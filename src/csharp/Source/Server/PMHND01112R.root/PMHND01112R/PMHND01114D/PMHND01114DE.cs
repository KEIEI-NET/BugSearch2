//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク（HT/APサーバー用）ワーク
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク（HT/APサーバー用）ワークです
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
    /// public class name:   HandyUOEOrderResultListWork
    /// <summary>
    ///                      ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク（HT/APサーバー用）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク（HT/APサーバー用）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyUOEOrderResultListWork
    {
        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>伝票番号</summary>
        private string _slipNo = "";

        /// <summary>オンライン番号</summary>
        private Int32 _onlineNo;

        /// <summary>UOE発注番号</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>入庫区分</summary>
        /// <remarks>1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO</remarks>
        private Int32 _warehousingDivCd;


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

        /// public propaty name  :  SlipNo
        /// <summary>伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
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

        /// public propaty name  :  WarehousingDivCd
        /// <summary>入庫区分プロパティ</summary>
        /// <value>1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehousingDivCd
        {
            get { return _warehousingDivCd; }
            set { _warehousingDivCd = value; }
        }


        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧情報ワーク（HT/APサーバー用）ワークコンストラクタ
        /// </summary>
        /// <returns>HandyUOEOrderResultListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderResultListWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyUOEOrderResultListWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>HandyUOEOrderResultListWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyUOEOrderResultListWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyUOEOrderResultListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderResultListWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyUOEOrderResultListWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyUOEOrderResultListWork || graph is ArrayList || graph is HandyUOEOrderResultListWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyUOEOrderResultListWork).FullName));

            if (graph != null && graph is HandyUOEOrderResultListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderResultListWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyUOEOrderResultListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyUOEOrderResultListWork[])graph).Length;
            }
            else if (graph is HandyUOEOrderResultListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SlipNo
            //オンライン番号
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //UOE発注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //入庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehousingDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyUOEOrderResultListWork)
            {
                HandyUOEOrderResultListWork temp = (HandyUOEOrderResultListWork)graph;

                SetHandyUOEOrderResultListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyUOEOrderResultListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyUOEOrderResultListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyUOEOrderResultListWork temp in lst)
                {
                    SetHandyUOEOrderResultListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyUOEOrderResultListWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  HandyUOEOrderResultListWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderResultListWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyUOEOrderResultListWork(System.IO.BinaryWriter writer, HandyUOEOrderResultListWork temp)
        {
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //伝票番号
            writer.Write(temp.SlipNo);
            //オンライン番号
            writer.Write(temp.OnlineNo);
            //UOE発注番号
            writer.Write(temp.UOESalesOrderNo);
            //入庫区分
            writer.Write(temp.WarehousingDivCd);

        }

        /// <summary>
        ///  HandyUOEOrderResultListWorkインスタンス取得
        /// </summary>
        /// <returns>HandyUOEOrderResultListWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderResultListWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyUOEOrderResultListWork GetHandyUOEOrderResultListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyUOEOrderResultListWork temp = new HandyUOEOrderResultListWork();

            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //伝票番号
            temp.SlipNo = reader.ReadString();
            //オンライン番号
            temp.OnlineNo = reader.ReadInt32();
            //UOE発注番号
            temp.UOESalesOrderNo = reader.ReadInt32();
            //入庫区分
            temp.WarehousingDivCd = reader.ReadInt32();


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
        /// <returns>HandyUOEOrderResultListWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyUOEOrderResultListWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyUOEOrderResultListWork temp = GetHandyUOEOrderResultListWork(reader, serInfo);
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
                    retValue = (HandyUOEOrderResultListWork[])lst.ToArray(typeof(HandyUOEOrderResultListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
