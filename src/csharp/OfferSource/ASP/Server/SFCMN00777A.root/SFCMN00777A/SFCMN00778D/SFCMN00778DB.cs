using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ChangGidncWork
	/// <summary>
	///                      変更案内ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   変更案内ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/11/12</br>
	/// <br>Genarated Date   :   2007/12/06  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
//	[Serializable]
//	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ChangGidncWork //: IFileHeader
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
		/// <remarks>案内区分、パッケージ区分、バージョン区分毎により1～連番採番</remarks>
		private Int32 _multicastConsNo;

		/// <summary>配信日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _multicastDate;

		/// <summary>サポート公開日時</summary>
		/// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
		private Int64 _supportOpenTime;

		/// <summary>ユーザー公開日時</summary>
		/// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
		private Int64 _customerOpenTime;

		/// <summary>メンテナンス予定日時　開始</summary>
		/// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
		private Int64 _serverMainteStScdl;

		/// <summary>メンテナンス予定日時　終了</summary>
		/// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
		private Int64 _serverMainteEdScdl;

		/// <summary>メンテナンス日時　開始</summary>
		/// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
		private Int64 _serverMainteStTime;

		/// <summary>メンテナンス日時　終了</summary>
		/// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
		private Int64 _serverMainteEdTime;

		/// <summary>配信案内 新規・改良区分</summary>
		/// <remarks>1:新規,2:改良,3:障害</remarks>
		private Int32 _mcastGidncNewCustmCd;

		/// <summary>配信案内 メンテ区分</summary>
		/// <remarks>1:定期ﾒﾝﾃ,2:ﾃﾞｰﾀﾒﾝﾃ,9:緊急ﾒﾝﾃ</remarks>
		private Int32 _mcastGidncMainteCd;

		/// <summary>システム区分</summary>
		/// <remarks>0:共通,1:SF,2:BK,3:SH</remarks>
		private Int32 _systemDivCd;

		/// <summary>案内文1</summary>
		private string _guidance1 = "";

		/// <summary>地域</summary>
		private string _area = "";


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
		/// <value>案内区分、パッケージ区分、バージョン区分毎により1～連番採番</value>
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

		/// public propaty name  :  MulticastDate
		/// <summary>配信日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   配信日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime MulticastDate
		{
			get{return _multicastDate;}
			set{_multicastDate = value;}
		}

		/// public propaty name  :  SupportOpenTime
		/// <summary>サポート公開日時プロパティ</summary>
		/// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   サポート公開日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SupportOpenTime
		{
			get{return _supportOpenTime;}
			set{_supportOpenTime = value;}
		}

		/// public propaty name  :  CustomerOpenTime
		/// <summary>ユーザー公開日時プロパティ</summary>
		/// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー公開日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 CustomerOpenTime
		{
			get{return _customerOpenTime;}
			set{_customerOpenTime = value;}
		}

		/// public propaty name  :  ServerMainteStScdl
		/// <summary>メンテナンス予定日時　開始プロパティ</summary>
		/// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メンテナンス予定日時　開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ServerMainteStScdl
		{
			get{return _serverMainteStScdl;}
			set{_serverMainteStScdl = value;}
		}

		/// public propaty name  :  ServerMainteEdScdl
		/// <summary>メンテナンス予定日時　終了プロパティ</summary>
		/// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メンテナンス予定日時　終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ServerMainteEdScdl
		{
			get{return _serverMainteEdScdl;}
			set{_serverMainteEdScdl = value;}
		}

		/// public propaty name  :  ServerMainteStTime
		/// <summary>メンテナンス日時　開始プロパティ</summary>
		/// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メンテナンス日時　開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ServerMainteStTime
		{
			get{return _serverMainteStTime;}
			set{_serverMainteStTime = value;}
		}

		/// public propaty name  :  ServerMainteEdTime
		/// <summary>メンテナンス日時　終了プロパティ</summary>
		/// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メンテナンス日時　終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ServerMainteEdTime
		{
			get{return _serverMainteEdTime;}
			set{_serverMainteEdTime = value;}
		}

		/// public propaty name  :  McastGidncNewCustmCd
		/// <summary>配信案内 新規・改良区分プロパティ</summary>
		/// <value>1:新規,2:改良,3:障害</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   配信案内 新規・改良区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 McastGidncNewCustmCd
		{
			get{return _mcastGidncNewCustmCd;}
			set{_mcastGidncNewCustmCd = value;}
		}

		/// public propaty name  :  McastGidncMainteCd
		/// <summary>配信案内 メンテ区分プロパティ</summary>
		/// <value>1:定期ﾒﾝﾃ,2:ﾃﾞｰﾀﾒﾝﾃ,9:緊急ﾒﾝﾃ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   配信案内 メンテ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 McastGidncMainteCd
		{
			get{return _mcastGidncMainteCd;}
			set{_mcastGidncMainteCd = value;}
		}

		/// public propaty name  :  SystemDivCd
		/// <summary>システム区分プロパティ</summary>
		/// <value>0:共通,1:SF,2:BK,3:SH</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   システム区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
		}

		/// public propaty name  :  Guidance1
		/// <summary>案内文1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   案内文1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Guidance1
		{
			get{return _guidance1;}
			set{_guidance1 = value;}
		}

		/// public propaty name  :  Area
		/// <summary>地域プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   地域プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Area
		{
			get{return _area;}
			set{_area = value;}
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
		/// 変更案内ワークコンストラクタ
		/// </summary>
		/// <returns>ChangGidncWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChangGidncWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ChangGidncWork()
		{
		}






		/// <summary>
		/// 変更案内ワークコンストラクタ
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
		/// <param name="multicastConsNo">連番(案内区分、パッケージ区分、バージョン区分毎により1～連番採番)</param>
		/// <param name="multicastDate">配信日(YYYYMMDD)</param>
		/// <param name="supportOpenTime">サポート公開日時(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="customerOpenTime">ユーザー公開日時(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteStScdl">メンテナンス予定日時　開始(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteEdScdl">メンテナンス予定日時　終了(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteStTime">メンテナンス日時　開始(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteEdTime">メンテナンス日時　終了(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="mcastGidncNewCustmCd">配信案内 新規・改良区分(1:新規,2:改良,3:障害)</param>
		/// <param name="mcastGidncMainteCd">配信案内 メンテ区分(1:定期ﾒﾝﾃ,2:ﾃﾞｰﾀﾒﾝﾃ,9:緊急ﾒﾝﾃ)</param>
		/// <param name="systemDivCd">システム区分(0:共通,1:SF,2:BK,3:SH)</param>
		/// <param name="guidance1">案内文1</param>
		/// <param name="area">地域</param>
        /// <returns>ChangGidncWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChangGidncWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public ChangGidncWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int32 mcastGidncCntntsCd, string productCode, string mcastGidncVersionCd, Int32 mcastOfferDivCd, string updateGroupCode, string enterpriseCode, Int32 multicastConsNo, DateTime multicastDate, Int64 supportOpenTime, Int64 customerOpenTime, Int64 serverMainteStScdl, Int64 serverMainteEdScdl, Int64 serverMainteStTime, Int64 serverMainteEdTime, Int32 mcastGidncNewCustmCd, Int32 mcastGidncMainteCd, Int32 systemDivCd, string guidance1, string area)
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
			this.MulticastDate = multicastDate; 
			this.SupportOpenTime = supportOpenTime; 
			this.CustomerOpenTime = customerOpenTime; 
			this.ServerMainteStScdl = serverMainteStScdl; 
			this.ServerMainteEdScdl = serverMainteEdScdl; 
			this.ServerMainteStTime = serverMainteStTime; 
			this.ServerMainteEdTime = serverMainteEdTime; 
			this.McastGidncNewCustmCd = mcastGidncNewCustmCd; 
			this.McastGidncMainteCd = mcastGidncMainteCd; 
			this.SystemDivCd = systemDivCd; 
			this.Guidance1 = guidance1; 
			this.Area = area; 

		}

		/// <summary>
		/// 変更案内ワーク複製処理
		/// </summary>
		/// <returns>ChangGidncWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいChangGidncWorkクラスのインスタンスを返します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public ChangGidncWork Clone()
		{
			return new ChangGidncWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._mcastGidncCntntsCd, this._productCode, this._mcastGidncVersionCd, this._mcastOfferDivCd, this._updateGroupCode, this._enterpriseCode, this._multicastConsNo, this._multicastDate, this._supportOpenTime, this._customerOpenTime, this._serverMainteStScdl, this._serverMainteEdScdl, this._serverMainteStTime, this._serverMainteEdTime, this._mcastGidncNewCustmCd, this._mcastGidncMainteCd, this._systemDivCd, this._guidance1, this._area);
        }

		/// <summary>
		/// 変更案内ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のChangGidncWorkクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChangGidncWorkクラスの内容が一致するか比較します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public bool Equals(ChangGidncWork target)
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
	    		 && (this.MulticastDate == target.MulticastDate)
	    		 && (this.SupportOpenTime == target.SupportOpenTime)
	    		 && (this.CustomerOpenTime == target.CustomerOpenTime)
	    		 && (this.ServerMainteStScdl == target.ServerMainteStScdl)
	    		 && (this.ServerMainteEdScdl == target.ServerMainteEdScdl)
	    		 && (this.ServerMainteStTime == target.ServerMainteStTime)
	    		 && (this.ServerMainteEdTime == target.ServerMainteEdTime)
	    		 && (this.McastGidncNewCustmCd == target.McastGidncNewCustmCd)
	    		 && (this.McastGidncMainteCd == target.McastGidncMainteCd)
	    		 && (this.SystemDivCd == target.SystemDivCd)
	    		 && (this.Guidance1 == target.Guidance1)
	    		 && (this.Area == target.Area)); 
        
        }

		/// <summary>
		/// 変更案内ワーク比較処理
		/// </summary>
		/// <param name="ChangGidnc1">比較するChangGidncWorkクラスのインスタンス</param>
		/// <param name="ChangGidnc2">比較するChangGidncWorkクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChangGidncWorkクラスの内容が一致するか比較します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public static bool Equals(ChangGidncWork ChangGidnc1, ChangGidncWork ChangGidnc2)
		{
			return ((ChangGidnc1.CreateDateTime == ChangGidnc2.CreateDateTime)
    			 && (ChangGidnc1.UpdateDateTime == ChangGidnc2.UpdateDateTime)
	    		 && (ChangGidnc1.LogicalDeleteCode == ChangGidnc2.LogicalDeleteCode)
	    		 && (ChangGidnc1.McastGidncCntntsCd == ChangGidnc2.McastGidncCntntsCd)
	    		 && (ChangGidnc1.ProductCode == ChangGidnc2.ProductCode)
	    		 && (ChangGidnc1.McastGidncVersionCd == ChangGidnc2.McastGidncVersionCd)
	    		 && (ChangGidnc1.McastOfferDivCd == ChangGidnc2.McastOfferDivCd)
	    		 && (ChangGidnc1.UpdateGroupCode == ChangGidnc2.UpdateGroupCode)
	    		 && (ChangGidnc1.EnterpriseCode == ChangGidnc2.EnterpriseCode)
	    		 && (ChangGidnc1.MulticastConsNo == ChangGidnc2.MulticastConsNo)
	    		 && (ChangGidnc1.MulticastDate == ChangGidnc2.MulticastDate)
	    		 && (ChangGidnc1.SupportOpenTime == ChangGidnc2.SupportOpenTime)
	    		 && (ChangGidnc1.CustomerOpenTime == ChangGidnc2.CustomerOpenTime)
	    		 && (ChangGidnc1.ServerMainteStScdl == ChangGidnc2.ServerMainteStScdl)
	    		 && (ChangGidnc1.ServerMainteEdScdl == ChangGidnc2.ServerMainteEdScdl)
	    		 && (ChangGidnc1.ServerMainteStTime == ChangGidnc2.ServerMainteStTime)
	    		 && (ChangGidnc1.ServerMainteEdTime == ChangGidnc2.ServerMainteEdTime)
	    		 && (ChangGidnc1.McastGidncNewCustmCd == ChangGidnc2.McastGidncNewCustmCd)
	    		 && (ChangGidnc1.McastGidncMainteCd == ChangGidnc2.McastGidncMainteCd)
	    		 && (ChangGidnc1.SystemDivCd == ChangGidnc2.SystemDivCd)
	    		 && (ChangGidnc1.Guidance1 == ChangGidnc2.Guidance1)
	    		 && (ChangGidnc1.Area == ChangGidnc2.Area)); 

		}

        /// <summary>
		/// 変更案内ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のChangGidncWorkクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChangGidncWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ChangGidncWork target)
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
	    	if(this.MulticastDate != target.MulticastDate)resList.Add("MulticastDate");
	    	if(this.SupportOpenTime != target.SupportOpenTime)resList.Add("SupportOpenTime");
	    	if(this.CustomerOpenTime != target.CustomerOpenTime)resList.Add("CustomerOpenTime");
	    	if(this.ServerMainteStScdl != target.ServerMainteStScdl)resList.Add("ServerMainteStScdl");
	    	if(this.ServerMainteEdScdl != target.ServerMainteEdScdl)resList.Add("ServerMainteEdScdl");
	    	if(this.ServerMainteStTime != target.ServerMainteStTime)resList.Add("ServerMainteStTime");
	    	if(this.ServerMainteEdTime != target.ServerMainteEdTime)resList.Add("ServerMainteEdTime");
	    	if(this.McastGidncNewCustmCd != target.McastGidncNewCustmCd)resList.Add("McastGidncNewCustmCd");
	    	if(this.McastGidncMainteCd != target.McastGidncMainteCd)resList.Add("McastGidncMainteCd");
	    	if(this.SystemDivCd != target.SystemDivCd)resList.Add("SystemDivCd");
	    	if(this.Guidance1 != target.Guidance1)resList.Add("Guidance1");
	    	if(this.Area != target.Area)resList.Add("Area");

			return resList;
		}

		/// <summary>
		/// 変更案内ワーク比較処理
		/// </summary>
		/// <param name="changGidnc1">比較するChangGidncWorkクラスのインスタンス</param>
		/// <param name="changGidnc2">比較するChangGidncWorkクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ChangGidncWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ChangGidncWork ChangGidnc1, ChangGidncWork ChangGidnc2)
		{
			ArrayList resList = new ArrayList();
			if(ChangGidnc1.CreateDateTime != ChangGidnc2.CreateDateTime)resList.Add("CreateDateTime");
    		if(ChangGidnc1.UpdateDateTime != ChangGidnc2.UpdateDateTime)resList.Add("UpdateDateTime");
	    	if(ChangGidnc1.LogicalDeleteCode != ChangGidnc2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
	    	if(ChangGidnc1.McastGidncCntntsCd != ChangGidnc2.McastGidncCntntsCd)resList.Add("McastGidncCntntsCd");
	    	if(ChangGidnc1.ProductCode != ChangGidnc2.ProductCode)resList.Add("ProductCode");
	    	if(ChangGidnc1.McastGidncVersionCd != ChangGidnc2.McastGidncVersionCd)resList.Add("McastGidncVersionCd");
	    	if(ChangGidnc1.McastOfferDivCd != ChangGidnc2.McastOfferDivCd)resList.Add("McastOfferDivCd");
	    	if(ChangGidnc1.UpdateGroupCode != ChangGidnc2.UpdateGroupCode)resList.Add("UpdateGroupCode");
	    	if(ChangGidnc1.EnterpriseCode != ChangGidnc2.EnterpriseCode)resList.Add("EnterpriseCode");
	    	if(ChangGidnc1.MulticastConsNo != ChangGidnc2.MulticastConsNo)resList.Add("MulticastConsNo");
	    	if(ChangGidnc1.MulticastDate != ChangGidnc2.MulticastDate)resList.Add("MulticastDate");
	    	if(ChangGidnc1.SupportOpenTime != ChangGidnc2.SupportOpenTime)resList.Add("SupportOpenTime");
	    	if(ChangGidnc1.CustomerOpenTime != ChangGidnc2.CustomerOpenTime)resList.Add("CustomerOpenTime");
	    	if(ChangGidnc1.ServerMainteStScdl != ChangGidnc2.ServerMainteStScdl)resList.Add("ServerMainteStScdl");
	    	if(ChangGidnc1.ServerMainteEdScdl != ChangGidnc2.ServerMainteEdScdl)resList.Add("ServerMainteEdScdl");
	    	if(ChangGidnc1.ServerMainteStTime != ChangGidnc2.ServerMainteStTime)resList.Add("ServerMainteStTime");
	    	if(ChangGidnc1.ServerMainteEdTime != ChangGidnc2.ServerMainteEdTime)resList.Add("ServerMainteEdTime");
	    	if(ChangGidnc1.McastGidncNewCustmCd != ChangGidnc2.McastGidncNewCustmCd)resList.Add("McastGidncNewCustmCd");
	    	if(ChangGidnc1.McastGidncMainteCd != ChangGidnc2.McastGidncMainteCd)resList.Add("McastGidncMainteCd");
	    	if(ChangGidnc1.SystemDivCd != ChangGidnc2.SystemDivCd)resList.Add("SystemDivCd");
	    	if(ChangGidnc1.Guidance1 != ChangGidnc2.Guidance1)resList.Add("Guidance1");
	    	if(ChangGidnc1.Area != ChangGidnc2.Area)resList.Add("Area");

			return resList;
		}

    
    }

}
