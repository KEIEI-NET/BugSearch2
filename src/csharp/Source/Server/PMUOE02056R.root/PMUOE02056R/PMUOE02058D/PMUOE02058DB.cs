using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecoveryDataResultWork
    /// <summary>
    ///                      復旧データ一覧表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   復旧データ一覧表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecoveryDataResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>オンライン番号</summary>
        private Int32 _onlineNo;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>受注数量</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>BO区分</summary>
        private string _boCode = "";

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>データ送信区分</summary>
        /// <remarks>0:未処理,1:処理中,2:送信エラー,3:受信エラー,4:異常終了,5:回答埋め込み,9:正常終了</remarks>
        private Int32 _dataSendCode;

        /// <summary>オンライン行番号</summary>
        private Int32 _onlineRowNo;

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
        private Int32 _systemDivCd;


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
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

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>受注数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
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

        /// public propaty name  :  DataSendCode
        /// <summary>データ送信区分プロパティ</summary>
        /// <value>0:未処理,1:処理中,2:送信エラー,3:受信エラー,4:異常終了,5:回答埋め込み,9:正常終了</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>オンライン行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>システム区分プロパティ</summary>
        /// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }


        /// <summary>
        /// 復旧データ一覧表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>RecoveryDataResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecoveryDataResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecoveryDataResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecoveryDataResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecoveryDataResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecoveryDataResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecoveryDataResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecoveryDataResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecoveryDataResultWork || graph is ArrayList || graph is RecoveryDataResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecoveryDataResultWork).FullName));

            if (graph != null && graph is RecoveryDataResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecoveryDataResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecoveryDataResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecoveryDataResultWork[])graph).Length;
            }
            else if (graph is RecoveryDataResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //UOE発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE発注先名称
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //オンライン番号
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //BO区分
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //データ送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DataSendCode
            //オンライン行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineRowNo
            //システム区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is RecoveryDataResultWork)
            {
                RecoveryDataResultWork temp = (RecoveryDataResultWork)graph;

                SetRecoveryDataResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecoveryDataResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecoveryDataResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecoveryDataResultWork temp in lst)
                {
                    SetRecoveryDataResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecoveryDataResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  RecoveryDataResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecoveryDataResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecoveryDataResultWork(System.IO.BinaryWriter writer, RecoveryDataResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //UOE発注先コード
            writer.Write(temp.UOESupplierCd);
            //UOE発注先名称
            writer.Write(temp.UOESupplierName);
            //オンライン番号
            writer.Write(temp.OnlineNo);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //BO区分
            writer.Write(temp.BoCode);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //データ送信区分
            writer.Write(temp.DataSendCode);
            //オンライン行番号
            writer.Write(temp.OnlineRowNo);
            //システム区分
            writer.Write(temp.SystemDivCd);

        }

        /// <summary>
        ///  RecoveryDataResultWorkインスタンス取得
        /// </summary>
        /// <returns>RecoveryDataResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecoveryDataResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecoveryDataResultWork GetRecoveryDataResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecoveryDataResultWork temp = new RecoveryDataResultWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE発注先名称
            temp.UOESupplierName = reader.ReadString();
            //オンライン番号
            temp.OnlineNo = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //BO区分
            temp.BoCode = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //データ送信区分
            temp.DataSendCode = reader.ReadInt32();
            //オンライン行番号
            temp.OnlineRowNo = reader.ReadInt32();
            //システム区分
            temp.SystemDivCd = reader.ReadInt32();


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
        /// <returns>RecoveryDataResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecoveryDataResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecoveryDataResultWork temp = GetRecoveryDataResultWork(reader, serInfo);
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
                    retValue = (RecoveryDataResultWork[])lst.ToArray(typeof(RecoveryDataResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
