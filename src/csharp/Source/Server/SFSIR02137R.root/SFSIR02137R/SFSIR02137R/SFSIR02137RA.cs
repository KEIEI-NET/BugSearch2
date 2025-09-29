//**********************************************************************//
// System           :   �o�l�D�m�r
// Sub System       :
// Program name     :   �x���X�V���������[�e�B���O
//                  :   SFSIR02137R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   ��{�@�E
// Date             :   2005.08.11
//----------------------------------------------------------------------//
// Update Note      : 20060926 iwa �ԍ��̔Ԃ̋��_���v�㋒�_����X�V���_�ɕύX�i�����ɍ��킹��j
//                  : 20061018 iwa �g�����U�N�V�����������x���Ή�
//                  : 20061222 18322 T.Kimura MA.NS�p�Ɏx���`�[�}�X�^��ύX
//                    20070213 18322 T.Kimura �ԓ`�̍폜�@�\��ǉ�
//                    20070327 18322 T.Kimura �d����x��(���|)���z�}�X�^�̍X�V�������폜
//----------------------------------------------------------------------//
// Update Note      : 20070907 980081 A.Yamada ���ʊ�V�X�e���Ή�
//                  : 20071102 980081 A.Yamada ���C�A�E�g�ύX�Ή�(�x���擙)
//                  : 20071210 980081 A.Yamada EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX
//                  : 20080111 980081 A.Yamada �_���폜�@�\��ǉ�(LogicalDelete)
//                  : 20080117 980081 A.Yamada �X�V�E�폜���G���[���C��
//                  : 20080317 980081 A.Yamada �x�������V�X�e�����t�œo�^����
//----------------------------------------------------------------------//
// Update Note      : 2008/04/22 21112  M.Kubota PM.NS�V�X�e���Ή�
//----------------------------------------------------------------------//
// Update Note      : 2009/04/28 22008 ���� MANTIS 13208 ���_���폜�Ή�
//----------------------------------------------------------------------//
// Update Note      : 2010.04.27 gejun M1007A-�x����`�f�[�^�X�V�ǉ�            
//----------------------------------------------------------------------//
// Update Note      : 2011/07/29 qijh  ���M�ς݂̃`�F�b�N���@��ǉ�
//----------------------------------------------------------------------//
// Update Note      : 2011/11/10 ����  Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------//
// Update Note      : 2011/12/15 tianjw  Redmine#27390 ���_�Ǘ�/������̃`�F�b�N�̑Ή�
//----------------------------------------------------------------------//
// Update Note      : 2012/02/06 �c����
// �Ǘ��ԍ�         : 10707327-00 2012/03/28�z�M��
//                    Redmine#28288 ���M�σf�[�^�C������̑Ή�
//----------------------------------------------------------------------//
// Update Note      : 2012/05/10 yangmj 
//                    ��������W�v�������ɓ`�[���s�s�̏C��
//----------------------------------------------------------------------//
// Update Note      : 2012/08/10 �e�c ���V 
//                    ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�
//----------------------------------------------------------------------//
// Update Note      : 2012/10/18 �{�{ ����
//                    �x���`�[�E��`(�x������)�X�V������ǉ�
//----------------------------------------------------------------------//
// Update Note      : 2012/11/07 FSI�֓� �a�G
//                    �l���E�萔���݂̂̐ԓ`���s�s�E�폜�s�̏�Q�Ή�
//----------------------------------------------------------------------//
// Update Note      : 2013/01/10 zhuhh
// �Ǘ��ԍ�         : 10806793-00 2013/03/13�z�M��
//                    Redmine#34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���
//----------------------------------------------------------------------//
// Update Note      : 2013/02/21 �e�c ���V 
//                    �x���`�[�폜���A��`�f�[�^�R�t�������Ή�
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
//using Broadleaf.Application.Controller;
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/22 M.Kubota
using Broadleaf.Application.Common;  // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �x���X�VDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���f�[�^�̍X�V������s���N���X�ł��B</br>
	/// <br>Programmer : 95089 ��{�@�E</br>
	/// <br>Date       : 2005.08.02</br>
	/// <br></br>
	/// <br>Update Note: 2006.12.22 �ؑ� ����</br>
    /// <br>                        �g��.NS�p�ɕύX</br>
    /// <br>Update Note: 2011/12/15 tianjw</br>
    /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note: 2012/02/06 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
    /// <br>             Redmine#28288 ���M�σf�[�^�C������̑Ή�</br>
    /// <br>Update Note: 2012/05/10  yangmj</br>
    /// <br>           : ��������W�v�������ɓ`�[���s�s�̏C��</br>
    /// <br>Update Note: 2012/08/10  �e�c ���V</br>
    /// <br>           : ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
    /// <br></br>
    /// </remarks>
	[Serializable]
    //public class PaymentSlpDB : RemoteDB, IPaymentSlpDB           //DEL 2008/04/24 M.Kubota
    public class PaymentSlpDB : RemoteWithAppLockDB, IPaymentSlpDB  //ADD 2008/04/24 M.Kubota
	{
        // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// ���M�σ`�F�b�N���s�̃X�e�[�^�X
        /// </summary>
        public const int STATUS_CHK_SEND_ERR = -1001;

        private SecMngSndRcvDB _SecMngSndRcvDB = null;
        /// <summary>
        /// ���_�Ǘ�����M�Ώېݒ�}�X�^�����[�g�v���p�e�B
        /// </summary>
        private SecMngSndRcvDB ScMngSndRcvDB
        {
            get
            {
                if (this._SecMngSndRcvDB == null)
                    this._SecMngSndRcvDB = new SecMngSndRcvDB();
                return this._SecMngSndRcvDB;
            }
        }

        private SecMngSetDB _SecMngSetDB = null;
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�����[�g�v���p�e�B
        /// </summary>
        private SecMngSetDB ScMngSetDB
        {
            get
            {
                if (this._SecMngSetDB == null)
                    this._SecMngSetDB = new SecMngSetDB();
                return this._SecMngSetDB;
            }
        }
        // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

        /// <summary>
		/// �x���X�VDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.02</br>
		/// </remarks>
        public PaymentSlpDB():
            base("SFSIR02140D", "Broadleaf.Application.Remoting.ParamData.CreatePaymentSlpWork", "PAYMENTSLPRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("DepsitMainDB�R���X�g���N�^");
        }

        # region [��������]

        /// <summary>
        /// �x���X�V����
        /// </summary>
        /// <param name="paymentDataWorkByte">�x����񃏁[�N</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����E�x�������������Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �x���ԍ������̎��A�V�K�x���쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : �x�������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Programmer : 95089 ��{�@�E</br>
        /// <br>Date       : 2005.08.11</br>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        /// </remarks>
        //public int Write(ref byte[] paymentDataWorkByte, ref byte[] depositAlwWorkListByte)
        public int Write(ref byte[] paymentDataWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/22 M.Kubota

            string resName = string.Empty;  //ADD 2008/04/22 M.Kubota

            try
            {
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                # region --- DEL 2008/04/22 M.Kubota ---
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                //// XML�̓ǂݍ���
                //PaymentSlpWork paymentDataWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentSlpWork));

                ////SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                ////sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);//20061018 iwa add

                //// �X�V�����b�N����
                //int[] SupplierCdList = { paymentDataWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(paymentDataWork.EnterpriseCode, SupplierCdList, null);	// ���Ӑ�ʃ��b�N��������
                # endregion

                //--- ADD 2008/04/22 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // XML�̓ǂݍ���
                //PaymentSlpWork paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentSlpWork)) as PaymentSlpWork;   //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/22 M.Kubota --->>>
                PaymentDataWork paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentDataWork)) as PaymentDataWork;  //ADD 2008/04/24 M.Kubota

                if (paymentDataWork == null)
                {
                    return status;
                }
                
                PaymentSlpWork paymentSlpWork = null;
                PaymentDtlWork[] paymentDtlWorkArray = null;
                PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);
                //--- ADD 2008/04/22 M.Kubota ---<<<

                if (paymentSlpWork != null)
                {
                    //--- DEL yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                    ////�V�X�e�����b�N(���_) //2009/1/27 Add sakurai
                    //ShareCheckInfo info = new ShareCheckInfo();
                    //info.Keys.Add(paymentSlpWork.EnterpriseCode, ShareCheckType.Section, paymentSlpWork.AddUpSecCode, "");
                    //status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    //if (status != 0) return status;
                    //--- DEL yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<

                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                    // �������b�N�i�`�[���j
                    ShareCheckInfo info = new ShareCheckInfo();
                    int supplierTotalDay = GetSupplierTotalDay(paymentSlpWork.EnterpriseCode, paymentSlpWork.SupplierCd, ref sqlConnection, ref sqlTransaction);
                    info.Keys.Add(new ShareCheckKey(paymentSlpWork.EnterpriseCode, ShareCheckType.SupUpSlip, paymentSlpWork.AddUpSecCode, "", supplierTotalDay, ToLongDate(paymentSlpWork.AddUpADate)));
                    // ���b�N
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;
                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<

                    // �x���}�X�^�X�V����
                    //status = WritePaymentSlpWork(ref paymentDataWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/22 M.Kubota
                    status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/22 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N���� //2009/1/27 Add sakurai
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);  //DEL 2008/04/22 M.Kubota

                    //--- ADD 2008/04/22 M.Kubota --->>>
                    PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                    
                    // XML�֕ϊ����A������̃o�C�i����
                    paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                    //--- ADD 2008/04/22 M.Kubota ---<<<
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤               
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/22 M.Kubota
                //--- ADD 2008/04/22 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/22 M.Kubota ---<<<
            }
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();              //DEL 2008/04/22 M.Kubota
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }

        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
        /// <summary>
        /// �d����̒���(DD)���擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="supplierCd"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetSupplierTotalDay(string enterpriseCode, int supplierCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int totalDay = 99;

            try
            {
                SupplierDB supplierDB = new SupplierDB();
                SupplierWork supplier = new SupplierWork();
                supplier.EnterpriseCode = enterpriseCode;
                supplier.SupplierCd = supplierCd;
                int ret = supplierDB.Read(ref supplier, 0, ref sqlConnection, ref sqlTransaction);

                if (ret == 0)
                {
                    int supplierTotalDay = 0;
                    supplierTotalDay = supplier.PaymentTotalDay;
                    totalDay = supplierTotalDay;
                }

                // ���s�����ꍇ�̓��b�N�̃L�[��ǉ����Ȃ�
                if (totalDay == 0)
                {
                    totalDay = 99;
                }
            }
            catch
            {
                totalDay = 99;
            }

            return totalDay;
        }
        /// <summary>
        /// ���t�ϊ�����
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate(DateTime dateTime)
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<

        // --------------- ADD START 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        /// <summary>
        /// �x���A��`�X�V����
        /// </summary>
        /// <param name="paymentDataWorkByte">�x����񃏁[�N</param>
        /// <param name="payDraftDataWorkByte">�x����`�f�[�^���[�N</param>
        /// <param name="payDraftDataDelWorkByte">�x����`�f�[�^���[�N(�폜�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����E�x���������E��`�f�[�^�����Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �x���ԍ������̎��A�V�K�x���E��`�f�[�^�쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : �x�������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Programmer : gejun</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int WriteWithPayDraft(ref byte[] paymentDataWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            bool commitFlg = true;

            string resName = string.Empty;

            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                PaymentDataWork paymentDataWork = new PaymentDataWork();
                if (paymentDataWorkByte != null)
                    paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentDataWork)) as PaymentDataWork;
                else
                    paymentDataWork = null;

                PayDraftDataWork payDraftDataWork = new PayDraftDataWork(); 
                if(payDraftDataWorkByte != null)
                    payDraftDataWork = XmlByteSerializer.Deserialize(payDraftDataWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataWork = null;
                
                PayDraftDataWork payDraftDataDelWork = new PayDraftDataWork();
                if (payDraftDataDelWorkByte != null)
                    payDraftDataDelWork = XmlByteSerializer.Deserialize(payDraftDataDelWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataDelWork = null;
                if (paymentDataWork == null)
                {
                    return status;
                }

                PaymentSlpWork paymentSlpWork = null;
                PaymentDtlWork[] paymentDtlWorkArray = null;
                PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

                //�V�X�e�����b�N(���_)
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(paymentSlpWork.EnterpriseCode, ShareCheckType.Section, paymentSlpWork.AddUpSecCode, "");
                if (paymentSlpWork != null && paymentSlpWork.AddUpADate != DateTime.MinValue)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    // �x���}�X�^�X�V����
                    status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                    // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    if (STATUS_CHK_SEND_ERR == status)
                    {
                        sqlTransaction.Rollback();
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            sqlConnection.Dispose();
                        }
                        return status;
                    }
                    // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // �x����`�f�[�^�X�V����
                if (payDraftDataWork != null)
                {
                    if (payDraftDataWork.PaymentRowNo != 0 && paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        // �x���`�[�ԍ�
                        payDraftDataWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
                        // �x���X�e�[�^�X
                        payDraftDataWork.SupplierFormal = paymentSlpWork.SupplierFormal;
                        // �x�����t
                        payDraftDataWork.PaymentDate = paymentSlpWork.PaymentDate;
                    }
                    
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.WritePayDraft(payDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // �x����`�f�[�^�폜����
                if (payDraftDataDelWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.DeletePayDraft(payDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }


                if (commitFlg)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();
      

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);

                        // XML�֕ϊ����A������̃o�C�i����
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤               
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }
        /// <summary>
        /// �x����`�f�[�^�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="payDraftDataWork">�x����`�f�[�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x����`�f�[�^�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private int WritePayDraft(PayDraftDataWork payDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlText = string.Empty;

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<


                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        DateTime comUpDateTime = payDraftDataWork.UpdateDateTime;

                        // �r���`�F�b�N
                        if (_updateDateTime != comUpDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            return status;
                        }
                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE PAYDRAFTDATARF " + Environment.NewLine;
                        sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYDRAFTNORF=@PAYDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , PAYMENTRF=@PAYMENT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , SUPPLIERCDRF=@SUPPLIERCD , SUPPLIERNM1RF=@SUPPLIERNM1 , SUPPLIERNM2RF=@SUPPLIERNM2 , SUPPLIERSNMRF=@SUPPLIERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , SUPPLIERFORMALRF=@SUPPLIERFORMAL , PAYMENTSLIPNORF=@PAYMENTSLIPNO , PAYMENTROWNORF=@PAYMENTROWNO , PAYMENTDATERF=@PAYMENTDATE " + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                        findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)payDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (payDraftDataWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //�@��ʂ̃f�[�^�Ainsert����
                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText = "INSERT INTO PAYDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @PAYMENT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @SUPPLIERFORMAL, @PAYMENTSLIPNO, @PAYMENTROWNO, @PAYMENTDATE)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)payDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (myReader.IsClosed == false) myReader.Close();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraPayDraftNo = sqlCommand.Parameters.Add("@PAYDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                    SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                    SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
                    SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(payDraftDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.LogicalDeleteCode);
                    paraPayDraftNo.Value = SqlDataMediator.SqlSetString(payDraftDataWork.PayDraftNo);
                    paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftKindCd);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftDivide);
                    paraPayment.Value = SqlDataMediator.SqlSetInt64(payDraftDataWork.Payment);
                    paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.BankAndBranchCd);
                    paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.BankAndBranchNm);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SectionCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.AddUpSecCode);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierSnm);
                    paraProcDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ProcDate);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ValidityTerm);
                    paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftStmntDate);
                    paraOutline1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline1);
                    paraOutline2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline2);
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierFormal);
                    paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentSlipNo);
                    paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentRowNo);
                    paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.PaymentDate);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDatatDB.Write" + status);
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
        /// �x����`�f�[�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="payDraftDataWork">�x����`�f�[�^�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private int DeletePayDraft(PayDraftDataWork payDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = payDraftDataWork.PayDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<


                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != payDraftDataWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    // �f�[�^�͑S�č폜
                    # region [DELETE��]
                    sqlText = string.Empty;
                    //sqlText += "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
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


                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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

        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// �x���A��`(�x���E���)�X�V����
        /// </summary>
        /// <param name="paymentDataWorkByte">�x����񃏁[�N</param>
        /// <param name="payDraftDataWorkByte">�x����`�f�[�^���[�N</param>
        /// <param name="payDraftDataDelWorkByte">�x����`�f�[�^���[�N(�폜�p)</param>
        /// <param name="rcvDraftDataWorkByte">����`�f�[�^���[�N</param>
        /// <param name="rcvDraftDataDelWorkByte">����`�f�[�^���[�N(�폜�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����E�x���������E��`�f�[�^�����Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �x���ԍ������̎��A�V�K�x���E��`�f�[�^�쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : �x�������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2012/10/18</br>
        /// </remarks>
        public int WriteWithDraft(ref byte[] paymentDataWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte
                                                                , byte[] rcvDraftDataWorkByte, byte[] rcvDraftDataDelWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            bool commitFlg = true;

            string resName = string.Empty;

            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                PaymentDataWork paymentDataWork = new PaymentDataWork();
                if (paymentDataWorkByte != null)
                    paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentDataWork)) as PaymentDataWork;
                else
                    paymentDataWork = null;

                PayDraftDataWork payDraftDataWork = new PayDraftDataWork();
                if (payDraftDataWorkByte != null)
                    payDraftDataWork = XmlByteSerializer.Deserialize(payDraftDataWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataWork = null;

                PayDraftDataWork payDraftDataDelWork = new PayDraftDataWork();
                if (payDraftDataDelWorkByte != null)
                    payDraftDataDelWork = XmlByteSerializer.Deserialize(payDraftDataDelWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataDelWork = null;

                RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
                if (rcvDraftDataWorkByte != null)
                    rcvDraftDataWork = XmlByteSerializer.Deserialize(rcvDraftDataWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataWork = null;

                RcvDraftDataWork rcvDraftDataDelWork = new RcvDraftDataWork();
                if (rcvDraftDataDelWorkByte != null)
                    rcvDraftDataDelWork = XmlByteSerializer.Deserialize(rcvDraftDataDelWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataDelWork = null;

                if (paymentDataWork == null)
                {
                    return status;
                }

                PaymentSlpWork paymentSlpWork = null;
                PaymentDtlWork[] paymentDtlWorkArray = null;
                PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

                //�V�X�e�����b�N(���_)
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(paymentSlpWork.EnterpriseCode, ShareCheckType.Section, paymentSlpWork.AddUpSecCode, "");
                if (paymentSlpWork != null && paymentSlpWork.AddUpADate != DateTime.MinValue)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    // �x���}�X�^�X�V����
                    status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                    // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    if (STATUS_CHK_SEND_ERR == status)
                    {
                        sqlTransaction.Rollback();
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            sqlConnection.Dispose();
                        }
                        return status;
                    }
                    // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // �x����`�f�[�^�X�V����
                if (payDraftDataWork != null)
                {
                    if (payDraftDataWork.PaymentRowNo != 0 && paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        // �x���`�[�ԍ�
                        payDraftDataWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
                        // �x���X�e�[�^�X
                        payDraftDataWork.SupplierFormal = paymentSlpWork.SupplierFormal;
                        // �x�����t
                        payDraftDataWork.PaymentDate = paymentSlpWork.PaymentDate;
                    }

                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.WritePayDraft(payDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // �x����`�f�[�^�폜����
                if (payDraftDataDelWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.DeletePayDraft(payDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }
                // ����`�f�[�^�X�V����
                if (rcvDraftDataWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.WriteRcvDraft(rcvDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // ����`�f�[�^�폜����
                if (rcvDraftDataDelWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.DeleteRcvDraft(rcvDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                if (commitFlg)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);

                        // XML�֕ϊ����A������̃o�C�i����
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤               
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }
        /// <summary>
        /// ����`�f�[�^�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="rcvDraftDataWork">����`�f�[�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2012/10/18</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private int WriteRcvDraft(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlText = string.Empty;

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        DateTime comUpDateTime = rcvDraftDataWork.UpdateDateTime;

                        // �r���`�F�b�N
                        if (_updateDateTime != comUpDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE RCVDRAFTDATARF " + Environment.NewLine;
                        sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , RCVDRAFTNORF=@RCVDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , DEPOSITRF=@DEPOSIT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , CUSTOMERSNMRF=@CUSTOMERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITROWNORF=@DEPOSITROWNO , DEPOSITDATERF=@DEPOSITDATE " + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123 
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                        findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (rcvDraftDataWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //�@��ʂ̃f�[�^�Ainsert����
                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText = "INSERT INTO RCVDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @RCVDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @DEPOSIT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @ACPTANODRSTATUS, @DEPOSITSLIPNO, @DEPOSITROWNO, @DEPOSITDATE)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (myReader.IsClosed == false) myReader.Close();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraRcvDraftNo = sqlCommand.Parameters.Add("@RCVDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                    SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                    SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rcvDraftDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.LogicalDeleteCode);
                    paraRcvDraftNo.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.RcvDraftNo);
                    paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftKindCd);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftDivide);
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(rcvDraftDataWork.Deposit);
                    paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.BankAndBranchCd);
                    paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.BankAndBranchNm);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.SectionCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.AddUpSecCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerSnm);
                    paraProcDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ProcDate);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ValidityTerm);
                    paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftStmntDate);
                    paraOutline1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline1);
                    paraOutline2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline2);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.AcptAnOdrStatus);
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositSlipNo);
                    paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositRowNo);
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DepositDate);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDatatDB.Write" + status);
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
        /// ����`�f�[�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="rcvDraftDataWork">����`�f�[�^�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2012/10/18</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private int DeleteRcvDraft(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<                

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != rcvDraftDataWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    // �f�[�^�͑S�č폜
                    # region [DELETE��]
                    sqlText = string.Empty;
                    //sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmime #34123
                    sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<< 
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


                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        // --------------- ADD END 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        /// <summary>
        /// �x���`�[�X�V�������C��
        /// </summary>
        /// <param name="paymentSlpWork">�x���`�[���</param>
        /// <param name="paymentDtlWorkArray">�x�����׏��̔z��</param>
        /// <param name="sqlConnection">DB�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int Write(ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [�p�����[�^�[�`�F�b�N]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (paymentSlpWork == null)
            {
                errmsg += "�x���`�[�f�[�^�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += ": DB�ڑ��I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += ": �g�����U�N�V�����I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            // ���b�N�p���\�[�X���̂��擾
            string resName = this.GetResourceName(paymentSlpWork.EnterpriseCode);
            status = this.Lock(resName, sqlConnection, sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                errmsg += ": ���b�N�Ɏ��s���܂���.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            try
            {
                status = this.WriteInitial(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WriteProc(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                this.Release(resName, sqlConnection, sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// �x���`�[�X�V��������
        /// </summary>
        /// <param name="paymentSlpWork">�x���`�[���</param>
        /// <param name="paymentDtlWorkArray">�x�����׏��̔z��</param>
        /// <param name="sqlConnection">DB�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int WriteInitial(ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [�p�����[�^�`�F�b�N]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (paymentSlpWork == null)
            {
                errmsg += ": �x���`�[�f�[�^�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += ": DB�ڑ��I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += ": �g�����U�N�V�����I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            # region [�x���`�[�f�[�^ ������������]
            // �x���`�[�ԍ��̍̔�
            if (paymentSlpWork.PaymentSlipNo == 0)
            {
                // �x���`�[�ԍ��̍̔�
                int paymentSlipNo = 0;
                status = this.CreatePaymentSlipNoProc(paymentSlpWork.EnterpriseCode, paymentSlpWork.UpdateSecCd, out paymentSlipNo, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paymentSlpWork.PaymentSlipNo = paymentSlipNo;
                }
                else
                {
                    // �x���`�[�ԍ��̍̔ԂɎ��s�����ꍇ�͏������I��
                    return status;
                }
            }
            # endregion

            # region [�x�����׃f�[�^ ������������]
            if (paymentDtlWorkArray != null && paymentDtlWorkArray.Length > 0)
            {
                foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                {
                    paymentDtlWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;  // ��ƃR�[�h 
                    paymentDtlWork.SupplierFormal = paymentSlpWork.SupplierFormal;  // �d���`��
                    paymentDtlWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;    // �x���`�[�ԍ�
                }
            }
            # endregion

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        /// <summary>
        /// �x���`�[�X�V��������
        /// </summary>
        /// <param name="paymentSlpWork">�x���`�[���</param>
        /// <param name="paymentDtlWorkArray">�x�����׏��̔z��</param>
        /// <param name="sqlConnection">DB�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (paymentSlpWork != null)
            {
                // �x���f�[�^�o�^�E�X�V
                status = this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �x�����׃f�[�^�o�^�E�X�V
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WritePaymentDtlWorkRec(paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                }
            }

            return status;
        }

        /// <summary>
        /// �x���}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="paymentSlpWork">�x���}�X�^���</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x�������X�V���܂�</br>
        /// <br>Programmer : 95089 ��{�@�E</br>
        /// <br>Date       : 2005.08.04</br>
        /// 
        //private int WritePaymentSlpWorkRec(bool mode_new, ref PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/22 M.Kubota
        private int WritePaymentSlpWorkRec(ref PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/22 M.Kubota
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //DEL 2008/04/22 M.Kubota
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;        //ADD 2008/04/22 M.Kubota

            SqlDataReader myReader = null;
            //string updateText; //DEL 2008/04/22 M.Kubota

            // �X�V���t���擾
            DateTime Upd_UpdateDateTime = paymentSlpWork.UpdateDateTime;

            bool deleteSql = false;  //ADD 2008/04/22 M.Kubota

            //Select�R�}���h�̐���
            try
            {
                # region --- DEL 2008/04/22 M.Kubota ---
# if false
                if (mode_new == true)
                {
                    // �� 2007.11.02 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                    //// �� 20061222 18322 c �g��.NS�̃��C�A�E�g�ɂ��킹�ύX
                    ////updateText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYMENTSLIPNORF, CUSTOMERCODERF, PAYMENTRF, DISCOUNTPAYMENTRF, FEEPAYMENTRF, OUTLINERF, PAYMENTINPSECTIONCDRF, PAYMENTDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, PAYMENTMONEYKINDCODERF, PAYMENTMONEYKINDDIVRF, PAYMENTMONEYKINDNAMERF, PAYMENTDIVNMRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF ,PAYMENTTOTALRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYMENTSLIPNO, @CUSTOMERCODE, @PAYMENT, @DISCOUNTPAYMENT, @FEEPAYMENT, @OUTLINE, @PAYMENTINPSECTIONCD, @PAYMENTDATE, @ADDUPSECCODE, @ADDUPADATE, @UPDATESECCD, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @PAYMENTMONEYKINDCODE, @PAYMENTMONEYKINDDIV, @PAYMENTMONEYKINDNAME, @PAYMENTDIVNM, @CREDITORLOANCD, @CREDITCOMPANYCODE , @PAYMENTTOTAL)";
                    //
                    //#region �x���`�[�}�X�^INSERT��
                    //updateText = "INSERT INTO PAYMENTSLPRF ("
                    //           + "  CREATEDATETIMERF"
                    //           + ", UPDATEDATETIMERF"
                    //           + ", ENTERPRISECODERF"
                    //           + ", FILEHEADERGUIDRF"
                    //           + ", UPDEMPLOYEECODERF"
                    //           + ", UPDASSEMBLYID1RF"
                    //           + ", UPDASSEMBLYID2RF"
                    //           + ", LOGICALDELETECODERF"
                    //           + ", DEBITNOTEDIVRF"
                    //           + ", PAYMENTSLIPNORF"
                    //           + ", CUSTOMERCODERF"
                    //           + ", CUSTOMERNAMERF"
                    //           + ", CUSTOMERNAME2RF"
                    //           + ", PAYMENTINPSECTIONCDRF"
                    //           + ", ADDUPSECCODERF"
                    //           + ", UPDATESECCDRF"
                    //           + ", PAYMENTDATERF"
                    //           + ", ADDUPADATERF"
                    //           + ", PAYMENTMONEYKINDCODERF"
                    //           + ", PAYMENTMONEYKINDNAMERF"
                    //           + ", PAYMENTMONEYKINDDIVRF"
                    //           + ", PAYMENTTOTALRF"
                    //           + ", PAYMENTRF"
                    //           + ", FEEPAYMENTRF"
                    //           + ", DISCOUNTPAYMENTRF"
                    //           + ", REBATEPAYMENTRF"
                    //           + ", AUTOPAYMENTRF"
                    //           + ", CREDITORLOANCDRF"
                    //           + ", CREDITCOMPANYCODERF"
                    //           + ", DRAFTDRAWINGDATERF"
                    //           + ", DRAFTPAYTIMELIMITRF"
                    //           + ", DEBITNOTELINKPAYNORF"
                    //           + ", PAYMENTAGENTCODERF"
                    //           // �� 20070907 980081 c
                    //           //+ ", PAYMENTAGENTNMRF"
                    //           + ", PAYMENTAGENTNAMERF"
                    //           // �� 20070907 980081 c
                    //           + ", OUTLINERF"
                    //           // �� 20070907 980081 a
                    //           + ", CUSTCLAIMCODERF"
                    //           + ", SUBSECTIONCODERF"
                    //           + ", MINSECTIONCODERF"
                    //           + ", DRAFTKINDRF"
                    //           + ", DRAFTKINDNAMERF"
                    //           + ", DRAFTDIVIDERF"
                    //           + ", DRAFTDIVIDENAMERF"
                    //           + ", DRAFTNORF"
                    //           + ", PAYMENTINPUTAGENTCDRF"
                    //           + ", PAYMENTINPUTAGENTNMRF"
                    //           + ", BANKCODERF"
                    //           + ", BANKNAMERF"
                    //           + ", EDISENDDATERF"
                    //           + ", EDITAKEINDATERF"
                    //           + ", TEXTEXTRADATERF"
                    //           // �� 20070907 980081 a
                    //           + ") VALUES ("
                    //           + "  @CREATEDATETIME"
                    //           + ", @UPDATEDATETIME"
                    //           + ", @ENTERPRISECODE"
                    //           + ", @FILEHEADERGUID"
                    //           + ", @UPDEMPLOYEECODE"
                    //           + ", @UPDASSEMBLYID1"
                    //           + ", @UPDASSEMBLYID2"
                    //           + ", @LOGICALDELETECODE"
                    //           + ", @DEBITNOTEDIV"
                    //           + ", @PAYMENTSLIPNO"
                    //           + ", @CUSTOMERCODE"
                    //           + ", @CUSTOMERNAME"
                    //           + ", @CUSTOMERNAME2"
                    //           + ", @PAYMENTINPSECTIONCD"
                    //           + ", @ADDUPSECCODE"
                    //           + ", @UPDATESECCD"
                    //           + ", @PAYMENTDATE"
                    //           + ", @ADDUPADATE"
                    //           + ", @PAYMENTMONEYKINDCODE"
                    //           + ", @PAYMENTMONEYKINDNAME"
                    //           + ", @PAYMENTMONEYKINDDIV"
                    //           + ", @PAYMENTTOTAL"
                    //           + ", @PAYMENT"
                    //           + ", @FEEPAYMENT"
                    //           + ", @DISCOUNTPAYMENT"
                    //           + ", @REBATEPAYMENT"
                    //           + ", @AUTOPAYMENT"
                    //           + ", @CREDITORLOANCD"
                    //           + ", @CREDITCOMPANYCODE"
                    //           + ", @DRAFTDRAWINGDATE"
                    //           + ", @DRAFTPAYTIMELIMIT"
                    //           + ", @DEBITNOTELINKPAYNO"
                    //           + ", @PAYMENTAGENTCODE"
                    //           // �� 20070907 980081 c
                    //           //+ ", @PAYMENTAGENTNM"
                    //           + ", @PAYMENTAGENTNAME"
                    //           // �� 20070907 980081 c
                    //           + ", @OUTLINE"
                    //           // �� 20070907 980081 a
                    //           + ", @CUSTCLAIMCODE"
                    //           + ", @SUBSECTIONCODE"
                    //           + ", @MINSECTIONCODE"
                    //           + ", @DRAFTKIND"
                    //           + ", @DRAFTKINDNAME"
                    //           + ", @DRAFTDIVIDE"
                    //           + ", @DRAFTDIVIDENAME"
                    //           + ", @DRAFTNO"
                    //           + ", @PAYMENTINPUTAGENTCD"
                    //           + ", @PAYMENTINPUTAGENTNM"
                    //           + ", @BANKCODE"
                    //           + ", @BANKNAME"
                    //           + ", @EDISENDDATE"
                    //           + ", @EDITAKEINDATE"
                    //           + ", @TEXTEXTRADATE"
                    //           // �� 20070907 980081 a
                    //           + ")"
                    //           ;
                    //#endregion
                    // �� 20061222 18322 c
                    #endregion
                    updateText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, MINSECTIONCODERF, PAYMENTDATERF, ADDUPADATERF, PAYMENTMONEYKINDCODERF, PAYMENTMONEYKINDNAMERF, PAYMENTMONEYKINDDIVRF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, REBATEPAYMENTRF, AUTOPAYMENTRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF, EDISENDDATERF, EDITAKEINDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEBITNOTEDIV, @PAYMENTSLIPNO, @SUPPLIERSLIPNO, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @PAYMENTINPSECTIONCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @MINSECTIONCODE, @PAYMENTDATE, @ADDUPADATE, @PAYMENTMONEYKINDCODE, @PAYMENTMONEYKINDNAME, @PAYMENTMONEYKINDDIV, @PAYMENTTOTAL, @PAYMENT, @FEEPAYMENT, @DISCOUNTPAYMENT, @REBATEPAYMENT, @AUTOPAYMENT, @CREDITORLOANCD, @CREDITCOMPANYCODE, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEBITNOTELINKPAYNO, @PAYMENTAGENTCODE, @PAYMENTAGENTNAME, @PAYMENTINPUTAGENTCD, @PAYMENTINPUTAGENTNM, @OUTLINE, @BANKCODE, @BANKNAME, @EDISENDDATE, @EDITAKEINDATE)";
                    // �� 2007.11.02 980081 c

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)paymentSlpWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                else
                {
                    if (paymentSlpWork.LogicalDeleteCode == 0)		// �_���폜�敪�������Ă��Ȃ��ꍇ�͒ʏ�X�V���s
                    {
                        // �� 2007.11.02 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                        //// �� 20061222 18322 c �g��.NS�̃��C�A�E�g�ɂ��킹�ύX
                        ////// �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                        ////updateText = "UPDATE PAYMENTSLPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYMENTSLIPNORF=@PAYMENTSLIPNO , CUSTOMERCODERF=@CUSTOMERCODE , PAYMENTRF=@PAYMENT , DISCOUNTPAYMENTRF=@DISCOUNTPAYMENT , FEEPAYMENTRF=@FEEPAYMENT , OUTLINERF=@OUTLINE , PAYMENTINPSECTIONCDRF=@PAYMENTINPSECTIONCD , PAYMENTDATERF=@PAYMENTDATE , ADDUPSECCODERF=@ADDUPSECCODE , ADDUPADATERF=@ADDUPADATE , UPDATESECCDRF=@UPDATESECCD , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , PAYMENTMONEYKINDCODERF=@PAYMENTMONEYKINDCODE , PAYMENTMONEYKINDDIVRF=@PAYMENTMONEYKINDDIV , PAYMENTMONEYKINDNAMERF=@PAYMENTMONEYKINDNAME , PAYMENTDIVNMRF=@PAYMENTDIVNM , CREDITORLOANCDRF=@CREDITORLOANCD , CREDITCOMPANYCODERF=@CREDITCOMPANYCODE , PAYMENTTOTALRF=@PAYMENTTOTAL WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO ";
                        //
                        //#region �x���`�[�}�X�^UPDATE�� �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                        //// �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                        //updateText = "UPDATE PAYMENTSLPRF"
                        //           + " SET CREATEDATETIMERF=@CREATEDATETIME"
                        //           + ", UPDATEDATETIMERF=@UPDATEDATETIME"
                        //           + ", ENTERPRISECODERF=@ENTERPRISECODE"
                        //           + ", FILEHEADERGUIDRF=@FILEHEADERGUID"
                        //           + ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                        //           + ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                        //           + ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                        //           + ", LOGICALDELETECODERF=@LOGICALDELETECODE"
                        //
                        //           + ", DEBITNOTEDIVRF=@DEBITNOTEDIV"
                        //           + ", PAYMENTSLIPNORF=@PAYMENTSLIPNO"
                        //           + ", CUSTOMERCODERF=@CUSTOMERCODE"
                        //           + ", CUSTOMERNAMERF=@CUSTOMERNAME"
                        //           + ", CUSTOMERNAME2RF=@CUSTOMERNAME2"
                        //           + ", PAYMENTINPSECTIONCDRF=@PAYMENTINPSECTIONCD"
                        //           + ", ADDUPSECCODERF=@ADDUPSECCODE"
                        //           + ", UPDATESECCDRF=@UPDATESECCD"
                        //           + ", PAYMENTDATERF=@PAYMENTDATE"
                        //           + ", ADDUPADATERF=@ADDUPADATE"
                        //           + ", PAYMENTMONEYKINDCODERF=@PAYMENTMONEYKINDCODE"
                        //           + ", PAYMENTMONEYKINDNAMERF=@PAYMENTMONEYKINDNAME"
                        //           + ", PAYMENTMONEYKINDDIVRF=@PAYMENTMONEYKINDDIV"
                        //           + ", PAYMENTTOTALRF=@PAYMENTTOTAL"
                        //           + ", PAYMENTRF=@PAYMENT"
                        //           + ", FEEPAYMENTRF=@FEEPAYMENT"
                        //           + ", DISCOUNTPAYMENTRF=@DISCOUNTPAYMENT"
                        //           + ", REBATEPAYMENTRF=@REBATEPAYMENT"
                        //           + ", AUTOPAYMENTRF=@AUTOPAYMENT"
                        //           + ", CREDITORLOANCDRF=@CREDITORLOANCD"
                        //           + ", CREDITCOMPANYCODERF=@CREDITCOMPANYCODE"
                        //           + ", DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE"
                        //           + ", DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT"
                        //           + ", DEBITNOTELINKPAYNORF=@DEBITNOTELINKPAYNO"
                        //           + ", PAYMENTAGENTCODERF=@PAYMENTAGENTCODE"
                        //           // �� 20070907 980081 c
                        //           //+ ", PAYMENTAGENTNMRF=@PAYMENTAGENTNM"
                        //           + ", PAYMENTAGENTNAMERF=@PAYMENTAGENTNAME"
                        //           // �� 20070907 980081 c
                        //           + ", OUTLINERF=@OUTLINE"
                        //           // �� 20070907 980081 a
                        //           + ", CUSTCLAIMCODERF=@CUSTCLAIMCODE"
                        //           + ", SUBSECTIONCODERF=@SUBSECTIONCODE"
                        //           + ", MINSECTIONCODERF=@MINSECTIONCODE"
                        //           + ", DRAFTKINDRF=@DRAFTKIND"
                        //           + ", DRAFTKINDNAMERF=@DRAFTKINDNAME"
                        //           + ", DRAFTDIVIDERF=@DRAFTDIVIDE"
                        //           + ", DRAFTDIVIDENAMERF=@DRAFTDIVIDENAME"
                        //           + ", DRAFTNORF=@DRAFTNO"
                        //           + ", PAYMENTINPUTAGENTCDRF=@PAYMENTINPUTAGENTCD"
                        //           + ", PAYMENTINPUTAGENTNMRF=@PAYMENTINPUTAGENTNM"
                        //           + ", BANKCODERF=@BANKCODE"
                        //           + ", BANKNAMERF=@BANKNAME"
                        //           + ", EDISENDDATERF=@EDISENDDATE"
                        //           + ", EDITAKEINDATERF=@EDITAKEINDATE"
                        //           + ", TEXTEXTRADATERF=@TEXTEXTRADATE"
                        //           // �� 20070907 980081 a
                        //           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                        //           + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                        //           + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO "
                        //           ;
                        //#endregion
                        //// �� 20061222 18322 c
                        #endregion
                        //�X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                        updateText = "UPDATE PAYMENTSLPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DEBITNOTEDIVRF=@DEBITNOTEDIV , PAYMENTSLIPNORF=@PAYMENTSLIPNO , SUPPLIERSLIPNORF=@SUPPLIERSLIPNO , SUPPLIERCDRF = @SUPPLIERCD, SUPPLIERNM1RF = @SUPPLIERNM1, SUPPLIERNM2RF = @SUPPLIERNM2, SUPPLIERSNMRF = @SUPPLIERSNM , PAYEECODERF=@PAYEECODE , PAYEENAMERF=@PAYEENAME , PAYEENAME2RF=@PAYEENAME2 , PAYEESNMRF=@PAYEESNM , PAYMENTINPSECTIONCDRF=@PAYMENTINPSECTIONCD , ADDUPSECCODERF=@ADDUPSECCODE , UPDATESECCDRF=@UPDATESECCD , SUBSECTIONCODERF=@SUBSECTIONCODE , MINSECTIONCODERF=@MINSECTIONCODE , PAYMENTDATERF=@PAYMENTDATE , ADDUPADATERF=@ADDUPADATE , PAYMENTMONEYKINDCODERF=@PAYMENTMONEYKINDCODE , PAYMENTMONEYKINDNAMERF=@PAYMENTMONEYKINDNAME , PAYMENTMONEYKINDDIVRF=@PAYMENTMONEYKINDDIV , PAYMENTTOTALRF=@PAYMENTTOTAL , PAYMENTRF=@PAYMENT , FEEPAYMENTRF=@FEEPAYMENT , DISCOUNTPAYMENTRF=@DISCOUNTPAYMENT , REBATEPAYMENTRF=@REBATEPAYMENT , AUTOPAYMENTRF=@AUTOPAYMENT , CREDITORLOANCDRF=@CREDITORLOANCD , CREDITCOMPANYCODERF=@CREDITCOMPANYCODE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , DRAFTKINDRF=@DRAFTKIND , DRAFTKINDNAMERF=@DRAFTKINDNAME , DRAFTDIVIDERF=@DRAFTDIVIDE , DRAFTDIVIDENAMERF=@DRAFTDIVIDENAME , DRAFTNORF=@DRAFTNO , DEBITNOTELINKPAYNORF=@DEBITNOTELINKPAYNO , PAYMENTAGENTCODERF=@PAYMENTAGENTCODE , PAYMENTAGENTNAMERF=@PAYMENTAGENTNAME , PAYMENTINPUTAGENTCDRF=@PAYMENTINPUTAGENTCD , PAYMENTINPUTAGENTNMRF=@PAYMENTINPUTAGENTNM , OUTLINERF=@OUTLINE , BANKCODERF=@BANKCODE , BANKNAMERF=@BANKNAME , EDISENDDATERF=@EDISENDDATE , EDITAKEINDATERF=@EDITAKEINDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO AND UPDATEDATETIMERF=@FINDUPDATEDATETIME";
                        // �� 2007.11.02 980081 c

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentSlpWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                    }
                    else											// �_���폜�敪�������Ă���ꍇ�͍폜�������s
                    {

                        // �� 20061222 18322 c �g��.NS�̃��C�A�E�g�ɂ��킹�ύX
                        //// �X�V�����X�V�����L�[�ɕt�����č폜�i���t�r�������j
                        //updateText = "DELETE FROM PAYMENTSLPRF WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO";

                        // �X�V�����X�V�����L�[�ɕt�����č폜�i���t�r�������j
                        updateText = "DELETE FROM PAYMENTSLPRF"
                                   + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                                   + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                                   + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"
                                   ;
                        // �� 20061222 18322 c

                    }

                }

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {
                    // �� 2008.01.17 980081 a
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                    // �� 2008.01.17 a
                    // �� 2007.11.02 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                    ////Prameter�I�u�W�F�N�g�̍쐬
                    //SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                    ////Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //findParaUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.EnterpriseCode);
                    //findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentSlipNo);
                    //
                    //#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    ////Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    //
                    //SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    //SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    //SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    //SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    //
                    //// �� 20061222 18322 c �g��.NS�p�ɕύX
                    ////SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    ////SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    ////SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    ////SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    ////SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    ////SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    ////SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    ////SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    ////SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    ////SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    ////SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    ////SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    ////SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    ////SqlParameter paraPaymentMoneyKindCode = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDCODE", SqlDbType.Int);
                    ////SqlParameter paraPaymentMoneyKindDiv = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDDIV", SqlDbType.Int);
                    ////SqlParameter paraPaymentMoneyKindName = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDNAME", SqlDbType.NVarChar);
                    //////SqlParameter paraPaymentDivNm = sqlCommand.Parameters.Add("@PAYMENTDIVNM", SqlDbType.NVarChar);
                    ////SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    ////SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    ////SqlParameter paraPaymenttotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    ////SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    //
                    //SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    //SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    //SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    //SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    //SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    //SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    //SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    //SqlParameter paraPaymentMoneyKindCode = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDCODE", SqlDbType.Int);
                    //SqlParameter paraPaymentMoneyKindName = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDNAME", SqlDbType.NVarChar);
                    //SqlParameter paraPaymentMoneyKindDiv = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDDIV", SqlDbType.Int);
                    //SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    //SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraRebatePayment = sqlCommand.Parameters.Add("@REBATEPAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    //SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    //SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    //SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    //SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    //SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                    //SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    //// �� 20070907 980081 c
                    ////SqlParameter paraPaymentAgentNm = sqlCommand.Parameters.Add("@PAYMENTAGENTNM", SqlDbType.NVarChar);
                    //SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                    //// �� 20070907 980081 c
                    //SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    //// �� 20061222 18322 c
                    //// �� 20070907 980081 a
                    //SqlParameter paraCustClaimCode = sqlCommand.Parameters.Add("@CUSTCLAIMCODE", SqlDbType.Int);
                    //SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    //SqlParameter paraMinSectionCode = sqlCommand.Parameters.Add("@MINSECTIONCODE", SqlDbType.Int);
                    //SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    //SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    //SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    //SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    //SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    //SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                    //SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                    //SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    //SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    //SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    //SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    //SqlParameter paraTextExtraDate = sqlCommand.Parameters.Add("@TEXTEXTRADATE", SqlDbType.Int);
                    //// �� 20070907 980081 a
                #endregion
                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                    SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraMinSectionCode = sqlCommand.Parameters.Add("@MINSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraPaymentMoneyKindCode = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDCODE", SqlDbType.Int);
                    SqlParameter paraPaymentMoneyKindName = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDNAME", SqlDbType.NVarChar);
                    SqlParameter paraPaymentMoneyKindDiv = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDDIV", SqlDbType.Int);
                    SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraRebatePayment = sqlCommand.Parameters.Add("@REBATEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                    SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    // �� 2007.11.02 980081 c
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    // �� 2007.11.02 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                    //paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDataWork.CreateDateTime);
                    //paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDataWork.UpdateDateTime);
                    //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.EnterpriseCode);
                    //paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentDataWork.FileHeaderGuid);
                    //paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdEmployeeCode);
                    //paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdAssemblyId1);
                    //paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdAssemblyId2);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.LogicalDeleteCode);
                    //
                    //// �� 20061222 18322 c �g��.NS�p�ɕύX
                    ////paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentSlipNo);
                    ////paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.SupplierCd);
                    ////paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.Payment);
                    ////paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.DiscountPayment);
                    ////paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.FeePayment);
                    ////paraOutline.Value = SqlDataMediator.SqlSetString(paymentDataWork.Outline);
                    ////paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInpSectionCd);
                    ////paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.PaymentDate);
                    ////paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.AddUpSecCode);
                    ////paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.AddUpADate);
                    ////paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdateSecCd);
                    ////paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftDrawingDate);
                    ////paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftPayTimeLimit);
                    ////paraPaymentMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindCode);
                    ////paraPaymentMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindDiv);
                    ////paraPaymentMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentMoneyKindName);
                    //////paraPaymentDivNm.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentDivNm);
                    ////paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.CreditOrLoanCd);
                    ////paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.CreditCompanyCode);
                    ////paraPaymenttotal.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.PaymentTotal);
                    //
                    //paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DebitNoteDiv);
                    //paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentSlipNo);
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.SupplierCd);
                    //paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentDataWork.SupplierNm1);
                    //paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentDataWork.SupplierNm2);
                    //paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInpSectionCd);
                    //paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.AddUpSecCode);
                    //paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdateSecCd);
                    //paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.PaymentDate);
                    //paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.AddUpADate);
                    //paraPaymentMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindCode);
                    //paraPaymentMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentMoneyKindName);
                    //paraPaymentMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindDiv);
                    //paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.PaymentTotal);
                    //paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.Payment);
                    //paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.FeePayment);
                    //paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.DiscountPayment);
                    //paraRebatePayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.RebatePayment);
                    //paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.AutoPayment);
                    //paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.CreditOrLoanCd);
                    //paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.CreditCompanyCode);
                    //paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftDrawingDate);
                    //paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftPayTimeLimit);
                    //paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DebitNoteLinkPayNo);
                    //paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentAgentCode);
                    //// �� 20070907 980081 c
                    ////paraPaymentAgentNm.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentAgentNm);
                    //paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentAgentName);
                    //// �� 20070907 980081 c
                    //paraOutline.Value = SqlDataMediator.SqlSetString(paymentDataWork.Outline);
                    //// �� 20061222 18322 c
                    //// �� 20070907 980081 a
                    //paraCustClaimCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.CustClaimCode);
                    //paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.SubSectionCode);
                    //paraMinSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.MinSectionCode);
                    //paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DraftKind);
                    //paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentDataWork.DraftKindName);
                    //paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DraftDivide);
                    //paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentDataWork.DraftDivideName);
                    //paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentDataWork.DraftNo);
                    //paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInputAgentCd);
                    //paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInputAgentNm);
                    //paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.BankCode);
                    //paraBankName.Value = SqlDataMediator.SqlSetString(paymentDataWork.BankName);
                    //paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.EdiSendDate);
                    //paraEdiTakeInDate.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.EdiTakeInDate);
                    //paraTextExtraDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.TextExtraDate);
                    //// �� 20070907 980081 a
                #endregion
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteDiv);
                    paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierSlipNo);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierSnm);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PayeeCode);
                    paraPayeeName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName);
                    paraPayeeName2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName2);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeSnm);
                    paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInpSectionCd);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.AddUpSecCode);
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdateSecCd);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SubSectionCode);
                    paraMinSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.MinSectionCode);
                    // �� 2008.03.14 980081 c
                    //paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.PaymentDate);
                    paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                    // �� 2008.03.14 980081 c
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.AddUpADate);
                    paraPaymentMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentMoneyKindCode);
                    paraPaymentMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentMoneyKindName);
                    paraPaymentMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentMoneyKindDiv);
                    paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.PaymentTotal);
                    paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.Payment);
                    paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.FeePayment);
                    paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.DiscountPayment);
                    paraRebatePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.RebatePayment);
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.AutoPayment);
                    paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.CreditOrLoanCd);
                    paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.CreditCompanyCode);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftDrawingDate);
                    paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftPayTimeLimit);
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftKind);
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftKindName);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftDivide);
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftDivideName);
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftNo);
                    paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                    paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentCode);
                    paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentName);
                    paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentCd);
                    paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentNm);
                    paraOutline.Value = SqlDataMediator.SqlSetString(paymentSlpWork.Outline);
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.BankCode);
                    paraBankName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.BankName);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.EdiSendDate);
                    // �� 2007.12.10 980081 c
                    //paraEdiTakeInDate.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.EdiTakeInDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.EdiTakeInDate);
                    // �� 2007.12.10 980081 c
                    // �� 2007.11.02 980081 c
                #endregion

                    int count = sqlCommand.ExecuteNonQuery();

                    // �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
