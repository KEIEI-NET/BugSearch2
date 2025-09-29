using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
// --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
using System.IO;
using Broadleaf.Application.Resources;
// --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>UpDateNote : �K�C�h�̋@�����[�h���w��o����悤�ɏC��</br>
    /// <br>             ���ʃK�C�h�̏ꍇ�̃t�H�[�J�X�̏C��</br>
    /// <br>             ���[�h�؂�ւ����̉�ʂ̂�������C��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009.07.13</br>
    /// <br>UpDateNote : ���ʏ��\���ݒ莞�̉�ʕ\���ʒu�C��</br>
    /// <br>Programmer : 980035 ���� ��`</br>
    /// <br>Date       : 2009.08.01</br>
    /// <br>UpDateNote : ���ʑI�����ɁA�擪�̕��ʂɊY������BL�R�[�h���P���������G���[�ɂȂ錏�̏C���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.08.06</br>
    /// <br>UpDateNote : �a�k�R�[�h�����a�k�R�[�h����(�S�p)����a�k�R�[�h����(���p)�ɕύX����B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2010/06/08</br>
    /// <br>
    /// <br>UpDateNote : ���`����K�C�h�N�����ɗ����܂�</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2010/06/28</br>
    /// <br>
    /// <br>UpDateNote : �@���ʑI���ła�k�R�[�h�I���ł��܂���</br>
    /// <br>           : �A�K�C�h�K�C�h�������N���ݒ肷��ƊY���f�[�^����܂���B�ɂȂ�</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2010/07/13</br>
    /// <br>Update Note: 2013/01/24 yangmj </br>
    /// <br>           : 10806793-00�ARedmine#33919�̑Ή�</br>
    /// <br>           : ������͂ƌ������ςŕ��ʃ}�X�^�̐ݒ�ʂ�̌������ʂɂȂ�Ȃ�</br>
    /// <br>Update Note: 2013/02/06 donggy </br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M</br>
    /// <br>           : Redmine#33919�̑Ή�</br>
    /// <br>Update Note: 2016/01/13 �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
    /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
    /// <br>Update Note: 2016/02/03 �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
    /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
    /// <br>Update Note: 2016/02/16 �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ��Q�ꗗNo.252 BL�R�[�h�I��(���ʕ�)��ʂŁA���������폜��ɖ��̍i�������t�H�[�J�X����Ȃ���Q�̑Ή�</br>
    /// <br>Update Note: 2016/02/17  �c����</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : �@���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���ύX</br>
    /// <br>           : �A�A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J�ڂ̑Ή�</br>
    /// <br>Update Note: 2016/02/25 �e�c���V</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���</br>
    /// <br>Update Note: 2016/12/26 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11270116-00 ����`�[���̓p�b�P�[�W�o�חp�\�[�X�̃}�[�W</br>
    /// <br>             Designer.cs�̏C��</br>
    /// <br>Update Note: K2021/04/19 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00 PMKOBETSU-4130</br>
    /// <br>             �a�k�b�c�K�C�h�������Ə�Q�̑Ή�</br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {

        # region �ϐ���`
        private const string Pure_Search = "����";
        private const string Prime_Search = "�D��";
        private const string CarInfo_Search = "TBO";
        private BlInfo _blInfoTable = null;
        internal BLInfoDataTable _orgBlInfoTable = null;
        private Dictionary<int, BLGoodsCdUMnt> _orgBLList;
        private ArrayList partsPosList;

        /// <summary>�Ώۂ̂ݕ\���p</summary>
        private string rowFilter1 = string.Empty;
        /// <summary>���ʕʕ\���p</summary>
        private string rowFilter2 = string.Empty;
        /// <summary>BL�R�[�h���i���p</summary>
        private string rowFilter3 = string.Empty;
        /// <summary>���_�R�[�h�iBL�R�[�h�K�C�h�\���p�j</summary>
        private string _sectionCd;
        /// <summary>���Ӑ�R�[�h�iBL�R�[�h�K�C�h�\���p�j</summary>
        private int _customerCode;
        private bool flipflopFlg = false;
        private SelectionForm2 frmBLAll = null;

        private List<int> retLstBl = null;

        private Thread prepareThread;

        private SelectionOfrBL.GuideMode _guideMode;
        // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
        // BL�R�[�h�ƕ��ʃR�[�h�֘A�p
        private Dictionary<int, string> rowPosDic = new Dictionary<int, string>();
        private Dictionary<int, string> rowPosBlDic = new Dictionary<int, string>();
        private List<string> blCdList = new List<string>();
        // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
        private int time_count;//ADD 2016/02/17 �c���� Redmine#48587

        // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
        private RetrySet RetrySettingInfo = null;
        // ���g���C�ݒ�XML�t�@�C��
        private const string XmlFileName = "PMKEN08140U_UserSetting.xml";
        // ���g���C��-�f�t�H���g�F3��
        private const int CtRetryCount = 3;
        // ���g���C�Ԋu-�f�t�H���g�F3�b
        private const int CtRetryInterval = 3000;
        // �[��
        private const int CtCount = 0;
        // �X���[�v���ԁF50ms
        private const int CtSleepMs = 50;
        // �N���C�A���g���O�o�͓��e
        private const string ErrorMessage = "PMKEN08140UB SearchPartsPosList ���ʃf�[�^�擾�ŗ�O�����A���_�R�[�h:{0}�A���Ӑ�R�[�h:{1}�A�K�C�h�N�����[�h:{2}�A���g���C��:{3}";
        // ���i�ʕ\���G���[���e
        private const string ErrMesShowByPos = "PMKEN08140UB ShowByPos ���ʕʕ\�������ŗ�O�����A���_�R�[�h:{0}�A���Ӑ�R�[�h:{1}�A�K�C�h�N�����[�h:{2}";
        // �ُ탁�b�Z�[�W
        private const string BLGuidErMes = "���ʏ��̌������ɃG���[���������܂����B\r\n���΂炭���Ԃ�u���čēx�������s�Ȃ��Ă��������B";
        // PGID
        private const string CtPGID = "PMKEN08140U";
        // ���O�o�͕��i
        OutLogCommon LogCommon;
        // ���񃁃b�Z�[�W�\��
        private bool ErrMesFirst = false;
        // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
        # endregion

        #region [ �R���X�g���N�^ ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="blTable">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        /// <param name="blList"></param>
        /// <param name="sectionCd"></param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="guideMode">�K�C�h�N�����[�h</param>
        //public SelectionForm(BLInfoDataTable blTable, Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd, int customerCode)
        public SelectionForm(BLInfoDataTable blTable, Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd, int customerCode, SelectionOfrBL.GuideMode guideMode)
        {
            //>>>2010/07/13
            _sectionCd = sectionCd;
            _customerCode = customerCode;
            _guideMode = guideMode; // 2009/07/13
            //<<<2010/07/13

            //>>>2010/06/28
            _orgBlInfoTable = blTable;
            _orgBLList = blList;
            //<<<2010/06/28

            GetXmlInfo(); // ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή�
            _blInfoTable = new BlInfo();
            prepareThread = new Thread(DoPrepare);
            prepareThread.Start();
            InitializeComponent();
            // DataTable �̐ݒ�
            //>>>2010/06/28
            //_orgBlInfoTable = blTable;
            //_orgBLList = blList;
            //<<<2010/06/28

            //>>>2010/07/13
            //_sectionCd = sectionCd;
            //_customerCode = customerCode;
            //_guideMode = guideMode; // 2009/07/13
            //<<<2010/07/13

            InitializeTable();
            InitializeForm();
            RefreshDataCount();

            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.Opacity = 0;
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion

        #region [ �������� ]
        private void InitializeForm()
        {
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_All"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            ToolbarsManager.Tools["Button_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PARTSSELECT;
            ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.LABEL;
            ToolbarsManager.Tools["Button_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            if (_orgBlInfoTable.Count == 0)
            {
                //ToolbarsManager.Tools["Button_All"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Search"].SharedProps.Visible = false;
            }
        }

        private void InitializeTable()
        {
            // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
            while (Monitor.TryEnter(_blInfoTable) == false)
                Thread.Sleep(50);
            // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
            gridBLInfo.BeginUpdate();
            gridBLInfo.DataSource = _blInfoTable.BL.DefaultView;
            gridBLInfo.EndUpdate();

            gridPartsPosInfo.BeginUpdate();
            gridPartsPosInfo.DataSource = _blInfoTable.Pos.DefaultView;
            gridPartsPosInfo.EndUpdate();
            // --- DEL K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
            //while (Monitor.TryEnter(_blInfoTable) == false)
            //    Thread.Sleep(50);
            // --- DEL K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
            if (_orgBlInfoTable.Count > 0)
            {
                rowFilter1 = String.Format("{0}<>''", _blInfoTable.BL.SearchMethodColumn.ColumnName);
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter1;
                ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
            }
            Monitor.Exit(_blInfoTable);
            //ChangeToolColor("Button_Search");
        }

        private void DoPrepare()
        {
            Monitor.Enter(_blInfoTable);
            // --- UPD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
            //PartsPosCodeUAcs partsPosCdAcs = new PartsPosCodeUAcs();
            //partsPosCdAcs.SearchAll(out partsPosList, LoginInfoAcquisition.EnterpriseCode);
            int retryCnt = 0;
            SearchPartsPosList(ref retryCnt);
            // --- UPD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
            InitializeData();
            Monitor.Exit(_blInfoTable);
            frmBLAll = new SelectionForm2(this, _blInfoTable.BL, _sectionCd);
        }

        // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
        /// <summary>
        /// ���ʃf�[�^�擾����
        /// </summary>
        /// <param name="retryCnt">���g���C��</param>
        /// <remarks>
        /// <br>Note         : ���ʃf�[�^�擾�������s��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void SearchPartsPosList(ref int retryCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                PartsPosCodeUAcs partsPosCdAcs = new PartsPosCodeUAcs();
                retryCnt++;
                status = partsPosCdAcs.SearchAll(out partsPosList, LoginInfoAcquisition.EnterpriseCode);
                //�������s�̏ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ���g���C�������s��
                    RetrySearchPartsPosList(ref retryCnt, null);
                }
            }
            catch (Exception ex)
            {
                // ���g���C�������s��
                RetrySearchPartsPosList(ref retryCnt, ex);
            }
        }

        /// <summary>
        /// ���ʃf�[�^�擾���g���C����
        /// </summary>
        /// <param name="retryCnt">���g���C��</param>
        /// <param name="ex">��O���e</param> 
        /// <remarks>
        /// <br>Note         : ���ʃf�[�^�擾���g���C�������s��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void RetrySearchPartsPosList(ref int retryCnt, Exception ex)
        {
            // ���O�o��
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            string message = string.Format(ErrorMessage, _sectionCd, _customerCode, _guideMode, retryCnt);
            LogCommon.OutputClientLog(CtPGID, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            // ���g���C�񐔂܂�
            if (retryCnt >= RetrySettingInfo.RetryCount)
            {
                // �����Ȃ�
            }
            else
            {
                System.Threading.Thread.Sleep(RetrySettingInfo.RetryInterval);

                // ���g���C�������s��
                SearchPartsPosList(ref retryCnt);
            }
        }

        /// <summary>
        /// �ُ탁�b�Z�[�W��\��
        /// </summary>
        /// <param name="ex">��O���e</param> 
        /// <remarks>
        /// <br>Note         : �ُ탁�b�Z�[�W��\��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void ExcetionShow(Exception ex)
        {
            //����ł͂Ȃ�
            if (ErrMesFirst)return;

            ErrMesFirst = true;
            // ���O�o��
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            string message = string.Format(ErrMesShowByPos, _sectionCd, _customerCode, _guideMode);
            LogCommon.OutputClientLog(CtPGID, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            // ���b�Z�[�W���o�͂��K�C�h�Ƃ��Đ������I��
            TMsgDisp.Show(
                        null,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        string.Empty,
                        BLGuidErMes,
                        0,
                        MessageBoxButtons.OK);
            this.Close();
        }

        /// <summary>
        /// XML���擾
        /// </summary>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void GetXmlInfo()
        {
            try
            {
                RetrySettingInfo = new RetrySet();

                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName)))
                {
                    // XML���烊�g���C�񐔂ƃ��g���C�Ԋu���擾����
                    RetrySettingInfo = UserSettingController.DeserializeUserSetting<RetrySet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName));
                }
                else
                {
                    // ���g���C��-�f�t�H���g�F3��
                    RetrySettingInfo.RetryCount = CtRetryCount;
                    // ���g���C�Ԋu-�f�t�H���g�F3�b
                    RetrySettingInfo.RetryInterval = CtRetryInterval;
                }
            }
            catch
            {
                if (RetrySettingInfo == null) RetrySettingInfo = new RetrySet();
                // ���g���C��-�f�t�H���g�F3��
                RetrySettingInfo.RetryCount = CtRetryCount;
                // ���g���C�Ԋu-�f�t�H���g�F3�b
                RetrySettingInfo.RetryInterval = CtRetryInterval;
            }
        }
        // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<

        /// <summary>
        /// �\���p�f�[�^��DataTable�ɓo�^���邽�߂̃T�u�X���b�h
        /// </summary>
        /// <br>Update Note: 2010/06/08 ���M PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// <br>             �a�k�R�[�h�����a�k�R�[�h����(�S�p)����a�k�R�[�h����(���p)�ɕύX����B</br>
        private void InitializeData()
        {
            _blInfoTable.BL.BeginLoadData();
            try
            {
                foreach (BLGoodsCdUMnt blGoodsCdUMnt in _orgBLList.Values)
                {
                    BlInfo.BLRow wkRow = wkRow = _blInfoTable.BL.NewBLRow();

                    wkRow.BLCd = blGoodsCdUMnt.BLGoodsCode;
                    // -------UPD 2010/06/08------->>>>>
                    //wkRow.BLName = blGoodsCdUMnt.BLGoodsFullName;
                    wkRow.BLName = blGoodsCdUMnt.BLGoodsHalfName;
                    // -------UPD 2010/06/08-------<<<<<

                    _blInfoTable.BL.AddBLRow(wkRow);
                }

                foreach (PartsPosCodeU partsPosCode in partsPosList)
                {
                    if (partsPosCode.CustomerCode != _customerCode && partsPosCode.CustomerCode != 0) // �w�蓾�Ӑ�łȂ���
                        continue;
                    if (partsPosCode.TbsPartsCode != 0 && // BL�R�[�h0�͕��ʖ��̗p�Ȃ̂ŏ��O
                        _blInfoTable.BL.FindByBLCd(partsPosCode.TbsPartsCode) != null) // �����\�ȑΏ�BL�ȊO�͏��O
                    {
                        BlInfo.PartsPosRow partsPosRow = _blInfoTable.PartsPos.NewPartsPosRow();

                        partsPosRow.PosCd = partsPosCode.SearchPartsPosCode;
                        partsPosRow.CustomerCode = partsPosCode.CustomerCode;
                        partsPosRow.BLCd = partsPosCode.TbsPartsCode;
                        partsPosRow.PosDispOrder = partsPosCode.PosDispOrder;

                        _blInfoTable.PartsPos.AddPartsPosRow(partsPosRow);
                    }
                    string pos = partsPosCode.SearchPartsPosCode.ToString("00");
                    if ((partsPosCode.CustomerCode == 0 && _blInfoTable.Pos.FindByPosCd(pos) == null) ||
                        (partsPosCode.CustomerCode != 0 && _blInfoTable.Pos.FindByPosCd("[" + pos + "]") == null))
                    {
                        BlInfo.PosRow posRow = _blInfoTable.Pos.NewPosRow();
                        if (partsPosCode.CustomerCode == 0)
                            posRow.PosCd = pos;
                        else
                            posRow.PosCd = "[" + pos + "]";
                        posRow.PosName = partsPosCode.SearchPartsPosName;
                        _blInfoTable.Pos.AddPosRow(posRow);
                    }
                }
                _blInfoTable.Pos.DefaultView.Sort = _blInfoTable.Pos.PosCdColumn.ColumnName;

                if (_orgBlInfoTable.Count > 0)
                {
                    for (int i = 0; i < _orgBlInfoTable.Count; i++)
                    {
                        BlInfo.BLRow wkRow = _blInfoTable.BL.FindByBLCd(_orgBlInfoTable[i].TbsPartsCode);
                        if (wkRow != null)
                        {
                            int searchFlg = _orgBlInfoTable[i].PrimeSearchFlg;
                            if (_orgBlInfoTable[i].PrimeSearchFlg != 0)
                            {
                                wkRow.SearchMethod = Prime_Search;
                            }
                            else if (_orgBlInfoTable[i].EquipGenreCode != 0)
                            {
                                wkRow.SearchMethod = CarInfo_Search;
                            }
                            else
                            {
                                wkRow.SearchMethod = Pure_Search;
                            }
                        }
                    }
                }
            }
            finally
            {
                _blInfoTable.BL.EndLoadData();
            }
        }
        #endregion

        #region ColInfo�@�C���^�[�i��

        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }

        }


        #endregion

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //gridBLInfo.BeginUpdate();
            //try
            //{
            //    gridBLInfo.DataSource = null;
            //}
            //finally
            //{
            //    gridBLInfo.EndUpdate();
            //}
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// �K�C�h��ʂ̕\��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g</param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/03 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���B</br>
        /// <br>Update Note: K2021/04/19 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00 PMKOBETSU-4130</br>
        /// <br>             �a�k�b�c�K�C�h�������Ə�Q�̑Ή�</br>
        /// </remarks>
        private void SelectionForm_Shown(object sender, EventArgs e)
        {
            // �擪�s��I����Ԃɂ���
            if (gridBLInfo.Rows.Count > 0)
                gridBLInfo.Rows[0].Selected = true;
            this.StartPosition = FormStartPosition.Manual;

            //----- ADD 2016/01/13 �c���� Redmine#48587 ----->>>>>
            // �����t�H�[�J�X�F���̍i���ɐݒ肵�A�u�B���v���`�F�b�N�I��
            if (_guideMode == SelectionOfrBL.GuideMode.BLCode)
            {
                this.OptionSearch.CheckedIndex = 1;
                //this.txtName.Focus();//DEL 2016/02/17 �c���� Redmine#48587
                this.chkSearch.Checked = true;//ADD 2016/02/03 �c���� Redmine#48587
            }
            //----- ADD 2016/01/13 �c���� Redmine#48587 -----<<<<<

            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>
            if (_guideMode == SelectionOfrBL.GuideMode.PartsPos)
            {
                ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
                // �X���b�h�������̏ꍇ�A�X���[�v�F50ms
                if (prepareThread.ThreadState == ThreadState.Running)
                {
                    while (prepareThread.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(CtSleepMs);
                    }
                }
                // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
                //���ʃK�C�h�\��
                ShowByPos(true);

                this.Opacity = 1;
            }
            else
                if (_guideMode == SelectionOfrBL.GuideMode.BLGuide)
                {
                    //BL�R�[�h�K�C�h�\��
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                    flipflopFlg = false;
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(50);
                        }
                    }

                    this.Opacity = 0;

                    RetType result;
                    DialogResult ret = frmBLAll.ShowDialog(out retLstBl, out result, true);
                    switch (result)
                    {
                        case RetType.ShowPos:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                            this.Opacity = 1;
                            break;
                        case RetType.ShowSearch:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false; // ADD 2016/01/13 �c���� Redmine#48587
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                            this.Opacity = 1;
                            break;
                        case RetType.OK:
                            DialogResult = DialogResult.OK;
                            break;
                        case RetType.Cancel:
                            DialogResult = DialogResult.Cancel;
                            break;
                    }

                }
                else
                {
                    this.Opacity = 1;
                }
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// �A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17  �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �A�A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J�ڂ̑Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == txtName)
            {
                if (gridPartsPosInfo.Visible)
                    gridPartsPosInfo.Select();
                else
                    gridBLInfo.Select();
            }
            //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
            switch (e.Key)
            {
                case Keys.Enter:
                case Keys.Tab:
                    //SHIFT�������Ȃ�
                    if (!e.ShiftKey)
                    {
                        //���������@�O���E�B���˃O���b�h
                        if (e.PrevCtrl == OptionSearch)
                        {
                            if (gridPartsPosInfo.Visible)
                            {
                                e.NextCtrl = gridPartsPosInfo;
                            }
                            else
                            {
                                e.NextCtrl = gridBLInfo;
                            }
                        }
                    }
                    else
                    {
                        //���������@�O���E�B���ˎ�������
                        if (e.PrevCtrl == OptionSearch)
                        {
                            e.NextCtrl = this.chkSearch;
                        }
                        //BL���ʕ�
                        if (gridPartsPosInfo.Visible)
                        {
                            if (e.PrevCtrl == txtName)
                            {
                                e.NextCtrl = this.gridBLInfo;
                            }
                        }
                    }
                    break;
                case Keys.Down:
                    //BL���ʕ�
                    if (gridPartsPosInfo.Visible)
                    {
                        //���������A���������@�O���E�B�� ��BL�R�[�h�O���b�h
                        if (e.PrevCtrl == chkSearch || e.PrevCtrl == OptionSearch)
                        {
                            e.NextCtrl = gridBLInfo;
                        }
                    }
                    break;
            }
            //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
        }
        #endregion

        internal DialogResult ShowDialog(out List<int> lstBlCd)
        {
            lstBlCd = null;
            DialogResult ret = base.ShowDialog();
            if (ret == DialogResult.OK)
            {
                //>>>2010/07/13
                //if (retLstBl != null) // PMKEN08140UC��BL���X�g�����܂����炻���Ԃ��B
                if ((retLstBl != null) && (retLstBl.Count != 0)) // PMKEN08140UC��BL���X�g�����܂����炻���Ԃ��B
                //<<<2010/07/13
                {
                    lstBlCd = retLstBl;
                }
                else
                {
                    lstBlCd = new List<int>();
                    //-----ADD yangmj 2013/01/24 for redmine#33919 ----->>>>>
                    bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
                    // ���ʈȊO�̏ꍇ�A����������ێ�
                    if (!chk)
                    {
                    //-----ADD yangmj 2013/01/24 for redmine#33919 -----<<<<<
                        for (int i = 0; i < _blInfoTable.BL.Count; i++)
                        {
                            if (_blInfoTable.BL[i].SelectionState)
                            {
                                lstBlCd.Add(_blInfoTable.BL[i].BLCd);
                            }
                        }
                    //-----ADD yangmj 2013/01/24 for redmine#33919 ----->>>>>
                    }
                    else
                    {
                        // --- DEL donggy 2013/02/06 for Redmine#33919 --->>>>>>
                        // ���ʂ̏ꍇ�A��ʕ\�����ŁA�߂�l��ݒ肷��
                        //for (int i = 0; i < _blInfoTable.Pos.DefaultView.Count; i++)
                        //{
                        //    //���ʂ��A��L�R�[�h��filter
                        //    string tmpFilter;
                        //    string pos = gridPartsPosInfo.Rows[i].Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
                        // --- DEL donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                        //�@���ʃR�[�h�Ƃa�k�R�[�h�̑I������
                        if (!splitContainer1.Panel1Collapsed)// ���ʃR�[�h�\���̏ꍇ
                        {
                            Dictionary<int, string>.KeyCollection keys = rowPosDic.Keys;
                            Dictionary<int, string>.KeyCollection keysBL = rowPosBlDic.Keys;
                            int[] keyArray = new int[keys.Count];
                            int[] keyBLArray = new int[keysBL.Count];
                            keys.CopyTo(keyArray, 0);
                            keysBL.CopyTo(keyBLArray, 0);
                            List<int> keyList = new List<int>();
                            //���ڑI���������ʃR�[�h�̍s�ԍ��̎擾
                            for (int i = 0; i < keyArray.Length; i++)
                            {
                                keyList.Add(keyArray[i]);
                            }
                            //�I�������a�k�R�[�h�ɂ���āA�I���������ʃR�[�h�̍s�ԍ��̎擾
                            for (int i = 0; i < keyBLArray.Length; i++)
                            {
                                if (!keyList.Contains(keyBLArray[i]))
                                {
                                    keyList.Add(keyBLArray[i]);
                                }
                            }
                            keyList.Sort();
                            //�I���������ʃR�[�h�ɂ���āA�a�k�R�[�h���擾����
                            for (int i = 0; i < keyList.Count; i++)
                            {
                                string tmpFilter;
                                string pos = string.Empty;
                                //���ʃR�[�h�̎擾
                                if (rowPosDic.ContainsKey(keyList[i]))
                                {
                                    pos = rowPosDic[keyList[i]].ToString();
                                }
                                else if (rowPosBlDic.ContainsKey(keyList[i]))
                                {
                                    pos = rowPosBlDic[keyList[i]].ToString();
                                }
                                else
                                {
                                    break;
                                }
                          // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                                if (pos.StartsWith("["))
                                {
                                    pos = pos.Substring(1, pos.Length - 2);
                                    tmpFilter = String.Format("{0} = {1} AND {2} <> 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                                    _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
                                }
                                else
                                {
                                    tmpFilter = String.Format("{0} = {1} AND {2} = 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                                    _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
                                }
                                _blInfoTable.PartsPos.DefaultView.RowFilter = tmpFilter;
                                rowFilter2 = "(";
                                for (int j = 0; j < _blInfoTable.PartsPos.DefaultView.Count; j++)
                                {
                                    BlInfo.PartsPosRow row = (BlInfo.PartsPosRow)_blInfoTable.PartsPos.DefaultView[j].Row;
                                    rowFilter2 += string.Format("{0} = {1} OR ", _blInfoTable.BL.BLCdColumn.ColumnName, row.BLCd);
                                    _blInfoTable.BL.FindByBLCd(row.BLCd).PosDispOrder = row.PosDispOrder;
                                }
                                rowFilter2 = rowFilter2.Remove(rowFilter2.Length - 4) + ")";

                                string rowFilter;
                                if (rowFilter1.Equals(string.Empty))
                                {
                                    rowFilter = rowFilter2;
                                }
                                else
                                {
                                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                                }

                                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                                _blInfoTable.BL.DefaultView.Sort = _blInfoTable.BL.PosDispOrderColumn.ColumnName;
                                //�I�����ꂽBL�R�[�h��߂�l��ݒ肷��
                                for (int n = 0; n < gridBLInfo.Rows.Count; n++)
                                {
                                    if ((bool)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value)
                                    {
                                        int blCd = (int)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value;
                                        if (!lstBlCd.Contains(blCd))
                                        {
                                            lstBlCd.Add(blCd);
                                        }
                                    }
                                }

                                rowFilter2 = string.Empty;
                            }
                        }
                        //-----ADD donggy 2013/02/06 for redmine#33919 ----->>>>>
                        // ���ʃR�[�h�\�����Ȃ��ꍇ
                        else
                        {
                            //�I�����ꂽBL�R�[�h��߂�l��ݒ肷��
                            for (int n = 0; n < gridBLInfo.Rows.Count; n++)
                            {
                                if ((bool)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value)
                                {
                                    int blCd = (int)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value;
                                    if (!lstBlCd.Contains(blCd))
                                    {
                                        lstBlCd.Add(blCd);
                                    }
                                }
                            }

                            rowFilter2 = string.Empty;
                        }
                        //-----ADD donggy 2013/02/06 for redmine#33919 -----<<<<<

                    }
                    //-----ADD yangmj 2013/01/24 for redmine#33919 -----<<<<<
                }
            }
            return ret;
        }

        #region [ �c�[���o�[�C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: K2021/04/19 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00 PMKOBETSU-4130</br>
        /// <br>             �a�k�b�c�K�C�h�������Ə�Q�̑Ή�</br>
        /// </remarks>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (flipflopFlg)
                return;
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            switch (e.Tool.Key)
            {
                case "Button_Select": // �I������Ă���s���m�肷��
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back": // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_All": // �S�\��
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = false;
                    flipflopFlg = false;
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(50);
                        }
                    }
                    if (frmBLAll == null) // ����I�ȏ�Ԃł͂��肦�Ȃ��P�[�X�����A�O�̂��ߓ���Ă����B
                    {
                        frmBLAll = new SelectionForm2(this, _blInfoTable.BL, _sectionCd);
                    }
                    // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                    //this.Visible = false;
                    this.Opacity = 0;
                    // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    RetType result;
                    DialogResult ret = frmBLAll.ShowDialog(out retLstBl, out result, false);
                    switch (result)
                    {
                        case RetType.ShowPos:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        case RetType.ShowSearch:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false; // ADD 2016/01/13 �c���� Redmine#48587
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        case RetType.OK:
                            DialogResult = DialogResult.OK;
                            break;
                        case RetType.Cancel:
                            DialogResult = DialogResult.Cancel;
                            break;
                    }
                    break;

                case "Button_Search": // �����\�Ώۂ̂ݕ\��
                    ShowBySearch(chk);
                    break;

                case "Button_Pos": // ���ʕʕ\������
                    // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
                    // �X���b�h�������̏ꍇ�A�X���[�v�F50ms
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(CtSleepMs);
                        }
                    }
                    // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
                    ShowByPos(chk);
                    break;

                case "Button_Guide": // BL�R�[�h�K�C�h�\��
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                    flipflopFlg = false;
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(50);
                        }
                    }

                    // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //this.Visible = false;
                    this.Opacity = 0;
                    // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    ret = frmBLAll.ShowDialog(out retLstBl, out result, true);
                    switch (result)
                    {
                        case RetType.ShowPos:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<< 
                            break;
                        case RetType.ShowSearch:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false; // ADD 2016/01/13 �c���� Redmine#48587
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>> 
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<
                            break;
                        case RetType.OK:
                            DialogResult = DialogResult.OK;
                            break;
                        case RetType.Cancel:
                            DialogResult = DialogResult.Cancel;
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// �����\�Ώۂ̂ݕ\��
        /// </summary>
        /// <param name="chk"></param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/03 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// </remarks>
        private void ShowBySearch(bool chk)
        {
            string rowFilter;
            if (((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked)
            {
                rowFilter1 = String.Format("{0}<>''", _blInfoTable.BL.SearchMethodColumn.ColumnName);
                if (rowFilter2.Equals(string.Empty))
                    rowFilter = rowFilter1;
                else
                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                flipflopFlg = true;
                ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = false;
                flipflopFlg = false;
                if (chk == false)
                {
                    if (gridBLInfo.Rows.Count > 0)
                    {
                        gridBLInfo.Rows[0].Activate();
                        if (gridBLInfo.Selected.Rows.Count > 0)
                        {
                            gridBLInfo.Select();
                            gridBLInfo.Selected.Rows[0].Activate();
                        }
                    }
                }
                SetSplitter(chk);
            }
            else
            {
                flipflopFlg = true;
                ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                flipflopFlg = false;
            }
            RefreshDataCount();

            //----- ADD 2016/01/13 �c���� Redmine#48587 ----->>>>>
            // �����t�H�[�J�X�F���̍i���ɐݒ肵�A�u�B���v���`�F�b�N�I��
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 �c���� Redmine#48587
            //----- ADD 2016/01/13 �c���� Redmine#48587 -----<<<<<
        }

        /// <summary>
        /// ���ʕʕ\������
        /// </summary>
        /// <param name="chk"></param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�����t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�t�H�[�J�X�𖼏̍i���ɏ����敪��B���ɂ���ύX</br>
        /// <br>Update Note: 2016/02/03 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �@�����\���������A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>           : �A��ʕ\��������AF5�AF6�AF7�AF8��ؑւ��A�u���������v���`�F�b�N�I���ɂ���ύX</br>
        /// <br>Update Note: K2021/04/19 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00 PMKOBETSU-4130</br>
        /// <br>             �a�k�b�c�K�C�h�������Ə�Q�̑Ή�</br>
        /// </remarks>
        private void ShowByPos(bool chk)
        {
            // --- UPD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
            //string rowFilter;
            string rowFilter = string.Empty;
            // --- UPD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
            //int blCode = 0;

            txtName.Clear();
            BLFiltering();
            //if (gridBLInfo.Selected.Rows.Count > 0)
            //{
            //    blCode = int.Parse(gridBLInfo.Selected.Rows[0].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
            //}
            //else
            //{
            //    return;
            //}
            SetSplitter(chk);
            // --- UPD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
            //if (chk)    // ���ʕ\��
            //{
            //    GridPosFiltering();

            //    if (rowFilter1.Equals(string.Empty))
            //        rowFilter = rowFilter2;
            //    else
            //        rowFilter = rowFilter1 + " AND " + rowFilter2;
            //}
            //else        // ���ʔ�\��
            //{
            //    rowFilter2 = string.Empty;
            //    rowFilter = rowFilter1;
            //}

            if (gridPartsPosInfo.Selected.Rows.Count == CtCount && chk)
            {
                ExcetionShow(null);
                return;
            }

            try
            {
                if (chk)
                {
                    GridPosFiltering();

                    if (rowFilter1.Equals(string.Empty))
                        rowFilter = rowFilter2;
                    else
                        rowFilter = rowFilter1 + " AND " + rowFilter2;
                }
                else        // ���ʔ�\��
                {
                    rowFilter2 = string.Empty;
                    rowFilter = rowFilter1;
                }

            }
            catch(Exception ex)
            {
                ExcetionShow(ex);
                return;
            }
            // --- UPD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
            _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
            if (chk)
            {
                _blInfoTable.BL.DefaultView.Sort = _blInfoTable.BL.PosDispOrderColumn.ColumnName;
                //gridPartsPosInfo.Rows[0].Activate();
                //gridPartsPosInfo.Rows[0].Selected = true;

                //int posCd = _blInfoTable.BL.FindByBLCd(blCode).PosCd;
                ////_blInfoTable.PartsPos.FindByPosCd(posCd);

                //for (int i = 0; i < gridPartsPosInfo.Rows.Count; i++)
                //{
                //    if (gridPartsPosInfo.Rows[i].Cells[_blInfoTable.PartsPos.PosCdColumn.ColumnName].Value.Equals(posCd))
                //    {
                //        gridPartsPosInfo.Rows[i].Selected = true;
                //        gridPartsPosInfo.Rows[i].Activate();
                //        break;
                //    }
                //}
                //for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                //{
                //    if (gridBLInfo.Rows[i].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.Equals(blCode))
                //    {
                //        gridBLInfo.Rows[i].Selected = true;
                //        gridBLInfo.Rows[i].Activate();
                //        break;
                //    }
                //}
                ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT2;
            }
            else
            {
                _blInfoTable.BL.DefaultView.Sort = string.Empty;
                //for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                //{
                //    if (gridBLInfo.Rows[i].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.Equals(blCode))
                //    {
                //        gridBLInfo.Select();
                //        gridBLInfo.Rows[i].Selected = true;
                //        gridBLInfo.Rows[i].Activate();
                //        break;
                //    }
                //}
                ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE2;
                
                gridBLInfo.Focus(); //2009/07/13
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.06 DEL
            //gridBLInfo.Rows[0].Activate();
            //gridBLInfo.Rows[0].Selected = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.06 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.06 ADD
            // �Y���s��������΃t�H�[�J�X�Z�b�g���Ȃ��B
            if ( gridBLInfo.Rows.Count > 0 )
            {
                gridBLInfo.Rows[0].Activate();
                gridBLInfo.Rows[0].Selected = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.06 ADD

            //----- ADD 2016/01/13 �c���� Redmine#48587 ----->>>>>
            // �����t�H�[�J�X�F���̍i���ɐݒ肵�A�u�B���v���`�F�b�N�I��
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 �c���� Redmine#48587
            //----- ADD 2016/01/13 �c���� Redmine#48587 -----<<<<<

            RefreshDataCount();
        }

        /// <summary>
        /// ���ʃO���b�h�t�B���^�����O����
        /// </summary>
        private void GridPosFiltering()
        {
            string tmpFilter;
            string pos = gridPartsPosInfo.Selected.Rows[0].Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
            if (pos.StartsWith("["))
            {
                pos = pos.Substring(1, pos.Length - 2);
                tmpFilter = String.Format("{0} = {1} AND {2} <> 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
            }
            else
            {
                tmpFilter = String.Format("{0} = {1} AND {2} = 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
            }
            _blInfoTable.PartsPos.DefaultView.RowFilter = tmpFilter;
            rowFilter2 = "(";
            for (int i = 0; i < _blInfoTable.PartsPos.DefaultView.Count; i++)
            {
                BlInfo.PartsPosRow row = (BlInfo.PartsPosRow)_blInfoTable.PartsPos.DefaultView[i].Row;
                rowFilter2 += string.Format("{0} = {1} OR ", _blInfoTable.BL.BLCdColumn.ColumnName, row.BLCd);
                _blInfoTable.BL.FindByBLCd(row.BLCd).PosDispOrder = row.PosDispOrder;
            }
            rowFilter2 = rowFilter2.Remove(rowFilter2.Length - 4) + ")";
        }

        /// <summary>
        /// ���ʏ��\���ݒ�
        /// </summary>
        /// <param name="flg">true:�\���^false:��\��</param>
        /// <br>Update Note: 2016/02/16 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ��Q�ꗗNo.252 BL�R�[�h�I��(���ʕ�)��ʂŁA���������폜��ɖ��̍i�������t�H�[�J�X����Ȃ���Q�̑Ή�</br>
        private void SetSplitter(bool flg)
        {
            splitContainer1.Panel1Collapsed = !flg;
            if (flg)
            {
                if (this.Width < 960)
                {
                    // 2009/08/01 >>>>>>>>>>>>>>>>>>>>>> 
                    //this.Left -= 300;
                    //this.Width = 960;
                    //if (this.Left < 200)
                    //    this.Left = 200;
                    //if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width - 200)
                    //{
                    //    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 200;
                    //}
                    this.Left -= 150;
                    this.Width = 960;
                    if (this.Left < 0)
                        this.Left = 0;
                    if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width)
                    {
                        this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                    }
                    // 2009/08/01 <<<<<<<<<<<<<<<<<<<<<<
                }
                if (gridPartsPosInfo.Selected.Rows.Count == 0 && gridPartsPosInfo.Rows.Count > 0)
                {
                    //gridPartsPosInfo.Select();//DEL 2016/02/16 �c���� Redmine#48587
                    gridPartsPosInfo.Rows[0].Activate();
                    gridPartsPosInfo.Rows[0].Selected = true;
                }
            }
            else
            {
                bool prevWidth = false;
                // 2009/08/01 >>>>>>>>>>>>>>>>>>>>>> 
                //if (this.Width > 660)
                //    prevWidth = true;
                //this.Width = 660;
                //if (prevWidth)
                //    this.Left += 300;
                //if (this.Left < 200)
                //    this.Left = 200;
                //if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width - 200)
                //{
                //    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 200;
                //}
                if (this.Width > 660)
                    prevWidth = true;
                this.Width = 660;
                if (prevWidth)
                    this.Left += 150;
                if (this.Left < 0)
                    this.Left = 0;
                if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                }
                // 2009/08/01 <<<<<<<<<<<<<<<<<<<<<<
                gridPartsPosInfo.Selected.Rows.Clear();
            }

        }
        #endregion

        #region [ �O���b�h�C�x���g���� ]
        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridBLInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            #region �O���b�h�̃��C�A�E�g������
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if (Band.Columns[Index].DataType == typeof(int) || Band.Columns[Index].DataType == typeof(double))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_blInfoTable.BL.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Band.Columns[_blInfoTable.BL.PosDispOrderColumn.ColumnName].Hidden = true;
            Band.Columns[_blInfoTable.BL.SelectionStateColumn.ColumnName].Hidden = true;
            Band.Columns[_blInfoTable.BL.BLCdColumn.ColumnName].Format = "00000";

            ColInfo.SetColInfo(Band, _blInfoTable.BL.SelImageColumn.ColumnName, 2, 0, 20);
            ColInfo.SetColInfo(Band, _blInfoTable.BL.BLCdColumn.ColumnName, 3, 0, 50);
            ColInfo.SetColInfo(Band, _blInfoTable.BL.BLNameColumn.ColumnName, 5, 0, 250);
            if (_orgBlInfoTable.Count == 0)
            {
                Band.Columns[_blInfoTable.BL.SearchMethodColumn.ColumnName].Hidden = true;
            }
            else
            {
                ColInfo.SetColInfo(Band, _blInfoTable.BL.SearchMethodColumn.ColumnName, 8, 0, 50);
            }

            #endregion
        }

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridBLInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (gridBLInfo.Selected.Rows.Count > 0)
            {
                gridBLInfo.Selected.Rows[0].Activate();
            }
            RefreshDataCount();
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M</br>
        /// <br>             Redmine#33919�Ή�</br>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �A�A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J�ڂ̑Ή�</br>>
        private void gridBLInfo_KeyDown(object sender, KeyEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // ���ʕ�
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (e.KeyCode == Keys.Enter)
            {
                //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
                //SHIFT�������Ȃ�
                if (!e.Shift)
                {
                    //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
                    if (gridBLInfo.ActiveRow != null)
                    {
                        if (gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            // BL�R�[�h��I�����ꂽ���ʃR�[�h�̍s�ԍ��̍폜
                            if (chk)
                            {
                                if (blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                                {
                                    blCdList.Remove(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                                }
                                if (blCdList.Count == 0)
                                {
                                    rowPosBlDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        }
                        else
                        {
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            // BL�R�[�h��I�����ꂽ���ʃR�[�h�̍s�ԍ��̒ǉ�
                            if (chk)
                            {
                                string posCd = gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
                                if (!rowPosBlDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                                {
                                    rowPosBlDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, posCd);
                                }
                                if (!blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                                {
                                    blCdList.Add(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        }
                        UltraGridRow ugr = this.gridBLInfo.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridBLInfo.UpdateData();
                    }
                //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
                }
                //SHIFT��������
                else
                {
                    if (gridBLInfo.ActiveRow != null)
                    {
                        UltraGridRow ugr = this.gridBLInfo.ActiveRow.GetSibling(SiblingRow.Previous);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridBLInfo.UpdateData();
                    }
                }
                //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
            }
            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>
            //���ʃK�C�h���[�h�̏ꍇ�Ɂ��������ꂽ�ꍇ�͕��ʃO���b�h�Ɉړ�
            else if (e.KeyCode == Keys.Left)
            {
                if (((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked == true)
                {
                    gridPartsPosInfo.Focus();
                    e.Handled = true;   //KeyDown�C�x���g�����
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked == true)
                {
                    e.Handled = true;   //KeyDown�C�x���g�����
                }
            }
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<
            //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
            //�O���b�h�̈�s�ځ��L�[���������ꂽ�ꍇ�͖��̍i���݂Ɉړ�
            if (e.KeyCode == Keys.Up)
            {
                if (gridBLInfo.Rows.Count > 0 && gridBLInfo.ActiveRow != null)
                {
                    if (gridBLInfo.ActiveRow.VisibleIndex == 0)
                    {
                        this.txtName.Focus();
                    }
                }
            }
            //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M</br>
        /// <br>             Redmine#33919�Ή�</br>
        private void gridBLInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            //���ʕ�
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (gridBLInfo.ActiveRow != null)
            {
                if (gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    // BL�R�[�h��I�����ꂽ���ʃR�[�h�̍s�ԍ��̍폜
                    if (chk)
                    {
                        if (blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                        {
                            blCdList.Remove(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                        }
                        if (blCdList.Count == 0)
                        {
                            rowPosBlDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                }
                else
                {
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    // BL�R�[�h��I�����ꂽ���ʃR�[�h�̍s�ԍ��̒ǉ�
                    if (chk)
                    {
                        string posCd = gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
                        if (!rowPosBlDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                        {
                            rowPosBlDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, posCd);
                        }
                        if (!blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                        {
                            blCdList.Add(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<

                }
                gridBLInfo.UpdateData();
            }
        }

        private void gridPartsPosInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Hidden = true;
            ColInfo.SetColInfo(Band, _blInfoTable.Pos.SelImageColumn.ColumnName, 2, 0, 20);
            ColInfo.SetColInfo(Band, _blInfoTable.Pos.PosCdColumn.ColumnName, 4, 0, 30);
            ColInfo.SetColInfo(Band, _blInfoTable.Pos.PosNameColumn.ColumnName, 7, 0, 160);
            Band.Columns[_blInfoTable.Pos.PosCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Band.Columns[_blInfoTable.Pos.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
        }

        private void gridPartsPosInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // ���ʕ�
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            blCdList = new List<string>();
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<
            string rowFilter;
            if (gridPartsPosInfo.Selected.Rows.Count > 0)
            {
                gridPartsPosInfo.Selected.Rows[0].Activate();

                GridPosFiltering();

                if (rowFilter1.Equals(string.Empty))
                    rowFilter = rowFilter2;
                else
                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                if (gridBLInfo.Rows.Count > 0)
                {
                    gridBLInfo.Rows[0].Activate();
                    gridBLInfo.Rows[0].Selected = true;
                }
            }

        }
        private void gridPartsPosInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // ���ʕ�
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (gridPartsPosInfo.ActiveRow != null)
            {
                if (gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = DBNull.Value;
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = false;
                    for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                    {
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    //�I�������̕��ʃR�[�h�̍s�ԍ��̍폜
                    if (chk)
                    {
                        if (rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                        {
                            rowPosDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                }
                else
                {
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = true;
                    for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                    {
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK]; ;
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    //�I�𕔈ʃR�[�h�̍s�ԍ��̒ǉ�
                    if (chk)
                    {
                        if (!rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                        {
                            rowPosDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString());
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                }
                gridPartsPosInfo.UpdateData();
                gridBLInfo.UpdateData();
            }
        }

        /// <summary>
        /// �u���i�ʁv���[�h�ŃO���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : �A�A���[�L�[�Aenter�Atab�̃t�H�[�J�X�J�ڂ̑Ή�</br>
        /// </remarks>
        private void gridPartsPosInfo_KeyDown(object sender, KeyEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // ���ʕ�
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (e.KeyCode == Keys.Enter)
            {
                //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
                //SHIFT�������Ȃ�
                if (!e.Shift)
                {
                    //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
                    if (gridPartsPosInfo.ActiveRow != null)
                    {
                        if (gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = DBNull.Value;
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = false;
                            for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                            {
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            //�I�������̕��ʃR�[�h�̍s�ԍ��̍폜
                            if (chk)
                            {
                                if (rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                                {
                                    rowPosDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        }
                        else
                        {
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = true;
                            for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                            {
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK]; ;
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            // �I�𕔈ʃR�[�_�̍s�ԍ��̒ǉ�
                            if (chk)
                            {
                                if (!rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                                {
                                    rowPosDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString());
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<
                        }
                        UltraGridRow ugr = gridPartsPosInfo.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridPartsPosInfo.UpdateData();
                        gridBLInfo.UpdateData();
                    }
                //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
                }
                //SHIFT��������
                else
                {
                    if (gridPartsPosInfo.ActiveRow != null)
                    {
                        UltraGridRow ugr = gridPartsPosInfo.ActiveRow.GetSibling(SiblingRow.Previous);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridPartsPosInfo.UpdateData();
                        gridBLInfo.UpdateData();
                    }
                }
                //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
            }
            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //���ʃR�[�h�O���b�h�Ł��������ꂽ�ꍇ��BL�R�[�h�O���b�h�Ɉړ�
            else if (e.KeyCode == Keys.Right)
            {
                if (gridBLInfo.Rows.Count != 0)
                {
                    gridBLInfo.Focus();
                }

                e.Handled = true;   //KeyDown�C�x���g�����
            }
            else if (e.KeyCode == Keys.Left)
            {
                e.Handled = true;   //KeyDown�C�x���g�����
            }
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
            //�O���b�h�̈�s�ځ��L�[���������ꂽ�ꍇ�͖��̍i���݂Ɉړ�
            else if ((e.KeyCode == Keys.Up))
            {
                if (gridPartsPosInfo.Rows.Count > 0 && gridPartsPosInfo.ActiveRow != null)
                {
                    if (gridPartsPosInfo.ActiveRow.VisibleIndex == 0)
                    {
                        this.txtName.Focus();
                    }
                }
            }
            //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
        }
        #endregion

        #region [ �t�B���^�����O ]
        private void txtName_ValueChanged(object sender, EventArgs e)
        {
            if (chkSearch.Checked && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (chkSearch.Checked == false && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void OptionSearch_ValueChanged(object sender, EventArgs e)
        {
            BLFiltering();
        }

        private void BLFiltering()
        {
            if (((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked == false)
            {
                string rowFilter;
                if (txtName.Text != string.Empty)
                {
                    if (OptionSearch.Value.Equals(true)) // �B������
                        rowFilter3 = string.Format("{0} like '%{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                    else // �O����v����
                        rowFilter3 = string.Format("{0} like '{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                }
                else
                {
                    rowFilter3 = string.Empty;
                }
                rowFilter = rowFilter1;
                if (rowFilter2 != string.Empty)
                {
                    if (rowFilter != string.Empty)
                        rowFilter += " AND ";
                    rowFilter += rowFilter2;
                }
                if (rowFilter != string.Empty && rowFilter3 != string.Empty)
                    rowFilter += " AND " + rowFilter3;
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                txtName.Tag = txtName.Text;
                if (gridBLInfo.Rows.Count > 0)
                    gridBLInfo.Rows[0].Selected = true;
                RefreshDataCount();
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---->>>>>>
            // ���ʕʂ̖��̍i���̒ǉ�
            else
            {
                
                if (txtName.Text != string.Empty)
                {
                    string rowFilter;
                    if (OptionSearch.Value.Equals(true)) // �B������
                        rowFilter3 = string.Format("{0} like '%{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                    else // �O����v����
                        rowFilter3 = string.Format("{0} like '{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                    SetSplitter(false);
                    rowFilter = rowFilter1;
                    if (rowFilter != string.Empty && rowFilter3 != string.Empty)
                        rowFilter += " AND " + rowFilter3;
                    _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                    _blInfoTable.BL.DefaultView.Sort = _blInfoTable.BL.BLCdColumn.ColumnName+" ASC";
                }
                else
                {
                    SetSplitter(true);
                }
                txtName.Tag = txtName.Text;
                if (gridBLInfo.Rows.Count > 0)
                    gridBLInfo.Rows[0].Selected = true;
                RefreshDataCount();
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 ----<<<<<<
        }
        #endregion

        /// <summary>
        /// [���y�[�W�^���y�[�W]�\���X�V
        /// </summary>
        private void RefreshDataCount()
        {
            int cnt = _blInfoTable.BL.DefaultView.Count;
            int current = 0;
            if (gridBLInfo.Selected.Rows.Count > 0)
                current = gridBLInfo.Selected.Rows[0].Index + 1;
            string cntMsg;
            cntMsg = string.Format("{0} / {1}", current, cnt);

            ToolbarsManager.Tools["lbl_Cnt"].SharedProps.Caption = cntMsg;
        }

        //----- ADD 2016/02/17 �c���� Redmine#48587 ----->>>>>
        /// <summary>
        /// ������͂���N���̏ꍇ�A�J�[�\�����擾�ł��Ȃ�������Q����̂ŁA�����J�[�\����timer1_Tick�Łu���̍i���݁v�ɃZ�b�g����B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���</br>
        /// <br>Update Note: 2016/02/25 �e�c���V</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Focus();
            this.txtName.Focus();
            this.txtName.ImeMode = ImeMode.KatakanaHalf; //ADD 2016/02/25 y.wakita Redmine#48587
            time_count++;
            if (time_count > 1)
            {
                this.timer1.Enabled = false;
            }
        }

        /// <summary>
        /// ������͂���N���̏ꍇ�A�J�[�\�����擾�ł��Ȃ�������Q����̂ŁA�����J�[�\����timer1_Tick�Łu���̍i���݁v�ɃZ�b�g����B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 �c����</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ���̍i���݂̏������̓��[�h���u���p�J�i�v�ɂ���</br>
        /// </remarks>
        private void SelectionForm_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
        //----- ADD 2016/02/17 �c���� Redmine#48587 -----<<<<<
    }

    // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� ----->>>>>
    # region
    /// <summary>
    /// ���g���C�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       �@: ���g���C�ݒ�N���X</br>
    /// <br>Programmer   : ���O</br>
    /// <br>Date         : K2021/04/19</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RetrySet
    {
        // ���g���C��
        private int _retryCount;

        // ���g���C�Ԋu
        private int _retryInterval;

        /// <summary>
        /// ���g���C�ݒ�N���X
        /// </summary>
        public RetrySet()
        {

        }

        /// <summary>���g���C��</summary>
        public int RetryCount
        {
            get { return this._retryCount; }
            set { this._retryCount = value; }
        }

        /// <summary>���g���C�Ԋu</summary>
        public int RetryInterval
        {
            get { return this._retryInterval; }
            set { this._retryInterval = value; }
        }
    }
    # endregion
    // --- ADD K2021/04/19 ���O PMKOBETSU-4130�̑Ή� -----<<<<<
}