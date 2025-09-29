using System;
using System.Collections;

namespace Broadleaf.Application.Common
{
	#region IDepositInputMDIChild 入金入力系のＭＤＩ子画面で実装しなければいけないメソッド定義
	/// <summary>
	/// ＭＤＩ子画面インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金入力系のＭＤＩ子画面で実装しなければいけないメソッド定義です。</br>
	/// <br>Programer  : 97036 amami</br>
	/// <br>Date       : 2005.07.30</br>
	/// <br>Update Note: 2008.02.21 20081 疋田 勇人 DC.NS用に変更</br>
    /// <br>Update Note: 2012/12/24 王君</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33741の対応</br>
	/// </remarks>
	public interface IDepositInputMDIChild
	{
		#region Event
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		event ParentToolbarDepositSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// 選択拠点取得イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		event GetDepositSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

        /// <summary>
        /// 計上拠点名称イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : メイン画面で取得した計上拠点名称をフレームに渡します。</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.02.20</br>
        /// </remarks>
        event HandOverDepositAddUpSecNameEventHandler HandOverAddUpSecNameEvent;
		#endregion

		# region Property
		/// <summary>新規ボタン有効無効プロパティ</summary>
		bool NewButton		{get;}

		/// <summary>保存ボタン有効無効プロパティ</summary>
		bool SaveButton		{get;}

		/// <summary>削除ボタン有効無効プロパティ</summary>
		bool DeleteButton	{get;}

		/// <summary>赤伝ボタン有効無効プロパティ</summary>
		bool AkaButton		{get;}

		/// <summary>領収書発行ボタン有効無効プロパティ</summary>
		bool ReceiptPrintButton { get;}

        bool RenewalButton { get;}
        // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
        // <summary>伝票番号呼出ボタン有効無効プロパティ</summary>
        bool ReadSlipButton { get;}
        // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
		# endregion

		# region Methods
		/// <summary>
		/// Control.Show メソッドのオーバーロード
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <remarks>
		/// <br>Note       : object型の引数を受け取り、コントロールをユーザーに対して表示します。
		///					 引数を使用しない場合は、メソッド内に[this.show();]のみを記述して下さい。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void Show(object parameter);

		/// <summary>
		/// 表示通知処理
		/// </summary>
		/// <param name="mode">起動モード 0:得意先コード指定, 1:受注番号指定</param>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝正常</param>
		/// <param return="int">0≠異常</param>
		/// <remarks>
		/// <br>Note       : ＭＤＩ親画面から表示指示を行った場合に発生するイベント</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int	ShowData(int mode, object[] parameter);

		/// <summary>
		/// タブ変更前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK</param>
		/// <param return="int">0≠NG タブ変更不可</param>
		/// <remarks>
		/// <br>Note       : タブ変更が行われる前に、変更を許可するかの判断を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int	BeforeTabChange(object parameter);

		/// <summary>
		/// 拠点変更前通知処理
		/// </summary>
		/// <param return="int">0＝OK</param>
		/// <param return="int">0≠NG 拠点変更不可</param>
		/// <remarks>
		/// <br>Note       : 拠点変更時、変更を許可するかの判断を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int BeforeSectionChange();

		/// <summary>
		/// 拠点変更後通知処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 拠点変更後の処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void AfterSectionChange();

		/// <summary>
		/// 終了前通知処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <param return="int">0＝OK</param>
		/// <param return="int">0≠NG</param>
		/// <remarks>
		/// <br>Note       : 終了する前に、変更を許可するかの判断を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int	BeforeClose(object parameter);

		/// <summary>
		/// 新規処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新規入力処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void NewDepositProc();

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 保存処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void SaveDepositProc();

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 削除処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void DeleteDepositProc();

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 赤伝処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void AkaDepositProc();

		/// <summary>
		/// 領収書発行処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 領収書発行処理を行います。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void ReceiptPrintProc();

        void RenewalProc();

        /// <summary>
        /// 伝票番号呼出処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票番号呼出処理を行います。</br>
        /// <br>Programer  : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        void ReadSlipProc();
        
		# endregion
	}
	#endregion

	#region デリゲート     
	/// <summary>
	/// ツールバーボタン制御
	/// </summary>
	/// <param name="sender">オブジェクト</param>
	/// <remarks>
	/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
	/// <br>Programer  : 97036 amami</br>
	/// <br>Date       : 2005.07.30</br>
	/// </remarks>
	public delegate void ParentToolbarDepositSettingEventHandler(object sender);

	/// <summary>
	/// 拠点コード取得
	/// </summary>
	/// <param name="sender">オブジェクト</param>
	/// <remarks>
	/// <br>Note       : フレームにて選択されている拠点コードを取得します。</br>
	/// <br>Programer  : 97036 amami</br>
	/// <br>Date       : 2005.07.30</br>
	/// </remarks>
	public delegate string GetDepositSelectSectionCodeEventHandler(object sender);

    /// <summary>
    /// 計上拠点名称
    /// </summary>
    /// <param name="sender">オブジェクト</param>
    /// <param name="sectionName">計上拠点名称</param>
    /// <remarks>
    /// <br>Note       : メイン画面で取得した計上拠点名称をフレームに渡します。</br>
    /// <br>Programer  : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.02.20</br>
    /// </remarks>
    public delegate void HandOverDepositAddUpSecNameEventHandler(object sender, string sectionName);
	#endregion
}
