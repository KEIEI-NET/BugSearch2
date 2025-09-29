using System;

namespace Broadleaf.Application.Common
{
	#region ■ IEstimateMDIChild　インターフェース
	/// <summary>
	/// ＭＤＩ子画面インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 検索見積ＭＤＩ子画面で実装しなければいけないメソッド定義です。</br>
	/// <br>Programer  : 21024　佐々木 健</br>
	/// <br>Date       : 2008.06.18</br>
	/// <br>Update Note:</br>
    /// <br>2009.03.26 20056 對馬 大輔 №12625 最新情報ボタン追加</br>
    /// </remarks>
	public interface IEstimateMDIChild
	{
		#region ◆ イベント
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
        /// <br>Date       : 2008.06.18</br>
		/// </remarks>
		event ParentToolbarLedgerSettingEventHandler ParentToolbarLedgerSettingEvent;
		#endregion

		#region ◆ メソッド
		/// <summary>
		/// Control.Show メソッドのオーバーロード
		/// </summary>
		/// <remarks>
		/// <br>Note       : object型の引数を受け取り、コントロールをユーザーに対して表示します。
		///					 引数を使用しない場合は、メソッド内に[this.show();]のみを記述して下さい。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
        /// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void Show(object[] parameters);

		/// <summary>
		/// 印刷処理
		/// </summary>
	    /// <returns></returns>
		/// <remarks>
        /// <br>Note       : 印刷処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
        int Print();

		/// <summary>
		/// 印刷前チェック処理
		/// </summary>
		/// <returns>[true:OK,false:NG]</returns>
		/// <remarks>
        /// <br>Note       : 印刷処理前チェックを行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		bool PrintBeforeCheack();

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void InitialScreen();

		/// <summary>
		/// フォーカス戻る処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォーカスを戻す処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void FocusSet_Return();

		/// <summary>
		/// フォーカス進む処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォーカスを進む処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void FocusSet_Forward();

		/// <summary>
		/// 新規作成
		/// </summary>
		/// <remarks>
		/// <br>Note       : 伝票新規作成処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void CreateNewSlip();

		/// <summary>
		/// 伝票削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 伝票削除処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void DeleteSlip();

		/// <summary>
		/// ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ガイド起動処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ExecuteGuide();

		/// <summary>
		/// 伝票呼出処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 伝票呼出処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ReadSlip();

		/// <summary>
		/// 伝票複写処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 伝票複写処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void CopySlip();

		/// <summary>
		/// 部品検索切替処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 部品検索切替処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ChangePartsSearch();

		/// <summary>
		/// 画面切替処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面切替を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ChangeDisplay();

		/// <summary>
		/// 結合登録処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 結合登録処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void EntryJoinParts();

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 元に戻す処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void Undo();

		/// <summary>
		/// 発注選択
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注選択処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void OrderSelect();

		/// <summary>
		/// セット表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : セット表示処理を行います。</br>
		/// <br>Programer  : 21024 佐々木 健</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ShowSet();

        // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 最新情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 最新情報の取得を行います。</br>
        /// <br>Programer  : 20056 對馬 大輔</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        void ReNewal();
        // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

		#region ◆ プロパティ

		/// <summary>
		/// 戻るボタン有効無効プロパティ
		/// </summary>
		bool CanReturnButton { get;}

		/// <summary>
		/// 進むボタン有効無効プロパティ
		/// </summary>
		bool CanForwardButton { get;}

		/// <summary>
		/// 印刷ボタン有効無効プロパティ
		/// </summary>
		bool CanPrintButton { get;}

		/// <summary>
		/// 新規ボタン有効無効プロパティ
		/// </summary>
		bool CanNewButton { get;}

		/// <summary>
		/// 伝票削除ボタン有効無効プロパティ
		/// </summary>
		bool CanDeleteSlipButton { get;}

		/// <summary>
		/// 取消ボタン有効無効プロパティ
		/// </summary>
		bool CanUndoButton { get;}

		/// <summary>
		/// ガイドボタン有効無効プロパティ
		/// </summary>
		bool CanGuideButton { get;}

		/// <summary>
		/// 伝票呼出ボタン有効無効プロパティ
		/// </summary>
		bool CanReadSlipButton { get;}

		/// <summary>
		/// 伝票複写ボタン有効無効プロパティ
		/// </summary>
		bool CanCopySlipButton { get;}

		/// <summary>
		/// 部品検索切替ボタン有効無効プロパティ
		/// </summary>
		bool CanChangePartsSearchButton { get;}

		/// <summary>
		/// 結合登録ボタン有効無効プロパティ
		/// </summary>
		bool CanEntryJoinPartsButton { get;}

		/// <summary>
		/// 発注選択ボタン有効無効プロパティ
		/// </summary>
		bool CanOrderSelectButton { get;}

		/// <summary>
		/// 画面切替ボタン有効無効プロパティ
		/// </summary>
		bool CanChangeDisplayButton { get;}

		/// <summary>
		/// セットボタン有効無効プロパティ
		/// </summary>
		bool CanShowSetButton { get;}

        // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 最新情報ボタン有効無効プロパティ
        /// </summary>
        bool CanReNewalButton { get;}
        // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion
	}
	#endregion

	#region ◆ デリゲート     
	/// <summary>
	/// ツールバーボタン制御
	/// </summary>
    /// <param name="sender">顧客車両選択パラメータ</param>
	/// <remarks>
    /// <br>Note       : 画面の初期化を行います。</br>
	/// <br>Programer  : 21024 佐々木 健</br>
	/// <br>Date       : 2008.06.18</br>
	/// </remarks>
	public delegate void ParentToolbarLedgerSettingEventHandler(object sender);
	#endregion

	# region ◆ 列挙型
	# endregion
}

