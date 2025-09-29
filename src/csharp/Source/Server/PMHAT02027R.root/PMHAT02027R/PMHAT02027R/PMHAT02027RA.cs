//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�gDB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �����_�ݒ�}�X�^���X�g���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�gDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^���X�g���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.03.27</br>
    /// </remarks>
    public class OrderSetMasListDB : RemoteDB, IOrderSetMasListDB
    {
        #region �N���X�R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public OrderSetMasListDB()
            : base("PMHAT02029D", "Broadleaf.Application.Remoting.ParamData.OrderSetMasListWork", "ORDERSETMASLIST")
        {

        }
        #endregion

        #region [Search]
        #region �w�肳�ꂽ�����̔����_�ݒ�}�X�^���X�g�ꗗ�\���LIST�̎擾����
        /// <summary>
        /// �w�肳�ꂽ�����̔����_�ݒ�}�X�^���X�g�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="orderSetMasListParaWork">�����p�����[�^</param>
        /// <param name="orderSetMasListWork">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̔����_�ݒ�}�X�^���X�g�ꗗ�\���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Search(out object orderSetMasListWork, ref object orderSetMasListParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            orderSetMasListWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out orderSetMasListWork, orderSetMasListParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "orderSetMasListDB.Search");
                orderSetMasListWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "orderSetMasList.DB");
                orderSetMasListWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region �w�肳�ꂽ�����̔����_�ݒ�}�X�^���X�g�ꗗ�\���LIST(�O�������SqlConnection���g�p)
        /// <summary>
        /// �w�肳�ꂽ�����̔����_�ݒ�}�X�^���X�g�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retList">�����p�����[�^</param>
        /// <param name="paraObj">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̔����_�ݒ�}�X�^���X�g�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            OrderSetMasListParaWork paraWork = null;
            paraWork = paraObj as OrderSetMasListParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                selectTxt = MakeSearchSQL(ref selectTxt, ref sqlCommand,  paraWork);
              
                //�\�[�g��
                selectTxt.Append( " ORDER BY ");
                //�����_�ݒ�}�X�^.�p�^�[���ԍ� �@(�ݒ�R�[�h�j
                selectTxt.Append( "A.PATTERNORF, ");
                selectTxt.Append( "A.PATTERNNODERIVEDNORF ");
                selectTxt.Append( " ASC ");
                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                //int con = 1;
                while (myReader.Read())
                {
                    al.Add(CopyToOrderSetMasListWorkFromReader(ref myReader));
                    //al.Add(CopyToOrderSetMasListWorkFromReader(ref myReader, con));
                    //con++;
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
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;

        }

        
        #endregion

        #region �����pSQL�̎擾����
        /// <summary>
        /// �����pSQL�̎擾����
        /// </summary>
        /// <param name="selectTxt">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����pSQL���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL(ref StringBuilder selectTxt, ref SqlCommand sqlCommand, OrderSetMasListParaWork paraWork)
        {
            #region [�擾����]
            selectTxt.Append( "SELECT DISTINCT ");
            selectTxt.Append( "A.PATTERNORF PATTERNORF, " );                        // �ݒ�R�[�h
            selectTxt.Append( "A.PATTERNNODERIVEDNORF PATTERNNODERIVEDNORF, ");     // �p�^�[���ԍ��}��
            selectTxt.Append( "A.WAREHOUSECODERF WAREHOUSECODERF, " );              // �q�ɃR�[�h
            selectTxt.Append( "B.WAREHOUSENAMERF WAREHOUSENAMERF, ");               // �q�ɖ���
            selectTxt.Append( "A.SUPPLIERCDRF SUPPLIERCDRF, "  );                   // �d����R�[�h
            selectTxt.Append( "C.SUPPLIERSNMRF SUPPLIERSNMRF, " );                  // �d���於
            selectTxt.Append( "A.GOODSMAKERCDRF GOODSMAKERCDRF, " );                // ���i���[�J�[�R�[�h
            selectTxt.Append( "D.MAKERNAMERF MAKERNAMERF, " );                      // ���[�J�[����
            selectTxt.Append( "A.GOODSMGROUPRF GOODSMGROUPRF, ");                   // ���i�����ރR�[�h
            selectTxt.Append( "E.GOODSMGROUPNAMERF GOODSMGROUPNAMERF, ");           // ���i�����ޖ���
            selectTxt.Append( "A.BLGROUPCODERF BLGROUPCODERF, ");                   // BL�O���[�v�R�[�h
            selectTxt.Append("F.BLGROUPKANANAMERF BLGROUPKANANAMERF, ");            // BL�O���[�v�R�[�h�J�i����
            selectTxt.Append( "A.BLGOODSCODERF BLGOODSCODERF, ");                   // BL���i�R�[�h
            selectTxt.Append( "G.BLGOODSHALFNAMERF BLGOODSHALFNAMERF, ");           // BL���i�R�[�h����
            selectTxt.Append( "A.STCKSHIPMONTHSTRF STCKSHIPMONTHSTRF, ");           // �݌ɏo�בΏۊJ�n��
            selectTxt.Append( "A.STCKSHIPMONTHEDRF STCKSHIPMONTHEDRF, ");           // �݌ɏo�בΏۏI����
            selectTxt.Append( "A.ORDERAPPLYDIVRF ORDERAPPLYDIVRF, ");               // �����K�p�敪
            selectTxt.Append( "A.STOCKCREATEDATERF STOCKCREATEDATERF, ");           //�݌ɓo�^��
            selectTxt.Append( "A.SHIPSCOPEMORERF SHIPSCOPEMORERF, "  );             //�o�א��͈�(�ȏ�)
            selectTxt.Append( "A.SHIPSCOPELESSRF SHIPSCOPELESSRF, "  );             //�o�א��͈�(�ȉ�)
            selectTxt.Append( "A.MINIMUMSTOCKCNTRF MINIMUMSTOCKCNTRF, " );          //�Œ�݌ɐ�
            selectTxt.Append( "A.MAXIMUMSTOCKCNTRF MAXIMUMSTOCKCNTRF, " );          //�ō��݌ɐ�
            selectTxt.Append( "A.SALESORDERUNITRF SALESORDERUNITRF, " );           //�����P��(�������b�g)
            selectTxt.Append( "A.ORDERPPROCUPDFLGRF ORDERPPROCUPDFLGRF ");       //�����_�����X�V�t���O

            #endregion
            #region [�e�[�u��]
            selectTxt.Append( "FROM ");
            selectTxt.Append( "ORDERPOINTSTRF A ");
            // �q�Ƀ}�X�^
            selectTxt.Append(" LEFT JOIN WAREHOUSERF B ON ");
            selectTxt.Append(" (A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
            selectTxt.Append(" AND A.WAREHOUSECODERF = B.WAREHOUSECODERF " );
            selectTxt.Append(" AND B.LOGICALDELETECODERF = 0) ");
            // �d����}�X�^
            selectTxt.Append("LEFT JOIN SUPPLIERRF C ON ");  
            selectTxt.Append("(A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
            selectTxt.Append("AND A.SUPPLIERCDRF = C.SUPPLIERCDRF ");
            selectTxt.Append("AND C.LOGICALDELETECODERF = 0) ");
            // ���[�J�[�}�X�^
            selectTxt.Append("LEFT JOIN MAKERURF D ON ");
            selectTxt.Append(" (A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
            selectTxt.Append("AND A.GOODSMAKERCDRF = D.GOODSMAKERCDRF ");
            selectTxt.Append("AND D.LOGICALDELETECODERF = 0) ");
             // ���i�����ރ}�X�^
            selectTxt.Append( "LEFT JOIN GOODSGROUPURF E ON  ");
            selectTxt.Append("(A.ENTERPRISECODERF = E.ENTERPRISECODERF  ");
            selectTxt.Append(" AND A.GOODSMGROUPRF = E.GOODSMGROUPRF  ");
            selectTxt.Append(" AND E.LOGICALDELETECODERF = 0) ");
            // BL�O���[�v�}�X�^
            selectTxt.Append( "LEFT JOIN BLGROUPURF F ON ");
            selectTxt.Append(" (A.ENTERPRISECODERF = F.ENTERPRISECODERF ");
            selectTxt.Append(" AND A.BLGROUPCODERF = F.BLGROUPCODERF ");
            selectTxt.Append(" AND F.LOGICALDELETECODERF = 0) ");
            // BL�R�[�h�}�X�^
            selectTxt.Append( "LEFT JOIN BLGOODSCDURF G ON  ");
            selectTxt.Append( "(A.ENTERPRISECODERF = G.ENTERPRISECODERF ");
            selectTxt.Append(" AND A.BLGOODSCODERF = G.BLGOODSCODERF ");
            selectTxt.Append(" AND G.LOGICALDELETECODERF = 0) ");
            #endregion
            #region [���o����]
            MakeWhereString(ref selectTxt, ref sqlCommand, paraWork);

            return selectTxt;
            #endregion
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐������Ə����l�ݒ菈��
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref StringBuilder sql, ref SqlCommand sqlCommand, OrderSetMasListParaWork paraWork)
        {
            sql.Append(" WHERE  ");
            // A.��ƃR�[�h=�p�����[�^.��ƃR�[�h
            sql.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE1 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            //AND A.�ݒ�R�[�h(�J�n)�@=�p�����[�^.�ݒ�R�[�h
            //-------------ADD 2009/07/13 PVCS334---------->>>>>
            if (!string.IsNullOrEmpty(paraWork.StartSetCode)) �@// ��ʂ̐ݒ�R�[�h(�J�n)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.PATTERNORF>= @STPATTERNORF ");
                SqlParameter paraStPatterNo = sqlCommand.Parameters.Add("@STPATTERNORF", SqlDbType.Int);
                paraStPatterNo.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.StartSetCode));
            }
            //-------------ADD 2009/07/13 PVCS334----------<<<<<
            if (!string.IsNullOrEmpty(paraWork.EndSetCode)) �@// ��ʂ̐ݒ�R�[�h(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.PATTERNORF <= @EDPATTERNORF ");
                SqlParameter paraEdPatterNo = sqlCommand.Parameters.Add("@EDPATTERNORF", SqlDbType.Int);
                paraEdPatterNo.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.EndSetCode));
            }

            //AND A.�q�ɃR�[�h�@=�p�����[�^.�q�ɃR�[�h�@�@�@// ��ʂ̑q��(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.StartWarehouseCode))
            {
                sql.Append(" AND A.WAREHOUSECODERF >= @STWAREHOUSE ");
                SqlParameter paraStWareHouse = sqlCommand.Parameters.Add("@STWAREHOUSE", SqlDbType.NChar);
                paraStWareHouse.Value = SqlDataMediator.SqlSetString(paraWork.StartWarehouseCode);
            }
            if (!string.IsNullOrEmpty(paraWork.EndWarehouseCode)) // ��ʂ̑q��(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.WAREHOUSECODERF <= @EDWAREHOUSE ");
                SqlParameter paraEdWareHouse = sqlCommand.Parameters.Add("@EDWAREHOUSE", SqlDbType.NChar);
                paraEdWareHouse.Value = SqlDataMediator.SqlSetString(paraWork.EndWarehouseCode);
            }

            //AND A.�d����R�[�h�@=�p�����[�^.�d����R�[�h�@�@�@// ��ʂ̎d����(�J�n)�����͂��ꂽ�ꍇ
            if (0 != paraWork.StartSupplierCd)
            {
                sql.Append(" AND A.SUPPLIERCDRF >= @STSUPPLIERCDRF ");
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCDRF", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.StartSupplierCd);
            }
            if (0 != paraWork.EndSupplierCd) // ��ʂ̎d����(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.SUPPLIERCDRF <= @EDSUPPLIERCDRF ");
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCDRF", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.EndSupplierCd);
            }

            //AND A.���[�J�[�R�[�h�@=�p�����[�^.���[�J�[�R�[�h�@�@�@// ��ʂ̃��[�J�[(�J�n)�����͂��ꂽ�ꍇ
            if (0 != paraWork.StartGoodsMakerCd)
            {
                sql.Append(" AND A.GOODSMAKERCDRF >= @STGOODSMAKERCDRF ");
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCDRF", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.StartGoodsMakerCd);
            }
            if (0 != paraWork.EndGoodsMakerCd) // ��ʂ̃��[�J�[(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.GOODSMAKERCDRF <= @EDGOODSMAKERCDRF ");
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCDRF", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.EndGoodsMakerCd);
            }

            //AND A.���i�����ރR�[�h�@=�p�����[�^.���i�����ރR�[�h�@�@�@// ��ʂ̒�����(�J�n)�����͂��ꂽ�ꍇ
            if (0 != paraWork.StartGoodsMGroup)
            {
                sql.Append(" AND A.GOODSMGROUPRF >= @STGOODSMGROUPRF ");
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUPRF", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(paraWork.StartGoodsMGroup);
            }
            if (0 != paraWork.EndGoodsMGroup) // ��ʂ̒�����(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.GOODSMGROUPRF <= @EDGOODSMGROUPRF ");
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUPRF", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(paraWork.EndGoodsMGroup);
            }

            //AND A.BL�O���[�v�R�[�h�@=�p�����[�^.BL�O���[�v�R�[�h�@�@�@// ��ʂ̃O���[�v(�J�n)�����͂��ꂽ�ꍇ
            if (0 != paraWork.StartBLGroupCode)
            {
                sql.Append(" AND A.BLGROUPCODERF >= @STBLGROUPCODERF ");
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODERF", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paraWork.StartBLGroupCode);
            }
            if (0 != paraWork.EndBLGroupCode) // ��ʂ̃O���[�v(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.BLGROUPCODERF <= @EDBLGROUPCODERF ");
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODERF", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paraWork.EndBLGroupCode);
            }

            //AND A.BL���i�R�[�h�@=�p�����[�^.BL���i�R�[�h�@�@�@// ��ʂ�BL�R�[�h(�J�n)�����͂��ꂽ�ꍇ
            if (0 != paraWork.StartBLGoodsCode)
            {
                sql.Append(" AND A.BLGOODSCODERF >= @STBLGOODSCODERF ");
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODERF", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paraWork.StartBLGoodsCode);
            }
            if (0 != paraWork.EndBLGoodsCode) // ��ʂ�BL�R�[�h(�I��)�����͂��ꂽ�ꍇ
            {
                sql.Append(" AND A.BLGOODSCODERF <= @EDBLGOODSCODERF ");
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODERF", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paraWork.EndBLGoodsCode);
            }

            //AND A.�_���폜�敪 = �p�����[�^.���s�^�C�v
            // �p�����[�^.���s�^�C�v != [2:�S��]
            if (2 != paraWork.PrintType )
            {
                sql.Append(" AND A.LOGICALDELETECODERF=@LOGICALDELETECODERF ");
                SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);
                paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(paraWork.PrintType);
            }
            return sql;
        }
        #endregion
        #endregion

        #region �N���X�i�[���� Reader �� OrderSetMasListWork
        /// <summary>
        /// �N���X�i�[���� Reader �� USysDemoFeeMessWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : Reader����OrderSetMasListWork�֕ϊ����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private OrderSetMasListWork CopyToOrderSetMasListWorkFromReader(ref SqlDataReader myReader)
        {
            OrderSetMasListWork listWork = new OrderSetMasListWork();
            #region �N���X�֊i�[

            string warehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            int supplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            int goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            int goodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            int bLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            int bLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));

            // �ݒ�R�[�h=�����_�ݒ�}�X�^�D�p�^�[���ԍ�		
            listWork.PatterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNORF"));

            // �q�ɂ�NULL�ꍇ
            if (String.IsNullOrEmpty(warehouseCode))
            {
                listWork.WarehouseCode = "0000";
                listWork.WarehouseName = "�S�q��";
            }
            else if (warehouseCode.Trim().Equals("0000"))
            {
                listWork.WarehouseCode = "0000";
                listWork.WarehouseName = "�S�q��";
            }
            else
            {   // �q�ɃR�[�h=�����_�ݒ�}�X�^�D�q�ɃR�[�h
                listWork.WarehouseCode = warehouseCode;
                // �q�ɖ��� =�q�Ƀ}�X�^. �q�ɖ���
                listWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }

            // �d�����NULL�ꍇ
            if (0 == supplierCd)
            {
                listWork.SupplierCd = "000000";
                listWork.SupplierSnm = "�S�d����";
            }
            else
            {
                // �d����R�[�h=�����_�ݒ�}�X�^�D�d����R�[�h    
                listWork.SupplierCd = supplierCd.ToString();
                // �d���於��=�d����}�X�^.�d���旪��
                listWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            }

            // ���[�J�[��NULL�ꍇ
            if (0 == goodsMakerCd)
            {
                listWork.GoodsMakerCd = "0000";
                listWork.MakerName = "�S���[�J�[";
            }
            else
            {
                // ���[�J�[�R�[�h=�����_�ݒ�}�X�^�D���i���[�J�[�R�[�h
                listWork.GoodsMakerCd = goodsMakerCd.ToString();
                // ���[�J�[����	=���[�J�[�}�X�^.���[�J�[����
                listWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            }

            // ���i�����ނ�NULL�ꍇ
            if (0 == goodsMGroup)
            {
                listWork.GoodsMGroup = "0000";
                listWork.GoodsMGroupName = "�S���i������";
            }
            else
            {
                // ���i�����ރR�[�h=�����_�ݒ�}�X�^�D���i�����ރR�[�h
                listWork.GoodsMGroup = goodsMGroup.ToString();
                // ���i�����ޖ���	=���i�����ރ}�X�^.���i�����ޖ���
                listWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            }

            // BL���i�R�[�h��NULL�ꍇ
            if (0 == bLGoodsCode)
            {
                listWork.BLGoodsCode = "00000";
                listWork.BLGoodsHalfName = "�S�a�k�R�[�h";
            }
            else
            {
                // BL���i�R�[�h=�����_�ݒ�}�X�^�DBL���i�R�[�h
                listWork.BLGoodsCode = bLGoodsCode.ToString();
                // BL���i�R�[�h���́i���p�j	=�a�k���i�R�[�h�}�X�^.BL���i�R�[�h���́i���p�j
                listWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            }

            // BL�O���[�v��NULL�ꍇ
            if (0 == bLGroupCode)
            {
                listWork.BLGroupCode = "00000";
                listWork.BLGroupName = "�S�O���[�v�R�[�h";
            }
            else
            {
                // BL�O���[�v�R�[�h=�����_�ݒ�}�X�^�DBL�O���[�v�R�[�h
                listWork.BLGroupCode = bLGroupCode.ToString();
                // BL�O���[�v�R�[�h����	=BL�O���[�v�}�X�^.BL�O���[�v�R�[�h�J�i����
                listWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            }

            // �݌ɏo�בΏۊJ�n�� = �����_�ݒ�}�X�^�D�݌ɏo�בΏۊJ�n��
            string stckShipMonthSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHSTRF")).ToString();
            if (String.IsNullOrEmpty(stckShipMonthSt))
            {
                listWork.StckShipMonthSt = String.Empty;
            }
            else
            {
                listWork.StckShipMonthSt = DateTime.ParseExact(stckShipMonthSt, "yyyyMMdd", null).ToString("yyyy/MM/dd");
            }

            // �݌ɏo�בΏۏI���� =�����_�ݒ�}�X�^�D�݌ɏo�בΏۏI����
            string stckShipMonthEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKSHIPMONTHEDRF")).ToString();
            if (String.IsNullOrEmpty(stckShipMonthEd))
            {
                listWork.StckShipMonthEd = String.Empty;
            }
            else
            {
                listWork.StckShipMonthEd = DateTime.ParseExact(stckShipMonthEd, "yyyyMMdd", null).ToString("yyyy/MM/dd");
            }

            // �o�א��͈�(�ȏ�) =�����_�ݒ�}�X�^�D�o�א��͈�(�ȏ�)
            listWork.ShipScopeMore = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPEMORERF"));
            // �o�א��͈�(�ȉ�)	=�����_�ݒ�}�X�^�D�o�א��͈�(�ȉ�)	  
            listWork.ShipScopeLess = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPSCOPELESSRF"));
            // �Œ�݌ɐ�=�����_�ݒ�}�X�^�D�Œ�݌ɐ�	
            listWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            // �ō��݌ɐ�=�����_�ݒ�}�X�^�D�ō��݌ɐ�
            listWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            // ���b�g��=�����_�ݒ�}�X�^�D�����P��
            listWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            // �t���O=�����_�ݒ�}�X�^�D�����_�����X�V�t���O
            int orderPProcUpdFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERPPROCUPDFLGRF"));
            listWork.OrderPProcUpdFlg = OrderPProcUpdFlgConvToString(orderPProcUpdFlg);

            // �����K�p�敪=�����_�ݒ�}�X�^�D�����K�p�敪
            int orderApplyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERAPPLYDIVRF"));
            listWork.OrderApplyDiv = OrderApplyDivConvToString(orderApplyDiv);

            // �݌ɓo�^��
            string stockCreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCREATEDATERF")).ToString();
            if (String.IsNullOrEmpty(stockCreateDate))
            {
                listWork.StockCreateDate = String.Empty;
            }
            else
            {
                listWork.StockCreateDate = DateTime.ParseExact(stockCreateDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + "�ȑO";
            }
            #endregion
            return listWork;
        }

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="_orderPProcUpdFlg">�����_�����X�V�t���O int</param>
        /// <returns>�����_�����X�V�t���O string</returns>
        /// <remarks>
        /// <br>Note       : �����_�����X�V�t���O�擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks> 
        private string OrderPProcUpdFlgConvToString(int _orderPProcUpdFlg)
        {
            string orderPProcUpdFlg = string.Empty;
            switch (_orderPProcUpdFlg)
            {
                case (0):
                    {
                        // ���X�V
                        orderPProcUpdFlg = "���X�V";
                    }
                    break;
                case (1):
                    {
                        // �X�V��
                        orderPProcUpdFlg = "�X�V��";
                    }
                    break;
            }

            return orderPProcUpdFlg;
        }

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="_orderApplyDiv">�����K�p�敪 int</param>
        /// <returns>�����K�p�敪 string</returns>
        /// <remarks>
        /// <br>Note       : �����K�p�敪�擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks> 
        private string OrderApplyDivConvToString(int _orderApplyDiv)
        {
            string orderApplyDiv = string.Empty;
            switch (_orderApplyDiv)
            {
                case (0):
                    {
                        // ����
                        orderApplyDiv = "����";
                    }
                    break;
                case (1):
                    {
                        // ���v
                        orderApplyDiv = "���v";
                    }
                    break;
            }

            return orderApplyDiv;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
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
