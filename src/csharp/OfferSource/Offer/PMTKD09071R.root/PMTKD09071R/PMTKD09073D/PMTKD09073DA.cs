//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタデータパラメータ
//                  :   PMTKD09073D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ModelNameWork
    /// <summary>
    ///                      車種名称（提供）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車種名称（提供）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/03/07</br>
    /// <br>Genarated Date   :   2008/06/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/4/6  水野　剛史</br>
    /// <br>                 :   共通ファイルヘッダ変更（項目削除）</br>
    /// <br>                 :   ・企業コード</br>
    /// <br>                 :   ・GUID</br>
    /// <br>                 :   ・更新従業員コード</br>
    /// <br>                 :   ・更新アセンブリID1</br>
    /// <br>                 :   ・更新アセンブリID2</br>
    /// <br>Update Note      :   2008/03/26  鹿野 幸生</br>
    /// <br>                 :   提供用ヘッダ部変更、及びこれに伴う</br>
    /// <br>                 :   IDX項目番号の変更</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ModelNameWork : IFileHeaderOffer2
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>車種コード（ユニーク）</summary>
        /// <remarks>メーカーコード3桁+車種コード3桁+車種サブコード3桁</remarks>
        private Int32 _modelUniqueCode;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ユーザー登録</remarks>
        private Int32 _modelSubCode = -1;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>車種呼び名名称</summary>
        /// <remarks>呼び名（発音で管理）</remarks>
        private string _modelAliasName = "";


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  ModelUniqueCode
        /// <summary>車種コード（ユニーク）プロパティ</summary>
        /// <value>メーカーコード3桁+車種コード3桁+車種サブコード3桁</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（ユニーク）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelUniqueCode
        {
            get { return _modelUniqueCode; }
            set { _modelUniqueCode = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  ModelAliasName
        /// <summary>車種呼び名名称プロパティ</summary>
        /// <value>呼び名（発音で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種呼び名名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelAliasName
        {
            get { return _modelAliasName; }
            set { _modelAliasName = value; }
        }


        /// <summary>
        /// 車種名称（提供）ワークコンストラクタ
        /// </summary>
        /// <returns>ModelNameWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ModelNameWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ModelNameWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ModelNameWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ModelNameWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ModelNameWork || graph is ArrayList || graph is ModelNameWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ModelNameWork).FullName));

            if (graph != null && graph is ModelNameWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ModelNameWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ModelNameWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ModelNameWork[])graph).Length;
            }
            else if (graph is ModelNameWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //車種コード（ユニーク）
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelUniqueCode
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種全角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //車種呼び名名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelAliasName


            serInfo.Serialize(writer, serInfo);
            if (graph is ModelNameWork)
            {
                ModelNameWork temp = (ModelNameWork)graph;

                SetModelNameWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ModelNameWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ModelNameWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ModelNameWork temp in lst)
                {
                    SetModelNameWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ModelNameWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  ModelNameWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetModelNameWork(System.IO.BinaryWriter writer, ModelNameWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //車種コード（ユニーク）
            writer.Write(temp.ModelUniqueCode);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種全角名称
            writer.Write(temp.ModelFullName);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
            //車種呼び名名称
            writer.Write(temp.ModelAliasName);

        }

        /// <summary>
        ///  ModelNameWorkインスタンス取得
        /// </summary>
        /// <returns>ModelNameWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ModelNameWork GetModelNameWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ModelNameWork temp = new ModelNameWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //車種コード（ユニーク）
            temp.ModelUniqueCode = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
            //車種呼び名名称
            temp.ModelAliasName = reader.ReadString();


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
        /// <returns>ModelNameWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ModelNameWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ModelNameWork temp = GetModelNameWork(reader, serInfo);
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
                    retValue = (ModelNameWork[])lst.ToArray(typeof(ModelNameWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
