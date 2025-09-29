using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using System.Threading ;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
// --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
using Broadleaf.Application.UIData;
// --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<
// --- ADD 2021/01/05 ���� ---------->>>>>
using Broadleaf.Library.Diagnostics;
// --- ADD 2021/01/05 ���� ---------->>>>>

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ���j���[���C����ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���j���[���C����ʃN���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.10 ����@�K��</br>
    /// <br>Update Note: 2009.08.20 ���X�� ��</br>
    /// <br>             �@�X�^�[�g�A�b�v�v���O������xml�Ή�</br>
    /// <br>             �A�����I�����j���[���A�擪�ɕύX</br>
    /// <br>Update Note: 2009.09.14 ���X�� ��</br>
    /// <br>             MANTIS[0014209]�Ή�</br>
    /// <br>             �@�p�����[�^�̃}�N���u���ɁAWeb�̐ڑ��������ǉ�</br>
    /// <br>Update Note: 2011/03/04 22018 ��� ���b</br>
    /// <br>             �O���[�v�̃^�C�g���\���ʒu�𒲐��i�Z���^�����O�j</br>
    /// <br>Update Note: 2011/06/29 21112 �v�ۓc ��</br>
    /// <br>             �J�e�S���[�̃X�N���[���\���Ή�</br>
    /// <br>             �T�u�J�e�S���[�̕\��������</br>
    /// <br>             �ʓ�������\���@�\�ǉ�</br>
    /// <br>             ��ʂ̍ŏ��T�C�Y��800x600�ɐݒ�</br>
    /// <br>Update Note: 2011/08/08 22018 ��� ���b</br>
    /// <br>             �R�~���j�P�[�V�����c�[���Ή�</br>
    /// <br>Update Note: 2011/08/22 22018 ��� ���b</br>
    /// <br>             2011/06/29��2011/08/08�̃\�[�X�}�[�W�ׁ̈Awidth�̒l�������</br>
    /// <br>Update Note: 2011/10/28 22008 ���� ���n</br>
    /// <br>             J�^�C�v�̏ꍇ�ɁA�񋟃f�[�^�̃o�[�W�����`�F�b�N�����Ȃ��悤�ɏC��</br>
    /// <br>Update Note: 2012/11/29 22018 ��� ���b</br>
    /// <br>             �񋟃f�[�^�X�V�������K�v�ȏꍇ�Ƀ_�C�A���O�I���ɂ���Ă͏������s�ł���悤�ύX</br>
    /// <br>Update Note: 2013/02/15 30747 �O�� �L��</br>
    /// <br>             2013/03/06�z�M�� SCM��Q��10469�@���O�C�����[�U�[���Ƀ��j���[�𐧌�</br>
    /// <br>Update Note: 2013/02/25 30746 ���� ��</br>
    /// <br>             2013/03/06�z�M�V�X�e���e�X�g��QNo126 ���j���[����̐����@�\�����C�ɓ��肩��N���ł��Ă��܂�</br>
    /// <br>Update Note: 2013/02/25 30747 �O�� �L��</br>
    /// <br>             2013/03/06�z�M�V�X�e���e�X�g��QNo142 ���j���[�\�����x���P</br>
    /// <br>Update Note: 2013/12/11 20073 �� �B</br>
    /// <br>             ���j���[�ȈՋN���I�v�V�������������͏풓�v���O�������N�����Ȃ�</br>
    /// <br>Update Note: 2013/12/19 22008 ���� ���n</br>
    /// <br>             �I�v�V�������L�������؂�̏ꍇ�ɁA�L���Ɣ��f����Ă���s����C��</br>
    /// <br>Update Note: 2014/05/01 30940 �͌��� �ꐶ</br>
    /// <br>             PMNS�d�|�ꗗNo.1891(���j���[�ő剻���Ƀ��[���ݒ�Ŕ�\���ɂ������j���[���\�������)</br>
    /// <br>Update Note: 2021/01/05 32470 ���� ���</br>
    /// <br>             �v���O�����N�����O�𑀍엚�����O�ɏo�͂���ǉ��Ή�</br>
    /// <br>             �S�\�[�X�t�@�C���̌x���Ή�</br>
    /// </remarks>
    public partial class SFNETMENU2A : Form
    {
        private const string cThemeKey2 = "5s";
        private const string cSfNetUserConfigKey1 = "823AB6";
        private const string cMenuKey4 = "bg2o7";
        private const int cSubMenuFig = 24;                                     //  2007.01.10  �ǉ�
        private bool _mBoot = true;
        private int _mSubMenuTabCount;
        //private int _mSearchMenuTabCount;
        private int _mMainSplitMaxLine;
        private int _mSubMenuItemSetType;   //0:�T�C�Y�D��,1:�y�[�W�����D��
        private int _mSubMenuItemWidth1;
        private int _mSubMenuItemWidth2;
        private int _mSubMenuItemMaxWidth1;
        private int _mSubMenuItemMaxWidth2;
        private int _mSubMenuItemDefCount1;
        private int _mSubMenuItemDefCount2;
        
        private int _mSubMenuItemMaxItemFig1;// �m�[�}��15��
        private int _mSubMenuItemMaxItemFig2;// �}�X����7��
        private int _mSubMenuItemMaxItemFig3;// ���[10��
        
        private int _mSubMenuItemMargin;
        //private int _mActiveTabPageIndex;
        private string _mPortNo = "";
        private string _mAccessNo = "";
        private int _mMaxRecentCount;
        private string _mStatusMessage = "";
        private int _mTargetingTabPage;
        private string[] gcmd;
        private int _mPanelPriorityMode;
        private bool _mSystemSettingMode;
        private Size _mtabpageSize;

        private const string cUserSetting1 = "u";
        private const string cThemeKey5 = "tDh30L";
        private const string cMenuKey2 = "8G6";
        private const string cUserSetting2 = "T6x";
        private const string cUserSetting3 = "hd02";
        private const string cSfNetUserConfigKey2 = "7194573265";
        private const string cmSystemSettingMode2 = "sys";
        private const int cFncUpDown = -100;
        private const int cFncUserMenu = -101;
        private const int cFncSerach = -102;
        private const string cMenuKey1 = "z";
        private const string cRollSetting1 = "df3";
        private const string cRollSetting2 = "6g";
        private const string cSfNetUserConfigKey3 = "5fghnesfy";
        private const string cmSystemSettingMode1 = "/E:";
        private const string cThemeKey1 = "4hJ";
        private const int cDefWidth = 1016;
        private const string cRollSetting5 = "h";
        private const int cDefHeight = 734;
        private const int cDefOuterWidth = 1024;                                                        //  2007.01.10  �ǉ�
        private const int cDefOuterHeight = 768;                                                        //  2007.01.10  �ǉ�
//        private const int cDefOuterWidth = 850;                                                        //  2007.01.10  �ǉ�
//        private const int cDefOuterHeight = 600;                                                        //  2007.01.10  �ǉ�

        private MenuConfigration MenuConf = new MenuConfigration();
        private const int   cMenuConfVer = 1;                                                          //  2006.09.29  �ǉ�
        private SystemSettingInfomation SystemSettingInfo = new SystemSettingInfomation();
        private ScreenInfomation ScreenInfo = new ScreenInfomation();
        private const string cRollSetting4 = "54lJ";
        private SystemMenuInfomation SystemMenuInfo = new SystemMenuInfomation();
        private DataSet UserMenuInfo = new DataSet();
        private const string cThemeKey4 = "3";
        private const string cUserSetting4 = "KiqDD";
        private const string cMenuKey5 = "6das";
        private ArrayList arRollSettings;

        private SFNETMENU2B msgWin = new SFNETMENU2B();
        private SFNETMENU2C usrGrpSetWin = new SFNETMENU2C();
        private const string cRollSetting3 = "cd12";
        private SFNETMENU2E usrScrnSetWin = new SFNETMENU2E();
        private const string cUserSetting5 = "41cd";
        private SFNETMENU2H usrPassSetWin = new SFNETMENU2H();
        private const string cMenuKey3 = "j53c3";
        private const string cThemeKey3 = "1sd4";
        private static string _mAppSettingDataDir = "";
        private static string _mNavigationDataDir = "";
        private VersionCheckAcs _VersionCheckAcs = null;
        private int _mClrTime;

        // --- ADD 2013/12/11 T.Nishi ---------->>>>>
        private const string TargetPGID_MAHNB01001U = "MAHNB01001U.EXE";
        private const string TargetPGID_PMKAU04000U = "PMKAU04000U.EXE";
        private const string TargetPGID_PMHNB01000U = "PMHNB01000U.EXE";
        private const string TargetPGID_PMKAU04020U = "PMKAU04020U.EXE";
        // --- ADD 2013/12/11 T.Nishi ----------<<<<<

        // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
        // �]�ƈ����[���}�X�^�A�N�Z�X�N���X
        private EmployeeRoleStAcs _employeeRoleStAcs;
        private ArrayList _roleGroupCode = new ArrayList();
        // ���[���O���[�v�����ݒ�}�X�^
        private RoleGroupAuthAcs _roleGroupAuthAcs;
        private ArrayList _categorySubItem = new ArrayList();
        // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        //--- ADD 2011/06/29 M.Kubota --->>>
        private const string cCustomHistoryFile = @"Custom\CustHistory.html";
        private string _CustomHistoryFullPath = "";
        //--- ADD 2011/06/29 M.Kubota ---<<<

        // 2008.09.28 sugi -<<
        private string gServiceTopPage = "";
        // 2009.09.14 >>>
        ////private string[] gMacroString = { "%$%TOPPAGE_WEB%$%" };// 2009.03.16 sugi del
        ////private string[] gMacroStringFunc = { "WEB" };// 2009.03.16 sugi del
        //private string[] gMacroString = { "%%TOP%%", "%%INF%%", "%%PRD%%" };// 2009.03.16 sugi add
        //private string[] gMacroStringAp = { "TOPPAGE_WEB", "INFORMATION_WEB", "PRODUCT" };// 2009.03.16 sugi add
        //private string[] gMacroStringFunc = { "WEB", "WEB", "PRD" };// 2009.03.16 sugi add

        private string[] gMacroString = { "%%TOP%%", "%%INF%%", "%%PRD%%", "%%INFCON%%" };
        private string[] gMacroStringAp = { "TOPPAGE_WEB", "INFORMATION_WEB", "PRODUCT", "INFORMATION_WEB" };
        private string[] gMacroStringFunc = { "WEB", "WEB", "PRD", "INFCON" };
        // 2009.09.14 <<<
        //NsLoginControler _nlc = null;                                          
        // 2008.09.28 sugi -<<

        // 2009.08.20 Add >>>
        private List<int> _stratUpCategoryIDs = new List<int>();
        // 2009.08.20 Add <<<

        // --- ADD 2021/01/05 ���� ---------->>>>>
        /// <summary>
        /// �N���XID
        /// </summary>
        private const string cClassId = "SFNETMENU2A";

        /// <summary>
        /// �v���O����ID
        /// </summary>
        private const string cProgramId = "SFNETMENU2";

        /// <summary>
        /// �v���O������
        /// </summary>
        private const string cProgramName = "�Ɩ����j���[";

        /// <summary>
        /// ���O�f�[�^��ʁi���j���[���O�o�́j
        /// </summary>
        private const int MenuLog = 2;

        /// <summary>
        /// ���O�f�[�^�I�y���[�V�����R�[�h�i�N���j
        /// </summary>
        private const int cLogDataOperationCdStart = 0;

        /// <summary>
        /// ���엚�����O�o�͕��i
        /// </summary>
        private OperationHistoryLog _operationHistoryLog = null;

        /// <summary>
        /// �N���C�A���g���O�o�͕��i
        /// </summary>
        private ClientLogTextOut _clientLogTextOut = null;
        // --- ADD 2021/01/05 ���� ---------->>>>>

        private enum CheckRollTypes
        {
            Normal_OK,
            Normal_NG,
            Return_OK,
            Return_NG,
            ReturnFix_OK,
            ReturnFix_NG
        }

        private enum DescriptionEnumTypes
        {
            Normal,
            Std7Lines,
            Std5Lines,
            Check7Lines,
            Check5Lines
        }

        /// <summary>�^�u�p�R���e�L�X�g���j���[�I��TABINDEX</summary>
        //private int gSelectMenuTab = -1;

        //private event EventHandler Recent_Click;

        /// <summary>���i���</summary>
        public ArrayList arProducts = new ArrayList();

        /// <summary>
        /// ���j���[���C����ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���j���[���C����ʃR���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2A()
        {
            InitializeComponent();
            
            _mBoot = true;
            _mSubMenuTabCount = 0;
//            _mMainSplitMaxLine = 200;                                         //  2007.01.10 �ύX
            // --- UPD m.suzuki 2011/08/22 ---------->>>>>
            //// --- UPD m.suzuki 2011/08/08 ---------->>>>>
            ////_mMainSplitMaxLine = 160;//2009.01.13 sugi chg
            //_mMainSplitMaxLine = 180;
            //// --- UPD m.suzuki 2011/08/08 ----------<<<<<
            _mMainSplitMaxLine = 190;
            // --- UPD m.suzuki 2011/08/22 ----------<<<<<
            _mSubMenuItemSetType = 1;
            _mSubMenuItemWidth1 = 250;
            _mSubMenuItemWidth2 = 300;
            _mSubMenuItemMaxWidth1 = 250;
            _mSubMenuItemMaxWidth2 = 500;
            _mSubMenuItemDefCount1 = 4;
            _mSubMenuItemDefCount2 = 2;
            //_mSubMenuItemMaxItemFig1 = 15;// �m�[�}��15��  //DEL 2011/06/29 M.Kubota
            _mSubMenuItemMaxItemFig1 = 17;// �m�[�}��17��    //ADD 2011/06/29 M.Kubota ��1280�~1024�ōő剻�����ꍇ�̌��E�\���\��
            _mSubMenuItemMaxItemFig2 = 7;// �}�X����7��
            //_mSubMenuItemMaxItemFig3 = 10;// ���[10��      //DEL 2011/06/29 M.Kubota
            _mSubMenuItemMaxItemFig3 = 13;// ���[13��        //ADD 2011/06/29 M.Kubota ��1280�~1024�ōő剻�����ꍇ�̌��E�\���\��
//            _mSubMenuItemMargin = 3;                                          //  2007.01.10  �ύX
            _mSubMenuItemMargin = 1;
            //_mSearchMenuTabCount = 0;
            //_mActiveTabPageIndex = 0;
            _mPortNo = "";
            _mAccessNo = "";
            _mStatusMessage = "";
            _mTargetingTabPage = -1;
            _mPanelPriorityMode = 0;        // �J�e�S���D��
            _mtabpageSize = new Size(0,0);
            _mClrTime = 0;

            // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._employeeRoleStAcs = new EmployeeRoleStAcs();
            this._roleGroupAuthAcs = new RoleGroupAuthAcs();
            // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            //  �R�}���h�p�����[�^�擾
            gcmd = System.Environment.GetCommandLineArgs();

            //  �v���_�N�g/�V�X�e���e�[�}�J���[�ݒ胂�[�h���ǂ������擾����
            try
            {
                _mSystemSettingMode = false;
                for (int i = 1; i < gcmd.Length; i++)
                {
                    if (gcmd[i].IndexOf("/P:", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        string pTemp = gcmd[i].Substring(3);
                        string[] gProducts = pTemp.Split(',');
                        arProducts.Clear();
                        foreach (string product in gProducts)
                        {
                            ProductsInfomation pi = new ProductsInfomation();
                            pi.ProductID = product;
                            arProducts.Add(pi);
                        }
                    }
                    else if (gcmd[i].ToString() == cmSystemSettingMode1 + cmSystemSettingMode2)
                    {
                        _mSystemSettingMode = true;
                    }

                }
                //  ���i��񂪖������SF�͓���
                if (arProducts.Count == 0)
                {
                    ProductsInfomation pi = new ProductsInfomation();
                    //pi.ProductID = "MobileKing";
                    //pi.ProductID = "Partsman"; //2009.03.23 sugi del
                    pi.ProductID = LoginInfoAcquisition.ProductCode; // 2009.03.23 sugi add
                    arProducts.Add(pi);
                }
            }
            catch (Exception)
            {
            }

            //  �|�[�g�E�A�N�Z�X�L�[��ݒ�
            _mAccessNo = gcmd[1].ToString();
            _mPortNo = gcmd[2].ToString();

            // --- ADD 2021/01/05 ���� ---------->>>>>
#if DEBUG
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, string.Empty, "�Ɩ����j���[�N��", "�f�o�b�O", "0");
#endif
            try
            {
                // �N���C�A���g���O�o�͕��i������
                _clientLogTextOut = new ClientLogTextOut();
            }
            catch
            {
                // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
            }

            try
            {
                // ���O�o�͕��i������
                _operationHistoryLog = new OperationHistoryLog();
            }
            catch(Exception ex)
            {
                // �G���[�����O�o��
                try
                {
                    if (_clientLogTextOut != null)
                    {
                        _clientLogTextOut.Output(cClassId, "���O�o�͕��i�������G���[", (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                    }
                }
                catch
                {
                    // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                }
            }
            // --- ADD 2021/01/05 ���� ---------->>>>>
        }

        /// <summary>
        /// �t�H�[�����[�h�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2A_Load(object sender, EventArgs e)
        {

            _mAppSettingDataDir = Path.Combine(Path.GetDirectoryName(gcmd[0]), DirSettiing.GetDirectory(DirSettiing.DirType.AppSettingDataDir));
            _mNavigationDataDir = Path.Combine(Path.GetDirectoryName(gcmd[0]), DirSettiing.GetDirectory(DirSettiing.DirType.NavigationDataDir));
            CheckProductDataRoot();

            bool bNewSetting = false;                                           //  2007.01.10  �ǉ�

            //MessageBox.Show("DBG"); //DBG

            //  �S���ҕʂ̐ݒ�t�@�C����ǂݍ���
            MenuConf = ReadSettingFile();
            //  ���j���[�ݒ���
            try
            {
                SystemSettingInfo = MenuConf.SystemSettingInfo;
            }
            catch
            {
                //  �ǂݍ��ݎ��s�Ȃ珉���l�ݒ�
                SystemSettingInfo = new SystemSettingInfomation();
                bNewSetting = true;
            }

            //  ���j���[�ݒ���𔽉f
            _mMaxRecentCount = SystemSettingInfo.MaxRecentFig;

            //  ��ʐF���
            try
            {
                ScreenInfo = MenuConf.ScreenInfo;
            }
            catch
            {
                //  �ǂݍ��ݎ��s�Ȃ珉���l�ݒ�
                ScreenThemeInfomation sti = ReadSystemTheme();
                if ((sti != null) && (sti.ThemeFig != 0))
                {
                    //  �V�X�e���X�N���[���e�[�}���擾�ł���΁A���̃[���Ԗڂ��f�t�H���g�Ƃ��Đݒ肷��
                    ((ScreenInfomation)sti.SceenTehme[0]).Copy(ScreenInfo);
                }
                else
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Init", "�������G���[", "�V�X�e���E�e�[�}���̎擾�Ɏ��s���܂����B\n\n�����s���ł��B", "-91");

                }
            }

            //  �����\�����j���[
            try
            {
                SystemMenuInfo = MenuConf.SystemMenuInfo;
            }
            catch
            {
                //  �ǂݍ��ݎ��s�Ȃ珉���l�ݒ�
                SystemMenuInfo.SelectCategory = 0;
            }

            //  �F��񔽉f
            ChangeControlProperty();

            //  ���[�U�[�ݒ�
            try
            {
                if ((UserMenuInfo = SFNETMENU2Utilities.SetUserConfig(MenuConf.UserMenu)) == null)
                {
                    UserMenuInfo = SFNETMENU2Utilities.CreateUserMenuInfomation();
                }
            }
            catch
            {
                //  �ǂݍ��ݎ��s�Ȃ珉���l�ݒ�
                UserMenuInfo = SFNETMENU2Utilities.CreateUserMenuInfomation();
            }

            //  �I�����C���E�I�t���C���̐ݒ�
            if (Program.gloginInfo.OnlienMode == true)
            {
                lblOnline.Text = "�y�I�����C���z";
                lblOnline.ForeColor = Color.Blue;
            }
            else
            {
                lblOnline.Text = "�y�I�t���C���z";
                lblOnline.ForeColor = Color.Red;
            }

            //  ���t�ݒ�
            lblDate.Text = SFNETMENU2Utilities.GetCalendar(ref SystemSettingInfo.DateTimeFormat);

            // --- DEL 2014/05/01 PMNS�d�|�ꗗ No.1891 ----------->>>>>
            // ���[���ݒ�擾�O�ɃA�N�e�B�x�[�g������ƃ��[���ݒ肪���f����Ȃ��Ȃ�̂ŁA���[���ݒ�擾��Ƀ��T�C�Y��������B
            //  ��{�ʒu�̐ݒ�(�R���g���[����)
            //if (SystemSettingInfo.SaveLastPosition == true)
            //{
            //    Location = SystemSettingInfo.LastLocation;
            //}
            //else
            //{
            //    this.SetBounds(0, 0, 0, 0, BoundsSpecified.Location);
            //}
            //if (SystemSettingInfo.SaveLastSize == true)
            //{
            //    ClientSize = SystemSettingInfo.LastSize;
            //    if (SystemSettingInfo.WindowMaximized == true)
            //    {
            //        WindowState = FormWindowState.Maximized;
            //    }

            //}
            //else
            //{
            //    this.ClientSize = new Size(cDefWidth, cDefHeight);
            //}

            ////  �V�K�\�����ɊO�g�T�C�Y��1024*768�𒴂��Ă����狭���I��1024*768�ɍ��킹��(Vista�Ή�) //  2007.01.10  �ǉ�
            //if ((bNewSetting == true) && ((this.Size.Width > cDefOuterWidth) || (this.Size.Height > cDefOuterHeight)))
            //{
            //    this.SetBounds(0, 0, cDefOuterWidth, cDefOuterHeight);
            //}
            // --- DEL 2014/05/01 PMNS�d�|�ꗗ No.1891 -----------<<<<<

            //  �D��\�����[�h�̐ݒ�
            _mPanelPriorityMode = SystemSettingInfo.CategoryPriority;

            //  �V�X�e�����[�h�̐ݒ�
            if (_mSystemSettingMode == true)
            {
                stsInfo3.Text = "S+";
            }
            else
            {
                stsInfo3.Text = "S-";
            }

            // �����V���N�����ǉ�
            //ProcessStartInfo psi = new ProcessStartInfo();
            //psi.FileName = "MACMN06540U.exe";
            //psi.Arguments = this.GetLoginArgument();
            //Process.Start(psi);

            // 2009.08.20 xml����擾���ċN������׍폜 >>>
            //// ���ē����������ǉ� 2009.03.02 sugi add ����
            //ProcessStartInfo psi = new ProcessStartInfo();
            //psi.FileName = "PMCMN00783U.exe";
            //psi.Arguments = this.GetLoginArgument();
            //Process.Start(psi);
            //// ���ē����������ǉ� sugi add ����
            // 2009.08.20 Del <<<

            if (_VersionCheckAcs==null)  _VersionCheckAcs = new VersionCheckAcs();//�N�����ɃC���X�^���X�� sugi add

            // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��QNo142 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // �]�ƈ����[���擾
            int status = 0;
            ArrayList retList = null;
            status = this._employeeRoleStAcs.Search3(out retList, Program.gloginInfo.EnterpriseCode, Program.gloginInfo.EmployeeCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (EmployeeRoleSt employeeRoleSt in retList)
                {
                    if (employeeRoleSt.LogicalDeleteCode != 0) continue;    // �]�ƈ����[�����_���폜����Ă�
                    if (employeeRoleSt.RoleGroupName == "") continue;       // ���[���O���[�v���̐ݒ�}�X�^���폜����Ă���
                    _roleGroupCode.Add(employeeRoleSt.RoleGroupCode);
                }
            }

            if (_roleGroupCode.Count == 0)
            {
                // ���ʐݒ���擾
                retList = null;
                status = this._employeeRoleStAcs.Search3(out retList, Program.gloginInfo.EnterpriseCode, "0000");
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (EmployeeRoleSt employeeRoleSt in retList)
                    {
                        if (employeeRoleSt.LogicalDeleteCode != 0) continue;    // �]�ƈ����[�����_���폜����Ă�
                        if (employeeRoleSt.RoleGroupName == "") continue;       // ���[���O���[�v���̐ݒ�}�X�^���폜����Ă���
                        _roleGroupCode.Add(employeeRoleSt.RoleGroupCode);
                    }
                }
            }

            // ���[���O���[�v�����ݒ�}�X�^�ɊY������̏ꍇ�͔�\���ɂ��邽�߁A�J�e�S���{�T�u�J�e�S���{�A�C�e����ۑ�
            retList = null;
            string categorySubItem = "";
            foreach (int roleGroupCode in _roleGroupCode)
            {
                status = this._roleGroupAuthAcs.SearchAll(roleGroupCode, out retList, Program.gloginInfo.EnterpriseCode);
                foreach (RoleGroupAuth roleGroupAuth in retList)
                {
                    if (roleGroupAuth.LogicalDeleteCode == 0)
                    {
                        categorySubItem = roleGroupAuth.RoleCategoryID.ToString().PadLeft(4, '0') +
                                          roleGroupAuth.RoleCategorySubID.ToString().PadLeft(6, '0') +
                                          roleGroupAuth.RoleItemID.ToString().PadLeft(2, '0');
                        if (_categorySubItem.Contains(categorySubItem)) continue;
                        _categorySubItem.Add(categorySubItem);
                    }
                }
            }
            // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��QNo142 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2014/05/01 PMNS�d�|�ꗗ No.1891 ----------->>>>>
            // ���[���ݒ�擾�O�ɃA�N�e�B�x�[�g������ƃ��[���ݒ肪���f����Ȃ��Ȃ�̂ŁA���[���ݒ�擾��Ƀ��T�C�Y��������B
            //  ��{�ʒu�̐ݒ�(�R���g���[����)
            if (SystemSettingInfo.SaveLastPosition == true)
            {
                Location = SystemSettingInfo.LastLocation;
            }
            else
            {
                this.SetBounds(0, 0, 0, 0, BoundsSpecified.Location);
            }
            if (SystemSettingInfo.SaveLastSize == true)
            {
                ClientSize = SystemSettingInfo.LastSize;
                if (SystemSettingInfo.WindowMaximized == true)
                {
                    WindowState = FormWindowState.Maximized;
                }

            }
            else
            {
                this.ClientSize = new Size(cDefWidth, cDefHeight);
            }

            //  �V�K�\�����ɊO�g�T�C�Y��1024*768�𒴂��Ă����狭���I��1024*768�ɍ��킹��(Vista�Ή�) //  2007.01.10  �ǉ�
            if ((bNewSetting == true) && ((this.Size.Width > cDefOuterWidth) || (this.Size.Height > cDefOuterHeight)))
            {
                this.SetBounds(0, 0, cDefOuterWidth, cDefOuterHeight);
            }
            // --- ADD 2014/05/01 PMNS�d�|�ꗗ No.1891 -----------<<<<<
        }

        /// <summary>
        /// �t�H�[���A�N�e�B�u
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [MTAThread]
        private void SFNETMENU2A_Activated(object sender, EventArgs e)
        {

            if (_mBoot == true)
            {
                _mBoot = false;

                System.Windows.Forms.Application.EnableVisualStyles();
//                SetStyle(ControlStyles.DoubleBuffer, true);
                SetStyle(ControlStyles.UserPaint, true);
//                SetStyle(ControlStyles.AllPaintingInWmPaint, true);


                //  ���O�C������ݒ�
                lblLoginUser.Text = Program.gloginInfo.EmployeeName;
                int StrLen = lblLoginUser.Text.Length - 2;
                int MaxLen = 250;
                while (lblLoginUser.Width > MaxLen)
                {
                    lblLoginUser.Text = Program.gloginInfo.EmployeeName.Substring(0, StrLen) + "�c";
                    lblLoginUser.ToolTipText = "�]�ƈ����́F" + Program.gloginInfo.EmployeeName;
                    StrLen--;
                }
                lblLoginUser.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.LoginEmployee];
                btnLogin.Image = MenuIconResourceManagement.imgLoginState.Images[(int)MenuIconResourceManagement.LoginStateImage.Login];

                mnuMain.SetBounds(0, 0, 0, 0, BoundsSpecified.Location);
                btnExit.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.CloseWindow];
                barCtrl.SetBounds(0, mnuMain.Height, 0, 0, BoundsSpecified.Location);
                barLoginInfo.SetBounds(barCtrl.Left+barCtrl.Width+1, mnuMain.Height, 0, 0, BoundsSpecified.Location);
                barFuncMenu.SetBounds(barLoginInfo.Left + barLoginInfo.Width + 1, mnuMain.Height, 0, 0, BoundsSpecified.Location);

                System.Windows.Forms.Application.DoEvents();

                stsInfoTheme.Text = "Theme:" + ScreenInfo.ThemeName;
                stsInfo1.Width = stsInfo.ClientSize.Width - (stsInfo2.Width + stsInfo3.Width + stsInfo4.Width + stsInfoTheme.Width) - 30;

                // DEL 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��QNo142 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //// --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //// �]�ƈ����[���擾
                //int status = 0;
                //ArrayList retList = null;
                //status = this._employeeRoleStAcs.Search3(out retList, Program.gloginInfo.EnterpriseCode, Program.gloginInfo.EmployeeCode);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    foreach (EmployeeRoleSt employeeRoleSt in retList)
                //    {
                //        if (employeeRoleSt.LogicalDeleteCode != 0) continue;    // �]�ƈ����[�����_���폜����Ă�
                //        if (employeeRoleSt.RoleGroupName == "") continue;       // ���[���O���[�v���̐ݒ�}�X�^���폜����Ă���
                //        _roleGroupCode.Add(employeeRoleSt.RoleGroupCode);
                //    }
                //}

                //if (_roleGroupCode.Count == 0)
                //{
                //    // ���ʐݒ���擾
                //    retList = null;
                //    status = this._employeeRoleStAcs.Search3(out retList, Program.gloginInfo.EnterpriseCode, "0000");
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        foreach (EmployeeRoleSt employeeRoleSt in retList)
                //        {
                //            if (employeeRoleSt.LogicalDeleteCode != 0) continue;    // �]�ƈ����[�����_���폜����Ă�
                //            if (employeeRoleSt.RoleGroupName == "") continue;       // ���[���O���[�v���̐ݒ�}�X�^���폜����Ă���
                //            _roleGroupCode.Add(employeeRoleSt.RoleGroupCode);
                //        }
                //    }
                //}

                //// ���[���O���[�v�����ݒ�}�X�^�ɊY������̏ꍇ�͔�\���ɂ��邽�߁A�J�e�S���{�T�u�J�e�S���{�A�C�e����ۑ�
                //retList = null;
                //string categorySubItem = "";
                //foreach (int roleGroupCode in _roleGroupCode)
                //{
                //    status = this._roleGroupAuthAcs.SearchAll(roleGroupCode, out retList, Program.gloginInfo.EnterpriseCode);
                //    foreach (RoleGroupAuth roleGroupAuth in retList)
                //    {
                //        if (roleGroupAuth.LogicalDeleteCode == 0)
                //        {
                //            categorySubItem = roleGroupAuth.RoleCategoryID.ToString().PadLeft(4, '0') +
                //                              roleGroupAuth.RoleCategorySubID.ToString().PadLeft(6, '0') +
                //                              roleGroupAuth.RoleItemID.ToString().PadLeft(2, '0');
                //            if (_categorySubItem.Contains(categorySubItem)) continue;
                //            _categorySubItem.Add(categorySubItem);
                //        }
                //    }
                //}
                //// --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                // DEL 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��QNo142 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                //  �X�v���b�^�[�ݒ�
                spltMain.Panel1MinSize = _mMainSplitMaxLine;
                spltMain.SplitterDistance = _mMainSplitMaxLine;

                //  �J�e�S���[��񃊃X�g�̕��X�V
                lstSubCategory.Columns[0].Width = lstSubCategory.ClientSize.Width - 2;

                //  �E�[�ݒ���s��
                barInfo.SetBounds(tscMain.TopToolStripPanel.ClientSize.Width - barInfo.Width, mnuMain.Height, 0, 0, BoundsSpecified.Location);

                System.Windows.Forms.Application.DoEvents();

                //  ���݂̕��ݒ�����ɃT�u���j���[�̕������肷��
                if (_mSubMenuItemSetType == 1)
                {
                    _mSubMenuItemWidth1 = (tabMenu.ClientSize.Width - (_mSubMenuItemMargin * _mSubMenuItemDefCount1)) / _mSubMenuItemDefCount1;
                    _mSubMenuItemWidth2 = (tabMenu.ClientSize.Width - (_mSubMenuItemMargin * _mSubMenuItemDefCount2)) / _mSubMenuItemDefCount2;
                }

                //  ���j���[�{�^���n��ݒ�
                mnuLogin.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.LoginEmployee];
                mnuLogin.ImageTransparentColor = Color.Cyan;
                mnuExit.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.CloseWindow];
                mnuExit.ImageTransparentColor = Color.Cyan;
                mnuSearch.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Search];
                mnuSearch.ImageTransparentColor = Color.Cyan;
                mnuEditUserMenu.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.EditUserMenu];
                mnuEditUserMenu.ImageTransparentColor = Color.Cyan;
                mnuOption.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.OptionTool];
                mnuOption.ImageTransparentColor = Color.Cyan;
                //mnuLoginInfo.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.LoginEmployee]; 2009.02.10 sugi del
                //mnuLoginInfo.ImageTransparentColor = Color.Cyan; 2009.02.10 sugi del
                mnuVersion.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.VersionInfo];
                mnuVersion.ImageTransparentColor = Color.Cyan;
                
                //--- ADD 2011/06/29 M.Kubota --->>>
                _CustomHistoryFullPath = Path.Combine(Path.GetDirectoryName(gcmd[0]), cCustomHistoryFile);

                if (File.Exists(_CustomHistoryFullPath))
                {
                    // �ʃv���O�����������ς݂̏ꍇ�ɂ̂ݕ\������
                    mnuCustHistory.Visible = true;
                    mnuCustHistory.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.EditUserMenu];
                    mnuCustHistory.ImageTransparentColor = Color.Cyan;
                }
                else
                {
                    // �ʃv���O�������������̏ꍇ�͔�\���Ƃ���
                    mnuCustHistory.Visible = false;
                }
                //--- ADD 2011/06/29 M.Kubota ---<<<

                mnuTabDel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.DeleteAllTab];
                mnuTabDel.ImageTransparentColor = Color.Cyan;
                mnuRTabDel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.DeleteRightTabPage];
                mnuRTabDel.ImageTransparentColor = Color.Cyan;
                mnuLTabDel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.DeleteLeftTabPage];
                mnuLTabDel.ImageTransparentColor = Color.Cyan;
                mnuCloseTab.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.DeleteAllTab];
                mnuCloseTab.ImageTransparentColor = Color.Cyan;
                mnuResetWindow.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.InitalWindow];
                mnuResetWindow.ImageTransparentColor = Color.Cyan;
                mnuResetSize.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.InitialWindowSize];
                mnuResetSize.ImageTransparentColor = Color.Cyan;
                mnuSystemReport.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Print];
                mnuSystemReport.ImageTransparentColor = Color.Cyan;
                

                //  ���j���[���ڂ̒l��ݒ�
                mnuSavePosition.Checked = SystemSettingInfo.SaveLastPosition;
                mnuSaveSize.Checked = SystemSettingInfo.SaveLastSize;

                //  ���j���[�ݒ�XML�t�@�C����ǂݍ���
                FileEncryptgraphy fe = new FileEncryptgraphy(cMenuKey1 + cMenuKey2 + cMenuKey3 + cMenuKey4 + cMenuKey5);
                if (File.Exists(Path.Combine(_mNavigationDataDir, SFNETMENU2Utilities.DefaultSystemXML)) == false)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "�������G���[", "���j���[�ݒ�t�@�C����������܂���B\n\n�N���o���܂���B", "-92");
                    System.Windows.Forms.Application.Exit();
                }
                MemoryStream ms =  fe.DecryptFile(Path.Combine(_mNavigationDataDir, SFNETMENU2Utilities.DefaultSystemXML));
                if (ms == null)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "�������G���[", "���j���[�ݒ�t�@�C�������Ă��܂��B\n�N���o���܂���B", "-93");
                    System.Windows.Forms.Application.Exit();
                }
                if (SFNETMENU2Utilities.SetSystemConfig(ms) != 0)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "�������G���[", "���j���[�ݒ�t�@�C�������Ă��܂��B\n�N���o���܂���B", "-94");
                    System.Windows.Forms.Application.Exit();
                }

                //  ���i�����擾����
                for (int i = 0; i < arProducts.Count; i++)
                {
                    ProductsInfomation pi = (ProductsInfomation)arProducts[i];
                    //DataRow[] TopCategory = SFNETMENU2Utilities.GetCategory(pi.ProductID, 0, true);   //  2006.09.29  �ύX
                    DataRow[] TopCategory = SFNETMENU2Utilities.GetProducts(pi.ProductID);
                    if (TopCategory.Length > 0)
                    {
                        pi.ProductName = TopCategory[0]["Name"].ToString();
                        pi.Version = TopCategory[0]["Description"].ToString();
                        //pi.IconType = TopCategory[0]["IconType"].ToString();                          //  2006.09.29  �폜
                        pi.IconIndex = (int)TopCategory[0]["IconIndex"];
                        pi.IconName = TopCategory[0]["IconName"].ToString();
                        //pi.SystemCode = TopCategory[0]["SystemCode"].ToString();                      //  2006.09.29  �폜
                        //pi.OptionCode = TopCategory[0]["OptionCode"].ToString();                      //  2006.09.29  �폜
                        pi.SysOpCode = TopCategory[0]["SysOpCode"].ToString();                          //  2006.09.29  �ǉ�
                        pi.DisplayOption = TopCategory[0]["DisplayOption"].ToString();
                    }

                    SystemCheck.ClearSystemCode();                                                      //  2006.09.29  �ǉ�
                    SystemCheck.AddSystemCode(pi.SysOpCode);                                            //  2006.09.29  �ǉ�

                }
                // �A�v���P�[�V�������̂�ݒ肷��
                if (arProducts.Count == 1)
                {
                    Bitmap bm = (Bitmap)MenuIconResourceManagement.GetImageListImage("ImgIcon", ((ProductsInfomation)arProducts[0]).IconIndex);
                    //this.Icon = Icon.FromHandle(bm.GetHicon());
                    this.Text = ((ProductsInfomation)arProducts[0]).ProductName + " �Ɩ����j���[";
                }
                else
                {
                    this.Text = "�Ɩ����j���[";
                }
                // �A�v���P�[�V�����A�C�R����ݒ肷��

                //  �J�e�S������ݒ肷��--------------------------------------------------------------
                grpButton.ImageList = MenuIconResourceManagement.GetImageList(((ProductsInfomation)arProducts[0]).IconName);
