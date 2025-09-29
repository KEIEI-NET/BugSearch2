//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�i�C���|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class JoinImportDB : RemoteDB, IJoinImportDB
    {
        /// <summary>
        /// �����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public JoinImportDB()
            : base("PMKHN07614R", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork", "JoinPartsURF")
        {
        }

        # region [Import]
        /// <summary>
        /// �����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="importWorkList">�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        public int Import(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �C���|�[�g����
                status = this.ImportProc(processKbn, ref importWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="objectImportWorkList">�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R���N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        private int ImportProc(Int32 processKbn, ref object objectImportWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            ArrayList importWorkList = objectImportWorkList as ArrayList;

            // �ǉ����X�g
            ArrayList addList = new ArrayList();
            // �X�V���X�g
            ArrayList updList = new ArrayList();

            try
            {
                // �����}�X�^(���[�U�[�o�^)��DB�����[�g�N���X
                JoinPartsUDB joinPartsUDB = new JoinPartsUDB();

                ArrayList joinPartsUArray = new ArrayList();

                JoinPartsUWork joinPartsUWork = new JoinPartsUWork();

                joinPartsUWork.EnterpriseCode = ((JoinPartsUWork)importWorkList[0]).EnterpriseCode;

                // �S�ăf�[�^�̌�������
                joinPartsUDB.Search(ref joinPartsUArray, joinPartsUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection, ref sqlTransaction);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Dictionary�̍쐬
                Dictionary<JoinSearchUImportWorkWrap, JoinPartsUWork> dict = new Dictionary<JoinSearchUImportWorkWrap, JoinPartsUWork>();

                foreach (JoinPartsUWork work in joinPartsUArray)
                {
                    JoinSearchUImportWorkWrap warp = new JoinSearchUImportWorkWrap(work);
                    dict.Add(warp, work);
                }

                foreach (JoinPartsUWork importWork in importWorkList)
                {
                    JoinSearchUImportWorkWrap importWarp = new JoinSearchUImportWorkWrap(importWork);

                    if (!dict.ContainsKey(importWarp))
                    {
                        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                        addList.Add(ConvertToImportWork(importWork, null, false));
                    }
                    else
                    {
                        // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                        updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
                    }
                }

                // �Ǎ�����
                readCnt = importWorkList.Count;

                // �R���N�V�����ƃg�����U�N�V����
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                 if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �����敪���u�ǉ��v�̏ꍇ
                     if (processKbn == 1)
                     {
                         status = joinPartsUDB.Write(ref addList, ref sqlConnection, ref sqlTransaction);

                         if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                         {
                             addCnt = addList.Count;
                         }
                     }
                     else if (processKbn == 2)
                     {
                         // �����敪���u�X�V�v�̏ꍇ

                         status = joinPartsUDB.Write(ref updList, ref sqlConnection, ref sqlTransaction);

                         if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                         {
                             updCnt = updList.Count;
                         }
                     }
                     else
                     {
                         // �����敪���u�ǉ��X�V�v�̏ꍇ
                         ArrayList addUpdList = new ArrayList();

                         if (addList.Count > 0)
                         {
                             addUpdList.AddRange(addList.GetRange(0, addList.Count));
                         }
                         if (updList.Count > 0)
                         {
                             addUpdList.AddRange(updList.GetRange(0, updList.Count));
                         }

                         status = joinPartsUDB.Write(ref addUpdList, ref sqlConnection, ref sqlTransaction);

                         if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                         {
                             addCnt = addList.Count;
                             updCnt = updList.Count;
                         }
                     }

                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null)
                    {
                        readCnt = 0;
                        addCnt = 0;
                        updCnt = 0;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (SqlException ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private JoinPartsUWork ConvertToImportWork(JoinPartsUWork csvWork, JoinPartsUWork searchWork, bool isUpdFlg)
        {
            JoinPartsUWork importWork = new JoinPartsUWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                  // ��ƃR�[�h
            importWork.JoinDispOrder = csvWork.JoinDispOrder;                       // �����\������
            importWork.JoinSourceMakerCode = csvWork.JoinSourceMakerCode;           // ���������[�J�[�R�[�h
            importWork.JoinSourPartsNoWithH = csvWork.JoinSourPartsNoWithH;         // �������i��(�|�t���i��)
            importWork.JoinSourPartsNoNoneH = csvWork.JoinSourPartsNoNoneH;         // �������i��(�|�����i��)
            importWork.JoinDestMakerCd = csvWork.JoinDestMakerCd;                   // �����惁�[�J�[�R�[�h
            importWork.JoinDestPartsNo = csvWork.JoinDestPartsNo;                   // ������i��(�|�t���i��)
            importWork.JoinQty = csvWork.JoinQty;                                   // �����p�s�x
            importWork.JoinSpecialNote = csvWork.JoinSpecialNote;               // �����K�i�E���L����
            return importWork;
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion

        #region �����������I�u�W�F�N�g
        /// <summary>
        /// �����������I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������I�u�W�F�N�g�ł��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        class JoinSearchUImportWorkWrap
        {
            #region Public Field
            public JoinPartsUWork joinWork;
            #endregion

            #region �N���X�R���X�g���N�^
            /// <summary>
            /// �����������I�u�W�F�N�g
            /// </summary>
            /// <remarks>
            /// <br>Note       : �����������I�u�W�F�N�g���擾���܂��B</br>
            /// <br>Programmer : ���M</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public JoinSearchUImportWorkWrap(JoinPartsUWork joinWork)
            {
                this.joinWork = joinWork;
            }
            #endregion

            #region �����������I�u�W�F�N�g�̃C�R�[���̔�r
            /// <summary>
            /// �����������I�u�W�F�N�g�̃C�R�[���̔�r
            /// </summary>
            /// <param name="obj">�����������I�u�W�F�N�g</param>
            /// <returns>��r����</returns>
            /// <remarks>
            /// <br>Note       : �����������I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
            /// <br>Programmer : ���M</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public override bool Equals(object obj)
            {
                JoinSearchUImportWorkWrap target = obj as JoinSearchUImportWorkWrap;
                if (target == null) return false;
                // ���������[�J�[�R�[�h�A�������i��(�|�t���i��)�A�����惁�[�J�[�R�[�h�A������i��(�|�t���i��)
                // �������ꍇ�A�������I�u�W�F�N�g�̓C�R�[���ɂ���B
                return target.joinWork.EnterpriseCode == joinWork.EnterpriseCode
                         && target.joinWork.JoinSourceMakerCode == joinWork.JoinSourceMakerCode
                         && target.joinWork.JoinSourPartsNoWithH == joinWork.JoinSourPartsNoWithH
                         && target.joinWork.JoinDestMakerCd == joinWork.JoinDestMakerCd
                         && target.joinWork.JoinDestPartsNo == joinWork.JoinDestPartsNo;
            }
            #endregion

            #region �����������I�u�W�F�N�g�̃n�V�R�[�h
            /// <summary>
            /// �����������I�u�W�F�N�g�̃n�V�R�[�h
            /// </summary>
            /// <returns>�n�V�R�[�h</returns>
            /// <remarks>
            /// <br>Note       : �����������I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
            /// <br>Programmer : ���M</br>
            /// <br>Date       : 2009.05.15</br>
            /// </remarks>
            public override int GetHashCode()
            {
                return joinWork.EnterpriseCode.GetHashCode()
                         + joinWork.JoinSourceMakerCode.GetHashCode()
                         + joinWork.JoinSourPartsNoWithH.GetHashCode()
                         + joinWork.JoinDestMakerCd.GetHashCode()
                         + joinWork.JoinDestPartsNo.GetHashCode();
            }
            #endregion
        }
        #endregion
    }
}
