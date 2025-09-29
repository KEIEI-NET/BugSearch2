using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CarKindInfoWork
	/// <summary>
	///                      車種情報ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   車種情報ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/24  (CSharp File Generated Date)</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CarKindInfoWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>メーカー全角名称</summary>
		/// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
		private string _makerFullName = "";

        /// <summary>メーカー半角名称</summary>
        private string _makerHalfName = "";

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;

		/// <summary>車種全角名称</summary>
		/// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
		private string _modelFullName = "";

        /// <summary>車種半角名称</summary>        
        private string _modelHalfName = "";

		/// <summary>エンジン型式名称</summary>
		/// <remarks>型式により変動</remarks>
		private string _engineModelNm = "";

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

		/// public propaty name  :  MakerFullName
		/// <summary>メーカー全角名称プロパティ</summary>
		/// <value>正式名称（カナ漢字混在で全角管理）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー全角名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerFullName
		{
			get { return _makerFullName; }
			set { _makerFullName = value; }
		}

        /// public propaty name  :  MakerHalfName
		/// <summary>メーカー半角名称プロパティ</summary>		
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   メーカー半角名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerHalfName
		{
			get { return _makerHalfName; }
			set { _makerHalfName = value; }
		}

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get { return _modelCode; }
			set { _modelCode = value; }
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>車種サブコードプロパティ</summary>
		/// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get { return _modelSubCode; }
			set { _modelSubCode = value; }
		}

		/// public propaty name  :  ModelFullName
		/// <summary>車種全角名称プロパティ</summary>
		/// <value>正式名称（カナ漢字混在で全角管理）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種全角名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ModelFullName
		{
			get { return _modelFullName; }
			set { _modelFullName = value; }
		}

        /// public propaty name  :  ModelHalfName
		/// <summary>車種半角名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ModelHalfName
		{
			get { return _modelHalfName; }
			set { _modelHalfName = value; }
		}

		/// public propaty name  :  EngineModelNm
		/// <summary>エンジン型式名称プロパティ</summary>
		/// <value>型式により変動</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   エンジン型式名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EngineModelNm
		{
			get { return _engineModelNm; }
			set { _engineModelNm = value; }
		}

		/// <summary>
		/// 車種情報ワークコンストラクタ
		/// </summary>
		/// <returns>CarKindInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CarKindInfoWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CarKindInfoWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>CarKindInfoWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   CarKindInfoWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class CarKindInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CarKindInfoWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  CarKindInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is CarKindInfoWork || graph is ArrayList || graph is CarKindInfoWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CarKindInfoWork).FullName));

			if (graph != null && graph is CarKindInfoWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is CarKindInfoWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((CarKindInfoWork[])graph).Length;
			}
			else if (graph is CarKindInfoWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//メーカー全角名称
			serInfo.MemberInfo.Add(typeof(string)); //MakerFullName
            //メーカー半角名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerHalfName
			//車種コード
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
			//車種サブコード
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
			//車種全角名称
			serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //車種半角名称
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
			//エンジン型式名称
			serInfo.MemberInfo.Add(typeof(string)); //EngineModelNm

			serInfo.Serialize(writer, serInfo);
			if (graph is CarKindInfoWork)
			{
				CarKindInfoWork temp = (CarKindInfoWork)graph;

				SetCarKindInfoWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is CarKindInfoWork[])
				{
					lst = new ArrayList();
					lst.AddRange((CarKindInfoWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (CarKindInfoWork temp in lst)
				{
					SetCarKindInfoWork(writer, temp);
				}

			}

		}


		/// <summary>
		/// CarKindInfoWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 8;

		/// <summary>
		///  CarKindInfoWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CarKindInfoWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetCarKindInfoWork(System.IO.BinaryWriter writer, CarKindInfoWork temp)
		{
			//メーカーコード
			writer.Write(temp.MakerCode);
			//メーカー全角名称
			writer.Write(temp.MakerFullName);
            //メーカー半角名称
            writer.Write(temp.MakerHalfName);
			//車種コード
			writer.Write(temp.ModelCode);
			//車種サブコード
			writer.Write(temp.ModelSubCode);
			//車種全角名称
			writer.Write(temp.ModelFullName);
            //車種半角名称
            writer.Write(temp.ModelHalfName);
			//エンジン型式名称
			writer.Write(temp.EngineModelNm);

		}

		/// <summary>
		///  CarKindInfoWorkインスタンス取得
		/// </summary>
		/// <returns>CarKindInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CarKindInfoWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private CarKindInfoWork GetCarKindInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			CarKindInfoWork temp = new CarKindInfoWork();

			//メーカーコード
			temp.MakerCode = reader.ReadInt32();
			//メーカー全角名称
			temp.MakerFullName = reader.ReadString();
            //メーカー半角名称
            temp.MakerHalfName = reader.ReadString();
			//車種コード
			temp.ModelCode = reader.ReadInt32();
			//車種サブコード
			temp.ModelSubCode = reader.ReadInt32();
			//車種全角名称
			temp.ModelFullName = reader.ReadString();
            //車種半角名称
            temp.ModelHalfName = reader.ReadString();
			//エンジン型式名称
			temp.EngineModelNm = reader.ReadString();

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
		/// <returns>CarKindInfoWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CarKindInfoWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				CarKindInfoWork temp = GetCarKindInfoWork(reader, serInfo);
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
					retValue = (CarKindInfoWork[])lst.ToArray(typeof(CarKindInfoWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
