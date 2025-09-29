using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   EnterSchOrderCndtn
	/// <summary>
	///                      入庫予定表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   入庫予定表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/03  (CSharp File Generated Date)</br>
    /// <br>Note             :   ハンディターミナル二次開発の対応</br>
    /// <br>Programmer       :   譚洪</br>
    /// <br>Date             :   2017/09/14</br>
	/// </remarks>
    public class EnterSchOrderCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>本社機能プロパティ</summary>
        private bool _isMainOfficeFunc;

        /// <summary>拠点コード（複数指定）</summary>
        private string[] _sectionCodes;

        /// <summary>開始UOE発注先コード</summary>
        private Int32 _st_UOESupplierCd;

        /// <summary>終了UOE発注先コード</summary>
        private Int32 _ed_UOESupplierCd;

        /// <summary>発注先コード指定(複数指定)</summary>
        /// <remarks>nullの場合は、開始終了範囲指定を使用</remarks>
        private Int32[] _uOESupplierCds;

        /// <summary>開始受信日付</summary>
        private DateTime _st_ReceiveDate;

        /// <summary>終了受信日付</summary>
        private DateTime _ed_ReceiveDate;

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:入庫分のみ 1:メーカーフォロー分のみ　2:欠品分のみ</remarks>
        private Int32 _printTypeCndtn;

        /// <summary>出力順</summary>
        private Int32 _sortOrderDiv;

        /// <summary>改頁</summary>
        private Int32 _newPageDiv;

        /// <summary>発注先抽出条件</summary>
        private int _supplierExtra;

        /// <summary>帳票タイプ区分</summary>
        private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        private string _printDivName = string.Empty;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>バーコード印字区分</summary>
        private int _barCodeShowDiv;
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

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

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   本社機能プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
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

        /// public propaty name  :  St_UOESupplierCd
        /// <summary>開始UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_UOESupplierCd
        {
            get { return _st_UOESupplierCd; }
            set { _st_UOESupplierCd = value; }
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
            get { return _ed_UOESupplierCd; }
            set { _ed_UOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCds
        /// <summary>発注先コード指定(複数指定)プロパティ</summary>
        /// <value>nullの場合は、開始終了範囲指定を使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コード指定(複数指定)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] UOESupplierCds
        {
            get { return _uOESupplierCds; }
            set { _uOESupplierCds = value; }
        }

        /// public propaty name  :  St_ReceiveDate
        /// <summary>開始受信日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>終了受信日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  PrintTypeCndtn
        /// <summary>印刷タイププロパティ</summary>
        /// <value>0:入庫分のみ 1:メーカーフォロー分のみ　2:欠品分のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintTypeCndtn
        {
            get { return _printTypeCndtn; }
            set { _printTypeCndtn = value; }
        }

        /// public propaty name  :  SortOrderDiv
        /// <summary>出力順プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SortOrderDiv
        {
            get { return _sortOrderDiv; }
            set { _sortOrderDiv = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  SupplierExtra
        /// <summary>発注先抽出条件プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先抽出条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierExtra
        {
            get { return this._supplierExtra; }
            set { this._supplierExtra = value; }
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

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// public propaty name  :  BarCodeShowDiv
        /// <summary>バーコード印字区分プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バーコード印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int BarCodeShowDiv
        {
            get { return _barCodeShowDiv; }
            set { _barCodeShowDiv = value; }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        /// <summary>
        /// 入庫予定表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>EnterSchOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EnterSchOrderCndtn()
        {
        }
    }
}
