//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���������i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/03  �C�����e : RedMine#307 �ۑ����ꂽ���Ӑ�ʐݒ���J���ƁA
//                                              �O���[�v�����\������Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/09  �C�����e : RedMine#343 ���Ӑ�ʐݒ�Ń��[�U�[�o�^�̃O���[�v��
//                                              �I������Ƒ��݂��Ȃ��G���[
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : ���I ���
// �X �V ��  2015/03/13  �C�����e : �i��RedMine#3151 ���Ӑ�ʐݒ�Ń��[�U�[�o�^�̃O���[�v��
//                                                   �I������Ƒ��݂��Ȃ��G���[
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/16  �C�����e : RedMine#371 �������iUP����ݒ肵���ꍇ�A
//                                              �������}�X�^�̃��[�J�[���i�ɓK�p�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/23  �C�����e : �i��Redmine#3158 �ۑ�Ǘ��\��37
//                                  ���J�敪�`�F�b�N���͂�������Ԃł���Ή��o�^�ł���悤�ɑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/25  �C�����e : ���[�J�[���i�擾���@�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/26  �C�����e : �i��Redmine#3247
//                                  PM���i�}�X�^(���[�U�[�o�^)����擾�������[�J�[���i�ɑ΂��ė����ݒ肪���f�����
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���������i�ݒ�}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������i�ݒ�}�X�^ �A�N�Z�X�N���X</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public class RecBgnGdsAcs
    {
        #region Private Member
        private static CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;

        private RecBgnGdsDataSet _dataSet;
        private RecBgnGdsDataSet.RecBgnGdsDataTable _recBgnGdsDataTable;
        private RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTable;

        private Dictionary<Guid, RecBgnGds> _prevRecBgnGdsDic = new Dictionary<Guid, RecBgnGds>();
        private Dictionary<Guid, RecBgnCust> _prevRecBgnCustDic = new Dictionary<Guid, RecBgnCust>();
        private Dictionary<int, RecBgnGdsCustInfo> _RecBgnGdsCustInfoDic = new Dictionary<int, RecBgnGdsCustInfo>();


        private AllDefSet _allDefSet; // �S�̏����l�ݒ�}�X�^���

        private IRecBgnGdsDB _iRecBgnGdsDB = null;
        private Calculator _calculator = null;
        private RecBgnGrpAcs _recBgnGrpAcs = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>�������ʏ�</summary>
        private string _statusOfResult = string.Empty;

        private MakerAcs _makerAcs = null;              // ���[�J�[�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs = null;          // ���_���A�N�Z�X�N���X

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

        /// <summary> SCM��ƘA���f�[�^�A�N�Z�X�N���X </summary>
        private ScmEpScCntAcs _scmEpScCntAcs;

        /// <summary> �������i�f�[�^�A�N�Z�X�N���X </summary>
        private IsolIslandPrcAcs _isolIslandPrcAcs = null;

        private IWin32Window _owner = null;

        private Dictionary<int, MakerUMnt> _makerUMntDic = new Dictionary<int, MakerUMnt>();            // ���[�J�[�}�X�^�f�B�N�V���i���[
        private Dictionary<string, SecInfoSet> _secInfoSetDic = new Dictionary<string, SecInfoSet>();   // ���_���f�B�N�V���i���[
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();    // BL�R�[�h�}�X�^�f�B�N�V���i���[
        private Dictionary<int, BLGroupU> _blGroupDic = new Dictionary<int, BLGroupU>();                // BL�O���[�v�}�X�^�f�B�N�V���i���[
        private Dictionary<int, UserGdBd> _userGdBdDic = new Dictionary<int, UserGdBd>();               // ���[�U�[�K�C�h�f�B�N�V���i���[
        private Dictionary<int, CustomerInfo> _customerDic = new Dictionary<int, CustomerInfo>();       // ���Ӑ�f�B�N�V���i���[
        private List<CustomerSearchRet> _customerSearchRetList = new List<CustomerSearchRet>();         // ���Ӑ惊�X�g�i���������i�O���[�v�K�C�h�p�j
        private Dictionary<int, RecBgnGds> _recBgnGdsDic = new Dictionary<int, RecBgnGds>();            // ���������i�ݒ�}�X�^�f�B�N�V���i���[
        private List<RecBgnGrpRet> _recBgnGrpWorkList = new List<RecBgnGrpRet>();                       // ���������i�O���[�v�ݒ�}�X�^���X�g

        private List<ScmEpScCnt> _scmEpScCntList = new List<ScmEpScCnt>();   // SCM��ƘA���f�[�^���X�g
        private List<RecBgnGds> _recBgnGdsList = new List<RecBgnGds>();

        //true:�폜�w��敪=1�Afalse:�폜�w��敪=0
        private bool _deleteSearchMode = false;

        /// <summary>// true:���[�J���Q�� false:�T�[�o�[�Q��</summary>
        public static readonly bool ctIsLocalDBRead = false;

        private RecBgnGds _newRecBgnGdsObj = new RecBgnGds(); // �V�K�s�̏ꍇ�p

        private Thread _masterAcsThread;    // �}�X�^�f�[�^�擾�X���b�h
        private Thread _goodsAcsThread;     // ���i�f�[�^�擾�X���b�h

        /// <summary>�S�Аݒ�</summary>
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "�S�Ћ���";
        #endregion

        #region �v���p�e�B
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

        /// <summary>
        /// �O���b�h�e�[�u���v���p�e�B
        /// </summary>
        public RecBgnGdsDataSet.RecBgnGdsDataTable RecBgnGdsDataTable
        {
            get { return this._recBgnGdsDataTable; }
        }

        /// <summary>
        /// �O���b�h�e�[�u���v���p�e�B
        /// </summary>
        public RecBgnGdsDataSet.RecBgnCustDataTable RecBgnCustDataTable
        {
            get { return this._recBgnCustDataTable; }
        }

        /// <summary>
        /// ���������i�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<Guid, RecBgnGds> PrevRecBgnGdsDic
        {
            get { return this._prevRecBgnGdsDic; }
        }

        /// <summary>
        /// ���������i���Ӑ�ʐݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<Guid, RecBgnCust> PrevRecBgnCustDic
        {
            get { return this._prevRecBgnCustDic; }
        }

        /// <summary>
        /// ���������i�ݒ�-���Ӑ�ʐݒ�֘A�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, RecBgnGdsCustInfo> RecBgnGdsCustInfoDic
        {
            get { return this._RecBgnGdsCustInfoDic; }
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
        /// ���Ӑ�}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public List<CustomerSearchRet> CustomerSearchRetList
        {
            get { return this._customerSearchRetList; }
        }

        /// <summary>
        /// ���������i�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, RecBgnGds> RecBgnGdsDic
        {
            get { return this._recBgnGdsDic; }
        }

        /// <summary>
        /// ���������i�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public List<RecBgnGds> RecBgnGdsList
        {
            get { return this._recBgnGdsList; }
        }

        /// <summary>
        /// SCM��ƘA���f�[�^���X�g�v���p�e�B
        /// </summary>
        public List<ScmEpScCnt> ScmEpScCntList
        {
            get { return this._scmEpScCntList; }
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
        /// (GetRatePriceOfRecBgnGds()���ďo�����ɕω����܂�)
        /// </summary>
        public string StatusOfResult
        {
            get { return _statusOfResult; }
        }

        /// <summary>
        /// ���������i�ݒ�v���p�e�B�A�V�K�s�̏ꍇ�p
        /// </summary>
        public RecBgnGds NewRecBgnGdsObj
        {
            get { return _newRecBgnGdsObj; }
            set { _newRecBgnGdsObj = value; }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^ ���i�Z�o�A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public Calculator Calculator
        {
            get { return this._calculator; }
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^ �v���p�e�B
        /// </summary>
        public AllDefSet AllDefSet
        {
            get { return this._allDefSet; }
        }
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
        /// <br>Note       : ���������i�ݒ�}�X�^ �A�N�Z�X�N���X</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public RecBgnGdsAcs()
        {
            this._dataSet = new RecBgnGdsDataSet();
            this._recBgnGdsDataTable = this._dataSet.RecBgnGds;
            this._recBgnCustDataTable = this._dataSet.RecBgnCust;
            this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._iRecBgnGdsDB = (IRecBgnGdsDB)MediationRecBgnGdsDB.GetRecBgnGdsDB();
            this._calculator = new Calculator();
            this._recBgnGrpAcs = new RecBgnGrpAcs();
            this._isolIslandPrcAcs = new IsolIslandPrcAcs(); // ADDD 2015/02/27 �C���A
        }
        #endregion

        #region Public Method
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <param name="recBgnGdsSearchPara">���������N���X</param>
        /// <param name="count">count</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public int Search(RecBgnGdsSearchPara recBgnGdsSearchPara, out int count, out string msg)
        {
            int status = 0;
            count = 0;
            msg = string.Empty;
            ArrayList recBgnGdsList = null;
            ArrayList recBgnCustList = null;

            RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = this.CopyToRecBgnGdsSearchParaWorkFromRecBgnGdsSearchPara(recBgnGdsSearchPara);

            try
            {
                if (recBgnGdsSearchPara.DeleteFlag == 0)
                {
                    status = this.SearchPrc(out recBgnGdsList, out recBgnCustList, recBgnGdsSearchParaWork, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
                }
                else
                {
                    status = this.SearchPrc(out recBgnGdsList, out recBgnCustList, recBgnGdsSearchParaWork, ConstantManagement.LogicalMode.GetData1, out count, ref msg);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            Dictionary<string, string> ss = new Dictionary<string, string>();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (recBgnGdsSearchPara.DeleteFlag == 0)
                {
                    this._deleteSearchMode = false;
                }
                else
                {
                    this._deleteSearchMode = true;
                }

                if (recBgnGdsList != null && recBgnGdsList.Count > 0)
                {
                    this.SettingDetailRowAfterSearch(recBgnGdsList, recBgnCustList);
                }
            }
            //---------ADD 2015/03/13 ���I -------->>>>>>
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                //�Y���Ȃ��ꍇ�A���Ӑ�ʃf�B�N�V���i�����N���A
                _RecBgnGdsCustInfoDic.Clear();
            }
            //---------ADD 2015/03/13 ���I --------<<<<<<

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retArray">����߰ݑΏۏ��i�ݒ�Ͻ��f�[�^</param>
        /// <param name="recBgnGdsSearchPara">���������N���X</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="count">count</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public int SearchPrc(out ArrayList retGdsArray, out ArrayList retCustArray, RecBgnGdsSearchParaWork recBgnGdsSearchParaWork, ConstantManagement.LogicalMode logicalMode, out int count, ref string msg)
        {
            int status = 0;
            count = 0;
            try
            {
                ArrayList recBgnGdsList = null;
                ArrayList recBgnCustList = null;
                object retObj = recBgnGdsList as object;
                object retCustobj = recBgnCustList as object;

                object paraObj = recBgnGdsSearchParaWork as object;
                status = this._iRecBgnGdsDB.Search(out retObj, out retCustobj, paraObj, logicalMode, out count, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retGdsArray = retObj as ArrayList;
                    retCustArray = retCustobj as ArrayList;
                }
                else
                {
                    retGdsArray = null;
                    retCustArray = null;
                }
            }
            catch (Exception ex)
            {
                retGdsArray = null;
                retCustArray = null;
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void DetailRowInitialSetting(int defaultRowCount)
        {
            this.RecBgnGdsDataTable.BeginLoadData();
            this.RecBgnGdsDataTable.Clear();
            this._deleteSearchMode = false;

            for (int i = 1; i <= defaultRowCount; i++)
            {
                RecBgnGdsDataSet.RecBgnGdsRow row = this.RecBgnGdsDataTable.NewRecBgnGdsRow();
                row.RowNo = i;
                row.FilterGuid = Guid.Empty;
                row.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                row.InqOtherEpCd = this._enterpriseCode;
                row.InqOtherSecCd = ALL_SECTION_CODE;
                row.InqOtherSecNm = ALL_SECTION_NAME;
                row.DisplayDivCode = 1;
                row.ApplyStaDate = string.Empty;
                row.ApplyEndDate = string.Empty;

                this.RecBgnGdsDataTable.AddRecBgnGdsRow(row);
            }
            this.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1], ref this._newRecBgnGdsObj);
            this.RecBgnGdsDataTable.EndLoadData();
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public int SaveProc(List<RecBgnGds> deleteList, List<RecBgnGds> updateList, List<RecBgnCust> updateCustList, out RecBgnGds recBgnGds)
        {
            int status = 0;
            recBgnGds = null;

            ArrayList GdsDelList = new ArrayList();
            ArrayList GdsUpdList = new ArrayList();
            ArrayList CustUpdList = new ArrayList();

            ArrayList IsolUpdList = new ArrayList();

            // ���������i
            RecBgnGdsPMWork recBgnGdsPMWork = null;
            foreach (RecBgnGds recBgn in deleteList)
            {
                recBgnGdsPMWork = this.CopyToRecBgnGdsPMWorkFromRecBgnGds(recBgn);
                GdsDelList.Add(recBgnGdsPMWork);
            }
            foreach (RecBgnGds recBgn in updateList)
            {
                recBgnGdsPMWork = this.CopyToRecBgnGdsPMWorkFromRecBgnGds(recBgn);
                GdsUpdList.Add(recBgnGdsPMWork);
            }

            // ���������i���Ӑ��
            RecBgnCustPMWork recBgnCustPMWork = null;
            foreach (RecBgnCust recCust in updateCustList)
            {
                recBgnCustPMWork = this.CopyToRecBgnCustPMWorkFromRecBgnCust(recCust);
                CustUpdList.Add(recBgnCustPMWork);
            }

            // �������i
            // --- UPD 2015/02/27 �C���A ------------------------------>>>>>
            //IsolIslandPrc isolIslandPrc = null;
            //foreach (RecBgnGds recBgn in updateList)
            //{
            //    status = this._isolIslandPrcAcs.Read(out isolIslandPrc, this._enterpriseCode, recBgn.GoodsMakerCd);
            //    IsolUpdList.Add(isolIslandPrc);
            //}
            PmIsolPrcWork pmIsolPrcWork = null;
            List<IsolIslandPrc> isolIslandPrcList = new List<IsolIslandPrc>();
            status = this._isolIslandPrcAcs.Search(out isolIslandPrcList, this._enterpriseCode); //�������i�}�X�^�Ǎ�
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (IsolIslandPrc isolIslandPrc in isolIslandPrcList)
                {
                    foreach (RecBgnGds recBgn in updateList)
                    {
                        if (isolIslandPrc.MakerCode == recBgn.GoodsMakerCd)
                        {
                            pmIsolPrcWork = new PmIsolPrcWork();
                            pmIsolPrcWork.CreateDateTime = isolIslandPrc.CreateDateTime;
                            pmIsolPrcWork.EnterpriseCode = isolIslandPrc.EnterpriseCode;
                            pmIsolPrcWork.ListPriceUpRate = isolIslandPrc.UpRate;
                            pmIsolPrcWork.LogicalDeleteCode  = isolIslandPrc.LogicalDeleteCode;
                            pmIsolPrcWork.MakerCode          = isolIslandPrc.MakerCode;
                            pmIsolPrcWork.PMFractionProcCd   = isolIslandPrc.FractionProcCd;
                            pmIsolPrcWork.PMFractionProcUnit = isolIslandPrc.FractionProcUnit;
                            pmIsolPrcWork.SectionCode        = isolIslandPrc.SectionCode;
                            pmIsolPrcWork.UpdateDateTime     = isolIslandPrc.UpdateDateTime;
                            pmIsolPrcWork.UpperLimitPrice    = isolIslandPrc.UpperLimitPrice;


                            IsolUpdList.Add(pmIsolPrcWork);
                            break;
                        }
                    }
                }
            }
            // --- UPD 2015/02/27 �C���A ------------------------------<<<<<

            object paraGdsDelObj = GdsDelList as object;
            object paraGdsUpdObj = GdsUpdList as object;
            object paraCustUpdObj = CustUpdList as object;

            object paraIsolUpdObj = IsolUpdList as object;

            if (this._deleteSearchMode == false)
            {
                object errorObj = null;
                status = this._iRecBgnGdsDB.DeleteAndWrite(paraGdsDelObj, ref paraGdsUpdObj, ref paraCustUpdObj, ref paraIsolUpdObj, out errorObj);
                if (errorObj != null)
                {
                    RecBgnGdsPMWork errorWork = errorObj as RecBgnGdsPMWork;
                    recBgnGds = this.CopyToRecBgnGdsFromRecBgnGdsPMWork(errorWork);
                }
            }
            else
            {
                status = this._iRecBgnGdsDB.DeleteAndRevival(paraGdsDelObj, ref paraGdsUpdObj);
            }

            return status;
        }

        /// <summary>
        /// ���i����
        /// </summary>
        /// <returns>�X�e�[�^�X 0�F����I�� 0�ȊO�F�ُ�I�� </returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //public int SearchPartsFromGoodsNo(string goodsNo, int goodsMakerCd, out GoodsUnitData goodsUnitData, out string msg)
        public int SearchPartsFromGoodsNo(
            string goodsNo, 
            int goodsMakerCd, 
            out GoodsUnitData goodsUnitData, 
            out PartsInfoDataSet partsInfoDataSet,
            out Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            out Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList, 
            out string msg)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            int status = -1;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            bool samePartsNoWindowDiv = true;   // ADD 2015/03/25 Y.Wakita

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = this._enterpriseCode;
            // --- UPD 2015/03/16 Y.Wakita Redmine#371 ---------->>>>>
            //cndtn.SectionCode = this._loginSectionCode;
            cndtn.SectionCode = ALL_SECTION_CODE;
            // --- UPD 2015/03/16 Y.Wakita Redmine#371 ----------<<<<<
            cndtn.GoodsKindCode = 9;
            cndtn.GoodsNo = goodsNo.Trim();

            goodsUnitData = null;
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            mkrSuggestRtPricList = null;
            mkrSuggestRtPricUList = null;
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            if (goodsMakerCd != 0)
            {
                cndtn.GoodsMakerCd = goodsMakerCd;
                samePartsNoWindowDiv = false;   // ADD 2015/03/25 Y.Wakita
            }

            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //status = this.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);
            status = this.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, samePartsNoWindowDiv, out goodsUnitDataList, out partsInfoDataSet, out msg);
            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                Calculator.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList, out mkrSuggestRtPricList, out mkrSuggestRtPricUList);
            }
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
            // --- DEL 2015/03/25 Y.Wakita ---------->>>>>
            //if (goodsUnitDataList.Count == 0 && status != -1)
            //{
            //    cndtn.SectionCode = ALL_SECTION_CODE;
            //    status = this.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);
            //}
            // --- DEL 2015/03/25 Y.Wakita ----------<<<<<
            if (goodsUnitDataList.Count > 0)
            {
                goodsUnitData = goodsUnitDataList[0];
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�ʐݒ�f�[�^���烊�X�g�쐬
        /// </summary>
        public void SetGdsToCust2(List<RecBgnGds> updateList, out List<RecBgnCust> updateCustList)
        {
            List<RecBgnCust> uList = new List<RecBgnCust>();
            RecBgnCust recBgnCust = new RecBgnCust();
            RecBgnCust recBgnCustUPD = new RecBgnCust();

            int custRowNo = 1;

            for (int i = 0; i < updateList.Count; i++)
            {
                int rowNo = updateList[i].RowIndex;
                RecBgnGdsCustInfo recBgnGdsCustInfo = null;
                if (this.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
                {
                    recBgnGdsCustInfo = this.RecBgnGdsCustInfoDic[rowNo];

                    if (recBgnGdsCustInfo.recBgnCust.Count != 0)
                    {
                        foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in recBgnGdsCustInfo.recBgnCust)
                        {
                            recBgnCust = new RecBgnCust();
                            this.CopyToRecBgnCustFromDetailRow(RecBgnCustRow, ref recBgnCust);

                            recBgnCustUPD = recBgnCust.Clone();
                            recBgnCustUPD.RowIndex = custRowNo;

                            recBgnCustUPD.LogicalDeleteCode = 0;
                            recBgnCustUPD.GoodsNo = updateList[i].GoodsNo;
                            recBgnCustUPD.GoodsMakerCd = updateList[i].GoodsMakerCd;
                            recBgnCustUPD.GoodsApplyStaDate = updateList[i].ApplyStaDate;

                            uList.Add(recBgnCustUPD);

                            custRowNo += 1;
                        }
                    }
                }
            }

            updateCustList = uList;
        }

        #endregion

        #region Private Method
        /// <summary>
        /// ����������A���׍s�ǉ�����
        /// </summary>
        /// <param name="retList">0:�o�^�E�X�V�A1:���S�폜�ƕ���</param>
        /// <remarks>
        /// <br>Note       : ����������A���׍s�ǉ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void SettingDetailRowAfterSearch(ArrayList retGdsList, ArrayList retCustList)
        {
            //�֘ADic�폜
            _RecBgnGdsCustInfoDic.Clear();

            // ���������i���Ӑ�ʐݒ�
            this._recBgnCustDataTable.BeginLoadData();
            this._recBgnCustDataTable.Clear();
            RecBgnCust recBgnCust = null;
            for (int i = 1; i <= retCustList.Count; i++)
            {
                recBgnCust = this.CopyToRecBgnCustFromRecBgnCustPMWork((RecBgnCustPMWork)retCustList[i - 1]);
                RecBgnGdsDataSet.RecBgnCustRow row = this._recBgnCustDataTable.NewRecBgnCustRow();
                row.RowNo = i;
                this.CopyToDetailRowFromRecBgnCust(ref row, recBgnCust);

                this._recBgnCustDataTable.AddRecBgnCustRow(row);
                this._prevRecBgnCustDic.Add(row.FilterGuid, recBgnCust);
            }
            this._recBgnCustDataTable.EndLoadData();

            // ���������i�ݒ�
            this.RecBgnGdsDataTable.BeginLoadData();
            this._recBgnGdsDataTable.Clear();
            RecBgnGds recBgnGds = null;

            List<RecBgnGdsPMWork> retGdsListWork = new List<RecBgnGdsPMWork>((RecBgnGdsPMWork[])retGdsList.ToArray(typeof(RecBgnGdsPMWork)));
            // ���_�AҰ���A�i�ԁA���J�J�n�����Ƀ\�[�g
            retGdsListWork.Sort(new RecBgnGdsAsComparer());

            // �o�^�ύs�̒ǉ�
            for (int i = 1; i <= retGdsList.Count; i++)
            {
                recBgnGds = this.CopyToRecBgnGdsFromRecBgnGdsPMWork(retGdsListWork[i - 1]);
                RecBgnGdsDataSet.RecBgnGdsRow row = this._recBgnGdsDataTable.NewRecBgnGdsRow();
                row.RowNo = i;
                this.CopyToDetailRowFromRecBgnGds(ref row, recBgnGds);

                // ���Ӑ�ʐݒ���Z�b�g����
                this.SetGdsToCust(ref row);

                this._recBgnGdsDataTable.AddRecBgnGdsRow(row);
                this._prevRecBgnGdsDic.Add(row.FilterGuid, recBgnGds);
            }

            if (this._deleteSearchMode == false)
            {
                // �V�K�s�̒ǉ�
                RecBgnGdsDataSet.RecBgnGdsRow newRow = this._recBgnGdsDataTable.NewRecBgnGdsRow();
                newRow.RowNo = retGdsList.Count + 1;
                newRow.FilterGuid = Guid.Empty;
                newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                newRow.InqOtherEpCd = this._enterpriseCode;
                newRow.GoodsName = string.Empty;
                newRow.GoodsComment = string.Empty;
                newRow.DisplayDivCode = 1;
                newRow.ApplyStaDate = string.Empty;
                newRow.ApplyEndDate = string.Empty;

                this._recBgnGdsDataTable.AddRecBgnGdsRow(newRow);
            }

            this.RecBgnGdsDataTable.EndLoadData();
        }

        /// <summary>
        /// ���Ӑ�ʐݒ�֘A�̃f�[�^�ݒ�
        /// </summary>
        private void SetGdsToCust(ref RecBgnGdsDataSet.RecBgnGdsRow newRow)
        {
            // �e�q�֌W
            RecBgnGdsCustInfo recBgnGdsCustInfo = new RecBgnGdsCustInfo();
            recBgnGdsCustInfo.recBgnGdsRow = newRow;

            DataRow[] res = this._recBgnCustDataTable.Select("InqOtherEpCd = '" + newRow.InqOtherEpCd + "'" +
                " AND InqOtherSecCd = '" + newRow.InqOtherSecCd + "'" +
                " AND GoodsNo = '" + newRow.GoodsNo + "'" +
                " AND GoodsMakerCode = " + (Int32)newRow.GoodsMakerCode +
                " AND GoodsApplyStaDate = '" + newRow.ApplyStaDate.Replace("/", "") + "'");

            RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTableWk = new RecBgnGdsDataSet.RecBgnCustDataTable();

            int rowNo = 1;
            foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in res)
            {
                _recBgnCustDataTableWk.BeginLoadData();
                RecBgnGdsDataSet.RecBgnCustRow row = _recBgnCustDataTableWk.NewRecBgnCustRow();

                row.ItemArray = RecBgnCustRow.ItemArray;
                row.RowNo = rowNo;

                _recBgnCustDataTableWk.AddRecBgnCustRow(row);
                _recBgnCustDataTableWk.EndLoadData();

                rowNo = rowNo + 1;
            }

            recBgnGdsCustInfo.recBgnCust = _recBgnCustDataTableWk;
            this._RecBgnGdsCustInfoDic.Add(newRow.RowNo, recBgnGdsCustInfo);
            if (res.Length > 0)
            {
                newRow.RecBgnCust = "�L";
            }
        }

        /// <summary>
        /// ���׍s�[�����������i�ݒ�}�X�^
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="RecBgnGds">���������i�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���׍s�[�����������i�ݒ�}�X�^</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void CopyToDetailRowFromRecBgnGds(ref RecBgnGdsDataSet.RecBgnGdsRow row, RecBgnGds recBgnGds)
        {
            row.UpdateTime = recBgnGds.UpdateDateTime.Date.ToString("yy/MM/dd"); //�폜��
            row.FilterGuid = Guid.NewGuid();

            row.InqOtherEpCd = recBgnGds.InqOtherEpCd;                                  // �⍇�����ƃR�[�h
            row.InqOtherSecCd = recBgnGds.InqOtherSecCd.Trim().PadLeft(2, '0');         // �⍇���拒�_�R�[�h
            if (recBgnGds.InqOtherSecCd.Trim() == ALL_SECTION_CODE)
                row.InqOtherSecNm = ALL_SECTION_NAME;       //���_��
            else
                row.InqOtherSecNm = this.GetSectionName(recBgnGds.InqOtherSecCd.Trim());    //���_��
            row.GoodsMakerCode = recBgnGds.GoodsMakerCd;        // Ұ��
            row.GoodsMakerName = recBgnGds.GoodsMakerNm;        // Ұ����
            row.GoodsNo = recBgnGds.GoodsNo;                    // �i��
            row.GoodsName = recBgnGds.GoodsName;                // �i��
            row.BLGroupCode = recBgnGds.BLGroupCode;            // BL�O���[�v�R�[�h
            row.BLGoodsCode = recBgnGds.BLGoodsCode;            // BL���i�R�[�h
            row.GoodsComment = recBgnGds.GoodsComment;          // ���i�R�����g
            row.MkrSuggestRtPric = recBgnGds.MkrSuggestRtPric;  // Ұ����]�������i
            row.ListPrice = recBgnGds.ListPrice;                // �艿
            row.UnitCalcRate = recBgnGds.UnitCalcRate;          // �P���Z�o�|��
            row.UnitPrice = recBgnGds.UnitPrice;                // ���P��
            row.ApplyStaDate = recBgnGds.ApplyStaDate.ToString("0000/00/00");          // �K�p�J�n��
            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            if (recBgnGds.ApplyEndDate != 0)
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
            row.ApplyEndDate = recBgnGds.ApplyEndDate.ToString("0000/00/00");          // �K�p�I����
            row.ModelFitDiv = recBgnGds.ModelFitDiv;            // �K���Ԏ�敪
            row.CustRateGrpCode = recBgnGds.CustRateGrpCode;    // ���Ӑ�|���O���[�v�R�[�h
            row.DisplayDivCode = recBgnGds.DisplayDivCode;      // �\���敪
            row.BrgnGoodsGrpCode = recBgnGds.BrgnGoodsGrpCode;  // ���������i�O���[�v�R�[�h
            row.BrgnGoodsGrpName = GetRecBgnGrpName(string.Empty, string.Empty, recBgnGds.BrgnGoodsGrpCode);    // ���������i�O���[�v��
            row.GoodsImage = recBgnGds.GoodsImage;              // ���i�摜
            row.RowDevelopFlg = 1;

            // ���i����
            string msg = string.Empty;
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //int status = this.SearchPartsFromGoodsNo(row.GoodsNo, row.GoodsMakerCode, out goodsUnitData, out msg);
            int status = this.SearchPartsFromGoodsNo(row.GoodsNo, row.GoodsMakerCode, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

            if (goodsUnitData != null)
            {
                if (goodsUnitData.LogicalDeleteCode == 0)
                {
                    // ���i���
                    row.goodsUnitData = goodsUnitData;
                    // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                    row.mkrSuggestRtPricList = mkrSuggestRtPricList;
                    row.mkrSuggestRtPricUList = mkrSuggestRtPricUList;
                    // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                }
            }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^�[�����׍s
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="RecBgnGds">���������i���Ӑ�ʐݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�[�����׍s</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void CopyToRecBgnCustFromDetailRow(RecBgnGdsDataSet.RecBgnCustRow row, ref RecBgnCust recBgnCust)
        {
            if (recBgnCust == null)
            {
                recBgnCust = new RecBgnCust();
            }

            recBgnCust.InqOriginalEpCd = row.InqOriginalEpCd;                               // �⍇�����ƃR�[�h
            recBgnCust.InqOriginalSecCd = row.InqOriginalSecCd.ToString().PadLeft(2, '0');  // �⍇���拒�_�R�[�h
            recBgnCust.InqOtherEpCd = row.InqOtherEpCd;                                     // �⍇�����ƃR�[�h
            recBgnCust.InqOtherSecCd = row.InqOtherSecCd.ToString().PadLeft(2, '0');        // �⍇���拒�_�R�[�h
            recBgnCust.GoodsNo = row.GoodsNo;                                               // ���i�ԍ�
            recBgnCust.GoodsMakerCd = row.GoodsMakerCode;                            // ���i���[�J�[�R�[�h
            recBgnCust.GoodsApplyStaDate = row.GoodsApplyStaDate;                    // ���i�K�p�J�n��
            recBgnCust.CustomerCode = int.Parse(row.CustomerCode);                   // ���Ӑ�R�[�h
            recBgnCust.MngSectionCode = row.MngSectionCode;                          // �Ǘ����_�R�[�h
            recBgnCust.MkrSuggestRtPric = row.MkrSuggestRtPric;                      // Ұ����]�������i
            recBgnCust.ListPrice = row.ListPrice;                                    // �艿
            recBgnCust.UnitCalcRate = row.UnitCalcRate;                              // �P���Z�o�|��
            recBgnCust.UnitPrice = row.UnitPrice;                                    // �P��

            int startDate = 0;  // �K�p�J�n��
            if (!row.ApplyStaDate.Replace("/", "").Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Replace("/", ""));
            recBgnCust.ApplyStaDate = startDate;
            int endDate = 0;    // �K�p�I����
            if (!row.ApplyEndDate.Replace("/", "").Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Replace("/", ""));
            recBgnCust.ApplyEndDate = endDate;
            recBgnCust.DisplayDivCode = row.DisplayDivCode;
            recBgnCust.BrgnGoodsGrpCode = row.BrgnGoodsGrpCode;  // ���������i�O���[�v�R�[�h
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^�[�����׍s
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="RecBgnGds">���������i�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�[�����׍s</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void CopyToRecBgnGdsFromDetailRow(RecBgnGdsDataSet.RecBgnGdsRow row, ref RecBgnGds recBgnGds)
        {
            if (recBgnGds == null)
            {
                recBgnGds = new RecBgnGds();
            }
            recBgnGds.InqOtherEpCd = row.InqOtherEpCd;                              // �⍇�����ƃR�[�h
            recBgnGds.InqOtherSecCd = row.InqOtherSecCd.ToString().PadLeft(2, '0'); // �⍇���拒�_�R�[�h
            recBgnGds.GoodsNo = row.GoodsNo;                                        // ���i�ԍ�
            recBgnGds.GoodsMakerCd = row.GoodsMakerCode;                            // ���i���[�J�[�R�[�h
            recBgnGds.GoodsMakerNm = row.GoodsMakerName;                            // ���i���[�J�[����
            if (row.IsGoodsNameNull())
                recBgnGds.GoodsName = string.Empty;                                 // ���i����
            else
                recBgnGds.GoodsName = row.GoodsName;                                // ���i����
            recBgnGds.BLGroupCode = row.BLGroupCode;                                // BL�O���[�v�R�[�h
            recBgnGds.BLGoodsCode = row.BLGoodsCode;                                // BL���i�R�[�h
            if (row.IsGoodsCommentNull())
                recBgnGds.GoodsComment = string.Empty;                              // ���i�R�����g
            else
                recBgnGds.GoodsComment = row.GoodsComment;                          // ���i�R�����g
            recBgnGds.MkrSuggestRtPric = row.MkrSuggestRtPric;                      // Ұ����]�������i
            recBgnGds.ListPrice = row.ListPrice;                                    // �艿
            recBgnGds.UnitCalcRate = row.UnitCalcRate;                              // �P���Z�o�|��
            recBgnGds.UnitPrice = row.UnitPrice;                                    // �P��

            int startDate = 0;  // ���J�J�n��
            if (!row.ApplyStaDate.Replace("/", "").Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Replace("/", ""));
            recBgnGds.ApplyStaDate = startDate;
            int endDate = 0;    // ���J�I����
            if (!row.ApplyEndDate.Replace("/", "").Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Replace("/", ""));
            recBgnGds.ApplyEndDate = endDate;

            recBgnGds.ModelFitDiv = row.ModelFitDiv;            // �K���Ԏ�敪
            recBgnGds.CustRateGrpCode = 0;                      // ���Ӑ�|���O���[�v�R�[�h
            recBgnGds.DisplayDivCode = row.DisplayDivCode;      // �\���敪
            recBgnGds.BrgnGoodsGrpCode = row.BrgnGoodsGrpCode;  // ���������i�O���[�v�R�[�h
            if (row.IsGoodsImageNull())                         // ���i�摜
                recBgnGds.GoodsImage = new Byte[0];
            else
                recBgnGds.GoodsImage = row.GoodsImage;          // ���i�摜
            recBgnGds.RowIndex = row.RowNo;
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="recBgnGds1">���������i�ݒ�}�X�^</param>
        /// <param name="recBgnGds2">���������i�ݒ�}�X�^</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^��r����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool Compare(RecBgnGds recBgnGds1, RecBgnGds recBgnGds2)
        {
            if (recBgnGds1.GoodsName != recBgnGds2.GoodsName
                || recBgnGds1.GoodsComment != recBgnGds2.GoodsComment
                || recBgnGds1.GoodsImage != recBgnGds2.GoodsImage
                || recBgnGds1.BrgnGoodsGrpCode != recBgnGds2.BrgnGoodsGrpCode
                || recBgnGds1.DisplayDivCode != recBgnGds2.DisplayDivCode
                || recBgnGds1.ApplyStaDate != recBgnGds2.ApplyStaDate
                || recBgnGds1.ApplyEndDate != recBgnGds2.ApplyEndDate
                || recBgnGds1.MkrSuggestRtPric != recBgnGds2.MkrSuggestRtPric   // ADD 2015/03/25 Y.Wakita
                || recBgnGds1.ListPrice != recBgnGds2.ListPrice                 // ADD 2015/03/25 Y.Wakita
                || recBgnGds1.UnitCalcRate != recBgnGds2.UnitCalcRate
                || recBgnGds1.UnitPrice != recBgnGds2.UnitPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="recBgnGds1">���������i�ݒ�}�X�^</param>
        /// <param name="recBgnGds2">���������i�ݒ�}�X�^</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^��r����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CompareKey(RecBgnGds recBgnGds1, RecBgnGds recBgnGds2)
        {
            if (recBgnGds1.InqOtherSecCd != recBgnGds2.InqOtherSecCd
             || recBgnGds1.GoodsNo != recBgnGds2.GoodsNo 
             || recBgnGds1.GoodsMakerCd != recBgnGds2.GoodsMakerCd 
             || recBgnGds1.ApplyStaDate != recBgnGds2.ApplyStaDate)
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
        /// <param name="recBgnGdsSearchPara1">���o����1</param>
        /// <param name="recBgnGdsSearchPara2">���o����2</param>
        /// <returns>true:���Afalse:�s��</returns>
        /// <remarks>
        /// <br>Note       : ���o������r����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CompareRecBgnGdsSearchPara(RecBgnGdsSearchPara recBgnGdsSearchPara1, RecBgnGdsSearchPara recBgnGdsSearchPara2)
        {
            //�����������ύX�Ȃ��̏ꍇ�͌������Ȃ�
            if (recBgnGdsSearchPara1.InqOtherSecCd == recBgnGdsSearchPara2.InqOtherSecCd
                && recBgnGdsSearchPara1.GoodsMakerCdSt == recBgnGdsSearchPara2.GoodsMakerCdSt
                && recBgnGdsSearchPara1.GoodsMakerCdEd == recBgnGdsSearchPara2.GoodsMakerCdEd
                && recBgnGdsSearchPara1.GoodsNo.Trim() == recBgnGdsSearchPara2.GoodsNo.Trim()
                && recBgnGdsSearchPara1.ApplyDateSt == recBgnGdsSearchPara2.ApplyDateSt
                && recBgnGdsSearchPara1.ApplyDateEd == recBgnGdsSearchPara2.ApplyDateEd
                && recBgnGdsSearchPara1.DeleteFlag == recBgnGdsSearchPara2.DeleteFlag)
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool IsRowUpdate(RecBgnGdsDataSet.RecBgnGdsRow row)
        {
            int startDate = 0;
            if (!row.ApplyStaDate.Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Trim().Replace("/", ""));
            int endDate = 0;
            if (!row.ApplyEndDate.Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Trim().Replace("/", ""));

            if (row.GoodsNo.Trim() != this._newRecBgnGdsObj.GoodsNo.Trim()
                || row.GoodsName.Trim() != this._newRecBgnGdsObj.GoodsName.Trim()
                || row.GoodsMakerCode != this._newRecBgnGdsObj.GoodsMakerCd
                || row.GoodsComment != this._newRecBgnGdsObj.GoodsComment
                || startDate != this._newRecBgnGdsObj.ApplyStaDate
                || endDate != this._newRecBgnGdsObj.ApplyEndDate
                || row.UnitPrice != this._newRecBgnGdsObj.UnitPrice
                || row.IsGoodsImageNull() != true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void LoadMstData()
        {
            this._masterAcsThread = new Thread(new ThreadStart(MasterThreadProc));   // �}�X�^�f�[�^�擾�X���b�h
            this._goodsAcsThread = new Thread(new ThreadStart(GoodsThreadProc));   // ���i�f�[�^�擾�X���b�h
            this._goodsAcsThread.Start();
            this._masterAcsThread.Start();
        }

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

            this.GetCustomerSearchRetList();//���Ӑ�}�X�^�̓ǂݍ���

            this.LoadScmEpScCnt();//SCM��ƘA���f�[�^�̓ǂݍ���

            this.LoadRecBgnGds();//���������i�ݒ�}�X�^�̓ǂݍ���

            this.LoadRecBgnGrp();//���������i�O���[�v�ݒ�}�X�^�̓ǂݍ���

            this.LoadAllDefSet(); //�S�̏����l�ݒ�}�X�^�̓ǂݍ���
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

        /// <summary>
        /// BlCode�}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BlCode�}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void GetCustomerSearchRetList()
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
                            // �_���폜����Ă���ꍇ
                            continue;
                        }
                        this._customerSearchRetList.Add(CopytoCustomerSearchRetFromCustmorInfo(customerInfo));
                        this._customerDic.Add(customerInfo.CustomerCode, customerInfo);
                    }
                }
            }
            catch
            {
                this._customerDic = new Dictionary<int, CustomerInfo>();
            }
        }


        private CustomerSearchRet CopytoCustomerSearchRetFromCustmorInfo(CustomerInfo customerInfo)
        {
            CustomerSearchRet customerSearchRet = new CustomerSearchRet();
            customerSearchRet.AcceptWholeSale = customerInfo.AcceptWholeSale;
            customerSearchRet.Address1 = customerInfo.Address1;
            customerSearchRet.Address3 = customerInfo.Address3;
            customerSearchRet.Address4 = customerInfo.Address4;
            customerSearchRet.CustomerAgentCd = customerInfo.CustomerAgentCd;
            customerSearchRet.CustomerAgentNm = customerInfo.CustomerAgentNm;
            customerSearchRet.CustomerCode = customerInfo.CustomerCode;
            customerSearchRet.CustomerEpCode = customerInfo.CustomerEpCode;
            customerSearchRet.CustomerSecCode = customerInfo.CustomerSecCode;
            customerSearchRet.CustomerSlipNoDiv = customerInfo.CustomerSlipNoDiv;
            customerSearchRet.CustomerSubCode = customerInfo.CustomerSubCode;
            customerSearchRet.EnterpriseCode = customerInfo.EnterpriseCode;
            customerSearchRet.EnterpriseName = customerInfo.EnterpriseName;
            customerSearchRet.HomeFaxNo = customerInfo.HomeFaxNo;
            customerSearchRet.HomeTelNo = customerInfo.HomeTelNo;
            customerSearchRet.HonorificTitle = customerInfo.HonorificTitle;
            customerSearchRet.Kana = customerInfo.Kana;
            customerSearchRet.LogicalDeleteCode = customerInfo.LogicalDeleteCode;
            customerSearchRet.MngSectionCode = customerInfo.MngSectionCode;
            customerSearchRet.Name = customerInfo.Name;
            customerSearchRet.Name2 = customerInfo.Name2;
            customerSearchRet.OfficeFaxNo = customerInfo.OfficeFaxNo;
            customerSearchRet.OfficeTelNo = customerInfo.OfficeTelNo;
            customerSearchRet.OnlineKindDiv = customerInfo.OnlineKindDiv;
            customerSearchRet.PortableTelNo = customerInfo.PortableTelNo;
            customerSearchRet.PostNo = customerInfo.PostNo;
            customerSearchRet.SearchTelNo = customerInfo.SearchTelNo;
            customerSearchRet.SimplInqAcntAcntGrId = customerInfo.SimplInqAcntAcntGrId;
            customerSearchRet.Snm = customerInfo.CustomerSnm;
            customerSearchRet.TotalDay = customerInfo.TotalDay;
            customerSearchRet.UpdateDate = customerInfo.UpdateDateTime;


            return customerSearchRet;
        }

        /// <summary>
        /// SCM��ƘA���f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM��ƘA���f�[�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void LoadScmEpScCnt()
        {
            try
            {
                bool msgDiv;
                string errMsg;
                List<ScmEpScCnt> scmEpScCntList;

                int status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out msgDiv, out errMsg);
                if (status == 0)
                {
                    this._scmEpScCntList = scmEpScCntList;
                }
            }
            catch
            {
                this._scmEpScCntList = new List<ScmEpScCnt>();
            }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadRecBgnGds()
        {
            this._recBgnGdsList = new List<RecBgnGds>();

            try
            {
                ArrayList retList = new ArrayList();
                object retObj = retList as object;
                object retCustObj = retList as object;

                string msg = string.Empty;

                int status = this._iRecBgnGdsDB.Search(out retObj, out retCustObj, this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, ref msg);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    RecBgnGds recBgnGds;
                    foreach (RecBgnGdsPMWork recBgnGdsWork in retList)
                    {
                        recBgnGds = CopyToRecBgnGdsFromRecBgnGdsPMWork(recBgnGdsWork);
                        this._recBgnGdsList.Add(recBgnGds);
                    }
                }
            }
            catch
            {
                this._recBgnGdsList = new List<RecBgnGds>();
            }
        }

        /// <summary>
        /// ���������i�O���[�v�ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�O���[�v�ݒ�}�X�^�Ǎ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadRecBgnGrp()
        {

            this._recBgnGrpWorkList = new List<RecBgnGrpRet>(); 

            try
            {
                RecBgnGrpRet[] ret = null;
                ArrayList retList = new ArrayList();
                RecBgnGrpPara para = new RecBgnGrpPara();
                // --- UPD 2015/03/09 Y.Wakita Redmine#343 ---------->>>>>
                //int status = this._recBgnGrpAcs.Search(out ret, para);
                int status = this._recBgnGrpAcs.Search(out ret, this._enterpriseCode);
                // --- UPD 2015/03/09 Y.Wakita Redmine#343 ----------<<<<<
                if (status == 0)
                {
                    retList.AddRange(ret);
                    foreach (RecBgnGrpRet recBgnGrop in retList)
                    {
                        if (recBgnGrop.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._recBgnGrpWorkList.Add(recBgnGrop);
                    }
                }
            }
            catch
            {
                this._recBgnGrpWorkList = new List<RecBgnGrpRet>();
            }
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ�}�X�^�̎擾���s���܂��B</br>
        /// <br>Programmer : �{�{ ����</br>
        /// <br>Date       : 2015/02/26</br>
        /// </remarks>
        private void LoadAllDefSet()
        {
            this._allDefSet = new AllDefSet();

            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode, allDefSetSearchMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���O�C���S���҂̏������_�������͑S�Аݒ���擾
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
            }
            catch
            {
                this._allDefSet = new AllDefSet();
            }
        }
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : �{�{ ����</br>
        /// <br>Date       : 2015/02/26</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == ALL_SECTION_CODE)
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }
        /// <summary>
        /// RecBgnGdsSearchPara->RecBgnGdsSearchParaWork
        /// </summary>
        /// <param name="searchCondition">��������</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsSearchPara->RecBgnGdsSearchParaWork</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnGdsSearchParaWork CopyToRecBgnGdsSearchParaWorkFromRecBgnGdsSearchPara(RecBgnGdsSearchPara recBgnGdsSearchPara)
        {
            RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = new RecBgnGdsSearchParaWork();

            recBgnGdsSearchParaWork.InqOtherEpCd = recBgnGdsSearchPara.InqOtherEpCd;        // �⍇�����ƃR�[�h
            recBgnGdsSearchParaWork.InqOtherSecCd = recBgnGdsSearchPara.InqOtherSecCd;      // �⍇���拒�_�R�[�h
            recBgnGdsSearchParaWork.GoodsMakerCdSt = recBgnGdsSearchPara.GoodsMakerCdSt;    // ���i���[�J�[�R�[�h�i�J�n�j
            recBgnGdsSearchParaWork.GoodsMakerCdEd = recBgnGdsSearchPara.GoodsMakerCdEd;    // ���i���[�J�[�R�[�h�i�I���j
            recBgnGdsSearchParaWork.ApplyDateSt = recBgnGdsSearchPara.ApplyDateSt;          // ���J���i�J�n�j
            recBgnGdsSearchParaWork.ApplyDateEd = recBgnGdsSearchPara.ApplyDateEd;          // ���J���i�I���j
            recBgnGdsSearchParaWork.GoodsNo = recBgnGdsSearchPara.GoodsNo;                  // ���i�ԍ�
            recBgnGdsSearchParaWork.DeleteFlag = recBgnGdsSearchPara.DeleteFlag;            // �폜�敪

            return recBgnGdsSearchParaWork;
        }

        #region ���������i�ݒ�
        /// <summary>
        /// RecBgnGdsPMWork->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGdsPMWork">���������i�ݒ胏�[�N</param>
        /// <returns>���������i�ݒ�</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsWork->RecBgnGds</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnGds CopyToRecBgnGdsFromRecBgnGdsPMWork(RecBgnGdsPMWork recBgnGdsPMWork)
        {
            RecBgnGds recBgnGds = new RecBgnGds();

            recBgnGds.CreateDateTime = recBgnGdsPMWork.CreateDateTime;        // �쐬����
            recBgnGds.UpdateDateTime = recBgnGdsPMWork.UpdateDateTime;        // �X�V����
            recBgnGds.LogicalDeleteCode = recBgnGdsPMWork.LogicalDeleteCode;  // �_���폜�敪
            recBgnGds.InqOtherEpCd = recBgnGdsPMWork.InqOtherEpCd;            // �⍇�����ƃR�[�h
            recBgnGds.InqOtherSecCd = recBgnGdsPMWork.InqOtherSecCd;          // �⍇���拒�_�R�[�h
            recBgnGds.GoodsNo = recBgnGdsPMWork.GoodsNo;                      // ���i�ԍ�
            recBgnGds.GoodsMakerCd = recBgnGdsPMWork.GoodsMakerCd;            // ���i���[�J�[�R�[�h
            recBgnGds.GoodsMakerNm = recBgnGdsPMWork.GoodsMakerNm;            // ���i���[�J�[����
            recBgnGds.GoodsName = recBgnGdsPMWork.GoodsName;                  // ���i����
            recBgnGds.BLGroupCode = recBgnGdsPMWork.BLGroupCode;              // BL�O���[�v�R�[�h
            recBgnGds.BLGoodsCode = recBgnGdsPMWork.BLGoodsCode;              // BL���i�R�[�h
            recBgnGds.GoodsComment = recBgnGdsPMWork.GoodsComment;            // ���i�R�����g
            recBgnGds.MkrSuggestRtPric = recBgnGdsPMWork.MkrSuggestRtPric;    // Ұ����]�������i
            recBgnGds.ListPrice = recBgnGdsPMWork.ListPrice;                  // �艿
            recBgnGds.UnitCalcRate = recBgnGdsPMWork.UnitCalcRate;            // �P���Z�o�|��
            recBgnGds.UnitPrice = recBgnGdsPMWork.UnitPrice;                  // �P��
            recBgnGds.ApplyStaDate = recBgnGdsPMWork.ApplyStaDate;            // �K�p�J�n��
            recBgnGds.ApplyEndDate = recBgnGdsPMWork.ApplyEndDate;            // �K�p�I����
            recBgnGds.ModelFitDiv = recBgnGdsPMWork.ModelFitDiv;              // �K���Ԏ�敪
            recBgnGds.CustRateGrpCode = recBgnGdsPMWork.CustRateGrpCode;      // ���Ӑ�|���O���[�v�R�[�h
            if (recBgnGdsPMWork.DisplayDivCode == 0)
                recBgnGds.DisplayDivCode = 1;        // �\���敪
            else
                recBgnGds.DisplayDivCode = 0;        // �\���敪
            recBgnGds.BrgnGoodsGrpCode = recBgnGdsPMWork.BrgnGoodsGrpCode;    // ���������i�O���[�v�R�[�h
            recBgnGds.GoodsImage = recBgnGdsPMWork.GoodsImage;                // ���i�摜

            return recBgnGds;
        }

        /// <summary>
        /// RecBgnGds->RecBgnGdsPMWork
        /// </summary>
        /// <param name="RecBgnGdsWork">���������i�ݒ�</param>
        /// <returns>���������i�ݒ胏�[�N</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGds->RecBgnGdsWork</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnGdsPMWork CopyToRecBgnGdsPMWorkFromRecBgnGds(RecBgnGds recBgnGds)
        {
            RecBgnGdsPMWork recBgnGdsPMWork = new RecBgnGdsPMWork();

            recBgnGdsPMWork.CreateDateTime = recBgnGds.CreateDateTime;        // �쐬����
            recBgnGdsPMWork.UpdateDateTime = recBgnGds.UpdateDateTime;        // �X�V����
            recBgnGdsPMWork.LogicalDeleteCode = recBgnGds.LogicalDeleteCode;  // �_���폜�敪
            recBgnGdsPMWork.InqOtherEpCd = recBgnGds.InqOtherEpCd;            // �⍇�����ƃR�[�h
            recBgnGdsPMWork.InqOtherSecCd = recBgnGds.InqOtherSecCd;          // �⍇���拒�_�R�[�h
            recBgnGdsPMWork.GoodsNo = recBgnGds.GoodsNo;                      // ���i�ԍ�
            recBgnGdsPMWork.GoodsMakerCd = recBgnGds.GoodsMakerCd;            // ���i���[�J�[�R�[�h
            recBgnGdsPMWork.GoodsMakerNm = recBgnGds.GoodsMakerNm;            // ���i���[�J�[����
            recBgnGdsPMWork.GoodsName = recBgnGds.GoodsName;                  // ���i����
            recBgnGdsPMWork.BLGroupCode = recBgnGds.BLGroupCode;              // BL�O���[�v�R�[�h
            recBgnGdsPMWork.BLGoodsCode = recBgnGds.BLGoodsCode;              // BL���i�R�[�h
            recBgnGdsPMWork.GoodsComment = recBgnGds.GoodsComment;            // ���i�R�����g
            recBgnGdsPMWork.MkrSuggestRtPric = recBgnGds.MkrSuggestRtPric;    // Ұ����]�������i
            recBgnGdsPMWork.ListPrice = recBgnGds.ListPrice;                  // �艿
            recBgnGdsPMWork.UnitCalcRate = recBgnGds.UnitCalcRate;            // �P���Z�o�|��
            recBgnGdsPMWork.UnitPrice = recBgnGds.UnitPrice;                  // �P��
            recBgnGdsPMWork.ApplyStaDate = recBgnGds.ApplyStaDate;            // �K�p�J�n��
            recBgnGdsPMWork.ApplyEndDate = recBgnGds.ApplyEndDate;            // �K�p�I����
            recBgnGdsPMWork.ModelFitDiv = recBgnGds.ModelFitDiv;              // �K���Ԏ�敪
            recBgnGdsPMWork.CustRateGrpCode = recBgnGds.CustRateGrpCode;      // ���Ӑ�|���O���[�v�R�[�h
            if (recBgnGds.DisplayDivCode == 0)
                recBgnGdsPMWork.DisplayDivCode = 1;        // �\���敪
            else
                recBgnGdsPMWork.DisplayDivCode = 0;        // �\���敪
            recBgnGdsPMWork.BrgnGoodsGrpCode = recBgnGds.BrgnGoodsGrpCode;    // ���������i�O���[�v�R�[�h
            if (recBgnGds.GoodsImage != null)
                recBgnGdsPMWork.GoodsImage = recBgnGds.GoodsImage;            // ���i�摜
            else
                recBgnGdsPMWork.GoodsImage = new Byte[0];

            return recBgnGdsPMWork;
        }
        #endregion

        #region ���������i���Ӑ�ʐݒ�
        /// <summary>
        /// RecBgnCustPMWork->RecBgnCust
        /// </summary>
        /// <param name="RecBgnCustPMWork">���������i���Ӑ�ʐݒ胏�[�N</param>
        /// <returns>���������i���Ӑ�ʐݒ�</returns>
        /// <remarks>
        /// <br>Note       : RecBgnCustPMWork->RecBgnCust</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void CopyToDetailRowFromRecBgnCust(ref RecBgnGdsDataSet.RecBgnCustRow row, RecBgnCust recBgnCust)
        {
            row.UpdateTime = recBgnCust.UpdateDateTime.Date.ToString("yy/MM/dd"); //�폜��
            row.FilterGuid = Guid.NewGuid();

            row.InqOriginalEpCd = recBgnCust.InqOriginalEpCd;      // �⍇������ƃR�[�h
            row.InqOriginalSecCd = recBgnCust.InqOriginalSecCd;    // �⍇�������_�R�[�h
            row.InqOtherEpCd = recBgnCust.InqOtherEpCd;            // �⍇�����ƃR�[�h
            row.InqOtherSecCd = recBgnCust.InqOtherSecCd;          // �⍇���拒�_�R�[�h
            row.GoodsNo = recBgnCust.GoodsNo;                      // ���i�ԍ�
            row.GoodsMakerCode = recBgnCust.GoodsMakerCd;          // ���i���[�J�[�R�[�h
            row.GoodsApplyStaDate = recBgnCust.GoodsApplyStaDate;  // ���i�K�p�J�n��
            row.CustomerCode = recBgnCust.CustomerCode.ToString().PadLeft(8, '0');          // ���Ӑ�R�[�h
            row.CustomerName = this.GetCustomerName(recBgnCust.CustomerCode);    // ���Ӑ於;
            row.MngSectionCode = recBgnCust.MngSectionCode;        // �Ǘ����_�R�[�h
            row.MkrSuggestRtPric = recBgnCust.MkrSuggestRtPric;    // Ұ����]�������i
            row.ListPrice = recBgnCust.ListPrice;                  // �艿
            row.UnitCalcRate = recBgnCust.UnitCalcRate;            // �P���Z�o�|��
            row.UnitPrice = recBgnCust.UnitPrice;                  // �P��

            string startDate = string.Empty;                                                                    // �K�p�J�n��
            if (recBgnCust.ApplyStaDate != 0) startDate = recBgnCust.ApplyStaDate.ToString("0000/00/00");
            row.ApplyStaDate = startDate;
            string endDate = string.Empty;                                                                      // �K�p�I����
            if (recBgnCust.ApplyEndDate != 0) endDate = recBgnCust.ApplyEndDate.ToString("0000/00/00");
            row.ApplyEndDate = endDate;
            row.DisplayDivCode = recBgnCust.DisplayDivCode;
            row.BrgnGoodsGrpCode = recBgnCust.BrgnGoodsGrpCode;    // ���������i�O���[�v�R�[�h
            // --- ADD 2015/03/03 Y.Wakita Redmine#307 ---------->>>>>
            row.BrgnGoodsGrpName = GetRecBgnGrpName(string.Empty, string.Empty, recBgnCust.BrgnGoodsGrpCode);    // ���������i�O���[�v��
            // --- ADD 2015/03/03 Y.Wakita Redmine#307 ----------<<<<<
            row.RowDevelopFlg = 1;
        }

        /// <summary>
        /// RecBgnGdsPMWork->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGdsPMWork">���������i�ݒ胏�[�N</param>
        /// <returns>���������i�ݒ�</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsWork->RecBgnGds</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnCust CopyToRecBgnCustFromRecBgnCustPMWork(RecBgnCustPMWork recBgnCustPMWork)
        {
            RecBgnCust recBgnCust = new RecBgnCust();

            recBgnCust.CreateDateTime = recBgnCustPMWork.CreateDateTime;        // �쐬����
            recBgnCust.UpdateDateTime = recBgnCustPMWork.UpdateDateTime;        // �X�V����
            recBgnCust.LogicalDeleteCode = recBgnCustPMWork.LogicalDeleteCode;  // �_���폜�敪
            recBgnCust.InqOriginalEpCd = recBgnCustPMWork.InqOriginalEpCd;      // �⍇������ƃR�[�h
            recBgnCust.InqOriginalSecCd = recBgnCustPMWork.InqOriginalSecCd;    // �⍇�������_�R�[�h
            recBgnCust.InqOtherEpCd = recBgnCustPMWork.InqOtherEpCd;            // �⍇�����ƃR�[�h
            recBgnCust.InqOtherSecCd = recBgnCustPMWork.InqOtherSecCd;          // �⍇���拒�_�R�[�h
            recBgnCust.GoodsNo = recBgnCustPMWork.GoodsNo;                      // ���i�ԍ�
            recBgnCust.GoodsMakerCd = recBgnCustPMWork.GoodsMakerCd;            // ���i���[�J�[�R�[�h
            recBgnCust.GoodsApplyStaDate = recBgnCustPMWork.GoodsApplyStaDate;  // ���i�K�p�J�n��
            recBgnCust.CustomerCode = recBgnCustPMWork.CustomerCode;            // ���Ӑ�R�[�h
            recBgnCust.MngSectionCode = recBgnCustPMWork.MngSectionCode;        // �Ǘ����_�R�[�h
            recBgnCust.MkrSuggestRtPric = recBgnCustPMWork.MkrSuggestRtPric;    // Ұ����]�������i
            recBgnCust.ListPrice = recBgnCustPMWork.ListPrice;                  // �艿
            recBgnCust.UnitCalcRate = recBgnCustPMWork.UnitCalcRate;            // �P���Z�o�|��
            recBgnCust.UnitPrice = recBgnCustPMWork.UnitPrice;                  // �P��
            recBgnCust.ApplyStaDate = recBgnCustPMWork.ApplyStaDate;            // �K�p�J�n��
            recBgnCust.ApplyEndDate = recBgnCustPMWork.ApplyEndDate;            // �K�p�I����
            if (recBgnCustPMWork.DisplayDivCode == 0)
                recBgnCust.DisplayDivCode = 1;        // �\���敪
            else
                recBgnCust.DisplayDivCode = 0;        // �\���敪
            recBgnCust.BrgnGoodsGrpCode = recBgnCustPMWork.BrgnGoodsGrpCode;    // ���������i�O���[�v�R�[�h

            return recBgnCust;
        }

        /// <summary>
        /// RecBgnGds->RecBgnCustPMWork
        /// </summary>
        /// <param name="RecBgnCustPMWork">���������i���Ӑ�ʐݒ�</param>
        /// <returns>���������i���Ӑ�ʐݒ胏�[�N</returns>
        /// <remarks>
        /// <br>Note       : recBgnCust->RecBgnCustPMWork</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnCustPMWork CopyToRecBgnCustPMWorkFromRecBgnCust(RecBgnCust recBgnCust)
        {
            RecBgnCustPMWork recBgnCustPMWork = new RecBgnCustPMWork();

            recBgnCustPMWork.CreateDateTime = recBgnCust.CreateDateTime;        // �쐬����
            recBgnCustPMWork.UpdateDateTime = recBgnCust.UpdateDateTime;        // �X�V����
            recBgnCustPMWork.LogicalDeleteCode = recBgnCust.LogicalDeleteCode;  // �_���폜�敪
            recBgnCustPMWork.InqOriginalEpCd = recBgnCust.InqOriginalEpCd;      // �⍇������ƃR�[�h
            recBgnCustPMWork.InqOriginalSecCd = recBgnCust.InqOriginalSecCd;    // �⍇�������_�R�[�h
            recBgnCustPMWork.InqOtherEpCd = recBgnCust.InqOtherEpCd;            // �⍇�����ƃR�[�h
            recBgnCustPMWork.InqOtherSecCd = recBgnCust.InqOtherSecCd;          // �⍇���拒�_�R�[�h
            recBgnCustPMWork.GoodsNo = recBgnCust.GoodsNo;                      // ���i�ԍ�
            recBgnCustPMWork.GoodsMakerCd = recBgnCust.GoodsMakerCd;            // ���i���[�J�[�R�[�h
            recBgnCustPMWork.GoodsApplyStaDate = recBgnCust.GoodsApplyStaDate;  // ���i�K�p�J�n��
            recBgnCustPMWork.CustomerCode = recBgnCust.CustomerCode;            // ���Ӑ�R�[�h
            recBgnCustPMWork.MngSectionCode = recBgnCust.MngSectionCode;        // �Ǘ����_�R�[�h
            recBgnCustPMWork.MkrSuggestRtPric = recBgnCust.MkrSuggestRtPric;    // Ұ����]�������i
            recBgnCustPMWork.ListPrice = recBgnCust.ListPrice;                  // �艿
            recBgnCustPMWork.UnitCalcRate = recBgnCust.UnitCalcRate;            // �P���Z�o�|��
            recBgnCustPMWork.UnitPrice = recBgnCust.UnitPrice;                  // �P��
            recBgnCustPMWork.ApplyStaDate = recBgnCust.ApplyStaDate;            // �K�p�J�n��
            recBgnCustPMWork.ApplyEndDate = recBgnCust.ApplyEndDate;            // �K�p�I����
            if (recBgnCust.DisplayDivCode == 0)
                recBgnCustPMWork.DisplayDivCode = 1;        // �\���敪
            else
                recBgnCustPMWork.DisplayDivCode = 0;        // �\���敪
            recBgnCustPMWork.BrgnGoodsGrpCode = recBgnCust.BrgnGoodsGrpCode;    // ���������i�O���[�v�R�[�h

            return recBgnCustPMWork;
        }
        #endregion


        #endregion

        /// <summary>
        /// ���_�`�F�b�N����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="chkFlg">�K�{�`�F�b�N�敪(ture:�L,false:��)</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckSection(string sectionCode, bool chkFlg, out string errMsg, out SecInfoSet retSecInfoSet)
        {
            retSecInfoSet = null;

            bool bRet = true;
            errMsg = string.Empty;

            Int32 chkSectionCode = 0;
            Int32.TryParse(sectionCode, out chkSectionCode);
            if (chkSectionCode == 0)
            {
                if (chkFlg)
                {
                    bRet = false;
                    errMsg = "���_�R�[�h����͂��ĉ������B";
                }
            }
            else
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
                {
                    retSecInfoSet = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')];
                }
                if (retSecInfoSet == null)
                {
                    bRet = false;
                    errMsg = "���_�����݂��܂���B";
                }
            }
            return bRet;
        }

        /// <summary>
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="chkFlg">�K�{�`�F�b�N�敪(ture:�L,false:��)</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckCustomer(int customerCode, bool chkFlg, out string errMsg)
        {
            bool bRet = true;
            errMsg = string.Empty;

            if (customerCode == 0)
            {
                if (chkFlg)
                {
                    bRet = false;
                    errMsg = "���Ӑ�R�[�h����͂��ĉ������B";
                }
            }
            else
            {
                CustomerInfo customerInfo = null;
                if (this._customerDic.ContainsKey(customerCode))
                {
                    customerInfo = this._customerDic[customerCode];
                }
                if (customerInfo == null)
                {
                    bRet = false;
                    errMsg = "���Ӑ悪���݂��܂���B";
                }
                else
                {
                    bRet = false;
                    errMsg = "�A�g���Ă��链�Ӑ�ł͂���܂���B";

                    if (customerInfo.OnlineKindDiv == 0       //�I�����C����ʋ敪
                     || customerInfo.CustomerEpCode == null   //���Ӑ��ƃR�[�h
                     || customerInfo.CustomerSecCode == null) //���Ӑ拒�_�R�[�h
                    {
                        return bRet;
                    }
                    else
                    {
                        foreach (ScmEpScCnt scmEpScCnt in this._scmEpScCntList)
                        {
                            if ((scmEpScCnt.CnectOriginalEpCd == customerInfo.CustomerEpCode)
                             && (scmEpScCnt.CnectOriginalSecCd == customerInfo.CustomerSecCode))
                            {
                                bRet = true;
                                errMsg = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
            return bRet;
        }

        /// <summary>
        /// ���������i�O���[�v�`�F�b�N����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="chkFlg">�K�{�`�F�b�N�敪(ture:�L,false:��)</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckRecBgnGrp(string inqOriginalEpCd, string inqOriginalSecCd, short brgnGoodsGrpCode, bool chkFlg, out string errMsg)
        {

            bool bRet = true;
            errMsg = string.Empty;

            if (brgnGoodsGrpCode == 0)
            {
                //if (chkFlg)
                //{
                //    bRet = false;
                //    errMsg = "���������i�O���[�v�R�[�h����͂��ĉ������B";
                //}
            }
            else
            {
                RecBgnGrpRet recBgnGrpRet = null;

                if (brgnGoodsGrpCode >= 9000 && brgnGoodsGrpCode <= 9999)
                {
                    // ���X�g���猟��
                    recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                            delegate(RecBgnGrpRet mst)
                                            {
                                                return mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                            });
                }
                else
                {
                    // ���X�g���猟��
                    recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                            delegate(RecBgnGrpRet mst)
                                            {
                                                return mst.InqOriginalEpCd == inqOriginalEpCd && mst.InqOriginalSecCd == inqOriginalSecCd && mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                            });
                }
                if (recBgnGrpRet == null)
                {
                    bRet = false;
                    errMsg = "���������i�O���[�v�����݂��܂���B";
                }
            }
            return bRet;
        }
        
        /// <summary>
        /// ���_���擾
        /// </summary>
        /// <param name="SectionCode">���_�R�[�h</param>
        public string GetSectionName(string sectionCode)
        {
            string sName = string.Empty;
            SecInfoSet secInfoSet = null;
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                secInfoSet = this._secInfoSetDic[sectionCode];
            }
            if (secInfoSet != null)
            {
                sName = secInfoSet.SectionGuideNm;
            }
            return sName;
        }

        /// <summary>
        /// ���Ӑ於�擾
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public string GetCustomerName(int customerCode)
        {
            string sName = string.Empty;
            CustomerInfo customerInfo = null;
            if (this._customerDic.ContainsKey(customerCode))
            {
                customerInfo = this._customerDic[customerCode];
            }
            if (customerInfo != null)
            {
                sName = customerInfo.CustomerSnm;
            }
            return sName;
        }

        /// <summary>
        /// ���������i�O���[�v���擾
        /// </summary>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <returns></returns>
        public string GetRecBgnGrpName(string inqOriginalEpCd, string inqOriginalSecCd, short brgnGoodsGrpCode)
        {
            string sName = string.Empty;
            RecBgnGrpRet recBgnGrpRet = null;

            if (brgnGoodsGrpCode >= 9000 && brgnGoodsGrpCode <= 9999)
            {
                // ���X�g���猟��
                recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                        delegate(RecBgnGrpRet mst)
                                        {
                                            return mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                        });
            }
            else
            {
                // ���X�g���猟��
                recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                        delegate(RecBgnGrpRet mst)
                                        {
                                            return mst.InqOriginalEpCd == inqOriginalEpCd && mst.InqOriginalSecCd == inqOriginalSecCd && mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                        });
            }
            if (recBgnGrpRet != null)
                sName = recBgnGrpRet.BrgnGoodsGrpTitle;

            return sName;
        }


        #region ���i�^�p�i�t���O�擾
        /// <summary>
        ///  ���i�^�p�i�t���O�擾
        /// </summary>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="retPartsFlag">���i�^�p�i�t���O 1:�񋟕��i 0:�񋟕��i�ȊO</param>
        /// <returns>�X�e�[�^�X</returns>
        // --- UPD 2015/03/26 Y.Wakita ---------->>>>>
        //public int GetPartsArticleInfo(GoodsUnitData goodsUnitData, out int retPartsFlag)
        public int GetPartsArticleInfo(GoodsUnitData goodsUnitData, bool uPricDiv, out int retPartsFlag)
        // --- UPD 2015/03/26 Y.Wakita ----------<<<<<
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            retPartsFlag = 0;

            // ���i��񂪋�̎��͏����I��
            if (goodsUnitData == null) return status;

            switch (goodsUnitData.OfferKubun)
            {
                case 0: // ���[�U�[�o�^
                    retPartsFlag = 0;
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    break;
                case 1: // �񋟏����ҏW
                case 2: // �񋟗D�ǕҏW
                case 3: // �񋟏���
                case 4: // �񋟗D��
                    retPartsFlag = 1;
                    // --- ADD 2015/03/26 Y.Wakita ---------->>>>>
                    if (uPricDiv) retPartsFlag = 2;
                    // --- ADD 2015/03/26 Y.Wakita ----------<<<<<
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    break;
                default:
                    break;
            }

            return status;
        }
        #endregion

        //****************************************************************************//
        // ���J�J�n���A���J�I�����ꗗ�擾�ŊԎ؂�
        #region �J�n���A�I�����ꗗ�擾
        /// <summary>
        /// �J�n���A�I�����f�[�^�N���X
        /// </summary>
        public class StartEndDate
        {
            /// <summary>�J�n��</summary>
            private DateTime _startDate;

            /// <summary>�I����</summary>
            private DateTime _endDate;

            /// <summary>�J�n���v���p�e�B</summary>
            public DateTime StartDate
            {
                get { return _startDate; }
                set { _startDate = value; }
            }

            /// <summary>���J�I�����v���p�e�B</summary>
            public DateTime EndDate
            {
                get { return _endDate; }
                set { _endDate = value; }
            }
        }

        /// <summary>
        ///  ���i�^�p�i�t���O�擾
        /// </summary>
        /// <param name="openStartDate">���J�J�n��</param>
        /// <param name="openEndDate">���J�I����</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="partsInfo">���i���</param>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="startDate">�J�n��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="retOpenStartEndDateList">���J�J�n���A���J�I�����ꗗ</param>
        /// <returns>�X�e�[�^�X</returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //public int GetOpenStartEndDateList(
        //    DateTime openStartDate,
        //    DateTime openEndDate,
        //    int customerCode,
        //    string sectionCode,
        //    GoodsUnitData goodsUnitData,
        //    out List<StartEndDate> retOpenStartEndDateList)
        public int GetOpenStartEndDateList(
            DateTime openStartDate,
            DateTime openEndDate,
            int customerCode,
            string sectionCode,
            GoodsUnitData goodsUnitData,
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList,
            out List<StartEndDate> retOpenStartEndDateList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                retOpenStartEndDateList = new List<StartEndDate>();
                // �����`�F�b�N
                if (goodsUnitData == null || customerCode == 0 || string.IsNullOrEmpty(sectionCode))
                {
                    return status;
                }

                // ���t�̃`�F�b�N
                if (openStartDate == DateTime.MinValue || openEndDate == DateTime.MinValue)
                {
                    return status;
                }

                // ���i�}�X�^���i�͈͎擾����
                List<DateTime> goodsPriceRengeList = null;
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //GetGoodsPriceRengeList(
                //    ref openStartDate, ref openEndDate, ref goodsUnitData, out goodsPriceRengeList);
                GetGoodsPriceRengeList(
                    ref openStartDate, ref openEndDate, ref goodsUnitData, ref mkrSuggestRtPricList, ref mkrSuggestRtPricUList, out goodsPriceRengeList);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                // �L�����y�[���Ǘ����擾����
                List<StartEndDate> campaignMngInfoList = null;
                status = GetCampaignMngInfoList(
                    ref openStartDate, ref openEndDate, ref customerCode, ref goodsUnitData, ref sectionCode, out campaignMngInfoList);
                //if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                // ���i�ϓ��J�n���쐬
                List<StartEndDate> costFluctuationList = null;
                CreateCostFluctuationList(ref openStartDate, ref openEndDate, ref campaignMngInfoList, out costFluctuationList);

                // ���i�ϓ��ꗗ����
                retOpenStartEndDateList = null;
                MergeCostFluctuationList(ref openStartDate, ref openEndDate, ref goodsPriceRengeList, ref costFluctuationList, out retOpenStartEndDateList);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                retOpenStartEndDateList = new List<StartEndDate>();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        ///  ���i�}�X�^���i�͈͎擾
        /// </summary>
        /// <param name="openStartDate">���J�J�n��</param>
        /// <param name="openEndDate">���J�I����</param>
        /// <param name="partsInfo">���i���</param>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="startDate">�J�n��</param>
        /// <param name="goodsPriceRengeList">���J�J�n���A���J�I�����ꗗ</param>
        /// <returns>�X�e�[�^�X</returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //private void GetGoodsPriceRengeList(
        //    ref DateTime openStartDate,
        //    ref DateTime openEndDate,
        //    ref GoodsUnitData goodsUnitData,
        //    out List<DateTime> retGoodsPriceRengeList)
        private void GetGoodsPriceRengeList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref GoodsUnitData goodsUnitData,
            ref Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            ref Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList,
            out List<DateTime> retGoodsPriceRengeList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            retGoodsPriceRengeList = new List<DateTime>();
            int findResult = -1;

            if (goodsUnitData == null) return;

            DateTime tempDate;

            // �艿�ꗗ�擾
            if (goodsUnitData.GoodsPriceList != null)
            {
                foreach (GoodsPrice priceData in goodsUnitData.GoodsPriceList)
                {
                    tempDate = priceData.PriceStartDate;
                    if (tempDate < openStartDate)
                    {
                        // ���J�J�n���ȑO�̃f�[�^�͔j������
                        continue;
                    }
                    else if (openEndDate < tempDate)
                    {
                        // ���J�I�����ȍ~�̃f�[�^�͔j������
                        continue;
                    }

                    findResult = retGoodsPriceRengeList.IndexOf(tempDate);
                    // �J�n�������o�^�̏ꍇ�̂ݓo�^����
                    if (findResult == -1) retGoodsPriceRengeList.Add(tempDate);
                }
            }
            // --- DEL 2015/03/25 Y.Wakita ---------->>>>>
            #region �폜
            //// ���[�J�[��]�������i�ꗗ�擾
            //if (goodsUnitData.MkrSuggestRtPricList != null)
            //{
            //    foreach (GoodsPrice priceData in goodsUnitData.MkrSuggestRtPricList)
            //    {
            //        tempDate = priceData.PriceStartDate;
            //        if (tempDate < openStartDate)
            //        {
            //            // ���J�J�n���ȑO�̃f�[�^�͔j������
            //            continue;
            //        }
            //        else if (openEndDate < tempDate)
            //        {
            //            // ���J�I�����ȍ~�̃f�[�^�͔j������
            //            continue;
            //        }

            //        findResult = retGoodsPriceRengeList.IndexOf(tempDate);
            //        // �J�n�������o�^�̏ꍇ�̂ݓo�^����
            //        if (findResult == -1) retGoodsPriceRengeList.Add(tempDate);
            //    }
            //}
            #endregion
            // --- DEL 2015/03/25 Y.Wakita ----------<<<<<
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            // ���[�J�[��]�������i�擾
            if (mkrSuggestRtPricList != null && mkrSuggestRtPricList.Count != 0)
            {
                Calculator.GoodsInfoKey goodsInfoKey = new Calculator.GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
                if (mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    //// ���[�J�[��]�������i���X�g������ɊY�����鉿�i���擾
                    List<GoodsPrice> _mkrSuggestRtPricList = mkrSuggestRtPricList[goodsInfoKey];
                    foreach (GoodsPrice priceData in _mkrSuggestRtPricList)
                    {
                        tempDate = priceData.PriceStartDate;
                        if (tempDate < openStartDate)
                        {
                            // ���J�J�n���ȑO�̃f�[�^�͔j������
                            continue;
                        }
                        else if (openEndDate < tempDate)
                        {
                            // ���J�I�����ȍ~�̃f�[�^�͔j������
                            continue;
                        }

                        findResult = retGoodsPriceRengeList.IndexOf(tempDate);
                        // �J�n�������o�^�̏ꍇ�̂ݓo�^����
                        if (findResult == -1) retGoodsPriceRengeList.Add(tempDate);
                    }
                }
            }
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            // �J�n���Ń\�[�g
            retGoodsPriceRengeList.Sort(delegate(DateTime x, DateTime y)
                {
                    return DateTime.Compare(x, y);
                }
            );
        }

        /// <summary>
        ///  �L�����y�[���Ǘ����擾
        /// </summary>
        /// <param name="openStartDate">���J�J�n��</param>
        /// <param name="openEndDate">���J�I����</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="partsInfo">���i���</param>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="startDate">�J�n��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="retCampaignMngInfoList">�L�����y�[�����i�J�n���A���i�I�����ꗗ</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetCampaignMngInfoList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref int customerCode,
            ref GoodsUnitData goodsUnitData,
            ref string sectionCode,
            out List<StartEndDate> retCampaignMngInfoList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            retCampaignMngInfoList = new List<StartEndDate>();

            List<CampaignObjGoodsSt> campaignMngList = null;
            CampaignObjGoodsStAcs campaignObjGoodsStAcs = CampaignObjGoodsStAcs.GetInstance();
            List<CampaignObjGoodsSt> campaignItemList = new List<CampaignObjGoodsSt>();

            status = campaignObjGoodsStAcs.Search(out campaignMngList, this._enterpriseCode, ConstantManagement.LogicalMode.GetData0);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

            if (campaignMngList != null)
            {
                foreach (CampaignObjGoodsSt data in campaignMngList)
                {

                    // // �L�����y�[����ʂɂ�镪��
                    switch (data.CampaignSettingKind)
                    {
                        case 1: // 1:Ұ��+�i��
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                                && data.GoodsNo.Trim().Equals(goodsUnitData.GoodsNo.Trim()))
                            {
                                // �K�p�L�����y�[�����Ƃ��ĕۑ�
                                campaignItemList.Add(data);
                            }
                            break;
                        case 2: // 2:Ұ��+BL
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                                 && (data.BLGoodsCode == goodsUnitData.BLGoodsCode))
                            {
                                // �K�p�L�����y�[�����Ƃ��ĕۑ�
                                campaignItemList.Add(data);
                            }
                            break;
                        case 3: // 3:Ұ��+��ٰ��
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                                 && (data.BLGroupCode == goodsUnitData.BLGroupCode))
                            {
                                // �K�p�L�����y�[�����Ƃ��ĕۑ�
                                campaignItemList.Add(data);
                            }
                            break;
                        case 4: // 4:Ұ��
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd)
                            {
                                // �K�p�L�����y�[�����Ƃ��ĕۑ�
                                campaignItemList.Add(data);
                            }
                            break;
                        case 5: // 5:BL����
                            if (data.BLGoodsCode == goodsUnitData.BLGoodsCode)
                            {
                                // �K�p�L�����y�[�����Ƃ��ĕۑ�
                                campaignItemList.Add(data);
                            }
                            break;
                        default: // ���̑��͓o�^�ΏۂƂ��Ȃ�
                            break;
                    }
                }

                if (campaignItemList.Count == 0)
                {
                    // �ΏۃL�����y�[����񂪂Ȃ��ꍇ�A�����I��
                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                // �����D��ݒ�擾
                CampaignPrcPrStAcs campaignPrcPrStAcs = new CampaignPrcPrStAcs();
                ArrayList campaignPrcPrStAcsList = null;
                CampaignPrcPrSt sectionPrcPrSt = null;
                CampaignPrcPrSt allSectionPrcPrSt = null;

                status = campaignPrcPrStAcs.SearchAll(out campaignPrcPrStAcsList, this._enterpriseCode);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                foreach (CampaignPrcPrSt campaignPrcPrSt in campaignPrcPrStAcsList)
                {
                    if (campaignPrcPrSt.LogicalDeleteCode == 1) continue;

                    // �����_�̔����D��ݒ�擾
                    if (campaignPrcPrSt.SectionCode.Trim().Equals(sectionCode.Trim())) sectionPrcPrSt = campaignPrcPrSt;
                    // �S���_�̔����D��ݒ�擾
                    if (campaignPrcPrSt.SectionCode.Trim().Equals(ALL_SECTION_CODE)) allSectionPrcPrSt = campaignPrcPrSt;
                }

                // �����_�̔����D��ݒ�擾���Ȃ��ꍇ�A���ʂ̐ݒ���g�p
                if (sectionPrcPrSt == null) sectionPrcPrSt = allSectionPrcPrSt;

                if (sectionPrcPrSt == null)
                {
                    // ���ʂ̐ݒ���Ȃ��ꍇ�A�f�t�H���g�̐ݒ���g�p
                    // �f�t�H���g�̗D�揇�ʁ@1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL���
                    sectionPrcPrSt = new CampaignPrcPrSt();
                    sectionPrcPrSt.PrioritySettingCd1 = 1;
                    sectionPrcPrSt.PrioritySettingCd2 = 2;
                    sectionPrcPrSt.PrioritySettingCd3 = 3;
                    sectionPrcPrSt.PrioritySettingCd4 = 4;
                    sectionPrcPrSt.PrioritySettingCd5 = 5;
                }

                // �L�����y�[�����\�[�g
                campaignItemList.Sort(delegate(CampaignObjGoodsSt x, CampaignObjGoodsSt y)
                    {
                        int compareResult = x.CampaignSettingKind.CompareTo(y.CampaignSettingKind);
                        // �L�����y�[���ݒ��ʔ�r
                        if (compareResult != 0)
                        {
                            if (sectionPrcPrSt.PrioritySettingCd1 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd1 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd2 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd2 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd3 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd3 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd4 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd4 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd5 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd5 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd6 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd6 == y.CampaignSettingKind) return 1;
                        }
                        else
                        {
                            // ���_�R�[�h��r
                            compareResult = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                            if (compareResult != 0)
                            {
                                // ���ʂ̏ꍇ�D��x��������
                                if (x.SectionCode.Trim().Equals(ALL_SECTION_CODE)) return 1;
                            }
                            else
                            {
                                // ���Ӑ��r
                                compareResult = y.CustomerCode.CompareTo(x.CustomerCode);
                                if (compareResult != 0)
                                {
                                    // ���ʂ̏ꍇ�D��x��������
                                    if (x.SectionCode.Trim().Equals("00000000")) return 1;
                                }
                                else
                                {
                                    // ���i�J�n����r
                                    compareResult = x.PriceStartDate.CompareTo(y.PriceStartDate);
                                }
                            }
                        }
                        // ��r���ʕԋp
                        return compareResult;
                    }
                );

                StartEndDate addData;
                DateTime dt;
                foreach (CampaignObjGoodsSt campaignObjGoodsSt in campaignItemList)
                {

                    if (campaignObjGoodsStAcs.CampaignStDic == null || campaignObjGoodsStAcs.CampaignStDic.Count == 0)
                    {
                        campaignObjGoodsStAcs.LoadCampaignSt();
                    }

                    bool searchFlg = true;
                    if (campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaignObjGoodsSt.CampaignCode))
                    {
                        Dictionary<int, CampaignSt> campaignStDic = campaignObjGoodsStAcs.CampaignStDic;
                        CampaignSt campaignSt = campaignStDic[campaignObjGoodsSt.CampaignCode];

                        // �L�����y�[���Ώۓ��Ӑ�ݒ���Q��
                        if (campaignSt.CampaignObjDiv == 0)
                        {
                            // �L�����y�[���Ώۋ敪�F"�S���Ӑ�" //�Ȃ��B
                        }
                        else if (campaignSt.CampaignObjDiv == 1)
                        {
                            // �L�����y�[���Ώۋ敪�F"�Ώۓ��Ӑ�"
                            ArrayList retList;
                            CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                            status = campaignLinkAcs.SearchDetail(out retList, this._enterpriseCode, campaignSt.CampaignCode);

                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                            foreach (CampaignLink campaignLink in retList)
                            {
                                if (campaignLink.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }

                                if (campaignLink.CustomerCode != customerCode)
                                {
                                    // �L�����y�[���֘A�̓��Ӑ�ƈ�v���Ȃ�
                                    searchFlg = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (searchFlg)
                    {
                        addData = new StartEndDate();
                        if (DateTime.TryParseExact(campaignObjGoodsSt.PriceStartDate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            addData.StartDate = dt;
                            if (DateTime.TryParseExact(campaignObjGoodsSt.PriceEndDate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                addData.EndDate = dt;
                                retCampaignMngInfoList.Add(addData);
                            }
                        }
                    }
                }
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        ///  �L�����y�[�����i�͈͎擾
        /// </summary>
        /// <param name="openStartDate">���J�J�n��</param>
        /// <param name="openEndDate">���J�I����</param>
        /// <param name="campaignMngInfoList">�K�p�L�����y�[�����̊J�n�I�������</param>
        /// <param name="campaignPriceFromToList">�T�}�������J�n�I�������</param>
        private void CreateCostFluctuationList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref List<StartEndDate> campaignMngInfoList,
            out List<StartEndDate> campaignPriceFromToList)
        {
            campaignPriceFromToList = new List<StartEndDate>();

            StartEndDate checkData;

            // �K�p�L�����y�[�����Ȃ��ꍇ�́A�����l�Ƃ��ē��͂������J�J�n���E���J�I������ԋp����B
            if (campaignMngInfoList.Count == 0)
            {
                checkData = new StartEndDate();
                checkData.StartDate = openStartDate;
                checkData.EndDate = openEndDate;
                campaignPriceFromToList.Add(checkData);
                return;
            }

            foreach (StartEndDate campaignMngInfo in campaignMngInfoList)
            {

                // �L�����y�[�����i�J�n�����A���J�I��������̏ꍇ�͏��O
                if (campaignMngInfo.StartDate > openEndDate) continue;
                // �L�����y�[�����i�I�������A���J�J�n�����O�̏ꍇ�͏��O
                if (campaignMngInfo.EndDate < openStartDate) continue;

                // �L�����y�[�����i�J�n�������J�J�n�����O�̏ꍇ�͌��J�J�n�����L�����y�[�����i�J�n���ɕύX����
                if (campaignMngInfo.StartDate < openStartDate) campaignMngInfo.StartDate = openStartDate;
                // �L�����y�[�����i�I���������J�I��������̏ꍇ�͌��J�I�������L�����y�[�����i�I�����Ƃ���
                if (campaignMngInfo.EndDate > openEndDate) campaignMngInfo.EndDate = openEndDate;

                DateTime startDate = DateTime.MinValue;
                DateTime lastDate = DateTime.MinValue;

                bool isOK = false;

                DateTime i = campaignMngInfo.StartDate;
                while (i <= campaignMngInfo.EndDate)
                {
                    // �����ɃL�����y�[�����Ԑݒ�\���𔻒�
                    isOK = CanAddCampaignTerm(campaignPriceFromToList, i);

                    if (isOK)
                    {
                        // �J�n����ݒ�
                        if (startDate == DateTime.MinValue)
                        {
                            startDate = i;
                        }
                        // �ݒ�\�ȍŏI����ޔ�
                        lastDate = i;
                    }
                    else
                    {
                        // �L�����y�[���ݒ�s�̏ꍇ�͍ŏI�ݒ�\����ݒ肵�ăL�����y�[�����Ԃ�ǉ�
                        if (startDate != DateTime.MinValue)
                        {
                            // �ǉ�
                            StartEndDate andDate = new StartEndDate();
                            andDate.StartDate = startDate;
                            andDate.EndDate = lastDate;
                            campaignPriceFromToList.Add(andDate);

                            // ������
                            startDate = DateTime.MinValue;
                            lastDate = DateTime.MinValue;
                        }
                    }

                    // ����
                    i = i.AddDays(1);
                }

                if (isOK)
                {
                    // �ŏI�f�[�^�̒ǉ�
                    StartEndDate andDate = new StartEndDate();
                    andDate.StartDate = startDate;
                    andDate.EndDate = lastDate;
                    campaignPriceFromToList.Add(andDate);
                }
            }

            // �J�n���Ń\�[�g
            campaignPriceFromToList.Sort(delegate(StartEndDate x, StartEndDate y)
                {
                    return DateTime.Compare(x.StartDate, y.StartDate);
                }
            );
        }

        /// <summary>
        /// �L�����y�[���ǉ��\�����`�F�b�N
        /// </summary>
        /// <param name="campaignPriceFromToList">�`�F�b�N�Ώۃ��X�g</param>
        /// <param name="checkDate">�`�F�b�N�Ώۓ�</param>
        /// <returns>true:�� false:�s��</returns>
        private bool CanAddCampaignTerm(List<StartEndDate> campaignPriceFromToList, DateTime checkDate)
        {
            foreach (StartEndDate campaingPriceFromTo in campaignPriceFromToList)
            {
                if ((campaingPriceFromTo.StartDate <= checkDate) && (checkDate <= campaingPriceFromTo.EndDate)) return false;
            }
            return true;
        }

        /// <summary>
        ///  ���i�ϓ��ꗗ����
        /// </summary>
        /// <param name="openStartDate">���J�J�n��</param>
        /// <param name="openEndDate">���J�I����</param>
        /// <param name="goodsPriceRengeList">���i�}�X�^�J�n�����X�g</param>
        /// <param name="campaignPriceFromToList">�L�����y�[�����i���ԃ��X�g</param>
        /// <param name="retOpenStartEndDateList">���J���ԃ��X�g</param>
        private void MergeCostFluctuationList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref List<DateTime> goodsPriceRengeList,
            ref List<StartEndDate> campaignPriceFromToList,
            out List<StartEndDate> retOpenStartEndDateList)
        {
            // ���L�����y�[�����i���ԃ��X�g�̒���
            if (campaignPriceFromToList.Count > 0)
            {
                DateTime campaignFirstDate = campaignPriceFromToList[0].StartDate;
                DateTime campaignEndDate = campaignPriceFromToList[campaignPriceFromToList.Count - 1].EndDate;

                // ���J�J�n������L�����y�[�����i�J�n���܂ł̊��Ԃ�ǉ�����
                if (openStartDate < campaignFirstDate)
                {
                    // ���J�J�n������擪�f�[�^�̊J�n��-1���̃f�[�^��ǉ�����
                    StartEndDate dummyDate = new StartEndDate();
                    dummyDate.StartDate = openStartDate;
                    dummyDate.EndDate = campaignFirstDate.AddDays(-1);
                    campaignPriceFromToList.Add(dummyDate);
                }

                // �L�����y�[�����i�I����������J�I�����܂ł̊��Ԃ�ǉ�����
                if (openEndDate > campaignEndDate)
                {
                    // ���J�J�n������擪�f�[�^�̊J�n��-1���̃f�[�^��ǉ�����
                    StartEndDate dummyDate = new StartEndDate();
                    dummyDate.StartDate = campaignEndDate.AddDays(1);
                    dummyDate.EndDate = openEndDate;
                    campaignPriceFromToList.Add(dummyDate);
                }

                // �L�����y�[�����i���ԃ��X�g���J�n���Ń\�[�g
                campaignPriceFromToList.Sort(delegate(StartEndDate x, StartEndDate y) { return DateTime.Compare(x.StartDate, y.StartDate); });
            }
            else
            {
                // �L�����y�[�����i���ԃ��X�g���Ȃ��ꍇ�̓_�~�[���Ԃ��쐬
                // ���J�J�n������擪�f�[�^�̊J�n��-1���̃f�[�^��ǉ�����
                StartEndDate dummyDate = new StartEndDate();
                dummyDate.StartDate = openStartDate;
                dummyDate.EndDate = openEndDate;
                campaignPriceFromToList.Add(dummyDate);
            }

            // ���󔒊��ԂɊJ�n�I����ݒ�
            List<StartEndDate> retTempList = new List<StartEndDate>();
            DateTime oldStartdate = DateTime.MinValue;
            DateTime oldEnddate = DateTime.MinValue;
            foreach (StartEndDate retStartEndDate in campaignPriceFromToList)
            {
                // 1���ڂ͓ǂݔ�΂�
                if (oldStartdate != DateTime.MinValue)
                {
                    if (oldEnddate.AddDays(1) != retStartEndDate.StartDate)
                    {
                        // �ǉ�
                        StartEndDate addStartEndDate = new StartEndDate();
                        addStartEndDate.StartDate = oldEnddate.AddDays(1);
                        addStartEndDate.EndDate = retStartEndDate.StartDate.AddDays(-1);
                        retTempList.Add(addStartEndDate);
                    }
                }
                retTempList.Add(retStartEndDate);
                // ���Ԃ�ۊ�
                oldStartdate = retStartEndDate.StartDate;
                oldEnddate = retStartEndDate.EndDate;
            }

            // �T�}�����ԃ��X�g���J�n���Ń\�[�g
            retTempList.Sort(delegate(StartEndDate x, StartEndDate y) { return DateTime.Compare(x.StartDate, y.StartDate); });

            // ���L�����y�[���Ə��i�̊��Ԃ��T�}������
            retOpenStartEndDateList = new List<StartEndDate>();
            foreach (StartEndDate campaignPriceFromTo in retTempList)
            {
                bool addFlg = false;
                DateTime nowStartDate = campaignPriceFromTo.StartDate;
                foreach (DateTime goodsStartDate in goodsPriceRengeList)
                {
                    DateTime firstStartDate = DateTime.MinValue;
                    DateTime firstEndDate = DateTime.MinValue;
                    DateTime secondStartDate = DateTime.MinValue;
                    DateTime secondEndDate = DateTime.MinValue;

                    // �L�����y�[���J�n�����ȍ~�ɏ��i���i�J�n�̏ꍇ
                    if (nowStartDate < goodsStartDate)
                    {
                        // �L�����y�[�����i�I������
                        if (goodsStartDate == campaignPriceFromTo.EndDate)
                        {
                            firstStartDate = nowStartDate;
                            firstEndDate = goodsStartDate.AddDays(-1);
                            secondStartDate = goodsStartDate;
                            secondEndDate = campaignPriceFromTo.EndDate;
                            addFlg = true;
                        }
                        // �L�����y�[�����i�I���O���ȑO
                        else if (goodsStartDate < campaignPriceFromTo.EndDate)
                        {
                            firstStartDate = nowStartDate;
                            firstEndDate = goodsStartDate.AddDays(-1);
                            secondStartDate = goodsStartDate;
                            secondEndDate = campaignPriceFromTo.EndDate;
                            addFlg = true;
                        }
                    }

                    // �������Ԃ��쐬
                    if (addFlg)
                    {
                        // ���X�g�Ō���i�J�n������Ԓx���j���Ԃ��폜
                        if (retOpenStartEndDateList.Count > 0) retOpenStartEndDateList.Remove(retOpenStartEndDateList[retTempList.Count - 1]);

                        // �����f�[�^���쐬(�O��)
                        StartEndDate firstDate = new StartEndDate();
                        firstDate.StartDate = firstStartDate;
                        firstDate.EndDate = firstEndDate;
                        retOpenStartEndDateList.Add(firstDate);

                        // �㕔
                        StartEndDate secondDate = new StartEndDate();
                        secondDate.StartDate = secondStartDate;
                        secondDate.EndDate = secondEndDate;
                        retOpenStartEndDateList.Add(secondDate);

                        // �O���̏I�������i����J�n���j��ޔ�
                        nowStartDate = firstEndDate.AddDays(1);
                    }
                }
                // �������̏ꍇ�̓L�����y�[�����Ԃ�ݒ�
                if (addFlg != true) retOpenStartEndDateList.Add(campaignPriceFromTo);
            }

            // �J�n���Ń\�[�g
            retOpenStartEndDateList.Sort(delegate(StartEndDate x, StartEndDate y) { return DateTime.Compare(x.StartDate, y.StartDate); });
        }

        #endregion

    }

    /// <summary>
    /// ���������i�ݒ�f�[�^��r�N���X(���_(����)�A���[�J�[(����)�A�i��(����)�A���J�J�n��(����))
    /// </summary>
    public class RecBgnGdsAsComparer : Comparer<RecBgnGdsPMWork>
    {
        /// <summary>
        /// ��r����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(RecBgnGdsPMWork x, RecBgnGdsPMWork y)
        {
            int result = 0;

            // ���_
            result = x.InqOtherSecCd.CompareTo(y.InqOtherSecCd);
            if (result != 0) return result;

            // ���[�J�[
            result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
            if (result != 0) return result;

            // �i��
            result = x.GoodsNo.CompareTo(y.GoodsNo);
            if (result != 0) return result;

            // ���J�J�n��
            result = x.ApplyStaDate.CompareTo(y.ApplyStaDate);

            return result;
        }
    }

    /// <summary>
    /// ���Ӑ�ʐݒ���p�N���X
    /// </summary>
    public class RecBgnGdsCustInfo
    {
        public RecBgnGdsDataSet.RecBgnGdsRow recBgnGdsRow;
        public RecBgnGdsDataSet.RecBgnCustDataTable recBgnCust;
    }


}