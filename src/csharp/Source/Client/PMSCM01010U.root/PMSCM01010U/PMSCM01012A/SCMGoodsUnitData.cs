//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/15  �C�����e : �@�񓚔[���ŁA�ݒ莞�Ԕ͈͊O�̏ꍇ�͋󔒂�Ԃ�
//                                 �A���㖾�׃f�[�^�̉񓚔[�����Z�b�g����Ȃ��s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/10  �C�����e : PCCUOE�����񓚑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/19  �C�����e : Redmine #25216
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liusy
// �� �� ��  2011/09/26  �C�����e : Redmine#25492�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/10/08  �C�����e : Redmine#25764�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/10/11  �C�����e : Redmine#25760�ARedmine#25765�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liusy
// �� �� ��  2011/10/11  �C�����e : Redmine#25754�ARedmine#25755�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liusy
// �� �� ��  2011/11/21  �C�����e : Redmine#8019�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10800003-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/01/04  �C�����e : SCM���ǑΉ�
//                                  1)�������ݒ�Ή�
//                                  2)�\�����ʐݒ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/03/28  �C�����e : SCM���ǑΉ�
//                                  1)�����񓚑��x���P
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����@����q
// �� �� ��  2012/04/23  �C�����e : ��Q��150 2012/02/23�z�M���ARedmine#28038�̑Ή�
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@SCM���ǁ^�C���R��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/05/28  �C�����e : ��Q��274 �݌Ɋm�F�ło�b�b�i�ڐݒ肪�����Ă������񓚂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30747 �O�ˁ@�L��
// �� �� ��  2012/06/18  �C�����e : ��Q��10289 �蓮�񓚎��A�W�����i�I����ʂőI�������W�����i���L���ɂȂ�Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/06/26  �C�����e : ��Q��274 �폜(2012/06/28�z�M���珜�O)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/06/29  �C�����e : ��Q��274 �݌Ɋm�F�ło�b�b�i�ڐݒ肪�����Ă������񓚂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/07/18  �C�����e : SCM��Q��173 PCC�D��ݒ�ŗD��q�ɐݒ莞�̕\����������ύX����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F���@30745
// �� �� ��  2012/08/30  �C�����e : 2012/10���z�M�\��SCM��Q��10345�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/09  �C�����e : SCM���Ǉ�10337,10338,10341,10364,10431�Ή� PCCforNS�ABLP�̎����񓚔��菈������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/27  �C�����e : 2012/12/12�z�M �V�X�e���e�X�g��Q��86�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/12/12  �C�����e : SCM���Ǉ�10423�Ή� PCCforNS�ABLP�̈ϑ��݌ɁE�Q�ƍ݌ɂ̔��菈������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/02/13  �C�����e : SCM��Q�ǉ��A�Ή��@2013/03/06�z�M
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2013/02/28  �C�����e : 2013/03/06�z�M�\�� �����[�X�O���؃T�|���Ǉ�92
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/03/07  �C�����e : SCM��Q��10489�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/09/13  �C�����e : SCM�d�|�ꗗ��10571�Ή��@PCC���Аݒ�}�X�^�̎Q�Ƒq�ɂ�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh
// �� �� ��  2013/02/27  �C�����e : �z�M���Ȃ��� Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/10/17  �C�����e : ���i�ۏ؉�Redmine#552�Ή� �Q�Ƒq�Ɏ擾��USB�I�v�V�����`�F�b�N�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/11/19  �C�����e : 201312xx�z�M�\�輽��ýď�Q��22�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/01/30  �C�����e : Redmine#41771 ��Q��13�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070147-00 �쐬�S�� : ���N�n��
// �C �� ��  2014/07/23  �C�����e : SCM�d�|�ꗗ��10659��3SCM�󔭒����׃f�[�^�ɍ݌ɏ󋵋敪�̃Z�b�g�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ����q
// �C �� ��  2014/09/19  �C�����e : SCM�Г���Q�ꗗ��44�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070221-00 �쐬�S�� : �e�c ���V
// �� �� ��  2014/11/05  �C�����e : SCM��Q��10535�Ή�
//                                : 2014/11/26�z�M�V�X�e���e�X�g��Q��6�Ή�
//                                : PM-SCM�Z�b�g���i���\���ŃL�����y�[�������f����Ȃ���Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F���@30745
// �� �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�� ���O�@31065
// �� �� ��  2015/02/18  �C�����e : SCM������ �V�X�e����Q��242�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170206-00 �쐬�S�� : �ړ�
// �� �� ��  2016/01/13  �C�����e : Redmine#47847 2016�N2���z�M��
//                                : �t�^�o�q�Ɉ����ăI�v�V�����I���F�����̂܂܂ōs���Ή�
//                                : �t�^�o�q�Ɉ����ăI�v�V�����I�t�FSCM�⍇�蓮�񓚎��A���㖾�׃f�[�^�̑q�ɂɓ��Ӑ�}�X�^�̗D��q�ɂƋ��_�ݒ�̑q�ɂP�`�R
//                                :                                 �ȊO�̑q�ɂ��\������Ă����Q�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Application.Remoting.ParamData; // ADD 2010/08/10
namespace Broadleaf.Application.Controller
{
    using CustomerServer            = SingletonInstance<CustomerAgent>;                 // ���Ӑ�}�X�^
    using SecInfoSetServer          = SingletonInstance<SecInfoSetAgent>;               // ���_�ݒ�}�X�^
    using DeliveryDateSettingServer = SingletonInstance<SCMDeliveryDateSettingAgent>;   // SCM�[���ݒ�}�X�^
    using SalesTtlStServer          = SingletonInstance<SalesTtlStAgent>;               // ����S�̐ݒ�}�X�^

    /// <summary>
    /// SCM�p�̏��t���i�A���f�[�^�̃w���p�N���X
    /// </summary>
    public class SCMGoodsUnitData
    {
        private const string MY_NAME = "SCMGoodsUnitData";  // ���O�p

        // ----- ADD 2011/08/10 ----- >>>>>
        // �󔭒����
        private int _acceptOrOrderKind;

        /// <summary>
        /// �󔭒���ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public int AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }

        #region <�Z�b�g�q���i��SCM�p�̏��t���i�A���f�[�^>
        /// <summary>�Z�b�g�q���i��SCM�p�̏��t���i�A���f�[�^</summary>
        private List<SCMGoodsUnitData> _setSCMGoodsUnitDataList;
        /// <summary>�Z�b�g�q���i��SCM�p�̏��t���i�A���f�[�^���擾���܂��B</summary>
        public List<SCMGoodsUnitData> SetSCMGoodsUnitDataList 
         {
            get
            {
                if (_setSCMGoodsUnitDataList == null)
                {
                    _setSCMGoodsUnitDataList = new List<SCMGoodsUnitData>();
                }
                return _setSCMGoodsUnitDataList;
            }
            set { _setSCMGoodsUnitDataList = value; }
        }
        #endregion

        // PCC���Аݒ�}�X�^
        private PccCmpnyStWork _pccCmpnySt;
        /// <summary>SCM�󒍃f�[�^�̊֘A�}�b�v���擾���܂��B</summary>
        public PccCmpnyStWork PccCmpnySt
        {
            get
            {
                if (_pccCmpnySt == null)
                {
                    _pccCmpnySt = new PccCmpnyStWork();
                }
                return _pccCmpnySt;
            }
            set
            {
                _pccCmpnySt = value;
            }
        }
        // ----- ADD 2011/08/10 ----- <<<<<

        #region <���i�A���f�[�^>

        /// <summary>�{���̏��i�A���f�[�^</summary>
        private readonly GoodsUnitData _realGoodsUnitData;
        /// <summary>�{���̏��i�A���f�[�^���擾���܂��B</summary>
        public GoodsUnitData RealGoodsUnitData { get { return _realGoodsUnitData; } }

        #endregion // </���i�A���f�[�^>

        #region <�������>

        /// <summary>�������</summary>
        private readonly SCMSearchedResult.GoodsSearchDivCd _searchedType;
        /// <summary>������ʂ��擾���܂��B</summary>
        public SCMSearchedResult.GoodsSearchDivCd SearchedType { get { return _searchedType; } }

        #endregion // </�������>

        #region <���ƂȂ���SCM�󒍃f�[�^>

        /// <summary>���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)</summary>
        private readonly ISCMOrderDetailRecord _sourceDetailRecord;
        /// <summary>���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)</summary>
        public ISCMOrderDetailRecord SourceDetailRecord { get { return _sourceDetailRecord; } }

        /// <summary>�蓮�񓚂̔���ɂĐ������ꂽ�����f����t���O</summary>
        private readonly bool _createdManually;
        /// <summary>�蓮�񓚂̔���ɂĐ������ꂽ�����f����t���O���擾���܂��B</summary>
        private bool CreatedManually { get { return _createdManually; } }

        #endregion // </���ƂȂ���SCM�󒍃f�[�^>

        #region <���Ӑ�>

        /// <summary>���Ӑ�R�[�h</summary>
        private readonly int _customerCode;
        /// <summary>���Ӑ�R�[�h���擾���܂��B</summary>
        public int CustomerCode { get { return _customerCode; } }

        /// <summary>���Ӑ�}�X�^���擾���܂��B</summary>
        private static CustomerAgent CustomerDB
        {
            get { return CustomerServer.Singleton.Instance; }
        }

        #endregion // </���Ӑ�>

        // --- Add 2011/08/06 duzg for Redmine#23307 --->>>
        #region <SCM�S�̐ݒ�}�X�^>
        /// <summary>SCM�S�̐ݒ�}�X�^�̃A�N�Z�T</summary>
        private SCMTtlStAgent _ttlStSettingDB;
        /// <summary>SCM�S�̐ݒ�}�X�^�̃A�N�Z�T���擾���܂��B</summary>
        protected SCMTtlStAgent TtlStSettingDB
        {
            get
            {
                if (_ttlStSettingDB == null)
                {
                    _ttlStSettingDB = new SCMTtlStAgent();
                }
                return _ttlStSettingDB;
            }
        }

        #endregion // </SCM�S�̐ݒ�}�X�^>
        // --- Add 2011/08/06 duzg for Redmine#23307 ---<<<

        #region <�����񓚉\�t���O>

        /// <summary>�����񓚉\�t���O</summary>
        private bool _canReplyAutomatically;
        /// <summary>
        /// �����񓚉\�t���O���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public bool CanReplyAutomatically
        {
            get { return _canReplyAutomatically; }
            set { _canReplyAutomatically = value; }
        }

        #endregion // </�����񓚉\�t���O>

        // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>

        #region �폜(SCM���ǂ̈�)
        //#region <SCM�i�ڐݒ�>

