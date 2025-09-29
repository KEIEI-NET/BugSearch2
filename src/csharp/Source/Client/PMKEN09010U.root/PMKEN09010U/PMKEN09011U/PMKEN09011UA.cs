using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTree;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 基本設定画面クラス
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 柴田 倫幸</br>
    /// <br>        	 ・流用/機能追加の為、修正</br>    
    /// <br>UpdateNote : 2009.05.25 20056 對馬 大輔 №12060 設定内容が登録されない</br>
    /// <br>                                        №13148 不正データが登録される</br>
    /// <br>                                        №13374 設定内容が削除されない</br>
    /// <br>                                        №13375 設定内容が表示されない</br>
    /// <br>                                        №13380 ST=5で保存できない</br>
    /// <br>UpdateNote : 2011/06/02 22018 鈴木 正臣</br>
    /// <br>               障害改良対応</br>
    /// <br>               　①種別違いで[表示無]を設定しても、基本設定の中分類/品目タブを選択すると[部品&結合]になってしまう不具合の修正。</br>
    /// <br>               　②基本設定の中分類/品目タブでチェックを付けた時、対象となる明細が不正となる不具合の修正。</br>
    /// <br>-----------------------------------------------------------------------</br>
    /// <br>管理番号              作成担当 : lxl</br>
    /// <br>更 新 日  2011/12/16  修正内容 : Redmine#26847 優良設定マスタ／シークレットモードで三菱ふそうを登録時エラーが出る</br>
    /// <br>-----------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2016/06/29 田建委</br>
    /// <br>管理番号   : 11275163-00</br>
    /// <br>           : Redmine#48793 商品中分類（2階層）をチェックON/OFFの場合、BLコードをフィルター条件に追加する</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKEN09011UA : Form, IPrimeSettingController
    {
        /// <summary>
        /// 基本設定画面クラス コンストラクタ
        /// </summary>
        public PMKEN09011UA()
        {
            InitializeComponent();

        }
        private DataView _MgBlMkView = null;

        # region InterFace
        /// <summary>
        /// 優良設定マスタコントローラ(インターフェースの実装）
        /// </summary>
        //PrimeSettingController _primeSettingController;  // DEL 2008/07/01
        PrimeSettingAcs _primeSettingController;           // ADD 2008/07/01

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
        /// デリゲートイベント（メインから通知）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TabIndex"></param>
        public void MainTabIndexChange(object sender, int TabIndex)
        {
            if (TabIndex == 0)
            {
                secret = _primeSettingController.SecretCode;
                _MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);
                if (viewmode == CHECKED_DISP)
                {
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));  // DEL 2008/07/01
                    setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));           // ADD 2008/07/01
                }
                else
                {
                    setRowFiter(_MgBlMkView, "");
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
            if (TabIndex == 0)
            {
                if (_MgBlMkView == null) return;
                //シークレット解除されたイベント
                if (key == SECRET)
                {
                    switch (ultraTabControl1.TabIndex)
                    {
                        case 0:
                            {
                                //setMK_BLTreeView();  // DEL 2008/07/01

                                // --- ADD 2008/07/01 -------------------------------->>>>>
                                if (sortMode == SORT_CODE)
                                {
                                    setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);  
                                }
                                else
                                {
                                    setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                }
                                // --- ADD 2008/07/01 --------------------------------<<<<< 

                                break;
                            }
                        case 1:
                            {
                                //setMG_BLTreeView();  // DEL 2008/07/01

                                // --- ADD 2008/07/01 -------------------------------->>>>>
                                if (sortMode == SORT_CODE)
                                {
                                    setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD); 
                                }
                                else
                                {
                                    setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                }
                                // --- ADD 2008/07/01 --------------------------------<<<<< 

                                break;
                            }
                    }

                }
            }
        }

        # endregion

        # region Const
        /// <summary>全てチェックON</summary>
        private const string ALL_DISP = "AllDisp";
        /// <summary>全てチェックOFF</summary>
        private const string CHECKED_DISP = "CheckedDisp";
        /// <summary>チェックON</summary>
        private const string CHECK_ON = "CheckOn";
        /// <summary>チェックOFF</summary>
        private const string CHECK_OFF = "CheckOff";

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>コード順</summary>
        private const string SORT_CODE = "SortCode";
        /// <summary>名称順</summary>
        private const string SORT_NAME = "SortName";
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>メーカー品目タブ</summary>
        private const string TABMK_BL = "TabMK_BL";
        /// <summary>シークレットキー</summary>
        private const string SECRET = "Secret";
        
        # endregion

        # region Private Menber
        //表示モード
        string viewmode = ALL_DISP;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        // ソート順
        string sortMode = SORT_CODE;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        string secret = "";
        bool checkeventflg = false;

        bool _firstFlg = true;
        # endregion

        private void setRowFiter(DataView dv, string s)
        {
            if (s == "")
                dv.RowFilter = _primeSettingController.SecretCode;
            else
            {
                if (_primeSettingController.SecretMode == true)
                    dv.RowFilter = _primeSettingController.SecretCode + " AND " + s;
                else
                    dv.RowFilter = s;
            }
        }

        # region Private Method
        private void setMG_BL_MKNodeIcon(ref Infragistics.Win.UltraWinTree.UltraTreeNode node, DataRowView dr)
        {
            // --- DEL 2008/07/01 -------------------------------->>>>>
            //string notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
            //                + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
            //                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // --- ADD 2008/07/01 -------------------------------->>>>>
            string notekey = "";

            if (node.Level == 0)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];  // DEL 2008/07/01
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                          // ADD 2008/07/01

                //switch (primenote.ImportantCode)  // DEL 2008/07/01
                switch (primenote.ImportantNoteCd)  // ADD 2008/07/01
                {
                    case -1:
                    case 0:
                        node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2];
                        break;
                    case 1:
                        node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];
                        break;
                    case 2:
                        node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1];
                        break;
                }
            }

        }
        private void setMKNodeIcon(ref Infragistics.Win.UltraWinTree.UltraTreeNode node, DataRowView dr)
        {
            string notekey = "";

            if (node.Level == 0)
            {
                notekey = ((Int32)0).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if (node.Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if (node.Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];  // DEL 2008/07/01
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                          // ADD 2008/07/01

                node.RightImages.Clear();  // ADD 2008/07/01

                //switch (primenote.ImportantCode)  // DEL 2008/07/01
                switch (primenote.ImportantNoteCd)  // ADD 2008/07/01
                {
                    case -1:
                    case 0:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2];  // DEL 2008/07/01
                        break;
                    case 1:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];  // DEL 2008/07/01
                        break;
                    case 2:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1];  // DEL 2008/07/01
                        break;
                }
            }
        }

        List<object> _partsMakerCode = new List<object>();  //ADD 2011/12/16 lxl Redmine#26874
        /// <summary>
        /// メーカー/品目設定ツリーの表示
        /// </summary> 
        //private void setMK_BLTreeView()              // DEL 2008/07/01
        private void setMK_BLTreeView(string strSort)  // ADD 2008/07/01
        { 
            // 画面構築処理
            MK_BLSettingNavigatorTree.BeginUpdate();
            MK_BLSettingNavigatorTree.Nodes.Clear();
            try
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // イベントハンドラを一時的に外す。
                MK_BLSettingNavigatorTree.AfterCheck -= MK_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<

                Hashtable Mkht = new Hashtable();
                Hashtable MkBlht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;

                // --- ADD 2008/07/01 -------------------------------->>>>>
                Hashtable MgBlMkht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode grandchildnode = null;
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                //この指令でノードのフォーカス枠が消える（チェックボックスの操作とノードの選択の動きが合わないため）
                this.MK_BLSettingNavigatorTree.DrawFilter = new RemoveFocusRectangleDrawFilter();

                if (viewmode == CHECKED_DISP)
                    //                dataview.RowFilter =_primeSettingController.SecretCode +  string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE);
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));  // DEL 2008/07/01
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));           // DEL 2011/12/16 lxl Redmine#26874
                    //ADD 2011/12/16 lxl Redmine#26874----------->>>>>>>>>>>>
                    if (this._primeSettingController.SecretMode)
                        _MgBlMkView.RowFilter = string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE);
                    else
                    {
                        setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));
                    }
                    //ADD 2011/12/16 lxl Redmine#26874-----------<<<<<<<<<<<<
                else
                //setRowFiter(_MgBlMkView, ""); // DEL 2011/12/16 lxl Redmine#26874
                // ADD 2011/12/16 lxl Redmine#26874-------------------------------->>>>>
                {
                    if (this._primeSettingController.SecretMode)
                    {
                        if (_partsMakerCode.Count == 0)
                        {
                            _MgBlMkView.RowFilter = "SecretCode=1 and CheckState=1";    //TbsPartsCode=0
                            foreach (DataRowView row in _MgBlMkView)
                            {
                                if (!_partsMakerCode.Contains(row[PrimeSettingInfo.COL_PARTSMAKERCD]))
                                    _partsMakerCode.Add(row[PrimeSettingInfo.COL_PARTSMAKERCD]);
                            }
                        }
                        _MgBlMkView.RowFilter = "";
                    }
                    else
                    {
                        setRowFiter(_MgBlMkView, "");
                    }
                }
                // ADD 2011/12/16 lxl Redmine#26874--------------------------------<<<<<
                    
                //                dataview.RowFilter = setRowFiter(ref dataview, "");

                //_MgBlMkView.Sort = (PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);  // DEL 2008/07/01
                _MgBlMkView.Sort = (strSort);  // ADD 2008/07/01

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 不具合対応[6969] 仕様変更
                    //ADD 2011/12/16 lxl Redmine#26874----------->>>>>>>>>>>>
                    if (this._primeSettingController.SecretMode && (int)dr[PrimeSettingInfo.COL_SECRETCODE] == 1)
                    {
                        if ((int)dr[PrimeSettingAcs.COL_CHECKSTATE] == 0 && !_partsMakerCode.Contains(dr[PrimeSettingInfo.COL_PARTSMAKERCD]))
                            continue;
                    }
                    //ADD 2011/12/16 lxl Redmine#26874-----------<<<<<<<<<<<<
                    if (Mkht[((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")] == null)
                    {
                        Mkht.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), dr);

                        // DEL 2008/10/28 不具合対応[6966]↓
                        //node = this.MK_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]);
                        // ADD 2008/10/28 不具合対応[6966] メーカーのノードテキストにはコードも表示 ---------->>>>>
                        string makerNodeText = ((int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                        node = this.MK_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"), makerNodeText);
                        // ADD 2008/10/28 不具合対応[6966] メーカーのノードテキストにはコードも表示 ----------<<<<<

                        node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        node.CheckedState = CheckState.Unchecked;
                        setMKNodeIcon(ref node, dr);
                        node.Tag = (object)dr.Row;
                    }

                    // --- ADD 2008/07/01 中分類名追加 -------------------------------->>>>>
                    string skey = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4");

                    if (MkBlht[skey] == null)
                    {
                        MkBlht.Add(skey, dr);

                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_MIDDLEGENRENAME] != System.DBNull.Value)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME];
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ":" + s);
                                childnode.Tag = (object)dr.Row;
                            }
                            else
                            {
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"));
                                childnode.Tag = (object)dr.Row;
                            }
                            childnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            setMKNodeIcon(ref childnode, dr);

                            childnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];

                            if (childnode.CheckedState == CheckState.Checked)
                            {
                                childnode.Parent.CheckedState = CheckState.Checked;
                            }
                        }
                    }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 

                    if ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE] == 0) continue;

                    skey = ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");

                    if (MgBlMkht[skey] == null)
                    {
                        MgBlMkht.Add(skey, dr);

                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != System.DBNull.Value)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                grandchildnode = childnode.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                grandchildnode.Tag = (object)dr.Row;
                            }
                            else
                            {
                                grandchildnode = childnode.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                                grandchildnode.Tag = (object)dr.Row;
                            }
                            grandchildnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            setMKNodeIcon(ref grandchildnode, dr);

                            //childnode.CheckedState = (CheckState)dr[PrimeSettingController.COL_CHECKSTATE];  // DEL 2008/07/01
                            grandchildnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];           // ADD 2008/07/01

                            if (grandchildnode.CheckedState == CheckState.Checked)
                            {
                                grandchildnode.Parent.CheckedState = CheckState.Checked;
                            }

                            //dr[PrimeSettingController.COL_TREENODE] = (object)childnode;
                        }
                    }
                    // --- ADD 2009/03/02 障害ID:12060対応------------------------------------------------------>>>>>
                    else
                    {
                        if (node != null)
                        {
                            if ((CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE] == CheckState.Checked)
                            {
                                grandchildnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];

                                if (grandchildnode.CheckedState == CheckState.Checked)
                                {
                                    grandchildnode.Parent.CheckedState = CheckState.Checked;
                                }
                            }
                        }
                    }
                    // --- ADD 2009/03/02 障害ID:12060対応------------------------------------------------------<<<<<
                }

                // --- ADD 2009/03/12 障害ID:12252対応------------------------------------------------------>>>>>
                // チェックが正しく制御されているか再確認
                foreach (UltraTreeNode nodelevel0 in MK_BLSettingNavigatorTree.Nodes)
                {
                    CheckState state = CheckState.Unchecked;

                    foreach (UltraTreeNode nodelevel1 in nodelevel0.Nodes)
                    {
                        foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                        {
                            if (nodelevel2.CheckedState == CheckState.Checked)
                            {
                                state = CheckState.Checked;
                                break;
                            }
                        }

                        nodelevel1.CheckedState = state;

                        if (state == CheckState.Checked)
                        {
                            break;
                        }
                    }

                    nodelevel0.CheckedState = state;
                }
                // --- ADD 2009/03/12 障害ID:12252対応------------------------------------------------------<<<<<
            }
            finally
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // イベントハンドラを再登録
                MK_BLSettingNavigatorTree.AfterCheck += MK_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<

                MK_BLSettingNavigatorTree.EndUpdate();
            }
        }


        private void setMGNodeIcon(ref Infragistics.Win.UltraWinTree.UltraTreeNode node, DataRowView dr)
        {
            string notekey = "";
            if (node.Level == 0)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (node.Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];  // DEL 2008/07/01
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                          // ADD 2008/07/01

                node.RightImages.Clear();  // ADD 2008/07/01

                //switch (primenote.ImportantCode)  // DEL 2008/07/01
                switch (primenote.ImportantNoteCd)  // ADD 2008/07/01
                {
                    case -1:
                    case 0:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST2];  // DEL 2008/07/01
                        break;
                    case 1:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4];  // DEL 2008/07/01
                        break;
                    case 2:
                        node.RightImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1]);                   // ADD 2008/07/01
                        //node.Override.NodeAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST1];  // DEL 2008/07/01
                        break;
                }
            }
        }

        /// <summary>
        /// 中分類/品目設定ツリーの表示
        /// </summary> 
        //private void setMG_BLTreeView()              // DEL 2008/07/01
        private void setMG_BLTreeView(string strSort)  // ADD 2008/07/01
        {
            // --- UPD m.suzuki 2011/06/02 ---------->>>>>
            //MK_BLSettingNavigatorTree.BeginUpdate();
            MG_BLSettingNavigatorTree.BeginUpdate();
            // --- UPD m.suzuki 2011/06/02 ----------<<<<<
            MG_BLSettingNavigatorTree.Nodes.Clear();
            try
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // イベントハンドラを一時的に外す。
                MG_BLSettingNavigatorTree.AfterCheck -= MG_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<

                Hashtable Mght = new Hashtable();
                Hashtable MgBlht = new Hashtable();
                Hashtable MgBlMkht = new Hashtable();
                Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode childnode = null;
                Infragistics.Win.UltraWinTree.UltraTreeNode grandchildnode = null;
                //この指令でノードのフォーカス枠が消える（チェックボックスの操作とノードの選択の動きが合わないため）
                this.MG_BLSettingNavigatorTree.DrawFilter = new RemoveFocusRectangleDrawFilter();
                if (viewmode == CHECKED_DISP)
                    //setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE));  // DEL 2008/07/01
                    setRowFiter(_MgBlMkView, string.Format("{0}=1", PrimeSettingAcs.COL_CHECKSTATE));           // ADD 2008/07/01 
                //dataview.RowFilter = string.Format("{0}=1", PrimeSettingController.COL_CHECKSTATE);
                else
                    //                dataview.RowFilter = "";
                    setRowFiter(_MgBlMkView, "");

                //_MgBlMkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);  // DEL 2008/07/01
                _MgBlMkView.Sort = (strSort);  // ADD 2008/07/01

                foreach (DataRowView dr in _MgBlMkView)
                {
                    if (PrimeSettingAcs.IsCommonRowOfMiddleGBLMakerDataTable(dr)) continue; // ADD 2008/10/29 不具合対応[6969] 仕様変更

                    if (Mght[((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")] == null)
                    {
                        Mght.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), dr);
                        // DEL 2008/10/28 不具合対応[6966]↓
                        //node = this.MG_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME]);
                        // ADD 2008/10/28 不具合対応[6966] 中分類のノードテキストにはコードも表示 ---------->>>>>
                        string middleGrNodeText = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ":" + (string)dr[PrimeSettingInfo.COL_MIDDLEGENRENAME];
                        node = this.MG_BLSettingNavigatorTree.Nodes.Add(((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4"), middleGrNodeText);
                        // ADD 2008/10/28 不具合対応[6966] 中分類のノードテキストにはコードも表示 ----------<<<<<

                        node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        node.CheckedState = CheckState.Unchecked;
                        setMGNodeIcon(ref node, dr);
                        node.Tag = (object)dr.Row;

                        // dr[PrimeSettingController.COL_TREENODE] = (object)node;
                    }
                    // if ((Int32)dr[PrimeSettingController.COL_TBSPARTSCODE] == 0) continue;

                    string skey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                    
                    if (MgBlht[skey] == null)
                    {
                        MgBlht.Add(skey, dr);
                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] != null)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4") + ":" + s);
                                childnode.Tag = null;// (object)dr;
                            }
                            else
                            {
                                childnode = node.Nodes.Add(skey, ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d4"));
                                childnode.Tag = null;// (object)dr;

                            }
                            childnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            //childnode.CheckedState = (CheckState)dr[PrimeSettingController.COL_CHECKSTATE];  // DEL 2008/07/01
                            childnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];           // ADD 2008/07/01 
                            setMGNodeIcon(ref childnode, dr);
                            childnode.Tag = (object)dr.Row;

                            if (childnode.CheckedState == CheckState.Checked)
                            {
                                childnode.Parent.CheckedState = CheckState.Checked;
                            }
                            // dr[PrimeSettingController.COL_TREENODE] = (object)childnode;

                            // ADD 2009/01/27 仕様変更：中分類のくくりで更新 ---------->>>>>
                            // FIXME:BLコードが0のものがあれば、隠す
                            if (((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                            {
                                childnode.Visible = false;
                            }
                            // ADD 2008/01/27 仕様変更：中分類のくくりで更新 ----------<<<<<
                        }
                    }

                    string skey2 = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                 + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                 + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");

                    if (MgBlMkht[skey2] == null)
                    {
                        MgBlMkht.Add(skey2, dr);
                        if (node != null)
                        {
                            if (dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] != null)
                            {
                                string s = (string)dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
                                grandchildnode = childnode.Nodes.Add(skey2, ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4") + ":" + s);
                                grandchildnode.Tag = (object)dr.Row;
                            }
                            else
                            {
                                grandchildnode = childnode.Nodes.Add(skey2, ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4"));
                                grandchildnode.Tag = (object)dr.Row;
                            }

                            grandchildnode.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            //grandchildnode.CheckedState = (CheckState)dr[PrimeSettingController.COL_CHECKSTATE];  // DEL 2008/07/01
                            grandchildnode.CheckedState = (CheckState)dr[PrimeSettingAcs.COL_CHECKSTATE];           // ADD 2008/07/01
                            
                            if (grandchildnode.CheckedState == CheckState.Checked)
                            {
                                grandchildnode.Parent.CheckedState = CheckState.Checked;
                                grandchildnode.Parent.Parent.CheckedState = CheckState.Checked;
                            }
                            setMGNodeIcon(ref grandchildnode, dr);

                            //  dr[PrimeSettingController.COL_TREENODE] = (object)grandchildnode;
                        }
                    }
                }

                // --- ADD 2009/03/12 障害ID:12252対応------------------------------------------------------>>>>>
                // チェックが正しく制御されているか再確認
                foreach (UltraTreeNode nodelevel0 in MK_BLSettingNavigatorTree.Nodes)
                {
                    CheckState state = CheckState.Unchecked;

                    foreach (UltraTreeNode nodelevel1 in nodelevel0.Nodes)
                    {
                        foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                        {
                            if (nodelevel2.CheckedState == CheckState.Checked)
                            {
                                state = CheckState.Checked;
                                break;
                            }
                        }

                        nodelevel1.CheckedState = state;

                        if (state == CheckState.Checked)
                        {
                            break;
                        }
                    }

                    nodelevel0.CheckedState = state;
                }
                // --- ADD 2009/03/12 障害ID:12252対応------------------------------------------------------<<<<<
            }
            finally
            {
                // --- ADD m.suzuki 2011/06/02 ---------->>>>>
                // イベントハンドラを再登録
                MG_BLSettingNavigatorTree.AfterCheck += MG_BLSettingNavigatorTree_AfterCheck;
                // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                // --- UPD m.suzuki 2011/06/02 ---------->>>>>
                //MK_BLSettingNavigatorTree.EndUpdate();
                MG_BLSettingNavigatorTree.EndUpdate();
                // --- UPD m.suzuki 2011/06/02 ----------<<<<<
            }
        }

        /// <summary>
        /// ツールバーボタン色変更処理
        /// </summary>
        /// <param name="key">対象ボタンKey</param>
        /// <remarks>
        /// <br>Note       : ツールバーのボタン色を更新する</br>
        /// </remarks>
        private void changeToolColor(string key)
        {
            // --- DEL 2008/07/01 -------------------------------->>>>>
            //if (key != ALL_DISP)
            //{
            //    tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
            //    tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
            //    tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            //}
            //if (key != CHECKED_DISP)
            //{
            //    tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
            //    tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
            //    tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
            //}
            //tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
            //tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
            //tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // --- ADD 2008/07/01 -------------------------------->>>>>
            if ((key == ALL_DISP) || (key == CHECKED_DISP))
            {
                // 「全て表示」の色をデフォルトに戻す
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[ALL_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // 「チェック付のみ表示」の色をデフォルトに戻す
                tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[CHECKED_DISP].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // 選択されたボタンの色をオレンジにする
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }

            if ((key == SORT_CODE) || (key == SORT_NAME))
            {
                // 「コード順」の色をデフォルトに戻す
                tToolbarsManager1.Tools[SORT_CODE].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[SORT_CODE].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[SORT_CODE].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // 「名称順」の色をデフォルトに戻す
                tToolbarsManager1.Tools[SORT_NAME].SharedProps.AppearancesSmall.Appearance.BackColor = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor;
                tToolbarsManager1.Tools[SORT_NAME].SharedProps.AppearancesSmall.Appearance.BackColor2 = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackColor2;
                tToolbarsManager1.Tools[SORT_NAME].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = tToolbarsManager1.Tools[CHECK_OFF].SharedProps.AppearancesSmall.Appearance.BackGradientStyle;
                // 選択されたボタンの色をオレンジにする
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor = Color.White;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackColor2 = Color.Orange;
                tToolbarsManager1.Tools[key].SharedProps.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 
        }
        # endregion

        # region Event
        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームを読込む時に発生します。</br>
        /// </remarks>
        private void PMKEN09011U_Load(object sender, EventArgs e)
        {
            // --- ADD 2009/03/10 障害ID:12270対応------------------------------------------------------>>>>>
            // タブスタイル設定
            ultraTabControl1.UseOsThemes = DefaultableBoolean.False;
            ultraTabControl1.Appearance.BackColor = Color.WhiteSmoke;
            ultraTabControl1.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            ultraTabControl1.Appearance.BackGradientStyle = GradientStyle.Vertical;
            ultraTabControl1.ActiveTabAppearance.BackColor = Color.White;
            ultraTabControl1.ActiveTabAppearance.BackColor2 = Color.Pink;
            ultraTabControl1.ActiveTabAppearance.BackGradientStyle = GradientStyle.Vertical;
            ultraTabControl1.Style = UltraTabControlStyle.VisualStudio2005;
            ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // --- ADD 2009/03/10 障害ID:12270対応------------------------------------------------------<<<<<

            this._firstFlg = true;

            changeToolColor(ALL_DISP);
            changeToolColor(SORT_CODE);  // ADD 2008/07/01
            if (_MgBlMkView == null) _MgBlMkView = new DataView(_primeSettingController.Mg_Bl_MkTable);
            secret = _primeSettingController.SecretCode;
            setRowFiter(_MgBlMkView, "");
            //setMK_BLTreeView();        // DEL 2008/07/01
            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);  // ADD 2008/07/01
            _primeSettingController.Copy();
            this._firstFlg = false;
        }

        private void SetDefaultPrimeDisplayCode(int goodsMGroup, int makerCode, int blGoodsCode)
        {
            // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Dictionary<int, int> selectDic = new Dictionary<int, int>();

            //foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            //{
            //    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
            //    {
            //        if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
            //        {
            //            selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
            //                          (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
            //        }
            //        else
            //        {
            //            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
            //            {
            //                selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
            //            }
            //        }
            //    }
            //}

            //bool allZeroFlg = true;
            //int notZeroCode = 0;
            //foreach (int selectCode in selectDic.Keys)
            //{
            //    if (selectDic[selectCode] != 0)
            //    {
            //        allZeroFlg = false;
            //        notZeroCode = selectCode;
            //        break;
            //    }
            //}
            //if (allZeroFlg)
            //{
            //    foreach (int selectCode in selectDic.Keys)
            //    {
            //        notZeroCode = selectCode;
            //        break;
            //    }
            //}

            //int displayOrder = 1;
            //foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            //{
            //    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
            //        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
            //    {
            //        if (notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE])
            //        {
            //            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
            //            {
            //                primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
            //                primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
            //                primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

            //                displayOrder++;
            //            }
            //        }
            //    }
            //}

            Dictionary<string, int> selectKindDic = new Dictionary<string, int>();
            Dictionary<int, int> selectDic = new Dictionary<int, int>();

            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
                {
                    string key = string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]) +
                                 string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]);
                    if (!selectKindDic.ContainsKey(key))
                    {
                        selectKindDic.Add(key, (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                    }
                    else
                    {
                        if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                        {
                            selectKindDic[key] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                        }
                    }

                    if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
                    {
                        selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
                                      (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                    }
                    else
                    {
                        if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                        {
                            selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                        }
                    }

                }
            }

            bool allZeroFlg = true;
            int notZeroCode = 0;
            foreach (int selectCode in selectDic.Keys)
            {
                if (selectDic[selectCode] != 0)
                {
                    allZeroFlg = false;
                    notZeroCode = selectCode;
                    break;
                }
            }
            if (allZeroFlg)
            {
                foreach (int selectCode in selectDic.Keys)
                {
                    notZeroCode = selectCode;
                    break;
                }
            }

            int displayOrder = 1;
            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                    ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == blGoodsCode))
                {
                    string targetKey = string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]) +
                                       string.Format("{0:0000}", (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]);
                    if ((notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]) &&
                        (selectKindDic.ContainsKey(targetKey)))
                    {
                        if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                            primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
                            primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

                            displayOrder++;
                        }
                    }
                }
            }
            // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        private void SetDefaultPrimeDisplayCode(int goodsMGroup, int targetCode, bool makerFlg)
        {
            Dictionary<int, int> selectDic = new Dictionary<int, int>();

            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (makerFlg)
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == targetCode))
                    {
                        if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
                        {
                            selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
                                          (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                        }
                        else
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                            {
                                selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                            }
                        }
                    }
                }
                else
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == targetCode))
                    {
                        if (!selectDic.ContainsKey((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]))
                        {
                            selectDic.Add((int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE],
                                          (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]);
                        }
                        else
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                            {
                                selectDic[(int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]] = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                            }
                        }
                    }
                }
            }

            bool allZeroFlg = true;
            int notZeroCode = 0;
            foreach (int selectCode in selectDic.Keys)
            {
                if (selectDic[selectCode] != 0)
                {
                    allZeroFlg = false;
                    notZeroCode = selectCode;
                    break;
                }
            }
            if (allZeroFlg)
            {
                foreach (int selectCode in selectDic.Keys)
                {
                    notZeroCode = selectCode;
                    break;
                }
            }

            int displayOrder = 1;
            foreach (DataRowView primeSettingRow in _primeSettingController.PrimeSettingView)
            {
                if (makerFlg)
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] == targetCode))
                    {
                        if (notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE])
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                            {
                                primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                                primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
                                primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

                                displayOrder++;
                            }
                        }
                    }
                }
                else
                {
                    if (((int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] == targetCode))
                    {
                        if (notZeroCode == (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE])
                        {
                            if ((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                            {
                                primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                                primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = displayOrder;
                                primeSettingRow[PrimeSettingAcs.COL_CHANGEFLAG] = true;

                                displayOrder++;
                            }
                        }
                    }
                }
            }
        }

        private void MG_BLSettingNavigatorTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (checkeventflg == true) return;
            checkeventflg = true;

            //親のチェックボックス操作は全て子に反映する
            if (e.TreeNode.Level == 0)
            {
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Nodes)
                {
                    nodelevel1.CheckedState = e.TreeNode.CheckedState;

                    //3階層までなので、再帰は使用しない
                    foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                    {
                        nodelevel2.CheckedState = e.TreeNode.CheckedState;
                        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                        DataRow dr = (DataRow)nodelevel2.Tag;
                        int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                        int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                        int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                        foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                        //foreach (DataRowView drv in _MgBlMkView)
                        {
                            if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                                ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                                ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                            {
                                drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                                if (e.TreeNode.CheckedState == CheckState.Unchecked)
                                {
                                    if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                    {
                                        drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                    }
                                }

                                // --- ADD m.suzuki 2011/06/02 ---------->>>>> // MK_BLSettingNavigatorTree_AfterCheckの2009.05.25の変更に相当
                                StringBuilder where = new StringBuilder();
                                where.Append( PrimeSettingInfo.COL_MIDDLEGENRECODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] );
                                where.Append( " AND " );
                                where.Append( PrimeSettingInfo.COL_PARTSMAKERCD ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] );
                                where.Append( " AND " );
                                where.Append( PrimeSettingInfo.COL_TBSPARTSCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] );
                                where.Append( " AND " );
                                where.Append( PrimeSettingInfo.COL_SECRETCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_SECRETCODE] );

                                DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select( where.ToString() );
                                if ( (rows != null) && (rows.Length != 0) )
                                {
                                    foreach ( DataRow row in rows ) row["CheckState"] = e.TreeNode.CheckedState;
                                }
                                // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                            }
                        }

                        // ユーザーデータに存在しないものは初期表示「部品＆結合」セット
                        if (!this._firstFlg)
                        {
                            if (e.TreeNode.CheckedState == CheckState.Checked)
                            {
                                // 優良表示区分初期値セット
                                SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                                // メーカー表示順位初期値セット
                                SetMakerDispOrder(blCode, goodsMGroup);
                            }
                        }
                    }
                }
            }
            //子のチェックボックス操作は子のチェックが全て外れていたら親はOFF。ひとつでもチェックがあれば親はON
            else if (e.TreeNode.Level == 1)
            {
                //3階層までなので、再帰は使用しない
                //子に対しては自分のチェックステータスをセット
                foreach (UltraTreeNode nodelevel2 in e.TreeNode.Nodes)
                {
                    nodelevel2.CheckedState = e.TreeNode.CheckedState;
                    //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                    ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                    DataRow dr = (DataRow)nodelevel2.Tag;
                    int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                    int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                    foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                    //foreach (DataRowView drv in _MgBlMkView)
                    {
                        if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                            ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                        {
                            drv[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)e.TreeNode.CheckedState;

                            if (e.TreeNode.CheckedState == CheckState.Unchecked)
                            {
                                if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                {
                                    drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                }
                            }

                            // --- ADD m.suzuki 2011/06/02 ---------->>>>> // MK_BLSettingNavigatorTree_AfterCheckの2009.05.25の変更に相当
                            StringBuilder where = new StringBuilder();
                            where.Append( PrimeSettingInfo.COL_MIDDLEGENRECODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] );
                            where.Append( " AND " );
                            where.Append( PrimeSettingInfo.COL_PARTSMAKERCD ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] );
                            where.Append( " AND " );
                            where.Append( PrimeSettingInfo.COL_TBSPARTSCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] );
                            where.Append( " AND " );
                            where.Append( PrimeSettingInfo.COL_SECRETCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_SECRETCODE] );

                            DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select( where.ToString() );
                            if ( (rows != null) && (rows.Length != 0) )
                            {
                                foreach ( DataRow row in rows ) row["CheckState"] = e.TreeNode.CheckedState;
                            }
                            // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                        }
                    }

                    // ユーザーデータに存在しないものは初期表示「部品＆結合」セット
                    if (!this._firstFlg)
                    {
                        if (e.TreeNode.CheckedState == CheckState.Checked)
                        {
                            // 優良表示区分初期値セット
                            SetDefaultPrimeDisplayCode(goodsMGroup, blCode, false);

                            // メーカー表示順位初期値セット
                            SetMakerDispOrder(blCode, goodsMGroup);
                        }
                    }
                }
                //同一階層のノードが全てチェックOFFの場合その親（Level0）もOFFとなる
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                e.TreeNode.Parent.CheckedState = cs;

            }
            //子のチェックボックス操作は子のチェックが全て外れていたら親はOFF。ひとつでもチェックがあれば親はON
            else if (e.TreeNode.Level == 2)
            {
                //((DataRow)e.TreeNode.Tag)[PrimeSettingController.COL_CHECKSTATE] = e.TreeNode.CheckedState;  // DEL 2008/07/01
                ((DataRow)e.TreeNode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;           // ADD 2008/07/01

                DataRow dr = (DataRow)e.TreeNode.Tag;
                int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                //foreach (DataRowView drv in _MgBlMkView)
                {
                    if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                        ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                    {
                        drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                        if (e.TreeNode.CheckedState == CheckState.Unchecked)
                        {
                            if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                            {
                                drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                            }
                        }

                        // --- ADD m.suzuki 2011/06/02 ---------->>>>> // MK_BLSettingNavigatorTree_AfterCheckの2009.05.25の変更に相当
                        StringBuilder where = new StringBuilder();
                        where.Append( PrimeSettingInfo.COL_MIDDLEGENRECODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] );
                        where.Append( " AND " );
                        where.Append( PrimeSettingInfo.COL_PARTSMAKERCD ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] );
                        where.Append( " AND " );
                        where.Append( PrimeSettingInfo.COL_TBSPARTSCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] );
                        where.Append( " AND " );
                        where.Append( PrimeSettingInfo.COL_SECRETCODE ).Append( "=" ).Append( (int)drv[PrimeSettingInfo.COL_SECRETCODE] );

                        DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select( where.ToString() );
                        if ( (rows != null) && (rows.Length != 0) )
                        {
                            foreach ( DataRow row in rows ) row["CheckState"] = e.TreeNode.CheckedState;
                        }
                        // --- ADD m.suzuki 2011/06/02 ----------<<<<<
                    }
                }

                // ユーザーデータに存在しないものは初期表示「部品＆結合」セット
                if (!this._firstFlg)
                {
                    if (e.TreeNode.CheckedState == CheckState.Checked)
                    {
                        // 優良表示区分初期値セット
                        SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                        // メーカー表示順位初期値セット
                        SetMakerDispOrder(blCode, goodsMGroup);
                    }
                }

                //Level1の階層をチェック
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                //ひとつでもチェックがあればチェックON
                e.TreeNode.Parent.CheckedState = cs;

                if (cs == CheckState.Unchecked)
                {
                    foreach (UltraTreeNode nodelevel0 in e.TreeNode.Parent.Parent.Nodes)
                    {
                        if (nodelevel0.CheckedState == CheckState.Checked)
                        {
                            cs = CheckState.Checked;
                        }
                    }
                    e.TreeNode.Parent.Parent.CheckedState = cs;
                }
                else
                {
                    e.TreeNode.Parent.Parent.CheckedState = CheckState.Checked;
                }
            }
            checkeventflg = false;
        }

        /// <summary>
        /// メーカー/品目設定タブで項目チェックのイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote : 2016/06/29 田建委</br>
        /// <br>管理番号   : 11275163-00</br>
        /// <br>           : Redmine#48793 商品中分類（2階層）をチェックON/OFFの場合、BLコードをフィルター条件に追加する</br>
        /// </remarks>
        private void MK_BLSettingNavigatorTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (checkeventflg == true) return;
            checkeventflg = true;

            //親のチェックボックス操作は全て子に反映する
            if (e.TreeNode.Level == 0)
            {
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Nodes)
                {
                    nodelevel1.CheckedState = e.TreeNode.CheckedState;
                    //3階層までなので、再帰は使用しない
                    foreach (UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                    {
                        nodelevel2.CheckedState = e.TreeNode.CheckedState;
                        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                        DataRow dr = (DataRow)nodelevel2.Tag;
                        int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                        int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                        int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                        foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                        //foreach (DataRowView drv in _MgBlMkView)
                        {
                            if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                                ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                                ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                            {
                                drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                                if (e.TreeNode.CheckedState == CheckState.Unchecked)
                                {
                                    if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                    {
                                        drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                    }
                                }

                                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                StringBuilder where = new StringBuilder();
                                where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE]);
                                where.Append(" AND ");
                                where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD]);
                                where.Append(" AND ");
                                where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE]);
                                where.Append(" AND ");
                                where.Append(PrimeSettingInfo.COL_SECRETCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_SECRETCODE]);

                                DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select(where.ToString());
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    foreach (DataRow row in rows) row["CheckState"] = e.TreeNode.CheckedState;
                                }
                                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            }
                        }

                        // ユーザーデータに存在しないものは初期表示「部品＆結合」セット
                        if (!this._firstFlg)
                        {
                            if (e.TreeNode.CheckedState == CheckState.Checked)
                            {
                                // 優良表示区分初期値セット
                                SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                                // メーカー表示順位初期値セット
                                SetMakerDispOrder(blCode, goodsMGroup);
                            }
                        }
                    }
                }
            }
            //子のチェックボックス操作は子のチェックが全て外れていたら親はOFF。ひとつでもチェックがあれば親はON
            else if (e.TreeNode.Level == 1)
            {
                //3階層までなので、再帰は使用しない
                //子に対しては自分のチェックステータスをセット
                foreach (UltraTreeNode nodelevel2 in e.TreeNode.Nodes)
                {
                    nodelevel2.CheckedState = e.TreeNode.CheckedState;
                    //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;  // DEL 2008/07/01
                    ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)nodelevel2.CheckedState;           // ADD 2008/07/01

                    DataRow dr = (DataRow)nodelevel2.Tag;
                    int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                    int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                    int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                    foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                    //foreach (DataRowView drv in _MgBlMkView)
                    {
                        if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                            ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode) && // ADD 2016/06/29 田建委 Redmine#48793 BLコードをフィルター条件に追加する
                            ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode))
                        {
                            drv[PrimeSettingAcs.COL_CHECKSTATE] = (CheckState)e.TreeNode.CheckedState;

                            if (e.TreeNode.CheckedState == CheckState.Unchecked)
                            {
                                if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                                {
                                    drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                                }
                            }

                            // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            StringBuilder where = new StringBuilder();
                            where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE]);
                            where.Append(" AND ");
                            where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD]);
                            where.Append(" AND ");
                            where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE]);
                            where.Append(" AND ");
                            where.Append(PrimeSettingInfo.COL_SECRETCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_SECRETCODE]);
                            DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select(where.ToString());
                            if ((rows != null) && (rows.Length != 0))
                            {
                                foreach (DataRow row in rows) row["CheckState"] = e.TreeNode.CheckedState;
                            }
                            // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }

                    // ユーザーデータに存在しないものは初期表示「部品＆結合」セット
                    if (!this._firstFlg)
                    {
                        if (e.TreeNode.CheckedState == CheckState.Checked)
                        {
                            // 優良表示区分初期値セット
                            SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, true);

                            // メーカー表示順位初期値セット
                            SetMakerDispOrder(blCode, goodsMGroup);
                        }
                    }
                }
                //同一階層のノードが全てチェックOFFの場合その親（Level0）もOFFとなる
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                e.TreeNode.Parent.CheckedState = cs;
            }
            //子のチェックボックス操作は子のチェックが全て外れていたら親はOFF。ひとつでもチェックがあれば親はON
            else if (e.TreeNode.Level == 2)
            {
                //((DataRow)e.TreeNode.Tag)[PrimeSettingController.COL_CHECKSTATE] = e.TreeNode.CheckedState;  // DEL 2008/07/01
                ((DataRow)e.TreeNode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;           // ADD 2008/07/01

                DataRow dr = (DataRow)e.TreeNode.Tag;
                int goodsMGroup = (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode = (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blCode = (int)dr[PrimeSettingInfo.COL_TBSPARTSCODE];

                foreach (DataRowView drv in _primeSettingController.PrimeSettingView)
                //foreach (DataRowView drv in _MgBlMkView)
                {
                    if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                        ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == makerCode) &&
                        ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == blCode))
                    {
                        drv[PrimeSettingAcs.COL_CHECKSTATE] = e.TreeNode.CheckedState;

                        if (e.TreeNode.CheckedState == CheckState.Unchecked)
                        {
                            if ((CheckState)drv[PrimeSettingAcs.COL_ORIGINAL_CHECKSTATE] == CheckState.Unchecked)
                            {
                                drv[PrimeSettingAcs.COL_CHANGEFLAG] = false;
                            }
                        }

                        // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        StringBuilder where = new StringBuilder();
                        where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE]);
                        where.Append(" AND ");
                        where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD]);
                        where.Append(" AND ");
                        where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE]);
                        where.Append(" AND ");
                        where.Append(PrimeSettingInfo.COL_SECRETCODE).Append("=").Append((int)drv[PrimeSettingInfo.COL_SECRETCODE]);

                        DataRow[] rows = this._primeSettingController.Mg_Bl_MkTable.Select(where.ToString());
                        if ((rows != null) && (rows.Length != 0))
                        {
                            foreach (DataRow row in rows) row["CheckState"] = e.TreeNode.CheckedState;
                        }
                        // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }

                // ユーザーデータに存在しないものは初期表示「部品＆結合」セット
                if (!this._firstFlg)
                {
                    if (e.TreeNode.CheckedState == CheckState.Checked)
                    {
                        // 優良表示区分初期値セット
                        SetDefaultPrimeDisplayCode(goodsMGroup, makerCode, blCode);

                        // メーカー表示順位初期値セット
                        SetMakerDispOrder(blCode, goodsMGroup);
                    }
                }

                //Level1の階層をチェック
                CheckState cs = CheckState.Unchecked;
                foreach (UltraTreeNode nodelevel1 in e.TreeNode.Parent.Nodes)
                {
                    if (nodelevel1.CheckedState == CheckState.Checked)
                    {
                        cs = CheckState.Checked;
                    }
                }
                //ひとつでもチェックがあればチェックON
                e.TreeNode.Parent.CheckedState = cs;

                if (cs == CheckState.Unchecked)
                {
                    foreach (UltraTreeNode nodelevel0 in e.TreeNode.Parent.Parent.Nodes)
                    {
                        if (nodelevel0.CheckedState == CheckState.Checked)
                        {
                            cs = CheckState.Checked;
                        }
                    }
                    e.TreeNode.Parent.Parent.CheckedState = cs;

                }
                else
                {
                    e.TreeNode.Parent.Parent.CheckedState = CheckState.Checked;
                }
            }
            checkeventflg = false;
        }

        private void SetMakerDispOrder(int blGoodsCode, int goodsMGroup)
        {
            StringBuilder filter = new StringBuilder();
            {
                filter.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.EQ).Append(blGoodsCode).Append(ADOUtil.AND);
                filter.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(goodsMGroup).Append(ADOUtil.AND);
                filter.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
            }

            _MgBlMkView.RowFilter = filter.ToString();
            _MgBlMkView.Sort = PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE;

            Dictionary<int, int> indexDic = new Dictionary<int, int>();
            foreach (DataRowView primeSettingRow in _MgBlMkView)
            {
                if (!indexDic.ContainsKey((int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER]))
                {
                    indexDic.Add((int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER], (int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER]);
                }
            }

            int order = 0;
            int makerCode = -1;
            foreach (DataRowView primeSettingRow in _MgBlMkView)
            {
                if (makerCode != (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD])
                {
                    if ((int)primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER] != 0)
                    {
                        continue;
                    }

                    for (int index = order + 1; index > 0; index++)
                    {
                        if (indexDic.ContainsKey(index))
                        {
                            continue;
                        }
                        order = index;
                        break;
                    }
                    primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                    makerCode = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                }
                else
                {
                    primeSettingRow[PrimeSettingAcs.COL_USER_MAKERDISPORDER] = order;
                }
            }

            _MgBlMkView.RowFilter = "";
        }

        /// <summary>
        /// ツールバーボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 選択されたボタンによりツリー状態を更新する</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (checkeventflg == true) return;
            checkeventflg = true;
            try
            {
                Infragistics.Win.UltraWinTree.UltraTree ut = null;
                if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                {
                    ut = MK_BLSettingNavigatorTree;
                }
                else
                {
                    ut = MG_BLSettingNavigatorTree;
                }

                switch (e.Tool.Key)
                {
                    //--------------------------------------------------------------
                    // チェックONボタン
                    //--------------------------------------------------------------
                    case CHECK_ON:
                        {
                            //チェックON
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode selectnode in ut.SelectedNodes)
                            {
                                selectnode.CheckedState = CheckState.Checked;

                                // --- CHG 2009/03/11 障害ID:12340対応------------------------------------------------------>>>>>
                                ////親のチェックボックス操作は全て子に反映する
                                //if (selectnode.Level == 0)
                                //{
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Nodes)
                                //    {
                                //        nodelevel1.CheckedState = CheckState.Checked;
                                //        if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //        {
                                //            //((DataRow)nodelevel1.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel1.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01
                                //        }
                                //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                                //        {
                                //            nodelevel2.CheckedState = CheckState.Checked;
                                //            //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01 
                                //        }
                                //    }
                                //}
                                //else if (selectnode.Level == 1)
                                //{
                                //    if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //    {
                                //        //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //        ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01
                                //    }
                                //    selectnode.Parent.CheckedState = CheckState.Checked;
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in selectnode.Nodes)
                                //    {
                                //        nodelevel2.CheckedState = CheckState.Checked;
                                //        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01
                                //    }
                                //}
                                //else if (selectnode.Level == 2)
                                //{
                                //    //((DataRow)selectnode.Parent.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;
                                //    selectnode.Parent.CheckedState = CheckState.Checked;
                                //    selectnode.Parent.Parent.CheckedState = CheckState.Checked;
                                //    //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Checked;  // DEL 2008/07/01
                                //    ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Checked;           // ADD 2008/07/01 
                                //}

                                checkeventflg = false;
                                if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                {
                                    MK_BLSettingNavigatorTree_AfterCheck(MK_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                else
                                {
                                    MG_BLSettingNavigatorTree_AfterCheck(MG_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                // --- CHG 2009/03/11 障害ID:12340対応------------------------------------------------------<<<<<
                            }
                            break;
                        }
                    //--------------------------------------------------------------
                    // チェックOFFボタン
                    //--------------------------------------------------------------
                    case CHECK_OFF:
                        {
                            // チェックOFF
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode selectnode in ut.SelectedNodes)
                            {
                                selectnode.CheckedState = CheckState.Unchecked;
                                
                                // --- CHG 2009/03/11 障害ID:12340対応------------------------------------------------------>>>>>
                                ////親のチェックボックス操作は全て子に反映する
                                //if (selectnode.Level == 0)
                                //{
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Nodes)
                                //    {
                                //        nodelevel1.CheckedState = CheckState.Unchecked;
                                //        if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //        {
                                //            //((DataRow)nodelevel1.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel1.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01 

                                //        }
                                //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in nodelevel1.Nodes)
                                //        {
                                //            nodelevel2.CheckedState = CheckState.Unchecked;
                                //            //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //            ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01
                                //        }
                                //    }
                                //}

                                //else if (selectnode.Level == 1)
                                //{
                                //    if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                //    {
                                //        //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //        ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01
                                //    }
                                //    //子に対しては自分のチェックステータスをセット
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in selectnode.Nodes)
                                //    {
                                //        nodelevel2.CheckedState = CheckState.Unchecked;
                                //        //((DataRow)nodelevel2.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //        ((DataRow)nodelevel2.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01
                                //    }

                                //    CheckState cs = CheckState.Unchecked;
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Parent.Nodes)
                                //    {
                                //        if (nodelevel1.CheckedState == CheckState.Checked)
                                //        {
                                //            cs = CheckState.Checked;
                                //        }
                                //    }
                                //    selectnode.Parent.CheckedState = cs;
                                //}
                                //else if (selectnode.Level == 2)
                                //{
                                //    //((DataRow)selectnode.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;  // DEL 2008/07/01
                                //    ((DataRow)selectnode.Tag)[PrimeSettingAcs.COL_CHECKSTATE] = CheckState.Unchecked;           // ADD 2008/07/01

                                //    //                                ((DataRow)utn.Tag)[PrimeSettingController.COL_CHECKSTATE] = CheckState.Unchecked;
                                //    //Level1の階層をチェック
                                //    CheckState cs = CheckState.Unchecked;
                                //    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel2 in selectnode.Parent.Nodes)
                                //    {
                                //        if (nodelevel2.CheckedState == CheckState.Checked)
                                //        {
                                //            cs = CheckState.Checked;
                                //        }
                                //    }
                                //    //ひとつでもチェックがあればチェックON
                                //    // ((DataRow)selectnode.Parent.Tag)[PrimeSettingController.COL_CHECKSTATE] = cs;
                                //    selectnode.Parent.CheckedState = cs;

                                //    //全てチェックがOFFの場合さらに親もチェック
                                //    if (cs == CheckState.Unchecked)
                                //    {
                                //        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodelevel1 in selectnode.Parent.Parent.Nodes)
                                //        {
                                //            if (nodelevel1.CheckedState == CheckState.Checked)
                                //            {
                                //                cs = CheckState.Checked;
                                //            }
                                //        }
                                //        // ((DataRow)e.TreeNode.Parent.Parent.Tag)[PrimeSettingController.COL_CHECKSTATE] = cs;
                                //        selectnode.Parent.Parent.CheckedState = cs;
                                //    }
                                //    else
                                //    {
                                //        selectnode.Parent.Parent.CheckedState = CheckState.Checked;
                                //    }
                                //}
                                
                                checkeventflg = false;
                                if (ultraTabControl1.SelectedTab.Key == TABMK_BL)
                                {
                                    MK_BLSettingNavigatorTree_AfterCheck(MK_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                else
                                {
                                    MG_BLSettingNavigatorTree_AfterCheck(MG_BLSettingNavigatorTree, new Infragistics.Win.UltraWinTree.NodeEventArgs(selectnode));
                                }
                                // --- CHG 2009/03/11 障害ID:12340対応------------------------------------------------------<<<<<
                            }
                            break;
                        }
                    //--------------------------------------------------------------
                    // 全て表示ボタン
                    //--------------------------------------------------------------
                    case ALL_DISP:
                        {
                            if (viewmode == ALL_DISP) return;
                            //                        setRowFiter(ref dataview,"");
                            //                        dataview.RowFilter = "";
                            changeToolColor(e.Tool.Key);
                            viewmode = ALL_DISP;
                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // メーカー/品目設定
                                    {
                                        //setMK_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // メーカー/品目設定ツリー更新(コード順)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        }
                                        else
                                        {
                                            // メーカー/品目設定ツリー更新(名称順)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                                        break;
                                    }
                                case 1:  // 中分類/品目設定
                                    {
                                        //setMG_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // 中分類/品目設定ツリー更新(コード順)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD); 
                                        }
                                        else
                                        {
                                            // 中分類/品目設定ツリー更新(名称順)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                                        break;
                                    }
                            }

                            break;
                        }
                    //--------------------------------------------------------------
                    // チェックのみ表示ボタン
                    //--------------------------------------------------------------
                    case CHECKED_DISP:
                        {
                            if (viewmode == CHECKED_DISP) return;
                            changeToolColor(e.Tool.Key);
                            viewmode = CHECKED_DISP;
                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // メーカー/品目設定
                                    {
                                        //setMK_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // メーカー/品目設定ツリー更新(コード順)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
                                        }
                                        else
                                        {
                                            // メーカー/品目設定ツリー更新(名称順)
                                            setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                                        break;
                                    }
                                case 1:  // 中分類/品目設定
                                    {
                                        //setMG_BLTreeView();  // DEL 2008/07/01

                                        // --- ADD 2008/07/01 -------------------------------->>>>>
                                        if (sortMode == SORT_CODE)
                                        {
                                            // 中分類/品目設定ツリー更新(コード順)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);
                                        }
                                        else
                                        {
                                            // 中分類/品目設定ツリー更新(名称順)
                                            setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                        }
                                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                                            
                                        break;
                                    }
                            }

                            break;
                        }
                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    //--------------------------------------------------------------
                    // コード順
                    //--------------------------------------------------------------
                    case SORT_CODE:
                        {
                            if (sortMode == SORT_CODE) return;

                            changeToolColor(e.Tool.Key);
                            sortMode = SORT_CODE;

                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // メーカー/品目設定
                                    {
                                        // メーカー/品目設定ツリー更新
                                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
                                        
                                        break;
                                    }
                                case 1:  // 中分類/品目設定
                                    {
                                        // 中分類/品目設定ツリー更新
                                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);  // ADD 2008/07/01
                                        
                                        break;
                                    }
                            }

                            break;
                        }
                    //--------------------------------------------------------------
                    // 名称順
                    //--------------------------------------------------------------
                    case SORT_NAME:
                        {
                            if (sortMode == SORT_NAME) return;

                            changeToolColor(e.Tool.Key);
                            sortMode = SORT_NAME;

                            switch (ultraTabControl1.SelectedTab.Index)
                            {
                                case 0:  // メーカー/品目設定
                                    {
                                        // メーカー/品目設定ツリー更新
                                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                                        
                                        break;
                                    }
                                case 1:  // 中分類/品目設定
                                    {
                                        // 中分類/品目設定ツリー更新
                                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                                        
                                        break;
                                    }
                            }

                            break;
                        }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 
                }
            }
            finally
            {
                checkeventflg = false;
            }
        }

        /// <summary>
        /// タブ変更時処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 選択されたタブによりツリー状態を更新する</br>
        /// </remarks>
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (_MgBlMkView == null) return;

            _primeSettingController.NavigeteIndex = e.Tab.Index;
            switch (e.Tab.Index)
            {
                case 0:  // メーカー/品目設定
                {
                    //setMK_BLTreeView();  // DEL 2008/07/01

                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    if (sortMode == SORT_CODE)
                    {
                        // コード順
                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
                    }
                    else
                    {
                        // 名称順
                        setMK_BLTreeView(PrimeSettingInfo.COL_PARTSMAKERFULLNAME + "," + PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_MAKERDISPORDER); 
                    }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 

                    break;
                }
                case 1:  // 中分類/品目設定
                {
                    //setMG_BLTreeView();  // DEL 2008/07/01

                    // --- ADD 2008/07/01 -------------------------------->>>>>
                    if (sortMode == SORT_CODE)
                    {
                        // コード順
                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD); 
                    }
                    else
                    {
                        // 名称順
                        setMG_BLTreeView(PrimeSettingInfo.COL_MIDDLEGENRENAME + "," + PrimeSettingInfo.COL_TBSPARTSFULLNAME + "," + PrimeSettingInfo.COL_PARTSMAKERFULLNAME);
                    }
                    // --- ADD 2008/07/01 --------------------------------<<<<< 

                    break;
                }
            }
        }

        private void PMKEN09011UA_Leave(object sender, EventArgs e)
        {
            // DEL 2008/11/21 不具合対応[8175] ↓表示順がタブを他のタブを選択すると書き換わる
            //_primeSettingController.setMakerDispOrderView();
        }
        # endregion

        private void MK_BLSettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (e.NewSelections.Count != 1) return;
            string notekey = "";
            DataRow dr = (DataRow)e.NewSelections[0].Tag;

            // --- DEL 2008/07/01 -------------------------------->>>>>
            //if (e.NewSelections[0].Level == 0)
            //{
            //    notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
            //    + ((Int32)0).ToString("d8")
            //    + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            //}
            //else
            //{
            //    notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
            //    + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
            //    + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            //}
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // --- ADD 2008/07/01 -------------------------------->>>>>
            if (e.NewSelections[0].Level == 0)
            {
                notekey = ((Int32)0).ToString("d4")
                + ((Int32)0).ToString("d8")
                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if(e.NewSelections[0].Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                + ((Int32)0).ToString("d8")
                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }
            else if (e.NewSelections[0].Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")  // MEMO:中分類コード
                + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")             // MEMO:BLコード
                + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");            // MEMO:メーカーコード
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            // TODO:優良設定備考を設定
            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                // --- DEL 2008/07/01 -------------------------------->>>>>
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey]; 
                //string s = primenote.OfferPrimeNote;  
                //this.MK_BLBrowser.DocumentText = s;         
                // --- DEL 2008/07/01 --------------------------------<<<<< 

                // --- ADD 2008/07/01 -------------------------------->>>>>
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                        
                string s = primenote.PrmSetNote;        
                MK_BLLabel.Text = s.Replace("<br>", "\r\n");
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            else
            {
                //this.MK_BLBrowser.DocumentText = "";  // DEL 2008/07/01
                MK_BLLabel.Text = "";                   // ADD 2008/07/01
            }
        }

        private void MG_BLSettingNavigatorTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (e.NewSelections.Count != 1) return;
            string notekey = "";

            DataRow dr = (DataRow)e.NewSelections[0].Tag;
            if (e.NewSelections[0].Level == 0)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)0).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }
            else if (e.NewSelections[0].Level == 1)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)0).ToString("d4");
            }

            else if (e.NewSelections[0].Level == 2)
            {
                notekey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                        + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                        + ((Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4");
            }

            if (_primeSettingController.OfferPrimeSettingNote[notekey] != null)
            {
                // --- DEL 2008/07/01 -------------------------------->>>>>
                //OfferPrimeSettingNoteWork primenote = (OfferPrimeSettingNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];
                //string s = primenote.OfferPrimeNote;  
                //this.MG_BLBrowser.DocumentText = s;         
                // --- DEL 2008/07/01 --------------------------------<<<<< 

                // --- ADD 2008/07/01 -------------------------------->>>>>
                PrmSetNoteWork primenote = (PrmSetNoteWork)_primeSettingController.OfferPrimeSettingNote[notekey];                
                string s = primenote.PrmSetNote;        
                MG_BLLabel.Text = s.Replace("<br>", "\r\n");
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            else
            {
                //this.MG_BLBrowser.DocumentText. = "";
                MG_BLLabel.Text = "";  // ADD 2008/07/01
            }
        }
    }
}