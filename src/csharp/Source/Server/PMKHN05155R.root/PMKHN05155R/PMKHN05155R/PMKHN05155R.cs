//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�`�[�ԍ��ϊ������[�g�I�u�W�F�N�g
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/07  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/28  �C�����e : �����[�g�̃^�C���A�E�g���Ԃ̐ݒ�
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : ���
// �C �� ��  2018/10/01  �C�����e : �x���`�[�ݒ�}�X�^�̒ǉ���
//-------------------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �`�[�ԍ��ϊ������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       :�`�[�ԍ��ϊ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SlpNoConvertDB : RemoteWithAppLockDB,ISlipNoConvertDB
    {

        #region -- Member --
        /// <summary>�^�C���A�E�g�̒l��\���萔�F36000</summary>
        private readonly int DB_TIME_OUT = 36000;
        /// <summary>�^�C���A�E�g�̒l��\���萔�F3600</summary>
        private readonly int DB_TIME_OUT2 = 3600;�@�@�@�@�@�@�@//2018/09/28�@�q���ǉ�
        /// <summary>�`�[�ԍ��ϊ��Ώۃt�@�C���ɕs���f�[�^���L�邱�Ƃ������萔�F997</summary>
        private readonly int ILLEGAL_DATA = 997;
        /// <summary>�`�[�ԍ��ϊ��Ώۃt�@�C���Ƀf�[�^���������Ƃ������萔�F998</summary>
        private readonly int NO_DATA = 998;
        /// <summary>�`�[�ԍ��ϊ��Ώۃt�@�C�������݂��Ȃ����Ƃ������萔�F999</summary>
        private readonly int NO_FILE = 999;
        
        #endregion

        #region -- Constructor --

        /// <summary>
        /// ���_�R�[�h�ϊ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/11</br>
        /// </remarks>
        public SlpNoConvertDB()
        {
        }
        
        #endregion

        #region -- Public Method -- 

        /// <summary>
        /// �`�[�ԍ��ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="secDiv">���_�敪�i0�F�S�ЁA1�F���_�j</param>
        /// <param name="targetTableList">�R�[�h�ϊ��Ώۃe�[�u�����X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ϊ��Ώۂ̃e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        public int GetTargetTableList(int secDiv, ref object targetTableMap)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XML����X�V�Ώۂ̃��X�g���擾���܂��B
                if (secDiv == 0)
                {
                    status = this.GetTargetTableFromWholeCompanyXml(ref targetTableMap);
                }
                else
                {
                    status = this.GetTargetTableFromBaseCompanyXml(ref targetTableMap);
                }
            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        /// <summary>
        /// �`�[�ԍ��ϊ��O�`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="slipNoCnvPrm">�ύX�f�[�^</param>
        /// <param name="check">�`�F�b�N���ʁiTrue�i�f�[�^�Ȃ��j/false(�f�[�^����))</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ϊ��O�`�F�b�N�������s���B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        public int CheckConvertSlipNo(string enterpriseCode,object slipNoCnvPrm,ref bool check)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�ύX�f�[�^�̕ϐ�
            SlipNoConvertPrmInfoList prmWk = slipNoCnvPrm as SlipNoConvertPrmInfoList;
            check = false;

            //�ϊ������̊J�n
            try
            {
                // DB�Ɛڑ����s���`�F�b�N�����܂�
                using (SqlConnection sqlCon = this.CreateConnection(true))
                {
                    status = this.CheckConvertSlipNoProc(enterpriseCode, prmWk,ref check, sqlCon);
                }

            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }

            return status;
        }

        /// <summary>
        /// �`�[�ԍ��ϊ�����
        /// </summary>
        /// <param name="enterprise">��ƃR�[�h</param>
        /// <param name="slipNoCnvPrm">�ύX�f�[�^</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ϊ��������s���B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        public int ConvertSlipNo(string enterprise,object slipNoCnvPrm, ref long numberOfTransactions)
        {
            // �����X�e�[�^�X�����������܂��B
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // SqlConnection�ϐ�
            SqlConnection sqlCon = null;
            // SqlTrancation�ϐ�
            SqlTransaction tran = null;
            //��������
            SlipNoConvertPrmInfoList slipNoCnv = slipNoCnvPrm as SlipNoConvertPrmInfoList;

            //��������
            numberOfTransactions = 0;

            //�ϊ������̊J�n
            try
            {
                // DB�Ɛڑ����s���܂�
                sqlCon = this.CreateConnection(true);
                // �g�����U�N�V�������J�n���܂�
                tran = this.CreateTransaction(ref sqlCon);
                //�R���o�[�g�����s���܂�
                status = this.ConvertSlipNoPrc(enterprise, slipNoCnv, sqlCon, tran, ref numberOfTransactions);

            }
            catch (Exception ex)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (tran != null)
                {
                    tran.Dispose();
                }

                if (sqlCon != null)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- �`�[�ԍ��ϊ��Ώۃe�[�u�����X�g�擾�֘A --

        /// <summary>
        /// �Ώۃe�[�u�����WholeCompanyXml�ǂݎ�菈��
        /// </summary
        /// <param name="targetTableList">�X�V�Ώۃe�[�u�������i�[����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML����ϊ��ΏۂƂȂ�e�[�u������ǂݎ��܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int GetTargetTableFromWholeCompanyXml(ref object targetTableList)
        {
            // �����X�e�[�^�X�����������܂�
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XML����f�[�^��ǂݎ��܂��B
            IList<SlpNoTargetTableList> trgTblMap = targetTableList as IList<SlpNoTargetTableList>;

            using (MemoryStream fs = XMLWholeCompanyList.ms())
            {
                // XML���f�V���A���C�Y���܂��B
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfWholeCompanyList));
                ArrayOfWholeCompanyList arryCnvList = (ArrayOfWholeCompanyList)serializer.Deserialize(fs);
                trgTblMap = new List<SlpNoTargetTableList>();


                //���X�g���쐬����
                foreach (WholeCompanyCvtList wholeList in arryCnvList.WoleCompanyCvtList)
                {
                    //Key(�ԍ��R�[�h�i�����ԍ��j���Z�b�g����
                    int TargetNo = 0;
                    if (wholeList.TARGETNO.ToString() == "")
                    {
                        // �����ԍ���0�̏ꍇ�ُ͈�f�[�^�ł���ׁA������ł��؂�
                        return this.ILLEGAL_DATA;
                    }
                    else
                    {
                        TargetNo = Convert.ToInt32(wholeList.TARGETNO);
                    }

                    SlpNoTargetTableList work = new SlpNoTargetTableList();
                    
                    //�ԍ��R�[�h(�����Ώ۔ԍ�)
                    work.TargetNo = Convert.ToInt32(wholeList.TARGETNO); ;
                    //�e�[�u��ID(������)
                    work.TargetTable = wholeList.TABLE.Trim().ToUpper(); ;
                    //�e�[�u����(�_����)
                    work.TargetTableName = wholeList.TABLENAME.Trim();
                    //�J������(������)
                    work.TargetColum = wholeList.TARGETCOLUM.Trim().ToUpper();
                    //�J������(�_����)
                    work.TargetColumName = wholeList.TARGETCOLUMNNAME.Trim();
                    //�󒍃X�e�[�^�XID
                    work.TargetAcptStatusId = wholeList.ACPTSTATUSID.Trim().ToUpper();
                    //�󒍃X�e�[�^�X�R�[�h
                  //if (wholeList.ACPTSTATUS.ToString() != "")    2018/10/01
                    if (work.TargetAcptStatusId != "")     //2018/10/01
                    {
                        work.TargetAcptStatus = Convert.ToInt32(wholeList.ACPTSTATUS);
                    }
                    
                    trgTblMap.Add(work);

                }

                if (trgTblMap.Count == 0)
                {
                    // trgTblMap��0���̏ꍇ�́A�ϊ��Ώۂ̃e�[�u���������ׁA�X�e�[�^�X��NO_DATA�ɂ��܂��B
                    status = this.NO_DATA;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    targetTableList = trgTblMap;
                }
            }


            return status;
        }


        /// <summary>
        /// �Ώۃe�[�u�����BaseCompanyXml�ǂݎ�菈��
        /// </summary
        /// <param name="targetTableList">�X�V�Ώۃe�[�u�������i�[����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML����ϊ��ΏۂƂȂ�e�[�u������ǂݎ��܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int GetTargetTableFromBaseCompanyXml(ref object targetTableList)
        {
            // �����X�e�[�^�X�����������܂�
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // XML����f�[�^��ǂݎ��܂��B
            IList<SlpNoTargetTableList> trgTblMap = targetTableList as IList<SlpNoTargetTableList>;

            using (MemoryStream fs = XMLBaseCompanyList.ms())
            {
                // XML���f�V���A���C�Y���܂��B
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfBaseCompanyList));
                ArrayOfBaseCompanyList arryCnvList = (ArrayOfBaseCompanyList)serializer.Deserialize(fs);
                trgTblMap = new List<SlpNoTargetTableList>();

                //���X�g���쐬����
                foreach (BaseCompanyCvtList baceList in arryCnvList.BaseCompanyCvtList)
                {
                    //Key(�ԍ��R�[�h�i�����ԍ��j���Z�b�g����
                    int TargetNo = 0;
                    if (baceList.TARGETNO.ToString() == "")
                    {
                        // �����ԍ���0�̏ꍇ�ُ͈�f�[�^�ł���ׁA������ł��؂�
                        return this.ILLEGAL_DATA;
                    }
                    else
                    {
                        TargetNo = Convert.ToInt32(baceList.TARGETNO);
                    }

                    SlpNoTargetTableList work = new SlpNoTargetTableList();

                    //�ԍ��R�[�h(�����Ώ۔ԍ�)
                    work.TargetNo = Convert.ToInt32(baceList.TARGETNO);;
                    //�e�[�u��ID(������)
                    work.TargetTable = baceList.TABLE.Trim().ToUpper(); ;
                    //�e�[�u����(�_����)
                    work.TargetTableName = baceList.TABLENAME.Trim();
                    //�J������(������)
                    work.TargetColum = baceList.TARGETCOLUM.Trim().ToUpper();
                    //�J������(�_����)
                    work.TargetColumName = baceList.TARGETCOLUMNAME.Trim();
                    //�󒍃X�e�[�^�XID
                    work.TargetAcptStatusId = baceList.ACPTSTATUSID.Trim().ToUpper();
                    //�󒍃X�e�[�^�X�R�[�h
           //       if (baceList.ACPTSTATUS.ToString() != "")        2018/10/01
                    if ( work.TargetAcptStatusId != "" )           //2018/10/01
                    {
                        work.TargetAcptStatus = Convert.ToInt32(baceList.ACPTSTATUS);
                    }

                    trgTblMap.Add(work);

                }

                if (trgTblMap.Count == 0)
                {
                    // trgTblMap��0���̏ꍇ�́A�ϊ��Ώۂ̃e�[�u���������ׁA�X�e�[�^�X��NO_DATA�ɂ��܂��B
                    status = this.NO_DATA;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    targetTableList = trgTblMap;
                }
            }


            return status;
        }

#endregion


        #region --�`�[�ԍ��ϊ��O�`�F�b�N�����֘A--
        /// <summary>
        /// �`�[�ԍ��ϊ��O�`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prmWk">��������</param>
        /// <param name="check">�`�F�b�N���ʁiTrue�i�f�[�^�Ȃ��j/false(�f�[�^����))</param>
        /// <param name="sqlCon">DB�ڑ����</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ϊ��O�`�F�b�N�������s���B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int CheckConvertSlipNoProc(string enterpriseCode,SlipNoConvertPrmInfoList prmWk, ref bool check,SqlConnection sqlCon)
        {
            // �����X�e�[�^�X��������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �����p��SQL�𐶐����A�������s���܂�
                using (SqlCommand cmd = new SqlCommand())
                {
                    // �ڑ�����ݒ�
                    cmd.Connection = sqlCon;
                    // �N�G����ݒ�
                    cmd.CommandText = this.CheckSlipSql(enterpriseCode,prmWk, cmd);
                    //�^�C���A�E�g�̐ݒ�
                    cmd.CommandTimeout = this.DB_TIME_OUT2;�@//------2018/09/28 -�q��-Add

                    // �N�G�������s
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            //���ʂ��Z�b�g����
                            long count = (int)SqlDataMediator.SqlSetInt32(rd.GetInt32(0));

                            if (count != 0)
                            {
                                check = false;
                            }
                            else
                            {
                                check = true;
                            }
                           
                        }
                        
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException sqle)
            {
                string errMsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(sqle, errMsg, sqle.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlpNoConvertDB.CheckConvertSlipNoProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// �`�[�ԍ��ϊ��O�`�F�b�NSQL�쐬����
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>SQL��</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ����p��SQL���𐶐����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private string CheckSlipSql(string enterpriseCode, SlipNoConvertPrmInfoList prmWk, SqlCommand cmd)
        {
            //SQL���̐���
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM " + prmWk.Table   //�e�[�u��ID  
            + " WHERE "
            + "ENTERPRISECODERF = '" + enterpriseCode         //��ƃR�[�h
            + "' AND ");

            //if(prmWk.AcptStatus != 0 & prmWk.AcptStatusId !="") �@2018/10/01  �d���f�[�^��0:�d��
            if ( prmWk.AcptStatusId != "")                        //2018/10/01 
            {
                sb.Append(prmWk.AcptStatusId + " = " + prmWk.AcptStatus + " AND ");   //�󒍃X�e�[�^�XID�A�󒍃X�e�[�^�X
            }

            //�����J�n�i�ݒ�J�n�ԍ�+�����l�j
            Int64 stprm = Convert.ToInt64(prmWk.SettingStartNo) + Convert.ToInt64(prmWk.NoIncDecWidth);
            //�����I���i�ԍ����ݒn+�����l�j
            Int64 edprm = Convert.ToInt64(prmWk.NoPresentVal) + Convert.ToInt64(prmWk.NoIncDecWidth);
            sb.Append(prmWk.Colum + " >= " + stprm  //����ID�A�ݒ�J�n�ԍ�+�����l
                 + " AND "
                 + prmWk.Colum + " <= " + edprm);     //����ID�A�ԍ����ݒl+�����l

            return sb.ToString();
        }

        #endregion
       

        #region -- �`�[�ԍ��ϊ������֘A --

        /// <summary>
        /// �`�[�ԍ��ϊ�����
        /// </summary>
        /// <param name="enterprise">��ƃR�[�h</param>
        /// <param name="slipNoCnvPrm">�ϊ�����</param>
        /// <param name="sqlCon">SqlConnection�I�u�W�F�N�g</param>
        /// <param name="tran">SqlTransaction�I�u�W�F�N�g</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ϊ��������s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private int ConvertSlipNoPrc(string enterprise, SlipNoConvertPrmInfoList slipNoCnvPrm, SqlConnection sqlCon, SqlTransaction tran, ref long numberOfTransactions)
        {
            // �X�e�[�^�X�����������܂�
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                //�X�V�������s���܂�
                using(SqlCommand cmd = new SqlCommand(String.Empty,sqlCon,tran))
                {
                    //�^�C���A�E�g�̐ݒ�
                    cmd.CommandTimeout = this.DB_TIME_OUT;
                    //SQl�𐶐����Ď��s���܂�
                    cmd.CommandText = this.ConvertSlipSql(enterprise, slipNoCnvPrm,cmd);
                    long count = cmd.ExecuteNonQuery();
                    numberOfTransactions = count;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď��������Ă��炢�܂�
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SectionConvertDB ConvertProc Exception" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            }
            finally
            {
                // ���������������ꍇ�̓R�~�b�g�A���s�����ꍇ�̓��[���o�b�N�����{���܂��B
                if (status == 0)
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
            }

            return status;
        }

        /// <summary>
        /// �`�[�ԍ��ϊ������@SQL�쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prmWork">�ϊ������̃��X�g</param>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <returns>�R�[�h�ϊ��pSQL</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������Ɍ����p��SQL���𐶐����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private string ConvertSlipSql(string enterpriseCode, SlipNoConvertPrmInfoList prmWork, SqlCommand cmd)
        {
            //SQL���̐���
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE " + prmWork.Table  //�e�[�u��ID
            + " SET "
            + prmWork.Colum + " = " + prmWork.Colum + " + " + prmWork.NoIncDecWidth  //����ID�A�����l
            + " WHERE "
            + "ENTERPRISECODERF = '" + enterpriseCode  //��ƃR�[�h
            + "' AND ");

//          if (prmWork.AcptStatusId != "" && prmWork.AcptStatus != 0)  //�󒍃X�e�[�^�XID�A�󒍃X�e�[�^�X  2018/10/01 �d���f�[�^��0:�d��
            if (prmWork.AcptStatusId != "" )                            //�󒍃X�e�[�^�XID�@�@�@�@          2018/10/01  
            {
                sb.Append(prmWork.AcptStatusId + " = " + prmWork.AcptStatus + " AND ");
            }

            sb.Append( prmWork.Colum + " >= " + prmWork.SettingStartNo + " AND "  //�ݒ�J�n�ԍ�
                + prmWork.Colum + " <= " + prmWork.NoPresentVal + " AND "         //�ԍ����ݒl
                + prmWork.Colum + " != 0"); //����ID

            return sb.ToString();
        }


        #endregion

      
        #endregion
    }
}
