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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I���\��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���\���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.08</br>
    /// <br></br>
    /// <br>Update Note: �폜�ςݑq�ɂ͒��o�ΏۊO�ɕύX</br>
    /// <br>Date       : 23012 �����@�[���N</br>
    /// <br>           : 2008.12.02</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2012/02/24 30517 �Ė� �x��</br>
    /// <br>             �s��Ή��F�Q���R�[�h�ȍ~������ɋ��z���\�������l�ɏC���B</br>
    /// <br>Update Note: 2012/03/26 wangf </br>
    /// <br>             redmine#29109�̑Ή�</br>
    /// <br>Update Note: 2013/10/14 ������</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
    /// <br>           : Redmine#40178 �@�I���\���̌����v�Z�̏�Q����(��2115)</br>
    /// <br>Update Note: 2014/03/05 �c����</br>
    /// <br>           : Redmine#42247 ����@�\�̒ǉ�</br>
    /// <br>Update Note: 2014/03/10 ������</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
    /// <br>           : Redmine#40178 �@�I���\���̌����v�Z�̏�Q����(��2115)��25</br>
    /// <br>Update Note: 2014/03/20 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
    /// <br>           : Redmine#40178 �I���\���ƒI���\�ŒI�����z�ɍ��ق�������Ή�</br>
    /// <br>Update Note: 2014/05/13 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070071-00 </br>
    /// <br>           : Redmine#36564 �I���\���̑��x���P(#1989)</br>
    /// <br>Update Note: 2014/07/01 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070071-00 </br>
    /// <br>           : Redmine#42984 ���l���H(�I���\��)�̏�Q�Ή�</br>
    /// <br>Update Note: 2015/03/13 caohh</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00 </br>
    /// <br>           : Redmine#44951 �I���\���̕s�(No.3)�Ή�</br>
    /// <br>           : �����v�Z�̊|���O���[�v�̃p�����[�^�̐ݒ���C��</br>
    /// <br>           : �i�O���[�v�R�[�h�}�X�^�̏��i������->BL�R�[�h�}�X�^�̏��i�����ނɕύX�j</br>
    /// <br>Update Note: 2020/06/17 ���J �M�m</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00 </br>
    /// <br>           : �d�a�d�΍�</br>
    /// <br>Update Note: 2020/10/20 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11675035-00</br>
    /// <br>             PMKOBETSU-3551 �I���\�������s����Ə����Ɏ��s���錻�ۂ̉���</br>
    /// <br>Update Note: 2021/03/16 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11770024-00</br>
    /// <br>             PMKOBETSU-3551 �I���\���̏�Q�Ή�</br> 
    /// <br>           : �@GoodsUnitData�̊�ƃR�[�h����̌�</br>
    /// <br>           : �A�|���D��Ǘ��}�X�^�̋��_�w�肪�y�S�Ћ��ʁz�̏ꍇ�A���_���̊|���f�[�^���g�p����Ă��܂���</br>
    /// <br>           : �B���_���̒P�i�ݒ�̊|���f�[�^������A�|���D��Ǘ��}�X�^��[6A]�����݂��Ȃ��ꍇ�A���_���̒P�i�ݒ�̊|���f�[�^���g�p����Ă��܂���</br>
    /// </remarks>
    [Serializable]
    public class InventoryDtDspDB : RemoteDB, IInventoryDtDspDB
    {
        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>DIC�L�[�t�H�[�}�b�g</summary>
        private const string ctDicKeyFmt = "{0}-{1:D4}-{2}";
        /// <summary>�S��</summary>
        private const string ctALLSection = "00";
        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
        /// <summary>
        /// �I���\��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
        /// </remarks>
        public InventoryDtDspDB()
            :
            base("PMZAI04207D", "Broadleaf.Application.Remoting.ParamData.InventoryDataDspResultWork", "STOCKRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̒I���\���f�[�^��߂��܂�
        /// </summary>
        /// <param name="inventoryDataDspResultWork">��������</param>
        /// <param name="inventoryDataDspParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���\���f�[�^��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
        public int Search(out object inventoryDataDspResultWork, object inventoryDataDspParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            inventoryDataDspResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchInventoryDtDsp(out inventoryDataDspResultWork, inventoryDataDspParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryDtDspDB.Search");
                inventoryDataDspResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̒I���\���f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objInventoryDataDspResultWork">��������</param>
        /// <param name="objInventoryDataDspParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���\���f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2013/10/14 ������</br>
        /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
        /// <br>           : Redmine#40178 �@�I���\���̌����v�Z�̏�Q����(��2115)</br>
        private int SearchInventoryDtDsp(out object objInventoryDataDspResultWork, object objInventoryDataDspParamWork, ref SqlConnection sqlConnection)
        {
            InventoryDataDspParamWork paramWork = null;

            ArrayList paramWorkList = objInventoryDataDspParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objInventoryDataDspParamWork as InventoryDataDspParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as InventoryDataDspParamWork;
            }

            ArrayList inventoryDataDspResultWork = null;

            // ---ADD 2011/03/22---------->>>>>
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "�I���\��", "���o�J�n");
            // ---ADD 2011/03/22----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �I���\���f�[�^���擾
            //status = SearchInventoryDtDspProc(out inventoryDataDspResultWork, paramWork, ref sqlConnection);//DEL ������ 2013/10/14 for Redmine#40178
            // --- ADD ������ 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
            Dictionary<int, SupplierWork> supplierDic = new Dictionary<int, SupplierWork>(); ;    // �d����}�X�^���Dictionary
            SupplierDB _supplierDB = new SupplierDB();  // �d����}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
            ArrayList supplierList = new ArrayList();
            SupplierWork supplierWork = new SupplierWork();
            supplierWork.EnterpriseCode = paramWork.EnterpriseCode;  // ��ƃR�[�h
            SqlTransaction sqlTrans = null;
            // �d����}�X�^�����擾����
            _supplierDB.Search(out supplierList, supplierWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTrans);�@// �d����}�X�^���̃��X�g���擾���܂�
            // �d����}�X�^���Dictionary���쐬
            foreach (SupplierWork supplierwork in supplierList)
            {
                if (!supplierDic.ContainsKey(supplierwork.SupplierCd))
                {
                    supplierDic.Add(supplierwork.SupplierCd, supplierwork);
                }
            }
            status = SearchInventoryDtDspProc(out inventoryDataDspResultWork, paramWork, ref sqlConnection, supplierDic);
            // --- ADD ������ 2013/10/14 for Redmine#40178 -------<<<<<<<<<<< 

            // ---ADD 2011/03/22---------->>>>>
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "�I���\��", "���o�I��");
            // ---ADD 2011/03/22----------<<<<<
            objInventoryDataDspResultWork = inventoryDataDspResultWork;
            return status;

        }
        #endregion  //Search

        #region [SearchInventoryDtDspProc]
        /// <summary>
        /// �w�肳�ꂽ�����̒I���\���f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inventoryDataDspResultWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒I���\���f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2013/10/14 ������</br>
        /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
        /// <br>           : Redmine#40178 �@�I���\���̌����v�Z�̏�Q����(��2115)</br>
        /// <br>Update Note: 2014/03/05 �c����</br>
        /// <br>           : Redmine#42247 ����@�\�̒ǉ�</br>
        /// <br>Update Note: 2014/03/10 ������</br>
        /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
        /// <br>           : Redmine#40178 �@�I���\���̌����v�Z�̏�Q����(��2115)��25</br>
        /// <br>Update Note: 2014/03/20 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
        /// <br>           : Redmine#40178 �I���\���ƒI���\�ŒI�����z�ɍ��ق�������Ή�</br>
        /// <br>Update Note: 2014/05/13 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070071-00 </br>
        /// <br>           : Redmine#36564 �I���\���̑��x���P(#1989)</br>
        /// <br>Update Note: 2014/07/01 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070071-00 </br>
        /// <br>           : Redmine#42984 ���l���H(�I���\��)�̏�QNo.98�Ή�</br>
        /// <br>Update Note: 2015/03/12 caohh</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 </br>
        /// <br>           : Redmine#44951 �I���\���̕s�(No.3)�Ή�</br>
        /// <br>           : �����v�Z�̊|���O���[�v�̃p�����[�^�̐ݒ���C��</br>
        /// <br>           : �i�O���[�v�R�[�h�}�X�^�̏��i������->BL�R�[�h�}�X�^�̏��i�����ނɕύX�j</br>
        /// <br>Update Note: 2020/06/17 ���J �M�m</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00 </br>
        /// <br>           : �d�a�d�΍�</br>
        /// <br>Update Note: 2020/10/20 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551 �I���\�������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        /// <br>Update Note: 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 �I���\���̏�Q�Ή�</br>  
        //private int SearchInventoryDtDspProc(out ArrayList inventoryDataDspResultWorkList, InventoryDataDspParamWork paramWork, ref SqlConnection sqlConnection)//DEL ������ 2013/10/14 for Redmine#40178
        private int SearchInventoryDtDspProc(out ArrayList inventoryDataDspResultWorkList, InventoryDataDspParamWork paramWork, ref SqlConnection sqlConnection, Dictionary<int, SupplierWork> supplierDic)// ADD ������ 2013/10/14 for Redmine#40178
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            inventoryDataDspResultWorkList = new ArrayList();//ADD �c���� 2014/05/13 for Redmine#36564
            ArrayList al = new ArrayList();

            // �C�� 2009/04/27 >>>
            //ArrayList ResultWorkList = new ArrayList();//DEL �c���� 2014/05/13 for Redmine#36564
            List<InventoryDataDspResultWork> ResultWorkList = null;//ADD �c���� 2014/05/13 for Redmine#36564

            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();

            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �����Z�o�p
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            // --- DEL �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
            //List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // �����v�Z�p�����[�^�I�u�W�F�N�g���X�g
            //List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // ���i�A���f�[�^�I�u�W�F�N�g���X�g
            // --- DEL �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<< 
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // �����v�Z���ʃ��X�g 
            //----- ADD 2014/05/13 �c���� for Redmine#36564 ------->>>>>
            List<UnitPriceCalcParamWork> beUnitPriceCalcParamWorkList = new List<UnitPriceCalcParamWork>();
            List<GoodsUnitDataWork> beGoodsUnitDataWorkList = new List<GoodsUnitDataWork>();
            List<GoodsPriceUWork> beGoodsPriceUWorkList = new List<GoodsPriceUWork>();
            //----- ADD 2014/05/13 �c���� for Redmine#36564 -------<<<<<
            // �C�� 2009/04/27 <<<
            List<string> warehouseCodeList = new List<string>();//ADD ������ 2013/10/14 for Redmine#40178
            string sqlText = string.Empty;
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // �P�i�|��Dic// ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� 
            // --- ADD START ���J 2020/06/17 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD END   ���J 2020/06/17 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                // �C�� 2009/04/27 >>>
                #region DEL 2009/04/27
                /*
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                #region [SELECT]
                sqlCommand.CommandText = "SELECT" + Environment.NewLine;
                sqlCommand.CommandText += "	MAIN.ENTERPRISECODE AS ENTERPRISECODE " + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.WAREHOUSECODE  AS WAREHOUSECODE" + Environment.NewLine;
                sqlCommand.CommandText += "	,WAREHOUSE.WAREHOUSENAMERF AS WAREHOUSENAME" + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.GOODSCOUNT AS GOODSCOUNT" + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.INVENTORYMONEY AS INVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.MAXIMUMINVENTORYMONEY AS MAXIMUMINVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "FROM" + Environment.NewLine;
                sqlCommand.CommandText += "(" + Environment.NewLine;
                sqlCommand.CommandText += "	SELECT" + Environment.NewLine;
                sqlCommand.CommandText += "		ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlCommand.CommandText += "		,WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                sqlCommand.CommandText += "		,COUNT(*) AS GOODSCOUNT" + Environment.NewLine;
                sqlCommand.CommandText += "		,SUM(SHIPMENTPOSCNTRF * STOCKUNITPRICEFLRF ) AS INVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "		,SUM(MAXIMUMSTOCKCNTRF * STOCKUNITPRICEFLRF) AS MAXIMUMINVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "	FROM" + Environment.NewLine;
                sqlCommand.CommandText += "		STOCKRF" + Environment.NewLine;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paramWork);
                sqlCommand.CommandText += "	GROUP BY" + Environment.NewLine;
                sqlCommand.CommandText += "		ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += "		,WAREHOUSECODERF" + Environment.NewLine;
                sqlCommand.CommandText += ") AS MAIN " + Environment.NewLine;
                sqlCommand.CommandText += "LEFT JOIN " + Environment.NewLine;
                sqlCommand.CommandText += "	WAREHOUSERF AS WAREHOUSE " + Environment.NewLine;
                sqlCommand.CommandText += " ON " + Environment.NewLine;
                sqlCommand.CommandText += "	MAIN.ENTERPRISECODE = WAREHOUSE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += "	AND MAIN.WAREHOUSECODE = WAREHOUSE.WAREHOUSECODERF" + Environment.NewLine;
                // ADD 2008.12.02 >>>
                sqlCommand.CommandText += " WHERE" + Environment.NewLine;
                sqlCommand.CommandText += " WAREHOUSE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                // ADD 2008.12.02 <<<

                #endregion
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToInventoryDtDspWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                */
                #endregion

                #region SELECT���쐬
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,STOCK.SECTIONCODERF -- ���_�R�[�h" + Environment.NewLine;
                sqlText += " ,STOCK.WAREHOUSECODERF -- �q�ɃR�[�h" + Environment.NewLine;
                //sqlText += " ,WAREHOUSE.WAREHOUSENAMERF -- �q�ɖ���_�q�Ƀ}�X�^" + Environment.NewLine;// DEL 2014/03/05 �c���� Redmine#42247
                //----- ADD 2014/03/05 �c���� Redmine#42247 ---------->>>>>
                sqlText += " ,CASE WHEN WAREHOUSE.WAREHOUSECODERF IS NULL THEN '���o�^' -- �q�ɖ���_�q�Ƀ}�X�^" + Environment.NewLine;
                sqlText += " WHEN WAREHOUSE.LOGICALDELETECODERF = 1 THEN '��' + WAREHOUSE.WAREHOUSENAMERF ELSE WAREHOUSE.WAREHOUSENAMERF END WAREHOUSENAMERF -- �q�ɖ���_�q�Ƀ}�X�^" + Environment.NewLine;
                //----- ADD 2014/03/05 �c���� Redmine#42247 ----------<<<<<
                sqlText += " ,STOCK.GOODSMAKERCDRF -- ���i���[�J�[" + Environment.NewLine;
                sqlText += " ,STOCK.GOODSNORF  -- �i��" + Environment.NewLine;
                //sqlText += " ,STOCK.SHIPMENTPOSCNTRF -- �o�׉\��" + Environment.NewLine;//DEL ������ 2014/03/10 for Redmine#40178��25
                //----ADD ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                sqlText += " ,STOCK.SUPPLIERSTOCKRF -- �d���݌ɐ�" + Environment.NewLine;
                sqlText += " ,STOCK.MOVINGSUPLISTOCKRF -- �ړ����d���݌ɐ�" + Environment.NewLine;
                sqlText += " ,STOCK.SHIPMENTCNTRF -- �o�א��i���v��j" + Environment.NewLine;
                sqlText += " ,STOCK.ARRIVALCNTRF -- ���א��i���v��j" + Environment.NewLine;
                //----ADD ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
                sqlText += " ,STOCK.MAXIMUMSTOCKCNTRF -- �ō��݌ɐ�" + Environment.NewLine;
                sqlText += " ,STOCK.STOCKUNITPRICEFLRF -- �d���P�� " + Environment.NewLine;
                sqlText += " ,GOODS.BLGOODSCODERF  -- BL�R�[�h_���i�}�X�^" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSRATERANKRF AS GOODSRATERANKRF" + Environment.NewLine;//ADD ������ 2013/10/14 for Redmine#40178
                sqlText += " ,BLGOODS.BLGROUPCODERF -- BL�O���[�v�R�[�h_BL�R�[�h�}�X�^" + Environment.NewLine;
                sqlText += " ,BLGOODS.GOODSRATEGRPCODERF -- ���i�|���O���[�v�R�[�h_BL�R�[�h�}�X�^" + Environment.NewLine; // ADD caohh 2015/03/13 for Redmine#44951
                sqlText += " ,BLGROUP.GOODSMGROUPRF -- ���i�����ރR�[�h_BL�O���[�v�R�[�h�}�X�^" + Environment.NewLine;
                // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                sqlText += " ,GOODSPRICEURF.CREATEDATETIMERF AS GPRICEU_CREATEDATETIMERF,GOODSPRICEURF.UPDATEDATETIMERF AS GPRICEU_UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.ENTERPRISECODERF AS GPRICEU_ENTERPRISECODERF,GOODSPRICEURF.FILEHEADERGUIDRF AS GPRICEU_FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.UPDEMPLOYEECODERF AS GPRICEU_UPDEMPLOYEECODERF,GOODSPRICEURF.UPDASSEMBLYID1RF AS GPRICEU_UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.UPDASSEMBLYID2RF AS GPRICEU_UPDASSEMBLYID2RF,GOODSPRICEURF.LOGICALDELETECODERF AS GPRICEU_LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.GOODSMAKERCDRF AS GPRICEU_GOODSMAKERCDRF,GOODSPRICEURF.GOODSNORF AS GPRICEU_GOODSNORF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.PRICESTARTDATERF AS GPRICEU_PRICESTARTDATERF,GOODSPRICEURF.LISTPRICERF AS GPRICEU_LISTPRICERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.SALESUNITCOSTRF AS GPRICEU_SALESUNITCOSTRF,GOODSPRICEURF.STOCKRATERF AS GPRICEU_STOCKRATERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.OPENPRICEDIVRF AS GPRICEU_OPENPRICEDIVRF,GOODSPRICEURF.OFFERDATERF AS GPRICEU_OFFERDATERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.UPDATEDATERF AS GPRICEU_UPDATEDATERF " + Environment.NewLine;
                // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
                sqlText += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                sqlText += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                sqlText += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                sqlText += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                sqlText += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                sqlText += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                sqlText += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                sqlText += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                sqlText += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                sqlText += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                sqlText += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                sqlText += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                sqlText += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                sqlText += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                sqlText += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                sqlText += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<
                // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                sqlText += "FROM" + Environment.NewLine;
                //sqlText += " STOCKRF AS STOCK" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += " STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " -- ���i" + Environment.NewLine;
                //sqlText += "INNER JOIN GOODSURF AS GOODS" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "INNER JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += "-- BL�R�[�h " + Environment.NewLine;
                //sqlText += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "LEFT JOIN BLGOODSCDURF AS BLGOODS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "-- BL�O���[�v" + Environment.NewLine;
                //sqlText += "LEFT JOIN BLGROUPURF AS BLGROUP" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;
                sqlText += "-- �q�Ƀ}�X�^" + Environment.NewLine;
                //sqlText += "LEFT JOIN WAREHOUSERF AS WAREHOUSE " + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "LEFT JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STOCK.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF" + Environment.NewLine;
                // ---  ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                sqlText += " LEFT JOIN GOODSPRICEURF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += " ON GOODSPRICEURF.ENTERPRISECODERF = STOCK.ENTERPRISECODERF AND GOODSPRICEURF.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                // ---  ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<< 
                // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
                sqlText += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += " ON STOCK.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STOCK.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                sqlText += " AND STOCK.LOGICALDELETECODERF = RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlText += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlText += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlText += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlText += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlText += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlText += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                sqlText += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += " ON STOCK.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                sqlText += " AND STOCK.LOGICALDELETECODERF = RATE2.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlText += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlText += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlText += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlText += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlText += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlText += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<
                #endregion

                sqlText += MakeWhereString(ref sqlCommand, paramWork);

                //sqlText += " ORDER BY STOCK.WAREHOUSECODERF" + Environment.NewLine;//DEL �c���� 2014/05/13 for Redmine#36564
                sqlText += " ORDER BY STOCK.SECTIONCODERF ASC, STOCK.WAREHOUSECODERF ASC, STOCK.GOODSMAKERCDRF ASC, STOCK.GOODSNORF ASC, GOODSPRICEURF.PRICESTARTDATERF DESC";// ADD �c���� 2014/05/13 for Redmine#36564

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 3600;// ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή�
                myReader = sqlCommand.ExecuteReader();
                // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                InventoryDataDspResultWork beInventoryDataWork = null;
                GoodsSupplierDataWork beGoodsSupplierDataWork = null;
                UnitPriceCalcParamWork beUnitPriceCalcParamWork = null;
                GoodsUnitDataWork beGoodsUnitDataWork = null;
                GoodsPriceUWork beGoodsPriceUWork = null;

                GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                string enterpriseCode = "";
                DateTime priceStartDate = DateTime.MinValue;
                //�d�����z�����敪�}�X�^�ǂݍ���
                List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();
                unitPriceCalculation.SearchStockProcMoneyForInventory(paramWork.EnterpriseCode, out stockProcMoneyList);

                // ����ł̒[�������P�ʁA�[�������敪���擾
                double taxFractionProcUnit;
                int taxFractionProcCd;
                this.GetStockFractionProcInfo(1, 0, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);
                List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
                unitPriceCalculation.SearchRateProtyMngForInventory(paramWork.EnterpriseCode, out rateProtyMngAllList);

                ArrayList secList = new ArrayList();
                ArrayList list = new ArrayList();
                ArrayList arrList = new ArrayList(); // ADD �c���� 2014/07/01 for Redmine#42984
                // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                //----ADD ������ 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //���_�{���[�J�[�{�i��
                Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //���_�{�����ށ{���[�J�[�{�a�k
                Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //���_�{�����ށ{���[�J�[
                Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //���_�{���[�J�[

                goodsSupplierGetter.GetGoodsMngInfo(paramWork.EnterpriseCode, ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);
                // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                //string goodsNo = string.Empty;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                string keyValue = string.Empty;
                RateWork rateAllSec = null;
                // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<
                //----ADD ������ 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<
                while (myReader.Read())
                {
                    //al.Add(CopyToInventoryDtDspWorkFromReader(ref myReader, paramWork));//DEL �c���� 2014/05/13 for Redmine#36564
                    // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                    InventoryDataDspResultWork wkInventoryDataWork = new InventoryDataDspResultWork();
                    wkInventoryDataWork = CopyToInventoryDtDspWorkFromReader(ref myReader, paramWork);
                    // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                    GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g
                    goodsPriceUWork = new GoodsPriceUWork();      //ADD �c���� 2014/05/13 for Redmine#36564

                    #region ���i�d���擾�f�[�^�N���X
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //��ƃR�[�h
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
                    //----- ADD 2014/05/13 �c���� for Redmine#36564 ------->>>>>
                    if (!secList.Contains(goodsSupplierDataWork.SectionCode))
                    {
                        secList.Add(goodsSupplierDataWork.SectionCode);
                    }
                    //----- ADD 2014/05/13 �c���� for Redmine#36564 -------<<<<<
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // ���i�ԍ�
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   // BL���i�R�[�h
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));   // ���i������
                    //GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);//DEL �c���� 2014/05/13 for Redmine#36564
                    #endregion

                    //----ADD ������ 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                    goodsMngDic1 = goodsMngDic1 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic1;
                    goodsMngDic2 = goodsMngDic2 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic2;
                    goodsMngDic3 = goodsMngDic3 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic3;
                    goodsMngDic4 = goodsMngDic4 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic4;
                    goodsSupplierGetter.GetSupplierInfo(ref goodsSupplierDataWork, goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4);
                    //----ADD ������ 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<

                    #region �P���Z�o���W���[���v�Z�p�p�����[�^
                    if (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF")) == 0) // �݌Ƀ}�X�^�E�d���P����0�̃��R�[�h�݂̂�ΏۂƂ���
                    {
                        //unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //��ƃR�[�h DEL ������ 2013/09/16 for Redmine#40178
                        unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); //���_�R�[�h ADD ������ 2013/09/16 for Redmine#40178
                        unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[
                        unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // ���i�ԍ�
                        //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));   // ���i������ // DEL caohh 2015/03/13 for Redmine#44951
                        unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));// ���i�|���O���[�v�R�[�h// ADD caohh 2015/03/13 for Redmine#44951
                        unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));   // BL�O���[�v�R�[�h
                        unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   // BL���i�R�[�h
                        unitPriceCalcParam.PriceApplyDate = DateTime.Now;
                        //----ADD ������ 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                        unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));  // �w�ʁ@
                        warehouseCodeList.Add(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")));
                        unitPriceCalcParam.SupplierCd = goodsSupplierDataWork.SupplierCd;
                        if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParam.SupplierCd))
                        {
                            unitPriceCalcParam.StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParam.SupplierCd].StockUnPrcFrcProcCd;
                        }
                        //----ADD ������ 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<
                        //unitPriceCalcParamList.Add(unitPriceCalcParam);//DEL �c���� 2014/05/13 for Redmine#36564
                    }
                    #endregion

                    #region ���i�A���f�[�^���X�g
                    if (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF")) == 0)// �݌Ƀ}�X�^�E�d���P����0�̃��R�[�h�݂̂�ΏۂƂ���
                    {
                        goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //��ƃR�[�h
                        goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // ���i�ԍ�
                        goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[
                        //goodsUnitDataList.Add(goodsUnitData);//DEL �c���� 2014/05/13 for Redmine#36564
                    }
                    #endregion

                    // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                    enterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_ENTERPRISECODERF"));
                    if (enterpriseCode != null && enterpriseCode != "")
                    {
                        priceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_PRICESTARTDATERF"));
                        if (priceStartDate < DateTime.Now)
                        {
                            if (priceStartDate > goodsPriceUWork.PriceStartDate)
                            {
                                goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_CREATEDATETIMERF"));
                                goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATETIMERF"));
                                goodsPriceUWork.EnterpriseCode = enterpriseCode;
                                goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GPRICEU_FILEHEADERGUIDRF"));
                                goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDEMPLOYEECODERF"));
                                goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID1RF"));
                                goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID2RF"));
                                goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_LOGICALDELETECODERF"));
                                goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_GOODSMAKERCDRF"));
                                goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_GOODSNORF"));
                                goodsPriceUWork.PriceStartDate = priceStartDate;

                                // --- UPD START ���J 2020/06/17 ---------->>>>>
                                //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));
                                convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                                convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                                convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));

                                // �ϊ��������s
                                convertDoubleRelease.ReleaseProc();

                                goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                                // --- UPD END   ���J 2020/06/17 ----------<<<<<

                                goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_SALESUNITCOSTRF"));
                                goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_STOCKRATERF"));
                                goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_OPENPRICEDIVRF"));
                                goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_OFFERDATERF"));
                                goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATERF"));
                            }
                        }
                        // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
                        // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //// �����i�̉��i���ݒ�̏ꍇ�A�P�i�|���̉��i�A�d�������Z�b�g����
                        ////if ((goodsPriceUWork.SalesUnitCost == 0) && ((goodsPriceUWork.StockRate == 0 || goodsPriceUWork.ListPrice == 0)))
                        //{
                        //    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                        //    if (goodsPriceUWork.LogicalDeleteCode == 0)
                        //    {
                        //        goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                        //    }
                        //}
                        // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

                        #region �P�i�|�����X�g

                        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //���_���P�i�|��
                        keyValue = string.Format(ctDicKeyFmt, wkInventoryDataWork.SectionCode.Trim(), wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //�����i�̋��_���P�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));           // ���i�ԍ�
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //�S�ВP�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));

                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<
                    }

                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                            && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode)
                        {
                            if (goodsPriceUWork.EnterpriseCode != "")
                            {
                                if (beGoodsPriceUWork == null || goodsPriceUWork.PriceStartDate > beGoodsPriceUWork.PriceStartDate)
                                {
                                    beGoodsPriceUWork = goodsPriceUWork;
                                }

                            }

                            // 1���R�[�h�O�Ɠ����������ꍇ
                            continue; // ���� 
                        }
                    }
                    else
                    {
                        // BeforeData
                        beInventoryDataWork = wkInventoryDataWork;
                        beGoodsSupplierDataWork = goodsSupplierDataWork;
                        beUnitPriceCalcParamWork = unitPriceCalcParam;
                        beGoodsUnitDataWork = goodsUnitData;
                        beGoodsPriceUWork = goodsPriceUWork;
                        //ArrayList arrList = new ArrayList(); // DEL �c���� 2014/07/01 for Redmine#42984
                        arrList = new ArrayList(); // ADD �c���� 2014/07/01 for Redmine#42984
                        if (!arrList.Contains(beGoodsPriceUWork))
                        {
                            arrList.Add(beGoodsPriceUWork);
                            beGoodsUnitDataWork.PriceList = arrList;
                        }
                        continue;
                    }

                    // 1���R�[�h�O�ƕς�����ꍇ�ABeforeData�����X�g�ɒǉ�
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);

                    beUnitPriceCalcParamWorkList.Add(beUnitPriceCalcParamWork);
                    beGoodsUnitDataWorkList.Add(beGoodsUnitDataWork);
                    beGoodsPriceUWorkList.Add(beGoodsPriceUWork);
                    //----- ADD �c���� 2014/07/01 for Redmine#42984 ----->>>>>
                    arrList = new ArrayList();
                    if (!arrList.Contains(beGoodsPriceUWork))
                    {
                        arrList.Add(beGoodsPriceUWork);
                        beGoodsUnitDataWork.PriceList = arrList;
                    }
                    //----- ADD �c���� 2014/07/01 for Redmine#42984 -----<<<<<

                    // ���݂̃��R�[�h��BeforeData�ɃZ�b�g
                    beInventoryDataWork = wkInventoryDataWork;
                    beGoodsSupplierDataWork = goodsSupplierDataWork;
                    beUnitPriceCalcParamWork = unitPriceCalcParam;
                    beGoodsUnitDataWork = goodsUnitData;
                    if (goodsPriceUWork.EnterpriseCode != "")
                    {
                        beGoodsPriceUWork = goodsPriceUWork;
                        //----- DEL �c���� 2014/07/01 for Redmine#42984 ----->>>>>
                        //ArrayList arrList = new ArrayList();
                        //if (!arrList.Contains(beGoodsPriceUWork))
                        //{
                        //    arrList.Add(beGoodsPriceUWork);
                        //    beGoodsUnitDataWork.PriceList = arrList;
                        //}
                        //----- DEL �c���� 2014/07/01 for Redmine#42984 -----<<<<<
                    }
                    else
                    {
                        beGoodsPriceUWork = null;
                    }
                    // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                }

                // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                // �Ō��BeforeData�����X�g�ɒǉ�����
                if (beInventoryDataWork != null)
                {
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);

                    beUnitPriceCalcParamWorkList.Add(beUnitPriceCalcParamWork);
                    beGoodsUnitDataWorkList.Add(beGoodsUnitDataWork);
                    beGoodsPriceUWorkList.Add(beGoodsPriceUWork);

                    //----- ADD �c���� 2014/07/01 for Redmine#42984 ----->>>>>
                    arrList = new ArrayList();
                    if (!arrList.Contains(beGoodsPriceUWork))
                    {
                        arrList.Add(beGoodsPriceUWork);
                        beGoodsUnitDataWork.PriceList = arrList;
                    }
                    //----- ADD �c���� 2014/07/01 for Redmine#42984 -----<<<<<
                }
                // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<

                // ---ADD 2011/03/22---------->>>>>
                if (GoodsSupplierDataWorkList.Count == 0)
                {
                    inventoryDataDspResultWorkList = new ArrayList();
                    return status;
                }
                // ---ADD 2011/03/22----------<<<<<

                //----- ADD 2014/05/13 �c���� for Redmine#36564 ------->>>>>
                List<RateWork> rateList;
                List<UnitPriceCalculation.UnitPriceKind> unitPriceKindList = new List<UnitPriceCalculation.UnitPriceKind>();
                unitPriceKindList.Add(UnitPriceCalculation.UnitPriceKind.UnitCost);
                // --- UPD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
                //unitPriceCalculation.SearchRateForInventoryDis(paramWork.EnterpriseCode, secList, out rateList);
                unitPriceCalculation.SearchRateForInventoryDis2(paramWork.EnterpriseCode, secList, out rateList);
                // --- UPD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<

                for (int i = 0; i < beUnitPriceCalcParamWorkList.Count; i++)
                {
                    // --- UPD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //unitPriceCalculation.CalculateUnitCostPrice(ref unitPriceCalcRetList, beGoodsPriceUWorkList[i], taxFractionProcUnit, taxFractionProcCd
                    //               , beUnitPriceCalcParamWorkList[i], stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWorkList[i], rateList);
                    unitPriceCalculation.CalculateUnitCostPrice2(ref unitPriceCalcRetList, beGoodsPriceUWorkList[i], taxFractionProcUnit, taxFractionProcCd
                                   , beUnitPriceCalcParamWorkList[i], stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWorkList[i], rateList, rateWorkByGoodsNoDic);
                    // --- UPD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<
                }
                //----- ADD 2014/05/13 �c���� for Redmine#36564 -------<<<<<

                #region �d���P���擾����
                //----DEL ������ 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                //// ���i�d������擾���� ���s
                //goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                //// ���i�d������擾�����ɂ��擾�����d�����
                //// �P���Z�o�p�����[�^�ɃZ�b�g
                //for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                //{
                //    for (int j = 0; j < unitPriceCalcParamList.Count; j++) // �P���Z�o���W���[���v�Z�p�p�����[�^
                //    {
                //        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // ���i���[�J�[
                //            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // ���i�ԍ�
                //            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL���i�R�[�h
                //        {
                //            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                //            {
                //                unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                //            }
                //        }
                //    }
                //}
                //----DEL ������ 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<
                // --- DEL �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                /*//�����Z�o���� ���s
                unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

                // �����Z�o�����ɂ��擾����������
                // �I���\���f�[�^�N���X�ɃZ�b�g
                for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                {
                    for (int j = 0; j < al.Count; j++) // �I���\���f�[�^�N���X
                    {
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataDspResultWork)al[j]).GoodsMakerCd) && // ���i���[�J�[
                            (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataDspResultWork)al[j]).GoodsNo) &&           // BL���i�R�[�h
                            (warehouseCodeList[i] == ((InventoryDataDspResultWork)al[j]).WarehouseCode) &&           //�q�ɃR�[�h ADD ������ 2013/10/14 for Redmine#40178
                            (((InventoryDataDspResultWork)al[j]).StockUnitPriceFl == 0))
                        {
                            // �d���P��
                            ((InventoryDataDspResultWork)al[j]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        }
                    }
                }*/
                // --- DEL �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                // �����Z�o�����ɂ��擾����������
                // �I���\���f�[�^�N���X�ɃZ�b�g
                for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                {

                    if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataDspResultWork)al[i]).GoodsMakerCd) && // ���i���[�J�[
                        (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataDspResultWork)al[i]).GoodsNo) &&           // BL���i�R�[�h
                        (((InventoryDataDspResultWork)al[i]).StockUnitPriceFl == 0))
                    {
                        // �d���P��
                        ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                    }
                }
                // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                #endregion

                #region ���z�v�Z����
                InventoryDataDspResultWork ResultWork = new InventoryDataDspResultWork();
                ResultWorkList = new List<InventoryDataDspResultWork>();//ADD �c���� 2014/05/13 for Redmine#36564
                int UpFlg = 0;

                for (int i = 0; i < al.Count; i++)
                {
                    UpFlg = 0;
                    ResultWork = new InventoryDataDspResultWork();
                    if (ResultWorkList.Count == 0)
                    {
                        ResultWork.EnterpriseCode = ((InventoryDataDspResultWork)al[i]).EnterpriseCode; // ��ƃR�[�h
                        ResultWork.WarehouseCode = ((InventoryDataDspResultWork)al[i]).WarehouseCode; // �q�ɃR�[�h
                        ResultWork.WarehouseName = ((InventoryDataDspResultWork)al[i]).WarehouseName; // �q�ɖ���
                        ResultWork.InventoryItemCnt = 1; // ���ѐ�
                        //----DEL ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                        //// �I�����z = �o�׉\�� �~ �d���P��
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).ShipmentPosCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                        //----DEL ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
                        //----ADD ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                        // �I�����z = �݌ɐ� �~ �d���P��
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 �c���� Redmine#40178
                        ResultWork.InventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 �c���� Redmine#40178
                        //----ADD ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<

                        // �ō��I�����z = �ō��݌ɐ� �~ �d���P��
                        //ResultWork.MaximumInventoryMoney = ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 �c���� Redmine#40178
                        ResultWork.MaximumInventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 �c���� Redmine#40178

                        ResultWorkList.Add(ResultWork);
                        continue;
                    }

                    for (int j = 0; j < ResultWorkList.Count; j++)
                    {
                        if (((InventoryDataDspResultWork)ResultWorkList[j]).WarehouseCode.Trim() == ((InventoryDataDspResultWork)al[i]).WarehouseCode.Trim())
                        {
                            UpFlg = 1;
                            //----DEL ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                            //// �I�����z += �o�׉\�� �~ �d���P��
                            //((InventoryDataDspResultWork)ResultWorkList[j]).InventoryMoney += ((InventoryDataDspResultWork)al[i]).ShipmentPosCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                            //----DEL ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
                            //----ADD ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                            // �I�����z += �݌ɐ� �~ �d���P��
                            //((InventoryDataDspResultWork)ResultWorkList[j]).InventoryMoney += ((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 �c���� Redmine#40178
                            ((InventoryDataDspResultWork)ResultWorkList[j]).InventoryMoney += Math.Floor(((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 �c���� Redmine#40178
                            //----ADD ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
                            // �ō��I�����z = �ō��݌ɐ� �~ �d���P��
                            //((InventoryDataDspResultWork)ResultWorkList[j]).MaximumInventoryMoney += ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 �c���� Redmine#40178
                            ((InventoryDataDspResultWork)ResultWorkList[j]).MaximumInventoryMoney += Math.Floor(((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 �c���� Redmine#40178
                            // ���ѐ�
                            ((InventoryDataDspResultWork)ResultWorkList[j]).InventoryItemCnt += 1;
                            break;
                        }
                    }
                    if (UpFlg == 0)
                    {
                        ResultWork.EnterpriseCode = ((InventoryDataDspResultWork)al[i]).EnterpriseCode; // ��ƃR�[�h
                        ResultWork.WarehouseCode = ((InventoryDataDspResultWork)al[i]).WarehouseCode; // �q�ɃR�[�h
                        ResultWork.WarehouseName = ((InventoryDataDspResultWork)al[i]).WarehouseName; // �q�ɖ���
                        ResultWork.InventoryItemCnt = 1; // ���ѐ�
                        //----DEL ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                        //// �I�����z = �o�׉\�� �~ �d���P��
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).ShipmentPosCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                        //----DEL ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
                        //----ADD ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                        // �I�����z = �݌ɐ� �~ �d���P��
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 �c���� Redmine#40178
                        ResultWork.InventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 �c���� Redmine#40178
                        //----ADD ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
                        // �ō��I�����z = �ō��݌ɐ� �~ �d���P��
                        // 2012/02/24 >>>
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                        //ResultWork.MaximumInventoryMoney = ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 �c���� Redmine#40178
                        ResultWork.MaximumInventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 �c���� Redmine#40178
                        // 2012/02/24 <<<
                        ResultWorkList.Add(ResultWork);
                    }
                }

                #endregion
                // �C�� 2009/04/27 <<<
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
                // --- ADD START ���J 2020/06/17 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                // --- ADD END   ���J 2020/06/17 ----------<<<<<
            }
            // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
            ResultWorkList.Sort(
                delegate(InventoryDataDspResultWork a, InventoryDataDspResultWork b)
                {
                    return
                        a.WarehouseCode.CompareTo(b.WarehouseCode);
                });
            Array array = ResultWorkList.ToArray();
            inventoryDataDspResultWorkList = new ArrayList(array);
            // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
            // �C�� 2009/04/27 >>>
            //inventoryDataDspResultWorkList = al;
            //inventoryDataDspResultWorkList = ResultWorkList;//DEL �c���� 2014/05/13 for Redmine#36564
            // �C�� 2009/04/27 <<<
            return status;
        }
        #endregion  //SearchInventoryDtDspProc

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="inventoryDataDspParamWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, InventoryDataDspParamWork inventoryDataDspParamWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            // ��ƃR�[�h�ݒ�
            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            if (inventoryDataDspParamWork.WarehouseDiv == 0) // 0:�͈�,1:�P��
            {
                //�q�ɃR�[�h�ݒ�
                if (inventoryDataDspParamWork.StWarehouseCode != "")
                {
                    retString.Append(" AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine);
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.StWarehouseCode);
                }
                if (inventoryDataDspParamWork.EdWarehouseCode != "")
                {
                    retString.Append(" AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine);
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.EdWarehouseCode + "%");
                }
            }
            else
            {
                if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                    inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                    inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                    inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" ||
                    inventoryDataDspParamWork.WarehouseCd09 != "" || inventoryDataDspParamWork.WarehouseCd10 != "") 
                {
                    retString.Append(" AND ( ");
                }

                //�q�ɃR�[�h01�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd01 != "")
                {
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD01" + Environment.NewLine);
                    SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                    paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd01);
                }

                //�q�ɃR�[�h02�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd02 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "") 
                    {
                        retString.Append(" OR");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD02" + Environment.NewLine);
                    SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                    paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd02);
                }

                //�q�ɃR�[�h03�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd03 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD03" + Environment.NewLine);
                    SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                    paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd03);
                }

                //�q�ɃR�[�h04�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd04 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD04" + Environment.NewLine);
                    SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                    paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd04);
                }

                //�q�ɃR�[�h05�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd05 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD05" + Environment.NewLine);
                    SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                    paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd05);
                }

                //�q�ɃR�[�h06�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd06 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "")
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD06" + Environment.NewLine);
                    SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                    paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd06);
                }

                //�q�ɃR�[�h07�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd07 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD07" + Environment.NewLine);
                    SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                    paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd07);
                }

                //�q�ɃR�[�h08�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd08 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                        inventoryDataDspParamWork.WarehouseCd07 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD08" + Environment.NewLine);
                    SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                    paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd08);
                }

                //�q�ɃR�[�h09�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd09 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                        inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD09" + Environment.NewLine);
                    SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                    paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd09);
                }

                //�q�ɃR�[�h10�ݒ�
                if (inventoryDataDspParamWork.WarehouseCd10 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                        inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" ||
                        inventoryDataDspParamWork.WarehouseCd09 != "")
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD10" + Environment.NewLine);
                    SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                    paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd10);
                }
                if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                    inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                    inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                    inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" ||
                    inventoryDataDspParamWork.WarehouseCd09 != "" || inventoryDataDspParamWork.WarehouseCd10 != "")
                {
                    retString.Append(" ) ");
                }

            }

            //���[�J�[�R�[�h�ݒ�
            if (inventoryDataDspParamWork.GoodsMakerCd != 0)
            {
                retString.Append(" AND STOCK.GOODSMAKERCDRF=@MAKERCODE" + Environment.NewLine);
                SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                paraMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataDspParamWork.GoodsMakerCd);
            }

            // �\���敪
            if (inventoryDataDspParamWork.ListDiv == 1)�@// 0:�S��,1:���Ѝ݌�,2:����݌�
            {
                retString.Append(" AND STOCK.STOCKDIVRF = 0 " + Environment.NewLine);
            }
            if (inventoryDataDspParamWork.ListDiv == 2)�@// 0:�S��,1:���Ѝ݌�,2:����݌�
            {
                retString.Append(" AND STOCK.STOCKDIVRF = 1 " + Environment.NewLine);
            }

            // �\���^�C�v
            if (inventoryDataDspParamWork.ListTypeDiv == 1)�@// 0:�ʏ�,1:���ѐ�=0�Ͷ��Ă��Ȃ�,2:�ő�
            {
                retString.Append(" AND STOCK.SUPPLIERSTOCKRF != 0 " + Environment.NewLine);
            }

            return retString.ToString();
        }
        # endregion

        #region [�N���X�i�[]
        /// <summary>
        /// �N���X�i�[���� Reader �� InventoryDataDspResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>InventoryDataDspResultWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
        /// <br>Update Note: 2014/03/10 ������</br>
        /// <br>�Ǘ��ԍ�   : 10904597-00 </br>
        /// <br>           : Redmine#40178 �@�I���\���̌����v�Z�̏�Q����(��2115)��25</br>
        /// </remarks>
        private InventoryDataDspResultWork CopyToInventoryDtDspWorkFromReader(ref SqlDataReader myReader, InventoryDataDspParamWork paramWork)
        {
            InventoryDataDspResultWork inventoryDataDspResultWork = new InventoryDataDspResultWork();

            if (myReader != null)
            {
                // �C�� 2009/04/27 >>>
                #region DEL 2009/04/27 
                /*
                # region �N���X�֊i�[
                inventoryDataDspResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                inventoryDataDspResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
                inventoryDataDspResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAME"));
                inventoryDataDspResultWork.InventoryItemCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSCOUNT"));               
                inventoryDataDspResultWork.MaximumInventoryMoney = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMINVENTORYMONEY"));
                inventoryDataDspResultWork.InventoryMoney = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYMONEY"));
                # endregion
                */
                #endregion
                inventoryDataDspResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //��ƃR�[�h
                inventoryDataDspResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); �@// ���_�R�[�h
                inventoryDataDspResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")); �@// �q�ɃR�[�h
                inventoryDataDspResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// �q�ɖ���
                inventoryDataDspResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[
                inventoryDataDspResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // ���i�ԍ�
                inventoryDataDspResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   // BL���i�R�[�h
                inventoryDataDspResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));   // BL�O���[�v�R�[�h
                inventoryDataDspResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));   // ���i������
                //inventoryDataDspResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF")); // �o�׉\��//DEL ������ 2014/03/10 for Redmine#40178��25
                inventoryDataDspResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF")); // �ō��݌ɐ�
                inventoryDataDspResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF")); // �d���P��
                // �C�� 2009/04/27 <<<
                //----ADD ������ 2014/03/10 for Redmine#40178��25 ------->>>>>>>>>>>
                double supplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF")); // �d���݌ɐ�
                double movingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF")); // �ړ����d���݌ɐ�
                double shipMentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF")); // �o�א��i���v��j
                double arrivalcnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF")); // ���א��i���v��j
                //�݌ɑ���=�݌Ƀ}�X�^.�d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�| �ړ����d���݌ɐ�
                inventoryDataDspResultWork.StockTotal = supplierStock + arrivalcnt - shipMentCnt - movingSupliStock;
                //----ADD ������ 2014/03/10 for Redmine#40178��25 -------<<<<<<<<<<<
            }

            return inventoryDataDspResultWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.08</br>
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

        // --- ADD �c���� 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
        #region GetStockFractionProcInfo
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="_stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = FractionProcMoney.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = FractionProcMoney.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if ((stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (stockProcMoney.FractionProcCode == fractionProcCode) &&
                                                (stockProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }
        #endregion
        // --- ADD �c���� 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
    }

}
