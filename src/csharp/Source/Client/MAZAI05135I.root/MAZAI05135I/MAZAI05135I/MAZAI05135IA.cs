//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸入力用インターフェース。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 作 成 日  2007/04/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/25  修正内容 : ツールバーボタン制御イベント、デリゲート追加
//　　　　　　　　　　　　　　　　　修正ボタンEnableプロパティ追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]　BeforeSave()追加
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 陳嘯
// 修 正 日  2015/04/27 修正内容 : Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
//                                  Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 棚卸数入力インターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note		: 棚卸数入力用インターフェースの定義</br>
    /// <br>Programer	: 22013 kubo</br>
    /// <br>Date		: 2007.04.05</br>
    /// <br>Update Note	: 2007.07.25 22013 kubo </br>
    /// <br>			:	・ツールバーボタン制御イベント、デリゲート追加 </br>
    /// <br>			:	・修正ボタンEnableプロパティ追加</br>
    /// <br>            : 2009/05/14 照田 貴志　不具合対応[13260]　BeforeSave()追加</br>
	/// </remarks>
	public interface IInventInputMdiChild
	{
		#region ◆ イベント
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;
		#endregion

		#region ◆ Public Property
		/// <summary> 企業コードプロパティ </summary>
		string EnterpriseCode { set; }

		/// <summary> ログイン拠点コードプロパティ </summary>
		string SectionCode { set; }

		/// <summary> ログイン拠点名称プロパティ </summary>
		string SectionName { set; }

		/// <summary> 取消ボタンEnableプロパティ </summary>
		bool IsCansel { get; }

		/// <summary> 抽出ボタンEnableプロパティ </summary>
		bool IsExtract { get; }

		/// <summary> 保存ボタンEnableプロパティ </summary>
		bool IsSave { get; }

		/// <summary> 詳細表示ボタンEnableプロパティ </summary>
		bool IsDetail { get; }

		/// <summary> 新規棚卸ボタンEnableプロパティ </summary>
		bool IsNewInvent { get; }

		/// <summary> バーコード取込ボタンEnableプロパティ </summary>
		bool IsBarcodeRead { get; }

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する ----->>>>>
        /// <summary> 品番検索ボタンEnableプロパティ </summary>
        bool IsGoodsSearch { get; }
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する -----<<<<<

		/// <summary> 修正ボタンEnableプロパティ </summary>
		bool IsDataEdit { get; }

		#endregion ◆ Property

		#region ◆ Public Method
		///// <summary>
		///// Control.Show メソッドのオーバーロード
		///// </summary>
		///// <param name="parameter">パラメータオブジェクト</param>
		///// <remarks>
		///// <br>Note       : object型の引数を受け取り、コントロールをユーザーに対して表示する。
		/////					 引数を使用しない場合は、メソッド内に[this.show();]のみを記述して下さい。</br>
		///// <br>Programer  : 22013 kubo</br>
		///// <br>Date       : 2007.04.05</br>
		///// </remarks>
		//void Show(object parameter);

		/// <summary>
		/// 表示通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝正常, 0≠異常</param>
		/// <remarks>
		/// <br>Note       : ＭＤＩ親画面から表示指示を行った場合に発生するイベント</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	ShowData(object parameter);

		/// <summary>
		/// タブ変更前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG タブ変更不可</param>
		/// <remarks>
		/// <br>Note       : タブ変更が行われる前に、変更を許可するかの判断を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeTabChange(object parameter);

		/// <summary>
		/// 終了前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 終了する前に、変更を許可するかの判断を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeClose(object parameter);

		/// <summary>
		/// 抽出前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 抽出する前に、変更を許可するかの判断を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeExtract(object parameter);

		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 抽出処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	Extract(ref object parameter);

		/// <summary>
		/// 取消前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 取消する前に、変更を許可するかの判断を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeCansel(object parameter);

		/// <summary>
		/// 取消処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 取消処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	Cansel(object parameter);

        // ---ADD 2009/05/14 不具合対応[13260] ----------------------------->>>>>
        /// <summary>
        /// 保存前処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <returns>0＝OK, 0≠NG</returns>
        /// <remarks>
        /// <br>Note       : 保存する前に、保存を許可するかの判断を行う</br>
        /// <br>Programer  : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks>
        int BeforeSave(object parameter);
        // ---ADD 2009/05/14 不具合対応[13260] -----------------------------<<<<<

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 保存処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	Save(object parameter);

		/// <summary>
		/// 詳細表示処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 詳細表示処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	ShowDetail(object parameter);

		/// <summary>
		/// 新規棚卸データ作成処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 新規棚卸データ作成処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	NewInvent(object parameter);

		/// <summary>
		/// バーコード読み込み処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : バーコード読み込み処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BarcodeRead(object parameter);

		/// <summary>
		/// 修正処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK, 0≠NG</param>
		/// <remarks>
		/// <br>Note       : 選択行の修正を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		int	DataEdit(object parameter);

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する ----->>>>>
        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 品番検索を行う</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 品番検索を追加</br>
        /// </remarks>
        int GoodsSearch(object parameter);
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する -----<<<<<

        // --- ADD 陳嘯 2015/04/27 Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する ----->>>>>
        /// <summary>
        /// 閉じる前チェック
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <param return="int">0＝OK, 0≠NG</param>
        /// <remarks>
        /// <br>Note       : 閉じる前チェックを行う</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/29</br>
        /// <br>管理番号   : 11070149-00 2015/04/29 閉じる前チェックを追加</br>
        /// </remarks>
        bool ClosingCheck();
        // --- ADD 陳嘯 2015/04/27 Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する -----<<<<<

		#endregion ◆ Public Method



	}
	#region ◆ デリゲート     
	/// <summary>
	/// ツールバーボタン制御
	/// </summary>
    /// <param name="targetForm">顧客車両選択パラメータ</param>
	/// <remarks>
    /// <br>Note       : 画面の初期化を行います。</br>
	/// <br>Programer  : 22013 kubo</br>
	/// <br>Date       : 2007.07.25</br>
	/// </remarks>
	public delegate void ParentToolbarInventSettingEventHandler(object targetForm);
	#endregion

}
