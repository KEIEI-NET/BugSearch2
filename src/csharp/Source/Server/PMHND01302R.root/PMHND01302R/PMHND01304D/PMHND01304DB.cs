//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充の倉庫情報検索結果ワーク
// プログラム概要   : ハンディターミナル委託在庫補充の倉庫情報検索結果ワークです
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
    /// public class name:   ConsStockRepWarehouseRetWork
    /// <summary>
    ///                      委託在庫補充の倉庫情報取得結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充の倉庫情報取得結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepWarehouseRetWork
    {
        /// <summary>委託倉庫コード</summary>
        private string _consignWarehouseCode = "";

        /// <summary>委託倉庫名称</summary>
        private string _consignWarehouseName = "";

        /// <summary>主管元倉庫コード</summary>
        /// <remarks>委託の場合に在庫補充を行う元の倉庫</remarks>
        private string _mainMngWarehouseCd = "";

        /// <summary>主管元倉庫名称</summary>
        private string _mainMngWarehouseName = "";


        /// public propaty name  :  ConsignWarehouseCode
        /// <summary>委託倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ConsignWarehouseCode
        {
            get { return _consignWarehouseCode; }
            set { _consignWarehouseCode = value; }
        }

        /// public propaty name  :  ConsignWarehouseName
        /// <summary>委託倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ConsignWarehouseName
        {
            get { return _consignWarehouseName; }
            set { _consignWarehouseName = value; }
        }

        /// public propaty name  :  MainMngWarehouseCd
        /// <summary>主管元倉庫コードプロパティ</summary>
        /// <value>委託の場合に在庫補充を行う元の倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主管元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainMngWarehouseCd
        {
            get { return _mainMngWarehouseCd; }
            set { _mainMngWarehouseCd = value; }
        }

        /// public propaty name  :  MainMngWarehouseName
        /// <summary>主管元倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主管元倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainMngWarehouseName
        {
            get { return _mainMngWarehouseName; }
            set { _mainMngWarehouseName = value; }
        }


        /// <summary>
        /// 委託在庫補充の倉庫情報取得結果ワークコンストラクタ
        /// </summary>
        /// <returns>ConsStockRepWarehouseRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepWarehouseRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConsStockRepWarehouseRetWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>ConsStockRepWarehouseRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ConsStockRepWarehouseRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ConsStockRepWarehouseRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepWarehouseRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConsStockRepWarehouseRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConsStockRepWarehouseRetWork || graph is ArrayList || graph is ConsStockRepWarehouseRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ConsStockRepWarehouseRetWork).FullName));

            if (graph != null && graph is ConsStockRepWarehouseRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConsStockRepWarehouseRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConsStockRepWarehouseRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConsStockRepWarehouseRetWork[])graph).Length;
            }
            else if (graph is ConsStockRepWarehouseRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //委託倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //ConsignWarehouseCode
            //委託倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //ConsignWarehouseName
            //主管元倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //MainMngWarehouseCd
            //主管元倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //MainMngWarehouseName


            serInfo.Serialize(writer, serInfo);
            if (graph is ConsStockRepWarehouseRetWork)
            {
                ConsStockRepWarehouseRetWork temp = (ConsStockRepWarehouseRetWork)graph;

                SetConsStockRepWarehouseRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConsStockRepWarehouseRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConsStockRepWarehouseRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConsStockRepWarehouseRetWork temp in lst)
                {
                    SetConsStockRepWarehouseRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConsStockRepWarehouseRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  ConsStockRepWarehouseRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepWarehouseRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetConsStockRepWarehouseRetWork(System.IO.BinaryWriter writer, ConsStockRepWarehouseRetWork temp)
        {
            //委託倉庫コード
            writer.Write(temp.ConsignWarehouseCode);
            //委託倉庫名称
            writer.Write(temp.ConsignWarehouseName);
            //主管元倉庫コード
            writer.Write(temp.MainMngWarehouseCd);
            //主管元倉庫名称
            writer.Write(temp.MainMngWarehouseName);

        }

        /// <summary>
        ///  ConsStockRepWarehouseRetWorkインスタンス取得
        /// </summary>
        /// <returns>ConsStockRepWarehouseRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepWarehouseRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ConsStockRepWarehouseRetWork GetConsStockRepWarehouseRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ConsStockRepWarehouseRetWork temp = new ConsStockRepWarehouseRetWork();

            //委託倉庫コード
            temp.ConsignWarehouseCode = reader.ReadString();
            //委託倉庫名称
            temp.ConsignWarehouseName = reader.ReadString();
            //主管元倉庫コード
            temp.MainMngWarehouseCd = reader.ReadString();
            //主管元倉庫名称
            temp.MainMngWarehouseName = reader.ReadString();


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
        /// <returns>ConsStockRepWarehouseRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepWarehouseRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConsStockRepWarehouseRetWork temp = GetConsStockRepWarehouseRetWork(reader, serInfo);
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
                    retValue = (ConsStockRepWarehouseRetWork[])lst.ToArray(typeof(ConsStockRepWarehouseRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