        ///// <summary>SCM�i�ڐݒ�</summary>
        //private SCMPrtSetting _scmItemConfig;
        ///// <summary>SCM�i�ڐݒ���擾�܂��͐ݒ肵�܂��B</summary>
        //public SCMPrtSetting SCMItemConfig
        //{
        //    get
        //    {
        //        if (_scmItemConfig == null)
        //        {
        //            _scmItemConfig = new SCMPrtSetting();
        //        }
        //        return _scmItemConfig;
        //    }
        //    set { _scmItemConfig = value; }
        //}

        ///// <summary>
        ///// ���i���񓚂ł��邩���f���܂��B
        ///// </summary>
        //private bool CanReplyPrice
        //{
        //    // UPD 2012/06/29 ���� No.274 ---------------------------------------------------->>>>>
        //    //>>>2012/06/26
        //    //// --- UPD �O�� 2012/05/28 ��274 ---------->>>>>
        //    ////get { return SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.Price); }
        //    //get { return !SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.DeliveryDate); }
        //    //// --- UPD �O�� 2012/05/28 ��274 ----------<<<<<

        //    //get { return SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.Price); }
        //    //<<<2012/06/26
        //    // �����񓚋敪���u�[���v�ȊO�̎��́u���i�v�ŉ񓚂���
        //    get { return !SCMItemConfig.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.DeliveryDate); }
        //    // UPD 2012/06/29 ���� No.274 ----------------------------------------------------<<<<<
        //}

        //#endregion // </SCM�i�ڐݒ�>
        #endregion

        #region <�����񓚕i�ڐݒ�>

        /// <summary>�����񓚕i�ڐݒ�</summary>
        private AutoAnsItemSt _autoAnsItemStConfig;
        /// <summary>�����񓚕i�ڐݒ���擾�܂��͐ݒ肵�܂��B</summary>
        public AutoAnsItemSt AutoAnsItemStConfig
        {
            get
            {
                if (_autoAnsItemStConfig == null)
                {
                    _autoAnsItemStConfig = new AutoAnsItemSt();
                }
                return _autoAnsItemStConfig;
            }
            set { _autoAnsItemStConfig = value; }
        }
        #endregion // </�����񓚕i�ڐݒ�>

        // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<

        #region <�P���Z�o����>

        /// <summary>�P���Z�o���ʂ̃��X�g</summary>
        private IList<UnitPriceCalcRet> _unitPriceCalcRetList;
        /// <summary>�P���Z�o���ʂ̃��X�g���擾�܂��͐ݒ肵�܂��B</summary>
        public IList<UnitPriceCalcRet> UnitPriceCalcRetList
        {
            get
            {
                if (_unitPriceCalcRetList == null)
                {
                    _unitPriceCalcRetList = new List<UnitPriceCalcRet>();
                }
                return _unitPriceCalcRetList;
            }
            set { _unitPriceCalcRetList = value; }
        }

        #endregion // </�P���Z�o����>

        #region <������>

        /// <summary>������̃��X�g</summary>
        private IList<SCMSobaResponseHelper> _scmSobaResponseList;
        /// <summary>������̃��X�g���擾�܂��͐ݒ肵�܂��B</summary>
        public IList<SCMSobaResponseHelper> SCMSobaResponseList
        {
            get
            {
                if (_scmSobaResponseList == null)
                {
                    _scmSobaResponseList = new List<SCMSobaResponseHelper>();
                }
                return _scmSobaResponseList;
            }
            set { _scmSobaResponseList = value; }
        }

        /// <summary>
        /// �������ǉ����܂��B
        /// </summary>
        /// <param name="sobaResponse">������</param>
        public void AddSobaResponse(SCMSobaResponseHelper sobaResponse)
        {
            SCMSobaResponseList.Add(sobaResponse);
        }

        /// <summary>
        /// ���ꉿ�i�������Ă��邩���f���܂��B
        /// </summary>
        /// <value>
        /// <c>true</c> :���ꉿ�i�������Ă��܂��B<br/>
        /// <c>false</c>:���ꉿ�i�������Ă��܂���B
        /// </value>
        public bool HasMarketPrice
        {
            get { return SCMSobaResponseList.Count > 0; }
        }

        #endregion // </������>

        #region <�L�����y�[�����>

        /// <summary>�L�����y�[�����</summary>
        private CampaignInformation _campaignInformation;
        /// <summary>�L�����y�[�������擾�܂��͐ݒ肵�܂��B</summary>
        public CampaignInformation CampaignInformation
        {
            get
            {
                if (_campaignInformation == null)
                {
                    _campaignInformation = new CampaignInformation();
                }
                return _campaignInformation;
            }
            set { _campaignInformation = value; }
        }

        #endregion // </�L�����y�[�����>

        #region <�����A�g�l�����>

        #endregion // </�����A�g�l�����>

        #region <����S�̐ݒ�>

        /// <summary>
        /// ����S�̐ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static SalesTtlStAgent SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }

        #endregion // </����S�̐ݒ�>

        //>>>2012/01/04
        #region �������
        /// <summary>�������[�J�[�R�[�h</summary>
        private int _pureGoodsMakerCd = 0;
        /// <summary>�������[�J�[�R�[�h</summary>
        public int PureGoodsMakerCd
        {
            get { return this._pureGoodsMakerCd; }
            set { this._pureGoodsMakerCd = value; }
        }
        /// <summary>�񓚏������i�ԍ�</summary>
        private string _ansPureGoodsNo = string.Empty;
        /// <summary>�񓚏������i�ԍ�</summary>
        public string AnsPureGoodsNo
        {
            get { return this._ansPureGoodsNo; }
            set { this._ansPureGoodsNo = value; }
        }
        #endregion

        #region �\������
        /// <summary>�񓚗p�\������</summary>
        private int _retDisplayOrder = 0;
        /// <summary>�񓚗p�\������</summary>
        public int RetDisplayOrder
        {
            get { return this._retDisplayOrder; }
            set { this._retDisplayOrder = value; }
        }
        #endregion
        //<<<2012/01/04

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGoodsUnitData">�{���̏��i�A���f�[�^</param>
        /// <param name="searchedType">�������</param>
        /// <param name="sourceDetailRecord">���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public SCMGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode
        ) : this(realGoodsUnitData, searchedType, sourceDetailRecord, customerCode, false)
        { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGoodsUnitData">�{���̏��i�A���f�[�^</param>
        /// <param name="searchedType">�������</param>
        /// <param name="sourceDetailRecord">���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="createdManually">�蓮�񓚂̔���ɂĐ������ꂽ�����f����t���O</param>
        public SCMGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode,
            bool createdManually
        )
        {
            _realGoodsUnitData  = realGoodsUnitData;
            _searchedType       = searchedType;
            _sourceDetailRecord = sourceDetailRecord;
            _customerCode       = customerCode;
            _createdManually    = createdManually;
        }

        #endregion // </Constructor>

        // ADD 2012/07/18 SCM��Q��173 --------------------------------------------->>>>>
        #region <�񋓌^>
        /// <summary>
        /// �D��q�ɏ��ʗ񋓌^
        /// </summary>
        public enum PriWareHouseOrder : int
        {
            /// <summary>�Ȃ�</summary>
            None = 0,
            /// <summary>�D��q�ɂP</summary>
            PriWareHouse1 = 1,
            /// <summary>�D��q�ɂQ</summary>
            PriWareHouse2 = 2,
            /// <summary>�D��q�ɂR</summary>
            // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PriWareHouse3 = 3
            PriWareHouse3 = 3,
            /// <summary>�D��q�ɂS</summary>
            PriWareHouse4 = 4
            // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
        }
        #endregion //</�񋓌^>
        // ADD 2012/07/18 SCM��Q��173 ---------------------------------------------<<<<<

        // ADD 2012/06/29 ���� No.274 ---------------------------------------------------->>>>>
        /// <summary>
        /// SCM�p�̏��t���i�A���f�[�^��������
        /// </summary>
        /// <returns>SCMGoodsUnitData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMGoodsUnitData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMGoodsUnitData Clone()
        {
            return new SCMGoodsUnitData(this._realGoodsUnitData, this._searchedType, this._sourceDetailRecord, this._customerCode, this._createdManually);
        }
        // ADD 2012/06/29 ���� No.274 ----------------------------------------------------<<<<<

