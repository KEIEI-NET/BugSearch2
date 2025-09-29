//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 全体項目表示設定
// プログラム概要   : 全体項目表示設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 秋山　亮介
// 作 成 日  2006/02/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : T.Kimura
// 修 正 日  2007/02/06  修正内容 : MA.NS用に変更（画面スキン変更対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 修 正 日  2008/06/05  修正内容 : PM.NS用に項目追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 全体項目表示設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 全体項目表示名称設定の設定を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2006.08.29</br>
	/// <br></br>
	/// <br>			: 2007.02.06 18322 T.Kimura MA.NS用に変更</br>
	/// <br>			:                           ・画面スキン変更対応</br>
    /// <br>Update Note : 2008.06.05 30413 犬飼</br>
    /// <br>              ・PM.NS用に項目追加</br>
	/// </remarks>
	public partial class SFCMN09160UA : Form, IMasterMaintenanceSingleType
	{
		#region << Constructor >>

		/// <summary>
		/// 全体項目表示設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 全体項目表示設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		public SFCMN09160UA()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode  = LoginInfoAcquisition.EnterpriseCode;

			// 全体項目表示名称テーブルアクセスクラス
			this._alItmDspNmAcs   = new AlItmDspNmAcs();

			// 比較用クローン
			this._alItmDspNmClone = null;

			// プロパティの初期設定
			this._canPrint        = false;
			this._canClose        = false;
		}

		#endregion

		#region << Private Members >>

		private AlItmDspNmAcs _alItmDspNmAcs;     // 全体項目表示名称テーブルアクセスクラス
		private AlItmDspNm    _alItmDspNm;        // 全体項目表示名称データクラス

		private string        _enterpriseCode;    // 企業コード

		// 比較用クローン
		private AlItmDspNm    _alItmDspNmClone;   // 比較用全体項目表示名称クラス

		// プロパティ用
		private bool          _canPrint;
		private bool          _canClose;

		private const string  HTML_HEADER_TITLE = "設定項目";
		private const string  HTML_HEADER_VALUE = "設定値";
		private const string  HTML_UNREGISTER   = "未設定";

		// 編集モード
		private const string  UPDATE_MODE		= "更新モード";

		private const string  CT_PGID           = "SFCMN09160U";
		private const string  CT_PGNM           = "全体項目表示名称設定";

        // ↓ 20070206 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070206 18322 a

		#endregion

		#region << Events >>

		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;

		# endregion

		#region << Properties >>

		/// <summary>
		/// 印刷プロパティ
		/// </summary>
		/// <remarks>
		/// 印刷可能かどうかの設定を取得します。（false固定）
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
		}

		/// <summary>
		/// 画面クローズプロパティ
		/// </summary>
		/// <remarks>
		/// 画面クローズを許可するかどうかの設定を取得または設定します。
		/// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}

		#endregion

		#region << Public Methods >>

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 未実装</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		public int Print()
		{
			// 印刷アセンブリをロードする（未実装）
			return 0;
		}

		/// <summary>
		/// HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note       : HTMLコードの取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			const string ctPROCNM = "GetHtmlCode";
			string outCode = "";

			// tHtmlGenerate部品の引数を生成する
			List<string> titleList = new List<string>();
			List<string> valueList = new List<string>();
			titleList.Add( HTML_HEADER_TITLE );							// 「設定項目」
			valueList.Add( HTML_HEADER_VALUE );							// 「設定値」

			// 設定項目タイトル設定
			titleList.Add( this.HomeTelNoDspName_Title_Label.Text );      // 自宅TEL表示名称
			titleList.Add( this.OfficeTelNoDspName_Title_Label.Text );    // 勤務先TEL表示名称
			titleList.Add( this.MobileTelNoDspName_Title_Label.Text );    // 携帯TEL表示名称
			titleList.Add( this.OtherTelNoDspName_Title_Label.Text );     // その他TEL表示名称
			titleList.Add( this.HomeFaxNoDspName_Title_Label.Text );      // 自宅FAX表示名称
			titleList.Add( this.OfficeFaxNoDspName_Title_Label.Text );    // 勤務先FAX表示名称
			titleList.Add( this.AddInfo1DspName_Title_Label.Text );       // 追加情報1表示名称
			titleList.Add( this.AddInfo2DspName_Title_Label.Text );       // 追加情報2表示名称
			titleList.Add( this.AddInfo3DspName_Title_Label.Text );       // 追加情報3表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            titleList.Add(this.JoinDspName_Title_Label.Text);           // 結合表示名称
            titleList.Add(this.StockRateDspName_Title_Label.Text);      // 仕入率表示名称
            titleList.Add(this.UnitCostDspName_Title_Label.Text);       // 原単価表示名称
            titleList.Add(this.ProfitDspName_Title_Label.Text);         // 粗利額表示名称
            titleList.Add(this.ProfitRateDspName_Title_Label.Text);     // 粗利率表示名称
            titleList.Add(this.OutTaxDspName_Title_Label.Text);         // 外税表示名称
            titleList.Add(this.InTaxDspName_Title_Label.Text);          // 内税表示名称
            titleList.Add(this.ListPriceDspName_Title_Label.Text);      // 価格表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END
            
			// 全体項目表示名称設定データ取得
			int status = 0;
			status = this._alItmDspNmAcs.Read( out this._alItmDspNm, this._enterpriseCode );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					
					// 全体項目表示名称取得データ設定
					if( this._alItmDspNm != null ) {
						valueList.Add( this._alItmDspNm.HomeTelNoDspName );
						valueList.Add( this._alItmDspNm.OfficeTelNoDspName );
						valueList.Add( this._alItmDspNm.MobileTelNoDspName );
						valueList.Add( this._alItmDspNm.OtherTelNoDspName );
						valueList.Add( this._alItmDspNm.HomeFaxNoDspName );
						valueList.Add( this._alItmDspNm.OfficeFaxNoDspName );
						valueList.Add( this._alItmDspNm.AddInfo1DspName );
						valueList.Add( this._alItmDspNm.AddInfo2DspName );
						valueList.Add( this._alItmDspNm.AddInfo3DspName );
                        // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
                        valueList.Add(this._alItmDspNm.JoinDspName);
                        valueList.Add(this._alItmDspNm.StockRateDspName);
                        valueList.Add(this._alItmDspNm.UnitCostDspName);
                        valueList.Add(this._alItmDspNm.ProfitDspName);
                        valueList.Add(this._alItmDspNm.ProfitRateDspName);
                        valueList.Add(this._alItmDspNm.OutTaxDspName);
                        valueList.Add(this._alItmDspNm.InTaxDspName);
                        valueList.Add(this._alItmDspNm.ListPriceDspName);
                        // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END
					}
					else {
						// 未設定
						for( int ix = 0; ix < titleList.Count; ix++ ) {
							valueList.Add( HTML_UNREGISTER );
						}
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 未設定
					for( int ix = 0; ix < titleList.Count; ix++ ) {
						valueList.Add( HTML_UNREGISTER );
					}
					break;
				}
				default:
				{
					// リード
					TMsgDisp.Show( 
						this,                                 // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
						CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
						CT_PGNM,                              // プログラム名称
						ctPROCNM,                             // 処理名称
						TMsgDisp.OPE_READ,                    // オペレーション
						"読み込みに失敗しました。",           // 表示するメッセージ
						status,                               // ステータス値
						this._alItmDspNmAcs,                  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,                 // 表示するボタン
						MessageBoxDefaultButton.Button1 );    // 初期表示ボタン

					// 未設定
					for( int ix = 0; ix < titleList.Count; ix++ ) {
						valueList.Add( HTML_UNREGISTER );
					}
					break;
				}
			}

			this.tHtmlGenerate1.Coltypes = new int[ 2 ];
			this.tHtmlGenerate1.Coltypes[ 0 ] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[ 1 ] = this.tHtmlGenerate1.ColtypeString;

			// 配列にコピー
            string [,] array = new string[ titleList.Count, 2 ];
			for( int ix = 0; ix < array.GetLength( 0 ); ix++ ) {
				array[ ix, 0 ] = titleList[ ix ];
				array[ ix, 1 ] = valueList[ ix ];
			}
           
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty( array, ref outCode );

			return outCode;
		}

		#endregion

		#region << Private Methods >>

		/// <summary>
		/// 画面初期設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : UI画面の初期設定を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
		}

		/// <summary>
		/// 画面情報全体項目表示名称クラス格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void ScreenToAlItmDspNm()
		{
			if( this._alItmDspNm == null ) {
				// 新規の場合
				this._alItmDspNm = new AlItmDspNm();
			}

			this._alItmDspNm.HomeTelNoDspName   = this.HomeTelNoDspName_tEdit.Text.TrimEnd();      // 自宅TEL表示名称
			this._alItmDspNm.OfficeTelNoDspName = this.OfficeTelNoDspName_tEdit.Text.TrimEnd();    // 勤務先TEL表示名称
			this._alItmDspNm.MobileTelNoDspName = this.MobileTelNoDspName_tEdit.Text.TrimEnd();    // 携帯TEL表示名称
			this._alItmDspNm.OtherTelNoDspName  = this.OtherTelNoDspName_tEdit.Text.TrimEnd();     // その他TEL表示名称
			this._alItmDspNm.HomeFaxNoDspName   = this.HomeFaxNoDspName_tEdit.Text.TrimEnd();      // 自宅FAX表示名称
			this._alItmDspNm.OfficeFaxNoDspName = this.OfficeFaxNoDspName_tEdit.Text.TrimEnd();    // 勤務先FAX表示名称
			this._alItmDspNm.AddInfo1DspName    = this.AddInfo1DspName_tEdit.Text.TrimEnd();       // 追加情報1表示名称
			this._alItmDspNm.AddInfo2DspName    = this.AddInfo2DspName_tEdit.Text.TrimEnd();       // 追加情報2表示名称
			this._alItmDspNm.AddInfo3DspName    = this.AddInfo3DspName_tEdit.Text.TrimEnd();       // 追加情報3表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            this._alItmDspNm.JoinDspName = this.JoinDspName_tEdit.Text.TrimEnd();                   // 結合表示名称
            this._alItmDspNm.StockRateDspName = this.StockRateDspName_tEdit.Text.TrimEnd();         // 仕入率表示名称
            this._alItmDspNm.UnitCostDspName = this.UnitCostDspName_tEdit.Text.TrimEnd();           // 原単価表示名称
            this._alItmDspNm.ProfitDspName = this.ProfitDspName_tEdit.Text.TrimEnd();               // 粗利額表示名称
            this._alItmDspNm.ProfitRateDspName = this.ProfitRateDspName_tEdit.Text.TrimEnd();       // 粗利率表示名称
            this._alItmDspNm.OutTaxDspName = this.OutTaxDspName_tEdit.Text.TrimEnd();               // 外税表示名称
            this._alItmDspNm.InTaxDspName = this.InTaxDspName_tEdit.Text.TrimEnd();                 // 内税表示名称
            this._alItmDspNm.ListPriceDspName = this.ListPriceDspName_tEdit.Text.TrimEnd();         // 価格表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END
		}

		/// <summary>
		/// 画面情報全体項目表示名称クラス格納処理(チェック用)
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から全体項目表示名称クラスにデータを格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void DispToAlItmDspNm( ref AlItmDspNm alItmDspNm )
		{
			if( alItmDspNm == null ) {
				// 新規の場合
				alItmDspNm = new AlItmDspNm();
			}

			alItmDspNm.HomeTelNoDspName   = this.HomeTelNoDspName_tEdit.Text.TrimEnd();      // 自宅TEL表示名称
			alItmDspNm.OfficeTelNoDspName = this.OfficeTelNoDspName_tEdit.Text.TrimEnd();    // 勤務先TEL表示名称
			alItmDspNm.MobileTelNoDspName = this.MobileTelNoDspName_tEdit.Text.TrimEnd();    // 携帯TEL表示名称
			alItmDspNm.OtherTelNoDspName  = this.OtherTelNoDspName_tEdit.Text.TrimEnd();     // その他TEL表示名称
			alItmDspNm.HomeFaxNoDspName   = this.HomeFaxNoDspName_tEdit.Text.TrimEnd();      // 自宅FAX表示名称
			alItmDspNm.OfficeFaxNoDspName = this.OfficeFaxNoDspName_tEdit.Text.TrimEnd();    // 勤務先FAX表示名称
			alItmDspNm.AddInfo1DspName    = this.AddInfo1DspName_tEdit.Text.TrimEnd();       // 追加情報1表示名称
			alItmDspNm.AddInfo2DspName    = this.AddInfo2DspName_tEdit.Text.TrimEnd();       // 追加情報2表示名称
			alItmDspNm.AddInfo3DspName    = this.AddInfo3DspName_tEdit.Text.TrimEnd();       // 追加情報3表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            alItmDspNm.JoinDspName = this.JoinDspName_tEdit.Text.TrimEnd();                   // 結合表示名称
            alItmDspNm.StockRateDspName = this.StockRateDspName_tEdit.Text.TrimEnd();         // 仕入率表示名称
            alItmDspNm.UnitCostDspName = this.UnitCostDspName_tEdit.Text.TrimEnd();           // 原単価表示名称
            alItmDspNm.ProfitDspName = this.ProfitDspName_tEdit.Text.TrimEnd();               // 粗利額表示名称
            alItmDspNm.ProfitRateDspName = this.ProfitRateDspName_tEdit.Text.TrimEnd();       // 粗利率表示名称
            alItmDspNm.OutTaxDspName = this.OutTaxDspName_tEdit.Text.TrimEnd();               // 外税表示名称
            alItmDspNm.InTaxDspName = this.InTaxDspName_tEdit.Text.TrimEnd();                 // 内税表示名称
            alItmDspNm.ListPriceDspName = this.ListPriceDspName_tEdit.Text.TrimEnd();         // 価格表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END
		}

		/// <summary>
		/// 画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称クラスから画面にデータを展開します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void AlItmDspNmToScreen()
		{
			this.HomeTelNoDspName_tEdit.Text   = this._alItmDspNm.HomeTelNoDspName;      // 自宅TEL表示名称
			this.OfficeTelNoDspName_tEdit.Text = this._alItmDspNm.OfficeTelNoDspName;    // 勤務先TEL表示名称
			this.MobileTelNoDspName_tEdit.Text = this._alItmDspNm.MobileTelNoDspName;    // 携帯TEL表示名称
			this.OtherTelNoDspName_tEdit.Text  = this._alItmDspNm.OtherTelNoDspName;     // その他TEL表示名称
			this.HomeFaxNoDspName_tEdit.Text   = this._alItmDspNm.HomeFaxNoDspName;      // 自宅FAX表示名称
			this.OfficeFaxNoDspName_tEdit.Text = this._alItmDspNm.OfficeFaxNoDspName;    // 勤務先FAX表示名称
			this.AddInfo1DspName_tEdit.Text    = this._alItmDspNm.AddInfo1DspName;       // 追加情報1表示名称
			this.AddInfo2DspName_tEdit.Text    = this._alItmDspNm.AddInfo2DspName;       // 追加情報2表示名称
			this.AddInfo3DspName_tEdit.Text    = this._alItmDspNm.AddInfo3DspName;       // 追加情報3表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            this.JoinDspName_tEdit.Text = this._alItmDspNm.JoinDspName;                     // 結合表示名称
            this.StockRateDspName_tEdit.Text = this._alItmDspNm.StockRateDspName;         // 仕入率表示名称
            this.UnitCostDspName_tEdit.Text = this._alItmDspNm.UnitCostDspName;           // 原単価表示名称
            this.ProfitDspName_tEdit.Text = this._alItmDspNm.ProfitDspName;               // 粗利額表示名称
            this.ProfitRateDspName_tEdit.Text = this._alItmDspNm.ProfitRateDspName;       // 粗利率表示名称
            this.OutTaxDspName_tEdit.Text = this._alItmDspNm.OutTaxDspName;               // 外税表示名称
            this.InTaxDspName_tEdit.Text = this._alItmDspNm.InTaxDspName;                 // 内税表示名称
            this.ListPriceDspName_tEdit.Text = this._alItmDspNm.ListPriceDspName;         // 価格表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.HomeTelNoDspName_tEdit.Clear();      // 自宅TEL表示名称
			this.OfficeTelNoDspName_tEdit.Clear();    // 勤務先TEL表示名称
			this.MobileTelNoDspName_tEdit.Clear();    // 携帯TEL表示名称
			this.OtherTelNoDspName_tEdit.Clear();     // その他TEL表示名称
			this.HomeFaxNoDspName_tEdit.Clear();      // 自宅FAX表示名称
			this.OfficeFaxNoDspName_tEdit.Clear();    // 勤務先FAX表示名称
			this.AddInfo1DspName_tEdit.Clear();       // 追加情報1表示名称
			this.AddInfo2DspName_tEdit.Clear();       // 追加情報2表示名称
			this.AddInfo3DspName_tEdit.Clear();       // 追加情報3表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            this.JoinDspName_tEdit.Clear();         // 結合表示名称
            this.StockRateDspName_tEdit.Clear();    // 仕入率表示名称
            this.UnitCostDspName_tEdit.Clear();     // 原単価表示名称
            this.ProfitDspName_tEdit.Clear();       // 粗利額表示名称
            this.ProfitRateDspName_tEdit.Clear();   // 粗利率表示名称
            this.OutTaxDspName_tEdit.Clear();       // 外税表示名称
            this.InTaxDspName_tEdit.Clear();        // 内税表示名称
            this.ListPriceDspName_tEdit.Clear();    // 価格表示名称
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面を再構築します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			const string ctPROCNM = "ScreenReconstruction";
			int status = 0;

			this._alItmDspNm = new AlItmDspNm();

			// 全体項目表示名称データ取得
			status = this._alItmDspNmAcs.Read( out this._alItmDspNm, this._enterpriseCode );

			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				if( this._alItmDspNm == null ) {
					this._alItmDspNm = new AlItmDspNm();
				}

				this.Mode_Label.Text = UPDATE_MODE;

				// 全体項目表示名称画面展開処理
				this.AlItmDspNmToScreen();
				// 比較用クローン作成
				this._alItmDspNmClone = this._alItmDspNm.Clone();
				// 画面情報を比較用クローンにコピー
				this.DispToAlItmDspNm( ref this._alItmDspNmClone );

				// 初期フォーカスをセット
				this.HomeTelNoDspName_tEdit.Focus();
			}
			else {
				// リード
				TMsgDisp.Show( 
					this,                                 // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
					CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
					CT_PGNM,                              // プログラム名称
					ctPROCNM,                             // 処理名称
					TMsgDisp.OPE_READ,                    // オペレーション
					"読み込みに失敗しました。",           // 表示するメッセージ
					status,                               // ステータス値
					this._alItmDspNmAcs,                  // エラーが発生したオブジェクト
					MessageBoxButtons.OK,                 // 表示するボタン
					MessageBoxDefaultButton.Button1 );    // 初期表示ボタン

				this.Mode_Label.Text = UPDATE_MODE;

				this._alItmDspNm = new AlItmDspNm();

				// 全体項目表示名称画面展開処理
				this.AlItmDspNmToScreen();
				// 比較用クローン作成
				this._alItmDspNmClone = this._alItmDspNm.Clone();
				// 画面情報を比較用クローンにコピー
				this.DispToAlItmDspNm( ref this._alItmDspNmClone );

				// 初期フォーカスをセット
				this.HomeTelNoDspName_tEdit.Focus();
			}
		}

		/// <summary>
		/// 画面入力チェック処理
		/// </summary>
		/// <param name="control">対象コントロール</param>
		/// <param name="message">表示メッセージ</param>
		/// <returns>チェック結果(true: OK, false:NG)</returns>
		/// <remarks>
		/// <br>Note       : 画面の入力チェックを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
        /// <br>Update Note: 30413 犬飼</br>
        /// <br>             ・PM.NS対応（必須入力項目チェック追加）</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            // 結合表示名称
            if (this.JoinDspName_tEdit.Text.Trim() == "")
            {
                control = this.JoinDspName_tEdit;
                message = this.JoinDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 仕入率表示名称
            if (this.StockRateDspName_tEdit.Text.Trim() == "")
            {
                control = this.StockRateDspName_tEdit;
                message = this.StockRateDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 原単価表示名称
            if (this.UnitCostDspName_tEdit.Text.Trim() == "")
            {
                control = this.UnitCostDspName_tEdit;
                message = this.UnitCostDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 粗利額表示名称
            if (this.ProfitDspName_tEdit.Text.Trim() == "")
            {
                control = this.ProfitDspName_tEdit;
                message = this.ProfitDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 粗利率表示名称
            if (this.ProfitRateDspName_tEdit.Text.Trim() == "")
            {
                control = this.ProfitRateDspName_tEdit;
                message = this.ProfitRateDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 価格表示名称
            if (this.ListPriceDspName_tEdit.Text.Trim() == "")
            {
                control = this.ListPriceDspName_tEdit;
                message = this.ListPriceDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 外税表示名称
            if (this.OutTaxDspName_tEdit.Text.Trim() == "")
            {
                control = this.OutTaxDspName_tEdit;
                message = this.OutTaxDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

            // 内税表示名称
            if (this.InTaxDspName_tEdit.Text.Trim() == "")
            {
                control = this.InTaxDspName_tEdit;
                message = this.InTaxDspName_Title_Label.Text + "を入力して下さい。";
                return false;
            }

			return result;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>結果</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称の保存を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private bool SaveProc()
		{
			const string ctPROCNM = "SaveProc";
			bool result = false;

			Control control = null;
			string message = null;
			if( this.ScreenDataCheck( ref control, ref message ) == false ) {
				// 入力チェック
				TMsgDisp.Show( 
					this,                                  // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
					CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
					message,                               // 表示するメッセージ
					0,                                     // ステータス値
					MessageBoxButtons.OK );                // 表示するボタン

				// コントロールを選択
				control.Focus();
				if( control is TEdit ) {
					( ( TEdit )control ).SelectAll();
				}
				if( control is TNedit ) {
					( ( TNedit )control ).SelectAll();
				}
                // 2008.06.06 30413 犬飼 入力チェックNGの場合は処理終了 >>>>>>START
                return false;
                // 2008.06.06 30413 犬飼 入力チェックNGの場合は処理終了 <<<<<<END
			}

			// 画面から全体項目表示名称のデータを取得
			this.ScreenToAlItmDspNm();

			int status = 0;
			status = this._alItmDspNmAcs.Write( ref this._alItmDspNm );

			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					result = true;
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// コード重複
					TMsgDisp.Show( 
						this,                                    // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,             // エラーレベル
						CT_PGID,                                 // アセンブリＩＤまたはクラスＩＤ
						"このコードは既に使用されています。",    // 表示するメッセージ
						0,                                       // ステータス値
						MessageBoxButtons.OK );                  // 表示するボタン

					return result;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					this.ExclusiveTransaction( status, true );
					return result;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show( 
						this,                                 // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
						CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
						CT_PGNM,                              // プログラム名称
						ctPROCNM,                             // 処理名称
						TMsgDisp.OPE_READ,                    // オペレーション
						"登録に失敗しました。",           // 表示するメッセージ
						status,                               // ステータス値
						this._alItmDspNmAcs,                  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,                 // 表示するボタン
						MessageBoxDefaultButton.Button1 );    // 初期表示ボタン

					this.CloseForm( DialogResult.Cancel );

					return result;
				}
			}

			return result;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
		/// <remarks>
		/// <br>Note       : 排他処理を行います</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this,                                  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
						CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。",    // 表示するメッセージ
						0,                                     // ステータス値
						MessageBoxButtons.OK );                // 表示するボタン
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this,                                  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
						CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。",    // 表示するメッセージ
						0,                                     // ステータス値
						MessageBoxButtons.OK );                // 表示するボタン
					if( hide == true ) {
						this.CloseForm( DialogResult.Cancel );
					}
					break;
				}
			}
		}

		/// <summary>
		/// フォームクローズ処理
		/// </summary>
		/// <param name="dialogResult">ダイアログ結果</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void CloseForm( DialogResult dialogResult )
		{
			// 画面非表示イベント
			if ( this.UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				this.UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// 比較用クローンクリア
			this._alItmDspNmClone = null;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		#endregion

		#region << Control Events >>

		/// <summary>
		/// Form.Load イベント (SFCMN09160UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void SFCMN09160UA_Load( object sender, EventArgs e )
		{
            // ↓ 20070206 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070206 18322 a

			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList            = imageList24;           // 保存ボタン
			this.Cancel_Button.ImageList        = imageList24;           // 閉じるボタン

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;     // 保存ボタン
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン

			// 画面初期化
			this.ScreenInitialSetting();
		}

		/// <summary>
		/// Form.FormClosing イベント (SFCMN09160UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void SFCMN09160UA_FormClosing( object sender, FormClosingEventArgs e )
		{
			// チェック用クローン初期化
			this._alItmDspNmClone = null;

			// ユーザーによって閉じられる場合
			if( e.CloseReason == CloseReason.UserClosing ) {
				// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
				if( this._canClose == false ) {
					e.Cancel = true;
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Form.VisibleChanged イベント (SFCMN09160UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void SFCMN09160UA_VisibleChanged( object sender, EventArgs e )
		{
			if( this.Visible == false ) {
				this.Owner.Activate();
				return;
			}

			// データがセットされていたら抜ける
			if( this._alItmDspNmClone != null ) {
				return;
			}

			this.Initial_Timer.Enabled = true;
			// 画面クリア
			this.ScreenClear();
		}

		/// <summary>
		/// Timer.Tick イベント (Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void Initial_Timer_Tick( object sender, EventArgs e )
		{
			this.Initial_Timer.Enabled = false;

			this.ScreenReconstruction();
		}

		/// <summary>
		/// UltraButton.Click イベント (Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void Ok_Button_Click( object sender, EventArgs e )
		{
			if( this.SaveProc() == false ) {
				return;
			}

			// フォームを閉じる
			this.CloseForm( DialogResult.OK );
		}

		/// <summary>
		/// UltraButton.Click イベント (Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.29</br>
		/// </remarks>
		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			DialogResult result = DialogResult.Cancel;

			AlItmDspNm compareAlItmDspNm = new AlItmDspNm();
			compareAlItmDspNm = this._alItmDspNmClone.Clone();
			this.DispToAlItmDspNm( ref compareAlItmDspNm );

			if( compareAlItmDspNm.Equals( this._alItmDspNmClone ) == false ) {
				// 画面情報が変更されていた場合は、保存確認メッセージを表示する
				// 保存確認
				DialogResult res = TMsgDisp.Show( 
					this,                                  // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // エラーレベル
					CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
					null,                                  // 表示するメッセージ
					0,                                     // ステータス値
					MessageBoxButtons.YesNoCancel );       // 表示するボタン
				switch( res ) {
					case DialogResult.Yes:
					{
						if( this.SaveProc() == false ) {
							return;
						}
						result = DialogResult.OK;
						break;
					}
					case DialogResult.No:
					{
						break;
					}
					default:
					{
						this.Cancel_Button.Focus();
						return;
					}
				}
			}

			// 画面を閉じる
			this.CloseForm( result );
		}

		#endregion
	}
}