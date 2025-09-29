using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///�������i�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30416 ���� ����</br>
    /// <br>Date       : 2008.06.27</br>
    /// <br>UpdateNote : 2008/10/07 30462 �s�V �m���@�o�O�C��</br>
    /// <br>           : 2008/11/13       �Ɠc �M�u  �o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>           : 2009.02.23 20056 ���n ���  Search���\�b�h�ŃL���b�V���w��\�ȃ��\�b�h���I�[�o�[���[�h</br>
    /// </remarks>
    public class IsolIslandPrcAcs
    {
        // --------------------------------------------------
        #region Private Members

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        /// <summary>�������i�}�X�^�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IIsolIslandPrcDB _iIsolIslandPrcDB = null;

        // �f�[�^�Z�b�g
        private DataSet _bindDataSet = null;
        private DataTable _isolIslandPrcTable = null;

        // �}�X�^�N���X�i�[���X�g
        private Dictionary<Guid, IsolIslandPrcWork> _isolIslandPrcDic = null;  // �������i�}�X�^�i�[�p

        // �}�X�^�擾�p���X�g
        private ArrayList _isolIslandPrcList = null;                  // �������i�}�X�^�擾�p

        #endregion

        // --------------------------------------------------
        #region Public Members
        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        public static readonly string TBL_ISOLISLANDPRC_TITLE       = "ISOLISLANDPRC_TABLE";
        public static readonly string COL_DELETEDATE_TITLE          = "�폜��";
        public static readonly string COL_SECTIONCODE_TITLE         = "���_";
        //--- DEL 2008/10/07 �s��Ή�[6323] ��
        //public static readonly string COL_SECTIONNAME_TITLE         = "���_����"; // ADD 2008/09/24
        public static readonly string COL_SECTIONNAME_TITLE         = "���_��";     // ADD 2008/10/07 �s��Ή�[6323]
        public static readonly string COL_MAKERCODE_TITLE           = "���[�J�[�R�[�h";
        //--- DEL 2008/10/07 �s��Ή�[6323] ��
        //public static readonly string COL_MAKERNAME_TITLE           = "���[�J�[����";
        public static readonly string COL_MAKERNAME_TITLE           = "���[�J�[��";   // ADD 2008/10/07 �s��Ή�[6323]
        public static readonly string COL_UPPERLIMITPRICE_TITLE     = "���i���";
        public static readonly string COL_UPRATE_TITLE              = "���iUP��";
        public static readonly string COL_FRACTIONPROCUNIT_TITLE    = "�[�������P��";
        public static readonly string COL_FRACTIONPROCCD_TITLE      = "�[�������敪";
        public static readonly string COL_GUID_TITLE                = "GUID";

        // �[�������敪
        /* --- DEL 2008/11/13 �\���ʒu�ύX�̈� ---------------->>>>>
        private const string FRACTIONPROCCD_KIND1 = "�l�̌ܓ�";
        private const string FRACTIONPROCCD_KIND2 = "�؂�グ";
        private const string FRACTIONPROCCD_KIND3 = "�؂�̂�";
           --- DEL 2008/11/13 ---------------------------------<<<<< */
        // --- ADD 2008/11/13 --------------------------------->>>>>
        private const string FRACTIONPROCCD_KIND1 = "�؂�̂�";
        private const string FRACTIONPROCCD_KIND2 = "�l�̌ܓ�";
        private const string FRACTIONPROCCD_KIND3 = "�؂�グ";
        // --- ADD 2008/11/13 ---------------------------------<<<<<
        #endregion
        // --------------------------------------------------
        #region Constructor

        /// <summary>
        ///�������i�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public IsolIslandPrcAcs()
        {
            try
            {
                // ��ƃR�[�h�擾
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // �����[�g�I�u�W�F�N�g�擾
                this._iIsolIslandPrcDB = (IIsolIslandPrcDB)MediationIsolIslandPrcDB.GetIsolIslandPrcDB();

                // �}�X�^�N���X�i�[���X�g������
                this._isolIslandPrcDic = new Dictionary<Guid, IsolIslandPrcWork>();

                // �}�X�^�擾�p���X�g������
                this._isolIslandPrcList = new ArrayList();

                // �f�[�^�Z�b�g������
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iIsolIslandPrcDB = null;
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // �������i�}�X�^�e�[�u��
            this._isolIslandPrcTable = new DataTable(TBL_ISOLISLANDPRC_TITLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            this._isolIslandPrcTable.Columns.Add(COL_DELETEDATE_TITLE, typeof(string));         // �폜��
            this._isolIslandPrcTable.Columns.Add(COL_SECTIONCODE_TITLE, typeof(string));        // ���_�R�[�h
            // --- ADD 2008/09/25 -------------------------------->>>>>
            this._isolIslandPrcTable.Columns.Add(COL_SECTIONNAME_TITLE, typeof(string));        // ���_����
            // --- ADD 2008/09/25 --------------------------------<<<<<
            this._isolIslandPrcTable.Columns.Add(COL_MAKERCODE_TITLE, typeof(Int32));           // ���[�J�[�R�[�h
            this._isolIslandPrcTable.Columns.Add(COL_MAKERNAME_TITLE, typeof(string));          // ���[�J�[����
            this._isolIslandPrcTable.Columns.Add(COL_UPPERLIMITPRICE_TITLE, typeof(Double));    // ���i���
            this._isolIslandPrcTable.Columns.Add(COL_UPRATE_TITLE, typeof(Double));             // ���iUP��
            this._isolIslandPrcTable.Columns.Add(COL_FRACTIONPROCUNIT_TITLE, typeof(Double));   // �[�������P��
            this._isolIslandPrcTable.Columns.Add(COL_FRACTIONPROCCD_TITLE, typeof(string));     // �[�������敪
            this._isolIslandPrcTable.Columns.Add(COL_GUID_TITLE, typeof(Guid));                 // GUID
            // PrimaryKey�ݒ�
            this._isolIslandPrcTable.PrimaryKey = new DataColumn[] { this._isolIslandPrcTable.Columns[COL_SECTIONCODE_TITLE],        // ���_�R�[�h
                                                                     this._isolIslandPrcTable.Columns[COL_MAKERCODE_TITLE],          // ���[�J�[�R�[�h
                                                                     this._isolIslandPrcTable.Columns[COL_UPPERLIMITPRICE_TITLE] };  // ���i���

            this._bindDataSet.Tables.Add(this._isolIslandPrcTable);
        }

        #endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>�f�[�^�Z�b�g�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g���擾���܂��B</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }

        #endregion

        // --------------------------------------------------
        #region GetOnlineMode

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            // �I�����C�����[�h���擾
            if (this._iIsolIslandPrcDB == null)
            {
                // �I�t���C��
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                // �I�����C��
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        // --------------------------------------------------
        #region Read Methods

        /// <summary>
        ///�ǂݍ��ݏ���
        /// </summary>
        /// <param name="IsolIslandPrc">�������i�}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Read(out IsolIslandPrc isolIslandPrc, string enterpriseCode, Int32 makerCode)
        {
            return this.ReadProc(out isolIslandPrc, enterpriseCode, makerCode);
        }

        /// <summary>
        ///�������i�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="IsolIslandPrc">�������i�}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int ReadProc(out IsolIslandPrc isolIslandPrc, string enterpriseCode, Int32 makerCode)
        {
            int status1 = 0;

            isolIslandPrc = null;

            try
            {
                // �L�[�����Z�b�g
                IsolIslandPrcWork isolIslandPrcWork = new IsolIslandPrcWork();
                isolIslandPrcWork.EnterpriseCode = enterpriseCode;   // ��ƃR�[�h
                isolIslandPrcWork.MakerCode = makerCode;             // ���[�J�[�R�[�h

                object refobj = null;

                //�������i�}�X�^�ǂݍ���
                status1 = this._iIsolIslandPrcDB.Read(ref refobj, 0);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    IsolIslandPrcWork isolIslandPrcWorkRef = (IsolIslandPrcWork)refobj;

                    // ���ʂ������o�R�s�[
                    isolIslandPrc = this.CopyToIsolIslandPrcFromIsolIslandPrcWork(isolIslandPrcWorkRef);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                isolIslandPrc = null;
                this._iIsolIslandPrcDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status1 = -1;
            }
            return status1;
        }

        #endregion

        // --------------------------------------------------
        #region Write Methods

        /// <summary>
        ///�������ݏ���
        /// </summary>
        /// <param name="isolIslandPrc">�������i�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Write(IsolIslandPrc isolIslandPrc)
        {
            // �������i�}�X�^�X�V
            return this.WriteProc(isolIslandPrc);
        }

        /// <summary>
        ///�������i�}�X�^�������ݏ���
        /// </summary>
        /// <param name="isolIslandPrc">�������i�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int WriteProc(IsolIslandPrc isolIslandPrc)
        {
            int status = 0;

            try
            {

                IsolIslandPrcWork isolIslandPrcWork = new IsolIslandPrcWork();

                // �ҏW�O���擾
                if (this._isolIslandPrcDic.ContainsKey(isolIslandPrc.FileHeaderGuid) == true)
                {
                    isolIslandPrcWork = (this._isolIslandPrcDic[isolIslandPrc.FileHeaderGuid] as IsolIslandPrcWork);
                }

                // �ҏW���擾
                CopyToIsolIslandPrcWorkFromDispIsolIslandPrc(ref isolIslandPrcWork, isolIslandPrc);

                ArrayList retParaArray = new ArrayList();
                retParaArray.Add(isolIslandPrcWork);

                object retObj = (object)retParaArray;

                // �������i�}�X�^��������
                status = this._iIsolIslandPrcDB.Write(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�Z�b�g�ɒǉ�
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    isolIslandPrcWork = (IsolIslandPrcWork)retArray[0];
                    this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iIsolIslandPrcDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region LogicalDelete Methods

        /// <summary>
        ///�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�������i�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // �������i�}�X�^�_���폜
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///�������i�}�X�^�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�������i�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                IsolIslandPrcWork isolIslandPrcWork = (this._isolIslandPrcDic[fileHeaderGuid] as IsolIslandPrcWork);

                ArrayList retArray = new ArrayList();
                retArray.Add(isolIslandPrcWork);

                object retObj = (object)retArray;

                // �������i�}�X�^�_���폜
                status = this._iIsolIslandPrcDB.LogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList refArray = (ArrayList)retObj;
                    isolIslandPrcWork = (IsolIslandPrcWork)refArray[0];
                    // �f�[�^�Z�b�g�ɒǉ�
                    this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iIsolIslandPrcDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Revival Methods

        /// <summary>
        ///�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">�������i�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // �������i�}�X�^����
            return this.RevivalProc(fileHeaderGuid);
        }

        /// <summary>
        ///�������i�}�X�^�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">�������i�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                IsolIslandPrcWork isolIslandPrcWork = (this._isolIslandPrcDic[fileHeaderGuid] as IsolIslandPrcWork);

                ArrayList retArray = new ArrayList();
                retArray.Add(isolIslandPrcWork);

                object retObj = (object)retArray;

                // �������i�}�X�^�_���폜����
                status = this._iIsolIslandPrcDB.RevivalLogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList refArray = (ArrayList)retObj;
                    isolIslandPrcWork = (IsolIslandPrcWork)refArray[0];
                    // �f�[�^�Z�b�g�ɒǉ�
                    this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                }
            }

            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iIsolIslandPrcDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Delete Methods

        /// <summary>
        ///�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�������i�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // �������i�}�X�^�����폜
            return this.DeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///�������i�}�X�^�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�������i�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                IsolIslandPrcWork isolIslandPrcWork = (this._isolIslandPrcDic[fileHeaderGuid] as IsolIslandPrcWork);
             
                ArrayList retArray = new ArrayList();
                retArray.Add(isolIslandPrcWork);

                object retObj = (object)retArray;

                // �������i�}�X�^�����폜
                status = this._iIsolIslandPrcDB.Delete(retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._isolIslandPrcDic.Remove(isolIslandPrcWork.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    DataRow dr = this._isolIslandPrcTable.Rows.Find(new object[] { isolIslandPrcWork.SectionCode,
                                                                                   isolIslandPrcWork.MakerCode,
                                                                                   isolIslandPrcWork.UpperLimitPrice } );

                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iIsolIslandPrcDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Search Methods

        // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ��������(�_���폜����)�i�I�[�o�[���[�h)
        ///// </summary>
        ///// <param name="isolIslandPrcList">�������i���X�g(ArrayList)</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        ///// <br>Programmer : 30416 ���� ����</br>
        ///// <br>Date       : 2008.06.27</br>
        ///// </remarks>
        //public int Search(out List<IsolIslandPrc> isolIslandPrcList, string enterpriseCode)
        //{
        //    int totalCount;
        //    isolIslandPrcList = new List<IsolIslandPrc>();
        //    int status = this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        foreach (IsolIslandPrcWork isolIslandPrcWork in (ArrayList)this._isolIslandPrcList)
        //        {
        //            isolIslandPrcList.Add(this.CopyToIsolIslandPrcFromIsolIslandPrcWork(isolIslandPrcWork));
        //        }
        //    }

        //    return status;
        //}

        /// <summary>
        /// ��������(�_���폜����)�i�I�[�o�[���[�h)
        /// </summary>
        /// <param name="isolIslandPrcList">�������i���X�g(ArrayList)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Search(out List<IsolIslandPrc> isolIslandPrcList, string enterpriseCode)
        {
            return this.Search(out isolIslandPrcList, enterpriseCode, true);
        }

        /// <summary>
        /// ��������(�_���폜����)�i�I�[�o�[���[�h)
        /// </summary>
        /// <param name="isolIslandPrcList"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int Search(out List<IsolIslandPrc> isolIslandPrcList, string enterpriseCode, bool isCache)
        {
            int totalCount;
            isolIslandPrcList = new List<IsolIslandPrc>();
            int status = this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0, isCache);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (IsolIslandPrcWork isolIslandPrcWork in (ArrayList)this._isolIslandPrcList)
                {
                    isolIslandPrcList.Add(this.CopyToIsolIslandPrcFromIsolIslandPrcWork(isolIslandPrcWork));
                }
            }

            return status;
        }
        // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///��������(�_���폜����)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Search(out int totalCount, string enterpriseCode)
        {
            // �������i�}�X�^����
            // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0, true);
            // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        ///��������(�_���폜�܂�)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode)
        {
            // �������i�}�X�^����
            // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01, true);
            // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        /////��������
        ///// </summary>
        ///// <param name="totalCount">�擾����</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        ///// <br>Programmer : 30416 ���� ����</br>
        ///// <br>Date       : 2008.06.27</br>
        ///// </remarks>
        //private int SearchProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        ///��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="isCache">�L���b�V���敪</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, bool isCache)
        // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            int status1 = 0;
            int status2 = 0;

            // �������i�}�X�^����
            status1 = this.SearchIsolIslandPrcProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) && // ADD 2008/09/25
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �L���b�V������
            //status2 = this.Cache(this._isolIslandPrcList);
            //if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status2;
            //}
            if (isCache)
            {
                // �L���b�V������
                status2 = this.Cache(this._isolIslandPrcList);
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status2;
                }
            }
            // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // �X�e�[�^�X���f
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status2 == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        ///�������i�}�X�^��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int SearchIsolIslandPrcProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._isolIslandPrcList.Clear();

                // �L���b�V���p�e�[�u�����N���A
                this._isolIslandPrcDic.Clear();

                // �L�[�����Z�b�g
                IsolIslandPrcWork paramIsolIslandPrcWork = new IsolIslandPrcWork();
                paramIsolIslandPrcWork.EnterpriseCode = enterpriseCode;    // ��ƃR�[�h

                ArrayList retArray = new ArrayList();
                object retobj = (object)retArray;

                // �������i�}�X�^����
                status = this._iIsolIslandPrcDB.Search(ref retobj, paramIsolIslandPrcWork, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._isolIslandPrcList = retobj as ArrayList;

                    // �Y�������i�[
                    totalCount = this._isolIslandPrcList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iIsolIslandPrcDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }
        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// �}�X�^�L���b�V������
        /// </summary>
        /// <param name="isolIslandPrcList">�}�X�^�擾���ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Cache(ArrayList isolIslandPrcList)
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._isolIslandPrcTable.BeginLoadData();

                    // �e�[�u�����N���A
                    this._isolIslandPrcTable.Clear();

                    // �`�[�Ǘ��f�[�^��DataSet�Ɋi�[
                    foreach (IsolIslandPrcWork isolIslandPrcWork in isolIslandPrcList)
                    {
                        // ���o�^�̎�
                        if (this._isolIslandPrcDic.ContainsKey(isolIslandPrcWork.FileHeaderGuid) == false)
                        {
                            // �f�[�^�Z�b�g�ɒǉ�
                            this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                        }
                    }
                }
                finally
                {
                    // �X�V�����I��
                    this._isolIslandPrcTable.EndLoadData();

                    // �\�[�g
                    this._isolIslandPrcTable.DefaultView.Sort = COL_SECTIONCODE_TITLE + " ASC";       // ���_�R�[�h
                    this._isolIslandPrcTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�R�s�[���� (��ʕύX�������i�}�X�^�N���X�˗������i�}�X�^���[�N�N���X)
        /// </summary>
        /// <param name="isolIslandPrcWork">�������i�}�X�^���[�N�N���X</param>
        /// <param name="IsolIslandPrc">�������i�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX�������i�}�X�^�N���X����
        ///                  �������i�}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void CopyToIsolIslandPrcWorkFromDispIsolIslandPrc(ref IsolIslandPrcWork isolIslandPrcWork, IsolIslandPrc isolIslandPrc)
        {
            isolIslandPrcWork.EnterpriseCode = isolIslandPrc.EnterpriseCode;          // ��ƃR�[�h
            isolIslandPrcWork.SectionCode = isolIslandPrc.SectionCode;                // ���_�R�[�h
            isolIslandPrcWork.SectionGuideNm = this.GetSectionName(isolIslandPrc.SectionCode); // ���_����  // ADD 2008/09/26
            isolIslandPrcWork.MakerCode = isolIslandPrc.MakerCode;                    // ���[�J�[�R�[�h
 
            isolIslandPrcWork.UpperLimitPrice = isolIslandPrc.UpperLimitPrice;        // ���i���
            isolIslandPrcWork.UpRate = isolIslandPrc.UpRate;                          // ���iUP��
            isolIslandPrcWork.FractionProcUnit = isolIslandPrc.FractionProcUnit;      // �[�������P��
            isolIslandPrcWork.FractionProcCd = isolIslandPrc.FractionProcCd;          // �[�������敪
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (�������i�}�X�^���[�N�N���X�˗������i�}�X�^�N���X)
        /// </summary>
        /// <param name="isolIslandPrcWork">�������i�}�X�^���[�N�N���X</param>
        /// <returns>�������i�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^���[�N�N���X����
        ///                  �������i�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private IsolIslandPrc CopyToIsolIslandPrcFromIsolIslandPrcWork(IsolIslandPrcWork isolIslandPrcWork)
        {
            IsolIslandPrc isolIslandPrc = new IsolIslandPrc();

            isolIslandPrc.CreateDateTime = isolIslandPrcWork.CreateDateTime;            // �쐬����
            isolIslandPrc.UpdateDateTime = isolIslandPrcWork.UpdateDateTime;            // �X�V����
            isolIslandPrc.EnterpriseCode = isolIslandPrcWork.EnterpriseCode;            // ��ƃR�[�h
            isolIslandPrc.FileHeaderGuid = isolIslandPrcWork.FileHeaderGuid;            // GUID
            isolIslandPrc.UpdEmployeeCode = isolIslandPrcWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            isolIslandPrc.UpdAssemblyId1 = isolIslandPrcWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            isolIslandPrc.UpdAssemblyId2 = isolIslandPrcWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            isolIslandPrc.LogicalDeleteCode = isolIslandPrcWork.LogicalDeleteCode;      // �_���폜�敪
            isolIslandPrc.SectionCode = isolIslandPrcWork.SectionCode;                  // ���_�R�[�h
            isolIslandPrc.MakerCode = isolIslandPrcWork.MakerCode;                      // ���[�J�[�R�[�h

            isolIslandPrc.UpperLimitPrice = isolIslandPrcWork.UpperLimitPrice;          // ���i���
            isolIslandPrc.UpRate = isolIslandPrcWork.UpRate;                            // ���iUP��
            isolIslandPrc.FractionProcUnit = isolIslandPrcWork.FractionProcUnit;        // �[�������P��
            isolIslandPrc.FractionProcCd = isolIslandPrcWork.FractionProcCd;            // �[�������敪

            // �e�[�u���X�V
            _isolIslandPrcDic[isolIslandPrcWork.FileHeaderGuid] = isolIslandPrcWork;

            return isolIslandPrc;
        }

        /// <summary>
        /// �������i�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����
        /// </summary>
        /// <param name="isolIslandPrcWork">�������i�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void IsolIslandPrcWorkToDataSet(IsolIslandPrcWork isolIslandPrcWork)
        {
            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            DataRow dr = this._isolIslandPrcTable.Rows.Find(new object[] { isolIslandPrcWork.SectionCode, isolIslandPrcWork.MakerCode, isolIslandPrcWork.UpperLimitPrice });
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._isolIslandPrcTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // �폜��
            if (isolIslandPrcWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", isolIslandPrcWork.UpdateDateTime);
            }

            // ���_�R�[�h
            dr[COL_SECTIONCODE_TITLE] = isolIslandPrcWork.SectionCode;
            // --- ADD 2008/09/24 -------------------------------->>>>>
            // ���_����
            dr[COL_SECTIONNAME_TITLE] = isolIslandPrcWork.SectionGuideNm;
            // --- ADD 2008/09/24 --------------------------------<<<<<
            // ���[�J�[�R�[�h
            dr[COL_MAKERCODE_TITLE] = isolIslandPrcWork.MakerCode;
            // ���[�J�[����
            dr[COL_MAKERNAME_TITLE] = GetMakerName(isolIslandPrcWork.MakerCode);

            // ���i���
            dr[COL_UPPERLIMITPRICE_TITLE] = isolIslandPrcWork.UpperLimitPrice;
            // ���iUP��
            dr[COL_UPRATE_TITLE] = isolIslandPrcWork.UpRate;
            // �[�������P��
            dr[COL_FRACTIONPROCUNIT_TITLE] = isolIslandPrcWork.FractionProcUnit;

            // �[�������敪
            /* --- DEL 2008/11/13 �l�ύX�̈� ----------------------->>>>>
            if (isolIslandPrcWork.FractionProcCd == 0)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND1;
            }
            if (isolIslandPrcWork.FractionProcCd == 1)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND2;
            }
            if (isolIslandPrcWork.FractionProcCd == 2)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND3;
            }
               --- DEL 2008/11/13 ----------------------------------<<<<< */
            if (isolIslandPrcWork.FractionProcCd == 1)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND1;        // �؂�̂�
            }
            if (isolIslandPrcWork.FractionProcCd == 2)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND2;        // �l�̌ܓ�
            }
            if (isolIslandPrcWork.FractionProcCd == 3)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND3;        // �؂�グ
            }

            // GUID
            dr[COL_GUID_TITLE] = isolIslandPrcWork.FileHeaderGuid;

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._isolIslandPrcTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._isolIslandPrcDic.ContainsKey(isolIslandPrcWork.FileHeaderGuid) == true)
            {
                this._isolIslandPrcDic.Remove(isolIslandPrcWork.FileHeaderGuid);
            }
            this._isolIslandPrcDic.Add(isolIslandPrcWork.FileHeaderGuid, isolIslandPrcWork);
        }
        #endregion

        // --------------------------------------------------
        #region ��r�p�N���X

        /// <summary>
        ///�������i�}�X�^��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public class IsolIslandPrcCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>
            /// ��r�p���\�b�h
            /// </summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : �������i�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 30416 ���� ����</br>
            /// <br>Date       : 2008.06.27</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                IsolIslandPrc obj1 = x as IsolIslandPrc;
                IsolIslandPrc obj2 = y as IsolIslandPrc;

                // �������i�R�[�h�Ŕ�r
                return obj1.SectionCode.CompareTo(obj2.SectionCode);
            }

            #endregion
        }

        #endregion

        #region �e��ϊ�
        /// <summary>
        /// NULL�����ϊ�����
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <returns>string�^�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : NULL�������܂܂�Ă���ꍇ�_�u���N�H�[�g�֕ϊ�����</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public static string NullChgStr(object obj)
        {
            string ret;
            try
            {
                if (obj == null)
                {
                    ret = "";
                }
                else
                {
                    ret = obj.ToString();
                }
            }
            catch
            {
                ret = "";
            }
            return ret;
        }

        /// <summary>
        /// NULL�����ϊ�����
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <returns>int�^�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : NULL�������܂܂�Ă���ꍇ�u0�v�֕ϊ�����</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public static int NullChgInt(object obj)
        {
            int ret;
            try
            {
                if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
                {
                    ret = 0;
                }
                else
                {
                    ret = Convert.ToInt32(obj);
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;

            MakerUMnt makerUMnt = new MakerUMnt();
            MakerAcs makerAcs = new MakerAcs();

            try
            {
                status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);

                if (status == 0)
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }
    }
}
