//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈��DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100937-00 �쐬�S�� : ����g  
// �C �� ��  2015/06/03  �C�����e : Redmine#45978 �C�X�R�W���p�� ����q�ɓ��œ���i�Ԃ������󎚂����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11202593-00  �쐬�S�� : miyatsu
// �C �� ��  2017/02/10  �C�����e : �݌ɓo�^���t�̏������Q�Ƃ��Ă��Ȃ���Q�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����_�ݒ菈��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ菈���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class OrderPointStSimulationDB : RemoteDB, IOrderPointStSimulationDB
    {
        /// <summary>
        /// �����_�ݒ菈��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public OrderPointStSimulationDB()
            :
            base("PMHAT09113D", "Broadleaf.Application.Remoting.ParamData.OrderPointStSimulationWork", "ORDERPOINTSTSIMULATIONRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔����_�ݒ菈���f�[�^��߂��܂�
        /// </summary>
        /// <param name="list">��������</param>
        /// <param name="stockList">�݌Ƀ}�X�^��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔����_�ݒ菈���f�[�^��߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        public int Search(out object list, out object stockList, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            list = null;
            stockList = null;
            ExtrInfo_OrderPointStSimulationWork paraWork = paramWork as ExtrInfo_OrderPointStSimulationWork;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out list, out stockList, paraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointStSimulationDB.Search");
                list = new ArrayList();
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
        }
        #endregion

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔����_�ݒ菈���f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="list">��������</param>
        /// <param name="stockList">�݌Ƀ}�X�^��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔����_�ݒ菈���f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        private int SearchProc(out object list, out object stockList, ExtrInfo_OrderPointStSimulationWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            ArrayList stockAl = new ArrayList();

            string sqlText = string.Empty;
            StringBuilder sql = new StringBuilder();

            //------ADD 2009/07/14 WUYX PVCS338--------->>>>>
            // ���Ԋu�̌v�Z
            DateTime _stckShipMonthSt = TDateTime.LongDateToDateTime(paramWork.StckShipMonthSt);
            DateTime _stckShipMonthEd = TDateTime.LongDateToDateTime(paramWork.StckShipMonthEd);
            TimeSpan Interva = _stckShipMonthEd.Subtract(_stckShipMonthSt);
            double dblMonthLen = (365 / 12);
            Int32 _monthInterval = Convert.ToInt32(Interva.Days / dblMonthLen);
            if (_monthInterval <= 0)
            {
                _monthInterval = 1;
            }
            //------ADD 2009/07/14 WUYX PVCS338---------<<<<<

            try
            {
                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                sql.Append(" SELECT").Append(Environment.NewLine);
                sql.Append("     A.PATTERNORF,").Append(Environment.NewLine);
                sql.Append("     A.PATTERNNODERIVEDNORF,").Append(Environment.NewLine);
                sql.Append("     J.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("     B.WAREHOUSECODERF,").Append(Environment.NewLine);
                sql.Append("     G.WAREHOUSENAMERF,").Append(Environment.NewLine);
                sql.Append("     J.WAREHOUSESHELFNORF,").Append(Environment.NewLine);
                sql.Append("     B.SUPPLIERCDRF,").Append(Environment.NewLine);
                sql.Append("     J.SHIPMENTPOSCNTRF,").Append(Environment.NewLine);
                sql.Append("     B.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("     I.MAKERNAMERF,").Append(Environment.NewLine);
                sql.Append("     B.GOODSMGROUPRF,").Append(Environment.NewLine);
                sql.Append("     B.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("     B.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("     J.GOODSNORF,").Append(Environment.NewLine);
                sql.Append("     A.MINIMUMSTOCKCNTRF NEWMINCNT,").Append(Environment.NewLine);
                sql.Append("     A.MAXIMUMSTOCKCNTRF NEWMAXCNT,").Append(Environment.NewLine);
                sql.Append("     A.SALESORDERUNITRF,").Append(Environment.NewLine);
                sql.Append("     H.SUPPLIERSNMRF,").Append(Environment.NewLine);
                sql.Append("     J.MINIMUMSTOCKCNTRF OLDMINCNT,").Append(Environment.NewLine);
                sql.Append("     J.MAXIMUMSTOCKCNTRF OLDMAXCNT,").Append(Environment.NewLine);
                sql.Append("     J.CREATEDATETIMERF STOCK_CREATEDATETIMERF,").Append(Environment.NewLine);
                sql.Append("     J.UPDATEDATETIMERF STOCK_UPDATEDATETIMERF,").Append(Environment.NewLine);
                sql.Append("     J.ENTERPRISECODERF STOCK_ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("     J.FILEHEADERGUIDRF STOCK_FILEHEADERGUIDRF,").Append(Environment.NewLine);
                sql.Append("     J.UPDEMPLOYEECODERF STOCK_UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sql.Append("     J.UPDASSEMBLYID1RF STOCK_UPDASSEMBLYID1RF,").Append(Environment.NewLine);
                sql.Append("     J.UPDASSEMBLYID2RF STOCK_UPDASSEMBLYID2RF,").Append(Environment.NewLine);
                sql.Append("     J.LOGICALDELETECODERF STOCK_LOGICALDELETECODERF,").Append(Environment.NewLine);
                sql.Append("     J.SECTIONCODERF STOCK_SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("     J.WAREHOUSECODERF STOCK_WAREHOUSECODERF,").Append(Environment.NewLine);
                sql.Append("     J.GOODSMAKERCDRF STOCK_GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("     J.GOODSNORF STOCK_GOODSNORF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKUNITPRICEFLRF STOCK_STOCKUNITPRICEFLRF,").Append(Environment.NewLine);
                sql.Append("     J.SUPPLIERSTOCKRF STOCK_SUPPLIERSTOCKRF,").Append(Environment.NewLine);
                sql.Append("     J.ACPODRCOUNTRF STOCK_ACPODRCOUNTRF,").Append(Environment.NewLine);
                sql.Append("     J.MONTHORDERCOUNTRF STOCK_MONTHORDERCOUNTRF,").Append(Environment.NewLine);
                sql.Append("     J.SALESORDERCOUNTRF STOCK_SALESORDERCOUNTRF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKDIVRF STOCK_STOCKDIVRF,").Append(Environment.NewLine);
                sql.Append("     J.MOVINGSUPLISTOCKRF STOCK_MOVINGSUPLISTOCKRF,").Append(Environment.NewLine);
                sql.Append("     J.SHIPMENTPOSCNTRF STOCK_SHIPMENTPOSCNTRF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKTOTALPRICERF STOCK_STOCKTOTALPRICERF,").Append(Environment.NewLine);
                sql.Append("     J.LASTSTOCKDATERF STOCK_LASTSTOCKDATERF,").Append(Environment.NewLine);
                sql.Append("     J.LASTSALESDATERF STOCK_LASTSALESDATERF,").Append(Environment.NewLine);
                sql.Append("     J.LASTINVENTORYUPDATERF STOCK_LASTINVENTORYUPDATERF,").Append(Environment.NewLine);
                sql.Append("     J.MINIMUMSTOCKCNTRF STOCK_MINIMUMSTOCKCNTRF,").Append(Environment.NewLine);
                sql.Append("     J.MAXIMUMSTOCKCNTRF STOCK_MAXIMUMSTOCKCNTRF,").Append(Environment.NewLine);
                sql.Append("     J.NMLSALODRCOUNTRF STOCK_NMLSALODRCOUNTRF,").Append(Environment.NewLine);
                sql.Append("     J.SALESORDERUNITRF STOCK_SALESORDERUNITRF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKSUPPLIERCODERF STOCK_STOCKSUPPLIERCODERF,").Append(Environment.NewLine);
                sql.Append("     J.GOODSNONONEHYPHENRF STOCK_GOODSNONONEHYPHENRF,").Append(Environment.NewLine);
                sql.Append("     J.WAREHOUSESHELFNORF STOCK_WAREHOUSESHELFNORF,").Append(Environment.NewLine);
                sql.Append("     J.DUPLICATIONSHELFNO1RF STOCK_DUPLICATIONSHELFNO1RF,").Append(Environment.NewLine);
                sql.Append("     J.DUPLICATIONSHELFNO2RF STOCK_DUPLICATIONSHELFNO2RF,").Append(Environment.NewLine);
                sql.Append("     J.PARTSMANAGEMENTDIVIDE1RF STOCK_PARTSMANAGEMENTDIVIDE1RF,").Append(Environment.NewLine);
                sql.Append("     J.PARTSMANAGEMENTDIVIDE2RF STOCK_PARTSMANAGEMENTDIVIDE2RF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKNOTE1RF STOCK_STOCKNOTE1RF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKNOTE2RF STOCK_STOCKNOTE2RF,").Append(Environment.NewLine);
                sql.Append("     J.SHIPMENTCNTRF STOCK_SHIPMENTCNTRF,").Append(Environment.NewLine);
                sql.Append("     J.ARRIVALCNTRF STOCK_ARRIVALCNTRF,").Append(Environment.NewLine);
                sql.Append("     J.STOCKCREATEDATERF STOCK_STOCKCREATEDATERF,").Append(Environment.NewLine);
                sql.Append("     J.UPDATEDATERF STOCK_UPDATEDATERF").Append(Environment.NewLine);
                sql.Append(" FROM").Append(Environment.NewLine);
                sql.Append("     ORDERPOINTSTRF A,").Append(Environment.NewLine);
                sql.Append("     (").Append(Environment.NewLine);
                if (paramWork.SumMethod == 0)
                {
                    // ��񂹕����܂ނ̏ꍇ
                    sql.Append("     SELECT").Append(Environment.NewLine);
                    sql.Append("         TBSUB.WAREHOUSECODERF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.SUPPLIERCDRF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.GOODSMAKERCDRF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.GOODSMGROUPRF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.BLGROUPCODERF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.BLGOODSCODERF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.GOODSNORF,").Append(Environment.NewLine);
                    sql.Append("         SUM(TBSUB.SUMSHIPMENTCNTRF) AS SUMSHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("     FROM").Append(Environment.NewLine);
                    sql.Append("     ( ").Append(Environment.NewLine);
                    sql.Append(MakeSubSelectSQL(paramWork, 0)).Append(Environment.NewLine); // ��񂹕����܂�
                    sql.Append("     UNION ").Append(Environment.NewLine);
                    sql.Append(MakeSubSelectSQL(paramWork, 1)).Append(Environment.NewLine); // �݌Ƀ}�X�^�̂�
                    sql.Append("     ) TBSUB").Append(Environment.NewLine);
                    sql.Append("     GROUP BY").Append(Environment.NewLine);
                    sql.Append("         TBSUB.WAREHOUSECODERF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.SUPPLIERCDRF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.GOODSMAKERCDRF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.GOODSMGROUPRF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.BLGROUPCODERF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.BLGOODSCODERF,").Append(Environment.NewLine);
                    sql.Append("         TBSUB.GOODSNORF").Append(Environment.NewLine);
                }
                else
                {
                    // �݌Ƀ}�X�^�̂ݏꍇ
                    sql.Append(MakeSubSelectSQL(paramWork, 1)).Append(Environment.NewLine);
                }
                sql.Append("     ) B").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN WAREHOUSERF G").Append(Environment.NewLine);
                sql.Append("     ON  G.ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
                sql.Append("     AND G.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND B.WAREHOUSECODERF = G.WAREHOUSECODERF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN SUPPLIERRF H").Append(Environment.NewLine);
                sql.Append("     ON  H.ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
                sql.Append("     AND H.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND B.SUPPLIERCDRF = H.SUPPLIERCDRF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN MAKERURF I").Append(Environment.NewLine);
                sql.Append("     ON  I.ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
                sql.Append("     AND I.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND B.GOODSMAKERCDRF = I.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("     STOCKRF J").Append(Environment.NewLine);
                sql.Append(" WHERE").Append(Environment.NewLine);
                sql.Append("        A.ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
                sql.Append(" AND A.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append(" AND A.PATTERNORF = @PATTERNO").Append(Environment.NewLine);
                //-------------ADD 2009/07/14 WUYX PVCS338----->>>>>
                //�����_�ݒ�}�X�^.�����K�p�敪 =[0: ����]�̏ꍇ
                if (paramWork.OrderApplyDiv == 0)
                {
                    sql.Append(" AND A.SHIPSCOPEMORERF <= ROUND(B.SUMSHIPMENTCNTRF/ ");
                    sql.Append("'" + _monthInterval + "'" + ",3)").Append(Environment.NewLine);
                    sql.Append(" AND A.SHIPSCOPELESSRF >= ROUND(B.SUMSHIPMENTCNTRF/");
                    sql.Append("'" + _monthInterval + "'" + ",3)").Append(Environment.NewLine);
                }
                //�����_�ݒ�}�X�^.�����K�p�敪 =[1�F����]�̏ꍇ
                if (paramWork.OrderApplyDiv == 1)
                {
                    sql.Append(" AND A.SHIPSCOPEMORERF <= B.SUMSHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append(" AND A.SHIPSCOPELESSRF >= B.SUMSHIPMENTCNTRF").Append(Environment.NewLine);
                }
                //-------------ADD 2009/07/14 WUYX PVCS338-----<<<<<

                //-------------ADD 2017/02/10 miyatsu----->>>> �݌ɓo�^���t�̏��������Ă��Ȃ���Q�̏C��
                sql.Append(" AND A.STOCKCREATEDATERF >= J.STOCKCREATEDATERF").Append(Environment.NewLine);
                //-------------ADD 2017/02/10 miyatsu-----<<<<

                sql.Append(" AND J.ENTERPRISECODERF = A.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append(" AND B.WAREHOUSECODERF = J.WAREHOUSECODERF").Append(Environment.NewLine);
                sql.Append(" AND B.GOODSMAKERCDRF = J.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append(" AND B.GOODSNORF = J.GOODSNORF").Append(Environment.NewLine);
                // �\�[�g��
                sql.Append(MakeOrderString(paramWork));

                // ���������ݒ�
                MakeWhereSetValue(ref sqlCommand, paramWork);

                sqlCommand.CommandText = sql.ToString();              

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ���[�f�[�^���X�g�̍쐬
                    al.Add(CopyToOrderPointStSimulationWorkFromReader(ref myReader, paramWork));

                    // �݌Ƀ}�X�^�f�[�^���X�g�̍쐬
                    stockAl.Add(CopyToStockWorkFromReader(ref myReader));
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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

            list = al;
            stockList = stockAl;

            return status;
        }
        #endregion

        # region [SQL���쐬����]
        /// <summary>
        /// ����SQL���ݒ�
        /// </summary>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sumMethod">�W�v���@</param>
        /// <returns/>
        /// <br>Note       : SQL�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.17</br>
        /// <br>UpdateNote : Redmine#45978 �C�X�R�W���p�� ����q�ɓ��œ���i�Ԃ������󎚂����C��</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2015/06/03</br>
        private string MakeSubSelectSQL(ExtrInfo_OrderPointStSimulationWork paramWork, Int32 sumMethod)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("     SELECT").Append(Environment.NewLine);
            sql.Append("         C.WAREHOUSECODERF,").Append(Environment.NewLine);
            sql.Append("         D.WAREHOUSECODERF DWAREHOUSECODERF,").Append(Environment.NewLine);
            //sql.Append("         D.SUPPLIERCDRF,").Append(Environment.NewLine);  //DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            sql.Append("         0 AS SUPPLIERCDRF,").Append(Environment.NewLine);  //ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            sql.Append("         D.GOODSMAKERCDRF,").Append(Environment.NewLine);
            // ------------------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            //sql.Append("         D.GOODSMGROUPRF,").Append(Environment.NewLine);
            //sql.Append("         D.BLGROUPCODERF,").Append(Environment.NewLine);
            //sql.Append("         D.BLGOODSCODERF,").Append(Environment.NewLine);
            // ------------------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            sql.Append("         G.GOODSMGROUPRF,").Append(Environment.NewLine);
            sql.Append("         F.BLGROUPCODERF,").Append(Environment.NewLine);
            sql.Append("         E.BLGOODSCODERF,").Append(Environment.NewLine);
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            sql.Append("         D.GOODSNORF,").Append(Environment.NewLine);
            sql.Append("         SUM(D.SHIPMENTCNTRF) AS SUMSHIPMENTCNTRF").Append(Environment.NewLine);
            sql.Append("     FROM").Append(Environment.NewLine);
            sql.Append("         STOCKRF C,").Append(Environment.NewLine);
            sql.Append("         SALESHISTDTLRF D,").Append(Environment.NewLine);
            sql.Append("         GOODSURF E").Append(Environment.NewLine);
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            sql.Append("         LEFT JOIN BLGOODSCDURF F").Append(Environment.NewLine);
            sql.Append("         ON F.ENTERPRISECODERF = E.ENTERPRISECODERF").Append(Environment.NewLine);
            sql.Append("           AND F.BLGOODSCODERF = E.BLGOODSCODERF").Append(Environment.NewLine);
            sql.Append("         LEFT JOIN BLGROUPURF G").Append(Environment.NewLine);
            sql.Append("         ON G.ENTERPRISECODERF = F.ENTERPRISECODERF").Append(Environment.NewLine);
            sql.Append("           AND G.BLGROUPCODERF = F.BLGROUPCODERF").Append(Environment.NewLine);
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            sql.Append("     WHERE").Append(Environment.NewLine);
            sql.Append("            C.ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
            sql.Append("     AND C.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
            // ADD 2009/07/14 WUYX PVCS338------->>>>>
            // ����`�[�敪(����)
            sql.Append("     AND D.SALESSLIPCDDTLRF <> 2").Append(Environment.NewLine);
            // ADD 2009/07/14 WUYX PVCS338-------<<<<<
            //�J�n�q�ɃR�[�h
            if (paramWork.St_WarehouseCode != "")
            {
                sql.Append("     AND C.WAREHOUSECODERF >= @STWAREHOUSECODE").Append(Environment.NewLine);
            }
            //�I���q�ɃR�[�h
            if (paramWork.Ed_WarehouseCode != "")
            {
                sql.Append("     AND C.WAREHOUSECODERF <= @EDWAREHOUSECODE").Append(Environment.NewLine);
            }
            //�J�n���[�J�[�R�[�h
            if (paramWork.St_GoodsMakerCd != 0)
            {
                sql.Append("     AND C.GOODSMAKERCDRF >= @STGOODSMAKERCD").Append(Environment.NewLine);
            }
            //�I�����[�J�[�R�[�h
            if (paramWork.Ed_GoodsMakerCd != 0)
            {
                sql.Append("     AND C.GOODSMAKERCDRF <= @EDGOODSMAKERCD").Append(Environment.NewLine);
            }
            // �Ǘ��敪�P
            if (paramWork.ManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in paramWork.ManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    sql.Append(" AND C.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ");
                }
            }
            // �Ǘ��敪�Q
            if (paramWork.ManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in paramWork.ManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    sql.Append(" AND C.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ");
                }
            }
            sql.Append("     AND D.ENTERPRISECODERF = C.ENTERPRISECODERF").Append(Environment.NewLine);
            sql.Append("     AND D.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
            sql.Append("     AND D.ACPTANODRSTATUSRF = 30").Append(Environment.NewLine);
            // �݌ɏo�בΏۊJ�n��
            if (paramWork.StckShipMonthSt != 0)
            {
                sql.Append("     AND D.SALESDATERF >= @STSALESDATE").Append(Environment.NewLine);
            }
            // �݌ɏo�בΏۏI����
            if (paramWork.StckShipMonthSt != 0)
            {
                sql.Append("     AND D.SALESDATERF <= @EDSALESDATE").Append(Environment.NewLine);
            }
            // �W�v���@
            if (sumMethod == 1)
            {
                sql.Append("     AND D.SALESORDERDIVCDRF = 1").Append(Environment.NewLine);
                sql.Append("     AND D.WAREHOUSECODERF = C.WAREHOUSECODERF").Append(Environment.NewLine);
            }
            else
            {
                sql.Append("     AND D.WAREHOUSECODERF IS NULL").Append(Environment.NewLine);
            }
            // ------------------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            ////�J�n�d����R�[�h
            //if (paramWork.St_SupplierCd != 0)
            //{
            //    sql.Append("     AND D.SUPPLIERCDRF >= @STSUPPLIERCD").Append(Environment.NewLine);
            //}
            ////�I���d����R�[�h
            //if (paramWork.Ed_SupplierCd != 0)
            //{
            //    sql.Append("     AND D.SUPPLIERCDRF <= @EDSUPPLIERCD").Append(Environment.NewLine);
            //}
            // ------------------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            sql.Append("     AND D.GOODSMAKERCDRF = C.GOODSMAKERCDRF").Append(Environment.NewLine);
            //�J�n���i������
            if (paramWork.St_GoodsMGroup != 0)
            {
                //sql.Append("     AND D.GOODSMGROUPRF >= @STGOODSMGROUP").Append(Environment.NewLine);  // DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
                sql.Append("     AND G.GOODSMGROUPRF >= @STGOODSMGROUP").Append(Environment.NewLine);  // ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            }
            //�I�����i������
            if (paramWork.Ed_GoodsMGroup != 0)
            {
                //sql.Append("     AND D.GOODSMGROUPRF <= @EDGOODSMGROUP").Append(Environment.NewLine);  // DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
                sql.Append("     AND G.GOODSMGROUPRF <= @EDGOODSMGROUP").Append(Environment.NewLine);  // ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            }
            //�J�n�O���[�v�R�[�h
            if (paramWork.St_BLGroupCode != 0)
            {
                //sql.Append("     AND D.BLGROUPCODERF >= @STBLGROUPCODE").Append(Environment.NewLine);  // DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
                sql.Append("     AND F.BLGROUPCODERF >= @STBLGROUPCODE").Append(Environment.NewLine);  // ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            }
            //�I���O���[�v�R�[�h
            if (paramWork.Ed_BLGroupCode != 0)
            {
                //sql.Append("     AND D.BLGROUPCODERF <= @EDBLGROUPCODE").Append(Environment.NewLine);  // DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
                sql.Append("     AND F.BLGROUPCODERF <= @EDBLGROUPCODE").Append(Environment.NewLine);  // ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            }
            //�J�nBL���i�R�[�h
            if (paramWork.St_BLGoodsCode != 0)
            {
                //sql.Append("     AND D.BLGOODSCODERF >= @STBLGOODSCODE").Append(Environment.NewLine);  // DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
                sql.Append("     AND E.BLGOODSCODERF >= @STBLGOODSCODE").Append(Environment.NewLine);  // ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            }
            //�I��BL���i�R�[�h
            if (paramWork.Ed_BLGoodsCode != 0)
            {
                //sql.Append("     AND D.BLGOODSCODERF <= @EDBLGOODSCODE").Append(Environment.NewLine);  // DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
                sql.Append("     AND E.BLGOODSCODERF <= @EDBLGOODSCODE").Append(Environment.NewLine);  // ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            }
            sql.Append("     AND D.GOODSNORF = C.GOODSNORF").Append(Environment.NewLine);
            sql.Append("     AND E.ENTERPRISECODERF = C.ENTERPRISECODERF").Append(Environment.NewLine);
            sql.Append("     AND E.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
            sql.Append("     AND E.GOODSMAKERCDRF = C.GOODSMAKERCDRF").Append(Environment.NewLine);
            sql.Append("     AND E.GOODSNORF = C.GOODSNORF").Append(Environment.NewLine);
           // DEL 2009/07/15 WUYX PVCS339
            // sql.Append("     AND E.BLGOODSCODERF = D.BLGOODSCODERF").Append(Environment.NewLine);
            sql.Append("     GROUP BY").Append(Environment.NewLine);
            sql.Append("         C.WAREHOUSECODERF,").Append(Environment.NewLine);
            sql.Append("         D.WAREHOUSECODERF,").Append(Environment.NewLine);
            //sql.Append("         D.SUPPLIERCDRF,").Append(Environment.NewLine);  //DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C��
            sql.Append("         D.GOODSMAKERCDRF,").Append(Environment.NewLine);
            // ------------------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            //sql.Append("         D.GOODSMGROUPRF,").Append(Environment.NewLine);
            //sql.Append("         D.BLGROUPCODERF,").Append(Environment.NewLine);
            //sql.Append("         D.BLGOODSCODERF,").Append(Environment.NewLine);
            // ------------------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            sql.Append("         G.GOODSMGROUPRF,").Append(Environment.NewLine);
            sql.Append("         F.BLGROUPCODERF,").Append(Environment.NewLine);
            sql.Append("         E.BLGOODSCODERF,").Append(Environment.NewLine);
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            sql.Append("         D.GOODSNORF").Append(Environment.NewLine);

            return sql.ToString();
        }
        #endregion

        # region [Where���쐬����]
        /// <summary>
        /// ���������l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <returns/>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.17</br>
        /// <br>UpdateNote : Redmine#45978 �C�X�R�W���p�� ����q�ɓ��œ���i�Ԃ������󎚂����C��</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2015/06/03</br>
        private void MakeWhereSetValue(ref SqlCommand sqlCommand, ExtrInfo_OrderPointStSimulationWork paramWork)
        {
            StringBuilder whereSql = new StringBuilder();
            // ��ƃR�[�h
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            // �ݒ�R�[�h
            SqlParameter paraPatterno = sqlCommand.Parameters.Add("@PATTERNO", SqlDbType.Int);
            paraPatterno.Value = SqlDataMediator.SqlSetInt32(paramWork.SettingCode);

            //�J�n�q�ɃR�[�h
            if (paramWork.St_WarehouseCode != "")
            {
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.St_WarehouseCode);
            }

            //�I���q�ɃR�[�h
            if (paramWork.Ed_WarehouseCode != "")
            {
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.Ed_WarehouseCode);
            }

            // ------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------>>>>>
            ////�J�n�d����R�[�h
            //if (paramWork.St_SupplierCd != 0)
            //{
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.St_SupplierCd);
            //}

            ////�I���d����R�[�h
            //if (paramWork.Ed_SupplierCd != 0)
            //{
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_SupplierCd);
            //}
            // ------ DEL ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------<<<<<

            //�J�n���[�J�[�R�[�h
            if (paramWork.St_GoodsMakerCd != 0)
            {
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.St_GoodsMakerCd);
            }

            //�I�����[�J�[�R�[�h
            if (paramWork.Ed_GoodsMakerCd != 0)
            {
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_GoodsMakerCd);
            }

            //�J�nBL���i�R�[�h
            if (paramWork.St_BLGoodsCode != 0)
            {
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.St_BLGoodsCode);
            }
        
            //�I��BL���i�R�[�h
            if (paramWork.Ed_BLGoodsCode != 0)
            {
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_BLGoodsCode);
            }

            //�J�n�O���[�v�R�[�h
            if (paramWork.St_BLGroupCode != 0)
            {
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.St_BLGroupCode);
            }
            //�I���O���[�v�R�[�h
            if (paramWork.Ed_BLGroupCode != 0)
            {
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_BLGroupCode);
            }

            //�J�n���i������
            if (paramWork.St_GoodsMGroup != 0)
            {
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(paramWork.St_GoodsMGroup);
            }
            //�I�����i������
            if (paramWork.Ed_GoodsMGroup != 0)
            {
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_GoodsMGroup);
            }

            // �݌ɏo�בΏۊJ�n��
            if (paramWork.StckShipMonthSt != 0)
            {
                SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                paraStSalesDate.Value = SqlDataMediator.SqlSetInt32(paramWork.StckShipMonthSt);
            }
            // �݌ɏo�בΏۏI����
            if (paramWork.StckShipMonthEd != 0)
            {
                SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                paraEdSalesDate.Value = SqlDataMediator.SqlSetInt32(paramWork.StckShipMonthEd);
            }

            return;
        }
        # endregion

        # region [�\�[�g���쐬����]
        /// <summary>
        /// �\�[�g���ݒ�
        /// </summary>
        /// <param name="paramWork">���������i�[�N���X</param>
        /// <returns>�\�[�g��������</returns>
        /// <br>Note       : �\�[�g�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.17</br>
        private string MakeOrderString(ExtrInfo_OrderPointStSimulationWork paramWork)
        {
            StringBuilder orderSql = new StringBuilder();
            orderSql.Append(" ORDER BY").Append(Environment.NewLine);
            switch (paramWork.OutPutDiv)
            {
                case 0:
                    // �i�ԏ�
                    orderSql.Append("     B.WAREHOUSECODERF,").Append(Environment.NewLine);
                    orderSql.Append("     B.SUPPLIERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.GOODSMGROUPRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.BLGROUPCODERF,").Append(Environment.NewLine);
                    orderSql.Append("     A.BLGOODSCODERF,").Append(Environment.NewLine);
                    orderSql.Append("     J.GOODSNORF").Append(Environment.NewLine);
                    break;
                case 1:
                    // �I�ԏ�
                    orderSql.Append("     B.WAREHOUSECODERF,").Append(Environment.NewLine);
                    orderSql.Append("     J.WAREHOUSESHELFNORF,").Append(Environment.NewLine);
                    orderSql.Append("     B.SUPPLIERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.GOODSMGROUPRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.BLGROUPCODERF,").Append(Environment.NewLine);
                    orderSql.Append("     A.BLGOODSCODERF,").Append(Environment.NewLine);
                    orderSql.Append("     J.GOODSNORF").Append(Environment.NewLine);
                    break;
                case 2:
                    // ���[�J�[�E�i�ԏ�
                    orderSql.Append("     B.WAREHOUSECODERF,").Append(Environment.NewLine);
                    orderSql.Append("     B.SUPPLIERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     J.GOODSNORF").Append(Environment.NewLine);
                    break;
                case 3:
                    // ���[�J�[�E�I�ԏ�
                    orderSql.Append("     B.WAREHOUSECODERF,").Append(Environment.NewLine);
                    orderSql.Append("     A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                    orderSql.Append("     J.WAREHOUSESHELFNORF,").Append(Environment.NewLine);
                    orderSql.Append("     B.SUPPLIERCDRF").Append(Environment.NewLine);
                    break;
            }

            return orderSql.ToString();
        }
        # endregion

        #region �N���X�i�[����
        /// <summary>
        /// �N���X�i�[���� Reader �� OrderPointStSimulationWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>OrderPointStSimulationWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.17</br>
        /// </remarks>
        private OrderPointStSimulationWork CopyToOrderPointStSimulationWorkFromReader(ref SqlDataReader myReader, ExtrInfo_OrderPointStSimulationWork paramWork)
        {
            OrderPointStSimulationWork work = new OrderPointStSimulationWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                work.PatterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNORF"));
                work.PatternNoDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PATTERNNODERIVEDNORF"));
                work.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                work.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                work.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                work.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                work.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                work.SupplierNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                work.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                work.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                work.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                work.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                work.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                work.NowPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                work.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                work.OldMinCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("OLDMINCNT"));
                work.OldMaxCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("OLDMAXCNT"));
                work.NewMinCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWMINCNT"));
                work.NewMaxCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWMAXCNT"));
                work.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                # endregion
            }

            return work;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.17</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader)
        {
            StockWork work = new StockWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                work.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("STOCK_CREATEDATETIMERF"));
                work.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("STOCK_UPDATEDATETIMERF"));
                work.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_ENTERPRISECODERF"));
                work.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("STOCK_FILEHEADERGUIDRF"));
                work.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_UPDEMPLOYEECODERF"));
                work.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_UPDASSEMBLYID1RF"));
                work.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_UPDASSEMBLYID2RF"));
                work.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_LOGICALDELETECODERF"));
                work.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_SECTIONCODERF"));
                work.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_WAREHOUSECODERF"));
                work.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_GOODSMAKERCDRF"));
                work.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_GOODSNORF"));
                work.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_STOCKUNITPRICEFLRF"));
                work.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_SUPPLIERSTOCKRF"));
                work.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_ACPODRCOUNTRF"));
                work.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_MONTHORDERCOUNTRF"));
                work.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_SALESORDERCOUNTRF"));
                work.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_STOCKDIVRF"));
                work.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_MOVINGSUPLISTOCKRF"));
                work.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_SHIPMENTPOSCNTRF"));
                work.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCK_STOCKTOTALPRICERF"));
                work.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTSTOCKDATERF"));
                work.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTSALESDATERF"));
                work.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTINVENTORYUPDATERF"));
                work.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWMINCNT"));
                work.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWMAXCNT"));
                work.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_NMLSALODRCOUNTRF"));
                work.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_SALESORDERUNITRF"));
                work.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_STOCKSUPPLIERCODERF"));
                work.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_GOODSNONONEHYPHENRF"));
                work.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_WAREHOUSESHELFNORF"));
                work.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_DUPLICATIONSHELFNO1RF"));
                work.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_DUPLICATIONSHELFNO2RF"));
                work.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_PARTSMANAGEMENTDIVIDE1RF"));
                work.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_PARTSMANAGEMENTDIVIDE2RF"));
                work.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_STOCKNOTE1RF"));
                work.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_STOCKNOTE2RF"));
                work.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_SHIPMENTCNTRF"));
                work.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCK_ARRIVALCNTRF"));
                work.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_STOCKCREATEDATERF"));
                work.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_UPDATEDATERF"));
                # endregion
            }

            return work;
        }
        #endregion

        #region �݌Ƀ}�X�^�̍X�V����
        /// <summary>
        /// �݌Ƀ}�X�^�̍X�V����
        /// </summary>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="orderPointStWorkList">OrderPointStWork�I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.27</br>
        public int Write(ref object stockWorkList, ref object orderPointStWorkList, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            StockDB stockDB = new StockDB();
            OrderPointStDB orderPointStDB = new OrderPointStDB();
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �����_�ݒ�}�X�^�̍X�V����
                status = orderPointStDB.Write(ref orderPointStWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �݌Ƀ}�X�^�X�V
                    ArrayList updStockWorkList = stockWorkList as ArrayList;
                    status = stockDB.WriteStockProc(ref updStockWorkList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointStSimulationDB.StockWrite");
                retMsg = ex.Message;
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
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
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
        #endregion  //�R�l�N�V������������
    }

}