# endif
                # endregion

                //--- ADD 2008/04/22 M.Kubota --->>>
                # region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  PAY.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PAY.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS PAY" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  PAY.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND PAY.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                    if (_updateDateTime != paymentSlpWork.UpdateDateTime)
                    {
                        if (paymentSlpWork.UpdateDateTime == DateTime.MinValue)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        }
                        else
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        }

                        return status;
                    }
                    // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    // �x���f�[�^���X�V����O�ɁA���M�ς݂̃`�F�b�N���s��
                    if (!CheckPaymentSlpSending(paymentSlpWork))
                    {
                        // �`�F�b�NNG
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                                myReader.Close();
                            myReader.Dispose();
                        }
                        return STATUS_CHK_SEND_ERR;
                    }
                    // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                    //if (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1)  // DEL 2009/04/28
                    if (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData3)  // ADD 2009/04/28
                    {
                        // �_���폜�敪�� 3 �̏ꍇ�͍폜�������s��
                        # region [DELETE��]
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PAYMENTSLPRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                        # endregion

                        deleteSql = true;
                    }
                    else
                    {
                        // �_���폜�敪�� 0 �̏ꍇ�͍X�V�������s��
                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE PAYMENTSLPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEDIVRF = @DEBITNOTEDIV" + Environment.NewLine;
                        sqlText += " ,PAYMENTSLIPNORF = @PAYMENTSLIPNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERFORMALRF = @SUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNORF = @SUPPLIERSLIPNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM1RF = @SUPPLIERNM1" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM2RF = @SUPPLIERNM2" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSNMRF = @SUPPLIERSNM" + Environment.NewLine;
                        sqlText += " ,PAYEECODERF = @PAYEECODE" + Environment.NewLine;
                        sqlText += " ,PAYEENAMERF = @PAYEENAME" + Environment.NewLine;
                        sqlText += " ,PAYEENAME2RF = @PAYEENAME2" + Environment.NewLine;
                        sqlText += " ,PAYEESNMRF = @PAYEESNM" + Environment.NewLine;
                        sqlText += " ,PAYMENTINPSECTIONCDRF = @PAYMENTINPSECTIONCD" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,UPDATESECCDRF = @UPDATESECCD" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,INPUTDAYRF = @INPUTDAY" + Environment.NewLine;         // ADD 2009/03/25
                        sqlText += " ,PAYMENTDATERF = @PAYMENTDATE" + Environment.NewLine;  
                        sqlText += " ,ADDUPADATERF = @ADDUPADATE" + Environment.NewLine;
                        sqlText += " ,PAYMENTTOTALRF = @PAYMENTTOTAL" + Environment.NewLine;
                        sqlText += " ,PAYMENTRF = @PAYMENT" + Environment.NewLine;
                        sqlText += " ,FEEPAYMENTRF = @FEEPAYMENT" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPAYMENTRF = @DISCOUNTPAYMENT" + Environment.NewLine;
                        sqlText += " ,AUTOPAYMENTRF = @AUTOPAYMENT" + Environment.NewLine;
                        sqlText += " ,DRAFTDRAWINGDATERF = @DRAFTDRAWINGDATE" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDRF = @DRAFTKIND" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDNAMERF = @DRAFTKINDNAME" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDERF = @DRAFTDIVIDE" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDENAMERF = @DRAFTDIVIDENAME" + Environment.NewLine;
                        sqlText += " ,DRAFTNORF = @DRAFTNO" + Environment.NewLine;
                        sqlText += " ,DEBITNOTELINKPAYNORF = @DEBITNOTELINKPAYNO" + Environment.NewLine;
                        sqlText += " ,PAYMENTAGENTCODERF = @PAYMENTAGENTCODE" + Environment.NewLine;
                        sqlText += " ,PAYMENTAGENTNAMERF = @PAYMENTAGENTNAME" + Environment.NewLine;
                        sqlText += " ,PAYMENTINPUTAGENTCDRF = @PAYMENTINPUTAGENTCD" + Environment.NewLine;
                        sqlText += " ,PAYMENTINPUTAGENTNMRF = @PAYMENTINPUTAGENTNM" + Environment.NewLine;
                        sqlText += " ,OUTLINERF = @OUTLINE" + Environment.NewLine;
                        sqlText += " ,BANKCODERF = @BANKCODE" + Environment.NewLine;
                        sqlText += " ,BANKNAMERF = @BANKNAME" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                        # endregion

                        //�X�V�w�b�_����ݒ�
                        int logicalDeleteCode = paymentSlpWork.LogicalDeleteCode; // 2009/04/28

                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentSlpWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        paymentSlpWork.LogicalDeleteCode = logicalDeleteCode; // 2009/04/28
                    }

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (paymentSlpWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTSLPRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,PAYEECODERF" + Environment.NewLine;
                    sqlText += " ,PAYEENAMERF" + Environment.NewLine;
                    sqlText += " ,PAYEENAME2RF" + Environment.NewLine;
                    sqlText += " ,PAYEESNMRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,UPDATESECCDRF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;    //ADD 2009/03/25
                    sqlText += " ,PAYMENTDATERF" + Environment.NewLine;
                    sqlText += " ,ADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,PAYMENTTOTALRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTRF" + Environment.NewLine;
                    sqlText += " ,FEEPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,DISCOUNTPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,AUTOPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,DRAFTDRAWINGDATERF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDRF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDENAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTNORF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTELINKPAYNORF" + Environment.NewLine;
                    sqlText += " ,PAYMENTAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,PAYMENTAGENTNAMERF" + Environment.NewLine;
                    sqlText += " ,PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                    sqlText += " ,OUTLINERF" + Environment.NewLine;
                    sqlText += " ,BANKCODERF" + Environment.NewLine;
                    sqlText += " ,BANKNAMERF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                    sqlText += " ,@PAYMENTSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM1" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM2" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@PAYEECODE" + Environment.NewLine;
                    sqlText += " ,@PAYEENAME" + Environment.NewLine;
                    sqlText += " ,@PAYEENAME2" + Environment.NewLine;
                    sqlText += " ,@PAYEESNM" + Environment.NewLine;
                    sqlText += " ,@PAYMENTINPSECTIONCD" + Environment.NewLine;
                    sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += " ,@UPDATESECCD" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@INPUTDAY" + Environment.NewLine;     //ADD 2009/03/25
                    sqlText += " ,@PAYMENTDATE" + Environment.NewLine;
                    sqlText += " ,@ADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@PAYMENTTOTAL" + Environment.NewLine;
                    sqlText += " ,@PAYMENT" + Environment.NewLine;
                    sqlText += " ,@FEEPAYMENT" + Environment.NewLine;
                    sqlText += " ,@DISCOUNTPAYMENT" + Environment.NewLine;
                    sqlText += " ,@AUTOPAYMENT" + Environment.NewLine;
                    sqlText += " ,@DRAFTDRAWINGDATE" + Environment.NewLine;
                    sqlText += " ,@DRAFTKIND" + Environment.NewLine;
                    sqlText += " ,@DRAFTKINDNAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDE" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDENAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTNO" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTELINKPAYNO" + Environment.NewLine;
                    sqlText += " ,@PAYMENTAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@PAYMENTAGENTNAME" + Environment.NewLine;
                    sqlText += " ,@PAYMENTINPUTAGENTCD" + Environment.NewLine;
                    sqlText += " ,@PAYMENTINPUTAGENTNM" + Environment.NewLine;
                    sqlText += " ,@OUTLINE" + Environment.NewLine;
                    sqlText += " ,@BANKCODE" + Environment.NewLine;
                    sqlText += " ,@BANKNAME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    # endregion

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)paymentSlpWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                sqlCommand.CommandText = sqlText;

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (!deleteSql)  // �ǉ��E�X�V�̍ۂɂ̂݃p�����[�^��ݒ肷��
                {
                    # region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                    SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);      //ADD 2009/03/25
                    SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                    SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteDiv);
                    paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierSlipNo);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierSnm);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PayeeCode);
                    paraPayeeName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName);
                    paraPayeeName2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName2);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeSnm);
                    paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInpSectionCd);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.AddUpSecCode);
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdateSecCd);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SubSectionCode);
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.InputDay);      //ADD 2009/03/25
                    paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.PaymentDate);
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.AddUpADate);
                    paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.PaymentTotal);
                    paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.Payment);
                    paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.FeePayment);
                    paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.DiscountPayment);
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.AutoPayment);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftDrawingDate);
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftKind);
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftKindName);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftDivide);
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftDivideName);
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftNo);
                    paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                    paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentCode);
                    paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentName);
                    paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentCd);
                    paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentNm);
                    paraOutline.Value = SqlDataMediator.SqlSetString(paymentSlpWork.Outline);
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.BankCode);
                    paraBankName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.BankName);
                    # endregion
                }

                int count = sqlCommand.ExecuteNonQuery();

                if (count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }

                //--- ADD 2008/04/22 M.Kubota ---<<<
            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        /// <summary>
        /// �x�����׃f�[�^���X�V���܂��B
        /// </summary>
        /// <param name="paymentSlpWork"></param>
        /// <param name="paymentDtlWorkArray"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int WritePaymentDtlWorkRec(PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                # region [DELETE��]
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);

                sqlCommand.ExecuteNonQuery();

                // 2009/04/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) 
                if ((paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) ||
                     (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1))
                // 2009/04/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    sqlCommand.Parameters.Clear();

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTDTLRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTSLIPNORF" + Environment.NewLine;
                    sqlText += " ,PAYMENTROWNORF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTRF" + Environment.NewLine;
                    sqlText += " ,VALIDITYTERMRF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@PAYMENTSLIPNO" + Environment.NewLine;
                    sqlText += " ,@PAYMENTROWNO" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += " ,@PAYMENT" + Environment.NewLine;
                    sqlText += " ,@VALIDITYTERM" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;                    
                    # endregion

                    # region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
                    SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                    SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                    SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    # endregion

                    foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        paymentDtlWork.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode; // 2009/04/28 �`�[�̘_���폜�敪���Z�b�g

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.LogicalDeleteCode);
                        paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.SupplierFormal);
                        paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.PaymentSlipNo);
                        paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.PaymentRowNo);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentDtlWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.MoneyKindDiv);
                        paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentDtlWork.Payment);
                        paraValidityTerm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDtlWork.ValidityTerm);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }
                    sqlDataReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        
        /// <summary>
        /// �x���`�[�ԍ����̔Ԃ��ĕԂ��܂�
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="AddUpSecCode">�v�㋒�_�R�[�h</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x���`�[�ԍ����̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 95089 ��{�@�E</br>
        /// <br>Date       : 2005.08.03</br>
        /// </remarks>	
        private int CreatePaymentSlipNoProc(string EnterpriseCode, string AddUpSecCode, out int paymentSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            paymentSlipNo = 0;
            //string retMsg = "";  //DEL 2008/04/25 M.Kubota

            //NumberNumbering numberNumbering = new NumberNumbering();  //DEL 2008/04/25 M.Kubota
            NumberingManager numberingManager = new NumberingManager(); //ADD 2008/04/25 M.Kubota

            //�ԍ��͈͕����[�v
            Int32 loopCnt = 1;
            while (loopCnt <= 999999999)
            {
                //string no;  //DEL 2008/04/25 M.Kubota
                long no;      //ADD 2008/04/25 M.Kubota

                //Int32 ptnCd;  //DEL 2008/04/25 M.Kubota
                //�ԍ��̔�
                //status = numberNumbering.Numbering(EnterpriseCode, AddUpSecCode, 52, new string[0], out no, out ptnCd, out retMsg);  //DEL 2008/04/25 M.Kubota
                status = numberingManager.GetSerialNumber(EnterpriseCode, AddUpSecCode, SerialNumberCode.PaymentSlipNo, out no);  //ADD 2008/04/25 M.Kubota
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //�ԍ��𐔒l�^�ɕϊ�
                    Int32 wkDepositSlipNo = System.Convert.ToInt32(no);  // Int32 �� Int64 �ŕϊ�
                    SqlDataReader myReader = null;
                    
                    //�x���󂫔ԃ`�F�b�N
                    try
                    {
                        //Select�R�}���h�̐���
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT PAYMENTSLIPNORF FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO", sqlConnection, sqlTransaction))
                        {

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                            findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(wkDepositSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //�f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                            if (!myReader.Read())
                            {
                                paymentSlipNo = wkDepositSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        //���N���X�ɗ�O��n���ď������Ă��炤
                        //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/22 M.Kubota

                        //--- ADD 2008/04/24 M.Kubota --->>>
                        string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                        //--- ADD 2008/04/24 M.Kubota ---<<<
                    }
                    finally
                    {
                        //if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close();  //DEL 2008/04/24 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                                myReader.Close();
                            myReader.Dispose();
                        }
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) break;
                }
                //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                else break;

                //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                loopCnt++;
            }

            //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                //retMsg = "�x���ԍ��ɋ󂫔ԍ�������܂���B�폜�\�Ȏx���`�[���폜���Ă��������B";  //DEL 2008/04/25 M.Kubota
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }

        # region --- DEL 2008/04/24 M.Kubota ---
