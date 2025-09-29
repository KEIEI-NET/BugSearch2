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
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Microsoft.VisualBasic.Devices;// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
using System.Xml;// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɉړ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.01.19</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.04 ���� DC.NS�p�ɏC��</br>
    /// <br>Update Note: 2009/11/25 ���� MANTS�Ή� 14328</br>
    /// <br>Update Note: 2010/06/11 ���� ���׎�����̕s��Ή�</br>
    /// <br>Update Note: 2010/06/15 ����</br>
    /// <br>             �@�݌Ɏ����o�^���̕s��C��</br>
    /// <br>             �A�o�ד`�[�X�V���̕s��C��</br>
    /// <br>Update Note: 2010/06/16 ����</br>
    /// <br>             ���׎�����̓��ד`�[��_���폜�ł͂Ȃ��A�����폜����悤�ɏC��</br>
    /// <br>Update Note: 2010/11/15 ������</br>
    /// <br>             ��Q���ǑΉ������u�Q�v�̑Ή�</br>
    /// /// <br>Update Note: 2011/08/24  �A��980 ���X��</br>
    /// <br>            : REDMINE#23417�̑Ή�</br>
    /// <br>Update Note: 2011/08/11 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j</br>
    /// <br>             �݌Ɉړ��f�[�^��M���ɍ݌Ƀ}�X�^�̍X�V���s��</br>
    /// <br>Update Note: 2011/08/24 ������ #23964</br>
    /// <br>             MAZAI04124R�\�[�X���r���[���ʇ@�C��</br>
    /// <br>Update Note: 2011/08/29 ������ </br>
    /// <br>             �݌Ƀf�[�^���[���ꍇ�A�݌Ƀf�[�^�X�V���Ȃ��ɏC��</br>
    /// <br>Update Note: 2011/09/02 ������ #24259</br>
    /// <br>             �@�u�l���Z�b�g����Ă��Ȃ��v�C��</br>
    /// <br>             �A�u�݌Ɏ󕥃f�[�^���쐬����Ȃ��B�v�C��</br>
    /// <br>Update Note: 2011/09/05 ������ </br>
    /// <br>             �@#24187��M���̋��_�ɑΏۂ̃}�X�^���o�^����Ă��Ȃ��ꍇ�̕s��ɂ���</br>
    /// <br>             �A#24241�݌Ɏ󕥗����f�[�^�̐��ʂ̍X�V�ɂ���</br>
    /// <br>Update Note: 2012/05/22 wangf </br>
    /// <br>�@�@�@�@   : 10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
    /// <br>Update Note: 2012/07/05 �O�� �L�� </br>
    /// <br>�@�@�@�@   : 10801804-00 �ړ����݌Ɏ����o�^�敪�ɂ�鐧���ǉ�</br>
    /// <br>Update Note: 2012/07/10 �O�� �L�� </br>
    /// <br>�@�@�@�@   : ���Ɋm�莞�ɍ݌Ƀf�[�^�������������Q�Ή�</br>
    /// <br>Update Note: 2012/10/02 �e�c ���V </br>
    /// <br>�@�@�@�@   : �u�ړ����݌Ɏ����o�^�敪�v���h���Ȃ��h�̏ꍇ�ł��݌ɍX�V����悤�ɏC��</br>
    /// <br>Update Note: K2013/12/10 wangl2</br>
    /// <br>�Ǘ��ԍ�   : 10970522-00</br>
    /// <br>             �t�^�o�ʋ��_�Ԕ����������邱�Ƃ̑Ή�</br>
    /// <br>Update Note: K2013/12/25 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10970522-00</br>
    /// <br>             �t�^�o�ʋ��_�Ԕ����ް����A�����ް��̍쐬���邱�Ƃ̑Ή�</br>
    /// <br>�Ǘ��ԍ�   : 11200041-00</br>
    /// <br>Update Note: 2016/04/26 ����</br>
    /// <br>             Redmine#48729 �݌Ɉړ����͂̓��׎����Q�̑Ή�</br>
    /// <br>Update Note: ���O</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br>�Ǘ��ԍ�   : 11370074-00</br>
    /// <br>           : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// <br>Update Note: K2019/02/27 杍^</br>
    /// <br>             Redmine#49811 �R�[�G�C�i�ʁj�ړ��`�[���͓��׊m�菈���@�I�[�o�[�t���[�̑Ή�</br>
    /// <br>Update Note: K2020/03/25 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00 PMKOBETSU-3622�Ή�</br>
    /// <br>             UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
    /// <br>Update Note: K2021/02/02 ������</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00 PMKOBETSU-4114�Ή�</br>
    /// <br>             ���׏������O�ǉ��Ή�</br>
    /// <br>Update Note: 2021/08/25 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : BLINCIDENT-2462 ���݌��ƌJ�z��������Ȃ��Ή�</br>
    /// </remarks>
    [Serializable]
    public class StockMoveDB : RemoteWithAppLockDB, IStockMoveDB
    {
        private StockDB _stockDB = new StockDB();
        private StockMngTtlStDB _stockMngTtlStDB = new StockMngTtlStDB();       //�݌ɊǗ��S�̐ݒ�
        private SecInfoSetDB _secInfoDB = new SecInfoSetDB();
        private Hashtable secInfoSetWorkHash = new Hashtable();
        private UsrJoinPartsSearchDB _usrJoinPartsSearchDB = new UsrJoinPartsSearchDB();
        private bool _isRecv = false;//ADD 2011/09/02 ������ #24259
        // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
        // CLC���O�o�͋敪
        private bool ClcLogOutDiv = false;
        // �T�[�o�[���O�o�͋敪
        private bool ServerLogOutDiv = false;
        // ������s�`�F�b�N
        private bool FirstFlg = true;
        // �݌Ɉړ����O�o�͉ې���t�@�C��
        private string StockMoveLogOutCheckEnablerFileNm = "StockMoveLogOutCheckEnabler.xml";
        // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
        private enum ct_ProcMode
        {
            Write = 0,
            Delete = 1
        }


        // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion
        // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

        // ------ ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary>���i�f�[�^ DB�����[�g�I�u�W�F�N�g</summary>
        private InspectDataDB HandyInspectDataDB = null;

        /// <summary>
        /// ���i�f�[�^ DB�����[�g�v���p�e�B
        /// </summary>
        private InspectDataDB InspectDataObj
        {
            get
            {
                if (this.HandyInspectDataDB == null)
                {
                    // ���i�f�[�^ DB�����[�g�𐶐�
                    this.HandyInspectDataDB = new InspectDataDB();
                }

                return this.HandyInspectDataDB;
            }
        }
        // ------ ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        /// <summary>
        /// �݌Ɉړ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        /// </remarks>
        public StockMoveDB()
            :
            base("MAZAI04126D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork", "STOCKMOVERF")
        {
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
            // ������s���̏ꍇ
            if (FirstFlg)
            {
                GetXml();
            }
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�
        /// </summary>
        /// <param name="stockMoveWork">��������</param>
        /// <param name="parastockMoveWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int Search(out object stockMoveWork, object parastockMoveWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockMoveWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMoveProc(out stockMoveWork, parastockMoveWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Search");
                stockMoveWork = new ArrayList();
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

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ����LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockMoveWork">��������</param>
        /// <param name="parastockMoveWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int SearchStockMoveProc(out object objstockMoveWork, object parastockMoveWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockMoveSlipSearchCondWork stockmovepara = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            ArrayList stockmoveWorkList = null;
            SqlTransaction sqlTransaction = null;
            stockmovepara = parastockMoveWork as StockMoveSlipSearchCondWork;

            int status = SearchStockMoveProc(out stockmoveWorkList, stockmovepara, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

            retList.Add(stockmoveWorkList);
            objstockMoveWork = retList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmoveWorkList">��������</param>
        /// <param name="stockmoveWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int SearchStockMoveProc(out ArrayList stockmoveWorkList, StockMoveSlipSearchCondWork stockmoveWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchStockMoveProcProc(out stockmoveWorkList, stockmoveWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmoveWorkList">��������</param>
        /// <param name="stockmoveWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ����LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        private int SearchStockMoveProcProc(out ArrayList stockmoveWorkList, StockMoveSlipSearchCondWork stockmoveWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKM.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVESLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATESECCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVECOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.OUTLINERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.WAREHOUSENOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEPRICERF" + Environment.NewLine;
                selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockmoveWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockMoveWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockmoveWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ���߂��܂�
        /// </summary>
        /// <param name="parabyte">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ���߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                StockMoveWork stockmoveWork = new StockMoveWork();

                // XML�̓ǂݍ���
                stockmoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMoveWork));
                if (stockmoveWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockmoveWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(stockmoveWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Read");
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

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ���߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ���߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int ReadProc(ref StockMoveWork stockmoveWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProcProc(ref stockmoveWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ���߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ���߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        private int ReadProcProc(ref StockMoveWork stockmoveWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKM.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVESLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATESECCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVECOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.OUTLINERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.WAREHOUSENOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEPRICERF" + Environment.NewLine;
                selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);
                SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    stockmoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("�`�[�̑��݃`�F�b�N�G���[ status={0} �G���[���={1}", status, ex.Message));

            }
            finally
            {
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

            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɉړ��𕡐��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="stockmoveList">��������List</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɉړ���f�����߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        private int ReadProcProc(ref StockMoveWork stockmoveWork,ref ArrayList stockmoveList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKM.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVESLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATESECCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVECOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.OUTLINERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.WAREHOUSENOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEPRICERF" + Environment.NewLine;
                selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;
                if (stockmoveWork.StockMoveFormal != 0)
                {
                    selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                }

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                if (stockmoveWork.StockMoveFormal != 0)
                {
                    SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                    findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                }


                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockmoveList.Add(CopyToStockMoveWorkFromReader(ref myReader));
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

            }

            return status;
        }

        #endregion

        #region [Write]
        /// <summary>
        /// �݌Ɉړ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        public int Write(ref object stockMoveWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retMsg = "";
            
            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retItemInfo = "";
            bool createHisData = true;
            
            string resNm = "";
            try
            {
                // --- UPD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
                //OutputClcLog(string.Format("�݌Ɉړ��o�^�����J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                // �ďo�����\�b�h�擾
                try
                {
                    string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                    string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    OutputClcLog(string.Format("�݌Ɉړ��o�^���� �ďo��={0} �ďo�����\�b�h={1}", className, methodName));
                }
                catch
                {
                    //�����Ȃ�
                }
                // --- UPD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
                ArrayList stockMoveList = null;         //�݌Ɉړ����X�g
                ArrayList stockList = null;             //�݌Ƀ��X�g
                ArrayList stockAcPayHistList = null;    //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList = null;      //�X�V�����݌Ɉړ����X�g
                ArrayList BFStockMoveList = null; //�X�V�O�ړ����X�g
                ArrayList defStockList = null;    //�X�V�O�݌Ƀ��X�g
                ArrayList moveArrivalnewList = null; // ���ɓ`�[�V�K�쐬�p���X�g
                ArrayList moveArrivalupList = null; // ���ɓ`�[�X�V���X�g

                
                ArrayList goodsUnitList = null;
                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<
                // ���_�Ԕ����f�[�^object
                object orderDataDicObj = null;
                // �I�v�V�������obj
                object psObj = null;

                // ���_�Ԕ����f�[�^��Dictionary�̏�����
                Dictionary<string, ArrayList> orderDataDic = null;
                // �I�v�V�������̏�����
                int ps = 0;
                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

                // ------ ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // ���i�f�[�^�I�u�W�F�N�g
                ArrayList inspectList = null;
                // ------ ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                    if (csaList[i] is Dictionary<string, ArrayList>)
                    {
                        // ���_�Ԕ����f�[�^��Dictionary�̃Z�b�g
                        orderDataDic = csaList[i] as Dictionary<string, ArrayList>;
                        // ���_�Ԕ����f�[�^object�̃Z�b�g
                        orderDataDicObj = csaList[i];
                    }
                    else if (csaList[i] is int)
                    {
                        // �I�v�V�������obj�̃Z�b�g
                        ps = Convert.ToInt32(csaList[i]);
                        // �I�v�V�������̃Z�b�g
                        psObj = csaList[i];
                    }
                    else
                    {
                        ArrayList wkal = csaList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //�݌Ɉړ��}�X�^
                                if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                                //���i�}�X�^
                                if (wkal[0] is GoodsUnitDataWork) goodsUnitList = wkal;
                                // ���i�f�[�^
                                if (wkal[0] is HandyInspectDataWork) inspectList = wkal;// ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J��
                            }
                        }
                    }
                    // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

                    // ---- DEL K2013/12/25 ���N�n�� ---- >>>>>
                    //ArrayList wkal = csaList[i] as ArrayList;
                    //if (wkal != null)
                    //{
                    //    if (wkal.Count > 0)
                    //    {
                    //        //�݌Ɉړ��}�X�^
                    //        if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                    //        //���i�}�X�^
                    //        if (wkal[0] is GoodsUnitDataWork) goodsUnitList = wkal;
                    //    }
                    //}
                    // ---- DEL K2013/12/25 ���N�n�� ---- <<<<<
                }

                // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                // �p�����[�^�[�̋��_�Ԕ����f�[�^���폜����
                if (orderDataDicObj != null)
                {
                    csaList.Remove(orderDataDicObj);
                }

                // �p�����[�^�[�̃I�v�V���������폜����
                if (psObj != null)
                {
                    csaList.Remove(psObj);
                }
                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                //OutputClcLog(string.Format("���_�ݒ�擾�J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                //���_�ݒ�̎擾
                status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                    OutputClcLog(string.Format("���_�ݒ�擾�ُ� status={0} �G���[���={1}", status, retMsg));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�

                    return status;
                }
                //OutputClcLog(string.Format("���_�ݒ�擾�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// // DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                OutputClcLog(string.Format("�ړ����={0}", moveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;
                //OutputClcLog(string.Format("�V�X�e�����b�N�J�n �o�ɑq��={0} ���Ɍɑq��={1} �������������v={2} ���p�\����������={3}", _stockMoveWork.BfEnterWarehCode, _stockMoveWork.AfEnterWarehCode, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// // DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                // �o�ɃV�X�e�����b�N
                ShareCheckInfo bfinfo = new ShareCheckInfo();
                bfinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.BfEnterWarehCode);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    status = this.ShareCheck(bfinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Write_ShareCheckLocke_bfinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != 0)
                {
                    OutputClcLog(string.Format("�o�ɃV�X�e�����b�N�G���[ status={0}", status));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                    return status;
                } 
        
                // ���ɃV�X�e�����b�N
                ShareCheckInfo afinfo = new ShareCheckInfo();
                afinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.AfEnterWarehCode);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    status = this.ShareCheck(afinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Write_ShareCheckLocke_afinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != 0)
                {
                    OutputClcLog(string.Format("���ɃV�X�e�����b�N�G���[ status={0}", status));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                    return status;
                } 
                // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //OutputClcLog(string.Format("�V�X�e�����b�N�I�� �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                //OutputClcLog(string.Format("�`�o���b�N�����J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //resNm = GetResourceName(enterpriseCode);
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.Write:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.Write:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                        OutputClcLog(string.Format("�`�o���b�N�����G���[ status={0} �G���[���={1}", status, retMsg));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                        OutputClcLog(string.Format("�`�o���b�N�����G���[ status={0} �G���[���={1}", status, retMsg));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.Write_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                    return status;
                }
                //OutputClcLog(string.Format("�`�o���b�N�����I�� �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

                try
                {
                    OutputClcLog(string.Format("���׊m�肠��/�Ȃ�={0}", _stockMoveWork.StockMoveFixCode));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                     //���׊m�肠��
                    if (_stockMoveWork.StockMoveFixCode == 1)
                    // �e�X�g�p
                    //if (_stockMoveWork.StockMoveFixCode == 0)
                    {
                        //---�݌Ɉړ��`�[�ԍ��̔ԏ���---
                        if (stockMoveSlipNo == 0)//�݌Ɉړ��`�[
                        {
                            //OutputClcLog(string.Format("�݌Ɉړ��`�[�ԍ��̔ԏ����J�n ���_�R�[�h={0}�C�݌Ɉړ��`��={1}�C�������������v={2} ���p�\����������={3}", sectionCode, stockMoveFormal, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                            // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                OutputClcLog(string.Format("�݌Ɉړ��`�[�ԍ��̔ԏ����G���[ status={0} �G���[���={1}", status, retMsg));
                            }
                            // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<
                            //OutputClcLog(string.Format("�݌Ɉړ��`�[�ԍ��̔ԏ����I�� �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                        }
                        else
                        {
                            //�X�V�O�f�[�^�̎擾
                            BFStockMoveList = new ArrayList();
                            foreach (StockMoveWork stmvwork in stockMoveList)
                            {
                                StockMoveWork searchpara = new StockMoveWork();
                                searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                                searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                                searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                                searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                                this.ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);

                                BFStockMoveList.Add(searchpara);
                            }

                            // ���׏����̏ꍇ
                            if (moveStatus == 9)
                            {
                                //OutputClcLog(string.Format("���׏����̏ꍇ�o�ɓ`�[�X�V���X�g�쐬�J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                // �o�ɓ`�[�X�V���X�g�쐬�̃^�C�~���O�œ��ɐV�K���X�g�쐬
                                moveArrivalnewList = new ArrayList();

                                foreach (StockMoveWork stMoveWork in stockMoveList)
                                {
                                    StockMoveWork arrivalWork = new StockMoveWork();
                                    OutputClcLog(string.Format("���׏���(���ɐV�K���X�g�쐬�O) �݌Ɉړ��`�[�ԍ�={0};�݌Ɉړ��`��={1};�݌Ɉړ��s�ԍ�={2};�ړ����={3}", stMoveWork.StockMoveSlipNo, stMoveWork.StockMoveFormal, stMoveWork.StockMoveRowNo, stMoveWork.MoveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                    #region ���ɓ`�[
                                    arrivalWork.AfEnterWarehCode = stMoveWork.AfEnterWarehCode;
                                    arrivalWork.AfEnterWarehName = stMoveWork.AfEnterWarehName;
                                    arrivalWork.AfSectionCode = stMoveWork.AfSectionCode;
                                    arrivalWork.AfSectionGuideSnm = stMoveWork.AfSectionGuideSnm;
                                    arrivalWork.AfShelfNo = stMoveWork.AfShelfNo;
                                    arrivalWork.ArrivalGoodsDay = stMoveWork.ArrivalGoodsDay;
                                    arrivalWork.AutoGoodsInsDiv = stMoveWork.AutoGoodsInsDiv;
                                    arrivalWork.BfEnterWarehCode = stMoveWork.BfEnterWarehCode;
                                    arrivalWork.BfEnterWarehName = stMoveWork.BfEnterWarehName;
                                    arrivalWork.BfSectionCode = stMoveWork.BfSectionCode;
                                    arrivalWork.BfSectionGuideSnm = stMoveWork.BfSectionGuideSnm;
                                    arrivalWork.BfShelfNo = stMoveWork.BfShelfNo;
                                    arrivalWork.BLGoodsCode = stMoveWork.BLGoodsCode;
                                    arrivalWork.BLGoodsFullName = stMoveWork.BLGoodsFullName;
                                    arrivalWork.CreateDateTime = stMoveWork.CreateDateTime;
                                    arrivalWork.EnterpriseCode = stMoveWork.EnterpriseCode;
                                    arrivalWork.FileHeaderGuid = stMoveWork.FileHeaderGuid;
                                    arrivalWork.GoodsMakerCd = stMoveWork.GoodsMakerCd;
                                    arrivalWork.GoodsName = stMoveWork.GoodsName;
                                    arrivalWork.GoodsNameKana = stMoveWork.GoodsNameKana;
                                    arrivalWork.GoodsNo = stMoveWork.GoodsNo;
                                    arrivalWork.InputDay = stMoveWork.InputDay;
                                    arrivalWork.ListPriceFl = stMoveWork.ListPriceFl;
                                    arrivalWork.LogicalDeleteCode = stMoveWork.LogicalDeleteCode;
                                    arrivalWork.MakerName = stMoveWork.MakerName;
                                    arrivalWork.MoveCount = stMoveWork.MoveCount;
                                    arrivalWork.MoveStatus = stMoveWork.MoveStatus;
                                    arrivalWork.Outline = stMoveWork.Outline;
                                    arrivalWork.ReceiveAgentCd = stMoveWork.ReceiveAgentCd;
                                    arrivalWork.ReceiveAgentNm = stMoveWork.ReceiveAgentNm;
                                    arrivalWork.ShipAgentCd = stMoveWork.ShipAgentCd;
                                    arrivalWork.ShipAgentNm = stMoveWork.ShipAgentNm;
                                    arrivalWork.StockDiv = stMoveWork.StockDiv;
                                    arrivalWork.StockMoveFixCode = stMoveWork.StockMoveFixCode;
                                    if (stMoveWork.StockMoveFormal == 1) arrivalWork.StockMoveFormal = 3;
                                    else arrivalWork.StockMoveFormal = 4;
                                    arrivalWork.StockMovePrice = stMoveWork.StockMovePrice;
                                    arrivalWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                    arrivalWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                    arrivalWork.StockMvEmpCode = stMoveWork.StockMvEmpCode;
                                    arrivalWork.StockMvEmpName = stMoveWork.StockMvEmpName;
                                    arrivalWork.StockUnitPriceFl = stMoveWork.StockUnitPriceFl;
                                    arrivalWork.SupplierCd = stMoveWork.SupplierCd;
                                    arrivalWork.SupplierSnm = stMoveWork.SupplierSnm;
                                    arrivalWork.TaxationDivCd = stMoveWork.TaxationDivCd;
                                    arrivalWork.UpdAssemblyId1 = stMoveWork.UpdAssemblyId1;
                                    arrivalWork.UpdAssemblyId2 = stMoveWork.UpdAssemblyId2;
                                    arrivalWork.UpdateDateTime = stMoveWork.UpdateDateTime;
                                    arrivalWork.UpdateSecCd = stMoveWork.UpdateSecCd;
                                    arrivalWork.UpdEmployeeCode = stMoveWork.UpdEmployeeCode;
                                    arrivalWork.WarehouseNote1 = stMoveWork.WarehouseNote1;
                                    arrivalWork.SlipPrintFinishCd = stMoveWork.SlipPrintFinishCd;

                                    // --- ADD �O�� 2012/07/10 ---------->>>>>
                                    arrivalWork.MoveStockAutoInsDiv = stMoveWork.MoveStockAutoInsDiv;
                                    // --- ADD �O�� 2012/07/10 ----------<<<<<

                                    #endregion

                                    moveArrivalnewList.Add(arrivalWork);
                                    OutputClcLog(string.Format("���׏���(���ɐV�K���X�g�쐬��) �݌Ɉړ��`��={0}", arrivalWork.StockMoveFormal));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                    // Read�p
                                    StockMoveWork readArrivalWork = new StockMoveWork();
                                    readArrivalWork.EnterpriseCode = arrivalWork.EnterpriseCode;
                                    readArrivalWork.StockMoveFormal = arrivalWork.StockMoveFormal;
                                    readArrivalWork.StockMoveSlipNo = arrivalWork.StockMoveSlipNo;
                                    readArrivalWork.StockMoveRowNo = arrivalWork.StockMoveRowNo;


                                    // �_���폜�`�[�̑��݃`�F�b�N
                                    status = ReadProcProc(ref readArrivalWork, 0, ref sqlConnection, ref sqlTransaction);
                                    // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                                    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                                    {
                                        OutputClcLog(string.Format("�_���폜�`�[�̑��݃`�F�b�N�G���[ status={0}", status));
                                    }
                                    // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<

                                    // -- UPD 2009/11/25 ----------------------->>>
                                    //�_���폜��Ԃ͒ʏ�͂P�����A����̃��[�U�[��9�����݂��鎖���l������OR�Ƃ���
                                    //if (status == 0 && readArrivalWork.LogicalDeleteCode == 9)
                                    if (status == 0 && (readArrivalWork.LogicalDeleteCode == 1 || readArrivalWork.LogicalDeleteCode == 9))
                                    // -- UPD 2009/11/25 -----------------------<<<
                                    {
                                        // -- UPD 2010/06/11 ---------------->>>
                                        //moveArrivalupList = new ArrayList();
                                        if (moveArrivalupList == null) moveArrivalupList = new ArrayList();
                                        // -- UPD 2010/06/11 ----------------<<<
                                        moveArrivalupList.Add(readArrivalWork);
                                    }

                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                //OutputClcLog(string.Format("���׏����̏ꍇ�o�ɓ`�[�X�V���X�g�쐬�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            }
                            // ���׎���̏ꍇ
                            // ADD 2009/07/08 �R�����g�ǉ� >>>
                            // ���׎�������̏ꍇ�A�o�Ƀf�[�^�E���Ƀf�[�^��2���R�[�h�ɑ΂��Ă̍X�V���s��
                            // �o�Ƀf�[�^�˓��׊m��O�̏�ԂɍX�V( �@���ד�=0 �A�ړ����=2:�ړ��� �ɕύX )
                            // ���Ƀf�[�^�˓��׊m��O�̏�ԂɍX�V( �@�폜�敪 =1:�_���폜 �ɕύX )
                            // ADD 2009/07/08 <<<
                            else if (moveStatus == 2)
                            {
                                // �C�� 2009/07/08 >>>
                                //foreach (StockMoveWork stMoveWork in stockMoveList)
                                //{
                                    //StockMoveWork arrivalWork = new StockMoveWork();
                                    //arrivalWork.EnterpriseCode = stMoveWork.EnterpriseCode;
                                    //arrivalWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                    //arrivalWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                    //if (stMoveWork.StockMoveFormal == 1) arrivalWork.StockMoveFormal = 3;
                                    //else arrivalWork.StockMoveFormal = 4;
                                    //status = ReadProcProc(ref arrivalWork, 0, ref sqlConnection, ref sqlTransaction);
                                    //if (status == 0 && arrivalWork.LogicalDeleteCode == 0)
                                    //{
                                    //    arrivalWork.LogicalDeleteCode = 9;
                                    //    moveArrivalnewList = new ArrayList();
                                    //    moveArrivalnewList.Add(arrivalWork);
                                    //}
                                //}
                                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                // -- ADD 2009/11/25 ----------------->>>
                                if (stockMoveFormal == 3 || stockMoveFormal == 4)
                                {
                                // -- ADD 2009/11/25 -----------------<<<
                                    for (int i = 0; i < stockMoveList.Count; i++)
                                    {
                                        StockMoveWork stMoveWork = stockMoveList[i] as StockMoveWork;
                                        OutputClcLog(string.Format("���׎������(���ɓ`�[) �݌Ɉړ��`�[�ԍ�={0};�݌Ɉړ��`��={1};�݌Ɉړ��s�ԍ�={2};�ړ����={3}", stMoveWork.StockMoveSlipNo, stMoveWork.StockMoveFormal, stMoveWork.StockMoveRowNo, stMoveWork.MoveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

                                        // ���ɓ`�[�̕ύX
                                        // -- UPD 2009/11/25 --------------------->>>
                                        //�_���폜��Ԃ�1�ɕύX
                                        //((StockMoveWork)stockMoveList[i]).LogicalDeleteCode = 9;  // �_���폜�敪 = 9
                                        ((StockMoveWork)stockMoveList[i]).LogicalDeleteCode = 1;  // �_���폜�敪 = 1
                                        // -- UPD 2009/11/25 ---------------------<<<


                                        StockMoveWork arrivalWork = new StockMoveWork();

                                        // ���ɓ`�[��񂩂�o�ɓ`�[���������Z�b�g
                                        arrivalWork.EnterpriseCode = stMoveWork.EnterpriseCode;
                                        arrivalWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                        arrivalWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                        if (stMoveWork.StockMoveFormal == 3) arrivalWork.StockMoveFormal = 1;
                                        else arrivalWork.StockMoveFormal = 2;
                                        OutputClcLog(string.Format("���׎������(�o�ɓ`�[��������) �݌Ɉړ��`�[�ԍ�={0};�݌Ɉړ��`��={1};�݌Ɉړ��s�ԍ�={2};�ړ����={3}", stMoveWork.StockMoveSlipNo, stMoveWork.StockMoveFormal, stMoveWork.StockMoveRowNo, stMoveWork.MoveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                        // �`�[�̑��݃`�F�b�N
                                        status = ReadProcProc(ref arrivalWork, 0, ref sqlConnection, ref sqlTransaction);
                                        // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            OutputClcLog(string.Format("���׎���̏ꍇ�`�[�̑��݃`�F�b�N�G���[ status={0}", status));
                                        }
                                        // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<

                                        if (status == 0 && arrivalWork.LogicalDeleteCode == 0)
                                        {
                                            // �o�ɓ`�[�̕ύX
                                            // -- UPD 2010/06/11 ----------------->>>
                                            //moveArrivalnewList = new ArrayList();
                                            if (moveArrivalnewList == null) moveArrivalnewList = new ArrayList();
                                            // -- UPD 2010/06/11 -----------------<<<
                                            if (arrivalWork.StockMoveFormal == 1 || arrivalWork.StockMoveFormal == 2)
                                            {
                                                arrivalWork.MoveStatus = 2;// �ړ���� = 2:�ړ���
                                                arrivalWork.ArrivalGoodsDay = DateTime.MinValue;// ���ד� = 0

                                                moveArrivalnewList.Add(arrivalWork);
                                                OutputClcLog(string.Format("���׎������(�o�ɓ`�[) �݌Ɉړ��`�[�ԍ�={0};�݌Ɉړ��`��={1};�݌Ɉړ��s�ԍ�={2};�ړ����={3}", arrivalWork.StockMoveSlipNo, arrivalWork.StockMoveFormal, arrivalWork.StockMoveRowNo, arrivalWork.MoveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                            }
                                        }
                                    }
                                } // ADD 2009/11/25

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                // �C�� 2009/07/08 <<<
                            }

                            #region DEL
                            //status = SearchStockMoveProc(out BFStockMoveList, searchpara, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //    status = DeleteStockMoveProc(BFStockMoveList, out deldefList, ref sqlConnection, ref sqlTransaction);

                            //createHisData = false;
                            //�f�[�^����(�O��̍݌ɂ̍X�V�l����x�N���A����)
                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                            //    status = TransStockMoveToStock((int)ct_ProcMode.Delete, createHisData, stockMoveFormal, stockMoveSlipNo, BFStockMoveList, BFStockMoveList, BFStockMoveList,  defStockList ,out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);

                            //�݌Ƀf�[�^�X�V
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //{
                            //    string origin = "";
                            //    CustomSerializeArrayList originList = null;
                            //    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                            //    paraList.Add(stockList);
                            //    int position = 0;
                            //    string param = "";
                            //    object freeParam = null;
                            //    status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                            //}
                            #endregion
                        }

                        //---�X�V����---
                        //�݌Ɉړ��f�[�^�X�V
                        if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // -- UPD 2010/06/16 ---------------------------------------->>>
                            //// �o�ɁE���ɓ`�[�o�^
                            //status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                            //if (stockMoveList != null)
                            //    if (stockMoveList.Count > 0)
                            //        retList.Add(stockMoveList);

                            if (moveStatus == 2 && moveArrivalnewList != null)
                            {
                                //OutputClcLog(string.Format("���׎���̏ꍇ���ד`�[�̍폜�J�n �݌Ɉړ��`�[����={0} �������������v={1} ���p�\����������={2}", stockMoveList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                //���׎���̏ꍇ�́A���ד`�[�̍폜
                                status = DeleteStockMoveProc(stockMoveList, out defStockMoveList, ref sqlConnection, ref sqlTransaction);
                                if (stockMoveList != null)
                                    if (stockMoveList.Count > 0)
                                        retList.Add(stockMoveList);
                                OutputClcLog(string.Format("���׎���̏ꍇ���ד`�[�̍폜�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                            }
                            else
                            {
                                //OutputClcLog(string.Format("�o�ɁE���ɓ`�[�o�^�J�n �݌Ɉړ��`�[����={0} �������������v={1} ���p�\����������={2}", stockMoveList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                // �o�ɁE���ɓ`�[�o�^
                                status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                                if (stockMoveList != null)
                                    if (stockMoveList.Count > 0)
                                        retList.Add(stockMoveList);
                                OutputClcLog(string.Format("�o�ɁE���ɓ`�[�o�^�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                            }
                            // -- UPD 2010/06/16 ----------------------------------------<<<

                            // ���ɓ`�[�o�^��_���폜��V�K�o�^�̏ꍇ // moveStatus��9(���׏���)����2(���׎��)��������
                            if ((moveStatus == 9 || moveStatus == 2) && moveArrivalupList == null && moveArrivalnewList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //OutputClcLog(string.Format("���̏o�ɓ`�[�̍X�V�J�n �݌Ɉړ��`�[����={0} �������������v={1} ���p�\����������={2}", moveArrivalnewList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                //���̏o�ɓ`�[�̍X�V
                                ArrayList defMoveArrivalList = null;
                                status = WriteStockMoveProc(stockMoveSlipNo, out defMoveArrivalList, ref moveArrivalnewList, ref sqlConnection, ref sqlTransaction);
                                OutputClcLog(string.Format("���̏o�ɓ`�[�̍X�V�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                            }
                            // ���ɓ`�[���� �_���폜�f�[�^���������ꍇ // moveStatus��9(���׏���)��������
                            if (moveStatus == 9 && moveArrivalupList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //object arrivalobj = null;
                                //CustomSerializeArrayList arrivalArray = new CustomSerializeArrayList();

                                //arrivalArray.Add(moveArrivalupList);
                                //arrivalobj = arrivalArray;

                                //status = RevivalLogicalDelete(ref arrivalobj);

                                ArrayList DefstockMoveWorkList = null;
                                //OutputClcLog(string.Format("�݌Ɉړ����̘_���폜�J�n�@�폜����={0} �������������v={1} ���p�\����������={2}", moveArrivalupList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                LogicalDeleteStockMoveProcProc(ref moveArrivalupList, out DefstockMoveWorkList, 1, ref sqlConnection, ref sqlTransaction);
                                OutputClcLog(string.Format("�݌Ɉړ����̘_���폜�I�� �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                            }
                        }

                        // --- ADD �O�� 2012/07/05 ---------->>>>>
                        // �����ǉ��F�ړ����݌Ɏ����o�^�敪���u0:����v�̏ꍇ
                        if (_stockMoveWork.MoveStockAutoInsDiv == 0)
                        {
                            // --- ADD �O�� 2012/07/05 ----------<<<<<
                            //���i�}�X�^�f�[�^�V�K�o�^
                            if (goodsUnitList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                CustomSerializeArrayList goodscsList = new CustomSerializeArrayList();
                                goodscsList.Add(goodsUnitList);

                                object goodsobj = goodscsList;
                                //OutputClcLog(string.Format("���i�}�X�^�f�[�^�V�K�o�^�J�n �o�^���i����={0} �������������v={1} ���p�\����������={2}", goodsUnitList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                status = _usrJoinPartsSearchDB.ReadNewWriteRelation(ref goodsobj, ref sqlConnection, ref sqlTransaction);
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("���i�}�X�^�f�[�^�V�K�o�^�G���[ status={0}", status));
                                }
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<
                                OutputClcLog(string.Format("���i�}�X�^�f�[�^�V�K�o�^�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                            }
                            // --- ADD �O�� 2012/07/05 ---------->>>>>
                        }
                        // --- ADD �O�� 2012/07/05 ----------<<<<<

                        //�f�[�^����
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            createHisData = true;
                            ArrayList defList = defStockMoveList;
                            //status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                            //OutputClcLog(string.Format("�f�[�^�ϊ�(����)�����J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��
                            OutputClcLog(string.Format("�f�[�^�ϊ�(����)�����I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
                        }

                        //�݌Ƀf�[�^�X�V
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            string origin = "";
                            CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                            paraList.Add(stockList);
                            paraList.Add(stockAcPayHistList);
                            int position = 0;
                            string param = "";
                            object freeParam = null;
                            // --- ADD �O�� 2012/07/05 ---------->>>>>
                            // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�ɑΉ�
                            if ((stockList.Count == 0 && stockAcPayHistList.Count == 0) == false)
                            {
                                // --- ADD �O�� 2012/07/05 ----------<<<<<
                                //OutputClcLog(string.Format("�݌Ƀf�[�^�X�V�����J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));
                                status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("�݌Ƀf�[�^�X�V�����G���[ status={0} �G���[���={1}", status, retMsg));
                                }
                                OutputClcLog(string.Format("�݌Ƀf�[�^�X�V�����I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<

                                // --- ADD �O�� 2012/07/05 ---------->>>>>
                                // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                                // �t�^�o�ʐ��p�̃L�[�ɃI�v�V�����R�[�h�������̏ꍇ(�I�v�V�����R�[�h�FOPT-CPM0130)
                                if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count > 0)
                                {
                                    status = UpdateSecOrderDtWork((int)ct_ProcMode.Write, stockMoveList, orderDataDic, ref sqlConnection, ref sqlTransaction);
                                    OutputClcLog(string.Format("�t�^�o���_�Ԕ����f�[�^�X�V�����I�� status={0}", status));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                }
                                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

                                // ------ ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                                // ���i�f�[�^�o�^
                                if (inspectList != null && inspectList.Count > 0)
                                {
                                    // ���i�f�[�^�o�^
                                    status = this.InspectDataObj.WriteInspectDataProc(ref inspectList, ref sqlConnection, ref sqlTransaction, 0);
                                    OutputClcLog(string.Format("���i�f�[�^�o�^�I�� status={0}", status));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                }
                                // ------ ADD 2017/08/02 ���O �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
                            }
                            // --- ADD �O�� 2012/07/05 ----------<<<<<
                        }

                        //�߂�l�Z�b�g
                        stockMoveWork = retList;
                    }
                    // ���׊m��Ȃ�
                    else
                    {
                        ArrayList stockMoveNewList = null;
                        //---�݌Ɉړ��`�[�ԍ��̔ԏ���---
                        if (stockMoveSlipNo == 0)//�݌Ɉړ��`�[
                        {
                            status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                        }
                        else
                        {
                            //�X�V�O�f�[�^�̎擾
                            BFStockMoveList = new ArrayList();
                            stockMoveNewList = new ArrayList(); 
                            foreach (StockMoveWork stmvwork in stockMoveList)
                            {
                                StockMoveWork searchpara = new StockMoveWork();
                                searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                                searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                                searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                                searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                                this.ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);

                                BFStockMoveList.Add(searchpara);

                                // ���ד`�[��������Z�b�g���L�d�l��ύX
                                if (searchpara.StockMoveFormal == 3 || searchpara.StockMoveFormal == 4)
                                {
                                    searchpara.ShipmentScdlDay = DateTime.MinValue;
                                    searchpara.ShipmentFixDay = DateTime.MinValue;
                                }
                            }
                        }
                        //---�X�V����---
                        //�݌Ɉړ��f�[�^�X�V
                        if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�݌Ɉړ��f�[�^�X�V�J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            // �o�ɓ`�[�o�^
                            status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                            if (stockMoveList != null)
                                if (stockMoveList.Count > 0)
                                    retList.Add(stockMoveList);
                            //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�݌Ɉړ��f�[�^�X�V�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                        }

                        // --- ADD �O�� 2012/07/05 ---------->>>>>
                        // �����ǉ��F�ړ����݌Ɏ����o�^�敪���u0:����v�̏ꍇ
                        if (_stockMoveWork.MoveStockAutoInsDiv == 0)
                        {
                            // --- ADD �O�� 2012/07/05 ----------<<<<<
                            //���i�}�X�^�f�[�^�V�K�o�^
                            if (goodsUnitList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                CustomSerializeArrayList goodscsList = new CustomSerializeArrayList();
                                goodscsList.Add(goodsUnitList);

                                object goodsobj = goodscsList;
                                //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A���i�}�X�^�f�[�^�V�K�o�^�J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                status = _usrJoinPartsSearchDB.ReadNewWriteRelation(ref goodsobj, ref sqlConnection, ref sqlTransaction);
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A���i�}�X�^�f�[�^�V�K�o�^�G���[ status={0}", status));
                                }
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<
                                //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A���i�}�X�^�f�[�^�V�K�o�^�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

                            }
                            // --- ADD �O�� 2012/07/05 ---------->>>>>
                        }
                        // --- ADD �O�� 2012/07/05 ----------<<<<<

                        //�f�[�^����
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            createHisData = true;
                            ArrayList defList = defStockMoveList;
                            //status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                            //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�f�[�^�����J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                            try
                            {
                                status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��
                            }
                            catch (Exception ex)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�f�[�^�����G���[ status={0} �G���[���e={1}", status, ex.Message));
                            }
                            finally
                            {
                                //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�f�[�^�����I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            }
                            // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<                            
                        }
                        
                        //�݌Ƀf�[�^�X�V
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            string origin = "";
                            //CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                            paraList.Add(stockList);
                            paraList.Add(stockAcPayHistList);
                            int position = 0;
                            string param = "";
                            object freeParam = null;
                            if ((stockList.Count == 0 && stockAcPayHistList.Count == 0) == false)
                            {
                                //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�݌Ƀf�[�^�X�V�J�n �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                                status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�݌Ƀf�[�^�X�V�G���[ status={0}", status));
                                }
                                // ----ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�----<<<<<

                                //OutputClcLog(string.Format("���׊m��Ȃ��̏ꍇ�A�݌Ƀf�[�^�X�V�I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            }
                        }

                        //�߂�l�Z�b�g
                        stockMoveWork = retList;
                    }
                }
                finally
                {
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.Write_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                        //OutputClcLog(string.Format("�`�o�A�����b�NRelease �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                    }
                    // -- UPD 2010/06/16 --------------------------->>>
                    int bkstatus = 0;
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        bkstatus = status;
                    // -- UPD 2010/06/16 ---------------------------<<<

                    // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", status);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", status);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", status);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", status);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    //OutputClcLog(string.Format("�V�X�e�����b�NRelease �������������v={0} ���p�\����������={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                    // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // -- UPD 2010/06/16 --------------------------->>>
                    //���C�������Ŏ��s���Ă��A���b�N�̃����[�X������I������ƁA�R�~�b�g����Ă��܂����߁A
                    //�����őޔ������X�e�[�^�X���Z�b�g����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        status = bkstatus;
                    // -- UPD 2010/06/16 ---------------------------<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Write(ref object stockMoveWork,out string retMsg)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                OutputClcLog(string.Format("�݌Ɉړ��o�^�����G���[ status={0} �G���[���={1}", status, ex.Message));
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //OutputClcLog(string.Format("�݌Ɉړ��o�^�����I�� status={0} �������������v={1} ���p�\����������={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
            }

            return status;
        }



        // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>

        /// <summary>
        /// ���_�Ԕ����f�[�^���X�V���܂�
        /// </summary>
        /// <param name="procMode">procMode</param>
        /// <param name="stockMoveList">stockMoveList</param>
        /// <param name="orderDataDic">orderDataDic</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        ///<remarks>
        /// <br>Note       : ���_�Ԕ����f�[�^���X�V���܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : K2013/12/25</br>
        ///</remarks>
        private int UpdateSecOrderDtWork(int procMode, ArrayList stockMoveList, Dictionary<string, ArrayList> orderDataDic, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string orderDataKey = string.Empty;
                StockMoveWork para = new StockMoveWork();
                ArrayList secOrderDtList = new ArrayList();
                // ����̏ꍇ�F1������ // ���ɂ̏ꍇ�F2������
                int secOrderDataDiv = 0;

                DateTime updateDateTime;
                //�݌Ɉړ��f�[�^�����[�v
                for (int i = 0; i < stockMoveList.Count; i++)
                {

                    para = stockMoveList[i] as StockMoveWork;
                    orderDataKey = para.StockMoveSlipNo + "_" + para.StockMoveRowNo;
                    if (!orderDataDic.ContainsKey(orderDataKey))
                    {
                        continue;
                    }

                    secOrderDtList = orderDataDic[orderDataKey] as ArrayList;

                    updateDateTime = Convert.ToDateTime(secOrderDtList[0]);
                    secOrderDataDiv = Convert.ToInt32(secOrderDtList[2]);
                    

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SECORDERDTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.NVarChar);
                    SqlParameter findStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(para.EnterpriseCode); // ��ƃR�[�h
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0); // �_���폜�敪
                    findStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(para.StockMoveSlipNo);// �����ԍ�
                    findStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(para.StockMoveRowNo);// �����s�ԍ�
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != updateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (updateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        # region �X�V����SQL������
                        StringBuilder sb = new StringBuilder();
                        sb.Append("UPDATE SECORDERDTRF SET ");
                        sb.Append("UPDATEDATETIMERF=@UPDATEDATETIME ,");
                        sb.Append("ENTERPRISECODERF=@ENTERPRISECODE ,");
                        sb.Append("FILEHEADERGUIDRF=@FILEHEADERGUID ,");
                        sb.Append("UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ,");
                        sb.Append("UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ,");
                        sb.Append("UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ,");
                        if (procMode == 0)
                        {
                            sb.Append("SECORDERDATADIVRF=@SECORDERDATADIV, ");
                        }
                        sb.Append("LOGICALDELETECODERF=@LOGICALDELETECODE ");
                        sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");
                        sb.Append("  AND  STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO ");
                        sb.Append("  AND  STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO ");
                        sqlCommand.CommandText = sb.ToString();
                        # endregion

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)para;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);


                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(para.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(para.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(para.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(para.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(para.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(para.UpdAssemblyId2);

                    if (procMode == 1)
                    {
                        // �`�[�폜�̏ꍇ
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                    }
                    else
                    {
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    }



                    if (secOrderDataDiv == 1 || secOrderDataDiv == 2)
                    {
                        SqlParameter paraSecOrderDataDiv = sqlCommand.Parameters.Add("@SECORDERDATADIV", SqlDbType.NVarChar);
                        // ���ɂ̏ꍇ�F2������ ����̏ꍇ�F1������
                        paraSecOrderDataDiv.Value = SqlDataMediator.SqlSetInt32(secOrderDataDiv);
                    }

                    #endregion

                    sqlCommand.ExecuteNonQuery();
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
        // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

        /// <summary>
        /// �݌Ɉړ�����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <param name="DefstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        public int WriteStockMoveProc(int stockMoveSlipNo, out ArrayList DefstockMoveWorkList, ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
            // �ďo�����\�b�h�擾
            try
            {
                string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                OutputClcLog(string.Format("�݌Ɉړ��o�^���� �ďo��={0} �ďo�����\�b�h={1}", className, methodName));
            }
            catch
            {
                //�����Ȃ�
            }
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
            return WriteStockMoveProcProc(stockMoveSlipNo, out DefstockMoveWorkList, ref stockMoveWorkList, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// �݌Ɉړ�����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <param name="DefstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: 2011/08/24  �A��980 ���X��</br>
        /// <br>            : REDMINE#23417�̑Ή�</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        private int WriteStockMoveProcProc(int stockMoveSlipNo, out ArrayList DefstockMoveWorkList, ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            DefstockMoveWorkList = new ArrayList();//�X�V�O�㍷���p���X�g
            try
            {
                string selectTxt = "";

                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        //�݌Ɉړ��`�[�ԍ��� 0 �̏ꍇ�̓p�����[�^�̓`�[�ԍ����Z�b�g
                        if (stockmoveWork.StockMoveSlipNo == 0)
                            stockmoveWork.StockMoveSlipNo = stockMoveSlipNo;

                        //OutputClcLog(string.Format("�݌Ɉړ���� �݌Ɉړ��`�[�ԍ�={0} �݌Ɉړ��`�[�s�ԍ�={1}", stockmoveWork.StockMoveSlipNo, stockmoveWork.StockMoveRowNo));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  *" + Environment.NewLine;
                        selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            OutputClcLog(string.Format("�݌Ɉړ��`�[UPDATE �݌Ɉړ��`�[�ԍ�={0} �݌Ɉړ��`�[�s�ԍ�={1} �݌Ɉړ��`��={2} �ړ����={3}", stockmoveWork.StockMoveSlipNo, stockmoveWork.StockMoveRowNo, stockmoveWork.StockMoveFormal, stockmoveWork.MoveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockmoveWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (stockmoveWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�X�V�O�̍݌Ɉړ��f�[�^���擾
                            StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                            //�X�V��̈ړ����𔽉f
                            defStockMoveWork.MoveCount = stockmoveWork.MoveCount - defStockMoveWork.MoveCount;
                            defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice - defStockMoveWork.StockMovePrice;
                            // -- ADD 2010/06/15 -------------------------------->>>
                            //�m��敪��ǉ�
                            defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                            // --- ADD �O�� 2012/07/10 ---------->>>>>
                            defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                            // --- ADD �O�� 2012/07/10 ----------<<<<<

                            // -- ADD 2010/06/15 --------------------------------<<<
                            DefstockMoveWorkList.Add(defStockMoveWork);

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKMOVERF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , STOCKMOVEFORMALRF=@STOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " , STOCKMOVESLIPNORF=@STOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " , STOCKMOVEROWNORF=@STOCKMOVEROWNO" + Environment.NewLine;
                            selectTxt += " , UPDATESECCDRF=@UPDATESECCD" + Environment.NewLine;
                            selectTxt += " , BFSECTIONCODERF=@BFSECTIONCODE" + Environment.NewLine;
                            selectTxt += " , BFSECTIONGUIDESNMRF=@BFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += " , BFENTERWAREHCODERF=@BFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += " , BFENTERWAREHNAMERF=@BFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += " , AFSECTIONCODERF=@AFSECTIONCODE" + Environment.NewLine;
                            selectTxt += " , AFSECTIONGUIDESNMRF=@AFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += " , AFENTERWAREHCODERF=@AFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += " , AFENTERWAREHNAMERF=@AFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += " , SHIPMENTSCDLDAYRF=@SHIPMENTSCDLDAY" + Environment.NewLine;
                            selectTxt += " , SHIPMENTFIXDAYRF=@SHIPMENTFIXDAY" + Environment.NewLine;
                            selectTxt += " , ARRIVALGOODSDAYRF=@ARRIVALGOODSDAY" + Environment.NewLine;
                            selectTxt += " , INPUTDAYRF=@INPUTDAY" + Environment.NewLine;
                            selectTxt += " , MOVESTATUSRF=@MOVESTATUS" + Environment.NewLine;
                            selectTxt += " , STOCKMVEMPCODERF=@STOCKMVEMPCODE" + Environment.NewLine;
                            selectTxt += " , STOCKMVEMPNAMERF=@STOCKMVEMPNAME" + Environment.NewLine;
                            selectTxt += " , SHIPAGENTCDRF=@SHIPAGENTCD" + Environment.NewLine;
                            selectTxt += " , SHIPAGENTNMRF=@SHIPAGENTNM" + Environment.NewLine;
                            selectTxt += " , RECEIVEAGENTCDRF=@RECEIVEAGENTCD" + Environment.NewLine;
                            selectTxt += " , RECEIVEAGENTNMRF=@RECEIVEAGENTNM" + Environment.NewLine;
                            selectTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSNMRF=@SUPPLIERSNM" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , MAKERNAMERF=@MAKERNAME" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                            selectTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                            selectTxt += " , MOVECOUNTRF=@MOVECOUNT" + Environment.NewLine;
                            selectTxt += " , BFSHELFNORF=@BFSHELFNO" + Environment.NewLine;
                            selectTxt += " , AFSHELFNORF=@AFSHELFNO" + Environment.NewLine;
                            selectTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += " , BLGOODSFULLNAMERF=@BLGOODSFULLNAME" + Environment.NewLine;
                            selectTxt += " , LISTPRICEFLRF=@LISTPRICEFL" + Environment.NewLine;
                            selectTxt += " , OUTLINERF=@OUTLINE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSENOTE1RF=@WAREHOUSENOTE1" + Environment.NewLine;
                            selectTxt += " , SLIPPRINTFINISHCDRF=@SLIPPRINTFINISHCD" + Environment.NewLine;
                            selectTxt += " , STOCKMOVEPRICERF=@STOCKMOVEPRICE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                            findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            ////����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            //if (stockmoveWork.UpdateDateTime > DateTime.MinValue)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            //    sqlCommand.Cancel();
                            //    if (myReader.IsClosed == false) myReader.Close();
                            //    return status;
                            //}
                            OutputClcLog(string.Format("�݌Ɉړ��`�[INSERT �݌Ɉړ��`�[�ԍ�={0} �݌Ɉړ��`�[�s�ԍ�={1} �݌Ɉړ��`��={2} �ړ����={3}", stockmoveWork.StockMoveSlipNo, stockmoveWork.StockMoveRowNo, stockmoveWork.StockMoveFormal, stockmoveWork.MoveStatus));// ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�
                            StockMoveWork defStockMoveWork = stockmoveWork;
                            DefstockMoveWorkList.Add(defStockMoveWork);

                            #region INSERT�N�G��
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKMOVERF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVEFORMALRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVESLIPNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVEROWNORF" + Environment.NewLine;
                            selectTxt += "  ,UPDATESECCDRF" + Environment.NewLine;
                            selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,BFSECTIONGUIDESNMRF" + Environment.NewLine;
                            selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
                            selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
                            selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,AFSECTIONGUIDESNMRF" + Environment.NewLine;
                            selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
                            selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTSCDLDAYRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTFIXDAYRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALGOODSDAYRF" + Environment.NewLine;
                            selectTxt += "  ,INPUTDAYRF" + Environment.NewLine;
                            selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMVEMPCODERF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMVEMPNAMERF" + Environment.NewLine;
                            selectTxt += "  ,SHIPAGENTCDRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPAGENTNMRF" + Environment.NewLine;
                            selectTxt += "  ,RECEIVEAGENTCDRF" + Environment.NewLine;
                            selectTxt += "  ,RECEIVEAGENTNMRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,MOVECOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                            selectTxt += "  ,LISTPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,OUTLINERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSENOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVEPRICERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVEROWNO" + Environment.NewLine;
                            selectTxt += "  ,@UPDATESECCD" + Environment.NewLine;
                            selectTxt += "  ,@BFSECTIONCODE" + Environment.NewLine; 
                            selectTxt += "  ,@BFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += "  ,@BFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += "  ,@BFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += "  ,@AFSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@AFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += "  ,@AFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += "  ,@AFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTSCDLDAY" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTFIXDAY" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALGOODSDAY" + Environment.NewLine;
                            selectTxt += "  ,@INPUTDAY" + Environment.NewLine;
                            selectTxt += "  ,@MOVESTATUS" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMVEMPCODE" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMVEMPNAME" + Environment.NewLine;
                            selectTxt += "  ,@SHIPAGENTCD" + Environment.NewLine;
                            selectTxt += "  ,@SHIPAGENTNM" + Environment.NewLine;
                            selectTxt += "  ,@RECEIVEAGENTCD" + Environment.NewLine;
                            selectTxt += "  ,@RECEIVEAGENTNM" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSNM" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@MAKERNAME" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNAME" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@MOVECOUNT" + Environment.NewLine;
                            selectTxt += "  ,@BFSHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@AFSHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSFULLNAME" + Environment.NewLine;
                            selectTxt += "  ,@LISTPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@OUTLINE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSENOTE1" + Environment.NewLine;
                            selectTxt += "  ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVEPRICE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            #endregion

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = selectTxt;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
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
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockmoveWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.LogicalDeleteCode);
                        paraStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        paraStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        paraStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                        paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdateSecCd);
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfSectionCode);
                        paraBfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfSectionGuideSnm);
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfEnterWarehCode);
                        paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfEnterWarehName);
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfSectionCode);
                        paraAfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfSectionGuideSnm);
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfEnterWarehCode);
                        paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfEnterWarehName);
                        if (stockmoveWork.StockMoveFormal == 3 || stockmoveWork.StockMoveFormal == 4)
                        {
                            paraShipmentScdlDay.Value = 0;
                            paraShipmentFixDay.Value = 0;
                            paraMoveStatus.Value = 9; // ADD 2009/07/08
                        }
                        else
                        {
                            paraShipmentScdlDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ShipmentScdlDay);
                            paraShipmentFixDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ShipmentFixDay);
                            paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.MoveStatus); // ADD 2009/07/08
                        }
                        // �C�� 2009/07/08 >>>
                        //paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ArrivalGoodsDay);
                        if (stockmoveWork.ArrivalGoodsDay == DateTime.MinValue)
                        {
                            paraArrivalGoodsDay.Value = 0;
                        }
                        else
                        {
                            paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ArrivalGoodsDay);
                        }
                        // �C�� 2009/07/08 <<<
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.InputDay);
                        //paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.MoveStatus); // DEL 2009/07/08
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.StockMvEmpCode);
                        paraStockMvEmpName.Value = SqlDataMediator.SqlSetString(stockmoveWork.StockMvEmpName);
                        paraShipAgentCd.Value = SqlDataMediator.SqlSetString(stockmoveWork.ShipAgentCd);
                        paraShipAgentNm.Value = SqlDataMediator.SqlSetString(stockmoveWork.ShipAgentNm);
                        paraReceiveAgentCd.Value = SqlDataMediator.SqlSetString(stockmoveWork.ReceiveAgentCd);
                        paraReceiveAgentNm.Value = SqlDataMediator.SqlSetString(stockmoveWork.ReceiveAgentNm);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.SupplierCd);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockmoveWork.SupplierSnm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockmoveWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockmoveWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockmoveWork.GoodsName);
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockmoveWork.GoodsNameKana);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockDiv);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockmoveWork.StockUnitPriceFl);
                        paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.TaxationDivCd);
                        paraMoveCount.Value = SqlDataMediator.SqlSetDouble(stockmoveWork.MoveCount);
                        paraBfShelfNo.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfShelfNo);
                        paraAfShelfNo.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfShelfNo);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockmoveWork.BLGoodsFullName);
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockmoveWork.ListPriceFl);
                        paraOutline.Value = SqlDataMediator.SqlSetString(stockmoveWork.Outline);
                        paraWarehouseNote1.Value = SqlDataMediator.SqlSetString(stockmoveWork.WarehouseNote1);
                        paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.SlipPrintFinishCd);
                        paraStockMovePrice.Value = SqlDataMediator.SqlSetInt64(stockmoveWork.StockMovePrice);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmoveWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //ADD by Liangsd   2011/08/24----------------->>>>>>>>>>
                if (ex.Number == 2627)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //ADD by Liangsd   2011/08/24-----------------<<<<<<<<<<
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("�`�[�o�^�G���[ status={0} �G���[���={1}", status, ex.Message));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
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

            stockMoveWorkList = al;

            return status;
        }

        /// <summary>
        /// �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�
        /// </summary>
        /// <param name="objstockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.03.11</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteSlipPrintFinishCd(ref object objstockMoveWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList stockMoveWorkList = objstockMoveWork as ArrayList;

            string resNm = string.Empty;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //resNm = GetResourceName((stockMoveWorkList[0] as StockMoveWork).EnterpriseCode);
                string enterpriseCode = (stockMoveWorkList[0] as StockMoveWork).EnterpriseCode;
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //return status;
                    string retMsg = string.Empty;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteSlipPrintFinishCd_Lock:{0}", retMsg), status);
                    return status;
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

                //�`�[���s�ϋ敪�X�V���\�b�h�Ăяo��
                status = WriteSlipPrintFinishCd(ref stockMoveWorkList, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.WriteSlipPrintFinishCd Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //�`�o�A�����b�N
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

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
        /// �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.03.11</br>
        public int WriteSlipPrintFinishCd(ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteSlipPrintFinishCdProc(ref stockMoveWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ��f�[�^�̓`�[���s�ϋ敪�݂̂��X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.03.11</br>
        private int WriteSlipPrintFinishCdProc(ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = "";

                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                        selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            selectTxt = "";
                            selectTxt += "UPDATE STOCKMOVERF" + Environment.NewLine;
                            selectTxt += "SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", SLIPPRINTFINISHCDRF=@SLIPPRINTFINISHCD" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                            findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //�V�K�ǉ��͍s��Ȃ�
                            if (myReader.IsClosed == false) myReader.Close();
                            continue;
                        }

                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId2);
                        paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.SlipPrintFinishCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmoveWork);
                    }
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockMoveWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �݌Ɉړ�����_���폜���܂�
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ�����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int LogicalDelete(ref object stockMoveWork)
        {
            return LogicalDeleteStockMove(ref stockMoveWork, 0);
        }

        /// <summary>
        /// �_���폜�݌Ɉړ����𕜊����܂�
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌Ɉړ����𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int RevivalLogicalDelete(ref object stockMoveWork)
        {
            return LogicalDeleteStockMove(ref stockMoveWork, 1);
        }

        /// <summary>
        /// �݌Ɉړ����̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ����̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        private int LogicalDeleteStockMove(ref object stockMoveWork, int procMode)
        {
            #region �폜
            /*
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockMoveList = null;

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ɉړ��}�X�^
                            if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                        }
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (stockMoveList != null)
                {
                    status = LogicalDeleteStockMoveProc(ref stockMoveList, procMode, ref sqlConnection, ref sqlTransaction);
                    retList.Add(stockMoveList);
                }

                stockMoveWork = null;
                stockMoveWork = retList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "StockMoveDB.LogicalDeleteStockMove :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
            */
            #endregion
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retMsg = "";
            string retItemInfo = "";

            string resNm = "";
            try
            {
                ArrayList stockMoveList = null;
                ArrayList stockList = null;             //�݌Ƀ��X�g
                ArrayList stockAcPayHistList = null;    //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList = null;      //�X�V�����݌Ɉړ����X�g
                ArrayList defStockList = null;   //�X�V�O�݌Ƀ��X�g

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<
                // ���_�Ԕ����f�[�^object
                object orderDataDicObj = null;
                // �I�v�V�������obj
                object psObj = null;

                // ���_�Ԕ����f�[�^��Dictionary�̏�����
                Dictionary<string, ArrayList> orderDataDic = null;
                // �I�v�V�������̏�����
                int ps = 0;
                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<
                for (int i = 0; i < csaList.Count; i++)
                {
                    // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                    if (csaList[i] is Dictionary<string, ArrayList>)
                    {
                        // ���_�Ԕ����f�[�^��Dictionary�̃Z�b�g
                        orderDataDic = csaList[i] as Dictionary<string, ArrayList>;
                        // ���_�Ԕ����f�[�^object�̃Z�b�g
                        orderDataDicObj = csaList[i];
                    }
                    else if (csaList[i] is int)
                    {
                        // �I�v�V�������obj�̃Z�b�g
                        ps = Convert.ToInt32(csaList[i]);
                        // �I�v�V�������̃Z�b�g
                        psObj = csaList[i];
                    }
                    else
                    {
                        ArrayList wkal = csaList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //�݌Ɉړ��}�X�^
                                if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                            }
                        }
                    }
                    // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

                    // ---- DEL K2013/12/25 ���N�n�� ---- >>>>>
                    //ArrayList wkal = csaList[i] as ArrayList;
                    //if (wkal != null)
                    //{
                    //    if (wkal.Count > 0)
                    //    {
                    //        //�݌Ɉړ��}�X�^
                    //        if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                    //    }
                    //}
                    // ---- DEL K2013/12/25 ���N�n�� ---- <<<<<
                }

                // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                // �p�����[�^�[�̋��_�Ԕ����f�[�^���폜����
                if (orderDataDicObj != null)
                {
                    csaList.Remove(orderDataDicObj);
                }

                // �p�����[�^�[�̃I�v�V���������폜����
                if (psObj != null)
                {
                    csaList.Remove(psObj);
                }
                // ---- ADD K2013/12/25 ���N�n�� ---- <<<<


                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                // �o�ɃV�X�e�����b�N
                ShareCheckInfo bfinfo = new ShareCheckInfo();
                bfinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.BfEnterWarehCode);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    status = this.ShareCheck(bfinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.LogicalDeleteStockMove_ShareCheckLocke_bfinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != 0) return status = 851;

                // ���ɃV�X�e�����b�N
                ShareCheckInfo afinfo = new ShareCheckInfo();
                afinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.AfEnterWarehCode);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    status = this.ShareCheck(afinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.LogicalDeleteStockMove_ShareCheckLocke_afinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != 0) return status = 851;
                // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                ////�`�o���b�N
                //resNm = GetResourceName(enterpriseCode);
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.LogicalDeleteStockMove_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                    return status;
                }

                try
                {

                    //�݌Ɉړ��f�[�^�_���폜����
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = LogicalDeleteStockMoveProc(ref stockMoveList, out defStockMoveList, procMode, ref sqlConnection, ref sqlTransaction);

                    }

                    //�݌Ɍn�X�V�p�p�����[�^�쐬
                    //�f�[�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                        status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��

                    //�݌Ƀf�[�^�X�V
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.Delete(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                        // �t�^�o�ʐ��p�̃L�[�ɃI�v�V�����R�[�h�������̏ꍇ(�I�v�V�����R�[�h�FOPT-CPM0130)
                        if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count > 0)
                        {
                            status = UpdateSecOrderDtWork((int)ct_ProcMode.Delete, stockMoveList, orderDataDic, ref sqlConnection, ref sqlTransaction);
                        }
                        // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<
                    }
                }
                finally
                {
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    }
                    // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", status);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", status);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", status);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", status);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

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
        /// �݌Ɉړ����̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="DefstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ����̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int LogicalDeleteStockMoveProc(ref ArrayList stockMoveWorkList, out ArrayList DefstockMoveWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockMoveProcProc(ref stockMoveWorkList, out DefstockMoveWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ɉړ����̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="DefstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ����̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        private int LogicalDeleteStockMoveProcProc(ref ArrayList stockMoveWorkList, out ArrayList DefstockMoveWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            DefstockMoveWorkList = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectTxt = "";

            try
            {
                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        //OutputClcLog(string.Format("�폜�`�[��� �݌Ɉړ��`�[�ԍ�={0}", stockmoveWork.StockMoveSlipNo));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  *" + Environment.NewLine;
                        selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockmoveWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            #region �݌Ƀ��X�g���݌ɍ������X�g
                            //�X�V�O�̍݌Ɉړ��f�[�^���擾
                            StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                            defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                            // --- ADD �O�� 2012/07/10 ---------->>>>>
                            defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                            // --- ADD �O�� 2012/07/10 ----------<<<<<

                            DefstockMoveWorkList.Add(defStockMoveWork);
                            #endregion


                            selectTxt = "";
                            selectTxt += "UPDATE STOCKMOVERF" + Environment.NewLine;
                            selectTxt += "SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                            findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) stockmoveWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else stockmoveWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockmoveWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else if (logicalDelCd == 9) stockmoveWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmoveWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("�݌Ɉړ����̘_���폜�G���[ status={0} �G���[���={1}", status, ex.Message));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockMoveWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �݌Ɉړ����𕨗��폜���܂�(�݌Ɉړ����͂͘_���폜�ɕύX�������ߖ��g�p)
        /// </summary>
        /// <param name="stockMoveWork">�݌Ɉړ����I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ɉړ����𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int Delete(ref object stockMoveWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retMsg = "";
            string retItemInfo = "";
            // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
            // ���_�Ԕ����f�[�^��Dictionary�̏�����
            Dictionary<string, ArrayList> orderDataDic = null;
            // �I�v�V�������̏�����
            int ps = 0;
            // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

            string resNm = "";           
            try
            {
                ArrayList stockMoveList = null;
                ArrayList stockList = null;             //�݌Ƀ��X�g
                ArrayList stockAcPayHistList = null;    //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList = null;      //�X�V�����݌Ɉړ����X�g
                ArrayList defStockList = null;   //�X�V�O�݌Ƀ��X�g

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ɉړ��}�X�^
                            if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                        }
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                // �o�ɃV�X�e�����b�N
                ShareCheckInfo bfinfo = new ShareCheckInfo();
                bfinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.BfEnterWarehCode);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    status = this.ShareCheck(bfinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Delete_ShareCheckLocke_bfinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != 0) return status = 851;

                // ���ɃV�X�e�����b�N
                ShareCheckInfo afinfo = new ShareCheckInfo();
                afinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.AfEnterWarehCode);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    status = this.ShareCheck(afinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Delete_ShareCheckLocke_afinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != 0) return status = 851;
                // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                ////�`�o���b�N
                //resNm = GetResourceName(enterpriseCode);
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.Delete:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.Delete:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                status = Lock(resNm,sqlConnection,sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.Delete_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                    return status;
                }

                try
                {
                    // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                    orderDataDic = new Dictionary<string, ArrayList>();
                    ps = 0;
                    // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

                    //�݌Ɉړ��f�[�^�폜����
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        status = DeleteStockMoveProc(stockMoveList, out defStockMoveList, ref sqlConnection, ref sqlTransaction);

                    //�݌Ɍn�X�V�p�p�����[�^�쐬
                    //�f�[�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                        status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��

                    //�݌Ƀf�[�^�X�V
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.Delete(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
                finally
                {
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.Delete_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    }

                    // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", status);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", status);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", status);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", status);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    // �V�X�e�����b�N(���_) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {

                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        sqlTransaction.Commit();
                    else
                    {
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

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
        /// �݌Ɉړ����𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmoveWorkList">�݌Ɉړ����I�u�W�F�N�g</param>
        /// <param name="DefstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ɉړ����𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p) </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        public int DeleteStockMoveProc(ArrayList stockmoveWorkList, out ArrayList DefstockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockMoveProcProc(stockmoveWorkList, out DefstockMoveWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ɉړ����𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmoveWorkList">�݌Ɉړ����I�u�W�F�N�g</param>
        /// <param name="DefstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ɉړ����𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p) </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        private int DeleteStockMoveProcProc(ArrayList stockmoveWorkList, out ArrayList DefstockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DefstockMoveWorkList = new ArrayList();//�X�V�O�㍷���p���X�g
            string selectTxt = "";

            try
            {

                for (int i = 0; i < stockmoveWorkList.Count; i++)
                {
                    StockMoveWork stockmoveWork = stockmoveWorkList[i] as StockMoveWork;

                    //OutputClcLog(string.Format("�`�[�폜��� �݌Ɉړ��`�[={0}", stockmoveWork.StockMoveSlipNo));// DEL BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή�

                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    // -- UPD 2010/06/16 ---------------------------------->>>
                    //selectTxt += "  STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                    //selectTxt += " ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                    //selectTxt += " ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "  *" + Environment.NewLine;
                    // -- UPD 2010/06/16 ----------------------------------<<<
                    selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                    selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                    selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                    SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                    SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                    findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                    findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                    findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != stockmoveWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // -- UPD 2010/06/16 ----------------------------------------------->>>
                        //�X�V�O�̍݌Ɉړ��f�[�^���擾
                        StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                        defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                        // --- ADD �O�� 2012/07/10 ---------->>>>>
                        defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                        // --- ADD �O�� 2012/07/10 ----------<<<<<

                        DefstockMoveWorkList.Add(defStockMoveWork);
                        // -- UPD 2010/06/16 -----------------------------------------------<<<

                        // -- DEL 2010/06/16 ----------------------------------->>>
                        #region
                        //#region �݌Ƀ��X�g���݌ɍ������X�g
                        //StockMoveWork defStockMoveWork = new StockMoveWork();
                        //defStockMoveWork.CreateDateTime = stockmoveWork.CreateDateTime;
                        //defStockMoveWork.UpdateDateTime = stockmoveWork.UpdateDateTime;
                        //defStockMoveWork.EnterpriseCode = stockmoveWork.EnterpriseCode;
                        //defStockMoveWork.FileHeaderGuid = stockmoveWork.FileHeaderGuid;
                        //defStockMoveWork.UpdEmployeeCode = stockmoveWork.UpdEmployeeCode;
                        //defStockMoveWork.UpdAssemblyId1 = stockmoveWork.UpdAssemblyId1;
                        //defStockMoveWork.UpdAssemblyId2 = stockmoveWork.UpdAssemblyId2;
                        //defStockMoveWork.LogicalDeleteCode = stockmoveWork.LogicalDeleteCode;
                        //defStockMoveWork.StockMoveFormal = stockmoveWork.StockMoveFormal;
                        //defStockMoveWork.StockMoveSlipNo = stockmoveWork.StockMoveSlipNo;
                        //defStockMoveWork.StockMoveRowNo = stockmoveWork.StockMoveRowNo;
                        //defStockMoveWork.UpdateSecCd = stockmoveWork.UpdateSecCd;
                        //defStockMoveWork.BfSectionCode = stockmoveWork.BfSectionCode;
                        //defStockMoveWork.BfSectionGuideSnm = stockmoveWork.BfSectionGuideSnm;
                        //defStockMoveWork.BfEnterWarehCode = stockmoveWork.BfEnterWarehCode;
                        //defStockMoveWork.BfEnterWarehName = stockmoveWork.BfEnterWarehName;
                        //defStockMoveWork.AfSectionCode = stockmoveWork.AfSectionCode;
                        //defStockMoveWork.AfSectionGuideSnm = stockmoveWork.AfSectionGuideSnm;
                        //defStockMoveWork.AfEnterWarehCode = stockmoveWork.AfEnterWarehCode;
                        //defStockMoveWork.AfEnterWarehName = stockmoveWork.AfEnterWarehName;
                        //defStockMoveWork.ShipmentScdlDay = stockmoveWork.ShipmentScdlDay;
                        //defStockMoveWork.ShipmentFixDay = stockmoveWork.ShipmentFixDay;
                        //defStockMoveWork.ArrivalGoodsDay = stockmoveWork.ArrivalGoodsDay;
                        //defStockMoveWork.InputDay = stockmoveWork.InputDay;
                        //defStockMoveWork.MoveStatus = stockmoveWork.MoveStatus;
                        //defStockMoveWork.StockMvEmpCode = stockmoveWork.StockMvEmpCode;
                        //defStockMoveWork.StockMvEmpName = stockmoveWork.StockMvEmpName;
                        //defStockMoveWork.ShipAgentCd = stockmoveWork.ShipAgentCd;
                        //defStockMoveWork.ShipAgentNm = stockmoveWork.ShipAgentNm;
                        //defStockMoveWork.ReceiveAgentCd = stockmoveWork.ReceiveAgentCd;
                        //defStockMoveWork.ReceiveAgentNm = stockmoveWork.ReceiveAgentNm;
                        //defStockMoveWork.SupplierCd = stockmoveWork.SupplierCd;
                        //defStockMoveWork.SupplierSnm = stockmoveWork.SupplierSnm;
                        //defStockMoveWork.GoodsMakerCd = stockmoveWork.GoodsMakerCd;
                        //defStockMoveWork.MakerName = stockmoveWork.MakerName;
                        //defStockMoveWork.GoodsNo = stockmoveWork.GoodsNo;
                        //defStockMoveWork.GoodsName = stockmoveWork.GoodsName;
                        //defStockMoveWork.GoodsNameKana = stockmoveWork.GoodsNameKana;
                        //defStockMoveWork.StockDiv = stockmoveWork.StockDiv;
                        //defStockMoveWork.StockUnitPriceFl = stockmoveWork.StockUnitPriceFl;
                        //defStockMoveWork.TaxationDivCd = stockmoveWork.TaxationDivCd;
                        //defStockMoveWork.MoveCount = stockmoveWork.MoveCount;
                        //defStockMoveWork.BfShelfNo = stockmoveWork.BfShelfNo;
                        //defStockMoveWork.AfShelfNo = stockmoveWork.AfShelfNo;
                        //defStockMoveWork.BLGoodsCode = stockmoveWork.BLGoodsCode;
                        //defStockMoveWork.BLGoodsFullName = stockmoveWork.BLGoodsFullName;
                        //defStockMoveWork.ListPriceFl = stockmoveWork.ListPriceFl;
                        //defStockMoveWork.Outline = stockmoveWork.Outline;
                        //defStockMoveWork.WarehouseNote1 = stockmoveWork.WarehouseNote1;
                        //defStockMoveWork.SlipPrintFinishCd = stockmoveWork.SlipPrintFinishCd;
                        //defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice;
                        //DefstockMoveWorkList.Add(defStockMoveWork);
                        //#endregion
                        #endregion
                        // -- DEL 2010/06/16 -----------------------------------<<<

                        selectTxt = "";
                        selectTxt += "DELETE FROM STOCKMOVERF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;
                        sqlCommand.CommandText = selectTxt;

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                    }
                    else
                    {
                        #region �݌Ƀ��X�g���݌ɍ������X�g
                        StockMoveWork defStockMoveWork = new StockMoveWork();
                        defStockMoveWork.CreateDateTime = stockmoveWork.CreateDateTime;
                        defStockMoveWork.UpdateDateTime = stockmoveWork.UpdateDateTime;
                        defStockMoveWork.EnterpriseCode = stockmoveWork.EnterpriseCode;
                        defStockMoveWork.FileHeaderGuid = stockmoveWork.FileHeaderGuid;
                        defStockMoveWork.UpdEmployeeCode = stockmoveWork.UpdEmployeeCode;
                        defStockMoveWork.UpdAssemblyId1 = stockmoveWork.UpdAssemblyId1;
                        defStockMoveWork.UpdAssemblyId2 = stockmoveWork.UpdAssemblyId2;
                        defStockMoveWork.LogicalDeleteCode = stockmoveWork.LogicalDeleteCode;
                        defStockMoveWork.StockMoveFormal = stockmoveWork.StockMoveFormal;
                        defStockMoveWork.StockMoveSlipNo = stockmoveWork.StockMoveSlipNo;
                        defStockMoveWork.StockMoveRowNo = stockmoveWork.StockMoveRowNo;
                        defStockMoveWork.UpdateSecCd = stockmoveWork.UpdateSecCd;
                        defStockMoveWork.BfSectionCode = stockmoveWork.BfSectionCode;
                        defStockMoveWork.BfSectionGuideSnm = stockmoveWork.BfSectionGuideSnm;
                        defStockMoveWork.BfEnterWarehCode = stockmoveWork.BfEnterWarehCode;
                        defStockMoveWork.BfEnterWarehName = stockmoveWork.BfEnterWarehName;
                        defStockMoveWork.AfSectionCode = stockmoveWork.AfSectionCode;
                        defStockMoveWork.AfSectionGuideSnm = stockmoveWork.AfSectionGuideSnm;
                        defStockMoveWork.AfEnterWarehCode = stockmoveWork.AfEnterWarehCode;
                        defStockMoveWork.AfEnterWarehName = stockmoveWork.AfEnterWarehName;
                        defStockMoveWork.ShipmentScdlDay = stockmoveWork.ShipmentScdlDay;
                        defStockMoveWork.ShipmentFixDay = stockmoveWork.ShipmentFixDay;
                        defStockMoveWork.ArrivalGoodsDay = stockmoveWork.ArrivalGoodsDay;
                        defStockMoveWork.InputDay = stockmoveWork.InputDay;
                        defStockMoveWork.MoveStatus = stockmoveWork.MoveStatus;
                        defStockMoveWork.StockMvEmpCode = stockmoveWork.StockMvEmpCode;
                        defStockMoveWork.StockMvEmpName = stockmoveWork.StockMvEmpName;
                        defStockMoveWork.ShipAgentCd = stockmoveWork.ShipAgentCd;
                        defStockMoveWork.ShipAgentNm = stockmoveWork.ShipAgentNm;
                        defStockMoveWork.ReceiveAgentCd = stockmoveWork.ReceiveAgentCd;
                        defStockMoveWork.ReceiveAgentNm = stockmoveWork.ReceiveAgentNm;
                        defStockMoveWork.SupplierCd = stockmoveWork.SupplierCd;
                        defStockMoveWork.SupplierSnm = stockmoveWork.SupplierSnm;
                        defStockMoveWork.GoodsMakerCd = stockmoveWork.GoodsMakerCd;
                        defStockMoveWork.MakerName = stockmoveWork.MakerName;
                        defStockMoveWork.GoodsNo = stockmoveWork.GoodsNo;
                        defStockMoveWork.GoodsName = stockmoveWork.GoodsName;
                        defStockMoveWork.GoodsNameKana = stockmoveWork.GoodsNameKana;
                        defStockMoveWork.StockDiv = stockmoveWork.StockDiv;
                        defStockMoveWork.StockUnitPriceFl = stockmoveWork.StockUnitPriceFl;
                        defStockMoveWork.TaxationDivCd = stockmoveWork.TaxationDivCd;
                        defStockMoveWork.MoveCount = 0;
                        defStockMoveWork.BfShelfNo = stockmoveWork.BfShelfNo;
                        defStockMoveWork.AfShelfNo = stockmoveWork.AfShelfNo;
                        defStockMoveWork.BLGoodsCode = stockmoveWork.BLGoodsCode;
                        defStockMoveWork.BLGoodsFullName = stockmoveWork.BLGoodsFullName;
                        defStockMoveWork.ListPriceFl = stockmoveWork.ListPriceFl;
                        defStockMoveWork.Outline = stockmoveWork.Outline;
                        defStockMoveWork.WarehouseNote1 = stockmoveWork.WarehouseNote1;
                        defStockMoveWork.SlipPrintFinishCd = stockmoveWork.SlipPrintFinishCd;
                        defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice;
                        DefstockMoveWorkList.Add(defStockMoveWork);
                        #endregion

                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("���ד`�[�̍폜�G���[ status={0} �G���[���={1}", status, ex.Message));// ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή�
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
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockMoveWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: 2012/05/22 wangf </br>
        /// <br>           : 10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMoveSlipSearchCondWork stockMoveWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "STOCKM.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCKM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCKM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //�X�V���_�R�[�h
            if (stockMoveWork.SectionCode != "")
            {
                retstring += "AND STOCKM.UPDATESECCDRF=@UPDATESECCD ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.SectionCode);
            }

            //�݌Ɉړ��`�[�ԍ�
            if (stockMoveWork.StockMoveSlipNo > 0)
            {
                retstring += "AND STOCKM.STOCKMOVESLIPNORF=@STOCKMOVESLIPNO ";
                SqlParameter paraStockMoveSlipNo = sqlCommand.Parameters.Add("@STOCKMOVESLIPNO", SqlDbType.Int);
                paraStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.StockMoveSlipNo);
            }

            //�݌Ɉړ����͏]�ƈ��R�[�h
            if (stockMoveWork.StockMvEmpCode != "")
            {
                retstring += "AND STOCKMVEMPCODERF=@STOCKMVEMPCODE ";
                SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@STOCKMVEMPCODE", SqlDbType.NChar);
                paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.StockMvEmpCode);
            }

            //�o�גS���]�ƈ��R�[�h
            if (stockMoveWork.ShipAgentCd != "")
            {
                retstring += "AND SHIPAGENTCDRF=@SHIPAGENTCD ";
                SqlParameter paraShipAgentCd = sqlCommand.Parameters.Add("@SHIPAGENTCD", SqlDbType.NChar);
                paraShipAgentCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.ShipAgentCd);
            }

            //����S���]�ƈ��R�[�h
            if (stockMoveWork.ReceiveAgentCd != "")
            {
                retstring += "AND RECEIVEAGENTCDRF=@RECEIVEAGENTCD ";
                SqlParameter paraReceiveAgentCd = sqlCommand.Parameters.Add("@RECEIVEAGENTCD", SqlDbType.NChar);
                paraReceiveAgentCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.ReceiveAgentCd);
            }

            //�o�ח\��J�n��
            if (stockMoveWork.ShipmentScdlStDay != DateTime.MinValue)
            {
                retstring += "AND SHIPMENTSCDLDAYRF>=@SHIPMENTSCDLSTDAY ";
                SqlParameter paraShipmentScdlStDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLSTDAY", SqlDbType.Int);
                paraShipmentScdlStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentScdlStDay);
            }

            //�o�ח\��I����
            if (stockMoveWork.ShipmentScdlEdDay != DateTime.MinValue)
            {
                retstring += "AND SHIPMENTSCDLDAYRF<=@SHIPMENTSCDLEDDAY ";
                SqlParameter paraShipmentScdlEdDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLEDDAY", SqlDbType.Int);
                paraShipmentScdlEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentScdlEdDay);
            }

            //�ړ������_�R�[�h
            if (stockMoveWork.BfSectionCode != "")
            {                                 
                retstring += "AND BFSECTIONCODERF=@BFSECTIONCODE ";
                SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfSectionCode);
            }

            //�ړ����q�ɃR�[�h
            if (stockMoveWork.BfEnterWarehCode != "")
            {
                retstring += "AND BFENTERWAREHCODERF=@BFENTERWAREHCODE ";
                SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfEnterWarehCode);
            }

            //�ړ��拒�_�R�[�h
            if (stockMoveWork.AfSectionCode != "")
            {
                retstring += "AND AFSECTIONCODERF=@AFSECTIONCODE ";
                SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfSectionCode);
            }

            //�ړ���q�ɃR�[�h
            if (stockMoveWork.AfEnterWarehCode != "")
            {
                retstring += "AND AFENTERWAREHCODERF=@AFENTERWAREHCODE ";
                SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfEnterWarehCode);
            }
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //�o�׊m���
            if (stockMoveWork.CallerFunction == 1 && stockMoveWork.StockMoveFixCode == 2 )
            {
                //�o�׊m��or���׊J�n��
                if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                {
                    retstring += " AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2 AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF>=@SHIPMENTFIXSTDAY))) ";
                    SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                    paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                }

                //�o�׊m��or���׏I����
                if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                {
                    retstring += " AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2 AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF<=@SHIPMENTFIXEDDAY))) ";
                    SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                    paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                }
                return retstring;
            }
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<


            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (stockMoveWork.MoveStatus != null)
                {
                    wkstring = "";
                    foreach (int str in stockMoveWork.MoveStatus)
                    {
                        if (stockMoveWork.MoveStatus.Length == 1)
                        {
                            if (str == 9)
                            {
                                //���׊J�n��
                                if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                                {
                                    retstring += "AND ARRIVALGOODSDAYRF>=@ARRIVALGOODSSTDAY ";
                                    SqlParameter paraArrivalGoodsStDay = sqlCommand.Parameters.Add("@ARRIVALGOODSSTDAY", SqlDbType.Int);
                                    paraArrivalGoodsStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                                }

                                //���׏I����
                                if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                                {
                                    retstring += "AND ARRIVALGOODSDAYRF<=@ARRIVALGOODSEDDAY ";
                                    SqlParameter paraArrivalGoodsEdDay = sqlCommand.Parameters.Add("@ARRIVALGOODSEDDAY", SqlDbType.Int);
                                    paraArrivalGoodsEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                                }
                            }
                            else
                            {
                                //�o�׊m��J�n��
                                if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                                {
                                    retstring += "AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY ";
                                    SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                                    paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                                }

                                //�o�׊m��I����
                                if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                                {
                                    retstring += "AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY ";
                                    SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                                    paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                                }
                            }
                        }
                        else
                        {
                            //�o�׊m��or���׊J�n��
                            if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                            {
                                retstring += "AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF>=@SHIPMENTFIXSTDAY)))";
                                SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                                paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                            }

                            //�o�׊m��or���׏I����
                            if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                            {
                                retstring += "AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF<=@SHIPMENTFIXEDDAY))) ";
                                SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                                paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                if (stockMoveWork.SlipDiv == 1)
                {
                    //�o�׊m��J�n��
                    if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                    {
                        retstring += "AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY ";
                        SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                        paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                    }

                    //�o�׊m��I����
                    if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                    {
                        retstring += "AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY ";
                        SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                        paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                    }
                }
                else if (stockMoveWork.SlipDiv == 2)
                {
                    //���׊J�n��
                    if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                    {
                        retstring += "AND ARRIVALGOODSDAYRF>=@ARRIVALGOODSSTDAY ";
                        SqlParameter paraArrivalGoodsStDay = sqlCommand.Parameters.Add("@ARRIVALGOODSSTDAY", SqlDbType.Int);
                        paraArrivalGoodsStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                    }

                    //���׏I����
                    if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                    {
                        retstring += "AND ARRIVALGOODSDAYRF<=@ARRIVALGOODSEDDAY ";
                        SqlParameter paraArrivalGoodsEdDay = sqlCommand.Parameters.Add("@ARRIVALGOODSEDDAY", SqlDbType.Int);
                        paraArrivalGoodsEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                    }
                }
            }

            // �`�[�ďo
            // ���׊m�肠��
            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (stockMoveWork.SlipDiv == 1)
                {
                    retstring += " AND (STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF = 2 ";
                }
                else if (stockMoveWork.SlipDiv == 2)
                {
                    //�ړ����
                    if (stockMoveWork.MoveStatus != null)
                    {
                        wkstring = "";
                        foreach (int str in stockMoveWork.MoveStatus)
                        {
                            if (stockMoveWork.MoveStatus.Length == 1)
                            {

                                if (str == 2)
                                    retstring += " AND (STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF = 2 ";
                                else if (str == 9)
                                    retstring += " AND (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) ";
                            }
                            else
                            {
                                retstring += " AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF = 2) OR (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4))" ;
                                break;
                            }
                        }
                    }
                }
            }
            // ���׊m��Ȃ�
            else
            {
                if (stockMoveWork.SlipDiv == 1)
                {
                    retstring += " AND ((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2) ";
                }
                else if (stockMoveWork.SlipDiv == 2)
                {
                    retstring += " AND (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) ";
                }
                else if (stockMoveWork.SlipDiv == -1)
                {
                    retstring += " AND ( ((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2) OR (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4)) ";
                }
            }

            /*
            //�ړ����
            if (stockMoveWork.MoveStatus != null)
            {
                wkstring = "";
                foreach (int str in stockMoveWork.MoveStatus)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND MOVESTATUSRF IN (" + wkstring + ") ";
                }

            }
            */
            
            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockMoveWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMoveWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// </remarks>
        private StockMoveWork CopyToStockMoveWorkFromReader(ref SqlDataReader myReader)
        {
            StockMoveWork wkStockMoveWork = new StockMoveWork();

            #region �N���X�֊i�[
            wkStockMoveWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockMoveWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockMoveWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockMoveWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockMoveWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockMoveWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockMoveWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockMoveWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockMoveWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
            wkStockMoveWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            wkStockMoveWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            wkStockMoveWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            wkStockMoveWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
            wkStockMoveWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
            wkStockMoveWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
            wkStockMoveWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            wkStockMoveWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
            wkStockMoveWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
            wkStockMoveWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
            wkStockMoveWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            wkStockMoveWork.ShipmentScdlDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
            wkStockMoveWork.ShipmentFixDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            wkStockMoveWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockMoveWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockMoveWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            wkStockMoveWork.StockMvEmpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
            wkStockMoveWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
            wkStockMoveWork.ShipAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTCDRF"));
            wkStockMoveWork.ShipAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTNMRF"));
            wkStockMoveWork.ReceiveAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTCDRF"));
            wkStockMoveWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
            wkStockMoveWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockMoveWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockMoveWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockMoveWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockMoveWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockMoveWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockMoveWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkStockMoveWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockMoveWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockMoveWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkStockMoveWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            wkStockMoveWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            wkStockMoveWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            wkStockMoveWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockMoveWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockMoveWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
            wkStockMoveWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            wkStockMoveWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
            wkStockMoveWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            wkStockMoveWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
            #endregion

            return wkStockMoveWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockMoveWork[] StockMoveWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is StockMoveWork)
                    {
                        StockMoveWork wkStockMoveWork = paraobj as StockMoveWork;
                        if (wkStockMoveWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockMoveWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockMoveWorkArray = (StockMoveWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockMoveWork[]));
                        }
                        catch (Exception) { }
                        if (StockMoveWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockMoveWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockMoveWork wkStockMoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockMoveWork));
                                if (wkStockMoveWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockMoveWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.19</br>
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

        #region �݌Ɉړ��f�[�^���݌Ƀf�[�^�E�݌Ɏ󕥗����f�[�^
        
        /// <summary>
        /// �f�[�^�ϊ�(����)����
        /// </summary>
        /// <param name="procMode">�����敪</param>
        /// <param name="createHisData">�󕥗����쐬�敪</param>
        /// <param name="stockMoveFormal">�݌Ɉړ��`��</param>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <param name="stockMoveList">�݌Ɉړ����X�g</param>
        /// <param name="bFStockMoveList">�X�V�O�݌Ɉړ����X�g</param>
        /// <param name="defStockList">�݌ɍ������X�g</param>
        /// <param name="defStockMoveList">�݌Ɉړ��������X�g</param>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <param name="stockAcPayHistList">�݌Ɏ󕥗������X�g</param>
        /// <param name="orderDataDic">orderDataDic</param>
        /// <param name="ps">ps</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2010/11/15 ������</br>
        /// <br>             ��Q���ǑΉ������u�Q�v�̑Ή�</br>
        //private int TransStockMoveToStock(int procMode, bool createHisData, int stockMoveFormal, int stockMoveSlipNo, ArrayList stockMoveList, ArrayList defStockMoveList, ArrayList bFStockMoveList, ArrayList defStockList, out ArrayList stockList, out ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL K2013/12/25 ���N�n��
        private int TransStockMoveToStock(int procMode, bool createHisData, int stockMoveFormal, int stockMoveSlipNo, ArrayList stockMoveList, ArrayList defStockMoveList, ArrayList bFStockMoveList, ArrayList defStockList, out ArrayList stockList, out ArrayList stockAcPayHistList, Dictionary<string, ArrayList> orderDataDic, int ps, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD K2013/12/25 ���N�n��
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            stockList = new ArrayList();            //�݌Ƀ��X�g
            stockAcPayHistList = new ArrayList();   //�݌Ɏ󕥗������X�g
            Dictionary<string, StockWork> BfStockDic = new Dictionary<string, StockWork>();
            Dictionary<string, StockWork> AfStockDic = new Dictionary<string, StockWork>();

            ArrayList originBfStockList = new ArrayList();

            //---���f�[�^�̊m�F---
            if (stockMoveList == null) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (stockMoveList.Count <= 0) return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ////�݌Ɉړ����X�g�̃\�[�g
            StockMoveWorkComparer stockMoveWorkComparer = new StockMoveWorkComparer();
            stockMoveList.Sort(stockMoveWorkComparer);
            defStockMoveList.Sort(stockMoveWorkComparer);
            if (bFStockMoveList != null)
                bFStockMoveList.Sort(stockMoveWorkComparer);
            //���݂̈ړ��X�e�[�^�X���擾
            int moveStatus = ((StockMoveWork)((ArrayList)stockMoveList)[0]).MoveStatus;

            //�݌Ɉړ��f�[�^�����[�v
            for (int j = 0; j < stockMoveList.Count; j++)
            {
                //�݌Ɉړ��L���X�g�i�݌Ɉړ����X�g����j
                StockMoveWork wkStockMoveWork = stockMoveList[j] as StockMoveWork;
                // ---ADD 2010/11/15---------------->>>>>
                // ���׍��ڂ������ύX���Ȃ��ꍇ(�݌Ɏ󕥃f�[�^�쐬�敪=�P)�A�݌Ɏ󕥗����f�[�^�쐬���Ȃ�
                if (wkStockMoveWork.CreateHistDiv == 1)
                {
                    createHisData = false;
                }
                else
                {
                    createHisData = true;
                }
                // ---ADD 2010/11/15----------------<<<<<

                //�݌Ɉړ��L���X�g�i�݌Ɉړ��������X�g����j
                StockMoveWork wkdefStockMoveWork = new StockMoveWork();
                if (defStockMoveList.Count > j)
                    wkdefStockMoveWork = defStockMoveList[j] as StockMoveWork;

                StockMoveWork wkbfStockMoveWork = new StockMoveWork();
                if (bFStockMoveList != null && bFStockMoveList.Count > j)
                    wkbfStockMoveWork = bFStockMoveList[j] as StockMoveWork;

                //�݌Ɏ󕥗����f�[�^�쐬
                if (createHisData)
                {
                    MakeStockAcPayList(ref stockAcPayHistList, wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal, sqlConnection, sqlTransaction);
                }

                // �݌Ƀ}�X�^���쐬
                //MakeStockList(ref stockList, ref BfStockDic, ref AfStockDic, wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                MakeStockList(ref stockList, ref BfStockDic, ref AfStockDic, wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��

                #region DELETE
                /*
                else //�q�Ɉړ�
                    {

                        StockWork originStockWork = null;
                        //�ړ����p�݌Ƀf�[�^�쐬
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, originStockWork, stockMngTtlStWork, wkdefStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkBfStockWork), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkdefStockMoveWork)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originStockWork, stockMngTtlStWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        }

                        //�ړ���p�݌Ƀf�[�^�쐬
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkdefStockMoveWork.MoveStatus, procMode, null);
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkAfStockWork), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkdefStockMoveWork)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                        }

                    }
                
                }
                */
                #endregion
            }
            return status;
            
        }

        /// <summary>
        /// �݌Ƀ}�X�^���쐬����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2016/04/26 ����</br>
        /// <br>             Redmine#48729 �݌Ɉړ����͂̓��׎����Q�̑Ή�</br>
        /// </remarks>
        //private void MakeStockList(ref ArrayList stockList, ref Dictionary<string, StockWork> BfStockDic, ref Dictionary<string, StockWork> AfStockDic, StockMoveWork wkStockMoveWork, StockMoveWork wkbfStockMoveWork, StockMoveWork wkdefStockMoveWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL K2013/12/25 ���N�n��
        private void MakeStockList(ref ArrayList stockList, ref Dictionary<string, StockWork> BfStockDic, ref Dictionary<string, StockWork> AfStockDic, StockMoveWork wkStockMoveWork, StockMoveWork wkbfStockMoveWork, StockMoveWork wkdefStockMoveWork, int procMode, Dictionary<string, ArrayList> orderDataDic, int ps, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD K2013/12/25 ���N�n��
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //�݌Ƀf�[�^�̎擾
            //�ړ����̍݌Ƀf�[�^
            StockWork originBfStockWork = new StockWork();
            originBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
            //originBfStockWork.SectionCode = wkdefStockMoveWork.BfSectionCode;
            originBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
            originBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
            originBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
            status = _stockDB.ReadProc(ref originBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

            if (wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived && wkdefStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)//���׏���
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)   //�݌Ƀ}�X�^�����݂��Ȃ��ꍇ���V�K�쐬����悤�ɏC��
                {

                    //�ړ����p�݌Ƀf�[�^�쐬
                    if (!BfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 0)))
                    {
                        StockWork retStockWork = null;
                        StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, originBfStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        stockList.Add(wkBfStockWork);
                        BfStockDic.Add(CreateKeyString(wkStockMoveWork, 0), wkBfStockWork);
                    }
                    else
                    {
                        StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkStockMoveWork, 0)] as StockWork;
                        wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originBfStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                    }

                    // --- ADD 2012/10/02 y.wakita ----->>>>>
                    //�݌Ƀf�[�^�̎擾
                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                    {
                        //�ړ���̍݌Ƀf�[�^
                        originBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        //originBfStockWork.SectionCode = wkdefStockMoveWork.AfSectionCode;
                        originBfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        originBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        originBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        status = _stockDB.ReadProc(ref originBfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 1) && (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                    // --- ADD 2012/10/02 y.wakita -----<<<<<

                        //�ړ���p�݌Ƀf�[�^�쐬
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 ���N�n��
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 ���N�n��  
                        }
                        // --- ADD 2012/10/02 y.wakita ----->>>>>
                    }
                    // --- ADD 2012/10/02 y.wakita -----<<<<<
                }
                else
                {
                    // --- ADD 2012/10/02 y.wakita ----->>>>>
                    //�݌Ƀf�[�^�̎擾
                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                    {
                        //�ړ���̍݌Ƀf�[�^
                        originBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        //originBfStockWork.SectionCode = wkdefStockMoveWork.AfSectionCode;
                        originBfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        originBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        originBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        status = _stockDB.ReadProc(ref originBfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    // --- ADD 2012/10/02 y.wakita -----<<<<<

                    // --- ADD �O�� 2012/07/10 ---------->>>>>
                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (wkStockMoveWork.MoveStockAutoInsDiv == 0)
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 1) && (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        // --- ADD �O�� 2012/07/10 ----------<<<<<

                        //���׎��Ɉړ���̍݌Ƀf�[�^�����݂��Ȃ��ꍇ�͐V�K�쐬����()
                        originBfStockWork = null;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        //�ړ���p�݌Ƀf�[�^�쐬
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 ���N�n��
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 ���N�n��
                        }
                        // --- ADD �O�� 2012/07/10 ---------->>>>>
                    }
                    // --- ADD �O�� 2012/07/10 ----------<<<<<
                }

            }
            else if (wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving && wkdefStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)//���׃L�����Z��
            {

                    StockWork originStockWork = null;

                    // --- ADD �O�� 2012/07/10 ---------->>>>>
                    // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�A
                    // �݌Ƀf�[�^�̑��݃`�F�b�N���s���A
                    // �݌ɂ��Ȃ��ꍇ�͍݌Ƀf�[�^���쐬���Ȃ��悤�ɏC��
                    int bfstockstatus = 0;

                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1 && _isRecv == false)
                    {
                        //�ړ����̍݌Ƀf�[�^
                        StockWork writeBfStockWork = new StockWork();
                        writeBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
                        writeBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        bfstockstatus = _stockDB.ReadProc(ref writeBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    if (bfstockstatus == 0)
                    {
                        // --- ADD �O�� 2012/07/10 ----------<<<<<
                        //�ړ����p�݌Ƀf�[�^�쐬
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 0)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkStockMoveWork, 0), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkStockMoveWork, 0)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete);
                        }
                        // --- ADD �O�� 2012/07/10 ---------->>>>>
                    }
                    // --- ADD �O�� 2012/07/10 ----------<<<<<

                    // --- ADD �O�� 2012/07/10 ---------->>>>>
                    // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�A
                    // �݌Ƀf�[�^�̑��݃`�F�b�N���s���A
                    // �݌ɂ��Ȃ��ꍇ�͍݌Ƀf�[�^���쐬���Ȃ��悤�ɏC��
                    int afstockstatus = 0;

                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1 && _isRecv == false)
                    {
                        //�ړ���̍݌Ƀf�[�^
                        StockWork writeAfStockWork = new StockWork();
                        writeAfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeAfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        writeAfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeAfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        afstockstatus = _stockDB.ReadProc(ref writeAfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (bfstockstatus == 0)
                    if (afstockstatus == 0)
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        // --- ADD �O�� 2012/07/10 ----------<<<<<
                        //�ړ���p�݌Ƀf�[�^�쐬
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 1);// ADD K2013/12/25 ���N�n��  
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            //wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork,
                              //wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);  DEL 2016/4/26 ���� Redmine#48729 ���׎�������㌻�݌ɐ����X�V����Ȃ���Q�Ή�
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, 
                                wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);// ADD 2016/4/26 ���� Redmine#48729 ���׎�������㌻�݌ɐ����X�V����Ȃ���Q�Ή�
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 1);// ADD K2013/12/25 ���N�n�� 
                        }
                    // --- ADD �O�� 2012/07/10 ---------->>>>>
                    }
                    // --- ADD �O�� 2012/07/10 ----------<<<<<
            }
            #region DELETE
            //else if (wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Unshipment && wkbfStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)//�m����
            //{
            //    StockWork originStockWork = null;

            //    //�ړ����p�݌Ƀf�[�^�쐬
            //    if (!BfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork)))
            //    {
            //        StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(null, wkStockMoveWork, originStockWork, wkbfStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
            //        stockList.Add(wkBfStockWork);
            //        BfStockDic.Add(CreateKeyString(wkBfStockWork), wkBfStockWork);
            //    }
            //    else
            //    {
            //        StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkStockMoveWork)] as StockWork;
            //        wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originStockWork, wkbfStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
            //    }
            //}
            #endregion
            else
            {
                StockWork originStockWork = null;

                if (wkStockMoveWork.StockMoveFixCode == 1)
                {
                    // --- ADD �O�� 2012/07/05 ---------->>>>>
                    // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�A
                    // �݌Ƀf�[�^�̑��݃`�F�b�N���s���A
                    // �݌ɂ��Ȃ��ꍇ�͍݌Ƀf�[�^���쐬���Ȃ��悤�ɏC��
                    int bfstockstatus = 0;

                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1 && _isRecv == false)
                    {
                        //�ړ����̍݌Ƀf�[�^
                        StockWork writeBfStockWork = new StockWork();
                        writeBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
                        writeBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        bfstockstatus = _stockDB.ReadProc(ref writeBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    if (bfstockstatus == 0)
                    {
                        // --- ADD �O�� 2012/07/05 ----------<<<<<

                        //�ړ����p�݌Ƀf�[�^�쐬
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork, 0)))
                        {
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(null, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 0), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkdefStockMoveWork, 0)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        }
                        // --- ADD �O�� 2012/07/05 ---------->>>>>
                    }
                    // --- ADD �O�� 2012/07/05 ----------<<<<<


                    // -------ADD K2013/12/25 ���N�n�� -------------------------------------------->>>>>

                    if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count>0)
                    {
                        int afstockstatus = 0;

                        // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�́A�݌Ƀf�[�^�̑��݃`�F�b�N���s���悤��
                        if ((wkStockMoveWork.MoveStockAutoInsDiv == 1 || wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)
                        {
                            //�ړ���̍݌Ƀf�[�^
                            StockWork writeAfStockWork = new StockWork();
                            writeAfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                            writeAfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                            writeAfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                            writeAfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                            afstockstatus = _stockDB.ReadProc(ref writeAfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                        }

                        if ((afstockstatus == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 0))
                        {
                            //�ړ���p�݌Ƀf�[�^�쐬
                            if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                            {
                                StockWork retStockWork = null;
                                StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkdefStockMoveWork, wkdefStockMoveWork.MoveStatus, procMode /*(int)ct_ProcMode.Delete*/, null);
                                if (procMode == (int)ct_ProcMode.Delete)
                                {
                                    SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 3);
                                }
                                stockList.Add(wkAfStockWork);
                                AfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 1), wkAfStockWork);
                            }
                            else
                            {
                                StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                                if (procMode == (int)ct_ProcMode.Delete)
                                {
                                    SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 3);
                                }
                                wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkdefStockMoveWork, wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                            }
                        }
                    
                    }
                    // -------ADD 2013/12/25 ���N�n�� --------------------------------------------<<<<<
                }
                else
                {
                    int bfstockstatus = 0;

                    //if (wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3)//DEL 2011/09/05 �@#24187��M���̋��_�ɑΏۂ̃}�X�^���o�^����Ă��Ȃ��ꍇ�̕s��ɂ���
                    // --- UPD �O�� 2012/07/05 ---------->>>>>
                    //if ((wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)//ADD 2011/09/05 �@#24187��M���̋��_�ɑΏۂ̃}�X�^���o�^����Ă��Ȃ��ꍇ�̕s��ɂ���
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 1 || wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)
                    // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�́A�݌Ƀf�[�^�̑��݃`�F�b�N���s���悤�ɁA�������C��
                    // --- UPD �O�� 2012/07/05 ----------<<<<<
                    {
                        //�ړ����̍݌Ƀf�[�^
                        StockWork writeBfStockWork = new StockWork();
                        writeBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
                        writeBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        bfstockstatus = _stockDB.ReadProc(ref writeBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (bfstockstatus == 0)
                    if ((bfstockstatus == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 0))
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        //�ړ����p�݌Ƀf�[�^�쐬
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork, 0)))
                        {
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(null, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 0), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkdefStockMoveWork, 0)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        }
                    }


                    int afstockstatus = 0;

                    //if (wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3)//DEL 2011/09/05 �@#24187��M���̋��_�ɑΏۂ̃}�X�^���o�^����Ă��Ȃ��ꍇ�̕s��ɂ���
                    // --- UPD �O�� 2012/07/05 ---------->>>>>
                    //if ((wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)//ADD 2011/09/05 �@#24187��M���̋��_�ɑΏۂ̃}�X�^���o�^����Ă��Ȃ��ꍇ�̕s��ɂ���
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 1 || wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)
                    // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�́A�݌Ƀf�[�^�̑��݃`�F�b�N���s���悤�ɁA�������C��
                    // --- UPD �O�� 2012/07/05 ----------<<<<<
                    {
                        //�ړ���̍݌Ƀf�[�^
                        StockWork writeAfStockWork = new StockWork();
                        writeAfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeAfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        writeAfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeAfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        afstockstatus = _stockDB.ReadProc(ref writeAfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                    }

                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (afstockstatus == 0)
                    if ((afstockstatus == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 0))
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        //�ړ���p�݌Ƀf�[�^�쐬
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkdefStockMoveWork, wkdefStockMoveWork.MoveStatus, procMode /*(int)ct_ProcMode.Delete*/, null);
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkdefStockMoveWork, wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �󕥏��쐬�쐬����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2021/08/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>           : BLINCIDENT-2462 ���݌��ƌJ�z��������Ȃ��Ή�</br>
        /// </remarks>
        private void MakeStockAcPayList(ref ArrayList stockAcPayHistList, StockMoveWork wkStockMoveWork, StockMoveWork wkbfStockMoveWork, StockMoveWork wkdefStockMoveWork, int procMode, int stockMoveFormal, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            StockAcPayHistWork wkStockAcPayHistWork = null;

            //�ړ����A�����A�艿�A���z���ύX���ꂽ�ꍇ�̂ݎ󕥗������쐬����(���׏����A���׃L�����Z���A�o�ד`�[�폜�͖������쐬�i�C�����o���Ȃ����߁j)
            if ((wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived) ||
                ((wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving) && (wkbfStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)) ||
                (procMode == (int)ct_ProcMode.Delete) ||
                (wkStockMoveWork.MoveCount != wkbfStockMoveWork.MoveCount) ||
                (wkStockMoveWork.StockUnitPriceFl != wkbfStockMoveWork.StockUnitPriceFl) ||
                (wkStockMoveWork.ListPriceFl != wkbfStockMoveWork.ListPriceFl) ||
                (wkStockMoveWork.StockMovePrice != wkbfStockMoveWork.StockMovePrice))
            {
                int stockstatus = 0;

                // --- UPD �O�� 2012/07/05 ---------->>>>>
                //if (wkStockMoveWork.StockMoveFixCode == 2 && (stockMoveFormal == 1 || stockMoveFormal == 3))
                // --- UPD ���O 2021/08/25 BLINCIDENT-2462 ���݌��ƌJ�z��������Ȃ��Ή� ----->>>>>
                //if ((wkStockMoveWork.MoveStockAutoInsDiv == 1) || (wkStockMoveWork.StockMoveFixCode == 2 && (stockMoveFormal == 1 || stockMoveFormal == 3)))
                //// �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�́A�݌Ƀf�[�^�̑��݃`�F�b�N���s���悤�ɁA�������C��
                // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�A�݌Ƀf�[�^�`�F�b�N���s��
                if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                // --- UPD ���O 2021/08/25 BLINCIDENT-2462 ���݌��ƌJ�z��������Ȃ��Ή� -----<<<<<
                // --- UPD �O�� 2012/07/05 ----------<<<<<
                {
                    // �݌Ƀ}�X�^Read�@�Ȃ���΁A�݌Ɉړ��̍ۂ͐V�K�ǉ����Ȃ�
                    StockWork stWork = new StockWork();
                    stWork.EnterpriseCode = wkStockMoveWork.EnterpriseCode;
                    stWork.WarehouseCode = wkStockMoveWork.BfEnterWarehCode;
                    stWork.GoodsMakerCd = wkStockMoveWork.GoodsMakerCd;
                    stWork.GoodsNo = wkStockMoveWork.GoodsNo;

                    stockstatus = _stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);
                }

                if (wkStockMoveWork.StockMoveFormal == 3) wkStockMoveWork.StockMoveFormal = 1;
                else if (wkStockMoveWork.StockMoveFormal == 4) wkStockMoveWork.StockMoveFormal = 2;

                if (stockstatus == 0)
                {
                    // �݌Ɏ󕥃Z�b�g�l���
                    wkStockAcPayHistWork = CopyStockAcPayHistWorkFromStockMoveWork(wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal);
                }
            }

            if (wkStockAcPayHistWork != null)
            {
                stockAcPayHistList.Add(wkStockAcPayHistWork);
            }

            // ���׊m��Ȃ��ŏo�ɂƓ��ɂ̗������쐬
            if (wkStockMoveWork.StockMoveFixCode == 2)
            {
                int stockstatus = 0;

                // --- UPD �O�� 2012/07/05 ---------->>>>>
                //if (wkStockMoveWork.StockMoveFixCode == 2 && (wkStockMoveWork.StockMoveFormal == 1 || wkStockMoveWork.StockMoveFormal == 3))
                // --- UPD ���O 2021/08/25 BLINCIDENT-2462 ���݌��ƌJ�z��������Ȃ��Ή� ----->>>>>
                //if ((wkStockMoveWork.MoveStockAutoInsDiv == 1) || (wkStockMoveWork.StockMoveFixCode == 2 && (wkStockMoveWork.StockMoveFormal == 1 || wkStockMoveWork.StockMoveFormal == 3)))
                //// �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�́A�݌Ƀf�[�^�̑��݃`�F�b�N���s���悤�ɁA�������C��
                // �ړ����݌Ɏ����o�^�敪���u1:���Ȃ��v�̏ꍇ�A�݌Ƀf�[�^�`�F�b�N���s��
                if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                // --- UPD ���O 2021/08/25 BLINCIDENT-2462 ���݌��ƌJ�z��������Ȃ��Ή� -----<<<<<
                // --- UPD �O�� 2012/07/05 ----------<<<<<
                {
                    // �݌Ƀ}�X�^Read�@�Ȃ���΁A�݌Ɉړ��̍ۂ͐V�K�ǉ����Ȃ�
                    StockWork stWork = new StockWork();
                    stWork.EnterpriseCode = wkStockMoveWork.EnterpriseCode;
                    stWork.WarehouseCode = wkStockMoveWork.AfEnterWarehCode;
                    stWork.GoodsMakerCd = wkStockMoveWork.GoodsMakerCd;
                    stWork.GoodsNo = wkStockMoveWork.GoodsNo;

                    stockstatus = _stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);
                }
                if (stockstatus == 0)
                {
                    StockMoveWork wareStMvWork = null;
                    StockAcPayHistWork wkStockAcPayHistPlusWork = null;

                    // �o��or���Ƀ��X�g�쐬����
                    wareStMvWork = MakeArrivalList(wkStockMoveWork);

                    // �o�Ɂ����ɂɕϊ��A���Ɂ��o�ɂɕϊ����ē���`�[�ԍ��ō쐬
                    wkStockAcPayHistPlusWork = CopyStockAcPayHistWorkFromStockMoveWork(wareStMvWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal);
                    stockAcPayHistList.Add(wkStockAcPayHistPlusWork);
                }
            }
            
            ////���׏����̏ꍇ�͏o�ׂ̃��R�[�h���쐬����
            //if ((wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived) && (procMode == (int)ct_ProcMode.Write))
            //{
            //   wkStockAcPayHistWork = CopyStockAcPayHistWorkFromStockMoveWorkPartner(wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal);
            //   stockAcPayHistList.Add(wkStockAcPayHistWork);
            //}
        }


        /// <summary>
        /// �q�Ɉړ��p�������X�g�쐬�쐬����
        /// </summary>
        /// <returns></returns>
        private StockMoveWork MakeArrivalList(StockMoveWork wkStockMoveWork)
        {
            StockMoveWork wareStMvWork = new StockMoveWork();

            wareStMvWork.AfEnterWarehCode = wkStockMoveWork.AfEnterWarehCode;
            wareStMvWork.AfEnterWarehName = wkStockMoveWork.AfEnterWarehName;
            wareStMvWork.AfSectionCode = wkStockMoveWork.AfSectionCode;
            wareStMvWork.AfSectionGuideSnm = wkStockMoveWork.AfSectionGuideSnm;
            wareStMvWork.AfShelfNo = wkStockMoveWork.AfShelfNo;
            wareStMvWork.ArrivalGoodsDay = wkStockMoveWork.ArrivalGoodsDay;
            wareStMvWork.AutoGoodsInsDiv = wkStockMoveWork.AutoGoodsInsDiv;
            wareStMvWork.BfEnterWarehCode = wkStockMoveWork.BfEnterWarehCode;
            wareStMvWork.BfEnterWarehName = wkStockMoveWork.BfEnterWarehName;
            wareStMvWork.BfSectionCode = wkStockMoveWork.BfSectionCode;
            wareStMvWork.BfSectionGuideSnm = wkStockMoveWork.BfSectionGuideSnm;
            wareStMvWork.BfShelfNo = wkStockMoveWork.BfShelfNo;
            wareStMvWork.BLGoodsCode = wkStockMoveWork.BLGoodsCode;
            wareStMvWork.BLGoodsFullName = wkStockMoveWork.BLGoodsFullName;
            wareStMvWork.CreateDateTime = wkStockMoveWork.CreateDateTime;
            wareStMvWork.EnterpriseCode = wkStockMoveWork.EnterpriseCode;
            wareStMvWork.FileHeaderGuid = wkStockMoveWork.FileHeaderGuid;
            wareStMvWork.GoodsMakerCd = wkStockMoveWork.GoodsMakerCd;
            wareStMvWork.GoodsName = wkStockMoveWork.GoodsName;
            wareStMvWork.GoodsNameKana = wkStockMoveWork.GoodsNameKana;
            wareStMvWork.GoodsNo = wkStockMoveWork.GoodsNo;
            wareStMvWork.InputDay = wkStockMoveWork.InputDay;
            wareStMvWork.ListPriceFl = wkStockMoveWork.ListPriceFl;
            wareStMvWork.LogicalDeleteCode = wkStockMoveWork.LogicalDeleteCode;
            wareStMvWork.MakerName = wkStockMoveWork.MakerName;
            wareStMvWork.MoveCount = wkStockMoveWork.MoveCount;
            wareStMvWork.MoveStatus = wkStockMoveWork.MoveStatus;
            wareStMvWork.Outline = wkStockMoveWork.Outline;
            wareStMvWork.ReceiveAgentCd = wkStockMoveWork.ReceiveAgentCd;
            wareStMvWork.ReceiveAgentNm = wkStockMoveWork.ReceiveAgentNm;
            wareStMvWork.ShipAgentCd = wkStockMoveWork.ShipAgentCd;
            wareStMvWork.ShipAgentNm = wkStockMoveWork.ShipAgentNm;
            wareStMvWork.ShipmentFixDay = wkStockMoveWork.ShipmentFixDay;
            wareStMvWork.ShipmentScdlDay = wkStockMoveWork.ShipmentScdlDay;
            wareStMvWork.SlipPrintFinishCd = wkStockMoveWork.SlipPrintFinishCd;
            wareStMvWork.StockDiv = wkStockMoveWork.StockMoveFixCode;
            wareStMvWork.StockMoveFormal = wkStockMoveWork.StockMoveFormal;
            wareStMvWork.StockMovePrice = wkStockMoveWork.StockMovePrice;
            wareStMvWork.StockMoveRowNo = wkStockMoveWork.StockMoveRowNo;
            wareStMvWork.StockMoveSlipNo = wkStockMoveWork.StockMoveSlipNo;
            wareStMvWork.StockMvEmpCode = wkStockMoveWork.StockMvEmpCode;
            wareStMvWork.StockMvEmpName = wkStockMoveWork.StockMvEmpName;
            wareStMvWork.StockUnitPriceFl = wkStockMoveWork.StockUnitPriceFl;
            wareStMvWork.SupplierCd = wkStockMoveWork.SupplierCd;
            wareStMvWork.SupplierSnm = wkStockMoveWork.SupplierSnm;
            wareStMvWork.TaxationDivCd = wkStockMoveWork.TaxationDivCd;
            wareStMvWork.UpdAssemblyId1 = wkStockMoveWork.UpdAssemblyId1;
            wareStMvWork.UpdAssemblyId2 = wkStockMoveWork.UpdAssemblyId2;
            wareStMvWork.UpdateDateTime = wkStockMoveWork.UpdateDateTime;
            wareStMvWork.UpdateSecCd = wkStockMoveWork.UpdateSecCd;
            wareStMvWork.UpdEmployeeCode = wkStockMoveWork.UpdEmployeeCode;
            wareStMvWork.WarehouseNote1 = wkStockMoveWork.WarehouseNote1;

            // �����o�ɓ`�[�̏ꍇ
            if (wkStockMoveWork.StockMoveFormal == 1 || wkStockMoveWork.StockMoveFormal == 2)
            {
                wareStMvWork.MoveStatus = 9;
                if (wareStMvWork.StockMoveFormal == 1) wareStMvWork.StockMoveFormal = 3;
                else wareStMvWork.StockMoveFormal = 4;
               
            }
            // �������ɓ`�[�̏ꍇ
            else
            {
                wareStMvWork.MoveStatus = 9;
                if (wareStMvWork.StockMoveFormal == 3) wareStMvWork.StockMoveFormal = 1;
                else wareStMvWork.StockMoveFormal = 2;
            }

            return wareStMvWork;
        }
        

        /*
        /// <summary>
        /// �݌ɗp�L�[������쐬����
        /// </summary>
        /// <param name="stockWork">�݌Ƀf�[�^</param>
        /// <returns></returns>
        private string CreateKeyString(StockWork stockWork)
        {
            string retString = "";
            retString =
                stockWork.EnterpriseCode + "-" +
                stockWork.GoodsMakerCd.ToString() + "-" +
                stockWork.GoodsNo
                ;
            return retString;
        }
        */ 

        /// <summary>
        /// �݌Ɉړ��f�[�^�L�[������쐬����
        /// </summary>
        /// <param name="stockMoveWork">�݌Ɉړ��f�[�^</param>
        /// <param name="mode">0:�ړ����݌ɁA1:�ړ���݌�</param>
        /// <returns></returns>
        private string CreateKeyString(StockMoveWork stockMoveWork, int mode)
        {
            string retString = "";
            retString =
                stockMoveWork.EnterpriseCode + "-" +
                stockMoveWork.GoodsMakerCd.ToString() + "-" +
                stockMoveWork.GoodsNo + "-";

               if (mode == 0)
               {
                   retString += stockMoveWork.BfEnterWarehCode.ToString();
               }
               else
               {
                   retString += stockMoveWork.AfEnterWarehCode.ToString();
               }

               return retString;
        }


        // ---- ADD K2013/12/25 ���N�n�� ---------------------- >>>>>
        /// <summary>
        /// ���_���̍݌Ƀ}�X�^�iStockRF�j�̔������̍X�V
        /// </summary>
        /// <param name="wkAfStockWork">�ړ���p�݌Ƀf�[�^</param>
        /// <param name="wkStockMoveWork">wkStockMoveWork</param>
        /// <param name="orderDataDic">orderDataDic</param>
        /// <param name="ps">ps</param>
        /// <param name="mode">mode 1:����̏ꍇ 2:���ɂ̏ꍇ 3:�`�[�폜�̏ꍇ</param>
        /// <remarks>
        /// <br>Note       : ���_���̍݌Ƀ}�X�^�iStockRF�j�̔������̍X�V�B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : K2013/12/25</br>
        /// </remarks>
        private void SalesOrderCountSet(ref StockWork wkAfStockWork, StockMoveWork wkStockMoveWork, ref Dictionary<string, ArrayList> orderDataDic, int ps, int mode)
        {
            string orderDataKey = string.Empty;
            double orderDataValue;
            ArrayList secOrderDtList = null;
            if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count > 0)
            {
                // key �݌Ɉړ��`�[�ԍ��ƍ݌Ɉړ��s�ԍ�
                orderDataKey = wkStockMoveWork.StockMoveSlipNo + "_" + wkStockMoveWork.StockMoveRowNo;

                if (orderDataDic.ContainsKey(orderDataKey))
                {
                    secOrderDtList = orderDataDic[orderDataKey] as ArrayList;
                    // value ���_������
                    orderDataValue = Convert.ToDouble(secOrderDtList[1]);
                    switch (mode)
                    {
                        case 1:
                            {
                                // ����̏ꍇ�F�������{���_�Ԕ����f�[�^.���_������
                                wkAfStockWork.SalesOrderCount = orderDataValue * 1;
                                secOrderDtList.RemoveAt(2);
                                secOrderDtList.Add(1);
                                break;
                            }
                        case 2:
                            {
                                // ���ɂ̏ꍇ�̏ꍇ�F������-���_�Ԕ����f�[�^.���_������
                                wkAfStockWork.SalesOrderCount = orderDataValue * -1;
                                secOrderDtList.RemoveAt(2);
                                secOrderDtList.Add(2);
                                break;
                            }
                        case 3:
                            {
                                // �`�[�폜�̏ꍇ�F������-���_�Ԕ����f�[�^.���_������
                                wkAfStockWork.SalesOrderCount = orderDataValue * -1;
                                break;
                            }
                    }

                }
            }
        }
        // ---- ADD K2013/12/25 ���N�n�� ---------------------- <<<<<

        #region �N���X�ϊ�����
        /// <summary>
        /// �݌Ɉړ��f�[�^���ړ���݌Ƀf�[�^
        /// </summary>
        /// <param name="retStockWork">�݌Ƀf�[�^</param>
        /// <param name="stockMoveWork">�݌Ɉړ��f�[�^</param>
        /// <param name="moveStatus">�݌Ɉړ��X�e�[�^�X</param>
        /// <param name="procMode">�����敪</param>
        /// <param name="originStockWork">�ړ����݌Ƀf�[�^</param>
        /// <returns>�ړ���݌Ƀf�[�^</returns>
        private StockWork CopyAfStockWorkFromStockMoveWork(StockWork retStockWork, StockMoveWork stockMoveWork, int moveStatus, int procMode, StockWork originStockWork)
        {
            if (retStockWork == null)
                retStockWork = new StockWork();

            #region �i�[����
            retStockWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //��ƃR�[�h
            retStockWork.SectionCode = stockMoveWork.AfSectionCode;    //���_�R�[�h���ړ��拒�_�R�[�h
            retStockWork.WarehouseCode = stockMoveWork.AfEnterWarehCode;    //�q�ɃR�[�h���ړ���q�ɃR�[�h
            retStockWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //���[�J�[�R�[�h
            retStockWork.GoodsNo = stockMoveWork.GoodsNo;    //���i�R�[�h
            retStockWork.GoodsNoNoneHyphen = stockMoveWork.GoodsNo.Replace("-","");  //�n�C�t�������i�� �݌Ƀ}�X�^�V�K�쐬���ɕK�v

            // ���׊m�肠��̏ꍇ
            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (moveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                {
                    if (procMode == (int)ct_ProcMode.Write)
                    {
                        retStockWork.SupplierStock += stockMoveWork.MoveCount;    //�d���݌ɐ����ړ����d���݌ɐ�
                    }
                    else
                    {
                        retStockWork.SupplierStock += stockMoveWork.MoveCount * -1;    //�d���݌ɐ����ړ����d���݌ɐ�
                    }
                }
                if (originStockWork != null)
                {
                    //retStockWork.StockUnitPriceFl = originStockWork.StockUnitPriceFl;    //�d���P��
                    // -- DEL 2010/06/15 --------------------------------------->>>
                    //retStockWork.LastStockDate = originStockWork.LastStockDate;    //�ŏI�d���N����
                    //retStockWork.MinimumStockCnt = originStockWork.MinimumStockCnt;    //�Œ�݌ɐ�
                    //retStockWork.MaximumStockCnt = originStockWork.MaximumStockCnt;    //�ō��݌ɐ�
                    //retStockWork.NmlSalOdrCount = originStockWork.NmlSalOdrCount;    //�������
                    //retStockWork.SalesOrderUnit = originStockWork.SalesOrderUnit;    //�����P��
                    // -- DEL 2010/06/15 ---------------------------------------<<<
                }
            }

            // ���׊m��Ȃ��̏ꍇ(�݌Ɉړ��Ƒq�Ɉړ�����)
            else
            {
                retStockWork.MovingSupliStock = 0;    //�ړ����d���݌ɐ�

                //if (stockMoveWork.StockMoveFormal == 2 || stockMoveWork.StockMoveFormal == 4)
                //{
                if (procMode == (int)ct_ProcMode.Write)
                {
                    retStockWork.SupplierStock += stockMoveWork.MoveCount;    //�d���݌ɐ�
                }
                else
                {
                    retStockWork.SupplierStock += stockMoveWork.MoveCount * -1;    //�d���݌ɐ�
                }
                //}
                //else
                //{
                //    // �o��
                //    if (stockMoveWork.StockMoveFormal == 1 || stockMoveWork.StockMoveFormal == 2)
                //        retStockWork.SupplierStock -= stockMoveWork.MoveCount;    //�d���݌ɐ�
                //    // ����
                //    else
                //        retStockWork.SupplierStock += stockMoveWork.MoveCount;    //�d���݌ɐ�
                //}
            }
            #endregion

            return retStockWork;
        }

        /// <summary>
        /// �݌Ɉړ��f�[�^���ړ����݌Ƀf�[�^
        /// </summary>
        /// <param name="retStockWork">�݌Ƀf�[�^</param>
        /// <param name="stockMoveWork">�݌Ɉړ��f�[�^</param>
        /// <param name="originStockWork">�X�V�O�݌Ƀf�[�^</param>
        /// <param name="newMoveStatus">�X�V�ړ��X�e�[�^�X</param>
        /// <param name="oldMoveStatus">�X�V�O�ړ��X�e�[�^�X</param>
        /// <param name="procMode">�����敪</param>
        /// <returns></returns>
        private StockWork CopyBfStockWorkFromStockMoveWork(StockWork retStockWork, StockMoveWork stockMoveWork, StockWork originStockWork,int newMoveStatus,int oldMoveStatus, int procMode)
        {
            if (retStockWork == null)
                retStockWork = new StockWork();

            #region �i�[����
            retStockWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //��ƃR�[�h
            retStockWork.SectionCode = stockMoveWork.BfSectionCode;         //���_�R�[�h���ړ������_�R�[�h
            retStockWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;    //�q�ɃR�[�h���ړ����q�ɃR�[�h
            retStockWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //���[�J�[�R�[�h
            retStockWork.GoodsNo = stockMoveWork.GoodsNo;    //���i�R�[�h
            retStockWork.GoodsNoNoneHyphen = stockMoveWork.GoodsNo.Replace("-", ""); //�n�C�t�������i�� �݌Ƀ}�X�^�V�K�쐬���ɕK�v
            
            if (originStockWork != null)
            {   
                //retStockWork.StockUnitPriceFl = originStockWork.StockUnitPriceFl;    //�d���P��
                retStockWork.LastStockDate = originStockWork.LastStockDate;    //�ŏI�d���N����
            }

            // ���׊m�肠��̏ꍇ
            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (newMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                {
                    retStockWork.SupplierStock += stockMoveWork.MoveCount * -1;    //�d���݌ɐ����ړ����d���݌ɐ�

                    if (oldMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)
                    {
                        retStockWork.MovingSupliStock += stockMoveWork.MoveCount * -1;    //�ړ����d���݌ɐ�
                    }
                }
                else if (newMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)
                {
                    if (procMode == (int)ct_ProcMode.Write)
                    {
                        retStockWork.MovingSupliStock += stockMoveWork.MoveCount;    //�ړ����d���݌ɐ�
                    }
                    else
                    {
                        //���׃L�����Z��
                        if (oldMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                        {
                            retStockWork.MovingSupliStock += stockMoveWork.MoveCount;    //�ړ����d���݌ɐ�
                            retStockWork.SupplierStock += stockMoveWork.MoveCount;    //�d���݌ɐ�
                        }
                        else
                        {
                            retStockWork.MovingSupliStock += stockMoveWork.MoveCount * -1;    //�ړ����d���݌ɐ�
                        }
                    }
                }
            }

            // ���׊m��Ȃ��̏ꍇ(�݌Ɉړ��Ƒq�Ɉړ�����)
            else
            {
                retStockWork.MovingSupliStock = 0;    //�ړ����d���݌ɐ�
                //if (stockMoveWork.StockMoveFormal == 2 || stockMoveWork.StockMoveFormal == 4)
                //{
                if (procMode == (int)ct_ProcMode.Write)
                {
                    // �o��
                    retStockWork.SupplierStock -= stockMoveWork.MoveCount;    //�d���݌ɐ�
                }
                else
                {
                    retStockWork.SupplierStock -= stockMoveWork.MoveCount * -1;    //�d���݌ɐ�
                }
                //}
                //else
                //{
                //    // �o��
                //    if (stockMoveWork.StockMoveFormal == 1 || stockMoveWork.StockMoveFormal == 2)
                //        retStockWork.SupplierStock -= stockMoveWork.MoveCount;    //�d���݌ɐ�
                //    // ����
                //    else
                //        retStockWork.SupplierStock += stockMoveWork.MoveCount;    //�d���݌ɐ�
                //}
            }
            #endregion

            return retStockWork;
        }
        
        /// <summary>
        /// �݌Ɉړ��f�[�^���݌Ɏ󕥗����f�[�^
        /// </summary>
        /// <param name="stockMoveWork">�݌Ɉړ�</param>
        /// <param name="bfstockMoveWork">�݌Ɉړ��ύX�O</param>
        /// <param name="defstockMoveWork">�݌Ɉړ�����</param>
        /// <param name="procMode">�X�V���[�h</param>
        /// <param name="stockMoveFormal">�ړ��`��</param>
        /// <br>Update Note: 2010/11/15 杍^</br>
        /// <br>             ��Q���ǑΉ������u�P�v�̑Ή�</br>
        /// <returns></returns>
        private StockAcPayHistWork CopyStockAcPayHistWorkFromStockMoveWork(StockMoveWork stockMoveWork, StockMoveWork bfstockMoveWork, StockMoveWork defstockMoveWork, int procMode, int stockMoveFormal)
        {                           
            StockAcPayHistWork retStockAcPayHistWork = new StockAcPayHistWork();

            #region �i�[����
            retStockAcPayHistWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //��ƃR�[�h
            retStockAcPayHistWork.AcPaySlipNum = stockMoveWork.StockMoveSlipNo.ToString(); //�󕥌��`�[�ԍ����݌Ɉړ��`�[�ԍ�
            retStockAcPayHistWork.AcPaySlipRowNo = stockMoveWork.StockMoveRowNo;

            if (procMode == (int)ct_ProcMode.Write)
            {
                if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.Cancel; //�󕥌�����敪
                else
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip; //�󕥌�����敪
            }
            else
                retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip; //�󕥌�����敪

            retStockAcPayHistWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //���[�J�[�R�[�h
            retStockAcPayHistWork.MakerName = stockMoveWork.MakerName;    //���[�J�[����
            retStockAcPayHistWork.GoodsNo = stockMoveWork.GoodsNo;    //���i�R�[�h
            retStockAcPayHistWork.GoodsName = stockMoveWork.GoodsName;    //���i����

            retStockAcPayHistWork.InputSectionCd = stockMoveWork.UpdateSecCd;    //���͋��_�R�[�h���X�V���_�R�[�h
            if (secInfoSetWorkHash.ContainsKey(stockMoveWork.UpdateSecCd) == true )
            {
                retStockAcPayHistWork.InputSectionGuidNm = secInfoSetWorkHash[stockMoveWork.UpdateSecCd].ToString();    //���͋��_���́��X�V���_����
            }

            if ((stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived) || //���׏���
                (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)) //���׃L�����Z��
            {
                retStockAcPayHistWork.SectionCode = stockMoveWork.AfSectionCode;    //���_�R�[�h���ړ��拒�_�R�[�h
                retStockAcPayHistWork.SectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //���_���́��ړ��拒�_����                
                retStockAcPayHistWork.WarehouseCode = stockMoveWork.AfEnterWarehCode;     //�q�ɃR�[�h���ړ���q�ɃR�[�h
                retStockAcPayHistWork.WarehouseName = stockMoveWork.AfEnterWarehName;     //�q�ɖ��́��ړ���q�ɖ���
                retStockAcPayHistWork.ShelfNo = stockMoveWork.AfShelfNo;  //�I�ԁ��ړ���I��
            }
            else
            {
                retStockAcPayHistWork.SectionCode = stockMoveWork.BfSectionCode;    //���_�R�[�h���ړ������_�R�[�h
                retStockAcPayHistWork.SectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //���_���́��ړ������_����
                retStockAcPayHistWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;     //�q�ɃR�[�h���ړ����q�ɃR�[�h
                retStockAcPayHistWork.WarehouseName = stockMoveWork.BfEnterWarehName;     //�q�ɖ��́��ړ����q�ɖ���
                retStockAcPayHistWork.ShelfNo = stockMoveWork.BfShelfNo;  //�I�ԁ��ړ����I��
            }            
            
            retStockAcPayHistWork.BfSectionCode = stockMoveWork.BfSectionCode;    //�ړ������_�R�[�h
            retStockAcPayHistWork.BfSectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //�ړ������_�K�C�h����
            retStockAcPayHistWork.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;    //�ړ����q�ɃR�[�h
            retStockAcPayHistWork.BfEnterWarehName = stockMoveWork.BfEnterWarehName;    //�ړ����q�ɖ���
            retStockAcPayHistWork.BfShelfNo = stockMoveWork.BfShelfNo;    //�ړ����I��
            retStockAcPayHistWork.AfSectionCode = stockMoveWork.AfSectionCode;    //�ړ��拒�_�R�[�h
            retStockAcPayHistWork.AfSectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //�ړ��拒�_�K�C�h����
            retStockAcPayHistWork.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;    //�ړ���q�ɃR�[�h
            retStockAcPayHistWork.AfEnterWarehName = stockMoveWork.AfEnterWarehName;    //�ړ���q�ɖ���
            retStockAcPayHistWork.AfShelfNo = stockMoveWork.AfShelfNo;    //�ړ���I��
            retStockAcPayHistWork.MoveStatus = stockMoveWork.MoveStatus;�@//�ړ����
            retStockAcPayHistWork.BLGoodsCode = stockMoveWork.BLGoodsCode;  //BL���i�R�[�h
            retStockAcPayHistWork.BLGoodsFullName = stockMoveWork.BLGoodsFullName;  //BL���i�R�[�h���́i�S�p�j

            retStockAcPayHistWork.ListPriceTaxExcFl = stockMoveWork.ListPriceFl; //�艿
            retStockAcPayHistWork.AcPayNote = stockMoveWork.Outline;    //�󕥔��l
            retStockAcPayHistWork.SupplierCd = stockMoveWork.SupplierCd; // �d����R�[�h
            retStockAcPayHistWork.SupplierSnm = stockMoveWork.SupplierSnm; // �d���於��

            //�󕥗����̐��ʂɂ͍����̐��ʂ��Z�b�g
            int mark = 1;

            if (procMode == (int)ct_ProcMode.Delete)
            {
                mark = -1;
            }


            if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)//���׏���
            {
                // ���׊m�肠��̏ꍇ
                if (stockMoveWork.StockMoveFixCode == 1)
                {
                    retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ArrivalGoodsDay;    //���o�ד������ד�
                    retStockAcPayHistWork.AddUpADate = stockMoveWork.ArrivalGoodsDay;    //�v��������ד�
                    retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival;    //�󕥌��`�[�敪
                    retStockAcPayHistWork.ArrivalCnt = stockMoveWork.MoveCount * mark;    //���א�(���׎��͐��ʂ����̂܂܃Z�b�g)
                    retStockAcPayHistWork.InputAgenCd = stockMoveWork.ReceiveAgentCd;    //����S���҃R�[�h
                    retStockAcPayHistWork.InputAgenNm = stockMoveWork.ReceiveAgentNm;    //����S���Җ���

                    retStockAcPayHistWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;    //�d���P��
                    retStockAcPayHistWork.StockPrice = stockMoveWork.StockMovePrice * mark;    //�d�����z
                }
                // ���׊m��Ȃ��̏ꍇ
                else
                {
                    retStockAcPayHistWork.MovingSupliStock = 0;

                    // �o�ד`�[�̏ꍇ
                    if (stockMoveWork.StockMoveFormal == 1 || stockMoveWork.StockMoveFormal == 2)
                    {
                        retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment;    //�󕥌��`�[�敪
                        //retStockAcPayHistWork.SupplierStock -= stockMoveWork.MoveCount;
                        retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //�o�גS���҃R�[�h
                        retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //�o�גS���Җ���
                        // UPD 2010/11/15 ---- >>>>
                        //retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentFixDay;    //���o�ד����o�׊m���
                        retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ArrivalGoodsDay;    //���o�ד������ד�
                        // UPD 2010/11/15 ---- <<<<
                        retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockMoveWork.StockUnitPriceFl;    //����P��
                        retStockAcPayHistWork.SalesMoney = defstockMoveWork.StockMovePrice * mark;    //������z(�������Z�b�g)
                        retStockAcPayHistWork.ShipmentCnt = defstockMoveWork.MoveCount * mark;    //�o�א�(�o�׎��͍������Z�b�g)
                        
                        retStockAcPayHistWork.SectionCode = stockMoveWork.BfSectionCode;    //���_�R�[�h���ړ������_�R�[�h
                        retStockAcPayHistWork.SectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //���_���́��ړ������_����
                        retStockAcPayHistWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;     //�q�ɃR�[�h���ړ����q�ɃR�[�h
                        retStockAcPayHistWork.WarehouseName = stockMoveWork.BfEnterWarehName;     //�q�ɖ��́��ړ����q�ɖ���
                        retStockAcPayHistWork.ShelfNo = stockMoveWork.BfShelfNo;  //�I�ԁ��ړ����I��
                    }
                    // ���ד`�[�̏ꍇ
          
                    else
                    {
                        retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival;    //�󕥌��`�[�敪
                        //retStockAcPayHistWork.SupplierStock += stockMoveWork.MoveCount;
                        retStockAcPayHistWork.InputAgenCd = stockMoveWork.ReceiveAgentCd;    //����S���҃R�[�h
                        retStockAcPayHistWork.InputAgenNm = stockMoveWork.ReceiveAgentNm;    //����S���Җ���
                        retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ArrivalGoodsDay;    //���o�ד������ד�
                        retStockAcPayHistWork.AddUpADate = stockMoveWork.ArrivalGoodsDay;    //�v��������ד�
                        retStockAcPayHistWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;    //�d���P��
                        retStockAcPayHistWork.StockPrice = defstockMoveWork.StockMovePrice * mark;    //�d�����z
                        retStockAcPayHistWork.ArrivalCnt = defstockMoveWork.MoveCount * mark;    //���א�(���׎��͐��ʂ����̂܂܃Z�b�g)

                        retStockAcPayHistWork.SectionCode = stockMoveWork.AfSectionCode;    //���_�R�[�h���ړ��拒�_�R�[�h
                        retStockAcPayHistWork.SectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //���_���́��ړ��拒�_����
                        retStockAcPayHistWork.WarehouseCode = stockMoveWork.AfEnterWarehCode;     //�q�ɃR�[�h���ړ���q�ɃR�[�h
                        retStockAcPayHistWork.WarehouseName = stockMoveWork.AfEnterWarehName;     //�q�ɖ��́��ړ���q�ɖ���
                        retStockAcPayHistWork.ShelfNo = stockMoveWork.AfShelfNo;  //�I�ԁ��ړ���I��
                    }
                }
            }
            else if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)//�o�׏���
            {
                if (bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                {
                    //���׃L�����Z������
                    retStockAcPayHistWork.IoGoodsDay = bfstockMoveWork.ArrivalGoodsDay;    //���o�ד������ד�
                    retStockAcPayHistWork.AddUpADate = bfstockMoveWork.ArrivalGoodsDay;    //�v��������ד�
                    retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival;    //�󕥌��`�[�敪

                    retStockAcPayHistWork.ArrivalCnt = stockMoveWork.MoveCount * -1;    //���א�(���׎��͐��ʂ����̂܂܃Z�b�g)

                    retStockAcPayHistWork.InputAgenCd = bfstockMoveWork.ReceiveAgentCd;    //����S���҃R�[�h
                    retStockAcPayHistWork.InputAgenNm = bfstockMoveWork.ReceiveAgentNm;    //����S���Җ���

                    retStockAcPayHistWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;    //�d���P��
                    retStockAcPayHistWork.StockPrice = stockMoveWork.StockMovePrice * -1;    //�d�����z
                }
                else
                {
                    retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentFixDay;    //���o�ד����o�׊m���
                    retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment;    //�󕥌��`�[�敪
                    retStockAcPayHistWork.ShipmentCnt = defstockMoveWork.MoveCount * mark;    //�o�א�(�o�׎��͍������Z�b�g)
                    retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //�o�גS���҃R�[�h
                    retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //�o�גS���Җ���

                    retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockMoveWork.StockUnitPriceFl;    //����P��
                    retStockAcPayHistWork.SalesMoney = defstockMoveWork.StockMovePrice * mark;    //������z(�������Z�b�g)

                }
            }
            //else if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Unshipment)//���o�׏��
            //{
            //    retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentScdlDay;    //���o�ד����o�ח\���
            //    retStockAcPayHistWork.ShipmentCnt = moveCount;    //�o�א�
            //    retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //�o�גS���҃R�[�h
            //    retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //�o�גS���Җ���
            //}
            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------->>>>>
            if (_isRecv)
            {
                retStockAcPayHistWork.SectionGuideNm = GetSecNameBySecCode(retStockAcPayHistWork.SectionCode);//���_���́��ړ��拒�_����
                retStockAcPayHistWork.InputSectionGuidNm = GetSecNameBySecCode(retStockAcPayHistWork.InputSectionCd);//���͋��_�R�[�h���X�V���_�R�[�h
            }
            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------<<<<<
            #endregion

            return retStockAcPayHistWork;
        }

        /// <summary>
        /// �݌Ɉړ��f�[�^���݌Ɏ󕥗����f�[�^(���׏������̏o��)
        /// </summary>
        /// <param name="stockMoveWork">�݌Ɉړ�</param>
        /// <param name="bfstockMoveWork">�݌Ɉړ��ύX�O</param>
        /// <param name="defstockMoveWork">�݌Ɉړ�����</param>
        /// <param name="procMode">�X�V���[�h</param>
        /// <param name="stockMoveFormal">�ړ��`��</param>
        /// <returns></returns>
        private StockAcPayHistWork CopyStockAcPayHistWorkFromStockMoveWorkPartner(StockMoveWork stockMoveWork, StockMoveWork bfstockMoveWork,StockMoveWork defstockMoveWork, int procMode, int stockMoveFormal)
        {
            StockAcPayHistWork retStockAcPayHistWork = new StockAcPayHistWork();

            #region �i�[����
            retStockAcPayHistWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //��ƃR�[�h
            retStockAcPayHistWork.AcPaySlipNum = stockMoveWork.StockMoveSlipNo.ToString(); //�󕥌��`�[�ԍ����݌Ɉړ��`�[�ԍ�
            retStockAcPayHistWork.AcPaySlipRowNo = stockMoveWork.StockMoveRowNo;

            if (procMode == (int)ct_ProcMode.Write)
            {
                if ((stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.MoveOffSubject && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving) ||
                    (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Unshipment && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving))
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.Cancel; //�󕥌�����敪
                else
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip; //�󕥌�����敪
            }
            else
                retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip; //�󕥌�����敪

            retStockAcPayHistWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //���[�J�[�R�[�h
            retStockAcPayHistWork.MakerName = stockMoveWork.MakerName;    //���[�J�[����
            retStockAcPayHistWork.GoodsNo = stockMoveWork.GoodsNo;    //���i�R�[�h
            retStockAcPayHistWork.GoodsName = stockMoveWork.GoodsName;    //���i����

            retStockAcPayHistWork.InputSectionCd = stockMoveWork.UpdateSecCd;    //���͋��_�R�[�h���X�V���_�R�[�h
            if (secInfoSetWorkHash.ContainsKey(stockMoveWork.UpdateSecCd) == true)
            {
                retStockAcPayHistWork.InputSectionGuidNm = secInfoSetWorkHash[stockMoveWork.UpdateSecCd].ToString();    //���͋��_���́��X�V���_����
            }

            retStockAcPayHistWork.SectionCode = stockMoveWork.BfSectionCode;    //���_�R�[�h���ړ������_�R�[�h
            retStockAcPayHistWork.SectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //���_���́��ړ������_����
            retStockAcPayHistWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;     //�q�ɃR�[�h���ړ����q�ɃR�[�h
            retStockAcPayHistWork.WarehouseName = stockMoveWork.BfEnterWarehName;     //�q�ɖ��́��ړ����q�ɖ���
            retStockAcPayHistWork.ShelfNo = stockMoveWork.BfShelfNo;  //�I�ԁ��ړ����I��

            retStockAcPayHistWork.BfSectionCode = stockMoveWork.BfSectionCode;    //�ړ������_�R�[�h
            retStockAcPayHistWork.BfSectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //�ړ������_�K�C�h����
            retStockAcPayHistWork.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;    //�ړ����q�ɃR�[�h
            retStockAcPayHistWork.BfEnterWarehName = stockMoveWork.BfEnterWarehName;    //�ړ����q�ɖ���
            retStockAcPayHistWork.BfShelfNo = stockMoveWork.BfShelfNo;  //�ړ����I��
            retStockAcPayHistWork.AfSectionCode = stockMoveWork.AfSectionCode;    //�ړ��拒�_�R�[�h
            retStockAcPayHistWork.AfSectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //�ړ��拒�_�K�C�h����
            retStockAcPayHistWork.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;    //�ړ���q�ɃR�[�h
            retStockAcPayHistWork.AfEnterWarehName = stockMoveWork.AfEnterWarehName;    //�ړ���q�ɖ���
            retStockAcPayHistWork.AfShelfNo = stockMoveWork.AfShelfNo;  //�ړ����I��
            retStockAcPayHistWork.MoveStatus = stockMoveWork.MoveStatus;�@//�ړ����
            retStockAcPayHistWork.BLGoodsCode = stockMoveWork.BLGoodsCode;  //BL���i�R�[�h
            retStockAcPayHistWork.BLGoodsFullName = stockMoveWork.BLGoodsFullName;  //BL���i�R�[�h���́i�S�p�j

            retStockAcPayHistWork.ListPriceTaxExcFl = stockMoveWork.ListPriceFl; //�艿
            retStockAcPayHistWork.AcPayNote = stockMoveWork.Outline;    //�󕥔��l

            int mark = 1;
            if (procMode == (int)ct_ProcMode.Delete)
            {
                mark = -1;
            }

            retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockMoveWork.StockUnitPriceFl;    //�d���P��
            retStockAcPayHistWork.SalesMoney = stockMoveWork.StockMovePrice * mark;    //�d�����z

            retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentFixDay;    //���o�ד����o�׊m���
            retStockAcPayHistWork.AddUpADate = stockMoveWork.ArrivalGoodsDay;    //�v��������ד�
            retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment;    //�󕥌��`�[�敪
            retStockAcPayHistWork.ShipmentCnt = defstockMoveWork.MoveCount * mark;    //�o�א�(�������Z�b�g)
            retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //�o�גS���҃R�[�h
            retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //�o�גS���Җ���

            #endregion

            return retStockAcPayHistWork;
        }
        
        #endregion

        #endregion

        #region ���_�ݒ�}�X�^�擾
        /// <summary>
        /// ���_�ݒ�}�X�^�擾
        /// </summary>
        /// <param name="stockMoveList"></param>
        /// <param name="secinfoSetWorkHash"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetSecInfoSetWork(ArrayList stockMoveList, ref Hashtable secinfoSetWorkHash, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            secinfoSetWorkHash = new Hashtable();
            
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            if (stockMoveList != null && stockMoveList.Count > 0)
                secInfoSetWork.EnterpriseCode = ((StockMoveWork)stockMoveList[0]).EnterpriseCode;   //��ƃR�[�h
            else
                return status;
            
            ArrayList secInfoList = new ArrayList();
            
            //���_�ݒ�Seach�Ăяo��
            status = _secInfoDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //���_���̂�HashTable�Ɋi�[
                foreach(SecInfoSetWork sec in secInfoList)
                {
                    secinfoSetWorkHash.Add(sec.SectionCode,sec.SectionGuideNm);
                
                }
            }
            
            return status;
        }
        
        #endregion

        #region �p�����[�^�`�F�b�N����
        /// <summary>
        /// �p�����[�^�`�F�b�N����
        /// </summary>
        /// <param name="stockMoveList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="stockMoveFormal"></param>
        /// <param name="stockMoveSlipNo"></param>
        /// <param name="moveStatus"></param>
        /// <param name="retMsg"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int CheckParam(ArrayList stockMoveList, out string enterpriseCode, out string sectionCode, out int stockMoveFormal, out int stockMoveSlipNo, out int moveStatus, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            enterpriseCode = "";
            sectionCode = "";
            stockMoveFormal = 0;
            stockMoveSlipNo = 0;
            moveStatus = 0;

            //NULL�`�F�b�N
            if (stockMoveList == null)
            {
                retMsg = "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //�J�E���g�`�F�b�N
            if (stockMoveList.Count <= 0)
            {
                retMsg = "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            StockMoveWork stockMoveWork = stockMoveList[0] as StockMoveWork;

            if (stockMoveWork == null)
            {
                retMsg = "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //��ƃR�[�h�擾
            enterpriseCode = stockMoveWork.EnterpriseCode;
            //���_�R�[�h
            sectionCode = stockMoveWork.BfSectionCode;
            //�݌Ɉړ��`��
            stockMoveFormal = stockMoveWork.StockMoveFormal;
            //�݌Ɉړ��`�[�ԍ�
            stockMoveSlipNo = stockMoveWork.StockMoveSlipNo;
            //�ړ����
            moveStatus = stockMoveWork.MoveStatus;

            return status;
        }
        #endregion

        #region �ړ��`�[�ԍ��̔�
        /// <summary>
        /// �݌Ɉړ��`�[�ԍ����̔Ԃ��ĕԂ��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockMoveSlipNo">�̔Ԍ���</param>
        /// <param name="stockMoveFormal">�݌Ɉړ��`��</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ��`�[�ԍ����̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 21015 �����@�F��</br>
        /// <br>Date       : 2007.02.07</br>
        private int CreateStockMoveSlipNo(string enterpriseCode, string sectionCode, out int stockMoveSlipNo, int stockMoveFormal, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            stockMoveSlipNo = 0;

            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = null;
            retItemInfo = null;

            NumberingManager numberingManager = new NumberingManager();

            //�ԍ��͈͕����[�v
            Int32 loopCnt = 1;

            while (loopCnt <= 999999999)
            {
                long no;

                //�݌Ɉړ��`�[�ԍ��͋��_��ˑ������狒�_�R�[�h�͑S��
                status = numberingManager.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.StockMoveSlipNo,out no);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //�ԍ��𐔒l�^�ɕϊ�
                    Int32 tmpStockMoveSlipNo = System.Convert.ToInt32(no);
                    SqlDataReader myReader = null;

                    //�󂫔ԃ`�F�b�N
                    try
                    {
                        //Select�R�}���h�̐���
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT STOCKMOVESLIPNORF FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO ", sqlConnection, sqlTransaction))
                        {

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                            SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(tmpStockMoveSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //�f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                            if (!myReader.Read())
                            {
                                stockMoveSlipNo = tmpStockMoveSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        retMsg = "�݌Ɉړ��`�[�ԍ��̔Ԓ��ɃG���[���������܂����B";
                        retItemInfo = "StockMoveSlipNo";

                        //���N���X�ɗ�O��n���ď������Ă��炤
                        status = base.WriteSQLErrorLog(ex);
                        break;
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                }
                //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                else break;

                //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                loopCnt++;
            }

            //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "�݌Ɉړ��`�[�ԍ��ɋ󂫔ԍ�������܂���B�폜�\�ȓ`�[���폜���Ă��������B";
                retItemInfo = "StockMoveSlipNo";
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }
        #endregion

        #region ADD 2011/08/11 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j�݌Ɉړ��f�[�^��M���ɍ݌Ƀ}�X�^�̍X�V���s��        
        /// <summary>
        /// �X�V�O�㍷���p���X�g���擾���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="ctProcMode">�������[�h</param>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <param name="defstockMoveWorkList">�݌Ɉړ��������X�g</param>
        /// <param name="stockMoveWorkList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �X�V�O�㍷���p���X�g���擾���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.11</br>
        private int GetStockMove(int ctProcMode, int stockMoveSlipNo, out ArrayList defstockMoveWorkList, ref ArrayList stockMoveWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            defstockMoveWorkList = new ArrayList();//�X�V�O�㍷���p���X�g
            try
            {
                //string selectTxt = "";//DEL 2011/09/05 �A#24241
                StringBuilder selectTxt = new StringBuilder();//ADD 2011/09/05 �A#24241

                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        #region DEL
                        //DEL 2011/09/05 �A#24241------------------------------------->>>>>
                        ////�݌Ɉړ��`�[�ԍ��� 0 �̏ꍇ�̓p�����[�^�̓`�[�ԍ����Z�b�g
                        //if (stockmoveWork.StockMoveSlipNo == 0)
                        //    stockmoveWork.StockMoveSlipNo = stockMoveSlipNo;

                        //selectTxt = "";
                        //selectTxt += "SELECT" + Environment.NewLine;
                        //selectTxt += "  *" + Environment.NewLine;
                        //selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        //selectTxt += "WHERE" + Environment.NewLine;
                        //selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        //selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        //selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        //selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        ////Select�R�}���h�̐���
                        //sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);
                        //DEL 2011/09/05 �A#24241-------------------------------------<<<<<
                        #endregion
                        //ADD 2011/09/05 �A#24241------------------------------------->>>>>
                        selectTxt.Append("SELECT" + Environment.NewLine);
                        selectTxt.Append("  *" + Environment.NewLine);
                        selectTxt.Append("FROM STOCKMOVERF AS STOCKM" + Environment.NewLine);
                        selectTxt.Append("WHERE" + Environment.NewLine);
                        selectTxt.Append("     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.LOGICALDELETECODERF=@FINDLOGICALDELETECODERF" + Environment.NewLine);
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection, sqlTransaction);
                        //ADD 2011/09/05 �A#24241-------------------------------------<<<<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);//ADD 2011/09/05 �A#24241

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);//ADD 2011/09/05 �A#24241

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //�X�V�O�̍݌Ɉړ��f�[�^���擾
                            StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                            if (ctProcMode == (int)ct_ProcMode.Write)
                            {
                                //�X�V��̈ړ����𔽉f
                                defStockMoveWork.MoveCount = stockmoveWork.MoveCount - defStockMoveWork.MoveCount;
                                defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice - defStockMoveWork.StockMovePrice;
                            }
                            else
                            {
                                if (defStockMoveWork.LogicalDeleteCode == 1)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    break;
                                }
                            }

                            //�m��敪��ǉ�
                            defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                            // --- ADD �O�� 2012/07/10 ---------->>>>>
                            defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                            // --- ADD �O�� 2012/07/10 ----------<<<<<

                            defstockMoveWorkList.Add(defStockMoveWork);                           
                        }
                        else
                        {
                            if (ctProcMode == (int)ct_ProcMode.Delete)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;                               
                            }
                            StockMoveWork defStockMoveWork = stockmoveWork;
                            defstockMoveWorkList.Add(defStockMoveWork);
                        }
                        if (myReader.IsClosed == false) myReader.Close();
                        al.Add(stockmoveWork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

            stockMoveWorkList = al;

            return status;
        }

        /// <summary>
        /// �݌Ɉړ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockMoveList">stockMoveList�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.11</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlEncryptInfo sqlEncryptInfo       = null;
            CustomSerializeArrayList retList    = new CustomSerializeArrayList();
            retMsg = "";

            string enterpriseCode   = "";
            string sectionCode      = "";
            int stockMoveFormal     = 0;
            int stockMoveSlipNo     = 0;
            int moveStatus          = 0;
            string retItemInfo      = "";
            bool createHisData      = true;
            string resNm = "";
            // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
            // ���_�Ԕ����f�[�^��Dictionary�̏�����
            Dictionary<string, ArrayList> orderDataDic = null;
            // �I�v�V�������̏�����
            int ps = 0;
            // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

            try
            {
                ArrayList stockList             = null; //�݌Ƀ��X�g
                ArrayList stockAcPayHistList    = null; //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList      = null; //�X�V�����݌Ɉړ����X�g
                ArrayList BFStockMoveList       = null; //�X�V�O�ړ����X�g
                ArrayList defStockList          = null; //�X�V�O�݌Ƀ��X�g
               
                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //ADD 2011/09/02 #24259------------------------------->>>>>
                //�R�l�N�V��������
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //���_�ݒ�̎擾
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                // �V�X�e�����b�N(���_)
                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //resNm = GetResourceName(enterpriseCode);
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData1:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteForReceiveData1_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                    return status;
                }

                try
                {
                    #region DEL 2011.08.24 #23964 �\�[�X���r���[����
                    ////���׊m�肠��
                    //if (_stockMoveWork.StockMoveFixCode == 1)
                    //{
                    //    //---�݌Ɉړ��`�[�ԍ��̔ԏ���---
                    //    if (stockMoveSlipNo == 0)//�݌Ɉړ��`�[
                    //    {
                    //        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    //    }
                    //    else
                    //    {
                    //        //�X�V�O�f�[�^�̎擾
                    //        BFStockMoveList = new ArrayList();
                    //        foreach (StockMoveWork stmvwork in stockMoveList)
                    //        {
                    //            StockMoveWork searchpara = new StockMoveWork();
                    //            searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                    //            searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                    //            searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                    //            searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                    //            status = ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);
                    //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //            {
                    //                BFStockMoveList.Add(searchpara);
                    //            }
                    //            else
                    //            {
                    //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //                BFStockMoveList.Clear();
                    //                BFStockMoveList = null;
                    //                break;
                    //            }
                    //        }                                      
                    //    }
                    //    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        if (moveStatus == 2 && stockMoveList != null)
                    //        {
                    //            //���׎���̏ꍇ�́A���ד`�[�̍폜
                    //            GetStockMove((int)ct_ProcMode.Delete, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    //        }
                    //        else
                    //        {
                    //            // �o�ɁE���ɓ`�[�o�^
                    //            GetStockMove((int)ct_ProcMode.Write, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    //        }                            
                    //    }

                    //    //�f�[�^����
                    //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        createHisData = true;
                    //        //ArrayList defList = defStockMoveList;//DEL 2011.08.24 #23964 �\�[�X���r���[����
                    //        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                    //    }

                    //    //�݌Ƀf�[�^�X�V
                    //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        string origin = "";
                    //        CustomSerializeArrayList originList = null;
                    //        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                    //        paraList.Add(stockList);
                    //        paraList.Add(stockAcPayHistList);
                    //        int position = 0;
                    //        string param = "";
                    //        object freeParam = null;
                    //        status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //    }
                    //}
                    //// ���׊m��Ȃ�
                    //else
                    //{
                    #endregion

                    ArrayList stockMoveNewList = null;
                    //---�݌Ɉړ��`�[�ԍ��̔ԏ���---
                    if (stockMoveSlipNo == 0)//�݌Ɉړ��`�[
                    {
                        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        //�X�V�O�f�[�^�̎擾
                        BFStockMoveList = new ArrayList();
                        stockMoveNewList = new ArrayList();
                        foreach (StockMoveWork stmvwork in stockMoveList)
                        {
                            StockMoveWork searchpara = new StockMoveWork();
                            searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                            searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                            searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                            searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                            this.ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                BFStockMoveList.Add(searchpara);

                                // ���ד`�[��������Z�b�g���L�d�l��ύX
                                if (searchpara.StockMoveFormal == 3 || searchpara.StockMoveFormal == 4)
                                {
                                    searchpara.ShipmentScdlDay = DateTime.MinValue;
                                    searchpara.ShipmentFixDay = DateTime.MinValue;
                                }
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                BFStockMoveList.Clear();
                                BFStockMoveList = null;
                                break;
                            }
                        }
                    }


                    //�݌Ɉړ��f�[�^�X�V
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �o�ɓ`�[�o�^
                        GetStockMove((int)ct_ProcMode.Write, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    }
                    // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                    orderDataDic = new Dictionary<string, ArrayList>();
                    ps = 0;
                    // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<
                    //�f�[�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        createHisData = true;
                        //ArrayList defList = defStockMoveList;//DEL 2011.08.24 #23964 �\�[�X���r���[����
                        //status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��
                    }

                    //�݌Ƀf�[�^�X�V
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        //if ((stockList.Count == 0 && stockAcPayHistList.Count == 0) == false)//DEL 2011.08.29 �݌Ƀf�[�^���[���ꍇ�A�݌Ƀf�[�^�X�V���Ȃ�
                        if (stockList.Count > 0)//ADD 2011.08.29 �݌Ƀf�[�^���[���ꍇ�A�݌Ƀf�[�^�X�V���Ȃ�
                        {
                            status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        }
                    }
                    //}//DEL 2011.08.24 #23964 �\�[�X���r���[����
                }
                finally
                {
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }




        // ---- ADD K2013/12/10 wangl2 ------------------------- >>>>>
        /// <summary>
        /// �݌Ɉړ�����o�^�A�X�V���܂�(�t�^�o�ʁ@���_�Ԕ�������)
        /// </summary>
        /// <param name="stockMoveList">stockMoveList�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        ///<remarks>
        /// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : K2013/12/10</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        ///</remarks>
        public int WriteForReceiveData(ref ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retMsg = "";

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retItemInfo = "";
            bool createHisData = true;
            string resNm = "";
            // ���_�Ԕ����f�[�^��Dictionary�̏�����
            Dictionary<string, ArrayList> orderDataDic = null;
            // �I�v�V�������̏�����
            int ps = 0;

            try
            {
                // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
                // �ďo�����\�b�h�擾
                try
                {
                    string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                    string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    OutputClcLog(string.Format("�݌Ɉړ��o�^���� �ďo��={0} �ďo�����\�b�h={1}", className, methodName));
                }
                catch
                {
                    //�����Ȃ�
                }
                // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
                ArrayList stockList = null; //�݌Ƀ��X�g
                ArrayList stockAcPayHistList = null; //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList = null; //�X�V�����݌Ɉړ����X�g
                ArrayList BFStockMoveList = null; //�X�V�O�ړ����X�g
                ArrayList defStockList = null; //�X�V�O�݌Ƀ��X�g
                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //�R�l�N�V��������
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //���_�ݒ�̎擾
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }

                // �V�X�e�����b�N(���_)
                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                ShareCheckInfo info = new ShareCheckInfo();

                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    // �������� Lock
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.WriteForReceiveData2_ShareCheckLocke:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //resNm = GetResourceName(enterpriseCode);
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteForReceiveData2_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                    return status;
                }
                #endif

                try
                {
                    for (int i = 1; i <= stockMoveList.Count; i++)
                    {
                        (stockMoveList[i - 1] as StockMoveWork).StockMoveRowNo = i;
                    }

                    //---�݌Ɉړ��`�[�ԍ��̔ԏ���---
                    if (stockMoveSlipNo == 0)//�݌Ɉړ��`�[
                    {
                        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    }
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                         // �o�ɁE���ɓ`�[�o�^
                         status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                    }

                    // �f�[�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        createHisData = true;
                        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);
                    }
                    
                    // �݌Ƀf�[�^�X�V
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }

                }
                finally
                {
                    #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    }

                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    int shareCheckReleaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", shareCheckReleaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", shareCheckReleaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", shareCheckReleaseStatus);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        shareCheckReleaseStatus = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (shareCheckReleaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", shareCheckReleaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    #endif
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        // ---- ADD K2013/12/10 wangl2 ------------------------- <<<<<

        // ---- ADD K2020/03/25 ���O�@�f�b�h���b�N�̑Ή� ---------->>>>>
        /// <summary>
        /// �݌Ɉړ�����o�^�A�X�V���܂�(�t�^�o�ʁ@���_�Ԕ�������)
        /// </summary>
        /// <param name="stockMoveList">stockMoveList�I�u�W�F�N�g</param>
        /// <param name="stockWorkList">stockWorkList�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        ///<remarks>
        /// <br>Note       : �݌Ɉړ�����o�^�A�X�V���܂�</br>
        /// <br>Programer  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�  : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        ///</remarks>
        public int WriteForSecOrderHandleDeadLock(ref ArrayList stockMoveList, ref ArrayList stockWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retMsg = "";

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retItemInfo = "";
            bool createHisData = true;
            string resNm = "";
            // ���_�Ԕ����f�[�^��Dictionary�̏�����
            Dictionary<string, ArrayList> orderDataDic = null;
            // �I�v�V�������̏�����
            int ps = 0;

            try
            {
                // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
                // �ďo�����\�b�h�擾
                try
                {
                    string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                    string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    OutputClcLog(string.Format("�݌Ɉړ��o�^���� �ďo��={0} �ďo�����\�b�h={1}", className, methodName));
                }
                catch
                {
                    //�����Ȃ�
                }
                // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
                ArrayList stockList = null; //�݌Ƀ��X�g
                ArrayList stockAcPayHistList = null; //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList = null; //�X�V�����݌Ɉړ����X�g
                ArrayList BFStockMoveList = null; //�X�V�O�ړ����X�g
                ArrayList defStockList = null; //�X�V�O�݌Ƀ��X�g
                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //�R�l�N�V��������
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //���_�ݒ�̎擾
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                        base.WriteErrorLog(string.Format("StockMoveDB.WriteForSecOrderHandleDeadLock:{0}", retMsg), status);
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "StockMoveDB.WriteForSecOrderHandleDeadLock:�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                    return status;
                }
                // �V�X�e�����b�N(���_)
                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                ShareCheckInfo info = new ShareCheckInfo();

                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                try
                {
                    // �������� Lock
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckLocke:" + ex.ToString());
                    throw ex;
                }

                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                //�`�o���b�N
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteForSecOrderHandleDeadLock_Lock:{0}", retMsg), status);
                    return status;
                }
                #endif

                try
                {
                    for (int i = 1; i <= stockMoveList.Count; i++)
                    {
                        (stockMoveList[i - 1] as StockMoveWork).StockMoveRowNo = i;
                    }

                    //---�݌Ɉړ��`�[�ԍ��̔ԏ���---
                    if (stockMoveSlipNo == 0)//�݌Ɉړ��`�[
                    {
                        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    }
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �o�ɁE���ɓ`�[�o�^
                        status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                    }

                    // �f�[�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        createHisData = true;
                        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);
                    }

                    // �݌Ƀf�[�^�X�V
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.WriteForStockMoveHandleDeadLock(origin, ref originList, ref paraList, ref stockWorkList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
                finally
                {
                    #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                    //�`�o�A�����b�N
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (resNm != "")
                    {
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                    }
                    
                    // �V�F�A�`�F�b�N
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        // �V�F�A�`�F�b�N����
                        releaseStatus = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                #endif
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockMoveDB.WriteForSecOrderHandleDeadLock", status);
                
            }

            return status;
        }
        // ---- ADD K2020/03/25 ���O�@�f�b�h���b�N�̑Ή� ----------<<<<<

        /// <summary>
        /// �݌Ɉړ����̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockMoveList">StockMoveWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉړ����̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.11</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int DeleteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlEncryptInfo sqlEncryptInfo       = null;
            CustomSerializeArrayList retList    = new CustomSerializeArrayList();

            string enterpriseCode   = "";
            string sectionCode      = "";
            int stockMoveFormal     = 0;
            int stockMoveSlipNo     = 0;
            int moveStatus          = 0;
            string retMsg           = "";
            string retItemInfo      = "";
            string resNm = "";
            // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
            // ���_�Ԕ����f�[�^��Dictionary�̏�����
            Dictionary<string, ArrayList> orderDataDic = null;
            // �I�v�V�������̏�����
            int ps = 0;
            // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

            try
            {
                ArrayList stockList             = null; //�݌Ƀ��X�g
                ArrayList stockAcPayHistList    = null; //�݌Ɏ󕥗������X�g
                ArrayList defStockMoveList      = null; //�X�V�����݌Ɉړ����X�g
                ArrayList defStockList          = null; //�X�V�O�݌Ƀ��X�g
                
                if (stockMoveList == null || stockMoveList.Count == 0) return status;

                //�p�����[�^�`�F�b�N
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //ADD 2011/09/02 #24259------------------------------->>>>>
                //�R�l�N�V��������
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //���_�ݒ�̎擾
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "���_�ݒ�̎擾�Ɏ��s���܂����B";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                // �o�ɑq�ɁE���ɑq�� �ǂݍ���
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;                

                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                ////�`�o���b�N
                //resNm = GetResourceName(enterpriseCode);
                // ��ƃR�[�h���󗓂̏ꍇ
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.DeleteForReceiveData:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.DeleteForReceiveData_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                    return status;
                }

                try
                {
                    // ---- ADD K2013/12/25 ���N�n�� ---- >>>>>
                    orderDataDic = new Dictionary<string, ArrayList>();
                    ps = 0;
                    // ---- ADD K2013/12/25 ���N�n�� ---- <<<<<

                    //�X�V�O�̍݌Ɉړ��f�[�^���擾
                    status = GetStockMove((int)ct_ProcMode.Delete, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //���ɘ_���폜�����͑��݂��Ȃ��ꍇ�@�������Ȃ�
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                    //�݌Ɍn�X�V�p�p�����[�^�쐬
                    //�f�[�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 ���N�n��
                        status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 ���N�n��

                    //�݌Ƀf�[�^�X�V
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.Delete(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
                finally
                {
                    //�`�o�A�����b�N
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                        }
                        else
                        {
                            //���r�����b�N����������
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }            
            return status;

        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="secCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/09/02</br>
        /// </remarks>
        private string GetSecNameBySecCode(string secCode)
        {
            if (string.IsNullOrEmpty(secCode))
            {
                return null;
            }
            if (secInfoSetWorkHash.Contains(secCode))
            {
                return secInfoSetWorkHash[secCode].ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion

        // --- ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή� ----->>>>>
        #region ���O�o��
        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���O�o�͏����B</br>
        /// <br>Programer  : 杍^</br>
        /// <br>Date       : K2019/02/27</br>
        /// <br>Update Note: K2021/02/02 ������</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00 PMKOBETSU-4114�Ή�</br>
        /// <br>             ���׏������O�ǉ��Ή�</br>
        /// </remarks>
        /// <returns>�Ȃ�</returns>
        public void OutputClcLog(string message)
        {
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
            try
            {
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<

                DateTime now = DateTime.Now;

                // ���O�t�@�C�����̍쐬
                // "MAZAI04124R"+DateTime��yyyyMMdd+�]�ƈ�ID
                ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                string logFileName = string.Format("MAZAI04124R_{0:yyyyMMdd}_{1}.log", now, serverLoginInfoAcquisition.EmployeeCode.Trim());

                // ���O���e
                string logContents = string.Format("{0} ==> {1}", now.ToString("yyyy/MM/dd HH:mm:ss fff"), message);

                // --- UPD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
                //KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
                //log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "CLCLogTextOut", logFileName, logContents);
                // LOG�t�H���_�փ��O�o��
                //WriteLog(logFileName, logContents);
                // CLC���O�o�͋敪��true�̏ꍇ�ACLC���O���o��
                if (ClcLogOutDiv)
                {
                    string guid = Guid.NewGuid().ToString().Replace("-", "");
                    string ClclogFileName = string.Format("MAZAI04124R_{0:yyyyMMddHHmmssfff}_{1}_{2}.log", now, serverLoginInfoAcquisition.EmployeeCode.Trim(), guid);
                    // ProgramData���փ��O�o��
                    KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
                    // clc���O�t�@�C����:"MAZAI04124R"+DateTime��yyyyMMdd+�]�ƈ�ID+Guid.NewGuid()
                    log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "CLCLogTextOut", ClclogFileName, logContents);
                }
                // �T�[�o�[���O�o�͋敪��true�̏ꍇ�A�T�[�o�[���O���o��
                if (ServerLogOutDiv)
                {
                    // LOG�t�H���_�փ��O�o��
                    WriteLog(logFileName, logContents);
                }
                // --- UPD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
            }
            catch
            {
                //�����Ȃ�
            }
            // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
        }

        /// <summary>
        /// LOG�t�H���_�փ��O�o��
        /// </summary>
        /// <param name="logFileName">���O�t�@�C����</param>
        /// <param name="message">���O���e</param>
        /// <remarks>
        /// <br>Note        : LOG�t�H���_�փ��O�o�͂��s���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : K2019/02/27</br>
        /// </remarks>
        private static void WriteLog(string logFileName, string message)
        {
            System.IO.StreamWriter writer = null;

            try
            {
                // Log�t�H���_�[
                string workDir; // ���s�t�@�C���̂���f�B���N�g��
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                string logFolderPath = System.IO.Path.Combine(workDir, "Log\\MAZAI04124R_RES");
                if (!System.IO.Directory.Exists(logFolderPath))
                {
                    // Log�t�H���_�[�����݂��Ȃ��ꍇ�A�쐬����
                    System.IO.Directory.CreateDirectory(logFolderPath);
                }

                // ���O�t�@�C��
                string logFilePath = System.IO.Path.Combine(logFolderPath, logFileName);
                writer = new System.IO.StreamWriter(logFilePath, true, System.Text.Encoding.Default);

                // ���O������
                writer.WriteLine(message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

        }

        /// <summary>
        /// �������������v�̏o��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�o�͏����B</br>
        /// <br>Programer  : 杍^</br>
        /// <br>Date       : K2019/02/27</br>
        /// </remarks>
        /// <returns>�������������v</returns>
        public string GetTotalMemory()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            long totalMb = Convert.ToInt64(computerInfo.TotalPhysicalMemory.ToString()) / 1024 / 1024;
            return totalMb.ToString();
        }

        /// <summary>
        /// ���p�\�����������̏o��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�o�͏����B</br>
        /// <br>Programer  : 杍^</br>
        /// <br>Date       : K2019/02/27</br>
        /// </remarks>
        /// <returns>���p�\����������</returns>
        public string GetAvaliableMemory()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            long avaliableMb = Convert.ToInt64(computerInfo.AvailablePhysicalMemory.ToString()) / 1024 / 1024;
            return avaliableMb.ToString();
        }
        #endregion
        // --- ADD BY 杍^ K2019/02/27 FOR Redmine#49811�̑Ή� -----<<<<<

        // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� --->>>>>
        #region XML�擾
        /// <summary>
        /// XML�擾
        /// </summary>
        /// <remarks>
        /// <br>Note        : XML�擾���s���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : K2021/02/02</br>
        /// </remarks>
        private void GetXml()
        {
            try
            {
                // Log�t�H���_�[
                string workDir; // ���s�t�@�C���̂���f�B���N�g��
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else// �����Ă���P�[�X
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                string filemPath = System.IO.Path.Combine(workDir, StockMoveLogOutCheckEnablerFileNm);
                // �݌Ɉړ����O�o�͉ې���t�@�C�������݂����ꍇ
                if (System.IO.File.Exists(filemPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(filemPath, settings))
                    {
                        // �݌Ɉړ����O�o�͉ې���t�@�C����ǂݍ���
                        while (reader.Read())
                        {
                            //CLC���O�o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement("ClcLogOutDiv")) ClcLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ClcLogOutDiv").Trim());
                            //�T�[�o�[���O�o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement("ServerLogOutDiv")) ServerLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ServerLogOutDiv").Trim());
                        }
                    }
                }
                else�@// �݌Ɉړ����O�o�͉ې���t�@�C�������݂��Ȃ��ꍇ
                {
                    ClcLogOutDiv = false;
                    ServerLogOutDiv = false;
                }
                FirstFlg = false;
            }
            catch
            {
                ClcLogOutDiv = false;
                ServerLogOutDiv = false;
                FirstFlg = true;
            }
        }
        #endregion
        // --- ADD BY ������ K2021/02/02 FOR PMKOBETSU-4114�̑Ή� ---<<<<<
    }

    #region ��r�N���X
    /// <summary>
    /// �݌Ɉړ��N���X��r�N���X
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class StockMoveWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// �ړ��`�[��r���\�b�h
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockMoveWork cx = (StockMoveWork)x;
            StockMoveWork cy = (StockMoveWork)y;

            //�݌Ɉړ��`�[�ԍ�
            result = cx.StockMoveSlipNo - cy.StockMoveSlipNo;
            //�݌Ɉړ��s�ԍ�
            if (result == 0)
                result = cx.StockMoveRowNo - cy.StockMoveRowNo;

            //���ʂ�Ԃ�
            return result;
        }
    }
    #endregion

}
