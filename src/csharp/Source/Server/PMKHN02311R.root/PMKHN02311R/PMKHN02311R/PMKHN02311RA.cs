//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���O
// �C �� ��  2020/06/18  �C�����e : PMKOBETSU-4005 �d�a�d�΍�
//---------------------------------------------------------------------------//

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
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;// ADD ���O 2020/06/18 PMKOBETSU-4005�̑Ή�

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������i���i��������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i���������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/06/18</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class GoodsInfoWorkDB : RemoteDB, IGoodsInfoWorkDB
    {
        /// <summary>
        /// �������i���i��������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public GoodsInfoWorkDB()
            :
        base("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork", "WAREHOUSERF") //���N���X�̃R���X�g���N�^
        {
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉������i���i����������LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="countNum">��������</param>
        /// <param name="normalGoodsInfoDataWorkLst">�t�@�C���p�����[�^����</param>
        /// <param name="warnGoodsInfoDataWorkLst">�t�@�C���p�����[�^�x��</param>
        /// <param name="goodsInfoCndtnWork">��ʂ̃p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̉������i���i����������LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        public int WriteGoodsInfo(out object countNum, out object writeError, ref object normalGoodsInfoDataWorkLst, ref object warnGoodsInfoDataWorkLst, object goodsInfoCndtnWork)
        {
            writeError = null;
            countNum = new object();
            ArrayList ret = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                if (null == normalGoodsInfoDataWorkLst
                    && null == warnGoodsInfoDataWorkLst)
                {
                    return status;
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                ArrayList normalParamGoodsInfoDataWorkLst = normalGoodsInfoDataWorkLst as ArrayList;

                ArrayList warnParamGoodsInfoDataWorkLst = warnGoodsInfoDataWorkLst as ArrayList;

                GoodsInfoCndtnWork goodsInfoParamCndtnWork = goodsInfoCndtnWork as GoodsInfoCndtnWork;

                //write���s
                ArrayList writeErrorList = null;

                status = WriteGoodsPriceProc(out ret, out writeErrorList, ref normalParamGoodsInfoDataWorkLst, ref warnParamGoodsInfoDataWorkLst, goodsInfoParamCndtnWork, ref sqlConnection, ref sqlTransaction);

                countNum = ret;

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                //    status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                //{
                    //�R�~�b�g
                    sqlTransaction.Commit();
                //}
                //else
                //{
                //    // ���[���o�b�N
                //    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //}
                //�߂�l�Z�b�g
                writeError = (object)writeErrorList;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Write(ref object GoodsPriceUWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Write(ref object GoodsPriceUWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        /// <summary>
        /// ���i���i�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="writeErrorList">�X�V�G���[���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br></br>
        public int WriteGoodsPriceProc(out ArrayList ret, out ArrayList writeErrorList, ref ArrayList normalGoodsInfoDataWorkLst, ref ArrayList warnGoodsInfoDataWorkLst, GoodsInfoCndtnWork goodsInfoParamCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ArrayList retList = new ArrayList();
            writeErrorList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //�ǉ���
            int addNum = 0;

            //�X�V��
            int updateNum = 0;

            ArrayList al = new ArrayList();
            string errorMessage = string.Empty;

            bool normalExistFlg;
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();

            try
            {
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                //����ꍇ
                for (int i = 0; i < normalGoodsInfoDataWorkLst.Count; i++)
                {
                    normalExistFlg = false;
                    GoodsInfoDataWork goodsInfoDataWork = normalGoodsInfoDataWorkLst[i] as GoodsInfoDataWork;

                    //���i�}�X�^
                    errorMessage = string.Empty;
                    int writeGoodsStatus;
                    writeGoodsStatus = WriteGoodsUProcProc(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out normalExistFlg, out errorMessage, ref sqlConnection, ref sqlTransaction);
                    if (writeGoodsStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (normalExistFlg)
                        {
                            updateNum++;
                        }
                        else
                        {
                            addNum++;
                        }

                        al.Add(goodsInfoDataWork);

                        //WARNING,ERROR����Ȃ�������NORMAL
                        if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                            status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }


                        //���i�Ǘ����}�X�^
                        errorMessage = string.Empty;
                        int writeGoodsMngStatus;
                        writeGoodsMngStatus = WriteGoodsMngProcProc(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        if (writeGoodsMngStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERROR����Ȃ�������NORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsMngStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                        //���i�}�X�^
                        errorMessage = string.Empty;
                        int writeGoodsPriceStatus;
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                       writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        
                        if (writeGoodsPriceStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERROR����Ȃ�������NORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsPriceStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                    }
                    else
                    {
                        writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsStatus, errorMessage));
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }
                }

                bool warnExistFlg;
                //�x���ꍇ
                for (int i = 0; i < warnGoodsInfoDataWorkLst.Count; i++)
                {
                    warnExistFlg = false;
                    GoodsInfoDataWork goodsInfoDataWork = warnGoodsInfoDataWorkLst[i] as GoodsInfoDataWork;
                    //���i�}�X�^
                    errorMessage = string.Empty;
                    int writeGoodsStatus;
                    writeGoodsStatus = WriteGoodsUProcProc(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out warnExistFlg, out errorMessage, ref sqlConnection, ref sqlTransaction);
                    if (writeGoodsStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (warnExistFlg)
                        {
                            updateNum++;
                        }
                        else
                        {
                            addNum++;
                        }

                        al.Add(goodsInfoDataWork);

                        //WARNING,ERROR����Ȃ�������NORMAL
                        if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                            status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        //���i�Ǘ����}�X�^
                        int writeGoodsMngStatus;
                        errorMessage = string.Empty;
                        writeGoodsMngStatus = WriteGoodsMngProcProc(ref  goodsInfoDataWork, goodsInfoParamCndtnWork, out  errorMessage, ref  sqlConnection, ref  sqlTransaction);
                        if (writeGoodsMngStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERROR����Ȃ�������NORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsMngStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                        //���i�}�X�^
                        errorMessage = string.Empty;
                        int writeGoodsPriceStatus;
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                        //writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease);
                        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                        
                        if (writeGoodsPriceStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERROR����Ȃ�������NORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsPriceStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                    }
                    else
                    {
                        writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsStatus, errorMessage));
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }

                }
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
            }
            finally
            {
                // ���
                convertDoubleRelease.Dispose();
            }
            // --- ADD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<

            retList.Add(updateNum);
            retList.Add(addNum);

            ret = retList;
            //goodsInfoDataWork = al;
            return status;
        }

        /// <summary>
        /// ���i���i�}�X�^ INSERT or UPDATE ����
        /// </summary>
        /// <param name="GoodsPriceUWork">���i���i�}�X�^</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">SQL�ڑ����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V�������</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^ INSERT or UPDATE �������s��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br></br>
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
        //private int WriteGoodsPrice(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteGoodsPrice(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
        {
            bool existFlg = false;
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try
            {
                //Select�R�}���h�̐���
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICEURF.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICEURF.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICEURF.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(goodsInfoDataWork.PriceStartDate.ToString(), "yyyyMMdd", null));

                DateTime updateCreateDateTime = DateTime.MinValue;
                Guid updateGuid = Guid.Empty;
                //�_���폜�敪
                Int32 updateDelete = -1;

                myReader = sqlCommand.ExecuteReader();

                if (0 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //insert or update 
                    if (myReader.Read())
                    {
                        ////����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        //if (_updateDateTime != goodsInfoDataWork.UpdateDateTime)
                        //{
                        //    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        //    if (goodsInfoDataWork.UpdateDateTime == DateTime.MinValue)
                        //    {
                        //        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //        errorMessage = "�d������f�[�^�����邽�ߍX�V�ł��܂���B";
                        //    }
                        //    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        //    else
                        //    {
                        //        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //        errorMessage = "���̃f�[�^�͊��ɍX�V����Ă��܂��B";
                        //    }

                        //    sqlCommand.Cancel();
                        //    return status;
                        //}

                        existFlg = true;

                        //�쐬����
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //�_���폜�敪
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //�X�V�p��SQL���𐶐�
                        sqlText = "";
                        sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                        sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                        sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                        //sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                        //sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        //sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(goodsInfoDataWork.PriceStartDate.ToString(), "yyyyMMdd", null));
                    }
                    else
                    {
                        ////����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        //if (goodsInfoDataWork.UpdateDateTime > DateTime.MinValue)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        //    errorMessage = "���̃f�[�^�͊��ɍ폜����Ă��܂��B";
                        //    sqlCommand.Cancel();
                        //    return status;
                        //}

                        existFlg = false;

                        //�V�K�쐬����SQL���𐶐�
                        sqlText = "";
                        sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "  ,GOODSNORF" + Environment.NewLine;
                        sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                        sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                        sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                        sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                        sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  ,@GOODSNO" + Environment.NewLine;
                        sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                        sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                        sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                        sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                        sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //�ȉ��̏����Ř_���폜�敪���O�ɏ����������Ă��܂��ׁA�ޔ����Ă���
                        //���i�݌Ƀ}�X�^����̘_���폜���Ɏg�p����
                        int logicalDeleteCode = goodsInfoDataWork.LogicalDeleteCode;

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        goodsInfoDataWork.LogicalDeleteCode = 0;
                    }

                }
                else if (1 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //update 
                    if (myReader.Read())
                    {
                        existFlg = true;

                        //�쐬����
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //�_���폜�敪
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //�X�V�p��SQL���𐶐�
                        sqlText = "";
                        sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                        sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                        sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                        //sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                        //sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        //sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(goodsInfoDataWork.PriceStartDate.ToString(), "yyyyMMdd", null));
                    }
                    else
                    {
                        existFlg = false;
                        return -1;
                    }
                }
                else
                {
                    //insert
                    if (myReader.Read())
                    {
                        existFlg = true;
                        return -1;
                    }
                    else
                    {
                        existFlg = false;
                        //�V�K�쐬����SQL���𐶐�
                        sqlText = "";
                        sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "  ,GOODSNORF" + Environment.NewLine;
                        sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                        sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                        sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                        sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                        sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  ,@GOODSNO" + Environment.NewLine;
                        sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                        sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                        sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                        sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                        sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //�ȉ��̏����Ř_���폜�敪���O�ɏ����������Ă��܂��ׁA�ޔ����Ă���
                        //���i�݌Ƀ}�X�^����̘_���폜���Ɏg�p����
                        int logicalDeleteCode = goodsInfoDataWork.LogicalDeleteCode;

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        goodsInfoDataWork.LogicalDeleteCode = 0;
                    }
                }

                //bool flg = myReader.Read();

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = null;
                SqlParameter paraOfferDate = null;
                SqlParameter paraUpdateDate = null;
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                    || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                    paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                }
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                if (existFlg)
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateCreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateGuid);
                    //if (updateDelete == -1)
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    //}
                    //else
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateDelete);
                    //}
                }
                else
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.CreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsInfoDataWork.FileHeaderGuid);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.LogicalDeleteCode);
                }
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId2);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(Convert.ToString(Convert.ToString(goodsInfoDataWork.PriceStartDate)), "yyyyMMdd", null));
                
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsInfoDataWork.Price);
                convertDoubleRelease.EnterpriseCode = goodsInfoDataWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = goodsInfoDataWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = goodsInfoDataWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = goodsInfoDataWork.Price;

                // �ϊ��������s
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/06/18 ���O PMKOBETSU-4005 ----------<<<<<
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble((goodsInfoDataWork.SalesUnitCost)/100);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble((goodsInfoDataWork.StockRate)/100);
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                    || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(0);
                    paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                    paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                }
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "�X�V�����ŃG���[���������܂����B";
                sqlCommand.Cancel();
                throw ex;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private int WriteGoodsUProcProc(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out bool existFlg, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            existFlg = false;
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;

                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);

                myReader = sqlCommand.ExecuteReader();

                //�쐬����
                DateTime updateCreateDateTime = DateTime.MinValue;
                //��ƃR�[�h
                Guid updateGuid = Guid.Empty;
                //�_���폜�敪
                Int32 updateDelete = -1;

                if (0 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //insert or update
                    if (myReader.Read())
                    {
                        existFlg = true;
                        ////����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        //if (_updateDateTime != goodsInfoDataWork.UpdateDateTime)
                        //{
                        //    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        //    if (goodsInfoDataWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //    sqlCommand.Cancel();
                        //    if (myReader.IsClosed == false) myReader.Close();
                        //    return status;
                        //}

                        sqlTxt = string.Empty;

                        //�쐬����
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //�_���폜�敪
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                        //sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        sqlTxt += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        existFlg = false;
                        ////����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        //if (goodsInfoDataWork.UpdateDateTime > DateTime.MinValue)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        //    sqlCommand.Cancel();
                        //    if (myReader.IsClosed == false) myReader.Close();
                        //    return status;
                        //}

                        sqlTxt = string.Empty + Environment.NewLine;
                        sqlTxt += "INSERT INTO GOODSURF" + Environment.NewLine;
                        sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        //sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "  ,DISPLAYORDERRF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                        sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSKINDCODERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF" + Environment.NewLine;
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
                        sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += "  ,@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "  )" + Environment.NewLine;

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = sqlTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                }
                else if (1 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //update
                    if (myReader.Read())
                    {
                        existFlg = true;

                        //�쐬����
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //�_���폜�敪
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlTxt = string.Empty;

                        sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                        //sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        sqlTxt += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        existFlg = false;
                        return -1;
                    }
                }
                else
                {
                    //insert
                    if (myReader.Read())
                    {
                        existFlg = true;
                        return -1;
                    }
                    else
                    {
                        sqlTxt = string.Empty + Environment.NewLine;
                        sqlTxt += "INSERT INTO GOODSURF" + Environment.NewLine;
                        sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        //sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "  ,DISPLAYORDERRF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                        sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSKINDCODERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF" + Environment.NewLine;
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
                        sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += "  ,@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "  )" + Environment.NewLine;

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = sqlTxt;
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                }

                //bool flg = myReader.Read();

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                //SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                //SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                SqlParameter paraOfferDate = null;
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                    || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                }


                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                //SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                //SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                //SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIVRF", SqlDbType.Int);
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);

                if (existFlg)
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateCreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateGuid);
                    //if (updateDelete == -1)
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    //}
                    //else
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateDelete);
                    //}
                }
                else
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.CreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsInfoDataWork.FileHeaderGuid);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                }
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId2);

                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsName);
                //paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNameKana);
                //paraJan.Value = SqlDataMediator.SqlSetString(goodsuWork.Jan);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraJan.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.BLGoodsCode);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(0);
                //paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsRateRank);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                //todo:�e�L�X�g�t�@�C���̕i�Ԃ��n�C�t�������������i��
                paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo.Replace("-", ""));
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                         || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                }
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(1);
                //paraGoodsNote1.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote1);
                //paraGoodsNote2.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote2);
                //paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsSpecialNote);
                paraGoodsNote1.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraGoodsNote2.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(0);




                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "�X�V�����ŃG���[���������܂����B";
                sqlCommand.Cancel();
                throw ex;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

        /// <summary>
        /// ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private int WriteGoodsMngProcProc(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            bool existFlg = false;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                DateTime updateCreateDateTime = DateTime.MinValue;
                Guid updateGuid = Guid.Empty;
                //�_���폜�敪
                Int32 updateDelete = -1;

                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "  GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += " ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += " ,GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += " ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += " ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                findParaSectionCode.Value = "00";
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                //todo:���i�����ރR�[�h���Ȃ��B
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);

                if (SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo) == DBNull.Value)
                {
                    findParaGoodsNo.Value = string.Empty;
                }
                else
                {
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                }

                myReader = sqlCommand.ExecuteReader();


                //insert update
                if (myReader.Read())
                {
                    ////����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    //if (_updateDateTime != goodsInfoDataWork.UpdateDateTime)
                    //{
                    //    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    //    if (goodsInfoDataWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    //    sqlCommand.Cancel();
                    //    if (myReader.IsClosed == false) myReader.Close();
                    //    return status;
                    //}
                    existFlg = true;

                    //�쐬����
                    updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //GUID
                    updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //�_���폜�敪
                    updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE GOODSMNGRF SET" + Environment.NewLine;
                    sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                    sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                    sqlTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                    sqlTxt += " , SUPPLIERLOTRF=@SUPPLIERLOT" + Environment.NewLine;
                    sqlTxt += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlTxt += "  AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                    findParaSectionCode.Value = "00";
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                    //todo:���i�����ރR�[�h
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);

                    if (SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo) == DBNull.Value)
                    {
                        findParaGoodsNo.Value = string.Empty;
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                    }

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    ////����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    //if (goodsInfoDataWork.UpdateDateTime > DateTime.MinValue)
                    //{
                    //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    //    sqlCommand.Cancel();
                    //    if (myReader.IsClosed == false) myReader.Close();
                    //    return status;
                    //}
                    existFlg = false;
                    sqlTxt = string.Empty;
                    sqlTxt += "INSERT INTO GOODSMNGRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                    sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;
                    sqlTxt += " VALUES" + Environment.NewLine;
                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                    sqlTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                    sqlTxt += "  ,@SUPPLIERLOT" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSMGROUP" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;

                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = sqlTxt;
                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierLot = sqlCommand.Parameters.Add("@SUPPLIERLOT", SqlDbType.Int);
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraSectionCode.Value = "00";

                if (SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo) == DBNull.Value)
                {
                    paraGoodsNo.Value = string.Empty;
                }
                else
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                }

                if (existFlg)
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateCreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateGuid);
                    //if (updateDelete == -1)
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    //}
                    //else
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateDelete);
                    //}
                }
                else
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.CreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsInfoDataWork.FileHeaderGuid);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                }
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId2);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32((goodsInfoDataWork.SupplierCd) * 100);
                paraSupplierLot.Value = SqlDataMediator.SqlSetInt32(0);
                //todo:notnull 0���Z�b�g����B
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);



                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "�X�V�����ŃG���[���������܂����B";
                sqlCommand.Cancel();
                throw ex;
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �o�^�G���[�I�u�W�F�N�g�̐���
        /// </summary>
        /// <param name="GoodsPriceUWork">���i���i�}�X�^</param>
        /// <param name="errorCode">�G���[�R�[�h</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>���i���i�o�^�G���[</returns>
        /// <br>Note       : �o�^�G���[�I�u�W�F�N�g�̐������s��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private GoodsInfoDataWork SetError(GoodsInfoDataWork goodsInfoDataWork, int errorCode, string errorMessage)
        {

            GoodsInfoDataWork goodsPriceWriteErrorWork = new GoodsInfoDataWork();

            goodsPriceWriteErrorWork.CreateDateTime = goodsInfoDataWork.CreateDateTime;
            goodsPriceWriteErrorWork.UpdateDateTime = goodsInfoDataWork.UpdateDateTime;
            goodsPriceWriteErrorWork.EnterpriseCode = goodsInfoDataWork.EnterpriseCode;
            goodsPriceWriteErrorWork.FileHeaderGuid = goodsInfoDataWork.FileHeaderGuid;
            goodsPriceWriteErrorWork.UpdEmployeeCode = goodsInfoDataWork.UpdEmployeeCode;
            goodsPriceWriteErrorWork.UpdAssemblyId1 = goodsInfoDataWork.UpdAssemblyId1;
            goodsPriceWriteErrorWork.UpdAssemblyId2 = goodsInfoDataWork.UpdAssemblyId2;
            goodsPriceWriteErrorWork.LogicalDeleteCode = goodsInfoDataWork.LogicalDeleteCode;
            goodsPriceWriteErrorWork.GoodsMakerCd = goodsInfoDataWork.GoodsMakerCd;
            goodsPriceWriteErrorWork.GoodsNo = goodsInfoDataWork.GoodsNo;
            goodsPriceWriteErrorWork.PriceStartDate = goodsInfoDataWork.PriceStartDate;
            goodsPriceWriteErrorWork.Price = goodsInfoDataWork.Price;
            goodsPriceWriteErrorWork.SalesUnitCost = goodsInfoDataWork.SalesUnitCost;
            goodsPriceWriteErrorWork.StockRate = goodsInfoDataWork.StockRate;
            //goodsPriceWriteErrorWork.OpenPriceDiv = goodsInfoDataWork.OpenPriceDiv;
            //goodsPriceWriteErrorWork.OfferDate = goodsInfoDataWork.OfferDate;
            //goodsPriceWriteErrorWork.UpdateDate = goodsInfoDataWork.UpdateDate;
            goodsPriceWriteErrorWork.ErrorCode = errorCode;
            goodsPriceWriteErrorWork.ErrorMessage = errorMessage;
            return goodsPriceWriteErrorWork;
        }


        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection�����������s��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

    }
}