        /// <summary>
        /// ����f�[�^���쐬�ł��邩���f���܂��B
        /// </summary>
        /// <remarks>
        /// ���`�p�Ɏ蓮�񓚂Ɣ��肳�ꂽ���׃f�[�^���󒍃f�[�^�̍쐬���K�v�B
        /// �������A�⍇���E������ʂ�"����"�ňϑ��݌ɈȊO�̂��̂�ΏۂƂ���
        /// </remarks>
        /// <returns>
        /// <c>true</c> :����f�[�^���쐬�ł��܂��B<br/>
        /// <c>false</c>:����f�[�^���쐬�ł��܂���B
        /// </returns>
        public bool CanMakeSalesData()
        {
            if (CreatedManually)
            {
                return SourceDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Ordering) && !IsTrustStock();
            }
            else
            {
                return true;
            }
        }

        #region <�\������>

        /// <summary>
        /// �\�����ʂ��擾���܂��B
        /// </summary>
        public int DisplayOrder
        {
            get { return RealGoodsUnitData.PrimePartsDisplayOrder; }
        }

        /// <summary>
        /// �����ł��邩���f���܂��B
        /// </summary>
        public bool IsPure()
        {
            return DisplayOrder.Equals(SCMSearchedResult.PURE_DISPLAY_ORDER);
        }

        #endregion // </�\������>

        #region <���i���>

        /// <summary>
        /// ���i��ʂ��擾���܂��B
        /// </summary>
        /// <param name="isAnswer">�񓚃t���O</param>
        /// <returns>
        /// �D��1<br/>
        /// ����񓚂����ꍇ�A3:���ϑ���<br/>
        /// ���T�C�N���񓚂����ꍇ�A2:���T�C�N�����i
        /// �D��2<br/>
        /// <c>GoodsUnitData.OfferKubun</c>�����i���<br/>
        /// 1:�񋟏����ҏW  ��0:����<br/>
        /// 2:�񋟗D�ǕҏW  ��1:�D��<br/>
        /// 3:�񋟏���      ��0:����<br/>
        /// 4:�񋟗D��      ��1:�D��<br/>
        /// 5:TBO           ��1:�D��<br/>
        /// 6:�I���W�i�����i��1:�D��<br/>
        /// </returns>
        public int GetGoodsDivCd(bool isAnswer)
        {
            if (isAnswer && HasMarketPrice)
            {
                return (int)GoodsDivCd.MarketPrice;
            }
            switch (SourceDetailRecord.GoodsDivCd)
            {
                case (int)GoodsDivCd.MarketPrice:   // ���ϑ���
                case (int)GoodsDivCd.Recycle:       // ���T�C�N�����i
                    return SourceDetailRecord.GoodsDivCd;

                default:
                    switch (RealGoodsUnitData.OfferKubun)
                    {
                        // ----- ADD 2011/10/11 ----- >>>>>
                        case 0: // ���[�U�[�o�^
                            {
                                // 0:����
                                if (RealGoodsUnitData.GoodsKindCode == 0)
                                {
                                    return (int)GoodsDivCd.Pure;
                                }
                                // 1:���̑�
                                else if (RealGoodsUnitData.GoodsKindCode == 1)
                                {
                                    return (int)GoodsDivCd.Prime;
                                }
                                return (int)GoodsDivCd.Prime;
                            }
                        // ----- ADD 2011/10/11 ----- <<<<<
                        case 1: // �񋟏����ҏW
                        case 3: // �񋟏���
                            return (int)GoodsDivCd.Pure;
                        
                        default:
                            return (int)GoodsDivCd.Prime;
                    }
            }
        }

        #endregion // </���i���>

        #region <���T�C�N�����i>

        /// <summary>
        /// ���T�C�N�����i��ʂ��擾���܂��B
        /// </summary>
        /// <param name="isAnswer">�񓚃t���O</param>
        /// <returns>���T�C�N�����i���</returns>
        public int GetRecyclePrtKindCode(bool isAnswer)
        {
            if (HasMarketPrice)
            {
                // ����񓚂̏ꍇ�A���T�C�N�����i��ʂ𒼐ڕԂ�
                return SCMSobaResponseList[0].MarketPriceKindCd;
            }
            if (GetGoodsDivCd(isAnswer).Equals((int)GoodsDivCd.Recycle))
            {
                if (SCMSobaResponseList.Count > 0)
                {
                    switch (SCMSobaResponseList[0].MarketPriceKindCd)
                    {
                        case (int)MarketPriceKindCd.Used:
                            return (int)RecyclePrtKindCode.Used;
                        case (int)MarketPriceKindCd.Rebuild:
                            return (int)RecyclePrtKindCode.Rebuild;
                    }
                }
            }
            return (int)RecyclePrtKindCode.None;
        }

        /// <summary>
        /// ���T�C�N�����i��ʖ��̂��擾���܂��B
        /// </summary>
        /// <param name="isAnswer">�񓚃t���O</param>
        /// <returns>���T�C�N�����i��ʖ���</returns>
        public string GetRecyclePrtKindName(bool isAnswer)
        {
            if (HasMarketPrice)
            {
                // ����񓚂̏ꍇ�A���T�C�N�����i��ʖ��̂𒼐ڕԂ�
                return SCMSobaResponseList[0].MarketPriceKindNm;
            }
            return SCMDataHelper.GetRecyclePrtKindName(GetRecyclePrtKindCode(isAnswer));
        }

        #endregion // </���T�C�N�����i>

        #region <�݌�>

        /// <summary>
        /// �݌ɂ����݂��邩���f���܂��B
        /// </summary>
        public bool ExistsStock
        {
            get
            {
                // 2011/01/11 >>>
                //return !(RealGoodsUnitData.StockList == null || RealGoodsUnitData.StockList.Count.Equals(0));
                return !( ( RealGoodsUnitData.SelectedWarehouseCode == null ) || ( string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode.Trim()) ) );
                // 2011/01/11 <<<
            }
        }

        /// <summary>
        /// �ϑ��݌ɂł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�ϑ��݌ɂł��B<br/>
        /// <c>false</c>:�ϑ��݌ɂł͂���܂���B
        /// </returns>
        public bool IsTrustStock()
        {
            return GetStockDiv().Equals((int)StockDiv.Trust);
        }

        #region <�q�Ƀ}�X�^>

        /// <summary>�q�Ƀ}�X�^</summary>
        private static WarehouseAgent _warehouseDB;
        /// <summary>�q�Ƀ}�X�^���擾���܂��B</summary>
        private static WarehouseAgent WarehouseDB
        {
            get
            {
                if (_warehouseDB == null)
                {
                    _warehouseDB = new WarehouseAgent();
                }
                return _warehouseDB;
            }
        }

        //// ----- ADD 2011/08/10 ----- >>>>>
        ///// <summary>PCCUOE���Аݒ�}�X�^</summary>
        //private static SCMWebAcsAgent _pccDB;
        ///// <summary>PCCUOE���Аݒ�}�X�^���擾���܂��B</summary>
        //private static SCMWebAcsAgent PccDB
        //{
        //    get
        //    {
        //        if (_pccDB == null)
        //        {
        //            _pccDB = new SCMWebAcsAgent();
        //        }
        //        return _pccDB;
        //    }
        //}
        //// ----- ADD 2011/08/10 ----- <<<<<

        #endregion // </�q�Ƀ}�X�^>

        #region <���_�ݒ�}�X�^>

        /// <summary>
        /// ���_�ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static SecInfoSetAgent SecInfoSetDB
        {
            get { return SecInfoSetServer.Singleton.Instance; }
        }

        #endregion // </���_�ݒ�}�X�^>

        /// <summary>�݌ɋ敪</summary>
        private int _stockDiv = -1;
        /// <summary>
        /// �݌ɋ敪���擾���܂��B
        /// </summary>
        /// <returns>�݌ɋ敪</returns>
        public int GetStockDiv()
        {
            const string METHOD_NAME = "GetStockDiv()"; // ���O�p

            if (_stockDiv >= 0) return _stockDiv;

            // DEL 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ---------------------------------->>>>>
            #region �폜
            //// SCM�̏ꍇ
            //if (this._acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM) // ADD 2011/08/10
            //{ // ADD 2011/08/10
            //    // �݌ɏ�񂪂Ȃ��ꍇ�A��݌�
            //    if (!ExistsStock)
            //    {
            //        _stockDiv = (int)StockDiv.None;
            //        return _stockDiv;
            //    }

            //    if (string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
            //    {
            //        // 2011/01/11 Del >>>
            //        //// �I�����Ă���q�ɃR�[�h���s��̏ꍇ�A�ŏ��̍݌ɕi�̑q�ɃR�[�h���g�p����
            //        //RealGoodsUnitData.SelectedWarehouseCode = GetFirstStockedWarehouseProfile().Key;

            //        // �������ʂ̑q�ɂ������Ă��Ȃ���Δ�݌�
            //        _stockDiv = (int)StockDiv.None;
            //        return _stockDiv;
            //        // 2011/01/11 Del <<<
            //    }

            //    _warehouseCode = RealGoodsUnitData.SelectedWarehouseCode;   // �q�ɃR�[�h
            //    _warehouseName = string.Empty;                              // �q�ɖ���

            //    // �ϑ��݌�
            //    // �q�Ƀ}�X�^�̓��Ӑ�R�[�h��SCM�󒍖��׃f�[�^(�⍇���E����)�̓��Ӑ�R�[�h����v
            //    Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
            //    if (foundWarehouse != null)
            //    {
            //        #region <Log>

            //        string msg = string.Format(
            //            "�ϑ��݌ɂ𔻒蒆...SelectedWarehouseCode=�u{0}�v, foundWarehouse.WarehouseCode=�u{1}�v, CustomerCode=�u{2}�v, foundWarehouse.CustomerCode=�u{3}�v",
            //            _warehouseCode,
            //            foundWarehouse.WarehouseCode,
            //            CustomerCode,
            //            foundWarehouse.CustomerCode
            //        );
            //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //        #endregion // </Log>

            //        // �q�ɖ���
            //        _warehouseName = foundWarehouse.WarehouseName;

            //        if (foundWarehouse.CustomerCode.Equals(CustomerCode))
            //        {
            //            _stockDiv = (int)StockDiv.Trust;
            //            return _stockDiv;
            //        }
            //    }
            //    else
            //    {
            //        #region <Log>

            //        string msg = string.Format("�ϑ��݌ɂ𔻒蒆...�q�Ƀ}�X�^�ɓo�^������܂���B(�q�ɃR�[�h={0})", _warehouseCode);
            //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //        #endregion // </Log>

            //        // �q�ɖ���
            //        _warehouseName = GetFirstStockedWarehouseProfile().Value;
            //    }

            //    // ���Ӑ�݌�
            //    // ���Ӑ�}�X�^�̓��Ӑ�q�ɃR�[�h�ƈ�v
            //    CustomerDB.TakeCustomerInfo(SourceDetailRecord.InqOtherEpCd, CustomerCode);
            //    if (CustomerDB.CustomerInfoMap.ContainsKey(CustomerCode))
            //    {
            //        CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[CustomerCode];
            //        {
            //            if (customerInfo.CustWarehouseCd.Trim().Equals(_warehouseCode.Trim()))
            //            {
            //                _stockDiv = (int)StockDiv.Customer;
            //                return _stockDiv;
            //            }
            //        }
            //    }

            //    // �D��q��
            //    // ���_�ݒ�}�X�^�̑q��
            //    if (SecInfoSetDB.ExistsWarehouse(
            //        SourceDetailRecord.InqOtherEpCd,
            //        SourceDetailRecord.InqOtherSecCd,
            //        _warehouseCode
            //    ))
            //    {
            //        _stockDiv = (int)StockDiv.PriorityWarehouse;
            //        return _stockDiv;
            //    }

            //    // ���Ѝ݌�
            //    // �q�ɃR�[�h���ݒ�L��ŁA��L�����𖞂����Ȃ��ꍇ
            //    if (!string.IsNullOrEmpty(_warehouseCode.Trim()))
            //    {
            //        _stockDiv = (int)StockDiv.OwnCompany;
            //        return _stockDiv;
            //    }

            //    // ��݌�
            //    // �q�ɃR�[�h���ݒ薳���ŁA��L�����𖞂����Ȃ��ꍇ
            //    _stockDiv = (int)StockDiv.None;
            //    return _stockDiv;
            //    // ----- ADD 2011/08/10 ----- >>>>>
            //}
            //// PCCUOE�̏ꍇ
            //else
            //{
            #endregion
            // DEL 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ----------------------------------<<<<<
                // �݌Ɋm�F�̏ꍇ
                if (SourceDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry))
                {
                    // �݌ɏ�񂪂Ȃ��ꍇ�A��݌�
                    if (ListUtil.IsNullOrEmpty(RealGoodsUnitData.StockList))
                    {
                        _stockDiv = (int)StockDiv.None;
                        return _stockDiv;
                    }
                    else
                    {
                        // --- ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή� ----->>>>>
                        // �t�^�o�q�Ɉ����ăI�v�V�����I���݂̂̏ꍇ�A�����Ɠ����d�l�ōs��
                        if (CheckFutabaWarehAllocOption())
                        {
                        // --- ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή� -----<<<<<
                            // ADD 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ---------------------------------->>>>>
                            if (string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                            {
                                // ADD 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ----------------------------------<<<<<
                                List<string> priorWarehouseList = new List<string>();
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccWarehouseCd) ? "" : PccCmpnySt.PccWarehouseCd);
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd1) ? "" : PccCmpnySt.PccPriWarehouseCd1);
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd2) ? "" : PccCmpnySt.PccPriWarehouseCd2);
                                priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd3) ? "" : PccCmpnySt.PccPriWarehouseCd3);
                                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------>>>>>
                                //// ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                                //priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd4) ? "" : PccCmpnySt.PccPriWarehouseCd4);
                                //// ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                                if (CheckPriWarehouseOption())
                                {
                                    priorWarehouseList.Add(string.IsNullOrEmpty(PccCmpnySt.PccPriWarehouseCd4) ? "" : PccCmpnySt.PccPriWarehouseCd4);
                                }
                                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------<<<<<

                                foreach (string warehouseCode in priorWarehouseList)
                                {
                                    if (string.IsNullOrEmpty(warehouseCode)) continue;
                                    Stock findStock = RealGoodsUnitData.StockList.Find(
                                        delegate(Stock stockInfo)
                                        {
                                            return (stockInfo.WarehouseCode.Trim().Equals(warehouseCode.Trim()));
                                        }
                                        );
                                    if (findStock != null)
                                    {
                                        RealGoodsUnitData.SelectedWarehouseCode = findStock.WarehouseCode;
                                        break;
                                    }
                                }
                                // ADD 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ---------------------------------->>>>>
                            }
                            // ADD 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ----------------------------------<<<<<
                        } // ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή�

                        if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                        {
                            _warehouseCode = RealGoodsUnitData.SelectedWarehouseCode;   // �q�ɃR�[�h
                            _warehouseName = string.Empty;                              // �q�ɖ���

                            Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
                            if (foundWarehouse != null)
                            {
                                // �q�ɖ���
                                _warehouseName = foundWarehouse.WarehouseName;
                            }
                            else
                            {
                                // �q�ɖ���
                                _warehouseName = GetFirstStockedWarehouseProfile().Value;
                            }

                            // �ϑ��݌�
                            if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccWarehouseCd.Trim())
                            {
                                _stockDiv = (int)StockDiv.Trust;

                            }
                            // �D��݌�
                            else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd1.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd2.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd3.Trim()
                                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------>>>>>
                                //|| RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim()
                                || (CheckPriWarehouseOption() && RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim())
                                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------<<<<<
                                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                                )
                            {
                                _stockDiv = (int)StockDiv.PriorityWarehouse;
                            }
                            return _stockDiv;
                        }
                        else
                        // �݌�
                        {
                            // --- ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή� ----->>>>>
                            // �t�^�o�q�Ɉ����ăI�v�V�����I���݂̂̏ꍇ�A�����Ɠ����d�l�ōs��
                            if (CheckFutabaWarehAllocOption())
                            {
                            // --- ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή� -----<<<<<
                                // ----- ADD 2011/09/26 ----- >>>>>
                                // ----- DEL 2011/09/19 ----- >>>>>
                                // �q�ɃR�[�h
                                _warehouseCode = GetFirstStockedWarehouseProfile().Key;
                                // �q�ɖ���
                                _warehouseName = GetFirstStockedWarehouseProfile().Value;

                                RealGoodsUnitData.SelectedWarehouseCode = _warehouseCode;

                                _stockDiv = (int)StockDiv.OwnCompany;
                                // ----- DEL 2011/09/19 ----- <<<<<
                                // ----- DEL 2011/09/26 ----- <<<<<

                                //_stockDiv = (int)StockDiv.None; // ADD 2011/09/19 // DEL 2011/09/26
                            // --- ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή� ----->>>>>
                            }
                            else
                            {
                                // �q�ɃR�[�h���I�����Ă��Ȃ��ꍇ�A��݌ɂƂ���B
                                _stockDiv = (int)StockDiv.None;
                            }
                            // --- ADD 2016/01/13 �ړ� Redmine#47847 �蓮�񓚗D��q�ɕ\���s���̏�Q�Ή� -----<<<<<
                            return _stockDiv;
                        }
                    }

                }
                // �����̏ꍇ
                else
                {
                    //>>>2012/04/09
                    //// �ϑ��݌�
                    //if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode) && RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccWarehouseCd.Trim())
                    //{
                    //    _stockDiv = (int)StockDiv.Trust;
                    //}
                    //// ��ϑ��݌�
                    //else
                    //{
                    //    _stockDiv = -1;
                    //}
                    // �݌ɏ�񂪂Ȃ��ꍇ�A��݌�
                    if (!ExistsStock)
                    {
                        _stockDiv = (int)StockDiv.None;
                        return _stockDiv;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                        {
                            // �ϑ��݌�
                            if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccWarehouseCd.Trim())
                            {
                                _stockDiv = (int)StockDiv.Trust;

                            }
                            // �D��݌�
                            else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd1.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd2.Trim()
                                || RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd3.Trim()
                                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------>>>>>
                                //|| RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim()
                                || (CheckPriWarehouseOption() && RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim())
                                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------<<<<<
                                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                                )
                            {
                                _stockDiv = (int)StockDiv.PriorityWarehouse;
                            }
                        }
                        else
                        // �݌�
                        {
                            _stockDiv = (int)StockDiv.OwnCompany;
                        }
                    }
                    //<<<2012/04/09

                    if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
                    {
                        _warehouseCode = RealGoodsUnitData.SelectedWarehouseCode;   // �q�ɃR�[�h
                        _warehouseName = string.Empty;                              // �q�ɖ���

                        Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
                        if (foundWarehouse != null)
                        {
                            // �q�ɖ���
                            _warehouseName = foundWarehouse.WarehouseName;
                        }
                    }
                    return _stockDiv;
                }
            // DEL 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ---------------------------------->>>>>
            //}
            // DEL 2012/12/12 2013/01/16�z�M SCM���Ǉ�10423�Ή� ----------------------------------<<<<<
            // ----- ADD 2011/08/10 ----- <<<<<
        }

        // ADD 2012/07/18 SCM��Q��173 ------------------------------------------->>>>>
        /// <summary>
        /// �D��q�ɏ��ʂ��擾���܂��B
        /// </summary>
        /// <returns>�D��q�ɏ���</returns>
        public PriWareHouseOrder GetPriWareHouseOrder()
        {
            PriWareHouseOrder ret = PriWareHouseOrder.None;

            if (!string.IsNullOrEmpty(RealGoodsUnitData.SelectedWarehouseCode))
            {
                if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd1.Trim())
                {
                    ret = PriWareHouseOrder.PriWareHouse1;
                }
                else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd2.Trim())
                {
                    ret = PriWareHouseOrder.PriWareHouse2;
                }
                else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd3.Trim())
                {
                    ret = PriWareHouseOrder.PriWareHouse3;
                }
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------>>>>>
                //else if (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim())
                else if (CheckPriWarehouseOption() && (RealGoodsUnitData.SelectedWarehouseCode.Trim() == PccCmpnySt.PccPriWarehouseCd4.Trim()))
                // UPD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------<<<<<
                {
                    ret = PriWareHouseOrder.PriWareHouse4;
                }
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

            }
            return ret;
        }
        // ADD 2012/07/18 SCM��Q��173 -------------------------------------------<<<<<

        // ADD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------>>>>>
        /// <summary>
        ///  BLP�Q�Ƒq�ɒǉ��I�v�V�����`�F�b�N
        /// </summary>
        /// <returns></returns>
        private static bool CheckPriWarehouseOption()
        {
            USBOptionAgent usbOptin = new USBOptionAgent();
            return usbOptin.EnabledBLPPriWarehouseOption();
        }

        // --- ADD 2016/01/13 �ړ� Redmine#47847 �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100��ǉ����� ----->>>>>
        /// <summary>
        ///  �t�^�o�q�Ɉ����ăI�v�V�����`�F�b�N
        /// </summary>
        /// <returns></returns>
        private static bool CheckFutabaWarehAllocOption()
        {
            USBOptionAgent usbOptin = new USBOptionAgent();
            return usbOptin.EnabledFutabaWarehAllocOption();
        }
        // --- ADD 2016/01/13 �ړ� Redmine#47847 �t�^�o�q�Ɉ����ăI�v�V����  �i�ʁj�FOPT-CPM0100��ǉ����� -----<<<<<
        // ADD 2013/10/17 ���i�ۏ؉�Redmine#552�Ή� ------------------------------------------<<<<<

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// �d�����ʂ��擾���܂��B
        /// </summary>
        /// <returns>�d������</returns>
        public double GetStockQty()
        {

            List<Stock> tempStockList = RealGoodsUnitData.StockList;
            if (!ListUtil.IsNullOrEmpty(tempStockList))
            {
                for(int i=0;i<tempStockList.Count;i++)
                {
                    Stock tempStock = tempStockList[i];
                    if (RealGoodsUnitData.SelectedWarehouseCode != null && tempStock.WarehouseCode == RealGoodsUnitData.SelectedWarehouseCode.Trim())
                    {
                        return tempStock.ShipmentPosCnt;
                    }
                }
                return tempStockList[0].ShipmentPosCnt;
            }
            else
            {
                return 0;
            }
        }
        // ----- ADD 2011/08/10 ----- <<<<<
        /// <summary>
        /// �ŏ��̍݌ɕi�̑q�ɃR�[�h�Ƒq�ɖ��̂��擾���܂��B
        /// </summary>
        /// <returns>
        /// �ŏ��̍݌ɕi�̑q�ɃR�[�h�Ƒq�ɖ��� ���݌ɂ��Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B
        /// </returns>
        private KeyValuePair<string, string> GetFirstStockedWarehouseProfile()
        {
            if (!ListUtil.IsNullOrEmpty<Stock>(RealGoodsUnitData.StockList))
            {
                return new KeyValuePair<string, string>(
                    RealGoodsUnitData.StockList[0].WarehouseCode,
                    RealGoodsUnitData.StockList[0].WarehouseName
                );
            }
            return new KeyValuePair<string, string>(string.Empty, string.Empty);
        }

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode;
        /// <summary>�q�ɃR�[�h���擾���܂��B</summary>
        public string GetWarehouseCode()
        {
            if (_stockDiv < 0) GetStockDiv();
            return string.IsNullOrEmpty(_warehouseCode) ? string.Empty : _warehouseCode;
        }

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName;
        /// <summary>�q�ɖ��̂��擾���܂��B</summary>
        public string GetWarehouseName()
        {
            if (_stockDiv < 0) GetStockDiv();
            return string.IsNullOrEmpty(_warehouseName) ? string.Empty : _warehouseName;
        }

        #endregion // </�݌�>

        #region <�󒍃X�e�[�^�X>

        /// <summary>�󒍃X�e�[�^�X</summary>
        private int _acptAnOdrStatus = -1;
        /// <summary>
        /// �󒍃X�e�[�^�X���擾���܂��B
        /// </summary>
        /// <returns>
        /// SCM�󒍖��׃f�[�^(�⍇���E����).�⍇���E������ʂ�"�⍇��"�̏ꍇ�A10:���� ��Ԃ��܂��B<br/>
        /// SCM�󒍖��׃f�[�^(�⍇���E����).�⍇���E������ʂ�"����"�̏ꍇ�A
        /// �݌ɏ��ɉ����āA"20:��"�܂���"30:����"��Ԃ��܂��B
        /// </returns>
        public int GetAcptAnOdrStatus()
        {
            // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
            #region ���όv��p����

            // ���όv��̏ꍇ�A����
            if (RealGoodsUnitData is AnsweredGoodsUnitData) return (int)AcptAnOdrStatus.Sales;

            #endregion // ���όv��p����
            // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

            if (_acptAnOdrStatus >= 0) return _acptAnOdrStatus;

            // UPD 2014/09/19 SCM�Г���Q�ꗗ��44�Ή� ----------------------------->>>>>
            //int acptAnOdrStatus = SCMDataHelper.GetDefaultAcptAnOdrStatus(SourceDetailRecord.InqOrdDivCd);
            _acptAnOdrStatus = SCMDataHelper.GetDefaultAcptAnOdrStatus(SourceDetailRecord.InqOrdDivCd);
            return _acptAnOdrStatus;
            // UPD 2014/09/19 SCM�Г���Q�ꗗ��44�Ή� -----------------------------<<<<<

            // DEL 2014/09/19 SCM�Г���Q�ꗗ��44�Ή� ----------------------------->>>>>
            #region �폜
            //////// SCM�󒍖��׃f�[�^(�⍇���E����).�⍇���E������ʂ�"�⍇��"�̏ꍇ�A10:���� ��Ԃ��܂��B
            //////if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate))
            //////{
            //////    _acptAnOdrStatus = acptAnOdrStatus;
            //////    return _acptAnOdrStatus;
            //////}


            //////// DEL 2012/11/27 2012/12/12�z�M �V�X�e���e�X�g��Q��86�Ή� ------------------------------>>>>>
            ////////// --- ADD ���� 2012/04/23 ��150 Redmine#28038 ---------->>>>>
            ////////// SCM�̏ꍇ
            ////////if (this._acceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
            ////////{
            ////////    // SCM�S�̐ݒ���擾
            ////////    SCMTtlSt foundSCMTtlSt = TtlStSettingDB.Find(
            ////////         SourceDetailRecord.InqOtherEpCd,
            ////////         SourceDetailRecord.InqOtherSecCd
            ////////        );

            ////////    if (foundSCMTtlSt.AutoAnswerDiv == 3)
            ////////    {
            ////////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Sales;  // ����
            ////////        return _acptAnOdrStatus;
            ////////    }
            ////////}
            ////////// --- ADD ���� 2012/04/23 ��150 Redmine#28038 ----------<<<<<
            //////// DEL 2012/11/27 2012/12/12�z�M �V�X�e���e�X�g��Q��86�Ή� ------------------------------<<<<<

            //////// SCM�󒍖��׃f�[�^(�⍇���E����).�⍇���E������ʂ�"����"�̏ꍇ
            //////// �݌ɏ�񂪂Ȃ��ꍇ�A��݌�
            //////if (RealGoodsUnitData.StockList == null || RealGoodsUnitData.StockList.Count.Equals(0))
            //////{
            //////    _acptAnOdrStatus = (int)AcptAnOdrStatus.Order;  // ��
            //////    return _acptAnOdrStatus;
            //////}

            //////// --- ADD ���� 2012/04/23 ��150 Redmine#28038 ---------->>>>>
            //////// SCM�̏ꍇ
            //////if (this._acceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
            //////{
            //////    //if (GetStockDiv().Equals((int)StockDiv.Trust))// Del 2011/08/06 duzg for Redmine#23307
            //////    if (GetStockDiv().Equals((int)StockDiv.Trust) || GetStockDiv().Equals((int)StockDiv.Customer) || GetStockDiv().Equals((int)StockDiv.PriorityWarehouse))// Add 2011/08/06 duzg for Redmine#23307
            //////    {
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Sales;  // ����
            //////        return _acptAnOdrStatus;
            //////    }
            //////    else
            //////    {
            //////        // ���Ӑ�݌�
            //////        // �D��q��
            //////        // ���Ѝ݌�
            //////        // ��݌�
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Order;  // ��
            //////        return _acptAnOdrStatus;
            //////    }
            //////}
            //////else
            //////{
            //////// --- ADD ���� 2012/04/23 ��150 Redmine#28038 ----------<<<<<
            //////    // �ϑ��݌�
            //////    if (GetStockDiv().Equals((int)StockDiv.Trust))
            //////    {
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Sales;  // ����
            //////        return _acptAnOdrStatus;
            //////    }
            //////    else
            //////    {
            //////        // ���Ӑ�݌�
            //////        // �D��q��
            //////        // ���Ѝ݌�
            //////        // ��݌�
            //////        _acptAnOdrStatus = (int)AcptAnOdrStatus.Order;  // ��
            //////        return _acptAnOdrStatus;
            //////    }
            //////// --- ADD ���� 2012/04/23 ��150 Redmine#28038 ---------->>>>>
            //////}
            //////// --- ADD ���� 2012/04/23 ��150 Redmine#28038 ----------<<<<<
            #endregion
            // DEL 2014/09/19 SCM�Г���Q�ꗗ��44�Ή� ----------------------------->>>>>
        }

        #endregion // </�󒍃X�e�[�^�X>

        #region <�񓚔[��>

        #region <SCM�[���ݒ�}�X�^>

        /// <summary>
        /// SCM�[���ݒ�}�X�^�̃A�N�Z�T���擾���܂��B
        /// </summary>
        private static SCMDeliveryDateSettingAgent DeliveryDateSettingDB
        {
            get { return DeliveryDateSettingServer.Singleton.Instance; }
        }

        #endregion // </SCM�[���ݒ�}�X�^>

        private const string DATE_FORMAT = "yyyy/MM/dd";

        /// <summary>�񓚔[��</summary>
        private string _answerDeliveryDate = DateTime.MinValue.ToString(DATE_FORMAT);
        /// <summary>
        /// �񓚔[�����擾���܂��B
        /// </summary>
        /// <returns>
        /// ��݌ɕi�̏ꍇ�̂�SCM�[���ݒ�}�X�^���擾���܂��B<br/>
        /// ����񓚂�<c>string.Empty</c>��Ԃ��܂��B
        /// </returns>
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        //// UPD 2013/03/07 SCM��Q��10489�Ή� ------------------------------------->>>>>
        ////public string GetAnswerDeliveryDate()
        //public string GetAnswerDeliveryDate(int fuwioutAutoAnsDiv)
        //// UPD 2013/03/07 SCM��Q��10489�Ή� -------------------------------------<<<<<
        #endregion
        // �� �����\�b�h�g�pPG�͎����񓚂݂̂ő�PG����̎Q�Ƃ͖���
        public string GetAnswerDeliveryDate(int fuwioutAutoAnsDiv, out Int16 ansDeliDateDiv)
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            const string METHOD_NAME = "GetAnswerDeliveryDate()";   // ���O�p

            ansDeliDateDiv = 0; // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�

            // ����񓚂�""
            if (HasMarketPrice)
            {
                return string.Empty;
            }

            // DEL 2015/02/18 �L�� SCM�d�|�ꗗNo10695�Ή� ---------->>>>>
            // �񓚔[���敪�Ď擾�̂��ߍ폜
            //if (!_answerDeliveryDate.Equals(DateTime.MinValue.ToString(DATE_FORMAT)))
            //{
            //    return _answerDeliveryDate;
            //}
            // DEL 2015/02/18 �L�� SCM�d�|�ꗗNo10695�Ή� ----------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
            // UPD 2013/03/07 SCM��Q��10489�Ή� ------------------------------------->>>>>
            // �Y���Ȃ������񓚋敪���u����v�ŕi�ԂȂ��񓚂̎��͉񓚔[����"�Y������"�ŉ񓚂���
            //if (RealGoodsUnitData.GoodsNo.Length.Equals(0))
            if (RealGoodsUnitData.GoodsNo.Length.Equals(0) && !RealGoodsUnitData.BLGoodsCode.Equals(0) &&
                fuwioutAutoAnsDiv.Equals((int)FuwioutAutoAnsDiv.Auto))
            // UPD 2013/03/07 SCM��Q��10489�Ή� -------------------------------------<<<<<
            {
                return "�Y������";
            }
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� ----------------------------------------------------------<<<<<

            // 2011/01/11 >>>
            //// ��݌ɕi�ȊO�͍݌ɋ敪�ɂ��ݒ�
            //if (!GetStockDiv().Equals((int)StockDiv.None))
            //{
            //    _answerDeliveryDate = GetAnswerDeliveryDate(GetStockDiv());
            //    if (!string.IsNullOrEmpty(_answerDeliveryDate.Trim()))
            //    {
            //        return _answerDeliveryDate;
            //    }
            //    // ��݌ɕi�Ƃ݂Ȃ��A�����𑱍s
            //}

            //// ��݌ɕi��SCM�[���ݒ�}�X�^���擾
            //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
            //    SourceDetailRecord.InqOtherEpCd,
            //    SourceDetailRecord.InqOtherSecCd,
            //    CustomerCode
            //);
            //if (!string.IsNullOrEmpty(_answerDeliveryDate.Trim()))
            //{
            //    #region <Log>

            //    string msg = "�񓚔[�����u�����F��݌Ɂv��SCM�[���ݒ�}�X�^���擾";
            //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //    #endregion // </Log>
            //}
            //return !string.IsNullOrEmpty(_answerDeliveryDate.Trim())
            //    ? _answerDeliveryDate
            //    : GetAnswerDeliveryDate((int)StockDiv.None);

            // ADD 2015/02/18 �L�� SCM�d�|�ꗗNo10695�Ή� ---------->>>>>
            // �擾�O�̐ݒ�l��ۑ�
            string answerDeliveryDateTemp = _answerDeliveryDate;
            // ADD 2015/02/18 �L�� SCM�d�|�ꗗNo10695�Ή� ----------<<<<<

            _answerDeliveryDate = string.Empty;
            // �݌ɋ敪���擾���A�e��t���O�𐧌�
            int stockDiv = GetStockDiv();
            bool stock = ( !stockDiv.Equals((int)StockDiv.None) );
            bool trustStock = ( stockDiv.Equals((int)StockDiv.Trust) );
            bool priorityStock = (stockDiv.Equals((int)StockDiv.PriorityWarehouse)); // ADD 2011/10/11
            // �I�Ԃ͈ϑ��݌ɂ̎��̂ݎ擾
            string shelfNo = ( trustStock ) ? GetShelfNo() : string.Empty;

            // ----- UPD 2011/10/08 ----- >>>>>
            //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
            //            SourceDetailRecord.InqOtherEpCd,
            //            SourceDetailRecord.InqOtherSecCd,
            //            CustomerCode,
            //            stock,
            //            trustStock,
            //            shelfNo);

            // ----- UPD 2011/11/21 ----- >>>>>
            //�݌ɕi
            if (stockDiv != 0)
            {
                // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// 2012/08/30 UPD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate2(
                //    SourceDetailRecord.InqOtherEpCd,
                //    SourceDetailRecord.InqOtherSecCd,
                //    CustomerCode,
                //    stock,
                //    trustStock,
                //    priorityStock,
                //    SourceDetailRecord.SalesOrderCount,
                //    GetStockQty());

                //#region ���\�[�X
                ////// ������ <= ���݌ɐ� �̏ꍇ
                ////if (SourceDetailRecord.SalesOrderCount <= GetStockQty())
                ////{
                ////    // ----- UPD 2011/10/11 ----- >>>>>
                ////    //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                ////    //    SourceDetailRecord.InqOtherEpCd,
                ////    //    SourceDetailRecord.InqOtherSecCd,
                ////    //    CustomerCode,
                ////    //    stock,
                ////    //    trustStock,
                ////    //    shelfNo);
                ////    _answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                ////        SourceDetailRecord.InqOtherEpCd,
                ////        SourceDetailRecord.InqOtherSecCd,
                ////        CustomerCode,
                ////        stock,
                ////        trustStock,
                ////        priorityStock,
                ////        shelfNo);
                ////    // ----- UPD 2011/10/11 ----- <<<<<
                ////}
                //#endregion
                //// 2012/08/30 UPD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion 

                _answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate2(
                    SourceDetailRecord.InqOtherEpCd
                    , SourceDetailRecord.InqOtherSecCd
                    , CustomerCode
                    , stock
                    , trustStock
                    , priorityStock
                    , SourceDetailRecord.SalesOrderCount
                    , GetStockQty()
                    , out ansDeliDateDiv);
                // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            //���i
            else
            {
                // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //_answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                //    SourceDetailRecord.InqOtherEpCd,
                //    SourceDetailRecord.InqOtherSecCd,
                //    CustomerCode,
                //    stock,
                //    trustStock,
                //    priorityStock,
                //    shelfNo);
                #endregion
                _answerDeliveryDate = DeliveryDateSettingDB.FindAnswerDelivDate(
                    SourceDetailRecord.InqOtherEpCd
                    , SourceDetailRecord.InqOtherSecCd
                    , CustomerCode
                    , stock
                    , trustStock
                    , priorityStock
                    , shelfNo
                    , out ansDeliDateDiv
                    );

                // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // ----- UPD 2011/10/08 ----- <<<<<
            // ----- UPD 2011/11/21 ----- >>>>>
            if (!string.IsNullOrEmpty(_answerDeliveryDate.Trim()))
            {
                #region <Log>

                string msg = "�񓚔[������";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }

            // ADD 2015/02/18 �L�� SCM�d�|�ꗗNo10695�Ή� ---------->>>>>
            // �擾�ς݂̋敪�͌��̋敪��ԋp
            if (!answerDeliveryDateTemp.Equals(DateTime.MinValue.ToString(DATE_FORMAT)))
            {
                _answerDeliveryDate = answerDeliveryDateTemp;
            }
            // ADD 2015/02/18 �L�� SCM�d�|�ꗗNo10695�Ή� ----------<<<<<

            return _answerDeliveryDate.Trim();
            // 2011/01/11 <<<
        }

        // 2011/01/11 Del >>>
#if False
        /// <summary>
        /// �񓚔[�����擾���܂��B
        /// </summary>
        /// <returns>
        /// ��2009/09/03 �d�l�ύX�@���R�����g�Ɉꕔ�ԈႢ����
        /// �ϑ��݌ɁF�I��<br/>
        /// �D��q�ɁF"�݌ɗL��"<br/>
        /// ���Ѝ݌ɁF�q�ɖ���<br/>
        /// ��݌ɁF"�v�m�F"<br/>
        /// ����ȊO�F<c>string.Empty</c>
        /// </returns>
        private string GetAnswerDeliveryDate(int stockDiv)
        {
            const string METHOD_NAME = "GetAnswerDeliveryDate(int)";    // ���O�p

            const string EXISTS_STOCK = "�݌ɗL��"; // LITERAL;

            switch (stockDiv)
            {
                // �݌ɋ敪.�ϑ��݌�    �c���i�����琮���H��ւ̈ϑ��݌�
                case (int)StockDiv.Trust:
                    {
                        #region <Log>

                        string msg = string.Format("�񓚔[�����u���i���F���Ӑ�̈ϑ��݌Ɂv��݌ɋ敪={0}", stockDiv);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return GetShelfNo();
                    }
                // �݌ɋ敪.���Ӑ�݌�  �c���i���F���Ӑ�D��q��
                case (int)StockDiv.Customer:
                    {
                        #region <Log>

                        string msg = string.Format("�񓚔[�����u���i���F���Ӑ�D��q�Ɂv��݌ɋ敪={0}", stockDiv);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return EXISTS_STOCK;
                    }
                // �݌ɋ敪.��݌�      �c�����F��݌�
                case (int)StockDiv.None:
                    {
                        #region <Log>

                        string msg = string.Format("�񓚔[�����u�����F��݌Ɂv��݌ɋ敪={0}", stockDiv);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        // 2010/03/15 >>>
                        //return "�v�m�F";    // LITERAL:
                        return string.Empty;  // LITERAL:
                        // 2010/03/15 <<<
                    }
                // �݌ɋ敪.�D��q�� ����� �݌ɋ敪.���Ѝ݌�
                default:
                    {
                        #region <Log>

                        string msg = string.Format(
                            "�񓚔[����ݒ蒆... SelectedWarehouseCode={0}, ���_={1}, ���={2}",
                            GetWarehouseCode(),
                            SourceDetailRecord.InqOtherSecCd,
                            SourceDetailRecord.InqOtherEpCd
                        );
                        string moreInfo = string.Empty;

                        #endregion // </Log>

                        // ���i���F�����_�݌Ɂ��q�Ƀ}�X�^.�Ǘ����_
                        if (!string.IsNullOrEmpty(GetWarehouseCode().Trim()))
                        {
                            Warehouse foundWarehouse = WarehouseDB.Find(RealGoodsUnitData);
                            if (
                                foundWarehouse != null
                                    &&
                                foundWarehouse.SectionCode.Trim().Equals(SourceDetailRecord.InqOtherSecCd.Trim())
                            )
                            {
                                #region <Log>

                                msg += Environment.NewLine + string.Format(
                                    "\t�񓚔[�����u���i���F�����_�݌Ɂv��q�Ƀ}�X�^.�Ǘ����_={0}",
                                    foundWarehouse.SectionCode
                                );
                                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                                #endregion // </Log>

                                return EXISTS_STOCK;
                            }
                            else
                            {
                                #region <Log>

                                moreInfo = string.Format(
                                    "�q�Ƀ}�X�^.�Ǘ����_=�u{0}�v",
                                    foundWarehouse != null ? foundWarehouse.SectionCode : "�q�Ƀ}�X�^�ɓo�^������܂���ł���"
                                );

                                #endregion // </Log>
                            }
                        }

                        // ���i���F�����_�݌Ɂi�D��q�Ɂj�����_�ݒ�.�D��q��1,2,3
                        if (SecInfoSetDB.ExistsWarehouse(
                            SourceDetailRecord.InqOtherEpCd,
                            SourceDetailRecord.InqOtherSecCd,
                            GetWarehouseCode()
                        ))
                        {
                            #region <Log>

                            msg += Environment.NewLine + "\t�񓚔[�����u���i���F���i���F�����_�݌Ɂi�D��q�Ɂj�v�����_�ݒ�.�D��q��1,2,3";
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            return TrimEndOfAnswerDeliveryDate(GetWarehouseName());
                        }

                        #region <Log>

                        msg += Environment.NewLine + string.Format(
                            "\t�񓚔[�����u�����F��݌Ɂv��݌ɕi�ł����A�D��q�ɂ̐ݒ�ɖ��������_�ł��B({0})",
                            moreInfo
                        );
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return string.Empty;
                    }
            }
        }
#endif
        // 2011/01/11 Del <<<

        /// <summary>�񓚔[���̍ő啶����</summary>
        private const int ANSWER_DELIVERY_DATE_LENGTH = 10;

        /// <summary>
        /// �񓚔[���̒l���ő啶�����ō��܂��B
        /// </summary>
        /// <param name="answerDeliveryDate">�񓚔[���̒l</param>
        /// <returns>�񓚔[���̒l.Substring(0, ANSWER_DELIVERY_DATE_LENGTH)</returns>
        private static string TrimEndOfAnswerDeliveryDate(string answerDeliveryDate)
        {
            if (string.IsNullOrEmpty(answerDeliveryDate)) return string.Empty;

            if (answerDeliveryDate.Length > ANSWER_DELIVERY_DATE_LENGTH)
            {
                return answerDeliveryDate.Substring(0, ANSWER_DELIVERY_DATE_LENGTH);
            }
            return answerDeliveryDate;
        }

        #endregion // <�񓚔[��>

        #region <���i�ԍ�>

        /// <summary>
        /// ���i�ԍ����擾���܂��B
        /// </summary>
        /// <returns>���i�ԍ�</returns>
        public string GetGoodsNo()
        {
            if (HasMarketPrice)
            {
                return RealGoodsUnitData.GoodsNo;   // TODO:����񓚂�"*"�����H
            }
            return RealGoodsUnitData.GoodsNo;
        }

        /// <summary>
        /// �񓚏������i�ԍ����擾���܂��B
        /// </summary>
        /// <returns>�񓚏������i�ԍ�</returns>
        public string GetAnsPureGoodsNo()
        {
            return GetGoodsNo();
        }

        #endregion // </���i�ԍ�>

        #region <�I��>

        /// <summary>
        /// �I�Ԃ��擾���܂��B�i�擾�����Ƃ��ē��Ӑ�R�[�h���܂݂܂��j
        /// </summary>
        /// <returns>�I��</returns>
        public string GetShelfNo()
        {
            string foundWarehouseCode = GetWarehouseCode();

            if (string.IsNullOrEmpty(foundWarehouseCode)) return string.Empty;

            //>>>2012/03/28
            //GoodsAcs goodsAccesser = new GoodsAcs(SourceDetailRecord.InqOtherSecCd);
            //{
            //    string msg = string.Empty;
            //    goodsAccesser.SearchInitial(SourceDetailRecord.InqOtherEpCd, SourceDetailRecord.InqOtherSecCd, out msg);
            //}
            //Stock foundStock = goodsAccesser.GetStockFromStockList(
            //    foundWarehouseCode,
            //    RealGoodsUnitData.GoodsMakerCd,
            //    RealGoodsUnitData.GoodsNo,
            //    RealGoodsUnitData.StockList
            //);

            Stock foundStock = this.GetStockFromStockList(
                foundWarehouseCode,
                RealGoodsUnitData.GoodsMakerCd,
                RealGoodsUnitData.GoodsNo,
                RealGoodsUnitData.StockList
            );
            //<<<2012/03/28

            string shelfNo = (foundStock != null ? foundStock.WarehouseShelfNo : string.Empty);
            return !string.IsNullOrEmpty(shelfNo.Trim()) ? shelfNo : "�I�Ԗ���";    // LITERAL:
        }

        //>>>2012/03/28
        /// <summary>
        /// �w������Y���݌ɏ��f�[�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="stockList">�݌Ƀf�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�݌Ƀf�[�^�I�u�W�F�N�g</returns>
        public Stock GetStockFromStockList(string warehouseCode, int goodsMakerCd, string goodsNo, List<Stock> stockList)
        {
            Stock retStock = null;
            foreach (Stock stock in stockList)
            {
                if ((stock.WarehouseCode.Trim() == warehouseCode.Trim()) &&
                    (stock.GoodsMakerCd == goodsMakerCd) &&
                    (stock.GoodsNo == goodsNo))
                {
                    retStock = stock;
                }
            }
            return retStock;
        }
        //<<<2012/03/28
        #endregion // </�I��>

        #region <���i>

        /// <summary>
        /// �艿���擾���܂��B
        /// </summary>
        /// <returns>�艿</returns>
        public long GetListPrice()
        {
            // ���ꉿ�i
            if (HasMarketPrice)
            {
                return SCMSobaResponseList[0].GetMarketPrice();
            }

            // ----- ADD 2011/08/10 ----- >>>>>
            // SCM�̏ꍇ
            if (this._acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            {
            // ----- ADD 2011/08/10 ----- <<<<<
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                //// SCM�i�ڐݒ肪�u���i�v�̏ꍇ�A�l��Ԃ�
                //if (CanReplyPrice)
                //{
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
                    // --- ADD �O�� 2012/06/18 ��10289 ---------->>>>>
                    if (this.RealGoodsUnitData.SelectedListPrice > 0)
                    {
                        return (long)this.RealGoodsUnitData.SelectedListPrice;
                    }
                    // --- ADD �O�� 2012/06/18 ��10289 ----------<<<<<

                    UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                    if (listPriceResult != null)
                    {
                        return (long)listPriceResult.UnitPriceTaxExcFl; // �艿�͒P��(�Ŕ�, ����)
                    }
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                //}
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
            // ----- ADD 2011/08/10 ----- >>>>>
            }
            // PCCUOE�̏ꍇ
            else
            {
                //>>>2012/02/12
                //UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                //if (listPriceResult != null)
                //{
                //    return (long)listPriceResult.UnitPriceTaxExcFl; // �艿�͒P��(�Ŕ�, ����)
                //}

                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                //// SCM�i�ڐݒ肪�u���i�v�̏ꍇ�A�l��Ԃ�
                //if (CanReplyPrice)
                //{
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
                    UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                    if (listPriceResult != null)
                    {
                        return (long)listPriceResult.UnitPriceTaxExcFl; // �艿�͒P��(�Ŕ�, ����)
                    }
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                //}
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
                //<<<2012/02/12
            }
            // ----- ADD 2011/08/10 ----- <<<<<
            return 0;
        }

        /// <summary>
        /// �Z�b�g�q���܂ނ����f���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// <c>true</c> :�Z�b�g�q���܂݂܂��B<br/>
        /// <c>false</c>:�Z�b�g�q���܂݂܂���B
        /// </returns>
        protected static bool ContainsSetChildAtGoodsKind(GoodsUnitData goodsUnitData)
        {
            IList<int> splitedGoodsKind = SplitGoodsKind(goodsUnitData);
            {
                foreach (int goodsKind in splitedGoodsKind)
                {
                    // 4:�Z�b�g�q
                    if (goodsKind.Equals(4)) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ���i���(��������)��1, 2, 4, 8, 16 �̍\���ɕ������܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>
        /// 1, 2, 4, 8, 16 �̂����A�\������鐔�l�̃��X�g
        /// </returns>
        protected static IList<int> SplitGoodsKind(GoodsUnitData goodsUnitData)
        {
            int number = goodsUnitData.GoodsKind;

            IList<int> splitedNumber = new List<int>();
            {
                int surplus = number;

                surplus %= 16;  // ��֌݊�
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(16);
                }

                number = surplus;
                surplus %= 8;   // ���
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(8);
                }

                number = surplus;
                surplus %= 4;   // �Z�b�g�q
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(4);
                }

                number = surplus;
                surplus %= 2;   // �����q
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(2);
                }

                // �e
                if (surplus.Equals(1))
                {
                    splitedNumber.Add(1);
                }
            }
            return splitedNumber;
        }
        /// <summary>
        /// �P�����擾���܂��B
        /// </summary>
        /// <returns>�P��</returns>
        public long GetUnitPrice()
        {
            // ���ꉿ�i
            if (HasMarketPrice)
            {
                return SCMSobaResponseList[0].GetMarketPrice();
            }

            // --- DEL 2014/11/05 Y.Wakita ---------->>>>>
            #region �폜
            //// ----- ADD 2011/08/10 ----- >>>>>
            //// SCM�̏ꍇ
            //if (this._acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            //{
            //    // ----- ADD 2011/08/10 ----- <<<<<
            //    // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
            //    //// SCM�i�ڐݒ肪�u���i�v�̏ꍇ�A�l��Ԃ�
            //    //if (CanReplyPrice)
            //    //{
            //    // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
            //        UnitPriceCalcRet sellingPriceResult = CalculatorAgent.GetSellingPriceResult(UnitPriceCalcRetList);
            //        if (sellingPriceResult != null)
            //        {
            //            return (long)sellingPriceResult.UnitPriceTaxExcFl;  // �P���͒P��(�Ŕ�, ����)
            //        }
            //        else
            //        {
            //            // �������ݒ�敪���u1:�艿�\���v�̏ꍇ�A�艿���g�p
            //            if (SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(
            //                SourceDetailRecord.InqOtherEpCd,
            //                SourceDetailRecord.InqOtherSecCd
            //            ))
            //            {
            //                return GetListPrice();
            //            }
            //            return 0;
            //        }
            //    // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
            //    //}
            //    // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
            //// ----- ADD 2011/08/10 ----- >>>>>
            //}
            //// PCCUOE�̏ꍇ
            //else
            //{
            #endregion
            // --- DEL 2014/11/05 Y.Wakita ----------<<<<<
                //>>>2012/02/12
                #region �폜
                //// ----- ADD 2011/10/11 ----- >>>>>
                //long _unitPrice = 0;
                //long _listPrice = 0;
                //UnitPriceCalcRet sellingPriceResult = CalculatorAgent.GetSellingPriceResult(UnitPriceCalcRetList);
                //if (sellingPriceResult != null)
                //{
                //    _unitPrice = (long)sellingPriceResult.UnitPriceTaxExcFl;  // �P���͒P��(�Ŕ�, ����)
                //}
                //else
                //{
                //    // �������ݒ�敪���u1:�艿�\���v�̏ꍇ�A�艿���g�p
                //    if (SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(
                //        SourceDetailRecord.InqOtherEpCd,
                //        SourceDetailRecord.InqOtherSecCd
                //    ))
                //    {
                //        _unitPrice = GetListPrice();
                //    }
                //}
                //// �⍇���̏ꍇ�y�я��i�A���f�[�^�̏��i���(��������)���Z�b�g�q�̏ꍇ(����f�[�^�쐬���Ȃ��̏ꍇ)
                //// �����A�g�l�����ƃL�����y�[���𔽉f
                //if (_sourceDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry && ContainsSetChildAtGoodsKind(_realGoodsUnitData))
                //{
                //    UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                //    if (listPriceResult != null)
                //    {
                //        _listPrice = (long)listPriceResult.UnitPriceTaxExcFl;
                //    }
                //    //���㖾�׃f�[�^
                //    SalesDetail salesDetail = new SalesDetail();
                //    salesDetail.TaxationDivCd = _realGoodsUnitData.TaxationDivCd;     //�ېŋ敪
                //    salesDetail.BfSalesUnitPrice = _unitPrice;                        //�ύX�O����
                //    salesDetail.ListPriceTaxExcFl = _listPrice;                       //�艿�i�Ŕ��C�����j
                //    if (_campaignInformation != null)   
                //    {
                //        salesDetail.CampaignCode = _campaignInformation.CampaignCode; //�L�����y�[���R�[�h
                //    }
                //    salesDetail.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                //    salesDetail.SectionCode = _realGoodsUnitData.SectionCode;
                //    salesDetail.GoodsMGroup = _realGoodsUnitData.GoodsMGroup;         //���i�����ރR�[�h
                //    salesDetail.BLGoodsCode = _realGoodsUnitData.BLGoodsCode;         //BL�O���[�v�R�[�h
                //    salesDetail.GoodsMakerCd = _realGoodsUnitData.GoodsMakerCd;       //���i���[�J�[�R�[�h
                //    salesDetail.GoodsNo = _realGoodsUnitData.GoodsNo;                 //���i�ԍ�
                //    salesDetail.SalesCode = _realGoodsUnitData.SalesCode;             //�̔��敪�R�[�h
                //    //����f�[�^
                //    SalesSlip salesSlip = new SalesSlip();
                //    if (_sourceDetailRecord != null)
                //    {
                //        salesSlip.SalesDate = _sourceDetailRecord.UpdateDate;         //�⍇����
                //    }
                //    salesSlip.TotalAmountDispWayCd = 0;                               //���z�\�����@�敪
                //    salesSlip.CustomerCode = _customerCode;
                //    salesSlip.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                //    // �����A�g�l�����ƃL�����y�[���𔽉f
                //    SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                //    {
                //        priceCalculator.SetCurrentSCMOrderData(_customerCode, salesDetail);
                //        PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, salesSlip);
                //        return (long)priceValue.TaxExc;
                //    }
                
                //}
                //else
                //{
                //    return _unitPrice;
                //}

                //// ----- ADD 2011/10/11 ----- <<<<<
                #endregion

                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                // SCM�i�ڐݒ肪�u���i�v�̏ꍇ�A�l��Ԃ�
                //if (CanReplyPrice)
                //{
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
                    // ----- ADD 2011/10/11 ----- >>>>>
                    long _unitPrice = 0;
                    long _listPrice = 0;
                    UnitPriceCalcRet sellingPriceResult = CalculatorAgent.GetSellingPriceResult(UnitPriceCalcRetList);
                    if (sellingPriceResult != null)
                    {
                        _unitPrice = (long)sellingPriceResult.UnitPriceTaxExcFl;  // �P���͒P��(�Ŕ�, ����)
                    }
                    else
                    {
                        // �������ݒ�敪���u1:�艿�\���v�̏ꍇ�A�艿���g�p
                        if (SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(
                            SourceDetailRecord.InqOtherEpCd,
                            SourceDetailRecord.InqOtherSecCd
                        ))
                        {
                            _unitPrice = GetListPrice();
                        }
                    }
                    // �⍇���̏ꍇ�y�я��i�A���f�[�^�̏��i���(��������)���Z�b�g�q�̏ꍇ(����f�[�^�쐬���Ȃ��̏ꍇ)
                    // �����A�g�l�����ƃL�����y�[���𔽉f
                    if (_sourceDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry && ContainsSetChildAtGoodsKind(_realGoodsUnitData))
                    {
                        UnitPriceCalcRet listPriceResult = CalculatorAgent.GetListPriceResult(UnitPriceCalcRetList);
                        if (listPriceResult != null)
                        {
                            _listPrice = (long)listPriceResult.UnitPriceTaxExcFl;
                        }
                        //���㖾�׃f�[�^
                        SalesDetail salesDetail = new SalesDetail();
                        salesDetail.TaxationDivCd = _realGoodsUnitData.TaxationDivCd;     //�ېŋ敪
                        salesDetail.BfSalesUnitPrice = _unitPrice;                        //�ύX�O����
                        salesDetail.ListPriceTaxExcFl = _listPrice;                       //�艿�i�Ŕ��C�����j
                        // ADD 2013/02/28 T.Yoshioka 2013/03/06�z�M�\�� �����[�X�O���؃T�|���Ǉ�92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        salesDetail.SalesUnPrcTaxExcFl = _unitPrice;
                        // ADD 2013/02/28 T.Yoshioka 2013/03/06�z�M�\�� �����[�X�O���؃T�|���Ǉ�92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        if (_campaignInformation != null)
                        {
                            salesDetail.CampaignCode = _campaignInformation.CampaignCode; //�L�����y�[���R�[�h
                        }
                        salesDetail.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                        salesDetail.SectionCode = _realGoodsUnitData.SectionCode;
                        salesDetail.GoodsMGroup = _realGoodsUnitData.GoodsMGroup;         //���i�����ރR�[�h
                        salesDetail.BLGoodsCode = _realGoodsUnitData.BLGoodsCode;         //BL�O���[�v�R�[�h
                        salesDetail.GoodsMakerCd = _realGoodsUnitData.GoodsMakerCd;       //���i���[�J�[�R�[�h
                        salesDetail.GoodsNo = _realGoodsUnitData.GoodsNo;                 //���i�ԍ�
                        salesDetail.SalesCode = _realGoodsUnitData.SalesCode;             //�̔��敪�R�[�h
                        //����f�[�^
                        SalesSlip salesSlip = new SalesSlip();
                        if (_sourceDetailRecord != null)
                        {
                            salesSlip.SalesDate = _sourceDetailRecord.UpdateDate;         //�⍇����
                        }
                        salesSlip.TotalAmountDispWayCd = 0;                               //���z�\�����@�敪
                        salesSlip.CustomerCode = _customerCode;
                        salesSlip.EnterpriseCode = _realGoodsUnitData.EnterpriseCode;
                        // �����A�g�l�����ƃL�����y�[���𔽉f
                        SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                        {
                            // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                            //priceCalculator.SetCurrentSCMOrderData(_customerCode, salesDetail);
                            priceCalculator.SetCurrentSCMOrderData(_customerCode, salesDetail,
                                (SourceDetailRecord.CancelCndtinDiv != 0) ? (short)1 : (short)0,
                                SourceDetailRecord.UpdateDate);
                            // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                            PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, salesSlip);
                            return (long)priceValue.TaxExc;
                        }

                    }
                    else
                    {
                        return _unitPrice;
                    }
                    // ----- ADD 2011/10/11 ----- <<<<<
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ---------------------------------->>>>>
                //}
                //else
                //{
                //    return 0;
                //}
                // DEL 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341,10364,10431�Ή� ----------------------------------<<<<<
                //<<<2012/02/12
            // --- DEL 2014/11/05 Y.Wakita ---------->>>>>
            //}
            // --- DEL 2014/11/05 Y.Wakita ----------<<<<<
            // ----- ADD 2011/08/10 ----- <<<<<
            return -1;  // TODO:SCM�i�ڐݒ�ŉ��i�ݒ肵�Ȃ���
        }

        #endregion // </���i>

        #region <�e��>

        /// <summary>
        /// �e���z���擾���܂��B
        /// </summary>
        /// <returns>���� - ����</returns>
        public long GetRoughRrofit()
        {
            // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� ----------------------->>>>>
            //return CalculatorAgent.GetRoughProfit(UnitPriceCalcRetList);
            bool salesPriceIsNone = SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(this.RealGoodsUnitData.EnterpriseCode, this.RealGoodsUnitData.SectionCode);
            return CalculatorAgent.GetRoughProfit(UnitPriceCalcRetList, salesPriceIsNone);
            // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� -----------------------<<<<<
        }

        /// <summary>
        /// �e�������擾���܂��B
        /// </summary>
        /// <remarks>�����_��3�ʂ��l�̌ܓ�</remarks>
        /// <returns>(���� - ����) / ���� * 100.0</returns>
        public double GetRoughRate()
        {
            // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� ----------------------->>>>>
            //double roughRate = CalculatorAgent.GetRoughRate(UnitPriceCalcRetList);
            bool salesPriceIsNone = SalesTtlStDB.UsesListPriceIfSalesPriceIsNone(this.RealGoodsUnitData.EnterpriseCode, this.RealGoodsUnitData.SectionCode);
            double roughRate = CalculatorAgent.GetRoughRate(UnitPriceCalcRetList, salesPriceIsNone);
            // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� -----------------------<<<<<
            return CalculatorAgent.RoundOff(roughRate, 3);
        }

        #endregion // </�e��>

        #region <�R���N�V�����p�w���p���\�b�h>

        /// <summary>
        /// �e�����̍ł�����SCM���t���i�A���f�[�^���������܂��B
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�e�����̍ł�����SCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> FindHighestRoughRate(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                double currentRoughRate = scmGoodsUitDataList[0].GetRoughRate();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    double roughRate = scmGoodsUnitData.GetRoughRate();
                    if (roughRate > currentRoughRate)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentRoughRate = roughRate;
                    }
                    else if (roughRate.Equals(currentRoughRate))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        /// <summary>
        /// �P���̍ł�����SCM���t���i�A���f�[�^���������܂��B
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�P���̍ł�����SCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> FindHighestUnitPrice(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                long currentUnitPrice = scmGoodsUitDataList[0].GetUnitPrice();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    long unitPrice = scmGoodsUnitData.GetUnitPrice();
                    if (unitPrice > currentUnitPrice)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentUnitPrice = unitPrice;
                    }
                    else if (unitPrice.Equals(currentUnitPrice))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        /// <summary>
        /// �艿�̍ł�����SCM���t���i�A���f�[�^���������܂��B
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�艿�̍ł�����SCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> FindHighestListPrice(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                long currentListPrice = scmGoodsUitDataList[0].GetListPrice();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    long listPrice = scmGoodsUnitData.GetListPrice();
                    if (listPrice > currentListPrice)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentListPrice = listPrice;
                    }
                    else if (listPrice.Equals(currentListPrice))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        /// <summary>
        /// �艿�̍ł��ႢSCM���t���i�A���f�[�^���������܂��B
        /// </summary>
        /// <param name="scmGoodsUitDataList">SCM���t���i�A���f�[�^�̃��X�g</param>
        /// <returns>�艿�̍ł��ႢSCM���t���i�A���f�[�^�̃��X�g</returns>
        public static IList<SCMGoodsUnitData> FindLowestListPrice(IList<SCMGoodsUnitData> scmGoodsUitDataList)
        {
            #region <Guard Phrase>

            if (scmGoodsUitDataList == null || scmGoodsUitDataList.Count.Equals(0)) return scmGoodsUitDataList;

            #endregion // </Guard Phrase>

            if (scmGoodsUitDataList.Count.Equals(1)) return scmGoodsUitDataList;

            IList<SCMGoodsUnitData> foundList = new List<SCMGoodsUnitData>();
            {
                long currentListPrice = scmGoodsUitDataList[0].GetListPrice();
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUitDataList)
                {
                    long listPrice = scmGoodsUnitData.GetListPrice();
                    if (listPrice < currentListPrice)
                    {
                        foundList.Clear();
                        foundList.Add(scmGoodsUnitData);
                        currentListPrice = listPrice;
                    }
                    else if (listPrice.Equals(currentListPrice))
                    {
                        foundList.Add(scmGoodsUnitData);
                    }
                }
            }
            return foundList.Count.Equals(0) ? scmGoodsUitDataList : foundList;
        }

        #endregion // </�R���N�V�����p�w���p���\�b�h>

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>
        /// �q�ɏ����擾���܂��B
        /// </summary>
        /// <param name="paramGoodsUnitData">���i�A���f�[�^</param>
        /// <returns>�q�ɏ��</returns>
        public Warehouse GetWarehouseInfo(GoodsUnitData paramGoodsUnitData)
        {
            return WarehouseDB.Find(paramGoodsUnitData);
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2014/07/23 Redmine#43080��3SCM�󔭒����׃f�[�^�ɍ݌ɏ󋵋敪�̃Z�b�g----------------------->>>>>
        /// <summary>
        /// �݌Ƀ}�X�^���擾
        /// </summary>
        /// <returns>�݌Ƀ}�X�^���</returns>
        /// <remarks>
        /// <br>Note		: �݌ɏ󋵋敪�擾���܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2014/07/23</br>
        /// </remarks>
        public Stock GetStock()
        {
            List<Stock> tempStockList = RealGoodsUnitData.StockList;
            if (!ListUtil.IsNullOrEmpty(tempStockList))
            {
                for (int i = 0; i < tempStockList.Count; i++)
                {
                    Stock tempStock = tempStockList[i];
                    if (RealGoodsUnitData.SelectedWarehouseCode != null && tempStock.WarehouseCode == RealGoodsUnitData.SelectedWarehouseCode.Trim())
                    {
                        return tempStock;
                    }
                }
                return tempStockList[0];
            }
            else
                return null;

        }
        // ADD 2014/07/23 Redmine#43080��3SCM�󔭒����׃f�[�^�ɍ݌ɏ󋵋敪�̃Z�b�g-----------------------<<<<<
    }
}
