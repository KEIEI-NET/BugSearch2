using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrdTypYearRetWork
	/// <summary>
	///                      生産年式抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   生産年式抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrdTypYearRetWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車台型式</summary>
		private string _frameModel = "";

		/// <summary>生産車台番号開始</summary>
		private Int32 _stProduceFrameNo;

		/// <summary>生産車台番号終了</summary>
		private Int32 _edProduceFrameNo;

		/// <summary>生産年式</summary>
		/// <remarks>YYYYDD</remarks>
        private Int32 _produceTypeOfYear;


		/// public propaty name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  FrameModel
		/// <summary>車台型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameModel
		{
			get { return _frameModel; }
			set { _frameModel = value; }
		}

		/// public propaty name  :  StProduceFrameNo
		/// <summary>生産車台番号開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産車台番号開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StProduceFrameNo
		{
			get { return _stProduceFrameNo; }
			set { _stProduceFrameNo = value; }
		}

		/// public propaty name  :  EdProduceFrameNo
		/// <summary>生産車台番号終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産車台番号終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdProduceFrameNo
		{
			get { return _edProduceFrameNo; }
			set { _edProduceFrameNo = value; }
		}

		/// public propaty name  :  ProduceTypeOfYear
		/// <summary>生産年式プロパティ</summary>
		/// <value>YYYYDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産年式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 ProduceTypeOfYear
		{
			get { return _produceTypeOfYear; }
			set { _produceTypeOfYear = value; }
		}


		/// <summary>
		/// 生産年式抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>PrdTypYearRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrdTypYearRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrdTypYearRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>PrdTypYearRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   PrdTypYearRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class PrdTypYearRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrdTypYearRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  PrdTypYearRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is PrdTypYearRetWork || graph is ArrayList || graph is PrdTypYearRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrdTypYearRetWork).FullName));

			if (graph != null && graph is PrdTypYearRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is PrdTypYearRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((PrdTypYearRetWork[])graph).Length;
			}
			else if (graph is PrdTypYearRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//車台型式
			serInfo.MemberInfo.Add(typeof(string)); //FrameModel
			//生産車台番号開始
			serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
			//生産車台番号終了
			serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
			//生産年式
			serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYear


			serInfo.Serialize(writer, serInfo);
			if (graph is PrdTypYearRetWork)
			{
				PrdTypYearRetWork temp = (PrdTypYearRetWork)graph;

				SetPrdTypYearRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is PrdTypYearRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((PrdTypYearRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (PrdTypYearRetWork temp in lst)
				{
					SetPrdTypYearRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// PrdTypYearRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 5;

		/// <summary>
		///  PrdTypYearRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrdTypYearRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetPrdTypYearRetWork(System.IO.BinaryWriter writer, PrdTypYearRetWork temp)
		{
			//メーカーコード
			writer.Write(temp.MakerCode);
			//車台型式
			writer.Write(temp.FrameModel);
			//生産車台番号開始
			writer.Write(temp.StProduceFrameNo);
			//生産車台番号終了
			writer.Write(temp.EdProduceFrameNo);
			//生産年式
			writer.Write(temp.ProduceTypeOfYear);

		}

		/// <summary>
		///  PrdTypYearRetWorkインスタンス取得
		/// </summary>
		/// <returns>PrdTypYearRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrdTypYearRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private PrdTypYearRetWork GetPrdTypYearRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			PrdTypYearRetWork temp = new PrdTypYearRetWork();

			//メーカーコード
			temp.MakerCode = reader.ReadInt32();
			//車台型式
			temp.FrameModel = reader.ReadString();
			//生産車台番号開始
			temp.StProduceFrameNo = reader.ReadInt32();
			//生産車台番号終了
			temp.EdProduceFrameNo = reader.ReadInt32();
			//生産年式
			temp.ProduceTypeOfYear = reader.ReadInt32();


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
		/// <returns>PrdTypYearRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrdTypYearRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				PrdTypYearRetWork temp = GetPrdTypYearRetWork(reader, serInfo);
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
					retValue = (PrdTypYearRetWork[])lst.ToArray(typeof(PrdTypYearRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
