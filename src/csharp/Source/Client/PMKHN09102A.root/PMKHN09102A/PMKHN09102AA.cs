using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30416 ���� ����</br>
    /// <br>Date       : 2008.06.26</br>
    /// <br>Update Note: 2008.09.22 30452 ��� �r��</br>
    /// <br>             PM.NS�Ή�</br>
    /// <br>             �E���Ӑ�`�[�ԍ��w�b�_�A���Ӑ�`�[�ԍ��t�b�^���폜</br>
    /// <br>Update Note: 2008.12.10 30365 �{�� �⎟�Y</br>
    /// <br>             ���Ӑ�}�X�^�̓��Ӑ�`�[�ԍ��敪��0�̓��Ӑ悪</br>
    /// <br>             �����O���b�h�ɕ\������Ȃ��悤�ɏC���B</br>
    /// <br>             DB�̓��Ӑ��ǂ݂ɍs���񐔂𑽏����炵�A���X�̍������B</br>
    /// <br>             ���x�ɂ��Ă͗v���P�B</br>
    /// <br>Update Note: 2009.02.12 30452 ��� �r��</br>
    /// <br>             ���x�A�b�v�Ή�</br>
    /// <br>Update Note: 2009.02.13 30452 ��� �r��</br>
    /// <br>             ���x�A�b�v�Ή�</br>
    /// </remarks>
    public class CustSlipNoSetAcs
    {
        //----------------------------------------
        // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�萔��`
        //----------------------------------------
        public const string CREATEDATETIME = "CreateDateTime";
        public const string UPDATEDATETIME = "UpdateDateTime";
        public const string ENTERPRISECODE = "EnterpriseCode";
        public const string FILEHEADERGUID = "FileHeaderGuid";
        public const string UPDEMPLOYEECODE = "UpdEmployeeCode";
        public const string UPDASSEMBLYID1 = "UpdAssemblyId1";
        public const string UPDASSEMBLYID2 = "UpdAssemblyId2";
        public const string LOGICALDELETECODE = "LogicalDeleteCode";

        public const string CUSTOMERCODE_TITLE = "���Ӑ�R�[�h";
        public const string CUSTOMERNAME_TITLE = "���Ӑ旪��";
        public const string ADDUPYEARMONTH_TITLE = "�v��N��";
        public const string PRESENTCUSTSLIPNO_TITLE = "���ݓ��Ӑ�`�[�ԍ�";
        public const string STARTCUSTSLIPNO_TITLE = "�J�n���Ӑ�`�[�ԍ�";
        public const string ENDCUSTSLIPNO_TITLE = "�I�����Ӑ�`�[�ԍ�";
        //public const string CUSTSLIPNOHEADER_TITLE = "���Ӑ�`�[�ԍ��w�b�_"; //DEL 2008/09/22
        //public const string CUSTSLIPNOFOOTER_TITLE = "���Ӑ�`�[�ԍ��t�b�^"; //DEL 2008/09/22
        public const string DELETE_DATE_TITLE = "�폜��";

        // �e�[�u����
        public const string MAIN_TABLE = "MainTable";
        public const string SECOND_TABLE = "SecondTable";

        // private member��`
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private ICustSlipNoSetDB _iCustSlipNoSetDB = null;    // �ݒ胊���[�g

        private DataSet _dataTableList = null;

        private string _enterpriseCode = "";

        // �����񌋍��p
        private StringBuilder _stringBuilder = null;

        private CustomerInfoAcs _customerInfoAcs; // ADD 2009/02/12

        #region Construcstor
        /// <summary>
        /// ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public CustSlipNoSetAcs()
        {
            try
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // �����[�g�I�u�W�F�N�g�擾
                this._iCustSlipNoSetDB = (ICustSlipNoSetDB)MediationCustSlipNoSetDB.GetCustSlipNoSetDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCustSlipNoSetDB = null;
            }

            // �f�[�^�Z�b�g����\�z����
            this._dataTableList = new DataSet();
            DataSetColumnConstruction(ref this._dataTableList);

            // �����񌋍��p
            this._stringBuilder = new StringBuilder();

            this._customerInfoAcs = new CustomerInfoAcs(); // ADD 2009/02/12
        }
        #endregion

        // �񋓌^
        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCustSlipNoSetDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        #region Property
        /// <summary>��P�e�[�u���i���Ӑ�R�[�h�e�[�u���j</summary>
        public DataTable DtMainTable
        {
            get { return this._dataTableList.Tables[MAIN_TABLE]; }
        }
        /// <summary>��Q�e�[�u���i�v��N���e�[�u���j</summary>
        public DataTable DtDetailsTable
        {
            get { return this._dataTableList.Tables[SECOND_TABLE]; }
        }
        #endregion

        #region public member

        #region GetTable �e�[�u���擾
        /// <summary>
        /// �e�[�u���擾
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>		
        /// <returns>DataTable</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�e�[�u���̃I�u�W�F�N�g��Ԃ��܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public DataTable GetTable(string tableName)
        {
            if (this._dataTableList.Tables.Contains(tableName))
            {
                return this._dataTableList.Tables[tableName];
            }
            return null;
        }
        #endregion

        #region GetSlipOutputSet ���Ӑ�ݒ�(�`�[�ݒ�)�f�[�^�擾
        /// <summary>
        /// ���Ӑ�ݒ�(�`�[�ݒ�)�f�[�^�擾
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>		
        /// <param name="addYearMonth">�v��N��</param>		
        /// <param name="custSlipNoSet">���Ӑ�ݒ�(�`�[�ݒ�)�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>		
        /// <returns>�t�@���N�V�����̃X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽKEY�������Ӑ�ݒ�(�`�[�ݒ�)�N���X��Ԃ��܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int GetSlipOutputSet(int customerCode,
                                    int addYearMonth,
                                    out CustSlipNoSet custSlipNoSet,
                                    out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            custSlipNoSet = new CustSlipNoSet();
            message = "";

            try
            {
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {  customerCode,
																								addYearMonth });
                if (dr == null)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                }

                // �쐬����
                custSlipNoSet.CreateDateTime = (DateTime)dr[CREATEDATETIME];
                // �X�V����
                custSlipNoSet.UpdateDateTime = (DateTime)dr[UPDATEDATETIME];
                // ��ƃR�[�h
                custSlipNoSet.EnterpriseCode = dr[ENTERPRISECODE].ToString();
                // GUID
                custSlipNoSet.FileHeaderGuid = (Guid)dr[FILEHEADERGUID];
                // �X�V�]�ƈ��R�[�h
                custSlipNoSet.UpdEmployeeCode = dr[UPDEMPLOYEECODE].ToString();
                // �X�V�A�Z���u��ID1
                custSlipNoSet.UpdAssemblyId1 = dr[UPDASSEMBLYID1].ToString();
                // �X�V�A�Z���u��ID2
                custSlipNoSet.UpdAssemblyId2 = dr[UPDASSEMBLYID2].ToString();
                // �_���폜�敪
                custSlipNoSet.LogicalDeleteCode = Convert.ToInt32(dr[LOGICALDELETECODE]);

                // ���Ӑ�R�[�h
                custSlipNoSet.CustomerCode = (Int32)dr[CUSTOMERCODE_TITLE];
                // �v��N��
                custSlipNoSet.AddUpYearMonth = (Int32)dr[ADDUPYEARMONTH_TITLE];
                // ���ݓ��Ӑ�`�[�ԍ�
                custSlipNoSet.PresentCustSlipNo = (Int64)dr[PRESENTCUSTSLIPNO_TITLE];
                // �J�n���Ӑ�`�[�ԍ�
                custSlipNoSet.StartCustSlipNo = (Int64)dr[STARTCUSTSLIPNO_TITLE];
                // �I�����Ӑ�`�[�ԍ�
                custSlipNoSet.EndCustSlipNo = (Int64)dr[ENDCUSTSLIPNO_TITLE];
                // --- DEL 2008/09/22 -------------------------------->>>>>
                //// ���Ӑ�`�[�ԍ��w�b�_
                //custSlipNoSet.CustSlipNoHeader = dr[CUSTSLIPNOHEADER_TITLE].ToString();
                //// ���Ӑ�`�[�ԍ��t�b�^
                //custSlipNoSet.CustSlipNoFooter = dr[CUSTSLIPNOFOOTER_TITLE].ToString();
                // --- DEL 2008/09/22 --------------------------------<<<<<

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                custSlipNoSet = null;
            }

            return status;
        }
        #endregion

        #region Search ��������
        /// <summary>
        /// ���������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retArrayList">�Ǎ����ʃR���N�V����(ArrayList)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="message">���b�Z�[�W</param>		
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Search(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
        {
            DataSet dmyDataSet = null;	// �f�[�^�Z�b�g�͎g�p���Ȃ�

            // ����
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, 0, out message);

            return status;
        }

        /// <summary>
        /// ���������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����(DataSet)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="message">���b�Z�[�W</param>		
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Search(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
        {
            ArrayList dmyArrayList = null;	// ArrayList�͎g�p���Ȃ�

            // ����
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, 0, out message);

            return status;
        }
        #endregion

        #region SearchAll ��������
        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retArrayList">�Ǎ����ʃR���N�V����(ArrayList)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="message">���b�Z�[�W</param>		
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
        {
            DataSet dmyDataSet = null;	// �f�[�^�Z�b�g�͎g�p���Ȃ�

            // ����
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);

            return status;
        }

        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����(DataSet)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="message">���b�Z�[�W</param>		
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchAll(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
        {
            ArrayList dmyArrayList = null;	// ArrayList�͎g�p���Ȃ�

            // ����
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);

            return status;
        }
        #endregion

        #region Write �������ݏ���
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="custSlipNoSet">�ۑ��f�[�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ݏ������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Write(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList paraSlipOutputSetWorkList = new ArrayList();
                paraSlipOutputSetWorkList.Add(custSlipNoSetWork);
                object paraObj = paraSlipOutputSetWorkList;

                // �������ݏ���
                status = this._iCustSlipNoSetDB.Write(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�o�^�Ɏ��s���܂����B";
                    return status;
                }

                // ���[�N�f�[�^���N���X�f�[�^�ɕϊ�
                custSlipNoSetWork = (CustSlipNoSetWork)((ArrayList)paraObj)[0];
                custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

                // �f�[�^�o�^�ς݃`�F�b�N
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] { custSlipNoSetWork.CustomerCode,
																						       custSlipNoSetWork.AddUpYearMonth });
                if (dr == null)
                {
                    // ���o�^�̏ꍇ�̓��[�N�f�[�^��DataRow�ɕϊ�
                    dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);

                    // ���o�^�̏ꍇ�̓��R�[�h��ǉ�
                    this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
                }
                else
                {
                    // �o�^�ς݂̏ꍇ�͍X�V
                    dr[UPDATEDATETIME] = custSlipNoSetWork.UpdateDateTime;
                    dr[UPDEMPLOYEECODE] = custSlipNoSetWork.UpdEmployeeCode;
                    dr[UPDASSEMBLYID1] = custSlipNoSetWork.UpdAssemblyId1;
                    dr[UPDASSEMBLYID2] = custSlipNoSetWork.UpdAssemblyId2;

                    // ���Ӑ�R�[�h
                    dr[CUSTOMERCODE_TITLE] = custSlipNoSetWork.CustomerCode;
                    // �v��N��
                    dr[ADDUPYEARMONTH_TITLE] = custSlipNoSetWork.AddUpYearMonth;

                    // ���ݓ��Ӑ�`�[�ԍ�
                    dr[PRESENTCUSTSLIPNO_TITLE] = custSlipNoSetWork.PresentCustSlipNo;
                    // �J�n���Ӑ�`�[�ԍ�
                    dr[STARTCUSTSLIPNO_TITLE] = custSlipNoSetWork.StartCustSlipNo;
                    // �I�����Ӑ�`�[�ԍ�
                    dr[ENDCUSTSLIPNO_TITLE] = custSlipNoSetWork.EndCustSlipNo;

                    // --- DEL 2008/09/22 -------------------------------->>>>>
                    //// ���Ӑ�`�[�ԍ��w�b�_
                    //dr[CUSTSLIPNOHEADER_TITLE] = custSlipNoSetWork.CustSlipNoHeader;
                    //// ���Ӑ�`�[�ԍ��t�b�^
                    //dr[CUSTSLIPNOFOOTER_TITLE] = custSlipNoSetWork.CustSlipNoFooter;
                    // --- DEL 2008/09/22 --------------------------------<<<<<
                }

                this._dataTableList.AcceptChanges();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCustSlipNoSetDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region LogicalDelete �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="custSlipNoSet">���Ӑ�ݒ�(�`�[�ݒ�)�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int LogicalDelete(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList slipOutputSetWorkList = new ArrayList();
                slipOutputSetWorkList.Add(custSlipNoSetWork);
                object paraObj = slipOutputSetWorkList;

                // �폜����
                status = this._iCustSlipNoSetDB.LogicalDelete(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                // �N���X�f�[�^�ɔ��f
                custSlipNoSetWork = (CustSlipNoSetWork)((ArrayList)paraObj)[0];
                custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

                // �f�[�^�e�[�u���ɔ��f
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																								custSlipNoSet.AddUpYearMonth });
                if (dr != null)
                {
                    dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);
                }
                this._dataTableList.AcceptChanges();


                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCustSlipNoSetDB = null;
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
        /// <param name="custSlipNoSet">���Ӑ�ݒ�(�`�[�ݒ�)�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Revival(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList paraSlipOutputSetWorkList = new ArrayList();
                paraSlipOutputSetWorkList.Add(custSlipNoSetWork);
                object paraObj = paraSlipOutputSetWorkList;

                // �������ݏ���
                status = this._iCustSlipNoSetDB.RevivalLogicalDelete(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                // �N���X�f�[�^�ɔ��f
                custSlipNoSetWork = (CustSlipNoSetWork)((ArrayList)paraObj)[0];
                custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

                // �f�[�^�e�[�u���ɔ��f
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																								custSlipNoSet.AddUpYearMonth });
                if (dr != null)
                {
                    dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);
                }
                this._dataTableList.AcceptChanges();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCustSlipNoSetDB = null;
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
        /// <param name="custSlipNoSet">���Ӑ�ݒ�(�`�[�ݒ�)�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Delete(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList custSlipNoSetArray = new ArrayList();
                custSlipNoSetArray.Add(custSlipNoSetWork);
                object retobj = (object)custSlipNoSetArray;

                // �������ݏ���
                status = this._iCustSlipNoSetDB.Delete(retobj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                // �f�[�^�o�^�ς݃`�F�b�N
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																								custSlipNoSet.AddUpYearMonth });
                if (dr != null)
                {
                    // �����폜�����f�[�^���폜
                    this._dataTableList.Tables[SECOND_TABLE].Rows.Remove(dr);
                }
                this._dataTableList.AcceptChanges();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iCustSlipNoSetDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #endregion

        #region private member

        #region �f�[�^�Z�b�g����\�z����
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //----------------------------------------------------------------
            // ���Ӑ�R�[�h�e�[�u�����`
            //----------------------------------------------------------------
            DataTable cashRegisterNoTable = new DataTable(MAIN_TABLE);

            // ���Ӑ�R�[�h
            cashRegisterNoTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));
            // ���Ӑ於��
            cashRegisterNoTable.Columns.Add(CUSTOMERNAME_TITLE, typeof(string));

            cashRegisterNoTable.PrimaryKey = new DataColumn[] { cashRegisterNoTable.Columns[CUSTOMERCODE_TITLE] };
            this._dataTableList.Tables.Add(cashRegisterNoTable);

            //----------------------------------------------------------------
            // �v��N���e�[�u�����`
            //----------------------------------------------------------------
            DataTable slipPrtTable = new DataTable(SECOND_TABLE);

            // �쐬����
            slipPrtTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
            // �X�V����
            slipPrtTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
            // ��ƃR�[�h
            slipPrtTable.Columns.Add(ENTERPRISECODE, typeof(string));
            // GUID
            slipPrtTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
            // �X�V�]�ƈ��R�[�h
            slipPrtTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
            // �X�V�A�Z���u��ID1
            slipPrtTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
            // �X�V�A�Z���u��ID2
            slipPrtTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
            // �_���폜�敪
            slipPrtTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));

            // ���Ӑ�R�[�h
            slipPrtTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(Int32));
            // �v��N��
            slipPrtTable.Columns.Add(ADDUPYEARMONTH_TITLE, typeof(Int32));

            // ���ݓ��Ӑ�`�[�ԍ�
            slipPrtTable.Columns.Add(PRESENTCUSTSLIPNO_TITLE, typeof(Int64));
            // �J�n���Ӑ�`�[�ԍ�
            slipPrtTable.Columns.Add(STARTCUSTSLIPNO_TITLE, typeof(Int64));
            // �I�����Ӑ�`�[�ԍ�
            slipPrtTable.Columns.Add(ENDCUSTSLIPNO_TITLE, typeof(Int64));

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// ���Ӑ�`�[�ԍ��w�b�_
            //slipPrtTable.Columns.Add(CUSTSLIPNOHEADER_TITLE, typeof(string));
            //// ���Ӑ�`�[�ԍ��t�b�^
            //slipPrtTable.Columns.Add(CUSTSLIPNOFOOTER_TITLE, typeof(string));
            // --- DEL 2008/09/22 --------------------------------<<<<<
            

            // �폜��
            slipPrtTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));

            slipPrtTable.PrimaryKey = new DataColumn[] { slipPrtTable.Columns[CUSTOMERCODE_TITLE],
											 			 slipPrtTable.Columns[ADDUPYEARMONTH_TITLE] };

            this._dataTableList.Tables.Add(slipPrtTable);

        }
        #endregion

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���Ӑ�ݒ�(�`�[�ݒ�)�N���X�˓��Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X�j
        /// </summary>
        /// <param name="custSlipNoSet">���Ӑ�ݒ�(�`�[�ݒ�)�N���X</param>
        /// <returns>CustSlipNoSetWork</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)�N���X���瓾�Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private CustSlipNoSetWork CopyToSlipOutputSetWorkFromSlipOutputSet(CustSlipNoSet custSlipNoSet)
        {
            CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();

            // �쐬����
            custSlipNoSetWork.CreateDateTime = custSlipNoSet.CreateDateTime;
            // �X�V����
            custSlipNoSetWork.UpdateDateTime = custSlipNoSet.UpdateDateTime;
            // ��ƃR�[�h
            custSlipNoSetWork.EnterpriseCode = custSlipNoSet.EnterpriseCode;
            // GUID
            custSlipNoSetWork.FileHeaderGuid = custSlipNoSet.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            custSlipNoSetWork.UpdEmployeeCode = custSlipNoSet.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            custSlipNoSetWork.UpdAssemblyId1 = custSlipNoSet.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            custSlipNoSetWork.UpdAssemblyId2 = custSlipNoSet.UpdAssemblyId2;
            // �_���폜�敪
            custSlipNoSetWork.LogicalDeleteCode = custSlipNoSet.LogicalDeleteCode;

            // ���Ӑ�R�[�h
            custSlipNoSetWork.CustomerCode = custSlipNoSet.CustomerCode;
            // �v��N��
            custSlipNoSetWork.AddUpYearMonth = custSlipNoSet.AddUpYearMonth;

            // ���ݓ��Ӑ�`�[�ԍ�
            custSlipNoSetWork.PresentCustSlipNo = custSlipNoSet.PresentCustSlipNo;
            // �J�n���Ӑ�`�[�ԍ�
            custSlipNoSetWork.StartCustSlipNo = custSlipNoSet.StartCustSlipNo;
            // �I�����Ӑ�`�[�ԍ�
            custSlipNoSetWork.EndCustSlipNo = custSlipNoSet.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// ���Ӑ�`�[�ԍ��w�b�_
            //custSlipNoSetWork.CustSlipNoHeader = custSlipNoSet.CustSlipNoHeader;
            //// ���Ӑ�`�[�ԍ��t�b�^
            //custSlipNoSetWork.CustSlipNoFooter = custSlipNoSet.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            return custSlipNoSetWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X�˓��Ӑ�ݒ�(�`�[�ݒ�)�N���X�j
        /// </summary>
        /// <param name="custSlipNoSetWork">���Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X</param>
        /// <returns>CustSlipNoSet</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X���瓾�Ӑ�ݒ�(�`�[�ݒ�)�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private CustSlipNoSet CopyToSlipOutputSetFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork)
        {
            CustSlipNoSet custSlipNoSet = new CustSlipNoSet();

            // �쐬����
            custSlipNoSet.CreateDateTime = custSlipNoSetWork.CreateDateTime;
            // �X�V����
            custSlipNoSet.UpdateDateTime = custSlipNoSetWork.UpdateDateTime;
            // ��ƃR�[�h
            custSlipNoSet.EnterpriseCode = custSlipNoSetWork.EnterpriseCode;
            // GUID
            custSlipNoSet.FileHeaderGuid = custSlipNoSetWork.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            custSlipNoSet.UpdEmployeeCode = custSlipNoSetWork.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            custSlipNoSet.UpdAssemblyId1 = custSlipNoSetWork.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            custSlipNoSet.UpdAssemblyId2 = custSlipNoSetWork.UpdAssemblyId2;
            // �_���폜�敪
            custSlipNoSet.LogicalDeleteCode = custSlipNoSetWork.LogicalDeleteCode;

            // ���Ӑ�R�[�h
            custSlipNoSet.CustomerCode = custSlipNoSetWork.CustomerCode;
            // �v��N��
            custSlipNoSet.AddUpYearMonth = custSlipNoSetWork.AddUpYearMonth;

            // ���ݓ��Ӑ�`�[�ԍ�
            custSlipNoSet.PresentCustSlipNo = custSlipNoSetWork.PresentCustSlipNo;
            // �J�n���Ӑ�`�[�ԍ�
            custSlipNoSet.StartCustSlipNo = custSlipNoSetWork.StartCustSlipNo;
            // �I�����Ӑ�`�[�ԍ�
            custSlipNoSet.EndCustSlipNo = custSlipNoSetWork.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// ���Ӑ�`�[�ԍ��w�b�_
            //custSlipNoSet.CustSlipNoHeader = custSlipNoSetWork.CustSlipNoHeader;
            //// ���Ӑ�`�[�ԍ��t�b�^
            //custSlipNoSet.CustSlipNoFooter = custSlipNoSetWork.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            return custSlipNoSet;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���Ӑ�ݒ�(�`�[�ݒ�)�N���X��DataRow�j
        /// </summary>
        /// <param name="custSlipNoSetWork">���Ӑ�ݒ�(�`�[�ݒ�)�N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X���瓾�Ӑ�ݒ�(�`�[�ݒ�)�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private DataRow CopyToDataRowFromSlipOutputSetWork(ref CustSlipNoSetWork custSlipNoSetWork)
        {
            CustSlipNoSet custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

            // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�ւ̓o�^
            DataRow dr;
            dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																					custSlipNoSet.AddUpYearMonth});
            if (dr == null)
            {
                dr = this._dataTableList.Tables[SECOND_TABLE].NewRow();
            }

            // �쐬����
            dr[CREATEDATETIME] = custSlipNoSet.CreateDateTime;
            // �X�V����
            dr[UPDATEDATETIME] = custSlipNoSet.UpdateDateTime;
            // ��ƃR�[�h
            dr[ENTERPRISECODE] = custSlipNoSet.EnterpriseCode;

            if (custSlipNoSet.FileHeaderGuid == Guid.Empty)
            {
                // GUID
                dr[FILEHEADERGUID] = Guid.NewGuid();
            }
            else
            {
                // GUID
                dr[FILEHEADERGUID] = custSlipNoSet.FileHeaderGuid;
            }
            // �X�V�]�ƈ��R�[�h
            dr[UPDEMPLOYEECODE] = custSlipNoSet.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            dr[UPDASSEMBLYID1] = custSlipNoSet.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            dr[UPDASSEMBLYID2] = custSlipNoSet.UpdAssemblyId2;
            // �_���폜�敪
            dr[LOGICALDELETECODE] = custSlipNoSet.LogicalDeleteCode;

            // ���Ӑ�R�[�h
            dr[CUSTOMERCODE_TITLE] = custSlipNoSet.CustomerCode;
            // �v��N��
            dr[ADDUPYEARMONTH_TITLE] = custSlipNoSet.AddUpYearMonth;

            // ���ݓ��Ӑ�`�[�ԍ�
            dr[PRESENTCUSTSLIPNO_TITLE] = custSlipNoSet.PresentCustSlipNo;
            // �J�n���Ӑ�`�[�ԍ�
            dr[STARTCUSTSLIPNO_TITLE] = custSlipNoSet.StartCustSlipNo;
            // �I�����Ӑ�`�[�ԍ�
            dr[ENDCUSTSLIPNO_TITLE] = custSlipNoSet.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// ���Ӑ�`�[�ԍ��w�b�_
            //dr[CUSTSLIPNOHEADER_TITLE] = custSlipNoSet.CustSlipNoHeader;
            //// ���Ӑ�`�[�ԍ��t�b�^
            //dr[CUSTSLIPNOFOOTER_TITLE] = custSlipNoSet.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            // �폜��
            if (custSlipNoSet.LogicalDeleteCode == 0)
            {
                dr[DELETE_DATE_TITLE] = "";
            }
            else
            {
                dr[DELETE_DATE_TITLE] = custSlipNoSet.UpdateDateTimeJpInFormal;
            }

            return dr;
        }

        #endregion

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retArrayList">�Ǎ����ʃR���N�V����(ArrayList)</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����(DataSet)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int SearchProc(out ArrayList retArrayList
                                , out DataSet retList
                                , out int retTotalCnt
                                , out bool nextData
                                , string enterpriseCode
                                , ConstantManagement.LogicalMode logicalMode
                                , out string message)
        {

            int status = 0;
            retList = null;
            retTotalCnt = 0;
            nextData = false;
            message = "";

            retArrayList = new ArrayList();

            // ���Ӑ�}�X�^�̘_���폜��0(����)�A���Ӑ�`�[�ԍ��敪��0�ȊO�̏ꍇ�ۑ��B
            // ���Ӑ�R�[�h�Ɩ���(Name)��ێ�
            Dictionary<int, string> customerList = new Dictionary<int, string>(); // ADD 2009/02/13

            // ADD 2009/02/13 ���Ӑ�}�X�^�Ɠ`�[�ݒ�}�X�^�̓Ǎ��ݏ���ύX
            //==========================================
            // ���Ӑ�}�X�^�ǂݍ���
            //==========================================

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            // ���Ӑ�}�X�^�擾
            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

            if (status == 0)
            {
                if (customerSearchRetArray.Length <= 0)
                {

                }
                else
                {
                    foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                    {
                        // --- DEL 2009/02/12 -------------------------------->>>>>
                        //    // ADD 2008/12/02 �s��Ή�[8568] ---------->>>>>
                        //if (customerSearchRet.LogicalDeleteCode == 0)
                        //    {
                        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu ADD
                        //        //CustomerInfo customerInfo = new CustomerInfo();
                        //        //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                        //        // --- DEL 2009/02/12 -------------------------------->>>>>
                        //        if (customerInfoWorkList.ContainsKey(customerSearchRet.CustomerCode))
                        //        {
                        //            customerInfo = customerInfoWorkList[customerSearchRet.CustomerCode];
                        //        }
                        //        else
                        //        {
                        //            status = _customerInfoAcs.ReadDBData(0, this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                        //            customerInfoWorkList.Add(customerSearchRet.CustomerCode, customerInfo);
                        //        }
                        //        // --- DEL 2009/02/12 --------------------------------<<<<<
                        //        if( (status == 0)&&(customerInfo.CustomerSlipNoDiv != 0) ){
                        //                // �f�[�^�e�[�u���֊i�[
                        //                AddRowFromCustomerSearchRet(customerSearchRet, customerInfo);
                        //        }
                        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD
                        //    }
                        //    // ADD 2008/12/02 �s��Ή�[8568] ----------<<<<<
                        ////}
                        // --- DEL 2009/02/12 --------------------------------<<<<<
                        // --- ADD 2009/02/12 -------------------------------->>>>>
                        if (customerSearchRet.LogicalDeleteCode == 0 && customerSearchRet.CustomerSlipNoDiv != 0)
                        {
                            if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { customerSearchRet.CustomerCode }) == null)
                            {
                                DataRow dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();

                                dr[CUSTOMERCODE_TITLE] = customerSearchRet.CustomerCode;
                                dr[CUSTOMERNAME_TITLE] = customerSearchRet.Name;

                                this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                            }

                            if (!customerList.ContainsKey(customerSearchRet.CustomerCode))
                            {
                                customerList.Add(customerSearchRet.CustomerCode, customerSearchRet.Name);
                            }
                        }
                        // --- ADD 2009/02/12 --------------------------------<<<<<
                    }
                }
            }

            //==========================================
            // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�ǂݍ���
            //==========================================
            // ���o�����p�����[�^
            CustSlipNoSetWork paraWork = new CustSlipNoSetWork();

            paraWork.EnterpriseCode = enterpriseCode;

            // ���l�^�̍��ڂ́u0�v�f�[�^���l�����A�S�����Ώێ��́u-1�v�Ƃ���
            paraWork.AddUpYearMonth = -1;	// �v��N��

            ArrayList custSlipNoSetWorkArray = new ArrayList();

            // �����[�g�߂胊�X�g
            object custSlipNoSetWorkList = (object)custSlipNoSetWorkArray;

            // ���Ӑ���̈ꎞ�ۊ�
            Dictionary<int, object> customerInfoWorkList = new Dictionary<int,object>();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu ADD
            // ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^����
            status = this._iCustSlipNoSetDB.Search(ref custSlipNoSetWorkList, paraWork, 0, logicalMode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //CustomerInfo customerInfo; // ADD 2009/02/12

                // �f�[�^�e�[�u���ɃZ�b�g
                foreach (CustSlipNoSetWork custSlipNoSetWork in (ArrayList)custSlipNoSetWorkList)
                {
                    // --- DEL 2009/02/13 -------------------------------->>>>>
                    //// ADD 2008/12/02 �s��Ή�[8568] ---------->>>>>

                    //    //CustomerInfo customerInfo = new CustomerInfo();
                    //    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    //    int customerCode = custSlipNoSetWork.CustomerCode;
                    //    status = _customerInfoAcs.ReadDBData(0, this._enterpriseCode, customerCode, out customerInfo);
                    //    if (status == 0 )
                    //    {
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu ADD
                    //        // �����ǂݍ��܂Ȃ��Ă������悤�Ɍڋq���������ɕۊǂ��Ă���
                    //        if (!customerInfoWorkList.ContainsKey(customerCode))
                    //        {
                    //            customerInfoWorkList.Add(customerCode, customerInfo);
                    //        }
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD

                    //            // ADD 2008/12/02 �s��Ή�[8568] ----------<<<<<
                    //            // �f�[�^�e�[�u���֊i�[
                    //            //AddRowFromSlipOutputSetWork(custSlipNoSetWork); // 2008/12/10 G.Miyatsu DEL
                    //            AddRowFromSlipOutputSetWork(custSlipNoSetWork, customerInfo); // 2008/12/10 G.Miyatsu ADD
                                
                    //            // ArrayList�֊i�[
                    //            retArrayList.Add(CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork));
                    //            // ADD 2008/12/02 �s��Ή�[8568] ---------->>>>>
                    //    }
                    //    else
                    //    {
                    //        //break; // DEL 2009/02/12
                    //        continue; // ADD 2009/02/12
                    //    }
                    //// ADD 2008/12/02 �s��Ή�[8568] ----------<<<<<
                    // --- DEL 2009/02/13 --------------------------------<<<<<
                    // --- ADD 2009/02/13 -------------------------------->>>>>
                    if (customerList.ContainsKey(custSlipNoSetWork.CustomerCode))
                    {
                        // �f�[�^�e�[�u���֊i�[
                        AddRowFromSlipOutputSetWork(custSlipNoSetWork, customerList);

                        // ArrayList�֊i�[
                        retArrayList.Add(CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork));
                    }
                    // --- ADD 2009/02/13 --------------------------------<<<<<
                }
            }
            
            //==========================================
            // �f�[�^�Z�b�g��Ԃ�
            //==========================================
            retList = this._dataTableList;

            return status;
        }
        #endregion

        /// <summary>
        /// ���Ӑ�}�X�^�@���@�f�[�^�e�[�u���@�ǉ�����
        /// </summary>
        /// <param name="custSlipNoSetWork">���Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X</param>
        //private void AddRowFromCustomerSearchRet(CustomerSearchRet customerSearchRet) // 2008/12/10 G.Miyatsu DEL
        private void AddRowFromCustomerSearchRet(CustomerSearchRet customerSearchRet , object customerInfo) // 2008/12/10 G.Miyatsu ADD
        {
            DataRow dr;
            
            try
            { 
                // ��P�O���b�h�i���Ӑ�R�[�h�j
                if (((CustomerInfo)customerInfo).CustomerSlipNoDiv != 0)
                {
                    if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { customerSearchRet.CustomerCode }) == null)
                    {
                        dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                        dr[CUSTOMERCODE_TITLE] = customerSearchRet.CustomerCode;
                        //dr[CUSTOMERNAME_TITLE] = GetCustomerName(customerSearchRet.CustomerCode); // 2008/12/10 G.Miyatsu DEL
                        dr[CUSTOMERNAME_TITLE] = ((CustomerInfo)customerInfo).Name; // 2008/12/10 G.Miyatsu ADD
                        
                        this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���Ӑ�ݒ�(�`�[�ݒ�)�}�X�^�@���@�f�[�^�e�[�u���@�ǉ�����
        /// </summary>
        /// <param name="custSlipNoSetWork">���Ӑ�ݒ�(�`�[�ݒ�)���[�N�N���X</param>
        /// 
        //private void AddRowFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork) // 2008/12/10 G.Miyatsu DEL
        //private void AddRowFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork, object customerInfo) // 2008/12/10 G.Miyatsu ADD // DEL 2009/02/13
        private void AddRowFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork, Dictionary<int, string> customerList)
        {
            DataRow dr;

            try
            {
                //if (((CustomerInfo)customerInfo).CustomerSlipNoDiv != 0) // DEL 2009/02/13
                //{
                    // ��P�O���b�h�i���Ӑ�R�[�h�j
                    if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { custSlipNoSetWork.CustomerCode }) == null)
                    {
                        dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                        dr[CUSTOMERCODE_TITLE] = custSlipNoSetWork.CustomerCode;
                        //dr[CUSTOMERNAME_TITLE] = GetCustomerName(custSlipNoSetWork.CustomerCode); // 2008/12/10 G.Miyatsu DEL
                        //dr[CUSTOMERNAME_TITLE] = ((CustomerInfo)customerInfo).Name; // 2008/12/10 G.Miyatsu ADD // DEL 2009/02/13
                        dr[CUSTOMERNAME_TITLE] = customerList[custSlipNoSetWork.CustomerCode];  // ADD 2009/02/13

                        this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                    }

                    // ��Q�O���b�h�i�v��N���j
                    if (this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSetWork.CustomerCode,
                                                                                        custSlipNoSetWork.AddUpYearMonth }) == null)
                    {
                        dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);
                        this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
                    }
                //}
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���Ӑ�ݒ�(�`�[�ݒ�)�ǂݍ��ݏ���
        /// </summary>
        /// <param name="custSlipNoSet">���Ӑ�ݒ�(�`�[�ݒ�)�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="addUpYearMonth">�v��N��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ݒ�(�`�[�ݒ�)����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Read(out CustSlipNoSet custSlipNoSet,
                        string enterpriseCode,
                        Int32 customerCode,
                        Int32 addUpYearMonth)
        {
            try
            {
                int status = 0;
                custSlipNoSet = null;
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();

                // �L�[���ڐݒ�
                custSlipNoSetWork.EnterpriseCode = enterpriseCode;
                custSlipNoSetWork.CustomerCode = customerCode;
                custSlipNoSetWork.AddUpYearMonth = addUpYearMonth;

                ArrayList custSlipNoSetArray = new ArrayList();

                custSlipNoSetArray.Add(custSlipNoSetWork);

                object retobj = (object)custSlipNoSetArray;
                   
                // ���Ӑ�ݒ�(�`�[�ݒ�)�ǂݍ��� 
                status = this._iCustSlipNoSetDB.Read(ref retobj, 0);

                if (status == 0)
                {
                    ArrayList retArray = (ArrayList)retobj;
                    custSlipNoSetWork = (CustSlipNoSetWork)retArray[0];

                    // �N���X�������o�R�s�[
                    //slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);
                }

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                custSlipNoSet = null;
                //�I�t���C������null���Z�b�g
                this._iCustSlipNoSetDB = null;
                return -1;
            }
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
        /// <br>Date       : 2008.06.26</br>
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
        /// <br>Date       : 2008.06.26</br>
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

        #region [2008/12/10 G.Miyatsu DEL]
        ///// <summary>
        ///// ���Ӑ於�̎擾����
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <returns>���Ӑ於��</returns>
        ///// <remarks>
        ///// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        ///// <br>Programmer : 30416 ���� ����</br>
        ///// <br>Date       : 2008.06.24</br>
        ///// </remarks>
        //private string GetCustomerName(int customerCode)
        //{
        //    string customerName = "";

        //    int status;

        //    CustomerInfo customerInfo = new CustomerInfo();
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();


        //    try
        //    {
        //        status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

        //        if (status == 0)
        //        {
        //            customerName = customerInfo.CustomerSnm.Trim();
        //        }
        //    }
        //    catch
        //    {
        //        customerName = "";
        //    }

        //    return customerName;
        //}
        #endregion
    }
}
