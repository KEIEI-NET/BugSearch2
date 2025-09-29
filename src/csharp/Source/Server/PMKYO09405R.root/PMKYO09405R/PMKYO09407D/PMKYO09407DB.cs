using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvEtrWork
    /// <summary>
    ///                      送受信抽出条件履歴ログデータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   送受信抽出条件履歴ログデータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/15</br>
    /// <br>Genarated Date   :   2011/07/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/23  馮文雄</br>
    /// <br>                 :   「論理削除区分」を追加。</br>
    /// <br>                 :   PKに項目「11」を追加</br>
    /// <br>Update Note      :   2011/8/23  孫東響</br>
    /// <br>                 :   #23826マスタ送受信処理：条件受信ができない</br>
    /// <br>                 :   送受信履歴ログ送信番号枝番はInt64からInt32に変更。</br> 
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvEtrWork : IFileHeader
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
        private string _sectionCode = "";

        /// <summary>送受信履歴ログ送信番号</summary>
        /// <remarks>番号管理設定にて採番</remarks>
        private Int32 _sndRcvHisConsNo;

        /// <summary>送受信履歴ログ送信番号枝番</summary>
		private Int32 _sndRcvHisConsDerivNo;

        /// <summary>種別</summary>
        private Int32 _kind;

        /// <summary>ファイルＩＤ</summary>
        private string _fileId = "";

        /// <summary>抽出開始日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _extraStartDate;

        /// <summary>抽出終了日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _extraEndDate;

        /// <summary>開始条件1</summary>
        private string _startCond1 = "";

        /// <summary>終了条件1</summary>
        private string _endCond1 = "";

        /// <summary>開始条件2</summary>
        private string _startCond2 = "";

        /// <summary>終了条件2</summary>
        private string _endCond2 = "";

        /// <summary>開始条件3</summary>
        private string _startCond3 = "";

        /// <summary>終了条件3</summary>
        private string _endCond3 = "";

        /// <summary>開始条件4</summary>
        private string _startCond4 = "";

        /// <summary>終了条件4</summary>
        private string _endCond4 = "";

        /// <summary>開始条件5</summary>
        private string _startCond5 = "";

        /// <summary>終了条件5</summary>
        private string _endCond5 = "";

        /// <summary>開始条件6</summary>
        private string _startCond6 = "";

        /// <summary>終了条件6</summary>
        private string _endCond6 = "";

        /// <summary>開始条件7</summary>
        private string _startCond7 = "";

        /// <summary>終了条件7</summary>
        private string _endCond7 = "";

        /// <summary>開始条件8</summary>
        private string _startCond8 = "";

        /// <summary>終了条件8</summary>
        private string _endCond8 = "";

        /// <summary>開始条件9</summary>
        private string _startCond9 = "";

        /// <summary>終了条件9</summary>
        private string _endCond9 = "";

        /// <summary>開始条件10</summary>
        private string _startCond10 = "";

        /// <summary>終了条件10</summary>
        private string _endCond10 = "";


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

        /// public propaty name  :  SndRcvHisConsNo
        /// <summary>送受信履歴ログ送信番号プロパティ</summary>
        /// <value>番号管理設定にて採番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信履歴ログ送信番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvHisConsNo
        {
            get { return _sndRcvHisConsNo; }
            set { _sndRcvHisConsNo = value; }
        }

        /// public propaty name  :  SndRcvHisConsDerivNo
        /// <summary>送受信履歴ログ送信番号枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信履歴ログ送信番号枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
		public Int32 SndRcvHisConsDerivNo
        {
            get { return _sndRcvHisConsDerivNo; }
            set { _sndRcvHisConsDerivNo = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// public propaty name  :  FileId
        /// <summary>ファイルＩＤプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルＩＤプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }

        /// public propaty name  :  ExtraStartDate
        /// <summary>抽出開始日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExtraStartDate
        {
            get { return _extraStartDate; }
            set { _extraStartDate = value; }
        }

        /// public propaty name  :  ExtraEndDate
        /// <summary>抽出終了日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExtraEndDate
        {
            get { return _extraEndDate; }
            set { _extraEndDate = value; }
        }

        /// public propaty name  :  StartCond1
        /// <summary>開始条件1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond1
        {
            get { return _startCond1; }
            set { _startCond1 = value; }
        }

        /// public propaty name  :  EndCond1
        /// <summary>終了条件1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond1
        {
            get { return _endCond1; }
            set { _endCond1 = value; }
        }

        /// public propaty name  :  StartCond2
        /// <summary>開始条件2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond2
        {
            get { return _startCond2; }
            set { _startCond2 = value; }
        }

        /// public propaty name  :  EndCond2
        /// <summary>終了条件2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond2
        {
            get { return _endCond2; }
            set { _endCond2 = value; }
        }

        /// public propaty name  :  StartCond3
        /// <summary>開始条件3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond3
        {
            get { return _startCond3; }
            set { _startCond3 = value; }
        }

        /// public propaty name  :  EndCond3
        /// <summary>終了条件3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond3
        {
            get { return _endCond3; }
            set { _endCond3 = value; }
        }

        /// public propaty name  :  StartCond4
        /// <summary>開始条件4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond4
        {
            get { return _startCond4; }
            set { _startCond4 = value; }
        }

        /// public propaty name  :  EndCond4
        /// <summary>終了条件4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond4
        {
            get { return _endCond4; }
            set { _endCond4 = value; }
        }

        /// public propaty name  :  StartCond5
        /// <summary>開始条件5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond5
        {
            get { return _startCond5; }
            set { _startCond5 = value; }
        }

        /// public propaty name  :  EndCond5
        /// <summary>終了条件5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond5
        {
            get { return _endCond5; }
            set { _endCond5 = value; }
        }

        /// public propaty name  :  StartCond6
        /// <summary>開始条件6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond6
        {
            get { return _startCond6; }
            set { _startCond6 = value; }
        }

        /// public propaty name  :  EndCond6
        /// <summary>終了条件6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond6
        {
            get { return _endCond6; }
            set { _endCond6 = value; }
        }

        /// public propaty name  :  StartCond7
        /// <summary>開始条件7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond7
        {
            get { return _startCond7; }
            set { _startCond7 = value; }
        }

        /// public propaty name  :  EndCond7
        /// <summary>終了条件7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond7
        {
            get { return _endCond7; }
            set { _endCond7 = value; }
        }

        /// public propaty name  :  StartCond8
        /// <summary>開始条件8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond8
        {
            get { return _startCond8; }
            set { _startCond8 = value; }
        }

        /// public propaty name  :  EndCond8
        /// <summary>終了条件8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond8
        {
            get { return _endCond8; }
            set { _endCond8 = value; }
        }

        /// public propaty name  :  StartCond9
        /// <summary>開始条件9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond9
        {
            get { return _startCond9; }
            set { _startCond9 = value; }
        }

        /// public propaty name  :  EndCond9
        /// <summary>終了条件9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond9
        {
            get { return _endCond9; }
            set { _endCond9 = value; }
        }

        /// public propaty name  :  StartCond10
        /// <summary>開始条件10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始条件10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartCond10
        {
            get { return _startCond10; }
            set { _startCond10 = value; }
        }

        /// public propaty name  :  EndCond10
        /// <summary>終了条件10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了条件10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndCond10
        {
            get { return _endCond10; }
            set { _endCond10 = value; }
        }


        /// <summary>
        /// 送受信抽出条件履歴ログデータワークコンストラクタ
        /// </summary>
        /// <returns>SndRcvEtrWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvEtrWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SndRcvEtrWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SndRcvEtrWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SndRcvEtrWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SndRcvEtrWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvEtrWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvEtrWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvEtrWork || graph is ArrayList || graph is SndRcvEtrWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SndRcvEtrWork).FullName));

            if (graph != null && graph is SndRcvEtrWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvEtrWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvEtrWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvEtrWork[])graph).Length;
            }
            else if (graph is SndRcvEtrWork)
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
            //送受信履歴ログ送信番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsNo
            //送受信履歴ログ送信番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsDerivNo
            //種別
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //ファイルＩＤ
            serInfo.MemberInfo.Add(typeof(string)); //FileId
            //抽出開始日時
            serInfo.MemberInfo.Add(typeof(Int64)); //ExtraStartDate
            //抽出終了日時
            serInfo.MemberInfo.Add(typeof(Int64)); //ExtraEndDate
            //開始条件1
            serInfo.MemberInfo.Add(typeof(string)); //StartCond1
            //終了条件1
            serInfo.MemberInfo.Add(typeof(string)); //EndCond1
            //開始条件2
            serInfo.MemberInfo.Add(typeof(string)); //StartCond2
            //終了条件2
            serInfo.MemberInfo.Add(typeof(string)); //EndCond2
            //開始条件3
            serInfo.MemberInfo.Add(typeof(string)); //StartCond3
            //終了条件3
            serInfo.MemberInfo.Add(typeof(string)); //EndCond3
            //開始条件4
            serInfo.MemberInfo.Add(typeof(string)); //StartCond4
            //終了条件4
            serInfo.MemberInfo.Add(typeof(string)); //EndCond4
            //開始条件5
            serInfo.MemberInfo.Add(typeof(string)); //StartCond5
            //終了条件5
            serInfo.MemberInfo.Add(typeof(string)); //EndCond5
            //開始条件6
            serInfo.MemberInfo.Add(typeof(string)); //StartCond6
            //終了条件6
            serInfo.MemberInfo.Add(typeof(string)); //EndCond6
            //開始条件7
            serInfo.MemberInfo.Add(typeof(string)); //StartCond7
            //終了条件7
            serInfo.MemberInfo.Add(typeof(string)); //EndCond7
            //開始条件8
            serInfo.MemberInfo.Add(typeof(string)); //StartCond8
            //終了条件8
            serInfo.MemberInfo.Add(typeof(string)); //EndCond8
            //開始条件9
            serInfo.MemberInfo.Add(typeof(string)); //StartCond9
            //終了条件9
            serInfo.MemberInfo.Add(typeof(string)); //EndCond9
            //開始条件10
            serInfo.MemberInfo.Add(typeof(string)); //StartCond10
            //終了条件10
            serInfo.MemberInfo.Add(typeof(string)); //EndCond10


            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvEtrWork)
            {
                SndRcvEtrWork temp = (SndRcvEtrWork)graph;

                SetSndRcvEtrWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvEtrWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvEtrWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvEtrWork temp in lst)
                {
                    SetSndRcvEtrWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvEtrWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  SndRcvEtrWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvEtrWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSndRcvEtrWork(System.IO.BinaryWriter writer, SndRcvEtrWork temp)
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
            //送受信履歴ログ送信番号
            writer.Write(temp.SndRcvHisConsNo);
            //送受信履歴ログ送信番号枝番
            writer.Write(temp.SndRcvHisConsDerivNo);
            //種別
            writer.Write(temp.Kind);
            //ファイルＩＤ
            writer.Write(temp.FileId);
            //抽出開始日時
            writer.Write((Int64)temp.ExtraStartDate.Ticks);
            //抽出終了日時
            writer.Write((Int64)temp.ExtraEndDate.Ticks);
            //開始条件1
            writer.Write(temp.StartCond1);
            //終了条件1
            writer.Write(temp.EndCond1);
            //開始条件2
            writer.Write(temp.StartCond2);
            //終了条件2
            writer.Write(temp.EndCond2);
            //開始条件3
            writer.Write(temp.StartCond3);
            //終了条件3
            writer.Write(temp.EndCond3);
            //開始条件4
            writer.Write(temp.StartCond4);
            //終了条件4
            writer.Write(temp.EndCond4);
            //開始条件5
            writer.Write(temp.StartCond5);
            //終了条件5
            writer.Write(temp.EndCond5);
            //開始条件6
            writer.Write(temp.StartCond6);
            //終了条件6
            writer.Write(temp.EndCond6);
            //開始条件7
            writer.Write(temp.StartCond7);
            //終了条件7
            writer.Write(temp.EndCond7);
            //開始条件8
            writer.Write(temp.StartCond8);
            //終了条件8
            writer.Write(temp.EndCond8);
            //開始条件9
            writer.Write(temp.StartCond9);
            //終了条件9
            writer.Write(temp.EndCond9);
            //開始条件10
            writer.Write(temp.StartCond10);
            //終了条件10
            writer.Write(temp.EndCond10);

        }

        /// <summary>
        ///  SndRcvEtrWorkインスタンス取得
        /// </summary>
        /// <returns>SndRcvEtrWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvEtrWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SndRcvEtrWork GetSndRcvEtrWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SndRcvEtrWork temp = new SndRcvEtrWork();

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
            //送受信履歴ログ送信番号
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //送受信履歴ログ送信番号枝番
            temp.SndRcvHisConsDerivNo = reader.ReadInt32();
            //種別
            temp.Kind = reader.ReadInt32();
            //ファイルＩＤ
            temp.FileId = reader.ReadString();
            //抽出開始日時
            temp.ExtraStartDate = new DateTime(reader.ReadInt64());
            //抽出終了日時
            temp.ExtraEndDate = new DateTime(reader.ReadInt64());
            //開始条件1
            temp.StartCond1 = reader.ReadString();
            //終了条件1
            temp.EndCond1 = reader.ReadString();
            //開始条件2
            temp.StartCond2 = reader.ReadString();
            //終了条件2
            temp.EndCond2 = reader.ReadString();
            //開始条件3
            temp.StartCond3 = reader.ReadString();
            //終了条件3
            temp.EndCond3 = reader.ReadString();
            //開始条件4
            temp.StartCond4 = reader.ReadString();
            //終了条件4
            temp.EndCond4 = reader.ReadString();
            //開始条件5
            temp.StartCond5 = reader.ReadString();
            //終了条件5
            temp.EndCond5 = reader.ReadString();
            //開始条件6
            temp.StartCond6 = reader.ReadString();
            //終了条件6
            temp.EndCond6 = reader.ReadString();
            //開始条件7
            temp.StartCond7 = reader.ReadString();
            //終了条件7
            temp.EndCond7 = reader.ReadString();
            //開始条件8
            temp.StartCond8 = reader.ReadString();
            //終了条件8
            temp.EndCond8 = reader.ReadString();
            //開始条件9
            temp.StartCond9 = reader.ReadString();
            //終了条件9
            temp.EndCond9 = reader.ReadString();
            //開始条件10
            temp.StartCond10 = reader.ReadString();
            //終了条件10
            temp.EndCond10 = reader.ReadString();


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
        /// <returns>SndRcvEtrWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvEtrWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvEtrWork temp = GetSndRcvEtrWork(reader, serInfo);
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
                    retValue = (SndRcvEtrWork[])lst.ToArray(typeof(SndRcvEtrWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
