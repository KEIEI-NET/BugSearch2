//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d�_�i�ڐݒ�}�X�^
// �v���O�����T�v   : �d�_�i�ڐݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/17  �C�����e : �d�_�i�ڐݒ�}�X�^�̎擾���\�b�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/08/25  �C�����e : �`�P�b�g[14065]�Ή�
//----------------------------------------------------------------------------//

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
    /// �d�_�i�ڐݒ�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�_�i�ڐݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009/05/22</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class ImportantPrtStAcs
    {
        #region public const
        //----------------------------------------
        // �d�_�i�ڐݒ�}�X�^�萔��`
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
        /// <summary>���Ӑ�R�[�h</summary>
        public const string ct_COL_CUSTOMERCODE = "CustomerCode";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_COL_GOODSMGROUP = "GoodsMGroup";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_COL_BLGOODSCODE = "BLGoodsCode";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_COL_GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>���i�ԍ�</summary>
        public const string ct_COL_GOODSNO = "GoodsNo";
        /// <summary>�L���敪</summary>
        public const string ct_COL_VALIDDIVCD = "ValidDivCd";

        /// <summary>�L���敪(�O��ޔ�)</summary>
        public const string ct_COL_ValidDivCd_BACKUP = "ValidDivCd_Backup";

        /// <summary>���_����</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>���Ӑ於��</summary>
        public const string ct_COL_CUSTOMERNAME = "CustomerName";
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
        /// <summary>�d����R�[�h</summary>
        public const string ct_COL_SUPPLIERCD = "SupplierCd";
        /// <summary>�d���旪��</summary>
        public const string ct_COL_SUPPLIERSNM = "SupplierSnm";

        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string ct_COL_BLGROUPCODE = "BLGroupCode";

        # region [�\�[�g�p]
        /// <summary>���_�R�[�h</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string ct_COL_CUSTOMERCODE_SORT = "CustomerCode_Sort";
        /// <summary>�d����R�[�h</summary>
        public const string ct_COL_SUPPLIERCD_SORT = "SupplierCd_Sort";
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
        /// <summary>�d�_�i�ڐݒ�}�X�^work�I�u�W�F�N�g(�����ێ��p)</summary>
        public const string ct_COL_IMPORTANTPRTSTWORKOBJECT = "ImportantPrtStWorkObject";


        // �e�[�u����
        /// <summary>�d�_�i�ڐݒ�e�[�u��</summary>
        public const string ct_TABLE_IMPORTANTPRTST = "ImportantPrtStTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�����o�[
        // ===================================================================================== //
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IImportantPrtStDB _iImportantPrtStDB = null;    // �d�_�i�ڐݒ胊���[�g

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        private GoodsAcs _goodsAcs;

        // ADD 2009/06/17 ------>>>
        // �d�_�i�ڐݒ�f�[�^�f�B�N�V���i���[�@�L�[����
        public struct DICKEY
        {
            /// <summary> ���_�R�[�h </summary>
            public string sectionCode;
            /// <summary> ���Ӑ�R�[�h </summary>
            public int customerCode;
            /// <summary> ���i������ </summary>
            public int goodsMGroup;
            /// <summary> BL�R�[�h </summary>
            public int blGoodsCode;
            /// <summary> ���[�J�[�R�[�h </summary>
            public int goodsMakerCd;
            /// <summary> �i�� </summary>
            public string goodsNo;
        }

        // �d�_�i�ڐݒ�f�[�^�f�B�N�V���i���[
        private Dictionary<DICKEY, ImportantPrtSt> _ImportantPrtStDic = null;
        /// <summary>
        /// �d�_�i�ڐݒ�f�[�^�f�B�N�V���i���[�i�S�������̃L���b�V���j
        /// </summary>
        public Dictionary<DICKEY, ImportantPrtSt> CachedImportantPrtStDic
        {
            get { return _ImportantPrtStDic; }
        }
        // ADD 2009/06/17 ------<<<

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

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
        /// �d�_�i�ڐݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public ImportantPrtStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iImportantPrtStDB = (IImportantPrtStDB)MediationImportantPrtStDB.GetImportantPrtStDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iImportantPrtStDB = null;
            }

            // �_���폜���O����
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// �d�_�i�ڐݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30434 �H��</br>
        /// <br>Date       : 2009/07/14</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public ImportantPrtStAcs(string enterpriseCode, string sectionCode) : this()
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
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iImportantPrtStDB == null)
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
        /// ��ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string EnterpriseCode
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
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���_�R�[�h���擾����ѐݒ肵�܂��B
        /// </summary>
        public string SectionCode
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
            set { _sectionCode = value; }
        }

        /// <summary>
        /// ���i�������擾���܂��B
        /// </summary>
        private GoodsAcs GoodsAccesser
        {
            get
            {
                if (_goodsAcs == null)
                {
                    _goodsAcs = new GoodsAcs();
                    string msg = string.Empty;
                    _goodsAcs.SearchInitial(EnterpriseCode, SectionCode, out msg);
                }
                return _goodsAcs;
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
                _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Clear();
            }
        }

        /// <summary>
        /// �d�_�i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�d�_�i�ڐݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="importantPrtStList">�d�_�i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Search( ImportantPrtStOrder paraData, out List<ImportantPrtSt> retList, out string message )
        {
            if ( _goodsAcs == null )
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            }

            // ����
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // ���ʊi�[
            retList = new List<ImportantPrtSt>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is ImportantPrtStWork )
                    {
                        ImportantPrtStWork retWork = (obj as ImportantPrtStWork);

                        // ���i�Ǘ������d������擾
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        // �d����͈͔���
                        if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                             (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                        {
                            continue;
                        }

                        // �l���Z�b�g
                        ImportantPrtSt importantPrtSt = CopyToImportantPrtStFromImportantPrtStWork( retWork );
                        if ( goodsUnitData != null )
                        {
                            importantPrtSt.SupplierCd = goodsUnitData.SupplierCd;
                            importantPrtSt.SupplierSnm = goodsUnitData.SupplierSnm;
                        }
                        retList.Add( importantPrtSt );
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
            _goodsAcs = null;
            _ImportantPrtStDic = null;  // ADD 2009/06/17
            this.Clear();
        }

        /// <summary>
        /// �d�_�i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�d�_�i�ڐݒ�}�X�����p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( ImportantPrtStOrder paraData, out string message )
        {
            if ( _goodsAcs == null )
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            }

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
                    if ( obj is ImportantPrtStWork )
                    {
                        ImportantPrtStWork retWork = (obj as ImportantPrtStWork);

                        // �A�N�Z�X�N���X����DataTable�ɒǉ�
                        DataRow row = this._dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].NewRow();

                        // ���i�Ǘ������d������擾
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        // �d����͈͔���
                        if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                             (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                        {
                            continue;
                        }

                        // �l���Z�b�g
                        CopyToDataRowFromImportantPrtStWork( ref row, retWork, goodsUnitData );
                        _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Add( row );
                    }
                }
            }
            if ( _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Count == 0 )
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
        /// <remarks>�d�_�i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public ImportantPrtSt GetRecordForMaintenance( Guid guid )
        {
            ImportantPrtStWork importantPrtStWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_IMPORTANTPRTST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    importantPrtStWork = CopyToImportantPrtStWorkFromDataRow( view[0].Row );
                }
            }

            // �Y�������Ȃ��f�[�^
            if ( importantPrtStWork == null )
            {
                importantPrtStWork = new ImportantPrtStWork();
            }

            return this.CopyToImportantPrtStFromImportantPrtStWork( importantPrtStWork );
        }
        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�d�_�i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_IMPORTANTPRTST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    row = view[0].Row;
                }
            }

            // �Y�������Ȃ�NULL
            return row;
        }
        /// <summary>
        /// ���i�Ǘ����擾����
        /// </summary>
        /// <param name="scmPrtSettngWork"></param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsMngInfo( ImportantPrtStWork scmPrtSettngWork )
        {
            GoodsUnitData goodsUnitData;

            if ( scmPrtSettngWork.GoodsNo == string.Empty )
            {
                goodsUnitData = new GoodsUnitData();

                goodsUnitData.EnterpriseCode = scmPrtSettngWork.EnterpriseCode.Trim();
                goodsUnitData.SectionCode = scmPrtSettngWork.SectionCode.Trim();
                goodsUnitData.GoodsMakerCd = scmPrtSettngWork.GoodsMakerCd;
                goodsUnitData.GoodsMGroup = scmPrtSettngWork.GoodsMGroup;
                goodsUnitData.BLGoodsCode = scmPrtSettngWork.BLGoodsCode;
                goodsUnitData.GoodsNo = scmPrtSettngWork.GoodsNo.Trim();

                GoodsAccesser.GetGoodsMngInfo( ref goodsUnitData );
            }
            else
            {
                GoodsAccesser.Read(scmPrtSettngWork.EnterpriseCode.Trim(), scmPrtSettngWork.GoodsMakerCd, scmPrtSettngWork.GoodsNo.Trim(), out goodsUnitData);
            }

            return goodsUnitData;
        }
        #endregion

        #region Write �������ݏ���
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="importantPrtStList">�ۑ��f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ݏ������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Write(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraImportantPrtStList = new ArrayList();
                ImportantPrtStWork importantPrtStWork = null;

                for ( int i = 0; i < importantPrtStList.Count; i++ )
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt( (ImportantPrtSt)importantPrtStList[i] );
                    paraImportantPrtStList.Add( importantPrtStWork );
                }

                object paraObj = (object)paraImportantPrtStList;

                // �������ݏ���
                status = this._iImportantPrtStDB.Write( ref paraObj );

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
                this._iImportantPrtStDB = null;
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
                DataView view = new DataView( _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST] );
                view.RowFilter = string.Format( "{0}<>{1}", ct_COL_VALIDDIVCD, ct_COL_ValidDivCd_BACKUP );

                return view.Count;
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
                ArrayList paraImportantPrtStList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows )
                {
                    // �ύX�L���`�F�b�N
                    if ( (int)row[ct_COL_VALIDDIVCD] == (int)row[ct_COL_ValidDivCd_BACKUP] )
                    {
                        // �ύX�\�ȍ��ڂ�Search���ƕς��Ȃ��̂őΏۊO�ɂ���
                        continue;
                    }

                    ImportantPrtStWork importantPrtStWork = CopyToImportantPrtStWorkFromDataRow( row );
                    paraImportantPrtStList.Add( importantPrtStWork );
                }
                // �ύX�L���`�F�b�N
                if ( paraImportantPrtStList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "�X�V�Ώۂ̃f�[�^�����݂��܂���";
                    return status;
                }

                object paraObj = (object)paraImportantPrtStList;


                // �������ݏ���
                status = this._iImportantPrtStDB.Write( ref paraObj );

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
                this._iImportantPrtStDB = null;
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
                    if ( obj is ImportantPrtStWork )
                    {
                        ImportantPrtStWork retWork = (ImportantPrtStWork)obj;

                        DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        if ( row == null )
                        {
                            // �ǉ�
                            row = _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].NewRow();
                            CopyToDataRowFromImportantPrtStWork( ref row, retWork, goodsUnitData );
                            _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Add( row );
                        }
                        else
                        {
                            // �X�V
                            CopyToDataRowFromImportantPrtStWork( ref row, retWork, goodsUnitData );
                        }
                    }
                }
            }
        }
        /// <summary>
        /// �����f�[�^�e�[�u��������������(�����폜��)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList importantPrtStWorkList )
        {
            foreach ( object obj in importantPrtStWorkList )
            {
                if ( obj is ImportantPrtStWork )
                {
                    ImportantPrtStWork retWork = (ImportantPrtStWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // �폜
                        _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="importantPrtStList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraImportantPrtStList = new ArrayList();
                ImportantPrtStWork importantPrtStWork = null;

                for (int i = 0; i < importantPrtStList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt((ImportantPrtSt)importantPrtStList[i]);

                    paraImportantPrtStList.Add(importantPrtStWork);
                }
                object paraObj = (object)paraImportantPrtStList;

                // �_���폜����
                status = this._iImportantPrtStDB.LogicalDelete( ref paraObj );

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
                this._iImportantPrtStDB = null;
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
        /// <param name="importantPrtStList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Revival(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraImportantPrtStList = new ArrayList();
                ImportantPrtStWork importantPrtStWork = null;

                for (int i = 0; i < importantPrtStList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt((ImportantPrtSt)importantPrtStList[i]);

                    paraImportantPrtStList.Add(importantPrtStWork);
                }

                object paraObj = (object)paraImportantPrtStList;

                // �������ݏ���
                status = this._iImportantPrtStDB.RevivalLogicalDelete(ref paraObj);

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
                this._iImportantPrtStDB = null;
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
        /// <param name="importantPrtStList">�폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Delete(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraImportantPrtStWork = null;
                ImportantPrtStWork importantPrtStWork = null;
                ArrayList importantPrtStWorkList = new ArrayList(); // ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < importantPrtStList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt((ImportantPrtSt)importantPrtStList[i]);
                    importantPrtStWorkList.Add(importantPrtStWork);
                }
                // ArrayList����z��𐶐�
                ImportantPrtStWork[] importantPrtStWorks = (ImportantPrtStWork[])importantPrtStWorkList.ToArray(typeof(ImportantPrtStWork));

                // �V���A���C�Y
                paraImportantPrtStWork = XmlByteSerializer.Serialize(importantPrtStWorks);

                // �����폜����
                status = this._iImportantPrtStDB.Delete(paraImportantPrtStWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // �e�[�u������폜
                        DeleteFromDataTable( importantPrtStWorkList );
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
                this._iImportantPrtStDB = null;
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
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // �d�_�i�ڐݒ�e�[�u�����`
            //----------------------------------------------------------------
            DataTable importantPrtStTable = new DataTable( ct_TABLE_IMPORTANTPRTST );


            // �쐬����
            importantPrtStTable.Columns.Add( ct_COL_CREATEDATETIME, typeof( DateTime ) );
            // �X�V����
            importantPrtStTable.Columns.Add( ct_COL_UPDATEDATETIME, typeof( DateTime ) );
            // ��ƃR�[�h
            importantPrtStTable.Columns.Add( ct_COL_ENTERPRISECODE, typeof( string ) );
            // GUID
            importantPrtStTable.Columns.Add( ct_COL_FILEHEADERGUID, typeof( Guid ) );
            // �X�V�]�ƈ��R�[�h
            importantPrtStTable.Columns.Add( ct_COL_UPDEMPLOYEECODE, typeof( string ) );
            // �X�V�A�Z���u��ID1
            importantPrtStTable.Columns.Add( ct_COL_UPDASSEMBLYID1, typeof( string ) );
            // �X�V�A�Z���u��ID2
            importantPrtStTable.Columns.Add( ct_COL_UPDASSEMBLYID2, typeof( string ) );
            // �_���폜�敪
            importantPrtStTable.Columns.Add( ct_COL_LOGICALDELETECODE, typeof( Int32 ) );
            // ���_�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_SECTIONCODE, typeof( string ) );
            // ���Ӑ�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_CUSTOMERCODE, typeof( Int32 ) );
            // ���i�����ރR�[�h
            importantPrtStTable.Columns.Add( ct_COL_GOODSMGROUP, typeof( Int32 ) );
            // BL���i�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_BLGOODSCODE, typeof( Int32 ) );
            // ���i���[�J�[�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_GOODSMAKERCD, typeof( Int32 ) );
            // ���i�ԍ�
            importantPrtStTable.Columns.Add( ct_COL_GOODSNO, typeof( string ) );
            // �L���敪
            importantPrtStTable.Columns.Add( ct_COL_VALIDDIVCD, typeof( Int32 ) );

            // �L���敪
            importantPrtStTable.Columns.Add( ct_COL_ValidDivCd_BACKUP, typeof( Int32 ) );

            // ���_����
            importantPrtStTable.Columns.Add( ct_COL_SECTIONNM, typeof( string ) );
            // ���Ӑ於��
            importantPrtStTable.Columns.Add( ct_COL_CUSTOMERNAME, typeof( string ) );
            // ���i�����ޖ���
            importantPrtStTable.Columns.Add( ct_COL_GOODSMGROUPNAME, typeof( string ) );
            // BL�O���[�v����
            importantPrtStTable.Columns.Add( ct_COL_BLGROUPNAME, typeof( string ) );
            // BL���i�R�[�h����
            importantPrtStTable.Columns.Add( ct_COL_BLGOODSNAME, typeof( string ) );
            // ���[�J�[����
            importantPrtStTable.Columns.Add( ct_COL_MAKERNAME, typeof( string ) );
            // ���i����
            importantPrtStTable.Columns.Add( ct_COL_GOODSNAME, typeof( string ) );
            // �d����R�[�h
            importantPrtStTable.Columns.Add( ct_COL_SUPPLIERCD, typeof( Int32 ) );
            // �d���旪��
            importantPrtStTable.Columns.Add( ct_COL_SUPPLIERSNM, typeof( string ) );

            // �O���[�v�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_BLGROUPCODE, typeof( Int32 ) );

            # region [�\�[�g�p]
            // ���_�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_SECTIONCODE_SORT, typeof( string ) );
            // ���Ӑ�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_CUSTOMERCODE_SORT, typeof( Int32 ) );
            // ���i�����ރR�[�h
            importantPrtStTable.Columns.Add( ct_COL_GOODSMGROUP_SORT, typeof( Int32 ) );
            // BL���i�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_BLGOODSCODE_SORT, typeof( Int32 ) );
            // ���i���[�J�[�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_GOODSMAKERCD_SORT, typeof( Int32 ) );
            // �d����R�[�h
            importantPrtStTable.Columns.Add( ct_COL_SUPPLIERCD_SORT, typeof( Int32 ) );
            // �O���[�v�R�[�h
            importantPrtStTable.Columns.Add( ct_COL_BLGROUPCODE_SORT, typeof( Int32 ) );
            # endregion


            // �_���폜��(�\���p)
            importantPrtStTable.Columns.Add( ct_COL_LOGICALDELETEDATE, typeof( string ) );
            // �I�u�W�F�N�g(�����ێ��p)
            importantPrtStTable.Columns.Add( ct_COL_IMPORTANTPRTSTWORKOBJECT, typeof( ImportantPrtStWork ) );

            this._dataTableList.Tables.Add(importantPrtStTable);

            //----------------------------------------------------------------
            // �f�[�^�r���[����
            //----------------------------------------------------------------
            this._dataView = new DataView( importantPrtStTable );
            this._dataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                                                ct_COL_SECTIONCODE_SORT,
                                                ct_COL_CUSTOMERCODE_SORT,
                                                ct_COL_SUPPLIERCD_SORT,
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
        /// �N���X�����o�[�R�s�[�����i�d�_�i�ڐݒ�N���X�ˏd�_�i�ڐݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="importantPrtSt">�d�_�i�ڐݒ�N���X</param>
        /// <returns>ImportantPrtStWork</returns>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ�N���X����d�_�i�ڐݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private ImportantPrtStWork CopyToImportantPrtStWorkFromImportantPrtSt(ImportantPrtSt importantPrtSt)
        {
            ImportantPrtStWork importantPrtStWork = new ImportantPrtStWork();

            importantPrtStWork.CreateDateTime = importantPrtSt.CreateDateTime;          // �쐬����
            importantPrtStWork.UpdateDateTime = importantPrtSt.UpdateDateTime;          // �X�V����
            importantPrtStWork.EnterpriseCode = importantPrtSt.EnterpriseCode;          // ��ƃR�[�h
            importantPrtStWork.FileHeaderGuid = importantPrtSt.FileHeaderGuid;          // GUID
            importantPrtStWork.UpdEmployeeCode = importantPrtSt.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            importantPrtStWork.UpdAssemblyId1 = importantPrtSt.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            importantPrtStWork.UpdAssemblyId2 = importantPrtSt.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            importantPrtStWork.LogicalDeleteCode = importantPrtSt.LogicalDeleteCode;    // �_���폜�敪
            importantPrtStWork.SectionCode = importantPrtSt.SectionCode;                // ���_�R�[�h
            importantPrtStWork.CustomerCode = importantPrtSt.CustomerCode;              // ���Ӑ�R�[�h
            importantPrtStWork.GoodsMGroup = importantPrtSt.GoodsMGroup;                // ���i�����ރR�[�h
            importantPrtStWork.BLGroupCode = importantPrtSt.BLGroupCode;                // BL�O���[�v�R�[�h
            importantPrtStWork.BLGoodsCode = importantPrtSt.BLGoodsCode;                // BL���i�R�[�h
            importantPrtStWork.GoodsMakerCd = importantPrtSt.GoodsMakerCd;              // ���i���[�J�[�R�[�h
            importantPrtStWork.GoodsNo = importantPrtSt.GoodsNo;                        // ���i�ԍ�
            importantPrtStWork.ValidDivCd = importantPrtSt.ValidDivCd;                  // �L���敪
            importantPrtStWork.SectionNm = importantPrtSt.SectionNm;                    // ���_����
            importantPrtStWork.CustomerName = importantPrtSt.CustomerName;              // ���Ӑ於��
            importantPrtStWork.GoodsMGroupName = importantPrtSt.GoodsMGroupName;        // ���i�����ޖ���
            importantPrtStWork.BLGroupName = importantPrtSt.BLGroupName;                // BL�O���[�v����
            importantPrtStWork.BLGoodsName = importantPrtSt.BLGoodsName;                // BL���i�R�[�h����
            importantPrtStWork.MakerName = importantPrtSt.MakerName;                    // ���[�J�[����
            importantPrtStWork.GoodsName = importantPrtSt.GoodsName;                    // ���i����
            //importantPrtStWork.SupplierCd = importantPrtSt.SupplierCd; // �d����R�[�h
            //importantPrtStWork.SupplierSnm = importantPrtSt.SupplierSnm; // �d���旪��

            return importantPrtStWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d�_�i�ڐݒ胏�[�N�N���X�ˏd�_�i�ڐݒ�N���X�j
        /// </summary>
        /// <param name="importantPrtStWork">�d�_�i�ڐݒ胏�[�N�N���X</param>
        /// <returns>ImportantPrtSt</returns>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ胏�[�N�N���X����d�_�i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private ImportantPrtSt CopyToImportantPrtStFromImportantPrtStWork(ImportantPrtStWork importantPrtStWork)
        {
            ImportantPrtSt importantPrtSt = new ImportantPrtSt();

            importantPrtSt.CreateDateTime = importantPrtStWork.CreateDateTime;          // �쐬����
            importantPrtSt.UpdateDateTime = importantPrtStWork.UpdateDateTime;          // �X�V����
            importantPrtSt.EnterpriseCode = importantPrtStWork.EnterpriseCode;          // ��ƃR�[�h
            importantPrtSt.FileHeaderGuid = importantPrtStWork.FileHeaderGuid;          // GUID
            importantPrtSt.UpdEmployeeCode = importantPrtStWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            importantPrtSt.UpdAssemblyId1 = importantPrtStWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            importantPrtSt.UpdAssemblyId2 = importantPrtStWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            importantPrtSt.LogicalDeleteCode = importantPrtStWork.LogicalDeleteCode;    // �_���폜�敪
            importantPrtSt.SectionCode = importantPrtStWork.SectionCode;                // ���_�R�[�h
            importantPrtSt.CustomerCode = importantPrtStWork.CustomerCode;              // ���Ӑ�R�[�h
            importantPrtSt.GoodsMGroup = importantPrtStWork.GoodsMGroup;                // ���i�����ރR�[�h
            importantPrtSt.BLGroupCode = importantPrtStWork.BLGroupCode;                // BL�O���[�v�R�[�h
            importantPrtSt.BLGoodsCode = importantPrtStWork.BLGoodsCode;                // BL���i�R�[�h
            importantPrtSt.GoodsMakerCd = importantPrtStWork.GoodsMakerCd;              // ���i���[�J�[�R�[�h
            importantPrtSt.GoodsNo = importantPrtStWork.GoodsNo;                        // ���i�ԍ�
            importantPrtSt.ValidDivCd = importantPrtStWork.ValidDivCd;                  // �L���敪
            importantPrtSt.SectionNm = importantPrtStWork.SectionNm;                    // ���_����
            importantPrtSt.CustomerName = importantPrtStWork.CustomerName;              // ���Ӑ於��
            importantPrtSt.GoodsMGroupName = importantPrtStWork.GoodsMGroupName;        // ���i�����ޖ���
            importantPrtSt.BLGroupName = importantPrtStWork.BLGroupName;                // BL�O���[�v����
            importantPrtSt.BLGoodsName = importantPrtStWork.BLGoodsName;                // BL���i�R�[�h����
            importantPrtSt.MakerName = importantPrtStWork.MakerName;                    // ���[�J�[����
            importantPrtSt.GoodsName = importantPrtStWork.GoodsName;                    // ���i����
            //importantPrtSt.SupplierCd = importantPrtStWork.SupplierCd; // �d����R�[�h
            //importantPrtSt.SupplierSnm = importantPrtStWork.SupplierSnm; // �d���旪��

            return importantPrtSt;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d�_�i�ڐݒ�N���X��DataRow�j
        /// </summary>
        /// <param name="importantPrtStWork">�d�_�i�ڐݒ�N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ胏�[�N�N���X����d�_�i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private void CopyToDataRowFromImportantPrtStWork( ref DataRow dr, ImportantPrtStWork importantPrtStWork, GoodsUnitData goodsUnitData )
        {
            # region [dr��importantPrtSt]
            dr[ct_COL_CREATEDATETIME] = importantPrtStWork.CreateDateTime;          // �쐬����
            dr[ct_COL_UPDATEDATETIME] = importantPrtStWork.UpdateDateTime;          // �X�V����
            dr[ct_COL_ENTERPRISECODE] = importantPrtStWork.EnterpriseCode;          // ��ƃR�[�h
            dr[ct_COL_FILEHEADERGUID] = importantPrtStWork.FileHeaderGuid;          // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = importantPrtStWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            dr[ct_COL_UPDASSEMBLYID1] = importantPrtStWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            dr[ct_COL_UPDASSEMBLYID2] = importantPrtStWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            dr[ct_COL_LOGICALDELETECODE] = importantPrtStWork.LogicalDeleteCode;    // �_���폜�敪
            dr[ct_COL_SECTIONCODE] = importantPrtStWork.SectionCode;                // ���_�R�[�h
            dr[ct_COL_CUSTOMERCODE] = importantPrtStWork.CustomerCode;              // ���Ӑ�R�[�h
            dr[ct_COL_GOODSMGROUP] = importantPrtStWork.GoodsMGroup;                // ���i�����ރR�[�h
            dr[ct_COL_BLGOODSCODE] = importantPrtStWork.BLGoodsCode;                // BL���i�R�[�h
            dr[ct_COL_GOODSMAKERCD] = importantPrtStWork.GoodsMakerCd;              // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSNO] = importantPrtStWork.GoodsNo;                        // ���i�ԍ�
            dr[ct_COL_VALIDDIVCD] = importantPrtStWork.ValidDivCd;                  // �L���敪
            dr[ct_COL_ValidDivCd_BACKUP] = importantPrtStWork.ValidDivCd;           // �L���敪(�O��l�ޔ�)

            // �_���폜��(�\���p)
            if ( importantPrtStWork.LogicalDeleteCode == 0 )
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString( "ggYY/MM/DD", importantPrtStWork.UpdateDateTime );
            }

            dr[ct_COL_SECTIONNM] = importantPrtStWork.SectionNm;                    // ���_����
            dr[ct_COL_CUSTOMERNAME] = importantPrtStWork.CustomerName;              // ���Ӑ於��
            dr[ct_COL_GOODSMGROUPNAME] = importantPrtStWork.GoodsMGroupName;        // ���i�����ޖ���
            dr[ct_COL_BLGROUPNAME] = importantPrtStWork.BLGroupName;                // BL�O���[�v����
            dr[ct_COL_BLGOODSNAME] = importantPrtStWork.BLGoodsName;                // BL���i�R�[�h����
            dr[ct_COL_MAKERNAME] = importantPrtStWork.MakerName;                    // ���[�J�[����
            dr[ct_COL_GOODSNAME] = importantPrtStWork.GoodsName;                    // ���i����
            dr[ct_COL_BLGROUPCODE] = importantPrtStWork.BLGroupCode;                // BL�O���[�v�R�[�h

            // ���i��񂩂�Z�b�g����
            dr[ct_COL_SUPPLIERCD] = goodsUnitData.SupplierCd;                       // �d����R�[�h
            dr[ct_COL_SUPPLIERSNM] = goodsUnitData.SupplierSnm;                     // �d���旪��

            // �\�[�g�p�J����
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue( importantPrtStWork.SectionCode );   // ���_�R�[�h
            dr[ct_COL_CUSTOMERCODE_SORT] = GetSortValue( importantPrtStWork.CustomerCode ); // ���Ӑ�R�[�h
            dr[ct_COL_SUPPLIERCD_SORT] = GetSortValue( goodsUnitData.SupplierCd );          // �d����R�[�h
            dr[ct_COL_GOODSMAKERCD_SORT] = GetSortValue( importantPrtStWork.GoodsMakerCd ); // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSMGROUP_SORT] = GetSortValue( importantPrtStWork.GoodsMGroup );   // ���i�����ރR�[�h
            dr[ct_COL_BLGROUPCODE_SORT] = GetSortValue( importantPrtStWork.BLGroupCode );   // BL�O���[�v�R�[�h
            dr[ct_COL_BLGOODSCODE_SORT] = GetSortValue( importantPrtStWork.BLGoodsCode );   // BL���i�R�[�h

            // �I�u�W�F�N�g(�����ێ��p)
            dr[ct_COL_IMPORTANTPRTSTWORKOBJECT] = importantPrtStWork;
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
        /// �N���X�����o�[�R�s�[�����iDataRow�ˏd�_�i�ڐݒ�N���X�j
        /// </summary>
        /// <param name="row"></param>
        /// <returns>ImportantPrtStWork</returns>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ胏�[�N�N���X����d�_�i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private ImportantPrtStWork CopyToImportantPrtStWorkFromDataRow( DataRow row )
        {
            ImportantPrtStWork importantPrtStWork = (ImportantPrtStWork)row[ct_COL_IMPORTANTPRTSTWORKOBJECT];
            
            // ���������\���ڂ̂ݍ����ւ���
            importantPrtStWork.ValidDivCd = (int)row[ct_COL_VALIDDIVCD];

            return importantPrtStWork;
        }

        /// <summary>
        /// ���o�����N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private ImportantPrtStOrderWork CopyToImportantPrtStOrderWorkFromImportantPrtStOrder( ImportantPrtStOrder paraData )
        {
            ImportantPrtStOrderWork paraWork = new ImportantPrtStOrderWork();
            
            # region [paraWork��paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;      // ��ƃR�[�h
            paraWork.SectionCode = paraData.SectionCode;            // ���_�R�[�h
            paraWork.St_CustomerCode = paraData.St_CustomerCode;    // �J�n���Ӑ�R�[�h
            paraWork.Ed_CustomerCode = paraData.Ed_CustomerCode;    // �I�����Ӑ�R�[�h
            //paraWork.St_SupplierCd = paraData.St_SupplierCd;  // �J�n�d����R�[�h
            //paraWork.Ed_SupplierCd = paraData.Ed_SupplierCd;  // �I���d����R�[�h
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
        #endregion

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃe�[�u��</param>
        /// <param name="importantPrtStList">�d�_�i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d�_�i�ڐݒ�}�X�^�̕��������������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private int SearchProc( ImportantPrtStOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                //ArrayList paraList = new ArrayList();
                //==========================================
                // �d�_�i�ڐݒ�}�X�^�ǂݍ���
                //==========================================
                ImportantPrtStOrderWork paraWork = CopyToImportantPrtStOrderWorkFromImportantPrtStOrder( paraData );

                // �����[�g�߂胊�X�g
                object importantPrtStWorkList = null;
                // �d�_�i�ڐݒ�}�X�^����
                status = this._iImportantPrtStDB.Search( out importantPrtStWorkList, paraWork, 0, logicalMode );

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)importantPrtStWorkList;
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
        /// �d�_�i�ڐݒ背�R�[�h�擾����
        /// </summary>
        /// <param name="importantPrtSt">�d�_�i�ڐݒ�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B
        ///                  importantPrtSt�N���X�Ɍ����f�[�^��ݒ肵�A���ʂ�importantPrtSt�N���X�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Read(ref ImportantPrtSt importantPrtSt)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // ���o�����p�����[�^
                ImportantPrtStWork importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt( importantPrtSt );

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize( importantPrtStWork );
                status = this._iImportantPrtStDB.Read( ref parabyte, 0 );

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    importantPrtStWork = (ImportantPrtStWork)XmlByteSerializer.Deserialize( parabyte, typeof( ImportantPrtStWork ) );
                }

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    importantPrtSt = CopyToImportantPrtStFromImportantPrtStWork( importantPrtStWork );
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                importantPrtSt = null;
                //�I�t���C������null���Z�b�g
                this._iImportantPrtStDB = null;
                return -1;
            }
        }
        #endregion

        // ADD 2009/06/17 ------>>>
        #region �d�_�i�ڐݒ�f�[�^�擾����
        /// <summary>
        /// �d�_�i�ڐݒ�f�[�^����
        /// </summary>
        /// <param name="importantPrtSt">���o���ʂ̏d�_�i�ڐݒ�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsMGroup">���i������</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o��������d�_�i�ڐݒ�f�[�^��Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009/06/16</br>
        /// </remarks>
        public int GetImportantPrtSt(out ImportantPrtSt importantPrtSt, string enterpriseCode, string sectionCode, int customerCode,
                                     int goodsMakerCd, int goodsMGroup, int blGoodsCode, string goodsNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
            // �L�[��ݒ肷��ہA�X�y�[�X�͍���Ă���̂ŁA�p�����[�^���X�y�[�X�����
            sectionCode = sectionCode.Trim();
            goodsNo     = goodsNo.Trim();
            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

            if (_ImportantPrtStDic == null)
            {
                // �d�_�i�ڐݒ�L���b�V���Ƀf�[�^�������̂Ŏ擾
                ImportantPrtStOrder importantPrtStOrder = new ImportantPrtStOrder();
                importantPrtStOrder.EnterpriseCode = enterpriseCode;
                importantPrtStOrder.SectionCode = null;

                List<ImportantPrtSt> retList;
                string message;

                // �d�_�i�ڐݒ�}�X�^�̑S����
                status = Search(importantPrtStOrder, out retList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �S�����Ŏ��s
                    importantPrtSt = null;
                    return status;
                }

                // �d�_�i�ڐݒ�f�[�^�̃L���b�V����
                _ImportantPrtStDic = new Dictionary<DICKEY, ImportantPrtSt>();

                foreach (ImportantPrtSt wkImportantPrtSt in retList)
                {
                    if (wkImportantPrtSt.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    // �ǉ��L�[�쐬
                    DICKEY addKey = new DICKEY();
                    addKey.sectionCode = wkImportantPrtSt.SectionCode.TrimEnd();
                    addKey.customerCode = wkImportantPrtSt.CustomerCode;
                    addKey.goodsMGroup = wkImportantPrtSt.GoodsMGroup;
                    addKey.blGoodsCode = wkImportantPrtSt.BLGoodsCode;
                    addKey.goodsMakerCd = wkImportantPrtSt.GoodsMakerCd;
                    addKey.goodsNo = wkImportantPrtSt.GoodsNo.Trim();

                    if (!_ImportantPrtStDic.ContainsKey(addKey))
                    {
                        _ImportantPrtStDic.Add(addKey, wkImportantPrtSt);
                    }
                }
            }

            // DEL 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
            #region �폜�R�[�h
            //// �L�[�쐬
            //DICKEY key = new DICKEY();
            //key.sectionCode = sectionCode.TrimEnd();
            //key.customerCode = customerCode;
            //key.goodsMGroup = goodsMGroup;
            //key.blGoodsCode = blGoodsCode;
            //key.goodsMakerCd = goodsMakerCd;
            //key.goodsNo = goodsNo.Trim();

            //if (_ImportantPrtStDic.ContainsKey(key))
            //{
            //    // �Y���f�[�^�L��
            //    importantPrtSt = _ImportantPrtStDic[key].Clone();
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            //else
            //{
            //    // �Y���f�[�^����
            //    importantPrtSt = null;
            //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            //return status;
            #endregion // �폜�R�[�h
            // DEL 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<

            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------>>>
            // �d�_�i�ڐݒ�L���b�V������f�[�^�擾

            #region �D�揇��1:���Ӑ�{���[�J�[�{�i��

            DICKEY key1 = new DICKEY();
            {
                key1.sectionCode = string.Empty;
                key1.customerCode = customerCode;
                key1.goodsMakerCd = goodsMakerCd;
                key1.goodsNo = goodsNo.Trim();
            }
            if (_ImportantPrtStDic.ContainsKey(key1))
            {
                importantPrtSt = _ImportantPrtStDic[key1].Clone();
                return status;
            }

            #endregion

            #region �D�揇��2:���Ӑ�{���[�J�[�{BL�R�[�h

            DICKEY key2 = new DICKEY();
            {
                key2.sectionCode = string.Empty;
                key2.customerCode = customerCode;
                key2.goodsMakerCd = goodsMakerCd;
                key2.blGoodsCode = blGoodsCode;
                key2.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key2))
            {
                importantPrtSt = _ImportantPrtStDic[key2].Clone();
                return status;
            }

            #endregion

            #region �D�揇��3:���Ӑ�{���[�J�[�{�����ރR�[�h

            DICKEY key3 = new DICKEY();
            {
                key3.sectionCode = string.Empty;
                key3.customerCode = customerCode;
                key3.goodsMakerCd = goodsMakerCd;
                key3.goodsMGroup = goodsMGroup;
                key3.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key3))
            {
                importantPrtSt = _ImportantPrtStDic[key3].Clone();
                return status;
            }

            #endregion

            #region �D�揇��4:���Ӑ�{���[�J�[

            DICKEY key4 = new DICKEY();
            {
                key4.sectionCode = string.Empty;
                key4.customerCode = customerCode;
                key4.goodsMakerCd = goodsMakerCd;
                key4.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key4))
            {
                importantPrtSt = _ImportantPrtStDic[key4].Clone();
                return status;
            }

            #endregion

            #region �D�揇��5:���_�{���[�J�[�{�i��

            DICKEY key5 = new DICKEY();
            {
                key5.sectionCode = sectionCode;
                key5.goodsMakerCd = goodsMakerCd;
                key5.goodsNo = goodsNo.Trim();
            }
            if (_ImportantPrtStDic.ContainsKey(key5))
            {
                importantPrtSt = _ImportantPrtStDic[key5].Clone();
                return status;
            }

            #endregion

            #region �D�揇��6:���_�{���[�J�[�{BL�R�[�h

            DICKEY key6 = new DICKEY();
            {
                key6.sectionCode = sectionCode;
                key6.goodsMakerCd = goodsMakerCd;
                key6.blGoodsCode = blGoodsCode;
                key6.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key6))
            {
                importantPrtSt = _ImportantPrtStDic[key6].Clone();
                return status;
            }

            #endregion

            #region �D�揇��7:���_�{���[�J�[�{�����ރR�[�h

            DICKEY key7 = new DICKEY();
            {
                key7.sectionCode = sectionCode;
                key7.goodsMakerCd = goodsMakerCd;
                key7.goodsMGroup = goodsMGroup;
                key7.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key7))
            {
                importantPrtSt = _ImportantPrtStDic[key7].Clone();
                return status;
            }

            #endregion

            #region �D�揇��8:���_�{���[�J�[

            DICKEY key8 = new DICKEY();
            {
                key8.sectionCode = sectionCode;
                key8.goodsMakerCd = goodsMakerCd;
                key8.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key8))
            {
                importantPrtSt = _ImportantPrtStDic[key8].Clone();
                return status;
            }

            #endregion

            // �S�ЂōČ���
            importantPrtSt = null;
            int sectionCodeNo = -1;
            if (int.TryParse(sectionCode.Trim(), out sectionCodeNo))
            {
                if (sectionCodeNo > 0)
                {
                    return GetImportantPrtSt(
                        out importantPrtSt,
                        enterpriseCode,
                        "00",   // �S�Аݒ�
                        customerCode,
                        goodsMakerCd,
                        goodsMGroup,
                        blGoodsCode,
                        goodsNo
                    );
                }
            }
            return status;
            // ADD 2009/08/25 �`�P�b�g[14065]�Ή� ------<<<
        }
        #endregion
        // ADD 2009/06/17 ------<<<
    }
}
