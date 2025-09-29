using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvHisCondWork
    /// <summary>
    ///                      送受信履歴ログデータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   送受信履歴ログデータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   本多　美和</br>
    /// <br>Genarated Date   :   2011/07/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/23  馮文雄</br>
    /// <br>                 :   「送信対象物拠点コード」から「送信対象拠点コード」へ修正</br>
    /// <br>                 :   「送信対象物開始日時」から「送信対象開始日時」へ修正</br>
	/// <br>                 :   「送信対象物終了日時」から「送信対象終了日時」へ修正</br>
	/// <br>Update Note      :   2011/9/14  張莉莉</br>
	/// <br>                 :   Redmine #25051 #24952 送信履歴ログメンテ　データ表示の不正</br>
    /// <br>Update Note      :   2012/07/24 姚学剛 </br>
    /// <br>                 :   10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
    /// <br>Update Note      :   2012/10/16 李亜博</br>
    ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvHisCondWork : IFileHeader
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>参照企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _paraEnterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>送信日(開始)</summary>
        /// <remarks>200601011212(西暦日付＋時分）</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>送信日(終了)</summary>
        /// <remarks>200601011212(西暦日付＋時分）</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>送受信区分</summary>
        /// <remarks>0:送信（出力）,1:受信（取込）</remarks>
        private Int32 _sendOrReceiveDivCd;

        /// <summary>種別</summary>
        /// <remarks>0:データ　1:マスタ</remarks>
        private Int32 _kind;

        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

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

		// ADD 2011.09.14 --------->>>>>
		/// <summary>パラメータ拠点コード</summary>
		private string _paraSectionCode = "";

		/// <summary>送受信区分</summary>
		/// <remarks>0:送信（出力）,1:受信（取込）</remarks>
		private Int32 _paraSendOrReceiveDivCd;
		// ADD 2011.09.14 ---------<<<<<

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
        ///// <summary>送受信履歴ログ送信番号</summary>
        ///// <remarks>番号管理設定にて採番</remarks>
        //private Int32 _sndRcvHisConsNo;

        ///// <summary>送受信ファイルＩＤ</summary>
        //private string _sndRcvFileID = "";
        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<

        //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
        ///// public propaty name  :  SndRcvHisConsNo
        ///// <summary>送受信履歴ログ送信番号プロパティ</summary>
        ///// <value>番号管理設定にて採番</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   送受信履歴ログ送信番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SndRcvHisConsNo
        //{
        //    get { return _sndRcvHisConsNo; }
        //    set { _sndRcvHisConsNo = value; }
        //}

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

        /// public propaty name  :  ParaEnterpriseCode
        /// <summary>参照企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   参照企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParaEnterpriseCode
        {
            get { return _paraEnterpriseCode; }
            set { _paraEnterpriseCode = value; }
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

        /// public propaty name  :  SendDateTimeStart
        /// <summary>送信日(開始)プロパティ</summary>
        /// <value>200601011212(西暦日付＋時分）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>送信日(終了)プロパティ</summary>
        /// <value>200601011212(西暦日付＋時分）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
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
		// ADD 2011.09.14 --------->>>>>
		/// public propaty name  :  ParaSectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ParaSectionCode
		{
			get { return _paraSectionCode; }
			set { _paraSectionCode = value; }
		}

		/// public propaty name  :  ParaSendOrReceiveDivCd
		/// <summary>送受信区分プロパティ</summary>
		/// <value>0:送信（出力）,1:受信（取込）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   送受信区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ParaSendOrReceiveDivCd
		{
			get { return _paraSendOrReceiveDivCd; }
			set { _paraSendOrReceiveDivCd = value; }
		}
		// ADD 2011.09.14 ---------<<<<<

        /// <summary>
        /// 送受信履歴ログデータワークコンストラクタ
        /// </summary>
        /// <returns>SndRcvHisCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SndRcvHisCondWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SndRcvHisCondWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SndRcvHisCondWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SndRcvHisCondWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisCondWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvHisCondWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvHisCondWork || graph is ArrayList || graph is SndRcvHisCondWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SndRcvHisCondWork).FullName));

            if (graph != null && graph is SndRcvHisCondWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvHisCondWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvHisCondWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvHisCondWork[])graph).Length;
            }
            else if (graph is SndRcvHisCondWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //参照企業コード
            serInfo.MemberInfo.Add(typeof(string)); //ParaEnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //送信日(開始)
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTimeStart
            //送信日(終了)
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTimeEnd
            //送受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SendOrReceiveDivCd
            //種別
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
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

			// ADD 2011.09.14 ---------->>>>>
			//拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //ParaSectionCode
			//送受信区分
			serInfo.MemberInfo.Add(typeof(Int32)); //ParaSendOrReceiveDivCd
			// ADD 2011.09.14 ----------<<<<<

            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            ////送受信履歴ログ送信番号
            //serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsNo
            ////送受信ファイルＩＤ
            //serInfo.MemberInfo.Add(typeof(string)); //SndRcvFileID
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvHisCondWork)
            {
                SndRcvHisCondWork temp = (SndRcvHisCondWork)graph;

                SetSndRcvHisCondWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvHisCondWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvHisCondWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvHisCondWork temp in lst)
                {
                    SetSndRcvHisCondWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvHisCondWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 16;
        //private const int currentMemberCount = 18;    // DEL 2012/07/24 姚学剛//DEL 2012/10/16 李亜博 for redmine#31026
        private const int currentMemberCount = 16; //ADD 2012/10/16 李亜博 for redmine#31026

        /// <summary>
        ///  SndRcvHisCondWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisCondWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private void SetSndRcvHisCondWork(System.IO.BinaryWriter writer, SndRcvHisCondWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //参照企業コード
            writer.Write(temp.ParaEnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //送信日(開始)
            writer.Write(temp.SendDateTimeStart);
            //送信日(終了)
            writer.Write(temp.SendDateTimeEnd);
            //送受信区分
            writer.Write(temp.SendOrReceiveDivCd);
            //種別
            writer.Write(temp.Kind);
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
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
			// ADD 2011.09.14 ---------->>>>>
			//拠点コード
			writer.Write(temp.ParaSectionCode);
			//送受信区分
			writer.Write(temp.ParaSendOrReceiveDivCd);
			// ADD 2011.09.14 ----------<<<<<

            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            ////送受信履歴ログ送信番号
            //writer.Write(temp.SndRcvHisConsNo);
            ////送受信ファイルＩＤ
            //writer.Write(temp.SndRcvFileID);
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        }

        /// <summary>
        ///  SndRcvHisCondWorkインスタンス取得
        /// </summary>
        /// <returns>SndRcvHisCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisCondWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2012/10/16 李亜博</br>
        ///	<br>			         10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private SndRcvHisCondWork GetSndRcvHisCondWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SndRcvHisCondWork temp = new SndRcvHisCondWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //参照企業コード
            temp.ParaEnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //送信日(開始)
            temp.SendDateTimeStart = reader.ReadInt64();
            //送信日(終了)
            temp.SendDateTimeEnd = reader.ReadInt64();
            //送受信区分
            temp.SendOrReceiveDivCd = reader.ReadInt32();
            //種別
            temp.Kind = reader.ReadInt32();
            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
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
			// ADD 2011.09.14 ---------->>>>>
			//拠点コード
			temp.ParaSectionCode = reader.ReadString();
			//送受信区分
			temp.ParaSendOrReceiveDivCd = reader.ReadInt32();
			// ADD 2011.09.14 ----------<<<<<

            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            ////送受信履歴ログ送信番号
            //temp.SndRcvHisConsNo = reader.ReadInt32();
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
        /// <returns>SndRcvHisCondWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SndRcvHisCondWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvHisCondWork temp = GetSndRcvHisCondWork(reader, serInfo);
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
                    retValue = (SndRcvHisCondWork[])lst.ToArray(typeof(SndRcvHisCondWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