# if false

        /// <summary>
        /// �x���X�V�������C��
        /// </summary>
        /// <param name="paymentDataWork">�x����񃏁[�N</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x���������Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �x���ԍ������̎��A�V�K�x���쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�(�����݂̂̍폜�\)</br>
        /// <br>Programmer : 95089 ��{�@�E</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int WritePaymentSlpWork(ref PaymentDataWork paymentDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int paymentSlipNo = 0;
            PaymentSlpWork bf_PaymentSlpWork = null;     // �X�V�O�x���`�[���
            bool mode_new = false;					     // �V�K�x�����[�h

            // �V�K�x���쐬��
            if (paymentDataWork.PaymentSlipNo == 0)
            {
                mode_new = true;							// �V�K�x�����[�h

                // �x���`�[�ԍ��̍̔�
                //status = CreatePaymentSlipNoProc(paymentDataWork.EnterpriseCode, paymentDataWork.AddUpSecCode, out paymentSlipNo, ref sqlConnection, ref sqlTransaction);//20060926 iwa del
                status = CreatePaymentSlipNoProc(paymentDataWork.EnterpriseCode, paymentDataWork.UpdateSecCd, out paymentSlipNo, ref sqlConnection, ref sqlTransaction);//20060926 iwa add

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �̔Ԃ����x���ԍ����x�����ɃZ�b�g
                paymentDataWork.PaymentSlipNo = paymentSlipNo;

            }
            // �x���C����
            else
            {
                // �X�V�O�x�����擾
                status = ReadPaymentSlpWorkRec(paymentDataWork.EnterpriseCode, paymentDataWork.PaymentSlipNo, out bf_PaymentSlpWork, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }


            // �x���f�[�^�X�V
            status = WritePaymentSlpWorkRec(mode_new, ref paymentDataWork, ref sqlConnection, ref sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // �x�����׃f�|�^�X�V

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �� 20070327 18322 c �d����x���i���|�j���z�}�X�^�̍X�V��
            //                     ���������ōs�����ƂɂȂ����ׁA�폜
        #region �d����x���i���|�j���z�}�X�^�̍X�V�i�S�ăR�����g�A�E�g�j
            //// ���z�}�X�^�X�V >>>>>>>>
            //UpdateSuplAccPayPayRec updateSuplAccPayPayRec = new UpdateSuplAccPayPayRec();
            //
            //SuplAccUpdatePara bf_suplAccUpdatePara = new SuplAccUpdatePara();						// ���z���Z���R�[�h
            //SuplAccUpdatePara af_suplAccUpdatePara = new SuplAccUpdatePara();						// ���z���Z���R�[�h
            //
            //ArrayList suplAccUpdateParas = new ArrayList();											// ���z�}�X�^�X�V���i�p�����[�^
            //
            //// �ǉ����R�[�h
            //if (paymentDataWork.LogicalDeleteCode == 0)												// �폜���ȊO
            //{
            //	af_suplAccUpdatePara.AddDel = 0;													// �ǉ��폜�敪:�ǉ��O
            //    af_suplAccUpdatePara.AddUpADate         = paymentDataWork.AddUpADate;				// �v����t
            //
            //    // �� 20061222 18322 c �g��.NS�p�ɕύX
            //    #region SF �x���z�E�x���l���z�擾(�R�����g�A�E�g)
            //    //af_suplAccUpdatePara.AddUpSeccode       = paymentDataWork.AddUpSecCode;				// �����v�㋒�_�R�[�h
            //
            //    //af_suplAccUpdatePara.Payment            = paymentDataWork.PaymentTotal;                   //�x���z
            //    //af_suplAccUpdatePara.DiscountPayment    = paymentDataWork.DiscountPayment;           //�x���l����
            //    #endregion
            //
            //    #region MA.NS ����x���z����ݒ�
            //    // ���Ӑ�R�[�h
            //    af_suplAccUpdatePara.SupplierCd  = paymentDataWork.SupplierCd ;
            //    // ���Ӑ於
            //    af_suplAccUpdatePara.SupplierNm1  = paymentDataWork.SupplierNm1 ;
            //    // ���Ӑ於2
            //    af_suplAccUpdatePara.SupplierNm2 = paymentDataWork.SupplierNm2;
            //
            //    // �v�㋒�_�R�[�h           <- �����v�㋒�_�R�[�h
            //    af_suplAccUpdatePara.AddUpSecCode = paymentDataWork.AddUpSecCode;
            //    // ����x�����z�i�ʏ�x���j <- �x���z
            //    af_suplAccUpdatePara.ThisTimePayNrml = paymentDataWork.Payment;
            //    // ����萔���z�i�ʏ�x���j <- �萔���x���z
            //    af_suplAccUpdatePara.ThisTimeFeePayNrml = paymentDataWork.FeePayment;
            //    // ����l���z�i�ʏ�x���j   <- �x���l����
            //    af_suplAccUpdatePara.ThisTimeDisPayNrml = paymentDataWork.DiscountPayment;
            //    // ���񃊃x�[�g�z�i�ʏ�x���j<- ���x�[�g�x���z
            //    af_suplAccUpdatePara.ThisTimeRbtPayNrml = paymentDataWork.RebatePayment;
            //    #endregion
            //    // �� 20061222 18322 c
            //
            //    suplAccUpdateParas.Add(af_suplAccUpdatePara);										// �p�����[�^�ǉ�
            //}
            //
            //// �폜���R�[�h
            //if(mode_new == false)																	// �x���C�������폜���R�[�h���ǉ�
            //{
            //	bf_suplAccUpdatePara.AddDel = 1;													// �ǉ��폜�敪:�폜�P
            //    bf_suplAccUpdatePara.AddUpADate         = bf_PaymentSlpWork.AddUpADate;				// �v����t
            //
            //    // �� 20061222 18322 c �g��.NS�p�ɕύX
            //    #region SF �x���z�E�x���l���z�擾(�R�����g�A�E�g)
            //    //bf_suplAccUpdatePara.AddUpSeccode       = bf_PaymentSlpWork.AddUpSecCode;			// �����v�㋒�_�R�[�h
            //    //
            //    //bf_suplAccUpdatePara.Payment            = bf_PaymentSlpWork.PaymentTotal;                //�x���z
            //    //bf_suplAccUpdatePara.DiscountPayment    = bf_PaymentSlpWork.DiscountPayment;        //�x���l����
            //    #endregion
            //
            //    #region MA.NS ����x���z����ݒ�
            //    // ���Ӑ�R�[�h
            //    bf_suplAccUpdatePara.SupplierCd  = bf_PaymentSlpWork.SupplierCd ;
            //    // ���Ӑ於
            //    bf_suplAccUpdatePara.SupplierNm1  = bf_PaymentSlpWork.SupplierNm1 ;
            //    // ���Ӑ於2
            //    bf_suplAccUpdatePara.SupplierNm2 = bf_PaymentSlpWork.SupplierNm2;
            //    // �v�㋒�_�R�[�h           <- �����v�㋒�_�R�[�h
            //    bf_suplAccUpdatePara.AddUpSecCode = bf_PaymentSlpWork.AddUpSecCode;
            //    // ����x�����z�i�ʏ�x���j <- �x���z
            //    bf_suplAccUpdatePara.ThisTimePayNrml = bf_PaymentSlpWork.Payment;
            //    // ����萔���z�i�ʏ�x���j <- �萔���x���z
            //    bf_suplAccUpdatePara.ThisTimeFeePayNrml = bf_PaymentSlpWork.FeePayment;
            //    // ����l���z�i�ʏ�x���j   <- �x���l����
            //    bf_suplAccUpdatePara.ThisTimeDisPayNrml = bf_PaymentSlpWork.DiscountPayment;
            //    // ���񃊃x�[�g�z�i�ʏ�x���j<- ���x�[�g�x���z
            //    bf_suplAccUpdatePara.ThisTimeRbtPayNrml = bf_PaymentSlpWork.RebatePayment;
            //    #endregion
            //    // �� 20061222 18322 c
            //
            //    suplAccUpdateParas.Add(bf_suplAccUpdatePara);										// �p�����[�^�ǉ�
            //}
            //
            //SuplAccUpdatePara[] SuplAccUpdateParaArray = (SuplAccUpdatePara[])suplAccUpdateParas.ToArray(typeof(SuplAccUpdatePara));
            //
            //// ���z�}�X�^�X�V����
            //status = updateSuplAccPayPayRec.Write(paymentDataWork.EnterpriseCode, paymentDataWork.SupplierCd, SuplAccUpdateParaArray, ref sqlConnection, ref sqlTransaction);
        #endregion
            // �� 20070327 18322 c 

            return status;
        }

