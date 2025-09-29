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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����m�F�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����m�F�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20098�@�����@����</br>
    /// <br>Date       : 2007.03.19</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2007.10.18</br>
    /// <br>           : DC�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2007.11.07</br>
    /// <br>           : �[���ꏊ�Z������߂�l�ɒǉ�</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2008.03.21</br>
    /// <br>           : ���z���ڂ̍ŐV���C�A�E�g�Ή�</br>
    /// <br>           : (�c�������f�[�^�E����Œ����f�[�^�Ή�)</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2008.03.25</br>
    /// <br>           : �������Ӑ�̂ݐ�����(����͂�������)���擾</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�r�p�ɕύX UI�ł�SearchSlip�ASearchDetail���g�p</br>
    /// <br>Date       : 2008.07.01</br>
    /// <br>           : 20081 �D�c �E�l</br>
    /// <br></br>
    /// <br>Update Note: �`�[�^�C�v����̏ꍇ�ɓ��ꃌ�R�[�h���d���\�������G���[�Ή�</br>
    /// <br>Date       : 2008.09.17</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br></br>
    /// <br>Update Note: ���_�K�C�h���́ˋ��_�K�C�h���̂ɕύX</br>
    /// <br>Date       : 2008.10.08</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: ���o���ʃN���X�ւ̍��ڒǉ��Ή�</br>
    /// <br>Date       : 2008.10.28</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: ���o�s��C��</br>
    /// <br>Date       : 2008.11.04 2008.11.25</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: ���o�s��C��</br>
    /// <br>Date       : 2009/5/18</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: MANTIS�Ή�[11184]</br>
    /// <br>Date       : 2009/7/23</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br></br>
    /// <br>Update Note: MANTIS�Ή�[14013]</br>
    /// <br>Date       : 2009/08/10</br>
    /// <br>           : 22008 ���� ���n</br>
    /// <br></br>
    /// <br>Update Note: �[���w�������OR�����ɕύX</br>
    /// <br>           : �e���[���ȉ��A�e�����ȉ��A�ȏ�Ŏw��l���܂ނ悤�ɏC��</br>
    /// <br>           : ���ߍs�𒊏o���Ȃ��悤�ɏC��</br>
    /// <br>Date       : 2009/10/22</br>
    /// <br>           : 22008 ���� ���n</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>           : 22008 ���� ���n</br>
    /// <br></br>
    /// <br>Update Note: �e�����̎w������̕s��C��</br>
    /// <br>Date       : 2010/06/08</br>
    /// <br>           : 30517 �Ė� �x��</br>
    /// <br></br>
    /// <br>Update Note: Mantis.15691�@�Ԏ햼�̈󎚂��Ԏ�S�p���̂���Ԏ피�p���̂֕ύX����B</br>
    /// <br>Date       : 2010/06/29</br>
    /// <br>           : 30517 �Ė� �x��</br>
    /// <br></br>
    /// <br>Update Note: Mantis�y15806�z�i���ɕi���J�i���Z�b�g����悤�ɏC��</br>
    /// <br>Date       : 30531 2010/07/14</br>
    /// <br>           : 30531 ��� �r��</br>
    /// <br>Update Note: ���ׂɁu�����񓚁v�̒ǉ��Ή�</br>
    /// <br>Date       : 2011/07/18</br>
    /// <br>           : �{��</br>
    /// <br>Update Note: ��Q�� #8076����m�F�\/�����`�[�ƍ폜�`�[�̋�ʂɂ��Ă̑Ή�</br>
    /// <br>Date       : 2011/11/29</br>
    /// <br>           : ����</br>
    /// <br>Update Note: �Ǘ��ԍ� : 10904597-00 �쐬�S�� : �{�{ ����</br>
    /// <br>           : �C�����e : �����艿�󎚑Ή��̏�Q�Ή�</br>
    /// <br>Date       : 2014/04/17</br>
    /// <br></br>
    /// <br>Update Note: �u����`�[���́v�̓o�^�Ń^�C���A�E�g���o�����܂����̑Ή� for redmine #42684 </br>
    /// <br>Date       : 2014/05/29</br>
    /// <br>           : zhangwei</br>
    /// <br></br>
	/// <br>Update Note: 11570208-00 �y���ŗ��Ή� </br>
	/// <br>Date       : 2020/02/27</br>
    /// <br>           : 3H ����</br>
    /// <br></br>
    /// <br>Update Note: 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j </br>
    /// <br>Date       : 2022/09/05</br>
    /// <br>           : ���O </br>
    /// </remarks>
    [Serializable]
    public class SalesConfDB : RemoteDB, ISalesConfDB
    {
        /// <summary>
        /// ����m�F�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        public SalesConfDB()
            :
            base("MAHNB02356D", "Broadleaf.Application.Remoting.ParamData.SalesConfWork", "SALESCONFRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�
        /// </summary>
        /// <param name="salesConfWork">��������</param>
        /// <param name="parasalesConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        public int Search(out object salesConfWork, object parasalesConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesConfWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesConfProc(out salesConfWork, parasalesConfWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesConfDB.Search");
                salesConfWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̔���m�F�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objsalesConfWork">��������</param>
        /// <param name="parasalesConfWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchSalesConfProc(out object objsalesConfWork, object parasalesConfWork, ref SqlConnection sqlConnection)
        {
            SalesConfShWork salesconfshWork = null;

            ArrayList salesconfshWorkList = parasalesConfWork as ArrayList;
            ArrayList salesconfWorkList = new ArrayList();

            if (salesconfshWorkList == null)
            {
                salesconfshWork = parasalesConfWork as SalesConfShWork;
            }
            else
            {
                if (salesconfshWorkList.Count > 0)
                    salesconfshWork = salesconfshWorkList[0] as SalesConfShWork;
            }

            int status = SearchSalesConfProc(out salesconfWorkList, salesconfshWork, ref sqlConnection);
            objsalesConfWork = salesconfWorkList;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesconfWorkList">��������</param>
        /// <param name="salesconfShWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchSalesConfProc(out ArrayList salesconfWorkList, SalesConfShWork salesconfShWork, ref SqlConnection sqlConnection)
        {
            return SearchSalesConfProcProc(out salesconfWorkList, salesconfShWork, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesconfWorkList">��������</param>
        /// <param name="salesconfShWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        private int SearchSalesConfProcProc(out ArrayList salesconfWorkList, SalesConfShWork salesconfShWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string OrderbyStr = "";
            //bool isDetails; // 2008.07.01 del

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, salesconfShWork)
                                       + MakeWhereString(ref sqlCommand, salesconfShWork)
                                       + MakeGroupByString(ref sqlCommand, salesconfShWork)
                                       + OrderbyStr;
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();


                //isDetails = salesconfShWork.IsDetails; // 2008.07.01 del

                while (myReader.Read())
                {

                    //al.Add(CopyToSalesConfWorkFromReader(ref myReader, isDetails)); // 2008.07.01 del
                    al.Add(CopyToSalesConfWorkFromReader(ref myReader));              // 2008.07.01 add 

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

            salesconfWorkList = al;

            return status;
        }
        #endregion

        #region [SQL��������]
        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesconfShWork">���������i�[�N���X</param>
        /// <returns>����m�F�\��SQL������</returns>
        /// <br>Note       : ����m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, SalesConfShWork salesconfShWork)
        {
            // 2008.07.01 upd start ---------------------------------------------->>
            //string sqlstring = "";
            //if (salesconfShWork.IsDetails == false)
            //{
            //    //���ԒP��SELECT�̍쐬
            //    sqlstring = "SELECT "
            //         + "B.RESULTSADDUPSECCDRF SECTIONCODERF, "	//���_�R�[�h
            //         + "D.SECTIONGUIDENMRF SECTIONGUIDENMRF, "	//���_�K�C�h����
            //         + "B.SALESDATERF SALESDATERF, "	//������t
            //         + "A.SHIPMENTDAYRF SHIPMENTDAYRF, "	//�o�ד��t
            //         + "A.CUSTOMERCODERF CUSTOMERCODERF, "	//���Ӑ�R�[�h
            //         + "A.CUSTOMERNAMERF CUSTOMERNAMERF, "	//���Ӑ於��
            //         + "A.CUSTOMERNAME2RF CUSTOMERNAME2RF, "	//���Ӑ於��2
            //         + "B.SALESFORMCODERF SALESFORMCODERF, "	//�̔��`�ԃR�[�h
            //         + "B.SALESFORMNAMERF SALESFORMNAMERF, "	//�̔��`�Ԗ���
            //         + "B.GOODSCODERF GOODSCODERF, "	//���i�R�[�h
            //         + "B.GOODSNAMERF GOODSNAMERF, "	//���i����
            //         + "A.SALESSLIPNUMRF SALESSLIPNUMRF, "	//�󒍔ԍ�������`�[�ԍ��ɕύX�@2007/05/31
            //         + "B.SALESROWNORF SALESROWNORF, "	//����s�ԍ�
            //         + "A.DEBITNOTEDIVRF DEBITNOTEDIVRF, "	//�ԓ`�敪
            //         + "A.ACCRECDIVCDRF ACCRECDIVCDRF, "	//���|�敪
            //         + "B.CARRIERCODERF CARRIERCODERF, "	//�L�����A�R�[�h
            //         + "B.CARRIERNAMERF CARRIERNAMERF, "	//�L�����A����
            //         + "B.LARGEGOODSGANRECODERF LARGEGOODSGANRECODERF, "	//���i�啪�ރR�[�h
            //         + "B.LARGEGOODSGANRENAMERF LARGEGOODSGANRENAMERF, "	//���i�啪�ޖ���
            //         + "B.MEDIUMGOODSGANRECODERF MEDIUMGOODSGANRECODERF, "	//���i�����ރR�[�h
            //         + "B.MEDIUMGOODSGANRENAMERF MEDIUMGOODSGANRENAMERF, "	//���i�����ޖ���
            //         + "B.CELLPHONEMODELCODERF CELLPHONEMODELCODERF, "	//�@��R�[�h
            //         + "B.CELLPHONEMODELNAMERF CELLPHONEMODELNAMERF, "	//�@�햼��
            //         + "A.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, "	//�̔��]�ƈ��R�[�h
            //         + "A.SALESEMPLOYEENMRF SALESEMPLOYEENMRF, "	//�̔��]�ƈ�����
            //         + "C.PRODUCTNUMBER1RF PRODUCTNUMBER1RF, "	//�����ԍ�1
            //         + "C.PRODUCTNUMBER2RF PRODUCTNUMBER2RF, "	//�����ԍ�2
            //         + "C.STOCKTELNO1RF STOCKTELNO1RF, "	//���i�d�b�ԍ�1
            //         + "C.STOCKTELNO2RF STOCKTELNO2RF, "	//���i�d�b�ԍ�2
            //         + "C.SALESSLIPEXPNUMRF SALESSLIPEXPNUMRF, "	//����ڍהԍ�
            //         //+ "B.SALESCOUNTRF SALESCOUNTRF, "	//���㐔
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END) SALESCOUNTRF, "	//���㐔
            //         + "B.SALESUNITPRICETAXEXCRF SALESUNITPRICETAXEXCRF, "	//����P���i�Ŕ����j
            //         + "B.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, "	//������z�i�Ŕ����j
            //         + "B.COSTRF COSTRF, "	//����
            //         + "SUM(ISNULL(F.INCRECVTAXEXCRF,0)) INCENTIVERECVRF, "	//���C���Z���e�B�u
            //         + "SUM(ISNULL(E.INCDTBTTAXEXCRF,0)) INCENTIVEDTBTRF, "	//�x���C���Z���e�B�u
            //         + "A.SALESSLIPCDRF SALESSLIPCDRF "	//����`�[�敪
            //         + "FROM "
            //         + "(SALESSLIPRF A "	//����
            //         + "INNER JOIN SALESDETAILRF B "	//���㖾��
            //         + "ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.ACCEPTANORDERNORF = A.ACCEPTANORDERNORF) "
            //         + "INNER JOIN SECINFOSETRF D "	//���_�}�X�^
            //         + "ON (D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.RESULTSADDUPSECCDRF)) "
            //         + "LEFT JOIN SALESEXPLADATARF C "	//����ڍ�
            //         + "ON (C.ENTERPRISECODERF = B.ENTERPRISECODERF AND C.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND C.SALESROWNORF = B.SALESROWNORF) "
            //         + "LEFT JOIN INCDTBTRF E "	//�x���C���Z���e�B�u
            //         + "ON (E.ENTERPRISECODERF = B.ENTERPRISECODERF AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND E.SALESROWNORF = B.SALESROWNORF) "
            //         + "LEFT JOIN INCRECVRF F "	//���C���Z���e�B�u
            //         + "ON (F.ENTERPRISECODERF = B.ENTERPRISECODERF AND F.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND F.SALESROWNORF = B.SALESROWNORF) ";
            //     }
            //else {
            //    //���גP��SELECT�̍쐬
            //    sqlstring = "SELECT "
            //         + "B.RESULTSADDUPSECCDRF SECTIONCODERF, "	//���_�R�[�h
            //         + "D.SECTIONGUIDENMRF SECTIONGUIDENMRF, "	//���_�K�C�h����
            //         + "B.SALESDATERF SALESDATERF, "	//������t
            //         + "A.SHIPMENTDAYRF SHIPMENTDAYRF, "	//�o�ד��t
            //         + "A.CUSTOMERCODERF CUSTOMERCODERF, "	//���Ӑ�R�[�h
            //         + "A.CUSTOMERNAMERF CUSTOMERNAMERF, "	//���Ӑ於��
            //         + "A.CUSTOMERNAME2RF CUSTOMERNAME2RF, "	//���Ӑ於��2
            //         + "B.SALESFORMCODERF SALESFORMCODERF, "	//�̔��`�ԃR�[�h
            //         + "B.SALESFORMNAMERF SALESFORMNAMERF, "	//�̔��`�Ԗ���
            //         + "B.GOODSCODERF GOODSCODERF, "	//���i�R�[�h
            //         + "B.GOODSNAMERF GOODSNAMERF, "	//���i����
            //         + "A.SALESSLIPNUMRF SALESSLIPNUMRF, "	//�󒍔ԍ�������󒍔ԍ��ɕύX 2007/05/31
            //         + "B.SALESROWNORF SALESROWNORF, "	//����s�ԍ�
            //         + "A.DEBITNOTEDIVRF DEBITNOTEDIVRF, "	//�ԓ`�敪
            //         + "A.ACCRECDIVCDRF ACCRECDIVCDRF, "	//���|�敪
            //         + "B.CARRIERCODERF CARRIERCODERF, "	//�L�����A�R�[�h
            //         + "B.CARRIERNAMERF CARRIERNAMERF, "	//�L�����A����
            //         + "B.LARGEGOODSGANRECODERF LARGEGOODSGANRECODERF, "	//���i�啪�ރR�[�h
            //         + "B.LARGEGOODSGANRENAMERF LARGEGOODSGANRENAMERF, "	//���i�啪�ޖ���
            //         + "B.MEDIUMGOODSGANRECODERF MEDIUMGOODSGANRECODERF, "	//���i�����ރR�[�h
            //         + "B.MEDIUMGOODSGANRENAMERF MEDIUMGOODSGANRENAMERF, "	//���i�����ޖ���
            //         + "B.CELLPHONEMODELCODERF CELLPHONEMODELCODERF, "	//�@��R�[�h
            //         + "B.CELLPHONEMODELNAMERF CELLPHONEMODELNAMERF, "	//�@�햼��
            //         + "A.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, "	//�̔��]�ƈ��R�[�h
            //         + "A.SALESEMPLOYEENMRF SALESEMPLOYEENMRF, "	//�̔��]�ƈ�����
            //        //+ "B.SALESCOUNTRF SALESCOUNTRF, "	//���㐔
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END) SALESCOUNTRF, "	//���㐔
            //         + "B.SALESUNITPRICETAXEXCRF SALESUNITPRICETAXEXCRF, "	//����P���i�Ŕ����j
            //         + "B.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, "	//������z�i�Ŕ����j
            //         + "B.COSTRF COSTRF, "	//����
            //         + "SUM(ISNULL(F.INCRECVTAXEXCRF,0)) INCENTIVERECVRF, "	//���C���Z���e�B�u
            //         + "SUM(ISNULL(E.INCDTBTTAXEXCRF,0)) INCENTIVEDTBTRF, "	//�x���C���Z���e�B�u
            //         + "A.SALESSLIPCDRF SALESSLIPCDRF "	//����`�[�敪
            //         + "FROM "
            //         + "SALESSLIPRF A "	//����
            //         + "INNER JOIN SALESDETAILRF B "	//���㖾��
            //         + "ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.ACCEPTANORDERNORF = A.ACCEPTANORDERNORF) "
            //         + "INNER JOIN SECINFOSETRF D "	//���_�}�X�^
            //         + "ON (D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.RESULTSADDUPSECCDRF) "
            //         +"LEFT JOIN INCDTBTRF E "	//�x���C���Z���e�B�u
            //         + "ON (E.ENTERPRISECODERF = B.ENTERPRISECODERF AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND E.SALESROWNORF = B.SALESROWNORF) "
            //         +"LEFT JOIN INCRECVRF F "	//���C���Z���e�B�u
            //         + "ON (F.ENTERPRISECODERF = B.ENTERPRISECODERF AND F.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND F.SALESROWNORF = B.SALESROWNORF) ";
            //}
            string sqlstring = string.Empty;
            // 2008.07.01 upd end ------------------------------------------------<<

            return sqlstring;
        }
        #endregion

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesconfShWork">���������i�[�N���X</param>
        /// <returns>����m�F�\��SQL������</returns>
        /// <br>Note       : ����m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesConfShWork salesconfShWork)
        {
            //string wherestring = " ";
            //��{WHERE��̍쐬
            string wherestring = "WHERE ";

            //�Œ����
            //��ƃR�[�h
            wherestring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesconfShWork.EnterpriseCode);

            //�_���폜�敪
            wherestring += "AND A.LOGICALDELETECODERF=0 ";
            wherestring += "AND B.LOGICALDELETECODERF=0 ";

            //���ьv�㋒�_�R�[�h
            //if (salesconfShWork.IsSelectAllSection == false && salesconfShWork.IsOutputAllSecRec == false) // 2008.07.01 del
            if (salesconfShWork.IsSelectAllSection == false) // 2008.07.01 add
            {
                string sectionString = "";
                foreach (string sectionCode in salesconfShWork.ResultsAddUpSecList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    wherestring += "AND B.RESULTSADDUPSECCDRF IN (" + sectionString + ") ";
                }
            }


            //����`�[���(10:����,20:����,31:�ϑ��v��)
            wherestring += "AND A.SALESSLIPKINDRF IN (10,20,31) ";

            //�󒍃X�e�[�^�X(30�F����̂�)
            wherestring += "AND A.ACPTANODRSTATUSRF=30 ";

            //�T�[�r�X�`�[�敪(0�FOFF�̂�)
            wherestring += "AND A.SERVICESLIPCDRF=0 ";

            //������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //������t(�J�n)
            if (salesconfShWork.SalesDateSt != 0)
            {
                wherestring += "AND B.SALESDATERF>=@SALESDATEST ";
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesDateSt);
            }

            //������t(�I��)
            if (salesconfShWork.SalesDateEd != 0)
            {
                wherestring += "AND B.SALESDATERF<=@SALESDATEED ";
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesDateEd);
            }


            //�o�ד��t(�J�n)
            if (salesconfShWork.ShipmentDaySt != 0)
            {
                wherestring += "AND A.SHIPMENTDAYRF>=@SHIPMENTDAYST ";
                SqlParameter paraShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                paraShipmentDaySt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.ShipmentDaySt);
            }

            //�o�ד��t(�I��)
            if (salesconfShWork.ShipmentDayEd != 0)
            {
                wherestring += "AND A.SHIPMENTDAYRF<=@SHIPMENTDAYED ";
                SqlParameter paraShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                paraShipmentDayEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.ShipmentDayEd);
            }

            // �� 2007.10.18 980081 d
            ////�L�����A�R�[�h
            //if (salesconfShWork.IsSelectAllCarrier == false)
            //{
            //    string carrierString = "";
            //    foreach (int carrierCode in salesconfShWork.CarrierCodeList)
            //    {
            //        if (carrierCode != 0)
            //        {
            //            if (carrierString != "") carrierString += ",";
            //            carrierString += carrierCode.ToString();
            //        }
            //    }
            //    if (carrierString != "")
            //    {
            //        wherestring += "AND B.CARRIERCODERF IN (" + carrierString + ") ";
            //    }
            //}
            // �� 2007.10.18 980081 d

            //���Ӑ�R�[�h(�J�n)
            if (salesconfShWork.CustomerCodeSt != 0)
            {
                wherestring += "AND A.CUSTOMERCODERF>=@CUSTOMERCODEST ";
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.CustomerCodeSt);
            }

            //���Ӑ�R�[�h(�I��)
            if (salesconfShWork.CustomerCodeEd != 0)
            {
                wherestring += "AND A.CUSTOMERCODERF<=@CUSTOMERCODEED ";
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.CustomerCodeEd);
            }

            //�ԓ`�敪
            if (salesconfShWork.DebitNoteDiv != -1)
            {
                wherestring += "AND A.DEBITNOTEDIVRF=@DEBITNOTEDIV ";
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.DebitNoteDiv);
            }

            //����`�[�敪
            if (salesconfShWork.SalesSlipCd != -1)
            {
                wherestring += "AND A.SALESSLIPCDRF=@SALESSLIPCD ";
                SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesSlipCd);
            }

            // �� 2007.10.18 980081 d
            #region �����C�A�E�g(�R�����g�A�E�g)
            ////����`��
            //string salesFormalString = "";
            //foreach (int salesFormalCode in salesconfShWork.SalesFormal)
            //{
            //    if (salesFormalCode != 0)
            //    {
            //        if (salesFormalString != "") salesFormalString += ",";
            //        salesFormalString += salesFormalCode.ToString();
            //    }
            //}
            //if (salesFormalString != "")
            //{
            //    wherestring += "AND A.SALESFORMALRF IN (" + salesFormalString + ") ";
            //}
            //
            ////�̔��`�ԃR�[�h
            //string salesFormCodeString = "";
            //if (salesconfShWork.SalesFormCode != null)
            //{
            //    foreach (int salesFormCode in salesconfShWork.SalesFormCode)
            //    {
            //        if (salesFormCode != 0)
            //        {
            //            if (salesFormCodeString != "") salesFormCodeString += ",";
            //            salesFormCodeString += salesFormCode.ToString();
            //        }
            //    }
            //    if (salesFormCodeString != "")
            //    {
            //        wherestring += "AND B.SALESFORMCODERF IN (" + salesFormCodeString + ") ";
            //    }
            //
            //}
            // �� 2007.10.18 980081 d

            ////�̔��`�ԃR�[�h(�J�n)
            //if (salesconfShWork.SalesFormCodeSt != 0)
            //{
            //    wherestring += "AND B.SALESFORMCODERF>=@SALESFORMCODEST ";
            //    SqlParameter paraSalesFormCodeSt = sqlCommand.Parameters.Add("@SALESFORMCODEST", SqlDbType.Int);
            //    paraSalesFormCodeSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesFormCodeSt);
            //}

            ////�̔��`�ԃR�[�h(�I��)
            //if (salesconfShWork.SalesFormCodeEd != 0)
            //{
            //    wherestring += "AND B.SALESFORMCODERF<=@SALESFORMCODEED ";
            //    SqlParameter paraSalesFormCodeEd = sqlCommand.Parameters.Add("@SALESFORMCODEED", SqlDbType.Int);
            //    paraSalesFormCodeEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesFormCodeEd);
            //}

            // �� 2007.10.18 980081 d
            ////���i�啪�ރR�[�h(�J�n)
            //if (salesconfShWork.LargeGoodsGanreCdSt != "")
            //{
            //    wherestring += "AND B.LARGEGOODSGANRECODERF>=@LARGEGOODSGANRECDST ";
            //    SqlParameter paraLargeGoodsGanreCdSt = sqlCommand.Parameters.Add("@LARGEGOODSGANRECDST", SqlDbType.NChar);
            //    paraLargeGoodsGanreCdSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.LargeGoodsGanreCdSt);
            //}
            //
            ////���i�啪�ރR�[�h(�I��)
            //if (salesconfShWork.LargeGoodsGanreCdEd != "")
            //{
            //    wherestring += "AND B.LARGEGOODSGANRECODERF<=@LARGEGOODSGANRECDED ";
            //    SqlParameter paraLargeGoodsGanreCdEd = sqlCommand.Parameters.Add("@LARGEGOODSGANRECDED", SqlDbType.NChar);
            //    paraLargeGoodsGanreCdEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.LargeGoodsGanreCdEd);
            //}
            //
            ////���i�����ރR�[�h(�J�n)
            //if (salesconfShWork.MediumGoodsGanreCdSt != "")
            //{
            //    wherestring += "AND B.MEDIUMGOODSGANRECODERF>=@MEDIUMGOODSGANRECDST ";
            //    SqlParameter paraMediumGoodsGanreCdSt = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECDST", SqlDbType.NChar);
            //    paraMediumGoodsGanreCdSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.MediumGoodsGanreCdSt);
            //}
            //
            ////���i�����ރR�[�h(�I��)
            //if (salesconfShWork.MediumGoodsGanreCdEd != "")
            //{
            //    wherestring += "AND B.MEDIUMGOODSGANRECODERF<=@MEDIUMGOODSGANRECDED ";
            //    SqlParameter paraMediumGoodsGanreCdEd = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECDED", SqlDbType.NChar);
            //    paraMediumGoodsGanreCdEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.MediumGoodsGanreCdEd);
            //}
            //
            ////���i�R�[�h(�J�n)
            //if (salesconfShWork.GoodsCodeSt != "")
            //{
            //    wherestring += "AND B.GOODSCODERF>=@GOODSCODEST ";
            //    SqlParameter paraGoodsCodeSt = sqlCommand.Parameters.Add("@GOODSCODEST", SqlDbType.NVarChar);
            //    paraGoodsCodeSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.GoodsCodeSt);
            //}
            //
            ////���i�R�[�h(�I��)
            //if (salesconfShWork.GoodsCodeEd != "")
            //{
            //    wherestring += "AND B.GOODSCODERF<=@GOODSCODEED ";
            //    SqlParameter paraGoodsCodeEd = sqlCommand.Parameters.Add("@GOODSCODEED", SqlDbType.NVarChar);
            //    paraGoodsCodeEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.GoodsCodeEd);
            //}
            #endregion
            // �� 2007.10.18 980081 d

            //�󒍔ԍ�(�J�n)������`�[�ԍ��ɕύX
            if (salesconfShWork.SalesSlipNumSt != "")
            {
                wherestring += "AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST ";
                SqlParameter paraAcceptAnOrderNoSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraAcceptAnOrderNoSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesSlipNumSt);
            }

            //�󒍔ԍ�(�I��)������`�[�ԍ��ɕύX
            if (salesconfShWork.SalesSlipNumEd != "")
            {
                wherestring += "AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED ";
                SqlParameter paraAcceptAnOrderNoEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraAcceptAnOrderNoEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesSlipNumEd);
            }

            // �� 2007.10.18 980081 d
            ////�@��R�[�h(�J�n)
            //if (salesconfShWork.CellphoneModelCodeSt != "")
            //{
            //    wherestring += "AND B.CELLPHONEMODELCODERF>=@CELLPHONEMODELCODEST ";
            //    SqlParameter paraCellphoneModelCodeSt = sqlCommand.Parameters.Add("@CELLPHONEMODELCODEST", SqlDbType.NVarChar);
            //    paraCellphoneModelCodeSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.CellphoneModelCodeSt);
            //}
            //
            ////�@��R�[�h(�I��)
            //if (salesconfShWork.CellphoneModelCodeEd != "")
            //{
            //    wherestring += "AND B.CELLPHONEMODELCODERF<=@CELLPHONEMODELCODEED ";
            //    SqlParameter paraCellphoneModelCodeEd = sqlCommand.Parameters.Add("@CELLPHONEMODELCODEED", SqlDbType.NVarChar);
            //    paraCellphoneModelCodeEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.CellphoneModelCodeEd);
            //}
            // �� 2007.10.18 980081 d

            //�̔��]�ƈ��R�[�h(�J�n)
            if (salesconfShWork.SalesEmployeeCdSt != "")
            {
                wherestring += "AND A.SALESEMPLOYEECDRF>=@SALESEMPLOYEECDST ";
                SqlParameter paraSalesEmployeeCdSt = sqlCommand.Parameters.Add("@SALESEMPLOYEECDST", SqlDbType.NVarChar);
                paraSalesEmployeeCdSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesEmployeeCdSt);
            }

            //�̔��]�ƈ��R�[�h(�I��)
            if (salesconfShWork.SalesEmployeeCdEd != "")
            {
                wherestring += "AND A.SALESEMPLOYEECDRF<=@SALESEMPLOYEECDED ";
                SqlParameter paraSalesEmployeeCdEd = sqlCommand.Parameters.Add("@SALESEMPLOYEECDED", SqlDbType.NVarChar);
                paraSalesEmployeeCdEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesEmployeeCdEd);
            }

            //�d����R�[�h(�J�n)
            if (salesconfShWork.SupplierCdSt != 0)
            {
                wherestring += "AND B.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SupplierCdSt);
            }

            //�d����R�[�h(�I��)
            if (salesconfShWork.SupplierCdEd != 0)
            {
                wherestring += "AND B.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SupplierCdEd);
            }
            //����݌Ɏ�񂹋敪
            if (salesconfShWork.SalesOrderDivCd != -1)
            {
                wherestring += "AND B.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesOrderDivCd);
            }
            //�������@�敪
            if (salesconfShWork.WayToOrder != -1)
            {
                wherestring += "AND B.WAYTOORDERRF=@WAYTOORDER ";
                SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.WayToOrder);
            }
            //����`�[�敪 2:�ԕi�E�l��
            if (salesconfShWork.SalesSlipCd == 2)
            {
                wherestring += "AND (A.SALESSLIPCDRF=1 OR (A.SALESSLIPCDRF=0 AND B.SALESSLIPCDDTLRF = 2 ))";
            }


            return wherestring;
        }
        #endregion


        #region [GROUP BY�吶������]
        /// <summary>
        /// GROUP BY�吶��
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesconfShWork">���������i�[�N���X</param>
        /// <returns>����m�F�\��SQL������</returns>
        /// <br>Note       : ����m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        private string MakeGroupByString(ref SqlCommand sqlCommand, SalesConfShWork salesconfShWork)
        {
            // 2008.07.01 upd start ----------------------------------------->>
            //string sqlstring = "";
            //if (salesconfShWork.IsDetails == false)
            //{
            //    //���ԒP��GROUP BY��̍쐬
            //    sqlstring = " GROUP BY "
            //         + "B.RESULTSADDUPSECCDRF, "	//���_�R�[�h
            //         + "D.SECTIONGUIDENMRF, "	//���_�K�C�h����
            //         + "B.SALESDATERF, "	//������t
            //         + "A.SHIPMENTDAYRF, "	//�o�ד��t
            //         + "A.CUSTOMERCODERF, "	//���Ӑ�R�[�h
            //         + "A.CUSTOMERNAMERF, "	//���Ӑ於��
            //         + "A.CUSTOMERNAME2RF, "	//���Ӑ於��2
            //         + "B.SALESFORMCODERF, "	//�̔��`�ԃR�[�h
            //         + "B.SALESFORMNAMERF, "	//�̔��`�Ԗ���
            //         + "B.GOODSCODERF, "	//���i�R�[�h
            //         + "B.GOODSNAMERF, "	//���i����
            //         + "A.SALESSLIPNUMRF, "	//�󒍔ԍ� ���@����`�[�ԍ��ɕύX
            //         + "B.SALESROWNORF, "	//����s�ԍ�
            //         + "A.DEBITNOTEDIVRF, "	//�ԓ`�敪
            //         + "A.ACCRECDIVCDRF, "	//���|�敪
            //         + "B.CARRIERCODERF, "	//�L�����A�R�[�h
            //         + "B.CARRIERNAMERF, "	//�L�����A����
            //         + "B.LARGEGOODSGANRECODERF, "	//���i�啪�ރR�[�h
            //         + "B.LARGEGOODSGANRENAMERF, "	//���i�啪�ޖ���
            //         + "B.MEDIUMGOODSGANRECODERF, "	//���i�����ރR�[�h
            //         + "B.MEDIUMGOODSGANRENAMERF, "	//���i�����ޖ���
            //         + "B.CELLPHONEMODELCODERF, "	//�@��R�[�h
            //         + "B.CELLPHONEMODELNAMERF, "	//�@�햼��
            //         + "A.SALESEMPLOYEECDRF, "	//�̔��]�ƈ��R�[�h
            //         + "A.SALESEMPLOYEENMRF, "	//�̔��]�ƈ�����
            //         + "C.PRODUCTNUMBER1RF, "	//�����ԍ�1
            //         + "C.PRODUCTNUMBER2RF, "	//�����ԍ�2
            //         + "C.STOCKTELNO1RF, "	//���i�d�b�ԍ�1
            //         + "C.STOCKTELNO2RF, "	//���i�d�b�ԍ�2
            //         + "C.SALESSLIPEXPNUMRF, "	//����ڍהԍ�
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END), "	//���㐔
            //         + "B.SALESUNITPRICETAXEXCRF, "	//����P���i�Ŕ����j
            //         + "B.SALESMONEYTAXEXCRF, "	//������z�i�Ŕ����j
            //         + "B.COSTRF, "	//����
            //         + "A.SALESSLIPCDRF ";	//����`�[�敪
            //}
            //else
            //{
            //    //���גP��GROUP BY��̍쐬
            //    sqlstring = " GROUP BY "
            //         + "B.RESULTSADDUPSECCDRF, "	//���_�R�[�h
            //         + "D.SECTIONGUIDENMRF, "	//���_�K�C�h����
            //         + "B.SALESDATERF, "	//������t
            //         + "A.SHIPMENTDAYRF, "	//�o�ד��t
            //         + "A.CUSTOMERCODERF, "	//���Ӑ�R�[�h
            //         + "A.CUSTOMERNAMERF, "	//���Ӑ於��
            //         + "A.CUSTOMERNAME2RF, "	//���Ӑ於��2
            //         + "B.SALESFORMCODERF, "	//�̔��`�ԃR�[�h
            //         + "B.SALESFORMNAMERF, "	//�̔��`�Ԗ���
            //         + "B.GOODSCODERF, "	//���i�R�[�h
            //         + "B.GOODSNAMERF, "	//���i����
            //         + "A.SALESSLIPNUMRF, "	//�󒍔ԍ� ���@����`�[�ԍ��ɕύX
            //         + "B.SALESROWNORF, "	//����s�ԍ�
            //         + "A.DEBITNOTEDIVRF, "	//�ԓ`�敪
            //         + "A.ACCRECDIVCDRF, "	//���|�敪
            //         + "B.CARRIERCODERF, "	//�L�����A�R�[�h
            //         + "B.CARRIERNAMERF, "	//�L�����A����
            //         + "B.LARGEGOODSGANRECODERF, "	//���i�啪�ރR�[�h
            //         + "B.LARGEGOODSGANRENAMERF, "	//���i�啪�ޖ���
            //         + "B.MEDIUMGOODSGANRECODERF, "	//���i�����ރR�[�h
            //         + "B.MEDIUMGOODSGANRENAMERF, "	//���i�����ޖ���
            //         + "B.CELLPHONEMODELCODERF, "	//�@��R�[�h
            //         + "B.CELLPHONEMODELNAMERF, "	//�@�햼��
            //         + "A.SALESEMPLOYEECDRF, "	//�̔��]�ƈ��R�[�h
            //         + "A.SALESEMPLOYEENMRF, "	//�̔��]�ƈ�����
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END), "	//���㐔
            //         + "B.SALESUNITPRICETAXEXCRF, "	//����P���i�Ŕ����j
            //         + "B.SALESMONEYTAXEXCRF, "	//������z�i�Ŕ����j
            //         + "B.COSTRF, "	//����
            //         + "A.SALESSLIPCDRF ";	//����`�[�敪
            //}
            string sqlstring = string.Empty;
            // 2008.07.01 upd end -------------------------------------------<<

            return sqlstring;
        }
        #endregion


        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        //private SalesConfWork CopyToSalesConfWorkFromReader(ref SqlDataReader myReader, bool isDetails) // 2008.07.01 del
        private SalesConfWork CopyToSalesConfWorkFromReader(ref SqlDataReader myReader)                   // 2008.07.01 add
        {
            SalesConfWork wkSalesConfWork = new SalesConfWork();

            #region �N���X�֊i�[
            wkSalesConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  //2008.10.08 DEL
            wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));   //2008.10.08 ADD
            wkSalesConfWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkSalesConfWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            wkSalesConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // �� 2007.10.18 980081 d
            //wkSalesConfWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            //wkSalesConfWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            //wkSalesConfWork.SalesFormCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESFORMCODERF"));
            //wkSalesConfWork.SalesFormName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESFORMNAMERF"));
            //wkSalesConfWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
            // �� 2007.10.18 980081 d
            wkSalesConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkSalesConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            //wkSalesConfWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF")); // 2008.07.01 del
            //wkSalesConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF")); // 2008.07.01 del
            wkSalesConfWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            // �� 2007.10.18 980081 d
            //wkSalesConfWork.CarrierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCODERF"));
            //wkSalesConfWork.CarrierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARRIERNAMERF"));
            //wkSalesConfWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkSalesConfWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkSalesConfWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkSalesConfWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkSalesConfWork.CellphoneModelCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELCODERF"));
            //wkSalesConfWork.CellphoneModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELNAMERF"));
            // �� 2007.10.18 980081 d
            wkSalesConfWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            wkSalesConfWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));

            // �� 2007.10.18 980081 d
            //if (isDetails == false)
            //{
            //    wkSalesConfWork.ProductNumber1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTNUMBER1RF"));
            //    wkSalesConfWork.ProductNumber2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTNUMBER2RF"));
            //    wkSalesConfWork.StockTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKTELNO1RF"));
            //    wkSalesConfWork.StockTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKTELNO2RF"));
            //    wkSalesConfWork.SalesSlipExpNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPEXPNUMRF"));
            //}
            // �� 2007.10.18 980081 d

            // �� 2007.10.18 980081 d
            //wkSalesConfWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
            //wkSalesConfWork.SalesUnitPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESUNITPRICETAXEXCRF"));
            // �� 2007.10.18 980081 d
            wkSalesConfWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            wkSalesConfWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
            wkSalesConfWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            // �� 2007.10.18 980081 d
            //wkSalesConfWork.IncentiveRecv = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCENTIVERECVRF"));
            //wkSalesConfWork.IncentiveDtbt = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCENTIVEDTBTRF"));
            // �� 2007.10.18 980081 d
            #endregion

            return wkSalesConfWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098�@�����@����</br>
        /// <br>Date       : 2007.03.19</br>
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
        
        // �� 2007.10.18 980081 a
        #region ����m�F�\(���v)�E����m�F�\(����)�Ή�
        /// <summary>
        /// �w�肳�ꂽ�����̔���m�F�\(���v)LIST��߂��܂�
        /// </summary>
        /// <param name="salesConfWork">��������</param>
        /// <param name="paraSalesConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\(���v)LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchSlip(out object salesConfWork, object paraSalesConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesConfWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesSlipConfProc(out salesConfWork, paraSalesConfWork, ref sqlConnection, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesConfDB.SearchSlip");
                salesConfWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̔���m�F�\(����)LIST��߂��܂�
        /// </summary>
        /// <param name="salesConfWork">��������</param>
        /// <param name="paraSalesConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\(����)LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchDetail(out object salesConfWork, object paraSalesConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesConfWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesSlipConfProc(out salesConfWork, paraSalesConfWork, ref sqlConnection, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesConfDB.SearchDetail");
                salesConfWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̔���m�F�\LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesConfWork">��������</param>
        /// <param name="paraSalesConfWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchSalesSlipConfProc(out object objSalesConfWork, object paraSalesConfWork, ref SqlConnection sqlConnection, int printMode)
        {
            SalesConfShWork salesConfShWork = null;

            ArrayList salesConfShWorkList = paraSalesConfWork as ArrayList;
            ArrayList salesConfWorkList = new ArrayList();

            if (salesConfShWorkList == null)
            {
                salesConfShWork = paraSalesConfWork as SalesConfShWork;
            }
            else
            {
                if (salesConfShWorkList.Count > 0)
                    salesConfShWork = salesConfShWorkList[0] as SalesConfShWork;
            }

            int status = SearchSalesSlipConfProc(out salesConfWorkList, salesConfShWork, ref sqlConnection, printMode);
            objSalesConfWork = salesConfWorkList;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̔���m�F�\(���v)LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesConfWorkList">��������</param>
        /// <param name="salesConfShWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���m�F�\(���v)LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchSalesSlipConfProc(out ArrayList salesConfWorkList, SalesConfShWork salesConfShWork, ref SqlConnection sqlConnection, int printMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectStringSlip(ref sqlCommand, salesConfShWork, printMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSalesSlipConfWorkFromReader(ref myReader, salesConfShWork, printMode));

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

            salesConfWorkList = al;

            return status;
        }

        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesConfShWork">���������i�[�N���X</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>����m�F�\��SQL������</returns>
        /// <br>Note       : ����m�F�\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Note       : �u����`�[���́v�̓o�^�Ń^�C���A�E�g���o�����܂��� for redmine #42684 </br>
        /// <br>Programmer : zhangwei</br>
        /// <br>Date       : 2014/05/29</br>
        /// <br>Note       : �y���ŗ��Ή� </br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        private string MakeSelectStringSlip(ref SqlCommand sqlCommand, SalesConfShWork salesConfShWork, int printMode)
        {
            #region Select��
            string sqlString = "";

            // 2008.07.01 upd start ------------------------------------------------->>
            #region 2008.07.01 DEL
            //if (printMode == 0)
            //{
            //    sqlString = "SELECT A.SECTIONCODERF, "
            //                     + "C.SECTIONGUIDENMRF, "
            //                     + "A.SUBSECTIONCODERF, "
            //                     + "D.SUBSECTIONNAMERF, "
            //                     + "A.MINSECTIONCODERF, "
            //                     + "E.MINSECTIONNAMERF, "
            //                     + "A.CUSTOMERCODERF, "
            //                     // �� 2008.03.25 980081 c
            //                     //+ "A.CUSTOMERSNMRF, "
            //                     + "CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF, "
            //                     // �� 2008.03.25 980081 c
            //                     + "A.SALESAREACODERF, "
            //                     + "A.SALESAREANAMERF, "
            //                     + "A.CLAIMCODERF, "
            //                     + "A.CLAIMSNMRF, "
            //                     + "A.ADDRESSEECODERF, "
            //                     + "A.ADDRESSEENAMERF, "
            //                     + "A.ADDRESSEENAME2RF, "
            //                     //+ "A.ADDRESSEEPOSTNORF, "
            //                     + "A.ADDRESSEEADDR1RF, "
            //                     + "A.ADDRESSEEADDR2RF, "
            //                     + "A.ADDRESSEEADDR3RF, "
            //                     + "A.ADDRESSEEADDR4RF, "
            //                     + "A.SALESINPUTCODERF, "
            //                     + "A.SALESINPUTNAMERF, "
            //                     + "A.FRONTEMPLOYEECDRF, "
            //                     + "A.FRONTEMPLOYEENMRF, "
            //                     + "A.SALESEMPLOYEECDRF, "
            //                     + "A.SALESEMPLOYEENMRF, "
            //                     + "A.ACPTANODRSTATUSRF, "
            //                     + "A.SALESSLIPNUMRF, "
            //                     + "A.DEBITNOTEDIVRF, "
            //                     + "A.SALESSLIPCDRF, "
            //                     + "A.SALESGOODSCDRF, "
            //                     + "A.ACCRECDIVCDRF, "
            //                     + "A.SEARCHSLIPDATERF, "
            //                     + "A.SHIPMENTDAYRF, "
            //                     + "A.SALESDATERF, "
            //                     + "A.ADDUPADATERF, "
            //                     + "A.DELAYPAYMENTDIVRF, "
            //                     + "A.PARTYSALESLIPNUMRF, "
            //                     + "A.SALESTOTALTAXEXCRF, "
            //                     + "A.SALESTOTALTAXINCRF, "
            //                     + "A.SALESDISTTLTAXEXCRF, "
            //                     + "A.SALESDISTTLTAXINCLURF, "
            //                     + "A.TOTALCOSTRF, "
            //                     // �� 2008.03.21 980081 a
            //                     + "A.SALESSUBTOTALTAXINCRF, "
            //                     + "A.SALESSUBTOTALTAXEXCRF, "
            //                     + "A.SALSENETPRICERF, "
            //                     + "A.SALESSUBTOTALTAXRF, "
            //                     + "A.ITDEDSALESOUTTAXRF, "
            //                     + "A.ITDEDSALESINTAXRF, "
            //                     + "A.SALSUBTTLSUBTOTAXFRERF, "
            //                     + "A.SALSEOUTTAXRF, "
            //                     + "A.SALAMNTCONSTAXINCLURF, "
            //                     + "A.ITDEDSALESDISOUTTAXRF, "
            //                     + "A.ITDEDSALESDISINTAXRF, "
            //                     + "A.ITDEDSALSEDISTAXFRERF, "
            //                     + "A.SALESDISOUTTAXRF, "
            //                     + "A.TOTALCOSTRF, "
            //                     // �� 2008.03.21 980081 a
            //                     + "A.SLIPNOTERF "
            //                     + "FROM SALESHISTORYRF A "
            //                     + "LEFT JOIN SECINFOSETRF C ON(C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.SECTIONCODERF = A.SECTIONCODERF) "
            //                     + "LEFT JOIN SUBSECTIONRF D ON(D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.SECTIONCODERF AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF) "
            //                     + "LEFT JOIN MINSECTIONRF E ON(E.ENTERPRISECODERF = A.ENTERPRISECODERF AND E.SECTIONCODERF = A.SECTIONCODERF AND E.SUBSECTIONCODERF = A.SUBSECTIONCODERF AND E.MINSECTIONCODERF = A.MINSECTIONCODERF) ";
            //}
            //else if (printMode == 1)
            //{
            //    sqlString = "SELECT A.SECTIONCODERF, "
            //                     + "C.SECTIONGUIDENMRF, "
            //                     + "A.SUBSECTIONCODERF, "
            //                     + "D.SUBSECTIONNAMERF, "
            //                     + "A.MINSECTIONCODERF, "
            //                     + "E.MINSECTIONNAMERF, "
            //                     + "A.CUSTOMERCODERF, "
            //                     // �� 2008.03.25 980081 c
            //                     //+ "A.CUSTOMERSNMRF, "
            //                     + "CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF, "
            //                     // �� 2008.03.25 980081 c
            //                     + "A.SALESAREACODERF, "
            //                     + "A.SALESAREANAMERF, "
            //                     + "A.CLAIMCODERF, "
            //                     + "A.CLAIMSNMRF, "
            //                     + "A.ADDRESSEECODERF, "
            //                     + "A.ADDRESSEENAMERF, "
            //                     + "A.ADDRESSEENAME2RF, "
            //                     //+ "A.ADDRESSEEPOSTNORF, "
            //                     + "A.ADDRESSEEADDR1RF, "
            //                     + "A.ADDRESSEEADDR2RF, "
            //                     + "A.ADDRESSEEADDR3RF, "
            //                     + "A.ADDRESSEEADDR4RF, "
            //                     + "A.SALESINPUTCODERF, "
            //                     + "A.SALESINPUTNAMERF, "
            //                     + "A.FRONTEMPLOYEECDRF, "
            //                     + "A.FRONTEMPLOYEENMRF, "
            //                     + "A.SALESEMPLOYEECDRF, "
            //                     + "A.SALESEMPLOYEENMRF, "
            //                     + "A.ACPTANODRSTATUSRF, "
            //                     + "A.SALESSLIPNUMRF, "
            //                     + "A.DEBITNOTEDIVRF, "
            //                     + "A.SALESSLIPCDRF, "
            //                     + "A.SALESGOODSCDRF, "
            //                     + "A.ACCRECDIVCDRF, "
            //                     + "A.SEARCHSLIPDATERF, "
            //                     + "A.SHIPMENTDAYRF, "
            //                     + "A.SALESDATERF, "
            //                     + "A.ADDUPADATERF, "
            //                     + "A.DELAYPAYMENTDIVRF, "
            //                     + "A.PARTYSALESLIPNUMRF, "
            //                     + "A.SALESTOTALTAXEXCRF, "
            //                     + "A.SALESTOTALTAXINCRF, "
            //                     + "A.SALESDISTTLTAXEXCRF, "
            //                     + "A.SALESDISTTLTAXINCLURF, "
            //                     + "A.TOTALCOSTRF, "
            //                     + "A.SLIPNOTERF, "
            //                     // �� 2008.03.21 980081 a
            //                     + "A.SALESSUBTOTALTAXINCRF, "
            //                     + "A.SALESSUBTOTALTAXEXCRF, "
            //                     + "A.SALSENETPRICERF, "
            //                     + "A.SALESSUBTOTALTAXRF, "
            //                     + "A.ITDEDSALESOUTTAXRF, "
            //                     + "A.ITDEDSALESINTAXRF, "
            //                     + "A.SALSUBTTLSUBTOTAXFRERF, "
            //                     + "A.SALSEOUTTAXRF, "
            //                     + "A.SALAMNTCONSTAXINCLURF, "
            //                     + "A.ITDEDSALESDISOUTTAXRF, "
            //                     + "A.ITDEDSALESDISINTAXRF, "
            //                     + "A.ITDEDSALSEDISTAXFRERF, "
            //                     + "A.SALESDISOUTTAXRF, "
            //                     + "A.TOTALCOSTRF, "
            //                     + "B.SALSEPRICECONSTAXRF, "
            //                     // �� 2008.03.21 980081 a
            //                     + "B.SALESROWNORF, "
            //                     + "B.SALESSLIPCDDTLRF, "
            //                     + "B.GOODSMAKERCDRF, "
            //                     + "B.MAKERNAMERF, "
            //                     + "B.GOODSNORF, "
            //                     + "B.GOODSNAMERF, "
            //                     + "B.UNITCODERF, "
            //                     + "B.UNITNAMERF, "
            //                     + "B.SHIPMENTCNTRF, "
            //                     + "B.STDUNPRCSALUNPRCRF, "
            //                     + "B.SALESUNPRCTAXINCFLRF, "
            //                     + "B.SALESUNPRCTAXEXCFLRF, "
            //                     + "B.SALESMONEYTAXINCRF, "
            //                     + "B.SALESMONEYTAXEXCRF, "
            //                     + "B.SALESUNITCOSTRF, "
            //                     + "B.COSTRF, "
            //                     + "B.WAREHOUSECODERF, "
            //                     + "B.WAREHOUSENAMERF, "
            //                     + "B.SUPPLIERCDRF, "
            //                     + "B.SUPPLIERSNMRF, "
            //                     + "B.PARTYSLIPNUMDTLRF, "
            //                     + "B.DTLNOTERF "
            //                     + "FROM SALESHISTORYRF A "
            //                     + "INNER JOIN SALESHISTDTLRF B ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF) "
            //                     + "LEFT JOIN SECINFOSETRF C ON(C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.SECTIONCODERF = A.SECTIONCODERF) "
            //                     + "LEFT JOIN SUBSECTIONRF D ON(D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.SECTIONCODERF AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF) "
            //                     + "LEFT JOIN MINSECTIONRF E ON(E.ENTERPRISECODERF = A.ENTERPRISECODERF AND E.SECTIONCODERF = A.SECTIONCODERF AND E.SUBSECTIONCODERF = A.SUBSECTIONCODERF AND E.MINSECTIONCODERF = A.MINSECTIONCODERF) ";
            //}
            #endregion

            if (printMode == 0)
            {
                //sqlString += "SELECT " + Environment.NewLine;        //2008.09.17 DEL
                sqlString += "SELECT DISTINCT" + Environment.NewLine;  //2008.09.17 ADD
                // �C�� 2009/05/18 >>>
                //sqlString += "     A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "     A.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine; 
                // �C�� 2009/05/18 <<<
                //sqlString += "    ,C.SECTIONGUIDENMRF" + Environment.NewLine;  // 2008.10.08 DEL
                sqlString += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;   // 2008.10.08 ADD

                sqlString += "    ,A.LOGICALDELETECODERF" + Environment.NewLine; // --- ADD  ����  2010/11/29

                sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONDIVRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONRF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += "    ,A.CONSTAXRATERF" + Environment.NewLine; // ����Őŗ�   // ADD 3H ���� 2020/02/27
                // �C�� 2009/04/21 >>>
                //sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,E.SALESDISTTLTAXEXCGOODS AS SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXEXCRF - E.SALESDISTTLTAXEXCGYO AS SALESDISTTLTAXEXCRF" + Environment.NewLine;
                // �C�� 2009/04/21 <<<
                sqlString += "    ,A.CUSTSLIPNORF" + Environment.NewLine;
                sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                // ADD 2008.10.28 >>>
                sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;

                
                // �C�� 2009/05/18 >>>
                //// --- ADD 2009/04/09 ------->>>
                sqlString += "    ,DTL.COSTRF AS TOTALCOSTRF" + Environment.NewLine;
                //sqlString += "    ,DTL.SALESMONEYTAXEXCRF AS SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,DTL.SALESMONEYTAXINCRF AS SALESTOTALTAXINCRF" + Environment.NewLine;
                //// --- ADD 2009/04/09 -------<<<
                //sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                // �C�� 2009/05/18 <<<

                // �`�[�^�C�v�̏ꍇ
                // ����ŋ��z�́A�`�[�̒l
                // ���̑����z�́A���ׂ̒l���o�� ����PM7�d�l
                sqlString += "    ,DTL.SALESMONEYTAXEXCRF AS SALESTOTALTAXEXCRF" + Environment.NewLine;
                // �C�� 2009/07/23 >>>
                //sqlString += "    ,DTL.SALESMONEYTAXEXCRF + A.SALESTOTALTAXINCRF -A.SALESTOTALTAXEXCRF AS SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += ",CASE WHEN A.CONSTAXLAYMETHODRF =0 THEN DTL.SALESMONEYTAXEXCRF + A.SALESTOTALTAXINCRF -A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += " ELSE DTL.SALESMONEYTAXINCRF END AS SALESTOTALTAXINCRF" + Environment.NewLine;
                // �C�� 2009/07/23 <<<
                // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                sqlString += "    ,F.SALESMONEYTAXFREECRF AS SALESMONEYTAXFREECRF" + Environment.NewLine;
                sqlString += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                sqlString += "       SELECT   " + Environment.NewLine;
                sqlString += "          1   " + Environment.NewLine;
                sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                sqlString += "       AND A.CONSTAXLAYMETHODRF != 9 " + Environment.NewLine;
                sqlString += "       AND SALESDTL.SALESSLIPCDDTLRF != 3 " + Environment.NewLine;
                
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "    AND (A.CONSTAXLAYMETHODRF = 0 OR ( A.CONSTAXLAYMETHODRF <> 0 AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD))";
                }
                sqlString += "       AND SALESDTL.TAXATIONDIVCDRF != 1)  " + Environment.NewLine;
                sqlString += "  THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
                sqlString += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                sqlString += "       SELECT   " + Environment.NewLine;
                sqlString += "          1   " + Environment.NewLine;
                sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "    AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                }
                sqlString += "       AND (A.CONSTAXLAYMETHODRF = 9 OR SALESDTL.TAXATIONDIVCDRF = 1))  " + Environment.NewLine;
                sqlString += "  THEN 1 ELSE 0 END TAXFREEEXISTFLAG  " + Environment.NewLine;
                // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                // ADD 2008.10.28 <<<
                // ADD 2009.01.14 >>>
                //sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                //sqlString += "    ,SUM(CASE WHEN B.SALESSLIPCDDTLRF = 2 THEN B.COSTRF ELSE 0 END) AS DISCOSTRF" + Environment.NewLine;
                // �C�� 2009/04/21 >>>
                //sqlString += "    ,E.DISOUTTAXGOODS AS SALESDISOUTTAXRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISOUTTAXRF - E.DISOUTTAXGYO AS SALESDISOUTTAXRF" + Environment.NewLine;
                // �C�� 2009/04/21 <<<
                sqlString += "    ,E.DISCOSTGOODS AS DISCOSTRF" + Environment.NewLine;
                // ADD 2009.01.14 <<<
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ---------->>>>> 
                //sqlString += " FROM SALESHISTORYRF A" + Environment.NewLine;
                //sqlString += " INNER JOIN SALESHISTDTLRF B ON" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>> 
                sqlString += " FROM SALESHISTORYRF A WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += " INNER JOIN SALESHISTDTLRF B WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                sqlString += " (B.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                //sqlString += " )LEFT JOIN SECINFOSETRF C ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " )LEFT JOIN SECINFOSETRF C WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (C.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                // �C�� 2009/05/18 >>>
                //sqlString += "    AND C.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "    AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                // �C�� 2009/05/18 <<<
                sqlString += " ) LEFT" + Environment.NewLine;
                //sqlString += " JOIN SUBSECTIONRF D ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " JOIN SUBSECTIONRF D WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (D.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND D.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;  // DEL 2010/05/10
                sqlString += "    AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                // ADD 
                sqlString += " LEFT JOIN" + Environment.NewLine;
                sqlString += " (" + Environment.NewLine;
                sqlString += "   SELECT" + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF," + Environment.NewLine;
                sqlString += "    --����/�ԕi�։��Z" + Environment.NewLine;
                sqlString += "    SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 THEN SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) SALESDISTTLTAXEXCGOODS," + Environment.NewLine;
                sqlString += "    SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 THEN SALESDTL.SALESMONEYTAXINCRF ELSE 0 END) SALESDISTTLTAXINCGOODS," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 THEN SALESDTL.COSTRF ELSE 0 END) DISCOSTGOODS," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 AND SALESDTL.TAXATIONDIVCDRF = 0 " + Environment.NewLine;
                sqlString += "	     THEN SALESDTL.SALESMONEYTAXINCRF - SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) DISOUTTAXGOODS," + Environment.NewLine;
                sqlString += "	  -- �s�l��" + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF = 0 THEN SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) SALESDISTTLTAXEXCGYO," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF = 0 THEN SALESDTL.COSTRF ELSE 0 END) DISCOSTGYO," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF = 0 AND SALESDTL.TAXATIONDIVCDRF = 0 " + Environment.NewLine;
                sqlString += "	     THEN SALESDTL.SALESMONEYTAXINCRF - SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) DISOUTTAXGYO" + Environment.NewLine;
                sqlString += "   FROM " + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ---------->>>>> 
                //sqlString += "     SALESHISTDTLRF AS SALESDTL" + Environment.NewLine;
                //sqlString += "   LEFT JOIN SALESHISTORYRF AS SALES" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>>
                sqlString += "     SALESHISTDTLRF AS SALESDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += "   LEFT JOIN SALESHISTORYRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                sqlString += "   ON " + Environment.NewLine;
                sqlString += "     (SALES.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "     AND SALES.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "     AND SALES.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF)" + Environment.NewLine;
                sqlString += "   WHERE" + Environment.NewLine;
                // -- UPD 2010/05/10 ----------------------------------------->>>
                //sqlString += "    SALESSLIPCDDTLRF = 2 -- �l��  " + Environment.NewLine;
                sqlString += "        SALES.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                sqlString += "    AND SALESDTL.SALESSLIPCDDTLRF = 2 -- �l��  " + Environment.NewLine;
                // -- UPD 2010/05/10 -----------------------------------------<<<
                sqlString += "   GROUP BY " + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += " ) AS E ON " + Environment.NewLine;
                sqlString += " (      " + Environment.NewLine;
                sqlString += "    E.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND E.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND E.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    AND E.SALESSLIPCDRF = A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "  )" + Environment.NewLine;
                // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                sqlString += " LEFT JOIN" + Environment.NewLine;
                sqlString += " (" + Environment.NewLine;
                sqlString += "   SELECT" + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF," + Environment.NewLine;
                sqlString += "    SUM(SALESDTL.SALESMONEYTAXEXCRF) SALESMONEYTAXFREECRF" + Environment.NewLine;
                sqlString += "   FROM " + Environment.NewLine;
                sqlString += "     SALESHISTDTLRF AS SALESDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += "   LEFT JOIN SALESHISTORYRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += "   ON " + Environment.NewLine;
                sqlString += "     (SALES.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "     AND SALES.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "     AND SALES.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF)" + Environment.NewLine;
                sqlString += "   WHERE" + Environment.NewLine;
                sqlString += "        SALES.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                sqlString += "    AND (SALESDTL.SALESSLIPCDDTLRF != 2  OR (SALESDTL.SALESSLIPCDDTLRF=2 AND SALESDTL.SHIPMENTCNTRF=0 ))" + Environment.NewLine;
                sqlString += "    AND (SALES.CONSTAXLAYMETHODRF = 9 OR SALESDTL.TAXATIONDIVCDRF = 1)  " + Environment.NewLine;
                sqlString += "    AND (SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF = 1)  " + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "    AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                }
                sqlString += "   GROUP BY " + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += " ) AS F ON " + Environment.NewLine;
                sqlString += " (      " + Environment.NewLine;
                sqlString += "    F.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND F.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND F.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    AND F.SALESSLIPCDRF = A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "  )" + Environment.NewLine;
                // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

                // DEL 2009/05/18 >>>
                // --- ADD 2009/04/09 ------->>> Mantis�Ή�11184 ���㖾�ׂ�蔄����z�ƌ����̍��Z�l���擾
                sqlString += "	LEFT JOIN " + Environment.NewLine;
                sqlString += "	 (SELECT" + Environment.NewLine;
                sqlString += "	  SADTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "	  SADTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "	  SADTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "   SALESORDERDIVCDRF," + Environment.NewLine;
                }

                sqlString += "	  SUM (SADTL.SALESMONEYTAXEXCRF) AS SALESMONEYTAXEXCRF," + Environment.NewLine;
                sqlString += "	  SUM (SADTL.COSTRF) AS COSTRF," + Environment.NewLine;
                sqlString += "    SUM (SADTL.SALESMONEYTAXINCRF) AS SALESMONEYTAXINCRF" + Environment.NewLine;
                //sqlString += "	  SADTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -- 2009/08/10 ------------------------------------------------->>>
                //sqlString += "	FROM SALESDETAILRF SADTL" + Environment.NewLine;
                //sqlString += "	FROM SALESHISTDTLRF SADTL" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += "	FROM SALESHISTDTLRF SADTL WITH (READUNCOMMITTED)" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                // -- 2009/08/10 -------------------------------------------------<<<
                sqlString += "	GROUP BY SADTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "	         SADTL.SALESSLIPNUMRF," + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "   SALESORDERDIVCDRF," + Environment.NewLine;
                }
                sqlString += "	         SADTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                //sqlString += "	         SADTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                sqlString += "	) AS DTL" + Environment.NewLine;
                sqlString += "	ON  DTL.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "	AND DTL.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "	AND DTL.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                // --- ADD 2009/04/09 -------<<<
                // DEL 2009/05/18 <<<
            }
            else
            {
                //sqlString += "SELECT A.SECTIONCODERF" + Environment.NewLine;  //2008.09.17 DEL
                sqlString += "SELECT DISTINCT" + Environment.NewLine;           //2008.09.17 ADD
                // �C�� 2009/05/18 >>>
                //sqlString += "     A.SECTIONCODERF" + Environment.NewLine;      //2008.09.17 ADD
                sqlString += "     A.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                // �C�� 2009/05/18 <<<
                sqlString += "    ,A.LOGICALDELETECODERF" + Environment.NewLine;  // --- ADD  ����  2010/11/29
                //sqlString += "    ,C.SECTIONGUIDENMRF" + Environment.NewLine; //2008.10.08 DEL
                sqlString += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;  //2008.10.08 ADD
                sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONDIVRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONRF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += "    ,A.CONSTAXRATERF" + Environment.NewLine; // ����Őŗ�   // ADD 3H ���� 2020/02/27
                sqlString += "    ,A.CUSTSLIPNORF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,B.GOODSNORF" + Environment.NewLine;
                sqlString += "    ,B.GOODSNAMERF" + Environment.NewLine;
                sqlString += "    ,B.BLGOODSCODERF" + Environment.NewLine;
                sqlString += "    ,B.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlString += "    ,B.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlString += "    ,B.LISTPRICETAXINCFLRF" + Environment.NewLine;
                sqlString += "    ,B.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESRATERF" + Environment.NewLine;
                sqlString += "    ,B.SHIPMENTCNTRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNITCOSTRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                sqlString += "    ,B.COSTRF" + Environment.NewLine;
                sqlString += "    ,B.SALESMONEYTAXINCRF" + Environment.NewLine;
                sqlString += "    ,B.SALESMONEYTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,B.SUPPLIERCDRF" + Environment.NewLine;
                sqlString += "    ,B.SUPPLIERSNMRF" + Environment.NewLine;
                sqlString += "    ,F.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlString += "    ,G.PARTYSALESLIPNUMRF AS PARTYSALESLIPNUMSTOCK" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSECODERF" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSENAMERF" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSESHELFNORF" + Environment.NewLine;
                sqlString += "    ,B.SALESCODERF" + Environment.NewLine;
                sqlString += "    ,B.SALESCDNMRF" + Environment.NewLine;
                sqlString += "    ,E.MODELFULLNAMERF" + Environment.NewLine;
                sqlString += "    ,E.FULLMODELRF" + Environment.NewLine;
                sqlString += "    ,E.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlString += "    ,E.CATEGORYNORF" + Environment.NewLine;
                sqlString += "    ,E.CARMNGCODERF" + Environment.NewLine;
                sqlString += "    ,E.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlString += "    ,B.SALESSLIPCDDTLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESROWNORF" + Environment.NewLine;
                sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                // ADD 2008.10.28 >>>
                sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,B.TAXATIONDIVCDRF" + Environment.NewLine;
                // ADD 2008.10.28 <<<
                // ADD 2009.01.14 >>>
                sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                // ADD 2009.01.14 <<<
                // 2010/06/29 Add >>>
                sqlString += "    ,E.MODELHALFNAMERF" + Environment.NewLine;
                // 2010/06/29 Add <<<
                // --- ADD  ���r��  2010/07/14 ---------->>>>>
                sqlString += "    ,B.GOODSNAMEKANARF" + Environment.NewLine;
                // --- ADD  ���r��  2010/07/14 ----------<<<<<
                // ----- ADD 2022/09/29 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
               

                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                    sqlString += "       SELECT   " + Environment.NewLine;
                    sqlString += "          1   " + Environment.NewLine;
                    sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                    sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                    sqlString += "       AND A.CONSTAXLAYMETHODRF != 9 " + Environment.NewLine;
                    sqlString += "       AND SALESDTL.SALESSLIPCDDTLRF != 3 " + Environment.NewLine;
                    sqlString += "    AND (A.CONSTAXLAYMETHODRF = 0 AND SALESDTL.SALESORDERDIVCDRF<>@SALESORDERDIVCD)";
                    sqlString += "       AND SALESDTL.TAXATIONDIVCDRF != 1)  " + Environment.NewLine;
                    sqlString += "  AND NOT EXISTS (" + Environment.NewLine;
                    sqlString += "       SELECT   " + Environment.NewLine;
                    sqlString += "          1   " + Environment.NewLine;
                    sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                    sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                    sqlString += "       AND A.CONSTAXLAYMETHODRF != 9 " + Environment.NewLine;
                    sqlString += "       AND SALESDTL.SALESSLIPCDDTLRF != 3 " + Environment.NewLine;
                    sqlString += "    AND (A.CONSTAXLAYMETHODRF = 0 AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD)";
                    sqlString += "       AND SALESDTL.TAXATIONDIVCDRF != 1)  " + Environment.NewLine;
                    sqlString += "  THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
                }
                // ----- ADD 2022/09/29 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                // --- ADD  �{��  2010/07/18 ---------->>>>>
                sqlString += "    ,B.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                // --- ADD  �{��  2010/07/18 ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>>
                //sqlString += " FROM SALESHISTORYRF A" + Environment.NewLine;
                //sqlString += " INNER JOIN SALESHISTDTLRF B ON" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>>
                sqlString += " FROM SALESHISTORYRF A WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += " INNER JOIN SALESHISTDTLRF B WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                sqlString += " (B.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                //sqlString += " ) LEFT JOIN SECINFOSETRF C ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " ) LEFT JOIN SECINFOSETRF C WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (C.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                // �C�� 2009/05/18 >>>
                //sqlString += "    AND C.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "    AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                // �C�� 2009/05/18 <<<
                //sqlString += " ) LEFT JOIN SUBSECTIONRF D ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " ) LEFT JOIN SUBSECTIONRF D WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (D.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND D.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;  // DEL 2010/05/10
                sqlString += "    AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF" + Environment.NewLine;
                // DEL 2008.11.25 >>>+
                //sqlString += " ) LEFT JOIN ACCEPTODRCARRF E ON" + Environment.NewLine;
                //sqlString += " (E.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF" + Environment.NewLine;
                //sqlString += "    AND E.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF" + Environment.NewLine;
                // DEL 2008.11.25 <<<
                // ADD 2008.11.25 >>>
                //sqlString += ") LEFT JOIN ACCEPTODRCARRF E ON (" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += ") LEFT JOIN ACCEPTODRCARRF E WITH (READUNCOMMITTED) ON (" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += "B.ENTERPRISECODERF=E.ENTERPRISECODERF  " + Environment.NewLine;
                sqlString += "AND B.ACCEPTANORDERNORF=E.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlString += "AND (" + Environment.NewLine;
                sqlString += "      (B.ACPTANODRSTATUSRF = 10 AND E.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //�@����
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 20 AND E.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // ��
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 30 AND E.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // ����
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 40 AND E.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // �o�ׁ@
                sqlString += "    )" + Environment.NewLine;
                // ADD 2008.11.25 <<<

                // -- 2009/08/10 -------------------------------------------------->>>
                //sqlString += " ) LEFT JOIN STOCKDETAILRF F ON" + Environment.NewLine;
                //sqlString += " ) LEFT JOIN STOCKSLHISTDTLRF F ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " ) LEFT JOIN STOCKSLHISTDTLRF F WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                // -- 2009/08/10 --------------------------------------------------<<<
                sqlString += " (F.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND F.SUPPLIERFORMALRF = B.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                sqlString += "    AND F.STOCKSLIPDTLNUMRF = B.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                //sqlString += " LEFT JOIN STOCKSLIPHISTRF G ON " + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " LEFT JOIN STOCKSLIPHISTRF G WITH (READUNCOMMITTED) ON " + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += "( G.ENTERPRISECODERF = F.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += " AND G.SUPPLIERFORMALRF = F.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlString += " AND G.SUPPLIERSLIPNORF = F.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;

            }
            // 2008.07.01 upd end ---------------------------------------------------<<

            #endregion

            #region Where��
            sqlString += "WHERE ";

            //��ƃR�[�h
            sqlString += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesConfShWork.EnterpriseCode);

            //�_���폜�敪
            if (salesConfShWork.LogicalDeleteCode == 1 && salesConfShWork.SalesSlipUpdateCd == 1)
            {
                sqlString += "AND( A.LOGICALDELETECODERF=@LOGICALDELETECODE OR A.SALESSLIPUPDATECDRF>=@SALESSLIPUPDATECD ) ";

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.LogicalDeleteCode);

                SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesSlipUpdateCd);

            }
            else
            {
                //�_���폜�敪
                sqlString += "AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.LogicalDeleteCode);

                //����`�[�X�V�敪
                if (salesConfShWork.SalesSlipUpdateCd != -1)
                {
                    sqlString += "AND A.SALESSLIPUPDATECDRF>=@SALESSLIPUPDATECD ";
                    SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                    paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesSlipUpdateCd);
                }
            }


            //���ьv�㋒�_�R�[�h
            //if (salesConfShWork.IsSelectAllSection == false && salesConfShWork.IsOutputAllSecRec == false) // 2008.07.01 del
            if (salesConfShWork.IsSelectAllSection == false) // 2008.07.01 del
            {
                string sectionString = "";
                foreach (string sectionCode in salesConfShWork.ResultsAddUpSecList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    
                    //sqlString += "AND A.SECTIONCODERF IN (" + sectionString + ") "; // DEL 2008.11.04
                    sqlString += "AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ") "; // ADD 2008.11.04
                }
            }

            //�󒍃X�e�[�^�X(30:����̂�)
            sqlString += "AND A.ACPTANODRSTATUSRF=30 ";

            //������t(�J�n)
            if (salesConfShWork.SalesDateSt != 0)
            {
                // -- UPD 2010/05/10 ----------------------------------------->>>
                //sqlString += "AND A.SALESDATERF>=@SALESDATEST ";
                //SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                //paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateSt);

                sqlString += "AND A.SALESDATERF>=" + SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -----------------------------------------<<<
            }

            //������t(�I��)
            if (salesConfShWork.SalesDateEd != 0)
            {
                // -- UPD 2010/05/10 ----------------------------------------->>>
                //sqlString += "AND A.SALESDATERF<=@SALESDATEED ";
                //SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                //paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateEd);

                sqlString += "AND A.SALESDATERF<=" + SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -----------------------------------------<<<
            }

            //�o�ד��t(�J�n)
            if (salesConfShWork.ShipmentDaySt != 0)
            {
                sqlString += "AND A.SHIPMENTDAYRF>=@SHIPMENTDAYST ";
                SqlParameter paraShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                paraShipmentDaySt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.ShipmentDaySt);
            }

            //�o�ד��t(�I��)
            if (salesConfShWork.ShipmentDayEd != 0)
            {
                sqlString += "AND A.SHIPMENTDAYRF<=@SHIPMENTDAYED ";
                SqlParameter paraShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                paraShipmentDayEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.ShipmentDayEd);
            }

            //���͓��t(�J�n)
            if (salesConfShWork.SearchSlipDateSt != 0)
            {
                sqlString += "AND A.SEARCHSLIPDATERF>=@SEARCHSLIPDATEST ";
                SqlParameter paraSearchSlipDateSt = sqlCommand.Parameters.Add("@SEARCHSLIPDATEST", SqlDbType.Int);
                paraSearchSlipDateSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SearchSlipDateSt);
            }

            //���͓��t(�I��)
            if (salesConfShWork.SearchSlipDateEd != 0)
            {
                sqlString += "AND A.SEARCHSLIPDATERF<=@SEARCHSLIPDATEED ";
                SqlParameter paraSearchSlipDateEd = sqlCommand.Parameters.Add("@SEARCHSLIPDATEED", SqlDbType.Int);
                paraSearchSlipDateEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SearchSlipDateEd);
            }

            //�ԓ`�敪
            if (salesConfShWork.DebitNoteDiv != -1)
            {
                sqlString += "AND A.DEBITNOTEDIVRF=@DEBITNOTEDIV ";
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.DebitNoteDiv);
            }

            //����`�[�敪 
            if (salesConfShWork.SalesSlipCd != -1 && salesConfShWork.SalesSlipCd != 2)
            {
                sqlString += "AND A.SALESSLIPCDRF=@SALESSLIPCD ";
                SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesSlipCd);
            }

            //���Ӑ�R�[�h(�J�n)
            if (salesConfShWork.CustomerCodeSt != 0)
            {
                sqlString += "AND A.CUSTOMERCODERF>=@CUSTOMERCODEST ";
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.CustomerCodeSt);
            }

            //���Ӑ�R�[�h(�I��)
            if (salesConfShWork.CustomerCodeEd != 0)
            {
                sqlString += "AND A.CUSTOMERCODERF<=@CUSTOMERCODEED ";
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.CustomerCodeEd);
            }
            
            //����`�[�ԍ�(�J�n)
            if (salesConfShWork.SalesSlipNumSt != "")
            {
                sqlString += "AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST ";
                SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesSlipNumSt);
            }

            //����`�[�ԍ�(�I��)
            if (salesConfShWork.SalesSlipNumEd != "")
            {
                sqlString += "AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED ";
                SqlParameter paraSalesSlipNumStEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraSalesSlipNumStEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesSlipNumEd);
            }

            //�̔��]�ƈ��R�[�h(�J�n)
            if (salesConfShWork.SalesEmployeeCdSt != "")
            {
                sqlString += "AND A.SALESEMPLOYEECDRF>=@SALESEMPLOYEECDST ";
                SqlParameter paraSalesEmployeeCdSt = sqlCommand.Parameters.Add("@SALESEMPLOYEECDST", SqlDbType.NVarChar);
                paraSalesEmployeeCdSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesEmployeeCdSt);
            }

            //�̔��]�ƈ��R�[�h(�I��)
            if (salesConfShWork.SalesEmployeeCdEd != "")
            {
                sqlString += "AND ( A.SALESEMPLOYEECDRF<=@SALESEMPLOYEECDED OR A.SALESEMPLOYEECDRF IS NULL ) ";
                SqlParameter paraSalesEmployeeCdEd = sqlCommand.Parameters.Add("@SALESEMPLOYEECDED", SqlDbType.NVarChar);
                paraSalesEmployeeCdEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesEmployeeCdEd);
            }

            //��t�]�ƈ��R�[�h(�J�n)
            if (salesConfShWork.FrontEmployeeCdSt != "")
            {
                sqlString += "AND A.FRONTEMPLOYEECDRF>=@FRONTEMPLOYEECDST ";
                SqlParameter paraFrontEmployeeCdSt = sqlCommand.Parameters.Add("@FRONTEMPLOYEECDST", SqlDbType.NVarChar);
                paraFrontEmployeeCdSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.FrontEmployeeCdSt);
            }

            //��t�]�ƈ��R�[�h(�I��)
            if (salesConfShWork.FrontEmployeeCdEd != "")
            {
                sqlString += "AND ( A.FRONTEMPLOYEECDRF<=@FRONTEMPLOYEECDED OR A.FRONTEMPLOYEECDRF IS NULL )";
                SqlParameter paraFrontEmployeeCdEd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECDED", SqlDbType.NVarChar);
                paraFrontEmployeeCdEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.FrontEmployeeCdEd);
            }

            //���͒S���҃R�[�h(�J�n)
            if (salesConfShWork.SalesInputCodeSt != "")
            {
                sqlString += "AND A.SALESINPUTCODERF>=@SALESINPUTCODEST ";
                SqlParameter paraSalesInputCodeSt = sqlCommand.Parameters.Add("@SALESINPUTCODEST", SqlDbType.NVarChar);
                paraSalesInputCodeSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesInputCodeSt);
            }

            //���͒S���҃R�[�h(�I��)
            if (salesConfShWork.SalesInputCodeEd != "")
            {
                sqlString += "AND ( A.SALESINPUTCODERF<=@SALESINPUTCODEED OR A.SALESINPUTCODERF IS NULL )";
                SqlParameter paraSalesInputCodeEd = sqlCommand.Parameters.Add("@SALESINPUTCODEED", SqlDbType.NVarChar);
                paraSalesInputCodeEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesInputCodeEd);
            }

            // 2008.07.01 add start ------------------------------>>
            //�̔��G���A�R�[�h(�J�n)
            if (salesConfShWork.SalesAreaCodeSt != 0)
            {
                sqlString += "AND A.SALESAREACODERF>=@SALESAREACODEST ";
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@SALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesAreaCodeSt);
            }
            //�̔��G���A�R�[�h(�J�n)
            if (salesConfShWork.SalesAreaCodeEd != 0)
            {
                sqlString += "AND A.SALESAREACODERF<=@SALESAREACODEED ";
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@SALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesAreaCodeEd);
            }
            //�Ǝ�R�[�h(�J�n)
            if (salesConfShWork.BusinessTypeCodeSt != 0)
            {
                sqlString += "AND A.BUSINESSTYPECODERF>=@BUSINESSTYPECODEST ";
                SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@BUSINESSTYPECODEST", SqlDbType.Int);
                paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.BusinessTypeCodeSt);
            }
            //�Ǝ�R�[�h(�I��)
            if (salesConfShWork.BusinessTypeCodeEd != 0)
            {
                sqlString += "AND A.BUSINESSTYPECODERF<=@BUSINESSTYPECODEED ";
                SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@BUSINESSTYPECODEED", SqlDbType.Int);
                paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.BusinessTypeCodeEd);
            }

            //if (printMode != 0) // ���׃^�C�v�̎�
            //{

            //�d����R�[�h(�J�n)
            if (salesConfShWork.SupplierCdSt != 0)
            {
                sqlString += "AND B.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SupplierCdSt);
            }

            //�d����R�[�h(�I��)
            if (salesConfShWork.SupplierCdEd != 0)
            {
                sqlString += "AND B.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SupplierCdEd);
            }
            //����݌Ɏ�񂹋敪
            if (salesConfShWork.SalesOrderDivCd != -1)
            {
                if (printMode == 0)
                {
                    sqlString += "AND B.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                    sqlString += "AND DTL.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                    SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                    paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesOrderDivCd);
                }
                else
                {
                    sqlString += "AND B.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                    SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                    paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesOrderDivCd);
                }
            }
            //�������@�敪
            if (salesConfShWork.WayToOrder != -1)
            {
                sqlString += "AND B.WAYTOORDERRF=@WAYTOORDER ";
                SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.WayToOrder);
            }
            //����`�[�敪 2:�ԕi�E�l��
            if (salesConfShWork.SalesSlipCd == 2)
            {
                sqlString += "AND (A.SALESSLIPCDRF=1 OR (A.SALESSLIPCDRF=0 AND B.SALESSLIPCDDTLRF = 2 )) ";
            }

            // ADD 2009/10/22 -------------------------------->>>
            //���ߍs�͑ΏۊO�Ƃ���
            sqlString += "AND B.SALESSLIPCDDTLRF != 3 ";
            // ADD 2009/10/22 --------------------------------<<<

            //}

            // -- UPD 2009/10/22 ------------------------------------------>>>
            #region �폜
            ////�����[��
            //if (salesConfShWork.ZeroSalesPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.SALESMONEYTAXEXCRF=0 ";
            //    else
            //        sqlString += "AND B.SALESMONEYTAXEXCRF=0 ";
            //}
            ////�����[��
            //if (salesConfShWork.ZeroCostPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.COSTRF=0 ";
            //    else
            //        sqlString += "AND B.COSTRF=0 ";
            //}
            ////�e���[��
            //if (salesConfShWork.ZeroGrsProfitPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.SALESMONEYTAXEXCRF - DTL.COSTRF=0 ";
            //    else
            //        sqlString += "AND B.SALESMONEYTAXEXCRF - B.COSTRF=0 ";
            //}
            ////�e���[���ȉ�
            //if (salesConfShWork.ZeroUdrGrsProfitPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.SALESMONEYTAXEXCRF - DTL.COSTRF<0 ";
            //    else
            //        sqlString += "AND B.SALESMONEYTAXEXCRF - B.COSTRF<0 ";
            //}
            ////�e����
            //string grsProfitRatePrintVal = string.Empty;
            //grsProfitRatePrintVal = salesConfShWork.GrsProfitRatePrintVal.ToString();

            //if (salesConfShWork.GrsProfitRatePrint != 0)
            //{
            //    if (salesConfShWork.GrsProfitRatePrintDiv != 0) // �ȏ�
            //    {
            //        if (printMode == 0)
            //            sqlString += "AND (CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) >" + grsProfitRatePrintVal + Environment.NewLine;
            //        else
            //            //sqlString += "AND (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF>" + grsProfitRatePrintVal + Environment.NewLine;
            //            sqlString += "AND (CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) >" + grsProfitRatePrintVal + Environment.NewLine;
            //    }
            //    else
            //    {
            //        if (printMode == 0)
            //            sqlString += "AND (CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) <" + grsProfitRatePrintVal + Environment.NewLine;
            //        else
            //            //sqlString += "AND (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF<" + grsProfitRatePrintVal + Environment.NewLine;
            //            sqlString += "AND (CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) <" + grsProfitRatePrintVal + Environment.NewLine;
            //    }
            //}
            // 2008.07.01 add end --------------------------------<<
            #endregion

            //�[���w��͂n�q�����ɕύX
            string zeroString = string.Empty;

            //�����[��
            if (salesConfShWork.ZeroSalesPrint != 0)
            {
                if (printMode == 0)
                    zeroString += "DTL.SALESMONEYTAXEXCRF=0";
                else
                    zeroString += "B.SALESMONEYTAXEXCRF=0";
            }
            //�����[��
            if (salesConfShWork.ZeroCostPrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (printMode == 0)
                    zeroString += "DTL.COSTRF=0";
                else
                    zeroString += "B.COSTRF=0";
            }
            //�e���[��
            if (salesConfShWork.ZeroGrsProfitPrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (printMode == 0)
                    zeroString += "DTL.SALESMONEYTAXEXCRF - DTL.COSTRF=0";
                else
                    zeroString += "B.SALESMONEYTAXEXCRF - B.COSTRF=0";
            }
            //�e���[���ȉ�
            if (salesConfShWork.ZeroUdrGrsProfitPrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (printMode == 0)
                    zeroString += "DTL.SALESMONEYTAXEXCRF - DTL.COSTRF<=0";
                else
                    zeroString += "B.SALESMONEYTAXEXCRF - B.COSTRF<=0";
            }

            //�e����
            string grsProfitRatePrintVal = string.Empty;
            grsProfitRatePrintVal = salesConfShWork.GrsProfitRatePrintVal.ToString();

            if (salesConfShWork.GrsProfitRatePrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (salesConfShWork.GrsProfitRatePrintDiv != 0) // �ȏ�
                {
                    if (printMode == 0)
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) >=" + grsProfitRatePrintVal +')' + Environment.NewLine;
                        zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,DTL.SALESMONEYTAXEXCRF) - convert(decimal,DTL.COSTRF)) * 100 / convert(decimal,DTL.SALESMONEYTAXEXCRF) ELSE 0 END) >=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                    else
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) >=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,B.SALESMONEYTAXEXCRF) - convert(decimal,B.COSTRF)) * 100 / convert(decimal,B.SALESMONEYTAXEXCRF) ELSE 0 END) >=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                }
                else
                {
                    if(printMode ==0)
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,DTL.SALESMONEYTAXEXCRF) - convert(decimal,DTL.COSTRF)) * 100 / convert(decimal,DTL.SALESMONEYTAXEXCRF) ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                    else
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,B.SALESMONEYTAXEXCRF) - convert(decimal,B.COSTRF)) * 100 / convert(decimal,B.SALESMONEYTAXEXCRF) ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                }
            }

            if (zeroString != string.Empty)
            {
                sqlString += "AND (" + zeroString + ") ";
            }
            // -- UPD 2009/10/22 ------------------------------------------<<<

            // 2008.07.01 add end --------------------------------<<

            if (printMode == 1)
            {
                // --- DEL 2014/04/17 T.Miyamoto ------------------------------>>>>>
                ////�ꎮ�f�[�^(�ꎮ���הԍ�=0)
                //sqlString += "AND B.CMPLTSALESROWNORF=0 ";
                // --- DEL 2014/04/17 T.Miyamoto ------------------------------<<<<<
            }
            #endregion

            // ADD 2009.01.14 >>>
            if (printMode == 0)
            {
                #region GROUP BY
                //sqlString += " GROUP BY" + Environment.NewLine;
                //sqlString += "     A.SECTIONCODERF" + Environment.NewLine;
                //sqlString += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;
                //sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                //sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                //sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                //sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                //sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                //sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                //sqlString += "    ,CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END" + Environment.NewLine;
                //sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                //sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                //sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                //sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                //sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                //sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                //sqlString += "    ,A.RETGOODSREASONDIVRF" + Environment.NewLine;
                //sqlString += "    ,A.RETGOODSREASONRF" + Environment.NewLine;
                //sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                //sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                //sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                //sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                //sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                //sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                //sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.CUSTSLIPNORF" + Environment.NewLine;
                //sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                //sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                //sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                //sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                #endregion
            }
            // ADD 2009.01.14 <<<

            #region Order By��
            sqlString += "ORDER BY A.SALESSLIPNUMRF ";
            if (printMode == 1)
            {
                sqlString += ", B.SALESROWNORF ";
            }

            #endregion

            return sqlString;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SalesConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="salesConfShWork">�����p�����[�^</param>
        /// <param name="printMode">0:���v�^�C�v 1:���ׁE�ڍ׃^�C�v</param>
        /// <returns>SalesConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        /// </remarks>
        private SalesConfWork CopyToSalesSlipConfWorkFromReader(ref SqlDataReader myReader, SalesConfShWork salesConfShWork, int printMode)
        {
            #region �N���X�֊i�[
            SalesConfWork wkSalesConfWork = new SalesConfWork();

            //����f�[�^
            wkSalesConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); //2008.10.08 DEL
            wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));  //2008.10.08 ADD
            wkSalesConfWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkSalesConfWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            wkSalesConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkSalesConfWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkSalesConfWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkSalesConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkSalesConfWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkSalesConfWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            wkSalesConfWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkSalesConfWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkSalesConfWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            wkSalesConfWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            wkSalesConfWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            wkSalesConfWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            wkSalesConfWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            wkSalesConfWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            wkSalesConfWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            wkSalesConfWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            wkSalesConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkSalesConfWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            wkSalesConfWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            wkSalesConfWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
            wkSalesConfWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            wkSalesConfWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            wkSalesConfWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            wkSalesConfWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            wkSalesConfWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            wkSalesConfWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkSalesConfWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            wkSalesConfWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkSalesConfWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkSalesConfWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkSalesConfWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            wkSalesConfWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));  // ����Őŗ��@// ADD 3H ���� 2020/02/27
            wkSalesConfWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
            wkSalesConfWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            wkSalesConfWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));

            // ADD 2008.10.28 >>>
            wkSalesConfWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkSalesConfWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            wkSalesConfWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
            wkSalesConfWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
            // ADD 2008.10.28 <<<
            // ADD 2009.01.14 >>>
            wkSalesConfWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
            wkSalesConfWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));// --- ADD  ����  2010/11/29
            if (printMode == 0)
            {
                wkSalesConfWork.DisCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOSTRF"));
                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--->>>>>
                wkSalesConfWork.TaxFreeExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXFREEEXISTFLAG")) > 0;
                wkSalesConfWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;
                wkSalesConfWork.SalesMoneyTaxFreeCdrf = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXFREECRF"));
                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---<<<<<
            }
            // --- ADD 2022/09/29 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--->>>>>
            else {
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    wkSalesConfWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;
                }
                else 
                {
                    wkSalesConfWork.TaxRateExistFlag = false;
                }
            }
            // --- ADD 2022/09/29 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---<<<<<
            // ADD 2009.01.14 <<<

            // �C�� 2009/04/21 >>>            
            if (printMode == 0)
            {
                // �l������ł̕␳����
                // �l������ł�0�ȊO ���� �l�����z(�Ŕ�)=0 �̏ꍇ�A�l������ł𔄏�/�ԕi����łֈړ�
                if (wkSalesConfWork.SalesDisOutTax != 0 && wkSalesConfWork.SalesDisTtlTaxExc == 0)
                {
                    //wkSalesConfWork.SalesTotalTaxInc -= wkSalesConfWork.SalesDisOutTax;
                    wkSalesConfWork.SalesDisOutTax = 0;
                }

            }
            // �C�� 2009/04/21 <<<

            //����敪��
            if (wkSalesConfWork.SalesSlipCd == 0)
            {
                if (wkSalesConfWork.AccRecDivCd == 0)
                {
                    wkSalesConfWork.TransactionName = "��������";
                }
                else if (wkSalesConfWork.AccRecDivCd == 1)
                {
                    wkSalesConfWork.TransactionName = "�|����";
                }
            }
            else if (wkSalesConfWork.SalesSlipCd == 1)
            {
                if (wkSalesConfWork.AccRecDivCd == 0)
                {
                    wkSalesConfWork.TransactionName = "�����ԕi";
                }
                else if (wkSalesConfWork.AccRecDivCd == 1)
                {
                    wkSalesConfWork.TransactionName = "�|�ԕi";
                }
            }

            //�e����(���v)
            if (wkSalesConfWork.SalesTotalTaxExc == 0)
            {
                wkSalesConfWork.GrossMarginRate = 0;
            }
            else
            {
                wkSalesConfWork.GrossMarginRate = (wkSalesConfWork.SalesTotalTaxExc - wkSalesConfWork.TotalCost) * 100 / (double)wkSalesConfWork.SalesTotalTaxExc;
            }

            //�e���`�F�b�N�}�[�N(���v)
            if (wkSalesConfWork.GrossMarginRate < salesConfShWork.GrsProfitCheckLower)
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin1Mark;
            }
            else if (wkSalesConfWork.GrossMarginRate < salesConfShWork.GrsProfitCheckBest)
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin2Mark;
            }
            else if (wkSalesConfWork.GrossMarginRate < salesConfShWork.GrsProfitCheckUpper)
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin3Mark;
            }
            else
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin4Mark;
            }
 
            //���׃f�[�^
            if (printMode == 1)
            {
                wkSalesConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkSalesConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkSalesConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkSalesConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkSalesConfWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                wkSalesConfWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                wkSalesConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkSalesConfWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                wkSalesConfWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkSalesConfWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                wkSalesConfWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                wkSalesConfWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                wkSalesConfWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                wkSalesConfWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                wkSalesConfWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                wkSalesConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkSalesConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkSalesConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                wkSalesConfWork.PartySaleSlipNumStock = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMSTOCK"));
                wkSalesConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkSalesConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkSalesConfWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkSalesConfWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                wkSalesConfWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                wkSalesConfWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                wkSalesConfWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                wkSalesConfWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                wkSalesConfWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                wkSalesConfWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                wkSalesConfWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                wkSalesConfWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                wkSalesConfWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                // ADD 2008.10.28 >>>
                wkSalesConfWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                // ADD 2008.10.28 <<<
                // 2010/06/29 Add >>>
                wkSalesConfWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                // 2010/06/29 Add <<<
                // --- ADD  ���r��  2010/07/14 ---------->>>>>
                wkSalesConfWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                // --- ADD  ���r��  2010/07/14 ----------<<<<<
                // --- ADD  �{��  2010/07/18 ---------->>>>>
                wkSalesConfWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));
                // --- ADD  �{��  2010/07/18 ----------<<<<<


                //�e����(����)
                if (wkSalesConfWork.SalesMoneyTaxExc == 0)
                {
                    wkSalesConfWork.GrossMarginRateDtl = 0;
                }
                else
                {
                    wkSalesConfWork.GrossMarginRateDtl = (wkSalesConfWork.SalesMoneyTaxExc - wkSalesConfWork.Cost) * 100 / (double)wkSalesConfWork.SalesMoneyTaxExc;
                }

                //�e���`�F�b�N�}�[�N(����)
                if (wkSalesConfWork.GrossMarginRateDtl < salesConfShWork.GrsProfitCheckLower)
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin1Mark;
                }
                else if (wkSalesConfWork.GrossMarginRateDtl < salesConfShWork.GrsProfitCheckBest)
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin2Mark;
                }
                else if (wkSalesConfWork.GrossMarginRateDtl < salesConfShWork.GrsProfitCheckUpper)
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin3Mark;
                }
                else
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin4Mark;
                }
            }
            #endregion

            return wkSalesConfWork;
        }

        #endregion
        // �� 2007.10.18 980081 e
    }
}
