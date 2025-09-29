//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充の検品情報保存条件ワーク
// プログラム概要   : ハンディターミナル委託在庫補充の検品情報保存条件ワークです
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
    /// public class name:   ConsStockRepInspectDataParamWork
    /// <summary>
    ///                      委託在庫補充の検品情報保存条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充の検品情報保存条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepInspectDataParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>受払元伝票区分</summary>
        /// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:貸出,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>委託先在庫調整伝票番号</summary>
        /// <remarks>「受払元伝票」の伝票番号を格納</remarks>
        private string _acPaySlipNum = "";

        /// <summary>委託先在庫調整行番号</summary>
        /// <remarks>「受払元伝票」の伝票行番号を格納</remarks>
        private Int32 _acPaySlipRowNo;

        /// <summary>受払元取引区分</summary>
        /// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</remarks>
        private Int32 _acPayTransCd;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>委託先倉庫コード</summary>
        /// <remarks>在庫管理なしは"0"</remarks>
        private string _warehouseCode = "";

        /// <summary>検品日時</summary>
        private Int64 _inspectDateTime;

        /// <summary>検品ステータス</summary>
        /// <remarks>1:検品中 2:ピッキング済み 3:検品済み　一括検品で"2"を登録します。</remarks>
        private Int32 _inspectStatus;

        /// <summary>検品区分</summary>
        /// <remarks>1:通常 2:手動検品 </remarks>
        private Int32 _inspectCode;

        /// <summary>検品数</summary>
        private Double _inspectCnt;

        /// <summary>ハンディターミナル区分</summary>
        /// <remarks>1:ハンディターミナル 9:その他</remarks>
        private Int32 _handTerminalCode;

        /// <summary>コンピュータ名</summary>
        private string _machineName = "";

        /// <summary>従業員コード</summary>
        /// <remarks>検品従業員</remarks>
        private string _employeeCode = "";

        /// <summary>処理区分</summary>
        private Int32 _opDiv;


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

        /// public propaty name  :  AcPaySlipCd
        /// <summary>受払元伝票区分プロパティ</summary>
        /// <value>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:貸出,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPaySlipNum
        /// <summary>委託先在庫調整伝票番号プロパティ</summary>
        /// <value>「受払元伝票」の伝票番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託先在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcPaySlipNum
        {
            get { return _acPaySlipNum; }
            set { _acPaySlipNum = value; }
        }

        /// public propaty name  :  AcPaySlipRowNo
        /// <summary>委託先在庫調整行番号プロパティ</summary>
        /// <value>「受払元伝票」の伝票行番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託先在庫調整行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPaySlipRowNo
        {
            get { return _acPaySlipRowNo; }
            set { _acPaySlipRowNo = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>受払元取引区分プロパティ</summary>
        /// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元取引区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
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

        /// public propaty name  :  WarehouseCode
        /// <summary>委託先倉庫コードプロパティ</summary>
        /// <value>在庫管理なしは"0"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  InspectDateTime
        /// <summary>検品日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InspectDateTime
        {
            get { return _inspectDateTime; }
            set { _inspectDateTime = value; }
        }

        /// public propaty name  :  InspectStatus
        /// <summary>検品ステータスプロパティ</summary>
        /// <value>1:検品中 2:ピッキング済み 3:検品済み　一括検品で"2"を登録します。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InspectStatus
        {
            get { return _inspectStatus; }
            set { _inspectStatus = value; }
        }

        /// public propaty name  :  InspectCode
        /// <summary>検品区分プロパティ</summary>
        /// <value>1:通常 2:手動検品 </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InspectCode
        {
            get { return _inspectCode; }
            set { _inspectCode = value; }
        }

        /// public propaty name  :  InspectCnt
        /// <summary>検品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double InspectCnt
        {
            get { return _inspectCnt; }
            set { _inspectCnt = value; }
        }

        /// public propaty name  :  HandTerminalCode
        /// <summary>ハンディターミナル区分プロパティ</summary>
        /// <value>1:ハンディターミナル 9:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンディターミナル区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandTerminalCode
        {
            get { return _handTerminalCode; }
            set { _handTerminalCode = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>コンピュータ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンピュータ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>検品従業員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  OpDiv
        /// <summary>処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpDiv
        {
            get { return _opDiv; }
            set { _opDiv = value; }
        }


        /// <summary>
        /// 委託在庫補充の検品情報保存条件ワークコンストラクタ
        /// </summary>
        /// <returns>ConsStockRepInspectDataParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectDataParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ConsStockRepInspectDataParamWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ConsStockRepInspectDataParamWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ConsStockRepInspectDataParamWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ConsStockRepInspectDataParamWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectDataParamWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConsStockRepInspectDataParamWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConsStockRepInspectDataParamWork || graph is ArrayList || graph is ConsStockRepInspectDataParamWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ConsStockRepInspectDataParamWork).FullName));

            if (graph != null && graph is ConsStockRepInspectDataParamWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectDataParamWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConsStockRepInspectDataParamWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConsStockRepInspectDataParamWork[])graph).Length;
            }
            else if (graph is ConsStockRepInspectDataParamWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //受払元伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //委託先在庫調整伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //AcPaySlipNum
            //委託先在庫調整行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipRowNo
            //受払元取引区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //委託先倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //検品日時
            serInfo.MemberInfo.Add(typeof(Int64)); //InspectDateTime
            //検品ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //検品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //検品数
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt
            //ハンディターミナル区分
            serInfo.MemberInfo.Add(typeof(Int32)); //HandTerminalCode
            //コンピュータ名
            serInfo.MemberInfo.Add(typeof(string)); //MachineName
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is ConsStockRepInspectDataParamWork)
            {
                ConsStockRepInspectDataParamWork temp = (ConsStockRepInspectDataParamWork)graph;

                SetConsStockRepInspectDataParamWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConsStockRepInspectDataParamWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConsStockRepInspectDataParamWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConsStockRepInspectDataParamWork temp in lst)
                {
                    SetConsStockRepInspectDataParamWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConsStockRepInspectDataParamWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  ConsStockRepInspectDataParamWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectDataParamWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetConsStockRepInspectDataParamWork(System.IO.BinaryWriter writer, ConsStockRepInspectDataParamWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //受払元伝票区分
            writer.Write(temp.AcPaySlipCd);
            //委託先在庫調整伝票番号
            writer.Write(temp.AcPaySlipNum);
            //委託先在庫調整行番号
            writer.Write(temp.AcPaySlipRowNo);
            //受払元取引区分
            writer.Write(temp.AcPayTransCd);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //委託先倉庫コード
            writer.Write(temp.WarehouseCode);
            //検品日時
            writer.Write(temp.InspectDateTime);
            //検品ステータス
            writer.Write(temp.InspectStatus);
            //検品区分
            writer.Write(temp.InspectCode);
            //検品数
            writer.Write(temp.InspectCnt);
            //ハンディターミナル区分
            writer.Write(temp.HandTerminalCode);
            //コンピュータ名
            writer.Write(temp.MachineName);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //処理区分
            writer.Write(temp.OpDiv);

        }

        /// <summary>
        ///  ConsStockRepInspectDataParamWorkインスタンス取得
        /// </summary>
        /// <returns>ConsStockRepInspectDataParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectDataParamWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ConsStockRepInspectDataParamWork GetConsStockRepInspectDataParamWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ConsStockRepInspectDataParamWork temp = new ConsStockRepInspectDataParamWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //受払元伝票区分
            temp.AcPaySlipCd = reader.ReadInt32();
            //委託先在庫調整伝票番号
            temp.AcPaySlipNum = reader.ReadString();
            //委託先在庫調整行番号
            temp.AcPaySlipRowNo = reader.ReadInt32();
            //受払元取引区分
            temp.AcPayTransCd = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //委託先倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //検品日時
            temp.InspectDateTime = reader.ReadInt64();
            //検品ステータス
            temp.InspectStatus = reader.ReadInt32();
            //検品区分
            temp.InspectCode = reader.ReadInt32();
            //検品数
            temp.InspectCnt = reader.ReadDouble();
            //ハンディターミナル区分
            temp.HandTerminalCode = reader.ReadInt32();
            //コンピュータ名
            temp.MachineName = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //処理区分
            temp.OpDiv = reader.ReadInt32();


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
        /// <returns>ConsStockRepInspectDataParamWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ConsStockRepInspectDataParamWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConsStockRepInspectDataParamWork temp = GetConsStockRepInspectDataParamWork(reader, serInfo);
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
                    retValue = (ConsStockRepInspectDataParamWork[])lst.ToArray(typeof(ConsStockRepInspectDataParamWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
