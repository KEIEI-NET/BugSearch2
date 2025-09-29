using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Data.SqlTypes;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��������X�V�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����IOWrite�ɂē����f�[�^�𐧌䂵�܂��B</br>
    /// <br>Programmer : 19026�@���R�@����</br>
    /// <br>Date       : 2007.03.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: 2013/01/18 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33797 �����m�F�\�̓E�v�����e���C��</br>
    /// </remarks>
    [Serializable]
    public class IOWriteMAHNBDepositDB : RemoteWithAppLockDB, IFunctionCallTargetWrite, IFunctionCallTargetRedBlackWrite
    {
        /// <summary>
        /// IOWrite�����X�V�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɖ���</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.03.17</br>
        /// </remarks>
        public IOWriteMAHNBDepositDB()
        {
        }

        #region ���p�����[�g

        private DepsitMainDB _depositMainDB = null;
        
        /// <summary>
        /// ���������[�g�v���p�e�B
        /// </summary>
        private DepsitMainDB depositMainDB
        {
            get
            {
                if (this._depositMainDB == null)
                {
                    this._depositMainDB = new DepsitMainDB();
                }

                return this._depositMainDB;
            }
        }

        private DepositReadDB _depositReadDB = null;

        /// <summary>
        /// ����Read�����[�g�v���p�e�B
        /// </summary>
        private DepositReadDB depositReadDB
        {
            get
            {
                if (this._depositReadDB == null)
                {
                    this._depositReadDB = new DepositReadDB();
                }

                return this._depositReadDB;
            }
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �����f�[�^�̓ǂݍ��݂��s�Ȃ��܂�
        /// </summary>
        /// <param name="origin">�Ăяo�����v���O����ID</param>
        /// <param name="readResultList">����Ǎ����ʃ��X�g</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����f�[�^�̓ǂݍ��݂��s�Ȃ��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.05</br>
        public int ReadFromSalesSlip(string origin, ref CustomSerializeArrayList readResultList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������f�[�^�Ǎ����ʃ`�F�b�N
                if (readResultList == null) return status;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //������f�[�^�Ǎ����ʂ�蔄��f�[�^���擾 -> �����f�[�^�����p�����[�^�Ƃ���
                SalesSlipWork salesSlipParam = ListUtils.Find(readResultList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                
                //����f�[�^���Ȃ���ΐ���I��
                if (salesSlipParam == null) return status;

                //�������f�[�^�̓Ǎ�
                object searchParaDepositRead = CreateReadParameterList(salesSlipParam);
                object depositDataResult;
                object depositAlwWorkList;
                SqlTransaction dummyTran = null;

                status = depositReadDB.Search(out depositDataResult, out depositAlwWorkList, searchParaDepositRead, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref dummyTran);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    //���X�|���X�f�[�^����
                    DepositInfo readDepositInfo = null;

                    readDepositInfo = this.CreateReadResult((ArrayList)depositDataResult, (ArrayList)depositAlwWorkList);

                    if (readDepositInfo != null)
                    {
                        readResultList.Add(readDepositInfo.DepsitDataWork);
                        readResultList.Add(readDepositInfo.DepositAlwWorkArray[0]);
                    }
                }

                //�f�[�^���͐���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�����p�̃p�����[�^�𐶐�
        /// </summary>
        /// <param name="salesSlipParam">����f�[�^</param>
        /// <returns>�����p�p�����[�^</returns>
        private SearchParaDepositRead CreateReadParameterList(SalesSlipWork salesSlipParam)
        {
            //�����������̌��������𐶐�
            SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            searchParaDepositRead.EnterpriseCode = salesSlipParam.EnterpriseCode;    // ��ƃR�[�h
            searchParaDepositRead.AutoDepositCd = 1;                                 // ���������敪
            searchParaDepositRead.AcptAnOdrStatus = salesSlipParam.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
            searchParaDepositRead.SalesSlipNum = salesSlipParam.SalesSlipNum;        // ����`�[�ԍ�
�@          return searchParaDepositRead;
        }
        #endregion

        #region [Write] implements IFunctionCallTargetWrite
        /// <summary>
        /// �����X�V�̏����������s���܂�
        /// </summary>
        /// <param name="origin">�Ăяo�����v���O����ID</param>
        /// <param name="originList">�X�V�O�I�u�W�F�N�g</param>
        /// <param name="list">�p�����[�^List</param>
        /// <param name="position">�Ώۃp�����[�^�N���X�ʒu</param>
        /// <param name="param">�\���t�@�C���p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.03.17</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���X�V�Ώۃp�����[�^���X�g�`�F�b�N
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": �X�V�Ώۃp�����[�^List�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������`�[�I�u�W�F�N�g�̎擾
                SalesSlipWork salesSlipParam = ListUtils.Find(list, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": �X�V�Ώ۔���I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������f�[�^�I�u�W�F�N�g�̎擾
                DepsitDataWork depsitDataWork = ListUtils.Find(list, typeof(DepsitDataWork), ListUtils.FindType.Class) as DepsitDataWork;

                if (depsitDataWork == null)
                {
                    errmsg += ": �X�V�Ώۓ����I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�����������f�[�^�I�u�W�F�N�g�̎擾
                DepositAlwWork depositAlwWork = ListUtils.Find(list, typeof(DepositAlwWork), ListUtils.FindType.Class) as DepositAlwWork;

                if (depositAlwWork == null)
                {
                    errmsg += ": �X�V�Ώۓ��������I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������E�����������I�u�W�F�N�g�̍쐬
                DepositInfo depositInfo = new DepositInfo();
                depositInfo.DepsitDataWork = depsitDataWork;
                DepositAlwWork[] depositAlwArray = new DepositAlwWork[] { depositAlwWork };
                depositInfo.DepositAlwWorkArray = depositAlwArray;
                this.CreateDepositParameter(salesSlipParam, ref depositInfo);

                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlArray);

                //�������`�[�ԍ��̍̔�
                this.depositMainDB.WriteInitial(ref depsitMainWork, ref depsitDtlArray, ref depositAlwArray, ref sqlConnection, ref sqlTransaction);

                DepsitDataUtil.UnionRef(ref depsitDataWork, depsitMainWork, depsitDtlArray);

                // ���X�g�ɒǉ�
                list.Add(depositInfo);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);                
            }
            finally
            {
                //�f�[�^�����̏ꍇ�̓X�e�[�^�X���x���X�e�[�^�X�ɕύX����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "�X�V���ꂽ�����f�[�^�͂���܂���B" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// �����X�V�����̌Ăяo�����s���܂�
        /// </summary>
        /// <param name="origin">�Ăяo�����v���O����ID</param>
        /// <param name="originList">�X�V�O�I�u�W�F�N�g</param>
        /// <param name="list">�p�����[�^List</param>
        /// <param name="position">�Ώۃp�����[�^�N���X�ʒu</param>
        /// <param name="param">�\���t�@�C���p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����X�V�������s���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.03.17</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���X�V�Ώۃp�����[�^���X�g�`�F�b�N
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": �X�V�Ώۃp�����[�^List�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������`�[�I�u�W�F�N�g�̎擾
                SalesSlipWork salesSlipParam = ListUtils.Find(list, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": �X�V�Ώ۔���I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������E�����������I�u�W�F�N�g�̎擾
                DepositInfo depositInfo = ListUtils.Find(list, typeof(DepositInfo), ListUtils.FindType.Class) as DepositInfo;

                if (depositInfo == null)
                {
                    errmsg += ": �X�V�Ώۓ����E�����������I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
               
                DepsitDataWork depsitDataWork = depositInfo.DepsitDataWork;
                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlArray);
                DepositAlwWork[] depositAlwArray = depositInfo.DepositAlwWorkArray;
                
                status = this.depositMainDB.WriteProc(ref depsitMainWork, ref depsitDtlArray, ref depositAlwArray, ref sqlConnection, ref sqlTransaction);
                    
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "�����f�[�^�̍X�V�����ŃG���[���������܂����B" + retMsg;
                }
                else
                {
                    DepsitDataUtil.UnionRef(ref depsitDataWork, depsitMainWork, depsitDtlArray);

                    // ���������[�g���ōX�V���������������v�z����������c�����A����`�[�f�[�^�ɍĐݒ肷��
                    status = this.UpdateSalesSlipAutoDepositSlipNo(depsitMainWork, ref salesSlipParam, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                // �ǉ������p�����[�^��list����폜
                list.Remove(depositInfo);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        #endregion

        #region [RedWrite] implements IFunctionCallTargetRedBlackWrite
        /// <summary>
        /// ����f�[�^�ԓ`�X�V��������
        /// </summary>
        /// <param name="origin">�Ăяo�����v���O����ID</param>
        /// <param name="originList">�����p�����[�^List</param>
        /// <param name="redList">�ԓ`�p�����[�^List</param>
        /// <param name="retRedList">�ԓ`�X�V����List</param>
        /// <param name="position">�Ώۃp�����[�^�N���X�ʒu</param>
        /// <param name="param">�\���t�@�C���p�����[�^</param>
        /// <param name="freeParam">�t���[�p�����[�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����f�[�^�ԓ`�X�V�̓����f�[�^�X�V�����������s�Ȃ��܂��B</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.07.04</br>
        public int RedWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            // �����̐ԓ`�[�͑��݂����A�ʏ�̍��`�Ƃ��ēo�^���邪�A���z�Ȃǂ��}�C�i�X�ɂ��đ��E����悤�ȃf�[�^�Ƃ��Ă���
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���ԓ`�X�V�p�����[�^���X�g�̃`�F�b�N
                if (ListUtils.IsEmpty(redList))
                {
                    errmsg += ": �ԓ`�X�V�Ώۃp�����[�^List�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������ԓ`�I�u�W�F�N�g�̎擾
                SalesSlipWork salesSlipParam = ListUtils.Find(redList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": �X�V�Ώ۔���ԓ`�I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������I�u�W�F�N�g�̎擾
                DepsitDataWork depsitDataWork = ListUtils.Find(redList, typeof(DepsitDataWork), ListUtils.FindType.Class) as DepsitDataWork;

                if (depsitDataWork == null)
                {
                    errmsg += ": �X�V�Ώۓ����I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������I�u�W�F�N�g�̎擾
                DepositAlwWork depositAlwWork = ListUtils.Find(redList, typeof(DepositAlwWork), ListUtils.FindType.Class) as DepositAlwWork;

                if (depositAlwWork == null)
                {
                    errmsg += ": �X�V�Ώۓ��������I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������E�����������I�u�W�F�N�g�̍쐬
                DepositInfo depositInfo = new DepositInfo();
                depositInfo.DepsitDataWork = depsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };

                this.CreateDepositParameter(salesSlipParam, ref depositInfo);

                // ���X�g�ɒǉ�
                redList.Add(depositInfo);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //TODO: WARNING �̈���
                //�f�[�^�����̏ꍇ�̓X�e�[�^�X���x���X�e�[�^�X�ɕύX����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "�X�V���ꂽ�����f�[�^�͂���܂���B" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }
            
            return status;
        }

        /// <summary>
        /// ����f�[�^�ԓ`�X�V��������
        /// </summary>
        /// <param name="origin">�Ăяo�����v���O����ID</param>
        /// <param name="originList">�����p�����[�^List</param>
        /// <param name="redList">�ԓ`�p�����[�^List</param>
        /// <param name="retRedList">�ԓ`�X�V����List</param>
        /// <param name="position">�Ώۃp�����[�^�N���X�ʒu</param>
        /// <param name="param">�\���t�@�C���p�����[�^</param>
        /// <param name="freeParam">�t���[�p�����[�^</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����f�[�^�ԓ`�X�V�̓����f�[�^�X�V�������s�Ȃ��܂��B</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.07.04</br>
        public int RedWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���X�V�Ώۃp�����[�^���X�g�`�F�b�N
                if (ListUtils.IsEmpty(redList))
                {
                    errmsg += ": �X�V�Ώۃp�����[�^List�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������`�[�I�u�W�F�N�g�̎擾
                SalesSlipWork salesSlipParam = ListUtils.Find(redList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                if (salesSlipParam == null)
                {
                    errmsg += ": �X�V�Ώ۔���I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������E�����������I�u�W�F�N�g�̎擾
                DepositInfo depositInfo = ListUtils.Find(redList, typeof(DepositInfo), ListUtils.FindType.Class) as DepositInfo;

                if (depositInfo == null)
                {
                    errmsg += ": �X�V�Ώۓ����E�����������I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlArray = null;
                DepsitDataUtil.Division(depositInfo.DepsitDataWork, out depsitMainWork, out depsitDtlArray);
                DepositAlwWork[] depositAlwArray = depositInfo.DepositAlwWorkArray;
                status = depositMainDB.Write(ref depsitMainWork, ref depsitDtlArray, ref depositAlwArray, ref sqlConnection, ref sqlTransaction);
                    
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "�����f�[�^�̍X�V�����ŃG���[���������܂����B" + retMsg;
                }
                else
                {
                    // �ԓ`�X�V���ʃ��X�g�ɒǉ�����
                    //retRedList.Add(depositMainWork);
                    //retRedList.Add(depositAlwWorkArray[0]);

                    // ���������`�[�ԍ����p�����[�^�ɃZ�b�g�������B
                    status = this.UpdateSalesSlipAutoDepositSlipNo(depsitMainWork, ref salesSlipParam, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }

                // �ǉ������p�����[�^��list����폜
                redList.Remove(depositInfo);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteMAHNBDepositDB.RedWrite:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            return status;
        }

        #endregion

        #region [Delete] implements IFunctionCallTargetWrite
        /// <summary>
        /// �����X�V�폜��������
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�����폜List</param>
        /// <param name="list"></param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�����폜��������</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.03.17</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���X�V�Ώۃp�����[�^���X�g�`�F�b�N
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": �X�V�Ώۃp�����[�^���X�g�����w��ł�";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������`�[�폜�I�u�W�F�N�g�̎擾
                SalesSlipDeleteWork salesSlipDeleteParam = ListUtils.Find(list, typeof(SalesSlipDeleteWork), ListUtils.FindType.Class) as SalesSlipDeleteWork;
                SalesSlipWork salesSlipParam = null;

                if (salesSlipDeleteParam == null)
                {
                    errmsg += ": �폜�Ώ۔���I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                else
                {
                    // ����`�[�폜�I�u�W�F�N�g���甄��`�[�I�u�W�F�N�g�𐶐�����(��q�̓����E�����������I�u�W�F�N�g���쐬����ۂɕK�v�Ȃ���)
                    salesSlipParam = new SalesSlipWork();
                    salesSlipParam.EnterpriseCode = salesSlipDeleteParam.EnterpriseCode;    // ��ƃR�[�h
                    salesSlipParam.AcptAnOdrStatus = salesSlipDeleteParam.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
                    salesSlipParam.SalesSlipNum = salesSlipDeleteParam.SalesSlipNum;        // ����`�[�ԍ�
                    salesSlipParam.DebitNoteDiv = salesSlipDeleteParam.DebitNoteDiv;        // �ԓ`�敪
                    salesSlipParam.UpdateDateTime = salesSlipDeleteParam.UpdateDateTime;    // �X�V���t
                }

                //�������I�u�W�F�N�g�̎擾
                DepsitDataWork depsitDataWork = ListUtils.Find(list, typeof(DepsitDataWork), ListUtils.FindType.Class) as DepsitDataWork;

                if (depsitDataWork == null)
                {
                    errmsg += ": �X�V�Ώۓ����I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�����������I�u�W�F�N�g�̎擾
                DepositAlwWork depositAlwWork = ListUtils.Find(list, typeof(DepositAlwWork), ListUtils.FindType.Class) as DepositAlwWork;

                if (depositAlwWork == null)
                {
                    errmsg += ": �X�V�Ώۓ��������I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������E�����������I�u�W�F�N�g�̍쐬
                DepositInfo depositInfo = new DepositInfo();
                depositInfo.DepsitDataWork = depsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };

                //���폜�̏ꍇ��UI������ǂݍ��ݍς݂̓����E�����f�[�^�𓾂��邽�߁A�l�̍Đݒ�͕s�v
                //this.CreateDepositParameter(salesSlipParam, ref depositInfo);

                // ���X�g�ɒǉ�
                list.Add(depositInfo);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //�f�[�^�����̏ꍇ�̓X�e�[�^�X���x���X�e�[�^�X�ɕύX����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "�폜��������f�[�^�͂���܂���B" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="list"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���X�V�Ώۃp�����[�^���X�g�`�F�b�N
                if (ListUtils.IsEmpty(list))
                {
                    errmsg += ": �X�V�Ώۃp�����[�^���X�g�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //�������E�����������I�u�W�F�N�g�̎擾
                DepositInfo depositInfo = ListUtils.Find(list, typeof(DepositInfo), ListUtils.FindType.Class) as DepositInfo;

                if (depositInfo == null)
                {
                    errmsg += ": �X�V�Ώۓ����E�����������I�u�W�F�N�g�p�����[�^�����w��ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                // ��ƃR�[�h�{�����`�[�ԍ��œ����f�[�^���폜����
                status = depositMainDB.LogicalDelete(depositInfo.DepsitDataWork.EnterpriseCode, depositInfo.DepsitDataWork.DepositSlipNo, depositInfo.DepsitDataWork.AcptAnOdrStatus, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "�����̍폜�����ŃG���[���������܂����B" + retMsg;
                }

                // �p�����[�^�̍폜
                list.Remove(depositInfo);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        #endregion

        /// <summary>
        /// ���㎩�����������ɂ����āA���������[�g���ōX�V���ꂽ���������c��������������v�z���Đݒ肷��
        /// </summary>
        /// <param name="depositmain">�����f�[�^</param>
        /// <param name="salesslip">����f�[�^</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns>status</returns>
        private int UpdateSalesSlipAutoDepositSlipNo(DepsitMainWork depositmain, ref SalesSlipWork salesslip, ref SqlConnection sqlConnection,
                                                    ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (depositmain != null && depositmain.DepositSlipNo > 0 &&
                salesslip != null && salesslip.AutoDepositCd == 1 &&
                sqlConnection != null && sqlTransaction != null)
            {
                try
                {
                    // ���������[�g���ōX�V���Ă��鍀�ڂ��擾���A����f�[�^�p�����[�^�ɃZ�b�g����
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLIP.DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                    sqlText += " ,SLIP.DEPOSITALWCBLNCERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar).Value = salesslip.EnterpriseCode;  // ��ƃR�[�h
                        sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int).Value = salesslip.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
                        sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar).Value = salesslip.SalesSlipNum;      // ����`�[�ԍ�

                        SqlDataReader myReader = sqlCommand.ExecuteReader();

                        try
                        {
                            if (myReader.Read())
                            {
                                salesslip.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));  // �����������v�z
                                salesslip.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));        // ���������c��
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                myReader.Close();
                                myReader.Dispose();
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, errmsg, status);
                }
            }
            else
            {
                errmsg += ": �e��p�����[�^������������܂���.";
                base.WriteErrorLog(errmsg, status);
            }

            return status;
        }

        //MEMO: �������Ȃ�
        #region [RedBlackWrite] implements IFunctionCallTargetRedBlackWrite
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="redList"></param>
        /// <param name="blackList"></param>
        /// <param name="retRedList"></param>
        /// <param name="retBlackList"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int RedBlackWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList blackList, ref CustomSerializeArrayList retRedList, ref CustomSerializeArrayList retBlackList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="redList"></param>
        /// <param name="blackList"></param>
        /// <param name="retRedList"></param>
        /// <param name="retBlackList"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int RedBlackWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList blackList, ref CustomSerializeArrayList retRedList, ref CustomSerializeArrayList retBlackList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
        
        #region �p�����[�^����
        # region [DELETE]
        /*
        /// <summary>
        /// �����}�X�^�E���������}�X�^�X�V�p�����[�^����
        /// </summary>
        /// <param name="salesSlipParam">����f�[�^�X�V�p�����[�^</param>
        /// <param name="depositParamList">����������</param>
        /// <param name="depositInfoList">�����X�V�p�����[�^</param>
        private void CreateDepositParameter(SalesSlipWork salesSlipParam, ArrayList depositParamList, out ArrayList depositInfoList)
        {
            depositInfoList = new ArrayList();

            try
            {
                for (int i = 0; i < depositParamList.Count; i++)
                {
                    IOWriteMAHNBDepositWork depositParam = (depositParamList[i] as IOWriteMAHNBDepositWork);

                    if (depositParam != null)
                    {
                        //���X�V�p�����[�^�i�[����
                        //�a����敪�������A�a����ȊO�̏ꍇ�͏������Ȃ�
                        if (depositParam.DepositCd != 0 && depositParam.DepositCd != 1) return;

                        #region �����}�X�^
                        DepsitMainWork depositMainWork = new DepsitMainWork();

                        // ����f�[�^�̒l���Z�b�g
                        depositMainWork.EnterpriseCode = salesSlipParam.EnterpriseCode;  // ��ƃR�[�h
                        depositMainWork.SubSectionCode = salesSlipParam.SubSectionCode;  // ���R�[�h
                        depositMainWork.MinSectionCode = salesSlipParam.MinSectionCode;  // �ۃR�[�h

                        depositMainWork.AcptAnOdrStatus = salesSlipParam.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
                        depositMainWork.AddUpSecCode = salesSlipParam.DemandAddUpSecCd;    // �����v�㋒�_�R�[�h                

                        depositMainWork.CustomerCode = salesSlipParam.CustomerCode;    // ���Ӑ�R�[�h
                        depositMainWork.CustomerName = salesSlipParam.CustomerName;    // ���Ӑ於��
                        depositMainWork.CustomerName2 = salesSlipParam.CustomerName2;  // ���Ӑ於�̂Q
                        depositMainWork.CustomerSnm = salesSlipParam.CustomerSnm;      // ���Ӑ旪��

                        depositMainWork.DepositAgentCode = salesSlipParam.SalesEmployeeCd;    // �����S���҃R�[�h �� �v��S���҃R�[�h
                        depositMainWork.DepositAgentNm = salesSlipParam.SalesEmployeeNm;      // �����S���Җ�     �� �v��S���Җ�
                        depositMainWork.DepositDate = salesSlipParam.SalesDate;               // �������t �� ������t
                        depositMainWork.DepositInputAgentCd = salesSlipParam.SalesInputCode;  // �������͎҃R�[�h �� ������͎҃R�[�h
                        depositMainWork.DepositInputAgentNm = salesSlipParam.SalesInputName;  // �������͎Җ�     �� ������͎Җ�
                        depositMainWork.InputDepositSecCd = salesSlipParam.SalesInpSecCd;     // �������͋��_�R�[�h
                        depositMainWork.SalesSlipNum = salesSlipParam.SalesSlipNum;           // ����`�[�ԍ�
                        depositMainWork.UpdateSecCd = salesSlipParam.UpdateSecCd;             // �X�V���_�R�[�h
                        depositMainWork.AutoDepositCd = salesSlipParam.AutoDepositCd;         // ���������敪
                        depositMainWork.Outline = salesSlipParam.SalesSlipNum;                // �`�[�E�v �� ����`�[�ԍ�

                        // �����p�����[�^�̒l���Z�b�g
                        depositMainWork.ClaimCode = depositParam.ClaimCode;    // ������R�[�h
                        depositMainWork.ClaimName = depositParam.ClaimName;    // �����於�̂Q
                        depositMainWork.ClaimName2 = depositParam.ClaimName2;  // �����於�̂Q
                        depositMainWork.ClaimSnm = depositParam.ClaimSnm;      // �����旪��
                        depositMainWork.Deposit = depositParam.Deposit;        // �������z
                        depositMainWork.DepositCd = depositParam.DepositCd;    // �a����敪

                        depositMainWork.DepositKindCode = depositParam.DepositKindCode;    // ��������R�[�h
                        depositMainWork.DepositKindName = depositParam.DepositKindName;    // �������햼��
                        depositMainWork.DepositKindDivCd = depositParam.DepositKindDivCd;  // ��������敪
                        depositMainWork.DepositTotal = depositParam.DepositTotal;          // �����v
                        depositMainWork.DiscountDeposit = depositParam.DiscountDeposit;    // �l�������z
                        depositMainWork.FeeDeposit = depositParam.FeeDeposit;              // �萔�������z
                        depositMainWork.DepositSlipNo = depositParam.DepositSlipNo;        // �����`�[�ԍ�(�ēo�^���ɃZ�b�g�ς�)

                        // UI����̓f�[�^�Z�b�g���Ȃ��Ă�������
                        depositMainWork.AddUpADate = depositMainWork.DepositDate;      // �v����t ���������t 
                        depositMainWork.DepositAllowance = depositParam.DepositTotal;  // ���������z �� �����v
                        depositMainWork.DepositDebitNoteCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // �����ԍ��敪 �� ���ォ��쐬��������͏�ɍ��Ƃ���
                        depositMainWork.LastReconcileAddUpDt = depositMainWork.DepositDate;
                        //depositDataWorkList.DepositAlwcBlnce = depositDataWorkList.DepositAlwcBlnce;  // ���������c���͓������Ōv�Z
                        #endregion

                        #region ���������}�X�^
                        DepositAlwWork depositAlwWork = new DepositAlwWork();
                        depositAlwWork.AcptAnOdrStatus = depositMainWork.AcptAnOdrStatus;
                        depositAlwWork.AddUpSecCode = depositMainWork.AddUpSecCode;
                        depositAlwWork.CustomerCode = depositMainWork.CustomerCode;
                        depositAlwWork.CustomerName = depositMainWork.CustomerName;
                        depositAlwWork.CustomerName2 = depositMainWork.CustomerName2;
                        depositAlwWork.DebitNoteOffSetCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // �����ԍ��敪 �� ���ォ��쐬��������͏�ɍ��Ƃ���
                        depositAlwWork.DepositAgentCode = depositMainWork.DepositInputAgentCd;
                        depositAlwWork.DepositAgentNm = depositMainWork.DepositInputAgentNm;
                        depositAlwWork.DepositAllowance = depositMainWork.DepositAllowance;
                        depositAlwWork.DepositCd = depositMainWork.DepositCd;
                        depositAlwWork.DepositKindCode = depositMainWork.DepositKindCode;
                        depositAlwWork.DepositKindName = depositMainWork.DepositKindName;
                        depositAlwWork.DepositSlipNo = depositMainWork.DepositSlipNo;
                        depositAlwWork.EnterpriseCode = depositMainWork.EnterpriseCode;
                        depositAlwWork.InputDepositSecCd = depositMainWork.InputDepositSecCd;
                        depositAlwWork.ReconcileAddUpDate = depositMainWork.AddUpADate;  //�����݌v��� = �����v���
                        depositAlwWork.ReconcileDate = depositMainWork.DepositDate;      //�����ݓ� = �������t
                        depositAlwWork.SalesSlipNum = depositMainWork.SalesSlipNum;
                        #endregion

                        DepositInfo depositInfo = new DepositInfo();
                        depositInfo.DepositMainWork = depositMainWork;
                        depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };
                        depositInfoList.Add(depositInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                if (depositInfoList != null)
                {
                    depositInfoList = null;
                }
            }
        }
        */
        # endregion
        # endregion

        /// <summary>
        /// ����f�[�^�Ɣ�������f�[�^��������E���������f�[�^���쐬���܂��B
        /// </summary>
        /// <param name="salesslipparam">����`�[�f�[�^</param>
        /// <param name="depositInfo">�����E���������f�[�^</param>
        /// <remarks>
        /// <br>Update Note: 2013/01/18 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33797 �����m�F�\�̓E�v�����e���C��</br>
        /// </remarks>
        private void CreateDepositParameter(SalesSlipWork salesslipparam, ref DepositInfo depositInfo)
        {
            try
            {
                if (salesslipparam != null && depositInfo != null)
                {
                    #region �����}�X�^
                    DepsitDataWork depsitDataWork = depositInfo.DepsitDataWork;

                    depsitDataWork.EnterpriseCode = salesslipparam.EnterpriseCode;                      // ��ƃR�[�h
                    depsitDataWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;    // �_���폜�敪
                    depsitDataWork.AcptAnOdrStatus = salesslipparam.AcptAnOdrStatus;                    // �󒍃X�e�[�^�X
                    depsitDataWork.DepositDebitNoteCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // �����ԍ��敪 �� ���ォ��쐬��������͏�ɍ��Ƃ���
                    depsitDataWork.SalesSlipNum = salesslipparam.SalesSlipNum;                          // ����`�[�ԍ�
                    depsitDataWork.InputDepositSecCd = salesslipparam.SalesInpSecCd;                    // �������͋��_�R�[�h  �� ������͋��_�R�[�h
                    depsitDataWork.AddUpSecCode = salesslipparam.DemandAddUpSecCd;                      // �v�㋒�_�R�[�h      �� �����v�㋒�_�R�[�h
                    depsitDataWork.UpdateSecCd = salesslipparam.UpdateSecCd;                            // �X�V���_�R�[�h
                    depsitDataWork.SubSectionCode = salesslipparam.SubSectionCode;                      // ����R�[�h
                    depsitDataWork.InputDay = salesslipparam.SearchSlipDate;                            // ���͓��t         �� �`�[�������t  //ADD 2009/03/25
                    depsitDataWork.DepositDate = salesslipparam.SearchSlipDate;                         // �������t         �� �`�[�������t
                    depsitDataWork.AddUpADate = salesslipparam.SalesDate;                               // �v����t         �� ������t
                    depsitDataWork.DepositTotal = salesslipparam.SalesTotalTaxInc;                      // �����v           �� ����`�[���v(�ō�)
                    depsitDataWork.Deposit = salesslipparam.SalesTotalTaxInc;                           // �������z         �� ����`�[���v(�ō�)
                    depsitDataWork.AutoDepositCd = salesslipparam.AutoDepositCd;                        // ���������敪
                    depsitDataWork.DepositAllowance = salesslipparam.SalesTotalTaxInc;                  // ���������z       �� ����`�[���v(�ō�)
                    depsitDataWork.DepositAgentCode = salesslipparam.SalesEmployeeCd;                   // �����S���҃R�[�h �� �v��S���҃R�[�h
                    depsitDataWork.DepositAgentNm = salesslipparam.SalesEmployeeNm;                     // �����S���Җ���   �� �v��S���Җ�
                    depsitDataWork.DepositInputAgentCd = salesslipparam.SalesInputCode;                 // �������͎҃R�[�h �� ������͎҃R�[�h
                    depsitDataWork.DepositInputAgentNm = salesslipparam.SalesInputName;                 // �������͎Җ���   �� ������͎Җ�
                    //depsitDataWork.CustomerCode = salesslipparam.CustomerCode;                        // ���Ӑ�R�[�h
                    //depsitDataWork.CustomerName = salesslipparam.CustomerName;                        // ���Ӑ於��
                    //depsitDataWork.CustomerName2 = salesslipparam.CustomerName2;                      // ���Ӑ於��2
                    //depsitDataWork.CustomerSnm = salesslipparam.CustomerSnm;                          // ���Ӑ旪��
                    depsitDataWork.CustomerCode = salesslipparam.ClaimCode;                             // ���Ӑ�R�[�h �� ������R�[�h ��PM7�d�l�ɏ���
                    depsitDataWork.CustomerName = depsitDataWork.ClaimName;                             // ���Ӑ於��   �� �����於��(UI���ݒ�)
                    depsitDataWork.CustomerName2 = depsitDataWork.ClaimName2;                           // ���Ӑ於��2  �� �����於�̂Q(UI���ݒ�)
                    depsitDataWork.CustomerSnm = salesslipparam.ClaimSnm;                               // ���Ӑ旪��   �� �����旪��
                    depsitDataWork.ClaimCode = salesslipparam.ClaimCode;                                // ������R�[�h
                    depsitDataWork.ClaimSnm = salesslipparam.ClaimSnm;                                  // �����旪��
                    //depsitDataWork.Outline = salesslipparam.SalesSlipNum;                               // �`�[�E�v         �� ����`�[�ԍ� // DEL 2013/01/18 �c���� Redmine#33797
                    //----- ADD 2013/01/18 �c���� Redmine#33797 ------------------------------------->>>>>
                    // �����������l�敪(AutoDepositNoteDivRF)(0:����`�[�ԍ� 1:����`�[���l 2:����)
                    if (salesslipparam.AutoDepositNoteDiv == 0)
                    {
                        depsitDataWork.Outline = salesslipparam.SalesSlipNum;                           // �`�[�E�v �� ����`�[�ԍ�
                    }
                    else if (salesslipparam.AutoDepositNoteDiv == 1)
                    {
                        depsitDataWork.Outline = salesslipparam.SlipNote;                               // �`�[�E�v �� ����`�[���l
                    }
                    else if (salesslipparam.AutoDepositNoteDiv == 2)
                    {
                        depsitDataWork.Outline = string.Empty;                                          // �`�[�E�v �� ����
                    }
                    else
                    {
                        depsitDataWork.Outline = string.Empty;                                          // �`�[�E�v �� ����
                    }
                    //----- ADD 2013/01/18 �c���� Redmine#33797 -------------------------------------<<<<<
                    depsitDataWork.DepositRowNo1 = 1;                                                   // �����s�ԍ��P
                    depsitDataWork.Deposit1 = salesslipparam.SalesTotalTaxInc;                          // �������z�P
                    #endregion

                    #region ���������}�X�^
                    DepositAlwWork depositAlwWork = depositInfo.DepositAlwWorkArray[0];

                    depositAlwWork.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;
                    depositAlwWork.AddUpSecCode = depsitDataWork.AddUpSecCode;
                    //depositAlwWork.CustomerCode = depsitDataWork.CustomerCode;
                    //depositAlwWork.CustomerName = depsitDataWork.CustomerName;
                    //depositAlwWork.CustomerName2 = depsitDataWork.CustomerName2;
                    depositAlwWork.CustomerCode = depsitDataWork.ClaimCode;
                    depositAlwWork.CustomerName = depsitDataWork.ClaimName;
                    depositAlwWork.CustomerName2 = depsitDataWork.ClaimName2;
                    depositAlwWork.DebitNoteOffSetCd = (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // �����ԍ��敪 �� ���ォ��쐬��������͏�ɍ��Ƃ���
                    depositAlwWork.DepositAgentCode = depsitDataWork.DepositInputAgentCd;
                    depositAlwWork.DepositAgentNm = depsitDataWork.DepositInputAgentNm;
                    depositAlwWork.DepositAllowance = depsitDataWork.DepositAllowance;
                    depositAlwWork.DepositSlipNo = depsitDataWork.DepositSlipNo;
                    depositAlwWork.EnterpriseCode = depsitDataWork.EnterpriseCode;
                    depositAlwWork.InputDepositSecCd = depsitDataWork.InputDepositSecCd;
                    depositAlwWork.ReconcileAddUpDate = depsitDataWork.AddUpADate;  //�����݌v��� = �����v���
                    depositAlwWork.ReconcileDate = depsitDataWork.DepositDate;      //�����ݓ� = �������t
                    depositAlwWork.SalesSlipNum = depsitDataWork.SalesSlipNum;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg);

                if (depositInfo != null)
                {
                    depositInfo = null;
                }
            }
        }

        /// <summary>
        /// �Ǎ������f�[�^�p�����[�^�𐶐�����
        /// </summary>
        /// <param name="depositDataWorkList">�����}�X�^</param>
        /// <param name="depositAlwWorkList">���������}�X�^</param>
        /// <returns>�����f�[�^�p�����[�^</returns>
        private DepositInfo CreateReadResult(ArrayList depositDataWorkList, ArrayList depositAlwWorkList)
        {
            DepositInfo depositInfo = new DepositInfo();
            depositInfo.DepsitDataWork = null;
            depositInfo.DepositAlwWorkArray = null;

            //�����`�[�ԍ��Ń\�[�g
            if (ListUtils.IsNotEmpty(depositDataWorkList)) depositDataWorkList.Sort(new DepositDataComparer());
            if (ListUtils.IsNotEmpty(depositAlwWorkList)) depositAlwWorkList.Sort(new DepositAlwComparer());

            //�擪�̓����f�[�^�Ɠ��������f�[�^��Ԃ�(���㓯�������̏ꍇ�A���ꂼ��f�[�^�͂P�������ł��Ȃ���)
            if (depositDataWorkList.Count > 0 && depositAlwWorkList.Count > 0)
            {
                depositInfo.DepsitDataWork = depositDataWorkList[0] as DepsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWorkList[0] as DepositAlwWork };
            }

            return depositInfo;
        }


        # region --- DEL ---
# if false
        /// <summary>
        /// ���������폜�p�̃p�����[�^�𐶐�����
        /// </summary>
        /// <param name="depositWork">����f�[�^</param>
        /// <param name="depositDataWorkList">�����}�X�^</param>
        /// <param name="depositAlwWorkList">���������}�X�^</param>
        /// <param name="depositInfoList">�����X�V�p�����[�^</param>
        private void CreateDeleteDepositParameter(SalesSlipWork salesSlipWork, ArrayList depositMainWorkList, ArrayList depositAlwWorkList, out ArrayList depositInfoList)
        {
            depositInfoList = new ArrayList();

            for (int i = 0; i < depositMainWorkList.Count; i++)
            {
                DepositInfo depositInfo = new DepositInfo();

                //�󒍔ԍ��w�肾����A����:��������=1:1�ɂȂ�
                DepsitMainWork depositMainWork = (DepsitMainWork)depositMainWorkList[i];
                DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkList[i];

                //�����͍폜 -- LogicalDeleteCode��1���Z�b�g
                depositAlwWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;

                //�������̓��������z����
                depositMainWork.DepositAllowance -= depositAlwWork.DepositAllowance;
                depositMainWork.DepositAlwcBlnce += depositAlwWork.DepositAllowance;

                depositInfo.DepositMainWork = depositMainWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWork };

                depositInfoList.Add(depositInfo);
            }
        }

        /// <summary>
        /// �Ǎ������f�[�^�p�����[�^�𐶐�����
        /// </summary>
        /// <param name="depositDataWorkList">�����}�X�^</param>
        /// <param name="depositAlwWorkList">���������}�X�^</param>
        /// <returns>�����f�[�^�p�����[�^</returns>
        private DepositInfo CreateReadResult(ArrayList depositDataWorkList, ArrayList depositAlwWorkList)
        {
            DepositInfo depositInfo = new DepositInfo();
            depositInfo.DepsitDataWork = null;
            depositInfo.DepositAlwWorkArray = null;

            //�����`�[�ԍ��Ń\�[�g
            if (ListUtils.IsNotEmpty(depositDataWorkList)) depositDataWorkList.Sort(new DepositDataComparer());
            if (ListUtils.IsNotEmpty(depositAlwWorkList)) depositAlwWorkList.Sort(new DepositAlwComparer());

            //�擪�̓����f�[�^�Ɠ��������f�[�^��Ԃ�(���㓯�������̏ꍇ�A���ꂼ��f�[�^�͂P�������ł��Ȃ���)
            if (depositDataWorkList.Count > 0 && depositAlwWorkList.Count > 0)
            {
                depositInfo.DepsitDataWork = depositDataWorkList[0] as DepsitDataWork;
                depositInfo.DepositAlwWorkArray = new DepositAlwWork[] { depositAlwWorkList[0] as DepositAlwWork };
            }

            return depositInfo;
        }

        /// <summary>
        /// DepsitMainWork �� DepositAlwWork ���� DepositParameterWork �𐶐�
        /// </summary>
        /// <param name="depositDataWorkList">�����}�X�^</param>
        /// <param name="depositAlwWorkList">���������}�X�^</param>
        /// <returns>�����p�����[�^</returns>
        /*
        private IOWriteMAHNBDepositWork NewDepositParam(DepsitMainWork depositMainWork, DepositAlwWork depositAlwWork)
        {
            IOWriteMAHNBDepositWork depositParam = new IOWriteMAHNBDepositWork();

            depositParam.CreateDateTime = depositMainWork.CreateDateTime;
            depositParam.UpdateDateTime = depositMainWork.UpdateDateTime;
            depositParam.EnterpriseCode = depositMainWork.EnterpriseCode;
            depositParam.FileHeaderGuid = depositMainWork.FileHeaderGuid;
            depositParam.UpdEmployeeCode = depositMainWork.UpdEmployeeCode;
            depositParam.UpdAssemblyId1 = depositMainWork.UpdAssemblyId1;
            depositParam.UpdAssemblyId2 = depositMainWork.UpdAssemblyId2;
            depositParam.LogicalDeleteCode = depositMainWork.LogicalDeleteCode;
            depositParam.AcptAnOdrStatus = depositMainWork.AcptAnOdrStatus;
            depositParam.DepositDebitNoteCd = depositMainWork.DepositDebitNoteCd;
            depositParam.DepositSlipNo = depositMainWork.DepositSlipNo;
            depositParam.SalesSlipNum = depositMainWork.SalesSlipNum;
            depositParam.InputDepositSecCd = depositMainWork.InputDepositSecCd;
            depositParam.AddUpSecCode = depositMainWork.AddUpSecCode;
            depositParam.UpdateSecCd = depositMainWork.UpdateSecCd;
            depositParam.SubSectionCode = depositMainWork.SubSectionCode;
            depositParam.MinSectionCode = depositMainWork.MinSectionCode;
            depositParam.DepositDate = depositMainWork.DepositDate;
            depositParam.AddUpADate = depositMainWork.AddUpADate;
            depositParam.DepositKindCode = depositMainWork.DepositKindCode;
            depositParam.DepositKindName = depositMainWork.DepositKindName;
            depositParam.DepositKindDivCd = depositMainWork.DepositKindDivCd;
            depositParam.DepositTotal = depositMainWork.DepositTotal;
            depositParam.Deposit = depositMainWork.Deposit;
            depositParam.FeeDeposit = depositMainWork.FeeDeposit;
            depositParam.DiscountDeposit = depositMainWork.DiscountDeposit;
            depositParam.AutoDepositCd = depositMainWork.AutoDepositCd;
            depositParam.DepositCd = depositMainWork.DepositCd;
            depositParam.DraftDrawingDate = depositMainWork.DraftDrawingDate;
            depositParam.DraftPayTimeLimit = depositMainWork.DraftPayTimeLimit;
            depositParam.DraftKind = depositMainWork.DraftKind;
            depositParam.DraftKindName = depositMainWork.DraftKindName;
            depositParam.DraftDivide = depositMainWork.DraftDivide;
            depositParam.DraftDivideName = depositMainWork.DraftDivideName;
            depositParam.DraftNo = depositMainWork.DraftNo;
            depositParam.DepositAllowance = depositMainWork.DepositAllowance;
            depositParam.DepositAlwcBlnce = depositMainWork.DepositAlwcBlnce;
            depositParam.DebitNoteLinkDepoNo = depositMainWork.DebitNoteLinkDepoNo;
            depositParam.LastReconcileAddUpDt = depositMainWork.LastReconcileAddUpDt;
            depositParam.DepositAgentCode = depositMainWork.DepositAgentCode;
            depositParam.DepositAgentNm = depositMainWork.DepositAgentNm;
            depositParam.DepositInputAgentCd = depositMainWork.DepositInputAgentCd;
            depositParam.DepositInputAgentNm = depositMainWork.DepositInputAgentNm;
            depositParam.CustomerCode = depositMainWork.CustomerCode;
            depositParam.CustomerName = depositMainWork.CustomerName;
            depositParam.CustomerName2 = depositMainWork.CustomerName2;
            depositParam.CustomerSnm = depositMainWork.CustomerSnm;
            depositParam.ClaimCode = depositMainWork.ClaimCode;
            depositParam.ClaimName = depositMainWork.ClaimName;
            depositParam.ClaimName2 = depositMainWork.ClaimName2;
            depositParam.ClaimSnm = depositMainWork.ClaimSnm;
            depositParam.Outline = depositMainWork.Outline;
            depositParam.BankCode = depositMainWork.BankCode;
            depositParam.BankName = depositMainWork.BankName;
            depositParam.EdiSendDate = depositMainWork.EdiSendDate;
            depositParam.EdiTakeInDate = depositMainWork.EdiTakeInDate;
                
            //depositParamList.ReconcileDate = depositAlwWorkList.ReconcileDate;
            //depositParamList.ReconcileAddUpDate = depositAlwWorkList.ReconcileAddUpDate;
            //depositParamList.DepositAllowance = depositAlwWorkList.DepositAllowance;
            //depositParamList.DebitNoteOffSetCd = depositAlwWorkList.DebitNoteOffSetCd;
            return depositParam;
        }
        */
# endif
        #endregion

        #region �p�����[�^�����p InnerClass
        /// <summary>
        /// ����-�����������֘A�t����
        /// </summary>
        //>>>2010/09/28
        //private class DepositInfo
        public class DepositInfo
        //<<<2010/09/28
        {
            private DepsitDataWork depsitDataWork = null;
            private DepositAlwWork[] depositAlwWorkArray = null;

            public DepsitDataWork DepsitDataWork
            {
                get { return depsitDataWork; }
                set { depsitDataWork = value; }
            }

            public DepositAlwWork[] DepositAlwWorkArray
            {
                get { return depositAlwWorkArray; }
                set { depositAlwWorkArray = value; }
            }
        }
        #endregion

        # region --- DEL ---
# if false

        /// <summary>
        /// ���_����ݒ�}�X�^���琿���v�㋒�_�R�[�h���擾����
        /// </summary>
        /// <param name="depositWork">�����f�[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_����ݒ�}�X�^���琿���v�㋒�_�R�[�h���擾����</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchClaimSecCd(ref DepsitMainWork depositWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    sqlCommand.CommandText = "SELECT CTRLFUNCSECTIONCODERF FROM SECCTRLSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CTRLFUNCCODERF=20";

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(depositWork.InputDepositSecCd);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        depositWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���ナ���[�g List ���[�e�B���e�B�N���X
        /// </summary>
        private class ListUtils
        {
            /// <summary>�����p�^�[�� Find() �ŗ��p</summary>
            public enum FIND_TYPE
            {
                /// <summary>�N���X</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }

            /// <summary>
            /// CustomArrayList ����w�肵���^�̃I�u�W�F�N�g���擾����
            /// </summary>
            /// <param name="paramArray">�����Ώۃp�����[�^List</param>
            /// <param name="type">�����Ώۃ^�C�v</param>
            /// <param name="pattern">�����p�^�[��</param>
            /// <param name="position">�p�����[�^�ʒu</param>
            /// <returns>�I�u�W�F�N�g</returns>
            public static object Find(CustomSerializeArrayList paramArray, Type type, FIND_TYPE pattern, out int position)
            {
                object result = null;
                position = -1;
                if (IsEmpty(paramArray)) return result;
                //�p�����[�^���擾
                if (pattern == FIND_TYPE.Class)
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] != null && paramArray[i].GetType() == type)
                        {
                            result = paramArray[i];
                            position = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] is ArrayList)
                        {
                            ArrayList al = paramArray[i] as ArrayList;
                            if (al != null && al.Count > 0)
                            {
                                if (al[0] != null && al[0].GetType() == type)
                                {
                                    result = paramArray[i];
                                    position = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// CustomArrayList ����w�肵���^�̃I�u�W�F�N�g���擾����
            /// </summary>
            /// <param name="paramArray">�����Ώۃp�����[�^List</param>
            /// <param name="type">�����Ώۃ^�C�v</param>
            /// <param name="pattern">�����p�^�[��</param>
            /// <returns>�I�u�W�F�N�g</returns>
            public static object Find(CustomSerializeArrayList paramArray, Type type, FIND_TYPE pattern)
            {
                int position;
                return Find(paramArray, type, pattern, out position);
            }

            /// <summary>
            /// ArrayList���󂩂ǂ����𔻒f����
            /// </summary>
            /// <param name="al">�����Ώ�ArrayList</param>
            /// <returns>true:�� false:��łȂ�</returns>
            public static bool IsEmpty(ArrayList al)
            {
                if (al == null || al.Count <= 0) return true;
                return false;
            }
            /// <summary>
            /// ArrayList���󂩂ǂ����𔻒f����
            /// </summary>
            /// <param name="al">�����Ώ�ArrayList</param>
            /// <returns>true:��łȂ� false:��</returns>
            public static bool IsNotEmpty(ArrayList al)
            {
                return !IsEmpty(al);
            }
        }
# endif
        # endregion

        #region Comparer
        /// <summary>
        /// �����}�X�^��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.15</br>
        /// </remarks>
        private class DepositDataComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                int result = 0;

                DepsitDataWork cx = x as DepsitDataWork;
                DepsitDataWork cy = y as DepsitDataWork;

                result = (cx == null ? 0 : 1) - (cy == null ? 0 : 1);

                //�����`�[�ԍ�
                if (result == 0 && cx != null)
                {
                    result = cx.DepositSlipNo - cy.DepositSlipNo;
                }

                //���ʂ�Ԃ�
                return result;
            }
        }
        /// <summary>
        /// ���������}�X�^��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.15</br>
        /// </remarks>
        private class DepositAlwComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                int result = 0;

                DepositAlwWork cx = (DepositAlwWork)x;
                DepositAlwWork cy = (DepositAlwWork)y;

                //�����`�[�ԍ�
                if (result == 0)
                    result = cx.DepositSlipNo - cy.DepositSlipNo;

                //����`�[�ԍ�
                try
                {
                    if (result == 0)
                        result = int.Parse(cx.SalesSlipNum) - int.Parse(cy.SalesSlipNum);
                }
                catch
                {
                    result = 0;
                }

                //���ʂ�Ԃ�
                return result;
            }
        }
        #endregion
    }
}
