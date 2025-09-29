using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{
	#region ◆　帳票業務(条件入力タイプ)チャート表示用インタフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)チャートインタフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : チャート表示する際、実装しなければいけないメンバ定義です。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
	/// </remarks>
	public interface IPrintConditionInpTypeChart
	{
		#region Property
		
		/// <summary>チャートボタン表示設定プロパティ</summary>
		/// <value>[True:表示,False:非表示]</value>
		/// <remarks>チャートボタンを表示するかどうかの設定を取得します。</remarks>
		bool VisibledChartButton { get;}

		/// <summary>チャートボタン有効無効設定プロパティ</summary>
		/// <value>[True:有効,False:無効]</value>
		/// <remarks>チャートボタン表示を許可するかどうかの設定を取得します。</remarks>
		bool CanChart { get;}
		
		#endregion

		#region Method

		/// <summary>
		/// チャート抽出クラスオブジェクト取得
		/// </summary>
		/// <param name="chartExtractMemberList">チャート抽出クラスオブジェクトリスト</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : グラフの画面条件の入力チェックを行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		int GetChartExtractMember(out List<IChartExtract> chartExtractMemberList);
		
		#endregion
	}
	#endregion

	#region ◆　チャート抽出クラスインタフェース
	/// <summary>
	/// チャート抽出クラスインタフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : チャート抽出クラスを作成する際、実装しなければいけないメンバ定義です。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.08</br>
	/// </remarks>
	public interface IChartExtract
	{
		#region Property

		/// <summary>
		/// チャート作成パラメータ
		/// </summary>
		ChartParamater ChartParamater { get; set;}　 

		#endregion

		#region Method

		/// <summary>
		/// チャートデータ作成処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="parameter">呼出パラメータ</param>
		/// <param name="msg">エラーメッセージ</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int MakeChartData(object sender, object parameter, out string msg);

		/// <summary>
		/// チャートパラメータ取得
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="parameter">呼出パラメータ</param>
		/// <param name="chartInfo">チャート情報パラメータ</param>
		/// <param name="msg">エラーメッセージ</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);

		/// <summary>
		/// ドリルダウンチャートパラメータ取得
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="parameter">呼出パラメータ</param>
		/// <param name="chartInfo">チャート情報パラメータ</param>
		/// <param name="msg">エラーメッセージ</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);


		/// <summary>
		/// チャート絞込み条件画面起動
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="parameter">呼出パラメータ</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int ShowCondition(object sender, object parameter);
		
		#endregion
	}


	#endregion


	#region ◆　チャート作成パラメータクラス
	/// <summary>
	/// チャート作成パラメータ
	/// </summary>
	public class ChartParamater
	{
		/// <summary>
		/// チャート作成パラメータコンストラクタ
		/// </summary>
		public ChartParamater()
		{
		}

		/// <summary>呼出パラメータ</summary>
		private string _paramater;

		/// <summary>条件ボタン有無</summary>
		private bool _isCondtnButton;

		/// <summary>ドリルダウン有無</summary>
		private bool _isDrillDown;


		/// <summary>
		/// 呼出パラメータプロパティ
		/// </summary>
		public string Paramater
		{
			get { return this._paramater; }
			set { this._paramater = value; }
		}

		/// <summary>
		/// 条件ボタン有無プロパティ
		/// </summary>
		public bool IsCondtnButton
		{
			get { return this._isCondtnButton; }
			set { this._isCondtnButton = value; }
		}

		/// <summary>
		/// ドリルダウンボタン有無プロパティ
		/// </summary>
		public bool IsDrillDown
		{
			get { return this._isDrillDown; }
			set { this._isDrillDown = value; }
		}
	}
	#endregion
}
