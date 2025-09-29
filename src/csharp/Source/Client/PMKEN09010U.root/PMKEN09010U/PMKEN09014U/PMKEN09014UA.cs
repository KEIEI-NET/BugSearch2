//****************************************************************************//
// System           : .NS Series
// Program name     : 優良設定マスタ                 
// Note             : 優良設定の登録・変更・削除を行う    
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                       
//============================================================================//
// 履歴                                                               
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/02/15  修正内容 : 新規作成                                   
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 更 新 日  2008/07/01  修正内容 : 流用/機能追加の為修正                                   
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 更 新 日  2011/11/22  修正内容 : Redmine#8033の対応                               
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李小路
// 更 新 日  2011/11/30  修正内容 : Redmine#8188 優良設定マスタ/表示順の保存について                               
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 更 新 日  2011/12/15  修正内容 : Redmine#26800 優良設定マスタ/表示順の保存について                               
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 譚洪
// 更 新 日  2011/12/19  修正内容 : 2012/01/25配信分、Redmine#27453 
//                                  優良設定マスタ/表示順の保存についての修正                               
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 許培珠
// 更 新 日  2012/09/25　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応                             
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

using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 履歴・得意先・車両情報テキスト出力画面クラス   
    /// </summary>
    /// <remarks>
    /// <br>Note		: 履歴・得意先・車両情報テキスト出力の抽出条件を入力するフォームクラスです。</br>
    /// <br>UpdateNote  : 2008/07/01 30415 柴田 倫幸</br>
    /// <br>        	 ・流用/機能追加の為、修正</br> 
    /// <br>Update Note: 2011/12/19 譚洪</br>
    /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
    /// <br>             Redmine#27453　優良設定マスタ/表示順の保存についての修正</br>
    /// <br>Update Note: 2012/09/25 譚洪</br>
    /// <br>管理番号   ：10801804-00 2012/10/17配信分</br>
    /// <br>             Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応</br>
    /// </remarks>
    public partial class PMKEN09014UA : Form, IPrimeSettingController,
        IPrimeSettingCheckable,             // ADD 2008/10/29 不具合対応[6962] 仕様変更
        IPrimeSettingNoteChangedEventHandler// ADD 2008/10/30 不具合対応[6961] 仕様変更
    {
        # region Constructor
        /// <summary>
        /// 履歴・得意先・車両情報テキスト出力画面クラス コンストラクタ
        /// </summary>
        /// <remarks>履歴・得意先・車両情報テキスト出力画面クラスのコンストラクタです。</remarks>
        public PMKEN09014UA()
        {
            InitializeComponent();

            // インターフェースプロパティ設定処理
            //this.SetProperties();
        }
        # endregion

        private DataView _MgBlMkView;

        // 優良設定マスタコントローラ(インターフェースの実装）
        //PrimeSettingController _primeSettingController;  // DEL 2008/07/01
        PrimeSettingAcs _primeSettingController;           // ADD 2008/07/01

        SupplierAcs _supplierAcs;  // ADD 2008/07/01

        //--------------------------------------------------------------------------
        //	ToolBar
        //--------------------------------------------------------------------------
        # region ▼Const-標準ToolBar
        /// <summary>全体設定</summary>
        private const string TOOL_GROBAL = "Grobal";
        /// <summary>詳細設定</summary>
        private const string TOOL_DETAIL = "Detail";

        /// <summary>上へ</summary>
        private const string TOOL_PRIOR = "Prior";
        /// <summary>下へ</summary>
        private const string TOOL_NEXT = "Next";

        /// <summary>上へ移動</summary>
        private const string TOOL_UP = "Up";
        /// <summary>下へ移動</summary>
        private const string TOOL_DOWN = "Down";
        /// <summary>最上位へ移動</summary>
        private const string TOOL_TOP = "Top";
        /// <summary>最下位へ移動</summary>
        private const string TOOL_BOTTOM = "Bottom";

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>仕入先クリア</summary>
        private const string TOOL_SUPPLIER = "SupplierClear";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        # endregion

        // HACK:実質、1固定ですが…？
        /// <summary>基本設定のタブID</summary>
        private int _navigeteIndex = 1;//0:中分類 1:BLコード

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
            // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
            // 表示内容をリセット
            ultraDockManager1.ResetControlPanes();
            // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<

            if (TabIndex == 1)
            {
                _MgBlMkView.Sort =
                    (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," +
                     PrimeSettingInfo.COL_TBSPARTSCODE + "," +
                     PrimeSettingInfo.COL_MAKERDISPORDER);
                _MgBlMkView.RowFilter = "";

                SetMG_BLTreeView(1);    // TODO:遅いメソッド（中分類/品目設定ツリーの初期化）
                SetMK_BLTreeView();     // メーカー/品目設定ツリーの初期化

                if (this.makerMiddleTab.ActiveTab.Index.Equals(1))
                {
                    if ((SettingNavigatorTree.TopNode != null) && (SettingNavigatorTree.Nodes.Count > 0))
                    {
                        SettingNavigatorTree.TopNode.Selected = true;
                        // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
                        SettingNavigatorTree_AfterSelect(SettingNavigatorTree, new Infragistics.Win.UltraWinTree.SelectEventArgs(SettingNavigatorTree.SelectedNodes));
                        // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<
                    }
                }
                else
                {
                    // ADD 2009/01/14 仕様変更 中分類コードのくくりも表示 ---------->>>>>
                    if ((MK_BLSettingNavigatorTree.TopNode != null) && (MK_BLSettingNavigatorTree.Nodes.Count > 0))
                    {
                        this.MK_BLSettingNavigatorTree.TopNode.Selected = true;
                        // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
                        MK_BLSettingNavigatorTree.Nodes[0].Selected = true;
                        MK_BLSettingNavigatorTree_AfterSelect(MK_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.SelectEventArgs(MK_BLSettingNavigatorTree.SelectedNodes));
                        // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<
                    }
                    // ADD 2009/01/14 仕様変更 中分類コードのくくりも表示 ----------<<<<<
                }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKEN09014UA_Load(object sender, EventArgs e)
        {
            // --- ADD 2009/03/10 障害ID:12270対応------------------------------------------------------>>>>>
            // タブスタイル設定
            makerMiddleTab.UseOsThemes = DefaultableBoolean.False;
            makerMiddleTab.Appearance.BackColor = Color.WhiteSmoke;
            makerMiddleTab.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            makerMiddleTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            makerMiddleTab.ActiveTabAppearance.BackColor = Color.White;
            makerMiddleTab.ActiveTabAppearance.BackColor2 = Color.Pink;
            makerMiddleTab.ActiveTabAppearance.BackGradientStyle = GradientStyle.Vertical;
            makerMiddleTab.Style = UltraTabControlStyle.VisualStudio2005;
            makerMiddleTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // --- ADD 2009/03/10 障害ID:12270対応------------------------------------------------------<<<<<

            if (_MgBlMkView == null) _MgBlMkView = new DataView(_primeSettingController.Mg_Bl_MkTable); // MEMO:
            PrimeSettingGrid.DataSource = _MgBlMkView;
        }

        /// <summary>
        /// 中分類/品目ビューの表示
        /// </summary>
        private void SetMG_BLTreeView(int mode)
        {
            Debug.WriteLine("中分類／品目ツリーの更新開始：" + DateTime.Now);

            SettingNavigatorTree.BeginUpdate();

            // DEL 2009/02/16 不具合対応[10406]↓速度アップ対応 ※原因はこの行
            //SettingNavigatorTree.Nodes.Clear();

            //int order = 0;
            if (mode == 0)
            {
                SettingNavigatorTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None;
            }
            else
            {
                SettingNavigatorTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Default;
            }

            Hashtable Mght = new Hashtable();
            Hashtable MgBlht = new Hashtable();
            Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
            Infragistics.Win.UltraWinTree.UltraTreeNode childNode = null;
            //_MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE);  // DEL 2008/07/01
            
            _MgBlMkView.RowFilter = ""; // ADD 2009/02/16 不具合対応[10406] 速度アップ対応
            // DEL 2009/02/16 不具合対応[10406] 速度アップ対応 ---------->>>>>
            //_MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);           // ADD 2008/07/01
            //_MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
            // DEL 2009/02/16 不具合対応[10406] 速度アップ対応 ----------<<<<<
            // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ---------->>>>>
            string orderBy = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
            _MgBlMkView.Sort = orderBy + "," + PrimeSettingAcs.COL_CHECKSTATE;
            // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ----------<<<<<
            foreach (DataRowView dr in _MgBlMkView)
            {
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 不具合対応[6969] 仕様変更

                #region 削除コード
                //  //ViewのチェックステータスがCHECKEDのデータのみ表示
                //  if ((CheckState)dr[PrimeSettingController.COL_CHECKSTATE] == CheckState.Checked)
                //  {
                #endregion

                string nodeKey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4");

                if (Mght[((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")] == null)
                {
                    Mght.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), dr);
                    // DEL 2008/10/28 不具合対応[6966]↓
                    //node = SettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME]);
                    // ADD 2008/10/28 不具合対応[6966]---------->>>>>
                    string middleGrNodeText = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME];

                    if (!SettingNavigatorTree.Nodes.Exists(nodeKey))
                    {
                        node = SettingNavigatorTree.Nodes.Add(nodeKey, middleGrNodeText);
                    }
                    else
                    {
                        node = SettingNavigatorTree.Nodes[nodeKey];
                    }
                    // ADD 2008/10/28 不具合対応[6966]----------<<<<<
                }
                // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ---------->>>>>
                else
                {
                    node = SettingNavigatorTree.Nodes[nodeKey];
                }
                node.Visible = true;
                // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ----------<<<<<

                string skey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                if (MgBlht[skey] == null)
                {
                    MgBlht.Add(skey, dr);
                    //    order = 1;
                    //                    if (node != null)
                    //                    {
                    if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                    {
                        if (!node.Nodes.Exists(skey))
                        {
                            string tbsPartsFullName = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                            childNode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + tbsPartsFullName);
                        }
                        else
                        {
                            childNode = node.Nodes[skey];
                        }
                    }
                    else
                    {
                        if (!node.Nodes.Exists(skey))
                        {
                            childNode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                        }
                        else
                        {
                            childNode = node.Nodes[skey];
                        }
                    }

                    // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ---------->>>>>
                    childNode.Visible = ((int)dr[PrimeSettingAcs.COL_CHECKSTATE]).Equals(1);
                    if (((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                    {
                        childNode.Visible = false;
                    }
                    // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ----------<<<<<

                    if (mode == 0) childNode.Visible = false;
                    //                    }
                }
                // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ---------->>>>>
                else
                {
                    childNode = node.Nodes[skey];
                    childNode.Visible = ((int)dr[PrimeSettingAcs.COL_CHECKSTATE]).Equals(1);
                    if (((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                    {
                        childNode.Visible = false;
                    }
                    
                    if (mode == 0) childNode.Visible = false;
                }
                // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ----------<<<<<
                #region 削除コード
                // else
                // {
                //     order++;
                // }
                // dr[PrimeSettingController.COL_MAKERDISPORDER] = order;
                //   }
                #endregion
            }   // foreach (DataRowView dr in _MgBlMkView)

            // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ---------->>>>>
            // 表示する子ノードが無い場合、親ノードも非表示にする
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode parentTreeNode in SettingNavigatorTree.Nodes)
            {
                if (!parentTreeNode.HasExpansionIndicator)
                {
                    parentTreeNode.Visible = false;
                }
            }
            // ADD 2009/02/16 不具合対応[10406] 速度アップ対応 ----------<<<<<

            _MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
            _MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);

            SettingNavigatorTree.EndUpdate();

            if (SettingNavigatorTree.Nodes.Count == 0)
            {
                StringBuilder allFilter = new StringBuilder();
                allFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1).Append(ADOUtil.AND).Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(9999999999);
                _MgBlMkView.RowFilter = allFilter.ToString();
            }

            Debug.WriteLine("中分類／品目ツリーの更新終了：" + DateTime.Now);
        }

        private void SettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.PrimeSettingGrid.BeginUpdate();

                // グリッドのカラム表示
                ChangeGridColumnHiddenForMiddleTree();

                for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                {
                    PrimeSettingGrid.Rows[rowIndex].Hidden = false;
                }

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)
                {
                    // ADD 2009/01/14 仕様変更↓：中分類のくくりも表示する
                    SetGridLayoutAccordingToNodeLevel(node.Level);

                    if (node.Level == 0)    // MEMO:中分類ノード
                    {
                        this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
                        this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
                        this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
                        this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;

                        // メーカーリストでグリッド表示を更新
                        int selectedMiddleGenreCode = int.Parse(node.Key);
                        if (!UpdateGridByMakerList(selectedMiddleGenreCode)) continue;
                    }
                    // 詳細設定の場合
                    else // MEMO:品目ノード
                    {
                        this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = true;
                        this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = true;
                        this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = true;
                        this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = true;

                        // 優良設定グループでグリッド表示を更新
                        int selectedMiddleGenreCode = int.Parse(node.Key.Substring(0, 4));
                        int selectedBLCode = int.Parse(node.Key.Substring(4, 8));
                        if (!UpdateGridByPrimeSettingGroup(selectedMiddleGenreCode, selectedBLCode)) continue;

                        int makerCode = 0;
                        foreach (UltraGridRow gridRow in this.PrimeSettingGrid.Rows)
                        {
                            if ((selectedMiddleGenreCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value) &&
                                (selectedBLCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                            {
                                makerCode = (Int32)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                                break;
                            }
                        }

                        NoteChangedEventArgs note = new NoteChangedEventArgs(selectedMiddleGenreCode, selectedBLCode, makerCode, string.Empty);

                        // 備考を更新
                        this.noteLabel.Text = note.ToString();
                    }
                }

                // FIXME:ソート内容がグリッドに反映されない？
                if (this.PrimeSettingGrid.Rows.Count > 0)
                {
                    for (int i = this.PrimeSettingGrid.Rows.Count - 1; i >= 0; i--)
                    {
                        this.PrimeSettingGrid.Rows[i].Selected = true;
                        this.PrimeSettingGrid.Rows[i].Activate();
                        this.PrimeSettingGrid.Rows[i].Selected = false;
                    }

                    if ((SettingNavigatorTree.SelectedNodes == null) || (SettingNavigatorTree.SelectedNodes.Count == 0))
                    {
                        return;
                    }
                    if (SettingNavigatorTree.SelectedNodes[0].Level == 0)
                    {
                        int makerCd = -1;
                        for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                            {
                                continue;
                            }

                            if (makerCd == (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value)
                            {
                                PrimeSettingGrid.Rows[rowIndex].Hidden = true;
                            }
                            makerCd = (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                        }
                    }
                    else
                    {
                        Dictionary<string, string> mk_blDic = new Dictionary<string, string>();
                        for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                        {
                            if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                            {
                                continue;
                            }

                            int makerCd = (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                            int blCd = (Int32)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
                            //---------------ADD BY 李小路 ON 2011/11/30 FOR Redmain#8188--------->>>>>>>>>>>>
                            int order = (int)PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value;
                            if (order == 0) { PrimeSettingGrid.Rows[rowIndex].Hidden = true; continue; };
                            //---------------ADD BY 李小路 ON 2011/11/30 FOR Redmain#8188---------<<<<<<<<<<<<
                            string key = makerCd.ToString("0000") + blCd.ToString("00000");

                            if (!mk_blDic.ContainsKey(key))
                            {
                                mk_blDic.Add(key, key);
                            }
                            else
                            {
                                PrimeSettingGrid.Rows[rowIndex].Hidden = true;
                            }
                        }
                    }
                }

                int makerDispOrder = 0;
                if ((SettingNavigatorTree.SelectedNodes == null) || (SettingNavigatorTree.SelectedNodes.Count == 0))
                {
                    return;
                }

                // 「No」「表示順」をセットします
                if (SettingNavigatorTree.SelectedNodes[0].Level == 0)
                {
                    this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;

                    foreach (DataRowView row in this._MgBlMkView)
                    {
                        row[PrimeSettingInfo.COL_MAKERDISPORDER] = ++makerDispOrder;
                    }
                }
                else
                {
                    this._MgBlMkView.Sort = PrimeSettingAcs.COL_USER_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;

                    Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
                    foreach (DataRowView row in this._MgBlMkView)
                    {
                        string key = ((int)row[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("0000") + ((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("0000") + ((int)row[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("00000");
                        //---------------ADD BY 李小路 ON 2011/11/30 FOR Redmain#8188--------->>>>>>>>>>>>
                        int order = (int)row[PrimeSettingAcs.COL_USER_MAKERDISPORDER];
                        if (order == 0) continue;
                        //---------------ADD BY 李小路 ON 2011/11/30 FOR Redmain#8188---------<<<<<<<<<<<<

                        if (!makerDispOrderDic.ContainsKey(key))
                        {
                            row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = ++makerDispOrder;
                            makerDispOrderDic.Add(key, (int)row[PrimeSettingAcs.COL_USER_MAKERDISPORDER]);
                        }
                        else
                        {
                            row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = (int)makerDispOrderDic[key];
                        }
                    }
                }

                for (int rowIndex = 0; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                {
                    this.PrimeSettingGrid.Rows[rowIndex].Selected = true;
                    this.PrimeSettingGrid.Rows[rowIndex].Activate();
                    this.PrimeSettingGrid.Rows[rowIndex].Selected = false;
                }

                this.PrimeSettingGrid.ActiveRow = null;
                this.PrimeSettingGrid.Update();
                this.PrimeSettingGrid.EndUpdate();

                // 備考を更新
                if (SettingNavigatorTree.SelectedNodes[0].Level == 0)
                {
                    this.noteLabel.Text = string.Empty;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region 仕様が大幅に変更したため削除
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        this.PrimeSettingGrid.BeginUpdate();

        //        // グリッドのカラム表示
        //        ChangeGridColumnHiddenForMiddleTree();  // ADD 2008/10/29 不具合対応[6969] 仕様変更

        //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)
        //        {
        //            #region 削除コード
        //            //全体設定の場合
        //            /*
        //            if ((node.Level == 0) && (_navigeteIndex == 0))
        //            {
        //                s = String.Format("{0}={1}", PrimeSettingController.COL_MIDDLEGENRECODE, node.Key);
        //                s += String.Format(" and {0}={1}", PrimeSettingController.COL_TBSPARTSCODE, node.Nodes[0].Key.Substring(4, 8));
        //                _MgBlMkView.RowFilter = s;
        //            }
                
        //            //詳細設定の場合
        //            if (_navigeteIndex == 1)
        //            {
        //                //親指定は表示しない
        //                if (node.Level == 0)
        //                {
        //                //    s = String.Format("{0}={1}", PrimeSettingController.COL_MIDDLEGENRECODE, (Int32)0);
        //                //    _MgBlMkView.RowFilter = s;
        //                }
        //                else
        //                {
        //                    s = String.Format("{0}={1}", PrimeSettingController.COL_MIDDLEGENRECODE, node.Key.Substring(0, 4));
        //                    s += String.Format(" and {0}={1}", PrimeSettingController.COL_TBSPARTSCODE, node.Key.Substring(4, 8));
        //                    _MgBlMkView.RowFilter = s;
        //                }
        //            }
        //            if (s == "") return;
        //            _MgBlMkView.RowFilter =
        //               String.Format("{0}=1 and ", PrimeSettingController.COL_CHECKSTATE) + s;
        //              */
        //            #endregion  // 削除コード

        //            // ADD 2009/01/14 仕様変更↓：中分類のくくりも表示する
        //            SetGridLayoutAccordingToNodeLevel(node.Level);

        //            if (node.Level == 0)    // MEMO:中分類ノード
        //            {
        //                this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
        //                this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
        //                this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
        //                this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;

        //                // DEL 2009/01/14 仕様変更：中分類のくくりも表示する ---------->>>>>
        //                //_MgBlMkView.RowFilter = String.Format("{0}={1} and {2}=1", PrimeSettingInfo.COL_MIDDLEGENRECODE, node.Key, PrimeSettingAcs.COL_CHECKSTATE);
        //                //_MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;
        //                // DEL 2009/01/14 仕様変更：中分類のくくりも表示する ----------<<<<<
        //                // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ---------->>>>>
        //                // メーカーリストでグリッド表示を更新
        //                int selectedMiddleGenreCode = int.Parse(node.Key);
        //                if (!UpdateGridByMakerList(selectedMiddleGenreCode)) continue;
        //                // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ----------<<<<<
        //            }
        //            // 詳細設定の場合
        //            else // MEMO:品目ノード
        //            {
        //                this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = true;
        //                this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = true;
        //                this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = true;
        //                this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = true;

        //                // DEL 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        //                //string filter = String.Format("{0}={1}", PrimeSettingInfo.COL_MIDDLEGENRECODE, node.Key.Substring(0, 4));
        //                //filter += String.Format(" and {0}={1}", PrimeSettingInfo.COL_TBSPARTSCODE, node.Key.Substring(4, 8));
        //                //_MgBlMkView.RowFilter = filter;
        //                //_MgBlMkView.RowFilter =
        //                //    //String.Format("{0}=1 and ", PrimeSettingController.COL_CHECKSTATE) + filter;  // DEL 2008/07/01
        //                //   String.Format("{0}=1 and ", PrimeSettingAcs.COL_CHECKSTATE) + filter;            // ADD 2008/07/01
        //                // DEL 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
        //                // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        //                // 優良設定グループでグリッド表示を更新
        //                int selectedMiddleGenreCode = int.Parse(node.Key.Substring(0, 4));
        //                int selectedBLCode = int.Parse(node.Key.Substring(4, 8));
        //                if (!UpdateGridByPrimeSettingGroup(selectedMiddleGenreCode, selectedBLCode)) continue;
        //                // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        //            }   // else
        //        }   // foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in SettingNavigatorTree.SelectedNodes)

        //        // FIXME:ソート内容がグリッドに反映されない？
        //        if (this.PrimeSettingGrid.Rows.Count > 0)
        //        {
        //            for (int i = this.PrimeSettingGrid.Rows.Count - 1; i >= 0; i--)
        //            {
        //                this.PrimeSettingGrid.Rows[i].Selected = true;
        //                this.PrimeSettingGrid.Rows[i].Activate();
        //                this.PrimeSettingGrid.Rows[i].Selected = false;
        //            }
        //        }

        //        int makerDispOrder = 0;
        //        foreach (DataRowView row in this._MgBlMkView)
        //        {
        //            row[PrimeSettingInfo.COL_MAKERDISPORDER] = ++makerDispOrder;
        //        }
                
        //        this.PrimeSettingGrid.Update();
        //        this.PrimeSettingGrid.EndUpdate();
                
        //        // 備考を更新
        //        this.noteLabel.Text = string.Empty; // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}
        #endregion 仕様が大幅に変更したため削除

        // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ---------->>>>>
        #region <中分類のくくりも表示/>

        /// <summary>
        /// メーカーリストでグリッド表示を更新します。
        /// </summary>
        /// <param name="selectedMiddleGenreCode">選択された中分類コード</param>
        /// <returns><c>false</c>:途中で処理を中断</returns>
        private bool UpdateGridByMakerList(int selectedMiddleGenreCode)
        {
            //this.PrimeSettingGrid.DataSource = null;

            string firstRowFilter = this._MgBlMkView.RowFilter;
            string firstSort = this._MgBlMkView.Sort;

            // グリッドへの表示条件をリセット
            StringBuilder allFilter = new StringBuilder();
            {
                allFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
            }
            this._MgBlMkView.RowFilter = allFilter.ToString();
            foreach (DataRowView row in this._MgBlMkView)
            {
                row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.None;
            }

            // A.優良設定マスタ（ユーザー登録分）に登録されているレコード
            StringBuilder userFilter = new StringBuilder();
            {
                userFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                userFilter.Append(ADOUtil.AND);
                userFilter.Append(PrimeSettingAcs.COL_USER_MAKERDISPORDER).Append(ADOUtil.LARGE).Append(0); // 提供分の値は0
                userFilter.Append(ADOUtil.AND);
                userFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }
            this._MgBlMkView.RowFilter = userFilter.ToString();
            this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;

            // B.選択した中分類コードにひもづく、BLコードがもつメーカーをリストにする
            // 起動時にアクセスクラスにて中分類コード別に構築
#if DEBUG
            IList<int> makerCodeList = this._primeSettingController.FindMakerCode(selectedMiddleGenreCode);
            Debug.WriteLine("中分類コード：" + selectedMiddleGenreCode.ToString());
            foreach (int makerCode in makerCodeList)
            {
                Debug.WriteLine("\tメーカーコード：" + makerCode.ToString());
            }
#endif
            int gridDispOrderCount = 0; // グリッドのソート順を決めるカウンタ

            // C.AとBの差分を取り、Aの下にBの残レコードを表示する
            foreach (DataRowView row in this._MgBlMkView)
            {
                // グリッドのソート順を設定
                row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridDispOrderCount;

                int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                if (this._primeSettingController.ContainsMakerCode(selectedMiddleGenreCode, makerCode))
                {
                    // Aのうち、削除対象ではないレコード
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.ViewingRecord;
                }
                else
                {
                    // Aのうち、削除対象となるレコード
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.DeletingRecord;
                    row[PrimeSettingAcs.COL_GRIDSORTORDER] = gridDispOrderCount * (-1);  // 削除対象はグリッドの下に表示
                }
            }
            // 中分類コードでフィルタ（提供分のみとなる）
            StringBuilder makerFilter = new StringBuilder();
            {
                makerFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                makerFilter.Append(ADOUtil.AND);
                makerFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }
            this._MgBlMkView.RowFilter = makerFilter.ToString();

            // 残レコードと削除対象レコードのグリッドのソート順を設定
            int deleteingRecordDispOrderCount = this._MgBlMkView.Count;

            foreach (DataRowView row in this._MgBlMkView)
            {
                // 残レコード
                int userMakerDispOrder = (int)row[PrimeSettingAcs.COL_USER_MAKERDISPORDER];
                if (userMakerDispOrder.Equals(0))
                {
                    row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridDispOrderCount;
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.ViewingRecord;
                }

                // 削除レコード
                int gridDispOrder = (int)row[PrimeSettingAcs.COL_GRIDSORTORDER];
                if (gridDispOrder < 0)  // 前段のC.の処理でマーキング済み
                {
                    row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++deleteingRecordDispOrderCount;
                    row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.DeletingRecord;
                }
            }

            // C.基本設定にて、非表示となっているレコード（削除対象）：ユーザー表示順 > 0 && チェック==なし && BLコード<>0
            StringBuilder uncheckedFilter = new StringBuilder();
            {
                uncheckedFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                uncheckedFilter.Append(ADOUtil.AND);
                uncheckedFilter.Append(PrimeSettingAcs.COL_USER_MAKERDISPORDER).Append(ADOUtil.LARGE).Append(0);    // 提供分の値は0
                uncheckedFilter.Append(ADOUtil.AND);
                uncheckedFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(0);
                uncheckedFilter.Append(ADOUtil.AND);                                                        // FIXME:BLコード=0は無視
                uncheckedFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0); // FIXME:BLコード=0は無視
            }
            this._MgBlMkView.RowFilter = uncheckedFilter.ToString();
            
            foreach (DataRowView row in this._MgBlMkView)
            {
                row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++deleteingRecordDispOrderCount;
                row[PrimeSettingAcs.COL_USER_STATUS] = (int)PrimeSettingAcs.UserStatus.DeletingRecord;
            }

            // 表示順を再度振り直す
            StringBuilder gridFilter = new StringBuilder();
            {
                gridFilter.Append(ADOUtil.BEGIN_BLOCK);
                gridFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                gridFilter.Append(ADOUtil.AND);
                gridFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                gridFilter.Append(ADOUtil.END_BLOCK);

                gridFilter.Append(ADOUtil.OR);

                gridFilter.Append(ADOUtil.BEGIN_BLOCK);
                gridFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                gridFilter.Append(ADOUtil.AND);
                gridFilter.Append(PrimeSettingAcs.COL_USER_STATUS).Append(ADOUtil.NOT_EQ).Append((int)PrimeSettingAcs.UserStatus.None);
                gridFilter.Append(ADOUtil.END_BLOCK);
            }
            this._MgBlMkView.RowFilter = gridFilter.ToString();
            this._MgBlMkView.Sort = PrimeSettingAcs.COL_GRIDSORTORDER;

            int makerDispOrder = 1;
            foreach (DataRowView record in this._MgBlMkView)
            {
                record[PrimeSettingInfo.COL_MAKERDISPORDER] = ++makerDispOrder;
                record[PrimeSettingInfo.COL_MAKERDISPORDER] = record[PrimeSettingAcs.COL_GRIDSORTORDER];
            }

            //this.PrimeSettingGrid.DataSource = this._MgBlMkView;

            // 削除対象をグリッド色を変更
            for (int i = 0; i < this.PrimeSettingGrid.Rows.Count; i++)
            {
                int userStatus = (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingAcs.COL_USER_STATUS].Value;
                if (userStatus.Equals((int)PrimeSettingAcs.UserStatus.DeletingRecord))
                {
                    this.PrimeSettingGrid.Rows[i].Appearance.BackColor = Color.Pink;
                }
                else
                {
                    this.PrimeSettingGrid.Rows[i].Appearance.Reset();
                }
            }

            // BLコード=0 のデータを代表として表示
            Dictionary<int, int> makerCodeDic = new Dictionary<int, int>();
            foreach (DataRowView row in this._MgBlMkView)
            {
                int makerCode = (Int32)row[PrimeSettingInfo.COL_PARTSMAKERCD];

                if (!makerCodeDic.ContainsKey(makerCode))
                {
                    makerCodeDic.Add(makerCode, makerCode);
                }
            }

            allFilter = new StringBuilder();
            {
                int index = 0;
                foreach (int makerCode in makerCodeDic.Values)
                {
                    if (index != 0)
                    {
                        allFilter.Append(ADOUtil.OR);
                    }

                    allFilter.Append(ADOUtil.BEGIN_BLOCK);
                    allFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                    allFilter.Append(ADOUtil.AND);
                    allFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(0);
                    allFilter.Append(ADOUtil.AND);
                    allFilter.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(makerCode);
                    allFilter.Append(ADOUtil.END_BLOCK);
                    index++;
                }
            }

            this._MgBlMkView.RowFilter = allFilter.ToString();
            this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD;

            // ----- DEL 2012/09/25 xupz for redmine#32367----->>>>>
            //ArrayList targetList = new ArrayList();
            //foreach (DataRowView row in _primeSettingController.Mg_Bl_MkView)
            //{
            //    if (((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE] == selectedMiddleGenreCode) &&
            //        ((int)row[PrimeSettingInfo.COL_TBSPARTSCODE] != 0))
            //    {
            //        targetList.Add(row);
            //    }
            //}

            //foreach (DataRowView row in this._MgBlMkView)
            //{
            //    int makerCode = (Int32)row[PrimeSettingInfo.COL_PARTSMAKERCD];
            //    int supplierCode = 0;
            //    if (row[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
            //    {
            //        supplierCode = (Int32)row[PrimeSettingInfo.COL_SUPPLIERCD];
            //    }

            //    Dictionary<int, int> supplierCodeDic = new Dictionary<int, int>();
            //    foreach (DataRowView rowView in targetList)
            //    {
            //        if (makerCode == (Int32)rowView[PrimeSettingInfo.COL_PARTSMAKERCD])
            //        {
            //            int supplierCd = 0;
            //            if (rowView[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
            //            {
            //                supplierCd = (Int32)rowView[PrimeSettingInfo.COL_SUPPLIERCD];
            //            }

            //            if (supplierCd != 0)
            //            {
            //                if (!supplierCodeDic.ContainsKey(supplierCd))
            //                {
            //                    supplierCodeDic.Add(supplierCd, supplierCd);
            //                }
            //            }
            //        }
            //    }

            //    if (supplierCodeDic.Values.Count == 1)
            //    {
            //        foreach (int code in supplierCodeDic.Values)
            //        {
            //            row[PrimeSettingInfo.COL_SUPPLIERCD] = code;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        row[PrimeSettingInfo.COL_SUPPLIERCD] = DBNull.Value;
            //    }
            //}
            // ----- DEL 2012/09/25 xupz for redmine#32367-----<<<<<

            return true;
        }

        #endregion  // <中分類のくくりも表示/>
        // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ----------<<<<<

        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        #region <関連BLコードの表示/>

        /// <summary>
        /// 優良設定グループでグリッド表示を更新します。
        /// </summary>
        /// <param name="selectedMiddleGenreCode">選択された中分類コード</param>
        /// <param name="selectedBLCode">選択されたBLコード</param>
        /// <returns><c>false</c>:途中で処理を中断</returns>
        private bool UpdateGridByPrimeSettingGroup(
            int selectedMiddleGenreCode,
            int selectedBLCode
        )
        {
            // 1.中分類コード + BLコードでフィルタ
            StringBuilder selectedFilter = new StringBuilder();
            {
                selectedFilter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(selectedMiddleGenreCode);
                selectedFilter.Append(ADOUtil.AND);
                selectedFilter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(selectedBLCode);
                selectedFilter.Append(ADOUtil.AND);
                selectedFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }
            this._MgBlMkView.RowFilter = selectedFilter.ToString();

            string firstFilter = this._MgBlMkView.RowFilter;
            string firstSort = this._MgBlMkView.Sort;

            // 2.表示順, メーカーコードでソート
            string sort = PrimeSettingAcs.COL_USER_MAKERDISPORDER + ADOUtil.COMMA + PrimeSettingInfo.COL_PARTSMAKERCD;
            this._MgBlMkView.Sort = sort;

            // 3.仮ソート順を設定しながら優良設定グループを取得
            //int gridSortOrder = 0;
            IDictionary<int, int> primeSettingGroupMap = new Dictionary<int, int>();
            foreach (DataRowView row in this._MgBlMkView)
            {
                // --- DEL 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridSortOrder;
                // --- DEL 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                row[PrimeSettingAcs.COL_RELATEDBLCODE] = string.Empty;  // 関連元のセルは空にする

                int primeSettingGroup = (int)row[PrimeSettingInfo.COL_PRMSETGROUP];

                if (!PrimeSettingAcs.ExistsGroup0)
                {
                    if (primeSettingGroup.Equals(0)) continue;
                }

                if (!primeSettingGroupMap.ContainsKey(primeSettingGroup))
                {
                    primeSettingGroupMap.Add(primeSettingGroup, primeSettingGroup);
                }
            }

            // 4.優良設定グループでフィルタを再設定
            StringBuilder where = new StringBuilder();
            {
                foreach (int primeSettingGroup in primeSettingGroupMap.Values)
                {
                    if (string.IsNullOrEmpty(where.ToString()))
                    {
                        where.Append("(");
                    }
                    else
                    {
                        where.Append(ADOUtil.OR);
                    }
                    where.Append(PrimeSettingInfo.COL_PRMSETGROUP).Append(ADOUtil.EQ).Append(primeSettingGroup);
                }
                if (!string.IsNullOrEmpty(where.ToString()))
                {
                    where.Append(")");
                }
            }
            if (!string.IsNullOrEmpty(where.ToString()))
            {
                where.Append(ADOUtil.AND).Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
                this._MgBlMkView.RowFilter = where.ToString();
            }
            else
            {
                this._MgBlMkView.RowFilter = firstFilter;
                this._MgBlMkView.Sort = firstSort;
                //return false;
                return true;
            }

            // --- DEL 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
            //// 5.ソート順を設定
            //foreach (DataRowView row in this._MgBlMkView)
            //{
            //    int currentGridSortOrder = (int)row[PrimeSettingAcs.COL_GRIDSORTORDER];
            //    int currentMiddleGenreCode = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
            //    int currentBLCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];
            //    if (!(currentMiddleGenreCode.Equals(selectedMiddleGenreCode) && currentBLCode.Equals(selectedBLCode)))
            //    {
            //        row[PrimeSettingAcs.COL_GRIDSORTORDER] = ++gridSortOrder;
            //    }
            //    // 表示順も設定
            //    row[PrimeSettingInfo.COL_MAKERDISPORDER] = row[PrimeSettingAcs.COL_GRIDSORTORDER];
            //}

            //// 6.ソート順でソート
            //this._MgBlMkView.Sort = PrimeSettingAcs.COL_GRIDSORTORDER;
            // --- DEL 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

            // 7.関連BLコードを設定
            foreach (DataRowView row in this._MgBlMkView)
            {
                string relatedBLCode = (string)row[PrimeSettingAcs.COL_RELATEDBLCODE];
                if (string.IsNullOrEmpty(relatedBLCode))
                {
                    int middleGenreCode = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                    int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];
                    if (!(middleGenreCode.Equals(selectedMiddleGenreCode) && blCode.Equals(selectedBLCode)))
                    {
                        relatedBLCode = this._primeSettingController.GetRelatedBLCodeName(blCode);
                        row[PrimeSettingAcs.COL_RELATEDBLCODE] = relatedBLCode;
                    }
                }
            }

            // 8.表示順でソート
            //this._MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD;
            //this._MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;
            this._MgBlMkView.Sort = PrimeSettingAcs.COL_USER_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;

            return true;
        }

        #endregion  // <関連BLコードの表示/>
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        /// <summary>
        /// 中分類-品目ツリーのノードに応じたグリッド表示を設定します。
        /// </summary>
        /// <param name="nodeLevel">ノードレベル</param>
        private void SetGridLayoutAccordingToNodeLevel(int nodeLevel)
        {
            //列幅自動調整
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.PrimeSettingGrid.DisplayLayout.Bands[0];

            // 中分類ノード
            if (nodeLevel.Equals(0))
            {
                band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.Caption = "No.";
                band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Hidden = false;
                band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Hidden = true;
                band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Hidden = true;

                if (!band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden)
                {
                    band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = true;
                }

                // FIXME:デバッグ用↓
                //band.Columns[PrimeSettingAcs.COL_USER_STATUS].Hidden = false;
                //band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = false;
            }
            // 品目ノード
            else
            {
                //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.Caption = "表示順";
                band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Hidden = true;
                band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Hidden = false;
                band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.Caption = "表示順";
                band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Hidden = false;
                
                if (PrimeSettingAcs.ExistsGroup0)
                {
                    band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = false;
                }
                // FIXME:デバッグ用↑

                if (!band.Columns[PrimeSettingAcs.COL_USER_STATUS].Hidden)
                {
                    band.Columns[PrimeSettingAcs.COL_USER_STATUS].Hidden = true;
                }
                if (!band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden)
                {
                    band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Hidden = true;
                }
            }

            // 列幅自動調整
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            //// TODO:微妙に幅が狭いので微調整
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = MAKER_CODE_COLUMN_WIDTH;
        }
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = PrimeSettingGrid;

            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // 列の表示／非表示（デフォルト）
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_MAKERDISPORDER:
                    case PrimeSettingInfo.COL_PARTSMAKERCD:
                    case PrimeSettingInfo.COL_PARTSMAKERFULLNAME:

                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    case PrimeSettingInfo.COL_SUPPLIERGUIDE:
                    case PrimeSettingInfo.COL_SUPPLIERCD:
                    case PrimeSettingInfo.COL_SUPPLIERNAME:
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }

            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Width = 60;
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].MaxWidth = 60;
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].MinWidth = 60;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = 90;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Width = 150;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MaxWidth = 150;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].MinWidth = 150;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Width = 120;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].MaxWidth = 120;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].MinWidth = 120;
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].Width = 200;
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].MaxWidth = 200;
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].MinWidth = 200;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Width = 120;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].MaxWidth = 120;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].MinWidth = 120;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Width = 60;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].MaxWidth = 60;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].MinWidth = 60;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Width = 60;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].MaxWidth = 60;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].MinWidth = 60;

            // 表示順
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.VisiblePosition = 0;
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.VisiblePosition = 1;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Header.VisiblePosition = 2;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.VisiblePosition = 3;
            // ADD 2008/10/29 不具合対応[6969] 仕様変更 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.VisiblePosition = 4;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.VisiblePosition = 5;
            // ADD 2008/10/29 不具合対応[6969] 仕様変更 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Header.VisiblePosition = 6;       // MOD 2008/10/29 不具合対応[6969] 仕様変更 3→5
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Header.VisiblePosition = 7;    // MOD 2008/10/29 不具合対応[6969] 仕様変更 4→6
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].Header.VisiblePosition = 8;     // MOD 2008/10/29 不具合対応[6969] 仕様変更 5→7
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].Header.VisiblePosition = 9;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Header.VisiblePosition = 10;
            band.Columns[PrimeSettingAcs.COL_GRIDSORTORDER].Header.VisiblePosition = 11;
            //band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.VisiblePosition = 11;
            band.Columns[PrimeSettingAcs.COL_USER_STATUS].Header.VisiblePosition = 12;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

            // ADD 2008/10/28 不具合対応[6964] タイトル表示はセンタリング ---------->>>>>
            // タイトル表示位置
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2008/10/28 不具合対応[6964] タイトル表示はセンタリング ----------<<<<<
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // 表示位置
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;// MOD 2008/10/28 不具合対応[6968] .Center→.Right
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // MOD 2008/10/28 不具合対応[6968] .Center→.Right
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ADD 2008/10/28 不具合対応[6969]---------->>>>>
            // 表示フォーマット
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Format = "0000";
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].Format = "0000";
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].Format = "000000";
            // ADD 2008/10/28 不具合対応[6969]----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
            // 編集不可設定
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellActivation = Activation.AllowEdit;// MOD 2008/10/28 不具合対応[6963] .Disabled→.AllowEdit
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellActivation = Activation.Disabled; // MOD 2009/01/13 仕様変更：表示順の手入力を廃止 .AllowEdit→.Disabled
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].TabStop = true;   // HACK:編集可能セルのTabStop
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellActivation = Activation.Disabled;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellActivation = Activation.Disabled;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellActivation = Activation.Disabled;       // ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellActivation = Activation.Disabled;   // ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].CellActivation = Activation.AllowEdit;    // 入力可
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].TabStop = true;   // HACK:編集可能セルのTabStop
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].CellActivation = Activation.Disabled;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellActivation = Activation.Disabled;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellActivation = Activation.Disabled;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellActivation = Activation.Disabled;

            // セルクリック動作
            // ADD 2009/01/13 仕様変更：表示順の手入力を廃止（不具合対応[6963]による削除を復活）
            // DEL 2008/10/28 不具合対応[6963]↓
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellClickAction = CellClickAction.RowSelect;    // ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellClickAction = CellClickAction.RowSelect;// ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].CellClickAction = CellClickAction.RowSelect;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellClickAction = CellClickAction.RowSelect;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellClickAction = CellClickAction.RowSelect;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellClickAction = CellClickAction.RowSelect;

            // 前景色の設定
            band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].CellAppearance.ForeColorDisabled = Color.Black;     // ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].CellAppearance.ForeColorDisabled = Color.Black; // ADD 2008/10/29 不具合対応[6969] 仕様変更
            band.Columns[PrimeSettingInfo.COL_SUPPLIERNAME].CellAppearance.ForeColorDisabled = Color.Black;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            band.Columns[PrimeSettingInfo.COL_PRMSETGROUP].CellAppearance.ForeColorDisabled = Color.Black;
            band.Columns[PrimeSettingAcs.COL_RELATEDBLCODE].CellAppearance.ForeColorDisabled = Color.Black;
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
            band.Columns[PrimeSettingAcs.COL_USER_MAKERDISPORDER].CellAppearance.ForeColorDisabled = Color.Black;

            // 表示位置調整
            band.Columns[PrimeSettingInfo.COL_SUPPLIERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 変更許可
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

            // --- ADD 2008/07/01 -------------------------------->>>>>
            // ガイドボタンの設定
            // --- CHG 2009/02/19 障害ID:10404対応------------------------------------------------------>>>>>
            //band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Width = 19;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Width = 20;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].MinWidth = 20;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].MaxWidth = 20;
            // --- CHG 2009/02/19 障害ID:10404対応------------------------------------------------------<<<<<
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].CellActivation = Activation.NoEdit;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            band.Columns[PrimeSettingInfo.COL_SUPPLIERGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            #region 削除コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// キー動作マッピングを追加
            //grid.KeyActionMappings.Add(
            //    new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //        Keys.Enter,	//Enterキー
            //        Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
            //        0,
            //        Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
            //        Infragistics.Win.SpecialKeys.All,
            //        0 )
            //    );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            #endregion  // 削除コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // キーマッピング処理
            MakeKeyMappingForGrid(grid);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2008/10/28 不具合対応[6966]---------->>>>>
            // TODO:微妙に幅が狭いので微調整
            // DEL 2009/01/30 不具合対応[10404]↓
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width += DELTA_WHITH;
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = 120;    // ADD 2009/01/30 不具合対応[10404]
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].MaxWidth = 120;    // ADD 2009/01/30 不具合対応[10404]
            band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].MinWidth = 120;    // ADD 2009/01/30 不具合対応[10404]
            // ADD 2008/10/28 不具合対応[6966]----------<<<<<
        }


        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 全体設定ボタン
                case TOOL_GROBAL:
                    {
                        //setMG_BLTreeView(0);
                        //_navigeteIndex = 0;
                        break;
                    }
                // 詳細設定ボタン
                case TOOL_DETAIL:
                    {
                        if (_navigeteIndex == 1) break;
                        SetMG_BLTreeView(1);
                        // TODO:詳細設定ボタン押下時のツリー表示？
                        _navigeteIndex = 1;
                        break;
                    }

                // 上へ(ノード)
                case TOOL_PRIOR:
                    {
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        if (SettingNavigatorTree.Nodes.Count == 0)
                        {
                            return;
                        }
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        // DEL 2008/10/29 不具合対応[6969] 仕様変更（メソッドとして抽出） ---------->>>>>
                        #region 削除コード
                        //if (SettingNavigatorTree.SelectedNodes[0] != null)
                        //{
                        //    Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                        //    if (node.PrevVisibleNode != null)
                        //    {
                        //        if (node.PrevVisibleNode.Level == 1)
                        //        {
                        //            node.PrevVisibleNode.Parent.Selected = true;
                        //        }
                        //        else
                        //        {
                        //            node.PrevVisibleNode.Selected = true;
                        //        }
                        //    }
                        //}
                        #endregion  // 削除コード
                        // DEL 2008/10/29 不具合対応[6969] 仕様変更（メソッドとして抽出）----------<<<<<
                        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ---------->>>>>
                        if (!IsMakerTab(this.makerMiddleTab.ActiveTab))
                        {
                            SelectUp(this.SettingNavigatorTree);
                        }
                        else
                        {
                            SelectUp(this.MK_BLSettingNavigatorTree);
                        }
                        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ----------<<<<<
                        break;
                    }

                // 下へ(ノード)
                case TOOL_NEXT:
                    {
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        if (SettingNavigatorTree.Nodes.Count == 0)
                        {
                            return;
                        }
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        // DEL 2008/10/29 不具合対応[6969] 仕様変更（メソッドとして抽出） ---------->>>>>
                        #region 削除コード
                        //if (SettingNavigatorTree.SelectedNodes[0] != null)
                        //{
                        //    Infragistics.Win.UltraWinTree.UltraTreeNode node = SettingNavigatorTree.SelectedNodes[0];
                        //    if (node.NextVisibleNode != null)
                        //    {
                        //        if (node.NextVisibleNode.Level == 1)
                        //        {
                        //            while (true)
                        //            {
                        //                node = node.NextVisibleNode;
                        //                if (node == null) return;
                        //                if (node.Level == 0) break;
                        //            }
                        //            node.Selected = true;
                        //        }
                        //        else
                        //        {
                        //            node.NextVisibleNode.Selected = true;
                        //        }
                        //    }
                        //}
                        #endregion  // 削除コード
                        // DEL 2008/10/29 不具合対応[6969] 仕様変更（メソッドとして抽出）----------<<<<<
                        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ---------->>>>>
                        if (!IsMakerTab(this.makerMiddleTab.ActiveTab))
                        {
                            SelectDown(this.SettingNavigatorTree);
                        }
                        else
                        {
                            SelectDown(this.MK_BLSettingNavigatorTree);
                        }
                        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ----------<<<<<
                        break;
                    }

                // 上へ
                case TOOL_UP:
                    {
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        #region 削除コード
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    int order = PrimeSettingGrid.ActiveRow.Index + 1;

                        //    if (idx == 0) return;
                        //    //先にアイテムを取得しておく
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row1 = PrimeSettingGrid.Rows[idx - 1];
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];

                        //    //上のアイテムの順位を下げる
                        //    row1.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order;
                        //    row1.Update();

                        //    //選択されているRowの順位を上げる
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order - 1;
                        //    selectrow.Update();
                        //    selectrow.Selected = true;
                        //    PrimeSettingGrid.ActiveRow = selectrow;
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        MoveUpGridRow(1);   // 1つ上へ移動
                        break;
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                    }

                // 下へ
                case TOOL_DOWN:
                    {
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        #region 削除コード
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    int order = PrimeSettingGrid.ActiveRow.Index + 1;
                        //    if (PrimeSettingGrid.Rows.Count <= order) return;
                        //    //先にアイテムを取得しておく
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow row = PrimeSettingGrid.Rows[idx + 1];
                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];

                        //    //下のアイテムの順位を上げる
                        //    row.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order;
                        //    row.Update();
                        //    //選択されているRowの順位を下げる
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = order + 1;
                        //    selectrow.Update();
                        //    selectrow.Selected = true;
                        //    PrimeSettingGrid.ActiveRow = selectrow;
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        MoveDownGridRow(1); // 1つ下へ移動
                        break;
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                    }

                // TODO:[トップへ]
                case TOOL_TOP:
                    {
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        #region 削除コード
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    if (idx == 0) return;

                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = 0;
                        //    selectrow.Update();
                        //    for (int i = idx; 1 <= i; i--)
                        //    {
                        //        //上のアイテムの順位を下げる
                        //        Infragistics.Win.UltraWinGrid.UltraGridRow row = PrimeSettingGrid.Rows[i];
                        //        row.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = i + 1;
                        //        row.Update();
                        //    }

                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = 1;
                        //    selectrow.Update();
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        MoveUpGridRow(0);   // 0:先頭へ移動
                        break;
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                    }
                // TODO:[ボトムへ]
                case TOOL_BOTTOM:
                    {
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        #region 削除コード
                        //if (PrimeSettingGrid.ActiveRow != null)
                        //{
                        //    int idx = PrimeSettingGrid.ActiveRow.Index;
                        //    if (idx == PrimeSettingGrid.Rows.Count-1) return;

                        //    Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];
                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = 0;
                        //    selectrow.Update();
                        //    for (int i = idx; i < PrimeSettingGrid.Rows.Count; i++)
                        //    {
                        //        //下のアイテムの順位を上げる
                        //        Infragistics.Win.UltraWinGrid.UltraGridRow row = PrimeSettingGrid.Rows[i];
                        //        row.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = i;
                        //        row.Update();
                        //    }

                        //    selectrow.Cells[PrimeSettingInfo.COL_MAKERDISPORDER].Value = PrimeSettingGrid.Rows.Count;
                        //    selectrow.Update();
                        //}
                        //break;
                        #endregion
                        // DEL 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
                        MoveDownGridRow(0); // 0:末尾へ移動
                        break;
                        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
                    }
                // --- ADD 2008/07/01 -------------------------------->>>>>
                // 仕入先クリア
                case TOOL_SUPPLIER:
                    {
                        if (PrimeSettingGrid.ActiveRow != null)
                        {
                            int idx = PrimeSettingGrid.ActiveRow.Index;

                            Infragistics.Win.UltraWinGrid.UltraGridRow selectrow = PrimeSettingGrid.Rows[idx];
                            selectrow.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;
                            selectrow.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;

                            // 変更フラグ更新
                            _primeSettingController.ChangeSupplierCd((int)selectrow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                                                                     (int)selectrow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                                                                     (int)selectrow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                                                                     0);

                            // --- ADD 2009/03/11 障害ID:12368対応------------------------------------------------------>>>>>
                            PrimeSettingGrid.PerformAction(UltraGridAction.ExitEditMode);
                            PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                            selectrow.Update();
                            // --- ADD 2009/03/11 障害ID:12368対応------------------------------------------------------<<<<<
                        }

                        break;
                    }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
        }

        private void PrimeSettingGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (PrimeSettingGrid.Selected.Rows.Count == 0) return;
            if (PrimeSettingGrid.Selected.Rows[0] != PrimeSettingGrid.ActiveRow)
            {
                PrimeSettingGrid.ActiveRow.Selected = true;
            }
        }

        private void PMKEN09014UA_Leave(object sender, EventArgs e)
        {
            // DEL 2008/11/21 不具合対応[8175] ↓表示順がタブを他のタブを選択すると書き換わる
            //_primeSettingController.setMakerDispOrderView();
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// 仕入先コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void PrimeSettingGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            int status;

            if (_supplierAcs == null)
            {
                // インスタンス生成
                _supplierAcs = new SupplierAcs();
            }

            // ガイド起動
            Supplier supplier;
            status = _supplierAcs.ExecuteGuid(out supplier, _primeSettingController.EnterPriseCode, "0");

            if (status != 0) return;

            // 選択した情報をCellに設定
            e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = supplier.SupplierCd;       // 仕入先コード
            e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = supplier.SupplierNm1;    // 仕入先名称

            // 変更フラグ更新
            _primeSettingController.ChangeSupplierCd((int)e.Cell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                                                     (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                                                     (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                                                     supplier.SupplierCd);
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/03 ADD
        # region [グリッド キーマッピング]
        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);
        }
        # endregion

        # region [セル更新時イベント処理]

        /// <summary>
        /// セル更新イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            //int stockRowNo = this._stockDataTable[cell.Row.Index].StockRowNo;            
            //int rowIndex = e.Cell.Row.Index;
            //this._cannotGoodsReaded = false;
            //this._cannotWarehouseReaded = false;
            //this._errstockCount = false;
            //this._errstockUnitPrice = false;
            //this._errsalesOrderUnit = false;
            //this._errmaximumStockCnt = false;

            // 仕入先入力チェック
            //StockExpansion stockExpansion = this._stockInputAcs.StockExpansion;
            //if (stockExpansion == null) return;

            // NULLに対する補正
            if (e.Cell.Value is DBNull)
            {
                // --- CHG 2009/03/10 障害ID:12261,12265対応------------------------------------------------------>>>>>
                //if ((e.Cell.Column.DataType == typeof(Int32)) ||
                //    (e.Cell.Column.DataType == typeof(Int64)))
                //{
                //    e.Cell.Value = 0;
                //}
                //else if (e.Cell.Column.DataType == typeof(double))
                //{
                //    e.Cell.Value = 0.0;
                //}
                this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;       // 仕入先コード
                e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;    // 仕入先名称
                this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                return;
                // --- CHG 2009/03/10 障害ID:12261,12265対応------------------------------------------------------<<<<<
            }

            // ActiveCellが仕入先コードの場合
            if (cell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD)
            {
                int supplierCd = ToInt(cell.Value.ToString());
                int code;
                string name;
                ReadSupplier(supplierCd, out code, out name);

                if (code != 0)
                {
                    // 選択した情報をCellに設定
                    //e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = code;       // 仕入先コード
                    e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = name;    // 仕入先名称
                }
                else
                {
                    // --- ADD 2009/02/19 障害ID:7043対応------------------------------------------------------>>>>>
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                    "PMKEN09014U",
                                    "マスタに登録されていません。",
                                    0,
                                    MessageBoxButtons.OK);
                    // --- ADD 2009/02/19 障害ID:7043対応------------------------------------------------------<<<<<

                    // 選択した情報をCellに設定
                    this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                    e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;       // 仕入先コード
                    e.Cell.Row.Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;    // 仕入先名称
                    this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                    // --- ADD 2009/02/19 障害ID:7043対応------------------------------------------------------>>>>>
                    return;
                    // --- ADD 2009/02/19 障害ID:7043対応------------------------------------------------------<<<<<
                }

                // 変更フラグ更新
                _primeSettingController.ChangeSupplierCd((int)e.Cell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                                                         (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                                                         (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                                                         code);

                // ADD 2008/10/29 不具合対応[6972]---------->>>>>
                // TODO:一括で仕入先を設定
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(
                    (int)e.Cell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value)
                )
                {
                    this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;

                    //int makerCode = int.Parse(MK_BLSettingNavigatorTree.SelectedNodes[0].Key.Substring(0, 4));//DEL BY 凌小青 on 2011/11/22 for Redmine#8033
                    //--------------ADD BY 凌小青 on 2011/11/22 for Redmine#8033 ----------->>>>>>>>>>>>
                    string tempCode = Convert.ToInt32(MK_BLSettingNavigatorTree.SelectedNodes[0].Key.Split(':')[0]).ToString("0000");
                    int makerCode = int.Parse(tempCode.Substring(0, 4));
                    //--------------ADD BY 凌小青 on 2011/11/22 for Redmine#8033 -----------<<<<<<<<<<<<
                    foreach (DataRowView row in _primeSettingController.Mg_Bl_MkView)
                    {
                        if (makerCode == (int)row[PrimeSettingInfo.COL_PARTSMAKERCD])
                        {
                            row[PrimeSettingInfo.COL_SUPPLIERCD] = code;
                            row[PrimeSettingInfo.COL_SUPPLIERNAME] = name;

                            // 変更フラグ更新
                            _primeSettingController.ChangeSupplierCd((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE],
                                                                     (int)row[PrimeSettingInfo.COL_PARTSMAKERCD],
                                                                     (int)row[PrimeSettingInfo.COL_TBSPARTSCODE],
                                                                     code);
                        }
                    }

                    this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                }
                else
                {
                    this.PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                    int makerCode = (int)this.PrimeSettingGrid.Rows[e.Cell.Row.Index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                    int goodsMGroup = (int)this.PrimeSettingGrid.Rows[e.Cell.Row.Index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                    int blGoodsCode = (int)this.PrimeSettingGrid.Rows[e.Cell.Row.Index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                    if (blGoodsCode != 0)
                    {
                        for (int i = 1; i < this.PrimeSettingGrid.Rows.Count; i++)
                        {
                            if ((makerCode == (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                                (goodsMGroup == (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value) &&
                                (blGoodsCode == (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                            {
                                this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = code; // 仕入先コード
                                this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = name; // 仕入先名称
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRowView row in _primeSettingController.Mg_Bl_MkView)
                        {
                            if ((makerCode == (int)row[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
                                (goodsMGroup == (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE]))
                            {
                                row[PrimeSettingInfo.COL_SUPPLIERCD] = code;
                                row[PrimeSettingInfo.COL_SUPPLIERNAME] = name;

                                // 変更フラグ更新
                                _primeSettingController.ChangeSupplierCd((int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE],
                                                                         (int)row[PrimeSettingInfo.COL_PARTSMAKERCD],
                                                                         (int)row[PrimeSettingInfo.COL_TBSPARTSCODE],
                                                                         code);
                            }
                        }
                    }
                    this.PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                }
                // ADD 2008/10/29 不具合対応[6972]----------<<<<<
            }

            // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
            // 表示順の変更 ※2009/01/15 仕様変更：表示順の編集機能は廃止
            if (e.Cell.Column.Key.Equals(PrimeSettingInfo.COL_MAKERDISPORDER))
            {
                Debug.WriteLine("変更された表示順：" + e.Cell.Value.ToString());
                CurrentDataViewRowFilter = _MgBlMkView.RowFilter;
                DefaultDataViewSort = _MgBlMkView.Sort;

                SwapGridRowByMakerDispOrder(e.Cell);

                // 編集可能状態にしたい
                this.PrimeSettingGrid.Focus();
                if (this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                {
                    if (!(this.PrimeSettingGrid.ActiveCell.Value is System.DBNull))
                    {
                        // 全選択状態にする。
                        //this.PrimeSettingGrid.ActiveCell.SelectAll();
                        this.PrimeSettingGrid.ActiveCell.SelStart = 0;
                        this.PrimeSettingGrid.ActiveCell.SelLength = this.PrimeSettingGrid.ActiveCell.Text.Length;

                        this.PrimeSettingGrid.ActiveRow.Selected = true;    // HACK:全選択状態にならないので、仮
                    }
                }

            }
            // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<
        }

        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ---------->>>>>
        // TODO:表示順の制御
        #region <表示順の制御/>

        /// <summary>
        /// 優良設定グリッドのBeforeCellUpdateイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PrimeSettingGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key.Equals(PrimeSettingInfo.COL_MAKERDISPORDER))
            {
                // 変更前の値を保持
                UpdatingMakerDispOrder = (int)e.Cell.Value;
            }
        }

        #region <データビュー/>

        /// <summary>現在のデータビューのフィルタ</summary>
        private string _currentDataViewRowFilter;
        /// <summary>
        /// 現在のデータビューのフィルタのアクセサ
        /// </summary>
        private string CurrentDataViewRowFilter
        {
            get { return _currentDataViewRowFilter; }
            set { _currentDataViewRowFilter = value; }
        }

        /// <summary>データビューのデフォルトソート</summary>
        private string _defaultDataViewSort;
        /// <summary>
        /// データビューのデフォルトソートのアクセサ
        /// </summary>
        /// <value>データビューのデフォルトソート</value>
        private string DefaultDataViewSort
        {
            get
            {
                return PrimeSettingInfo.COL_MAKERDISPORDER + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;
            }
            set { _defaultDataViewSort = value; }   // HACK:仮
        }

        /// <summary>データビューをソート中フラグ</summary>
        private bool _sortingDataView;
        /// <summary>
        /// データビューをソート中フラグのアクセサ
        /// </summary>
        /// <value>データビューをソート中フラグ</value>
        private bool SortingDataView
        {
            get { return _sortingDataView; }
            set { _sortingDataView = value; }
        }

        #endregion  // <データビュー/>

        /// <summary>変更前の表示順</summary>
        private int _updatingMakerDispOrder;
        /// <summary>
        /// 変更前の表示順のアクセサ
        /// </summary>
        /// <value>変更前の表示順</value>
        public int UpdatingMakerDispOrder
        {
            get { return _updatingMakerDispOrder; }
            set { _updatingMakerDispOrder = value; }
        }

        /// <summary>
        /// 選択している優良設定グリッド行を1行上に移動させます。
        /// </summary>
        /// <param name="step">
        /// 移動する相対位置<br/>
        /// ※<c>0</c>を指定すると先頭へ移動します。
        /// </param>
        /// <remarks>
        /// <br>Update Note: 2011/11/19 譚洪</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27453　優良設定マスタ/表示順の保存についての修正</br>
        /// </remarks>
        private void MoveUpGridRow(int step)
        {
            if (this.PrimeSettingGrid.ActiveRow != null)
            {
                if (this.PrimeSettingGrid.ActiveRow.Index.Equals(0)) return;

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //int previousIndex = this.PrimeSettingGrid.ActiveRow.Index - step;
                //if (step.Equals(0))
                //{
                //    previousIndex = 0;
                //}

                //GridRowHelper previousGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[previousIndex]);
                //int swapMakerDispOrder = previousGridRow.MakerDispOrder;

                //GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                //activeGridRow.MakerDispOrder = swapMakerDispOrder;

                //previousGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Selected = true;
                //this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;

                if (step != 0)
                {
                    int previousIndex = this.PrimeSettingGrid.ActiveRow.Index - step;

                    if (previousIndex >= 0)
                    {
                        for (int index = this.PrimeSettingGrid.ActiveRow.Index - 1; index >= 0; index--)
                        {
                            if (this.PrimeSettingGrid.Rows[index].Hidden == false)
                            {
                                previousIndex = index;
                                break;
                            }
                            // ADD 2011/12/15 --- >>>>
                            else
                            {
                                if (index == 0)
                                {
                                    return;
                                }
                            }
                            // ADD 2011/12/15 --- <<<<
                        }

                        GridRowHelper previousGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[previousIndex]);
                        int swapMakerDispOrder = previousGridRow.MakerDispOrder;

                        GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                        previousGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                        activeGridRow.MakerDispOrder = swapMakerDispOrder;

                        previousGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Selected = true;
                        this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                    }
                }
                else
                {
                    GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);

                    for (int rowIndex = PrimeSettingGrid.ActiveRow.Index - 1; rowIndex >= 0; rowIndex--)
                    {
                        if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                        {
                            continue;
                        }

                        GridRowHelper previousGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[rowIndex]);
                        int swapMakerDispOrder = previousGridRow.MakerDispOrder;

                        previousGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                        activeGridRow.MakerDispOrder = swapMakerDispOrder;
                        
                        previousGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Update();
                    }

                    activeGridRow.MyGridRow.Selected = true;
                    this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                }

                // DEL 譚洪 2011/12/19  Redmine#27453 -------- >>>>>>>>>
                //Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
                //for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
                //{
                //    if (PrimeSettingGrid.Rows[index].Hidden == false)
                //    {
                //        int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                //        int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                //        int blCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                //        string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //        if (!makerDispOrderDic.ContainsKey(key))
                //        {
                //            makerDispOrderDic.Add(key, (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value);
                //        }
                //    }
                //}

                //foreach (DataRowView row in this._MgBlMkView)
                //{
                //    int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                //    int goodsMGroup = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                //    int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];

                //    string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //    if (makerDispOrderDic.ContainsKey(key))
                //    {
                //        row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = makerDispOrderDic[key];
                //    }
                //}
                // DEL 譚洪 2011/12/19  Redmine#27453 -------- <<<<<<<

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// 選択している優良設定グリッド行を1行下に移動させます。
        /// </summary>
        /// <param name="step">
        /// 移動する相対位置<br/>
        /// ※<c>0</c>を指定すると末尾へ移動します。
        /// </param>
        /// <remarks>
        /// <br>Update Note: 2011/11/19 譚洪</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27453　優良設定マスタ/表示順の保存についての修正</br>
        /// </remarks>
        private void MoveDownGridRow(int step)
        {
            if (this.PrimeSettingGrid.ActiveRow != null)
            {
                if (this.PrimeSettingGrid.ActiveRow.Index.Equals(this.PrimeSettingGrid.Rows.Count - 1)) return;

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //int nextIndex = this.PrimeSettingGrid.ActiveRow.Index + step;
                //if (step.Equals(0))
                //{
                //    nextIndex = this.PrimeSettingGrid.Rows.Count - 1;
                //}

                //GridRowHelper nextGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[nextIndex]);
                //int swapMakerDispOrder = nextGridRow.MakerDispOrder;

                //GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                //activeGridRow.MakerDispOrder = swapMakerDispOrder;

                //nextGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Update();
                //activeGridRow.MyGridRow.Selected = true;
                //this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;

                if (step != 0)
                {
                    int nextIndex = this.PrimeSettingGrid.ActiveRow.Index + step;

                    if (this.PrimeSettingGrid.Rows.Count > nextIndex)
                    {
                        for (int index = this.PrimeSettingGrid.ActiveRow.Index + 1; index < this.PrimeSettingGrid.Rows.Count; index++)
                        {
                            if (this.PrimeSettingGrid.Rows[index].Hidden == false)
                            {
                                nextIndex = index;
                                break;
                            }
                        }

                        if (this.PrimeSettingGrid.Rows[nextIndex].Hidden == false)
                        {
                            GridRowHelper nextGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[nextIndex]);
                            int swapMakerDispOrder = nextGridRow.MakerDispOrder;

                            GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);
                            nextGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                            activeGridRow.MakerDispOrder = swapMakerDispOrder;

                            nextGridRow.MyGridRow.Update();
                            activeGridRow.MyGridRow.Update();
                            activeGridRow.MyGridRow.Selected = true;
                            this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                        }
                    }
                }
                else
                {
                    GridRowHelper activeGridRow = new GridRowHelper(this.PrimeSettingGrid.ActiveRow);

                    for (int rowIndex = PrimeSettingGrid.ActiveRow.Index + 1; rowIndex < PrimeSettingGrid.Rows.Count; rowIndex++)
                    {
                        if (PrimeSettingGrid.Rows[rowIndex].Hidden == true)
                        {
                            continue;
                        }

                        GridRowHelper nextGridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[rowIndex]);
                        int swapMakerDispOrder = nextGridRow.MakerDispOrder;

                        nextGridRow.MakerDispOrder = activeGridRow.MakerDispOrder;
                        activeGridRow.MakerDispOrder = swapMakerDispOrder;

                        nextGridRow.MyGridRow.Update();
                        activeGridRow.MyGridRow.Update();
                    }

                    activeGridRow.MyGridRow.Selected = true;
                    this.PrimeSettingGrid.ActiveRow = activeGridRow.MyGridRow;
                }

                // DEL 譚洪 2011/12/19 Redmine#27453 -------- >>>>>>>>>
                //Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
                //for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
                //{
                //    if (PrimeSettingGrid.Rows[index].Hidden == false)
                //    {
                //        int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                //        int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                //        int blCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                //        string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //        if (!makerDispOrderDic.ContainsKey(key))
                //        {
                //            makerDispOrderDic.Add(key, (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value);
                //        }
                //    }
                //}

                //foreach (DataRowView row in this._MgBlMkView)
                //{
                //    int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                //    int goodsMGroup = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                //    int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];

                //    string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                //    if (makerDispOrderDic.ContainsKey(key))
                //    {
                //        row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = makerDispOrderDic[key];
                //    }
                //}
                // DEL 譚洪 2011/12/19 Redmine#27453 -------- <<<<<<<<<<

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// 表示順でグリッド行を入れ替えます。
        /// </summary>
        /// <param name="changedCell">変更された表示順セル</param>
        private void SwapGridRowByMakerDispOrder(UltraGridCell changedCell)
        {
            if (SortingDataView) return;

            int changedMiddle   = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
            int changedBL       = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
            int changedMaker    = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
            int changedOrder    = (int)changedCell.Value;

            _MgBlMkView.RowFilter = CurrentDataViewRowFilter;
            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;

            IList<int> previousOrderList = new List<int>();
            int targetIndex = 0;
            for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
            {
                GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                Debug.WriteLine("表示順でソート：" + gridRow.MakerDispOrder.ToString());

                previousOrderList.Add(gridRow.MakerDispOrder);
                if (
                    gridRow.MiddleCode.Equals(changedMiddle)
                        &&
                    gridRow.BLCode.Equals(changedBL)
                        &&
                    gridRow.MakerCode.Equals(changedMaker)
                )
                {
                    targetIndex = idx;
                }
            }

            SortingDataView = true;
            try
            {
                int targetOrder = changedOrder;
                for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
                {
                    if (idx.Equals(targetIndex)) continue;

                    GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                    if (gridRow.MakerDispOrder.Equals(targetOrder))
                    {
                        gridRow.MakerDispOrder = UpdatingMakerDispOrder;
                        gridRow.MyGridRow.Update();
                        break;
                    }
                }
            }
            finally
            {
                SortingDataView = false;
            }

            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;
        }

        /// <summary>
        /// データビューを表示順にソートします。
        /// </summary>
        /// <param name="changedCell">変更された表示順セル</param>
        [Obsolete("SwapGridRowByMakerDispOrder()を使用して下さい。")]
        private void SortDataViewWithInserting(UltraGridCell changedCell)
        {
            if (SortingDataView) return;

            int changedMiddle = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
            int changedBL = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;
            int changedMaker = (int)changedCell.Row.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
            int changedOrder = (int)changedCell.Value;

            _MgBlMkView.RowFilter = CurrentDataViewRowFilter;
            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;

            IList<int> previousOrderList = new List<int>();
            int targetIndex = 0;
            for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
            {
                GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                Debug.WriteLine("表示順でソート：" + gridRow.MakerDispOrder.ToString());

                previousOrderList.Add(gridRow.MakerDispOrder);
                if (
                    gridRow.MiddleCode.Equals(changedMiddle)
                        &&
                    gridRow.BLCode.Equals(changedBL)
                        &&
                    gridRow.MakerCode.Equals(changedMaker)
                )
                {
                    targetIndex = idx;
                }
            }

            SortingDataView = true;
            try
            {
                int targetOrder = changedOrder;
                for (int idx = 0; idx < this.PrimeSettingGrid.Rows.Count; idx++)
                {
                    if (idx.Equals(targetIndex)) continue;

                    GridRowHelper gridRow = new GridRowHelper(this.PrimeSettingGrid.Rows[idx]);
                    if (gridRow.MakerDispOrder.Equals(targetOrder))
                    {
                        gridRow.MakerDispOrder = targetOrder + 1;
                        targetOrder = gridRow.MakerDispOrder;
                        gridRow.MyGridRow.Update();
                    }
                }
            }
            finally
            {
                SortingDataView = false;
            }

            _MgBlMkView.Sort = PrimeSettingInfo.COL_MAKERDISPORDER;
        }

        #endregion  // <表示順の制御/>
        // ADD 2008/11/19 不具合対応[7010] 仕様変更「表示順」の値は任意 ----------<<<<<

        /// <summary>
        /// 仕入先読み込み処理
        /// </summary>
        /// <param name="suppliserCd"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private void ReadSupplier(int supplierCd, out int code, out string name)
        {
            if (supplierCd != 0)
            {
                if (_supplierAcs == null)
                {
                    _supplierAcs = new SupplierAcs();
                }
                Supplier supplier;
                int status = _supplierAcs.Read(out supplier, _primeSettingController.EnterPriseCode, supplierCd);
                if (status == 0)
                {
                    if (supplier.LogicalDeleteCode == 0)
                    {
                        code = supplier.SupplierCd;
                        name = supplier.SupplierNm1;
                    }
                    else
                    {
                        code = 0;
                        name = string.Empty;
                    }
                }
                else
                {
                    code = 0;
                    name = string.Empty;
                }
            }
            else
            {
                code = 0;
                name = string.Empty;
            }
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        private int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.PrimeSettingGrid.BeginUpdate();

                if ((activeCellCheck) && (this.PrimeSettingGrid.ActiveCell != null))
                {
                    if ((!this.PrimeSettingGrid.ActiveCell.Column.Hidden) &&
                        (this.PrimeSettingGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.PrimeSettingGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    performActionResult = this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.PrimeSettingGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.PrimeSettingGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                {
                    this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.PrimeSettingGrid.EndUpdate();
            }

            return performActionResult;
        }
        # endregion

        /// <summary>
        /// パフォームアクション後イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeSettingGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.PrimeSettingGrid.ActiveCell != null) && (this.PrimeSettingGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.PrimeSettingGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.PrimeSettingGrid.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.PrimeSettingGrid.ActiveCell.Value is System.DBNull))
                                        {
                                            // 全選択状態にする。
                                            this.PrimeSettingGrid.ActiveCell.SelStart = 0;
                                            this.PrimeSettingGrid.ActiveCell.SelLength = this.PrimeSettingGrid.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.PrimeSettingGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/03 ADD

        // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示 ---------->>>>>
        /// <summary>
        /// グリッドのAfterSelectChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PrimeSettingGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            UpdateCurrentNote();
        }

        /// <summary>
        /// グリッドのAfterCellActivateイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PrimeSettingGrid_AfterCellActivate(object sender, EventArgs e)
        {
            UpdateCurrentNote();
        }
        // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示 ----------<<<<<

        // ADD 2008/10/29 不具合対応[6969] 仕様変更---------->>>>>
        /// <summary>カラム幅の微調整用幅値</summary>
        private const int DELTA_WHITH = 20;

        ///// <summary>メーカーコードの列幅（自動で幅調整しても微妙に狭いため、固定としておく）</summary>
        //private int MAKER_CODE_COLUMN_WIDTH = 150;

        /// <summary>
        /// 中分類/品目設定ツリー用のグリッドのカラム構成に変化させます。
        /// </summary>
        private void ChangeGridColumnHiddenForMiddleTree()
        {
            //列幅自動調整
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.PrimeSettingGrid.DisplayLayout.Bands[0];

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_MAKERDISPORDER:
                    case PrimeSettingInfo.COL_PARTSMAKERCD:
                    case PrimeSettingInfo.COL_PARTSMAKERFULLNAME:
                    case PrimeSettingInfo.COL_SUPPLIERGUIDE:
                    case PrimeSettingInfo.COL_SUPPLIERCD:
                    case PrimeSettingInfo.COL_SUPPLIERNAME:
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }

            //// TODO:微妙に幅が狭いので微調整
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = MAKER_CODE_COLUMN_WIDTH;
        }

        #region <IPrimeSettingNoteChangedEventHandlerの実装/>

        /// <summary>
        /// 優良設定用備考の値が変化したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        public void PrimeSettingNoteChanged(
            object sender,
            NoteChangedEventArgs e
        )
        {
            // DEL 2008/11/21 不具合対応[8176] ↓仕様変更 選択グリッド列の備考表示
            //this.noteLabel.Text = e.ToString();
        }

        // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示 ---------->>>>>
        /// <summary>
        /// 現在の備考の値を更新します。
        /// </summary>
        private void UpdateCurrentNote()
        {
            try
            {
                if (!this.PrimeSettingGrid.ActiveRow.Activated)
                {
                    this.noteLabel.Text = string.Empty;
                    return;
                }

                NoteChangedEventArgs note = new NoteChangedEventArgs(
                    (int)this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value,
                    (int)this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value,
                    (int)this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value,
                    string.Empty
                );

                this.noteLabel.Text = note.ToString();
            }
            catch (NullReferenceException)
            {
                // アクティブ行がnullの可能性あり
                this.noteLabel.Text = string.Empty;
            }
        }
        // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示 ----------<<<<<

        #endregion  // <IPrimeSettingNoteChangedEventHandlerの実装/>

        #region <メーカー/品目設定/>

        /// <summary>
        /// メーカー/品目設定ツリーの表示
        /// </summary>
        /// <remarks>
        /// コピー元：PMKEN09012UA
        /// </remarks>
        private void SetMK_BLTreeView()
        {
            this.MK_BLSettingNavigatorTree.BeginUpdate();
            this.MK_BLSettingNavigatorTree.Nodes.Clear();
            try
            {
                // 左のツリービューを表示
                // 画面構築処理
                Hashtable Mkht = new Hashtable();
                Hashtable MkBlht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;

                _MgBlMkView.RowFilter = string.Empty;
                // ----- DEL 2011/12/14 -------------------------->>>>>
                //_MgBlMkView.RowFilter = String.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
                //_MgBlMkView.RowFilter = this._primeSettingController.SecretCode;//ADD BY 凌小青 on 2011/11/22 for Redmine#8033
                // ----- DEL 2011/12/14 --------------------------<<<<<
                _MgBlMkView.RowFilter = string.Format("({0} and {1}=1) or ({2}=1 and {3})", "SecretCode=0", PrimeSettingAcs.COL_CHECKSTATE, PrimeSettingAcs.COL_CHECKSTATE, "SecretCode=1"); // ADD 2011/12/14

                _MgBlMkView.Sort = (PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE);

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue;

                    // ViewのチェックステータスがCHECKEDのデータのみ表示
                    if ((CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE] == CheckState.Checked)
                    {
                        if (Mkht[((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")] == null)
                        {
                            Mkht.Add(((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), dr);

                            string makerNodeText = ((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                            node = this.MK_BLSettingNavigatorTree.Nodes.Add(((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d"), makerNodeText);
                        }
                        if ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE] == 0) continue;

                        string skey = ((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                        if (MkBlht[skey] == null)
                        {
                            MkBlht.Add(skey, dr);
                            if (node != null)
                            {
                                if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                                {
                                    string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                    childnode = node.Nodes.Add(skey, ((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                }
                                else
                                {
                                    childnode = node.Nodes.Add(skey, ((int)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                this.MK_BLSettingNavigatorTree.EndUpdate();
            }

            if (MK_BLSettingNavigatorTree.Nodes.Count == 0)
            {
                StringBuilder allFilter = new StringBuilder();
                allFilter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1).Append(ADOUtil.AND).Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(9999999999);
                _MgBlMkView.RowFilter = allFilter.ToString();
            }

            // ADD 2008/11/19 不具合対応[7010]↓ 仕様変更「表示順」の値は任意
            _MgBlMkView.Sort = DefaultDataViewSort;
        }

        /// <summary>
        /// メーカー/品目設定ツリー用のグリッドのカラム構成に変化させます。
        /// </summary>
        private void ChangeGridColumnHiddenForMakerTree()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.PrimeSettingGrid.DisplayLayout.Bands[0];

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                switch (band.Columns[ix].Key)
                {
                    case PrimeSettingInfo.COL_TBSPARTSCODE:
                    case PrimeSettingInfo.COL_TBSPARTSFULLNAME:
                    case PrimeSettingInfo.COL_SUPPLIERGUIDE:
                    case PrimeSettingInfo.COL_SUPPLIERCD:
                    case PrimeSettingInfo.COL_SUPPLIERNAME:
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }
            }
        }

        /// <summary>
        /// メーカー/品目設定ツリーのAfterSelectイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void MK_BLSettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            this.tToolbarsManager1.Tools[TOOL_UP].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools[TOOL_DOWN].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools[TOOL_TOP].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools[TOOL_BOTTOM].SharedProps.Enabled = false;

            // グリッドの列表示
            ChangeGridColumnHiddenForMakerTree();

            // グリッドの行表示
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.MK_BLSettingNavigatorTree.SelectedNodes)
            {
                if (node.Level.Equals(0))    // MEMO:メーカーノード
                {
                    //string rowFilter = string.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key.Substring(0, 4));//DEL BY 凌小青 on 2011/11/22 for Redmine#8033
                     //--------------ADD BY 凌小青 on 2011/11/22 for Redmine#8033 ----------->>>>>>>>>>>>
                    string nodeTemp = Convert.ToInt32(node.Key.Split(':')[0]).ToString("0000");
                    string rowFilter = string.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, nodeTemp);
                    //--------------ADD BY 凌小青 on 2011/11/22 for Redmine#8033 -----------<<<<<<<<<<<<
                    rowFilter += string.Format(" OR {0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, PrimeSettingAcs.COMMON_MAKER_CODE.ToString());

                    _MgBlMkView.RowFilter = rowFilter;
                    _MgBlMkView.RowFilter = string.Format("{0}=1 and ", PrimeSettingAcs.COL_CHECKSTATE) + rowFilter;
                    _MgBlMkView.Sort = PrimeSettingInfo.COL_TBSPARTSCODE;
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                    // 備考を更新
                    this.noteLabel.Text = string.Empty;
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                }
                else // MEMO:品目ノード
                {
                    string rowFilter = string.Format("{0}={1}", PrimeSettingInfo.COL_PARTSMAKERCD, node.Key.Substring(0, 4));
                    rowFilter += string.Format(" and {0}={1}", PrimeSettingInfo.COL_TBSPARTSCODE, node.Key.Substring(4, 8));
                    _MgBlMkView.RowFilter = rowFilter;
                    _MgBlMkView.RowFilter = string.Format("{0}=1 and ", PrimeSettingAcs.COL_CHECKSTATE) + rowFilter;

                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                    int makerCode = int.Parse(node.Key.Substring(0, 4));
                    int blGoodsCode = int.Parse(node.Key.Substring(4, 8));
                    int goodsMGroup = 0;

                    foreach (UltraGridRow gridRow in this.PrimeSettingGrid.Rows)
                    {
                        if ((makerCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value) &&
                            (blGoodsCode == (Int32)gridRow.Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value))
                        {
                            goodsMGroup = (Int32)gridRow.Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                            break;
                        }
                    }

                    NoteChangedEventArgs note = new NoteChangedEventArgs(goodsMGroup, blGoodsCode, makerCode, string.Empty);

                    // 備考を更新
                    this.noteLabel.Text = note.ToString();
                    // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                }
            }

            // 共通レコード以外の「BLコード：0000」のデータが表示されている場合は非表示
            Dictionary<string, int> tempDic = new Dictionary<string, int>();
            for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
            {
                if ((PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Text.Trim() == "0000") &&
                    (PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSFULLNAME].Text.Trim() == ""))
                {
                    PrimeSettingGrid.Rows[index].Hidden = true;
                }

                int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                int blGoodsCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                // 共通レコードは選択ノードが変更される度にクリアする
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(makerCode))
                {
                    PrimeSettingGrid.AfterCellUpdate -= PrimeSettingGrid_AfterCellUpdate;
                    PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value = DBNull.Value;
                    PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_SUPPLIERNAME].Value = DBNull.Value;
                    PrimeSettingGrid.Rows[index].Update();
                    PrimeSettingGrid.AfterCellUpdate += PrimeSettingGrid_AfterCellUpdate;
                }

                string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blGoodsCode.ToString("00000");

                if (!tempDic.ContainsKey(key))
                {
                    tempDic.Add(key, index);
                }
                else
                {
                    PrimeSettingGrid.Rows[index].Hidden = true;
                }
            }

            // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
            //// 備考を更新
            //this.noteLabel.Text = string.Empty; // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示
            // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
        }

        /// <summary>
        /// メーカー/品目設定タブか判定します。
        /// </summary>
        /// <param name="tab">タブ</param>
        /// <returns>
        /// <c>true</c> :メーカー/品目設定タブである。<br/>
        /// <c>false</c>:メーカー/品目設定タブではない。
        /// </returns>
        private static bool IsMakerTab(Infragistics.Win.UltraWinTabControl.UltraTab tab)
        {
            return tab.Key.Equals("TabMK_BL");    // TODO:タブのキーを変更したらここも変更すること
        }

        /// <summary>
        /// 上方向の選択を行います。
        /// </summary>
        /// <param name="tree">対象とするツリー</param>
        private static void SelectUp(Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.SelectedNodes[0] != null)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode node = tree.SelectedNodes[0];
                if (node.PrevVisibleNode != null)
                {
                    if (node.PrevVisibleNode.Level.Equals(1))
                    {
                        node.PrevVisibleNode.Parent.Selected = true;
                    }
                    else
                    {
                        node.PrevVisibleNode.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 下方向の選択を行います。
        /// </summary>
        /// <param name="tree">対象とするツリー</param>
        private static void SelectDown(Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.SelectedNodes[0] != null)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode node = tree.SelectedNodes[0];
                if (node.NextVisibleNode != null)
                {
                    if (node.NextVisibleNode.Level.Equals(1))
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
        }

        /// <summary>
        /// メーカー／品目設定、中分類／品目設定タブのActiveTabChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void makerMiddleTab_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
            // 表示内容をリセット
            ultraDockManager1.ResetControlPanes();
            // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<

            //列幅自動調整
            this.PrimeSettingGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            if (IsMakerTab(e.Tab))
            {
                // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
                if ((MK_BLSettingNavigatorTree.TopNode != null) && (MK_BLSettingNavigatorTree.Nodes.Count > 0))
                {
                    MK_BLSettingNavigatorTree.TopNode.Selected = true;
                    MK_BLSettingNavigatorTree.Nodes[0].Selected = true;
                    MK_BLSettingNavigatorTree_AfterSelect(sender, null);
                }
                // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<

            }
            else
            {
                // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------>>>>>
                if ((SettingNavigatorTree.TopNode != null) && (SettingNavigatorTree.Nodes.Count > 0))
                {
                    SettingNavigatorTree.TopNode.Selected = true;
                    SettingNavigatorTree_AfterSelect(sender, null);
                }
                // --- ADD 2009/03/10 障害ID:12273対応------------------------------------------------------<<<<<

            }
        }

        #endregion  // <メーカー/品目設定/>

        #region <数字入力のチェック/>

        /// <summary>
        /// 中分類/BL/メーカー グリッドのKeyPressイベントハンドラ
        /// </summary>
        /// <remarks>
        /// 数値入力のチェックを行います。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void PrimeSettingGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.PrimeSettingGrid.ActiveCell == null) return;       // ADD 2009/01/30 不具合対応[10403]
            if (!this.PrimeSettingGrid.ActiveCell.IsInEditMode) return; // ADD 2008/11/20 不具合対応[6969]

            Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.PrimeSettingGrid.ActiveCell;
            switch (activeCell.Column.Key)
            {
                // TODO:表示順（1～99）
                case PrimeSettingInfo.COL_MAKERDISPORDER:
                    if (!CheckKeyPressNumber(
                        2,                      // 桁
                        0,                      // 小数点以下桁数
                        activeCell.Text,        // 現在の文字列
                        e.KeyChar,              // 入力されたキー値
                        activeCell.SelStart,    // カーソル位置
                        activeCell.SelLength,   // 選択文字長
                        false                   // マイナス入力可
                    ))// || e.KeyChar.Equals('0'))
                    {
                        e.Handled = true;   // イベントキャンセルする
                    }
                    else
                    {
                        // 1文字目が'0'はNG
                        if (activeCell.SelStart.Equals(0) && e.KeyChar.Equals('0'))
                        {
                            e.Handled = true;
                        }
                    }
                    break;
                // 仕入先コード（000001～999999）
                case PrimeSettingInfo.COL_SUPPLIERCD:
                    if (!CheckKeyPressNumber(
                        6,                      // 桁
                        0,                      // 小数点以下桁数
                        activeCell.Text,        // 現在の文字列
                        e.KeyChar,              // 入力されたキー値
                        activeCell.SelStart,    // カーソル位置
                        activeCell.SelLength,   // 選択文字長
                        false                   // マイナス入力可
                    ))
                    {
                        e.Handled = true;   // イベントキャンセルする
                    }
                    break;
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <remarks>コピー元：MAKHN09280UC.csのKeyPressNumCheck()</remarks>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        public static bool CheckKeyPressNumber(
            int keta,
            int priod,
            string prevVal,
            char key,
            int selstart,
            int sellength,
            Boolean minusFlg
        )
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 1文字目が'.'はNG
            if (string.IsNullOrEmpty(prevVal) && key.Equals('.'))
            {
                return false;
            }

            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion  // <数字入力のチェック/>
        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ----------<<<<<

        // ADD 2008/10/29 不具合対応[6962]---------->>>>>
        #region <IPrimeSettingCheckableの実装/>

        /// <summary>
        /// 保存可能か判定します。
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns><c>true</c> :保存可能<br/><c>false</c>:保存不可能</returns>
        public bool CanSave(out string errorMessage)
        {
            errorMessage = string.Empty;

            UserMakerDispOrderSetting();  // ADD 2011/12/19

            // 共通レコードのみは不可
            if (
                this.PrimeSettingGrid.Rows.Count.Equals(1)
                    &&
                PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(
                    (int)this.PrimeSettingGrid.Rows[0].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value
                )
            )
            {
                return false;
            }


            for (int i = 0; i < this.PrimeSettingGrid.Rows.Count; i++)
            {
                if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(
                    (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value
                ))
                {
                    continue;   // 共通レコードは無視
                }

                if ((int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value == 0)
                {
                    continue;
                }

                try
                {
                    int supplierCode = (int)this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Value;
                    if (supplierCode <= 0 || supplierCode > 999999) // LITERAL:
                    {
                        this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Selected = true;
                        errorMessage = "仕入先コードの値が範囲外です。";    // LITERAL:
                        return false;
                    }
                }
                catch (InvalidCastException e)
                {
                    Debug.WriteLine(e.ToString());

                    this.PrimeSettingGrid.Rows[i].Cells[PrimeSettingInfo.COL_SUPPLIERCD].Selected = true;
                    errorMessage = "仕入先コードが未入力です。";    // LITERAL:
                    return false;
                }
            }

            return true;
        }

        #endregion  // <IPrimeSettingCheckableの実装/>
        // ADD 2008/10/29 不具合対応[6962]----------<<<<<

        // --- ADD 2009/02/19 障害ID:7042対応------------------------------------------------------>>>>>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.PrimeSettingGrid)
            {
                if ((this.PrimeSettingGrid.ActiveCell == null) && (this.PrimeSettingGrid.ActiveRow == null))
                {
                    return;
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        int activeRowIndex;
                        int columnIndex;

                        if (this.PrimeSettingGrid.ActiveCell != null)
                        {
                            activeRowIndex = this.PrimeSettingGrid.ActiveCell.Row.Index;
                            columnIndex = this.PrimeSettingGrid.ActiveCell.Column.Index;
                        }
                        else
                        {
                            e.NextCtrl = null;
                            this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Activate();
                            this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        this.PrimeSettingGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (this.PrimeSettingGrid.ActiveCell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD)
                        {
                            if (this.PrimeSettingGrid.ActiveCell.Value == DBNull.Value)
                            {
                                e.NextCtrl = null;
                                this.PrimeSettingGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }
                            else
                            {
                                if (activeRowIndex == this.PrimeSettingGrid.Rows.Count - 1)
                                {
                                    e.NextCtrl = null;
                                    this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.PrimeSettingGrid.Rows[activeRowIndex + 1].Cells[columnIndex].Activate();
                                    this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (activeRowIndex == this.PrimeSettingGrid.Rows.Count - 1)
                            {
                                e.NextCtrl = null;
                                this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                e.NextCtrl = null;
                                this.PrimeSettingGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }

                        }
                    }
                }
                else
                {
                    int activeRowIndex;
                    int columnIndex;

                    if (this.PrimeSettingGrid.ActiveCell != null)
                    {
                        activeRowIndex = this.PrimeSettingGrid.ActiveCell.Row.Index;
                        columnIndex = this.PrimeSettingGrid.ActiveCell.Column.Index;
                    }
                    else
                    {
                        e.NextCtrl = null;
                        this.PrimeSettingGrid.ActiveRow.Cells[PrimeSettingInfo.COL_SUPPLIERCD].Activate();
                        this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }

                    this.PrimeSettingGrid.PerformAction(UltraGridAction.ExitEditMode);

                    if ((activeRowIndex == 0) &&
                        (this.PrimeSettingGrid.ActiveCell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD))
                    {
                        e.NextCtrl = null;
                        this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        e.NextCtrl = null;
                        this.PrimeSettingGrid.PerformAction(UltraGridAction.PrevCellByTab);
                    }
                }

                
            }
        }

        private void PrimeSettingGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.PrimeSettingGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.PrimeSettingGrid.ActiveCell.Row.Index;
            int colIndex = this.PrimeSettingGrid.ActiveCell.Column.Index;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        if (this.PrimeSettingGrid.ActiveCell.Column.Key == PrimeSettingInfo.COL_SUPPLIERCD)
                        {
                            if (this.PrimeSettingGrid.ActiveCell.IsInEditMode)
                            {
                                if (this.PrimeSettingGrid.ActiveCell.SelStart >= this.PrimeSettingGrid.ActiveCell.Text.Length)
                                {
                                    e.Handled = true;
                                    this.PrimeSettingGrid.Rows[rowIndex].Cells[PrimeSettingInfo.COL_SUPPLIERGUIDE].Activate();
                                    this.PrimeSettingGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        if (this.PrimeSettingGrid.ActiveCell.Column.Key != PrimeSettingInfo.COL_SUPPLIERGUIDE)
                        {
                            return;
                        }

                        PrimeSettingGrid_ClickCellButton(this.PrimeSettingGrid, new CellEventArgs(this.PrimeSettingGrid.ActiveCell));
                        break;
                    }
            }
        }

        // --- ADD 譚洪 2011/12/19 Redmine#27453 -------- >>>>>>>>
        /// <summary>
        /// SettingNavigatorTree の BeforeSelect イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : SettingNavigatorTree の BeforeSelect イベント</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2011/12/19</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分　Redmine#27453　優良設定マスタ/表示順の保存についての修正</br>
        /// </remarks>
        private void SettingNavigatorTree_BeforeSelect(object sender, Infragistics.Win.UltraWinTree.BeforeSelectEventArgs e)
        {
            UserMakerDispOrderSetting();
        }

        /// <summary>
        /// _MgBlMkView 表示順の保存
        /// </summary>
        /// <remarks>
        /// <br>Note       : _MgBlMkView 表示順の保存</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2011/12/19</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分　Redmine#27453　優良設定マスタ/表示順の保存についての修正</br>
        /// </remarks>
        private void UserMakerDispOrderSetting()
        {
            Dictionary<string, int> makerDispOrderDic = new Dictionary<string, int>();
            for (int index = 0; index < PrimeSettingGrid.Rows.Count; index++)
            {
                if (PrimeSettingGrid.Rows[index].Hidden == false)
                {
                    int makerCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_PARTSMAKERCD].Value;
                    int goodsMGroup = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_MIDDLEGENRECODE].Value;
                    int blCode = (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingInfo.COL_TBSPARTSCODE].Value;

                    if (PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value == DBNull.Value)
                    {
                        return;
                    }

                    string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                    if (!makerDispOrderDic.ContainsKey(key))
                    {
                        makerDispOrderDic.Add(key, (int)PrimeSettingGrid.Rows[index].Cells[PrimeSettingAcs.COL_USER_MAKERDISPORDER].Value);
                    }
                }
            }

            string strTemp = _MgBlMkView.Sort;
            _MgBlMkView.Sort = string.Empty; 

            foreach (DataRowView row in this._MgBlMkView)
            {
                int makerCode = (int)row[PrimeSettingInfo.COL_PARTSMAKERCD];
                int goodsMGroup = (int)row[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int blCode = (int)row[PrimeSettingInfo.COL_TBSPARTSCODE];

                string key = makerCode.ToString("0000") + goodsMGroup.ToString("0000") + blCode.ToString("00000");

                if (makerDispOrderDic.ContainsKey(key))
                {
                    row[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = makerDispOrderDic[key];
                }
            }

            _MgBlMkView.Sort = strTemp;
        }
        // --- ADD 譚洪 2011/12/19 Redmine#27453 -------- <<<<<<<<
        // --- ADD 2009/02/19 障害ID:7042対応------------------------------------------------------<<<<<
    }
}