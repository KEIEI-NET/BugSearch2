//****************************************************************************//
// System           : .NS Series
// Program name     : 優良設定マスタ                 
// Note             : 優良設定の登録・変更・削除を行う    
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.                       
//============================================================================//
// 履歴                                                               
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/02/15  修正内容 : 新規作成                                   
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/01/13  修正内容 : Mantis：14714　表示無も採番されるように修正                                   
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 更 新 日  2011/11/22  修正内容 : Redmine#8033の対応                               
//----------------------------------------------------------------------------//
// 管理番号  11275163-00 作成担当 : 田建委
// 更 新 日  2016/06/29  修正内容 : Redmine#48793の対応
//                                  商品中分類の下にBLコードが多く過ぎる場合、詳細設定タブにメーカーノードをクリックするとエラーの解除
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 詳細設定画面クラス   
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 柴田 倫幸</br>
    /// <br>        	 ・流用/機能追加の為、修正</br>    
    /// <br>UpdateNote : 2016/06/29 田建委</br>
    /// <br>管理番号   : 11275163-00</br>
    /// <br>           : Redmine#48793 商品中分類の下にBLコードが多く過ぎる場合、詳細設定タブにメーカーノードをクリックするとエラーの解除</br>
    /// </remarks>
    public partial class PMKEN09012UA : Form, IPrimeSettingController,
        IPrimeSettingNoteChanger // ADD 2008/10/30 不具合対応[6961] 仕様変更
	{
		# region Constructor
		/// <summary>
		/// 履歴・得意先・車両情報テキスト出力画面クラス コンストラクタ
		/// </summary>
		/// <remarks>履歴・得意先・車両情報テキスト出力画面クラスのコンストラクタです。</remarks>
		public PMKEN09012UA()
		{
			InitializeComponent();

			// インターフェースプロパティ設定処理
			//this.SetProperties();

            this.NoteChanged += this.CurrentNoteForPrimeSettingChanged; // ADD 2008/10/30 不具合対応[6961] 仕様変更
		}

        private DataView _PriSetView = null;
        private DataView _MgBlMkView = null;

		# endregion

        // 優良設定マスタコントローラ(インターフェースの実装）
        //PrimeSettingController _primeSettingController;  // DEL 2008/07/01
        PrimeSettingAcs _primeSettingController;           // ADD 2008/07/01

        //--------------------------------------------------------------------------
        //	ToolBar
        //--------------------------------------------------------------------------
        # region ▼Const-標準ToolBar
        /// <summary>全て部品と結合</summary>
        private const string ALL_JOIN = "AllJoin";
        /// <summary>全て部品のみ</summary>
        private const string ALL_PARTS = "AllParts";
        /// <summary>全てなし</summary>
        private const string ALL_NONE = "AllNone";
        /// <summary>全て部品と結合</summary>
        private const string JOIN = "Join";
        /// <summary>全て部品のみ</summary>
        private const string PARTS = "Parts";
        /// <summary>全てなし</summary>
        private const string NONE = "None";
        /// <summary>次へ</summary>
        private const string NEXT = "Next";
        /// <summary>前へ</summary>
        private const string PRIOR = "Prior";
        /// <summary>上へ移動</summary>
        private const string TOOL_UP = "Up";
        /// <summary>下へ移動</summary>
        private const string TOOL_DOWN = "Down";
        /// <summary>最上位へ移動</summary>
        private const string TOOL_TOP = "Top";
        /// <summary>最下位へ移動</summary>
        private const string TOOL_BOTTOM = "Bottom";
        # endregion

        /// <summary>
        /// プロパティ(優良設定マスタコントローラインターフェースの実装）
        /// </summary>
        public object objPrimeSettingController
        {   
            get
            {
                return (object)_primeSettingController;
            }
            set
            {
                //if (value is PrimeSettingController)  // DEL 2008/07/01
                if (value is PrimeSettingAcs)           // ADD 2008/07/01
                {
                    //_primeSettingController = (PrimeSettingController)value;  // DEL 2008/07/01
                    _primeSettingController = (PrimeSettingAcs)value;           // ADD 2008/07/01 
                }
                else
                {
                    _primeSettingController = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TabIndex"></param>
        /// <remarks>
        /// 
        /// </remarks>
        public void MainTabIndexChange(object sender, int TabIndex)
        {
            if (TabIndex == 2)
            {
                _PriSetView.Sort =
                    (PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                     PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                     PrimeSettingInfo.COL_MAKERDISPORDER + "," +
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                     PrimeSettingInfo.COL_SELECTCODE + "," +
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                     PrimeSettingInfo.COL_DISPLAYORDER);
                
                //優良設定リストを更新する
                _primeSettingController.updateCheckPrimeSettingList();

                switch (_primeSettingController.NavigeteIndex)
                {
                    case 0:
                        {
                            setMK_BLTreeView();
                            break;
                        }
                    case 1:
                        {
                            setMK_BLTreeView();
                            //setMG_BLTreeView();
                            break;
                        }

                }
                if (SettingNavigatorTree.TopNode != null)
                {
                    SettingNavigatorTree.TopNode.Selected = true;
                }

                // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
                if (SettingNavigatorTree.Nodes.Count > 0)
                {
                    SettingNavigatorTree.Nodes[0].Selected = true;
                }
                // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TabIndex"></param>
        /// <param name="key"></param>
        public void FrameNotifyEvent(object sender, int TabIndex, string key)
        {

        }

        // ADD 2008/10/30 不具合対応[6961] 仕様変更 ---------->>>>>
        #region <IPrimeSettingNoteManagementView メンバ/>

        /// <summary>優良設定用備考が変化したときのイベント</summary>
        public event NoteChangedEventHandler NoteChanged;

        #endregion  // <IPrimeSettingNoteManagementView メンバ/>
        // ADD 2008/10/30 不具合対応[6961] 仕様変更 ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NSKEN90102UA_Load(object sender, EventArgs e)
        {

            if (_PriSetView == null) _PriSetView = new DataView(_primeSettingController.PrimeSettingTable);
            if (_MgBlMkView == null) _MgBlMkView = new DataView(_primeSettingController.Mg_Bl_MkTable);
            _PriSetView.RowFilter = String.Format("{0}=1 and {1}", PrimeSettingAcs.COL_CHECKSTATE, string.IsNullOrEmpty(this._primeSettingController.SecretCode) ? "1=1" : this._primeSettingController.SecretCode);//ADD BY 凌小青  on 2011/11/22 for Redmine#8033

            Mk_BlPrimeSettingGrid.DataSource = _PriSetView; // TODO:詳細設定タブの表示テーブル
            //PrimeSettingGrid_InitializeLayout();
            // １段目に配置
            tToolbarsManager1.Toolbars["TreeToolBar"].DockedRow = 0;
            tToolbarsManager1.Toolbars["TreeToolBar"].DockedColumn = 0;
            tToolbarsManager1.Toolbars["GridToolBar"].DockedRow = 0;
            tToolbarsManager1.Toolbars["GridToolBar"].DockedColumn = 1;
        }

        /// <summary>
        /// ツリービュー表示
        /// </summary>
        private void setMK_BLTreeView()
        {
            SettingNavigatorTree.BeginUpdate();
            SettingNavigatorTree.Nodes.Clear();
            try
            {
                // 左のツリービューを表示
                // 画面構築処理
                Hashtable Mkht = new Hashtable();
                Hashtable MkBlht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;

                _MgBlMkView.RowFilter = "";

                // --- ADD 2008/07/01 -------------------------------->>>>>
                _MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
                _PriSetView.RowFilter = "";
                //_PriSetView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);//DEL BY 凌小青 on 2011/11/22 for Redmine#8033
                _PriSetView.RowFilter = String.Format("{0}=1 and {1}", PrimeSettingAcs.COL_CHECKSTATE, string.IsNullOrEmpty(this._primeSettingController.SecretCode) ? "1=1" : this._primeSettingController.SecretCode);//ADD BY 凌小青 on 2011/11/22 for Redmine#8033
                // --- ADD 2008/07/01 --------------------------------<<<<< 
                _MgBlMkView.RowFilter = this._primeSettingController.SecretCode;//ADD BY 凌小青 on 2011/11/22 for Redmine#8033
                _MgBlMkView.RowFilter = string.Format("({0} and {1}=1) or ({2}=1 and {3})", "SecretCode=0", PrimeSettingAcs.COL_CHECKSTATE, PrimeSettingAcs.COL_CHECKSTATE, "SecretCode=1"); // ADD 2011/12/14

                _MgBlMkView.Sort = (PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE);

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 不具合対応[6969] 仕様変更

                    //ViewのチェックステータスがCHECKEDのデータのみ表示
                    //if ((CheckState)dr[PrimeSettingController.COL_CHECKSTATE] == CheckState.Checked)  // DEL 2008/07/01
                    if ((CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE] == CheckState.Checked)           // ADD 2008/07/01
                    {

                        if (Mkht[((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d")] == null)
                        {
                            Mkht.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), dr);
                            // DEL 2008/10/30 不具合対応[6961]↓ 仕様変更
                            //node = this.SettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]);
                            // ADD 2008/10/30 不具合対応[6961] 仕様変更 ---------->>>>>
                            string makerNodeText = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                            node = this.SettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), makerNodeText);
                            // ADD 2008/10/30 不具合対応[6961] 仕様変更 ----------<<<<<
                        }
                        if ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE] == 0) continue;

                        string skey = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                        if (MkBlht[skey] == null)
                        {
                            MkBlht.Add(skey, dr);
                            if (node != null)
                            {

                                if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                                {

                                    string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                    childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                }
                                else
                                {
                                    childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));

                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                SettingNavigatorTree.EndUpdate();
            }
        }

        /// <summary>
        /// ノードを選択するイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote : 2016/06/29 田建委</br>
        /// <br>管理番号   : 11275163-00</br>
        /// <br>           : Redmine#48793 商品中分類の下にBLコードが多く過ぎる場合、詳細設定タブにメーカーノードをクリックするとエラーの解除</br>
        /// </remarks>
        private void SettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                           PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                           PrimeSettingInfo.COL_MAKERDISPORDER + "," +
                                           PrimeSettingInfo.COL_SELECTCODE + "," +
                                           PrimeSettingInfo.COL_DISPLAYORDER;

            foreach( Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)
            {
                if ( node.Level == 0 )
                {
                    //----- UPD 2016/06/29 田建委 Redmine#48793 RowFilter文字列にORをINに変更 ----->>>>>
                    //string s = String.Format("{0}={1} and", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key);
                    //string or = "(";
                    //foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in node.Nodes)
                    //{
                    //    s += or + String.Format(" ({0}={1})", PrimeSettingInfo.COL_TBSPARTSCODE, utn.Key.Substring(4, 8));
                    //    or = "or";
                    //}
                    //s += ")";
                    string s = String.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key);
                    List<string> blCodeList = new List<string>();
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in node.Nodes)
                    {
                        blCodeList.Add(utn.Key.Substring(4, 8));
                    }
                    if (blCodeList.Count > 0)
                    {
                        s += String.Format(" and {0} in ({1})", PrimeSettingInfo.COL_TBSPARTSCODE, String.Join(",", blCodeList.ToArray()));
                        blCodeList.Clear();
                    }
                    //----- UPD 2016/06/29 田建委 Redmine#48793 RowFilter文字列にORをINに変更 -----<<<<<
                    _PriSetView.RowFilter =
                        //String.Format(s, PrimeSettingController.COL_CHECKSTATE, CheckState.Checked.ToString());  // DEL 2008/07/01
                        String.Format(s, PrimeSettingAcs.COL_CHECKSTATE, CheckState.Checked.ToString());           // ADD 2008/07/01

                    // --- CHG 2009/03/11 障害ID:12281対応------------------------------------------------------>>>>>
                    //_PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_SELECTCODE;
                    _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                          PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                          PrimeSettingInfo.COL_SELECTCODE + "," +
                                          PrimeSettingInfo.COL_DISPLAYORDER;
                    // --- CHG 2009/03/11 障害ID:12281対応------------------------------------------------------<<<<<
                    
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                    // 備考を更新
                    this.noteLabel.Text = string.Empty;
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                }
                // --- ADD 2008/07/01 -------------------------------->>>>>
                else if (node.Level == 1)
                {
                    StringBuilder selectedFilter = new StringBuilder();
                    selectedFilter.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(node.Parent.Key);
                    selectedFilter.Append(ADOUtil.AND);
                    selectedFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(node.Key.Substring(4, 8));
                    selectedFilter.Append(ADOUtil.AND);
                    selectedFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                    _PriSetView.RowFilter = selectedFilter.ToString();

                    // --- ADD 2009/03/11 障害ID:12281対応------------------------------------------------------>>>>>
                    _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                          PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                          PrimeSettingInfo.COL_SELECTCODE + "," +
                                          PrimeSettingInfo.COL_DISPLAYORDER;
                    // --- ADD 2009/03/11 障害ID:12281対応------------------------------------------------------<<<<<

                    //string or = "(";
                    //foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in node.Parent.Nodes)
                    //{
                    //    s += or + String.Format(" ({0}={1})", PrimeSettingInfo.COL_TBSPARTSCODE, utn.Key.Substring(4, 8));
                    //    or = "or";
                    //}
                    //s += ")";
                    //_PriSetView.RowFilter =
                    //    String.Format(s, PrimeSettingAcs.COL_CHECKSTATE, CheckState.Checked.ToString());

                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                    // 子ノードを選択した場合も備考を表示
                    int makerCode = int.Parse(node.Parent.Key);
                    int blGoodsCode = int.Parse(node.Key.Substring(4, 8));
                    int goodsMGroup = 0;
                    foreach (UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
                    {
                        if ((makerCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                            (blGoodsCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                        {
                            goodsMGroup = (Int32)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                            break;
                        }
                    }

                    StringBuilder noteText = new StringBuilder();
                    string key = PrimeSettingAcs.GetKeyOfOfferPrimeSettingNote(goodsMGroup, blGoodsCode, makerCode);
                    if (_primeSettingController.OfferPrimeSettingNote.Contains(key))
                    {
                        PrmSetNoteWork primeNote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[key];
                        noteText.Append(primeNote.PrmSetNote.Replace("<br>", Environment.NewLine)).Append(Environment.NewLine);
                    }

                    Debug.WriteLine("備考：" + noteText.ToString());

                    SetCurrentNoteForPrimeSetting(goodsMGroup, blGoodsCode, makerCode, noteText.ToString());
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }

            // --- DEL 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
            //// 備考を更新
            //this.noteLabel.Text = string.Empty; // ADD 2008/11/21 不具合対応[8178] 仕様変更 選択グリッド列の備考表示
            // --- DEL 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

            // 2010/01/13 Add >>>
            SetDisplayOrder();
            // 2010/01/13 Add <<<

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = Mk_BlPrimeSettingGrid;

            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns ;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // 列の表示／非表示（デフォルト）
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_DISPLAYORDER:
                    case PrimeSettingInfo.COL_PRIMEDISPLAYCODE:
                    case PrimeSettingInfo.COL_TBSPARTSCODE:
                    case PrimeSettingInfo.COL_TBSPARTSFULLNAME:
                    case PrimeSettingInfo.COL_SELECTNAME:
                    case PrimeSettingInfo.COL_PRIMEKINDNAME:

                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }

            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].Width = 40;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Width = 90;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Width = 60;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Width = 200;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Width = 200;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Width = 200;

            // 表示順
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.VisiblePosition = 0;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.VisiblePosition = 1;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.VisiblePosition = 2;
            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].Header.VisiblePosition = 3;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.VisiblePosition = 4;	
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.VisiblePosition = 5;

            // ADD 2008/10/28 不具合対応[6964] タイトル表示はセンタリング ---------->>>>>
            // タイトル表示位置
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2008/10/28 不具合対応[6964] タイトル表示はセンタリング ----------<<<<<

            // 書式
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Format = "0000;";	

            // 表示位置
            band.Columns[PrimeSettingInfo.COL_DISPLAYORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //  結合設定
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellAppearance.BackColor = Color.Lavender;
            // --- ADD 2008/07/01 -------------------------------->>>>>
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluator = new MergedCell();
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            //  結合設定
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluator = new MergedCell();

            //  結合設定
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluator = new MergedCell();

            // --- ADD 2008/07/01 -------------------------------->>>>>
            //  結合設定
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluator = new MergedCell();
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            // 値リストを初期化し、グリッドへ追加します。
            grid.DisplayLayout.ValueLists.Clear();
            Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            vl1.ValueListItems.Add(0, "表示無");    // MEMO:優良表示区分：PrimeDisplayCodeRF
            vl1.ValueListItems.Add(1, "部品&結合"); // MEMO:優良表示区分：PrimeDisplayCodeRF
            vl1.ValueListItems.Add(2, "部品");      // MEMO:優良表示区分：PrimeDisplayCodeRF
            vl1.ValueListItems[1].Appearance.BackColor= Color.SkyBlue;
            vl1.ValueListItems[1].Appearance.BackColor2 = Color.White;
            vl1.ValueListItems[1].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            vl1.ValueListItems[2].Appearance.BackColor = Color.MediumAquamarine;
            vl1.ValueListItems[2].Appearance.BackColor2 = Color.White;
            vl1.ValueListItems[2].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].ValueList = vl1;
            band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            // キー動作マッピングを追加
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	//Enterキー
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0)
                );
        }

        // TODO:ツールバーのアクション
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 表示無しボタン
                case NONE:
                    {
                        setPrimeDisplayCode(0, false);  // TODO:[表示無し]ツールボタンの動作開始
                        break;
                    }
                // 部品と結合ボタン
                case JOIN:
                    {
                        setPrimeDisplayCode(1, false);
                        break;
                    }
                // 部品のみボタン
                case PARTS:
                    {
                        setPrimeDisplayCode(2, false);
                        break;
                    }

                // 全て表示無し
                case ALL_NONE:
                    {
                        setPrimeDisplayCode(0, true);
                        break;
                    }
                // 全て部品と結合ボタン
                case ALL_JOIN:
                    {
                        setPrimeDisplayCode(1, true);
                        break;
                    }
                // 全て部品のみボタン
                case ALL_PARTS:
                    {
                        setPrimeDisplayCode(2, true);
                        break;
                    }
                // 次へ
                case NEXT:
                    {
                        if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;
                        if (SettingNavigatorTree.SelectedNodes[0] != null)
                        {
                            Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                            if (node.NextVisibleNode != null)
                            {
                                if (node.NextVisibleNode.Level == 1)
                                {
                                    while (true)
                                    {
                                        node = node.NextVisibleNode;
                                        if (node == null) return;
                                        if (node.Level == 0) break;
                                    }
                                    node.Selected = true;
                                }
                                else
                                {
                                    node.NextVisibleNode.Selected = true;
                                }
                            }
                        }
                        break;
                    }
                // 前へ
                case PRIOR:
                    {
                        if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;
                        if (SettingNavigatorTree.SelectedNodes[0] != null)
                        {
                            Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                            if (node.PrevVisibleNode != null)
                            {
                                if (node.PrevVisibleNode.Level == 1)
                                {
                                    node.PrevVisibleNode.Parent.Selected = true;
                                }
                                else
                                {
                                    node.PrevVisibleNode.Selected = true;
                                }
                            }
                        }

                        break;
                    }

                // 上へ
                case TOOL_UP:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == 0) return;

                        //先にアイテムを取得しておく
                        Infragistics.Win.UltraWinGrid.UltraGridRow priorrow = Mk_BlPrimeSettingGrid.Rows[idx - 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];
                        //Infragistics.Win.UltraWinGrid.UltraGridRow firstrow = Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.FirstRow;

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //選択アイテムと次の行のBLコードが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        // 選択アイテムと次の行のセレクトが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        //選択アイテムが先頭なら終了
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 1) return;
                        if ((Int32)selectrow.Index == 0) return;
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //バンドを取得
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // セル結合しないに設定(この処理がないとセルが結合されない場合がある)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //int order = (Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        int selectIndex = (Int32)selectrow.Index;
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        order = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        
                        //上のアイテムの順位を下げる
                        priorrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order;
                        priorrow.Update();

                        //選択されているRowの順位を上げる
                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order - 1;
                        selectrow.Update();

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;

                        // セル結合するに設定
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        // Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineUp);

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 不具合対応[6961]

                        break;
                    }

                // 下へ
                case TOOL_DOWN:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == Mk_BlPrimeSettingGrid.Rows.Count - 1) return;

                        //先にアイテムを取得しておく
                        Infragistics.Win.UltraWinGrid.UltraGridRow nextrow = Mk_BlPrimeSettingGrid.Rows[idx + 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        //選択アイテムと次の行のBLコードが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        // 選択アイテムと次の行のセレクトが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //バンドを取得
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // セル結合しないに設定(この処理がないとセルが結合されない場合がある)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //int order = (Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        int selectIndex = (Int32)selectrow.Index;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        order = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        //下のアイテムの順位を上げる
                        nextrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order;
                        nextrow.Update();

                        //選択されているRowの順位を下げる
                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order + 1;
                        selectrow.Update();

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;

                        // セル結合するに設定
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 不具合対応[6961]

                        break;
                    }

                // トップへ
                case TOOL_TOP:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == 0) return;

                        //先にアイテムを取得しておく
                        Infragistics.Win.UltraWinGrid.UltraGridRow priorrow = Mk_BlPrimeSettingGrid.Rows[idx - 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        //選択アイテムと前のBLコードが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;
                        //Infragistics.Win.UltraWinGrid.UltraGridRow firstrow = Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.FirstRow;
                       // Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //選択アイテムと前のセレクトコードが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)priorrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 1) return;
                        if ((Int32)selectrow.Index == 0) return;
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //バンドを取得
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // セル結合しないに設定(この処理がないとセルが結合されない場合がある)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //int topNo = 1;  // ADD 2008/07/01

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        //for (int i = idx; 1 <= i; i--)
                        //{
                        //    priorrow = Mk_BlPrimeSettingGrid.Rows[i - 1];

                        //    //上のアイテムの順位を下げる
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[i];
                        //    row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value =
                        //             (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value + 1;
                        //    row.Update();

                        //    topNo = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;  // ADD 2008/07/01

                        //    //選択アイテムと次の行のBLコードが異なる場合終了
                        //    if ((Int32)priorrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0) break;

                        //    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //    //選択アイテムと次の行のセレクトコードが異なる場合終了
                        //    if ((Int32)priorrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value == 0) break;
                        //    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        //}

                        ////selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 1;        // DEL 2008/07/01
                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = topNo - 1;  // ADD 2008/07/01

                        //selectrow.Update();

                        //// Mk_BlPrimeSettingGrid.ActiveRowScrollRegion.ScrollPosition = firstrow;

                        int selectIndex = selectrow.Index;

                        int topIndex = 0;

                        int blGoodsCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        int selectCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;

                        for (int index = 0; index < Mk_BlPrimeSettingGrid.Rows.Count; index++)
                        {
                            if (Mk_BlPrimeSettingGrid.Rows[index].Hidden == true)
                            {
                                continue;
                            }

                            if ((blGoodsCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                (selectCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SELECTCODE].Value))
                            {
                                topIndex = index;
                                break;
                            }
                        }

                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        int topOrder = (Int32)Mk_BlPrimeSettingGrid.Rows[topIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                        for (int index = topIndex; index < selectIndex; index++)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            order = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order + 1;
                        }

                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = topOrder;

                        Mk_BlPrimeSettingGrid.BeginUpdate();

                        for (int index = topIndex; index < selectIndex; index++)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            row.Update();

                            row.Selected = true;
                            Mk_BlPrimeSettingGrid.ActiveRow = row;
                        }

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;
                        Mk_BlPrimeSettingGrid.EndUpdate();
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        // セル結合するに設定
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 不具合対応[6961]

                        break;

                    }
                //ボトムへ
                case TOOL_BOTTOM:
                    {
                        //if (Mk_BlPrimeSettingGrid.Selected.Rows.Count != 1) return;  // DEL 2008/07/01
                        if (Mk_BlPrimeSettingGrid.ActiveRow == null) return;

                        int idx = Mk_BlPrimeSettingGrid.ActiveRow.Index;
                        if (idx == Mk_BlPrimeSettingGrid.Rows.Count - 1) return;

                        //先にアイテムを取得しておく
                        Infragistics.Win.UltraWinGrid.UltraGridRow nextrow = Mk_BlPrimeSettingGrid.Rows[idx + 1];
                        Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = Mk_BlPrimeSettingGrid.Rows[idx];

                        //選択アイテムと次の行のBLコードが異なる場合終了(最下位の場合）
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) return;

                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //選択アイテムと前のセレクトコードが異なる場合終了
                        if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                             (Int32)nextrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        //バンドを取得
                        Infragistics.Win.UltraWinGrid.UltraGridBand band = Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0];

                        // セル結合しないに設定(この処理がないとセルが結合されない場合がある)
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //int bottom = 1;

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        //selectrow.Update();

                        ////for (int i = idx+1; i < Mk_BlPrimeSettingGrid.Rows.Count-1; i++)  // DEL 2008/07/01
                        //for (int i = idx + 1; i < Mk_BlPrimeSettingGrid.Rows.Count; i++)    // ADD 2008/07/01
                        //{
                        //    //nextrow = Mk_BlPrimeSettingGrid.Rows[i+1];  // DEL 2008/07/01
                        //    nextrow = Mk_BlPrimeSettingGrid.Rows[i];      // ADD 2008/07/01

                        //    //下のアイテムの順位を上げる
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[i];

                        //    // --- ADD 2008/07/01 -------------------------------->>>>>
                        //    //選択アイテムと次の行のBLコードが異なる場合終了
                        //    if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                        //         (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) break;
                        //    // --- ADD 2008/07/01 --------------------------------<<<<< 

                        //    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //    //選択アイテムと前のセレクトコードが異なる場合終了
                        //    if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                        //         (Int32)nextrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value) return;
                        //    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                        //    //row.Cells[PrimeSettingController.COL_DISPLAYORDER].Value = i;
                        //    row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value =
                        //             (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value - 1;
                        //    row.Update();
                        //    bottom = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                        //    // --- DEL 2008/07/01 -------------------------------->>>>>
                        //    //選択アイテムと次の行のBLコードが異なる場合終了
                        //    //if ((Int32)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                        //    //     (Int32)nextrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) break;
                        //    // --- DEL 2008/07/01 --------------------------------<<<<< 
                        //}

                        //selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = bottom + 1;
                        //selectrow.Update();

                        int selectIndex = selectrow.Index;

                        int bottomIndex = 0;

                        int blGoodsCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        int selectCode = (Int32)Mk_BlPrimeSettingGrid.Rows[selectIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;

                        for (int index = Mk_BlPrimeSettingGrid.Rows.Count - 1; index >= 0; index--)
                        {
                            if (Mk_BlPrimeSettingGrid.Rows[index].Hidden == true)
                            {
                                continue;
                            }

                            if ((blGoodsCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                (selectCode == (Int32)Mk_BlPrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SELECTCODE].Value))
                            {
                                bottomIndex = index;
                                break;
                            }
                        }

                        int order = 0;
                        for (int rowIndex = 0; rowIndex < Mk_BlPrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                            {
                                continue;
                            }
                            if ((Int32)selectrow.Cells[PrimeSettingInfo.COL_SELECTCODE].Value !=
                                (Int32)Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                            {
                                continue;
                            }

                            Mk_BlPrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++order;
                        }
                        Mk_BlPrimeSettingGrid.BeginUpdate();
                        Mk_BlPrimeSettingGrid.Update();
                        Mk_BlPrimeSettingGrid.EndUpdate();

                        int bottomOrder = (Int32)Mk_BlPrimeSettingGrid.Rows[bottomIndex].Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                        for (int index = bottomIndex; index >= selectIndex; index--)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            order = (Int32)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;

                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = order - 1;
                        }

                        selectrow.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = bottomOrder;

                        Mk_BlPrimeSettingGrid.BeginUpdate();

                        for (int index = bottomIndex; index >= selectIndex; index--)
                        {
                            UltraGridRow row = Mk_BlPrimeSettingGrid.Rows[index];
                            row.Update();

                            row.Selected = true;
                            Mk_BlPrimeSettingGrid.ActiveRow = row;
                        }

                        selectrow.Selected = true;
                        Mk_BlPrimeSettingGrid.ActiveRow = selectrow;
                        Mk_BlPrimeSettingGrid.EndUpdate();
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        
                        // セル結合するに設定
                        band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;  // ADD 2008/07/01

                        EnabledToolButtonForSelectingGrodRow(); // ADD 2008/10/30 不具合対応[6961]

                        break;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 表示無し：value := 0, all := false
        /// </remarks>
        /// <param name="value"></param>
        /// <param name="all"></param>
        private void setPrimeDisplayCode(int value, bool all)
        {
            int blGoodsCode = -1;
            string selectName = null;
            int prevVal = -1;

            int selectBLGoodsCode = -1;
            int displayOrder = 1;

            int selectCode = -1;    // 2010/01/13 Add

            // セル結合しないに設定(この処理がないとセルが結合されない場合がある)
            Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0].Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;

            // UNDONE:複数選択
            //Infragistics.Win.UltraWinGrid.UltraGridRow row = this.Mk_BlPrimeSettingGrid.ActiveRow;

            int count = 0;// 2010/01/13 Add
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in Mk_BlPrimeSettingGrid.Rows)
            {
                // [全て○○]ツールボタンの処理
                if (all == true)
                {
                    // 2010/01/13 Add >>>
                    if (selectBLGoodsCode != (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value || selectCode != (int)row.Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                    {
                        selectBLGoodsCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        selectCode = (int)row.Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                        count = 0;
                    }
                    // 2010/01/13 Add <<<
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// まず自身をクリア
                    //row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = 0;
                    //row.Update();

                    //// ADD 2008/11/18 不具合対応[7010] 仕様変更「セレクト／種別」別の複数選択対応 ---------->>>>>
                    //// 「セレクト」が設定されている行の場合
                    //// --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                    ////if (HasSelectValue(row))
                    //string selectName;
                    //if (HasSelectValue(row, out selectName))
                    //// --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                    //// ADD 2008/11/18 不具合対応[7010] 仕様変更「セレクト／種別」別の複数選択対応 ----------<<<<<
                    //{
                    //    // 同一BLコードで部品,部品&結合が設定されている明細があれば迂回
                    //    if (value != 0 && CheckSettedDispCodeRow((int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                    //    {
                    //        continue;
                    //    }
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    //row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value;
                    //row.Update();

                    // 表示無しに変更
                    if (value == 0)
                    {
                        row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value;
                        row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                    }
                    // 部品＆結合、部品に変更
                    else
                    {
                        // BLコードが前回値と違う場合は、変更対象の優良表示区分に変更
                        if (blGoodsCode != (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                        {
                            row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value;
                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 1;
                            blGoodsCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                            selectName = (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                            prevVal = value;
                            displayOrder = 2;

                            int makerCode = (int)row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                            int blCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                            int goodsMGroup = (int)row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;

                            ArrayList makerOrderList = new ArrayList();
                            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                            {
                                if ((makerCode == (int)row2.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                                    (blCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                    (goodsMGroup == (int)row2.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value))
                                {
                                    makerOrderList.Add((int)row2.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value);
                                }
                            }

                            foreach (int order in makerOrderList)
                            {
                                if (order != 0)
                                {
                                    foreach (DataRowView row2 in _MgBlMkView)
                                    {
                                        if ((makerCode == (int)row2[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
                                            (blCode == (int)row2[PrimeSettingInfo.COL_TBSPARTSCODE]) &&
                                            (goodsMGroup == (int)row2[PrimeSettingInfo.COL_MIDDLEGENRECODE]))
                                        {
                                            row2[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                                        }
                                    }

                                    break;
                                }
                            }
                            continue;
                        }

                        if (selectName == (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value)
                        {
                            row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = prevVal;
                            if (prevVal != 0)
                            {
                                row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = displayOrder;
                                displayOrder++;
                            }
                            else
                            {
                                row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                            }
                            selectName = (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                            continue;
                        }
                        else
                        {
                            row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = 0;
                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                            selectName = (string)row.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                            prevVal = 0;
                        }
                    }
                }
                // 個別の設定ツールボタンの処理
                else
                {
                    if (row.Selected == true)
                    {
                        //// --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //string selectName;
                        //// --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        selectBLGoodsCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                        selectCode = (int)row.Cells[PrimeSettingInfo.COL_SELECTCODE].Value;// 2010/01/13 Add
                        // 複数選択
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                        //if (HasSelectValue(row))  // MOD 2008/11/18 不具合対応[7010] 仕様変更「セレクト／種別」別の複数選択対応 value != 0 → IsSelectType(row)
                        if (HasSelectValue(row, out selectName))
                        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        {
                            // 同一BLコードの明細をクリアする
                            // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                            //ClearSettedDispCodeRow((int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value);
                            ClearSettedDispCodeRow((int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value, selectName);
                            // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        row.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value = value; 
                        if (value == 0)
                        {
                            row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                        }
                        else
                        {
                            if ((int)row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0)
                            {
                                row.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = displayOrder;

                                int makerCode = (int)row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                                int blCode = (int)row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                                int goodsMGroup = (int)row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;

                                ArrayList makerOrderList = new ArrayList();
                                foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                                {
                                    if ((makerCode == (int)row2.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                                        (blCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value) &&
                                        (goodsMGroup == (int)row2.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value))
                                    {
                                        makerOrderList.Add((int)row2.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value);
                                    }
                                }

                                foreach (int order in makerOrderList)
                                {
                                    if (order != 0)
                                    {
                                        foreach (DataRowView row2 in _MgBlMkView)
                                        {
                                            if ((makerCode == (int)row2[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
                                                (blCode == (int)row2[PrimeSettingInfo.COL_TBSPARTSCODE]) &&
                                                (goodsMGroup == (int)row2[PrimeSettingInfo.COL_MIDDLEGENRECODE]))
                                            {
                                                row2[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        row.Update();
                    }
                }
            }

            if (all == false)
            {
                // 2010/01/13 >>>
                //int displayOrder2 = -1;
                int displayOrder2 = 0;
                _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                               PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                               PrimeSettingInfo.COL_SELECTCODE;

                // 2010/01/13 <<<
                foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                {
                    if (selectBLGoodsCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                    {
                        // 2010/01/13 Del >>>
                        //if (displayOrder2 == -1)
                        //{
                        //    displayOrder2 = (int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                        //}
                        //else
                        //{
                        // 2010/01/13 Del <<<
                        if ((int)row2.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value != 0)
                        {
                            row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++displayOrder2;
                            row2.Update();
                        }
                        // 2010/01/13 Add >>>
                        else
                        {
                            // 表示無でSELECTCODEも一緒の場合は１度表示順を0にする
                            if ((int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value == selectCode)
                            {
                                row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = 0;
                                row2.Update();
                            }
                        }
                        // 2010/01/13 Add <<<
                        //}// 2010/01/13 Del
                    }
                }
                // 2010/01/13 Add 表示順0のものに対して表示順を採番する >>>
                foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
                {
                    if (selectBLGoodsCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value && (int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value == selectCode)
                    {
                        if ((int)row2.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value == 0 && (int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0)
                        {
                            row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++displayOrder2;
                            row2.Update();
                        }
                    }
                }
                // DISPLAYORDERでソートし直す
                _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                          PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                          PrimeSettingInfo.COL_SELECTCODE + "," +
                                          PrimeSettingInfo.COL_DISPLAYORDER;
                // 2010/01/13 Add <<<
            }
            // 2010/01/13 Add >>>
            else
            {
                SetDisplayOrder();
            }
            // 2010/01/13 Add <<<

            Mk_BlPrimeSettingGrid.BeginUpdate();
            Mk_BlPrimeSettingGrid.Update();

            // セル結合するに設定
            Mk_BlPrimeSettingGrid.DisplayLayout.Bands[0].Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;

            UltraGridRow selectedRow = null;
            if ((Mk_BlPrimeSettingGrid.Selected.Rows != null) && (Mk_BlPrimeSettingGrid.Selected.Rows.Count > 0))
            {
                selectedRow = Mk_BlPrimeSettingGrid.Selected.Rows[0];
            }
            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
            {
                row2.Selected = true;
                row2.Activate();
                row2.Selected = false;
            }
            if (selectedRow != null)
            {
                Mk_BlPrimeSettingGrid.Rows[selectedRow.Index].Selected = true;
                Mk_BlPrimeSettingGrid.Rows[selectedRow.Index].Activated = true;
            }
            else
            {
                Mk_BlPrimeSettingGrid.Rows[0].Activated = true;
            }
            Mk_BlPrimeSettingGrid.EndUpdate();
        }

        // ADD 2008/11/18 不具合対応[7010] 仕様変更「セレクト／種別」別の複数選択対応 ---------->>>>>
        /// <summary>
        /// セレクトが設定されている行か判定します。
        /// </summary>
        /// <param name="gridRow">グリッド行</param>
        /// <returns>
        /// <c>true</c> :セレクトが設定されている。<br/>
        /// <c>false</c>:セレクトが設定されていない。
        /// </returns>
        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
        //private bool HasSelectValue(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        private bool HasSelectValue(UltraGridRow gridRow, out string selectName)
        // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
        {
            // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
            selectName = "";
            // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

            if (gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME] == null)
            {
                return false;
            }

            // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
            //string selectName = gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME].Value.ToString();
            selectName = gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME].Value.ToString();
            // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            if (string.IsNullOrEmpty(selectName))
            {
                return false;
            }

            return true;
        }
        // ADD 2008/11/18 不具合対応[7010] 仕様変更「セレクト／種別」別の複数選択対応 ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
        //private void ClearSettedDispCodeRow( int blGoodsCode )
        private void ClearSettedDispCodeRow( int blGoodsCode , string selectName)
        // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
        {
            // ビューの生成
            DataView view = CreateViewForCheckSettedDispCodeRow( blGoodsCode );

            // 該当分を全てクリア
            foreach ( DataRowView rowView in view )
            {
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //rowView[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0; // 0:表示なし
                if ((rowView[PrimeSettingInfo.COL_SELECTNAME] != null) &&
                    (rowView[PrimeSettingInfo.COL_SELECTNAME].ToString() != "") &&
                    (rowView[PrimeSettingInfo.COL_SELECTNAME].ToString() != selectName))
                {
                    rowView[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0; // 0:表示なし
                    //rowView[PrimeSettingInfo.COL_DISPLAYORDER] = 0; // 2010/01/13 Del 表示順は残す
                }
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        private bool CheckSettedDispCodeRow( int blGoodsCode )
        {
            // ビューの生成
            DataView view = CreateViewForCheckSettedDispCodeRow( blGoodsCode );

            // 該当ありならtrue
            return (view.Count > 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        private DataView CreateViewForCheckSettedDispCodeRow( int blGoodsCode )
        {
            // ビューの生成
            DataView view = new DataView( _primeSettingController.PrimeSettingTable );

            // フィルタ文字列生成
            // 同一ＢＬコードand（部品結合or部品）
            string wkFilter = string.Format("{0}='{1}' AND {2}>'0'",
                                            PrimeSettingInfo.COL_TBSPARTSCODE, blGoodsCode,
                                            PrimeSettingInfo.COL_PRIMEDISPLAYCODE);
            if (_PriSetView.RowFilter != string.Empty)
            {
                view.RowFilter = _PriSetView.RowFilter + " AND " + wkFilter;
            }
            else
            {
                view.RowFilter = wkFilter;
            }
            return view;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

        private void PrimeSettingGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (Mk_BlPrimeSettingGrid.Selected.Rows.Count == 0) return;
            if (Mk_BlPrimeSettingGrid.Selected.Rows[0] != Mk_BlPrimeSettingGrid.ActiveRow)
            {
                Mk_BlPrimeSettingGrid.ActiveRow.Selected = true;
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SettingNavigatorTree.ActiveNode != null)
            {
                if (((ToolStripMenuItem)sender).Name == "toolStripMenuItem1")
                {
                    // 全て表示無し
                    setPrimeDisplayCode(0, true);
                }
                if (((ToolStripMenuItem)sender).Name == "toolStripMenuItem2")
                {
                    // 全て部品と結合ボタン
                    setPrimeDisplayCode(1, true);
                }
                if (((ToolStripMenuItem)sender).Name == "toolStripMenuItem3")
                {
                    // 全て部品のみボタン
                    setPrimeDisplayCode(2, true);
                }
            }
        }

        // ADD 2008/10/29 不具合対応[6961] 仕様変更 ---------->>>>>
        /// <summary>現在の優良設定用備考</summary>
        private string _currentNoteForPrimeSetting;
        /// <summary>
        /// 現在の優良設定用備考を取得します。
        /// </summary>
        /// <value>現在の優良設定用備考</value>
        private string CurrentNoteForPrimeSetting
        {
            get { return _currentNoteForPrimeSetting; }
        }
        /// <summary>
        /// 現在の優良設定用備考を設定します。
        /// </summary>
        /// <param name="middleCode">中分類コード</param>
        /// <param name="blCode">BLコード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="value">現在の優良設定用備考</param>
        private void SetCurrentNoteForPrimeSetting(
            int middleCode,
            int blCode,
            int makerCode,
            string value
        )
        {
            _currentNoteForPrimeSetting = value;

            // 優良設定用備考の値に変化があったことを通知
            NoteChanged(
                this,
                new NoteChangedEventArgs(middleCode, blCode, makerCode, value)
            );
        }

        /// <summary>
        /// 現在の優良設定用備考の値が変化したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void CurrentNoteForPrimeSettingChanged(
            object sender,
            NoteChangedEventArgs e
        )
        {
            StringBuilder noteText = new StringBuilder(e.ToString());

            int currentMiddleCode   = e.MiddleCode;
            int currentBLCode       = e.BLCode;
            int currentMakerCode    = e.MakerCode;

            StringBuilder selectText= new StringBuilder();
            StringBuilder typeText  = new StringBuilder();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
            {
                int middleCode  = (int)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                int blCode      = (int)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                int makerCode   = (int)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;

                if (middleCode.Equals(currentMiddleCode) && blCode.Equals(currentBLCode) && makerCode.Equals(currentMakerCode))
                {
                    string selectTextItem = (string)gridRow.Cells[PrimeSettingInfo.COL_SELECTNAME].Value;
                    if (!string.IsNullOrEmpty(selectTextItem))
                    {
                        selectText.Append(" "); // TODO:不必要なら削除
                        selectText.Append(selectTextItem).Append(Environment.NewLine);
                    }

                    string typeTextItem = (string)gridRow.Cells[PrimeSettingInfo.COL_PRIMEKINDNAME].Value;
                    if (!string.IsNullOrEmpty(typeTextItem))
                    {
                        typeText.Append(" ");   // TODO:不必要なら削除
                        typeText.Append(typeTextItem).Append(Environment.NewLine);
                    }
                }
            }

            if (selectText.Length > 0)
            {
                noteText.Append(Environment.NewLine).Append("[セレクト]").Append(Environment.NewLine);  // LITERAL:
                noteText.Append(selectText.ToString());
            }

            if (typeText.Length > 0)
            {
                noteText.Append(Environment.NewLine).Append("[種別]").Append(Environment.NewLine);  // LITERAL:
                noteText.Append(typeText.ToString());
            }

            this.noteLabel.Text = noteText.ToString();
        }

        /// <summary>
        /// 現在の優良設定用備考の値を更新します。
        /// </summary>
        private void UpdateCurrentNoteForPrimeSetting()
        {
            StringBuilder noteText = new StringBuilder();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
            {
                if (!gridRow.Selected) continue;

                string noteKey = PrimeSettingAcs.GetKeyOfOfferPrimeSettingNote(
                    (int)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                    (int)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                    (int)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value
                );
                if (_primeSettingController.OfferPrimeSettingNote.Contains(noteKey))
                {
                    PrmSetNoteWork primeNote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[noteKey];
                    noteText.Append(primeNote.PrmSetNote.Replace("<br>", Environment.NewLine)).Append(Environment.NewLine);
                }
            }
            Debug.WriteLine("備考：" + noteText.ToString());

            SetCurrentNoteForPrimeSetting(
                (int)this.Mk_BlPrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                (int)this.Mk_BlPrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                (int)this.Mk_BlPrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                noteText.ToString()
            );
        }

        /// <summary>
        /// 優良設定マスタグリッドのAfterSelectChangeイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 現在の優良設定用備考の値を更新します。<br/>
        /// [上へ移動],[最上位へ移動]ツールボタン,[下へ移動],[最下位へ移動]ツールボタンの有効フラグを制御します。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void Mk_BlPrimeSettingGrid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            // 現在の優良設定用備考の値を更新
            UpdateCurrentNoteForPrimeSetting();

            // [上へ移動],[最上位へ移動]ツールボタン,[下へ移動],[最下位へ移動]ツールボタンの有効フラグを制御
            EnabledToolButtonForSelectingGrodRow();
        }

        /// <summary>
        /// [上へ移動],[最上位へ移動]ツールボタン,[下へ移動],[最下位へ移動]ツールボタンの有効フラグを制御します。
        /// </summary>
        private void EnabledToolButtonForSelectingGrodRow()
        {
            int beginIndex  = -1;
            int endIndex    = this.Mk_BlPrimeSettingGrid.Rows.Count;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.Mk_BlPrimeSettingGrid.Rows)
            {
                if (!gridRow.Selected) continue;

                if (beginIndex < 0)
                {
                    beginIndex = gridRow.Index;
                }
                else
                {
                    endIndex = gridRow.Index;
                }
            }
            // 1行のみの選択の場合
            if (endIndex.Equals(this.Mk_BlPrimeSettingGrid.Rows.Count) && beginIndex >= 0) endIndex = beginIndex;

            // [上へ移動],[最上位へ移動]ツールボタン
            if (beginIndex > 0)
            {
                int currentBLCode = (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                int previousBLCode= (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex - 1].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                int selectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                int previousSelectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[beginIndex - 1].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = previousBLCode.Equals(currentBLCode);
                //this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled= previousBLCode.Equals(currentBLCode);

                if ((currentBLCode == previousBLCode) && (selectCode == previousSelectCode))
                {
                    this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = true;
                    this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
                    this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
                }
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            }
            else
            {
                this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
                this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled= false;
            }

            // [下へ移動],[最下位へ移動]ツールボタン
            if (endIndex < (this.Mk_BlPrimeSettingGrid.Rows.Count - 1))
            {
                int currentBLCode   = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                int nextBLCode      = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex + 1].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                int selectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                int nextSelectCode = (int)this.Mk_BlPrimeSettingGrid.Rows[endIndex + 1].Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled     = nextBLCode.Equals(currentBLCode);
                //this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled   = nextBLCode.Equals(currentBLCode);

                if ((currentBLCode == nextBLCode) && (selectCode == nextSelectCode))
                {
                    this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = true;
                    this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
                    this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;
                }
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            }
            else
            {
                this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled     = false;
                this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled   = false;
            }
        }
        // ADD 2008/10/29 不具合対応[6961] 仕様変更 ----------<<<<<

        // --- ADD 2009/02/19 障害ID:10402対応------------------------------------------------------>>>>>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.Mk_BlPrimeSettingGrid)
            {
                if (this.Mk_BlPrimeSettingGrid.ActiveRow == null)
                {
                    return;
                }

                int rowIndex = this.Mk_BlPrimeSettingGrid.ActiveRow.Index;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = null;
                        this.Mk_BlPrimeSettingGrid.PerformAction(UltraGridAction.NextRow);
                        this.Mk_BlPrimeSettingGrid.ActiveRow.Selected = true;
                    }
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        e.NextCtrl = null;
                        this.Mk_BlPrimeSettingGrid.PerformAction(UltraGridAction.PrevRow);
                        this.Mk_BlPrimeSettingGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }
        // --- ADD 2009/02/19 障害ID:10402対応------------------------------------------------------<<<<<
        // 2010/01/13 Add >>>
        /// <summary>
        /// BLコード別・セレクト別で表示あり→表示なしの順でソートがかかるように表示順を採番し直します
        /// </summary>
        private void SetDisplayOrder()
        {
            // DISPLAYORDERをキーから外す
            _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                                 PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                                 PrimeSettingInfo.COL_SELECTCODE;
            int count = 0;  // 表示順無しの数を数える
            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
            {
                if ((int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value == 0)
                {
                    row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = Mk_BlPrimeSettingGrid.Rows.Count + 1;
                    row2.Update();
                    count++;
                }
            }
            // DISPLAYORDERをキーに戻す
            _PriSetView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," +
                         PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                         PrimeSettingInfo.COL_SELECTCODE + "," +
                         PrimeSettingInfo.COL_DISPLAYORDER;
            // ソートされた結果に表示順を1から採番し直す
            int selectBLGoodsCode = -1;
            int selectCode = -1;
            count = 0;
            foreach (UltraGridRow row2 in Mk_BlPrimeSettingGrid.Rows)
            {
                if (selectBLGoodsCode == (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value && selectCode == (int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value)
                {
                    row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++count;
                    row2.Update();
                    int tempdisp = (int)row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value;
                    int tempprime = (int)row2.Cells[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Value;
                }
                else
                {
                    selectCode = (int)row2.Cells[PrimeSettingInfo.COL_SELECTCODE].Value;
                    selectBLGoodsCode = (int)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                    count = 0;
                    row2.Cells[PrimeSettingInfo.COL_DISPLAYORDER].Value = ++count;
                    row2.Update();
                }
            }
        }
        // 2010/01/13 Add <<<
    }

    internal class MergedCell : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
    {
        public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
        {
            string text1;
            string text2;

            //if ((column.Key == PrimeSettingInfo.COL_SELECTNAME) ||
            //    (column.Key == PrimeSettingInfo.COL_PARTSMAKERFULLNAME) ||
            //    (column.Key == PrimeSettingInfo.COL_TBSPARTSFULLNAME))

            if ((column.Key == PrimeSettingInfo.COL_TBSPARTSCODE) ||
                (column.Key == PrimeSettingInfo.COL_TBSPARTSFULLNAME) ||
                (column.Key == PrimeSettingInfo.COL_SELECTNAME) ||
                (column.Key == PrimeSettingInfo.COL_PRIMEKINDNAME))
            {
                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((Int32)row1.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value ==
                    (Int32)row2.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value)
                {
                    text1 = (string)row1.Cells[column.Key].Text;
                    text2 = (string)row2.Cells[column.Key].Text;

                    //どちらかが空白なら結合しない
                    if (text1 == "") return false;
                    if (text2 == "") return false;

                    //両方同じ値なら結合する
                    if (text1 == text2) return true;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            return false;
        }
    }
}