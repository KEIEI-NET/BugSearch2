using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ユーザーメニュー編集画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザーメニュー編集画面クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.21 鹿野　幸生</br>
    /// <br></br>
    /// <br>Update Note: 2010/02/22 21024　佐々木 健</br>
    /// <br>             グループ名称変更ボタンを押した後、名称を変更せずに確定するとエラーになる不具合の修正(MANTIS[0015019])</br>
    /// </remarks>
    public partial class SFNETMENU2C : Form
    {

        SFNETMENU2D listItemWin = new SFNETMENU2D();
        private int PastGroupNo = -1;

        private ScreenInfomation _msi;

        /// <summary>
        /// ユーザーメニュー編集画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーメニュー編集画面コンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2C()
        {
            InitializeComponent();
            PastGroupNo = -1;
        }

        /// <summary>
        /// ユーザーメニューカテゴリクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーメニューカテゴリ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        private class UserCategoryInfomation
        {
            public int UserCategoryID;
            public string Name;
            public int No;
            public ArrayList arUserItemInfo = new ArrayList();
        }

        /// <summary>
        /// ユーザーメニューアイテムクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーメニューアイテムクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        private class UserItemInfomation
        {
            public int UserCategoryID;
            public int CategoryID;
            public int CategorySubID;
            public int ItemID;
            public int No;
            public string Name;
            public string Description;

        }

        /// <summary>
        /// ユーザーメニュー編集画面表示制御処理
        /// </summary>
        /// <param name="si">画面色情報</param>
        /// <returns>ダイアログ結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニュー編集画面表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public DialogResult ShowUserMenu(ScreenInfomation si)
        {
            _msi = si;

            btnSave.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Decision];
            btnCancel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Back];
            btnSave.ForeColor = si.ToolBarForeColor;
            btnCancel.ForeColor = si.ToolBarForeColor;

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


            lstUserSubCategroy.Items.Clear();
            lstItem.Items.Clear();

            //DataRow[] UserCategoryRows = SFNETMENU2Utilities.GetUserCategoryGroup(0);     //  2007.01.10  変更
            DataRow[] UserCategoryRows = SFNETMENU2Utilities.GetUserCategoryGroup(-1);
            for (int i = 0; i < UserCategoryRows.Length; i++)
            {
                UserCategoryInfomation uci = new UserCategoryInfomation();
                uci.UserCategoryID = (int)UserCategoryRows[i]["CategorySubID"];
                uci.Name = UserCategoryRows[i]["Name"].ToString();
                uci.No = (int)UserCategoryRows[i]["No"];
                ListViewItem lvc = new ListViewItem();
                lvc.Text = uci.Name;
                lvc.Tag = uci;
                lstUserSubCategroy.Items.Add(lvc);
                uci.arUserItemInfo.Clear();
                DataRow[] UserItemRows = SFNETMENU2Utilities.GetUserItem(uci.UserCategoryID);//調整する
                for (int j = 0; j < UserItemRows.Length; j++)
                {
                    
                    UserItemInfomation uii = new UserItemInfomation();
                    uii.UserCategoryID = uci.UserCategoryID; //調整する
                    uii.CategoryID = (int)UserItemRows[j]["CategoryID"];
                    uii.CategorySubID = (int)UserItemRows[j]["CategorySubID"];
                    uii.ItemID = (int)UserItemRows[j]["ItemID"];
                    uii.No = (int)UserItemRows[j]["No"];
                    uii.Name = UserItemRows[j]["Name"].ToString().Replace("\\n", "");
                    uii.Description = UserItemRows[j]["Description"].ToString().Replace("\\n", ",");

                    uci.arUserItemInfo.Add(uii);

                }

            }

            if (lstUserSubCategroy.Items.Count > 0)
            {
                PastGroupNo = -1;
                lstUserSubCategroy.SelectedIndices.Add(0);
            }
            PastGroupNo = -1;

            return ShowDialog();

        }

        /// <summary>
        /// グループ追加ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubAdd_Click(object sender, EventArgs e)
        {
            int CateGoryID = 1;
            //bool bLoopBreak = false;
            while (true)
            {
                bool bUnique = true;
                for (int i=0;i<lstUserSubCategroy.Items.Count;i++)
                {
                    UserCategoryInfomation uci_tmp = (UserCategoryInfomation)lstUserSubCategroy.Items[i].Tag;

                    if (CateGoryID == uci_tmp.UserCategoryID)
                    {
                        bUnique = false;
                        break;
                    }
                }
                if (bUnique == false)
                {
                    CateGoryID++;
                }
                else
                {
                    break;
                }
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = "グループ" + CateGoryID.ToString();
            UserCategoryInfomation uci = new UserCategoryInfomation();
            uci.UserCategoryID = CateGoryID;
            uci.Name = lvi.Text;
            uci.No = lstUserSubCategroy.Items.Count;
            lvi.Tag = uci;
            ListViewItem lvia = lstUserSubCategroy.Items.Add(lvi);
            lvia.Checked = true;
            
        }

        /// <summary>
        /// 名前変更ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubNameChange_Click(object sender, EventArgs e)
        {
            if (lstUserSubCategroy.SelectedIndices.Count == 0)
                return;

            lstUserSubCategroy.LabelEdit = true;
            lstUserSubCategroy.Items[lstUserSubCategroy.SelectedIndices[0]].BeginEdit();

        }

        /// <summary>
        /// グループ名編集後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUserSubCategroy_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            lstUserSubCategroy.LabelEdit = false;
            // 2010/02/22 >>>
            //UserCategoryInfomation uci = (UserCategoryInfomation)lstUserSubCategroy.Items[e.Item].Tag;
            //uci.Name = e.Label;
            if (e.Label != null)
            {
                UserCategoryInfomation uci = (UserCategoryInfomation)lstUserSubCategroy.Items[e.Item].Tag;
                uci.Name = e.Label;
            }
            // 2010/02/22 <<<
        }

        /// <summary>
        /// グループ削除ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubDelete_Click(object sender, EventArgs e)
        {

            if (lstUserSubCategroy.SelectedIndices.Count == 0)
            {
                return;
            }


            UserCategoryInfomation uci = (UserCategoryInfomation)lstUserSubCategroy.SelectedItems[0].Tag;
            for (int i=uci.arUserItemInfo.Count-1;i>=0;i--)
            {
                UserItemInfomation ui = (UserItemInfomation)uci.arUserItemInfo[i];
                if (uci.UserCategoryID == ui.UserCategoryID)
                {
                    uci.arUserItemInfo.RemoveAt(i);
                }
            }
            lstItem.Items.Clear();
            lstUserSubCategroy.Items.RemoveAt(lstUserSubCategroy.SelectedIndices[0]);
            PastGroupNo = -1;


        }

        /// <summary>
        /// フォームアクティブ発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2C_Activated(object sender, EventArgs e)
        {
            lstUserSubCategroy.Columns[0].Width = lstUserSubCategroy.ClientSize.Width;
        }


        /// <summary>
        /// アイテム追加ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            if (lstUserSubCategroy.SelectedItems.Count > 0)
            {
                MenuItemInfomation[] mii = listItemWin.ShowItemList("", _msi);
                if ((listItemWin.DialogResult == DialogResult.OK) && (mii != null))
                {
                    UserCategoryInfomation uci = (UserCategoryInfomation)lstUserSubCategroy.SelectedItems[0].Tag;
                    for (int i = 0; i < mii.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        UserItemInfomation uii = new UserItemInfomation();
                        uii.UserCategoryID = uci.UserCategoryID;
                        uii.CategoryID = mii[i].CategoryID;
                        uii.CategorySubID = mii[i].CategorySubID;
                        uii.ItemID = mii[i].ItemID;
                        uii.No = mii[i].No;
                        uii.Name = mii[i].Name.Replace("\\n", "");
                        uii.Description = mii[i].Description.Replace("\\n", ",");
                        lvi.Text = uii.Name;
                        lvi.Tag = uii;
                        ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = uii.Description;
                        lvi.SubItems.Add(lvsi);
                        lstItem.Items.Add(lvi);
                        uci.arUserItemInfo.Add(uii);
                    }
                }
            }
            else
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "選択エラー", "機能を追加したいグループを選択してください", "");
            }

        }

        /// <summary>
        /// 確定ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            //  現状のユーザー設定を削除
            SFNETMENU2Utilities.ClearUserCategory();
            SFNETMENU2Utilities.ClearUserItem();

            //  ユーザーカテゴリ
            for (int i = 0; i < lstUserSubCategroy.Items.Count; i++)
            {
                UserCategoryInfomation uci = (UserCategoryInfomation)lstUserSubCategroy.Items[i].Tag;
                SFNETMENU2Utilities.AddUserCategory(uci.UserCategoryID, uci.Name,uci.No);
                for (int j = 0; j < uci.arUserItemInfo.Count; j++)
                {
                    UserItemInfomation uii = (UserItemInfomation)uci.arUserItemInfo[j];
                    SFNETMENU2Utilities.AddUserItem(uci.UserCategoryID, uii.CategoryID, uii.CategorySubID, uii.ItemID, uii.No);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// サブカテゴリ選択時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUserSubCategroy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lstUserSubCategroy.SelectedIndices.Count != 0) && (lstUserSubCategroy.SelectedIndices[0] != PastGroupNo))
            {
                //  選択されたインデックスを表示
                //  現在のインデックスに設定
                PastGroupNo = lstUserSubCategroy.SelectedIndices[0];
                PullUserItemInfo(PastGroupNo);
            }

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
        /// ユーザーアイテム削除ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            if ((lstUserSubCategroy.SelectedIndices.Count != 0) && (lstItem.SelectedIndices.Count != 0))
            {
                lstItem.Items.RemoveAt(lstItem.SelectedIndices[0]);
                UserCategoryInfomation uci = (UserCategoryInfomation)lstUserSubCategroy.SelectedItems[0].Tag;
                uci.arUserItemInfo.Clear();
                for (int i = 0; i < lstItem.Items.Count; i++)
                {
                    uci.arUserItemInfo.Add((UserItemInfomation)lstItem.Items[i].Tag);
                }
            }
            else
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "選択エラー", "削除する機能を選択してください。", "");
            }

        }

        /// <summary>
        /// ユーザーアイテム取得処理
        /// </summary>
        /// <param name="NowIndex">対象インデックス</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーアイテム取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int PullUserItemInfo(int NowIndex)
        {

            if (NowIndex == -1)
            {
                return -1;
            }

            lstItem.Items.Clear();

            UserCategoryInfomation uci;
            if (lstUserSubCategroy.Items[NowIndex].Tag == null)
            {
                return  -3;
            }
            else
            {
                uci = (UserCategoryInfomation)lstUserSubCategroy.Items[NowIndex].Tag;
            }
            for (int i = 0; i < uci.arUserItemInfo.Count; i++)
            {
                UserItemInfomation uii = (UserItemInfomation)uci.arUserItemInfo[i];
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = uii;
                lvi.Text = uii.Name;
                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = uii.Description;
                lvi.SubItems.Add(lvsi);
                lstItem.Items.Add(lvi);
            }

            return 0;

        }

    }

}