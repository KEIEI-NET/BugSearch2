//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2010/07/20  修正内容 : 王開強
//----------------------------------------------------------------------------//


using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   EmployeeResultsListCndtnWork
	/// <summary>
    ///                      担当者別実績照会抽出条件クラスワーク
	/// </summary>
	/// <remarks>
    /// <br>note             :   担当者別実績照会抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class EmployeeResultsListCndtnWork
	{

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>参照区分</summary>
        /// <remarks>担当者、受注者、発行者</remarks>
        private Int32 _referType;

        /// <summary>期間区分</summary>
        /// <remarks>日計、月計、当期</remarks>
        private Int32 _duringType;


        /// <summary>担当者(開始)</summary>
        private string _st_EmployeeCode;

        /// <summary>担当者(終了)</summary>
        private string _ed_EmployeeCode;


        /// <summary>期間(開始)YYYYMMDD</summary>
        /// <remarks>なし</remarks>
        private DateTime _st_DuringTime;

        /// <summary>期間(終了)YYYYMMDD</summary>
        /// <remarks>なし</remarks>
        private DateTime _ed_DuringTime;


        /// <summary>期間(開始)YYYYMM</summary>
        /// <remarks>なし</remarks>
        private DateTime _st_YearMonth;

        /// <summary>期間(終了)YYYYMM</summary>
        /// <remarks>なし</remarks>
        private DateTime _ed_YearMonth;

        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>拠点コードリスト</summary>
        /// <remarks>なし</remarks>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>画面ビュー・出力ビューフラグ</summary>
        private string _viewFlg = string.Empty;
        // --- ADD 2010/07/20 --------------------------------<<<<<

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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  ReferType
        /// <summary>参照区分プロパティ</summary>
        /// <value>担当者、受注者、発行者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReferType
        {
            get { return _referType; }
            set { _referType = value; }
        }

        /// public propaty name  :  DuringType
        /// <summary>期間区分プロパティ</summary>
        /// <value>日計、月計、当期</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期間区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DuringType
        {
            get { return _duringType; }
            set { _duringType = value; }
        }


        /// <summary>担当者(開始)</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// <summary>担当者(終了)</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// <summary>期間(開始)YYYYMMDD</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_DuringTime
        {
            get { return _st_DuringTime; }
            set { _st_DuringTime = value; }
        }

        /// <summary>期間(終了)YYYYMMDD</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_DuringTime
        {
            get { return _ed_DuringTime; }
            set { _ed_DuringTime = value; }
        }


        /// <summary>期間(開始)YYYYMM</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_YearMonth
        {
            get { return _st_YearMonth; }
            set { _st_YearMonth = value; }
        }

        /// <summary>期間(終了)YYYYMM</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_YearMonth
        {
            get { return _ed_YearMonth; }
            set { _ed_YearMonth = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// 拠点コードリスト
        /// </summary>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }

        /// <summary>
        /// 画面ビュー・出力ビューフラグ
        /// </summary>
        public string ViewFlg
        {
            get { return _viewFlg; }
            set { _viewFlg = value; }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

		/// <summary>
        /// 担当者別実績照会抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeResultsListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeResultsListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EmployeeResultsListCndtnWork()
		{
		}

	}
}




