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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d����d�q���� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����d�q�������f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.08.18</br>
    /// <br></br>
    /// <br>Update Note: ���������N���X�`�[�����敪�̒ǉ�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.21</br>
    /// <br></br>
    /// <br>Update Note: ���ʃN���X�֏���ŋ敪�̒ǉ�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.30</br>
    /// <br></br>
    /// <br>Update Note: ���o�s��C��( MANTIS ID:13324 )</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.05.26</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 ���̕�</br>
    /// <br>           : PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@</br>
    /// <br>           : �ߋ����\���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/10 �������n</br>
    /// <br>           : ���x�`���[�j���O</br>
    /// <br>UpdateNote : 2010/07/20 chenyd</br>
    /// <br>           �@�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2012/06/26 20008 �ɓ� �L</br>
    /// <br>           : �ۑ�No.1027 �������Ɍ����I�[�o�[����ƃG���[�ɂȂ錻�ۂ��C��</br>
    /// <br>           : READUNCOMMITTED�Ή��A�^�C���A�E�g���Ԃ̉���</br>
    /// <br>UpdateNote : 2012/09/13 FSI��k�c �G��</br>
    /// <br>           �@�d���摍���Ή��̒ǉ�</br>
    /// <br>UpdateNote : 2012/11/08 FSI��k�c �G��</br>
    /// <br>           �@�c���ꗗ�\���ʕ\���s��Ή�</br>   
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : FSI��c �W�v
    // �C �� ��  2013/01/21  �C�����e : �d���ԕi�\��@�\�Ή�
    //----------------------------------------------------------------------------//
    /// <br>UpdateNote : 2015/08/17 �c�v�t</br>
    /// <br>�Ǘ��ԍ�   : 11170129-00</br>
    /// <br>           �@Redmine#47007 ����łȂǂ��s���̏�Q�Ή�</br>
    /// <br>Update Note: 2015/12/22 �ړ�</br>
    /// <br>�Ǘ��ԍ�   : 11170204-00 2016�N1���z�M��</br>
    /// <br>             Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�A�Q�̑Ή�</br>
    /// <br>             ��Q�P:�������_�̎��т��o�͂���Ȃ� </br>
    /// <br>             ��Q�Q:�O����т��Ȃ��ꍇ�u�O��c���v�A�u�J�z�c���v�A�u����c���v�ɑO���_�́u����c���v���v���X����Ă��܂�</br>
    /// <br>Update Note: 2015/12/25 �ړ�</br>
    /// <br>�Ǘ��ԍ�   : 11170204-00 2016�N1���z�M��</br>
    /// <br>             Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�R�̑Ή�</br>
    /// <br>             ��Q�R�F�c���\���^�u�Ŏd�������I�v�V�������L���̏ꍇ�Ƀe�L�X�g�o�͂��s���Ǝd����R�[�h���x����R�[�h�̎c�����\������Ȃ�</br>
    /// <br>Update Note: 2016/02/02 �ړ�</br>
    /// <br>�Ǘ��ԍ�   : 11200002-00 2016�N2���z�M��</br>
    /// <br>             Redmine#48327 �d�������I�v�V�������L���̏ꍇ�ɑS���_���̃��R�[�h���o�͂����т��Ȃ����̂�ALL�[���ɂ���</br>
    /// </remarks>
    [Serializable]
    public class SuppPrtPprWorkDB : RemoteDB, ISuppPrtPprWorkDB
    {

        /// <summary>
        /// �d����d�q���� �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// </remarks>
        public SuppPrtPprWorkDB()
        {
        }

        // ----------ADD 2013/01/21----------->>>>>
        #region [SearchRefPurchaseReturnSchedule]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������d���ԕi�\����̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="suppPrtPprStcTblRsltWork">��������(�d���ԕi�\��f�[�^)</param>
        /// <param name="suppPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="logicalDelDiv">�폜�w��敪(0:�ʏ� 1:�폜���̂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public int SearchRefPurchaseReturnSchedule(ref object suppPrtPprStcTblRsltWork, object suppPrtPprWork, out Int64 recordCount, int logicalDelDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            //������
            recordCount = 0;
            Int64 iRecCnt = 0;
            suppPrtPprStcTblRsltWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (suppPrtPprWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�d���f�[�^�p ArrayList
                ArrayList suppPrtPprStcTblRsltWorkArray = suppPrtPprStcTblRsltWork as ArrayList;

                if (suppPrtPprStcTblRsltWorkArray == null)
                {
                    suppPrtPprStcTblRsltWorkArray = new ArrayList();
                }
                //�����p�����[�^
                SuppPrtPprWork _suppPrtPprWork = suppPrtPprWork as SuppPrtPprWork;
                #endregion  //[�p�����[�^�̃L���X�g]

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "�d���ԕi�\����", "���o�J�n");

                //Search���s
                #region [�d���f�[�^����]
                status = SearchRefProcPurchaseReturnSchedule(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, logicalDelDiv, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //���s���G���[
                    throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                }
                if (recordCount >= _suppPrtPprWork.SearchCnt)
                {
                    //���������I�[�o�[
                    suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                #endregion

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "�d���ԕi�\����", "���o�I��");

                //���s���ʃZ�b�g
                suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;

                if (suppPrtPprStcTblRsltWork != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchRefPurchaseReturnSchedule Exception=" + ex.Message);
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
        #endregion
        #region [SearchRefProcPurchaseReturnSchedule]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������d���ԕi�\��f�[�^�̃��X�g�𒊏o���܂�(�d���ԕi�\��f�[�^)
        /// </summary>
        /// <param name="rsltWorkArray">��������(�d���f�[�^)</param>
        /// <param name="_suppPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)�߂�l�p</param>
        /// <param name="iRecCnt">��������(����)�����`�F�b�N�p</param>
        /// <param name="logicalDelDiv">�폜�w��敪(0:�ʏ� 1:�폜���̂�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private int SearchRefProcPurchaseReturnSchedule(ref ArrayList rsltWorkArray, SuppPrtPprWork _suppPrtPprWork, out Int64 recordCount, Int64 iRecCnt, int logicalDelDiv, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ISuppPrtPprRetSch suppPrtPpr;
            suppPrtPpr = new SuppPrtPprRetSchStcTblRsltQuery();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = suppPrtPpr.MakeSelectString(ref sqlCommand, _suppPrtPprWork, logicalDelDiv);

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                //�����`�F�b�N�p�t���O
                bool bCuntChkFlg = false;

                SuppPrtPprStcTblRsltWork suppPrtPprStcTblRsltWork = new SuppPrtPprStcTblRsltWork();

                while (myReader.Read())
                {
                    if (bCuntChkFlg != true)
                    {
                        //�t���OON
                        bCuntChkFlg = true; 
                        //�Y���f�[�^�����擾
                        iRecCnt = iRecCnt + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROWNUM"));
                    }

                    //�擾���ʃZ�b�g
                    rsltWorkArray.Add(suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprWork));
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchRefProc_StcTbl Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            recordCount = iRecCnt;

            return status;
        }
        #endregion  //[SearchRefProcPurchaseReturnSchedule]
        // ----------ADD 2013/01/21-----------<<<<<

        #region [�c���Ɖ�E�`�[�\���E���ו\������]

        #region [SearchRef]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������c���Ɖ�E�`�[�\���E���ו\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="suppPrtPprBlDspRsltWork">��������(�c���Ɖ�)</param>
        /// <param name="suppPrtPprStcTblRsltWork">��������(����f�[�^)</param>
        /// <param name="suppPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2009/09/08 ���̕��@�ߋ����\���Ή�</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2012/06/26 20008 �ɓ� �L</br>
        /// <br>           : �ۑ�No.1027 �������Ɍ����I�[�o�[����ƃG���[�ɂȂ錻�ۂ��C��</br>
        public int SearchRef(ref object suppPrtPprBlDspRsltWork, ref object suppPrtPprStcTblRsltWork, object suppPrtPprWork, out Int64 recordCount, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            //������
            recordCount = 0;
            Int64 iRecCnt = 0;
            suppPrtPprBlDspRsltWork = null;
            suppPrtPprStcTblRsltWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (suppPrtPprWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�c���Ɖ�p ArrayList
                ArrayList suppPrtPprBlDspRsltArray = suppPrtPprBlDspRsltWork as ArrayList;
                if (suppPrtPprBlDspRsltArray == null)
                {
                    suppPrtPprBlDspRsltArray = new ArrayList();
                }
                //�d���f�[�^�p ArrayList
                ArrayList suppPrtPprStcTblRsltWorkArray = suppPrtPprStcTblRsltWork as ArrayList;
                if (suppPrtPprStcTblRsltWorkArray == null)
                {
                    suppPrtPprStcTblRsltWorkArray = new ArrayList();
                }
                //�����p�����[�^
                SuppPrtPprWork _suppPrtPprWork = suppPrtPprWork as SuppPrtPprWork;
                #endregion  //[�p�����[�^�̃L���X�g]

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();               

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "�d����d�q����", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                //Search���s
                #region [�d���f�[�^����]
                if (_suppPrtPprWork.SearchType != (int)SearchType.Pay) // ADD 2008.10.21 �`�[�����敪�� 2:�x���݈̂ȊO�̏ꍇ���� >>> 
                {
                    // -------------ADD 2009/09/08 ------------>>>>>
                    // ��S�Ă̏ꍇ
                    if (_suppPrtPprWork.SupplierFormal != null && _suppPrtPprWork.SupplierFormal.Length ==1)
                    {
                        status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection);
                    }
                    // �S�Ă̏ꍇ
                    else if (_suppPrtPprWork.SupplierFormal != null && _suppPrtPprWork.SupplierFormal.Length > 1)
                    {
                        // 0:�d���̌��������ʂ̌���
                        _suppPrtPprWork.SupplierFormal = new int[] { 0 };
                        status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection);
                        // 1:����,2:�����̌���
                        if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
                            || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 2012/06/26 Y.Ito ADD START �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                            if (recordCount >= _suppPrtPprWork.SearchCnt)
                            {
                                suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;

                                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            // 2012/06/26 Y.Ito ADD END �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��

                            iRecCnt = recordCount;
                            _suppPrtPprWork.SupplierFormal = new int[] { 1, 2 };
                            status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection);
                            _suppPrtPprWork.SupplierFormal = new int[] { 0, 1, 2 };
                        }
                    }
                    // -------------ADD 2009/09/08 ------------<<<<<
                    // status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection); // DEL 2009/09/08
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //���s���G���[
                        throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                    }
                    if (recordCount >= _suppPrtPprWork.SearchCnt)
                    {
                        // 2012/06/26 Y.Ito MOD START �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                        //���������I�[�o�[
                        //throw new Exception("���������I�[�o�[");
                        suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        // 2012/06/26 Y.Ito MOD END �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                    # region [�����f�[�^����]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 DEL
                    //List<int> list = new List<int>( _suppPrtPprWork.SupplierFormal );
                    //if ( list.Contains( 2 ) )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 ADD
                    if ( CheckSelectOdr( _suppPrtPprWork ) )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 ADD
                    {
                        iRecCnt = recordCount;

                        // SupplierFormat���X�g��2:�������܂܂��ꍇ�͔����f�[�^����
                        status = SearchRefProc( ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTblOdr, readMode, logicalMode, ref sqlConnection );
                        if ( (status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                            (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) )
                        {
                            //���s���G���[
                            throw new Exception( "�������s���G���[�FStatus=" + status.ToString() );
                        }
                        if ( recordCount >= _suppPrtPprWork.SearchCnt )
                        {
                            // 2012/06/26 Y.Ito MOD START �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                            //���������I�[�o�[
                            //throw new Exception("���������I�[�o�[");
                            suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // 2012/06/26 Y.Ito MOD END �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                        }
                    }
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                }
                #endregion
                
                #region [�x���f�[�^����]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 DEL
                //if (_suppPrtPprWork.SearchType != (int)SearchType.Sup && _suppPrtPprWork.PartySaleSlipNum == "") // ADD 2008.10.21 �`�[�����敪�� 1:�d���݈̂ȊO�̏ꍇ���� >>> 
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 ADD
                if ( CheckSelectPayment( _suppPrtPprWork ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 ADD
                {

                    iRecCnt = recordCount;
                    status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.PayTbl, readMode, logicalMode, ref sqlConnection);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //���s���G���[
                        throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                    }
                    if (recordCount >= _suppPrtPprWork.SearchCnt)
                    {
                        // 2012/06/26 Y.Ito MOD START �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                        //���������I�[�o�[
                        //throw new Exception("���������I�[�o�[");
                        suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        // 2012/06/26 Y.Ito MOD END �ۑ�No.1027 �����I�[�o�[���ɃG���[�ɂȂ錻�ۂ��C��
                    }   
                }
                #endregion

                #region [�c���Ɖ��]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
                //iRecCnt = recordCount;
                //status = SearchRefProc(ref suppPrtPprBlDspRsltArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.BlDsp, readMode, logicalMode, ref sqlConnection);
                //if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                //    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                //{
                //    //���s���G���[
                //    throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
                #endregion

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "�d����d�q����", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<

                //���s���ʃZ�b�g
                suppPrtPprBlDspRsltWork = suppPrtPprBlDspRsltArray;
                suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;

                // ADD 2008.11.26 >>>
                if ((suppPrtPprBlDspRsltWork != null) || (suppPrtPprStcTblRsltWork != null))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2008.11.26 <<<

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchProc Exception=" + ex.Message);
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 ADD
        /// <summary>
        /// �����f�[�^�������s�`�F�b�N����
        /// </summary>
        /// <param name="_suppPrtPprWork"></param>
        /// <returns></returns>
        /// <remarks>�����ʏ����N���X�̓��e���甭���f�[�^�����L���𔻒f���܂�</remarks>
        private bool CheckSelectOdr( SuppPrtPprWork paraWork )
        {
            // �󒍃X�e�[�^�X 2:�������܂܂Ȃ��Ȃ�I��
            List<int> list = new List<int>( paraWork.SupplierFormal );
            if ( !list.Contains( 2 ) ) return false;

            // �x���悪���͂���Ă�����I��
            if ( paraWork.PayeeCode != 0 ) return false;

            // �d���`�[�ԍ��w�肠��Ȃ�I��
            if ( paraWork.PartySaleSlipNum != string.Empty ) return false;

            // �l���敪�w�肠��Ȃ�I��
            if ( paraWork.StockSlipCdDtl != 0 ) return false;

            // �����f�[�^��������
            return true;
        }
        /// <summary>
        /// �x���f�[�^�������s�`�F�b�N����
        /// </summary>
        /// <param name="_suppPrtPprWork"></param>
        /// <returns></returns>
        /// <remarks>�����ʏ����N���X�̓��e����x���f�[�^�����L���𔻒f���܂�</remarks>
        private bool CheckSelectPayment( SuppPrtPprWork paraWork )
        {
            // �����^�C�v�F�d���f�[�^�݂̂Ȃ�ΉI��
            if ( paraWork.SearchType == (int)SearchType.Sup ) return false;

            // �d���`�[�ԍ��w�肠��Ȃ�I��
            if ( paraWork.PartySaleSlipNum != string.Empty ) return false;

            // UOE�����w�肠��Ȃ�I��
            if ( paraWork.WayToOrder != 0 ) return false;

            // ���l�Q�w�肠��Ȃ�I��
            if ( paraWork.SupplierSlipNote2 != string.Empty ) return false;

            // UOE�ϰ��P�w�肠��Ȃ�I��
            if ( paraWork.UoeRemark1 != string.Empty ) return false;

            // UOE�ϰ��Q�w�肠��Ȃ�I��
            if ( paraWork.UoeRemark2 != string.Empty ) return false;

            // �O���[�v�R�[�h�w�肠��Ȃ�I��
            if ( paraWork.BLGroupCode != 0 ) return false;

            // BL�R�[�h�w�肠��Ȃ�I��
            if ( paraWork.BLGoodsCode != 0 ) return false;

            // �i�Ԏw�肠��Ȃ�I��
            if ( paraWork.GoodsNo != string.Empty ) return false;

            // ���[�J�[�R�[�h�w�肠��Ȃ�I��
            if ( paraWork.GoodsMakerCd != 0 ) return false;

            // �݌Ɏ��敪�w�肠��Ȃ�I��
            if ( paraWork.StockOrderDivCd > -1 ) return false;

            // �q�ɃR�[�h�w�肠��Ȃ�I��
            if ( paraWork.WarehouseCode != string.Empty ) return false;

            // �l���敪�w�肠��Ȃ�I��
            if ( paraWork.StockSlipCdDtl != 0 ) return false;


            // �x���f�[�^��������
            return true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 ADD
        #endregion

        #region [SearchRefProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������`�[�\���E���ו\���f�[�^�̃��X�g�𒊏o���܂�(����f�[�^)
        /// </summary>
        /// <param name="rsltWorkArray">��������(�d���f�[�^)</param>
        /// <param name="_suppPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)�߂�l�p</param>
        /// <param name="iRecCnt">��������(����)�����`�F�b�N�p</param>
        /// <param name="iType">�����^�C�v</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private int SearchRefProc(ref ArrayList rsltWorkArray, SuppPrtPprWork _suppPrtPprWork, out Int64 recordCount, Int64 iRecCnt, int iType, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ISuppPrtPpr suppPrtPpr;
            suppPrtPpr = new SuppPrtPprStcTblRsltQuery();
            if (iType == (int)iSrcType.BlDsp) suppPrtPpr = new SuppPrtPprBlDspRsltQuery();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = suppPrtPpr.MakeSelectString(ref sqlCommand, _suppPrtPprWork, iType, logicalMode);

                // 2012/06/26 Y.Ito ADD START �^�C���A�E�g������
                sqlCommand.CommandTimeout = 3600;
                // 2012/06/26 Y.Ito ADD END �^�C���A�E�g������

                myReader = sqlCommand.ExecuteReader();

                //�����`�F�b�N�p�t���O
                bool bCuntChkFlg = false;
                if (iType == (int)iSrcType.BlDsp) bCuntChkFlg = true;

                while (myReader.Read())
                {
                    #region �����`�F�b�N
                    if (bCuntChkFlg != true)
                    {
                        bCuntChkFlg = true;  //�t���OON
                        //�Y���f�[�^�����擾
                        iRecCnt = iRecCnt + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROWNUM"));
                        // 2012/06/26 Y.Ito DEL START �����`�F�b�N�͂����ł͍s��Ȃ��B
                        //�����`�F�b�N
                        //if (iRecCnt >= _suppPrtPprWork.SearchCnt)
                        //{
                        //    //��������I�[�o�[�̏ꍇ��Break
                        //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        //    break;
                        //}
                        // 2012/06/26 Y.Ito DEL END �����`�F�b�N�͂����ł͍s��Ȃ��B
                    }
                    #endregion

                    //�擾���ʃZ�b�g
                    rsltWorkArray.Add(suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprWork, iType));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchRefProc_StcTbl Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            recordCount = iRecCnt;

            return status;
        }
        #endregion  //[SearchRefProc]

        #endregion  //[�c���Ɖ�E�`�[�\���E���ו\������]

        #region [�c���ꗗ����]

        #region [SearchBlTbl]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������c���ꗗ�\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="suppPrtPprBlTblRsltWork">��������</param>
        /// <param name="suppPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:�x�� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: </br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        public int SearchBlTbl(ref object suppPrtPprBlTblRsltWork, object suppPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            suppPrtPprBlTblRsltWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (suppPrtPprBlnceWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�c���ꗗ�p ArrayList
                ArrayList suppPrtPprBlTblRsltArray = suppPrtPprBlTblRsltWork as ArrayList;
                if (suppPrtPprBlTblRsltArray == null)
                {
                    suppPrtPprBlTblRsltArray = new ArrayList();
                }
                //�����p�����[�^
                SuppPrtPprBlnceWork _suppPrtPprBlnceWork = suppPrtPprBlnceWork as SuppPrtPprBlnceWork;
                #endregion  //[�p�����[�^�̃L���X�g]

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprBlnceWork.EnterpriseCode, "�d����d�q����", "���o�J�n");
                // ---ADD 2011/03/22----------<<<<<

                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                string[] sectionCodes = _suppPrtPprBlnceWork.SectionCode;
                if (sectionCodes != null)
                {
                    foreach (string sectionCode in sectionCodes)
                    {
                        _suppPrtPprBlnceWork.SectionCode = new string[] { sectionCode };
                        //SearchBlTbl���s
                        status = SearchBlTblProc(ref suppPrtPprBlTblRsltArray, _suppPrtPprBlnceWork, SrchKndDiv, readMode, logicalMode, ref sqlConnection);
                    }
                    if (suppPrtPprBlTblRsltArray.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                else
                {
                    // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
                    //SearchBlTbl���s
                    status = SearchBlTblProc(ref suppPrtPprBlTblRsltArray, _suppPrtPprBlnceWork, SrchKndDiv, readMode, logicalMode, ref sqlConnection);
                }// ADD 2010/07/20 

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprBlnceWork.EnterpriseCode, "�d����d�q����", "���o�I��");
                // ---ADD 2011/03/22----------<<<<<

                //���s���ʃZ�b�g
                suppPrtPprBlTblRsltWork = suppPrtPprBlTblRsltArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchProc Exception=" + ex.Message);
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
        #endregion  //[SearchBlTbl]

        #region [SearchBlTblProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������c���ꗗ�\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="rsltWorkArray">��������</param>
        /// <param name="_suppPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>UpdateNote : 2015/08/17 �c�v�t</br>
        /// <br>           �@Redmine#47007�F����łȂǂ��s���̏�Q�Ή�</br> 
        /// <br>Update Note: 2015/12/22 �ړ�</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00 2016�N1���z�M��</br>
        /// <br>             Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�A�Q�̑Ή�</br>
        /// <br>             ��Q�P:�������_�̎��т��o�͂���Ȃ� </br>
        /// <br>             ��Q�Q:�O����т��Ȃ��ꍇ�u�O��c���v�A�u�J�z�c���v�A�u����c���v�ɑO���_�́u����c���v���v���X����Ă��܂�</br>
        /// <br>Update Note: 2016/02/02 �ړ�</br>
        /// <br>�Ǘ��ԍ�   : 11200002-00 2016�N2���z�M��</br>
        /// <br>             Redmine#48327 �d�������I�v�V�������L���̏ꍇ�ɑS���_���̃��R�[�h���o�͂����т��Ȃ����̂�ALL�[���ɂ���</br>
        private int SearchBlTblProc(ref ArrayList rsltWorkArray, SuppPrtPprBlnceWork _suppPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // --- ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�̑Ή� ----->>>>>
            // ��ʂ���ŏ��̌��������̕ϐ����ꎞ�ޔ�
            int st_supplierCd = _suppPrtPprBlnceWork.St_SupplierCd;
            int ed_supplierCd = _suppPrtPprBlnceWork.Ed_SupplierCd;
            int payeeCode = _suppPrtPprBlnceWork.PayeeCode;
            // --- ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�̑Ή� -----<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ISuppPrtPpr suppPrtPpr;
            suppPrtPpr = new SuppPrtPprBlTblRsltQuery();
            // --- DEL 2016/02/02 �ړ� Redmine#48327 ----->>>>>
            //1���_1�d���敪���Ɏ擾���ꗗ��V�K����ׁA�����ɍ폜����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            //List<Int32> monthList = new List<Int32>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
            // --- DEL 2016/02/02 �ړ� Redmine#48327 -----<<<<<

            //----- ADD 2015/08/17 �c�v�t For Redmine#47007�F��Q2�@�o�͌������s���̏�Q�Ή�---------->>>>>
            ArrayList suplWorkList = new ArrayList();
            Dictionary<int, string> suppDic = new Dictionary<int, string>();

            if (_suppPrtPprBlnceWork.SearchDiv == 1)
            {
                // Excel�E�e�L�X�g�o�͂̏ꍇ�A�d���惊�X�g���擾
                GetSupplier(_suppPrtPprBlnceWork, ref suplWorkList, out suppDic, ref sqlConnection);
            }
            else
            {
                // ��ʂ���̏ꍇ�A�d���惊�X�g���擾
                suplWorkList.Add(_suppPrtPprBlnceWork.PayeeCode);
            }

            // �d����R�[�h�ɂ���ďo�͒l���擾����
            foreach (int supplierCd in suplWorkList)
            {
                _suppPrtPprBlnceWork.PayeeCode = supplierCd;
                _suppPrtPprBlnceWork.St_SupplierCd = supplierCd;
                _suppPrtPprBlnceWork.Ed_SupplierCd = supplierCd;

                // --- ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή� ----->>>>>
                //1���_1�d���敪�̎c���f�[�^�i�d����R�[�h���ς�����ꍇ�A�ēx�V�K�j�O���c���擾�p
                ArrayList rsltWorkArrayForLastTimeBlc = new ArrayList();
                // --- ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή� -----<<<<<
                // --- ADD 2016/02/02 �ړ� Redmine#48327 ----->>>>>
                //1���_1�d���敪���Ɏ擾���ꗗ��V�K����
                List<Int32> monthList = new List<Int32>();
                // --- ADD 2016/02/02 �ړ� Redmine#48327 -----<<<<<
            //----- ADD 2015/08/17 �c�v�t For Redmine#47007�F��Q2�@�o�͌������s���̏�Q�Ή� ----------<<<<<

                try
                {
                    sqlCommand = new SqlCommand("", sqlConnection);

                    //SELECT������
                    sqlCommand.CommandText = suppPrtPpr.MakeSelectString(ref sqlCommand, _suppPrtPprBlnceWork, SrchKndDiv, logicalMode);

                    // 2012/06/26 Y.Ito ADD START �^�C���A�E�g������
                    sqlCommand.CommandTimeout = 3600;
                    // 2012/06/26 Y.Ito ADD END �^�C���A�E�g������

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                        ////�擾���ʃZ�b�g
                        //rsltWorkArray.Add(suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprBlnceWork, SrchKndDiv));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                        //�擾���ʃZ�b�g
                        SuppPrtPprBlTblRsltWork retWork = (SuppPrtPprBlTblRsltWork)suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprBlnceWork, SrchKndDiv);
                        rsltWorkArray.Add(retWork);
                        rsltWorkArrayForLastTimeBlc.Add(retWork);// ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή�

                        //�擾���ꗗ�ǉ�
                        monthList.Add((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(retWork.AddUpYearMonth));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchBlTblProc Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (sqlCommand != null) sqlCommand.Dispose();
                    if (!myReader.IsClosed) myReader.Close();
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                if ( SrchKndDiv == (int)iSrchKndDiv.SuplAcc )
                {
                    FinYearTableGenerator finYearTableGenerator = this.GetFinYearTableGenerator(_suppPrtPprBlnceWork.EnterpriseCode, ref sqlConnection);
                    if (finYearTableGenerator != null)
                    {
                        # region [���������͈�]
                        // �O�񌎎����������擾
                        DateTime prevTotalDay = CheckPrcMonthlyAccRec(_suppPrtPprBlnceWork, ref sqlConnection);

                        // �w�茎�͈�
                        int monthCount = GetMonthsCount(_suppPrtPprBlnceWork.Ed_AddUpYearMonth, _suppPrtPprBlnceWork.St_AddUpYearMonth);
                        for (int monthIndex = 0; monthIndex < monthCount; monthIndex++)
                        {
                            DateTime targetMonth = _suppPrtPprBlnceWork.St_AddUpYearMonth.AddMonths(monthIndex);

                            // --- DEL 2012/11/08 ---------->>>>>
                            // �擾�ł��Ȃ��������ɑ΂��Ă̏���
                            //if ( !monthList.Contains( (Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM( targetMonth ) ) &&
                            //      (prevTotalDay < targetMonth) )
                            //{
                            //    //---------------------------------------------------
                            //    // ���В��ߌ��͈�
                            //    //---------------------------------------------------
                            //    # region [���В��ߌ��͈�]
                            //    DateTime stDate;
                            //    DateTime edDate;
                            //    finYearTableGenerator.GetDaysFromMonth( targetMonth, out stDate, out edDate );
                            //    # endregion
                            // --- DEL 2012/11/08 ----------<<<<<
                            // --- ADD 2012/11/08 ---------->>>>>
                            //---------------------------------------------------
                            // ���В��ߌ��͈�
                            //---------------------------------------------------
                            # region [���В��ߌ��͈�]
                            DateTime stDate;
                            DateTime edDate;
                            finYearTableGenerator.GetDaysFromMonth(targetMonth, out stDate, out edDate);
                            # endregion

                            // �擾�ł��Ȃ��������ɑ΂��Ă̏���
                            // --- ADD 2016/02/02 �ړ� Redmine#48327 ----->>>>>
                            //�d�������I�v�V�������L���̏ꍇ�A�O�񌎎����������Ɖ�ʂ���̑Ώ۔N���𖳎����A�S���_���̃��R�[�h���o�͂���B
                            //�d�������I�v�V�����������̏ꍇ�A�O�񌎎�������������ʂ���̑Ώ۔N���̃��R�[�h���o�͂���(�d�l�ۗ�)�B
                            if (!monthList.Contains((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(targetMonth)) &&
                                  ((!_suppPrtPprBlnceWork.OptSupplierSummary && (prevTotalDay < edDate)) || _suppPrtPprBlnceWork.OptSupplierSummary))
                            // --- ADD 2016/02/02 �ړ� Redmine#48327 -----<<<<<
                            // --- DEL 2016/02/02 �ړ� Redmine#48327 ----->>>>>
                            //if (!monthList.Contains((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(targetMonth)) &&
                            //      (prevTotalDay < edDate))
                            // --- DEL 2016/02/02 �ړ� Redmine#48327 -----<<<<<
                            {
                                // --- ADD 2012/11/08 ----------<<<<<

                                //---------------------------------------------------
                                // �����p�����[�^�Z�b�g
                                //---------------------------------------------------
                                # region [�����p�����[�^�Z�b�g]
                                SuplAccPayWork paraWork = new SuplAccPayWork();
                                paraWork.EnterpriseCode = _suppPrtPprBlnceWork.EnterpriseCode;                //��ƃR�[�h
                                //paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);// DEL 2015/08/17 �c�v�t For Redmine#47007 ��Q1 ����łȂǂ��s���̏�Q�Ή�

                                //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q1 ����łȂǂ��s���̏�Q�Ή�---------->>>>>
                                //�v��N����ݒ肷��
                                if (TDateTime.DateTimeToString("YYYYMM", prevTotalDay) == TDateTime.DateTimeToString("YYYYMM", targetMonth.AddMonths(-1)))
                                {
                                    paraWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                                }
                                else
                                {
                                    paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);
                                }
                                //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q1 ����łȂǂ��s���̏�Q�Ή� ----------<<<<<

                                paraWork.AddUpDate = edDate;
                                paraWork.AddUpYearMonth = targetMonth;                //�v��N��
                                paraWork.AddUpSecCode = _suppPrtPprBlnceWork.SectionCode[0];  //�v�㋒�_�R�[�h �����Ӑ�}�X�^���X�g����
                                paraWork.SupplierCd = _suppPrtPprBlnceWork.SupplierCd;     //���Ӑ�R�[�h   �����Ӑ�}�X�^���X�g����
                                if (paraWork.SupplierCd == 0)
                                {
                                    paraWork.SupplierCd = _suppPrtPprBlnceWork.PayeeCode;
                                }
                                //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q1 ����łȂǂ��s���̏�Q�Ή� ---------->>>>>
                                //�������쐬���鎞�A�d����R�[�h�Ɠ����l���x����ɃZ�b�g����AMAKAU00133RA�̎d���f�[�^�擾���\�b�h�ɁA�󂯂��p�����[�^�̎d����R�[�h���󂯂��p�����[�^�̎x����R�[�h�̎��A�d���f�[�^����������d�l������
                                if (paraWork.PayeeCode == 0)
                                {
                                    paraWork.PayeeCode = _suppPrtPprBlnceWork.PayeeCode;
                                }
                                //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q1 ����łȂǂ��s���̏�Q�Ή� ----------<<<<<
                                # endregion

                                //---------------------------------------------------
                                // ���|���E���|���Z�o���W���[���Ăяo��
                                //---------------------------------------------------
                                # region [���|���E���|���Z�o���W���[���Ăяo��]
                                MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
                                object paraObj = paraWork;
                                string retMsg;
                                // --- DEL 2012/09/13 ---------->>>>>
                                //int accStatus = monthlyAddUpDB.ReadSuplAccPay( ref paraObj, out retMsg, ref sqlConnection );
                                // --- DEL 2012/09/13 ----------<<<<<
                                // --- ADD 2012/09/13 ---------->>>>>
                                int accStatus = 0;
                                if (_suppPrtPprBlnceWork.OptSupplierSummary)
                                {
                                    // �d�������I�v�V�������L���̏ꍇ
                                    accStatus = monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj, out retMsg, ref sqlConnection);
                                }
                                else
                                {   // �d�������I�v�V�����������̏ꍇ
                                    accStatus = monthlyAddUpDB.ReadSuplAccPay(ref paraObj, out retMsg, ref sqlConnection);
                                }
                                // --- ADD 2012/09/13 ----------<<<<<

                                if (accStatus == 0)
                                {
                                    SuppPrtPprBlTblRsltWork rsltWork = new SuppPrtPprBlTblRsltWork();

                                    // ���ʃZ�b�g
                                    # region [���ʃZ�b�g]
                                    SuplAccPayWork retWork = (SuplAccPayWork)paraObj;
                                    //----- ADD 2015/08/17 �c�v�t For Redmine#47007�F��Q2�@�o�͌������s���̏�Q�Ή�---------->>>>>
                                    // Excel�E�e�L�X�g�o�͂̏ꍇ�A�d����R�[�h�Ƌ��_�R�[�h�Ǝd���於���擾����
                                    if (_suppPrtPprBlnceWork.SearchDiv == 1)
                                    {
                                        rsltWork.AddUpSecCode = retWork.AddUpSecCode;
                                        rsltWork.SupplierCd = retWork.PayeeCode;
                                        if (suppDic.ContainsKey(retWork.PayeeCode))
                                        {
                                            rsltWork.SupplierNm1 = suppDic[retWork.PayeeCode];
                                        }
                                    }
                                    //----- ADD 2015/08/17 �c�v�t For Redmine#47007�F��Q2�@�o�͌������s���̏�Q�Ή� ----------<<<<<
                                    rsltWork.AddUpDate = retWork.AddUpDate;
                                    rsltWork.LastTimeBlc = retWork.LastTimeAccPay;
                                    rsltWork.ThisTimePayNrml = retWork.ThisTimePayNrml;
                                    rsltWork.ThisTimeTtlBlc = retWork.ThisTimeTtlBlcAcPay;
                                    rsltWork.ThisTimeStockPrice = retWork.ThisTimeStockPrice;
                                    rsltWork.ThisStckPricRgdsDis = retWork.ThisStckPricRgds + retWork.ThisStckPricDis;
                                    rsltWork.OfsThisTimeStock = retWork.OfsThisTimeStock;
                                    rsltWork.OfsThisStockTax = retWork.OfsThisStockTax;
                                    rsltWork.ThisStckPricTotal = retWork.OfsThisTimeStock + retWork.OfsThisStockTax;
                                    rsltWork.StckTtlPayBlc = retWork.StckTtlAccPayBalance;
                                    rsltWork.StockSlipCount = retWork.StockSlipCount;
                                    # endregion

                                    // �O���c���̔��f
                                    # region [�O���c���̔��f]
                                    //int prevIndex = rsltWorkArray.Count - 1;// DEL 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή�
                                    int prevIndex = rsltWorkArrayForLastTimeBlc.Count - 1;// ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή�
                                    //-----ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q3 �擾���s�̏�Q�Ή�---------->>>>>
                                    if (prevIndex >= 0)
                                    {
                                    //----- ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q3 �擾���s�̏�Q�Ή� ----------<<<<<
                                        //rsltWork.LastTimeBlc = ((SuppPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).StckTtlPayBlc; // �O���c��// DEL 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή�
                                        rsltWork.LastTimeBlc = ((SuppPrtPprBlTblRsltWork)rsltWorkArrayForLastTimeBlc[prevIndex]).StckTtlPayBlc; // �O���c��// ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή�
                                        // ����J�z�c��(���|) = �O�񐿋��c�� - ����������z 
                                        rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimePayNrml;// ����J�z�c��(���|)
                                        // �v�Z�㐿�����z = ����J�z�c�� + (���E�㍡�񔄏���z + ���E�㍡�񔄏�����)
                                        rsltWork.StckTtlPayBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeStock + rsltWork.OfsThisStockTax);// �v�Z�㐿�����z
                                    } // ADD 2015/08/17 �c�v�t For Redmine#47007 ��Q3 �擾���s�̏�Q�Ή�
                                    # endregion

                                    rsltWorkArray.Add(rsltWork);
                                    rsltWorkArrayForLastTimeBlc.Add(rsltWork);// ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�Q�̑Ή�

                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                # endregion
                            }
                        }
                        # endregion
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

            }

            // --- ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�̑Ή� ----->>>>>
            //���o����O�ɉ�ʂ���̌�����������
            //-----------------------------------------------------------------------------------------------
            //���C����: 1���_�ڂ̎c���f�[�^���擾���鎞�A��ʂ���̌����������ύX����āA
            //1���_�ڈȍ~�̎d���惊�X�g�̎擾���ԈႢ�A�c���f�[�^�̎擾�͎��s�ɂȂ�
            //-----------------------------------------------------------------------------------------------
            _suppPrtPprBlnceWork.St_SupplierCd = st_supplierCd;
            _suppPrtPprBlnceWork.Ed_SupplierCd = ed_supplierCd;
            _suppPrtPprBlnceWork.PayeeCode = payeeCode;
            // --- ADD 2015/12/22 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�̑Ή� ----->>>>>
            return status;
        }

        //----- ADD 2015/08/17 �c�v�t For Redmine#47007�F��Q2�@�o�͌������s���̏�Q�Ή�---------->>>>>
        /// <summary>
        /// EXCEL�A�e�L�X�g�o�͉�ʎw�肳�ꂽ���������ɊY������d���惊�X�g�𒊏o����
        /// </summary>
        /// <param name="suppPrtPprBlnceWork">��������</param>
        /// <param name="suplWorkList">�d���惊�X�g</param>
        /// <param name="suppDic">�d������Dictionary</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2015/08/17 �c�v�t</br>
        /// <br>             Redmine#47007�F�o�͌������s���̏�Q�Ή�</br>
        /// <br>Update Note: 2015/12/25 �ړ�</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00 2016�N1���z�M��</br>
        /// <br>             Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�R�̑Ή�</br>
        /// <br>             ��Q�R�F�c���\���^�u�Ŏd�������I�v�V�������L���̏ꍇ�Ƀe�L�X�g�o�͂��s���Ǝd����R�[�h���x����R�[�h�̎c�����\������Ȃ�</br>
        /// </remarks>
        private int GetSupplier(SuppPrtPprBlnceWork suppPrtPprBlnceWork, ref ArrayList suplWorkList, out Dictionary<int, string> suppDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            suppDic = new Dictionary<int, string>();

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandTimeout = 600;
                    sqlCommand.Connection = sqlConnection;

                    #region [Select���쐬]
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "   A.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,A.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "  ,A.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "  SUPPLIERRF AS A" + Environment.NewLine;
                    sqlText += "  WITH(READUNCOMMITTED)" + Environment.NewLine;
                    //WHRERE��
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "  A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND A.LOGICALDELETECODERF=0" + Environment.NewLine;
                    // --- ADD 2015/12/25 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�R�̑Ή� ----->>>>>
                    //�d�������I�v�V�����������̏ꍇ�A�u�d���� = �x����v�A�u�x�����_����ʂ̏����͈͓��v�A�u�x�����_���L���ȋ��_�v�̌����������܂�
                    if (!suppPrtPprBlnceWork.OptSupplierSummary)
                    {
                        // --- ADD 2015/12/25 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�R�̑Ή� -----<<<<<
                        sqlText += "  AND A.SUPPLIERCDRF=A.PAYEECODERF" + Environment.NewLine;

                        //���_�R�[�h
                        if (suppPrtPprBlnceWork.SectionCode != null)
                        {
                            string sectionCodestr = "";
                            foreach (string seccdstr in suppPrtPprBlnceWork.SectionCode)
                            {
                                if (sectionCodestr != "")
                                {
                                    sectionCodestr += ",";
                                }
                                sectionCodestr += "'" + seccdstr + "'";
                            }
                            if (sectionCodestr != "")
                            {
                                sqlText += "AND A.PAYMENTSECTIONCODERF IN (" + sectionCodestr + ") ";
                                sqlText += "AND A.PAYMENTSECTIONCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF = 0)";
                            }
                            sqlText += Environment.NewLine;
                        }
                    }//ADD 2015/12/25 �ړ� Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�R�̑Ή�

                    if (suppPrtPprBlnceWork.St_SupplierCd != 0)
                    {
                        sqlText += "  AND A.SUPPLIERCDRF>=@FINDSUPPLIERCDST" + Environment.NewLine;
                        SqlParameter findParaSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCDST", SqlDbType.Int);
                        findParaSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(suppPrtPprBlnceWork.St_SupplierCd);
                    }
                    if (suppPrtPprBlnceWork.Ed_SupplierCd != 0)
                    {
                        sqlText += "  AND A.SUPPLIERCDRF<=@FINDSUPPLIERCDED" + Environment.NewLine;
                        SqlParameter findParaSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDED", SqlDbType.Int);
                        findParaSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(suppPrtPprBlnceWork.Ed_SupplierCd);
                    }

                    sqlText += " ORDER BY" + Environment.NewLine;
                    sqlText += "  A.SUPPLIERCDRF" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select���쐬]

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suppPrtPprBlnceWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        int supplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                        string supplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                        //�d����R�[�h�Ǝd���於���擾����
                        if (!suppDic.ContainsKey(supplierCd))
                        {
                            suppDic.Add(supplierCd, supplierName);
                        }
                        else
                        {
                            suppDic[supplierCd] = supplierName;
                        }

                        suplWorkList.Add(supplierCd);

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
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        //----- ADD 2015/08/17 �c�v�t For Redmine#47007�F��Q2�@�o�͌������s���̏�Q�Ή� ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
        /// <summary>
        /// ��v�N�x�e�[�u���������i�擾
        /// </summary>
        /// <returns></returns>
        private FinYearTableGenerator GetFinYearTableGenerator( string enterpriseCode, ref SqlConnection sqlConnection )
        {
            FinYearTableGenerator finYearTableGenerator = null;

            // ���Џ�񃌃R�[�h�擾
            CompanyInfDB companyInfDB = new CompanyInfDB();
            CompanyInfWork paraWork = new CompanyInfWork();
            paraWork.EnterpriseCode = enterpriseCode;
            ArrayList retList;
            companyInfDB.Search( out retList, paraWork, ref sqlConnection );
            if ( retList != null && retList.Count > 0 )
            {
                // ��v�N�x���i����
                finYearTableGenerator = new FinYearTableGenerator( (CompanyInfWork)retList[0] );
            }

            return finYearTableGenerator;
        }
        /// <summary>
        /// ���|���ς݃`�F�b�N
        /// </summary>
        /// <param name="custPrtPprBlnceWork"></param>
        private DateTime CheckPrcMonthlyAccRec( SuppPrtPprBlnceWork suppPrtPprBlnceWork, ref SqlConnection sqlConnection )
        {
            // ���σ`�F�b�N
            TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();

            TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
            paraWork.EnterpriseCode = suppPrtPprBlnceWork.EnterpriseCode;
            paraWork.SectionCode = suppPrtPprBlnceWork.SectionCode[0];
            paraWork.SupplierCd = suppPrtPprBlnceWork.SupplierCd;
            if ( paraWork.SupplierCd == 0 )
            {
                paraWork.SupplierCd = suppPrtPprBlnceWork.PayeeCode;
            }
            List<TtlDayCalcRetWork> retList;

            int status = ttlDayCalcDB.SearchHisMonthlyAccPay( out retList, paraWork, ref sqlConnection );
            if ( status == 0 && retList != null && retList.Count > 0 )
            {
                TtlDayCalcRetWork retWork = (TtlDayCalcRetWork)retList[0];
                DateTime totalDay;
                try
                {
                    if ( retWork.TotalDay != 0 )
                    {
                        totalDay = new DateTime( (retWork.TotalDay / 10000), ((retWork.TotalDay / 100) % 100), (retWork.TotalDay % 100) );
                    }
                    else
                    {
                        totalDay = DateTime.MinValue;
                    }
                }
                catch
                {
                    totalDay = DateTime.MinValue;
                }
                return totalDay;
            }

            return DateTime.MinValue;
        }
        /// <summary>
        /// �����Z�o
        /// </summary>
        /// <param name="edDate"></param>
        /// <param name="stDate"></param>
        /// <returns></returns>
        private int GetMonthsCount( DateTime edDate, DateTime stDate )
        {
            int difOfYear = edDate.Year - stDate.Year;
            int difOfMonth = edDate.Month - stDate.Month;

            return ((difOfYear * 12) + (difOfMonth)) + 1;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
        #endregion  //[SearchBlTblProc]

        #endregion  //[�c���ꗗ����]
    }

    interface ISuppPrtPpr
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, ConstantManagement.LogicalMode logicalMode);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam);
    }

    // ----------ADD 2013/01/21----------->>>>>
    interface ISuppPrtPprRetSch
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int logicalDelDiv);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork);
    }
    // ----------ADD 2013/01/21-----------<<<<<

    /// <summary>
    /// �`�[�E���ׂ̌����^�C�v��񋓂��܂��B
    /// </summary>
    enum iSrcType
    {
        StcTbl = 0,  //�d���f�[�^����
        PayTbl = 1,  //�x���f�[�^����
        BlDsp = 2,   //�c���Ɖ��
        BlTbl = 3,    //�c���ꗗ����(���g�p)
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
        StcTblOdr = 4, // �d��(�����f�[�^)����
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
    }

    /// <summary>
    /// �c���ꗗ�̌����^�C�v��񋓂��܂��B
    /// </summary>
    enum iSrchKndDiv
    {
        Suplier = 0,  //�d����x�����z�}�X�^
        SuplAcc = 1   //�d���攃�|���z�}�X�^
    }
    // ADD 2008.10.21 >>>
    /// <summary>
    /// �`�[�����敪��񋓂��܂��B
    /// </summary>
    enum SearchType
    {
        All = 0,  //0:�S��
        Sup = 1,  //1:�d���̂�
        Pay = 2   //2:�x���̂�
    }
    // ADD 2008.10.21 <<<
}