# endif
        # endregion

        # endregion

        # region [�Ǎ�����]

        /// <summary>
		/// �x���Ǎ�����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="PaymentSlipNo">�x���ԍ�</param>
		/// <param name="paymentDataWorkByte">�x�����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �x�������x���ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int Read(string EnterpriseCode, int PaymentSlipNo, out byte[] paymentDataWorkByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            //PaymentSlpWork paymentSlpWork = new PaymentSlpWork();  //DEL 2008/04/24 M.Kubota

            paymentDataWorkByte = null;

            //--- ADD 2008/04/24 M.Kubota --->>>
            PaymentDataWork paymentDataWork = null;
            PaymentSlpWork paymentSlpWork = null;
            PaymentDtlWork[] paymentDtlWorkArray = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            //--- ADD 2008/04/24 M.Kubota ---<<<

            try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                ////SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                ////sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                # endregion

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    errmsg += ": �f�[�^�x�[�X�ւ̐ڑ��Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<

                // �x���Ǎ��ݏ���
                //status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/24 M.Kubota
                status = this.Read(EnterpriseCode, PaymentSlipNo, out paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);  //ADD 2008/04/24 M.Kubota

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                }

                # region --- DEL 2008/04/24 M.Kubota ---
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    sqlTransaction.Commit();
                //else
                //    sqlTransaction.Rollback();
                # endregion
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/24 M.Kubota ---<<<
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			// XML�֕ϊ����A������̃o�C�i����
            //paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);  //DEL 2008/04/24 M.Kubota
            paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);   //ADD 2008/04/24 M.Kubota

			return status;
        }

        /// <summary>
        /// �x���`�[�{�x�����׃f�[�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^</param>
        /// <param name="paymentDtlWorkArray">�x�����׃f�[�^�̔z��</param>
        /// <param name="sqlConnection">DB�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int Read(string EnterpriseCode, int paymentSlipNo, out PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            paymentSlpWork = new PaymentSlpWork();
            paymentDtlWorkArray = new PaymentDtlWork[0];

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�`�F�b�N]

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ���񂪖��ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (string.IsNullOrEmpty(EnterpriseCode))
                {
                    errmsg += ": ��ƃR�[�h�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (paymentSlipNo < 1)
                {
                    errmsg += ": �x���`�[�ԍ������ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                // �x���`�[�̓ǂݍ���
                status = this.ReadPaymentSlpWorkRec(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- ADD 2012/11/07 ---------->>>>>
                    // �l��or�萔���݂̂̃f�[�^�Őԓ`���s����ꍇ�͖��ׂ������ׁA
                    // ���׃f�[�^�Ǎ����X�L�b�v����
                    if (paymentSlpWork.Payment == 0 &&
                         (paymentSlpWork.FeePayment != 0 || paymentSlpWork.DiscountPayment != 0))
                    {
                    }
                    else
                    {
                        // �����̖��דǍ�����
                    // �x�����ׂ̓ǂݍ���
                    status = this.ReadPaymentDtlWorkRec(paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);
                    }
                    // --- ADD 2012/11/07 ----------<<<<<
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
                return status;
            }

            return status;
        }
 
        /// <summary>
        /// �x���}�X�^�����擾���܂�
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <param name="paymentSlpWork">�x�����</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x���}�X�^�����x���ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 95089 ��{�@�E</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        private int ReadPaymentSlpWorkRec(string EnterpriseCode, int paymentSlipNo, out PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            paymentSlpWork = new PaymentSlpWork();

            try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                // �� 20061222 18322 c �g��.NS�̃��C�A�E�g�ɂ��킹�ύX
                ////Select�R�}���h�̐���
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYMENTSLIPNORF, CUSTOMERCODERF, PAYMENTRF, DISCOUNTPAYMENTRF, FEEPAYMENTRF, OUTLINERF, PAYMENTINPSECTIONCDRF, PAYMENTDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, PAYMENTMONEYKINDCODERF, PAYMENTMONEYKINDDIVRF, PAYMENTMONEYKINDNAMERF, PAYMENTDIVNMRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF ,PAYMENTTOTALRF FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO", sqlConnection, sqlTransaction))
                //string sqlCmd = "SELECT *"
                //              + " FROM PAYMENTSLPRF"
                //              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //              + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"
                //              ;
                # endregion

                # region [SELECT��]
                string sqlCmd = string.Empty;
                sqlCmd += "SELECT" + Environment.NewLine;
                sqlCmd += "  PAY.CREATEDATETIMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDATEDATETIMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.ENTERPRISECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlCmd += " ,PAY.LOGICALDELETECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERNM1RF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERNM2RF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERSNMRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEENAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEENAME2RF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEESNMRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.ADDUPSECCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDATESECCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUBSECTIONCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.INPUTDAYRF" + Environment.NewLine;    //ADD 2009/03/25
                sqlCmd += " ,PAY.PAYMENTDATERF" + Environment.NewLine;
                sqlCmd += " ,PAY.ADDUPADATERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTTOTALRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.FEEPAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.AUTOPAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTKINDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTDIVIDERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlCmd += " ,PAY.OUTLINERF" + Environment.NewLine;
                sqlCmd += " ,PAY.BANKCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.BANKNAMERF" + Environment.NewLine;
                sqlCmd += "FROM" + Environment.NewLine;
                sqlCmd += "  PAYMENTSLPRF AS PAY" + Environment.NewLine;
                sqlCmd += "WHERE" + Environment.NewLine;
                sqlCmd += "  PAY.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlCmd += "  AND PAY.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection, sqlTransaction))
                // �� 20061222 18322 c
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        # region --- DEL 2008/04/24 M.Kubota ---
                        # if false    
                        #region �x���`�[�}�X�^�N���X�֑��
                        // �� 2007.11.02 980081 c
                        #region �����C�A�E�g(�R�����g�A�E�g)
                        //paymentDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //paymentDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //paymentDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        //paymentDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //paymentDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //paymentDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //paymentDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //paymentDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //
                        //// �� 20061222 18322 c �g��.NS�p�ɕύX
                        ////paymentDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                        ////paymentDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        ////paymentDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        ////paymentDataWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                        ////paymentDataWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                        ////paymentDataWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        ////paymentDataWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                        ////paymentDataWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                        ////paymentDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        ////paymentDataWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        ////paymentDataWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        ////paymentDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        ////paymentDataWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        ////paymentDataWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                        ////paymentDataWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                        ////paymentDataWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                        ////paymentDataWork.PaymentDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTDIVNMRF"));
                        ////paymentDataWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        ////paymentDataWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        ////paymentDataWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                        //
                        //// �ԓ`�敪
                        //paymentDataWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                        //// �x���`�[�ԍ�
                        //paymentDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                        //// ���Ӑ�R�[�h
                        //paymentDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        //// ���Ӑ於��
                        //paymentDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        //// ���Ӑ於��2
                        //paymentDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        //// �x�����͋��_�R�[�h
                        //paymentDataWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                        //// �v�㋒�_�R�[�h
                        //paymentDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        //// �X�V���_�R�[�h
                        //paymentDataWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        //// �x�����t
                        //paymentDataWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                        //// �v����t
                        //paymentDataWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        //// �x������R�[�h
                        //paymentDataWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                        //// �x�����햼��
                        //paymentDataWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                        //// �x������敪
                        //paymentDataWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                        //// �x���v
                        //paymentDataWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                        //// �x�����z
                        //paymentDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        //// �萔���x���z
                        //paymentDataWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                        //// �l���x���z
                        //paymentDataWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                        //// ���x�[�g�x���z
                        //paymentDataWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                        //// �����x���敪
                        //paymentDataWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                        //// �N���W�b�g�^���[���敪
                        //paymentDataWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// �N���W�b�g��ЃR�[�h
                        //paymentDataWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        //// ��`�U�o��
                        //paymentDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        //// ��`�x������
                        //paymentDataWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        //// �ԍ��x���A���ԍ�
                        //paymentDataWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                        //// �x���S���҃R�[�h
                        //paymentDataWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                        //// �x���S���Җ���
                        //// �� 20070907 980081 c
                        ////paymentDataWork.PaymentAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNMRF"));
                        //paymentDataWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                        //// �� 20070907 980081 c
                        //// �`�[�E�v
                        //paymentDataWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        //// �� 20061222 18322 c
                        //// �� 20070907 980081 c
                        //// ���Ӑ搿����R�[�h
                        //paymentDataWork.CustClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCLAIMCODERF"));
                        //// ����R�[�h
                        //paymentDataWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        //// �ۃR�[�h
                        //paymentDataWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        //// ��`���
                        //paymentDataWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        //// ��`��ޖ���
                        //paymentDataWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        //// ��`�敪
                        //paymentDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        //// ��`�敪����
                        //paymentDataWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        //// ��`�ԍ�
                        //paymentDataWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        //// �x�����͎҃R�[�h
                        //paymentDataWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                        //// �x�����͎Җ���
                        //paymentDataWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                        //// ��s�R�[�h
                        //paymentDataWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        //// ��s����
                        //paymentDataWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        //// �d�c�h���M��
                        //paymentDataWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        //// �d�c�h�捞��
                        //paymentDataWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        //// �e�L�X�g���o��
                        //paymentDataWork.TextExtraDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TEXTEXTRADATERF"));
                        //// �� 20070907 980081 c
                        #endregion
                        paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                        paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                        paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                        paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                        paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                        paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                        paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                        paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                        paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                        paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                        paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                        paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                        paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        paymentSlpWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                        paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        paymentSlpWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                        paymentSlpWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                        paymentSlpWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                        paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                        paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                        paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                        paymentSlpWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                        paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                        paymentSlpWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        paymentSlpWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        paymentSlpWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                        paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                        paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                        paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                        paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                        paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        paymentSlpWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        // �� 2007.12.10 980081 c
                        //paymentDataWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        paymentSlpWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        // �� 2007.12.10 980081 c
                        // �� 2007.11.02 980081 c
                        #endregion
                        # endif
                        # endregion
                        
                        this.ReadDataToPaymentSlp(ref paymentSlpWork, myReader);  //ADD 2008/04/24 M.Kubota

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        /// <summary>
        /// �x�����׃f�[�^��ǂݍ��݂܂�
        /// </summary>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^</param>
        /// <param name="paymentDtlWorkArray">�x�����׃f�[�^�̔z��</param>
        /// <param name="sqlConnection">DB�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        private int ReadPaymentDtlWorkRec(PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            paymentDtlWorkArray = new PaymentDtlWork[0];

            ArrayList paymentDtlWorList = new ArrayList();

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                # region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  PDTL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PDTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,PDTL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,PDTL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,PDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,PDTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,PDTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,PDTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,PDTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,PDTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,PDTL.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,PDTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTDTLRF AS PDTL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  PDTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND PDTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND PDTL.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);

                if (paymentSlpWork.DebitNoteDiv != 1)
                {
                    // 0:��, 2:�����̏ꍇ
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                }
                else
                {
                    // 1:�� �̏ꍇ
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                }

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    PaymentDtlWork paymentDtlWork = this.ReadDataToPaymentDtl(sqlDataReader);

                    if (paymentSlpWork.DebitNoteDiv == 1)
                    {
                        // 1:�� �̏ꍇ
                        paymentDtlWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
                        paymentDtlWork.Payment = paymentDtlWork.Payment * -1;
                    }

                    paymentDtlWorList.Add(paymentDtlWork);
                }

                if (paymentDtlWorList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    paymentDtlWorkArray = (PaymentDtlWork[])paymentDtlWorList.ToArray(typeof(PaymentDtlWork));
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }

                    sqlDataReader.Dispose();
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
        /// �x���`�[�}�X�^�̓ǂݍ��݌��ʂ��i�[���܂�
        /// </summary>
        /// <param name="sqlDataReader">�x���`�[�}�X�^�̓ǂݍ��݌���</param>
        /// <returns>�x���`�[�f�[�^</returns>
        private PaymentSlpWork ReadDataToPaymentSlp(SqlDataReader sqlDataReader)
        {
            PaymentSlpWork paymentSlpWork = new PaymentSlpWork();
            this.ReadDataToPaymentSlp(ref paymentSlpWork, sqlDataReader);
            return paymentSlpWork;
        }

        /// <summary>
        /// �x���`�[�}�X�^�̓ǂݍ��݌��ʂ��i�[���܂�
        /// </summary>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^</param>
        /// <param name="sqlDataReader">�x���`�[�}�X�^�̓Ǎ�����</param>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        private void ReadDataToPaymentSlp(ref PaymentSlpWork paymentSlpWork, SqlDataReader sqlDataReader)
        {
            try
            {
                #region [�x���`�[�}�X�^ �Ǎ����ʊi�[]
                paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));         // �쐬����
                paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));         // �X�V����
                paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));                    // ��ƃR�[�h
                paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));                      // GUID
                paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));                  // �X�V�]�ƈ��R�[�h
                paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));                    // �X�V�A�Z���u��ID1
                paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));                    // �X�V�A�Z���u��ID2
                paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));               // �_���폜�敪
                paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTEDIVRF"));                         // �ԓ`�敪
                paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTSLIPNORF"));                       // �x���`�[�ԍ�
                paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERFORMALRF"));                     // �d���`��
                paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERSLIPNORF"));                     // �d���`�[�ԍ�
                paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERCDRF"));                             // �d����R�[�h
                paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERNM1RF"));                          // �d���於1
                paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERNM2RF"));                          // �d���於2
                paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERSNMRF"));                          // �d���旪��
                paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYEECODERF"));                               // �x����R�[�h
                paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYEENAMERF"));                              // �x���於��
                paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYEENAME2RF"));                            // �x���於��2
                paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYEESNMRF"));                                // �x���旪��
                paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));          // �x�����͋��_�R�[�h
                paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPSECCODERF"));                        // �v�㋒�_�R�[�h
                paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDATESECCDRF"));                          // �X�V���_�R�[�h
                paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUBSECTIONCODERF"));                     // ����R�[�h
                paymentSlpWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDAYRF"));                  // ���͓��t  //ADD 2009/03/25
                paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTDATERF"));            // �x�����t
                paymentSlpWork.PrePaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTDATERF"));            // �x�����t // ADD 2011/12/21
                paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPADATERF"));              // �v����t
                paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTTOTALRF"));                         // �x���v
                paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTRF"));                                   // �x�����z
                paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("FEEPAYMENTRF"));                             // �萔���x���z
                paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DISCOUNTPAYMENTRF"));                   // �l���x���z
                paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("AUTOPAYMENTRF"));                           // �����x���敪
                paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDRAWINGDATERF"));  // ��`�U�o��
                paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDRF"));                               // ��`���
                paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDNAMERF"));                      // ��`��ޖ���
                paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDERF"));                           // ��`�敪
                paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDENAMERF"));                  // ��`�敪����
                paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTNORF"));                                  // ��`�ԍ�
                paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTELINKPAYNORF"));             // �ԍ��x���A���ԍ�
                paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTAGENTCODERF"));                // �x���S���҃R�[�h
                paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTAGENTNAMERF"));                // �x���S���Җ���
                paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));          // �x�����͎҃R�[�h
                paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));          // �x�����͎Җ���
                paymentSlpWork.Outline = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("OUTLINERF"));                                  // �`�[�E�v
                paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("BANKCODERF"));                                 // ��s�R�[�h
                paymentSlpWork.BankName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("BANKNAMERF"));                                // ��s����
                # endregion
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
        }

        /// <summary>
        /// �x�����׃f�[�^�̓ǂݍ��݌��ʂ��i�[���܂��B
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private PaymentDtlWork ReadDataToPaymentDtl(SqlDataReader sqlDataReader)
        {
            PaymentDtlWork paymentDtlWork = new PaymentDtlWork();
            this.ReadDataToPaymentDtl(ref paymentDtlWork, sqlDataReader);
            return paymentDtlWork;
        }

        /// <summary>
        /// �x�����׃f�[�^�̓ǂݍ��݌��ʂ��i�[���܂��B
        /// </summary>
        /// <param name="paymentDtlWork">�x�����׃f�[�^</param>
        /// <param name="sqlDataReader">�x�����׃f�[�^�̓Ǎ�����</param>
        private void ReadDataToPaymentDtl(ref PaymentDtlWork paymentDtlWork, SqlDataReader sqlDataReader)
        {
            try
            {
                # region [�x�����׃f�[�^ �Ǎ����ʊi�[]
                paymentDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                paymentDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                paymentDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
                paymentDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                paymentDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
                paymentDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
                paymentDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
                paymentDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
                paymentDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERFORMALRF"));              // �d���`��
                paymentDtlWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTSLIPNORF"));                // �x���`�[�ԍ�
                paymentDtlWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTROWNORF"));                  // �x���s�ԍ�
                paymentDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDCODERF"));                // ����R�[�h
                paymentDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDNAMERF"));               // ���햼��
                paymentDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDDIVRF"));                  // ����敪
                paymentDtlWork.Payment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTRF"));                            // �x�����z
                paymentDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("VALIDITYTERMRF"));   // �L������
                # endregion
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
        }

        # region --- DEL 2008/04/24 M.Kubota ---
