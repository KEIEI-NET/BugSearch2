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
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�\���擾�i�񋟁jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�\���擾�i�񋟁j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.06</br>
    /// <br></br>
    /// <br>Update Note: 2007.08.29 ���� DC.NS�p�ɏC��</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.13 20081 �D�c �E�l PM.NS�p�ɏC��</br>
    /// </remarks>
    [Serializable]
    public class GoodsRelationDataDB : RemoteDB, IGoodsRelationDataDB
    {
        /// <summary>
        /// ���i�\���擾�i�񋟁jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        public GoodsRelationDataDB()
            :
            base("MACMN00136D", "Broadleaf.Application.Remoting.ParamData.GoodsRelationDataWork", "GOODSRELATIONDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾�i�񋟁j���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsRelationDataWork">��������</param>
        /// <param name="paragoodsRelationDataWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾�i�񋟁j���LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        public int Search(ref object goodsRelationDataWork, object paragoodsRelationDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(ref goodsRelationDataWork, paragoodsRelationDataWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsRelationDataDB.Search");
                goodsRelationDataWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏��i�\���擾�i�񋟁j���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾�i�񋟁j���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.29 ���� DC.NS�p�ɏC��</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            GoodsCndtnWork goodsrelationdataWork = null;

            //�����N���X�̃L���X�g
            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList == null)
            {
                goodsrelationdataWork = paraObj as GoodsCndtnWork;
            }
            else
            {
                if (goodsrelationdataWorkList.Count > 0)
                    goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsCndtnWork;
            }
            
            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            if (paraList != null)
            {
                for (int i = 0; i < paraList.Count; i++)
                {
                    Type wktype = paraList[i].GetType();

                    //���i�A��
                    //if (wktype.Equals(typeof(GoodsUnitDataWork)))
                    //{
                    //    ArrayList retal = null;
                    //    status = SearchGoodsRelationDataProc(out retal, goodsrelationdataWork, readMode, logicalMode, ref sqlConnection);
                    //    retCSAList.Add(retal);
                    //}

                    //���[�J�[
                    if (wktype.Equals(typeof(PMakerNmWork)))
                    {
                        PMakerNmDB pMakerNmDB = new PMakerNmDB();
                        ArrayList retal = null;
                        status = pMakerNmDB.Search(out retal, readMode, sqlConnection, sqlTransaction);
                        retCSAList.Add(retal);
                    }

                    //���i�����ރR�[�h
                    if (wktype.Equals(typeof(GoodsMGroupWork)))
                    {
                        GoodsMGroupDB goodsMGroupDB = new GoodsMGroupDB();
                        object retal = null;
                        GoodsMGroupDB goodsMGroupWork = new GoodsMGroupDB();
                        status = goodsMGroupDB.SearchGoodsMGroupProc(out retal, goodsMGroupWork, sqlConnection, sqlTransaction);
                        retCSAList.Add(retal);
                    }

                    //BL�O���[�v
                    if (wktype.Equals(typeof(BLGroupWork)))
                    {
                        BLGroupDB bLGroupDB = new BLGroupDB();
                        object retal = new object();
                        BLGroupWork bLGroupWork = new BLGroupWork();
                        status = bLGroupDB.SearchBLGroupCdProc(out retal, bLGroupWork, sqlConnection, sqlTransaction);
                        retCSAList.Add(retal);
                    }

                    //BL�R�[�h
                    if (wktype.Equals(typeof(TbsPartsCodeWork)))
                    {
                        TbsPartsCodeDB tbsPartsCodeDB = new TbsPartsCodeDB();
                        ArrayList retal = null;
                        TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
                        status = tbsPartsCodeDB.SearchTbsPartsCodeProc(out retal, tbsPartsCodeWork, ref sqlConnection);
                        retCSAList.Add(retal);
                    }
                }
            }
            retObj = retCSAList;
            return status;
        }

        // 2008.06.13 del start ---------------------------------------------->>
        ///// <summary>
        ///// �w�肳�ꂽ�����̏��i�\���擾�i�񋟁j���LIST��߂��܂�(�O�������SqlConnection���g�p)
        ///// </summary>
        ///// <param name="goodsrelationdataWorkList">��������</param>
        ///// <param name="goodsrelationdataWork">�����p�����[�^</param>
        ///// <param name="readMode">�����敪(���ݖ��g�p)</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �w�肳�ꂽ�����̏��i�\���擾�i�񋟁j���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2007.02.06</br>
        ///// <br></br>
        ///// <br>Update Note: 2007.08.29 ���� DC.NS�p�ɏC��</br>
        //public int SearchGoodsRelationDataProc(out ArrayList goodsrelationdataWorkList, GoodsCndtnWork goodsrelationdataWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    ArrayList al = new ArrayList();
        //    string selectstring = "";
        //    try
        //    {
        //        selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
        //        selectstring += "    ,MAKER.MAKERNAMERF AS MAKERNAME" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
        //        selectstring += "    ,TBSPARTSCODE.TBSPARTSFULLNAMERF AS TBSPARTSFULLNAME" + Environment.NewLine;
        //        selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
        //        selectstring += "    ,BLGROUP.GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
        //        selectstring += "    ,GOODSMGROUP.GOODSMGROUPNAMERF AS GOODSMGROUPNAME" + Environment.NewLine;
        //        selectstring += "    ,BLGROUP.BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;
        //        selectstring += "    ,BLGROUP.BLGROUPNAMERF AS BLGROUPNAME" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.CREATEDATETIMERF AS GOODSPCREATEDATETIME" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDATEDATETIMERF AS GOODSPUPDATEDATETIME" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.ENTERPRISECODERF AS GOODSPENTERPRISECODE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.FILEHEADERGUIDRF AS GOODSPFILEHEADERGUID" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDEMPLOYEECODERF AS GOODSPUPDEMPLOYEECODE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDASSEMBLYID1RF AS GOODSPUPDASSEMBLYID1" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDASSEMBLYID2RF AS GOODSPUPDASSEMBLYID2" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.PRICESTARTDATERF AS GOODSPPRICESTARTDATE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.LISTPRICERF AS GOODSPLISTPRICE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.SALESUNITCOSTRF AS GOODSPSALESUNITCOST" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.STOCKRATERF AS GOODSPSTOCKRATE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.OPENPRICEDIVRF AS GOODSPOPENPRICEDIV" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.OFFERDATERF AS GOODSPOFFERDATE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDATEDATERF AS GOODSPUPDATEDATE" + Environment.NewLine;
        //        selectstring += "FROM GOODSRF AS GOODS" + Environment.NewLine;
        //        selectstring += "LEFT JOIN PTMKRPRICERF AS GOODSPRICE" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     GOODSPRICE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
        //        selectstring += " AND GOODSPRICE.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN MAKERNAMERF AS MAKER" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     MAKER.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN TBSPARTSCODERF AS TBSPARTSCODE" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     TBSPARTSCODE.TBSPARTSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN BLGROUPRF AS BLGROUP" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     BLGROUP.BLGROUPCODERF=TBSPARTSCODE.BLGROUPCODERF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     GOODSMGROUP.GOODSMGROUPRF=BLGROUP.GOODSMGROUPRF" + Environment.NewLine;

        //        sqlCommand = new SqlCommand(selectstring, sqlConnection);

        //        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsrelationdataWork, logicalMode);

        //        sqlCommand.CommandText += "ORDER BY GOODSPRICE.PRICESTARTDATERF DESC, GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {

        //            al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));

        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();
        //    }

        //    goodsrelationdataWorkList = al;

        //    return status;
        //}
        #endregion
        // 2008.06.13 del end ------------------------------------------------<<

  	    #region [Where���쐬����]
	      /// <summary>
  	    /// �������������񐶐��{�����l�ݒ�
	      /// </summary>
	      /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
	      /// <param name="goodsRelationDataWork">���������i�[�N���X</param>
	      /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	      /// <returns>Where����������</returns>
	      /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.29 ���� DC.NS�p�ɏC��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsCndtnWork goodsRelationDataWork, ConstantManagement.LogicalMode logicalMode)
        {
 
              string wkstring = "";
              StringBuilder retstring = new StringBuilder();
              retstring.Append("WHERE ");

              //�_���폜�敪
              wkstring = "";
              if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData1)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData2)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData3))
              {
                  wkstring = "GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
              }
              else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData012))
              {
                  wkstring = "GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
              }
              if(wkstring != "")
              {
	              retstring.Append(wkstring);
	              SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
	              paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
              }

              //���i�R�[�h
              if (SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo) != DBNull.Value)
              {
                  if (goodsRelationDataWork.GoodsNoSrchTyp != 0)
                  {
                      //�n�C�t�������i�Ԃɕϊ�
                      string goodsNoNoneHyphen = goodsRelationDataWork.GoodsNo.Replace("-", "");

                      if (goodsRelationDataWork.GoodsNoSrchTyp != 4)
                      {
                          retstring.Append("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                          //�O����v�����̏ꍇ
                          if (goodsRelationDataWork.GoodsNoSrchTyp == 1) goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                          //�����v�����̏ꍇ
                          if (goodsRelationDataWork.GoodsNoSrchTyp == 2) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen;
                          //�����܂������̏ꍇ
                          if (goodsRelationDataWork.GoodsNoSrchTyp == 3) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen + "%";

                      }
                      else
                      {
                          //�n�C�t�������i�Ԋ��S��v�����̏ꍇ
                          retstring.Append("AND GOODS.GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ");
                      }

                      SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                      paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
                  }
                  else
                  {
                      retstring.Append("AND GOODS.GOODSNORF=@GOODSNO ");
                      SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                      paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo);
                  }

              }

              //���[�J�[�R�[�h
              if (goodsRelationDataWork.GoodsMakerCd > 0)
              {
                retstring.Append("AND GOODS.GOODSMAKERCDRF=@GOODSMAKERCD ");
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMakerCd);
              }

              //���i����
              if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsName) == false)
              {
                  retstring.Append("AND GOODS.GOODSNAMERF LIKE @GOODSNAME ");
                  SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                  //�O����v�����̏ꍇ
                  if (goodsRelationDataWork.GoodsNameSrchTyp == 1) goodsRelationDataWork.GoodsName = goodsRelationDataWork.GoodsName + "%";
                  //�����v�����̏ꍇ
                  if (goodsRelationDataWork.GoodsNameSrchTyp == 2) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName;
                  //�����܂������̏ꍇ
                  if (goodsRelationDataWork.GoodsNameSrchTyp == 3) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName + "%";
                  paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsName);
              }

              //���i���̃J�i
              if (goodsRelationDataWork.GoodsNameKana != "")
              {
                  retstring.Append("AND GOODS.GOODSNAMEKANARF LIKE @GOODSNAMEKANA ");
                  SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                  //�O����v�����̏ꍇ
                  if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 1) goodsRelationDataWork.GoodsNameKana = goodsRelationDataWork.GoodsNameKana + "%";
                  //�����v�����̏ꍇ
                  if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 2) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana;
                  //�����܂������̏ꍇ
                  if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 3) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana + "%";
                  paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNameKana);
              }

              //BL�R�[�h
              if (goodsRelationDataWork.BLGoodsCode > 0)
              {
                  retstring.Append("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
                  SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                  paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGoodsCode);
              }

              //BL�O���[�v�R�[�h
              if (goodsRelationDataWork.BLGroupCode > 0)
              {
                  retstring.Append("AND BLGROUP.BLGROUPCODERF=@BLGROUPCODE ");
                  SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                  paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
              }

              //���i�����ރR�[�h
              if (goodsRelationDataWork.GoodsMGroup > 0)
              {
                  retstring.Append("AND BLGROUP.GOODSMGROUPRF=@GOODSMGROUP ");
                  SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                  paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
              }

              //���i����
              if (goodsRelationDataWork.GoodsKindCode != 9)
              {
                  retstring.Append("AND GOODS.GOODSKINDCODERF=@GOODSKINDCODE ");
                  SqlParameter paraDetailGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                  paraDetailGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsKindCode);
              }

            return retstring.ToString();
		  }
	    #endregion

        // 2008.06.13 del start ---------------------------------------------->>
        #region [���i�A���f�[�^�N���X�i�[����]
        ///// <summary>
        ///// �N���X�i�[���� Reader �� GoodsUnitDataWork
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>GoodsUnitDataWork</returns>
        ///// <remarks>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2006.12.06</br>
        ///// <br></br>
        ///// <br>Update Note: 2007.08.29 ���� DC.NS�p�ɏC��</br>
        ///// </remarks>
        //private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)
        //{
        //    GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

        //    #region �N���X�֊i�[
        //    wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    wkGoodsUnitDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAME"));
        //    wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //    wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
        //    wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
        //    wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
        //    wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
        //    wkGoodsUnitDataWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAME"));
        //    wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
        //    wkGoodsUnitDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUP"));
        //    wkGoodsUnitDataWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAME"));
        //    wkGoodsUnitDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
        //    wkGoodsUnitDataWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAME"));
        //    wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
        //    wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
        //    wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
        //    wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //    wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
        //    wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
        //    wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
        //    wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
        //    wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
        //    wkGoodsUnitDataWork.GoodsPriceCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPRICECREATEDATETIME"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPRICEUPDATEDATETIME"));
        //    wkGoodsUnitDataWork.GoodsPriceEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEENTERPRISECODE"));
        //    wkGoodsUnitDataWork.GoodsPriceFileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GOODSPRICEFILEHEADERGUID"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDEMPLOYEECODE"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDASSEMBLYID1"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDASSEMBLYID2"));
        //    wkGoodsUnitDataWork.GoodsPricePriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEPRICESTARTDATE"));
        //    wkGoodsUnitDataWork.GoodsPriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICELISTPRICE"));
        //    wkGoodsUnitDataWork.GoodsPriceSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICESALESUNITCOST"));
        //    wkGoodsUnitDataWork.GoodsPriceStockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICESTOCKRATE"));
        //    wkGoodsUnitDataWork.GoodsPriceOpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSPRICEOPENPRICEDIV"));
        //    wkGoodsUnitDataWork.GoodsPriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEOFFERDATE"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEUPDATEDATE"));
        //    #endregion

        //    return wkGoodsUnitDataWork;
        //}
        #endregion
        // 2008.06.13 del end ------------------------------------------------<<

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
