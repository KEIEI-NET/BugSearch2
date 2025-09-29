//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignGoodsDataWork
    /// <summary>
    ///                      キャンペーン管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignGoodsDataWork
    {
        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>頭品番</summary>
        private string _headerGoodsNo = "";

        /// <summary>キャンペーン対象商品設定マスタ削除件数</summary>
        private Int32 _goodsStCount;

        /// <summary>キャンペーン名称設定マスタ削除件数</summary>
        private Int32 _nameStCount;

        /// <summary>キャンペーン対象得意先設定マスタ削除件数</summary>
        private Int32 _customStCount;

        /// <summary>キャンペーン目標設定マスタ削除件数</summary>
        private Int32 _targetStCount;

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>ﾒｰｶｰ名</summary>
        private string _goodsMakerNm = "";

        /// <summary>企業ｺｰﾄﾞ</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";


        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>00は全社</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  HeaderGoodsNo
        /// <summary>頭品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   頭品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HeaderGoodsNo
        {
            get { return _headerGoodsNo; }
            set { _headerGoodsNo = value; }
        }

        /// public propaty name  :  GoodsStCount
        /// <summary>キャンペーン対象商品設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象商品設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsStCount
        {
            get { return _goodsStCount; }
            set { _goodsStCount = value; }
        }

        /// public propaty name  :  NameStCount
        /// <summary>キャンペーン名称設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NameStCount
        {
            get { return _nameStCount; }
            set { _nameStCount = value; }
        }

        /// public propaty name  :  CustomStCount
        /// <summary>キャンペーン対象得意先設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象得意先設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomStCount
        {
            get { return _customStCount; }
            set { _customStCount = value; }
        }

        /// public propaty name  :  TargetStCount
        /// <summary>キャンペーン目標設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン目標設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetStCount
        {
            get { return _targetStCount; }
            set { _targetStCount = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>ﾒｰｶｰ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業ｺｰﾄﾞプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }


        /// <summary>
        /// キャンペーン管理ワークコンストラクタ
        /// </summary>
        /// <returns>CampaignGoodsDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignGoodsDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CampaignGoodsDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CampaignGoodsDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CampaignGoodsDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignGoodsDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignGoodsDataWork || graph is ArrayList || graph is CampaignGoodsDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CampaignGoodsDataWork).FullName));

            if (graph != null && graph is CampaignGoodsDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignGoodsDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignGoodsDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignGoodsDataWork[])graph).Length;
            }
            else if (graph is CampaignGoodsDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //頭品番
            serInfo.MemberInfo.Add(typeof(string)); //HeaderGoodsNo
            //キャンペーン対象商品設定マスタ削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsStCount
            //キャンペーン名称設定マスタ削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //NameStCount
            //キャンペーン対象得意先設定マスタ削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomStCount
            //キャンペーン目標設定マスタ削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetStCount
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //ﾒｰｶｰ名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //企業ｺｰﾄﾞ
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignGoodsDataWork)
            {
                CampaignGoodsDataWork temp = (CampaignGoodsDataWork)graph;

                SetCampaignGoodsDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignGoodsDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignGoodsDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignGoodsDataWork temp in lst)
                {
                    SetCampaignGoodsDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignGoodsDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  CampaignGoodsDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCampaignGoodsDataWork(System.IO.BinaryWriter writer, CampaignGoodsDataWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //頭品番
            writer.Write(temp.HeaderGoodsNo);
            //キャンペーン対象商品設定マスタ削除件数
            writer.Write(temp.GoodsStCount);
            //キャンペーン名称設定マスタ削除件数
            writer.Write(temp.NameStCount);
            //キャンペーン対象得意先設定マスタ削除件数
            writer.Write(temp.CustomStCount);
            //キャンペーン目標設定マスタ削除件数
            writer.Write(temp.TargetStCount);
            //拠点名称
            writer.Write(temp.SectionName);
            //ﾒｰｶｰ名
            writer.Write(temp.GoodsMakerNm);
            //企業ｺｰﾄﾞ
            writer.Write(temp.EnterpriseCode);

        }

        /// <summary>
        ///  CampaignGoodsDataWorkインスタンス取得
        /// </summary>
        /// <returns>CampaignGoodsDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CampaignGoodsDataWork GetCampaignGoodsDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CampaignGoodsDataWork temp = new CampaignGoodsDataWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //頭品番
            temp.HeaderGoodsNo = reader.ReadString();
            //キャンペーン対象商品設定マスタ削除件数
            temp.GoodsStCount = reader.ReadInt32();
            //キャンペーン名称設定マスタ削除件数
            temp.NameStCount = reader.ReadInt32();
            //キャンペーン対象得意先設定マスタ削除件数
            temp.CustomStCount = reader.ReadInt32();
            //キャンペーン目標設定マスタ削除件数
            temp.TargetStCount = reader.ReadInt32();
            //拠点名称
            temp.SectionName = reader.ReadString();
            //ﾒｰｶｰ名
            temp.GoodsMakerNm = reader.ReadString();
            //企業ｺｰﾄﾞ
            temp.EnterpriseCode = reader.ReadString();


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
        /// <returns>CampaignGoodsDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignGoodsDataWork temp = GetCampaignGoodsDataWork(reader, serInfo);
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
                    retValue = (CampaignGoodsDataWork[])lst.ToArray(typeof(CampaignGoodsDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
