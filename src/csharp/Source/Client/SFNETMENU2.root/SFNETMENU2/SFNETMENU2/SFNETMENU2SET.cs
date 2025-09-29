using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;

namespace Broadleaf.Windows.Forms
{


    /// <summary>
    /// ���j���[�֘A�ݒ���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���j���[�֘A�ݒ���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class MenuConfigration
    {
        public int InfoVer;                                     //  ���j���[�f�[�^���e���ǎ��̃`�F�b�N�p   //  2009.09.29  �ǉ�
        public SystemMenuInfomation SystemMenuInfo;
        public ScreenInfomation ScreenInfo;
        public SystemSettingInfomation SystemSettingInfo;
        public DataSet UserMenu;
    }

    /// <summary>
    /// ��ʐF���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ʐF���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class ScreenThemeInfomation
    {
        public int ThemeFig = 0;
        public ArrayList SceenTehme = new ArrayList();

    }

    /// <summary>
    /// �V�X�e���ݒ���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�X�e���ݒ���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class SystemSettingInfomation
    {
        public bool ShowDialog;
        public int DialogTimerInterval;
        public bool FuncKeyEnabled;
        public bool NumKeyEnabled;
        public int MaxRecentFig;
        public bool SaveLastPosition;
        public Point LastLocation;
        public bool SaveLastSize;
        public Size LastSize;
        public bool WindowMaximized;
        public int DateTimeFormat;
        public bool ShiftKeyPriority;
        public bool TabAutoDelete;
        public int  CategoryPriority;
        public bool TopMenu;//2008.09.26 sugi

        /// <summary>
        /// �V�X�e���ݒ���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e���ݒ���N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SystemSettingInfomation()
        {
            ShowDialog = true;
            DialogTimerInterval = 10;
            FuncKeyEnabled = true;
            NumKeyEnabled = true;
            MaxRecentFig = 10;
            SaveLastPosition = true;
            LastLocation = new Point(0, 0);
            SaveLastSize = true;
            LastSize = new Size(1016, 734);
            WindowMaximized = false;
            DateTimeFormat = 0;
            ShiftKeyPriority = true;
            TabAutoDelete = true;
            CategoryPriority = 0;
            TopMenu = true;//2008.09.26 sugi

        }

        /// <summary>
        /// �V�X�e���ݒ���R�s�[����
        /// </summary>
        /// <returns>�R�s�[�����������V�X�e���ݒ���</returns>
        /// <remarks>
        /// <br>Note       :�V�X�e���ݒ���R�s�[</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public SystemSettingInfomation Copy()
        {
            SystemSettingInfomation nThis = new SystemSettingInfomation();
            nThis.ShowDialog = ShowDialog;
            nThis.DialogTimerInterval = DialogTimerInterval;
            nThis.FuncKeyEnabled = FuncKeyEnabled;
            nThis.NumKeyEnabled = NumKeyEnabled;
            nThis.MaxRecentFig = MaxRecentFig;
            nThis.SaveLastPosition = SaveLastPosition;
            nThis.LastLocation = LastLocation;
            nThis.SaveLastSize = SaveLastSize;
            nThis.LastSize = LastSize;
            nThis.WindowMaximized = WindowMaximized;
            nThis.DateTimeFormat = DateTimeFormat;
            nThis.ShiftKeyPriority = ShiftKeyPriority;
            nThis.TabAutoDelete = TabAutoDelete;
            nThis.CategoryPriority = CategoryPriority;
            nThis.TopMenu = TopMenu;//2008.09.26 sugi

            return nThis;
        }
    }


    /// <summary>
    /// �N�����\�����j���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �N�����\�����j���[���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class SystemMenuInfomation
    {
        public int SelectCategory;
        public ArrayList arCategoryCollections = new ArrayList();
        public ArrayList SelectSubMenuCollection = new ArrayList();

        /// <summary>
        /// �N�����\�����j���[���R�s�[����
        /// </summary>
        /// <returns>�R�s�[�����������N�����\�����j���[���</returns>
        /// <remarks>
        /// <br>Note       :�N�����\�����j���[���R�s�[</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public SystemMenuInfomation Copy()
        {
            SystemMenuInfomation nThis = new SystemMenuInfomation();
            nThis.SelectCategory = SelectCategory;
            nThis.arCategoryCollections.Clear();
            for (int i = 0; i < arCategoryCollections.Count; i++)
            {
                nThis.arCategoryCollections.Add(arCategoryCollections[i]);
            }
            nThis.SelectSubMenuCollection.Clear();
            for (int i = 0; i < SelectSubMenuCollection.Count; i++)
            {
                nThis.SelectSubMenuCollection.Add(SelectSubMenuCollection[i]);
            }

            return nThis;
        }
    }

    /// <summary>
    /// �c�[���o�[�`����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �c�[���o�[�`����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class CustomProfessionalRenderer : ProfessionalColorTable
    {

        public Color _ToolStripGradientBegin;
        public Color _ToolStripGradientMiddle;
        public Color _ToolStripGradientEnd;
        //ToolStripPanel�̃O���f�[�V�����̐F���w��
        public Color _ToolStripPanelGradientBegin;
        public Color _ToolStripPanelGradientEnd;

        //ToolStrip�̃O���f�[�V�����̐F���w��
        public override Color ToolStripGradientBegin
        {
            get { return _ToolStripGradientBegin; }
        }

        public override Color ToolStripGradientMiddle
        {
            get { return _ToolStripGradientMiddle; }
        }

        public override Color ToolStripGradientEnd
        {
            get { return _ToolStripGradientEnd; }
        }

        //ToolStripPanel�̃O���f�[�V�����̐F���w��
        public override Color ToolStripPanelGradientBegin
        {
            get { return _ToolStripPanelGradientBegin; }
        }

        public override Color ToolStripPanelGradientEnd
        {
            get { return _ToolStripPanelGradientEnd; }
        }
    }

