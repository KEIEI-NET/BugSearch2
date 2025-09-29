using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PrmSettingPrintOrderCndtn
	/// <summary>
	///                      優良設定マスタ印刷条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   優良設定マスタ印刷条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class PrmSettingPrintOrderCndtn
    {
        # region ■ private field ■
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        private string[] _sectionCodes;

        /// <summary>商品中分類コード(開始)</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _st_GoodsMGroup;

        /// <summary>商品中分類コード(終了)</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _ed_GoodsMGroup;
        # endregion  ■ private field ■

        # region ■ public propaty ■
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

		/// public propaty name  :  St_GoodsMGroup
		/// <summary>商品中分類コード(開始)プロパティ</summary>
		/// <value>※中分類</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMGroup
		{
			get{return _st_GoodsMGroup;}
			set{_st_GoodsMGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsMGroup
		/// <summary>商品中分類コード(終了)プロパティ</summary>
		/// <value>※中分類</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMGroup
		{
			get{return _ed_GoodsMGroup;}
			set{_ed_GoodsMGroup = value;}
		}
        
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
		/// 優良設定マスタ印刷条件クラスコンストラクタ
		/// </summary>
		/// <returns>PrmSettingPrintOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrmSettingPrintOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public PrmSettingPrintOrderCndtn()
		{
        }
        # endregion ■ Constructor ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;
                
        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
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

       
        # endregion ■ public propaty (自動生成以外) ■
    }
}
