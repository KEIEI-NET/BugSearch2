//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 梁森東
// 作 成 日  2011/07/13  修正内容 : 連番No.2 新規作成                      
//----------------------------------------------------------------------------//
//<br>Update Note: 2011/08/30  連番2 梁森東</br>
// <br>            : REDMINE#23820の対応</br>
// --------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/09/06  修正内容 : 優良データ削除処理のメッセージボックスについての修正 FOR redmine #24507
//----------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 高騁
// 修 正 日  2015/06/08  修正内容 : REDMINE#45792の対応"商品マスタ削除" と同時に
//                                  掛率マスタは、削除する・削除しないを制御できるように修正する。
//---------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 高騁
// 修 正 日  2015/08/20  修正内容 : REDMINE#45792の対応"商品マスタ削除" と同時に
//                                  掛率マスタは、削除する・削除しないを制御できるように修正する。
//---------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinGrid;
using PMKHN01504E;
using Broadleaf.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Application.Controller;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 優良データ削除処理
    /// </summary>
    /// <remarks>
    /// <br>Note        : 優良データ削除処理を行います。</br>
    /// <br>Programmer	: 梁森東</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br>Update Nota : 2011/07/21 caohh</br>
    /// <br>            : 優良データ削除チェックリスト対応</br>
    /// <br>Update Note : 2011/09/06 鄧潘ハン　</br>
    /// <br>            : 優良データ削除処理のメッセージボックスについての修正 FOR redmine #24507</br>
    /// <br>Update Note : 2015/06/08 高騁</br>
    /// <br>管理番号    : 11100068-00 </br>
    /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
    /// </remarks>
    public partial class PMKHN01500UA : Form
    {
        # region Private Constant
        // クラス名
        private string ct_PRINTNAME = "優良データ削除処理";
        // ---- ADD caohh 2011/07/21 ----->>>>
        // プログラムID
        private const string ct_PGID = "PMKHN01500U";
        // 帳票名称
        private string _printName = "優良データ削除チェックリスト(削除)";
        // 帳票キー	
        private string _printKey = "09333d0ef6624f7e8d87f7d191c467e4";
        // 抽出条件クラス
        private DeleteCondition _deleteConditionBak;
        // ---- ADD caohh 2011/07/21 -----<<<<
        # endregion

        # region Private Members
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGroupU> _bLGroupUDic;
        private string _enterpriseCode;
        private DeleteConditionAcs _deleteConditionAcs = null;
        private SearchResultDataSet.ResultTableDataTable _resultTableMaker;
        private SearchResultDataSet.ResultTableDataTable _resultTableMGroup;
        private SearchResultDataSet.ResultTableDataTable _resultTableGroup;
        private DeleteCondition _deleteCondition;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ログイン担当者名称
        private SecInfoAcs _secInfoAcs;                                                                                   // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;                                                            // 拠点アクセスクラス
        private MakerAcs _makerAcs = null;					                                                        // メーカーアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs = null;                                              //商品中分類アクセスクラス
        private BLGroupUAcs _bLGroupUAcs = null;                                                             //BLグループアクセスクラス
        private Control _prevControl = null;									                                        // 現在のコントロール
        private int selectCount = 0;
        #endregion

        #region 初期設定処理
        /// <summary>
        /// 優良データ削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 優良データ削除処理の新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks>
        public PMKHN01500UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_End"];
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Delete"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            //this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];//DEL by Liangsd     2011/08/30
            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._bLGroupUAcs = new BLGroupUAcs();
            // マスタ読込
            ReadSecInfoSet();
            // メーカーマスタ読込処理
            LoadMakerUMnt();
            //商品中分類マスタ読込処理
            LoadGoodsGroupU();
            //BLグループ読込処理
            LoadBLGroupU();
            GetGridDate();
            this.dataGrid.DataSource = this._resultTableMaker;
        }
        # endregion

        #region ツールバー初期設定処理
        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;

            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }
        # endregion

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void PMKHN01500U_Load(object sender, EventArgs e)
        {
            ToolBarInitilSetting();
            //this.tEdit_SectionCode.Text = "00";//DEL by Liangsd     2011/08/30
            //this.tEdit_SectionName.Text = "全社";//DEL by Liangsd     2011/08/30
            this.deleteCombo.SelectedIndex = 0;
            this.ultraLabelMaker.Visible = false;
            this.tNedit_MakerCode.Visible = false;
            this.tNedit_MakerName.Visible = false;
            this.ultraLabel_Change.Text = "メーカー";
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            textClear();
            this.MaximizeBox = false;
        }
        #endregion

        #region 拠点略称取得処理
        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点略称取得処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');
            // 00時 拠点略称は全社
            if (sectionCode == "00")
            {
                return "全社";
            }
            //拠点略称取得
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }
            return "";
        }
        # endregion

        #region 拠点情報マスタ読込処理
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタ読込処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            // 拠点情報マスタ読込
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }
        # endregion

        #region メーカーマスタ読込処理
        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタ読込処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;
                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }
        #endregion

        #region ﾒｰｶｰ名取得処理
        /// <summary>
        /// ﾒｰｶｰ名取得処理
        /// </summary>
        /// <param name="goodsMakerCd">ﾒｰｶｰコード</param>
        /// <returns>ﾒｰｶｰ名</returns>
        /// <remarks>
        /// <br>Note       : ﾒｰｶｰ名取得処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetGoodsMakerNm(int goodsMakerCd)
        {
            if (this._makerUMntDic.ContainsKey(goodsMakerCd))
            {
                return this._makerUMntDic[goodsMakerCd].MakerName.Trim();
            }

            return "";
        }
        #endregion

        #region 商品中分類マスタ読込処理
        /// <summary>
        /// 商品中分類マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタ読込処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    //読込処理
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }
        #endregion

        #region 商品中分類名取得処理
        /// <summary>
        /// 商品中分類名取得処理
        /// </summary>
        /// <param name="goodsGroupcode">商品中分類コード</param>
        /// <returns>商品中分類名</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類名取得処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetGoodsGroupName(int goodsGroupcode)
        {
            if (this._goodsGroupUDic.ContainsKey(goodsGroupcode))
            {
                return this._goodsGroupUDic[goodsGroupcode].GoodsMGroupName.Trim();
            }

            return "";
        }
        #endregion

        #region BLグループマスタ読込処理
        /// <summary>
        /// BLグループマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLグループマスタ読込処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void LoadBLGroupU()
        {
            this._bLGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._bLGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            this._bLGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._bLGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }
        #endregion

        #region BLグループ名取得処理
        /// <summary>
        /// BLグループ名取得処理
        /// </summary>
        /// <param name="bLGroupcode">BLグループコード</param>
        /// <returns> BLグループ名</returns>
        /// <remarks>
        /// <br>Note       :  BLグループ名取得処理を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private string GetBLGroupName(int bLGroupcode)
        {
            if (this._bLGroupUDic.ContainsKey(bLGroupcode))
            {
                return this._bLGroupUDic[bLGroupcode].BLGroupName.Trim();
            }

            return "";
        }
        #endregion

        #region ChangeFocus イベント
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2011/09/06 鄧潘ハン　</br>
        /// <br>           : 優良データ削除処理のメッセージボックスについての修正 FOR redmine #24507</br>
        /// <br>Update Note: 2015/06/08 高騁</br>
        /// <br>管理番号   : 11100068-00 </br>
        /// <br>           : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                //#region 拠点
                ////拠点
                //case "tEdit_SectionCode":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                if (this.tEdit_SectionCode.Text == "")
                //                {
                //                    e.NextCtrl = this.SectionGuide_Button;
                //                }
                //                else
                //                {
                //                    e.NextCtrl = this.deleteCombo;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                e.NextCtrl = this.tEdit_SectionCode;
                //            }
                //        }
                //        string code = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
                //        // 入力無し
                //        if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                //        {
                //            this.tEdit_SectionName.Text = "";
                //            return;
                //        }
                //        if (GetSectionName(code) == "" && this.tEdit_SectionCode.Text != "")
                //        {
                //            this.tEdit_SectionCode.Text = "";
                //            this.tEdit_SectionName.Text = "";
                //            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当する拠点が存在しない",0);
                //            this.tEdit_SectionCode.Focus();
                //        }
                //        this.tEdit_SectionName.Text = GetSectionName(code);
                //        break;
                //    }
                //#endregion
                //#region ガイドバーテン
                ////ガイドバーテン
                //case "SectionGuide_Button":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                    e.NextCtrl = this.deleteCombo;
                //            }
                //        }
                //        else
                //        {
                //            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //            {
                //                //e.NextCtrl = this.tEdit_SectionCode;
                //            }
                //        }
                //        break;
                //    }
                //#endregion
                //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<

                #region 削除区分
                case "deleteCombo":
                    {
                        if (this.deleteCombo.SelectedIndex == 0)
                        {
                            // フォーカス設定
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.tNedit_Code1;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;//DEL by Liangsd     2011/08/30
                                    e.NextCtrl = this.deleteCombo;//ADD by Liangsd    2011/08/30
                                }
                            }
                            this.ultraLabelMaker.Visible = false;
                            this.tNedit_MakerCode.Visible = false;
                            this.tNedit_MakerName.Visible = false;
                            this.ultraLabel_Change.Text = "メーカー";
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.tNedit_MakerCode;
                                    ChangeToMakerData();
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;//DEL by Liangsd     2011/08/30
                                    e.NextCtrl = this.deleteCombo;//ADD by Liangsd    2011/08/30
                                }
                            }
                            this.ultraLabelMaker.Visible = true;
                            this.tNedit_MakerCode.Visible = true;
                            this.tNedit_MakerName.Visible = true;
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                this.ultraLabel_Change.Text = "中分類";
                            }
                            else
                            {
                                this.ultraLabel_Change.Text = "グループコード";
                            }

                        }
                        break;
                    }
                #endregion

                #region メーカー
                //メーカー
                case "tNedit_MakerCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code1;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.deleteCombo;
                            }
                        }
                        int code = this.tNedit_MakerCode.GetInt();
                        // 入力無し
                        if (code == 0)
                        {
                            this.tNedit_MakerCode.Text = "";
                            this.tNedit_MakerName.Text = "";
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            return;
                        }
                        else
                        {
                            if (GetGoodsMakerNm(code) == "")
                            {
                                e.NextCtrl = this.tNedit_MakerCode;
                                this.tNedit_MakerCode.Text = "";
                                this.tNedit_MakerName.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                            }
                        }
                        this.tNedit_MakerName.Text = GetGoodsMakerNm(code);
                        CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        break;
                    }
                #endregion

                #region コード１
                case "tNedit_Code1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code2;
                            }
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.deleteCombo;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.tNedit_MakerCode;
                                }
                            }
                        }
                        int code = this.tNedit_Code1.GetInt();
                        // 入力無しと繰り返し
                        if (code == this.tNedit_Code2.GetInt() || code == this.tNedit_Code3.GetInt() || code == this.tNedit_Code4.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code1.Text = "";
                                this.tEdit_Name1.Text = "";
                                this.tNedit_Code1.Focus();
                            }
                            else
                            {
                                this.tNedit_Code1.Text = "";
                                this.tEdit_Name1.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                if (this.ultraLabel_Change.Text == "メーカー")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "中分類")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code1.Focus();
                            }
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {

                                if (GetGoodsMakerNm(this.tNedit_Code1.GetInt()) == "" && this.tNedit_Code1.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code1;
                                    this.tNedit_Code1.Text = "";
                                    this.tEdit_Name1.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name1.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);

                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code1.GetInt()) == "" && this.tNedit_Code1.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code1;
                                    this.tNedit_Code1.Text = "";
                                    this.tEdit_Name1.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name1.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code1.GetInt()) == "" && this.tNedit_Code1.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code1;
                                    this.tNedit_Code1.Text = "";
                                    this.tEdit_Name1.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name1.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region コード２
                case "tNedit_Code2":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code3;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code1;
                            }
                        }
                        int code = this.tNedit_Code2.GetInt();
                        // 入力無しと繰り返し
                        if (code == this.tNedit_Code1.GetInt() || code == this.tNedit_Code3.GetInt() || code == this.tNedit_Code4.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code2.Text = "";
                                this.tEdit_Name2.Text = "";
                                this.tNedit_Code2.Focus();
                            }
                            else
                            {
                                this.tNedit_Code2.Text = "";
                                this.tEdit_Name2.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                if (this.ultraLabel_Change.Text == "メーカー")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "中分類")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code2.Focus();
                            }
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {

                                if (GetGoodsMakerNm(this.tNedit_Code2.GetInt()) == "" && this.tNedit_Code2.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code2;
                                    this.tNedit_Code2.Text = "";
                                    this.tEdit_Name2.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name2.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);

                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code2.GetInt()) == "" && this.tNedit_Code2.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code2;
                                    this.tNedit_Code2.Text = "";
                                    this.tEdit_Name2.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name2.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code2.GetInt()) == "" && this.tNedit_Code2.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code2;
                                    this.tNedit_Code2.Text = "";
                                    this.tEdit_Name2.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name2.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region コード 3
                case "tNedit_Code3":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code4;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code2;
                            }
                        }
                        int code = this.tNedit_Code3.GetInt();
                        // 入力無しと繰り返し
                        if (code == this.tNedit_Code1.GetInt() || code == this.tNedit_Code2.GetInt() || code == this.tNedit_Code4.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code3.Text = "";
                                this.tEdit_Name3.Text = "";
                                this.tNedit_Code3.Focus();
                            }
                            else
                            {
                                this.tNedit_Code3.Text = "";
                                this.tEdit_Name3.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                if (this.ultraLabel_Change.Text == "メーカー")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "中分類")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code3.Focus();
                            }
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {
                                if (GetGoodsMakerNm(this.tNedit_Code3.GetInt()) == "" && this.tNedit_Code3.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code3;
                                    this.tNedit_Code3.Text = "";
                                    this.tEdit_Name3.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name3.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);

                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code3.GetInt()) == "" && this.tNedit_Code3.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code3;
                                    this.tNedit_Code3.Text = "";
                                    this.tEdit_Name3.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name3.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code3.GetInt()) == "" && this.tNedit_Code3.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code3;
                                    this.tNedit_Code3.Text = "";
                                    this.tEdit_Name3.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name3.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region コード 4
                case "tNedit_Code4":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.goodsComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code3;
                            }
                        }
                        int code = this.tNedit_Code4.GetInt();
                        // 入力無しと繰り返し
                        if (code == this.tNedit_Code1.GetInt() || code == this.tNedit_Code2.GetInt() || code == this.tNedit_Code3.GetInt())
                        {
                            if (code == 0)
                            {
                                this.tNedit_Code4.Text = "";
                                this.tEdit_Name4.Text = "";
                                this.tNedit_Code4.Focus();
                            }
                            else
                            {
                                this.tNedit_Code4.Text = "";
                                this.tEdit_Name4.Text = "";
                                //---UPD 2011/09/06 ------------------------------------->>>>>
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                if (this.ultraLabel_Change.Text == "メーカー")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                }
                                else if (this.ultraLabel_Change.Text == "中分類")
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                }
                                else
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                }
                                //---UPD 2011/09/06 -------------------------------------<<<<<
                                this.tNedit_Code4.Focus();
                            }
                            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                        }
                        else
                        {
                            if (this.deleteCombo.SelectedIndex == 0)
                            {
                                if (GetGoodsMakerNm(this.tNedit_Code4.GetInt()) == "" && this.tNedit_Code4.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code4;
                                    this.tNedit_Code4.Text = "";
                                    this.tEdit_Name4.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name4.Text = GetGoodsMakerNm(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 1)
                            {
                                if (GetMNameCommon(this.tNedit_Code4.GetInt()) == "" && this.tNedit_Code4.Text != "")
                                {

                                    e.NextCtrl = this.tNedit_Code4;
                                    this.tNedit_Code4.Text = "";
                                    this.tEdit_Name4.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name4.Text = GetMNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                            if (this.deleteCombo.SelectedIndex == 2)
                            {
                                if (GetBLGroupNameCommon(this.tNedit_Code4.GetInt()) == "" && this.tNedit_Code4.Text != "")
                                {
                                    e.NextCtrl = this.tNedit_Code4;
                                    this.tNedit_Code4.Text = "";
                                    this.tEdit_Name4.Text = "";
                                    //---UPD 2011/09/06 ------------------------------------->>>>>
                                    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力あやまり", 0);
                                    if (this.ultraLabel_Change.Text == "メーカー")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したメーカーコードは存在しません。", 0);
                                    }
                                    else if (this.ultraLabel_Change.Text == "中分類")
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力した商品中分類コードは存在しません。", 0);
                                    }
                                    else
                                    {
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "入力したグループコードは存在しません。", 0);
                                    }
                                    //---UPD 2011/09/06 -------------------------------------<<<<<
                                }
                                this.tEdit_Name4.Text = GetBLGroupNameCommon(code);
                                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
                            }
                        }
                        break;
                    }
                #endregion

                #region Grid
                //Grid
                case "dataGrid":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.goodsComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_Code4;
                            }
                        }
                        break;
                    }
                #endregion

                #region 商品マスタ
                case "goodsComboEditor":
                    {
                        if (this.goodsComboEditor.SelectedIndex == 1)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.joinComboEditor;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.tNedit_Code4;
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.goodsStockComboEditor;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.tNedit_Code4;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 商品在庫品取扱い
                case "goodsStockComboEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.joinComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.goodsComboEditor;
                            }
                        }
                        break;
                    }
                #endregion

                #region 結合マスタ
                case "joinComboEditor":
                    {
                        if (this.joinComboEditor.SelectedIndex == 1)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // e.NextCtrl = this.joinComboEditor; // Del 2015/06/08 高騁 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                                    e.NextCtrl = this.rateComboEditor; // Add 2015/06/08 高騁 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                                }
                            }
                            else
                            {
                                if (this.goodsComboEditor.SelectedIndex == 1)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsComboEditor;
                                    }
                                }
                                else
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsStockComboEditor;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.joinStockComboEditor;
                                }
                            }
                            else
                            {
                                if (this.goodsComboEditor.SelectedIndex == 1)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsComboEditor;
                                    }
                                }
                                else
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        e.NextCtrl = this.goodsStockComboEditor;
                                    }
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 結合在庫品取扱い
                case "joinStockComboEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // e.NextCtrl = this.joinComboEditor; // Del 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                                e.NextCtrl = this.rateComboEditor; // Add 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.joinComboEditor;
                            }
                        }
                        break;
                    }
                #endregion

                // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                #region 掛率マスタ
                case "rateComboEditor":
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.rateComboEditor.SelectedIndex == 1)
                            {
                                if (e.ShiftKey == false)
                                {
                                    e.NextCtrl = this.rateComboEditor;
                                }
                                else if (this.joinComboEditor.SelectedIndex == 1)
                                {
                                    e.NextCtrl = this.joinComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.joinStockComboEditor;
                                }
                            }
                            else
                            {
                                if (e.ShiftKey == false)
                                {
                                    //e.NextCtrl = this.rateStockComboEditor; // DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                                    e.NextCtrl = this.rateComboEditor; // ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                                }
                                else if (this.joinComboEditor.SelectedIndex == 1)
                                {
                                    e.NextCtrl = this.joinComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.joinStockComboEditor;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                //#region 掛率在庫品取扱い
                //case "rateStockComboEditor":
                //    {
                //        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //        {
                //            if (e.ShiftKey == false)
                //            {
                //                e.NextCtrl = this.rateStockComboEditor;
                //            }
                //            else
                //            {
                //                e.NextCtrl = this.rateComboEditor;
                //            }
                //        }
                //        break;
                //    }
                //#endregion
                // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<
                // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
            }
        }
        #endregion

        #region グリッド列初期設定処理
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void dataGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMaker;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            // 選択チェックボックス
            columns[table.ChooseColColumn.ColumnName].Header.Caption = "選択";
            columns[table.ChooseColColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.ChooseColColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            columns[table.ChooseColColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            columns[table.ChooseColColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[table.ChooseColColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;

            // 名称
            columns[table.CodeColumn.ColumnName].Header.Caption = "メーカーコード";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "メーカー名称";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;

            // 表示幅設定
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;

        }
        #endregion

        #region グリッドのClick
        /// <summary>
        /// グリッドのClick
        /// </summary>
        /// <remarks>
        /// <br>Note		: グリッドClickの時、データ設定処理を行います。</br> 
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void dataGrid_Click(object sender, EventArgs e)
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            try
            {
                // マウスポインタがグリッドのどの位置にあるかを判定する
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElementを取得する。
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                    return;

                // マウスポインターが列のヘッダ上にあるかチェック。
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                    (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                if (objHeader != null) return;

                // マウスポインターが行の上にあるかチェック。
                Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                    (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                if (objRow == null) return;

                // マウスポインターが行の上にあるかチェック。
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                    (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                // 選択・非選択セル以外はキャンセル
                if (objCell == null || objCell.Column.Key != "ChooseCol") return;
                GridClick(objRow, false, true);
            }
            catch
            {
            }
        }
        #endregion

        #region グリッドのDoubleClick
        /// <summary>
        /// グリッドのDoubleClick
        /// </summary>
        /// <remarks>
        /// <br>Note		: グリッドsDoubleClickの時、データ設定処理を行います。</br> 
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
            UltraGridRow dr = dataGrid.ActiveRow;
            GridClick(dr, false, true);
        }
        #endregion

        #region 削除区分ValueChange イベント
        /// <summary>
        /// 削除区分ValueChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 削除区分ValueChange イベントを行います</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void DeleteComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //メーカー
            if (this.deleteCombo.SelectedIndex == 0)
            {
                this.ultraLabelMaker.Visible = false;
                this.tNedit_MakerCode.Visible = false;
                this.tNedit_MakerName.Visible = false;
                this.ultraLabel_Change.Text = "メーカー";
                this.tNedit_Code1.Focus();
                this.selectCount = 0;
                textClear();
            }
            else
            {
                textClear();
                this.ultraLabelMaker.Visible = true;
                this.tNedit_MakerCode.Visible = true;
                this.tNedit_MakerName.Visible = true;
                //中分類
                if (this.deleteCombo.SelectedIndex == 1)
                {
                    this.selectCount = 0;
                    this.ultraLabel_Change.Text = "中分類";
                    this.tNedit_MakerCode.Focus();
                }
                //グループコード
                else
                {
                    this.selectCount = 0;
                    this.ultraLabel_Change.Text = "グループコード";
                    this.tNedit_MakerCode.Focus();
                }
            }
        }
        #endregion

        #region 商品マスタValueChange イベント
        /// <summary>
        /// 商品マスタValueChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 商品マスタValueChange イベントを行います</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void goodsComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.goodsComboEditor.SelectedIndex == 1)
            {
                this.goodsStockComboEditor.Text = "";
                this.goodsStockComboEditor.Enabled = false;
            }
            else
            {
                this.goodsStockComboEditor.Enabled = true;
                this.goodsStockComboEditor.SelectedIndex = 0;
            }
        }
        #endregion

        #region 結合マスタValueChange イベント
        /// <summary>
        /// 結合マスタValueChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 結合マスタValueChange イベントを行います</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void joinComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.joinComboEditor.SelectedIndex == 1)
            {
                this.joinStockComboEditor.Text = "";
                this.joinStockComboEditor.Enabled = false;
            }
            else
            {
                this.joinStockComboEditor.SelectedIndex = 0;
                this.joinStockComboEditor.Enabled = true;
            }
        }
        #endregion

        // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
        //// ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正---->>>>>
        //#region 掛率マスタValueChange イベント
        ///// <summary>
        ///// 掛率マスタValueChange イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントハンドラ</param>
        ///// <remarks>
        ///// <br>Note       : 掛率マスタValueChange イベントを行います</br>
        ///// <br>Programmer : 高騁</br>
        ///// <br>Date       : 2015/06/08</br>
        ///// </remarks>
        //private void rateComboEditor_ValueChanged(object sender, EventArgs e)
        //{
        //    if (this.rateComboEditor.SelectedIndex == 1)
        //    {
        //        this.rateStockComboEditor.Text = "";
        //        this.rateStockComboEditor.Enabled = false;
        //    }
        //    else
        //    {
        //        this.rateStockComboEditor.SelectedIndex = 0;
        //        this.rateStockComboEditor.Enabled = true;
        //    }
        //}
        //#endregion
        //// ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正----<<<<<
        // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<

        #region 商品中分類名取得
        /// <summary>
        /// 商品中分類名取得
        /// </summary>
        /// <param name="codeNum">入力code</param>
        /// <param name="outName">商品中分類名</param>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// <returns></returns>
        private string GetMNameCommon(int codeNum)
        {
            string outName = "";
            int code = codeNum;
            // 入力無し
            if (string.IsNullOrEmpty(codeNum.ToString()))
            {
                outName = "";
            }
            else
            {
                outName = GetGoodsGroupName(code);
            }
            return outName;
        }
        #endregion

        #region  BLグループ名取得
        /// <summary>
        /// BLグループ名取得
        /// </summary>
        /// <param name="codeNum">入力code</param>
        /// <param name="outName">BLグループ名</param>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// <returns></returns>
        private string GetBLGroupNameCommon(int codeNum)
        {
            string outName = "";
            int code = codeNum;
            // 入力無し
            if (string.IsNullOrEmpty(codeNum.ToString()))
            {
                outName = "";
            }
            else
            {
                outName = GetBLGroupName(code);
            }
            return outName;
        }
        #endregion

        #region ツールバークリックイベント
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生します。</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case "ButtonTool_End":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                //削除
                case "ButtonTool_Delete":
                    {
                        //削除処理
                        DeleteAll();
                        break;
                    }
            }
        }
        #endregion

        #region 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 削除処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2015/06/08 高騁</br>
        /// <br>管理番号   : 11100068-00 </br>
        /// <br>           : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
        /// </remarks>
        private void DeleteAll()
        {
            if (BeforeDeleteCheck())
            {
                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                if (this._prevControl != null)
                {
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                    this.tArrowKeyControl1_ChangeFocus(this, e);
                }
                // 確認メッセージを表示する。
                DialogResult result = TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,             // エラーレベル
                            "PMKHN01500UA",						            // アセンブリＩＤまたはクラスＩＤ
                            ct_PRINTNAME,				                    // プログラム名称
                            "", 								            // 処理名称
                            "",									            // オペレーション
                            "削除処理を開始してもよろしいですか？",		// 表示するメッセージ
                            -1, 							                // ステータス値
                            null, 								            // エラーが発生したオブジェクト
                            MessageBoxButtons.YesNo, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	            // 初期表示ボタン
                // 入力画面へ戻る。
                if (result == DialogResult.No)
                {
                    return;
                }

                // 抽出中画面部品のインスタンスを作成
                SFCMN00299CA msgForm = new SFCMN00299CA();
                msgForm.Title = "削除中";
                msgForm.Message = "削除中です。";
                try
                {
                    msgForm.Show();

                    string msg = string.Empty;
                    //削除前データ設定
                    _deleteCondition = new DeleteCondition();
                    _deleteConditionAcs = DeleteConditionAcs.GetInstance();
                    _deleteCondition.DeleteCode = this.deleteCombo.SelectedIndex;
                    //データクリア
                    this.goodsNotDelLabel.Text = "0 件";
                    this.joinNotDelLabel.Text = "0 件";
                    this.joinDeleteLabel.Text = "0 件";
                    this.goodsDeleteLabel.Text = "0 件";
                    this.stockNotDelLabel.Text = "0 件";
                    this.stockDeleteLabel.Text = "0 件";
                    // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                    //this.rateNotDelLabel.Text = "0 件";//DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    this.rateDeleteLabel.Text = "0 件";
                    // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                    this._deleteCondition.StockDeleteCnt = 0;
                    this._deleteCondition.GoodsDeleteCnt = 0;
                    this._deleteCondition.JoinDeleteCnt = 0;
                    this._deleteCondition.RateDeleteCnt = 0; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    this._deleteCondition.StockNotDeleteCnt = 0;
                    this._deleteCondition.GoodsNotDeleteCnt = 0;
                    this._deleteCondition.JoinNotDeleteCnt = 0;
                    this._deleteCondition.RateNotDeleteCnt = 0; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    /* ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    //削除区分 = メーカー
                    if (this.deleteCombo.SelectedIndex == 0)
                    {
                       ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                        _deleteCondition.EnterpriseCode = this._enterpriseCode;
                        //_deleteCondition.SectionCode = this.tEdit_SectionCode.Text;//DEL by Liangsd     2011/08/30
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                        //削除区分 <> メーカー
                        if (this.deleteCombo.SelectedIndex != 0)
                        {
                            _deleteCondition.GoodsMakerCode = this.tNedit_MakerCode.GetInt();
                        }
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                        _deleteCondition.Code1 = this.tNedit_Code1.GetInt();
                        _deleteCondition.Code2 = this.tNedit_Code2.GetInt();
                        _deleteCondition.Code3 = this.tNedit_Code3.GetInt();
                        _deleteCondition.Code4 = this.tNedit_Code4.GetInt();
                        //商品マスタ削除区分
                        if (this.goodsComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.GoodsDeleteCode = this.goodsStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //削除しない
                            _deleteCondition.GoodsDeleteCode = 9;
                        }
                        //結合マスタ削除区分
                        if (this.joinComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.JoinDeleteCode = this.joinStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //削除しない
                            _deleteCondition.JoinDeleteCode = 9;
                        }
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                        //掛率マスタ削除区分
                        if (this.rateComboEditor.SelectedIndex == 0)
                        {
                            //_deleteCondition.RateDeleteCode = this.rateStockComboEditor.SelectedIndex + 1; //DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                            _deleteCondition.RateDeleteCode = 0; //ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                        }
                        else
                        {
                            //削除しない
                            _deleteCondition.RateDeleteCode = 9;
                        }
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                    /* ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    }
                    else
                    {
                        _deleteCondition.EnterpriseCode = this._enterpriseCode;
                        //_deleteCondition.SectionCode = this.tEdit_SectionCode.Text;//DEL by Liangsd     2011/08/30
                        _deleteCondition.GoodsMakerCode = this.tNedit_MakerCode.GetInt();
                        _deleteCondition.Code1 = this.tNedit_Code1.GetInt();
                        _deleteCondition.Code2 = this.tNedit_Code2.GetInt();
                        _deleteCondition.Code3 = this.tNedit_Code3.GetInt();
                        _deleteCondition.Code4 = this.tNedit_Code4.GetInt();
                        //商品マスタ削除区分
                        if (this.goodsComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.GoodsDeleteCode = this.goodsStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //削除しない
                            _deleteCondition.GoodsDeleteCode = 9;
                        }
                        //結合マスタ削除区分
                        if (this.joinComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.JoinDeleteCode = this.joinStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //削除しない
                            _deleteCondition.JoinDeleteCode = 9;
                        }
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                        //掛率マスタ削除区分
                        if (this.rateComboEditor.SelectedIndex == 0)
                        {
                            _deleteCondition.RateDeleteCode = this.rateStockComboEditor.SelectedIndex + 1;
                        }
                        else
                        {
                            //削除しない
                            _deleteCondition.RateDeleteCode = 9;
                        }
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                    }
                       ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                    // 削除処理
                    // ---- ADD caohh 2011/07/21 ---->>>>
                    _deleteConditionBak = new DeleteCondition();
                    _deleteConditionBak = _deleteCondition;
                    // 優良データ削除チェックリストを出力する場合
                    if (_deleteCondition.GoodsDeleteCode == 3 || _deleteCondition.GoodsDeleteCode == 4)
                    {
                        status = this._deleteConditionAcs.SearchMain(ref msg, ref this._deleteCondition);
                    }
                    // ---- ADD caohh 2011/07/21 ----<<<<

                    status = this._deleteConditionAcs.DeleteData(ref msg, ref _deleteCondition);

                    switch (status)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            this.stockDeleteLabel.Text = this._deleteCondition.StockDeleteCnt + " 件";
                            this.goodsDeleteLabel.Text = this._deleteCondition.GoodsDeleteCnt + " 件";
                            this.joinDeleteLabel.Text = this._deleteCondition.JoinDeleteCnt + " 件";
                            this.rateDeleteLabel.Text = this._deleteCondition.RateDeleteCnt + " 件"; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                            if (this.goodsComboEditor.SelectedIndex != 1)
                            {
                                this.stockNotDelLabel.Text = this._deleteCondition.StockNotDeleteCnt + " 件";
                            }
                            if (this.goodsStockComboEditor.SelectedIndex == 1 || this.goodsStockComboEditor.SelectedIndex == 3)
                            {
                                this.goodsNotDelLabel.Text = this._deleteCondition.GoodsNotDeleteCnt + " 件";
                            }
                            if (this.joinStockComboEditor.SelectedIndex == 1)
                            {
                                this.joinNotDelLabel.Text = this._deleteCondition.JoinNotDeleteCnt + " 件";
                            }
                            // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                            //// ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 --->>>>>
                            //if (this.rateStockComboEditor.SelectedIndex == 1)
                            //{
                            //    this.rateNotDelLabel.Text = this._deleteCondition.RateNotDeleteCnt + " 件";
                            //}
                            //// ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                            // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<
                            // フォーカスは拠点に戻る
                            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
                            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30
                            msgForm.Close();
                            // if (this._deleteCondition.StockDeleteCnt != 0 || this._deleteCondition.GoodsDeleteCnt != 0 || this._deleteCondition.JoinDeleteCnt != 0) // DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                            if (this._deleteCondition.StockDeleteCnt != 0 || this._deleteCondition.GoodsDeleteCnt != 0 || this._deleteCondition.JoinDeleteCnt != 0 || this._deleteCondition.RateDeleteCnt != 0) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "削除成功", 0);
                            }
                            else
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "削除対象がありません", 0);
                            }
                            // ---- ADD caohh 2011/07/21 ---->>>>
                            // 優良データ削除チェックリストを出力する場合
                            if ((_deleteConditionBak.GoodsDeleteCode == 3 || _deleteConditionBak.GoodsDeleteCode == 4) && (this._deleteCondition.StockDeleteCnt != 0 || this._deleteCondition.GoodsDeleteCnt != 0))
                            {
                                SFCMN06002C parameter = new SFCMN06002C();
                                status = Print(ref parameter);
                            }
                            // ---- ADD caohh 2011/07/21 ----<<<<
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            "PMKHN01500UA",							// アセンブリID
                            "優良データ削除処理\n既に他端末により更新されている為、処理を中断しました。\n再試行するか、しばらく待ってから再度処理を実行して下さい。",	    // 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                            // フォーカスは拠点に戻る
                            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
                            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30

                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            "PMKHN01500UA",							// アセンブリID
                            "優良データ削除処理が\n既に他端末により削除されている為、処理を中断しました。\n再試行するか、しばらく待ってから再度処理を実行して下さい。",	    // 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                            // フォーカスは拠点に戻る
                            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
                            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30
                            break;

                        default:
                            MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "削除に失敗しました。", 0);
                            break;
                    }
                }
                finally
                {
                    msgForm.Close();
                }


            }
        }
        #endregion

        #region 削除前チェック
        /// <summary>
        /// 削除前チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 削除前チェックを行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2015/06/08 高騁</br>
        /// <br>管理番号   : 11100068-00 </br>
        /// <br>           : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>     
        /// </remarks>
        private bool BeforeDeleteCheck()
        {
            //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
            //// 拠点入力チェック
            //if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
            //{
            //    // 該当なし
            //    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
            //                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
            //                    this.Name,											// アセンブリID
            //                    "拠点が設定されていません。",                       // 表示するメッセージ
            //                    -1,													// ステータス値
            //                    MessageBoxButtons.OK);

            //    // フォーカス設定
            //    this.tEdit_SectionCode.Focus();
            //    return false;
            //}
            // メーカー入力チェック
            //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
            if (this.deleteCombo.SelectedIndex != 0)
            {
                if (this.tNedit_MakerCode.GetInt() == 0)
                {
                    // 該当なし
                    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                    this.Name,											// アセンブリID
                                    "メーカーコードを入力して下さい。",                 // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);

                    // フォーカス設定
                    this.tNedit_MakerCode.Focus();
                    ChangeToMakerData();
                    return false;
                }
            }
            if (this.tNedit_Code1.GetInt() == 0 && this.tNedit_Code2.GetInt() == 0 && this.tNedit_Code3.GetInt() == 0 && this.tNedit_Code4.GetInt() == 0)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "コードを入力して下さい。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tNedit_Code1.Focus();
                if (deleteCombo.SelectedIndex == 0)
                {
                    ChangeToMakerData();
                }
                if (deleteCombo.SelectedIndex == 1)
                {
                    ChangeToMGroupData();
                }
                if (deleteCombo.SelectedIndex == 2)
                {
                    ChangeToGroupData();
                }
                return false;
            }
            // if (this.joinComboEditor.SelectedIndex == 1 && this.goodsComboEditor.SelectedIndex == 1) // DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (this.joinComboEditor.SelectedIndex == 1 && this.goodsComboEditor.SelectedIndex == 1 && this.rateComboEditor.SelectedIndex == 1) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "削除する対象がありません。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.goodsComboEditor.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 商品メーカーコードFocusリッド列設定処理処理
        /// <summary>
        /// 商品メーカーコードFocusリッド列設定処理処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       :商品メーカーコードFocusリッド列設定処理処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_MakerCode_Enter(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMaker;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableMaker;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.NameColumn.ColumnName].Width = 260;
            columns[table.CodeColumn.ColumnName].Header.Caption = "メーカーコード";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "メーカー名称";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
        }
        #endregion

        #region コード1Focus取得処理
        /// <summary>
        /// コードFocus取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : コード1Focus取得処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code1_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region コード2Focus取得処理
        /// <summary>
        /// コードFocus取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : コード2Focus取得処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code2_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region コード3Focus取得処理
        /// <summary>
        /// コードFocus取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : コード3Focus取得処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code3_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region コード4Focus取得処理
        /// <summary>
        /// コードFocus取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : コード4Focus取得処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void tNedit_Code4_Enter(object sender, EventArgs e)
        {
            CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            ColumnChange();
        }
        #endregion

        #region  コード変更時グリッド列設定処理処理
        /// <summary>
        /// コード変更時グリッド列設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コード変更時グリッド列設定処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void ColumnChange()
        {
            //削除区分 = メーカー
            if (this.deleteCombo.SelectedIndex == 0)
            {
                ChangeToMakerData();
                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            }
            //削除区分 = メーカー+中分類
            if (this.deleteCombo.SelectedIndex == 1)
            {
                ChangeToMGroupData();
                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            }
            //削除区分 = メーカー+グループコード
            if (this.deleteCombo.SelectedIndex == 2)
            {
                ChangeToGroupData();
                CheckBoxAuto((SearchResultDataSet.ResultTableDataTable)this.dataGrid.DataSource);
            }
        }
        #endregion

        #region  グリッドデータ読込処理
        /// <summary>
        /// グリッドデータ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドデータ読込処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void GetGridDate()
        {
            GetMakerTable();
            GetMGroupTable();
            GetGroupTable();
        }
        /// <summary>
        /// メーカーグリッドデータ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーグリッドデータ読込処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void GetMakerTable()
        {
            _resultTableMaker = new SearchResultDataSet.ResultTableDataTable();
            SearchResultDataSet.ResultTableRow rowMaker = _resultTableMaker.NewResultTableRow();
            try
            {
                ArrayList retListMaker;
                int status = this._makerAcs.SearchAll(out retListMaker, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retListMaker)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            rowMaker = _resultTableMaker.NewResultTableRow();
                            rowMaker.ChooseCol = false;
                            rowMaker.Code = makerUMnt.GoodsMakerCd.ToString();
                            rowMaker.Name = makerUMnt.MakerName.ToString();
                            _resultTableMaker.AddResultTableRow(rowMaker);
                        }
                    }
                }
            }
            catch
            {
                _resultTableMaker = new SearchResultDataSet.ResultTableDataTable();
            }
        }
        /// <summary>
        /// 中分類グリッドデータ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 中分類グリッドデータ読込処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void GetMGroupTable()
        {
            _resultTableMGroup = new SearchResultDataSet.ResultTableDataTable();
            SearchResultDataSet.ResultTableRow rowMGroup = _resultTableMGroup.NewResultTableRow();
            try
            {
                ArrayList retListMGroup;
                int status = this._goodsGroupUAcs.SearchAll(out retListMGroup, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retListMGroup)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            rowMGroup = _resultTableMGroup.NewResultTableRow();
                            rowMGroup.ChooseCol = false;
                            rowMGroup.Code = goodsGroupU.GoodsMGroup.ToString();
                            rowMGroup.Name = goodsGroupU.GoodsMGroupName.ToString();
                            _resultTableMGroup.AddResultTableRow(rowMGroup);
                        }
                    }
                }
            }
            catch
            {
                _resultTableMGroup = new SearchResultDataSet.ResultTableDataTable();
            }
        }

        /// <summary>
        /// グループグリッドデータ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グループグリッドデータ読込処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void GetGroupTable()
        {
            _resultTableGroup = new SearchResultDataSet.ResultTableDataTable();
            SearchResultDataSet.ResultTableRow rowGroup = _resultTableGroup.NewResultTableRow();
            try
            {
                ArrayList retListGroup;
                int status = this._bLGroupUAcs.SearchAll(out retListGroup, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retListGroup)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            rowGroup = _resultTableGroup.NewResultTableRow();
                            rowGroup.ChooseCol = false;
                            rowGroup.Code = bLGroupU.BLGroupCode.ToString();
                            rowGroup.Name = bLGroupU.BLGroupName.ToString();
                            _resultTableGroup.AddResultTableRow(rowGroup);
                        }
                    }
                }
            }
            catch
            {
                _resultTableGroup = new SearchResultDataSet.ResultTableDataTable();
            }
        }









        #endregion

        #region エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMKHN01500UA",						// アセンブリＩＤまたはクラスＩＤ
                ct_PRINTNAME,				        // プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region 条件データクリア
        /// <summary>
        /// 条件データクリア
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// <br>Update Note: 2015/06/08 高騁</br>
        /// <br>管理番号   : 11100068-00 </br>
        /// <br>           : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
        /// </remarks>
        private void textClear()
        {
            this.tNedit_Code1.Text = "";
            this.tNedit_Code2.Text = "";
            this.tNedit_Code3.Text = "";
            this.tNedit_Code4.Text = "";
            this.tEdit_Name1.Text = "";
            this.tEdit_Name2.Text = "";
            this.tEdit_Name3.Text = "";
            this.tEdit_Name4.Text = "";
            this.tNedit_MakerCode.Text = "";
            this.tNedit_MakerName.Text = "";
            this.goodsNotDelLabel.Text = "0 件";
            this.joinNotDelLabel.Text = "0 件";
            this.joinDeleteLabel.Text = "0 件";
            this.goodsDeleteLabel.Text = "0 件";
            this.stockNotDelLabel.Text = "0 件";
            this.stockDeleteLabel.Text = "0 件";
            // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正---->>>>>
            //this.rateNotDelLabel.Text = "0 件";//DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            this.rateDeleteLabel.Text = "0 件";
            // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正----<<<<<
            this.goodsComboEditor.SelectedIndex = 0;
            this.joinComboEditor.SelectedIndex = 0;
            this.goodsStockComboEditor.SelectedIndex = 0;
            this.joinStockComboEditor.SelectedIndex = 0;
            // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正---->>>>>
            this.rateComboEditor.SelectedIndex = 0;
            //this.rateStockComboEditor.SelectedIndex = 0; //DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正----<<<<<
        }
        #endregion

        #region DataChange
        /// <summary>
        /// グリッド列変更 = メーカー
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列変更 = メーカーを行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void ChangeToMakerData()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMaker;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableMaker;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;
        }

        /// <summary>
        /// グリッド列変更 = 中分類
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列変更 = 中分類を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void ChangeToMGroupData()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableMGroup;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableMGroup;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.CodeColumn.ColumnName].Header.Caption = "中分類コード";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "中分類名称";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;

        }

        /// <summary>
        /// グリッド列変更 = グループ
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列変更 = グループを行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/15</br>
        /// </remarks>
        private void ChangeToGroupData()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.dataGrid.DisplayLayout.Bands[0];
            editBand.Columns[0].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            if (editBand == null) return;
            SearchResultDataSet.ResultTableDataTable table = this._resultTableGroup;
            ColumnsCollection columns = editBand.Columns;
            editBand.ColHeadersVisible = true;
            this.dataGrid.DataSource = this._resultTableGroup;
            columns[table.CodeColumn.ColumnName].Hidden = false;
            columns[table.ChooseColColumn.ColumnName].Width = 30;
            columns[table.CodeColumn.ColumnName].Width = 130;
            columns[table.NameColumn.ColumnName].Width = 260;
            columns[table.NameColumn.ColumnName].Hidden = false;
            columns[table.CodeColumn.ColumnName].Header.Caption = "グループコード";
            columns[table.CodeColumn.ColumnName].CellActivation = Activation.NoEdit;
            columns[table.CodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.NameColumn.ColumnName].Header.Caption = "グループ名称";
            columns[table.NameColumn.ColumnName].CellActivation = Activation.NoEdit;
        }
        #endregion

        #region 拠点ガイドのClick
        /// <summary>
        ///  拠点ガイドのClick
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		:  拠点ガイドClickの時、データ設定処理を行います。</br> 
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            //DEL by Liangsd   2011/08/30----------------->>>>>>>>>
            //SecInfoSet sectionInfo;
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this.tEdit_SectionCode.Text = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0'); 
            //    this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
            //}
            //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
        }
        #endregion

        #region グリッドのClick共通
        /// <summary>
        /// グリッドのClick共通
        /// </summary>
        /// <param name="dr">現在の行</param>
        /// <param name="flag1">区分１</param>
        /// <param name="flag2">区分２</param>        /// <remarks>
        /// <br>Note		:  グリッドのClick共通を行います。</br> 
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        private void GridClick(UltraGridRow dr, bool flag1, bool flag2)
        {
            //コード判定
            if (this.deleteCombo.SelectedIndex != 0 && dr.Cells[1].Value.ToString() == this.tNedit_MakerCode.Text)
            {
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code1.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code1.Text = "";
                this.tEdit_Name1.Text = "";
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code2.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code2.Text = "";
                this.tEdit_Name2.Text = "";
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code3.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code3.Text = "";
                this.tEdit_Name3.Text = "";
                return;
            }
            if (dr.Cells[1].Value.ToString() == this.tNedit_Code4.Text)
            {
                dr.Cells[0].Value = flag1;
                selectCount--;
                this.tNedit_Code4.Text = "";
                this.tEdit_Name4.Text = "";
                return;
            }
            if (this.deleteCombo.SelectedIndex != 0 && this.tNedit_MakerCode.Text == "" && this.dataGrid.DataSource == this._resultTableMaker)
            {
                dr.Cells[0].Value = flag2;
                this.tNedit_MakerCode.Text = dr.Cells[1].Value.ToString();
                this.tNedit_MakerName.Text = dr.Cells[2].Value.ToString();
            }
            if (selectCount <= 4)
            {

                if (this.deleteCombo.SelectedIndex != 0 && this.dataGrid.DataSource == this._resultTableMaker)
                {
                    return;
                }
                else
                {
                    if (this.tNedit_Code1.Text == "")
                    {
                        dr.Cells[0].Value = flag2;
                        selectCount++;
                        this.tNedit_Code1.Text = dr.Cells[1].Value.ToString();
                        this.tEdit_Name1.Text = dr.Cells[2].Value.ToString();
                    }
                    else
                    {
                        if (this.tNedit_Code2.Text == "")
                        {
                            dr.Cells[0].Value = flag2;
                            selectCount++;
                            this.tNedit_Code2.Text = dr.Cells[1].Value.ToString();
                            this.tEdit_Name2.Text = dr.Cells[2].Value.ToString();
                        }
                        else
                        {
                            if (this.tNedit_Code3.Text == "")
                            {
                                dr.Cells[0].Value = flag2;
                                selectCount++;
                                this.tNedit_Code3.Text = dr.Cells[1].Value.ToString();
                                this.tEdit_Name3.Text = dr.Cells[2].Value.ToString();
                            }
                            else
                            {
                                if (this.tNedit_Code4.Text == "")
                                {
                                    dr.Cells[0].Value = flag2;
                                    selectCount++;
                                    this.tNedit_Code4.Text = dr.Cells[1].Value.ToString();
                                    this.tEdit_Name4.Text = dr.Cells[2].Value.ToString();
                                }
                                else
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN01500UA",
                                        "これ以上指定出来ません",
                                        -1,
                                        MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 初期化Focus処理
        /// <summary>
        /// 初期化Focus処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 初期化Focus処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void PMKHN01500UA_Shown(object sender, EventArgs e)
        {
            //this.tEdit_SectionCode.Focus();//DEL by Liangsd     2011/08/30
            this.deleteCombo.Focus();//ADD by Liangsd    2011/08/30
        }
        #endregion

        #region チェックボックス処理
        /// <summary>
        /// チェックボックス処理
        /// </summary>
        /// <param name="table">今グリッドのデータ</param>
        /// <remarks>
        /// <br>Note       : チェックボックス処理を行い</br>
        /// <br>Programmer : 梁森東</br>
        /// <br>Date       : 2011/07/13</br>
        /// </remarks>
        private void CheckBoxAuto(SearchResultDataSet.ResultTableDataTable table)
        {
            ArrayList codeList = new ArrayList();
            if (table == this._resultTableMaker && this.deleteCombo.SelectedIndex != 0)
            {
                if (tNedit_MakerCode.GetInt() != 0)
                {
                    codeList.Add(tNedit_MakerCode.GetInt().ToString().Trim());
                }
            }

            if (tNedit_Code1.GetInt() != 0)
            {
                codeList.Add(tNedit_Code1.GetInt().ToString().Trim());
            }

            if (tNedit_Code2.GetInt() != 0)
            {
                codeList.Add(tNedit_Code2.GetInt().ToString().Trim());
            }

            if (tNedit_Code3.GetInt() != 0)
            {
                codeList.Add(tNedit_Code3.GetInt().ToString().Trim());
            }

            if (tNedit_Code4.GetInt() != 0)
            {
                codeList.Add(tNedit_Code4.GetInt().ToString().Trim());
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {


                if (table.Rows[i][1] != null
                    && codeList.Contains(table.Rows[i][1].ToString()))
                {
                    table.Rows[i][0] = true;
                }
                else
                {
                    table.Rows[i][0] = false;
                }
            }

        }
        #endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        public int Print(ref SFCMN06002C parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter;

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				       // 起動PGID
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;
            printInfo.rdData = this._deleteConditionAcs.DeleteListDataView;

            // 抽出条件の設定
            printInfo.jyoken = this._deleteConditionBak;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        private void rateComboEditor_ValueChanged(object sender, EventArgs e)
        {

        }
        // ---- ADD caohh 2011/07/21 ----<<<<

    }
}
