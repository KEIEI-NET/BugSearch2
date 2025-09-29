//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）_一覧情報ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyUOEOrderListWork
    /// <summary>
    ///                      ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル在庫仕入（入庫更新）_一覧情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyUOEOrderListWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>オンライン番号</summary>
        private Int32 _onlineNo;

        /// <summary>UOE発注番号</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>UOE拠点伝票番号</summary>
        private string _uOESectionSlipNo = "";

        /// <summary>BO伝票番号１</summary>
        /// <remarks>サブ本部フォロー伝票№</remarks>
        private string _bOSlipNo1 = "";

        /// <summary>BO伝票番号２</summary>
        /// <remarks>本部フォロー伝票№</remarks>
        private string _bOSlipNo2 = "";

        /// <summary>BO伝票番号３</summary>
        /// <remarks>ルートフォロー伝票№</remarks>
        private string _bOSlipNo3 = "";

        /// <summary>入庫更新区分（拠点）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivSec;

        /// <summary>入庫更新区分（BO1）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivBO1;

        /// <summary>入庫更新区分（BO2）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivBO2;

        /// <summary>入庫更新区分（BO3）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivBO3;

        /// <summary>入庫更新区分（ﾒｰｶｰ）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivMaker;

        /// <summary>入庫更新区分（EO）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivEO;

        /// <summary>通信アセンブリID</summary>
        private string _commAssemblyId = "";


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

        /// public propaty name  :  OnlineNo
        /// <summary>オンライン番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
        }

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UOESectionSlipNo
        /// <summary>UOE拠点伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionSlipNo
        {
            get { return _uOESectionSlipNo; }
            set { _uOESectionSlipNo = value; }
        }

        /// public propaty name  :  BOSlipNo1
        /// <summary>BO伝票番号１プロパティ</summary>
        /// <value>サブ本部フォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo1
        {
            get { return _bOSlipNo1; }
            set { _bOSlipNo1 = value; }
        }

        /// public propaty name  :  BOSlipNo2
        /// <summary>BO伝票番号２プロパティ</summary>
        /// <value>本部フォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo2
        {
            get { return _bOSlipNo2; }
            set { _bOSlipNo2 = value; }
        }

        /// public propaty name  :  BOSlipNo3
        /// <summary>BO伝票番号３プロパティ</summary>
        /// <value>ルートフォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo3
        {
            get { return _bOSlipNo3; }
            set { _bOSlipNo3 = value; }
        }

        /// public propaty name  :  EnterUpdDivSec
        /// <summary>入庫更新区分（拠点）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（拠点）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivSec
        {
            get { return _enterUpdDivSec; }
            set { _enterUpdDivSec = value; }
        }

        /// public propaty name  :  EnterUpdDivBO1
        /// <summary>入庫更新区分（BO1）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（BO1）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivBO1
        {
            get { return _enterUpdDivBO1; }
            set { _enterUpdDivBO1 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO2
        /// <summary>入庫更新区分（BO2）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（BO2）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivBO2
        {
            get { return _enterUpdDivBO2; }
            set { _enterUpdDivBO2 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO3
        /// <summary>入庫更新区分（BO3）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（BO3）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivBO3
        {
            get { return _enterUpdDivBO3; }
            set { _enterUpdDivBO3 = value; }
        }

        /// public propaty name  :  EnterUpdDivMaker
        /// <summary>入庫更新区分（ﾒｰｶｰ）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（ﾒｰｶｰ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivMaker
        {
            get { return _enterUpdDivMaker; }
            set { _enterUpdDivMaker = value; }
        }

        /// public propaty name  :  EnterUpdDivEO
        /// <summary>入庫更新区分（EO）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（EO）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivEO
        {
            get { return _enterUpdDivEO; }
            set { _enterUpdDivEO = value; }
        }

        /// public propaty name  :  CommAssemblyId
        /// <summary>通信アセンブリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信アセンブリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }


        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧情報ワークコンストラクタ
        /// </summary>
        /// <returns>HandyUOEOrderListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderListWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyUOEOrderListWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>HandyUOEOrderListWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyUOEOrderListWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyUOEOrderListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderListWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyUOEOrderListWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyUOEOrderListWork || graph is ArrayList || graph is HandyUOEOrderListWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyUOEOrderListWork).FullName));

            if (graph != null && graph is HandyUOEOrderListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderListWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyUOEOrderListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyUOEOrderListWork[])graph).Length;
            }
            else if (graph is HandyUOEOrderListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //オンライン番号
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //UOE発注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //UOE拠点伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //BO伝票番号１
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO伝票番号２
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO伝票番号３
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //入庫更新区分（拠点）
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivSec
            //入庫更新区分（BO1）
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivBO1
            //入庫更新区分（BO2）
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivBO2
            //入庫更新区分（BO3）
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivBO3
            //入庫更新区分（ﾒｰｶｰ）
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivMaker
            //入庫更新区分（EO）
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivEO
            //通信アセンブリID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyUOEOrderListWork)
            {
                HandyUOEOrderListWork temp = (HandyUOEOrderListWork)graph;

                SetHandyUOEOrderListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyUOEOrderListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyUOEOrderListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyUOEOrderListWork temp in lst)
                {
                    SetHandyUOEOrderListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyUOEOrderListWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  HandyUOEOrderListWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderListWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyUOEOrderListWork(System.IO.BinaryWriter writer, HandyUOEOrderListWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //オンライン番号
            writer.Write(temp.OnlineNo);
            //UOE発注番号
            writer.Write(temp.UOESalesOrderNo);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //UOE拠点伝票番号
            writer.Write(temp.UOESectionSlipNo);
            //BO伝票番号１
            writer.Write(temp.BOSlipNo1);
            //BO伝票番号２
            writer.Write(temp.BOSlipNo2);
            //BO伝票番号３
            writer.Write(temp.BOSlipNo3);
            //入庫更新区分（拠点）
            writer.Write(temp.EnterUpdDivSec);
            //入庫更新区分（BO1）
            writer.Write(temp.EnterUpdDivBO1);
            //入庫更新区分（BO2）
            writer.Write(temp.EnterUpdDivBO2);
            //入庫更新区分（BO3）
            writer.Write(temp.EnterUpdDivBO3);
            //入庫更新区分（ﾒｰｶｰ）
            writer.Write(temp.EnterUpdDivMaker);
            //入庫更新区分（EO）
            writer.Write(temp.EnterUpdDivEO);
            //通信アセンブリID
            writer.Write(temp.CommAssemblyId);

        }

        /// <summary>
        ///  HandyUOEOrderListWorkインスタンス取得
        /// </summary>
        /// <returns>HandyUOEOrderListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderListWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyUOEOrderListWork GetHandyUOEOrderListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyUOEOrderListWork temp = new HandyUOEOrderListWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //オンライン番号
            temp.OnlineNo = reader.ReadInt32();
            //UOE発注番号
            temp.UOESalesOrderNo = reader.ReadInt32();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //UOE拠点伝票番号
            temp.UOESectionSlipNo = reader.ReadString();
            //BO伝票番号１
            temp.BOSlipNo1 = reader.ReadString();
            //BO伝票番号２
            temp.BOSlipNo2 = reader.ReadString();
            //BO伝票番号３
            temp.BOSlipNo3 = reader.ReadString();
            //入庫更新区分（拠点）
            temp.EnterUpdDivSec = reader.ReadInt32();
            //入庫更新区分（BO1）
            temp.EnterUpdDivBO1 = reader.ReadInt32();
            //入庫更新区分（BO2）
            temp.EnterUpdDivBO2 = reader.ReadInt32();
            //入庫更新区分（BO3）
            temp.EnterUpdDivBO3 = reader.ReadInt32();
            //入庫更新区分（ﾒｰｶｰ）
            temp.EnterUpdDivMaker = reader.ReadInt32();
            //入庫更新区分（EO）
            temp.EnterUpdDivEO = reader.ReadInt32();
            //通信アセンブリID
            temp.CommAssemblyId = reader.ReadString();


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
        /// <returns>HandyUOEOrderListWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderListWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyUOEOrderListWork temp = GetHandyUOEOrderListWork(reader, serInfo);
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
                    retValue = (HandyUOEOrderListWork[])lst.ToArray(typeof(HandyUOEOrderListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
