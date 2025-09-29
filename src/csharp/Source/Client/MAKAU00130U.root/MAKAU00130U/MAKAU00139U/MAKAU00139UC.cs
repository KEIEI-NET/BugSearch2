using System;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
	/// <summary>
	/// 仕入明細列表示状況クラス
	/// </summary>
	internal class ProductStockDisplayStatus
	{
		//====================================================================================================
		//  プライベート定数
		//====================================================================================================
		#region プライベート定数
		/// <summary>
		/// クラスID(TEMP保存用)
		/// </summary>
		private const string CT_CLASSID = "MAZAI04380UC";
		/// <summary>
		/// KEYLIST(TEMP保存用)
		/// </summary>
//		private const string CT_KEYLIST = "PtSupSlipDtlStatus";
        #endregion
        #region 列順定義定数
        /// <summary>行番号</summary>
        public const int ctINDX_RowNum = 0;
		/// <summary>商品コード</summary>
		public const int ctINDX_GoodsCode = ctINDX_RowNum + 1;
        /// <summary>商品ガイド</summary>
        public const int ctINDX_GoodsGuide = ctINDX_GoodsCode + 1;
		/// <summary>商品名称</summary>
		public const int ctINDX_GoodsName = ctINDX_GoodsGuide + 1;
		/// <summary>機種</summary>
		public const int ctINDX_CellphoneModelName = ctINDX_GoodsName + 1;
		/// <summary>製造番号</summary>
		public const int ctINDX_ProductNumber = ctINDX_CellphoneModelName + 1;
		/// <summary>携帯番号</summary>
		public const int ctINDX_StockTelNo1 = ctINDX_ProductNumber + 1;
		/// <summary>仕入先</summary>
        public const int ctINDX_CustomerName = ctINDX_StockTelNo1 + 1;
		#endregion

		#region 列名定義定数
        /// <summary>行番号</summary>
        public const string ctCOL_RowNum = "RowNum";
        /// <summary>商品コード</summary>
        public const string ctCOL_GoodsCode = "GoodsCode";
        /// <summary>商品ガイド</summary>
        public const string ctCOL_GoodsGuide = "GoodsGuide";
        /// <summary>商品名称</summary>
        public const string ctCOL_GoodsName = "GoodsName";
        /// <summary>機種</summary>
        public const string ctCOL_CellphoneModelName = "CellphoneModelName";
        /// <summary>製造番号</summary>
        public const string ctCOL_ProductNumber = "ProductNumber";
        /// <summary>携帯番号</summary>
        public const string ctCOL_StockTelNo1 = "StockTelNo1";
        /// <summary>仕入先</summary>
        public const string ctCOL_CustomerName = "CustomerName";

        /// <summary>文字サイズ</summary>
		private const string ctCOL_FontSize = "FontSize";
		/// <summary>内税外税両表示</summary>
//		private const string ctCOL_TaxDisplay = "TaxDisplay";
		#endregion

		#region 列初期値テーブル
		/// <summary>
		/// 明細列表示ステータスの初期値
		/// </summary>
		private SlipDtlDisplayStatus[] CT_DEFAULTSTATUS = new SlipDtlDisplayStatus[]
			{
                //                       名称             インデックス     幅  Visible
                new SlipDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,30,true),
				new SlipDtlDisplayStatus(ctCOL_GoodsCode, ctINDX_GoodsCode, 160, true),          	            // 商品コード
                new SlipDtlDisplayStatus(ctCOL_GoodsGuide,ctINDX_GoodsGuide,30,true),                           // 商品ガイド
				new SlipDtlDisplayStatus(ctCOL_GoodsName, ctINDX_GoodsName, 160, true),			        	    // 商品名称
				new SlipDtlDisplayStatus(ctCOL_CellphoneModelName, ctINDX_CellphoneModelName, 160, true),	    // 機種
				new SlipDtlDisplayStatus(ctCOL_ProductNumber, ctINDX_ProductNumber, 140, true),			        // 製造番号
				new SlipDtlDisplayStatus(ctCOL_StockTelNo1, ctINDX_StockTelNo1, 140, true),  	// 携帯番号
				new SlipDtlDisplayStatus(ctCOL_CustomerName, ctINDX_CustomerName, 160, true),					// 仕入先
			};
		#endregion


		//====================================================================================================
		//  プライベート変数宣言
		//====================================================================================================
		#region プライベート変数
		/// <summary>
		/// 仕入明細列ステータス
		/// </summary>
		private ArrayList mDetailStatus;
		/// <summary>
		/// フォントサイズ
		/// </summary>
		private int _fontSize = 11;
		/// <summary>
		/// 内税外税両表示
		/// </summary>
