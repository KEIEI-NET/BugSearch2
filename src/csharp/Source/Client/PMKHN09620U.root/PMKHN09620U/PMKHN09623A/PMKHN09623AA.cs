//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10701342-00 �쐬�S�� : ������
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/07  �C�����e : Redmine#22810 ���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/14  �C�����e : Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/14  �C�����e : Redmine#23004 �L�����y�[���Ώۏ��i�ݒ�}�X�^�̓��t�͈̓`�F�b�N�G���[�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/22  �C�����e : Redmine#23119 �@�D�ǐݒ�}�X�^��ݒ��ɍŐV���擾�����s���Ă��A�Ď擾����Ȃ�������肠��܂��̑Ή�
//                                                �A�������̕\�����Ԃ����̂o�f�Ɣ�r���Ēx���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����g
// �C �� ��  2011/08/12  �C�����e : Redmine#23556 ���������[�h�͕��ׂď������āA���Ԃ���������悤�ɏC������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/04/12  �C�����e : �����D��ݒ�̎擾���@�ύX�i���x���ǁj
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���@�F��
// �C �� ��  2013/01/18  �C�����e : 2013/03/13�z�M�@SCM��Q��10475�Ή� ���x���P
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���@�F��
// �C �� ��  2013/02/13  �C�����e : 2013/03/06�z�M�@SCM��Q��10478�Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��
// �C �� ��  2014/03/20  �C�����e : Redmine#42174 �X�V��Column�ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/08  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή�
//                                : 02.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i�񓚔��莞�j
//                                : 03.�ύX�O�P���v�Z�ďo�񐔉��ǑΉ�
//                                : 04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ�
//                                : 05.���Ӑ�}�X�^�i�`�[�Ǘ��j�擾���ǑΉ�
//                                : 06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j
//                                : 07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j
//                                : 08.����f�[�^�������̃V�X�e�����t�擾�Ή�
//                                : 09.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i����f�[�^�������j
//                                : 10.�P���v�Z�ďo�񐔉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �C �� ��  2015/02/12  �C�����e : �V�X�e���e�X�g��Q�Ή� RedMine#145
//                                  �����D��ݒ�̓K�p�����������ǉ��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Diagnostics;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^ �A�N�Z�X�N���X</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 ���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�</br>
    /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
    /// <br>UpdateNote : 2011/07/15 ������ Redmine#23004 �L�����y�[���Ώۏ��i�ݒ�}�X�^�̓��t�͈̓`�F�b�N�G���[�Ή�</br>
    /// <br>UpdateNote : 2011/07/22 杍^ Redmine#23119 �@�D�ǐݒ�}�X�^��ݒ��ɍŐV���擾�����s���Ă��A�Ď擾����Ȃ�������肠��܂��̑Ή�</br>
    /// <br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�A�������̕\�����Ԃ����̂o�f�Ɣ�r���Ēx���̑Ή�</br>
    /// </remarks>
    public class CampaignObjGoodsStAcs
    {
        #region Private Member
        private static CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;

        private CampaignMngDataSet _dataSet;
        private CampaignMngDataSet.CampaignMngDataTable _campaignMngDataTable;
        private Dictionary<Guid, CampaignObjGoodsSt> _prevCampaignMngDic = new Dictionary<Guid, CampaignObjGoodsSt>();
        private ICampaignObjGoodsStDB _iCampaignObjGoodsStDB = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>�������ʏ�</summary>
        private string _statusOfResult = string.Empty;
        /// <summary>�L�����y�[���������A�����z�擾�����Ŏg�p���ꂽ�L�����y�[���֘A�ݒ�f�[�^</summary>
        private ArrayList _usedCampaignLinkList = null;
        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private ArrayList _campaignPrcPrStList = null;
        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs = null;                     // ���_���A�N�Z�X�N���X

        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>PMKHN09062A)BL�O���[�v</summary>
        private BLGroupUAcs _blGroupUAcs;
        /// <summary>SFCMN09062A)���[�U�[�K�C�h</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>PMKHN09012A)���Ӑ�</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>MAKHN04112A)BL�R�[�h�E�i�Ԍ���</summary>
        private GoodsAcs _goodsAcs;

        private CampaignStAcs _campaignStAcs = null;
        private CampaignLinkAcs _campaignLinkAcs = null;
        private CampaignPrcPrStAcs _campaignPrcPrStAcs = null;

        private IWin32Window _owner = null;

        private Dictionary<int, MakerUMnt> _makerUMntDic = new Dictionary<int, MakerUMnt>();    // ���[�J�[�}�X�^�f�B�N�V���i���[
        private Dictionary<string, SecInfoSet> _secInfoSetDic = new Dictionary<string, SecInfoSet>();// ���_���f�B�N�V���i���[

        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();    // BL�R�[�h�}�X�^�f�B�N�V���i���[
        private Dictionary<int, BLGroupU> _blGroupDic = new Dictionary<int, BLGroupU>();    // BL�O���[�v�}�X�^�f�B�N�V���i���[
        private Dictionary<int, UserGdBd> _userGdBdDic = new Dictionary<int, UserGdBd>();    // ���[�U�[�K�C�h�f�B�N�V���i���[
        private Dictionary<int, CustomerInfo> _customerDic = new Dictionary<int, CustomerInfo>();    // ���Ӑ�f�B�N�V���i���[

        private Dictionary<int, CampaignSt> _campaignStDic = new Dictionary<int, CampaignSt>();
        private List<CampaignLink> _campaignLinkList = new List<CampaignLink>();
        private List<CampaignObjGoodsSt> _campaignMngList = new List<CampaignObjGoodsSt>();

        // �L�����y�[���Ώۏ��i�ݒ�f�[�^���X�g
        private List<CampaignObjGoodsSt> _campaignObjGoodsStList = null;

        //true:�폜�w��敪=1�Afalse:�폜�w��敪=0
        private bool _deleteSearchMode = false;

        /// <summary>// true:���[�J���Q�� false:�T�[�o�[�Q��</summary>
        public static readonly bool ctIsLocalDBRead = false;

        private CampaignObjGoodsSt _newCampaignObj = new CampaignObjGoodsSt(); // �V�K�s�̏ꍇ�p // ADD 2011/07/14

        private Thread _masterAcsThread;   // �}�X�^�f�[�^�擾�X���b�h  // ADD Redmine#23556 2011/08/12
        private Thread _goodsAcsThread;   // ���i�f�[�^�擾�X���b�h     // ADD Redmine#23556 2011/08/12

        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        CampaignPrcPrSt campaignPrcPrSt = null;
        bool first = true;
        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

        #region �v���p�e�B
        // ------------- ADD Redmine#23556 2011/08/12 --------------->>>>>
        /// <summary>
        /// �}�X�^�f�[�^�擾�X���b�h�v���p�e�B
        /// </summary>
        public Thread MasterAcsThread
        {
            get { return this._masterAcsThread; }
        }
        /// <summary>
        /// ���i�f�[�^�擾�X���b�h�v���p�e�B
        /// </summary>
        public Thread GoodsAcsThread
        {
            get { return this._goodsAcsThread; }
        }
        // ------------- ADD Redmine#23556 2011/08/12 ---------------<<<<<
        /// <summary>
        /// �O���b�h�e�[�u���v���p�e�B
        /// </summary>
        public CampaignMngDataSet.CampaignMngDataTable CampaignMngDataTable
        {
            get { return this._campaignMngDataTable; }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<Guid, CampaignObjGoodsSt> PrevCampaignMngDic
        {
            get { return this._prevCampaignMngDic; }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, MakerUMnt> MakerUMntDic
        {
            get { return this._makerUMntDic; }
        }

        /// <summary>
        /// �a�k�R�[�h�}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, BLGoodsCdUMnt> BLGoodsCdDic
        {
            get { return this._blGoodsCdDic; }
        }

        /// <summary>
        /// �a�k�O���v�}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, BLGroupU> BLGroupDic
        {
            get { return this._blGroupDic; }
        }

        /// <summary>
        /// �̔��敪�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, UserGdBd> UserGdBdDic
        {
            get { return this._userGdBdDic; }
        }

        /// <summary>
        /// �폜�w��敪�v���p�e�B
        /// </summary>
        public bool DeleteSearchMode
        {
            get { return this._deleteSearchMode; }
        }

        /// <summary>
        /// ���_���}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<string, SecInfoSet> SecInfoSetDic
        {
            get { return this._secInfoSetDic; }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, CustomerInfo> CustomerDic
        {
            get { return this._customerDic; }
        }

        /// <summary>
        /// �L�����y�[���ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, CampaignSt> CampaignStDic
        {
            get { return this._campaignStDic; }
        }

        /// <summary>
        /// �L�����y�[���֘A�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public List<CampaignLink> CampaignLinkList
        {
            get { return this._campaignLinkList; }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public List<CampaignObjGoodsSt> CampaignMngList
        {
            get { return this._campaignMngList; }
        }

        /// <summary>
        /// ���i�A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public GoodsAcs GoodsAcsClass
        {
            get { return this._goodsAcs; }
        }

        /// <summary>
        /// �������ʏ󋵂��擾���܂��B<br/>
        /// (GetRatePriceOfCampaignMng()���ďo�����ɕω����܂�)
        /// </summary>
        public string StatusOfResult
        {
            get { return _statusOfResult; }
        }

        /// <summary>
        /// �L�����y�[���������A�����z�擾�����Ŏg�p���ꂽ�L�����y�[���֘A�ݒ�f�[�^���擾���܂��B<br/>
        /// �i�L�����y�[���ݒ�.CampaignObjDiv == 1 �Ń����[�g�A�N�Z�X���܂��j
        /// </summary>
        public ArrayList UsedCampaignLinkList
        {
            get { return _usedCampaignLinkList; }
        }

        // ---ADD 2011/07/14--------------->>>>>
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�v���p�e�B�A�V�K�s�̏ꍇ�p
        /// </summary>
        public CampaignObjGoodsSt NewCampaignObj
        {
            get { return _newCampaignObj; }
            set { _newCampaignObj = value; }
        }
        // ---ADD 2011/07/14---------------<<<<<
        #endregion

        #region �����̑��⏕���\�b�h
        /// <summary>
        /// ��r�֐�
        /// </summary>
        /// <typeparam name="T">�^�w��</typeparam>
        /// <param name="condition">����</param>
        /// <param name="valueOnTrue">True�̎��̒l</param>
        /// <param name="valueOnFalse">False�̎��̒l</param>
        /// <returns>�����ɂ��I�����ꂽ�l</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^ �A�N�Z�X�N���X</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        static public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }
        #endregion

        # region Constroctors
        /// <summary>
        /// ���͖��ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͖��ד��̓R���g���[���N���X �f�t�H���g���s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public CampaignObjGoodsStAcs()
        {
            this._dataSet = new CampaignMngDataSet();
            this._campaignMngDataTable = this._dataSet.CampaignMng;
            this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._campaignStAcs = new CampaignStAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._iCampaignObjGoodsStDB = (ICampaignObjGoodsStDB)MediationCampaignObjGoodsStDB.GetCampaignObjGoodsStDB();

            // ---------- DEL Redmine#23556 2011/08/12 ------------------->>>>>
            //#region �����i�A�N�Z�X�N���X��������(�L���b�V���Ȃ�)
            //string retMessage;
            //this._goodsAcs = new GoodsAcs();
            //this._goodsAcs.IsLocalDBRead = false;
            //this._goodsAcs.Owner = this._owner;
            //this._goodsAcs.IsGetSupplier = true;
            //this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);
            //#endregion
            // ---------- DEL Redmine#23556 2011/08/12 -------------------<<<<<
        }
        #endregion

        #region Public Method
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public static CampaignObjGoodsStAcs GetInstance()
        {
            if (_campaignObjGoodsStAcs == null)
            {
                _campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            }

            return _campaignObjGoodsStAcs;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="searchCondition">���������N���X</param>
        /// <param name="count">count</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(SearchCondition searchCondition, out int count, out string msg)
        {
            int status = 0;
            count = 0;
            msg = string.Empty;
            ArrayList campaignMngList = null;
            SearchConditionWork searchConditionWork  = this.CopyToSearchConditionWorkFromSearchCondition(searchCondition);

            try
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    status = this.SearchPrc(out campaignMngList, searchConditionWork, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
                }
                else
                {
                    status = this.SearchPrc(out campaignMngList, searchConditionWork, ConstantManagement.LogicalMode.GetData1, out count, ref msg);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    this._deleteSearchMode = false;
                }
                else
                {
                    this._deleteSearchMode = true;
                }

                if (campaignMngList != null && campaignMngList.Count > 0)
                {
                    this.SettingDetailRowAfterSearch(campaignMngList);
                }
            }
            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retArray">����߰ݑΏۏ��i�ݒ�Ͻ��f�[�^</param>
        /// <param name="searchConditionWork">���������N���X</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="count">count</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SearchPrc(out ArrayList retArray, SearchConditionWork searchConditionWork, ConstantManagement.LogicalMode logicalMode, out int count, ref string msg)
        {
            int status = 0;
            count = 0;
            try
            {
                ArrayList campaignMngList = null;
                object retObj = campaignMngList as object;

                object paraObj = searchConditionWork as object;
                status = this._iCampaignObjGoodsStDB.Search(out retObj, paraObj, 0, logicalMode, out count, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retArray">����߰ݑΏۏ��i�ݒ�Ͻ��f�[�^</param>
        /// <param name="campaignObjGoodsSt">���������N���X</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Read(out ArrayList retArray, CampaignObjGoodsSt campaignObjGoodsSt, ref string msg)
        {
            int status = 0;
            try
            {
                ArrayList campaignMngList = null;
                object retObj = campaignMngList as object;

                CampaignObjGoodsStWork campaignObjGoodsStWork  = this.CopyToCampaignMngWorkFromCampaignMng(campaignObjGoodsSt);
                object paraObj = campaignObjGoodsStWork as object;

                status = this._iCampaignObjGoodsStDB.Read(out retObj, paraObj, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���׃f�[�^�e�[�u���̏����ݒ���s���܂��B
        /// </summary>
        /// <param name="defaultRowCount">�����s��</param>
        /// <remarks>
        /// <br>Note       : ���׃f�[�^�e�[�u���̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// </remarks>
        public void DetailRowInitialSetting(int defaultRowCount)
        {
            this.CampaignMngDataTable.BeginLoadData();
            this.CampaignMngDataTable.Clear();
            this._deleteSearchMode = false;

            for (int i = 1; i <= defaultRowCount; i++)
            {
                CampaignMngDataSet.CampaignMngRow row = this.CampaignMngDataTable.NewCampaignMngRow();
                row.RowNo = i;
                row.FilterGuid = Guid.Empty;
                row.GoodsName = "";
                row.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                this.CampaignMngDataTable.AddCampaignMngRow(row);
            }
            this.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref this._newCampaignObj); // ADD 2011/07/14
            this.CampaignMngDataTable.EndLoadData();
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <param name="updateList">�o�^�E�X�V���X�g</param>
        /// <param name="campaignObjGoodsSt">�G���[�I�u�W�F�N�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SaveProc(List<CampaignObjGoodsSt> deleteList, List<CampaignObjGoodsSt> updateList, out CampaignObjGoodsSt campaignObjGoodsSt)
        {
            int status = 0;
            campaignObjGoodsSt = null;
            ArrayList delList = new ArrayList();
            ArrayList UpdList = new ArrayList();
            CampaignObjGoodsStWork campaignObjGoodsStWork = null;
            foreach (CampaignObjGoodsSt campaignMng in deleteList)
            {
                campaignObjGoodsStWork = this.CopyToCampaignMngWorkFromCampaignMng(campaignMng);
                delList.Add(campaignObjGoodsStWork);
            }
            foreach (CampaignObjGoodsSt campaignMng in updateList)
            {
                campaignObjGoodsStWork = this.CopyToCampaignMngWorkFromCampaignMng(campaignMng);
                UpdList.Add(campaignObjGoodsStWork);
            }

            object paraDelObj = delList as object;
            object paraUpdObj = UpdList as object;
            if (this._deleteSearchMode == false)
            {
                object errorObj = null;
                status = this._iCampaignObjGoodsStDB.DeleteAndWrite(paraDelObj, ref paraUpdObj, out errorObj);
                if (errorObj != null)
                {
                    CampaignObjGoodsStWork errorWork = errorObj as CampaignObjGoodsStWork;
                    campaignObjGoodsSt = this.CopyToCampaignMngFromCampaignMngWork(errorWork);
                }
            }
            else
            {
                status = this._iCampaignObjGoodsStDB.DeleteAndRevival(paraDelObj, ref paraUpdObj);
            }

            return status;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ����������A���׍s�ǉ�����
        /// </summary>
        /// <param name="retList">0:�o�^�E�X�V�A1:���S�폜�ƕ���</param>
        /// <remarks>
        /// <br>Note       : ����������A���׍s�ǉ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SettingDetailRowAfterSearch(ArrayList retList)
        {
            this.CampaignMngDataTable.BeginLoadData();
            this._campaignMngDataTable.Clear();
            CampaignObjGoodsSt campaignObjGoodsSt = null;

            // �o�^�ύs�̒ǉ�
            for (int i = 1; i <= retList.Count; i++)
            {
                campaignObjGoodsSt = this.CopyToCampaignMngFromCampaignMngWork((CampaignObjGoodsStWork)retList[i - 1]);
                CampaignMngDataSet.CampaignMngRow row = this._campaignMngDataTable.NewCampaignMngRow();
                row.RowNo = i;
                this.CopyToDetailRowFromCampaignMng(ref row, campaignObjGoodsSt);

                this._campaignMngDataTable.AddCampaignMngRow(row);
                this._prevCampaignMngDic.Add(row.FilterGuid, campaignObjGoodsSt);
            }

            if (this._deleteSearchMode == false)
            {
                // �V�K�s�̒ǉ�
                CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                newRow.RowNo = retList.Count + 1;
                newRow.FilterGuid = Guid.Empty;
                newRow.GoodsName = "";
                newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                this._campaignMngDataTable.AddCampaignMngRow(newRow);
            }

            this.CampaignMngDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׍s�[���L�����y�[���Ώۏ��i�ݒ�}�X�^
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="campaignMng">�L�����y�[���Ώۏ��i�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���׍s�[���L�����y�[���Ώۏ��i�ݒ�}�X�^</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote  : 2011/07/07 杍^ Redmine#22810 ���ׁh���[�J�[���́h����h�J�i���́h�ɕύX�̑Ή�</br>
        /// <br>UpdateNote  : 2011/07/22 杍^ Redmine#23119 �������̕\�����Ԃ����̂o�f�Ɣ�r���Ēx���̑Ή�</br>
        /// </remarks>
        private void CopyToDetailRowFromCampaignMng(ref CampaignMngDataSet.CampaignMngRow row, CampaignObjGoodsSt campaignMng)
        {
            row.UpdateTime = campaignMng.UpdateDateTime.Date.ToString("yy/MM/dd"); //�폜��
            // ADD �� 2014/03/20 ---------------------------------------->>>>>
            row.UpdateTime2 = campaignMng.UpdateDateTime.Date.ToString("yyyy/MM/dd");
            // ADD �� 2014/03/20 ----------------------------------------<<<<<
            row.FilterGuid = Guid.NewGuid();
            row.SectionCode = campaignMng.SectionCode.Trim().PadLeft(2, '0'); //���_

            row.SalesPriceSetDiv = campaignMng.SalesPriceSetDiv; // �����敪
            if (campaignMng.SalesPriceSetDiv == 1)
            {
                row.CustomerCode = campaignMng.CustomerCode.ToString().PadLeft(8, '0'); //���Ӑ�
                row.DiscountRate = campaignMng.DiscountRate; //�l����
                row.PriceFl = campaignMng.PriceFl; //�����z
                row.RateVal = campaignMng.RateVal; //������
                row.PriceStartDate = campaignMng.PriceStartDate; //���i�J�n��
                row.PriceEndDate = campaignMng.PriceEndDate; //���i�I����
            }
            else
            {
                row.CustomerCode = string.Empty;
                row.DiscountRate = 0;
                row.PriceFl = 0;
                row.RateVal = 0;
                row.PriceStartDate = 0;
                row.PriceEndDate = 0;
            }

            row.CampaignSettingKind = campaignMng.CampaignSettingKind; //�ݒ���
            if (campaignMng.CampaignSettingKind == 6)
            {
                // �̔��敪
                row.SalesCode = campaignMng.SalesCode.ToString().PadLeft(4, '0');

                row.GoodsMakerCode = 0;
                row.GoodsMakerName = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGoodsCode = 0;
                row.GoodsName = string.Empty;
                row.BLGroupCode = 0;
            }

            if (campaignMng.CampaignSettingKind == 5)
            {
                // BL����
                row.BLGoodsCode = campaignMng.BLGoodsCode;
                // �i��
                BLGoodsCdUMnt bLGoodsCdUMnt = null;
                if (this.BLGoodsCdDic.ContainsKey(campaignMng.BLGoodsCode))
                {
                    bLGoodsCdUMnt = this.BLGoodsCdDic[campaignMng.BLGoodsCode];
                }
                if (bLGoodsCdUMnt != null)
                {
                    row.GoodsName = bLGoodsCdUMnt.BLGoodsHalfName;
                }
                else
                {
                    row.GoodsName = string.Empty;
                }


                row.SalesCode = string.Empty;
                row.GoodsMakerCode = 0;
                row.GoodsMakerName = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGroupCode = 0;
            }

            if (campaignMng.CampaignSettingKind == 4)
            {
                // Ұ��
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // Ұ����
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName;  // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName;  // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }


                row.SalesCode = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGoodsCode = 0;
                row.GoodsName = string.Empty;
                row.BLGroupCode = 0;
            }

            if (campaignMng.CampaignSettingKind == 3)
            {
                // Ұ��
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // Ұ����
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName; // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName; // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }
                // ��ٰ��
                row.BLGroupCode = campaignMng.BLGroupCode;


                row.SalesCode = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGoodsCode = 0;
                row.GoodsName = string.Empty;
            }

            if (campaignMng.CampaignSettingKind == 2)
            {
                // Ұ��
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // Ұ����
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName;  // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName;  // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }

                // BL����
                row.BLGoodsCode = campaignMng.BLGoodsCode;
                // �i��
                BLGoodsCdUMnt bLGoodsCdUMnt = null;
                if (this.BLGoodsCdDic.ContainsKey(campaignMng.BLGoodsCode))
                {
                    bLGoodsCdUMnt = this.BLGoodsCdDic[campaignMng.BLGoodsCode];
                }
                if (bLGoodsCdUMnt != null)
                {
                    row.GoodsName = bLGoodsCdUMnt.BLGoodsHalfName;
                }
                else
                {
                    row.GoodsName = string.Empty;
                }


                row.SalesCode = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGroupCode = 0; 
            }

            if (campaignMng.CampaignSettingKind == 1)
            {
                // Ұ��
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // Ұ����
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName;  // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName;    // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }

                // �i��
                row.GoodsNo = campaignMng.GoodsNo;
                // �i��
                if (campaignMng.GoodsNameKana.Trim() == string.Empty)
                {
                    if (campaignMng.GoodsNo.Trim() != string.Empty)
                    {
                        List<GoodsUnitData> goodsDate;
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = this._enterpriseCode;
                        if (campaignMng.GoodsMakerCd != 0)
                        {
                            cndtn.GoodsMakerCd = campaignMng.GoodsMakerCd;
                        }
                        cndtn.GoodsNo = campaignMng.GoodsNo.Trim();
                        cndtn.GoodsKindCode = 9;
                        // --- UPD 2011/07/22 ----->>>>>
                        cndtn.IsSettingSupplier = 1;
                        PartsInfoDataSet partsInfoDataSet;
                        string msg = string.Empty;
                        //if (this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsDate, out msg) == 0)
                        if (this._goodsAcs.SearchPartsOfNonGoodsNo(cndtn, out partsInfoDataSet, out goodsDate, out msg) == 0)
                        // --- UPD 2011/07/22 -----<<<<<
                        {
                            if (goodsDate.Count > 0)
                            {
                                row.GoodsName = goodsDate[0].GoodsNameKana;
                            }
                        }
                        else
                        {
                            row.GoodsName = string.Empty;
                        }
                    }
                    else
                    {
                        row.GoodsName = string.Empty;
                    }
                }
                else
                {
                    row.GoodsName = campaignMng.GoodsNameKana;
                }


                row.SalesCode = string.Empty;
                row.BLGoodsCode = 0;
                row.BLGroupCode = 0;
            }

            row.CampaignCode = campaignMng.CampaignCode; //����
            if (this.CampaignStDic.ContainsKey(campaignMng.CampaignCode)) //����
            {
                CampaignSt campaignSt = this.CampaignStDic[campaignMng.CampaignCode];
                row.CampaignName = campaignSt.CampaignName;
            }
            else
            {
                row.CampaignName = string.Empty;
            }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�[�����׍s
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="campaignMng">�L�����y�[���Ώۏ��i�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�[�����׍s</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// <br>UpdateNote : 2011/07/15 ������ Redmine#23004 �L�����y�[���Ώۏ��i�ݒ�}�X�^�̓��t�͈̓`�F�b�N�G���[�Ή�</br>
        /// </remarks>
        public void CopyToCampaignMngFromDetailRow(CampaignMngDataSet.CampaignMngRow row, ref CampaignObjGoodsSt campaignMng)
        {
            // ---ADD 2011/07/14-------------->>>>>
            if (campaignMng == null)
            {
                campaignMng = new CampaignObjGoodsSt();
            }
            // ---ADD 2011/07/14--------------<<<<<
            campaignMng.EnterpriseCode = this._enterpriseCode; // ADD 2011/07/15
            campaignMng.SectionCode = row.SectionCode.ToString().PadLeft(2, '0');
            campaignMng.BLGoodsCode = row.BLGoodsCode;
            campaignMng.GoodsMakerCd = row.GoodsMakerCode;
            campaignMng.GoodsNo = row.GoodsNo;
            campaignMng.CampaignCode = row.CampaignCode;
            campaignMng.PriceFl = row.PriceFl;
            campaignMng.RateVal = row.RateVal;
            campaignMng.BLGroupCode = row.BLGroupCode;
            if (row.SalesCode.Trim() == string.Empty)
            {
                campaignMng.SalesCode = 0;
            }
            else
            {
                campaignMng.SalesCode = Convert.ToInt32(row.SalesCode);
            }
            campaignMng.CampaignSettingKind = row.CampaignSettingKind;
            campaignMng.SalesPriceSetDiv = row.SalesPriceSetDiv;
            if (row.CustomerCode.Trim() == string.Empty)
            {
                campaignMng.CustomerCode = 0;
            }
            else
            {
                campaignMng.CustomerCode = Convert.ToInt32(row.CustomerCode);
            }
            campaignMng.DiscountRate= row.DiscountRate;
            campaignMng.PriceStartDate = row.PriceStartDate;
            campaignMng.PriceEndDate = row.PriceEndDate;

            campaignMng.RowIndex = row.RowNo;
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignMng1">�L�����y�[���Ώۏ��i�ݒ�}�X�^</param>
        /// <param name="campaignMng2">�L�����y�[���Ώۏ��i�ݒ�}�X�^</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public bool Compare(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            if (campaignMng1.PriceEndDate != campaignMng2.PriceEndDate
                || campaignMng1.PriceStartDate != campaignMng2.PriceStartDate
                || campaignMng1.CustomerCode != campaignMng2.CustomerCode
                || campaignMng1.DiscountRate != campaignMng2.DiscountRate
                || campaignMng1.SalesPriceSetDiv != campaignMng2.SalesPriceSetDiv
                || campaignMng1.SalesCode != campaignMng2.SalesCode
                || campaignMng1.BLGroupCode != campaignMng2.BLGroupCode
                || campaignMng1.RateVal != campaignMng2.RateVal
                || campaignMng1.PriceFl != campaignMng2.PriceFl
                || campaignMng1.GoodsNo.Trim() != campaignMng2.GoodsNo.Trim()
                || campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd
                || campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode
                || campaignMng1.SectionCode.Trim().PadLeft(2, '0') != campaignMng2.SectionCode.Trim().PadLeft(2, '0'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignMng1">�L�����y�[���Ώۏ��i�ݒ�}�X�^</param>
        /// <param name="campaignMng2">�L�����y�[���Ώۏ��i�ݒ�}�X�^</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��r����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public bool CompareKey(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            if (campaignMng1.PriceEndDate != campaignMng2.PriceEndDate
                || campaignMng1.PriceStartDate != campaignMng2.PriceStartDate
                || campaignMng1.CustomerCode != campaignMng2.CustomerCode
                || campaignMng1.SalesPriceSetDiv != campaignMng2.SalesPriceSetDiv
                || campaignMng1.SalesCode != campaignMng2.SalesCode
                || campaignMng1.BLGroupCode != campaignMng2.BLGroupCode
                || campaignMng1.GoodsNo.Trim() != campaignMng2.GoodsNo.Trim()
                || campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd
                || campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode
                || campaignMng1.SectionCode.Trim().PadLeft(2, '0') != campaignMng2.SectionCode.Trim().PadLeft(2, '0'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ���o������r����
        /// </summary>
        /// <param name="searchCondition1">���o����1</param>
        /// <param name="searchCondition2">���o����2</param>
        /// <returns>true:���Afalse:�s��</returns>
        /// <remarks>
        /// <br>Note       : ���o������r����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public bool CompareSearchCondition(SearchCondition searchCondition1, SearchCondition searchCondition2)
        {
            //�����������ύX�Ȃ��̏ꍇ�͌������Ȃ�
            if (searchCondition1.CampaignCode == searchCondition2.CampaignCode
                && searchCondition1.SectionCode.Trim().PadLeft(2, '0') == searchCondition2.SectionCode.Trim().PadLeft(2, '0')
                && searchCondition1.SalesCodeSt == searchCondition2.SalesCodeSt
                && searchCondition1.SalesCodeEd == searchCondition2.SalesCodeEd
                && searchCondition1.BLGoodsCodeSt == searchCondition2.BLGoodsCodeSt
                && searchCondition1.BLGoodsCodeEd == searchCondition2.BLGoodsCodeEd
                && searchCondition1.BLGroupCodeSt == searchCondition2.BLGroupCodeSt
                && searchCondition1.BLGroupCodeEd == searchCondition2.BLGroupCodeEd
                && searchCondition1.DeleteFlag == searchCondition2.DeleteFlag
                && searchCondition1.DiscountRate == searchCondition2.DiscountRate
                && searchCondition1.DiscountRateDiv == searchCondition2.DiscountRateDiv
                && searchCondition1.EnterpriseCode == searchCondition2.EnterpriseCode
                && searchCondition1.GoodsMakerCdSt == searchCondition2.GoodsMakerCdSt
                && searchCondition1.GoodsMakerCdEd == searchCondition2.GoodsMakerCdEd
                && searchCondition1.GoodsNo.Trim() == searchCondition2.GoodsNo.Trim()
                && searchCondition1.PriceFl == searchCondition2.PriceFl
                && searchCondition1.PriceFlDiv == searchCondition2.PriceFlDiv
                && searchCondition1.RateVal == searchCondition2.RateVal
                && searchCondition1.RateValDiv == searchCondition2.RateValDiv)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �V�K�s�̔��f����
        /// </summary>
        /// <param name="row">�V�K�s</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : �V�K�s�̔��f����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22984 �ŏI�s�̏�񂪃f�[�^�o�^����Ȃ�</br>
        /// </remarks>
        public bool IsRowUpdate(CampaignMngDataSet.CampaignMngRow row)
        {
            // ---UPD 2011/07/14--------------->>>>>
            //if (row.CampaignCode != 0
            //    || row.SectionCode != "00"
            //    || row.CampaignSettingKind != 1
            //    || row.GoodsMakerCode != 0
            //    || row.GoodsNo != string.Empty
            //    || row.BLGoodsCode != 0
            //    || row.BLGroupCode != 0
            //    || row.SalesCode.Trim() != string.Empty
            //    || row.SalesPriceSetDiv != 0
            //    || row.CustomerCode.Trim() != string.Empty
            //    || row.DiscountRate != 0
            //    || row.RateVal != 0
            //    || row.PriceFl != 0
            //    || row.PriceStartDate != 0
            //    || row.PriceEndDate != 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            if (row.CampaignCode != this._newCampaignObj.CampaignCode
                || row.SectionCode.PadLeft(2, '0') != this._newCampaignObj.SectionCode.ToString().PadLeft(2, '0')
                || row.CampaignSettingKind != this._newCampaignObj.CampaignSettingKind
                || row.GoodsMakerCode != this._newCampaignObj.GoodsMakerCd
                || row.GoodsNo.Trim() != this._newCampaignObj.GoodsNo.Trim()
                || row.BLGoodsCode != this._newCampaignObj.BLGoodsCode
                || row.BLGroupCode != this._newCampaignObj.BLGroupCode
                || row.SalesCode.Trim().PadLeft(4, '0') != this._newCampaignObj.SalesCode.ToString().PadLeft(4, '0')
                || row.SalesPriceSetDiv != this._newCampaignObj.SalesPriceSetDiv
                || row.CustomerCode.Trim().PadLeft(8, '0') != this._newCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                || row.DiscountRate != this._newCampaignObj.DiscountRate
                || row.RateVal != this._newCampaignObj.RateVal
                || row.PriceFl != this._newCampaignObj.PriceFl
                || row.PriceStartDate != this._newCampaignObj.PriceStartDate
                || row.PriceEndDate != this._newCampaignObj.PriceEndDate)
            {
                return true;
            }
            else
            {
                return false;
            }
            // ---UPD 2011/07/14---------------<<<<<
        }

        /// <summary>
        /// �}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/22 杍^ Redmine#23119 �D�ǐݒ�}�X�^��ݒ��ɍŐV���擾�����s���Ă��A�Ď擾����Ȃ�������肠��܂��̑Ή�</br>
        /// </remarks>
        public void LoadMstData()
        {
            // ---------------- UPD Redmine#23556 2011/08/12 --------------------->>>>>
            //this.LoadMakerUMnt();

            //this.LoadBlCodeMst();

            //this.LoadBlGroupMst();

            //this.CacheUserGd();

            //this.ReadSecInfoSet();
            
            //this.GetCustomerDic();
            
            //this.LoadCampaignSt();

            //this.LoadCampaignLink();

            //// --- ADD 2011/07/22 ---- >>>>>>>>>
            //#region �����i�A�N�Z�X�N���X��������(�L���b�V���Ȃ�)
            //string retMessage;
            //this._goodsAcs = new GoodsAcs();
            //this._goodsAcs.IsLocalDBRead = false;
            //this._goodsAcs.Owner = this._owner;
            //this._goodsAcs.IsGetSupplier = true;
            //this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);
            //#endregion
            //// --- ADD 2011/07/22 ---- <<<<<<<<<

            this._masterAcsThread = new Thread(new ThreadStart(MasterThreadProc));   // �}�X�^�f�[�^�擾�X���b�h
            this._goodsAcsThread = new Thread(new ThreadStart(GoodsThreadProc));   // ���i�f�[�^�擾�X���b�h
            this._goodsAcsThread.Start();
            this._masterAcsThread.Start();
            // ---------------- UPD Redmine#23556 2011/08/12 ---------------------<<<<<
        }

        // ---------------- ADD Redmine#23556 2011/08/12 --------------------->>>>>
        /// <summary>
        /// �}�X�^�f�[�^�擾�X���b�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^�f�[�^�擾�X���b�h</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        public void MasterThreadProc()
        {
            this.LoadMakerUMnt();//���[�J�[�}�X�^�̓ǂݍ���

            this.LoadBlCodeMst();//BL�}�X�^�̓ǂݍ���

            this.LoadBlGroupMst();//BL�O���[�v�}�X�^�̓ǂݍ���

            this.CacheUserGd();//���[�U�[�K�C�h�}�X�^�̓ǂݍ���

            this.ReadSecInfoSet();//���_�}�X�^�̓ǂݍ���

            this.GetCustomerDic();//���Ӑ�}�X�^�̓ǂݍ���

            this.LoadCampaignSt();//�L�����y�[���Ǘ��}�X�^�̓ǂݍ���

            this.LoadCampaignLink();//�L�����y�[���֘A�}�X�^�̓ǂݍ���
        }

        /// <summary>
        /// ���i�f�[�^�擾�X���b�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�擾�X���b�h</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        public void GoodsThreadProc()
        {
            // ���i�A�N�Z�X�N���X��������(�L���b�V���Ȃ�)
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);
        }
        // ---------------- ADD Redmine#23556 2011/08/12 ---------------------<<<<<

        /// <summary>
        /// BlCode�}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BlCode�}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadBlCodeMst()
        {
            this._blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = _blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._blGoodsCdDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                    }
                }
            }
            catch
            {

                this._blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// Bl�O���[�v�}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : Bl�O���[�v�}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadBlGroupMst()
        {
            this._blGroupDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._blGroupDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                    }
                }
            }
            catch
            {

                this._blGroupDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// UserGd�}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : UserGd�}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void CacheUserGd()
        {
            this._userGdBdDic = new Dictionary<int, UserGdBd>();

            try
            {
                ArrayList userGdBdList;

                int status = this._userGuideAcs.SearchDivCodeBody(out userGdBdList, this._enterpriseCode, 71, UserGuideAcsData.UserBodyData);

                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in userGdBdList)
                    {
                        if (userGdBd.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._userGdBdDic.Add(userGdBd.GuideCode, userGdBd);
                    }
                }
            }
            catch
            {
                this._userGdBdDic = new Dictionary<int, UserGdBd>();
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^�Ǎ�����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet);
                }
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ǎ�����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void GetCustomerDic()
        {
            this._customerDic = new Dictionary<int, CustomerInfo>();

            try
            {
                List<CustomerInfo> customerInfoList;

                int status = this._customerInfoAcs.Search(this._enterpriseCode, false, false, out customerInfoList);

                if (status == 0)
                {
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        if (customerInfo.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._customerDic.Add(customerInfo.CustomerCode, customerInfo);
                    }
                }
            }
            catch
            {
                this._customerDic = new Dictionary<int, CustomerInfo>();
            }
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void LoadCampaignSt()
        {
            this._campaignStDic = new Dictionary<int, CampaignSt>();

            try
            {
                ArrayList retList;

                int status = this._campaignStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (CampaignSt campaignSt in retList)
                    {
                        this._campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                    }
                }
            }
            catch
            {
                this._campaignStDic = new Dictionary<int, CampaignSt>();
            }
        }

        /// <summary>
        /// �L�����y�[���֘A�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadCampaignLink()
        {
            this._campaignLinkList = new List<CampaignLink>();

            try
            {
                ArrayList retList;

                int status = this._campaignLinkAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (CampaignLink campaignLink in retList)
                    {
                        this._campaignLinkList.Add(campaignLink);
                    }
                }
            }
            catch
            {
                this._campaignLinkList = new List<CampaignLink>();
            }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadCampaignMng()
        {
            this._campaignMngList = new List<CampaignObjGoodsSt>();

            try
            {
                ArrayList retList = new ArrayList();
                object retObj = retList as object;
                string msg = string.Empty;
                int status = this._iCampaignObjGoodsStDB.Search(out retObj, this._enterpriseCode, 0, ConstantManagement.LogicalMode.GetData01, ref msg);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    CampaignObjGoodsSt campaignObjGoodsSt;
                    foreach (CampaignObjGoodsStWork campaignObjGoodsStWork in retList)
                    {
                        campaignObjGoodsSt = CopyToCampaignMngFromCampaignMngWork(campaignObjGoodsStWork);
                        this._campaignMngList.Add(campaignObjGoodsSt);
                    }
                }
            }
            catch
            {
                this._campaignMngList = new List<CampaignObjGoodsSt>();
            }
        }

        /// <summary>
        /// SearchCondition->SearchConditionWork
        /// </summary>
        /// <param name="searchCondition">��������</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : SearchCondition->SearchConditionWork</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private SearchConditionWork CopyToSearchConditionWorkFromSearchCondition(SearchCondition searchCondition)
        {
            SearchConditionWork searchConditionWork = new SearchConditionWork();

            searchConditionWork.EnterpriseCode = searchCondition.EnterpriseCode;
            searchConditionWork.CampaignCode = searchCondition.CampaignCode;
            searchConditionWork.SectionCode = searchCondition.SectionCode;
            searchConditionWork.GoodsMakerCdSt = searchCondition.GoodsMakerCdSt;
            searchConditionWork.GoodsMakerCdEd = searchCondition.GoodsMakerCdEd;
            searchConditionWork.BLGoodsCodeSt = searchCondition.BLGoodsCodeSt;
            searchConditionWork.BLGoodsCodeEd = searchCondition.BLGoodsCodeEd;
            searchConditionWork.BLGroupCodeSt = searchCondition.BLGroupCodeSt;
            searchConditionWork.BLGroupCodeEd = searchCondition.BLGroupCodeEd;
            searchConditionWork.SalesCodeSt = searchCondition.SalesCodeSt;
            searchConditionWork.SalesCodeEd = searchCondition.SalesCodeEd;
            searchConditionWork.GoodsNo = searchCondition.GoodsNo;
            searchConditionWork.DeleteFlag = searchCondition.DeleteFlag;
            searchConditionWork.DiscountRate = searchCondition.DiscountRate;
            searchConditionWork.DiscountRateDiv = searchCondition.DiscountRateDiv;
            searchConditionWork.RateVal = searchCondition.RateVal;
            searchConditionWork.RateValDiv = searchCondition.RateValDiv;
            searchConditionWork.PriceFl = searchCondition.PriceFl;
            searchConditionWork.PriceFlDiv = searchCondition.PriceFlDiv;

            return searchConditionWork;
        }

        /// <summary>
        /// CampaignMngWork->CampaignMng
        /// </summary>
        /// <param name="campaignObjGoodsStWork">�L�����y�[���Ώۏ��i�ݒ胏�[�N</param>
        /// <returns>�L�����y�[���Ώۏ��i�ݒ�</returns>
        /// <remarks>
        /// <br>Note       : CampaignMngWork->CampaignMng</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignObjGoodsSt CopyToCampaignMngFromCampaignMngWork(CampaignObjGoodsStWork campaignObjGoodsStWork)
        {
            CampaignObjGoodsSt campaignObjGoodsSt = new CampaignObjGoodsSt();

            campaignObjGoodsSt.CreateDateTime = campaignObjGoodsStWork.CreateDateTime;
            campaignObjGoodsSt.UpdateDateTime = campaignObjGoodsStWork.UpdateDateTime;
            campaignObjGoodsSt.EnterpriseCode = campaignObjGoodsStWork.EnterpriseCode;
            campaignObjGoodsSt.FileHeaderGuid = campaignObjGoodsStWork.FileHeaderGuid;
            campaignObjGoodsSt.UpdEmployeeCode = campaignObjGoodsStWork.UpdEmployeeCode;
            campaignObjGoodsSt.UpdAssemblyId1 = campaignObjGoodsStWork.UpdAssemblyId1;
            campaignObjGoodsSt.UpdAssemblyId2 = campaignObjGoodsStWork.UpdAssemblyId2;
            campaignObjGoodsSt.LogicalDeleteCode = campaignObjGoodsStWork.LogicalDeleteCode;
            campaignObjGoodsSt.SectionCode = campaignObjGoodsStWork.SectionCode;
            campaignObjGoodsSt.GoodsMGroup = campaignObjGoodsStWork.GoodsMGroup;
            campaignObjGoodsSt.BLGoodsCode = campaignObjGoodsStWork.BLGoodsCode;
            campaignObjGoodsSt.GoodsMakerCd = campaignObjGoodsStWork.GoodsMakerCd;
            campaignObjGoodsSt.GoodsNo = campaignObjGoodsStWork.GoodsNo;
            campaignObjGoodsSt.SalesTargetMoney = campaignObjGoodsStWork.SalesTargetMoney;
            campaignObjGoodsSt.SalesTargetProfit = campaignObjGoodsStWork.SalesTargetProfit;
            campaignObjGoodsSt.SalesTargetCount = campaignObjGoodsStWork.SalesTargetCount;
            campaignObjGoodsSt.CampaignCode = campaignObjGoodsStWork.CampaignCode;
            campaignObjGoodsSt.PriceFl = campaignObjGoodsStWork.PriceFl;
            campaignObjGoodsSt.RateVal = campaignObjGoodsStWork.RateVal;
            campaignObjGoodsSt.BLGroupCode = campaignObjGoodsStWork.BLGroupCode;
            campaignObjGoodsSt.SalesCode = campaignObjGoodsStWork.SalesCode;
            campaignObjGoodsSt.CampaignSettingKind = campaignObjGoodsStWork.CampaignSettingKind;
            campaignObjGoodsSt.SalesPriceSetDiv = campaignObjGoodsStWork.SalesPriceSetDiv;
            campaignObjGoodsSt.CustomerCode = campaignObjGoodsStWork.CustomerCode;
            campaignObjGoodsSt.PriceStartDate = campaignObjGoodsStWork.PriceStartDate;
            campaignObjGoodsSt.PriceEndDate = campaignObjGoodsStWork.PriceEndDate;
            campaignObjGoodsSt.DiscountRate = campaignObjGoodsStWork.DiscountRate;
            campaignObjGoodsSt.GoodsNameKana = campaignObjGoodsStWork.GoodsNameKana;
            campaignObjGoodsSt.RowIndex = campaignObjGoodsStWork.RowIndex;

            return campaignObjGoodsSt;
        }

        /// <summary>
        /// CampaignMng->CampaignMngWork
        /// </summary>
        /// <param name="campaignObjGoodsSt">�L�����y�[���Ώۏ��i�ݒ�</param>
        /// <returns>�L�����y�[���Ώۏ��i�ݒ胏�[�N</returns>
        /// <remarks>
        /// <br>Note       : CampaignMng->CampaignMngWork</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignObjGoodsStWork CopyToCampaignMngWorkFromCampaignMng(CampaignObjGoodsSt campaignObjGoodsSt)
        {
            CampaignObjGoodsStWork campaignObjGoodsStWork = new CampaignObjGoodsStWork();

            campaignObjGoodsStWork.CreateDateTime = campaignObjGoodsSt.CreateDateTime;
            campaignObjGoodsStWork.UpdateDateTime = campaignObjGoodsSt.UpdateDateTime;
            campaignObjGoodsStWork.EnterpriseCode = campaignObjGoodsSt.EnterpriseCode;
            campaignObjGoodsStWork.FileHeaderGuid = campaignObjGoodsSt.FileHeaderGuid;
            campaignObjGoodsStWork.UpdEmployeeCode = campaignObjGoodsSt.UpdEmployeeCode;
            campaignObjGoodsStWork.UpdAssemblyId1 = campaignObjGoodsSt.UpdAssemblyId1;
            campaignObjGoodsStWork.UpdAssemblyId2 = campaignObjGoodsSt.UpdAssemblyId2;
            campaignObjGoodsStWork.LogicalDeleteCode = campaignObjGoodsSt.LogicalDeleteCode;
            campaignObjGoodsStWork.SectionCode = campaignObjGoodsSt.SectionCode;
            campaignObjGoodsStWork.GoodsMGroup = campaignObjGoodsSt.GoodsMGroup;
            campaignObjGoodsStWork.BLGoodsCode = campaignObjGoodsSt.BLGoodsCode;
            campaignObjGoodsStWork.GoodsMakerCd = campaignObjGoodsSt.GoodsMakerCd;
            campaignObjGoodsStWork.GoodsNo = campaignObjGoodsSt.GoodsNo;
            campaignObjGoodsStWork.SalesTargetMoney = campaignObjGoodsSt.SalesTargetMoney;
            campaignObjGoodsStWork.SalesTargetProfit = campaignObjGoodsSt.SalesTargetProfit;
            campaignObjGoodsStWork.SalesTargetCount = campaignObjGoodsSt.SalesTargetCount;
            campaignObjGoodsStWork.CampaignCode = campaignObjGoodsSt.CampaignCode;
            campaignObjGoodsStWork.PriceFl = campaignObjGoodsSt.PriceFl;
            campaignObjGoodsStWork.RateVal = campaignObjGoodsSt.RateVal;
            campaignObjGoodsStWork.BLGroupCode = campaignObjGoodsSt.BLGroupCode;
            campaignObjGoodsStWork.SalesCode = campaignObjGoodsSt.SalesCode;
            campaignObjGoodsStWork.CampaignSettingKind = campaignObjGoodsSt.CampaignSettingKind;
            campaignObjGoodsStWork.SalesPriceSetDiv = campaignObjGoodsSt.SalesPriceSetDiv;
            campaignObjGoodsStWork.CustomerCode = campaignObjGoodsSt.CustomerCode;
            campaignObjGoodsStWork.PriceStartDate = campaignObjGoodsSt.PriceStartDate;
            campaignObjGoodsStWork.PriceEndDate = campaignObjGoodsSt.PriceEndDate;
            campaignObjGoodsStWork.DiscountRate = campaignObjGoodsSt.DiscountRate;
            campaignObjGoodsStWork.RowIndex = campaignObjGoodsSt.RowIndex;

            return campaignObjGoodsStWork;
        }

        #region �L�����y�[���������A�����z�擾����
        /// <summary>
        /// �L�����y�[���������A�����z�擾����
        /// </summary>
        /// <param name="campaignObjGoodsSt">���o���ʃL�����y�[���Ώۏ��i�ݒ�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="blGroupCode">�O���[�v�R�[�h</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="salesCode">�̔��敪</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="applyDate">�K�p��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���������A�����z�擾�̎擾���s���܂��B
        ///                  ���o��������L�����y�[���������A�����z�擾�������ݒ肳��Ă���L�����y�[���Ώۏ��i�ݒ�f�[�^��Ԃ��܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int GetRatePriceOfCampaignMng(out CampaignObjGoodsSt campaignObjGoodsSt, string enterpriseCode, string sectionCode, int customerCode,
                                             int goodsMakerCd, int blGroupCode, int blGoodsCode, int salesCode, string goodsNo, DateTime applyDate)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            CampaignObjGoodsSt readCampaignObjGoodsSt = new CampaignObjGoodsSt();
            // �K�p��
            int applyDateTime = 0;
            int.TryParse(applyDate.Date.ToString("yyyyMMdd"), out applyDateTime);

            // �������L�����y�[�������D��ݒ�}�X�^�����擾

            // UPD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //CampaignPrcPrSt campaignPrcPrSt = null;
            //this.GetCampaignPrcPrSt(out campaignPrcPrSt, enterpriseCode, sectionCode);
            if (first)
            {
                this.GetCampaignPrcPrSt(out campaignPrcPrSt, enterpriseCode, sectionCode);
                first = false;
            }
            // UPD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            if (this._campaignObjGoodsStList == null)
            {
                List<CampaignObjGoodsSt> retList = null;
                // �L�����y�[���Ώۏ��i�ݒ�}�X�^�̑S����
                status = this.Search(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ� -------------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        // �Y���f�[�^�Ȃ��̎�
                        this._campaignObjGoodsStList = new List<CampaignObjGoodsSt>();
                    }
                    // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ� --------------------------------------<<<<<

                    // �S�����Ŏ��s
                    readCampaignObjGoodsSt = null;
                    campaignObjGoodsSt = null;

                    _statusOfResult = "�L�����y�[���Ώۏ��i�ݒ�}�X�^�̑S�����Ŏ��s";

                    return status;
                }

                //�L�����y�[���Ώۏ��i�ݒ�f�[�^�̃L���b�V����
                this._campaignObjGoodsStList = new List<CampaignObjGoodsSt>();

                foreach (CampaignObjGoodsSt campaignObjGoods in retList)
                {
                    if (campaignObjGoods.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    this._campaignObjGoodsStList.Add(campaignObjGoods);
                }
            }
            // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ� -------------------------------------->>>>>
            else if (this._campaignObjGoodsStList != null && this._campaignObjGoodsStList.Count == 0)
            {
                readCampaignObjGoodsSt = null;
                campaignObjGoodsSt = null;
                _statusOfResult = "�Y���f�[�^�Ȃ�";
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
           }
           // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ� --------------------------------------<<<<<


            // �L�����y�[���Ώۏ��i�ݒ�}�X�^�e�[�u���Ώ۔���
            List<CampaignObjGoodsSt> campaignList = new List<CampaignObjGoodsSt>();
            if (campaignPrcPrSt != null)
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (campaignList.Count > 0)
                    {
                        break;
                    }

                    switch (i)
                    {
                        case 1:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd1 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd1)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd1)
                                            {
                                                //1�FҰ��+�i��
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2�FҰ��+BL����
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3�FҰ��+��ٰ��
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4�FҰ��
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5�FBL����
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6�F�̔��敪
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd2 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd2)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd2)
                                            {
                                                //1�FҰ��+�i��
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2�FҰ��+BL����
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3�FҰ��+��ٰ��
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4�FҰ��
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5�FBL����
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6�F�̔��敪
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd3 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd3)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd3)
                                            {
                                                //1�FҰ��+�i��
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2�FҰ��+BL����
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3�FҰ��+��ٰ��
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4�FҰ��
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5�FBL����
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6�F�̔��敪
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd4 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd4)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd4)
                                            {
                                                //1�FҰ��+�i��
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2�FҰ��+BL����
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3�FҰ��+��ٰ��
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4�FҰ��
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5�FBL����
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6�F�̔��敪
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd5 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd5)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd5)
                                            {
                                                //1�FҰ��+�i��
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2�FҰ��+BL����
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3�FҰ��+��ٰ��
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4�FҰ��
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5�FBL����
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6�F�̔��敪
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd6 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd6)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd6)
                                            {
                                                //1�FҰ��+�i��
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2�FҰ��+BL����
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3�FҰ��+��ٰ��
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4�FҰ��
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5�FBL����
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6�F�̔��敪
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            // ���ݒ莞�͐ݒ��ʋ敪�̏����Ƃ���
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (campaignList.Count > 0)
                    {
                        break;
                    }

                    switch (i)
                    {
                        case 1:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //1�FҰ��+�i��
                                    if (campaignObjGoods.CampaignSettingKind == 1)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //2�FҰ��+BL����
                                    if (campaignObjGoods.CampaignSettingKind == 2)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //3�FҰ��+��ٰ��
                                    if (campaignObjGoods.CampaignSettingKind == 3)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //4�FҰ��
                                    if (campaignObjGoods.CampaignSettingKind == 4)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //5�FBL����
                                    if (campaignObjGoods.CampaignSettingKind == 5)
                                    {
                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //6�F�̔��敪
                                    if (campaignObjGoods.CampaignSettingKind == 6)
                                    {
                                        if (campaignObjGoods.SalesCode == salesCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }

            if (campaignList.Count > 0)
            {
                if (campaignList.Count == 1)
                {
                    readCampaignObjGoodsSt = campaignList[0];
                }
                else
                {
                    bool getFlg1 = false;
                    bool getFlg2 = false;
                    bool getFlg3 = false;
                    foreach (CampaignObjGoodsSt campaignObjGoods in campaignList)
                    {
                        if (campaignObjGoods.SectionCode.Trim() == sectionCode.Trim()
                            && campaignObjGoods.CustomerCode == customerCode)
                        {
                            readCampaignObjGoodsSt = campaignObjGoods;
                            getFlg1 = true;
                            break;
                        }
                        // ���_�R�[�h�A���Ӑ�R�[�h����v���Ȃ��ꍇ�u���_�F00�A���Ӑ�F00000000�v��ΏۂƂ���
                        if (!getFlg1)
                        {
                            if (campaignObjGoods.SectionCode.Trim() == sectionCode.Trim()
                                && campaignObjGoods.CustomerCode == 0)
                            {
                                readCampaignObjGoodsSt = campaignObjGoods;
                                getFlg2 = true;
                            }
                            if (!getFlg2)
                            {
                                if (campaignObjGoods.SectionCode.Trim() == "00"
                                    && campaignObjGoods.CustomerCode == customerCode)
                                {
                                    readCampaignObjGoodsSt = campaignObjGoods;
                                    getFlg3 = true;
                                }
                                if (!getFlg3)
                                {
                                    if (campaignObjGoods.SectionCode.Trim() == "00"
                                        && campaignObjGoods.CustomerCode == 0)
                                    {
                                        readCampaignObjGoodsSt = campaignObjGoods;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (readCampaignObjGoodsSt != null)
            {
                if (this._campaignStDic == null || this._campaignStDic.Count == 0)
                {
                    this.LoadCampaignSt();
                }

                if (this._campaignStDic.ContainsKey(readCampaignObjGoodsSt.CampaignCode))
                {
                    CampaignSt campaignSt = this._campaignStDic[readCampaignObjGoodsSt.CampaignCode];
                    if (campaignSt.LogicalDeleteCode == 0)
                    {
                        // �K�p�����͈͓���
                        if ((campaignSt.ApplyStaDate > applyDate) ||
                            (campaignSt.ApplyEndDate < applyDate))
                        {
                            // �K�p�J�n���O�A�܂��͓K�p�I������̏ꍇ�͏����I��
                            readCampaignObjGoodsSt = null;
                            campaignObjGoodsSt = null;

                            _statusOfResult = "�K�p�����͈͊O";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }

                        if (campaignSt.CampaignObjDiv == 0)
                        {
                            // �L�����y�[���Ώۋ敪�F"�S���Ӑ�" //�Ȃ��B
                        }
                        else if (campaignSt.CampaignObjDiv == 1)
                        {
                            // �L�����y�[���Ώۋ敪�F"�Ώۓ��Ӑ�"
                            ArrayList retList;
                            CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                            status = campaignLinkAcs.SearchDetail(out retList, enterpriseCode, campaignSt.CampaignCode);

                            // �����p�ɕێ�
                            _usedCampaignLinkList = retList;

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �Y������L�����y�[���֘A�}�X�^�������̂ŏ����I��
                                readCampaignObjGoodsSt = null;
                                campaignObjGoodsSt = null;

                                _statusOfResult = "�Y������L�����y�[���֘A�}�X�^������";

                                return status;
                            }
                            else if ((retList == null) || (retList.Count == 0))
                            {
                                // �������ʂ�0���̏ꍇ�������I��
                                readCampaignObjGoodsSt = null;
                                campaignObjGoodsSt = null;

                                _statusOfResult = "�L�����y�[���֘A�}�X�^�̌������ʂ�0��";

                                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }

                            bool searchFlg = false;
                            foreach (CampaignLink campaignLink in retList)
                            {
                                if (campaignLink.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }

                                if (campaignLink.CustomerCode == customerCode)
                                {
                                    // �L�����y�[���֘A�̓��Ӑ�ƈ�v
                                    searchFlg = true;
                                    break;
                                }
                            }

                            if (!searchFlg)
                            {
                                // �L�����y�[���֘A�ɊY�����Ӑ悪�����̂ŏ����I��
                                readCampaignObjGoodsSt = null;
                                campaignObjGoodsSt = null;

                                _statusOfResult = "�L�����y�[���֘A�ɊY�����Ӑ悪����";

                                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                        else
                        {
                            // �L�����y�[���Ώۋ敪�F"���~"
                            readCampaignObjGoodsSt = null;
                            campaignObjGoodsSt = null;

                            _statusOfResult = "�L�����y�[���Ώۋ敪�F�u���~�v";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                    else
                    {
                        // �Y������L�����y�[���R�[�h�������̂ŏ����I��
                        readCampaignObjGoodsSt = null;
                        campaignObjGoodsSt = null;

                        _statusOfResult = "�Y������L�����y�[���R�[�h������";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // �Y������L�����y�[���R�[�h�������̂ŏ����I��
                    readCampaignObjGoodsSt = null;
                    campaignObjGoodsSt = null;

                    _statusOfResult = "�Y������L�����y�[���R�[�h������";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }

            // �L�����y�[���Ώ�
            if (readCampaignObjGoodsSt != null)
            {
                campaignObjGoodsSt = readCampaignObjGoodsSt.Clone();
            }
            else
            {
                campaignObjGoodsSt = null;
            }

            if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == sectionCode.Trim().PadLeft(2, '0'))
            {
                _statusOfResult = "�L�����y�[���Ώۏ��i�ݒ�������ł��܂����B";
            }
            else
            {
                _statusOfResult = "�S�Аݒ�ōČ���";
            }

            return 0;
        }

        /// <summary>
        /// �������L�����y�[�������D��ݒ�}�X�^�����擾�B
        /// </summary>
        /// <param name="campaignPrcPrSt">�����D��ݒ�}�X�^���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �������L�����y�[�������D��ݒ�}�X�^�����擾�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void GetCampaignPrcPrSt(out CampaignPrcPrSt campaignPrcPrSt, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (this._campaignPrcPrStAcs == null)
            {
                this._campaignPrcPrStAcs = new CampaignPrcPrStAcs();
            }

            int sectionCd = 0;
            int.TryParse(sectionCode, out sectionCd);
            //2012/04/12 T.Nishi UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //status = this._campaignPrcPrStAcs.Read(out campaignPrcPrSt, enterpriseCode, sectionCode);
            CampaignPrcPrSt campaignPrcPrStRead = new CampaignPrcPrSt();
            if (_campaignPrcPrStList == null)
            {
                status = this._campaignPrcPrStAcs.SearchAll(out _campaignPrcPrStList, enterpriseCode);
            }
            foreach (CampaignPrcPrSt campaignPrcPr in this._campaignPrcPrStList)
            {
                // --- ADD 2015/02/12 Y.Wakita Redmine#145 ---------->>>>>
                if (campaignPrcPr.LogicalDeleteCode != 0) continue;
                // --- ADD 2015/02/12 Y.Wakita Redmine#145 ----------<<<<<

                // UPD 2013/02/13 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��10478 �L�����y�[����Q --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // if (campaignPrcPr.SectionCode.Trim() == sectionCode)
                if (campaignPrcPr.SectionCode.Trim() == sectionCode.Trim())
                // UPD 2013/02/13 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��10478 �L�����y�[����Q ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                    break;
                }
                if (campaignPrcPr.SectionCode.Trim() == "00")
                {
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                }

            }

            campaignPrcPrSt = campaignPrcPrStRead;
            //2012/04/12 T.Nishi UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.LogicalDeleteCode != 0)
                    {
                        status = -1;
                    }
                }
            }

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.PrioritySettingCd1 == 0
                        && campaignPrcPrSt.PrioritySettingCd2 == 0
                        && campaignPrcPrSt.PrioritySettingCd3 == 0
                        && campaignPrcPrSt.PrioritySettingCd4 == 0
                        && campaignPrcPrSt.PrioritySettingCd5 == 0
                        && campaignPrcPrSt.PrioritySettingCd6 == 0)
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
            else
            {
                if (sectionCd != 0)
                {
                    // �����̋��_�Ɉ�v���郌�R�[�h�����݂��Ȃ��ꍇ�́A00�S�Ѓ��R�[�h���g�p����B
                    campaignPrcPrSt = null;
                    status = this._campaignPrcPrStAcs.Read(out campaignPrcPrSt, enterpriseCode, "00");
                    if (status == 0)
                    {
                        if (campaignPrcPrSt != null)
                        {
                            if (campaignPrcPrSt.LogicalDeleteCode != 0)
                            {
                                campaignPrcPrSt = null;
                                return;
                            }

                            if (campaignPrcPrSt.PrioritySettingCd1 == 0
                                && campaignPrcPrSt.PrioritySettingCd2 == 0
                                && campaignPrcPrSt.PrioritySettingCd3 == 0
                                && campaignPrcPrSt.PrioritySettingCd4 == 0
                                && campaignPrcPrSt.PrioritySettingCd5 == 0
                                && campaignPrcPrSt.PrioritySettingCd6 == 0)
                            {
                                campaignPrcPrSt = null;
                            }
                        }
                        else
                        {
                            campaignPrcPrSt = null;
                        }
                    }
                    else
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�L�����y�[���Ώۏ��i�ݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="retList">�L�����y�[���Ώۏ��i�ݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="enterpriseCode">enterpriseCode</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(out List<CampaignObjGoodsSt> retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            // ����
            ArrayList retWorkList;
            int status = this.SearchProc(out retWorkList, enterpriseCode, logicalMode);

            // ���ʊi�[
            retList = new List<CampaignObjGoodsSt>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null)
            {
                foreach (object obj in retWorkList)
                {
                    if (obj is CampaignObjGoodsStWork)
                    {
                        CampaignObjGoodsStWork retWork = (obj as CampaignObjGoodsStWork);

                        // �l���Z�b�g
                        CampaignObjGoodsSt campaignObjGoodsSt = CopyToCampaignMngFromCampaignMngWork(retWork);
                        retList.Add(campaignObjGoodsSt);
                    }
                }
            }

            if (retList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retWorkList">�Ǎ����ʃe�[�u��</param>
        /// <param name="enterpriseCode">enterpriseCode</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�̕��������������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchProc(out ArrayList retWorkList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;
            string msg = string.Empty;

            try
            {
                //ArrayList paraList = new ArrayList();
                //==========================================
                // �L�����y�[���Ώۏ��i�ݒ�}�X�^�ǂݍ���
                //==========================================

                // �����[�g�߂胊�X�g
                object campaignMngWorkList = null;
                // �L�����y�[���Ώۏ��i�ݒ�}�X�^����
                status = this._iCampaignObjGoodsStDB.Search(out campaignMngWorkList, enterpriseCode, 0, logicalMode, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)campaignMngWorkList;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return status;
        }


        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�e�[�u���Ώ۔���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�e�[�u���Ώ۔���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void DetermineDate(ref List<CampaignObjGoodsSt> campaignList, CampaignObjGoodsSt campaignObjGoodsSt, string sectionCode, string enterpriseCode, int applyDateTime, int customerCode)
        {
            if (campaignObjGoodsSt.EnterpriseCode.Trim() == enterpriseCode.Trim()
                && campaignObjGoodsSt.SalesPriceSetDiv == 1
                && campaignObjGoodsSt.PriceStartDate <= applyDateTime
                && applyDateTime <= campaignObjGoodsSt.PriceEndDate)
            {
                if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') != sectionCode.Trim().PadLeft(2, '0')
                    || campaignObjGoodsSt.CustomerCode != customerCode)
                {
                    if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == "00"
                        && campaignObjGoodsSt.CustomerCode == customerCode)
                    {
                        campaignList.Add(campaignObjGoodsSt);
                    }
                    else if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == sectionCode.Trim().PadLeft(2, '0')
                         && campaignObjGoodsSt.CustomerCode == 0)
                    {
                        campaignList.Add(campaignObjGoodsSt);
                    }
                    else if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == "00"
                        && campaignObjGoodsSt.CustomerCode == 0)
                    {
                        campaignList.Add(campaignObjGoodsSt);
                    }
                }
                else
                {
                    campaignList.Add(campaignObjGoodsSt);
                }
            }
        }
        #endregion

        #endregion
    }
}