    /// <summary>
    /// �c�[���o�[�J�X�^���`����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �c�[���o�[�J�X�^���`����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.20 ����K��</br>
    /// </remarks>
    [Serializable()]
    public class CustomToolBarRenderer
    {

//        private Color _ToolStripGradientBegin;       <<2006.09.20
//        private Color _ToolStripGradientMiddle;
//        private Color _ToolStripGradientEnd;
//        private Color _ToolStripPanelGradientBegin;
//        private Color _ToolStripPanelGradientEnd;    >>2006.09.20
        public Color _ToolStripGradientBegin;
        public Color _ToolStripGradientMiddle;
        public Color _ToolStripGradientEnd;
        public Color _ToolStripPanelGradientBegin;
        public Color _ToolStripPanelGradientEnd;

        //ToolStrip�̃O���f�[�V�����̐F���w��
        public Color ToolStripGradientBegin
        {
            set { _ToolStripGradientBegin = value; }
            get { return _ToolStripGradientBegin; }
        }

        public Color ToolStripGradientMiddle
        {
            set { _ToolStripGradientMiddle = value; }
            get { return _ToolStripGradientMiddle; }
        }

        public Color ToolStripGradientEnd
        {
            set { _ToolStripGradientEnd = value; }
            get { return _ToolStripGradientEnd; }
        }

        //ToolStripPanel�̃O���f�[�V�����̐F���w��
        public Color ToolStripPanelGradientBegin
        {
            set { _ToolStripPanelGradientBegin = value; }
            get { return _ToolStripPanelGradientBegin; }
        }

        public Color ToolStripPanelGradientEnd
        {
            set { _ToolStripPanelGradientEnd = value; }
            get { return _ToolStripPanelGradientEnd; }
        }
    }