//		private bool _dispBothTaxway = false;
		#endregion

		//====================================================================================================
		//  コンストラクタ
		//====================================================================================================
		#region コンストラクタ
		/// <summary>
		/// 製番在庫クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 製番在庫クラスのインスタンスを作成し、初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public ProductStockDisplayStatus()
		{
			mDetailStatus = new ArrayList();

            InitializeStatus(ctCOL_RowNum);
			// 商品コード
			InitializeStatus(ctCOL_GoodsCode);
            // 商品ガイド
            
			// 商品名称
			InitializeStatus(ctCOL_GoodsName);
			// 機種
			InitializeStatus(ctCOL_CellphoneModelName);
			// 製造番号
			InitializeStatus(ctCOL_ProductNumber);
			// 携帯番号
			InitializeStatus(ctCOL_StockTelNo1);
			// 仕入先
			InitializeStatus(ctCOL_CustomerName);

		}
		#endregion

		//====================================================================================================
		//  パブリックプロパティ
		//====================================================================================================
		#region パブリックプロパティ
		#region [表示位置]プロパティ

        /// <summary>
        /// [表示位置]行番号
        /// </summary>
        public int Order_RowNum
        {
            get { return GetVisiblePosition(ctCOL_RowNum); }
            set { SetVisiblePosition(ctCOL_RowNum, value); }
        }

        /// <summary>
		/// [表示位置]商品コード
		/// </summary>
		public int Order_GoodsCode
		{
			get { return GetVisiblePosition(ctCOL_GoodsCode); }
			set { SetVisiblePosition(ctCOL_GoodsCode, value); }
		}
        /// <summary>
        /// [表示位置]商品ガイド
        /// </summary>
        public int Order_GoodsGuide
        {
            get { return GetVisiblePosition(ctCOL_GoodsGuide); }
            set { SetVisiblePosition(ctCOL_GoodsGuide, value); }
        }

		/// <summary>
		/// [表示位置]商品名称
		/// </summary>
		public int Order_GoodsName
		{
			get { return GetVisiblePosition(ctCOL_GoodsName); }
			set { SetVisiblePosition(ctCOL_GoodsName, value); }
		}
		/// <summary>
		/// [表示位置]機種
		/// </summary>
		public int Order_CellphoneModelName
		{
			get { return GetVisiblePosition(ctCOL_CellphoneModelName); }
			set { SetVisiblePosition(ctCOL_CellphoneModelName, value); }
		}
		/// <summary>
		/// [表示位置]製造番号
		/// </summary>
		public int Order_ProductNumber
		{
			get { return GetVisiblePosition(ctCOL_ProductNumber); }
			set { SetVisiblePosition(ctCOL_ProductNumber, value); }
		}
		/// <summary>
		/// [表示位置]携帯番号
		/// </summary>
		public int Order_StockTelNo1
		{
			get { return GetVisiblePosition(ctCOL_StockTelNo1); }
			set { SetVisiblePosition(ctCOL_StockTelNo1, value); }
		}
		/// <summary>
		/// [表示位置]仕入先
		/// </summary>
		public int Order_CustomerName
		{
			get { return GetVisiblePosition(ctCOL_CustomerName); }
			set { SetVisiblePosition(ctCOL_CustomerName, value); }
		}
		#endregion

		#region [表示]プロパティ

        /// <summary>
        /// [表示]行番号
        /// </summary>
        public bool Visible_RowNum
        {
            get { return GetVisible(ctCOL_RowNum); }
            set { SetVisible(ctCOL_RowNum, value); }
        }
		/// <summary>
		/// [表示]商品コード
		/// </summary>
		public bool Visible_GoodsCode
		{
			get { return GetVisible(ctCOL_GoodsCode); }
			set { SetVisible(ctCOL_GoodsCode, value); }
		}
        /// <summary>
        /// [表示]商品ガイド
        /// </summary>
        public bool Visible_GoodsGuide
        {
            get { return GetVisible(ctCOL_GoodsGuide); }
            set { SetVisible(ctCOL_GoodsGuide, value); }
        }
        /// <summary>
		/// [表示]商品名称
		/// </summary>
		public bool Visible_GoodsName
		{
			get { return GetVisible(ctCOL_GoodsName); }
			set { SetVisible(ctCOL_GoodsName, value); }
		}
		/// <summary>
		/// [表示]機種
		/// </summary>
		public bool Visible_CellphoneModelName
		{
			get { return GetVisible(ctCOL_CellphoneModelName); }
			set { SetVisible(ctCOL_CellphoneModelName, value); }
		}
		/// <summary>
		/// [表示]製造番号
		/// </summary>
		public bool Visible_ProductNumber
		{
			get { return GetVisible(ctCOL_ProductNumber); }
			set { SetVisible(ctCOL_ProductNumber, value); }
		}
		/// <summary>
		/// [表示]携帯番号
		/// </summary>
		public bool Visible_StockTelNo1
		{
			get { return GetVisible(ctCOL_StockTelNo1); }
			set { SetVisible(ctCOL_StockTelNo1, value); }
		}
		/// <summary>
		/// [表示]仕入先
		/// </summary>
		public bool Visible_CustomerName
		{
			get { return GetVisible(ctCOL_CustomerName); }
			set { SetVisible(ctCOL_CustomerName, value); }
		}
		#endregion

		#region [列幅]プロパティ
        /// <summary>
        /// [列幅]行番号
        /// </summary>
        public int Width_RowNum
        {
            get { return GetWidth(ctCOL_RowNum); }
            set { SetWidth(ctCOL_RowNum, value); }
        }
		/// <summary>
		/// [列幅]商品コード
		/// </summary>
		public int Width_GoodsCode
		{
			get { return GetWidth(ctCOL_GoodsCode); }
			set { SetWidth(ctCOL_GoodsCode, value); }
		}
        /// <summary>
        /// [列幅]商品ガイド
        /// </summary>
        public int Width_GoodsGuide
        {
            get { return GetWidth(ctCOL_GoodsGuide); }
            set { SetWidth(ctCOL_GoodsGuide, value); }
        }
        /// <summary>
		/// [列幅]商品名称
		/// </summary>
		public int Width_GoodsName
		{
			get { return GetWidth(ctCOL_GoodsName); }
			set { SetWidth(ctCOL_GoodsName, value); }
		}
		/// <summary>
		/// [列幅]機種
		/// </summary>
		public int Width_CellphoneModelName
		{
			get { return GetWidth(ctCOL_CellphoneModelName); }
			set { SetWidth(ctCOL_CellphoneModelName, value); }
		}
		/// <summary>
		/// [列幅]製造番号
		/// </summary>
		public int Width_ProductNumber
		{
			get { return GetWidth(ctCOL_ProductNumber); }
			set { SetWidth(ctCOL_ProductNumber, value); }
		}
		/// <summary>
		/// [列幅]携帯番号
		/// </summary>
		public int Width_StockTelNo1
		{
			get { return GetWidth(ctCOL_StockTelNo1); }
			set { SetWidth(ctCOL_StockTelNo1, value); }
		}
		/// <summary>
		/// [列幅]仕入先
		/// </summary>
		public int Width_CustomerName
		{
			get { return GetWidth(ctCOL_CustomerName); }
			set { SetWidth(ctCOL_CustomerName, value); }
		}
		#endregion

		/// <summary>
		/// フォントサイズ
		/// </summary>
		public int FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		/// <summary>
		/// 内税外税両表示
		/// </summary>
		public bool DispBothTaxway
		{
			get { return _dispBothTaxway; }
			set { _dispBothTaxway = value; }
		}
  
		#endregion

		//====================================================================================================
		//  パブリックメソッド
		//====================================================================================================
		#region パブリックメソッド
		/// <summary>
		/// 明細列表示ステータスデータが正しく設定してあるかをチェック
		/// </summary>
		/// <returns>true=正常,false=異常</returns>
		/// <remarks>
		/// <br>Note       : 明細列表示ステータスが正常に設定してあるかをチェックします。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public Boolean CheckDisplayStatus()
		{
			SlipDtlDisplayStatus _temp;

            // 行番号
            _temp = SearchDisplayStatus(ctCOL_RowNum);
            if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            // 商品コード
			_temp = SearchDisplayStatus(ctCOL_GoodsCode);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            // 商品ガイド
            _temp = SearchDisplayStatus(ctCOL_GoodsGuide);
            if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// 商品名称
			_temp = SearchDisplayStatus(ctCOL_GoodsName);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// 機種
			_temp = SearchDisplayStatus(ctCOL_CellphoneModelName);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// 製造番号
			_temp = SearchDisplayStatus(ctCOL_ProductNumber);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// 携帯番号
			_temp = SearchDisplayStatus(ctCOL_StockTelNo1);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			// 仕入先
			_temp = SearchDisplayStatus(ctCOL_CustomerName);
			if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
			return true;
		}

		/// <summary>
		/// 明細表示ステータスデータを初期値に設定する。
		/// </summary>
		/// <remarks>
		/// <br>Note       : 明細表示ステータスを初期状態にする。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public void SetDefaultValue()
		{
			SlipDtlDisplayStatus _temp;

            // 行番号
            _temp = SearchDisplayStatus(ctCOL_RowNum); if (_temp == null) _temp = InitializeStatus(ctCOL_RowNum);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_RowNum].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_RowNum].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_RowNum].Visible;            
            // 商品コード
			_temp = SearchDisplayStatus(ctCOL_GoodsCode); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsCode);
			_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsCode].VisiblePosition;
			_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Width;
			_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Visible;
            // 商品ガイド
            _temp = SearchDisplayStatus(ctCOL_GoodsGuide); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsGuide);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Visible;
            // 商品名称
			_temp = SearchDisplayStatus(ctCOL_GoodsName); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsName);
			_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsName].VisiblePosition;
			_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsName].Width;
			_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsName].Visible;
			// 機種
			_temp = SearchDisplayStatus(ctCOL_CellphoneModelName); if (_temp == null) _temp = InitializeStatus(ctCOL_CellphoneModelName);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_CellphoneModelName].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_CellphoneModelName].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_CellphoneModelName].Visible;
			// 製造番号
            _temp = SearchDisplayStatus(ctCOL_ProductNumber); if (_temp == null) _temp = InitializeStatus(ctCOL_ProductNumber);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_ProductNumber].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Visible;
			// 携帯番号
            _temp = SearchDisplayStatus(ctCOL_StockTelNo1); if (_temp == null) _temp = InitializeStatus(ctCOL_StockTelNo1);
            _temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].VisiblePosition;
            _temp.Width = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Width;
            _temp.Visible = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Visible;
			// 仕入先
			_temp = SearchDisplayStatus(ctCOL_CustomerName); if (_temp == null) _temp = InitializeStatus(ctCOL_CustomerName);
			_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_CustomerName].VisiblePosition;
			_temp.Width = CT_DEFAULTSTATUS[ctINDX_CustomerName].Width;
			_temp.Visible = CT_DEFAULTSTATUS[ctINDX_CustomerName].Visible;
			// フォントサイズ
			_fontSize = 11;

			// 内税外税両表示
