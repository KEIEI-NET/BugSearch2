//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ���������
// �v���O�����T�v   : �i�ԕϊ��G���[�f�[�^�̒ǉ��ƍ폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/02/26  �C�����e : Redmine#44209 ���b�Z�[�W�̕����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/03/20  �C�����e : Redmine#44209 �t�@�C���`�F�b�N�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/07  �C�����e : Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�
//----------------------------------------------------------------------------//


using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources; 
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Collections;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�ƕi�ԕϊ���������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �i�ԕϊ��������ʂ̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class GoodsNoChgCommonDB : RemoteDB
    {
        # region Const Member
        /// <summary>
        ///  ���i�݌Ƀ}�X�^
        /// </summary>
        public static int GOODSMST = 1;
        /// <summary>
        ///  ���i�Ǘ����}�X�^
        /// </summary>
        public static int GOODSMNGMST = 2;
        /// <summary>
        ///  �|���}�X�^
        /// </summary>
        public static int RATEMST = 3;
        /// <summary>
        ///  �����}�X�^
        /// </summary>
        public static int JOINMST = 4;
        /// <summary>
        ///  ��փ}�X�^
        /// </summary>
        public static int PARTSMST = 5;
        /// <summary>
        ///  �Z�b�g�}�X�^
        /// </summary>
        public static int SETMST = 6;
        # endregion

        //----- ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�----->>>>>
        #region ���b�Z�[�W
        /// <summary>
        /// �_���폜�`�F�b�N���b�Z�[�W
        /// </summary>
        public static string DELETEMSG = "�_���폜�f�[�^";
        /// <summary>
        /// �r���`�F�b�N���b�Z�[�W
        /// </summary>
        public static string EXISTMSG = "�ϊ���i�Ԃ�����{0}�ɓo�^����Ă��܂�";
        /// <summary>
        /// �ϊ����ُ�G���[�̏ꍇ
        /// </summary>
        public static string OLDEXCEPTIONMSG = "�ϊ����i�Ԃ̍폜�Ɏ��s���܂���";
        /// <summary>
        /// �ϊ���ُ�G���[�̏ꍇ
        /// </summary>
        public static string NEWEXCEPTIONMSG = "�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���";
        /// <summary>
        /// �s�����f�[�^������ꍇ
        /// </summary>
        public static string UNNORMALDATA = "���i�}�X�^�����݂��Ȃ��ׁA���Y�i�ԏ����ł��܂���ł���";
        /// <summary>
        /// �����i�ԁA���i�}�X�^�A�݌Ƀ}�X�^�G���[����������ꍇ
        /// </summary>
        public static string GOODSMSTERRMSG2 = "����i�Ԃ�{0}�ŕϊ��G���[�����������ׁA�����ł��܂���ł���";
        /// <summary>
        /// �X�V���s�̏ꍇ
        /// </summary>
        public static string UPDATEFAIL = "���̃��[�U�[�ɂ��ϊ����i�Ԃ�{0}���X�V���ꂽ�ׁA�ϊ����i�Ԃ��폜�ł��܂���ł���";
        /// <summary>
        /// ���i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�G���[����������ꍇ
        /// </summary>
        public static string GOODSMSTERRMSG = "{0}�ϊ��ŃG���[�����������ׁA�����ł��܂���ł����B{0}�̃G���[���O���m�F���ĉ�����";
        /// <summary>
        /// �ݏo�ϊ��ُ�G���[�̏ꍇ
        /// </summary>
        public static string RENTEXCEPTIONMSG = "���v��ݏo�f�[�^�̕i�ԕϊ��Ɏ��s���܂���";
        /// <summary>
        /// �ݏo�ϊ��r���G���[�̏ꍇ
        /// </summary>
        public static string RENTUPDATEFAIL = "���̃��[�U�[�ɂ�薢�v��ݏo�f�[�^���X�V���ꂽ�ׁA���v��ݏo�f�[�^�̕i�Ԃ�ϊ��ł��܂���ł���";
        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
        /// <summary>
        /// ���i�Ԃ̗D�ǐݒ�}�X�^�폜�ɔr���G���[�̏ꍇ
        /// </summary>
        public static string PRMDELETEERR = "���̃��[�U�[�ɂ�苌�i�Ԃ̗D�ǐݒ�}�X�^���X�V���ꂽ�ׁA�D�ǐݒ�}�X�^��ϊ��ł��܂���ł���";
        /// <summary>
        /// ���i�Ԃ̗D�ǐݒ�}�X�^�o�^�ɔr���ȊO�G���[�̏ꍇ
        /// </summary>
        public static string PRMDELETEEX = "���i�Ԃ̗D�ǐݒ�}�X�^�폜�Ɏ��s���܂���";
        /// <summary>
        /// �V�i�Ԃ̗D�ǐݒ�}�X�^�o�^�ɔr���G���[�̏ꍇ
        /// </summary>
        public static string PRMINSERTERR = "�V�i�Ԃ̗D�ǐݒ�}�X�^�����ɗD�ǐݒ�}�X�^�ɓo�^����Ă��܂�";
        /// <summary>
        /// �V�i�Ԃ̗D�ǐݒ�}�X�^�X�V�o�^�ɔr���ȊO�G���[�̏ꍇ
        /// </summary>
        public static string PRMINSERTEX = "�V�i�Ԃ̗D�ǐݒ�}�X�^�o�^�Ɏ��s���܂���";
        /// <summary>
        /// �񋟏�񂪑��݂��Ȃ��ꍇ
        /// </summary>
        public static string PRMOFFERNOT = "�񋟏�񂪑��݂��Ȃ������ׁA�����ł��܂���ł���";
        //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------>>>>>
        /// <summary>
        /// �����}�X�^�ϊ����A�������ƌ�����̕i�Ԃ�����̏ꍇ
        /// </summary>
        public static string REPEATJOINMSG = "�ϊ���̌������i�Ԃƌ�����i�Ԃ�����ł�";
        /// <summary>
        /// ��փ}�X�^�ϊ����A��֌��Ƒ�֐�̕i�Ԃ�����̏ꍇ
        /// </summary>
        public static string REPEATPARTSMSG = "�ϊ���̑�֌��i�ԂƑ�֐�i�Ԃ�����ł�";
        /// <summary>
        /// �Z�b�g�}�X�^�ϊ����A�e�i�ԂƎq�i�Ԃ�����̏ꍇ
        /// </summary>
        public static string REPEATSETMSG = "�ϊ���̐e�i�ԂƎq�i�Ԃ�����ł�";
        //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------<<<<<
        //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------>>>>>
        /// <summary>
        /// �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ
        /// </summary>
        public static string DISPORDEROVERNUMBER = "�\�����ʂ̍̔ԂɎ��s���܂����B���ʂ�50�𒴂��Ă��܂�";
        //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------<<<<<
        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<
        #endregion
        //----- ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�-----<<<<<

        #region GoodsNoChgCommonDB
        /// <summary>
        /// ����f�[�^�e�L�X�g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public GoodsNoChgCommonDB()
        {

        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ����� false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }
        #endregion  //�R�l�N�V������������

        #region [SqlTransaction��������]
        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
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
        #endregion  //SqlTransaction��������

        #region �i�ԕϊ��G���[�f�[�^�𕨗��폜
        /// <summary>
        /// �i�ԕϊ��G���[�f�[�^�𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="deleteDiv">�폜�敪</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : �i�ԕϊ��G���[�f�[�^�𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        public int DeleteGoodsNoChangeErrorDataProc(string enterPriseCode, int deleteDiv, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                sqlTxt = "";
                sqlTxt += "DELETE" + Environment.NewLine;
                sqlTxt += "FROM GOODSNOCHANGEERRDTRF" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " AND MASTERDIVCDRF=@FINDMASTERDIVCDRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlTxt;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMasterDivCd = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);

                //KEY�R�}���h���Đݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(deleteDiv);

                //if (deleteDiv == GOODSMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(GOODSMST);
                //}
                //else if (deleteDiv == GOODSMNGMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(GOODSMNGMST);
                //}
                //else if (deleteDiv == STOCKMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(STOCKMST);
                //}
                //else if (deleteDiv == RATEMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(RATEMST);
                //}
                //else if (deleteDiv == JOINMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(JOINMST);
                //}
                //else if (deleteDiv == PARTSMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(PARTSMST);
                //}
                //else if (deleteDiv == SETMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(SETMST);
                //}
                //else
                //{ 
                //    // �Ȃ�
                //}

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region �i�ԕϊ��G���[�f�[�^��o�^
        /// <summary>
        /// �i�ԕϊ��G���[�f�[�^��o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsNoChangeErrorDataWorkDic">RateWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �i�ԕϊ��G���[�f�[�^��o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        public int WriteGoodsNoChangeErrorDataProc(Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChangeErrorDataWorkDic, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";
                foreach (string goodsNoChgKey in goodsNoChangeErrorDataWorkDic.Keys)
                {
                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = goodsNoChangeErrorDataWorkDic[goodsNoChgKey];
                    sqlTxt = "" + Environment.NewLine;
                    sqlTxt += "INSERT INTO GOODSNOCHANGEERRDTRF" + Environment.NewLine;
                    sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "  ,MASTERDIVCDRF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "  ,CHGSRCGOODSNORF" + Environment.NewLine;
                    sqlTxt += "  ,CHGDESTGOODSNORF" + Environment.NewLine;
                    sqlTxt += "  )" + Environment.NewLine;
                    sqlTxt += "VALUES" + Environment.NewLine;
                    sqlTxt += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "  ,@MASTERDIVCD" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  ,@CHGSRCGOODSNO" + Environment.NewLine;
                    sqlTxt += "  ,@CHGDESTGOODSNO" + Environment.NewLine;
                    sqlTxt += "  )" + Environment.NewLine;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = sqlTxt;
                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsNoChangeErrorDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraMasterDivCd = sqlCommand.Parameters.Add("@MASTERDIVCD", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraChgDestGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeErrorDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeErrorDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsNoChangeErrorDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeErrorDataWork.LogicalDeleteCode);
                    paraMasterDivCd.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeErrorDataWork.MasterDivCd);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeErrorDataWork.GoodsMakerCd);
                    paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.ChgSrcGoodsNo);
                    paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.ChgDestGoodsNo);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        #region �t�@�C���`�F�b�N�����ւ���
        #region �G���[���b�Z�[�W
        private const string ct_FILE_MSG = "�i�ԕϊ��}�X�^�捞�p�̃N���X�C���f�b�N�X�t�@�C��������܂���B" + "\r\n" + "AP�T�[�o�[�ɃN���X�C���f�b�N�X�t�@�C�����z�u����Ă��邩�m�F���Ă��������B";
        private const string ct_FILE_MSG2 = "�D�ǐݒ�}�X�^�ϊ��p�̃N���X�C���f�b�N�X�t�@�C��������܂���B" + "\r\n" + "AP�T�[�o�[�ɃN���X�C���f�b�N�X�t�@�C�����z�u����Ă��邩�m�F���Ă��������B";
        private const string ct_FILE_NODATA = "�Y������f�[�^������܂���B";
        // --- DEL �i�N 2015/03/20 �t�@�C���`�F�b�N�̑Ή� ----->>>>>
        //private const int OF_READWRITE = 2;
        //private const int OF_SHARE_DENY_NONE = 0x40;
        //private readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        // --- DEL �i�N 2015/03/20 �t�@�C���`�F�b�N�̑Ή� -----<<<<<

        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}���ݒ肳��Ă��܂���";
        private const string FORMAT_ERRMSG_LENTH = "{0}({2})�̌�����{1}���𒴂��Ă��܂�";
        /// <summary>
        /// �s���ȕ������܂܂�Ă���ꍇ
        /// </summary>
        public static string FORMAT_ERRMSG_TYPE = "{0}�ɕs���ȕ������܂܂�Ă��܂�";
        /// <summary>
        /// ���ڐ����s���̏ꍇ
        /// </summary>
        public static string ERRMSG_COUNTERR = "���ڐ����s���ł�";
        /// <summary>
        /// ���[�J�[���}�X�^�ɓo�^����Ă��܂���
        /// </summary>
        public static string ERRMSG_MAKERNOTFOUND = "���[�J�[���}�X�^�ɓo�^����Ă��܂���";

        #endregion

        /// <summary>
        /// ÷��̧�ٖ��`�F�b�N����
        /// </summary>
        /// <param name="filePath">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="mode">mode 0:�i�ԕϊ��}�X�^�ϊ��p�@1:�D�ǐݒ�}�X�^�ϊ��p</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ÷��̧�ٖ��`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        public bool CheckInputFile(string filePath, out string errMsg, int mode)
        {
            bool status = true;
            errMsg = string.Empty;
            string fileName = filePath.Trim();
            string message = string.Empty;
            if (mode == 0)
            {
                message = ct_FILE_MSG;
            }
            if (mode == 1)
            {
                message = ct_FILE_MSG2;
            }

            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
                {
                    errMsg = message;
                    status = false;
                    return status;
                }

                if (!File.Exists(fileName))
                {
                    errMsg = message;
                    status = false;
                    return status;
                }

                // --- DEL �i�N 2015/03/20 �t�@�C���`�F�b�N�̑Ή� ----->>>>>
                //IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);
                //if (vHandle == HFILE_ERROR)
                //{
                //    errMsg = message;
                //    status = false;
                //    return status;
                //}
                //CloseHandle(vHandle);
                // --- DEL �i�N 2015/03/20 �t�@�C���`�F�b�N�̑Ή� -----<<<<<
            }
            catch
            {
                errMsg = message;
                status = false;
                return status;
            }

            return true;
        }

        /// <summary>
        /// ÷��̧�ٖ��̃��R�[�h���݃`�F�b�N����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="dataList">�f�[�^���X�g</param>
        /// <param name="isReadErr">�Ǎ��G���[���ǂ���</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ÷��̧�ٖ��̃��R�[�h���݃`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        public bool CheckInputFileDataExists(string fileName, out string errMsg, out List<string[]> dataList, out bool isReadErr)
        {
            errMsg = string.Empty;
            isReadErr = false;
            bool bStatus = true;
            dataList = GetCsvData(fileName, out errMsg);
            // �Ǎ����ɃG���[�����������ꍇ
            if (!string.IsNullOrEmpty(errMsg))
            {
                isReadErr = true;
                bStatus = false;
            }
            return bStatus;
        }

        /// <summary>
        /// CSV���擾����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>CSV���</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private List<String[]> GetCsvData(String fileName, out string errMsg)
        {
            errMsg = string.Empty;
            List<string[]> csvDataList = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            try
            {
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // ��؂蕶���̓R���}
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1�s�ǂݍ���
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                // �Ȃ�
            }
            return csvDataList;

        }

        // --- DEL �i�N 2015/03/20 �t�@�C���`�F�b�N�̑Ή� ----->>>>>
        ///// <summary>
        ///// _lopen
        ///// </summary>
        ///// <param name="lpPathName"></param>
        ///// <param name="iReadWrite"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        ///// <summary>
        ///// CloseHandle
        ///// </summary>
        ///// <param name="hObject"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //public static extern bool CloseHandle(IntPtr hObject);
        // --- DEL �i�N 2015/03/20 �t�@�C���`�F�b�N�̑Ή� -----<<<<<

        /// <summary>
        /// NULL���f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        public bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �����������f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        public bool IsDigitAdd(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regex1 = "^[0-9]*[1-9][0-9]*$";
            Regex objRegex = new Regex(regex1);
            if (!objRegex.IsMatch(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ������+0���f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>True:����; False:�񐔎�</returns>
        /// <remarks>
        /// <br>Note       : ������+0���f�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/12/30</br>
        /// </remarks>
        public bool IsDigitAddZero(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regex1 = "^\\d+$";
            Regex objRegex = new Regex(regex1);
            if (!objRegex.IsMatch(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �������w�肵�Ȃ��̕�����`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        public bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            if (val.Trim().Length > len)
            {
                msg = string.Format(FORMAT_ERRMSG_LENTH, fieldNm, len.ToString(), val);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���p�p�����A�����̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        public bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;

            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
                return false;
            }

        }

        /// <summary>
        /// �󔒍��ڂ֕ϊ�����
        /// </summary>
        /// <param name="csvDataArr">CSV���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�ύX��������</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        public string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
    }
}
