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
    /// メニュー関連設定情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メニュー関連設定情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class MenuConfigration
    {
        public int InfoVer;                                     //  メニューデータ内容改良時のチェック用   //  2009.09.29  追加
        public SystemMenuInfomation SystemMenuInfo;
        public ScreenInfomation ScreenInfo;
        public SystemSettingInfomation SystemSettingInfo;
        public DataSet UserMenu;
    }

    /// <summary>
    /// 画面色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 画面色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class ScreenThemeInfomation
    {
        public int ThemeFig = 0;
        public ArrayList SceenTehme = new ArrayList();

    }

    /// <summary>
    /// システム設定情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : システム設定情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
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
        /// システム設定情報クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : システム設定情報クラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
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
        /// システム設定情報コピー処理
        /// </summary>
        /// <returns>コピー情報を持ったシステム設定情報</returns>
        /// <remarks>
        /// <br>Note       :システム設定情報コピー</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
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
    /// 起動時表示メニュー情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 起動時表示メニュー情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class SystemMenuInfomation
    {
        public int SelectCategory;
        public ArrayList arCategoryCollections = new ArrayList();
        public ArrayList SelectSubMenuCollection = new ArrayList();

        /// <summary>
        /// 起動時表示メニュー情報コピー処理
        /// </summary>
        /// <returns>コピー情報を持った起動時表示メニュー情報</returns>
        /// <remarks>
        /// <br>Note       :起動時表示メニュー情報コピー</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
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
    /// ツールバー描画情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ツールバー描画情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class CustomProfessionalRenderer : ProfessionalColorTable
    {

        public Color _ToolStripGradientBegin;
        public Color _ToolStripGradientMiddle;
        public Color _ToolStripGradientEnd;
        //ToolStripPanelのグラデーションの色を指定
        public Color _ToolStripPanelGradientBegin;
        public Color _ToolStripPanelGradientEnd;

        //ToolStripのグラデーションの色を指定
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

        //ToolStripPanelのグラデーションの色を指定
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
    /// ツールバーカスタム描画情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ツールバーカスタム描画情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.20 鹿野幸生</br>
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

        //ToolStripのグラデーションの色を指定
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

        //ToolStripPanelのグラデーションの色を指定
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
    /// 画面色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 画面色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
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
        /// 画面色情報コピー処理
        /// </summary>
        /// <returns>コピー情報を持った画面色情報</returns>
        /// <remarks>
        /// <br>Note       :画面色情報コピー</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
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
        /// 画面色情報コピー処理
        /// </summary>
        /// <returns>指定引数に色情報をコピーする</returns>
        /// <remarks>
        /// <br>Note       :画面色情報コピー</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
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
    /// ツールバー色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ツールバー色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class ToolBarSetting
    {

        private Color _ToolStripForeColor;
        private Color _ToolStripGradientBegin;
        private Color _ToolStripGradientMiddle;
        private Color _ToolStripGradientEnd;
        private Color _ToolStripPanelGradientBegin;
        private Color _ToolStripPanelGradientEnd;


        [Category("色")]
        [Description("文字色を設定します")]
        [DisplayName("文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripForeColor
        {
            get { return _ToolStripForeColor; }
            set { _ToolStripForeColor = value; }
        }

        [Category("色")]
        [Description("ツールバー背景のグラデーションの開始色を設定します")]
        [DisplayName("ツールバー背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripGradientBegin
        {
            set { _ToolStripGradientBegin = value; }
            get { return _ToolStripGradientBegin; }
        }


        [Category("色")]
        [Description("ツールバー背景のグラデーションの中間色を設定します")]
        [DisplayName("ツールバー背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripGradientMiddle
        {
            set { _ToolStripGradientMiddle = value; }
            get { return _ToolStripGradientMiddle; }
        }


        [Category("色")]
        [Description("ツールバー背景のグラデーションの終了色を設定します")]
        [DisplayName("ツールバー背景色3")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripGradientEnd
        {
            set { _ToolStripGradientEnd = value; }
            get { return _ToolStripGradientEnd; }
        }

        [Category("色")]
        [Description("パネル背景のグラデーションの開始色を設定します")]
        [DisplayName("パネル背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripPanelGradientBegin
        {
            set { _ToolStripPanelGradientBegin = value; }
            get { return _ToolStripPanelGradientBegin; }
        }

        [Category("色")]
        [Description("パネル背景のグラデーションの終了色を設定します")]
        [DisplayName("パネル背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ToolStripPanelGradientEnd
        {
            set { _ToolStripPanelGradientEnd = value; }
            get { return _ToolStripPanelGradientEnd; }
        }
    }

    /// <summary>
    /// 背景色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 背景色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class BackgroundSetting
    {
        private Color _TabPageBackColor;
        private Image _TabPageBackImage;
        private ImageLayout _TabPageBackImageLayout;
        private Color _ScreenBackColor;

        [Category("色")]
        [Description("タブ背景色を設定します")]
        [DisplayName("タブ背景色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color TabPageBackColor
        {
            get { return _TabPageBackColor; }
            set { _TabPageBackColor = value; }
        }

        [Category("画像")]
        [Description("タブ背景の画像を表示設定を行います")]
        [DisplayName("タブ背景画像表示設定")]
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

        [Category("画像")]
        [Description("タブ背景画像を設定します")]
        [DisplayName("タブ背景背画像")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image TabPageBackImage
        {
            get { return _TabPageBackImage; }
            set { _TabPageBackImage = value; }
        }

        [Category("画像")]
        [Description("タブ背景画像の表示方法を設定します")]
        [DisplayName("タブ背景画像表示形式")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageLayout TabPageBackImageLayout
        {
            get { return _TabPageBackImageLayout; }
            set { _TabPageBackImageLayout = value; }
        }

        [Category("色")]
        [Description("画面背景色を設定します")]
        [DisplayName("画面背景色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ScreenBackColor
        {
            get { return _ScreenBackColor; }
            set { _ScreenBackColor = value; }
        }

    }

    /// <summary>
    /// 基本色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 基本色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class BasicSetting
    {
        private Color _BackColor;
        private Color _ForeColor;

        [Category("色")]
        [Description("背景色を設定します")]
        [DisplayName("背景色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }


        [Category("色")]
        [Description("文字色を設定します")]
        [DisplayName("文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

    }

    /// <summary>
    /// カテゴリラベル色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : カテゴリラベル色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class CategoryInfoSetting
    {
        private Color _CategoryLabelForeColor;
        private Color _CategoryLabelBackColor1;
        private Color _CategoryLabelBackColor2;
        private LinearGradientMode _CategoryLabelGradiationMode;

        [Category("色")]
        [Description("文字色を設定します")]
        [DisplayName("文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _CategoryLabelForeColor; }
            set { _CategoryLabelForeColor = value; }
        }

        [Category("色")]
        [Description("背景のグラデーションの開始色を設定します")]
        [DisplayName("背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor1
        {
            get { return _CategoryLabelBackColor1; }
            set { _CategoryLabelBackColor1 = value; }
        }

        [Category("色")]
        [Description("背景のグラデーションの終了色を設定します")]
        [DisplayName("背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor2
        {
            get { return _CategoryLabelBackColor2; }
            set { _CategoryLabelBackColor2 = value; }
        }

        [Category("色")]
        [Description("グラデーションの方向を設定します")]
        [DisplayName("グラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode GradiationMode
        {
            get { return _CategoryLabelGradiationMode; }
            set { _CategoryLabelGradiationMode = value; }
        }

    }

    /// <summary>
    /// サブカテゴリ色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : サブカテゴリ色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class SubCategorySetting
    {
        private Color _SubCategoryForeColor;
        private Color _SubCategoryLabelBackColor;
        private Image _SubCategoryBackImage;
        private bool _SubCategoryBackImageTiled;

        [Category("色")]
        [Description("文字色を設定します")]
        [DisplayName("文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _SubCategoryForeColor; }
            set { _SubCategoryForeColor = value; }
        }

        [Category("色")]
        [Description("背景色を設定します")]
        [DisplayName("背景色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor
        {
            get { return _SubCategoryLabelBackColor; }
            set { _SubCategoryLabelBackColor = value; }
        }

        [Category("画像")]
        [Description("背景の画像を表示設定を行います")]
        [DisplayName("背景画像表示設定")]
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

        [Category("画像")]
        [Description("背景の画像を設定します")]
        [DisplayName("背景画像")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image BackgroundImage
        {
            get { return _SubCategoryBackImage; }
            set { _SubCategoryBackImage = value; }
        }

        [Category("画像")]
        [Description("背景画像をタイル形式で表示します")]
        [DisplayName("背景画像表示形式")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool BackgroundImageTiled
        {
            get { return _SubCategoryBackImageTiled; }
            set { _SubCategoryBackImageTiled = value; }
        }

    }

    /// <summary>
    /// カテゴリ色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : カテゴリ色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
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

        [Category("ボタン")]
        [Description("文字色を設定します")]
        [DisplayName("文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _CategoryButtonForeColor; }
            set { _CategoryButtonForeColor = value; }
        }

        [Category("ボタン")]
        [Description("ボタンのグラデーションの開始色を設定します")]
        [DisplayName("ボタン色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor1
        {
            get { return _CategoryButtonBackColor1; }
            set { _CategoryButtonBackColor1 = value; }
        }

        [Category("ボタン")]
        [Description("ボタンのグラデーションの終了色を設定します")]
        [DisplayName("ボタン色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor2
        {
            get { return _CategoryButtonBackColor2; }
            set { _CategoryButtonBackColor2 = value; }
        }

        [Category("ボタン")]
        [Description("ボタンのグラデーションの方向を設定します")]
        [DisplayName("ボタングラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode ButtonGradiationMode
        {
            get { return _CategoryButtonGradiationMode; }
            set { _CategoryButtonGradiationMode = value; }
        }

        [Category("ボタン")]
        [Description("ボタンの選択文字色を設定します")]
        [DisplayName("ボタン選択文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonForeColor
        {
            get { return _CategorySelectedButtonForeColor; }
            set { _CategorySelectedButtonForeColor = value; }
        }

        [Category("ボタン")]
        [Description("マウスでの選択時のボタン背景開始色を設定します")]
        [DisplayName("マウス選択背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor1
        {
            get { return _CategorySelectedButtonFaceColor1; }
            set { _CategorySelectedButtonFaceColor1 = value; }
        }

        [Category("ボタン")]
        [Description("マウスでの選択時のボタン背景終了色を設定します")]
        [DisplayName("マウス選択背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor2
        {
            get { return _CategorySelectedButtonFaceColor2; }
            set { _CategorySelectedButtonFaceColor2 = value; }
        }

        [Category("ボタン")]
        [Description("キーフォーカスのあるボタン枠の色を設定します")]
        [DisplayName("キーフォーカスボタン枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color FocusButtonBorderColor
        {
            get { return _FocusButtonBorderColor; }
            set { _FocusButtonBorderColor = value; }
        }

        [Category("ボタン")]
        [Description("マウスフォーカスのあるボタン枠の色を設定します")]
        [DisplayName("マウスフォーカスボタン枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HotTrackingColor
        {
            get { return _HotTrackingColor; }
            set { _HotTrackingColor = value; }
        }

        [Category("色")]
        [Description("背景のグラデーションの開始色を設定します")]
        [DisplayName("背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor1
        {
            get { return _CategoryBackColor1; }
            set { _CategoryBackColor1 = value; }
        }

        [Category("色")]
        [Description("背景のグラデーションの終了色を設定します")]
        [DisplayName("背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor2
        {
            get { return _CategoryBackColor2; }
            set { _CategoryBackColor2 = value; }
        }

        [Category("色")]
        [Description("背景色のグラデーションの方向を設定します")]
        [DisplayName("背景グラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode GradiationMode
        {
            get { return _CategoryGradiationMode; }
            set { _CategoryGradiationMode = value; }
        }

        [Category("色")]
        [Description("アクティブなパネル枠の色を設定します")]
        [DisplayName("アクティブパネル枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ActivePanelBorderColor
        {
            get { return _ActivePanelBorderColor; }
            set { _ActivePanelBorderColor = value; }
        }

        [Category("画像")]
        [Description("背景の画像を表示設定を行います")]
        [DisplayName("背景画像表示設定")]
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

        [Category("画像")]
        [Description("背景の画像を設定します")]
        [DisplayName("背景画像")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image BackgroundImage
        {
            get { return _CategoryBackImage; }
            set { _CategoryBackImage = value; }
        }

        [Category("画像")]
        [Description("背景画像の表示方法を設定します")]
        [DisplayName("背景画像表示形式")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageLayout BackgroundImageLayout
        {
            get { return _CategoryBackImageLayout; }
            set { _CategoryBackImageLayout = value; }
        }

    }

    /// <summary>
    /// サブメニュー色情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : サブメニュー色情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
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
             

        [Category("見出し")]
        [Description("見出し文字色を設定します")]
        [DisplayName("見出し文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderForeColor
        {
            get { return _SubMenuHeaderForeColor; }
            set { _SubMenuHeaderForeColor = value; }
        }

        [Category("見出し")]
        [Description("見出し背景色のグラデーションの開始色を設定します")]
        [DisplayName("見出し背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderBackColor1
        {
            get { return _SubMenuHeaderBackColor1; }
            set { _SubMenuHeaderBackColor1 = value; }
        }

        [Category("見出し")]
        [Description("見出し背景色のグラデーションの終了色を設定します")]
        [DisplayName("見出し背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderBackColor2
        {
            get { return _SubMenuHeaderBackColor2; }
            set { _SubMenuHeaderBackColor2 = value; }
        }

        [Category("見出し")]
        [Description("見出し背景色のグラデーションの方向を設定します")]
        [DisplayName("見出し背景色グラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode HeaderGradiationMode
        {
            get { return _SubMenuHeaderGradiationMode; }
            set { _SubMenuHeaderGradiationMode = value; }
        }

        [Category("見出し")]
        [Description("アクティブなパネルの見出し文字色を設定します")]
        [DisplayName("アクティブパネル見出文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HeaderActiveForeColor
        {
            get { return _SubMenuHeaderActiveColor; }
            set { _SubMenuHeaderActiveColor = value; }
        }

        [Category("ボタン")]
        [Description("文字色を設定します")]
        [DisplayName("文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ForeColor
        {
            get { return _SubMenuButtonForeColor; }
            set { _SubMenuButtonForeColor = value; }
        }

        [Category("ボタン")]
        [Description("ボタンのグラデーションの開始色を設定します")]
        [DisplayName("ボタン色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor1
        {
            get { return _SubMenuButtonBackColor1; }
            set { _SubMenuButtonBackColor1 = value; }
        }

        [Category("ボタン")]
        [Description("ボタンのグラデーションの終了色を設定します")]
        [DisplayName("ボタン色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ButtonBackColor2
        {
            get { return _SubMenuButtonBackColor2; }
            set { _SubMenuButtonBackColor2 = value; }
        }

        [Category("ボタン")]
        [Description("ボタンのグラデーションの方向を設定します")]
        [DisplayName("ボタングラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode ButtonGradiationMode
        {
            get { return _SubMenuButtonGradiationMode; }
            set { _SubMenuButtonGradiationMode = value; }
        }

        [Category("ボタン")]
        [Description("ボタンの選択文字色を設定します")]
        [DisplayName("ボタン選択文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonForeColor
        {
            get { return _SubMenuSelectedButtonForeColor; }
            set { _SubMenuSelectedButtonForeColor = value; }
        }

        [Category("ボタン")]
        [Description("マウスでの選択時のボタン背景開始色を設定します")]
        [DisplayName("マウス選択背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor1
        {
            get { return _SubMenuSelectedButtonFaceColor1; }
            set { _SubMenuSelectedButtonFaceColor1 = value; }
        }

        [Category("ボタン")]
        [Description("マウスでの選択時のボタン背景終了色を設定します")]
        [DisplayName("マウス選択背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color SelectedButtonFaceColor2
        {
            get { return _SubMenuSelectedButtonFaceColor2; }
            set { _SubMenuSelectedButtonFaceColor2 = value; }
        }

        [Category("ボタン")]
        [Description("キーフォーカスのあるボタン枠の色を設定します")]
        [DisplayName("キーフォーカスボタン枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color FocusButtonBorderColor
        {
            get { return _FocusButtonBorderColor; }
            set { _FocusButtonBorderColor = value; }
        }

        [Category("ボタン")]
        [Description("マウスフォーカスのあるボタン枠の色を設定します")]
        [DisplayName("マウスフォーカスボタン枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color HotTrackingColor
        {
            get { return _HotTrackingColor; }
            set { _HotTrackingColor = value; }
        }

        [Category("色")]
        [Description("背景のグラデーションの開始色を設定します")]
        [DisplayName("背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor1
        {
            get { return _SubMenuBackColor1; }
            set { _SubMenuBackColor1 = value; }
        }

        [Category("色")]
        [Description("背景のグラデーションの終了色を設定します")]
        [DisplayName("背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color BackColor2
        {
            get { return _SubMenuBackColor2; }
            set { _SubMenuBackColor2 = value; }
        }

        [Category("色")]
        [Description("背景色のグラデーションの方向を設定します")]
        [DisplayName("背景グラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode GradiationMode
        {
            get { return _SubMenuGradiationMode; }
            set { _SubMenuGradiationMode = value; }
        }

        [Category("色")]
        [Description("アクティブなパネル枠の色を設定します")]
        [DisplayName("アクティブパネル枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color ActivePanelBorderColor
        {
            get { return _ActivePanelBorderColor; }
            set { _ActivePanelBorderColor = value; }
        }

        [Category("画像")]
        [Description("背景の画像を表示設定を行います")]
        [DisplayName("背景画像表示設定")]
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

        [Category("画像")]
        [Description("背景の画像を設定します")]
        [DisplayName("背景画像")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Image BackgroundImage
        {
            get {  return _SubMenuBackImage; }
            set { _SubMenuBackImage = value; }
        }

        [Category("画像")]
        [Description("背景画像の表示方法を設定します")]
        [DisplayName("背景画像表示形式")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageLayout BackgroundImageLayout
        {
            get { return _SubMenuBackImageLayout; }
            set { _SubMenuBackImageLayout = value; }
        }
        [Category("詳細")]
        [Description("詳細文字色を設定します")]
        [DisplayName("詳細文字色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescForeColor
        {
            get { return _SubMenuDescForeColor; }
            set { _SubMenuDescForeColor = value; }
        }

        [Category("詳細")]
        [Description("詳細の枠色を設定します")]
        [DisplayName("詳細枠色")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescLineColor
        {
            get { return _SubMenuDescLineColor; }
            set { _SubMenuDescLineColor = value; }
        }

        [Category("詳細")]
        [Description("詳細背景のグラデーションの開始色を設定します")]
        [DisplayName("詳細背景色1")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescBackColor1
        {
            get { return _SubMenuDescBackColor1; }
            set { _SubMenuDescBackColor1 = value; }
        }

        [Category("詳細")]
        [Description("詳細背景のグラデーションの終了色を設定します")]
        [DisplayName("詳細背景色2")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color DescBackColor2
        {
            get { return _SubMenuDescBackColor2; }
            set { _SubMenuDescBackColor2 = value; }
        }

        [Category("詳細")]
        [Description("詳細背景のグラデーションの方向を設定します")]
        [DisplayName("詳細背景グラデーション方向")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public LinearGradientMode DescGradiationMode
        {
            get { return _SubMenuDescGradientMode; }
            set { _SubMenuDescGradientMode = value; }
        }


    }

    /// <summary>
    /// 設定系ユーティリティクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 設定系ユーティリティクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    class SFNETMENU2SettingInfomation
    {
        public static string DefaultSettinBinary = "SfNetMenuSetting";
        public static string DefaultSettinBinaryExt = ".zcx";
        public static string ThemeBinary = "SfNetMenuTheme.qqc";

    }
}
