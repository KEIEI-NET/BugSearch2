//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/18  �C�����e : Redmine#23746
//                                  �Ⴄ��ƃR�[�h�Ԃ̑���M�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : dingjx
// �C �� ��  2011/11/01 �C�����e :  Redmine#26228���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �e�c ���V
// �C �� ��  2014/03/26  �C�����e : �d�|�ꗗ��2292�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɉړ��f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockMoveDB : RemoteDB
    {
        /// <summary>
        /// �݌Ɉړ��f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockMoveDB()
            : base("PMKYO07601D", "Broadleaf.Application.Remoting.ParamData.DCStockMoveWork", "STOCKMOVERF")
        {

        }

        # region [Read]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�擾
        /// </summary>
        /// <param name="stockMoveList">�݌ɒ����f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList stockMoveList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockMoveList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�擾
        /// </summary>
        /// <param name="stockMoveList">�݌ɒ����f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockMoveList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockMoveList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //  ADD dingjx  2011/11/01  ------------------------------------->>>>>>
            if ((receiveDataWork.Kind == 0) && (receiveDataWork.SndLogExtraCondDiv == 1))
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WITH (READUNCOMMITTED) WHERE ARRIVALGOODSDAYRF>=@FINDUPDATESTARTDATETIME AND ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME AND  UPDATESECCDRF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE"; // DEL 2011/11/30
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WITH (READUNCOMMITTED) WHERE ((ARRIVALGOODSDAYRF>=@FINDUPDATESTARTDATETIME AND ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>=@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME)) AND  UPDATESECCDRF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // ADD 2011/11/30
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WITH (READUNCOMMITTED) WHERE ((ARRIVALGOODSDAYRF>=@FINDUPDATESTARTDATETIME AND ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME) OR (UPDATEDATETIMERF>@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME)) AND  UPDATESECCDRF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
            else
            //  ADD dingjx  2011/11/01  ------------------------------------->>>>>>
			    // UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			    //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF FROM STOCKMOVERF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND  UPDATESECCDRF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			    // UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);// ADD 2011/08/18 ���仁@Redmine#23746
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 ���仁@Redmine#23746
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = receiveDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                findParaEndTime.Value = receiveDataWork.EndDateTimeTicks;
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

            // SQL��
			sqlCommand.CommandText = sqlText;

            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                stockMoveList.Add(this.CopyToStockMoveWorkFromReader(ref myReader));
            }

            if (stockMoveList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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

            return status;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� stockAdjustDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockMoveWork CopyToStockMoveWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockMoveWork stockMoveWork = new DCStockMoveWork();

            this.CopyToStockMoveWorkFromReader(ref myReader, ref stockMoveWork);

            return stockMoveWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� stockMoveWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockMoveWork">stockMoveWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToStockMoveWorkFromReader(ref SqlDataReader myReader, ref DCStockMoveWork stockMoveWork)
        {
            if (myReader != null && stockMoveWork != null)
            {
                # region �N���X�֊i�[
                stockMoveWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                stockMoveWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                stockMoveWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                stockMoveWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                stockMoveWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                stockMoveWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                stockMoveWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                stockMoveWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                stockMoveWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
                stockMoveWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
                stockMoveWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
                stockMoveWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                stockMoveWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                stockMoveWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                stockMoveWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                stockMoveWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                stockMoveWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                stockMoveWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
                stockMoveWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                stockMoveWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                stockMoveWork.ShipmentScdlDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
                stockMoveWork.ShipmentFixDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
                stockMoveWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                stockMoveWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                stockMoveWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
                stockMoveWork.StockMvEmpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
                stockMoveWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
                stockMoveWork.ShipAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTCDRF"));
                stockMoveWork.ShipAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTNMRF"));
                stockMoveWork.ReceiveAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTCDRF"));
                stockMoveWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
                stockMoveWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                stockMoveWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                stockMoveWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                stockMoveWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                stockMoveWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                stockMoveWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                stockMoveWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                stockMoveWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                stockMoveWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                stockMoveWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                stockMoveWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                stockMoveWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                stockMoveWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
                stockMoveWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                stockMoveWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                stockMoveWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                stockMoveWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                stockMoveWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                stockMoveWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                stockMoveWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌Ɉړ��f�[�^�폜
        /// </summary>
        /// <param name="dcStockMoveWorkList">�݌Ɉړ��f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockMoveWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌Ɉړ��f�[�^�폜
        /// </summary>
        /// <param name="dcStockMoveWorkList">�݌Ɉړ��f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockMoveWork dcStockMoveWork in dcStockMoveWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcStockMoveWork.EnterpriseCode;
                findParaStockMoveFormal.Value = dcStockMoveWork.StockMoveFormal;
                findParaStockMoveSlipNo.Value = dcStockMoveWork.StockMoveSlipNo;
				findParaStockMoveRowNo.Value = dcStockMoveWork.StockMoveRowNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �݌Ɉړ��f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌Ɉړ��f�[�^�o�^
        /// </summary>
        /// <param name="dcStockMoveWorkList">�݌Ɉړ��f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockMoveWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌Ɉړ��f�[�^�o�^
        /// </summary>
        /// <param name="dcStockMoveWorkList">�݌Ɉړ��f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockMoveWork dcStockMoveWork in dcStockMoveWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Insert�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO STOCKMOVERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, STOCKMOVEFORMALRF, STOCKMOVESLIPNORF, STOCKMOVEROWNORF, UPDATESECCDRF, BFSECTIONCODERF, BFSECTIONGUIDESNMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, AFSECTIONCODERF, AFSECTIONGUIDESNMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, SHIPMENTSCDLDAYRF, SHIPMENTFIXDAYRF, ARRIVALGOODSDAYRF, INPUTDAYRF, MOVESTATUSRF, STOCKMVEMPCODERF, STOCKMVEMPNAMERF, SHIPAGENTCDRF, SHIPAGENTNMRF, RECEIVEAGENTCDRF, RECEIVEAGENTNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, STOCKDIVRF, STOCKUNITPRICEFLRF, TAXATIONDIVCDRF, MOVECOUNTRF, BFSHELFNORF, AFSHELFNORF, BLGOODSCODERF, BLGOODSFULLNAMERF, LISTPRICEFLRF, OUTLINERF, WAREHOUSENOTE1RF, SLIPPRINTFINISHCDRF, STOCKMOVEPRICERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @STOCKMOVEFORMAL, @STOCKMOVESLIPNO, @STOCKMOVEROWNO, @UPDATESECCD, @BFSECTIONCODE, @BFSECTIONGUIDESNM, @BFENTERWAREHCODE, @BFENTERWAREHNAME, @AFSECTIONCODE, @AFSECTIONGUIDESNM, @AFENTERWAREHCODE, @AFENTERWAREHNAME, @SHIPMENTSCDLDAY, @SHIPMENTFIXDAY, @ARRIVALGOODSDAY, @INPUTDAY, @MOVESTATUS, @STOCKMVEMPCODE, @STOCKMVEMPNAME, @SHIPAGENTCD, @SHIPAGENTNM, @RECEIVEAGENTCD, @RECEIVEAGENTNM, @SUPPLIERCD, @SUPPLIERSNM, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @STOCKDIV, @STOCKUNITPRICEFL, @TAXATIONDIVCD, @MOVECOUNT, @BFSHELFNO, @AFSHELFNO, @BLGOODSCODE, @BLGOODSFULLNAME, @LISTPRICEFL, @OUTLINE, @WAREHOUSENOTE1, @SLIPPRINTFINISHCD, @STOCKMOVEPRICE)";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraStockMoveFormal = sqlCommand.Parameters.Add("@STOCKMOVEFORMAL", SqlDbType.Int);
                SqlParameter paraStockMoveSlipNo = sqlCommand.Parameters.Add("@STOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter paraStockMoveRowNo = sqlCommand.Parameters.Add("@STOCKMOVEROWNO", SqlDbType.Int);
                SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraBfSectionGuideSnm = sqlCommand.Parameters.Add("@BFSECTIONGUIDESNM", SqlDbType.NVarChar);
                SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraAfSectionGuideSnm = sqlCommand.Parameters.Add("@AFSECTIONGUIDESNM", SqlDbType.NVarChar);
                SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraShipmentScdlDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLDAY", SqlDbType.Int);
                SqlParameter paraShipmentFixDay = sqlCommand.Parameters.Add("@SHIPMENTFIXDAY", SqlDbType.Int);
                SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
                SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@STOCKMVEMPCODE", SqlDbType.NChar);
                SqlParameter paraStockMvEmpName = sqlCommand.Parameters.Add("@STOCKMVEMPNAME", SqlDbType.NVarChar);
                SqlParameter paraShipAgentCd = sqlCommand.Parameters.Add("@SHIPAGENTCD", SqlDbType.NChar);
                SqlParameter paraShipAgentNm = sqlCommand.Parameters.Add("@SHIPAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraReceiveAgentCd = sqlCommand.Parameters.Add("@RECEIVEAGENTCD", SqlDbType.NChar);
                SqlParameter paraReceiveAgentNm = sqlCommand.Parameters.Add("@RECEIVEAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                SqlParameter paraMoveCount = sqlCommand.Parameters.Add("@MOVECOUNT", SqlDbType.Float);
                SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                SqlParameter paraWarehouseNote1 = sqlCommand.Parameters.Add("@WAREHOUSENOTE1", SqlDbType.NVarChar);
                SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                SqlParameter paraStockMovePrice = sqlCommand.Parameters.Add("@STOCKMOVEPRICE", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockMoveWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockMoveWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockMoveWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.LogicalDeleteCode);
                paraStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.StockMoveFormal);
                paraStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.StockMoveSlipNo);
                paraStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.StockMoveRowNo);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.UpdateSecCd);
                paraBfSectionCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.BfSectionCode);
                paraBfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.BfSectionGuideSnm);
                paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.BfEnterWarehCode);
                paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.BfEnterWarehName);
                paraAfSectionCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.AfSectionCode);
                paraAfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.AfSectionGuideSnm);
                paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.AfEnterWarehCode);
                paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.AfEnterWarehName);
                paraShipmentScdlDay.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.ShipmentScdlDay);
                paraShipmentFixDay.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.ShipmentFixDay);
                paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.ArrivalGoodsDay);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.InputDay);
                paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.MoveStatus);
                paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.StockMvEmpCode);
                paraStockMvEmpName.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.StockMvEmpName);
                paraShipAgentCd.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.ShipAgentCd);
                paraShipAgentNm.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.ShipAgentNm);
                paraReceiveAgentCd.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.ReceiveAgentCd);
                paraReceiveAgentNm.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.ReceiveAgentNm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.SupplierSnm);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.GoodsNameKana);
                paraStockDiv.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.StockDiv);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockMoveWork.StockUnitPriceFl);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.TaxationDivCd);
                paraMoveCount.Value = SqlDataMediator.SqlSetDouble(dcStockMoveWork.MoveCount);
                paraBfShelfNo.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.BfShelfNo);
                paraAfShelfNo.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.AfShelfNo);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.BLGoodsFullName);
                paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockMoveWork.ListPriceFl);
                paraOutline.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.Outline);
                paraWarehouseNote1.Value = SqlDataMediator.SqlSetString(dcStockMoveWork.WarehouseNote1);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(dcStockMoveWork.SlipPrintFinishCd);
                paraStockMovePrice.Value = SqlDataMediator.SqlSetInt64(dcStockMoveWork.StockMovePrice);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �݌Ɉړ��f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 ���� ---------->>>>>
		# region [Clear]
		// R�N���X��public Method��SQL�������ʖ�
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Delete�R�}���h�̐���
            //sqlCommand.CommandText = "DELETE FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
            sqlCommand.CommandText = "DELETE FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATESECCDRF  = @FINDSECTIONCODERF";
            
			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // ����f�[�^���폜����
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 ���� ----------<<<<<
    }
}
