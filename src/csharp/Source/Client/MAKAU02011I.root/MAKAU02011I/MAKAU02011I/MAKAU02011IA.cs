using System;

namespace Broadleaf.Application.Common
{
	#region ◆　請求帳票系MDI子画面インターフェース
	/// <summary>
	/// 請求帳票系MDI子画面インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChild
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
	/// <br>Note       : </br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChildMain
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
		/// <br>Note       : 画面の入力チェックを行います。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// データ抽出処理
		/// </summary>
		/// <param name="printKind">帳票種類[1:請求一覧,2:合計請求書,3:明細請求書]</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 画面の入力チェックを行います。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		int ExtractData(int printKind);

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行います。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		int Print(ref object parameter);
	
		/// <summary>
		/// 印刷書類変更処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷書類変更時の処理を行います。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.07</br>
		/// </remarks>
		void ChangePrintType(int printType);
	}
	#endregion
	
	#region ◆　請求帳票系印刷ActiveReportTypeインターフェース
	/// <summary>
	/// 請求帳票系印刷ActiveReportTypeインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.15</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandPrintActiveReportType
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
		/// <br>Note       : 印刷に必要な初期設定情報を設定します。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		int SetPrintConditionIno(object conditionInfo,out string message);
		
		/// <summary>
		/// 印刷用情報設定処理
		/// </summary>
		/// <param name="demandRelatedData">印刷用情報オブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 直接バインドしない印刷時に必要な情報を設定します。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion

	#region ◆　デリゲート
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);
	#endregion
}
