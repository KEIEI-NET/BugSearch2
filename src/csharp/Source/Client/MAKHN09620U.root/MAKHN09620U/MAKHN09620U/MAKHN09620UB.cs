//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �Z�b�g�}�X�^
// �v���O�����T�v   : �Z�b�g�}�X�^�̓o�^�E�X�V�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2008.08.01  �C�����e : Partsman�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2009/02/06  �C�����e : �e�푬�x�A�b�v�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/09  �C�����e : �폜���i�̏��i�����\���ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2009/09/16  �C�����e : �yMANTIS:14244�z�A���ōs�폜����ƃG���[������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/08/04  �C�����e : �N�����x�A�b�v�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2010/12/03  �C�����e : �P�D���׍s��S�č폜��ɁA�w�b�_���̍폜�{�^������������ƃG���[����������s��̏C��
//                                  �Q�D�����s�̖��ׂ�����Z�b�g�i�̖��ׂ̈ꕔ���s�폜���A�w�b�_���̍폜�{�^�������s�����ꍇ�̍폜�����̕s�� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175121-00 �쐬�S�� : gaocheng
// �C �� ��  2015/05/08  �C�����e : �E�B���h�E���L�����ۂɃZ�b�g�}�X�^�̉�ʂ����l�ɍL���炸�̏C��
//                                : �c�[���o�[�ŃV���[�g�J�b�g�L�[�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175121-00 �쐬�S�� : gaocheng
// �C �� ��  2015/07/02  �C�����e : �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170188-00 �쐬�S�� : ���V��
// �� �� ��  2015/10/28  �C�����e : Redmine#47547 �Z�b�g�q�i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11401643-00 �쐬�S�� : 杍^
// �� �� ��  K2019/01/07 �C�����e : Redmine#49802 �����e���l�ɂăZ�b�g�}�X�^�̍ő�o�^������99���ɑ��₷�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
using System.IO;
using Broadleaf.Application.Resources;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Z�b�g���i�����̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Note       : �Z�b�g���i���̓��͂��s�Ȃ��R���g���[���N���X�ł��B                   </br>
    /// <br>Programmer : 30005 �،��@��                                                         </br>
    /// <br>Date       : 2007.05.10                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpDateNote : �Z�b�g���i���̕K�{���̓`�F�b�N��ǉ�                                 </br>
    /// <br>Programmer : 30005 �،��@��                                                         </br>
    /// <br>Date       : 2007.07.10                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : ���̓R���|�[�l���g���ҏW�s�̂Ƃ��̕����̐F��ύX                     </br>
    /// <br>Programmer : 30005 �،��@��                                                         </br>
    /// <br>Date       : 2007.07.10                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : DC.NS�p�ɕύX����(�ύX�_���������邽�ߕύX�R�����g�͎c���܂���)        </br>
    /// <br>Programmer : 20081 �D�c�@�E�l                                                       </br>
    /// <br>Date       : 2007.09.26                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : PM.NS�Ή�                                                              </br>
    /// <br>Programmer : 30413 ����                                                             </br>
    /// <br>Date       : 2008.08.01                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.02.06 20056 ���n ���</br>
    /// <br>           : �@�e�푬�x�A�b�v�Ή�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2010/08/04 22018 ��� ���b</br>
    /// <br>           : �N�����x�A�b�v�Ή�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/05/08 gaocheng</br>
    /// <br>           : �E�B���h�E���L�����ۂɃZ�b�g�}�X�^�̉�ʂ����l�ɍL���炸�̏C��</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>UpdateNote : 2015/07/02 gaocheng</br>
    /// <br>           : �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>UpdateNote : Redmine#47547 �Z�b�g�q�i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή�        </br>
    /// <br>Programmer : ���V��                                                                 </br>
    /// <br>Date       : 2015/10/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : Redmine#49802 �����e���l�ɂăZ�b�g�}�X�^�̍ő�o�^������99���ɑ��₷�̑Ή� </br>
    /// <br>Programmer : 杍^�@                                                                 </br>
    /// <br>Date       : K2019/01/07                                                            </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    public partial class MAKHN09620UB : UserControl
    {
        #region ��Constractor
        /// <summary>
        /// �Z�b�g���i�����̓R���g���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g���i���̓��͂��s�Ȃ��R���g���[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30005 �،��@��</br>
        /// <br>Date       : 2007.05.10</br>
        /// <br>UpdateNote : 2010/12/03  ���N�n��</br>
        /// <br>�C�����e   : �P�D���׍s��S�č폜��ɁA�w�b�_���̍폜�{�^������������ƃG���[����������s��̏C��</br>
        /// <br>             �Q�D�����s�̖��ׂ�����Z�b�g�i�̖��ׂ̈ꕔ���s�폜���A�w�b�_���̍폜�{�^�������s�����ꍇ�̍폜�����̕s��</br>
        /// <br>UpdateNote : K2019/01/07 杍^</br>
        /// <br>�C�����e   : �����e����pOP�̃I�v�V�����R�[�h���̎擾</br>
        /// </remarks>
        // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //public MAKHN09620UB()
        public MAKHN09620UB(GoodsSetAcs inputGoodsSetAcs)
        // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            InitializeComponent();

            // 2008.08.06 30413 ���� �v���p�e�B�ǉ� >>>>>>START
            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
            // 2008.08.06 30413 ���� �v���p�e�B�ǉ� <<<<<<END

            _goodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();

            // 2008.08.12 30413 ���� �v���p�e�B�ǉ� >>>>>>START
            _deleteGoodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();
            // 2008.08.12 30413 ���� �v���p�e�B�ǉ� <<<<<<END

            // ---ADD 2010/12/03 ---------------------------------------->>>>>
            _deleteGoodsDetailDataTable.PrimaryKey = null;
            // ---ADD 2010/12/03 ----------------------------------------<<<<<

            // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� >>>>>>START
            _lcGoodsUnitDataList = new List<GoodsUnitData>();
            // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� <<<<<<END
        
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���i�Z�b�g�}�X�^�A�N�Z�X�N���X�C���X�^���X��
            //_goodsSetAcs = new GoodsSetAcs();
            // ���i�Z�b�g�}�X�^�A�N�Z�X�N���X�C���X�^���X��
            _goodsSetAcs = inputGoodsSetAcs;
            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
            this._userSetting = new SetMstUserConst();

            this.Deserialize();

            // ���׃O���b�h
            this.LoadGridColumnsSetting(this.uGrid_Details, this._detailColumnsList);
            //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<

            //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ---->>>>>
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_RuntelCustom) > 0)
            {
                this.HaveRuntel = true;
            }
            else
            {
                this.HaveRuntel = false;
            }
            //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ----<<<<<
        }

        #endregion

        #region ��Private Members

        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _goodsDetailDataTable;
        private Image _guideButtonImage;
        private ImageList _imageList16;

        // �����\���s��
        private int _defaultRowCnt = 10;

        // 2008.08.07 30413 ���� �v���p�e�B�ǉ� >>>>>>START
        // �폜�e�[�u��
        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _deleteGoodsDetailDataTable;
        // �ő�s��
        private const int _maxRowNum = 50;
        // 2008.08.07 30413 ���� �v���p�e�B�ǉ� <<<<<<END
        private const int MaxRowNumForRuntel = 99; // ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή�
        // ��ƃR�[�h
        private string _enterpriseCode;

        // ���͒l�ێ�
        private int _beforeMakerCode = 0;
        private string _beforeGoodsCode = "";

        // �ύX�t���O
        private bool _changeFlg;

        // 2008.08.06 30413 ���� �v���p�e�B�ǉ� >>>>>>START
        // ���O�C���]�ƈ�
        private Employee _loginEmployee = null;
        // 2008.08.06 30413 ���� �v���p�e�B�ǉ� <<<<<<END

        // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� >>>>>>START
        /// <summary>���i�A�����[�J���L���b�V���p�f�[�^���X�g�N���X</summary>
        private List<GoodsUnitData> _lcGoodsUnitDataList;
        // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� <<<<<<END
        
        // �Z�b�g���i�̕i�ԍX�V�敪
        private bool _setGoodNoUpdFlg = true;

        // ���i�Z�b�g�A�N�Z�X�N���X
        private GoodsSetAcs _goodsSetAcs;
        
        // 2008.10.15 30413 ���� �e���i�̕i�Ԃƃ��[�J�[���i�[ >>>>>>START
        private string _parentGoodsNo = "";
        private int _parentMakerCode = 0;
        // 2008.10.15 30413 ���� �e���i�̕i�Ԃƃ��[�J�[���i�[ <<<<<<END

        // 2008.10.30 30413 ���� �ύX�O�Z�b�g���i�̕i�Ԃ��i�[ >>>>>>START
        private string _childGoodsNo = "";
        // 2008.10.30 30413 ���� �ύX�O�Z�b�g���i�̕i�Ԃ��i�[ <<<<<<END

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
        // ���[�U�[�ݒ�
        private SetMstUserConst _userSetting;
        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "MAKHN09620UB_Construction.XML";
        //�������t���O
        private bool _initialLoadFlag = false;
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<

        private bool HaveRuntel = false; // ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή�
        #endregion

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
        # region ���v���p�e�B�[
        /// <summary>�Z�b�g�}�X�^���[�U�[�ݒ�</summary>
        public SetMstUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>�������t���O</summary>
        public bool InitialLoadFlag
        {
            get { return this._initialLoadFlag; }
            set { this._initialLoadFlag = value; }
        }
        # endregion
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<

        # region ��Event

        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>�O���b�h�ŉ��w�s�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownButtomRow;
        
        # endregion

        #region ��Public Methods

        /// <summary>
        /// �Z�b�g���i���s�ǉ�����
        /// </summary>
        /// <remarks>
        /// Note			:	�Z�b�g���i���̋�s���f�[�^�e�[�u���ɒǉ����鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        public void AddGoodsDetailRow()
        {
            // No�̔Ԃ̂��߂Ƀf�[�^�e�[�u���̍s�����J�E���g����
            int rowCount = this._goodsDetailDataTable.Rows.Count;

            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            row.No = (short)(rowCount + 1);
            this._goodsDetailDataTable.AddGoodsSetDetailRow(row);
        }

        /// <summary>
        /// �f�[�^�e�[�u���O���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// Note			:	�\������f�[�^�s���O���b�h�Ƀo�C���h���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.10<br />
        /// </remarks>
        public void SetGoodsSetGrid()
        {
            // �O���b�h�ɕ\������f�[�^�e�[�u����ݒ�
            uGrid_Details.DataSource = _goodsDetailDataTable;

            // �O���b�h�����ݒ�
            this.InitialSettingGridCol();
            // �{�^���̏����ݒ�
            ButtonInitialSetting();
            // �O���b�h�L�[�}�b�s���O�ݒ菈��
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// �f�[�^�s�f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="No">�\��No</param>
        /// <param name="dataRow">�I�����ꂽ�f�[�^�s</param>
        /// <remarks>
        /// Note			:	�\������f�[�^�s���O���b�h�Ƀo�C���h���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.10<br />
        /// </remarks>
        public void SetGoodsSetDataTable(int No, DataRow dataRow)
        {
            this._goodsDetailDataTable.BeginLoadData();

            // �\���s
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // ��̓��͍s�ȏ�f�[�^�����݂���ꍇ�͐V�K�s������ăf�[�^���i�[
            if (No > _defaultRowCnt)
            {
                detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            }
            // ��̓��͍s�ȉ��̏ꍇ�͑��݂���s���ƕϐ�No����v����s���X�V����
            else
            {
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find((short)No);
            }

            // �K�v�ȍ��ڂ����O���b�h�\���f�[�^�e�[�u���ɃZ�b�g
            detailRow.No = (short)No;                                                  // No
            if (dataRow[GoodsSetAcs.DISPLAYORDER_TITLE].ToString() != string.Empty)
            {
                detailRow.Disply = (int)dataRow[GoodsSetAcs.DISPLAYORDER_TITLE];       // �\������
            }

            //detailRow.MakerCode = (int)dataRow[GoodsSetAcs.SUBGOODSMAKERCD_TITLE];     // ���[�J�[�R�[�h
            int workMakerCode = (int)dataRow[GoodsSetAcs.SUBGOODSMAKERCD_TITLE];
            detailRow.MakerCode = workMakerCode.ToString("d04");     // ���[�J�[�R�[�h
            detailRow.MakerName = (string)dataRow[GoodsSetAcs.SUBGOODSMAKERNM_TITLE];  // ���[�J�[����
            detailRow.GoodsCode = (string)dataRow[GoodsSetAcs.SUBGOODSNO_TITLE];       // �i��
            detailRow.GoodsName = (string)dataRow[GoodsSetAcs.SUBGOODSNAME_TITLE];     // �i��

            if (dataRow[GoodsSetAcs.CNTFL_TITLE].ToString() != string.Empty)
            {
                //detailRow.CntFl = (double)dataRow[GoodsSetAcs.CNTFL_TITLE];            // �p�s�x(����)
                detailRow.CntFl = (string)dataRow[GoodsSetAcs.CNTFL_TITLE];            // �p�s�x(����)
            }

            detailRow.SetNote   = dataRow[GoodsSetAcs.SETSPECIALNOTE_TITLE].ToString();   // �Z�b�g�K�i�E���L����
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 >>>>>>START
            //detailRow.CatalogShape = dataRow[GoodsSetAcs.CATALOGSHAPENO_TITLE].ToString();// �J�^���O�}��
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 <<<<<<END
            
            // �V�K�s�̂Ƃ��̂ݐV�����s��ǉ����邽��Add�������K�v
            if (No > _defaultRowCnt)
            {
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// �f�[�^�e�[�u���N���A����
        /// </summary>
        /// <remarks>
        /// Note			:	�f�[�^�e�[�u�����N���A���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void ClearGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Clear();
            // 2008.08.20 30413 ���� �폜�f�[�^�e�[�u����ǉ� >>>>>>START
            this._deleteGoodsDetailDataTable.Clear();
            // 2008.08.20 30413 ���� �폜�f�[�^�e�[�u����ǉ� <<<<<<END

            // 2008.08.22 30413 ���� ���[�J���L���b�V�����N���A >>>>>>START
            this._lcGoodsUnitDataList.Clear();
            // 2008.08.22 30413 ���� ���[�J���L���b�V�����N���A <<<<<<END

            // 2008.10.15 30413 ���� �e�����N���A >>>>>>START
            this._parentGoodsNo = "";
            this._parentMakerCode = 0;
            // 2008.10.15 30413 ���� �e�����N���A <<<<<<END            
        }

        /// <summary>
        /// �f�[�^�e�[�u�����Z�b�g����
        /// </summary>
        /// <remarks>
        /// Note			:	�f�[�^�e�[�u�������Z�b�g���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void ResetGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Reset();
            // 2008.08.20 30413 ���� �폜�f�[�^�e�[�u����ǉ� >>>>>>START
            this._deleteGoodsDetailDataTable.Reset();
            // 2008.08.20 30413 ���� �폜�f�[�^�e�[�u����ǉ� <<<<<<END
        }

        /// <summary>
        /// �O���b�h���͋����䏈��
        /// </summary>
        /// <remarks>
        /// Note			:	�O���b�h�̓��͋������ݒ肵�܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void GridInputPermissionControl(bool enabled)
        {
            this.uGrid_Details.Enabled = enabled;
        }

        /// <summary>
        /// �O���b�h�{�^�������䏈��
        /// </summary>
        /// <remarks>
        /// Note			:	�O���b�h�̃{�^���̋������ݒ肵�܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void GridButtonPermissionControl(bool enabled)
        {
            this.uButton_RowDelete.Enabled = enabled;
            this.uButton_RowInsert.Enabled = enabled;
        }

        /// <summary>
        /// �O���b�h�����̓`�F�b�N
        /// </summary>
        /// <return>RESULT</return>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// <br>Note		: �O���b�h���̃f�[�^�����������͂���Ă��邩�`�F�b�N���s���܂��B</br>
        /// <br>Programmer	: 30005 �،��@��</br>
        /// <br>Date		: 2007.05.14</br>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// Note			: �K�{���̓`�F�b�N��ǉ�<br />
        /// Programmer		: 30005 �،��@��<br />
        /// Date			: 2007.07.10<br />
        /// <br>--------------------------------------------------------------------------------------</br>
        /// <br>UpdateNote  : K2019/01/07 杍^</br>
        /// <br>�C�����e    : �����e���l�ɂăZ�b�g�}�X�^�̍ő�o�^������99���ɑ��₷�̑Ή�</br>
        /// </remarks>
        public bool GridDataCheck(ref Control control, ref string message)
        {
            bool result;
            int errorRowNo;
            string errorColNm;

            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
            int errorDispNo;
            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END            

            // 2009.03.26 30413 ���� �Z�b�g���i�̏��i�}�X�^�폜�`�F�b�N >>>>>>START
            #region ���폜�`�F�b�N
            this.CheckDeleteData(out errorRowNo);
            if (errorRowNo != 0)
            {
                message = "�Z�b�g���i���� [ " + errorRowNo + " ] �s�ڂ����i�}�X�^����폜����Ă��܂��B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            // 2009.03.26 30413 ���� �Z�b�g���i�̏��i�}�X�^�폜�`�F�b�N <<<<<<END
            
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();
            
            #region ���L���f�[�^�`�F�b�N
            
            #region < �L���f�[�^�����擾 >
            this.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);
            #endregion

            #region < �K�{���̓`�F�b�N >
            if (errorColNm != "")
            {
                message = "�Z�b�g���i���� [ " + errorRowNo + " ] �s�ڂ�" + errorColNm + "����͂��Ă��������B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }

            // 2007.07.10 add by T-Kidate
            if (effectDataList.Count == 0)
            {
                message = "�Z�b�g���i������͂��Ă��������B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #region < �����f�[�^�����`�F�b�N>
            if (errorRowNo != 0)
            {
                message = "�Z�b�g���i���� [ " + errorRowNo + " ] �s�ڂ𐳂������͂��Ă��������B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #endregion

            // 2008.10.15 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
            #region ���e���i�Ɠ��ꏤ�i�`�F�b�N
            this.CheckParentOverlapData(out errorRowNo, effectDataList);

            #region -- �e���i�Ɠ��ꏤ�i�L�� --
            if (errorRowNo != 0)
            {
                message = "�Z�b�g���i���� [ " + errorRowNo + " ] �s�ڂ��e���i�Ɠ���ł�";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            #endregion
            // 2008.10.15 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END
            
            #region ���d���`�F�b�N
            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
            //this.CheckOverlapData(out errorRowNo, effectDataList);
            this.CheckOverlapData(out errorRowNo, out errorDispNo, effectDataList);
            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END            

            #region -- �d���L�� --
            if (errorRowNo != 0)
            {
                message = "�Z�b�g���i���� [ " + errorRowNo + " ] �s�ڂ��d�����Ă��܂�";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
            if (errorDispNo != 0)
            {
                //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ---->>>>>
                if(this.HaveRuntel)
                {
                    message = "�Z�b�g���i���� [ " + errorDispNo + " ] �s�ڂ̕\�����ʂ��d��\n�܂��͓��͔͈�(1�`99)����O��Ă��܂�";
                }
                else
                {
                 //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ---->>>>>
                    message = "�Z�b�g���i���� [ " + errorDispNo + " ] �s�ڂ̕\�����ʂ��d��\n�܂��͓��͔͈�(1�`50)����O��Ă��܂�";
                }// ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή�
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END            

            #endregion

            result = true;
            return result;
        }

        /// <summary>
        /// ���i�}�X�^�폜�f�[�^�`�F�b�N
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <remarks>
        /// </remarks>
        public void CheckDeleteData(out int errorRowNo)
        {
            // �G���[���s�ԍ�(0 ������I��)
            errorRowNo = 0;
            
            // �f�[�^�e�[�u���̑��������J�E���g���A���̒��Ńf�[�^�����͂���Ă���s�̂݃`�F�b�N���s��
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                if (row.EditFlg)
                {
                    // �i�����󔒂̃f�[�^�͖���
                    if (row.MakerCode != "" && row.GoodsCode != "")
                    {
                        if (row.GoodsName.Trim() == "")
                        {
                            // �����f�[�^�s�̍s�ԍ�
                            errorRowNo = (int)row.No;
                            return;
                        }                        
                    }
                }
                // ADD 2009/04/09 ------>>>
                else if (row.MakerCode == "" && row.GoodsCode == "")
                {
                    // ��f�[�^�Ȃ̂ŉ������Ȃ�
                }
                // �����f�[�^
                else
                {
                    if (row.GoodsName.Trim() == "")
                    {
                        // �����f�[�^�s�̍s�ԍ�
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
                // ADD 2009/04/09 ------<<<
            }
        }

        /// <summary>
        /// �L���f�[�^�e�[�u���s�擾����
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <param name="errorColNm">�G���[��</param>
        /// <param name="effectDataList">�L���f�[�^�s���X�g</param>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// Note			:	�f�[�^�e�[�u���̒�����L���ȃf�[�^�s�̃��X�g���擾���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// <br>--------------------------------------------------------------------------------------</br>
          /// </remarks>
        public void GetEffectiveData(out int errorRowNo, out string errorColNm, out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            // �G���[���s�ԍ�(0 ������I��)
            errorRowNo = 0;
            errorColNm = "";
            effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // �f�[�^�e�[�u���̑��������J�E���g���A���̒��Ńf�[�^�����͂���Ă���s�̂݃`�F�b�N���s��
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt ; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                // 2008.08.12 30413 ���� �o�^�ς݂̒񋟃f�[�^�͑ΏۊO >>>>>>START
                //// �S�J���������͂���Ă���(���L���f�[�^)
                //if (row.MakerCode != 0 && row.GoodsCode != "")
                //{
                //    effectDataList.Add(row);
                //}
                //// �S�J���������͂���Ă��Ȃ��B(���L���f�[�^)
                //else if (row.MakerCode == 0 && row.GoodsCode == "")
                //{
                //    // ��f�[�^�Ȃ̂ŉ������Ȃ�
                //}
                //// �����f�[�^
                //else
                //{
                //    // �����f�[�^�s�̍s�ԍ�
                //    errorRowNo = (int)row.No;
                //    return;
                //}
                if (row.EditFlg)
                {
                    // �S�J���������͂���Ă���(���L���f�[�^)
                    //if (row.MakerCode != 0 && row.GoodsCode != "")
                    if (row.MakerCode != "" && row.GoodsCode != "")
                    {
                        // 2009.02.06 30413 ���� QTY�̓��̓`�F�b�N��ǉ� >>>>>>START
                        double cntFl = 0.0;
                        if ((!double.TryParse(row.CntFl, out cntFl)) || (cntFl == 0.0))
                        {
                            // �����f�[�^�s�̍s�ԍ�
                            errorRowNo = (int)row.No;
                            errorColNm = this._goodsDetailDataTable.CntFlColumn.Caption;
                            return;
                        }
                        // 2009.02.06 30413 ���� QTY�̓��̓`�F�b�N��ǉ� <<<<<<END
                        
                        effectDataList.Add(row);
                    }
                    // �S�J���������͂���Ă��Ȃ��B(���L���f�[�^)
                    //else if (row.MakerCode == 0 && row.GoodsCode == "")
                    else if (row.MakerCode == "" && row.GoodsCode == "")
                    {
                        // ��f�[�^�Ȃ̂ŉ������Ȃ�
                    }
                    // �����f�[�^
                    else
                    {
                        // �����f�[�^�s�̍s�ԍ�
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
                // 2008.08.12 30413 ���� �o�^�ς݂̒񋟃f�[�^�͑ΏۊO <<<<<<END                
            }
        }

        /// <summary>
        /// �f�[�^�e�[�u���s�d���`�F�b�N����
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <param name="errorDispNo">�\�����ʃG���[�s�ԍ�</param>
        /// <param name="effectDataList">�L���f�[�^�s���X�g</param>
        /// <remarks>
        /// Note			:	�f�[�^�e�[�u���̃f�[�^�s�d���`�F�b�N�������s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.18<br />
        /// <br>UpdateNote  : K2019/01/07 杍^</br>
        /// <br>�C�����e    : �����e���l�ɂăZ�b�g�}�X�^�̍ő�o�^������99���ɑ��₷�̑Ή�</br>
        /// </remarks>
        public void CheckOverlapData(out int errorRowNo, out int errorDispNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;
            
            // �L���f�[�^�S�����擾
            effectRowCnt = effectDataList.Count;

            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
            errorRowNo = 0;
            errorDispNo = 0;
            // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END

            #region < ��r�Ώۍs��ݒ肵�S����r >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();
                // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
                List<int> equalDispNoList = new List<int>();

                //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ---->>>>>
                //if ((targetRow.Disply < 1) || (targetRow.Disply > 50))
                if ((targetRow.Disply < 1) || 
                    (!this.HaveRuntel && targetRow.Disply > 50) ||
                    (this.HaveRuntel && targetRow.Disply > MaxRowNumForRuntel))
                //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ----<<<<<
                {
                    // �\�����ʂ͈̔͂��s��
                    equalDispNoList.Add((int)targetRow.No);
                }
                // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END

                #region -- ��r�Ώۂ����ɍs���X�g��S����r --
                for (int j = 0; j < effectRowCnt; j++)
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow compareRow = effectDataList[j];

                    #region - �i�Ԕ�r -
                    if (targetRow.GoodsCode == compareRow.GoodsCode)
                    {
                        equalRowNoList.Add((int)compareRow.No);
                    }
                    #endregion

                    // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
                    #region - �\�����ʔ�r -
                    if (targetRow.Disply == compareRow.Disply)
                    {
                        equalDispNoList.Add((int)compareRow.No);
                    }
                    #endregion
                    // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END

                }
                #endregion

                #region -- �d��No�`�F�b�N --
                if (equalRowNoList.Count > 1)
                {
                    // �d�����������Ō�̍s�ԍ����擾���Ĉ����Ɋi�[
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return ;
                }
                #endregion

                // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N >>>>>>START
                #region -- �d���\�����ʃ`�F�b�N --
                if (equalDispNoList.Count > 1)
                {
                    // �d�����������Ō�̍s�ԍ����擾���Ĉ����Ɋi�[
                    errorDispNo = equalDispNoList[equalDispNoList.Count - 1];
                    return;
                }
                #endregion
                // 2008.08.11 30413 ���� �\�����ʂ̏d���`�F�b�N <<<<<<END
            
            }
            #endregion

            // �d�������݂��Ȃ������̂ŃG���[�ԍ��͂O
            errorRowNo = 0;
        }

        /// <summary>
        /// �e���i�Ƃ̓���i�`�F�b�N����
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <param name="effectDataList">�L���f�[�^�s���X�g</param>
        /// <remarks>
        /// Note			:	�e���i�Ƃ̓���i�`�F�b�N�������s���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.15<br />
        /// </remarks>
        public void CheckParentOverlapData(out int errorRowNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;

            // �L���f�[�^�S�����擾
            effectRowCnt = effectDataList.Count;

            errorRowNo = 0;
            
            #region < ��r�Ώۍs��ݒ肵�S����r >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();

                #region - �e���i�̕i�ԁA���[�J�[�Ɠ����r -
                if ((targetRow.GoodsCode == this._parentGoodsNo) &&
                    (int.Parse(targetRow.MakerCode) == this._parentMakerCode))
                {
                    equalRowNoList.Add((int)targetRow.No);
                }
                #endregion

                #region -- �e���i����No�`�F�b�N --
                if (equalRowNoList.Count > 0)
                {
                    // �e���i�̕i�ԁA���[�J�[�Ɠ���̃Z�b�g���i�̍s�ԍ����擾���Ĉ����Ɋi�[
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return;
                }
                #endregion
            }
            #endregion

            // �d�������݂��Ȃ������̂ŃG���[�ԍ��͂O
            errorRowNo = 0;
        }

        /// <summary>
        /// �O���b�h���ύX�m�F����
        /// </summary>
        /// <return>�ύX�t���O(ON:�ύX�L  OFF:�ύX��)</return>
        /// <remarks>
        /// Note			:	�O���b�h�����ҏW���ꂽ�����`�F�b�N���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public bool CheckGridChange()
        {
            return _changeFlg;
        }

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// Note			:	����������@���擾���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }

        #region Return�L�[�_�E������ �C���O
        ///// <summary>
        ///// Return�L�[�_�E������
        ///// </summary>
        ///// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        //internal bool ReturnKeyDown()
        //{
        //    if (this.uGrid_Details.ActiveCell == null) return false;
        //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
        //    int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;

        //    //bool canMove;
        //    //canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

        //    bool canMove = true;

        //    // 2008.08.22 30413 ���� �\�����ʂ�ǉ� >>>>>>START
        //    #region ��ActiveCell���\������
        //    if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
        //    {
        //        if (!this._goodsDetailDataTable[cell.Row.Index].EditFlg)
        //        {
        //            this.MoveNextAllowEditCell(false);
        //        }
        //    }
        //    #endregion

        //    #region ��ActiveCell���i��
        //    //if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //    else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //    // 2008.08.22 30413 ���� �\�����ʂ�ǉ� <<<<<<END
        //    {
        //        // 2008.08.22 30413 ���� �s���ύX�s���̏�����ǉ� >>>>>>START
        //         ActiveCell�̍s���ύX�s�̏ꍇ�͕ҏW�\�ȍs��
        //        if (!this._goodsDetailDataTable[cell.Row.Index].EditFlg)
        //        {
        //            this.MoveNextAllowEditCell(false);
        //        }
        //        // 2008.08.22 30413 ���� �s���ύX�s���̏�����ǉ� <<<<<<END

        //        if (!this._setGoodNoUpdFlg)
        //        {
        //            this._setGoodNoUpdFlg = true;
        //            // �i�Ԏ擾�敪��false�̏ꍇ(�������s���͎��̃Z���֑J�ڂ��Ȃ�)
        //            return this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
        //        }
                
        //        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
        //        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

        //        // ActiveCell���ύX���Ă��Ȃ��ꍇ��NextCell�����s����
        //        if (this.uGrid_Details.ActiveCell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //        {
        //            #region < �i�Ԗ����� >
        //            if (this._goodsDetailDataTable[cell.Row.Index].GoodsCode == "")
        //            {
        //                canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
        //            }
        //            #endregion

        //            #region < �i�ԓ��� >
        //            else
        //            {
        //                string goodsCode = cell.Value.ToString();

        //                if (!String.IsNullOrEmpty(goodsCode))
        //                {
        //                    string searchCode;

        //                    // �����̎�ނ��擾
        //                    int searchType = this.GetSearchType(goodsCode, out searchCode);

        //                    List<GoodsUnitData> goodsUnitDataList;
        //                    string message;

        //                    // 2008.08.06 30413 ���� ���i���������̕ύX >>>>>>START
        //                    #region < ���i�������� > <<<<<<�ύX�O
        //                    //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
        //                    //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
        //                    #endregion

        //                    #region < ���i�������� >
        //                    string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
        //                    GoodsCndtn goodsCndtn = new GoodsCndtn();
        //                    //GoodsAcs goodsAcs = new GoodsAcs();

        //                    // ���i���������ݒ�
        //                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //                    goodsCndtn.SectionCode = sectionCd;
        //                    goodsCndtn.GoodsMakerCd = 0;
        //                    goodsCndtn.MakerName = "";
        //                    goodsCndtn.GoodsNo = goodsCode;
        //                    goodsCndtn.GoodsNoSrchTyp = searchType;

        //                    //int status = goodsAcs.SearchInitial(this._enterpriseCode, sectionCd, out message);
        //                    // 2008.08.26 30413 ���� ���i�A�N�Z�X�N���X�̃��\�b�h�ύX >>>>>>START
        //                    //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out goodsUnitDataList, out message);
        //                    //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //                    int status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //                    // 2008.08.26 30413 ���� ���i�A�N�Z�X�N���X�̃��\�b�h�ύX <<<<<<END
        //                    #endregion
        //                    // 2008.08.06 30413 ���� ���i���������̕ύX <<<<<<END

        //                    #region -- �擾���� --
        //                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //                    {
        //                        // ���i�}�X�^�f�[�^�N���X
        //                        GoodsUnitData goodsUnitData = new GoodsUnitData();
        //                        goodsUnitData = goodsUnitDataList[0];
        //                        // ���i�}�X�^���ݒ菈��
        //                        this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

        //                        // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� >>>>>>START
        //                        // �擾�������i�A���f�[�^���L���b�V���Ƃ��ĕێ�
        //                        if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
        //                        {
        //                            _lcGoodsUnitDataList.Add(goodsUnitData);
        //                        }
        //                        // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� <<<<<<END
        //                    }
        //                    #endregion

        //                    #region -- �擾���s --
        //                    else
        //                    {
        //                        TMsgDisp.Show(
        //                            this,
        //                            emErrorLevel.ERR_LEVEL_INFO,
        //                            this.Name,
        //                            // 2008.08.06 30413 ���� ���i�R�[�h���i�ԂɕύX >>>>>>START
        //                            //"���i�R�[�h [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
        //                            "�i�� [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
        //                            // 2008.08.06 30413 ���� ���i�R�[�h���i�ԂɕύX <<<<<<END
        //                            -1,
        //                            MessageBoxButtons.OK);

        //                        // ���ڃN���A
        //                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // �i��
        //                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // �i��
        //                        //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;       // ���[�J�[�R�[�h
        //                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";       // ���[�J�[�R�[�h
        //                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // ���[�J�[����
        //                    }
        //                    #endregion
        //                }
        //                else
        //                {
        //                    // �i�Ԃ����ɖ߂�
        //                    this._goodsDetailDataTable[cell.Row.Index].GoodsCode = this._beforeGoodsCode;
        //                    // �i���̃N���A
        //                    this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";
        //                    //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;       // ���[�J�[�R�[�h
        //                    this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";       // ���[�J�[�R�[�h
        //                    this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // ���[�J�[����
        //                }
        //            }

        //            #endregion
        //        }
        //    }
        //    #endregion

        //    #region ��ActiveCell���i��
        //    else if (cell.Column.Key == this._goodsDetailDataTable.GoodsNameColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);
        //    }
        //    #endregion

        //    #region ��ActiveCell�����[�J�[����
        //    else if (cell.Column.Key == this._goodsDetailDataTable.MakerNameColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);
        //    }
        //    #endregion

        //    #region ��ActiveCell�����[�J�[�R�[�h
        //    else if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
        //    {
        //        // 2008.08.22 30413 ���� �s���ύX�s���̏�����ǉ� >>>>>>START
        //        this.MoveNextAllowEditCell(false);
        //        // 2008.08.22 30413 ���� �s���ύX�s���̏�����ǉ� <<<<<<END

        //        // 2008.08.22 30413 ���� ���[�J�[�R�[�h�͕ҏW�s�ɕύX >>>>>>START
        //        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
        //        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

        //        //// ActiveCell���ύX���Ă��Ȃ��ꍇ��NextCell�����s����
        //        //if (this.uGrid_Details.ActiveCell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
        //        //{
        //        //    #region < ���[�J�[�R�[�h������ >
        //        //    if (this._goodsDetailDataTable[cell.Row.Index].MakerCode == 0)
        //        //    {
        //        //        //canMove = this.MoveNextAllowEditCell(false);
        //        //        canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
        //        //    }
        //        //    #endregion

        //        //    #region < ���[�J�[�R�[�h���� >
        //        //    else
        //        //    {
        //        //        int searchCode = (int)cell.Value;

        //        //        if (!String.IsNullOrEmpty(searchCode.ToString()))
        //        //        {
        //        //            MakerUMnt makerUMnt;
        //        //            GoodsAcs goodsAcs = new GoodsAcs();
        //        //            string msg;
        //        //            goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

        //        //            // �����i�����̃��[�J�[�}�X�^���擾���\�b�h���Ăяo��
        //        //            int status = goodsAcs.GetMaker(this._enterpriseCode, searchCode, out makerUMnt);

        //        //            #region -- �擾���� --
        //        //            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (makerUMnt != null))
        //        //            {
        //        //                // ���[�J�[�}�X�^���ݒ菈��
        //        //                this.MakerDetailRowGoodsSetSetting(goodsRowNo, makerUMnt);

        //        //                // ���i�R�[�h�����͂����悤�ɐ��䂷��
        //        //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //        //                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //        //                this.uGrid_Details.ActiveCell.SelStart = 0;
        //        //                this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //        //            }
        //        //            #endregion

        //        //            #region -- �擾���s --
        //        //            else
        //        //            {
        //        //                TMsgDisp.Show(
        //        //                    this,
        //        //                    emErrorLevel.ERR_LEVEL_INFO,
        //        //                    this.Name,
        //        //                    "���[�J�[�R�[�h [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
        //        //                    -1,
        //        //                    MessageBoxButtons.OK);

        //        //                // ���[�J�[�R�[�h�̏�����
        //        //                //this._goodsDetailDataTable[cell.Row.Index].MakerCode = this._beforeMakerCode;
        //        //                this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;
        //        //            }
        //        //            #endregion
        //        //        }
        //        //    }
        //        //    #endregion
        //        //}
        //        // 2008.08.22 30413 ���� ���[�J�[�R�[�h�͕ҏW�s�ɕύX <<<<<<END
        //    }
        //    #endregion

        //    // 2008.08.22 30413 ���� �p�s�x�A�Z�b�g�K�i�A�񋟋敪��ǉ� >>>>>>START
        //    #region ��ActiveCell���p�s�x
        //    else if (cell.Column.Key == this._goodsDetailDataTable.CntFlColumn.ColumnName)
        //    {
        //        if (!this._goodsDetailDataTable[cell.Row.Index].EditFlg)
        //        {
        //            this.MoveNextAllowEditCell(false);
        //        }
        //    }
        //    #endregion

        //    #region ��ActiveCell���Z�b�g�K�i�E���L����
        //    else if (cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);                
        //    }
        //    #endregion

        //    #region ��ActiveCell���񋟋敪
        //    else if (cell.Column.Key == this._goodsDetailDataTable.DivisionColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);
        //    }
        //    #endregion
        //    // 2008.08.22 30413 ���� �p�s�x�A�Z�b�g�K�i�A�񋟋敪��ǉ� <<<<<<END
            
        //    #region ��ActiveCell���K�C�h�{�^���̏ꍇ
        //    // 2008.08.04 30413 ���� �K�C�h�{�^���̍폜 >>>>>>START
        //    //else if ((cell.Column.Key == this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName) ||
        //    //        (cell.Column.Key == this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName))
        //    //{
        //    //    // �����͉\�Z���ړ�����
        //    //    canMove = this.MoveNextAllowEditCell(false);
        //    //}
        //    // 2008.08.04 30413 ���� ���i�����K�C�h�{�^���̍폜 <<<<<<END
        //    #endregion

        //    return canMove;
        //}
        #endregion

        #region Return�L�[�_�E������ �C����
        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;

            bool moveFlg = this.MoveNextAllowEditCell(false);
            if (moveFlg)
            {
                return moveFlg;
            }
            else
            {
                return moveFlg;
            }
        }
        #endregion

        #region Return�L�[�_�E������(Shift+TAB�p)
        /// <summary>
        /// Return�L�[�_�E������(Shift+TAB�p)
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown2()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            
            bool canMove = this.MovePrevAllowEditCell(false);

            return canMove;
        }
        #endregion

        #endregion

        #region ��Private Methods

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// Note			:	�O���b�h�̏����ݒ�����܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.10<br />
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// Note			:	���̓R���|�[�l���g���ҏW�s�̂Ƃ��̕����̐F��ύX<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.07.10<br />
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// Note			:	���i�R�[�h�����l�߂ŕ\������悤�ɕύX<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.07.14<br />
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            // �K�C�h�{�^���̃A�C�R��
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            
            // ���̓t�H�[����ʕ\���̂��߃f�[�^�e�[�u��������
            this._goodsDetailDataTable.Clear();

            // 2008.08.04 30413 ���� �\�����ݒ�̕ύX >>>>>>START
            #region ���\�����ݒ� <<<<<<�ύX�O
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Width = 50;                   // No
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Width = 50;               // �\������
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Width = 120;           // ���[�J�[�R�[�h 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].Width = 25;     // ���[�J�[�K�C�h�{�^��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Width = 150;           // ���[�J�[����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Width = 120;           // �i��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].Width = 25;     // ���i�K�C�h�{�^��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Width = 300;           // �i��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Width = 50;                // ����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Width = 50;              // �Z�b�g�K�i�E���L����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].Width = 50;         // �J�^���O�}��
            #endregion

            if (_initialLoadFlag) // ADD gaocheng�@2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�
            {
                #region ���\�����ݒ�
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Width = 50;                   // No
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Width = 50;               // �\������
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Width = 120;           // �i��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Width = 300;           // �i��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Width = 120;           // ���[�J�[�R�[�h 
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Width = 150;           // ���[�J�[����
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Width = 80;                // �p�s�x(����)
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Width = 300;             // �Z�b�g�K�i�E���L����
                // 2009.02.06 30413 ���� �����؂�̂��ߕ\�������C�� >>>>>>START
                //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].Width = 50;             // �񋟋敪
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].Width = 100;            // �񋟋敪
                // 2009.02.06 30413 ���� �����؂�̂��ߕ\�������C�� <<<<<<END
            } // ADD gaocheng�@2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�s
            #endregion
            // 2008.08.04 30413 ���� �\�����ݒ�̕ύX <<<<<<END

            // 2008.08.04 30413 ���� �Z�����̃f�[�^�\���ʒu�ݒ�̕ύX >>>>>>START
            #region ���Z�����̃f�[�^�\���ʒu�ݒ� <<<<<<�ύX�O
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion

            #region ���Z�����̃f�[�^�\���ʒu�ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion
            
            // 2008.08.04 30413 ���� �Z�����̃f�[�^�\���ʒu�ݒ�̕ύX <<<<<<END
            
            #region ���Z�����̓��͍��ڑ啶���������ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            // 2008.12.17 30413 ���� �啶���ݒ��ʏ�ɕύX >>>>>>START
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            // 2008.12.17 30413 ���� �啶���ݒ��ʏ�ɕύX <<<<<<END
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 >>>>>>START
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 <<<<<<END
            #endregion

            #region ���\���J�[�\���ݒ�
            // 2008.08.04 30413 ���� �K�C�h�{�^���̍폜 >>>>>>START
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            // 2008.08.04 30413 ���� �K�C�h�{�^���̍폜 <<<<<<END
            #endregion

            // 2008.08.04 30413 ���� �X�^�C���ݒ�̕ύX >>>>>>START
            #region ���X�^�C���ݒ� <<<<<<�ύX�O
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // �\������
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // ���[�J�[�R�[�h 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;       // ���[�J�[�K�C�h�{�^��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // ���[�J�[����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // ���i�R�[�h
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;       // ���i�K�C�h�{�^��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // ���i����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                    // ����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // �Z�b�g�K�i�E���L����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;             // �J�^���O�}��
            #endregion

            #region ���X�^�C���ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // �\������
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // �i��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // �i��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // ���[�J�[�R�[�h 
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                    // �p�s�x(����)
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // �Z�b�g�K�i�E���L����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                 // �񋟋敪
            #endregion
            // 2008.08.04 30413 ���� �X�^�C���ݒ�̕ύX <<<<<<END
            
            #region ���ʐݒ�
            
            // 2008.08.07 30413 ���� ���[�J�[�K�C�h�{�^���̍폜 >>>>>>START
            #region < ���[�J�[�K�C�h�{�^�� >
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            #endregion
            // 2008.08.07 30413 ���� ���[�J�[�K�C�h�{�^���̍폜 <<<<<<END
            
            // 2008.08.04 30413 ���� ���i�����K�C�h�{�^���̍폜 >>>>>>START
            #region < ���i�K�C�h�{�^�� >
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            #endregion
            // 2008.08.04 30413 ���� ���i�����K�C�h�{�^���̍폜 <<<<<<END
            
            #region < No >
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion
            
            #endregion

            #region �����͐���
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;           // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// �i��
            // 2008.08.04 30413 ���� ���[�J�[�R�[�h�A�񋟋敪�̒ǉ� >>>>>>START
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// ���[�J�[�R�[�h
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// �񋟋敪
            // 2008.08.04 30413 ���� ���[�J�[�R�[�h�A�񋟋敪�̒ǉ� <<<<<<END
            #endregion

            #region ���t�H�[�}�b�g�ݒ�

            string codeFormat = "#0;-#0;''";

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Format = codeFormat;

            #endregion

            // 2008.08.06 30413 ���� �񕝂̉ϐݒ�̒ǉ� >>>>>>START
            #region ���񕝂̉ϐݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.EntireColumn;
            #endregion
            // 2008.08.06 30413 ���� �񕝂̉ϐݒ�̒ǉ� <<<<<<END

            // 2008.08.07 30413 ���� ��̔�\���ݒ�̒ǉ� >>>>>>START
            #region ����̔�\���ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Hidden = true;               // �ҏW��
            // 2008.10.30 30413 ���� �ǉ��t���O >>>>>>START
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.AddFlagColumn.ColumnName].Hidden = true;               // �ǉ��t���O
            // 2008.10.30 30413 ���� �ǉ��t���O <<<<<<END
            #endregion
            // 2008.08.07 30413 ���� ��̔�\���ݒ�̒ǉ� <<<<<<END

            // 2008.08.08 30413 ���� ��̏����ݒ�̒ǉ� >>>>>>START
            #region ����̏����ݒ�
            // ��̈ړ�������
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup;
            // ��̌Œ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.Fixed = true;              // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.Fixed = true;          // �\������
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.Fixed = true;       // �i��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;       // �i��
            #endregion
            // 2008.08.08 30413 ���� ��̏����ݒ�̒ǉ� <<<<<<END
            
            #region ���V�K���͍s�쐬

            int count;
            for (count = 1; count <= _defaultRowCnt; count++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
                detailRow.No = (short)count;
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
                
            }

            #endregion

            // 2008.08.04 30413 ���� �ύX�s���t�H���g�J���[�ݒ�̕ύX >>>>>>START
            #region ���ύX�s���t�H���g�J���[�ݒ� <<<<<<�ύX�O
            //// 2007.07.10 add by T-Kidate
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // �\������
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // ���[�J�[�R�[�h 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;    // ���[�J�[�K�C�h�{�^��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // ���[�J�[����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // ���i�R�[�h
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;    // ���i�K�C�h�{�^��
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // ���i����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;               // ����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;             // �Z�b�g�K�i�E���L����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;        // �J�^���O�}��
            #endregion

            #region ���ύX�s���t�H���g�J���[�ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // �\������
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // �i��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // �i��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // ���[�J�[�R�[�h 
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;               // �p�s�x(����)
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;             // �Z�b�g�K�i�E���L����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // �񋟋敪
            #endregion
            // 2008.08.04 30413 ���� �ύX�s���t�H���g�J���[�ݒ�̕ύX >>>>>>START
            
            #region �����l�ߐݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;  // ���i�R�[�h
            #endregion

            // 2008.08.22 30413 ���� 1�s�ڂ̕\�����ʂ��A�N�e�B�u�Z���ɐݒ� >>>>>>START
            this.uGrid_Details.Rows[0].Activate();
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
            // 2008.08.22 30413 ���� 1�s�ڂ̕\�����ʂ��A�N�e�B�u�Z���ɐݒ� <<<<<<END
        }

        /// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
        /// <remarks>
        /// Note			:	�{�^���̏����ݒ�����܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;

            this.uButton_RowInsert.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;

            this.uButton_RowInsert.Appearance.Image = (int)Size16_Index.ROWINSERT;
            this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;

            this.uButton_RowInsert.Enabled = true;
            this.uButton_RowDelete.Enabled = true;
			
            // �ύX�t���OOFF
            this._changeFlg = false;
        }

        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        /// <remarks>
        /// Note			:	�{�^���̏����ݒ�����܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        /// <remarks>
        /// Note			:	ActiveRow�C���f�b�N�X���擾���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            // --- ADD m.suzuki 2010/08/04 ---------->>>>>
            if ( this.uGrid_Details.ActiveCell == null )
            {
                return false;
            }
            // --- ADD m.suzuki 2010/08/04 ----------<<<<<

            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            // 2008.08.22 30413 ���� �Z���̃t�H�[�J�X�ݒ��ύX >>>>>>START
            else
            {
                while (!moved)
                {
                    if (!this._goodsDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].EditFlg)
                    {
                        int rowCnt = this.uGrid_Details.ActiveCell.Row.Index;
                        while (!this._goodsDetailDataTable[rowCnt].EditFlg)
                        {
                            rowCnt++;
                        }
                        this.uGrid_Details.Rows[rowCnt].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                        moved = true;
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                        if (!this._setGoodNoUpdFlg)
                        {
                            // �X�V�t���O��false
                            this._setGoodNoUpdFlg = true;
                            // �ړ��O��cell���A�N�e�B�u
                            performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                            moved = true;
                        }

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
                }
            }

            //while (!moved)
            //{
            //    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

            //    if (performActionResult)
            //    {
            //        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
            //            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
            //        {
            //            moved = true;
            //        }
            //        else
            //        {
            //            moved = false;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            // 2008.08.22 30413 ���� �Z���̃t�H�[�J�X�ݒ��ύX <<<<<<END
                
            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Prev�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Prev�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	�O�̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.15<br />
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    if (!this._goodsDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].EditFlg)
                    {
                        int rowCnt = this.uGrid_Details.ActiveCell.Row.Index;
                        while (!this._goodsDetailDataTable[rowCnt].EditFlg)
                        {
                            rowCnt--;
                        }
                        this.uGrid_Details.Rows[rowCnt].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                        moved = true;
                    }
                    else
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
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }


        /// <summary>
        /// �Z�b�g���i���s�}������
        /// </summary>
        /// <param name="insertIndex">�}���sIndex</param>
        /// <remarks>
        /// Note			:	�Z�b�g���i���̋�s��I�����ꂽ�s�ɑ}�����鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void InsertGoodsDetailRow(int insertIndex)
        {
            this.InsertGoodsDetailRow(insertIndex, 1);
        }

        /// <summary>
        /// �Z�b�g���i���s�}�������i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="insertIndex">�}���sIndex</param>
        /// <param name="line">�}���i��</param>
        /// <remarks>
        /// Note			:	�Z�b�g���i���̋�s��I�����ꂽ�s�ɑ}�����鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void InsertGoodsDetailRow(int insertIndex, int line)
        {
            this._goodsDetailDataTable.BeginLoadData();
            
            // ��s��ǉ�����O�̍ŏI�s�̃C���f�b�N�X��ێ�
            int lastRowIndex = this._goodsDetailDataTable.Rows.Count - 1;
            // �I�����ꂽ�s�̍sNo��ێ�
            int goodsRowNo = this._goodsDetailDataTable[insertIndex].No;

            // �Z�b�g���i���s�ǉ�����
            for (int i = 0; i < line; i++)
            {
                // �q���i���P�s�ǉ�����
                this.AddGoodsDetailRow();
            }

            // �ŏI�s����}���Ώۍs�܂ł̍s�����w��i�����ɃR�s�[����
            for (int i = lastRowIndex; i >= insertIndex; i--)
            {
                // �R�s�[���s�̎擾
                GoodsSetGoodsDataSet.GoodsSetDetailRow sourceRow = this._goodsDetailDataTable.FindByNo(this._goodsDetailDataTable[i].No);
                // �R�s�[��s�̎擾
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = this._goodsDetailDataTable.FindByNo(this._goodsDetailDataTable[i + line].No);

                this.CopyGoodsDetailRow(sourceRow, targetRow);
            }

            // �}���Ώۍs���N���A����
            GoodsSetGoodsDataSet.GoodsSetDetailRow clearRow = this._goodsDetailDataTable.FindByNo(this._goodsDetailDataTable[insertIndex].No);
            this.ClearGoodsDetailRow(clearRow);

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// �Z�b�g���i���s�R�s�[����
        /// </summary>
        /// <param name="sourceRow">�R�s�[���Z�b�g���i���f�[�^�e�[�u���s�N���X</param>
        /// <param name="targetRow">�R�s�[��Z�b�g���i���f�[�^�e�[�u���s�N���X</param>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s���R�s�[���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void CopyGoodsDetailRow(GoodsSetGoodsDataSet.GoodsSetDetailRow sourceRow, GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow)
        {
            if ((sourceRow == null) || (targetRow == null)) return;
            
            // �S�J�����̏����R�s�[��s�ɃR�s�[����
            targetRow.Disply            = sourceRow.Disply;             // �\������ 
            targetRow.MakerCode         = sourceRow.MakerCode;          // ���[�J�[�R�[�h
            targetRow.MakerName         = sourceRow.MakerName;          // ���[�J�[����
            targetRow.GoodsCode         = sourceRow.GoodsCode;          // �i��
            targetRow.GoodsName         = sourceRow.GoodsName;          // �i��
            targetRow.CntFl             = sourceRow.CntFl;              // �p�s�x(����)
            targetRow.SetNote           = sourceRow.SetNote;            // �Z�b�g�K�i
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 >>>>>>START
            //targetRow.CatalogShape = sourceRow.CatalogShape;         // �J�^���O�}��
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 <<<<<<END

            // 2008.08.04 30413 ���� �񋟋敪�̒ǉ� >>>>>>START
            targetRow.Division = sourceRow.Division;                    // �񋟋敪
            // 2008.08.04 30413 ���� �񋟋敪�̒ǉ� <<<<<<END

            // 2008.08.07 30413 ���� �ҏW�ۂ̒ǉ� >>>>>>START
            targetRow.EditFlg = sourceRow.EditFlg;                      // �ҏW��
            // 2008.08.07 30413 ���� �ҏW�ۂ̒ǉ� <<<<<<END

            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
            targetRow.AddFlag = sourceRow.AddFlag;                      // �ǉ��t���O
            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END
        }

        /// <summary>
        /// �Z�b�g���i���s�N���A����
        /// </summary>
        /// <param name="row">�Z�b�g���i���f�[�^�e�[�u���s�N���X</param>
        /// <remarks>
        /// Note			:	�Z�b�g���i���̍s���N���A���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void ClearGoodsDetailRow(GoodsSetGoodsDataSet.GoodsSetDetailRow row)
        {
            if (row == null) return;

            // �K�C�h�{�^���ȊO�ɏ����l���i�[����
            row.Disply    = 0;
            //row.MakerCode = 0;
            row.MakerCode = "";
            row.MakerName = ""; 
            row.GoodsCode = "";
            row.GoodsName = "";
            //row.CntFl     = 0;
            row.CntFl = "";
            row.SetNote   = "";
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 >>>>>>START
            //row.CatalogShape = "";
            // 2008.08.04 30413 ���� �J�^���O�}�Ԃ̍폜 <<<<<<END

            // 2008.08.04 30413 ���� �񋟋敪�̒ǉ� >>>>>>START
            row.Division = "";
            // 2008.08.04 30413 ���� �񋟋敪�̒ǉ� <<<<<<END

            // 2008.08.07 30413 ���� �ҏW�ۂ̒ǉ� >>>>>>START
            row.EditFlg = true;
            // 2008.08.07 30413 ���� �ҏW�ۂ̒ǉ� <<<<<<END

            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
            row.AddFlag = true;
            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END            
        }

        /// <summary>
        /// �I���ς݃Z�b�g���i���s�ԍ����X�g�擾����
        /// </summary>
        /// <returns>�I���ς݃Z�b�g���i���s�ԍ����X�g</returns>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s�ԍ����擾���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private List<int> GetSelectedGoodsRowNoList()
        {
            // �I�����ꂽ�Z�����擾
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            // �I�����ꂽ�s���擾����
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedGoodsRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                selectedGoodsRowNoList.Add(this._goodsDetailDataTable[cell.Row.Index].No);
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    selectedGoodsRowNoList.Add(this._goodsDetailDataTable[row.Index].No);
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedGoodsRowNoList;
        }

        /// <summary>
        /// �Z�b�g���i���s�폜�\�`�F�b�N����
        /// </summary>
        /// <param name="goodsRowNoList">�폜�sStockRowNo���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>true:�s�폜�\ false:�s�폜�s��</returns>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s�ԍ����폜�\���`�F�b�N���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private bool CanDeleteGoodsDetailRow(List<int> goodsRowNoList, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// �Z�b�g���i���s�폜����
        /// </summary>
        /// <param name="goodsRowNoList">�폜�sNo���X�g</param>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s���폜���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// <br>UpdateNote  :   2010/12/03  ���N�n��</br>
        /// <br>�C�����e    :   �P�D���׍s��S�č폜��ɁA�w�b�_���̍폜�{�^������������ƃG���[����������s��̏C��</br>
        /// <br>                �Q�D�����s�̖��ׂ�����Z�b�g�i�̖��ׂ̈ꕔ���s�폜���A�w�b�_���̍폜�{�^�������s�����ꍇ�̍폜�����̕s��</br>
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList)
        {
            this.DeleteGoodsDetailRow(goodsRowNoList, false);
            // ---DEL 2010/12/03 ---------------------------------------->>>>>
            // 2009/09/16 Add >>>
            // �s�폜��ɍ폜�f�[�^�e�[�u��������
            //this._deleteGoodsDetailDataTable.Clear();
            // 2009/09/16 Add <<<
            // ---DEL 2010/12/03 ----------------------------------------<<<<<
        }

        /// <summary>
        /// �Z�b�g���i���s�폜����(�I�[�o�[���[�h)
        /// </summary>
        /// <param name="goodsRowNoList">�폜�sStockRowNo���X�g</param>
        /// <param name="changeRowCount">true:�s����ύX���� false:�s����ύX����͕ύX���Ȃ�</param>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s���폜���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList, bool changeRowCount)
        {
            this._goodsDetailDataTable.BeginLoadData();
            foreach (int goodsRowNo in goodsRowNoList)
            {
                // �폜�Ώۍs�����擾����
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);
                if (targetRow == null) continue;

                // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
                // 2008.08.12 30413 ���� �폜�Ώۍs��ޔ� >>>>>>START
                // �폜�Ώۍs��ޔ�
                //if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != 0))
                //if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != ""))
                if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != "") && (!targetRow.AddFlag))
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._deleteGoodsDetailDataTable.NewGoodsSetDetailRow();
                    row.No = targetRow.No;
                    row.Disply = targetRow.Disply;
                    row.GoodsCode = targetRow.GoodsCode;
                    row.GoodsName = targetRow.GoodsName;
                    row.MakerCode = targetRow.MakerCode;
                    row.MakerName = targetRow.MakerName;
                    row.CntFl = targetRow.CntFl;
                    row.SetNote = targetRow.SetNote;
                    row.Division = targetRow.Division;
                    row.EditFlg = targetRow.EditFlg;
                    row.AddFlag = targetRow.AddFlag;
                    this._deleteGoodsDetailDataTable.AddGoodsSetDetailRow(row);
                }
                // 2008.08.12 30413 ���� �폜�Ώۍs��ޔ� <<<<<<END
                // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END
                
                // �Ώۍs�폜����
                this._goodsDetailDataTable.RemoveGoodsSetDetailRow(targetRow);
            }

            // �Z�b�g���i���f�[�^�e�[�u��StockRowNo�񏉊�������
            this.InitializeGoodsSetDetailRowNoColumn();

            if (!changeRowCount)
            {
                // �폜�����������V�K�ɍs��ǉ�����
                for (int i = 0; i < goodsRowNoList.Count; i++)
                {
                    this.AddGoodsDetailRow();
                }
            }
            this._goodsDetailDataTable.EndLoadData();

        }

        /// <summary>
        /// �Z�b�g���i���f�[�^�e�[�u��No�񏉊�������
        /// </summary>
        /// <remarks>
        /// Note			:	�Z�b�g���i���f�[�^�e�[�u����No�����������鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void InitializeGoodsSetDetailRowNoColumn()
        {
            this._goodsDetailDataTable.BeginLoadData();

            for (int i = 0; i < this._goodsDetailDataTable.Rows.Count; i++)
            {
                this._goodsDetailDataTable[i].No = (short)(i + 1);
            }

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// �Z���A�N�e�B�u���{�^���L�������R���g���[������
        /// </summary>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s���폜���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void ActiveCellButtonEnabledControl(int index)
        {
            // �s����{�^���̗L��������ݒ肷��
            //int makerCode = this._goodsDetailDataTable[index].MakerCode;
            int makerCode = int.Parse(this._goodsDetailDataTable[index].MakerCode); 
            string goodsCode = this._goodsDetailDataTable[index].GoodsCode;

            if (makerCode == 0 && goodsCode == "")
            {
                this.uButton_RowInsert.Enabled = true;
                
            }
            else
            {

            }
        }

        /// <summary>
        /// �Z�b�g���i���f�[�^�Z�b�e�B���O�����i���i�Z�b�g���ݒ�j
        /// </summary>
        /// <param name="goodsRowNo">�Z�b�g���i���s�ԍ�</param>
        /// <param name="goodsUnitData">���i�Z�b�g���e�N���X���X�g</param>
        /// <remarks>
        /// Note			:	�Z�b�g���i���s�ɏ��i�Z�b�g���e��ǉ����܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void GoodsDetailRowGoodsSetSetting(int goodsRowNo, GoodsUnitData goodsUnitData)
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            // �K�C�h�f�[�^�W�J
            //row.MakerCode = goodsUnitData.GoodsMakerCd;
            row.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");
            row.MakerName = goodsUnitData.MakerName;
            row.GoodsCode = goodsUnitData.GoodsNo;
            row.GoodsName = goodsUnitData.GoodsName;
            // 2008.08.06 30413 ���� �񋟋敪�̒ǉ� >>>>>>START
            switch (goodsUnitData.OfferKubun)
            {
                case 0:     // ���[�U�[�o�^
                case 1:     // �񋟏����ҏW
                case 2:     // �񋟗D�ǕҏW
                    {
                        // ���[�U�[
                        row.Division = GoodsSetAcs.DIVISION_NAME_USER;
                        break;
                    }
                case 3:     // 3:�񋟏���
                case 4:     // 4:�񋟗D��
                case 5:     // 5:TBO
                case 7:     // 7:�I���W�i��
                    {
                        // ��
                        row.Division = GoodsSetAcs.DIVISION_NAME_OFFER;
                        break;
                    }
            }
            // 2008.08.06 30413 ���� �񋟋敪�̒ǉ� <<<<<<END
            // 2008.08.07 30413 ���� �ҏW�ۂ̒ǉ� >>>>>>START
            row.EditFlg = true;
            // 2008.08.07 30413 ���� �ҏW�ۂ̒ǉ� <<<<<<END

            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
            row.AddFlag = true;
            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END                    

            // ���s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
            if (goodsRowNo == (this._goodsDetailDataTable.Rows.Count + 1))
            {
                this.AddGoodsDetailRow();
            }
        }

        /// <summary>
        /// �Z�b�g���i���f�[�^�Z�b�e�B���O�����i���[�J�[���ݒ�j
        /// </summary>
        /// <param name="goodsRowNo">�Z�b�g���i���s�ԍ�</param>
        /// <param name="makerUMnt">���[�J�[���e�N���X���X�g</param>
        /// <remarks>
        /// Note			:	�I�����ꂽ�Z�b�g���i���̍s�Ƀ��[�J�[����ݒ肷�鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void MakerDetailRowGoodsSetSetting(int goodsRowNo, MakerUMnt makerUMnt)
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            // �K�C�h�f�[�^�W�J
            //row.MakerCode = makerUMnt.GoodsMakerCd;
            row.MakerCode = makerUMnt.GoodsMakerCd.ToString("d04");
            row.MakerName = makerUMnt.MakerName;

            // ���[�J�[���ݒ肳�ꂽ��f�[�^�̐����������킹�邽�ߏ��i�����N���A����
            row.GoodsCode = "";
            row.GoodsName = "";
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
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// Note			:	�����ꂽ�L�[�����l�̂ݗL���ɂ��鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 2008.10.15 30413 ���� �����_�`�F�b�N�̓}�C�i�X���̓t���O�ƕ��� >>>>>>START
            // �����_�̃`�F�b�N
            if (key == '.')
            {
                //// �����_(�}�C�i�X)�����͉\���H
                //if (minusFlg == false)
                //{
                //    return false;
                //}
                // �����_�ȉ�������0���H
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }       
            }
            // 2008.10.15 30413 ���� �����_�`�F�b�N�̓}�C�i�X���̓t���O�ƕ��� <<<<<<END
            
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                // 2008.10.15 30413 ���� �����`�F�b�N�������_�Ή� >>>>>>START
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                // 2008.10.15 30413 ���� �����`�F�b�N�������_�Ή� <<<<<<END
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �񋟋敪�ŕҏW�s�̐�����s��
        /// </summary>
        /// <remarks>
        /// Note			:	�񋟋敪�ŕҏW�s��ݒ肷�鏈�����s���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.08.07<br />
        /// </remarks>
        private void ChangeRowActivation_Division()
        {
            int rowCnt = this._goodsDetailDataTable.Rows.Count;
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // �s�e�[�u��
            for (int i = 0; i < rowCnt; i++)
            {
                // �f�[�^�e�[�u�����擾
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];
                // �s�ԍ����擾
                int rowNo = detailRow.No - 1;

                if ((detailRow.Division == GoodsSetAcs.DIVISION_NAME_OFFER) && !detailRow.EditFlg)
                {
                    // �񋟃f�[�^�͕ҏW�s��
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.CntFlColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    // ���[�U�[�f�[�^�͕ҏW��
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.CntFlColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;                    
                }
            }
        }

        #endregion

        # region ��Control Event Methods

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
        }

        // 2008.10.30 30413 ���� ���g�p�C�x���g�̍폜 >>>>>>START
        #region �O���b�h�Z���A�b�v�f�[�g��C�x���g
        ///// <summary>
        ///// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        //private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        //{
        //    // �ύX�t���OON
        //    _changeFlg = true;
            
        //    if (e.Cell == null) return;

        //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
        //    int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;
        //    int rowIndex = e.Cell.Row.Index;

        //    // ���l���ڂ���̏ꍇ
        //    if (e.Cell.Value is DBNull)
        //    {
        //        if ((e.Cell.Column.DataType == typeof(Int32)) ||
        //            (e.Cell.Column.DataType == typeof(Int64)) ||
        //            (e.Cell.Column.DataType == typeof(double)))
        //        {
        //            e.Cell.Value = 0;
        //        }
        //    }

        //    #region ��ActiveCell���i�Ԃ̏ꍇ
        //    if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //    {
        //        string goodsCode = cell.Value.ToString();

        //        // �i�ԍX�V�敪�̏����ݒ�
        //        this._setGoodNoUpdFlg = true;

        //        if (!String.IsNullOrEmpty(goodsCode))
        //        {
        //            #region �����͗L
        //            string searchCode;

        //            #region < ������ގ擾 >
        //            int searchType = this.GetSearchType(goodsCode, out searchCode);
        //            #endregion

        //            List<GoodsUnitData> goodsUnitDataList;
        //            string message;

        //            // 2008.08.06 30413 ���� ���i���������̕ύX >>>>>>START
        //            #region < ���i���̎擾 > <<<<<<�ύX�O
        //            //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
        //            //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
        //            #endregion

        //            #region < �i���擾 >
        //            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
        //            GoodsCndtn goodsCndtn = new GoodsCndtn();
        //            //GoodsAcs goodsAcs = new GoodsAcs();

        //            // ���i���������ݒ�
        //            goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //            goodsCndtn.SectionCode = sectionCd;
        //            goodsCndtn.GoodsMakerCd = 0;
        //            goodsCndtn.MakerName = "";
        //            goodsCndtn.GoodsNo = goodsCode;
        //            goodsCndtn.GoodsNoSrchTyp = searchType;

        //            //int status = goodsAcs.SearchInitial(this._enterpriseCode, sectionCd, out message);
        //            // 2008.08.26 30413 ���� ���i�A�N�Z�X�N���X�̃��\�b�h�ύX >>>>>>START
        //            //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out goodsUnitDataList, out message);
        //            //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //            int status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //            // 2008.08.26 30413 ���� ���i�A�N�Z�X�N���X�̃��\�b�h�ύX <<<<<<END
        //            #endregion
        //            // 2008.08.06 30413 ���� ���i���������̕ύX <<<<<<END

        //            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //            {
        //                #region -- ����擾 --
        //                // ���i�}�X�^�f�[�^�N���X
        //                GoodsUnitData goodsUnitData = new GoodsUnitData();
        //                goodsUnitData = goodsUnitDataList[0];
                        
        //                // ���i�}�X�^���ݒ菈��
        //                this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

        //                // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� >>>>>>START
        //                // �擾�������i�A���f�[�^���L���b�V���Ƃ��ĕێ�
        //                if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
        //                {
        //                    _lcGoodsUnitDataList.Add(goodsUnitData);
        //                }
        //                // 2008.08.21 30413 ���� ���i�A�����[�J���L���b�V���p�f�[�^���X�g�ǉ� <<<<<<END
        //                #endregion
        //            }
        //            else
        //            {
        //                #region -- �擾���s --
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_INFO,
        //                    this.Name,
        //                    // 2008.08.06 30413 ���� ���i�R�[�h���i�ԂɕύX >>>>>>START
        //                    //"���i�R�[�h [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
        //                    "�i�� [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
        //                    // 2008.08.06 30413 ���� ���i�R�[�h���i�ԂɕύX <<<<<<END
        //                    -1,
        //                    MessageBoxButtons.OK);

        //                // �Ώۍs�̃N���A
        //                //this._goodsDetailDataTable[cell.Row.Index].GoodsCode = this._beforeGoodsCode;
        //                this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // �i��
        //                this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // �i��
        //                // 2008.08.20 30413 ���� ���[�J�[���N���A >>>>>>START
        //                //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;           // ���[�J�[�R�[�h
        //                this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // ���[�J�[�R�[�h
        //                this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // ���[�J�[����
        //                this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
        //                this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // �Z�b�g�K�i�E���L����
        //                this._goodsDetailDataTable[cell.Row.Index].Division = "";       // �񋟋敪
        //                this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // �ҏW�ۃt���O
        //                // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
        //                this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // �ǉ��t���O
        //                // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END                        
        //                // 2008.08.20 30413 ���� ���[�J�[���N���A <<<<<<END

        //                // �i�ԍX�V�敪�̏����ݒ�
        //                this._setGoodNoUpdFlg = false;

        //                #endregion
        //            }
        //            #endregion
        //        }
        //        else
        //        {
        //            #region ��������
        //            // �i�Ԃ����ɖ߂�
        //            //this._goodsDetailDataTable[cell.Row.Index].GoodsCode = this._beforeGoodsCode;
        //            this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";
        //            // �i���̃N���A
        //            this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";
        //            // 2008.08.20 30413 ���� ���[�J�[���N���A >>>>>>START
        //            //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;           // ���[�J�[�R�[�h
        //            this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";          // ���[�J�[�R�[�h
        //            this._goodsDetailDataTable[cell.Row.Index].MakerName = "";          // ���[�J�[����
        //            this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;             // QTY
        //            this._goodsDetailDataTable[cell.Row.Index].SetNote = "";            // �Z�b�g�K�i�E���L����
        //            this._goodsDetailDataTable[cell.Row.Index].Division = "";           // �񋟋敪
        //            this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;          // �ҏW�ۃt���O
        //            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
        //            this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;
        //            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END                        
        //            // 2008.08.20 30413 ���� ���[�J�[���N���A <<<<<<END
        //            #endregion
        //        }

        //    }
        //    #endregion

        //    // 2008.10.10 30413 ���� ���[�J�[�R�[�h�͓��͕s�ɂȂ����̂ō폜 >>>>>>START
        //    #region ��ActiveCell�����[�J�[�R�[�h�̏ꍇ
        //    //else if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
        //    //{
        //    //    int searchCode = (int)cell.Value;

        //    //    // 0 �������� �� �ȊO�����͂��ꂽ�ꍇ
        //    //    if (searchCode != 0)
        //    //    {
        //    //        MakerUMnt makerUMnt;
        //    //        //MakerAcs makerAcs = new MakerAcs();
        //    //        GoodsAcs goodsAcs = new GoodsAcs();
        //    //        string msg;
        //    //        goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

        //    //        #region < ���[�J�[���擾 >
        //    //        // �����i�����̃��[�J�[�}�X�^���擾���\�b�h���Ăяo��
        //    //        int status = goodsAcs.GetMaker(this._enterpriseCode, searchCode, out makerUMnt);
        //    //        #endregion

        //    //        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (makerUMnt != null))
        //    //        {
        //    //            #region -- ����擾 --
        //    //            // ���[�J�[�}�X�^���ݒ菈��
        //    //            this.MakerDetailRowGoodsSetSetting(goodsRowNo, makerUMnt);
                        
        //    //            // ���i�R�[�h�����͂����悤�ɐ��䂷��
        //    //            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //    //            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //    //            this.uGrid_Details.ActiveCell.SelStart = 0;
        //    //            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //    //            #endregion
        //    //        }
        //    //        else
        //    //        {
        //    //            #region -- �擾���s --
        //    //            TMsgDisp.Show(
        //    //                this,
        //    //                emErrorLevel.ERR_LEVEL_INFO,
        //    //                this.Name,
        //    //                "���[�J�[�R�[�h [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
        //    //                -1,
        //    //                MessageBoxButtons.OK);

        //    //            // ���[�J�[�����N���A
        //    //            //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;
        //    //            this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";
        //    //            this._goodsDetailDataTable[cell.Row.Index].MakerName = "";
                        
        //    //            //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];
        //    //            //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //    //            //this.uGrid_Details.ActiveCell.SelStart = 0;
        //    //            //this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //    //            #endregion
        //    //        }
        //    //    }
        //    //    // �l����Ȃ�
        //    //    else
        //    //    {
        //    //        // ���[�J�[�����N���A
        //    //        //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;
        //    //        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";
        //    //        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";
                    
        //    //    }
        //    //}
        //    #endregion
        //    // 2008.10.10 30413 ���� ���[�J�[�R�[�h�͓��͕s�ɂȂ����̂ō폜 <<<<<<END
        //}
        #endregion
        // 2008.10.30 30413 ���� ���g�p�C�x���g�̍폜 <<<<<<END
        
        /// <summary>
        /// Grid�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // 2008.12.17 30413 ���� IME�����ύX >>>>>>START
            // �Z���P�ʂł�IME����
            //if (e.Cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName) 
            //{
            //    // IME���Ђ炪�ȃ��[�h�ɂ���
            //    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //}
            //if (e.Cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            //{
            //    // IME���N�����Ȃ�
            //    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Off;
            //}
            if (e.Cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
            {
                // �Z�b�g�K�i�^���L���� IME��ON
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            else
            {
                // ���̑� IME�𖳌�
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
            // 2008.12.17 30413 ���� IME�����ύX <<<<<<END
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            #region ��ActiveCell�����[�J�[�R�[�h�̏ꍇ
            if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            {
                // ���͑O�̃f�[�^��AfterCellUpdate�C�x���g�̂��߂ɕێ�
                //if (e.Cell.Value != null) 
                if (e.Cell.Value != DBNull.Value) 
                {
                    this._beforeMakerCode = (int)e.Cell.Value;
                }
                else
                {
                    this._beforeMakerCode = 0;
                }
            }
            #endregion

            #region ��ActiveCell���i�Ԃ̏ꍇ
            else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                // ���͑O�̃f�[�^��AfterCellUpdate�C�x���g�̂��߂ɕێ�
                if (e.Cell.Value != null)
                {
                    this._beforeGoodsCode = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeGoodsCode = "";
                }
            }
            #endregion
        }

        /// <summary>
        /// �O���b�h�f�[�^�G���[�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        // 2008.08.07 30413 ���� �Z���{�^���̍폜 >>>>>>START
        #region �Z���{�^���N���b�N�C�x���g
        ///// <summary>
        ///// �Z���{�^���N���b�N�C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        //private void uGrid_Details_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        //{
        //    this._goodsDetailDataTable.AcceptChanges();

        //    // ActiveRow�C���f�b�N�X�擾����
        //    int rowIndex = e.Cell.Row.Index;
        //    if (rowIndex == -1) return;

        //    // �Z�b�g���i���s�ԍ����擾
        //    int goodsRowNo = this._goodsDetailDataTable[rowIndex].No;

        //    switch (e.Cell.Column.Index)
        //    {
        //        case 3:

        //            #region �����[�J�[�K�C�h�{�^��
        //            {
        //                #region < ���[�J�[�K�C�h�N�� >
        //                GoodsAcs goodsAcs = new GoodsAcs();
        //                string msg;
        //                goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

        //                MakerUMnt makerUMnt = new MakerUMnt();

        //                int status = goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out makerUMnt);
        //                #endregion

        //                #region < �擾���s >
        //                if (status != 0)
        //                {
        //                    // �t�H�[�J�X�����[�J�[�R�[�h�ɂ��ē��̓f�[�^��S�I��
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];

        //                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //                    // �S�I������
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                }
        //                #endregion

        //                #region < ����擾 >
        //                else
        //                {
        //                    // ���[�J�[�}�X�^���ݒ菈��
        //                    this.MakerDetailRowGoodsSetSetting(goodsRowNo, makerUMnt);

        //                    // �t�H�[�J�X�����i�R�[�h�ɂ���
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //                    // �����͉\�Z���ړ�����
        //                    this.MoveNextAllowEditCell(true);
        //                    // �S�I������
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                }
        //                #endregion

        //                break;
        //            }

        //            #endregion


        //        case 6:

        //            #region �����i�K�C�h�{�^��
        //            {
        //                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //                GoodsUnitData goodsUnitData;

        //                #region < ���������ǉ� >
        //                // ���͂���Ă��錟�������ɒǉ�����
        //                GoodsCndtn goodsCndtn = new GoodsCndtn();
        //                goodsCndtn.GoodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value;
        //                goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //                #endregion

        //                #region < ���i�����N�� >
        //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate START
        //                //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, false, goodsCndtn, out goodsUnitData);
        //                DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
        //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate END
        //                #endregion

        //                #region < ��ʕ\������ >
        //                if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //                {
        //                    #region -- ����擾 --
        //                    // ���i�}�X�^���ݒ菈��
        //                    this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

        //                    // �I������Ă���s���ŏI�s�H
        //                    if (this.uGrid_Details.Rows.Count == (rowIndex + 1))
        //                    {
        //                        // ��̐V�K�s�̒ǉ�
        //                        GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
        //                        detailRow.No = (short)(this.uGrid_Details.Rows.Count + 1);
        //                        this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
        //                    }

        //                    // �t�H�[�J�X�͎��s�̃��[�J�[�R�[�h
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex + 1].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];
        //                    // �Z����ҏW���[�h�ɂ���
        //                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                    #endregion
        //                }
        //                else
        //                {
        //                    #region -- �擾���s --
        //                    // �t�H�[�J�X�����̏��i�R�[�h�ɖ߂�
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //                    // �Z����ҏW���[�h�ɂ���
        //                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                    #endregion
        //                }
        //                #endregion

        //                break;
        //            }
        //            #endregion

        //    }
        //}
        #endregion
        // 2008.08.07 30413 ���� �Z���{�^���̍폜 <<<<<<END

        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];

                        // �����͉\�Z���ړ�����
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                if ((!this.uGrid_Details.ActiveCell.IsInEditMode) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    this.MoveNextAllowEditCell(true);
                }
            }

            // �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
            this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �Ȃɂ����Ȃ�
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            #region ���Z�����I������Ă���ꍇ
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                #region ��Escape�L�[
                if (e.KeyCode == Keys.Escape)
                {
                    // �Ȃɂ����Ȃ�
                }
                #endregion

                #region ��Shift�L�[
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                    }
                }
                #endregion

                #region �����̑��̃L�[
                else
                {
                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            #region < �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t) >
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion

                            #region < ��L�ȊO�̃X�^�C�� >
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion
                        }
                    }

                    switch (e.KeyCode)
                    {
                        #region < Homo�L�[ >
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion

                        #region < End�L�[ >
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion
                    }

                    // �ŏ�ʍs�Ƀt�H�[�J�X
                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                    {
                        #region < ���L�[ >
                        if (e.KeyCode == Keys.Up)
                        {
                            if (this.GridKeyDownTopRow != null)
                            {
                                this.GridKeyDownTopRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                    // �ŉ��ʍs�Ƀt�H�[�J�X
                    else if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                    {
                        #region < ���L�[ >
                        if (e.KeyCode == Keys.Down)
                        {
                            if (this.GridKeyDownButtomRow != null)
                            {
                                this.GridKeyDownButtomRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }
            #endregion

            #region ���񂪑I������Ă���ꍇ
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                switch (e.KeyCode)
                {
                    #region < Delete�L�[ >
                    case Keys.Delete:
                        {
                            this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                            break;
                        }
                    #endregion
                }

                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    #region < ���L�[ >
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    #region < ���L�[ >
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
            }
            #endregion
        }

        /// <summary>
        /// �O���b�h�L�[�v���X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 2008.10.15 30413 ���� ���[�J�[�R�[�h�͓��͕s�ɕύX >>>>>>START
            #region ��ActiveCell�����[�J�[�R�[�h�̏ꍇ
            //if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            //{
            //    // �ҏW���[�h���H
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            #endregion
            // 2008.10.15 30413 ���� ���[�J�[�R�[�h�͓��͕s�ɕύX <<<<<<END

            // 2008.10.15 30413 ���� �\�����ʂ̓��͌����`�F�b�N��ǉ� >>>>>>START
            #region ��ActiveCell���\�����ʂ̏ꍇ
            if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
            // 2008.10.15 30413 ���� �\�����ʂ̓��͌����`�F�b�N��ǉ� <<<<<<END
            
            #region DEL �i�ԃ`�F�b�N�̍폜
            // DEL 2015/10/28 ���V�� Redmine#47547 �Z�b�g�q�i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή� ----->>>>>
            //#region ��ActiveCell���i�Ԃ̏ꍇ
            //else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            //{
            //    // �ҏW���[�h���H
            //    if (cell.IsInEditMode)
            //    {
            //        // 2008.10.15 30413 ���� �i�Ԃ̓��͌�����24���ɕύX >>>>>>START
            //        //if (!this.KeyPressNumCheck(15, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true, true))
            //        if (!this.KeyPressNumCheck(24, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true, true))
            //        // 2008.10.15 30413 ���� �i�Ԃ̓��͌�����24���ɕύX >>>>>>START
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            //#endregion
            // DEL 2015/10/28 ���V�� Redmine#47547 �Z�b�g�q�i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή� -----<<<<<
            #endregion

            // 2008.10.15 30413 ���� QTY�̓��͌����`�F�b�N��ǉ� >>>>>>START
            #region ��ActiveCell��QTY�̏ꍇ
            if (cell.Column.Key == this._goodsDetailDataTable.CntFlColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
            // 2008.10.15 30413 ���� QTY�̓��͌����`�F�b�N��ǉ� <<<<<<END
            
            // 2008.08.07 30413 ���� ���[�J�[�K�C�h�{�^���̍폜 >>>>>>START
            #region ��ActiveCell�����[�J�[�K�C�h�̏ꍇ
            //else if (cell.Column.Key == this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyChar == (char)Keys.Space)
            //    {
            //        //
            //    }
            //}
            #endregion
            // 2008.08.07 30413 ���� ���[�J�[�K�C�h�{�^���̍폜 <<<<<<END
            
            // 2008.08.04 30413 ���� ���i�K�C�h�{�^���̍폜 >>>>>>START
            #region ��ActiveCell�����i�K�C�h�{�^���̏ꍇ
            //else if (cell.Column.Key == this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyChar == (char)Keys.Space)
            //    {
            //        //
            //    }
            //}
            #endregion
            // 2008.08.04 30413 ���� ���i�K�C�h�{�^���̍폜 <<<<<<END
            
        }

        /// <summary>
        /// �O���b�h�L�[�A�b�v�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 2008.08.04 30413 ���� ���i�K�C�h�{�^���̍폜 >>>>>>START
            #region ��ActiveCell�����i�K�C�h�{�^���̏ꍇ
            //if (cell.Column.Key == this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        Infragistics.Win.UltraWinGrid.CellEventArgs ce = new Infragistics.Win.UltraWinGrid.CellEventArgs(cell);
            //        this.uGrid_Details_ClickCellButton(this.uGrid_Details, ce);
            //    }
            //}
            #endregion
            // 2008.08.04 30413 ���� ���i�K�C�h�{�^���̍폜 <<<<<<END

            // 2008.08.07 30413 ���� ���[�J�[�K�C�h�{�^���̍폜 >>>>>>START
            #region ��ActiveCell�����[�J�[�K�C�h�{�^���̏ꍇ
            //if (cell.Column.Key == this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        Infragistics.Win.UltraWinGrid.CellEventArgs ce = new Infragistics.Win.UltraWinGrid.CellEventArgs(cell);
            //        this.uGrid_Details_ClickCellButton(this.uGrid_Details, ce);
            //    }
            //}
            // 2008.08.07 30413 ���� ���[�J�[�K�C�h�{�^���̍폜 <<<<<<END
            #endregion

        }

        /// <summary>
        /// ���׃O���b�h���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // ����̎d�l�ł͉����������Ȃ�
            // �d�����͂ł́A�X�e�[�^�X�o�[�̏��������s
        }

        /// <summary>
        /// �O���b�h�}�E�X�G���^�[�G�������g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            // ����̎d�l�ł͂Ȃɂ��������Ȃ�
        }

        /// <summary>
        /// �O���b�h�}�E�X���[���G�������g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            // ����̎d�l�ł͂Ȃɂ��������Ȃ�
        }

        /// <summary>
        /// �h���b�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// Note			:	�s�E��E�w�b�_�̃h���b�O���̃C�x���g���������܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.08.08<br />
        /// </remarks>
        private void uGrid_Details_SelectionDrag(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Details.Selected.Columns.Count > 0)
            {
                int pos = this.uGrid_Details.Selected.Columns[0].VisiblePosition;
                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[pos].Header.Fixed)
                {
                    e.Cancel = true;
                }
            }
        }

        #region �� uButton �C�x���g

        /// <summary>
        /// �}���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>UpdateNote  : K2019/01/07 杍^</br>
        /// <br>�C�����e    : �����e���l�ɂăZ�b�g�}�X�^�̍ő�o�^������99���ɑ��₷�̑Ή�</br>
        /// </remarks>
        private void uButton_RowInsert_Click(object sender, EventArgs e)
        {
            this._goodsDetailDataTable.AcceptChanges();

            // ActiveRow�C���f�b�N�X�擾����
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ---->>>>>
            if (this.HaveRuntel && this.uGrid_Details.Rows.Count >= MaxRowNumForRuntel)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Z�b�g���i�͂X�X�ȓ��ō\�����Ă��������B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            //---- ADD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ----<<<<<
            // 2008.08.07 30413 ���� �s����50�𒴂���ꍇ�͑}���s�� >>>>>>START
            //---- UPD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ---->>>>>
            //if (this.uGrid_Details.Rows.Count >= _maxRowNum)
            else if (!this.HaveRuntel && this.uGrid_Details.Rows.Count >= _maxRowNum)
            //---- UPD 杍^ K2019/01/07 FOR Redmine#49801�̑Ή� ----<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Z�b�g���i�͂T�O�ȓ��ō\�����Ă��������B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 2008.08.07 30413 ���� �s����50�𒴂���ꍇ�͑}���s�� <<<<<<END
            

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �d�����׍s�}������
                this.InsertGoodsDetailRow(rowIndex);

                // ���׃O���b�h�Z���ݒ菈��
                // 2007.05.11 deleted by T-Kidate : �}�����ɂ͂Ƃ��ɃO���b�h�̐ݒ���s�Ȃ�Ȃ��Ɣ��f��������
                //this.SettingGrid();

                // 2008.08.07 30413 ���� �񋟋敪�ɂ��ҏW�s���� >>>>>>START
                this.ChangeRowActivation_Division();
                // 2008.08.07 30413 ���� �񋟋敪�ɂ��ҏW�s���� <<<<<<END


                // �����͉\�Z���ړ�����
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �}���{�^��Enabled�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowInsert_EnabledChanged(object sender, EventArgs e)
        {
            // [����]�E�C���h�E���̃{�^���ƃc�[���{�b�N�X���̃{�^����Enabled�v���p�e�B�̓�������邽�߂̏���
            //       ����E�C���h�E��\�����Ȃ����߂��̃C�x���g���ł͏����͉����s�Ȃ�Ȃ����̂Ƃ���B
            //this._rowInsertButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// �폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._goodsDetailDataTable.AcceptChanges();

            // �I���ς݃Z�b�g���i���s�ԍ����X�g�擾����
            List<int> selectedGoodsRowNoList = this.GetSelectedGoodsRowNoList();
            if ((selectedGoodsRowNoList == null) || (selectedGoodsRowNoList.Count == 0))
            {
                return;
            }

            // 2008.08.07 30413 ���� �񋟂̃`�F�b�N >>>>>>START
            int rowIdx = selectedGoodsRowNoList[0];
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find(rowIdx);

            if (!detailRow.EditFlg)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�o�^�ς̒񋟃f�[�^�͍폜�ł��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 2008.08.07 30413 ���� �񋟂̃`�F�b�N <<<<<<END
            
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "�I���s���폜���Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // ActiveRow�C���f�b�N�X�擾����
            int rowIndex = this.GetActiveRowIndex();

            string message;
            // �폜�\�`�F�b�N����(���݂͕K��True���������Ă���)
            if (!this.CanDeleteGoodsDetailRow(selectedGoodsRowNoList, out message))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �Z�b�g���i���s�폜����
                this.DeleteGoodsDetailRow(selectedGoodsRowNoList);

                // ���׃O���b�h�Z���ݒ菈��
                // 2007.05.11 deleted by T-Kidate : �}�����ɂ͂Ƃ��ɃO���b�h�̐ݒ���s�Ȃ�Ȃ��Ɣ��f��������
                //this.SettingGrid();

                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];

                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }

                // �����͉\�Z���ړ�����
                this.MoveNextAllowEditCell(true);

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �폜�{�^��Enabled�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
        {
            // [����]�E�C���h�E���̃{�^���ƃc�[���{�b�N�X���̃{�^����Enabled�v���p�e�B�̓�������邽�߂̏���
            //       ����E�C���h�E��\�����Ȃ����߂��̃C�x���g���ł͏����͉����s�Ȃ�Ȃ����̂Ƃ���B
            //this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        #endregion

        #endregion


        /// <summary>
        /// �f�[�^�s�f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="No">�\��No</param>
        /// <param name="goodsUnitData">�I�����ꂽ�f�[�^�s</param>
        /// <remarks>
        /// Note			:	�\������f�[�^�s���O���b�h�Ƀo�C���h���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.08.07<br />
        /// </remarks>
        public void SetGoodsSetDataTable(int No, GoodsUnitData goodsUnitData)
        {
            this._goodsDetailDataTable.BeginLoadData();

            // �\���s
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // ��̓��͍s�ȏ�f�[�^�����݂���ꍇ�͐V�K�s������ăf�[�^���i�[
            if (No > _defaultRowCnt)
            {
                detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            }
            // ��̓��͍s�ȉ��̏ꍇ�͑��݂���s���ƕϐ�No����v����s���X�V����
            else
            {
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find((short)No);
            }

            // �K�v�ȍ��ڂ����O���b�h�\���f�[�^�e�[�u���ɃZ�b�g
            detailRow.No = (short)No;                                                   // No
            if (goodsUnitData.DisplayOrder.ToString() != string.Empty)
            {
                detailRow.Disply = goodsUnitData.SetDispOrder;                          // �\������
            }

            detailRow.GoodsCode = goodsUnitData.GoodsNo;                                // �i��
            detailRow.GoodsName = goodsUnitData.GoodsName;                              // �i��
            //detailRow.MakerCode = goodsUnitData.GoodsMakerCd;                           // ���[�J�[�R�[�h
            // DEL 2009/04/09 ------>>>
            //detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // ���[�J�[�R�[�h
            //detailRow.MakerName = goodsUnitData.MakerName;                              // ���[�J�[����
            // DEL 2009/04/09 ------<<<
            
            // ADD 2009/04/09 ------>>>
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                detailRow.MakerCode = string.Empty;
                detailRow.MakerName = string.Empty;
            }
            else
            {
                detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // ���[�J�[�R�[�h
                detailRow.MakerName = goodsUnitData.MakerName;                              // ���[�J�[����
            }
            // ADD 2009/04/09 ------<<<

            //if (dataRow[GoodsSetAcs.CNTFL_TITLE].ToString() != string.Empty)
            //{
                //detailRow.CntFl = (double)dataRow[GoodsSetAcs.CNTFL_TITLE];             // �p�s�x(����)
            //}
            //detailRow.CntFl = goodsUnitData.SetQty;                                     // �p�s�x(����)
            detailRow.CntFl = goodsUnitData.SetQty.ToString("##0.00");                                     // �p�s�x(����)

            detailRow.SetNote = goodsUnitData.SetSpecialNote;                           // �Z�b�g�K�i�E���L����

            // �V�K�s�̂Ƃ��̂ݐV�����s��ǉ����邽��Add�������K�v
            if (No > _defaultRowCnt)
            {
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            // �񋟃f�[�^�s��ҏW�s�Ƃ���
            //if (goodsUnitData.OfferKubun != 0)
            if(!this._goodsSetAcs.CheckDivision(goodsUnitData))
            {
                // �񋟃f�[�^
                detailRow.Division = GoodsSetAcs.DIVISION_NAME_OFFER;
                detailRow.EditFlg = false;

                int rowIdx = No - 1;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.CntFlColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else
            {
                // ���[�U�f�[�^
                detailRow.Division = GoodsSetAcs.DIVISION_NAME_USER;
                detailRow.EditFlg = true;
            }

            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� >>>>>>START
            detailRow.AddFlag = false;
            // 2008.10.20 30413 ���� �ǉ��t���O�̒ǉ� <<<<<<END                    

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// �폜�Ώۃf�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="deleteDataList">�I�����ꂽ�f�[�^�s</param>
        /// <remarks>
        /// Note			:	�\������f�[�^�s���O���b�h�Ƀo�C���h���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.08.07<br />
        /// </remarks>
        public void GetDeleteData(out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList)
        {
            deleteDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // �폜�Ώۃf�[�^�e�[�u���̌������J�E���g
            int totalCnt = this._deleteGoodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._deleteGoodsDetailDataTable.Rows[i];

                // �폜�Ώۃf�[�^�e�[�u����ǉ�
                deleteDataList.Add(row);
            }
        }

        /// <summary>
        /// ���i�A���f�[�^�p���[�J���L���b�V���擾
        /// </summary>
        /// <param name="goodsUnitDataDic">���i�A���f�[�^�p�f�B�N�V���i���[</param>
        /// <remarks>
        /// Note			:	���i�A���f�[�^�p���[�J���L���b�V�����擾���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.08.21<br />
        /// </remarks>
        public void GetLC_GoodsUnitData(out Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            goodsUnitDataDic = new Dictionary<string,GoodsUnitData>();

            foreach (GoodsUnitData workGoodsUnitData in _lcGoodsUnitDataList)
            {
                // ���[�U�[�o�^����Ă��Ȃ����i�A���f�[�^��ݒ�
                switch (workGoodsUnitData.OfferKubun)
                {
                    case 3:     // 3:�񋟏���
                    case 4:     // 4:�񋟗D��
                    case 5:     // 5:TBO
                    case 7:     // 7:�I���W�i��
                        {
                            // �i�Ԃƃ��[�J�[�R�[�h���L�[�Ƃ���
                            string key = workGoodsUnitData.GoodsNo + "-" + workGoodsUnitData.GoodsMakerCd.ToString("d04");
                            if (goodsUnitDataDic.ContainsKey(key))
                            {
                                goodsUnitDataDic.Remove(key);
                            }
                            goodsUnitDataDic.Add(key, workGoodsUnitData);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// �}�E�X�|�C���^�A�b�v EVENT
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// Note			:	�}�E�X�|�C���^�����ꂽ�Ƃ��̃C�x���g���������܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.14<br />
        /// </remarks>
        private void uGrid_Details_MouseUp(object sender, MouseEventArgs e)
        {
            #region ����̏����ݒ�
            // �Œ��̏����ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.VisiblePosition = 0;              // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.VisiblePosition = 1;          // �\������
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.VisiblePosition = 2;       // �i��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = 3;       // �i��
            #endregion
            
        }

        /// <summary>
        /// �e���i�����擾(�`�F�b�N�p)
        /// </summary>
        /// <param name="GoodsNo">�e�i��</param>
        /// <param name="GoodsMakerCd">�e���[�J�[</param>
        /// <remarks>
        /// Note			:	�e���i�����擾���܂��B<br />
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.15<br />
        /// </remarks>
        public void SetParentData(string GoodsNo, int GoodsMakerCd)
        {
            // �e�i��
            this._parentGoodsNo = GoodsNo;
            // �e���[�J�[
            this._parentMakerCode = GoodsMakerCd;
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note	    :   GRID�̃Z���ҏW�I���C�x���g�����B</br>
        /// Programmer		:	30413 ����<br />
        /// Date			:	2008.10.30<br />
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            int status = -1;

            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;
            int rowIndex = cell.Row.Index;

            #region ��ActiveCell���i�Ԃ̏ꍇ
            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                string goodsCode = cell.Value.ToString();

                // �i�ԍX�V�敪�̏����ݒ�
                this._setGoodNoUpdFlg = true;

                if (this._childGoodsNo == goodsCode)
                {
                    // �ҏW�O�ƕҏW�オ�����ꍇ�͏������s��Ȃ�
                    return;
                }

                if (!String.IsNullOrEmpty(goodsCode))
                {
                    #region �����͗L
                    string searchCode;

                    #region < ������ގ擾 >
                    int searchType = this.GetSearchType(goodsCode, out searchCode);
                    #endregion

                    List<GoodsUnitData> goodsUnitDataList;
                    string message;

                    #region < �i���擾 >
                    string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
                    GoodsCndtn goodsCndtn = new GoodsCndtn();

                    // ���i���������ݒ�
                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.SectionCode = sectionCd;
                    goodsCndtn.GoodsMakerCd = 0;
                    goodsCndtn.MakerName = "";
                    goodsCndtn.GoodsNo = goodsCode;
                    goodsCndtn.GoodsNoSrchTyp = searchType;
                    goodsCndtn.IsSettingSupplier = 1; // 2009.02.09
                    goodsCndtn.PriceApplyDate = DateTime.Today;
            
                    status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
                    #endregion

                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    {
                        #region -- ����擾 --
                        // ���i�}�X�^�f�[�^�N���X
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataList[0];

                        // ���i�}�X�^���ݒ菈��
                        this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

                        // �擾�������i�A���f�[�^���L���b�V���Ƃ��ĕێ�
                        if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
                        {
                            _lcGoodsUnitDataList.Add(goodsUnitData);
                        }
                        #endregion
                    }
                    else if (status == -1)
                    {
                        // ����i�ԑI����ʂŃL�����Z��
                        // �Ώۍs�̃N���A
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // �i��
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // �i��
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // ���[�J�[�R�[�h
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // ���[�J�[����
                        //this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].CntFl = "";         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // �Z�b�g�K�i�E���L����
                        this._goodsDetailDataTable[cell.Row.Index].Division = "";       // �񋟋敪
                        this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // �ҏW�ۃt���O
                        this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // �ǉ��t���O

                        // �i�ԍX�V�敪�̏����ݒ�
                        this._setGoodNoUpdFlg = false;
                    }
                    else
                    {
                        #region -- �擾���s --
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�i�� [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        // �Ώۍs�̃N���A
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // �i��
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // �i��
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // ���[�J�[�R�[�h
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // ���[�J�[����
                        //this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].CntFl = "";         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // �Z�b�g�K�i�E���L����
                        this._goodsDetailDataTable[cell.Row.Index].Division = "";       // �񋟋敪
                        this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // �ҏW�ۃt���O
                        this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // �ǉ��t���O

                        // �i�ԍX�V�敪�̏����ݒ�
                        this._setGoodNoUpdFlg = false;

                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region ��������
                    // �Ώۍs�̃N���A
                    this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // �i��
                    this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // �i��
                    this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // ���[�J�[�R�[�h
                    this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // ���[�J�[����
                    //this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
                    this._goodsDetailDataTable[cell.Row.Index].CntFl = "";         // QTY
                    this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // �Z�b�g�K�i�E���L����
                    this._goodsDetailDataTable[cell.Row.Index].Division = "";       // �񋟋敪
                    this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // �ҏW�ۃt���O
                    this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // �ǉ��t���O
                    #endregion
                }

            }
            // 2009.02.06 30413 ���� QTY�̃t�H�[�}�b�g >>>>>>START
            else if (cell.Column.Key == this._goodsDetailDataTable.CntFlColumn.ColumnName)
            {
                double cntFl = 0.0;
                if ((!double.TryParse(cell.Text, out cntFl)) || (cntFl == 0.0))
                {
                    if (cell.Text != "")
                    {
                        this._goodsDetailDataTable[cell.Row.Index].CntFl = "0";    
                    }
                }
                else
                {
                    this._goodsDetailDataTable[cell.Row.Index].CntFl = cntFl.ToString("##0.00");
                    
                }
            }
            // 2009.02.06 30413 ���� QTY�̃t�H�[�}�b�g <<<<<<END
            #endregion
        }

        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                this._childGoodsNo = cell.Value.ToString();
            }
        }

        //---- ADD gaocheng 2015/05/08 for Redmine#45798 �E�B���h�E���L�����ۂɃZ�b�g�}�X�^�̉�ʂ����l�ɍL���炸�̏C�� ---->>>>>
        /// <summary>
        /// ��ʂ̉�����ύX�C�x�b�g
        /// </summary>
        /// <param name="width">��ʂ̉���</param>
        /// <param name="height">��ʂ̍���</param> 
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̉�����ύX�C�x�b�g���s���B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/05/08</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E���L�����ۂɃZ�b�g�}�X�^�̉�ʂ����l�ɍL���炸�̏C��</br>    
        /// </remarks>     
        public void SettingGridWidth(int width, int height)
        {
            this.Width = width;
            this.pnl_uGrid.Width = width;
            this.uGrid_Details.Width = width;

            this.Height = height;
            this.pnl_uGrid.Height = height;
            this.uGrid_Details.Height = height;

            this.pnl_uGrid.Dock = DockStyle.Fill;
            this.uGrid_Details.Dock = DockStyle.Fill;
            this.uGrid_Details.Refresh();
        }
        //---- ADD gaocheng 2015/05/08 for Redmine#45798 �E�B���h�E���L�����ۂɃZ�b�g�}�X�^�̉�ʂ����l�ɍL���炸�̏C�� ----<<<<<

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
        # region [�O���b�h�J������� �ۑ��E����]
        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�������̕ۑ����s���B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>    
        /// </remarks> 
        public void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�J�������̓ǂݍ��݂��s���B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>    
        /// </remarks>  
        public void LoadGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // �J�����ݒ����\�����Ń\�[�g����
            settingList.Sort(new ColumnInfoComparer());

            // ��x�A�S�ẴJ������Fixed����������
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // ����ъ�����A�܂Ƃ߂�Fixed��ݒ肷��B
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }
        # endregion

        #region ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        /// <summary>
        /// �Z�b�g�}�X�^�p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>   
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// �Z�b�g�}�X�^�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>   
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<SetMstUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

                }
                catch
                {
                    this._userSetting = new SetMstUserConst();
                }
            }
        }

        #endregion // ���[�U�[�ݒ�̕ۑ��E�ǂݍ���
        //---- ADD gaocheng 2015/05/08 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<
    }

    # region [SetMstUserConst]
    /// <summary>
    /// �Z�b�g�}�X�^�p���[�U�[�ݒ�N���X
    /// </summary>
    [Serializable]
    public class SetMstUserConst
    {

        # region �v���C�x�[�g�ϐ�

        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// �Z�b�g�}�X�^���[�U�[�ݒ���N���X
        /// </summary>
        public SetMstUserConst()
        {

        }

        # endregion // �R���X�g���N�^

        # region �v���p�e�B
        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        # endregion

        /// <summary>
        /// �Z�b�g�}�X�^���[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>�Z�b�g�}�X�^���[�U�[�ݒ���N���X</returns>
        public SetMstUserConst Clone()
        {
            SetMstUserConst constObj = new SetMstUserConst();
            return constObj;
        }
    }
    #endregion

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>��</summary>
        private string _columnName;
        /// <summary>���я�</summary>
        private int _visiblePosition;
        /// <summary>��\���t���O</summary>
        private bool _hidden;
        /// <summary>��</summary>
        private int _width;
        /// <summary>�Œ�t���O</summary>
        private bool _columnFixed;
        /// <summary>
        /// ��
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// ���я�
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// ��\���t���O
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// �Œ�t���O
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="visiblePosition">���я�</param>
        /// <param name="hidden">��\���t���O</param>
        /// <param name="width">��</param>
        /// <param name="columnFixed">�Œ�t���O</param>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }

    /// <summary>
    /// ColumnInfo��r�N���X�i�\�[�g�p�j
    /// </summary>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo��r����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ColumnInfo x, ColumnInfo y)
        {
            // ��\�����Ŕ�r
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            // ��\��������v����ꍇ�͗񖼂Ŕ�r(�ʏ�͔������Ȃ�)
            if (result == 0)
            {
                result = x.ColumnName.CompareTo(y.ColumnName);
            }
            return result;
        }
    }
    # endregion
    //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<
}
