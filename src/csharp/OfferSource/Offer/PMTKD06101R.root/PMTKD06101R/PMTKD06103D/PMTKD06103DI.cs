using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ColorCdRetWork
	/// <summary>
	///                      カラー抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   カラー抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ColorCdRetWork
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
		/// <summary>カラーコード</summary>
		/// <remarks>カタログの色コード</remarks>
		private string _colorCode = "";
/*
		/// <summary>カラーコード重複時枝番</summary>
		private Int32 _colorCdDupDerivedNo;
*/
		/// <summary>カラー名称1</summary>
		/// <remarks>画面表示用正式名称</remarks>
		private string _colorName1 = "";


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
		/// public propaty name  :  ColorCode
		/// <summary>カラーコードプロパティ</summary>
		/// <value>カタログの色コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カラーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ColorCode
		{
			get { return _colorCode; }
			set { _colorCode = value; }
		}
/*
		/// public propaty name  :  ColorCdDupDerivedNo
		/// <summary>カラーコード重複時枝番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カラーコード重複時枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ColorCdDupDerivedNo
		{
			get { return _colorCdDupDerivedNo; }
			set { _colorCdDupDerivedNo = value; }
		}
*/
		/// public propaty name  :  ColorName1
		/// <summary>カラー名称1プロパティ</summary>
		/// <value>画面表示用正式名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カラー名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ColorName1
		{
			get { return _colorName1; }
			set { _colorName1 = value; }
		}


		/// <summary>
		/// カラー抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>ColorCdRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ColorCdRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ColorCdRetWork()
		{
		}

	}


	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>ColorCdRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   ColorCdRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class ColorCdRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ColorCdRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  ColorCdRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is ColorCdRetWork || graph is ArrayList || graph is ColorCdRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ColorCdRetWork).FullName));

			if (graph != null && graph is ColorCdRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is ColorCdRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((ColorCdRetWork[])graph).Length;
			}
			else if (graph is ColorCdRetWork)
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
			//カラーコード
			serInfo.MemberInfo.Add(typeof(string)); //ColorCode
/*			//カラーコード重複時枝番
			serInfo.MemberInfo.Add(typeof(Int32)); //ColorCdDupDerivedNo*/
			//カラー名称1
			serInfo.MemberInfo.Add(typeof(string)); //ColorName1


			serInfo.Serialize(writer, serInfo);
			if (graph is ColorCdRetWork)
			{
				ColorCdRetWork temp = (ColorCdRetWork)graph;

				SetColorCdRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is ColorCdRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((ColorCdRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (ColorCdRetWork temp in lst)
				{
					SetColorCdRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// ColorCdRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		//private const int currentMemberCount = 8;
        private const int currentMemberCount = 5;

		/// <summary>
		///  ColorCdRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ColorCdRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetColorCdRetWork(System.IO.BinaryWriter writer, ColorCdRetWork temp)
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
			//カラーコード
			writer.Write(temp.ColorCode);
/*			//カラーコード重複時枝番
			writer.Write(temp.ColorCdDupDerivedNo);*/
			//カラー名称1
			writer.Write(temp.ColorName1);

		}

		/// <summary>
		///  ColorCdRetWorkインスタンス取得
		/// </summary>
		/// <returns>ColorCdRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ColorCdRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private ColorCdRetWork GetColorCdRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			ColorCdRetWork temp = new ColorCdRetWork();

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
			//カラーコード
			temp.ColorCode = reader.ReadString();
/*			//カラーコード重複時枝番
			temp.ColorCdDupDerivedNo = reader.ReadInt32();*/
			//カラー名称1
			temp.ColorName1 = reader.ReadString();


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
		/// <returns>ColorCdRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ColorCdRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				ColorCdRetWork temp = GetColorCdRetWork(reader, serInfo);
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
					retValue = (ColorCdRetWork[])lst.ToArray(typeof(ColorCdRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
