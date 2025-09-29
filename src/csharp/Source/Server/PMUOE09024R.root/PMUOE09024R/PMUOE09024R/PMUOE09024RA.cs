//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ������}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMUOE09024R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :   2011/12/15 yangmj Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/09/10 ���� ��
//                  :   BL�Ǘ����[�U�[�R�[�h�Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE ������}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE ������}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: e-Parts�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009.05.29</br>
    /// </remarks>
    [Serializable]
    public class UOESupplierDB : RemoteWithAppLockDB, IUOESupplierDB, IGetSyncdataList
    {
        /// <summary>
        /// UOE ������}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public UOESupplierDB() : base("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork", "UOESupplierRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P���UOE ������}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierObj">UOESupplierWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����UOE ������}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref object uoeSupplierObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                UOESupplierWork uoeSupplierWork = uoeSupplierObj as UOESupplierWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref uoeSupplierWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �P���UOE ������}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierWork">UOESupplierWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����UOE ������}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref UOESupplierWork uoeSupplierWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref uoeSupplierWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �P���UOE ������}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierWork">UOESupplierWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����UOE ������}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int ReadProc(ref UOESupplierWork uoeSupplierWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;

                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                sqlText += " FROM UOESUPPLIERRF UOESUPP" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " WHERE UOESUPP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                sqlText += "    AND UOESUPP.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToUOESupplierWorkFromReader(ref myReader, ref uoeSupplierWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Delete]
        /// <summary>
        /// UOE ������}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSupplierList">�����폜����UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����UOE ������}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(object uoeSupplierList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeSupplierList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
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
        /// UOE ������}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSupplierList">UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList �Ɋi�[����Ă���UOE ������}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(uoeSupplierList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ������}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSupplierList">UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList �Ɋi�[����Ă���UOE ������}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int DeleteProc(ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (uoeSupplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSupplierList.Count; i++)
                    {
                        UOESupplierWork uoeSupplierWork = uoeSupplierList[i] as UOESupplierWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeSupplierWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// UOE ������}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">��������</param>
        /// <param name="uoeSupplierObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����A�S�Ă�UOE ������}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// <br>Update Note  : 2013/04/15 donggy</br>
        /// <br>�Ǘ��ԍ�     : 10900691-00 2013/05/15�z�M��</br>
        /// <br>               Redmine#35020�@�������ρv�́u����������ʁv�̃��X�|���X�ቺ�̃g���K�[�̔r��</br>
        public int Search(ref object uoeSupplierList, object uoeSupplierObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeSupplierArray = uoeSupplierList as ArrayList;

                if (uoeSupplierArray == null)
                {
                    uoeSupplierArray = new ArrayList();
                }
                // --- DEL donggy 2013/04/15 --->>>>>>>>
                //UOESupplierWork uoeSupplierWork = uoeSupplierObj as UOESupplierWork;
                //// �R�l�N�V��������
                //sqlConnection = this.CreateSqlConnection(true);

                //status = this.Search(ref uoeSupplierArray, uoeSupplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction); 
                // --- DEL donggy 2013/04/15 ---<<<<<<<<

                // --- ADD donggy 2013/04/15 --->>>>>>>>
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (uoeSupplierObj is UOESupplierWork)
                {
                    // UOE ������}�X�^���̃��X�g���擾���܂�
                    UOESupplierWork uoeSupplierWork = uoeSupplierObj as UOESupplierWork;
                status = this.Search(ref uoeSupplierArray, uoeSupplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
                else if (uoeSupplierObj is System.Collections.Generic.List<UOESupplierWork>)
                {
                    // UOE ������}�X�^���̃��X�g���擾���܂�(������R�[�h�ɂ��j
                    System.Collections.Generic.List<UOESupplierWork> uoeSupplierWorkList = uoeSupplierObj as System.Collections.Generic.List<UOESupplierWork>;
                    status = this.SearchBySupplierCds(ref uoeSupplierArray, uoeSupplierWorkList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                }
                // --- ADD donggy 2013/04/15 ---<<<<<<<<<
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// UOE ������}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeSupplierWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����A�S�Ă�UOE ������}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref ArrayList uoeSupplierList, UOESupplierWork uoeSupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref uoeSupplierList, uoeSupplierWork, readMode, logicalMode,ref sqlConnection,ref sqlTransaction);
        }

        // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>>>
        /// <summary>
        /// UOE ������}�X�^���̃��X�g���擾���܂��B(������R�[�h�ɂ��j
        /// </summary>
        /// <param name="uoeSupplierList">UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeSupplierWorkList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����A�S�Ă�UOE ������}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2013/04/15</br>
        private int SearchBySupplierCds(ref ArrayList uoeSupplierList, System.Collections.Generic.List<UOESupplierWork> uoeSupplierWorkList,
                                       int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                sqlText += " FROM UOESUPPLIERRF UOESUPP WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 WITH (READUNCOMMITTED)  ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeSupplierWorkList, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeSupplierList.Add(this.CopyToUOESupplierWorkFromReader(ref myReader));
                }

                if (uoeSupplierList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {

                    sqlCommand.Cancel();
                    sqlCommand.Dispose();

                }
            }

            return status;
        }
        // --- ADD donggy 2013/04/15 for Redmine#35020 ---<<<<<<<<<

        /// <summary>
        /// UOE ������}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeSupplierWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ������}�X�^�̃L�[�l����v����A�S�Ă�UOE ������}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int SearchProc(ref ArrayList uoeSupplierList, UOESupplierWork uoeSupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;

                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                
                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                sqlText += " FROM UOESUPPLIERRF UOESUPP" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeSupplierWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeSupplierList.Add(this.CopyToUOESupplierWorkFromReader(ref myReader));
                }

                if (uoeSupplierList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {

                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// UOE ������}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�ǉ��E�X�V����UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList �Ɋi�[����Ă���UOE ������}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref object uoeSupplierList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeSupplierList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
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
        /// UOE ������}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�ǉ��E�X�V����UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList �Ɋi�[����Ă���UOE ������}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref uoeSupplierList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ������}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�ǉ��E�X�V����UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList �Ɋi�[����Ă���UOE ������}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int WriteProc(ref ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeSupplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSupplierList.Count; i++)
                    {
                        UOESupplierWork uoeSupplierWork = uoeSupplierList[i] as UOESupplierWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeSupplierWork.UpdateDateTime)
                            {
                                if (uoeSupplierWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE UOESUPPLIERRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += " , UOESUPPLIERNAMERF=@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += " , TELNORF=@TELNO" + Environment.NewLine;
                            sqlText += " , UOETERMINALCDRF=@UOETERMINALCD" + Environment.NewLine;
                            sqlText += " , UOEHOSTCODERF=@UOEHOSTCODE" + Environment.NewLine;
                            sqlText += " , UOECONNECTPASSWORDRF=@UOECONNECTPASSWORD" + Environment.NewLine;
                            sqlText += " , UOECONNECTUSERIDRF=@UOECONNECTUSERID" + Environment.NewLine;
                            sqlText += " , UOEIDNUMRF=@UOEIDNUM" + Environment.NewLine;
                            sqlText += " , COMMASSEMBLYIDRF=@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += " , CONNECTVERSIONDIVRF=@CONNECTVERSIONDIV" + Environment.NewLine;
                            sqlText += " , UOESHIPSECTCDRF=@UOESHIPSECTCD" + Environment.NewLine;
                            sqlText += " , UOESALSECTCDRF=@UOESALSECTCD" + Environment.NewLine;
                            sqlText += " , UOERESERVSECTCDRF=@UOERESERVSECTCD" + Environment.NewLine;
                            sqlText += " , RECEIVECONDITIONRF=@RECEIVECONDITION" + Environment.NewLine;
                            sqlText += " , SUBSTPARTSNODIVRF=@SUBSTPARTSNODIV" + Environment.NewLine;
                            sqlText += " , PARTSNOPRTCDRF=@PARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " , LISTPRICEUSEDIVRF=@LISTPRICEUSEDIV" + Environment.NewLine;
                            sqlText += " , STOCKSLIPDTRECVDIVRF=@STOCKSLIPDTRECVDIV" + Environment.NewLine;
                            sqlText += " , CHECKCODEDIVRF=@CHECKCODEDIV" + Environment.NewLine;
                            sqlText += " , BUSINESSCODERF=@BUSINESSCODE" + Environment.NewLine;
                            sqlText += " , UOERESVDSECTIONRF=@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UOEDELIGOODSDIVRF=@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += " , BOCODERF=@BOCODE" + Environment.NewLine;
                            sqlText += " , UOEORDERRATERF=@UOEORDERRATE" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD1RF=@ENABLEODRMAKERCD1" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD2RF=@ENABLEODRMAKERCD2" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD3RF=@ENABLEODRMAKERCD3" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD4RF=@ENABLEODRMAKERCD4" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD5RF=@ENABLEODRMAKERCD5" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD6RF=@ENABLEODRMAKERCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                            sqlText += " , ODRPRTSNOHYPHENCD1RF=@ODRPRTSNOHYPHENCD1" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD2RF=@ODRPRTSNOHYPHENCD2" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD3RF=@ODRPRTSNOHYPHENCD3" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD4RF=@ODRPRTSNOHYPHENCD4" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD5RF=@ODRPRTSNOHYPHENCD5" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD6RF=@ODRPRTSNOHYPHENCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                            sqlText += " , INSTRUMENTNORF=@INSTRUMENTNO" + Environment.NewLine;
                            sqlText += " , UOETESTMODERF=@UOETESTMODE" + Environment.NewLine;
                            sqlText += " , UOEITEMCDRF=@UOEITEMCD" + Environment.NewLine;
                            sqlText += " , HONDASECTIONCODERF=@HONDASECTIONCODE" + Environment.NewLine;
                            sqlText += " , ANSWERSAVEFOLDERRF=@ANSWERSAVEFOLDER" + Environment.NewLine;
                            sqlText += " , MAZDASECTIONCODERF=@MAZDASECTIONCODE" + Environment.NewLine;
                            sqlText += " , EMERGENCYDIVRF=@EMERGENCYDIV" + Environment.NewLine;
                            sqlText += " , DAIHATSUORDREDIVRF=@DAIHATSUORDREDIV" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;

                            // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += " ,LOGINTIMEOUTVALRF = @LOGINTIMEOUTVAL" + Environment.NewLine;
                            sqlText += " ,UOEORDERURLRF = @UOEORDERURL" + Environment.NewLine;
                            sqlText += " ,UOESTOCKCHECKURLRF = @UOESTOCKCHECKURL" + Environment.NewLine;
                            sqlText += " ,UOEFORCEDTERMURLRF = @UOEFORCEDTERMURL" + Environment.NewLine;
                            sqlText += " ,UOELOGINURLRF = @UOELOGINURL" + Environment.NewLine;
                            sqlText += " ,INQORDDIVCDRF = @INQORDDIVCD" + Environment.NewLine;
                            sqlText += " ,EPARTSUSERIDRF = @EPARTSUSERID" + Environment.NewLine;
                            sqlText += " ,EPARTSPASSWORDRF = @EPARTSPASSWORD" + Environment.NewLine;
                            // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                            sqlText += " ,BLMNGUSERCODERF = @BLMNGUSERCODE" + Environment.NewLine;
                            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSupplierWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (uoeSupplierWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO UOESUPPLIERRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,UOESUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "    ,UOESUPPLIERNAMERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,TELNORF" + Environment.NewLine;
                            sqlText += "    ,UOETERMINALCDRF" + Environment.NewLine;
                            sqlText += "    ,UOEHOSTCODERF" + Environment.NewLine;
                            sqlText += "    ,UOECONNECTPASSWORDRF" + Environment.NewLine;
                            sqlText += "    ,UOECONNECTUSERIDRF" + Environment.NewLine;
                            sqlText += "    ,UOEIDNUMRF" + Environment.NewLine;
                            sqlText += "    ,COMMASSEMBLYIDRF" + Environment.NewLine;
                            sqlText += "    ,CONNECTVERSIONDIVRF" + Environment.NewLine;
                            sqlText += "    ,UOESHIPSECTCDRF" + Environment.NewLine;
                            sqlText += "    ,UOESALSECTCDRF" + Environment.NewLine;
                            sqlText += "    ,UOERESERVSECTCDRF" + Environment.NewLine;
                            sqlText += "    ,RECEIVECONDITIONRF" + Environment.NewLine;
                            sqlText += "    ,SUBSTPARTSNODIVRF" + Environment.NewLine;
                            sqlText += "    ,PARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += "    ,LISTPRICEUSEDIVRF" + Environment.NewLine;
                            sqlText += "    ,STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                            sqlText += "    ,CHECKCODEDIVRF" + Environment.NewLine;
                            sqlText += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlText += "    ,UOERESVDSECTIONRF" + Environment.NewLine;
                            sqlText += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UOEDELIGOODSDIVRF" + Environment.NewLine;
                            sqlText += "    ,BOCODERF" + Environment.NewLine;
                            sqlText += "    ,UOEORDERRATERF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD1RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD2RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD3RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD4RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD5RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD6RF" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                            sqlText += "    ,ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                            sqlText += "    ,INSTRUMENTNORF" + Environment.NewLine;
                            sqlText += "    ,UOETESTMODERF" + Environment.NewLine;
                            sqlText += "    ,UOEITEMCDRF" + Environment.NewLine;
                            sqlText += "    ,HONDASECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,ANSWERSAVEFOLDERRF" + Environment.NewLine;
                            sqlText += "    ,MAZDASECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,EMERGENCYDIVRF" + Environment.NewLine;
                            sqlText += "    ,DAIHATSUORDREDIVRF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                            // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += "    ,LOGINTIMEOUTVALRF" + Environment.NewLine;
                            sqlText += "    ,UOEORDERURLRF" + Environment.NewLine;
                            sqlText += "    ,UOESTOCKCHECKURLRF " + Environment.NewLine;
                            sqlText += "    ,UOEFORCEDTERMURLRF" + Environment.NewLine;
                            sqlText += "    ,UOELOGINURLRF" + Environment.NewLine;
                            sqlText += "    ,INQORDDIVCDRF" + Environment.NewLine;
                            sqlText += "    ,EPARTSUSERIDRF" + Environment.NewLine;
                            sqlText += "    ,EPARTSPASSWORDRF" + Environment.NewLine;
                            // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                            sqlText += "    ,BLMNGUSERCODERF" + Environment.NewLine;
                            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    ,@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += "    ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@TELNO" + Environment.NewLine;
                            sqlText += "    ,@UOETERMINALCD" + Environment.NewLine;
                            sqlText += "    ,@UOEHOSTCODE" + Environment.NewLine;
                            sqlText += "    ,@UOECONNECTPASSWORD" + Environment.NewLine;
                            sqlText += "    ,@UOECONNECTUSERID" + Environment.NewLine;
                            sqlText += "    ,@UOEIDNUM" + Environment.NewLine;
                            sqlText += "    ,@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += "    ,@CONNECTVERSIONDIV" + Environment.NewLine;
                            sqlText += "    ,@UOESHIPSECTCD" + Environment.NewLine;
                            sqlText += "    ,@UOESALSECTCD" + Environment.NewLine;
                            sqlText += "    ,@UOERESERVSECTCD" + Environment.NewLine;
                            sqlText += "    ,@RECEIVECONDITION" + Environment.NewLine;
                            sqlText += "    ,@SUBSTPARTSNODIV" + Environment.NewLine;
                            sqlText += "    ,@PARTSNOPRTCD" + Environment.NewLine;
                            sqlText += "    ,@LISTPRICEUSEDIV" + Environment.NewLine;
                            sqlText += "    ,@STOCKSLIPDTRECVDIV" + Environment.NewLine;
                            sqlText += "    ,@CHECKCODEDIV" + Environment.NewLine;
                            sqlText += "    ,@BUSINESSCODE" + Environment.NewLine;
                            sqlText += "    ,@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += "    ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "    ,@BOCODE" + Environment.NewLine;
                            sqlText += "    ,@UOEORDERRATE" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD1" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD2" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD3" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD4" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD5" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                            sqlText += "    ,@ODRPRTSNOHYPHENCD1" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD2" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD3" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD4" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD5" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                            sqlText += "    ,@INSTRUMENTNO" + Environment.NewLine;
                            sqlText += "    ,@UOETESTMODE" + Environment.NewLine;
                            sqlText += "    ,@UOEITEMCD" + Environment.NewLine;
                            sqlText += "    ,@HONDASECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@ANSWERSAVEFOLDER" + Environment.NewLine;
                            sqlText += "    ,@MAZDASECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@EMERGENCYDIV" + Environment.NewLine;
                            sqlText += "    ,@DAIHATSUORDREDIV" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                            // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += "    ,@LOGINTIMEOUTVAL" + Environment.NewLine;
                            sqlText += "    ,@UOEORDERURL" + Environment.NewLine;
                            sqlText += "    ,@UOESTOCKCHECKURL" + Environment.NewLine;
                            sqlText += "    ,@UOEFORCEDTERMURL" + Environment.NewLine;
                            sqlText += "    ,@UOELOGINURL" + Environment.NewLine;
                            sqlText += "    ,@INQORDDIVCD" + Environment.NewLine;
                            sqlText += "    ,@EPARTSUSERID" + Environment.NewLine;
                            sqlText += "    ,@EPARTSPASSWORD" + Environment.NewLine;
                            // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                            sqlText += "    ,@BLMNGUSERCODE" + Environment.NewLine;
                            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSupplierWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraUOESupplierName = sqlCommand.Parameters.Add("@UOESUPPLIERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraTelNo = sqlCommand.Parameters.Add("@TELNO", SqlDbType.NVarChar);
                        SqlParameter paraUOETerminalCd = sqlCommand.Parameters.Add("@UOETERMINALCD", SqlDbType.NVarChar);
                        SqlParameter paraUOEHostCode = sqlCommand.Parameters.Add("@UOEHOSTCODE", SqlDbType.NVarChar);
                        SqlParameter paraUOEConnectPassword = sqlCommand.Parameters.Add("@UOECONNECTPASSWORD", SqlDbType.NVarChar);
                        SqlParameter paraUOEConnectUserId = sqlCommand.Parameters.Add("@UOECONNECTUSERID", SqlDbType.NVarChar);
                        SqlParameter paraUOEIDNum = sqlCommand.Parameters.Add("@UOEIDNUM", SqlDbType.NVarChar);
                        SqlParameter paraCommAssemblyId = sqlCommand.Parameters.Add("@COMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraConnectVersionDiv = sqlCommand.Parameters.Add("@CONNECTVERSIONDIV", SqlDbType.Int);
                        SqlParameter paraUOEShipSectCd = sqlCommand.Parameters.Add("@UOESHIPSECTCD", SqlDbType.NVarChar);
                        SqlParameter paraUOESalSectCd = sqlCommand.Parameters.Add("@UOESALSECTCD", SqlDbType.NVarChar);
                        SqlParameter paraUOEReservSectCd = sqlCommand.Parameters.Add("@UOERESERVSECTCD", SqlDbType.NVarChar);
                        SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITION", SqlDbType.Int);
                        SqlParameter paraSubstPartsNoDiv = sqlCommand.Parameters.Add("@SUBSTPARTSNODIV", SqlDbType.Int);
                        SqlParameter paraPartsNoPrtCd = sqlCommand.Parameters.Add("@PARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraListPriceUseDiv = sqlCommand.Parameters.Add("@LISTPRICEUSEDIV", SqlDbType.Int);
                        SqlParameter paraStockSlipDtRecvDiv = sqlCommand.Parameters.Add("@STOCKSLIPDTRECVDIV", SqlDbType.Int);
                        SqlParameter paraCheckCodeDiv = sqlCommand.Parameters.Add("@CHECKCODEDIV", SqlDbType.Int);
                        SqlParameter paraBusinessCode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
                        SqlParameter paraUOEResvdSection = sqlCommand.Parameters.Add("@UOERESVDSECTION", SqlDbType.NVarChar);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUOEDeliGoodsDiv = sqlCommand.Parameters.Add("@UOEDELIGOODSDIV", SqlDbType.NVarChar);
                        SqlParameter paraBoCode = sqlCommand.Parameters.Add("@BOCODE", SqlDbType.NChar);
                        SqlParameter paraUOEOrderRate = sqlCommand.Parameters.Add("@UOEORDERRATE", SqlDbType.NVarChar);
                        SqlParameter paraEnableOdrMakerCd1 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD1", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd2 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD2", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd3 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD3", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd4 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD4", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd5 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD5", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd6 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD6", SqlDbType.Int);

                        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                        SqlParameter paraOdrPrtsNoHyphenCd1 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD1", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd2 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD2", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd3 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD3", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd4 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD4", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd5 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD5", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd6 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD6", SqlDbType.Int);
                        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<

                        SqlParameter parainstrumentNo = sqlCommand.Parameters.Add("@INSTRUMENTNO", SqlDbType.NVarChar);
                        SqlParameter paraUOETestMode = sqlCommand.Parameters.Add("@UOETESTMODE", SqlDbType.NVarChar);
                        SqlParameter paraUOEItemCd = sqlCommand.Parameters.Add("@UOEITEMCD", SqlDbType.NVarChar);
                        SqlParameter paraHondaSectionCode = sqlCommand.Parameters.Add("@HONDASECTIONCODE", SqlDbType.NVarChar);
                        SqlParameter paraAnswerSaveFolder = sqlCommand.Parameters.Add("@ANSWERSAVEFOLDER", SqlDbType.NVarChar);
                        SqlParameter paraMazdaSectionCode = sqlCommand.Parameters.Add("@MAZDASECTIONCODE", SqlDbType.NVarChar);
                        SqlParameter paraEmergencyDiv = sqlCommand.Parameters.Add("@EMERGENCYDIV", SqlDbType.NVarChar);
                        SqlParameter paraDaihatsuOrdreDiv = sqlCommand.Parameters.Add("@DAIHATSUORDREDIV", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVAL", SqlDbType.Int);  // ���O�C���^�C���A�E�g
                        SqlParameter paraUOEOrderUrl = sqlCommand.Parameters.Add("@UOEORDERURL", SqlDbType.NVarChar);  // UOE����URL
                        SqlParameter paraUOEStockCheckUrl = sqlCommand.Parameters.Add("@UOESTOCKCHECKURL", SqlDbType.NVarChar);  // UOE�݌Ɋm�FURL
                        SqlParameter paraUOEForcedTermUrl = sqlCommand.Parameters.Add("@UOEFORCEDTERMURL", SqlDbType.NVarChar);  // UOE�����I��URL
                        SqlParameter paraUOELoginUrl = sqlCommand.Parameters.Add("@UOELOGINURL", SqlDbType.NVarChar);  // UOE���O�C��URL
                        SqlParameter paraInqOrdDivCd = sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);  // �⍇���E�������
                        SqlParameter paraEPartsUserId = sqlCommand.Parameters.Add("@EPARTSUSERID", SqlDbType.NVarChar);  // e-Parts���[�UID
                        SqlParameter paraEPartsPassWord = sqlCommand.Parameters.Add("@EPARTSPASSWORD", SqlDbType.NVarChar);  // e-Parts�p�X���[�h
                        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraBLMngUserCode = sqlCommand.Parameters.Add("@BLMNGUSERCODE", SqlDbType.NVarChar); //BL�Ǘ����[�U�[�R�[�h
                        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                        // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSupplierWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSupplierWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeSupplierWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.LogicalDeleteCode);
                        paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        paraUOESupplierName.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOESupplierName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.GoodsMakerCd);
                        paraTelNo.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.TelNo);
                        paraUOETerminalCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOETerminalCd);
                        paraUOEHostCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEHostCode);
                        paraUOEConnectPassword.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEConnectPassword);
                        paraUOEConnectUserId.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEConnectUserId);
                        paraUOEIDNum.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEIDNum);
                        paraCommAssemblyId.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.CommAssemblyId);
                        paraConnectVersionDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.ConnectVersionDiv);
                        paraUOEShipSectCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEShipSectCd);
                        paraUOESalSectCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOESalSectCd);
                        paraUOEReservSectCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEReservSectCd);
                        paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.ReceiveCondition);
                        paraSubstPartsNoDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.SubstPartsNoDiv);
                        paraPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.PartsNoPrtCd);
                        paraListPriceUseDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.ListPriceUseDiv);
                        paraStockSlipDtRecvDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.StockSlipDtRecvDiv);
                        paraCheckCodeDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.CheckCodeDiv);
                        paraBusinessCode.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.BusinessCode);
                        paraUOEResvdSection.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEResvdSection);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EmployeeCode);
                        paraUOEDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEDeliGoodsDiv);
                        paraBoCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.BoCode);
                        paraUOEOrderRate.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEOrderRate);
                        paraEnableOdrMakerCd1.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd1);
                        paraEnableOdrMakerCd2.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd2);
                        paraEnableOdrMakerCd3.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd3);
                        paraEnableOdrMakerCd4.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd4);
                        paraEnableOdrMakerCd5.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd5);
                        paraEnableOdrMakerCd6.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd6);

                        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                        paraOdrPrtsNoHyphenCd1.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd1);
                        paraOdrPrtsNoHyphenCd2.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd2);
                        paraOdrPrtsNoHyphenCd3.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd3);
                        paraOdrPrtsNoHyphenCd4.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd4);
                        paraOdrPrtsNoHyphenCd5.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd5);
                        paraOdrPrtsNoHyphenCd6.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd6);
                        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                        parainstrumentNo.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.instrumentNo);
                        paraUOETestMode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOETestMode);
                        paraUOEItemCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEItemCd);
                        paraHondaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.HondaSectionCode);
                        paraAnswerSaveFolder.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.AnswerSaveFolder);
                        paraMazdaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.MazdaSectionCode);
                        paraEmergencyDiv.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EmergencyDiv);
                        paraDaihatsuOrdreDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.DaihatsuOrdreDiv);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.SupplierCd);
                        // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        paraLoginTimeoutVal.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.LoginTimeoutVal);  // ���O�C���^�C���A�E�g
                        paraUOEOrderUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEOrderUrl);  // UOE����URL
                        paraUOEStockCheckUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEStockCheckUrl);  // UOE�݌Ɋm�FURL
                        paraUOEForcedTermUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEForcedTermUrl);  // UOE�����I��URL
                        paraUOELoginUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOELoginUrl);  // UOE���O�C��URL
                        paraInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.InqOrdDivCd);  // �⍇���E�������
                        paraEPartsUserId.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EPartsUserId);  // e-Parts���[�UID
                        paraEPartsPassWord.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EPartsPassWord);  // e-Parts�p�X���[�h
                        // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                        paraBLMngUserCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.BLMngUserCode); //BL�Ǘ����[�U�[�R�[�h
                        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeSupplierWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            uoeSupplierList = al;

            return status;
        }
        # endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������UOE������}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������UOE������}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;
                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                sqlText += "    , UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                sqlText += " FROM UOESUPPLIERRF UOESUPP" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESALSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOERESERVSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToUOESupplierWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        # region [LogicalDelete]
        /// <summary>
        /// UOE ������}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜����UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref object uoeSupplierList)
        {
            return this.LogicalDelete(ref uoeSupplierList, 0);
        }

        /// <summary>
        /// UOE ������}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜����������UOE ������}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int RevivalLogicalDelete(ref object uoeSupplierList)
        {
            return this.LogicalDelete(ref uoeSupplierList, 1);
        }

        /// <summary>
        /// UOE ������}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜�𑀍삷��UOE ������}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDelete(ref object uoeSupplierList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeSupplierList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
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
        /// UOE ������}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜�𑀍삷��UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref ArrayList uoeSupplierList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref uoeSupplierList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ������}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeSupplierList">�_���폜�𑀍삷��UOE ������}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork �Ɋi�[����Ă���UOE ������}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDeleteProc(ref ArrayList uoeSupplierList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeSupplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSupplierList.Count; i++)
                    {
                        UOESupplierWork uoeSupplierWork = uoeSupplierList[i] as UOESupplierWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
                        
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeSupplierWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  UOESUPPLIERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSupplierWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // �_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) uoeSupplierWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else uoeSupplierWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                uoeSupplierWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSupplierWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeSupplierWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            uoeSupplierList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="uoeSupplierWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOESupplierWork uoeSupplierWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  UOESUPP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // UOE������R�[�h
            if (uoeSupplierWork.UOESupplierCd != 0)
            {
                retstring += "  AND UOESUPP.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter findUOESupplier = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                findUOESupplier.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
            }

            // ���_�R�[�h
            if (uoeSupplierWork.SectionCode != "")
            {
                retstring += "  AND UOESUPP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
            }
            return retstring;
        }

        // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>>
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="uoeSupplierWorkList">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2013/04/15</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, System.Collections.Generic.List<UOESupplierWork> uoeSupplierWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            if (uoeSupplierWorkList.Count == 0)
            {
                return string.Empty;
            }
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  UOESUPP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWorkList[0].EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // UOE������R�[�h
            for (int i = 0; i < uoeSupplierWorkList.Count; i++)
            {
                if (uoeSupplierWorkList.Count > 1)
                {
                    if (uoeSupplierWorkList[i].UOESupplierCd != 0)
                    {
                        if (i == 0)
                        {
                            retstring += "  AND (  UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + Environment.NewLine;
                        }
                        else if (i < uoeSupplierWorkList.Count - 1)
                        {
                            retstring += "      OR UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + Environment.NewLine;
                        }
                        else
                        {
                            retstring += "     OR UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + " )" + Environment.NewLine;
                        }
                    }
                }
                else if (uoeSupplierWorkList.Count == 1)
                {
                    if (uoeSupplierWorkList[i].UOESupplierCd != 0)
                    {
                        retstring += "  AND  UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + Environment.NewLine;
                    }
                }

            }
            // ���_�R�[�h
            if (uoeSupplierWorkList[0].SectionCode != "")
            {
                retstring += "  AND UOESUPP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWorkList[0].SectionCode);
            }
            return retstring;
        }
        // --- ADD donggy 2013/04/15 for Redmine#35020 ---<<<<<<<<
        # endregion

        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "UOESUPP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UOESUPP.UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UOESUPP.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UOESUPP.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� UOESupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>uoeSupplierWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private UOESupplierWork CopyToUOESupplierWorkFromReader(ref SqlDataReader myReader)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();

            this.CopyToUOESupplierWorkFromReader(ref myReader, ref uoeSupplierWork);

            return uoeSupplierWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� UOESupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeSupplierWork">UOESupplierWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private void CopyToUOESupplierWorkFromReader(ref SqlDataReader myReader, ref UOESupplierWork uoeSupplierWork)
        {
            if (myReader != null && uoeSupplierWork != null)
            {
                # region �N���X�֊i�[
                uoeSupplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                uoeSupplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                uoeSupplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                uoeSupplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                uoeSupplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                uoeSupplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                uoeSupplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                uoeSupplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                uoeSupplierWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                uoeSupplierWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                uoeSupplierWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                uoeSupplierWork.TelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TELNORF"));
                uoeSupplierWork.UOETerminalCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOETERMINALCDRF"));
                uoeSupplierWork.UOEHostCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEHOSTCODERF"));
                uoeSupplierWork.UOEConnectPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECONNECTPASSWORDRF"));
                uoeSupplierWork.UOEConnectUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECONNECTUSERIDRF"));
                uoeSupplierWork.UOEIDNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEIDNUMRF"));
                uoeSupplierWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                uoeSupplierWork.ConnectVersionDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONNECTVERSIONDIVRF"));
                uoeSupplierWork.UOEShipSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESHIPSECTCDRF"));
                uoeSupplierWork.UOESalSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESALSECTCDRF"));
                uoeSupplierWork.UOEReservSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESERVSECTCDRF"));
                uoeSupplierWork.ReceiveCondition = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVECONDITIONRF"));
                uoeSupplierWork.SubstPartsNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSTPARTSNODIVRF"));
                uoeSupplierWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
                uoeSupplierWork.ListPriceUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEUSEDIVRF"));
                uoeSupplierWork.StockSlipDtRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPDTRECVDIVRF"));
                uoeSupplierWork.CheckCodeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKCODEDIVRF"));
                uoeSupplierWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                uoeSupplierWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                uoeSupplierWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                uoeSupplierWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                uoeSupplierWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                uoeSupplierWork.UOEOrderRate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEORDERRATERF"));
                uoeSupplierWork.EnableOdrMakerCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD1RF"));
                uoeSupplierWork.EnableOdrMakerCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD2RF"));
                uoeSupplierWork.EnableOdrMakerCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD3RF"));
                uoeSupplierWork.EnableOdrMakerCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD4RF"));
                uoeSupplierWork.EnableOdrMakerCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD5RF"));
                uoeSupplierWork.EnableOdrMakerCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD6RF"));
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                uoeSupplierWork.OdrPrtsNoHyphenCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD1RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD2RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD3RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD4RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD5RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD6RF"));
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                uoeSupplierWork.instrumentNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSTRUMENTNORF"));
                uoeSupplierWork.UOETestMode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOETESTMODERF"));
                uoeSupplierWork.UOEItemCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEITEMCDRF"));
                uoeSupplierWork.HondaSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONDASECTIONCODERF"));
                uoeSupplierWork.AnswerSaveFolder = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERSAVEFOLDERRF"));
                uoeSupplierWork.MazdaSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDASECTIONCODERF"));
                uoeSupplierWork.EmergencyDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMERGENCYDIVRF"));
                uoeSupplierWork.DaihatsuOrdreDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DAIHATSUORDREDIVRF"));
                uoeSupplierWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                uoeSupplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                uoeSupplierWork.LoginTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGINTIMEOUTVALRF"));  // ���O�C���^�C���A�E�g
                uoeSupplierWork.UOEOrderUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEORDERURLRF"));  // UOE����URL
                uoeSupplierWork.UOEStockCheckUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESTOCKCHECKURLRF"));  // UOE�݌Ɋm�FURL
                uoeSupplierWork.UOEForcedTermUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEFORCEDTERMURLRF"));  // UOE�����I��URL
                uoeSupplierWork.UOELoginUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOELOGINURLRF"));  // UOE���O�C��URL
                uoeSupplierWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // �⍇���E�������
                uoeSupplierWork.EPartsUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPARTSUSERIDRF"));  // e-Parts���[�UID
                uoeSupplierWork.EPartsPassWord = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPARTSPASSWORDRF"));  // e-Parts�p�X���[�h
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                uoeSupplierWork.BLMngUserCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLMNGUSERCODERF")); //BL�Ǘ����[�U�[�R�[�h
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                
                // �������牺�͎��e�[�u���ɂȂ��A�ǉ�����
                uoeSupplierWork.UOEShipSectNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPSECTNM"));
                uoeSupplierWork.UOESalSectNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALSECTNM"));
                uoeSupplierWork.UOEReservSectNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESERVSECTNM"));
                uoeSupplierWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNM"));
                uoeSupplierWork.EnableOdrMakerName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM1"));
                uoeSupplierWork.EnableOdrMakerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM2"));
                uoeSupplierWork.EnableOdrMakerName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM3"));
                uoeSupplierWork.EnableOdrMakerName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM4"));
                uoeSupplierWork.EnableOdrMakerName5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM5"));
                uoeSupplierWork.EnableOdrMakerName6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM6"));
                # endregion
            }
        }
        # endregion

        # region [�R�l�N�V������������]
        /*
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
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

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        */
        # endregion
    }
}
