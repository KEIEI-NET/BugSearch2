using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
 	/// public class name:   PrmSettingChgWork
	/// <summary>
	///                      優良設定変更ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   優良設定変更ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   1/5</br>
	/// <br>Genarated Date   :   2009/01/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrmSettingChgWork
	{
		/// <summary>提供日付</summary>
		/// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

		/// <summary>商品中分類コード</summary>
		private Int32 _goodsMGroup;

		/// <summary>部品メーカーコード</summary>
		private Int32 _partsMakerCd;

		/// <summary>BLコード</summary>
		private Int32 _tbsPartsCode;

		/// <summary>BLコード枝番</summary>
		/// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
		private Int32 _tbsPartsCdDerivedNo;

		/// <summary>優良設定詳細コード１</summary>
		private Int32 _prmSetDtlNo1;

		/// <summary>優良設定詳細コード２</summary>
		private Int32 _prmSetDtlNo2;

		/// <summary>変更後優良設定詳細コード１</summary>
		/// <remarks>-1の時変更対象外</remarks>
		private Int32 _afPrmSetDtlNo1;

		/// <summary>変更後優良設定詳細コード２</summary>
		/// <remarks>-1の時変更対象外</remarks>
		private Int32 _afPrmSetDtlNo2;

		/// <summary>変更後優良表示区分</summary>
		/// <remarks>1:商品&結合　2:商品 (-1の時変更対象外)</remarks>
		private Int32 _afPrimeDisplayCode;

		/// <summary>処理区分</summary>
		/// <remarks>0:変更 1:削除</remarks>
		private Int32 _procDivCd;


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
			get{return _offerDate;}
			set{_offerDate = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  PartsMakerCd
		/// <summary>部品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsMakerCd
		{
			get{return _partsMakerCd;}
			set{_partsMakerCd = value;}
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>BLコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 TbsPartsCode
		{
			get{return _tbsPartsCode;}
			set{_tbsPartsCode = value;}
		}

		/// public propaty name  :  TbsPartsCdDerivedNo
		/// <summary>BLコード枝番プロパティ</summary>
		/// <value>※未使用項目（レイアウトには入れておく）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLコード枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TbsPartsCdDerivedNo
		{
			get{return _tbsPartsCdDerivedNo;}
			set{_tbsPartsCdDerivedNo = value;}
		}

		/// public propaty name  :  PrmSetDtlNo1
		/// <summary>優良設定詳細コード１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrmSetDtlNo1
		{
			get{return _prmSetDtlNo1;}
			set{_prmSetDtlNo1 = value;}
		}

		/// public propaty name  :  PrmSetDtlNo2
		/// <summary>優良設定詳細コード２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrmSetDtlNo2
		{
			get{return _prmSetDtlNo2;}
			set{_prmSetDtlNo2 = value;}
		}

		/// public propaty name  :  AfPrmSetDtlNo1
		/// <summary>変更後優良設定詳細コード１プロパティ</summary>
		/// <value>-1の時変更対象外</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更後優良設定詳細コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AfPrmSetDtlNo1
		{
			get{return _afPrmSetDtlNo1;}
			set{_afPrmSetDtlNo1 = value;}
		}

		/// public propaty name  :  AfPrmSetDtlNo2
		/// <summary>変更後優良設定詳細コード２プロパティ</summary>
		/// <value>-1の時変更対象外</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更後優良設定詳細コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AfPrmSetDtlNo2
		{
			get{return _afPrmSetDtlNo2;}
			set{_afPrmSetDtlNo2 = value;}
		}

		/// public propaty name  :  AfPrimeDisplayCode
		/// <summary>変更後優良表示区分プロパティ</summary>
		/// <value>1:商品&結合　2:商品 (-1の時変更対象外)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更後優良表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AfPrimeDisplayCode
		{
			get{return _afPrimeDisplayCode;}
			set{_afPrimeDisplayCode = value;}
		}

		/// public propaty name  :  ProcDivCd
		/// <summary>処理区分プロパティ</summary>
		/// <value>0:変更 1:削除</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ProcDivCd
		{
			get{return _procDivCd;}
			set{_procDivCd = value;}
		}


		/// <summary>
		/// 優良設定変更ワークコンストラクタ
		/// </summary>
		/// <returns>PrmSettingChgWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrmSettingChgWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrmSettingChgWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmSettingChgWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmSettingChgWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmSettingChgWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingChgWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  PrmSettingChgWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is PrmSettingChgWork || graph is ArrayList || graph is PrmSettingChgWork[]) )
			throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(PrmSettingChgWork).FullName ) );

		if( graph != null && graph is PrmSettingChgWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingChgWork" );

		//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		int occurrence = 0;     //一般にゼロの場合もありえます
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is PrmSettingChgWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((PrmSettingChgWork[])graph).Length;
		}
		else if( graph is PrmSettingChgWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //繰り返し数	

		//提供日付
		serInfo.MemberInfo.Add( typeof(Int32) ); //OfferDate
		//商品中分類コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsMGroup
		//部品メーカーコード
		serInfo.MemberInfo.Add( typeof(Int32) ); //PartsMakerCd
		//BLコード
        serInfo.MemberInfo.Add( typeof(Int32) ); //TbsPartsCode
		//BLコード枝番
		serInfo.MemberInfo.Add( typeof(Int32) ); //TbsPartsCdDerivedNo
		//優良設定詳細コード１
		serInfo.MemberInfo.Add( typeof(Int32) ); //PrmSetDtlNo1
		//優良設定詳細コード２
		serInfo.MemberInfo.Add( typeof(Int32) ); //PrmSetDtlNo2
		//変更後優良設定詳細コード１
		serInfo.MemberInfo.Add( typeof(Int32) ); //AfPrmSetDtlNo1
		//変更後優良設定詳細コード２
		serInfo.MemberInfo.Add( typeof(Int32) ); //AfPrmSetDtlNo2
		//変更後優良表示区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //AfPrimeDisplayCode
		//処理区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //ProcDivCd

			
		serInfo.Serialize( writer, serInfo );
		if( graph is PrmSettingChgWork )
		{
			PrmSettingChgWork temp = (PrmSettingChgWork)graph;

			SetPrmSettingChgWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is PrmSettingChgWork[])
			{
				lst = new ArrayList();
				lst.AddRange((PrmSettingChgWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(PrmSettingChgWork temp in lst)
			{
				SetPrmSettingChgWork(writer, temp);
			}

		}

		
	}


        /// <summary>
        /// PrmSettingChgWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  PrmSettingChgWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingChgWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmSettingChgWork(System.IO.BinaryWriter writer, PrmSettingChgWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCd);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            //変更後優良設定詳細コード１
            writer.Write(temp.AfPrmSetDtlNo1);
            //変更後優良設定詳細コード２
            writer.Write(temp.AfPrmSetDtlNo2);
            //変更後優良表示区分
            writer.Write(temp.AfPrimeDisplayCode);
            //処理区分
            writer.Write(temp.ProcDivCd);

        }

        /// <summary>
        ///  PrmSettingChgWorkインスタンス取得
        /// </summary>
        /// <returns>PrmSettingChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingChgWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmSettingChgWork GetPrmSettingChgWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmSettingChgWork temp = new PrmSettingChgWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //変更後優良設定詳細コード１
            temp.AfPrmSetDtlNo1 = reader.ReadInt32();
            //変更後優良設定詳細コード２
            temp.AfPrmSetDtlNo2 = reader.ReadInt32();
            //変更後優良表示区分
            temp.AfPrimeDisplayCode = reader.ReadInt32();
            //処理区分
            temp.ProcDivCd = reader.ReadInt32();


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
        /// <returns>PrmSettingChgWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingChgWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingChgWork temp = GetPrmSettingChgWork(reader, serInfo);
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
                    retValue = (PrmSettingChgWork[])lst.ToArray(typeof(PrmSettingChgWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
