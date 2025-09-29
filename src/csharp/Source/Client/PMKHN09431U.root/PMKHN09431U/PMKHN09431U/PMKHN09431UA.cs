//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꊇ�C��
// �v���O�����T�v   : �����ꊇ�C�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2009/07/09  �C�����e : PVCS#323 ���ږ��̂̕ύX 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2009/09/03  �C�����e : PVCS#427 ���ו��̃N���A�����̕ύX 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �C �� ��  2009/11/30  �C�����e : ���Ӑ�|���O���[�v���� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30531�@���r��
// �C �� ��  2010/04/20  �C�����e : ���Ӑ�|��G���ݒ�̂Ƃ��A�C���E�X�V�ł���悤�C�� 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����ꊇ�C��UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �����ꊇ�C��UI�t�H�[���N���X</br>
    /// <br>Programmer  : ���M</br>
    /// <br>Date        : 2009/04/01</br>
    /// </remarks>
    public partial class PMKHN09431UA : Form
    {
        #region �� Constants

        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMKHN09431U";

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMKHN09431U.dat";

        // �O���b�h��
        private const string COLUMN_NO = "No";
        private const string COLUMN_GOODSNO = "GoodsNo";
        private const string COLUMN_PRICEFL = "PriceFl";
        private const string COLUMN_USERPRICEFL = "UserPriceFl";
        private const string COLUMN_RATEVAL = "RateVal";
        private const string COLUMN_GOODSMAKERCD = "GoodsMakerCd";
        private const string COLUMN_SALERATE1 = "SaleRate1";
        private const string COLUMN_SALERATE2 = "SaleRate2";
        private const string COLUMN_SALERATE3 = "SaleRate3";
        private const string COLUMN_SALERATE4 = "SaleRate4";
        private const string COLUMN_SALERATE5 = "SaleRate5";
        private const string COLUMN_SALERATE6 = "SaleRate6";
        private const string COLUMN_SALERATE7 = "SaleRate7";
        private const string COLUMN_SALERATE8 = "SaleRate8";
        private const string COLUMN_SALERATE9 = "SaleRate9";
        private const string COLUMN_SALERATE10 = "SaleRate10";
        private const string COLUMN_SALERATE11 = "SaleRate11";
        private const string COLUMN_SALERATE12 = "SaleRate12";
        private const string COLUMN_SALERATE13 = "SaleRate13";
        private const string COLUMN_SALERATE14 = "SaleRate14";
        private const string COLUMN_SALERATE15 = "SaleRate15";
        private const string COLUMN_SALERATE16 = "SaleRate16";
        private const string COLUMN_SALERATE17 = "SaleRate17";
        private const string COLUMN_SALERATE18 = "SaleRate18";
        private const string COLUMN_SALERATE19 = "SaleRate19";
        private const string COLUMN_SALERATE20 = "SaleRate20";
        private const string COLUMN_SALERATE21 = "SaleRate21";

        private const int COLINDEX_SALERATE_ST = 6;
        private const int COLINDEX_SALERATE_ED = 26;

        private const string FORMAT = "#,##0.00;-#,##0.00;''";
        private const string FORMAT_NO = "#,##0;-#,##0;''";

        #endregion �� Constants

        #region �� Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SecInfoAcs _secInfoAcs;                                 // ���_���A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;                           // ���_���ݒ�A�N�Z�X�N���X
        private MakerAcs _makerAcs;                                     // ���[�J�[�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs;                             // BL�R�[�h�K�C�h�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;                             // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private SaleRateUpdateAcs _saleRateUpdateAcs;                //�����ꊇ�C���A�N�Z�X�N���X

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        private Dictionary<int, BLGoodsCdUMnt> _bLGoodsCdDic;
        private Dictionary<int, string> _custRateGrpDic;

        private TNedit[] _tNedit_CustRateGrpCode;

        private Dictionary<int, int> _targetDic = new Dictionary<int, int>();

        private SalesRateSearchParam _extrInfo;

        private List<GoodsUnitData> _goodDisplayList;
        private List<Rate> _rateDisplayList;
        private List<Rate> _userRateDisplayList;
        private List<Rate> _rateDisplayListClone;

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private int _tmpGoodsMakerCd;
        private string _tmpSectionCode;
        private int _tmpBLGoodsCode;

        private string _searchSectionCode;

        DataTable _dataTableClone = new DataTable();

        private int _xml_static = 0;

        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// �����ꊇ�C��UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����ꊇ�C��UI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        public PMKHN09431UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._saleRateUpdateAcs = new SaleRateUpdateAcs();
            this._gridStateController = new GridStateController();

            // �}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadMakerUMnt();
            ReadBLGoodsCdUMnt();
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/04/01</br>
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
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
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
        }
        #endregion XML����

        #region �}�X�^�Ǎ�
        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_���}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            this._bLGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt bLGoodsCdUMnt in retList)
                    {
                        if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._bLGoodsCdDic.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._bLGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(���Ӑ�|���f)�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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
                        this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                    }
                }
            }
            catch
            {
                this._custRateGrpDic = new Dictionary<int, string>();
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// <param name="bLGoodsCode">���[�J�[�R�[�h</param>
        /// <returns>�a�k�R�[�h��</returns>
        /// <remarks>
        /// <br>Note        : �a�k�R�[�h�ɊY�����閼�̂��擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private string GetBLGoodsName(int bLGoodsCode)
        {
            if (this._bLGoodsCdDic.ContainsKey(bLGoodsCode))
            {
                return this._bLGoodsCdDic[bLGoodsCode].BLGoodsFullName.Trim();
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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

        #region �`�F�b�N����
        /// <summary>
        /// ���������`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������`�F�b�N���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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
                    return (false);
                }

                // ���[�J�[�R�[�h
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    errMsg = "���[�J�[�R�[�h����͂��Ă��������B";
                    this.tNedit_GoodsMakerCd.Focus();
                    return (false);
                }

                bool inputFlg = false;

                // ���Ӑ�|���f
                for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
                {
                    if (this._tNedit_CustRateGrpCode[index].DataText.Trim() != "")
                    {
                        int custRateGrpCode = this._tNedit_CustRateGrpCode[index].GetInt();

                        if (GetCustRateGrpName(custRateGrpCode) == "")
                        {
                            errMsg = "�w�肳�ꂽ�����œ��Ӑ�|��G�͑��݂��܂���ł����B";
                            this._tNedit_CustRateGrpCode[index].Focus();
                            return (false);
                        }

                        inputFlg = true;
                    }
                }

                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // TODO:���Ӑ�|���O���[�v�̓��͂������A���ݒ�`�F�b�N���Ȃ��ꍇ
                if (!inputFlg) inputFlg = this.chkSearchingAll.Checked;
                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                if (inputFlg == false)
                {
                    errMsg = "���Ӑ�|���f����͂��Ă��������B";
                    this.tNedit_CustRateGrpCode1.Focus();
                    return (false);
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�������s�@False:�������f)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ����r���A�ύX����Ă���ꍇ�̓��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        public bool CompareScreen()
        {
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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

        #region �����ݒ�
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // �R���g���[���z��
            //---------------------------------

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
            for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
            {
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

            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

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
            this.BLGoodsGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // �O���b�h�ݒ�
            //---------------------------------

            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA);

            _xml_static = status;

            CreateGrid(ref this.uGrid_Details);

        }

        #endregion �����ݒ�

        #region �ۑ�
        /// <summary>
        /// TODO:�ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��ʏ��擾
            ArrayList updateList;
            ArrayList deleteList;

            GetUpdateList(out updateList, out deleteList);

            // ��ʏ��`�F�b�N
            string errMsg = "";

            try
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    errMsg = "�ۑ��Ώۃf�[�^�����݂��܂���B";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    return (status);
                }
                if ((updateList.Count == 0) && (deleteList.Count == 0))
                {
                    errMsg = "�ۑ��Ώۃf�[�^�����݂��܂���B";
                    this.uGrid_Details.Rows[0].Cells[COLUMN_RATEVAL].Activate();
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
            if (deleteList.Count > 0 || updateList.Count > 0)
            {
                status = this._saleRateUpdateAcs.Save(ref deleteList, ref updateList, out errMsg);
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

                            this.tEdit_SectionCodeAllowZero.Focus();
                            return (status);
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "Save",
                                           "�ۑ������Ɏ��s���܂����B",
                                           status,
                                           MessageBoxButtons.OK);

                            this.tEdit_SectionCodeAllowZero.Focus();
                            return (status);
                        }
                }
            }

            // --- DEL 2009/09/03 ---------->>>>> 
            // �Č���
            //List<GoodsUnitData> goodsSearchResultList;
            //List<Rate> rateSearchResultList = new List<Rate>();
            //List<Rate> userRateSearchResultLis = new List<Rate>();

            //// ���i�}�X�^��������
            //status = this._saleRateUpdateAcs.Search(out goodsSearchResultList, this._extrInfo, out errMsg);

            //if (status == 0 && goodsSearchResultList.Count != 0)
            //{
            //    // �|���}�X�^.������������
            //    status = this._saleRateUpdateAcs.Search(out rateSearchResultList, out userRateSearchResultLis, goodsSearchResultList, this._extrInfo, out errMsg);
            //}

            //if (status == 0)
            //{
            //    // �O���b�h�\�����X�g�擾
            //    GetDisplayList(goodsSearchResultList, rateSearchResultList, userRateSearchResultLis);

            //    // �O���b�h�f�[�^�ݒ�
            //    CreateGrid(ref this.uGrid_Details);
            //}

            //this.uGrid_Details.ActiveRow = null;

            //this.tEdit_SectionCodeAllowZero.Focus();
            //--- DEL 2009/09/03 ----------<<<<<

            // �o�^�����_�C�A���O�\��
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            return (status);
        }

        #endregion �ۑ�

        #region ����
        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private int Search()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �����������̓`�F�b�N
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return -1;
            }

            // �o�^�E�C���ΏۃR�[�h�擾
            this._targetDic = new Dictionary<int, int>();

            int custRateGrpCode;

            TNedit[] CustRateGrpCode = new TNedit[21];
            CustRateGrpCode = this._tNedit_CustRateGrpCode;

            for (int i = 0; i < CustRateGrpCode.Length; i++)
            {
                for (int j = i; j < CustRateGrpCode.Length; j++)
                {
                    if (CustRateGrpCode[i].GetInt() >= CustRateGrpCode[j].GetInt())
                    {
                        TNedit x = CustRateGrpCode[i];
                        CustRateGrpCode[i] = CustRateGrpCode[j];
                        CustRateGrpCode[j] = x;
                    }
                }
            }

            // TODO:���Ӑ�|���f
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            if (this.chkSearchingAll.Checked)
            {
                this._targetDic.Add(SaleRateUpdateAcs.ALL_CUST_RATE_GRP_CODE, SaleRateUpdateAcs.ALL_CUST_RATE_GRP_CODE);
            }
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            for (int index = 0; index < CustRateGrpCode.Length; index++)
            {
                if (CustRateGrpCode[index].DataText.Trim() == "")
                {
                    continue;
                }

                custRateGrpCode = CustRateGrpCode[index].GetInt();

                if (!this._targetDic.ContainsKey(custRateGrpCode))
                {
                    this._targetDic.Add(custRateGrpCode, custRateGrpCode);
                }
            }

            // ���������i�[
            SetExtrInfo(out this._extrInfo);

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "���i�}�X�^�̒��o���ł��B";


            List<GoodsUnitData> goodsSearchResultList;
            List<Rate> rateSearchResultList = new List<Rate>();
            List<Rate> userRateSearchResultLis = new List<Rate>();

            try
            {
                msgForm.Show();

                string errMsg;

                _saleRateUpdateAcs.GoodsPriceUList = new ArrayList();

                // TODO:���i�}�X�^��������
                status = this._saleRateUpdateAcs.Search(out goodsSearchResultList, this._extrInfo, out errMsg);

                if (status == 0 && goodsSearchResultList.Count != 0)
                {
                    // TODO:�|���}�X�^.������������
                    status = this._saleRateUpdateAcs.Search(out rateSearchResultList, out userRateSearchResultLis, goodsSearchResultList, this._extrInfo, out errMsg);
                }

                if (goodsSearchResultList.Count != 0)
                {
                    _xml_static = 0;

                    // �O���b�h�\�����X�g�擾
                    GetDisplayList(goodsSearchResultList, rateSearchResultList, userRateSearchResultLis);

                    // �O���b�h�f�[�^�ݒ�
                    CreateGrid(ref this.uGrid_Details);

                    this.uGrid_Details.ActiveRow = null;

                    this.Replace_Button.Enabled = true;

                    this.Replace_Button.Focus();

                    return (status);
                }

            }
            finally
            {
                msgForm.Close();
            }

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
        /// ���������ݒ菈��
        /// </summary>
        /// <param name="para">��������</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂猟��������ݒ肵�܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void SetExtrInfo(out SalesRateSearchParam para)
        {
            para = new SalesRateSearchParam();

            // ��ƃR�[�h
            para.EnterpriseCode = this._enterpriseCode;

            // ���_
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // �S�Ўw��
                para.SectionCode = string.Empty;
            }
            else
            {
                para.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            // BL���i�R�[�h
            para.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

            // ���[�J�[
            para.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // ���Ӑ�|���f
            // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            //para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
            // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            if (!this.chkSearchingAll.Checked)
            {
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
            }
            else
            {
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count + 1];
            }
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

            int index = 0;
            foreach (int key in this._targetDic.Keys)
            {
                para.CustRateGrpCode[index] = key;
                index++;
            }

            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            // TODO:���Ӑ�|���O���[�v�R�[�h(=-1)�F�w��Ȃ���
            if (para.CustRateGrpCode.Length > this._targetDic.Keys.Count)
            {
                // this._targetDic �̐擪��"�w��Ȃ�"��ǉ����Ă���̂� 0 �Ԗ�
                para.CustRateGrpCode[0] = SaleRateUpdateAcs.ALL_CUST_RATE_GRP_CODE;
            }
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

            // ���O�C�����_
            para.PrmSectionCode = new string[1];
            para.PrmSectionCode[0] = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._searchSectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
        }

        #endregion ����

        #region �f�[�^�擾
        /// <summary>
        /// �O���b�h�\�����X�g�擾����
        /// </summary>
        /// <param name="goodsSearchResultList">�|���}�X�^�������ʃ��X�g</param>
        /// <param name="rateSearchResultList">�|���}�X�^�����p���[���^</param>
        /// <param name="userRateSearchResultLis">�|���}�X�^�����p���[���^</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�ɕ\�����郊�X�g���擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void GetDisplayList(List<GoodsUnitData> goodsSearchResultList, List<Rate> rateSearchResultList, List<Rate> userRateSearchResultLis)
        {
            this._goodDisplayList = new List<GoodsUnitData>();

            foreach (GoodsUnitData goodsUnitData in goodsSearchResultList)
            {
                this._goodDisplayList.Add(goodsUnitData);
            }

            _rateDisplayListClone = new List<Rate>();

            _rateDisplayListClone = rateSearchResultList;

            // �d�����Ă���f�[�^������ꍇ�́A�ŏ����b�g���̃f�[�^���擾
            Dictionary<string, Rate> parentDic = new Dictionary<string, Rate>();
            foreach (Rate rateSearchResult in rateSearchResultList)
            {
                string key = MakeRateKey(rateSearchResult);
                if (!parentDic.ContainsKey(key))
                {
                    parentDic.Add(key, rateSearchResult.Clone());
                }
                else
                {
                    if (rateSearchResult.LotCount < parentDic[key].LotCount)
                    {
                        parentDic[key] = rateSearchResult.Clone();
                    }
                }
            }

            _rateDisplayList = new List<Rate>();

            foreach (Rate result in parentDic.Values)
            {
                this._rateDisplayList.Add(result.Clone());
            }

            // �d�����Ă���f�[�^������ꍇ
            Dictionary<string, Rate> childDic = new Dictionary<string, Rate>();
            foreach (Rate userRateSearchResult in userRateSearchResultLis)
            {
                string key = MakeKey(userRateSearchResult);
                if (!childDic.ContainsKey(key))
                {
                    childDic.Add(key, userRateSearchResult.Clone());
                }
            }

            _userRateDisplayList = new List<Rate>();

            foreach (Rate useresult in childDic.Values)
            {
                this._userRateDisplayList.Add(useresult.Clone());
            }

        }

        /// <summary>
        /// �X�V�f�[�^�擾����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="deleteList">�폜���X�g</param>
        /// <remarks>
        /// <br>Note        : �X�V�f�[�^���擾���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            string key;

            saveList = new ArrayList();
            deleteList = new ArrayList();

            this.uGrid_Details.ActiveCell = null;

            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {
                List<Rate> resultList;

                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

                DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                    + cells[COLUMN_NO].Value.ToString() + "'")[0];

                key = MakeKey(StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value), cells[COLUMN_GOODSNO].Value.ToString().Trim(), this._searchSectionCode);

                resultList = this._rateDisplayList.FindAll(delegate(Rate target)
                {
                    if (key.Equals(MakeKey(target.GoodsMakerCd, target.GoodsNo, target.SectionCode)))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                Rate result = new Rate();

                // ����
                foreach (int code in this._targetDic.Keys)
                {
                    double olddata = Convert.ToDouble(originalDr[code.ToString()]);
                    double newdata = Convert.ToDouble(cells[code.ToString()].Value);
                    if (newdata != olddata)
                    {
                        Rate updateRate = new Rate();

                        result = resultList.Find(delegate(Rate target)
                            {
                                if (target.CustRateGrpCode == code)
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                        if (result == null && 0 != DoubleObjToDouble(cells[code.ToString()].Value))
                        {
                            // TODO:�f�[�^�ǉ�
                            #region �V�K�f�[�^�ǉ�
                            updateRate.EnterpriseCode = this._enterpriseCode;
                            updateRate.SectionCode = this._searchSectionCode;
                            updateRate.LotCount = 9999999.99;
                            updateRate.UnPrcFracProcUnit = 0;
                            updateRate.UnPrcFracProcDiv = 0;

                            // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            //updateRate.UnitRateSetDivCd = "14A";
                            //updateRate.RateSettingDivide = "4A";
                            //updateRate.RateMngCustCd = "4";
                            //updateRate.RateMngCustNm = "���Ӑ�|���O���[�v";
                            // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                            updateRate.UnitRateSetDivCd = code >= 0 ? "14A" : "16A";
                            updateRate.RateSettingDivide = code >= 0 ? "4A" : "6A";
                            updateRate.RateMngCustCd = code >= 0 ? "4" : "6";
                            updateRate.RateMngCustNm = code >= 0 ? "���Ӑ�|���O���[�v" : "�w��Ȃ�";
                            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                            // --- DEL  ���r��  2010/04/20 ---------->>>>>
                            //updateRate.CustRateGrpCode = code;
                            // --- DEL  ���r��  2010/04/20 ----------<<<<<
                            // --- ADD  ���r��  2010/04/20 ---------->>>>>
                            if (code == -1)
                            {
                                updateRate.CustRateGrpCode = 0;
                            }
                            else
                            {
                                updateRate.CustRateGrpCode = code;
                            }
                            // --- ADD  ���r��  2010/04/20 ----------<<<<<
                            updateRate.RateMngGoodsCd = "A";
                            updateRate.RateMngGoodsNm = "Ұ���{�i��";
                            updateRate.BLGoodsCode = 0;
                            updateRate.UnitPriceKind = "1";
                            updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value);
                            updateRate.GoodsNo = cells[COLUMN_GOODSNO].Value.ToString().Trim();
                            updateRate.SupplierCd = 0;
                            updateRate.RateVal = 0;
                            updateRate.GoodsRateRank = string.Empty;
                            updateRate.PriceFl = DoubleObjToDouble(cells[code.ToString()].Value);
                            saveList.Add(updateRate.Clone());

                            #endregion �V�K�f�[�^�ǉ�
                        }
                        else if (result != null)
                        {
                            string ratekey = MakeRateKey(result);
                            List<Rate> rateresultList = new List<Rate>();

                            rateresultList = this._rateDisplayListClone.FindAll(delegate(Rate target)
                            {
                                if (ratekey.Equals(MakeRateKey(target)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (Rate rateresult in rateresultList)
                            {
                                if (rateresult.LogicalDeleteCode == 0 || DoubleObjToDouble(cells[code.ToString()].Value) != 0)
                                {
                                    #region �폜�f�[�^�ǉ�

                                    updateRate.EnterpriseCode = this._enterpriseCode;
                                    updateRate.SectionCode = this._searchSectionCode;

                                    // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                    //updateRate.UnitRateSetDivCd = "14A";
                                    // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                                    // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                    updateRate.UnitRateSetDivCd = result.UnitRateSetDivCd;
                                    // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                                    updateRate.GoodsRateGrpCode = result.GoodsRateGrpCode;
                                    updateRate.GoodsRateRank = result.GoodsRateRank;
                                    updateRate.BLGroupCode = result.BLGroupCode;
                                    updateRate.BLGoodsCode = result.BLGoodsCode;
                                    updateRate.CustomerCode = result.CustomerCode;
                                    updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value);
                                    updateRate.GoodsNo = cells[COLUMN_GOODSNO].Value.ToString().Trim();
                                    // --- DEL  ���r��  2010/04/20 ---------->>>>>
                                    //updateRate.CustRateGrpCode = code;
                                    // --- DEL  ���r��  2010/04/20 ----------<<<<<
                                    // --- ADD  ���r��  2010/04/20 ---------->>>>>
                                    if (code == -1)
                                    {
                                        updateRate.CustRateGrpCode = 0;
                                    }
                                    else
                                    {
                                        updateRate.CustRateGrpCode = code;
                                    }
                                    // --- ADD  ���r��  2010/04/20 ----------<<<<<
                                    updateRate.SupplierCd = result.SupplierCd;
                                    updateRate.LotCount = rateresult.LotCount;
                                    updateRate.UpdateDateTime = rateresult.UpdateDateTime;

                                    deleteList.Add(updateRate.Clone());

                                    #endregion �폜�f�[�^�ǉ�
                                }
                            }
                            if (0 != DoubleObjToDouble(cells[code.ToString()].Value))
                            {
                                #region �V�K�f�[�^�ǉ�

                                // TODO:�f�[�^�ǉ�
                                updateRate.EnterpriseCode = this._enterpriseCode;
                                updateRate.SectionCode = this._searchSectionCode;

                                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                //updateRate.UnitRateSetDivCd = "14A";
                                //updateRate.RateSettingDivide = "4A";
                                //updateRate.RateMngCustCd = "4";
                                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                updateRate.UnitRateSetDivCd = code >= 0 ? "14A" : "16A";
                                updateRate.RateSettingDivide = code >= 0 ? "4A" : "6A";
                                updateRate.RateMngCustCd = code >= 0 ? "4" : "6";
                                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                                updateRate.RateMngGoodsCd = "A";
                                updateRate.GoodsRateGrpCode = 0;
                                updateRate.GoodsRateRank = string.Empty;
                                updateRate.BLGroupCode = 0;
                                updateRate.BLGoodsCode = 0;
                                updateRate.CustomerCode = 0;
                                updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value);
                                updateRate.LotCount = 9999999.99;
                                updateRate.UnPrcFracProcUnit = 0;
                                updateRate.UnPrcFracProcDiv = 0;

                                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                //updateRate.RateMngCustNm = "���Ӑ�|���O���[�v";
                                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                                updateRate.RateMngCustNm = code >= 0 ? "���Ӑ�|���O���[�v" : "�w��Ȃ�";
                                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                                updateRate.RateMngGoodsNm = "Ұ���{�i��";
                                updateRate.BLGoodsCode = 0;
                                updateRate.UnitPriceKind = "1";
                                updateRate.SupplierCd = 0;
                                updateRate.RateVal = 0;
                                updateRate.GoodsRateRank = string.Empty;
                                // --- DEL  ���r��  2010/04/20 ---------->>>>>
                                //updateRate.CustRateGrpCode = code;
                                // --- DEL  ���r��  2010/04/20 ----------<<<<<
                                // --- ADD  ���r��  2010/04/20 ---------->>>>>
                                if (code == -1)
                                {
                                    updateRate.CustRateGrpCode = 0;
                                }
                                else
                                {
                                    updateRate.CustRateGrpCode = code;
                                }
                                // --- ADD  ���r��  2010/04/20 ----------<<<<<
                                updateRate.SupplierCd = 0;
                                updateRate.PriceFl = DoubleObjToDouble(cells[code.ToString()].Value);
                                updateRate.UpdateDateTime = DateTime.MinValue;

                                saveList.Add(updateRate.Clone());

                                #endregion �V�K�f�[�^�ǉ�
                            }
                        }
                    }
                }
            }
        }

        #endregion �f�[�^�擾

        #region �Z���l�ϊ�
        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>String�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
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
        /// <returns>Double�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
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

        #region �N���A����
        /// <summary>
        /// ��ʏ��N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void ClearScreen()
        {
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "�S��";
            this._tmpSectionCode = "00";
            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            _tmpGoodsMakerCd = 0;
            // BL�R�[�h
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            _tmpBLGoodsCode = 0;

            // ���Ӑ�|��G
            for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
            {
                this._tNedit_CustRateGrpCode[index].Clear();
            }

            // �X�N���[���|�W�V����������
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // �O���b�h�N���A
            ClearGrid();

            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// �O���b�h����������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�����������s���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void ClearGrid()
        {
            this._targetDic = new Dictionary<int, int>();
            this._goodDisplayList = new List<GoodsUnitData>();
            this._rateDisplayList = new List<Rate>();
            this._userRateDisplayList = new List<Rate>();
            this._rateDisplayListClone = new List<Rate>();

            // �O���b�h�쐬����
            CreateGrid(ref this.uGrid_Details);
        }

        #endregion �N���A����

        #region �O���b�h�ݒ�
        /// <summary>
        /// TODO:�O���b�h�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�̗���쐬���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            DataTable dataTable = new DataTable();

            // No
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // �i��
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // �艿
            dataTable.Columns.Add(COLUMN_PRICEFL, typeof(double));
            // ���[�U�[�艿
            dataTable.Columns.Add(COLUMN_USERPRICEFL, typeof(double));
            // �d������
            dataTable.Columns.Add(COLUMN_RATEVAL, typeof(double));
            //���[�J�[�R�[�h
            dataTable.Columns.Add(COLUMN_GOODSMAKERCD, typeof(int));
            if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
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
                    dataTable.Columns.Add(key.ToString(), typeof(double));
                    dataTable.Columns[key.ToString()].DefaultValue = 0;
                }
            }

            uGrid.DataSource = dataTable;

            // �O���b�h�X�^�C���ݒ�
            SetGridLayout(ref uGrid);

            // �f�[�^�������ꍇ
            if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
            {
                return;
            }

            dataTable.AcceptChanges();

            try
            {
                List<Rate> targetList;

                List<Rate> usertargetList;

                // �d����������
                this._saleRateUpdateAcs.SearchGoodsPriceU(_goodDisplayList, _searchSectionCode);

                for (int index = 0; index < this._goodDisplayList.Count; index++)
                {
                    // �s�ǉ�
                    DataRow row = dataTable.NewRow();

                    GoodsUnitData goodsresult = (GoodsUnitData)this._goodDisplayList[index];

                    // No
                    row[COLUMN_NO] = index + 1;

                    //�i��
                    row[COLUMN_GOODSNO] = goodsresult.GoodsNo;

                    //���i
                    if (goodsresult.GoodsPriceList != null && goodsresult.GoodsPriceList.Count != 0)
                    {
                        row[COLUMN_PRICEFL] = GetListPrice(goodsresult.GoodsPriceList);
                    }

                    //���[�U�[�艿
                    usertargetList = this._userRateDisplayList.FindAll(delegate(Rate usertarget)
                    {
                        if (MakeKey(goodsresult.GoodsMakerCd, goodsresult.GoodsNo, this._searchSectionCode).Equals(MakeKey(usertarget.GoodsMakerCd, usertarget.GoodsNo, usertarget.SectionCode)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (usertargetList != null && usertargetList.Count != 0)
                    {
                        row[COLUMN_USERPRICEFL] = usertargetList[0].PriceFl;
                    }

                    //�d������
                    row[COLUMN_RATEVAL] = _saleRateUpdateAcs.GetStockUnitPrice(goodsresult);

                    //���i���[�J�[�R�[�h
                    row[COLUMN_GOODSMAKERCD] = goodsresult.GoodsMakerCd;

                    targetList = this._rateDisplayList.FindAll(delegate(Rate target)
                    {
                        if (MakeKey(goodsresult.GoodsMakerCd, goodsresult.GoodsNo, this._searchSectionCode).Equals(MakeKey(target.GoodsMakerCd, target.GoodsNo, target.SectionCode)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    //����
                    foreach (Rate rate in targetList)
                    {
                        if (this._targetDic.ContainsKey(rate.CustRateGrpCode))
                        {
                            // ���Ӑ�|���f
                            if (rate.PriceFl != 0 && rate.LogicalDeleteCode == 0)
                            {
                                row[rate.CustRateGrpCode.ToString()] = rate.PriceFl;
                            }
                        }
                    }

                    dataTable.Rows.Add(row);
                }
            }
            finally
            {
                _dataTableClone = dataTable.Copy();
            }

        }

        /// <summary>
        /// �O���b�h�X�^�C���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�̃X�^�C����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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

                // �艿
                //columns[COLUMN_PRICEFL].Header.Caption = "�艿"; // DEL 2009/07/09
                columns[COLUMN_PRICEFL].Header.Caption = "���i"; // ADD 2009/07/09
                columns[COLUMN_PRICEFL].Header.Fixed = true;
                columns[COLUMN_PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_PRICEFL].CellActivation = Activation.NoEdit;
                columns[COLUMN_PRICEFL].Format = FORMAT_NO;

                if (_xml_static != 0)
                {
                    columns[COLUMN_PRICEFL].Hidden = false;
                }

                // ���[�U�[�艿
                //columns[COLUMN_USERPRICEFL].Header.Caption = "���[�U�[�艿";  // ADD 2009/07/09
                columns[COLUMN_USERPRICEFL].Header.Caption = "���[�U�[���i";  // ADD 2009/07/09
                columns[COLUMN_USERPRICEFL].Header.Fixed = true;
                columns[COLUMN_USERPRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_USERPRICEFL].CellActivation = Activation.NoEdit;
                columns[COLUMN_USERPRICEFL].Format = FORMAT_NO;

                if (_xml_static != 0)
                {
                    columns[COLUMN_USERPRICEFL].Hidden = true;
                }

                // �d������
                columns[COLUMN_RATEVAL].Header.Caption = "�d������";
                columns[COLUMN_RATEVAL].Header.Fixed = true;
                columns[COLUMN_RATEVAL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_RATEVAL].CellActivation = Activation.NoEdit;
                columns[COLUMN_RATEVAL].Format = FORMAT;

                // ���i���[�J�[�R�[�h
                columns[COLUMN_GOODSMAKERCD].Header.Caption = "���i���[�J�[�R�[�h";
                columns[COLUMN_GOODSMAKERCD].Hidden = true;
                columns[COLUMN_GOODSMAKERCD].Header.Fixed = true;
                columns[COLUMN_GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_GOODSMAKERCD].CellActivation = Activation.NoEdit;

                // ����
                if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
                {
                    for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                    {
                        columns[index].Header.Caption = "";
                        columns[index].Format = FORMAT;
                        columns[index].CellAppearance.TextHAlign = HAlign.Right;
                        columns[index].CellActivation = Activation.AllowEdit;
                    }
                }
                else
                {
                    foreach (int key in this._targetDic.Keys)
                    {
                        columns[key.ToString()].Header.Caption = ((int)this._targetDic[key]).ToString("0000");
                        
                        // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        if (((int)this._targetDic[key]) < 0) columns[key.ToString()].Header.Caption = "ALL";   // HACK:"ALL"
                        // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                        columns[key.ToString()].Format = FORMAT;
                        columns[key.ToString()].CellAppearance.TextHAlign = HAlign.Right;
                        columns[key.ToString()].CellActivation = Activation.AllowEdit;
                    }
                }

                // �O���b�h�񕝐ݒ�
                SetColumnWidth(ref uGrid);
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void SetColumnWidth(ref UltraGrid uGrid)
        {
            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            // No
            columns[COLUMN_NO].Width = 45;
            // �i��
            columns[COLUMN_GOODSNO].Width = 275;
            // �艿
            columns[COLUMN_PRICEFL].Width = 120;
            // ���[�U�[�艿
            columns[COLUMN_USERPRICEFL].Width = 120;
            // �d������
            columns[COLUMN_RATEVAL].Width = 120;
            // ����
            if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
            {
                for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                {
                    columns[index].Width = 110;
                }
            }
            else
            {
                foreach (int key in this._targetDic.Keys)
                {
                    columns[key.ToString()].Width = 110;
                }
            }
        }

        /// <summary>
        /// ���i����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        public double GetListPrice(List<GoodsPrice> goodsPriceList)
        {
            double listprice = 0;
            DateTime time = DateTime.Now;

            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                if (goodsPrice.PriceStartDate.CompareTo(time) <= 0)
                {
                    listprice = goodsPrice.ListPrice;

                    return listprice;
                }
            }

            return listprice;
        }

        #endregion �O���b�h�ݒ�

        #region Key�쐬
        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="rateSearchResult">�|���}�X�^��������</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private string MakeKey(Rate rateSearchResult)
        {
            // ���_�R�[�h�{�P���|���ݒ�敪�{���i���[�J�[�R�[�h+���i�ԍ�
            string key = rateSearchResult.SectionCode +
                         rateSearchResult.UnitRateSetDivCd +
                         rateSearchResult.GoodsMakerCd +
                         rateSearchResult.GoodsNo;


            return key;
        }

        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="SectionCode">���_</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private string MakeKey(int goodsMakerCd, string goodsNo, string SectionCode)
        {
            // ���i���[�J�[�R�[�h�{���i�ԍ�
            string key = goodsMakerCd.ToString("000000") + goodsNo + SectionCode;

            return key;
        }

        /// <summary>
        /// Key�쐬����
        /// </summary>
        /// <param name="rateSearchResult">�|���}�X�^��������</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Key���쐬���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private string MakeRateKey(Rate rateSearchResult)
        {
            // ���_�R�[�h�{�P���|���ݒ�敪�{���i���[�J�[�R�[�h+���i�ԍ�+���Ӑ�|���O���[�v�R�[�h
            string key = rateSearchResult.SectionCode +
                         rateSearchResult.UnitRateSetDivCd +
                         rateSearchResult.GoodsMakerCd +
                         rateSearchResult.GoodsNo +
                         rateSearchResult.CustRateGrpCode;


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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/07</br>
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/07</br>
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
                                         this._saleRateUpdateAcs,	        // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void PMKHN09431UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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

                        // �I������
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        Save();

                        // �N���A����
                        ClearScreen();
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
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                    // �ݒ�l��ۑ�
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                    // �t�H�[�J�X�ݒ�
                    this.tNedit_GoodsMakerCd.Focus();
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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
                    this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                    this.tEdit_MakerName.DataText = GetMakerName(makerUMnt.GoodsMakerCd);
                    // �ݒ�l��ۑ�
                    this._tmpGoodsMakerCd = makerUMnt.GoodsMakerCd;
                    // �t�H�[�J�X�ݒ�
                    this.tNedit_BLGoodsCode.Focus();
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
        /// <br>Note        : �a�k�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt bLGoodsCdUMnt;

                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
                if (status == 0)
                {
                    this.tNedit_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                    this.tEdit_BLGoodsName.DataText = GetBLGoodsName(bLGoodsCdUMnt.BLGoodsCode);
                    // �ݒ�l��ۑ�
                    this._tmpBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                    // �t�H�[�J�X�ݒ�
                    this.tNedit_CustRateGrpCode1.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // �ҏW�ł���͔̂����̂�
            if (cell.IsInEditMode)
            {
                if (!KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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
                            this.Replace_Button.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                if ((rowIndex == 0) && (colIndex == COLINDEX_SALERATE_ST))
                                {
                                    e.Handled = true;
                                }
                                else if (colIndex == COLINDEX_SALERATE_ST)
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                if ((rowIndex == uGrid.Rows.Count - 1) && (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1))
                                {
                                    e.Handled = true;
                                }
                                else if (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1)
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex + 1].Cells[COLINDEX_SALERATE_ST].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();

            // XML�f�[�^�Ǎ�
            LoadStateXmlData();

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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
                this.Form1_Top_Panel5.Size = new Size(295, 23);
                this.uLabel_SaleRate.Size = new Size(295, 23);
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
                            this.Form1_Top_Panel5.Size = new Size(295, 31);
                            this.uLabel_SaleRate.Size = new Size(295, 15);
                            break;
                        }
                    case 8:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 28);
                            this.uLabel_SaleRate.Size = new Size(295, 18);
                            break;
                        }
                    case 9:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 26);
                            this.uLabel_SaleRate.Size = new Size(295, 20);
                            break;
                        }
                    case 10:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 25);
                            this.uLabel_SaleRate.Size = new Size(295, 21);
                            break;
                        }
                    case 11:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 23);
                            this.uLabel_SaleRate.Size = new Size(295, 23);
                            break;
                        }
                    case 12:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 22);
                            this.uLabel_SaleRate.Size = new Size(295, 24);
                            break;
                        }
                    case 14:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 19);
                            this.uLabel_SaleRate.Size = new Size(295, 27);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�|���f����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/07</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        #region ���_�R�[�h
                        // ���͖���
                        if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpSectionCode = string.Empty;
                            this.tEdit_SectionName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim().Equals(this._tmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }

                            break;
                        }
                        else
                        {
                            // ���_�R�[�h�擾
                            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                            if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                            {
                                // ���ʂ���ʂɐݒ�
                                //this.tEdit_SectionCodeAllowZero.DataText = sectionCode;
                                this.tEdit_SectionName.Text = GetSectionName(sectionCode);

                                // �ݒ�l��ۑ�
                                this._tmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tEdit_SectionCodeAllowZero.DataText = _tmpSectionCode;

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                this.Name,											// �A�Z���u��ID
                                                "�w�肳�ꂽ�����ŋ��_�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                                -1,													// �X�e�[�^�X�l
                                                MessageBoxButtons.OK);								// �\������{�^��
                                // �� 2009.07.01 liuyang add
                                e.NextCtrl = e.PrevCtrl;
                                // �� 2009.07.01 liuyang 

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                        }
                        break;

                        #endregion
                    }
                // ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    {
                        #region ���[�J�[�R�[�h

                        // ���͖���
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpGoodsMakerCd = 0;
                            this.tEdit_MakerName.Text = string.Empty;

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (string.IsNullOrEmpty(tNedit_GoodsMakerCd.Text.Trim()))
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._tmpGoodsMakerCd)
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }

                            break;
                        }
                        else
                        {
                            int makerCd = this.tNedit_GoodsMakerCd.GetInt();
                            if (!string.IsNullOrEmpty(GetMakerName(makerCd)))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tNedit_GoodsMakerCd.SetInt(makerCd);
                                this.tEdit_MakerName.Text = GetMakerName(makerCd);

                                // �ݒ�l��ۑ�
                                this._tmpGoodsMakerCd = makerCd;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_GoodsMakerCd.SetInt(this._tmpGoodsMakerCd);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                this.Name,											// �A�Z���u��ID
                                                "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                                -1,													// �X�e�[�^�X�l
                                                MessageBoxButtons.OK);								// �\������{�^��
                                // �� 2009.07.01 liuyang add
                                e.NextCtrl = e.PrevCtrl;
                                // �� 2009.07.01 liuyang 
                                
                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }
                        }

                        break;

                        #endregion
                    }
                // �a�k�R�[�h
                case "tNedit_BLGoodsCode":
                    {

                        #region �a�k�R�[�h

                        // ���͖���
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpBLGoodsCode = 0;
                            this.tEdit_BLGoodsName.Text = string.Empty;

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    if (string.IsNullOrEmpty(tNedit_BLGoodsCode.Text.Trim()))
                                    {
                                        e.NextCtrl = this.BLGoodsGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                            }

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_BLGoodsCode.GetInt() == this._tmpBLGoodsCode)
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                            }

                            break;
                        }
                        else
                        {
                            int bLGoodsCd = this.tNedit_BLGoodsCode.GetInt();
                            if (!string.IsNullOrEmpty(GetBLGoodsName(bLGoodsCd)))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tNedit_BLGoodsCode.SetInt(bLGoodsCd);
                                this.tEdit_BLGoodsName.Text = GetBLGoodsName(bLGoodsCd);

                                // �ݒ�l��ۑ�
                                this._tmpBLGoodsCode = bLGoodsCd;
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_BLGoodsCode.SetInt(this._tmpBLGoodsCode);

                                // �Y���Ȃ�
                                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                this.Name,											// �A�Z���u��ID
                                                "�w�肳�ꂽ�����ła�k�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                                -1,													// �X�e�[�^�X�l
                                                MessageBoxButtons.OK);								// �\������{�^��

                                // �� 2009.07.01 liuyang add
                                e.NextCtrl = e.PrevCtrl;
                                // �� 2009.07.01 liuyang 

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                    e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // �t�H�[�J�X�ړ�
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                            }
                        }

                        break;

                        #endregion
                    }
                // ���Ӑ�|���f�R�[�h1
                case "tNedit_CustRateGrpCode1":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // �t�H�[�J�X�ړ�
                                if (this.tNedit_BLGoodsCode.Text.Trim() != "")
                                {
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                }
                            }
                        }
                        break;
                    }

                // �O���b�h
                case "uGrid_Details":
                    {
                        #region �O���b�h

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
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[6].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox.Expanded == true)
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            e.NextCtrl = tNedit_CustRateGrpCode1;
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
                                        this.uGrid_Details.Rows[0].Cells[6].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex < 5)
                                {
                                    // �Ƀt�H�[�J�X
                                    this.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Count - 1)
                                {
                                    if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        // �t�H�[�J�X�ړ��Ȃ�
                                        //this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        this.tEdit_SectionCodeAllowZero.Focus();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        e.NextCtrl = null;
                                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else
                                    {
                                        // 1�s���̎d�����Ƀt�H�[�J�X
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
                            if (e.Key == Keys.Tab)
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
                                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                                    colIndex = 7;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            // ���Ӑ�|���f
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                        }
                                        else if (Standard_UGroupBox.Expanded == true)
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
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
                                        e.NextCtrl = this.Replace_Button;
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex <= 6)
                                {
                                    if (rowIndex == 0)
                                    {
                                        e.NextCtrl = this.Replace_Button;
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[rowIndex - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Count - 1].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        break;

                        #endregion

                    }
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
                        #region �O���b�h

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[0].Cells[6].Activate();
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
                                    }
                                    else
                                    {
                                        // ���Ӑ�|���f
                                        e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[6].Activate();
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
                                    if (this.Replace_Button.Enabled == false)
                                    {
                                        if ((Standard_UGroupBox.Expanded == false) &&
                                            (Standard_UGroupBox2.Expanded == false))
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            // ���Ӑ�|���f
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                        }
                                        else
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;

                        #endregion
                    }
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
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
                this.uGrid_Details.ActiveCell.Value = 0;
            }
        }

        /// <summary>
        /// BeforeCellDeactivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                dr = this.uGrid_Details.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// �e�f�[�^�̏�Ԃɉ������w�i�F��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>�X�V�s�F��</br>
        /// <br>�݌ɓo�^����Ă��鏤�i�F�s���N</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                + dr.Cells[COLUMN_NO].Value.ToString() + "'")[0];

            for (int j = 6; j < dr.Cells.Count; j++)
            {
                double newdata = 0.0;
                if (!(dr.Cells[j].Value is System.DBNull))
                {
                    newdata = (double)dr.Cells[j].Value;
                }
                double olddata = (double)originalDr[j];

                if (newdata != olddata)
                {
                    dr.Cells[j].Appearance.BackColor = Color.Red;
                    dr.Cells[j].Appearance.BackColor2 = Color.Red;
                    dr.Cells[j].Appearance.BackColorDisabled = Color.Red;
                    dr.Cells[j].Appearance.BackColorDisabled2 = Color.Red;
                }
                else
                {
                    dr.Cells[j].Appearance.BackColor = Color.Empty;
                    dr.Cells[j].Appearance.BackColor2 = Color.Empty;
                    dr.Cells[j].Appearance.BackColorDisabled = Color.Empty;
                    dr.Cells[j].Appearance.BackColorDisabled2 = Color.Empty;
                }
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �\���ؑփ{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void Replace_Button_Click(object sender, EventArgs e)
        {
            // ���ׂĂ̗�̕\����\���ݒ�
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];

            if (editBand == null) return;

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                if (col.Key == COLUMN_USERPRICEFL)
                {
                    if (col.Hidden == false)
                    {
                        col.Hidden = true;
                    }
                    else
                    {
                        col.Hidden = false;
                    }
                }
                if (col.Key == COLUMN_PRICEFL)
                {
                    if (col.Hidden == false)
                    {
                        col.Hidden = true;
                    }
                    else
                    {
                        col.Hidden = false;
                    }
                }
            }
        }

        /// <summary>
        /// ExpandedStateChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �W�J�X�e�[�^�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 25;

            if ((this.Standard_UGroupBox.Expanded == true) || (this.Standard_UGroupBox2.Expanded == true))
            {
                topSize.Height = 150;
            }
            else
            {
                topSize.Height = 25;
            }

            this.Form1_Top_Panel.Size = topSize;

        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �\���ؑփ{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void panel_Detail_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();

            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                dr = this.uGrid_Details.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        #endregion �� Control Events
    }
}