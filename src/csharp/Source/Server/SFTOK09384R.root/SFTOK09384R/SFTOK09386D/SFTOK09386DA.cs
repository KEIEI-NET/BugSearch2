using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   EmployeeWork
	/// <summary>
	///                      従業員ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   従業員ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/17</br>
	/// <br>Genarated Date   :   2008/05/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2012.05.29 30182 立谷　亮介</br>
	/// <br>                 :    「売上伝票入力起動枚数」「得意先電子元帳起動枚数」項目追加</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class EmployeeWork : IFileHeader
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

		/// <summary>従業員コード</summary>
		private string _employeeCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>短縮名称</summary>
		private string _shortName = "";

		/// <summary>性別コード</summary>
		/// <remarks>0:男,1:女,2:不明</remarks>
		private Int32 _sexCode;

		/// <summary>性別名称</summary>
		/// <remarks>全角で管理</remarks>
		private string _sexName = "";

		/// <summary>生年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _birthday;

		/// <summary>電話番号（会社）</summary>
		private string _companyTelNo = "";

		/// <summary>電話番号（携帯）</summary>
		private string _portableTelNo = "";

		/// <summary>役職コード</summary>
		private Int32 _postCode;

		/// <summary>業務区分</summary>
		private Int32 _businessCode;

		/// <summary>受付・メカ区分</summary>
		/// <remarks>0:受付,1:メカ,2:営業</remarks>
		private Int32 _frontMechaCode;

		/// <summary>社内外区分</summary>
		/// <remarks>0:社内,1:社外</remarks>
		private Int32 _inOutsideCompanyCode;

		/// <summary>所属拠点コード</summary>
		private string _belongSectionCode = "";

		/// <summary>レバレート原価（一般）</summary>
		private Int64 _lvrRtCstGeneral;

		/// <summary>レバレート原価（車検）</summary>
		private Int64 _lvrRtCstCarInspect;

		/// <summary>レバレート原価（塗装）</summary>
		private Int64 _lvrRtCstBodyPaint;

		/// <summary>レバレート原価（鈑金）</summary>
		private Int64 _lvrRtCstBodyRepair;

		/// <summary>ログインID</summary>
		private string _loginId = "";

		/// <summary>ログインパスワード</summary>
		private string _loginPassword = "";

		/// <summary>ユーザー管理者フラグ</summary>
		/// <remarks>0:一般,1:ユーザー管理者</remarks>
		private Int32 _userAdminFlag;

		/// <summary>入社日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _enterCompanyDate;

		/// <summary>退職日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _retirementDate;

		/// <summary>権限レベル1</summary>
		/// <remarks>80:店長 70:店頭販売員(正社員) 60:店頭販売員(アルバイト) 40:バックヤード担当者 20:事務</remarks>
		private Int32 _authorityLevel1;

		/// <summary>権限レベル2</summary>
		/// <remarks>50:正社員 10:アルバイト</remarks>
		private Int32 _authorityLevel2;

		// -- Add St 2012.05.29 30182 R.Tachiya --
		/// <summary>売上伝票入力起動枚数</summary>
		private Int32 _salSlipInpBootCnt;

		/// <summary>得意先電子元帳起動枚数</summary>
		private Int32 _custLedgerBootCnt;
		// -- Add Ed 2012.05.29 30182 R.Tachiya --


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

		/// public propaty name  :  EmployeeCode
		/// <summary>従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Kana
		/// <summary>カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Kana
		{
			get{return _kana;}
			set{_kana = value;}
		}

		/// public propaty name  :  ShortName
		/// <summary>短縮名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   短縮名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShortName
		{
			get{return _shortName;}
			set{_shortName = value;}
		}

		/// public propaty name  :  SexCode
		/// <summary>性別コードプロパティ</summary>
		/// <value>0:男,1:女,2:不明</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   性別コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SexCode
		{
			get{return _sexCode;}
			set{_sexCode = value;}
		}

		/// public propaty name  :  SexName
		/// <summary>性別名称プロパティ</summary>
		/// <value>全角で管理</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   性別名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SexName
		{
			get{return _sexName;}
			set{_sexName = value;}
		}

		/// public propaty name  :  Birthday
		/// <summary>生年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Birthday
		{
			get{return _birthday;}
			set{_birthday = value;}
		}

		/// public propaty name  :  CompanyTelNo
		/// <summary>電話番号（会社）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（会社）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CompanyTelNo
		{
			get{return _companyTelNo;}
			set{_companyTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>電話番号（携帯）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（携帯）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  PostCode
		/// <summary>役職コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   役職コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PostCode
		{
			get{return _postCode;}
			set{_postCode = value;}
		}

		/// public propaty name  :  BusinessCode
		/// <summary>業務区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業務区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BusinessCode
		{
			get{return _businessCode;}
			set{_businessCode = value;}
		}

		/// public propaty name  :  FrontMechaCode
		/// <summary>受付・メカ区分プロパティ</summary>
		/// <value>0:受付,1:メカ,2:営業</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付・メカ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FrontMechaCode
		{
			get{return _frontMechaCode;}
			set{_frontMechaCode = value;}
		}

		/// public propaty name  :  InOutsideCompanyCode
		/// <summary>社内外区分プロパティ</summary>
		/// <value>0:社内,1:社外</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内外区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InOutsideCompanyCode
		{
			get{return _inOutsideCompanyCode;}
			set{_inOutsideCompanyCode = value;}
		}

		/// public propaty name  :  BelongSectionCode
		/// <summary>所属拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BelongSectionCode
		{
			get{return _belongSectionCode;}
			set{_belongSectionCode = value;}
		}

		/// public propaty name  :  LvrRtCstGeneral
		/// <summary>レバレート原価（一般）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（一般）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstGeneral
		{
			get{return _lvrRtCstGeneral;}
			set{_lvrRtCstGeneral = value;}
		}

		/// public propaty name  :  LvrRtCstCarInspect
		/// <summary>レバレート原価（車検）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（車検）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstCarInspect
		{
			get{return _lvrRtCstCarInspect;}
			set{_lvrRtCstCarInspect = value;}
		}

		/// public propaty name  :  LvrRtCstBodyPaint
		/// <summary>レバレート原価（塗装）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（塗装）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstBodyPaint
		{
			get{return _lvrRtCstBodyPaint;}
			set{_lvrRtCstBodyPaint = value;}
		}

		/// public propaty name  :  LvrRtCstBodyRepair
		/// <summary>レバレート原価（鈑金）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レバレート原価（鈑金）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 LvrRtCstBodyRepair
		{
			get{return _lvrRtCstBodyRepair;}
			set{_lvrRtCstBodyRepair = value;}
		}

		/// public propaty name  :  LoginId
		/// <summary>ログインIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログインIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LoginId
		{
			get{return _loginId;}
			set{_loginId = value;}
		}

		/// public propaty name  :  LoginPassword
		/// <summary>ログインパスワードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログインパスワードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LoginPassword
		{
			get{return _loginPassword;}
			set{_loginPassword = value;}
		}

		/// public propaty name  :  UserAdminFlag
		/// <summary>ユーザー管理者フラグプロパティ</summary>
		/// <value>0:一般,1:ユーザー管理者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー管理者フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UserAdminFlag
		{
			get{return _userAdminFlag;}
			set{_userAdminFlag = value;}
		}

		/// public propaty name  :  EnterCompanyDate
		/// <summary>入社日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EnterCompanyDate
		{
			get{return _enterCompanyDate;}
			set{_enterCompanyDate = value;}
		}

		/// public propaty name  :  RetirementDate
		/// <summary>退職日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime RetirementDate
		{
			get{return _retirementDate;}
			set{_retirementDate = value;}
		}

		/// public propaty name  :  AuthorityLevel1
		/// <summary>権限レベル1プロパティ</summary>
		/// <value>80:店長 70:店頭販売員(正社員) 60:店頭販売員(アルバイト) 40:バックヤード担当者 20:事務</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   権限レベル1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AuthorityLevel1
		{
			get{return _authorityLevel1;}
			set{_authorityLevel1 = value;}
		}

		/// public propaty name  :  AuthorityLevel2
		/// <summary>権限レベル2プロパティ</summary>
		/// <value>50:正社員 10:アルバイト</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   権限レベル2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AuthorityLevel2
		{
			get{return _authorityLevel2;}
			set{_authorityLevel2 = value;}
		}

		// -- Add St 2012.05.29 30182 R.Tachiya --
		/// public propaty name  :  SalSlipInpBootCnt
		/// <summary>売上伝票入力起動枚数</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票入力起動枚数プロパティ</br>
		/// <br>Programer        :   30182 立谷　亮介</br>
		/// </remarks>
		public Int32 SalSlipInpBootCnt
		{
			get { return _salSlipInpBootCnt; }
			set { _salSlipInpBootCnt = value; }
		}

		/// public propaty name  :  CustLedgerBootCnt
		/// <summary>得意先電子元帳起動枚数</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先電子元帳起動枚数プロパティ</br>
		/// <br>Programer        :   30182 立谷　亮介</br>
		/// </remarks>
		public Int32 CustLedgerBootCnt
		{
			get { return _custLedgerBootCnt; }
			set { _custLedgerBootCnt = value; }
		}
		// -- Add Ed 2012.05.29 30182 R.Tachiya --


		/// <summary>
		/// 従業員ワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EmployeeWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EmployeeWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EmployeeWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EmployeeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EmployeeWork || graph is ArrayList || graph is EmployeeWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(EmployeeWork).FullName));

            if (graph != null && graph is EmployeeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EmployeeWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EmployeeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EmployeeWork[])graph).Length;
            }
            else if (graph is EmployeeWork)
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
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //カナ
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //短縮名称
            serInfo.MemberInfo.Add(typeof(string)); //ShortName
            //性別コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SexCode
            //性別名称
            serInfo.MemberInfo.Add(typeof(string)); //SexName
            //生年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //Birthday
            //電話番号（会社）
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo
            //電話番号（携帯）
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //役職コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PostCode
            //業務区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessCode
            //受付・メカ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FrontMechaCode
            //社内外区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InOutsideCompanyCode
            //所属拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            //レバレート原価（一般）
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstGeneral
            //レバレート原価（車検）
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstCarInspect
            //レバレート原価（塗装）
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstBodyPaint
            //レバレート原価（鈑金）
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstBodyRepair
            //ログインID
            serInfo.MemberInfo.Add(typeof(string)); //LoginId
            //ログインパスワード
            serInfo.MemberInfo.Add(typeof(string)); //LoginPassword
            //ユーザー管理者フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //UserAdminFlag
            //入社日
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterCompanyDate
            //退職日
            serInfo.MemberInfo.Add(typeof(Int32)); //RetirementDate
            //権限レベル1
            serInfo.MemberInfo.Add(typeof(Int32)); //AuthorityLevel1
            //権限レベル2
            serInfo.MemberInfo.Add(typeof(Int32)); //AuthorityLevel2
			// -- Add St 2012.05.29 30182 R.Tachiya --
			//売上伝票入力起動枚数
			serInfo.MemberInfo.Add(typeof(Int32)); //SalSlipInpBootCnt
			//得意先電子元帳起動枚数
			serInfo.MemberInfo.Add(typeof(Int32)); //CustLedgerBootCnt
			// -- Add Ed 2012.05.29 30182 R.Tachiya --


            serInfo.Serialize(writer, serInfo);
            if (graph is EmployeeWork)
            {
                EmployeeWork temp = (EmployeeWork)graph;

                SetEmployeeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EmployeeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EmployeeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EmployeeWork temp in lst)
                {
                    SetEmployeeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EmployeeWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 35;// -- Add 2012.05.29 30182 R.Tachiya --
		//private const int currentMemberCount = 33;// -- Del 2012.05.29 30182 R.Tachiya --

        /// <summary>
        ///  EmployeeWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEmployeeWork(System.IO.BinaryWriter writer, EmployeeWork temp)
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
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //名称
            writer.Write(temp.Name);
            //カナ
            writer.Write(temp.Kana);
            //短縮名称
            writer.Write(temp.ShortName);
            //性別コード
            writer.Write(temp.SexCode);
            //性別名称
            writer.Write(temp.SexName);
            //生年月日
            writer.Write((Int64)temp.Birthday.Ticks);
            //電話番号（会社）
            writer.Write(temp.CompanyTelNo);
            //電話番号（携帯）
            writer.Write(temp.PortableTelNo);
            //役職コード
            writer.Write(temp.PostCode);
            //業務区分
            writer.Write(temp.BusinessCode);
            //受付・メカ区分
            writer.Write(temp.FrontMechaCode);
            //社内外区分
            writer.Write(temp.InOutsideCompanyCode);
            //所属拠点コード
            writer.Write(temp.BelongSectionCode);
            //レバレート原価（一般）
            writer.Write(temp.LvrRtCstGeneral);
            //レバレート原価（車検）
            writer.Write(temp.LvrRtCstCarInspect);
            //レバレート原価（塗装）
            writer.Write(temp.LvrRtCstBodyPaint);
            //レバレート原価（鈑金）
            writer.Write(temp.LvrRtCstBodyRepair);
            //ログインID
            writer.Write(temp.LoginId);
            //ログインパスワード
            writer.Write(temp.LoginPassword);
            //ユーザー管理者フラグ
            writer.Write(temp.UserAdminFlag);
            //入社日
            writer.Write((Int64)temp.EnterCompanyDate.Ticks);
            //退職日
            writer.Write((Int64)temp.RetirementDate.Ticks);
            //権限レベル1
            writer.Write(temp.AuthorityLevel1);
            //権限レベル2
            writer.Write(temp.AuthorityLevel2);
			// -- Add St 2012.05.29 30182 R.Tachiya --
			//売上伝票入力起動枚数
			writer.Write(temp.SalSlipInpBootCnt);
			//得意先元帳起動枚数
			writer.Write(temp.CustLedgerBootCnt);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

        }

        /// <summary>
        ///  EmployeeWorkインスタンス取得
        /// </summary>
        /// <returns>EmployeeWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private EmployeeWork GetEmployeeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EmployeeWork temp = new EmployeeWork();

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
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //カナ
            temp.Kana = reader.ReadString();
            //短縮名称
            temp.ShortName = reader.ReadString();
            //性別コード
            temp.SexCode = reader.ReadInt32();
            //性別名称
            temp.SexName = reader.ReadString();
            //生年月日
            temp.Birthday = new DateTime(reader.ReadInt64());
            //電話番号（会社）
            temp.CompanyTelNo = reader.ReadString();
            //電話番号（携帯）
            temp.PortableTelNo = reader.ReadString();
            //役職コード
            temp.PostCode = reader.ReadInt32();
            //業務区分
            temp.BusinessCode = reader.ReadInt32();
            //受付・メカ区分
            temp.FrontMechaCode = reader.ReadInt32();
            //社内外区分
            temp.InOutsideCompanyCode = reader.ReadInt32();
            //所属拠点コード
            temp.BelongSectionCode = reader.ReadString();
            //レバレート原価（一般）
            temp.LvrRtCstGeneral = reader.ReadInt64();
            //レバレート原価（車検）
            temp.LvrRtCstCarInspect = reader.ReadInt64();
            //レバレート原価（塗装）
            temp.LvrRtCstBodyPaint = reader.ReadInt64();
            //レバレート原価（鈑金）
            temp.LvrRtCstBodyRepair = reader.ReadInt64();
            //ログインID
            temp.LoginId = reader.ReadString();
            //ログインパスワード
            temp.LoginPassword = reader.ReadString();
            //ユーザー管理者フラグ
            temp.UserAdminFlag = reader.ReadInt32();
            //入社日
            temp.EnterCompanyDate = new DateTime(reader.ReadInt64());
            //退職日
            temp.RetirementDate = new DateTime(reader.ReadInt64());
            //権限レベル1
            temp.AuthorityLevel1 = reader.ReadInt32();
            //権限レベル2
            temp.AuthorityLevel2 = reader.ReadInt32();
			// -- Add St 2012.05.29 30182 R.Tachiya --
			//売上伝票入力起動枚数
			temp.SalSlipInpBootCnt = reader.ReadInt32();
			//得意先元帳起動枚数
			temp.CustLedgerBootCnt = reader.ReadInt32();
			// -- Add Ed 2012.05.29 30182 R.Tachiya --


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
        /// <returns>EmployeeWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EmployeeWork temp = GetEmployeeWork(reader, serInfo);
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
                    retValue = (EmployeeWork[])lst.ToArray(typeof(EmployeeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
