//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/26  修正内容 : 拠点管理DCログ時間追加改良
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SecMngSndRcvWork
    /// <summary>
    ///                      拠点管理送受信対象ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   拠点管理送受信対象ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note : 2012/07/26 姚学剛 </br>
    /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCSecMngSndRcvWork : IFileHeader
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

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>マスタ名称</summary>
        private string _masterName = "";

        /// <summary>ファイルＩＤ</summary>
        private string _fileId = "";

        /// <summary>ファイル名称</summary>
        private string _fileNm = "";

        /// <summary>ユーザーガイド区分</summary>
        private Int32 _userGuideDivCd;

        /// <summary>拠点管理送信区分</summary>
        /// <remarks>0:送信なし 1:送信あり</remarks>
        private Int32 _secMngSendDiv;

        /// <summary>拠点管理受信区分</summary>
        /// <remarks>0:受信無 1:受信有（追加のみ） 2:受信有（追加・更新）</remarks>
        private Int32 _secMngRecvDiv;

        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>送受信履歴ログ送信番号</summary>
        private Int32 _sndRcvHisConsNo;

        /// <summary>送受信ログ抽出条件区分</summary>
        private Int32 _sndLogExtraCondDiv;

        /// <summary>送信先企業コード</summary>
        private string _sendDestEpCode = "";

        /// <summary>送信先拠点コード</summary>
        private string _sendDestSecCode = "";

        /// <summary>送受信状態</summary>
        /// <remarks>0:成功,1:失敗</remarks>
        private Int32 _sndRcvCondition;

        /// <summary>仮受信区分</summary>
        /// <remarks >1:受信,2:仮受信</remarks>
        private Int32 _tempReceiveDiv;

        /// <summary>送受信エラー内容</summary>
        private string _sndRcvErrContents = "";

        /// <summary>送受信ファイルＩＤ</summary>
        private string _sndRcvFileID = "";
        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

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

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  MasterName
        /// <summary>マスタ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MasterName
        {
            get { return _masterName; }
            set { _masterName = value; }
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

        /// public propaty name  :  FileNm
        /// <summary>ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileNm
        {
            get { return _fileNm; }
            set { _fileNm = value; }
        }

        /// public propaty name  :  UserGuideDivCd
        /// <summary>ユーザーガイド区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイド区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGuideDivCd
        {
            get { return _userGuideDivCd; }
            set { _userGuideDivCd = value; }
        }

        /// public propaty name  :  SecMngSendDiv
        /// <summary>拠点管理送信区分プロパティ</summary>
        /// <value>0:送信なし 1:送信あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点管理送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecMngSendDiv
        {
            get { return _secMngSendDiv; }
            set { _secMngSendDiv = value; }
        }

        /// public propaty name  :  SecMngRecvDiv
        /// <summary>拠点管理受信区分プロパティ</summary>
        /// <value>0:受信無 1:受信有（追加のみ） 2:受信有（追加・更新）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点管理受信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecMngRecvDiv
        {
            get { return _secMngRecvDiv; }
            set { _secMngRecvDiv = value; }
        }

        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
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
        /// <summary>送受信履歴ログ送信番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信履歴ログ送信番号パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvHisConsNo
        {
            get { return _sndRcvHisConsNo; }
            set { _sndRcvHisConsNo = value; }
        }

        /// public propaty name  :  SndLogExtraCondDiv
        /// <summary>送受信ログ抽出条件区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ログ抽出条件区分パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndLogExtraCondDiv
        {
            get { return _sndLogExtraCondDiv; }
            set { _sndLogExtraCondDiv = value; }
        }

        /// public propaty name  :  SendDestEpCode
        /// <summary>送信先企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先企業コードパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestEpCode
        {
            get { return _sendDestEpCode; }
            set { _sendDestEpCode = value; }
        }

        /// public propaty name  :  SendDestSecCode
        /// <summary>送信先拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信先拠点コードパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendDestSecCode
        {
            get { return _sendDestSecCode; }
            set { _sendDestSecCode = value; }
        }

        /// public propaty name  :  SndRcvCondition
        /// <summary>送受信状態</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信状態パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SndRcvCondition
        {
            get { return _sndRcvCondition; }
            set { _sndRcvCondition = value; }
        }

        /// public propaty name  :  TempReceiveDiv
        /// <summary>仮受信区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仮受信区分パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TempReceiveDiv
        {
            get { return _tempReceiveDiv; }
            set { _tempReceiveDiv = value; }
        }

        /// public propaty name  :  SndRcvErrContents
        /// <summary>送受信エラー内容</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信エラー内容パティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndRcvErrContents
        {
            get { return _sndRcvErrContents; }
            set { _sndRcvErrContents = value; }
        }

        /// public propaty name  :  SndRcvFileID
        /// <summary>送受信ファイルＩＤ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信ファイルＩＤパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SndRcvFileID
        {
            get { return _sndRcvFileID; }
            set { _sndRcvFileID = value; }
        }
        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

        /// <summary>
        /// 拠点管理送受信対象ワークコンストラクタ
        /// </summary>
        /// <returns>SecMngSndRcvWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DCSecMngSndRcvWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SecMngSndRcvWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SecMngSndRcvWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SecMngSndRcvWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SecMngSndRcvWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCSecMngSndRcvWork || graph is ArrayList || graph is DCSecMngSndRcvWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DCSecMngSndRcvWork).FullName));

            if (graph != null && graph is DCSecMngSndRcvWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCSecMngSndRcvWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCSecMngSndRcvWork[])graph).Length;
            }
            else if (graph is DCSecMngSndRcvWork)
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
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //マスタ名称
            serInfo.MemberInfo.Add(typeof(string)); //MasterName
            //ファイルＩＤ
            serInfo.MemberInfo.Add(typeof(string)); //FileId
            //ファイル名称
            serInfo.MemberInfo.Add(typeof(string)); //FileNm
            //ユーザーガイド区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGuideDivCd
            //拠点管理送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SecMngSendDiv
            //拠点管理受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SecMngRecvDiv
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string));  // SectionCode
            //送受信履歴ログ送信番号
            serInfo.MemberInfo.Add(typeof(Int32));  // SndRcvHisConsNo
            //送受信ログ抽出条件区分
            serInfo.MemberInfo.Add(typeof(Int32));  // SndLogExtraCondDiv
            //送信先企業コード
            serInfo.MemberInfo.Add(typeof(Int32));  // SndRcvCondition
            //送信先拠点コード
            serInfo.MemberInfo.Add(typeof(string));  // SendDestSecCode
            //送受信状態
            serInfo.MemberInfo.Add(typeof(Int32)); // SndRcvCondition
            //仮受信区分
            serInfo.MemberInfo.Add(typeof(Int32)); // TempReceiveDiv
            //送受信エラー内容
            serInfo.MemberInfo.Add(typeof(string)); // SndRcvErrContents
            //送受信ファイルＩＤ
            serInfo.MemberInfo.Add(typeof(string)); // SndRcvFileID
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is DCSecMngSndRcvWork)
            {
                DCSecMngSndRcvWork temp = (DCSecMngSndRcvWork)graph;

                SetSecMngSndRcvWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCSecMngSndRcvWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCSecMngSndRcvWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCSecMngSndRcvWork temp in lst)
                {
                    SetSecMngSndRcvWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SecMngSndRcvWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 15;    // DEL 2012/07/26 姚学剛
        private const int currentMemberCount = 24;  // ADD 2012/07/26 姚学剛

        /// <summary>
        ///  SecMngSndRcvWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </remarks>
        private void SetSecMngSndRcvWork(System.IO.BinaryWriter writer, DCSecMngSndRcvWork temp)
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
            //表示順位
            writer.Write(temp.DisplayOrder);
            //マスタ名称
            writer.Write(temp.MasterName);
            //ファイルＩＤ
            writer.Write(temp.FileId);
            //ファイル名称
            writer.Write(temp.FileNm);
            //ユーザーガイド区分
            writer.Write(temp.UserGuideDivCd);
            //拠点管理送信区分
            writer.Write(temp.SecMngSendDiv);
            //拠点管理受信区分
            writer.Write(temp.SecMngRecvDiv);
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            //拠点コード
            writer.Write(temp.SectionCode);
            //送受信履歴ログ送信番号
            writer.Write(temp.SndRcvHisConsNo);
            //送受信ログ抽出条件区分
            writer.Write(temp.SndLogExtraCondDiv);
            //送信先企業コード
            writer.Write(temp.SndRcvCondition);
            //送信先拠点コード
            writer.Write(temp.SendDestSecCode);
            //送受信状態
            writer.Write(temp.SndRcvCondition);
            //仮受信区分
            writer.Write(temp.TempReceiveDiv);
            //送受信エラー内容
            writer.Write(temp.SndRcvErrContents);
            //送受信ファイルＩＤ
            writer.Write(temp.SndRcvFileID);
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

        }

        /// <summary>
        ///  SecMngSndRcvWorkインスタンス取得
        /// </summary>
        /// <returns>SecMngSndRcvWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// </remarks>
        private DCSecMngSndRcvWork GetSecMngSndRcvWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DCSecMngSndRcvWork temp = new DCSecMngSndRcvWork();

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
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //マスタ名称
            temp.MasterName = reader.ReadString();
            //ファイルＩＤ
            temp.FileId = reader.ReadString();
            //ファイル名称
            temp.FileNm = reader.ReadString();
            //ユーザーガイド区分
            temp.UserGuideDivCd = reader.ReadInt32();
            //拠点管理送信区分
            temp.SecMngSendDiv = reader.ReadInt32();
            //拠点管理受信区分
            temp.SecMngRecvDiv = reader.ReadInt32();
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //送受信履歴ログ送信番号
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //送受信ログ抽出条件区分
            temp.SndLogExtraCondDiv = reader.ReadInt32();
            //送信先企業コード
            temp.SndRcvCondition = reader.ReadInt32();
            //送信先拠点コード
            temp.SendDestSecCode = reader.ReadString();
            //送受信状態
            temp.SndRcvCondition = reader.ReadInt32();
            //仮受信区分
            temp.TempReceiveDiv = reader.ReadInt32();
            //送受信エラー内容
            temp.SndRcvErrContents = reader.ReadString();
            //送受信ファイルＩＤ
            temp.SndRcvFileID = reader.ReadString();
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

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
        /// <returns>SecMngSndRcvWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecMngSndRcvWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCSecMngSndRcvWork temp = GetSecMngSndRcvWork(reader, serInfo);
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
                    retValue = (DCSecMngSndRcvWork[])lst.ToArray(typeof(DCSecMngSndRcvWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
