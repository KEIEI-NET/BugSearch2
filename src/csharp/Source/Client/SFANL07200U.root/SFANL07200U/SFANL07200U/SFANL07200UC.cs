using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 分析チャートビューフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 分析チャートを表示するフォームクラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
	/// </remarks>
	internal partial class AnalysisChartViewForm : Form
	{
		#region Constructor
		/// <summary>
		/// 分析チャートビューフォームクラスコンストラクタ
		/// </summary>
		/// <param name="parentForm">親フォーム（分析チャートメインフレーム）</param>
		/// <remarks>
		/// <br>Note       : 分析チャートビューフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		internal AnalysisChartViewForm()
		{
			InitializeComponent();

			// チャート抽出クラスオブジェクトリスト初期化
			this._chartExtractList = new List<IChartExtract>();

			// ドリルダウン有り分析チャート情報管理クラスリスト初期化
			this._drillDownChartList		= new SortedList();

			// 条件ボタン有り分析チャート情報管理クラスリスト初期化
			this._condtionClickChartList	= new SortedList();

			// チャートパラメータリスト初期化
			this._chartInfoList				= new SortedList();

			// 分析チャート表示設定アクセスクラス
			this._analysisChartSettingAcs	= new AnalysisChartSettingAcs();
		}
		#endregion

		#region Private Member
		/// <summary>チャート抽出クラスオブジェクトリスト</summary>
		private List<IChartExtract> _chartExtractList = null;

		/// <summary>ドリルダウン有り分析チャート情報管理クラスリスト</summary>
		private SortedList _drillDownChartList						= null;

		/// <summary>条件ボタン有り分析チャート情報管理クラスリスト</summary>
		private SortedList _condtionClickChartList					= null;

		/// <summary>チャートパラメータリスト</summary>
		private SortedList _chartInfoList							= null;

		/// <summary>チャート生成クラス</summary>
		private ChartLibrary _chartLibrary							= null;

		/// <summary>分析チャート表示設定アクセスクラス</summary>
		private AnalysisChartSettingAcs _analysisChartSettingAcs	= null;

		/// <summary>帳票共通用フォームコントロールキー</summary>
		private string _formControlInfoKey = "";

		/// <summary>チャートNo.</summary>
		private int _number;

		/// <summary>抽出条件オブジェクト</summary>
		private object _extractObj;

		#endregion

		#region Property
		/// <summary>チャート抽出オブジェクトリストプロパティ</summary>
		internal List<IChartExtract> ChartExtractList
		{
			get { return this._chartExtractList; }
			set { this._chartExtractList = value; }
		}

		/// <summary>分析チャート情報管理クラスリスト文字列プロパティ（読み取り専用）</summary>
		internal string AnalysisChartControlListString
		{
			get
			{
				StringBuilder analysisChartControlListString = new StringBuilder(string.Empty);

				//if ((this._chartExtractList == null) || (this._chartExtractList.Count == 0))
				//{
				//  return analysisChartControlListString.ToString();
				//}

				//foreach (IPrintConditionInpTypeGraphExtract graphExtract in this._chartExtractList)
				//{
				//  if (analysisChartControlListString.Length > 0)
				//  {
				//    // 改行
				//    analysisChartControlListString.Append("\r\n");
				//  }

				//  // 分析チャート名称を追加
				//  analysisChartControlListString.Append(graphExtract.Name);
				//}

				return analysisChartControlListString.ToString();
			}
		}
		/// <summary>帳票共通用フォームコントロールキープロパティ</summary>
		internal string FormControlInfoKey
		{
			get { return this._formControlInfoKey; }
			set { this._formControlInfoKey = value; }
		}
		/// <summary>チャートNo.プロパティ</summary>
		internal int Number
		{
			get { return this._number; }
			set { this._number = value; }
		}
		#endregion

		#region Private Method


		#region 分析チャートデータ生成処理
		/// <summary>
		/// 分析チャートデータ生成処理
		/// </summary>
		/// <param name="graphExtractObjList">分析チャート情報管理クラスリスト</param>
		/// <returns>RESULT（true:OK,false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 分析チャート抽出クラスにて分析チャートデータの生成を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private bool CreateChartData(List<IChartExtract> chartExtractObjList)
		{
			try
			{
				if ((chartExtractObjList == null) || (chartExtractObjList.Count == 0))
				{
					return false;
				}


				foreach (IChartExtract chartExtract in chartExtractObjList)
				{
					string msg;
					
					// チャートデータ作成
					int status = chartExtract.MakeChartData(this, this._extractObj, out msg);
					switch (status)
					{
						case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
							{
								break;
							}
						default:
							{
								SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
								return false;
							}
					}
				
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "分析チャートデータの生成に失敗しました。" + "\r\n" + ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return false;
			}

			return true;
		}
		#endregion

		#region 分析チャートパラメータリスト取得処理
		/// <summary>
		/// 分析チャートパラメータリスト取得処理
		/// </summary>
		/// <param name="graphExtractObjList">分析チャート情報管理クラスリスト</param>
		/// <returns>RESULT（true:OK,false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 分析チャート抽出クラスから分析チャートパラメータのリストを取得します。
		///                  また、ドリルダウンの有る分析チャート情報管理クラスのリストを生成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private bool GetChartInfoList(List<IChartExtract> chartExtractObjList)
		{
			try
			{
				// ドリルダウン有り分析チャート情報管理クラスリストクリア
				this._drillDownChartList.Clear();

				// 条件ボタン有り分析チャート情報管理クラスリストクリア
				this._condtionClickChartList.Clear();

				// チャートパラメータリストクリア
				this._chartInfoList.Clear();

				if ((chartExtractObjList == null) || (chartExtractObjList.Count == 0))
				{
					return false;
				}

				for (int i = 0; i < chartExtractObjList.Count; i++)
				{
					IChartExtract chartExtractObj = chartExtractObjList[i];

					if (chartExtractObj != null)
					{
						string msg = "";
						ChartInfo chartInfo;

						// チャート情報
						int status = chartExtractObj.GetChartInfo(this, this._extractObj, out chartInfo, out msg);

						switch (status)
						{
							case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
							case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
								{
									// チャート番号を取得
									int number = this._chartInfoList.Count + 1;

									// 詳細表示初期値をセット
									chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// ポイントラベル表示初期値をセット
									chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
									// ラベル角度初期値をセット
									chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// ３Ｄ／２Ｄ表示初期値をセット
									chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

									// チャートパラメータリストに格納
									this._chartInfoList.Add(number, chartInfo);

									// ドリルダウンチャート有り
									if (chartExtractObj.ChartParamater.IsDrillDown)
									{
										// ドリルダウン有り分析チャート情報管理クラスリストに格納
										this._drillDownChartList.Add(number, chartExtractObj);
									}

									// 条件（条件ボタン）有り
									if (chartExtractObj.ChartParamater.IsCondtnButton)
									{
										// 条件ボタン有り分析チャート情報管理クラスリストに格納
										this._condtionClickChartList.Add(number, chartExtractObj);

										// 条件ボタン可視設定
										this.ConditionButtonVisibleFalse(number, true);
									}
									else
									{
										// 条件ボタン可視設定
										this.ConditionButtonVisibleFalse(number, false);
									}
									break;
								}

							default:
								{
									SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
									return false;
								}
						}
					}
				}
				if (this._chartInfoList.Count == 0)
				{
					return false;
				}

				if (this._drillDownChartList.Count > 0)
				{
					foreach (int number in this._drillDownChartList.Keys)
					{
						// チャート切替イベント（ドリルダウン用）登録
						this.RegistChartSwitch(number);
					}
				}

			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "分析チャートデータの取得に失敗しました。" + "\r\n" + ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return false;
			}

			return true;
		}
		#endregion

		#region 分析チャート表示処理
		/// <summary>
		/// 分析チャート表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : チャート生成クラスにて分析チャートを生成し表示します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		private void ShowChartData()
		{

			// パネルに既にコントロールが有る場合はクリアする
			if (this.AnalysisChartView_panel.Controls.Count > 0)
			{
				this.AnalysisChartView_panel.Controls.Remove(this.AnalysisChartView_panel.Controls[0]);
			}

			// ポイントラベルフォントサイズ初期値をセット
			this._chartLibrary.PointLabelSizeInitialValue	= this._analysisChartSettingAcs.PointLabelSizeInitialValue;

			// ラベル最大桁数初期値をセット
			this._chartLibrary.LabelMaxLengthInitialValue	= this._analysisChartSettingAcs.LabelMaxLengthInitialValue;

			// ラベルフォントサイズ初期値をセット
			this._chartLibrary.LabelSizeInitialValue		= this._analysisChartSettingAcs.LabelSizeInitialValue;

			// チャート生成
			this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

			// スタイル変更
			SFANL07200UA.mControlScreenSkin.SettingScreenSkin(this._chartLibrary);
			
			// チャート表示
			this._chartLibrary.TopLevel			= false;
			this._chartLibrary.FormBorderStyle	= FormBorderStyle.None;
			this._chartLibrary.Show();

			// パネルにチャートを表示
			this.AnalysisChartView_panel.Controls.Add(this._chartLibrary);
			this._chartLibrary.Dock				= System.Windows.Forms.DockStyle.Fill;
		}
		#endregion

		#region チャート切替イベント（ドリルダウン用）登録処理
		/// <summary>
		/// チャート切替イベント（ドリルダウン用）登録処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RegistChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 += new ChartSwitchingEventHandler(this.ChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替イベント（ドリルダウン用）削除処理
		/// <summary>
		/// チャート切替イベント（ドリルダウン用）削除処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RemoveChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 -= new ChartSwitchingEventHandler(this.ChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替イベント（ドリルダウンからの戻り用）登録処理
		/// <summary>
		/// チャート切替イベント（ドリルダウンからの戻り用）登録処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RegistBackChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 += new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替イベント（ドリルダウンからの戻り用）削除処理
		/// <summary>
		/// チャート切替イベント（ドリルダウンからの戻り用）削除処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		private void RemoveBackChartSwitch(int number)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.ChartSwitch1 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 2: { this._chartLibrary.ChartSwitch2 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 3: { this._chartLibrary.ChartSwitch3 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
				case 4: { this._chartLibrary.ChartSwitch4 -= new ChartSwitchingEventHandler(this.BackChartSwitch); break; }
			}
		}
		#endregion

		#region チャート切替処理（ドリルダウン用）
		/// <summary>
		/// チャート切替処理（ドリルダウン用）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ChartSwitch(object sender, ChartSwitchingEventArgs e)
		{
			try
			{
				if (this._drillDownChartList.ContainsKey(e.Number))
				{
					IChartExtract iChartExtract = this._drillDownChartList[e.Number] as IChartExtract;
					if (iChartExtract != null)
					{
						string msg;
						ChartInfo chartInfo;

						// ドリルダウンチャートパラメータ取得
						int status = iChartExtract.GetDrillDownChartInfo(this, e.Element, out chartInfo, out msg);
						switch (status)
						{
							case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
								{
									// 詳細表示初期値をセット
									chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// ポイントラベル表示初期値をセット
									chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
									// ラベル角度初期値をセット
									chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// ３Ｄ／２Ｄ表示初期値をセット
									chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

									// チャートパラメータの削除
									if (this._chartInfoList.ContainsKey(e.Number))
									{
										this._chartInfoList.Remove(e.Number);
									}
									// チャートパラメータリストに格納
									this._chartInfoList.Add(e.Number, chartInfo);

									// チャート再生成
									this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

									// チャート切替イベント（ドリルダウン用）削除
									this.RemoveChartSwitch(e.Number);
									// チャート切替イベント（ドリルダウンからの戻り用）登録
									this.RegistBackChartSwitch(e.Number);

									break;
								}
							case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
								{
									break;
								}
							default:
								{
									SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "分析チャート（ドリルダウン）データの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}
		#endregion

		#region チャート切替処理（ドリルダウンからの戻り用）
		/// <summary>
		/// チャート切替処理（ドリルダウンからの戻り用）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void BackChartSwitch(object sender, ChartSwitchingEventArgs e)
		{
			try
			{
				if (this._drillDownChartList.ContainsKey(e.Number))
				{
					IChartExtract iChartExtract = this._drillDownChartList[e.Number] as IChartExtract;
					if (iChartExtract != null)
					{
						string msg;
						ChartInfo chartInfo;

						int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

						status = iChartExtract.GetChartInfo(this, this._extractObj, out chartInfo, out msg);

						switch (status)
						{
							case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
							case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
								{
									// 詳細表示初期値をセット
									chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
									// ポイントラベル表示初期値をセット
									chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
									// ラベル角度初期値をセット
									chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
									// ３Ｄ／２Ｄ表示初期値をセット
									chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

									// チャートパラメータの削除
									if (this._chartInfoList.ContainsKey(e.Number))
									{
										this._chartInfoList.Remove(e.Number);
									}
									// チャートパラメータリストに格納
									this._chartInfoList.Add(e.Number, chartInfo);

									// チャート再生成
									this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

									// チャート切替イベント（ドリルダウンからの戻り用）削除
									this.RemoveBackChartSwitch(e.Number);
									// チャート切替イベント（ドリルダウン用）登録
									this.RegistChartSwitch(e.Number);

									break;
								}
							default:
								{
									SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
									return;
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "分析チャートデータの取得に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}
		#endregion

		#region 条件ボタン可視設定処理
		/// <summary>
		/// 条件ボタン可視設定処理
		/// </summary>
		/// <param name="number">チャート番号</param>
		/// <param name="visible">可視</param>
		private void ConditionButtonVisibleFalse(int number, bool visible)
		{
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
			}

			switch (number)
			{
				case 1: { this._chartLibrary.Condition1ButtonVisible = visible; break; }
				case 2: { this._chartLibrary.Condition2ButtonVisible = visible; break; }
				case 3: { this._chartLibrary.Condition3ButtonVisible = visible; break; }
				case 4: { this._chartLibrary.Condition4ButtonVisible = visible; break; }
			}
		}
		#endregion


		#region 条件ボタンクリック処理
		/// <summary>
		/// 条件ボタンクリック処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ConditionClick(object sender, ConditionClickEventArgs e)
		{
			try
			{
				if (this._condtionClickChartList.ContainsKey(e.Number))
				{
					// 分析チャート情報管理クラス取得
					IChartExtract iChartExtract = this._condtionClickChartList[e.Number] as IChartExtract;
					if (iChartExtract != null)
					{
						// 条件入力ＵＩ画面表示
						int status = iChartExtract.ShowCondition(this, null);

						if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							string msg;
							ChartInfo chartInfo;

							// チャートパラメータ取得
							status = iChartExtract.GetChartInfo(this, this._extractObj, out chartInfo, out msg);
							switch (status)
							{
								case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
								case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
									{
										// 詳細表示初期値をセット
										chartInfo.Grid = this._analysisChartSettingAcs.DetailDisplayInitialValue;
										// ポイントラベル表示初期値をセット
										chartInfo.PointLabel = this._analysisChartSettingAcs.PointLabelInitialValue;
										// ラベル角度初期値をセット
										chartInfo.XLabelVertical = this._analysisChartSettingAcs.LabelVerticalInitialValue;
										// ３Ｄ／２Ｄ表示初期値をセット
										chartInfo.Chart3D = this._analysisChartSettingAcs.View3D2DInitialValue;

										// チャートパラメータの削除
										if (this._chartInfoList.ContainsKey(e.Number))
										{
											this._chartInfoList.Remove(e.Number);
										}
										// チャートパラメータリストに格納
										this._chartInfoList.Add(e.Number, chartInfo);

										// チャート再生成
										this._chartLibrary.GenerateChart(new ArrayList(this._chartInfoList.Values));

										break;
									}
								default:
									{
										SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
										return;
									}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				SFANL07200UA.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "条件設定に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}
		#endregion

		#endregion

		#region Internal Method
		/// <summary>
		/// 分析チャートビューフォーム情報管理クラスクリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャートビューフォーム情報管理クラスをクリアします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.05.15</br>
		/// </remarks>
		internal void Clear()
		{
			// 分析チャート情報管理クラスリストクリア
			this.ClearAnalysisChartControlList();

			// 画面終了
			this.Close();
		}

		#region 分析チャート情報管理クラスリストクリア処理
		/// <summary>
		/// 分析チャート情報管理クラスリストクリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート情報管理クラスリストをクリアします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		internal void ClearAnalysisChartControlList()
		{
			if ((this._chartExtractList == null) || (this._chartExtractList.Count == 0))
			{
				return;
			}

			//foreach (AnalysisChartControl analysisChartControl in this._chartExtractList)
			//{
			//  // 分析チャート情報管理クラスクリア
			//  analysisChartControl.Clear();
			//}

			// 分析チャート情報管理クラスリストクリア
			this._chartExtractList.Clear();
		}
		#endregion

		#region 分析チャートビューフォーム表示処理
		/// <summary>
		/// 分析チャートビューフォーム表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャートビューフォームを表示します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		internal void ShowMe(object paramater)
		{
			// 抽出条件設定
			this._extractObj = paramater;

			// 画面表示
			this.Show();

			// チャート部品作成
			if (this._chartLibrary == null)
			{
				this._chartLibrary = new ChartLibrary();
				this._chartLibrary.ConditionClick += new ConditionClickEventHandler(this.ConditionClick);
			}
			
			// 分析チャートデータ生成
			if (this.CreateChartData(this._chartExtractList))
			{
				// 分析チャートパラメータリスト取得
				if (this.GetChartInfoList(this._chartExtractList))
				{
					// 分析チャート表示
					this.ShowChartData();
				}
			}
		}
		
		#endregion

		#endregion

		// ===================================================================================== //
		// Internalイベント
		// ===================================================================================== //
		#region Internal event
		/// <summary>
		/// ツールバー表示制御イベント
		/// </summary>
		internal event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion

		// ===================================================================================== //
		// コントロールイベント
		// ===================================================================================== //
		#region control event
		/// <summary>
		/// Control.Activatedイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : フォームがアクティブにされた時に発生します。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2007.03.06</br>
		/// </remarks>
		private void AnalysisChartViewForm_Activated(object sender, EventArgs e)
		{
			if (this.ParentToolbarSettingEvent != null)
				this.ParentToolbarSettingEvent(this);
		}
		#endregion
	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  