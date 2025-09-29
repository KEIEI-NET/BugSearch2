//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TBO�����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : TBO�����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
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
    /// TBO�����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TBOSearchUImportDB : RemoteDB, ITBOSearchUImportDB
    {
        /// <summary>
        /// TBO�����}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public TBOSearchUImportDB()
            : base("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork", "TBOSearchURF")
        {
        }

        # region [Import]
        /// <summary>
        /// TBO�����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="importWorkList">�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���w�q</br>
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
        /// TBO�����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="importWorkList">�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R���N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        private int ImportProc(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            ArrayList tboSearchUList = new ArrayList();
            ArrayList paraList = new ArrayList();

            // TBO������DB�����[�g�N���X
            TBOSearchUDB TBOSearchUDB = new TBOSearchUDB();

            try
            {
                // �����p�����[�^�̐ݒ�
                ArrayList importWorkArray = importWorkList as ArrayList;
                if (importWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    TBOSearchUWork paraTBOSearchUWork = new TBOSearchUWork();
                    paraTBOSearchUWork.EnterpriseCode = ((TBOSearchUWork)importWorkArray[0]).EnterpriseCode;
                    paraList.Add(paraTBOSearchUWork);
                }

                // �S�ăf�[�^�̌�������
                TBOSearchUDB.Search(ref tboSearchUList, paraList, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection, ref sqlTransaction);
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Dictionary�̍쐬
                Dictionary<TBOSearchUImportWorkWrap, TBOSearchUWork> dict = new Dictionary<TBOSearchUImportWorkWrap, TBOSearchUWork>();
                foreach (TBOSearchUWork work in tboSearchUList)
                {
                    TBOSearchUImportWorkWrap warp = new TBOSearchUImportWorkWrap(work);
                    dict.Add(warp, work);
                }

                // �ǉ����X�g
                ArrayList addList = new ArrayList();
                // �X�V���X�g
                ArrayList updList = new ArrayList();

                foreach (TBOSearchUWork importWork in importWorkArray)
                {
                    TBOSearchUImportWorkWrap importWarp = new TBOSearchUImportWorkWrap(importWork);

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
                readCnt = importWorkArray.Count;
                
                // �R���N�V�����ƃg�����U�N�V����
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                // �����敪���u�ǉ��v�̏ꍇ
                if (processKbn == 1)
                {
                    if (addList != null && addList.Count > 0)
                    {
                        // �o�^����
                        status = TBOSearchUDB.Write(ref addList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                        }
                    }
                }
                // �����敪���u�X�V�v�̏ꍇ
                else if (processKbn == 2)
                {
                    if (updList != null && updList.Count > 0)
                    {
                        // �X�V����
                        status = TBOSearchUDB.Write(ref updList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            updCnt = updList.Count;
                        }
                    }
                }
                // �����敪���u�ǉ��X�V�v�̏ꍇ
                else
                {
                    // �o�^�X�V���X�g�̍쐬
                    ArrayList addUpdList = new ArrayList();
                    if (addList.Count > 0)
                    {
                        addUpdList.AddRange(addList.GetRange(0, addList.Count));
                    }
                    if (updList.Count > 0)
                    {
                        addUpdList.AddRange(updList.GetRange(0, updList.Count));
                    }
                    if (addUpdList.Count > 0)
                    {
                        // �o�^�X�V����
                        status = TBOSearchUDB.Write(ref addUpdList, ref sqlConnection, ref sqlTransaction);
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private TBOSearchUWork ConvertToImportWork(TBOSearchUWork csvWork, TBOSearchUWork searchWork, bool isUpdFlg)
        {
            TBOSearchUWork importWork = new TBOSearchUWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // �_���폜�敪
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // ��ƃR�[�h
            importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BL���i�R�[�h
            importWork.EquipGenreCode = csvWork.EquipGenreCode;                     // ��������
            importWork.EquipName = csvWork.EquipName;                               // ��������
            importWork.CarInfoJoinDispOrder = csvWork.CarInfoJoinDispOrder;         // �ԗ������\������
            importWork.JoinDestMakerCd = csvWork.JoinDestMakerCd;                   // �����惁�[�J�[�R�[�h
            importWork.JoinDestPartsNo = csvWork.JoinDestPartsNo;                   // ������i��(�|�t���i��)
            importWork.JoinQty = csvWork.JoinQty;                                   // �����p�s�x
            importWork.EquipSpecialNote = csvWork.EquipSpecialNote;                 // �����K�i�E���L����
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
        /// <br>Programmer : ���w�q</br>
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
    }

    #region TBO�������I�u�W�F�N�g
    /// <summary>
    /// TBO�������I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO�������I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class TBOSearchUImportWorkWrap
    {
        #region Public Field
        public TBOSearchUWork tboWork;
        #endregion

        #region �N���X�R���X�g���N�^
        /// <summary>
        /// TBO�������I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : TBO�������I�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public TBOSearchUImportWorkWrap(TBOSearchUWork tboWork)
        {
            this.tboWork = tboWork;
        }
        #endregion

        #region TBO�������I�u�W�F�N�g�̃C�R�[���̔�r
        /// <summary>
        /// TBO�������I�u�W�F�N�g�̃C�R�[���̔�r
        /// </summary>
        /// <param name="obj">TBO�������I�u�W�F�N�g</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : TBO�������I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            TBOSearchUImportWorkWrap target = obj as TBOSearchUImportWorkWrap;
            if (target == null) return false;
            // �������ށA�������́A�����惁�[�J�[�R�[�h�A������i��(�|�t���i��)
            // �������ꍇ�ATBO�������I�u�W�F�N�g�̓C�R�[���ɂ���B
            return target.tboWork.EnterpriseCode == tboWork.EnterpriseCode
                     && target.tboWork.EquipGenreCode == tboWork.EquipGenreCode
                     && target.tboWork.EquipName == tboWork.EquipName
                     && target.tboWork.JoinDestMakerCd == tboWork.JoinDestMakerCd
                     && target.tboWork.JoinDestPartsNo == tboWork.JoinDestPartsNo;
        }
        #endregion

        #region TBO�������I�u�W�F�N�g�̃n�V�R�[�h
        /// <summary>
        /// TBO�������I�u�W�F�N�g�̃n�V�R�[�h
        /// </summary>
        /// <returns>�n�V�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : TBO�������I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return tboWork.EnterpriseCode.GetHashCode()
                     + tboWork.EquipGenreCode.GetHashCode()
                     + tboWork.EquipName.GetHashCode()
                     + tboWork.JoinDestMakerCd.GetHashCode()
                     + tboWork.JoinDestPartsNo.GetHashCode();
        }
        #endregion
    }
    #endregion
}
