//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員別販売区分別売上目標設定検索パラメータワーク
// プログラム概要   : 入金データテキスト変換条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11500865-00  作成担当 : 譚洪
// 作 成 日  2019/09/02   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchEmpScSalesTargetParaWork
	/// <summary>
    ///                      従業員別販売区分別売上目標設定検索パラメータワーク
	/// </summary>
	/// <remarks>
    /// <br>note             :   従業員別販売区分別売上目標設定検索パラメータワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2019/09/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SearchEmpScSalesTargetParaWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>論理削除区分</summary>
		private Int32 _logicalDeleteCode;

		/// <summary>目標設定区分</summary>
		/// <remarks>10：月間目標,20：個別期間目標</remarks>
		private Int32 _targetSetCd;

		/// <summary>目標対比区分</summary>
        /// <remarks>10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+業種,31:拠点+業種+得意先,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品</remarks>
		private Int32 _targetContrastCd;

		/// <summary>目標区分コード</summary>
		/// <remarks>月間目標：YYYYMM、個別期間目標：任意コード</remarks>
		private string _targetDivideCode = "";

		/// <summary>目標区分名称</summary>
		private string _targetDivideName = "";

        /// <summary>従業員コード</summary>
		private string _employeeCode = "";

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

		/// <summary>適用開始日（開始）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _startApplyStaDate;

		/// <summary>適用開始日（終了）</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyStaDate;

		/// <summary>適用終了日（開始）</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _startApplyEndDate;

		/// <summary>適用終了日（終了）</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyEndDate;


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

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
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

		/// public propaty name  :  TargetSetCd
		/// <summary>目標設定区分プロパティ</summary>
		/// <value>10：月間目標,20：個別期間目標</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   目標設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TargetSetCd
		{
			get{return _targetSetCd;}
			set{_targetSetCd = value;}
		}

		/// public propaty name  :  TargetContrastCd
		/// <summary>目標対比区分プロパティ</summary>
		/// <value>10:拠点,20:拠点+従業員,30:拠点+ｷｬﾘｱｺｰﾄﾞ+機種ｺｰﾄﾞ,40:拠点+ﾒｰｶｰｺｰﾄﾞ+商品ｺｰﾄﾞ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   目標対比区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TargetContrastCd
		{
			get{return _targetContrastCd;}
			set{_targetContrastCd = value;}
		}

		/// public propaty name  :  TargetDivideCode
		/// <summary>目標区分コードプロパティ</summary>
		/// <value>月間目標：YYYYMM、個別期間目標：任意コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   目標区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TargetDivideCode
		{
			get{return _targetDivideCode;}
			set{_targetDivideCode = value;}
		}

		/// public propaty name  :  TargetDivideName
		/// <summary>目標区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   目標区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TargetDivideName
		{
			get{return _targetDivideName;}
			set{_targetDivideName = value;}
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

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

		/// public propaty name  :  StartApplyStaDate
		/// <summary>適用開始日（開始）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用開始日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime StartApplyStaDate
		{
			get{return _startApplyStaDate;}
			set{_startApplyStaDate = value;}
		}

		/// public propaty name  :  EndApplyStaDate
		/// <summary>適用開始日（終了）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用開始日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime EndApplyStaDate
		{
			get{return _endApplyStaDate;}
			set{_endApplyStaDate = value;}
		}

		/// public propaty name  :  StartApplyEndDate
		/// <summary>適用終了日（開始）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用終了日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime StartApplyEndDate
		{
			get{return _startApplyEndDate;}
			set{_startApplyEndDate = value;}
		}

		/// public propaty name  :  EndApplyEndDate
		/// <summary>適用終了日（終了）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用終了日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime EndApplyEndDate
		{
			get{return _endApplyEndDate;}
			set{_endApplyEndDate = value;}
		}


		/// <summary>
		/// 従業員別売上目標設定検索パラメータワークコンストラクタ
		/// </summary>
        /// <returns>SearchEmpScSalesTargetParaWorkクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   SearchEmpScSalesTargetParaWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SearchEmpScSalesTargetParaWork()
		{
		}

	}
}
