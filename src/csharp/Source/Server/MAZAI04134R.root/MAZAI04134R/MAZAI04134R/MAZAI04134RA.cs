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
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library;
using System.Reflection;
using System.IO;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using System.Xml;
using Microsoft.Win32;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
using System.Threading;//ADD 2021/06/10 �c���� PMKOBETSU-4144

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɂ̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.01.18</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� PM.NS�p�ɏC��</br>
    /// <br>Date       : 2008.07.03</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� �s��C��</br>
    /// <br>Date       : 2009.05.25</br>
    /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
    /// <br>             �݌Ƀ}�X�^���_���폜����Ă���ꍇ�̕ύX</br>
    /// <br>UpdateNote : 2010/10/13 22018 ��� ���b</br>
    /// <br>             �����c�����}�C�i�X�ɂȂ鎞�A�[���ŕ␳����悤�C���B(�����d����Mor�݌ɓ��ɍX�V)</br>
    /// <br>UpdateNote : �{�z��</br>
    /// <br>Date       : 2011/07/12</br>
    /// <br>           : �A��No.1027 �����c���}�C�i�X�ɂȂ�ꍇ�́A�Œ�łO���Z�b�g���Ă��邪�A�����d����M���N�����ƂȂ�ꍇ�́A�����c�̃}�C�i�X��������B</br>
    /// <br>UpdateNote : 2011/07/20 �{�z�� </br>
    /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���̑Ή�</br>
    /// <br>UpdateNote : 2011/07/21 �x�c </br>
    /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���Ή��̎擾���̏C��</br>
    /// <br>UpdateNote : 2011/08/29 wangf </br>
    /// <br>             NS���[�U�[���Ǘv�]�ꗗ_20110629_�D��_PM7����_��Q_�A��1016�A�݌Ƀ}�X�^�̏o�׉\���̍X�V�d�l�̕ύX�C���̑Ή�</br>
    /// <br>UpdateNote : 2011/11/29 30517 �Ė� �x��</br>
    /// <br>             ���i�݌Ɉꊇ�o�^�C���������̃^�C���A�E�g���Ԃ�60�b�ɉ���</br>
    /// <br>Update Note: 2012/05/29 zhangy3 </br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
    /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
    /// <br>Update Note: 2013/10/09 yangyi</br>
    /// <br>             redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���</br>
    /// <br>UpdateNote : 2013/11/13 �A���� </br>
    /// <br>�Ǘ��ԍ�   : 10904948-00 �t�^�o��</br>
    /// <br>             Redmine#41201 �@�\:EMC�捞�蓮:PMUOE01751UC�@����:PMUOE01770UC�@SPK�捞����:PMUOE01800UC�@�蓮:PMUOE01802UC�@�����c�̃}�C�i�X��������</br>
    /// <br>UpdateNote : K2014/01/06 wangl2 </br>
    /// <br>�Ǘ��ԍ�   : 10970522-00 �t�^�o��</br>
    /// <br>UpdateNote : 2014/01/15 huangt </br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>             Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC��</br>
    /// <br>Update Note: 2014/02/06 ���� ����q</br>
    /// <br>�Ǘ��ԍ�   : </br>
    /// <br>           : SCM�d�|�ꗗ��10632�Ή�</br>
    /// <br>Update Note: 2014/08/13 ����</br>
    /// <br>             PMSCM�������Ή��̕ύX</br>
    /// <br>Update Note: K2020/03/25 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00 PMKOBETSU-3622�Ή�</br>
    /// <br>             UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br> 
    /// <br>Update Note: 2021/06/10 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
    /// </remarks>
    [Serializable]
    public class StockDB : RemoteWithAppLockDB, IStockDB, IFunctionCallTargetWrite, IFunctionCallTargetRead
    {
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
        // ���g���C��-�f�t�H���g�F5��
        private const int RETRY_COUNT_DEFAULT = 5;
        // ���g���C�Ԋu-�f�t�H���g�F60�b
        private const int RETRY_INTERVAL_DEFAULT = 60;
        // ���O�o��PGID
        private const string CURRENT_PGID = "MAZAI04134R";
        // �G���[���b�Z�[�W
        private const string ERR_MEG_W = "WriteStockBlanketProcReTry�f�b�h���b�N���� ���g���C�񐔁F{0}���";
        // �G���[���b�Z�[�W
        private const string ERR_MEG_D = "DeleteStockProcReTry�f�b�h���b�N���� ���g���C�񐔁F{0}���";
        // �f�b�h���b�N1205
        private const int DEAD_LOCK_VALUE = 1205;
        // SavePoint(WriteStockBlanketProcReTry)
        private const string SAVEPPIONT_W = "WriteStockBlanketProcReTry";
        // SavePoint(DeleteStockProcReTry)
        private const string SAVEPPIONT_D = "DeleteStockProcReTry";
        // �萔(0)
        private const int ZERO_VALUE = 0;
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<

        /// <summary>
        /// �݌�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        public StockDB()
            :
            base("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork", "STOCKRF")
        {
        }

        #region �萔
        /// <summary>�����敪</summary>
        public enum ct_ProcMode
        {
            /// <summary>�d��</summary>
            StockSlip = 0,
            /// <summary>�ړ�</summary>
            StockMove = 1,
            /// <summary>�̔�</summary>
            Sales = 2,
            /// <summary>����</summary>
            StockAdjust = 3
        }

        /// <summary>�X�V�����敪</summary>
        public enum ct_WriteMode
        {
            /// <summary>�X�V</summary>
            Write = 0,
            /// <summary>�폜</summary>
            delete = 1
        }

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        #endregion

        #region 
        /// <summary>�I���X�V�敪</summary>
        private int _whUpdateDiv = 0;
        #endregion

        #region [OtherRemote]
        private StockAcPayHistDB _stockAcPayHistDB = new StockAcPayHistDB();    //�݌Ɏ󕥗��������[�g
        private StockMngTtlStDB _stockMngTtlStDB = new StockMngTtlStDB();       //�݌ɊǗ��S�̐ݒ�
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�
        /// </summary>
        /// <param name="stockWork">��������</param>
        /// <param name="parastockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int Search(out object stockWork, object parastockWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockProc(out stockWork, parastockWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Search");
                stockWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockWork">��������</param>
        /// <param name="parastockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int SearchStockProc(out object objstockWork, object parastockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockWork stockWork = null;

            ArrayList stockWorkList = parastockWork as ArrayList;
            if (stockWorkList == null)
            {
                stockWork = parastockWork as StockWork;
            }
            else
            {
                if (stockWorkList.Count > 0)
                    stockWork = stockWorkList[0] as StockWork;
            }

            int status = SearchStockProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
            objstockWork = stockWorkList;
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p �����񓚏�����p)
        /// </summary>
        /// <param name="objstockWork">��������</param>
        /// <param name="parastockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br></br>
        public int SearchStockForAutoSearchProc(out object objstockWork, object parastockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            List<StockWork> stockWork = new List<StockWork>();
            ArrayList stockWorkList;

            stockWork = parastockWork as List<StockWork>;

            int status = SearchStockProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
            objstockWork = stockWorkList;
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="stockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int SearchStockProc(out ArrayList stockWorkList, StockWork stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockProcProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p �����񓚏�����p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="stockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br></br>
        public int SearchStockProc(out ArrayList stockWorkList, List<StockWork> stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockProcProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<


        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="stockWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
        private int SearchStockProcProc(out ArrayList stockWorkList, StockWork stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockWork, logicalMode);

                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockWorkFromReader(ref myReader,0));

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

            stockWorkList = al;

            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWorkList">��������</param>
        /// <param name="stockWork">�����p�����[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br></br>
        private int SearchStockProcProc(out ArrayList stockWorkList, List<StockWork> stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockWork, logicalMode);

                sqlCommand.CommandTimeout = 60;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockWorkFromReader(ref myReader, 0));

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

            stockWorkList = al;

            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɂ�߂��܂�
        /// </summary>
        /// <param name="parabyte">StockWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɂ�߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockWork stockWork = new StockWork();

                // XML�̓ǂݍ���
                stockWork = (StockWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockWork));
                if (stockWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(stockWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Read");
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
        /// �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int ReadProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref stockWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
        private int ReadProcProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockWork = CopyToStockWorkFromReader(ref myReader,0);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int ReadProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProcProc(ref stockWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɂ�߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
        private int ReadProcProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        stockWork = CopyToStockWorkFromReader(ref myReader,0);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        #region [Write]
        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int Write(ref object stockWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            string resNm = "";
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(stockWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //resNm = GetResourceName(((StockWork)paraList[0]).EnterpriseCode);
                string enterpriseCode = ((StockWork)paraList[0]).EnterpriseCode;
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
                            base.WriteErrorLog("StockDB.Write1:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockDB.Write1:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                //�`�o���b�N
                status = Lock(resNm,sqlConnection,sqlTransaction);
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string retMsg = string.Empty;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }
                    base.WriteErrorLog(string.Format("StockDB.Write1_Lock:{0}", retMsg), status);
                }
                // --- ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

                //write���s
                status = WriteStockProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                //�߂�l�Z�b�g
                stockWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Write(ref object stockWork)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                ////�`�o�A�����b�N
                //Release(resNm, sqlConnection, sqlTransaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (sqlConnection == null)
                {
                    base.WriteErrorLog("StockDB.Write1_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (sqlTransaction == null)
                {
                    base.WriteErrorLog("StockDB.Write1_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (sqlTransaction.Connection == null)
                {
                    base.WriteErrorLog("StockDB.Write1_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    //���r�����b�N����������
                    releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("StockDB.Write1_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }
                // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // �R�~�b�g
                        //sqlTransaction.Commit(); // DEL ���� 2014/08/13
                    //----- ADD START ���� 2014/08/13 ----->>>>>>
                    {
                        sqlTransaction.Commit();
                        //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                        //synchExecuteMng.SyncReqExecute();
                    }
                    //----- ADD END ���� 2014/08/13 -----<<<<<<
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
        /// �݌ɏ��X�V����(�r���L�E�݌ɒ����p)
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="stockAcPayHistWorkList">�݌Ɏ󕥗������X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int Write(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";

            //���R�l�N�V�������p�����[�^�`�F�b�N
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                return status;
            }
            
            string resNm = "";
            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.Write2:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.Write2:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.Write2:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.Write2:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

                if (resNm != "")
                {
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
                        base.WriteErrorLog(string.Format("StockDB.Write2_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                        return status;
                    }

                }

                //�݌Ƀf�[�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockProc(ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�̍X�V�Ɏ��s���܂����B";
                }

                //�X�V��̍݌Ƀf�[�^���݌Ɏ󕥗����f�[�^�֔��f
                if (stockAcPayHistWorkList != null && stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //�݌Ɏ󕥗����}�X�^�X�V
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�̍X�V�Ɏ��s���܂����B";
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    ////�`�o�A�����b�N
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.Write2_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.Write2_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.Write2_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.Write2_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
            }
            return status;
        }

        /// <summary>
        /// �݌Ɉꊇ�o�^����̍݌ɏ��X�V
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="stockAcPayHistWorkList">�݌Ɏ󕥗������X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteStockBlanket(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StockMngTtlStWork stockMngTtlStWork = null;     //�݌ɊǗ��S�̐ݒ�
            retMsg = "";
            
            string resNm = "";
            
            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.WriteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.WriteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
                   
                if (resNm != "")
                {
                    //�`�o���b�N
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
                        base.WriteErrorLog(string.Format("StockDB.WriteStockBlanket_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                        return status;
                    }

                }
                
                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                    return status;
                }

                //�݌ɊǗ��S�̐ݒ�擾
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌ɊǗ��S�̐ݒ���擾�Ɏ��s���܂����B";
                }

                //�݌Ƀf�[�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockBlanketProc((int)(int)ct_ProcMode.StockAdjust,(int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�̍X�V�Ɏ��s���܂����B";
                }

                //�X�V��̍݌Ƀf�[�^���݌Ɏ󕥗����f�[�^�֔��f
                if (stockAcPayHistWorkList != null && stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //�݌Ɏ󕥗����}�X�^�X�V
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�̍X�V�Ɏ��s���܂����B";
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    ////�`�o�A�����b�N
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStockBlanket_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStockBlanket_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStockBlanket_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteStockBlanket_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

            }
            return status;
        }

        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- >>>>>
        /// <summary>
        /// �݌Ɉꊇ�o�^����̍݌ɏ��X�V
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2014/01/10</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br></br>
        public int WriteStock(ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StockMngTtlStWork stockMngTtlStWork = null;     //�݌ɊǗ��S�̐ݒ�
            retMsg = "";

            string resNm = "";

            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.WriteStock:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteStock:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

                if (resNm != "")
                {
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
                        base.WriteErrorLog(string.Format("StockDB.WriteStock_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                        return status;
                    }

                }

                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                    return status;
                }

                //�݌ɊǗ��S�̐ݒ�擾
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌ɊǗ��S�̐ݒ���擾�Ɏ��s���܂����B";
                }

                //�݌Ƀf�[�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockBlanketProc((int)(int)ct_ProcMode.StockAdjust, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�̍X�V�Ɏ��s���܂����B";
                }

            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    ////�`�o�A�����b�N
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStock_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStock_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStock_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteStock_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

            }
            return status;
        }
        // ----- ADD huangt 2014/01/15 Redmine#40998 �ݏo���̕ύX���\�ɂ���悤�ɏC�� ----- <<<<<

        /// <summary>
        /// �݌Ɉꊇ�o�^����̍݌ɏ��폜
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="stockAcPayHistWorkList">�݌Ɏ󕥗������X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int DeleteStockBlanket(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";

            string resNm = "";

            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.DeleteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.DeleteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.DeleteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.DeleteStockBlanket:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

                if (resNm != "")
                {
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
                        base.WriteErrorLog(string.Format("StockDB.DeleteStockBlanket_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                        return status;
                    }

                }

                //���R�l�N�V�������p�����[�^�`�F�b�N
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                    return status;
                }

                //�݌Ƀ}�X�^�����폜
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteStockProc(stockWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�̍폜�Ɏ��s���܂����B";
                }

                //�݌Ɏ󕥗����}�X�^�X�V
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�̍X�V�Ɏ��s���܂����B";
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    ////�`�o�A�����b�N
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }

            }

            return status;
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int WriteStockProc(ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockProcProc(ref stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        private int WriteStockProcProc(ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            bool insflg = false;
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        selectTxt = "";

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (stockWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            insflg = false;
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
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
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeader���\�b�h��logicalDeleteCode���㏑�������邽��
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            insflg = true;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START ���{ 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END ���{ 2015/01/28 -----<<<<<<	
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

            stockWorkList = al;

            return status;
        }

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        /// <summary>
        /// �o�׉\���ݒ菈��
        /// </summary>
        /// <param name="stockWork">�݌Ƀf�[�^</param>
        /// <br>Note       : �o�׉\���ݒ菈��</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2011/08/29 wangf �A��1016�̑Ή�</br>
        private void SetShipmentPosCnt(ref StockWork stockWork)
        {
            // -- add wangf 2011/08/29 ---------->>>>>
            // �݌ɊǗ��S�̐ݒ�́u���݌ɕ\���敪�v�ɂ��A�󒍐��͎Z�o�����ǉ��̔��f
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = stockWork.EnterpriseCode;
            stockMngTtlStWork.SectionCode = "00";
            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);
            // �݌ɊǗ��S�̐ݒ�ǂݍ���
            int status = stockMngTtlStDB.Read(ref parabyte, 0);
            if (status == 0)
            {
                // XML�̓ǂݍ���
                stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
            }
            // -- add wangf 2011/08/29 ----------<<<<<
            //����������������������������������������������������������������������������������������������������
            //�o�׉\���̌v�Z��
            //�o�׉\�����d���݌ɐ��{���א��i���v��j�[ �o�א��i���v��j�[ �󒍐� �[ �ړ����d���݌ɐ�
            //����������������������������������������������������������������������������������������������������

            // double�^�ɂ��v�Z�ł͊ۂߌ덷���������Ă��܂��ׁAdecimal�^�ɃL���X�g���Čv�Z����
            decimal SupplierStock = (decimal)stockWork.SupplierStock;
            decimal ArrivalCnt = (decimal)stockWork.ArrivalCnt;
            decimal ShipmentCnt = (decimal)stockWork.ShipmentCnt;
            decimal AcpOdrCount = (decimal)stockWork.AcpOdrCount;
            decimal MovingSupliStock = (decimal)stockWork.MovingSupliStock;
            //stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - AcpOdrCount - MovingSupliStock); // del wangf 2011/08/29
            // -- add wangf 2011/08/29 ---------->>>>>
            if (stockMngTtlStWork.PreStckCntDspDiv == 0)
            {
                // �󒍕��܂�
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - AcpOdrCount - MovingSupliStock);
            }
            else
            {
                // �󒍕��܂܂Ȃ�
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - MovingSupliStock);
            }
            // -- add wangf 2011/08/29 ----------<<<<<
        }

        /// <summary>
        /// ���z�v�Z����
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="wkStockWork">�X�V�O�݌Ƀf�[�^</param>
        /// <param name="stockWork">����X�V�݌Ƀf�[�^</param>
        /// <br>Note       : �݌ɕ]�����@�ɂ����z�v�Z�������s���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.04.24</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        private void SetStockPrice(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref StockWork wkStockWork, ref StockWork stockWork)
        {

            if (wkStockWork != null)
            {
                //---�����f�[�^�L�̏ꍇ---//

                //�݌ɕ]�����@�ɂ��d���P���̎Z�o�ؑ�
                switch (stockMngTtlStWork.StockPointWay)
                {

                    //-------------------------------------------------------------------
                    //�ŏI�d�������@
                    //-------------------------------------------------------------------
                    case (int)ConstantManagement_Mobile.ct_StockPointWay.Last:

                        //�������d���P���ݒ聙����
                        //�d���P�� = ����d���P�� 
                        if ((wkStockWork.LastStockDate <= stockWork.LastStockDate) && (stockWork.SupplierStock >= 0))//����̎d�������ŏI�̎d�������V�����ꍇ���݌ɐ��ʂ��P�ȏ�̏ꍇ
                            wkStockWork.StockUnitPriceFl = stockWork.StockUnitPriceFl;

                        //�������݌ɕۗL���z�ݒ聙����
                        //�݌ɕۗL���z = �d���P�� * ����d���݌ɐ�
                        wkStockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(wkStockWork.StockUnitPriceFl * wkStockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);
                        break;

                    //-------------------------------------------------------------------
                    //�ړ����ϖ@
                    //-------------------------------------------------------------------
                    case (int)ConstantManagement_Mobile.ct_StockPointWay.Average:

                        //�������݌ɕۗL���z�ݒ聙����
                        if (stockWork.StockTotalPrice != 0)
                            //�݌ɕۗL���z += ����݌ɕۗL���z
                            wkStockWork.StockTotalPrice += stockWork.StockTotalPrice;
                        else
                            //�݌ɕۗL���z += ����d���P�� * ����d���݌ɐ�
                        wkStockWork.StockTotalPrice += (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                        //�������d���P���ݒ聙����
                        if (stockWork.SupplierStock >= 0)//�݌ɐ��ʂ��P�ȏ�̏ꍇ
                            if (procMode == (int)ct_ProcMode.StockSlip || procMode == (int)ct_ProcMode.StockAdjust || procMode == (int)ct_ProcMode.StockMove)
                            {
                                if (wkStockWork.StockTotalPrice != 0 && wkStockWork.SupplierStock != 0)
                                {
                                    //�d���P�� = �[�������i�݌ɕۗL���z / �d���݌ɐ��j
                                    double dbluprice = wkStockWork.StockTotalPrice / wkStockWork.SupplierStock;
                                    if (dbluprice != 0)
                                        wkStockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(dbluprice, stockMngTtlStWork.FractionProcCd);
                                }
                                else
                                    wkStockWork.StockUnitPriceFl = 0;
                            }
                        break;

                    //-------------------------------------------------------------------
                    //�ʒP���@
                    //-------------------------------------------------------------------
                    case (int)ConstantManagement_Mobile.ct_StockPointWay.Individual:

                        //�������݌ɕۗL���z�ݒ聙����
                        if (stockWork.StockTotalPrice != 0)
                            //�݌ɕۗL���z += ����݌ɕۗL���z
                            wkStockWork.StockTotalPrice += stockWork.StockTotalPrice;
                        else
                            //�݌ɕۗL���z += ����d���P�� * ����d���݌ɐ�
                            wkStockWork.StockTotalPrice += (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                        //�������d���P���ݒ聙����
                        //if (stockWork.SupplierStock > 0)//�݌ɐ��ʂ��P�ȏ�̏ꍇ
                        if (wkStockWork.StockTotalPrice != 0 && wkStockWork.SupplierStock != 0)
                        {
                            //�d���P�� = �[�������i�݌ɕۗL���z / �d���݌ɐ��j
                            wkStockWork.StockUnitPriceFl = CalculateConsTax.Fraction((wkStockWork.StockTotalPrice / wkStockWork.SupplierStock), stockMngTtlStWork.FractionProcCd);
                        }
                        else
                            wkStockWork.StockUnitPriceFl = 0;
                        break;
                }

                //�V�����ŏI�d���N�����̕����ŐV�̓��t�̏ꍇ�ŏI�d���N�������X�V
                if (wkStockWork.LastStockDate <= stockWork.LastStockDate)
                    wkStockWork.LastStockDate = stockWork.LastStockDate;
            }
            else
            {
                if (stockWork.StockUnitPriceFl > 0)
                {
                    //---�V�K�̏ꍇ---//
                    //�݌ɕ]�����@�ɂ��d���P���̎Z�o�ؑ�
                    switch (stockMngTtlStWork.StockPointWay)
                    {

                        //-------------------------------------------------------------------
                        //�ŏI�d�������@
                        //-------------------------------------------------------------------
                        case (int)ConstantManagement_Mobile.ct_StockPointWay.Last:

                            //�������݌ɕۗL���z�ݒ聙����
                            //�݌ɕۗL���z = ����d���P�� * ����d���݌ɐ�
                            stockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);
                            break;

                        //-------------------------------------------------------------------
                        //�ړ����ϖ@
                        //-------------------------------------------------------------------
                        case (int)ConstantManagement_Mobile.ct_StockPointWay.Average:

                            //�������݌ɕۗL���z�ݒ聙����
                            //�݌ɕۗL���z = ����d���P�� * ����d���݌ɐ�
                            stockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                            //�������d���P���ݒ聙����
                            if (stockWork.SupplierStock >= 0)//�݌ɐ��ʂ��P�ȏ�̏ꍇ
                                if (procMode == (int)ct_ProcMode.StockSlip || procMode == (int)ct_ProcMode.StockAdjust || procMode == (int)ct_ProcMode.StockMove)
                                {
                                    if (stockWork.StockTotalPrice != 0 && stockWork.SupplierStock != 0)
                                    {
                                        //�d���P�� = �[�������i�݌ɕۗL���z / �d���݌ɐ��j
                                        double dbluprice = stockWork.StockTotalPrice / stockWork.SupplierStock;
                                        if (dbluprice != 0)
                                            stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(dbluprice, stockMngTtlStWork.FractionProcCd);
                                    }
                                    else
                                        stockWork.StockUnitPriceFl = 0;
                                }
                            break;

                        //-------------------------------------------------------------------
                        //�ʒP���@
                        //-------------------------------------------------------------------
                        case (int)ConstantManagement_Mobile.ct_StockPointWay.Individual:

                            //�������݌ɕۗL���z�ݒ聙����
                            //�݌ɕۗL���z = ����d���P�� * ����d���݌ɐ�
                            if (stockWork.StockTotalPrice == 0)
                                stockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                            //�������d���P���ݒ聙����
                            //if (stockWork.SupplierStock > 0)//�݌ɐ��ʂ��P�ȏ�̏ꍇ
                            if (stockWork.StockTotalPrice != 0 && stockWork.SupplierStock != 0)
                            {
                                //�d���P�� = �[�������i�݌ɕۗL���z / �d���݌ɐ��j
                                stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction((stockWork.StockTotalPrice / stockWork.SupplierStock), stockMngTtlStWork.FractionProcCd);
                            }
                            else
                                stockWork.StockUnitPriceFl = 0;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int StockAddCountUPProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return StockAddCountUPProcProc(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �݌Ƀ}�X�^���_���폜����Ă���ꍇ�̕ύX</br>
        /// <br>UpdateNote : 2011/07/12 �{�z�� </br>
        /// <br>             �A��No.1027 �����c���}�C�i�X�ɂȂ�ꍇ�́A�Œ�łO���Z�b�g���Ă��邪�A�����d����M���N�����ƂȂ�ꍇ�́A�����c�̃}�C�i�X��������B</br>
        /// <br>UpdateNote : 2011/07/20 �{�z�� </br>
        /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���̑Ή�</br>
        /// <br>UpdateNote : 2011/07/21 �x�c </br>
        /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���Ή��̎擾���̏C��</br>
        /// <br>UpdateNote : 2013/11/13 �A���� </br>
        /// <br>�Ǘ��ԍ�   : 10904948-00 �t�^�o��</br>
        /// <br>             Redmine#41201 �@�\:EMC�捞�蓮:PMUOE01751UC�@����:PMUOE01770UC�@SPK�捞����:PMUOE01800UC�@�蓮:PMUOE01802UC�@�����c�̃}�C�i�X��������</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br> 
        private int StockAddCountUPProcProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StockWork wkStockWork = null;
            bool insflg = false;
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //�X�V�`�F�b�N����
                        //Select�R�}���h�̐���
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        sqlCommand.CommandTimeout = dbCommandTimeout;  //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //���݂̃f�[�^���N���X�֊i�[
                            wkStockWork = CopyToStockWorkFromReader(ref myReader,1);

                            //������������������������������������������������������������������������������������
                            //���ʂ̍X�V
                            //���ʂ̑�������(�n���ꂽ�p�����[�^�̐��ʂ��l������Ă�����̂Ƃ��ĒP���ɉ��Z���܂��B
                            //���ۂ͒ʏ�Ȃ�v���X�A�ԓ`��������ȂǍ폜�̏ꍇ�̓}�C�i�X�ɂȂ�܂��B)
                            //������������������������������������������������������������������������������������
                            
                            // double�^�̂܂܂Ōv�Z���s���Ɗۂߌ덷��������ꍇ(�� 0.37 + 0.31 = 0.67999999999999994)
                            // ������̂�decimal�^�ɃL���X�g���Čv�Z����
                            wkStockWork.SupplierStock = (double)((decimal)wkStockWork.SupplierStock + (decimal)stockWork.SupplierStock);
                            wkStockWork.AcpOdrCount = (double)((decimal)wkStockWork.AcpOdrCount + (decimal)stockWork.AcpOdrCount);
                            wkStockWork.SalesOrderCount = (double)((decimal)wkStockWork.SalesOrderCount + (decimal)stockWork.SalesOrderCount);
                            wkStockWork.MovingSupliStock = (double)((decimal)wkStockWork.MovingSupliStock + (decimal)stockWork.MovingSupliStock);
                            wkStockWork.ShipmentCnt = (double)((decimal)wkStockWork.ShipmentCnt + (decimal)stockWork.ShipmentCnt);
                            wkStockWork.ArrivalCnt = (double)((decimal)wkStockWork.ArrivalCnt + (decimal)stockWork.ArrivalCnt);

                            // --- UPD 2011/07/12 ---------->>>>>
                            // --- ADD m.suzuki 2010/10/13 ---------->>>>>
                            //  // �����c�����}�C�i�X�ɂȂ�ꍇ�̓[���ŕ␳����B
                            //  if ( wkStockWork.SalesOrderCount < 0 )
                            //  {
                            //    wkStockWork.SalesOrderCount = 0;
                            //  }
                            //  // --- ADD m.suzuki 2010/10/13 ----------<<<<<
                            
                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //---�N�����v���Z�X�̎擾
                            //Assembly myAssembly = Assembly.GetEntryAssembly();
                            //string path1 = myAssembly.Location;
                            //string path2 = Path.GetFileName(path1);
                            object obje = (object)this;
                            FileHeader filehd2 = new FileHeader(obje);

                            string path2 = filehd2.UpdAssemblyId1;
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            
                            // �����d����M�ȊO�ŁA�����c�����}�C�i�X�ɂȂ�ꍇ�̓[���ŕ␳
                            // --- ADD 2011/07/20 ---------->>>>>
                            int tempIndex = path2.IndexOf(":");
                            if (tempIndex > 0)
                            {
                                path2 = path2.Substring(0, tempIndex);
                            }
                            // --- ADD 2011/07/20 ----------<<<<<
                            
                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //if (path2 != "PMUOE01300U.exe")
                            //if (path2 != "PMUOE01300U")//DEL 2013/11/13�@�A���� Redmine#41201 �V�X�e����Q�ꗗ��2�@�����c�̃}�C�i�X��������u�@�\:EMC�捞�蓮:PMUOE01751UC�@����:PMUOE01770UC�@SPK�捞����:PMUOE01800UC�@�蓮:PMUOE01802UC�v
                            //if (path2 != "PMUOE01300U" && path2 != "PMUOE01751UC" && path2 != "PMUOE01770UC" && path2 != "PMUOE01800UC" && path2 != "PMUOE01802UC")//ADD 2013/11/13�@�A���� Redmine#41201 �V�X�e����Q�ꗗ��2�@�����c�̃}�C�i�X��������//DEL K2014/01/06�@wangl2�@�t�^�o
                            if (path2 != "PMUOE01300U" && path2 != "PMUOE01751UC" && path2 != "PMUOE01770UC" && path2 != "PMUOE01800UC" && path2 != "PMUOE01802UC" && path2 != "PMZAI01101UC")//ADD K2014/01/06�@wangl2�@�t�^�o
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            {
                                if (wkStockWork.SalesOrderCount < 0)
                                {
                                    wkStockWork.SalesOrderCount = 0;
                                }
                            }�@�@    
                            // --- UPD 2011/07/12 ----------<<<<<
                            //�V�����ŏI������̕����ŐV�̓��t�̏ꍇ�ŏI��������X�V
                            if (wkStockWork.LastSalesDate <= stockWork.LastSalesDate)
                                wkStockWork.LastSalesDate = stockWork.LastSalesDate;    //�ŏI�����

                            //�V�����ŏI�I���X�V���̕����ŐV�̓��t�̏ꍇ�ŏI�I���X�V�����X�V
                            if (wkStockWork.LastInventoryUpdate <= stockWork.LastInventoryUpdate)
                                wkStockWork.LastInventoryUpdate = stockWork.LastInventoryUpdate;    //�ŏI�I���X�V��
                            
                            // 2009/06/26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //�V�����ŏI�d�����̕����ŐV�̓��t�̏ꍇ�ŏI�d�������X�V
                            if (wkStockWork.LastStockDate <= stockWork.LastStockDate)
                                wkStockWork.LastStockDate = stockWork.LastStockDate;    //�ŏI�d����
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //�o�׉\���ݒ菈��
                            SetShipmentPosCnt(ref wkStockWork);

                            //������������������������������������������������������������������������������������
                            //�d���P���̍X�V
                            //������������������������������������������������������������������������������������
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            //�����f�[�^����̌Ăяo���̏ꍇ�ŒI�ԍX�V�敪�u0:����v�̏ꍇ�ɒI�Ԃ��X�V����
                            if ((procMode == (int)ct_ProcMode.StockAdjust) && (_whUpdateDiv == 0))
                            {
                                wkStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            
                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wkStockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            stockWork = wkStockWork;    //�p�����[�^����ւ�

                            // --- ADD 2009/12/03 ---------->>>>>
                            // �݌Ƀ}�X�^���_���폜����Ă���ꍇ
                            if (stockWork.LogicalDeleteCode == 1)
                            {
                                stockWork.LogicalDeleteCode = 0;
                            }
                            // --- ADD 2009/12/03 ----------<<<<<

                            insflg = false;
                        }
                        else
                        {
                            #region �݌Ƀf�[�^�V�K�쐬����
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
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
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeader���\�b�h��logicalDeleteCode���㏑�������邽��
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            #endregion

                            // --- ADD 2009/12/03 ---------->>>>>
                            // �݌Ƀ}�X�^�����o�^��
                            stockWork.StockUnitPriceFl = 0;
                            // --- ADD 2009/12/03 ----------<<<<<

                            //�o�׉\���ݒ菈��
                            SetShipmentPosCnt(ref stockWork);
                            //������������������������������������������������������������������������������������
                            //�d���P���̍X�V
                            //������������������������������������������������������������������������������������
                            wkStockWork = null;
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            insflg = true;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            // 2009/06/26 MANTIS 13242 >>>>>>>>>>>>>>>>>>>>>>>>>>
                            //paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDateTime);
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START ���{ 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END ���{ 2015/01/28 -----<<<<<<	
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

            stockWorkList = al;

            return status;
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        public int WriteStockBlanketProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
            //return WriteStockBlanketProcProc(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
            // ���g���C��
            int retryCnt = ZERO_VALUE;
            // ���O�o�̓N���X
            OutLogCommon outLogCommonObj = new OutLogCommon();
            // ���g���C�ݒ胏�[�N
            RetrySet retrySettingInfo = new RetrySet();
            // ���g���C�ݒ�擾�o�͕��i
            RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
            retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

            return this.WriteStockBlanketProcReTry(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<
        }

        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>> 
        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <param name="outLogCommonObj">���O�o�̓N���X</param>
        /// <param name="retrySettingInfo">���g���C�ݒ胏�[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        private int WriteStockBlanketProcReTry(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();

            // ���g���C��
            retryCnt++;

            // savepiont�ݒ�
            sqlTransaction.Save(SAVEPPIONT_W);

            bool lastRetry = false;
            if (retryCnt == retrySettingInfo.RetryCount)
            {
                lastRetry = true;
            }

            // �݌ɏ���o�^�A�X�V����
            status = WriteStockBlanketProcProc(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction, lastRetry);

            //�f�b�h���b�N�̏ꍇ
            if (status == DEAD_LOCK_VALUE)
            {
                // ���O�o��
                outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG_W, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, null);
                // ���g���C�񐔂܂�
                if (retryCnt >= retrySettingInfo.RetryCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//����STATUS�l�𕜌�
                }
                else
                {
                    // �ݒ肵��savepoint�����[���o�b�N
                    sqlTransaction.Rollback(SAVEPPIONT_W);
                    // ���g���C�Ԋu��sleep
                    Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                    // ���g���C�������s��
                    status = this.WriteStockBlanketProcReTry(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
                }
            }

            return status;
        }
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<< 

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="lastRetry">���g���C�t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>UpdateNote : 2011/07/12 �{�z�� </br>
        /// <br>             �A��No.1027 �����c���}�C�i�X�ɂȂ�ꍇ�́A�Œ�łO���Z�b�g���Ă��邪�A�����d����M���N�����ƂȂ�ꍇ�́A�����c�̃}�C�i�X��������B</br>
        /// <br>UpdateNote : 2011/07/20 �{�z�� </br>
        /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���̑Ή�</br>
        /// <br>UpdateNote : 2011/07/21 �x�c </br>
        /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���Ή��̎擾���̏C��</br>
        /// <br>Update Note: 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
        //private int WriteStockBlanketProcProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteStockBlanketProcProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, bool lastRetry)
        // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StockWork wkStockWork = null;
            bool insflg = false;
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //�X�V�`�F�b�N����
                        //Select�R�}���h�̐���
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {

                            //���݂̃f�[�^���N���X�֊i�[
                            wkStockWork = CopyToStockWorkFromReader(ref myReader,1);

                            // double�^�̂܂܂Ōv�Z���s���Ɗۂߌ덷��������ꍇ(�� 0.37 + 0.31 = 0.67999999999999994)
                            // ������̂�decimal�^�ɃL���X�g���Čv�Z����
                            wkStockWork.SupplierStock = (double)((decimal)wkStockWork.SupplierStock + (decimal)stockWork.SupplierStock);
                            wkStockWork.AcpOdrCount = (double)((decimal)wkStockWork.AcpOdrCount + (decimal)stockWork.AcpOdrCount);
                            wkStockWork.SalesOrderCount = (double)((decimal)wkStockWork.SalesOrderCount + (decimal)stockWork.SalesOrderCount);
                            wkStockWork.MovingSupliStock = (double)((decimal)wkStockWork.MovingSupliStock + (decimal)stockWork.MovingSupliStock);
                            wkStockWork.ShipmentCnt = (double)((decimal)wkStockWork.ShipmentCnt + (decimal)stockWork.ShipmentCnt);
                            wkStockWork.ArrivalCnt = (double)((decimal)wkStockWork.ArrivalCnt + (decimal)stockWork.ArrivalCnt);

                            // --- UPD 2011/07/12 ---------->>>>>
                            // --- ADD m.suzuki 2010/10/13 ---------->>>>>
                            //  // �����c�����}�C�i�X�ɂȂ�ꍇ�̓[���ŕ␳����B
                            //  if ( wkStockWork.SalesOrderCount < 0 )
                            //  {
                            //    wkStockWork.SalesOrderCount = 0;
                            //  }
                            //  // --- ADD m.suzuki 2010/10/13 ----------<<<<<

                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //---�N�����v���Z�X�̎擾
                            //Assembly myAssembly = Assembly.GetEntryAssembly();
                            //string path1 = myAssembly.Location;
                            //string path2 = Path.GetFileName(path1);
                            object obje = (object)this;
                            FileHeader filehd2 = new FileHeader(obje);

                            string path2 = filehd2.UpdAssemblyId1;
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            
                            // �����d����M�ȊO�ŁA�����c�����}�C�i�X�ɂȂ�ꍇ�̓[���ŕ␳
                            // --- ADD 2011/07/20 ---------->>>>>
                            int tempIndex = path2.IndexOf(":");
                            if (tempIndex > 0)
                            {
                                path2 = path2.Substring(0, tempIndex);
                            }
                            // --- ADD 2011/07/20 ----------<<<<<
                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //if (path2 != "PMUOE01300U.exe")
                            if (path2 != "PMUOE01300U")
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            {
                                if (wkStockWork.SalesOrderCount < 0)
                                {
                                    wkStockWork.SalesOrderCount = 0;
                                }
                            }
                            // --- UPD 2011/07/12 ----------<<<<<

                            //�o�׉\���ݒ菈��
                            SetShipmentPosCnt(ref wkStockWork);

                            //������������������������������������������������������������������������������������
                            //�d���P���̍X�V
                            //������������������������������������������������������������������������������������
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            //�����f�[�^����̌Ăяo���̏ꍇ�ŒI�ԍX�V�敪�u0:����v�̏ꍇ�ɒI�Ԃ��X�V����
                            //if ((procMode == (int)ct_ProcMode.StockAdjust) && (_whUpdateDiv == 0))
                            //{
                            //    wkStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            //}

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                            //IFileHeader flhd = (IFileHeader)wkStockWork;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            //wkStockWork�̕ϓ�����(���ʓ�)�݂̂��Z�b�g���A�����ڂ͈����̓��e�ōX�V����
                            //stockWork.StockUnitPriceFl = wkStockWork.StockUnitPriceFl;
                            stockWork.SupplierStock = wkStockWork.SupplierStock;
                            stockWork.AcpOdrCount = wkStockWork.AcpOdrCount;
                            stockWork.SalesOrderCount = wkStockWork.SalesOrderCount;
                            stockWork.MovingSupliStock = wkStockWork.MovingSupliStock;
                            stockWork.ShipmentPosCnt = wkStockWork.ShipmentPosCnt;
                            stockWork.StockTotalPrice = wkStockWork.StockTotalPrice;
                            stockWork.ShipmentCnt = wkStockWork.ShipmentCnt;
                            stockWork.ArrivalCnt = wkStockWork.ArrivalCnt;
                            
                            //stockWork = wkStockWork;    //�p�����[�^����ւ�

                            insflg = false;
                        }
                        else
                        {
                            #region �݌Ƀf�[�^�V�K�쐬����
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
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
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeader���\�b�h��logicalDeleteCode���㏑�������邽��
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;
                            
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            #endregion

                            //�o�׉\���ݒ菈��
                            SetShipmentPosCnt(ref stockWork);
                            //������������������������������������������������������������������������������������
                            //�d���P���̍X�V
                            //������������������������������������������������������������������������������������
                            wkStockWork = null;
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            insflg = true;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START ���{ 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END ���{ 2015/01/28 -----<<<<<<	
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
                //status = base.WriteSQLErrorLog(ex);

                //�f�b�g���b�N�̏ꍇ�A�f�b�h���b�N�l��status�ɃZ�b�g�A��̃��g���C�����ɗ��p
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    status = DEAD_LOCK_VALUE;
                }
                //�f�b�h���b�N�ȊO�̏ꍇ�A���̂܂�
                else
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<
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

            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
            //stockWorkList = al;
            if (status != DEAD_LOCK_VALUE && !lastRetry)
            {
                stockWorkList = al;
            }
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �݌ɏ���_���폜���܂�
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int LogicalDelete(ref object stockWork)
        {
            return LogicalDeleteStock(ref stockWork, 0);
        }

        /// <summary>
        /// �_���폜�݌ɏ��𕜊����܂�
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌ɏ��𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int RevivalLogicalDelete(ref object stockWork)
        {
            return LogicalDeleteStock(ref stockWork, 1);
        }

        /// <summary>
        /// �݌ɏ��̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ��̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        private int LogicalDeleteStock(ref object stockWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(stockWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    //sqlTransaction.Commit(); // DEL ���� 2014/08/13
                //----- ADD START ���� 2014/08/13 ----->>>>>>
                {
                    sqlTransaction.Commit();
                    //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                    //synchExecuteMng.SyncReqExecute();
                }
                //----- ADD END ���� 2014/08/13 -----<<<<<<
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
                base.WriteErrorLog(ex, "StockDB.LogicalDeleteStock :" + procModestr);

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
        }

        /// <summary>
        /// �݌ɏ��̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ��̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int LogicalDeleteStockProc(ref ArrayList stockWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockProcProc(ref stockWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɏ��̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ��̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        private int LogicalDeleteStockProcProc(ref ArrayList stockWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //Select�R�}���h�̐���
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != stockWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
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
                            else if (logicalDelCd == 0) stockWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else stockWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START ���{ 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END ���{ 2015/01/28 -----<<<<<<	
                    }

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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockWorkList = al;

            return status;

        }
        
        #endregion

        #region [Delete]
        /// <summary>
        /// �݌ɏ��𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�݌ɏ��I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɏ��𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteStockProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    //sqlTransaction.Commit(); // DEL ���� 2014/08/13
                //----- ADD START ���� 2014/08/13 ----->>>>>>
                {
                    sqlTransaction.Commit();
                    //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                    //synchExecuteMng.SyncReqExecute();
                }
                //----- ADD END ���� 2014/08/13 -----<<<<<<
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        /// �݌ɏ��𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɏ��𕨗��폜���܂�(�O�������SqlConnection, SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>UpdateNote : 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        public int DeleteStockProc(ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
            //return DeleteStockProcProc(stockWorkList, ref sqlConnection, ref sqlTransaction);
            // ���g���C��
            int retryCnt = ZERO_VALUE;
            // ���O�o�̓N���X
            OutLogCommon outLogCommonObj = new OutLogCommon();
            // ���g���C�ݒ胏�[�N
            RetrySet retrySettingInfo = new RetrySet();
            // ���g���C�ݒ�擾�o�͕��i
            RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
            retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

            return this.DeleteStockProcReTry(stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<
        }

        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>> 
        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <param name="outLogCommonObj">���O�o�̓N���X</param>
        /// <param name="retrySettingInfo">���g���C�ݒ胏�[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        private int DeleteStockProcReTry(ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();

            // ���g���C��
            retryCnt++;

            // savepiont�ݒ�
            sqlTransaction.Save(SAVEPPIONT_D);

            // �݌ɏ��𕨗��폜����
            status = DeleteStockProcProc(stockWorkList, ref sqlConnection, ref sqlTransaction);

            //�f�b�h���b�N�̏ꍇ
            if (status == DEAD_LOCK_VALUE)
            {
                // ���O�o��
                outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG_D, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, null);
                // ���g���C�񐔂܂�
                if (retryCnt >= retrySettingInfo.RetryCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//����STATUS�l�𕜌�
                }
                else
                {
                    // �ݒ肵��savepoint�����[���o�b�N
                    sqlTransaction.Rollback(SAVEPPIONT_D);
                    // ���g���C�Ԋu��sleep
                    Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                    // ���g���C�������s��
                    status = this.DeleteStockProcReTry(stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
                }
            }

            return status;
        }
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<< 

        /// <summary>
        /// �݌ɏ��𕨗��폜���܂�(�O�������SqlConnection,SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockWorkList">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɏ��𕨗��폜���܂�(�O�������SqlConnection, SqlTranaction���g�p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>UpdateNote : 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        private int DeleteStockProcProc(ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";

                for (int i = 0; i < stockWorkList.Count; i++)
                {
                    StockWork stockWork = stockWorkList[i] as StockWork;

                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "FROM STOCKRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != stockWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "DELETE" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                    //----- ADD START ���{ 2015/01/28 ----->>>>>>
                    sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                    sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                    //----- ADD END ���{ 2015/01/28 -----<<<<<<	
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 ----->>>>>
                //status = base.WriteSQLErrorLog(ex);

                //�f�b�g���b�N�̏ꍇ�A�f�b�h���b�N�l��status�ɃZ�b�g�A��̃��g���C�����ɗ��p
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    status = DEAD_LOCK_VALUE;
                }
                //�f�b�h���b�N�ȊO�̏ꍇ�A���̂܂�
                else
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 -----<<<<<
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
        /// <param name="stockWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockWork stockWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "STOCK.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (string.IsNullOrEmpty(stockWork.SectionCode) == false)
            {
                retstring += " AND STOCK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
            }

            //�q�ɃR�[�h
            if (string.IsNullOrEmpty(stockWork.WarehouseCode) == false)
            {
                retstring += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
            }

            //���i�ԍ�
            if (string.IsNullOrEmpty(stockWork.GoodsNo) == false)
            {
                retstring += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
            }

            //���i���[�J�[�R�[�h
            if (stockWork.GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
            }

            return retstring;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �������������񐶐��{�����l�ݒ� �i�����񓚏�����p�j
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="stockWorkList">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        private string MakeWhereString(ref SqlCommand sqlCommand, List<StockWork> stockWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "STOCK.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWorkList[0].EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (string.IsNullOrEmpty(stockWorkList[0].SectionCode) == false)
            {
                retstring += " AND STOCK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWorkList[0].SectionCode);
            }

            // ���i�ԍ��E���i���[�J�[�R�[�h�Z�b�g
            if (stockWorkList != null && stockWorkList.Count != 0)
            {
                bool searchFlag = false;
                for(int i = 0; i < stockWorkList.Count; i++)
                {
                    StockWork wk = stockWorkList[i];

                    if (!string.IsNullOrEmpty(wk.GoodsNo) && wk.GoodsMakerCd != 0)
                    {
                        if (i == 0)
                        {
                            retstring += " AND (  ";
                        }
                        else
                        {
                            retstring += " OR ";
                        }
                        searchFlag = true;
                        retstring += " ( STOCK.GOODSNORF='" + wk.GoodsNo + "'";
                        retstring += " AND STOCK.GOODSMAKERCDRF=" + wk.GoodsMakerCd.ToString().Trim() + " )" + Environment.NewLine;
                    }
                }
                if (searchFlag) retstring += " )  " + Environment.NewLine;
            }

            return retstring;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">0:�ʃ}�X�^����̎擾���ڂ��Z�b�g</param>
        /// <returns>StockWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            StockWork wkStockWork = new StockWork();

            #region �N���X�֊i�[
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            wkStockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            
            if (mode == 0)
            {
                wkStockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                wkStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }
            #endregion

            return wkStockWork;
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
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockWork[] StockWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is StockWork)
                    {
                        StockWork wkStockWork = paraobj as StockWork;
                        if (wkStockWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockWorkArray = (StockWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockWork[]));
                        }
                        catch (Exception) { }
                        if (StockWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockWork wkStockWork = (StockWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockWork));
                                if (wkStockWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockWork);
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
        /// <br>Date       : 2007.01.18</br>
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

        #region �݌Ƀf�[�^���݌Ɏ󕥗����f�[�^
        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ��X�g</param>
        /// <param name="stockAcPayHistWorkList">�݌Ɏ󕥗������X�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.02</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        private void SetstockAcPayHist(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�X�V��̍݌Ƀf�[�^�̐��ʂ��݌Ɏ󕥗����f�[�^�֔��f������

            //�݌Ɏ󕥗����f�[�^�����[�v
            for (int i = 0; i < stockAcPayHistWorkList.Count; i++)
            {
                StockAcPayHistWork wkStockAcPayHistWork = stockAcPayHistWorkList[i] as StockAcPayHistWork;
                StockWork wkStockWork = new StockWork();
                wkStockWork.EnterpriseCode = wkStockAcPayHistWork.EnterpriseCode;
                wkStockWork.GoodsMakerCd = wkStockAcPayHistWork.GoodsMakerCd;
                wkStockWork.GoodsNo = wkStockAcPayHistWork.GoodsNo;
                
                if (wkStockAcPayHistWork.AcPaySlipCd == (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment)
                {
                    //wkStockWork.SectionCode = wkStockAcPayHistWork.BfSectionCode;
                    wkStockWork.WarehouseCode = wkStockAcPayHistWork.BfEnterWarehCode;
                }
                else if (wkStockAcPayHistWork.AcPaySlipCd == (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival)
                {
                    //wkStockWork.SectionCode = wkStockAcPayHistWork.AfSectionCode;
                    wkStockWork.WarehouseCode = wkStockAcPayHistWork.AfEnterWarehCode;
                }
                else
                {
                    //wkStockWork.SectionCode = wkStockAcPayHistWork.SectionCode;
                    wkStockWork.WarehouseCode = wkStockAcPayHistWork.WarehouseCode;
                }
          

                int status = ReadProc(ref wkStockWork, 0, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkStockAcPayHistWork.SupplierStock = wkStockWork.SupplierStock;
                    wkStockAcPayHistWork.AcpOdrCount = wkStockWork.AcpOdrCount;
                    wkStockAcPayHistWork.SalesOrderCount = wkStockWork.SalesOrderCount;
                    wkStockAcPayHistWork.MovingSupliStock = wkStockWork.MovingSupliStock;
                    wkStockAcPayHistWork.NonAddUpShipmCnt = wkStockWork.ShipmentCnt;
                    wkStockAcPayHistWork.NonAddUpArrGdsCnt = wkStockWork.ArrivalCnt;
                    wkStockAcPayHistWork.ShipmentPosCnt = wkStockWork.ShipmentPosCnt;
                    
                    // double�^�ɂ��v�Z�ł͊ۂߌ덷���������Ă��܂��ׁAdecimal�^�ɃL���X�g���Čv�Z����
                    decimal SupplierStock = (decimal)wkStockWork.SupplierStock;
                    decimal ArrivalCnt = (decimal)wkStockWork.ArrivalCnt;
                    decimal ShipmentCnt = (decimal)wkStockWork.ShipmentCnt;
                    decimal MovingSupliStock = (decimal)wkStockWork.MovingSupliStock;

                    wkStockAcPayHistWork.PresentStockCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - MovingSupliStock);
                }
            }
        }
        #endregion

        #region IOWrite�e�X�g�p
        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �e�X�g�p��IOWrite�𒼐ڌďo���݌ɏ���o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int Write(ref object stockWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = "";

            string origin = "";
            CustomSerializeArrayList paraList = stockWork as CustomSerializeArrayList;
            int position = 0;
            string param = "";
            object freeParam = null;
            string retItemInfo = "";
            SqlEncryptInfo sqlEncryptInfo = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                CustomSerializeArrayList cList = null;
                //write���s
                status = Write(origin, ref cList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    //sqlTransaction.Commit(); // DEL ���� 2014/08/13
                //----- ADD START ���� 2014/08/13 ----->>>>>>
                {
                    sqlTransaction.Commit();
                    //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                    //synchExecuteMng.SyncReqExecute();
                }
                //----- ADD END ���� 2014/08/13 -----<<<<<<
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                stockWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Write(ref object stockWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        /// �݌ɔr���p�����[�^�쐬����
        /// </summary>
        /// <param name="stocklist"></param>
        /// <param name="exparaList"></param>
        /// <br>Note       : �݌ɔr���p�̃p�����[�^���쐬���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        private void SetExpara(ArrayList stocklist, out List<StockExclsvDataParam> exparaList)
        {
            exparaList = new List<StockExclsvDataParam>();

            StockExclsvDataParam expara = null;
            for (int i = 0; i < stocklist.Count; i++)
            {
                expara = new StockExclsvDataParam();
                expara.EnterpriseCode = ((StockWork)stocklist[i]).EnterpriseCode;
                expara.WarehouseCode = ((StockWork)stocklist[i]).WarehouseCode;
                expara.GoodsMakerCd = ((StockWork)stocklist[i]).GoodsMakerCd;
                expara.GoodsNo = ((StockWork)stocklist[i]).GoodsNo;
                exparaList.Add(expara);
            }
        }
        #endregion

        #region IFunctionCallTargetWrite �����o
        /// <summary>
        /// �݌ɍ폜����(IOWirte)
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍폜�������s���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;
            StockMngTtlStWork stockMngTtlStWork = null;     //�݌ɊǗ��S�̐ݒ�

            //�X�V�ΏۃN���X�������ꍇ�͖�����
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //���R�l�N�V�������p�����[�^�`�F�b�N
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                return status;
            }
            //���X�V�I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }

            //���X�g����K�v�ȏ����擾
            for (int i = 0; i < paraList.Count; i++)
            {
                ArrayList wkal = paraList[i] as ArrayList;
                if (wkal != null)
                {
                    if (wkal.Count > 0)
                    {
                        //�݌Ƀ}�X�^�Ń��X�g��NULL�̏ꍇ
                        if (wkal[0] is StockWork && stockWorkList == null)
                        {
                            stockWorkList = wkal;
                            listPos_StockWork = i;//�i�[����Ă����ʒu��ޔ�
                        }
                        //�݌Ɏ󕥗����}�X�^�̏ꍇ
                        if (wkal[0] is StockAcPayHistWork)
                        {
                            stockAcPayHistWorkList = wkal;
                            listPos_StockAcPayHistWork = i;//�i�[����Ă����ʒu��ޔ�
                        }
                    }
                }
            }

            //�݌ɊǗ��S�̐ݒ�擾
            if (stockWorkList != null)
            {
                status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
            }

            //�݌Ƀ}�X�^�X�V
            if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = StockAddCountUPProc((int)ct_ProcMode.StockSlip, (int)ct_WriteMode.delete, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�X�V�Ɏ��s���܂����B";
            }

            //�X�V��̍݌Ƀf�[�^���݌Ɏ󕥗����f�[�^�֔��f
            if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

            //�݌Ɏ󕥗����}�X�^�X�V
            if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                
                //status = _stockAcPayHistDB.LogicalDeleteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                //�`�[�폜���ɂ��󕥗����͒ǉ�����悤�ɏC��
                status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�X�V�Ɏ��s���܂����B";
            }

            //�X�V���ʂ�߂�
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockWorkList != null)
                    paraList[listPos_StockWork] = stockWorkList;
                if (stockAcPayHistWorkList != null)
                    paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
            }

            return status;
        }

        /// <summary>
        /// �݌ɍX�V�O����(IOWrite)
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�O�������s���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
        
        /// <summary>
        /// �݌ɍ폜�O����(IOWrite)���ݖ��g�p
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="list">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍폜�O�������s���܂��B���ݖ��g�p</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �݌ɍ폜����(IOWrite)�݌Ɉړ��p
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B(�݌Ɉړ��p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int WriteForStockMove(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return WriteProc((int)ct_ProcMode.StockMove, origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        // --- ADD K2020/03/25 ���O�@�f�b�h���b�N�̑Ή� ---------->>>>>
        /// <summary>
        /// �݌ɍ폜�����ƍ݌Ƀ}�X�^�̔������̍X�V(IOWrite)�݌Ɉړ��p
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="stockWorkList">�݌Ƀ}�X�^�̔������̍X�VList</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B(�݌Ɉړ��p)</br>
        /// <br>Programer  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        /// </remarks>
        public int WriteForStockMoveHandleDeadLock(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, ref ArrayList stockWorkList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return WriteForStockMoveHandleDeadLock((int)ct_ProcMode.StockMove, origin, ref originList, ref paraList, ref stockWorkList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// �݌ɍX�V����(IOWrite)(�݌Ɉړ��p)
        /// </summary>
        /// <param name="procMode">�����敪</param>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="stockOrderCountWorkList">�݌Ƀ}�X�^�̔������̍X�VList</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B</br>
        /// <br>Programer  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        /// </remarks>
        private int WriteForStockMoveHandleDeadLock(int procMode, string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, ref ArrayList stockOrderCountWorkList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;
            StockMngTtlStWork stockMngTtlStWork = null;     //�݌ɊǗ��S�̐ݒ�

            //�X�V�ΏۃN���X�������ꍇ�͖�����
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //���R�l�N�V�������p�����[�^�`�F�b�N
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                return status;
            }
            //���X�V�I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }
            string resNm = "";

            try
            {

                //���X�g����K�v�ȏ����擾
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ƀ}�X�^�Ń��X�g��NULL�̏ꍇ
                            if (wkal[0] is StockWork && stockWorkList == null)
                            {
                                stockWorkList = wkal;
                                listPos_StockWork = i;//�i�[����Ă����ʒu��ޔ�
                            }
                            //�݌Ɏ󕥗����}�X�^�̏ꍇ
                            if (wkal[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistWorkList = wkal;
                                listPos_StockAcPayHistWork = i;//�i�[����Ă����ʒu��ޔ�
                            }
                        }
                    }
                }
                string enterpriseCode = string.Empty;
                if (stockWorkList != null)
                {
                    enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                }
                else if (stockAcPayHistWorkList != null)
                {
                    enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
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
                            base.WriteErrorLog("StockDB.WriteForStockMoveHandleDeadLock:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveHandleDeadLock:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                    }
                }
                // ���b�N���\�[�X��
                resNm = this.GetResourceName(enterpriseCode);
                if (resNm != "")
                {
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
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_Lock:{0}", retMsg), status);
                        return status;
                    }
                }

                //�݌ɊǗ��S�̐ݒ�擾
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "�v���O�����G���[�B�݌ɊǗ��S�̐ݒ���擾�Ɏ��s���܂����B";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_GetStockMngTtlStWork:{0}", retMsg), status);
                    }
                }

                //�݌Ƀ}�X�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProc(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�X�V�Ɏ��s���܂����B";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_StockAddCountUPProc1:{0}", retMsg), status);
                    }
                }

                //�X�V��̍݌Ƀf�[�^���݌Ɏ󕥗����f�[�^�֔��f
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //�݌Ɏ󕥗����f�[�^�X�V
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //����A�d���A�����̎󕥍X�V
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�X�V�Ɏ��s���܂����B";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_WriteStockAcPayHistProc:{0}", retMsg), status);
                    }
                }

                //�X�V���ʂ�߂�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockWorkList != null)
                        paraList[listPos_StockWork] = stockWorkList;
                    if (stockAcPayHistWorkList != null)
                        paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
                }

                //�݌Ƀ}�X�^�������̍X�V
                if (stockOrderCountWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProc(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockOrderCountWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�������̍X�V�Ɏ��s���܂����B";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_StockAddCountUPProc2:{0}", retMsg), status);
                    }
                }
            }
            finally
            {
                if (resNm != "")
                {
                    //�`�o�A�����b�N
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                }
            }
            return status;
        }
        // --- ADD K2020/03/25 ���O�@�f�b�h���b�N�̑Ή� ----------<<<<<


        /// <summary>
        /// �݌ɍ폜����(IOWrite)�݌Ɉړ��p
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <param name="whUpdateDiv">�I���X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B(�݌Ɉړ��p)</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int WriteForStockAdjust(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, int whUpdateDiv)
        {
            _whUpdateDiv = whUpdateDiv;
            return WriteProc((int)ct_ProcMode.StockAdjust, origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// �݌ɍX�V����(IOWrite)
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return WriteProc((int)ct_ProcMode.StockSlip, origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// �݌ɍX�V����(IOWrite)
        /// </summary>
        /// <param name="procMode">�����敪</param>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programme  : ���O</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteProc(int procMode, string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;
            StockMngTtlStWork stockMngTtlStWork = null;     //�݌ɊǗ��S�̐ݒ�
            
            //�X�V�ΏۃN���X�������ꍇ�͖�����
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //���R�l�N�V�������p�����[�^�`�F�b�N
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                return status;
            }
            //���X�V�I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }
            
            string resNm = "";
            
            try
            {
            
                //���X�g����K�v�ȏ����擾
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ƀ}�X�^�Ń��X�g��NULL�̏ꍇ
                            if (wkal[0] is StockWork && stockWorkList == null)
                            {
                                stockWorkList = wkal;
                                listPos_StockWork = i;//�i�[����Ă����ʒu��ޔ�
                            }
                            //�݌Ɏ󕥗����}�X�^�̏ꍇ
                            if (wkal[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistWorkList = wkal;
                                listPos_StockAcPayHistWork = i;//�i�[����Ă����ʒu��ޔ�
                            }
                        }
                    }
                }

                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.WriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
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
                                base.WriteErrorLog("StockDB.WriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                        }
                    }
                    // ���b�N���\�[�X��
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
                
                if (resNm != "")
                {   
                    //�`�o���b�N
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
                        base.WriteErrorLog(string.Format("StockDB.WriteProc_Lock:{0}", retMsg), status);  // ADD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                        return status;
                    }

                }
                
                //�݌ɊǗ��S�̐ݒ�擾
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌ɊǗ��S�̐ݒ���擾�Ɏ��s���܂����B";
                }

                //�݌Ƀ}�X�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProc(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�X�V�Ɏ��s���܂����B";
                }

                //�X�V��̍݌Ƀf�[�^���݌Ɏ󕥗����f�[�^�֔��f
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //�݌Ɏ󕥗����f�[�^�X�V
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //if ((procMode == (int)ct_ProcMode.StockMove))
                    //{
                    //    //�ړ��̎󕥍X�V
                    //    status = _stockAcPayHistDB.WriteStockMoveAcPayHistProc(ref stockAcPayHistWorkList, acPayHistDateTime, ref sqlConnection, ref sqlTransaction);
                    //}
                    //else
                    //{
                    //    //����A�d���A�����̎󕥍X�V
                        status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    //}
                    
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�X�V�Ɏ��s���܂����B";
                }

                //�X�V���ʂ�߂�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockWorkList != null)
                        paraList[listPos_StockWork] = stockWorkList;
                    if (stockAcPayHistWorkList != null)
                        paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                    ////�`�o�A�����b�N
                    //Release(resNm,sqlConnection,sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                    }
                    else
                    {
                        //���r�����b�N����������
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteProc_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                }
            }
            return status;
        }
        #endregion

        #region �݌ɊǗ��S�̐ݒ�擾����
        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�擾����
        /// </summary>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <param name="stockMngTtlStWork">�݌ɑS�̐ݒ�}�X�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�̎擾�������s���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        private int GetStockMngTtlStWork(ArrayList stockList, out StockMngTtlStWork stockMngTtlStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockMngTtlStWork = new StockMngTtlStWork();
            if (stockList != null && stockList.Count > 0)
            {
                stockMngTtlStWork.EnterpriseCode = ((StockWork)stockList[0]).EnterpriseCode;   //��ƃR�[�h
            }
            else
            {
                return status;
            }
 
            stockMngTtlStWork.SectionCode = "00";                 //�S�Ћ��ʐݒ��ǂݍ���
 
            //�݌ɊǗ��S�̐ݒ胊�[�h�Ăяo��
            status = _stockMngTtlStDB.ReadProc(ref stockMngTtlStWork, 0, ref sqlConnection, ref sqlTransaction);

            return status;
        }
        #endregion

        #region IFunctionCallTargetRead �����o
        
        /// <summary>
        /// �݌Ƀf�[�^�Ǎ�����
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="paraList">�Ăяo����List</param>
        /// <param name="retList">�߂�lList</param>
        /// <param name="position">�ΏۃI�u�W�F�N�g�ʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns></returns>
        /// <br>Note       : �݌Ƀf�[�^�̓Ǎ��������s���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int Read(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList StockList = null;
            ArrayList StockretList = null;

            //���X�g����K�v�ȏ����擾
            for (int i = 0; i < paraList.Count; i++)
            {
                ArrayList wkal = paraList[i] as ArrayList;
                if (wkal != null)
                {
                    if (wkal.Count > 0)
                    {
                        //�݌Ƀ}�X�^�̏ꍇ
                        if (wkal[0] is StockWork)
                        {
                            StockList = wkal;
                        }
                    }
                }
            }

            if (StockList != null)
            {
                status = ReadStockByStockCommonPara(StockList, out StockretList, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && StockretList != null)
                    retList.Add(StockretList);
            }

            return status;
        }
        

        /// <summary>
        /// �݌Ƀf�[�^�擾����
        /// </summary>
        /// <param name="paraList">�������X�g</param>
        /// <param name="retList">���ʃ��X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�擾�������s���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.09.25</br>
        public int ReadStockByStockCommonPara(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadStockByStockCommonParaProc(paraList, out retList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ƀf�[�^�擾����
        /// </summary>
        /// <param name="paraList">�������X�g</param>
        /// <param name="retList">���ʃ��X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�擾�������s���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.09.25</br>
        public int ReadStockByStockCommonPara(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadStockByStockCommonParaProc(paraList, out retList, ref sqlConnection, ref sqlTransaction);
        }
            
        /// <summary>
        /// �݌Ƀf�[�^�擾����
        /// </summary>
        /// <param name="paraList">�������X�g</param>
        /// <param name="retList">���ʃ��X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�擾�������s���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.09.25</br>
        public int ReadStockByStockCommonParaProc(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadStockByStockCommonParaProcProc(paraList, out retList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌Ƀf�[�^�擾����
        /// </summary>
        /// <param name="paraList">�������X�g</param>
        /// <param name="retList">���ʃ��X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�擾�������s���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2007.09.25</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30029 �݌Ƀ}�X�^�ꗗ��� ����������ł̈���s�</br>
        private int ReadStockByStockCommonParaProcProc(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            retList = new ArrayList();
            StockWork stockWork = null;
            string selectTxt = "";
            try
            {
                if (paraList != null)
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        StockWork stockList = paraList[i] as StockWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                        //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "ON " + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "ON " + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                        if (sqlTransaction != null)
                            sqlCommand.Transaction = sqlTransaction;

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockList.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockList.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockList.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockList.GoodsNo);

                        if (myReader != null)
                            if (myReader.IsClosed == false) myReader.Close();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            stockWork = CopyToStockWorkFromReader(ref myReader,0);
                            retList.Add(stockWork);
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

            return status;
        }

        #endregion

        // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
        /// <summary>
        /// �݌ɍX�V����(�I���ߕs���X�V�p)
        /// </summary>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="stockMngTtlStWork">stockMngTtlStWork</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <param name="whUpdateDiv">�I���X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        public int WriteFromInventory(string origin, StockMngTtlStWork stockMngTtlStWork, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, int whUpdateDiv)
        {
            _whUpdateDiv = whUpdateDiv;
            return WriteFromInventoryProc((int)ct_ProcMode.StockAdjust, origin, stockMngTtlStWork, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// �݌ɍX�V����(�I���ߕs���X�V�p)
        /// </summary>
        /// <param name="procMode">�����敪</param>
        /// <param name="origin">�Ăяo����</param>
        /// <param name="stockMngTtlStWork">stockMngTtlStWork</param>
        /// <param name="originList">�Ăяo����List</param>
        /// <param name="paraList">�����폜List</param>
        /// <param name="position">�X�V�Ώ۵�޼ު�Ĉʒu</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="freeParam">���R�p�����[�^</param>
        /// <param name="retMsg">ү����</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀf�[�^�̍X�V�������s���܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        public int WriteFromInventoryProc(int procMode, string origin, StockMngTtlStWork stockMngTtlStWork, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;

            //�X�V�ΏۃN���X�������ꍇ�͖�����
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //���R�l�N�V�������p�����[�^�`�F�b�N
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�f�[�^�x�[�X�ڑ����p�����[�^�����w��ł�");
                return status;
            }
            //���X�V�I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "�v���O�����G���[�B�X�V�Ώۃp�����[�^�����w��ł�");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }

            try
            {

                //���X�g����K�v�ȏ����擾
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //�݌Ƀ}�X�^�Ń��X�g��NULL�̏ꍇ
                            if (wkal[0] is StockWork && stockWorkList == null)
                            {
                                stockWorkList = wkal;
                                listPos_StockWork = i;//�i�[����Ă����ʒu��ޔ�
                            }
                            //�݌Ɏ󕥗����}�X�^�̏ꍇ
                            if (wkal[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistWorkList = wkal;
                                listPos_StockAcPayHistWork = i;//�i�[����Ă����ʒu��ޔ�
                            }
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //�݌ɊǗ��S�̐ݒ�擾
                if (stockWorkList != null && stockMngTtlStWork == null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌ɊǗ��S�̐ݒ���擾�Ɏ��s���܂����B";
                }

                //�݌Ƀ}�X�^�X�V
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProcFromInvent(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ƀ}�X�^�X�V�Ɏ��s���܂����B";
                }

                //�X�V��̍݌Ƀf�[�^���݌Ɏ󕥗����f�[�^�֔��f
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //�݌Ɏ󕥗����f�[�^�X�V
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "�v���O�����G���[�B�݌Ɏ󕥗����}�X�^�X�V�Ɏ��s���܂����B";
                }

                //�X�V���ʂ�߂�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockWorkList != null)
                        paraList[listPos_StockWork] = stockWorkList;
                    if (stockAcPayHistWorkList != null)
                        paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
                }
            }
            finally
            {

            }
            return status;
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        public int StockAddCountUPProcFromInvent(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return StockAddCountUPProcProcFromInvent(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="procMode">�������[�h</param>
        /// <param name="writeMode">�X�V���[�h</param>
        /// <param name="stockMngTtlStWork">�݌ɊǗ��S�̐ݒ�</param>
        /// <param name="stockWorkList">StockWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂��B�܂��݌ɂ����݂���ꍇ���ʍ��ڂɂ��Ă͉��Z���܂��B(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �݌Ƀ}�X�^���_���폜����Ă���ꍇ�̕ύX</br>
        /// <br>UpdateNote : 2011/07/12 �{�z�� </br>
        /// <br>             �A��No.1027 �����c���}�C�i�X�ɂȂ�ꍇ�́A�Œ�łO���Z�b�g���Ă��邪�A�����d����M���N�����ƂȂ�ꍇ�́A�����c�̃}�C�i�X��������B</br>
        /// <br>UpdateNote : 2011/07/20 �{�z�� </br>
        /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���̑Ή�</br>
        /// <br>UpdateNote : 2011/07/21 �x�c </br>
        /// <br>             Redmine#23074 �擪����u�F�v�܂ł̕����񂪁uPMUOE01300U�v���ۂ��̔���Ή��̎擾���̏C��</br>
        private int StockAddCountUPProcProcFromInvent(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StockWork wkStockWork = null;
            bool insflg = false;
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //�X�V�`�F�b�N����
                        //Select�R�}���h�̐���
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //���݂̃f�[�^���N���X�֊i�[
                            wkStockWork = CopyToStockWorkFromReader(ref myReader, 1);

                            //������������������������������������������������������������������������������������
                            //���ʂ̍X�V
                            //���ʂ̑�������(�n���ꂽ�p�����[�^�̐��ʂ��l������Ă�����̂Ƃ��ĒP���ɉ��Z���܂��B
                            //���ۂ͒ʏ�Ȃ�v���X�A�ԓ`��������ȂǍ폜�̏ꍇ�̓}�C�i�X�ɂȂ�܂��B)
                            //������������������������������������������������������������������������������������

                            // double�^�̂܂܂Ōv�Z���s���Ɗۂߌ덷��������ꍇ(�� 0.37 + 0.31 = 0.67999999999999994)
                            // ������̂�decimal�^�ɃL���X�g���Čv�Z����
                            wkStockWork.SupplierStock = (double)((decimal)wkStockWork.SupplierStock + (decimal)stockWork.SupplierStock);
                            wkStockWork.AcpOdrCount = (double)((decimal)wkStockWork.AcpOdrCount + (decimal)stockWork.AcpOdrCount);
                            wkStockWork.SalesOrderCount = (double)((decimal)wkStockWork.SalesOrderCount + (decimal)stockWork.SalesOrderCount);
                            wkStockWork.MovingSupliStock = (double)((decimal)wkStockWork.MovingSupliStock + (decimal)stockWork.MovingSupliStock);
                            wkStockWork.ShipmentCnt = (double)((decimal)wkStockWork.ShipmentCnt + (decimal)stockWork.ShipmentCnt);
                            wkStockWork.ArrivalCnt = (double)((decimal)wkStockWork.ArrivalCnt + (decimal)stockWork.ArrivalCnt);

                            // --- UPD 2011/07/12 ---------->>>>>
                            // --- ADD m.suzuki 2010/10/13 ---------->>>>>
                            //  // �����c�����}�C�i�X�ɂȂ�ꍇ�̓[���ŕ␳����B
                            //  if ( wkStockWork.SalesOrderCount < 0 )
                            //  {
                            //    wkStockWork.SalesOrderCount = 0;
                            //  }
                            //  // --- ADD m.suzuki 2010/10/13 ----------<<<<<

                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //---�N�����v���Z�X�̎擾
                            //Assembly myAssembly = Assembly.GetEntryAssembly();
                            //string path1 = myAssembly.Location;
                            //string path2 = Path.GetFileName(path1);
                            object obje = (object)this;
                            FileHeader filehd2 = new FileHeader(obje);

                            string path2 = filehd2.UpdAssemblyId1;
                            // --- UPD 2011/07/21 ------------------<<<<<<

                            // �����d����M�ȊO�ŁA�����c�����}�C�i�X�ɂȂ�ꍇ�̓[���ŕ␳
                            // --- ADD 2011/07/20 ---------->>>>>
                            int tempIndex = path2.IndexOf(":");
                            if (tempIndex > 0)
                            {
                                path2 = path2.Substring(0, tempIndex);
                            }
                            // --- ADD 2011/07/20 ----------<<<<<

                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //if (path2 != "PMUOE01300U.exe")
                            if (path2 != "PMUOE01300U")
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            {
                                if (wkStockWork.SalesOrderCount < 0)
                                {
                                    wkStockWork.SalesOrderCount = 0;
                                }
                            }
                            // --- UPD 2011/07/12 ----------<<<<<
                            //�V�����ŏI������̕����ŐV�̓��t�̏ꍇ�ŏI��������X�V
                            if (wkStockWork.LastSalesDate <= stockWork.LastSalesDate)
                                wkStockWork.LastSalesDate = stockWork.LastSalesDate;    //�ŏI�����

                            //�V�����ŏI�I���X�V���̕����ŐV�̓��t�̏ꍇ�ŏI�I���X�V�����X�V
                            if (wkStockWork.LastInventoryUpdate <= stockWork.LastInventoryUpdate)
                                wkStockWork.LastInventoryUpdate = stockWork.LastInventoryUpdate;    //�ŏI�I���X�V��

                            // 2009/06/26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //�V�����ŏI�d�����̕����ŐV�̓��t�̏ꍇ�ŏI�d�������X�V
                            if (wkStockWork.LastStockDate <= stockWork.LastStockDate)
                                wkStockWork.LastStockDate = stockWork.LastStockDate;    //�ŏI�d����
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //�o�׉\���ݒ菈��
                            SetShipmentPosCntFromInvent(ref wkStockWork, stockMngTtlStWork);

                            //������������������������������������������������������������������������������������
                            //�d���P���̍X�V
                            //������������������������������������������������������������������������������������
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            //�����f�[�^����̌Ăяo���̏ꍇ�ŒI�ԍX�V�敪�u0:����v�̏ꍇ�ɒI�Ԃ��X�V����
                            if ((procMode == (int)ct_ProcMode.StockAdjust) && (_whUpdateDiv == 0))
                            {
                                wkStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wkStockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            stockWork = wkStockWork;    //�p�����[�^����ւ�

                            // --- ADD 2009/12/03 ---------->>>>>
                            // �݌Ƀ}�X�^���_���폜����Ă���ꍇ
                            if (stockWork.LogicalDeleteCode == 1)
                            {
                                stockWork.LogicalDeleteCode = 0;
                            }
                            // --- ADD 2009/12/03 ----------<<<<<

                            insflg = false;
                        }
                        else
                        {
                            #region �݌Ƀf�[�^�V�K�쐬����
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
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
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeader���\�b�h��logicalDeleteCode���㏑�������邽��
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            #endregion

                            // --- ADD 2009/12/03 ---------->>>>>
                            // �݌Ƀ}�X�^�����o�^��
                            stockWork.StockUnitPriceFl = 0;
                            // --- ADD 2009/12/03 ----------<<<<<

                            //�o�׉\���ݒ菈��
                            SetShipmentPosCntFromInvent(ref stockWork, stockMngTtlStWork);
                            //������������������������������������������������������������������������������������
                            //�d���P���̍X�V
                            //������������������������������������������������������������������������������������
                            wkStockWork = null;
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            insflg = true;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            // 2009/06/26 MANTIS 13242 >>>>>>>>>>>>>>>>>>>>>>>>>>
                            //paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDateTime);
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START ���{ 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END ���{ 2015/01/28 -----<<<<<<	
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

            stockWorkList = al;

            return status;
        }

        /// <summary>
        /// �o�׉\���ݒ菈��
        /// </summary>
        /// <param name="stockWork">�݌Ƀf�[�^</param>
        /// <br>Note       : �o�׉\���ݒ菈��</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2011/08/29 wangf �A��1016�̑Ή�</br>
        private void SetShipmentPosCntFromInvent(ref StockWork stockWork, StockMngTtlStWork stockMngTtlStWork)
        {
            if (stockMngTtlStWork==null)
            {
                // �݌ɊǗ��S�̐ݒ�́u���݌ɕ\���敪�v�ɂ��A�󒍐��͎Z�o�����ǉ��̔��f
                StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
                stockMngTtlStWork = new StockMngTtlStWork();
                stockMngTtlStWork.EnterpriseCode = stockWork.EnterpriseCode;
                stockMngTtlStWork.SectionCode = "00";
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);
                // �݌ɊǗ��S�̐ݒ�ǂݍ���
                int status = stockMngTtlStDB.Read(ref parabyte, 0);
                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                }
            }

            //����������������������������������������������������������������������������������������������������
            //�o�׉\���̌v�Z��
            //�o�׉\�����d���݌ɐ��{���א��i���v��j�[ �o�א��i���v��j�[ �󒍐� �[ �ړ����d���݌ɐ�
            //����������������������������������������������������������������������������������������������������

            // double�^�ɂ��v�Z�ł͊ۂߌ덷���������Ă��܂��ׁAdecimal�^�ɃL���X�g���Čv�Z����
            decimal SupplierStock = (decimal)stockWork.SupplierStock;
            decimal ArrivalCnt = (decimal)stockWork.ArrivalCnt;
            decimal ShipmentCnt = (decimal)stockWork.ShipmentCnt;
            decimal AcpOdrCount = (decimal)stockWork.AcpOdrCount;
            decimal MovingSupliStock = (decimal)stockWork.MovingSupliStock;

            if (stockMngTtlStWork.PreStckCntDspDiv == 0)
            {
                // �󒍕��܂�
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - AcpOdrCount - MovingSupliStock);
            }
            else
            {
                // �󒍕��܂܂Ȃ�
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - MovingSupliStock);
            }
        }

        // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<
    }

    #region �݌ɔ�r�N���X
    /// <summary>
    /// �݌ɃN���X��r�N���X
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015�@�����@�F��</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    /// <br></br>
    /// <br>Update Note: 2007.09.25 ���� DC.NS�p�ɏC��</br>
    public class StockWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockWork cx = (StockWork)x;
            StockWork cy = (StockWork)y;

            //���_�R�[�h
            //result = cx.SectionCode.CompareTo(cy.SectionCode);
            //�q�ɃR�[�h
            result = cx.WarehouseCode.CompareTo(cy.WarehouseCode);
            //���[�J�[�R�[�h
            if (result == 0)
                result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            //���i�R�[�h
            if (result == 0)
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);

            //���ʂ�Ԃ�
            return result;
        }
    }
    #endregion

}
