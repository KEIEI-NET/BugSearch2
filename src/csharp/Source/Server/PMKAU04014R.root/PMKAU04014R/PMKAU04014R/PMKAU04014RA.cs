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
// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�d�q���� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q�������f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.30</br>
    /// <br></br>
    /// <br>Update Note: �s��C��</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.12.09</br>
    /// <br></br>
    /// <br>Update Note: ���ڒǉ�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.01.06 2009.01.30</br>
    /// <br></br>
    /// <br>Update Note: �s��C��( �̔��敪���̎擾�����̕s��C�� )</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009/05/12</br>
    /// <br></br>
    /// <br>Update Note: ���o�\�t�@�\�̒ǉ��ׁ̈A���o���ڂ�ǉ��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.08.10</br>
    /// <br></br>
    /// <br>Update Note: �ߋ����\���Ή��i����f�[�^�ɖ����A���㗚���ɂ��镪��ǉ��j</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.08.24</br>
    /// <br></br>
    /// <br>Update Note: �ߋ����\�����x�A�b�v�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009.09.04</br>
    /// <br></br>
    /// <br>Update Note: �\�����x�A�b�v�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009/10/05</br>
    /// <br></br>
    /// <br>Update Note: �yMANTIS:0015241�z���o�\�t�̏C��</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/04/02</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br></br>
    /// <br>Update Note: UOE�����f�[�^�̌��������s��Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/07</br>
    /// <br></br>
    /// <br>Update Note: READUNCOMMITTED�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/09</br>
    /// <br></br>
    /// <br>Update Note: �c���ꗗ�\���̑O��c�����C���i�O��{�O�X��{�O�X�X��j</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/12/20</br>
    /// <br>Update Note: ���N�n��</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2011/04/06 ������</br>
    /// <br>             Redmine#20387�̑Ή�</br>
    /// <br></br>
    /// <br>Update Note: �e�L�X�g�o�͂̎c���ꗗ�ɗ^�M�c����ǉ�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2013/03/13</br>
    /// <br>Update Note: 10800003-00�@2013/05/15�z�M�� Redmine#35205���Ӑ�d�q�����̑Ή�</br>
    /// <br>             �@�^�M�c���o�͌����s���̏C���B</br>
    /// <br>             �A�^�M�c���o�͏ꍇ�A���o�f�[�^�͑O���f�[�^�����ꍇ�A�O���̃f�[�^���폜</br>
    /// <br>Programmer : xuyb</br>
    /// <br>Date       : 2013/03/29</br>
    /// <br>Update Note: 10800003-00�@2013/05/15�z�M�� Redmine#35205���Ӑ�d�q�����̑Ή�</br>
    /// <br>             �^�M�c���o�͓��e�s���̏C���B</br>
    /// <br>Programmer : zhujw</br>
    /// <br>Date       : 2013/04/12</br>
    /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ�(VIN�R�[�h)�ɂ�钊�o���\�ɂ���</br>
    /// <br>Programmer : FSI���� �G</br>
    /// <br>Date       : 2013/03/25</br>
    /// <br>Update Note: Redmine#39753���Ӑ�d�q�����Ɏc���ꗗ�̏���ŕs���ɂȂ錏�̑Ή�</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date       : 2013/10/24</br>
    /// <br>Update Note: Redmine#41206 ��26�̑Ή�</br>
    /// <br>             ���Ӑ�d�q�����ɑΏ۔N��(�J�n)�ɔ��㌎���X�V���������̌����w�肵���ꍇ�A�c���ꗗ���\������Ȃ�</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date       : 2013/11/11</br>
    /// <br></br>
    /// <br>Update Note: �e�L�X�g�o�͂̎c���ꗗ�ɗ^�M�c����ǉ�</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2014/07/04</br>
    /// <br>Update Note: PM-SCM�d�|�ꗗ ��10666</br>
    /// <br>             BLP�̔����Ŏ����񓚂��������ԓ`���s����Ǝ��q��񂪏������Q�Ή�</br>
    /// <br>Update Note: 2015/02/05 ������</br>
    /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
    /// <br>UpdateNote : 2015/03/03 ������ Redmine#44701</br>
    /// <br>           : ��ʂ̔�������w�肳��Ȃ��ꍇ�A�����f�[�^����J�n�E�I������������������</br>
    /// <br>Update Note: K2016/02/23 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11200090-00 �C�P�� ���Ӑ�d�q����</br>
    /// <br>             ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
    /// <br>Update Note: 2022/05/05 ����</br>
    /// <br>�Ǘ��ԍ�   : 11870080-00</br>
    /// <br>           : �[�i���d�q����A�g�Ή�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CustPrtPprWorkDB : RemoteDB, ICustPrtPprWorkDB
    {
        // -- DEL 2009/09/04 --------------------->>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        //public Dictionary<string, string> _slipKeyDic;
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ---------------------<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        private SalesSlipDB _salesSlipDB = null; // ���ナ���[�g
        private StockSlipDB _stockSlipDB = null; // �d�������[�g  
        private SalesSlipHistDB _salesSlipHistDB = null; // ���㗚�������[�g
        private StockSlipHistDB _stockSlipHistDB = null; // �d�����������[�g
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

        /// <summary>
        /// ���Ӑ�d�q���� �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// </remarks>
        public CustPrtPprWorkDB()
        {
        }

        #region [�c���Ɖ�E�`�[�\���E���ו\������]

        #region [SearchRef]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������c���Ɖ�E�`�[�\���E���ו\���̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="custPrtPprBlDspRsltWork">��������(�c���Ɖ�)</param>
        /// <param name="custPrtPprSalTblRsltWork">��������(����f�[�^)</param>
        /// <param name="custPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2011/04/06 ������</br>
        /// <br>             ���엚��\���ŁA�@�\���u���Ӑ�d�q�����v��I�����āu�\���X�V�v�����s�������̍i�荞�݂�L���ɂ���ׁB</br>
        /// <br>UpdateNote : 2015/03/03 ������ Redmine#44701</br>
        /// <br>           : ���o���������Ȃ��̏ꍇ�A�����f�[�^�̌��������������폜����</br>
        /// <br>Update Note:K2016/02/23 ���V��</br>
        /// <br>            ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int SearchRef(ref object custPrtPprBlDspRsltWork, ref object custPrtPprSalTblRsltWork, object custPrtPprWork, out Int64 recordCount, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            // -- UPD 2009/10/05 MANTIS 14396---------------------------->>>
            //�ُ�I�����Ȃ��ꍇ�ł��A�S�Ă̌������ʂ�Ȃ��p�^�[���ŃG���[�ƂȂ��Ă��܂����߃X�e�[�^�X���C��
            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // -- UPD 2009/10/05 ----------------------------------------<<<
            SqlConnection sqlConnection = null;

            //������
            recordCount = 0;
            Int64 iRecCnt = 0;
            custPrtPprBlDspRsltWork = null;
            custPrtPprSalTblRsltWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (custPrtPprWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�c���Ɖ�p ArrayList
                ArrayList custPrtPprBlDspRsltArray = custPrtPprBlDspRsltWork as ArrayList;
                if (custPrtPprBlDspRsltArray == null)
                {
                    custPrtPprBlDspRsltArray = new ArrayList();
                }
                //����f�[�^�p ArrayList
                ArrayList custPrtPprSalTblRsltWorkArray = custPrtPprSalTblRsltWork as ArrayList;
                if (custPrtPprSalTblRsltWorkArray == null)
                {
                    custPrtPprSalTblRsltWorkArray = new ArrayList();
                }
                //�����p�����[�^
                CustPrtPprWork _custPrtPprWork = custPrtPprWork as CustPrtPprWork;
                #endregion  //[�p�����[�^�̃L���X�g]

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
               
                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "���Ӑ�d�q����", "���o�J�n"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "���Ӑ�d�q����", "���o�J�n", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<
                //Search���s
                #region [����f�[�^����]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 DEL
                //if (_custPrtPprWork.SearchType != (int)SearchType.Dep)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 ADD
                if ( CheckSelectSales( _custPrtPprWork ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 ADD
                {
                    // -- DEL 2009/09/04 ----------------------->>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                    //_slipKeyDic = new Dictionary<string, string>();
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                    // -- DEL 2009/09/04 -----------------------<<<

                    //�`�[�����敪���u�����̂݁v�ȊO�̏ꍇ�Ɍ���

                    //����f�[�^����
                    status = SearchRefProc(ref custPrtPprSalTblRsltWorkArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.SalTbl, readMode, logicalMode, ref sqlConnection);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //���s���G���[
                        throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                    }
                    // -- DEL 2009/10/05 --------------------------->>>
                    //�����������I�[�o�[�����ꍇ�ɗ�O�Ƃ��Ȃ��B���������̃I�[�o�[�͂t�h���Ŕ��f���āA���b�Z�[�W�\������
                    //if (recordCount >= _custPrtPprWork.SearchCnt)
                    //{
                    //    //���������I�[�o�[
                    //    throw new Exception("���������I�[�o�[");
                    //}
                    // -- DEL 2009/10/05 ---------------------------<<<

                    // -- DEL 2009/09/04 --------------------->>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                    //// ���㗚���f�[�^����(�ǉ�)
                    //iRecCnt = recordCount;
                    //status = SearchRefProc( ref custPrtPprSalTblRsltWorkArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.SalHisTbl, readMode, logicalMode, ref sqlConnection );
                    //if ( (status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    //    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) )
                    //{
                    //    //���s���G���[
                    //    throw new Exception( "�������s���G���[�FStatus=" + status.ToString() );
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                    // -- DEL 2009/09/04 ---------------------<<<
                }
                #endregion

                #region [�����f�[�^����]
                // -- UPD 2009/10/05 ------------------------------------->>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 DEL
                ////if (_custPrtPprWork.SearchType != (int)SearchType.Sal)
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 ADD
                //if ( CheckSelectDeposit( _custPrtPprWork ) )
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 ADD
                // ���o�������I�[�o�[���Ă��Ȃ��ꍇ�̂ݓ����f�[�^����������
                //if (CheckSelectDeposit(_custPrtPprWork) && (recordCount < _custPrtPprWork.SearchCnt-1)) // DEL 2015/03/03 ������ Redmine#44701 #36
                //----- ADD 2015/03/03 ������ Redmine#44701 #36 -------------------->>>>>
                if (( CheckSelectDeposit(_custPrtPprWork) && _custPrtPprWork.SearchCountCtrl == 1) ||
                    (CheckSelectDeposit(_custPrtPprWork) && _custPrtPprWork.SearchCountCtrl == 0 && recordCount < _custPrtPprWork.SearchCnt - 1))
                //----- ADD 2015/03/03 ������ Redmine#44701 #36 --------------------<<<<<
                // -- UPD 2009/10/05 -------------------------------------<<<
                {
                    //�`�[�����敪���u����̂݁v�ȊO�̏ꍇ�Ɍ���


                    //----- ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή� ----->>>>>
                    // �󒍍쐬�敪���u�ʏ�󒍓`�[�v/�u�`��UOE�󒍓`�[�v�̏ꍇ�A�����`�[����������Ȃ�
                    if (_custPrtPprWork.AcptAnOdrMakeDiv != 2 && _custPrtPprWork.AcptAnOdrMakeDiv != 3)
                    {
                    //----- ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή� -----<<<<<
                    iRecCnt = recordCount;
                    //�����f�[�^����
                    status = SearchRefProc(ref custPrtPprSalTblRsltWorkArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.DepTbl, readMode, logicalMode, ref sqlConnection);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //���s���G���[
                        throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                    }
                    }// ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�

                    // -- DEL 2009/10/05 ------------------------------->>>
                    //���o�������I�[�o�[�����ꍇ�ɗ�O�Ƃ��Ȃ��B���������̃I�[�o�[�͂t�h���Ŕ��f���āA���b�Z�[�W�\������
                    //if (recordCount >= _custPrtPprWork.SearchCnt)
                    //{
                    //    //���������I�[�o�[
                    //    throw new Exception("���������I�[�o�[");
                    //}
                    // -- DEL 2009/10/05 -------------------------------<<<

                }
                #endregion

                #region [�c���Ɖ��]
                iRecCnt = recordCount;
                //�c���Ɖ�����O�`�F�b�N
                if ((_custPrtPprWork.CustomerCode == 0) && (_custPrtPprWork.ClaimCode == 0))
                {
                    //���Ӑ�/������ -> �������͂Ȃ��͎擾���Ȃ�
                }
                else
                {
                    #region [���Ӑ�/������`�F�b�N]
                    //���Ӑ�/������ �ɐݒ肪����ꍇ
                    if ((_custPrtPprWork.CustomerCode != 0) && (_custPrtPprWork.ClaimCode == 0))
                    {
                        //���Ӑ悾��
                        //�����Ӑ�}�X������Read���\�b�h����A�Y�����Ӑ�̐�����R�[�h���擾���A
                        //�@���Ӑ�R�[�h�Ɛ�����R�[�h�����ꂼ�꓾�Ӑ搿�����z�}�X�^�ɓ���ēǂݍ���
                        #region [���Ӑ挟��]
                        CustomerDB customerDB = new CustomerDB();
                        CustomerWork[] customerWorkArray = new CustomerWork[1];  //���Ӑ���N���X�z��
                        string enterpriseCode = null;                            //��ƃR�[�h
                        int[] customerCodeArray = new Int32[1];                  //���Ӑ�R�[�h�z��
                        int[] statusArray = new Int32[1];                        //�X�e�[�^�X�z��

                        //�p�����[�^�Z�b�g
                        enterpriseCode = _custPrtPprWork.EnterpriseCode;         //��ƃR�[�h
                        customerCodeArray[0] = _custPrtPprWork.CustomerCode;     //���Ӑ�R�[�h

                        //���Ӑ挟�����s
                        status = customerDB.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //STATUS=0 -> ������R�[�h�Z�b�g
                            _custPrtPprWork.ClaimCode = customerWorkArray[0].ClaimCode;
                        }
                        else
                        {
                            //���s���G���[
                            throw new Exception("���Ӑ�}�X�^Read���s:Status=" + status.ToString());
                        }
                        #endregion  //[[���Ӑ挟��]
                    }
                    else if ((_custPrtPprWork.CustomerCode == 0) && (_custPrtPprWork.ClaimCode != 0))
                    {
                        //�����悾��
                        //��������R�[�h�𓾈Ӑ搿�����z�}�X�^�̓��Ӑ�R�[�h�Ɛ�����R�[�h�ɓ���ēǂݍ���
                        _custPrtPprWork.CustomerCode = _custPrtPprWork.ClaimCode;
                    }
                    #endregion  //[���Ӑ�/������`�F�b�N]

                    #region [�����`�F�b�N]
                    TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();
                    List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                    TtlDayCalcParaWork para = new TtlDayCalcParaWork();
                    para.EnterpriseCode = _custPrtPprWork.EnterpriseCode;  //��ƃR�[�h
                    para.CustomerCode = _custPrtPprWork.CustomerCode;      //���Ӑ�R�[�h
                    status = ttlDayCalcDB.SearchPrcDmdC(out retList, para, ref sqlConnection);
                    #endregion  //[�����`�F�b�N]

                    #region [�c���Ɖ��]
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //STATUS=0 -> �c���Ɖ�����s
                        //�v��N�����擾
                        _custPrtPprWork.AddUpYearMonth = DateTime.ParseExact(retList[0].TotalDay.ToString(), "yyyyMMdd", null);
                        //�c���Ɖ�����s
                        status = SearchRefProc(ref custPrtPprBlDspRsltArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.BlDsp, readMode, logicalMode, ref sqlConnection);
                        if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                            (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                        {
                            //���s���G���[
                            throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        //���ߏ��Ȃ� -> STATUS=0��UI�ɕԂ�
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //���s���G���[
                        throw new Exception("�������擾���s:Status=" + status.ToString());
                    }
                    #endregion  //[�c���Ɖ��]
                }
                #endregion

                // --- ADD 2011/03/22----------------------------------->>>>>
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "���Ӑ�d�q����", "���o�I��"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "���Ӑ�d�q����", "���o�I��", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<
                //���s���ʃZ�b�g
                custPrtPprBlDspRsltWork = custPrtPprBlDspRsltArray;
                custPrtPprSalTblRsltWork = custPrtPprSalTblRsltWorkArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchProc Exception=" + ex.Message);
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 ADD
        /// <summary>
        /// ����f�[�^���o�`�F�b�N����
        /// </summary>
        /// <param name="paramWork"></param>
        /// <returns></returns>
        private bool CheckSelectSales( CustPrtPprWork paramWork )
        {
            // �����敪
            if ( paramWork.SearchType == (int)SearchType.Dep ) return false;


            // ��L�ȊO�͒��o����
            return true;
        }

        /// <summary>
        /// �����f�[�^���o�`�F�b�N����
        /// </summary>
        /// <param name="paramWork"></param>
        /// <returns></returns>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ�(VIN�R�[�h)�ɂ�钊�o���\�ɂ���</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/25</br>
        private bool CheckSelectDeposit(CustPrtPprWork paramWork)
        {
            // �����敪
            if ( paramWork.SearchType == (int)SearchType.Sal ) return false;

            ////�󒍃X�e�[�^�X
            //if ( paramWork.AcptAnOdrStatus != null ) return false;
            ////����`�[�敪
            //if ( paramWork.SalesSlipCd != null ) return false;
            //����`�[�ԍ�
            if ( paramWork.SalesSlipNum != "" ) return false;
            //�󒍎�(��t�]�ƈ��R�[�h)
            if ( paramWork.FrontEmployeeCd != "" ) return false;
            //���Ӑ撍��(�����`�[�ԍ�)
            if ( paramWork.PartySaleSlipNum != "" ) return false;
            //���l�Q(�`�[���l�Q) �������܂���������
            if ( paramWork.SlipNote2 != "" ) return false;
            //���l�R(�`�[���l�R) �������܂���������
            if ( paramWork.SlipNote3 != "" ) return false;
            //�t�n�d���}�[�N�P �������܂���������
            if ( paramWork.UoeRemark1 != "" ) return false;
            //�t�n�d���}�[�N�Q �������܂���������
            if ( paramWork.UoeRemark2 != "" ) return false;


            //�Ǘ��ԍ�(���q�Ǘ��R�[�h)
            if ( paramWork.CarMngCode != "" ) return false;
            //�Ԏ햼��(�Ԏ�S�p����) �������܂���������
            if ( paramWork.ModelFullName != "" ) return false;
            //�^��(�^��(�t���^)) �������܂���������
            if ( paramWork.FullModel != "" ) return false;
            //�ԑ䇂(�ԑ�ԍ�(�����p))
            if ( paramWork.SearchFrameNo != 0 ) return false;
            // --- ADD 2013/03/25 ---------->>>>>
            //�ԑ䇂(�ԑ�ԍ�)
            if (paramWork.FrameNo != "") return false;
            // --- ADD 2013/03/25 ----------<<<<<
            //�J���[����(�J���[����1) �������܂���������
            if ( paramWork.ColorName1 != "" ) return false;
            //�g�������� �������܂���������
            if ( paramWork.TrimName != "" ) return false;
            //UOE���M(�f�[�^���M�敪)
            if ( paramWork.DataSendCode != 0 ) return false;
            //�a�k�O���[�v(BL�O���[�v�R�[�h)
            if ( paramWork.BLGroupCode != 0 ) return false;
            //�a�k�R�[�h(BL���i�R�[�h)
            if ( paramWork.BLGoodsCode != 0 ) return false;
            //�i��(���i����) �������܂���������
            if ( paramWork.GoodsName != "" ) return false;
            //�i��(���i�ԍ�) �������܂���������
            if ( paramWork.GoodsNo != "" ) return false;
            //���[�J�[(���i���[�J�[�R�[�h)
            if ( paramWork.GoodsMakerCd != 0 ) return false;
            //�̔��敪�R�[�h
            if ( paramWork.SalesCode != 0 ) return false;
            //���Е��ރR�[�h
            if ( paramWork.EnterpriseGanreCode != 0 ) return false;
            //�݌Ɏ��敪(����݌Ɏ�񂹋敪)
            if ( paramWork.SalesOrderDivCd != -1 ) return false;
            //�q�ɃR�[�h
            if ( paramWork.WarehouseCode != "" ) return false;
            //�d���`�[�ԍ�
            if ( paramWork.SupplierSlipNo != "" ) return false;
            //�d����(�d����R�[�h)
            if ( paramWork.SupplierCd != 0 ) return false;
            //������
            if ( paramWork.UOESupplierCd != 0 ) return false;
            //���ה��l �������܂���������
            if ( paramWork.DtlNote != "" ) return false;
            //�[�i��R�[�h
            if ( paramWork.AddresseeCode != 0 ) return false;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            // ���i����
            if ( paramWork.GoodsKindCode != -1 ) return false;
            // ���i�啪�ރR�[�h
            if ( paramWork.GoodsLGroup != 0 ) return false;
            // ���i�����ރR�[�h
            if ( paramWork.GoodsMGroup != 0 ) return false;
            // �I��
            if ( paramWork.WarehouseShelfNo != string.Empty ) return false;
            // ����`�[�敪(����)
            if ( paramWork.SalesSlipCdDtl != 0 ) return false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD


            // ��L�ȊO�͒��o����
            return true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 ADD

        #endregion  //[SearchRef]

        #region [SearchRefProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������`�[�\���E���ו\���f�[�^�̃��X�g�𒊏o���܂�(����f�[�^)
        /// </summary>
        /// <param name="rsltWorkArray">��������(����f�[�^)</param>
        /// <param name="_custPrtPprWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)�߂�l�p</param>
        /// <param name="iRecCnt">��������(����)�����`�F�b�N�p</param>
        /// <param name="iType">�����^�C�v</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private int SearchRefProc(ref ArrayList rsltWorkArray, CustPrtPprWork _custPrtPprWork, out Int64 recordCount, Int64 iRecCnt, int iType, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ICustPrtPpr custPrtPpr;

            // -- DEL 2009/09/04 ----------------------------->>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
            ////custPrtPpr = new CustPrtPprSalTblRsltQuery();
            ////if (iType == (int)iSrcType.BlDsp) custPrtPpr = new CustPrtPprBlDspRsltQuery();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
            //if ( iType != (int)iSrcType.BlDsp )
            //{
            //    // ����E�������חp
            //    custPrtPpr = new CustPrtPprSalTblRsltQuery();
            //    if ( iType == (int)iSrcType.SalTbl || iType == (int)iSrcType.SalHisTbl )
            //    {
            //        (custPrtPpr as CustPrtPprSalTblRsltQuery).SalesSlipHisKeyDic = _slipKeyDic;
            //    }
            //}
            //else
            //{
            //    // �c���Ɖ�p
            //    custPrtPpr = new CustPrtPprBlDspRsltQuery();
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
            // -- DEL 2009/09/04 -----------------------------<<<

            // -- ADD 2009/09/04 -------------------------->>>
            custPrtPpr = new CustPrtPprSalTblRsltQuery();
            if (iType == (int)iSrcType.BlDsp) custPrtPpr = new CustPrtPprBlDspRsltQuery();
            // -- ADD 2009/09/04 --------------------------<<<

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprWork, iType, logicalMode);

                //string txt = "declare @ENTERPRISECODE nchar(16) set @ENTERPRISECODE='0105130551011800' declare @ENTERPRISECODE2 nchar(16) set @ENTERPRISECODE2='0105130551011800' declare @FINDLOGICALDELETECODE int set @FINDLOGICALDELETECODE=0 declare @RESULTSADDUPSECCD nchar(6) set @RESULTSADDUPSECCD='01' declare @STSALESDATE int set @STSALESDATE=20090401 declare @EDSALESDATE int set @EDSALESDATE=20090430 ";


                //sqlCommand.CommandText = txt + "SELECT TOP 20002      SALSLP.SALESDATERF     ,SALSLP.SALESSLIPNUMRF     ,SALSLP.SALESROWNORF     ,SALSLP.ACPTANODRSTATUSRF     ,SALSLP.SALESSLIPCDRF     ,SALSLP.SALESEMPLOYEENMRF     ,SALSLP.SALESTOTALTAXEXCRF     ,SALSLP.SALESTOTALTAXINCRF     ,SALSLP.GOODSNAMERF     ,SALSLP.GOODSNORF     ,SALSLP.BLGOODSCODERF     ,SALSLP.BLGROUPCODERF     ,SALSLP.SHIPMENTCNTRF     ,SALSLP.LISTPRICETAXEXCFLRF     ,SALSLP.OPENPRICEDIVRF     ,SALSLP.SALESUNPRCTAXEXCFLRF     ,SALSLP.SALESUNITCOSTRF     ,SALSLP.SALESMONEYTAXEXCRF     ,SALSLP.CONSTAXLAYMETHODRF     ,SALSLP.SALESPRICECONSTAXRF     ,SALSLP.TOTALCOSTRF     ,AODCAR.MODELDESIGNATIONNORF     ,AODCAR.CATEGORYNORF     ,AODCAR.MODELFULLNAMERF     ,AODCAR.FIRSTENTRYDATERF     ,AODCAR.SEARCHFRAMENORF     ,AODCAR.FULLMODELRF     ,SALSLP.SLIPNOTERF     ,SALSLP.SLIPNOTE2RF     ,SALSLP.SLIPNOTE3RF     ,SALSLP.FRONTEMPLOYEENMRF     ,SALSLP.SALESINPUTNAMERF     ,SALSLP.CUSTOMERCODERF     ,SALSLP.CUSTOMERSNMRF     ,SALSLP.SUPPLIERCDRF     ,SALSLP.SUPPLIERSNMRF     ,SALSLP.PARTYSALESLIPNUMRF     ,AODCAR.CARMNGCODERF     ,SALSLP.ACCEPTANORDERNORF     ,SALSLP.SHIPMSALESSLIPNUM     ,SALSLP.SRCSALESSLIPNUM     ,SALSLP.SALESORDERDIVCDRF     ,SALSLP.WAREHOUSENAMERF     ,STCDTL.SUPPLIERSLIPNORF     ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD     ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM     ,SALSLP.UOEREMARK1RF     ,SALSLP.UOEREMARK2RF     ,USRGBU.GUIDENAMERF     ,SCINFS.SECTIONGUIDENMRF     ,SALSLP.DTLNOTERF     ,AODCAR.COLORNAME1RF     ,AODCAR.TRIMNAMERF     ,SALSLP.STDUNPRCLPRICERF     ,SALSLP.STDUNPRCSALUNPRCRF     ,SALSLP.STDUNPRCUNCSTRF     ,SALSLP.GOODSMAKERCDRF     ,SALSLP.MAKERNAMERF     ,SALSLP.COSTRF     ,SALSLP.CUSTSLIPNORF     ,SALSLP.ADDUPADATERF     ,SALSLP.ACCRECDIVCDRF     ,SALSLP.DEBITNOTEDIVRF     ,SALSLP.SECTIONCODERF     ,SALSLP.WAREHOUSECODERF     ,SALSLP.ACPTANODRREMAINCNTRF     ,SALSLP.TOTALAMOUNTDISPWAYCDRF     ,SALSLP.TAXATIONDIVCDRF     ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF     ,SALSLP.SHIPMENTDAYRF     ,SALSLP.ADDRESSEECODERF     ,SALSLP.ADDRESSEENAMERF     ,SALSLP.ADDRESSEENAME2RF     ,AODCAR.FRAMENORF     ,SALSLP.ENTERPRISEGANRECODERF     ,SALSLP.SEARCHSLIPDATERF     ,SALSLP.GOODSKINDCODERF     ,SALSLP.GOODSLGROUPRF     ,SALSLP.GOODSMGROUPRF     ,SALSLP.WAREHOUSESHELFNORF     ,SALSLP.SALESSLIPCDDTLRF     ,SALSLP.GOODSLGROUPNAMERF     ,SALSLP.GOODSMGROUPNAMERF     ,SALSLP.DELIVEREDGOODSDIVRF     ,AODCAR.CARMNGNORF     ,AODCAR.MAKERCODERF     ,AODCAR.MODELCODERF     ,AODCAR.MODELSUBCODERF     ,AODCAR.ENGINEMODELNMRF     ,AODCAR.COLORCODERF     ,AODCAR.TRIMCODERF     ,AODCAR.FULLMODELFIXEDNOARYRF     ,AODCAR.CATEGORYOBJARYRF     ,SALSLP.SALESINPUTCODERF     ,SALSLP.FRONTEMPLOYEECDRF     ,SALSLP.HISTORYDIVRF    FROM (     SELECT       SALSLPSUB.ENTERPRISECODERF      ,SALSLPSUB.SALESDATERF      ,SALSLPSUB.SALESSLIPNUMRF      ,SALSLPSUB.ACPTANODRSTATUSRF      ,SALSLPSUB.SALESSLIPCDRF      ,SALSLPSUB.SALESEMPLOYEENMRF      ,SALSLPSUB.SALESTOTALTAXEXCRF      ,SALSLPSUB.SALESTOTALTAXINCRF      ,SALSLPSUB.CONSTAXLAYMETHODRF      ,SALSLPSUB.TOTALCOSTRF      ,SALSLPSUB.SLIPNOTERF      ,SALSLPSUB.SLIPNOTE2RF      ,SALSLPSUB.SLIPNOTE3RF      ,SALSLPSUB.FRONTEMPLOYEENMRF      ,SALSLPSUB.SALESINPUTNAMERF      ,SALSLPSUB.CUSTOMERCODERF      ,SALSLPSUB.CUSTOMERSNMRF      ,SALSLPSUB.PARTYSALESLIPNUMRF      ,SALSLPSUB.UOEREMARK1RF      ,SALSLPSUB.UOEREMARK2RF      ,SALSLPSUB.CUSTSLIPNORF      ,SALSLPSUB.ADDUPADATERF      ,SALSLPSUB.ACCRECDIVCDRF      ,SALSLPSUB.DEBITNOTEDIVRF      ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF      ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF      ,SALSLPSUB.SHIPMENTDAYRF      ,SALSLPSUB.ADDRESSEECODERF      ,SALSLPSUB.ADDRESSEENAMERF      ,SALSLPSUB.ADDRESSEENAME2RF      ,SALSLPSUB.SEARCHSLIPDATERF      ,SALSLPSUB.DELIVEREDGOODSDIVRF      ,SALSLPSUB.SALESINPUTCODERF      ,SALSLPSUB.FRONTEMPLOYEECDRF      ,SALDTL.SALESROWNORF      ,SALDTL.GOODSNAMERF      ,SALDTL.GOODSNORF      ,SALDTL.BLGOODSCODERF      ,SALDTL.BLGROUPCODERF      ,SALDTL.SHIPMENTCNTRF      ,SALDTL.LISTPRICETAXEXCFLRF      ,SALDTL.OPENPRICEDIVRF      ,SALDTL.SALESUNPRCTAXEXCFLRF      ,SALDTL.SALESUNITCOSTRF      ,SALDTL.SALESMONEYTAXEXCRF      ,SALDTL.SALESPRICECONSTAXRF      ,SALDTL.SUPPLIERCDRF      ,SALDTL.SUPPLIERSNMRF      ,SALDTL2.ACCEPTANORDERNORF      ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM      ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM      ,SALDTL.SALESORDERDIVCDRF      ,SALDTL.WAREHOUSENAMERF      ,SALDTL.DTLNOTERF      ,SALDTL.STDUNPRCLPRICERF      ,SALDTL.STDUNPRCSALUNPRCRF      ,SALDTL.STDUNPRCUNCSTRF      ,SALDTL.GOODSMAKERCDRF      ,SALDTL.MAKERNAMERF      ,SALDTL.COSTRF      ,SALDTL.WAREHOUSECODERF      ,SALDTL3.ACPTANODRREMAINCNTRF      ,SALDTL.TAXATIONDIVCDRF      ,SALDTL.ENTERPRISEGANRECODERF      ,SALDTL.GOODSKINDCODERF      ,SALDTL.GOODSLGROUPRF      ,SALDTL.GOODSMGROUPRF      ,SALDTL.WAREHOUSESHELFNORF      ,SALDTL.SALESSLIPCDDTLRF      ,SALDTL.GOODSLGROUPNAMERF      ,SALDTL.GOODSMGROUPNAMERF      ,SALDTL.COMMONSEQNORF      ,SALDTL.SUPPLIERFORMALSYNCRF      ,SALDTL.STOCKSLIPDTLNUMSYNCRF      ,SALDTL.SALESCODERF      ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1      ,(CASE WHEN SALDTL3.ACPTANODRREMAINCNTRF IS NULL THEN 1 ELSE 0 END) AS HISTORYDIVRF     FROM SALESHISTORYRF AS SALSLPSUB     LEFT JOIN SALESHISTDTLRF SALDTL    ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF    AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF    AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF    LEFT JOIN SALESHISTDTLRF SALDTL2    ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF    AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF    AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF    LEFT JOIN SALESDETAILRF SALDTL3    ON  SALDTL3.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF    AND SALDTL3.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF    AND SALDTL3.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF   WHERE   SALSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE   AND SALSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE   AND SALSLPSUB.RESULTSADDUPSECCDRF=@RESULTSADDUPSECCD    AND ((SALSLPSUB.SALESDATERF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))   AND ((SALSLPSUB.SALESDATERF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))   AND SALSLPSUB.ACPTANODRSTATUSRF IN (30)    AND SALSLPSUB.SALESSLIPCDRF IN (0,1)     ) AS SALSLP    LEFT JOIN ACCEPTODRCARRF AODCAR    ON  AODCAR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND AODCAR.ACCEPTANORDERNORF=SALSLP.ACCEPTANORDERNORF_1    AND (           (SALSLP.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1)         OR (SALSLP.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)        OR (SALSLP.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)        OR (SALSLP.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)      )    LEFT JOIN UOEORDERDTLRF UOEODR    ON  UOEODR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND UOEODR.COMMONSEQNORF=SALSLP.COMMONSEQNORF    LEFT JOIN SECINFOSETRF SCINFS    ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF    LEFT JOIN STOCKDETAILRF STCDTL    ON  STCDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND STCDTL.SUPPLIERFORMALRF=SALSLP.SUPPLIERFORMALSYNCRF    AND STCDTL.STOCKSLIPDTLNUMRF=SALSLP.STOCKSLIPDTLNUMSYNCRF    LEFT JOIN STOCKSLIPRF STCSLP    ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF    AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF    AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF    LEFT JOIN BLGROUPURF BLGRPU    ON  BLGRPU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND BLGRPU.BLGROUPCODERF=SALSLP.BLGROUPCODERF    LEFT JOIN USERGDBDURF USRGBU    ON  USRGBU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND USRGBU.USERGUIDEDIVCDRF=71    AND USRGBU.GUIDECODERF=SALSLP.SALESCODERF   WHERE   SALSLP.ENTERPRISECODERF=@ENTERPRISECODE2  ";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                sqlCommand.CommandTimeout = 3600;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD

                myReader = sqlCommand.ExecuteReader();

                //�����`�F�b�N�p�t���O
                bool bCuntChkFlg = false;
                if (iType == (int)iSrcType.BlDsp) bCuntChkFlg = true;
                //----- ADD 2015/02/05 ������ -------------------->>>>>
                // ���o���������Ȃ��̏ꍇ
                if (_custPrtPprWork.SearchCountCtrl == 1) bCuntChkFlg = true;
                //----- ADD 2015/02/05 ������ --------------------<<<<<

                while (myReader.Read())
                {
                    #region �����`�F�b�N
                    // -- UPD 2009/10/05 ---------------------------->>>
                    //if (bCuntChkFlg != true)
                    //{
                    //    bCuntChkFlg = true;  //�t���OON
                    //    //�Y���f�[�^�����擾
                    //    iRecCnt = iRecCnt + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROWNUM"));
                    //    //�����`�F�b�N
                    //    if (iRecCnt >= _custPrtPprWork.SearchCnt)
                    //    {
                    //        //��������I�[�o�[�̏ꍇ��Break
                    //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //        break;
                    //    }
                    //}
                    // -- UPD 2009/10/05 ----------------------------<<<
                    #endregion

                    //�擾���ʃZ�b�g
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
                    //rsltWorkArray.Add( custPrtPpr.CopyToResultWorkFromReader( ref myReader, _custPrtPprWork, iType ) );
                    //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD

                    object retWork = custPrtPpr.CopyToResultWorkFromReader( ref myReader, _custPrtPprWork, iType );
                    if ( retWork != null )
                    {
                        rsltWorkArray.Add( retWork );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        // -- ADD 2009/10/05 ---------------------------->>>
                        if (bCuntChkFlg != true)
                        {
                            iRecCnt++;
                            if (iRecCnt >= _custPrtPprWork.SearchCnt)
                            {
                                //��������I�[�o�[�̏ꍇ��Break
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                recordCount = iRecCnt;
                                break;
                            }
                        }
                        // -- ADD 2009/10/05 ----------------------------<<<
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchRefProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                // -- UPD 2009/10/05 -------------------->>>
                //if (!myReader.IsClosed) myReader.Close();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
                // -- UPD 2009/10/05 --------------------<<<
                
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
        /// <param name="custPrtPprBlTblRsltWork">��������</param>
        /// <param name="custPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2011/04/06 ������</br>
        /// <br>             ���엚��\���ŁA�@�\���u���Ӑ�d�q�����v��I�����āu�\���X�V�v�����s�������̍i�荞�݂�L���ɂ���ׁB</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int SearchBlTbl(ref object custPrtPprBlTblRsltWork, object custPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            custPrtPprBlTblRsltWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (custPrtPprBlnceWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�c���ꗗ�p ArrayList
                ArrayList custPrtPprBlTblRsltArray = custPrtPprBlTblRsltWork as ArrayList;
                if (custPrtPprBlTblRsltArray == null)
                {
                    custPrtPprBlTblRsltArray = new ArrayList();
                }
                //�����p�����[�^
                CustPrtPprBlnceWork _custPrtPprBlnceWork = custPrtPprBlnceWork as CustPrtPprBlnceWork;
                #endregion  //[�p�����[�^�̃L���X�g]

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "���Ӑ�d�q����", "���o�J�n"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "���Ӑ�d�q����", "���o�J�n", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<

                //SearchBlTbl���s
                status = SearchBlTblProc(ref custPrtPprBlTblRsltArray, _custPrtPprBlnceWork, SrchKndDiv, readMode, logicalMode, ref sqlConnection);

                // --- ADD 2011/03/22----------------------------------->>>>>
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "���Ӑ�d�q����", "���o�I��"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "���Ӑ�d�q����", "���o�I��", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<
                //���s���ʃZ�b�g
                custPrtPprBlTblRsltWork = custPrtPprBlTblRsltArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchProc Exception=" + ex.Message);
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
        /// <param name="_custPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753���Ӑ�d�q�����Ɏc���ꗗ�̏���ŕs���ɂȂ錏�̑Ή�</br>
        /// <br>Update Note: 2013/11/11 gezh</br>
        /// <br>             Redmine#41206�̇�26 ���Ӑ�d�q�����ɑΏ۔N��(�J�n)�ɔ��㌎���X�V���������̌����w�肵���ꍇ�A�c���ꗗ���\������Ȃ��̑Ή�</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private int SearchBlTblProc(ref ArrayList rsltWorkArray, CustPrtPprBlnceWork _custPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //ICustPrtPpr custPrtPpr;
            ICustPrtPprOutput custPrtPpr;
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
            custPrtPpr = new CustPrtPprBlTblRsltQuery();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            List<Int32> monthList = new List<Int32>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                //sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, logicalMode);
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, false, logicalMode);
                // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                    ////�擾���ʃZ�b�g
                    //rsltWorkArray.Add(custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv));
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                    //�擾���ʃZ�b�g
                    // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                    //CustPrtPprBlTblRsltWork retWork = (CustPrtPprBlTblRsltWork)custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv);
                    CustPrtPprBlTblRsltWork retWork = (CustPrtPprBlTblRsltWork)custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv, false);
                    // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
                    rsltWorkArray.Add(retWork);

                    //�擾���ꗗ�ǉ�
                    monthList.Add( (Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM( retWork.AddUpYearMonth ) );
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
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchBlTblProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                // -- UPD 2009/10/05 -------------------->>>
                //if (!myReader.IsClosed) myReader.Close();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
                // -- UPD 2009/10/05 --------------------<<<

            }


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            if ( SrchKndDiv == (int)iSrchKndDiv.CustAcc )
            {
                FinYearTableGenerator finYearTableGenerator = this.GetFinYearTableGenerator( _custPrtPprBlnceWork.EnterpriseCode, ref sqlConnection );
                if ( finYearTableGenerator != null )
                {
                    # region [���������͈�]
                    // �O�񌎎����������擾
                    DateTime prevTotalDay = CheckPrcMonthlyAccRec( _custPrtPprBlnceWork, ref sqlConnection );

                    // �w�茎�͈�
                    int monthCount = GetMonthsCount( _custPrtPprBlnceWork.Ed_AddUpYearMonth, _custPrtPprBlnceWork.St_AddUpYearMonth );
                    for ( int monthIndex = 0; monthIndex < monthCount; monthIndex++ )
                    {
                        DateTime targetMonth = _custPrtPprBlnceWork.St_AddUpYearMonth.AddMonths( monthIndex );

                        // �擾�ł��Ȃ��������ɑ΂��Ă̏���
                        if ( !monthList.Contains( (Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM( targetMonth ) ) &&
                              (prevTotalDay < targetMonth) )
                        {
                            //---------------------------------------------------
                            // ���В��ߌ��͈�
                            //---------------------------------------------------
                            # region [���В��ߌ��͈�]
                            DateTime stDate;
                            DateTime edDate;
                            finYearTableGenerator.GetDaysFromMonth( targetMonth, out stDate, out edDate );
                            # endregion

                            //---------------------------------------------------
                            // �����p�����[�^�Z�b�g
                            //---------------------------------------------------
                            # region [�����p�����[�^�Z�b�g]
                            CustAccRecWork paraWork = new CustAccRecWork();
                            paraWork.EnterpriseCode = _custPrtPprBlnceWork.EnterpriseCode;                //��ƃR�[�h
                            //paraWork.LaMonCAddUpUpdDate = stDate.AddDays( -1 );     // DEL 2013/10/24 gezh for Redmine#39753
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>> 
                            if (TDateTime.DateTimeToString("YYYYMM", prevTotalDay) == TDateTime.DateTimeToString("YYYYMM", targetMonth.AddMonths(-1)))
                            {
                                paraWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                            }
                            else
                            {
                                paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);
                            }
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
                            paraWork.AddUpDate = edDate;
                            paraWork.AddUpYearMonth = targetMonth;                //�v��N��
                            paraWork.AddUpSecCode = _custPrtPprBlnceWork.SectionCode[0];  //�v�㋒�_�R�[�h �����Ӑ�}�X�^���X�g����
                            paraWork.CustomerCode = _custPrtPprBlnceWork.CustomerCode;     //���Ӑ�R�[�h   �����Ӑ�}�X�^���X�g����
                            if ( paraWork.CustomerCode == 0 )
                            {
                                paraWork.CustomerCode = _custPrtPprBlnceWork.ClaimCode;
                            }

                            # endregion

                            //---------------------------------------------------
                            // ���|���E���|���Z�o���W���[���Ăяo��
                            //---------------------------------------------------
                            # region [���|���E���|���Z�o���W���[���Ăяo��]
                            MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
                            object paraObj = paraWork;
                            string retMsg;
                            int accStatus = monthlyAddUpDB.ReadCustAccRec( ref paraObj, out retMsg, ref sqlConnection );

                            if ( accStatus == 0 )
                            {
                                CustPrtPprBlTblRsltWork rsltWork = new CustPrtPprBlTblRsltWork();

                                // ���ʃZ�b�g
                                # region [���ʃZ�b�g]
                                CustAccRecWork retWork = (CustAccRecWork)paraObj;
                                rsltWork.AddUpDate = retWork.AddUpDate;
                                rsltWork.LastTimeBlc = retWork.LastTimeAccRec;
                                rsltWork.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml;
                                rsltWork.ThisTimeTtlBlc = retWork.ThisTimeTtlBlcAcc;
                                rsltWork.ThisTimeSales = retWork.ThisTimeSales;
                                rsltWork.SalesPricRgdsDis = retWork.ThisSalesPricRgds + retWork.ThisSalesPricDis;
                                rsltWork.OfsThisTimeSales = retWork.OfsThisTimeSales;
                                rsltWork.OfsThisSalesTax = retWork.OfsThisSalesTax;
                                rsltWork.ThisSalesPricTotal = retWork.OfsThisTimeSales + retWork.OfsThisSalesTax;
                                rsltWork.AfCalBlc = retWork.AfCalTMonthAccRec;
                                rsltWork.SalesSlipCount = retWork.SalesSlipCount;
                                # endregion

                                // �O���c���̔��f
                                # region [�O���c���̔��f]
                                int prevIndex = rsltWorkArray.Count - 1;
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                //rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // �O���c��
                                //// ����J�z�c��(���|) = �O�񐿋��c�� - ����������z 
                                //rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// ����J�z�c��(���|)
                                //// �v�Z�㐿�����z = ����J�z�c�� + (���E�㍡�񔄏���z + ���E�㍡�񔄏�����)
                                //rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// �v�Z�㐿�����z
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                if (prevIndex >= 0)
                                {
                                    rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // �O���c��
                                    // ����J�z�c��(���|) = �O�񐿋��c�� - ����������z 
                                    rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// ����J�z�c��(���|)
                                    // �v�Z�㐿�����z = ����J�z�c�� + (���E�㍡�񔄏���z + ���E�㍡�񔄏�����)
                                    rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// �v�Z�㐿�����z
                                }
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                # endregion

                                rsltWorkArray.Add( rsltWork );

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            # endregion
                        }
                    }
                    # endregion
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

            return status;
        }
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
        private DateTime CheckPrcMonthlyAccRec( CustPrtPprBlnceWork custPrtPprBlnceWork, ref SqlConnection sqlConnection )
        {
            // ���σ`�F�b�N
            TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();

            TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
            paraWork.EnterpriseCode = custPrtPprBlnceWork.EnterpriseCode;
            paraWork.SectionCode = custPrtPprBlnceWork.SectionCode[0];
            paraWork.CustomerCode = custPrtPprBlnceWork.CustomerCode;
            if ( paraWork.CustomerCode == 0 )
            {
                paraWork.CustomerCode = custPrtPprBlnceWork.ClaimCode;
            }
            List<TtlDayCalcRetWork> retList;

            int status = ttlDayCalcDB.SearchHisMonthlyAccRec( out retList, paraWork, ref sqlConnection );
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

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        #region [SearchBlTblOutput]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������c���ꗗ�\���i�^�M�c���o�͗p�j�̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="custPrtPprBlTblRsltWork">��������</param>
        /// <param name="custPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������c���ꗗ�\���i�^�M�c���o�͗p�jLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30744 ���� ����q</br>
        /// <br>Date       : 2013/03/13</br>
        /// <br></br>
        public int SearchBlTblOutput(ref object custPrtPprBlTblRsltWork, object custPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode, bool CreditMng)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            custPrtPprBlTblRsltWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (custPrtPprBlnceWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�c���ꗗ�p ArrayList
                ArrayList custPrtPprBlTblRsltArray = custPrtPprBlTblRsltWork as ArrayList;
                if (custPrtPprBlTblRsltArray == null)
                {
                    custPrtPprBlTblRsltArray = new ArrayList();
                }
                //�����p�����[�^
                CustPrtPprBlnceWork _custPrtPprBlnceWork = custPrtPprBlnceWork as CustPrtPprBlnceWork;
                #endregion  //[�p�����[�^�̃L���X�g]

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "���Ӑ�d�q����", "���o�J�n", "PMKAU04000U", 0); 

                //SearchBlTbl���s
                status = SearchBlTblOutputProc(ref custPrtPprBlTblRsltArray, _custPrtPprBlnceWork, SrchKndDiv, CreditMng, readMode, logicalMode, ref sqlConnection);

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "���Ӑ�d�q����", "���o�I��", "PMKAU04000U", 0); 
                //���s���ʃZ�b�g
                custPrtPprBlTblRsltWork = custPrtPprBlTblRsltArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchBlTblOutput Exception=" + ex.Message);
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
        #endregion  //[SearchBlTblOutput]

        #region [SearchBlTblOutputProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������c���ꗗ�\���i�^�M�c���o�͗p�j�̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="rsltWorkArray">��������</param>
        /// <param name="_custPrtPprBlnceWork">�����p�����[�^</param>
        /// <param name="SrchKndDiv">������� 0:���� 1:���|</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30744 ���� ����q</br>
        /// <br>Date       : 2013/03/13</br>
        /// <br>Update Note: 10800003-00�@2013/05/15�z�M�� Redmine#35205���Ӑ�d�q�����̑Ή�</br>
        /// <br>             �@�^�M�c���o�͌����s���̏C��</br>
        /// <br>             �A�^�M�c���o�͏ꍇ�A���o�f�[�^�͑O���f�[�^�����ꍇ�A�O���̃f�[�^���폜</br>
        /// <br>Programmer : xuyb</br>
        /// <br>Date       : 2013/03/29</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753���Ӑ�d�q�����Ɏc���ꗗ�̏���ŕs���ɂȂ錏�̑Ή�</br>
        /// <br>Update Note: 2013/11/11 gezh</br>
        /// <br>             Redmine#41206�̇�26 ���Ӑ�d�q�����ɑΏ۔N��(�J�n)�ɔ��㌎���X�V���������̌����w�肵���ꍇ�A�c���ꗗ���\������Ȃ��̑Ή�</br>
        /// <br></br>
        private int SearchBlTblOutputProc(ref ArrayList rsltWorkArray, CustPrtPprBlnceWork _custPrtPprBlnceWork, int SrchKndDiv, bool CreditMng, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ICustPrtPprOutput custPrtPpr;
            custPrtPpr = new CustPrtPprBlTblRsltQuery();
            List<Int32> monthList = new List<Int32>();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, CreditMng, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    //�擾���ʃZ�b�g
                    CustPrtPprBlTblRsltWork retWork = (CustPrtPprBlTblRsltWork)custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv, CreditMng);
                    rsltWorkArray.Add(retWork);

                    //�擾���ꗗ�ǉ�
                    monthList.Add((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(retWork.AddUpYearMonth));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2013/03/29 xuyb Redmine#35205�A�^�M�c���o�͏ꍇ�A���o�f�[�^�͑O���f�[�^�����ꍇ�A�O���̃f�[�^���폜
                if (CreditMng && monthList.Count == 1 && monthList[0].ToString().Equals(_custPrtPprBlnceWork.St_AddUpYearMonth.ToString("yyyyMM")))
                {
                    rsltWorkArray.RemoveAt(0);
                }
                // ADD 2013/03/29 xuyb Redmine#35205�A�^�M�c���o�͏ꍇ�A���o�f�[�^�͑O���f�[�^�����ꍇ�A�O���̃f�[�^���폜
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchBlTblProc Exception=" + ex.Message);
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

            if (SrchKndDiv == (int)iSrchKndDiv.CustAcc)
            {
                FinYearTableGenerator finYearTableGenerator = this.GetFinYearTableGenerator(_custPrtPprBlnceWork.EnterpriseCode, ref sqlConnection);
                if (finYearTableGenerator != null)
                {
                    # region [���������͈�]
                    // �O�񌎎����������擾
                    DateTime prevTotalDay = CheckPrcMonthlyAccRec(_custPrtPprBlnceWork, ref sqlConnection);
                    // �w�茎�͈�
                    int monthCount = GetMonthsCount(_custPrtPprBlnceWork.Ed_AddUpYearMonth, _custPrtPprBlnceWork.St_AddUpYearMonth);
                    for (int monthIndex = 0; monthIndex < monthCount; monthIndex++)
                    {
                        DateTime targetMonth = _custPrtPprBlnceWork.St_AddUpYearMonth.AddMonths(monthIndex);

                        // �擾�ł��Ȃ��������ɑ΂��Ă̏���
                        if (!monthList.Contains((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(targetMonth)) &&
                              (prevTotalDay < targetMonth))
                        {
                            //---------------------------------------------------
                            // ���В��ߌ��͈�
                            //---------------------------------------------------
                            # region [���В��ߌ��͈�]
                            DateTime stDate;
                            DateTime edDate;
                            finYearTableGenerator.GetDaysFromMonth(targetMonth, out stDate, out edDate);
                            # endregion

                            //---------------------------------------------------
                            // �����p�����[�^�Z�b�g
                            //---------------------------------------------------
                            # region [�����p�����[�^�Z�b�g]
                            CustAccRecWork paraWork = new CustAccRecWork();
                            paraWork.EnterpriseCode = _custPrtPprBlnceWork.EnterpriseCode;                //��ƃR�[�h
                            //paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);     // DEL 2013/10/24 gezh for Redmine#39753
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>> 
                            if (TDateTime.DateTimeToString("YYYYMM", prevTotalDay) == TDateTime.DateTimeToString("YYYYMM", targetMonth.AddMonths(-1)))
                            {
                                paraWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                            }
                            else
                            {
                                paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);
                            }
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
                            paraWork.AddUpDate = edDate;
                            paraWork.AddUpYearMonth = targetMonth;                //�v��N��
                            paraWork.AddUpSecCode = _custPrtPprBlnceWork.SectionCode[0];  //�v�㋒�_�R�[�h �����Ӑ�}�X�^���X�g����
                            paraWork.CustomerCode = _custPrtPprBlnceWork.CustomerCode;     //���Ӑ�R�[�h   �����Ӑ�}�X�^���X�g����
                            if (paraWork.CustomerCode == 0)
                            {
                                paraWork.CustomerCode = _custPrtPprBlnceWork.ClaimCode;
                            }

                            # endregion

                            //---------------------------------------------------
                            // ���|���E���|���Z�o���W���[���Ăяo��
                            //---------------------------------------------------
                            # region [���|���E���|���Z�o���W���[���Ăяo��]
                            MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
                            object paraObj = paraWork;
                            string retMsg;
                            int accStatus = monthlyAddUpDB.ReadCustAccRec(ref paraObj, out retMsg, ref sqlConnection);

                            if (accStatus == 0)
                            {
                                CustPrtPprBlTblRsltWork rsltWork = new CustPrtPprBlTblRsltWork();

                                // ���ʃZ�b�g
                                # region [���ʃZ�b�g]
                                CustAccRecWork retWork = (CustAccRecWork)paraObj;
                                rsltWork.AddUpDate = retWork.AddUpDate;
                                rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;  // ADD 2013/03/29 xuyb Redmine#35205�@
                                rsltWork.LastTimeBlc = retWork.LastTimeAccRec;
                                rsltWork.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml;
                                rsltWork.ThisTimeTtlBlc = retWork.ThisTimeTtlBlcAcc;
                                rsltWork.ThisTimeSales = retWork.ThisTimeSales;
                                rsltWork.SalesPricRgdsDis = retWork.ThisSalesPricRgds + retWork.ThisSalesPricDis;
                                rsltWork.OfsThisTimeSales = retWork.OfsThisTimeSales;
                                rsltWork.OfsThisSalesTax = retWork.OfsThisSalesTax;
                                rsltWork.ThisSalesPricTotal = retWork.OfsThisTimeSales + retWork.OfsThisSalesTax;
                                rsltWork.AfCalBlc = retWork.AfCalTMonthAccRec;
                                rsltWork.SalesSlipCount = retWork.SalesSlipCount;
                                # endregion

                                // �O���c���̔��f
                                # region [�O���c���̔��f]
                                int prevIndex = rsltWorkArray.Count - 1;
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                //rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // �O���c��
                                //// ����J�z�c��(���|) = �O�񐿋��c�� - ����������z 
                                //rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// ����J�z�c��(���|)
                                //// �v�Z�㐿�����z = ����J�z�c�� + (���E�㍡�񔄏���z + ���E�㍡�񔄏�����)
                                //rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// �v�Z�㐿�����z
                                //// ���В���
                                //rsltWork.CompanyTotalDay = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).CompanyTotalDay; // ���В���
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                if (prevIndex >= 0)
                                {
                                    rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // �O���c��
                                    // ����J�z�c��(���|) = �O�񐿋��c�� - ����������z 
                                    rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// ����J�z�c��(���|)
                                    // �v�Z�㐿�����z = ����J�z�c�� + (���E�㍡�񔄏���z + ���E�㍡�񔄏�����)
                                    rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// �v�Z�㐿�����z
                                    // ���В���
                                    rsltWork.CompanyTotalDay = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).CompanyTotalDay; // ���В���
                                }
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                # endregion

                                rsltWork.CreditMngCode = 2;// �^�M�敪 // ADD 2013/04/12 zhujw Redmine#35205

                                rsltWorkArray.Add(rsltWork);

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            # endregion
                        }
                    }
                    # endregion
                }
            }

            return status;
        }
        #endregion  //[SearchBlTblOutputProc]
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

        #endregion  //[�c���ꗗ����]

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        # region [���𕪂̐ԓ`�Ή�]

        # region [����`�[�ǂݍ��݁i�����܂ށj]
        /// <summary>
        /// ����`�[�ǂݍ��݁i�����܂ށj
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retsliplist"></param>
        /// <param name="retrelationsliplist"></param>
        /// <param name="readMode"></param>
        /// <returns></returns>
        public int ReadSalesSlip( ref object paramlist, out object retsliplist, out object retrelationsliplist, int readMode )
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = null;
            retrelationsliplist = null;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;

            if ( SlipListUtils.IsEmpty( paramlist as ArrayList ) )
            {
                string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                errmsg += ": �ǂݍ��ݏ�񃊃X�g�����o�^�ł��B";
                base.WriteErrorLog( errmsg, status );
            }
            else
            {
                try
                {
                    ArrayList list = paramlist as ArrayList;

                    ArrayList retslips = null;
                    ArrayList retrelationslips = null;

                    status = this.ReadProc( ref list, out retslips, out retrelationslips, ref connection, ref encryptinfo, true, readMode );

                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        retsliplist = new CustomSerializeArrayList();
                        (retsliplist as CustomSerializeArrayList).AddRange( retslips );

                        retrelationsliplist = new CustomSerializeArrayList();
                        (retrelationsliplist as CustomSerializeArrayList).AddRange( retrelationslips );
                    }
                }
                catch ( Exception ex )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    base.WriteErrorLog( ex, errmsg, status );
                }
                finally
                {
                    # region [�Í����L�[�̃N���[�Y(�ۗ�)]
                    // �Í����L�[�̃N���[�Y
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}
                    # endregion

                    // �R�l�N�V�����̔j��
                    if ( connection != null )
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retsliplist"></param>
        /// <param name="retrelationsliplist"></param>
        /// <param name="connection"></param>
        /// <param name="encryptinfo"></param>
        /// <param name="readrelation"></param>
        /// <returns></returns>
        private int ReadProc( ref ArrayList paramlist, out ArrayList retsliplist, out ArrayList retrelationsliplist, ref SqlConnection connection, ref SqlEncryptInfo encryptinfo, bool readrelation, int readMode )
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = new ArrayList();
            retrelationsliplist = new ArrayList();

            SqlCommand command = null;

            try
            {
                # region [�p�����[�^�[�`�F�b�N]

                //���Ǎ���񃊃X�g�`�F�b�N
                if ( SlipListUtils.IsEmpty( paramlist ) )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": �Ǎ���񃊃X�g�����o�^�ł��B";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }

                //������E�d������I�v�V�����`�F�b�N
                this.CtrlOptWork = SlipListUtils.Find( paramlist, typeof( IOWriteCtrlOptWork ), SlipListUtils.FindType.Class ) as IOWriteCtrlOptWork;

                if ( this.CtrlOptWork == null )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": ����E�d������I�v�V������������܂���B";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }

                //���R�l�N�V�����`�F�b�N
                if ( connection == null )
                {
                    connection = this.CreateSqlConnection( true );
                }

                if ( connection == null )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": �f�[�^�x�[�X�֐ڑ��o���܂���B";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }

                // �ǂݍ��݃p�����[�^����
                MakeReadFunctionParam( ref paramlist );



                # region �Í������� �ۗ�
                //���Í����L�[�`�F�b�N�@(�ۗ�)
                //if (encryptinfo == null)
                //{
                //    List<string> ConcatArray = new List<string>();

                //    // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
                //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
                //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // �e�[�u�����X�g�̌���
                //    string[] tablenames = ConcatArray.ToArray();

                //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
                //}

                //if (encryptinfo == null)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": �Í����L�[���쐬�o���܂���B";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //encryptinfo.OpenSymKey(ref connection);

                //if (!encryptinfo.IsOpen)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": �Í����L�[���I�[�v���o���܂���B";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}
                # endregion

                //������N�_�ɉ����ēǍ��I�u�W�F�N�g�����X�g���擾����
                IOWriteMAHNBReadWork salesReadWork = null;
                IOWriteMASIRReadWork stockReadWork = null;

                if ( this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales )
                {
                    salesReadWork = SlipListUtils.Find( paramlist, typeof( IOWriteMAHNBReadWork ), SlipListUtils.FindType.Class ) as IOWriteMAHNBReadWork;

                    if ( salesReadWork == null )
                    {
                        string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                        errmsg += ": ����f�[�^�Ǎ��I�u�W�F�N�g���o�^����Ă��܂���B";
                        base.WriteErrorLog( errmsg, status );
                        return status;
                    }
                }
                else if ( this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase )
                {

                    stockReadWork = SlipListUtils.Find( paramlist, typeof( IOWriteMASIRReadWork ), SlipListUtils.FindType.Class ) as IOWriteMASIRReadWork;

                    if ( stockReadWork == null )
                    {
                        string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                        errmsg += ": �d���f�[�^�Ǎ��I�u�W�F�N�g���o�^����Ă��܂���B";
                        base.WriteErrorLog( errmsg, status );
                        return status;
                    }
                }
                else
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": ����E�d������I�v�V�����̐���N�_�Ɍ�肪����܂��B";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }
                # endregion

                # region [�w��`�[�f�[�^�̓Ǎ�]
                CustomSerializeArrayList readparam = new CustomSerializeArrayList();
                readparam.AddRange( paramlist );

                //CustomSerializeArrayList readresult = null;
                CustomSerializeArrayList readresult = new CustomSerializeArrayList();

                int pos = MakePosition( readparam, typeof( SalesSlipReadWork ), 0 );

                //���Ǎ��Ώۂ̓`�[�f�[�^���擾����
                if ( this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales )
                {
                    ArrayList detailList = null;
                    SqlTransaction transaction = null;

                    // UI����w�肳�ꂽreadMode�ɂ�蔄��f�[�^or���㗚���f�[�^�����肷��B
                    if ( readMode == 0 )
                    {
                        //---------------------------------------------
                        // ����
                        //---------------------------------------------

                        # region [����]
                        // ����`�[�f�[�^��ǂݍ���
                        _salesSlipDB = new SalesSlipDB();
                        object freeParam = null;//����`�[Read�ł͎��R�p�����[�^�͗��p���Ȃ�
                        status = _salesSlipDB.Read( "CustPrtPprWorkDB", ref readparam, ref readresult, MakePosition( readparam, typeof( SalesSlipReadWork ), 0 ), "", ref freeParam, ref connection );

                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            foreach ( object obj in readresult )
                            {
                                // --- UPD 2014/07/04 y.wakita ----->>>>>
                                //if (obj is ArrayList && (obj as ArrayList).Count > 0 && ((obj as ArrayList)[0] is SalesDetailWork))
                                if (obj is ArrayList && (obj as ArrayList).Count > 0 && (("SalesDetailWork").Equals(((obj as ArrayList)[0]).GetType().Name)))
                                // --- UPD 2014/07/04 y.wakita -----<<<<<
                                {
                                    detailList = (ArrayList)obj;
                                }
                            }
                        }

                        # endregion
                    }
                    else
                    {
                        //---------------------------------------------
                        // ���㗚��
                        //---------------------------------------------

                        # region [���㗚��]
                        // ����`�[�f�[�^��ǂݍ���
                        if ( pos > 0 )
                        {
                            _salesSlipHistDB = new SalesSlipHistDB();

                            SalesHistoryWork paraWork = new SalesHistoryWork();
                            paraWork.EnterpriseCode = (readparam[pos] as SalesSlipReadWork).EnterpriseCode;
                            paraWork.AcptAnOdrStatus = (readparam[pos] as SalesSlipReadWork).AcptAnOdrStatus;
                            paraWork.SalesSlipNum = (readparam[pos] as SalesSlipReadWork).SalesSlipNum;
                            ArrayList histDetailList = null;

                            // ���㗚��ǂݍ���
                            status = _salesSlipHistDB.ReadProc( ref paraWork, ref histDetailList, 0, ref connection, ref transaction );
                            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                            {
                                // ���㗚��
                                readresult.Add( CopyToSalesSlipFromSalesHist( paraWork ) );
                                // ���㗚�𖾍�
                                detailList = CopyToSalesDetailListFromSalesHistDtlList( histDetailList );
                                readresult.Add( detailList );
                            }
                        }
                        # endregion
                    }

                    # region [�󒍃}�X�^�i���q�j]
                    // �󒍃}�X�^�i���q�j
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        ArrayList carList;
                        transaction = null;

                        if ( detailList != null && detailList.Count > 0 )
                        {
                            // �󒍃}�X�^(�ԗ�)�ǂݍ���
                            AcceptOdrCarReader acceptOdrCarReader = new AcceptOdrCarReader();
                            acceptOdrCarReader.ReadWithSalesDetail( out carList, detailList, connection, transaction );
                            if ( carList != null && carList.Count > 0 )
                            {
                                // �󒍃}�X�^(�ԗ�)
                                readresult.Add( carList );
                            }
                        }
                    }
                    # endregion
                }

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // �Ǎ����ʂ��i�[
                    retsliplist.AddRange( readresult );
                }
                else
                {
                    return status;
                }
                # endregion

                # region [�֘A����d���`�[�̎擾]
                if ( pos > 0 )
                {
                    string sqlText = string.Empty;
                    command = new SqlCommand( sqlText, connection );

                    # region [SELECT]
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "   SAH.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                    sqlText += "  ,SAH.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += "  ,STH.SUPPLIERFORMALRF AS STHFM" + Environment.NewLine;
                    sqlText += "  ,STH.SUPPLIERSLIPNORF AS STHNO" + Environment.NewLine;
                    sqlText += "  ,STC.SUPPLIERFORMALRF AS STCFM" + Environment.NewLine;
                    sqlText += "  ,STC.SUPPLIERSLIPNORF AS STCNO" + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    // -- UPD 2010/06/09 ----------------------------------------->>>
                    //sqlText += "  SALESHISTDTLRF AS SAH" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF AS SAH WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/09 -----------------------------------------<<<
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF AS STH" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  SAH.ENTERPRISECODERF = STH.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND STH.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND SAH.SUPPLIERFORMALSYNCRF = STH.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "  AND SAH.STOCKSLIPDTLNUMSYNCRF = STH.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKDETAILRF AS STC" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  SAH.ENTERPRISECODERF = STC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND STC.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND SAH.SUPPLIERFORMALSYNCRF = STC.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "  AND SAH.STOCKSLIPDTLNUMSYNCRF = STC.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SAH.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SAH.SALESSLIPNUMRF=@FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "  AND SAH.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "" + Environment.NewLine;
                    command.CommandText = sqlText;

                    SqlParameter findEnterpriseCode = command.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );  // ��ƃR�[�h
                    SqlParameter findSalesSlipNum = command.Parameters.Add( "@FINDSALESSLIPNUM", SqlDbType.NChar );      // �`�[�ԍ�
                    SqlParameter findAcptAnOdrStatus = command.Parameters.Add( "@FINDACPTANODRSTATUS", SqlDbType.Int );  // �󒍃X�e�[�^�X


                    SalesSlipReadWork readWork = (readparam[pos] as SalesSlipReadWork);
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString( readWork.EnterpriseCode );
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString( readWork.SalesSlipNum );
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32( readWork.AcptAnOdrStatus );
                    # endregion

                    DataTable aodrtable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter( command );

                    try
                    {
                        dataAdapter.Fill( aodrtable );

                        foreach ( DataRow row in aodrtable.Rows )
                        {
                            if ( row["STCNO"] != DBNull.Value && (int)row["STCNO"] > 0 )
                            {
                                //---------------------------------------------
                                // �d��
                                //---------------------------------------------

                                # region [�d��]
                                // �ǂݍ��݃p�����[�^�Z�b�g
                                CustomSerializeArrayList stockParaList = new CustomSerializeArrayList();
                                StockSlipReadWork stockSlipReadWork = new StockSlipReadWork();
                                stockSlipReadWork.EnterpriseCode = readWork.EnterpriseCode;
                                stockSlipReadWork.SupplierFormal = (int)row["STCFM"];
                                stockSlipReadWork.SupplierSlipNo = (int)row["STCNO"];
                                stockParaList.Add( stockSlipReadWork );

                                // �d���f�[�^�ǂݍ���
                                CustomSerializeArrayList stockRetList = new CustomSerializeArrayList();
                                _stockSlipDB = new StockSlipDB();
                                object freeParam = null;//���R�p�����[�^�͗��p���Ȃ�

                                status = _stockSlipDB.Read( "CustPrtPprWorkDB", ref stockParaList, ref stockRetList, MakePosition( stockParaList, typeof( StockSlipReadWork ), 0 ), "", ref freeParam, ref connection );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // �Ǎ����ʂ��i�[
                                    retrelationsliplist.Add( stockRetList );
                                }
                                # endregion
                            }
                            else if ( row["STHNO"] != DBNull.Value && (int)row["STHNO"] > 0 )
                            {
                                //---------------------------------------------
                                // �d������
                                //---------------------------------------------

                                # region [�d������]
                                StockSlipHistWork stockHisParaWork = new StockSlipHistWork();
                                stockHisParaWork.EnterpriseCode = readWork.EnterpriseCode;
                                stockHisParaWork.SupplierFormal = (int)row["STHFM"];
                                stockHisParaWork.SupplierSlipNo = (int)row["STHNO"];

                                ArrayList stockHisDtlList = null;
                                ArrayList stockDetalList = null;
                                SqlTransaction transaction = null;
                                _stockSlipHistDB = new StockSlipHistDB();

                                status = _stockSlipHistDB.ReadProc( ref stockHisParaWork, ref stockHisDtlList, 0, ref connection, ref transaction );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    CustomSerializeArrayList retList = new CustomSerializeArrayList();

                                    // �d������
                                    retList.Add( CopyToStockSlipFromStockHist( stockHisParaWork ) );
                                    // �d�����𖾍�
                                    stockDetalList = CopyToStockDetailListFromStockHistDtlList( stockHisDtlList );
                                    retList.Add( stockDetalList );

                                    // �Ǎ����ʂ��i�[
                                    retrelationsliplist.Add( retList );
                                }
                                # endregion
                            }
                        }
                    }
                    finally
                    {
                        aodrtable.Dispose();
                        dataAdapter.Dispose();
                    }
                }
                # endregion
            }
            catch ( SqlException ex )
            {
                string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                status = base.WriteSQLErrorLog( ex, errmsg, ex.Number );
            }
            finally
            {
                if ( command != null )
                {
                    command.Dispose();
                }
            }

            return status;
        }
        # region [�f�[�^Copy����]
        /// <summary>
        /// ���㗚��������
        /// </summary>
        /// <param name="salesHist"></param>
        /// <returns></returns>
        private SalesSlipWork CopyToSalesSlipFromSalesHist( SalesHistoryWork salesHist )
        {
            SalesSlipWork salesSlip = new SalesSlipWork();
            # region [Copy]
            salesSlip.CreateDateTime = salesHist.CreateDateTime;  // �쐬����
            salesSlip.UpdateDateTime = salesHist.UpdateDateTime;  // �X�V����
            salesSlip.EnterpriseCode = salesHist.EnterpriseCode;  // ��ƃR�[�h
            salesSlip.FileHeaderGuid = salesHist.FileHeaderGuid;  // GUID
            salesSlip.UpdEmployeeCode = salesHist.UpdEmployeeCode;  // �X�V�]�ƈ��R�[�h
            salesSlip.UpdAssemblyId1 = salesHist.UpdAssemblyId1;  // �X�V�A�Z���u��ID1
            salesSlip.UpdAssemblyId2 = salesHist.UpdAssemblyId2;  // �X�V�A�Z���u��ID2
            salesSlip.LogicalDeleteCode = salesHist.LogicalDeleteCode;  // �_���폜�敪
            salesSlip.AcptAnOdrStatus = salesHist.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
            salesSlip.SalesSlipNum = salesHist.SalesSlipNum;  // ����`�[�ԍ�
            salesSlip.SectionCode = salesHist.SectionCode;  // ���_�R�[�h
            salesSlip.SubSectionCode = salesHist.SubSectionCode;  // ����R�[�h
            salesSlip.DebitNoteDiv = salesHist.DebitNoteDiv;  // �ԓ`�敪
            salesSlip.DebitNLnkSalesSlNum = salesHist.DebitNLnkSalesSlNum;  // �ԍ��A������`�[�ԍ�
            salesSlip.SalesSlipCd = salesHist.SalesSlipCd;  // ����`�[�敪
            salesSlip.SalesGoodsCd = salesHist.SalesGoodsCd;  // ���㏤�i�敪
            salesSlip.AccRecDivCd = salesHist.AccRecDivCd;  // ���|�敪
            salesSlip.SalesInpSecCd = salesHist.SalesInpSecCd;  // ������͋��_�R�[�h
            salesSlip.DemandAddUpSecCd = salesHist.DemandAddUpSecCd;  // �����v�㋒�_�R�[�h
            salesSlip.ResultsAddUpSecCd = salesHist.ResultsAddUpSecCd;  // ���ьv�㋒�_�R�[�h
            salesSlip.UpdateSecCd = salesHist.UpdateSecCd;  // �X�V���_�R�[�h
            salesSlip.SalesSlipUpdateCd = salesHist.SalesSlipUpdateCd;  // ����`�[�X�V�敪
            salesSlip.SearchSlipDate = salesHist.SearchSlipDate;  // �`�[�������t
            salesSlip.ShipmentDay = salesHist.ShipmentDay;  // �o�ד��t
            salesSlip.SalesDate = salesHist.SalesDate;  // ������t
            salesSlip.AddUpADate = salesHist.AddUpADate;  // �v����t
            salesSlip.DelayPaymentDiv = salesHist.DelayPaymentDiv;  // �����敪
            salesSlip.InputAgenCd = salesHist.InputAgenCd;  // ���͒S���҃R�[�h
            salesSlip.InputAgenNm = salesHist.InputAgenNm;  // ���͒S���Җ���
            salesSlip.SalesInputCode = salesHist.SalesInputCode;  // ������͎҃R�[�h
            salesSlip.SalesInputName = salesHist.SalesInputName;  // ������͎Җ���
            salesSlip.FrontEmployeeCd = salesHist.FrontEmployeeCd;  // ��t�]�ƈ��R�[�h
            salesSlip.FrontEmployeeNm = salesHist.FrontEmployeeNm;  // ��t�]�ƈ�����
            salesSlip.SalesEmployeeCd = salesHist.SalesEmployeeCd;  // �̔��]�ƈ��R�[�h
            salesSlip.SalesEmployeeNm = salesHist.SalesEmployeeNm;  // �̔��]�ƈ�����
            salesSlip.TotalAmountDispWayCd = salesHist.TotalAmountDispWayCd;  // ���z�\�����@�敪
            salesSlip.TtlAmntDispRateApy = salesHist.TtlAmntDispRateApy;  // ���z�\���|���K�p�敪
            salesSlip.SalesTotalTaxInc = salesHist.SalesTotalTaxInc;  // ����`�[���v�i�ō��݁j
            salesSlip.SalesTotalTaxExc = salesHist.SalesTotalTaxExc;  // ����`�[���v�i�Ŕ����j
            salesSlip.SalesPrtTotalTaxInc = salesHist.SalesPrtTotalTaxInc;  // ���㕔�i���v�i�ō��݁j
            salesSlip.SalesPrtTotalTaxExc = salesHist.SalesPrtTotalTaxExc;  // ���㕔�i���v�i�Ŕ����j
            salesSlip.SalesWorkTotalTaxInc = salesHist.SalesWorkTotalTaxInc;  // �����ƍ��v�i�ō��݁j
            salesSlip.SalesWorkTotalTaxExc = salesHist.SalesWorkTotalTaxExc;  // �����ƍ��v�i�Ŕ����j
            salesSlip.SalesSubtotalTaxInc = salesHist.SalesSubtotalTaxInc;  // ���㏬�v�i�ō��݁j
            salesSlip.SalesSubtotalTaxExc = salesHist.SalesSubtotalTaxExc;  // ���㏬�v�i�Ŕ����j
            salesSlip.SalesPrtSubttlInc = salesHist.SalesPrtSubttlInc;  // ���㕔�i���v�i�ō��݁j
            salesSlip.SalesPrtSubttlExc = salesHist.SalesPrtSubttlExc;  // ���㕔�i���v�i�Ŕ����j
            salesSlip.SalesWorkSubttlInc = salesHist.SalesWorkSubttlInc;  // �����Ə��v�i�ō��݁j
            salesSlip.SalesWorkSubttlExc = salesHist.SalesWorkSubttlExc;  // �����Ə��v�i�Ŕ����j
            salesSlip.SalesNetPrice = salesHist.SalesNetPrice;  // ���㐳�����z
            salesSlip.SalesSubtotalTax = salesHist.SalesSubtotalTax;  // ���㏬�v�i�Łj
            salesSlip.ItdedSalesOutTax = salesHist.ItdedSalesOutTax;  // ����O�őΏۊz
            salesSlip.ItdedSalesInTax = salesHist.ItdedSalesInTax;  // ������őΏۊz
            salesSlip.SalSubttlSubToTaxFre = salesHist.SalSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz
            salesSlip.SalesOutTax = salesHist.SalesOutTax;  // ����O�Ŋz
            salesSlip.SalAmntConsTaxInclu = salesHist.SalAmntConsTaxInclu;  // ������z����Ŋz�i���Łj
            salesSlip.SalesDisTtlTaxExc = salesHist.SalesDisTtlTaxExc;  // ����l�����z�v�i�Ŕ����j
            salesSlip.ItdedSalesDisOutTax = salesHist.ItdedSalesDisOutTax;  // ����l���O�őΏۊz���v
            salesSlip.ItdedSalesDisInTax = salesHist.ItdedSalesDisInTax;  // ����l�����őΏۊz���v
            salesSlip.ItdedPartsDisOutTax = salesHist.ItdedPartsDisOutTax;  // ���i�l���Ώۊz���v�i�Ŕ����j
            salesSlip.ItdedPartsDisInTax = salesHist.ItdedPartsDisInTax;  // ���i�l���Ώۊz���v�i�ō��݁j
            salesSlip.ItdedWorkDisOutTax = salesHist.ItdedWorkDisOutTax;  // ��ƒl���Ώۊz���v�i�Ŕ����j
            salesSlip.ItdedWorkDisInTax = salesHist.ItdedWorkDisInTax;  // ��ƒl���Ώۊz���v�i�ō��݁j
            salesSlip.ItdedSalesDisTaxFre = salesHist.ItdedSalesDisTaxFre;  // ����l����ېőΏۊz���v
            salesSlip.SalesDisOutTax = salesHist.SalesDisOutTax;  // ����l������Ŋz�i�O�Łj
            salesSlip.SalesDisTtlTaxInclu = salesHist.SalesDisTtlTaxInclu;  // ����l������Ŋz�i���Łj
            salesSlip.PartsDiscountRate = salesHist.PartsDiscountRate;  // ���i�l����
            salesSlip.RavorDiscountRate = salesHist.RavorDiscountRate;  // �H���l����
            salesSlip.TotalCost = salesHist.TotalCost;  // �������z�v
            salesSlip.ConsTaxLayMethod = salesHist.ConsTaxLayMethod;  // ����œ]�ŕ���
            salesSlip.ConsTaxRate = salesHist.ConsTaxRate;  // ����Őŗ�
            salesSlip.FractionProcCd = salesHist.FractionProcCd;  // �[�������敪
            salesSlip.AccRecConsTax = salesHist.AccRecConsTax;  // ���|�����
            salesSlip.AutoDepositCd = salesHist.AutoDepositCd;  // ���������敪
            salesSlip.AutoDepositSlipNo = salesHist.AutoDepositSlipNo;  // ���������`�[�ԍ�
            salesSlip.DepositAllowanceTtl = salesHist.DepositAllowanceTtl;  // �����������v�z
            salesSlip.DepositAlwcBlnce = salesHist.DepositAlwcBlnce;  // ���������c��
            salesSlip.ClaimCode = salesHist.ClaimCode;  // ������R�[�h
            salesSlip.ClaimSnm = salesHist.ClaimSnm;  // �����旪��
            salesSlip.CustomerCode = salesHist.CustomerCode;  // ���Ӑ�R�[�h
            salesSlip.CustomerName = salesHist.CustomerName;  // ���Ӑ於��
            salesSlip.CustomerName2 = salesHist.CustomerName2;  // ���Ӑ於��2
            salesSlip.CustomerSnm = salesHist.CustomerSnm;  // ���Ӑ旪��
            salesSlip.HonorificTitle = salesHist.HonorificTitle;  // �h��
            salesSlip.OutputNameCode = salesHist.OutputNameCode;  // �����R�[�h
            salesSlip.OutputName = salesHist.OutputName;  // ��������
            //salesSlip.CustSlipNo = salesHist.CustSlipNo;  // ���Ӑ�`�[�ԍ�
            salesSlip.SlipAddressDiv = salesHist.SlipAddressDiv;  // �`�[�Z���敪
            salesSlip.AddresseeCode = salesHist.AddresseeCode;  // �[�i��R�[�h
            salesSlip.AddresseeName = salesHist.AddresseeName;  // �[�i�於��
            salesSlip.AddresseeName2 = salesHist.AddresseeName2;  // �[�i�於��2
            salesSlip.AddresseePostNo = salesHist.AddresseePostNo;  // �[�i��X�֔ԍ�
            salesSlip.AddresseeAddr1 = salesHist.AddresseeAddr1;  // �[�i��Z��1�i�s���{���s��S�E�����E���j
            salesSlip.AddresseeAddr3 = salesHist.AddresseeAddr3;  // �[�i��Z��3�i�Ԓn�j
            salesSlip.AddresseeAddr4 = salesHist.AddresseeAddr4;  // �[�i��Z��4�i�A�p�[�g���́j
            salesSlip.AddresseeTelNo = salesHist.AddresseeTelNo;  // �[�i��d�b�ԍ�
            salesSlip.AddresseeFaxNo = salesHist.AddresseeFaxNo;  // �[�i��FAX�ԍ�
            salesSlip.PartySaleSlipNum = salesHist.PartySaleSlipNum;  // �����`�[�ԍ�
            salesSlip.SlipNote = salesHist.SlipNote;  // �`�[���l
            salesSlip.SlipNote2 = salesHist.SlipNote2;  // �`�[���l�Q
            salesSlip.SlipNote3 = salesHist.SlipNote3;  // �`�[���l�R
            salesSlip.RetGoodsReasonDiv = salesHist.RetGoodsReasonDiv;  // �ԕi���R�R�[�h
            salesSlip.RetGoodsReason = salesHist.RetGoodsReason;  // �ԕi���R
            salesSlip.DetailRowCount = salesHist.DetailRowCount;  // ���׍s��
            salesSlip.EdiSendDate = salesHist.EdiSendDate;  // �d�c�h���M��
            salesSlip.EdiTakeInDate = salesHist.EdiTakeInDate;  // �d�c�h�捞��
            salesSlip.UoeRemark1 = salesHist.UoeRemark1;  // �t�n�d���}�[�N�P
            salesSlip.UoeRemark2 = salesHist.UoeRemark2;  // �t�n�d���}�[�N�Q
            salesSlip.SlipPrintDivCd = salesHist.SlipPrintDivCd;  // �`�[���s�敪
            salesSlip.SlipPrintFinishCd = salesHist.SlipPrintFinishCd;  // �`�[���s�ϋ敪
            salesSlip.SalesSlipPrintDate = salesHist.SalesSlipPrintDate;  // ����`�[���s��
            salesSlip.BusinessTypeCode = salesHist.BusinessTypeCode;  // �Ǝ�R�[�h
            salesSlip.BusinessTypeName = salesHist.BusinessTypeName;  // �Ǝ햼��
            salesSlip.DeliveredGoodsDiv = salesHist.DeliveredGoodsDiv;  // �[�i�敪
            salesSlip.DeliveredGoodsDivNm = salesHist.DeliveredGoodsDivNm;  // �[�i�敪����
            salesSlip.SalesAreaCode = salesHist.SalesAreaCode;  // �̔��G���A�R�[�h
            salesSlip.SalesAreaName = salesHist.SalesAreaName;  // �̔��G���A����
            salesSlip.SlipPrtSetPaperId = salesHist.SlipPrtSetPaperId;  // �`�[����ݒ�p���[ID
            salesSlip.CompleteCd = salesHist.CompleteCd;  // �ꎮ�`�[�敪
            salesSlip.SalesPriceFracProcCd = salesHist.SalesPriceFracProcCd;  // ������z�[�������敪
            salesSlip.StockGoodsTtlTaxExc = salesHist.StockGoodsTtlTaxExc;  // �݌ɏ��i���v���z�i�Ŕ��j
            salesSlip.PureGoodsTtlTaxExc = salesHist.PureGoodsTtlTaxExc;  // �������i���v���z�i�Ŕ��j
            salesSlip.ListPricePrintDiv = salesHist.ListPricePrintDiv;  // �艿����敪
            salesSlip.EraNameDispCd1 = salesHist.EraNameDispCd1;  // �����\���敪�P
            # endregion
            return salesSlip;
        }
        /// <summary>
        /// ���㗚�𖾍ׁ����㖾��
        /// </summary>
        /// <param name="histDetail"></param>
        /// <returns></returns>
        private SalesDetailWork CopyToSalesDetailFromSalesHistDtl( SalesHistDtlWork histDetail )
        {
            SalesDetailWork salesDetail = new SalesDetailWork();
            # region [Copy]
            salesDetail.CreateDateTime = histDetail.CreateDateTime;  // �쐬����
            salesDetail.UpdateDateTime = histDetail.UpdateDateTime;  // �X�V����
            salesDetail.EnterpriseCode = histDetail.EnterpriseCode;  // ��ƃR�[�h
            salesDetail.FileHeaderGuid = histDetail.FileHeaderGuid;  // GUID
            salesDetail.UpdEmployeeCode = histDetail.UpdEmployeeCode;  // �X�V�]�ƈ��R�[�h
            salesDetail.UpdAssemblyId1 = histDetail.UpdAssemblyId1;  // �X�V�A�Z���u��ID1
            salesDetail.UpdAssemblyId2 = histDetail.UpdAssemblyId2;  // �X�V�A�Z���u��ID2
            salesDetail.LogicalDeleteCode = histDetail.LogicalDeleteCode;  // �_���폜�敪
            salesDetail.AcceptAnOrderNo = histDetail.AcceptAnOrderNo;  // �󒍔ԍ�
            salesDetail.AcptAnOdrStatus = histDetail.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
            salesDetail.SalesSlipNum = histDetail.SalesSlipNum;  // ����`�[�ԍ�
            salesDetail.SalesRowNo = histDetail.SalesRowNo;  // ����s�ԍ�
            salesDetail.SalesRowDerivNo = histDetail.SalesRowDerivNo;  // ����s�ԍ��}��
            salesDetail.SectionCode = histDetail.SectionCode;  // ���_�R�[�h
            salesDetail.SubSectionCode = histDetail.SubSectionCode;  // ����R�[�h
            salesDetail.SalesDate = histDetail.SalesDate;  // ������t
            salesDetail.CommonSeqNo = histDetail.CommonSeqNo;  // ���ʒʔ�
            salesDetail.SalesSlipDtlNum = histDetail.SalesSlipDtlNum;  // ���㖾�גʔ�
            salesDetail.AcptAnOdrStatusSrc = histDetail.AcptAnOdrStatusSrc;  // �󒍃X�e�[�^�X�i���j
            salesDetail.SalesSlipDtlNumSrc = histDetail.SalesSlipDtlNumSrc;  // ���㖾�גʔԁi���j
            salesDetail.SupplierFormalSync = histDetail.SupplierFormalSync;  // �d���`���i�����j
            salesDetail.StockSlipDtlNumSync = histDetail.StockSlipDtlNumSync;  // �d�����גʔԁi�����j
            salesDetail.SalesSlipCdDtl = histDetail.SalesSlipCdDtl;  // ����`�[�敪�i���ׁj
            salesDetail.GoodsKindCode = histDetail.GoodsKindCode;  // ���i����
            salesDetail.GoodsMakerCd = histDetail.GoodsMakerCd;  // ���i���[�J�[�R�[�h
            salesDetail.MakerName = histDetail.MakerName;  // ���[�J�[����
            salesDetail.MakerKanaName = histDetail.MakerKanaName;  // ���[�J�[�J�i����
            salesDetail.GoodsNo = histDetail.GoodsNo;  // ���i�ԍ�
            salesDetail.GoodsName = histDetail.GoodsName;  // ���i����
            salesDetail.GoodsNameKana = histDetail.GoodsNameKana;  // ���i���̃J�i
            salesDetail.GoodsLGroup = histDetail.GoodsLGroup;  // ���i�啪�ރR�[�h
            salesDetail.GoodsLGroupName = histDetail.GoodsLGroupName;  // ���i�啪�ޖ���
            salesDetail.GoodsMGroup = histDetail.GoodsMGroup;  // ���i�����ރR�[�h
            salesDetail.GoodsMGroupName = histDetail.GoodsMGroupName;  // ���i�����ޖ���
            salesDetail.BLGroupCode = histDetail.BLGroupCode;  // BL�O���[�v�R�[�h
            salesDetail.BLGroupName = histDetail.BLGroupName;  // BL�O���[�v����
            salesDetail.BLGoodsCode = histDetail.BLGoodsCode;  // BL���i�R�[�h
            salesDetail.BLGoodsFullName = histDetail.BLGoodsFullName;  // BL���i�R�[�h���́i�S�p�j
            salesDetail.EnterpriseGanreCode = histDetail.EnterpriseGanreCode;  // ���Е��ރR�[�h
            salesDetail.EnterpriseGanreName = histDetail.EnterpriseGanreName;  // ���Е��ޖ���
            salesDetail.WarehouseCode = histDetail.WarehouseCode;  // �q�ɃR�[�h
            salesDetail.WarehouseName = histDetail.WarehouseName;  // �q�ɖ���
            salesDetail.WarehouseShelfNo = histDetail.WarehouseShelfNo;  // �q�ɒI��
            salesDetail.SalesOrderDivCd = histDetail.SalesOrderDivCd;  // ����݌Ɏ�񂹋敪
            salesDetail.OpenPriceDiv = histDetail.OpenPriceDiv;  // �I�[�v�����i�敪
            salesDetail.GoodsRateRank = histDetail.GoodsRateRank;  // ���i�|�������N
            salesDetail.CustRateGrpCode = histDetail.CustRateGrpCode;  // ���Ӑ�|���O���[�v�R�[�h
            salesDetail.ListPriceRate = histDetail.ListPriceRate;  // �艿��
            salesDetail.RateSectPriceUnPrc = histDetail.RateSectPriceUnPrc;  // �|���ݒ苒�_�i�艿�j
            salesDetail.RateDivLPrice = histDetail.RateDivLPrice;  // �|���ݒ�敪�i�艿�j
            salesDetail.UnPrcCalcCdLPrice = histDetail.UnPrcCalcCdLPrice;  // �P���Z�o�敪�i�艿�j
            salesDetail.PriceCdLPrice = histDetail.PriceCdLPrice;  // ���i�敪�i�艿�j
            salesDetail.StdUnPrcLPrice = histDetail.StdUnPrcLPrice;  // ��P���i�艿�j
            salesDetail.FracProcUnitLPrice = histDetail.FracProcUnitLPrice;  // �[�������P�ʁi�艿�j
            salesDetail.FracProcLPrice = histDetail.FracProcLPrice;  // �[�������i�艿�j
            salesDetail.ListPriceTaxIncFl = histDetail.ListPriceTaxIncFl;  // �艿�i�ō��C�����j
            salesDetail.ListPriceTaxExcFl = histDetail.ListPriceTaxExcFl;  // �艿�i�Ŕ��C�����j
            salesDetail.ListPriceChngCd = histDetail.ListPriceChngCd;  // �艿�ύX�敪
            salesDetail.SalesRate = histDetail.SalesRate;  // ������
            salesDetail.RateSectSalUnPrc = histDetail.RateSectSalUnPrc;  // �|���ݒ苒�_�i����P���j
            salesDetail.RateDivSalUnPrc = histDetail.RateDivSalUnPrc;  // �|���ݒ�敪�i����P���j
            salesDetail.UnPrcCalcCdSalUnPrc = histDetail.UnPrcCalcCdSalUnPrc;  // �P���Z�o�敪�i����P���j
            salesDetail.PriceCdSalUnPrc = histDetail.PriceCdSalUnPrc;  // ���i�敪�i����P���j
            salesDetail.StdUnPrcSalUnPrc = histDetail.StdUnPrcSalUnPrc;  // ��P���i����P���j
            salesDetail.FracProcUnitSalUnPrc = histDetail.FracProcUnitSalUnPrc;  // �[�������P�ʁi����P���j
            salesDetail.FracProcSalUnPrc = histDetail.FracProcSalUnPrc;  // �[�������i����P���j
            salesDetail.SalesUnPrcTaxIncFl = histDetail.SalesUnPrcTaxIncFl;  // ����P���i�ō��C�����j
            salesDetail.SalesUnPrcTaxExcFl = histDetail.SalesUnPrcTaxExcFl;  // ����P���i�Ŕ��C�����j
            salesDetail.SalesUnPrcChngCd = histDetail.SalesUnPrcChngCd;  // ����P���ύX�敪
            salesDetail.CostRate = histDetail.CostRate;  // ������
            salesDetail.RateSectCstUnPrc = histDetail.RateSectCstUnPrc;  // �|���ݒ苒�_�i�����P���j
            salesDetail.RateDivUnCst = histDetail.RateDivUnCst;  // �|���ݒ�敪�i�����P���j
            salesDetail.UnPrcCalcCdUnCst = histDetail.UnPrcCalcCdUnCst;  // �P���Z�o�敪�i�����P���j
            salesDetail.PriceCdUnCst = histDetail.PriceCdUnCst;  // ���i�敪�i�����P���j
            salesDetail.StdUnPrcUnCst = histDetail.StdUnPrcUnCst;  // ��P���i�����P���j
            salesDetail.FracProcUnitUnCst = histDetail.FracProcUnitUnCst;  // �[�������P�ʁi�����P���j
            salesDetail.FracProcUnCst = histDetail.FracProcUnCst;  // �[�������i�����P���j
            salesDetail.SalesUnitCost = histDetail.SalesUnitCost;  // �����P��
            salesDetail.SalesUnitCostChngDiv = histDetail.SalesUnitCostChngDiv;  // �����P���ύX�敪
            salesDetail.RateBLGoodsCode = histDetail.RateBLGoodsCode;  // BL���i�R�[�h�i�|���j
            salesDetail.RateBLGoodsName = histDetail.RateBLGoodsName;  // BL���i�R�[�h���́i�|���j
            salesDetail.RateGoodsRateGrpCd = histDetail.RateGoodsRateGrpCd;  // ���i�|���O���[�v�R�[�h�i�|���j
            salesDetail.RateGoodsRateGrpNm = histDetail.RateGoodsRateGrpNm;  // ���i�|���O���[�v���́i�|���j
            salesDetail.RateBLGroupCode = histDetail.RateBLGroupCode;  // BL�O���[�v�R�[�h�i�|���j
            salesDetail.RateBLGroupName = histDetail.RateBLGroupName;  // BL�O���[�v���́i�|���j
            salesDetail.PrtBLGoodsCode = histDetail.PrtBLGoodsCode;  // BL���i�R�[�h�i����j
            salesDetail.PrtBLGoodsName = histDetail.PrtBLGoodsName;  // BL���i�R�[�h���́i����j
            salesDetail.SalesCode = histDetail.SalesCode;  // �̔��敪�R�[�h
            salesDetail.SalesCdNm = histDetail.SalesCdNm;  // �̔��敪����
            salesDetail.WorkManHour = histDetail.WorkManHour;  // ��ƍH��
            salesDetail.ShipmentCnt = histDetail.ShipmentCnt;  // �o�א�
            salesDetail.SalesMoneyTaxInc = histDetail.SalesMoneyTaxInc;  // ������z�i�ō��݁j
            salesDetail.SalesMoneyTaxExc = histDetail.SalesMoneyTaxExc;  // ������z�i�Ŕ����j
            salesDetail.Cost = histDetail.Cost;  // ����
            salesDetail.GrsProfitChkDiv = histDetail.GrsProfitChkDiv;  // �e���`�F�b�N�敪
            salesDetail.SalesGoodsCd = histDetail.SalesGoodsCd;  // ���㏤�i�敪
            salesDetail.SalesPriceConsTax = histDetail.SalesPriceConsTax;  // ������z����Ŋz
            salesDetail.TaxationDivCd = histDetail.TaxationDivCd;  // �ېŋ敪
            salesDetail.PartySlipNumDtl = histDetail.PartySlipNumDtl;  // �����`�[�ԍ��i���ׁj
            salesDetail.DtlNote = histDetail.DtlNote;  // ���ה��l
            salesDetail.SupplierCd = histDetail.SupplierCd;  // �d����R�[�h
            salesDetail.SupplierSnm = histDetail.SupplierSnm;  // �d���旪��
            salesDetail.OrderNumber = histDetail.OrderNumber;  // �����ԍ�
            salesDetail.WayToOrder = histDetail.WayToOrder;  // �������@
            salesDetail.SlipMemo1 = histDetail.SlipMemo1;  // �`�[�����P
            salesDetail.SlipMemo2 = histDetail.SlipMemo2;  // �`�[�����Q
            salesDetail.SlipMemo3 = histDetail.SlipMemo3;  // �`�[�����R
            salesDetail.InsideMemo1 = histDetail.InsideMemo1;  // �Г������P
            salesDetail.InsideMemo2 = histDetail.InsideMemo2;  // �Г������Q
            salesDetail.InsideMemo3 = histDetail.InsideMemo3;  // �Г������R
            salesDetail.BfListPrice = histDetail.BfListPrice;  // �ύX�O�艿
            salesDetail.BfSalesUnitPrice = histDetail.BfSalesUnitPrice;  // �ύX�O����
            salesDetail.BfUnitCost = histDetail.BfUnitCost;  // �ύX�O����
            salesDetail.CmpltSalesRowNo = histDetail.CmpltSalesRowNo;  // �ꎮ���הԍ�
            salesDetail.CmpltGoodsMakerCd = histDetail.CmpltGoodsMakerCd;  // ���[�J�[�R�[�h�i�ꎮ�j
            salesDetail.CmpltMakerName = histDetail.CmpltMakerName;  // ���[�J�[���́i�ꎮ�j
            salesDetail.CmpltMakerKanaName = histDetail.CmpltMakerKanaName;  // ���[�J�[�J�i���́i�ꎮ�j
            salesDetail.CmpltGoodsName = histDetail.CmpltGoodsName;  // ���i���́i�ꎮ�j
            salesDetail.CmpltShipmentCnt = histDetail.CmpltShipmentCnt;  // ���ʁi�ꎮ�j
            salesDetail.CmpltSalesUnPrcFl = histDetail.CmpltSalesUnPrcFl;  // ����P���i�ꎮ�j
            salesDetail.CmpltSalesMoney = histDetail.CmpltSalesMoney;  // ������z�i�ꎮ�j
            salesDetail.CmpltSalesUnitCost = histDetail.CmpltSalesUnitCost;  // �����P���i�ꎮ�j
            salesDetail.CmpltCost = histDetail.CmpltCost;  // �������z�i�ꎮ�j
            salesDetail.CmpltPartySalSlNum = histDetail.CmpltPartySalSlNum;  // �����`�[�ԍ��i�ꎮ�j
            salesDetail.CmpltNote = histDetail.CmpltNote;  // �ꎮ���l
            salesDetail.PrtGoodsNo = histDetail.PrtGoodsNo;  // ����p���i�ԍ�
            salesDetail.PrtMakerCode = histDetail.PrtMakerCode;  // ����p���[�J�[�R�[�h
            salesDetail.PrtMakerName = histDetail.PrtMakerName;  // ����p���[�J�[����
            salesDetail.CampaignCode = histDetail.CampaignCode;  // �L�����y�[���R�[�h
            salesDetail.CampaignName = histDetail.CampaignName;  // �L�����y�[������
            salesDetail.GoodsDivCd = histDetail.GoodsDivCd;  // ���i���
            salesDetail.AnswerDelivDate = histDetail.AnswerDelivDate;  // �񓚔[��
            salesDetail.RecycleDiv = histDetail.RecycleDiv;  // ���T�C�N���敪
            salesDetail.RecycleDivNm = histDetail.RecycleDivNm;  // ���T�C�N���敪����
            salesDetail.WayToAcptOdr = histDetail.WayToAcptOdr;  // �󒍕��@
            # endregion
            return salesDetail;
        }
        /// <summary>
        /// ���㗚�𖾍׃��X�g�����㖾�׃��X�g
        /// </summary>
        /// <param name="histDetailList"></param>
        /// <returns></returns>
        private ArrayList CopyToSalesDetailListFromSalesHistDtlList( ArrayList histDetailList )
        {
            ArrayList retList = new ArrayList();

            foreach ( SalesHistDtlWork histDetail in histDetailList )
            {
                retList.Add( CopyToSalesDetailFromSalesHistDtl( histDetail ) );
            }

            return retList;
        }
        /// <summary>
        /// �d���������d��
        /// </summary>
        /// <param name="stockHisParaWork"></param>
        /// <returns></returns>
        private StockSlipWork CopyToStockSlipFromStockHist( StockSlipHistWork stockHist )
        {
            StockSlipWork stockSlip = new StockSlipWork();
            # region [Copy]
            stockSlip.CreateDateTime = stockHist.CreateDateTime;  // �쐬����
            stockSlip.UpdateDateTime = stockHist.UpdateDateTime;  // �X�V����
            stockSlip.EnterpriseCode = stockHist.EnterpriseCode;  // ��ƃR�[�h
            stockSlip.FileHeaderGuid = stockHist.FileHeaderGuid;  // GUID
            stockSlip.UpdEmployeeCode = stockHist.UpdEmployeeCode;  // �X�V�]�ƈ��R�[�h
            stockSlip.UpdAssemblyId1 = stockHist.UpdAssemblyId1;  // �X�V�A�Z���u��ID1
            stockSlip.UpdAssemblyId2 = stockHist.UpdAssemblyId2;  // �X�V�A�Z���u��ID2
            stockSlip.LogicalDeleteCode = stockHist.LogicalDeleteCode;  // �_���폜�敪
            stockSlip.SupplierFormal = stockHist.SupplierFormal;  // �d���`��
            stockSlip.SupplierSlipNo = stockHist.SupplierSlipNo;  // �d���`�[�ԍ�
            stockSlip.SectionCode = stockHist.SectionCode;  // ���_�R�[�h
            stockSlip.SubSectionCode = stockHist.SubSectionCode;  // ����R�[�h
            stockSlip.DebitNoteDiv = stockHist.DebitNoteDiv;  // �ԓ`�敪
            stockSlip.DebitNLnkSuppSlipNo = stockHist.DebitNLnkSuppSlipNo;  // �ԍ��A���d���`�[�ԍ�
            stockSlip.SupplierSlipCd = stockHist.SupplierSlipCd;  // �d���`�[�敪
            stockSlip.StockGoodsCd = stockHist.StockGoodsCd;  // �d�����i�敪
            stockSlip.AccPayDivCd = stockHist.AccPayDivCd;  // ���|�敪
            stockSlip.StockSectionCd = stockHist.StockSectionCd;  // �d�����_�R�[�h
            stockSlip.StockAddUpSectionCd = stockHist.StockAddUpSectionCd;  // �d���v�㋒�_�R�[�h
            stockSlip.StockSlipUpdateCd = stockHist.StockSlipUpdateCd;  // �d���`�[�X�V�敪
            stockSlip.InputDay = stockHist.InputDay;  // ���͓�
            stockSlip.ArrivalGoodsDay = stockHist.ArrivalGoodsDay;  // ���ד�
            stockSlip.StockDate = stockHist.StockDate;  // �d����
            stockSlip.StockAddUpADate = stockHist.StockAddUpADate;  // �d���v����t
            stockSlip.DelayPaymentDiv = stockHist.DelayPaymentDiv;  // �����敪
            stockSlip.PayeeCode = stockHist.PayeeCode;  // �x����R�[�h
            stockSlip.PayeeSnm = stockHist.PayeeSnm;  // �x���旪��
            stockSlip.SupplierCd = stockHist.SupplierCd;  // �d����R�[�h
            stockSlip.SupplierNm1 = stockHist.SupplierNm1;  // �d���於1
            stockSlip.SupplierNm2 = stockHist.SupplierNm2;  // �d���於2
            stockSlip.SupplierSnm = stockHist.SupplierSnm;  // �d���旪��
            stockSlip.BusinessTypeCode = stockHist.BusinessTypeCode;  // �Ǝ�R�[�h
            stockSlip.BusinessTypeName = stockHist.BusinessTypeName;  // �Ǝ햼��
            stockSlip.SalesAreaCode = stockHist.SalesAreaCode;  // �̔��G���A�R�[�h
            stockSlip.SalesAreaName = stockHist.SalesAreaName;  // �̔��G���A����
            stockSlip.StockInputCode = stockHist.StockInputCode;  // �d�����͎҃R�[�h
            stockSlip.StockInputName = stockHist.StockInputName;  // �d�����͎Җ���
            stockSlip.StockAgentCode = stockHist.StockAgentCode;  // �d���S���҃R�[�h
            stockSlip.StockAgentName = stockHist.StockAgentName;  // �d���S���Җ���
            stockSlip.SuppTtlAmntDspWayCd = stockHist.SuppTtlAmntDspWayCd;  // �d���摍�z�\�����@�敪
            stockSlip.TtlAmntDispRateApy = stockHist.TtlAmntDispRateApy;  // ���z�\���|���K�p�敪
            stockSlip.StockTotalPrice = stockHist.StockTotalPrice;  // �d�����z���v
            stockSlip.StockSubttlPrice = stockHist.StockSubttlPrice;  // �d�����z���v
            stockSlip.StockTtlPricTaxInc = stockHist.StockTtlPricTaxInc;  // �d�����z�v�i�ō��݁j
            stockSlip.StockTtlPricTaxExc = stockHist.StockTtlPricTaxExc;  // �d�����z�v�i�Ŕ����j
            stockSlip.StockNetPrice = stockHist.StockNetPrice;  // �d���������z
            stockSlip.StockPriceConsTax = stockHist.StockPriceConsTax;  // �d�����z����Ŋz
            stockSlip.TtlItdedStcOutTax = stockHist.TtlItdedStcOutTax;  // �d���O�őΏۊz���v
            stockSlip.TtlItdedStcInTax = stockHist.TtlItdedStcInTax;  // �d�����őΏۊz���v
            stockSlip.TtlItdedStcTaxFree = stockHist.TtlItdedStcTaxFree;  // �d����ېőΏۊz���v
            stockSlip.StockOutTax = stockHist.StockOutTax;  // �d�����z����Ŋz�i�O�Łj
            stockSlip.StckPrcConsTaxInclu = stockHist.StckPrcConsTaxInclu;  // �d�����z����Ŋz�i���Łj
            stockSlip.StckDisTtlTaxExc = stockHist.StckDisTtlTaxExc;  // �d���l�����z�v�i�Ŕ����j
            stockSlip.ItdedStockDisOutTax = stockHist.ItdedStockDisOutTax;  // �d���l���O�őΏۊz���v
            stockSlip.ItdedStockDisInTax = stockHist.ItdedStockDisInTax;  // �d���l�����őΏۊz���v
            stockSlip.ItdedStockDisTaxFre = stockHist.ItdedStockDisTaxFre;  // �d���l����ېőΏۊz���v
            stockSlip.StockDisOutTax = stockHist.StockDisOutTax;  // �d���l������Ŋz�i�O�Łj
            stockSlip.StckDisTtlTaxInclu = stockHist.StckDisTtlTaxInclu;  // �d���l������Ŋz�i���Łj
            stockSlip.TaxAdjust = stockHist.TaxAdjust;  // ����Œ����z
            stockSlip.BalanceAdjust = stockHist.BalanceAdjust;  // �c�������z
            stockSlip.SuppCTaxLayCd = stockHist.SuppCTaxLayCd;  // �d�������œ]�ŕ����R�[�h
            stockSlip.SupplierConsTaxRate = stockHist.SupplierConsTaxRate;  // �d�������Őŗ�
            stockSlip.AccPayConsTax = stockHist.AccPayConsTax;  // ���|�����
            stockSlip.StockFractionProcCd = stockHist.StockFractionProcCd;  // �d���[�������敪
            stockSlip.AutoPayment = stockHist.AutoPayment;  // �����x���敪
            stockSlip.AutoPaySlipNum = stockHist.AutoPaySlipNum;  // �����x���`�[�ԍ�
            stockSlip.RetGoodsReasonDiv = stockHist.RetGoodsReasonDiv;  // �ԕi���R�R�[�h
            stockSlip.RetGoodsReason = stockHist.RetGoodsReason;  // �ԕi���R
            stockSlip.PartySaleSlipNum = stockHist.PartySaleSlipNum;  // �����`�[�ԍ�
            stockSlip.SupplierSlipNote1 = stockHist.SupplierSlipNote1;  // �d���`�[���l1
            stockSlip.SupplierSlipNote2 = stockHist.SupplierSlipNote2;  // �d���`�[���l2
            stockSlip.DetailRowCount = stockHist.DetailRowCount;  // ���׍s��
            stockSlip.EdiSendDate = stockHist.EdiSendDate;  // �d�c�h���M��
            stockSlip.EdiTakeInDate = stockHist.EdiTakeInDate;  // �d�c�h�捞��
            stockSlip.UoeRemark1 = stockHist.UoeRemark1;  // �t�n�d���}�[�N�P
            stockSlip.UoeRemark2 = stockHist.UoeRemark2;  // �t�n�d���}�[�N�Q
            stockSlip.SlipPrintDivCd = stockHist.SlipPrintDivCd;  // �`�[���s�敪
            stockSlip.SlipPrintFinishCd = stockHist.SlipPrintFinishCd;  // �`�[���s�ϋ敪
            stockSlip.StockSlipPrintDate = stockHist.StockSlipPrintDate;  // �d���`�[���s��
            stockSlip.SlipPrtSetPaperId = stockHist.SlipPrtSetPaperId;  // �`�[����ݒ�p���[ID
            # endregion
            return stockSlip;
        }
        /// <summary>
        /// �d�����𖾍ׁ��d������
        /// </summary>
        /// <param name="histDetail"></param>
        /// <returns></returns>
        private StockDetailWork CopyToStockDetailFromStockHistDtl( StockSlHistDtlWork histDetail )
        {
            StockDetailWork stockDetail = new StockDetailWork();
            # region [Copy]
            stockDetail.CreateDateTime = histDetail.CreateDateTime;  // �쐬����
            stockDetail.UpdateDateTime = histDetail.UpdateDateTime;  // �X�V����
            stockDetail.EnterpriseCode = histDetail.EnterpriseCode;  // ��ƃR�[�h
            stockDetail.FileHeaderGuid = histDetail.FileHeaderGuid;  // GUID
            stockDetail.UpdEmployeeCode = histDetail.UpdEmployeeCode;  // �X�V�]�ƈ��R�[�h
            stockDetail.UpdAssemblyId1 = histDetail.UpdAssemblyId1;  // �X�V�A�Z���u��ID1
            stockDetail.UpdAssemblyId2 = histDetail.UpdAssemblyId2;  // �X�V�A�Z���u��ID2
            stockDetail.LogicalDeleteCode = histDetail.LogicalDeleteCode;  // �_���폜�敪
            stockDetail.AcceptAnOrderNo = histDetail.AcceptAnOrderNo;  // �󒍔ԍ�
            stockDetail.SupplierFormal = histDetail.SupplierFormal;  // �d���`��
            stockDetail.SupplierSlipNo = histDetail.SupplierSlipNo;  // �d���`�[�ԍ�
            stockDetail.StockRowNo = histDetail.StockRowNo;  // �d���s�ԍ�
            stockDetail.SectionCode = histDetail.SectionCode;  // ���_�R�[�h
            stockDetail.SubSectionCode = histDetail.SubSectionCode;  // ����R�[�h
            stockDetail.CommonSeqNo = histDetail.CommonSeqNo;  // ���ʒʔ�
            stockDetail.StockSlipDtlNum = histDetail.StockSlipDtlNum;  // �d�����גʔ�
            stockDetail.SupplierFormalSrc = histDetail.SupplierFormalSrc;  // �d���`���i���j
            stockDetail.StockSlipDtlNumSrc = histDetail.StockSlipDtlNumSrc;  // �d�����גʔԁi���j
            stockDetail.AcptAnOdrStatusSync = histDetail.AcptAnOdrStatusSync;  // �󒍃X�e�[�^�X�i�����j
            stockDetail.SalesSlipDtlNumSync = histDetail.SalesSlipDtlNumSync;  // ���㖾�גʔԁi�����j
            stockDetail.StockSlipCdDtl = histDetail.StockSlipCdDtl;  // �d���`�[�敪�i���ׁj
            stockDetail.StockAgentCode = histDetail.StockAgentCode;  // �d���S���҃R�[�h
            stockDetail.StockAgentName = histDetail.StockAgentName;  // �d���S���Җ���
            stockDetail.GoodsKindCode = histDetail.GoodsKindCode;  // ���i����
            stockDetail.GoodsMakerCd = histDetail.GoodsMakerCd;  // ���i���[�J�[�R�[�h
            stockDetail.MakerName = histDetail.MakerName;  // ���[�J�[����
            stockDetail.MakerKanaName = histDetail.MakerKanaName;  // ���[�J�[�J�i����
            stockDetail.CmpltMakerKanaName = histDetail.CmpltMakerKanaName;  // ���[�J�[�J�i���́i�ꎮ�j
            stockDetail.GoodsNo = histDetail.GoodsNo;  // ���i�ԍ�
            stockDetail.GoodsName = histDetail.GoodsName;  // ���i����
            stockDetail.GoodsNameKana = histDetail.GoodsNameKana;  // ���i���̃J�i
            stockDetail.GoodsLGroup = histDetail.GoodsLGroup;  // ���i�啪�ރR�[�h
            stockDetail.GoodsLGroupName = histDetail.GoodsLGroupName;  // ���i�啪�ޖ���
            stockDetail.GoodsMGroup = histDetail.GoodsMGroup;  // ���i�����ރR�[�h
            stockDetail.GoodsMGroupName = histDetail.GoodsMGroupName;  // ���i�����ޖ���
            stockDetail.BLGroupCode = histDetail.BLGroupCode;  // BL�O���[�v�R�[�h
            stockDetail.BLGroupName = histDetail.BLGroupName;  // BL�O���[�v����
            stockDetail.BLGoodsCode = histDetail.BLGoodsCode;  // BL���i�R�[�h
            stockDetail.BLGoodsFullName = histDetail.BLGoodsFullName;  // BL���i�R�[�h���́i�S�p�j
            stockDetail.EnterpriseGanreCode = histDetail.EnterpriseGanreCode;  // ���Е��ރR�[�h
            stockDetail.EnterpriseGanreName = histDetail.EnterpriseGanreName;  // ���Е��ޖ���
            stockDetail.WarehouseCode = histDetail.WarehouseCode;  // �q�ɃR�[�h
            stockDetail.WarehouseName = histDetail.WarehouseName;  // �q�ɖ���
            stockDetail.WarehouseShelfNo = histDetail.WarehouseShelfNo;  // �q�ɒI��
            stockDetail.StockOrderDivCd = histDetail.StockOrderDivCd;  // �d���݌Ɏ�񂹋敪
            stockDetail.OpenPriceDiv = histDetail.OpenPriceDiv;  // �I�[�v�����i�敪
            stockDetail.GoodsRateRank = histDetail.GoodsRateRank;  // ���i�|�������N
            stockDetail.CustRateGrpCode = histDetail.CustRateGrpCode;  // ���Ӑ�|���O���[�v�R�[�h
            stockDetail.SuppRateGrpCode = histDetail.SuppRateGrpCode;  // �d����|���O���[�v�R�[�h
            stockDetail.ListPriceTaxExcFl = histDetail.ListPriceTaxExcFl;  // �艿�i�Ŕ��C�����j
            stockDetail.ListPriceTaxIncFl = histDetail.ListPriceTaxIncFl;  // �艿�i�ō��C�����j
            stockDetail.StockRate = histDetail.StockRate;  // �d����
            stockDetail.RateSectStckUnPrc = histDetail.RateSectStckUnPrc;  // �|���ݒ苒�_�i�d���P���j
            stockDetail.RateDivStckUnPrc = histDetail.RateDivStckUnPrc;  // �|���ݒ�敪�i�d���P���j
            stockDetail.UnPrcCalcCdStckUnPrc = histDetail.UnPrcCalcCdStckUnPrc;  // �P���Z�o�敪�i�d���P���j
            stockDetail.PriceCdStckUnPrc = histDetail.PriceCdStckUnPrc;  // ���i�敪�i�d���P���j
            stockDetail.StdUnPrcStckUnPrc = histDetail.StdUnPrcStckUnPrc;  // ��P���i�d���P���j
            stockDetail.FracProcUnitStcUnPrc = histDetail.FracProcUnitStcUnPrc;  // �[�������P�ʁi�d���P���j
            stockDetail.FracProcStckUnPrc = histDetail.FracProcStckUnPrc;  // �[�������i�d���P���j
            stockDetail.StockUnitPriceFl = histDetail.StockUnitPriceFl;  // �d���P���i�Ŕ��C�����j
            stockDetail.StockUnitTaxPriceFl = histDetail.StockUnitTaxPriceFl;  // �d���P���i�ō��C�����j
            stockDetail.StockUnitChngDiv = histDetail.StockUnitChngDiv;  // �d���P���ύX�敪
            stockDetail.BfStockUnitPriceFl = histDetail.BfStockUnitPriceFl;  // �ύX�O�d���P���i�����j
            stockDetail.BfListPrice = histDetail.BfListPrice;  // �ύX�O�艿
            stockDetail.RateBLGoodsCode = histDetail.RateBLGoodsCode;  // BL���i�R�[�h�i�|���j
            stockDetail.RateBLGoodsName = histDetail.RateBLGoodsName;  // BL���i�R�[�h���́i�|���j
            stockDetail.RateGoodsRateGrpCd = histDetail.RateGoodsRateGrpCd;  // ���i�|���O���[�v�R�[�h�i�|���j
            stockDetail.RateGoodsRateGrpNm = histDetail.RateGoodsRateGrpNm;  // ���i�|���O���[�v���́i�|���j
            stockDetail.RateBLGroupCode = histDetail.RateBLGroupCode;  // BL�O���[�v�R�[�h�i�|���j
            stockDetail.RateBLGroupName = histDetail.RateBLGroupName;  // BL�O���[�v���́i�|���j
            stockDetail.StockCount = histDetail.StockCount;  // �d����
            stockDetail.StockPriceTaxExc = histDetail.StockPriceTaxExc;  // �d�����z�i�Ŕ����j
            stockDetail.StockPriceTaxInc = histDetail.StockPriceTaxInc;  // �d�����z�i�ō��݁j
            stockDetail.StockGoodsCd = histDetail.StockGoodsCd;  // �d�����i�敪
            stockDetail.StockPriceConsTax = histDetail.StockPriceConsTax;  // �d�����z����Ŋz
            stockDetail.TaxationCode = histDetail.TaxationCode;  // �ېŋ敪
            stockDetail.StockDtiSlipNote1 = histDetail.StockDtiSlipNote1;  // �d���`�[���ה��l1
            stockDetail.SalesCustomerCode = histDetail.SalesCustomerCode;  // �̔���R�[�h
            stockDetail.SalesCustomerSnm = histDetail.SalesCustomerSnm;  // �̔��旪��
            stockDetail.OrderNumber = histDetail.OrderNumber;  // �����ԍ�
            stockDetail.SlipMemo1 = histDetail.SlipMemo1;  // �`�[�����P
            stockDetail.SlipMemo2 = histDetail.SlipMemo2;  // �`�[�����Q
            stockDetail.SlipMemo3 = histDetail.SlipMemo3;  // �`�[�����R
            stockDetail.InsideMemo1 = histDetail.InsideMemo1;  // �Г������P
            stockDetail.InsideMemo2 = histDetail.InsideMemo2;  // �Г������Q
            stockDetail.InsideMemo3 = histDetail.InsideMemo3;  // �Г������R
            # endregion
            return stockDetail;
        }
        /// <summary>
        /// �d�����𖾍׃��X�g���d�����׃��X�g
        /// </summary>
        /// <param name="stockHisDtlList"></param>
        /// <returns></returns>
        private ArrayList CopyToStockDetailListFromStockHistDtlList( ArrayList histDetailList )
        {
            ArrayList retList = new ArrayList();

            foreach ( StockSlHistDtlWork histDetail in histDetailList )
            {
                retList.Add( CopyToStockDetailFromStockHistDtl( histDetail ) );
            }

            return retList;
        }
        # endregion

        # region [IOWriter����R�s�[�������ʏ���]
        /// <summary>
        /// SQL�R�l�N�V��������
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private SqlConnection CreateSqlConnection( bool p )
        {
            //�R�l�N�V��������
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
            if ( connectionText == null || connectionText == "" ) return null;

            //SQL������
            SqlConnection sqlConnection = new SqlConnection( connectionText );
            sqlConnection.Open();

            return sqlConnection;
        }
        /// <summary>
        /// �p�����[�^�ʒu�擾
        /// </summary>
        /// <param name="paramArray">�󂯎��p�����[�^List</param>
        /// <param name="type">�擾�^�C�v</param>
        /// <param name="pattern">�p�����[�^�p�^�[���F0�N���X 1:Array</param>
        /// <returns>�p�����[�^�ʒu:�����ꍇ��-1</returns>
        private int MakePosition( CustomSerializeArrayList paramArray, Type type, Int32 pattern )
        {
            int result = -1;

            //�p�����[�^���擾
            if ( pattern == 0 )
            {
                for ( int i = 0; i < paramArray.Count; i++ )
                {
                    if ( paramArray[i] != null && paramArray[i].GetType() == type )
                    {
                        result = i;
                        break;
                    }
                }
            }
            else
            {
                for ( int i = 0; i < paramArray.Count; i++ )
                {
                    if ( paramArray[i] is ArrayList )
                    {
                        ArrayList al = paramArray[i] as ArrayList;
                        if ( al != null && al.Count > 0 )
                        {
                            if ( al[0] != null && al[0].GetType() == type )
                            {
                                result = i;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Read�p�厲�p�����[�^����
        /// </summary>
        /// <param name="paramArray">�󂯎��p�����[�^List</param>
        /// <returns>STATUS</returns>
        /// <returns>
        /// <br>Update Note: 2022/05/05 ����</br>
        /// <br>�Ǘ��ԍ�   : 11870080-00</br>
        /// <br>           : �[�i���d�q����A�g�Ή�</br>
        /// </returns>
        //private int MakeReadFunctionParam( ref CustomSerializeArrayList paramArray )
        private int MakeReadFunctionParam( ref ArrayList paramArray )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�Ƃ肠��������w�b�_���[�N�𔄏�`�[�p�����[�^�Ƃ��Đ�������
            //����ȊO�̏������ǉ����ꂽ��Read�p�p�����[�^�N���X�𐶐�����
            foreach ( object obj in paramArray )
            {
                IOWriteMAHNBReadWork readWork = obj as IOWriteMAHNBReadWork;

                if ( readWork != null )
                {
                    //Read�p�����[�^�𐶐�
                    //Read�p�����[�^�͑������̌����L�[�S�ĂƂ���
                    SalesSlipReadWork salesSlipReadWork = new SalesSlipReadWork();

                    salesSlipReadWork.EnterpriseCode = readWork.EnterpriseCode;
                    salesSlipReadWork.AcptAnOdrStatus = readWork.AcptAnOdrStatus;
                    salesSlipReadWork.SalesSlipNum = readWork.SalesSlipNum;
                    salesSlipReadWork.DebitNoteDiv = readWork.DebitNoteDiv;
                    salesSlipReadWork.SalesSlipCd = readWork.SalesSlipCd;
                    salesSlipReadWork.SalesGoodsCd = readWork.SalesGoodsCd;
                    // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------->>>>>
                    salesSlipReadWork.LogicalDeleteCodeFlg = readWork.LogicalDeleteCodeFlg;
                    // --------ADD 2022/05/05 ���� �[�i���d�q����Ή��@-------<<<<<

                    paramArray.Add( salesSlipReadWork );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
        }
        # endregion
        # endregion

        # region [�`�[�p�����[�^���X�g���쏈��]
        /// <summary>
        /// List ���[�e�B���e�B�N���X
        /// </summary>
        private class SlipListUtils : ListUtils
        {
            /*
            /// <summary>�����p�^�[�� Find() �Ŏg�p</summary>
            public enum FindType
            {
                /// <summary>�N���X</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }
            */
            /// <summary>�����Ώۍ��� FindSlipDetail() �Ŏg�p</summary>
            public enum FindItem
            {
                /// <summary>�ʏ�</summary>
                Normal,
                /// <summary>�v�㌳</summary>
                Source,
                /// <summary>�����v��</summary>
                Synchronize,
                /// <summary>UOE����</summary>
                UoeOrder
                # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
            /// <summary>����ꎞ</summary>
            SalesTemp
#endif
                # endregion
            }

            /// <summary>
            /// �p�����[�^�Ɏw�肳�ꂽ�N���X�ɉ������`�[�^�C�v���擾���܂��B
            /// </summary>
            /// <returns>SlipType</returns>
            public static SlipType GetSlipType( object obj )
            {
                SlipType result = SlipType.None;

                if ( obj is ArrayList )
                {
                    ArrayList slips = obj as ArrayList;

                    if ( SlipListUtils.IsNotEmpty( slips ) )
                    {
                        object findObj = null;

                        // ���㖾�׃f�[�^����������
                        findObj = SlipListUtils.Find( slips, typeof( SalesDetailWork ), FindType.Array );

# if false
                        if ( findObj == null )
                        {
                            // �d�����׃f�[�^����������(���ׂŌ�������͔̂����f�[�^���܂܂�邽��)
                            findObj = SlipListUtils.Find( slips, typeof( StockDetailWork ), FindType.Array );
                        }

                        if ( findObj == null )
                        {
                            // UOE�������׃f�[�^����������
                            findObj = SlipListUtils.Find( slips, typeof( UOEOrderDtlWork ), FindType.Array );
                        }

                        if ( findObj == null )
                        {
                            // �d���폜�p�����[�^
                            findObj = SlipListUtils.Find( slips, typeof( IOWriteMASIRDeleteWork ), FindType.Class );
                        }

                        if ( findObj == null )
                        {
                            // ����폜�p�����[�^
                            findObj = SlipListUtils.Find( slips, typeof( IOWriteMAHNBDeleteWork ), FindType.Class );
                        }
                        if ( findObj == null )
                        {
                            // �݌ɒ����f�[�^
                            // 2009/02/26 ���|�����I�v�V�����Ή�>>>>>>>>>>>>>>>
                            //// 2009/02/10 >>>>>>>>
                            ////findObj = SlipListUtils.Find(slips, typeof(StockAdjustWork), FindType.Array); //DEL
                            ////�݌ɒ������׃f�[�^�N���X�̃��X�g���擾����悤�ɏC��
                            //findObj = SlipListUtils.Find(slips, typeof(StockAdjustDtlWork), FindType.Array); //ADD
                            //// 2009/02/10 <<<<<<<<

                            ArrayList adjustcs = slips[0] as ArrayList;
                            findObj = SlipListUtils.Find( adjustcs, typeof( StockAdjustDtlWork ), FindType.Array ); //ADD

                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
# endif


                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
                if (findObj == null)
                {
                    // ����ꎞ�f�[�^����������
                    findObj = SlipListUtils.Find(slips, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                }
#endif
                        # endregion

                        if ( SlipListUtils.IsNotEmpty( findObj as ArrayList ) )
                        {
                            findObj = (findObj as ArrayList)[0];
                        }

                        if ( findObj is SalesDetailWork )
                        {
                            switch ( (findObj as SalesDetailWork).AcptAnOdrStatus )
                            {
                                case (int)SlipType.Estimation:     // ����
                                    result = SlipType.Estimation;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // ��
                                    result = SlipType.AcceptAnOrder;
                                    break;
                                case (int)SlipType.Shipment:       // �o��
                                    result = SlipType.Shipment;
                                    break;
                                case (int)SlipType.Sales:          // ����
                                    result = SlipType.Sales;
                                    break;
                            }
                        }
# if false
                        else if ( findObj is StockDetailWork )
                        {
                            switch ( (findObj as StockDetailWork).SupplierFormal )
                            {
                                case (int)SlipType.Order:     // ����
                                    result = SlipType.Order;
                                    break;
                                case (int)SlipType.Arrival:   // ����
                                    result = SlipType.Arrival;
                                    break;
                                case (int)SlipType.Purchase:  // �d��
                                    result = SlipType.Purchase;
                                    break;
                            }
                        }
                        else if ( findObj is UOEOrderDtlWork )
                        {
                            result = SlipType.UoeOrder;  // UOE����
                        }
                        else if ( findObj is StockAdjustDtlWork )
                        {
                            result = SlipType.StockAdjust;  // �݌ɒ���
                        }
# endif
                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    result = SlipType.SalesTemp;
                        //}
                        # endregion
                    }
                }
                else if ( obj is IOWriteMAHNBDeleteWork )
                {
                    result = SlipType.SalesDel;  // ����폜
                }
                else if ( obj is IOWriteMASIRDeleteWork )
                {
                    result = SlipType.PurchaseDel;  // �d���폜
                }

                return result;
            }


            /// <summary>
            /// �`�[�^�C�v��GUID�����v���閾�׃f�[�^���擾���܂��B
            /// </summary>
            /// <param name="sliplist">�����Ώۃ��X�g</param>
            /// <param name="finditem">�����Ώۍ���</param>
            /// <param name="sliptype">�`�[�^�C�v</param>
            /// <param name="guid">����GUID</param>
            /// <param name="source">���������׃f�[�^</param>
            /// <returns>�I�u�W�F�N�g</returns>
            public static object FindSlipDetail( ArrayList sliplist, FindItem finditem, SlipType sliptype, Guid guid, object source )
            {
                object retdtil = null;

                foreach ( object item in sliplist )
                {
                    if ( item is ArrayList )
                    {
                        // �ċA�������s��
                        retdtil = SlipListUtils.FindSlipDetail( item as ArrayList, finditem, sliptype, guid, source );
                    }
                    else
                    {
                        // �������̖��׃f�[�^�ƈقȂ�ꍇ�ɂ̂݃`�F�b�N����
                        if ( item != source )
                        {
                            switch ( finditem )
                            {
                                case FindItem.Normal:
                                    {
                                        # region [�󒍃X�e�[�^�X or �d���`���������ΏۂƂ���]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if ( item is SalesDetailWork )
                                                    {
                                                        // �󒍃X�e�[�^�X��GUID���`�F�b�N����
                                                        if ( (item as SalesDetailWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# if false
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if ( item is StockDetailWork )
                                                    {
                                                        // �d���`����GUID���`�F�b�N����
                                                        if ( (item as StockDetailWork).SupplierFormal == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# endif
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.Source:
                                    {
                                        # region [�󒍃X�e�[�^�X(�v�㌳) or �d���`��(�v�㌳)�������ΏۂƂ���]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if ( item is SalesDetailWork )
                                                    {
                                                        // �󒍃X�e�[�^�X(�v�㌳)��GUID���`�F�b�N����
                                                        if ( (item as SalesDetailWork).AcptAnOdrStatusSrc == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# if false
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if ( item is StockDetailWork )
                                                    {
                                                        // �d���`��(�v�㌳)��GUID���`�F�b�N����
                                                        if ( (item as StockDetailWork).SupplierFormalSrc == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# endif
                                        }
                                        # endregion
                                        break;
                                    }
# if false
                                case FindItem.Synchronize:
                                    {
                                # region [�󒍃X�e�[�^�X(����) or �d���`��(����)�������ΏۂƂ���]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if ( item is StockDetailWork )
                                                    {
                                                        // �󒍃X�e�[�^�X(����)��GUID���`�F�b�N����
                                                        if ( (item as StockDetailWork).AcptAnOdrStatusSync == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if ( item is SalesDetailWork )
                                                    {
                                                        // �d���`��(����)��GUID���`�F�b�N����
                                                        if ( (item as SalesDetailWork).SupplierFormalSync == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.UoeOrder:
                                    {
                                #region [�󒍃X�e�[�^�X or �d���`���������ΏۂƂ���]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if ( item is UOEOrderDtlWork )
                                                    {
                                                        // �󒍃X�e�[�^�X��GUID���`�F�b�N����
                                                        if ( (item as UOEOrderDtlWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if ( item is UOEOrderDtlWork )
                                                    {
                                                        // �d���`����GUID���`�F�b�N����
                                                        if ( (item as UOEOrderDtlWork).SupplierFormal == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
# endif
                                # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                                //case FindItem.SalesTemp:
                                //    {
                                //    # region [����ꎞ�f�[�^�������ΏۂƂ���]
                                //        switch (sliptype)
                                //        {
                                //            case SlipType.Order:          // ����
                                //            case SlipType.Arrival:        // ����
                                //            case SlipType.Purchase:       // �d��
                                //                {
                                //                    if (item is SalesTempWork)
                                //                    {
                                //                        // GUID���`�F�b�N����
                                //                        if ((item as SalesTempWork).DtlRelationGuid == guid)
                                //                        {
                                //                            retdtil = item;
                                //                        }
                                //                    }
                                //                    break;
                                //                }
                                //        }
                                //        # endregion
                                //        break;
                                //    }
                                # endregion
                            }
                        }
                    }

                    // �ŏ��Ɍ������f�[�^��Ԃ�
                    if ( retdtil != null )
                    {
                        break;
                    }
                }

                return retdtil;
            }
        }

        /// <summary>
        /// �`�[�^�C�v
        /// </summary>
        internal enum SlipType : int
        {
            /// <summary>���w��</summary>
            None = -1,
            /// <summary>����</summary>
            Estimation = 10,
            /// <summary>��</summary>
            AcceptAnOrder = 20,
            /// <summary>�o��</summary>
            Shipment = 40,
            /// <summary>����</summary>
            Sales = 30,
            /// <summary>����</summary>
            Order = 2,
            /// <summary>����</summary>
            Arrival = 1,
            /// <summary>�d��</summary>
            Purchase = 0,
            /// <summary>UOE����</summary>
            UoeOrder = 98,
            /// <summary>����폜</summary>
            SalesDel = 100,
            /// <summary>�d���폜</summary>
            PurchaseDel = 101,
            /// <summary>�݌ɒ���</summary>
            StockAdjust = 102
            #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
            ///// <summary>����ꎞ(�d�����㓯���v��)</summary>            
            //SalesTemp = 99
            #endregion
        }

        /// <summary>
        /// �`�[�`���Ń\�[�g���s��
        /// </summary>
        internal class SlipTypeComparer : IComparer
        {
            /// <summary>
            /// �`�[���փ^�C�v
            /// </summary>
            public enum SlipSortType
            {
                /// <summary>����</summary>
                Sales,
                /// <summary>�d��</summary>
                Purchase
            }

            public SlipSortType SortType = SlipSortType.Sales;

            /// <summary>
            /// �d������ɓ`�[�`���Ń\�[�g���s��
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare( object x, object y )
            {
                # region [DELETE]
                // SortType �� SlipSortType.Sales(����) �̏ꍇ��
                // 0:����I�v�V������1:���ρ�2:�󒍁�3:�o�ׁ�4:���ぃ5:����(�{6:UOE����)��7:���ׁ�8:�d����9:����ꎞ �̏��ɕ��ѕς���

                // SortType �� SlipSortType.Purchase(�d��) �̏ꍇ��
                // 0:����I�v�V������5:����(�{6:UOE����)��7:���ׁ�8:�d����9:����ꎞ��11:���ρ�12:�󒍁�13:�o�ׁ�14:���� �̏��ɕ��ѕς���
                # endregion

                // SortType �� SlipSortType.Sales(����) �̏ꍇ��
                // 0:����I�v�V������1:�d���폜��2:���ρ�3:�󒍁�4:�o�ׁ�5:���ぃ6:����폜��7:����(�{8:UOE����)��9:���ׁ�10:�d����11:�݌ɒ�����12:����ꎞ �̏��ɕ��ѕς���

                // SortType �� SlipSortType.Purchase(�d��) �̏ꍇ��
                // 0:����I�v�V������6:����폜��7:����(�{8:UOE����)��9:���ׁ�10:�d����11:�݌ɒ�����12:����ꎞ��21:�d���폜��22:���ρ�23:�󒍁�24:�o�ׁ�25:���� �̏��ɕ��ѕς���

                int xValue = 0;
                int yValue = 0;
                int zValue = int.MaxValue;

                int xSlipDtlRegOrder = 0;
                int ySlipDtlRegOrder = 0;
                int zSlipDtlRegOrder = 0;

                const int orderWeight = 20;  // ����̎d���ŕς����я��̏d�݂��w��

                object Z = null;

                for ( int i = 0; i < 2; i++ )
                {
                    Z = (i == 0) ? x : y;

                    if ( Z is IOWriteCtrlOptWork )
                    {
                        // ����I�v�V�����͏�ɐ擪�Ƃ���
                        zValue = 0;
                    }
                    else if ( Z is IOWriteMASIRDeleteWork )
                    {
                        # region [�d���폜�p�����[�^]

                        // �d���폜�p�����[�^
                        zValue = 1;

                        // ���փ^�C�v�ɉ����ďd�݂�݂���
                        zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                        // �d���폜�p�����[�^�������o�^����Ă���ꍇ�́A�d���`���̋t��(��:�d�������ׁ�����:��)�̏��ɕ��ׂ�
                        zSlipDtlRegOrder = 2 - (Z as IOWriteMASIRDeleteWork).SupplierFormal;

                        # endregion
                    }
                    else if ( Z is IOWriteMAHNBDeleteWork )
                    {
                        # region [����폜�p�����[�^]

                        // ����폜�p�����[�^
                        zValue = 6;

                        // ����폜�p�����[�^�������o�^����Ă���ꍇ�́A�󒍃X�e�[�^�X�̋t��(��:�o�ׁ����と�󒍁�����:��)���ɕ��ׂ�
                        zSlipDtlRegOrder = 40 - (Z as IOWriteMAHNBDeleteWork).AcptAnOdrStatus;

                        # endregion
                    }
                    else if ( Z is ArrayList )
                    {
                        object findObj = null;
                        ArrayList zList = Z as ArrayList;

                        # region [�����Ώۂ̒��o]
                        // ���㖾�׃f�[�^����������
                        findObj = SlipListUtils.Find( zList, typeof( SalesDetailWork ), SlipListUtils.FindType.Array );

# if false
                        if ( findObj == null )
                        {
                            // �d�����׃f�[�^����������(���ׂŌ�������͔̂����f�[�^���܂܂�邽��)
                            findObj = SlipListUtils.Find( zList, typeof( StockDetailWork ), SlipListUtils.FindType.Array );
                        }
                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //if (findObj == null)
                        //{
                        //    // ����ꎞ�f�[�^����������
                        //    findObj = SlipListUtils.Find(zList, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                        //}
                        # endregion

                        if ( findObj == null )
                        {
                            // UOE�������׃f�[�^����������
                            findObj = SlipListUtils.Find( zList, typeof( UOEOrderDtlWork ), SlipListUtils.FindType.Array );
                        }

                        if ( findObj == null )
                        {
                            // 2009/02/26 ���|�����I�v�V�����Ή� >>>>>>>>>>>>>>>
                            // �݌ɒ���
                            //findObj = SlipListUtils.Find(zList, typeof(StockAdjustWork), SlipListUtils.FindType.Array);

                            ArrayList adjustList = zList[0] as ArrayList;
                            findObj = SlipListUtils.Find( adjustList, typeof( StockAdjustWork ), SlipListUtils.FindType.Array );
                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
# endif

                        if ( findObj is ArrayList && SlipListUtils.IsNotEmpty( findObj as ArrayList ) )
                        {
                            Z = (findObj as ArrayList)[0];
                        }

                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    Z = findObj;
                        //}
                        # endregion
                        # endregion

                        # region [�����ΏۂɊ�Â����d�݂̐ݒ�]

                        if ( Z is SalesDetailWork )
                        {
                            # region [���㖾�׃f�[�^]

                            switch ( (Z as SalesDetailWork).AcptAnOdrStatus )
                            {
                                case (int)SlipType.Estimation:     // ����
                                    zValue = 2;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // ��
                                    zValue = 3;
                                    break;
                                case (int)SlipType.Shipment:       // �o��
                                    zValue = 4;
                                    break;
                                case (int)SlipType.Sales:          // ����
                                    zValue = 5;
                                    break;
                            }

                            // ���փ^�C�v�ɉ����ďd�݂�݂���
                            zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                            // ����󒍃X�e�[�^�X�̓`�[���r����ۂɁA�`�[���דo�^���ʂ��r���ڂƂ���
                            ArrayList SlpDtlAddInfList = ListUtils.Find( zList, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                            if ( ListUtils.IsNotEmpty( SlpDtlAddInfList ) )
                            {
                                SlpDtlAddInfList.Sort( new SlipDetailAddInfoRegOrderComparer() );
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
# if false
                        else if ( Z is StockDetailWork )
                        {
                        # region [�d�����׃f�[�^]

                            switch ( (Z as StockDetailWork).SupplierFormal )
                            {
                                case (int)SlipType.Order:     // ����
                                    zValue = 7;
                                    break;
                                case (int)SlipType.Arrival:   // ����
                                    zValue = 9;
                                    break;
                                case (int)SlipType.Purchase:  // �d��
                                    zValue = 10;
                                    break;
                            }

                            // ���փ^�C�v�ɉ����ďd�݂�݂���
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            // ����d���`���̓`�[���r����ۂɁA�`�[���דo�^���ʂ��r���ڂƂ���
                            ArrayList SlpDtlAddInfList = ListUtils.Find( zList, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                            if ( ListUtils.IsNotEmpty( SlpDtlAddInfList ) )
                            {
                                SlpDtlAddInfList.Sort( new SlipDetailAddInfoRegOrderComparer() );
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
                        else if ( Z is UOEOrderDtlWork )
                        {
                        # region [UOE�����f�[�^]

                            // UOE����
                            zValue = 8;

                            // ���փ^�C�v�ɉ����ďd�݂�݂���
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            ArrayList SlpDtlAddInfList = ListUtils.Find( zList, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                            if ( ListUtils.IsNotEmpty( SlpDtlAddInfList ) )
                            {
                                SlpDtlAddInfList.Sort( new SlipDetailAddInfoRegOrderComparer() );
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }
                            else
                            {
                                zSlipDtlRegOrder = 0;
                            }

                            # endregion
                        }
                        else if ( Z is StockAdjustWork )
                        {
                        # region [�݌ɒ����f�[�^]
                            zValue = 11;
                            zSlipDtlRegOrder = 0;
                            # endregion
                        }

                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //else if (Z is SalesTempWork)  // ����ꎞ�f�[�^
                        //{
                        //    zValue = 9;

                        //    // ���փ^�C�v�ɉ����ďd�݂�݂���
                        //    zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;
                        //}
                        # endregion
# endif
                        # endregion

                    }

                    if ( i == 0 )
                    {
                        xValue = zValue;
                        xSlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                    else
                    {
                        yValue = zValue;
                        ySlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                }

                // �󒍃X�e�[�^�X or �d���`�� �Ŕ�r
                int compret = xValue.CompareTo( yValue );

                if ( compret == 0 )
                {
                    // �`�[���דo�^���ʂŔ�r
                    compret = xSlipDtlRegOrder.CompareTo( ySlipDtlRegOrder );
                }

                return compret;
            }
        }
        # endregion

        # region [����E�d������I�v�V����]
        /// <summary>
        /// ����E�d������I�v�V����
        /// </summary>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// ����E�d������I�v�V���� �v���p�e�B
        /// </summary>
        private IOWriteCtrlOptWork CtrlOptWork
        {
            get { return this._CtrlOptWork; }

            set
            {
                this._CtrlOptWork = value;
                //this._ResourceName = this.GetResourceName( this._CtrlOptWork.EnterpriseCode );
            }
        }
        # endregion

        # region [�`�[�������݁iIOWriter���g�p�j]
        /// <summary>
        /// �`�[�������ݏ����iIOWriter���g�p�j
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <returns></returns>
        public int WriteByIOWriter( ref object paraList, out string retMsg, out string retItemInfo )
        {
            IOWriteControlDB iOWriteControlDB = new IOWriteControlDB();
            return iOWriteControlDB.Write( ref paraList, out retMsg, out retItemInfo );
        }
        # endregion

        # region [�����`�[�ԍ��ɂ��d���f�[�^����]
        /// <summary>
        /// �����`�[�ԍ��ɂ��d���f�[�^�̌������s���܂��B
        /// </summary>
        /// <param name="retStockSlipList">�������ʂ��i�[���� CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="paraStockSlip">�����������i�[���� StockSlip ���w�肵�܂��B</param>
        /// <param name="mode">0:���S��v 1:�O����v 2:���S��v�{�d�����׎擾</param>
        /// <returns>STATUS</returns>
        public int SearchPartySaleSlipNum( ref object retStockSlipList, object paraStockSlip, int mode )
        {
            // �������d���`�[�̐ԓ`�����Ŏg�p���邽�߁A���𕪂͑ΏۊO�̂܂�
            _stockSlipDB = new StockSlipDB();
            return _stockSlipDB.SearchPartySaleSlipNum( ref retStockSlipList, paraStockSlip, mode );
        }
        # endregion

        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

        // --- ADD 2012/12/17 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �T�[�o�[�V�X�e�����t�擾��߂��܂�		
        /// </summary>
        public DateTime GetServerNowTime()
        {
            return DateTime.Now;
        }
        // --- ADD 2012/12/17 T.Miyamoto ------------------------------<<<<<

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>
        /// ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������
        /// </summary>
        /// <param name="salesDateSt">�J�n�����</param>
        /// <param name="salesDateEd">�I�������</param>
        /// <param name="custPrtPprParam">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2015/02/05</br>
        /// </remarks>
        public int GetSalesDate(out DateTime salesDateSt, out DateTime salesDateEd, object custPrtPprParam, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            salesDateSt = DateTime.MinValue;
            salesDateEd = DateTime.MinValue;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (custPrtPprParam == null) return status;

                //�����p�����[�^
                CustPrtPprWork custPrtPprWork = custPrtPprParam as CustPrtPprWork;

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                DateTime st_salesDate;
                DateTime ed_salesDate;

                // �J�n�������NULL�A�I���������NULL
                if (custPrtPprWork.St_SalesDate != DateTime.MinValue && custPrtPprWork.Ed_SalesDate == DateTime.MinValue)
                {
                    custPrtPprWork.SearchSalDateStEd = 1;
                    status = GetSalesDateProc(custPrtPprWork, logicalMode, out ed_salesDate, ref sqlConnection);

                    salesDateSt = custPrtPprWork.St_SalesDate;
                    salesDateEd = ed_salesDate;
                }
                // �J�n�������NULL�A�I���������NULL
                else if (custPrtPprWork.St_SalesDate == DateTime.MinValue && custPrtPprWork.Ed_SalesDate != DateTime.MinValue)
                {
                    custPrtPprWork.SearchSalDateStEd = 0;
                    status = GetSalesDateProc(custPrtPprWork, logicalMode, out st_salesDate, ref sqlConnection);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesDateSt = st_salesDate;
                        salesDateEd = custPrtPprWork.Ed_SalesDate;
                    }
                }
                // �J�n�������NULL�A�I���������NULL
                else if (custPrtPprWork.St_SalesDate == DateTime.MinValue && custPrtPprWork.Ed_SalesDate == DateTime.MinValue)
                {
                    custPrtPprWork.SearchSalDateStEd = 0;
                    status = GetSalesDateProc(custPrtPprWork, logicalMode, out st_salesDate, ref sqlConnection);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesDateSt = st_salesDate;

                        custPrtPprWork.SearchSalDateStEd = 1;
                        status = GetSalesDateProc(custPrtPprWork, logicalMode, out ed_salesDate, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            salesDateEd = ed_salesDate;
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
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.GetSalesDate Exception=" + ex.Message);
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

        //----- ADD 2015/03/03 ������ Redmine#44701 ---------->>>>>
        /// <summary>
        /// ����f�[�^�E�����f�[�^������t����������
        /// </summary>
        /// <param name="custPrtPprWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="salesDate">�����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ����f�[�^�E�����f�[�^������t����������</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2015/03/03</br>
        /// </remarks>
        private int GetSalesDateProc(CustPrtPprWork custPrtPprWork, ConstantManagement.LogicalMode logicalMode, out DateTime salesDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            salesDate = DateTime.MinValue;
            DateTime searchStockDate = DateTime.MinValue;

            try
            {
                // ����f�[�^������t�̌���
                if (CheckSelectSales(custPrtPprWork))
                {
                    custPrtPprWork.SearchSalDateType = 0; // ����f�[�^������t������
                    status = SearchSalesDateProc(custPrtPprWork, logicalMode, out searchStockDate, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesDate = searchStockDate;
                    }
                }

                // �����f�[�^������t�̌���
                if (CheckSelectDeposit(custPrtPprWork))
                {
                    custPrtPprWork.SearchSalDateType = 1; // �����f�[�^������t������
                    status = SearchSalesDateProc(custPrtPprWork, logicalMode, out searchStockDate, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (custPrtPprWork.SearchSalDateStEd == 0)
                        {
                            if (salesDate == DateTime.MinValue || searchStockDate < salesDate)
                            {
                                salesDate = searchStockDate;
                            }
                        }
                        else
                        {
                            if (searchStockDate > salesDate)
                            {
                                salesDate = searchStockDate;
                            }
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
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.GetSalesDateProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        //----- ADD 2015/03/03 ������ Redmine#44701 ----------<<<<<

        /// <summary>
        /// ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������
        /// </summary>
        /// <param name="custPrtPprWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="salesDate">�����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2015/02/05</br>
        /// <br>UpdateNote  : 2015/03/03 ������ Redmine#44701</br>
        /// <br>            : �����f�[�^�������������������</br>
        /// </remarks>
        //private int GetSalesDateProc(CustPrtPprWork custPrtPprWork, ConstantManagement.LogicalMode logicalMode, out DateTime salesDate, ref SqlConnection sqlConnection) // DEL 2015/03/03 ������ Redmine#44701 #36
        private int SearchSalesDateProc(CustPrtPprWork custPrtPprWork, ConstantManagement.LogicalMode logicalMode, out DateTime salesDate, ref SqlConnection sqlConnection) // ADD 2015/03/03 ������ Redmine#44701 #36
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            salesDate = DateTime.MinValue;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ICustPrtPpr custPrtPpr;
            custPrtPpr = new CustPrtPprSalTblRsltQuery();

            try
            {
                int iType = (int)iSrcType.SalDate;
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, custPrtPprWork, iType, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //�擾���ʃZ�b�g
                    object retWork = custPrtPpr.CopyToResultWorkFromReader(ref myReader, custPrtPprWork, iType);
                    if (retWork != null)
                    {
                        CustPrtPprSalTblRsltWork work = (CustPrtPprSalTblRsltWork)retWork;
                        salesDate = work.SalesDate;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchSalesDateProc Exception=" + ex.Message);
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

            return status;
        }
        //----- ADD 2015/02/05 ������ --------------------<<<<<
    }

    interface ICustPrtPpr
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, ConstantManagement.LogicalMode logicalMode);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam);
    }

    // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
    interface ICustPrtPprOutput
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, bool CreditMng, ConstantManagement.LogicalMode logicalMode);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam, bool CreditMng);
    }
    // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

    /// <summary>
    /// �`�[�E���ׂ̌����^�C�v��񋓂��܂��B
    /// </summary>
    enum iSrcType
    {
        SalTbl = 0,  //����f�[�^����
        DepTbl = 1,  //�����f�[�^����
        BlDsp = 2,   //�c���Ɖ��
        BlTbl = 3,   //�c���ꗗ����
        // -- DEL 2009/09/04 --------------------->>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        //SalHisTbl = 4, // ���㗚���f�[�^����
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ---------------------<<<
        SalDate = 4, // �e�L�X�g�o�͗p������̌��� // ADD 2015/02/05 ������
    }

    /// <summary>
    /// �c���ꗗ�̌����^�C�v��񋓂��܂��B
    /// </summary>
    enum iSrchKndDiv
    {
        CustDmd = 0,  //���Ӑ搿�����z�}�X�^
        CustAcc = 1,  //���Ӑ攄�|���z�}�X�^
    }

    /// <summary>
    /// �`�[�����敪��񋓂��܂��B
    /// </summary>
    enum SearchType
    {
        All = 0,  //0:�S��
        Sal = 1,  //1:����̂�
        Dep = 2,  //2:�����̂�
    }
}