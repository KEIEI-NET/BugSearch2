//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���Ǘ��}�X�^
// �v���O�����T�v   : �L�����y�[���Ǘ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/28  �C�����e : �V�K�쐬
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/07/14  �C�����e : �T�[�o�Ή�(LoginInfoAcquisition.Employee.BelongSectionCode���g�p���Ȃ�)
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/08/25  �C�����e : �`�P�b�g[14065]�Ή�
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/08/31  �C�����e : �`�P�b�g[14194]�Ή�
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/04/13  �C�����e : �L�����y�[���ݒ�}�X�^�ƃL�����y�[���Ǘ��}�X�^�̋��_�`�F�b�N���@�C��
//                                : (�L�����y�[���ݒ�}�X�^�őS�Аݒ�ɂ����ꍇ�A�S�Ă̐ݒ�Ƀq�b�g���Ȃ�)
// �Ǘ��ԍ�              �쐬�S�� : 22008 ���� ���n
// �� �� ��  2010/09/29  �C�����e : ���`�Ŗ��א��ʕύX���̑��x�A�b�v�Ή�
//----------------------------------------------------------------------------//
#define _USING_VERSION_2_   // �����ł��g�p����t���O

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���Ǘ��}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ǘ��}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009/05/28</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class CampaignMngAcs
    {
        #region public const
        //----------------------------------------
        // �L�����y�[���Ǘ��}�X�^�萔��`
        //----------------------------------------
        /// <summary>�쐬����</summary>
        public const string ct_COL_CREATEDATETIME = "CreateDateTime";
        /// <summary>�X�V����</summary>
        public const string ct_COL_UPDATEDATETIME = "UpdateDateTime";
        /// <summary>��ƃR�[�h</summary>
        public const string ct_COL_ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ct_COL_FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        public const string ct_COL_UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>�X�V�A�Z���u��ID1</summary>
        public const string ct_COL_UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>�X�V�A�Z���u��ID2</summary>
        public const string ct_COL_UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>�_���폜�敪</summary>
        public const string ct_COL_LOGICALDELETECODE = "LogicalDeleteCode";
        /// <summary>���_�R�[�h</summary>
        public const string ct_COL_SECTIONCODE = "SectionCode";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_COL_GOODSMGROUP = "GoodsMGroup";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_COL_BLGOODSCODE = "BLGoodsCode";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_COL_GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>���i�ԍ�</summary>
        public const string ct_COL_GOODSNO = "GoodsNo";
        /// <summary>����ڕW���z</summary>
        public const string ct_COL_SALESTARGETMONEY = "SalesTargetMoney";
        /// <summary>����ڕW�e���z</summary>
        public const string ct_COL_SALESTARGETPROFIT = "SalesTargetProfit";
        /// <summary>����ڕW����</summary>
        public const string ct_COL_SALESTARGETCOUNT = "SalesTargetCount";
        /// <summary>�L�����y�[���R�[�h</summary>
        public const string ct_COL_CAMPAIGNCODE = "CampaignCode";
        /// <summary>������</summary>
        public const string ct_COL_RATEVAL = "RateVal";
        /// <summary>�����z</summary>
        public const string ct_COL_PRICEFL = "PriceFl";

        /// <summary>�L�����y�[���R�[�h�K�C�h</summary>
        public const string ct_COL_CAMPAIGNCODEGUIDE = "CampaignCodeGuide";
        /// <summary>�L�����y�[������</summary>
        public const string ct_COL_CAMPAIGNNAME = "CampaignName";

        /// <summary>�L�����y�[���R�[�h(�O��ޔ�)</summary>
        public const string ct_COL_CAMPAIGNCODE_BACKUP = "CampaignCode_Backup";
        /// <summary>������(�O��ޔ�)</summary>
        public const string ct_COL_RATEVAL_BACKUP = "RateVal_Backup";
        /// <summary>�����z(�O��ޔ�)</summary>
        public const string ct_COL_PRICEFL_BACKUP = "PriceFl_Backup";

        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string ct_COL_BLGROUPCODE = "BLGroupCode";
        
        /// <summary>���_����</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>���i�����ޖ���</summary>
        public const string ct_COL_GOODSMGROUPNAME = "GoodsMGroupName";
        /// <summary>BL�O���[�v����</summary>
        public const string ct_COL_BLGROUPNAME = "BLGroupName";
        /// <summary>BL���i�R�[�h����</summary>
        public const string ct_COL_BLGOODSNAME = "BLGoodsName";
        /// <summary>���[�J�[����</summary>
        public const string ct_COL_MAKERNAME = "MakerName";
        /// <summary>���i����</summary>
        public const string ct_COL_GOODSNAME = "GoodsName";
        
        # region [�\�[�g�p]
        /// <summary>���_�R�[�h</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_COL_GOODSMAKERCD_SORT = "GoodsMakerCd_Sort";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_COL_GOODSMGROUP_SORT = "GoodsMGroup_Sort";
        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string ct_COL_BLGROUPCODE_SORT = "BLGroupCode_Sort";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_COL_BLGOODSCODE_SORT = "BLGoodsCode_Sort";
        # endregion

        /// <summary>�_���폜��(�\���p)</summary>
        public const string ct_COL_LOGICALDELETEDATE = "LogicalDeleteDate";
        /// <summary>�L�����y�[���Ǘ��}�X�^work�I�u�W�F�N�g(�����ێ��p)</summary>
        public const string ct_COL_CAMPAIGNMNGWORKOBJECT = "CampaignMngWorkObject";


        // �e�[�u����
        /// <summary>�L�����y�[���Ǘ��e�[�u��</summary>
        public const string ct_TABLE_CAMPAIGNMNG = "CampaignMngTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�����o�[
        // ===================================================================================== //
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private ICampaignMngDB _iCampaignMngDB = null;      // �L�����y�[���Ǘ������[�g

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        //private GoodsAcs _goodsAcs;  // DEL 2010/09/29

        // �L�����y�[���ݒ�A�N�Z�X�N���X
        private CampaignStAcs _campaignStAcs;
        // �L�����y�[���ݒ�f�B�N�V���i��
        private Dictionary<int, CampaignSt> _campaignStDic;

        // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
        /// <summary>
        /// �L�����y�[���ݒ�f�B�N�V���i���i�S�������̃L���b�V���f�[�^�j���擾���܂��B
        /// </summary>
        public Dictionary<int, CampaignSt> CachedCampaignStDic
        {
            get { return _campaignStDic; }
        }

        /// <summary>�L�����y�[���������A�����z�擾�����Ŏg�p���ꂽ�L�����y�[���֘A�ݒ�f�[�^</summary>
        private ArrayList _usedCampaignLinkList;
        /// <summary>
        /// �L�����y�[���������A�����z�擾�����Ŏg�p���ꂽ�L�����y�[���֘A�ݒ�f�[�^���擾���܂��B<br/>
        /// �i�L�����y�[���ݒ�.CampaignObjDiv == 1 �Ń����[�g�A�N�Z�X���܂��j
        /// </summary>
        public ArrayList UsedCampaignLinkList
        {
            get { return _usedCampaignLinkList; }
        }

        /// <summary>�������ʏ�</summary>
        private string _statusOfResult = string.Empty;
        /// <summary>
        /// �������ʏ󋵂��擾���܂��B<br/>
        /// (GetRatePriceOfCampaignMng()���ďo�����ɕω����܂�)
        /// </summary>
        public string StatusOfResult
        {
            get { return _statusOfResult; }
        }
        // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

        // �L�����y�[���Ǘ��f�[�^�f�B�N�V���i���[�@�L�[����
        public struct DICKEY
        {
            /// <summary> ���_�R�[�h </summary>
            public string sectionCode;
            /// <summary> ���i������ </summary>
            public int goodsMGroup;
            /// <summary> BL�R�[�h </summary>
            public int blGoodsCode;
            /// <summary> ���[�J�[�R�[�h </summary>
            public int goodsMakerCd;
            /// <summary> �i�� </summary>
            public string goodsNo;
        }

        // �L�����y�[���Ǘ��f�[�^�f�B�N�V���i���[
        private Dictionary<DICKEY, CampaignMng> _campaignMngDic = null;
        // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
        /// <summary>
        /// �L�����y�[���Ǘ��f�[�^�f�B�N�V���i���[�i�S�������̃L���b�V���f�[�^�j���擾���܂��B
        /// </summary>
        public Dictionary<DICKEY, CampaignMng> CachedCampaignMngDic
        {
            get { return _campaignMngDic; }
        }
        // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

        /// <summary>��ƃR�[�h</summary>
        private readonly string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private readonly string _sectionCode = string.Empty;

        #endregion

        # region enum
        // �񋓌^
        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }
        # endregion

        #region Construcstor
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public CampaignMngAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iCampaignMngDB = (ICampaignMngDB)MediationCampaignMngDB.GetCampaignMngDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
            }

            // �_���폜���O����
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30434 �H��</br>
        /// <br>Date       : 2009/07/14</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public CampaignMngAcs(string enterpriseCode, string sectionCode) : this()
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode    = sectionCode;
        }
        #endregion

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignMngDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// �f�[�^�e�[�u���X�V��C�x���g
        /// </summary>
        public event EventHandler AfterTableUpdate;


        #region Property
        /// <summary>
        /// �f�[�^�r���[�i�}�X�^�ꗗ�p�j
        /// </summary>
        public DataView DataViewForMstList
        {
            get 
            {
                // �����O��get�v�����ꂽ�珉���������������s����
                if ( _dataTableList == null )
                {
                    this._dataTableList = new DataSet();
                    DataSetColumnConstruction();
                }
                return _dataView; 
            }
        }
        /// <summary>
        /// DataView�_���폜���O�t���O
        /// </summary>
        public bool ExcludeLogicalDeleteFromView
        {
            set
            {
                DataView view = this.DataViewForMstList;
                if ( value == true )
                {
                    // �_���폜����
                    view.RowFilter = string.Format( "{0}='{1}'", ct_COL_LOGICALDELETECODE, 0 );
                }
                else
                {
                    // �_���폜�܂�
                    view.RowFilter = string.Empty;
                }
            }
            get { return _excludeLogicalDeleteFromView; }
        }

        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        private string EnterpriseCode
        {
            get
            {
                if (string.IsNullOrEmpty(_enterpriseCode.Trim()))
                {
                    return LoginInfoAcquisition.EnterpriseCode;
                }
                else
                {
                    return _enterpriseCode;
                }
            }
        }

        /// <summary>
        /// ���_�R�[�h���擾���܂��B
        /// </summary>
        private string SectionCode
        {
            get
            {
                if (string.IsNullOrEmpty(_sectionCode.Trim()))
                {
                    return LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                else
                {
                    return _sectionCode;
                }
            }
        }
        #endregion

        #region Search ��������
        /// <summary>
        /// �������ʃN���A����
        /// </summary>
        public void Clear()
        {
            // �i�[��e�[�u������
            if ( _dataTableList == null )
            {
                // ����̂ݐ���
                this._dataTableList = new DataSet();
                DataSetColumnConstruction();
            }
            else
            {
                // �Q��ڈȍ~�̓N���A�̂�
                _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Clear();
            }
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�������������i�_���폜�܂܂Ȃ��j�L�����y�[���Ǘ��}�X�����ȊO�p
        /// </summary>
        /// <param name="paraData">�L�����y�[���Ǘ��I�u�W�F�N�g���X�g</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Search( CampaignMngOrder paraData, out List<CampaignMng> retList, out string message )
        {
            // -- DEL 2010/09/29 -------------------------------------->>>
            //if ( _goodsAcs == null )
            //{
            //    string msg;
            //    _goodsAcs = new GoodsAcs(SectionCode);
            //    _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            //}
            // -- DEL 2010/09/29 --------------------------------------<<<

            // ����
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // ���ʊi�[
            retList = new List<CampaignMng>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is CampaignMngWork )
                    {
                        CampaignMngWork retWork = (obj as CampaignMngWork);

                        // �l���Z�b�g
                        CampaignMng campaignMng = CopyToCampaignMngFromCampaignMngWork( retWork );
                        retList.Add( campaignMng );
                    }
                }
            }

            if ( retList.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        public void Renewal()
        {
            //_goodsAcs = null; // DEL 2010/09/29
            _campaignMngDic = null;
            this.Clear();
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�������������i�_���폜�܂܂Ȃ��j�L�����y�[���Ǘ��}�X�����p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( CampaignMngOrder paraData, out string message )
        {
            // -- DEL 2010/09/29 -------------------------->>>
            //if ( _goodsAcs == null )
            //{
            //    string msg;
            //    _goodsAcs = new GoodsAcs(SectionCode);
            //    _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            //}
            // -- DEL 2010/09/29 --------------------------<<<

            // ������/�N���A
            this.Clear();

            // ����
            ArrayList retWorkList;
            int status = SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message );

            // ���ʊi�[
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is CampaignMngWork )
                    {
                        CampaignMngWork retWork = (obj as CampaignMngWork);

                        // �A�N�Z�X�N���X����DataTable�ɒǉ�
                        DataRow row = this._dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].NewRow();

                        // �l���Z�b�g
                        CopyToDataRowFromCampaignMngWork(ref row, retWork);
                        _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Add( row );
                    }
                }
            }
            if ( _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            // �e�[�u���X�V��C�x���g
            if ( AfterTableUpdate != null )
            {
                AfterTableUpdate( this, new EventArgs() );
            }

            return status;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�L�����y�[���Ǘ��}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public CampaignMng GetRecordForMaintenance( Guid guid )
        {
            CampaignMngWork campaignMngWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_CAMPAIGNMNG] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    campaignMngWork = CopyToCampaignMngWorkFromDataRow( view[0].Row );
                }
            }

            // �Y�������Ȃ��f�[�^
            if ( campaignMngWork == null )
            {
                campaignMngWork = new CampaignMngWork();
            }

            return this.CopyToCampaignMngFromCampaignMngWork( campaignMngWork );
        }
        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�L�����y�[���Ǘ��}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_CAMPAIGNMNG] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    row = view[0].Row;
                }
            }

            // �Y�������Ȃ�NULL
            return row;
        }
        #endregion

        #region Write �������ݏ���
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="campaignMngList">�ۑ��f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ݏ������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Write(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraCampaignMngList = new ArrayList();
                CampaignMngWork campaignMngWork = null;

                for ( int i = 0; i < campaignMngList.Count; i++ )
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng( (CampaignMng)campaignMngList[i] );
                    paraCampaignMngList.Add( campaignMngWork );
                }

                object paraObj = (object)paraCampaignMngList;

                // �������ݏ���
                status = this._iCampaignMngDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ����X�V

                    // DataTable���g�p���Ă���ꍇ�̂ݏ����������s��
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // ��������̃G���[����
                    message = "�o�^�Ɏ��s���܂����B";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        /// <summary>
        /// �X�V�����̎擾�i����DataTable���j
        /// </summary>
        /// <returns></returns>
        public int GetUpdateCountFromTable()
        {
            if ( _dataTableList != null )
            {
                int count = 0;

                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows )
                {
                    // �������Ɣ����z�̕ϊ�
                    double rateVal = 0.0;
                    double rateValBk = 0.0;
                    double priceFl = 0.0;
                    double priceFlBk = 0.0;

                    if (row[ct_COL_RATEVAL] != null && row[ct_COL_RATEVAL] != DBNull.Value)
                    {
                        rateVal = (double)row[ct_COL_RATEVAL];
                    }
                    if (row[ct_COL_RATEVAL_BACKUP] != null && row[ct_COL_RATEVAL_BACKUP] != DBNull.Value)
                    {
                        rateValBk = (double)row[ct_COL_RATEVAL_BACKUP];
                    }
                    if (row[ct_COL_PRICEFL] != null && row[ct_COL_PRICEFL] != DBNull.Value)
                    {
                        priceFl = (double)row[ct_COL_PRICEFL];
                    }
                    if (row[ct_COL_PRICEFL_BACKUP] != null && row[ct_COL_PRICEFL_BACKUP] != DBNull.Value)
                    {
                        priceFlBk = (double)row[ct_COL_PRICEFL_BACKUP];
                    }

                    // �X�V�L���`�F�b�N
                    string campaignCode = row[ct_COL_CAMPAIGNCODE].ToString();
                    if (string.IsNullOrEmpty(campaignCode.Trim()))
                    {
                        row[ct_COL_CAMPAIGNCODE] = 0;
                    }
                    if (((int)row[ct_COL_CAMPAIGNCODE] != (int)row[ct_COL_CAMPAIGNCODE_BACKUP]) ||
                        (rateVal != rateValBk) ||
                        (priceFl != priceFlBk))
                    {
                        // �X�V�L
                        count++;
                    }
                }

                return count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// DataTable����̈ꊇ�������ݏ���
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int WriteAll( out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // DataTable���珑�����݃��X�g����
                ArrayList paraCampaignMngList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows )
                {
                    // �������Ɣ����z�̕ϊ�
                    double rateVal = 0.0;
                    double rateValBk = 0.0;
                    double priceFl = 0.0;
                    double priceFlBk = 0.0;

                    if (row[ct_COL_RATEVAL] != null && row[ct_COL_RATEVAL] != DBNull.Value)
                    {
                        rateVal = (double)row[ct_COL_RATEVAL];
                    }
                    if (row[ct_COL_RATEVAL_BACKUP] != null && row[ct_COL_RATEVAL_BACKUP] != DBNull.Value)
                    {
                        rateValBk = (double)row[ct_COL_RATEVAL_BACKUP];
                    }
                    if (row[ct_COL_PRICEFL] != null && row[ct_COL_PRICEFL] != DBNull.Value)
                    {
                        priceFl = (double)row[ct_COL_PRICEFL];
                    }
                    if (row[ct_COL_PRICEFL_BACKUP] != null && row[ct_COL_PRICEFL_BACKUP] != DBNull.Value)
                    {
                        priceFlBk = (double)row[ct_COL_PRICEFL_BACKUP];
                    }

                    // �ύX�L���`�F�b�N
                    if (((int)row[ct_COL_CAMPAIGNCODE] == (int)row[ct_COL_CAMPAIGNCODE_BACKUP]) &&
                        (rateVal == rateValBk) &&
                        (priceFl == priceFlBk))
                    {
                        // �ύX�\�ȍ��ڂ�Search���ƕς��Ȃ��̂őΏۊO�ɂ���
                        continue;
                    }

                    CampaignMngWork campaignMngWork = CopyToCampaignMngWorkFromDataRow( row );
                    paraCampaignMngList.Add( campaignMngWork );
                }
                // �ύX�L���`�F�b�N
                if ( paraCampaignMngList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "�X�V�Ώۂ̃f�[�^�����݂��܂���";
                    return status;
                }

                object paraObj = (object)paraCampaignMngList;


                // �������ݏ���
                status = this._iCampaignMngDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ����X�V

                    // DataTable���g�p���Ă���ꍇ�̂ݏ����������s��
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // ��������̃G���[����
                    message = "�o�^�Ɏ��s���܂����B";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�e�[�u��������������
        /// </summary>
        /// <param name="paraObj"></param>
        private void UpdateDataTable( object retObj )
        {
            if ( retObj is ArrayList )
            {
                foreach ( object obj in (retObj as ArrayList) )
                {
                    if ( obj is CampaignMngWork )
                    {
                        CampaignMngWork retWork = (CampaignMngWork)obj;

                        DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );
                        
                        if ( row == null )
                        {
                            // �ǉ�
                            row = _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].NewRow();
                            CopyToDataRowFromCampaignMngWork(ref row, retWork);
                            _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Add( row );
                        }
                        else
                        {
                            // �X�V
                            CopyToDataRowFromCampaignMngWork(ref row, retWork);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// �����f�[�^�e�[�u��������������(�����폜��)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList campaignMngWorkList )
        {
            foreach ( object obj in campaignMngWorkList )
            {
                if ( obj is CampaignMngWork )
                {
                    CampaignMngWork retWork = (CampaignMngWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // �폜
                        _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="campaignMngList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraCampaignMngList = new ArrayList();
                CampaignMngWork campaignMngWork = null;

                for (int i = 0; i < campaignMngList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng((CampaignMng)campaignMngList[i]);

                    paraCampaignMngList.Add(campaignMngWork);
                }
                object paraObj = (object)paraCampaignMngList;

                // �_���폜����
                status = this._iCampaignMngDB.LogicalDelete( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="campaignMngList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Revival(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraCampaignMngList = new ArrayList();
                CampaignMngWork campaignMngWork = null;

                for (int i = 0; i < campaignMngList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng((CampaignMng)campaignMngList[i]);

                    paraCampaignMngList.Add(campaignMngWork);
                }

                object paraObj = (object)paraCampaignMngList;

                // �������ݏ���
                status = this._iCampaignMngDB.RevivalLogicalDelete(ref paraObj);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region Delete �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="campaignMngList">�폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Delete(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraCampaignMngWork = null;
                CampaignMngWork campaignMngWork = null;
                ArrayList campaignMngWorkList = new ArrayList(); // ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < campaignMngList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng((CampaignMng)campaignMngList[i]);
                    campaignMngWorkList.Add(campaignMngWork);
                }
                // ArrayList����z��𐶐�
                CampaignMngWork[] campaignMngWorks = (CampaignMngWork[])campaignMngWorkList.ToArray(typeof(CampaignMngWork));

                // �V���A���C�Y
                paraCampaignMngWork = XmlByteSerializer.Serialize(campaignMngWorks);

                // �����폜����
                status = this._iCampaignMngDB.Delete(paraCampaignMngWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // �e�[�u������폜
                        DeleteFromDataTable( campaignMngWorkList );
                    }
                }
                else
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region �f�[�^�Z�b�g����\�z����
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // �L�����y�[���Ǘ��e�[�u�����`
            //----------------------------------------------------------------
            DataTable campaignMngTable = new DataTable( ct_TABLE_CAMPAIGNMNG );


            // �쐬����
            campaignMngTable.Columns.Add( ct_COL_CREATEDATETIME, typeof( DateTime ) );
            // �X�V����
            campaignMngTable.Columns.Add( ct_COL_UPDATEDATETIME, typeof( DateTime ) );
            // ��ƃR�[�h
            campaignMngTable.Columns.Add( ct_COL_ENTERPRISECODE, typeof( string ) );
            // GUID
            campaignMngTable.Columns.Add( ct_COL_FILEHEADERGUID, typeof( Guid ) );
            // �X�V�]�ƈ��R�[�h
            campaignMngTable.Columns.Add( ct_COL_UPDEMPLOYEECODE, typeof( string ) );
            // �X�V�A�Z���u��ID1
            campaignMngTable.Columns.Add( ct_COL_UPDASSEMBLYID1, typeof( string ) );
            // �X�V�A�Z���u��ID2
            campaignMngTable.Columns.Add( ct_COL_UPDASSEMBLYID2, typeof( string ) );
            // �_���폜�敪
            campaignMngTable.Columns.Add( ct_COL_LOGICALDELETECODE, typeof( Int32 ) );
            // ���_�R�[�h
            campaignMngTable.Columns.Add( ct_COL_SECTIONCODE, typeof( string ) );
            // ���i�����ރR�[�h
            campaignMngTable.Columns.Add( ct_COL_GOODSMGROUP, typeof( Int32 ) );
            // BL���i�R�[�h
            campaignMngTable.Columns.Add( ct_COL_BLGOODSCODE, typeof( Int32 ) );
            // ���i���[�J�[�R�[�h
            campaignMngTable.Columns.Add( ct_COL_GOODSMAKERCD, typeof( Int32 ) );
            // ���i�ԍ�
            campaignMngTable.Columns.Add( ct_COL_GOODSNO, typeof( string ) );
            // ����ڕW���z
            campaignMngTable.Columns.Add(ct_COL_SALESTARGETMONEY, typeof(Int64));
            // ����ڕW�e���z
            campaignMngTable.Columns.Add(ct_COL_SALESTARGETPROFIT, typeof(Int64));
            // ����ڕW����
            campaignMngTable.Columns.Add(ct_COL_SALESTARGETCOUNT, typeof(double));
            // �L�����y�[���R�[�h
            campaignMngTable.Columns.Add( ct_COL_CAMPAIGNCODE, typeof( Int32 ) );
            // �L�����y�[���R�[�h�K�C�h
            campaignMngTable.Columns.Add(ct_COL_CAMPAIGNCODEGUIDE, typeof(Int32));
            // �L�����y�[������
            campaignMngTable.Columns.Add(ct_COL_CAMPAIGNNAME, typeof(string));
            // ������
            campaignMngTable.Columns.Add(ct_COL_RATEVAL, typeof(double));
            // �����z
            campaignMngTable.Columns.Add(ct_COL_PRICEFL, typeof(double));

            // �L�����y�[���R�[�h(�O��ޔ�)
            campaignMngTable.Columns.Add( ct_COL_CAMPAIGNCODE_BACKUP, typeof( Int32 ) );
            // ������(�O��ޔ�)
            campaignMngTable.Columns.Add(ct_COL_RATEVAL_BACKUP, typeof(double));
            // �����z(�O��ޔ�)
            campaignMngTable.Columns.Add(ct_COL_PRICEFL_BACKUP, typeof(double));

            // �O���[�v�R�[�h
            campaignMngTable.Columns.Add(ct_COL_BLGROUPCODE, typeof(Int32));
            
            // ���_����
            campaignMngTable.Columns.Add( ct_COL_SECTIONNM, typeof( string ) );
            // ���i�����ޖ���
            campaignMngTable.Columns.Add( ct_COL_GOODSMGROUPNAME, typeof( string ) );
            // BL�O���[�v����
            campaignMngTable.Columns.Add( ct_COL_BLGROUPNAME, typeof( string ) );
            // BL���i�R�[�h����
            campaignMngTable.Columns.Add( ct_COL_BLGOODSNAME, typeof( string ) );
            // ���[�J�[����
            campaignMngTable.Columns.Add( ct_COL_MAKERNAME, typeof( string ) );
            // ���i����
            campaignMngTable.Columns.Add( ct_COL_GOODSNAME, typeof( string ) );
            
            
            # region [�\�[�g�p]
            // ���_�R�[�h
            campaignMngTable.Columns.Add( ct_COL_SECTIONCODE_SORT, typeof( string ) );
            // ���i�����ރR�[�h
            campaignMngTable.Columns.Add( ct_COL_GOODSMGROUP_SORT, typeof( Int32 ) );
            // BL���i�R�[�h
            campaignMngTable.Columns.Add( ct_COL_BLGOODSCODE_SORT, typeof( Int32 ) );
            // ���i���[�J�[�R�[�h
            campaignMngTable.Columns.Add( ct_COL_GOODSMAKERCD_SORT, typeof( Int32 ) );
            // �O���[�v�R�[�h
            campaignMngTable.Columns.Add( ct_COL_BLGROUPCODE_SORT, typeof( Int32 ) );
            # endregion


            // �_���폜��(�\���p)
            campaignMngTable.Columns.Add( ct_COL_LOGICALDELETEDATE, typeof( string ) );
            // �I�u�W�F�N�g(�����ێ��p)
            campaignMngTable.Columns.Add( ct_COL_CAMPAIGNMNGWORKOBJECT, typeof( CampaignMngWork ) );

            this._dataTableList.Tables.Add(campaignMngTable);

            //----------------------------------------------------------------
            // �f�[�^�r���[����
            //----------------------------------------------------------------
            this._dataView = new DataView( campaignMngTable );
            this._dataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                ct_COL_SECTIONCODE_SORT,
                                                ct_COL_GOODSMAKERCD_SORT,
                                                ct_COL_GOODSMGROUP_SORT,
                                                ct_COL_BLGROUPCODE_SORT,
                                                ct_COL_BLGOODSCODE_SORT,
                                                ct_COL_GOODSNO 
                                                );
        }
        #endregion

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[���Ǘ��N���X�˃L�����y�[���Ǘ����[�N�N���X�j
        /// </summary>
        /// <param name="campaignMng">�L�����y�[���Ǘ��N���X</param>
        /// <returns>CampaignMngWork</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��N���X����L�����y�[���Ǘ����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private CampaignMngWork CopyToCampaignMngWorkFromCampaignMng(CampaignMng campaignMng)
        {
            CampaignMngWork campaignMngWork = new CampaignMngWork();

            campaignMngWork.CreateDateTime = campaignMng.CreateDateTime;            // �쐬����
            campaignMngWork.UpdateDateTime = campaignMng.UpdateDateTime;            // �X�V����
            campaignMngWork.EnterpriseCode = campaignMng.EnterpriseCode;            // ��ƃR�[�h
            campaignMngWork.FileHeaderGuid = campaignMng.FileHeaderGuid;            // GUID
            campaignMngWork.UpdEmployeeCode = campaignMng.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            campaignMngWork.UpdAssemblyId1 = campaignMng.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            campaignMngWork.UpdAssemblyId2 = campaignMng.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            campaignMngWork.LogicalDeleteCode = campaignMng.LogicalDeleteCode;      // �_���폜�敪

            campaignMngWork.SectionCode = campaignMng.SectionCode;                  // ���_�R�[�h
            campaignMngWork.GoodsMGroup = campaignMng.GoodsMGroup;                  // ���i�����ރR�[�h
            campaignMngWork.BLGroupCode = campaignMng.BLGroupCode;                  // BL�O���[�v�R�[�h
            campaignMngWork.BLGoodsCode = campaignMng.BLGoodsCode;                  // BL���i�R�[�h
            campaignMngWork.GoodsMakerCd = campaignMng.GoodsMakerCd;                // ���i���[�J�[�R�[�h
            campaignMngWork.GoodsNo = campaignMng.GoodsNo;                          // ���i�ԍ�
            campaignMngWork.SalesTargetMoney = campaignMng.SalesTargetMoney;        // ����ڕW���z
            campaignMngWork.SalesTargetProfit = campaignMng.SalesTargetProfit;      // ����ڕW�e���z
            campaignMngWork.SalesTargetCount = campaignMng.SalesTargetCount;        // ����ڕW����
            campaignMngWork.CampaignCode = campaignMng.CampaignCode;                // �L�����y�[���R�[�h
            campaignMngWork.RateVal = campaignMng.RateVal;                          // ������
            campaignMngWork.PriceFl = campaignMng.PriceFl;                          // �����z
            campaignMngWork.SectionNm = campaignMng.SectionNm;                      // ���_����
            campaignMngWork.GoodsMGroupName = campaignMng.GoodsMGroupName;          // ���i�����ޖ���
            campaignMngWork.BLGroupName = campaignMng.BLGroupName;                  // BL�O���[�v����
            campaignMngWork.BLGoodsName = campaignMng.BLGoodsName;                  // BL���i�R�[�h����
            campaignMngWork.MakerName = campaignMng.MakerName;                      // ���[�J�[����
            campaignMngWork.GoodsName = campaignMng.GoodsName;                      // ���i����
            
            return campaignMngWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[���Ǘ����[�N�N���X�˃L�����y�[���Ǘ��N���X�j
        /// </summary>
        /// <param name="campaignMngWork">�L�����y�[���Ǘ����[�N�N���X</param>
        /// <returns>CampaignMng</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ����[�N�N���X����L�����y�[���Ǘ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private CampaignMng CopyToCampaignMngFromCampaignMngWork(CampaignMngWork campaignMngWork)
        {
            CampaignMng campaignMng = new CampaignMng();

            campaignMng.CreateDateTime = campaignMngWork.CreateDateTime;            // �쐬����
            campaignMng.UpdateDateTime = campaignMngWork.UpdateDateTime;            // �X�V����
            campaignMng.EnterpriseCode = campaignMngWork.EnterpriseCode;            // ��ƃR�[�h
            campaignMng.FileHeaderGuid = campaignMngWork.FileHeaderGuid;            // GUID
            campaignMng.UpdEmployeeCode = campaignMngWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            campaignMng.UpdAssemblyId1 = campaignMngWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            campaignMng.UpdAssemblyId2 = campaignMngWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            campaignMng.LogicalDeleteCode = campaignMngWork.LogicalDeleteCode;      // �_���폜�敪
            campaignMng.SectionCode = campaignMngWork.SectionCode;                  // ���_�R�[�h
            campaignMng.GoodsMGroup = campaignMngWork.GoodsMGroup;                  // ���i�����ރR�[�h
            campaignMng.BLGroupCode = campaignMngWork.BLGroupCode;                  // BL�O���[�v�R�[�h
            campaignMng.BLGoodsCode = campaignMngWork.BLGoodsCode;                  // BL���i�R�[�h
            campaignMng.GoodsMakerCd = campaignMngWork.GoodsMakerCd;                // ���i���[�J�[�R�[�h
            campaignMng.GoodsNo = campaignMngWork.GoodsNo;                          // ���i�ԍ�
            campaignMng.SalesTargetMoney = campaignMngWork.SalesTargetMoney;        // ����ڕW���z
            campaignMng.SalesTargetProfit = campaignMngWork.SalesTargetProfit;      // ����ڕW�e���z
            campaignMng.SalesTargetCount = campaignMngWork.SalesTargetCount;        // ����ڕW����
            campaignMng.CampaignCode = campaignMngWork.CampaignCode;                // �L�����y�[���R�[�h
            campaignMng.RateVal = campaignMngWork.RateVal;                          // ������
            campaignMng.PriceFl = campaignMngWork.PriceFl;                          // �����z
            campaignMng.SectionNm = campaignMngWork.SectionNm;                      // ���_����
            campaignMng.GoodsMGroupName = campaignMngWork.GoodsMGroupName;          // ���i�����ޖ���
            campaignMng.BLGroupName = campaignMngWork.BLGroupName;                  // BL�O���[�v����
            campaignMng.BLGoodsName = campaignMngWork.BLGoodsName;                  // BL���i�R�[�h����
            campaignMng.MakerName = campaignMngWork.MakerName;                      // ���[�J�[����
            campaignMng.GoodsName = campaignMngWork.GoodsName;                      // ���i����
            
            return campaignMng;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�L�����y�[���Ǘ��N���X��DataRow�j
        /// </summary>
        /// <param name="dr">�f�[�^�s</param>
        /// <param name="campaignMngWork">�L�����y�[���Ǘ��N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ����[�N�N���X����L�����y�[���Ǘ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private void CopyToDataRowFromCampaignMngWork(ref DataRow dr, CampaignMngWork campaignMngWork)
        {
            # region [dr��campaignMng]
            dr[ct_COL_CREATEDATETIME] = campaignMngWork.CreateDateTime;         // �쐬����
            dr[ct_COL_UPDATEDATETIME] = campaignMngWork.UpdateDateTime;         // �X�V����
            dr[ct_COL_ENTERPRISECODE] = campaignMngWork.EnterpriseCode;         // ��ƃR�[�h
            dr[ct_COL_FILEHEADERGUID] = campaignMngWork.FileHeaderGuid;         // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = campaignMngWork.UpdEmployeeCode;       // �X�V�]�ƈ��R�[�h
            dr[ct_COL_UPDASSEMBLYID1] = campaignMngWork.UpdAssemblyId1;         // �X�V�A�Z���u��ID1
            dr[ct_COL_UPDASSEMBLYID2] = campaignMngWork.UpdAssemblyId2;         // �X�V�A�Z���u��ID2
            dr[ct_COL_LOGICALDELETECODE] = campaignMngWork.LogicalDeleteCode;   // �_���폜�敪
            dr[ct_COL_SECTIONCODE] = campaignMngWork.SectionCode;               // ���_�R�[�h
            dr[ct_COL_GOODSMGROUP] = campaignMngWork.GoodsMGroup;               // ���i�����ރR�[�h
            dr[ct_COL_BLGOODSCODE] = campaignMngWork.BLGoodsCode;               // BL���i�R�[�h
            dr[ct_COL_GOODSMAKERCD] = campaignMngWork.GoodsMakerCd;             // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSNO] = campaignMngWork.GoodsNo;                       // ���i�ԍ�
            dr[ct_COL_SALESTARGETMONEY] = campaignMngWork.SalesTargetMoney;     // ����ڕW���z
            dr[ct_COL_SALESTARGETPROFIT] = campaignMngWork.SalesTargetProfit;   // ����ڕW�e���z
            dr[ct_COL_SALESTARGETCOUNT] = campaignMngWork.SalesTargetCount;     // ����ڕW����
            dr[ct_COL_CAMPAIGNCODE] = campaignMngWork.CampaignCode;             // �L�����y�[���R�[�h
            dr[ct_COL_CAMPAIGNNAME] = GetCampaignName(campaignMngWork.CampaignCode);    // �L�����y�[������

            // ������
            if (campaignMngWork.RateVal == 0.00)
            {
                dr[ct_COL_RATEVAL] = DBNull.Value;
                dr[ct_COL_RATEVAL_BACKUP] = DBNull.Value;
            }
            else
            {
                dr[ct_COL_RATEVAL] = campaignMngWork.RateVal;
                dr[ct_COL_RATEVAL_BACKUP] = campaignMngWork.RateVal;                // ������(�O��l�ޔ�)
            }
            

            // �����z
            if (campaignMngWork.PriceFl == 0.00)
            {
                dr[ct_COL_PRICEFL] = DBNull.Value;
                dr[ct_COL_PRICEFL_BACKUP] = DBNull.Value;
            }
            else
            {
                dr[ct_COL_PRICEFL] = campaignMngWork.PriceFl;
                dr[ct_COL_PRICEFL_BACKUP] = campaignMngWork.PriceFl;            // �����z(�O��l�ޔ�)
            }

            dr[ct_COL_CAMPAIGNCODE_BACKUP] = campaignMngWork.CampaignCode;      // �L�����y�[���R�[�h(�O��l�ޔ�)

            // �_���폜��(�\���p)
            if ( campaignMngWork.LogicalDeleteCode == 0 )
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString( "ggYY/MM/DD", campaignMngWork.UpdateDateTime );
            }

            dr[ct_COL_SECTIONNM] = campaignMngWork.SectionNm;                   // ���_����
            dr[ct_COL_GOODSMGROUPNAME] = campaignMngWork.GoodsMGroupName;       // ���i�����ޖ���
            dr[ct_COL_BLGROUPNAME] = campaignMngWork.BLGroupName;               // BL�O���[�v����
            dr[ct_COL_BLGOODSNAME] = campaignMngWork.BLGoodsName;               // BL���i�R�[�h����
            dr[ct_COL_MAKERNAME] = campaignMngWork.MakerName;                   // ���[�J�[����
            dr[ct_COL_GOODSNAME] = campaignMngWork.GoodsName;                   // ���i����
            dr[ct_COL_BLGROUPCODE] = campaignMngWork.BLGroupCode;               // BL�O���[�v�R�[�h

            // �\�[�g�p�J����
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue( campaignMngWork.SectionCode );      // ���_�R�[�h
            dr[ct_COL_GOODSMAKERCD_SORT] = GetSortValue( campaignMngWork.GoodsMakerCd );    // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSMGROUP_SORT] = GetSortValue( campaignMngWork.GoodsMGroup );      // ���i�����ރR�[�h
            dr[ct_COL_BLGROUPCODE_SORT] = GetSortValue( campaignMngWork.BLGroupCode );      // BL�O���[�v�R�[�h
            dr[ct_COL_BLGOODSCODE_SORT] = GetSortValue( campaignMngWork.BLGoodsCode );      // BL���i�R�[�h

            // �I�u�W�F�N�g(�����ێ��p)
            dr[ct_COL_CAMPAIGNMNGWORKOBJECT] = campaignMngWork;
            # endregion
        }
        /// <summary>
        /// �\�[�g�l�擾�i���l�j
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetSortValue( int value )
        {
            if ( value != 0 )
            {
                return value;
            }
            else
            {
                // ���ݒ肪���ɂȂ�悤�ɂ���
                return Int32.MaxValue;
            }
        }
        /// <summary>
        /// �\�[�g�l�擾�i������j
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetSortValue( string value )
        {
            if ( value.Trim() != string.Empty )
            {
                return value;
            }
            else
            {
                // ���ݒ肪���ɂȂ�悤�ɂ���
                // (������͋��_�݂̂Ŏg�p���Ă���̂ŕ֋X�I��AA�ɂ��Ă��܂�)
                return "AA";
            }
        }
        /// <summary>
        /// �N���X�����o�[�R�s�[�����iDataRow�˃L�����y�[���Ǘ��N���X�j
        /// </summary>
        /// <param name="row"></param>
        /// <returns>CampaignMngWork</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ����[�N�N���X����L�����y�[���Ǘ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private CampaignMngWork CopyToCampaignMngWorkFromDataRow( DataRow row )
        {
            CampaignMngWork campaignMngWork = (CampaignMngWork)row[ct_COL_CAMPAIGNMNGWORKOBJECT];
            
            // ���������\���ڂ̂ݍ����ւ���
            campaignMngWork.CampaignCode = (int)row[ct_COL_CAMPAIGNCODE];   // �L�����y�[���R�[�h

            // ������
            if (row[ct_COL_RATEVAL] == null || row[ct_COL_RATEVAL] == DBNull.Value)
            {
                campaignMngWork.RateVal = 0.00;
            }
            else
            {
                campaignMngWork.RateVal = (double)row[ct_COL_RATEVAL];
            }

            // �����z
            if (row[ct_COL_PRICEFL] == null || row[ct_COL_PRICEFL] == DBNull.Value)
            {
                campaignMngWork.PriceFl = 0.00;
            }
            else
            {
                campaignMngWork.PriceFl = (double)row[ct_COL_PRICEFL];
            }

            return campaignMngWork;
        }

        /// <summary>
        /// ���o�����N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private CampaignMngOrderWork CopyToCampaignMngOrderWorkFromCampaignMngOrder( CampaignMngOrder paraData )
        {
            CampaignMngOrderWork paraWork = new CampaignMngOrderWork();
            
            # region [paraWork��paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;      // ��ƃR�[�h
            paraWork.SectionCode = paraData.SectionCode;            // ���_�R�[�h
            paraWork.St_GoodsMGroup = paraData.St_GoodsMGroup;      // �J�n���i�����ރR�[�h
            paraWork.Ed_GoodsMGroup = paraData.Ed_GoodsMGroup;      // �I�����i�����ރR�[�h
            paraWork.St_BLGroupCode = paraData.St_BLGroupCode;      // �J�nBL�O���[�v�R�[�h
            paraWork.Ed_BLGroupCode = paraData.Ed_BLGroupCode;      // �I��BL�O���[�v�R�[�h
            paraWork.St_BLGoodsCode = paraData.St_BLGoodsCode;      // �J�nBL���i�R�[�h
            paraWork.Ed_BLGoodsCode = paraData.Ed_BLGoodsCode;      // �I��BL���i�R�[�h
            paraWork.St_GoodsMakerCd = paraData.St_GoodsMakerCd;    // �J�n���i���[�J�[�R�[�h
            paraWork.Ed_GoodsMakerCd = paraData.Ed_GoodsMakerCd;    // �I�����i���[�J�[�R�[�h
            # endregion
            
            return paraWork;
        }

        /// <summary>
        /// �L�����y�[�����̎擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �L�����y�[���ݒ�}�X�^��ǂݍ��݁A�L�����y�[�����̂��擾���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private string GetCampaignName(int campaignCode)
        {
            string name = string.Empty;

            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            if (_campaignStDic == null)
            {
                this._campaignStDic = new Dictionary<int, CampaignSt>();

                ArrayList retList;
                int status = this._campaignStAcs.SearchAll(out retList, EnterpriseCode);

                if (status == 0)
                {
                    foreach (CampaignSt campaignSt in retList)
                    {
                        if (campaignSt.LogicalDeleteCode == 0)
                        {
                            this._campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                        }
                    }
                }
            }

            if (this._campaignStDic.ContainsKey(campaignCode))
            {
                name = this._campaignStDic[campaignCode].CampaignName;
            }

            return name;
        }
        #endregion

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃe�[�u��</param>
        /// <param name="campaignMngList">�L�����y�[���Ǘ��I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�̕��������������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private int SearchProc( CampaignMngOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                //ArrayList paraList = new ArrayList();
                //==========================================
                // �L�����y�[���Ǘ��}�X�^�ǂݍ���
                //==========================================
                CampaignMngOrderWork paraWork = CopyToCampaignMngOrderWorkFromCampaignMngOrder( paraData );

                // �����[�g�߂胊�X�g
                object campaignMngWorkList = null;
                // �L�����y�[���Ǘ��}�X�^����
                status = this._iCampaignMngDB.Search( out campaignMngWorkList, paraWork, 0, logicalMode );

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)campaignMngWorkList;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #region Read ��������
        /// <summary>
        /// �L�����y�[���Ǘ����R�[�h�擾����
        /// </summary>
        /// <param name="campaignMng">�L�����y�[���Ǘ��f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B
        ///                  campaignMng�N���X�Ɍ����f�[�^��ݒ肵�A���ʂ�campaignMng�N���X�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Read(ref CampaignMng campaignMng)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // ���o�����p�����[�^
                CampaignMngWork campaignMngWork = CopyToCampaignMngWorkFromCampaignMng( campaignMng );

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize( campaignMngWork );
                status = this._iCampaignMngDB.Read( ref parabyte, 0 );

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    campaignMngWork = (CampaignMngWork)XmlByteSerializer.Deserialize( parabyte, typeof( CampaignMngWork ) );
                }

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    campaignMng = CopyToCampaignMngFromCampaignMngWork( campaignMngWork );
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                campaignMng = null;
                //�I�t���C������null���Z�b�g
                this._iCampaignMngDB = null;
                return -1;
            }
        }
        #endregion

        #region �L�����y�[���������A�����z�擾����

        // ADD 2009/08/31 �`�P�b�g[14194]�Ή� ------>>>
        /// <summary>
        /// �L�����y�[���������A�����z�擾�����i�����Łj
        /// </summary>
        /// <param name="campaignMng">���o���ʃL�����y�[���Ǘ��f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsMGroup">���i������</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="applyDate">�K�p��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���������A�����z�擾�̎擾���s���܂��B
        ///                  ���o��������L�����y�[���������A�����z�擾�������ݒ肳��Ă���L�����y�[���Ǘ��f�[�^��Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// <br>Note       : �K�p�������ԊO�̏ꍇ�A���ɊY������L�����y�[���Ǘ��}�X�^�̃��R�[�h���擾����悤GetRatePriceOfCampaignMng()������</br>
        /// <br>Programmer : 30434 �H��</br>
        /// <br>Date       : 2009/08/31</br>
        /// </remarks>
        private int GetRatePriceOfCampaignMng2(
            out CampaignMng campaignMng,
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            int goodsMakerCd,
            int goodsMGroup,
            int blGoodsCode,
            string goodsNo,
            DateTime applyDate
        )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
            // �L�[��ݒ肷��ہA�X�y�[�X�͍���Ă���̂ŁA�p�����[�^���X�y�[�X�����
            sectionCode = sectionCode.Trim();
            goodsNo     = goodsNo.Trim();
            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

            #region �L�����y�[���Ǘ��}�X�^�̋��_�������ʂ��L���b�V��

            if (_campaignMngDic == null)
            {
                // �L�����y�[���Ǘ��L���b�V���Ƀf�[�^�������̂Ŏ擾
                CampaignMngOrder campaignMngOrder = new CampaignMngOrder();
                campaignMngOrder.EnterpriseCode = enterpriseCode;
                campaignMngOrder.SectionCode = null;

                List<CampaignMng> retList;
                string message;

                // �L�����y�[���Ǘ��}�X�^�̑S����
                status = Search(campaignMngOrder, out retList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �S�����Ŏ��s
                    campaignMng = null;

                    _statusOfResult = "�L�����y�[���Ǘ��}�X�^�̑S�����Ŏ��s";

                    return status;
                }

                //�L�����y�[���Ǘ��f�[�^�̃L���b�V����
                _campaignMngDic = new Dictionary<DICKEY, CampaignMng>();

                foreach (CampaignMng wkCampaignMng in retList)
                {
                    if (wkCampaignMng.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    // �ǉ��L�[�쐬
                    DICKEY addKey = new DICKEY();
                    addKey.sectionCode = wkCampaignMng.SectionCode.TrimEnd();
                    addKey.goodsMGroup = wkCampaignMng.GoodsMGroup;
                    addKey.blGoodsCode = wkCampaignMng.BLGoodsCode;
                    addKey.goodsMakerCd = wkCampaignMng.GoodsMakerCd;
                    addKey.goodsNo = wkCampaignMng.GoodsNo.Trim();

                    if (!_campaignMngDic.ContainsKey(addKey))
                    {
                        _campaignMngDic.Add(addKey, wkCampaignMng);
                    }
                }
            }

            #endregion // �L�����y�[���Ǘ��}�X�^�̋��_�������ʂ��L���b�V��

            #region ���ƂȂ�L�����y�[���Ǘ��}�X�^�̃��R�[�h��S�Ď擾

            // �L�����y�[���Ǘ��L���b�V������f�[�^�擾
            List<KeyValuePair<string, CampaignMng>> foundCampaignMngList = new List<KeyValuePair<string, CampaignMng>>();
            {
                // �L�[�쐬
                DICKEY key = new DICKEY();
                key.sectionCode = sectionCode.TrimEnd();
                key.goodsMakerCd = goodsMakerCd;
                key.goodsNo = goodsNo.Trim();
                if (!string.IsNullOrEmpty(key.goodsNo) && _campaignMngDic.ContainsKey(key))
                {
                    // �@���[�J�[�{�i��
                    string info = string.Format(
                        "�@���_(={0}) + ���[�J�[(={1}) + �i��(={2})",
                        sectionCode,
                        goodsMakerCd,
                        goodsNo
                    );
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                // �L�[�ύX
                key.goodsNo = string.Empty;
                key.blGoodsCode = blGoodsCode;
                if (key.blGoodsCode > 0 && _campaignMngDic.ContainsKey(key))
                {
                    // �A���[�J�[�{BL�R�[�h
                    string info = string.Format(
                        "�A���_(={0}) + ���[�J�[(={1}) + BL�R�[�h(={2})",
                        sectionCode,
                        goodsMakerCd,
                        blGoodsCode
                    );
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                // �L�[�ύX
                key.blGoodsCode = 0;
                key.goodsMGroup = goodsMGroup;
                if (key.goodsMGroup > 0 && _campaignMngDic.ContainsKey(key))
                {
                    // �B���[�J�[�{���i������
                    string info = string.Format(
                        "�B���_(={0}) + ���[�J�[(={1}) + ���i������(={2})",
                        sectionCode,
                        goodsMakerCd,
                        goodsMGroup
                    );
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                // �L�[�ύX
                key.goodsMGroup = 0;
                if (_campaignMngDic.ContainsKey(key))
                {
                    // �C���[�J�[
                    string info = string.Format("�C���_(={0}) + ���[�J�[(={1})", sectionCode, goodsMakerCd);
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                if (foundCampaignMngList.Count.Equals(0))
                {
                    // �Y���f�[�^����
                    campaignMng = null;

                    // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
                    _statusOfResult = "�L�����y�[���Ǘ��}�X�^�ɊY���f�[�^����";

                    // �S�ЂōČ���
                    int sectionCodeNo = int.Parse(sectionCode.Trim());
                    if (sectionCodeNo > 0)
                    {
                        _statusOfResult = "�S�Аݒ�ōČ���";

                        return GetRatePriceOfCampaignMng(
                            out campaignMng,
                            enterpriseCode,
                            "00",
                            customerCode,
                            goodsMakerCd,
                            goodsMGroup,
                            blGoodsCode,
                            goodsNo,
                            applyDate
                        );
                    }
                    // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

                    return status;
                }
            }   // List<KeyValuePair<string, CampaignMng>> foundCampaignMngList = new List<KeyValuePair<string, CampaignMng>>();

            #endregion // ���ƂȂ�L�����y�[���Ǘ��}�X�^�̃��R�[�h��S�Ď擾

            CampaignMng readCampaignMng = null;
            string keyInfo = string.Empty;
            foreach (KeyValuePair<string, CampaignMng> foundCampaignMng in foundCampaignMngList)
            {
                readCampaignMng = foundCampaignMng.Value;
                keyInfo         = foundCampaignMng.Key;

                // �L�����y�[���ݒ�}�X�^�̓Ǎ�(�f�B�N�V���i���[�����ݒ�̏ꍇ������̂�)
                string name = GetCampaignName(readCampaignMng.CampaignCode);
                Debug.WriteLine(readCampaignMng.CampaignCode.ToString() + ":" + name);

                // �L�����y�[���ݒ�}�X�^�ƈ�v���邩
                if (this._campaignStDic.ContainsKey(readCampaignMng.CampaignCode))
                {
                    CampaignSt campaignSt = this._campaignStDic[readCampaignMng.CampaignCode];
                    //>>>2010/04/13
                    if (campaignSt.CampaignObjDiv == 9) // 9:���~
                    {
                        campaignMng = null;
                        readCampaignMng = null;
                        _statusOfResult = "�L�����y�[���Ǘ��}�X�^�@�L�����y�[���Ώۋ敪[2:���~]";
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    //<<<2010/04/13

                    //>>>2010/04/13
                    //if (campaignSt.SectionCode.TrimEnd() != sectionCode.TrimEnd())
                    if ((campaignSt.SectionCode.TrimEnd() != "00") &&
                        (campaignSt.SectionCode.TrimEnd() != sectionCode.TrimEnd()))
                    //<<<2010/04/13
                    {
                        // ���_���s��v�̏ꍇ�͏����I��
                        campaignMng = null;
                        readCampaignMng = null;

                        _statusOfResult = "�L�����y�[���Ǘ��}�X�^�ƃL�����y�[���ݒ�}�X�^�̋��_���s��v";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    // �K�p�����͈͓���
                    if ((campaignSt.ApplyStaDate > applyDate) ||
                        (campaignSt.ApplyEndDate < applyDate))
                    {
                        // �K�p�J�n���O�A�܂��͓K�p�I������̏ꍇ�͏����I��
                        campaignMng = null;
                        readCampaignMng = null;

                        _statusOfResult = "�K�p�����͈͊O";
                        Debug.WriteLine(_statusOfResult + ":" + keyInfo);

                        // ���ԊO�̏ꍇ�A���ɗD�悳���L�����y�[���Ǘ�����
                        continue;
                        // TODO:�S�~�|���creturn (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    if (campaignSt.CampaignObjDiv == 0)
                    {
                        // �L�����y�[���Ώۋ敪�F"�S���Ӑ�"
                        CustomerInfo customerInfo;
                        CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                        status = customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �Y�����链�Ӑ悪�����̂ŏ����I��
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "���Ӑ�}�X�^�ɊY�����链�Ӑ悪�Ȃ��i���Ӑ�=�j" + customerCode.ToString();

                            return status;
                        }

                        if (!sectionCode.Trim().Equals("00"))   // ADD 2009/08/25 �`�P�b�g[14065]�Ή� �S�Аݒ�ł̓`�F�b�N���Ȃ�
                        {
                            if (customerInfo.MngSectionCode.TrimEnd() != sectionCode.TrimEnd())
                            {
                                // �Y�����链�Ӑ�̊Ǘ����_����v���Ȃ��̂ŏ����I��
                                campaignMng = null;
                                readCampaignMng = null;

                                _statusOfResult = string.Format(
                                    "�Y�����链�Ӑ�̊Ǘ����_����v���Ȃ��i���Ӑ�={0}??{1}, ���_={2}??{3}�j",
                                    customerInfo.CustomerCode,
                                    customerCode,
                                    customerInfo.MngSectionCode,
                                    sectionCode
                                );

                                return status;
                            }
                        }
                    }
                    else if (campaignSt.CampaignObjDiv == 1)
                    {
                        // �L�����y�[���Ώۋ敪�F"�Ώۓ��Ӑ�"
                        ArrayList retList;
                        CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                        status = campaignLinkAcs.SearchDetail(out retList, enterpriseCode, campaignSt.CampaignCode);

                        // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
                        // �����p�ɕێ�
                        _usedCampaignLinkList = retList;
                        // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �Y������L�����y�[���֘A�}�X�^�������̂ŏ����I��
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "�Y������L�����y�[���֘A�}�X�^������";

                            return status;
                        }
                        else if ((retList == null) || (retList.Count == 0))
                        {
                            // �������ʂ�0���̏ꍇ�������I��
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "�L�����y�[���֘A�}�X�^�̌������ʂ�0��";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }

                        bool searchFlg = false;
                        foreach (CampaignLink wkCampaignLink in retList)
                        {
                            if (wkCampaignLink.CustomerCode == customerCode)
                            {
                                // �L�����y�[���֘A�̓��Ӑ�ƈ�v
                                searchFlg = true;
                                break;
                            }
                        }

                        if (!searchFlg)
                        {
                            // �L�����y�[���֘A�ɊY�����Ӑ悪�����̂ŏ����I��
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "�L�����y�[���֘A�ɊY�����Ӑ悪����";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                    else if (campaignSt.CampaignObjDiv == 2)
                    {
                        // �L�����y�[���Ώۋ敪�F"���~"
                        campaignMng = null;
                        readCampaignMng = null;

                        _statusOfResult = "�L�����y�[���Ώۋ敪�F�u���~�v";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // �Y������L�����y�[���R�[�h�������̂ŏ����I��
                    campaignMng = null;
                    readCampaignMng = null;

                    _statusOfResult = "�Y������L�����y�[���R�[�h������";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (readCampaignMng != null) break;
            }   // foreach (KeyValuePair<string, CampaignMng> foundCampaignMng in foundCampaignMngList)

            // �L�����y�[���Ώ�
            if (readCampaignMng != null)
            {
                campaignMng = readCampaignMng.Clone();
            }
            else
            {
                campaignMng = null;
            }
            _statusOfResult = _statusOfResult.Equals("�S�Аݒ�ōČ���") ? "�S�Аݒ�ōČ���" : "�L�����y�[���Ǘ��������ł��܂����B";
            _statusOfResult += ":" + keyInfo;

            return status;
        }
        // ADD 2009/08/31 �`�P�b�g[14194]�Ή� ------>>>

        /// <summary>
        /// �L�����y�[���������A�����z�擾����
        /// </summary>
        /// <param name="campaignMng">���o���ʃL�����y�[���Ǘ��f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsMGroup">���i������</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="applyDate">�K�p��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���������A�����z�擾�̎擾���s���܂��B
        ///                  ���o��������L�����y�[���������A�����z�擾�������ݒ肳��Ă���L�����y�[���Ǘ��f�[�^��Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int GetRatePriceOfCampaignMng(out CampaignMng campaignMng, string enterpriseCode, string sectionCode, int customerCode, 
                                             int goodsMakerCd, int goodsMGroup, int blGoodsCode, string goodsNo, DateTime applyDate)
        {
        #if _USING_VERSION_2_

            // ADD 2009/08/31 �`�P�b�g[14194]�Ή� ------>>>
            return GetRatePriceOfCampaignMng2(
                out campaignMng,
                enterpriseCode,
                sectionCode,
                customerCode,
                goodsMakerCd,
                goodsMGroup,
                blGoodsCode,
                goodsNo,
                applyDate
            );
            // ADD 2009/08/31 �`�P�b�g[14194]�Ή� ------>>>

        #else

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
            // �L�[��ݒ肷��ہA�X�y�[�X�͍���Ă���̂ŁA�p�����[�^���X�y�[�X�����
            sectionCode = sectionCode.Trim();
            goodsNo     = goodsNo.Trim();
            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

            if (_campaignMngDic == null)
            {
                // �L�����y�[���Ǘ��L���b�V���Ƀf�[�^�������̂Ŏ擾
                CampaignMngOrder campaignMngOrder = new CampaignMngOrder();
                campaignMngOrder.EnterpriseCode = enterpriseCode;
                campaignMngOrder.SectionCode = null;

                List<CampaignMng> retList;
                string message;

                // �L�����y�[���Ǘ��}�X�^�̑S����
                status = Search(campaignMngOrder, out retList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �S�����Ŏ��s
                    campaignMng = null;

                    _statusOfResult = "�L�����y�[���Ǘ��}�X�^�̑S�����Ŏ��s";

                    return status;
                }

                //�L�����y�[���Ǘ��f�[�^�̃L���b�V����
                _campaignMngDic = new Dictionary<DICKEY, CampaignMng>();

                foreach (CampaignMng wkCampaignMng in retList)
                {
                    if (wkCampaignMng.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    // �ǉ��L�[�쐬
                    DICKEY addKey = new DICKEY();
                    addKey.sectionCode = wkCampaignMng.SectionCode.TrimEnd();
                    addKey.goodsMGroup = wkCampaignMng.GoodsMGroup;
                    addKey.blGoodsCode = wkCampaignMng.BLGoodsCode;
                    addKey.goodsMakerCd = wkCampaignMng.GoodsMakerCd;
                    addKey.goodsNo = wkCampaignMng.GoodsNo.Trim();

                    if (!_campaignMngDic.ContainsKey(addKey))
                    {
                        _campaignMngDic.Add(addKey, wkCampaignMng);
                    }
                }
            }

            // �L�����y�[���Ǘ��L���b�V������f�[�^�擾
            CampaignMng readCampaignMng = new CampaignMng();
            // �L�[�쐬
            DICKEY key = new DICKEY();
            key.sectionCode = sectionCode.TrimEnd();
            key.goodsMakerCd = goodsMakerCd;
            key.goodsNo = goodsNo.Trim();
            if (_campaignMngDic.ContainsKey(key))
            {
                // �@���[�J�[�{�i��
                readCampaignMng = _campaignMngDic[key].Clone();
            }
            else
            {
                // �L�[�ύX
                key.goodsNo = string.Empty;
                key.blGoodsCode = blGoodsCode;
                if (_campaignMngDic.ContainsKey(key))
                {
                    // �A���[�J�[�{BL�R�[�h
                    readCampaignMng = _campaignMngDic[key].Clone();
                }
                else
                {
                    // �L�[�ύX
                    key.blGoodsCode = 0;
                    key.goodsMGroup = goodsMGroup;
                    if (_campaignMngDic.ContainsKey(key))
                    {
                        // �B���[�J�[�{���i������
                        readCampaignMng = _campaignMngDic[key].Clone();
                    }
                    else
                    {
                        // �L�[�ύX
                        key.goodsMGroup = 0;
                        if (_campaignMngDic.ContainsKey(key))
                        {
                            // �C���[�J�[
                            readCampaignMng = _campaignMngDic[key].Clone();
                        }
                        else
                        {
                            // �Y���f�[�^����
                            campaignMng = null;

                            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
                            _statusOfResult = "�L�����y�[���Ǘ��}�X�^�ɊY���f�[�^����";

                            // �S�ЂōČ���
                            int sectionCodeNo = int.Parse(sectionCode.Trim());
                            if (sectionCodeNo > 0)
                            {
                                _statusOfResult = "�S�Аݒ�ōČ���";

                                return GetRatePriceOfCampaignMng(
                                    out campaignMng,
                                    enterpriseCode,
                                    "00",
                                    customerCode,
                                    goodsMakerCd,
                                    goodsMGroup,
                                    blGoodsCode,
                                    goodsNo,
                                    applyDate
                                );
                            }
                            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

                            return status;
                        }
                    }
                }
            }

            // �L�����y�[���ݒ�}�X�^�̓Ǎ�(�f�B�N�V���i���[�����ݒ�̏ꍇ������̂�)
            string name = GetCampaignName(readCampaignMng.CampaignCode);

            // �L�����y�[���ݒ�}�X�^�ƈ�v���邩
            if (this._campaignStDic.ContainsKey(readCampaignMng.CampaignCode))
            {
                CampaignSt campaignSt = this._campaignStDic[readCampaignMng.CampaignCode];
                if (campaignSt.SectionCode.TrimEnd() != sectionCode.TrimEnd())
                {
                    // ���_���s��v�̏ꍇ�͏����I��
                    campaignMng = null;

                    _statusOfResult = "�L�����y�[���Ǘ��}�X�^�ƃL�����y�[���ݒ�}�X�^�̋��_���s��v";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                // �K�p�����͈͓���
                if ((campaignSt.ApplyStaDate > applyDate) ||
                    (campaignSt.ApplyEndDate < applyDate))
                {
                    // �K�p�J�n���O�A�܂��͓K�p�I������̏ꍇ�͏����I��
                    campaignMng = null;

                    _statusOfResult = "�K�p�����͈͊O";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (campaignSt.CampaignObjDiv == 0)
                {
                    // �L�����y�[���Ώۋ敪�F"�S���Ӑ�"
                    CustomerInfo customerInfo;
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                    status = customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �Y�����链�Ӑ悪�����̂ŏ����I��
                        campaignMng = null;

                        _statusOfResult = "���Ӑ�}�X�^�ɊY�����链�Ӑ悪�Ȃ��i���Ӑ�=�j" + customerCode.ToString();

                        return status;
                    }

                    if (!sectionCode.Trim().Equals("00"))   // ADD 2009/08/25 �`�P�b�g[14065]�Ή� �S�Аݒ�ł̓`�F�b�N���Ȃ�
                    {
                        if (customerInfo.MngSectionCode.TrimEnd() != sectionCode.TrimEnd())
                        {
                            // �Y�����链�Ӑ�̊Ǘ����_����v���Ȃ��̂ŏ����I��
                            campaignMng = null;

                            _statusOfResult = string.Format(
                                "�Y�����链�Ӑ�̊Ǘ����_����v���Ȃ��i���Ӑ�={0}??{1}, ���_={2}??{3}�j",
                                customerInfo.CustomerCode,
                                customerCode,
                                customerInfo.MngSectionCode,
                                sectionCode
                            );

                            return status;
                        }
                    }
                }
                else if (campaignSt.CampaignObjDiv == 1)
                {
                    // �L�����y�[���Ώۋ敪�F"�Ώۓ��Ӑ�"
                    ArrayList retList;
                    CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                    status = campaignLinkAcs.SearchDetail(out retList, enterpriseCode, campaignSt.CampaignCode);

                    // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
                    // �����p�ɕێ�
                    _usedCampaignLinkList = retList;
                    // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �Y������L�����y�[���֘A�}�X�^�������̂ŏ����I��
                        campaignMng = null;

                        _statusOfResult = "�Y������L�����y�[���֘A�}�X�^������";

                        return status;
                    }
                    else if ((retList == null) || (retList.Count == 0))
                    {
                        // �������ʂ�0���̏ꍇ�������I��
                        campaignMng = null;

                        _statusOfResult = "�L�����y�[���֘A�}�X�^�̌������ʂ�0��";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    bool searchFlg = false;
                    foreach (CampaignLink wkCampaignLink in retList)
                    {
                        if (wkCampaignLink.CustomerCode == customerCode)
                        {
                            // �L�����y�[���֘A�̓��Ӑ�ƈ�v
                            searchFlg = true;
                            break;
                        }
                    }

                    if (!searchFlg)
                    {
                        // �L�����y�[���֘A�ɊY�����Ӑ悪�����̂ŏ����I��
                        campaignMng = null;

                        _statusOfResult = "�L�����y�[���֘A�ɊY�����Ӑ悪����";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else if (campaignSt.CampaignObjDiv == 2)
                {
                    // �L�����y�[���Ώۋ敪�F"���~"
                    campaignMng = null;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            else
            {
                // �Y������L�����y�[���R�[�h�������̂ŏ����I��
                campaignMng = null;

                _statusOfResult = "�Y������L�����y�[���R�[�h������";

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // �L�����y�[���Ώ�
            campaignMng = readCampaignMng.Clone();

            _statusOfResult = _statusOfResult.Equals("�S�Аݒ�ōČ���") ? "�S�Аݒ�ōČ���" : "�L�����y�[���Ǘ��������ł��܂����B";

            return status;

        #endif
        }
        #endregion
    }
}