//			_dispBothTaxway = false;
		}

		/// <summary>
		/// クラスデータをシリアライズする。
		/// </summary>
		/// <param name="_filename">出力するファイル名称</param>
		/// <remarks>
		/// <br>Note       : 明細列ステータス情報をシリアライズする</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public void SerializeData(string _filename)
		{
			try
			{
				// シリアライズする前に、フォントサイズを追加しておく
				SlipDtlDisplayStatus _temp = SearchDisplayStatus(ctCOL_FontSize);

				// まだ内部保持リストの中にない(間違いなくないはずです！！！)
				if (_temp == null)
				{
					_temp = new SlipDtlDisplayStatus(ctCOL_FontSize, 9999, 11, false);
					mDetailStatus.Add(_temp);
				}

				// フォントサイズを幅に入れる
				_temp.Width = _fontSize;

				// 保持している情報をバイト配列に変換する
				SlipDtlDisplayStatus[] dtlStat = (SlipDtlDisplayStatus[])mDetailStatus.ToArray(typeof(SlipDtlDisplayStatus));

				Broadleaf.Application.Common.UserSettingController.ByteSerializeUserSetting(dtlStat, ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);
			}
			catch
			{
				// 何もなしとする。
			}
		}

		/// <summary>
		/// クラスデータをデシリアライズする。
		/// </summary>
		/// <param name="_filename">取得するファイル名称</param>
		/// <remarks>
		/// <br>Note       : 明細列ステータス情報をデシリアライズする</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public void DeserializeData(string _filename)
		{
			try
			{
				// 設定データをREADする
				SlipDtlDisplayStatus[] dtl = Broadleaf.Application.Common.UserSettingController.ByteDeserializeUserSetting<SlipDtlDisplayStatus[]>(ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);

				// データがあった場合
				if (dtl != null)
				{
					// 一旦リストを削除
					mDetailStatus.Clear();

					foreach (SlipDtlDisplayStatus wk in dtl)
					{
						mDetailStatus.Add(wk.Clone());
					}
				}

				// デシリアライズしたときに、フォントデータ・内税外税両表示は取得後リストからは削除する
				// (Gridの列ではないのでこのままあると明細画面を修正する必要があるため)
				if (mDetailStatus != null)
				{
					int[] delIndex = new int[] { -1, -1 };
					int ix = 0;

					foreach (SlipDtlDisplayStatus _st in mDetailStatus)
					{
						// フォントサイズ
						if (_st.ColName == ctCOL_FontSize)
						{
							_fontSize = _st.Width;
							delIndex[0] = ix;
						}
						// 内税外税両表示
//						else if (_st.ColName == ctCOL_TaxDisplay)
//						{
//							_dispBothTaxway = _st.Visible;
							delIndex[1] = ix;
//						}

						if ((delIndex[0] != -1) && (delIndex[1] != -1)) break;
						ix++;
					}

					// リストより削除(後ろから)
					Array.Sort(delIndex);
					for (int i = delIndex.Length -1; i >= 0; i--)
					{
						if (delIndex[i] != -1)
						{
							mDetailStatus.RemoveAt(delIndex[i]);
						}
					}
				}
			}
			catch
			{
				// 何もなしとする。
			}
		}

		/// <summary>
		/// 表示順に並び替えられたカラム名称リストを取得します。
		/// </summary>
		/// <returns>表示順のカラム名称リスト</returns>
		/// <remarks>
		/// <br>Note       : 明細列表示ステータスを表示順に並び替え、そのカラム名称リストを取得します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public System.Collections.ArrayList GetVisiblePositionList()
		{
			mDetailStatus.Sort(new VisibleCompare());

			System.Collections.ArrayList _retList = new System.Collections.ArrayList();
			for (int i = 0; i < mDetailStatus.Count; i++)
			{
				_retList.Add(((SlipDtlDisplayStatus)mDetailStatus[i]).ColName);
			}
			return _retList;
		}

		/// <summary>
		/// 明細表示列ステータス比較
		/// </summary>
		/// <remarks>
		/// <br>Note       : 明細表示列を表示順に並び替えます。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		internal class VisibleCompare : System.Collections.IComparer
		{
			#region IComparer メンバ
			/// <summary>
			/// 並び替え処理部
			/// </summary>
			/// <param name="x">第一比較オブジェクト</param>
			/// <param name="y">第二比較オブジェクト</param>
			/// <returns>0未満:ｘ＜ｙ,0:ｘ＝ｙ,0より大:x＞ｙ</returns>
			/// <remarks>
			/// <br>Note       : オブジェクト同士を比較します。</br>
			/// <br>Programer  : 19077 渡邉貴裕</br>
			/// <br>Date       : 2006.05.30</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				if ((x is SlipDtlDisplayStatus) && (y is SlipDtlDisplayStatus))
				{
					return ((SlipDtlDisplayStatus)x).VisiblePosition - ((SlipDtlDisplayStatus)y).VisiblePosition;
				}

				return 0;
			}

			#endregion
		}
		#endregion

		//====================================================================================================
		//  プライベートメソッド
		//====================================================================================================
		#region プライベートメソッド
		/// <summary>
		/// 明細列表示ステータス検索
		/// </summary>
		/// <param name="_key">カラム名称</param>
		/// <returns>発見した明細列表示ステータス</returns>
		/// <remarks>
		/// <br>Note       : 明細列表示ステータスを検索します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private SlipDtlDisplayStatus SearchDisplayStatus(string _key)
		{
			if (mDetailStatus != null)
			{
				foreach (SlipDtlDisplayStatus _st in mDetailStatus)
				{
					if (_st.ColName == _key)
					{
						return _st;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// 指定された明細列の表示状況ステータスを初期化します。
		/// </summary>
		/// <param name="_key">初期化する列名</param>
		/// <remarks>
		/// <br>Note       : 指定された明細表示列の表示状況ステータスを初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private SlipDtlDisplayStatus InitializeStatus(string _key)
		{
			int _index = -1;

            // 商品コード
            if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }
            // 商品コード
			else if (_key == ctCOL_GoodsCode) { _index = ctINDX_GoodsCode; }
            // 商品ガイド
            else if (_key == ctCOL_GoodsGuide) { _index = ctINDX_GoodsGuide; }
            // 商品名称
			else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }
			// 機種
			else if (_key == ctCOL_CellphoneModelName) { _index = ctINDX_CellphoneModelName; }
			// 製造番号
			else if (_key == ctCOL_ProductNumber) { _index = ctINDX_ProductNumber; }
			// 携帯番号
			else if (_key == ctCOL_StockTelNo1) { _index = ctINDX_StockTelNo1; }
			// 仕入先
			else if (_key == ctCOL_CustomerName) { _index = ctINDX_CustomerName; }

            int _width = 0;
			Boolean _visible = false;

			if (_index != -1)
			{
				_width = CT_DEFAULTSTATUS[_index].Width;
				_visible = CT_DEFAULTSTATUS[_index].Visible;
			}

			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			if (_temp == null)
			{
				_temp = new SlipDtlDisplayStatus(_key, -1, _width, _visible);
				mDetailStatus.Add(_temp);
			}
			else
			{
				_temp.Width = _width;
				_temp.Visible = _visible;
				_temp.VisiblePosition = -1;
			}
			return _temp;
		}

		/// <summary>
		/// 指定された列の表示ステータスを取得する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <returns>true=表示,false=非表示</returns>
		/// <remarks>
		/// <br>Note       : 列の表示ステータス取得</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private Boolean GetVisible(string _key)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);

			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を戻す。
			return _temp.Visible;
		}

		/// <summary>
		/// 指定された列の表示ステータスを設定する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <param name="_value">true=表示,false=非表示</param>
		/// <remarks>
		/// <br>Note       : 列の表示ステータス設定</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private void SetVisible(string _key, Boolean _value)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を設定する。
			_temp.Visible = _value;
		}

		/// <summary>
		/// 指定された列の列幅を取得する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <returns>取得した列幅</returns>
		/// <remarks>
		/// <br>Note       : 列の列幅取得</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private int GetWidth(string _key)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を戻す。
			return _temp.Width;
		}

		/// <summary>
		/// 指定された列の列幅を設定する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <param name="_width">列幅</param>
		/// <remarks>
		/// <br>Note       : 列の列幅設定</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private void SetWidth(string _key, int _width)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を設定する。
			_temp.Width = _width;
		}

		/// <summary>
		/// 指定された列の表示位置を取得する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <returns>取得した列位置</returns>
		/// <remarks>
		/// <br>Note       : 列の列位置取得</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private int GetVisiblePosition(string _key)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を戻す。
			return _temp.VisiblePosition;
		}

		/// <summary>
		/// 指定された列の表示位置を設定する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <param name="_position">表示位置</param>
		/// <remarks>
		/// <br>Note       : 列の表示位置設定</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		private void SetVisiblePosition(string _key, int _position)
		{
			SlipDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を設定する。
			_temp.VisiblePosition = _position;
		}
		#endregion
	}
       --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
	
    /// <summary>
	/// 明細表示状況クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 伝票明細の表示状況を示すクラス</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2006.05.30</br>
	/// </remarks>
	[Serializable]
	public class SlipDtlDisplayStatus : ICloneable
	{
		#region コンストラクタ
		/// <summary>
		/// 明細表示状況クラスコンストラクタ
		/// </summary>
		public SlipDtlDisplayStatus()
		{ }

		/// <summary>
		/// 明細表示状況クラスコンストラクタ
		/// </summary>
		/// <param name="_colName">カラム名称</param>
		/// <param name="_position">表示位置</param>
		/// <param name="_width">列幅</param>
		/// <param name="_visible">表示／非表示</param>
		/// <remarks>
		/// <br>Note       : 明細表示状況クラスのインスタンスを作成し、初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public SlipDtlDisplayStatus(string _colName, int _position, int _width, Boolean _visible)
		{
			mColName = _colName;
			mOrder = _position;
			mWidth = _width;
			mVisible = _visible;
		}
		#endregion

		#region	プライベート変数
		/// <summary>
		/// 表示位置
		/// </summary>
		private int mOrder = -1;
		/// <summary>
		/// 列幅
		/// </summary>
		private int mWidth = -1;
		/// <summary>
		/// 表示/非表示
		/// </summary>
		private Boolean mVisible = false;
		/// <summary>
		/// カラム名称
		/// </summary>
		private string mColName = "";
		#endregion

		#region パブリックプロパティ
		/// <summary>
		/// 表示位置
		/// </summary>
		public int VisiblePosition
		{
			get { return this.mOrder; }
			set { this.mOrder = value; }
		}
		/// <summary>
		/// 列幅
		/// </summary>
		public int Width
		{
			get { return this.mWidth; }
			set { this.mWidth = value; }
		}
		/// <summary>
		/// 表示／非表示
		/// </summary>
		public Boolean Visible
		{
			get { return this.mVisible; }
			set { this.mVisible = value; }
		}
		/// <summary>
		/// カラム名称
		/// </summary>
		public string ColName
		{
			get { return this.mColName; }
			set { this.mColName = value; }
		}
		#endregion

		#region ICloneable メンバ
		/// <summary>
		/// 本クラスのコピー処理
		/// </summary>
		/// <returns>このクラスのクローン</returns>
		/// <remarks>
		/// <br>Note       : クラスのクローン処理</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public object Clone()
		{
			return new SlipDtlDisplayStatus(this.mColName, this.mOrder, this.mWidth, this.mVisible); ;
		}
		#endregion
	}
}
