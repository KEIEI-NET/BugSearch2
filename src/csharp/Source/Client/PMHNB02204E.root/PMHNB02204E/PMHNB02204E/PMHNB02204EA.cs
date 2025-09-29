//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリスト抽出条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RateUnMatchCndtn
    /// <summary>
    ///                      売価原価アンマッチリスト抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売価原価アンマッチリスト抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RateUnMatchCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>拠点コード（複数指定）</summary>
        private string[] _sectionCodes;

        /// <summary>処理区分</summary>
		private Int32 _processKbn;

        /// <summary>帳票タイプ区分</summary>
        private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        private string _printDivName = string.Empty;

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

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション導入区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
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
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._sectionCodes.Length == 1) && (this._sectionCodes[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  ProcessKbn
		/// <summary>処理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 ProcessKbn
		{
			get{return _processKbn;}
			set{_processKbn = value;}
		}

        /// public propaty name  :  PrintDiv
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>帳票タイプ区分プロパティ名称(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// 売価原価アンマッチリスト抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SupplierUnmOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierUnmOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RateUnMatchCndtn()
        {
        }
    }
}
