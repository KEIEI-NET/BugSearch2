//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 更新履歴表示
// プログラム概要   : 更新履歴表示の検索・表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2008/09/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤仁美
// 作 成 日  2008/10/28  修正内容 : バグ修正[7083]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤仁美
// 作 成 日  2008/11/04  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤仁美
// 作 成 日  2008/11/06  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤仁美
// 作 成 日  2008/11/11  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/02/04  修正内容 : 障害ID:10398対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/03/09  修正内容 : 障害ID:11404,11711対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/03/12  修正内容 : 障害ID:12290対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野俊治
// 作 成 日  2009/04/02  修正内容 : 障害ID:13057対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/01  修正内容 : 障害ID:13405対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/04  修正内容 : 障害ID:13405対応(ソート順と実施日の出力形式を変更)
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 更新履歴表示UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 更新履歴表示UIフォームクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2008/09/29</br>
    /// <br>UpdateNote  : 2008/10/28 30462 行澤 仁美　バグ修正[7083]</br>
    /// <br>UpdateNote  : 2008/11/04 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2008/11/06 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2008/11/11 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2009/02/04 30414 忍幸史　障害ID:10398対応</br>
    /// <br>UpdateNote  : 2009/03/09 30414 忍幸史　障害ID:11404,11711対応</br>
    /// <br>UpdateNote  : 2009/03/12 30414 忍幸史　障害ID:12290対応</br>
    /// <br>UpdateNote  : 2009/04/02 30452 上野俊治　障害ID:13057対応</br>
    /// </remarks>
    public partial class PMKAU04101UA : Form
    {
        #region Constants

        // アセンブリID
        private const string ASSMBLY_ID = "PMKAU04101U";

        // グリッド列
        private const string COLUMN_NO = "No";
        private const string COLUMN_CADDUPUPDDATE = "CAddUpUpdDate";
        private const string COLUMN_CADDUPUPDEXECDATE = "CAddUpUpdExecDate";
        private const string COLUMN_SECTIONCD = "SectionCd";
        private const string COLUMN_SECTIONNM = "SectionNm";
        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
        //private const string COLUMN_CUSTOMERCD = "CustomerCd";
        //private const string COLUMN_CUSTOMERNM = "CustomerNm";
        //private const string COLUMN_SUPPLIERCD = "SupplierCd";
        //private const string COLUMN_SUPPLIERNM = "SupplierNm";
        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
        private const string COLUMN_PROCDIVCD = "ProcDivCd";
        private const string COLUMN_PROCRESULT = "ProcResult";

        // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
        private const string COLUMN_EXECSECTIONCD = "ExecSectionCd";
        private const string COLUMN_EXECSECTIONNM = "ExecSectionNm";
        private const string COLUMN_EXECEMPLOYEECD = "ExecEmployeeCd";
        // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

        #endregion Constants


        #region Private Members

        private ControlScreenSkin _controlScreenSkin;

        private UpdHisDspAcs _updHisDspAcs;
        private SecInfoAcs _secInfoAcs;

        private bool _topPanelFlg = false;          // ヘッダパネルサイズ制御用フラグ
        private bool _secPanelFlg = false;          // ヘッダパネルサイズ制御用フラグ

        #endregion


        #region Constructor

        /// <summary>
        /// 更新履歴表示UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 更新履歴表示UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public PMKAU04101UA()
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._updHisDspAcs = new UpdHisDspAcs();
            this._secInfoAcs = new SecInfoAcs();

            // 画面クリア
            ClearScreen();

            // 画面初期設定
            SetInitialSetting();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            excCtrlNm.Add(this.Detail_UGroupBox.Name);
            excCtrlNm.Add(this.Section_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            //---------------------------------
            // ツールバーアイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            // --- CHG 2009/03/12 障害ID:12290対応------------------------------------------------------>>>>>
            //workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // --- CHG 2009/03/12 障害ID:12290対応------------------------------------------------------<<<<<
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            //---------------------------------
            // 拠点リスト作成
            //---------------------------------
            this.CheckedListBox_SectionCode.Items.Clear();
            
            // 全社ノード追加
            this.CheckedListBox_SectionCode.Items.Add("全社", CheckState.Checked);

            // CheckListに拠点を追加
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode != 0)
                {
                    continue;
                }

                this.CheckedListBox_SectionCode.Items.Add(secInfoSet.SectionGuideNm.TrimEnd());
            }

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(new List<RsltInfo_UpdHisDspWork>());
            SetGridLayout();

            //---------------------------------
            // 初期値設定
            //---------------------------------
            // 表示区分(0:請求)
            this.tComboEditor_DispDiv.Value = 0;
            // 処理種別(0:全て)
            this.tComboEditor_ProcKnd.Value = -1;
            // 結果種別(0:全て)
            this.tComboEditor_RsltKnd.Value = -1;
        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点コード(全社にチェック)
            this.CheckedListBox_SectionCode.SetItemChecked(0, true);
            this.CheckedListBox_SectionCode.TopIndex = 0;

            // 実施日
            this.tDateEdit_CAddUpUpdExecDateSt.SetDateTime(this._updHisDspAcs.GetStartYearDate());
            this.tDateEdit_CAddUpUpdExecDateEd.SetDateTime(DateTime.Today);
            // 処理日
            this.tDateEdit_CAddUpUpdDateSt.SetDateTime(DateTime.MinValue);
            this.tDateEdit_CAddUpUpdDateEd.SetDateTime(DateTime.MinValue);
            // 表示区分
            this.tComboEditor_DispDiv.Value = 0;
            // 処理種別
            this.tComboEditor_ProcKnd.Value = -1;
            // 結果種別
            this.tComboEditor_RsltKnd.Value = -1;
            // グリッド
            CreateGrid(new List<RsltInfo_UpdHisDspWork>());
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="updHisDspWorkList">更新履歴リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void CreateGrid(List<RsltInfo_UpdHisDspWork> updHisDspWorkList)
        {
            //--------------------------------------
            // グリッド列、データ設定
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            dataTable.Columns.Add(COLUMN_CADDUPUPDDATE, typeof(string));
            // DEL 2009/06/04 ------>>>
            //// --- CHG 2009/03/09 障害ID:11404,11711対応------------------------------------------------------>>>>>
            ////dataTable.Columns.Add(COLUMN_CADDUPUPDEXECDATE, typeof(string));
            //dataTable.Columns.Add(COLUMN_CADDUPUPDEXECDATE, typeof(DateTime));
            //// --- CHG 2009/03/09 障害ID:11404,11711対応------------------------------------------------------<<<<<
            // DEL 2009/06/04 ------<<<
            dataTable.Columns.Add(COLUMN_CADDUPUPDEXECDATE, typeof(string));    // ADD 2009/06/04

            dataTable.Columns.Add(COLUMN_SECTIONCD, typeof(string));
            dataTable.Columns.Add(COLUMN_SECTIONNM, typeof(string));
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            //dataTable.Columns.Add(COLUMN_CUSTOMERCD, typeof(string));
            //dataTable.Columns.Add(COLUMN_CUSTOMERNM, typeof(string));
            //dataTable.Columns.Add(COLUMN_SUPPLIERCD, typeof(string));
            //dataTable.Columns.Add(COLUMN_SUPPLIERNM, typeof(string));
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
            dataTable.Columns.Add(COLUMN_PROCDIVCD, typeof(string));
            dataTable.Columns.Add(COLUMN_PROCRESULT, typeof(string));

            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            dataTable.Columns.Add(COLUMN_EXECSECTIONCD, typeof(string));
            dataTable.Columns.Add(COLUMN_EXECSECTIONNM, typeof(string));
            dataTable.Columns.Add(COLUMN_EXECEMPLOYEECD, typeof(string));
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

            int rowCount = 1;
            foreach (RsltInfo_UpdHisDspWork rsltInfo in updHisDspWorkList)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_NO] = rowCount;

                switch ((int)this.tComboEditor_DispDiv.Value)
                {
                    case 0:
                        // 表示区分が「請求」の場合、締次更新年月日を表示
                        dataRow[COLUMN_CADDUPUPDDATE] = rsltInfo.CAddUpUpdDate.ToShortDateString();

                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                        //if (rsltInfo.CustomerCode == 0)
                        //{
                        //    dataRow[COLUMN_CUSTOMERCD] = "";
                        //    dataRow[COLUMN_CUSTOMERNM] = "一括";
                        //}
                        //else
                        //{
                        //    dataRow[COLUMN_CUSTOMERCD] = rsltInfo.CustomerCode.ToString("00000000");
                        //    dataRow[COLUMN_CUSTOMERNM] = this._updHisDspAcs.GetCustomerName(rsltInfo.CustomerCode);
                        //}
                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
                        break;
                    case 1:
                        // 表示区分が「支払」の場合、締次更新年月日を表示
                        dataRow[COLUMN_CADDUPUPDDATE] = rsltInfo.CAddUpUpdDate.ToShortDateString();

                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                        //if (rsltInfo.SupplierCd == 0)
                        //{
                        //    dataRow[COLUMN_SUPPLIERCD] = "";
                        //    dataRow[COLUMN_SUPPLIERNM] = "一括";
                        //}
                        //else
                        //{
                        //    dataRow[COLUMN_SUPPLIERCD] = rsltInfo.SupplierCd.ToString("000000");
                        //    dataRow[COLUMN_SUPPLIERNM] = this._updHisDspAcs.GetSupplierName(rsltInfo.SupplierCd);
                        //}
                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
                        break;
                    case 2:
                    case 3:
                        // 表示区分が「売上月次、仕入月次」の場合、月次更新年月を表示
                        //dataRow[COLUMN_CADDUPUPDDATE] = rsltInfo.MonthlyAddUpDate.ToString("yyyy/MM");  // DEL 2008/11/04 不具合対応[7084]
                        dataRow[COLUMN_CADDUPUPDDATE] = rsltInfo.MonthAddUpYearMonth.ToString("yyyy/MM");   // ADD 2008/11/04 不具合対応[7084]
                        break;
                }

                //dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.CAddUpUpdExecDate.ToShortDateString(); // DEL 2008/11/04 不具合対応[7084]
                
                // DEL 2009/06/01 ------>>>
                //// --- CHG 2009/03/09 障害ID:11404,11711対応------------------------------------------------------>>>>>
                ////// ADD 2008/11/04 不具合対応[7084] ---------->>>>>
                ////switch ((int)this.tComboEditor_DispDiv.Value)
                ////{
                ////    case 0:
                ////    case 1:
                ////        dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.CAddUpUpdExecDate.ToShortDateString();
                ////        break;
                ////    case 2:
                ////    case 3:
                ////        dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.MonthAddUpExpDate.ToShortDateString();
                ////        break;
                ////}
                ////// ADD 2008/11/04 不具合対応[7084] ----------<<<<<
                //DateTime dateTime = new DateTime(rsltInfo.DataUpdateDateTime);
                //dataRow[COLUMN_CADDUPUPDEXECDATE] = dateTime;
                //// --- CHG 2009/03/09 障害ID:11404,11711対応------------------------------------------------------<<<<<
                // DEL 2009/06/01 ------<<<
                
                // ADD 2009/06/01 ------>>>
                if (rsltInfo.ConvertProcessDivCd == 1)
                {
                    // コンバートデータは、更新実行日を表示
                    switch ((int)this.tComboEditor_DispDiv.Value)
                    {
                        case 0:
                        case 1:
                            //dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.CAddUpUpdExecDate;   // DEL 2009/06/04
                            dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.CAddUpUpdExecDate.ToString("yyyy/MM/dd");  // ADD 2009/06/04
                            break;
                        case 2:
                        case 3:
                            //dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.MonthAddUpExpDate;   // DEL 2009/06/04
                            dataRow[COLUMN_CADDUPUPDEXECDATE] = rsltInfo.MonthAddUpExpDate.ToString("yyyy/MM/dd");  // ADD 2009/06/04
                            break;
                    }
                }
                else
                {
                    // 通常データは、データ更新日時を表示
                    DateTime dateTime = new DateTime(rsltInfo.DataUpdateDateTime);
                    //dataRow[COLUMN_CADDUPUPDEXECDATE] = dateTime;     // DEL 2009/06/04
                    dataRow[COLUMN_CADDUPUPDEXECDATE] = dateTime.ToString("yyyy/MM/dd HH:mm:ss");   // ADD 2009/06/04
                }
                // ADD 2009/06/01 ------<<<
                
                if (rsltInfo.AddUpSecCode.Trim() == "")
                {
                    dataRow[COLUMN_SECTIONCD] = "";
                    dataRow[COLUMN_SECTIONNM] = "一括";
                }
                else
                {
                    dataRow[COLUMN_SECTIONCD] = rsltInfo.AddUpSecCode.Trim();
                    dataRow[COLUMN_SECTIONNM] = this._updHisDspAcs.GetSectionName(rsltInfo.AddUpSecCode.Trim());
                }
                
                dataRow[COLUMN_PROCDIVCD] = GetProcKndName(rsltInfo.ProcDivCd);
                dataRow[COLUMN_PROCRESULT] = rsltInfo.ProcResult.Trim();

                // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                dataRow[COLUMN_EXECSECTIONCD] = rsltInfo.BelongSectionCode.Trim();
                dataRow[COLUMN_EXECSECTIONNM] = rsltInfo.SectionGuideSnm.Trim();
                dataRow[COLUMN_EXECEMPLOYEECD] = rsltInfo.UpdEmployeeCode.Trim();
                // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

                dataTable.Rows.Add(dataRow);

                rowCount++;
            }

            this.uGrid_Details.DataSource = dataTable;

            // --- ADD 2009/03/09 障害ID:11404,11711対応------------------------------------------------------>>>>>
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_CADDUPUPDEXECDATE].Format = "yyyy/MM/dd";    // DEL 2009/06/04
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_CADDUPUPDEXECDATE].CellActivation = Activation.NoEdit;
            // --- ADD 2009/03/09 障害ID:11404,11711対応------------------------------------------------------<<<<<

            if (updHisDspWorkList.Count != 0)
            {
                this.uGrid_Details.TabStop = true;
                this.uGrid_Details.Focus();
                this.uGrid_Details.Rows[0].Selected = true;
            }
            else
            {
                this.uGrid_Details.TabStop = false;
                this.tDateEdit_CAddUpUpdExecDateSt.Focus();
            }
        }

        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドレイアウトを設定します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // グリッド外観設定
            //--------------------------------------
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // キャプション
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_CADDUPUPDDATE].Header.Caption = "処理日";
            columns[COLUMN_CADDUPUPDEXECDATE].Header.Caption = "実施日";
            columns[COLUMN_SECTIONCD].Header.Caption = "拠点コード";
            columns[COLUMN_SECTIONNM].Header.Caption = "拠点名";
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            //columns[COLUMN_CUSTOMERCD].Header.Caption = "得意先コード";
            //columns[COLUMN_CUSTOMERNM].Header.Caption = "得意先名";
            //columns[COLUMN_SUPPLIERCD].Header.Caption = "仕入先コード";
            //columns[COLUMN_SUPPLIERNM].Header.Caption = "仕入先名";
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
            columns[COLUMN_PROCDIVCD].Header.Caption = "処理種別";
            columns[COLUMN_PROCRESULT].Header.Caption = "処理結果";
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            columns[COLUMN_EXECSECTIONCD].Header.Caption = "処理拠点コード";
            columns[COLUMN_EXECSECTIONNM].Header.Caption = "処理拠点名";
            columns[COLUMN_EXECEMPLOYEECD].Header.Caption = "処理担当者コード";
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

            // 列幅
            columns[COLUMN_NO].Width = 50;
            columns[COLUMN_CADDUPUPDDATE].Width = 95;
            //columns[COLUMN_CADDUPUPDEXECDATE].Width = 95;     // DEL 2009/06/04
            columns[COLUMN_CADDUPUPDEXECDATE].Width = 165;      // ADD 2009/06/04
            columns[COLUMN_SECTIONCD].Width = 80;
            columns[COLUMN_SECTIONNM].Width = 110;
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            //columns[COLUMN_CUSTOMERCD].Width = 100;
            //columns[COLUMN_CUSTOMERNM].Width = 320;
            //columns[COLUMN_SUPPLIERCD].Width = 100;
            //columns[COLUMN_SUPPLIERNM].Width = 320;
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
            columns[COLUMN_PROCDIVCD].Width = 100;
            columns[COLUMN_PROCRESULT].Width = 100;
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            columns[COLUMN_EXECSECTIONCD].Width = 80;
            columns[COLUMN_EXECSECTIONNM].Width = 110;
            columns[COLUMN_EXECEMPLOYEECD].Width = 110;
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            //// 列表示設定
            //switch ((int)this.tComboEditor_DispDiv.Value)
            //{
            //    case 0:
            //        // 表示区分が「請求」の時
            //        columns[COLUMN_CUSTOMERCD].Hidden = false;
            //        columns[COLUMN_CUSTOMERNM].Hidden = false;
            //        columns[COLUMN_SUPPLIERCD].Hidden = true;
            //        columns[COLUMN_SUPPLIERNM].Hidden = true;
            //        break;
            //    case 1:
            //        // 表示区分が「支払」の時
            //        columns[COLUMN_CUSTOMERCD].Hidden = true;
            //        columns[COLUMN_CUSTOMERNM].Hidden = true;
            //        columns[COLUMN_SUPPLIERCD].Hidden = false;
            //        columns[COLUMN_SUPPLIERNM].Hidden = false;
            //        break;
            //    default:
            //        columns[COLUMN_CUSTOMERCD].Hidden = true;
            //        columns[COLUMN_CUSTOMERNM].Hidden = true;
            //        columns[COLUMN_SUPPLIERCD].Hidden = true;
            //        columns[COLUMN_SUPPLIERNM].Hidden = true;
            //        break;
            //}
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

            // テキスト位置(HAlign)
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_CADDUPUPDDATE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_CADDUPUPDEXECDATE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONCD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SECTIONNM].CellAppearance.TextHAlign = HAlign.Left;
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            //columns[COLUMN_CUSTOMERCD].CellAppearance.TextHAlign = HAlign.Right;
            //columns[COLUMN_CUSTOMERNM].CellAppearance.TextHAlign = HAlign.Left;
            //columns[COLUMN_SUPPLIERCD].CellAppearance.TextHAlign = HAlign.Right;
            //columns[COLUMN_SUPPLIERNM].CellAppearance.TextHAlign = HAlign.Left;
            // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
            columns[COLUMN_PROCDIVCD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_PROCRESULT].CellAppearance.TextHAlign = HAlign.Left;
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
            columns[COLUMN_EXECSECTIONCD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_EXECSECTIONNM].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_EXECEMPLOYEECD].CellAppearance.TextHAlign = HAlign.Left;
            // --- ADD 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<

            // テキスト位置(VAlign)
            foreach (UltraGridColumn column in columns)
            {
                column.CellAppearance.TextVAlign = VAlign.Middle;
            }

            // 固定ヘッダー
            columns[COLUMN_NO].Header.Fixed = true;
        }

        /// <summary>
        /// 処理種別名称取得処理
        /// </summary>
        /// <param name="procKndCode">処理種別コード</param>
        /// <returns>処理種別名称</returns>
        /// <remarks>
        /// <br>Note        : 処理種別名称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private string GetProcKndName(int procKndCode)
        {
            string procKndName = "";

            switch (procKndCode)
            {
                case 0:
                    procKndName = "更新処理";
                    break;
                case 1:
                    procKndName = "解除処理";
                    break;
                default:
                    procKndName = "";
                    break;
            }

            return procKndName;
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 確定処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void Search()
        {
            // 画面情報チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return;
            }

            // 検索条件格納
            ExtrInfo_UpdHisDspWork extrInfo;
            SetExtrInfo(out extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "更新履歴データの抽出中です。";

            int status;
            List<RsltInfo_UpdHisDspWork> updHisDspWorkList;

            try
            {
                msgForm.Show();

                // 検索処理
                status = this._updHisDspAcs.Search(extrInfo, out updHisDspWorkList);
                if (status == 0)
                {
                    // ソート(処理日(降順)、拠点コードの順)
                    updHisDspWorkList.Sort(delegate(RsltInfo_UpdHisDspWork x, RsltInfo_UpdHisDspWork y)
                    {
                        DateTime dateTimeX = new DateTime();
                        DateTime dateTimeY = new DateTime();

                        // DEL 2009/06/04 ------>>>
                        //switch ((int)this.tComboEditor_DispDiv.Value)
                        //{
                        //    case 0:
                        //    case 1:
                        //        // 表示区分が「請求、支払」の場合、締次更新年月日で比較
                        //        dateTimeX = x.CAddUpUpdDate;
                        //        dateTimeY = y.CAddUpUpdDate;
                        //        break;
                        //    case 2:
                        //    case 3:
                        //        // 表示区分が「売上月次、仕入月次」の場合、月次更新年月で比較
                        //        dateTimeX = x.MonthlyAddUpDate;
                        //        dateTimeY = y.MonthlyAddUpDate;
                        //        break;
                        //}
                        // DEL 2009/06/04 ------<<<

                        // ADD 2009/06/04 ------>>>
                        if (x.ConvertProcessDivCd == 1)
                        {
                            // コンバートデータは、更新実行日で比較
                            switch ((int)this.tComboEditor_DispDiv.Value)
                            {
                                case 0:
                                case 1:
                                    dateTimeX = x.CAddUpUpdExecDate;
                                    break;
                                case 2:
                                case 3:
                                    dateTimeX = x.MonthAddUpExpDate;
                                    break;
                            }
                        }
                        else
                        {
                            // 通常データは、データ更新日時で比較
                            dateTimeX = new DateTime(x.DataUpdateDateTime);
                        }

                        if (y.ConvertProcessDivCd == 1)
                        {
                            // コンバートデータは、更新実行日で比較
                            switch ((int)this.tComboEditor_DispDiv.Value)
                            {
                                case 0:
                                case 1:
                                    dateTimeY = y.CAddUpUpdExecDate;
                                    break;
                                case 2:
                                case 3:
                                    dateTimeY = y.MonthAddUpExpDate;
                                    break;
                            }
                        }
                        else
                        {
                            // 通常データは、データ更新日時で比較
                            dateTimeY = new DateTime(y.DataUpdateDateTime);
                        }
                        // ADD 2009/06/04 ------<<<
                        
                        if (dateTimeX == dateTimeY)
                        {
                            long longX = x.DataUpdateDateTime;
                            long longY = y.DataUpdateDateTime;

                            if (longX == longY)
                            {
                                return String.Compare(x.AddUpSecCode, y.AddUpSecCode);
                            }
                            else if (longX > longY)
                            {
                                return (-1);
                            }
                            else
                            {
                                return (1);
                            }
                        }
                        else if (dateTimeX > dateTimeY)
                        {
                            return (-1);
                        }
                        else
                        {
                            return (1);
                        }
                    });

                    // グリッド作成
                    CreateGrid(updHisDspWorkList);
                    return;
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "検索条件に該当する更新履歴は存在しません。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<RsltInfo_UpdHisDspWork>());
                        return;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "確定処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<RsltInfo_UpdHisDspWork>());
                        return;
                    }
            }
        }

        /// <summary>
        /// 画面情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報をチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // 拠点
                if (this.CheckedListBox_SectionCode.CheckedItems.Count == 0)
                {
                    errMsg = "出力対象拠点を選択してください。";
                    this.CheckedListBox_SectionCode.Focus();
                    this.CheckedListBox_SectionCode.SelectedIndex = 0;
                    return (false);
                }

                // 実施日(開始)
                // DEL 2008/10/28 不具合対応[7083] ↓
                //if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateSt, true, out errMsg) == false)
                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                //if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateSt, true, true, out errMsg) == false) // DEL 2009/04/02
                if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateSt, false, true, out errMsg) == false) // ADD 2009/04/02
                // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                {
                    // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                    errMsg = "実施日の入力が不正です";
                    // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                    this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                    return (false);
                }
                // 実施日(終了)
                // DEL 2008/10/28 不具合対応[7083] ↓
                //if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateEd, true, out errMsg) == false)
                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                //if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateEd, true, true, out errMsg) == false) // DEL 2009/04/02
                if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateEd, false, true, out errMsg) == false) // ADD 2009/04/02
                // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                {
                    // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                    errMsg = "実施日の入力が不正です";
                    // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                    this.tDateEdit_CAddUpUpdExecDateEd.Focus();
                    return (false);
                }
                // 実施日範囲チェック
                if (this.tDateEdit_CAddUpUpdExecDateSt.GetDateTime() != DateTime.MinValue
                    && this.tDateEdit_CAddUpUpdExecDateEd.GetDateTime() != DateTime.MinValue)
                {
                    if (this.tDateEdit_CAddUpUpdExecDateSt.GetDateTime() > this.tDateEdit_CAddUpUpdExecDateEd.GetDateTime())
                    {
                        errMsg = "実施日の範囲指定に誤りがあります。";
                        this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                        return (false);
                    }
                }

                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                bool DayCheck = true;
                if (this.tComboEditor_DispDiv.Value.ToString().Equals("2") ||
                    this.tComboEditor_DispDiv.Value.ToString().Equals("3"))
                {
                    DayCheck = false;
                }
                // ADD 2008/10/09 不具合対応[7083] ----------<<<<<

                // 処理日(開始)
                // DEL 2008/10/28 不具合対応[7083] ↓
                //if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdDateSt, false, out errMsg) == false)
                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdDateSt, false, DayCheck,out errMsg) == false)
                // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                {
                    // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                    errMsg = "処理日の入力が不正です";
                    // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                    this.tDateEdit_CAddUpUpdDateSt.Focus();
                    return (false);
                }
                // 処理日(終了)
                // DEL 2008/10/28 不具合対応[7083] ↓
                //if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdDateEd, false, out errMsg) == false)
                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdDateEd, false, DayCheck, out errMsg) == false)
                // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                {
                    // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                    errMsg = "処理日の入力が不正です";
                    // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
                    this.tDateEdit_CAddUpUpdDateEd.Focus();
                    return (false);
                }
                // 処理日範囲チェック
                if ((this.tDateEdit_CAddUpUpdDateSt.GetDateTime() != DateTime.MinValue) &&
                    (this.tDateEdit_CAddUpUpdDateEd.GetDateTime() != DateTime.MinValue))
                {
                    if (this.tDateEdit_CAddUpUpdDateSt.GetDateTime() > this.tDateEdit_CAddUpUpdDateEd.GetDateTime())
                    {
                        errMsg = "処理日の範囲指定に誤りがあります。";
                        this.tDateEdit_CAddUpUpdDateSt.Focus();
                        return (false);
                    }
                }
                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                if (DayCheck == false)
                {
                    if (this.tDateEdit_CAddUpUpdDateSt.GetLongDate() != 0 &&
                        this.tDateEdit_CAddUpUpdDateEd.GetLongDate() != 0)
                    {
                        if (this.tDateEdit_CAddUpUpdDateSt.GetLongDate() > this.tDateEdit_CAddUpUpdDateEd.GetLongDate())
                        {
                            errMsg = "処理日の範囲指定に誤りがあります。";
                            this.tDateEdit_CAddUpUpdDateSt.Focus();
                            return (false);
                        }
                    }
                }
                // ADD 2008/10/09 不具合対応[7083] ----------<<<<<
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="minValueCheck">未入力チェックフラグ(True:未入力不可 False:未入力可)</param>
        /// <param name="dayCheck">日付チェックフラグ(True:日付チェックあり False:日付チェックなし)2008/10/28追加</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, bool dayCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "日付を指定してください。";
                    return (false);
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }
                // ADD 2008/10/28 不具合対応[7083] ---------->>>>>
                if (dayCheck)
                {
                    if ((year == 0) || (month == 0) || (day == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
                else
                {
                    if ((year == 0) || (month == 0))
                    {
                        errMsg = "日付を指定してください。";
                        return (false);
                    }
                }
                // ADD 2008/10/28 不具合対応[7083] ----------<<<<<
            }

            if (year < 1900)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void SetExtrInfo(out ExtrInfo_UpdHisDspWork extrInfo)
        {
            extrInfo = new ExtrInfo_UpdHisDspWork();

            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 出力対象拠点
            // チェックされているアイテムの中に「全て」が存在するか
            if (this.CheckedListBox_SectionCode.CheckedItems.Contains(this.CheckedListBox_SectionCode.Items[0]))
            {
                // 全社が選択されているとき
                string[] sectionList = new string[this.CheckedListBox_SectionCode.CheckedItems.Count];
                sectionList[0] = "";
                extrInfo.AddupSecCodeList = sectionList;
            }
            else
            {
                // 「全社」がない場合
                int itemIndex = 0;
                string[] sectionList = new string[this.CheckedListBox_SectionCode.CheckedItems.Count];

                foreach (object checkedItem in this.CheckedListBox_SectionCode.CheckedItems)
                {
                    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                    {
                        if (secInfoSet.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        if (secInfoSet.SectionGuideNm == (string)checkedItem)
                        {
                            sectionList[itemIndex] = secInfoSet.SectionCode;
                            itemIndex++;
                            break;
                        }
                    }
                }
                extrInfo.AddupSecCodeList = sectionList;
            }

            // ADD 2008/11/06 不具合対応[7084] ---------->>>>>
            if ((int)this.tComboEditor_DispDiv.Value >= 2)
            {
                // 開始締次更新年月日
                if (this.tDateEdit_CAddUpUpdDateSt.GetLongDate() != 0)
                {
                    extrInfo.St_CAddUpUpdDate = Int32.Parse(this.tDateEdit_CAddUpUpdDateSt.GetLongDate().ToString().Substring(0, 6));
                }
                else
                {
                    extrInfo.St_CAddUpUpdDate = this.tDateEdit_CAddUpUpdDateSt.GetLongDate();
                }
                // 終了締次更新年月日
                if (this.tDateEdit_CAddUpUpdDateEd.GetLongDate() != 0)
                {

                    extrInfo.Ed_CAddUpUpdDate = Int32.Parse(this.tDateEdit_CAddUpUpdDateEd.GetLongDate().ToString().Substring(0, 6));
                }
                else
                {
                    extrInfo.Ed_CAddUpUpdDate = this.tDateEdit_CAddUpUpdDateEd.GetLongDate();
                }
            }
            else
            {
                // ADD 2008/11/06 不具合対応[7084] ----------<<<<<

                // 開始締次更新年月日
                extrInfo.St_CAddUpUpdDate = this.tDateEdit_CAddUpUpdDateSt.GetLongDate();
                // 終了締次更新年月日
                extrInfo.Ed_CAddUpUpdDate = this.tDateEdit_CAddUpUpdDateEd.GetLongDate();
                // ADD 2008/11/06 不具合対応[7084] ---------->>>>>
            }
            // ADD 2008/11/06 不具合対応[7084] ----------<<<<<
            // 開始締次更新実行年月日
            extrInfo.St_CAddUpUpdExecDate = this.tDateEdit_CAddUpUpdExecDateSt.GetLongDate();
            // 終了締次更新年月日
            extrInfo.Ed_CAddUpUpdExecDate = this.tDateEdit_CAddUpUpdExecDateEd.GetLongDate();
            // 表示区分
            extrInfo.DispDiv = (int)this.tComboEditor_DispDiv.Value;
            // 処理種別
            extrInfo.ProcKnd = (int)this.tComboEditor_ProcKnd.Value;
            // 結果種別
            extrInfo.RsltKnd = (int)this.tComboEditor_RsltKnd.Value;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._updHisDspAcs,				// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion Private Methods


        #region Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void PMKAU04101UA_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        Search();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        ClearScreen();
                        break;
                    }
            }
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void Section_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            //if (this._topPanelFlg == true) return;

            //this._secPanelFlg = true;    // ヘッダパネルサイズ制御用フラグ

            //if (this.Section_UGroupBox.Expanded == true)
            //{
            //    this.CheckedListBox_SectionCode.Size = new Size(260, 174);
            //    this.Form1_Top_Panel.Size = new Size(942, 240);

            //    this.Standard_UGroupBox.Expanded = true;
            //    this.Detail_UGroupBox.Expanded = true;
            //}
            //else
            //{
            //    this.Form1_Top_Panel.Size = new Size(942, 50);

            //    this.Standard_UGroupBox.Expanded = false;
            //    this.Detail_UGroupBox.Expanded = false;
            //}

            //this._secPanelFlg = false;   // ヘッダパネルサイズ制御用フラグ

            Size topSize = new Size();
            Size secSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            secSize.Width = this.CheckedListBox_SectionCode.Size.Width;

            if (_topPanelFlg == true) return;

            _secPanelFlg = true;    // ヘッダパネルサイズ制御用フラグ

            if (this.Section_UGroupBox.Expanded == true)
            {
                topSize.Height = 240;
                this.Form1_Top_Panel.Size = topSize;

                this.Standard_UGroupBox.Expanded = true;
                this.Detail_UGroupBox.Expanded = true;
            }
            else
            {
                topSize.Height = 42;
                secSize.Height = 174;
                this.Form1_Top_Panel.Size = topSize;
                this.CheckedListBox_SectionCode.Size = secSize;

                this.Standard_UGroupBox.Expanded = false;
                this.Detail_UGroupBox.Expanded = false;
            }

            _secPanelFlg = false;   // ヘッダパネルサイズ制御用フラグ
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            //Size topSize = new Size();
            //Size secSize = new Size();

            //topSize.Width = this.Form1_Top_Panel.Size.Width;
            //secSize.Width = this.CheckedListBox_SectionCode.Size.Width;

            //if (this._secPanelFlg == true) return;

            //this._topPanelFlg = true;    // ヘッダパネルサイズ制御用フラグ

            //if ((this.Standard_UGroupBox.Expanded == false) && (this.Detail_UGroupBox.Expanded == false))
            //{
            //    topSize.Height = 42;
            //    secSize.Height = 174;
            //    this.Section_UGroupBox.Expanded = false;
            //}
            //else if ((this.Standard_UGroupBox.Expanded == true) && (this.Detail_UGroupBox.Expanded == false))
            //{
            //    topSize.Height = 141;
            //    secSize.Height = 72;
            //    this.Section_UGroupBox.Expanded = true;
            //}
            //else if ((this.Standard_UGroupBox.Expanded == false) && (this.Detail_UGroupBox.Expanded == true))
            //{
            //    topSize.Height = 141;
            //    secSize.Height = 72;
            //    this.Section_UGroupBox.Expanded = true;
            //}
            //else
            //{
            //    topSize.Height = 240;
            //    secSize.Height = 174;
            //    this.Section_UGroupBox.Expanded = true;
            //}

            //this._topPanelFlg = false;   // ヘッダパネルサイズ制御用フラグ

            Size topSize = new Size();
            Size secSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            secSize.Width = this.CheckedListBox_SectionCode.Size.Width;

            if (_secPanelFlg == true) return;

            _topPanelFlg = true;    // ヘッダパネルサイズ制御用フラグ

            if ((this.Standard_UGroupBox.Expanded == false) && (this.Detail_UGroupBox.Expanded == false))
            {
                topSize.Height = 42;
                secSize.Height = 174;

                this.Section_UGroupBox.Expanded = false;
            }
            else if ((this.Standard_UGroupBox.Expanded == true) && (this.Detail_UGroupBox.Expanded == false))
            {
                topSize.Height = 141;
                secSize.Height = 72;
                this.Section_UGroupBox.Expanded = true;
            }
            else if ((this.Standard_UGroupBox.Expanded == false) && (this.Detail_UGroupBox.Expanded == true))
            {
                topSize.Height = 141;
                secSize.Height = 72;
                this.Section_UGroupBox.Expanded = true;
            }
            else
            {
                topSize.Height = 240;
                secSize.Height = 174;
                this.Section_UGroupBox.Expanded = true;
            }

            this.Form1_Top_Panel.Size = topSize;
            this.CheckedListBox_SectionCode.Size = secSize;

            _topPanelFlg = false;   // ヘッダパネルサイズ制御用フラグ
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        break;
                    }
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // グリッド表示を左にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 先頭行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 最終行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ItemCheck イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : チェック状態が変わろうとしている時に発生。イベント後、チェック状態が変更される。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date	   : 2008/09/29</br>
        /// </remarks>
        private void CheckedListBox_SectionCode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                // これから選択されようとしているので値は逆
                if (this.CheckedListBox_SectionCode.GetItemChecked(0) == false) 
                {
                    // 「全社」が選択された場合、「全社」以外の選択を解除
                    for (int index = 1; index < CheckedListBox_SectionCode.Items.Count; index++)
                    {
                        this.CheckedListBox_SectionCode.SetItemChecked(index, false);
                    }
                }
                else
                {
                    if (this.CheckedListBox_SectionCode.CheckedItems.Count == 0)
                    {
                        // 選択項目が全て解除された場合、「全社」を選択状態にする
                        this.CheckedListBox_SectionCode.SetItemChecked(0, true);
                    }
                }
            }
            else
            {
                // これから選択されようとしているので値は逆
                if (this.CheckedListBox_SectionCode.GetItemChecked(e.Index) == false) 
                {
                    // 「全社」以外が選択状態にされた場合は、「全社」の選択状態を解除
                    this.CheckedListBox_SectionCode.SetItemChecked(0, false);
                }
            }
        }

        /// <summary>
        /// Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点チェックリストがアクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void CheckedListBox_SectionCode_Enter(object sender, EventArgs e)
        {
            this.CheckedListBox_SectionCode.BackColor = Color.FromArgb(247, 227, 156);
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点チェックリストが非アクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void CheckedListBox_SectionCode_Leave(object sender, EventArgs e)
        {
            this.CheckedListBox_SectionCode.BackColor = Color.Empty;
            this.CheckedListBox_SectionCode.SelectedIndex = -1;
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 表示区分の値が変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void tComboEditor_DispDiv_ValueChanged(object sender, EventArgs e)
        {
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // ADD 2008/11/11 不具合対応[7084] ---------->>>>>
            // 処理日のクリア
            //this.tDateEdit_CAddUpUpdDateSt.SetDateTime(DateTime.MinValue);
            //this.tDateEdit_CAddUpUpdDateEd.SetDateTime(DateTime.MinValue);
            // ADD 2008/11/11 不具合対応[7084] ----------<<<<<
            switch ((int)this.tComboEditor_DispDiv.Value)
            {
                case 0:
                case 1:
                    if (this.tDateEdit_CAddUpUpdDateSt.DateFormat != emDateFormat.df4Y2M2D)
                    {
                        this.tDateEdit_CAddUpUpdDateSt.SetDateTime(DateTime.MinValue);
                        this.tDateEdit_CAddUpUpdDateEd.SetDateTime(DateTime.MinValue);
                    }
                    break;
                case 2:
                case 3:
                    if (this.tDateEdit_CAddUpUpdDateSt.DateFormat != emDateFormat.df4Y2M)
                    {
                        this.tDateEdit_CAddUpUpdDateSt.SetDateTime(DateTime.MinValue);
                        this.tDateEdit_CAddUpUpdDateEd.SetDateTime(DateTime.MinValue);
                    }
                    break;
            }
            if (this.tComboEditor_DispDiv.Value == null)
            {
                // 年月日
                this.tDateEdit_CAddUpUpdDateSt.DateFormat = emDateFormat.df4Y2M2D;
                this.tDateEdit_CAddUpUpdDateEd.DateFormat = emDateFormat.df4Y2M2D;

                // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                //if (columns.Count != 0)
                //{
                //    // グリッド列表示設定
                //    columns[COLUMN_CUSTOMERCD].Hidden = false;
                //    columns[COLUMN_CUSTOMERNM].Hidden = false;
                //    columns[COLUMN_SUPPLIERCD].Hidden = false;
                //    columns[COLUMN_SUPPLIERNM].Hidden = false;
                //}
                // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
                return;
            }

            switch ((int)this.tComboEditor_DispDiv.Value)
            {
                case 0: // 表示区分が「請求」の時
                    {
                        // 年月日
                        this.tDateEdit_CAddUpUpdDateSt.DateFormat = emDateFormat.df4Y2M2D;
                        this.tDateEdit_CAddUpUpdDateEd.DateFormat = emDateFormat.df4Y2M2D;

                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                        //if (columns.Count != 0)
                        //{
                        //    // グリッド列表示設定
                        //    columns[COLUMN_CUSTOMERCD].Hidden = false;
                        //    columns[COLUMN_CUSTOMERNM].Hidden = false;
                        //    columns[COLUMN_SUPPLIERCD].Hidden = true;
                        //    columns[COLUMN_SUPPLIERNM].Hidden = true;
                        //}
                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
                        break;
                    }
                case 1: // 表示区分が「支払」の時
                    {
                        // 年月日
                        this.tDateEdit_CAddUpUpdDateSt.DateFormat = emDateFormat.df4Y2M2D;
                        this.tDateEdit_CAddUpUpdDateEd.DateFormat = emDateFormat.df4Y2M2D;

                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                        //if (columns.Count != 0)
                        //{
                        //    // グリッド列表示設定
                        //    columns[COLUMN_CUSTOMERCD].Hidden = true;
                        //    columns[COLUMN_CUSTOMERNM].Hidden = true;
                        //    columns[COLUMN_SUPPLIERCD].Hidden = false;
                        //    columns[COLUMN_SUPPLIERNM].Hidden = false;
                        //}
                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
                        break;
                    }
                case 2: // 表示区分が「売上月次」の時
                case 3: // 表示区分が「仕入月次」の時
                    {
                        // 年月
                        this.tDateEdit_CAddUpUpdDateSt.DateFormat = emDateFormat.df4Y2M;
                        this.tDateEdit_CAddUpUpdDateEd.DateFormat = emDateFormat.df4Y2M;

                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------>>>>>
                        //if (columns.Count != 0)
                        //{
                        //    // グリッド列表示設定
                        //    columns[COLUMN_CUSTOMERCD].Hidden = true;
                        //    columns[COLUMN_CUSTOMERNM].Hidden = true;
                        //    columns[COLUMN_SUPPLIERCD].Hidden = true;
                        //    columns[COLUMN_SUPPLIERNM].Hidden = true;
                        //}
                        // --- DEL 2009/02/04 障害ID:10398対応------------------------------------------------------<<<<<
                        break;
                    }
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tDateEdit_CAddUpUpdExecDateSt.Focus();

            this.Initial_Timer.Enabled = false;
        }

        #endregion Control Events
    }
}