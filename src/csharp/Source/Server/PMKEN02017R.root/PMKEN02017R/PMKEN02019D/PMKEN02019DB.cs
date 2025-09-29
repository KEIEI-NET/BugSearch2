using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrmSettingPrintResultWork
	/// <summary>
	///                      優良設定印刷抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   優良設定印刷抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrmSettingPrintResultWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>拠点ガイド略称</summary>
		/// <remarks>帳票印字用</remarks>
		private string _sectionGuideSnm = "";

		/// <summary>商品中分類コード</summary>
		/// <remarks>※中分類</remarks>
		private Int32 _goodsMGroup;

		/// <summary>商品中分類名称</summary>
		private string _goodsMGroupName = "";

		/// <summary>BLコード</summary>
		private Int32 _tbsPartsCode;

		/// <summary>BL商品コード名称（半角）</summary>
		private string _bLGoodsHalfName = "";

		/// <summary>部品メーカーコード</summary>
		private Int32 _partsMakerCd;

		/// <summary>メーカー略称</summary>
		private string _makerShortName = "";

		/// <summary>優良表示順位</summary>
		private Int32 _primeDispOrder;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>優良設定詳細名称１</summary>
		private string _prmSetDtlName1 = "";

		/// <summary>優良設定詳細名称２</summary>
		private string _prmSetDtlName2 = "";

		/// <summary>メーカー表示順位</summary>
		private Int32 _makerDispOrder;

		/// <summary>優良表示区分</summary>
		/// <remarks>0:無し　1:商品&結合　2:商品</remarks>
		private Int32 _primeDisplayCode;


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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SectionGuideSnm
		/// <summary>拠点ガイド略称プロパティ</summary>
		/// <value>帳票印字用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideSnm
		{
			get{return _sectionGuideSnm;}
			set{_sectionGuideSnm = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>商品中分類コードプロパティ</summary>
		/// <value>※中分類</value>
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

		/// public propaty name  :  GoodsMGroupName
		/// <summary>商品中分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
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

		/// public propaty name  :  BLGoodsHalfName
		/// <summary>BL商品コード名称（半角）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（半角）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsHalfName
		{
			get{return _bLGoodsHalfName;}
			set{_bLGoodsHalfName = value;}
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

		/// public propaty name  :  MakerShortName
		/// <summary>メーカー略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerShortName
		{
			get{return _makerShortName;}
			set{_makerShortName = value;}
		}

		/// public propaty name  :  PrimeDispOrder
		/// <summary>優良表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrimeDispOrder
		{
			get{return _primeDispOrder;}
			set{_primeDispOrder = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>仕入先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  PrmSetDtlName1
		/// <summary>優良設定詳細名称１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細名称１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrmSetDtlName1
		{
			get{return _prmSetDtlName1;}
			set{_prmSetDtlName1 = value;}
		}

		/// public propaty name  :  PrmSetDtlName2
		/// <summary>優良設定詳細名称２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細名称２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrmSetDtlName2
		{
			get{return _prmSetDtlName2;}
			set{_prmSetDtlName2 = value;}
		}

		/// public propaty name  :  MakerDispOrder
		/// <summary>メーカー表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerDispOrder
		{
			get{return _makerDispOrder;}
			set{_makerDispOrder = value;}
		}

		/// public propaty name  :  PrimeDisplayCode
		/// <summary>優良表示区分プロパティ</summary>
		/// <value>0:無し　1:商品&結合　2:商品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrimeDisplayCode
		{
			get{return _primeDisplayCode;}
			set{_primeDisplayCode = value;}
		}


		/// <summary>
		/// 優良設定印刷抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>PrmSettingPrintResultWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrmSettingPrintResultWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrmSettingPrintResultWork()
		{
		}

	}


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmSettingPrintResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmSettingPrintResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmSettingPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingPrintResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmSettingPrintResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmSettingPrintResultWork || graph is ArrayList || graph is PrmSettingPrintResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrmSettingPrintResultWork).FullName));

            if (graph != null && graph is PrmSettingPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingPrintResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmSettingPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmSettingPrintResultWork[])graph).Length;
            }
            else if (graph is PrmSettingPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //商品中分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //優良表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDispOrder
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //優良設定詳細名称１
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName1
            //優良設定詳細名称２
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //メーカー表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerDispOrder
            //優良表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDisplayCode


            serInfo.Serialize(writer, serInfo);
            if (graph is PrmSettingPrintResultWork)
            {
                PrmSettingPrintResultWork temp = (PrmSettingPrintResultWork)graph;

                SetPrmSettingPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSettingPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmSettingPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSettingPrintResultWork temp in lst)
                {
                    SetPrmSettingPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmSettingPrintResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  PrmSettingPrintResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingPrintResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmSettingPrintResultWork(System.IO.BinaryWriter writer, PrmSettingPrintResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //商品中分類名称
            writer.Write(temp.GoodsMGroupName);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //優良表示順位
            writer.Write(temp.PrimeDispOrder);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //優良設定詳細名称１
            writer.Write(temp.PrmSetDtlName1);
            //優良設定詳細名称２
            writer.Write(temp.PrmSetDtlName2);
            //メーカー表示順位
            writer.Write(temp.MakerDispOrder);
            //優良表示区分
            writer.Write(temp.PrimeDisplayCode);

        }

        /// <summary>
        ///  PrmSettingPrintResultWorkインスタンス取得
        /// </summary>
        /// <returns>PrmSettingPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingPrintResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmSettingPrintResultWork GetPrmSettingPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmSettingPrintResultWork temp = new PrmSettingPrintResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //商品中分類名称
            temp.GoodsMGroupName = reader.ReadString();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //優良表示順位
            temp.PrimeDispOrder = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //優良設定詳細名称１
            temp.PrmSetDtlName1 = reader.ReadString();
            //優良設定詳細名称２
            temp.PrmSetDtlName2 = reader.ReadString();
            //メーカー表示順位
            temp.MakerDispOrder = reader.ReadInt32();
            //優良表示区分
            temp.PrimeDisplayCode = reader.ReadInt32();


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
        /// <returns>PrmSettingPrintResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingPrintResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingPrintResultWork temp = GetPrmSettingPrintResultWork(reader, serInfo);
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
                    retValue = (PrmSettingPrintResultWork[])lst.ToArray(typeof(PrmSettingPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