# if false
        /// <summary>
        /// �x���Ǎ��������C��
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="PaymentSlipNo">�x���ԍ�</param>
        /// <param name="paymentDataWork">�x�����</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����E�x�����������x���ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 95089 ��{�@�E</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int ReadPaymentSlpWork(string EnterpriseCode, int PaymentSlipNo, out PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            paymentSlpWork = new PaymentSlpWork();

            // �x���}�X�^�Ǎ�����
            status = ReadPaymentSlpWorkRec(EnterpriseCode, PaymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

            return status;
        }
# endif
        # endregion

        # endregion

        # region [�_���폜����]

        // �� 2008.01.11 980081 a
        /// <summary>
        /// �x���_���폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���ԍ��̎x�����_���폜���s���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string enterpriseCode, int paymentSlipNo)
        {
            byte[] paymentDataWorkByte;

            int status = LogicalDelete(enterpriseCode, paymentSlipNo, out paymentDataWorkByte);

            return status;
        }

        /// <summary>
        /// �x���_���폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���ԍ��̎x�����_���폜���s���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string enterpriseCode, int paymentSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            byte[] paymentDataWorkByte;

            int status = LogicalDelete(enterpriseCode, paymentSlipNo, out paymentDataWorkByte, ref sqlConnection, ref sqlTransaction);

            return status;
        }

        /// <summary>
        /// �x���_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <param name="paymentDataWorkByte">�X�V�x���f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���ԍ��̎x�����_���폜���s���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string EnterpriseCode, int paymentSlipNo, out byte[] paymentDataWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region --- DEL 2008/04/24 M.Kubota ---
            # if false
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            PaymentSlpWork paymentSlpWork = null;

            paymentDataWorkByte = null;

            ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i

            try
            {
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                if (connectionText == null || connectionText == "") return status;

                //SQL�ڑ�
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);//20061018 iwa add

                // �x���Ǎ��ݏ���
                status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // �� 20070213 18322 a MA.NS�p�ɕύX
                // �ԓ`�敪���Q(���E�ςݍ�)�̏ꍇ�̓G���[
                if (paymentSlpWork.DebitNoteDiv == 2)
                {
                    // UI�d�l��A�����X�V���ɔ�������\�������邽�߁A�r���G���[�ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }
                // �� 20070213 18322 a

                // �X�V�����b�N����
                int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, SupplierCdList, null);	// ���Ӑ�ʃ��b�N��������

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // �_���폜�𗧂Ă�i�X�V���������ŕ����폜�����E�����X�V���������s�����j
                if (paymentSlpWork != null)
                    paymentSlpWork.LogicalDeleteCode = 1;

                // �x���}�X�^�X�V����
                status = LogicalDeletePaymentSlpWork(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                // �� 20070213 18322 a MA.NS�p�ɕύX
                // �ԓ����̍폜�̏ꍇ�A�����̓����E�������̍X�V���s��(�ԑ��E�̋敪�֘A���N���A����)
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                   (paymentSlpWork.DebitNoteDiv == 1))
                {
                    // �ԓ`�폜

                    // �x���Ǎ��ݏ���(�ԑ��E����Ă����x���`�[)
                    status = ReadPaymentSlpWork(EnterpriseCode
                                               , paymentSlpWork.DebitNoteLinkPayNo
                                               , out paymentSlpWork
                                               , ref sqlConnection
                                               , ref sqlTransaction);

                    // �ԓ`�敪���N���A
                    paymentSlpWork.DebitNoteDiv = 0;

                    // �����x���̐ԍ��A���ԍ����N���A
                    paymentSlpWork.DebitNoteLinkPayNo = 0;

                    // �����x���}�X�^�X�V����
                    status = LogicalDeletePaymentSlpWork(ref paymentSlpWork
                                                , ref sqlConnection
                                                , ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XML�֕ϊ����A������̃o�C�i����
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);
                    }
                }
                // �� 20070213 18322 a

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // �X�V�����b�N����
                controlExclusiveOrderAccess.UnlockDB();
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            # endif
            # endregion

            //--- ADD 2008/04/24 M.Kubota --->>>
            paymentDataWorkByte = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);

            try
            {
                status = this.LogicalDelete(EnterpriseCode, paymentSlipNo, out paymentDataWorkByte, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
                else
                {
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<

            return status;
        }

        /// <summary>
        /// �x���_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <param name="paymentDataWorkByte">�X�V�x���f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���ԍ��̎x�����_���폜���s���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string EnterpriseCode, int paymentSlipNo, out byte[] paymentDataWorkByte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            PaymentSlpWork paymentSlpWork = null;
            PaymentDataWork paymentDataWork = null;       //ADD 2008/04/24 M.Kubota
            PaymentDtlWork[] paymentDtlWorkArray = null;  //ADD 2008/04/24 M.Kubota

            paymentDataWorkByte = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/24 M.Kubota

            try
            {
                // �x���Ǎ��ݏ���
                //status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/24 M.Kubota
                status = this.ReadPaymentSlpWorkRec(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/24 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �� 20070213 18322 a MA.NS�p�ɕύX
                // �ԓ`�敪���Q(���E�ςݍ�)�̏ꍇ�̓G���[
                if (paymentSlpWork.DebitNoteDiv == 2)
                {
                    // UI�d�l��A�����X�V���ɔ�������\�������邽�߁A�r���G���[�ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }
                // �� 20070213 18322 a

                # region --- DEL 2008/04/24 M.Kubota ---
                // �X�V�����b�N����
                //int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, SupplierCdList, null);	// ���Ӑ�ʃ��b�N��������

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                # endregion --- DEL 2008/04/24 M.Kubota ---

                // �_���폜�𗧂Ă�i�X�V���������ŕ����폜�����E�����X�V���������s�����j
                if (paymentSlpWork != null)
                    paymentSlpWork.LogicalDeleteCode = 1;

                // �x���}�X�^�X�V����
                status = LogicalDeletePaymentSlpWork(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);
                if (STATUS_CHK_SEND_ERR == status) // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)
                    return status; // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)

                // �� 20070213 18322 a MA.NS�p�ɕύX
                // �ԓ����̍폜�̏ꍇ�A�����̓����E�������̍X�V���s��(�ԑ��E�̋敪�֘A���N���A����)
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                   (paymentSlpWork.DebitNoteDiv == 1))
                {
                    // �ԓ`�폜

                    // �x���Ǎ��ݏ���(�ԑ��E����Ă����x���`�[)
                    # region --- DEL 2008/04/24 M.Kubota ---
                    //status = ReadPaymentSlpWork(EnterpriseCode
                    //                           , paymentSlpWork.DebitNoteLinkPayNo
                    //                           , out paymentSlpWork
                    //                           , ref sqlConnection
                    //                           , ref sqlTransaction);
                    # endregion --- DEL 2008/04/24 M.Kubota ---

                    status = this.ReadPaymentSlpWorkRec(EnterpriseCode, paymentSlpWork.DebitNoteLinkPayNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                    // �ԓ`�敪���N���A
                    paymentSlpWork.DebitNoteDiv = 0;

                    // �����x���̐ԍ��A���ԍ����N���A
                    paymentSlpWork.DebitNoteLinkPayNo = 0;

                    // �����x���}�X�^�X�V����
                    # region --- DEL 2008/04/24 M.Kubota ---
                    //status = LogicalDeletePaymentSlpWork(ref paymentSlpWork
                    //                            , ref sqlConnection
                    //                            , ref sqlTransaction);
                    # endregion --- DEL 2008/04/24 M.Kubota ---

                    //this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/24 M.Kubota //DEL 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)
                    if (STATUS_CHK_SEND_ERR == this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction)) // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)
                        return STATUS_CHK_SEND_ERR; // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)

                    # region --- DEL 2008/04/24 M.Kubota ---
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // XML�֕ϊ����A������̃o�C�i����
                    //    paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);
                    //}
                    # endregion --- DEL 2008/04/24 M.Kubota ---
                }
                // �� 20070213 18322 a

                //--- ADD 2008/04/24 M.Kubota --->>>
                status = this.LogicalDeletePaymentDtlWork(paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                    paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<

            }
            # region --- DEL 2008/04/24 M.Kubota ---
            //catch (SqlException ex)
            //{
            //    //���N���X�ɗ�O��n���ď������Ă��炤
            //    status = base.WriteSQLErrorLog(ex);
            //}
            # endregion --- DEL 2008/04/24 M.Kubota ---
            //--- ADD 2008/04/24 M.Kubota --->>>
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                return status;
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/24 M.Kubota
            }

            return status;
        }

        /// <summary>
        /// �x���}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="paymentSlpWork">�x���}�X�^���</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �x�������X�V���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        private int LogicalDeletePaymentSlpWork(ref PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            string updateText;

            // �X�V���t���擾
            DateTime Upd_UpdateDateTime = paymentSlpWork.UpdateDateTime;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/24 M.Kubota

            //Select�R�}���h�̐���
            try
            {
                // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                // �x���f�[�^���X�V����O�ɁA���M�ς݂̃`�F�b�N���s��
                if (!CheckPaymentSlpSending(paymentSlpWork))
                {
                    // �`�F�b�NNG
                    return STATUS_CHK_SEND_ERR;
                }
                // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                #region �x���}�X�^ UPDATE��
                // �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                updateText = "UPDATE PAYMENTSLPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE"
                           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                             + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                             + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"
                             ;
                #endregion

                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)paymentSlpWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);


                    #region �x���}�X�^ Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    // �쐬����
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // �X�V����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // ��ƃR�[�h
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // �X�V�A�Z���u��ID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    #endregion

                    #region �x���}�X�^ Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    // �쐬����
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                    // �X�V����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    // ��ƃR�[�h
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                    // �X�V�]�ƈ��R�[�h
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    // �X�V�A�Z���u��ID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    // �_���폜�敪
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
                    #endregion

                    int count = sqlCommand.ExecuteNonQuery();

                    // �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }

            }
            catch (SqlException ex)
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                //if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);
                # endregion --- DEL 2008/04/24 M.Kubota ---

                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/24 M.Kubota
            }
            //--- ADD 2008/04/24 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
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
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/24 M.Kubota

            return status;
        }

        private int LogicalDeletePaymentDtlWork(PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            paymentDtlWorkArray = new PaymentDtlWork[0];

            // �X�V���t���擾
            DateTime Upd_UpdateDateTime = paymentSlpWork.UpdateDateTime;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/24 M.Kubota

            try
            {
                # region [UPDATE��]
                string sqlText = string.Empty;
                sqlText += "UPDATE PAYMENTDTLRF" + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);


                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);

                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);

                    int count = sqlCommand.ExecuteNonQuery();

                    // �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.ReadPaymentDtlWorkRec(paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
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
            }

            return status;
        }

        # endregion

        # region [�폜����]

        // �� 2008.01.11 980081 a

		/// <summary>
		/// �x���폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <param name="payDraftDataWorkByte">�x����`���</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���x���ԍ��̎x�����폜���s���܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int Delete(string EnterpriseCode, int paymentSlipNo)
        public int Delete(string EnterpriseCode, int paymentSlipNo, byte[] payDraftDataWorkByte)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
        {
			byte[] paymentDataWorkByte;

            // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
            //int status = Delete(EnterpriseCode, paymentSlipNo, out paymentDataWorkByte);
            int status = Delete(EnterpriseCode, paymentSlipNo, payDraftDataWorkByte, out paymentDataWorkByte);
            // --- UPD 2013/02/21 Y.Wakita ----------<<<<<

			return status;
		}

		/// <summary>
		/// �x���폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���ԍ�</param>
        /// <param name="payDraftDataWorkByte">�x����`���</param>
        /// <param name="paymentDataWorkByte">�X�V�x���f�[�^(�ԍ폜���̌������R�[�h)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���x���ԍ��̎x�����폜���s���܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int Delete(string EnterpriseCode, int paymentSlipNo, out byte[] paymentDataWorkByte)
        public int Delete(string EnterpriseCode, int paymentSlipNo, byte[] payDraftDataWorkByte, out byte[] paymentDataWorkByte)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            PaymentSlpWork paymentSlpWork = null;

            PaymentDataWork paymentDataWork = null;       //ADD 2008/04/24 M.Kubota
            PaymentDtlWork[] paymentDtlWorkArray = null;  //ADD 2008/04/24 M.Kubota

            paymentDataWorkByte = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/24 M.Kubota
            
            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/24 M.Kubota

			try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                ////���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                ////SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                ////sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);//20061018 iwa add
                # endregion

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����̍쐬�Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/24 M.Kubota ---<<<

                // �x���Ǎ��ݏ���
                //status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork,  ref sqlConnection, ref sqlTransaction);       //DEL 2008/04/24 M.Kubota
                status = this.Read(EnterpriseCode, paymentSlipNo, out paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);    //ADD 2008/04/24 M.Kubota
                    
				if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					sqlTransaction.Rollback();
					sqlConnection.Close();
					sqlConnection.Dispose();

					return status;
				}

                // �� 20070213 18322 a MA.NS�p�ɕύX
				// �ԓ`�敪���Q(���E�ςݍ�)�̏ꍇ�̓G���[
				if(paymentSlpWork.DebitNoteDiv == 2)
				{
					// UI�d�l��A�����X�V���ɔ�������\�������邽�߁A�r���G���[�ŕԂ�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					return status;
				}
                // �� 20070213 18322 a

                # region --- DEL 2008/04/24 M.Kubota ---
                //// �X�V�����b�N����
                //int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, SupplierCdList, null);	// ���Ӑ�ʃ��b�N��������

                //if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    sqlTransaction.Rollback();
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();

                //    return status;
                //}
                # endregion

                // �_���폜�𗧂Ă�i�X�V���������ŕ����폜�����E�����X�V���������s�����j
                if (paymentSlpWork != null)
                    paymentSlpWork.LogicalDeleteCode = 1;

				// �x���}�X�^�X�V����
                //status = WritePaymentSlpWork(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);                //DEL 2008/04/24 M.Kubota
                status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/24 M.Kubota

                // --- ADD 2013/02/21 Y.Wakita ---------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PayDraftDataWork payDraftDataWork = new PayDraftDataWork();
                    if (payDraftDataWorkByte != null)
                        payDraftDataWork = XmlByteSerializer.Deserialize(payDraftDataWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                    else
                        payDraftDataWork = null;

                    // �x����`�f�[�^�X�V����
                    if (payDraftDataWork != null)
                    {
                        if (payDraftDataWork.PaymentRowNo != 0 && paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                        {
                            // �d���`��
                            payDraftDataWork.SupplierFormal = 0;
                            // �x���`�[�ԍ�
                            payDraftDataWork.PaymentSlipNo = 0;
                            // �x���s�ԍ�
                            payDraftDataWork.PaymentRowNo = 0;
                            // �x�����t
                            string d, f;
                            DateTime dt;
                            d = payDraftDataWork.ProcDate.ToString();
                            f = "yyyyMMdd";
                            dt = DateTime.ParseExact(d, f, null);

                            payDraftDataWork.PaymentDate = dt;
                        }

                        status = this.WritePayDraft(payDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    }
                }
                // --- ADD 2013/02/21 Y.Wakita ----------<<<<<

                // �� 20070213 18322 a MA.NS�p�ɕύX
				// �ԓ����̍폜�̏ꍇ�A�����̓����E�������̍X�V���s��(�ԑ��E�̋敪�֘A���N���A����)
				if((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                   (paymentSlpWork.DebitNoteDiv == 1)                          )
				{
                    // �ԓ`�폜

                    // �x���Ǎ��ݏ���(�ԑ��E����Ă����x���`�[)
                    //--- DEL 2008/04/24 M.Kubota --->>>
                    //status = ReadPaymentSlpWork( EnterpriseCode
                    //                           , paymentSlpWork.DebitNoteLinkPayNo 
                    //                           , out paymentSlpWork
                    //                           , ref sqlConnection
                    //                           , ref sqlTransaction);
                    //--- DEL 2008/04/24 M.Kubota ---<<<

                    paymentSlipNo = paymentSlpWork.DebitNoteLinkPayNo;
                    status = this.Read(EnterpriseCode, paymentSlipNo, out paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);    //ADD 2008/04/24 M.Kubota

					// �ԓ`�敪���N���A
					paymentSlpWork.DebitNoteDiv = 0;

					// �����x���̐ԍ��A���ԍ����N���A
					paymentSlpWork.DebitNoteLinkPayNo = 0;

                    // �����x���}�X�^�X�V����
                    //--- DEL 2008/04/24 M.Kubota --->>>
                    //status = WritePaymentSlpWork( ref paymentSlpWork
                    //                            , ref sqlConnection
                    //                            , ref sqlTransaction);
                    //--- DEL 2008/04/24 M.Kubota ---<<<
                    status = this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

					if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// XML�֕ϊ����A������̃o�C�i����
                        //paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);  //DEL 2008/04/24 M.Kubota
                        //--- ADD 2008/04/24 M.Kubota --->>>
                        PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                        //--- ADD 2008/04/24 M.Kubota ---<<<
					}
				}
                // �� 20070213 18322 a

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();
			}
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);
                base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //DEL 2008/04/24 M.Kubota
            }
            //--- ADD 2008/04/24 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<
            }

            //--- DEL 2008/04/25 M.Kubota --->>>
            //if(sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            //--- DEL 2008/04/25 M.Kubota ---<<<

			return status;
        }

        # endregion

        # region [�ԓ`�쐬]
        /// <summary>
        /// �x���`�[�ԓ`����
        /// </summary>
        /// <param name="Mode">�ԓ`�쐬���[�h 0:�ԓ����쐬</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
        /// <param name="PaymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="PaymentAgentName">�x���S���Җ�</param>
        /// <param name="AddUpADate">�v���</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�(�ԓ`���s�����`)</param>
        /// <param name="RetPaymentSlpWorkList">�x���`�[�}�X�^(�X�V����)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���`�[�ԍ��̐Ԏx���쐬�������s���܂�</br>    
        /// <br>Programmer : 18322 �ؑ� ����</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        // �� 20070907 980081 c
        //public int RedCreate(int Mode, string EnterpriseCode, string UpdateSecCd, string PaymentAgentCode, string PaymentAgentNm, DateTime AddUpADate, int paymentSlipNo, out object RetPaymentSlpWorkList)
        public int RedCreate(int Mode, string EnterpriseCode, string UpdateSecCd, string PaymentAgentCode, string PaymentAgentName, DateTime AddUpADate, int paymentSlipNo, out object RetPaymentSlpWorkList)
        // �� 20070907 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            RetPaymentSlpWorkList = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            PaymentSlpWork paymentSlpWork = null;
            
            //--- ADD 2008/04/24 M.Kubota --->>>
            PaymentDtlWork[] paymentDtlArray = null;
            PaymentDataWork blkpaymentDataWork = null;
            PaymentDataWork redPaymentDataWork = null;
            
            // 2009/04/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //string resName = this.GetResourceName(EnterpriseCode);
            //status = this.Lock(resName, sqlConnection, sqlTransaction);

            //string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            // 2009/04/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //--- ADD 2008/04/24 M.Kubota ---<<<

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/24 M.Kubota

            string resName = string.Empty; // 2009/04/28

            try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                ////���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                ////SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();

                //// ����
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                # endregion --- DEL 2008/04/24 M.Kubota ---

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                
                string errmsg = string.Empty; // 2009/04/28

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ւ̐ڑ��Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/24 M.Kubota ---<<<

                // -- 2009/04/28 -- >>>>>>>>>>>>>
                resName = this.GetResourceName(EnterpriseCode);
                status = this.Lock(resName, sqlConnection, sqlTransaction);

                errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                // -- 2009/04/28 -- <<<<<<<<<<<<<

                // �x���Ǎ��ݏ���
                # region --- DEL 2008/04/24 M.Kubota ---
                //status = ReadPaymentSlpWork(EnterpriseCode,
                //                            PaymentSlipNo,
                //                            out paymentSlpWork,
                //                            ref sqlConnection,
                //                            ref sqlTransaction);
                # endregion --- DEL 2008/04/24 M.Kubota ---

                status = this.Read(EnterpriseCode, paymentSlipNo, out paymentSlpWork, out paymentDtlArray, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[�I��
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    return status;
                }

                # region --- DEL 2008/04/24 M.Kubota ---
                //// �X�V�����b�N����(���Ӑ�ʃ��b�N)
                //int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode,
                //                                            SupplierCdList,
                //                                            null);
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    // �G���[�I��
                //    sqlTransaction.Rollback();
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //    return status;
                //}
                # endregion --- DEL 2008/04/24 M.Kubota ---

                // �ԓ`�f�[�^�쐬
                // �� 20070907 980081 c
                //PaymentSlpWork redPaymentSlip = CreateRedPaymentSlipProc(UpdateSecCd,
                //                                                         PaymentAgentCode,
                //                                                         PaymentAgentNm,
                //                                                         AddUpADate,
                //                                                         paymentDataWork);
                PaymentSlpWork redPaymentSlip = CreateRedPaymentSlipProc(UpdateSecCd,
                                                                         PaymentAgentCode,
                                                                         PaymentAgentName,
                                                                         AddUpADate,
                                                                         paymentSlpWork);
                // �� 20070907 980081 c
                // �ԓ`�o�^����
                # region --- DEL 2008/04/24 M.Kubota ---
                //status = WritePaymentSlpWork(ref redPaymentSlip,
                //                             ref sqlConnection,
                //                             ref sqlTransaction);
                # endregion --- DEL 2008/04/24 M.Kubota ---
                
                //--- ADD 2008/04/24 M.Kubota --->>>

                // �ԓ`�p�̃_�~�[���׃f�[�^���쐬���Ă����A���������̃f�[�^��DB�ɓo�^����Ȃ�
                PaymentDtlWork[] redPaymentDtlArray = this.CreateRedPaymentDtlProc(redPaymentSlip.PaymentSlipNo, paymentDtlArray);

                status = this.WriteInitial(ref redPaymentSlip, ref redPaymentDtlArray, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    errmsg += ": �x���`�[�ԍ��̍̔ԂɎ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                status = this.WritePaymentSlpWorkRec(ref redPaymentSlip, ref sqlConnection, ref sqlTransaction);

                //--- ADD 2008/04/24 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[�I��
                    sqlTransaction.Rollback();
                    //sqlConnection.Close();    //DEL 2008/04/24 M.Kubota
                    //sqlConnection.Dispose();  //DEL 2008/04/24 M.Kubota
                    return status;
                }

                PaymentDataUtil.Union(out redPaymentDataWork, redPaymentSlip, redPaymentDtlArray);  //ADD 2008/04/24 M.Kubota

                // ���E�ςݍ��`�X�V����
                paymentSlpWork.DebitNoteDiv = 2;
                paymentSlpWork.DebitNoteLinkPayNo = redPaymentSlip.PaymentSlipNo;
                # region --- DEL 2008/04/24 M.Kubota ---
                //status = WritePaymentSlpWork(ref paymentSlpWork,
                //                             ref sqlConnection,
                //                             ref sqlTransaction);
                #endregion --- DEL 2008/04/24 M.Kubota ---

                status = this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[�I��
                    sqlTransaction.Rollback();
                    //sqlConnection.Close();    //DEL 2008/04/24 M.Kubota
                    //sqlConnection.Dispose();  //DEL 2008/04/24 M.Kubota
                    return status;
                }

                PaymentDataUtil.Union(out blkpaymentDataWork, paymentSlpWork, paymentDtlArray);  //ADD 2008/04/24 M.Kubota

                // ����I��
                sqlTransaction.Commit();
                //sqlConnection.Close();    //DEL 2008/04/24 M.Kubota
                //sqlConnection.Dispose();  //DEL 2008/04/24 M.Kubota

                //=================================================
                // ���E�ςݍ��`�E�ԓ`��߂�p�̃p�����[�^�ɐݒ�
                //=================================================
                ArrayList list = new ArrayList();
                //list.Add(paymentSlpWork);  //DEL 2008/04/24 M.Kubota
                //list.Add(redPaymentSlip);  //DEL 2008/04/24 M.Kubota

                list.Add(redPaymentDataWork);  //ADD 2008/04/24 M.Kubota
                list.Add(blkpaymentDataWork);  //ADD 2008/04/24 M.Kubota

                RetPaymentSlpWorkList = list;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>
                this.Release(resName, sqlConnection, sqlTransaction);
                
                if (sqlTransaction != null)
                {
                    //if (sqlTransaction.Connection != null || status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)
                    if (sqlTransaction.Connection != null && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)
                    {
                        sqlTransaction.Rollback();
                    }
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<
            }

            # region --- DEL 2008/04/24 M.Kubota ---
            //if (sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            # endregion --- DEL 2008/04/24 M.Kubota ---

            return status;
        }

        /// <summary>
		/// �x���`�[�ԓ`�쐬
		/// </summary>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="paymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="paymentAgentName">�x���S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="paymentSlpWork">�x���`�[�}�X�^(�ԓ`��)</param>
        /// <returns>�ԓ`�f�[�^</returns>
		/// <remarks>
        /// <br>Note       : �x���`�[�̐ԓ`�f�[�^���쐬���܂��B</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2006.12.22</br>
		/// </remarks>
        // �� 20070907 980081 c
        //private PaymentSlpWork CreateRedPaymentSlipProc(string updateSecCd, string paymentAgentCode, string paymentAgentNm, DateTime addUpADate, PaymentSlpWork paymentDataWork)
        private PaymentSlpWork CreateRedPaymentSlipProc(string updateSecCd, string paymentAgentCode, string paymentAgentName, DateTime addUpADate, PaymentSlpWork paymentSlpWork)
        // �� 20070907 980081 c
        {
            PaymentSlpWork ret = new PaymentSlpWork();

            # region --- DEL 2008/04/24 M.Kubota ---
            # if false
            // �� 2007.11.02 980081 c
            #region �����C�A�E�g
            //// ��ƃR�[�h
            //ret.EnterpriseCode = paymentDataWork.EnterpriseCode;
            //// �X�V�]�ƈ��R�[�h
            //ret.UpdEmployeeCode = paymentAgentCode;
            //// �X�V�A�Z���u��ID1
            //ret.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;
            //// �X�V�A�Z���u��ID2
            //ret.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;
            //// �_���폜�敪
            //ret.LogicalDeleteCode = 0;
            //// �ԓ`�敪
            //ret.DebitNoteDiv = 1;
            //// �x���`�[�ԍ�
            //ret.paymentSlipNo = 0;
            //// ���Ӑ�R�[�h
            //ret.SupplierCd = paymentDataWork.SupplierCd;
            //// ���Ӑ於��
            //ret.SupplierNm1 = paymentDataWork.SupplierNm1;
            //// ���Ӑ於��2
            //ret.SupplierNm2 = paymentDataWork.SupplierNm2;
            //// �x�����͋��_�R�[�h
            //ret.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;
            //// �v�㋒�_�R�[�h
            //ret.AddUpSecCode = paymentDataWork.AddUpSecCode;
            //// �X�V���_�R�[�h
            //ret.UpdateSecCd = updateSecCd;
            //// �x�����t
            //ret.PaymentDate = addUpADate;
            //// �v����t
            //ret.AddUpADate = addUpADate;
            //// �x������R�[�h
            //ret.PaymentMoneyKindCode = paymentDataWork.PaymentMoneyKindCode;
            //// �x�����햼��
            //ret.PaymentMoneyKindName = paymentDataWork.PaymentMoneyKindName;
            //// �x������敪
            //ret.PaymentMoneyKindDiv = paymentDataWork.PaymentMoneyKindDiv;
            //// �x���v
            //ret.PaymentTotal = paymentDataWork.PaymentTotal * -1;
            //// �x�����z
            //ret.Payment = paymentDataWork.Payment * -1;
            //// �萔���x���z
            //ret.FeePayment = paymentDataWork.FeePayment * -1;
            //// �l���x���z
            //ret.DiscountPayment = paymentDataWork.DiscountPayment * -1;
            //// ���x�[�g�x���z
            //ret.RebatePayment = paymentDataWork.RebatePayment * -1;
            //// �����x���敪
            //ret.AutoPayment = paymentDataWork.AutoPayment;
            //// �N���W�b�g�^���[���敪
            //ret.CreditOrLoanCd = paymentDataWork.CreditOrLoanCd;
            //// �N���W�b�g��ЃR�[�h
            //ret.CreditCompanyCode = paymentDataWork.CreditCompanyCode;
            //// ��`�U�o��
            //ret.DraftDrawingDate = paymentDataWork.DraftDrawingDate;
            //// ��`�x������
            //ret.DraftPayTimeLimit = paymentDataWork.DraftPayTimeLimit;
            //// �ԍ��x���A���ԍ�
            //ret.DebitNoteLinkPayNo = paymentDataWork.paymentSlipNo;
            //// �x���S���҃R�[�h
            //ret.PaymentAgentCode = paymentAgentCode;
            //// �x���S���Җ���
            //// �� 20070907 980081 c
            ////ret.PaymentAgentNm = paymentAgentNm;
            //ret.PaymentAgentName = paymentAgentName;
            //// �� 20070907 980081 c
            //// �`�[�E�v
            //ret.Outline = paymentDataWork.Outline;
            //// �� 20070907 980081 a
            //// ���Ӑ搿����R�[�h
            //ret.CustClaimCode = paymentDataWork.CustClaimCode;
            //// ����R�[�h
            //ret.SubSectionCode = paymentDataWork.SubSectionCode;
            //// �ۃR�[�h
            //ret.MinSectionCode = paymentDataWork.MinSectionCode;
            //// ��`���
            //ret.DraftKind = paymentDataWork.DraftKind;
            //// ��`��ޖ���
            //ret.DraftKindName = paymentDataWork.DraftKindName;
            //// ��`�敪
            //ret.DraftDivide = paymentDataWork.DraftDivide;
            //// ��`�敪����
            //ret.DraftDivideName = paymentDataWork.DraftDivideName;
            //// ��`�ԍ�
            //ret.DraftNo = paymentDataWork.DraftNo;
            //// �x�����͎҃R�[�h
            //ret.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;
            //// �x�����͎Җ���
            //ret.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;
            //// ��s�R�[�h
            //ret.BankCode = paymentDataWork.BankCode;
            //// ��s����
            //ret.BankName = paymentDataWork.BankName;
            //// �d�c�h���M��
            //ret.EdiSendDate = paymentDataWork.EdiSendDate;
            //// �d�c�h�捞��
            //ret.EdiTakeInDate = paymentDataWork.EdiTakeInDate;
            //// �e�L�X�g���o��
            //ret.TextExtraDate = paymentDataWork.TextExtraDate;
            //// �� 20070907 980081 a
            #endregion
            //ret.CreateDateTime = paymentDataWork.CreateDateTime;                      //�쐬����(�s�v)
            //ret.UpdateDateTime = paymentDataWork.UpdateDateTime;                      //�X�V����(�s�v)
            ret.EnterpriseCode = paymentSlpWork.EnterpriseCode;                      //��ƃR�[�h
            //ret.FileHeaderGuid = paymentDataWork.FileHeaderGuid;                      //GUID(�s�v)
            ret.UpdEmployeeCode = paymentAgentCode;                                  //�X�V�]�ƈ��R�[�h(�p�����[�^���g�p)
            ret.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;                      //�X�V�A�Z���u��ID1
            ret.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;                      //�X�V�A�Z���u��ID2
            ret.LogicalDeleteCode = 0;                                               //�_���폜�敪(0�Œ�)
            ret.DebitNoteDiv = 1;                                                    //�ԓ`�敪(1�Œ�)
            ret.PaymentSlipNo = 0;                                                   //�x���`�[�ԍ�(0�Œ�)
            ret.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;                      //�d���`�[�ԍ�
            ret.SupplierCd = paymentSlpWork.SupplierCd;                          //���Ӑ�R�[�h
            ret.SupplierNm1 = paymentSlpWork.SupplierNm1;                          //���Ӑ於��
            ret.SupplierNm2 = paymentSlpWork.SupplierNm2;                        //���Ӑ於��2
            ret.SupplierSnm = paymentSlpWork.SupplierSnm;                            //���Ӑ旪��
            ret.PayeeCode = paymentSlpWork.PayeeCode;                                //�x����R�[�h
            ret.PayeeName = paymentSlpWork.PayeeName;                                //�x���於��
            ret.PayeeName2 = paymentSlpWork.PayeeName2;                              //�x���於��2
            ret.PayeeSnm = paymentSlpWork.PayeeSnm;                                  //�x���旪��
            ret.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;            //�x�����͋��_�R�[�h
            ret.AddUpSecCode = paymentSlpWork.AddUpSecCode;                          //�v�㋒�_�R�[�h
            ret.UpdateSecCd = updateSecCd;                                           //�X�V���_�R�[�h(�p�����[�^���g�p)
            ret.SubSectionCode = paymentSlpWork.SubSectionCode;                      //����R�[�h
            ret.MinSectionCode = paymentSlpWork.MinSectionCode;                      //�ۃR�[�h
            // �� 2008.03.14 980081 c
            //ret.PaymentDate = addUpADate;                                            //�x�����t(�p�����[�^���g�p)
            ret.PaymentDate = DateTime.Now;
            // �� 2008.03.14 980081 c
            ret.AddUpADate = addUpADate;                                             //�v����t(�p�����[�^���g�p)
            ret.PaymentMoneyKindCode = paymentSlpWork.PaymentMoneyKindCode;          //�x������R�[�h
            ret.PaymentMoneyKindName = paymentSlpWork.PaymentMoneyKindName;          //�x�����햼��
            ret.PaymentMoneyKindDiv = paymentSlpWork.PaymentMoneyKindDiv;            //�x������敪
            ret.PaymentTotal = -paymentSlpWork.PaymentTotal;                         //�x���v(�������])
            ret.Payment = -paymentSlpWork.Payment;                                   //�x�����z(�������])
            ret.FeePayment = -paymentSlpWork.FeePayment;                             //�萔���x���z(�������])
            ret.DiscountPayment = -paymentSlpWork.DiscountPayment;                   //�l���x���z(�������])
            ret.RebatePayment = -paymentSlpWork.RebatePayment;                       //���x�[�g�x���z(�������])
            ret.AutoPayment = paymentSlpWork.AutoPayment;                            //�����x���敪
            ret.CreditOrLoanCd = paymentSlpWork.CreditOrLoanCd;                      //�N���W�b�g�^���[���敪
            ret.CreditCompanyCode = paymentSlpWork.CreditCompanyCode;                //�N���W�b�g��ЃR�[�h
            ret.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;                  //��`�U�o��
            ret.DraftPayTimeLimit = paymentSlpWork.DraftPayTimeLimit;                //��`�x������
            ret.DraftKind = paymentSlpWork.DraftKind;                                //��`���
            ret.DraftKindName = paymentSlpWork.DraftKindName;                        //��`��ޖ���
            ret.DraftDivide = paymentSlpWork.DraftDivide;                            //��`�敪
            ret.DraftDivideName = paymentSlpWork.DraftDivideName;                    //��`�敪����
            ret.DraftNo = paymentSlpWork.DraftNo;                                    //��`�ԍ�
            ret.DebitNoteLinkPayNo = paymentSlpWork.PaymentSlipNo;                   //�ԍ��x���A���ԍ�(���`�̓`�[�ԍ����Z�b�g)
            ret.PaymentAgentCode = paymentAgentCode;                                 //�x���S���҃R�[�h(�p�����[�^���g�p)
            ret.PaymentAgentName = paymentAgentName;                                 //�x���S���Җ���(�p�����[�^���g�p)
            ret.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;            //�x�����͎҃R�[�h
            ret.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;            //�x�����͎Җ���
            ret.Outline = paymentSlpWork.Outline;                                    //�`�[�E�v
            ret.BankCode = paymentSlpWork.BankCode;                                  //��s�R�[�h
            ret.BankName = paymentSlpWork.BankName;                                  //��s����
            //ret.EdiSendDate = paymentDataWork.EdiSendDate;                            //�d�c�h���M��(�s�v)
            //ret.EdiTakeInDate = paymentDataWork.EdiTakeInDate;                        //�d�c�h�捞��(�s�v)
            // �� 2007.11.02 980081 c
            # endif
            # endregion

            //--- ADD 2008/04/24 M.Kubota --->>>
            ret.EnterpriseCode = paymentSlpWork.EnterpriseCode;            // ��ƃR�[�h
            ret.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
            ret.DebitNoteDiv = 1;                                          // �ԓ`�敪 (1:�ԓ`)
            ret.PaymentSlipNo = 0;                                         // �x���`�[�ԍ�
            ret.SupplierFormal = paymentSlpWork.SupplierFormal;            // �d���`��
            ret.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;            // �d���`�[�ԍ�
            ret.SupplierCd = paymentSlpWork.SupplierCd;                    // �d����R�[�h
            ret.SupplierNm1 = paymentSlpWork.SupplierNm1;                  // �d���於1
            ret.SupplierNm2 = paymentSlpWork.SupplierNm2;                  // �d���於2
            ret.SupplierSnm = paymentSlpWork.SupplierSnm;                  // �d���旪��
            ret.PayeeCode = paymentSlpWork.PayeeCode;                      // �x����R�[�h
            ret.PayeeName = paymentSlpWork.PayeeName;                      // �x���於��
            ret.PayeeName2 = paymentSlpWork.PayeeName2;                    // �x���於��2
            ret.PayeeSnm = paymentSlpWork.PayeeSnm;                        // �x���旪��
            ret.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;  // �x�����͋��_�R�[�h
            ret.AddUpSecCode = paymentSlpWork.AddUpSecCode;                // �v�㋒�_�R�[�h
            ret.UpdateSecCd = paymentSlpWork.UpdateSecCd;                  // �X�V���_�R�[�h
            ret.SubSectionCode = paymentSlpWork.SubSectionCode;            // ����R�[�h
            ret.InputDay = DateTime.Now;                                  // ���͓��t  //ADD 2009/03/25
            ret.PaymentDate = DateTime.Now;                               // �x�����t
            ret.AddUpADate = addUpADate;                                   // �v����t
            ret.PaymentTotal = -paymentSlpWork.PaymentTotal;               // �x���v
            ret.Payment = -paymentSlpWork.Payment;                         // �x�����z
            ret.FeePayment = -paymentSlpWork.FeePayment;                   // �萔���x���z
            ret.DiscountPayment = -paymentSlpWork.DiscountPayment;         // �l���x���z
            ret.AutoPayment = paymentSlpWork.AutoPayment;                  // �����x���敪
            ret.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;        // ��`�U�o��
            ret.DraftKind = paymentSlpWork.DraftKind;                      // ��`���
            ret.DraftKindName = paymentSlpWork.DraftKindName;              // ��`��ޖ���
            ret.DraftDivide = paymentSlpWork.DraftDivide;                  // ��`�敪
            ret.DraftDivideName = paymentSlpWork.DraftDivideName;          // ��`�敪����
            ret.DraftNo = paymentSlpWork.DraftNo;                          // ��`�ԍ�
            ret.DebitNoteLinkPayNo = paymentSlpWork.PaymentSlipNo;         // �ԍ��x���A���ԍ�
            ret.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;        // �x���S���҃R�[�h
            ret.PaymentAgentName = paymentSlpWork.PaymentAgentName;        // �x���S���Җ���
            ret.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;  // �x�����͎҃R�[�h
            ret.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;  // �x�����͎Җ���
            ret.Outline = paymentSlpWork.Outline;                          // �`�[�E�v
            ret.BankCode = paymentSlpWork.BankCode;                        // ��s�R�[�h
            ret.BankName = paymentSlpWork.BankName;                        // ��s����
            //--- ADD 2008/04/24 M.Kubota ---<<<

            return ret;
        }

        private PaymentDtlWork[] CreateRedPaymentDtlProc(int redPaymentSlipNo, PaymentDtlWork[] paymentDtlArray)
        {
            ArrayList redDtlList = new ArrayList();

            foreach(PaymentDtlWork dtl in paymentDtlArray)
            {
                PaymentDtlWork redDtl = new PaymentDtlWork();
                redDtl.CreateDateTime = dtl.CreateDateTime;        // �쐬����
                redDtl.UpdateDateTime = dtl.UpdateDateTime;        // �X�V����
                redDtl.EnterpriseCode = dtl.EnterpriseCode;        // ��ƃR�[�h
                redDtl.FileHeaderGuid = dtl.FileHeaderGuid;        // GUID
                redDtl.UpdEmployeeCode = dtl.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
                redDtl.UpdAssemblyId1 = dtl.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
                redDtl.UpdAssemblyId2 = dtl.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
                redDtl.LogicalDeleteCode = dtl.LogicalDeleteCode;  // �_���폜�敪
                redDtl.SupplierFormal = dtl.SupplierFormal;        // �d���`��
                redDtl.PaymentSlipNo = dtl.PaymentSlipNo;          // �x���`�[�ԍ�
                redDtl.PaymentRowNo = dtl.PaymentRowNo;            // �x���s�ԍ�
                redDtl.MoneyKindCode = dtl.MoneyKindCode;          // ����R�[�h
                redDtl.MoneyKindName = dtl.MoneyKindName;          // ���햼��
                redDtl.MoneyKindDiv = dtl.MoneyKindDiv;            // ����敪
                redDtl.Payment = dtl.Payment * -1;                 // �x�����z
                redDtl.ValidityTerm = dtl.ValidityTerm;            // �L������

                redDtlList.Add(redDtl);
            }

            return (PaymentDtlWork[])redDtlList.ToArray(typeof(PaymentDtlWork));
        }

        # endregion

        # region --- DEL 2008/04/24 M.Kubota --- [�R�����g�A�E�g����Ă���\�[�X]

