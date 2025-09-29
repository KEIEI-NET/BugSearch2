//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/09/06  �C�����e : #14238�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2010/09/26  �C�����e : Redmine#14182�̑��x�t�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/02  �C�����e : Redmine#26319�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/22  �C�����e : Redmine#7744�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11000127-00 �쐬�S�� : gaocheng
// �C �� ��  2014/09/02  �C�����e : Redmine#43368�P�i�����ꊇ�C���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �P�i�����ݒ�ꊇ�o�^�E�C��UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �P�i�����ݒ�ꊇ�o�^�E�C��UI�t�H�[���N���X</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2010/08/04</br>
    /// <br>Update Note : 2010/09/06 ������ #14238�Ή�</br>
    /// </remarks>
    public partial class PMKHN09461UA : Form
    {
        #region �� Constants

        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMKHN09461U";

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMKHN09461U.dat";

        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_GoodsMakerGuide = "GoodsMakerGuide";
        private const string ctGUIDE_NAME_BLGoodsGuide = "BLGoodsGuide";
        private const string ctGUIDE_NAME_BLGloupGuide = "BLGloupGuide";

        // �O���b�h��
        public const string COLUMN_NO = "No";
        public const string COLUMN_GOODSNO = "GoodsNo";
        public const string COLUMN_GOODSNAME = "GoodsName";
        public const string COLUMN_MAKERCODE = "MakerCode";
        public const string COLUMN_BLCODE = "BlCode";
        public const string COLUMN_BLGROUPCODE = "blGroupCode";
        public const string COLUMN_SUPPLIERCODE = "SupplierCode";
        public const string COLUMN_PRICEFL = "PriceFl";   // �W�����i
        public const string COLUMN_SUPPLIERPRICE = "SupplierPrice";   // �d������

        public const string COLUMN_MAKERNAME = "MakerName";

        public const string COLUMN_SALERATE1 = "SaleRate1";
        public const string COLUMN_SALERATE2 = "SaleRate2";
        public const string COLUMN_SALERATE3 = "SaleRate3";
        public const string COLUMN_SALERATE4 = "SaleRate4";
        public const string COLUMN_SALERATE5 = "SaleRate5";
        public const string COLUMN_SALERATE6 = "SaleRate6";
        public const string COLUMN_SALERATE7 = "SaleRate7";
        public const string COLUMN_SALERATE8 = "SaleRate8";
        public const string COLUMN_SALERATE9 = "SaleRate9";
        public const string COLUMN_SALERATE10 = "SaleRate10";
        public const string COLUMN_SALERATE11 = "SaleRate11";
        public const string COLUMN_SALERATE12 = "SaleRate12";
        public const string COLUMN_SALERATE13 = "SaleRate13";
        public const string COLUMN_SALERATE14 = "SaleRate14";
        public const string COLUMN_SALERATE15 = "SaleRate15";
        public const string COLUMN_SALERATE16 = "SaleRate16";
        public const string COLUMN_SALERATE17 = "SaleRate17";
        public const string COLUMN_SALERATE18 = "SaleRate18";
        public const string COLUMN_SALERATE19 = "SaleRate19";
        public const string COLUMN_SALERATE20 = "SaleRate20";
        public const string COLUMN_SALERATE21 = "SaleRate21";

        public const int COLINDEX_SALERATE_ST = 9;
        public const int COLINDEX_SALERATE_ED = 29;

        private const string FORMAT = "N";
        private const string FORMAT_NUM = "###,###";
        private const string DETAIL_TITLE_1 = "�����z";
        private const string DETAIL_TITLE_2 = "������";
        private const string DETAIL_TITLE_3 = "���[�U�[���i";
        private const string DETAIL_TITLE_4 = "���i�t�o��";
        private const string DETAIL_TITLE_5 = "�����t�o��";
        private const string DETAIL_TITLE_6 = "�e���m�ۗ�";

        #endregion �� Constants

        #region �� Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SecInfoAcs _secInfoAcs;                                 // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;                           // ���_���ݒ�A�N�Z�X�N���X
        private MakerAcs _makerAcs;                                     // ���[�J�[�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs;                             // BL�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs;                               // BL�O���[�v�A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs;                   // ���Ӑ���A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;                             // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private GoodsRateSetUpdateAcs _goodsRateSetUpdateAcs;           // �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X
        private PMKHN09461UC _pMKHN09461UC;
        private PMKHN09461UD _pMKHN09461UD;
        private PMKHN09461UB _pMKHN09461UB;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// �K�C�h�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		        // �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rateGRefButton;		    // �|���f���p�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _customerRefButton;		// ���Ӑ���p�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _renewalButton;		    // �ŐV���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _showChangeButton;		    // �\���ؑփ{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		        // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _allDeleteButton;		    // �ꊇ�폜�{�^��

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, string> _custRateGrpDic;

        private TNedit[] _tNedit_CustomerCode;
        private TNedit[] _tNedit_CustRateGrpCode;

        private int _objectDiv;
        private string _searchSectionCode;
        private int _targetDivide;
        private bool _unSetting;
        private Dictionary<int, int> _targetDic = new Dictionary<int, int>();
        private List<GoodsRateSetSearchResult> _logicDelRateList;
        private List<GoodsRateSetSearchResult> _displayList;
        private List<GoodsRateSetSearchResult> _ratedisplayList;

        private GoodsRateSetSearchParam _extrInfo;

        private bool _closeFlg;

        private int _panel3Height = 187;

        // �|���}�X�^�f�[�^�̃f�[�^�Z�b�g
        private DataSet _rateDataSet = null;

        // �f�[�^�e�[�u����clone
        DataTable _dataTableClone = new DataTable();

        /// <summary>���f�_�C�A���O</summary>
        private SFCMN00299CA _processingDialog = null;

        // �O��̋��_�R�[�h
        private string _prevSectionCode = null;
        // �O���BL�R�[�h
        private int _prevBLGoodsCode = 0;
        // �O���BL�O���[�v�R�[�h
        private int _prevBLGroupCode = 0;
        // �O��̃��[�J�[�R�[�h
        private int _prevMakerCode = 0;

        private string _tNedit_CustomerCodeName = null;

        // ���Ӑ�R�[�h�E���Ӑ�|���O���[�v�R�[�h���X�g
        private List<int> _keyList = new List<int>();

        private int _startIndex = 9;

        // --- ADD 2010/08/30 ---------------------------------->>>>>
        // �t�H�[�J�X����p
        TNedit _preCtrl = null;
        // ���Ӑ�R�[�h�`�F�b�N�p
        private CustomerInputAcs _customerInputAcs = null;
        // �����v�ۃ`�F�b�N�p
        private bool searchFlag = false;
        // --- ADD 2010/08/30 ----------------------------------<<<<<

        #endregion �� Private Members


        #region �� Constructor
        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C��UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���}�X�^�ꊇ�C���E�o�^UI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public PMKHN09461UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsRateSetUpdateAcs = new GoodsRateSetUpdateAcs();

            this._gridStateController = new GridStateController();

            this._rateDataSet = new DataSet();

            // --- ADD 2010/08/30 ---------------------------------->>>>>
            this._customerInputAcs = new CustomerInputAcs();
            // --- ADD 2010/08/30 ----------------------------------<<<<<

            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadMakerUMnt();
            ReadCustomerSearchRet();
            ReadCustRateGrp();

            // ��ʏ����ݒ�
            SetInitialSetting();

            // ��ʃN���A
            ClearScreen();
        }

        #endregion �� Constructor


        #region �� Private Methods

        #region XML����
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̓Ǎ��������s���܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Details);
                if (gridStateInfo != null)
                {
                    // �t�H���g�T�C�Y
                    this.tComboEditor_GridFontSize.Value = (int)gridStateInfo.FontSize;
                    // ��̎�������
                    this.uCheckEditor_AutoFillToColumn.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // �t�H���g�T�C�Y
                this.tComboEditor_GridFontSize.Value = 11;
                // ��̎�������
                this.uCheckEditor_AutoFillToColumn.Checked = false;
            }
        }

        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̕ۑ��������s���܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
            // ADD 2010/08/27  ---------->>>>>
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // �O���b�h����ۑ�
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            // ADD 2010/08/27  ----------<<<<<
        }
        #endregion XML����

        #region �}�X�^�Ǎ�
        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_���}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�J�[�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

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
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���Ӑ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(���Ӑ�|���f)�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     43, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                this._custRateGrpDic = new Dictionary<int, string>();
            }
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            int status = 0;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// �O���[�v�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���[�v�R�[�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        //-----ADD 2010/08/30---------->>>>>
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                        //-----ADD 2010/08/30----------<<<<<
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        //-----ADD 2010/08/30---------->>>>>
                        }
                        //-----ADD 2010/08/30----------<<<<<
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }
        #endregion �}�X�^�Ǎ�

        #region ���̎擾
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note        : ���_�R�[�h�ɊY�����鋒�_���̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "�S��";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideSnm.Trim();
            }

            return "";
        }

        /// <summary>
        /// ���[�J�[���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[��</returns>
        /// <remarks>
        /// <br>Note        : ���[�J�[�R�[�h�ɊY�����閼�̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            if (this._makerDic.ContainsKey(makerCode))
            {
                return this._makerDic[makerCode].MakerName.Trim();
            }

            return "";
        }

        /// <summary>
        /// �a�k�R�[�h���擾����
        /// </summary>
        /// <param name="blGoodsCode">�a�k�R�[�h</param>
        /// <returns>�a�k�R�[�h��</returns>
        /// <remarks>
        /// <br>Note        : �a�k�R�[�h�ɊY�����閼�̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            if (this._blGoodsCdUMntDic == null)
            {
                // BL�R�[�h�}�X�^�Ǎ�����
                ReadBLGoodsCdUMnt();
            }

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                return this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName;
            }

            return "";
        }

        /// <summary>
        /// �a�k�R�[�h���擾����
        /// </summary>
        /// <param name="makerCode">�a�k�R�[�h</param>
        /// <returns>�a�k�R�[�h��</returns>
        /// <remarks>
        /// <br>Note        : �a�k�R�[�h�ɊY�����閼�̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            if (this._blGroupUDic == null)
            {
                // �O���[�v�R�[�h�}�X�^�Ǎ�����
                ReadBLGroupU();
            }

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                return this._blGroupUDic[blGroupCode].BLGroupName;
            }

            return "";
        }

        /// <summary>
        /// ���Ӑ旪�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ旪��</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ�R�[�h�ɊY�����链�Ӑ旪�̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetCustomerSnm(int customerCode)
        {
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                return this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return "";
        }

        /// <summary>
        /// ���Ӑ�|���f���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���f�R�[�h</param>
        /// <returns>���Ӑ�|���f����</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ�|���f�R�[�h�ɊY�����链�Ӑ�|���f���̂��擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                return (string)this._custRateGrpDic[custRateGrpCode];
            }

            return "";
        }
        #endregion ���̎擾

        #region �}�X�^���݃`�F�b�N
        /// <summary>
        /// ���Ӑ摶�݃`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>true�FOK�Afalse�FNG</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ悪���݂��邩�`�F�b�N���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion �}�X�^���݃`�F�b�N

        #region �����ݒ�
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // �R���g���[���z��
            //---------------------------------
            this._tNedit_CustomerCode = new TNedit[21];
            this._tNedit_CustomerCode[0] = this.tNedit_CustomerCode1;
            this._tNedit_CustomerCode[1] = this.tNedit_CustomerCode2;
            this._tNedit_CustomerCode[2] = this.tNedit_CustomerCode3;
            this._tNedit_CustomerCode[3] = this.tNedit_CustomerCode4;
            this._tNedit_CustomerCode[4] = this.tNedit_CustomerCode5;
            this._tNedit_CustomerCode[5] = this.tNedit_CustomerCode6;
            this._tNedit_CustomerCode[6] = this.tNedit_CustomerCode7;
            this._tNedit_CustomerCode[7] = this.tNedit_CustomerCode8;
            this._tNedit_CustomerCode[8] = this.tNedit_CustomerCode9;
            this._tNedit_CustomerCode[9] = this.tNedit_CustomerCode10;
            this._tNedit_CustomerCode[10] = this.tNedit_CustomerCode11;
            this._tNedit_CustomerCode[11] = this.tNedit_CustomerCode12;
            this._tNedit_CustomerCode[12] = this.tNedit_CustomerCode13;
            this._tNedit_CustomerCode[13] = this.tNedit_CustomerCode14;
            this._tNedit_CustomerCode[14] = this.tNedit_CustomerCode15;
            this._tNedit_CustomerCode[15] = this.tNedit_CustomerCode16;
            this._tNedit_CustomerCode[16] = this.tNedit_CustomerCode17;
            this._tNedit_CustomerCode[17] = this.tNedit_CustomerCode18;
            this._tNedit_CustomerCode[18] = this.tNedit_CustomerCode19;
            this._tNedit_CustomerCode[19] = this.tNedit_CustomerCode20;
            this._tNedit_CustomerCode[20] = this.tNedit_CustomerCode21;

            this._tNedit_CustRateGrpCode = new TNedit[21];
            this._tNedit_CustRateGrpCode[0] = this.tNedit_CustRateGrpCode1;
            this._tNedit_CustRateGrpCode[1] = this.tNedit_CustRateGrpCode2;
            this._tNedit_CustRateGrpCode[2] = this.tNedit_CustRateGrpCode3;
            this._tNedit_CustRateGrpCode[3] = this.tNedit_CustRateGrpCode4;
            this._tNedit_CustRateGrpCode[4] = this.tNedit_CustRateGrpCode5;
            this._tNedit_CustRateGrpCode[5] = this.tNedit_CustRateGrpCode6;
            this._tNedit_CustRateGrpCode[6] = this.tNedit_CustRateGrpCode7;
            this._tNedit_CustRateGrpCode[7] = this.tNedit_CustRateGrpCode8;
            this._tNedit_CustRateGrpCode[8] = this.tNedit_CustRateGrpCode9;
            this._tNedit_CustRateGrpCode[9] = this.tNedit_CustRateGrpCode10;
            this._tNedit_CustRateGrpCode[10] = this.tNedit_CustRateGrpCode11;
            this._tNedit_CustRateGrpCode[11] = this.tNedit_CustRateGrpCode12;
            this._tNedit_CustRateGrpCode[12] = this.tNedit_CustRateGrpCode13;
            this._tNedit_CustRateGrpCode[13] = this.tNedit_CustRateGrpCode14;
            this._tNedit_CustRateGrpCode[14] = this.tNedit_CustRateGrpCode15;
            this._tNedit_CustRateGrpCode[15] = this.tNedit_CustRateGrpCode16;
            this._tNedit_CustRateGrpCode[16] = this.tNedit_CustRateGrpCode17;
            this._tNedit_CustRateGrpCode[17] = this.tNedit_CustRateGrpCode18;
            this._tNedit_CustRateGrpCode[18] = this.tNedit_CustRateGrpCode19;
            this._tNedit_CustRateGrpCode[19] = this.tNedit_CustRateGrpCode20;
            this._tNedit_CustRateGrpCode[20] = this.tNedit_CustRateGrpCode21;

            //---------------------------------
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            //---------------------------------
            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            excCtrlNm.Add(this.Standard_UGroupBox2.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �R���g���[���T�C�Y�ݒ�
            this.tEdit_SectionCodeAllowZero.Size = new Size(59, 24);
            this.tEdit_SectionName.Size = new Size(175, 24);
            this.tEdit_GoodsNo.Size = new Size(268, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(59, 24);
            this.tEdit_MakerName.Size = new Size(175, 24);
            this.tNedit_BLGoodsCode.Size = new Size(59, 24);
            this.tEdit_BLGoodsName.Size = new Size(175, 24);
            this.tNedit_BLGloupCode.Size = new Size(59, 24);
            this.tEdit_BLGloupName.Size = new Size(175, 24);

            for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
            {
                this._tNedit_CustomerCode[index].Size = new Size(76, 24);
                this._tNedit_CustRateGrpCode[index].Size = new Size(76, 24);
            }

            //---------------------------------
            // �A�C�R���ݒ�
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            LabelTool labelTool;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            _closeButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            _closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            _saveButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            _saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            _searchButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            _searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            _rateGRefButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RateGRef"];
            _rateGRefButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
            _customerRefButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CustomerRef"];
            _customerRefButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
            _guideButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            _guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            _renewalButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            _renewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            _showChangeButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ShowChange"];
            _showChangeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            _undoButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            _undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            _allDeleteButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"];
            _allDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

            // ���_��
            ToolBase sectionName = tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"];
            if (sectionName != null && LoginInfoAcquisition.Employee != null)
            {
                sectionName.SharedProps.Caption = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }

            // ���O�C����
            ToolBase loginName = tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // �O���b�h�ݒ�
            //---------------------------------
            CreateGrid(ref this.uGrid_Details);
            // --- ADD 2010/08/27 ---------->>>>>
            // �O���b�h�񕝐ݒ�
            SetColumnWidth(ref this.uGrid_Details);
            // --- ADD 2010/08/27 ----------<<<<<
        }
        #endregion �����ݒ�

        #region �N���A����
        /// <summary>
        /// ��ʏ��N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ClearScreen()
        {
            uLabel_SaleRate.Text = DETAIL_TITLE_1; // ADD 2010/08/27
            _startIndex = 9;// ADD 2010/08/27

            // �Ώۋ敪
            this.tComboEditor_ObjectDiv.Value = 0;

            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "�S��";
            _prevSectionCode = "00";

            // �i��
            this.tEdit_GoodsNo.Clear();

            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            _prevMakerCode = 0;

            // �a�k�R�[�h
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            _prevBLGoodsCode = 0;

            // �O���[�v�R�[�h
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_BLGloupName.Clear();
            _prevBLGroupCode = 0;

            // �敪
            this.tComboEditor_TargetDivide.Value = 1;

            // ���ݒ�敪
            this.uCheckEditor_unSetting.Checked = false;

            // ���Ӑ�R�[�h
            for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
            {
                this._tNedit_CustomerCode[index].Clear();
                this._tNedit_CustRateGrpCode[index].Clear();
            }

            // �X�N���[���|�W�V����������
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // �O���b�h�N���A
            ClearGrid();

            // �t�H�[�J�X�ݒ�
            this.tComboEditor_ObjectDiv.Focus();
            _guideButton.SharedProps.Enabled = false;
        }

        /// <summary>
        /// �O���b�h����������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�����������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ClearGrid()
        {
            this._targetDic = new Dictionary<int, int>();
            this._displayList = new List<GoodsRateSetSearchResult>();
            this._ratedisplayList = new List<GoodsRateSetSearchResult>();
            this._logicDelRateList = new List<GoodsRateSetSearchResult>();


            // �O���b�h�쐬����
            CreateGrid(ref this.uGrid_Details);
        }
        #endregion �N���A����

        #region �ۑ�
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��ʏ��擾
            ArrayList saveList;
            ArrayList deleteList;
            GetUpdateList(out saveList, out deleteList);

            // ��ʏ��`�F�b�N
            string errMsg = "";

            try
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    errMsg = "�ۑ��Ώۃf�[�^�����݂��܂���B";
                    this.tComboEditor_ObjectDiv.Focus();
                    _guideButton.SharedProps.Enabled = false;
                    return (status);
                }
                if ((saveList.Count == 0) && (deleteList.Count == 0))
                {
                    errMsg = "�ۑ��Ώۃf�[�^�����݂��܂���B";
                    this.uGrid_Details.Rows[0].Cells[_startIndex].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (status);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            // �ۑ�����
            if (deleteList.Count > 0 || saveList.Count > 0)
            {
                status = this._goodsRateSetUpdateAcs.Save(ref deleteList, ref saveList, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                            {
                                errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                            }
                            else
                            {
                                errMsg = "���ɑ��[�����폜����Ă��܂��B";
                            }

                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                           "Save",
                                           errMsg,
                                           status,
                                           MessageBoxButtons.OK);

                            this.tComboEditor_ObjectDiv.Focus();
                            _guideButton.SharedProps.Enabled = false;
                            return (status);
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "Save",
                                           "�ۑ������Ɏ��s���܂����B",
                                           status,
                                           MessageBoxButtons.OK);

                            this.tComboEditor_ObjectDiv.Focus();
                            _guideButton.SharedProps.Enabled = false;
                            return (status);
                        }
                }
            }

            // �o�^�����_�C�A���O�\��
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            // �Č���
            this.Search();
            // �F������߂�
            uGrid_Details_AfterExitEditMode(null, null);

            return (status);
        }
        #endregion �ۑ�

        /// <summary>���Ӑ�|���O���[�v�̎w��Ȃ�</summary>
        private const int ALL_CUST_RATE_GRP_CODE = -1;  

        #region ����
        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private int Search()
        {
            // �O���b�h�N���A
            ClearGrid();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            _goodsRateSetUpdateAcs.ExtractCancelFlag = false;

            // �����������̓`�F�b�N
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return -1;
            }

            // �o�^�E�C���ΏۃR�[�h�擾
            this._targetDic = new Dictionary<int, int>();
            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                int custRateGrpCode;
                if (this.uCheckEditor_unSetting.Checked)
                {
                    this._targetDic.Add(ALL_CUST_RATE_GRP_CODE, ALL_CUST_RATE_GRP_CODE);
                }

                // ���Ӑ�|���f
                for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
                {
                    if (this._tNedit_CustRateGrpCode[index].DataText.Trim() == "")
                    {
                        continue;
                    }

                    custRateGrpCode = this._tNedit_CustRateGrpCode[index].GetInt();

                    if (!this._targetDic.ContainsKey(custRateGrpCode))
                    {
                        this._targetDic.Add(custRateGrpCode, custRateGrpCode);
                    }
                }
            }
            else
            {
                int customerCode;

                // ���Ӑ�
                for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
                {
                    customerCode = this._tNedit_CustomerCode[index].GetInt();

                    if (customerCode != 0)
                    {
                        if (!this._targetDic.ContainsKey(customerCode))
                        {
                            this._targetDic.Add(customerCode, customerCode);
                        }
                    }
                }
            }
            _keyList = new List<int>();
            foreach (int code in this._targetDic.Keys)
            {
                _keyList.Add(code);
            }

            // ���������i�[
            SetExtrInfo(out this._extrInfo);

            // ���o����ʕ��i�̃C���X�^���X���쐬
            _processingDialog = new SFCMN00299CA();
            SFCMN00299CA msgForm = _processingDialog;
            msgForm.Title = "���o����";
            msgForm.Message = "���݁A�f�[�^���o���ł��B(ESC�Œ��f���܂�)";
            msgForm.DispCancelButton = true;
            msgForm.CancelButtonClick += new EventHandler(processingDialog_CancelButtonClick);

            List<GoodsRateSetSearchResult> rateSearchResultList = null;

            try
            {
                msgForm.Show();

                // ��������
                if (_goodsRateSetUpdateAcs.ExtractCancelFlag == false)
                {
                    status = this._goodsRateSetUpdateAcs.Search(out rateSearchResultList, this._extrInfo);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // [�����z]�̃f�[�^��\������
                    uLabel_SaleRate.Text = DETAIL_TITLE_1;
                    // �O���b�h�\�����X�g�擾
                    GetDisplayList(rateSearchResultList);

                    // �O���b�h�f�[�^�ݒ�
                    CreateGrid(ref this.uGrid_Details);

                    // �S�W�J�{�^��������
                    this.uGrid_Details.ActiveRow = null;

                    if (this.uGrid_Details.Rows.Count == 0)
                    {
                        msgForm.Close();
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "���������ɊY������f�[�^�����݂��܂���B",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // �O���b�h�N���A
                        ClearGrid();

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    return (status);
                }
            }
            finally
            {
                msgForm.Close();
            }

            if (_goodsRateSetUpdateAcs.ExtractCancelFlag == true)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "�����𒆒f���܂����B",
                    status, MessageBoxButtons.OK);
                return (status);
            }
            _goodsRateSetUpdateAcs.ExtractCancelFlag = false;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "���������ɊY������f�[�^�����݂��܂���B",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // �O���b�h�N���A
                        ClearGrid();

                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        // �O���b�h�N���A
                        ClearGrid();

                        return (status);
                    }
            }
        }

        /// <summary>
        /// ���f�{�^������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processingDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // ���o�L�����Z��
            CancelExtract();
        }
        /// <summary>
        /// ���o�L�����Z��
        /// </summary>
        private void CancelExtract()
        {
            // ���o�L�����Z��
            _goodsRateSetUpdateAcs.ExtractCancelFlag = true;
            if (_processingDialog != null)
            {
                _processingDialog.Message = "���f���܂��B";
            }
        }

        /// <summary>
        /// ���������ݒ菈��
        /// </summary>
        /// <param name="para">��������</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂猟��������ݒ肵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// <br>Update Note : 2010/08/31 �k���r #14019�̂Q�̑Ή��B</br>
        /// </remarks>
        private void SetExtrInfo(out GoodsRateSetSearchParam para)
        {
            //-----ADD 2010/08/30---------->>>>>
            string fileName = "";
            if (this._extrInfo != null)
            {
                fileName = this._extrInfo.FileName;
            }
            //-----ADD 2010/08/30----------<<<<<

            para = new GoodsRateSetSearchParam();

            // ��ƃR�[�h
            para.EnterpriseCode = this._enterpriseCode;

            // �Ώۋ敪
            para.ObjectDiv = this.tComboEditor_ObjectDiv.SelectedItem.DataValue.ToString();

            // ���_
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // �S�Ўw��
                para.SectionCode = new string[1];
                para.SectionCode[0] = "00";
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            // �i��
            para.GoodsNo = this.tEdit_GoodsNo.Text;

            // ���[�J�[
            para.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // BL�R�[�h
            para.BlGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            //�@�O���[�v�R�[�h
            para.BlGroupCode = this.tNedit_BLGloupCode.GetInt();

            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                // ���Ӑ�|���f
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
                if (this.uCheckEditor_unSetting.Checked)
                {
                    // FIXME:���Ӑ�|���O���[�v�R�[�h=-1�͌��������ɓ���Ȃ�
                    if (null != _targetDic.Keys && _targetDic.Keys.Count > 0)
                        para.CustRateGrpCode = new int[this._targetDic.Keys.Count - 1];
                }

                int index = 0;
                bool hasFlg = false;
                foreach (int key in this._targetDic.Keys)
                {
                    if (this.uCheckEditor_unSetting.Checked && key < 0)
                    {
                        continue;   // FIXME:���Ӑ�|���O���[�v�R�[�h=-1�͌��������ɓ���Ȃ�
                    }
                    para.CustRateGrpCode[index] = key;
                    index++;
                    hasFlg = true;
                }
                if (!hasFlg)
                    para.CustRateGrpCode = null;

            }
            else
            {
                // ���Ӑ�
                para.CustomerCode = new int[this._targetDic.Keys.Count];

                int index = 0;
                foreach (int key in this._targetDic.Keys)
                {
                    para.CustomerCode[index] = key;
                    index++;
                }
            }

            // ���O�C�����_
            para.PrmSectionCode = new string[1];
            para.PrmSectionCode[0] = LoginInfoAcquisition.Employee.BelongSectionCode;

            // �o�b�t�@�ɕێ�
            this._objectDiv = (int)this.tComboEditor_ObjectDiv.Value;
            this._targetDivide = (int)this.tComboEditor_TargetDivide.Value;
            this._searchSectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            // ���ݒ�
            this._unSetting = uCheckEditor_unSetting.Checked;
            para.UnSettingFlg = this._unSetting;

            //-----ADD 2010/08/30---------->>>>>
            if (!string.IsNullOrEmpty(fileName))
            {
                para.FileName = fileName;
            }
            //-----ADD 2010/08/30----------<<<<<
        }
        #endregion ����

        # region �K�C�h�N������
        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�N���������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ExecuteGuide()
        {
            // �K�C�h�N������
            bool flag = false;
            foreach (Control ctrl in ultraExpandableGroupBoxPanel1.Controls)
            {
                if (ctrl.ContainsFocus)
                {
                    switch (ctrl.Name)
                    {

                        // ���_
                        case "tEdit_SectionCodeAllowZero":
                            {
                                this.SectionGuide_Button_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
                                flag = true;
                                break;
                            }
                        // ���[�J�[
                        case "tNedit_GoodsMakerCd":
                            {
                                this.MakerGuide_Button_Click(this.tNedit_GoodsMakerCd, new EventArgs());
                                flag = true;
                                break;
                            }
                            // BL���i�R�[�h
                        case "tNedit_BLGoodsCode":
                            {
                                this.BLGoodsCdGuide_Button_Click(this.tNedit_BLGoodsCode, new EventArgs());
                                flag = true;
                                break;
                            }
                        // BL�O���[�v�R�[�h
                        case "tNedit_BLGloupCode":
                            {
                                this.BLGroupGuide_Button_Click(this.tNedit_BLGloupCode, new EventArgs());
                                flag = true;
                                break;
                            }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
            }
            // ���Ӑ�|����G�K�C�h
            flag = false;
            foreach (Control ctrl in panel_CustRateGrp.Controls)
            {
                if (ctrl.ContainsFocus)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        int status;

                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                        if (status == 0)
                        {
                            TNedit control = (TNedit)(this.GetType().GetField(ctrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                            control.DataText = userGdBd.GuideCode.ToString("0000");
                            // --- ADD 2010/08/30 ---------------------------------->>>>>
                            // �t�H�[�J�X����
                            this._preCtrl = (TNedit)ctrl;
                            if (!"tNedit_CustRateGrpCode21".Equals(ctrl.Name))
                            {
                                string strOldId = ctrl.Name.Replace("tNedit_CustRateGrpCode", "");
                                int nextId = int.Parse(strOldId) + 1;
                                string strNextCtrlName = "tNedit_CustRateGrpCode" + nextId.ToString();
                                TNedit nextControl = (TNedit)(this.GetType().GetField(strNextCtrlName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                                nextControl.Focus();
                            }
                            else
                            {
                                // ��ʏ���r
                                bool bStatus = CompareScreen();
                                if (!bStatus)
                                {
                                    return;
                                }

                                // ��������
                                Search();
                            }
                            // --- ADD 2010/08/30 ----------------------------------<<<<<
                        }
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        else
                        {
                            this._preCtrl = (TNedit)ctrl;
                            this._preCtrl.Focus();
                            this._preCtrl.SelectAll();
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<
                        flag = true;
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            // ���Ӑ�K�C�h
            flag = false;
            foreach (Control ctrl in panel_Customer.Controls)
            {
                if (ctrl.ContainsFocus)
                {
                    this._tNedit_CustomerCodeName = ctrl.Name;
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                        customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                        // --- UPD 2010/08/30 ---------------------------------->>>>>
                        //customerSearchForm.ShowDialog(this);
                        DialogResult result = customerSearchForm.ShowDialog(this);
                        // --- UPD 2010/08/30 ---------------------------------->>>>>
                        flag = true;
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        if ((int)result == 1)
                        {
                            // �t�H�[�J�X����
                            this._preCtrl = (TNedit)ctrl;
                            if (!"tNedit_CustomerCode21".Equals(ctrl.Name) && !"".Equals(ctrl.Text))
                            {
                                string strOldId = ctrl.Name.Replace("tNedit_CustomerCode", "");
                                int nextId = int.Parse(strOldId) + 1;
                                string strNextCtrlName = "tNedit_CustomerCode" + nextId.ToString();
                                TNedit nextControl = (TNedit)(this.GetType().GetField(strNextCtrlName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                                nextControl.Focus();
                            }
                            else if ("tNedit_CustomerCode21".Equals(ctrl.Name) && !"".Equals(ctrl.Text))
                            {
                                // ��ʏ���r
                                bool bStatus = CompareScreen();
                                if (!bStatus)
                                {
                                    return;
                                }

                                // ��������
                                Search();
                            }
                        }
                        else
                        {
                            this._preCtrl = (TNedit)ctrl;
                            this._preCtrl.Focus();
                            this._preCtrl.SelectAll();
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            // ���Ӑ�R�[�h�ݒ�
            TNedit control = (TNedit)(this.GetType().GetField(this._tNedit_CustomerCodeName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
            control.SetInt(customerSearchRet.CustomerCode);
        }
        # endregion�@�K�C�h�N������

        #region �f�[�^�擾
        /// <summary>
        /// �O���b�h�\�����X�g�擾����
        /// </summary>
        /// <param name="rateSearchResultList">�|���}�X�^�������ʃ��X�g</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�ɕ\�����郊�X�g���擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void GetDisplayList(List<GoodsRateSetSearchResult> rateSearchResultList)
        {

            // UPD 2010/09/26 --- >>>
            // �d�����Ă���f�[�^������ꍇ�́A�ŏ����b�g���̃f�[�^���擾
            //Dictionary<string, GoodsRateSetSearchResult> parentDic = new Dictionary<string, GoodsRateSetSearchResult>();
            //foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            //{
            //    if ((0 == _objectDiv && 0 == rateSearchResult.GoodsLogicalDeleteCode)
            //        || (1 == _objectDiv && 0 == rateSearchResult.LogicalDeleteCode))
            //    {
            //        string key = MakeParentKey(rateSearchResult);
            //        if (!parentDic.ContainsKey(key))
            //        {
            //            parentDic.Add(key, rateSearchResult.Clone());
            //        }
            //        else
            //        {
            //            if (rateSearchResult.LotCount < parentDic[key].LotCount)
            //            {
            //                parentDic[key] = rateSearchResult.Clone();
            //            }
            //        }
            //    }
            //}

            //_displayList = new List<GoodsRateSetSearchResult>();

            //foreach (GoodsRateSetSearchResult result in parentDic.Values)
            //{
            //    this._displayList.Add(result.Clone());
            //}

            this._displayList = rateSearchResultList;

            //Dictionary<string, GoodsRateSetSearchResult> childDic = new Dictionary<string, GoodsRateSetSearchResult>();
            //foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            //{
            //    if (0 == rateSearchResult.GoodsLogicalDeleteCode && 0 == rateSearchResult.LogicalDeleteCode)
            //    {
            //        string key = MakeRateKey(rateSearchResult);
            //        if (!childDic.ContainsKey(key))
            //        {
            //            childDic.Add(key, rateSearchResult.Clone());
            //        }
            //        else
            //        {
            //            if (rateSearchResult.LotCount < childDic[key].LotCount)
            //            {
            //                childDic[key] = rateSearchResult.Clone();
            //            }
            //        }
            //    }
            //}

            //_ratedisplayList = new List<GoodsRateSetSearchResult>();

            //foreach (GoodsRateSetSearchResult result in childDic.Values)
            //{
            //    this._ratedisplayList.Add(result.Clone());
            //}

            //// �_���폜�̃f�[�^�i�|���}�X�^�𕜋����邽�߁j
            //Dictionary<string, GoodsRateSetSearchResult> deleteDic = new Dictionary<string, GoodsRateSetSearchResult>();
            //foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            //{
            //    if (1 == rateSearchResult.LogicalDeleteCode)
            //    {
            //        string key = MakeRateKey(rateSearchResult);
            //        if (!deleteDic.ContainsKey(key))
            //        {
            //            deleteDic.Add(key, rateSearchResult.Clone());
            //        }
            //        else
            //        {
            //            if (rateSearchResult.LotCount < deleteDic[key].LotCount)
            //            {
            //                deleteDic[key] = rateSearchResult.Clone();
            //            }
            //        }
            //    }
            //}


            Dictionary<string, GoodsRateSetSearchResult> childDic = new Dictionary<string, GoodsRateSetSearchResult>();

            // �_���폜�̃f�[�^�i�|���}�X�^�𕜋����邽�߁j
            Dictionary<string, GoodsRateSetSearchResult> deleteDic = new Dictionary<string, GoodsRateSetSearchResult>();

            foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            {
                if (1 == rateSearchResult.LogicalDeleteCode)
                {
                    string key = MakeRateKey(rateSearchResult);
                    if (!deleteDic.ContainsKey(key))
                    {
                        deleteDic.Add(key, rateSearchResult.Clone());
                    }
                    else
                    {
                        if (rateSearchResult.LotCount < deleteDic[key].LotCount)
                        {
                            deleteDic[key] = rateSearchResult.Clone();
                        }
                    }
                }
                else if (0 == rateSearchResult.GoodsLogicalDeleteCode && 0 == rateSearchResult.LogicalDeleteCode)
                {
                    string key = MakeRateKey(rateSearchResult);
                    if (!childDic.ContainsKey(key))
                    {
                        childDic.Add(key, rateSearchResult.Clone());
                    }
                    else
                    {
                        if (rateSearchResult.LotCount < childDic[key].LotCount)
                        {
                            childDic[key] = rateSearchResult.Clone();
                        }
                    }
                }
            }


            _logicDelRateList = new List<GoodsRateSetSearchResult>();

            _ratedisplayList = new List<GoodsRateSetSearchResult>();

            foreach (GoodsRateSetSearchResult result in childDic.Values)
            {
                this._ratedisplayList.Add(result.Clone());
            }

            foreach (GoodsRateSetSearchResult result in deleteDic.Values)
            {
                this._logicDelRateList.Add(result.Clone());
            }
            // UPD 2010/09/26 --- <<<

        }

        /// <summary>
        /// �X�V�f�[�^�擾����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="deleteList">�폜���X�g</param>
        /// <remarks>
        /// <br>Note        : �X�V�f�[�^���擾���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            string key;

            saveList = new ArrayList();
            deleteList = new ArrayList();

            this.uGrid_Details.ActiveCell = null;

            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {
                List<GoodsRateSetSearchResult> resultList;

                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

                DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                    + cells[COLUMN_NO].Value.ToString() + "'")[0];

                key = MakeKey(StrObjToInt(cells[COLUMN_MAKERCODE].Value), StrObjToInt(cells[COLUMN_BLCODE].Value),
                    StrObjToInt(cells[COLUMN_BLGROUPCODE].Value), StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value),
                    cells[COLUMN_GOODSNO].Value.ToString());

                resultList = this._ratedisplayList.FindAll(delegate(GoodsRateSetSearchResult target)
                {
                    if (key.Equals(MakeKey(target.GoodsMakerCd, target.BLGoodsCode, target.BLGroupCode, target.GoodsSupplierCd, target.GoodsNo)))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                List<GoodsRateSetSearchResult> resultListUnitPrice = new List<GoodsRateSetSearchResult>();

                // ����
                foreach (int code in this._targetDic.Keys)
                {
                    // �����z
                    double oldCode1 = DoubleObjToDouble(originalDr[code.ToString() + "title1"]);
                    double newCode1 = DoubleObjToDouble(cells[code.ToString() + "title1"].Value);
                    // ������
                    double oldCode2 = DoubleObjToDouble(originalDr[code.ToString() + "title2"]);
                    double newCode2 = DoubleObjToDouble(cells[code.ToString() + "title2"].Value);
                    // ���[�U�[���i
                    double oldCode3 = DoubleObjToDouble(originalDr[code.ToString() + "title3"]);
                    double newCode3 = DoubleObjToDouble(cells[code.ToString() + "title3"].Value);
                    // ���i�t�o��
                    double oldCode4 = DoubleObjToDouble(originalDr[code.ToString() + "title4"]);
                    double newCode4 = DoubleObjToDouble(cells[code.ToString() + "title4"].Value);
                    // �����t�o��
                    double oldCode5 = DoubleObjToDouble(originalDr[code.ToString() + "title5"]);
                    double newCode5 = DoubleObjToDouble(cells[code.ToString() + "title5"].Value);
                    // �e���m�ۗ�
                    double oldCode6 = DoubleObjToDouble(originalDr[code.ToString() + "title6"]);
                    double newCode6 = DoubleObjToDouble(cells[code.ToString() + "title6"].Value);

                    double[] oldValues = new double[] { oldCode1, oldCode2, oldCode3, oldCode4, oldCode5, oldCode6 };
                    double[] newValues = new double[] { newCode1, newCode2, newCode3, newCode4, newCode5, newCode6 };

                    if (oldCode1 != newCode1 || oldCode2 != newCode2 || oldCode3 != newCode3
                        || oldCode4 != newCode4 || oldCode5 != newCode5 || oldCode6 != newCode6)
                    {
                        Rate updateRate = new Rate();

                        resultListUnitPrice = resultList.FindAll(delegate(GoodsRateSetSearchResult target)
                            {
                                if (0 == _targetDivide)
                                {
                                    // FIXME:���Ӑ�|���O���[�v"�w��Ȃ�"
                                    if (code < 0)
                                    {
                                        return IsAllCustRateGrpCode(target);
                                    }
                                    else
                                    {
                                        if (target.CustRateGrpCode == code && !IsAllCustRateGrpCode(target))
                                            return (true);
                                        else
                                            return (false);
                                    }
                                }
                                else
                                {
                                    // FIXME:���Ӑ�|���O���[�v"�w��Ȃ�"
                                    if (code < 0)
                                    {
                                        return IsAllCustRateGrpCode(target);
                                    }
                                    if (target.CustomerCode == code)
                                        return (true);
                                    else
                                        return (false);
                                }
                            });
                        // �f�[�^�ǉ�
                        if (null == resultListUnitPrice || resultListUnitPrice.Count == 0
                            || 1 == resultListUnitPrice.Count)
                        {
                            List<Rate> updateRateList = new List<Rate>();
                            updateRateList = CreateRateForUpdate(cells, code, oldValues, newValues, null);
                            saveList.AddRange(updateRateList);
                        }

                        foreach (GoodsRateSetSearchResult result in resultListUnitPrice)
                        {
                            List<Rate> updateRateList = new List<Rate>();
                            updateRateList = CreateRateForUpdate(cells, code, oldValues, newValues, result);

                            saveList.AddRange(updateRateList);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v��"�w��Ȃ�"�̃f�[�^�ł��邩���f���܂��B
        /// </summary>
        /// <param name="rateSearchResult">���������f�[�^</param>
        /// <returns>
        /// <c>true</c> :���Ӑ�|���O���[�v��"�w��Ȃ�"�̃f�[�^�ł��B<br/>
        /// <c>false</c>:���Ӑ�|���O���[�v��"�w��Ȃ�"�̃f�[�^�ł͂���܂���B
        /// </returns>
        private static bool IsAllCustRateGrpCode(GoodsRateSetSearchResult rateSearchResult)
        {
            string unitRateSetDivCd = rateSearchResult.UnitRateSetDivCd.Trim();
            return unitRateSetDivCd.Equals("16A") || unitRateSetDivCd.Equals("36A");
        }

        /// <summary>
        /// FIXME:�ΏۂƂ��链�Ӑ�|���O���[�v�R�[�h�ɑ��݂��邩���f���܂��B
        /// </summary>
        /// <param name="custRateGrpCodeKey"></param>
        /// <returns></returns>
        private bool ExistsCustRateGrpCodeInTargetDic(int custRateGrpCode)
        {
            foreach (int custRateGrpCodeKey in this._targetDic.Keys)
            {
                if (custRateGrpCodeKey.Equals(custRateGrpCode))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �|���}�X�^�쐬����
        /// </summary>
        /// <param name="cells">�Z��</param>
        /// <param name="code">���Ӑ�R�[�h�E���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="oldValues">�ύX�O�̃Z���l</param>
        /// <param name="newValues">�ύX��̃Z���l</param>
        /// <param name="result">GoodsRateSetSearchResult</param>
        /// <returns>�|���}�X�^</returns>
        /// <remarks>
        /// <br>Note        : �|���}�X�^��V�K�쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private List<Rate> CreateRateForUpdate(CellsCollection cells, int code, double[] oldValues, double[] newValues, GoodsRateSetSearchResult result)
        {
            // �Œ�l�̂��̂����Z�b�g
            List<Rate> updateRateList = new List<Rate>();
            Rate updateRate = new Rate();
            Rate updateRateClone = new Rate();

            // �|���}�X�^�ɂ��ăf�[�^���Ȃ��̏ꍇ
            if (null == result)
            {
                Rate deleteRate = null;
                // �ύX�O�F�u�����z�E�������E����UP���E�e���m�ۗ��v�S�ā�0
                // �ύX��F�u�����z�E�������E����UP���E�e���m�ۗ��v�����ꂩ��0
                if (!(0 != oldValues[0] || 0 != oldValues[1] || 0 != oldValues[4] || 0 != oldValues[5])
                        && (0 != newValues[0] || 0 != newValues[1] || 0 != newValues[4] || 0 != newValues[5]))
                {
                    // �����̘_���폜�̃f�[�^�����邩
                    this.HasLogicDelRecord(cells, "1", code, out deleteRate);
                    if (null == deleteRate)
                    {
                        // �P�����
                        updateRate.UnitPriceKind = "1";
                        CreateRateForUpdateByUnitPrice(cells, code, newValues, ref updateRate);
                        updateRateList.Add(updateRate);
                    }
                    // �����̘_���폜�̃f�[�^������̏ꍇ�A�|���}�X�^�𕜋�����B
                    else
                    {
                        deleteRate.LogicalDeleteCode = 0;

                        // ���i�i�����j �u��ʂ̔����z�v
                        deleteRate.PriceFl = newValues[0];
                        // �|�� �u��ʂ̔������v
                        deleteRate.RateVal = newValues[1];
                        // UP�� �u��ʂ̌���UP���v
                        deleteRate.UpRate = newValues[4];
                        // �e���m�ۗ� �u��ʂ̑e���m�ۗ��v
                        deleteRate.GrsProfitSecureRate = newValues[5];
                        updateRateList.Add(deleteRate);
                    }
                }
                // �ύX�O�F�uհ�ް�艿�E�艿UP���v�S�ā�0
                // �ύX��F�uհ�ް�艿�E�艿UP���v�����ꂩ��0
                if (!(0 != oldValues[2] || 0 != oldValues[3]) && (0 != newValues[2] || 0 != newValues[3]))
                {
                    // �����̘_���폜�̃f�[�^�����邩
                    this.HasLogicDelRecord(cells, "3", code, out deleteRate);
                    if (null == deleteRate)
                    {
                        // �P�����
                        updateRateClone = updateRate.Clone();
                        updateRateClone.UnitPriceKind = "3";
                        CreateRateForUpdateByUnitPrice(cells, code, newValues, ref updateRateClone);
                        updateRateList.Add(updateRateClone);
                    }
                    else
                    {
                        deleteRate.LogicalDeleteCode = 0;

                        // ���i�i�����j�u��ʂ̃��[�U�[�艿�v
                        deleteRate.PriceFl = newValues[2];
                        // �|�� �u0�v	
                        deleteRate.RateVal = 0;
                        // UP�� �u��ʂ̒艿UP���v
                        deleteRate.UpRate = newValues[3];
                        // �e���m�ۗ� �u0�v	
                        deleteRate.GrsProfitSecureRate = 0;
                        updateRateList.Add(deleteRate);

                    }

                }
            }

            // �|���}�X�^�ɂ��ăf�[�^������̏ꍇ
            if (null != result)
            {
                updateRate = CopyToRateFromRateSearchResult(result);

                if ("1".Equals(result.UnitPriceKind))
                {
                    // �ύX�O�A�ύX����F�u�����z�E�������E����UP���E�e���m�ۗ��v�����ꂩ��0
                    if ((0 != oldValues[0] || 0 != oldValues[1] || 0 != oldValues[4] || 0 != oldValues[5]) &&
                        (0 != newValues[0] || 0 != newValues[1] || 0 != newValues[4] || 0 != newValues[5]) &&
                        (oldValues[0] != newValues[0] || oldValues[1] != newValues[1]
                         || oldValues[4] != newValues[4] || oldValues[5] != newValues[5]))
                    {
                        // ���i�i�����j �u��ʂ̔����z�v
                        updateRate.PriceFl = newValues[0];
                        // �|�� �u��ʂ̔������v
                        updateRate.RateVal = newValues[1];
                        // UP�� �u��ʂ̌���UP���v
                        updateRate.UpRate = newValues[4];
                        // �e���m�ۗ� �u��ʂ̑e���m�ۗ��v
                        updateRate.GrsProfitSecureRate = newValues[5];
                        updateRateList.Add(updateRate);
                    }

                    // �ύX�O�F�u�����z�E�������E����UP���E�e���m�ۗ��v�����ꂩ��0
                    // �ύX��F�u�����z�E�������E����UP���E�e���m�ۗ��v�S�ā�0
                    if ((0 != oldValues[0] || 0 != oldValues[1] || 0 != oldValues[4] || 0 != oldValues[5]) &&
                        !(0 != newValues[0] || 0 != newValues[1] || 0 != newValues[4] || 0 != newValues[5]))
                    {
                        updateRate.LogicalDeleteCode = 1;
                        updateRateList.Add(updateRate);
                    }
                }
                else
                {
                    // �ύX�O�A�ύX����F�uհ�ް�艿�E�艿UP���v�����ꂩ��0
                    if ((0 != oldValues[2] || 0 != oldValues[3]) &&
                        (0 != newValues[2] || 0 != newValues[3]) &&
                        (oldValues[2] != newValues[2] || oldValues[3] != newValues[3]))
                    {

                        // ���i�i�����j�u��ʂ̃��[�U�[�艿�v
                        updateRate.PriceFl = newValues[2];
                        // �|�� �u0�v	
                        updateRate.RateVal = 0;
                        // UP�� �u��ʂ̒艿UP���v
                        updateRate.UpRate = newValues[3];
                        // �e���m�ۗ� �u0�v	
                        updateRate.GrsProfitSecureRate = 0;
                        updateRateList.Add(updateRate);
                    }
                    // �ύX�O�F�uհ�ް�艿�E�艿UP���v�����ꂩ��0
                    // �ύX��F�uհ�ް�艿�E�艿UP���v�S�ā�0
                    if ((0 != oldValues[2] || 0 != oldValues[3]) &&
                        !(0 != newValues[2] || 0 != newValues[3]))
                    {
                        updateRate.LogicalDeleteCode = 1;
                        updateRateList.Add(updateRate);
                    }
                }
            }

            return updateRateList;
        }

        /// <summary>
        /// �|���}�X�^�쐬����
        /// </summary>
        /// <param name="cells">�Z��</param>
        /// <param name="code">���Ӑ�R�[�h�E���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="newValues">�ύX��̃Z���l</param>
        /// <param name="result">GoodsRateSetSearchResult</param>
        /// <remarks>
        /// <br>Note        : �|���}�X�^��V�K�쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void CreateRateForUpdateByUnitPrice(CellsCollection cells, int code, double[] newValues, ref Rate updateRate)
        {

            updateRate.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h		
            updateRate.SectionCode = this._searchSectionCode;

            // �|���ݒ�敪�i���i�j
            updateRate.RateMngGoodsCd = "A";
            // �|���ݒ薼�́i���i�j
            updateRate.RateMngGoodsNm = "Ұ���{�i��";
            // ���i���[�J�[�R�[�h
            updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_MAKERCODE].Value);
            // ���i�ԍ�
            updateRate.GoodsNo = cells[COLUMN_GOODSNO].Value.ToString().Trim();
            // ���i�|�������N
            updateRate.GoodsRateRank = string.Empty;
            // ���i�|���O���[�v�R�[�h
            updateRate.GoodsRateGrpCode = 0;
            // BL�O���[�v�R�[�h
            updateRate.BLGroupCode = 0;
            // BL���i�R�[�h
            updateRate.BLGoodsCode = 0;
            if (0 == _targetDivide)
                if (0 <= code)
                    // ���Ӑ�|���O���[�v�R�[�h
                    updateRate.CustRateGrpCode = code;
                else
                    updateRate.CustRateGrpCode = 0;
            else
                // ���Ӑ�R�[�h
                updateRate.CustomerCode = code;
            //�d����R�[�h
            updateRate.SupplierCd = 0;
            // ���b�g��
            updateRate.LotCount = 9999999.99;

            if ("1".Equals(updateRate.UnitPriceKind))
            {
                if (1 == _targetDivide)
                {
                    // �P���|���ݒ�敪
                    updateRate.UnitRateSetDivCd = "12A";
                    // �|���ݒ�敪
                    updateRate.RateSettingDivide = "2A";
                    // �|���ݒ�敪�i���Ӑ�j		
                    updateRate.RateMngCustCd = "2";
                    // �|���ݒ薼�́i���Ӑ�j		
                    updateRate.RateMngCustNm = "���Ӑ�";
                }
                else if (0 == _targetDivide && 0 <= code)
                {
                    // �P���|���ݒ�敪
                    updateRate.UnitRateSetDivCd = "14A";
                    // �|���ݒ�敪
                    updateRate.RateSettingDivide = "4A";
                    // �|���ݒ�敪�i���Ӑ�j	
                    updateRate.RateMngCustCd = "4";
                    // �|���ݒ薼�́i���Ӑ�j		
                    updateRate.RateMngCustNm = "���Ӑ�|��G";
                }
                else if (0 == _targetDivide && 0 > code)
                {
                    // �P���|���ݒ�敪
                    updateRate.UnitRateSetDivCd = "16A";
                    // �|���ݒ�敪
                    updateRate.RateSettingDivide = "6A";
                    // �|���ݒ�敪�i���Ӑ�j	
                    updateRate.RateMngCustCd = "6";
                    updateRate.RateMngCustNm = "�w��Ȃ�";

                }
            }
            else if ("3".Equals(updateRate.UnitPriceKind))
            {
                if (1 == _targetDivide)
                {
                    // �P���|���ݒ�敪
                    updateRate.UnitRateSetDivCd = "32A";
                    // �|���ݒ�敪
                    updateRate.RateSettingDivide = "2A";
                    // �|���ݒ�敪�i���Ӑ�j		
                    updateRate.RateMngCustCd = "2";
                    // �|���ݒ薼�́i���Ӑ�j		
                    updateRate.RateMngCustNm = "���Ӑ�";
                }
                else if (0 == _targetDivide && 0 <= code)
                {
                    // �P���|���ݒ�敪
                    updateRate.UnitRateSetDivCd = "34A";
                    // �|���ݒ�敪
                    updateRate.RateSettingDivide = "4A";
                    // �|���ݒ�敪�i���Ӑ�j	
                    updateRate.RateMngCustCd = "4";
                    // �|���ݒ薼�́i���Ӑ�j		
                    updateRate.RateMngCustNm = "���Ӑ�|��G";
                }
                else if (0 == _targetDivide && 0 > code)
                {
                    // �P���|���ݒ�敪
                    updateRate.UnitRateSetDivCd = "36A";
                    // �|���ݒ�敪
                    updateRate.RateSettingDivide = "6A";
                    // �|���ݒ�敪�i���Ӑ�j	
                    updateRate.RateMngCustCd = "6";
                    updateRate.RateMngCustNm = "�w��Ȃ�";
                }
            }

            if ("1".Equals(updateRate.UnitPriceKind))
            {
                // ���i�i�����j �u��ʂ̔����z�v
                updateRate.PriceFl = newValues[0];
                // �|�� �u��ʂ̔������v
                updateRate.RateVal = newValues[1];
                // UP�� �u��ʂ̌���UP���v
                updateRate.UpRate = newValues[4];
                // �e���m�ۗ� �u��ʂ̑e���m�ۗ��v
                updateRate.GrsProfitSecureRate = newValues[5];
                // �P���[�������P��
                updateRate.UnPrcFracProcUnit = 0;
                // �P���[�������敪
                updateRate.UnPrcFracProcDiv = 0;
            }
            else if ("3".Equals(updateRate.UnitPriceKind))
            {
                // ���i�i�����j�u��ʂ̃��[�U�[�艿�v
                updateRate.PriceFl = newValues[2];
                // �|�� �u0�v	
                updateRate.RateVal = 0;
                // UP�� �u��ʂ̒艿UP���v
                updateRate.UpRate = newValues[3];
                // �e���m�ۗ� �u0�v	
                updateRate.GrsProfitSecureRate = 0;
                // �P���[�������P��
                updateRate.UnPrcFracProcUnit = 1;
                // �P���[�������敪
                updateRate.UnPrcFracProcDiv = 2;
            }
        }

        /// <summary>
        /// �_���폜�̃f�[�^���擾����
        /// </summary>
        /// <param name="rateSearchResult">�|���}�X�^��������</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void HasLogicDelRecord(CellsCollection cells, string unitPriceKind, int code, out Rate deleteRate)
        {
            deleteRate = null;
            GoodsRateSetSearchResult deleteResult = _logicDelRateList.Find(delegate(GoodsRateSetSearchResult target)
            {
                if (0 == _targetDivide)
                {
                    if (-1 == code)
                    {
                        if (target.CustRateGrpCode == 0 && target.CustomerCode == 0
                            && target.UnitPriceKind == unitPriceKind
                            && target.GoodsMakerCd == StrObjToInt(cells[COLUMN_MAKERCODE].Value)
                            && target.BLGoodsCode == StrObjToInt(cells[COLUMN_BLCODE].Value)
                            && target.BLGroupCode == StrObjToInt(cells[COLUMN_BLGROUPCODE].Value)
                            && target.GoodsSupplierCd == StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value)
                            && target.GoodsNo == cells[COLUMN_GOODSNO].Value.ToString()
                            && "6A".Equals(target.RateSettingDivide.Trim())) // ADD 2010/08/27
                            return (true);
                        else
                            return (false);
                    }
                    else
                    {
                        if (target.CustRateGrpCode == code && target.UnitPriceKind == unitPriceKind
                            && target.GoodsMakerCd == StrObjToInt(cells[COLUMN_MAKERCODE].Value)
                            && target.BLGoodsCode == StrObjToInt(cells[COLUMN_BLCODE].Value)
                            && target.BLGroupCode == StrObjToInt(cells[COLUMN_BLGROUPCODE].Value)
                            && target.GoodsSupplierCd == StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value)
                            && target.GoodsNo == cells[COLUMN_GOODSNO].Value.ToString())
                            return (true);
                        else
                            return (false);
                    }
                }
                else
                {
                    if (target.CustomerCode == code && target.UnitPriceKind == unitPriceKind
                        && target.GoodsMakerCd == StrObjToInt(cells[COLUMN_MAKERCODE].Value)
                        && target.BLGoodsCode == StrObjToInt(cells[COLUMN_BLCODE].Value)
                        && target.BLGroupCode == StrObjToInt(cells[COLUMN_BLGROUPCODE].Value)
                        && target.GoodsSupplierCd == StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value)
                        && target.GoodsNo == cells[COLUMN_GOODSNO].Value.ToString())
                        return (true);
                    else
                        return (false);
                }
            });
            if (null != deleteResult)
                deleteRate = CopyToRateFromRateSearchResult(deleteResult);
        }

        /// <summary>
        /// �N���X�����o�R�s�[����
        /// </summary>
        /// <param name="result">�|���}�X�^��������</param>
        /// <returns>�|���}�X�^</returns>
        /// <remarks>
        /// <br>Note        : �|���}�X�^�������ʂ���|���}�X�^���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private Rate CopyToRateFromRateSearchResult(GoodsRateSetSearchResult result)
        {
            Rate newRate = new Rate();

            newRate.CreateDateTime = result.CreateDateTime;
            newRate.UpdateDateTime = result.UpdateDateTime;
            newRate.EnterpriseCode = result.EnterpriseCode;
            newRate.FileHeaderGuid = result.FileHeaderGuid;
            newRate.UpdEmployeeCode = result.UpdEmployeeCode;
            newRate.UpdAssemblyId1 = result.UpdAssemblyId1;
            newRate.UpdAssemblyId2 = result.UpdAssemblyId2;
            newRate.LogicalDeleteCode = result.LogicalDeleteCode;
            newRate.SectionCode = result.SectionCode;
            newRate.UnitRateSetDivCd = result.UnitRateSetDivCd;
            newRate.UnitPriceKind = result.UnitPriceKind;
            newRate.RateSettingDivide = result.RateSettingDivide;
            newRate.RateMngGoodsCd = result.RateMngGoodsCd;
            newRate.RateMngGoodsNm = result.RateMngGoodsNm;
            newRate.RateMngCustCd = result.RateMngCustCd;
            newRate.RateMngCustNm = result.RateMngCustNm;
            newRate.GoodsMakerCd = result.GoodsMakerCd;
            newRate.GoodsNo = result.GoodsNo;
            newRate.GoodsRateRank = result.GoodsRateRank;
            newRate.GoodsRateGrpCode = result.GoodsRateGrpCode;
            newRate.BLGroupCode = result.RatebLGroupCode;
            newRate.BLGoodsCode = result.RatebLGoodsCode;
            newRate.CustomerCode = result.CustomerCode;
            newRate.CustRateGrpCode = result.CustRateGrpCode;
            newRate.SupplierCd = result.SupplierCd;
            newRate.LotCount = result.LotCount;
            newRate.PriceFl = result.PriceFl;
            newRate.RateVal = result.RateVal;
            newRate.UpRate = result.UpRate;
            newRate.GrsProfitSecureRate = result.GrsProfitSecureRate;
            newRate.UnPrcFracProcUnit = result.UnPrcFracProcUnit;
            newRate.UnPrcFracProcDiv = result.UnPrcFracProcDiv;

            return newRate;
        }
        #endregion �f�[�^�擾

        #region �`�F�b�N����
        /// <summary>
        /// ���������`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������`�F�b�N���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            try
            {
                // ���_
                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == "")
                {
                    errMsg = "���_����͂��Ă��������B";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    _guideButton.SharedProps.Enabled = true;
                    return (false);
                }

                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    _guideButton.SharedProps.Enabled = true;
                    return (false);
                }


                bool inputFlg = false;

                if ((int)this.tComboEditor_TargetDivide.Value == 0)
                {
                    // ���Ӑ�|���f
                    for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
                    {
                        if (this._tNedit_CustRateGrpCode[index].DataText.Trim() != "")
                        {
                            int custRateGrpCode = this._tNedit_CustRateGrpCode[index].GetInt();

                            if (GetCustRateGrpName(custRateGrpCode) == "")
                            {
                                // --- UPD 2010/09/01 ---------------->>>>>
                                //errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                errMsg = "���Ӑ�|���O���[�v�����݂��܂���B";
                                // --- UPD 2010/09/01 ----------------<<<<<
                                this._tNedit_CustRateGrpCode[index].Focus();
                                _guideButton.SharedProps.Enabled = true;
                                return (false);
                            }

                            inputFlg = true;
                        }
                    }


                    // ���Ӑ�|���O���[�v�̓��͂������A���ݒ�`�F�b�N���Ȃ��ꍇ
                    if (!inputFlg) inputFlg = this.uCheckEditor_unSetting.Checked;
                    if (inputFlg == false)
                    {
                        errMsg = "���Ӑ�|���f����͂��Ă��������B";
                        this._tNedit_CustRateGrpCode[0].Focus();
                        _guideButton.SharedProps.Enabled = true;
                        return (false);
                    }
                }
                else
                {
                    // ���Ӑ�
                    for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
                    {
                        if (this._tNedit_CustomerCode[index].GetInt() != 0)
                        {
                            int customerCode = this._tNedit_CustomerCode[index].GetInt();

                            if (!CheckCustomer(customerCode))
                            {
                                // --- UPD 2010/09/01 ---------------->>>>>
                                //errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                                errMsg = "���Ӑ悪���݂��܂���B";
                                // --- UPD 2010/09/01 ----------------<<<<<
                                this._tNedit_CustomerCode[index].Focus();
                                _guideButton.SharedProps.Enabled = true;
                                return (false);
                            }

                            inputFlg = true;
                        }
                    }

                    if (inputFlg == false)
                    {
                        errMsg = "���Ӑ����͂��Ă��������B";
                        this._tNedit_CustomerCode[0].Focus();
                        _guideButton.SharedProps.Enabled = true;
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ���l���̓`�F�b�N����2
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���</br>
        /// <br>Date        : 2010/08/31</br>
        /// </remarks>
        private bool KeyPressNumCheck2(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                return false;
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                return false;
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�������s�@False:�������f)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ����r���A�ύX����Ă���ꍇ�̓��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return (true);
            }

            // ��ʏ���r
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // �ۑ�����
                            int status = Save();
                            if (status != 0)
                            {
                                return (false);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ����r���A�ύX����Ă���ꍇ�̓��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                return (false);
            }

            return (true);
        }

        #endregion �`�F�b�N����

        #region �O���b�h�ݒ�
        /// <summary>
        /// �O���b�h�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <param name="displayList">�\���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�̗���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            DataTable dataTable = new DataTable();

            // No
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // �i��
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // �i��
            dataTable.Columns.Add(COLUMN_GOODSNAME, typeof(string));
            // ���[�J�[�R�[�h
            dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
            // �a�k�R�[�h
            dataTable.Columns.Add(COLUMN_BLCODE, typeof(string));
            // �O���[�v�R�[�h
            dataTable.Columns.Add(COLUMN_BLGROUPCODE, typeof(string));
            // �d����
            dataTable.Columns.Add(COLUMN_SUPPLIERCODE, typeof(string));
            // �W�����i
            dataTable.Columns.Add(COLUMN_PRICEFL, typeof(double));
            // �d������
            dataTable.Columns.Add(COLUMN_SUPPLIERPRICE, typeof(double));

            // ������
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                dataTable.Columns.Add(COLUMN_SALERATE1, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE2, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE3, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE4, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE5, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE6, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE7, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE8, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE9, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE10, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE11, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE12, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE13, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE14, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE15, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE16, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE17, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE18, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE19, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE20, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE21, typeof(double));
            }
            else
            {
                foreach (int key in this._targetDic.Keys)
                {
                    dataTable.Columns.Add(key.ToString() + "title1", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title2", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title3", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title4", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title5", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title6", typeof(double));
                }
            }

            uGrid.DataSource = dataTable;

            // �O���b�h�X�^�C���ݒ�
            SetGridLayout(ref uGrid);

            // �f�[�^�������ꍇ
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                return;
            }
            dataTable.AcceptChanges();

            List<GoodsRateSetSearchResult> targetList;

            this.uGrid_Details.BeginUpdate();

            try
            {
                _dataTableClone = dataTable.Copy();

                //-----------ADD BY ������ on 2011/11/02 for Redmine#26319--------------->>>>>>>>>>
                int tempCount = this._displayList.Count;
                bool flag = false;
                for (int index = 0; index < tempCount; index++)
                {
                    for (int i = 0; i < tempCount - 1; i++)
                    {
                        if (this._displayList.Count == index + 1 || this._displayList.Count == index)
                        {
                            flag = true;
                            break;
                        }
                        GoodsRateSetSearchResult result1 = (GoodsRateSetSearchResult)this._displayList[index];
                        GoodsRateSetSearchResult result2 = (GoodsRateSetSearchResult)this._displayList[index + 1];
                        //if (result1.GoodsNo.Equals(result2.GoodsNo)) DEL BY gaocheng on 2014/09/02 for Redmine#43368
                        if (result1.GoodsNo.Equals(result2.GoodsNo) && result1.GoodsMakerCd.Equals(result2.GoodsMakerCd)) // ADD BY gaocheng on 2014/09/02 for Redmine#43368
                        {
                            this._displayList.Remove(this._displayList[index]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                //-----------ADD BY ������ on 2011/11/02 for Redmine#26319---------------<<<<<<<<<<<<
                for (int index = 0; index < this._displayList.Count; index++)
                {
                    // �s�ǉ�
                    DataRow row = _dataTableClone.NewRow();
                    uGrid.DisplayLayout.Bands[0].AddNew();

                    CellsCollection cells = uGrid.Rows[index].Cells;

                    GoodsRateSetSearchResult result = (GoodsRateSetSearchResult)this._displayList[index];

                    // No
                    cells[COLUMN_NO].Value = index + 1;
                    row[COLUMN_NO] = index + 1;

                    // �i��
                    cells[COLUMN_GOODSNO].Value = result.GoodsNo;
                    row[COLUMN_GOODSNO] = result.GoodsNo;
                    // �i��
                    cells[COLUMN_GOODSNAME].Value = result.BLGoodsHalfName;
                    row[COLUMN_GOODSNAME] = result.BLGoodsHalfName;
                    // ���[�J�[
                    cells[COLUMN_MAKERCODE].Value = result.GoodsMakerCd.ToString("0000");
                    row[COLUMN_MAKERCODE] = result.GoodsMakerCd.ToString("0000");
                    // BL�R�[�h
                    cells[COLUMN_BLCODE].Value = result.BLGoodsCode.ToString("00000");
                    row[COLUMN_BLCODE] = result.BLGoodsCode.ToString("00000");
                    // �O���[�v�R�[�h
                    cells[COLUMN_BLGROUPCODE].Value = result.BLGroupCode.ToString("00000");
                    row[COLUMN_BLGROUPCODE] = result.BLGroupCode.ToString("00000");
                    // �d����
                    cells[COLUMN_SUPPLIERCODE].Value = result.GoodsSupplierCd.ToString("000000");
                    row[COLUMN_SUPPLIERCODE] = result.GoodsSupplierCd.ToString("000000");
                    // �W�����i
                    cells[COLUMN_PRICEFL].Value = result.ListPrice.ToString(FORMAT);
                    row[COLUMN_PRICEFL] = result.ListPrice.ToString(FORMAT);
                    // �d������
                    cells[COLUMN_SUPPLIERPRICE].Value = result.SalesUnitCost.ToString(FORMAT);
                    row[COLUMN_SUPPLIERPRICE] = result.SalesUnitCost.ToString(FORMAT);


                    targetList = this._ratedisplayList.FindAll(delegate(GoodsRateSetSearchResult target)
                    {
                        if (MakeKey(result.GoodsMakerCd, result.BLGoodsCode, result.BLGroupCode, result.GoodsSupplierCd, result.GoodsNo).Equals(
                            MakeKey(target.GoodsMakerCd, target.BLGoodsCode, target.BLGroupCode, target.GoodsSupplierCd, target.GoodsNo)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    // �P����ނɂ���āA���X�g���쐬����
                    if (0 == _targetDivide)
                    {
                        targetList.Sort(delegate(GoodsRateSetSearchResult x, GoodsRateSetSearchResult y)
                            {
                                int compare = x.CustRateGrpCode - y.CustRateGrpCode;
                                if (compare == 0) compare = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                                return compare;
                            });
                    }
                    else
                    {
                        targetList.Sort(delegate(GoodsRateSetSearchResult x, GoodsRateSetSearchResult y)
                            {
                                int compare = x.CustomerCode - y.CustomerCode;
                                if (compare == 0) compare = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                                return compare;
                            });
 
                    }

                    // �����L�[�i�i�ԁ{���[�J�[�R�[�h�{BL�R�[�h + �O���[�v�R�[�h + �d����R�[�h +  ���Ӑ�R�[�h/���Ӑ�|���O���[�v�R�[�h�j
                    // �̏ꍇ�A�Ⴂ�P����ނɂ���āA���R�[�h��ʁX�Őݒ肷��
                    for (int columnIndex = 0; columnIndex < targetList.Count; columnIndex++)
                    {
                        GoodsRateSetSearchResult rate = (GoodsRateSetSearchResult)targetList[columnIndex];
                        SetCellRateVal(ref cells, rate, ref row, index);
                    }

                    _dataTableClone.Rows.Add(row);
                }
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// �|���}�X�^�ɂ��ẴZ���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���}�X�^�ɂ��ẴZ���̐ݒ���s��</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetCellRateVal(ref CellsCollection cells, GoodsRateSetSearchResult rate, ref DataRow row, int index)
        {
            // �P�����
            string unitPriceKindCode = rate.UnitPriceKind;
            // �|���ݒ�敪
            string rateSettingDivide = rate.RateSettingDivide;

            if (0 == _targetDivide)
            {
                switch (unitPriceKindCode)
                {
                    // �����ݒ�
                    case "1":

                        // ������
                        if (rate.RateVal != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title2"].Value = rate.RateVal.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title2"] = rate.RateVal.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title2"].Value = rate.RateVal.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title2"] = rate.RateVal.ToString(FORMAT);
                                }
                            }
                        }

                        // �����z
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                            if (rate.PriceFl != 0)
                            {
                                // ALL column
                                if (IsAllCustRateGrpCode(rate))
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                    {
                                        cells[ALL_CUST_RATE_GRP_CODE + "title1"].Value = rate.PriceFl.ToString(FORMAT);
                                        row[ALL_CUST_RATE_GRP_CODE + "title1"] = rate.PriceFl.ToString(FORMAT);
                                    }
                                }
                                else
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                    {
                                        cells[rate.CustRateGrpCode.ToString() + "title1"].Value = rate.PriceFl.ToString(FORMAT);
                                        row[rate.CustRateGrpCode.ToString() + "title1"] = rate.PriceFl.ToString(FORMAT);
                                    }
                                }
                            }
                        }

                        string cellStr = null;
                        if (IsAllCustRateGrpCode(rate))
                        {
                            if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                            {
                                cellStr = ALL_CUST_RATE_GRP_CODE.ToString();
                            }
                        }
                        else
                        {

                            if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                            {
                                cellStr = rate.CustRateGrpCode.ToString();
                            }

                        }

                        if (!string.IsNullOrEmpty(cellStr))
                        {
                            // �����z
                            double sellPrice = DoubleObjToDouble(cells[cellStr + "title1"].Value);
                            // ������
                            double sellRate = DoubleObjToDouble(cells[cellStr + "title2"].Value);
                            // ���������|���}�X�^���u�����z�v��0�̏ꍇ�A�u�����z�v���́u�������v���ڂ̔w�i�F���u�����v�֕ύX����B
                            if (0 != sellPrice)
                            {
                                // --- UPD 2010/08/27 ---------->>>>>
                                //cells[cellStr + "title1"].Appearance.BackColor = Color.MediumPurple;
                                //cells[cellStr + "title2"].Appearance.BackColor = Color.MediumPurple;
                                cells[cellStr + "title1"].Appearance.BackColor = Color.Pink;
                                cells[cellStr + "title2"].Appearance.BackColor = Color.Pink;
                                // --- UPD 2010/08/27 ----------<<<<<
                            }
                            // ���������|���}�X�^���u�����z�v��0�Ŋ��u�������v��0�̏ꍇ�A�u�����z�v���́u�������v���ڂ̔w�i�F���u���΁v�֕ύX����B
                            else if (0 == sellPrice && 0 != sellRate)
                            {
                                cells[cellStr + "title1"].Appearance.BackColor = Color.PaleGreen;
                                cells[cellStr + "title2"].Appearance.BackColor = Color.PaleGreen;
                            }
                            else
                            {
                                if (0 == index % 2)
                                {
                                    cells[cellStr + "title1"].Appearance.BackColor = Color.White;
                                    cells[cellStr + "title2"].Appearance.BackColor = Color.White;
                                }
                                else
                                {
                                    cells[cellStr + "title1"].Appearance.BackColor = Color.Lavender;
                                    cells[cellStr + "title2"].Appearance.BackColor = Color.Lavender;
                                }
                            }
                        }

                        // �����t�o��
                        if (rate.UpRate != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title5"].Value = rate.UpRate.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title5"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title5"].Value = rate.UpRate.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title5"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                        }

                        // �e���m�ۗ�
                        if (rate.GrsProfitSecureRate != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title6"].Value = rate.GrsProfitSecureRate.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title6"] = rate.GrsProfitSecureRate.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title6"].Value = rate.GrsProfitSecureRate.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title6"] = rate.GrsProfitSecureRate.ToString(FORMAT);
                                }
                            }
                        }
                        break;
                    // ���i�ݒ�
                    case "3":

                        // ���i�t�o��
                        if (rate.UpRate != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title4"].Value = rate.UpRate.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title4"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title4"].Value = rate.UpRate.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title4"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                        }

                        // ���[�U�[���i
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                            if (rate.PriceFl != 0)
                            {
                                // ALL column
                                if (IsAllCustRateGrpCode(rate))
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                    {
                                        cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title3"].Value = rate.PriceFl.ToString(FORMAT_NUM);
                                        row[ALL_CUST_RATE_GRP_CODE.ToString() + "title3"] = rate.PriceFl.ToString(FORMAT_NUM);
                                    }
                                }
                                else
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                    {
                                        cells[rate.CustRateGrpCode.ToString() + "title3"].Value = rate.PriceFl.ToString(FORMAT_NUM);
                                        row[rate.CustRateGrpCode.ToString() + "title3"] = rate.PriceFl.ToString(FORMAT_NUM);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                if (this._targetDic.ContainsKey(rate.CustomerCode))
                {
                    switch (unitPriceKindCode)
                    {
                        // �����ݒ�
                        case "1":

                            // ������
                            if (rate.RateVal != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title2"].Value = rate.RateVal.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title2"] = rate.RateVal.ToString(FORMAT);

                            }

                            // �����z
                            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                            {
                                // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                                if (rate.PriceFl != 0)
                                {
                                    cells[rate.CustomerCode.ToString() + "title1"].Value = rate.PriceFl.ToString(FORMAT);
                                    row[rate.CustomerCode.ToString() + "title1"] = rate.PriceFl.ToString(FORMAT);
                                }
                            }

                            // �����z
                            double sellPrice = DoubleObjToDouble(cells[rate.CustomerCode.ToString() + "title1"].Value);
                            // ������
                            double sellRate = DoubleObjToDouble(cells[rate.CustomerCode.ToString() + "title2"].Value);
                            // ���������|���}�X�^���u�����z�v��0�̏ꍇ�A�u�����z�v���́u�������v���ڂ̔w�i�F���u�����v�֕ύX����B
                            if (0 != sellPrice)
                            {
                                // --- UPD 2010/08/27 ---------->>>>>
                                //cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.MediumPurple;
                                //cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.MediumPurple;
                                cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.Pink;
                                cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.Pink;
                                // --- UPD 2010/08/27 ---------->>>>>
                            }
                            // ���������|���}�X�^���u�����z�v��0�Ŋ��u�������v��0�̏ꍇ�A�u�����z�v���́u�������v���ڂ̔w�i�F���u���΁v�֕ύX����B
                            else if (0 == sellPrice && 0 != sellRate)
                            {
                                cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.PaleGreen;
                                cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.PaleGreen;
                            }
                            else
                            {
                                if (0 == index % 2)
                                {
                                    cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.White;
                                    cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.White;
                                }
                                else
                                {
                                    cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.Lavender;
                                    cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.Lavender;
                                }
                            }

                            // �����t�o��
                            if (rate.UpRate != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title5"].Value = rate.UpRate.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title5"] = rate.UpRate.ToString(FORMAT);
                            }

                            // �e���m�ۗ�
                            if (rate.GrsProfitSecureRate != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title6"].Value = rate.GrsProfitSecureRate.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title6"] = rate.GrsProfitSecureRate.ToString(FORMAT);
                            }
                            break;
                        // ���i�ݒ�
                        case "3":

                            // ���i�t�o��
                            if (rate.UpRate != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title4"].Value = rate.UpRate.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title4"] = rate.UpRate.ToString(FORMAT);
                            }

                            // ���[�U�[���i
                            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                            {
                                // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                                if (rate.PriceFl != 0)
                                {
                                    cells[rate.CustomerCode.ToString() + "title3"].Value = rate.PriceFl.ToString(FORMAT_NUM);
                                    row[rate.CustomerCode.ToString() + "title3"] = rate.PriceFl.ToString(FORMAT_NUM);
                                }
                            }
                            break;
                    }
                }

            }
        }   

        /// <summary>
        /// �O���b�h�X�^�C���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�̃X�^�C����ݒ肵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetGridLayout(ref UltraGrid uGrid)
        {
            try
            {
                uGrid.BeginUpdate();

                ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

                // �Z���X�^�C��
                for (int index = 0; index < columns.Count; index++)
                {
                    columns[index].CellAppearance.BackColorDisabled = Color.White;
                    columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                }
                uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free; // ADD 2010/08/27

                // No
                columns[COLUMN_NO].Header.Caption = "No.";
                columns[COLUMN_NO].Header.Fixed = true;
                columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
                columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
                columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
                columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_NO].CellActivation = Activation.Disabled;

                // �i��
                columns[COLUMN_GOODSNO].Header.Caption = "�i��";
                columns[COLUMN_GOODSNO].Header.Fixed = true;
                columns[COLUMN_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_GOODSNO].CellActivation = Activation.NoEdit;

                // �i��
                columns[COLUMN_GOODSNAME].Header.Caption = "�i��";
                //columns[COLUMN_GOODSNAME].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_GOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_GOODSNAME].CellActivation = Activation.NoEdit;

                // ���[�J�[�R�[�h
                columns[COLUMN_MAKERCODE].Header.Caption = "Ұ��";
                //columns[COLUMN_MAKERCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_MAKERCODE].CellActivation = Activation.NoEdit;

                // �a�k�R�[�h
                columns[COLUMN_BLCODE].Header.Caption = "BL����";
                //columns[COLUMN_BLCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_BLCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLCODE].CellActivation = Activation.NoEdit;

                // �O���[�v�R�[�h
                columns[COLUMN_BLGROUPCODE].Header.Caption = "��ٰ�ߺ���";
                //columns[COLUMN_BLGROUPCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_BLGROUPCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLGROUPCODE].CellActivation = Activation.NoEdit;

                // �d����
                columns[COLUMN_SUPPLIERCODE].Header.Caption = "�d����";
                //columns[COLUMN_SUPPLIERCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_SUPPLIERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_SUPPLIERCODE].CellActivation = Activation.NoEdit;

                // �W�����i
                columns[COLUMN_PRICEFL].Header.Caption = "�W�����i";
                //columns[COLUMN_PRICEFL].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_PRICEFL].Format = FORMAT;
                columns[COLUMN_PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_PRICEFL].CellActivation = Activation.NoEdit;

                // �d������
                columns[COLUMN_SUPPLIERPRICE].Header.Caption = "�d������";
                //columns[COLUMN_SUPPLIERPRICE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_SUPPLIERPRICE].Format = FORMAT;
                columns[COLUMN_SUPPLIERPRICE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_SUPPLIERPRICE].CellActivation = Activation.NoEdit;


                // ������
                if ((this._displayList == null) || (this._displayList.Count == 0))
                {
                    for (int index = _startIndex; index <= COLINDEX_SALERATE_ED; index++)
                    {
                        columns[index].Header.Caption = "";
                        columns[index].Format = FORMAT;
                        columns[index].CellAppearance.TextHAlign = HAlign.Right;
                        columns[index].CellActivation = Activation.AllowEdit;
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        foreach (int key in this._targetDic.Keys)
                        {
                            if (this._targetDivide == 0)
                            {
                                columns[key.ToString() + "title" + i].Header.Caption = ((int)this._targetDic[key]).ToString("0000");
                                if (((int)this._targetDic[key]) < 0) 
                                    columns[key.ToString() + "title" + i].Header.Caption = "ALL";
                            }
                            else
                            {
                                columns[key.ToString() + "title" + i].Header.Caption = ((int)this._targetDic[key]).ToString("00000000");
                            }
                            columns[key.ToString() + "title" + i].Format = FORMAT;
                            columns[key.ToString() + "title" + i].CellAppearance.TextHAlign = HAlign.Right;
                            columns[key.ToString() + "title" + i].CellActivation = Activation.AllowEdit;
                            columns[key.ToString() + "title" + i].Hidden = true;

                            if (DETAIL_TITLE_1.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title1"].Hidden = false;
                            else if (DETAIL_TITLE_2.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title2"].Hidden = false;
                            else if (DETAIL_TITLE_3.Equals(uLabel_SaleRate.Text))
                            {
                                columns[key.ToString() + "title3"].Hidden = false;
                                // --- ADD 2010/08/31 ---------------------------------->>>>>
                                columns[key.ToString() + "title3"].Format = FORMAT_NUM;
                                // --- ADD 2010/08/31 ----------------------------------<<<<<
                            }
                            else if (DETAIL_TITLE_4.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title4"].Hidden = false;
                            else if (DETAIL_TITLE_5.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title5"].Hidden = false;
                            else if (DETAIL_TITLE_6.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title6"].Hidden = false;
                        }
                    }

                }

                // --- DEL 2010/08/27 ---------->>>>>
                //// �O���b�h�񕝐ݒ�
                //SetColumnWidth(ref uGrid);
                // --- DEL 2010/08/27 ----------<<<<<
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// �O���b�h�񕝐ݒ菈��
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�̗񕝂�ݒ肵�܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetColumnWidth(ref UltraGrid uGrid)
        {
            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            // No
            columns[COLUMN_NO].Width = 45;
            // �i��
            columns[COLUMN_GOODSNO].Width = 190;
            // �i��
            columns[COLUMN_GOODSNAME].Width = 190;
            // ���[�J�[�R�[�h
            columns[COLUMN_MAKERCODE].Width = 45;
            // �a�k�R�[�h
            columns[COLUMN_BLCODE].Width = 55;
            // �O���[�v�R�[�h
            columns[COLUMN_BLGROUPCODE].Width = 80;
            // �d����
            columns[COLUMN_SUPPLIERCODE].Width = 60;
            // �W�����i
            columns[COLUMN_PRICEFL].Width = 120;
            // �d������
            columns[COLUMN_SUPPLIERPRICE].Width = 120;

            // ������
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                for (int index = _startIndex; index <= COLINDEX_SALERATE_ED; index++)
                {
                    columns[index].Width = 120;
                }
            }
            else
            {
                string title = "";
                if (DETAIL_TITLE_1.Equals(uLabel_SaleRate.Text))
                    title = "title1";
                else if (DETAIL_TITLE_2.Equals(uLabel_SaleRate.Text))
                    title = "title2";
                else if (DETAIL_TITLE_3.Equals(uLabel_SaleRate.Text))
                    title = "title3";
                else if (DETAIL_TITLE_4.Equals(uLabel_SaleRate.Text))
                    title = "title4";
                else if (DETAIL_TITLE_5.Equals(uLabel_SaleRate.Text))
                    title = "title5";
                else if (DETAIL_TITLE_6.Equals(uLabel_SaleRate.Text))
                    title = "title6";

                foreach (int key in this._targetDic.Keys)
                {
                    columns[key.ToString() + title].Width = 120;
                }
            }
        }
        #endregion �O���b�h�ݒ�

        #region �Z���l�ϊ�
        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Int�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (int)cellValue;
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>String�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return int.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Double�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public double DoubleObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (double)cellValue;
            }
        }
        #endregion �Z���l�ϊ�

        #region Key�쐬
        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="result">�|���}�X�^��������</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeParentKey(GoodsRateSetSearchResult result)
        {
            // �i�ԁ{���[�J�[�R�[�h�{BL�R�[�h + �O���[�v�R�[�h + �d����R�[�h
            string key = result.GoodsMakerCd.ToString("0000") + "\\" +
                         result.BLGoodsCode.ToString("00000") + "\\" +
                         result.BLGroupCode.ToString("00000") + "\\" +
                         result.GoodsSupplierCd.ToString("000000") + "\\" +
                         result.GoodsNo;

            return key;
        }

        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="bLGoodsCode">���i�ԍ�</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="goodsSupplierCd">�d����R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeKey(int goodsMakerCd, int bLGoodsCode, int bLGroupCode, int goodsSupplierCd, string goodsNo)
        {
            // �i�ԁ{���[�J�[�R�[�h�{BL�R�[�h + �O���[�v�R�[�h + �d����R�[�h
            string key = goodsMakerCd.ToString("0000") + "\\" +
                         bLGoodsCode.ToString("00000") + "\\" +
                         bLGroupCode.ToString("00000") + "\\" +
                         goodsSupplierCd.ToString("000000") + "\\" +
                         goodsNo;

            return key;
        }

        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="rateSearchResult">�|���}�X�^��������</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeRateKey(GoodsRateSetSearchResult result)
        {
            int custCode = 0;
            if (0 == _targetDivide)
            {
                custCode = result.CustRateGrpCode;
            }
            else
            {
                custCode = result.CustomerCode;
            }

            // �i�ԁ{���[�J�[�R�[�h�{BL�R�[�h + �O���[�v�R�[�h + �d����R�[�h + �P����� + ���Ӑ�R�[�h/���Ӑ�|���O���[�v�R�[�h
            string key = result.GoodsMakerCd.ToString("0000") + "\\" +
                         result.BLGoodsCode.ToString("00000") + "\\" +
                         result.BLGroupCode.ToString("00000") + "\\" +
                         result.GoodsSupplierCd.ToString("000000") + "\\" +
                         custCode.ToString("00000000") + "\\" +
                         result.UnitPriceKind + "\\" +
                         result.RateSettingDivide + "\\" +
                         result.GoodsNo;
            return key;
        }
        #endregion Key�쐬

        #region ���b�Z�[�W�{�b�N�X�\��
        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                        // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@		    // �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._goodsRateSetUpdateAcs,	    // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }
        #endregion ���b�Z�[�W�{�b�N�X�\��
        #endregion �� Private Methods


        #region �� Control Events

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[����Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void PMKHN09461UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;

            //this.Form1_Top_Panel6.Size = new Size(750, 23); // DEL 2010/08/27
            //this.Form1_Top_Panel6.Size = new Size(520, 23); // ADD 2010/08/27  //DEL BY ������ on 2011/11/22 for Redmine#7744
            this.Form1_Top_Panel6.Size = new Size(490, 23);   //ADD BY ������ on 2011/11/22 for Redmine#7744
        }

        /// <summary>
        /// ToolClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // ��ʏ���r
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        this._closeFlg = true;

                        // �I������
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        Save();
                        //-----ADD 2010/09/01---------->>>>>
                        if (this.uGrid_Details.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.uGrid_Details.Rows[0].Cells.Count; i++)
                            {
                                if (this.uGrid_Details.Rows[0].Cells[i].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                                && this.uGrid_Details.Rows[0].Cells[i].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[0].Cells[i].Activate();
                                    this._startIndex = i;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this._guideButton.SharedProps.Enabled = false;
                                    break;
                                }
                            }
                        }
                        //-----ADD 2010/09/01----------<<<<<
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ��ʏ���r
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // ��������
                        Search();

                        //-----ADD 2010/08/30---------->>>>>
                        if (this.uGrid_Details.Rows.Count > 0)
                        {
                            this.uGrid_Details.Focus();
                            //-----UPD 2010/09/01---------->>>>>
                            //this.uGrid_Details.Rows[0].Cells[this._startIndex].Activate();
                            //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            //this._guideButton.SharedProps.Enabled = false;
                            for (int i = 0; i < this.uGrid_Details.Rows[0].Cells.Count; i++)
                            {
                                if (this.uGrid_Details.Rows[0].Cells[i].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                                && this.uGrid_Details.Rows[0].Cells[i].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[0].Cells[i].Activate();
                                    this._startIndex = i;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this._guideButton.SharedProps.Enabled = false;
                                    break;
                                }
                            }
                            //-----UPD 2010/09/01----------<<<<<
                        }
                        //-----ADD 2010/08/30----------<<<<<
                        break;
                    }
                case "ButtonTool_RateGRef":
                    {
                        // �|���f���p
                        // ���������i�[

                        SetExtrInfo(out this._extrInfo);
                        _pMKHN09461UD = new PMKHN09461UD(this._extrInfo);
                        DialogResult result = _pMKHN09461UD.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            if (this.uGrid_Details.Rows.Count == 0) return;
                            // �Č���
                            this.Search();
                            // �F������߂�
                            uGrid_Details_AfterExitEditMode(null, null);
                        }
                        break;
                    }
                case "ButtonTool_CustomerRef":
                    {
                        // ���Ӑ���p
                        SetExtrInfo(out this._extrInfo);
                        _pMKHN09461UC = new PMKHN09461UC(this._extrInfo);
                        DialogResult result = _pMKHN09461UC.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            if (this.uGrid_Details.Rows.Count == 0) return;
                            // �Č���
                            this.Search();
                            // �F������߂�
                            uGrid_Details_AfterExitEditMode(null, null);
                        }

                        break;
                    }
                case "ButtonTool_Guide":
                    {
                        // �K�C�h�N������
                        this.ExecuteGuide();

                        break;
                    }
                case "ButtonTool_Renewal":
                    {
                        // �}�X�^�Ǎ�
                        ReadSecInfoSet();
                        ReadMakerUMnt();
                        ReadCustomerSearchRet();
                        ReadCustRateGrp();
                        // --- ADD 2010/08/27 ---------->>>>>
                        this._goodsRateSetUpdateAcs.RenewalSearchInitial();
                        // --- ADD 2010/08/27 ----------<<<<<

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�ŐV�����擾���܂����B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                        break;
                    }
                case "ButtonTool_ShowChange":
                    {
                        // �\���ؑ�
                        if (DETAIL_TITLE_1.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_2;
                            this._startIndex = COLINDEX_SALERATE_ST + 1;
                        }
                        else if (DETAIL_TITLE_2.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_3;
                            this._startIndex = COLINDEX_SALERATE_ST + 2;
                        }
                        else if (DETAIL_TITLE_3.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_4;
                            this._startIndex = COLINDEX_SALERATE_ST + 3;
                        }
                        else if (DETAIL_TITLE_4.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_5;                            
                            this._startIndex = COLINDEX_SALERATE_ST + 4;
                        }
                        else if (DETAIL_TITLE_5.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_6;
                            this._startIndex = COLINDEX_SALERATE_ST + 5;
                        }
                        else if (DETAIL_TITLE_6.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_1;
                            this._startIndex = COLINDEX_SALERATE_ST;
                        }

                        // �O���b�h�f�[�^�ݒ�
                        SetGridLayout(ref this.uGrid_Details);

                        ChangeRateFocus(); // ADD 2010/08/27

                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // ��ʏ���r
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // �N���A����
                        ClearScreen();
                        break;
                    }
                case "ButtonTool_AllDelete":
                    {
                        // �ꊇ�폜
                        // ���������i�[
                        SetExtrInfo(out this._extrInfo);
                        _pMKHN09461UB = new PMKHN09461UB(this._extrInfo);
                        DialogResult result = _pMKHN09461UB.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            if (this.uGrid_Details.Rows.Count == 0) return;
                            // �Č���
                            this.Search();
                            // �F������߂�
                            uGrid_Details_AfterExitEditMode(null, null);
                        }
                        break;
                    }
            }
        }

        // ---ADD 2010/08/27-------------------->>>
        /// <summary>
        /// �ؑ֎��́A�t�H�[�J�X��ݒ肷��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ؑ֎��́A�t�H�[�J�X��ݒ肷��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/27</br>
        /// </remarks>
        private void ChangeRateFocus()
        {
            int rowIndex;
            int colIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                colIndex = this.uGrid_Details.ActiveCell.Column.Index;

                if (colIndex >= COLINDEX_SALERATE_ST)
                {
                    if ((colIndex - (COLINDEX_SALERATE_ST + 5)) % 6 == 0)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex - 5].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
        }
        // ---ADD 2010/08/27--------------------<<<

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != this._prevSectionCode)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());

                        // �t�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                        _guideButton.SharedProps.Enabled = false;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                        this.tEdit_MakerName.DataText = GetMakerName(makerUMnt.GoodsMakerCd);

                        // �t�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                        _guideButton.SharedProps.Enabled = true;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(�a�k�R�[�h�K�C�h)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �a�k�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void BLGoodsCdGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = null;

                // BL�R�[�h�K�C�h�\��
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BL�R�[�h
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                        // �a�k�R�[�h��
                        this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsHalfName;

                        this.tNedit_BLGloupCode.Focus();
                        _guideButton.SharedProps.Enabled = true;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(�O���[�v�R�[�h�K�C�h)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���[�v�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BL�O���[�v�K�C�h�\��
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BL�O���[�v�R�[�h
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);
                        // �O���[�v�R�[�h��
                        this.tEdit_BLGloupName.DataText = blGroupU.BLGroupName;

                        this.tComboEditor_TargetDivide.Focus();
                        _guideButton.SharedProps.Enabled = false;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// ExpandedStateChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �W�J�X�e�[�^�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 48;

            if ((this.Standard_UGroupBox.Expanded == true) || (this.Standard_UGroupBox2.Expanded == true))
            {
                topSize.Height = 210;
                Form1_Top_Panel3.Height = _panel3Height;
            }
            else
            {
                topSize.Height = 48;
                Form1_Top_Panel3.Height = _panel3Height - 162;
            }

            this.Form1_Top_Panel.Size = topSize;
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;


            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            // ADD 2010/08/27 --- >>>>>
                            this.tNedit_BLGloupCode.Focus();
                            this.tNedit_BLGloupCode.SelectAll();
                            uGrid.Rows[0].Activated = false;
                            // ADD 2010/08/27 --- <<<<<
                            // --- ADD 2010/08/30 ---------------------------------->>>>>
                            this._guideButton.SharedProps.Enabled = true;
                            // --- ADD 2010/08/30 ----------------------------------<<<<<
                        }
                        else
                        {
                            e.Handled = true;
                            for (int i = rowIndex - 1; i >= 0; i--)
                            {
                                if (!uGrid.Rows[i].Hidden)
                                {
                                    uGrid.Rows[i].Cells[colIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                            {
                                if (!uGrid.Rows[i].Hidden)
                                {
                                    uGrid.Rows[i].Cells[colIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                if ((rowIndex == 0) && (colKey == COLUMN_SUPPLIERPRICE))
                                {
                                    e.Handled = true;
                                }
                                //-----UPD 2010/08/30---------->>>>>
                                else if (colIndex == _startIndex)
                                //else if (colKey == COLUMN_SUPPLIERPRICE)
                                //-----UPD 2010/08/30----------<<<<<
                                {
                                    e.Handled = true;
                                    //-----UPD 2010/09/01---------->>>>>
                                    //for (int i = rowIndex - 1; i >= 0; i--)
                                    //{
                                    //    if (!uGrid.Rows[i].Hidden)
                                    //    {
                                    //        uGrid.Rows[i].Cells[_startIndex + (this._targetDic.Keys.Count - 1) * 6].Activate();
                                    //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    //        break;
                                    //    }
                                    //}
                                    //-----UPD 2010/09/01---------->>>>>
                                }
                                else
                                {
                                    e.Handled = true;
                                    if (colIndex > this._startIndex)
                                    {
                                        uGrid.Rows[rowIndex].Cells[colIndex - 1 * 6].Activate();
                                    }
                                    else
                                    {
                                        uGrid.Rows[rowIndex].Cells[colIndex - (this._startIndex - 8)].Activate();
                                    }
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        //-----ADD 2010/08/30---------->>>>>
                        else
                        {
                            if (colIndex == 1)
                            {
                                e.Handled = true;
                                if (rowIndex != 0)
                                {
                                    uGrid.Rows[rowIndex - 1].Cells[_startIndex + (this._targetDic.Keys.Count - 1) * 6].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        //-----ADD 2010/08/30----------<<<<<
                        break;
                    }
                case Keys.Right:
                    {
                        // UPD 2010/08/27 ---- >>>>>
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                if ((rowIndex == uGrid.Rows.Count - 1) && (colIndex == _startIndex + (this._targetDic.Keys.Count - 1) * 6))
                                {
                                    e.Handled = true;
                                }
                                else if (colIndex == _startIndex + (this._targetDic.Keys.Count - 1) * 6)
                                {
                                    e.Handled = true;
                                    //for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                    //{
                                    //    if (!uGrid.Rows[i].Hidden)
                                    //    {
                                    //        uGrid.Rows[i].Cells[_startIndex].Activate();
                                    //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    //        break;
                                    //    }
                                    //}
                                }
                                else
                                {
                                    e.Handled = true;
                                    //-----ADD 2010/08/30---------->>>>>
                                    //uGrid.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    uGrid.Rows[rowIndex].Cells[colIndex + 6].Activate();
                                    //-----ADD 2010/08/30----------<<<<<
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        //-----ADD 2010/08/30---------->>>>>
                        else
                        {
                            if (colIndex == 8)
                            {
                                e.Handled = true;
                                uGrid.Rows[rowIndex].Cells[_startIndex].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        //-----ADD 2010/08/30----------<<<<<
                        // UPD 2010/08/27 ---- <<<<<<<
                        break;
                    }
            }

        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // �ҏW�ł���͎̂d�����Ɣ������̂�
            if (cell.IsInEditMode)
            {
                //-----ADD 2010/08/31---------->>>>>
                if (uLabel_SaleRate.Text == DETAIL_TITLE_3)
                {
                    if (!KeyPressNumCheck2(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                //-----ADD 2010/08/31----------<<<<<
                // ZZZZZZZZ9.99
                //-----UPD 2010/08/31---------->>>>>
                //if (uLabel_SaleRate.Text == DETAIL_TITLE_1 || uLabel_SaleRate.Text == DETAIL_TITLE_3)
                else if (uLabel_SaleRate.Text == DETAIL_TITLE_1)
                //-----UPD 2010/08/31----------<<<<<
                {
                    if (!KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // ZZ9.99
                else if (uLabel_SaleRate.Text == DETAIL_TITLE_2 || uLabel_SaleRate.Text == DETAIL_TITLE_4
                     || uLabel_SaleRate.Text == DETAIL_TITLE_5)
                {
                    if (!KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }

                }
                // Z9.99
                else
                {
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }

            }
        }

        /// <summary>
        /// AfterCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z�����A�N�e�B�u���������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Selected = false;
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            // ���͒l�擾
            double rate = DoubleObjToDouble(this.uGrid_Details.ActiveCell.Value);

            // 0�͋󔒕\��
            if (rate == 0)
            {
                this.uGrid_Details.ActiveCell.Value = DBNull.Value;
            }

            // �������s��A�u��ԍ��̍��ڒl�v����ɁA�قȂ�l����͂����ꍇ�ɕ����F���u�ԐF�v�֕ύX����B
            //�@�܂��A�����l����͂����ꍇ�͕����F�����ɖ߂��B
            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {

                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;
                DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                    + cells[COLUMN_NO].Value.ToString() + "'")[0];

                int codeLeft = 0;
                for (int keyIndex = 0; keyIndex < _keyList.Count; keyIndex++)
                {
                    codeLeft = _keyList[0];

                    int code = _keyList[keyIndex];

                    // �����z
                    for (int i = 1; i < 7; i++)
                    {
                        double oldCode1 = DoubleObjToDouble(originalDr[code.ToString() + "title" + i]);
                        double newCode1 = DoubleObjToDouble(cells[code.ToString() + "title" + i].Value);

                        double newCodeLeft = DoubleObjToDouble(cells[codeLeft.ToString() + "title" + i].Value);
                        if (oldCode1 != newCode1 && newCode1 != newCodeLeft)
                        {
                            cells[code.ToString() + "title" + i].Appearance.ForeColor = Color.Red;
                        }
                        else
                        {
                            cells[code.ToString() + "title" + i].Appearance.ForeColor = Color.Black;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ԋu���߂���x�Ɏ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tComboEditor_ObjectDiv.Focus();
            // ---ADD 2010/08/27-------------------->>>
            // XML�f�[�^�Ǎ�
            LoadStateXmlData();
            // ---ADD 2010/08/27--------------------<<<

            // �O���b�h�̃A�N�e�B�u�s���폜
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
                this.Form1_Top_Panel3.Size = new Size(595, 187);
                this.Form1_Top_Panel5.Size = new Size(595, 23);
                this.uLabel_SaleRate.Size = new Size(177, 23);
                this.uLabel_SaleRate.Appearance.FontData.SizeInPoints = 11;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                this.uLabel_SaleRate.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                switch ((int)this.tComboEditor_GridFontSize.Value)
                {
                    case 6:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 195);
                            this.Form1_Top_Panel5.Size = new Size(595, 15);
                            this.uLabel_SaleRate.Size = new Size(177, 15);
                            break;
                        }
                    case 8:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 192);
                            this.Form1_Top_Panel5.Size = new Size(595, 18);
                            this.uLabel_SaleRate.Size = new Size(177, 18);
                            break;
                        }
                    case 9:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 190);
                            this.Form1_Top_Panel5.Size = new Size(595, 20);
                            this.uLabel_SaleRate.Size = new Size(177, 20);
                            break;
                        }
                    case 10:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 189);
                            this.Form1_Top_Panel5.Size = new Size(595, 21);
                            this.uLabel_SaleRate.Size = new Size(177, 21);
                            break;
                        }
                    case 11:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 187);
                            this.Form1_Top_Panel5.Size = new Size(595, 23);
                            this.uLabel_SaleRate.Size = new Size(177, 23);
                            break;
                        }
                    case 12:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 186);
                            this.Form1_Top_Panel5.Size = new Size(595, 24);
                            this.uLabel_SaleRate.Size = new Size(177, 24);
                            break;
                        }
                    case 14:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 183);
                            this.Form1_Top_Panel5.Size = new Size(595, 27);
                            this.uLabel_SaleRate.Size = new Size(177, 27);
                            break;
                        }
                }
            }

            this._panel3Height = this.Form1_Top_Panel3.Height;
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ώۋ敪�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tComboEditor_TargetDivide_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetDivide.Value == null)
            {
                this.tComboEditor_TargetDivide.Value = 0;
            }

            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                // ���Ӑ�|���f
                this.panel_Customer.Visible = false;
                this.panel_Customer.Size = new Size(573, 1);
                this.panel_Customer.Location = new Point(10, 34);

                this.panel_CustRateGrp.Size = new Size(573, 88);
                this.panel_CustRateGrp.Location = new Point(10, 36);
                this.panel_CustRateGrp.Visible = true;

                this.uCheckEditor_unSetting.Visible = true;
            }
            else
            {
                // ���Ӑ�
                this.panel_CustRateGrp.Visible = false;
                this.panel_CustRateGrp.Size = new Size(573, 1);
                this.panel_CustRateGrp.Location = new Point(10, 34);

                this.panel_Customer.Size = new Size(573, 88);
                this.panel_Customer.Location = new Point(10, 36);
                this.panel_Customer.Visible = true;

                this.uCheckEditor_unSetting.Visible = false;
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�|���f����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tNedit_CustRateGrpCode_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = (TNedit)sender;

            if (tNedit.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = tNedit.GetInt();

            tNedit.DataText = custRateGrpCode.ToString("0000");
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃t�H�[�J�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/08/04</br>
        /// <br>Update Note: 2010/09/06 ������ #14238�Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // �K�C�h�L��/�����̐ݒ�
            bool flag = false;
            switch (e.NextCtrl.Name)
            {
                // ���_
                case "tEdit_SectionCodeAllowZero":
                // ���[�J�[
                case "tNedit_GoodsMakerCd":
                // BL���i�R�[�h
                case "tNedit_BLGoodsCode":
                // BL�O���[�v�R�[�h
                case "tNedit_BLGloupCode":
                    {
                        flag = true;
                        break;
                    }
            }
            // ���Ӑ�|��G/���Ӑ�
            if (panel_CustRateGrp.Contains(e.NextCtrl) || panel_Customer.Contains(e.NextCtrl))
            {
                flag = true;
            }

            // �K�C�h�L���̒n�悩��K�C�h�c�[���o�[�Ƀt�H�[�J�X�ړ������ꍇ�̓K�C�h�L���ɂ���
            if ("_Form1_Toolbars_Dock_Area_Top".Equals(e.NextCtrl.Name))
            {
                switch (e.PrevCtrl.Name)
                {
                    // ���_
                    case "tEdit_SectionCodeAllowZero":
                    // ���[�J�[
                    case "tNedit_GoodsMakerCd":
                    // BL���i�R�[�h
                    case "tNedit_BLGoodsCode":
                    // BL�O���[�v�R�[�h
                    case "tNedit_BLGloupCode":
                        {
                            flag = true;
                            break;
                        }
                }
                // ���Ӑ�|��G/���Ӑ�
                if (panel_CustRateGrp.Contains(e.PrevCtrl) || panel_Customer.Contains(e.PrevCtrl))
                {
                    flag = true;
                }
            }

            this._guideButton.SharedProps.Enabled = flag;

            // --- ADD 2010/08/30 ---------------------------------->>>>>
            #region ���Ӑ�R�[�h�Ɠ��Ӑ�|���f�̓��͂ŁA�`�F�b�N���s��
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode1":
                case "tNedit_CustomerCode2":
                case "tNedit_CustomerCode3":
                case "tNedit_CustomerCode4":
                case "tNedit_CustomerCode5":
                case "tNedit_CustomerCode6":
                case "tNedit_CustomerCode7":
                case "tNedit_CustomerCode8":
                case "tNedit_CustomerCode9":
                case "tNedit_CustomerCode10":
                case "tNedit_CustomerCode11":
                case "tNedit_CustomerCode12":
                case "tNedit_CustomerCode13":
                case "tNedit_CustomerCode14":
                case "tNedit_CustomerCode15":
                case "tNedit_CustomerCode16":
                case "tNedit_CustomerCode17":
                case "tNedit_CustomerCode18":
                case "tNedit_CustomerCode19":
                case "tNedit_CustomerCode20":
                case "tNedit_CustomerCode21":
                    {
                        TNedit control = (TNedit)(this.GetType().GetField(e.PrevCtrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            int customerCd = control.GetInt();
                            CustomerInfo customerInfo = null;
                            // ���Ӑ挟�������i���Ӑ�R�[�h���j
                            int status = this._customerInputAcs.GetCustomerInfoFromCustomerCode(ConstantManagement.LogicalMode.GetDataAll, customerCd, out customerInfo);

                            if (customerInfo != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.LogicalDeleteCode == 0)
                            {
                                control.DataText = customerCd.ToString();
                                this.searchFlag = true;
                            }
                            else
                            {
                                // --- ADD 2010/08/31 ---------------------------------->>>>>
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���Ӑ悪���݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);
                                // --- ADD 2010/08/31 ----------------------------------<<<<<
                                control.DataText = string.Empty;
                                e.NextCtrl = control;
                                this.searchFlag = false;
                            }
                        }
                        else
                        {
                            this.searchFlag = true;
                        }
                        
                        break;
                    }
                case "tNedit_CustRateGrpCode1":
                case "tNedit_CustRateGrpCode2":
                case "tNedit_CustRateGrpCode3":
                case "tNedit_CustRateGrpCode4":
                case "tNedit_CustRateGrpCode5":
                case "tNedit_CustRateGrpCode6":
                case "tNedit_CustRateGrpCode7":
                case "tNedit_CustRateGrpCode8":
                case "tNedit_CustRateGrpCode9":
                case "tNedit_CustRateGrpCode10":
                case "tNedit_CustRateGrpCode11":
                case "tNedit_CustRateGrpCode12":
                case "tNedit_CustRateGrpCode13":
                case "tNedit_CustRateGrpCode14":
                case "tNedit_CustRateGrpCode15":
                case "tNedit_CustRateGrpCode16":
                case "tNedit_CustRateGrpCode17":
                case "tNedit_CustRateGrpCode18":
                case "tNedit_CustRateGrpCode19":
                case "tNedit_CustRateGrpCode20":
                case "tNedit_CustRateGrpCode21":
                    {
                        TNedit control = (TNedit)(this.GetType().GetField(e.PrevCtrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            int customerGpCd = control.GetInt();
                            if (control.Text.IndexOf(customerGpCd.ToString()) >= 0)
                            {
                                UserGdBd userGdBd = null;
                                UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                                int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 43, customerGpCd, ref acsDataType);

                                if (userGdBd != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd.LogicalDeleteCode == 0)
                                {
                                    control.DataText = customerGpCd.ToString();
                                    this.searchFlag = true;
                                }
                                else
                                {
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "���Ӑ�|���O���[�v�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
                                    control.DataText = string.Empty;
                                    e.NextCtrl = control;
                                    this.searchFlag = false;
                                }
                            }
                            else
                            {
                                control.DataText = string.Empty;
                                e.NextCtrl = control;
                            }
                        }
                        else
                        {
                            this.searchFlag = true;
                        }

                        break;
                    }
            }
            #endregion
            // --- ADD 2010/08/30 ----------------------------------<<<<<

            switch (e.PrevCtrl.Name)
            {
                // �Ώۋ敪
                case "tComboEditor_ObjectDiv":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                _guideButton.SharedProps.Enabled = true;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tComboEditor_TargetDivide;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }
                        else
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Tab)
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = e.PrevCtrl;
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }

                        break;
                    }
                // ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = "";
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                        {
                            _prevSectionCode = "00";
                            sectionCode = "00";
                        }
                        else
                        {
                            sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                        }

                        string sectionName = GetSectionName(sectionCode).Trim();

                        // �}�X�^�ɑ��݂��Ȃ��ꍇ
                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(sectionName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tEdit_SectionCodeAllowZero.Text = _prevSectionCode;
                            hasFlg = false;
                        }
                        else
                        {
                            // �Y������f�[�^�����݂����ꍇ
                            this.tEdit_SectionName.DataText = sectionName;
                            hasFlg = true;
                            _prevSectionCode = sectionCode;

                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                        _guideButton.SharedProps.Enabled = false;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        this.tEdit_SectionCodeAllowZero.SelectAll();
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = this.tComboEditor_ObjectDiv;
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }
                        break;
                    }
                // �i��
                case "tEdit_GoodsNo":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                _guideButton.SharedProps.Enabled = true;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // �t�H�[�J�X�ړ�
                        //        if (this.tEdit_SectionName.DataText.Trim() != "")
                        //        {
                        //            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                        //            _guideButton.SharedProps.Enabled = true;
                        //        }
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                // ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    {
                        if (this.tNedit_GoodsMakerCd.DataText == string.Empty)
                        {
                            _prevMakerCode = 0;
                            this.tEdit_MakerName.DataText = "";
                            return;
                        }

                        int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                        string makerName = GetMakerName(makerCode);

                        // �}�X�^�ɑ��݂��Ȃ��ꍇ
                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(makerName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���[�J�[�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_GoodsMakerCd.SetInt(_prevMakerCode);
                            hasFlg = false;
                        }
                        else
                        {
                            // �Y������f�[�^�����݂����ꍇ
                            this.tEdit_MakerName.DataText = makerName;
                            hasFlg = true;
                            _prevMakerCode = makerCode;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerName.DataText.Trim() != "")
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                        this.tNedit_GoodsMakerCd.SelectAll();
                                    }
                                    _guideButton.SharedProps.Enabled = true;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                        break;
                    }
                // ���[�J�[�K�C�h
                case "MakerGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_BLGoodsCode;
                                _guideButton.SharedProps.Enabled = true;
                            }
                        }
                        break;
                    }
                // �a�k�R�[�h
                case "tNedit_BLGoodsCode":
                    {
                        // ���͂��Ȃ�
                        if (this.tNedit_BLGoodsCode.DataText == string.Empty)
                        {
                            this._prevBLGoodsCode = 0;
                            this.tEdit_BLGoodsName.DataText = "";
                            return;
                        }
                        // ���[�J�[�R�[�h�擾
                        int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        string blGoodsName = this.GetBLGoodsName(bLGoodsCode);

                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(blGoodsName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�a�k�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_BLGoodsCode.SetInt(_prevBLGoodsCode);
                            hasFlg = false;
                        }
                        else
                        {
                            hasFlg = true;
                            this.tEdit_BLGoodsName.DataText = blGoodsName;
                            _prevBLGoodsCode = bLGoodsCode;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGoodsName.DataText.Trim() != "")
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tNedit_BLGloupCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                        this.tNedit_BLGoodsCode.SelectAll();
                                    }
                                    _guideButton.SharedProps.Enabled = true;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (tEdit_MakerName.DataText.Trim() != "")
                        //        {
                        //            // �t�H�[�J�X�ړ�
                        //            e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            _guideButton.SharedProps.Enabled = true;
                        //        }
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                // �a�k�R�[�h�K�C�h
                case "BLGoodsCdGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_BLGloupCode;
                                _guideButton.SharedProps.Enabled = true;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }

                        break;
                    }
                // �O���[�v�R�[�h
                case "tNedit_BLGloupCode":
                    {
                        // ���͂��Ȃ�
                        if (this.tNedit_BLGloupCode.DataText == string.Empty)
                        {
                            this._prevBLGroupCode = 0;
                            this.tEdit_BLGloupName.DataText = "";
                            break;
                        }

                        // �O���[�v�R�[�h�擾
                        int groupCode = this.tNedit_BLGloupCode.GetInt();
                        string groupName = this.GetBLGroupName(groupCode);

                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(groupName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�O���[�v�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_BLGloupCode.SetInt(_prevBLGroupCode);
                            hasFlg = false;
                        }
                        else
                        {
                            this.tEdit_BLGloupName.DataText = groupName;
                            hasFlg = true;
                            _prevBLGroupCode = groupCode;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGloupName.DataText.Trim() != "")
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tComboEditor_TargetDivide;
                                        _guideButton.SharedProps.Enabled = false;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BLGloupCode;
                                        this.tNedit_BLGloupCode.SelectAll();
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (tEdit_BLGoodsName.DataText.Trim() != "")
                        //        {
                        //            // �t�H�[�J�X�ړ�
                        //            e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            _guideButton.SharedProps.Enabled = true;
                        //        }
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                // �O���[�v�R�[�h�K�C�h
                case "BLGroupGuide_Button":
                    {

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_TargetDivide;
                                _guideButton.SharedProps.Enabled = false;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }

                        break;
                    }
                // �Ώۋ敪
                case "tComboEditor_TargetDivide":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �t�H�[�J�X�ړ�
                                //-----UPD 2010/09/06---------->>>>>
                                //if (this.tEdit_BLGloupName.DataText.Trim() != "")
                                //{
                                //    e.NextCtrl = this.tNedit_BLGloupCode;
                                //    _guideButton.SharedProps.Enabled = true;
                                //}
                                //else
                                //{
                                //e.NextCtrl = this.BLGroupGuide_Button;
                                //_guideButton.SharedProps.Enabled = false;
                                //}
                                e.NextCtrl = this.BLGroupGuide_Button;
                                _guideButton.SharedProps.Enabled = false;
                                //-----UPD 2010/09/06----------<<<<<
                            }
                        }
                        //-----ADD 2010/09/06---------->>>>>
                        else
                        {
                            if (e.Key == Keys.Right)
                            {
                                if (this.uCheckEditor_unSetting.Enabled)
                                {
                                    e.NextCtrl = this.uCheckEditor_unSetting;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }
                        //-----ADD 2010/09/06----------<<<<<
                        break;
                    }
                // ���Ӑ�|���f�R�[�h21�A���Ӑ�R�[�h21
                case "tNedit_CustRateGrpCode21":
                case "tNedit_CustomerCode21":
                    {
                        if (e.ShiftKey == false)
                        {
                            // --- UPD 2010/08/31 ---------------------------------->>>>>
                            //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            if (((e.Key == Keys.Enter) || (e.Key == Keys.Tab)) && this.searchFlag)
                            // --- UPD 2010/08/31 ----------------------------------<<<<<
                            {
                                // ��������
                                Search();

                            }
                        }
                        break;
                    }
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                int rowIndex;
                                int colIndex;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    e.NextCtrl = null;
                                    _guideButton.SharedProps.Enabled = false;
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox.Expanded == true)
                                        {
                                            e.NextCtrl = this.tComboEditor_ObjectDiv;
                                            _guideButton.SharedProps.Enabled = false;
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            e.NextCtrl = tComboEditor_TargetDivide;
                                            _guideButton.SharedProps.Enabled = false;
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        e.NextCtrl = null;
                                        _guideButton.SharedProps.Enabled = false;
                                        this.uGrid_Details.Rows[0].Cells[this._startIndex].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;

                                if (colIndex < 8)
                                {
                                    // �d�����Ƀt�H�[�J�X
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == this._startIndex + (this._targetDic.Count - 1) * 6)
                                {
                                    if (rowIndex == this.uGrid_Details.Rows.Count - 1) 
                                    {
                                        // �t�H�[�J�X�ړ��Ȃ�
                                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else
                                    {
                                        // �\������Ă���s�̓��Ӑ�R�[�h�P�Ƀt�H�[�J�X
                                        for (int i = rowIndex + 1; i < this.uGrid_Details.Rows.Count; i++)
                                        {
                                            if (!this.uGrid_Details.Rows[i].Hidden)
                                            {
                                                this.uGrid_Details.Rows[i].Cells[this._startIndex].Activate();
                                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                break;
                                            }
                                        }
                                        return;
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        else
                        {
                            // UPD 2010/08/27 ---- >>>>>
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {

                                int rowIndex = 0;
                                int colIndex = 0;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                                    colIndex = 8;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                            {
                                                // ���Ӑ�|���f
                                                e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                                _guideButton.SharedProps.Enabled = true;
                                            }
                                            else
                                            {
                                                // ���Ӑ�
                                                e.NextCtrl = this.tNedit_CustomerCode21;
                                                _guideButton.SharedProps.Enabled = true;
                                            }
                                        }
                                        else if (Standard_UGroupBox.Expanded == true)
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                _guideButton.SharedProps.Enabled = true;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
                                                _guideButton.SharedProps.Enabled = false;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }

                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;

                                //if (colIndex <= 8)
                                //{
                                //    if (rowIndex == 0)
                                //    {
                                //    }
                                //    else
                                //    {
                                //        // �\������Ă���s�̊|���f�Ƀt�H�[�J�X
                                //        for (int i = rowIndex - 1; i >= 0; i--)
                                //        {
                                //            if (!this.uGrid_Details.Rows[i].Hidden)
                                //            {
                                //                this.uGrid_Details.Rows[i].Cells[this._startIndex + (this._targetDic.Count - 1) * 6].Activate();
                                //                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                //                break;
                                //            }
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //if (rowIndex == 0)
                                //{

                                    //this.tNedit_BLGloupCode.Focus();
                                    //this.tNedit_BLGloupCode.SelectAll();
                                    //this.uGrid_Details.Rows[0].Activated = false;

                                    //this._guideButton.SharedProps.Enabled = true;

                                //}
                                //else
                                //{
                                if (!MoveNextAllowEditCell(false))
                                {
                                    if (Standard_UGroupBox2.Expanded == true)
                                    {
                                        if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                        {
                                            // ���Ӑ�|���f
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                        else
                                        {
                                            // ���Ӑ�
                                            e.NextCtrl = this.tNedit_CustomerCode21;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                    }
                                    else if (Standard_UGroupBox.Expanded == true)
                                    {
                                        if (this.tEdit_MakerName.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.MakerGuide_Button;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    return;
                                }
                                //}

                                    //this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                //}
                            }
                            // UPD 2010/08/27 ---- <<<<<
                        }
                        break;
                    }
                //-----ADD 2010/09/06---------->>>>>
                    //���ݒ�
                case "uCheckEditor_unSetting":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }
                        break;
                    }
                //-----ADD 2010/09/06---------->>>>>
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                    // --- UPD 2010/08/30 ---------------------------------->>>>>
                                    //if ("tNedit_BLGloupCode".Equals(e.PrevCtrl.Name))
                                    if ("tNedit_BLGloupCode".Equals(e.PrevCtrl.Name) || panel_CustRateGrp.Contains(e.PrevCtrl) || panel_Customer.Contains(e.PrevCtrl))
                                    {
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                    // --- UPD 2010/08/30 ----------------------------------<<<<<
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
                                    if (this.tNedit_CustomerCode1.Focused)
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode1;
                                    }
                                    else if (this.tNedit_CustRateGrpCode1.Focused)
                                    {
                                        e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                    }
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[0].Cells[_startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    if ((Standard_UGroupBox.Expanded == false) &&
                                        (Standard_UGroupBox2.Expanded == false))
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else if (Standard_UGroupBox.Expanded == true)
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                    else
                                    {
                                        if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                        {
                                            // ���Ӑ�|���f
                                            e.NextCtrl = this.tNedit_CustRateGrpCode15;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                        else
                                        {
                                            // ���Ӑ�
                                            e.NextCtrl = this.tNedit_CustomerCode15;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[_startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[_startIndex + (this._targetDic.Keys.Count - 1)].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }
        // ADD 2010/08/27 ---- >>>>>
        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/27</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                if (performActionResult)
                {
                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Details.ResumeLayout();
            return performActionResult;
        }
        // ADD 2010/08/27 ---- <<<<<
        #endregion �� Control Events

    }
}