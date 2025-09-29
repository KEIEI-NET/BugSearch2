using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   TrimCdRetWork
	/// <summary>
	///                      トリム抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   トリム抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class TrimCdRetWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;
/*
		/// <summary>系統コード</summary>
		private Int32 _systematicCode;

		/// <summary>生産年式コード</summary>
		private Int32 _produceTypeOfYearCd;
*/
		/// <summary>トリムコード</summary>
		private string _trimCode = "";

		/// <summary>トリム名称</summary>
		private string _trimName = "";


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
/*
		/// public propaty name  :  SystematicCode
		/// <summary>系統コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   系統コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystematicCode
		{
			get { return _systematicCode; }
			set { _systematicCode = value; }
		}

		/// public propaty name  :  ProduceTypeOfYearCd
		/// <summary>生産年式コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産年式コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ProduceTypeOfYearCd
		{
			get { return _produceTypeOfYearCd; }
			set { _produceTypeOfYearCd = value; }
		}
*/
		/// public propaty name  :  TrimCode
		/// <summary>トリムコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   トリムコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TrimCode
		{
			get { return _trimCode; }
			set { _trimCode = value; }
		}

		/// public propaty name  :  TrimName
		/// <summary>トリム名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   トリム名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TrimName
		{
			get { return _trimName; }
			set { _trimName = value; }
		}


		/// <summary>
		/// トリム抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>TrimCdRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TrimCdRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TrimCdRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>TrimCdRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   TrimCdRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class TrimCdRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   TrimCdRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  TrimCdRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is TrimCdRetWork || graph is ArrayList || graph is TrimCdRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TrimCdRetWork).FullName));

			if (graph != null && graph is TrimCdRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is TrimCdRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((TrimCdRetWork[])graph).Length;
			}
			else if (graph is TrimCdRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//車種コード
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
			//車種サブコード
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
/*			//系統コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SystematicCode
            //生産年式コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearCd*/
            //トリムコード
			serInfo.MemberInfo.Add(typeof(string)); //TrimCode
			//トリム名称
			serInfo.MemberInfo.Add(typeof(string)); //TrimName


			serInfo.Serialize(writer, serInfo);
			if (graph is TrimCdRetWork)
			{
				TrimCdRetWork temp = (TrimCdRetWork)graph;

				SetTrimCdRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is TrimCdRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((TrimCdRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (TrimCdRetWork temp in lst)
				{
					SetTrimCdRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// TrimCdRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 5;

		/// <summary>
		///  TrimCdRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   TrimCdRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetTrimCdRetWork(System.IO.BinaryWriter writer, TrimCdRetWork temp)
		{
			//メーカーコード
			writer.Write(temp.MakerCode);
			//車種コード
			writer.Write(temp.ModelCode);
			//車種サブコード
			writer.Write(temp.ModelSubCode);
/*			//系統コード
			writer.Write(temp.SystematicCode);
			//生産年式コード
			writer.Write(temp.ProduceTypeOfYearCd);*/
			//トリムコード
			writer.Write(temp.TrimCode);
			//トリム名称
			writer.Write(temp.TrimName);

		}

		/// <summary>
		///  TrimCdRetWorkインスタンス取得
		/// </summary>
		/// <returns>TrimCdRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TrimCdRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private TrimCdRetWork GetTrimCdRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			TrimCdRetWork temp = new TrimCdRetWork();

			//メーカーコード
			temp.MakerCode = reader.ReadInt32();
			//車種コード
			temp.ModelCode = reader.ReadInt32();
			//車種サブコード
			temp.ModelSubCode = reader.ReadInt32();
/*			//系統コード
			temp.SystematicCode = reader.ReadInt32();
			//生産年式コード
			temp.ProduceTypeOfYearCd = reader.ReadInt32();*/
			//トリムコード
			temp.TrimCode = reader.ReadString();
			//トリム名称
			temp.TrimName = reader.ReadString();


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
		/// <returns>TrimCdRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TrimCdRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				TrimCdRetWork temp = GetTrimCdRetWork(reader, serInfo);
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
					retValue = (TrimCdRetWork[])lst.ToArray(typeof(TrimCdRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
