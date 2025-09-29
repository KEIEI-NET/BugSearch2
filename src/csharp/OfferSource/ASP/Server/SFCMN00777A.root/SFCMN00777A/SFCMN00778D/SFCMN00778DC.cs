using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ChgGidncDtWork
	/// <summary>
	///                      変更案内明細ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   変更案内明細ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/11/12</br>
	/// <br>Genarated Date   :   2007/12/06  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
//	[Serializable]
//	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ChgGidncDtWork //: IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>配信案内 案内内容区分</summary>
		/// <remarks>0:共通,1:ﾌﾟﾛｸﾞﾗﾑ配信,2:ｻｰﾊﾞｰﾒﾝﾃﾅﾝｽ</remarks>
		private Int32 _mcastGidncCntntsCd;

		/// <summary>パッケージ区分</summary>
		private string _productCode = "";

		/// <summary>配信案内 バージョン区分</summary>
		private string _mcastGidncVersionCd = "";

		/// <summary>配信提供区分</summary>
		/// <remarks>0:標準,1:個別</remarks>
		private Int32 _mcastOfferDivCd;

		/// <summary>更新グループコード</summary>
		private string _updateGroupCode = "";

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>連番</summary>
		/// <remarks>案内区分、ﾊﾟｯｹｰｼﾞ区分、ﾊﾞｰｼﾞｮﾝ区分毎により1～連番採番</remarks>
		private Int32 _multicastConsNo;

		/// <summary>連番サブコード</summary>
		/// <remarks>案内区分、ﾊﾟｯｹｰｼﾞ区分、ﾊﾞｰｼﾞｮﾝ区分、連番毎により1～連番採番</remarks>
		private Int32 _multicastSubCode;

		/// <summary>変更内容</summary>
		/// <remarks>※１</remarks>
		private string _changeContents;

		/// <summary>別紙ファイル有無区分</summary>
		/// <remarks>0:無し,1:有り</remarks>
		private Int32 _anothersheetFileExst;

		/// <summary>別紙ファイル名</summary>
		private string _anothersheetFileName = "";


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

		/// public propaty name  :  McastGidncCntntsCd
		/// <summary>配信案内 案内内容区分プロパティ</summary>
		/// <value>0:共通,1:ﾌﾟﾛｸﾞﾗﾑ配信,2:ｻｰﾊﾞｰﾒﾝﾃﾅﾝｽ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   配信案内 案内内容区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 McastGidncCntntsCd
		{
			get{return _mcastGidncCntntsCd;}
			set{_mcastGidncCntntsCd = value;}
		}

		/// public propaty name  :  ProductCode
		/// <summary>パッケージ区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   パッケージ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ProductCode
		{
			get{return _productCode;}
			set{_productCode = value;}
		}

		/// public propaty name  :  McastGidncVersionCd
		/// <summary>配信案内 バージョン区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   配信案内 バージョン区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string McastGidncVersionCd
		{
			get{return _mcastGidncVersionCd;}
			set{_mcastGidncVersionCd = value;}
		}

		/// public propaty name  :  McastOfferDivCd
		/// <summary>配信提供区分プロパティ</summary>
		/// <value>0:標準,1:個別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   配信提供区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 McastOfferDivCd
		{
			get{return _mcastOfferDivCd;}
			set{_mcastOfferDivCd = value;}
		}

		/// public propaty name  :  UpdateGroupCode
		/// <summary>更新グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateGroupCode
		{
			get{return _updateGroupCode;}
			set{_updateGroupCode = value;}
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

		/// public propaty name  :  MulticastConsNo
		/// <summary>連番プロパティ</summary>
		/// <value>案内区分、ﾊﾟｯｹｰｼﾞ区分、ﾊﾞｰｼﾞｮﾝ区分毎により1～連番採番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MulticastConsNo
		{
			get{return _multicastConsNo;}
			set{_multicastConsNo = value;}
		}

		/// public propaty name  :  MulticastSubCode
		/// <summary>連番サブコードプロパティ</summary>
		/// <value>案内区分、ﾊﾟｯｹｰｼﾞ区分、ﾊﾞｰｼﾞｮﾝ区分、連番毎により1～連番採番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連番サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MulticastSubCode
		{
			get{return _multicastSubCode;}
			set{_multicastSubCode = value;}
		}

		/// public propaty name  :  ChangeContents
		/// <summary>変更内容プロパティ</summary>
		/// <value>※１</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更内容プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ChangeContents
		{
			get{return _changeContents;}
			set{_changeContents = value;}
		}

		/// public propaty name  :  AnothersheetFileExst
		/// <summary>別紙ファイル有無区分プロパティ</summary>
		/// <value>0:無し,1:有り</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   別紙ファイル有無区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnothersheetFileExst
		{
			get{return _anothersheetFileExst;}
			set{_anothersheetFileExst = value;}
		}

		/// public propaty name  :  AnothersheetFileName
		/// <summary>別紙ファイル名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   別紙ファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnothersheetFileName
		{
			get{return _anothersheetFileName;}
			set{_anothersheetFileName = value;}
		}



        /// public propaty name  :  McastGidncVersionCdZeroSup
        /// <summary>配信案内 バージョン区分(ゼロサプレス)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信案内 バージョン区分(ゼロサプレス)プロパティ</br>
        /// </remarks>
        public string McastGidncVersionCdZeroSup
        {
            get { return VersionStringConverter.ConvertToZeroSuppress( _mcastGidncVersionCd ); }
            set { _mcastGidncVersionCd = VersionStringConverter.ConvertToZeroPadding( value, 5 ); }
        }



		/// <summary>
		/// 変更案内明細ワークコンストラクタ
		/// </summary>
		/// <returns>ChgGidncDtWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChgGidncDtWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ChgGidncDtWork()
		{
		}





		/// <summary>
		/// 変更案内明細ワークコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="mcastGidncCntntsCd">配信案内 案内内容区分(0:共通,1:ﾌﾟﾛｸﾞﾗﾑ配信,2:ｻｰﾊﾞｰﾒﾝﾃﾅﾝｽ)</param>
		/// <param name="productCode">パッケージ区分</param>
		/// <param name="mcastGidncVersionCd">配信案内 バージョン区分</param>
		/// <param name="mcastOfferDivCd">配信提供区分(0:標準,1:個別)</param>
		/// <param name="updateGroupCode">更新グループコード</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="multicastConsNo">連番(案内区分、ﾊﾟｯｹｰｼﾞ区分、ﾊﾞｰｼﾞｮﾝ区分毎により1～連番採番)</param>
		/// <param name="multicastSubCode">連番サブコード(案内区分、ﾊﾟｯｹｰｼﾞ区分、ﾊﾞｰｼﾞｮﾝ区分、連番毎により1～連番採番)</param>
		/// <param name="changeContents">変更内容(※１)</param>
		/// <param name="anothersheetFileExst">別紙ファイル有無区分(0:無し,1:有り)</param>
		/// <param name="anothersheetFileName">別紙ファイル名</param>
        /// <returns>ChgGidncDtWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChgGidncDtWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public ChgGidncDtWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int32 mcastGidncCntntsCd, string productCode, string mcastGidncVersionCd, Int32 mcastOfferDivCd, string updateGroupCode, string enterpriseCode, Int32 multicastConsNo, Int32 multicastSubCode, string changeContents, Int32 anothersheetFileExst, string anothersheetFileName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this.LogicalDeleteCode = logicalDeleteCode;
			this.McastGidncCntntsCd = mcastGidncCntntsCd;
			this.ProductCode = productCode;
			this.McastGidncVersionCd = mcastGidncVersionCd;
			this.McastOfferDivCd = mcastOfferDivCd;
			this.UpdateGroupCode = updateGroupCode;
			this.EnterpriseCode = enterpriseCode;
			this.MulticastConsNo = multicastConsNo;
			this.MulticastSubCode = multicastSubCode;
			this.ChangeContents = changeContents;
			this.AnothersheetFileExst = anothersheetFileExst;
			this.AnothersheetFileName = anothersheetFileName;

		}

		/// <summary>
		/// 変更案内明細ワーク複製処理
		/// </summary>
		/// <returns>ChgGidncDtWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいChgGidncDtWorkクラスのインスタンスを返します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public ChgGidncDtWork Clone()
		{
    		return new ChgGidncDtWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._mcastGidncCntntsCd, this._productCode, this._mcastGidncVersionCd, this._mcastOfferDivCd, this._updateGroupCode, this._enterpriseCode, this._multicastConsNo, this._multicastSubCode, this._changeContents, this._anothersheetFileExst, this._anothersheetFileName);

        }

		/// <summary>
		/// 変更案内明細ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のChgGidncDtWorkクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChgGidncDtWorkクラスの内容が一致するか比較します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public bool Equals(ChgGidncDtWork target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.McastGidncCntntsCd == target.McastGidncCntntsCd)
				 && (this.ProductCode == target.ProductCode)
                 && (this.McastGidncVersionCd == target.McastGidncVersionCd)
				 && (this.McastOfferDivCd == target.McastOfferDivCd)
				 && (this.UpdateGroupCode == target.UpdateGroupCode)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.MulticastConsNo == target.MulticastConsNo)
				 && (this.MulticastSubCode == target.MulticastSubCode)
				 && (this.ChangeContents == target.ChangeContents)
				 && (this.AnothersheetFileExst == target.AnothersheetFileExst)
				 && (this.AnothersheetFileName == target.AnothersheetFileName));

		}

		/// <summary>
		/// 変更案内明細ワーク比較処理
		/// </summary>
		/// <param name="chgGidncDt1">比較するChgGidncDtWorkクラスのインスタンス</param>
		/// <param name="chgGidncDt2">比較するChgGidncDtWorkクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChgGidncDtWorkクラスの内容が一致するか比較します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public static bool Equals(ChgGidncDtWork chgGidncDt1, ChgGidncDtWork chgGidncDt2)
		{
			return ((chgGidncDt1.CreateDateTime == chgGidncDt2.CreateDateTime)
				 && (chgGidncDt1.UpdateDateTime == chgGidncDt2.UpdateDateTime)
				 && (chgGidncDt1.LogicalDeleteCode == chgGidncDt2.LogicalDeleteCode)
				 && (chgGidncDt1.McastGidncCntntsCd == chgGidncDt2.McastGidncCntntsCd)
				 && (chgGidncDt1.ProductCode == chgGidncDt2.ProductCode)
                 && (chgGidncDt1.McastGidncVersionCd == chgGidncDt2.McastGidncVersionCd)
				 && (chgGidncDt1.McastOfferDivCd == chgGidncDt2.McastOfferDivCd)
				 && (chgGidncDt1.UpdateGroupCode == chgGidncDt2.UpdateGroupCode)
				 && (chgGidncDt1.EnterpriseCode == chgGidncDt2.EnterpriseCode)
				 && (chgGidncDt1.MulticastConsNo == chgGidncDt2.MulticastConsNo)
				 && (chgGidncDt1.MulticastSubCode == chgGidncDt2.MulticastSubCode)
				 && (chgGidncDt1.ChangeContents == chgGidncDt2.ChangeContents)
				 && (chgGidncDt1.AnothersheetFileExst == chgGidncDt2.AnothersheetFileExst)
				 && (chgGidncDt1.AnothersheetFileName == chgGidncDt2.AnothersheetFileName));

		}
		/// <summary>
		/// 変更案内明細ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のChgGidncDtWorkクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChgGidncDtWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ChgGidncDtWork target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.McastGidncCntntsCd != target.McastGidncCntntsCd)resList.Add("McastGidncCntntsCd");
			if(this.ProductCode != target.ProductCode)resList.Add("ProductCode");
            if(this.McastGidncVersionCd != target.McastGidncVersionCd)resList.Add("McastGidncVersionCd");
			if(this.McastOfferDivCd != target.McastOfferDivCd)resList.Add("McastOfferDivCd");
			if(this.UpdateGroupCode != target.UpdateGroupCode)resList.Add("UpdateGroupCode");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.MulticastConsNo != target.MulticastConsNo)resList.Add("MulticastConsNo");
			if(this.MulticastSubCode != target.MulticastSubCode)resList.Add("MulticastSubCode");
			if(this.ChangeContents != target.ChangeContents)resList.Add("ChangeContents");
			if(this.AnothersheetFileExst != target.AnothersheetFileExst)resList.Add("AnothersheetFileExst");
			if(this.AnothersheetFileName != target.AnothersheetFileName)resList.Add("AnothersheetFileName");

			return resList;
		}

		/// <summary>
		/// 変更案内明細ワーク比較処理
		/// </summary>
		/// <param name="chgGidncDt1">比較するChgGidncDtWorkクラスのインスタンス</param>
		/// <param name="chgGidncDt2">比較するChgGidncDtWorkクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChgGidncDtWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ChgGidncDtWork chgGidncDt1, ChgGidncDtWork chgGidncDt2)
		{
			ArrayList resList = new ArrayList();
			if(chgGidncDt1.CreateDateTime != chgGidncDt2.CreateDateTime)resList.Add("CreateDateTime");
			if(chgGidncDt1.UpdateDateTime != chgGidncDt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(chgGidncDt1.LogicalDeleteCode != chgGidncDt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(chgGidncDt1.McastGidncCntntsCd != chgGidncDt2.McastGidncCntntsCd)resList.Add("McastGidncCntntsCd");
			if(chgGidncDt1.ProductCode != chgGidncDt2.ProductCode)resList.Add("ProductCode");
            if(chgGidncDt1.McastGidncVersionCd != chgGidncDt2.McastGidncVersionCd)resList.Add("McastGidncVersionCd");
			if(chgGidncDt1.McastOfferDivCd != chgGidncDt2.McastOfferDivCd)resList.Add("McastOfferDivCd");
			if(chgGidncDt1.UpdateGroupCode != chgGidncDt2.UpdateGroupCode)resList.Add("UpdateGroupCode");
			if(chgGidncDt1.EnterpriseCode != chgGidncDt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(chgGidncDt1.MulticastConsNo != chgGidncDt2.MulticastConsNo)resList.Add("MulticastConsNo");
			if(chgGidncDt1.MulticastSubCode != chgGidncDt2.MulticastSubCode)resList.Add("MulticastSubCode");
			if(chgGidncDt1.ChangeContents != chgGidncDt2.ChangeContents)resList.Add("ChangeContents");
			if(chgGidncDt1.AnothersheetFileExst != chgGidncDt2.AnothersheetFileExst)resList.Add("AnothersheetFileExst");
			if(chgGidncDt1.AnothersheetFileName != chgGidncDt2.AnothersheetFileName)resList.Add("AnothersheetFileName");

			return resList;
		}

    
    }

}
