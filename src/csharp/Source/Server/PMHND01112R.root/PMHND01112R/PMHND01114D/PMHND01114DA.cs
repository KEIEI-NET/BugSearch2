//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）_登録ワーク
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）_登録ワークです
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
    /// public class name:   InspectDataAddWork
    /// <summary>
    ///                      ハンディターミナル在庫仕入（入庫更新）_登録ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ハンディターミナル在庫仕入（入庫更新）_登録ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InspectDataAddWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>コンピュータ名</summary>
        private string _machineName = "";

        /// <summary>所属拠点コード</summary>
        private string _belongSectionCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>在庫管理なしは"0"</remarks>
        private string _warehouseCode = "";

        /// <summary>検品ステータス</summary>
        /// <remarks>1:検品中 2:ピッキング済み 3:検品済み　一括検品で"2"を登録します。</remarks>
        private Int32 _inspectStatus;

        /// <summary>検品区分</summary>
        /// <remarks>1:通常 2:手動検品 </remarks>
        private Int32 _inspectCode;

        /// <summary>検品数</summary>
        private Double _inspectCnt;

        /// <summary>更新区分</summary>
        /// <remarks>" "：未処理、"1"：入荷、"2"：未入荷、"3"：修正、"9"：消込み</remarks>
        private Int32 _updateDiv;

        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>処理区分</summary>
        /// <remarks>1:在庫一括分 2:その他</remarks>
        private Int32 _opDiv;

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>入庫区分</summary>
        /// <remarks>1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO</remarks>
        private Int32 _warehousingDivCd;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
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

        /// public propaty name  :  BelongSectionCode
        /// <summary>所属拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BelongSectionCode
        {
            get { return _belongSectionCode; }
            set { _belongSectionCode = value; }
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
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>在庫管理なしは"0"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
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

        /// public propaty name  :  UpdateDiv
        /// <summary>更新区分プロパティ</summary>
        /// <value>" "：未処理、"1"：入荷、"2"：未入荷、"3"：修正、"9"：消込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDiv
        {
            get { return _updateDiv; }
            set { _updateDiv = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  OpDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>1:在庫一括分 2:その他</value>
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
        /// ハンディターミナル在庫仕入（入庫更新）_登録ワークコンストラクタ
        /// </summary>
        /// <returns>InspectDataAddWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InspectDataAddWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InspectDataAddWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>InspectDataAddWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   InspectDataAddWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class InspectDataAddWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   InspectDataAddWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  InspectDataAddWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is InspectDataAddWork || graph is ArrayList || graph is InspectDataAddWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(InspectDataAddWork).FullName));

            if (graph != null && graph is InspectDataAddWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InspectDataAddWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is InspectDataAddWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((InspectDataAddWork[])graph).Length;
            }
            else if (graph is InspectDataAddWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //コンピュータ名
            serInfo.MemberInfo.Add(typeof(string)); //MachineName
            //所属拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //検品ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //検品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //検品数
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt
            //更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDiv
            //仕入明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpDiv
            //UOE発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //入庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehousingDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is InspectDataAddWork)
            {
                InspectDataAddWork temp = (InspectDataAddWork)graph;

                SetInspectDataAddWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is InspectDataAddWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((InspectDataAddWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (InspectDataAddWork temp in lst)
                {
                    SetInspectDataAddWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// InspectDataAddWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  InspectDataAddWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   InspectDataAddWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetInspectDataAddWork(System.IO.BinaryWriter writer, InspectDataAddWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //コンピュータ名
            writer.Write(temp.MachineName);
            //所属拠点コード
            writer.Write(temp.BelongSectionCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //検品ステータス
            writer.Write(temp.InspectStatus);
            //検品区分
            writer.Write(temp.InspectCode);
            //検品数
            writer.Write(temp.InspectCnt);
            //更新区分
            writer.Write(temp.UpdateDiv);
            //仕入明細通番
            writer.Write(temp.StockSlipDtlNum);
            //処理区分
            writer.Write(temp.OpDiv);
            //UOE発注先コード
            writer.Write(temp.UOESupplierCd);
            //入庫区分
            writer.Write(temp.WarehousingDivCd);

        }

        /// <summary>
        ///  InspectDataAddWorkインスタンス取得
        /// </summary>
        /// <returns>InspectDataAddWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InspectDataAddWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private InspectDataAddWork GetInspectDataAddWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            InspectDataAddWork temp = new InspectDataAddWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //コンピュータ名
            temp.MachineName = reader.ReadString();
            //所属拠点コード
            temp.BelongSectionCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //検品ステータス
            temp.InspectStatus = reader.ReadInt32();
            //検品区分
            temp.InspectCode = reader.ReadInt32();
            //検品数
            temp.InspectCnt = reader.ReadDouble();
            //更新区分
            temp.UpdateDiv = reader.ReadInt32();
            //仕入明細通番
            temp.StockSlipDtlNum = reader.ReadInt64();
            //処理区分
            temp.OpDiv = reader.ReadInt32();
            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
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
        /// <returns>InspectDataAddWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InspectDataAddWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                InspectDataAddWork temp = GetInspectDataAddWork(reader, serInfo);
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
                    retValue = (InspectDataAddWork[])lst.ToArray(typeof(InspectDataAddWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
