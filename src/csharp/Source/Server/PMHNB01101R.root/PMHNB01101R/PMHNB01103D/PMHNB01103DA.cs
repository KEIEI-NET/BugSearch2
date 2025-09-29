//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   売上月次集計データ更新パラメータワーク
//                  :   PMHNB01103D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田　誠
// Date             :   2008.05.19
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
    /// public class name:   MTtlSalesUpdParaWork
    /// <summary>
    /// 売上月次集計データ更新パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上月次集計データ更新パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlSalesUpdParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上年月(開始)</summary>
        /// <remarks>YYYYMM形式 0:未設定</remarks>
        private Int32 _addUpYearMonthSt;

        /// <summary>計上年月(終了)</summary>
        /// <remarks>YYYYMM形式 0:未設定</remarks>
        private Int32 _addUpYearMonthEd;

        /// <summary>伝票登録区分</summary>
        /// <remarks>0:削除 1:登録</remarks>
        private Int32 _slipRegDiv;

        /// <summary>売上月次集計データ処理対象フラグ</summary>
        /// <remarks>0:非対象 1:対象</remarks>
        private Int32 _mTtlSalesPrcFlg;

        /// <summary>商品別売上月次集計データ処理対象フラグ</summary>
        /// <remarks>0:非対象 1:対象</remarks>
        private Int32 _goodsMTtlSaPrcFlg;

        // ---ADD 2009/12/24 -------->>>
        /// <summary>計上拠点コード開始</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCodeSt = "";

        /// <summary>計上拠点コード終了</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCodeEd = "";
        // ---ADD 2009/12/24 --------<<<


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        // ---ADD 2009/12/24 -------->>>
        /// public propaty name  :  AddUpSecCodeSt
        /// <summary>計上拠点コード開始プロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCodeSt
        {
            get { return _addUpSecCodeSt; }
            set { _addUpSecCodeSt = value; }
        }

        /// public propaty name  :  AddUpSecCodeEd
        /// <summary>計上拠点コード終了プロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCodeEd
        {
            get { return _addUpSecCodeEd; }
            set { _addUpSecCodeEd = value; }
        }
        // ---ADD 2009/12/24 --------<<<

        /// public propaty name  :  AddUpYearMonthSt
        /// <summary>計上年月(開始)プロパティ</summary>
        /// <value>YYYYMM形式 0:未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonthSt
        {
            get { return _addUpYearMonthSt; }
            set { _addUpYearMonthSt = value; }
        }

        /// public propaty name  :  AddUpYearMonthEd
        /// <summary>計上年月(終了)プロパティ</summary>
        /// <value>YYYYMM形式 0:未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpYearMonthEd
        {
            get { return _addUpYearMonthEd; }
            set { _addUpYearMonthEd = value; }
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

        /// public propaty name  :  MTtlSalesPrcFlg
        /// <summary>売上月次集計データ処理対象フラグプロパティ</summary>
        /// <value>0:非対象 1:対象</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上月次集計データ処理対象フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MTtlSalesPrcFlg
        {
            get { return _mTtlSalesPrcFlg; }
            set { _mTtlSalesPrcFlg = value; }
        }

        /// public propaty name  :  GoodsMTtlSaPrcFlg
        /// <summary>商品別売上月次集計データ処理対象フラグプロパティ</summary>
        /// <value>0:非対象 1:対象</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品別売上月次集計データ処理対象フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMTtlSaPrcFlg
        {
            get { return _goodsMTtlSaPrcFlg; }
            set { _goodsMTtlSaPrcFlg = value; }
        }


        /// <summary>
        /// 売上月次集計データ更新パラメータワークコンストラクタ
        /// </summary>
        /// <returns>MTtlSalesUpdParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesUpdParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MTtlSalesUpdParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MTtlSalesUpdParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MTtlSalesUpdParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MTtlSalesUpdParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesUpdParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlSalesUpdParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlSalesUpdParaWork || graph is ArrayList || graph is MTtlSalesUpdParaWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MTtlSalesUpdParaWork).FullName));

            if (graph != null && graph is MTtlSalesUpdParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlSalesUpdParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlSalesUpdParaWork[])graph).Length;
            }
            else if (graph is MTtlSalesUpdParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode

            // ---ADD 2009/12/24 -------->>>
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCodeSt
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCodeEd
            // ---ADD 2009/12/24 --------<<<

            //計上年月(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonthSt
            //計上年月(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonthEd
            //伝票登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipRegDiv
            //売上月次集計データ処理対象フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //MTtlSalesPrcFlg
            //商品別売上月次集計データ処理対象フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMTtlSaPrcFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlSalesUpdParaWork)
            {
                MTtlSalesUpdParaWork temp = (MTtlSalesUpdParaWork)graph;

                SetMTtlSalesUpdParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlSalesUpdParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlSalesUpdParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlSalesUpdParaWork temp in lst)
                {
                    SetMTtlSalesUpdParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlSalesUpdParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 7;

        /// <summary>
        ///  MTtlSalesUpdParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesUpdParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMTtlSalesUpdParaWork(System.IO.BinaryWriter writer, MTtlSalesUpdParaWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);

            // ---ADD 2009/12/24 -------->>>
            //計上拠点コード
            writer.Write(temp.AddUpSecCodeSt);
            //計上拠点コード
            writer.Write(temp.AddUpSecCodeEd);
            // ---ADD 2009/12/24 --------<<<

            //計上年月(開始)
            writer.Write(temp.AddUpYearMonthSt);
            //計上年月(終了)
            writer.Write(temp.AddUpYearMonthEd);
            //伝票登録区分
            writer.Write(temp.SlipRegDiv);
            //売上月次集計データ処理対象フラグ
            writer.Write(temp.MTtlSalesPrcFlg);
            //商品別売上月次集計データ処理対象フラグ
            writer.Write(temp.GoodsMTtlSaPrcFlg);

        }

        /// <summary>
        ///  MTtlSalesUpdParaWorkインスタンス取得
        /// </summary>
        /// <returns>MTtlSalesUpdParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesUpdParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MTtlSalesUpdParaWork GetMTtlSalesUpdParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MTtlSalesUpdParaWork temp = new MTtlSalesUpdParaWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();

            // ---ADD 2009/12/24 -------->>>
            //計上拠点コード
            temp.AddUpSecCodeSt = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCodeEd = reader.ReadString();
            // ---ADD 2009/12/24 --------<<<

            //計上年月(開始)
            temp.AddUpYearMonthSt = reader.ReadInt32();
            //計上年月(終了)
            temp.AddUpYearMonthEd = reader.ReadInt32();
            //伝票登録区分
            temp.SlipRegDiv = reader.ReadInt32();
            //売上月次集計データ処理対象フラグ
            temp.MTtlSalesPrcFlg = reader.ReadInt32();
            //商品別売上月次集計データ処理対象フラグ
            temp.GoodsMTtlSaPrcFlg = reader.ReadInt32();


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
        /// <returns>MTtlSalesUpdParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesUpdParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlSalesUpdParaWork temp = GetMTtlSalesUpdParaWork(reader, serInfo);
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
                    retValue = (MTtlSalesUpdParaWork[])lst.ToArray(typeof(MTtlSalesUpdParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