    /// <summary>
    /// ��ʐF���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ʐF���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class ScreenInfomation
    {

        public Guid ThemeID;
        public bool SystemServe = false;
        public string ThemeName;

        public Color ToolBarForeColor;
        public CustomToolBarRenderer ToolBarColor = new CustomToolBarRenderer();

        public bool FocusBorderBold;
        public Color MenuBarForeColor;
        public Color MenuBarBackColor;
        public Color StatusBarForeColor;
        public Color StatusBarBackColor;
        public Color CategoryLabelForeColor;
        public Color CategoryLabelBackColor1;
        public Color CategoryLabelBackColor2;
        public LinearGradientMode CategoryLabelGradiationMode;

        public Color SubCategoryForeColor;
        public Color SubCategoryBackColor;
        public Image SubCategoryBackImage;
        public bool SubCategoryBackImageTiled;

        public Color CategoryForeColor;
        public Color CategoryBackColor1;
        public Color CategoryBackColor2;
        public LinearGradientMode CategoryGradiationMode;
        public Color CategoryButtonBackColor1;
        public Color CategoryButtonBackColor2;
        public Color CategorySelectedButtonForeColor;
        public Color CategorySelectedButtonFaceColor1;
        public Color CategorySelectedButtonFaceColor2;
        public LinearGradientMode CategoryButtonGradiationMode;
        public Image CategoryBackImage;
        public ImageLayout CategoryBackImageLayout;
        public Color CategoryActivePanelBorderColor;
        public Color CategoryFocusButtonBorderColor;
        public Color CategoryHotTrackingColor;

        public Color SubMenuBackColor1;
        public Color SubMenuBackColor2;
        public LinearGradientMode SubMenuGradiationMode;
        public Color SubMenuForeColor;
        public Color SubMenuButtonBackColor1;
        public Color SubMenuButtonBackColor2;
        public LinearGradientMode SubMenuButtonGradiationMode;
        public Color SubMenuSelectedButtonForeColor;
        public Color SubMenuSelectedButtonFaceColor1;
        public Color SubMenuSelectedButtonFaceColor2;
        public Color SubMenuHeaderForeColor;
        public Color SubMenuHeaderBackColor1;
        public Color SubMenuHeaderBackColor2;
        public LinearGradientMode SubMenuHeaderGradiationMode;
        public Color SubMenuHeaderActiveForeColor;
        public Image SubMenuBackImage;
        public ImageLayout SubMenuBackImageLayout;
        public Color SubMenuDescForeColor;
        public Color SubMenuDescBackColor1;
        public Color SubMenuDescBackColor2;
        public Color SubMenuDescLineColor;
        public LinearGradientMode SubMenuDescGradientMode;
        public Color SubMenuActivePanelBorderColor;
        public Color SubMenuFocusButtonBorderColor;
        public Color SubMenuHotTrackingColor;

        public Color TabPageBackColor;
        public Image TabPageBackImage;
        public ImageLayout TabPageBackImageLayout;
        public Color ScreenBackColor;

        /// <summary>
        /// ��ʐF���R�s�[����
        /// </summary>
        /// <returns>�R�s�[������������ʐF���</returns>
        /// <remarks>
        /// <br>Note       :��ʐF���R�s�[</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public ScreenInfomation Copy()
        {
            ScreenInfomation nThis = new ScreenInfomation();
            nThis.ThemeID = ThemeID;
            nThis.SystemServe = SystemServe;
            nThis.ThemeName = ThemeName;
            nThis.ToolBarForeColor = ToolBarForeColor;
            nThis.ToolBarColor = ToolBarColor;
            nThis.FocusBorderBold = FocusBorderBold;
            nThis.MenuBarForeColor = MenuBarForeColor;
            nThis.MenuBarBackColor = MenuBarBackColor;
            nThis.StatusBarForeColor = StatusBarForeColor;
            nThis.StatusBarBackColor = StatusBarBackColor;
            nThis.CategoryLabelForeColor = CategoryLabelForeColor;
            nThis.CategoryLabelBackColor1 = CategoryLabelBackColor1;
            nThis.CategoryLabelBackColor2 = CategoryLabelBackColor2;
            nThis.CategoryLabelGradiationMode = CategoryLabelGradiationMode;
            nThis.SubCategoryForeColor = SubCategoryForeColor;
            nThis.SubCategoryBackColor = SubCategoryBackColor;
            nThis.SubCategoryBackImage = SubCategoryBackImage;
            nThis.SubCategoryBackImageTiled = SubCategoryBackImageTiled;
            nThis.CategoryForeColor = CategoryForeColor;
            nThis.CategoryBackColor1 = CategoryBackColor1;
            nThis.CategoryBackColor2 = CategoryBackColor2;
            nThis.CategoryGradiationMode = CategoryGradiationMode;
            nThis.CategoryButtonBackColor1 = CategoryButtonBackColor1;
            nThis.CategoryButtonBackColor2 = CategoryButtonBackColor2;
            nThis.CategoryButtonGradiationMode = CategoryButtonGradiationMode;
            nThis.CategorySelectedButtonForeColor = CategorySelectedButtonForeColor;
            nThis.CategorySelectedButtonFaceColor1 = CategorySelectedButtonFaceColor1;
            nThis.CategorySelectedButtonFaceColor2 = CategorySelectedButtonFaceColor2;
            nThis.CategoryBackImage = CategoryBackImage;
            nThis.CategoryBackImageLayout = CategoryBackImageLayout;
            nThis.CategoryActivePanelBorderColor = CategoryActivePanelBorderColor;
            nThis.CategoryFocusButtonBorderColor = CategoryFocusButtonBorderColor;
            nThis.CategoryHotTrackingColor = CategoryHotTrackingColor;
            nThis.SubMenuBackColor1 = SubMenuBackColor1;
            nThis.SubMenuBackColor2 = SubMenuBackColor2;
            nThis.SubMenuGradiationMode = SubMenuGradiationMode;
            nThis.SubMenuForeColor = SubMenuForeColor;
            nThis.SubMenuButtonBackColor1 = SubMenuButtonBackColor1;
            nThis.SubMenuButtonBackColor2 = SubMenuButtonBackColor2;
            nThis.SubMenuButtonGradiationMode = SubMenuButtonGradiationMode;
            nThis.SubMenuSelectedButtonForeColor = SubMenuSelectedButtonForeColor;
            nThis.SubMenuSelectedButtonFaceColor1 = SubMenuSelectedButtonFaceColor1;
            nThis.SubMenuSelectedButtonFaceColor2 = SubMenuSelectedButtonFaceColor2;
            nThis.SubMenuHeaderForeColor = SubMenuHeaderForeColor;
            nThis.SubMenuHeaderBackColor1 = SubMenuHeaderBackColor1;
            nThis.SubMenuHeaderBackColor2 = SubMenuHeaderBackColor2;
            nThis.SubMenuHeaderGradiationMode = SubMenuHeaderGradiationMode;
            nThis.SubMenuHeaderActiveForeColor = SubMenuHeaderActiveForeColor;
            nThis.SubMenuBackImage = SubMenuBackImage;
            nThis.SubMenuBackImageLayout = SubMenuBackImageLayout;
            nThis.SubMenuDescForeColor = SubMenuDescForeColor;
            nThis.SubMenuDescBackColor1 = SubMenuDescBackColor1;
            nThis.SubMenuDescBackColor2 = SubMenuDescBackColor2;
            nThis.SubMenuDescLineColor = SubMenuDescLineColor;
            nThis.SubMenuDescGradientMode = SubMenuDescGradientMode;
            nThis.SubMenuActivePanelBorderColor = SubMenuActivePanelBorderColor;
            nThis.SubMenuFocusButtonBorderColor = SubMenuFocusButtonBorderColor;
            nThis.SubMenuHotTrackingColor = SubMenuHotTrackingColor;

            nThis.TabPageBackColor = TabPageBackColor;
            nThis.TabPageBackImage = TabPageBackImage;
            nThis.TabPageBackImageLayout = TabPageBackImageLayout;
            nThis.ScreenBackColor = ScreenBackColor;

            return nThis;

        }

        /// <summary>
        /// ��ʐF���R�s�[����
        /// </summary>
        /// <returns>�w������ɐF�����R�s�[����</returns>
        /// <remarks>
        /// <br>Note       :��ʐF���R�s�[</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public ScreenInfomation Copy(ScreenInfomation DestScreenInfo)
        {

            DestScreenInfo.ThemeID = ThemeID;
            DestScreenInfo.SystemServe = SystemServe;
            DestScreenInfo.ThemeName = ThemeName;
            DestScreenInfo.ToolBarForeColor = ToolBarForeColor;
            DestScreenInfo.ToolBarColor = ToolBarColor;
            DestScreenInfo.FocusBorderBold = FocusBorderBold;
            DestScreenInfo.MenuBarForeColor = MenuBarForeColor;
            DestScreenInfo.MenuBarBackColor = MenuBarBackColor;
            DestScreenInfo.StatusBarForeColor = StatusBarForeColor;
            DestScreenInfo.StatusBarBackColor = StatusBarBackColor;
            DestScreenInfo.CategoryLabelForeColor = CategoryLabelForeColor;
            DestScreenInfo.CategoryLabelBackColor1 = CategoryLabelBackColor1;
            DestScreenInfo.CategoryLabelBackColor2 = CategoryLabelBackColor2;
            DestScreenInfo.CategoryLabelGradiationMode = CategoryLabelGradiationMode;
            DestScreenInfo.SubCategoryForeColor = SubCategoryForeColor;
            DestScreenInfo.SubCategoryBackColor = SubCategoryBackColor;
            DestScreenInfo.SubCategoryBackImage = SubCategoryBackImage;
            DestScreenInfo.SubCategoryBackImageTiled = SubCategoryBackImageTiled;
            DestScreenInfo.CategoryForeColor = CategoryForeColor;
            DestScreenInfo.CategoryBackColor1 = CategoryBackColor1;
            DestScreenInfo.CategoryBackColor2 = CategoryBackColor2;
            DestScreenInfo.CategoryGradiationMode = CategoryGradiationMode;
            DestScreenInfo.CategoryButtonBackColor1 = CategoryButtonBackColor1;
            DestScreenInfo.CategoryButtonBackColor2 = CategoryButtonBackColor2;
            DestScreenInfo.CategoryButtonGradiationMode = CategoryButtonGradiationMode;
            DestScreenInfo.CategorySelectedButtonForeColor = CategorySelectedButtonForeColor;
            DestScreenInfo.CategorySelectedButtonFaceColor1 = CategorySelectedButtonFaceColor1;
            DestScreenInfo.CategorySelectedButtonFaceColor2 = CategorySelectedButtonFaceColor2;
            DestScreenInfo.CategoryBackImage = CategoryBackImage;
            DestScreenInfo.CategoryBackImageLayout = CategoryBackImageLayout;
            DestScreenInfo.CategoryActivePanelBorderColor = CategoryActivePanelBorderColor;
            DestScreenInfo.CategoryFocusButtonBorderColor = CategoryFocusButtonBorderColor;
            DestScreenInfo.CategoryHotTrackingColor = CategoryHotTrackingColor;
            DestScreenInfo.SubMenuBackColor1 = SubMenuBackColor1;
            DestScreenInfo.SubMenuBackColor2 = SubMenuBackColor2;
            DestScreenInfo.SubMenuGradiationMode = SubMenuGradiationMode;
            DestScreenInfo.SubMenuForeColor = SubMenuForeColor;
            DestScreenInfo.SubMenuButtonBackColor1 = SubMenuButtonBackColor1;
            DestScreenInfo.SubMenuButtonBackColor2 = SubMenuButtonBackColor2;
            DestScreenInfo.SubMenuButtonGradiationMode = SubMenuButtonGradiationMode;
            DestScreenInfo.SubMenuSelectedButtonForeColor = SubMenuSelectedButtonForeColor;
            DestScreenInfo.SubMenuSelectedButtonFaceColor1 = SubMenuSelectedButtonFaceColor1;
            DestScreenInfo.SubMenuSelectedButtonFaceColor2 = SubMenuSelectedButtonFaceColor2;
            DestScreenInfo.SubMenuHeaderForeColor = SubMenuHeaderForeColor;
            DestScreenInfo.SubMenuHeaderBackColor1 = SubMenuHeaderBackColor1;
            DestScreenInfo.SubMenuHeaderBackColor2 = SubMenuHeaderBackColor2;
            DestScreenInfo.SubMenuHeaderGradiationMode = SubMenuHeaderGradiationMode;
            DestScreenInfo.SubMenuHeaderActiveForeColor = SubMenuHeaderActiveForeColor;
            DestScreenInfo.SubMenuBackImage = SubMenuBackImage;
            DestScreenInfo.SubMenuBackImageLayout = SubMenuBackImageLayout;
            DestScreenInfo.SubMenuDescForeColor = SubMenuDescForeColor;
            DestScreenInfo.SubMenuDescBackColor1 = SubMenuDescBackColor1;
            DestScreenInfo.SubMenuDescBackColor2 = SubMenuDescBackColor2;
            DestScreenInfo.SubMenuDescGradientMode = SubMenuDescGradientMode;
            DestScreenInfo.SubMenuDescLineColor = SubMenuDescLineColor;
            DestScreenInfo.TabPageBackColor = TabPageBackColor;
            DestScreenInfo.TabPageBackImage = TabPageBackImage;
            DestScreenInfo.TabPageBackImageLayout = TabPageBackImageLayout;
            DestScreenInfo.ScreenBackColor = ScreenBackColor;
            DestScreenInfo.SubMenuActivePanelBorderColor = SubMenuActivePanelBorderColor;
            DestScreenInfo.SubMenuFocusButtonBorderColor = SubMenuFocusButtonBorderColor;
            DestScreenInfo.SubMenuHotTrackingColor = SubMenuHotTrackingColor;
            DestScreenInfo.SubMenuActivePanelBorderColor = SubMenuActivePanelBorderColor;
            DestScreenInfo.SubMenuFocusButtonBorderColor = SubMenuFocusButtonBorderColor;
            DestScreenInfo.SubMenuHotTrackingColor = SubMenuHotTrackingColor;

            return DestScreenInfo;

        }

    }

