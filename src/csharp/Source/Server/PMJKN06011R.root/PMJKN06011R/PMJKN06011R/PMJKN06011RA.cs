using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;  // ADD 2020/06/18 杍^ PMKOBETSU-4005 

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ���R�������i�擾DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^���擾�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22018  ��� ���b</br>
    /// <br>Date       : 2010/04/26</br>
    /// <br></br>
    /// <br>Update Note: 2014/02/06 ���� ����q</br>
    /// <br>�Ǘ��ԍ�   : </br>
    /// <br>           : SCM�d�|�ꗗ��10632�Ή�</br>
    /// <br>Update Note: 2020/06/18 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FreeSearchPartsSearchDB : RemoteDB, IFreeSearchPartsSearchDB
    {
        #region [ Query ]
        private const string ctQryBLSearch =
                      "SELECT "
                    + "FSP.CREATEDATETIMERF "
                    + ",FSP.UPDATEDATETIMERF "
                    + ",FSP.ENTERPRISECODERF "
                    + ",FSP.FILEHEADERGUIDRF "
                    + ",FSP.UPDEMPLOYEECODERF "
                    + ",FSP.UPDASSEMBLYID1RF "
                    + ",FSP.UPDASSEMBLYID2RF "
                    + ",FSP.LOGICALDELETECODERF "
                    + ",FSP.FRESRCHPRTPROPNORF "
                    + ",FSP.MAKERCODERF "
                    + ",FSP.MODELCODERF "
                    + ",FSP.MODELSUBCODERF "
                    + ",FSP.FULLMODELRF "
                    + ",FSP.TBSPARTSCODERF "
                    + ",FSP.TBSPARTSCDDERIVEDNORF "
                    + ",FSP.GOODSNORF "
                    + ",FSP.GOODSNONONEHYPHENRF "
                    + ",FSP.GOODSMAKERCDRF "
                    + ",FSP.PARTSQTYRF "
                    + ",FSP.PARTSOPNMRF "
                    + ",FSP.MODELPRTSADPTYMRF "
                    + ",FSP.MODELPRTSABLSYMRF "
                    + ",FSP.MODELPRTSADPTFRAMENORF "
                    + ",FSP.MODELPRTSABLSFRAMENORF "
                    + ",FSP.MODELGRADENMRF "
                    + ",FSP.BODYNAMERF "
                    + ",FSP.DOORCOUNTRF "
                    + ",FSP.ENGINEMODELNMRF "
                    + ",FSP.ENGINEDISPLACENMRF "
                    + ",FSP.EDIVNMRF "
                    + ",FSP.TRANSMISSIONNMRF "
                    + ",FSP.WHEELDRIVEMETHODNMRF "
                    + ",FSP.SHIFTNMRF "
                    + ",FSP.CREATEDATERF "
                    + ",FSP.UPDATEDATERF "
                    + ",GDS.GOODSNORF AS GOODSNOFROMGOODSRF "
                    + ",GDS.GOODSNAMERF "
                    + ",GDS.GOODSNAMEKANARF "
                    + ",GDS.GOODSRATERANKRF "
                    + ",GDS.BLGOODSCODERF AS BLGOODSCODEFROMGOODSRF "
                    + ",PRC.GOODSNORF AS GOODSNOFROMPRICERF "
                    + ",PRC.PRICESTARTDATERF "
                    + ",PRC.LISTPRICERF "
                    + ",PRC.OPENPRICEDIVRF "
                    + ",BLC.BLGOODSFULLNAMERF "
                    + ",BLC.BLGOODSHALFNAMERF ";

        #endregion

        #region [ �R���X�g���N�^ ]
        /// <summary>
        /// ���R�������i���擾DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        public FreeSearchPartsSearchDB()
            :
            base("PMJKN06013D", "Broadleaf.Application.Remoting.FreeSearchPartsSearchDB", "FREESEARCHPARTSRF")
        {
        }
        #endregion

        #region [ Search ]
        /// <summary>
        /// ���R�������i�}�X�^�擾����
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retParts"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        public int Search( FreeSearchPartsSParaWork inPara, ref object retParts, out long retCnt )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            retParts = null;
            retCnt = 0;

            ArrayList alRetParts = new ArrayList();

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                // ���i�������C��
                status = SearchPartsInf( inPara, ref alRetParts, ref sqlConnection );
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // ���ʊi�[
            retParts = alRetParts;
            retCnt = alRetParts.Count;


            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                retParts = null;
            }

            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���R�������i�}�X�^�擾����
        /// </summary>
        /// <param name="inParaList"></param>
        /// <param name="retParts"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        public int Search(ArrayList inParaList, ref object retParts, out long retCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            retParts = null;
            retCnt = 0;

            ArrayList alRetParts = new ArrayList();

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                // ���i�������C��
                status = SearchPartsInf(inParaList, ref alRetParts, ref retCnt,  ref sqlConnection);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // ���ʊi�[
            retParts = alRetParts;

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retParts = null;
            }

            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���R�������i�̌���
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Programmer : 22018�@��� ���b</br>
        /// <br>Date       : 2010/04/26</br>
        private int SearchPartsInf( FreeSearchPartsSParaWork inPara, ref ArrayList alRetParts, ref SqlConnection sqlConnection )
        {
            ArrayList retInf = new ArrayList();
            ArrayList retEquip = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //���ʂ̏�����
            retInf = new ArrayList();

            try
            {
                // ���i�ŗL�ԍ��̏d���`�F�b�N�p (������Ɉ��k�������s�����A�������̈׃f�B�N�V���i���œ��ꃌ�R�[�h�����O����)
                Dictionary<string, bool> freSrchPrtPropNoDic = new Dictionary<string, bool>();


                // �a�k�R�[�h���� or �ŗL�ԍ��z�񌟍�
                if ( inPara.FreSrchPrtPropNos == null || inPara.FreSrchPrtPropNos.Length == 0 )
                {
                    // ���q���̊Y�����i����
                    for ( int modelIndex = 0; modelIndex < inPara.FSPartsSModels.Length; modelIndex++ )
                    {
                        //���i����
                        status = SearchPartsInfProc( inPara, modelIndex, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection );
                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                             status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                        {
                            break;
                        }
                    }

                    // STATUS�̍Đݒ�
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && retInf.Count > 0 )
                    {
                        // �Ō�̎��q�ŊY���������Ă��A�r���Œ��o�f�[�^������ꍇ��ctDB_NORMAL�ɕ␳����
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // ���o���ʂ̈��k����
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        CompressPartsRec( inPara, ref retInf );
                    }
                }
                else
                {
                    // �ŗL�ԍ��z�񌟍�
                    status = SearchPartsInfProc( inPara, 0, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection );
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = -1;
            }

            alRetParts = retInf;

            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���R�������i�̌���
        /// </summary>
        /// <param name="inParaList"></param>
        /// <param name="alRetParts"></param>
        /// <param name="retCount"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPartsInf(ArrayList inParaList, ref ArrayList alRetParts, ref long retCount, ref SqlConnection sqlConnection)
        {
            ArrayList retInf = new ArrayList();
            ArrayList retEquip = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;


            try
            {
                foreach (FreeSearchPartsSParaWork inPara in inParaList)
                {
                    // ���i�ŗL�ԍ��̏d���`�F�b�N�p (������Ɉ��k�������s�����A�������̈׃f�B�N�V���i���œ��ꃌ�R�[�h�����O����)
                    Dictionary<string, bool> freSrchPrtPropNoDic = new Dictionary<string, bool>();
                    //���ʂ̏�����
                    retInf = new ArrayList();

                    // �a�k�R�[�h���� or �ŗL�ԍ��z�񌟍�
                    if (inPara.FreSrchPrtPropNos == null || inPara.FreSrchPrtPropNos.Length == 0)
                    {
                        // ���q���̊Y�����i����
                        for (int modelIndex = 0; modelIndex < inPara.FSPartsSModels.Length; modelIndex++)
                        {
                            //���i����
                            status = SearchPartsInfProc(inPara, modelIndex, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                                 status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                break;
                            }
                        }

                        // STATUS�̍Đݒ�
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && retInf.Count > 0)
                        {
                            // �Ō�̎��q�ŊY���������Ă��A�r���Œ��o�f�[�^������ꍇ��ctDB_NORMAL�ɕ␳����
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        // ���o���ʂ̈��k����
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CompressPartsRec(inPara, ref retInf);
                        }
                    }
                    else
                    {
                        // �ŗL�ԍ��z�񌟍�
                        status = SearchPartsInfProc(inPara, 0, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection);
                    }
                    alRetParts.Add(retInf);
                    retCount += retInf.Count;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = -1;
            }
            if (retCount != 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���R�������i�}�X�^����
        /// </summary>
        /// <param name="inPara">�����p�����[�^</param>
        /// <param name="modelIndex">�^������index</param>
        /// <param name="freSrchPrtPropNoDic">���R�������i�ŗL�ԍ��f�B�N�V���i��</param>
        /// <param name="retInf">���o�������i���R�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V�����N���X</param>
        /// <returns></returns>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchPartsInfProc( FreeSearchPartsSParaWork inPara, int modelIndex, ref Dictionary<string, bool> freSrchPrtPropNoDic, ref ArrayList retInf, ref SqlConnection sqlConnection )
        {
            SqlDataReader myReader = null;
            //���ʂ�ArrayList�ɂ�����Ə��N���X
            FreeSearchPartsSRetWork mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string orderstring = string.Empty;
            string queryCol = string.Empty;
            string originalPartsNo = string.Empty;
            string partsNo = string.Empty;

            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<

            try
            {
                SqlCommand sqlCommand = new SqlCommand();

                // Select�R�}���h�����i���R�������i�E���i�E���i�j
                selectstr = ctQryBLSearch;

                fromstr = " FROM FREESEARCHPARTSRF AS FSP " + Environment.NewLine;
                fromstr += "  LEFT JOIN BLGOODSCDURF AS BLC " + Environment.NewLine;
                fromstr += "    ON (FSP.ENTERPRISECODERF = BLC.ENTERPRISECODERF AND FSP.TBSPARTSCODERF = BLC.BLGOODSCODERF AND BLC.LOGICALDELETECODERF = @FINDLOGICALDELETECODE) " + Environment.NewLine;
                fromstr += "  LEFT JOIN GOODSURF AS GDS " + Environment.NewLine;
                fromstr += "    ON (FSP.ENTERPRISECODERF = GDS.ENTERPRISECODERF AND FSP.GOODSNORF = GDS.GOODSNORF AND FSP.GOODSMAKERCDRF = GDS.GOODSMAKERCDRF AND GDS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE) " + Environment.NewLine;
                fromstr += "  LEFT JOIN GOODSPRICEURF AS PRC " + Environment.NewLine;
                fromstr += "    ON (FSP.ENTERPRISECODERF = PRC.ENTERPRISECODERF AND FSP.GOODSNORF = PRC.GOODSNORF AND FSP.GOODSMAKERCDRF = PRC.GOODSMAKERCDRF AND PRC.LOGICALDELETECODERF = @FINDLOGICALDELETECODE) " + Environment.NewLine;

                # region [WHERE]

                wherestr = "WHERE ";

                // ��ƺ���
                wherestr += "  FSP.ENTERPRISECODERF = @FINDENTERPRISECODE ";
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString( inPara.EnterpriseCode );

                // �_���폜
                wherestr += " AND FSP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE";
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
                findLogicalDeleteCode.Value = 0;

                // �a�k�R�[�h
                if ( inPara.TbsPartsCode != 0 )
                {
                    wherestr += " AND FSP.TBSPARTSCODERF = @FINDTBSPARTSCODE ";
                    SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add( "@FINDTBSPARTSCODE", SqlDbType.Int );
                    findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32( inPara.TbsPartsCode );
                }

                // �i��
                if ( inPara.GoodsNo != string.Empty )
                {
                    wherestr += " AND FSP.GOODSNORF = @FINDGOODSNO ";
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NVarChar );
                    findGoodsNo.Value = SqlDataMediator.SqlSetString( inPara.GoodsNo );
                }

                // ���i���[�J�[�R�[�h
                if ( inPara.GoodsMakerCd != 0 )
                {
                    wherestr += " AND FSP.GOODSMAKERCDRF = @FINDGOODSMAKERCD ";
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( inPara.GoodsMakerCd );
                }

                // ���i�J�n��
                if ( inPara.PriceStartDate != DateTime.MinValue )
                {
                    wherestr += " AND ( PRICESTARTDATERF IS NULL OR PRICESTARTDATERF <= @FINDPRICESTARTDATE ) ";
                    SqlParameter findPriceStartDate = sqlCommand.Parameters.Add( "@FINDPRICESTARTDATE", SqlDbType.Int );
                    findPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( inPara.PriceStartDate );
                }

                // ���R�������i�ŗL�ԍ��z��
                if ( inPara.FreSrchPrtPropNos != null && inPara.FreSrchPrtPropNos.Length > 0 )
                {
                    wherestr += " AND FRESRCHPRTPROPNORF IN ( ";
                    for ( int propIndex = 0; propIndex < inPara.FreSrchPrtPropNos.Length; propIndex++ )
                    {
                        if ( propIndex > 0 )
                        {
                            wherestr += ",";
                        }
                        wherestr += string.Format( "@FINDFRESRCHPRTPROPNO{0}", propIndex );
                        SqlParameter findFreSrchPrtPropNo = sqlCommand.Parameters.Add( string.Format( "@FINDFRESRCHPRTPROPNO{0}", propIndex ), SqlDbType.NChar );
                        findFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString( inPara.FreSrchPrtPropNos[propIndex] );
                    }
                    wherestr += " ) ";
                }

                // �^�����E�������̍i�荞�݁i���̃��\�b�h�P��ɕt���AmodelIndex�œ��肵���P���q�݂̂��ΏۂƂȂ�j
                if ( inPara.FSPartsSModels != null && inPara.FSPartsSModels.Length > modelIndex )
                {
                    FreeSearchPartsSMdlParaWork mdlPara = inPara.FSPartsSModels[modelIndex];

                    # region [�Ώێ��q��]

                    //--------------------------------------------------
                    // �^�����
                    //--------------------------------------------------

                    // ���[�J�[�R�[�h
                    if ( mdlPara.MakerCode != 0 )
                    {
                        wherestr += " AND FSP.MAKERCODERF = @FINDMAKERCODE ";
                        SqlParameter findMakerCode = sqlCommand.Parameters.Add( "@FINDMAKERCODE", SqlDbType.Int );
                        findMakerCode.Value = SqlDataMediator.SqlSetInt32( mdlPara.MakerCode );
                    }

                    // �Ԏ�R�[�h
                    if ( mdlPara.ModelCode != 0 )
                    {
                        wherestr += " AND FSP.MODELCODERF = @FINDMODELCODE ";
                        SqlParameter findModelCode = sqlCommand.Parameters.Add( "@FINDMODELCODE", SqlDbType.Int );
                        findModelCode.Value = SqlDataMediator.SqlSetInt32( mdlPara.ModelCode );
                    }

                    // �Ԏ�T�u�R�[�h
                    if ( mdlPara.ModelSubCode != -1 )
                    {
                        wherestr += " AND FSP.MODELSUBCODERF = @FINDMODELSUBCODE ";
                        SqlParameter findModelSubCode = sqlCommand.Parameters.Add( "@FINDMODELSUBCODE", SqlDbType.Int );
                        findModelSubCode.Value = SqlDataMediator.SqlSetInt32( mdlPara.ModelSubCode );
                    }

                    // �^���i�t���^�j
                    if ( mdlPara.FullModel != string.Empty )
                    {
                        wherestr += " AND FSP.FULLMODELRF = @FINDFULLMODEL ";
                        SqlParameter findFullModel = sqlCommand.Parameters.Add( "@FINDFULLMODEL", SqlDbType.NVarChar );
                        findFullModel.Value = SqlDataMediator.SqlSetString( mdlPara.FullModel );
                    }

                    //--------------------------------------------------
                    // �N���E�ԑ�ԍ��͈̔�
                    //--------------------------------------------------

                    // �N���i�J�n�`�I���j
                    if ( mdlPara.ProduceTypeOfYear != 0 )
                    {
                        if ( mdlPara.ProduceTypeOfYear % 100 == 0 )
                        {
                            //--------------------
                            // �N�̂� (��:201000)
                            //--------------------

                            // �J�n
                            wherestr += " AND (FSP.MODELPRTSADPTYMRF / 100 <= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSADPTYMRF = 0 OR FSP.MODELPRTSADPTYMRF IS NULL) ";
                            // �I��
                            wherestr += " AND (FSP.MODELPRTSABLSYMRF / 100 >= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSABLSYMRF = 0 OR FSP.MODELPRTSABLSYMRF IS NULL) ";

                            SqlParameter findProduceTypeOfYear = sqlCommand.Parameters.Add( "@FINDPRODUCETYPEOFYEAR", SqlDbType.Int );
                            findProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32( mdlPara.ProduceTypeOfYear / 100 );
                        }
                        else
                        {
                            //--------------------
                            // �N�� (��:201012)
                            //--------------------

                            // �J�n
                            //wherestr += " AND (FSP.MODELPRTSADPTYMRF <= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSADPTYMRF = 0) ";
                            wherestr += " AND (FSP.MODELPRTSADPTYMRF <= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSADPTYMRF = 0 OR FSP.MODELPRTSADPTYMRF IS NULL) ";
                            // �I��
                            //wherestr += " AND (FSP.MODELPRTSABLSYMRF >= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSABLSYMRF = 0) ";
                            wherestr += " AND (FSP.MODELPRTSABLSYMRF >= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSABLSYMRF = 0 OR FSP.MODELPRTSABLSYMRF IS NULL) ";

                            SqlParameter findProduceTypeOfYear = sqlCommand.Parameters.Add( "@FINDPRODUCETYPEOFYEAR", SqlDbType.Int );
                            findProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32( mdlPara.ProduceTypeOfYear );
                        }
                    }

                    // �ԑ�ԍ�
                    if ( mdlPara.ProduceFrameNo != 0 )
                    {
                        // �J�n
                        //wherestr += " AND (FSP.MODELPRTSADPTFRAMENORF <= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSADPTFRAMENORF = 0) ";
                        wherestr += " AND (FSP.MODELPRTSADPTFRAMENORF <= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSADPTFRAMENORF = 0 OR FSP.MODELPRTSADPTFRAMENORF IS NULL) ";
                        // �I��
                        //wherestr += " AND (FSP.MODELPRTSABLSFRAMENORF >= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSABLSFRAMENORF = 0) ";
                        wherestr += " AND (FSP.MODELPRTSABLSFRAMENORF >= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSABLSFRAMENORF = 0 OR FSP.MODELPRTSABLSFRAMENORF IS NULL) ";

                        SqlParameter findProduceFrameNo = sqlCommand.Parameters.Add( "@FINDPRODUCEFRAMENO", SqlDbType.Int );
                        findProduceFrameNo.Value = SqlDataMediator.SqlSetInt32( mdlPara.ProduceFrameNo );
                    }

                    //--------------------------------------------------
                    // �������
                    //--------------------------------------------------

                    // �^���O���[�h����
                    if ( mdlPara.ModelGradeNm != string.Empty )
                    {
                        wherestr += " AND (FSP.MODELGRADENMRF IS NULL OR FSP.MODELGRADENMRF = @FINDMODELGRADENM OR FSP.MODELGRADENMRF = '') ";
                        SqlParameter findModelGradeNm = sqlCommand.Parameters.Add( "@FINDMODELGRADENM", SqlDbType.NVarChar );
                        findModelGradeNm.Value = SqlDataMediator.SqlSetString( mdlPara.ModelGradeNm );
                    }

                    // �{�f�B�[����
                    if ( mdlPara.BodyName != string.Empty )
                    {
                        wherestr += " AND (FSP.BODYNAMERF IS NULL OR FSP.BODYNAMERF = @FINDBODYNAME OR FSP.BODYNAMERF = '') ";
                        SqlParameter findBodyName = sqlCommand.Parameters.Add( "@FINDBODYNAME", SqlDbType.NVarChar );
                        findBodyName.Value = SqlDataMediator.SqlSetString( mdlPara.BodyName );
                    }

                    // �h�A��
                    if ( mdlPara.DoorCount != 0 )
                    {
                        wherestr += " AND (FSP.DOORCOUNTRF IS NULL OR FSP.DOORCOUNTRF = @FINDDOORCOUNT OR FSP.DOORCOUNTRF = 0) ";
                        SqlParameter findDoorCount = sqlCommand.Parameters.Add( "@FINDDOORCOUNT", SqlDbType.Int );
                        findDoorCount.Value = SqlDataMediator.SqlSetInt32( mdlPara.DoorCount );
                    }

                    // �G���W���^������
                    if ( mdlPara.EngineModelNm != string.Empty )
                    {
                        wherestr += " AND (FSP.ENGINEMODELNMRF IS NULL OR FSP.ENGINEMODELNMRF = @FINDENGINEMODELNM OR FSP.ENGINEMODELNMRF = '') ";
                        SqlParameter findEngineModelNm = sqlCommand.Parameters.Add( "@FINDENGINEMODELNM", SqlDbType.NVarChar );
                        findEngineModelNm.Value = SqlDataMediator.SqlSetString( mdlPara.EngineModelNm );
                    }

                    // �r�C�ʖ���
                    if ( mdlPara.EngineDisplaceNm != string.Empty )
                    {
                        wherestr += " AND (FSP.ENGINEDISPLACENMRF IS NULL OR FSP.ENGINEDISPLACENMRF = @FINDENGINEDISPLACENM OR FSP.ENGINEDISPLACENMRF = '') ";
                        SqlParameter findEngineDisplaceNm = sqlCommand.Parameters.Add( "@FINDENGINEDISPLACENM", SqlDbType.NVarChar );
                        findEngineDisplaceNm.Value = SqlDataMediator.SqlSetString( mdlPara.EngineDisplaceNm );
                    }

                    // E�敪����
                    if ( mdlPara.EDivNm != string.Empty )
                    {
                        wherestr += " AND (FSP.EDIVNMRF IS NULL OR FSP.EDIVNMRF = @FINDEDIVNM OR FSP.EDIVNMRF = '') ";
                        SqlParameter findEDivNm = sqlCommand.Parameters.Add( "@FINDEDIVNM", SqlDbType.NVarChar );
                        findEDivNm.Value = SqlDataMediator.SqlSetString( mdlPara.EDivNm );
                    }

                    // �~�b�V��������
                    if ( mdlPara.TransmissionNm != string.Empty )
                    {
                        wherestr += " AND (FSP.TRANSMISSIONNMRF IS NULL OR FSP.TRANSMISSIONNMRF = @FINDTRANSMISSIONNM OR FSP.TRANSMISSIONNMRF ='') ";
                        SqlParameter findTransmissionNm = sqlCommand.Parameters.Add( "@FINDTRANSMISSIONNM", SqlDbType.NVarChar );
                        findTransmissionNm.Value = SqlDataMediator.SqlSetString( mdlPara.TransmissionNm );
                    }

                    // �V�t�g����
                    if ( mdlPara.ShiftNm != string.Empty )
                    {
                        wherestr += " AND (FSP.SHIFTNMRF IS NULL OR FSP.SHIFTNMRF = @FINDSHIFTNM OR FSP.SHIFTNMRF = '') ";
                        SqlParameter findShiftNm = sqlCommand.Parameters.Add( "@FINDSHIFTNM", SqlDbType.NVarChar );
                        findShiftNm.Value = SqlDataMediator.SqlSetString( mdlPara.ShiftNm );
                    }

                    // �쓮��������
                    if ( mdlPara.WheelDriveMethodNm != string.Empty )
                    {
                        wherestr += " AND (FSP.WHEELDRIVEMETHODNMRF IS NULL OR FSP.WHEELDRIVEMETHODNMRF = @FINDWHEELDRIVEMETHODNM OR FSP.WHEELDRIVEMETHODNMRF = '') ";
                        SqlParameter findWheelDriveMethodNm = sqlCommand.Parameters.Add( "@FINDWHEELDRIVEMETHODNM", SqlDbType.NVarChar );
                        findWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString( mdlPara.WheelDriveMethodNm );
                    }
                    # endregion
                }
                # endregion

                orderstring = " ORDER BY FSP.FULLMODELRF, FSP.GOODSNORF, FSP.GOODSMAKERCDRF, FSP.MODELPRTSADPTFRAMENORF, PRC.PRICESTARTDATERF DESC";

                string strdum = selectstr + fromstr + wherestr + orderstring;

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strdum;
                sqlCommand.Transaction = null;


                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // ���R�������i�ŗL�ԍ��̎擾
                    string freSrchPrtPropNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRESRCHPRTPROPNORF" ) );  // ���R�������i�ŗL�ԍ�
                    
                    // �ŗL�ԍ��̏d���`�F�b�N�i���i�}�X�^���������R�[�h�L��ꍇ�����̃`�F�b�N�ōŐV�̂ݎc��j
                    if ( freSrchPrtPropNoDic.ContainsKey( freSrchPrtPropNo ) )
                    {
                        continue;
                    }
                    freSrchPrtPropNoDic.Add( freSrchPrtPropNo, true );

                    // ���o���ʃZ�b�g
                    mf = new FreeSearchPartsSRetWork();

                    # region [���o���ʂ̃Z�b�g]
                    mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "CREATEDATETIMERF" ) );  // �쐬����
                    mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );  // �X�V����
                    mf.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );  // ��ƃR�[�h
                    mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid( myReader, myReader.GetOrdinal( "FILEHEADERGUIDRF" ) );  // GUID
                    mf.UpdEmployeeCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDEMPLOYEECODERF" ) );  // �X�V�]�ƈ��R�[�h
                    mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID1RF" ) );  // �X�V�A�Z���u��ID1
                    mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID2RF" ) );  // �X�V�A�Z���u��ID2
                    mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "LOGICALDELETECODERF" ) );  // �_���폜�敪
                    mf.FreSrchPrtPropNo = freSrchPrtPropNo;  // ���R�������i�ŗL�ԍ�
                    mf.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );  // ���[�J�[�R�[�h
                    mf.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );  // �Ԏ�R�[�h
                    mf.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );  // �Ԏ�T�u�R�[�h
                    mf.FullModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );  // �^���i�t���^�j
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );  // �a�k�R�[�h
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNORF" ) );  // �a�k�R�[�h�}��
                    mf.GoodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );  // ���i�ԍ�
                    mf.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNONONEHYPHENRF" ) );  // �n�C�t�������i�ԍ�
                    mf.GoodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );  // ���i���[�J�[�R�[�h
                    mf.PartsQty = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSQTYRF" ) );  // ���iQTY
                    mf.PartsOpNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSOPNMRF" ) );  // ���i�I�v�V��������
                    mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "MODELPRTSADPTYMRF" ) );  // �^���ʕ��i�̗p�N��
                    mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "MODELPRTSABLSYMRF" ) );  // �^���ʕ��i�p�~�N��
                    mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELPRTSADPTFRAMENORF" ) );  // �^���ʕ��i�̗p�ԑ�ԍ�
                    mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELPRTSABLSFRAMENORF" ) );  // �^���ʕ��i�p�~�ԑ�ԍ�
                    mf.ModelGradeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELGRADENMRF" ) );  // �^���O���[�h����
                    mf.BodyName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BODYNAMERF" ) );  // �{�f�B�[����
                    mf.DoorCount = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DOORCOUNTRF" ) );  // �h�A��
                    mf.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );  // �G���W���^������
                    mf.EngineDisplaceNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEDISPLACENMRF" ) );  // �r�C�ʖ���
                    mf.EDivNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EDIVNMRF" ) );  // E�敪����
                    mf.TransmissionNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSMISSIONNMRF" ) );  // �~�b�V��������
                    mf.WheelDriveMethodNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WHEELDRIVEMETHODNMRF" ) );  // �쓮��������
                    mf.ShiftNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIFTNMRF" ) );  // �V�t�g����
                    mf.CreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "CREATEDATERF" ) );  // �쐬���t
                    mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "UPDATEDATERF" ) );  // �X�V�N����
                    mf.GoodsNoFromGoods = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNOFROMGOODSRF" ) );  // ���i�ԍ�[���i�}�X�^]
                    mf.GoodsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );  // ���i����
                    mf.GoodsNameKana = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMEKANARF" ) );  // ���i���̃J�i
                    mf.GoodsRateRank = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSRATERANKRF" ) );  // ���i�|�������N
                    mf.GoodsNoFromPrice = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNOFROMPRICERF" ) );  // ���i�ԍ�[���i�}�X�^]
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "PRICESTARTDATERF" ) );  // ���i�J�n��
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICERF" ) );  // �艿
                    convertDoubleRelease.EnterpriseCode = mf.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // �ϊ��������s
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );  // �I�[�v�����i�敪
                    mf.BLGoodsFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSFULLNAMERF" ) );  // �a�k���i����
                    mf.BLGoodsHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSHALFNAMERF" ) );  // �a�k���i���̃J�i
                    mf.BLGoodsCodeFromGoods = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODEFROMGOODSRF" ) );  // ���i�}�X�^�a�k�R�[�h
                    # endregion

                    # region [�^���O�E�P�E�Q�̃Z�b�g(�w�肳�ꂽ���o�������)]
                    if ( inPara.FSPartsSModels != null && inPara.FSPartsSModels.Length > modelIndex )
                    {
                        mf.ExhaustGasSign = inPara.FSPartsSModels[modelIndex].ExhaustGasSign;
                        mf.SeriesModel = inPara.FSPartsSModels[modelIndex].SeriesModel;
                        mf.CategorySignModel = inPara.FSPartsSModels[modelIndex].CategorySignModel;
                    }
                    # endregion

                    retInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion

        #region [ ���ꕔ�i��񈳏k���� ]
        /// <summary>
        /// ���ꕔ�i���k����
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retInf">���o���ʕ��i���R�[�h</param>
        private void CompressPartsRec( FreeSearchPartsSParaWork inPara, ref ArrayList retInf )
        {
            ArrayList alwk = new ArrayList();
            FreeSearchPartsSRetWork rtwk = new FreeSearchPartsSRetWork();
            int existsFlag = 0;

            foreach ( FreeSearchPartsSRetWork mf in retInf )
            {
                if ( mf != null )
                {
                    existsFlag = 0;
                    foreach ( FreeSearchPartsSRetWork mf2 in alwk )
                    {
                        if ( mf2 != null )
                        {
                            if ( (mf.MakerCode == mf2.MakerCode) &&
                                (mf.GoodsNo == mf2.GoodsNo) &&
                                (mf.PartsQty == mf2.PartsQty) &&
                                (mf.PartsOpNm == mf2.PartsOpNm) )
                            {
                                if ( (((mf.ModelPrtsAdptYm == mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm == mf2.ModelPrtsAblsYm)) ||
                                     ((mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm)) ||
                                     ((mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm)) ||
                                     ((mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm))) &&
                                    (((mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo) && (mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo)) ||
                                       (mf.ModelPrtsAdptFrameNo >= mf2.ModelPrtsAdptFrameNo) && (mf.ModelPrtsAblsFrameNo <= mf2.ModelPrtsAblsFrameNo)) )
                                {
                                    if ( (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm )
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                        if ( mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm )
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }
                                    if ( (mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm )
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                    }
                                    if ( (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm )
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }
                                    // ���i���̍X�V
                                    if ( (mf2.PriceStartDate < mf.PriceStartDate) &&
                                         (mf.PriceStartDate <= inPara.PriceStartDate) )
                                    {
                                        mf2.ListPrice = mf.ListPrice; // ���i���i
                                        mf2.PriceStartDate = mf.PriceStartDate; // ���i���i�J�n��
                                        mf2.OpenPriceDiv = mf.OpenPriceDiv; // �I�[�v�����i�敪
                                    }
                                    if ( (mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo) && (mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo) )
                                    {
                                        if ( mf.ModelPrtsAdptFrameNo < mf2.ModelPrtsAdptFrameNo )
                                            mf2.ModelPrtsAdptFrameNo = mf.ModelPrtsAdptFrameNo;
                                        if ( mf.ModelPrtsAblsFrameNo > mf2.ModelPrtsAblsFrameNo )
                                            mf2.ModelPrtsAblsFrameNo = mf.ModelPrtsAblsFrameNo;
                                    }
                                    existsFlag = 1;

                                    break;
                                }
                            }
                        }
                    }
                    //�d�����Ă��Ȃ����alwk��Insert
                    if ( existsFlag == 0 )
                    {
                        alwk.Add( mf );
                    }
                }
            }
            //���k�ς�ArrayList��߂�
            retInf = alwk;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
