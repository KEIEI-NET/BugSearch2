using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;


using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 前年対比表チャートデータ作成クラス
    /// </summary>
    public class AgentOrderChart : IChartExtract
    {

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
		/// 
        public AgentOrderChart(int index, int para)
        {
			this._ChartScIndex = index;						//チャートmodeパラメータ

			_singleTypeObj._ModePara = para;				//起動mode（○○別）パラメータをEBに渡す

			DCTOK02096EB _DCTOK02096EB = new DCTOK02096EB();

			this._chartParamater = new ChartParamater();

			this._chartParamater.IsCondtnButton = true;     // 絞込条件ボタン(表示しない)
			this._chartParamater.IsDrillDown = false;       // チャートのドリルダウン機能(なし)                 

			this._prevYearTableAcs = new PrevYearComparison();

			// チャート表示用データセットインスタンス化
			this._chartDataSet = new DataSet();
		
        }

        #endregion

        #region const

        #endregion

        #region Private Members

        private string _PGID = "DCTOK02126E";

        private int _ChartScIndex = 0;
        private bool _ExtraProcFlg = false;


        private PrevYearComparison _prevYearTableAcs = null;    // 前年対比表アクセスクラス

        /// <summary>チャート情報パラメータ</summary>
        private ChartParamater _chartParamater;
        private int _paraStyle = 1;

        /// <summary>チャート表示パラメータリスト</summary>
        private List<int> _chartInfoList = new List<int>();

        /// <summary>ベースデータ保持用データセット</summary>
        private DataSet _baseDataSet;
        /// <summary>チャート表示用データセット</summary>
        private DataSet _chartDataSet;

        // 抽出条件クラス
		private ExtrInfo_DCTOK02093E _extraparam;

        /// <summary>前年対比表データテーブル名(ベース用)</summary>
        private string _PrevYearReportTable;

        /// <summary>前年対比表データテーブル名(チャート用：比率)</summary>
        private string _PrevYearReportDataTableRatio = "PrevYearReportRatio";

		/// <summary>前年対比表データテーブル名(チャート用：売上)</summary>
		private string _PrevYearReportDataTableSales = "PrevYearReportSales";

        // DataTable列名＜チャート用テーブル＞
		private const string COL_TITLE = "COL_TITLE";
		private const string COL_THIS_SALES = "COL_PARA_TSALES";
		private const string COL_FIRST_SALES = "COL_PARA_FSALES";
		private const string COL_SALES_RATIO = "COL_PARA_RATIO";
		private const string COL_THIS_GROSS = "COL_PARA_TGROSS";
		private const string COL_FIRST_GROSS = "COL_PARA_FGROSS";
		private const string COL_GROSS_RATIO = "COL_PARA_GRSRATIO";

		// 条件入力ＵＩ画面表示
		DCTOK02096EB _singleTypeObj = new DCTOK02096EB();

		List<string> _CodeList;
		List<string> _NameList;

		#endregion

        #region IChartExtract メンバ

        /// <summary>
        /// 
        /// </summary>
        public ChartParamater ChartParamater
        {
            get { return this._chartParamater; }
            set { this._chartParamater = value; }
        }

        #region ◆チャートデータ作成処理
        /// <summary>
        /// チャートデータ作成処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int MakeChartData(object sender, object parameter, out string msg)
        {
            msg = "";

			_singleTypeObj.b_Ok = true;						//フレームの『グラフ表示』ボタンを押された時は常にtrue

            try
            {
				this._extraparam = (ExtrInfo_DCTOK02093E)parameter;

                int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
                int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                string message = "";

                try
                {
					status = this._prevYearTableAcs.SearchStatic(out message);
                    if (status == 0)
                    {
                        this._PrevYearReportTable = Broadleaf.Application.UIData.DCTOK02094EA.CT_PrevYearCpDataTable;
						
						// アクセスクラスから取得したテーブルを、チャート用ベーステーブルとして保持
                        this._baseDataSet = this._prevYearTableAcs._printDataSet.Copy();

                        this.CreateTable();

						// チャート表示用データセットスキーマ設定
						SetTableSchema();

						int tbRatioCnt = 0;
						int tbSalesCnt = 0;

						// チャート表示パラメータリスト初期化
						#region < パラメータ初期化 >
						this._chartInfoList = new List<int>();
 
						switch(this._ChartScIndex)
						{
							 case 0:	//比率
								tbRatioCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Count;
								break;

							 case 1:	//金額
								tbSalesCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Count;
								break;
						}
							if (this._ChartScIndex == 0)	//比率
							{
								for (int ix = 1; ix < tbRatioCnt ; ix++)
								{
									this._chartInfoList.Add(1);
								}
							}
							else
							{
								for (int ix = 1; ix < tbSalesCnt; ix++)
								{
									this._chartInfoList.Add(1);
								}
							}
						#endregion

						}
                }
                catch (Exception ex)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                                MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    // 戻り値を設定。異常の場合はメッセージを表示
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }
                        default:
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                            MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                break;
                            }
                    }
                }
                msg = message;
                return result;
            }
            catch (Exception)
            {
                msg = "前年対比表情報の取得に失敗しました。";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        #region ◆チャートパラメータ取得処理
        /// <summary>
        /// チャートパラメータ取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
		/// <param name="chartInfo">チャートパラメータ</param>
        /// <param name="msg"></param>
        /// <returns></returns>
		public int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

				try
				{
					// チャート部品情報の作成
					this.CreateChartInfo(ref chartInfo, this._extraparam);

					// チャート用データテーブルの作成
					this.ExtraProcMain(ref this._chartDataSet, this._baseDataSet, this._extraparam);

					int tbRatioRowsCnt = 0;
					int tbSalesRowsCnt = 0;

					switch (this._ChartScIndex)
					{
						case 0:	//比率
							tbRatioRowsCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Rows.Count;
							break;

						case 1:	//金額
							tbSalesRowsCnt = this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Rows.Count;
							break;
					}

					if ((tbRatioRowsCnt + tbSalesRowsCnt) == 0)
					{
						msg = "データが存在しませんでした。";
						return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
					}

					// データソースの設定
					switch (this._ChartScIndex)
					{
						case 0:	//比率
							chartInfo.DataSource = this._chartDataSet.Tables[this._PrevYearReportDataTableRatio];

							break;

						case 1:	//金額
							chartInfo.DataSource = this._chartDataSet.Tables[this._PrevYearReportDataTableSales];

							break;
					}
				}
				catch (Exception ex)
				{
					msg = "チャート部品情報作成に失敗しました。" + ex;
					return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
				}

		return status;
        }

        #endregion

        #region ◆ドリルダウンチャートパラメータ取得処理
        /// <summary>
        /// ドリルダウンチャートパラメータ取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
		/// <param name="chartInfo"></param>
		/// <param name="msg"></param>
        /// <returns></returns>
        public int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            msg = "";
            chartInfo = new ChartInfo();

            // チャート表示用パラメータの取得
            // あれば取得

            try
            {
                // チャート部品情報の作成
                //this.CreateChartInfo(1, ref chartInfo);

                //DataRow parentRow = this._chartDataSet.Tables[CT_TableName_GoodsKind].Rows[(int)parameter];

                //// ドリルダウン元情報の取得
                //string goodsKindName = (string)parentRow[CT_COL_GoodsKindName];
                //chartInfo.SubTitle = "（" + goodsKindName + "）";

                //// チャート用データテーブルの作成
                //this.ExtraProcMaker(parentRow, ref this._chartDataSet);
                //if (this._chartDataSet.Tables[CT_TableName_GoodsMaker].Rows.Count == 0)
                //{
                //    msg = "データが存在しませんでした。";
                //    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //}

                //// -- データソースの設定 -// 
                //chartInfo.DataSource = this._chartDataSet.Tables[CT_TableName_GoodsMaker];

            }
            catch (Exception ex)
            {
                msg = "チャート部品情報の作成で例外が発生しました" + "\n\r" + "[" + ex.Message + "]";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◆チャート条件画面表示処理
        /// <summary>
        /// チャート絞込条件画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        public int ShowCondition(object sender, object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            #region パラメータセット
            _singleTypeObj._TitleList = new List<string>();

			_singleTypeObj._Code = new List<string>();
			_singleTypeObj._Name = new List<string>();

			this.CreatList();

			if (this._ChartScIndex == 0)	//比率
			{
				_singleTypeObj._TitleList.Add("売上：比率");
				_singleTypeObj._TitleList.Add("粗利：比率");

				//DCTOK02096EBに一括してリストを渡す
				_singleTypeObj._Code = this._CodeList;
				_singleTypeObj._Name = this._NameList;

			}
			else
			{
                _singleTypeObj._TitleList.Add("売上：当年");
                _singleTypeObj._TitleList.Add("売上：前年");
                _singleTypeObj._TitleList.Add("粗利：当年");
                _singleTypeObj._TitleList.Add("粗利：前年");

				_singleTypeObj._Code = this._CodeList;
				_singleTypeObj._Name = this._NameList;
			}

			_singleTypeObj._GraphPara = new List<int>();
			_singleTypeObj._GraphPara.Add(this._paraStyle);

			_singleTypeObj._GraphShow = new List<int>();

			for (int ix = 0; ix < this._chartInfoList.Count; ix++)
			{
				_singleTypeObj._GraphShow.Add(this._chartInfoList[ix]);
			}

			#endregion

            Form customForm = (Form)_singleTypeObj;
            customForm.StartPosition = FormStartPosition.CenterScreen;

			DialogResult dialogResult = customForm.ShowDialog();

			if (dialogResult == DialogResult.Cancel)
			{
				_singleTypeObj.b_Ok = false;
				//_singleTypeObj._Ok = false;
			}

			
			#region パラメータゲット
			if (_singleTypeObj._GraphPara[0] > -1)
			{
				int cnt = 0;
				this._paraStyle = _singleTypeObj._GraphPara[0];

				for (int ix = 0; ix < this._chartInfoList.Count; ix++)
				{
					this._chartInfoList[ix] = _singleTypeObj._GraphShow[cnt];
					cnt++;
				}
			}
			#endregion

            return status;
        }
        #endregion

        #endregion


        #region private Method

        #region ◆チャート部品情報作成処理
        /// <summary>
        /// チャート部品情報作成処理
        /// </summary>
		/// <param name="extraparam">抽出条件クラス</param>
        /// <param name="chartInfo">チャートパラメータ</param>
		private void CreateChartInfo(ref ChartInfo chartInfo, ExtrInfo_DCTOK02093E extraparam)
		{
				chartInfo.Palette = PaletteStyle.DefaultWindows;		   	// パレット(色の組み合わせ)
				chartInfo.DockPosition = EditorDockPosition.Top;			// データエディターポジション
				chartInfo.PanelColor = Color.FromArgb(198, 219, 255);		// パネルの色
				chartInfo.Ydecimal = 0;										// Y軸小数点以下桁
				chartInfo.Ydecimal2 = 0;									// Y軸２小数点以下桁
				chartInfo.Stacked = StackStyle.No;                          // データの積層(奥・横に並べる)
				chartInfo.Cluster = true;									// Z軸に向けて系統を並べるかどうか
				chartInfo.Legend = true;                                    // 凡例(表示する)
				chartInfo.LegendBox = false;								// X軸の凡例の表示非表示
				chartInfo.Grid = true;                                      // データグリッド(表示する)
				chartInfo.View3DDepth = 80; 								// 3Dグラフの奥行き

				chartInfo.PointLabel = false;                               // チャートの上に値表示(しない)
				chartInfo.Chart3D = true;                                   // チャート3D or 2D (3D)

				chartInfo.AngleX = 30;										// X軸の回転
				chartInfo.AngleY = 30;										// Y軸の回転

				#region < 系統非表示設定 >
				int[] seriesVisible;
				int cnt = 0;
				int index = 0;

				int i_cnt = 0;
				int ccnt = 0;
				//List<string> _codeCashe = new List<string>();
				List<string> _codeCashe = null;
				List<int> lstindex = new List<int>();

				// 前回の表示設定を引き継ぐ
				#region 『対象項目2』の表示・非表示設定
				//『対象項目2』の表示・非表示設定
				switch (this._ChartScIndex)
				{
					case 0:	//比率の場合
						_codeCashe = _singleTypeObj._CodeCashe_r;
						break;

					case 1:
						_codeCashe = _singleTypeObj._CodeCashe_s;
						break;
				}

				//コードキャッシュが生成されていたら
				if (_codeCashe != null && 0 < _codeCashe.Count)
				{
					//TODO　_CodeListを更新
					this.CreatList();

						for (int ix = 0; ix < _codeCashe.Count; ix++)
						{
							//_CodeList内の要素に_codeCashe内の要素と同じものがあったら
							if (this._CodeList != null && this._CodeList.Contains(_codeCashe[ix]) == true)
							{
								//_CodeList内の要素のインデックスを取得
								lstindex.Add(this._CodeList.IndexOf(_codeCashe[ix]));
							}
						}

						#region 『確定』ボタンが押された場合の処理
						if (_singleTypeObj.b_Ok == true)	//Form2が『確定』で閉じられた時の処理。（else:×で閉じられた時は何もせず終了する）
						{
							// _chartInfoListをすべて0に
							for (int ix = 0; ix < this._chartInfoList.Count; ix++)
							{
								this._chartInfoList[ix] = 0;
							}

							if (lstindex.Count == 0)	//_CodeList内の要素に_codeCashe内の要素と同じものがない場合
							{
								//コードの若いデータを一件だけ表示
								switch (this._ChartScIndex)
								{
									case 0:	//比率の場合
										this._chartInfoList[0] = 1;
										this._chartInfoList[1] = 1;
										break;

									case 1:	//金額の場合
										this._chartInfoList[0] = 1;
										this._chartInfoList[1] = 1;
										this._chartInfoList[2] = 1;
										this._chartInfoList[3] = 1;
										break;
								}
							}
							else
							{
								//_codeCashe内の要素だけを1に
								for (int jx = 0; jx < lstindex.Count; jx++)
								{
									switch (this._ChartScIndex)
									{
										case 0:	//比率の場合

											i_cnt = lstindex[jx] * 2;

											this._chartInfoList[i_cnt] = 1;
											this._chartInfoList[i_cnt + 1] = 1;

											break;

										case 1:	//金額の場合
											i_cnt = lstindex[jx] * 4;

											this._chartInfoList[i_cnt] = 1;
											this._chartInfoList[i_cnt + 1] = 1;
											this._chartInfoList[i_cnt + 2] = 1;
											this._chartInfoList[i_cnt + 3] = 1;

											break;
									}
								}

							}

						}
						#endregion 『確定』ボタンが押された場合の処理：終

						#endregion	『対象項目2』の表示・非表示設定：終

						#region 『対象項目』の表示・非表示設定

						#region 『確定』ボタンが押された場合の処理
						if (_singleTypeObj.b_Ok == true)
						{

							//『対象項目』の表示・非表示設定
							for (int kx = 0; kx < lstindex.Count; kx++)
							{
								switch (this._ChartScIndex)
								{
									case 0:	//比率の場合

										ccnt = lstindex[kx] * 2;

										//_chartInfoListの『比率：売上』ぶんを非表示
										if (_singleTypeObj._CheckedIteme_r[0] == false)
										{
											this._chartInfoList[ccnt] = 0;
										}

										//_chartInfoListの『比率：売上』ぶんを非表示
										if (_singleTypeObj._CheckedIteme_r[1] == false)
										{
											this._chartInfoList[ccnt + 1] = 0;
										}

										break;

									case 1:

										ccnt = lstindex[kx] * 4;

										//_chartInfoListの『売上：当年』ぶんを非表示
										if (_singleTypeObj._CheckedIteme_s[0] == false)
										{
											this._chartInfoList[ccnt] = 0;
										}
										//_chartInfoListの『売上：前年』ぶんを非表示
										if (_singleTypeObj._CheckedIteme_s[1] == false)
										{
											this._chartInfoList[ccnt + 1] = 0;
										}
										//_chartInfoListの『粗利：当年』ぶんを非表示
										if (_singleTypeObj._CheckedIteme_s[2] == false)
										{
											this._chartInfoList[ccnt + 2] = 0;
										}
										//_chartInfoListの『粗利：前年』ぶんを非表示
										if (_singleTypeObj._CheckedIteme_s[3] == false)
										{
											this._chartInfoList[ccnt + 3] = 0;
										}

										break;
								}
							}

						}
						#endregion 『確定』ボタンが押された場合の処理

						#endregion	『対象項目』の表示・非表示設定：終

					}
				else	//コードキャッシュが生成されていない＝初回表示の時
				{
					//_chartInfoListをすべて0に
					for (int ix = 0; ix < this._chartInfoList.Count; ix++)
					{
						this._chartInfoList[ix] = 0;
					}

					//コードの若いデータを一件だけ表示
					switch (this._ChartScIndex)
					{
						case 0:	//比率の場合
							this._chartInfoList[0] = 1;
							this._chartInfoList[1] = 1;
							break;

						case 1:	//金額の場合
							this._chartInfoList[0] = 1;
							this._chartInfoList[1] = 1;
							this._chartInfoList[2] = 1;
							this._chartInfoList[3] = 1;
							break;
					}
				}

				for (int kx = 0; kx < this._chartInfoList.Count; kx++)
				{
					if (this._chartInfoList[kx] == 0) cnt++;
				}

				seriesVisible = new int[cnt];		//seriesVisibleの要素数を決める

				for (int kx = 0; kx < this._chartInfoList.Count; kx++)
				{
					if (this._chartInfoList[kx] == 0)
					{
						seriesVisible[index] = kx;
						index++;
					}
				}

				//系の表示・非表示設定。非表示にしたい系の番号をそれぞれの配列に格納
				chartInfo.SeriesVisible = seriesVisible;                    // 系の非表示設定

				// b_Okの初期化
				_singleTypeObj.b_Ok = true;

				#endregion

/*
            int[] seriesVisible;
            if (this._ChartScIndex == 0)
            {
                seriesVisible = new int[4];
                seriesVisible[0] = 4;
                seriesVisible[1] = 5;
                seriesVisible[2] = 6;
                seriesVisible[3] = 7;
            }
            else
            {
                seriesVisible = new int[4];
                seriesVisible[0] = 0;
                seriesVisible[1] = 1;
                seriesVisible[2] = 2;
                seriesVisible[3] = 3;
            }
            chartInfo.SeriesVisible = seriesVisible;                    // 系の非表示設定
*/

				#region < チャートスタイル設定 >
				switch (this._paraStyle)
				{
					case 0:	//棒グラフ
						{
							chartInfo.Style = ChartStyle.Bar;						// チャートのスタイル
							chartInfo.Cluster = true;                               // Z軸に向けて系統を並べるかどうか

							break;
						}
					case 1:
						{
							chartInfo.Style = ChartStyle.Line;						// チャートのスタイル
							chartInfo.Cluster = true;                               // Z軸に向けて系統を並べるかどうか

							break;
						}
				}

				#endregion

				#region < タイトル設定 >
				chartInfo.Title = "前年対比表";           // タイトル

				string extraTitle = "";
				if (this._ChartScIndex == 0)
				{
					extraTitle = "（比率）";
				}
				else
				{
					extraTitle = "（金額）";
				}
				chartInfo.SubTitle = extraTitle;          // サブタイトル（上部）

				switch (extraparam.ListType)
				{
                    case 0: // 得意先別
                        {
                            chartInfo.XLabel = "得意先";	  // サブタイトル（下部）
                            break;
                        }
                    case 1: // 担当者別
                        {
                            chartInfo.XLabel = "担当者";
                            break;
                        }
                    case 2: // 受注者別
                        {
                            chartInfo.XLabel = "受注者";
                            break;
                        }
                    case 3: // 地区
                        {
                            chartInfo.XLabel = "地区";
                            break;
                        }
                    case 4: // 業種
                        {
                            chartInfo.XLabel = "業種";
                            break;
                        }
                    case 5: //ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
                        {
                            chartInfo.XLabel = "グループコード";
                            break;
                        }
                    case 6: //ＢＬｺｰﾄﾞ別
                        {
                            chartInfo.XLabel = "ＢＬコード";
                            break;
                        }
				}

				if (extraparam.MoneyUnit == 0)
				{
					chartInfo.YLabel = "円";
				}
				else
				{
					chartInfo.YLabel = "千円";
				}
				#endregion
			}
		
        #endregion

        #region ◆テーブルスキーマ作成
        /// <summary>
        /// テーブルスキーマ作成
        /// </summary>
        private void CreateTable()
        {
            // ベーステーブル作成
            if (this._baseDataSet == null)
            {
                this._baseDataSet = new DataSet();
            }

            // チャート抽出用テーブル作成
            if (this._chartDataSet == null)
            {
                this._chartDataSet = new DataSet();
            }

            // チャート用テーブルデータ作成フラグクリア
            this._ExtraProcFlg = false;
        }
        #endregion

        #region ◆チャート用テーブルデータ作成処理
        /// <summary>
        /// チャート用テーブルデータ作成処理
        /// </summary>
		private void ExtraProcMain(ref DataSet chartDs, DataSet baseDs, ExtrInfo_DCTOK02093E extraparam)
        {
            DataRow dr;
            DataRow data;

            // 作成済みの時は処理をスキップ
            if (this._ExtraProcFlg == true) return;

			// 集計月タイトル
			//開始年月					
			string str_st_Month = this._extraparam.St_AddUpYearMonth.ToString() + "01";
			DateTime dt_stDate = DateTime.ParseExact(str_st_Month, "yyyyMMdd", null);
			//終了年月
			string str_ed_Month = this._extraparam.Ed_AddUpYearMonth.ToString() + "01";
			DateTime dt_edDate = DateTime.ParseExact(str_ed_Month, "yyyyMMdd", null);

			switch (this._ChartScIndex)
			{
			    case 0:	//比率
					// テーブル作成
					chartDs.Tables[this._PrevYearReportDataTableRatio].Clear();
					chartDs.Tables[this._PrevYearReportDataTableRatio].BeginLoadData();

					#region 比率用テーブルデータ作成

					// １ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.Month.ToString() + "月";
					//『○○別』（ListType）の数だけforで回してRowを作る
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio1];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio1];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ２ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(1).Month.ToString() + "月";		
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio2];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio2];	// 粗利：比率
					
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);
					
					// ３ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(2).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio3];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio3];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ４ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(3).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio4];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio4];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ５ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(4).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio5];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio5];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ６ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(5).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio6];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio6];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ７ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(6).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio7];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio7];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ８ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(7).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio8];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio8];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// ９ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(8).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio9];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio9];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// １０ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(9).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio10];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio10];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// １１ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(10).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio11];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio11];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);

					// １２ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableRatio].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.AddMonths(11).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_SALES_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_SalesRatio12];	// 売上：比率
						dr[COL_GROSS_RATIO + i] = data[DCTOK02094EA.CT_PrevYear_GrossRatio12];	// 粗利：比率
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableRatio].Rows.Add(dr);
					
					#endregion 比率用テーブルデータ作成

					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].EndLoadData();

					break;

				case 1:	//売上
					// テーブル作成
					chartDs.Tables[this._PrevYearReportDataTableSales].Clear();
					chartDs.Tables[this._PrevYearReportDataTableSales].BeginLoadData();

					#region 売上用テーブルデータ作成

					// １ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：比率
					dr[COL_TITLE] = dt_stDate.Month.ToString() + "月";
					//『○○別』（ListType）の数だけforで回してRowを作る
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales1];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales1];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross1];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross1];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ２ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(1).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales2];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales2];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross2];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross2];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ３ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(2).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales3];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales3];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross3];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross3];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ４ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(3).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales4];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales4];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross4];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross4];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ５ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(4).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales5];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales5];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross5];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross5];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ６ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(5).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales6];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales6];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross6];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross6];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ７ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(6).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales7];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales7];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross7];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross7];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// ８ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(7).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales8];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales8];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross8];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross8];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);
					
					// ９ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(8).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales9];		// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales9];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross9];		// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross9];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// １０ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(9).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales10];	// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales10];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross10];	// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross10];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// １１ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(10).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales11];	// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales11];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross11];	// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross11];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					// １２ヶ月目
					dr = chartDs.Tables[this._PrevYearReportDataTableSales].NewRow();	//チャート用：売上
					dr[COL_TITLE] = dt_stDate.AddMonths(11).Month.ToString() + "月";
					for (int ix = 0; ix < baseDs.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();
						data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];
						dr[COL_THIS_SALES + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermSales12];	// 売上：当年
						dr[COL_FIRST_SALES + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermSales12];	// 売上：前年
						dr[COL_THIS_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_ThisTermGross12];	// 粗利：当年
						dr[COL_FIRST_GROSS + i] = data[DCTOK02094EA.CT_PrevYear_FirstTermGross12];	// 粗利：前年
					}
					// チャートテーブルに追加
					chartDs.Tables[this._PrevYearReportDataTableSales].Rows.Add(dr);

					#endregion 売上用テーブルデータ作成

				this._chartDataSet.Tables[this._PrevYearReportDataTableSales].EndLoadData();
				break;
			}

            // チャート用テーブルデータ作成フラグセット
            this._ExtraProcFlg = true;

        }
        #endregion

		#region 条件設定ダイアログに渡すリストを作成
		/// <summary>
		/// 条件設定ダイアログに渡すリストの作成
		/// </summary>
		public void CreatList()
		{
			DataSet baseDs = this._baseDataSet;
			DataRow data;

			_CodeList = new List<string>();
			_NameList = new List<string>();

			for (int i = 0; i < baseDs.Tables[this._PrevYearReportTable].Rows.Count; i++)
			{
				switch (this._extraparam.ListType)
				{
					case 0:	//得意先別
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_CustomerCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_CustomerSnm].ToString());

						break;

                    case 1:	//担当者別
                    case 2: //受注者別
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_EmployeeCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_EmployeeName].ToString());

                        break;
					case 3:	//地区別
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_SalesAreaCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_SalesAreaName].ToString());

						break;

					case 4:	//業種別
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
						_CodeList.Add(data[DCTOK02094EA.CT_PrevYear_BusinessTypeCode].ToString());
						_NameList.Add(data[DCTOK02094EA.CT_PrevYear_BusinessTypeName].ToString());

						break;

					case 5:	//ｸﾞﾙｰﾌﾟｺｰﾄﾞ別	
						data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
                        _CodeList.Add(data[DCTOK02094EA.CT_PrevYear_BLGroupCode].ToString());
                        _NameList.Add(data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName].ToString());

						break;
                    case 6: //BLｺｰﾄﾞ別
                        data = baseDs.Tables[this._PrevYearReportTable].Rows[i];
                        _CodeList.Add(data[DCTOK02094EA.CT_PrevYear_BLGoodsCode].ToString());
                        _NameList.Add(data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName].ToString());

                        break;
				}
			}

		}
		#endregion 条件設定ダイアログに渡すリストを作成:終

        #region ◆チャート用データセットスキーマ設定処理
        /// <summary>
        /// チャート用データセットスキーマ設定処理
        /// </summary>
		private void SetTableSchema()
        {
            this._chartDataSet.Tables.Clear();

			DataRow data;
			DataSet chartDs = this._chartDataSet;
			DataSet baseDs = this._baseDataSet;

            // 前年対比表チャート
			switch (this._ChartScIndex)
			{
				case 0:

					this._chartDataSet.Tables.Add(this._PrevYearReportDataTableRatio);
					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_TITLE, typeof(string));	// 集計月タイトル
					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_TITLE].DefaultValue = "";
					this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_TITLE].Caption = "集計月";

					for (int ix = 0; ix < this._baseDataSet.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_SALES_RATIO + i, typeof(Int64));	// 売上：比率
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].DefaultValue = 0;
						
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_GROSS_RATIO + i, typeof(Int64));	// 粗利：比率
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].DefaultValue = 0;


                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_GROSS_RATIO + i, typeof(Int64));	// 粗利：比率
                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].DefaultValue = 0;

                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns.Add(COL_SALES_RATIO + i, typeof(Int64));	// 売上：比率
                        this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].DefaultValue = 0;


						switch (this._extraparam.ListType)
						{
							#region ListType別に『詳細表示』タイトルを設定

							case 0:	//得意先別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " 売上：比率";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " 粗利：比率";

								break;

                            case 1:	//担当者別
                            case 2: //受注者別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " 売上：比率";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " 粗利：比率";

                                break;
							case 3:	//地区別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " 売上：比率";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " 粗利：比率";

								break;

							case 4:	//業種別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " 売上：比率";
								this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " 粗利：比率";

								break;

							case 5:	//ｸﾞﾙｰﾌﾟコード
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " 売上：比率";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " 粗利：比率";

								break;
                            case 6: //BLｺｰﾄﾞ別
                                data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_SALES_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " 売上：比率";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableRatio].Columns[COL_GROSS_RATIO + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " 粗利：比率";

                                break;
							#endregion ListType別に『詳細表示』タイトルを設定：終
						}

					}
					break;

				case 1:

					this._chartDataSet.Tables.Add(this._PrevYearReportDataTableSales);
					this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_TITLE, typeof(string));	// 集計月タイトル
					this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_TITLE].DefaultValue = "";
					this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_TITLE].Caption = "集計月";

					for (int ix = 0; ix < this._baseDataSet.Tables[this._PrevYearReportTable].Rows.Count; ix++)
					{
						string i = ix.ToString();

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_SALES + i, typeof(Int64));	    // 売上：当年
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].DefaultValue = 0;

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_SALES + i, typeof(Int64));	// 売上：当年
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].DefaultValue = 0;

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_GROSS + i, typeof(Int64));	// 粗利：当年
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].DefaultValue = 0;

                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_GROSS + i, typeof(Int64));   // 粗利：前年
                        //this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].DefaultValue = 0;


                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_GROSS + i, typeof(Int64));	// 粗利：当年
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].DefaultValue = 0;

                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_GROSS + i, typeof(Int64));   // 粗利：前年
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].DefaultValue = 0;
                        
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_THIS_SALES + i, typeof(Int64));	    // 売上：当年
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].DefaultValue = 0;

                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns.Add(COL_FIRST_SALES + i, typeof(Int64));	// 売上：前年
                        this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].DefaultValue = 0;

                        
                        
                        switch (this._extraparam.ListType)
						{
							#region ListType別に『詳細表示』タイトルを設定
							case 0:	//得意先別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " 売上：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " 売上：前年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " 粗利：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_CustomerSnm] + " 粗利：前年";
								break;
                            case 1:	//担当者別
                            case 2: //受注者別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " 売上：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " 売上：前年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " 粗利：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_EmployeeName] + " 粗利：前年";
								break;
							case 3:	//地区別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " 売上：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " 売上：前年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " 粗利：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_SalesAreaName] + " 粗利：前年";
								break;
							case 4:	//業種別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " 売上：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " 売上：前年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " 粗利：当年";
								this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BusinessTypeName] + " 粗利：前年";
								break;
							case 5:	//ｸﾞﾙｰﾌﾟｺｰﾄﾞ別
								data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " 売上：当年";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " 売上：前年";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " 粗利：当年";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] + " 粗利：前年";
								break;
                            case 6: //ＢＬｺｰﾄﾞ別
                                data = baseDs.Tables[this._PrevYearReportTable].Rows[ix];

                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " 売上：当年";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_SALES + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " 売上：前年";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_THIS_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " 粗利：当年";
                                this._chartDataSet.Tables[this._PrevYearReportDataTableSales].Columns[COL_FIRST_GROSS + i].Caption = data[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] + " 粗利：前年";
                                break;
							#endregion ListType別に『詳細表示』タイトルを設定：終
						}
					}
					break;
					}
        }
        #endregion


        #endregion

        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "前年対比表抽出処理", iMsg, iSt, iButton, iDefButton);
        }




	}

}
