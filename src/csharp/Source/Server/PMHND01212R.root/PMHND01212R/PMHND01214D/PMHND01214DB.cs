//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫移動_検品対象結果ワーク
// プログラム概要   : ハンディターミナル在庫移動_検品対象結果ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   HandyStockMoveWork
	/// <summary>
    ///                      ハンディターミナル在庫移動_検品対象結果ワーククラス（ハンディターミナル）ワーク
	/// </summary>
	/// <remarks>
    /// <br>note             :   ハンディターミナル在庫移動_検品対象結果ワーククラス（ハンディターミナル）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2017/08/02</br>
	/// <br>Genarated Date   :   2017/08/02  (CSharp File Generated Date)</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class HandyStockMoveWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>在庫移動伝票番号</summary>
		private Int32 _stockMoveSlipNo;

		/// <summary>在庫移動行番号</summary>
		private Int32 _stockMoveRowNo;

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称カナ</summary>
		private string _goodsNameKana = "";

		/// <summary>移動数</summary>
		private Double _moveCount;

		/// <summary>移動元倉庫コード</summary>
		private string _bfEnterWarehCode = "";

		/// <summary>移動元倉庫名称</summary>
		private string _bfEnterWarehName = "";

		/// <summary>移動先倉庫コード</summary>
		private string _afEnterWarehCode = "";

		/// <summary>移動先倉庫名称</summary>
		private string _afEnterWarehName = "";

		/// <summary>移動元棚番</summary>
		private string _bfShelfNo = "";

		/// <summary>移動先棚番</summary>
		private string _afShelfNo = "";

        /// <summary>移動状態</summary>
        private Int32 _moveStatus;

		/// <summary>商品バーコード</summary>
		private string _goodsBarCode = "";

		/// <summary>検品ステータス</summary>
		/// <remarks>1:検品中 2:ピッキング済み 3:検品済み　一括検品で"2"を登録します。</remarks>
		private Int32 _inspectStatus;

		/// <summary>検品区分</summary>
		/// <remarks>1:通常 2:手動検品 </remarks>
		private Int32 _inspectCode;

		/// <summary>検品数</summary>
		private Double _inspectCnt;

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  StockMoveSlipNo
		/// <summary>在庫移動伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫移動伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockMoveSlipNo
		{
			get{return _stockMoveSlipNo;}
			set{_stockMoveSlipNo = value;}
		}

		/// public propaty name  :  StockMoveRowNo
		/// <summary>在庫移動行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫移動行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockMoveRowNo
		{
			get{return _stockMoveRowNo;}
			set{_stockMoveRowNo = value;}
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
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
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
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsNameKana
		/// <summary>商品名称カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  MoveCount
		/// <summary>移動数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MoveCount
		{
			get{return _moveCount;}
			set{_moveCount = value;}
		}

		/// public propaty name  :  BfEnterWarehCode
		/// <summary>移動元倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfEnterWarehCode
		{
			get{return _bfEnterWarehCode;}
			set{_bfEnterWarehCode = value;}
		}

		/// public propaty name  :  BfEnterWarehName
		/// <summary>移動元倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfEnterWarehName
		{
			get{return _bfEnterWarehName;}
			set{_bfEnterWarehName = value;}
		}

		/// public propaty name  :  AfEnterWarehCode
		/// <summary>移動先倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfEnterWarehCode
		{
			get{return _afEnterWarehCode;}
			set{_afEnterWarehCode = value;}
		}

		/// public propaty name  :  AfEnterWarehName
		/// <summary>移動先倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfEnterWarehName
		{
			get{return _afEnterWarehName;}
			set{_afEnterWarehName = value;}
		}

		/// public propaty name  :  BfShelfNo
		/// <summary>移動元棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfShelfNo
		{
			get{return _bfShelfNo;}
			set{_bfShelfNo = value;}
		}

		/// public propaty name  :  AfShelfNo
		/// <summary>移動先棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfShelfNo
		{
			get{return _afShelfNo;}
			set{_afShelfNo = value;}
		}

        /// public propaty name  :  MoveStatus
        /// <summary>移動状態プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

		/// public propaty name  :  GoodsBarCode
		/// <summary>商品バーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品バーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsBarCode
		{
			get{return _goodsBarCode;}
			set{_goodsBarCode = value;}
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
			get{return _inspectStatus;}
			set{_inspectStatus = value;}
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
			get{return _inspectCode;}
			set{_inspectCode = value;}
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
			get{return _inspectCnt;}
			set{_inspectCnt = value;}
		}

		/// <summary>
        /// ハンディターミナル在庫移動_検品対象結果ワークコンストラクタ
		/// </summary>
        /// <returns>HandyStockMoveWorkクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   HandyStockMoveWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public HandyStockMoveWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリイアライザです。
    /// </summary>
    /// <returns>HandyStockMoveWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyStockMoveWorkクラスのカスタムシリイアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyStockMoveWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockMoveWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyStockMoveWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyStockMoveWork || graph is ArrayList || graph is HandyStockMoveWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyStockMoveWork).FullName));

            if (graph != null && graph is HandyStockMoveWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyStockMoveWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyStockMoveWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyStockMoveWork[])graph).Length;
            }
            else if (graph is HandyStockMoveWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //在庫移動伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //在庫移動行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveRowNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //移動数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCount
            //移動元倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //移動元倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //移動先倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //移動先倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //移動元棚番
            serInfo.MemberInfo.Add(typeof(string)); //BfShelfNo
            //移動先棚番
            serInfo.MemberInfo.Add(typeof(string)); //AfShelfNo
            //移動状態
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStatus
            //商品バーコード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsBarCode
            //検品ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //検品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //検品数
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyStockMoveWork)
            {
                HandyStockMoveWork temp = (HandyStockMoveWork)graph;

                SetHandyStockMoveWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyStockMoveWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyStockMoveWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyStockMoveWork temp in lst)
                {
                    SetHandyStockMoveWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyStockMoveWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  HandyStockMoveWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockMoveWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyStockMoveWork(System.IO.BinaryWriter writer, HandyStockMoveWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //在庫移動伝票番号
            writer.Write(temp.StockMoveSlipNo);
            //在庫移動行番号
            writer.Write(temp.StockMoveRowNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //移動数
            writer.Write(temp.MoveCount);
            //移動元倉庫コード
            writer.Write(temp.BfEnterWarehCode);
            //移動元倉庫名称
            writer.Write(temp.BfEnterWarehName);
            //移動先倉庫コード
            writer.Write(temp.AfEnterWarehCode);
            //移動先倉庫名称
            writer.Write(temp.AfEnterWarehName);
            //移動元棚番
            writer.Write(temp.BfShelfNo);
            //移動先棚番
            writer.Write(temp.AfShelfNo);
            //移動状態
            writer.Write(temp.MoveStatus);
            //商品バーコード
            writer.Write(temp.GoodsBarCode);
            //検品ステータス
            writer.Write(temp.InspectStatus);
            //検品区分
            writer.Write(temp.InspectCode);
            //検品数
            writer.Write(temp.InspectCnt);

        }

        /// <summary>
        ///  HandyStockMoveWorkインスタンス取得
        /// </summary>
        /// <returns>HandyStockMoveWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockMoveWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyStockMoveWork GetHandyStockMoveWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyStockMoveWork temp = new HandyStockMoveWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //在庫移動伝票番号
            temp.StockMoveSlipNo = reader.ReadInt32();
            //在庫移動行番号
            temp.StockMoveRowNo = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //移動数
            temp.MoveCount = reader.ReadDouble();
            //移動元倉庫コード
            temp.BfEnterWarehCode = reader.ReadString();
            //移動元倉庫名称
            temp.BfEnterWarehName = reader.ReadString();
            //移動先倉庫コード
            temp.AfEnterWarehCode = reader.ReadString();
            //移動先倉庫名称
            temp.AfEnterWarehName = reader.ReadString();
            //移動元棚番
            temp.BfShelfNo = reader.ReadString();
            //移動先棚番
            temp.AfShelfNo = reader.ReadString();
            //移動状態
            temp.MoveStatus = reader.ReadInt32();
            //商品バーコード
            temp.GoodsBarCode = reader.ReadString();
            //検品ステータス
            temp.InspectStatus = reader.ReadInt32();
            //検品区分
            temp.InspectCode = reader.ReadInt32();
            //検品数
            temp.InspectCnt = reader.ReadDouble();

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
        ///  Ver5.10.1.0用のカスタムシリイアライザです。
        /// </summary>
        /// <returns>HandyStockMoveWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyStockMoveWorkクラスのカスタムシリイアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyStockMoveWork temp = GetHandyStockMoveWork(reader, serInfo);
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
                    retValue = (HandyStockMoveWork[])lst.ToArray(typeof(HandyStockMoveWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
