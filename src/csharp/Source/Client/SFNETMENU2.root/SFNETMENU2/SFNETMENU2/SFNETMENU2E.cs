using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// オプション関連設定画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : オプション関連設定画面クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.29 鹿野　幸生</br>
    /// <br>Update Note: 2007.01.10 鹿野　幸生</br>
    /// </remarks>
    public partial class SFNETMENU2E : Form
    {

        private bool bShowing = false;
        private bool bBeforeActive = true;

        private const string cThemeKey1 = "4hJ";
        private bool CreateSystemColor = false;

        private SFNETMENU2F winCustomCreateTheme = new SFNETMENU2F();
        private SFNETMENU2G winCustomRenameTheme = new SFNETMENU2G();

        private const string cThemeKey4 = "3";
        private class SubCategoryInfomationWithNo
        {
            public int DspNo = 0;
            public SubCategoryInfomation SubCategoryInfo = new SubCategoryInfomation();
        }
        private class MenuItemInfoComparer : IComparer    // ソート(比較)のユーザ定義文
        {
            public int Compare(object x, object y)                  // 定型文
            {
                SubCategoryInfomationWithNo mi1 = (SubCategoryInfomationWithNo)x;
                SubCategoryInfomationWithNo mi2 = (SubCategoryInfomationWithNo)y;

                return mi1.DspNo - mi2.DspNo;
            }
        }

        private string gBootDir;
        private string gNavigationDir;
        private const string cThemeKey3 = "1sd4";
        private const int cSubMenuFig = 24;                                     //  2007.01.10  追加

        private ScreenThemeInfomation _mScreenThemeInfomation = new ScreenThemeInfomation();
        private SystemSettingInfomation _mSystemSettingInfomation = new SystemSettingInfomation();
        private SystemMenuInfomation _mSystemMenuInfomation = new SystemMenuInfomation();
        private ScreenInfomation _mScreenInfomationSave = new ScreenInfomation();
        private ScreenInfomation _mScreenInfomation = new ScreenInfomation();
        private const string cThemeKey5 = "tDh30L";

        private BasicSetting MenuLabel = new BasicSetting();
        private class BasicSetting2 : BasicSetting
        {
        }
        private BasicSetting2 StatusBarLabel = new BasicSetting2();
        private ToolBarSetting ToolbarLabel = new ToolBarSetting();
        private CategoryInfoSetting CartegroyLabel = new CategoryInfoSetting();
        private SubCategorySetting SubCartegroyList = new SubCategorySetting();
        private CategorySetting CategroyButton = new CategorySetting();
        private SubMenuSetting SubMenuButton = new SubMenuSetting();
        private BackgroundSetting BackScreen = new BackgroundSetting();
        DataRow[] gTopCategory;                                                         //  2006.09.29  追加
        private const string cThemeKey2 = "5s";
        private ArrayList arTopCategory = new ArrayList();

        /// <summary>
        /// オプション関連設定画面コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :オプション関連設定画面コンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2E()
        {
            InitializeComponent();
        }

        /// <summary>
        /// オプション関連設定表示制御処理
        /// </summary>
        /// <param name="smif">メニュー設定情報</param>
        /// <param name="sif">画面色情報</param>
        /// <param name="ssif">システム設定情報</param>
        /// <param name="wrkPath">カレントディレクトリ</param>
        /// <param name="SystemSettingMode">システム提供設定情報作成有無</param>
        /// <returns>ダイアログ結果</returns>
        /// <remarks>
        /// <br>Note       :オプション関連設定表示制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public DialogResult ShowSetting(string[] Products, ref SystemMenuInfomation smif, ref ScreenInfomation sif, ref SystemSettingInfomation ssif, string BootDir, string NavigationDir, bool SystemSettingMode)
        {

            bShowing = true;            //  ダイアログ表示処理中
            bBeforeActive = true;       //  アクティブイベント未発生

            gBootDir = BootDir;
            gNavigationDir = NavigationDir;

            btnSave.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Decision];
            btnCancel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Back];
            btnSave.ForeColor = sif.ToolBarForeColor;
            btnCancel.ForeColor = sif.ToolBarForeColor;

            //  内部変数に保存
            _mSystemMenuInfomation = smif;
            _mScreenInfomation = sif;
            _mScreenInfomationSave = sif.Copy();
            _mSystemSettingInfomation = ssif;

            CreateSystemColor = SystemSettingMode;

            //  画面を初期化
            tabSetting.SelectedIndex = 0;;
            grdProperty.SelectedObject = null;

            //  メニュー情報を設定(全件取得)------------------------------------------------------
            //gTopCategory = SFNETMENU2Utilities.GetCategory(Products);             //  2006.09.29  変更
            gTopCategory = SFNETMENU2Utilities.GetCategory(Products, true);
            cmbCategory.Items.Clear();
            lstSubMenu.Items.Clear();
            arTopCategory.Clear();                                                  //  2006.09.29  追加
            int idxSelect = -1;
            for (int i = 0; i < gTopCategory.Length; i++)
            {
                // ★ カテゴリを権限レベルを参照しフィルターをかける 
                bool CategoryCheck = false;

                if (gTopCategory.Length != 0)
                {
                    CategoryCheck = SystemCheck.CheckAuthority(gTopCategory[i]);
                }

                // 権限が無ければ表示できない
                if (CategoryCheck == false)
                {
                    continue;
                }
                //2009.02.10 sugi add↓
                if (gTopCategory[i]["DisplayOption"].ToString().ToUpper() == "I")
                {
                    continue;
                }

                    //  サポート専用のカテゴリ
                else if (gTopCategory[i]["DisplayOption"].ToString().ToUpper() == "S")
                {
                    //  サポート以外には非表示
                    if (LoginInfoAcquisition.Employee.UserAdminFlag < 2) continue;
                }

                //  管理者専用のカテゴリ
                else if (gTopCategory[i]["DisplayOption"].ToString().ToUpper() == "A")
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

                if (SystemCheck.CheckSystemPermissionFunction(gTopCategory[i]) != 0)
                {
                    arTopCategory.Add(gTopCategory[i]);                             //  2006.09.29  追加
                    cmbCategory.Items.Add(gTopCategory[i]["Name"].ToString());
                    if ((int)gTopCategory[i]["CategoryID"] == smif.SelectCategory)
                    {
                        //idxSelect = i;                                            //  2006.09.29  変更
                        idxSelect = arTopCategory.Count-1;    
                    }

                }
            }
            cmbCategory.Items.Add("お気に入り");    //  2009.02.10  sugi 変更（ユーザーメニュー）
            if (idxSelect != -1)
            {
                //  通常メニュー
                cmbCategory.SelectedIndex = idxSelect;
            }
            else
            {
                if (_mSystemMenuInfomation.SelectCategory > 0)
                {
                    _mSystemMenuInfomation.SelectCategory = 0;
                    cmbCategory.SelectedIndex = -1;
                }
                else
                {
                    //  ユーザーメニュー
                    cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;
                }
            }
            System.Windows.Forms.Application.DoEvents();

            //  色情報を設定------------------------------------------------------

            //  システムテーマを取得
            cmbTheme.Items.Clear();
            _mScreenThemeInfomation.ThemeFig = 0;
            _mScreenThemeInfomation.SceenTehme.Clear();
            try
            {
                //  読み込み失敗なら初期値設定
                try
                {

                    BinaryFormatter formatter = new BinaryFormatter();
                    FileEncryptgraphy fe = new FileEncryptgraphy(cThemeKey1 + cThemeKey2 + cThemeKey3 + cThemeKey4 + cThemeKey5);

                    MemoryStream ms = fe.DecryptFile(Path.Combine(gNavigationDir, SFNETMENU2SettingInfomation.ThemeBinary));

                    _mScreenThemeInfomation = (ScreenThemeInfomation)formatter.Deserialize(ms);

                }
                catch (Exception)
                {
                    _mScreenThemeInfomation = new ScreenThemeInfomation();
                }

                for (int i = 0; i < _mScreenThemeInfomation.ThemeFig; i++)
                {
                    cmbTheme.Items.Add(((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[i]).ThemeName);
                }

            }
            catch (Exception)
            {
                _mScreenThemeInfomation = new ScreenThemeInfomation();
            }


            if (sif.SystemServe == true)
            {
                cmbTheme.SelectedIndex = -1;
                for (int i = 0; i < _mScreenThemeInfomation.ThemeFig; i++)
                {
                    if (((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[i]).ThemeID == sif.ThemeID)
                    {
                        cmbTheme.SelectedIndex = i;
                        break;
                    }
                }
                if (cmbTheme.SelectedIndex == -1)
                {
                    sif.SystemServe = false;
                }
            }
            else
            {
                try
                {
                    cmbTheme.Items.Add(sif.ThemeName);
                    cmbTheme.SelectedIndex = cmbTheme.Items.Count - 1;
                }
                catch
                {
                }
            }

            if (sif.SystemServe == true)
            {
                btnDelCustom.Visible = false;
                btnRenameCustom.Visible = false;
                grdProperty.Enabled = false;
                chkFocusBorder.Enabled = false;
            }
            else
            {
//                btnDelCustom.Visible = true;
                btnRenameCustom.Visible = true;
                grdProperty.Enabled = true;
                chkFocusBorder.Enabled = true;
            }
            //  システムカラー作成時は特殊
            if (CreateSystemColor == true)
            {
                btnDelCustom.Visible = true;
                btnRenameCustom.Visible = true;
                grdProperty.Enabled = true;
                chkFocusBorder.Enabled = true;
            }

            //  色情報を設定
            SetPropertyInfomation(sif);
            ChangeMenuColor(null);

            //  その他画面を設定------------------------------------------------------------
            chkShowDialog.Checked = ssif.ShowDialog;
            txtTime.Text = ssif.DialogTimerInterval.ToString();
            chkFuncKey.Checked = ssif.FuncKeyEnabled;
            chkNumKey.Checked = ssif.NumKeyEnabled;
            txtRecent.Text = ssif.MaxRecentFig.ToString();
            chkSavePosition.Checked = ssif.SaveLastPosition;
            chkSaveSize.Checked = ssif.SaveLastSize;
            lstDate.Items.Clear();
            chkShftKey.Checked = ssif.ShiftKeyPriority;
            cmbCategoryPriority.SelectedIndex = ssif.CategoryPriority;
            chkTabAutoDelete.Checked = ssif.TabAutoDelete;
            chkTopMenu.Checked = ssif.TopMenu;              //  2008.09.26 sugi 
            for (int i = 0; i < SFNETMENU2Utilities.CallndarTypeFig; i++)
            {
                int idx = i;
                lstDate.Items.Add(SFNETMENU2Utilities.GetCalendar(ref idx));

            }
            lstDate.SelectedIndex = ssif.DateTimeFormat;


            lstSubMenu.Columns[0].Width = lstSubMenu.ClientSize.Width - 2;              //  2006.09.29  追加

            bShowing = false;


            return ShowDialog();

        }

        /// <summary>
        /// 第二画面カテゴリラベル選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCategory_Click(object sender, EventArgs e)
        {

            grdProperty.SelectedObject = CartegroyLabel;
            lblSelectItem.Text = "選択カテゴリ";

        }

        /// <summary>
        /// 第二画面プロパティグリッド値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                try
                {
                    if (grdProperty.SelectedObject.GetType() == typeof(BasicSetting))
                    {
                        _mScreenInfomation.MenuBarForeColor = MenuLabel.ForeColor;
                        _mScreenInfomation.MenuBarBackColor = MenuLabel.BackColor;
                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(BasicSetting2))
                    {
                        _mScreenInfomation.StatusBarForeColor = StatusBarLabel.ForeColor;
                        _mScreenInfomation.StatusBarBackColor = StatusBarLabel.BackColor;
                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(ToolBarSetting))
                    {
                        _mScreenInfomation.ToolBarColor = new CustomToolBarRenderer();//test
                        _mScreenInfomation.ToolBarForeColor = ToolbarLabel.ToolStripForeColor;
                        _mScreenInfomation.ToolBarColor.ToolStripGradientBegin = ToolbarLabel.ToolStripGradientBegin;
                        _mScreenInfomation.ToolBarColor.ToolStripGradientMiddle = ToolbarLabel.ToolStripGradientMiddle;
                        _mScreenInfomation.ToolBarColor.ToolStripGradientEnd = ToolbarLabel.ToolStripGradientEnd;
                        _mScreenInfomation.ToolBarColor.ToolStripPanelGradientBegin = ToolbarLabel.ToolStripPanelGradientBegin;
                        _mScreenInfomation.ToolBarColor.ToolStripPanelGradientEnd = ToolbarLabel.ToolStripPanelGradientEnd;
                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(CategoryInfoSetting))
                    {
                        _mScreenInfomation.CategoryLabelForeColor = CartegroyLabel.ForeColor;
                        _mScreenInfomation.CategoryLabelBackColor1 = CartegroyLabel.BackColor1;
                        _mScreenInfomation.CategoryLabelBackColor2 = CartegroyLabel.BackColor2;
                        _mScreenInfomation.CategoryLabelGradiationMode = CartegroyLabel.GradiationMode;
                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(SubCategorySetting))
                    {
                        _mScreenInfomation.SubCategoryForeColor = SubCartegroyList.ForeColor;
                        _mScreenInfomation.SubCategoryBackColor = SubCartegroyList.BackColor;
                        _mScreenInfomation.SubCategoryBackImage = SubCartegroyList.BackgroundImage;
                        _mScreenInfomation.SubCategoryBackImageTiled = SubCartegroyList.BackgroundImageTiled;


                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(CategorySetting))
                    {
                        _mScreenInfomation.CategoryForeColor = CategroyButton.ForeColor;
                        _mScreenInfomation.CategoryBackColor1 = CategroyButton.BackColor1;
                        _mScreenInfomation.CategoryBackColor2 = CategroyButton.BackColor2;
                        _mScreenInfomation.CategoryBackColor2 = CategroyButton.BackColor2;
                        _mScreenInfomation.CategoryGradiationMode = CategroyButton.GradiationMode;
                        _mScreenInfomation.CategoryButtonBackColor1 = CategroyButton.ButtonBackColor1;
                        _mScreenInfomation.CategoryButtonBackColor2 = CategroyButton.ButtonBackColor2;
                        _mScreenInfomation.CategoryButtonGradiationMode = CategroyButton.ButtonGradiationMode;
                        _mScreenInfomation.CategorySelectedButtonForeColor = CategroyButton.SelectedButtonForeColor;
                        _mScreenInfomation.CategorySelectedButtonFaceColor1 = CategroyButton.SelectedButtonFaceColor1;
                        _mScreenInfomation.CategorySelectedButtonFaceColor2 = CategroyButton.SelectedButtonFaceColor2;
                        _mScreenInfomation.CategoryBackImage = CategroyButton.BackgroundImage;
                        _mScreenInfomation.CategoryBackImageLayout = CategroyButton.BackgroundImageLayout;
                        _mScreenInfomation.CategoryActivePanelBorderColor = CategroyButton.ActivePanelBorderColor;
                        _mScreenInfomation.CategoryFocusButtonBorderColor = CategroyButton.FocusButtonBorderColor;
                        _mScreenInfomation.CategoryHotTrackingColor = CategroyButton.HotTrackingColor;

                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(SubMenuSetting))
                    {

                        _mScreenInfomation.SubMenuForeColor = SubMenuButton.ForeColor;
                        _mScreenInfomation.SubMenuBackColor1 = SubMenuButton.BackColor1;
                        _mScreenInfomation.SubMenuBackColor2 = SubMenuButton.BackColor2;
                        _mScreenInfomation.SubMenuGradiationMode = SubMenuButton.GradiationMode;
                        _mScreenInfomation.SubMenuHeaderForeColor = SubMenuButton.HeaderForeColor;
                        _mScreenInfomation.SubMenuHeaderBackColor1 = SubMenuButton.HeaderBackColor1;
                        _mScreenInfomation.SubMenuHeaderBackColor2 = SubMenuButton.HeaderBackColor2;
                        _mScreenInfomation.SubMenuHeaderGradiationMode = SubMenuButton.HeaderGradiationMode;
                        _mScreenInfomation.SubMenuHeaderActiveForeColor = SubMenuButton.HeaderActiveForeColor;
                        _mScreenInfomation.SubMenuButtonBackColor1 = SubMenuButton.ButtonBackColor1;
                        _mScreenInfomation.SubMenuButtonBackColor2 = SubMenuButton.ButtonBackColor2;
                        _mScreenInfomation.SubMenuButtonGradiationMode = SubMenuButton.ButtonGradiationMode;
                        _mScreenInfomation.SubMenuSelectedButtonForeColor = SubMenuButton.SelectedButtonForeColor;
                        _mScreenInfomation.SubMenuSelectedButtonFaceColor1 = SubMenuButton.SelectedButtonFaceColor1;
                        _mScreenInfomation.SubMenuSelectedButtonFaceColor2 = SubMenuButton.SelectedButtonFaceColor2;
                        _mScreenInfomation.SubMenuBackImage = SubMenuButton.BackgroundImage;
                        _mScreenInfomation.SubMenuBackImageLayout = SubMenuButton.BackgroundImageLayout;
                        _mScreenInfomation.SubMenuDescForeColor = SubMenuButton.DescForeColor;
                        _mScreenInfomation.SubMenuDescBackColor1 = SubMenuButton.DescBackColor1;
                        _mScreenInfomation.SubMenuDescBackColor2 = SubMenuButton.DescBackColor2;
                        _mScreenInfomation.SubMenuDescGradientMode = SubMenuButton.DescGradiationMode;
                        _mScreenInfomation.SubMenuDescLineColor = SubMenuButton.DescLineColor;
                        _mScreenInfomation.SubMenuActivePanelBorderColor = SubMenuButton.ActivePanelBorderColor;
                        _mScreenInfomation.SubMenuFocusButtonBorderColor = SubMenuButton.FocusButtonBorderColor;
                        _mScreenInfomation.SubMenuHotTrackingColor = SubMenuButton.HotTrackingColor;

                    }
                    else if (grdProperty.SelectedObject.GetType() == typeof(BackgroundSetting))
                    {

                        _mScreenInfomation.ScreenBackColor = BackScreen.ScreenBackColor;
                        _mScreenInfomation.TabPageBackColor = BackScreen.TabPageBackColor;
                        _mScreenInfomation.TabPageBackImage = BackScreen.TabPageBackImage;
                        _mScreenInfomation.TabPageBackImageLayout = BackScreen.TabPageBackImageLayout;
                    }

                    ChangeMenuColor(grdProperty.SelectedObject);


                }
                catch (Exception)
                {

                }
            }
            finally
            {
                Directory.SetCurrentDirectory(gBootDir);
            }

        }

        /// <summary>
        /// 第二画面カテゴリ描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCategory_Paint(object sender, PaintEventArgs e)
        {
            //たてに白から黒へのグラデーションのブラシを作成
            //g.VisibleClipBoundsは表示クリッピング領域に外接する四角形
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, CartegroyLabel.BackColor1, CartegroyLabel.BackColor2, CartegroyLabel.GradiationMode);

            //四角を描く
            e.Graphics.FillRectangle(myBrush, e.Graphics.VisibleClipBounds);

            //ボタンのTextを描画する準備
            StringFormat sf = new StringFormat();
            //文字列を真ん中に描画
            if (((Label)sender).TextAlign.ToString().IndexOf("left", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.Alignment = StringAlignment.Near;
            }
            else if (((Label)sender).TextAlign.ToString().IndexOf("center", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.Alignment = StringAlignment.Center;
            }
            else
            {
                sf.Alignment = StringAlignment.Far;
            }
            if (((Label)sender).TextAlign.ToString().IndexOf("top", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.LineAlignment = StringAlignment.Near;
            }
            else if (((Label)sender).TextAlign.ToString().IndexOf("middle", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.LineAlignment = StringAlignment.Center;
            }
            else
            {
                sf.LineAlignment = StringAlignment.Far;
            }
            //Brushの作成
            Brush brsh = new SolidBrush(CartegroyLabel.ForeColor);
            //文字列を描画
            e.Graphics.DrawString(((Label)sender).Text, ((Label)sender).Font, brsh, ((Label)sender).ClientRectangle, sf);

            //リソースを開放する
            brsh.Dispose();
            myBrush.Dispose();
            e.Dispose();

        }

        /// <summary>
        /// 第二画面サブカテゴリ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubCategory_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = SubCartegroyList;
            lblSelectItem.Text = "サブカテゴリ";
        }

        /// <summary>
        /// 第二画面カテゴリ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpCategory_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = CategroyButton;
            lblSelectItem.Text = "カテゴリ";

        }

        /// <summary>
        /// 第二画面サブメニュー選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpSubMenu_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = SubMenuButton;
            lblSelectItem.Text = "サブメニュー(選択サブカテゴリ)";
        }

        /// <summary>
        /// 第二画面サブメニュー選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpSubMenu2_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = SubMenuButton;
            lblSelectItem.Text = "サブメニュー(選択サブカテゴリ)";

        }

        /// <summary>
        /// 第二画面タブ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabBase_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = BackScreen;
            lblSelectItem.Text = "タブ背景";

        }

        /// <summary>
        /// 第二画面タブ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = BackScreen;
            lblSelectItem.Text = "タブ背景";

        }

        /// <summary>
        /// 第一画面カテゴリ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bShowing == false)
            {
                try
                {

                    //if ((int)gTopCategory[cmbCategory.SelectedIndex]["CategoryID"] == _mSystemMenuInfomation.SelectCategory)          //  2006.09.29  変更
                    if ((int)((DataRow)arTopCategory[cmbCategory.SelectedIndex])["CategoryID"] == _mSystemMenuInfomation.SelectCategory)
                    {
                        return;
                    }
                }
                catch
                { }
            }

            if (cmbCategory.SelectedIndex != cmbCategory.Items.Count - 1)
            {
                //_mSystemMenuInfomation.SelectCategory = (int)gTopCategory[cmbCategory.SelectedIndex]["CategoryID"];       //  2006.09.29 変更
                _mSystemMenuInfomation.SelectCategory = (int)((DataRow)arTopCategory[cmbCategory.SelectedIndex])["CategoryID"];
            }
            else
            {
                _mSystemMenuInfomation.SelectCategory = -101;
            }
            if (bShowing == false)
            {
                _mSystemMenuInfomation.SelectSubMenuCollection.Clear();
            }
            DataRow[] CategoryInfo;
            if (cmbCategory.SelectedIndex != cmbCategory.Items.Count - 1)
            {

                CategoryInfo = SFNETMENU2Utilities.GetSubCategoryGroup(_mSystemMenuInfomation.SelectCategory);
            }
            else
            {
                //CategoryInfo = SFNETMENU2Utilities.GetUserCategoryGroup(-101);    //  2007.01.10  変更
                CategoryInfo = SFNETMENU2Utilities.GetUserCategoryGroup(-1);
            }
            lstSubMenu.Items.Clear();
            for (int i = 0; i < CategoryInfo.Length; i++)
            {

                // ★ サブカテゴリを権限レベルを参照しフィルターをかける
                bool SubCategoryCheck = false;

                if (CategoryInfo.Length != 0)
                {
                    SubCategoryCheck = SystemCheck.CheckAuthority(CategoryInfo[i]);
                }

                // 権限が無ければ表示できない
                if (SubCategoryCheck == false)
                {
                    continue;
                }

                ListViewItem lvi = new ListViewItem();
                if (SystemCheck.CheckSystemPermissionFunction(CategoryInfo[i]) != 0)
                {
                    lvi.Text = CategoryInfo[i]["Name"].ToString();
                }
                else
                {
                    lvi.Text = "";
                }
                SubCategoryInfomation ci = new SubCategoryInfomation();
                ci.CategoryID = (int)CategoryInfo[i]["CategoryID"];
                ci.CategorySubID = (int)CategoryInfo[i]["CategorySubID"];
                ci.No = (int)CategoryInfo[i]["No"];
                ci.Name = CategoryInfo[i]["Name"].ToString();
                ci.Description = CategoryInfo[i]["Description"].ToString();
                //ci.IconType = CategoryInfo[i]["IconType"].ToString();                 //  2006.09.29  削除
                ci.IconIndex = (int)CategoryInfo[i]["IconIndex"];
                ci.IconName = CategoryInfo[i]["IconName"].ToString();
                //ci.SystemCode = CategoryInfo[i]["SystemCode"].ToString();             //  2006.09.29  削除
                //ci.OptionCode = CategoryInfo[i]["OptionCode"].ToString();             //  2006.09.29  削除
                ci.SysOpCode = CategoryInfo[i]["SysOpCode"].ToString();                 //  2006.09.29  追加
                ci.DisplayOption = CategoryInfo[i]["DisplayOption"].ToString();
                lvi.Tag = ci;
                lstSubMenu.Items.Add(lvi);
            }
            //  規定個数に満たない場合、空白を入れる                                       //  2006.01.10  追加
            for (int i = CategoryInfo.Length; i < cSubMenuFig; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lstSubMenu.Items.Add(lvi);
            }

            System.Windows.Forms.Application.DoEvents();
            for (int i = pnlDefMenu.Controls.Count - 1; i >= 0; i--)
            {
                pnlDefMenu.Controls[i].Dispose();
            }

            lstSubMenu.Columns[0].Width = lstSubMenu.ClientSize.Width - 2;              //  2006.09.29  追加

        }

        /// <summary>
        /// 第一画面サブカテゴリ選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubMenu_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true)
            {
                SubCategoryInfomation ci = (SubCategoryInfomation)e.Item.Tag;
                SubCategoryInfomationWithNo ciwn = new SubCategoryInfomationWithNo();
                ciwn.DspNo = pnlDefMenu.Controls.Count + 1;
                ciwn.SubCategoryInfo = ci;
                TGroupButton gButton = CreateSubMenu(ciwn);
                gButton.Select();
                pnlDefMenu.Tag = gButton;
            }
            else
            {

                //  アクティブイベント未発生で以降の処理が働くと初期表示がおかしくなるので抑制する
                if (bBeforeActive == true)
                {
                    return;

                }
                
                SubCategoryInfomation ci = (SubCategoryInfomation)e.Item.Tag;
                int ChangePos = 0;
                for (int i = pnlDefMenu.Controls.Count - 1; i >= 0; i--)
                {
                    if (ci.CategorySubID == ((SubCategoryInfomationWithNo)((TGroupButton)pnlDefMenu.Controls[i]).Tag).SubCategoryInfo.CategorySubID)
                    {
                        ChangePos = ((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).DspNo;
                        //  消す対象のサブメニューが現在アクティブならアクティブを他に設定する
                        if ((object)pnlDefMenu.Controls[i] == (object)pnlDefMenu.Tag)
                        {
                            if (pnlDefMenu.Controls.Count == 1)
                            {
                                //  一個のみなら無し
                                pnlDefMenu.Tag = null;
                            }
                            else if (i == 0)
                            {
                                //  先頭なら次に
                                pnlDefMenu.Tag = pnlDefMenu.Controls[1];
                            }
                            else
                            {
                                //  それ以外なら前に
                                pnlDefMenu.Tag = pnlDefMenu.Controls[i - 1];
                            }
                        }
                        ((TGroupButton)pnlDefMenu.Controls[i]).Dispose();
                        break;
                    }

                }
                //  消す対象が有ったら再整列
                if (ChangePos > 0)
                {
                    for (int i = 0; i < pnlDefMenu.Controls.Count; i++)
                    {
                        if (((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).DspNo > ChangePos)
                        {
                            ((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).DspNo--;
                            pnlDefMenu.Controls[i].Location = new Point((((pnlDefMenu.ClientSize.Width - 20) / 4) + 3) * (((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).DspNo - 1), 0);
                        }
                    }
                }
            }

            //  アクティブイベント未発生で以降の処理が働くと初期表示がおかしくなるので抑制する
            if (bBeforeActive == true)
            {
                return;

            }
            //  システムメニュー情報の選択済みの情報を一旦クリアして設定
            _mSystemMenuInfomation.SelectSubMenuCollection.Clear();
            for (int i = 0; i < pnlDefMenu.Controls.Count; i++)
            {
                _mSystemMenuInfomation.SelectSubMenuCollection.Add(((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).SubCategoryInfo);
            }

        }

        /// <summary>
        /// 第一画面サブメニュー作成処理
        /// </summary>
        /// <param name="ciwn">サブカテゴリ情報</param>
        /// <returns>作成グループボタン</returns>
        /// <remarks>
        /// <br>Note       :第一画面サブメニュー作成</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private TGroupButton CreateSubMenu(SubCategoryInfomationWithNo ciwn)
        {
            TGroupButton grpDefSubMenu = new TGroupButton();
            grpDefSubMenu.Parent = pnlDefMenu;
            grpDefSubMenu.HeaderActiveForeColor = Color.Red;
            grpDefSubMenu.AutoHeight = false;
            grpDefSubMenu.AutoWidth = true;
            grpDefSubMenu.GroupButtonCursor = Cursors.Hand;
            grpDefSubMenu.BackColor = SubMenuButton.BackColor1;
            grpDefSubMenu.BackColor2 = SubMenuButton.BackColor2;
            grpDefSubMenu.DescBackColor1 = SubMenuButton.DescBackColor1;
            grpDefSubMenu.DescBackColor2 = SubMenuButton.DescBackColor2;
            grpDefSubMenu.DescDivideRatio = 0;
            grpDefSubMenu.DescFont = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            grpDefSubMenu.DescForeColor = SubMenuButton.DescForeColor;
            grpDefSubMenu.DescGradientMode = SubMenuButton.DescGradiationMode;
            grpDefSubMenu.DescLineColor = SubMenuButton.DescLineColor;
            grpDefSubMenu.DescOuterDepth = 1;
            grpDefSubMenu.DescTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            grpDefSubMenu.EnableEnterKeyClick = false;
            grpDefSubMenu.EnableFuncKeyClick = false;
            grpDefSubMenu.EnableNumKeyClick = false;
            grpDefSubMenu.EnableSpaceKeyClick = false;
            grpDefSubMenu.GradientMode = SubMenuButton.GradiationMode;
            grpDefSubMenu.GroupButtonBackColor1 = SubMenuButton.ButtonBackColor1;
            grpDefSubMenu.GroupButtonBackColor2 = SubMenuButton.ButtonBackColor2;
            grpDefSubMenu.GroupButtonDepth = 1;
            grpDefSubMenu.GroupButtonGradientMode = SubMenuButton.ButtonGradiationMode;
            grpDefSubMenu.GroupButtonMargin = 3;
            grpDefSubMenu.GroupButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            grpDefSubMenu.GroupButtonTextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            grpDefSubMenu.SelectedButtonForeColor = SubMenuButton.SelectedButtonForeColor;
            grpDefSubMenu.SelectedButtonFaceColor1 = SubMenuButton.SelectedButtonFaceColor1;
            grpDefSubMenu.SelectedButtonFaceColor2 = SubMenuButton.SelectedButtonFaceColor2;
            grpDefSubMenu.HeaderBackColor1 = SubMenuButton.HeaderBackColor1;
            grpDefSubMenu.HeaderBackColor2 = SubMenuButton.HeaderBackColor2;
            grpDefSubMenu.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            grpDefSubMenu.HeaderForeColor = SubMenuButton.HeaderForeColor;
            grpDefSubMenu.HeaderGradientMode = SubMenuButton.HeaderGradiationMode;
            grpDefSubMenu.HeaderHeight = 20;
            grpDefSubMenu.HeaderImageIndex = -1;
            grpDefSubMenu.HeaderImageList = null;
            grpDefSubMenu.HeaderText = ciwn.SubCategoryInfo.Name;
            grpDefSubMenu.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            grpDefSubMenu.HeaderVisible = true;
            grpDefSubMenu.HeaderActiveForeColor = SubMenuButton.HeaderActiveForeColor;
            grpDefSubMenu.HotTrackingColor = SubMenuButton.HotTrackingColor;
            grpDefSubMenu.FocusButtonBorderColor = SubMenuButton.FocusButtonBorderColor;
            grpDefSubMenu.ActivePanelBorderColor = SubMenuButton.ActivePanelBorderColor;
            grpDefSubMenu.BackgroundImage = SubMenuButton.BackgroundImage;
            grpDefSubMenu.BackgroundImageLayout = SubMenuButton.BackgroundImageLayout;
            grpDefSubMenu.ImageList = null;
            grpDefSubMenu.Location = new System.Drawing.Point((((pnlDefMenu.ClientSize.Width - 20) / 4) + 3) * (pnlDefMenu.Controls.Count - 1), 0);
            grpDefSubMenu.Name = "grpDefSubMenu" + ciwn.SubCategoryInfo.No.ToString();
            grpDefSubMenu.ShowActivePanel = false;
            grpDefSubMenu.ShowDescription = false;
            grpDefSubMenu.Size = new System.Drawing.Size((pnlDefMenu.ClientSize.Width - 20) / 4, pnlDefMenu.ClientSize.Height);
            grpDefSubMenu.Tag = ciwn;
            grpDefSubMenu.Click += new EventHandler(grpDefSubMenu_Click);
            if (_mScreenInfomation.FocusBorderBold == true)
            {
                grpDefSubMenu.FocusDepth = 2;
                grpDefSubMenu.GroupButtonInnerDepth = 2;
            }
            else
            {
                grpDefSubMenu.FocusDepth = 1;
                grpDefSubMenu.GroupButtonInnerDepth = 1;
            }
            for (int i = 0; i < 3; i++)
            {
                GroupButton gb = new GroupButton();
                gb.DescriptionText = "";
                gb.Enabled = true;
                gb.ImageIndex = -1;
                gb.Location = new System.Drawing.Point(3, 26);
                gb.Parent = null;
                gb.Size = new System.Drawing.Size(115, 20);
                gb.Text = "機能" + i.ToString();
                gb.DescriptionText = "詳細" + i.ToString();
                gb.Enabled = true;
                if (ciwn.SubCategoryInfo.DisplayOption == "1")
                {
                    grpDefSubMenu.ShowDescription = true;
                    grpDefSubMenu.DescDivideRatio = 40;
                }
                grpDefSubMenu.GroupButtons.Add(gb);
            }

            return grpDefSubMenu;
        }

        /// <summary>
        ///  第一画面サブメニュー選択時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grpDefSubMenu_Click(object sender, EventArgs e)
        {
            pnlDefMenu.Tag = sender;
        }

        /// <summary>
        ///  第一画面サブメニュー左移動ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if ((pnlDefMenu.Controls.Count > 1) && (pnlDefMenu.Tag != null))
            {

                TGroupButton ActiveButton = (TGroupButton)pnlDefMenu.Tag;
                if (ActiveButton == null)
                {
                    return;
                }
                if (((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo == 1)
                {
                    return;
                }
                TGroupButton MoveButton = null;
                for (int i = 0; i < pnlDefMenu.Controls.Count; i++)
                {
                    if (((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo - 1 == ((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).DspNo)
                    {
                        MoveButton = (TGroupButton)pnlDefMenu.Controls[i];
                    }
                }
                if (MoveButton != null)
                {
                    MoveButton.Location = new Point((((pnlDefMenu.ClientSize.Width - 20) / 4) + 3) * (((SubCategoryInfomationWithNo)MoveButton.Tag).DspNo), 0);
                    ((SubCategoryInfomationWithNo)MoveButton.Tag).DspNo++;
                }
                ((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo--;
                ActiveButton.Location = new Point((((pnlDefMenu.ClientSize.Width - 20) / 4) + 3) * (((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo - 1), 0);
                ActiveButton.Select();

            }
        }

        /// <summary>
        ///  第一画面サブメニュー右移動ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if ((pnlDefMenu.Controls.Count > 0) && (pnlDefMenu.Tag != null))
            {
                TGroupButton ActiveButton = (TGroupButton)pnlDefMenu.Tag;
                if (ActiveButton == null)
                {
                    return;
                }
                if (((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo == pnlDefMenu.Controls.Count)
                {
                    return;
                }
                TGroupButton MoveButton = null;
                for (int i = 0; i < pnlDefMenu.Controls.Count; i++)
                {
                    if (((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo + 1 == ((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).DspNo)
                    {
                        MoveButton = (TGroupButton)pnlDefMenu.Controls[i];
                    }
                }
                if (MoveButton != null)
                {
                    ((SubCategoryInfomationWithNo)MoveButton.Tag).DspNo--;
                    MoveButton.Location = new Point((((pnlDefMenu.ClientSize.Width - 20) / 4) + 3) * (((SubCategoryInfomationWithNo)MoveButton.Tag).DspNo - 1), 0);
                }
                ActiveButton.Location = new Point((((pnlDefMenu.ClientSize.Width - 20) / 4) + 3) * (((SubCategoryInfomationWithNo)ActiveButton.Tag).DspNo++), 0);
                ActiveButton.Select();
            }

        }

        /// <summary>
        ///  確定ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbTheme.Text.Length == 0)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "選択エラー", "テーマ名を選択・設定してください。", "");
                tabSetting.SelectedIndex = 1;
                tabColor.Select();
                return;
            }
            //  初期表示メニューの並び順を制御
            _mSystemMenuInfomation.SelectSubMenuCollection.Clear();
            if (pnlDefMenu.Controls.Count > 0)
            {
                try
                {

                    ArrayList arTemp = new ArrayList();
                    arTemp.Clear();
                    for (int i = 0; i < pnlDefMenu.Controls.Count; i++)
                    {
                        arTemp.Add((SubCategoryInfomationWithNo)((TGroupButton)pnlDefMenu.Controls[i]).Tag);
                    }
                    MenuItemInfoComparer micomp = new MenuItemInfoComparer();
                    arTemp.Sort(micomp);
                    for (int i = 0; i < arTemp.Count; i++)
                    {
                        _mSystemMenuInfomation.SelectSubMenuCollection.Add(((SubCategoryInfomationWithNo)arTemp[i]).SubCategoryInfo);
                    }
                }
                catch(Exception)
                {
                }
            }


            //  システムカラー作成用
            if (CreateSystemColor == true)
            {
                //  作成したユーザー設定をシステム設定に追加する
                bool bHit = false;
                _mScreenInfomation.SystemServe = true;
                for (int i = 0; i < _mScreenThemeInfomation.ThemeFig; i++)
                {
                    if (((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[i]).ThemeID == _mScreenInfomation.ThemeID)
                    {
                        _mScreenThemeInfomation.SceenTehme[i] = _mScreenInfomation.Copy();
                        bHit = true;
                        break;
                    }
                }
                if (bHit == false)
                {
                    _mScreenThemeInfomation.SceenTehme.Add(_mScreenInfomation);
                    _mScreenThemeInfomation.ThemeFig = _mScreenThemeInfomation.SceenTehme.Count;
                }

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream();
                    formatter.Serialize(ms, _mScreenThemeInfomation);

                    FileEncryptgraphy fe = new FileEncryptgraphy(cThemeKey1 + cThemeKey2 + cThemeKey3 + cThemeKey4 + cThemeKey5);

                    if (fe.EncryptFile(Path.Combine(gNavigationDir, SFNETMENU2SettingInfomation.ThemeBinary), ms) != 0)
                    {
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Option", "保存エラー", "テーマ情報の書き込みに失敗しました。\n\n再度設定してください。", "-890");
                        return;
                    }


                }
                catch (Exception)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Option", "保存エラー", "テーマ情報の書き込みに失敗しました。\n\n再度設定してください。", "-891");
                    return;
                }


            }

            //  その他設定を保存
            try
            {

                _mSystemSettingInfomation.ShowDialog = chkShowDialog.Checked;
                int IntTimer = System.Convert.ToInt32(txtTime.Text);
                _mSystemSettingInfomation.DialogTimerInterval = IntTimer;
                _mSystemSettingInfomation.FuncKeyEnabled = chkFuncKey.Checked;
                _mSystemSettingInfomation.NumKeyEnabled = chkNumKey.Checked;
                _mSystemSettingInfomation.MaxRecentFig = System.Convert.ToInt32(txtRecent.Text);
                _mSystemSettingInfomation.SaveLastPosition = chkSavePosition.Checked;
                _mSystemSettingInfomation.SaveLastSize = chkSaveSize.Checked;
                _mSystemSettingInfomation.DateTimeFormat = lstDate.SelectedIndex;
                _mSystemSettingInfomation.ShiftKeyPriority = chkShftKey.Checked;
                _mSystemSettingInfomation.CategoryPriority = cmbCategoryPriority.SelectedIndex;
                _mSystemSettingInfomation.TabAutoDelete = chkTabAutoDelete.Checked;
                _mSystemSettingInfomation.TopMenu = chkTopMenu.Checked;//2008.09.26 sugi

            }
            catch (Exception)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "入力エラー", "ダイアログの表示時間は数字で秒単位で設定してください。", "");
                tabSetting.SelectedIndex = 2;
                tabEtc.Select();
                return;
            }


            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///  戻るボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        /// <summary>
        ///  第三画面ダイアログ表示時間設定変更押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int IntTimer = System.Convert.ToInt32(txtTime.Text);
                _mSystemSettingInfomation.DialogTimerInterval = IntTimer;
            }
            catch
            {
                txtTime.Text = _mSystemSettingInfomation.DialogTimerInterval.ToString();
            }
        }

        /// <summary>
        ///  第二画面テーマテキスト変更押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTheme_TextChanged(object sender, EventArgs e)
        {
            if (bShowing == true)
            {
                return;
            }
            _mScreenInfomation.ThemeName = cmbTheme.Text;
        }

        /// <summary>
        ///  第二画面テーマ変更押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTheme.SelectedIndex <= _mScreenThemeInfomation.SceenTehme.Count - 1)
                {
                     ((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[cmbTheme.SelectedIndex]).Copy(_mScreenInfomation);
                }
                else
                {
                    _mScreenInfomationSave.Copy(_mScreenInfomation);
                }
                SetPropertyInfomation(_mScreenInfomation);
                ChangeMenuColor(null);
                if (_mScreenInfomation.SystemServe == true)
                {
                    btnDelCustom.Visible = false;
                    btnRenameCustom.Visible = false;
                    grdProperty.Enabled = false;
                    chkFocusBorder.Enabled = false;
                }
                else
                {
//                    btnDelCustom.Visible = true;
                    btnRenameCustom.Visible = true;
                    grdProperty.Enabled = true;
                    chkFocusBorder.Enabled = true;
                }
                //  システムカラー作成時は特殊
                if (CreateSystemColor == true)
                {
                    btnDelCustom.Visible = true;
                    btnRenameCustom.Visible = true;
                    grdProperty.Enabled = true;
                    chkFocusBorder.Enabled = true;
                }

            }
            catch (Exception)
            {
                _mScreenInfomationSave.Copy(_mScreenInfomation);
                ChangeMenuColor(null);
            }

        }


        /// <summary>
        ///  第二画面カスタム設定作成ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCuston_Click(object sender, EventArgs e)
        {
            try
            {
                if (winCustomCreateTheme.ShowCustomColorSetting(_mScreenThemeInfomation, _mScreenInfomation) == DialogResult.OK)
                {

                    if (winCustomCreateTheme.ThemeID != null)
                    {
                        for (int i = 0; i < _mScreenThemeInfomation.ThemeFig; i++)
                        {
                            if (((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[i]).ThemeID == winCustomCreateTheme.ThemeID)
                            {
                                ((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[i]).Copy(_mScreenInfomation);
                                ((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[i]).Copy(_mScreenInfomationSave);
                                break;
                            }
                        }
                    }
                    _mScreenInfomation.ThemeName = winCustomCreateTheme.CustonName;
                    _mScreenInfomation.SystemServe = false;
                    _mScreenInfomation.ThemeID = System.Guid.NewGuid();
                    _mScreenInfomationSave.ThemeName = winCustomCreateTheme.CustonName;
                    _mScreenInfomationSave.SystemServe = false;
                    _mScreenInfomationSave.ThemeID = _mScreenInfomation.ThemeID;

//                    btnDelCustom.Visible = true;
                    btnRenameCustom.Visible = true;
                    grdProperty.Enabled = true;
                    chkFocusBorder.Enabled = true;
                    if (cmbTheme.Items.Count == _mScreenThemeInfomation.SceenTehme.Count)
                    {
                        cmbTheme.Items.Add(_mScreenInfomation.ThemeName);
                    }
                    else
                    {
                        cmbTheme.Items[cmbTheme.Items.Count - 1] = _mScreenInfomation.ThemeName;
                    }
                    cmbTheme.SelectedIndex = cmbTheme.Items.Count - 1;
                    SetPropertyInfomation(_mScreenInfomation);
                    ChangeMenuColor(null);
                    if (CreateSystemColor == true)
                    {
                        btnDelCustom.Visible = true;
                        btnRenameCustom.Visible = true;
                        grdProperty.Enabled = true;
                        chkFocusBorder.Enabled = true;
                    }

                }
            }
            catch
            {
            }

        }

        /// <summary>
        ///  第二画面カスタム設定名ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRenameCustom_Click(object sender, EventArgs e)
        {

            if (winCustomRenameTheme.ShowCustomNameSetting(cmbTheme.Items[cmbTheme.SelectedIndex].ToString(), _mScreenInfomation) == DialogResult.OK)
            {

                if (cmbTheme.SelectedIndex <= _mScreenThemeInfomation.SceenTehme.Count - 1)
                {
                    ((ScreenInfomation)_mScreenThemeInfomation.SceenTehme[cmbTheme.SelectedIndex]).ThemeName = winCustomRenameTheme.CustonName;
                }
                _mScreenInfomation.ThemeName = winCustomRenameTheme.CustonName;
                cmbTheme.Items[cmbTheme.Items.Count - 1] = _mScreenInfomation.ThemeName;

            }
        }

        /// <summary>
        ///  第二画面ツールバー選択時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolBar_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = ToolbarLabel;
            lblSelectItem.Text = "ツールバー";
        }

        /// <summary>
        ///  第二画面ツールバー選択時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolbarBack_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = ToolbarLabel;
            lblSelectItem.Text = "ツールバー";

        }

        /// <summary>
        ///  第二画面ツールバー描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolBar_Paint(object sender, PaintEventArgs e)
        {
            //たてに白から黒へのグラデーションのブラシを作成
            //g.VisibleClipBoundsは表示クリッピング領域に外接する四角形
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, ToolbarLabel.ToolStripGradientBegin, ToolbarLabel.ToolStripGradientEnd, LinearGradientMode.Vertical);

            //四角を描く
            e.Graphics.FillRectangle(myBrush, e.Graphics.VisibleClipBounds);

            //ボタンのTextを描画する準備
            StringFormat sf = new StringFormat();
            //文字列を真ん中に描画
            if (((Label)sender).TextAlign.ToString().IndexOf("left", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.Alignment = StringAlignment.Near;
            }
            else if (((Label)sender).TextAlign.ToString().IndexOf("center", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.Alignment = StringAlignment.Center;
            }
            else
            {
                sf.Alignment = StringAlignment.Far;
            }
            if (((Label)sender).TextAlign.ToString().IndexOf("top", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.LineAlignment = StringAlignment.Near;
            }
            else if (((Label)sender).TextAlign.ToString().IndexOf("middle", StringComparison.OrdinalIgnoreCase) > -1)
            {
                sf.LineAlignment = StringAlignment.Center;
            }
            else
            {
                sf.LineAlignment = StringAlignment.Far;
            }
            //Brushの作成
            Brush brsh = new SolidBrush(((Label)sender).ForeColor);
            //文字列を描画
            e.Graphics.DrawString(((Label)sender).Text, ((Label)sender).Font, brsh, ((Label)sender).ClientRectangle, sf);

            //リソースを開放する
            brsh.Dispose();
            myBrush.Dispose();
            e.Dispose();

        }

        /// <summary>
        ///  第二画面ツールバー背景描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolbarBack_Paint(object sender, PaintEventArgs e)
        {
            //たてに白から黒へのグラデーションのブラシを作成
            //g.VisibleClipBoundsは表示クリッピング領域に外接する四角形
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, ToolbarLabel.ToolStripPanelGradientBegin, ToolbarLabel.ToolStripPanelGradientEnd, LinearGradientMode.Vertical);

            //四角を描く
            e.Graphics.FillRectangle(myBrush, e.Graphics.VisibleClipBounds);

            //リソースを開放する
            myBrush.Dispose();
            e.Dispose();

        }

        /// <summary>
        ///  第二画面メニューバー選択時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMenuBar_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = MenuLabel;
            lblSelectItem.Text = "メニューバー";

        }

        /// <summary>
        ///  第二画面ステータスバー選択時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = StatusBarLabel;
            lblSelectItem.Text = "ステータスバー";

        }

        /// <summary>
        ///  第二画面メニューバー描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMenuBar_Paint(object sender, PaintEventArgs e)
        {
            lblMenuBar.ForeColor = _mScreenInfomation.MenuBarForeColor;
            lblMenuBar.BackColor = _mScreenInfomation.MenuBarBackColor;
        }

        /// <summary>
        ///  第二画面ステータスバー描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_Paint(object sender, PaintEventArgs e)
        {
            lblStatusBar.ForeColor = _mScreenInfomation.MenuBarForeColor;
            lblStatusBar.BackColor = _mScreenInfomation.MenuBarBackColor;

        }

        /// <summary>
        ///  第二画面カスタム設定削除ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelCustom_Click(object sender, EventArgs e)
        {
            //  選択無しなら抜ける                                                       //  2007.01.10  追加
            if (cmbTheme.SelectedIndex == -1)
            {
                return;
            }

            if (cmbTheme.SelectedIndex < _mScreenThemeInfomation.ThemeFig)
            {
                if (CreateSystemColor == true)
                {
                    _mScreenThemeInfomation.SceenTehme.RemoveAt(cmbTheme.SelectedIndex);
                    _mScreenThemeInfomation.ThemeFig = _mScreenThemeInfomation.SceenTehme.Count;
                }
                cmbTheme.Items.RemoveAt(cmbTheme.SelectedIndex);
                cmbTheme.Refresh();
            }
            
        }

        /// <summary>
        ///  第三画面最近使った機能数変更時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRecent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int RecentFig = System.Convert.ToInt32(txtRecent.Text);
                _mSystemSettingInfomation.MaxRecentFig = RecentFig;
            }
            catch
            {
                txtRecent.Text = _mSystemSettingInfomation.MaxRecentFig.ToString();
            }

        }

        /// <summary>
        ///  第二画面フォーカス枠変更時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFocusBorder_CheckedChanged(object sender, EventArgs e)
        {
            _mScreenInfomation.FocusBorderBold = chkFocusBorder.Checked;
            SetPropertyInfomation(_mScreenInfomation);
            ChangeMenuColor(null);
        }

        /// <summary>
        ///  フォームアクティブ時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2E_Activated(object sender, EventArgs e)
        {

            //  アクティブイベントが一度でも発生していれば再度行わない
            if (bBeforeActive == false)
            {
                return;
            }

            //  サブメニュー表示を行う(ここで行わないとサブメニューの表示順番が不正になる)
            for (int j = 0; j < _mSystemMenuInfomation.SelectSubMenuCollection.Count; j++)
            {
                for (int i = 0; i < lstSubMenu.Items.Count; i++)
                {
                    try
                    {
                        if ((((SubCategoryInfomation)lstSubMenu.Items[i].Tag).CategoryID == ((SubCategoryInfomation)_mSystemMenuInfomation.SelectSubMenuCollection[j]).CategoryID)
                            && (((SubCategoryInfomation)lstSubMenu.Items[i].Tag).CategorySubID == ((SubCategoryInfomation)_mSystemMenuInfomation.SelectSubMenuCollection[j]).CategorySubID))
                        {
                            lstSubMenu.Items[i].Checked = true;
                            System.Windows.Forms.Application.DoEvents();
                            break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            bBeforeActive = false;       //  アクティブイベント発生

        }

        /// <summary>
        /// 第一画面サブカテゴリチェック時発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubMenu_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (lstSubMenu.Items[e.Index].Text.Length == 0)
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }


        /// <summary>
        /// 第二画面色情報更新制御処理
        /// </summary>
        /// <param name="TargetObject">対象オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :第二画面色情報更新制御</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int ChangeMenuColor(object TargetObject)
        {

            try
            {
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(BasicSetting)))
                {
                    lblMenuBar.Refresh();

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(BasicSetting2)))
                {
                    lblStatusBar.Refresh();

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(ToolBarSetting)))
                {
                    lblToolBar.ForeColor = _mScreenInfomation.ToolBarForeColor;
                    CustomProfessionalRenderer cpr = new CustomProfessionalRenderer();
                    try
                    {
                        cpr._ToolStripGradientBegin = _mScreenInfomation.ToolBarColor.ToolStripGradientBegin;
                        cpr._ToolStripGradientMiddle = _mScreenInfomation.ToolBarColor.ToolStripGradientMiddle;
                        cpr._ToolStripGradientEnd = _mScreenInfomation.ToolBarColor.ToolStripGradientEnd;
                        cpr._ToolStripPanelGradientBegin = _mScreenInfomation.ToolBarColor.ToolStripPanelGradientBegin;
                        cpr._ToolStripPanelGradientEnd = _mScreenInfomation.ToolBarColor.ToolStripPanelGradientEnd;
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
                    btnSave.ForeColor = _mScreenInfomation.ToolBarForeColor;
                    btnCancel.ForeColor = _mScreenInfomation.ToolBarForeColor;

                    lblToolBar.Refresh();
                    lblToolbarBack.Refresh();

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(CategoryInfoSetting)))
                {
                    lblCategory.Refresh();

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(SubCategorySetting)))
                {
                    lstSubCategory.ForeColor = _mScreenInfomation.SubCategoryForeColor;
                    lstSubCategory.BackColor = _mScreenInfomation.SubCategoryBackColor;
                    lstSubCategory.BackgroundImage = _mScreenInfomation.SubCategoryBackImage;
                    lstSubCategory.BackgroundImageTiled = _mScreenInfomation.SubCategoryBackImageTiled;
                    lstSubCategory.Refresh();

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(CategorySetting)))
                {
                    grpCategory.ForeColor = _mScreenInfomation.CategoryForeColor;
                    grpCategory.BackColor = _mScreenInfomation.CategoryBackColor1;
                    grpCategory.BackColor2 = _mScreenInfomation.CategoryBackColor2;
                    grpCategory.GradientMode = _mScreenInfomation.CategoryGradiationMode;
                    grpCategory.GroupButtonBackColor1 = _mScreenInfomation.CategoryButtonBackColor1;
                    grpCategory.GroupButtonBackColor2 = _mScreenInfomation.CategoryButtonBackColor2;
                    grpCategory.GroupButtonGradientMode = _mScreenInfomation.CategoryButtonGradiationMode;
                    grpCategory.SelectedButtonForeColor = _mScreenInfomation.CategorySelectedButtonForeColor;
                    grpCategory.SelectedButtonFaceColor1 = _mScreenInfomation.CategorySelectedButtonFaceColor1;
                    grpCategory.SelectedButtonFaceColor2 = _mScreenInfomation.CategorySelectedButtonFaceColor2;
                    grpCategory.BackgroundImage = _mScreenInfomation.CategoryBackImage;
                    grpCategory.BackgroundImageLayout = _mScreenInfomation.CategoryBackImageLayout;
                    grpCategory.HotTrackingColor = _mScreenInfomation.CategoryHotTrackingColor;
                    grpCategory.FocusButtonBorderColor = _mScreenInfomation.CategoryFocusButtonBorderColor;
                    grpCategory.ActivePanelBorderColor = _mScreenInfomation.CategoryActivePanelBorderColor;
                    if (_mScreenInfomation.FocusBorderBold == true)
                    {
                        grpCategory.FocusDepth = 2;
                        grpCategory.GroupButtonInnerDepth = 2;
                    }
                    else
                    {
                        grpCategory.FocusDepth = 1;
                        grpCategory.GroupButtonInnerDepth = 1;
                    }
                    grpCategory.Refresh();
                    tabBase.Refresh();                                          //  2007.01.10  追加

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(SubMenuSetting)))
                {

                    grpSubMenu.ForeColor = _mScreenInfomation.SubMenuForeColor;
                    grpSubMenu.BackColor = _mScreenInfomation.SubMenuBackColor1;
                    grpSubMenu.BackColor2 = _mScreenInfomation.SubMenuBackColor2;
                    grpSubMenu.GradientMode = _mScreenInfomation.SubMenuGradiationMode;
                    grpSubMenu.HeaderActiveForeColor = _mScreenInfomation.SubMenuHeaderActiveForeColor;
                    grpSubMenu.HeaderForeColor = _mScreenInfomation.SubMenuHeaderForeColor;
                    grpSubMenu.HeaderBackColor1 = _mScreenInfomation.SubMenuHeaderBackColor1;
                    grpSubMenu.HeaderBackColor2 = _mScreenInfomation.SubMenuHeaderBackColor2;
                    grpSubMenu.HeaderGradientMode = _mScreenInfomation.SubMenuHeaderGradiationMode;
                    grpSubMenu.GroupButtonBackColor1 = _mScreenInfomation.SubMenuButtonBackColor1;
                    grpSubMenu.GroupButtonBackColor2 = _mScreenInfomation.SubMenuButtonBackColor2;
                    grpSubMenu.GroupButtonGradientMode = _mScreenInfomation.SubMenuButtonGradiationMode;
                    grpSubMenu.SelectedButtonForeColor = _mScreenInfomation.SubMenuSelectedButtonForeColor;
                    grpSubMenu.SelectedButtonFaceColor1 = _mScreenInfomation.SubMenuSelectedButtonFaceColor1;
                    grpSubMenu.SelectedButtonFaceColor2 = _mScreenInfomation.SubMenuSelectedButtonFaceColor2;
                    grpSubMenu.BackgroundImage = _mScreenInfomation.SubMenuBackImage;
                    grpSubMenu.BackgroundImageLayout = _mScreenInfomation.SubMenuBackImageLayout;
                    grpSubMenu.DescBackColor1 = _mScreenInfomation.SubMenuDescBackColor1;
                    grpSubMenu.DescBackColor2 = _mScreenInfomation.SubMenuDescBackColor2;
                    grpSubMenu.DescForeColor = _mScreenInfomation.SubMenuDescForeColor;
                    grpSubMenu.DescGradientMode = _mScreenInfomation.SubMenuDescGradientMode;
                    grpSubMenu.DescLineColor = _mScreenInfomation.SubMenuDescLineColor;
                    grpSubMenu.HotTrackingColor = _mScreenInfomation.SubMenuHotTrackingColor;
                    grpSubMenu.FocusButtonBorderColor = _mScreenInfomation.SubMenuFocusButtonBorderColor;
                    grpSubMenu.ActivePanelBorderColor = _mScreenInfomation.SubMenuActivePanelBorderColor;
                    if (_mScreenInfomation.FocusBorderBold == true)
                    {
                        grpSubMenu.FocusDepth = 2;
                        grpSubMenu.GroupButtonInnerDepth = 2;
                    }
                    else
                    {
                        grpSubMenu.FocusDepth = 1;
                        grpSubMenu.GroupButtonInnerDepth = 1;
                    }
                    grpSubMenu.Refresh();
                    grpSubMenu2.ForeColor = _mScreenInfomation.SubMenuForeColor;
                    grpSubMenu2.BackColor = _mScreenInfomation.SubMenuBackColor1;
                    grpSubMenu2.BackColor2 = _mScreenInfomation.SubMenuBackColor2;
                    grpSubMenu2.GradientMode = _mScreenInfomation.SubMenuGradiationMode;
                    grpSubMenu2.HeaderActiveForeColor = _mScreenInfomation.SubMenuHeaderActiveForeColor;
                    grpSubMenu2.HeaderForeColor = _mScreenInfomation.SubMenuHeaderForeColor;
                    grpSubMenu2.HeaderBackColor1 = _mScreenInfomation.SubMenuHeaderBackColor1;
                    grpSubMenu2.HeaderBackColor2 = _mScreenInfomation.SubMenuHeaderBackColor2;
                    grpSubMenu2.HeaderGradientMode = _mScreenInfomation.SubMenuHeaderGradiationMode;
                    grpSubMenu2.GroupButtonBackColor1 = _mScreenInfomation.SubMenuButtonBackColor1;
                    grpSubMenu2.GroupButtonBackColor2 = _mScreenInfomation.SubMenuButtonBackColor2;
                    grpSubMenu2.GroupButtonGradientMode = _mScreenInfomation.SubMenuButtonGradiationMode;
                    grpSubMenu2.SelectedButtonForeColor = _mScreenInfomation.SubMenuSelectedButtonForeColor;
                    grpSubMenu2.SelectedButtonFaceColor1 = _mScreenInfomation.SubMenuSelectedButtonFaceColor1;
                    grpSubMenu2.SelectedButtonFaceColor2 = _mScreenInfomation.SubMenuSelectedButtonFaceColor2;
                    grpSubMenu2.BackgroundImage = _mScreenInfomation.SubMenuBackImage;
                    grpSubMenu2.BackgroundImageLayout = _mScreenInfomation.SubMenuBackImageLayout;
                    grpSubMenu2.DescBackColor1 = _mScreenInfomation.SubMenuDescBackColor1;
                    grpSubMenu2.DescBackColor2 = _mScreenInfomation.SubMenuDescBackColor2;
                    grpSubMenu2.DescForeColor = _mScreenInfomation.SubMenuDescForeColor;
                    grpSubMenu2.DescGradientMode = _mScreenInfomation.SubMenuDescGradientMode;
                    grpSubMenu2.DescLineColor = _mScreenInfomation.SubMenuDescLineColor;
                    grpSubMenu2.HotTrackingColor = _mScreenInfomation.SubMenuHotTrackingColor;
                    grpSubMenu2.FocusButtonBorderColor = _mScreenInfomation.SubMenuFocusButtonBorderColor;
                    grpSubMenu2.ActivePanelBorderColor = _mScreenInfomation.SubMenuActivePanelBorderColor;
                    if (_mScreenInfomation.FocusBorderBold == true)
                    {
                        grpSubMenu2.FocusDepth = 2;
                        grpSubMenu2.GroupButtonInnerDepth = 2;
                    }
                    else
                    {
                        grpSubMenu2.FocusDepth = 1;
                        grpSubMenu2.GroupButtonInnerDepth = 1;
                    }
                    grpSubMenu2.Refresh();

                }
                if ((TargetObject == null) || (TargetObject.GetType() == typeof(BackgroundSetting)))
                {

                    tabMenu.BackColor = _mScreenInfomation.TabPageBackColor;
                    tabMenu.BackgroundImage = _mScreenInfomation.TabPageBackImage;
                    tabMenu.BackgroundImageLayout = _mScreenInfomation.TabPageBackImageLayout;
                    tabColor.BackColor = _mScreenInfomation.ScreenBackColor;
                    tabSetting.BackColor = _mScreenInfomation.ScreenBackColor;
                   // tabStartup.BackColor = _mScreenInfomation.ScreenBackColor;
                    tabEtc.BackColor = _mScreenInfomation.ScreenBackColor;
                    pnlDefMenu.BackColor = _mScreenInfomation.TabPageBackColor;
                    pnlDefMenu.BackgroundImage = _mScreenInfomation.TabPageBackImage;
                    pnlDefMenu.BackgroundImageLayout = _mScreenInfomation.TabPageBackImageLayout;
                    BackColor = _mScreenInfomation.ScreenBackColor;

                    tabMenu.Refresh();
                }
                return 0;
            }
            catch (Exception)
            {
                return 5;
            }
        }

        /// <summary>
        /// 第二画面色情報設定処理
        /// </summary>
        /// <param name="srcInfomation">画面色情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :第二画面色情報設定</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int SetPropertyInfomation(ScreenInfomation srcInfomation)
        {
            StatusBarLabel.BackColor = srcInfomation.StatusBarBackColor;
            StatusBarLabel.ForeColor = srcInfomation.StatusBarForeColor;

            ToolbarLabel.ToolStripForeColor = _mScreenInfomation.ToolBarForeColor;
            ToolbarLabel.ToolStripGradientBegin = srcInfomation.ToolBarColor.ToolStripGradientBegin;
            ToolbarLabel.ToolStripGradientMiddle = srcInfomation.ToolBarColor.ToolStripGradientMiddle;
            ToolbarLabel.ToolStripGradientEnd = srcInfomation.ToolBarColor.ToolStripGradientEnd;
            ToolbarLabel.ToolStripPanelGradientBegin = srcInfomation.ToolBarColor.ToolStripPanelGradientBegin;
            ToolbarLabel.ToolStripPanelGradientEnd = srcInfomation.ToolBarColor.ToolStripPanelGradientEnd;

            MenuLabel.BackColor = srcInfomation.MenuBarBackColor;
            MenuLabel.ForeColor = srcInfomation.MenuBarForeColor;

            StatusBarLabel.BackColor = srcInfomation.StatusBarBackColor;
            StatusBarLabel.ForeColor = srcInfomation.StatusBarForeColor;

            CartegroyLabel.ForeColor = srcInfomation.CategoryLabelForeColor;
            CartegroyLabel.BackColor1 = srcInfomation.CategoryLabelBackColor1;
            CartegroyLabel.BackColor2 = srcInfomation.CategoryLabelBackColor2;
            CartegroyLabel.GradiationMode = srcInfomation.CategoryLabelGradiationMode;

            SubCartegroyList.ForeColor = srcInfomation.SubCategoryForeColor;
            SubCartegroyList.BackColor = srcInfomation.SubCategoryBackColor;
            SubCartegroyList.BackgroundImage = srcInfomation.SubCategoryBackImage;
            SubCartegroyList.BackgroundImageTiled = srcInfomation.SubCategoryBackImageTiled;

            CategroyButton.ForeColor = srcInfomation.CategoryForeColor;
            CategroyButton.BackColor1 = srcInfomation.CategoryBackColor1;
            CategroyButton.BackColor2 = srcInfomation.CategoryBackColor2;
            CategroyButton.GradiationMode = srcInfomation.CategoryGradiationMode;
            CategroyButton.ButtonBackColor1 = srcInfomation.CategoryButtonBackColor1;
            CategroyButton.ButtonBackColor2 = srcInfomation.CategoryButtonBackColor2;
            CategroyButton.ButtonGradiationMode = srcInfomation.CategoryButtonGradiationMode;
            CategroyButton.SelectedButtonForeColor = srcInfomation.CategorySelectedButtonForeColor;
            CategroyButton.SelectedButtonFaceColor1 = srcInfomation.CategorySelectedButtonFaceColor1;
            CategroyButton.SelectedButtonFaceColor2 = srcInfomation.CategorySelectedButtonFaceColor2;
            CategroyButton.BackgroundImage = srcInfomation.CategoryBackImage;
            CategroyButton.BackgroundImageLayout = srcInfomation.CategoryBackImageLayout;
            CategroyButton.HotTrackingColor = srcInfomation.CategoryHotTrackingColor;
            CategroyButton.ActivePanelBorderColor = srcInfomation.CategoryActivePanelBorderColor;
            CategroyButton.FocusButtonBorderColor = srcInfomation.CategoryFocusButtonBorderColor;

            SubMenuButton.ForeColor = srcInfomation.SubMenuForeColor;
            SubMenuButton.BackColor1 = srcInfomation.SubMenuBackColor1;
            SubMenuButton.BackColor2 = srcInfomation.SubMenuBackColor2;
            SubMenuButton.GradiationMode = srcInfomation.SubMenuGradiationMode;
            SubMenuButton.HeaderActiveForeColor = srcInfomation.SubMenuHeaderActiveForeColor;
            SubMenuButton.HeaderForeColor = srcInfomation.SubMenuHeaderForeColor;
            SubMenuButton.HeaderBackColor1 = srcInfomation.SubMenuHeaderBackColor1;
            SubMenuButton.HeaderBackColor2 = srcInfomation.SubMenuHeaderBackColor2;
            SubMenuButton.HeaderGradiationMode = srcInfomation.SubMenuHeaderGradiationMode;
            SubMenuButton.ButtonBackColor1 = srcInfomation.SubMenuButtonBackColor1;
            SubMenuButton.ButtonBackColor2 = srcInfomation.SubMenuButtonBackColor2;
            SubMenuButton.ButtonGradiationMode = srcInfomation.SubMenuButtonGradiationMode;
            SubMenuButton.SelectedButtonForeColor = srcInfomation.SubMenuSelectedButtonForeColor;
            SubMenuButton.SelectedButtonFaceColor1 = srcInfomation.SubMenuSelectedButtonFaceColor1;
            SubMenuButton.SelectedButtonFaceColor2 = srcInfomation.SubMenuSelectedButtonFaceColor2;
            SubMenuButton.BackgroundImage = srcInfomation.SubMenuBackImage;
            SubMenuButton.BackgroundImageLayout = srcInfomation.SubMenuBackImageLayout;
            SubMenuButton.DescBackColor1 = srcInfomation.SubMenuDescBackColor1;
            SubMenuButton.DescBackColor2 = srcInfomation.SubMenuDescBackColor2;
            SubMenuButton.DescForeColor = srcInfomation.SubMenuDescForeColor;
            SubMenuButton.DescGradiationMode = srcInfomation.SubMenuDescGradientMode;
            SubMenuButton.DescLineColor = srcInfomation.SubMenuDescLineColor;
            SubMenuButton.HotTrackingColor = srcInfomation.SubMenuHotTrackingColor;
            SubMenuButton.ActivePanelBorderColor = srcInfomation.SubMenuActivePanelBorderColor;
            SubMenuButton.FocusButtonBorderColor = srcInfomation.SubMenuFocusButtonBorderColor;

            chkFocusBorder.Checked = srcInfomation.FocusBorderBold;

            BackScreen.ScreenBackColor = srcInfomation.ScreenBackColor;
            BackScreen.TabPageBackColor = srcInfomation.TabPageBackColor;
            BackScreen.TabPageBackImage = srcInfomation.TabPageBackImage;
            BackScreen.TabPageBackImageLayout = srcInfomation.TabPageBackImageLayout;

            //  初期メニュー設定の色を設定
            lstSubMenu.ForeColor = SubCartegroyList.ForeColor;
            lstSubMenu.BackColor = SubCartegroyList.BackColor;
            lstSubMenu.BackgroundImage = SubCartegroyList.BackgroundImage;
            lstSubMenu.BackgroundImageTiled = SubCartegroyList.BackgroundImageTiled;

            return 0;
        }

        /// <summary>
        /// 第二画面タブコントロール描画イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabBase_DrawItem(object sender, DrawItemEventArgs e)
        {

            //StringFormatを作成
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            //背景の描画
            Brush bk = new SolidBrush(_mScreenInfomation.ScreenBackColor);
            e.Graphics.FillRectangle(bk, e.Graphics.VisibleClipBounds);

            Brush foreBrush, backBrush;

            //タブページのテキストを取得
            string txt = tabBase.TabPages[0].Text;
            //  タブページに色づけ(カテゴリーの色を極力使用する)            // 2007.01.10  追加
            Color cFore;
            Color cBack;
            if (_mScreenInfomation.CategoryButtonBackColor1.GetBrightness() == _mScreenInfomation.CategoryButtonBackColor2.GetBrightness())
            {
                cFore = _mScreenInfomation.CategoryButtonBackColor1;
                byte crc = (byte)(_mScreenInfomation.CategoryButtonBackColor1.R * .8);
                byte cgc = (byte)(_mScreenInfomation.CategoryButtonBackColor1.G * .8);
                byte cbc = (byte)(_mScreenInfomation.CategoryButtonBackColor1.B * .8);
                cBack = Color.FromArgb(crc, cgc, cbc);
            }
            else if (_mScreenInfomation.CategoryButtonBackColor1.GetBrightness() > _mScreenInfomation.CategoryButtonBackColor2.GetBrightness())
            {
                cFore = _mScreenInfomation.CategoryButtonBackColor1;
                cBack = _mScreenInfomation.CategoryButtonBackColor2;
            }
            else
            {
                cFore = _mScreenInfomation.CategoryButtonBackColor2;
                cBack = _mScreenInfomation.CategoryButtonBackColor1;
            }

            foreBrush = new SolidBrush(_mScreenInfomation.CategorySelectedButtonForeColor);
            backBrush = new SolidBrush(cFore);

            e.Graphics.FillRectangle(backBrush, tabBase.GetTabRect(0));

            if (tabBase.TabPages[0].Tag != null)
            {
                Image img;
                try
                {
                    TabMenuInfomation ti = (TabMenuInfomation)tabBase.TabPages[0].Tag;
                    if (ti.Icon != null)
                    {
                        img = ti.Icon;
                    }
                    else
                    {
                        img = MenuIconResourceManagement.GetImageListImage(ti.IconName, ti.IconIndex);
                    }

                    e.Graphics.DrawImage(img, new Point(tabBase.GetTabRect(0).Left + 3, (tabBase.GetTabRect(0).Height - img.Height) / 2));
                }
                catch (Exception)
                { }
            }

            //Textの描画
            e.Graphics.DrawString(txt, tabBase.TabPages[0].Font, foreBrush, tabBase.GetTabRect(0), sf);

        }


    }

}
