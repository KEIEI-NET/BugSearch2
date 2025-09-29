//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 請求帳票系MDI子画面インターフェースクラス
// プログラム概要   : 請求帳票系MDI子画面インターフェースクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870080-00   作成担当 : 陳艶丹
// 作 成 日  2022/04/21    修正内容 : 電子帳簿2次対応
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Common
{
	#region ◆　請求帳票系MDI子画面インターフェース
	/// <summary>
	/// 請求帳票系MDI子画面インターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// <br>Update Note : 2020/04/21 陳艶丹</br>
    /// <br>管理番号    : 11870080-00 電子帳簿2次対応</br> 
	/// </remarks>
    public interface IDemandEbookChild
	{
		/// <summary>
		/// Control.Show メソッドのオーバーロード
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		void Show(object parameter);
	}
	#endregion
    
	#region ◆　請求帳票系MDI子画面条件入力メイン画面インターフェース
	/// <summary>
	/// 請求帳票系MDI子画面条件入力メイン画面インターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandEbooksChildMain
	{
		/// <summary>
		/// Control.Show メソッドのオーバーロード
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		void Show(object parameter);
		
		/// <summary>
		/// 画面入力チェック処理
		/// </summary>
		/// <returns>[true:OK,false:NG]</returns>
		/// <remarks>
        /// <br>Note        : 画面の入力チェックを行います。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// データ抽出処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
        /// <br>Note        : 画面の入力チェックを行います。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int ExtractData();

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
        /// <br>Note        : 印刷処理を行います。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int Print(ref object parameter, bool syncFlg);

        /// <summary>
        /// 同期処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面の入力チェックを行います。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        int SyncMain();

        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
        /// <summary>
        /// 抽出条件タブに戻る
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 抽出条件タブに戻るを行います。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        void ReturnToExtraCondition();
        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
	}
	#endregion
	
	#region ◆　請求帳票系印刷ActiveReportTypeインターフェース
	/// <summary>
	/// 請求帳票系印刷ActiveReportTypeインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandEBooksPrintActiveReportType
	{
		/// <summary>
		/// 印刷タイトル
		/// </summary>
		string Title
		{
			set;
		}
		
		/// <summary>
		/// 印刷情報パラメータプロパティ
		/// </summary>
		SFCMN06002C PrintInfo
		{
			get;
			set;
		}
		
		/// <summary>
		/// 印刷用初期設定情報設定
		/// </summary>
		/// <param name="conditionInfo">設定情報オブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note        : 印刷に必要な初期設定情報を設定します。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int SetPrintConditionIno(object conditionInfo,out string message);
		
		/// <summary>
		/// 印刷用情報設定処理
		/// </summary>
		/// <param name="demandRelatedData">印刷用情報オブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note        : 直接バインドしない印刷時に必要な情報を設定します。
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion

	#region ◆　デリゲート
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);
	#endregion
}
