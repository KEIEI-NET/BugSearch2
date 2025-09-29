using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 登録プログラム選択画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 登録プログラム選択画面クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public partial class SFNETMENU2D : Form
    {

        /// <summary>
        /// 登録プログラム選択画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 登録プログラム選択画面コンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2D()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ユーザーメニュー編集画面表示制御処理
        /// </summary>
        /// <param name="strFilter">検索フィルター文字列</param>
        /// <param name="si">画面色情報</param>
        /// <returns>選択メニュー情報</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニュー編集画面表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public MenuItemInfomation[] ShowItemList(string strFilter, ScreenInfomation si)
        {

            btnSave.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Decision];
            btnCancel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Back];
            btnSave.ForeColor = si.ToolBarForeColor;                            //  2007.01.10  追加
            btnCancel.ForeColor = si.ToolBarForeColor;                          //  2007.01.10  追加

            CustomProfessionalRenderer cpr = new CustomProfessionalRenderer();
            try
            {
                cpr._ToolStripGradientBegin = si.ToolBarColor.ToolStripGradientBegin;
                cpr._ToolStripGradientMiddle = si.ToolBarColor.ToolStripGradientMiddle;
                cpr._ToolStripGradientEnd = si.ToolBarColor.ToolStripGradientEnd;
                cpr._ToolStripPanelGradientBegin = si.ToolBarColor.ToolStripPanelGradientBegin;
                cpr._ToolStripPanelGradientEnd = si.ToolBarColor.ToolStripPanelGradientEnd;
            }
            catch (Exception)
            {
                cpr._ToolStripGradientBegin = Color.LightBlue;
                cpr._ToolStripGradientMiddle = Color.WhiteSmoke;
                cpr._ToolStripGradientEnd = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientBegin = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientEnd = Color.LightSkyBlue;
            }
            barSub.Renderer = new ToolStripProfessionalRenderer(cpr);

            BackColor = si.ScreenBackColor;

            Cursor = Cursors.WaitCursor;

            lstItems.Items.Clear();
            ShowFilterList(strFilter);

            Cursor = Cursors.Default;

            if (Visible != true)
            {
                ShowDialog();
            }

            if (lstItems.SelectedIndices.Count > 0)
            {

                MenuItemInfomation[] mii = new MenuItemInfomation[lstItems.SelectedIndices.Count];
                for (int i = 0; i < lstItems.SelectedIndices.Count; i++)
                {
                    mii[i] = (MenuItemInfomation)lstItems.Items[lstItems.SelectedIndices[i]].Tag;
                }
                return mii;
            }


            return null;
        }

        /// <summary>
        /// 検索結果表示制御処理
        /// </summary>
        /// <param name="strFilter">検索フィルター文字列</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :検索結果表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int ShowFilterList(string strFilter)
        {
            try
            {

                //DataRow[] srchItemRows = SFNETMENU2Utilities.SearchProductItem(strFilter);            //  20069.09.26 変更
                DataRow[] srchItemRows = SFNETMENU2Utilities.SearchProductItem(strFilter, 0);
                for (int i = 0; i < srchItemRows.Length; i++)
                {
                    if (SystemCheck.CheckSystemPermissionFunction(srchItemRows[i]) != 0)
                    {
                        ListViewItem lvi = new ListViewItem();
                        //  明細を取得
                        MenuItemInfomation mii = new MenuItemInfomation();
                        mii.CategoryID = (int)srchItemRows[i]["CategoryID"];
                        mii.CategorySubID = (int)srchItemRows[i]["CategorySubID"];
                        mii.ItemID = (int)srchItemRows[i]["ItemID"];
                        mii.No = (int)srchItemRows[i]["No"];
                        mii.Pgid = srchItemRows[i]["Pgid"].ToString();
                        mii.Name = srchItemRows[i]["Name"].ToString();
                        mii.Parameter = srchItemRows[i]["Parameter"].ToString();
                        mii.Description = srchItemRows[i]["Description"].ToString();
                        //mii.IconType = srchItemRows[i]["IconType"].ToString();                        //  2006.09.29  削除
                        mii.IconIndex = (int)srchItemRows[i]["IconIndex"];
                        mii.IconName = srchItemRows[i]["IconName"].ToString();
                        //mii.SystemCode = srchItemRows[i]["SystemCode"].ToString();                    //  2006.09.29  削除
                        //mii.OptionCode = srchItemRows[i]["OptionCode"].ToString();                    //  2006.09.29  削除
                        mii.SysOpCode = srchItemRows[i]["SysOpCode"].ToString();                        //  2006.09.29  追加
                        mii.DisplayOption = srchItemRows[i]["DisplayOption"].ToString();
                        mii.SearchKeyWord = srchItemRows[i]["SearchKeyWord"].ToString();
                        mii.Rank = (int)srchItemRows[i]["Rank"];


                        //2009.02.10 sugi add↓
                        // ★ カテゴリを権限レベルを参照しフィルターをかける 
                        
                        //2009.02.10 sugi add↓

                         //  サポート専用のカテゴリ
                        if (mii.DisplayOption.ToUpper() == "S")
                        {
                            //  サポート以外には非表示
                            if (LoginInfoAcquisition.Employee.UserAdminFlag < 2) continue;
                        }

                        //  管理者専用のカテゴリ
                        else if (mii.DisplayOption.ToUpper() == "A")
                        {
                            //  サポートと管理者以外には非表示
                            if (LoginInfoAcquisition.Employee.UserAdminFlag == 0) continue;
                        }
                        //  サポートそれ以外のカテゴリはサポートには非表示
                        else
                        {
                            if (LoginInfoAcquisition.Employee.UserAdminFlag != 0) continue;
                        }
                        //2009.02.10 sugi add↑
                        //  明細からカテゴリを取得
                        //DataRow[] srchCategoryRows = SFNETMENU2Utilities.GetCategory("SuperFrontman", mii.CategoryID, true);      //  2006.09.29  変更
                        DataRow[] srchCategoryRows = SFNETMENU2Utilities.GetCategory(mii.CategoryID, true);
                        if (srchCategoryRows.Length > 0)
                        {
                            //  カテゴリ機能の使用可・不可の確認
                            if (SystemCheck.CheckSystemPermissionFunction(srchCategoryRows[0]) == 0)
                            {
                                continue;
                            }

                            //  サブカテゴリ
                            //DataRow[] SubCategoryRows = SFNETMENU2Utilities.GetProductItem((int)srchItemRows[i]["CategoryID"], (int)srchItemRows[i]["CategorySubID"]);        //  2006.09.29  変更
                            DataRow[] SubCategoryRows = SFNETMENU2Utilities.GetProductItem((int)srchItemRows[i]["CategoryID"], (int)srchItemRows[i]["CategorySubID"], 0);
                            if (SubCategoryRows.Length == 0)
                            {
                                continue;
                            }

                            // ★アイテム情報からカテゴリIDおよびサブカテゴリIDを取得し、それに対する権限レベルを確認する
                            DataRow[] CategoryRow = SFNETMENU2Utilities.GetCategory(mii.CategoryID, true);
                            DataRow[] SubCategoryRow = SFNETMENU2Utilities.GetSubCategory(mii.CategoryID, mii.CategorySubID);

                            bool CategoryCheck = false;
                            bool SubCategoryCheck = false;
                            bool ProductItemCheck = false;

                            if (CategoryRow.Length != 0 && SubCategoryRow.Length != 0)
                            {
                                CategoryCheck = SystemCheck.CheckAuthority(CategoryRow[0]);
                                SubCategoryCheck = SystemCheck.CheckAuthority(SubCategoryRow[0]);
                                ProductItemCheck = SystemCheck.CheckAuthority(srchItemRows[i]);
                            }

                            // 共に権限が無ければ表示できない(カテゴリ、サブカテゴリ、プロダクトアイテムチェック)
                            if (CategoryCheck == false || SubCategoryCheck == false || ProductItemCheck == false)
                            {
                                continue;
                            }

                            //  カテゴリ名を設定
                            lvi.Text = srchCategoryRows[0]["Name"].ToString();
                            //  明細からサブカテゴリを取得
                            DataRow[] srchSubCategoryRows = SFNETMENU2Utilities.GetSubCategory(mii.CategoryID,mii.CategorySubID);
                            if (srchSubCategoryRows.Length > 0)
                            {
                                if (SystemCheck.CheckSystemPermissionFunction(SubCategoryRows[0]) == 0)
                                {
                                    continue;
                                }
                                if (SystemCheck.CheckSystemPermissionFunction(srchSubCategoryRows[0]) != 0)
                                {
                                    //  サブカテゴリ名を設定
                                    ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                                    lvsi.Text = srchSubCategoryRows[0]["Name"].ToString().Replace("\\n", "");
                                    lvi.SubItems.Add(lvsi);
                                    ListViewItem.ListViewSubItem lvsi2 = new ListViewItem.ListViewSubItem();
                                    lvsi2.Text = mii.Name.Replace("\\n", "");
                                    lvi.SubItems.Add(lvsi2);
                                    ListViewItem.ListViewSubItem lvsi3 = new ListViewItem.ListViewSubItem();
                                    lvsi3.Text = mii.Description.Replace("\\n", ",");
                                    lvi.SubItems.Add(lvsi3);

                                    lvi.Tag = mii;
                                    lstItems.Items.Add(lvi);
                                }
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                return 9;
            }
        }

        /// <summary>
        /// 確定ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// 戻るボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        /// <summary>
        /// アイテムダブルクリック時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// 権限レベルの確認
        /// </summary>
        /// <param name="targetRow">対象レコード</param>
        /// <returns>ture:権限有 false:権限無</returns>
        /// <remarks>
        /// <br>Note        :権限レベルの確認</br>
        /// <br>Programmer  : 20008 伊藤　豊</br>
        /// <br>Date        : 2007.06.19</br>
        /// </remarks>
        private bool CheckAuthorityLevel(DataRow targetRow)
        {
            //targetRow[""]

            return false;
        }

    }
}