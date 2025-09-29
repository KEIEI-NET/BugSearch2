using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �A�v���P�[�V���� ���\�[�X�ɑ΂��郍�b�N�@�\��L���� RemoteDB �N���X�ł��B
    /// </summary>
    /// <remarks>
    /// �{�N���X�̓A�v���P�[�V���� ���\�[�X���b�N���s���ۂɃC���X�^���X�����ĊY�����\�b�h��
    /// ���s���Ă��\���܂��񂵁ARemoteDB �̑ւ��Ɍp�����Ƃ��Ďw�肵�ĊY�����\�b�h�����s
    /// ���Ă��\���܂���B
    /// <br></br>
    /// <br>Update Note: 2010/08/16  22018 ��� ���b  �������b�N�@�\�̒ǉ��ɔ����ύX�B</br>
    /// <br></br>
    /// </remarks>
    public partial class RemoteWithAppLockDB : RemoteDB
    {
        # region [�V�F�A�`�F�b�N�֘A]

        /// <summary>
        /// �V�F�A�`�F�b�N���s���܂��B
        /// </summary>
        /// <param name="info">ShareCheckInfo ���w�肵�܂�</param>
        /// <param name="mode">�V�F�A�`�F�b�N�̃��b�N or �����[�X���w�肵�܂�</param>
        /// <param name="connection">DB�ڑ������w�肵�܂�</param>
        /// <param name="transaction">�g�����U�N�V���������w�肵�܂�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// ShareCheckKey �����X�g�����ēn�����ɂ���āA�����̋��_�R�[�h��q�ɃR�[�h�œ����Ƀ��b�N�������s���܂��B
        /// �A���d�������f�[�^�▵�����Ă���g�ݍ��킹�� ShareCheckKey ���Z�b�g�����ꍇ�̓���͕ۏႵ�Ă��܂���B
        /// ��F�����ƃR�[�h�ɂ������ƃ��b�N�Ƌ��_���b�N�̑g�ݍ��킹 �� �m�f
        /// �@�@�����ƃR�[�h�ɂ����鋒�_���b�N�Ƒq�Ƀ��b�N�̑g�ݍ��킹 �� �n�j etc.
        /// </remarks>
        public int ShareCheck(ShareCheckInfo info, LockControl mode, SqlConnection connection, SqlTransaction transaction)
        {
            return this.ShareCheckProc(info, mode, connection, transaction);
        }

        /// <summary>
        /// �V�F�A�`�F�b�N���s���܂�
        /// </summary>
        /// <param name="info">������ ShareCheckKey ���i�[���� ShareCheckKeyList ���w�肵�܂�</param>
        /// <param name="mode">�V�F�A�`�F�b�N�̃��b�N or �����[�X���w�肵�܂�</param>
        /// <param name="connection">DB�ڑ������w�肵�܂�</param>
        /// <param name="transaction">�g�����U�N�V���������w�肵�܂�</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        private int ShareCheckProc(ShareCheckInfo info, LockControl mode, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �V�F�A�`�F�b�N���ʂ�S��"���s"�ŏ���������
            info.Keys.SetKeyResult(ShareCheckResult.Failure, delegate(ShareCheckKey item) { return true; });

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            bool errflg = false;

            # region [�p�����[�^�`�F�b�N]

            if (info.Keys.Count == 0)
            {
                errmsg += ": �V�F�A�`�F�b�N�L�[�����ݒ�ł�.";
                errflg = true;
            }
            else
            {
                info.Keys.Sort();  // ��Ɓ����_���q�Ƀ��b�N�̏��ɕ��ѕς���(�ڍׂ� ShareCheckKey.CompareTo ���Q��)

                # region [���ݒ荀�ڂ̃`�F�b�N]

                // ��ƃR�[�h�����ݒ�̍��ڂ�����
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     { return string.IsNullOrEmpty(item.EnterpriseCode); }))
                {
                    errmsg += ": ��ƃR�[�h�����ݒ�̕�������܂�.";
                    errflg = true;
                }

                // �V�F�A�`�F�b�N�^�C�v�����ݒ�̍��ڂ�����
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     { return item.Type == ShareCheckType.None; }))
                {
                    errmsg += ": �V�F�A�`�F�b�N�^�C�v�����ݒ�̕�������܂�.";
                    errflg = true;
                }

                // ���_���b�N���ɋ��_�R�[�h�����ݒ�̍��ڂ�����
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     {
                                         return item.Type == ShareCheckType.Section &&
                                                string.IsNullOrEmpty(item.SectionCode);
                                     }))
                {
                    errmsg += ": ���_�R�[�h�����ݒ�̕�������܂�.";
                    errflg = true;
                }

                // �q�Ƀ��b�N���ɑq�ɃR�[�h�����ݒ�̍��ڂ�����
                if (info.Keys.Exists(delegate(ShareCheckKey item)
                                     {
                                         return item.Type == ShareCheckType.WareHouse &&
                                                string.IsNullOrEmpty(item.WarehouseCode);
                                     }))
                {
                    errmsg += ": �q�ɃR�[�h�����ݒ�̕�������܂�.";
                    errflg = true;
                }

                // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                if ( info.Keys.Exists( delegate( ShareCheckKey item )
                                        {
                                            //return ((item.Type == ShareCheckType.AddUpSlip || item.Type == ShareCheckType.AddUpUpdate) &&//DEL yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��
                                            //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                                            return ((item.Type == ShareCheckType.AddUpSlip || item.Type == ShareCheckType.AddUpUpdate
                                                || item.Type == ShareCheckType.SupUpSlip || item.Type == ShareCheckType.SupUpUpdate) &&
                                            //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                                                    (item.TotalDay == 0 || item.AddUpUpdDate == 0)); //���_��ALL�̉\�����L��̂Ń`�F�b�N���Ȃ��B
                                        } ) )
                {
                    errmsg += ": �����W�v���b�N���������ݒ�̕�������܂�.";
                    errflg = true;
                }
                // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                # endregion

                # region [�g�ݍ��킹�`�F�b�N]

                // ��ƃ��b�N���w�肳��Ă���L�[�̈ꗗ���擾����
                List<ShareCheckKey> EnterpriseLocks = info.Keys.FindAll(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; });

                foreach (ShareCheckKey key in EnterpriseLocks)
                {
                    // ��ƃ��b�N���w�肳��Ă���A����̊�ƃR�[�h�������_�E�q�Ƀ��b�N�̈ꗗ���擾����
                    List<ShareCheckKey> illegals = info.Keys.FindAll(delegate(ShareCheckKey item)
                                                                     {
                                                                         return item.EnterpriseCode == key.EnterpriseCode &&
                                                                                item.Type != ShareCheckType.Enterprise;
                                                                     });

                    foreach (ShareCheckKey illegal in illegals)
                    {
                        // ���������g�ݍ��킹�Ȃ̂ō폜����(�G���[�Ƃ͂��Ȃ�)
                        info.Keys.Remove(illegal);
                    }
                }

                # endregion
            }

            if (connection == null)
            {
                errmsg += ": DB�ڑ���񂪖��ݒ�ł�.";
                errflg = true;
            }

            if (transaction == null)
            {
                errmsg += ": �g�����U�N�V������񂪖��ݒ�ł�.";
                errflg = true;
            }

            # endregion

            if (errflg)
            {
                // �p�����[�^�~�X���L�����ꍇ�̓��O�ɗ����ďI��(ST = 1000)
                this.WriteErrorLog(errmsg, status);
            }
            else
            {
                SqlCommand command = null;
                SqlDataReader reader = null;

                try
                {
                    // ���b�N���̂݃��b�N��Ԃ̊m�F���s��
                    if (mode == LockControl.Locke)
                    {
                        # region [��ƃR�[�h��S�Ď擾���� �� WHERE�吶���ɕK�v]

                        List<string> EnterpriseCodes = new List<string>();

                        foreach (ShareCheckKey key in info.Keys)
                        {
                            if (!EnterpriseCodes.Exists(delegate(string EnterpriseCode) { return EnterpriseCode == key.EnterpriseCode; }))
                            {
                                EnterpriseCodes.Add(key.EnterpriseCode);
                            }
                        }

                        # endregion

                        # region [���b�N��Ԃ��擾����SELECT��]

                        string sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        // --- UPD m.suzuki 2010/08/16 ---------->>>>>
                        //sqlText += "  SUBSTRING(locks.resource_description,  4,16) AS ENTERPRISE" + Environment.NewLine;
                        //sqlText += " ,SUBSTRING(locks.resource_description, 20, 3) AS TYPE" + Environment.NewLine;
                        //sqlText += " ,SUBSTRING(locks.resource_description, 23, 6) AS CODE" + Environment.NewLine;
                        sqlText += "  SUBSTRING(locks.resource_description,  4,16) AS ENTERPRISE" + Environment.NewLine;
                        sqlText += " ,SUBSTRING(locks.resource_description, 20, 2) AS TYPE" + Environment.NewLine;
                        sqlText += " ,SUBSTRING(locks.resource_description, 22, 4) AS CODE" + Environment.NewLine;
                        // --- UPD m.suzuki 2010/08/16 ----------<<<<<
                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                        sqlText += " ,SUBSTRING(locks.resource_description, 26, 2) AS TOTALDAY" + Environment.NewLine;
                        sqlText += " ,SUBSTRING(locks.resource_description, 28, 8) AS ADDUPUPDDATE" + Environment.NewLine;
                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  sys.dm_tran_locks AS locks" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  locks.resource_type = 'APPLICATION'" + Environment.NewLine;

                        foreach (string EnterpriseCode in EnterpriseCodes)
                        {
                            sqlText += "  AND locks.resource_description LIKE '0:$[" + EnterpriseCode + "%' escape '$'" + Environment.NewLine;
                        }

                        command = new SqlCommand(sqlText, connection, transaction);

# if DEBUG
                        //Console.Clear();
                        //Console.WriteLine(NSDebug.GetSqlCommand(command));
# endif

                        # endregion

                        for (int cnt = 0; cnt < info.RetryCount; cnt++)
                        {
                            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                            bool breakThroughFlag = false;
                            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                            reader = command.ExecuteReader();

                            # region [���b�N��Ԃ��i�[]

                            List<ShareCheckKey> lockState = new List<ShareCheckKey>();

                            try
                            {
                                while (reader.Read())
                                {
                                    ShareCheckKey wrkKey = new ShareCheckKey();

                                    wrkKey.EnterpriseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ENTERPRISE"));  // ��ƃR�[�h
                                    wrkKey.TypeText = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("TYPE"));              // �V�F�A�`�F�b�N�^�C�v

                                    if (wrkKey.Type == ShareCheckType.Section)
                                    {
                                        wrkKey.SectionCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("CODE"));      // ���_�R�[�h

                                    }
                                    else if (wrkKey.Type == ShareCheckType.WareHouse)
                                    {
                                        wrkKey.WarehouseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("CODE"));     // �q�ɃR�[�h
                                    }
                                    // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                                    //else if ( wrkKey.Type == ShareCheckType.AddUpSlip || wrkKey.Type == ShareCheckType.AddUpUpdate )//DEL yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
                                    //--- ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                                    else if (wrkKey.Type == ShareCheckType.AddUpSlip || wrkKey.Type == ShareCheckType.AddUpUpdate
                                    || wrkKey.Type == ShareCheckType.SupUpSlip || wrkKey.Type == ShareCheckType.SupUpUpdate)
                                    //--- ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                                    {
                                        wrkKey.SectionCode = SqlDataMediator.SqlGetString( reader, reader.GetOrdinal( "CODE" ) );      // ���_�R�[�h
                                        wrkKey.TotalDay = ToInt( SqlDataMediator.SqlGetString( reader, reader.GetOrdinal( "TOTALDAY" ) ) );      // ����
                                        wrkKey.AddUpUpdDate = ToInt( SqlDataMediator.SqlGetString( reader, reader.GetOrdinal( "ADDUPUPDDATE" ) ) );      // �����X�V��
                                    }
                                    // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                                    lockState.Add(wrkKey);
                                }
                            }
                            finally
                            {
                                if (reader != null)
                                {
                                    if (!reader.IsClosed)
                                    {
                                        reader.Close();
                                    }

                                    reader.Dispose();
                                    reader = null;
                                }
                            }
                            # endregion

                            # region [�V�F�A�`�F�b�N�^�C�v�ɉ������`�F�b�N����]

                            if (lockState.Count > 0)
                            {
                                foreach (ShareCheckKey key in info.Keys)
                                {
                                    switch (key.Type)
                                    {
                                        # region [����ƃ��b�N �`�F�b�N]
                                        case ShareCheckType.Enterprise:
                                            {
                                                // ���ꂩ�̃��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if (lockState.Count > 0)
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }

                                                break;
                                            }
                                        # endregion

                                        # region [�����_���b�N �`�F�b�N]
                                        case ShareCheckType.Section:
                                            {
                                                // ��ƃ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // ���ꋒ�_���b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                          {
                                                                              return item.Type == ShareCheckType.Section &&
                                                                                     item.SectionCode == key.SectionCode;
                                                                          }))
                                                {
                                                    key.Result = ShareCheckResult.SectionLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }

                                                break;
                                            }
                                        # endregion

                                        # region [���q�Ƀ��b�N �`�F�b�N]
                                        case ShareCheckType.WareHouse:
                                            {
                                                // ��ƃ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // ����q�Ƀ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                          {
                                                                              return item.Type == ShareCheckType.WareHouse &&
                                                                                     item.WarehouseCode == key.WarehouseCode;
                                                                          }))
                                                {
                                                    key.Result = ShareCheckResult.WareHouseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }

                                                break;
                                            }
                                        # endregion

                                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                                        # region [���������b�N �`�F�b�N]
                                        // ���������b�N�i�`�[���j
                                        case ShareCheckType.AddUpSlip:
                                            {
                                                // ��ƃ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if ( lockState.Exists( delegate( ShareCheckKey item ) { return item.Type == ShareCheckType.Enterprise; } ) )
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // �Ή�����������b�N�i�W�v���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpUpdate &&
                                                                                    (item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" || item.SectionCode == key.SectionCode) &&
                                                                                    (item.TotalDay == 99 || item.TotalDay == key.TotalDay) &&
                                                                                    item.AddUpUpdDate >= key.AddUpUpdDate);
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;

                                                    // ���Ώۊ��Ԃ��W�v���Ȃ̂Ń��g���C������break������
                                                    breakThroughFlag = true;
                                                }
                                                // ��������Œ������b�N�i�`�[���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���istatus��TimeOut�ɂ��鎖�Ń��g���C������B�A���ʏ�͓`�[���s���m�͋��_���b�N���|��͂��Ȃ̂ŕs�v�B�j
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpSlip &&
                                                                                    item.SectionCode == key.SectionCode &&
                                                                                    item.TotalDay == key.TotalDay &&
                                                                                    item.AddUpUpdDate == key.AddUpUpdDate);
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        // ���������b�N�i�W�v���j
                                        case ShareCheckType.AddUpUpdate:
                                            {
                                                // ��ƃ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if ( lockState.Exists( delegate( ShareCheckKey item ) { return item.Type == ShareCheckType.Enterprise; } ) )
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // ���ꋒ�_�Œ������b�N�i�W�v���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpUpdate &&
                                                                                    (item.SectionCode == key.SectionCode ||
                                                                                     item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" ||
                                                                                     key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000"));
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // �Ή�����������b�N�i�`�[���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if ( lockState.Exists( delegate( ShareCheckKey item )
                                                                        {
                                                                            return (item.Type == ShareCheckType.AddUpSlip &&
                                                                                    (item.SectionCode == key.SectionCode || key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000") &&
                                                                                    (item.TotalDay == key.TotalDay || key.TotalDay == 99) &&
                                                                                    item.AddUpUpdDate <= key.AddUpUpdDate);
                                                                        } ) )
                                                {
                                                    key.Result = ShareCheckResult.AddUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                                        // ���������b�N�i�`�[���j
                                        case ShareCheckType.SupUpSlip:
                                            {
                                                // ��ƃ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // �Ή�����������b�N�i�W�v���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpUpdate &&
                                                                                    (item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" || item.SectionCode == key.SectionCode) &&
                                                                                    (item.TotalDay == 99 || item.TotalDay == key.TotalDay) &&
                                                                                    item.AddUpUpdDate >= key.AddUpUpdDate);
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;

                                                    // ���Ώۊ��Ԃ��W�v���Ȃ̂Ń��g���C������break������
                                                    breakThroughFlag = true;
                                                }
                                                // ��������Œ������b�N�i�`�[���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���istatus��TimeOut�ɂ��鎖�Ń��g���C������B�A���ʏ�͓`�[���s���m�͋��_���b�N���|��͂��Ȃ̂ŕs�v�B�j
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpSlip &&
                                                                                    item.SectionCode == key.SectionCode &&
                                                                                    item.TotalDay == key.TotalDay &&
                                                                                    item.AddUpUpdDate == key.AddUpUpdDate);
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        // ���������b�N�i�W�v���j
                                        case ShareCheckType.SupUpUpdate:
                                            {
                                                // ��ƃ��b�N���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                if (lockState.Exists(delegate(ShareCheckKey item) { return item.Type == ShareCheckType.Enterprise; }))
                                                {
                                                    key.Result = ShareCheckResult.EnterpriseLockFailure;

                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // ���ꋒ�_�Œ������b�N�i�W�v���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpUpdate &&
                                                                                    (item.SectionCode == key.SectionCode ||
                                                                                     item.SectionCode == string.Empty || item.SectionCode == "00" || item.SectionCode == "0000" ||
                                                                                     key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000"));
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpUpdateLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                // �Ή�����������b�N�i�`�[���j���|���Ă���ꍇ�̓��b�N�s�Ƃ���
                                                else if (lockState.Exists(delegate(ShareCheckKey item)
                                                                        {
                                                                            return (item.Type == ShareCheckType.SupUpSlip &&
                                                                                    (item.SectionCode == key.SectionCode || key.SectionCode == string.Empty || key.SectionCode == "00" || key.SectionCode == "0000") &&
                                                                                    (item.TotalDay == key.TotalDay || key.TotalDay == 99) &&
                                                                                    item.AddUpUpdDate <= key.AddUpUpdDate);
                                                                        }))
                                                {
                                                    key.Result = ShareCheckResult.SupUpSlipLockFailure;
                                                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                                                }
                                                break;
                                            }
                                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                                        # endregion
                                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                                    }

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                                    {
                                        break;  // �`�F�b�N�ɖ�肪�L�����ꍇ�͑����g���C�����Ɉڍs����
                                    }
                                }
                            }

                            # endregion

                            if (status != (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                            {
                                // �`�F�b�N�ɖ�肪������΃��g���C�p�̃��[�v���甲����
                                break;
                            }
                            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                            // ���g���C�s�v�Ɣ��f�����ꍇ
                            if ( breakThroughFlag == true )
                            {
                                break;
                            }
                            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

                            System.Threading.Thread.Sleep(info.TimeOut);  // �w��_�b�ҋ@����
                        }
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        int timeout = (mode == LockControl.Locke) ? info.TimeOut : 0;

                        foreach (ShareCheckKey key in info.Keys)
                        {
                            // ���b�N�E�����[�X���s��
                            // �������������b�N�Ɏ��s�����ꍇ�́A�Ăяo�����ɂăg�����U�N�V���������[���o�b�N���ĖႤ
                            status = this.ExclusiveLockControl(mode, connection, transaction, key.ResourceName, timeout);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �V�F�A�`�F�b�N����
                                key.Result = ShareCheckResult.Success;
                            }
                            else
                            {
                                // �V�F�A�`�F�b�N�^�C���A�E�g
                                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                                {
                                    # region [�^�C�v�ɉ��������ʂ�ݒ�]
                                    switch (key.Type)
                                    {
                                        case ShareCheckType.Enterprise:
                                            {
                                                // ��ƃ��b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.EnterpriseLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.Section:
                                            {
                                                // ���_���b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.SectionLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.WareHouse:
                                            {
                                                // �q�Ƀ��b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.WareHouseLockFailure;
                                                break;
                                            }
                                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                                        case ShareCheckType.AddUpSlip:
                                            {
                                                // �������b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.AddUpSlipLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.AddUpUpdate:
                                            {
                                                // �������b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.AddUpUpdateLockFailure;
                                                break;
                                            }
                                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                                        case ShareCheckType.SupUpSlip:
                                            {
                                                // �������b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.SupUpSlipLockFailure;
                                                break;
                                            }
                                        case ShareCheckType.SupUpUpdate:
                                            {
                                                // �������b�N�ɂ�鎸�s
                                                key.Result = ShareCheckResult.SupUpUpdateLockFailure;
                                                break;
                                            }
                                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                                    }
                                    # endregion
                                }

                                // �P�ł����b�N�Ɏ��s�����ꍇ�͂��̎��_�ŏI������
                                break;
                            }
                        }
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �V�F�A�`�F�b�N���ʂ�"���ݒ�"��������"����"�ƂȂ��Ă��镨�̂�"���s"�ɂ���
                        info.Keys.SetKeyResult(ShareCheckResult.Failure, delegate(ShareCheckKey item)
                                                                         {
                                                                             return item.Result == ShareCheckResult.None ||
                                                                                    item.Result == ShareCheckResult.Success;
                                                                         });
                    }
                }
                catch (SqlException ex)
                {
                    status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    this.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                        reader.Dispose();
                    }

                    if (command != null)
                    {
                        command.Cancel();
                        command.Dispose();
                    }
                }
            }

            // �������ʂ��Q�l�ɁA�߂�l��ύX����
            ShareCheckKey tmpKey = null;
            info.Keys.GetIntegratedResult(out tmpKey);

            if (tmpKey != null)
            {
                switch (tmpKey.Result)
                {
                    case ShareCheckResult.EnterpriseLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.SectionLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.WareHouseLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT;
                            break;
                        }
                    // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                    case ShareCheckResult.AddUpUpdateLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.AddUpSlipLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT;
                            break;
                        }
                    // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                    case ShareCheckResult.SupUpUpdateLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT;
                            break;
                        }
                    case ShareCheckResult.SupUpSlipLockFailure:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT;
                            break;
                        }
                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                }
            }

            return status;
        }
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>
        /// �����񂩂琔�l�ϊ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
        # endregion
    }
}

namespace Broadleaf.Application.Remoting.ParamData
{
    # region [�V�F�A�`�F�b�N�^�C�v]

    /// <summary>
    /// �V�F�A�`�F�b�N�^�C�v���`���܂��B
    /// </summary>
    public enum ShareCheckType : int
    {
        /// <summary>���w��</summary>
        None = 0,
        /// <summary>��ƒP��</summary>
        Enterprise,
        /// <summary>���_�P��</summary>
        Section,
        /// <summary>�q�ɒP��</summary>
        // --- UPD m.suzuki 2010/08/16 ---------->>>>>
        //WareHouse
        WareHouse,
        // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>�����W�v(�`�[��)</summary>
        AddUpSlip,
        /// <summary>�����W�v(�W�v��)</summary>
        AddUpUpdate,
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
        // --- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C�� ---------->>>>>
        /// <summary>�����W�v(�d����)</summary>
        SupUpSlip,
        /// <summary>�����W�v(�W�v��)</summary>
        SupUpUpdate,
        // --- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C�� ----------<<<<<
    }

    # endregion

    # region [�V�F�A�`�F�b�N����]
    
    /// <summary>
    /// �V�F�A�`�F�b�N���ʂ��`���܂��B
    /// </summary>
    public enum ShareCheckResult : int
    {
        /// <summary>���w��</summary>
        None = 0,
        /// <summary>����</summary>        
        Success = 1,
        /// <summary>���s</summary>
        Failure = -1,
        /// <summary>�q�Ƀ��b�N�ɂ�鎸�s</summary>
        WareHouseLockFailure = -2,
        /// <summary>���_���b�N�ɂ�鎸�s</summary>
        SectionLockFailure = -3,
        /// <summary>��ƃ��b�N�ɂ�鎸�s</summary>
        // --- UPD m.suzuki 2010/08/16 ---------->>>>>
        //EnterpriseLockFailure = -4
        EnterpriseLockFailure = -4,
        // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>�����W�v���b�N�ɂ�鎸�s(�W�v�����|�������b�N)</summary>
        AddUpUpdateLockFailure = -5,
        /// <summary>�����W�v���b�N�ɂ�鎸�s(�`�[�����|�������b�N)</summary>
        AddUpSlipLockFailure = -6,
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<

        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
        /// <summary>�����W�v���b�N�ɂ�鎸�s(�W�v�����|�������b�N)</summary>
        SupUpUpdateLockFailure = -7,
        /// <summary>�����W�v���b�N�ɂ�鎸�s(�`�[�����|�������b�N)</summary>
        SupUpSlipLockFailure = -8,
        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
    }

    # endregion

    # region [�V�F�A�`�F�b�N���]

    /// <summary>
    /// �V�F�A�`�F�b�N�Ɋւ��L�[���ڂ��`���܂�
    /// </summary>
    [Serializable]
    public class ShareCheckKey : IComparable<ShareCheckKey>
    {
        private string _EnterpriseCode = string.Empty;
        private string _SectionCode = string.Empty;
        private string _WarehouseCode = string.Empty;
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        private int _TotalDay = 0;
        private int _AddUpUpdDate = 0;
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
        private ShareCheckType _Type = ShareCheckType.None;
        private ShareCheckResult _Result = ShareCheckResult.None;
        private Dictionary<ShareCheckType, string> TypeTextDic = null;

        /// <summary>��ƃR�[�h</summary>
        public string EnterpriseCode
        {
            get { return this._EnterpriseCode; }
            set { this._EnterpriseCode = value.Trim().PadLeft(16, '0'); }
        }

        /// <summary>���_�R�[�h</summary>
        public string SectionCode
        {
            get { return this._SectionCode; }
            // --- UPD m.suzuki 2010/08/16 ---------->>>>>
            //set { this._SectionCode = value.Trim().PadLeft(6, '0'); }
            set { this._SectionCode = value.Trim().PadLeft(4, '0'); }
            // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        }

        /// <summary>�q�ɃR�[�h</summary>
        public string WarehouseCode
        {
            get { return this._WarehouseCode; }
            // --- UPD m.suzuki 2010/08/16 ---------->>>>>
            //set { this._WarehouseCode = value.Trim().PadLeft(6, '0'); }
            set { this._WarehouseCode = value.Trim().PadLeft(4, '0'); }
            // --- UPD m.suzuki 2010/08/16 ----------<<<<<
        }

        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>����(DD)</summary>
        public int TotalDay
        {
            get { return _TotalDay; }
            set { _TotalDay = value; }
        }
        /// <summary>�����X�V��(YYYYMMDD)</summary>
        public int AddUpUpdDate
        {
            get { return _AddUpUpdDate; }
            set { _AddUpUpdDate = value; }
        }
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<

        /// <summary>�V�F�A�`�F�b�N�^�C�v</summary>
        public ShareCheckType Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }
       
        /// <summary>�V�F�A�`�F�b�N����</summary>
        public ShareCheckResult Result
        {
            get { return this._Result; }
            internal set { this._Result = value; }
        }

        /// <summary>�R���X�g���N�^</summary>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public ShareCheckKey()
        {
            this.TypeTextDic = new Dictionary<ShareCheckType, string>();

            // --- UPD m.suzuki 2010/08/16 ---------->>>>>
            //this.TypeTextDic.Add(ShareCheckType.None, "NON");
            //this.TypeTextDic.Add(ShareCheckType.Enterprise, "ENT");
            //this.TypeTextDic.Add(ShareCheckType.Section, "SEC");
            //this.TypeTextDic.Add(ShareCheckType.WareHouse, "WAR");
            this.TypeTextDic.Add( ShareCheckType.None, "NO" );
            this.TypeTextDic.Add( ShareCheckType.Enterprise, "EN" );
            this.TypeTextDic.Add( ShareCheckType.Section, "SE" );
            this.TypeTextDic.Add( ShareCheckType.WareHouse, "WA" );
            // --- UPD m.suzuki 2010/08/16 ----------<<<<<
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            this.TypeTextDic.Add( ShareCheckType.AddUpSlip, "AS" );
            this.TypeTextDic.Add( ShareCheckType.AddUpUpdate, "AU" );
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

            // --- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C�� ---------->>>>>
            this.TypeTextDic.Add(ShareCheckType.SupUpSlip, "SS");
            this.TypeTextDic.Add(ShareCheckType.SupUpUpdate, "SU");
            // --- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C�� ----------<<<<<
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <param name="type">�V�F�A�`�F�b�N�^�C�v</param>
        /// <param name="sectioncode">���_�R�[�h</param>
        /// <param name="warehousecode">�q�ɃR�[�h</param>
        public ShareCheckKey(string enterprisecode, ShareCheckType type, string sectioncode, string warehousecode)
            : this()
        {
            this.EnterpriseCode = enterprisecode;
            this.Type = type;
            this.SectionCode = (this.Type == ShareCheckType.Section) ? sectioncode : string.Empty;
            this.WarehouseCode = (this.Type == ShareCheckType.WareHouse) ? warehousecode : string.Empty;
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            this.TotalDay = 0;
            this.AddUpUpdDate = 0;
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<
            this.Result = ShareCheckResult.None;
        }
        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterprisecode"></param>
        /// <param name="type"></param>
        /// <param name="sectioncode"></param>
        /// <param name="warehousecode"></param>
        /// <param name="totalDay"></param>
        /// <param name="addUpUpdDate"></param>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public ShareCheckKey(string enterprisecode, ShareCheckType type, string sectioncode, string warehousecode, int totalDay, int addUpUpdDate)
            : this()
        {
            this.EnterpriseCode = enterprisecode;
            this.Type = type;
            //this.SectionCode = (this.Type == ShareCheckType.Section || this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate) ? sectioncode : string.Empty;//DEL yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
            this.SectionCode = (this.Type == ShareCheckType.Section || this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate) ? sectioncode : string.Empty;//ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
            this.WarehouseCode = (this.Type == ShareCheckType.WareHouse) ? warehousecode : string.Empty;
            //this.TotalDay = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate) ? totalDay : 0;//DEL yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
            this.TotalDay = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate) ? totalDay : 0;//ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
            //this.AddUpUpdDate = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate) ? addUpUpdDate : 0;//DEL yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
            this.AddUpUpdDate = (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate) ? addUpUpdDate : 0;//ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
            this.Result = ShareCheckResult.None;
        }
        // --- ADD m.suzuki 2010/08/16 ----------<<<<<

        /// <summary>
        /// �V�F�A�`�F�b�N�^�C�v��
        /// </summary>
        internal string TypeText
        {
            set
            {
                this.Type = ShareCheckType.None;
                try
                {
                    foreach (ShareCheckType type in this.TypeTextDic.Keys)
                    {
                        if (this.TypeTextDic[type].CompareTo(value) == 0)
                        {
                            this.Type = type;
                            break;
                        }
                    }
                }
                catch
                {
                    // �َE
                }
            }

            get
            {
                return this.TypeTextDic[this.Type];
            }
        }

        /// <summary>
        /// �V�F�A�`�F�b�N�p���\�[�X��
        /// </summary>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        internal string ResourceName
        {
            get
            {
                string rNm = string.Empty;

                if (this.Type != ShareCheckType.None)
                {
                    // --- UPD m.suzuki 2010/08/16 ---------->>>>>
                    //// ��ƃR�[�h(16��)�{����(3��)�{���_�E�q�ɃR�[�h(6��)
                    // ��ƃR�[�h(16��)�{����(2��)�{���_�E�q�ɃR�[�h(4��)�{[ ����(2��)�{���t(8��) ]
                    // --- UPD m.suzuki 2010/08/16 ----------<<<<<
                    rNm = this.EnterpriseCode + this.TypeText;

                    switch (this.Type)
                    {
                        case ShareCheckType.Enterprise:
                            {
                                // --- UPD m.suzuki 2010/08/16 ---------->>>>>
                                //rNm += "000000";
                                rNm += "0000";
                                // --- UPD m.suzuki 2010/08/16 ----------<<<<<
                                break;
                            }
                        case ShareCheckType.Section:
                            {
                                rNm += this.SectionCode;
                                break;
                            }
                        case ShareCheckType.WareHouse:
                            {
                                rNm += this.WarehouseCode;
                                break;
                            }
                        // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                        case ShareCheckType.AddUpSlip:
                        case ShareCheckType.AddUpUpdate:
                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                        case ShareCheckType.SupUpSlip:
                        case ShareCheckType.SupUpUpdate:
                        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                            {
                                rNm += this.SectionCode + this.TotalDay.ToString( "00" ) + this.AddUpUpdDate.ToString( "00000000" );
                                break;
                            }
                        // --- ADD m.suzuki 2010/08/16 ----------<<<<<
                    }
                }

                return rNm;
            }
        }

        /// <summary>
        /// ���݂̃I�u�W�F�N�g�𓯂��^�̕ʂ̃I�u�W�F�N�g�Ɣ�r���܂��B
        /// </summary>
        /// <param name="other">���̃I�u�W�F�N�g�Ɣ�r����I�u�W�F�N�g�B</param>
        /// <returns>int</returns>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public int CompareTo(ShareCheckKey other)
        {
            // ��ƃR�[�h�Ŕ�r
            int ret = this.EnterpriseCode.CompareTo(other.EnterpriseCode);

            if (ret == 0)
            {
                // �V�F�A�`�F�b�N�^�C�v�Ŕ�r
                ret = this.Type.CompareTo(other.Type);
            }

            if (ret == 0)
            {
                if (this.Type == ShareCheckType.Section)
                {
                    // ���_�R�[�h�Ŕ�r
                    ret = this.SectionCode.CompareTo(other.SectionCode);
                }
                else if (this.Type == ShareCheckType.WareHouse)
                {
                    // �q�ɃR�[�h�Ŕ�r
                    ret = this.WarehouseCode.CompareTo(other.WarehouseCode);
                }
                // --- ADD m.suzuki 2010/08/16 ---------->>>>>
                //else if ( this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate )//DEL yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
                else if (this.Type == ShareCheckType.AddUpSlip || this.Type == ShareCheckType.AddUpUpdate || this.Type == ShareCheckType.SupUpSlip || this.Type == ShareCheckType.SupUpUpdate)//ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
                {
                    // ���_�R�[�h�E�����E�����X�V���Ŕ�r
                    ret = this.SectionCode.CompareTo( other.SectionCode );
                    if ( ret == 0 )
                    {
                        ret = this.TotalDay.CompareTo( other.TotalDay );
                        if ( ret == 0 )
                        {
                            ret = this.AddUpUpdDate.CompareTo( other.AddUpUpdDate );
                        }
                    }
                }
                // --- ADD m.suzuki 2010/08/16 ----------<<<<<
            }

            return ret;
        }
    }

    /// <summary>
    /// �V�F�A�`�F�b�N�L�[���i�[����W�F�l���b�N�E�N���X
    /// </summary>
    public class ShareCheckKeyList : List<ShareCheckKey>
    {
        /// <summary>
        /// ShareCheckKeyList �̖����ɁA�w�肵���l������ ShareCheckKey ��ǉ����܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <param name="type">�V�F�A�`�F�b�N�^�C�v</param>
        /// <param name="sectioncode">���_�R�[�h</param>
        /// <param name="warehousecode">�q�ɃR�[�h</param>
        public void Add(string enterprisecode, ShareCheckType type, string sectioncode, string warehousecode)
        {
            base.Add(new ShareCheckKey(enterprisecode, type, sectioncode, warehousecode));
        }

        /// <summary>
        /// �����ɍ��v����V�F�A�`�F�b�N�L�[�̃V�F�A�`�F�b�N���ʂ��A�w�肳�ꂽ�l�ɐݒ肵�܂�
        /// </summary>
        /// <param name="value">�V�F�A�`�F�b�N����</param>
        /// <param name="match">��������</param>
        internal void SetKeyResult(ShareCheckResult value, Predicate<ShareCheckKey> match)
        {
            foreach (ShareCheckKey key in this.FindAll(match))
            {
                key.Result = value;
            }
        }

        /// <summary>
        /// ���X�̃V�F�A�`�F�b�N���ʂ��r���A�������ʂ��擾����
        /// </summary>
        /// <param name="key">�������ʂƓ������ʂ����ŏ���ShareCheckKey</param>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        public void GetIntegratedResult(out ShareCheckKey key)
        {
            key = null;

            List<ShareCheckResult> order = new List<ShareCheckResult>();
            order.Add(ShareCheckResult.None);                   // ��(�Ⴂ) ���ݒ�
            order.Add(ShareCheckResult.Success);                //          ����
            order.Add(ShareCheckResult.Failure);                //          ���s
            order.Add(ShareCheckResult.WareHouseLockFailure);   //          �q�Ƀ��b�N�ɂ�鎸�s
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            order.Add( ShareCheckResult.AddUpSlipLockFailure );   //        �����W�v���b�N�ɂ�鎸�s
            order.Add( ShareCheckResult.AddUpUpdateLockFailure ); //        �����W�v���b�N�ɂ�鎸�s
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<
            //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
            order.Add(ShareCheckResult.SupUpUpdateLockFailure);   //        �����W�v���b�N�ɂ�鎸�s
            order.Add(ShareCheckResult.SupUpSlipLockFailure); //            �����W�v���b�N�ɂ�鎸�s
            //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
            order.Add(ShareCheckResult.SectionLockFailure);     //          ���_���b�N�ɂ�鎸�s
            order.Add(ShareCheckResult.EnterpriseLockFailure);  // ��(����) ��ƃ��b�N�ɂ�鎸�s

            foreach (ShareCheckResult value in order)
            {
                ShareCheckKey tmpKey = this.Find(delegate(ShareCheckKey item) { return item.Result == value; });

                if (tmpKey != null)
                {
                    key = tmpKey;
                }
            }
        }
    }

    /// <summary>
    /// �V�F�A�`�F�b�N�Ɋւ���t�������`���܂�
    /// </summary>
    public class ShareCheckInfo
    {
        // �f�t�H���g�̃V�F�A�`�F�b�N�^�C���A�E�g���Ԃ��_�b�Ŏw�肷��
        private const int DEFAULT_SHARECHECK_TIMEOUT = 1000;  // 1�b

        // �f�t�H���g�̃V�F�A�`�F�b�N�m�F���g���C�񐔂��w�肷��
        private const int DEFAULT_SHARECHECK_RETRY = 5;       // 5��

        private ShareCheckKeyList _Keys = null;
        private int _RetryCount = 0;
        private int _TimeOut = 0;

        /// <summary>
        /// �V�F�A�`�F�b�N�L�[���w�肵�܂�
        /// </summary>
        public ShareCheckKeyList Keys
        {
            get
            {
                if (this._Keys == null)
                {
                    this._Keys = new ShareCheckKeyList();
                }

                return this._Keys;
            }
        }

        /// <summary>
        /// ���g���C�����w�肵�܂�
        /// </summary>
        public int RetryCount
        {
            get { return this._RetryCount; }
            set { this._RetryCount = value; }
        }

        /// <summary>
        /// �^�C���A�E�g���Ԃ��~���b�Ŏw�肵�܂�
        /// </summary>
        public int TimeOut
        {
            get { return this._TimeOut; }
            set { this._TimeOut = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ShareCheckInfo()
        {
            this._RetryCount = DEFAULT_SHARECHECK_RETRY;
            this._TimeOut = DEFAULT_SHARECHECK_TIMEOUT;
        }
    }

    # endregion
}
