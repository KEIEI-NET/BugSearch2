using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// 売上・仕入制御オプションの制御起点に設定する値
    /// </summary>
    public enum IOWriteCtrlOptCtrlStartingPoint
    {
        /// <summary>0:売上</summary>
        Sales = 0,
        /// <summary>1:仕入</summary>
        Purchase = 1,
        /// <summary>2:仕入売上同時</summary>
        PurchaseAndSales = 2,
        /// <summary>9:未設定(初期値)</summary>
        None = 9
    }

    /// public class name:   IOWriteCtrlOptWork
    /// <summary>
    ///                      売上・仕入制御オプションワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上・仕入制御オプションワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteCtrlOptWork
    {
        /// <summary>制御起点</summary>
        /// <remarks>0:売上,1:仕入,2:仕入売上同時計上,9:未設定</remarks>
        private Int32 _ctrlStartingPoint;

        /// <summary>見積データ計上残区分</summary>
        /// <remarks>0:残す　1:残さない</remarks>
        private Int32 _estimateAddUpRemDiv;

        /// <summary>受注データ計上残区分</summary>
        /// <remarks>0:残す　1:残さない</remarks>
        private Int32 _acpOdrrAddUpRemDiv;

        /// <summary>出荷データ計上残区分</summary>
        /// <remarks>0:残す　1:残さない</remarks>
        private Int32 _shipmAddUpRemDiv;

        /// <summary>返品時在庫登録区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _retGoodsStockEtyDiv;

        /// <summary>仕入伝票削除区分</summary>
        /// <remarks>0:しない　1:確認　2:する　(する:売仕入同時計上の仕入伝票を売伝削除時に同時削除)</remarks>
        private Int32 _supplierSlipDelDiv;

        /// <summary>残数管理区分</summary>
        /// <remarks>0:する　1:しない 　　※伝票削除時に残に戻すかどうか </remarks>
        private Int32 _remainCntMngDiv;

        /// <summary>企業コード</summary>
        /// <remarks>排他制御のキーとして用いる企業コード</remarks>
        private string _enterpriseCode = "";

        /// <summary>車両管理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _carMngDivCd;


        /// public propaty name  :  CtrlStartingPoint
        /// <summary>制御起点プロパティ</summary>
        /// <value>0:売上,1:仕入,2:仕入売上同時計上,9:未設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   制御起点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CtrlStartingPoint
        {
            get { return _ctrlStartingPoint; }
            set { _ctrlStartingPoint = value; }
        }

        /// public propaty name  :  EstimateAddUpRemDiv
        /// <summary>見積データ計上残区分プロパティ</summary>
        /// <value>0:残す　1:残さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ計上残区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateAddUpRemDiv
        {
            get { return _estimateAddUpRemDiv; }
            set { _estimateAddUpRemDiv = value; }
        }

        /// public propaty name  :  AcpOdrrAddUpRemDiv
        /// <summary>受注データ計上残区分プロパティ</summary>
        /// <value>0:残す　1:残さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注データ計上残区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrrAddUpRemDiv
        {
            get { return _acpOdrrAddUpRemDiv; }
            set { _acpOdrrAddUpRemDiv = value; }
        }

        /// public propaty name  :  ShipmAddUpRemDiv
        /// <summary>出荷データ計上残区分プロパティ</summary>
        /// <value>0:残す　1:残さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷データ計上残区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmAddUpRemDiv
        {
            get { return _shipmAddUpRemDiv; }
            set { _shipmAddUpRemDiv = value; }
        }

        /// public propaty name  :  RetGoodsStockEtyDiv
        /// <summary>返品時在庫登録区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品時在庫登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetGoodsStockEtyDiv
        {
            get { return _retGoodsStockEtyDiv; }
            set { _retGoodsStockEtyDiv = value; }
        }

        /// public propaty name  :  SupplierSlipDelDiv
        /// <summary>仕入伝票削除区分プロパティ</summary>
        /// <value>0:しない　1:確認　2:する　(する:売仕入同時計上の仕入伝票を売伝削除時に同時削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipDelDiv
        {
            get { return _supplierSlipDelDiv; }
            set { _supplierSlipDelDiv = value; }
        }

        /// public propaty name  :  RemainCntMngDiv
        /// <summary>残数管理区分プロパティ</summary>
        /// <value>0:する　1:しない 　　※伝票削除時に残に戻すかどうか </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RemainCntMngDiv
        {
            get { return _remainCntMngDiv; }
            set { _remainCntMngDiv = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>排他制御のキーとして用いる企業コード</value>
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

        /// public propaty name  :  CarMngDivCd
        /// <summary>車両管理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }


        /// <summary>
        /// 売上・仕入制御オプションワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteCtrlOptWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteCtrlOptWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteCtrlOptWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>IOWriteCtrlOptWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   IOWriteCtrlOptWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class IOWriteCtrlOptWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteCtrlOptWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteCtrlOptWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteCtrlOptWork || graph is ArrayList || graph is IOWriteCtrlOptWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(IOWriteCtrlOptWork).FullName));

            if (graph != null && graph is IOWriteCtrlOptWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteCtrlOptWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteCtrlOptWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteCtrlOptWork[])graph).Length;
            }
            else if (graph is IOWriteCtrlOptWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //制御起点
            serInfo.MemberInfo.Add(typeof(Int32)); //CtrlStartingPoint
            //見積データ計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateAddUpRemDiv
            //受注データ計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrAddUpRemDiv
            //出荷データ計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmAddUpRemDiv
            //返品時在庫登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsStockEtyDiv
            //仕入伝票削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipDelDiv
            //残数管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntMngDiv
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //車両管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteCtrlOptWork)
            {
                IOWriteCtrlOptWork temp = (IOWriteCtrlOptWork)graph;

                SetIOWriteCtrlOptWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteCtrlOptWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteCtrlOptWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteCtrlOptWork temp in lst)
                {
                    SetIOWriteCtrlOptWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteCtrlOptWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  IOWriteCtrlOptWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteCtrlOptWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetIOWriteCtrlOptWork(System.IO.BinaryWriter writer, IOWriteCtrlOptWork temp)
        {
            //制御起点
            writer.Write(temp.CtrlStartingPoint);
            //見積データ計上残区分
            writer.Write(temp.EstimateAddUpRemDiv);
            //受注データ計上残区分
            writer.Write(temp.AcpOdrrAddUpRemDiv);
            //出荷データ計上残区分
            writer.Write(temp.ShipmAddUpRemDiv);
            //返品時在庫登録区分
            writer.Write(temp.RetGoodsStockEtyDiv);
            //仕入伝票削除区分
            writer.Write(temp.SupplierSlipDelDiv);
            //残数管理区分
            writer.Write(temp.RemainCntMngDiv);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //車両管理区分
            writer.Write(temp.CarMngDivCd);

        }

        /// <summary>
        ///  IOWriteCtrlOptWorkインスタンス取得
        /// </summary>
        /// <returns>IOWriteCtrlOptWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteCtrlOptWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private IOWriteCtrlOptWork GetIOWriteCtrlOptWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            IOWriteCtrlOptWork temp = new IOWriteCtrlOptWork();

            //制御起点
            temp.CtrlStartingPoint = reader.ReadInt32();
            //見積データ計上残区分
            temp.EstimateAddUpRemDiv = reader.ReadInt32();
            //受注データ計上残区分
            temp.AcpOdrrAddUpRemDiv = reader.ReadInt32();
            //出荷データ計上残区分
            temp.ShipmAddUpRemDiv = reader.ReadInt32();
            //返品時在庫登録区分
            temp.RetGoodsStockEtyDiv = reader.ReadInt32();
            //仕入伝票削除区分
            temp.SupplierSlipDelDiv = reader.ReadInt32();
            //残数管理区分
            temp.RemainCntMngDiv = reader.ReadInt32();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //車両管理区分
            temp.CarMngDivCd = reader.ReadInt32();


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
        /// <returns>IOWriteCtrlOptWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteCtrlOptWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteCtrlOptWork temp = GetIOWriteCtrlOptWork(reader, serInfo);
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
                    retValue = (IOWriteCtrlOptWork[])lst.ToArray(typeof(IOWriteCtrlOptWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
