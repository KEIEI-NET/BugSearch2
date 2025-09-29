//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入月次集計データ更新パラメータワーク
//                  :   PMKOU01113D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.12.12
//----------------------------------------------------------------------
// Update Note      :　 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④
//                             ・一括リアル更新の新規を対応
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlStockUpdParaWork
    /// <summary>
    ///                      仕入月次集計データ更新パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入月次集計データ更新パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlStockUpdParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>仕入拠点コード</summary>
        private string _stockSectionCd = "";

        // ---ADD 2009/12/24 -------->>>
        /// <summary>計上拠点コード開始</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _stockSectionCdSt = "";

        /// <summary>計上拠点コード終了</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _stockSectionCdEd = "";
        // ---ADD 2009/12/24 --------<<<

        /// <summary>仕入年月(開始)</summary>
        /// <remarks>YYYYMM 0:未設定</remarks>
        private Int32 _stockDateYmSt;

        /// <summary>仕入年月(終了)</summary>
        /// <remarks>YYYYMM 0:未設定</remarks>
        private Int32 _stockDateYmEd;

        /// <summary>伝票登録区分</summary>
        /// <remarks>0:削除 1:登録 2:再集計</remarks>
        private Int32 _slipRegDiv;


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

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        // ---ADD 2009/12/24 -------->>>
        /// public propaty name  :  StockSectionCdSt
        /// <summary>仕入拠点コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCdSt
        {
            get { return _stockSectionCdSt; }
            set { _stockSectionCdSt = value; }
        }

        /// public propaty name  :  StockSectionCdEd
        /// <summary>仕入拠点コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCdEd
        {
            get { return _stockSectionCdEd; }
            set { _stockSectionCdEd = value; }
        }
        // ---ADD 2009/12/24 --------<<<

        /// public propaty name  :  StockDateYmSt
        /// <summary>仕入年月(開始)プロパティ</summary>
        /// <value>YYYYMM 0:未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateYmSt
        {
            get { return _stockDateYmSt; }
            set { _stockDateYmSt = value; }
        }

        /// public propaty name  :  StockDateYmEd
        /// <summary>仕入年月(終了)プロパティ</summary>
        /// <value>YYYYMM 0:未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateYmEd
        {
            get { return _stockDateYmEd; }
            set { _stockDateYmEd = value; }
        }

        /// public propaty name  :  SlipRegDiv
        /// <summary>伝票登録区分プロパティ</summary>
        /// <value>0:削除 1:登録 2:再集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipRegDiv
        {
            get { return _slipRegDiv; }
            set { _slipRegDiv = value; }
        }


        /// <summary>
        /// 仕入月次集計データ更新パラメータワークコンストラクタ
        /// </summary>
        /// <returns>MTtlStockUpdParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlStockUpdParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MTtlStockUpdParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MTtlStockUpdParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MTtlStockUpdParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MTtlStockUpdParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlStockUpdParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlStockUpdParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlStockUpdParaWork || graph is ArrayList || graph is MTtlStockUpdParaWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MTtlStockUpdParaWork).FullName));

            if (graph != null && graph is MTtlStockUpdParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlStockUpdParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlStockUpdParaWork[])graph).Length;
            }
            else if (graph is MTtlStockUpdParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd

            // ---ADD 2009/12/24 -------->>>
            //仕入拠点コード(開始)
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCdSt
            //仕入拠点コード(終了)
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCdEd
            // ---ADD 2009/12/24 --------<<<

            //仕入年月(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateYmSt
            //仕入年月(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateYmEd
            //伝票登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipRegDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlStockUpdParaWork)
            {
                MTtlStockUpdParaWork temp = (MTtlStockUpdParaWork)graph;

                SetMTtlStockUpdParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlStockUpdParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlStockUpdParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlStockUpdParaWork temp in lst)
                {
                    SetMTtlStockUpdParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlStockUpdParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  MTtlStockUpdParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlStockUpdParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMTtlStockUpdParaWork(System.IO.BinaryWriter writer, MTtlStockUpdParaWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);

            // ---ADD 2009/12/24 -------->>>
            //仕入拠点コード(開始)
            writer.Write(temp.StockSectionCdSt);
            //仕入拠点コード(終了)
            writer.Write(temp.StockSectionCdEd);
            // ---ADD 2009/12/24 --------<<<

            //仕入年月(開始)
            writer.Write(temp.StockDateYmSt);
            //仕入年月(終了)
            writer.Write(temp.StockDateYmEd);
            //伝票登録区分
            writer.Write(temp.SlipRegDiv);

        }

        /// <summary>
        ///  MTtlStockUpdParaWorkインスタンス取得
        /// </summary>
        /// <returns>MTtlStockUpdParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlStockUpdParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MTtlStockUpdParaWork GetMTtlStockUpdParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MTtlStockUpdParaWork temp = new MTtlStockUpdParaWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();

            // ---ADD 2009/12/24 -------->>>
            //仕入拠点コード(開始)
            temp.StockSectionCdSt = reader.ReadString();
            //仕入拠点コード(終了)
            temp.StockSectionCdEd = reader.ReadString();
            // ---ADD 2009/12/24 --------<<<

            //仕入年月(開始)
            temp.StockDateYmSt = reader.ReadInt32();
            //仕入年月(終了)
            temp.StockDateYmEd = reader.ReadInt32();
            //伝票登録区分
            temp.SlipRegDiv = reader.ReadInt32();


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
        /// <returns>MTtlStockUpdParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlStockUpdParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlStockUpdParaWork temp = GetMTtlStockUpdParaWork(reader, serInfo);
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
                    retValue = (MTtlStockUpdParaWork[])lst.ToArray(typeof(MTtlStockUpdParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
