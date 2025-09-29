//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ԗ��Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMSYR09011R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.06.02
//----------------------------------------------------------------------
// Update Note      :   2009/09/11 �����
//                      ���q�Ǘ��}�X�^ LDNS�J���Ή�
// Update Note      :   2009/12/24 ���n ���
//                      MANTIS[14822] ���q�Ǘ��}�X�^�@�L�[�ǉ��Ή�
// Update Note      :   2010/04/27 gaoyh
//                      ���q�Ǘ��}�X�^ ���R�����^���Œ�ԍ��z���ǉ�
// Update Note      :   2011/03/22 ������
//                      �Ɖ�v���O�����̃��O�o�͑Ή�
// Update Note      :   2011/04/06 ������
//                      Redmine#20389�̑Ή��i���[�n���O�o�͑Ή��̎d�l�ύX�j
// Update Note      :   2012/08/30 �e�c�@���V
//                      ���`�C�����Ɏ��p�Ǘ��}�X�^�̓��e���N���A������Q�̏C��
// Update Note      :   2013/01/11 �����M
// �Ǘ��ԍ�         :   10801804-00 2013/03/13�z�M��
//                      Redmine#32256 ���q�Ǘ��}�X�^�ɍ폜�ς݂̃f�[�^�������Ɗ��S�폜����ł��Ȃ���Q�̏C��
// Update Note      :   2013/03/22 FSI���� ����
// �Ǘ��ԍ�         :   10900269-00 
//                      SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�
// Update Note      :   2015/03/23 �{�{ ����
// �Ǘ��ԍ�         :   11070149-00
//                      ���V�o����̎��q�Ǘ��o�^(���`���͎�)�̏�Q�Ή�
// Update Note      :   2020/08/28 �c����
// �Ǘ��ԍ�         :   11600006-00
//                      PMKOBETSU-4076 �^�C���A�E�g�ݒ�
// Update Note      :   2021/11/02 ���X�ؘj
// �Ǘ��ԍ�         :   11770175-00
//                      OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�@���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j
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
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ԗ��Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ��Ǘ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.06.02</br>
    /// <br></br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2011/04/06 ������</br>
    /// <br>             Redmine#20389�̑Ή��i���[�n���O�o�͑Ή��̎d�l�ύX�j</br>
    /// <br>Update Note: 2013/01/11 �����M</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#32256 ���q�Ǘ��}�X�^�ɍ폜�ς݂̃f�[�^�������Ɗ��S�폜����ł��Ȃ���Q�̏C��</br>
    /// <br>Update Note: 2013/03/22 FSI���� ����</br>
    /// <br>�Ǘ��ԍ�   : 10900269-00</br>
    /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
    /// <br>Update Note: PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2020/08/28</br>
    /// <br>Update Note: 2021/11/02 ���X�ؘj</br>
    /// <br>�Ǘ��ԍ�   : 11770175-00</br>
    /// <br>             OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�@���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j</br>
    /// </remarks>
    [Serializable]
    public class CarManagementDB : RemoteWithAppLockDB, ICarManagementDB
    {
        private bool _CompulsoryDataOverride = false;

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        // --- ADD ���X�ؘj 2021/11/02 ------>>>>> 
        // �ő咊�o����
        private const int MAX_MST_RECORD_COUNT = 20001;
        // --- ADD ���X�ؘj 2021/11/02 ------<<<<<

        /// <summary>
        /// �ԗ��Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public CarManagementDB() : base("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork", "CARMANAGEMENTRF")
        {
            this._CompulsoryDataOverride = false;
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="compulsoryDataOverride">false(�W��):�X�V���t�����l�����ăf�[�^�̍X�V���s���B�@true:�X�V���t�Ȃǂ𖳎����ăf�[�^�̍X�V���s���B</param>
        /// <remarks>
        /// <br>Note       : �{�R���X�g���N�^���g�p����ۂ́ACompulsoryDataOverride�̎戵���ɏ\�����ӂ��鎖</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public CarManagementDB(bool compulsoryDataOverride)
            : base("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork", "CARMANAGEMENTRF")
        {
            this._CompulsoryDataOverride = true;
        }


        # region [Read]
        /// <summary>
        /// �P��̎ԗ��Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="carManagementObj">CarManagementWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Read(ref object carManagementObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CarManagementWork carManagementWork = carManagementObj as CarManagementWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref carManagementWork, readMode, sqlConnection, sqlTransaction);
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
        /// �P��̎ԗ��Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="carManagementWork">CarManagementWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Read(ref CarManagementWork carManagementWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref carManagementWork, readMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �P��̎ԗ��Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="carManagementWork">CarManagementWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        private int ReadProc(ref CarManagementWork carManagementWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                // sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction); // DEL 2009/09/11

                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CARM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CARM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICCODERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.DOORCOUNTRF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMECODERF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,CARM.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADENMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEDISPLACENMRF" + Environment.NewLine;
                sqlText += " ,CARM.EDIVNMRF" + Environment.NewLine;
                sqlText += " ,CARM.TRANSMISSIONNMRF" + Environment.NewLine;
                sqlText += " ,CARM.SHIFTNMRF" + Environment.NewLine;
                sqlText += " ,CARM.WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC6RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE6RF" + Environment.NewLine;
                sqlText += " ,CARM.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                sqlText += " ,CARM.THREEDILLUSTNORF" + Environment.NewLine;
                sqlText += " ,CARM.PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                sqlText += " ,CARM.INSPECTMATURITYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.LTIMECIMATDATERF" + Environment.NewLine;
                sqlText += " ,CARM.CARINSPECTYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.MILEAGERF" + Environment.NewLine;
                sqlText += " ,CARM.CARNORF" + Environment.NewLine;
                sqlText += " ,CARM.COLORCODERF" + Environment.NewLine;
                sqlText += " ,CARM.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYOBJARYRF" + Environment.NewLine;
                // --- ADD 2009/09/11 -------------->>>
                sqlText += " ,CARM.CARADDINFO1RF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO2RF" + Environment.NewLine;
                sqlText += " ,CARM.CARNOTERF" + Environment.NewLine;
                // --- ADD 2009/09/11 --------------<<<
                // --- ADD 2009/04/26 -------------->>>
                sqlText += " ,CARM.FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                // --- ADD 2010/04/26 -------------->>>
                // ADD 2013/03/22  -------------------->>>>>
                sqlText += " ,CARM.DOMESTICFOREIGNCODERF" + Environment.NewLine;
                sqlText += " ,CARM.HANDLEINFOCDRF" + Environment.NewLine;
                // ADD 2013/03/22  --------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                # endregion                

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction); // ADD 2009/09/11

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // 2009/12/24

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // 2009/12/24

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCarManagementWorkFromReader(ref myReader, ref carManagementWork);
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
        /// �ԗ��Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="carManagementList">�����폜����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����ԗ��Ǘ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Delete(object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = carManagementList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
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
        /// �ԗ��Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="carManagementList">�ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Delete(ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(carManagementList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="carManagementList">�ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/01/11 �����M</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#32256 ���q�Ǘ��}�X�^�ɍ폜�ς݂̃f�[�^�������Ɗ��S�폜����ł��Ȃ���Q�̏C��</br>
        private int DeleteProc(ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine;// ADD �����M 2013/01/11 for redmine 32256
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // ADD �����M 2013/01/11 for redmine 32256

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD �����M 2013/01/11 for redmine 32256

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != carManagementWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD �����M 2013/01/11 for redmine 32256
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD �����M 2013/01/11 for redmine 32256
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
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carManagementList">��������</param>
        /// <param name="carManagementObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int Search(ref object carManagementList, object carManagementObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList carManagementArray = carManagementList as ArrayList;
                CarManagementWork carManagementWork = carManagementObj as CarManagementWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                bool checkId = oprtnHisLogDB.CheckClientAssemblyId("PMSYA04001U");
                if (checkId) oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carManagementWork.EnterpriseCode, "���q�o�ו��i�\��(���q����)", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                status = this.Search(ref carManagementArray, carManagementWork, readMode, logicalMode, sqlConnection, sqlTransaction);

                // ---ADD 2011/03/22---------->>>>>
                if (checkId) oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carManagementWork.EnterpriseCode, "���q�o�ו��i�\��(���q����)", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<
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
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carManagementList">�ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="carManagementWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2009/09/11 ����� LDNS�J���Ή�</br>
        public int Search(ref ArrayList carManagementList, CarManagementWork carManagementWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            // --- UPD 2009/09/11 -------------->>>
            //return this.Search(ref carManagementList, carManagementWork, readMode, logicalMode, sqlConnection, sqlTransaction);
            return this.SearchProc(ref carManagementList, carManagementWork, readMode, logicalMode, sqlConnection, sqlTransaction);
            // --- UPD 2009/09/11 --------------<<<
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carManagementList">�ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="carManagementWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// <br>Update Note: 2021/11/02 ���X�ؘj</br>
        /// <br>�Ǘ��ԍ�   : 11770175-00</br>
        /// <br>             OUT OF MEMORY�Ή�(4GB�Ή�) ���q�Ǘ��}�X�^�ێ�@���o�Ώی������ő匏��20001���܂Łi20000���܂ŉ�ʕ\���j</br>
        private int SearchProc(ref ArrayList carManagementList, CarManagementWork carManagementWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                // --- ADD ���X�ؘj 2021/11/02 ------>>>>> 
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                bool checkId = oprtnHisLogDB.CheckClientAssemblyId("PMSYA04001U");
                if (checkId == true)
                {
                    // ���q�o�ו��i�\��(���q����)
                }
                else
                {
                    sqlText += string.Format(" TOP {0} ", MAX_MST_RECORD_COUNT) + Environment.NewLine;
                }
                // --- ADD ���X�ؘj 2021/11/02 ------<<<<<
                sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CARM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CARM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICCODERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.DOORCOUNTRF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMECODERF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,CARM.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADENMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEDISPLACENMRF" + Environment.NewLine;
                sqlText += " ,CARM.EDIVNMRF" + Environment.NewLine;
                sqlText += " ,CARM.TRANSMISSIONNMRF" + Environment.NewLine;
                sqlText += " ,CARM.SHIFTNMRF" + Environment.NewLine;
                sqlText += " ,CARM.WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC6RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE6RF" + Environment.NewLine;
                sqlText += " ,CARM.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                sqlText += " ,CARM.THREEDILLUSTNORF" + Environment.NewLine;
                sqlText += " ,CARM.PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                sqlText += " ,CARM.INSPECTMATURITYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.LTIMECIMATDATERF" + Environment.NewLine;
                sqlText += " ,CARM.CARINSPECTYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.MILEAGERF" + Environment.NewLine;
                sqlText += " ,CARM.CARNORF" + Environment.NewLine;
                sqlText += " ,CARM.COLORCODERF" + Environment.NewLine;
                sqlText += " ,CARM.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYOBJARYRF" + Environment.NewLine;
                // --- ADD 2009/09/11 ---------->>>>>
                sqlText += " ,CARM.CARADDINFO1RF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO2RF" + Environment.NewLine;
                sqlText += " ,CARM.CARNOTERF" + Environment.NewLine;
                // --- ADD 2009/09/11 ----------<<<<<
                // --- ADD 2009/04/26 -------------->>>
                sqlText += " ,CARM.FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                // --- ADD 2010/04/26 -------------->>>
                // ADD 2013/03/22  -------------------->>>>>
                sqlText += " ,CARM.DOMESTICFOREIGNCODERF" + Environment.NewLine;
                sqlText += " ,CARM.HANDLEINFOCDRF" + Environment.NewLine;
                // ADD 2013/03/22  --------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine; sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, carManagementWork, logicalMode);
                // --- ADD 2009/09/11 ---------->>>>>
                sqlCommand.CommandText += " ORDER BY CARM.CUSTOMERCODERF";
                sqlCommand.CommandText += " ,CARM.CARMNGCODERF";
                sqlCommand.CommandText += " ,CARM.CARMNGNORF";
                // --- ADD 2009/09/11 ----------<<<<<
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    carManagementList.Add(this.CopyToCarManagementWorkFromReader(ref myReader));
                }

                if (carManagementList.Count > 0)
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

        # region [SearchGuide]
        // --- ADD 2009/09/11 -------------->>>
        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carMngGuideWorkObj">��������</param>
        /// <param name="carMngWorkListObj">�ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/11</br>
        public int SearchGuide(object carMngGuideWorkObj, out object carMngWorkListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            carMngWorkListObj = new object();

            try
            {
                CarMngGuideParamWork carMngGuideWork = carMngGuideWorkObj as CarMngGuideParamWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                ArrayList carMngWorkList = new ArrayList();
                status = this.SearchGuideProc(carMngGuideWork, out carMngWorkList, sqlConnection, sqlTransaction);
                carMngWorkListObj = carMngWorkList as object;
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
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carManagementList">�ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="carMngGuideWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/11</br>
        /// <br>Update Note: 2013/03/22 FSI���� ���Y�O�ԋ敪�Ή�</br>
        private int SearchGuideProc(CarMngGuideParamWork carMngGuideWork, out ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            carManagementList = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CARM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CARM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CARM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CARM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,CARM.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,CARM.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICCODERF" + Environment.NewLine;
                sqlText += " ,CARM.SYSTEMATICNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                sqlText += " ,CARM.PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.DOORCOUNTRF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMECODERF" + Environment.NewLine;
                sqlText += " ,CARM.BODYNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,CARM.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.FRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.STPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.EDPRODUCEFRAMENORF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADENMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ENGINEDISPLACENMRF" + Environment.NewLine;
                sqlText += " ,CARM.EDIVNMRF" + Environment.NewLine;
                sqlText += " ,CARM.TRANSMISSIONNMRF" + Environment.NewLine;
                sqlText += " ,CARM.SHIFTNMRF" + Environment.NewLine;
                sqlText += " ,CARM.WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPEC6RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE1RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE2RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE3RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE4RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE5RF" + Environment.NewLine;
                sqlText += " ,CARM.ADDICARSPECTITLE6RF" + Environment.NewLine;
                sqlText += " ,CARM.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,CARM.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,CARM.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                sqlText += " ,CARM.THREEDILLUSTNORF" + Environment.NewLine;
                sqlText += " ,CARM.PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                sqlText += " ,CARM.INSPECTMATURITYDATERF" + Environment.NewLine;
                sqlText += " ,CARM.LTIMECIMATDATERF" + Environment.NewLine;
                sqlText += " ,CARM.CARINSPECTYEARRF" + Environment.NewLine;
                sqlText += " ,CARM.MILEAGERF" + Environment.NewLine;
                sqlText += " ,CARM.CARNORF" + Environment.NewLine;
                sqlText += " ,CARM.COLORCODERF" + Environment.NewLine;
                sqlText += " ,CARM.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,CARM.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,CARM.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CATEGORYOBJARYRF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO1RF" + Environment.NewLine;
                sqlText += " ,CARM.CARADDINFO2RF" + Environment.NewLine;
                sqlText += " ,CARM.CARNOTERF" + Environment.NewLine;
                // --- ADD 2010/04/27 -------------->>>>>
                sqlText += " ,CARM.FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                // --- ADD 2010/04/27 --------------<<<<<
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                // ADD 2013/03/22  -------------------->>>>>
                sqlText += " ,CARM.DOMESTICFOREIGNCODERF" + Environment.NewLine;
                sqlText += " ,CARM.HANDLEINFOCDRF" + Environment.NewLine;
                // ADD 2013/03/22  --------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                sqlText += " ,CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereStringForGuide(ref sqlCommand, carMngGuideWork);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                string customerName = string.Empty;

                while (myReader.Read())
                {
                    CarManagementWork carManagementWork = this.CopyToCarManagementWorkFromReader(ref myReader);
                    // ���Ӑ於��
                    customerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF")) + " " + 
                                          SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                    carManagementWork.CustomerName = customerName;

                    carManagementList.Add(carManagementWork);
                }

                if (carManagementList.Count > 0)
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
        // --- ADD 2009/09/11 --------------<<<
        # endregion

        # region [Write]
        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write(ref object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = carManagementList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // ������������ (�ԗ��Ǘ��ԍ��̍̔�)
                status = this.WriteInitial(ref paraList, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������
                    status = this.Write(ref paraList, sqlConnection, sqlTransaction);
                }
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
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���s���ׂ̏����������s���܂��B
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int WriteInitial(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (carManagementList != null && carManagementList.Count > 0)
                {
                    NumberingManager numberingManager = new NumberingManager();
                    long no = -1;
                    
                    foreach (CarManagementWork carManagementWork in carManagementList)
                    {
                        // --- ADD 2009/09/11 -------------->>>
                        if (carManagementWork.CarMngNo != 0)
                        {
                            // ���q�Ǘ��}�X�^���̎��q�Ǘ��ԍ���0�̏ꍇ�A���q�Ǘ��ԍ��̍̔ԏ������s��Ȃ�
                            continue;
                        }
                        // --- ADD 2009/09/11 --------------<<<

                        no = -1;
                        // �ԗ��Ǘ��ԍ����̔Ԃ���B�@�����_�Ǘ����s��Ȃ��̂ŋ��_�R�[�h�ɂ�"000000"���Œ�Őݒ肷��
                        status = numberingManager.GetSerialNumber(carManagementWork.EnterpriseCode, "000000", SerialNumberCode.CarMngNo, out no);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                        {
                            carManagementWork.CarMngNo = (int)no;
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref carManagementList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        private int WriteProc(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // 2009/12/24

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode.Trim()); // 2009/12/24

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            if (!this._CompulsoryDataOverride)
                            {
                                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                                if (_updateDateTime != carManagementWork.UpdateDateTime)
                                {
                                    if (carManagementWork.UpdateDateTime == DateTime.MinValue)
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
                            }
                            else
                            {
                                // �����I�Ƀf�[�^���㏑��������ׁA�쐬������t�@�C���w�b�_�[GUID���㏑�����Ă���
                                // ��fileHeader.SetUpdateHeader �ł͂����̍��ڂ��Z�b�g����Ȃ���
                                carManagementWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                                carManagementWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                 // GUID
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF = @CARMNGNO" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,ENTRYDATERF = @ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF = @MAKERCODE" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,MODELCODERF = @MODELCODE" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF = @MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF = @SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF = @SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF = @PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF = @PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF = @STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF = @EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF = @DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF = @BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF = @BODYNAME" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF = @FULLMODEL" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,FRAMENORF = @FRAMENO" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF = @STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF = @EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELRF = @ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF = @MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF = @ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF = @EDIVNM" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF = @TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF = @SHIFTNM" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF = @WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF = @ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF = @ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF = @ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF = @ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF = @ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF = @ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF = @ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF = @ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF = @ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF = @ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF = @ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF = @ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF = @BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF = @THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF = @PARTSDATAOFFERFLAG" + Environment.NewLine;
                            sqlText += " ,INSPECTMATURITYDATERF = @INSPECTMATURITYDATE" + Environment.NewLine;
                            sqlText += " ,LTIMECIMATDATERF = @LTIMECIMATDATE" + Environment.NewLine;
                            sqlText += " ,CARINSPECTYEARRF = @CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,MILEAGERF = @MILEAGE" + Environment.NewLine;
                            sqlText += " ,CARNORF = @CARNO" + Environment.NewLine;
                            sqlText += " ,COLORCODERF = @COLORCODE" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF = @COLORNAME1" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF = @TRIMCODE" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF = @TRIMNAME" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY" + Environment.NewLine;
                            // --- ADD 2009/09/11 -------------->>>
                            sqlText += " ,CARADDINFO1RF = @CARADDINFO1" + Environment.NewLine;
                            sqlText += " ,CARADDINFO2RF = @CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,CARNOTERF = @CARNOTE" + Environment.NewLine;
                            // --- ADD 2009/09/11 --------------<<<
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF = @HANDLEINFOCDRF" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); //2009/12/24

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (carManagementWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CARMANAGEMENTRF (" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF" + Environment.NewLine;
                            sqlText += " ,ENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELCODERF" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF" + Environment.NewLine;
                            sqlText += " ,FRAMENORF" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                            sqlText += " ,INSPECTMATURITYDATERF" + Environment.NewLine;
                            sqlText += " ,LTIMECIMATDATERF" + Environment.NewLine;
                            sqlText += " ,CARINSPECTYEARRF" + Environment.NewLine;
                            sqlText += " ,MILEAGERF" + Environment.NewLine;
                            sqlText += " ,CARNORF" + Environment.NewLine;
                            sqlText += " ,COLORCODERF" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            //sqlText += " ,CATEGORYOBJARYRF)" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF" + Environment.NewLine;
                            sqlText += " ,CARADDINFO1RF" + Environment.NewLine;
                            sqlText += " ,CARADDINFO2RF" + Environment.NewLine;
                            sqlText += " ,CARNOTERF" + Environment.NewLine;
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22 --------------------<<<<<
                            // --- UPD 2009/09/11 --------------<<<
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGNO" + Environment.NewLine;
                            sqlText += " ,@CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,@ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@MAKERCODE" + Environment.NewLine;
                            sqlText += " ,@MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,@MODELCODE" + Environment.NewLine;
                            sqlText += " ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,@MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,@BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,@BODYNAME" + Environment.NewLine;
                            sqlText += " ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,@FULLMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,@FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,@FRAMENO" + Environment.NewLine;
                            sqlText += " ,@SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,@EDIVNM" + Environment.NewLine;
                            sqlText += " ,@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,@SHIFTNM" + Environment.NewLine;
                            sqlText += " ,@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,@RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,@SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,@MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,@BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,@THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,@PARTSDATAOFFERFLAG" + Environment.NewLine;
                            sqlText += " ,@INSPECTMATURITYDATE" + Environment.NewLine;
                            sqlText += " ,@LTIMECIMATDATE" + Environment.NewLine;
                            sqlText += " ,@CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,@MILEAGE" + Environment.NewLine;
                            sqlText += " ,@CARNO" + Environment.NewLine;
                            sqlText += " ,@COLORCODE" + Environment.NewLine;
                            sqlText += " ,@COLORNAME1" + Environment.NewLine;
                            sqlText += " ,@TRIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRIMNAME" + Environment.NewLine;
                            sqlText += " ,@FULLMODELFIXEDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,@FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            // sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CARADDINFO1" + Environment.NewLine;
                            sqlText += " ,@CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,@CARNOTE" + Environment.NewLine;
                            // --- UPD 2009/09/11 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,@DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,@HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.CommandText = sqlText;

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);     // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);              // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);             // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);             // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);            // �_���폜�敪
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);                      // ���Ӑ�R�[�h
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                              // �ԗ��Ǘ��ԍ�
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                     // ���q�Ǘ��R�[�h
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);              // ���^�������ԍ�
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);         // ���^�����ǖ���
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                 // �ԗ��o�^�ԍ��i��ʁj
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                 // �ԗ��o�^�ԍ��i�J�i�j
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                      // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        SqlParameter paraEntryDate = sqlCommand.Parameters.Add("@ENTRYDATE", SqlDbType.Int);                            // �o�^�N����
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                  // ���N�x
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                            // ���[�J�[�R�[�h
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);               // ���[�J�[�S�p����
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);               // ���[�J�[���p����
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                            // �Ԏ�R�[�h
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                      // �Ԏ�T�u�R�[�h
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);               // �Ԏ�S�p����
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);               // �Ԏ피�p����
                        SqlParameter paraSystematicCode = sqlCommand.Parameters.Add("@SYSTEMATICCODE", SqlDbType.Int);                  // �n���R�[�h
                        SqlParameter paraSystematicName = sqlCommand.Parameters.Add("@SYSTEMATICNAME", SqlDbType.NVarChar);             // �n������
                        SqlParameter paraProduceTypeOfYearCd = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARCD", SqlDbType.Int);        // ���Y�N���R�[�h
                        SqlParameter paraProduceTypeOfYearNm = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARNM", SqlDbType.NVarChar);   // ���Y�N������
                        SqlParameter paraStProduceTypeOfYear = sqlCommand.Parameters.Add("@STPRODUCETYPEOFYEAR", SqlDbType.Int);        // �J�n���Y�N��
                        SqlParameter paraEdProduceTypeOfYear = sqlCommand.Parameters.Add("@EDPRODUCETYPEOFYEAR", SqlDbType.Int);        // �I�����Y�N��
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);                            // �h�A��
                        SqlParameter paraBodyNameCode = sqlCommand.Parameters.Add("@BODYNAMECODE", SqlDbType.Int);                      // �{�f�B�[���R�[�h
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);                         // �{�f�B�[����
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);             // �r�K�X�L��
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                   // �V���[�Y�^��
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);       // �^���i�ޕʋL���j
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                       // �^���i�t���^�j
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);          // �^���w��ԍ�
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                          // �ޕʔԍ�
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                     // �ԑ�^��
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                           // �ԑ�ԍ�
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                    // �ԑ�ԍ��i�����p�j
                        SqlParameter paraStProduceFrameNo = sqlCommand.Parameters.Add("@STPRODUCEFRAMENO", SqlDbType.Int);              // ���Y�ԑ�ԍ��J�n
                        SqlParameter paraEdProduceFrameNo = sqlCommand.Parameters.Add("@EDPRODUCEFRAMENO", SqlDbType.Int);              // ���Y�ԑ�ԍ��I��
                        SqlParameter paraEngineModel = sqlCommand.Parameters.Add("@ENGINEMODEL", SqlDbType.NVarChar);                   // �����@�^���i�G���W���j
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);                 // �^���O���[�h����
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);               // �G���W���^������
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);         // �r�C�ʖ���
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);                             // E�敪����
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);             // �~�b�V��������
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);                           // �V�t�g����
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);     // �쓮��������
                        SqlParameter paraAddiCarSpec1 = sqlCommand.Parameters.Add("@ADDICARSPEC1", SqlDbType.NVarChar);                 // �ǉ�����1
                        SqlParameter paraAddiCarSpec2 = sqlCommand.Parameters.Add("@ADDICARSPEC2", SqlDbType.NVarChar);                 // �ǉ�����2
                        SqlParameter paraAddiCarSpec3 = sqlCommand.Parameters.Add("@ADDICARSPEC3", SqlDbType.NVarChar);                 // �ǉ�����3
                        SqlParameter paraAddiCarSpec4 = sqlCommand.Parameters.Add("@ADDICARSPEC4", SqlDbType.NVarChar);                 // �ǉ�����4
                        SqlParameter paraAddiCarSpec5 = sqlCommand.Parameters.Add("@ADDICARSPEC5", SqlDbType.NVarChar);                 // �ǉ�����5
                        SqlParameter paraAddiCarSpec6 = sqlCommand.Parameters.Add("@ADDICARSPEC6", SqlDbType.NVarChar);                 // �ǉ�����6
                        SqlParameter paraAddiCarSpecTitle1 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE1", SqlDbType.NVarChar);       // �ǉ������^�C�g��1
                        SqlParameter paraAddiCarSpecTitle2 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE2", SqlDbType.NVarChar);       // �ǉ������^�C�g��2
                        SqlParameter paraAddiCarSpecTitle3 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE3", SqlDbType.NVarChar);       // �ǉ������^�C�g��3
                        SqlParameter paraAddiCarSpecTitle4 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE4", SqlDbType.NVarChar);       // �ǉ������^�C�g��4
                        SqlParameter paraAddiCarSpecTitle5 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE5", SqlDbType.NVarChar);       // �ǉ������^�C�g��5
                        SqlParameter paraAddiCarSpecTitle6 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE6", SqlDbType.NVarChar);       // �ǉ������^�C�g��6
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);             // �֘A�^��
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                          // �T�u�Ԗ��R�[�h
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);           // �^���O���[�h����
                        SqlParameter paraBlockIllustrationCd = sqlCommand.Parameters.Add("@BLOCKILLUSTRATIONCD", SqlDbType.Int);        // �u���b�N�C���X�g�R�[�h
                        SqlParameter paraThreeDIllustNo = sqlCommand.Parameters.Add("@THREEDILLUSTNO", SqlDbType.Int);                  // 3D�C���X�gNo
                        SqlParameter paraPartsDataOfferFlag = sqlCommand.Parameters.Add("@PARTSDATAOFFERFLAG", SqlDbType.Int);          // ���i�f�[�^�񋟃t���O
                        SqlParameter paraInspectMaturityDate = sqlCommand.Parameters.Add("@INSPECTMATURITYDATE", SqlDbType.Int);        // �Ԍ�������
                        SqlParameter paraLTimeCiMatDate = sqlCommand.Parameters.Add("@LTIMECIMATDATE", SqlDbType.Int);                  // �O��Ԍ�������
                        SqlParameter paraCarInspectYear = sqlCommand.Parameters.Add("@CARINSPECTYEAR", SqlDbType.Int);                  // �Ԍ�����
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                // �ԗ����s����
                        SqlParameter paraCarNo = sqlCommand.Parameters.Add("@CARNO", SqlDbType.NVarChar);                               // ����
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                       // �J���[�R�[�h
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                     // �J���[����1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                         // �g�����R�[�h
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                         // �g��������
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);  // �t���^���Œ�ԍ��z��
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);            // �����I�u�W�F�N�g�z��
                        // --- ADD 2010/04/27 -------------->>>
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // ���R�����^���Œ�ԍ��z��
                        // --- ADD 2010/04/27 --------------<<<
                        // --- ADD 2009/09/11 -------------->>>
                        SqlParameter paraCarAddInfo1 = sqlCommand.Parameters.Add("@CARADDINFO1", SqlDbType.NVarChar);                   // ���q�ǉ����P
                        SqlParameter paraCarAddInfo2 = sqlCommand.Parameters.Add("@CARADDINFO2", SqlDbType.NVarChar);                   // ���q�ǉ����Q
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);                           // ���q���l
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODERF", SqlDbType.Int);      // ���Y/�O�ԋ敪
                        SqlParameter paraHandleInfoCode = sqlCommand.Parameters.Add("@HANDLEINFOCDRF", SqlDbType.Int);                  // �n���h���ʒu���
                        // ADD 2013/03/22  --------------------<<<<<             
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.CreateDateTime);               // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.UpdateDateTime);               // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);                          // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(carManagementWork.FileHeaderGuid);                            // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdEmployeeCode);                        // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId1);                          // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId2);                          // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.LogicalDeleteCode);                     // �_���폜�敪
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);                               // ���Ӑ�R�[�h
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);                                       // �ԗ��Ǘ��ԍ�
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode);                                  // ���q�Ǘ��R�[�h
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate1Code);                       // ���^�������ԍ�
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate1Name);                      // ���^�����ǖ���
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate2);                              // �ԗ��o�^�ԍ��i��ʁj
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate3);                              // �ԗ��o�^�ԍ��i�J�i�j
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate4);                               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        paraEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.EntryDate);                      // �o�^�N����
                        //paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.FirstEntryDate);              // ���N�x
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(carManagementWork.FirstEntryDate);                           // ���N�x
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.MakerCode);                                     // ���[�J�[�R�[�h
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerFullName);                            // ���[�J�[�S�p����
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerHalfName);                            // ���[�J�[���p����                        
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelCode);                                     // �Ԏ�R�[�h
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelSubCode);                               // �Ԏ�T�u�R�[�h
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelFullName);                            // �Ԏ�S�p����
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelHalfName);                            // �Ԏ피�p����
                        paraSystematicCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SystematicCode);                           // �n���R�[�h
                        paraSystematicName.Value = SqlDataMediator.SqlSetString(carManagementWork.SystematicName);                          // �n������
                        paraProduceTypeOfYearCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ProduceTypeOfYearCd);                 // ���Y�N���R�[�h
                        paraProduceTypeOfYearNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ProduceTypeOfYearNm);                // ���Y�N������
                        paraStProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.StProduceTypeOfYear);    // �J�n���Y�N��
                        paraEdProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.EdProduceTypeOfYear);    // �I�����Y�N��
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DoorCount);                                     // �h�A��
                        paraBodyNameCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BodyNameCode);                               // �{�f�B�[���R�[�h
                        paraBodyName.Value = SqlDataMediator.SqlSetString(carManagementWork.BodyName);                                      // �{�f�B�[����
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(carManagementWork.ExhaustGasSign);                          // �r�K�X�L��
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(carManagementWork.SeriesModel);                                // �V���[�Y�^��
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(carManagementWork.CategorySignModel);                    // �^���i�ޕʋL���j
                        paraFullModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FullModel);                                    // �^���i�t���^�j
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelDesignationNo);                   // �^���w��ԍ�
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CategoryNo);                                   // �ޕʔԍ�
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameModel);                                  // �ԑ�^��
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameNo);                                        // �ԑ�ԍ�
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SearchFrameNo);                             // �ԑ�ԍ��i�����p�j
                        paraStProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.StProduceFrameNo);                       // ���Y�ԑ�ԍ��J�n
                        paraEdProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.EdProduceFrameNo);                       // ���Y�ԑ�ԍ��I��
                        paraEngineModel.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModel);                                // �����@�^���i�G���W���j
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeNm);                              // �^���O���[�h����
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModelNm);                            // �G���W���^������
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineDisplaceNm);                      // �r�C�ʖ���
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EDivNm);                                          // E�敪����
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(carManagementWork.TransmissionNm);                          // �~�b�V��������
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ShiftNm);                                        // �V�t�g����
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(carManagementWork.WheelDriveMethodNm);                  // �쓮��������
                        paraAddiCarSpec1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec1);                              // �ǉ�����1
                        paraAddiCarSpec2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec2);                              // �ǉ�����2
                        paraAddiCarSpec3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec3);                              // �ǉ�����3
                        paraAddiCarSpec4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec4);                              // �ǉ�����4
                        paraAddiCarSpec5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec5);                              // �ǉ�����5
                        paraAddiCarSpec6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec6);                              // �ǉ�����6
                        paraAddiCarSpecTitle1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle1);                    // �ǉ������^�C�g��1
                        paraAddiCarSpecTitle2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle2);                    // �ǉ������^�C�g��2
                        paraAddiCarSpecTitle3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle3);                    // �ǉ������^�C�g��3
                        paraAddiCarSpecTitle4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle4);                    // �ǉ������^�C�g��4
                        paraAddiCarSpecTitle5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle5);                    // �ǉ������^�C�g��5
                        paraAddiCarSpecTitle6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle6);                    // �ǉ������^�C�g��6
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(carManagementWork.RelevanceModel);                          // �֘A�^��
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SubCarNmCd);                                   // �T�u�Ԗ��R�[�h
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeSname);                        // �^���O���[�h����
                        paraBlockIllustrationCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BlockIllustrationCd);                 // �u���b�N�C���X�g�R�[�h
                        paraThreeDIllustNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ThreeDIllustNo);                           // 3D�C���X�gNo
                        paraPartsDataOfferFlag.Value = SqlDataMediator.SqlSetInt32(carManagementWork.PartsDataOfferFlag);                   // ���i�f�[�^�񋟃t���O
                        paraInspectMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.InspectMaturityDate);  // �Ԍ�������
                        paraLTimeCiMatDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.LTimeCiMatDate);            // �O��Ԍ�������
                        paraCarInspectYear.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarInspectYear);                           // �Ԍ�����
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(carManagementWork.Mileage);                                         // �ԗ����s����
                        paraCarNo.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNo);                                            // ����
                        paraColorCode.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorCode);                                    // �J���[�R�[�h
                        paraColorName1.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorName1);                                  // �J���[����1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimCode);                                      // �g�����R�[�h
                        paraTrimName.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimName);                                      // �g��������
                        // --- ADD 2009/09/11 -------------->>>
                        paraCarAddInfo1.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo1);                                // ���q�ǉ����P
                        paraCarAddInfo2.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo2);                                // ���q�ǉ����Q
                        paraCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote);                                        // ���q���l
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DomesticForeignCode);                 // ���Y/�O�ԋ敪�R�[�h
                        paraHandleInfoCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.HandleInfoCode);                           // �n���h���ʒu���R�[�h
                        // ADD 2013/03/22  --------------------<<<<<

                        // int[] �� byte[] �ɕϊ�
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in carManagementWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                                            // �t���^���Œ�ԍ��z��
                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.CategoryObjAry);                          // �����I�u�W�F�N�g�z��
                        // --- ADD 2010/04/27 -------------->>>
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.FreeSrchMdlFxdNoAry);                                            // ���R�����^���Œ�ԍ��z��
                        // --- ADD 2010/04/27 --------------<<<
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(carManagementWork);
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

            carManagementList = al;

            return status;
        }
        # endregion

        // ADD 2012/08/29 Wakita -------------------->>>>>
        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B�i����`�[���͍X�V��p�j
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write2(ref object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = carManagementList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // ������������ (�ԗ��Ǘ��ԍ��̍̔�)
                status = this.WriteInitial(ref paraList, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������
                    status = this.Write2(ref paraList, sqlConnection, sqlTransaction);
                }
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
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B�i����`�[���͍X�V��p�j
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int Write2(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc2(ref carManagementList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        private int WriteProc2(ref ArrayList carManagementList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;
                        // --- ADD 2015/03/23 T.Miyamoto ���V�o�����Q�Ή� -------------------->>>>>
                        // ���q�Ǘ��R�[�h����܂���NULL�̏ꍇ�͓o�^���������s���Ȃ�
                        if (string.IsNullOrEmpty(carManagementWork.CarMngCode.Trim()))
                        {
                            al.Add(carManagementWork);
                            continue;
                        }
                        // --- ADD 2015/03/23 T.Miyamoto ���V�o�����Q�Ή� --------------------<<<<<

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // 2009/12/24

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode.Trim()); // 2009/12/24

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            if (!this._CompulsoryDataOverride)
                            {
                                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                                if (_updateDateTime != carManagementWork.UpdateDateTime)
                                {
                                    if (carManagementWork.UpdateDateTime == DateTime.MinValue)
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
                            }
                            else
                            {
                                // �����I�Ƀf�[�^���㏑��������ׁA�쐬������t�@�C���w�b�_�[GUID���㏑�����Ă���
                                // ��fileHeader.SetUpdateHeader �ł͂����̍��ڂ��Z�b�g����Ȃ���
                                carManagementWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                                carManagementWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                 // GUID
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF = @CARMNGNO" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4" + Environment.NewLine;
                            //sqlText += " ,ENTRYDATERF = @ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF = @MAKERCODE" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,MODELCODERF = @MODELCODE" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF = @MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF = @SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF = @SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF = @PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF = @PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF = @STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF = @EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF = @DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF = @BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF = @BODYNAME" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF = @FULLMODEL" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,FRAMENORF = @FRAMENO" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF = @STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF = @EDPRODUCEFRAMENO" + Environment.NewLine;
                            //sqlText += " ,ENGINEMODELRF = @ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF = @MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF = @ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF = @EDIVNM" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF = @TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF = @SHIFTNM" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF = @WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF = @ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF = @ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF = @ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF = @ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF = @ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF = @ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF = @ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF = @ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF = @ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF = @ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF = @ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF = @ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF = @BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF = @THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF = @PARTSDATAOFFERFLAG" + Environment.NewLine;
                            //sqlText += " ,INSPECTMATURITYDATERF = @INSPECTMATURITYDATE" + Environment.NewLine;
                            //sqlText += " ,LTIMECIMATDATERF = @LTIMECIMATDATE" + Environment.NewLine;
                            //sqlText += " ,CARINSPECTYEARRF = @CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,MILEAGERF = @MILEAGE" + Environment.NewLine;
                            sqlText += " ,CARNORF = @CARNO" + Environment.NewLine;
                            sqlText += " ,COLORCODERF = @COLORCODE" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF = @COLORNAME1" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF = @TRIMCODE" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF = @TRIMNAME" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY" + Environment.NewLine;
                            // --- ADD 2009/09/11 -------------->>>
                            //sqlText += " ,CARADDINFO1RF = @CARADDINFO1" + Environment.NewLine;
                            //sqlText += " ,CARADDINFO2RF = @CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,CARNOTERF = @CARNOTE" + Environment.NewLine;
                            // --- ADD 2009/09/11 --------------<<<
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF = @HANDLEINFOCDRF" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // 2009/12/24
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); //2009/12/24

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (carManagementWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CARMANAGEMENTRF (" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF" + Environment.NewLine;
                            //sqlText += " ,ENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELCODERF" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICCODERF" + Environment.NewLine;
                            sqlText += " ,SYSTEMATICNAMERF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARCDRF" + Environment.NewLine;
                            sqlText += " ,PRODUCETYPEOFYEARNMRF" + Environment.NewLine;
                            sqlText += " ,STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += " ,DOORCOUNTRF" + Environment.NewLine;
                            sqlText += " ,BODYNAMECODERF" + Environment.NewLine;
                            sqlText += " ,BODYNAMERF" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF" + Environment.NewLine;
                            sqlText += " ,FRAMENORF" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF" + Environment.NewLine;
                            sqlText += " ,STPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += " ,EDPRODUCEFRAMENORF" + Environment.NewLine;
                            //sqlText += " ,ENGINEMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADENMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += " ,ENGINEDISPLACENMRF" + Environment.NewLine;
                            sqlText += " ,EDIVNMRF" + Environment.NewLine;
                            sqlText += " ,TRANSMISSIONNMRF" + Environment.NewLine;
                            sqlText += " ,SHIFTNMRF" + Environment.NewLine;
                            sqlText += " ,WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPEC6RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE1RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE2RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE3RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE4RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE5RF" + Environment.NewLine;
                            sqlText += " ,ADDICARSPECTITLE6RF" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF" + Environment.NewLine;
                            sqlText += " ,BLOCKILLUSTRATIONCDRF" + Environment.NewLine;
                            sqlText += " ,THREEDILLUSTNORF" + Environment.NewLine;
                            sqlText += " ,PARTSDATAOFFERFLAGRF" + Environment.NewLine;
                            //sqlText += " ,INSPECTMATURITYDATERF" + Environment.NewLine;
                            //sqlText += " ,LTIMECIMATDATERF" + Environment.NewLine;
                            //sqlText += " ,CARINSPECTYEARRF" + Environment.NewLine;
                            sqlText += " ,MILEAGERF" + Environment.NewLine;
                            sqlText += " ,CARNORF" + Environment.NewLine;
                            sqlText += " ,COLORCODERF" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,FREESRCHMDLFXDNOARYRF" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            //sqlText += " ,CATEGORYOBJARYRF)" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF" + Environment.NewLine;
                            //sqlText += " ,CARADDINFO1RF" + Environment.NewLine;
                            //sqlText += " ,CARADDINFO2RF" + Environment.NewLine;
                            sqlText += " ,CARNOTERF" + Environment.NewLine;
                            // --- UPD 2009/09/11 --------------<<<
                            // ADD 2013/03/22 -------------------->>>>>
                            sqlText += " ,DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22 --------------------<<<<<
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGNO" + Environment.NewLine;
                            sqlText += " ,@CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE4" + Environment.NewLine;
                            //sqlText += " ,@ENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@MAKERCODE" + Environment.NewLine;
                            sqlText += " ,@MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,@MODELCODE" + Environment.NewLine;
                            sqlText += " ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,@MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICCODE" + Environment.NewLine;
                            sqlText += " ,@SYSTEMATICNAME" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARCD" + Environment.NewLine;
                            sqlText += " ,@PRODUCETYPEOFYEARNM" + Environment.NewLine;
                            sqlText += " ,@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " ,@DOORCOUNT" + Environment.NewLine;
                            sqlText += " ,@BODYNAMECODE" + Environment.NewLine;
                            sqlText += " ,@BODYNAME" + Environment.NewLine;
                            sqlText += " ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,@FULLMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,@FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,@FRAMENO" + Environment.NewLine;
                            sqlText += " ,@SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " ,@EDPRODUCEFRAMENO" + Environment.NewLine;
                            //sqlText += " ,@ENGINEMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELGRADENM" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " ,@EDIVNM" + Environment.NewLine;
                            sqlText += " ,@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " ,@SHIFTNM" + Environment.NewLine;
                            sqlText += " ,@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPEC6" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE1" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE2" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE3" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE4" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE5" + Environment.NewLine;
                            sqlText += " ,@ADDICARSPECTITLE6" + Environment.NewLine;
                            sqlText += " ,@RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,@SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,@MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,@BLOCKILLUSTRATIONCD" + Environment.NewLine;
                            sqlText += " ,@THREEDILLUSTNO" + Environment.NewLine;
                            sqlText += " ,@PARTSDATAOFFERFLAG" + Environment.NewLine;
                            //sqlText += " ,@INSPECTMATURITYDATE" + Environment.NewLine;
                            //sqlText += " ,@LTIMECIMATDATE" + Environment.NewLine;
                            //sqlText += " ,@CARINSPECTYEAR" + Environment.NewLine;
                            sqlText += " ,@MILEAGE" + Environment.NewLine;
                            sqlText += " ,@CARNO" + Environment.NewLine;
                            sqlText += " ,@COLORCODE" + Environment.NewLine;
                            sqlText += " ,@COLORNAME1" + Environment.NewLine;
                            sqlText += " ,@TRIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRIMNAME" + Environment.NewLine;
                            sqlText += " ,@FULLMODELFIXEDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 -------------->>>
                            sqlText += " ,@FREESRCHMDLFXDNOARY" + Environment.NewLine;
                            // --- ADD 2010/04/27 --------------<<<
                            // --- UPD 2009/09/11 -------------->>>
                            // sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            //sqlText += " ,@CARADDINFO1" + Environment.NewLine;
                            //sqlText += " ,@CARADDINFO2" + Environment.NewLine;
                            sqlText += " ,@CARNOTE" + Environment.NewLine;
                            // --- UPD 2009/09/11 --------------<<<
                            // ADD 2013/03/22  -------------------->>>>>
                            sqlText += " ,@DOMESTICFOREIGNCODERF" + Environment.NewLine;
                            sqlText += " ,@HANDLEINFOCDRF)" + Environment.NewLine;
                            // ADD 2013/03/22  --------------------<<<<<
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.CommandText = sqlText;

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);     // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);              // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);             // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);             // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);            // �_���폜�敪
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);                      // ���Ӑ�R�[�h
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                              // �ԗ��Ǘ��ԍ�
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                     // ���q�Ǘ��R�[�h
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);              // ���^�������ԍ�
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);         // ���^�����ǖ���
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                 // �ԗ��o�^�ԍ��i��ʁj
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                 // �ԗ��o�^�ԍ��i�J�i�j
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                      // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        //SqlParameter paraEntryDate = sqlCommand.Parameters.Add("@ENTRYDATE", SqlDbType.Int);                            // �o�^�N����
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                  // ���N�x
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                            // ���[�J�[�R�[�h
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);               // ���[�J�[�S�p����
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);               // ���[�J�[���p����
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                            // �Ԏ�R�[�h
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                      // �Ԏ�T�u�R�[�h
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);               // �Ԏ�S�p����
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);               // �Ԏ피�p����
                        SqlParameter paraSystematicCode = sqlCommand.Parameters.Add("@SYSTEMATICCODE", SqlDbType.Int);                  // �n���R�[�h
                        SqlParameter paraSystematicName = sqlCommand.Parameters.Add("@SYSTEMATICNAME", SqlDbType.NVarChar);             // �n������
                        SqlParameter paraProduceTypeOfYearCd = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARCD", SqlDbType.Int);        // ���Y�N���R�[�h
                        SqlParameter paraProduceTypeOfYearNm = sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARNM", SqlDbType.NVarChar);   // ���Y�N������
                        SqlParameter paraStProduceTypeOfYear = sqlCommand.Parameters.Add("@STPRODUCETYPEOFYEAR", SqlDbType.Int);        // �J�n���Y�N��
                        SqlParameter paraEdProduceTypeOfYear = sqlCommand.Parameters.Add("@EDPRODUCETYPEOFYEAR", SqlDbType.Int);        // �I�����Y�N��
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);                            // �h�A��
                        SqlParameter paraBodyNameCode = sqlCommand.Parameters.Add("@BODYNAMECODE", SqlDbType.Int);                      // �{�f�B�[���R�[�h
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);                         // �{�f�B�[����
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);             // �r�K�X�L��
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                   // �V���[�Y�^��
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);       // �^���i�ޕʋL���j
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                       // �^���i�t���^�j
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);          // �^���w��ԍ�
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                          // �ޕʔԍ�
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                     // �ԑ�^��
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                           // �ԑ�ԍ�
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                    // �ԑ�ԍ��i�����p�j
                        SqlParameter paraStProduceFrameNo = sqlCommand.Parameters.Add("@STPRODUCEFRAMENO", SqlDbType.Int);              // ���Y�ԑ�ԍ��J�n
                        SqlParameter paraEdProduceFrameNo = sqlCommand.Parameters.Add("@EDPRODUCEFRAMENO", SqlDbType.Int);              // ���Y�ԑ�ԍ��I��
                        //SqlParameter paraEngineModel = sqlCommand.Parameters.Add("@ENGINEMODEL", SqlDbType.NVarChar);                   // �����@�^���i�G���W���j
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);                 // �^���O���[�h����
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);               // �G���W���^������
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);         // �r�C�ʖ���
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);                             // E�敪����
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);             // �~�b�V��������
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);                           // �V�t�g����
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);     // �쓮��������
                        SqlParameter paraAddiCarSpec1 = sqlCommand.Parameters.Add("@ADDICARSPEC1", SqlDbType.NVarChar);                 // �ǉ�����1
                        SqlParameter paraAddiCarSpec2 = sqlCommand.Parameters.Add("@ADDICARSPEC2", SqlDbType.NVarChar);                 // �ǉ�����2
                        SqlParameter paraAddiCarSpec3 = sqlCommand.Parameters.Add("@ADDICARSPEC3", SqlDbType.NVarChar);                 // �ǉ�����3
                        SqlParameter paraAddiCarSpec4 = sqlCommand.Parameters.Add("@ADDICARSPEC4", SqlDbType.NVarChar);                 // �ǉ�����4
                        SqlParameter paraAddiCarSpec5 = sqlCommand.Parameters.Add("@ADDICARSPEC5", SqlDbType.NVarChar);                 // �ǉ�����5
                        SqlParameter paraAddiCarSpec6 = sqlCommand.Parameters.Add("@ADDICARSPEC6", SqlDbType.NVarChar);                 // �ǉ�����6
                        SqlParameter paraAddiCarSpecTitle1 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE1", SqlDbType.NVarChar);       // �ǉ������^�C�g��1
                        SqlParameter paraAddiCarSpecTitle2 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE2", SqlDbType.NVarChar);       // �ǉ������^�C�g��2
                        SqlParameter paraAddiCarSpecTitle3 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE3", SqlDbType.NVarChar);       // �ǉ������^�C�g��3
                        SqlParameter paraAddiCarSpecTitle4 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE4", SqlDbType.NVarChar);       // �ǉ������^�C�g��4
                        SqlParameter paraAddiCarSpecTitle5 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE5", SqlDbType.NVarChar);       // �ǉ������^�C�g��5
                        SqlParameter paraAddiCarSpecTitle6 = sqlCommand.Parameters.Add("@ADDICARSPECTITLE6", SqlDbType.NVarChar);       // �ǉ������^�C�g��6
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);             // �֘A�^��
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                          // �T�u�Ԗ��R�[�h
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);           // �^���O���[�h����
                        SqlParameter paraBlockIllustrationCd = sqlCommand.Parameters.Add("@BLOCKILLUSTRATIONCD", SqlDbType.Int);        // �u���b�N�C���X�g�R�[�h
                        SqlParameter paraThreeDIllustNo = sqlCommand.Parameters.Add("@THREEDILLUSTNO", SqlDbType.Int);                  // 3D�C���X�gNo
                        SqlParameter paraPartsDataOfferFlag = sqlCommand.Parameters.Add("@PARTSDATAOFFERFLAG", SqlDbType.Int);          // ���i�f�[�^�񋟃t���O
                        //SqlParameter paraInspectMaturityDate = sqlCommand.Parameters.Add("@INSPECTMATURITYDATE", SqlDbType.Int);        // �Ԍ�������
                        //SqlParameter paraLTimeCiMatDate = sqlCommand.Parameters.Add("@LTIMECIMATDATE", SqlDbType.Int);                  // �O��Ԍ�������
                        //SqlParameter paraCarInspectYear = sqlCommand.Parameters.Add("@CARINSPECTYEAR", SqlDbType.Int);                  // �Ԍ�����
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                // �ԗ����s����
                        SqlParameter paraCarNo = sqlCommand.Parameters.Add("@CARNO", SqlDbType.NVarChar);                               // ����
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                       // �J���[�R�[�h
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                     // �J���[����1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                         // �g�����R�[�h
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                         // �g��������
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);  // �t���^���Œ�ԍ��z��
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);            // �����I�u�W�F�N�g�z��
                        // --- ADD 2010/04/27 -------------->>>
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // ���R�����^���Œ�ԍ��z��
                        // --- ADD 2010/04/27 --------------<<<
                        // --- ADD 2009/09/11 -------------->>>
                        //SqlParameter paraCarAddInfo1 = sqlCommand.Parameters.Add("@CARADDINFO1", SqlDbType.NVarChar);                   // ���q�ǉ����P
                        //SqlParameter paraCarAddInfo2 = sqlCommand.Parameters.Add("@CARADDINFO2", SqlDbType.NVarChar);                   // ���q�ǉ����Q
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);                           // ���q���l
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODERF", SqlDbType.Int);      // ���Y/�O�ԋ敪
                        SqlParameter paraHandleInfoCode = sqlCommand.Parameters.Add("@HANDLEINFOCDRF", SqlDbType.Int);                  // �n���h���ʒu���
                        // ADD 2013/03/22  --------------------<<<<<

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.CreateDateTime);               // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.UpdateDateTime);               // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);                          // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(carManagementWork.FileHeaderGuid);                            // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdEmployeeCode);                        // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId1);                          // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId2);                          // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.LogicalDeleteCode);                     // �_���폜�敪
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);                               // ���Ӑ�R�[�h
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);                                       // �ԗ��Ǘ��ԍ�
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode);                                  // ���q�Ǘ��R�[�h
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate1Code);                       // ���^�������ԍ�
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate1Name);                      // ���^�����ǖ���
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate2);                              // �ԗ��o�^�ԍ��i��ʁj
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(carManagementWork.NumberPlate3);                              // �ԗ��o�^�ԍ��i�J�i�j
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(carManagementWork.NumberPlate4);                               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        //paraEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.EntryDate);                      // �o�^�N����
                        //paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.FirstEntryDate);              // ���N�x
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(carManagementWork.FirstEntryDate);                           // ���N�x
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.MakerCode);                                     // ���[�J�[�R�[�h
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerFullName);                            // ���[�J�[�S�p����
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.MakerHalfName);                            // ���[�J�[���p����                        
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelCode);                                     // �Ԏ�R�[�h
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelSubCode);                               // �Ԏ�T�u�R�[�h
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelFullName);                            // �Ԏ�S�p����
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelHalfName);                            // �Ԏ피�p����
                        paraSystematicCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SystematicCode);                           // �n���R�[�h
                        paraSystematicName.Value = SqlDataMediator.SqlSetString(carManagementWork.SystematicName);                          // �n������
                        paraProduceTypeOfYearCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ProduceTypeOfYearCd);                 // ���Y�N���R�[�h
                        paraProduceTypeOfYearNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ProduceTypeOfYearNm);                // ���Y�N������
                        paraStProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.StProduceTypeOfYear);    // �J�n���Y�N��
                        paraEdProduceTypeOfYear.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(carManagementWork.EdProduceTypeOfYear);    // �I�����Y�N��
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DoorCount);                                     // �h�A��
                        paraBodyNameCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BodyNameCode);                               // �{�f�B�[���R�[�h
                        paraBodyName.Value = SqlDataMediator.SqlSetString(carManagementWork.BodyName);                                      // �{�f�B�[����
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(carManagementWork.ExhaustGasSign);                          // �r�K�X�L��
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(carManagementWork.SeriesModel);                                // �V���[�Y�^��
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(carManagementWork.CategorySignModel);                    // �^���i�ޕʋL���j
                        paraFullModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FullModel);                                    // �^���i�t���^�j
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ModelDesignationNo);                   // �^���w��ԍ�
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CategoryNo);                                   // �ޕʔԍ�
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameModel);                                  // �ԑ�^��
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(carManagementWork.FrameNo);                                        // �ԑ�ԍ�
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SearchFrameNo);                             // �ԑ�ԍ��i�����p�j
                        paraStProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.StProduceFrameNo);                       // ���Y�ԑ�ԍ��J�n
                        paraEdProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.EdProduceFrameNo);                       // ���Y�ԑ�ԍ��I��
                        //paraEngineModel.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModel);                                // �����@�^���i�G���W���j
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeNm);                              // �^���O���[�h����
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineModelNm);                            // �G���W���^������
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EngineDisplaceNm);                      // �r�C�ʖ���
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(carManagementWork.EDivNm);                                          // E�敪����
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(carManagementWork.TransmissionNm);                          // �~�b�V��������
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(carManagementWork.ShiftNm);                                        // �V�t�g����
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(carManagementWork.WheelDriveMethodNm);                  // �쓮��������
                        paraAddiCarSpec1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec1);                              // �ǉ�����1
                        paraAddiCarSpec2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec2);                              // �ǉ�����2
                        paraAddiCarSpec3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec3);                              // �ǉ�����3
                        paraAddiCarSpec4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec4);                              // �ǉ�����4
                        paraAddiCarSpec5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec5);                              // �ǉ�����5
                        paraAddiCarSpec6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpec6);                              // �ǉ�����6
                        paraAddiCarSpecTitle1.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle1);                    // �ǉ������^�C�g��1
                        paraAddiCarSpecTitle2.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle2);                    // �ǉ������^�C�g��2
                        paraAddiCarSpecTitle3.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle3);                    // �ǉ������^�C�g��3
                        paraAddiCarSpecTitle4.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle4);                    // �ǉ������^�C�g��4
                        paraAddiCarSpecTitle5.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle5);                    // �ǉ������^�C�g��5
                        paraAddiCarSpecTitle6.Value = SqlDataMediator.SqlSetString(carManagementWork.AddiCarSpecTitle6);                    // �ǉ������^�C�g��6
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(carManagementWork.RelevanceModel);                          // �֘A�^��
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.SubCarNmCd);                                   // �T�u�Ԗ��R�[�h
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(carManagementWork.ModelGradeSname);                        // �^���O���[�h����
                        paraBlockIllustrationCd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.BlockIllustrationCd);                 // �u���b�N�C���X�g�R�[�h
                        paraThreeDIllustNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.ThreeDIllustNo);                           // 3D�C���X�gNo
                        paraPartsDataOfferFlag.Value = SqlDataMediator.SqlSetInt32(carManagementWork.PartsDataOfferFlag);                   // ���i�f�[�^�񋟃t���O
                        //paraInspectMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.InspectMaturityDate);  // �Ԍ�������
                        //paraLTimeCiMatDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(carManagementWork.LTimeCiMatDate);            // �O��Ԍ�������
                        //paraCarInspectYear.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarInspectYear);                           // �Ԍ�����
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(carManagementWork.Mileage);                                         // �ԗ����s����
                        paraCarNo.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNo);                                            // ����
                        paraColorCode.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorCode);                                    // �J���[�R�[�h
                        paraColorName1.Value = SqlDataMediator.SqlSetString(carManagementWork.ColorName1);                                  // �J���[����1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimCode);                                      // �g�����R�[�h
                        paraTrimName.Value = SqlDataMediator.SqlSetString(carManagementWork.TrimName);                                      // �g��������
                        // --- ADD 2009/09/11 -------------->>>
                        //paraCarAddInfo1.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo1);                                // ���q�ǉ����P
                        //paraCarAddInfo2.Value = SqlDataMediator.SqlSetString(carManagementWork.CarAddInfo2);                                // ���q�ǉ����Q
                        paraCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote);                                        // ���q���l
                        // --- ADD 2009/09/11 --------------<<<
                        // ADD 2013/03/22  -------------------->>>>>
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.DomesticForeignCode);                 // ���Y/�O�ԋ敪
                        paraHandleInfoCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.HandleInfoCode);                           // �n���h���ʒu���
                        // ADD 2013/03/22  --------------------<<<<<     
                        // int[] �� byte[] �ɕϊ�
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in carManagementWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                                            // �t���^���Œ�ԍ��z��
                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.CategoryObjAry);                          // �����I�u�W�F�N�g�z��
                        // --- ADD 2010/04/27 -------------->>>
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(carManagementWork.FreeSrchMdlFxdNoAry);                                            // ���R�����^���Œ�ԍ��z��
                        // --- ADD 2010/04/27 --------------<<<
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(carManagementWork);
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

            carManagementList = al;

            return status;
        }
        // ADD 2012/08/29 Wakita --------------------<<<<<

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        # region [LogicalDelete]
        /// <summary>
        /// �ԗ��Ǘ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int LogicalDelete(ref object carManagementList)
        {
            return this.LogicalDelete(ref carManagementList, 0);
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜����������ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int RevivalLogicalDelete(ref object carManagementList)
        {
            return this.LogicalDelete(ref carManagementList, 1);
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜�𑀍삷��ԗ��Ǘ��}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        private int LogicalDelete(ref object carManagementList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = carManagementList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, sqlConnection, sqlTransaction);
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
        /// �ԗ��Ǘ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜�𑀍삷��ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        public int LogicalDelete(ref ArrayList carManagementList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref carManagementList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜�𑀍삷��ԗ��Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2013/01/11 �����M</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#32256 ���q�Ǘ��}�X�^�ɍ폜�ς݂̃f�[�^�������Ɗ��S�폜����ł��Ȃ���Q�̏C��</br>
        private int LogicalDeleteProc(ref ArrayList carManagementList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (carManagementList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < carManagementList.Count; i++)
                    {
                        CarManagementWork carManagementWork = carManagementList[i] as CarManagementWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CARM.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CARM.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CARMANAGEMENTRF AS CARM" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                        sqlText += "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD �����M 2013/01/11 for redmine 32256
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
                        SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar); // ADD �����M 2013/01/11 for redmine 32256

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                        findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                        findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD �����M 2013/01/11 for redmine 32256

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != carManagementWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CARMANAGEMENTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
                            sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD �����M 2013/01/11 for redmine 32256
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
                            findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
                            findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode); // ADD �����M 2013/01/11 for redmine 32256

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)carManagementWork;
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
                            else if (logicalDelCd == 0) carManagementWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else carManagementWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                carManagementWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(carManagementWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(carManagementWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(carManagementWork);
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

            carManagementList = al;

            return status;
        }
        # endregion

        # region [WriteAndLogicDelete]
        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̏����Ƙ_���폜�����B
        /// </summary>
        /// <param name="carManagementList">�_���폜����Ə�������ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���������Ƙ_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int WriteAndLogicDelete(ref object carManagementList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                CustomSerializeArrayList paraList = carManagementList as CustomSerializeArrayList;

                ArrayList updateDataList = paraList[0] as ArrayList;
                ArrayList logicDeleteDataList = paraList[1] as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (updateDataList.Count > 0)
                {
                    // ������������ (�ԗ��Ǘ��ԍ��̍̔�)
                    status = this.WriteInitial(ref updateDataList, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ��������
                        status = this.Write(ref updateDataList, sqlConnection, sqlTransaction);
                    }
                }

                if (logicDeleteDataList.Count > 0)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �_���폜����
                        status = this.LogicalDelete(ref logicDeleteDataList, 0, sqlConnection, sqlTransaction);
                    }
                }

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
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="carManagementWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2009/09/11 ����� LDNS�J���Ή�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CarManagementWork carManagementWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carManagementWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND CARM.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND CARM.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // --- DEL 2009/09/11 ---------->>>>>
            // �ԗ��Ǘ��ԍ�
            //SqlParameter findCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
            //findCarMngNo.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CarMngNo);
            //--- DEL 2009/09/11 ----------<<<<<

            // --- ADD 2009/09/11 ---------->>>>>
            // ���q�Ǘ��R�[�h
            //wkstring = "";
            if (carManagementWork.CarMngCode != string.Empty)
            {
                if (carManagementWork.CarMngCodeSearchDiv == 0)
                {
                    wkstring = "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode);
                }
                else if (carManagementWork.CarMngCodeSearchDiv == 1)
                {
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carManagementWork.CarMngCode + "%");
                }
                else if (carManagementWork.CarMngCodeSearchDiv == 2)
                {
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarMngCode + "%");
                }
                else
                {
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarMngCode);
                }
            }

            // ���Ӑ�
            if (carManagementWork.CustomerCode != 0)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCode);
            }

            // ���Ӑ�J�n
            if (carManagementWork.CustomerCodeSt != 0)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF >= @FINDCUSTOMERCODEST" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCodeSt = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEST", SqlDbType.Int);
                findCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCodeSt);
            }

            // ���Ӑ�I��
            if (carManagementWork.CustomerCodeEd != 0)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF <= @FINDCUSTOMERCODEED" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCodeEd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEED", SqlDbType.Int);
                findCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(carManagementWork.CustomerCodeEd);
            }

            // ���q���l
            if (!string.IsNullOrEmpty(carManagementWork.CarNote.Trim()))
            {
                if (carManagementWork.CarNoteSearchDiv == 0)
                {
                    // ���S��v�̏ꍇ
                    wkstring = "  AND CARM.CARNOTERF = @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote);
                }
                else if (carManagementWork.CarNoteSearchDiv == 1)
                {
                    // �O����v�̏ꍇ
                    wkstring = "  AND CARM.CARNOTERF LIKE @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString(carManagementWork.CarNote + "%");
                }
                else if (carManagementWork.CarNoteSearchDiv == 2)
                {
                    // �܂݂̏ꍇ
                    wkstring = "  AND CARM.CARNOTERF LIKE @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarNote + "%");
                }
                else
                {
                    // �����v�̏ꍇ
                    wkstring = "  AND CARM.CARNOTERF LIKE @FINDCARNOTE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarNote = sqlCommand.Parameters.Add("@FINDCARNOTE", SqlDbType.NChar);
                    findCarNote.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.CarNote);
                }
            }

            // �^��
            if (!string.IsNullOrEmpty(carManagementWork.KindModel.Trim()))
            {
                if (carManagementWork.KindModelSearchDiv == 0)
                {
                    // ���S��v�̏ꍇ
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') = @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString(carManagementWork.KindModel);
                }
                else if (carManagementWork.KindModelSearchDiv == 1)
                {
                    // �O����v�̏ꍇ
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') LIKE @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString(carManagementWork.KindModel + "%");
                }
                else if (carManagementWork.KindModelSearchDiv == 2)
                {
                    // �܂݂̏ꍇ
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') LIKE @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.KindModel + "%");
                }
                else
                {

                    // �����v�̏ꍇ
                    wkstring = "  AND ISNULL(CARM.SERIESMODELRF, '') + '-' + ISNULL(CARM.CATEGORYSIGNMODELRF, '') LIKE @FINDKINDMODEL" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findKindModel = sqlCommand.Parameters.Add("@FINDKINDMODEL", SqlDbType.NChar);
                    findKindModel.Value = SqlDataMediator.SqlSetString("%" + carManagementWork.KindModel);
                }
            }

            // --- ADD 2009/09/11 ----------<<<<<

            return retstring;
        }
        # endregion

        # region [Where���쐬�����i�K�C�h�p�j]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="carMngGuideWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/11</br>
        private string MakeWhereStringForGuide(ref SqlCommand sqlCommand, CarMngGuideParamWork carMngGuideWork)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  CARM.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(carMngGuideWork.EnterpriseCode);

            // ���q�Ǘ��}�X�^�D��ƃR�[�h�����Ӑ�}�X�^�D�D��ƃR�[�h
            retstring += "  AND CARM.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;

            // ���q�Ǘ��}�X�^�D�_���폜�敪���L���f�[�^
            retstring += "  AND CARM.LOGICALDELETECODERF = 0" + Environment.NewLine;

            // ���Ӑ�}�X�^�D�_���폜�敪���L���f�[�^
            retstring += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;

            // ���q�Ǘ��}�X�^�D���Ӑ�R�[�h�����Ӑ�}�X�^�D���Ӑ�R�[�h
            retstring += "  AND CARM.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;

            // ���Ӑ�R�[�h�i�荞�ݗL��
            if (carMngGuideWork.IsCheckCustomerCode == true)
            {
                wkstring = "  AND CARM.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                retstring += wkstring;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(carMngGuideWork.CustomerCode);
            }
            // �Ǘ��ԍ��i�荞�ݗL��
            if (carMngGuideWork.IsCheckCarMngCode == true)
            {
                if (carMngGuideWork.CheckCarMngCodeType == 0)
                {
                    // ���S��v�̏ꍇ
                    wkstring = "  AND CARM.CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carMngGuideWork.CarMngCode);
                }
                else if (carMngGuideWork.CheckCarMngCodeType == 1)
                {
                    // �O����v�̏ꍇ
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString(carMngGuideWork.CarMngCode + "%");
                }
                else if (carMngGuideWork.CheckCarMngCodeType == 2)
                {
                    // �܂݂̏ꍇ
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carMngGuideWork.CarMngCode + "%");
                }
                else
                {
                    // �����v�̏ꍇ
                    wkstring = "  AND CARM.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                    retstring += wkstring;
                    SqlParameter findCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NChar);
                    findCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carMngGuideWork.CarMngCode);
                }
            }

            // ���q�Ǘ��敪�`�F�b�N�L��
            if (carMngGuideWork.IsCheckCarMngDivCd == true)
            {
                // ���Ӑ�}�X�^.���q�Ǘ��敪���u0:���Ȃ��v�̃f�[�^���擾����
                wkstring = "  AND CUST.CARMNGDIVCDRF != 0" + Environment.NewLine;
                retstring += wkstring;
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CarManagementWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CarManagementWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        private CarManagementWork CopyToCarManagementWorkFromReader(ref SqlDataReader myReader)
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            this.CopyToCarManagementWorkFromReader(ref myReader, ref carManagementWork);

            return carManagementWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CarManagementWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="carManagementWork">CarManagementWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br>Update Note: 2009/09/11 ����� LDNS�J���Ή�</br>
        /// <br>Update Note: 2010/04/27 gaoyh ���R�����^���Œ�ԍ��z���ǉ�</br>
        /// <br>Update Note: 2011/04/06 ������ ���q�Ǘ��}�X�^��Binaly�^��=null�̃f�[�^�����݂��鎞�A�G���[���������Ȃ��悤�C������ׁB</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private void CopyToCarManagementWorkFromReader(ref SqlDataReader myReader, ref CarManagementWork carManagementWork)
        {
            if (myReader != null && carManagementWork != null)
            {
                # region �N���X�֊i�[
                carManagementWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));               // �쐬����
                carManagementWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));               // �X�V����
                carManagementWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                          // ��ƃR�[�h
                carManagementWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                            // GUID
                carManagementWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                        // �X�V�]�ƈ��R�[�h
                carManagementWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                          // �X�V�A�Z���u��ID1
                carManagementWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                          // �X�V�A�Z���u��ID2
                carManagementWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                     // �_���폜�敪
                carManagementWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                               // ���Ӑ�R�[�h
                carManagementWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));                                       // �ԗ��Ǘ��ԍ�
                carManagementWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));                                  // ���q�Ǘ��R�[�h
                carManagementWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));                       // ���^�������ԍ�
                carManagementWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));                      // ���^�����ǖ���
                carManagementWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));                              // �ԗ��o�^�ԍ��i��ʁj
                carManagementWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));                              // �ԗ��o�^�ԍ��i�J�i�j
                carManagementWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));                               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                carManagementWork.EntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTRYDATERF"));                      // �o�^�N����
                //carManagementWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));              // ���N�x
                carManagementWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));                           // ���N�x
                carManagementWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));                                     // ���[�J�[�R�[�h
                carManagementWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));                            // ���[�J�[�S�p����
                carManagementWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));                            // ���[�J�[���p����
                carManagementWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));                                     // �Ԏ�R�[�h
                carManagementWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));                               // �Ԏ�T�u�R�[�h
                carManagementWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));                            // �Ԏ�S�p����
                carManagementWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));                            // �Ԏ피�p����
                carManagementWork.SystematicCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));                           // �n���R�[�h
                carManagementWork.SystematicName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYSTEMATICNAMERF"));                          // �n������
                carManagementWork.ProduceTypeOfYearCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARCDRF"));                 // ���Y�N���R�[�h
                carManagementWork.ProduceTypeOfYearNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNMRF"));                // ���Y�N������
                carManagementWork.StProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));    // �J�n���Y�N��
                carManagementWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));    // �I�����Y�N��
                carManagementWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));                                     // �h�A��
                carManagementWork.BodyNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BODYNAMECODERF"));                               // �{�f�B�[���R�[�h
                carManagementWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));                                      // �{�f�B�[����
                carManagementWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));                          // �r�K�X�L��
                carManagementWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));                                // �V���[�Y�^��
                carManagementWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));                    // �^���i�ޕʋL���j
                carManagementWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));                                    // �^���i�t���^�j
                carManagementWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));                   // �^���w��ԍ�
                carManagementWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));                                   // �ޕʔԍ�
                carManagementWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));                                  // �ԑ�^��
                carManagementWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));                                        // �ԑ�ԍ�
                carManagementWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));                             // �ԑ�ԍ��i�����p�j
                carManagementWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));                       // ���Y�ԑ�ԍ��J�n
                carManagementWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));                       // ���Y�ԑ�ԍ��I��
                carManagementWork.EngineModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELRF"));                                // �����@�^���i�G���W���j
                carManagementWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));                              // �^���O���[�h����
                carManagementWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));                            // �G���W���^������
                carManagementWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));                      // �r�C�ʖ���
                carManagementWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));                                          // E�敪����
                carManagementWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));                          // �~�b�V��������
                carManagementWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));                                        // �V�t�g����
                carManagementWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));                  // �쓮��������
                carManagementWork.AddiCarSpec1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC1RF"));                              // �ǉ�����1
                carManagementWork.AddiCarSpec2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC2RF"));                              // �ǉ�����2
                carManagementWork.AddiCarSpec3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC3RF"));                              // �ǉ�����3
                carManagementWork.AddiCarSpec4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC4RF"));                              // �ǉ�����4
                carManagementWork.AddiCarSpec5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC5RF"));                              // �ǉ�����5
                carManagementWork.AddiCarSpec6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC6RF"));                              // �ǉ�����6
                carManagementWork.AddiCarSpecTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE1RF"));                    // �ǉ������^�C�g��1
                carManagementWork.AddiCarSpecTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE2RF"));                    // �ǉ������^�C�g��2
                carManagementWork.AddiCarSpecTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE3RF"));                    // �ǉ������^�C�g��3
                carManagementWork.AddiCarSpecTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE4RF"));                    // �ǉ������^�C�g��4
                carManagementWork.AddiCarSpecTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE5RF"));                    // �ǉ������^�C�g��5
                carManagementWork.AddiCarSpecTitle6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE6RF"));                    // �ǉ������^�C�g��6
                carManagementWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));                          // �֘A�^��
                carManagementWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));                                   // �T�u�Ԗ��R�[�h
                carManagementWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));                        // �^���O���[�h����
                carManagementWork.BlockIllustrationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLOCKILLUSTRATIONCDRF"));                 // �u���b�N�C���X�g�R�[�h
                carManagementWork.ThreeDIllustNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("THREEDILLUSTNORF"));                           // 3D�C���X�gNo
                carManagementWork.PartsDataOfferFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDATAOFFERFLAGRF"));                   // ���i�f�[�^�񋟃t���O
                carManagementWork.InspectMaturityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));  // �Ԍ�������
                carManagementWork.LTimeCiMatDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTIMECIMATDATERF"));            // �O��Ԍ�������
                carManagementWork.CarInspectYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));                           // �Ԍ�����
                carManagementWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));                                         // �ԗ����s����
                carManagementWork.CarNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNORF"));                                            // ����
                carManagementWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));                                    // �J���[�R�[�h
                carManagementWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));                                  // �J���[����1
                carManagementWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));                                      // �g�����R�[�h
                carManagementWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));                                      // �g��������
                // ADD 2013/03/22  -------------------->>>>>
                carManagementWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));                // ���Y/�O�ԋ敪
                carManagementWork.HandleInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEINFOCDRF"));                            // �n���h���ʒu���
                // ADD 2013/03/22  --------------------<<<<< 
                byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                                     // �t���^���Œ�ԍ��z��
                // --- ADD 2011/04/06---------->>>>>
                if (varbinary == null)
                {
                    varbinary = new byte[0];
                }
                // --- ADD 2011/04/06----------<<<<<
                carManagementWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];
                
                for (int idx = 0; idx < carManagementWork.FullModelFixedNoAry.Length; idx++)
                {
                    carManagementWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                }

                carManagementWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));                          // �����I�u�W�F�N�g�z��
                // --- ADD 2011/04/06---------->>>>>
                if (carManagementWork.CategoryObjAry == null)
                {
                    carManagementWork.CategoryObjAry = new byte[0];
                }
                // --- ADD 2011/04/06----------<<<<<
                // --- ADD 2009/09/11 ---------->>>>>
                carManagementWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));                                         // ���q���l
                carManagementWork.CarAddInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARADDINFO1RF"));                                 // ���q�ǉ����P
                carManagementWork.CarAddInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARADDINFO2RF"));                                 // ���q�ǉ����Q
                // --- ADD 2009/09/11 ----------<<<<<
                // --- ADD 2010/04/27 ---------->>>>>
                carManagementWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));
                // --- ADD 2010/04/27 ----------<<<<<
                // --- ADD 2011/04/06---------->>>>>
                if ( carManagementWork.FreeSrchMdlFxdNoAry == null )
                {
                    carManagementWork.FreeSrchMdlFxdNoAry = new byte[0];
                }
                // --- ADD 2011/04/06----------<<<<<
                # endregion
            }
        }
        # endregion
    }
}
