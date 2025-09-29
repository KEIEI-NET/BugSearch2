using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesProcMoneyWork
	/// <summary>
	///                      売上金額処理区分設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上金額処理区分設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/08/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesProcMoneyWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>端数処理対象金額区分</summary>
		/// <remarks>0:売上金額,1:消費税,2:売上単価,3:売上原価単価,4:売上原価金額,3,4は自社用設定のみ</remarks>
		private Int32 _fracProcMoneyDiv;

		/// <summary>端数処理コード</summary>
		/// <remarks>0の場合は自社用(標準)設定とする。</remarks>
		private Int32 _fractionProcCode;

		/// <summary>上限金額</summary>
		/// <remarks>金額の場合は整数のみ設定</remarks>
		private Double _upperLimitPrice;

		/// <summary>端数処理単位</summary>
		private Double _fractionProcUnit;

		/// <summary>端数処理区分</summary>
		/// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
		private Int32 _fractionProcCd;


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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

		/// public propaty name  :  FracProcMoneyDiv
		/// <summary>端数処理対象金額区分プロパティ</summary>
		/// <value>0:売上金額,1:消費税,2:売上単価,3:売上原価単価,4:売上原価金額,3,4は自社用設定のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理対象金額区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FracProcMoneyDiv
		{
			get{return _fracProcMoneyDiv;}
			set{_fracProcMoneyDiv = value;}
		}

		/// public propaty name  :  FractionProcCode
		/// <summary>端数処理コードプロパティ</summary>
		/// <value>0の場合は自社用(標準)設定とする。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCode
		{
			get{return _fractionProcCode;}
			set{_fractionProcCode = value;}
		}

		/// public propaty name  :  UpperLimitPrice
		/// <summary>上限金額プロパティ</summary>
		/// <value>金額の場合は整数のみ設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   上限金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double UpperLimitPrice
		{
			get{return _upperLimitPrice;}
			set{_upperLimitPrice = value;}
		}

		/// public propaty name  :  FractionProcUnit
		/// <summary>端数処理単位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double FractionProcUnit
		{
			get{return _fractionProcUnit;}
			set{_fractionProcUnit = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}


		/// <summary>
		/// 売上金額処理区分設定ワークコンストラクタ
		/// </summary>
		/// <returns>SalesProcMoneyWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesProcMoneyWork()
		{
		}

  }

  /// <summary>
  ///  Ver5.10.1.0用のカスタムシライアライザです。
  /// </summary>
  /// <returns>SalesProcMoneyWorkクラスのインスタンス(object)</returns>
  /// <remarks>
  /// <br>Note　　　　　　 :   SalesProcMoneyWorkクラスのカスタムシリアライザを定義します</br>
  /// <br>Programer        :   自動生成</br>
  /// </remarks>
  public class SalesProcMoneyWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
  {
    #region ICustomSerializationSurrogate メンバ

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesProcMoneyWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public void Serialize(System.IO.BinaryWriter writer, object graph)
    {
      // TODO:  SalesProcMoneyWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
      if (writer == null)
        throw new ArgumentNullException();

      if (graph != null && !(graph is SalesProcMoneyWork || graph is ArrayList || graph is SalesProcMoneyWork[]))
        throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesProcMoneyWork).FullName));

      if (graph != null && graph is SalesProcMoneyWork)
      {
        Type t = graph.GetType();
        if (!CustomFormatterServices.NeedCustomSerialization(t))
          throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
      }

      //SerializationTypeInfo
      Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesProcMoneyWork");

      //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
      int occurrence = 0;     //一般にゼロの場合もありえます
      if (graph is ArrayList)
      {
        serInfo.RetTypeInfo = 0;
        occurrence = ((ArrayList)graph).Count;
      }
      else if (graph is SalesProcMoneyWork[])
      {
        serInfo.RetTypeInfo = 2;
        occurrence = ((SalesProcMoneyWork[])graph).Length;
      }
      else if (graph is SalesProcMoneyWork)
      {
        serInfo.RetTypeInfo = 1;
        occurrence = 1;
      }

      serInfo.Occurrence = occurrence;		 //繰り返し数	

      //作成日時
      serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
      //更新日時
      serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
      //企業コード
      serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
      //GUID
      serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
      //更新従業員コード
      serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
      //更新アセンブリID1
      serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
      //更新アセンブリID2
      serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
      //論理削除区分
      serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
      //端数処理対象金額区分
      serInfo.MemberInfo.Add(typeof(Int32)); //FracProcMoneyDiv
      //端数処理コード
      serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCode
      //上限金額
      serInfo.MemberInfo.Add(typeof(Double)); //UpperLimitPrice
      //端数処理単位
      serInfo.MemberInfo.Add(typeof(Double)); //FractionProcUnit
      //端数処理区分
      serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd


      serInfo.Serialize(writer, serInfo);
      if (graph is SalesProcMoneyWork)
      {
        SalesProcMoneyWork temp = (SalesProcMoneyWork)graph;

        SetSalesProcMoneyWork(writer, temp);
      }
      else
      {
        ArrayList lst = null;
        if (graph is SalesProcMoneyWork[])
        {
          lst = new ArrayList();
          lst.AddRange((SalesProcMoneyWork[])graph);
        }
        else
        {
          lst = (ArrayList)graph;
        }

        foreach (SalesProcMoneyWork temp in lst)
        {
          SetSalesProcMoneyWork(writer, temp);
        }

      }


    }


    /// <summary>
    /// SalesProcMoneyWorkメンバ数(publicプロパティ数)
    /// </summary>
    private const int currentMemberCount = 13;

    /// <summary>
    ///  SalesProcMoneyWorkインスタンス書き込み
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesProcMoneyWorkのインスタンスを書き込み</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private void SetSalesProcMoneyWork(System.IO.BinaryWriter writer, SalesProcMoneyWork temp)
    {
      //作成日時
      writer.Write((Int64)temp.CreateDateTime.Ticks);
      //更新日時
      writer.Write((Int64)temp.UpdateDateTime.Ticks);
      //企業コード
      writer.Write(temp.EnterpriseCode);
      //GUID
      byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
      writer.Write(fileHeaderGuidArray.Length);
      writer.Write(temp.FileHeaderGuid.ToByteArray());
      //更新従業員コード
      writer.Write(temp.UpdEmployeeCode);
      //更新アセンブリID1
      writer.Write(temp.UpdAssemblyId1);
      //更新アセンブリID2
      writer.Write(temp.UpdAssemblyId2);
      //論理削除区分
      writer.Write(temp.LogicalDeleteCode);
      //端数処理対象金額区分
      writer.Write(temp.FracProcMoneyDiv);
      //端数処理コード
      writer.Write(temp.FractionProcCode);
      //上限金額
      writer.Write(temp.UpperLimitPrice);
      //端数処理単位
      writer.Write(temp.FractionProcUnit);
      //端数処理区分
      writer.Write(temp.FractionProcCd);

    }

    /// <summary>
    ///  SalesProcMoneyWorkインスタンス取得
    /// </summary>
    /// <returns>SalesProcMoneyWorkクラスのインスタンス</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesProcMoneyWorkのインスタンスを取得します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private SalesProcMoneyWork GetSalesProcMoneyWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    {
      // V5.1.0.0なので不要ですが、V5.1.0.1以降では
      // serInfo.MemberInfo.Count < currentMemberCount
      // のケースについての配慮が必要になります。

      SalesProcMoneyWork temp = new SalesProcMoneyWork();

      //作成日時
      temp.CreateDateTime = new DateTime(reader.ReadInt64());
      //更新日時
      temp.UpdateDateTime = new DateTime(reader.ReadInt64());
      //企業コード
      temp.EnterpriseCode = reader.ReadString();
      //GUID
      int lenOfFileHeaderGuidArray = reader.ReadInt32();
      byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
      temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
      //更新従業員コード
      temp.UpdEmployeeCode = reader.ReadString();
      //更新アセンブリID1
      temp.UpdAssemblyId1 = reader.ReadString();
      //更新アセンブリID2
      temp.UpdAssemblyId2 = reader.ReadString();
      //論理削除区分
      temp.LogicalDeleteCode = reader.ReadInt32();
      //端数処理対象金額区分
      temp.FracProcMoneyDiv = reader.ReadInt32();
      //端数処理コード
      temp.FractionProcCode = reader.ReadInt32();
      //上限金額
      temp.UpperLimitPrice = reader.ReadDouble();
      //端数処理単位
      temp.FractionProcUnit = reader.ReadDouble();
      //端数処理区分
      temp.FractionProcCd = reader.ReadInt32();


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
    /// <returns>SalesProcMoneyWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesProcMoneyWorkクラスのカスタムデシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public object Deserialize(System.IO.BinaryReader reader)
    {
      object retValue = null;
      Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
      ArrayList lst = new ArrayList();
      for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
      {
        SalesProcMoneyWork temp = GetSalesProcMoneyWork(reader, serInfo);
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
          retValue = (SalesProcMoneyWork[])lst.ToArray(typeof(SalesProcMoneyWork));
          break;
      }
      return retValue;
    }

    #endregion
  }

}
