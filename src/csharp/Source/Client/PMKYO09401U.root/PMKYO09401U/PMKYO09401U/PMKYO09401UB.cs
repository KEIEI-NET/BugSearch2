//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 抽出条件詳細画面
// プログラム概要   : 抽出条件詳細画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 作 成 日  2011/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/08/24  修正内容 : Redmine #23930　ソースレビュー結果対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原 庸平
// 作 成 日  2012.07.26  修正内容 : 抽出データに従業員、ユーザーガイド、結合を項目に追加
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// 抽出条件詳細画面
    /// </summary>
    /// <remarks>
    /// Note       : 抽出条件詳細画面<br />
    /// Programmer : 丁建雄<br />
    /// Date       : 2011/08/01<br />
    /// Update     : <br />
    /// </remarks>
    public partial class PMKYO09401UB : Form
    {
        #region ■ Constructor ■
        public PMKYO09401UB(SndRcvHisWork sndRcvHisWork, object searchResult)
        {
            InitializeComponent();

            // 変数初期化
            //履歴グッリド
            detailsTable = new DataTable();
            _searchResult = searchResult;
            _sndRcvHisWork = sndRcvHisWork;

            // ボタン変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
        }
        #endregion ■ Constructor ■

        #region ■ Const Memebers ■
        private const String ENT_CODE = "企業コード";
        private const String SECTION = "拠点";
        private const String SEND_NO = "送信番号";
        private const String SEND_NO_DIV = "送信番号枝番";
        private const String GET_DATA_TYPE = "抽出データ";
        private const String GET_START_DATE = "抽出開始日時";
        private const String GET_END_DATE = "抽出終了日時";
        private const String START_CONDITION1 = "開始条件１";
        private const String END_CONDITION1 = "終了条件１";

        private const String START_CONDITION2 = "開始条件２";
        private const String END_CONDITION2 = "終了条件２";

        private const String START_CONDITION3 = "開始条件３";
        private const String END_CONDITION3 = "終了条件３";

        private const String START_CONDITION4 = "開始条件４";
        private const String END_CONDITION4 = "終了条件４";

        private const String START_CONDITION5 = "開始条件５";
        private const String END_CONDITION5 = "終了条件５";

        private const String START_CONDITION6 = "開始条件６";
        private const String END_CONDITION6 = "終了条件６";

        private const String START_CONDITION7 = "開始条件７";
        private const String END_CONDITION7 = "終了条件７";

        private const String START_CONDITION8 = "開始条件８";
        private const String END_CONDITION8 = "終了条件８";

        private const String START_CONDITION9 = "開始条件９";
        private const String END_CONDITION9 = "終了条件９";

        private const String START_CONDITION10 = "開始条件１０";
        private const String END_CONDITION10 = "終了条件１０";

        private const String CustomerRF = "得意先マスタ";
        private const String GoodsURF = "商品マスタ";
        private const String StockRF = "在庫マスタ";
        private const String SupplierRF = "仕入先マスタ";
        private const String RateRF = "掛率マスタ";
        // --- ADD 2012/07/26 ---------->>>>>
        private const String EmployeeDtlRF = "従業員設定マスタ";
        private const String UserGdBdURF = "ユーザーガイドマスタ(販売区分)";
        private const String JoinPartsURF = "結合マスタ";
        // --- ADD 2012/07/26 ----------<<<<<
        #endregion ■ Const Memebers ■

        #region ■ Private Field ■
        /// <summary>
        /// 抽出条件詳細グッリド
        /// </summary>
        private DataTable detailsTable;
        private object _searchResult;
        private SndRcvHisWork _sndRcvHisWork;
        private string _loginName;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        #endregion ■ Private Field ■

        #region ■ Public Method ■

        #endregion ■ Public Method ■

        #region ■ Event ■
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 画面の終了
                case "ButtonTool_Close":
                    {
                        //画面閉じる。
                        this.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : 画面ロードイベント</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMKYO09401UB_Load(object sender, EventArgs e)
        {
            this.DataSetColumnConstruction();
            this.ButtonInitialSetting();
            this.SetColumnStyle();

            // 詳細情報を表示する
            this.DetailShow();
        }
        #endregion ■ Event ■

        #region ■ Private Method ■
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット列情報構築処理です</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            this.detailsTable.Columns.Add(ENT_CODE, typeof(string));
            this.detailsTable.Columns.Add(SECTION, typeof(string));
            this.detailsTable.Columns.Add(SEND_NO, typeof(string));
            this.detailsTable.Columns.Add(SEND_NO_DIV, typeof(string));
            this.detailsTable.Columns.Add(GET_DATA_TYPE, typeof(string));
            this.detailsTable.Columns.Add(GET_START_DATE, typeof(string));
            this.detailsTable.Columns.Add(GET_END_DATE, typeof(string));
            this.detailsTable.Columns.Add(START_CONDITION1, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION1, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION2, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION2, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION3, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION3, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION4, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION4, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION5, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION5, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION6, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION6, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION7, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION7, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION8, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION8, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION9, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION9, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION10, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION10, typeof(string));

            this.uGrid_Details.DataSource = detailsTable;
        }

        /// <summary>
        /// レコードの列のスタイルの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レコードの列のスタイルの設定</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetColumnStyle()
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 表示幅設定
            Columns[this.detailsTable.Columns[ENT_CODE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SEND_NO_DIV].ColumnName].Width = 100;
            // --- DEL 2012/07/26 ---------->>>>>
            //Columns[this.detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 110;
            // --- DEL 2012/07/26 ----------<<<<<
            // --- ADD 2012/07/26 ---------->>>>>
            Columns[this.detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 250;
            // --- ADD 2012/07/26 ----------<<<<<
            Columns[this.detailsTable.Columns[GET_START_DATE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[GET_END_DATE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[START_CONDITION1].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION1].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION2].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION2].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION3].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION3].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION4].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION4].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION5].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION5].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION6].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION6].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION7].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION7].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION8].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION8].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION9].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION9].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION10].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION10].ColumnName].Width = 100;

            // 入力許可設定
            Columns[this.detailsTable.Columns[ENT_CODE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_NO_DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[GET_DATA_TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[GET_START_DATE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[GET_END_DATE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[START_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._loginName = LoginInfoAcquisition.Employee.Name;
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager1.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }

        /// <summary>
        /// 詳細情報を表示する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細情報を表示する</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void DetailShow()
        {
            int sndRcvHisConsNo = this._sndRcvHisWork.SndRcvHisConsNo;  // 送信番号
            ArrayList details = new ArrayList();
			SndRcvHisAcs sndRcvHisAcs = new SndRcvHisAcs();// ADD 2011.08.24
            ArrayList resultList = this._searchResult as ArrayList;
            SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();

            for (int i = 0; i < resultList.Count; i++)
            {
				if (resultList[i].GetType() == typeof(SndRcvHisWork))
				{
					SndRcvHisWork work = resultList[i] as SndRcvHisWork;
					if (work.SndRcvHisConsNo == sndRcvHisConsNo)
					{
						if (i <= (resultList.Count - 1))
						{
							if ((resultList[i + 1]).GetType() == typeof(ArrayList))
							{
								i++;
								// Get details
								details = resultList[i] as ArrayList;
							}
						}
						sndRcvHisWork = work;
						break;
					}
				}
            }
            if (details.Count == 0)
            {
                DataRow row = this.detailsTable.NewRow();
                row[this.detailsTable.Columns[ENT_CODE]] = sndRcvHisWork.EnterpriseCode;
				//row[this.detailsTable.Columns[SECTION]] = this.GetSetctionName(sndRcvHisWork.SectionCode.ToString());// DEL 2011.08.24
				row[this.detailsTable.Columns[SECTION]] = sndRcvHisAcs.GetSetctionName(sndRcvHisWork.SectionCode.ToString());// ADD 2011.08.24
                row[this.detailsTable.Columns[SEND_NO]] = sndRcvHisWork.SndRcvHisConsNo;
            }

            foreach (SndRcvEtrWork work in details)
            {
                DataRow row = this.detailsTable.NewRow();
                row[this.detailsTable.Columns[ENT_CODE]] = work.EnterpriseCode;
				//row[this.detailsTable.Columns[SECTION]] = this.GetSetctionName(work.SectionCode.ToString());// DEL 2011.08.24
				row[this.detailsTable.Columns[SECTION]] = sndRcvHisAcs.GetSetctionName(work.SectionCode.ToString());// ADD 2011.08.24
                row[this.detailsTable.Columns[SEND_NO]] = work.SndRcvHisConsNo;
                row[this.detailsTable.Columns[SEND_NO_DIV]] = work.SndRcvHisConsDerivNo;
                if (work.ExtraStartDate > DateTime.MinValue)
                {
					//row[this.detailsTable.Columns[GET_START_DATE]] = this.DateTimeFormatToString(work.ExtraStartDate);// DEL 2011.08.24
					row[this.detailsTable.Columns[GET_START_DATE]] = sndRcvHisAcs.DateTimeFormatToString(work.ExtraStartDate);// ADD 2011.08.24
                }else
                {
                    row[this.detailsTable.Columns[GET_START_DATE]] = "";
                }
                if (work.ExtraEndDate > DateTime.MinValue)
                {
					//row[this.detailsTable.Columns[GET_END_DATE]] = this.DateTimeFormatToString(work.ExtraEndDate);// DEL 2011.08.24
					row[this.detailsTable.Columns[GET_END_DATE]] = sndRcvHisAcs.DateTimeFormatToString(work.ExtraEndDate);// ADD 2011.08.24
                }
                else
                {
                    row[this.detailsTable.Columns[GET_END_DATE]] = "";
                }              
                
                row[this.detailsTable.Columns[START_CONDITION1]] = work.StartCond1;
                row[this.detailsTable.Columns[END_CONDITION1]] = work.EndCond1;
                row[this.detailsTable.Columns[START_CONDITION2]] = work.StartCond2;
                row[this.detailsTable.Columns[END_CONDITION2]] = work.EndCond2;
                row[this.detailsTable.Columns[START_CONDITION3]] = work.StartCond3;
                row[this.detailsTable.Columns[END_CONDITION3]] = work.EndCond3;
                row[this.detailsTable.Columns[START_CONDITION4]] = work.StartCond4;
                row[this.detailsTable.Columns[END_CONDITION4]] = work.EndCond4;
                row[this.detailsTable.Columns[START_CONDITION5]] = work.StartCond5;
                row[this.detailsTable.Columns[END_CONDITION5]] = work.EndCond5;
                row[this.detailsTable.Columns[START_CONDITION6]] = work.StartCond6;
                row[this.detailsTable.Columns[END_CONDITION6]] = work.EndCond6;
                row[this.detailsTable.Columns[START_CONDITION7]] = work.StartCond7;
                row[this.detailsTable.Columns[END_CONDITION7]] = work.EndCond7;
                row[this.detailsTable.Columns[START_CONDITION8]] = work.StartCond8;
                row[this.detailsTable.Columns[END_CONDITION8]] = work.EndCond8;
                row[this.detailsTable.Columns[START_CONDITION9]] = work.StartCond9;
                row[this.detailsTable.Columns[END_CONDITION9]] = work.EndCond9;
                row[this.detailsTable.Columns[START_CONDITION10]] = work.StartCond10;
                row[this.detailsTable.Columns[END_CONDITION10]] = work.EndCond10;

                if ("CustomerRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = CustomerRF;
                }
                else if ("GoodsURF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = GoodsURF;
                }
                else if ("StockRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = StockRF;
                }
                else if ("SupplierRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = SupplierRF;
                }
                else if ("RateRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = RateRF;
                }
                // --- ADD 2012/07/26 ---------->>>>>
                else if ("EmployeeDtlRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = EmployeeDtlRF;
                }
                else if ("UserGdBdURF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = UserGdBdURF;
                }
                else if ("JoinPartsURF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = JoinPartsURF;
                }
                // --- ADD 2012/07/26 ----------<<<<<

                this.detailsTable.Rows.Add(row);
            }
        }

		// DEL 2011.08.24 --------------->>>>>
		///// <summary>
		///// 拠点情報を取得
		///// </summary>
		///// <param name="sectionCode"></param>
		///// <returns></returns>
		//private string GetSetctionName(string sectionCode) 
		//{
		//    string sectionName = null;

		//    SecInfoAcs secInfoAcs = new SecInfoAcs();
		//    try
		//    {
		//        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
		//        {
		//            if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
		//            {
		//                sectionName = secInfoSet.SectionGuideNm.Trim();
		//                break;
		//            }
		//        }
		//    }
		//    catch
		//    {
		//        sectionName = string.Empty;
		//    }

		//    return sectionName;
		//}		

		///// <summary>
		///// DateTimeの日時はStringにする
		///// </summary>
		///// <param name="dateTime">DateTimeの日時</param>
		///// <returns>Stringの日時</returns>
		///// <remarks>
		///// <br>Note       : DateTimeの日時はStringにする</br>
		///// <br>Programmer : 丁建雄</br>
		///// <br>Date       : 2011/08/01</br>
		///// </remarks>
		//private string DateTimeFormatToString(DateTime dateTime)
		//{
		//    string time = null;
		//    time += dateTime.Year + "年";
		//    time += dateTime.Month + "月";
		//    time += dateTime.Day + "日";
		//    time += dateTime.Hour + "時";
		//    time += dateTime.Minute + "分";
		//    time += dateTime.Second + "秒";

		//    return time;
		//}
		// DEL 2011.08.24 ---------------<<<<<
        #endregion ■ Private Method ■
    }
}