    /// <summary>
    /// �c�[���o�[�F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �c�[���o�[�F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class ToolBarSetting
    {

        private Color _ToolStripForeColor;
        private Color _ToolStripGradientBegin;
        private Color _ToolStripGradientMiddle;
        private Color _ToolStripGradientEnd;
        private Color _ToolStripPanelGradientBegin;
        private Color _ToolStripPanelGradientEnd;


        [Category("�F")]
        [Description("�����F��ݒ肵�܂�")]
        [DisplayName("�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripForeColor
        {
            get { return _ToolStripForeColor; }
            set { _ToolStripForeColor = value; }
        }

        [Category("�F")]
        [Description("�c�[���o�[�w�i�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�c�[���o�[�w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripGradientBegin
        {
            set { _ToolStripGradientBegin = value; }
            get { return _ToolStripGradientBegin; }
        }


        [Category("�F")]
        [Description("�c�[���o�[�w�i�̃O���f�[�V�����̒��ԐF��ݒ肵�܂�")]
        [DisplayName("�c�[���o�[�w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripGradientMiddle
        {
            set { _ToolStripGradientMiddle = value; }
            get { return _ToolStripGradientMiddle; }
        }


        [Category("�F")]
        [Description("�c�[���o�[�w�i�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�c�[���o�[�w�i�F3")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripGradientEnd
        {
            set { _ToolStripGradientEnd = value; }
            get { return _ToolStripGradientEnd; }
        }

        [Category("�F")]
        [Description("�p�l���w�i�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�p�l���w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripPanelGradientBegin
        {
            set { _ToolStripPanelGradientBegin = value; }
            get { return _ToolStripPanelGradientBegin; }
        }

        [Category("�F")]
        [Description("�p�l���w�i�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�p�l���w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripPanelGradientEnd
        {
            set { _ToolStripPanelGradientEnd = value; }
            get { return _ToolStripPanelGradientEnd; }
        }
    }

    /// <summary>
    /// �w�i�F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �w�i�F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class BackgroundSetting
    {
        private Color _TabPageBackColor;
        private Image _TabPageBackImage;
        private ImageLayout _TabPageBackImageLayout;
        private Color _ScreenBackColor;

        [Category("�F")]
        [Description("�^�u�w�i�F��ݒ肵�܂�")]
        [DisplayName("�^�u�w�i�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color TabPageBackColor
        {
            get { return _TabPageBackColor; }
            set { _TabPageBackColor = value; }
        }

        [Category("�摜")]
        [Description("�^�u�w�i�̉摜��\���ݒ���s���܂�")]
        [DisplayName("�^�u�w�i�摜�\���ݒ�")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool TabPageBackImageVisible
        {
            get
            {
                if (_TabPageBackImage != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value == false)
                {
                    _TabPageBackImage = null;
                }
            }
        }

        [Category("�摜")]
        [Description("�^�u�w�i�摜��ݒ肵�܂�")]
        [DisplayName("�^�u�w�i�w�摜")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image TabPageBackImage
        {
            get { return _TabPageBackImage; }
            set { _TabPageBackImage = value; }
        }

        [Category("�摜")]
        [Description("�^�u�w�i�摜�̕\�����@��ݒ肵�܂�")]
        [DisplayName("�^�u�w�i�摜�\���`��")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageLayout TabPageBackImageLayout
        {
            get { return _TabPageBackImageLayout; }
            set { _TabPageBackImageLayout = value; }
        }

        [Category("�F")]
        [Description("��ʔw�i�F��ݒ肵�܂�")]
        [DisplayName("��ʔw�i�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ScreenBackColor
        {
            get { return _ScreenBackColor; }
            set { _ScreenBackColor = value; }
        }

    }

    /// <summary>
    /// ��{�F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��{�F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class BasicSetting
    {
        private Color _BackColor;
        private Color _ForeColor;

        [Category("�F")]
        [Description("�w�i�F��ݒ肵�܂�")]
        [DisplayName("�w�i�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }


        [Category("�F")]
        [Description("�����F��ݒ肵�܂�")]
        [DisplayName("�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

    }

    /// <summary>
    /// �J�e�S�����x���F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �J�e�S�����x���F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class CategoryInfoSetting
    {
        private Color _CategoryLabelForeColor;
        private Color _CategoryLabelBackColor1;
        private Color _CategoryLabelBackColor2;
        private LinearGradientMode _CategoryLabelGradiationMode;

        [Category("�F")]
        [Description("�����F��ݒ肵�܂�")]
        [DisplayName("�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _CategoryLabelForeColor; }
            set { _CategoryLabelForeColor = value; }
        }

        [Category("�F")]
        [Description("�w�i�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor1
        {
            get { return _CategoryLabelBackColor1; }
            set { _CategoryLabelBackColor1 = value; }
        }

        [Category("�F")]
        [Description("�w�i�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor2
        {
            get { return _CategoryLabelBackColor2; }
            set { _CategoryLabelBackColor2 = value; }
        }

        [Category("�F")]
        [Description("�O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("�O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode GradiationMode
        {
            get { return _CategoryLabelGradiationMode; }
            set { _CategoryLabelGradiationMode = value; }
        }

    }

    /// <summary>
    /// �T�u�J�e�S���F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �T�u�J�e�S���F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class SubCategorySetting
    {
        private Color _SubCategoryForeColor;
        private Color _SubCategoryLabelBackColor;
        private Image _SubCategoryBackImage;
        private bool _SubCategoryBackImageTiled;

        [Category("�F")]
        [Description("�����F��ݒ肵�܂�")]
        [DisplayName("�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _SubCategoryForeColor; }
            set { _SubCategoryForeColor = value; }
        }

        [Category("�F")]
        [Description("�w�i�F��ݒ肵�܂�")]
        [DisplayName("�w�i�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor
        {
            get { return _SubCategoryLabelBackColor; }
            set { _SubCategoryLabelBackColor = value; }
        }

        [Category("�摜")]
        [Description("�w�i�̉摜��\���ݒ���s���܂�")]
        [DisplayName("�w�i�摜�\���ݒ�")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool BackgroundImageVisible
        {
            get
            {
                if (_SubCategoryBackImage != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value == false)
                {
                    _SubCategoryBackImage = null;
                }
            }
        }

        [Category("�摜")]
        [Description("�w�i�̉摜��ݒ肵�܂�")]
        [DisplayName("�w�i�摜")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image BackgroundImage
        {
            get { return _SubCategoryBackImage; }
            set { _SubCategoryBackImage = value; }
        }

        [Category("�摜")]
        [Description("�w�i�摜���^�C���`���ŕ\�����܂�")]
        [DisplayName("�w�i�摜�\���`��")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool BackgroundImageTiled
        {
            get { return _SubCategoryBackImageTiled; }
            set { _SubCategoryBackImageTiled = value; }
        }

    }

    /// <summary>
    /// �J�e�S���F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �J�e�S���F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class CategorySetting
    {
        private Color _CategoryBackColor1;
        private Color _CategoryBackColor2;
        private LinearGradientMode _CategoryGradiationMode;
        private Color _CategoryButtonForeColor;
        private Color _CategoryButtonBackColor1;
        private Color _CategoryButtonBackColor2;
        private Color _CategorySelectedButtonForeColor;
        private Color _CategorySelectedButtonFaceColor1;
        private Color _CategorySelectedButtonFaceColor2;
        private LinearGradientMode _CategoryButtonGradiationMode;
        private Image _CategoryBackImage;
        private ImageLayout _CategoryBackImageLayout;
        private Color _ActivePanelBorderColor;
        private Color _FocusButtonBorderColor;
        private Color _HotTrackingColor;

        [Category("�{�^��")]
        [Description("�����F��ݒ肵�܂�")]
        [DisplayName("�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _CategoryButtonForeColor; }
            set { _CategoryButtonForeColor = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�{�^���F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor1
        {
            get { return _CategoryButtonBackColor1; }
            set { _CategoryButtonBackColor1 = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�{�^���F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor2
        {
            get { return _CategoryButtonBackColor2; }
            set { _CategoryButtonBackColor2 = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̃O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("�{�^���O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode ButtonGradiationMode
        {
            get { return _CategoryButtonGradiationMode; }
            set { _CategoryButtonGradiationMode = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̑I�𕶎��F��ݒ肵�܂�")]
        [DisplayName("�{�^���I�𕶎��F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonForeColor
        {
            get { return _CategorySelectedButtonForeColor; }
            set { _CategorySelectedButtonForeColor = value; }
        }

        [Category("�{�^��")]
        [Description("�}�E�X�ł̑I�����̃{�^���w�i�J�n�F��ݒ肵�܂�")]
        [DisplayName("�}�E�X�I��w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor1
        {
            get { return _CategorySelectedButtonFaceColor1; }
            set { _CategorySelectedButtonFaceColor1 = value; }
        }

        [Category("�{�^��")]
        [Description("�}�E�X�ł̑I�����̃{�^���w�i�I���F��ݒ肵�܂�")]
        [DisplayName("�}�E�X�I��w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor2
        {
            get { return _CategorySelectedButtonFaceColor2; }
            set { _CategorySelectedButtonFaceColor2 = value; }
        }

        [Category("�{�^��")]
        [Description("�L�[�t�H�[�J�X�̂���{�^���g�̐F��ݒ肵�܂�")]
        [DisplayName("�L�[�t�H�[�J�X�{�^���g�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color FocusButtonBorderColor
        {
            get { return _FocusButtonBorderColor; }
            set { _FocusButtonBorderColor = value; }
        }

        [Category("�{�^��")]
        [Description("�}�E�X�t�H�[�J�X�̂���{�^���g�̐F��ݒ肵�܂�")]
        [DisplayName("�}�E�X�t�H�[�J�X�{�^���g�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HotTrackingColor
        {
            get { return _HotTrackingColor; }
            set { _HotTrackingColor = value; }
        }

        [Category("�F")]
        [Description("�w�i�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor1
        {
            get { return _CategoryBackColor1; }
            set { _CategoryBackColor1 = value; }
        }

        [Category("�F")]
        [Description("�w�i�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor2
        {
            get { return _CategoryBackColor2; }
            set { _CategoryBackColor2 = value; }
        }

        [Category("�F")]
        [Description("�w�i�F�̃O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("�w�i�O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode GradiationMode
        {
            get { return _CategoryGradiationMode; }
            set { _CategoryGradiationMode = value; }
        }

        [Category("�F")]
        [Description("�A�N�e�B�u�ȃp�l���g�̐F��ݒ肵�܂�")]
        [DisplayName("�A�N�e�B�u�p�l���g�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ActivePanelBorderColor
        {
            get { return _ActivePanelBorderColor; }
            set { _ActivePanelBorderColor = value; }
        }

        [Category("�摜")]
        [Description("�w�i�̉摜��\���ݒ���s���܂�")]
        [DisplayName("�w�i�摜�\���ݒ�")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool BackgroundImageVisible
        {
            get
            {
                if (_CategoryBackImage != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value == false)
                {
                    _CategoryBackImage = null;
                }
            }
        }

        [Category("�摜")]
        [Description("�w�i�̉摜��ݒ肵�܂�")]
        [DisplayName("�w�i�摜")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image BackgroundImage
        {
            get { return _CategoryBackImage; }
            set { _CategoryBackImage = value; }
        }

        [Category("�摜")]
        [Description("�w�i�摜�̕\�����@��ݒ肵�܂�")]
        [DisplayName("�w�i�摜�\���`��")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageLayout BackgroundImageLayout
        {
            get { return _CategoryBackImageLayout; }
            set { _CategoryBackImageLayout = value; }
        }

    }

    /// <summary>
    /// �T�u���j���[�F���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �T�u���j���[�F���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class SubMenuSetting
    {
        private Color _SubMenuBackColor1;
        private Color _SubMenuBackColor2;
        private LinearGradientMode _SubMenuGradiationMode;
        private Color _SubMenuHeaderForeColor;
        private Color _SubMenuHeaderBackColor1;
        private Color _SubMenuHeaderBackColor2;
        private LinearGradientMode _SubMenuHeaderGradiationMode;
        private Color _SubMenuHeaderActiveColor;
        private Color _SubMenuButtonForeColor;
        private Color _SubMenuButtonBackColor1;
        private Color _SubMenuButtonBackColor2;
        private Color _SubMenuSelectedButtonForeColor;
        private Color _SubMenuSelectedButtonFaceColor1;
        private Color _SubMenuSelectedButtonFaceColor2;
        private LinearGradientMode _SubMenuButtonGradiationMode;
        private Image _SubMenuBackImage;
        private ImageLayout _SubMenuBackImageLayout;
        private Color _SubMenuDescForeColor;
        private Color _SubMenuDescBackColor1;
        private Color _SubMenuDescBackColor2;
        private Color _SubMenuDescLineColor;
        private LinearGradientMode _SubMenuDescGradientMode;
        private Color _ActivePanelBorderColor;
        private Color _FocusButtonBorderColor;
        private Color _HotTrackingColor;
             

        [Category("���o��")]
        [Description("���o�������F��ݒ肵�܂�")]
        [DisplayName("���o�������F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderForeColor
        {
            get { return _SubMenuHeaderForeColor; }
            set { _SubMenuHeaderForeColor = value; }
        }

        [Category("���o��")]
        [Description("���o���w�i�F�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("���o���w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderBackColor1
        {
            get { return _SubMenuHeaderBackColor1; }
            set { _SubMenuHeaderBackColor1 = value; }
        }

        [Category("���o��")]
        [Description("���o���w�i�F�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("���o���w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderBackColor2
        {
            get { return _SubMenuHeaderBackColor2; }
            set { _SubMenuHeaderBackColor2 = value; }
        }

        [Category("���o��")]
        [Description("���o���w�i�F�̃O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("���o���w�i�F�O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode HeaderGradiationMode
        {
            get { return _SubMenuHeaderGradiationMode; }
            set { _SubMenuHeaderGradiationMode = value; }
        }

        [Category("���o��")]
        [Description("�A�N�e�B�u�ȃp�l���̌��o�������F��ݒ肵�܂�")]
        [DisplayName("�A�N�e�B�u�p�l�����o�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderActiveForeColor
        {
            get { return _SubMenuHeaderActiveColor; }
            set { _SubMenuHeaderActiveColor = value; }
        }

        [Category("�{�^��")]
        [Description("�����F��ݒ肵�܂�")]
        [DisplayName("�����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _SubMenuButtonForeColor; }
            set { _SubMenuButtonForeColor = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�{�^���F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor1
        {
            get { return _SubMenuButtonBackColor1; }
            set { _SubMenuButtonBackColor1 = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�{�^���F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor2
        {
            get { return _SubMenuButtonBackColor2; }
            set { _SubMenuButtonBackColor2 = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̃O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("�{�^���O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode ButtonGradiationMode
        {
            get { return _SubMenuButtonGradiationMode; }
            set { _SubMenuButtonGradiationMode = value; }
        }

        [Category("�{�^��")]
        [Description("�{�^���̑I�𕶎��F��ݒ肵�܂�")]
        [DisplayName("�{�^���I�𕶎��F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonForeColor
        {
            get { return _SubMenuSelectedButtonForeColor; }
            set { _SubMenuSelectedButtonForeColor = value; }
        }

        [Category("�{�^��")]
        [Description("�}�E�X�ł̑I�����̃{�^���w�i�J�n�F��ݒ肵�܂�")]
        [DisplayName("�}�E�X�I��w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor1
        {
            get { return _SubMenuSelectedButtonFaceColor1; }
            set { _SubMenuSelectedButtonFaceColor1 = value; }
        }

        [Category("�{�^��")]
        [Description("�}�E�X�ł̑I�����̃{�^���w�i�I���F��ݒ肵�܂�")]
        [DisplayName("�}�E�X�I��w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor2
        {
            get { return _SubMenuSelectedButtonFaceColor2; }
            set { _SubMenuSelectedButtonFaceColor2 = value; }
        }

        [Category("�{�^��")]
        [Description("�L�[�t�H�[�J�X�̂���{�^���g�̐F��ݒ肵�܂�")]
        [DisplayName("�L�[�t�H�[�J�X�{�^���g�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color FocusButtonBorderColor
        {
            get { return _FocusButtonBorderColor; }
            set { _FocusButtonBorderColor = value; }
        }

        [Category("�{�^��")]
        [Description("�}�E�X�t�H�[�J�X�̂���{�^���g�̐F��ݒ肵�܂�")]
        [DisplayName("�}�E�X�t�H�[�J�X�{�^���g�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HotTrackingColor
        {
            get { return _HotTrackingColor; }
            set { _HotTrackingColor = value; }
        }

        [Category("�F")]
        [Description("�w�i�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�w�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor1
        {
            get { return _SubMenuBackColor1; }
            set { _SubMenuBackColor1 = value; }
        }

        [Category("�F")]
        [Description("�w�i�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�w�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor2
        {
            get { return _SubMenuBackColor2; }
            set { _SubMenuBackColor2 = value; }
        }

        [Category("�F")]
        [Description("�w�i�F�̃O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("�w�i�O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode GradiationMode
        {
            get { return _SubMenuGradiationMode; }
            set { _SubMenuGradiationMode = value; }
        }

        [Category("�F")]
        [Description("�A�N�e�B�u�ȃp�l���g�̐F��ݒ肵�܂�")]
        [DisplayName("�A�N�e�B�u�p�l���g�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ActivePanelBorderColor
        {
            get { return _ActivePanelBorderColor; }
            set { _ActivePanelBorderColor = value; }
        }

        [Category("�摜")]
        [Description("�w�i�̉摜��\���ݒ���s���܂�")]
        [DisplayName("�w�i�摜�\���ݒ�")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool BackgroundImageVisible
        {
            get
            {
                if (_SubMenuBackImage != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value == false)
                {
                    _SubMenuBackImage = null;
                }
            }
        }

        [Category("�摜")]
        [Description("�w�i�̉摜��ݒ肵�܂�")]
        [DisplayName("�w�i�摜")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image BackgroundImage
        {
            get {  return _SubMenuBackImage; }
            set { _SubMenuBackImage = value; }
        }

        [Category("�摜")]
        [Description("�w�i�摜�̕\�����@��ݒ肵�܂�")]
        [DisplayName("�w�i�摜�\���`��")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageLayout BackgroundImageLayout
        {
            get { return _SubMenuBackImageLayout; }
            set { _SubMenuBackImageLayout = value; }
        }
        [Category("�ڍ�")]
        [Description("�ڍו����F��ݒ肵�܂�")]
        [DisplayName("�ڍו����F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescForeColor
        {
            get { return _SubMenuDescForeColor; }
            set { _SubMenuDescForeColor = value; }
        }

        [Category("�ڍ�")]
        [Description("�ڍׂ̘g�F��ݒ肵�܂�")]
        [DisplayName("�ڍטg�F")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescLineColor
        {
            get { return _SubMenuDescLineColor; }
            set { _SubMenuDescLineColor = value; }
        }

        [Category("�ڍ�")]
        [Description("�ڍהw�i�̃O���f�[�V�����̊J�n�F��ݒ肵�܂�")]
        [DisplayName("�ڍהw�i�F1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescBackColor1
        {
            get { return _SubMenuDescBackColor1; }
            set { _SubMenuDescBackColor1 = value; }
        }

        [Category("�ڍ�")]
        [Description("�ڍהw�i�̃O���f�[�V�����̏I���F��ݒ肵�܂�")]
        [DisplayName("�ڍהw�i�F2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescBackColor2
        {
            get { return _SubMenuDescBackColor2; }
            set { _SubMenuDescBackColor2 = value; }
        }

        [Category("�ڍ�")]
        [Description("�ڍהw�i�̃O���f�[�V�����̕�����ݒ肵�܂�")]
        [DisplayName("�ڍהw�i�O���f�[�V��������")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode DescGradiationMode
        {
            get { return _SubMenuDescGradientMode; }
            set { _SubMenuDescGradientMode = value; }
        }


    }

    /// <summary>
    /// �ݒ�n���[�e�B���e�B�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ݒ�n���[�e�B���e�B�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    class SFNETMENU2SettingInfomation
    {
        public static string DefaultSettinBinary = "SfNetMenuSetting";
        public static string DefaultSettinBinaryExt = ".zcx";
        public static string ThemeBinary = "SfNetMenuTheme.qqc";

    }
}