//                int SubCategoryPanelHigh = 0;
                grpButton.GroupButtons.Clear();
                //  ��ڂ̃{�^���͓��ʈ���
                GroupButton gbtop = new GroupButton();
                gbtop.Enabled = true;
                gbtop.ImageIndex = SystemSettingInfo.CategoryPriority;
                gbtop.Text = "";
                gbtop.Size = new Size(gbtop.Size.Width, 20);

                CategoryInfomation citop = new CategoryInfomation();
                citop.CategoryID = cFncUpDown;
                citop.No = 0;
                citop.Name = "";
                citop.Description = "";
                //citop.IconType = "";                                                  //  2006.09.29  �폜
                citop.IconIndex = gbtop.ImageIndex;
                citop.IconName = "";
                citop.Icon = grpButton.ImageList.Images[citop.IconIndex];
                //citop.SystemCode = "";                                                //  2006.09.29  �폜
                //citop.OptionCode = "";                                                //  2006.09.29  �폜
                citop.SysOpCode = "";                                                   //  2006.09.29  �ǉ�
                citop.DisplayOption = "0";
                gbtop.Tag = citop;
                //grpButton.GroupButtons.Add(gbtop);//2009.01.13 sugi del
                this._stratUpCategoryIDs = new List<int>();                             // 2009.08.20 Add
                string[] ProductIDs = new string[arProducts.Count];
                for (int i=0;i<arProducts.Count;i++)
                {
                    //ProductIDs[0] = ((ProductsInfomation)arProducts[i]).ProductID;    //  2006.09.29  �ύX
                    ProductIDs[i] = ((ProductsInfomation)arProducts[i]).ProductID;
                }
                //DataRow[] Category = SFNETMENU2Utilities.GetCategory(ProductIDs);     //  2006.09.29  �ύX
                DataRow[] Category = SFNETMENU2Utilities.GetCategory(ProductIDs, true);
                //�ʏ�{�^��
                for (int i = 0; i < Category.Length; i++)
                {
                    //  �C���t�H���[�V�����̓J�e�S���ɂ��Ȃ�                            //  2007.06.06  �ǉ�
                    if (Category[i]["DisplayOption"].ToString().ToUpper() == "I")
                    {
                        continue;
                    }
                    // 2009.08.20 Add >>>
                    // �X�^�[�g�A�b�v�N���͕\�����Ȃ�
                    else if (Category[i]["DisplayOption"].ToString().ToUpper() == "E")
                    {
                        this._stratUpCategoryIDs.Add((int)Category[i]["CategoryID"]);
                        continue;
                    }
                    // 2009.08.20 Add <<<
                    //2009.02.04  sugi ->>
                    //  �T�|�[�g��p�̃J�e�S��
                    else if (Category[i]["DisplayOption"].ToString().ToUpper() == "S")
                    {
                        //  �T�|�[�g�ȊO�ɂ͔�\��
                        if (LoginInfoAcquisition.Employee.UserAdminFlag < 2) continue;
                    }
                    
                    //  �Ǘ��Ґ�p�̃J�e�S��
                    else if (Category[i]["DisplayOption"].ToString().ToUpper() == "A")
                    {
                        //  �T�|�[�g�ƊǗ��҈ȊO�ɂ͔�\��
                        if (LoginInfoAcquisition.Employee.UserAdminFlag == 0) continue;
                    }
                    //  �T�|�[�g����ȊO�̃J�e�S���̓T�|�[�g�ɂ͔�\��
                    else
                    {
                        if (LoginInfoAcquisition.Employee.UserAdminFlag != 0) continue;
                    }
                    //2009.02.04  sugi -<<

                    // ���啪�ނ̋@�\�ǉ�����(�]�ƈ����x�����擾���A�\����\���̐�����s��)  // 2007.05.16 Add By Y.Ito

                    // �������x�����擾
                    int roleLevel1 = LoginInfoAcquisition.Employee.AuthorityLevel1;
                    int roleLevel2 = LoginInfoAcquisition.Employee.AuthorityLevel2;

                    // ���p�\�������擾(ItemsArray[9]�`ItemsArray[14]�܂ł����p�\����1�`���p�\����6)
                    // �������x��1�̗��p����
                    string enableCondition1 = Category[i].ItemArray[9].ToString();
                    string enableCondition2 = Category[i].ItemArray[10].ToString();
                    string enableCondition3 = Category[i].ItemArray[11].ToString();
                    // �������x��2�̗��p����
                    string enableCondition4 = Category[i].ItemArray[12].ToString();
                    string enableCondition5 = Category[i].ItemArray[13].ToString();
                    string enableCondition6 = Category[i].ItemArray[14].ToString();

                    // ���p�\����������̉��
                    int checkResultsA = -1; // �������x��1�̏���1
                    int checkResultsB = -1; // �������x��1�̏���2
                    int checkResultsC = -1; // �������x��1�̏���3
                    int checkResultsD = -1; // �������x��2�̏���1
                    int checkResultsE = -1; // �������x��2�̏���2
                    int checkResultsF = -1; // �������x��2�̏���3

                    // �������x��1�̗��p�����`�F�b�N
                    if (enableCondition1 != "")
                    {
                        checkResultsA = SystemCheck.CheckUseEnable(enableCondition1, roleLevel1);
                    }

                    if (enableCondition2 != "")
                    {
                        checkResultsB = SystemCheck.CheckUseEnable(enableCondition2, roleLevel1);
                    }

                    if (enableCondition3 != "")
                    {
                        checkResultsC = SystemCheck.CheckUseEnable(enableCondition3, roleLevel1);
                    }

                    // �������x��2�̗��p�����`�F�b�N
                    if (enableCondition4 != "")
                    {
                        checkResultsD = SystemCheck.CheckUseEnable(enableCondition4, roleLevel2);
                    }

                    if (enableCondition5 != "")
                    {
                        checkResultsE = SystemCheck.CheckUseEnable(enableCondition5, roleLevel2);
                    }

                    if (enableCondition6 != "")
                    {
                        checkResultsF = SystemCheck.CheckUseEnable(enableCondition6, roleLevel2);
                    }

                    // ���������������ꍇ�������͏������P�ł��ʂ�ꍇ
                    if ((checkResultsA == -1 && checkResultsB == -1 && checkResultsC == -1 &&
                        checkResultsD == -1 && checkResultsE == -1 && checkResultsF == -1) ||
                        (checkResultsA == 1 || checkResultsB == 1 || checkResultsC == 1 ||
                         checkResultsD == 1 || checkResultsE == 1 || checkResultsF == 1))
                    {
                        //  �@�\�̎g�p�E�s�̊m�F
                        if (SystemCheck.CheckSystemPermissionFunction(Category[i]) == 0)
                        {
                            continue;
                        }
                        GroupButton gb = new GroupButton();
                        gb.Enabled = true;
                        // gb.ImageIndex = (int)Category[i]["IconIndex"]; //2009.01.13 sugi del
                        gb.Text = " " + Category[i]["Name"].ToString();//2009.01.13 sugi chg
                        gb.Size = new Size(gb.Size.Width, 30);
                        CategoryInfomation ci = new CategoryInfomation();
                        ci.CategoryID = (int)Category[i]["CategoryID"];
                        ci.No = (int)Category[i]["No"];
                        ci.Name = Category[i]["Name"].ToString();//2009.01.13 sugi add
                        ci.Description = Category[i]["Description"].ToString();
                        //ci.IconType = Category[i]["IconType"].ToString();                 //  2006.09.29  �폜
                        ci.IconIndex = (int)Category[i]["IconIndex"];
                        ci.IconName = Category[i]["IconName"].ToString();
                        ci.Icon = grpButton.ImageList.Images[ci.IconIndex];
                        //ci.SystemCode = Category[i]["SystemCode"].ToString();             //  2006.09.29  �폜
                        //ci.OptionCode = Category[i]["OptionCode"].ToString();             //  2006.09.29  �폜
                        ci.SysOpCode = Category[i]["SysOpCode"].ToString();                 //  2006.09.29  �ǉ�
                        ci.DisplayOption = Category[i]["DisplayOption"].ToString();
                        gb.Tag = ci;
                        // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        string categorySubItem = "";    // ADD 2013/02/25 �O�� 2013/03/06�z�M�V�X�e���e�X�g��QNo142
                        // ���[���O���[�v�����ݒ�}�X�^�ɊY������̏ꍇ�͔�\��
                        categorySubItem = ci.CategoryID.ToString().PadLeft(4,'0') + "000000" + "00";
                        if (_categorySubItem.Contains(categorySubItem)) continue;
                        // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        grpButton.GroupButtons.Add(gb);
                        // SubCategoryPanelHigh = SubCategoryPanelHigh + gb.Size.Height + grpButton.GroupButtonMargin;
                    }
                }
                //  �Ō�̃{�^���̓��[�U�[�J�X�^�����j���[
                GroupButton gbusr = new GroupButton();
                gbusr.Enabled = true;
                //gbusr.ImageIndex = 3;//2009.01.13 sugi del
                gbusr.Text = " ���C�ɓ���"; //2009.01.13 sugi chg
                gbusr.Size = new Size(gbusr.Size.Width, 30);
                CategoryInfomation ciusr = new CategoryInfomation();
                ciusr.CategoryID = cFncUserMenu;
                ciusr.No = 0;
                //ciusr.Name = gbusr.Text;  //2009.01.13 sugi del
                ciusr.Name = "���C�ɓ���"; //2009.01.13 sugi chg
                ciusr.Description = "";
                //ciusr.IconType = "res";                                               //  2006.09.29  �폜
                //ciusr.IconIndex = gbusr.ImageIndex; //2009.01.13 sugi del
                ciusr.IconName = "";
                ciusr.Icon = grpButton.ImageList.Images[ciusr.IconIndex];
                //ciusr.SystemCode = "";                                                //  2006.09.29  �폜
                //ciusr.OptionCode = "";                                                //  2006.09.29  �폜
                ciusr.SysOpCode = "";                                                   //  2006.09.29  �ǉ�
                ciusr.DisplayOption = "0";
                gbusr.Tag = ciusr;
                grpButton.GroupButtons.Add(gbusr);

                //--- ADD 2011/06/29 M.Kubota --->>>
                // �J�e�S���[�̃X�N���[���Ή�
                this.MouseWheel += spltCategory_Panel2_MouseWheel;  // �}�E�X�z�C�[���ɑΉ�
                
                vGroupButtonScrollBar.Minimum = 0;
                vGroupButtonScrollBar.Visible = false;
                vGroupButtonScrollBar.Parent = spltCategory.Panel2;
                vGroupButtonScrollBar.Dock = DockStyle.Right;
                vGroupButtonScrollBar.Width = SystemInformation.VerticalScrollBarWidth;

                // �{�^�����ɉ����ăO���[�v�{�^���̍�����ݒ�
                grpButton.Height = grpButton.GroupButtons.Count * (grpButton.GroupButtons[0].Size.Height + 1) + 2;
                grpButton.Width = spltCategory.Panel2.Width - 2;
                grpButton.Visible = true;
                //--- ADD 2011/06/29 M.Kubota ---<<<

                System.Windows.Forms.Application.DoEvents();

                // 2008.09.28 sugi -<<
                //  �C���t�H���[�V������\��                                
                CategoryInfomation ciinf = new CategoryInfomation();
                TabPage tbinf = null;
                for (int i = 0; i < Category.Length; i++)
                {
                    //  �C���t�H���[�V�����̓J�e�S���ɂ��Ȃ�                  
                    if (Category[i]["DisplayOption"].ToString() == "I")
                    {
                        //Top��\�����Ȃ��ꍇ�̓X���[
                        if (SystemSettingInfo.TopMenu == true) continue;

                        ciinf.Name = "�C���t�H���[�V����";//2009.01.13 sugi chg
                        ciinf.Icon = grpButton.ImageList.Images[Convert.ToInt32(Category[i]["IconIndex"])];
                        tbinf = CreateTabMenubPage(ciinf);
                        tabMenu.SelectedTab = tbinf;
                        WebBrowser wb = new WebBrowser();
                        wb.Parent = tbinf;
                        wb.Dock = DockStyle.Fill;
                        gServiceTopPage = Program.arm.GetAPServiceTargetDomain(Category[i]["Description"].ToString());
                        wb.Navigate(gServiceTopPage);
                    }
                }
                // 2008.09.28 sugi -<<

                TabPage toptab = null;                                          //  2007.07.25
                //  �ݒ������ɃJ�e�S�����T�u�J�e�S�����T�u���j���[������
                //                grpButton.PerformButtonClick(SFCMN99999U.TGroupButton.EventSoruceType.Mouse, SystemMenuInfo.SelectCategory);
                //if (SystemMenuInfo.SelectCategory > 0)                        //  2007.01.10  �ύX
                if ((SystemMenuInfo.SelectCategory > 0) || (SystemMenuInfo.SelectCategory == cFncUserMenu))
                {
                    for (int i = 0; i < grpButton.GroupButtons.Count; i++)
                    {
                        if (((CategoryInfomation)grpButton.GroupButtons[i].Tag).CategoryID == SystemMenuInfo.SelectCategory)
                        {
                            grpButton.SelectedButtonIndex = i;
                            break;
                        }
                    }
                    //  �\���\�Ȑݒ��񂪂���΁A���f���Ă���
                    if (grpButton.SelectedButtonIndex != -1)
                    {
                        CategoryInfomation ci = (CategoryInfomation)grpButton.GroupButtons[grpButton.SelectedButtonIndex].Tag;
                        if (SystemMenuInfo.SelectSubMenuCollection.Count > 0)
                        {
                            TabPage tb = DisplaySubCategory(ci, grpButton.SelectedButtonIndex, 1);
                            for (int i = 0; i < SystemMenuInfo.SelectSubMenuCollection.Count; i++)
                            {
                                //                                                                                              //  2006.09.29  �폜
                                /*
                                SubCategoryInfomation lci = (SubCategoryInfomation)SystemMenuInfo.SelectSubMenuCollection[i]; 
                                //  �@�\�̎g�p�E�s�̊m�F
                                //if (SystemCheck.CheckSystemPermissionFunction(lci.SystemCode, lci.OptionCode) == 0)
                                {
                                    continue;
                                }
                                if (CreateSubItem(tb, lci, 1, false) == 3)
                                {
                                    break;
                                }
                                */
                                //  ���j���[�ۑ����̃o�[�W�������Ⴄ�ꍇ�A��ʌ݊�����������                                      //  2006.09.29  �ǉ� VV
                                //  (2006.09.29���_�ł͏������̃o�[�W�������`�F�b�N����K�v�͖��������㔭������\��)
                                SubCategoryInfomation lci = new SubCategoryInfomation();
                                //  �e����(�Ⴆ�΃V�X�e���E�I�v�V����)���ς���Ă���\��������̂ŁA�J�e�S���E�T�u�J�e�S������ɐ������f�[�^���擾����
                                SubCategoryInfomation wklci = (SubCategoryInfomation)SystemMenuInfo.SelectSubMenuCollection[i];
                                //DataRow[] Categoryinf = SFNETMENU2Utilities.GetSubCategory(wklci.CategoryID, wklci.CategorySubID);    //  2007.01.10  �ύX
                                DataRow[] Categoryinf;
                                if (SystemMenuInfo.SelectCategory > 0)
                                {
                                    Categoryinf = SFNETMENU2Utilities.GetSubCategory(wklci.CategoryID, wklci.CategorySubID);
                                }
                                else
                                {
                                    Categoryinf = SFNETMENU2Utilities.GetUserCategoryGroup(wklci.CategorySubID);
                                }
                                if (Categoryinf.Length > 0)
                                {
                                    lci.CategoryID = (int)Categoryinf[0]["CategoryID"];
                                    lci.CategorySubID = (int)Categoryinf[0]["CategorySubID"];
                                    lci.No = (int)Categoryinf[0]["No"];
                                    lci.Name = Categoryinf[0]["Name"].ToString();
                                    lci.Description = Categoryinf[0]["Description"].ToString();
                                    lci.IconIndex = (int)Categoryinf[0]["IconIndex"];
                                    lci.IconName = Categoryinf[0]["IconName"].ToString();
                                    lci.SysOpCode = Categoryinf[0]["SysOpCode"].ToString();
                                    lci.DisplayOption = Categoryinf[0]["DisplayOption"].ToString();
                                    //  �擾���ʂ𔽉f������
                                    SystemMenuInfo.SelectSubMenuCollection[i] = lci;
                                    //  �@�\�̎g�p�E�s�̊m�F
                                    if (SystemCheck.CheckSystemPermissionFunction(lci.SysOpCode) == 0)
                                    {
                                        continue;
                                    }
                                    if (CreateSubItem(tb, lci, 1, false) == 3)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DisplaySubCategory(ci, grpButton.SelectedButtonIndex, 0);
                        }
                    }
                    else
                    {
                        stsInfo1.Text = "�����\���ݒ肪�ۑ����ꂽ�󋵂Ɛ��i�\�����Ⴂ�܂��B�����\���ݒ��K�p���鎖���o���܂���ł����B";
                    }
                }
                else
                {
                    //  ���[�U�[�ݒ胁�j���[�������ꍇ���l�����A�擾���s�̏ꍇ�A�J�e�S���̐擪�{�^���̃V�X�e����\������
                    // 2009.08.20 >>>
                    //grpButton.SelectedButtonIndex = 1;
                    grpButton.SelectedButtonIndex = 0;
                    // 2009.08.20 <<<
                    //  �������j���[��\��
                    grpButton.PerformButtonClick(TGroupButton.EventSoruceType.Mouse, grpButton.SelectedButtonIndex);
                }


                // ���t�F���ԃX���b�h�̐錾
//                Thread thread_1 = new Thread(new ThreadStart(func_1));
//                thread_1.Start();

                //  �T�C�Y�ύX
                ResizeCategory();
                System.Windows.Forms.Application.DoEvents();

                System.Windows.Forms.Application.DoEvents();

                calTimer.Enabled = true;
                calTimer.Start();

                //  ���[���ݒ�t�@�C����ǂݍ���
                //  ���j���[�ݒ�XML�t�@�C����ǂݍ���
                arRollSettings = ReadRollSettingFile();
                if (arRollSettings == null)
                {
                    arRollSettings = new ArrayList();
                }

                //  �t�H�[�J�X����
                try
                {
                    if (tabMenu.SelectedIndex > -1)
                    {
                        TabMenuInfomation ti = (TabMenuInfomation)tabMenu.SelectedTab.Tag;
                        if (ti.arSubItems.Count > 0)
                        {
                            ((TGroupButton)ti.arSubItems[ti.arSubItems.Count - 1]).Focus();
                        }
                    }
                    else
                    {
                        lstSubCategory.Focus();
                    }
                }
                catch (Exception)
                {
                }

                //stsInfo1.Text = "Ready";                                          //  2006.09.29  �ǉ�
                if (stsInfo1.Text.Trim().Length == 0)
                {
                    stsInfo1.Text = "Ready";
                }

                //2008.09.26 sugi -->>>>
                //  �C���t�H���[�V������\�����Ȃ�(true)                               
                if (SystemSettingInfo.TopMenu == false)
                {
                    tabMenu.SelectedTab = tbinf;
                    btnBack.Visible = true;
                    btnFwd.Visible = true;
                }
                else
                {
                    if (toptab != null)
                    {
                        tabMenu.SelectedTab = toptab;
                    }
                }
                //2008.09.26 sugi --<<<<

                this.ExecuteStartUp();      // 2009.08.20 Add
            }

        }

        // 2009.08.20 Add >>>
        /// <summary>
        /// �X�^�[�g�A�b�v�v���O�����̋N��
        /// </summary>
        private void ExecuteStartUp()
        {
            foreach (int categoryID in this._stratUpCategoryIDs)
            {
                DataRow[] categorySubInfo = SFNETMENU2Utilities.GetSubCategoryGroup(categoryID);

                if (categorySubInfo != null && categorySubInfo.Length > 0)
                {
                    for (int i = 0; i < categorySubInfo.Length; i++)
                    {
                        DataRow[] productItems = SFNETMENU2Utilities.GetProductItem(categoryID, (int)categorySubInfo[i]["CategorySubID"], 0);

                        if (productItems != null && productItems.Length > 0)
                        {
                            for (int j = 0; j < productItems.Length; j++)
                            {
                                MenuItemInfomation mii = new MenuItemInfomation();
                                mii.Pgid = productItems[j]["Pgid"].ToString();
                                mii.Name = productItems[j]["Name"].ToString();
                                mii.Parameter = productItems[j]["Parameter"].ToString();
                                mii.Description = productItems[j]["Description"].ToString();
                                mii.SysOpCode = productItems[j]["SysOpCode"].ToString();
                                mii.DisplayOption = productItems[j]["DisplayOption"].ToString();
                                mii.SearchKeyWord = productItems[j]["SearchKeyWord"].ToString();
                                mii.Rank = (int)productItems[j]["Rank"];

                                string retStr = "";
                                //  ���[�������N�̎w�肪�������ꍇ�A�p�X���[�h�`�F�b�N���s��
                                CheckRollTypes crt = CheckRollPassword(mii, ref retStr);
                                if (crt == CheckRollTypes.Normal_NG)
                                {
                                    continue;
                                }

                                // �v���O���������݂��Ȃ��ꍇ�͏I��
                                if (File.Exists(Path.Combine(Path.GetDirectoryName(gcmd[0]), mii.Pgid)) == false) continue;

                                // �I�v�V�����R�[�h�̃`�F�b�N
                                if (SystemCheck.CheckSystemPermissionFunction(mii.SysOpCode) == 0) continue;

                                // --- ADD 2013/12/11 T.Nishi ---------->>>>>
                                //���j���[�ȈՋN���I�v�V��������������Ă��Ȃ��ꍇ�́A�uPMHNB01000U�v�A�uPMKAU04020U�v�풓�̋N���͍s��Ȃ�
                                //if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM02010") == 0)  // DEL 2013/12/19
                                if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM02010") <= 0) // ADD 2013/12/19
                                    && (mii.Pgid == TargetPGID_PMHNB01000U || mii.Pgid == TargetPGID_PMKAU04020U))
                                {
                                    continue;
                                }
                                // --- ADD 2013/12/11 T.Nishi ----------<<<<<


                                //  �p�����[�^�}�N����u��
                                string pgParam = mii.Parameter;
                                if (pgParam.IndexOf("%%") > 0)
                                {

                                    try
                                    {
                                        for (int k = 0; k < gMacroString.Length; k++)
                                        {
                                            if (pgParam.IndexOf(gMacroString[k]) > 0)
                                            {
                                                if (gMacroStringFunc[k] == "WEB")
                                                {
                                                    string webPage = pgParam.Substring(pgParam.IndexOf(gMacroString[k]), gMacroString[k].Length);
                                                    webPage = Program.arm.GetAPServiceTargetDomain(gMacroStringAp[k]);
                                                    pgParam = pgParam.Replace(gMacroString[k], webPage);
                                                }

                                                if (gMacroStringFunc[k] == "PRD")
                                                {
                                                    string productCode = pgParam.Substring(pgParam.IndexOf(gMacroString[k]), gMacroString[k].Length);
                                                    productCode = LoginInfoAcquisition.ProductCode;
                                                    pgParam = pgParam.Replace(gMacroString[k], productCode);
                                                }

                                                // 2009.09.14 Add >>>
                                                if (gMacroStringFunc[k] == "INFCON")
                                                {
                                                    string webPage = pgParam.Substring(pgParam.IndexOf(gMacroString[k]), gMacroString[k].Length);
                                                    webPage = Program.arm.GetConnectionInfo(gMacroStringAp[k], gMacroStringAp[k]);
                                                    pgParam = pgParam.Replace(gMacroString[k], webPage);
                                                }
                                                // 2009.09.14 Add <<<
                                            }
                                        }
                                        mii.Parameter = pgParam;
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }

                                // �v���O�����̋N��
                                string args = _mAccessNo + " " + _mPortNo + " " + mii.Parameter + " " + retStr;
                                args = args.Trim();

                                try
                                {
                                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(Path.Combine(Path.GetDirectoryName(gcmd[0]), mii.Pgid), args);
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        // 2009.08.20 Add <<<


        /// <summary>
        /// �T�u�J�e�S�����x���y�C���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCategory_Paint(object sender, PaintEventArgs e)
        {

            //���Ăɔ����獕�ւ̃O���f�[�V�����̃u���V���쐬
            //g.VisibleClipBounds�͕\���N���b�s���O�̈�ɊO�ڂ���l�p�`
            LinearGradientBrush myBrush = new LinearGradientBrush(e.Graphics.VisibleClipBounds, ScreenInfo.CategoryLabelBackColor1, ScreenInfo.CategoryLabelBackColor2, ScreenInfo.CategoryLabelGradiationMode);

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
            Brush brsh = new SolidBrush(ScreenInfo.CategoryLabelForeColor);
            //�������`��
            e.Graphics.DrawString(((Label)sender).Text, ((Label)sender).Font, brsh, ((Label)sender).ClientRectangle, sf);
            //�{�^���̔w�i�摜���{�^���̑傫���ɍ��킹�ĕ`��
//            if ((grpButton.ImageList != null) && (grpButton.SelectedButtonIndex > -1))
//            {
//                Image img = grpButton.ImageList.Images[grpButton.SelectedButtonIndex];
            if (lblCategory.Image != null)
            {
                e.Graphics.DrawImage(lblCategory.Image, new Point(3, (((Label)sender).ClientSize.Height - lblCategory.Image.Height) / 2));
            }
//                img.Dispose();
//            }

            //���\�[�X���J������
            brsh.Dispose();
            myBrush.Dispose();
            e.Dispose();
        }


        /// <summary>
        /// �J�e�S���O���[�v�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [MTAThread]
        private void grpButton_GroupButtonClick(object sender, TGroupButton.GroupButtonEventArgs e)
        {
            // --- UPD m.suzuki 2011/08/08 ---------->>>>>
            # region // DEL
            ////2009.01.13 sugi ��
            ////  �{�^����I����Ԃ�
            //grpButton.SelectedButtonIndex = e.ButtonIndex;
            //CategoryInfomation cci = (CategoryInfomation)grpButton.GroupButtons[e.ButtonIndex].Tag;
            ////  �J�e�S����񕔕\��
            //DisplaySubCategory(cci, e.ButtonIndex, 0);
            ///*
            ////  �J�e�S���E�T�u�J�e�S���̗D��؂�ւ�
            //if (e.ButtonIndex == 0)
            //{
            //    if (_mPanelPriorityMode == 1)
            //    {
            //        //  �J�e�S���D�惂�[�h��
            //        _mPanelPriorityMode = 0;
            //        grpButton.GroupButtons[0].ImageIndex = 0;
            //        ResizeCategory();
            //    }
            //    else
            //    {
            //        //  �T�u�J�e�S���D�惂�[�h��
            //        _mPanelPriorityMode = 1;
            //        grpButton.GroupButtons[0].ImageIndex = 1;
            //        ResizeCategory();
            //    }
            //}
            //else
            ////  �J�e�S���؂�ւ�
            //{
            //    //  �{�^����I����Ԃ�
            //    grpButton.SelectedButtonIndex = e.ButtonIndex;

            //    CategoryInfomation cci = (CategoryInfomation)grpButton.GroupButtons[e.ButtonIndex].Tag;

            //    //  �J�e�S����񕔕\��
            //    DisplaySubCategory(cci, e.ButtonIndex, 0);
            //}
            // */
            ////2009.01.13 sugi ��
            # endregion

            if ( e.ButtonIndex == 0 )
            {
                //  �{�^����I����Ԃ�
                grpButton.SelectedButtonIndex = e.ButtonIndex;
                CategoryInfomation cci = (CategoryInfomation)grpButton.GroupButtons[e.ButtonIndex].Tag;
                //  �J�e�S����񕔕\��
                DisplaySubCategory( cci, e.ButtonIndex, 0 );
            }
            else
            {
                //  �R�~���j�P�[�V�����c�[���N��
                CategoryInfomation cci = (CategoryInfomation)grpButton.GroupButtons[e.ButtonIndex].Tag;
                if ( cci.Description.IndexOf( ".exe", StringComparison.OrdinalIgnoreCase ) > -1 )
                {
                    MenuItemInfomation mii = new MenuItemInfomation();
                    mii.CategoryID = cci.CategoryID;
                    mii.CategorySubID = 0;
                    mii.ItemID = 0;
                    mii.ItemSubID = 0;
                    mii.Pgid = cci.Description;
                    mii.Parameter = "";
                    mii.Name = cci.Description;
                    StartProgram( sender, mii, "" );
                    return;
                }

                //  �{�^����I����Ԃ�
                grpButton.SelectedButtonIndex = e.ButtonIndex;
                //  �J�e�S����񕔕\��
                DisplaySubCategory( cci, e.ButtonIndex, 0 );
            }
            // --- UPD m.suzuki 2011/08/08 ----------<<<<<

        }

        /// <summary>
        /// �E�C���h�E�ʒu�ۑ����j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSavePosition_CheckedChanged(object sender, EventArgs e)
        {
            SystemSettingInfo.SaveLastPosition = mnuSavePosition.Checked;

            MenuConfigration mc = new MenuConfigration();

            mc.SystemSettingInfo = SystemSettingInfo;
            mc.SystemMenuInfo = SystemMenuInfo;
            mc.ScreenInfo = ScreenInfo;
            mc.UserMenu = UserMenuInfo;

            if (WriteSettingFile(mc) != 0)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Main", "�ۑ��G���[", "�ݒ�t�@�C���̍X�V�Ɏ��s���܂����B", "-981");
            }

        }

        /// <summary>
        /// �E�C���h�E�T�C�Y�ۑ����j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSaveSize_CheckedChanged(object sender, EventArgs e)
        {
            SystemSettingInfo.SaveLastSize = mnuSaveSize.Checked;

            MenuConfigration mc = new MenuConfigration();

            mc.SystemSettingInfo = SystemSettingInfo;
            mc.SystemMenuInfo = SystemMenuInfo;
            mc.ScreenInfo = ScreenInfo;
            mc.UserMenu = UserMenuInfo;

            if (WriteSettingFile(mc) != 0)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Main", "�ۑ��G���[", "�ݒ�t�@�C���̍X�V�Ɏ��s���܂����B", "-982");
            }

        }

        /// <summary>
        /// �J�����_�[�p�^�C�}�[�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calTimer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = SFNETMENU2Utilities.GetCalendar(ref SystemSettingInfo.DateTimeFormat);
            System.Windows.Forms.Application.DoEvents();
            barInfo.SetBounds(tscMain.TopToolStripPanel.ClientSize.Width - barInfo.Width, mnuMain.Height, 0, 0, BoundsSpecified.Location);
            System.Windows.Forms.Application.DoEvents();

            //  30�b���̓X�e�[�^�X�N���A
            if (_mClrTime > 30000)
            {
                stsInfo1.Text = "";
                _mClrTime = 0;
            }
            else
            {
                _mClrTime = _mClrTime + calTimer.Interval;
            }

        }

        /// <summary>
        /// �T�u���j���[�O���[�v�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grpSubItem_GroupButtonClick(object sender, TGroupButton.GroupButtonEventArgs e)
        {
            if (SystemSettingInfo.NumKeyEnabled == false)
            {
                return;
            }


            if (e.ButtonIndex > -1)
            {

                //  �v���O�����N��
                MenuItemInfomation mii = (MenuItemInfomation)((TGroupButton)sender).GroupButtons[e.ButtonIndex].Tag;
                string retStr = "";
                //  ���[�������N�̎w�肪�������ꍇ�A�p�X���[�h�`�F�b�N���s��
                CheckRollTypes crt = CheckRollPassword(mii, ref retStr);
                if (crt == CheckRollTypes.Normal_NG)
                {
                    //  �m�[�}��NG�̂ݕԂ�
                    return;
                }
                //2008.12.16 sugi add ==>>
                //  OK�����̓p�����[�^�t��NG�Ȃ�N��
                //if (StartProgram(sender, mii, retStr) != 0)
                //{
                //    stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N���ł��܂���ł���";
                //    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Execute", "�G���[", _mStatusMessage, "-910");
                //}
                //else
                //{
                //    stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N�����܂���";
                //}

                //  OK�����̓p�����[�^�t��NG�Ȃ�N��
                int iRet=StartProgram(sender, mii, retStr);
                if (iRet== -9)
                {
                    stsInfo1.Text = mii.Name.Replace("\\n", "") + "�̓Z�L�����e�B�����ɂ��N���ł��܂���ł���";
                }
                else if (iRet == -2)
                {
                    stsInfo1.Text = "�T�[�o�[�����X�V����Ă��܂���B�u�񋟃f�[�^�X�V�����v���s���Ă�������";
                    // --- DEL m.suzuki 2012/11/29 ---------->>>>>
                    //SFNETMENU2Utilities.ShowMessage( SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Execute", "�G���[", _mStatusMessage, "-920" );
                    // --- DEL m.suzuki 2012/11/29 ----------<<<<<
                }
                else if (iRet == -1)
                {
                    stsInfo1.Text = "�񋟃f�[�^�X�V�������ł��B���΂炭���҂���������";
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Execute", "�G���[", _mStatusMessage, "-920");
                }
                else if (iRet == 0)
                {
                    stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N�����܂���";
                }
                else if (iRet == -999)
                {
                    stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N���ł��܂���ł���";
                }
                else
                {
                    stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N���ł��܂���ł���";
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Execute", "�G���[", _mStatusMessage, "-910");
                }
                //2008.12.16 sugi add ==<<
            
                //  �ŋߎg�����@�\�ɐݒ�
                Image img;
                try
                {
                    img = ((TGroupButton)sender).ImageList.Images[((TGroupButton)sender).GroupButtons[e.ButtonIndex].ImageIndex];
                }
                catch
                {
                    img = null;
                }
                AddRecentFnc(sender, ((TGroupButton)sender).HeaderText, img, mii);

            }

        }

        /// <summary>
        /// �ŋߎg�����@�\�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void this_RecentClick(object sender, EventArgs e)
        {

            //  �v���O�����N��
            MenuItemInfomation mii = (MenuItemInfomation)((ToolStripMenuItem)sender).Tag;


            //  ���[�������N�̎w�肪�������ꍇ�A�p�X���[�h�`�F�b�N���s��
            string retStr = "";
            CheckRollTypes crt = CheckRollPassword(mii, ref retStr);
            if (crt == CheckRollTypes.Normal_NG)
            {
                //  �m�[�}��NG�̂ݕԂ�
                return;
            }

            //  OK�����̓p�����[�^�t��NG�Ȃ�N��
            if (StartProgram(sender, mii, retStr) != 0)
            {

                stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N���ł��܂���ł���";
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Execute", "�G���[",  _mStatusMessage, "-910");
            }
            else
            {
                stsInfo1.Text = mii.Name.Replace("\\n", "") + "���N�����܂���";
            }

        }

        /// <summary>
        /// �t�H�[�����T�C�Y�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2A_Resize(object sender, EventArgs e)
        {

            if (this.Width <= 300)
            {

                barFuncMenu.Visible = false;
                barInfo.Visible = false;
            }

            System.Windows.Forms.Application.DoEvents();

            barCtrl.SetBounds(0, mnuMain.Height, 0, 0, BoundsSpecified.Location);
            barLoginInfo.SetBounds(barCtrl.Left + barCtrl.Width + 1, mnuMain.Height, 0, 0, BoundsSpecified.Location);
            barFuncMenu.Visible = true;
            barFuncMenu.SetBounds(barLoginInfo.Left + barLoginInfo.Width + 1, mnuMain.Height, 0, 0, BoundsSpecified.Location);

            System.Windows.Forms.Application.DoEvents();

            barInfo.Visible = true;
            barInfo.SetBounds(tscMain.TopToolStripPanel.ClientSize.Width - barInfo.Width, mnuMain.Height, 0, 0, BoundsSpecified.Location);
            System.Windows.Forms.Application.DoEvents();

            stsInfo1.Width = stsInfo.ClientSize.Width - (stsInfo2.Width + stsInfo3.Width + stsInfo4.Width + stsInfoTheme.Width) - 30;

            System.Windows.Forms.Application.DoEvents();

            this.SuspendLayout();

            //  �X�v���b�^�[����
            if (spltMain.SplitterDistance > _mMainSplitMaxLine)
            {
                spltMain.SplitterDistance = _mMainSplitMaxLine;
            }
            System.Windows.Forms.Application.DoEvents();

            this.ResumeLayout();

            //  �J�e�S���{�^���𒲐�(���[�h�ɂ�菈������)
            ResizeCategory();

            System.Windows.Forms.Application.DoEvents();

            this.SuspendLayout();
            //  ���T�C�Y�̏ꍇ�A�I���^�u�ȊO�̃^�u���̍ĕ`��t���O���Z�b�g���Ă���
            try
            {
                for (int i = 0; i < tabMenu.TabPages.Count; i++)
                {
                    TabMenuInfomation tim = (TabMenuInfomation)tabMenu.TabPages[i].Tag;
                    tim.NeedRefresh = true;
                }
            }
            catch (Exception)
            {
            }
            System.Windows.Forms.Application.DoEvents();

            //  �^�u�y�[�W����������ăO���[�v�{�^���̍Ē������s��
            try
            {
                if (tabMenu.TabPages.Count > 0)
                {
                    //  �^�u�Z���N�g���ɐ؂�ւ���̃^�u�N���C�A���g�T�C�Y���A���T�C�Y�O�̃T�C�Y�ɂȂ��Ă���̂Ŏg���Ȃ��ׁA�����ŕۑ����Ă����B
                    _mtabpageSize = tabMenu.SelectedTab.ClientSize;
                    //  �^�u�y�[�W���T�C�Y
                    ResizeTabPage(tabMenu.SelectedTab);
                }
            }
            catch (Exception)
            {
            }

            this.ResumeLayout();
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// �t�H�[�����T�C�Y�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2A_ResizeEnd(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            SFNETMENU2A_Resize(sender, e);
        }

        /// <summary>
        /// �T�u�J�e�S�����X�g�r���[�A�C�e���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubCategory_Click(object sender, EventArgs e)
        {

            //  ���I���Ȃ甲����
            if (lstSubCategory.SelectedIndices.Count == 0)
            {
                return;
            }
            //  ������Ȃ��Ȃ疢�����Ƃ��Ĕ�����
            if (lstSubCategory.SelectedItems[0].Text.Trim().Length == 0)
            {
                return;
            }

            int notFoundPhase = 0;

            //  �T�u�J�e�S���I��
            SubCategoryInfomation lci = (SubCategoryInfomation)lstSubCategory.Items[lstSubCategory.SelectedIndices[0]].Tag;
            //if (SystemCheck.CheckSystemPermissionFunction(lci.SystemCode, lci.OptionCode) == 0)       //  2006.09.29  �ύX 
            if (SystemCheck.CheckSystemPermissionFunction(lci.SysOpCode) == 0)
            {
                //  �`�F�b�N�Ɉ������������疢�����Ƃ��Ĕ�����
                return;
            }
            for (int i = 0; i < tabMenu.TabPages.Count; i++)
            {

                TabMenuInfomation ti = (TabMenuInfomation)tabMenu.TabPages[i].Tag;
                if (lci.CategoryID == ti.CategoryID)
                {
                    notFoundPhase = 1;
                    tabMenu.SelectedIndex = i;
                    tabMenu.TabPages[i].Select();
                    for (int j = 0; j < tabMenu.TabPages[tabMenu.SelectedIndex].Controls.Count; j++)
                    {
                        //  �O���[�v�{�^���Ȃ�
                        if (tabMenu.TabPages[tabMenu.SelectedIndex].Controls[j].GetType() == typeof(TGroupButton))
                        {

                            SubCategoryInfomation gci = (SubCategoryInfomation)tabMenu.TabPages[tabMenu.SelectedIndex].Controls[j].Tag;
                            if (gci != null)
                            {
                                if ((lci.CategoryID == gci.CategoryID) && (lci.CategorySubID == gci.CategorySubID))
                                {
                                    tabMenu.TabPages[tabMenu.SelectedIndex].Controls[j].Select();
                                    return;
                                }
                            }

                        }

                    }
                }

            }

            //  �����o������������t�F�[�Y�ŏ�������
            if (notFoundPhase == 0)
            {
                //  �^�u�������ł��Ȃ������ꍇ�́A�V�K�^�u�����
                CategoryInfomation cig;

                for (int j = 1; j < grpButton.GroupButtons.Count; j++)
                {
                    cig = (CategoryInfomation)grpButton.GroupButtons[j].Tag;
                    if (lci.CategoryID == cig.CategoryID)
                    {
                        TabPage tb = CreateTabMenubPage(cig);
                        //  �V�K�ɍ�����ꍇ�A�w�肵���T�u�J�e�S������쐬����
                        for (int i = lstSubCategory.SelectedIndices[0]; i < lstSubCategory.Items.Count; i++)
                        {
                            SubCategoryInfomation lcisub = (SubCategoryInfomation)lstSubCategory.Items[i].Tag;
                            if (CreateSubItem(tb, lcisub, 1, true) == 3)
                            {
                                break;
                            }
                        }
                        tabMenu.SelectedIndex = tabMenu.TabPages.Count - 1;
                        tb.Focus();
                        tb.Select();
                        System.Windows.Forms.Application.DoEvents();
                        break;
                    }
                }

            }
            else if (notFoundPhase == 1)
            {
                //  �^�u�͗L�������A�O���[�v�{�^�������������ꍇ�A�T�u���j���[�����
                CreateSubItem(tabMenu.TabPages[tabMenu.SelectedIndex], lci, 0, true);
                System.Windows.Forms.Application.DoEvents();
            }

        }

        /// <summary>
        /// �����{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //  ����
            if (cmbSearchMenu.Text.Trim().Length != 0)
            {

                TabPage MenuTab = CreateTabSearchMenubPage(cmbSearchMenu.Text);
                SubCategoryInfomation ci = new SubCategoryInfomation();
                ci.CategoryID = cFncSerach;
                ci.CategorySubID = 0;
                ci.No = 0;
                ci.Name = "��������";
                //ci.IconType = "res";                                              //  2006.09.29  �폜
                ci.IconIndex = -1;
                ci.IconName = "";
                ci.Description = "";
                //ci.SystemCode = "";                                               //  2006.09.29  �폜
                //ci.OptionCode = "";                                               //  2006.09.29  �폜
                ci.SysOpCode = "";                                                  //  2006.09.29  �ǉ�
                ci.DisplayOption = "0";
                int SearchCount;
                int DispCount;
                CreateSearchItem(MenuTab, ci, 0, cmbSearchMenu.Text, true, out SearchCount, out DispCount);
                stsInfo1.Text = SearchCount.ToString() + "�������A" + DispCount.ToString() + "���\�����܂���";
                tabMenu.SelectedIndex = tabMenu.TabPages.Count - 1;
                MenuTab.Select();
                System.Windows.Forms.Application.DoEvents();

            }
        }

        /// <summary>
        /// �����e�L�X�g�{�b�N�X�L�[�v���X�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSearchMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        /// <summary>
        /// �T�u���j���[�^�u�E�}�E�X�{�^���_�E���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_MouseDown(object sender, MouseEventArgs e)
        {
            //	�^�u���E�N���b�N���ꂽ��^�u�������s�Ȃ�
            _mTargetingTabPage = -1;
            switch (e.Button)
            {
                case MouseButtons.Right:

                    for (int i = 0; i < tabMenu.TabCount; i++)
                    {
                        if (tabMenu.GetTabRect(i).Contains(e.X, e.Y))
                        {
                            _mTargetingTabPage = i;
                            mnuTab.Show(tabMenu, e.X, e.Y);
                            break;
                        }
                    }
                    break;
            }

        }

        /// <summary>
        /// �ŋߎg�����@�\�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barRecent_Click(object sender, EventArgs e)
        {
            barRecent.ShowDropDown();
        }

        /// <summary>
        /// �T�u���j���[�^�u�؂�ւ��������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == null)
                return;

            TabMenuInfomation ti = (TabMenuInfomation)e.TabPage.Tag;
            if (ti.NeedRefresh == true)
            {
                ResizeTabPage(e.TabPage);
            }

        }

        /// <summary>
        /// �^�u�y�[�W�폜�v���_�E�����j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTabDel_Click(object sender, EventArgs e)
        {
            if (_mTargetingTabPage > -1)
            {
                tabMenu.TabPages[_mTargetingTabPage].Dispose();
                _mTargetingTabPage = -1;
            }
        }

        /// <summary>
        /// �E�^�u�y�[�W�폜�v���_�E�����j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRTabDel_Click(object sender, EventArgs e)
        {
            if (_mTargetingTabPage > -1)
            {
                int idx = _mTargetingTabPage;
                for (int i = tabMenu.TabPages.Count - 1; i > idx; i--)
                {
                    tabMenu.TabPages[i].Dispose();
                }
                _mTargetingTabPage = -1;
            }
        }

        /// <summary>
        /// ���^�u�y�[�W�폜�v���_�E�����j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuLTabDel_Click(object sender, EventArgs e)
        {
            if (_mTargetingTabPage > -1)
            {
                int idx = _mTargetingTabPage;
                for (int i = idx - 1; i >= 0; i--)
                {
                    tabMenu.TabPages[i].Dispose();
                }
                _mTargetingTabPage = -1;
            }

        }

        /// <summary>
        /// �I�����j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// �ҏW���j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEditUserMenu_Click(object sender, EventArgs e)
        {

            DataSet dsBackUser = UserMenuInfo.Copy();
            if (usrGrpSetWin.ShowUserMenu(ScreenInfo) == DialogResult.OK)
            {
                MenuConfigration mc = new MenuConfigration();
                mc.SystemSettingInfo = SystemSettingInfo;
                mc.SystemMenuInfo = SystemMenuInfo;
                mc.ScreenInfo = ScreenInfo;
                mc.UserMenu = UserMenuInfo;

                if (WriteSettingFile(mc) != 0)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Main", "�ۑ��G���[", "�ݒ�t�@�C���̍X�V�Ɏ��s���܂����B", "-984");
                }

            }
            else
            {
                UserMenuInfo = SFNETMENU2Utilities.SetUserConfig(dsBackUser);
            }

        }

        /// <summary>
        /// �t�@���N�V�����L�[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Function_KeyDown(object sender, KeyEventArgs e)
        {
            //2009.01.13 sugi add
            return;

            //if (SystemSettingInfo.FuncKeyEnabled == false)
            //{
            //    return;
            //}

            //if ((e.KeyCode < Keys.F1) || (e.KeyCode > Keys.F24))
            //{
            //    return;
            //}

            //int VariableModify = 0;
            //if (SystemSettingInfo.ShiftKeyPriority == true)
            //{
            //    //  �V�t�g�L�[�D��^
            //    if (e.Shift == true)
            //    {
            //        VariableModify = 1;
            //    }
            //    else if (e.Control == true)
            //    {
            //        VariableModify = 2;
            //    }
            //    else if (e.Alt == true)
            //    {
            //        VariableModify = 3;
            //    }
            //}
            //else
            //{
            //    //  Ctrl�L�[�D��^
            //    if (e.Control == true)
            //    {
            //        VariableModify = 1;
            //    }
            //    else if (e.Alt == true)
            //    {
            //        VariableModify = 2;
            //    }
            //    else if (e.Shift == true)
            //    {
            //        VariableModify = 3;
            //    }
            //}

            //// �{�^���̒ǉ�
            //int btnFuncAddNo = 0;
            //if (VariableModify == 1)
            //{
            //    btnFuncAddNo = 12;
            //}
            //else if (VariableModify == 2)
            //{
            //    btnFuncAddNo = 24;
            //}
            //else if (VariableModify == 3)
            //{
            //    btnFuncAddNo = 36;
            //}

            //ListView.SelectedIndexCollection lsc = new ListView.SelectedIndexCollection(lstSubCategory);
            //EventArgs ee = new EventArgs();

            //lsc.Clear();
            //switch (e.KeyCode)
            //{
            //    case Keys.F1:
            //        if (lstSubCategory.Items.Count > (0 + btnFuncAddNo))
            //        {
            //            lsc.Add(0 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F2:
            //        if (lstSubCategory.Items.Count > (1 + btnFuncAddNo))
            //        {
            //            lsc.Add(1 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F3:
            //        if (lstSubCategory.Items.Count > (2 + btnFuncAddNo))
            //        {
            //            lsc.Add(2 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F4:
            //        if (lstSubCategory.Items.Count > (3 + btnFuncAddNo))
            //        {
            //            lsc.Add(3 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F5:
            //        if (lstSubCategory.Items.Count > (4 + btnFuncAddNo))
            //        {
            //            lsc.Add(4 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F6:
            //        if (lstSubCategory.Items.Count > (5 + btnFuncAddNo))
            //        {
            //            lsc.Add(5 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F7:
            //        if (lstSubCategory.Items.Count > (6 + btnFuncAddNo))
            //        {
            //            lsc.Add(6 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F8:
            //        if (lstSubCategory.Items.Count > (7 + btnFuncAddNo))
            //        {
            //            lsc.Add(7 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F9:
            //        if (lstSubCategory.Items.Count > (8 + btnFuncAddNo))
            //        {
            //            lsc.Add(8 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F10:
            //        if (lstSubCategory.Items.Count > (9 + btnFuncAddNo))
            //        {
            //            lsc.Add(9 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F11:
            //        if (lstSubCategory.Items.Count > (10 + btnFuncAddNo))
            //        {
            //            lsc.Add(10 + btnFuncAddNo);
            //        }
            //        break;
            //    case Keys.F12:
            //        if (lstSubCategory.Items.Count > (11 + btnFuncAddNo))
            //        {
            //            lsc.Add(11 + btnFuncAddNo);
            //        }
            //        break;
            //}
            //if (lsc.Count > 0)
            //{
            //    lstSubCategory_Click(lstSubCategory, ee);
            //}


        }

        /// <summary>
        /// �T�u�J�e�S���E���X�g�r���[�L�[�_�E���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSubCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventArgs ee = new EventArgs();
                lstSubCategory_Click(lstSubCategory, ee);
            }
        }

        /// <summary>
        /// �I�v�V�������j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOption_Click(object sender, EventArgs e)
        {
            string[] Products = new string[arProducts.Count];
            for (int i = 0; i < arProducts.Count; i++)
            {
                Products[i] = ((ProductsInfomation)arProducts[i]).ProductID;
            }

            SystemSettingInfomation ssi = new SystemSettingInfomation();
            SystemMenuInfomation smi = new SystemMenuInfomation();
            ScreenInfomation si = new ScreenInfomation();
            smi = SystemMenuInfo.Copy();
            si = ScreenInfo.Copy();
            ssi = SystemSettingInfo.Copy();

            if (usrScrnSetWin.ShowSetting(Products, ref smi, ref si, ref ssi, Path.GetDirectoryName(gcmd[0]), _mNavigationDataDir, _mSystemSettingMode) == DialogResult.OK)
            {
                SystemSettingInfo = ssi;
                ScreenInfo = si;
                SystemMenuInfo = smi;

                ChangeControlProperty();
                System.Windows.Forms.Application.DoEvents();
                MenuConfigration mc = new MenuConfigration();
                mc.SystemSettingInfo = ssi;
                mc.SystemMenuInfo = smi;
                mc.ScreenInfo = si;
                mc.UserMenu = UserMenuInfo;     //  ���̂܂ܕύX�������Z�b�g

                if (WriteSettingFile(mc) != 0)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Main", "�ۑ��G���[", "�ݒ�t�@�C���̍X�V�Ɏ��s���܂����B", "-985");
                }

            }
        }

        /// <summary>
        /// �o�[�W�������j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuVersion_Click(object sender, EventArgs e)
        {
            string sVer = "";
            for (int i = 0; i < arProducts.Count; i++)
            {
                if (((ProductsInfomation)arProducts[i]).ProductName.Length != 0)
                {
                    sVer = "\n" + sVer + ((ProductsInfomation)arProducts[i]).ProductName + "  Version " + ((ProductsInfomation)arProducts[i]).Version;
                }
            }
            SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "", "�o�[�W�������", sVer, "0");
        }

        /// <summary>
        /// �ʓ�������I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //--- ADD 2011/06/29 M.Kubota --->>>
        private void mnuCustHistory_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(_mNavigationDataDir, _CustomHistoryFullPath);
            file = string.Format("/Ext /Prdct:2 /Fnc:1 /Lmt:2 /Mhf:1 file://\"{0}\"", file);

            if (File.Exists("NsBrowser.exe"))
	        {
                string arguments = string.Format("{0} {1} {2}", Program._param[0], Program._param[1], file);
                Process.Start("NsBrowser.exe", arguments);
	        }
        }
        //--- ADD 2011/06/29 M.Kubota ---<<<

        /// <summary>
        /// �������j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSearch_Click(object sender, EventArgs e)
        {
            cmbSearchMenu.Focus();
        }

        /// <summary>
        /// �^�u�y�[�W�N���[�Y���j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCloseTab_Click(object sender, EventArgs e)
        {
            if (tabMenu.TabCount > 0)
            {
                tabMenu.SelectedTab.Dispose();
            }
        }

        /// <summary>
        /// �E�C���h�E�T�C�Y���Z�b�g���j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuResetSize_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            //this.ClientSize = new Size(1016, 734);                    //  2007.01.10  �ǉ�
            this.ClientSize = new Size(cDefWidth, cDefHeight);
            //  �ő�T�C�Y��10.24*768�𒴂�����1024*768�ɐݒ�(Vista�Ή�)  //  2007.01.10  �ǉ�
            if ((this.Size.Width > cDefOuterWidth) || (this.Size.Height > cDefOuterHeight))
            {
                this.SetBounds(0, 0, cDefOuterWidth, cDefOuterHeight, BoundsSpecified.Size);
            }
        }

        /// <summary>
        /// �E�C���h�E���Z�b�g���j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuResetWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(0, 0);
            //this.ClientSize = new Size(1016, 734);                    //  2007.01.10  �ǉ�
            this.ClientSize = new Size(cDefWidth, cDefHeight);
            //  �ő�T�C�Y��10.24*768�𒴂�����1024*768�ɐݒ�(Vista�Ή�)  //  2007.01.10  �ǉ�
            if ((this.Size.Width > cDefOuterWidth) || (this.Size.Height > cDefOuterHeight))
            {
                this.SetBounds(0, 0, cDefOuterWidth, cDefOuterHeight);
            }
        }

        /// <summary>
        /// �^�u�A�C�e���y�C���g�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {

            //StringFormat���쐬
            StringFormat sf = new StringFormat();
            //�c�����ɂ���
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            //�w�i�̕`��
            Brush bk = new SolidBrush(ScreenInfo.ScreenBackColor);
            e.Graphics.FillRectangle(bk, e.Graphics.VisibleClipBounds);

            Brush foreBrush, backBrush;
            for (int i = 0; i < tabMenu.TabPages.Count; i++)
            {
                //�^�u�y�[�W�̃e�L�X�g���擾
                string txt = tabMenu.TabPages[i].Text;
                //  �^�u�y�[�W�ɐF�Â�(�J�e�S���[�̐F���ɗ͎g�p����)            // 2007.01.10  �ǉ�
                Color cFore;
                Color cBack;
                if (ScreenInfo.CategoryButtonBackColor1.GetBrightness() == ScreenInfo.CategoryButtonBackColor2.GetBrightness())
                {
                    cFore = ScreenInfo.CategoryButtonBackColor1;
                    byte crc = (byte)(ScreenInfo.CategoryButtonBackColor1.R * .8);
                    byte cgc = (byte)(ScreenInfo.CategoryButtonBackColor1.G * .8);
                    byte cbc = (byte)(ScreenInfo.CategoryButtonBackColor1.B * .8);
                    cBack = Color.FromArgb(crc, cgc, cbc);
                } 
                else if (ScreenInfo.CategoryButtonBackColor1.GetBrightness() > ScreenInfo.CategoryButtonBackColor2.GetBrightness())
                {
                    cFore = ScreenInfo.CategoryButtonBackColor1;
                    cBack = ScreenInfo.CategoryButtonBackColor2;
                }
                else
                {
                    cFore = ScreenInfo.CategoryButtonBackColor2;
                    cBack = ScreenInfo.CategoryButtonBackColor1;
                }


                if (i == tabMenu.SelectedIndex)
                {
                    foreBrush = new SolidBrush(ScreenInfo.CategorySelectedButtonForeColor);
                    //backBrush = Brushes.WhiteSmoke;                           //  2007.01.10  �ύX
                    backBrush = new SolidBrush(cFore);
                }
                else
                {
                    foreBrush = new SolidBrush(ScreenInfo.CategoryForeColor);
                    //backBrush = new SolidBrush(Color.LightGray);              //  2007.01.10  �ύX
                    backBrush = new SolidBrush(cBack);

                }
                e.Graphics.FillRectangle(backBrush, tabMenu.GetTabRect(i));

                if (tabMenu.TabPages[i].Tag != null)
                {
                    Image img;
                    try
                    {
                        TabMenuInfomation ti = (TabMenuInfomation)tabMenu.TabPages[i].Tag;
                        if (ti.Icon != null)
                        {
                            img = ti.Icon;
                        }
                        else
                        {
                            img = MenuIconResourceManagement.GetImageListImage(ti.IconName, ti.IconIndex);
                        }

                        //e.Graphics.DrawImage(img, new Point(tabMenu.GetTabRect(i).Left + 3, (tabMenu.GetTabRect(i).Height - img.Height) / 2));//2009.01.13 sugi del
                    }
                    catch (Exception)
                    { }
                }
                //Text�̕`��
                //            foreBrush = new SolidBrush(page.ForeColor);
                e.Graphics.DrawString(txt, tabMenu.TabPages[i].Font, foreBrush, tabMenu.GetTabRect(i), sf);
            }

        }

        /// <summary>
        /// �t�H�[���N���[�Y���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFNETMENU2A_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((SystemSettingInfo.SaveLastPosition == true) || (SystemSettingInfo.SaveLastSize == true))
            {
                MenuConfigration mc = new MenuConfigration();

                if (SystemSettingInfo.SaveLastPosition == true)
                {
                    if (WindowState == FormWindowState.Minimized)
                    {
                        SystemSettingInfo.WindowMaximized = false;
                    SystemSettingInfo.LastLocation = new Point(0, 0);
                    }
                    else
                    {
                        SystemSettingInfo.LastLocation = this.Location;
                    }
                }
                if (SystemSettingInfo.SaveLastSize == true)
                {
                    if (WindowState == FormWindowState.Maximized)
                    {
                        SystemSettingInfo.WindowMaximized = true;
                        SystemSettingInfo.LastSize = new Size(cDefWidth, cDefHeight);
                    }
                    else if (WindowState == FormWindowState.Minimized)
                    {
                        SystemSettingInfo.WindowMaximized = false;
                        SystemSettingInfo.LastSize = new Size(cDefWidth, cDefHeight);
                    }
                    else
                    {
                        SystemSettingInfo.WindowMaximized = false;
                        if ((this.Size.Width < 400) && (this.Size.Height < 300))
                        {
                            SystemSettingInfo.LastSize = new Size(cDefWidth, cDefHeight);
                        }
                        else
                        {
                            SystemSettingInfo.LastSize = this.ClientSize;
                        }
                    }
                }
                mc.SystemSettingInfo = SystemSettingInfo;
                mc.SystemMenuInfo = SystemMenuInfo;
                mc.ScreenInfo = ScreenInfo;
                mc.UserMenu = UserMenuInfo;

                if (WriteSettingFile(mc) != 0)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Main", "�ۑ��G���[", "�ݒ�t�@�C���̍X�V�Ɏ��s���܂����B", "-986");
                }
            }

        }

        /// <summary>
        /// �V�X�e�����|�[�g���j���[�I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSystemReport_Click(object sender, EventArgs e)
        {
            SystemReportList srl = new SystemReportList();
            
            //srl.ReportSoftware();                                 //  2006.09.29  �ύX
            string[] prdct = new string[arProducts.Count];
            for (int i = 0; i < arProducts.Count; i++)
            {
                prdct[i] = ((ProductsInfomation)arProducts[i]).ProductID;
            }
            srl.ReportSoftware(prdct);

        }

        /// <summary>
        /// �T�u���j���[�L�[�_�E���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grpSubItem_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
            {
                SubCategoryInfomation sci = (SubCategoryInfomation)((TGroupButton)sender).Tag;
                TabPage tabActive = (TabPage)((TGroupButton)sender).Parent;
                TabMenuInfomation ti = (TabMenuInfomation)tabActive.Tag;
                if (ti.arSubItems.Count <= 1)
                {
                    //  ��Ȃ甲����
                    return;
                }
                //  �^�u�y�[�W��������Ĉړ�
                for (int i = 0; i < ti.arSubItems.Count; i++)
                {
                    if (sender == ti.arSubItems[i])
                    {
                        if (e.KeyCode == Keys.Left)
                        {
                            //  ����
                            if (i == ti.arSubItems.Count - 1)
                            {
                                //  �ō���(��������)
                            }
                            else
                            {
                                //  ���ֈړ�
                                ((TGroupButton)ti.arSubItems[i + 1]).Focus();
                                //  �����ςȂ̂Ŗ{�̑��̏����͂����Ȃ�
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            //  �E��
                            if (i == 0)
                            {
                                //  �ŉE(��������)
                            }
                            else
                            {
                                //  �E�ֈړ�
                                ((TGroupButton)ti.arSubItems[i - 1]).Focus();
                                //  �����ςȂ̂Ŗ{�̑��̏����͂����Ȃ�
                                e.Handled = true;
                            }
                        }
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// �I���{�^���I���������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //----------------------------------------------------------------------------------------------
        //  ���\�b�h�Q
        //----------------------------------------------------------------------------------------------

        /// <summary>
        /// �V�X�e���e�[�}�Ǎ�����
        /// </summary>
        /// <returns>�V�X�e���e�[�}�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       :�V�X�e���e�[�}�Ǎ�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private ScreenThemeInfomation ReadSystemTheme()
        {
            ScreenThemeInfomation sti;
            try
            {

                BinaryFormatter formatter = new BinaryFormatter();
                FileEncryptgraphy fe = new FileEncryptgraphy(cThemeKey1 + cThemeKey2 + cThemeKey3 + cThemeKey4 + cThemeKey5);

                MemoryStream ms = fe.DecryptFile(Path.Combine(_mNavigationDataDir, SFNETMENU2SettingInfomation.ThemeBinary));
                if (ms == null)
                {
                    return null;
                }

                sti = (ScreenThemeInfomation)formatter.Deserialize(ms);

                return sti;

            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// �T�u���j���[�^�u�쐬����
        /// </summary>
        /// <param name="ci">�J�e�S�����</param>
        /// <returns>�쐬�^�u�y�[�W</returns>
        /// <remarks>
        /// <br>Note       :�T�u���j���[�^�u�쐬</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        [MTAThread]
        public TabPage CreateTabMenubPage(CategoryInfomation ci)
        {

            TabPage tabMenuPage = new TabPage();
            tabMenu.TabPages.Add(tabMenuPage);
            tabMenuPage.BackColor = ScreenInfo.TabPageBackColor;
//            tabMenuPage.AutoScroll = true;
            tabMenuPage.BackgroundImage = ScreenInfo.TabPageBackImage;
            tabMenuPage.BackgroundImageLayout = ScreenInfo.TabPageBackImageLayout;
            tabMenuPage.Name = "tabMenuPage" + ((int)(++_mSubMenuTabCount)).ToString();
            tabMenuPage.Text = "�@ " + ci.Name;
            tabMenuPage.Margin  = new Padding(0);                               //  2007.01.10  �ǉ�
            tabMenuPage.Padding = new Padding(0);                               //  2007.01.10  �ǉ�
            TabMenuInfomation ti = new TabMenuInfomation(ci.CategoryID);
            ti.SubMenuItemMargin = _mSubMenuItemMargin;
            ti.SubMenuItemWidth1 = _mSubMenuItemWidth1;
            ti.SubMenuItemWidth2 = _mSubMenuItemWidth2;
            ti.SubMenuItemMaxWidth1 = _mSubMenuItemMaxWidth1;
            ti.SubMenuItemMaxWidth2 = _mSubMenuItemMaxWidth2;
            ti.SubMenuItemDefCount1 = _mSubMenuItemDefCount1;
            ti.SubMenuItemDefCount2 = _mSubMenuItemDefCount2;
            ti.SubMenuItemMaxItemFig1 = _mSubMenuItemMaxItemFig1;
            ti.SubMenuItemMaxItemFig2 = _mSubMenuItemMaxItemFig2;
            ti.SubMenuItemMaxItemFig3 = _mSubMenuItemMaxItemFig3;
            ti.IconName = ci.IconName;
            ti.IconIndex =ci.IconIndex;
            ti.Icon = ci.Icon;
            ti.NeedRefresh = false;
            _mtabpageSize = tabMenuPage.ClientSize;
            tabMenuPage.Tag = ti;

            if (SystemSettingInfo.TabAutoDelete == true)
            {
                int i = 0;
                int MaxWidth = 0;
                while (true)
                {
                    if (i >= tabMenu.TabCount)
                    {
                        break;
                    }
                    MaxWidth = MaxWidth + tabMenu.GetTabRect(i).Width;
                    if (MaxWidth > tabMenu.ClientSize.Width)
                    {
                        int DelCount = tabMenu.TabCount - i;
                        for (int j = DelCount - 1; j >= 0; j--)
                        {
                            try
                            {
                                tabMenu.TabPages[j].Dispose();
                                System.Windows.Forms.Application.DoEvents();
                            }
                            catch
                            { }
                        }
                        i = 0;
                        MaxWidth = 0;
                        continue;
                    }
                    i++;
                }
            }

             return tabMenuPage;

        }

        /// <summary>
        /// �����T�u���j���[�^�u�쐬����
        /// </summary>
        /// <param name="SearchString">����������</param>
        /// <returns>�쐬�^�u�y�[�W</returns>
        /// <remarks>
        /// <br>Note       :�T�u���j���[�^�u�쐬</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        [MTAThread]
        public TabPage CreateTabSearchMenubPage(string SearchString)
        {

            for (int i = 0; i < tabMenu.TabCount; i++)
            {
                if (tabMenu.TabPages[i].Name == "tabSearchMenuPage")
                {
                    return tabMenu.TabPages[i];
                }
            }

            TabPage tabMenuPage = new TabPage();
            tabMenu.TabPages.Add(tabMenuPage);
            tabMenuPage.BackColor = Color.DarkCyan;
//            tabMenuPage.AutoScroll = true;
            tabMenuPage.BackgroundImage = ScreenInfo.TabPageBackImage;
            tabMenuPage.BackgroundImageLayout = ScreenInfo.TabPageBackImageLayout;
            tabMenuPage.Name = "tabSearchMenuPage";
            tabMenuPage.Text = "   ��������";
            tabMenuPage.Margin = new Padding(0);                               //  2007.01.10  �ǉ�
            tabMenuPage.Padding = new Padding(0);                               //  2007.01.10  �ǉ�
            TabMenuInfomation ti = new TabMenuInfomation(0);
            ti.SubMenuItemMargin = _mSubMenuItemMargin;
            ti.SubMenuItemWidth1 = _mSubMenuItemWidth1;
            ti.SubMenuItemWidth2 = _mSubMenuItemWidth2;
            ti.SubMenuItemMaxWidth1 = _mSubMenuItemMaxWidth1;
            ti.SubMenuItemMaxWidth2 = _mSubMenuItemMaxWidth2;
            ti.SubMenuItemDefCount1 = _mSubMenuItemDefCount1;
            ti.SubMenuItemDefCount2 = _mSubMenuItemDefCount2;
            ti.SubMenuItemMaxItemFig1 = _mSubMenuItemMaxItemFig1;
            ti.SubMenuItemMaxItemFig2 = _mSubMenuItemMaxItemFig2;
            ti.SubMenuItemMaxItemFig3 = _mSubMenuItemMaxItemFig3;
            ti.IconName = "imgToolBar";
            ti.IconIndex = (int)MenuIconResourceManagement.ToolBarImage.Search;
            ti.Icon = MenuIconResourceManagement.GetImageListImage(ti.IconName, ti.IconIndex);
            ti.NeedRefresh = false;
            tabMenuPage.Tag = ti;

            _mtabpageSize = tabMenuPage.ClientSize;

            if (SystemSettingInfo.TabAutoDelete == true)
            {
                int i = 0;
                int MaxWidth = 0;
                while (true)
                {
                    if (i >= tabMenu.TabCount)
                    {
                        break;
                    }
                    MaxWidth = MaxWidth + tabMenu.GetTabRect(i).Width;
                    if (MaxWidth > tabMenu.ClientSize.Width)
                    {
                        int DelCount = tabMenu.TabCount - i;
                        for (int j = DelCount - 1; j >= 0; j--)
                        {
                            try
                            {
                                tabMenu.TabPages[j].Dispose();
                                System.Windows.Forms.Application.DoEvents();
                            }
                            catch
                            { }
                        }
                        i = 0;
                        MaxWidth = 0;
                        continue;
                    }
                    i++;
                }
            }

            return tabMenuPage;

        }

        /// <summary>
        /// �T�u���j���[�O���[�v�{�^���쐬����
        /// </summary>
        /// <param name="MenuTab">�쐬�Ώۃ^�u</param>
        /// <param name="ci">�T�u�J�e�S�����</param>
        /// <param name="DspType">�O���[�v�{�^���\������</param>
        /// <param name="bFocusIn">�t�H�[�J�X�ݒ�L��</param>
        /// <returns>��������(0:����쐬,1:�ǉ�����(���p�s�@�\),3:�ǉ��s��,5:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�T�u���j���[�O���[�v�{�^���쐬</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        [MTAThread]
        public int CreateSubItem(TabPage MenuTab, SubCategoryInfomation ci, int DspType, bool bFocusIn)
        {

            //  �������w��̃T�u���j���[�����p�\���𔻒f���ė��p�s�Ȃ�O���[�v�{�^����\�����Ȃ�
            //if (SystemCheck.CheckSystemPermissionFunction(ci.SystemCode, ci.OptionCode) == 0)         //  2006.09.29  �ύX
            if (SystemCheck.CheckSystemPermissionFunction(ci.SysOpCode) == 0)
            {
                return 1;
            }

            TabMenuInfomation ti = (TabMenuInfomation)MenuTab.Tag;

            //  �C���X�^���X�쐬
            TGroupButton grpSubItem = new TGroupButton();

            grpSubItem.Margin = new Padding(ti.SubMenuItemMargin, 0, ti.SubMenuItemMargin, 0); //  2007.01.10  �ǉ�

            //  �\���������擾                                                               //  2006.09.29  �ǉ� VV
            DescriptionEnumTypes descHeadType = GetDescriptionType(ci.DisplayOption.Trim());

            //  �ݒ�ɍ��킹�ĉ����v�Z
            if (_mSubMenuItemSetType == 1)
            {
                ti.SubMenuItemWidth1 = (MenuTab.ClientSize.Width - (ti.SubMenuItemMargin + (ti.SubMenuItemMargin * ti.SubMenuItemDefCount1))) / ti.SubMenuItemDefCount1;
                ti.SubMenuItemWidth2 = (MenuTab.ClientSize.Width - (ti.SubMenuItemMargin + (ti.SubMenuItemMargin * ti.SubMenuItemDefCount2))) / ti.SubMenuItemDefCount2;
            }

            try
            {
                //  �\���`���ɍ��킹�ď���
                if (DspType == 0)
                {

                    //  �擪�ɍ���
                    int InsSubMenuCnt = 0;
                    int SubMenuCnt = 0;
                    for (int i = ti.arSubItems.Count - 1; i >= 0; i--)
                    {
                        //   �R���g���[�����O���[�v�{�^���Ȃ炸�炷
                        int L = 0;
                        int W = 0;

                        //  �ʒu�E�����擾
                        //                                                                  //  2006.09.29  �폜
                        /*
                        if (ci.DisplayOption.Trim() == "0")
                        {
                            W = ti.SubMenuItemWidth1;
                            InsSubMenuCnt = 1;
                        }
                        else
                        {
                            W = ti.SubMenuItemWidth2;
                            InsSubMenuCnt = 2;
                        }
                        */
                        //                                                                  //  2006.09.29  �ǉ� VV
                        if (descHeadType ==  DescriptionEnumTypes.Normal)
                        {
                            W = ti.SubMenuItemWidth1;
                            InsSubMenuCnt = 1;
                        }
                        else
                        {
                            W = ti.SubMenuItemWidth2;
                            InsSubMenuCnt = 2;
                        }
                        //                                                                  //  2006.09.29  �ǉ� AA
                        if (((TGroupButton)ti.arSubItems[i]).ShowDescription != true)
                        {
                            SubMenuCnt++;// ���
                        }
                        else
                        {
                            SubMenuCnt++;// ���
                            SubMenuCnt++;
                        }

                        L = ((TGroupButton)ti.arSubItems[i]).Left + ti.SubMenuItemMargin + W;

                        //  �����A���ɒǉ�����P�ƍ��킹�āA�g�����𒴂��Ă��������(���D�惂�[�h�̂ݍ���̓T�|�[�g)
                        if (SubMenuCnt + InsSubMenuCnt > ti.SubMenuItemDefCount1)
                        {
                            ((TGroupButton)ti.arSubItems[i]).Tag = null;
                        }
                        else
                        {
                            ((TGroupButton)ti.arSubItems[i]).Left = L;
                        }
                    }
                    //  ��O�̏�����Tag���k���ɂ����R���g���[��������
                    //  �O���[�v�{�^������Tag���k���Ȃ����
                    for (int k = ti.arSubItems.Count - 1; k >= 0; k--)
                    {
                        if (((TGroupButton)ti.arSubItems[k]).Tag == null)
                        {
                            ((TGroupButton)ti.arSubItems[k]).Dispose();
                            ti.arSubItems.RemoveAt(k);
                            ti.SubMenuItemCount--;
                        }

                    }
                    //  �擪�ɒǉ�
                    grpSubItem.Name = "SubItem" + ((int)(ti.SubMenuItemCount + 1)).ToString();
                    //                                                                  //  2006.09.29  �폜
                    /*
                    if (ci.DisplayOption.Trim() == "0")
                    {
                        grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                    }
                    else
                    {
                        grpSubItem.ShowDescription = true;
                        grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                    }
                    */
                    //                                                                   // 2006.09.29  �ǉ� VV
                    if (descHeadType == DescriptionEnumTypes.Normal)
                    {
                        grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                    }
                    else
                    {
                        grpSubItem.ShowDescription = true;
                        grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                    }
                    //                                                                   // 2006.09.29  �ǉ� AA
                    ti.arSubItems.Add(grpSubItem);

                }
                else
                {
                    //  1�Ȃ�Ō����Add
                    int XOffset = 0;
                    //  �悸�͕\���J�n�ʒu��c������
                    for (int i = 0; i < MenuTab.Controls.Count; i++)
                    {
                        //  �O���[�v�{�^���Ȃ�
                        if (MenuTab.Controls[i].GetType() == typeof(TGroupButton))
                        {
                            if (MenuTab.Controls[i].Left + MenuTab.Controls[i].Width > XOffset)
                            {
                                XOffset = MenuTab.Controls[i].Left + MenuTab.Controls[i].Width;
                            }
                        }

                    }

                    //  �����A�\���\�͈͊O�ɏo��Ȃ璆�~
                    //                                                                      //  2006.09.29  �ύX
                    /*
                    if ((XOffset > tabMenu.ClientSize.Width) ||
                        ((ci.DisplayOption.Trim() == "0") && ((XOffset + ti.SubMenuItemWidth1) > tabMenu.ClientSize.Width)) ||
                        ((ci.DisplayOption.Trim() != "0") && ((XOffset + ti.SubMenuItemWidth2) > tabMenu.ClientSize.Width)))
                    {
                        return 3;
                    }
                    */
                    if ((XOffset > tabMenu.ClientSize.Width) ||
                        ((descHeadType ==  DescriptionEnumTypes.Normal) && ((XOffset + ti.SubMenuItemWidth1) > tabMenu.ClientSize.Width)) ||
                        ((descHeadType !=  DescriptionEnumTypes.Normal) && ((XOffset + ti.SubMenuItemWidth2) > tabMenu.ClientSize.Width)))
                    {
                        return 3;
                    }

                    //  �Ō���ɒǉ�
                    grpSubItem.Name = "SubItem" + DspType.ToString();
                    //                                                                      //  2006.09.29  �ύX
                    /*
                    if (ci.DisplayOption.Trim() == "0")
                    {
                        grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                    }
                    else
                    {
                        grpSubItem.ShowDescription = true;
                        grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                    }
                    */
                    if (descHeadType ==  DescriptionEnumTypes.Normal)
                    {
                        grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                    }
                    else
                    {
                        grpSubItem.ShowDescription = true;
                        grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                    }
                    ti.arSubItems.Insert(0, grpSubItem);
                }

                //  �ڍׂȐݒ���s��
                grpSubItem.Parent = MenuTab;
                grpSubItem.EnableEnterKeyClick = true;
                grpSubItem.EnableSpaceKeyClick = true;
                if (SystemSettingInfo.NumKeyEnabled == true)
                {
                    grpSubItem.EnableNumKeyClick = true;
                }
                else
                {
                    grpSubItem.EnableNumKeyClick = false;
                }
                grpSubItem.EnableFuncKeyClick = false;
                grpSubItem.ShiftKeyPriority = SystemSettingInfo.ShiftKeyPriority;
                grpSubItem.GroupButtonCursor = Cursors.Hand;

                grpSubItem.BackColor = ScreenInfo.SubMenuBackColor1;
                grpSubItem.BackColor2 = ScreenInfo.SubMenuBackColor2;
                grpSubItem.BorderStyle = BorderStyle.FixedSingle;
                int MaixItemFig;
                //                                                                          //  2006.09.29  �폜
                /*
                if (ci.DisplayOption.Trim() == "0")
                {
                    grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    MaixItemFig = ti.SubMenuItemMaxItemFig1;
                }
                else if (ci.DisplayOption.Trim() == "1")
                {
                    grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    MaixItemFig = ti.SubMenuItemMaxItemFig2;
                }
                else
                {
                    grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    MaixItemFig = ti.SubMenuItemMaxItemFig3;
                }
                */
                //  �ڍו\���^�C�v�����āA�ݒ���e�𕪂���                                         //  2006.09.29  �ǉ�  VV
                if (descHeadType == DescriptionEnumTypes.Normal)
                {
                    grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    MaixItemFig = ti.SubMenuItemMaxItemFig1;
                }
                else if ((descHeadType == DescriptionEnumTypes.Std5Lines) || (descHeadType == DescriptionEnumTypes.Std7Lines))
                {
                    grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));//2009.01.13 sugi chg
                    MaixItemFig = ti.SubMenuItemMaxItemFig2;
                }
                else
                {
                    grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    MaixItemFig = ti.SubMenuItemMaxItemFig3;
                }
                //                                                                              //  2006.09.29  �ǉ� AA
                grpSubItem.ForeColor = ScreenInfo.SubMenuForeColor;
                grpSubItem.GradientMode = ScreenInfo.SubMenuGradiationMode;
                grpSubItem.GroupButtonDepth = 1;
                grpSubItem.GroupButtonMargin = 3;
                grpSubItem.GroupButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                grpSubItem.GroupButtonTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                grpSubItem.HeaderBackColor1 = ScreenInfo.SubMenuHeaderBackColor1;
                grpSubItem.HeaderBackColor2 = ScreenInfo.SubMenuHeaderBackColor2;
                grpSubItem.HeaderFont = new System.Drawing.Font("�l�r �S�V�b�N", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                grpSubItem.HeaderForeColor = ScreenInfo.SubMenuHeaderForeColor;
                grpSubItem.HeaderGradientMode = ScreenInfo.SubMenuHeaderGradiationMode;
                grpSubItem.HeaderHeight = 36;
                grpSubItem.HeaderImageList = MenuIconResourceManagement.GetImageList(ti.IconName);
                //grpSubItem.HeaderImageIndex = ci.IconIndex; //2009.01.13 sugi del
                grpSubItem.HeaderText = ci.Name;
                grpSubItem.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                grpSubItem.HeaderActiveForeColor = ScreenInfo.SubMenuHeaderActiveForeColor;
                grpSubItem.ShowActivePanel = true;
                //if (ci.DisplayOption.Trim() != "0")                                           //  2006.09.29  �ύX
                if (descHeadType !=  DescriptionEnumTypes.Normal)
                {
                    //grpSubItem.DescDivideRatio = 55;
                    grpSubItem.DescDivideRatio = 50;//2009.01.13 sugi chg
                    //grpSubItem.DescFont = new System.Drawing.Font("�l�r �S�V�b�N", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));      //  2006.09.29  �ύX
                    if ((descHeadType == DescriptionEnumTypes.Std5Lines) || (descHeadType == DescriptionEnumTypes.Check5Lines))
                    {
                        grpSubItem.DescFont = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    }
                    else
                    {
                        grpSubItem.DescFont = new System.Drawing.Font("�l�r �S�V�b�N", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    }
                    grpSubItem.DescBackColor1 = ScreenInfo.SubMenuDescBackColor1;
                    grpSubItem.DescBackColor2 = ScreenInfo.SubMenuDescBackColor2;
                    grpSubItem.DescForeColor = ScreenInfo.SubMenuDescForeColor;
                    grpSubItem.DescLineColor = ScreenInfo.SubMenuDescLineColor;
                    grpSubItem.DescOuterDepth = 2;
                    grpSubItem.DescTextAlign = ContentAlignment.MiddleLeft;
                    grpSubItem.DescGradientMode = ScreenInfo.SubMenuDescGradientMode;
                }
                grpSubItem.ImageList = MenuIconResourceManagement.GetImageList(ci.IconName);
                grpSubItem.ImeMode = System.Windows.Forms.ImeMode.Off;
                grpSubItem.TabIndex = 0;
                grpSubItem.GroupButtonBackColor1 = ScreenInfo.SubMenuButtonBackColor1;
                grpSubItem.GroupButtonBackColor2 = ScreenInfo.SubMenuButtonBackColor2;
                grpSubItem.GroupButtonGradientMode = ScreenInfo.SubMenuButtonGradiationMode;
                grpSubItem.SelectedButtonForeColor = ScreenInfo.SubMenuSelectedButtonForeColor;
                grpSubItem.SelectedButtonFaceColor1 = ScreenInfo.SubMenuSelectedButtonFaceColor1;
                grpSubItem.SelectedButtonFaceColor2 = ScreenInfo.SubMenuSelectedButtonFaceColor2;
                grpSubItem.BackgroundImage = ScreenInfo.SubMenuBackImage;
                grpSubItem.BackgroundImageLayout = ScreenInfo.SubMenuBackImageLayout;
                grpSubItem.HotTrackingColor = ScreenInfo.SubMenuHotTrackingColor;
                grpSubItem.FocusButtonBorderColor = ScreenInfo.SubMenuFocusButtonBorderColor;
                grpSubItem.ActivePanelBorderColor = ScreenInfo.SubMenuActivePanelBorderColor;
                if (ScreenInfo.FocusBorderBold == true)
                {
                    grpSubItem.FocusDepth = 2;
                    grpSubItem.GroupButtonInnerDepth = 2;
                }
                else
                {
                    grpSubItem.FocusDepth = 1;
                    grpSubItem.GroupButtonInnerDepth = 1;
                }

                SubCategoryInfomation lci = new SubCategoryInfomation();
                lci.CategoryID = ci.CategoryID;
                lci.CategorySubID = ci.CategorySubID;
                lci.No = ci.No;
                lci.DisplayOption = ci.DisplayOption;
                grpSubItem.Tag = lci;
                grpSubItem.GroupButtonClick += new EventHandler<TGroupButton.GroupButtonEventArgs>(grpSubItem_GroupButtonClick);
                grpSubItem.KeyDown += new KeyEventHandler(grpSubItem_KeyDown);

                DataRow[] productItem;
                if (ci.CategoryID != cFncUserMenu)
                {
                    //productItem = SFNETMENU2Utilities.GetProductItem(ci.CategoryID, ci.CategorySubID);        //  2006.09.29  �ύX
                    productItem = SFNETMENU2Utilities.GetProductItem(ci.CategoryID, ci.CategorySubID, 0);
                }
                else
                {
                    productItem = SFNETMENU2Utilities.GetUserItem(ci.CategorySubID);
                }

                // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
                int continueCount = 0;
                int continueHeight = 0;
                // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                for (int i = 0; i < productItem.Length; i++)
                {
                    if (grpSubItem.GroupButtons.Count > MaixItemFig)
                    {
                        break;
                    }

                    // ���]�ƈ��ɂċ@�\�̎g�p�E�s�̊m�F(�T�u�A�C�e��) // 2007.05.16 Add By Y.Ito

                    // �������x�����擾
                    int roleLevel1 = LoginInfoAcquisition.Employee.AuthorityLevel1;
                    int roleLevel2 = LoginInfoAcquisition.Employee.AuthorityLevel2;

                    // ���p�\�������擾(ItemsArray[17]�`ItemsArray[22]�܂ł����p�\����1�`���p�\����6)
                    // �������x��1�̗��p����
                    string enableCondition1 = productItem[i].ItemArray[17].ToString();
                    string enableCondition2 = productItem[i].ItemArray[18].ToString();
                    string enableCondition3 = productItem[i].ItemArray[19].ToString();
                    // �������x��2�̗��p����
                    string enableCondition4 = productItem[i].ItemArray[20].ToString();
                    string enableCondition5 = productItem[i].ItemArray[21].ToString();
                    string enableCondition6 = productItem[i].ItemArray[22].ToString();

                    // ���p�\����������̉��
                    int checkResultsA = -1; // �������x��1�̏���1
                    int checkResultsB = -1; // �������x��1�̏���2
                    int checkResultsC = -1; // �������x��1�̏���3
                    int checkResultsD = -1; // �������x��2�̏���1
                    int checkResultsE = -1; // �������x��2�̏���2
                    int checkResultsF = -1; // �������x��2�̏���3

                    // �������x��1�̗��p�����`�F�b�N
                    if (enableCondition1 != "")
                    {
                        checkResultsA = SystemCheck.CheckUseEnable(enableCondition1, roleLevel1);
                    }

                    if (enableCondition2 != "")
                    {
                        checkResultsB = SystemCheck.CheckUseEnable(enableCondition2, roleLevel1);
                    }

                    if (enableCondition3 != "")
                    {
                        checkResultsC = SystemCheck.CheckUseEnable(enableCondition3, roleLevel1);
                    }

                    // �������x��2�̗��p�����`�F�b�N
                    if (enableCondition4 != "")
                    {
                        checkResultsD = SystemCheck.CheckUseEnable(enableCondition4, roleLevel2);
                    }

                    if (enableCondition5 != "")
                    {
                        checkResultsE = SystemCheck.CheckUseEnable(enableCondition5, roleLevel2);
                    }

                    if (enableCondition6 != "")
                    {
                        checkResultsF = SystemCheck.CheckUseEnable(enableCondition6, roleLevel2);
                    }

                    // ���������������ꍇ�������͏������P�ł��ʂ�ꍇ
                    if ((checkResultsA == -1 && checkResultsB == -1 && checkResultsC == -1 &&
                        checkResultsD == -1 && checkResultsE == -1 && checkResultsF == -1) ||
                        (checkResultsA == 1 || checkResultsB == 1 || checkResultsC == 1 ||
                         checkResultsD == 1 || checkResultsE == 1 || checkResultsF == 1))
                    {

                        GroupButton gb = new GroupButton();
                        if (SystemCheck.CheckSystemPermissionFunction(productItem[i]) != 0)
                        {
                            gb.Enabled = true;
                            gb.Text = productItem[i]["Name"].ToString();
                            //                                                                             //  2006.09.29  �폜
                            /*
                            gb.DescriptionText = productItem[i]["Description"].ToString();                
                            if (ci.DisplayOption.Trim() == "0")
                            {
                                gb.Size = new Size(gb.Size.Width, 36);
                            }
                            else if (ci.DisplayOption.Trim() == "1")
                            {
                                gb.Size = new Size(gb.Size.Width, 80);
                            }
                            else
                            {
                                gb.Size = new Size(gb.Size.Width, 55);
                            }
                            */
                            //  �ڍו\���^�C�v�����āA�ݒ���e�𕪂���                                         //  2006.09.29  �ǉ�  VV
                            if ((descHeadType == SFNETMENU2A.DescriptionEnumTypes.Check5Lines) || (descHeadType == DescriptionEnumTypes.Check7Lines))
                            {
                                gb.DescType = GroupButton.DescriptionEnumTypes.AutoMulti;
                                DataRow[] productDetItem = SFNETMENU2Utilities.GetProductItem((int)productItem[i]["CategoryID"], (int)productItem[i]["CategorySubID"], (int)productItem[i]["ItemID"], 1);
                                StringBuilder DescText = new StringBuilder();
                                for (int j = 0; j < productDetItem.Length; j++)
                                {
                                    if (SystemCheck.CheckSystemPermissionFunction(productDetItem[j]["SysOpCode"].ToString()) != 0)
                                    {
                                        DescText.Append(productDetItem[j]["Name"].ToString());
                                        if (j != (productDetItem.Length - 1))
                                        {
                                            DescText.Append("\n");
                                        }
                                    }
                                }
                                gb.DescriptionText = DescText.ToString();
                            }
                            else
                            {
                                gb.DescType = GroupButton.DescriptionEnumTypes.Simple;
                                gb.DescriptionText = productItem[i]["Description"].ToString();
                            }
                            if (descHeadType == DescriptionEnumTypes.Normal)
                            {
                                gb.Size = new Size(gb.Size.Width, 42);//2009.01.13 sugi chg 36 -> 40
                            }
                            else if ((descHeadType == DescriptionEnumTypes.Check7Lines) || (descHeadType == DescriptionEnumTypes.Std7Lines))
                            {
                                gb.Size = new Size(gb.Size.Width, 80);
                            }
                            else
                            {
                                gb.Size = new Size(gb.Size.Width, 55);
                            }
                            //                                                                          //  2006.09.29  �ǉ�  AA
                        }
                        else
                        {
                            gb.Enabled = false;
                            gb.Text = "";
                            gb.DescriptionText = "";
                            //                                                                          //  2006.09.29  �폜
                            /*
                            if (ci.DisplayOption.Trim() == "0")
                            {
                                gb.Size = new Size(gb.Size.Width, 36);
                            }
                            else  if (ci.DisplayOption.Trim() == "1")
                            {
                                gb.Size = new Size(gb.Size.Width, 80);
                            }
                            else
                            {
                                gb.Size = new Size(gb.Size.Width, 55);
                            }
                            */
                            //                                                                          //  2006.09.29  �ǉ�
                            if (descHeadType == DescriptionEnumTypes.Normal)
                            {
                                gb.Size = new Size(gb.Size.Width, 42);//2009.01.13 sugi chg 36 -> 40
                            }
                            else if ((descHeadType == DescriptionEnumTypes.Check7Lines) || (descHeadType == DescriptionEnumTypes.Std7Lines))
                            {
                                gb.Size = new Size(gb.Size.Width, 80);
                            }
                            else
                            {
                                gb.Size = new Size(gb.Size.Width, 55);
                            }


                        }
                        //                    gb.ImageIndex = (int)productItem[i]["IconIndex"];
                        //gb.ImageIndex = i;//2009.01.13 sugi del
                        MenuItemInfomation mii = new MenuItemInfomation();
                        mii.CategoryID = (int)productItem[i]["CategoryID"];
                        mii.CategorySubID = (int)productItem[i]["CategorySubID"];
                        mii.ItemID = (int)productItem[i]["ItemID"];
                        mii.No = (int)productItem[i]["No"];
                        mii.Pgid = productItem[i]["Pgid"].ToString();
                        mii.Name = productItem[i]["Name"].ToString();
                        mii.Parameter = productItem[i]["Parameter"].ToString();
                        mii.Description = productItem[i]["Description"].ToString();
                        //mii.IconType = productItem[i]["IconType"].ToString();             //  2006.09.29  �폜
                        //                    mii.IconIndex = (int)productItem[i]["IconIndex"];
                        mii.IconIndex = i;
                        mii.IconName = productItem[i]["IconName"].ToString();
                        //mii.SystemCode = productItem[i]["SystemCode"].ToString();         //  2006.09.29  �폜
                        //mii.OptionCode = productItem[i]["OptionCode"].ToString();         //  2006.09.29  �폜
                        mii.SysOpCode = productItem[i]["SysOpCode"].ToString();             //  2006.09.29  �ǉ�
                        mii.DisplayOption = productItem[i]["DisplayOption"].ToString();
                        mii.SearchKeyWord = productItem[i]["SearchKeyWord"].ToString();
                        mii.Rank = (int)productItem[i]["Rank"];
                        //if (mii.IconType.IndexOf("res", StringComparison.OrdinalIgnoreCase) > -1) //  2006.09.29   �ύX
                        //{
                        //gb.ImageIndex = mii.IconIndex;
                        //}
                        //gb.ImageIndex = mii.IconIndex;//2009.01.13 sugi del
                        gb.Tag = mii;
                        // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        // 2013/02/25 ADD ���� 2013/03/06�z�M�V�X�e���e�X�g��QNo126 ---------->>>>>>>>>>>>>>>>>>>>>>
                        // ���C�ɓ���̓A�C�e�����x���œo�^����邪�A���[���ݒ�̓J�e�S����T�u�J�e�S�����x�����o�^�����B
                        // �Ȃ̂ŁA���C�ɓ���z���̃A�C�e���̏ꍇ�́A�J�e�S����T�u�J�e�S�����x���ł��`�F�b�N����B
                        if (ci.CategoryID == -101)
                        {
                            string categorySubItem1 = mii.CategoryID.ToString().PadLeft(4, '0') + "00000000";
                            string categorySubItem2 = mii.CategoryID.ToString().PadLeft(4, '0') + mii.CategorySubID.ToString().PadLeft(6, '0') + "00";
                            string categorySubItem3 = mii.CategoryID.ToString().PadLeft(4, '0') + mii.CategorySubID.ToString().PadLeft(6, '0') + mii.ItemID.ToString().PadLeft(2, '0');
                            if (_categorySubItem.Contains(categorySubItem1) ||
                                _categorySubItem.Contains(categorySubItem2) ||
                                _categorySubItem.Contains(categorySubItem3))
                            {
                                continueCount++;
                                continueHeight = gb.Size.Height;
                                continue;
                            }
                        }
                        else
                        {
                        // 2013/02/25 ADD ���� 2013/03/06�z�M�V�X�e���e�X�g��QNo126 ----------<<<<<<<<<<<<<<<<<<<<<<
                            string categorySubItem = ci.CategoryID.ToString().PadLeft(4, '0') + mii.CategorySubID.ToString().PadLeft(6, '0') + mii.ItemID.ToString().PadLeft(2, '0');
                            if (_categorySubItem.Contains(categorySubItem))
                            {
                                continueCount++;
                                continueHeight = gb.Size.Height;
                                continue;
                            }
                        // 2013/02/25 ADD ���� 2013/03/06�z�M�V�X�e���e�X�g��QNo126 ---------->>>>>>>>>>>>>>>>>>>>>>
                        }
                        // 2013/02/25 ADD ���� 2013/03/06�z�M�V�X�e���e�X�g��QNo126 ----------<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        grpSubItem.GroupButtons.Add(gb);
                    }
                }
                // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (continueCount > 0)
                {
                    // �󔒃{�^����ǉ�����
                    for (int i = 0; i < continueCount; i++)
                    {
                        GroupButton gb = new GroupButton();
                        gb.Enabled = false;
                        gb.Text = "";
                        gb.DescriptionText = "";
                        gb.Size = new Size(gb.Size.Width, continueHeight);
                        grpSubItem.GroupButtons.Add(gb);
                    }
                }
                // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<


                ti.SubMenuItemCount++;

                System.Windows.Forms.Application.DoEvents();

                if (bFocusIn == true)
                {
                    grpSubItem.Focus();
                    grpSubItem.Select();
                    System.Windows.Forms.Application.DoEvents();
                }

                return 0;
            }
            catch (Exception)
            {
                return 5;
            }

         
        }

        /// <summary>
        /// �������ʃT�u���j���[�O���[�v�{�^���쐬����
        /// </summary>
        /// <param name="MenuTab">�쐬�Ώۃ^�u</param>
        /// <param name="ci">�T�u�J�e�S�����</param>
        /// <param name="DspType">�O���[�v�{�^���\������</param>
        /// <param name="SearchString">����������</param>
        /// <param name="bFocusIn">�t�H�[�J�X�ݒ�L��</param>
        /// <returns>��������(0:����쐬,1:�ǉ�����(���p�s�@�\),3:�ǉ��s��,5:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�T�u���j���[�O���[�v�{�^���쐬</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        [MTAThread]
        public int CreateSearchItem(TabPage MenuTab, SubCategoryInfomation ci, int DspType, string SearchString, bool bFocusIn, out int SearchCount, out int DispCount)
        {

            //  ���j���[���ו��\��

            TabMenuInfomation ti = (TabMenuInfomation)MenuTab.Tag;

            //  �C���X�^���X�쐬
            TGroupButton grpSubItem = new TGroupButton();

            grpSubItem.Margin = new Padding(ti.SubMenuItemMargin, 0, ti.SubMenuItemMargin, 0); //  2007.01.10  �ǉ�

            //  �\���������擾                                                               //  2006.09.29  �ǉ� VV
            DescriptionEnumTypes descHeadType = GetDescriptionType(ci.DisplayOption.Trim());

            //  �ݒ�ɍ��킹�ĉ����v�Z
            if (_mSubMenuItemSetType == 1)
            {
                ti.SubMenuItemWidth1 = (MenuTab.ClientSize.Width - (ti.SubMenuItemMargin + (ti.SubMenuItemMargin * ti.SubMenuItemDefCount1))) / ti.SubMenuItemDefCount1;
                ti.SubMenuItemWidth2 = (MenuTab.ClientSize.Width - (ti.SubMenuItemMargin + (ti.SubMenuItemMargin * ti.SubMenuItemDefCount2))) / ti.SubMenuItemDefCount2;
            }


            SearchCount = 0;
            DispCount = 0;

            //  �\���`���ɍ��킹�ď���
            if (DspType == 0)
            {
                //int InsSubMenuCnt = 0;
                int SubMenuCnt = 0;
                for (int i = ti.arSubItems.Count - 1; i >= 0; i--)
                {
                    //   �R���g���[�����O���[�v�{�^���Ȃ炸�炷
                    int L = 0;
                    int W = 0;

                    //  �ʒu�E�����擾
                    //                                                                  //  2006.09.29  �폜
                    /*
                    if (ci.DisplayOption.Trim() == "0")
                    {
                        W = ti.SubMenuItemWidth1;
                        InsSubMenuCnt = 1;
                    }
                    else
                    {
                        W = ti.SubMenuItemWidth2;
                        InsSubMenuCnt = 2;
                    }
                    */
                    //                                                                  //  2006.09.29  �ǉ� VV
                    if (descHeadType == DescriptionEnumTypes.Normal)
                    {
                        W = ti.SubMenuItemWidth1;
                        //InsSubMenuCnt = 1;
                    }
                    else
                    {
                        W = ti.SubMenuItemWidth2;
                        //InsSubMenuCnt = 2;
                    }
                    //                                                                  //  2006.09.29  �ǉ� AA
                    if (((TGroupButton)ti.arSubItems[i]).ShowDescription != true)
                    {
                        SubMenuCnt++;// ���
                    }
                    else
                    {
                        SubMenuCnt++;// ���
                        SubMenuCnt++;
                    }

                    L = ((TGroupButton)ti.arSubItems[i]).Left + ti.SubMenuItemMargin + W;

                    //  �����A���ɒǉ�����P�ƍ��킹�āA�g�����𒴂��Ă��������(���D�惂�[�h�̂ݍ���̓T�|�[�g)
                    if (SubMenuCnt + 1 > ti.SubMenuItemDefCount1)
                    {
                        ((TGroupButton)ti.arSubItems[i]).Tag = null;
                    }
                    else
                    {
                        ((TGroupButton)ti.arSubItems[i]).Left = L;
                    }
                }
                //  ��O�̏�����Tag���k���ɂ����R���g���[��������
                //  �O���[�v�{�^������Tag���k���Ȃ����
                for (int k = ti.arSubItems.Count - 1; k >= 0; k--)
                {
                    if (((TGroupButton)ti.arSubItems[k]).Tag == null)
                    {
                        ((TGroupButton)ti.arSubItems[k]).Dispose();
                        ti.arSubItems.RemoveAt(k);
                        ti.SubMenuItemCount--;
                    }

                }
                //  �擪�ɒǉ�
                grpSubItem.Name = "SubItem" + ((int)(ti.SubMenuItemCount + 1)).ToString();
                //                                                                  //  2006.09.29  �폜
                /*
                if (ci.DisplayOption.Trim() == "0")
                {
                    grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                }
                else
                {
                    grpSubItem.ShowDescription = true;
                    grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                }
                */
                //                                                                   // 2006.09.29  �ǉ� VV
                if (descHeadType == DescriptionEnumTypes.Normal)
                {
                    grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                }
                else
                {
                    grpSubItem.ShowDescription = true;
                    grpSubItem.SetBounds(ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                }
                //                                                                   // 2006.09.29  �ǉ� AA
                ti.arSubItems.Add(grpSubItem);
            }
            else
            {
                //  1�Ȃ�Ō����Add
                int XOffset = 0;
                //  �悸�͕\���J�n�ʒu��c������
                for (int i = 0; i < MenuTab.Controls.Count; i++)
                {
                    //  �O���[�v�{�^���Ȃ�
                    if (MenuTab.Controls[i].GetType() == typeof(TGroupButton))
                    {
                        if (MenuTab.Controls[i].Left + MenuTab.Controls[i].Width > XOffset)
                        {
                            XOffset = MenuTab.Controls[i].Left + MenuTab.Controls[i].Width;
                        }
                    }

                }

                //  �����A�\���\�͈͊O�ɏo��Ȃ璆�~
                //                                                                      //  2006.09.29  �ύX
                /*
                if ((XOffset > tabMenu.ClientSize.Width) ||
                    ((ci.DisplayOption.Trim() == "0") && ((XOffset + ti.SubMenuItemWidth1) > tabMenu.ClientSize.Width)) ||
                    ((ci.DisplayOption.Trim() != "0") && ((XOffset + ti.SubMenuItemWidth2) > tabMenu.ClientSize.Width)))
                {
                    return 3;
                }
                */
                if ((XOffset > tabMenu.ClientSize.Width) ||
                    ((descHeadType == DescriptionEnumTypes.Normal) && ((XOffset + ti.SubMenuItemWidth1) > tabMenu.ClientSize.Width)) ||
                    ((descHeadType != DescriptionEnumTypes.Normal) && ((XOffset + ti.SubMenuItemWidth2) > tabMenu.ClientSize.Width)))
                {
                    return 3;
                }

                //  �Ō���ɒǉ�
                grpSubItem.Name = "SubItem" + DspType.ToString();
                //                                                                      //  2006.09.29  �ύX
                /*
                if (ci.DisplayOption.Trim() == "0")
                {
                    grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                }
                else
                {
                    grpSubItem.ShowDescription = true;
                    grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                }
                */
                if (descHeadType == DescriptionEnumTypes.Normal)
                {
                    grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth1, MenuTab.ClientSize.Height);
                }
                else
                {
                    grpSubItem.ShowDescription = true;
                    grpSubItem.SetBounds(XOffset + ti.SubMenuItemMargin, 0, ti.SubMenuItemWidth2, MenuTab.ClientSize.Height);
                }
                ti.arSubItems.Insert(0, grpSubItem);
            }

            //  �ڍׂȐݒ���s��
            grpSubItem.Parent = MenuTab;
            grpSubItem.EnableEnterKeyClick = true;
            grpSubItem.EnableSpaceKeyClick = true;
            grpSubItem.EnableNumKeyClick = false;
            grpSubItem.EnableFuncKeyClick = false;
            grpSubItem.ShiftKeyPriority = SystemSettingInfo.ShiftKeyPriority;
            grpSubItem.GroupButtonCursor = Cursors.Hand;
            grpSubItem.BackColor = System.Drawing.Color.PowderBlue;
            grpSubItem.BackColor2 = System.Drawing.Color.LightSteelBlue;
            grpSubItem.BorderStyle = BorderStyle.FixedSingle;
            grpSubItem.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            grpSubItem.ForeColor = System.Drawing.Color.White;
            grpSubItem.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            grpSubItem.GroupButtonDepth = 1;
            grpSubItem.GroupButtonMargin = 3;
            grpSubItem.GroupButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            grpSubItem.GroupButtonTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            grpSubItem.HeaderBackColor1 = System.Drawing.Color.BlanchedAlmond;
            grpSubItem.HeaderBackColor2 = System.Drawing.Color.LightGray;
            grpSubItem.HeaderFont = new System.Drawing.Font("�l�r �S�V�b�N", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            grpSubItem.HeaderForeColor = System.Drawing.Color.DarkGoldenrod;
            grpSubItem.HeaderGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            grpSubItem.HeaderHeight = 38;
            grpSubItem.HeaderImageList = MenuIconResourceManagement.GetImageList(ci.IconName);
            grpSubItem.HeaderImageIndex = ci.IconIndex;
            grpSubItem.HeaderText = ci.Name + "\n[ " + SearchString + " ]";    //  �ύX�ӏ�
            grpSubItem.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            grpSubItem.HeaderActiveForeColor = Color.Red;
            grpSubItem.ShowActivePanel = true;
            grpSubItem.HeaderActiveForeColor = Color.Red;
            //if (ci.DisplayOption.Trim() != "0")                                           //  2006.09.29  �ύX
            if (descHeadType != DescriptionEnumTypes.Normal)
            {
                //grpSubItem.DescDivideRatio = 55;
                grpSubItem.DescDivideRatio = 58;
                //grpSubItem.DescFont = new System.Drawing.Font("�l�r �S�V�b�N", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));  //  2006.09.29  �ύX
                if ((descHeadType == DescriptionEnumTypes.Std5Lines) || (descHeadType == DescriptionEnumTypes.Check5Lines))
                {
                    grpSubItem.DescFont = new System.Drawing.Font("�l�r �S�V�b�N", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                }
                else
                {
                    grpSubItem.DescFont = new System.Drawing.Font("�l�r �S�V�b�N", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                }
                grpSubItem.DescBackColor1 = Color.WhiteSmoke;
                grpSubItem.DescBackColor2 = Color.White;
                grpSubItem.DescForeColor = Color.Gray;
                grpSubItem.DescLineColor = Color.MediumSlateBlue;
                grpSubItem.DescOuterDepth = 2;
                grpSubItem.DescTextAlign = ContentAlignment.MiddleLeft;
                grpSubItem.DescGradientMode = LinearGradientMode.BackwardDiagonal;
            }
            grpSubItem.ImageList = MenuIconResourceManagement.GetImageList(ci.IconName);
            grpSubItem.ImeMode = System.Windows.Forms.ImeMode.Off;
            grpSubItem.TabIndex = 0;
            grpSubItem.GroupButtonBackColor1 = Color.LightSlateGray;
            grpSubItem.GroupButtonBackColor2 = Color.DarkSlateGray;
            grpSubItem.SelectedButtonForeColor = Color.Red;
            grpSubItem.SelectedButtonFaceColor1 = Color.LightPink;
            grpSubItem.SelectedButtonFaceColor2 = Color.LightPink;
            grpSubItem.HotTrackingColor = Color.Orange;
            grpSubItem.FocusButtonBorderColor = Color.Black;
            grpSubItem.ActivePanelBorderColor = Color.Red;
            if (ScreenInfo.FocusBorderBold == true)
            {
                grpSubItem.FocusDepth = 2;
                grpSubItem.GroupButtonInnerDepth = 2;
            }
            else
            {
                grpSubItem.FocusDepth = 1;
                grpSubItem.GroupButtonInnerDepth = 1;
            }

            SubCategoryInfomation lci = new SubCategoryInfomation();
            lci.CategoryID = ci.CategoryID;
            lci.CategorySubID = ci.CategorySubID;
            lci.No = ci.No;
            lci.DisplayOption = "0";
            grpSubItem.Tag = lci;
            grpSubItem.GroupButtonClick += new EventHandler<TGroupButton.GroupButtonEventArgs>(grpSubItem_GroupButtonClick);

            //DataRow[] searchItem = SFNETMENU2Utilities.SearchProductItem(SearchString);           //  2006.09.29  �ύX
            DataRow[] searchItem = SFNETMENU2Utilities.SearchProductItem(SearchString, 0);
            
            SearchCount = searchItem.Length;
            for (int i = 0; i < searchItem.Length; i++)
            {

                //  �@�\�̎g�p�E�s�̊m�F
                //  �J�e�S��
                //DataRow[] CategoryRows = SFNETMENU2Utilities.GetCategory(searchItem[i]["Products"].ToString(), (int)searchItem[i]["CategoryID"], true);   //  2006.09.29  �ύX
                DataRow[] CategoryRows = SFNETMENU2Utilities.GetCategory((int)searchItem[i]["CategoryID"], true);
                if (CategoryRows.Length == 0)
                {
                    continue;
                }
                if (SystemCheck.CheckSystemPermissionFunction(CategoryRows[0]) == 0)
                {
                    continue;
                }
                //  �T�u�J�e�S��
                DataRow[] SubCategoryRows = SFNETMENU2Utilities.GetSubCategory((int)searchItem[i]["CategoryID"], (int)searchItem[i]["CategorySubID"]);
                if (SubCategoryRows.Length == 0)
                {
                    continue;
                }
                if (SystemCheck.CheckSystemPermissionFunction(SubCategoryRows[0]) == 0)
                {
                    continue;
                }
                //  �A�C�e��
                if (SystemCheck.CheckSystemPermissionFunction(searchItem[i]) == 0)
                {
                    continue;
                }
                //  PGID�d���`�F�b�N
                bool bHit = false;
                for (int j = 0; j < grpSubItem.GroupButtons.Count; j++)
                {
                    MenuItemInfomation mit = (MenuItemInfomation)grpSubItem.GroupButtons[j].Tag;
                    if ((searchItem[i]["Pgid"].ToString() == mit.Pgid)
                        && (searchItem[i]["Parameter"].ToString() == mit.Parameter))
                    {
                        bHit = true;
                        break;
                    }
                }
                if (bHit == true)
                {
                    continue;
                }

                // �� �������ʂ��������x�����Q�Ƃ��t�B���^�[��������
                DataRow[] CategoryRow = SFNETMENU2Utilities.GetCategory((int)searchItem[i]["CategoryID"], true);
                DataRow[] SubCategoryRow = SFNETMENU2Utilities.GetSubCategory((int)searchItem[i]["CategoryID"], (int)searchItem[i]["CategorySubID"]);

                bool CategoryCheck = false;
                bool SubCategoryCheck = false;
                bool ProductItemCheck = false;

                if (CategoryRow.Length != 0 && SubCategoryRow.Length != 0)
                {
                    CategoryCheck = SystemCheck.CheckAuthority(CategoryRow[0]);
                    SubCategoryCheck = SystemCheck.CheckAuthority(SubCategoryRow[0]);
                    ProductItemCheck = SystemCheck.CheckAuthority(searchItem[i]);
                }

                // ���Ɍ�����������Ε\���ł��Ȃ�(�J�e�S���A�T�u�J�e�S���A�v���_�N�g�A�C�e���`�F�b�N)
                if (CategoryCheck == false || SubCategoryCheck == false || ProductItemCheck == false)
                {
                    continue;
                }


                //if (ci.DisplayOption.Trim() == "0")                                       //  2006.9.29   �ύX
                if (descHeadType == DescriptionEnumTypes.Normal)
                    {
                    if (grpSubItem.GroupButtons.Count > ti.SubMenuItemMaxItemFig1)
                    {
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Search", "����",  "�ő�\�������𒴂��܂����B���������i�荞�񂾌��������ōēx���s���Ă��������B", "");
                        break;
                    }
                }
                //else if (ci.DisplayOption.Trim() == "1")                                 //  2006.9.29   �ύX
                else if ((descHeadType == DescriptionEnumTypes.Check7Lines) || (descHeadType == DescriptionEnumTypes.Std7Lines))
                {
                    if (grpSubItem.GroupButtons.Count > ti.SubMenuItemMaxItemFig2)
                    {
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Search", "����",  "�ő�\�������𒴂��܂����B���������i�荞�񂾌��������ōēx���s���Ă��������B", "");
                        break;
                    }
                }
                else
                {
                    if (grpSubItem.GroupButtons.Count > ti.SubMenuItemMaxItemFig3)
                    {
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Search", "����",  "�ő�\�������𒴂��܂����B���������i�荞�񂾌��������ōēx���s���Ă��������B", "");
                        break;
                    }
                }

                //  �O���[�v�{�^���쐬
                GroupButton gb = new GroupButton();
                gb.Enabled = true;
                //                gb.ImageIndex = (int)searchItem[i]["IconIndex"];
                gb.ImageIndex = i;
//                gb.Text = "< " + SubCategoryRows[0]["Name"].ToString() + " >\n" + searchItem[i]["Name"].ToString();
                gb.Text = searchItem[i]["Name"].ToString();
                //                                                                             //  2006.09.29  �폜
                /*
                gb.DescriptionText = searchItem[i]["Description"].ToString();
                if (ci.DisplayOption.Trim() == "0")
                {
                    gb.Size = new Size(gb.Size.Width, 36);
                }
                else if (ci.DisplayOption.Trim() == "1")
                {
                    gb.Size = new Size(gb.Size.Width, 80);
                }
                else
                {
                    gb.Size = new Size(gb.Size.Width, 55);
                }
                        */
                //  �ڍו\���^�C�v�����āA�ݒ���e�𕪂���                                         //  2006.09.29  �ǉ�  VV
                if ((descHeadType == SFNETMENU2A.DescriptionEnumTypes.Check5Lines) || (descHeadType == DescriptionEnumTypes.Check7Lines))
                {
                    gb.DescType = GroupButton.DescriptionEnumTypes.AutoMulti;
                    DataRow[] productDetItem = SFNETMENU2Utilities.GetProductItem((int)searchItem[i]["CategoryID"], (int)searchItem[i]["CategorySubID"], (int)searchItem[i]["ItemID"], 1);
                    StringBuilder DescText = new StringBuilder();
                    for (int j = 0; j < productDetItem.Length; j++)
                    {
                        if (SystemCheck.CheckSystemPermissionFunction(productDetItem[j]["SysOpCode"].ToString()) != 0)
                        {
                            DescText.Append(productDetItem[j]["Name"].ToString());
                            if (j != (productDetItem.Length - 1))
                            {
                                DescText.Append("\n");
                            }
                        }
                    }
                    gb.DescriptionText = DescText.ToString();
                }
                else
                {
                    gb.DescType = GroupButton.DescriptionEnumTypes.Simple;
                    gb.DescriptionText = searchItem[i]["Description"].ToString();
                }
                if (descHeadType == DescriptionEnumTypes.Normal)
                {
                    gb.Size = new Size(gb.Size.Width, 36);
                }
                else if ((descHeadType == DescriptionEnumTypes.Check7Lines) || (descHeadType == DescriptionEnumTypes.Std7Lines))
                {
                    gb.Size = new Size(gb.Size.Width, 80);
                }
                else
                {
                    gb.Size = new Size(gb.Size.Width, 55);
                }
                //                                                                          //  2006.09.29  �ǉ�  AA
                MenuItemInfomation mii = new MenuItemInfomation();
                mii.CategoryID = (int)searchItem[i]["CategoryID"];
                mii.CategorySubID = (int)searchItem[i]["CategorySubID"];
                mii.ItemID = (int)searchItem[i]["ItemID"];
                mii.No = (int)searchItem[i]["No"];
                mii.Pgid = searchItem[i]["Pgid"].ToString();
                mii.Name = searchItem[i]["Name"].ToString();
                mii.Parameter = searchItem[i]["Parameter"].ToString();
                mii.Description = searchItem[i]["Description"].ToString();
                //mii.IconType = searchItem[i]["IconType"].ToString();                  //  2006.09.29  �폜
                //                mii.IconIndex = (int)searchItem[i]["IconIndex"];
                mii.IconIndex = i;
                mii.IconName = searchItem[i]["IconName"].ToString();
                //mii.SystemCode = searchItem[i]["SystemCode"].ToString();              //  2006.09.29  �폜
                //mii.OptionCode = searchItem[i]["OptionCode"].ToString();              //  2006.09.29  �폜
                mii.SysOpCode = searchItem[i]["SysOpCode"].ToString();                  //  2006.09.29  �ǉ�
                mii.DisplayOption = searchItem[i]["DisplayOption"].ToString();
                mii.SearchKeyWord = searchItem[i]["SearchKeyWord"].ToString();
                mii.Rank = (int)searchItem[i]["Rank"];
                gb.ImageIndex = 0;
                gb.Tag = mii;
                grpSubItem.GroupButtons.Add(gb);
                DispCount++;
            }

            System.Windows.Forms.Application.DoEvents();

            ti.SubMenuItemCount++;

            if (bFocusIn == true)
            {
                grpSubItem.Focus();
                grpSubItem.Select();
                System.Windows.Forms.Application.DoEvents();
            }

            return 0;


        }

        /// <summary>
        /// �v���O�����N������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="mii">���j���[���</param>
        /// <returns>�N������</returns>
        /// <remarks>
        /// <br>Note       :�v���O�����N��</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int StartProgram(object sender, MenuItemInfomation mii, string AddParam)
        {

            int rtnCd = 0;
            int Merge;// 2008.12.16 sugi add
            int stat;

            _mStatusMessage = "";

            //  �v���O�����N��
            if (mii.Pgid.Trim().Length != 0)
            {
                //  �v���O�����̃`�F�b�N
                if (File.Exists(Path.Combine(Path.GetDirectoryName(gcmd[0]), mii.Pgid)) == false)
                {
                    _mStatusMessage = "�w�肳�ꂽ�v���O���������݂��܂���B";
                    rtnCd = 1;

                }

                //  �L�b�N
                if (rtnCd == 0)
                {
                    // 2008.09.28 sugi -<<
                    //  �p���[���^�}�N����T���Ă���΁A�u��
                    string PgParam = mii.Parameter;
                    //if (PgParam.IndexOf("%$%") > 0)// 2009.03.16 sugi del
                    if (PgParam.IndexOf("%%") > 0)// 2009.03.16 sugi add
                    {
                        try
                        {
                            for (int j = 0; j < gMacroString.Length; j++)
                            {
                                if (PgParam.IndexOf(gMacroString[j]) > 0)
                                {
                                    if (gMacroStringFunc[j] == "WEB")
                                    {
                                        string webPage = PgParam.Substring(PgParam.IndexOf(gMacroString[j]), gMacroString[j].Length);
                                        //webPage = Program.arm.GetAPServiceTargetDomain(webPage.Replace("%$%", ""));// 2009.03.16 sugi del
                                        webPage = Program.arm.GetAPServiceTargetDomain(gMacroStringAp[j]);// 2009.03.16 sugi add
                                        PgParam = PgParam.Replace(gMacroString[j], webPage);
                                    }

                                    // 2009.03.16 sugi -<<
                                    if (gMacroStringFunc[j] == "PRD")
                                    {
                                        string productCode = PgParam.Substring(PgParam.IndexOf(gMacroString[j]), gMacroString[j].Length);
                                        productCode = LoginInfoAcquisition.ProductCode;
                                        PgParam = PgParam.Replace(gMacroString[j], productCode);
                                    }
                                    // 2009.03.16 sugi -<<

                                    // 2009.09.14 Add >>>
                                    if (gMacroStringFunc[j] == "INFCON")
                                    {
                                        string webPage = PgParam.Substring(PgParam.IndexOf(gMacroString[j]), gMacroString[j].Length);
                                        webPage = Program.arm.GetConnectionInfo(gMacroStringAp[j], gMacroStringAp[j]);
                                        PgParam = PgParam.Replace(gMacroString[j], webPage);
                                    }
                                    // 2009.09.14 Add <<<

                                }   
                            }
                            // 2009.03.16 sugi -<<
                            mii.Parameter = PgParam;
                            // 2009.03.16 sugi -<<
                        }
                        catch (Exception er)
                        {
                            _mStatusMessage = er.Message;
                            return�@rtnCd = 8;
                        }
                    }
                    // 2008.12.16 sugi ->>
                    // ��Ƀo�[�W�����`�F�b�N���s��
                    // �T�[�o�[�o�[�W�����`�F�b�N�ŃG���[�ƂȂ�\������B
                    // �������A�G���[�̓Z�L�����e�B�`�F�b�N�̔��f��ɂ���
                    try
                    {
                        string _currentVersion;
                        _VersionCheckAcs.MergeCheck(out stat,out _currentVersion);
                        // -- UPD 2011/10/28 ------------------------>>>
                        //Merge = stat;  
                     
                        //��{�񋟃I�v�V�����ƂQ�֒񋟃I�v�V�������Ȃ��ꍇ�́A�}�[�W�̃`�F�b�N�͍s��Ȃ�
                        //if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-CMN0600") == 0) && (Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM00700") == 0)) // DEL 2013/12/19
                        if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-CMN0600") <= 0) && (Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM00700") <= 0)) // ADD 2013/12/19
                        {
                            Merge = 0;
                        }
                        else
                        {
                            Merge = stat;  
                        }
                        // -- UPD 2011/10/28 ------------------------<<<

                        // 2008.12.16 sugi -<<

                        // 2008.12.16 sugi ->>
                        // �N���\������
                        if (PgParam.IndexOf("#Auth#") >= 0)
                        {
                            if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry(Path.GetFileNameWithoutExtension(mii.Pgid), true))
                            {
                                //_mStatusMessage = "�w�肳�ꂽ�v���O���������݂��܂���B";
                                return rtnCd = -9;
                            }
                            else PgParam = PgParam.Replace("#Auth#", "");
                        }
                        // 2008.12.16 sugi -<<
                        // 2008.12.16 sugi ->>
                        // �N���\������o�[�W�����`�F�b�N
                        if (PgParam.IndexOf("#Merge#") >= 0)
                        {
                            // --- UPD m.suzuki 2012/11/29 ---------->>>>>
                            ////_VersionCheckAcs = new Broadleaf.Application.Controller.VersionCheckAcs();
                            //if (Merge == 2)
                            //{
                            //    _mStatusMessage = "�T�[�o�[�����X�V����Ă��܂���\n�u�񋟃f�[�^�X�V�����v���s���Ă�������";
                            //    return rtnCd = -2;
                            //}
                            //else if (Merge == 1)
                            //{
                            //    _mStatusMessage = "�񋟃f�[�^�X�V�������ł�\n ���΂炭���҂���������";
                            //    return rtnCd = -1;
                            //}
                            //else PgParam = PgParam.Replace("#Merge#", "");

                            // �X�V������ �� �v���O�����N�������Ȃ�
                            if (Merge == 1)
                            {
                                _mStatusMessage = "�񋟃f�[�^�X�V�������ł�\n ���΂炭���҂���������";
                                return rtnCd = -1;
                            }
                            else
                            {
                                PgParam = PgParam.Replace( "#Merge#", "" );
                            }

                            // �񋟃f�[�^�X�V�m�F
                            if (Merge == 2)
                            {
                                // ���s���邩���_�C�A���O�Ŋm�F
                                _mStatusMessage = "�T�[�o�[�����X�V����Ă��܂���" + Environment.NewLine
                                                  + "�u�񋟃f�[�^�X�V�����v�̎��s���K�v�ł�" + Environment.NewLine
                                                  + "" + Environment.NewLine
                                                  + "���i�����ŐV������Ă��܂���" + Environment.NewLine
                                                  + "�X�V�����ɏ����𑱍s���܂����H";
                                DialogResult dialogResult = SFNETMENU2Utilities.ShowMessage( SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarningConfirem, "Execute", "", _mStatusMessage, "" );
                                if (dialogResult != DialogResult.Yes)
                                {
                                    // ������
                                    return rtnCd = -2;
                                }
                            }
                            // --- UPD m.suzuki 2012/11/29 ----------<<<<<
                        }
                        // 2008.12.16 sugi -<<
                    }
                    catch (Exception er)
                    {

                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Execute", "�G���[", er.Message, "-999");
                        //�T�[�o�[�̃o�[�W�����`�F�b�N�ŗ������ꍇ�A�����ɗ���B
                        //System.Windows.Forms.Application.Exit();
                        return rtnCd = -999;
                    }

                    // 2008.09.28 sugi -<<
                    //  �N�����\��
                    if (SystemSettingInfo.ShowDialog == true)
                    {
                        msgWin.ShowProgressMessage(SystemSettingInfo.DialogTimerInterval, ScreenInfo);
                        System.Windows.Forms.Application.DoEvents();
                    }

                    // --- ADD 2013/12/11 T.Nishi ---------->>>>>
                    //���j���[�ȈՋN���I�v�V�������ݒ肳��Ă��Ȃ��A�܂��͋N��������0�̏ꍇ�́u����`�[���́v�A�u���Ӑ�d�q�����v�����ꂼ��N��
                    //if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM02010") == 0) // DEL 2013/12/19
                    if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM02010") <= 0) // ADD 2013/12/19
                     && (mii.Pgid == TargetPGID_PMHNB01000U)) 
                    {
                        mii.Pgid = TargetPGID_MAHNB01001U;
                    }
                    //if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM02010") == 0) // DEL 2013/12/19
                    if ((Program.arm.SoftwarePurchasedCheckForUSB("OPT-PM02010") <= 0)  // ADD 2013/12/19
                     && (mii.Pgid == TargetPGID_PMKAU04020U))
                    {
                        mii.Pgid = TargetPGID_PMKAU04000U;
                    }
                    // --- ADD 2013/12/11 T.Nishi ----------<<<<<

                    string args = _mAccessNo + " " + _mPortNo + " " + mii.Parameter + " " + AddParam;
                    args = args.Trim();
                    //  �N��
                    try
                    {
                        System.Diagnostics.Process p = System.Diagnostics.Process.Start(Path.Combine(Path.GetDirectoryName(gcmd[0]), mii.Pgid), args);
                        //                    p.WaitForInputIdle();
                    }
                    catch (Exception er)
                    {
                        _mStatusMessage = er.Message;
                        return�@rtnCd = 5;
                    }

                    // --- ADD 2021/01/05 ���� ---------->>>>>
                    // �N��PG���𑀍엚�����O�ɏo��
                    StartPgOperationLogOutput(mii, "StartProgram");
                    // --- ADD 2021/01/05 ���� ---------->>>>>
                }
            }

            return rtnCd;

        }

        /// <summary>
        /// �ŋߎg�����@�\�o�^����
        /// </summary>
        /// <param name="MenuTab">�ΏۃI�u�W�F�N�g</param>
        /// <param name="ci">�o�^�T�u�J�e�S����</param>
        /// <param name="DspType">���j���[�A�C�e�����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�ŋߎg�����@�\�o�^</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int AddRecentFnc(object sender, string GroupHeader, Image img, MenuItemInfomation mii)
        {
            //  �悸�́A�������ڂ��o�^����ĂȂ����m�F����B�L��΍폜
            for (int i = 0; i < barRecent.DropDownItems.Count; i++)
            {
                MenuItemInfomation mir = (MenuItemInfomation)barRecent.DropDownItems[i].Tag;
                if ((mii.CategoryID == mir.CategoryID) && (mii.CategorySubID == mir.CategorySubID) && (mii.ItemID == mir.ItemID))
                {
                    barRecent.DropDownItems[i].Dispose();
                    _mMaxRecentCount--;
                }
                

            }

            //  �ő匏���𒴂��Ȃ��悤�ɁA�������������
            if (barRecent.DropDownItems.Count >= _mMaxRecentCount)
            {
                barRecent.DropDownItems[_mMaxRecentCount - 1].Dispose();
                _mMaxRecentCount--;

            }

            //  ���j���[���ڐݒ�
            ToolStripItem tsi = new ToolStripMenuItem();
            tsi.Text = GroupHeader.Replace("\\n", "") + "�F" + mii.Name.Replace("\\n", "");
            tsi.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.ItemList];
            tsi.ForeColor = ScreenInfo.MenuBarForeColor;
            tsi.BackColor = ScreenInfo.MenuBarBackColor;
            tsi.Click +=new EventHandler(this_RecentClick);
            tsi.Tag = mii;

            //  �ŋߎg�����@�\�ɐݒ�
            barRecent.DropDownItems.Insert(0,tsi);
            _mMaxRecentCount++;

            return 0;

        }

        /// <summary>
        /// �v���p�e�B�X�V���䏈��
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�X�V����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public int ChangeControlProperty()
        {
            CustomProfessionalRenderer cpr = new CustomProfessionalRenderer();
            try
            {
                cpr._ToolStripGradientBegin = ScreenInfo.ToolBarColor.ToolStripGradientBegin;
                cpr._ToolStripGradientMiddle = ScreenInfo.ToolBarColor.ToolStripGradientMiddle;
                cpr._ToolStripGradientEnd = ScreenInfo.ToolBarColor.ToolStripGradientEnd;
                cpr._ToolStripPanelGradientBegin = ScreenInfo.ToolBarColor.ToolStripPanelGradientBegin;
                cpr._ToolStripPanelGradientEnd = ScreenInfo.ToolBarColor.ToolStripPanelGradientEnd;
            }
            catch (Exception)
            {
                cpr._ToolStripGradientBegin = Color.LightBlue;
                cpr._ToolStripGradientMiddle = Color.WhiteSmoke;
                cpr._ToolStripGradientEnd = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientBegin = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientEnd = Color.LightSkyBlue;
            }

            barCtrl.ForeColor = ScreenInfo.ToolBarForeColor;
            barCtrl.Renderer = new ToolStripProfessionalRenderer(cpr);
            btnExit.ForeColor = ScreenInfo.ToolBarForeColor;
            barLoginInfo.ForeColor = ScreenInfo.ToolBarForeColor;
            barLoginInfo.Renderer = new ToolStripProfessionalRenderer(cpr);
            lblLoginUser.ForeColor = ScreenInfo.ToolBarForeColor;
            barInfo.ForeColor = ScreenInfo.ToolBarForeColor;
            barFuncMenu.ForeColor = ScreenInfo.ToolBarForeColor;
            barFuncMenu.Renderer = new ToolStripProfessionalRenderer(cpr);
            barRecent.ForeColor = ScreenInfo.ToolBarForeColor;
            cmbSearchMenu.ForeColor = ScreenInfo.ToolBarForeColor;
            //  �����F�Ɣw�i�F�������ɂȂ��Ă��܂�����A�����F�𔽓]                //  2007.01.10  �ǉ�
            if (cmbSearchMenu.ForeColor.ToArgb() == cmbSearchMenu.BackColor.ToArgb())
            {
                byte cr = (byte)~(cmbSearchMenu.BackColor.R);
                byte cg = (byte)~(cmbSearchMenu.BackColor.G);
                byte cb = (byte)~(cmbSearchMenu.BackColor.B);
                cmbSearchMenu.ForeColor = Color.FromArgb(cr, cg, cb);
            }
            barInfo.Renderer = new ToolStripProfessionalRenderer(cpr);
            lblDate.ForeColor = ScreenInfo.ToolBarForeColor;

            mnuMain.BackColor = ScreenInfo.MenuBarBackColor;
            mnuMain.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuFile.BackColor = ScreenInfo.MenuBarBackColor;
            mnuFile.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuLogin.BackColor = ScreenInfo.MenuBarBackColor;
            mnuLogin.ForeColor = ScreenInfo.MenuBarForeColor;
            //mnuLoginInfo.BackColor = ScreenInfo.MenuBarBackColor; 2009.02.10 sugi del
            //mnuLoginInfo.ForeColor = ScreenInfo.MenuBarForeColor; 2009.02.10 sugi del
            mnuExit.BackColor = ScreenInfo.MenuBarBackColor;
            mnuExit.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuEdit.BackColor = ScreenInfo.MenuBarBackColor;
            mnuEdit.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuEdit.BackColor = ScreenInfo.MenuBarBackColor;
            mnuEdit.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuLTabDel.BackColor = ScreenInfo.MenuBarBackColor;
            mnuLTabDel.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuRTabDel.BackColor = ScreenInfo.MenuBarBackColor;
            mnuRTabDel.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuOption.BackColor = ScreenInfo.MenuBarBackColor;
            mnuOption.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuSearch.BackColor = ScreenInfo.MenuBarBackColor;
            mnuSearch.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuTab.BackColor = ScreenInfo.MenuBarBackColor;
            mnuTab.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuTabDel.BackColor = ScreenInfo.MenuBarBackColor;
            mnuTabDel.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuVersion.BackColor = ScreenInfo.MenuBarBackColor;
            mnuVersion.ForeColor = ScreenInfo.MenuBarForeColor;
            //--- ADD 2011/06/29 M.Kubota --->>>
            mnuCustHistory.BackColor = ScreenInfo.MenuBarBackColor;
            mnuCustHistory.ForeColor = ScreenInfo.MenuBarForeColor;
            //--- ADD 2011/06/29 M.Kubota ---<<<
            mnuVisual.BackColor = ScreenInfo.MenuBarBackColor;
            mnuVisual.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuEditUserMenu.BackColor = ScreenInfo.MenuBarBackColor;
            mnuEditUserMenu.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuCloseTab.BackColor = ScreenInfo.MenuBarBackColor;
            mnuCloseTab.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuResetSize.BackColor = ScreenInfo.MenuBarBackColor;
            mnuResetSize.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuResetWindow.BackColor = ScreenInfo.MenuBarBackColor;
            mnuResetWindow.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuSavePosition.BackColor = ScreenInfo.MenuBarBackColor;
            mnuSavePosition.ForeColor = ScreenInfo.MenuBarForeColor;
            mnuSaveSize.BackColor = ScreenInfo.MenuBarBackColor;
            mnuSaveSize.ForeColor = ScreenInfo.MenuBarForeColor;                //  2007.01.10  �ǉ�
            mnuSystemReport.BackColor = ScreenInfo.MenuBarBackColor;
            mnuSystemReport.ForeColor = ScreenInfo.MenuBarForeColor;

            mnuSavePosition.Checked = SystemSettingInfo.SaveLastPosition;
            mnuSaveSize.Checked = SystemSettingInfo.SaveLastSize;

            stsInfo.BackColor = ScreenInfo.StatusBarBackColor;
            stsInfo.ForeColor = ScreenInfo.StatusBarForeColor;
            stsInfo1.BackColor = ScreenInfo.StatusBarBackColor;
            stsInfo1.ForeColor = ScreenInfo.StatusBarForeColor;
            stsInfo2.BackColor = ScreenInfo.StatusBarBackColor;
            stsInfo2.ForeColor = ScreenInfo.StatusBarForeColor;
            stsInfo3.BackColor = ScreenInfo.StatusBarBackColor;
            stsInfo3.ForeColor = ScreenInfo.StatusBarForeColor;
            stsInfo4.BackColor = ScreenInfo.StatusBarBackColor;
            stsInfo4.ForeColor = ScreenInfo.StatusBarForeColor;
            stsInfoTheme.BackColor = ScreenInfo.StatusBarBackColor;
            stsInfoTheme.ForeColor = ScreenInfo.StatusBarForeColor;

            stsInfoTheme.Text = "Theme:" + ScreenInfo.ThemeName;
            stsInfo1.Width = stsInfo.ClientSize.Width - (stsInfo2.Width + stsInfo3.Width + stsInfo4.Width + stsInfoTheme.Width) - 30;

            lstSubCategory.ForeColor = ScreenInfo.SubCategoryForeColor;
            lstSubCategory.BackColor = ScreenInfo.SubCategoryBackColor;
            lstSubCategory.BackgroundImage = ScreenInfo.SubCategoryBackImage;
            lstSubCategory.BackgroundImageTiled = ScreenInfo.SubCategoryBackImageTiled;

            grpButton.ForeColor = ScreenInfo.CategoryForeColor;
            grpButton.BackColor = ScreenInfo.CategoryBackColor1;
            grpButton.BackColor2 = ScreenInfo.CategoryBackColor2;
            grpButton.GradientMode = ScreenInfo.CategoryGradiationMode;
            grpButton.GroupButtonBackColor1 = ScreenInfo.CategoryButtonBackColor1;
            grpButton.GroupButtonBackColor2 = ScreenInfo.CategoryButtonBackColor2;
            grpButton.GroupButtonGradientMode = ScreenInfo.CategoryButtonGradiationMode;
            grpButton.SelectedButtonForeColor = ScreenInfo.CategorySelectedButtonForeColor;
            grpButton.SelectedButtonFaceColor1 = ScreenInfo.CategorySelectedButtonFaceColor1;
            grpButton.SelectedButtonFaceColor2 = ScreenInfo.CategorySelectedButtonFaceColor2;
            grpButton.ActivePanelBorderColor = ScreenInfo.CategoryActivePanelBorderColor;
            grpButton.FocusButtonBorderColor = ScreenInfo.CategoryFocusButtonBorderColor;
            grpButton.HotTrackingColor = ScreenInfo.CategoryHotTrackingColor;
            grpButton.ShiftKeyPriority = SystemSettingInfo.ShiftKeyPriority;
            if (ScreenInfo.FocusBorderBold == true)
            {
                grpButton.FocusDepth = 2;
                grpButton.GroupButtonInnerDepth = 2;
            }
            else
            {
                grpButton.FocusDepth = 1;
                grpButton.GroupButtonInnerDepth = 1;
            }

            
            //            ScreenInfo.CategoryBackImage;
            //            ScreenInfo.SubCategoryBackImageTiled;
            //            grpButton.GroupButtonInnerDepth = 1;
            //            grpButton.GroupButtonMargin = 1;
            //            grpButton.HotTrackingColor = System.Drawing.Color.Red;
            //            grpButton.SelectedButtonColor = System.Drawing.Color.Red;

            for (int i = 0; i < tabMenu.TabCount; i++)
            {

                for (int j=0; j < tabMenu.TabPages[i].Controls.Count; j++)
                {

                    tabMenu.TabPages[i].BackColor = ScreenInfo.TabPageBackColor;
                    tabMenu.TabPages[i].BackgroundImage = ScreenInfo.TabPageBackImage;
                    tabMenu.TabPages[i].BackgroundImageLayout = ScreenInfo.TabPageBackImageLayout;

                    //  �O���[�v�{�^���Ȃ�
                    if (tabMenu.TabPages[i].Controls[j].GetType() == typeof(TGroupButton))
                    {
                        TGroupButton GB = (TGroupButton)tabMenu.TabPages[i].Controls[j];
                        GB.ForeColor = ScreenInfo.SubMenuForeColor;
                        GB.BackColor = ScreenInfo.SubMenuBackColor1;
                        GB.BackColor2 = ScreenInfo.SubMenuBackColor2;
                        GB.GradientMode = ScreenInfo.SubMenuGradiationMode;
                        GB.HeaderForeColor = ScreenInfo.SubMenuHeaderForeColor;
                        GB.HeaderBackColor1 = ScreenInfo.SubMenuHeaderBackColor1;
                        GB.HeaderBackColor2 = ScreenInfo.SubMenuHeaderBackColor2;
                        GB.HeaderGradientMode = ScreenInfo.SubMenuHeaderGradiationMode;
                        GB.HeaderActiveForeColor = ScreenInfo.SubMenuHeaderActiveForeColor;
                        GB.GroupButtonBackColor1 = ScreenInfo.SubMenuButtonBackColor1;
                        GB.GroupButtonBackColor2 = ScreenInfo.SubMenuButtonBackColor2;
                        GB.GroupButtonGradientMode = ScreenInfo.SubMenuButtonGradiationMode;
                        GB.SelectedButtonForeColor = ScreenInfo.SubMenuSelectedButtonForeColor;
                        GB.SelectedButtonFaceColor1 = ScreenInfo.SubMenuSelectedButtonFaceColor1;
                        GB.SelectedButtonFaceColor2 = ScreenInfo.SubMenuSelectedButtonFaceColor2;
                        GB.BackgroundImage = ScreenInfo.SubMenuBackImage;
                        GB.BackgroundImageLayout = ScreenInfo.SubMenuBackImageLayout;
                        //            grpSubItem.BorderStyle = BorderStyle.FixedSingle;
                        //            grpSubItem.GroupButtonDepth = 1;
                        //            grpSubItem.GroupButtonMargin = 4;
                        //            grpSubItem.HeaderActiveForeColor = Color.Red;
                        GB.DescBackColor1 = ScreenInfo.SubMenuDescBackColor1;
                        GB.DescBackColor2 = ScreenInfo.SubMenuDescBackColor2;
                        GB.DescForeColor = ScreenInfo.SubMenuDescForeColor;
                        //            ScreenInfo.DescOuterDepth = 2;
                        GB.DescGradientMode = ScreenInfo.SubMenuDescGradientMode;
                        GB.DescLineColor = ScreenInfo.SubMenuDescLineColor;
                        GB.ActivePanelBorderColor = ScreenInfo.SubMenuActivePanelBorderColor;
                        GB.FocusButtonBorderColor = ScreenInfo.SubMenuFocusButtonBorderColor;
                        GB.HotTrackingColor = ScreenInfo.SubMenuHotTrackingColor;
                        if (ScreenInfo.FocusBorderBold == true)
                        {
                            GB.FocusDepth = 2;
                            GB.GroupButtonInnerDepth = 2;
                        }
                        else
                        {
                            GB.FocusDepth = 1;
                            GB.GroupButtonInnerDepth = 1;
                        }
                        if (SystemSettingInfo.NumKeyEnabled == true)
                        {
                            GB.EnableNumKeyClick = true;
                        }
                        else
                        {
                            GB.EnableNumKeyClick = false;
                        }
                        GB.ShiftKeyPriority = SystemSettingInfo.ShiftKeyPriority;
                    }
                }
            }

            spltMain.BackColor = ScreenInfo.ScreenBackColor;
            spltMain.Panel1.BackColor = ScreenInfo.ScreenBackColor;
            spltMain.Panel2.BackColor = ScreenInfo.ScreenBackColor;
            spltCategory.BackColor = ScreenInfo.ScreenBackColor;
            spltCategory.Panel1.BackColor = ScreenInfo.ScreenBackColor;
            spltCategory.Panel2.BackColor = ScreenInfo.ScreenBackColor;
            tscMain.ContentPanel.BackColor = ScreenInfo.ScreenBackColor;
            try
            {
                tscMain.TopToolStripPanel.BackColor = ScreenInfo.ToolBarColor.ToolStripPanelGradientBegin;
                tscMain.BottomToolStripPanel.BackColor = ScreenInfo.ToolBarColor.ToolStripPanelGradientBegin;
            }
            catch (Exception)
            {
                tscMain.TopToolStripPanel.BackColor = Color.LightSkyBlue;
                tscMain.BottomToolStripPanel.BackColor = Color.LightSkyBlue;
            }

            lblDate.Text = SFNETMENU2Utilities.GetCalendar(ref SystemSettingInfo.DateTimeFormat);
            System.Windows.Forms.Application.DoEvents();

            Refresh();

            return 0;

        }

        /// <summary>
        /// ���[���ݒ�t�@�C���Ǎ�����
        /// </summary>
        /// <returns>���j���[�ݒ���</returns>
        /// <remarks>
        /// <br>Note       :���[���ݒ�t�@�C���Ǎ�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private ArrayList ReadRollSettingFile()
        {

            try
            {
                ArrayList arRolls = new ArrayList();
                arRolls.Clear();

                FileEncryptgraphy fe = new FileEncryptgraphy(cRollSetting1 + cRollSetting2 + cRollSetting3 + cRollSetting4 + cRollSetting5);

                MemoryStream ms = fe.DecryptFile(Path.Combine(_mNavigationDataDir, SFNETMENU2Utilities.RollSettingXML));
                if (ms == null)
                {
                    return null;
                }

                DataSet dsRollSettings = new DataSet();
                dsRollSettings.ReadXml(ms, XmlReadMode.ReadSchema);
                foreach (DataRow dr in dsRollSettings.Tables[0].Rows)
                {
                    RollSettingInfomation rc = new RollSettingInfomation();
                    rc.RollRank = (int)dr["RollRank"];
                    rc.RollName = dr["RollName"].ToString();
                    rc.PassWordType = (int)dr["PassWordType"];
                    rc.PassWord = dr["PassWord"].ToString();
                    rc.Result = dr["Result"].ToString();
                    arRolls.Add(rc);
                }

                return arRolls;

            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// ���j���[�ݒ�t�@�C���Ǎ�����
        /// </summary>
        /// <returns>���j���[�ݒ���</returns>
        /// <remarks>
        /// <br>Note       :���j���[�ݒ�t�@�C���Ǎ�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private MenuConfigration ReadSettingFile()
        {
            MenuConfigration mc;

            try
            {
                StringHashEncryptgraphy she = new StringHashEncryptgraphy(cSfNetUserConfigKey1 + cSfNetUserConfigKey2 + cSfNetUserConfigKey3);
                string EmployeeSettingFileName = SFNETMENU2SettingInfomation.DefaultSettinBinary + she.CreateHash(Program.gloginInfo.EmployeeCode.Trim() + Program.gloginInfo.EmployeeCode.Trim()) + SFNETMENU2SettingInfomation.DefaultSettinBinaryExt;

                BinaryFormatter formatter = new BinaryFormatter();
                FileEncryptgraphy fe = new FileEncryptgraphy(cUserSetting1 + cUserSetting2 + cUserSetting3 + cUserSetting4 + cUserSetting5);

                MemoryStream ms = fe.DecryptFile(Path.Combine(_mAppSettingDataDir, EmployeeSettingFileName));
                if (ms == null)
                {
                    return null;
                }

                mc = (MenuConfigration)formatter.Deserialize(ms);

                return mc;

            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// ���j���[�ݒ�t�@�C����������
        /// </summary>
        /// <param name="mc">���j���[�ݒ���</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���j���[�ݒ�t�@�C������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int WriteSettingFile(MenuConfigration mc)
        {

            if (Directory.Exists(_mAppSettingDataDir) == false)
            {
                try
                {
                    Directory.CreateDirectory(_mAppSettingDataDir);
                }
                catch (Exception)
                {
                }
            }

            try
            {
                //  ���j���[�o�[�W�����������ݒ�(���������e���ǎ��Ƀ`�F�b�N����ړI�Ŏg�p�\��)
                mc.InfoVer = cMenuConfVer;

                StringHashEncryptgraphy she = new StringHashEncryptgraphy(cSfNetUserConfigKey1 + cSfNetUserConfigKey2 + cSfNetUserConfigKey3);
                string EmployeeSettingFileName = SFNETMENU2SettingInfomation.DefaultSettinBinary + she.CreateHash(Program.gloginInfo.EmployeeCode.Trim() + Program.gloginInfo.EmployeeCode.Trim()) + SFNETMENU2SettingInfomation.DefaultSettinBinaryExt;

                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                formatter.Serialize(ms, mc);

                FileEncryptgraphy fe = new FileEncryptgraphy(cUserSetting1 + cUserSetting2 + cUserSetting3 + cUserSetting4 + cUserSetting5);

                if (fe.EncryptFile(Path.Combine(_mAppSettingDataDir, EmployeeSettingFileName), ms) != 0)
                {
                    return 5;
                }

                stsInfo1.Text = "�ݒ�t�@�C����ۑ����܂���";

                return 0;

            }
            catch(Exception)
            {
                return 5;
            }

        }


        /// <summary>
        /// �T�u�J�e�S���\������
        /// </summary>
        /// <param name="cci">�J�e�S�����</param>
        /// <param name="CategryButtonIndex">�J�e�S���{�^���C���f�b�N�X</param>
        /// <param name="PhaseTabMenu">�^�u�y�[�W�T�u���j���[�\���ݒ�(0:ALL,1:TAB�}�f,2:���X�g�̂�)</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�T�u�J�e�S���\��</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private TabPage DisplaySubCategory(CategoryInfomation cci, int CategryButtonIndex, int PhaseTabMenu)
        {
            
            //  �J�e�S����񕔕\��
            try
            {
                lblCategory.Image = grpButton.ImageList.Images[grpButton.GroupButtons[CategryButtonIndex].ImageIndex];
            }
            catch
            { }
            // --- UPD m.suzuki 2011/08/08 ---------->>>>>
            # region // DEL
            //// --- UPD m.suzuki 2011/03/04 ---------->>>>>
            //lblCategory.Text = "�@ " + cci.Name;
            //try
            //{
            //    int count = Encoding.GetEncoding( "Shift-JIS" ).GetByteCount( cci.Name );
            //    if ( count <= 3 * 2 )
            //    {
            //        lblCategory.Text = "�@�@" + cci.Name;
            //    }
            //    else if ( count <= 4 * 2 )
            //    {
            //        lblCategory.Text = "�@ " + cci.Name;
            //    }
            //    else if ( count <= 5 * 2 )
            //    {
            //        lblCategory.Text = "�@" + cci.Name;
            //    }
            //    else if ( count <= 6 * 2 )
            //    {
            //        lblCategory.Text = " " + cci.Name;
            //    }
            //    else
            //    {
            //        lblCategory.Text = cci.Name;
            //    }
            //}
            //catch
            //{
            //    lblCategory.Text = "�@ " + cci.Name;
            //}
            //// --- UPD m.suzuki 2011/03/04 ----------<<<<<
            # endregion
            // --- UPD m.suzuki 2011/08/22 ---------->>>>>
            # region // DELL
            //lblCategory.Text = (new string( ' ', 4 )) + cci.Name;
            //try
            //{
            //    int count = Encoding.GetEncoding( "Shift-JIS" ).GetByteCount( cci.Name );
            //    if ( count <= 3 * 2 )
            //    {
            //        lblCategory.Text = (new string( ' ', 5 )) + cci.Name;
            //    }
            //    else if ( count <= 4 * 2 )
            //    {
            //        lblCategory.Text = (new string( ' ', 4 )) + cci.Name;
            //    }
            //    else if ( count <= 5 * 2 )
            //    {
            //        lblCategory.Text = (new string( ' ', 3 )) + cci.Name;
            //    }
            //    else if ( count <= 6 * 2 )
            //    {
            //        lblCategory.Text = (new string( ' ', 2 )) + cci.Name;
            //    }
            //    else
            //    {
            //        lblCategory.Text = (new string( ' ', 1 )) + cci.Name;
            //    }
            //}
            //catch
            //{
            //    lblCategory.Text = (new string( ' ', 5 )) + cci.Name;
            //}
            # endregion
            lblCategory.Text = (new string( ' ', 5 )) + cci.Name;
            try
            {
                int count = Encoding.GetEncoding( "Shift-JIS" ).GetByteCount( cci.Name );
                if ( count <= 3 * 2 )
                {
                    lblCategory.Text = (new string( ' ', 6 )) + cci.Name;
                }
                else if ( count <= 4 * 2 )
                {
                    lblCategory.Text = (new string( ' ', 5 )) + cci.Name;
                }
                else if ( count <= 5 * 2 )
                {
                    lblCategory.Text = (new string( ' ', 4 )) + cci.Name;
                }
                else if ( count <= 6 * 2 )
                {
                    lblCategory.Text = (new string( ' ', 3 )) + cci.Name;
                }
                else
                {
                    lblCategory.Text = (new string( ' ', 2 )) + cci.Name;
                }
            }
            catch
            {
                lblCategory.Text = (new string( ' ', 6 )) + cci.Name;
            }
            // --- UPD m.suzuki 2011/08/22 ----------<<<<<
            // --- UPD m.suzuki 2011/08/08 ----------<<<<<
            DataRow[] CategorySubInfo;
            if (cci.CategoryID != cFncUserMenu)
            {
                CategorySubInfo = SFNETMENU2Utilities.GetSubCategoryGroup(cci.CategoryID);
            }
            else
            {
                //CategorySubInfo = SFNETMENU2Utilities.GetUserCategoryGroup(cci.CategoryID);           //  2007.01.10  �ύX
                CategorySubInfo = SFNETMENU2Utilities.GetUserCategoryGroup(-1);
            }
            lstSubCategory.SmallImageList = MenuIconResourceManagement.GetImageList(cci.IconName);
            //lstSubCategory.LargeImageList = MenuIconResourceManagement.GetImageList(cci.IconName);    //  2007.01.10  �폜
            //lstSubCategory.StateImageList = MenuIconResourceManagement.GetImageList(cci.IconName);    //  2007.01.10  �폜
            lstSubCategory.Items.Clear();
            for (int i = 0; i < CategorySubInfo.Length; i++)
            {
                // ���]�ƈ��ɂċ@�\�̎g�p�E�s�̊m�F(�T�u�J�e�S��) // 2007.05.16 Add By Y.Ito

                // �������x�����擾
                int roleLevel1 = LoginInfoAcquisition.Employee.AuthorityLevel1;
                int roleLevel2 = LoginInfoAcquisition.Employee.AuthorityLevel2;

                // ���p�\�������擾(ItemsArray[10]�`ItemsArray[15]�܂ł����p�\����1�`���p�\����6)
                // �������x��1�̗��p����
                string enableCondition1 = CategorySubInfo[i].ItemArray[10].ToString();
                string enableCondition2 = CategorySubInfo[i].ItemArray[11].ToString();
                string enableCondition3 = CategorySubInfo[i].ItemArray[12].ToString();
                // �������x��2�̗��p����
                string enableCondition4 = CategorySubInfo[i].ItemArray[13].ToString();
                string enableCondition5 = CategorySubInfo[i].ItemArray[14].ToString();
                string enableCondition6 = CategorySubInfo[i].ItemArray[15].ToString();

                // ���p�\����������̉��
                int checkResultsA = -1; // �������x��1�̏���1
                int checkResultsB = -1; // �������x��1�̏���2
                int checkResultsC = -1; // �������x��1�̏���3
                int checkResultsD = -1; // �������x��2�̏���1
                int checkResultsE = -1; // �������x��2�̏���2
                int checkResultsF = -1; // �������x��2�̏���3

                // �������x��1�̗��p�����`�F�b�N
                if (enableCondition1 != "")
                {
                    checkResultsA = SystemCheck.CheckUseEnable(enableCondition1, roleLevel1);
                }

                if (enableCondition2 != "")
                {
                    checkResultsB = SystemCheck.CheckUseEnable(enableCondition2, roleLevel1);
                }

                if (enableCondition3 != "")
                {
                    checkResultsC = SystemCheck.CheckUseEnable(enableCondition3, roleLevel1);
                }

                // �������x��2�̗��p�����`�F�b�N
                if (enableCondition4 != "")
                {
                    checkResultsD = SystemCheck.CheckUseEnable(enableCondition4, roleLevel2);
                }

                if (enableCondition5 != "")
                {
                    checkResultsE = SystemCheck.CheckUseEnable(enableCondition5, roleLevel2);
                }

                if (enableCondition6 != "")
                {
                    checkResultsF = SystemCheck.CheckUseEnable(enableCondition6, roleLevel2);
                }

                // ���������������ꍇ�������͏������P�ł��ʂ�ꍇ
                if ((checkResultsA == -1 && checkResultsB == -1 && checkResultsC == -1 &&
                    checkResultsD == -1 && checkResultsE == -1 && checkResultsF == -1) ||
                    (checkResultsA == 1 || checkResultsB == 1 || checkResultsC == 1 ||
                     checkResultsD == 1 || checkResultsE == 1 || checkResultsF == 1))
                {

                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = (int)CategorySubInfo[i]["IconIndex"];
                    if (SystemCheck.CheckSystemPermissionFunction(CategorySubInfo[i]) != 0)
                    {
                        lvi.Text = CategorySubInfo[i]["Name"].ToString();
                    }
                    else
                    {
                        lvi.Text = "";
                    }
                    lvi.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                    SubCategoryInfomation ci = new SubCategoryInfomation();
                    ci.CategoryID = (int)CategorySubInfo[i]["CategoryID"];
                    ci.CategorySubID = (int)CategorySubInfo[i]["CategorySubID"];
                    ci.No = (int)CategorySubInfo[i]["No"];
                    ci.Name = CategorySubInfo[i]["Name"].ToString();
                    ci.Description = CategorySubInfo[i]["Description"].ToString();
                    //ci.IconType = CategorySubInfo[i]["IconType"].ToString();                  //  2006.09.29  �폜
                    ci.IconIndex = (int)CategorySubInfo[i]["IconIndex"];
                    ci.IconName = CategorySubInfo[i]["IconName"].ToString();
                    //ci.SystemCode = CategorySubInfo[i]["SystemCode"].ToString();              //  2006.09.29  �폜
                    //ci.OptionCode = CategorySubInfo[i]["OptionCode"].ToString();              //  2006.09.29  �폜
                    ci.SysOpCode = CategorySubInfo[i]["SysOpCode"].ToString();                  //  2006.09.29  �ǉ�
                    ci.DisplayOption = CategorySubInfo[i]["DisplayOption"].ToString();
                    lvi.Tag = ci;
                    // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    // ���[���O���[�v�����ݒ�}�X�^�ɊY������̏ꍇ�͔�\��
                    string categorySubItem = ci.CategoryID.ToString().PadLeft(4, '0') + ci.CategorySubID.ToString().PadLeft(6, '0') + "00";
                    if (_categorySubItem.Contains(categorySubItem)) continue;
                    // --- ADD 2013/02/15 �O�� 2013/03/06�z�M�� SCM��Q��10469 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    lstSubCategory.Items.Add(lvi);
                }
            }
            //  24�ɖ����Ȃ��ꍇ�A�_�~�[�󔒂�����                                         //  2007.01.10  �ǉ�
            for (int i = CategorySubInfo.Length; i < cSubMenuFig; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 0;
                lvi.Text = "";
                lvi.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                SubCategoryInfomation ci = new SubCategoryInfomation();
                ci.CategoryID = 0;
                ci.CategorySubID = 0;
                ci.No = 0;
                ci.Name = "";
                ci.Description = "";
                ci.IconIndex = 0;
                ci.IconName = "";
                ci.SysOpCode = "#";
                ci.DisplayOption = "";
                lvi.Tag = ci;
                lstSubCategory.Items.Add(lvi);
            }

            TabPage tb = null;

            if (PhaseTabMenu < 2)
            {

                //  �I�𒆂̃J�e�S�������ɕ\������Ă��邩�`�F�b�N���A������΍쐬�E�L��Ε\��
                for (int i = 0; i < tabMenu.TabPages.Count; i++)
                {
                    TabMenuInfomation ti = (TabMenuInfomation)tabMenu.TabPages[i].Tag;
                    if (ti.CategoryID == cci.CategoryID)
                    {
                        tabMenu.SelectedIndex = i;
                        tabMenu.TabPages[i].Select();
                        return tabMenu.TabPages[i];
                    }

                }
                tb = CreateTabMenubPage(cci);
                System.Windows.Forms.Application.DoEvents();
            }

            //  ���j���[���ו��\��
            if (PhaseTabMenu < 1)
            {
                for (int i = 0; i < lstSubCategory.Items.Count; i++)
                {
                    SubCategoryInfomation lci = (SubCategoryInfomation)lstSubCategory.Items[i].Tag;
                    //  �@�\�̎g�p�E�s�̊m�F
                    //if (SystemCheck.CheckSystemPermissionFunction(lci.SystemCode, lci.OptionCode) == 0)   //  2006.09.29  �ύX
                    if (SystemCheck.CheckSystemPermissionFunction(lci.SysOpCode) == 0)
                    {
                        continue;
                    }
                    //  �T�u���j���[�\��
                    if (CreateSubItem(tb, lci, 1, false) == 3)
                    {
                        break;
                    }
                }
                tabMenu.SelectedIndex = tabMenu.TabPages.Count - 1;
                tb.Select();
                System.Windows.Forms.Application.DoEvents();
            }

            return tb;
        }

        /// <summary>
        /// ���[�������`�F�b�N����
        /// </summary>
        /// <param name="mii">���j���[�A�C�e�����</param>
        /// <returns>�N���E�s��</returns>
        /// <remarks>
        /// <br>Note       :���[�������`�F�b�N</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private CheckRollTypes  CheckRollPassword(MenuItemInfomation mii, ref string ReturnString)
        {

            CheckRollTypes rtnCd;

            if (mii.Rank > 0)
            {
                try
                {
                    bool bHit = false;
                    RollSettingInfomation rsi = null;
                    for (int i = 0; i < arRollSettings.Count; i++)
                    {
                        rsi = (RollSettingInfomation)arRollSettings[i];
                        if (mii.Rank == rsi.RollRank)
                        {
                            bHit = true;
                            break;
                        }
                    }
                    if (bHit == true)
                    {
                        string[] retStr = rsi.Result.Split(',');

                        //  �ŏ���NG��Ԃ��p�^�[�����ɐݒ肵�Ă���
                        if ((rsi.PassWordType / 10) == 1)
                        {
                            ReturnString = retStr[0];
                            rtnCd = CheckRollTypes.Return_NG;
                        }
                        else if ((rsi.PassWordType / 20) == 1)
                        {
                            ReturnString = retStr[0];
                            rtnCd = CheckRollTypes.ReturnFix_NG;
                        }
                        else
                        {
                            ReturnString = "";
                            rtnCd = CheckRollTypes.Normal_NG;
                        }


                        string sPassKey1 = "";
                        string sPassKey2 = "";
                        string sPassKeyMain = "";
                        if ((rsi.PassWordType % 10) == 1)
                        {
                            //  �����^�C���w��Ȃ�p�X�L�[�쐬
                            string sHashOrg = Program.gloginInfo.EnterpriseCode.Trim() + DateTime.Now.ToString("ssmmHHddMMyyyy") + "3104962352267874543214";
                            sHashOrg.Substring(0, 24);
                            StringHashEncryptgraphy she = new StringHashEncryptgraphy(sHashOrg);
                            sPassKey1 = DateTime.Now.ToString("HH").Substring(0, 1);
                            sPassKey2 = she.CreateHash(Program.gloginInfo.EnterpriseCode.Trim());
                            sPassKey2 = sPassKey2.ToUpper().Substring(0, 7);
                            sPassKeyMain = sPassKey1 + sPassKey2;

                        }
                        if (usrPassSetWin.ShowPasswordSetting(rsi.PassWordType, sPassKeyMain, ScreenInfo) == DialogResult.OK)
                        {
                            if ((rsi.PassWordType % 10) == 1)
                            {
                                //  �����^�C���w��Ȃ�p�X�L�[����ɈÍ���������𐶐����A�`�F�b�N
                                string sPassword;
                                string sDate = DateTime.Now.ToString("ddMM");
                                string sTime = DateTime.Now.ToString("HH");

                                sPassword = StringEncryptgraphy.EncryptString(sTime + sDate, sPassKey2, 1);
                                int maxLoop = 0;

                                if (sPassword.Length > 20)
                                {
                                    maxLoop = 20;
                                }
                                else
                                {
                                    maxLoop = sPassword.Length;
                                }

                                string sCutPassword = "";
                                for (int i = 0; i < maxLoop; i++)
                                {
                                    if ((i % 3) == 0)
                                    {
                                        sCutPassword = sCutPassword + sPassword.Substring(i, 1);
                                    }
                                }
                                if (sCutPassword + sPassKey1 != usrPassSetWin.Password)
                                {
                                    if ((rsi.PassWordType / 10) == 0)
                                    {
                                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Check", "�����G���[", "�p�X���[�h����v���܂���ł����B\n\n���̋@�\���g�p���鎖�͏o���܂���B", "-921");
                                    }
                                    return rtnCd;
                                }
                                else
                                {
                                    //  ����
                                    if ((rsi.PassWordType / 10) == 1)
                                    {
                                        ReturnString = retStr[1];
                                        return CheckRollTypes.Return_OK;
                                    }
                                    else
                                    {
                                        ReturnString = "";
                                        return CheckRollTypes.Normal_OK;
                                    }
                                }
                            }
                            else
                            {
                                if ((rsi.PassWordType / 20) == 1)
                                {
                                    //  �����p�X���[�h
                                    string[] PassArray = rsi.PassWord.Split(',');
                                    for (int i = 0; i < PassArray.Length; i++)
                                    {
                                        if (PassArray[i] == usrPassSetWin.Password)
                                        {
                                            //  ����
                                            ReturnString = retStr[i + 1];
                                            return CheckRollTypes.ReturnFix_OK;
                                        }
                                    }
                                    return rtnCd;
                                }
                                else
                                {
                                    //  �P��p�X���[�h
                                    if (rsi.PassWord != usrPassSetWin.Password)
                                    {
                                        if ((rsi.PassWordType / 10) != 1)
                                        {
                                            SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Check", "�����G���[", "�p�X���[�h����v���܂���ł����B\n\n���̋@�\���g�p���鎖�͏o���܂���B", "-922");
                                        }
                                        return rtnCd;
                                    }
                                    else
                                    {
                                        //  ����
                                        if ((rsi.PassWordType / 10) == 1)
                                        {
                                            ReturnString = retStr[1];
                                            return CheckRollTypes.Return_OK;
                                        }
                                        else
                                        {
                                            return CheckRollTypes.Normal_OK;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Check", "�����G���[", "�p�X���[�h�̓��͂��L��܂���ł����B\n\n���̋@�\���g�p���鎖�͏o���܂���B", "-923");   //  2007.10
                            return CheckRollTypes.Normal_NG;
                        }
                    }
                    else
                    {
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Check", "�����G���[",  "�����ݒ肪�s���ł��B\n\n���̋@�\���g�p���鎖�͏o���܂���B", "-924");
                        return CheckRollTypes.Normal_NG;
                    }
                }
                catch (Exception er)
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelWarning, "Check", "�����G���[",  er.Message, "-925");
                    return CheckRollTypes.Normal_NG;
                }
            }
            else
            {
                return CheckRollTypes.Normal_OK;
            }
        }

        /// <summary>
        /// �^�u�y�[�W�R���g���[�����T�C�Y����
        /// </summary>
        /// <param name="mii">�^�u�y�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�^�u�y�[�W�R���g���[�����T�C�Y</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public int ResizeTabPage(TabPage tabbActive)
        {
            //  �^�u�y�[�W����������ăO���[�v�{�^���̍Ē������s��
            try
            {
                if (tabbActive.Tag != null)
                {
                    TabMenuInfomation ti = (TabMenuInfomation)tabbActive.Tag;
                    if (_mSubMenuItemSetType == 1)
                    {
                        ti.SubMenuItemWidth1 = (_mtabpageSize.Width - (ti.SubMenuItemMargin + (ti.SubMenuItemMargin * ti.SubMenuItemDefCount1))) / ti.SubMenuItemDefCount1;
                        ti.SubMenuItemWidth2 = (_mtabpageSize.Width - (ti.SubMenuItemMargin + (ti.SubMenuItemMargin * ti.SubMenuItemDefCount2))) / ti.SubMenuItemDefCount2;
                    }
                    int L = ti.SubMenuItemMargin;
                    for (int i = ti.arSubItems.Count - 1; i >= 0; i--)
                    {
                        //  �O���[�v�{�^���Ȃ�
                        int w;
                        TGroupButton gb = (TGroupButton)ti.arSubItems[i];
                        SubCategoryInfomation ci = (SubCategoryInfomation)gb.Tag;
                        if (ci != null)
                        {
                            //  �ʒu�E�����擾
                            if (ci.DisplayOption.Trim() == "0")
                            {
                                w = ti.SubMenuItemWidth1;
                            }
                            else
                            {
                                w = ti.SubMenuItemWidth2;
                            }
                            int h;
                            if (_mtabpageSize.Height != 0)
                            {
                                h = _mtabpageSize.Height;
                            }
                            else
                            {
                                h = tabbActive.ClientSize.Height;
                            }

                            gb.SetBounds(L, 0, w, h);
                            L = L + ti.SubMenuItemMargin + w;
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    //  ���݃^�u�̂݁A�`��I���Ƃ��Ă���
                    ti.NeedRefresh = false;
                }
                return 0;
            }
            catch (Exception)
            {
                return 5;
            }
        }

        /// <summary>
        /// �J�e�S���E�T�u�J�e�S���X�v���b�^�[���T�C�Y����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�J�e�S���E�T�u�J�e�S���X�v���b�^�[���T�C�Y</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int ResizeCategory()
        {
            //  �J�e�S���{�^���𒲐�(���[�h�ɂ�菈������)
            try
            {
                spltCategory.SplitterDistance = 0;
                spltCategory_Panel2_Resize(null, EventArgs.Empty);  //ADD 2011/06/29 M.Kubota  // �\�����ɃX�N���[���o�[��\��
                return 0;�@//2009.01.13 sugi add
                /*
                //  �T�u�J�e�S�����v�Z
                int lstLineHeight = lblCategory.Height;
                //  5�ȉ��Ȃ�Œ�6�ɂ��Ă���(���h���̖��)
                if (lstSubCategory.Items.Count > 0) 
                {
                    //  �������Ȃ��ꍇ�A���h���̖��Œ��߂ɂƂ�
                    if (lstSubCategory.Items.Count > 5)
                    {
                        lstLineHeight = lstLineHeight + lstSubCategory.Items[0].Bounds.Height * (lstSubCategory.Items.Count + 1);
                    }
                    else
                    {
                        lstLineHeight = lstLineHeight + lstSubCategory.Items[0].Bounds.Height * (lstSubCategory.Items.Count * 2);
                    }
                }
                //  �J�e�S�����v�Z
                int grpButtonHeight = grpButton.GroupButtonMargin;
                for (int i = 0; i < grpButton.GroupButtons.Count; i++)
                {
                    grpButtonHeight = grpButtonHeight + grpButton.GroupButtons[i].Size.Height  + grpButton.GroupButtonMargin;
                }

                //  �����X�v���b�g�p�l���S�̂��A�J�e�S���{�T�u�J�e�S�������傫����΁A�ǂ�ȃ��[�h�ł��J�e�S���D��Ƃ���
                //  (�����ڂ̖��)
                if (spltCategory.ClientSize.Height > (spltCategory.SplitterWidth + grpButtonHeight + lstLineHeight))
                {
                    //  �S�̂̍�����ݒ�
                    grpButton.GroupButtons[0].ImageIndex = 2;
                    //spltCategory.SplitterDistance = spltCategory.ClientSize.Height - (grpButtonHeight + 2);   //  2007.01.10  �ύX
                    spltCategory.SplitterDistance = spltCategory.ClientSize.Height - (grpButtonHeight + +spltCategory.SplitterWidth + 1);
                }
                else
                {

                    grpButton.GroupButtons[0].ImageIndex = _mPanelPriorityMode;
                    if (_mPanelPriorityMode == 1)
                    {
                        //  �T�u�J�e�S���D��
                        if (spltCategory.ClientSize.Height - (lstLineHeight + 10) > 0)
                        {
                            //  �\���ɗ]�T����
                            spltCategory.SplitterDistance = lstLineHeight + 10;
                        }
                        else
                        {
                            //  �\���ɗ]�T�Ȃ�
                            spltCategory.SplitterDistance = spltCategory.ClientSize.Height - (spltCategory.SplitterWidth + grpButton.GroupButtons[0].Size.Height + (grpButton.GroupButtonMargin * 2));
                        }
                    }
                    else
                    {
                        //  �J�e�S���D��
                        //  �S�̂̍�����ݒ�
                        if (spltCategory.ClientSize.Height - (grpButtonHeight + 2) > 0)
                        {
                            //spltCategory.SplitterDistance = spltCategory.ClientSize.Height - (grpButtonHeight + 2);   //  2007.01.10  �ύX
                            spltCategory.SplitterDistance = spltCategory.ClientSize.Height - (grpButtonHeight + spltCategory.SplitterWidth + 1);
                        }
                        else
                        {
                            spltCategory.SplitterDistance = 1;
                        }

                    }
                }

                //  �T�u�J�e�S���\�����X�g�ݒ�
                lstSubCategory.Columns[0].Width = lstSubCategory.ClientSize.Width - 2;

                System.Windows.Forms.Application.DoEvents();

                return 0;
                */
            }
            catch (Exception)
            {
                return 5;
            }

        }

        /// <summary>
        /// �ڍו\���^�C�v�擾����
        /// </summary>
        /// <param name="displayOpt">�ڍו\���敪</param>
        /// <returns>�ڍו\���^�C�v</returns>
        /// <remarks>
        /// <br>Note       :�ڍו\���^�C�v�擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.29</br>
        /// </remarks>
        private DescriptionEnumTypes GetDescriptionType(string displayOpt)
        {
            int DspFlg = 0;

            try
            {
                DspFlg = System.Convert.ToInt32(displayOpt);
            }
            catch
            {
                DspFlg = 0;
            }

            //0:�ʏ�^�C�v,1:�ڍו\��7�^�C�v,2:�ڍו\��10�^�C�v,11:option���f�ڍו\��7�^�C�v,12:option���f�ڍו\��10�^�C�v
            if (DspFlg == 0)
            {
                return DescriptionEnumTypes.Normal;
            }
            else if (DspFlg == 1)
            {
                return DescriptionEnumTypes.Std7Lines;
            }
            else if (DspFlg == 2)
            {
                return DescriptionEnumTypes.Std5Lines;
            }
            else if (DspFlg == 11)
            {
                return DescriptionEnumTypes.Check7Lines;
            }
            else if (DspFlg == 12)
            {
                return DescriptionEnumTypes.Check5Lines;
            }
            else
            {
                return DescriptionEnumTypes.Normal;
            }
       
        }

        /// <summary>
        /// ���O�C���p�����[�^�擾����
        /// </summary>
        /// <returns></returns>
        private string GetLoginArgument()
        {
            StringBuilder arguments = new StringBuilder();

            // ���O�C���p�����[�^����ݒ�
            ApplicationStartControl applicationStartControl = new ApplicationStartControl();
            string[] loginArguments = applicationStartControl.Parameters;

            if (loginArguments == null)
            {
                return null;
            }

            foreach (string argument in loginArguments)
            {
                if (argument.Trim() != "")
                {
                    arguments.Append(argument + " ");
                }
            }

            return arguments.ToString();
        }

        //2008.09.26 sugi --<<
        private void btnHome_Click(object sender, EventArgs e)
        {

            //  �X�e�[�^�X�o�[����                                                      //  2007.12.26
            stsInfo1.Text = "";

            //  �����A�����ł���΁A���̒��Ńg�b�v�y�[�W�ցA������΍쐬
            for (int i = 0; i < tabMenu.TabPages.Count; i++)
            {
                TabMenuInfomation tim = (TabMenuInfomation)tabMenu.TabPages[i].Tag;
                if ((tim.CategoryID == 0) && (tim.SubMenuItemCount == 0))
                {
                    TabPage tb = tabMenu.TabPages[i];
                    tabMenu.SelectedTab = tb;
                    for (int j = 0; j < tb.Controls.Count; j++)
                    {
                        //  Web�Ȃ�
                        if (tb.Controls[j].GetType() == typeof(WebBrowser))
                        {

                            WebBrowser wb = (WebBrowser)tb.Controls[j];
                            wb.Navigate(gServiceTopPage);
                            return;

                        }
                    }
                }
            }

            //  �C���t�H���[�V������\��
            string[] ProductIDs = new string[arProducts.Count];
            for (int i = 0; i < arProducts.Count; i++)
            {
                //ProductIDs[0] = ((ProductsInfomation)arProducts[i]).ProductID;    //  2006.09.29  �ύX
                ProductIDs[i] = ((ProductsInfomation)arProducts[i]).ProductID;
            }
            //DataRow[] Category = SFNETMENU2Utilities.GetCategory(ProductIDs);     //  2006.09.29  �ύX
            DataRow[] Category = SFNETMENU2Utilities.GetCategory(ProductIDs, true);

            for (int i = 0; i < Category.Length; i++)
            {
                //  �C���t�H���[�V�����̓J�e�S���ɂ��Ȃ�                           
                if (Category[i]["DisplayOption"].ToString().ToUpper() == "I")
                {
                    CategoryInfomation ciinf = new CategoryInfomation();
                    ciinf.Name = "�C���t�H���[�V����";
                    ciinf.Icon = grpButton.ImageList.Images[Convert.ToInt32(Category[i]["IconIndex"])];
                    TabPage tbinf = CreateTabMenubPage(ciinf);
                    tabMenu.SelectedTab = tbinf;
                    WebBrowser wbn = new WebBrowser();
                    wbn.Parent = tbinf;
                    wbn.Dock = DockStyle.Fill;
                    gServiceTopPage = Program.arm.GetAPServiceTargetDomain(Category[i]["Description"].ToString());
                    wbn.Navigate(gServiceTopPage);
                }
            }
        }
        //2008.09.26 sugi --<<

        //2008.09.26 sugi --<<
        private void btnFwd_Click(object sender, EventArgs e)
        {
            //  �X�e�[�^�X�o�[����                                                      
            stsInfo1.Text = "";

            TabPage tb = tabMenu.SelectedTab;
            for (int j = 0; j < tb.Controls.Count; j++)
            {
                //  Web�Ȃ�
                if (tb.Controls[j].GetType() == typeof(WebBrowser))
                {

                    WebBrowser wb = (WebBrowser)tb.Controls[j];
                    wb.GoForward();
                    break;

                }

            }

        }
        //2008.09.26 sugi --<<

        //2008.09.26 sugi --<<
        private void btnBack_Click(object sender, EventArgs e)
        {
            //  �X�e�[�^�X�o�[����                                                     
            stsInfo1.Text = "";

            TabPage tb = tabMenu.SelectedTab;
            for (int j = 0; j < tb.Controls.Count; j++)
            {
                //  Web�Ȃ�
                if (tb.Controls[j].GetType() == typeof(WebBrowser))
                {

                    WebBrowser wb = (WebBrowser)tb.Controls[j];
                    wb.GoBack();
                    break;

                }

            }

        }

    

        /// <summary>
        /// �N���C�A���g�f�B���N�g���̑��݃`�F�b�N�A�쐬����
        /// </summary>
        /// <returns></returns>
        private void CheckProductDataRoot()
        {
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_DATA_ROOT);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_PRTPOS);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_Temp);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_Temp_OfflineDownload);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_Temp_UserTemp);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_UISettings);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_UISettings_FormPos);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_UISettings_GridInfo);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_LocalApplicationData);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_LocalApplicationData_OfflineSaveData);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_LocalApplicationData_AppSettingData);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_MenuSettings);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_MenuSettings_AppSettingData);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_GraphicsCache);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_GraphicsCache_Image);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_GraphicsCache_Shape);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_GraphicsCache_Thumbnail);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_FREEPOS);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_FREEPOS_PRTPOS);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_FREEPOS_PRTITEM);
            this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_FREEPOS_PRTSCHEMA);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_HANDY);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_HANDY_HDRECV);
            //this.CheckExistAndMakeDirectry(Broadleaf.Application.Common.ProductUsesPathGenerator.PRODUCT_HANDY_HDSEND);
        }

        /// <summary>
        /// �f�B���N�g���̑��݃`�F�b�N�A�쐬����
        /// </summary>
        /// <returns></returns>
        private void CheckExistAndMakeDirectry(string checkPath)
        {
            if (!Directory.Exists(checkPath))
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(checkPath);
                }
                catch (UnauthorizedAccessException uae)
                {
                    // �f�B���N�g���̍쐬�Ɏ��s�����ꍇ
                    MessageBox.Show(uae.Message);
                }
            }
        }
        //2008.09.26 sugi --<<

        //--- ADD 2011/06/29 M.Kubota --->>>
        private void spltCategory_Panel2_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (vGroupButtonScrollBar.Visible)
            {
                // e.Location �̓t�H�[������Ƃ������W�Ȃ̂ŁA��x�X�N���[�����W�ɕϊ����Ă���
                // �p�l������Ƃ������W�ɕϊ����ă`�F�b�N�������s���B
                Point scrPos = this.PointToScreen(e.Location);
                Point pnlPos = spltCategory.Panel2.PointToClient(scrPos);
                
                if (spltCategory.Panel2.Bounds.Contains(pnlPos))
                {
                    int sign = (e.Delta > 0) ? -1 : 1;                                                     // ��]�����̒��o
                    int value = vGroupButtonScrollBar.Value + (vGroupButtonScrollBar.LargeChange * sign);  // �ړ��ʂ̎Z�o

                    // ���K���킹
                    if (value < vGroupButtonScrollBar.Minimum)
                    {
                        value = vGroupButtonScrollBar.Minimum;
                    }
                    else if (value >= (vGroupButtonScrollBar.Maximum - vGroupButtonScrollBar.LargeChange + 1))
                    {
                        // LargeChange + 1 �̒l�Œ�������̂́A�X�N���[���o�[�̎d�l�̈�
                        // �����[�U�[����ɂ���� Value �� Maximum �ɂȂ�Ȃ���
                        value = vGroupButtonScrollBar.Maximum - vGroupButtonScrollBar.LargeChange + 1;
                    }

                    vGroupButtonScrollBar.Value = value;  // ���ۂ̈ړ��� ValueChanged �C�x���g�ōs����
                }
            }
        }
        
        private void spltCategory_Panel2_Resize(object sender, EventArgs e)
        {
            // �R���e�i�ƃ{�^��'s�̍������r���ăX�N���[���̗L����ݒ肷��
            int _width = spltCategory.Panel2.Width - 2;

            if (spltCategory.Panel2.Height < grpButton.Height)
            {
                // ���T�C�Y�ɔ����X�N���[���o�[�̍ő�ʂ��Đݒ�
                vGroupButtonScrollBar.Maximum = grpButton.Height - spltCategory.Panel2.Height + (vGroupButtonScrollBar.LargeChange - 1);

                if (!vGroupButtonScrollBar.Visible)
                {
                    // ���X�N���[���o�[���o�Ȃ��l�ɕ��𒲐�����
                    grpButton.Width = _width - SystemInformation.VerticalScrollBarWidth;
                    vGroupButtonScrollBar.Visible = true;
                }
            }
            else
            {
                if (vGroupButtonScrollBar.Visible)
                {
                    grpButton.Width = _width;
                    vGroupButtonScrollBar.Value = 0;
                    vGroupButtonScrollBar.Visible = false;
                }
            }
        }

        private void vGroupButtonScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (vGroupButtonScrollBar.Value == 0)
            {
                grpButton.Top = 0;  // Value = 0 �̏ꍇ�͏�ӂ��҂����荇�킹��
            }
            else
            {
                grpButton.Top = -(vGroupButtonScrollBar.Value + 2);  // +2 �̓{�^���̒�ӂ��\�����؂�l�ɒ�����������
            }
        }
        //--- ADD 2011/06/29 M.Kubota ---<<<

        // --- ADD 2021/01/05 ���� ---------->>>>>
        /// <summary>
        /// �N��PG���엚�����O�o��
        /// </summary>
        /// <param name="mii">���j���[�A�C�e�����</param>
        /// <param name="methodName">���s���\�b�h��</param>
        /// <remarks>
        /// <br>Note       :���j���[���O�o�͑Ή�</br>
        /// <br>Programmer  : 32470 ����</br>
        /// <br>Date        : 2021.01.07</br>
        /// </remarks>
        private void StartPgOperationLogOutput(MenuItemInfomation mii, string methodName)
        {
            try
            {
                if (_operationHistoryLog != null)
                {
                    // �J�e�S�����擾�i1�s�j
                    DataRow[] categoryInfo = SFNETMENU2Utilities.GetCategory(mii.CategoryID, true);

                    // �T�u�J�e�S�����擾
                    DataRow[] categorySubInfo = SFNETMENU2Utilities.GetSubCategory(mii.CategoryID, mii.CategorySubID);

                    // �N��PG��񐶐�
                    // �J�e�S�����.Name�{","�{�T�u�J�e�S�����.Name�{","�{�A�C�e�����.Name�{","�{�A�C�e�����.PgId�{","�{�J�e�S�����.DisplayOption
                    string logMsg = string.Format("{0},{1},{2},{3},{4}", categoryInfo[0]["Name"], categorySubInfo[0]["Name"], mii.Name, mii.Pgid, categoryInfo[0]["DisplayOption"]);

                    // ���엚�����O�o��
                    _operationHistoryLog.WriteOperationLog(this, DateTime.Now, (LogDataKind)MenuLog, cProgramId, cProgramName, methodName, cLogDataOperationCdStart, (int)ConstantManagement.MethodResult.ctFNC_NORMAL, logMsg, string.Empty);
                }
            }
            catch (Exception ex)
            {
                // �G���[�����O�o��
                try
                {
                    if (_clientLogTextOut != null)
                    {
                        _clientLogTextOut.Output(cClassId, methodName + ":�N��PG���O�o�̓G���[", (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                    }
                }
                catch
                {
                    // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                }
            }
        }
        // --- ADD 2021/01/05 ���� ---------->>>>>
    }
}