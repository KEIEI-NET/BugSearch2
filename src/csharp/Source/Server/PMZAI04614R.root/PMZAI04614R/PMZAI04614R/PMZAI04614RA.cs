//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q���� �����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��r��
// �� �� ��  2011/05/20  �C�����e : Redmine#21657 �d����Ǝd���於��ǉ����܂�
//----------------------------------------------------------------------------//
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
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɉړ��d�q���� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q���� �����[�g�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// </remarks>
    [Serializable]
    public class StockMoveWorkDB : RemoteDB, IStockMoveWorkDB
    {
        /// <summary>
        /// �݌Ɉړ��d�q���� �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        public StockMoveWorkDB()
            :
            base("PMZAI04616D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork", "STOCKMOVERF")
        {
        }

        #region [���ו\������]

        #region [SearchRef]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="stockMoveWork">��������(����f�[�^)</param>
        /// <param name="stockMovePrtWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: </br>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������\���̃��X�g�𒊏o���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 ��r�� �d����Ǝd���於��ǉ����܂�</br>
        /// </remarks>
        public int SearchRef(ref object stockMoveWork, object stockMovePrtWork, out Int64 recordCount, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //������
            recordCount = 0;
            Int64 iRecCnt = 0;
            stockMoveWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (stockMovePrtWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�����p�����[�^
                StockMovePrtWork _stockMovePrtWork = stockMovePrtWork as StockMovePrtWork;
                ArrayList stockMoveWorkArray = stockMoveWork as ArrayList;
                if (stockMoveWorkArray == null)
                {
                    stockMoveWorkArray = new ArrayList();
                }
                #endregion

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Search���s
                #region [�݌Ɉړ��f�[�^����]

                //�݌Ɉړ��f�[�^����
                status = SearchRefProc(ref stockMoveWorkArray, _stockMovePrtWork, out recordCount, iRecCnt, readMode, logicalMode, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //���s���G���[
                    throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                }
                #endregion

                //���s���ʃZ�b�g
                stockMoveWork = stockMoveWorkArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveWorkDB.SearchProc Exception=" + ex.Message);
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

            return status;
        }
        #endregion  //[SearchRef]

        #region [SearchRefProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������\���f�[�^�̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="rsltWorkArray">��������(����f�[�^)</param>
        /// <param name="_stockMovePrtWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)�߂�l�p</param>
        /// <param name="iRecCnt">��������(����)�����`�F�b�N�p</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br></br>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������\���f�[�^�̃��X�g�𒊏o���܂��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        private int SearchRefProc(ref ArrayList rsltWorkArray, StockMovePrtWork _stockMovePrtWork, out Int64 recordCount, Int64 iRecCnt, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = MakeSelectString(ref sqlCommand, _stockMovePrtWork, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                //�����`�F�b�N
                while (myReader.Read())
                {
                    object retWork = CopyToResultWorkFromReaderProc(ref myReader, _stockMovePrtWork);
                    if (retWork != null)
                    {
                        rsltWorkArray.Add(retWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        iRecCnt++;
                        if (iRecCnt >= _stockMovePrtWork.SearchCnt)
                        {
                            //��������I�[�o�[�̏ꍇ��Break
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            recordCount = iRecCnt;
                            break;
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveWorkDB.SearchRefProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
            }
            recordCount = iRecCnt;

            return status;
        }
        #endregion  //[SearchRefProc]

        #endregion  //���ו\������]

        #region [StockMoveWork�p SELECT��]
        /// <summary>
        /// ���X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>���X�g���oSELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���X�g���o�N�G���쐬�B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            StockMovePrtWork _ctockMoveWork = paramWork as StockMovePrtWork;
            string selectTxt = "";

            // �Ώۃe�[�u��
            // STOCKMOVERF  STOCK  �݌Ɉړ��f�[�^
            #region [Select���쐬]
            selectTxt += "  SELECT TOP " + _ctockMoveWork.SearchCnt + Environment.NewLine; // ������������𒴂���܂Ŏ擾
            selectTxt += "STOCK.STOCKMOVEFORMALRF" + Environment.NewLine;        // �݌Ɉړ��`��
            selectTxt += " ,STOCK.STOCKMOVESLIPNORF" + Environment.NewLine;        // �݌Ɉړ��`�[�ԍ�
            selectTxt += " ,STOCK.STOCKMOVEROWNORF" + Environment.NewLine;         // �݌Ɉړ��s�ԍ�
            selectTxt += " ,STOCK.UPDATESECCDRF" + Environment.NewLine;            // �X�V���_�R�[�h
            selectTxt += " ,STOCK.BFSECTIONCODERF" + Environment.NewLine;          // �ړ������_�R�[�h
            selectTxt += " ,STOCK.BFSECTIONGUIDESNMRF" + Environment.NewLine;      // �ړ������_�K�C�h����
            selectTxt += " ,STOCK.BFENTERWAREHCODERF" + Environment.NewLine;       // �ړ����q�ɃR�[�h
            selectTxt += " ,STOCK.BFENTERWAREHNAMERF" + Environment.NewLine;       // �ړ����q�ɖ���
            selectTxt += " ,STOCK.AFSECTIONCODERF" + Environment.NewLine;          // �ړ��拒�_�R�[�h
            selectTxt += " ,STOCK.AFSECTIONGUIDESNMRF" + Environment.NewLine;      // �ړ��拒�_�K�C�h����
            selectTxt += " ,STOCK.AFENTERWAREHCODERF" + Environment.NewLine;       // �ړ���q�ɃR�[�h
            selectTxt += " ,STOCK.AFENTERWAREHNAMERF" + Environment.NewLine;       // �ړ���q�ɖ���
            selectTxt += " ,STOCK.SHIPMENTFIXDAYRF" + Environment.NewLine;         // �o�׊m���
            selectTxt += " ,STOCK.ARRIVALGOODSDAYRF" + Environment.NewLine;        // ���ד�
            selectTxt += " ,STOCK.INPUTDAYRF" + Environment.NewLine;               // ���͓�
            selectTxt += " ,STOCK.MOVESTATUSRF" + Environment.NewLine;             // �ړ����
            selectTxt += " ,STOCK.STOCKMVEMPNAMERF" + Environment.NewLine;         // �݌Ɉړ����͏]�ƈ�����
            selectTxt += " ,STOCK.RECEIVEAGENTNMRF" + Environment.NewLine;         // ����S���]�ƈ�����
            selectTxt += " ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;           // ���i���[�J�[�R�[�h
            selectTxt += " ,STOCK.MAKERNAMERF" + Environment.NewLine;              // ���[�J�[����
            selectTxt += " ,STOCK.GOODSNORF" + Environment.NewLine;                // ���i�ԍ�
            selectTxt += " ,STOCK.GOODSNAMERF" + Environment.NewLine;              // ���i����
            selectTxt += " ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;       // �d���P���i�Ŕ�,�����j
            selectTxt += " ,STOCK.MOVECOUNTRF" + Environment.NewLine;              // �ړ���
            selectTxt += " ,STOCK.BFSHELFNORF" + Environment.NewLine;              // �ړ����I��
            selectTxt += " ,STOCK.AFSHELFNORF" + Environment.NewLine;              // �ړ���I��
            selectTxt += " ,STOCK.BLGOODSCODERF" + Environment.NewLine;            // BL���i�R�[�h
            selectTxt += " ,STOCK.LISTPRICEFLRF" + Environment.NewLine;            // �艿�i�����j
            selectTxt += " ,STOCK.OUTLINERF" + Environment.NewLine;                // �`�[�E�v
            selectTxt += " ,STOCK.STOCKMOVEPRICERF" + Environment.NewLine;         // �ړ����z
            // ADD 2011/05/20 -------------------->>>>>>
            selectTxt += " ,STOCK.SUPPLIERCDRF" + Environment.NewLine;           // �d����R�[�h
            selectTxt += " ,STOCK.SUPPLIERSNMRF" + Environment.NewLine;              // �d���於
            // ADD 2011/05/20 --------------------<<<<<<
            selectTxt += " ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;           // ���_�K�C�h����
            selectTxt += " FROM STOCKMOVERF AS STOCK  WITH (READUNCOMMITTED) " + Environment.NewLine;
            // ���_���ݒ�}�X�^.���_�K�C�h���̂��擾����
            selectTxt += " LEFT JOIN  SECINFOSETRF AS SEC" + Environment.NewLine;
            selectTxt += " ON " + Environment.NewLine;
            selectTxt += " STOCK.ENTERPRISECODERF = SEC.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND STOCK.UPDATESECCDRF = SEC.SECTIONCODERF " + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //WHERE���̍쐬
            selectTxt += MakeWhereString(ref sqlCommand, _ctockMoveWork, logicalMode);

            selectTxt += "  ORDER BY  " + Environment.NewLine;
            // ���o��/�`�[���t,�ړ��`�[�ԍ�
            if (_ctockMoveWork.StockMoveFixCode == 1)
            {
                if (_ctockMoveWork.OutputDiv == 0 || _ctockMoveWork.OutputDiv == 2)
                {
                    selectTxt += " SHIPMENTFIXDAYRF ASC" + Environment.NewLine;
                }
                else
                {
                    selectTxt += " ARRIVALGOODSDAYRF ASC" + Environment.NewLine;
                }
            }
            else
            {
                selectTxt += " ARRIVALGOODSDAYRF ASC" + Environment.NewLine;
            }
            selectTxt += " , STOCKMOVESLIPNORF ASC" + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion

        #region [StockMoveWork�p WHERE����������]
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMovePrtWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //����`�[�ԍ�
            if (paramWork.SalesSlipNum != "")
            {
                retstring += " AND STOCK.STOCKMOVESLIPNORF >=@FINDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.SalesSlipNum);
            }

            //���͓��t(�`�[�������t)
            if (paramWork.St_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND STOCK.INPUTDAYRF>=@STSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraStAddUpADate = sqlCommand.Parameters.Add("@STSEARCHSLIPDATE", SqlDbType.Int);
                paraStAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_AddUpADate);
            }
            if (paramWork.Ed_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND STOCK.INPUTDAYRF<=@EDSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraEdAddUpADate = sqlCommand.Parameters.Add("@EDSEARCHSLIPDATE", SqlDbType.Int);
                paraEdAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_AddUpADate);
            }

            //�d����(�d����R�[�h)
            if (paramWork.SupplierCd != 0)
            {
                retstring += " AND STOCK.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //�i��(���i����) �������܂���������
            if (paramWork.GoodsName != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsName, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND STOCK.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;

                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STOCK.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
                }
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(paramWork.GoodsName);
            }

            //�i��(���i�ԍ�) �������܂���������
            if (paramWork.GoodsNo != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsNo, "(%)").Success == true)
                {
                    //�����܂�����
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND STOCK.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE (STOCK.GOODSNORF, '-', '') LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                }
                else
                {
                    //�����܂���������Ȃ�
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND STOCK.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE (STOCK.GOODSNORF, '-', '') = @FINDGOODSNO" + Environment.NewLine;
                    }
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //���[�J�[(���i���[�J�[�R�[�h)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //�a�k�R�[�h(BL���i�R�[�h)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring += " AND STOCK.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCode);
            }

            //���ה��l �������܂���������
            if (paramWork.SlipNote != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote, "(%)").Success == true)
                {
                    retstring += " AND STOCK.OUTLINERF LIKE @FINDDTLNOTE" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STOCK.OUTLINERF=@FINDDTLNOTE" + Environment.NewLine;
                }
                SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@FINDDTLNOTE", SqlDbType.NVarChar);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote);
            }

            // �o�͋敪�̏ꍇ
            if (paramWork.StockMoveFixCode == 1)
            {
                // �݌Ɉړ��`��
                retstring += " AND (STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL1" + Environment.NewLine;
                retstring += " OR STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL2)" + Environment.NewLine;
                SqlParameter paraStockMoveFormal1 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL1", SqlDbType.Int);
                SqlParameter paraStockMoveFormal2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                if (paramWork.OutputDiv == 0)
                {
                    // �o�ו�
                    paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(1);
                    paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(2);

                    // �ړ������_�R�[�h
                    if (!string.IsNullOrEmpty(paramWork.SectionCode))
                    {
                        retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                        // �o�ו� �o�ɋ��_
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    }

                    // �ړ����q�ɃR�[�h
                    if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                    {
                        retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                        // �o�ɑq��
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                    }

                    // �ړ��拒�_�R�[�h
                    if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                    {
                        retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                        //����q��
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                    }
                    // �ړ���q�ɃR�[�h
                    if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                    {
                        retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                        //����q��
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                    }
                    // �o�׊m���
                    if (paramWork.St_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                        SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                        //���o�ד�(�J�n)
                        paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                    }
                    if (paramWork.Ed_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                        SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                        //���o�ד�(�I��)
                        paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                    }
                    // ���׋敪arrivalGoodsFlag
                    if (paramWork.ArrivalGoodsFlag != 0)
                    {
                        retstring += " AND STOCK.MOVESTATUSRF =@FINDMOVESTATUS" + Environment.NewLine;
                        SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@FINDMOVESTATUS", SqlDbType.Int);
                        // �ړ����
                        if (paramWork.ArrivalGoodsFlag == 1)
                        {
                            paraMoveStatus.Value = SqlDataMediator.SqlSetInt(9);
                        }
                        else
                        {
                            paraMoveStatus.Value = SqlDataMediator.SqlSetInt(2);
                        }
                    }
                    // �݌Ɉړ����͏]�ƈ��R�[�h
                    if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                    {
                        retstring += " AND STOCK.STOCKMVEMPCODERF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                        //����q��
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                    }

                    // �I�� �ړ����I��
                    if (paramWork.WarehouseShelfNo != string.Empty)
                    {
                        //�����܂��������ǂ������`�F�b�N
                        if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                        {
                            //�����܂�����
                            retstring += " AND STOCK.BFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        else
                        {
                            //�����܂���������Ȃ�
                            retstring += " AND STOCK.BFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                    }
                }
                else if (paramWork.OutputDiv == 1)
                {
                    // ���׍ϕ�
                    paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(3);
                    paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(4);

                    // �ړ������_�R�[�h
                    if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                    {
                        retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                        // ���苒�_
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                    }

                    // �ړ����q�ɃR�[�h
                    if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                    {
                        retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                        //����q��
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                    }
                    // �ړ��拒�_�R�[�h
                    if (!string.IsNullOrEmpty(paramWork.SectionCode))
                    {
                        retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                        //���ɋ��_
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    }
                    // �ړ���q�ɃR�[�h
                    if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                    {
                        retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                        //���ɑq��
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                    }
                    // ���ד�
                    if (paramWork.St_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.ARRIVALGOODSDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                        SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                        //���o�ד�(�J�n)
                        paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                    }
                    if (paramWork.Ed_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.ARRIVALGOODSDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                        SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                        //���o�ד�(�I��)
                        paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                    }
                    // ����S���]�ƈ��R�[�h
                    if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                    {
                        retstring += " AND STOCK.RECEIVEAGENTCDRF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                        // �S����
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                    }
                    // �I�� �ړ���I��
                    if (paramWork.WarehouseShelfNo != string.Empty)
                    {
                        //�����܂��������ǂ������`�F�b�N
                        if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                        {
                            //�����܂�����
                            retstring += " AND STOCK.AFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        else
                        {
                            //�����܂���������Ȃ�
                            retstring += " AND STOCK.AFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                    }
                }
                else
                {
                    //�����ו�
                    paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(1);
                    paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(2);

                    // �ړ������_�R�[�h
                    if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                    {
                        retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                        // ���苒�_
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                    }

                    // �ړ����q�ɃR�[�h
                    if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                    {
                        retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                        //����q��
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                    }

                    // �ړ��拒�_�R�[�h
                    if (!string.IsNullOrEmpty(paramWork.SectionCode))
                    {
                        retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                        //���ɋ��_
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    }
                    // �ړ���q�ɃR�[�h
                    if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                    {
                        retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                        //���ɑq��
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                    }
                    // �o�׊m���
                    if (paramWork.St_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                        SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                        //���o�ד�(�J�n)
                        paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                    }
                    if (paramWork.Ed_Date != DateTime.MinValue)
                    {
                        retstring += " AND STOCK.SHIPMENTFIXDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                        SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                        //���o�ד�(�I��)
                        paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                    }
                    // ���׋敪
                    retstring += " AND STOCK.MOVESTATUSRF =@FINDMOVESTATUS" + Environment.NewLine;
                    SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@FINDMOVESTATUS", SqlDbType.Int);
                    //���o�ד�(�I��)
                    paraMoveStatus.Value = SqlDataMediator.SqlSetInt(2);

                    // �݌Ɉړ����͏]�ƈ��R�[�h
                    if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                    {
                        retstring += " AND STOCK.STOCKMVEMPCODERF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                        //�S����
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                    }

                    // �I�� �ړ���I��
                    if (paramWork.WarehouseShelfNo != string.Empty)
                    {
                        //�����܂��������ǂ������`�F�b�N
                        if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                        {
                            //�����܂�����
                            retstring += " AND STOCK.AFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        else
                        {
                            //�����܂���������Ȃ�
                            retstring += " AND STOCK.AFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                        }
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                    }
                }
            }
            // �`�[�敪�̏ꍇ
            else
            {
                // �X�V���_�R�[�h
                if (!string.IsNullOrEmpty(paramWork.InputSectionCode))
                {
                    retstring += " AND STOCK.UPDATESECCDRF=@FINDUPDATESECCD" + Environment.NewLine;
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@FINDUPDATESECCD", SqlDbType.NChar);
                    // ���͋��_
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paramWork.InputSectionCode);
                }

                // ���ד�
                if (paramWork.St_Date != DateTime.MinValue)
                {
                    retstring += " AND STOCK.ARRIVALGOODSDAYRF>=@FINDSHIPMENTFIXDAYST" + Environment.NewLine;
                    SqlParameter paraShipmentFixDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYST", SqlDbType.Int);
                    //���o�ד�(�J�n)
                    paraShipmentFixDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_Date);
                }
                if (paramWork.Ed_Date != DateTime.MinValue)
                {
                    retstring += " AND STOCK.ARRIVALGOODSDAYRF<=@FINDSHIPMENTFIXDAYED" + Environment.NewLine;
                    SqlParameter paraShipmentFixDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTFIXDAYED", SqlDbType.Int);
                    //���o�ד�(�I��)
                    paraShipmentFixDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_Date);
                }

                // �݌Ɉړ����͏]�ƈ��R�[�h
                if (!string.IsNullOrEmpty(paramWork.SalesEmployeeCd))
                {
                    retstring += " AND STOCK.STOCKMVEMPCODERF=@FINDSTOCKMVEMPCODE" + Environment.NewLine;
                    SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@FINDSTOCKMVEMPCODE", SqlDbType.NChar);
                    // �S����
                    paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
                }

                // �݌Ɉړ��`��
                if (paramWork.SalesSlipDiv != 0)
                {
                    retstring += " AND (STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL1" + Environment.NewLine;
                    retstring += " OR STOCK.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL2)" + Environment.NewLine;
                    SqlParameter paraStockMoveFormal1 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL1", SqlDbType.Int);
                    SqlParameter paraStockMoveFormal2 = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL2", SqlDbType.Int);
                    if (paramWork.SalesSlipDiv == 1)
                    {
                        // �o��
                        paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(1);
                        paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(2);

                        //�ړ������_�R�[�h
                        if (!string.IsNullOrEmpty(paramWork.SectionCode))
                        {
                            retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                            // �o�ɋ��_
                            paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                        }
                        //�ړ����q�ɃR�[�h
                        if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                        {
                            retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                            // �o�ɑq��
                            paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                        }
                        // �ړ��拒�_�R�[�h
                        if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                        {
                            retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                            //����q��
                            paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                        }
                        // �ړ���q�ɃR�[�h
                        if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                        {
                            retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                            //����q��
                            paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                        }
                        // �I�� �ړ����I��
                        if (paramWork.WarehouseShelfNo != string.Empty)
                        {
                            //�����܂��������ǂ������`�F�b�N
                            if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                            {
                                //�����܂�����
                                retstring += " AND STOCK.BFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            else
                            {
                                //�����܂���������Ȃ�
                                retstring += " AND STOCK.BFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                        }
                    }
                    else
                    {
                        // ����
                        paraStockMoveFormal1.Value = SqlDataMediator.SqlSetInt(3);
                        paraStockMoveFormal2.Value = SqlDataMediator.SqlSetInt(4);

                        //�ړ������_�R�[�h
                        if (!string.IsNullOrEmpty(paramWork.AfSectionCode))
                        {
                            retstring += " AND STOCK.BFSECTIONCODERF=@FINDBFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@FINDBFSECTIONCODE", SqlDbType.NChar);
                            // ���苒�_
                            paraBfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.AfSectionCode);
                        }
                        // �ړ����q�ɃR�[�h
                        if (!string.IsNullOrEmpty(paramWork.AfEnterWarehCode))
                        {
                            retstring += " AND STOCK.BFENTERWAREHCODERF=@FINDBFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@FINDBFENTERWAREHCODE", SqlDbType.NChar);
                            // ����q��
                            paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.AfEnterWarehCode);
                        }
                        // �ړ��拒�_�R�[�h
                        if (!string.IsNullOrEmpty(paramWork.SectionCode))
                        {
                            retstring += " AND STOCK.AFSECTIONCODERF=@FINDAFSECTIONCODE" + Environment.NewLine;
                            SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@FINDAFSECTIONCODE", SqlDbType.NChar);
                            // ���ɋ��_
                            paraAfSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                        }
                        // �ړ���q�ɃR�[�h
                        if (!string.IsNullOrEmpty(paramWork.WarehouseCode))
                        {
                            retstring += " AND STOCK.AFENTERWAREHCODERF=@FINDAFENTERWAREHCODE" + Environment.NewLine;
                            SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@FINDAFENTERWAREHCODE", SqlDbType.NChar);
                            // ���ɑq��
                            paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                        }
                        // �I�� �ړ���I��
                        if (paramWork.WarehouseShelfNo != string.Empty)
                        {
                            //�����܂��������ǂ������`�F�b�N
                            if (System.Text.RegularExpressions.Regex.Match(paramWork.WarehouseShelfNo, "(%)").Success == true)
                            {
                                //�����܂�����
                                retstring += " AND STOCK.AFSHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            else
                            {
                                //�����܂���������Ȃ�
                                retstring += " AND STOCK.AFSHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                            }
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseShelfNo);
                        }

                    }
                }

            }
            #endregion

            return retstring;
        }
        #endregion

        #region [StockMoveWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockMoveWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprBlnceWork</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[���� Reader �� StockMoveWork�B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 ��r�� �d����Ǝd���於��ǉ����܂�</br>
        /// </remarks>
        private StockMoveWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, StockMovePrtWork paramWork)
        {
            #region ���o����-�l�Z�b�g
            StockMoveWork resultWork = new StockMoveWork();

            resultWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
            resultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            resultWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            resultWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF")).Trim();
            resultWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF")).Trim();
            resultWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
            resultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF")).Trim();
            resultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            resultWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF")).Trim();
            resultWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
            resultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF")).Trim();
            resultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            resultWork.ShipmentFixDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            resultWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            resultWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            resultWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
            resultWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            resultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            resultWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            resultWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            resultWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            resultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
            resultWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            resultWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
            resultWork.UpdateSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            // ADD 2011/05/20 ------------------------->>>>>>
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            // ADD 2011/05/20 -------------------------<<<<<<
            #endregion

            return resultWork;
        }
        #endregion
    }
}