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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǂa�k�R�[�h����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�ǂa�k�R�[�h�����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: ��ւ̌������C��</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/10/19</br>
    /// <br></br>
    /// <br>Update Note: �������i���̃}�X�^�̑S���[�J�[�p�̑Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/10/22</br>
    /// </remarks>
    [Serializable]
    public class OfferPrimeBlSearchDB : RemoteDB, IOfferPrimeBlSearchDB
    {
        #region << Private ��` >>
        private string PrimeSearchSelect =
            //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
            "SELECT DISTINCT "

            // �񋟗D�ǌ����}�X�^����
            + "ORGPARTSNORF.PRMSETDTLNO2RF" // PRIMEKINDCODERF�@��ʃR�[�h
            // 2009/10/19 >>>
            //+ ",ORGPARTSNORF.PRIMEPARTSNORF"
            + ",ORGPARTSNORF.PRIMEOLDPARTSNORF as PRIMEPARTSNORF"
            // 2009/10/19 <<<
            + ",ORGPARTSNORF.PRMPARTSPROPERNORF"
            + ",ORGPARTSNORF.PARTSDISPORDERRF"
            + ",ORGPARTSNORF.SETPARTSFLGRF"
            + ",ORGPARTSNORF.PRIMEQTYRF"
            + ",ORGPARTSNORF.PRIMESPECIALNOTERF"
            + ",ORGPARTSNORF.STPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.EDPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.STPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.EDPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.OFFERDATERF"
            + ",ORGPARTSNORF.MODELGRADENMRF"
            + ",ORGPARTSNORF.BODYNAMERF"
            + ",ORGPARTSNORF.DOORCOUNTRF"
            + ",ORGPARTSNORF.ENGINEMODELNMRF"
            + ",ORGPARTSNORF.ENGINEDISPLACENMRF"
            + ",ORGPARTSNORF.EDIVNMRF"
            + ",ORGPARTSNORF.TRANSMISSIONNMRF"
            + ",ORGPARTSNORF.SHIFTNMRF"
            + ",ORGPARTSNORF.WHEELDRIVEMETHODNMRF"

            // �񋟗D�Ǖ��i�}�X�^����
            + ",PRIMEPARTSRF.GOODSMGROUPRF"
            + ",PRIMEPARTSRF.TBSPARTSCODERF"
            + ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF"
            + ",PRIMEPARTSRF.PRMSETDTLNO1RF" // �Z���N�g�R�[�h
            + ",PRIMEPARTSRF.PARTSMAKERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNOWITHHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNONONEHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
            + ",PRIMEPARTSRF.PRIMEPARTSKANANMRF"
            + ",PRIMEPARTSRF.PARTSLAYERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
            + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
            + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF"
            + ",PRIMEPARTSRF.PRMPARTSILLUSTCRF "

            + ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF "
            + ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF "
            + ",SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD" // 2009/10/22 Add

            //�i�n�h�m����
            + " FROM PRIMEPARTSRF INNER JOIN ORGPARTSNORF ON PRIMEPARTSRF.GOODSMGROUPRF = ORGPARTSNORF.GOODSMGROUPRF "
            + " AND PRIMEPARTSRF.TBSPARTSCODERF = ORGPARTSNORF.TBSPARTSCODERF "
            + " AND PRIMEPARTSRF.PRMSETDTLNO1RF = ORGPARTSNORF.PRMSETDTLNO1RF "
            + " AND PRIMEPARTSRF.PARTSMAKERCDRF = ORGPARTSNORF.PARTSMAKERCDRF "
            // 2009/10/19 >>>
            //+ " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = ORGPARTSNORF.PRIMEOLDPARTSNORF "// PRIMEOLDPARTSNORF�����C��
            + " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = ORGPARTSNORF.PRIMEPARTSNORF "// PRIMEOLDPARTSNORF�����C��
            // 2009/10/19 <<<
            + " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
        // JOIN���������Ŋ����łȂ��̂Ō�Ń����e����ے��ӂ��Ă��������B������g���̂�1���������ł��B

        private string PrimeSearchSubstSelect =
            //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
            "SELECT DISTINCT "
            // �񋟗D�ǌ����}�X�^����
            + "ORGPARTSNORF.PRMSETDTLNO2RF" // PRIMEKINDCODERF�@��ʃR�[�h
            + ",ORGPARTSNORF.PRIMEPARTSNORF"
            //+ ",ORGPARTSNORF.PRMPARTSPROPERNORF"
            + ",ORGPARTSNORF.PARTSDISPORDERRF"
            + ",ORGPARTSNORF.SETPARTSFLGRF"
            + ",ORGPARTSNORF.PRIMEQTYRF"
            + ",ORGPARTSNORF.PRIMESPECIALNOTERF"
            + ",ORGPARTSNORF.STPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.EDPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.STPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.EDPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.OFFERDATERF"

            // �񋟗D�Ǖ��i�}�X�^����
            + ",PRIMEPARTSRF.GOODSMGROUPRF"
            + ",PRIMEPARTSRF.TBSPARTSCODERF"
            + ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF"
            + ",PRIMEPARTSRF.PRMSETDTLNO1RF" // �Z���N�g�R�[�h
            + ",PRIMEPARTSRF.PARTSMAKERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNOWITHHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNONONEHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
            + ",PRIMEPARTSRF.PRIMEPARTSKANANMRF"
            + ",PRIMEPARTSRF.PARTSLAYERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
            + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
            + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF"
            + ",PRIMEPARTSRF.PRMPARTSILLUSTCRF "

            + ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF "
            + ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF "
            + ",SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD" // 2009/10/22 Add

            //�i�n�h�m����
            + " FROM PRIMEPARTSRF INNER JOIN ORGPARTSNORF ON PRIMEPARTSRF.GOODSMGROUPRF = ORGPARTSNORF.GOODSMGROUPRF "
            + " AND PRIMEPARTSRF.TBSPARTSCODERF = ORGPARTSNORF.TBSPARTSCODERF "
            + " AND PRIMEPARTSRF.PRMSETDTLNO1RF = ORGPARTSNORF.PRMSETDTLNO1RF "
            + " AND PRIMEPARTSRF.PARTSMAKERCDRF = ORGPARTSNORF.PARTSMAKERCDRF "
            + " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = ORGPARTSNORF.PRIMEOLDPARTSNORF "// PRIMEOLDPARTSNORF�����C��
            + " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
        // JOIN���������Ŋ����łȂ��̂Ō�Ń����e����ے��ӂ��Ă��������B������g���̂�1���������ł��B
        #endregion

        #region << �R���X�g���N�^�[ >>
        /// <summary>
        ///�@�D�ǂa�k�R�[�h����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        public OfferPrimeBlSearchDB()
            :
            base("PMTKD06034D", "Broadleaf.Application.Remoting.OfferPrimeBlSearchDB", "PRIMEPARTSRF")
        {
        }
        #endregion

        #region << Public�@���\�b�h >>
        /// <summary>
        /// �D�ǂa�k�R�[�h����DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <param name="offerPrimeBlSearchCondWork"></param>
        /// <param name="offerPrimeSearchRetWork"></param>
        /// <param name="offerPrimePriceRetWork"></param>
        /// <param name="offerSetPartsRetWork"></param>
        /// <param name="offerSetPartPrice"></param>
        /// <returns></returns>
        public int Search(OfferPrimeBlSearchCondWork offerPrimeBlSearchCondWork, out ArrayList offerPrimeSearchRetWork,
            out ArrayList offerPrimePriceRetWork, out ArrayList offerSetPartsRetWork, out ArrayList offerSetPartPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            offerPrimeSearchRetWork = new ArrayList();
            offerPrimePriceRetWork = new ArrayList();
            offerSetPartsRetWork = new ArrayList();
            offerSetPartPrice = new ArrayList();
            //���o�̓p�����[�^�[�ݒ�
            SqlConnection sqlConnection = null;
            try
            {
                ArrayList _offerOldPrimeSearchRetWork = new ArrayList();

                //�r�p�k��������
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�D�ǂa�k�R�[�h����
                status = OfferPrimeBlSearch(offerPrimeBlSearchCondWork, ref offerPrimeSearchRetWork, sqlConnection);
                if (status != 0)
                {
                    return status;
                }

                //�D�ǂa�k�R�[�h��������֌����p��
                status = OfferPrimeBlSubstSearch(offerPrimeBlSearchCondWork.MakerCode, offerPrimeSearchRetWork, 
                    ref _offerOldPrimeSearchRetWork, sqlConnection);
                if (status != 0 && status != 4)
                {
                    return status;
                }
                offerPrimeSearchRetWork.AddRange(_offerOldPrimeSearchRetWork);

                status = GetOriginalPartsPrice(offerPrimeSearchRetWork, out offerPrimePriceRetWork, sqlConnection);

                //�Z�b�g�}�X�^����
                status = SearchSetParts(offerPrimeBlSearchCondWork.MakerCode, offerPrimeSearchRetWork, out offerSetPartsRetWork, sqlConnection);

                status = SearchSetPartsPrice(offerSetPartsRetWork, out offerSetPartPrice, sqlConnection);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return status;
        }

        // �s�v
        ///// <summary>
        ///// �D�ǂa�k�R�[�h����DB�����[�g�I�u�W�F�N�g
        ///// </summary>
        ///// <param name="searchSetPartsCondWork"></param>
        ///// <param name="offerSetPartsRetWork"></param>
        ///// <returns></returns>
        //public int Search(ArrayList searchSetPartsCondWork, out ArrayList offerSetPartsRetWork)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlConnection sqlConnection = null;

        //    //���o�̓p�����[�^�[�ݒ�
        //    offerSetPartsRetWork = null;
        //    try
        //    {
        //        ArrayList _offerSetPartsRetWork = new ArrayList();

        //        //�r�p�k��������
        //        SqlConnectionInfo sqlConnectioninfo = sqlConnectioninfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
        //        if (string.IsNullOrEmpty(connectionText))
        //        {
        //            return 99;
        //        }
        //        sqlConnection = new SqlConnection(connectionText);
        //        sqlConnection.Open();

        //        //�Z�b�g�}�X�^����
        //        status = SearchSetParts(searchSetPartsCondWork, out _offerSetPartsRetWork, sqlConnection);
        //        if (status == 0)
        //        {
        //            offerSetPartsRetWork = _offerSetPartsRetWork;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.Search Exception = " + ex.Message);
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //    return status;
        //}

        #endregion

        #region << Private ���\�b�h >>
        /// <summary>
        /// �D�ǂa�k�R�[�h���������i�a�k�R�[�h�E�������̎w��j
        /// </summary>
        /// <param name="searchCond"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int OfferPrimeBlSearch(OfferPrimeBlSearchCondWork searchCond, ref ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr;
            SqlDataReader myReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(); //selectstr, sqlConnection);
                selectstr = PrimeSearchSelect;

                // 2009/10/22 >>>
                //selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", searchCond.MakerCode);
                selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF IN ({0},0)) ", searchCond.MakerCode);
                // 2009/10/22 <<<
                //�v�g�d�q�d����
                selectstr += "WHERE ORGPARTSNORF.TBSPARTSCODERF = @TBSPARTSCODE ";
                selectstr += " AND  ORGPARTSNORF.MAKERCODERF = @MAKERCODE";
                selectstr += " AND  ORGPARTSNORF.MODELCODERF = @MODELCODE";
                selectstr += " AND  ORGPARTSNORF.MODELSUBCODERF = @MODELSUBCODE";
                selectstr += " AND  ORGPARTSNORF.SERIESMODELRF = @SERIESMODEL";
                // Prameter�I�u�W�F�N�g�̍쐬
                ((SqlParameter)sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.TbsPartsCode);	//�a�k�R�[�h
                ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.MakerCode);	//�ԃ��[�J�[�R�[�h
                ((SqlParameter)sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.ModelCode);	//�Ԏ�R�[�h
                ((SqlParameter)sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.ModelSubCode);	//�Ԏ�T�u�R�[�h
                ((SqlParameter)sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.VarChar)).Value =
                    SqlDataMediator.SqlSetString(searchCond.SeriesModel);	//�V���[�Y�^��

                MakeWhereString(searchCond, ref selectstr);

                sqlCommand.CommandText = selectstr;
                sqlCommand.Connection = sqlConnection;

                myReader = sqlCommand.ExecuteReader();
                SetOfferPrimeSearchRetWork(myReader, retWork, 0);
                CompressPartsRec(ref retWork);
                if (retWork.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.OfferPrimeBlSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �i�������쐬
        /// </summary>
        /// <param name="searchCond"></param>
        /// <param name="selectstr"></param>
        private void MakeWhereString(OfferPrimeBlSearchCondWork searchCond, ref string selectstr)
        {
            if (searchCond.CategorySignModel.Count > 0)	    //�^���i�ޕʋL���j
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.CategorySignModel.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.CATEGORYSIGNMODELRF = '" + searchCond.CategorySignModel[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.CATEGORYSIGNMODELRF = '' )";
            }

            if (searchCond.ProduceTypeOfYear != 0)  // ���Y�N�� - ���[�U�[���͂̎ԗ��̐��Y�N��������ꍇ
            {
                selectstr += " AND ( ORGPARTSNORF.STPRODUCETYPEOFYEARRF <= " + searchCond.ProduceTypeOfYear.ToString();
                selectstr += " AND ORGPARTSNORF.EDPRODUCETYPEOFYEARRF >= " + searchCond.ProduceTypeOfYear.ToString() + " ) ";
            }
            else // ���[�U�[���͂��Ȃ��ꍇ�A�Ԃ̊J�n���Y�N���E�I�����Y�N���ōi��
            {
                if (searchCond.StProduceTypeOfYear.Count > 0)	    //�J�n���Y�N��
                {
                    selectstr += " AND (";
                    for (int i = 0; i < searchCond.StProduceTypeOfYear.Count; i++)
                    {
                        selectstr += string.Format("((ORGPARTSNORF.STPRODUCETYPEOFYEARRF = 0 OR ORGPARTSNORF.STPRODUCETYPEOFYEARRF >= {0})"
                                , searchCond.StProduceTypeOfYear[i]);
                        selectstr += string.Format(" AND (ORGPARTSNORF.EDPRODUCETYPEOFYEARRF = 999999 OR ORGPARTSNORF.EDPRODUCETYPEOFYEARRF <= {0})) OR "
                                , searchCond.EdProduceTypeOfYear[i]);
                    }
                    selectstr = selectstr.Remove(selectstr.Length - 3) + ") ";
                }
            }

            if (searchCond.ProduceTypeOfYear != 0)  // ���Y�ԑ�ԍ� - ���[�U�[���͂̎ԗ��̐��Y�ԑ�ԍ�������ꍇ
            {
                selectstr += " AND ( ORGPARTSNORF.STPRODUCETYPEOFYEARRF <= " + searchCond.ProduceTypeOfYear.ToString();
                selectstr += " AND ORGPARTSNORF.EDPRODUCETYPEOFYEARRF >= " + searchCond.ProduceTypeOfYear.ToString() + " ) ";
            }
            else // ���[�U�[���͂��Ȃ��ꍇ�A�Ԃ̊J�n���Y�ԑ�ԍ��E�I�����Y�ԑ�ԍ��ōi��
            {
                if (searchCond.StProduceFrameNo.Count > 0)	    //���Y�ԑ�ԍ��J�n
                {
                    selectstr += " AND (";
                    for (int i = 0; i < searchCond.StProduceFrameNo.Count; i++)
                    {
                        selectstr += string.Format("((ORGPARTSNORF.STPRODUCEFRAMENORF = 0 OR ORGPARTSNORF.STPRODUCEFRAMENORF >= {0})"
                                , searchCond.StProduceFrameNo[i]);
                        selectstr += string.Format(" AND (ORGPARTSNORF.EDPRODUCEFRAMENORF = 99999999 OR ORGPARTSNORF.EDPRODUCEFRAMENORF <= {0})) OR "
                                , searchCond.EdProduceFrameNo[i]);

                        selectstr += " ORGPARTSNORF.STPRODUCEFRAMENORF >= " + searchCond.StProduceFrameNo[i].ToString() + " OR ";
                    }
                    selectstr = selectstr.Remove(selectstr.Length - 3) + ") ";
                }
            }

            if (searchCond.ModelGradeNm.Count > 0)	    //�^���O���[�h����
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.ModelGradeNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.MODELGRADENMRF = '" + searchCond.ModelGradeNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.MODELGRADENMRF = '' )";
            }

            if (searchCond.BodyName.Count > 0)	    //�{�f�B�[����
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.BodyName.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.BODYNAMERF = '" + searchCond.BodyName[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.BODYNAMERF = '' )";
            }

            if (searchCond.DoorCount.Count > 0)	//�h�A��
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.DoorCount.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.DOORCOUNTRF = " + searchCond.DoorCount[i].ToString() + " OR ";
                }
                selectstr += "ORGPARTSNORF.DOORCOUNTRF = 0 )";
            }

            if (searchCond.EngineModelNm.Count > 0)	//�G���W���^������
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.EngineModelNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.ENGINEMODELNMRF = '" + searchCond.EngineModelNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.ENGINEMODELNMRF = '' )";
            }

            if (searchCond.EngineDisplaceNm.Count > 0)	//�r�C�ʖ���
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.EngineDisplaceNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.ENGINEDISPLACENMRF = '" + searchCond.EngineDisplaceNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.ENGINEMODELNMRF = '' )";
            }

            if (searchCond.EDivNm.Count > 0)	//E�敪����
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.EDivNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.EDIVNMRF = '" + searchCond.EDivNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.ENGINEMODELNMRF = '' )";
            }

            if (searchCond.TransmissionNm.Count > 0)	//�~�b�V��������
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.TransmissionNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.TRANSMISSIONNMRF = '" + searchCond.TransmissionNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.TRANSMISSIONNMRF = '' )";
            }

            if (searchCond.ShiftNm.Count > 0)	//�V�t�g����
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.ShiftNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.SHIFTNMRF = '" + searchCond.ShiftNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.SHIFTNMRF = '' )";
            }

            if (searchCond.WheelDriveMethodNm.Count > 0)	//�쓮��������
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.WheelDriveMethodNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.WHEELDRIVEMETHODNMRF = '" + searchCond.WheelDriveMethodNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.WHEELDRIVEMETHODNMRF = '' )";
            }
        }

        /// <summary>
        /// �D�ǂa�k�R�[�h���D�Ǒ�֕i�Ԑ�p�������i�a�k�R�[�h�j
        /// </summary>
        /// <param name="carMakerCd">�ԃ��[�J�[�R�[�h�i�����i�������p�j</param>
        /// <param name="lstSubstSrc">��֌����������X�g</param>
        /// <param name="retWork">���ʃ��X�g</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int OfferPrimeBlSubstSearch(int carMakerCd, ArrayList lstSubstSrc, ref ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = PrimeSearchSubstSelect;
            string wherestr;
            SqlDataReader myReader = null;
            //ArrayList listWork = new ArrayList();
            //listWork.AddRange(lstSubstSrc);
            List<SubstChkKey> lst = new List<SubstChkKey>();

            try
            {
                // 2009/10/22 >>>
                //selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF IN ({0},0)) ", carMakerCd);
                // 2009/10/22 <<<
                foreach (OfferPrimeSearchRetWork ofrPrime in lstSubstSrc)
                {
                    // 2009/10/19 >>>
                    //if (ofrPrime.PrimePartsNo.Equals(string.Empty)) // �V���i���Ȃ��Ə������Ȃ��B
                    //    continue;
                    if (ofrPrime.PrimePartsNoWithH.Equals(string.Empty)) // �V���i���Ȃ��Ə������Ȃ��B
                        continue;
                    // 2009/10/19 <<<
                    SubstChkKey key = new SubstChkKey(ofrPrime.GoodsMGroup, ofrPrime.PartsMakerCd, ofrPrime.PrimePartsNoWithH);
                    if (lst.Contains(key))
                        continue;
                    lst.Add(key);

                    ArrayList tmpWork = new ArrayList();
                    wherestr = " WHERE PRIMEPARTSRF.PARTSMAKERCDRF = @PARTSMAKERCD";
                    wherestr += " AND PRIMEPARTSRF.TBSPARTSCODERF = @TBSPARTSCODE";
                    wherestr += " AND PRIMEPARTSRF.GOODSMGROUPRF = @GOODSMGROUP";
                    // 2009/10/19 >>>
                    //wherestr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = @PRIMEPARTSNOWITHH";
                    wherestr += " AND ORGPARTSNORF.PRIMEPARTSNORF = @PRIMEPARTSNOWITHH";
                    // 2009/10/19 <<<

                    SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    ((SqlParameter)sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int)).Value =
                        SqlDataMediator.SqlSetInt(ofrPrime.PartsMakerCd);	//���i���[�J�[�R�[�h
                    ((SqlParameter)sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int)).Value =
                        SqlDataMediator.SqlSetInt(ofrPrime.TbsPartsCode);	//BL�R�[�h
                    ((SqlParameter)sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int)).Value =
                        SqlDataMediator.SqlSetInt(ofrPrime.GoodsMGroup);	//���i�����ރR�[�h
                    // 2009/10/19 >>>
                    //((SqlParameter)sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH", SqlDbType.VarChar)).Value =
                    //    SqlDataMediator.SqlSetString(ofrPrime.PrimePartsNo);	//�D�ǐV�i��

                    ( (SqlParameter)sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH", SqlDbType.VarChar) ).Value =
                        SqlDataMediator.SqlSetString(ofrPrime.PrimePartsNoWithH);	//�D�ǐV�i��
                    // 2009/10/19 <<<

                    myReader = sqlCommand.ExecuteReader();
                    SetOfferPrimeSearchRetWork(myReader, tmpWork, 1);
                    CompressPartsRec(ref tmpWork);
                    if (tmpWork.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retWork.AddRange(tmpWork);
                    }
                    myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.OfferPrimeBlOldSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        private int GetOriginalPartsPrice(ArrayList inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr;
            SqlDataReader myReader = null;
            retWork = new ArrayList();

            selectstr = "SELECT DISTINCT ";
            selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
            selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
            selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
            selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
            selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
            selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
            selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";
            selectstr += " FROM PRMPRTPRICERF ";
            selectstr += "WHERE PRMPRTPRICERF.PRMSETDTLNO1RF = @PRMSETDTLNO1 ";
            selectstr += "AND  PRMPRTPRICERF.PARTSMAKERCDRF = @PARTSMAKERCD ";
            selectstr += "AND  PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = @PRIMEPARTSNOWITHH ";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                SqlParameter paraPrimePartsNo = sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH", SqlDbType.NVarChar);

                foreach (OfferPrimeSearchRetWork ofrPrime in inPara)
                {
                    paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt(ofrPrime.PrmSetDtlNo1);
                    paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt(ofrPrime.PartsMakerCd);
                    paraPrimePartsNo.Value = SqlDataMediator.SqlSetString(ofrPrime.PrimePartsNoWithH);
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        OfferJoinPriceRetWork priceWork = new OfferJoinPriceRetWork();

                        priceWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                        priceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                        priceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                        priceWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                        priceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                        priceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                        retWork.Add(priceWork);
                    }
                    myReader.Close();
                }
                status = 0;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.GetOriginalPartsPrice Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// �Z�b�g�}�X�^����
        /// </summary>
        /// <param name="carMakerCd">�ԃ��[�J�[�R�[�h�i�����i�������p�j</param>
        /// <param name="inWork">�Z�b�g�����������X�g</param>
        /// <param name="retWork">���ʃ��X�g</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSetParts(int carMakerCode, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //���ʂ̏�����
            retWork = new ArrayList();

            try
            {
                selectstr = "SELECT "
                    //�Z�b�g�}�X�^
                    + "SETPARTSRF.OFFERDATERF"
                    + ",SETPARTSRF.GOODSMGROUPRF"
                    + ",SETPARTSRF.TBSPARTSCODERF"
                    + ",SETPARTSRF.TBSPARTSCDDERIVEDNORF"
                    + ",SETPARTSRF.SETMAINMAKERCDRF"
                    + ",SETPARTSRF.SETMAINPARTSNORF"
                    + ",SETPARTSRF.SETSUBMAKERCDRF"
                    + ",SETPARTSRF.SETSUBPARTSNORF"
                    + ",SETPARTSRF.SETDISPORDERRF"
                    + ",SETPARTSRF.SETQTYRF"
                    + ",SETPARTSRF.SETNAMERF"
                    + ",SETPARTSRF.SETSPECIALNOTERF"
                    + ",SETPARTSRF.CATALOGSHAPENORF"

                    //�D�Ǖ��i�}�X�^
                    + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
                    + ",PRIMEPARTSRF.PARTSLAYERCDRF"
                    + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
                    + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
                    + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF "

                    + ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF "
                    + ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF "

                    //�i�n�h�m����
                    + " FROM PRIMEPARTSRF INNER JOIN SETPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = SETPARTSRF.SETSUBMAKERCDRF"
                    + " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = SETPARTSRF.SETSUBPARTSNORF "
                    + " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF "
                    + string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCode)
                    + "WHERE ";

                //�����惁�[�J�[�R�[�h�E������i�� 
                foreach (OfferPrimeSearchRetWork wk in inWork)
                {
                    //�Z�b�g�i�ԃt���O���P�̏ꍇ�̂ݑΏ�
                    if (wk.SetPartsFlg == 1)
                    {
                        wherestr += "OR ( SETPARTSRF.SETMAINMAKERCDRF = " + wk.PartsMakerCd + " AND ";
                        wherestr += "SETPARTSRF.SETMAINPARTSNORF = '" + wk.PrimePartsNoWithH + "' ) ";
                    }
                }
                if (wherestr.Length == 0)
                {
                    return (0);
                }
                wherestr = wherestr.Substring(2); // �擪��OR����
                wherestr += "ORDER BY SETDISPORDERRF ASC";
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferSetPartsRetWork mf = new OfferSetPartsRetWork();
                    //�Z�b�g�}�X�^
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETMAINMAKERCDRF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETMAINPARTSNORF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETSUBMAKERCDRF"));
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSUBPARTSNORF"));
                    mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETDISPORDERRF"));
                    mf.SetQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SETQTYRF"));
                    mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF"));
                    mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));

                    //�D�Ǖ��i�}�X�^
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    retWork.Add(mf);

                }
                if (retWork.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.SearchSetParts Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// ���i�擾
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSetPartsPrice(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            retWork = new ArrayList();

            if (inWork == null)
            {
                return status;
            }
            else if (inWork.Count == 0)
            {
                return 0;
            }

            try
            {
                //[�P���ɏ����i�ɕR�t���D�Ǖi�𒊏o]
                selectstr = "SELECT ";
                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // �Z���N�g�R�[�h
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += " FROM PRMPRTPRICERF ";

                selectstr += " WHERE ";

                foreach (OfferSetPartsRetWork wk in inWork)
                {
                    //���[�J�[�R�[�h
                    wherestr += " OR ( ";
                    wherestr += " PRMPRTPRICERF.PARTSMAKERCDRF = " + wk.SetSubMakerCd;
                    wherestr += " AND PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = '" + wk.SetSubPartsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // �擪��OR����
                wherestr += "ORDER BY PRICESTARTDATERF DESC";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

                    //�������
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    mf.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mf.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearch.SearchSetPrimePartsNo�ɂăG���[���� Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;

        }

        /// <summary>
        /// DataReader���烊�X�g�쐬����
        /// </summary>
        /// <param name="myReader">myReader</param>
        /// <param name="retInf">���ʃ��X�g</param>
        /// <param name="mode">0:��ʐݒ�@1:��֐ݒ�</param>
        private void SetOfferPrimeSearchRetWork(SqlDataReader myReader, ArrayList retInf, int mode)
        {
            OfferPrimeSearchRetWork primeSearchRetWork;
            while (myReader.Read())
            {
                primeSearchRetWork = new OfferPrimeSearchRetWork();

                //�񋟗D�ǌ����}�X�^����
                primeSearchRetWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                primeSearchRetWork.PrimePartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNORF"));

                primeSearchRetWork.PartsDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDISPORDERRF"));
                primeSearchRetWork.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                primeSearchRetWork.PrimeQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRIMEQTYRF"));
                primeSearchRetWork.PrimeSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMESPECIALNOTERF"));
                primeSearchRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));
                primeSearchRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));
                primeSearchRetWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                primeSearchRetWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                primeSearchRetWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                primeSearchRetWork.SubstFlag = mode; // 1:��֕i
                primeSearchRetWork.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                primeSearchRetWork.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                if (mode == 0) // �ȉ��̏����͑�֕i�Ɋւ��Ă͏������Ȃ��B
                {
                    primeSearchRetWork.PrmPartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRMPARTSPROPERNORF"));

                    primeSearchRetWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                    primeSearchRetWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                    primeSearchRetWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                    primeSearchRetWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    primeSearchRetWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                    primeSearchRetWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                    primeSearchRetWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                    primeSearchRetWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                }
                primeSearchRetWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                primeSearchRetWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                primeSearchRetWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                primeSearchRetWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                primeSearchRetWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                primeSearchRetWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                primeSearchRetWork.PrimePartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                primeSearchRetWork.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                primeSearchRetWork.PrimePartsKanaNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                primeSearchRetWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                primeSearchRetWork.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                primeSearchRetWork.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                primeSearchRetWork.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                primeSearchRetWork.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));
                primeSearchRetWork.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));  // 2009/10/22 Add

                retInf.Add(primeSearchRetWork);
            }
        }

        /// <summary>
        /// ���ꕔ�i���k����
        /// </summary>
        /// <param name="retInf">���o���ʕ��i���R�[�h</param>
        private void CompressPartsRec(ref ArrayList retInf)
        {
            ArrayList alwk = new ArrayList();
            int ariflg = 0;

            foreach (OfferPrimeSearchRetWork mf in retInf)
            {
                if (mf != null)
                {
                    ariflg = 0;
                    foreach (OfferPrimeSearchRetWork mf2 in alwk)
                    {
                        if (mf2 != null)
                        {
                            if ((mf.PrimePartsNoWithH == mf2.PrimePartsNoWithH) && (mf.PartsMakerCd == mf2.PartsMakerCd)
                                && (mf.PrimeSpecialNote == mf2.PrimeSpecialNote)
                                && (mf.ModelGradeNm == mf2.ModelGradeNm) && (mf.DoorCount == mf2.DoorCount) && (mf.BodyName == mf2.BodyName)
                                && (mf.EDivNm == mf2.EDivNm) && (mf.ShiftNm == mf2.ShiftNm) && (mf.TransmissionNm == mf2.TransmissionNm)
                                && (mf.WheelDriveMethodNm == mf2.WheelDriveMethodNm))
                            {
                                if (((mf.StProduceTypeOfYear == mf2.StProduceTypeOfYear) && (mf.EdProduceTypeOfYear == mf2.EdProduceTypeOfYear)) ||
                                    ((mf.StProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.StProduceTypeOfYear <= mf2.EdProduceTypeOfYear)) ||
                                    ((mf.EdProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.EdProduceTypeOfYear <= mf2.EdProduceTypeOfYear)))
                                {
                                    if ((mf.StProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.StProduceTypeOfYear <= mf2.EdProduceTypeOfYear))
                                    {
                                        if (mf.EdProduceTypeOfYear > mf2.EdProduceTypeOfYear)
                                            mf2.EdProduceTypeOfYear = mf.EdProduceTypeOfYear;
                                    }
                                    if ((mf.EdProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.EdProduceTypeOfYear <= mf2.EdProduceTypeOfYear))
                                    {
                                        if (mf.StProduceTypeOfYear < mf2.StProduceTypeOfYear)
                                            mf2.StProduceTypeOfYear = mf.StProduceTypeOfYear;
                                    }
                                    // 2009/10/22 Add >>>
                                    if (mf2.SrchPNmAcqrCarMkrCd == 0 && mf2.SrchPNmAcqrCarMkrCd != mf.SrchPNmAcqrCarMkrCd)
                                    {
                                        mf2.SrchPNmAcqrCarMkrCd = mf.SrchPNmAcqrCarMkrCd;
                                        mf2.SearchPartsFullName = mf.SearchPartsFullName;
                                        mf2.SearchPartsHalfName = mf.SearchPartsHalfName;
                                    }
                                    // 2009/10/22 Add <<<
                                    ariflg = 1;

                                    break;
                                }
                            }
                        }
                    }
                    //�d�����Ă��Ȃ����alwk��Insert
                    if (ariflg == 0)
                    {
                        alwk.Add(mf);
                    }
                }
            }
            //���k�ς�ArrayList��߂�
            retInf = alwk;
        }

        ///// <summary>
        ///// �ޕʑ������i�}�X�^���[�h
        ///// </summary>
        ///// <param name="ModelDesignationNo"></param>
        ///// <param name="CategoryNo"></param>
        ///// <param name="TbsPartsCode"></param>
        ///// <param name="RetInf"></param>
        ///// <returns></returns>
        //private int ReadCtgEquip(int ModelDesignationNo, int CategoryNo, int TbsPartsCode, string divname, int divcd, string partsname, ref ArrayList RetInf, ref SqlConnection sqlConnection)
        //{

        //    //SqlConnection sqlConnection		= null;
        //    SqlDataReader myReader = null;
        //    //���ʂ̏�����
        //    //SqlEncryptInfo sqlEncriptInfo = null;

        //    int status = 0;
        //    string selectstr = "";
        //    string fromstr = "";
        //    string wherestr = "";
        //    string orderstr = "";

        //    // Prameter�I�u�W�F�N�g�̍쐬
        //    SqlParameter findfull = null;	//�^��
        //    SqlParameter findparts = null; //�ޕ�
        //    SqlParameter findpartsdiv = null;	//�����i�R�[�h

        //    RetPartsInf ptwk = null;
        //    try
        //    {
        //        //���Í������i��������
        //        //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "CTGEQUIPPTRF" });
        //        //�Í����L�[OPEN�iSQLException�̉\���L��j
        //        //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

        //        //,Cast(  DecryptByKey(CLGPNOINFORF.TBSPARTSCDDERIVEDNMRF) AS NVARCHAR(15) ) AS TBSPARTSCDDERIVEDNMRF				

        //        //selectstr = "SELECT EQUIPMENTNAMERF,EQUIPMENTCNTRF ";
        //        selectstr = "SELECT CTGEQUIPPTRF.EQUIPMENTNAMERF,EQUIPMENTCNTRF ";
        //        fromstr = "FROM CTGEQUIPPTRF ";

        //        wherestr = " WHERE MODELDESIGNATIONNORF=@MODELDESIGNATIONNORF AND TBSPARTSCODERF=@TBSPARTSCODERF AND CATEGORYNORF=@CATEGORYNORF ";

        //        orderstr = " ORDER BY EQUIPMENTDISPORDERRF";

        //        SqlCommand sqlCommand = new SqlCommand(selectstr + fromstr + wherestr + orderstr, sqlConnection);

        //        // Prameter�I�u�W�F�N�g�̍쐬
        //        findfull = sqlCommand.Parameters.Add("@MODELDESIGNATIONNORF", SqlDbType.Int);
        //        findparts = sqlCommand.Parameters.Add("@TBSPARTSCODERF", SqlDbType.Int);
        //        findpartsdiv = sqlCommand.Parameters.Add("@CATEGORYNORF", SqlDbType.Int);

        //        // Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findfull.Value = SqlDataMediator.SqlSetInt32(ModelDesignationNo);
        //        findparts.Value = SqlDataMediator.SqlSetInt32(TbsPartsCode);
        //        findpartsdiv.Value = SqlDataMediator.SqlSetInt32(CategoryNo);

        //        myReader = sqlCommand.ExecuteReader();

        //        int ariflg = 0;
        //        while (myReader.Read())
        //        {
        //            ariflg = 1;
        //            ptwk = new RetPartsInf();

        //            ptwk.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("EQUIPMENTCNTRF"));
        //            //ptwk.PartsQtyForRp = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("EQUIPMENTCNTRF"));
        //            ptwk.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTNAMERF"));
        //            ptwk.PartsSearchCode = 2;
        //            ptwk.PartsName = partsname;
        //            ptwk.TbsPartsCode = TbsPartsCode;
        //            ptwk.WorkOrPartsDivNm = divname;
        //            ptwk.PartsCode = divcd;
        //            //ptwk.TotalDivCd = totaldivcdrf;

        //            RetInf.Add(ptwk);
        //        }
        //        if (ariflg == 0)
        //            status = 4;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (myReader != null && !myReader.IsClosed)
        //            myReader.Close();
        //    }

        //    //�Í����L�[�N���[�Y
        //    //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

        //    //sqlConnection.Close();
        //    //sqlConnection.Dispose();

        //    return status;
        //}

        #endregion
    }

}
