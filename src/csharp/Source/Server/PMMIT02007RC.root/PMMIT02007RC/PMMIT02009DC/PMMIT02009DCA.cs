//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先別見積書・棚卸表
// プログラム概要   : 得意先別見積書・棚卸表抽出条件クラスワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10970531-00  作成担当 : songg
// 作 成 日  K2013/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   TakekawaQuotaInventCndtnWork
	/// <summary>
	///                      得意先別見積書・棚卸表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先別見積書・棚卸表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Genarated Date   :   K2013/12/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class TakekawaQuotaInventCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

        /// <summary>ログインユーザーの拠点コード</summary>
        private string _loginUserSecCode;

		/// <summary>計上年月日</summary>
		/// <remarks>YYYYMMDD ※処理月を締める日付。</remarks>
        private Int32 _addUpDate;

        /// <summary></summary>
        private DateTime _oprDate;

        /// <summary>得意先開始</summary>
        private Int32 _customerCodeSt;

        /// <summary>得意先終了</summary>
        private Int32 _customerCodeEd;

        /// <summary>倉庫開始</summary>
        private string _warehouseCodeSt = "";

        /// <summary>倉庫終了</summary>
        private string _warehouseCodeEd = "";

        /// <summary>選択区分</summary>
        /// <remarks>0:見積書,1:棚卸表</remarks>
        private Int32 _selectFlg;

        /// <summary>棚番開始</summary>
        private string _warehouseShelfNoSt = "";

        /// <summary>棚番終了</summary>
        private string _warehouseShelfNoEd = "";

        /// <summary>仕入先開始</summary>
        private Int32 _stSupplierCd;

        /// <summary>仕入先終了</summary>
        private Int32 _edSupplierCd;

        /// <summary>BLコード開始</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>BLコード終了</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>メーカー開始</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>メーカー終了</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>棚番計印字区分</summary>
        /// <remarks>0:棚番計印字する,1:棚番計印字しない</remarks>
        private Int32 _shelfNoPrintFlg;

        /// <summary>棚卸未入力分処理区分</summary>
        /// <remarks>0:マシン在庫数を採用,1:未入力扱い</remarks>
        private Int32 _shelfNoOprFlg;


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
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

        /// public propaty name  :  LoginUserSecCode
        /// <summary>ログインユーザーの拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインユーザーの拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginUserSecCode
		{
            get { return _loginUserSecCode; }
            set { _loginUserSecCode = value; }
		}

		/// public propaty name  :  AddUpDate
		/// <summary>計上年月日プロパティ</summary>
		/// <value>YYYYMMDD ※処理月を締める日付。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

        /// public propaty name  :  OprDate
        /// <summary>支払予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OprDate
        {
            get { return _oprDate; }
            set { _oprDate = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>得意先開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>得意先終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  WarehouseCodeSt
        /// <summary>倉庫開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>倉庫終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        /// public propaty name  :  SelectFlg
        /// <summary>選択区分プロパティ</summary>
        /// <value>0:見積書,1:棚卸表</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelectFlg
        {
            get { return _selectFlg; }
            set { _selectFlg = value; }
        }

        /// public propaty name  :  WarehouseShelfNoSt
        /// <summary>棚番開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNoSt
        {
            get { return _warehouseShelfNoSt; }
            set { _warehouseShelfNoSt = value; }
        }

        /// public propaty name  :  WarehouseShelfNoEd
        /// <summary>棚番終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNoEd
        {
            get { return _warehouseShelfNoEd; }
            set { _warehouseShelfNoEd = value; }
        }

        /// public propaty name  :  StSupplierCd
        /// <summary>仕入先開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StSupplierCd
        {
            get { return _stSupplierCd; }
            set { _stSupplierCd = value; }
        }

        /// public propaty name  :  EdSupplierCd
        /// <summary>仕入先終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdSupplierCd
        {
            get { return _edSupplierCd; }
            set { _edSupplierCd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>BLコード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>BLコード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカー開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>メーカー終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  ShelfNoPrintFlg
        /// <summary>棚番計印字区分プロパティ</summary>
        /// <value>0:棚番計印字する,1:棚番計印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShelfNoPrintFlg
        {
            get { return _shelfNoPrintFlg; }
            set { _shelfNoPrintFlg = value; }
        }

        /// public propaty name  :  ShelfNoOprFlg
        /// <summary>棚卸未入力分処理区分プロパティ</summary>
        /// <value>0:マシン在庫数を採用,1:未入力扱い</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸未入力分処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShelfNoOprFlg
        {
            get { return _shelfNoOprFlg; }
            set { _shelfNoOprFlg = value; }
        }

		/// <summary>
		/// 得意先別見積書・棚卸表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>TakekawaQuotaInventCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TakekawaQuotaInventCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TakekawaQuotaInventCndtnWork()
		{
		}

	}
}
