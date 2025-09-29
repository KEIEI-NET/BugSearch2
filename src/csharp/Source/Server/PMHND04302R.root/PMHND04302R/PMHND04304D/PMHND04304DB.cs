//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル発注先ガイド情報取得ワーク
// プログラム概要   : ハンディターミナル発注先ガイド情報取得(通常)ワークです
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
    /// public class name:   SupplierGuideResultWork
    /// <summary>
    ///                      ハンディターミナル発注先ガイド検索結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル発注先ガイド検索結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SupplierGuideResultWork
    {
        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";


        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }


        /// <summary>
        /// 発注先ガイド検索結果ワークコンストラクタ
        /// </summary>
        /// <returns>SupplierGuideResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierGuideResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierGuideResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SupplierGuideResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SupplierGuideResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SupplierGuideResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierGuideResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SupplierGuideResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SupplierGuideResultWork || graph is ArrayList || graph is SupplierGuideResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SupplierGuideResultWork).FullName));

            if (graph != null && graph is SupplierGuideResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SupplierGuideResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SupplierGuideResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SupplierGuideResultWork[])graph).Length;
            }
            else if (graph is SupplierGuideResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //UOE発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE発注先名称
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName


            serInfo.Serialize(writer, serInfo);
            if (graph is SupplierGuideResultWork)
            {
                SupplierGuideResultWork temp = (SupplierGuideResultWork)graph;

                SetSupplierGuideResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SupplierGuideResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SupplierGuideResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SupplierGuideResultWork temp in lst)
                {
                    SetSupplierGuideResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SupplierGuideResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 2;

        /// <summary>
        ///  SupplierGuideResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierGuideResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSupplierGuideResultWork(System.IO.BinaryWriter writer, SupplierGuideResultWork temp)
        {
            //UOE発注先コード
            writer.Write(temp.UOESupplierCd);
            //UOE発注先名称
            writer.Write(temp.UOESupplierName);

        }

        /// <summary>
        ///  SupplierGuideResultWorkインスタンス取得
        /// </summary>
        /// <returns>SupplierGuideResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierGuideResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SupplierGuideResultWork GetSupplierGuideResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SupplierGuideResultWork temp = new SupplierGuideResultWork();

            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE発注先名称
            temp.UOESupplierName = reader.ReadString();


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
        /// <returns>SupplierGuideResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierGuideResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SupplierGuideResultWork temp = GetSupplierGuideResultWork(reader, serInfo);
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
                    retValue = (SupplierGuideResultWork[])lst.ToArray(typeof(SupplierGuideResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
