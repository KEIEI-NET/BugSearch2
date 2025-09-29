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
    /// �I�v�V�����֘A�ݒ��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�v�V�����֘A�ݒ��ʃN���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.29 ����@�K��</br>
    /// <br>Update Note: 2007.01.10 ����@�K��</br>
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
        private class MenuItemInfoComparer : IComparer    // �\�[�g(��r)�̃��[�U��`��
        {
            public int Compare(object x, object y)                  // ��^��
            {
                SubCategoryInfomationWithNo mi1 = (SubCategoryInfomationWithNo)x;
                SubCategoryInfomationWithNo mi2 = (SubCategoryInfomationWithNo)y;

                return mi1.DspNo - mi2.DspNo;
            }
        }

        private string gBootDir;
        private string gNavigationDir;
        private const string cThemeKey3 = "1sd4";
        private const int cSubMenuFig = 24;                                     //  2007.01.10  �ǉ�

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
        DataRow[] gTopCategory;                                                         //  2006.09.29  �ǉ�
        private const string cThemeKey2 = "5s";
        private ArrayList arTopCategory = new ArrayList();

        /// <summary>
        /// �I�v�V�����֘A�ݒ��ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :�I�v�V�����֘A�ݒ��ʃR���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2E()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �I�v�V�����֘A�ݒ�\�����䏈��
        /// </summary>
        /// <param name="smif">���j���[�ݒ���</param>
        /// <param name="sif">��ʐF���</param>
        /// <param name="ssif">�V�X�e���ݒ���</param>
        /// <param name="wrkPath">�J�����g�f�B���N�g��</param>
        /// <param name="SystemSettingMode">�V�X�e���񋟐ݒ���쐬�L��</param>
        /// <returns>�_�C�A���O����</returns>
        /// <remarks>
        /// <br>Note       :�I�v�V�����֘A�ݒ�\������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public DialogResult ShowSetting(string[] Products, ref SystemMenuInfomation smif, ref ScreenInfomation sif, ref SystemSettingInfomation ssif, string BootDir, string NavigationDir, bool SystemSettingMode)
        {

            bShowing = true;            //  �_�C�A���O�\��������
            bBeforeActive = true;       //  �A�N�e�B�u�C�x���g������

            gBootDir = BootDir;
            gNavigationDir = NavigationDir;

            btnSave.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Decision];
            btnCancel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Back];
            btnSave.ForeColor = sif.ToolBarForeColor;
            btnCancel.ForeColor = sif.ToolBarForeColor;

            //  �����ϐ��ɕۑ�
            _mSystemMenuInfomation = smif;
            _mScreenInfomation = sif;
            _mScreenInfomationSave = sif.Copy();
            _mSystemSettingInfomation = ssif;

            CreateSystemColor = SystemSettingMode;

            //  ��ʂ�������
            tabSetting.SelectedIndex = 0;;
            grdProperty.SelectedObject = null;

            //  ���j���[����ݒ�(�S���擾)------------------------------------------------------
            //gTopCategory = SFNETMENU2Utilities.GetCategory(Products);             //  2006.09.29  �ύX
            gTopCategory = SFNETMENU2Utilities.GetCategory(Products, true);
            cmbCategory.Items.Clear();
            lstSubMenu.Items.Clear();
            arTopCategory.Clear();                                                  //  2006.09.29  �ǉ�
            int idxSelect = -1;
            for (int i = 0; i < gTopCategory.Length; i++)
            {
                // �� �J�e�S�����������x�����Q�Ƃ��t�B���^�[�������� 
                bool CategoryCheck = false;

                if (gTopCategory.Length != 0)
                {
                    CategoryCheck = SystemCheck.CheckAuthority(gTopCategory[i]);
                }

                // ������������Ε\���ł��Ȃ�
                if (CategoryCheck == false)
                {
                    continue;
                }
                //2009.02.10 sugi add��
                if (gTopCategory[i]["DisplayOption"].ToString().ToUpper() == "I")
                {
                    continue;
                }

                    //  �T�|�[�g��p�̃J�e�S��
                else if (gTopCategory[i]["DisplayOption"].ToString().ToUpper() == "S")
                {
                    //  �T�|�[�g�ȊO�ɂ͔�\��
                    if (LoginInfoAcquisition.Employee.UserAdminFlag < 2) continue;
                }

                //  �Ǘ��Ґ�p�̃J�e�S��
                else if (gTopCategory[i]["DisplayOption"].ToString().ToUpper() == "A")
                {
                    //  �T�|�[�g�ƊǗ��҈ȊO�ɂ͔�\��
                    if (LoginInfoAcquisition.Employee.UserAdminFlag == 0) continue;
                }
                //  �T�|�[�g����ȊO�̃J�e�S���̓T�|�[�g�ɂ͔�\��
                else
                {
                    if (LoginInfoAcquisition.Employee.UserAdminFlag != 0) continue;
                }
                //2009.02.10 sugi add��

                if (SystemCheck.CheckSystemPermissionFunction(gTopCategory[i]) != 0)
                {
                    arTopCategory.Add(gTopCategory[i]);                             //  2006.09.29  �ǉ�
                    cmbCategory.Items.Add(gTopCategory[i]["Name"].ToString());
                    if ((int)gTopCategory[i]["CategoryID"] == smif.SelectCategory)
                    {
                        //idxSelect = i;                                            //  2006.09.29  �ύX
                        idxSelect = arTopCategory.Count-1;    
                    }

                }
            }
            cmbCategory.Items.Add("���C�ɓ���");    //  2009.02.10  sugi �ύX�i���[�U�[���j���[�j
            if (idxSelect != -1)
            {
                //  �ʏ탁�j���[
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
                    //  ���[�U�[���j���[
                    cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;
                }
            }
            System.Windows.Forms.Application.DoEvents();

            //  �F����ݒ�------------------------------------------------------

            //  �V�X�e���e�[�}���擾
            cmbTheme.Items.Clear();
            _mScreenThemeInfomation.ThemeFig = 0;
            _mScreenThemeInfomation.SceenTehme.Clear();
            try
            {
                //  �ǂݍ��ݎ��s�Ȃ珉���l�ݒ�
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
            //  �V�X�e���J���[�쐬���͓���
            if (CreateSystemColor == true)
            {
                btnDelCustom.Visible = true;
                btnRenameCustom.Visible = true;
                grdProperty.Enabled = true;
                chkFocusBorder.Enabled = true;
            }

            //  �F����ݒ�
            SetPropertyInfomation(sif);
            ChangeMenuColor(null);

            //  ���̑���ʂ�ݒ�------------------------------------------------------------
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


            lstSubMenu.Columns[0].Width = lstSubMenu.ClientSize.Width - 2;              //  2006.09.29  �ǉ�

            bShowing = false;


            return ShowDialog();

        }

        /// <summary>
        /// ����ʃJ�e�S�����x���I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCategory_Click(object sender, EventArgs e)
        {

            grdProperty.SelectedObject = CartegroyLabel;
            lblSelectItem.Text = "�I���J�e�S��";

        }

        /// <summary>
        /// ����ʃv���p�e�B�O���b�h�l�ύX�C�x���g
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
        /// ����ʃJ�e�S���`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCategory_Paint(object sender, PaintEventArgs e)
        {
            //���Ăɔ����獕�ւ̃O���f�[�V�����̃u���V���쐬
            //g.VisibleClipBounds�͕\���N���b�s���O�̈�ɊO�ڂ���l�p�`
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, CartegroyLabel.BackColor1, CartegroyLabel.BackColor2, CartegroyLabel.GradiationMode);

            //�l�p��`��
            e.Graphics.FillRectangle(myBrush, e.Graphics.VisibleClipBounds);

            //�{�^����Text��`�悷�鏀��
            StringFormat sf = new StringFormat();
            //�������^�񒆂ɕ`��
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
            //Brush�̍쐬
            Brush brsh = new SolidBrush(CartegroyLabel.ForeColor);
            //�������`��
            e.Graphics.DrawString(((Label)sender).Text, ((Label)sender).Font, brsh, ((Label)sender).ClientRectangle, sf);

            //���\�[�X���J������
            brsh.Dispose();
            myBrush.Dispose();
            e.Dispose();

        }

        /// <summary>
        /// ����ʃT�u�J�e�S���I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubCategory_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = SubCartegroyList;
            lblSelectItem.Text = "�T�u�J�e�S��";
        }

        /// <summary>
        /// ����ʃJ�e�S���I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpCategory_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = CategroyButton;
            lblSelectItem.Text = "�J�e�S��";

        }

        /// <summary>
        /// ����ʃT�u���j���[�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpSubMenu_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = SubMenuButton;
            lblSelectItem.Text = "�T�u���j���[(�I���T�u�J�e�S��)";
        }

        /// <summary>
        /// ����ʃT�u���j���[�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grpSubMenu2_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = SubMenuButton;
            lblSelectItem.Text = "�T�u���j���[(�I���T�u�J�e�S��)";

        }

        /// <summary>
        /// ����ʃ^�u�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabBase_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = BackScreen;
            lblSelectItem.Text = "�^�u�w�i";

        }

        /// <summary>
        /// ����ʃ^�u�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_MouseDown(object sender, MouseEventArgs e)
        {
            grdProperty.SelectedObject = BackScreen;
            lblSelectItem.Text = "�^�u�w�i";

        }

        /// <summary>
        /// ����ʃJ�e�S���I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bShowing == false)
            {
                try
                {

                    //if ((int)gTopCategory[cmbCategory.SelectedIndex]["CategoryID"] == _mSystemMenuInfomation.SelectCategory)          //  2006.09.29  �ύX
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
                //_mSystemMenuInfomation.SelectCategory = (int)gTopCategory[cmbCategory.SelectedIndex]["CategoryID"];       //  2006.09.29 �ύX
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
                //CategoryInfo = SFNETMENU2Utilities.GetUserCategoryGroup(-101);    //  2007.01.10  �ύX
                CategoryInfo = SFNETMENU2Utilities.GetUserCategoryGroup(-1);
            }
            lstSubMenu.Items.Clear();
            for (int i = 0; i < CategoryInfo.Length; i++)
            {

                // �� �T�u�J�e�S�����������x�����Q�Ƃ��t�B���^�[��������
                bool SubCategoryCheck = false;

                if (CategoryInfo.Length != 0)
                {
                    SubCategoryCheck = SystemCheck.CheckAuthority(CategoryInfo[i]);
                }

                // ������������Ε\���ł��Ȃ�
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
                //ci.IconType = CategoryInfo[i]["IconType"].ToString();                 //  2006.09.29  �폜
                ci.IconIndex = (int)CategoryInfo[i]["IconIndex"];
                ci.IconName = CategoryInfo[i]["IconName"].ToString();
                //ci.SystemCode = CategoryInfo[i]["SystemCode"].ToString();             //  2006.09.29  �폜
                //ci.OptionCode = CategoryInfo[i]["OptionCode"].ToString();             //  2006.09.29  �폜
                ci.SysOpCode = CategoryInfo[i]["SysOpCode"].ToString();                 //  2006.09.29  �ǉ�
                ci.DisplayOption = CategoryInfo[i]["DisplayOption"].ToString();
                lvi.Tag = ci;
                lstSubMenu.Items.Add(lvi);
            }
            //  �K����ɖ����Ȃ��ꍇ�A�󔒂�����                                       //  2006.01.10  �ǉ�
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

            lstSubMenu.Columns[0].Width = lstSubMenu.ClientSize.Width - 2;              //  2006.09.29  �ǉ�

        }

        /// <summary>
        /// ����ʃT�u�J�e�S���I���C�x���g
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

                //  �A�N�e�B�u�C�x���g�������ňȍ~�̏����������Ə����\�������������Ȃ�̂ŗ}������
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
                        //  �����Ώۂ̃T�u���j���[�����݃A�N�e�B�u�Ȃ�A�N�e�B�u�𑼂ɐݒ肷��
                        if ((object)pnlDefMenu.Controls[i] == (object)pnlDefMenu.Tag)
                        {
                            if (pnlDefMenu.Controls.Count == 1)
                            {
                                //  ��݂̂Ȃ疳��
                                pnlDefMenu.Tag = null;
                            }
                            else if (i == 0)
                            {
                                //  �擪�Ȃ玟��
                                pnlDefMenu.Tag = pnlDefMenu.Controls[1];
                            }
                            else
                            {
                                //  ����ȊO�Ȃ�O��
                                pnlDefMenu.Tag = pnlDefMenu.Controls[i - 1];
                            }
                        }
                        ((TGroupButton)pnlDefMenu.Controls[i]).Dispose();
                        break;
                    }

                }
                //  �����Ώۂ��L������Đ���
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

            //  �A�N�e�B�u�C�x���g�������ňȍ~�̏����������Ə����\�������������Ȃ�̂ŗ}������
            if (bBeforeActive == true)
            {
                return;

            }
            //  �V�X�e�����j���[���̑I���ς݂̏�����U�N���A���Đݒ�
            _mSystemMenuInfomation.SelectSubMenuCollection.Clear();
            for (int i = 0; i < pnlDefMenu.Controls.Count; i++)
            {
                _mSystemMenuInfomation.SelectSubMenuCollection.Add(((SubCategoryInfomationWithNo)pnlDefMenu.Controls[i].Tag).SubCategoryInfo);
            }

        }

        /// <summary>
        /// ����ʃT�u���j���[�쐬����
        /// </summary>
        /// <param name="ciwn">�T�u�J�e�S�����</param>
        /// <returns>�쐬�O���[�v�{�^��</returns>
        /// <remarks>
        /// <br>Note       :����ʃT�u���j���[�쐬</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
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
                gb.Text = "�@�\" + i.ToString();
                gb.DescriptionText = "�ڍ�" + i.ToString();
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
        ///  ����ʃT�u���j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grpDefSubMenu_Click(object sender, EventArgs e)
        {
            pnlDefMenu.Tag = sender;
        }

        /// <summary>
        ///  ����ʃT�u���j���[���ړ��{�^�������������C�x���g
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
        ///  ����ʃT�u���j���[�E�ړ��{�^�������������C�x���g
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
        ///  �m��{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbTheme.Text.Length == 0)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "�I���G���[", "�e�[�}����I���E�ݒ肵�Ă��������B", "");
                tabSetting.SelectedIndex = 1;
                tabColor.Select();
                return;
            }
            //  �����\�����j���[�̕��я��𐧌�
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


            //  �V�X�e���J���[�쐬�p
            if (CreateSystemColor == true)
            {
                //  �쐬�������[�U�[�ݒ���V�X�e���ݒ�ɒǉ�����
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
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Option", "�ۑ��G���[", "�e�[�}���̏������݂Ɏ��s���܂����B\n\n�ēx�ݒ肵�Ă��������B", "-890");
                        return;
                    }


                }
                catch (Exception)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Option", "�ۑ��G���[", "�e�[�}���̏������݂Ɏ��s���܂����B\n\n�ēx�ݒ肵�Ă��������B", "-891");
                    return;
                }


            }

            //  ���̑��ݒ��ۑ�
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
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Option", "���̓G���[", "�_�C�A���O�̕\�����Ԃ͐����ŕb�P�ʂŐݒ肵�Ă��������B", "");
                tabSetting.SelectedIndex = 2;
                tabEtc.Select();
                return;
            }


            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///  �߂�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        /// <summary>
        ///  ��O��ʃ_�C�A���O�\�����Ԑݒ�ύX�����������C�x���g
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
        ///  ����ʃe�[�}�e�L�X�g�ύX�����������C�x���g
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
        ///  ����ʃe�[�}�ύX�����������C�x���g
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
                //  �V�X�e���J���[�쐬���͓���
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
        ///  ����ʃJ�X�^���ݒ�쐬�{�^�������������C�x���g
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
        ///  ����ʃJ�X�^���ݒ薼�{�^�������������C�x���g
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
        ///  ����ʃc�[���o�[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolBar_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = ToolbarLabel;
            lblSelectItem.Text = "�c�[���o�[";
        }

        /// <summary>
        ///  ����ʃc�[���o�[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolbarBack_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = ToolbarLabel;
            lblSelectItem.Text = "�c�[���o�[";

        }

        /// <summary>
        ///  ����ʃc�[���o�[�`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolBar_Paint(object sender, PaintEventArgs e)
        {
            //���Ăɔ����獕�ւ̃O���f�[�V�����̃u���V���쐬
            //g.VisibleClipBounds�͕\���N���b�s���O�̈�ɊO�ڂ���l�p�`
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, ToolbarLabel.ToolStripGradientBegin, ToolbarLabel.ToolStripGradientEnd, LinearGradientMode.Vertical);

            //�l�p��`��
            e.Graphics.FillRectangle(myBrush, e.Graphics.VisibleClipBounds);

            //�{�^����Text��`�悷�鏀��
            StringFormat sf = new StringFormat();
            //�������^�񒆂ɕ`��
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
            //Brush�̍쐬
            Brush brsh = new SolidBrush(((Label)sender).ForeColor);
            //�������`��
            e.Graphics.DrawString(((Label)sender).Text, ((Label)sender).Font, brsh, ((Label)sender).ClientRectangle, sf);

            //���\�[�X���J������
            brsh.Dispose();
            myBrush.Dispose();
            e.Dispose();

        }

        /// <summary>
        ///  ����ʃc�[���o�[�w�i�`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToolbarBack_Paint(object sender, PaintEventArgs e)
        {
            //���Ăɔ����獕�ւ̃O���f�[�V�����̃u���V���쐬
            //g.VisibleClipBounds�͕\���N���b�s���O�̈�ɊO�ڂ���l�p�`
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, ToolbarLabel.ToolStripPanelGradientBegin, ToolbarLabel.ToolStripPanelGradientEnd, LinearGradientMode.Vertical);

            //�l�p��`��
            e.Graphics.FillRectangle(myBrush, e.Graphics.VisibleClipBounds);

            //���\�[�X���J������
            myBrush.Dispose();
            e.Dispose();

        }

        /// <summary>
        ///  ����ʃ��j���[�o�[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMenuBar_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = MenuLabel;
            lblSelectItem.Text = "���j���[�o�[";

        }

        /// <summary>
        ///  ����ʃX�e�[�^�X�o�[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_Click(object sender, EventArgs e)
        {
            grdProperty.SelectedObject = StatusBarLabel;
            lblSelectItem.Text = "�X�e�[�^�X�o�[";

        }

        /// <summary>
        ///  ����ʃ��j���[�o�[�`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMenuBar_Paint(object sender, PaintEventArgs e)
        {
            lblMenuBar.ForeColor = _mScreenInfomation.MenuBarForeColor;
            lblMenuBar.BackColor = _mScreenInfomation.MenuBarBackColor;
        }

        /// <summary>
        ///  ����ʃX�e�[�^�X�o�[�`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_Paint(object sender, PaintEventArgs e)
        {
            lblStatusBar.ForeColor = _mScreenInfomation.MenuBarForeColor;
            lblStatusBar.BackColor = _mScreenInfomation.MenuBarBackColor;

        }

        /// <summary>
        ///  ����ʃJ�X�^���ݒ�폜�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelCustom_Click(object sender, EventArgs e)
        {
            //  �I�𖳂��Ȃ甲����                                                       //  2007.01.10  �ǉ�
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
        ///  ��O��ʍŋߎg�����@�\���ύX�������C�x���g
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
        ///  ����ʃt�H�[�J�X�g�ύX�������C�x���g
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
        ///  �t�H�[���A�N�e�B�u�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2E_Activated(object sender, EventArgs e)
        {

            //  �A�N�e�B�u�C�x���g����x�ł��������Ă���΍ēx�s��Ȃ�
            if (bBeforeActive == false)
            {
                return;
            }

            //  �T�u���j���[�\�����s��(�����ōs��Ȃ��ƃT�u���j���[�̕\�����Ԃ��s���ɂȂ�)
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

            bBeforeActive = false;       //  �A�N�e�B�u�C�x���g����

        }

        /// <summary>
        /// ����ʃT�u�J�e�S���`�F�b�N�������C�x���g
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
        /// ����ʐF���X�V���䏈��
        /// </summary>
        /// <param name="TargetObject">�ΏۃI�u�W�F�N�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :����ʐF���X�V����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
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
                    tabBase.Refresh();                                          //  2007.01.10  �ǉ�

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
        /// ����ʐF���ݒ菈��
        /// </summary>
        /// <param name="srcInfomation">��ʐF���</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :����ʐF���ݒ�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
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

            //  �������j���[�ݒ�̐F��ݒ�
            lstSubMenu.ForeColor = SubCartegroyList.ForeColor;
            lstSubMenu.BackColor = SubCartegroyList.BackColor;
            lstSubMenu.BackgroundImage = SubCartegroyList.BackgroundImage;
            lstSubMenu.BackgroundImageTiled = SubCartegroyList.BackgroundImageTiled;

            return 0;
        }

        /// <summary>
        /// ����ʃ^�u�R���g���[���`��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabBase_DrawItem(object sender, DrawItemEventArgs e)
        {

            //StringFormat���쐬
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            //�w�i�̕`��
            Brush bk = new SolidBrush(_mScreenInfomation.ScreenBackColor);
            e.Graphics.FillRectangle(bk, e.Graphics.VisibleClipBounds);

            Brush foreBrush, backBrush;

            //�^�u�y�[�W�̃e�L�X�g���擾
            string txt = tabBase.TabPages[0].Text;
            //  �^�u�y�[�W�ɐF�Â�(�J�e�S���[�̐F���ɗ͎g�p����)            // 2007.01.10  �ǉ�
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

            //Text�̕`��
            e.Graphics.DrawString(txt, tabBase.TabPages[0].Font, foreBrush, tabBase.GetTabRect(0), sf);

        }


    }

}