# if false
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x���`�[�ԍ��ő�l��߂��܂�
		/// </summary>
		/// <param name="DepositSlipNo">�x���`�[�ԍ�</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍ő�x���`�[�ԍ���߂��܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.03</br>
		/// </remarks>
        private int GetMaxDepositSlipNoProc(out int DepositSlipNo,string EnterpriseCode, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int wkDepositSlipNo = 0;
			SqlDataReader myReader = null;

			try 
			{			
                // �� 20061222 18322 c �����}�X�^���Q�Ƃ���̂͊ԈႢ�A��ŗv�m�F
                //                     �x���}�X�^�͖����̂ŁA�Ƃ肠�����x���`�[�}�X�^�ɂ���
				//Select�R�}���h�̐���
                //using(SqlCommand sqlCommand = new SqlCommand("SELECT MAX(DEPOSITSLIPNORF) DEPOSITSLIPNORF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction))

                string sqlCmd = "SELECT MAX(PAYMENTSLIPNORF) DEPOSITSLIPNORF"
                              + " FROM PAYMENTSLPRF"
                              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                              ;

				using(SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection, sqlTransaction))
                // �� 20061222 18322 c
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						wkDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			DepositSlipNo = wkDepositSlipNo;

			return status;
        }

        #region ��������Ǎ������i�e�X�g�p�F���j�S�ăR�����g�A�E�g
        /*
		/// <summary>
		/// ��������Ǎ������i�e�X�g�p�F���j
		/// </summary>
		/// <param name="EnterpriseCode"></param>
		/// <param name="DepositSlipNo"></param>
		/// <param name="depsitMainWorkByte"></param>
		/// <param name="depositAlwWorkListByte"></param>
		/// <returns></returns>
		public int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DmdSalesWork[] DmdSalesWorkList = null;


			dmdSalesWorkListByte = null;

			try 
			{	
				//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL�ڑ�
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction();

				// �x���Ǎ��ݏ���
				status = ReadDmdSalesWorkRec(EnterpriseCode, ClaimCode, out DmdSalesWorkList, ref sqlConnection, ref sqlTransaction);

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			// XML�֕ϊ����A������̃o�C�i����
			dmdSalesWorkListByte = XmlByteSerializer.Serialize(DmdSalesWorkList);

			return status;
		}
        */
        #endregion

        #region ��������}�X�^�����擾���܂�(�e�X�g�p�����W�b�N) �S�ăR�����g�A�E�g
        /*
		/// <summary>
		/// ��������}�X�^�����擾���܂�(�e�X�g�p�����W�b�N)
		/// </summary>
		private int ReadDmdSalesWorkRec(string EnterpriseCode, int ClaimCode, out DmdSalesWork[] DmdSalesWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	
			SqlDataReader myReader = null;

			ArrayList dmdSalesWorkArrayList = new ArrayList();

			try 
			{			
				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SLIPNORF, DEBITNOTEDIVRF, CUSTOMERCODERF, CARMNGNORF, CLAIMCODERF, ADDUPADATERF, ACCEPTANORDERSALESRF, ACPTANODRDISCOUNTTTLRF, ACCEPTANORDERCONSTAXRF, TOTALVARIOUSCOSTRF, VARCSTTAXTOTALRF, VARCSTTAXFREETOTALRF, VARCST1RF, VARCST2RF, VARCST3RF, VARCST4RF, VARCST5RF, VARCST6RF, VARCST7RF, VARCST8RF, VARCST9RF, VARCST10RF, VARCST11RF, VARCST12RF, VARCST13RF, VARCST14RF, VARCST15RF, VARCST16RF, VARCST17RF, VARCST18RF, VARCST19RF, VARCST20RF, VARCSTDIV1RF, VARCSTDIV2RF, VARCSTDIV3RF, VARCSTDIV4RF, VARCSTDIV5RF, VARCSTDIV6RF, VARCSTDIV7RF, VARCSTDIV8RF, VARCSTDIV9RF, VARCSTDIV10RF, VARCSTDIV11RF, VARCSTDIV12RF, VARCSTDIV13RF, VARCSTDIV14RF, VARCSTDIV15RF, VARCSTDIV16RF, VARCSTDIV17RF, VARCSTDIV18RF, VARCSTDIV19RF, VARCSTDIV20RF, VARCSTCONSTAXRF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DATAINPUTSYSTEMRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, ACCEPTANORDERDATERF, CARDELIEXPECTEDDATERF, SALESEMPLOYEECDRF, SALESDIVRF, SALESNAMERF, DEBITNLNKACPTANODRRF, DEMANDPRORATACDRF, LASTRECONCILEDATERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MAKERNAMERF, MODELNAMERF, DEMANDABLESALESNOTERF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, CREDITSALESRF, CREDITALLOWANCERF, CREDITALWCBLNCERF, CORPORATEDIVCODERF, AACOUNTRF, MNYONDEPOALLOWANCERF, ACPTANODRSTATUSRF, LASTRECONCILEADDUPDTRF, CARINSPECTORGECDRF, GRADENAMERF "
						  +"FROM DMDSALESRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCLAIMCODE", sqlConnection, sqlTransaction))
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
					findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(ClaimCode);

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						DmdSalesWork dmdSalesWork = new DmdSalesWork();


        #region �N���X�֑��
						dmdSalesWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						dmdSalesWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						dmdSalesWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						dmdSalesWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						dmdSalesWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						dmdSalesWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						dmdSalesWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						dmdSalesWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						dmdSalesWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
						dmdSalesWork.SlipNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SLIPNORF"));
						dmdSalesWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
						dmdSalesWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
						dmdSalesWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARMNGNORF"));
						dmdSalesWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIMCODERF"));
						dmdSalesWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
						dmdSalesWork.AcceptAnOrderSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESRF"));
						dmdSalesWork.AcptAnOdrDiscountTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPTANODRDISCOUNTTTLRF"));
						dmdSalesWork.AcceptAnOrderConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERCONSTAXRF"));
						dmdSalesWork.TotalVariousCost = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("TOTALVARIOUSCOSTRF"));
						dmdSalesWork.VarCstTaxTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXTOTALRF"));
						dmdSalesWork.VarCstTaxFreeTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXFREETOTALRF"));
						dmdSalesWork.VarCst1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST1RF"));
						dmdSalesWork.VarCst2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST2RF"));
						dmdSalesWork.VarCst3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST3RF"));
						dmdSalesWork.VarCst4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST4RF"));
						dmdSalesWork.VarCst5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST5RF"));
						dmdSalesWork.VarCst6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST6RF"));
						dmdSalesWork.VarCst7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST7RF"));
						dmdSalesWork.VarCst8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST8RF"));
						dmdSalesWork.VarCst9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST9RF"));
						dmdSalesWork.VarCst10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST10RF"));
						dmdSalesWork.VarCst11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST11RF"));
						dmdSalesWork.VarCst12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST12RF"));
						dmdSalesWork.VarCst13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST13RF"));
						dmdSalesWork.VarCst14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST14RF"));
						dmdSalesWork.VarCst15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST15RF"));
						dmdSalesWork.VarCst16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST16RF"));
						dmdSalesWork.VarCst17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST17RF"));
						dmdSalesWork.VarCst18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST18RF"));
						dmdSalesWork.VarCst19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST19RF"));
						dmdSalesWork.VarCst20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST20RF"));
						dmdSalesWork.VarCstDiv1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV1RF"));
						dmdSalesWork.VarCstDiv2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV2RF"));
						dmdSalesWork.VarCstDiv3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV3RF"));
						dmdSalesWork.VarCstDiv4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV4RF"));
						dmdSalesWork.VarCstDiv5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV5RF"));
						dmdSalesWork.VarCstDiv6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV6RF"));
						dmdSalesWork.VarCstDiv7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV7RF"));
						dmdSalesWork.VarCstDiv8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV8RF"));
						dmdSalesWork.VarCstDiv9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV9RF"));
						dmdSalesWork.VarCstDiv10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV10RF"));
						dmdSalesWork.VarCstDiv11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV11RF"));
						dmdSalesWork.VarCstDiv12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV12RF"));
						dmdSalesWork.VarCstDiv13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV13RF"));
						dmdSalesWork.VarCstDiv14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV14RF"));
						dmdSalesWork.VarCstDiv15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV15RF"));
						dmdSalesWork.VarCstDiv16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV16RF"));
						dmdSalesWork.VarCstDiv17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV17RF"));
						dmdSalesWork.VarCstDiv18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV18RF"));
						dmdSalesWork.VarCstDiv19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV19RF"));
						dmdSalesWork.VarCstDiv20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV20RF"));
						dmdSalesWork.VarCstConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTCONSTAXRF"));
						dmdSalesWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
						dmdSalesWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
						dmdSalesWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
						dmdSalesWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
						dmdSalesWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
						dmdSalesWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
						dmdSalesWork.AcceptAnOrderDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
						dmdSalesWork.CarDeliExpectedDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("CARDELIEXPECTEDDATERF"));
						dmdSalesWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
						dmdSalesWork.SalesDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SALESDIVRF"));
						dmdSalesWork.SalesName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESNAMERF"));
						dmdSalesWork.DebitNLnkAcptAnOdr = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
						dmdSalesWork.DemandProRataCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEMANDPRORATACDRF"));
						dmdSalesWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE1CODERF"));
						dmdSalesWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
						dmdSalesWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE2RF"));
						dmdSalesWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE3RF"));
						dmdSalesWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE4RF"));
						dmdSalesWork.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MAKERNAMERF"));
						dmdSalesWork.ModelName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELNAMERF"));
						dmdSalesWork.DemandableSalesNote = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDABLESALESNOTERF"));
						dmdSalesWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
						dmdSalesWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
						dmdSalesWork.CreditSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITSALESRF"));
						dmdSalesWork.CreditAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALLOWANCERF"));
						dmdSalesWork.CreditAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALWCBLNCERF"));
						dmdSalesWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
						dmdSalesWork.AaCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AACOUNTRF"));
						dmdSalesWork.MnyOnDepoAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCERF"));
						dmdSalesWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
						dmdSalesWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
						dmdSalesWork.CarInspectOrGeCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARINSPECTORGECDRF"));
						dmdSalesWork.GradeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GRADENAMERF"));
        #endregion

						dmdSalesWorkArrayList.Add(dmdSalesWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();
	
			DmdSalesWorkList =  (DmdSalesWork[])dmdSalesWorkArrayList.ToArray(typeof(DmdSalesWork));

			return status;
		}
        */
        #endregion

