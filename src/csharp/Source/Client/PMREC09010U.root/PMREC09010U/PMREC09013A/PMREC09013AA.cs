//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�̕ێ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/01/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/02/10  �C�����e : �@BL�R�[�h���͎��ɏ��i�R�����g(��)��\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/02  �C�����e : Redmine#296
//                                  �S���Ӑ���w�肵�ăT���v���捞�����ꍇ�A���Ӑ�E����ƁE�����_�Ƀ[�����Z�b�g
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/03  �C�����e : Redmine#297
//                                  ������BL�R�[�h�ƃp�[�c�����ɓ��͂��Ȃ��ꍇ�͐V�K�s�i�o�^�s�v�s�j�Ɣ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/06  �C�����e : Redmine#338 �S���Ӑ�ݒ���e��萔��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �{�{����
// �� �� ��  2015/03/09  �C�����e : Redmine#338 �u�S���Ӑ�v���u�S���Ӑ拤�ʁv
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
    /// ���R�����h���i�֘A�ݒ�}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^ �A�N�Z�X�N���X</br>
    /// <br>Programmer : �{�{����</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public class RecGoodsLkStAcs
    {
        #region Private Member
        private static RecGoodsLkStAcs _RecGoodsLkStAcs = null;

        private RecGoodsLkDataSet _dataSet;
        private RecGoodsLkDataSet.RecGoodsLkDataTable _recGoodsLkDataTable;
        private Dictionary<Guid, RecGoodsLkSt> _prevRecGoodsLkDic = new Dictionary<Guid, RecGoodsLkSt>();
        private IRecGoodsLkDB _iRecGoodsLkDB = null;

        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        private const int DELETEFLG_DEFAULT = 0;       // �ʏ�
        private const int DELETEFLG_DELETE = 1;       // �폜
        private const int DELETEFLG_REVIVAL = 2;       // ����
        private const int DELETEFLG_SAMPLE = 9;       // �T���v���捞

        private IRecGoodsLkODB _IRecGoodsLkODB = null;

        private string _sampleSecCd = string.Empty;
        private string _sampleSecNm = string.Empty;
        public string SampleSecCd
        {
            get { return this._sampleSecCd; }
            set { this._sampleSecCd = value; }
        }
        public string SampleSecNm
        {
            get { return this._sampleSecNm; }
            set { this._sampleSecNm = value; }
        }

        private CustomerInfo _sampleCustomerInfo = null;
        public CustomerInfo SampleCustomerInfo
        {
            get { return this._sampleCustomerInfo; }
            set { this._sampleCustomerInfo = value; }
        }
        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<
        // --- ADD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
        public const string ALL_CUSTOMERCODE = "00000000";
        public const string ALL_CUSTOMERNAME = "�S���Ӑ拤��"; // UPD 2015/03/09 T.Miyamoto Redmine#338 �u�S���Ӑ�v���u�S���Ӑ拤�ʁv
        public const string ALL_ORIGINALEPCD = "0000000000000000";
        public const string ALL_ORIGINALSECCD = "000000";
        // --- ADD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>�������ʏ�</summary>
        private string _statusOfResult = string.Empty;

        private SecInfoAcs _secInfoAcs = null; // ���_���A�N�Z�X�N���X

        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>SFCMN09062A)���[�U�[�K�C�h</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>PMREC09013A)���Ӑ�</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary> SCM��ƘA���f�[�^�A�N�Z�X�N���X </summary>
        private ScmEpScCntAcs _scmEpScCntAcs;

        //private IWin32Window _owner = null;

        private Dictionary<string, SecInfoSet> _secInfoSetDic = new Dictionary<string, SecInfoSet>(); // ���_���f�B�N�V���i���[
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();  // BL�R�[�h�}�X�^�f�B�N�V���i���[
        private Dictionary<int, UserGdBd> _userGdBdDic = new Dictionary<int, UserGdBd>();             // ���[�U�[�K�C�h�f�B�N�V���i���[
        private Dictionary<int, CustomerInfo> _customerDic = new Dictionary<int, CustomerInfo>();     // ���Ӑ�f�B�N�V���i���[
        private List<ScmEpScCnt> _scmEpScCntList = new List<ScmEpScCnt>();

        private List<RecGoodsLkSt> _recGoodsLkList = new List<RecGoodsLkSt>();

        // ���R�����h���i�֘A�ݒ�f�[�^���X�g
        //private List<RecGoodsLkSt> _RecGoodsLkStList = null;

        //true:�폜�w��敪=1�Afalse:�폜�w��敪=0
        private bool _deleteSearchMode = false;

        /// <summary>// true:���[�J���Q�� false:�T�[�o�[�Q��</summary>
        public static readonly bool ctIsLocalDBRead = false;

        private RecGoodsLkSt _newRecGoodsLkObj = new RecGoodsLkSt(); // �V�K�s�̏ꍇ�p

        private Thread _masterAcsThread;   // �}�X�^�f�[�^�擾�X���b�h

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
        /// �O���b�h�e�[�u���v���p�e�B
        /// </summary>
        public RecGoodsLkDataSet.RecGoodsLkDataTable RecGoodsLkDataTable
        {
            get { return this._recGoodsLkDataTable; }
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<Guid, RecGoodsLkSt> PrevRecGoodsLkDic
        {
            get { return this._prevRecGoodsLkDic; }
        }

        /// <summary>
        /// �a�k�R�[�h�}�X�^�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public Dictionary<int, BLGoodsCdUMnt> BLGoodsCdDic
        {
            get { return this._blGoodsCdDic; }
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
        /// ���R�����h���i�֘A�ݒ�f�B�N�V���i���[�v���p�e�B
        /// </summary>
        public List<RecGoodsLkSt> RecGoodsLkList
        {
            get { return this._recGoodsLkList; }
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�v���p�e�B�A�V�K�s�̏ꍇ�p
        /// </summary>
        public RecGoodsLkSt NewRecGoodsLkObj
        {
            get { return _newRecGoodsLkObj; }
            set { _newRecGoodsLkObj = value; }
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
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^ �A�N�Z�X�N���X</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public RecGoodsLkStAcs()
        {
            this._dataSet = new RecGoodsLkDataSet();
            this._recGoodsLkDataTable = this._dataSet.RecGoodsLk;
            this._secInfoAcs = new SecInfoAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._iRecGoodsLkDB = (IRecGoodsLkDB)MediationRecGoodsLkDB.GetRecGoodsLkDB();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._IRecGoodsLkODB = (IRecGoodsLkODB)MediationRecGoodsLkODB.GetRecGoodsLkODB(); // ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ�
        }
        #endregion

        #region Public Method
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public static RecGoodsLkStAcs GetInstance()
        {
            if (_RecGoodsLkStAcs == null)
            {
                _RecGoodsLkStAcs = new RecGoodsLkStAcs();
            }

            return _RecGoodsLkStAcs;
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int Search(SearchCondition searchCondition, out int count, out string msg)
        {
            int status = 0;
            count = 0;
            msg = string.Empty;

            ArrayList recGoodsLkList = null;
            RecGoodsLkWork recGoodsLkWork = this.CopyToSearchConditionWorkFromSearchCondition(searchCondition);

            try
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    status = this.SearchPrc(out recGoodsLkList, recGoodsLkWork, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
                }
                else
                {
                    status = this.SearchPrc(out recGoodsLkList, recGoodsLkWork, ConstantManagement.LogicalMode.GetData1, out count, ref msg);
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

                if (recGoodsLkList != null && recGoodsLkList.Count > 0)
                {
                    this.SettingDetailRowAfterSearch(recGoodsLkList);
                }
            }
            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retArray">���R�����h���i�֘A�ݒ�}�X�^�f�[�^</param>
        /// <param name="searchConditionWork">���������N���X</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="count">count</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int SearchPrc(out ArrayList retArray, RecGoodsLkWork recGoodsLkWork, ConstantManagement.LogicalMode logicalMode, out int count, ref string msg)
        {
            int status = 0;
            count = 0;
            try
            {
                ArrayList recGoodsLkList = null;
                object retObj = recGoodsLkList as object;

                object paraObj = recGoodsLkWork as object;
                status = this._iRecGoodsLkDB.SearchRcmd(out retObj, paraObj, 0, logicalMode, out count, ref msg);

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
        /// <param name="retArray">���R�����h���i�֘A�ݒ�}�X�^�f�[�^</param>
        /// <param name="RecGoodsLkSt">���������N���X</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int Read(out ArrayList retArray, RecGoodsLkSt RecGoodsLkSt, ref string msg)
        {
            int status = 0;
            try
            {
                ArrayList recGoodsLkList = null;
                object retObj = recGoodsLkList as object;

                //RecGoodsLkStWork RecGoodsLkStWork = this.CopyToRecGoodsLkWorkFromRecGoodsLk(RecGoodsLkSt);
                //object paraObj = RecGoodsLkStWork as object;
                //status = this._iRecGoodsLkStDB.Read(ref retObj, 0, ConstantManagement.LogicalMode.GetData0);
                //status = this._iRecGoodsLkDB.Read(out retObj, paraObj, ref msg);
                //status = this._iCampaignObjGoodsStDB.Read(out retObj, paraObj, ref msg);
                status = this._iRecGoodsLkDB.Read(ref retObj, 0, ConstantManagement.LogicalMode.GetData0);

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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void DetailRowInitialSetting(int defaultRowCount)
        {
            this.RecGoodsLkDataTable.BeginLoadData();
            this.RecGoodsLkDataTable.Clear();
            this._deleteSearchMode = false;

            for (int i = 1; i <= defaultRowCount; i++)
            {
                RecGoodsLkDataSet.RecGoodsLkRow row = this.RecGoodsLkDataTable.NewRecGoodsLkRow();
                row.RowNo = i;
                row.FilterGuid = Guid.Empty;
                //row.GoodsName = "";
                row.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                row.InqOtherEpCd = this._enterpriseCode;
                //row.InqOtherSecCd = this._loginSectionCode;
                this.RecGoodsLkDataTable.AddRecGoodsLkRow(row);
            }
            this.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1], ref this._newRecGoodsLkObj);
            this.RecGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <param name="updateList">�o�^�E�X�V���X�g</param>
        /// <param name="RecGoodsLkSt">�G���[�I�u�W�F�N�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int SaveProc(List<RecGoodsLkSt> deleteList, List<RecGoodsLkSt> updateList, out RecGoodsLkSt RecGoodsLkSt)
        {
            int status = 0;
            RecGoodsLkSt = null;
            ArrayList delList = new ArrayList();
            ArrayList UpdList = new ArrayList();

            RecGoodsLkWork recGoodsLkWork = null;
            foreach (RecGoodsLkSt recGoodsLk in deleteList)
            {
                recGoodsLkWork = this.CopyToRecGoodsLkWorkFromRecGoodsLk(recGoodsLk);
                delList.Add(recGoodsLkWork);
            }
            foreach (RecGoodsLkSt recGoodsLk in updateList)
            {
                recGoodsLkWork = this.CopyToRecGoodsLkWorkFromRecGoodsLk(recGoodsLk);
                UpdList.Add(recGoodsLkWork);
            }

            object paraDelObj = delList as object;
            object paraUpdObj = UpdList as object;
            if (this._deleteSearchMode == false)
            {
//                status = this._iRecGoodsLkDB.WriteRcmd(ref paraUpdObj);

                object errorObj = null;
                status = this._iRecGoodsLkDB.DeleteAndWrite(paraDelObj, ref paraUpdObj, out errorObj);
                if (errorObj != null)
                {
                    RecGoodsLkWork errorWork = errorObj as RecGoodsLkWork;
                    RecGoodsLkSt = this.CopyToRecGoodsLkFromRecGoodsLkWork(errorWork);
                }
            }
            else
            {
                status = this._iRecGoodsLkDB.DeleteAndRevival(paraDelObj, ref paraUpdObj);
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void SettingDetailRowAfterSearch(ArrayList retList)
        {
            this.RecGoodsLkDataTable.BeginLoadData();
            this._recGoodsLkDataTable.Clear();
            RecGoodsLkSt RecGoodsLkSt = null;

            // �o�^�ύs�̒ǉ�
            for (int i = 1; i <= retList.Count; i++)
            {
                RecGoodsLkSt = this.CopyToRecGoodsLkFromRecGoodsLkWork((RecGoodsLkWork)retList[i - 1]);
                RecGoodsLkDataSet.RecGoodsLkRow row = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                row.RowNo = i;
                this.CopyToDetailRowFromRecGoodsLk(ref row, RecGoodsLkSt);

                this._recGoodsLkDataTable.AddRecGoodsLkRow(row);
                this._prevRecGoodsLkDic.Add(row.FilterGuid, RecGoodsLkSt);
            }

            if (this._deleteSearchMode == false)
            {
                // �V�K�s�̒ǉ�
                RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                newRow.RowNo = retList.Count + 1;
                newRow.FilterGuid = Guid.Empty;
                newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                newRow.InqOtherEpCd = this._enterpriseCode;
                //newRow.InqOtherSecCd = this._loginSectionCode;
                this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);
            }

            this.RecGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// ���׍s�[�����R�����h�ݒ�}�X�^
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="recGoodsLk">���R�����h�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���׍s�[�����R�����h�ݒ�}�X�^</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void CopyToDetailRowFromRecGoodsLk(ref RecGoodsLkDataSet.RecGoodsLkRow row, RecGoodsLkSt recGoodsLk)
        {
            row.UpdateTime = recGoodsLk.UpdateDateTime.Date.ToString("yy/MM/dd"); //�X�V��
            row.FilterGuid = Guid.NewGuid();

            row.InqOriginalEpCd = recGoodsLk.InqOriginalEpCd;
            row.InqOriginalSecCd = recGoodsLk.InqOriginalSecCd;
            row.InqOtherEpCd = recGoodsLk.InqOtherEpCd;
            row.InqOtherSecCd = recGoodsLk.InqOtherSecCd;

            //���Ӑ�
            row.CustomerCode = recGoodsLk.CustomerCode.ToString().PadLeft(8, '0');
            CustomerInfo customerInfo = null;
            if (this._customerDic.ContainsKey(recGoodsLk.CustomerCode))
            {
                customerInfo = this._customerDic[recGoodsLk.CustomerCode];
                row.CustomerSnm = customerInfo.CustomerSnm; //���Ӑ旪��
            }
            else if (recGoodsLk.CustomerCode == 0)
            {
                // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                //row.CustomerSnm = "�S���Ӑ拤��"; //���_����
                row.CustomerSnm = ALL_CUSTOMERNAME; //���_����
                // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
            }
            //���_
            string inqOtherSecCd = recGoodsLk.InqOtherSecCd.Trim().PadLeft(2, '0');

            row.InqOtherSecCd = inqOtherSecCd;
            SecInfoSet secInfoSet = null;
            if (this._secInfoSetDic.ContainsKey(inqOtherSecCd))
            {
                secInfoSet = this._secInfoSetDic[inqOtherSecCd];
                row.InqOtherSecNm = secInfoSet.SectionGuideNm; //���_����
            }
            else if (inqOtherSecCd == "00")
            {
                row.InqOtherSecNm = "�S�Ћ���"; //���_����
            }
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            //������BL�R�[�h
            row.RecSourceBLGoodsCd = recGoodsLk.RecSourceBLGoodsCd;
            if (this.BLGoodsCdDic.ContainsKey(recGoodsLk.RecSourceBLGoodsCd))
            {
                blGoodsCdUMnt = BLGoodsCdDic[recGoodsLk.RecSourceBLGoodsCd];
                row.RecSourceBLGoodsNm = blGoodsCdUMnt.BLGoodsHalfName;
            }
            //������BL�R�[�h
            row.RecDestBLGoodsCd = recGoodsLk.RecDestBLGoodsCd;
            if (BLGoodsCdDic.ContainsKey(recGoodsLk.RecDestBLGoodsCd))
            {
                blGoodsCdUMnt = BLGoodsCdDic[recGoodsLk.RecDestBLGoodsCd];
                row.RecDestBLGoodsNm = blGoodsCdUMnt.BLGoodsHalfName;
            }
            // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
            // ���i�R�����g
            row.GoodsComment = recGoodsLk.GoodsComment;
            // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�[�����׍s
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="recGoodsLk">���R�����h���i�֘A�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�[�����׍s</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        public void CopyToRecGoodsLkFromDetailRow(RecGoodsLkDataSet.RecGoodsLkRow row, ref RecGoodsLkSt recGoodsLk)
        {
            if (recGoodsLk == null)
            {
                recGoodsLk = new RecGoodsLkSt();
            }

            Int32 customerCode = 0;
            Int32.TryParse(row.CustomerCode, out customerCode);
            recGoodsLk.CustomerCode = customerCode;

            recGoodsLk.InqOriginalEpCd = row.InqOriginalEpCd;
            recGoodsLk.InqOriginalSecCd = row.InqOriginalSecCd;
            recGoodsLk.InqOtherEpCd = row.InqOtherEpCd;
            recGoodsLk.InqOtherSecCd = row.InqOtherSecCd;
            recGoodsLk.RecSourceBLGoodsCd = row.RecSourceBLGoodsCd;
            recGoodsLk.RecDestBLGoodsCd = row.RecDestBLGoodsCd;
            recGoodsLk.RecDestBLGoodsNm = row.RecDestBLGoodsNm;
            // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
            recGoodsLk.GoodsComment = string.Empty; ;
            if (!row.IsGoodsCommentNull())
            {
                recGoodsLk.GoodsComment = row.GoodsComment;
            }
            // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<

            recGoodsLk.RowIndex = row.RowNo;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="recGoodsLk1">���R�����h���i�֘A�ݒ�}�X�^</param>
        /// <param name="recGoodsLk2">���R�����h���i�֘A�ݒ�}�X�^</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��r����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool Compare(RecGoodsLkSt recGoodsLk1, RecGoodsLkSt recGoodsLk2)
        {
            if (recGoodsLk1.CustomerCode != recGoodsLk2.CustomerCode
             || recGoodsLk1.RecSourceBLGoodsCd != recGoodsLk2.RecSourceBLGoodsCd
             || recGoodsLk1.RecDestBLGoodsCd != recGoodsLk2.RecDestBLGoodsCd
             || recGoodsLk1.GoodsComment != recGoodsLk2.GoodsComment) // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="recGoodsLk1">���R�����h���i�֘A�ݒ�}�X�^</param>
        /// <param name="recGoodsLk2">���R�����h���i�֘A�ݒ�}�X�^</param>
        /// <returns>true:�s���Afalse:����</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��r����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CompareKey(RecGoodsLkSt recGoodsLk1, RecGoodsLkSt recGoodsLk2)
        {
            if (recGoodsLk1.InqOriginalEpCd != recGoodsLk2.InqOriginalEpCd
             || recGoodsLk1.InqOriginalSecCd != recGoodsLk2.InqOriginalSecCd
             || recGoodsLk1.InqOtherEpCd != recGoodsLk2.InqOtherEpCd
             || recGoodsLk1.InqOtherSecCd != recGoodsLk2.InqOtherSecCd
             || recGoodsLk1.RecSourceBLGoodsCd != recGoodsLk2.RecSourceBLGoodsCd
             || recGoodsLk1.RecDestBLGoodsCd != recGoodsLk2.RecDestBLGoodsCd
             || recGoodsLk1.GoodsComment != recGoodsLk2.GoodsComment) // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CompareSearchCondition(SearchCondition searchCondition1, SearchCondition searchCondition2)
        {
            //�����������ύX�Ȃ��̏ꍇ�͌������Ȃ�
            if (searchCondition1.InqOtherSecCd == searchCondition2.InqOtherSecCd
             && searchCondition1.CustomerCode == searchCondition2.CustomerCode
             && searchCondition1.RecSourceBLGoodsCdSt == searchCondition2.RecSourceBLGoodsCdSt
             && searchCondition1.RecSourceBLGoodsCdEd == searchCondition2.RecSourceBLGoodsCdEd
             && searchCondition1.DeleteFlag == searchCondition2.DeleteFlag)
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool IsRowUpdate(RecGoodsLkDataSet.RecGoodsLkRow row)
        {
            // --- UPD 2015/03/03 T.Miyamoto Redmine#297 ------------------------------>>>>>
            //if (row.CustomerCode.Trim().PadLeft(8, '0') != this._newRecGoodsLkObj.CustomerCode.ToString().PadLeft(8, '0')
            // || row.RecSourceBLGoodsCd != this._newRecGoodsLkObj.RecSourceBLGoodsCd
            // || row.RecDestBLGoodsCd != this._newRecGoodsLkObj.RecDestBLGoodsCd)
            // ������BL�R�[�h�ƃp�[�c�����ɓ��͂��Ȃ��ꍇ�͐V�K�s�i�o�^�s�v�s�j�Ɣ���
            if ((row.RecDestBLGoodsCd != this._newRecGoodsLkObj.RecDestBLGoodsCd)
             || (row.GoodsComment != this._newRecGoodsLkObj.GoodsComment))
            // --- UPD 2015/03/03 T.Miyamoto Redmine#297 ------------------------------<<<<<
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void LoadMstData()
        {
            this._masterAcsThread = new Thread(new ThreadStart(MasterThreadProc)); // �}�X�^�f�[�^�擾�X���b�h
            this._masterAcsThread.Start();
        }

        /// <summary>
        /// �}�X�^�f�[�^�擾�X���b�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^�f�[�^�擾�X���b�h</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void MasterThreadProc()
        {
            this.LoadBlCodeMst();//BL�}�X�^�̓ǂݍ���

            this.ReadSecInfoSet();//���_�}�X�^�̓ǂݍ���

            this.GetCustomerDic();//���Ӑ�}�X�^�̓ǂݍ���

            this.SearchCnectOriginalEpFromSc(); //SCM��ƘA���f�[�^�Ǎ�����
        }

        /// <summary>
        /// BlCode�}�X�^�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BlCode�}�X�^�f�[�^�擾����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���}�X�^�Ǎ�����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// ���Ӑ�`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="chkFlg">�K�{�`�F�b�N�敪(ture:�L,false:��)</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckCustomer(int customerCode, bool chkFlg, out string errMsg, out CustomerInfo retCustomerInfo)
        {
            retCustomerInfo = null;

            bool bRet = true;
            errMsg = string.Empty;

            if (customerCode == 0)
            {
            
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                //�S�Аݒ�Ή��̈׍폜
                //if (chkFlg)
                //{
                //    bRet = false;
                //    errMsg = "���Ӑ�R�[�h����͂��ĉ������B";
                //}
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            }
            else
            {
                if (this._customerDic.ContainsKey(customerCode))
                {
                    retCustomerInfo = this._customerDic[customerCode];
                }
                if (retCustomerInfo == null)
                {
                    bRet = false;
                    errMsg = "���Ӑ悪���݂��܂���B";
                }
                else
                {
                    bRet = false;
                    errMsg = "�A�g���Ă��链�Ӑ�ł͂���܂���B";
                    if (retCustomerInfo.OnlineKindDiv != 0       //�I�����C����ʋ敪
                     && retCustomerInfo.CustomerEpCode != null   //���Ӑ��ƃR�[�h
                     && retCustomerInfo.CustomerSecCode != null) //���Ӑ拒�_�R�[�h
                    {
                        // SCM��ƘA���f�[�^�Y���`�F�b�N
                        bRet = false;
                        errMsg = "�A�g���Ă��链�Ӑ�ł͂���܂���B";
                        foreach (ScmEpScCnt wk in this._scmEpScCntList)
                        {
                            if (!wk.LogicalDeleteCode.Equals(0)) continue;                              // �_���폜�F�L���ȊO
                            if (wk.DiscDivCd.Equals(1)) continue;                                       // �A������
                            if (wk.ScmCommMethod.Equals(0) && wk.PccUoeCommMethod.Equals(0)) continue;  // �ʐM����������

                            // �I�����C����ʋ敪�A���Ӑ��ƃR�[�h�A���Ӑ拒�_�R�[�h�̔���
                            if (retCustomerInfo.OnlineKindDiv == 10  // 10:SCM
                               && retCustomerInfo.CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                               && retCustomerInfo.CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim())
                                 )
                            {
                                bRet = true;
                                break;
                            }
                        }
                    }
                }
            }
            return bRet;
        }
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

            // --- UPD 2015/02/12 T.Miyamoto ------------------------------>>>>>
            //if (int.Parse(sectionCode.Trim()) == 0)
            Int32 chkSectionCode = 0;
            Int32.TryParse(sectionCode, out chkSectionCode);
            if (chkSectionCode == 0)
            // --- UPD 2015/02/12 T.Miyamoto ------------------------------<<<<<
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
        /// SearchCondition->SearchConditionWork
        /// </summary>
        /// <param name="searchCondition">��������</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : SearchCondition->SearchConditionWork</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private RecGoodsLkWork CopyToSearchConditionWorkFromSearchCondition(SearchCondition searchCondition)
        {
            RecGoodsLkWork recGoodsLkWork = new RecGoodsLkWork();

            recGoodsLkWork.InqOtherEpCd   = searchCondition.InqOtherEpCd;   //�⍇�����ƃR�[�h
            recGoodsLkWork.InqOtherSecCd  = searchCondition.InqOtherSecCd;  //�⍇���拒�_�R�[�h
            recGoodsLkWork.CustomerCode      = searchCondition.CustomerCode;      //���Ӑ�R�[�h
            recGoodsLkWork.RecSourceBLGoodsCdSt = searchCondition.RecSourceBLGoodsCdSt; //������BL�R�[�h�i�J�n�j
            recGoodsLkWork.RecSourceBLGoodsCdEd = searchCondition.RecSourceBLGoodsCdEd; //������BL�R�[�h�i�I���j
            recGoodsLkWork.LogicalDeleteCode  = searchCondition.DeleteFlag;        //�폜�w��敪
            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------>>>>>
            recGoodsLkWork.InqOriginalEpCd  = searchCondition.InqOriginalEpCd;  //�⍇������ƃR�[�h
            recGoodsLkWork.InqOriginalSecCd = searchCondition.InqOriginalSecCd; //�⍇�������_�R�[�h
            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------<<<<<

            return recGoodsLkWork;
        }

        /// <summary>
        /// RecGoodsLkWork->RecGoodsLk
        /// </summary>
        /// <param name="recGoodsLkWork">���R�����h���i�֘A�ݒ胏�[�N</param>
        /// <returns>���R�����h���i�֘A�ݒ�</returns>
        /// <remarks>
        /// <br>Note       : RecGoodsLkWork->RecGoodsLk</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private RecGoodsLkSt CopyToRecGoodsLkFromRecGoodsLkWork(RecGoodsLkWork recGoodsLkWork)
        {
            RecGoodsLkSt RecGoodsLkSt = new RecGoodsLkSt();

            RecGoodsLkSt.CreateDateTime      = recGoodsLkWork.CreateDateTime;
            RecGoodsLkSt.UpdateDateTime      = recGoodsLkWork.UpdateDateTime;
            RecGoodsLkSt.LogicalDeleteCode   = recGoodsLkWork.LogicalDeleteCode;
            RecGoodsLkSt.InqOriginalEpCd     = recGoodsLkWork.InqOriginalEpCd;
            RecGoodsLkSt.InqOriginalSecCd    = recGoodsLkWork.InqOriginalSecCd;
            RecGoodsLkSt.InqOtherEpCd        = recGoodsLkWork.InqOtherEpCd;
            RecGoodsLkSt.InqOtherSecCd       = recGoodsLkWork.InqOtherSecCd;
            RecGoodsLkSt.CustomerCode        = recGoodsLkWork.CustomerCode;
            RecGoodsLkSt.RecSourceBLGoodsCd  = recGoodsLkWork.RecSourceBLGoodsCd;
            RecGoodsLkSt.RecDestBLGoodsCd    = recGoodsLkWork.RecDestBLGoodsCd;
            RecGoodsLkSt.RecDestBLGoodsNm    = recGoodsLkWork.RecDestBLGoodsNm;
            RecGoodsLkSt.GoodsComment        = recGoodsLkWork.GoodsComment; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�

            return RecGoodsLkSt;
        }

        /// <summary>
        /// RecGoodsLk->RecGoodsLkWork
        /// </summary>
        /// <param name="RecGoodsLkSt">���R�����h���i�֘A�ݒ�</param>
        /// <returns>���R�����h���i�֘A�ݒ胏�[�N</returns>
        /// <remarks>
        /// <br>Note       : RecGoodsLk->RecGoodsLkWork</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private RecGoodsLkWork CopyToRecGoodsLkWorkFromRecGoodsLk(RecGoodsLkSt RecGoodsLkSt)
        {
            RecGoodsLkWork recGoodsLkWork = new RecGoodsLkWork();

            recGoodsLkWork.CreateDateTime      = RecGoodsLkSt.CreateDateTime;
            recGoodsLkWork.UpdateDateTime      = RecGoodsLkSt.UpdateDateTime;
            recGoodsLkWork.LogicalDeleteCode   = RecGoodsLkSt.LogicalDeleteCode;
            recGoodsLkWork.InqOriginalEpCd     = RecGoodsLkSt.InqOriginalEpCd;
            recGoodsLkWork.InqOriginalSecCd    = RecGoodsLkSt.InqOriginalSecCd;
            recGoodsLkWork.InqOtherEpCd        = RecGoodsLkSt.InqOtherEpCd;
            recGoodsLkWork.InqOtherSecCd       = RecGoodsLkSt.InqOtherSecCd;
            recGoodsLkWork.CustomerCode        = RecGoodsLkSt.CustomerCode;
            recGoodsLkWork.RecSourceBLGoodsCd  = RecGoodsLkSt.RecSourceBLGoodsCd;
            recGoodsLkWork.RecDestBLGoodsCd    = RecGoodsLkSt.RecDestBLGoodsCd;
            recGoodsLkWork.RecDestBLGoodsNm    = RecGoodsLkSt.RecDestBLGoodsNm;
            recGoodsLkWork.GoodsComment        = RecGoodsLkSt.GoodsComment; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�

            return recGoodsLkWork;
        }

        /// <summary>
        /// SCM��ƘA���f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM��ƘA���f�[�^�Ǎ�����</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/04</br>
        /// </remarks>
        private void SearchCnectOriginalEpFromSc()
        {
            try
            {
                bool msgDiv;
                string errMsg;

                int status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out this._scmEpScCntList, out msgDiv, out errMsg);
            }
            catch
            {
            }
        }
        #endregion

        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------>>>>>
        /// <summary>
        /// �T���v���捞�`�F�b�N����
        /// </summary>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �T���v���捞�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        public int SampleCheck(out string msg)
        {
            msg = string.Empty;
            int status = 0;
            int count = 0;
            try
            {
                ArrayList recGoodsLkList = null;
                object retObj = recGoodsLkList as object;

                RecGoodsLkWork recGoodsLkWork    = new RecGoodsLkWork();
                recGoodsLkWork.InqOtherEpCd      = this._enterpriseCode;                     //�⍇�����ƃR�[�h
                recGoodsLkWork.InqOtherSecCd     = this._sampleSecCd;                        //�⍇���拒�_�R�[�h
                recGoodsLkWork.CustomerCode      = this._sampleCustomerInfo.CustomerCode;    //���Ӑ�R�[�h
                recGoodsLkWork.InqOriginalEpCd   = this._sampleCustomerInfo.CustomerEpCode;  //�⍇������ƃR�[�h
                recGoodsLkWork.InqOriginalSecCd  = this._sampleCustomerInfo.CustomerSecCode; //�⍇�������_�R�[�h
                recGoodsLkWork.LogicalDeleteCode = 0;                                        //�폜�w��敪
                object paraObj = recGoodsLkWork as object;

                status = this._iRecGoodsLkDB.SearchRcmd(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2015/02/10�@ T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// ���i�R�����g��������
        /// </summary>
        /// <param name="recSourceBLCode">������BL�R�[�h</param>
        /// <param name="recDestBLCode">������BL�R�[�h</param>
        /// <returns>string</returns>
        /// <remarks>
        /// <br>Note       : �w�肵��BL�R�[�h���珤�i�R�����g�̌������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/10</br>
        /// </remarks>
        public string SampleRead(int recSourceBLCode, int recDestBLCode)
        {
            string goodsComment = string.Empty;

            ArrayList retArrayList = new ArrayList();
            RecGoodsLkOWork pararecGoodsLkOWork = new RecGoodsLkOWork();
            pararecGoodsLkOWork.RecSourceBLGoodsCd = recSourceBLCode;
            pararecGoodsLkOWork.RecDestBLGoodsCd = recDestBLCode;

            string msg = string.Empty;
            retArrayList.Add(pararecGoodsLkOWork);
            int status = this.SampleReadProc(ref retArrayList, ref msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                RecGoodsLkOWork recGoodsLkOWork = (RecGoodsLkOWork)retArrayList[0];
                goodsComment = recGoodsLkOWork.GoodsComment.Trim();
            }
            return goodsComment;
        }

        /// <summary>
        /// ���i�R�����g��������
        /// </summary>
        /// <param name="recGoodsLkOWork">��������</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�����g�����������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/10</br>
        /// </remarks>
        public int SampleReadProc(ref ArrayList retArray, ref string msg)
        {
            int status = 0;
            try
            {
                object retObj = null;
                retObj = retArray[0] as Object;
                ArrayList retArrayList = new ArrayList();
                status = this._IRecGoodsLkODB.Read(ref retObj, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArrayList.Add(retObj as RecGoodsLkOWork);
                    retArray = retArrayList;
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
        // --- ADD 2015/02/10�@ T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// �T���v���f�[�^��������
        /// </summary>
        /// <param name="searchCondition">���������N���X</param>
        /// <param name="count">count</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �T���v���f�[�^�����������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int SampleSearch(out string msg)
        {
            int status = 0;
            msg = string.Empty;

            ArrayList recGoodsLkOWorkList = null;
            try
            {
                status = this.SampleSearchPrc(out recGoodsLkOWorkList, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (recGoodsLkOWorkList != null && recGoodsLkOWorkList.Count > 0)
                {
                    this.SettingDetailRowAfterSampleSearch(recGoodsLkOWorkList);
                }
            }
            return status;
        }

        /// <summary>
        /// �T���v���f�[�^��������
        /// </summary>
        /// <param name="retArray">���i�R�����g�f�[�^</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �T���v���f�[�^�����������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        public int SampleSearchPrc(out ArrayList retArray, ref string msg)
        {
            int status = 0;
            try
            {
                object retObj = null;
                RecGoodsLkOWork recGoodsLkOWork = new RecGoodsLkOWork();
                status = this._IRecGoodsLkODB.Search(out retObj, recGoodsLkOWork, 0, ConstantManagement.LogicalMode.GetData0);
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
        /// ���i�R�����g����������A���׍s�ǉ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�R�����g����������A���׍s�ǉ��������s���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private void SettingDetailRowAfterSampleSearch(ArrayList retList)
        {
            this.RecGoodsLkDataTable.BeginLoadData();
            RecGoodsLkSt RecGoodsLkSt = null;

            this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1].Delete(); //�����̐V�K�s���폜
            int startRowNo = this._recGoodsLkDataTable.Count;
            // �T���v���f�[�^��W�J
            for (int iCnt = 1; iCnt <= retList.Count; iCnt++)
            {
                // �V�K�s�̒ǉ�
                RecGoodsLkDataSet.RecGoodsLkRow setRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                setRow.RowNo = startRowNo + iCnt;
                setRow.FilterGuid = Guid.Empty;
                setRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                setRow.InqOtherEpCd = this._enterpriseCode;                         //�⍇�����ƃR�[�h

                // �捞��ʂœ��͂������_�E���Ӑ���Z�b�g
                setRow.InqOtherSecCd = this._sampleSecCd;                           //�⍇���拒�_�R�[�h
                setRow.InqOtherSecNm = this._sampleSecNm;                           //�⍇���拒�_��
                // --- UPD 2015/03/02 T.Miyamoto Redmine#296 ------------------------------>>>>>
                //setRow.CustomerCode = this._sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'); //���Ӑ�R�[�h
                //setRow.CustomerSnm = this._sampleCustomerInfo.CustomerSnm;          //���Ӑ旪��
                //setRow.InqOriginalEpCd = this._sampleCustomerInfo.CustomerEpCode;   //�⍇������ƃR�[�h�����Ӑ��ƃR�[�h
                //setRow.InqOriginalSecCd = this._sampleCustomerInfo.CustomerSecCode; //�⍇�������_�R�[�h�����Ӑ拒�_�R�[�h
                if ((this._sampleCustomerInfo == null) || (this._sampleCustomerInfo.CustomerCode == 0))
                {
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //setRow.CustomerCode = "00000000";
                    //setRow.CustomerSnm = "�S���Ӑ�";
                    //setRow.InqOriginalEpCd = "0000000000000000";
                    //setRow.InqOriginalSecCd = "000000";
                    setRow.CustomerCode = ALL_CUSTOMERCODE;
                    setRow.CustomerSnm = ALL_CUSTOMERNAME;
                    setRow.InqOriginalEpCd = ALL_ORIGINALEPCD;
                    setRow.InqOriginalSecCd = ALL_ORIGINALSECCD;
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                else
                {
                    setRow.CustomerCode = this._sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'); //���Ӑ�R�[�h
                    setRow.CustomerSnm = this._sampleCustomerInfo.CustomerSnm;          //���Ӑ旪��
                    setRow.InqOriginalEpCd = this._sampleCustomerInfo.CustomerEpCode;   //�⍇������ƃR�[�h�����Ӑ��ƃR�[�h
                    setRow.InqOriginalSecCd = this._sampleCustomerInfo.CustomerSecCode; //�⍇�������_�R�[�h�����Ӑ拒�_�R�[�h
                }
                // --- UPD 2015/03/02 T.Miyamoto Redmine#296 ------------------------------<<<<<

                // �T���v���f�[�^���Z�b�g
                RecGoodsLkOWork recGoodsLkOWork = (RecGoodsLkOWork)retList[iCnt - 1];
                //������BL���i�R�[�h
                setRow.RecSourceBLGoodsCd = recGoodsLkOWork.RecSourceBLGoodsCd;     
                setRow.RecSourceBLGoodsNm = GetBLGoodsNm(recGoodsLkOWork.RecSourceBLGoodsCd);
                //������BL���i�R�[�h
                setRow.RecDestBLGoodsCd = recGoodsLkOWork.RecDestBLGoodsCd;
                setRow.RecDestBLGoodsNm = GetBLGoodsNm(recGoodsLkOWork.RecDestBLGoodsCd);
                //���i�R�����g
                setRow.GoodsComment = recGoodsLkOWork.GoodsComment;

                // �s�폜�t���O
                setRow.RowDeleteFlg = DELETEFLG_SAMPLE; //�T���v���捞�̃t���O���Z�b�g

                this._recGoodsLkDataTable.AddRecGoodsLkRow(setRow);
            }
            // �V�K�s�̒ǉ�
            RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            newRow.RowNo = this._recGoodsLkDataTable.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;
            newRow.RowDeleteFlg = DELETEFLG_SAMPLE; //�T���v���捞�̃t���O���Z�b�g
            this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

            this.RecGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private string GetBLGoodsNm(int BLGoodsCd)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();
            if (this.BLGoodsCdDic.ContainsKey(BLGoodsCd))
            {
                blGoodsCdUMnt = BLGoodsCdDic[BLGoodsCd];
            }
            return blGoodsCdUMnt.BLGoodsHalfName;
        }
        // --- ADD 2015/02/06 T.Miyamoto �T���v���捞�@�\�ǉ� ------------------------------<<<<<
    }
}
