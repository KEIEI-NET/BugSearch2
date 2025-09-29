using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvHisWork
    /// <summary>
    ///                      送受信履歴ログデータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   送受信履歴ログデータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   本多　美和</br>
    /// <br>Genarated Date   :   2011/07/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/23  馮文雄</br>
    /// <br>                 :   「送信対象物拠点コード」から「送信対象拠点コード」へ修正</br>
    /// <br>                 :   「送信対象物開始日時」から「送信対象開始日時」へ修正</br>
    /// <br>                 :   「送信対象物終了日時」から「送信対象終了日時」へ修正</br>
    /// <br>Update Note      :   2011/11/30  譚洪</br>
    /// <br>                 :   Redmine #8293 拠点管理／伝票日付日付抽出改良</br>
    /// <br>Update Note      :   2012/07/26 姚学剛 </br>
    /// <br>                 :   10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
    /// <br>Update Note      :   2012/10/16 李亜博</br>
    ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvHisWork : IFileHeader
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

        /// <summary>送信日時</summary>
        /// <remarks>200601011212(西暦日付＋時分）</remarks>
        private Int64 _sendDateTime;

        /// <summary>送受信ログ利用区分</summary>
        /// <remarks>ログの利用形態 0:拠点管理</remarks>
        private Int32 _sndLogUseDiv;

        /// <summary>送受信区分</summary>
        /// <remarks>0:送信（出力）,1:受信（取込）</remarks>
        private Int32 _sendOrReceiveDivCd;

        /// <summary>種別</summary>
        /// <remarks>0:データ　1:マスタ</remarks>
        private Int32 _kind;

        /// <summary>送受信ログ抽出条件区分</summary>
        /// <remarks>0:自動(差分),1:手動</remarks>
        private Int32 _sndLogExtraCondDiv;

        /// <summary>送信対象拠点コード</summary>
        /// <remarks>送信データ（マスタ）の所属する拠点</remarks>
        private string _extraObjSecCode = "";

        /// <summary>送信対象開始日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _sndObjStartDate;

        /// <summary>送信対象終了日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _sndObjEndDate;

        /// <summary>送信先企業コード</summary>
        private string _sendDestEpCode = "";

        /// <summary>送信先拠点コード</summary>
        private string _sendDestSecCode = "";

        /// <summary>シンク実行日付</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _syncExecDate;

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
        ///// <summary>送受信ファイルＩＤ</summary>
        //private string _sndRcvFileID = "";
        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        /// public propaty name  :  SyncExecDate
        /// <summary>シンク実行日付プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シンク実行日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
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

        /// public propaty name  :  SendDateTime
        /// <summary>送信日時プロパティ</summary>
        /// <value>200601011212(西暦日付＋時分）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTime
        {
            get { return _sendDateTime; }
            set { _sendDateTime = value; }
        }

        /// public propaty name  :  SndLogUseDiv
        /// <summary>送受信ログ利用区分プロパティ</summary>
        /// <value>ログの利用形態 0:拠点管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ログ利用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndLogUseDiv
        {
            get { return _sndLogUseDiv; }
            set { _sndLogUseDiv = value; }
        }

        /// public propaty name  :  SendOrReceiveDivCd
        /// <summary>送受信区分プロパティ</summary>
        /// <value>0:送信（出力）,1:受信（取込）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendOrReceiveDivCd
        {
            get { return _sendOrReceiveDivCd; }
            set { _sendOrReceiveDivCd = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>種別プロパティ</summary>
        /// <value>0:データ　1:マスタ</value>
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

        /// public propaty name  :  SndLogExtraCondDiv
        /// <summary>送受信ログ抽出条件区分プロパティ</summary>
        /// <value>0:自動(差分),1:手動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ログ抽出条件区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndLogExtraCondDiv
        {
            get { return _sndLogExtraCondDiv; }
            set { _sndLogExtraCondDiv = value; }
        }

        /// public propaty name  :  ExtraObjSecCode
        /// <summary>送信対象拠点コードプロパティ</summary>
        /// <value>送信データ（マスタ）の所属する拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExtraObjSecCode
        {
            get { return _extraObjSecCode; }
            set { _extraObjSecCode = value; }
        }

        /// public propaty name  :  SndObjStartDate
        /// <summary>送信対象開始日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SndObjStartDate
        {
            get { return _sndObjStartDate; }
            set { _sndObjStartDate = value; }
        }

        /// public propaty name  :  SndObjEndDate
        /// <summary>送信対象終了日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信対象終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SndObjEndDate
        {
            get { return _sndObjEndDate; }
            set { _sndObjEndDate = value; }
        }

        /// public propaty name  :  SendDestEpCode
        /// <summary>送信先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestEpCode
        {
            get { return _sendDestEpCode; }
            set { _sendDestEpCode = value; }
        }

        /// public propaty name  :  SendDestSecCode
        /// <summary>送信先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestSecCode
        {
            get { return _sendDestSecCode; }
            set { _sendDestSecCode = value; }
        }

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
        ///// public propaty name  :  SndRcvFileID
        ///// <summary>送受信ファイルＩＤ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   送受信ファイルＩＤパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SndRcvFileID
        //{
        //    get { return _sndRcvFileID; }
        //    set { _sndRcvFileID = value; }
        //}
        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
        
        /// <summary>
        /// 送受信履歴ログデータワークコンストラクタ
        /// </summary>
        /// <returns>SndRcvHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SndRcvHisWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SndRcvHisWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SndRcvHisWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note : 2012/07/24 姚学剛 </br>
    /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
    /// </remarks>
    public class SndRcvHisWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvHisWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvHisWork || graph is ArrayList || graph is SndRcvHisWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SndRcvHisWork).FullName));

            if (graph != null && graph is SndRcvHisWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvHisWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvHisWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvHisWork[])graph).Length;
            }
            else if (graph is SndRcvHisWork)
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
            //送信日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTime
            //送受信ログ利用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SndLogUseDiv
            //送受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SendOrReceiveDivCd
            //種別
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //送受信ログ抽出条件区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SndLogExtraCondDiv
            //送信対象拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ExtraObjSecCode
            //送信対象開始日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndObjStartDate
            //送信対象終了日時
            serInfo.MemberInfo.Add(typeof(Int64)); //SndObjEndDate
            //送信先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //SendDestEpCode
            //送信先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SendDestSecCode
            //シンク実行日付
            serInfo.MemberInfo.Add(typeof(Int64)); //SyncExecDate

            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            ////送受信ファイルＩＤ
            //serInfo.MemberInfo.Add(typeof(string)); //SndRcvFileID
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvHisWork)
            {
                SndRcvHisWork temp = (SndRcvHisWork)graph;

                SetSndRcvHisWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvHisWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvHisWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvHisWork temp in lst)
                {
                    SetSndRcvHisWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvHisWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 20;
        //private const int currentMemberCount = 21;    // DEL 2012/07/24 姚学剛
        //private const int currentMemberCount = 22;  // ADD 2012/07/24 姚学剛//DEL 2012/10/16 李亜博 for redmine#31026
        private const int currentMemberCount = 21; //ADD 2012/10/16 李亜博 for redmine#31026

        /// <summary>
        ///  SndRcvHisWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private void SetSndRcvHisWork(System.IO.BinaryWriter writer, SndRcvHisWork temp)
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
            //送信日時
            writer.Write(temp.SendDateTime);
            //送受信ログ利用区分
            writer.Write(temp.SndLogUseDiv);
            //送受信区分
            writer.Write(temp.SendOrReceiveDivCd);
            //種別
            writer.Write(temp.Kind);
            //送受信ログ抽出条件区分
            writer.Write(temp.SndLogExtraCondDiv);
            //送信対象拠点コード
            writer.Write(temp.ExtraObjSecCode);
            //送信対象開始日時
            writer.Write((Int64)temp.SndObjStartDate.Ticks);
            //送信対象終了日時
            writer.Write((Int64)temp.SndObjEndDate.Ticks);
            //送信先企業コード
            writer.Write(temp.SendDestEpCode);
            //送信先拠点コード
            writer.Write(temp.SendDestSecCode);
            //シンク実行日付
            writer.Write((Int64)temp.SyncExecDate.Ticks);
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            ////送受信ファイルＩＤ
            //writer.Write(temp.SndRcvFileID);
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        }

        /// <summary>
        ///  SndRcvHisWorkインスタンス取得
        /// </summary>
        /// <returns>SndRcvHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private SndRcvHisWork GetSndRcvHisWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SndRcvHisWork temp = new SndRcvHisWork();

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
            //送信日時
            temp.SendDateTime = reader.ReadInt64();
            //送受信ログ利用区分
            temp.SndLogUseDiv = reader.ReadInt32();
            //送受信区分
            temp.SendOrReceiveDivCd = reader.ReadInt32();
            //種別
            temp.Kind = reader.ReadInt32();
            //送受信ログ抽出条件区分
            temp.SndLogExtraCondDiv = reader.ReadInt32();
            //送信対象拠点コード
            temp.ExtraObjSecCode = reader.ReadString();
            //送信対象開始日時
            temp.SndObjStartDate = new DateTime(reader.ReadInt64());
            //送信対象終了日時
            temp.SndObjEndDate = new DateTime(reader.ReadInt64());
            //送信先企業コード
            temp.SendDestEpCode = reader.ReadString();
            //送信先拠点コード
            temp.SendDestSecCode = reader.ReadString();
            //シンク実行日付
            temp.SyncExecDate = new DateTime(reader.ReadInt64());
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            ////送受信ファイルＩＤ
            //temp.SndRcvFileID = reader.ReadString();
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            


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
        /// <returns>SndRcvHisWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvHisWork temp = GetSndRcvHisWork(reader, serInfo);
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
                    retValue = (SndRcvHisWork[])lst.ToArray(typeof(SndRcvHisWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