# endif

        # endregion

        # region [�`�F�b�N����]
        // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// �x���f�[�^�̑��M�ς݂̃`�F�b�N
        /// </summary>
        /// <param name="paymentSlpWork">�x�����[�N</param>
        /// <returns>true: �`�F�b�NOK�Afalse�F�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// <br>Update Note: 2012/02/06 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28288 ���M�σf�[�^�C������̑Ή�</br>
        /// <br>Update Note: 2012/08/10  �e�c ���V</br>
        /// <br>           : ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�</br>
        /// </remarks>
        private bool CheckPaymentSlpSending(PaymentSlpWork paymentSlpWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �`�F�b�N���s�����ǂ��������L�̂悤�ɔ��f����(�A�`�B)
            // �A���_�Ǘ�����M�Ώۃ}�X�^�Ɏx���f�[�^�̋��_�Ǘ����M�敪���u1:���M����v----------->
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
            secMngSndRcvWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;
            object outSecMngSndRcvList = null;

            // ���_�Ǘ�����M�Ώۃ}�X�^�����擾
            status = this.ScMngSndRcvDB.Search(out outSecMngSndRcvList, secMngSndRcvWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSndRcvList = outSecMngSndRcvList as ArrayList;

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSndRcvList || secMngSndRcvList.Count == 0)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;

            bool isHaveObj = false;
            foreach (SecMngSndRcvWork resultSecMngSndRcvWork in secMngSndRcvList)
            {
                if (string.Equals("PaymentSlpRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase)
                    && resultSecMngSndRcvWork.SecMngSendDiv == 1
                    && resultSecMngSndRcvWork.LogicalDeleteCode == 0)
                {
                    isHaveObj = true;
                    break;
                }
            }
            if (!isHaveObj)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;
            // �A���_�Ǘ�����M�Ώۃ}�X�^�Ɏx���f�[�^�̋��_�Ǘ����M�敪���u1:���M����v-----------<


            // �B���_�Ǘ��ݒ�}�X�^�ɉ��L�̏��ɓ����郌�R�[�h�����݂��� ------------------------>>
            // ��ʁ�0:�f�[�^
            // ��M�󋵁�0:���M
            // ���M�Ώۋ��_���X�V����x���f�[�^�̌v�㋒�_�R�[�h
            // ���M�σf�[�^�C���敪���C���s��
            object outSecMngSetList = null;
            SecMngSetWork paraSecMngSetWork = new SecMngSetWork();
            paraSecMngSetWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;

            // ���_�Ǘ��ݒ�}�X�^�����擾
            status = this.ScMngSetDB.Search(out outSecMngSetList, paraSecMngSetWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSetList = outSecMngSetList as ArrayList;


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSetList || secMngSetList.Count == 0)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;

            isHaveObj = false;
            string addUpSecCode = paymentSlpWork.AddUpSecCode;
            if (null != addUpSecCode)
                addUpSecCode = addUpSecCode.Trim();
            DateTime maxSyncExecDate = DateTime.MinValue; // ���_�Ǘ��ݒ�}�X�^�̑��M���s��
            int sndFinDataEdDiv = -1; //ADD by �����@2011/11/10
            foreach (SecMngSetWork resultSecMngSetWork in secMngSetList)
            {
                if (resultSecMngSetWork.Kind == 0 && resultSecMngSetWork.ReceiveCondition == 0
                    // ��ʁ�0:�f�[�^ && ��M�󋵁�0:���M
                    && resultSecMngSetWork.SectionCode.Trim() == addUpSecCode
                    // ���M�Ώۋ��_���X�V����x���f�[�^�̌v�㋒�_�R�[�h
                    && (resultSecMngSetWork.SndFinDataEdDiv == 1||resultSecMngSetWork.SndFinDataEdDiv == 2) //ADD by �����@2011/11/10
                    //&& resultSecMngSetWork.SndFinDataEdDiv == 1 //DEL by �����@2011/11/10
                    // ���M�σf�[�^�C���敪���C���s��
                    && resultSecMngSetWork.LogicalDeleteCode == 0
                    )
                {
                    isHaveObj = true;
                    if (resultSecMngSetWork.SyncExecDate.CompareTo(maxSyncExecDate) > 0)
                    //ADD by �����@2011/11/10 start---->>>>>>    
                    {
                        sndFinDataEdDiv = resultSecMngSetWork.SndFinDataEdDiv;
                    //ADD by �����@2011/11/10 end  ----<<<<<<   
                        maxSyncExecDate = resultSecMngSetWork.SyncExecDate;
                    }//ADD by �����@2011/11/10
                }
            }
            if (!isHaveObj)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;
            // �B���_�Ǘ��ݒ�}�X�^�ɉ��L�̏��ɓ����郌�R�[�h�����݂��� ------------------------<<


            // �`�F�b�N���� -------------------------------------->>>
            //ADD by �����@2011/11/10 start---->>>>>>
            if ((sndFinDataEdDiv==1&&paymentSlpWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)||
                //(sndFinDataEdDiv == 2 && paymentSlpWork.PaymentDate.CompareTo(maxSyncExecDate) <= 0)) // DEL 2011/12/15
                //(sndFinDataEdDiv == 2 && paymentSlpWork.PrePaymentDate.CompareTo(maxSyncExecDate) <= 0)) // ADD 2011/12/15 // DEL 2012/02/06 �c���� Redmine#28288
                //(sndFinDataEdDiv == 2 && paymentSlpWork.PrePaymentDate.CompareTo(maxSyncExecDate) <= 0 && paymentSlpWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)) // ADD 2012/02/06 �c���� Redmine#28288 DEL 2012/08/10 Y.Wakita
                (sndFinDataEdDiv == 2 && paymentSlpWork.PrePaymentDate.CompareTo(maxSyncExecDate) <= 0 && paymentSlpWork.UpdateDateTime.ToString("HHmmss").CompareTo(maxSyncExecDate.ToString("HHmmss")) <= 0)) // ADD 2012/08/10 Y.Wakita
            //ADD by �����@2011/11/10 end  ----<<<<<<
            //if (paymentSlpWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) //DEL by �����@2011/11/10
            {
                // �`�F�b�NNG
                // ���M�ς݂̃f�[�^���X�V�ł��Ȃ��A�G���[���b�Z�[�W�����O�ɏo��
                System.Text.StringBuilder errMessage = new System.Text.StringBuilder();
                errMessage.Append(NSDebug.GetExecutingMethodName(new StackFrame()));
                errMessage.Append(": ���M�ς݂̃f�[�^�ׁ̈A�X�V�ł��܂���B");
                base.WriteErrorLog(errMessage.ToString(), (int)ConstantManagement.DB_Status.ctDB_ERROR);
                return false;
            }
            else
            {
                // �`�F�b�NOK
                return true;
            }
            // �`�F�b�N���� --------------------------------------<<<
        }
        // ADD 2011/07/29 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
        # endregion
    }
}
