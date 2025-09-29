using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   RecoveryDataOrderCndtn
	/// <summary>
	///                      復旧データ一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   復旧データ一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class RecoveryDataOrderCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>システム区分</summary>
		/// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充 9:全て</remarks>
        private SystemDivState _systemDivCd;

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>開始UOE発注先コード</summary>
		private Int32 _st_UOESupplierCd;

		/// <summary>終了UOE発注先コード</summary>
		private Int32 _ed_UOESupplierCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>改頁区分</summary>
        /// <remarks>0:システム区分 1:しない</remarks>
        private NewPageDivState _newPageDiv;


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

		/// public propaty name  :  SystemDivCd
		/// <summary>システム区分プロパティ</summary>
		/// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   システム区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SystemDivState SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_UOESupplierCd
		/// <summary>開始UOE発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始UOE発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_UOESupplierCd
		{
			get{return _st_UOESupplierCd;}
			set{_st_UOESupplierCd = value;}
		}

		/// public propaty name  :  Ed_UOESupplierCd
		/// <summary>終了UOE発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了UOE発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_UOESupplierCd
		{
			get{return _ed_UOESupplierCd;}
			set{_ed_UOESupplierCd = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

		/// <summary>
		/// 復旧データ一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>RecoveryDataOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecoveryDataOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RecoveryDataOrderCndtn()
		{
		}

		/// <summary>
		/// 復旧データ一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充)</param>
		/// <param name="sectionCodes">拠点コード（複数指定）</param>
		/// <param name="st_UOESupplierCd">開始UOE発注先コード</param>
		/// <param name="ed_UOESupplierCd">終了UOE発注先コード</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>RecoveryDataOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecoveryDataOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public RecoveryDataOrderCndtn(string enterpriseCode, SystemDivState systemDivCd, string[] sectionCodes, Int32 st_UOESupplierCd, Int32 ed_UOESupplierCd, string enterpriseName,
            bool isOptSection, bool isSelectAllSection, NewPageDivState newPageDiv)
		{
			this._enterpriseCode = enterpriseCode;
			this._systemDivCd = systemDivCd;
			this._sectionCodes = sectionCodes;
			this._st_UOESupplierCd = st_UOESupplierCd;
			this._ed_UOESupplierCd = ed_UOESupplierCd;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._newPageDiv = newPageDiv;

		}

		/// <summary>
		/// 復旧データ一覧表抽出条件クラス複製処理
		/// </summary>
		/// <returns>RecoveryDataOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいRecoveryDataOrderCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RecoveryDataOrderCndtn Clone()
		{
			return new RecoveryDataOrderCndtn(this._enterpriseCode,this._systemDivCd,this._sectionCodes,this._st_UOESupplierCd,this._ed_UOESupplierCd,this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._newPageDiv);
		}

		/// <summary>
		/// 復旧データ一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のRecoveryDataOrderCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecoveryDataOrderCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(RecoveryDataOrderCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SystemDivCd == target.SystemDivCd)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_UOESupplierCd == target.St_UOESupplierCd)
				 && (this.Ed_UOESupplierCd == target.Ed_UOESupplierCd)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.NewPageDiv == target.NewPageDiv)
                 );
		}

		/// <summary>
		/// 復旧データ一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="recoveryDataOrderCndtn1">
		///                    比較するRecoveryDataOrderCndtnクラスのインスタンス
		/// </param>
		/// <param name="recoveryDataOrderCndtn2">比較するRecoveryDataOrderCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecoveryDataOrderCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(RecoveryDataOrderCndtn recoveryDataOrderCndtn1, RecoveryDataOrderCndtn recoveryDataOrderCndtn2)
		{
			return ((recoveryDataOrderCndtn1.EnterpriseCode == recoveryDataOrderCndtn2.EnterpriseCode)
				 && (recoveryDataOrderCndtn1.SystemDivCd == recoveryDataOrderCndtn2.SystemDivCd)
				 && (recoveryDataOrderCndtn1.SectionCodes == recoveryDataOrderCndtn2.SectionCodes)
				 && (recoveryDataOrderCndtn1.St_UOESupplierCd == recoveryDataOrderCndtn2.St_UOESupplierCd)
				 && (recoveryDataOrderCndtn1.Ed_UOESupplierCd == recoveryDataOrderCndtn2.Ed_UOESupplierCd)
				 && (recoveryDataOrderCndtn1.EnterpriseName == recoveryDataOrderCndtn2.EnterpriseName)
                 && (recoveryDataOrderCndtn1.IsOptSection == recoveryDataOrderCndtn2.IsOptSection)
                 && (recoveryDataOrderCndtn1.IsSelectAllSection == recoveryDataOrderCndtn2.IsSelectAllSection)
                 && (recoveryDataOrderCndtn1.NewPageDiv == recoveryDataOrderCndtn2.NewPageDiv)
                 );
		}
		/// <summary>
		/// 復旧データ一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のRecoveryDataOrderCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecoveryDataOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(RecoveryDataOrderCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SystemDivCd != target.SystemDivCd)resList.Add("SystemDivCd");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_UOESupplierCd != target.St_UOESupplierCd)resList.Add("St_UOESupplierCd");
			if(this.Ed_UOESupplierCd != target.Ed_UOESupplierCd)resList.Add("Ed_UOESupplierCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");



			return resList;
		}

		/// <summary>
		/// 復旧データ一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="recoveryDataOrderCndtn1">比較するRecoveryDataOrderCndtnクラスのインスタンス</param>
		/// <param name="recoveryDataOrderCndtn2">比較するRecoveryDataOrderCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecoveryDataOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(RecoveryDataOrderCndtn recoveryDataOrderCndtn1, RecoveryDataOrderCndtn recoveryDataOrderCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(recoveryDataOrderCndtn1.EnterpriseCode != recoveryDataOrderCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(recoveryDataOrderCndtn1.SystemDivCd != recoveryDataOrderCndtn2.SystemDivCd)resList.Add("SystemDivCd");
			if(recoveryDataOrderCndtn1.SectionCodes != recoveryDataOrderCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(recoveryDataOrderCndtn1.St_UOESupplierCd != recoveryDataOrderCndtn2.St_UOESupplierCd)resList.Add("St_UOESupplierCd");
			if(recoveryDataOrderCndtn1.Ed_UOESupplierCd != recoveryDataOrderCndtn2.Ed_UOESupplierCd)resList.Add("Ed_UOESupplierCd");
			if(recoveryDataOrderCndtn1.EnterpriseName != recoveryDataOrderCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (recoveryDataOrderCndtn1.IsOptSection != recoveryDataOrderCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (recoveryDataOrderCndtn1.IsSelectAllSection != recoveryDataOrderCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (recoveryDataOrderCndtn1.NewPageDiv != recoveryDataOrderCndtn2.NewPageDiv) resList.Add("NewPageDiv");
			return resList;
		}

        #region ■項目名称プロパティ
        /// <summary>
        /// システム区分タイトル　プロパティ
        /// </summary>
        public string SystemDivStateTitle
        {
            get
            {
                switch (this._systemDivCd)
                {
                    case SystemDivState.Manual: return ct_SystemDivState_Manual;
                    case SystemDivState.Slip: return ct_SystemDivState_Slip;
                    case SystemDivState.Search: return ct_SystemDivState_Search;
                    case SystemDivState.Lump: return ct_SystemDivState_Lump;
                    case SystemDivState.All: return ct_SystemDivState_All;
                    default: return "";
                }
            }
        }

        #endregion

        #region ■列挙体
        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>システム区分毎</summary>
            System = 0,
            /// <summary>しない</summary>
            None = 1,
        }

        /// <summary>
        /// 発行タイプ列挙体
        /// </summary>
        public enum SystemDivState
        {
            /// <summary>手入力</summary>
            Manual = 0,
            /// <summary>伝発</summary>
            Slip = 1,
            /// <summary>検索</summary>
            Search = 2,
            /// <summary>一括</summary>
            Lump = 3,
            /// <summary>全て</summary>
            All = 9,

        }

        /// <summary>
        /// データ送信区分列挙体
        /// </summary>
        public enum DataSendCodeState
        {
            /// <summary>送信エラー</summary>
            SendErr = 2,
            /// <summary>受信エラー</summary>
            ReceiveErr = 3,
            /// <summary>異常終了</summary>
            AbnormalErr = 4,
        }
        #endregion

        #region ■項目名称

        /// <summary>システム区分</summary>
        public const string ct_SystemDivState_Manual = "手入力";
        public const string ct_SystemDivState_Slip = "伝発";
        public const string ct_SystemDivState_Search = "検索";
        public const string ct_SystemDivState_Lump = "一括";
        public const string ct_SystemDivState_All = "全て";

        public const string ct_DataSendCode_SendErr = "送信ｴﾗｰ";
        public const string ct_DataSendCode_ReceiveErr = "受信ｴﾗｰ";
        public const string ct_DataSendCode_AbnormalErr = "異常終了";
        #endregion
	}
}
