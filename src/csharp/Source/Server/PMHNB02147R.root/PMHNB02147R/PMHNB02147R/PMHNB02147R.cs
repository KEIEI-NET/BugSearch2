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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.9.10</br>
    /// <br></br>
    /// <br>UpdateNote : �C�X�R�Ή��EREADUNCOMMITTED�Ή�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br>UpdateNote : 2014/12/30 ������</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>UpdateNote : 2015/05/08 �c����</br>
    /// <br>�Ǘ��ԍ�  : 11070263-00</br>
    /// <br>           : �����Y�ƗlSeiken�i�ԕύX �O���[�o���ϐ��̍폜</br>
    /// </remarks>
    [Serializable]
    public class ShipGdsPrimeListResultWorkDB : RemoteDB, IShipGdsPrimeListResultWorkDB
    {
        //------ DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜 ---------------->>>>>
        #region DEL
        ////------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        //#region [���ʗp�t���O�錾]
        //private bool goodsNoSum = false;   //���Z�̏ꍇ�A���i�ԕ\��
        //#endregion
        ////------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
        #endregion
        //------ DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜 ----------------<<<<<
        /// <summary>
        /// �o�׏��i�D�ǑΉ��\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public ShipGdsPrimeListResultWorkDB()
            :
        base("PMHNB02149D", "Broadleaf.Application.Remoting.ParamData.ShipGdsPrimeListResultWork", "MTTLSALESSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �o�׏��i�D�ǑΉ��\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">��������</param>
        /// <param name="shipGdsPrimeListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.24</br>
        public int Search(out object shipGdsPrimeListResultList, object shipGdsPrimeListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            shipGdsPrimeListResultList = null;

            ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork = shipGdsPrimeListCndtnWork as ShipGdsPrimeListCndtnWork;

            try
            {
                status = SearchProc(out shipGdsPrimeListResultList, _shipGdsPrimeListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.Search Exception=" + ex.Message);
                shipGdsPrimeListResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">��������</param>
        /// <param name="_shipGdsPrimeListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 2014/12/22 ������</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>UpdateNote : 2015/05/08 �c����</br>
        /// <br>�Ǘ��ԍ�  : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX �O���[�o���ϐ��̍폜</br>
        private int SearchProc(out object shipGdsPrimeListResultList, ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            shipGdsPrimeListResultList = null;

            ArrayList al = new ArrayList();   //���o����
            //------ DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜 ---------------->>>>>
            #region DEL
            ////------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            ////���Z�̏ꍇ
            //if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
            //{
            //    goodsNoSum = true;
            //}
            ////�ʁX�̏ꍇ�A�����̏����Ɠ���
            //else
            //{
            //    goodsNoSum = false;
            //}
            ////------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            #endregion
            //------ DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜 ----------------<<<<<

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchProc(ref al, ref sqlConnection, _shipGdsPrimeListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.SearchProc Exception=" + ex.Message);
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

            shipGdsPrimeListResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_shipGdsPrimeListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref ArrayList al, ref SqlConnection sqlConnection, ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";
                sqlCommand.Parameters.Clear();
                //SELECT���쐬
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += "  ,MTL_TOTAL.CHGSRCGOODSNORF" + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                selectTxt += "  ,MTL_TOTAL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.SALESTIMESRF AS ST_SALESTIMESRF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.TOTALSALESCOUNTRF AS ST_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.SALESMONEYRF AS ST_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.SALESRETGOODSPRICERF AS ST_SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.DISCOUNTPRICERF AS ST_DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "  ,MTL_STOCK.GROSSPROFITRF AS ST_GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.SALESTIMESRF - (CASE WHEN MTL_STOCK.SALESTIMESRF IS NULL THEN 0 ELSE MTL_STOCK.SALESTIMESRF END)) AS OR_SALESTIMESRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.TOTALSALESCOUNTRF - (CASE WHEN MTL_STOCK.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE MTL_STOCK.TOTALSALESCOUNTRF END)) AS OR_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.SALESMONEYRF - (CASE WHEN MTL_STOCK.SALESMONEYRF IS NULL THEN 0 ELSE MTL_STOCK.SALESMONEYRF END)) AS OR_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.SALESRETGOODSPRICERF - (CASE WHEN MTL_STOCK.SALESRETGOODSPRICERF IS NULL THEN 0 ELSE MTL_STOCK.SALESRETGOODSPRICERF END)) AS OR_SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.DISCOUNTPRICERF - (CASE WHEN MTL_STOCK.DISCOUNTPRICERF IS NULL THEN 0 ELSE MTL_STOCK.DISCOUNTPRICERF END)) AS OR_DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "  ,(MTL_TOTAL.GROSSPROFITRF - (CASE WHEN MTL_STOCK.GROSSPROFITRF IS NULL THEN 0 ELSE MTL_STOCK.GROSSPROFITRF END)) AS OR_GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += " (SELECT" + Environment.NewLine;
                selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += "  ,MAX(MTL1.CHGSRCGOODSNORF) AS CHGSRCGOODSNORF" + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL1.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  FROM  " + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1" + Environment.NewLine;
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine; // DEL 2014/12/30 ������ FOR Redmine#44209����
                // 2011/08/01 <<<
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                //�i�ԏW�v�敪���u���Z�v�ꍇ
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += " SELECT" + Environment.NewLine;
                    selectTxt += "   MTL3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE1.CHGDESTGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE1.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE2.CHGSRCGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE2.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL3.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE1  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE1.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE1.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE1.CHGSRCGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE1.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE2  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE2.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE2.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE2.CHGDESTGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE2.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "  ) AS MTL1" + Environment.NewLine;
                }
                //�i�ԏW�v�敪�́u�ʁX�v�ꍇ
                else
                {
                    selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                selectTxt += MakeWhereString(ref sqlCommand, _shipGdsPrimeListCndtnWork, logicalMode, "MTL1");
                
                selectTxt += "  GROUP BY" + Environment.NewLine;
                selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTL_TOTAL" + Environment.NewLine;
                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += " (SELECT" + Environment.NewLine;
                selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                selectTxt += "	,SUM(MTL2.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "  FROM " + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2" + Environment.NewLine;
                //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;// DEL 2014/12/30 ������ FOR Redmine#44209����
                // 2011/08/01 <<<
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                // �i�ԏW�v�敪���u���Z�v�ꍇ
                if (_shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += " SELECT" + Environment.NewLine;
                    selectTxt += "   MTL4.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE3.CHGDESTGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE3.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,(CASE WHEN GOODSNOCHANGE4.CHGSRCGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE4.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.RSLTTTLDIVCDRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.ADDUPYEARMONTHRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL4.GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE3  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE3.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE3.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE3.CHGSRCGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE3.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE4  WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSNOCHANGE4.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE4.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE4.CHGDESTGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                    selectTxt += "   AND GOODSNOCHANGE4.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "  ) AS MTL2" + Environment.NewLine;
                }
                //�i�ԏW�v�敪�́u�ʁX�v�ꍇ
                else
                {
                    selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                selectTxt += MakeWhereString(ref sqlCommand, _shipGdsPrimeListCndtnWork, logicalMode, "MTL2");
                
                selectTxt += "  GROUP BY" + Environment.NewLine;
                selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTL_STOCK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	  MTL_STOCK.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTL_STOCK.ADDUPSECCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND MTL_STOCK.GOODSMAKERCDRF=MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND MTL_STOCK.GOODSNORF=MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                // 2011/08/01 >>>
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += "ON" + Environment.NewLine;
                // DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                //selectTxt += "      SEC.ENTERPRISECODERF=MTL_STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND SEC.SECTIONCODERF=MTL_STOCK.ADDUPSECCODERF" + Environment.NewLine;
                // DEL END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                selectTxt += "      SEC.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SEC.SECTIONCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                sqlCommand.CommandText = selectTxt;

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader); // DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜
                    ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader, _shipGdsPrimeListCndtnWork.GoodsNoTtlDiv); // ADD 2015/05/08 �c���� �O���[�o���ϐ��̍폜

                    al.Add(wkShipGdsPrimeListResultWork);
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="tblName">�e�[�u����</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, ShipGdsPrimeListCndtnWork _shipGdsPrimeListCndtnWork, ConstantManagement.LogicalMode logicalMode, string tblName)
        {
            string retstring = string.Empty;

            // 2011/08/01 >>>
            //retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS" + Environment.NewLine;
            retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "ON" + Environment.NewLine;
            retstring += "      BLGDS.ENTERPRISECODERF=" + tblName + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND BLGDS.BLGOODSCODERF=" + tblName + ".BLGOODSCODERF" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += "LEFT JOIN BLGROUPURF AS BLGRP" + Environment.NewLine;
            retstring += "LEFT JOIN BLGROUPURF AS BLGRP WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "ON" + Environment.NewLine;
            retstring += "      BLGRP.ENTERPRISECODERF=BLGDS.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND BLGRP.BLGROUPCODERF=BLGDS.BLGROUPCODERF" + Environment.NewLine;

            #region WHERE���쐬
            retstring += "WHERE" + Environment.NewLine;
            //��ƃR�[�h
            retstring += tblName + ".ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            if (tblName == "MTL1")
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_shipGdsPrimeListCndtnWork.EnterpriseCode);
            }

            if (tblName == "MTL1")
            {
                retstring += " AND MTL1.RSLTTTLDIVCDRF=0" + Environment.NewLine;
            }
            else
            if (tblName == "MTL2")
            {
                retstring += " AND MTL2.RSLTTTLDIVCDRF=1" + Environment.NewLine;
            }

            //�v�㋒�_�R�[�h
            if (_shipGdsPrimeListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _shipGdsPrimeListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND " + tblName + ".ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }

            //�N���x
            if (_shipGdsPrimeListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrimeListCndtnWork.St_AddUpYearMonth);
                }
            }
            if (_shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth);
                }
            }

            //�J�n���[�J�[�R�[�h
            if (_shipGdsPrimeListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND " + tblName + ".GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_GoodsMakerCd);
                }
            }

            //�I�����[�J�[�R�[�h
            if (_shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd != 0)
            {
                retstring += " AND " + tblName + ".GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                if (tblName == "MTL1")
                {

                    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd);
                }
            }

            //�J�n�a�k�R�[�h
            if (_shipGdsPrimeListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND " + tblName + ".BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_BLGoodsCode);
                }
            }

            //�I���a�k�R�[�h
            if (_shipGdsPrimeListCndtnWork.Ed_BLGoodsCode != 0)
            {
                retstring += " AND " + tblName + ".BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {

                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_BLGoodsCode);
                }
            }

            //�J�n�啪�ރR�[�h
            if (_shipGdsPrimeListCndtnWork.St_GoodsLGroup != 0)
            {
                retstring += " AND BLGRP.GOODSLGROUPRF>=@STGOODSLGROUP" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STGOODSLGROUP", SqlDbType.Int);
                    paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_GoodsLGroup);
                }
            }

            //�I���啪�ރR�[�h
            if (_shipGdsPrimeListCndtnWork.Ed_GoodsLGroup != 0)
            {
                if (_shipGdsPrimeListCndtnWork.St_GoodsLGroup != 0)
                {
                    retstring += " AND BLGRP.GOODSLGROUPRF<=@EDGOODSLGROUP" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (BLGRP.GOODSLGROUPRF<=@EDGOODSLGROUP OR BLGRP.GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                }
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdGoodsLGroup = sqlCommand.Parameters.Add("@EDGOODSLGROUP", SqlDbType.Int);
                    paraEdGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_GoodsLGroup);
                }
            }

            //�J�n�����ރR�[�h
            if (_shipGdsPrimeListCndtnWork.St_GoodsMGroup != 0)
            {
                retstring += " AND BLGRP.GOODSMGROUPRF>=@STGOODSMGROUP" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUP", SqlDbType.Int);
                    paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_GoodsMGroup);
                }
            }

            //�I�������ރR�[�h
            if (_shipGdsPrimeListCndtnWork.Ed_GoodsMGroup != 0)
            {
                if (_shipGdsPrimeListCndtnWork.St_GoodsMGroup != 0)
                {
                    retstring += " AND BLGRP.GOODSMGROUPRF<=@EDGOODSMGROUP" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (BLGRP.GOODSMGROUPRF<=@EDGOODSMGROUP OR BLGRP.GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                }
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUP", SqlDbType.Int);
                    paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_GoodsMGroup);
                }
            }

            //�J�n�O���[�v�R�[�h
            if (_shipGdsPrimeListCndtnWork.St_BLGroupCode != 0)
            {
                retstring += " AND BLGDS.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                    paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.St_BLGroupCode);
                }
            }

            //�I���O���[�v�R�[�h
            if (_shipGdsPrimeListCndtnWork.Ed_BLGroupCode != 0)
            {
                if (_shipGdsPrimeListCndtnWork.St_BLGroupCode != 0)
                {
                    retstring += " AND BLGDS.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (BLGDS.BLGROUPCODERF<=@EDBLGROUPCODE OR BLGDS.BLGROUPCODERF IS NULL)" + Environment.NewLine;
                }

                if (tblName == "MTL1")
                {
                    SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                    paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrimeListCndtnWork.Ed_BLGroupCode);
                }
            }

            #endregion
            return retstring;
        }
        #endregion


        #region �Ή��i�ԗp
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">��������</param>
        /// <param name="shipGdsPrmListCndtnPartnerList">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.24</br>
        public int SearchPartner(out object shipGdsPrimeListResultList, object shipGdsPrmListCndtnPartnerList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            shipGdsPrimeListResultList = null;

            ArrayList _shipGdsPrimeListCndtnPartnerList = shipGdsPrmListCndtnPartnerList as ArrayList;

            try
            {
                status = SearchProcPartner(out shipGdsPrimeListResultList, _shipGdsPrimeListCndtnPartnerList, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.Search Exception=" + ex.Message);
                shipGdsPrimeListResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">��������</param>
        /// <param name="_shipGdsPrimeListCndtnPartnerList">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̏o�׏��i�D�ǑΉ��\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 ���� DC.NS�p�ɏC��</br>
        private int SearchProcPartner(out object shipGdsPrimeListResultList, ArrayList _shipGdsPrimeListCndtnPartnerList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            shipGdsPrimeListResultList = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchProcPartner(ref al, ref sqlConnection, _shipGdsPrimeListCndtnPartnerList, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipGdsPrimeListResultWorkDB.SearchProcPartner Exception=" + ex.Message);
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

            shipGdsPrimeListResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_shipGdsPrimeListCndtnPartnerList">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2014/12/22 ������</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>UpdateNote : 2015/05/08 �c����</br>
        /// <br>�Ǘ��ԍ�  : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX �O���[�o���ϐ��̍폜</br>
        private int SearchProcPartner(ref ArrayList al, ref SqlConnection sqlConnection, ArrayList _shipGdsPrimeListCndtnPartnerList, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                foreach (ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork in _shipGdsPrimeListCndtnPartnerList)
                {
                    //------ DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜 ---------------->>>>>
                    #region DEL
                    ////------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    ////���Z�̏ꍇ
                    //if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1) 
                    //{
                    //    goodsNoSum = true;
                    //}
                    ////�ʁX�̏ꍇ�A�����̏����Ɠ���
                    //else
                    //{
                    //    goodsNoSum = false;
                    //}
                    ////------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                    #endregion
                    //------ DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜 ----------------<<<<<
                    selectTxt = "";
                    sqlCommand.Parameters.Clear();
                    //SELECT���쐬
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "   MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "  ,MTL_TOTAL.CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                    selectTxt += "	,MTL_TOTAL.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.SALESTIMESRF AS ST_SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.TOTALSALESCOUNTRF AS ST_TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.SALESMONEYRF AS ST_SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.SALESRETGOODSPRICERF AS ST_SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.DISCOUNTPRICERF AS ST_DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,MTL_STOCK.GROSSPROFITRF AS ST_GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.SALESTIMESRF - (CASE WHEN MTL_STOCK.SALESTIMESRF IS NULL THEN 0 ELSE MTL_STOCK.SALESTIMESRF END)) AS OR_SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.TOTALSALESCOUNTRF - (CASE WHEN MTL_STOCK.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE MTL_STOCK.TOTALSALESCOUNTRF END)) AS OR_TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.SALESMONEYRF - (CASE WHEN MTL_STOCK.SALESMONEYRF IS NULL THEN 0 ELSE MTL_STOCK.SALESMONEYRF END)) AS OR_SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.SALESRETGOODSPRICERF - (CASE WHEN MTL_STOCK.SALESRETGOODSPRICERF IS NULL THEN 0 ELSE MTL_STOCK.SALESRETGOODSPRICERF END)) AS OR_SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.DISCOUNTPRICERF - (CASE WHEN MTL_STOCK.DISCOUNTPRICERF IS NULL THEN 0 ELSE MTL_STOCK.DISCOUNTPRICERF END)) AS OR_DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "  ,(MTL_TOTAL.GROSSPROFITRF - (CASE WHEN MTL_STOCK.GROSSPROFITRF IS NULL THEN 0 ELSE MTL_STOCK.GROSSPROFITRF END)) AS OR_GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "FROM" + Environment.NewLine;
                    selectTxt += " (SELECT" + Environment.NewLine;
                    selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += "  ,MAX(MTL1.CHGSRCGOODSNORF) AS CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL1.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM  " + Environment.NewLine;
                    // 2011/08/01 >>>
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1" + Environment.NewLine;
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine; // DEL 2014/12/30 ������ FOR Redmine#44209����
                    // 2011/08/01 <<<
                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    //�i�ԏW�v�敪���u���Z�v�ꍇ
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += " ( " + Environment.NewLine;
                        selectTxt += " SELECT" + Environment.NewLine;
                        selectTxt += "   MTL3.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE1.CHGDESTGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE1.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE2.CHGSRCGOODSNORF IS NULL THEN " + "MTL3.GOODSNORF ELSE GOODSNOCHANGE2.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.RSLTTTLDIVCDRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.BLGOODSCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.SALESTIMESRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.TOTALSALESCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.SALESMONEYRF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.SALESRETGOODSPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.DISCOUNTPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL3.GROSSPROFITRF" + Environment.NewLine;
                        selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE1  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE1.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE1.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE1.CHGSRCGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE1.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE2  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE2.ENTERPRISECODERF=MTL3.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE2.GOODSMAKERCDRF=MTL3.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE2.CHGDESTGOODSNORF=MTL3.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE2.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "  ) AS MTL1" + Environment.NewLine;
                    }
                    //�i�ԏW�v�敪�́u�ʁX�v�ꍇ
                    else
                    {
                        selectTxt += "	GOODSMTTLSASLIPRF AS MTL1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                    selectTxt += MakeWhereStringPartner(ref sqlCommand, shipGdsPrmListCndtnPartnerWork, logicalMode, "MTL1");

                    selectTxt += "  GROUP BY" + Environment.NewLine;
                    selectTxt += "	 MTL1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL1.GOODSNORF" + Environment.NewLine;
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "  ) AS MTL_TOTAL" + Environment.NewLine;
                    selectTxt += "LEFT JOIN" + Environment.NewLine;
                    selectTxt += " (SELECT" + Environment.NewLine;
                    selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.SALESTIMESRF) AS SALESTIMESRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.TOTALSALESCOUNTRF) AS TOTALSALESCOUNTRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.SALESMONEYRF) AS SALESMONEYRF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.DISCOUNTPRICERF) AS DISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "	,SUM(MTL2.GROSSPROFITRF) AS GROSSPROFITRF" + Environment.NewLine;
                    selectTxt += "  FROM  " + Environment.NewLine;
                    // 2011/08/01 >>>
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2" + Environment.NewLine;
                    //selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine; // DEL 2014/12/30 ������ FOR Redmine#44209����
                    // 2011/08/01 <<<
                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    // �i�ԏW�v�敪���u���Z�v�ꍇ
                    if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                    {
                        selectTxt += " ( " + Environment.NewLine;
                        selectTxt += " SELECT" + Environment.NewLine;
                        selectTxt += "   MTL4.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE3.CHGDESTGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE3.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,(CASE WHEN GOODSNOCHANGE4.CHGSRCGOODSNORF IS NULL THEN " + "MTL4.GOODSNORF ELSE GOODSNOCHANGE4.CHGSRCGOODSNORF END) AS CHGSRCGOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.RSLTTTLDIVCDRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.BLGOODSCODERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.SALESTIMESRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.TOTALSALESCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.SALESMONEYRF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.SALESRETGOODSPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.DISCOUNTPRICERF" + Environment.NewLine;
                        selectTxt += "  ,MTL4.GROSSPROFITRF" + Environment.NewLine;
                        selectTxt += "  FROM GOODSMTTLSASLIPRF AS MTL4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE3  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE3.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE3.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE3.CHGSRCGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE3.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "   LEFT JOIN GOODSNOCHANGERF GOODSNOCHANGE4  WITH (READUNCOMMITTED) " + Environment.NewLine;
                        selectTxt += "   ON  GOODSNOCHANGE4.ENTERPRISECODERF=MTL4.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE4.GOODSMAKERCDRF=MTL4.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE4.CHGDESTGOODSNORF=MTL4.GOODSNORF" + Environment.NewLine;
                        selectTxt += "   AND GOODSNOCHANGE4.LOGICALDELETECODERF=0" + Environment.NewLine;
                        selectTxt += "  ) AS MTL2" + Environment.NewLine;
                    }
                    //�i�ԏW�v�敪�́u�ʁX�v�ꍇ
                    else
                    {
                        selectTxt += "	GOODSMTTLSASLIPRF AS MTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    }
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                    selectTxt += MakeWhereStringPartner(ref sqlCommand, shipGdsPrmListCndtnPartnerWork, logicalMode, "MTL2");

                    selectTxt += "  GROUP BY" + Environment.NewLine;
                    selectTxt += "	 MTL2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "	,MTL2.GOODSNORF" + Environment.NewLine;
                    selectTxt += "	,BLGDS.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += "  ) AS MTL_STOCK" + Environment.NewLine;
                    selectTxt += "ON" + Environment.NewLine;
                    selectTxt += "	  MTL_STOCK.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND MTL_STOCK.ADDUPSECCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                    selectTxt += "  AND MTL_STOCK.GOODSMAKERCDRF=MTL_TOTAL.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  AND MTL_STOCK.GOODSNORF=MTL_TOTAL.GOODSNORF" + Environment.NewLine;
                    // 2011/08/01 >>>
                    //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                    selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                    // 2011/08/01 <<<
                    selectTxt += "ON" + Environment.NewLine;
                    //------ DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    //selectTxt += "      SEC.ENTERPRISECODERF=MTL_STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    //selectTxt += "  AND SEC.SECTIONCODERF=MTL_STOCK.ADDUPSECCODERF" + Environment.NewLine;
                    //------ DEL END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    selectTxt += "      SEC.ENTERPRISECODERF=MTL_TOTAL.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  AND SEC.SECTIONCODERF=MTL_TOTAL.ADDUPSECCODERF" + Environment.NewLine;
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                    sqlCommand.CommandText = selectTxt;

                    //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                    sqlCommand.CommandTimeout = 3600;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader); // DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜
                        ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = CopyToShipGdsPrimeListResultWorkFromReader(ref myReader, shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv); // ADD 2015/05/08 �c���� �O���[�o���ϐ��̍폜

                        al.Add(wkShipGdsPrimeListResultWork);
                    }

                    if (!myReader.IsClosed) myReader.Close();
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="tblName">�e�[�u����</param>
        /// <returns>Where����������</returns>
        /// <br>Update Note: 2014/12/22 ������</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        private string MakeWhereStringPartner(ref SqlCommand sqlCommand, ShipGdsPrmListCndtnPartnerWork _shipGdsPrmListCndtnPartnerWork, ConstantManagement.LogicalMode logicalMode, string tblName)
        {
            string retstring = string.Empty;

            // 2011/08/01 >>>
            //retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS" + Environment.NewLine;
            retstring += "LEFT JOIN BLGOODSCDURF AS BLGDS WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "ON" + Environment.NewLine;
            retstring += "      BLGDS.ENTERPRISECODERF=" + tblName + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND BLGDS.BLGOODSCODERF=" + tblName + ".BLGOODSCODERF" + Environment.NewLine;

            #region WHERE���쐬
            retstring += "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += tblName + " .ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            if (tblName == "MTL1")
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_shipGdsPrmListCndtnPartnerWork.EnterpriseCode);
            }
            
            if (tblName == "MTL1")
            {
                retstring += " AND MTL1.RSLTTTLDIVCDRF=0" + Environment.NewLine;
            }
            else
            if (tblName == "MTL2")
            {
                retstring += " AND MTL2.RSLTTTLDIVCDRF=1" + Environment.NewLine;
            }

            //�v�㋒�_�R�[�h
            if (string.IsNullOrEmpty(_shipGdsPrmListCndtnPartnerWork.SectionCode) == false)
            {
                retstring += " AND " + tblName + ".ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(_shipGdsPrmListCndtnPartnerWork.SectionCode);
                }
            }

            //�J�n�N���x
            if (_shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth);
                }
            }

            //�I���N���x
            if (_shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND " + tblName + ".ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth);
                }
            }

            //���[�J�[�R�[�h
            if (_shipGdsPrmListCndtnPartnerWork.GoodsMakerCd != 0)
            {
                retstring += " AND " + tblName + ".GOODSMAKERCDRF=@STGOODSMAKERCD" + Environment.NewLine;
                if (tblName == "MTL1")
                {
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_shipGdsPrmListCndtnPartnerWork.GoodsMakerCd);
                }
            }

            //�i��
            if (string.IsNullOrEmpty(_shipGdsPrmListCndtnPartnerWork.GoodsNo) == false)
            {
                //retstring += " AND " + tblName + ".GOODSNORF=@GOODSNO" + Environment.NewLine;// DEL 2014/12/30 ������ FOR Redmine#44209����
                //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
                if (_shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                {
                    retstring += " AND (" + tblName + ".GOODSNORF=@GOODSNO" + Environment.NewLine;
                    retstring += " OR " + tblName + ".CHGSRCGOODSNORF=@GOODSNO)" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND " + tblName + ".GOODSNORF=@GOODSNO" + Environment.NewLine;
                }
                //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

                if (tblName == "MTL1")
                {
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(_shipGdsPrmListCndtnPartnerWork.GoodsNo);
                }
            }

            #endregion
            return retstring;
        }
        #endregion

        /// <summary>
        /// �N���X�i�[���� Reader �� SumCustStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsNoTtlDiv">�i�ԏW�v�敪</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// <br>UpdateNote : 2015/05/08 �c����</br>
        /// <br>�Ǘ��ԍ�  : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX �O���[�o���ϐ��̍폜</br>
        /// </remarks>
        //private ShipGdsPrimeListResultWork CopyToShipGdsPrimeListResultWorkFromReader(ref SqlDataReader myReader) // DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜
        private ShipGdsPrimeListResultWork CopyToShipGdsPrimeListResultWorkFromReader(ref SqlDataReader myReader, int goodsNoTtlDiv)// ADD 2015/05/08 �c���� �O���[�o���ϐ��̍폜
        {
            ShipGdsPrimeListResultWork wkShipGdsPrimeListResultWork = new ShipGdsPrimeListResultWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                wkShipGdsPrimeListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkShipGdsPrimeListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                wkShipGdsPrimeListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                wkShipGdsPrimeListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkShipGdsPrimeListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                //if (goodsNoSum) // DEL 2015/05/08 �c���� �O���[�o���ϐ��̍폜
                if (goodsNoTtlDiv == 1) // ADD 2015/05/08 �c���� �O���[�o���ϐ��̍폜
                {
                    wkShipGdsPrimeListResultWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                wkShipGdsPrimeListResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                wkShipGdsPrimeListResultWork.St_SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ST_SALESTIMESRF"));
                wkShipGdsPrimeListResultWork.St_TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ST_TOTALSALESCOUNTRF"));
                wkShipGdsPrimeListResultWork.St_SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_SALESMONEYRF"));
                wkShipGdsPrimeListResultWork.St_SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_SALESRETGOODSPRICERF"));
                wkShipGdsPrimeListResultWork.St_DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_DISCOUNTPRICERF"));
                wkShipGdsPrimeListResultWork.St_GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ST_GROSSPROFITRF"));
                wkShipGdsPrimeListResultWork.Or_SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OR_SALESTIMESRF"));
                wkShipGdsPrimeListResultWork.Or_TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("OR_TOTALSALESCOUNTRF"));
                wkShipGdsPrimeListResultWork.Or_SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_SALESMONEYRF"));
                wkShipGdsPrimeListResultWork.Or_SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_SALESRETGOODSPRICERF"));
                wkShipGdsPrimeListResultWork.Or_DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_DISCOUNTPRICERF"));
                wkShipGdsPrimeListResultWork.Or_GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OR_GROSSPROFITRF"));
                # endregion
            }

            return wkShipGdsPrimeListResultWork;
        }
    }
}

