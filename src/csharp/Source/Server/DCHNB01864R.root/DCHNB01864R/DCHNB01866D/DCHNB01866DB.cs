using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region [比較クラス]
    
    /// <summary>
    /// 伝票明細追加情報データワークの明細関連付けGUIDで比較します。
    /// </summary>
    public class SlipDetailAddInfoDtlRelationGuidComparer : IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            Guid xGuid = Guid.Empty;

            if (x is Guid)
            {
                xGuid = (Guid)x;
            }
            else if (x is SlipDetailAddInfoWork)
            {
                xGuid = (x as SlipDetailAddInfoWork).DtlRelationGuid;
            }

            Guid yGuid = Guid.Empty;

            if (y is Guid)
            {
                yGuid = (Guid)y;
            }
            else if (y is SlipDetailAddInfoWork)
            {
                yGuid = (y as SlipDetailAddInfoWork).DtlRelationGuid;
            }

            return xGuid.CompareTo(yGuid);
        }
    }

    /// <summary>
    /// 伝票明細追加情報データワークの伝票明細登録順位で比較します。
    /// </summary>
    public class SlipDetailAddInfoRegOrderComparer : IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            SlipDetailAddInfoWork xInfo = x as SlipDetailAddInfoWork;
            SlipDetailAddInfoWork yInfo = y as SlipDetailAddInfoWork;

            int ret = (xInfo == null ? 0 : 1) - (yInfo == null ? 0 : 1);

            if (ret == 0 && xInfo != null)
            {
                ret = xInfo.SlipDtlRegOrder.CompareTo(yInfo.SlipDtlRegOrder);
            }

            return ret;
        }
    }
    # endregion

    # region [削除]
    # if false
    /// public class name:   SlipDetailAddInfoWork
    /// <summary>
    /// 伝票明細追加情報データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   伝票明細追加情報データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/06/05</br>
    /// <br>Genarated Date   :   2008/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/02  久保田</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SlipDetailAddInfoWork
	{
		/// <summary>明細関連付けGUID</summary>
		/// <remarks>伝票明細と紐付ける為のGUID、UI側で設定</remarks>
		private Guid _dtlRelationGuid;

		/// <summary>商品登録区分</summary>
		/// <remarks>0:なし　1:あり</remarks>
		private Int32 _goodsEntryDiv;

		/// <summary>商品提供日付</summary>
		/// <remarks>YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型</remarks>
		private DateTime _goodsOfferDate;

		/// <summary>価格更新区分</summary>
		/// <remarks>0:なし　1:あり</remarks>
		private Int32 _priceUpdateDiv;

		/// <summary>価格開始日付</summary>
		/// <remarks>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</remarks>
		private DateTime _priceStartDate;

		/// <summary>価格提供日付</summary>
		/// <remarks>YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型</remarks>
		private DateTime _priceOfferDate;

		/// <summary>車両関連付けGUID</summary>
		/// <remarks>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</remarks>
		private Guid _carRelationGuid;

        /// <summary>伝票明細登録順位</summary>
        /// <remarks>伝票・明細の登録順位を設定</remarks>
        private Int32 _slipDtlRegOrder;


		/// public propaty name  :  DtlRelationGuid
		/// <summary>明細関連付けGUIDプロパティ</summary>
		/// <value>伝票明細と紐付ける為のGUID、UI側で設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細関連付けGUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid DtlRelationGuid
		{
			get{return _dtlRelationGuid;}
			set{_dtlRelationGuid = value;}
		}

		/// public propaty name  :  GoodsEntryDiv
		/// <summary>商品登録区分プロパティ</summary>
		/// <value>0:なし　1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品登録区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsEntryDiv
		{
			get{return _goodsEntryDiv;}
			set{_goodsEntryDiv = value;}
		}

		/// public propaty name  :  GoodsOfferDate
		/// <summary>商品提供日付プロパティ</summary>
		/// <value>YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime GoodsOfferDate
		{
			get{return _goodsOfferDate;}
			set{_goodsOfferDate = value;}
		}

		/// public propaty name  :  PriceUpdateDiv
		/// <summary>価格更新区分プロパティ</summary>
		/// <value>0:なし　1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格更新区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceUpdateDiv
		{
			get{return _priceUpdateDiv;}
			set{_priceUpdateDiv = value;}
		}

		/// public propaty name  :  PriceStartDate
		/// <summary>価格開始日付プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PriceStartDate
		{
			get{return _priceStartDate;}
			set{_priceStartDate = value;}
		}

		/// public propaty name  :  PriceOfferDate
		/// <summary>価格提供日付プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PriceOfferDate
		{
			get{return _priceOfferDate;}
			set{_priceOfferDate = value;}
		}

		/// public propaty name  :  CarRelationGuid
		/// <summary>車両関連付けGUIDプロパティ</summary>
		/// <value>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両関連付けGUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid CarRelationGuid
		{
			get{return _carRelationGuid;}
			set{_carRelationGuid = value;}
		}

        /// public propaty name  :  SlipDtlRegOrder
        /// <summary>伝票明細登録順位プロパティ</summary>
        /// <value>伝票・明細の登録順位を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票明細登録順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipDtlRegOrder
        {
            get { return _slipDtlRegOrder; }
            set { _slipDtlRegOrder = value; }
        }

		/// <summary>
		/// 伝票明細追加情報データワークコンストラクタ
		/// </summary>
		/// <returns>SlipDetailAddInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SlipDetailAddInfoWork()
		{
		}
	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SlipDetailAddInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SlipDetailAddInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipDetailAddInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipDetailAddInfoWork || graph is ArrayList || graph is SlipDetailAddInfoWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SlipDetailAddInfoWork).FullName));

            if (graph != null && graph is SlipDetailAddInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipDetailAddInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipDetailAddInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipDetailAddInfoWork[])graph).Length;
            }
            else if (graph is SlipDetailAddInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //明細関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid
            //商品登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsEntryDiv
            //商品提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //GoodsOfferDate
            //価格更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceUpdateDiv
            //価格開始日付
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //価格提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceOfferDate
            //車両関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //CarRelationGuid
            //伝票明細登録順位
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDtlRegOrder

            serInfo.Serialize(writer, serInfo);
            if (graph is SlipDetailAddInfoWork)
            {
                SlipDetailAddInfoWork temp = (SlipDetailAddInfoWork)graph;

                SetSlipDetailAddInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipDetailAddInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipDetailAddInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipDetailAddInfoWork temp in lst)
                {
                    SetSlipDetailAddInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipDetailAddInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  SlipDetailAddInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSlipDetailAddInfoWork(System.IO.BinaryWriter writer, SlipDetailAddInfoWork temp)
        {
            //明細関連付けGUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
            //商品登録区分
            writer.Write(temp.GoodsEntryDiv);
            //商品提供日付
            writer.Write(temp.GoodsOfferDate.Ticks);
            //価格更新区分
            writer.Write(temp.PriceUpdateDiv);
            //価格開始日付
            writer.Write(temp.PriceStartDate.Ticks);
            //価格提供日付
            writer.Write(temp.PriceOfferDate.Ticks);
            //車両関連付けGUID
            byte[] carRelationGuidArray = temp.CarRelationGuid.ToByteArray();
            writer.Write(carRelationGuidArray.Length);
            writer.Write(temp.CarRelationGuid.ToByteArray());
            //伝票明細登録順位
            writer.Write(temp.SlipDtlRegOrder);
        }

        /// <summary>
        ///  SlipDetailAddInfoWorkインスタンス取得
        /// </summary>
        /// <returns>SlipDetailAddInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SlipDetailAddInfoWork GetSlipDetailAddInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SlipDetailAddInfoWork temp = new SlipDetailAddInfoWork();

            //明細関連付けGUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);
            //商品登録区分
            temp.GoodsEntryDiv = reader.ReadInt32();
            //商品提供日付
            temp.GoodsOfferDate = new DateTime(reader.ReadInt64());
            //価格更新区分
            temp.PriceUpdateDiv = reader.ReadInt32();
            //価格開始日付
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //価格提供日付
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());
            //車両関連付けGUID
            int lenOfCarRelationGuidArray = reader.ReadInt32();
            byte[] carRelationGuidArray = reader.ReadBytes(lenOfCarRelationGuidArray);
            temp.CarRelationGuid = new Guid(carRelationGuidArray);
            //伝票明細登録順位
            temp.SlipDtlRegOrder = reader.ReadInt32();


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
        /// <returns>SlipDetailAddInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipDetailAddInfoWork temp = GetSlipDetailAddInfoWork(reader, serInfo);
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
                    retValue = (SlipDetailAddInfoWork[])lst.ToArray(typeof(SlipDetailAddInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    # endif
    # endregion

    /// public class name:   SlipDetailAddInfoWork
    /// <summary>
    ///                      伝票明細追加情報データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   伝票明細追加情報データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/06/05</br>
    /// <br>Genarated Date   :   2008/10/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/02  久保田</br>
    /// <br></br>
    /// <br>Update Note      :   フタバ個別対応</br>
    /// <br>                     赤伝･返品･削除時在庫引当処理対応</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   K2014/06/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SlipDetailAddInfoWork
    {
        /// <summary>明細関連付けGUID</summary>
        /// <remarks>伝票明細と紐付ける為のGUID、UI側で設定</remarks>
        private Guid _dtlRelationGuid;

        /// <summary>商品登録区分</summary>
        /// <remarks>0:なし　1:あり</remarks>
        private Int32 _goodsEntryDiv;

        /// <summary>商品提供日付</summary>
        /// <remarks>YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型</remarks>
        private DateTime _goodsOfferDate;

        /// <summary>価格更新区分</summary>
        /// <remarks>0:なし　1:あり</remarks>
        private Int32 _priceUpdateDiv;

        /// <summary>価格開始日付</summary>
        /// <remarks>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</remarks>
        private DateTime _priceStartDate;

        /// <summary>価格提供日付</summary>
        /// <remarks>YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型</remarks>
        private DateTime _priceOfferDate;

        /// <summary>車両関連付けGUID</summary>
        /// <remarks>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</remarks>
        private Guid _carRelationGuid;

        /// <summary>伝票明細登録順位</summary>
        /// <remarks>伝票・明細の登録順位を設定</remarks>
        private Int32 _slipDtlRegOrder;

        /// <summary>計上残区分</summary>
        /// <remarks>0:IOWriteCtrlOptWorkの計上残区分に準拠　1:残す　2:残さない</remarks>
        private Int32 _addUpRemDiv;

        /// <summary>発注残調整数</summary>
        /// <remarks>元の発注残数からセットされた値を減算して発注残の計算を行う</remarks>
        private Double _orderRemainAdjustCnt;

        // --- ADD m.suzuki 2010/04/30 ---------->>>>>
        /// <summary>自由検索部品登録区分</summary>
        /// <remarks>0:なし　1:あり</remarks>
        private Int32 _freeSearchPartsEntryDiv;
        /// <summary>フル型式リスト</summary>
        /// <remarks>※自由検索部品自動登録で使用する</remarks>
        private string[] _fullModelList;
        // --- ADD m.suzuki 2010/04/30 ----------<<<<<

        // --- ADD K2014/06/12 y.wakita ----->>>>>
        /// <summary>在庫更新有無区分※フタバ個別対応</summary>
        /// <remarks>true:更新なし　false:更新あり</remarks>
        private bool _zaiUpdFlg;

        /// <summary>計上残区分※フタバ個別対応</summary>
        /// <remarks>true:残す　false:IOWriteCtrlOptWorkの計上残区分に準拠</remarks>
        private bool _addUpRemFlg;
        // --- ADD K2014/06/12 y.wakita -----<<<<<

        /// public propaty name  :  DtlRelationGuid
        /// <summary>明細関連付けGUIDプロパティ</summary>
        /// <value>伝票明細と紐付ける為のGUID、UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細関連付けGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
        }

        /// public propaty name  :  GoodsEntryDiv
        /// <summary>商品登録区分プロパティ</summary>
        /// <value>0:なし　1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsEntryDiv
        {
            get { return _goodsEntryDiv; }
            set { _goodsEntryDiv = value; }
        }

        /// public propaty name  :  GoodsOfferDate
        /// <summary>商品提供日付プロパティ</summary>
        /// <value>YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime GoodsOfferDate
        {
            get { return _goodsOfferDate; }
            set { _goodsOfferDate = value; }
        }

        /// public propaty name  :  PriceUpdateDiv
        /// <summary>価格更新区分プロパティ</summary>
        /// <value>0:なし　1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceUpdateDiv
        {
            get { return _priceUpdateDiv; }
            set { _priceUpdateDiv = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日付プロパティ</summary>
        /// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  PriceOfferDate
        /// <summary>価格提供日付プロパティ</summary>
        /// <value>YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }

        /// public propaty name  :  CarRelationGuid
        /// <summary>車両関連付けGUIDプロパティ</summary>
        /// <value>車両管理情報と伝票明細を紐付けるGUID、UI側で設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両関連付けGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid CarRelationGuid
        {
            get { return _carRelationGuid; }
            set { _carRelationGuid = value; }
        }

        /// public propaty name  :  SlipDtlRegOrder
        /// <summary>伝票明細登録順位プロパティ</summary>
        /// <value>伝票・明細の登録順位を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票明細登録順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipDtlRegOrder
        {
            get { return _slipDtlRegOrder; }
            set { _slipDtlRegOrder = value; }
        }

        /// public propaty name  :  AddUpRemDiv
        /// <summary>計上残区分プロパティ</summary>
        /// <value>0:IOWriteCtrlOptWorkの計上残区分に準拠　1:残す　2:残さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上残区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpRemDiv
        {
            get { return _addUpRemDiv; }
            set { _addUpRemDiv = value; }
        }

        /// public propaty name  :  OrderRemainAdjustCnt
        /// <summary>発注残調整数プロパティ</summary>
        /// <value>元の発注残数からセットされた値を減算して発注残の計算を行う</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注残調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderRemainAdjustCnt
        {
            get { return _orderRemainAdjustCnt; }
            set { _orderRemainAdjustCnt = value; }
        }

        // --- ADD m.suzuki 2010/04/30 ---------->>>>>
        /// public propaty name  :  FreeSearchPartsEntryDiv
        /// <summary>自由検索部品登録区分プロパティ</summary>
        /// <value>0:なし　1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索部品登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FreeSearchPartsEntryDiv
        {
            get { return _freeSearchPartsEntryDiv; }
            set { _freeSearchPartsEntryDiv = value; }
        }
        /// public propaty name  :  FreeSearchPartsEntryDiv
        /// <summary>フル型式リストプロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] FullModelList
        {
            get { return _fullModelList; }
            set { _fullModelList = value; }
        }
        // --- ADD m.suzuki 2010/04/30 ----------<<<<<

        // --- ADD K2014/06/12 y.wakita ----->>>>>
        /// public propaty name  :  ZaiUpdFlg
        /// <summary>在庫更新有無区分プロパティ※フタバ個別対応</summary>
        /// <value>true:更新なし　false:更新あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫更新有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool ZaiUpdFlg
        {
            get { return _zaiUpdFlg; }
            set { _zaiUpdFlg = value; }
        }

        /// public propaty name  :  AddUpRemFlg
        /// <summary>計上残区分プロパティ※フタバ個別対応</summary>
        /// <value>true:残す　false:IOWriteCtrlOptWorkの計上残区分に準拠</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上残区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool AddUpRemFlg
        {
            get { return _addUpRemFlg; }
            set { _addUpRemFlg = value; }
        }
        // --- ADD K2014/06/12 y.wakita -----<<<<<

        /// <summary>
        /// 伝票明細追加情報データワークコンストラクタ
        /// </summary>
        /// <returns>SlipDetailAddInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipDetailAddInfoWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SlipDetailAddInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SlipDetailAddInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipDetailAddInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipDetailAddInfoWork || graph is ArrayList || graph is SlipDetailAddInfoWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SlipDetailAddInfoWork).FullName));

            if (graph != null && graph is SlipDetailAddInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipDetailAddInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipDetailAddInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipDetailAddInfoWork[])graph).Length;
            }
            else if (graph is SlipDetailAddInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //明細関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid
            //商品登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsEntryDiv
            //商品提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //GoodsOfferDate
            //価格更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceUpdateDiv
            //価格開始日付
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //価格提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceOfferDate
            //車両関連付けGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //CarRelationGuid
            //伝票明細登録順位
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDtlRegOrder
            //計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpRemDiv
            //発注残調整数
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainAdjustCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is SlipDetailAddInfoWork)
            {
                SlipDetailAddInfoWork temp = (SlipDetailAddInfoWork)graph;

                SetSlipDetailAddInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipDetailAddInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipDetailAddInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipDetailAddInfoWork temp in lst)
                {
                    SetSlipDetailAddInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipDetailAddInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  SlipDetailAddInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSlipDetailAddInfoWork(System.IO.BinaryWriter writer, SlipDetailAddInfoWork temp)
        {
            //明細関連付けGUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
            //商品登録区分
            writer.Write(temp.GoodsEntryDiv);
            //商品提供日付
            writer.Write(temp.GoodsOfferDate.Ticks);
            //価格更新区分
            writer.Write(temp.PriceUpdateDiv);
            //価格開始日付
            writer.Write(temp.PriceStartDate.Ticks);
            //価格提供日付
            writer.Write(temp.PriceOfferDate.Ticks);
            //車両関連付けGUID
            byte[] carRelationGuidArray = temp.CarRelationGuid.ToByteArray();
            writer.Write(carRelationGuidArray.Length);
            writer.Write(temp.CarRelationGuid.ToByteArray());
            //伝票明細登録順位
            writer.Write(temp.SlipDtlRegOrder);
            //計上残区分
            writer.Write(temp.AddUpRemDiv);
            //発注残調整数
            writer.Write(temp.OrderRemainAdjustCnt);

        }

        /// <summary>
        ///  SlipDetailAddInfoWorkインスタンス取得
        /// </summary>
        /// <returns>SlipDetailAddInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SlipDetailAddInfoWork GetSlipDetailAddInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SlipDetailAddInfoWork temp = new SlipDetailAddInfoWork();

            //明細関連付けGUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);
            //商品登録区分
            temp.GoodsEntryDiv = reader.ReadInt32();
            //商品提供日付
            temp.GoodsOfferDate = new DateTime(reader.ReadInt64());
            //価格更新区分
            temp.PriceUpdateDiv = reader.ReadInt32();
            //価格開始日付
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //価格提供日付
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());
            //車両関連付けGUID
            int lenOfCarRelationGuidArray = reader.ReadInt32();
            byte[] carRelationGuidArray = reader.ReadBytes(lenOfCarRelationGuidArray);
            temp.CarRelationGuid = new Guid(carRelationGuidArray);
            //伝票明細登録順位
            temp.SlipDtlRegOrder = reader.ReadInt32();
            //計上残区分
            temp.AddUpRemDiv = reader.ReadInt32();
            //発注残調整数
            temp.OrderRemainAdjustCnt = reader.ReadDouble();


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
        /// <returns>SlipDetailAddInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipDetailAddInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipDetailAddInfoWork temp = GetSlipDetailAddInfoWork(reader, serInfo);
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
                    retValue = (SlipDetailAddInfoWork[])lst.ToArray(typeof(SlipDetailAddInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}