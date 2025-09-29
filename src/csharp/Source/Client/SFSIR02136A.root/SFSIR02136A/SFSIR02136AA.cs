using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �x���`�[�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �x���`�[�̃e�[�u���փA�N�Z�X���܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2006.05.23</br>
	/// <br></br>
	/// <br>Update Note : 2006.12.22 �ؑ� ����</br>
	/// <br>              �g��.NS�p�ɐԓ`�̃C���^�[�t�F�[�X��ǉ�</br>
    /// <br>Update Note : 2010.04.27 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    /// <br>Update Note : 2011.07.30 qijh</br>
    /// <br>              SCM�Ή� - ���_�Ǘ�(10704767-00)
    /// <br>              ���M�ς݂̃`�F�b�N���b�Z�[�W���o�͂ł���悤�ɉ��C</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note : 2013.02.21 �e�c ���V</br>
    /// <br>              �x���`�[�폜���A��`�f�[�^�R�t�������Ή�
    /// <br></br>
	/// </remarks>
	public class PaymentSlpAcs
	{
		#region PrivateMember
        
        // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// ���M�σ`�F�b�N���s�̃X�e�[�^�X
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;

        /// <summary>
        /// ���M�σ`�F�b�N���s�̃G���[���b�Z�[�W
        /// </summary>
        private const string CHK_SEND_ERR_MSG = "���M�ς݂̃f�[�^�ׁ̈A�X�V�ł��܂���B";
        // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

		// �G���[���b�Z�[�W
		private string _errorMessage;
		#endregion

		#region Interface
		// �����[�g�C���^�[�t�F�[�X
		IPaymentSlpDB _iPaymentSlpDB;
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PaymentSlpAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				_iPaymentSlpDB = (IPaymentSlpDB)MediationPaymentSlpDB.GetPaymentSlpDB();
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				_iPaymentSlpDB = null;
			}
		}
		#endregion

		#region PublicMethod
        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �x���`�[�o�^����
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int Write(ref PaymentSlp paymentSlp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            PaymentDataWork paymentDataWork = CopyToPaymentDataWorkFromPaymentSlp(paymentSlp);
            
            // XML�֕ϊ�
            byte[] parabyte = XmlByteSerializer.Serialize(paymentDataWork);
           
            try
            {
                // �����f�[�^��������
                status = this._iPaymentSlpDB.Write(ref parabyte);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XML�̓ǂݍ���
                            paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            _errorMessage = "�x���ԍ���ʒ[�����̔Ԃ��Ă��܂��B\r\n���΂炭���҂��ɂȂ��čēx���s���Ă��������B";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
                    default:
                        {
                            _errorMessage = "�x���`�[�̕ۑ������Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̕ۑ������ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }
        // --------------- ADD START 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        /// <summary>
        /// �x���`�[�o�^����(�x����`�f�[�^���A���)
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <param name="payDraftData">�x����`�f�[�^</param>
        /// <param name="payDraftDataDel">�x����`�f�[�^(�폜�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̓o�^�E�X�V�E�폜���s���܂��B</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        public int WriteWithPayDraft(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            PaymentDataWork paymentDataWork = CopyToPaymentDataWorkFromPaymentSlp(paymentSlp);
            PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);
            PayDraftDataWork payDraftDataWorkDel =new PayDraftDataWork();
            if (payDraftDataDel != null)
                payDraftDataWorkDel = CopyToPayDraftDataWorkFromPayDraftData(payDraftDataDel);
            else
                payDraftDataWorkDel = null;

            // XML�֕ϊ�
            byte[] parabyte = XmlByteSerializer.Serialize(paymentDataWork);
            byte[] parabyteUpd = XmlByteSerializer.Serialize(payDraftDataWork);
            byte[] parabyteDel;
            if(payDraftDataWorkDel != null)
                parabyteDel = XmlByteSerializer.Serialize(payDraftDataWorkDel);
            else
                parabyteDel = null;

            try
            {
                // �����f�[�^��������
                status = this._iPaymentSlpDB.WriteWithPayDraft(ref parabyte, parabyteUpd, parabyteDel);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XML�̓ǂݍ���
                            paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            _errorMessage = "�x���ԍ���ʒ[�����̔Ԃ��Ă��܂��B\r\n���΂炭���҂��ɂȂ��čēx���s���Ă��������B";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "�x���`�[�̕ۑ������Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̕ۑ������ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }
        // --------------- ADD END 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// �x���`�[�o�^����(�x���E����`�f�[�^���A���)
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <param name="payDraftData">�x����`�f�[�^</param>
        /// <param name="payDraftDataDel">�x����`�f�[�^(�폜�p)</param>
        /// <param name="rcvDraftData">����`�f�[�^</param>
        /// <param name="rcvDraftDataDel">����`�f�[�^(�폜�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̓o�^�E�X�V�E�폜���s���܂��B</br>
        /// <br>Programmer	: �{�{</br>
        /// <br>Date		: 2012/10/18</br>
        /// </remarks>
        public int WriteWithDraft(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel
                                                           , RcvDraftData rcvDraftData, RcvDraftData rcvDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            PaymentDataWork paymentDataWork = CopyToPaymentDataWorkFromPaymentSlp(paymentSlp);
            PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);
            PayDraftDataWork payDraftDataWorkDel = new PayDraftDataWork();
            if (payDraftDataDel != null)
                payDraftDataWorkDel = CopyToPayDraftDataWorkFromPayDraftData(payDraftDataDel);
            else
                payDraftDataWorkDel = null;

            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            RcvDraftDataWork rcvDraftDataWorkDel = new RcvDraftDataWork();
            if (rcvDraftData != null)
                rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);
            else
                rcvDraftDataWork = null;
            if (rcvDraftDataDel != null)
                rcvDraftDataWorkDel = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataDel);
            else
                rcvDraftDataWorkDel = null;

            // XML�֕ϊ�
            byte[] parabyte = XmlByteSerializer.Serialize(paymentDataWork);
            byte[] parabytePayUpd = XmlByteSerializer.Serialize(payDraftDataWork);
            byte[] parabytePayDel;
            if (payDraftDataWorkDel != null)
                parabytePayDel = XmlByteSerializer.Serialize(payDraftDataWorkDel);
            else
                parabytePayDel = null;
            byte[] parabyteRcvUpd;
            if (rcvDraftDataWork != null)
                parabyteRcvUpd = XmlByteSerializer.Serialize(rcvDraftDataWork);
            else
                parabyteRcvUpd = null;
            byte[] parabyteRcvDel;
            if (rcvDraftDataWorkDel != null)
                parabyteRcvDel = XmlByteSerializer.Serialize(rcvDraftDataWorkDel);
            else
                parabyteRcvDel = null;

            try
            {
                // �x���f�[�^��������
                status = this._iPaymentSlpDB.WriteWithDraft(ref parabyte, parabytePayUpd, parabytePayDel, parabyteRcvUpd, parabyteRcvDel);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XML�̓ǂݍ���
                            paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
                            break;
                        }
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                        {
                            _errorMessage = "�x���ԍ���ʒ[�����̔Ԃ��Ă��܂��B\r\n���΂炭���҂��ɂȂ��čēx���s���Ă��������B";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "�x���`�[�̕ۑ������Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̕ۑ������ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        /// <summary>
        /// �x���`�[�Ǎ�����
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�}�X�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̓Ǎ����s���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int Read(out PaymentSlp paymentSlp, string enterpriseCode, int paymentSlipNo)
        {
            int status = 0;
            _errorMessage = "";
            paymentSlp = null;

            try
            {
                byte[] parabyte;
                status = _iPaymentSlpDB.Read(enterpriseCode, paymentSlipNo, out parabyte);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // XML�̓ǂݍ���
                            PaymentDataWork paymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentDataWork));
                            // �N���X�������o�R�s�[
                            paymentSlp = CopyToPaymentSlpFromPaymentDataWork(paymentDataWork);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�w��x���`�[�͑��݂��܂���B";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "�x���`�[�̓Ǎ������Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̓Ǎ��ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �x���`�[�폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="payDraftData">�x����`���</param>
        /// <param name="retPaymentDataWork">�����E�ςݍ��`</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �x���`�[�̍폜���s���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int Delete(string enterpriseCode, int paymentSlipNo, out PaymentDataWork retPaymentDataWork)
        public int Delete(string enterpriseCode, int paymentSlipNo, PayDraftData payDraftData, out PaymentDataWork retPaymentDataWork)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
        {
            retPaymentDataWork = null;

            int status = 0;
            _errorMessage = "";

            try
            {
                // --- ADD 2013/02/21 Y.Wakita ---------->>>>>
                PayDraftDataWork payDraftDataWork = new PayDraftDataWork();
                byte[] parabytePayUpd;
                if (payDraftData != null)
                {
                    payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);
                    // XML�֕ϊ�
                    parabytePayUpd = XmlByteSerializer.Serialize(payDraftDataWork);
                }
                else
                {
                    payDraftDataWork = null;
                    parabytePayUpd = null;
                }
                // --- ADD 2013/02/21 Y.Wakita ----------<<<<<
                byte[] PaymentDataWorkByte;

                // ADD 2009/05/01 �R�����g�ǋL
                // �����폜���\�b�h���g�p���Ă��邪�A�����[�g���Ř_���폜�����ɕύX���Ă���
                // �x���`�[�폜
                // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
                //status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo, out PaymentDataWorkByte);
                status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo, parabytePayUpd, out PaymentDataWorkByte);
                // --- UPD 2013/02/21 Y.Wakita ----------<<<<<

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (PaymentDataWorkByte != null)
                            {
                                // �����E�ςݍ��`��Ԃ��B
                                retPaymentDataWork = (PaymentDataWork)XmlByteSerializer.Deserialize(PaymentDataWorkByte, typeof(PaymentDataWork));
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
                    default:
                        {
                            _errorMessage = "�x���`�[�̍폜�����Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̍폜�����ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �x���`�[�ԓ`�쐬����
        /// </summary>
        /// <param name="mode">�ԓ`�쐬���[�h 0:�ԓ����쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="paymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="paymentAgentNm">�x���S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�(�ԓ`���s�����`)</param>
        /// <param name="retPaymentDataWorkList">�x���`�[�}�X�^(�X�V����)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���`�[�ԍ��̐Ԏx���쐬�������s���܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        public int RedCreate(int mode, string enterpriseCode, string updateSecCd, string paymentAgentCode, string paymentAgentNm, DateTime addUpADate, int paymentSlipNo, out ArrayList retPaymentDataWorkList)
        {
            int status = 0;
            _errorMessage = "";

            retPaymentDataWorkList = new ArrayList();
            retPaymentDataWorkList.Clear();

            try
            {
                object retObj;
                status = _iPaymentSlpDB.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  addUpADate,
                                                  paymentSlipNo,
                                                  out retObj);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList wkList = retObj as ArrayList;
                            if (wkList != null)
                            {
                                for (int i = 0; i != wkList.Count; i++)
                                {
                                    PaymentDataWork work = (PaymentDataWork)wkList[i];
                                    retPaymentDataWorkList.Add(work);
                                }
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    case STATUS_CHK_SEND_ERR:
                        {
                            _errorMessage = CHK_SEND_ERR_MSG;
                            break;
                        }
                    // ADD 2011/07/30 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "�x���`�[�̐ԓ`�����Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̐ԓ`�����ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }


        // --------------- ADD START 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�x����`�f�[�^�}�X�^�N���X�ˎx����`�f�[�^�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="payDraftData">�x����`�f�[�^�}�X�^�N���X</param>
        /// <returns>�x����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^�N���X����x����`�f�[�^�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private PayDraftDataWork CopyToPayDraftDataWorkFromPayDraftData(PayDraftData payDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.CreateDateTime = payDraftData.CreateDateTime;
            payDraftDataWork.UpdateDateTime = payDraftData.UpdateDateTime;
            payDraftDataWork.EnterpriseCode = payDraftData.EnterpriseCode;
            payDraftDataWork.FileHeaderGuid = payDraftData.FileHeaderGuid;
            payDraftDataWork.UpdEmployeeCode = payDraftData.UpdEmployeeCode;
            payDraftDataWork.UpdAssemblyId1 = payDraftData.UpdAssemblyId1;
            payDraftDataWork.UpdAssemblyId2 = payDraftData.UpdAssemblyId2;
            payDraftDataWork.LogicalDeleteCode = payDraftData.LogicalDeleteCode;
            payDraftDataWork.PayDraftNo = payDraftData.PayDraftNo;
            payDraftDataWork.DraftKindCd = payDraftData.DraftKindCd;
            payDraftDataWork.DraftDivide = payDraftData.DraftDivide;
            payDraftDataWork.Payment = payDraftData.Payment;
            payDraftDataWork.BankAndBranchCd = payDraftData.BankAndBranchCd;
            payDraftDataWork.BankAndBranchNm = payDraftData.BankAndBranchNm;
            payDraftDataWork.SectionCode = payDraftData.SectionCode;
            payDraftDataWork.AddUpSecCode = payDraftData.AddUpSecCode;
            payDraftDataWork.SupplierCd = payDraftData.SupplierCd;
            payDraftDataWork.SupplierNm1 = payDraftData.SupplierNm1;
            payDraftDataWork.SupplierNm2 = payDraftData.SupplierNm2;
            payDraftDataWork.SupplierSnm = payDraftData.SupplierSnm;
            payDraftDataWork.ProcDate = payDraftData.ProcDate;
            payDraftDataWork.DraftDrawingDate = payDraftData.DraftDrawingDate;
            payDraftDataWork.ValidityTerm = payDraftData.ValidityTerm;
            payDraftDataWork.DraftStmntDate = payDraftData.DraftStmntDate;
            payDraftDataWork.Outline1 = payDraftData.Outline1;
            payDraftDataWork.Outline2 = payDraftData.Outline2;
            payDraftDataWork.SupplierFormal = payDraftData.SupplierFormal;
            payDraftDataWork.PaymentSlipNo = payDraftData.PaymentSlipNo;
            payDraftDataWork.PaymentRowNo = payDraftData.PaymentRowNo;
            payDraftDataWork.PaymentDate = payDraftData.PaymentDate;

            return payDraftDataWork;
        }
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i����`�f�[�^�}�X�^�N���X�ˎ���`�f�[�^�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="rcvDraftData">����`�f�[�^�}�X�^�N���X</param>
        /// <returns>����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^�N���X�������`�f�[�^�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2012/10/18</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromRcvDraftData(RcvDraftData rcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = rcvDraftData.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = rcvDraftData.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = rcvDraftData.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = rcvDraftData.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = rcvDraftData.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = rcvDraftData.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = rcvDraftData.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = rcvDraftData.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = rcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = rcvDraftData.DraftKindCd;
            rcvDraftDataWork.DraftDivide = rcvDraftData.DraftDivide;
            rcvDraftDataWork.Deposit = rcvDraftData.Deposit;
            rcvDraftDataWork.BankAndBranchCd = rcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = rcvDraftData.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = rcvDraftData.SectionCode;
            rcvDraftDataWork.AddUpSecCode = rcvDraftData.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = rcvDraftData.CustomerCode;
            rcvDraftDataWork.CustomerName = rcvDraftData.CustomerName;
            rcvDraftDataWork.CustomerName2 = rcvDraftData.CustomerName2;
            rcvDraftDataWork.CustomerSnm = rcvDraftData.CustomerSnm;
            rcvDraftDataWork.ProcDate = rcvDraftData.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = rcvDraftData.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = rcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = rcvDraftData.DraftStmntDate;
            rcvDraftDataWork.Outline1 = rcvDraftData.Outline1;
            rcvDraftDataWork.Outline2 = rcvDraftData.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = rcvDraftData.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = rcvDraftData.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = rcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositDate = rcvDraftData.DepositDate;
            
            return rcvDraftDataWork;
        }
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        // --------------- ADD END 2010.04.27 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="paymentSlp">�x���`�[�N���X</param>
        /// <returns>�x���`�[���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/08</br>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        private PaymentDataWork CopyToPaymentDataWorkFromPaymentSlp(PaymentSlp paymentSlp)
        {
            PaymentDataWork paymentDataWork = new PaymentDataWork();

            paymentDataWork.CreateDateTime = paymentSlp.CreateDateTime;              // �쐬���t
            paymentDataWork.UpdateDateTime = paymentSlp.UpdateDateTime;              // �X�V���t
            paymentDataWork.EnterpriseCode = paymentSlp.EnterpriseCode;              // ��ƃR�[�h
            paymentDataWork.FileHeaderGuid = paymentSlp.FileHeaderGuid;              // GUID
            paymentDataWork.UpdEmployeeCode = paymentSlp.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            paymentDataWork.UpdAssemblyId1 = paymentSlp.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            paymentDataWork.UpdAssemblyId2 = paymentSlp.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            paymentDataWork.LogicalDeleteCode = paymentSlp.LogicalDeleteCode;        // �_���폜�敪
            paymentDataWork.DebitNoteDiv = paymentSlp.DebitNoteDiv;                  // �ԓ`�敪
            paymentDataWork.PaymentSlipNo = paymentSlp.PaymentSlipNo;                // �x���`�[�ԍ�
            paymentDataWork.SupplierCd = paymentSlp.SupplierCd;                      // �d����R�[�h
            paymentDataWork.SupplierNm1 = paymentSlp.SupplierNm1;                    // �d���於1
            paymentDataWork.SupplierNm2 = paymentSlp.SupplierNm2;                    // �d���於2
            paymentDataWork.SupplierSnm = paymentSlp.SupplierSnm;                    // �d���旪��
            paymentDataWork.PayeeCode = paymentSlp.PayeeCode;                        // �x����R�[�h
            paymentDataWork.PayeeName = paymentSlp.PayeeName;                        // �x���於��
            paymentDataWork.PayeeName2 = paymentSlp.PayeeName2;                      // �x���於��2
            paymentDataWork.PayeeSnm = paymentSlp.PayeeSnm;                          // �x���旪��
            paymentDataWork.PaymentInpSectionCd = paymentSlp.PaymentInpSectionCd;    // �x�����͋��_�R�[�h
            paymentDataWork.SubSectionCode = paymentSlp.SubSectionCode;
            paymentDataWork.AddUpSecCode = paymentSlp.AddUpSecCode;                  // �v�㋒�_�R�[�h
            paymentDataWork.UpdateSecCd = paymentSlp.UpdateSecCd;                    // �X�V���_�R�[�h
            paymentDataWork.PaymentDate = paymentSlp.PaymentDate;                    // �x�����t
            paymentDataWork.PrePaymentDate = paymentSlp.PrePaymentDate;              // �O��x�����t // ADD 2011/12/15
            paymentDataWork.AddUpADate = paymentSlp.AddUpADate;                      // �v����t
            paymentDataWork.PaymentTotal = paymentSlp.PaymentTotal;                  // �x���v
            paymentDataWork.Payment = paymentSlp.Payment;                            // �x�����z
            paymentDataWork.FeePayment = paymentSlp.FeePayment;                      // �萔���x���z
            paymentDataWork.DiscountPayment = paymentSlp.DiscountPayment;            // �l���x���z
            paymentDataWork.AutoPayment = paymentSlp.AutoPayment;                    // �����x���敪
            paymentDataWork.DraftDrawingDate = paymentSlp.DraftDrawingDate;          // ��`�U�o��
            paymentDataWork.DebitNoteLinkPayNo = paymentSlp.DebitNoteLinkPayNo;      // �ԍ��x���A���ԍ�
            paymentDataWork.PaymentAgentCode = paymentSlp.PaymentAgentCode;          // �x���S���҃R�[�h
            paymentDataWork.PaymentAgentName = paymentSlp.PaymentAgentName;          // �x���S���Җ���
            paymentDataWork.PaymentInputAgentCd = paymentSlp.PaymentInputAgentCd;
            paymentDataWork.PaymentInputAgentNm = paymentSlp.PaymentInputAgentNm;
            paymentDataWork.Outline = paymentSlp.Outline;                            // �`�[�E�v
            paymentDataWork.DraftKind = paymentSlp.DraftKind;                        // ��`���
            paymentDataWork.DraftKindName = paymentSlp.DraftKindName;                // ��`��ޖ���
            paymentDataWork.DraftDivide = paymentSlp.DraftDivide;                    // ��`�敪
            paymentDataWork.DraftDivideName = paymentSlp.DraftDivideName;            // ��`�敪����
            paymentDataWork.DraftNo = paymentSlp.DraftNo;                            // ��`�ԍ�
            paymentDataWork.BankCode = paymentSlp.BankCode;                          // ��s�R�[�h
            paymentDataWork.BankName = paymentSlp.BankName;                          // ��s����
            paymentDataWork.PaymentRowNo1 = paymentSlp.PaymentRowNoDtl[0];
            paymentDataWork.PaymentRowNo2 = paymentSlp.PaymentRowNoDtl[1];
            paymentDataWork.PaymentRowNo3 = paymentSlp.PaymentRowNoDtl[2];
            paymentDataWork.PaymentRowNo4 = paymentSlp.PaymentRowNoDtl[3];
            paymentDataWork.PaymentRowNo5 = paymentSlp.PaymentRowNoDtl[4];
            paymentDataWork.PaymentRowNo6 = paymentSlp.PaymentRowNoDtl[5];
            paymentDataWork.PaymentRowNo7 = paymentSlp.PaymentRowNoDtl[6];
            paymentDataWork.PaymentRowNo8 = paymentSlp.PaymentRowNoDtl[7];
            paymentDataWork.PaymentRowNo9 = paymentSlp.PaymentRowNoDtl[8];
            paymentDataWork.PaymentRowNo10 = paymentSlp.PaymentRowNoDtl[9];
            paymentDataWork.MoneyKindCode1 = paymentSlp.MoneyKindCodeDtl[0];
            paymentDataWork.MoneyKindCode2 = paymentSlp.MoneyKindCodeDtl[1];
            paymentDataWork.MoneyKindCode3 = paymentSlp.MoneyKindCodeDtl[2];
            paymentDataWork.MoneyKindCode4 = paymentSlp.MoneyKindCodeDtl[3];
            paymentDataWork.MoneyKindCode5 = paymentSlp.MoneyKindCodeDtl[4];
            paymentDataWork.MoneyKindCode6 = paymentSlp.MoneyKindCodeDtl[5];
            paymentDataWork.MoneyKindCode7 = paymentSlp.MoneyKindCodeDtl[6];
            paymentDataWork.MoneyKindCode8 = paymentSlp.MoneyKindCodeDtl[7];
            paymentDataWork.MoneyKindCode9 = paymentSlp.MoneyKindCodeDtl[8];
            paymentDataWork.MoneyKindCode10 = paymentSlp.MoneyKindCodeDtl[9];
            paymentDataWork.MoneyKindName1 = paymentSlp.MoneyKindNameDtl[0];
            paymentDataWork.MoneyKindName2 = paymentSlp.MoneyKindNameDtl[1];
            paymentDataWork.MoneyKindName3 = paymentSlp.MoneyKindNameDtl[2];
            paymentDataWork.MoneyKindName4 = paymentSlp.MoneyKindNameDtl[3];
            paymentDataWork.MoneyKindName5 = paymentSlp.MoneyKindNameDtl[4];
            paymentDataWork.MoneyKindName6 = paymentSlp.MoneyKindNameDtl[5];
            paymentDataWork.MoneyKindName7 = paymentSlp.MoneyKindNameDtl[6];
            paymentDataWork.MoneyKindName8 = paymentSlp.MoneyKindNameDtl[7];
            paymentDataWork.MoneyKindName9 = paymentSlp.MoneyKindNameDtl[8];
            paymentDataWork.MoneyKindName10 = paymentSlp.MoneyKindNameDtl[9];
            paymentDataWork.MoneyKindDiv1 = paymentSlp.MoneyKindDivDtl[0];
            paymentDataWork.MoneyKindDiv2 = paymentSlp.MoneyKindDivDtl[1];
            paymentDataWork.MoneyKindDiv3 = paymentSlp.MoneyKindDivDtl[2];
            paymentDataWork.MoneyKindDiv4 = paymentSlp.MoneyKindDivDtl[3];
            paymentDataWork.MoneyKindDiv5 = paymentSlp.MoneyKindDivDtl[4];
            paymentDataWork.MoneyKindDiv6 = paymentSlp.MoneyKindDivDtl[5];
            paymentDataWork.MoneyKindDiv7 = paymentSlp.MoneyKindDivDtl[6];
            paymentDataWork.MoneyKindDiv8 = paymentSlp.MoneyKindDivDtl[7];
            paymentDataWork.MoneyKindDiv9 = paymentSlp.MoneyKindDivDtl[8];
            paymentDataWork.MoneyKindDiv10 = paymentSlp.MoneyKindDivDtl[9];
            paymentDataWork.Payment1 = paymentSlp.PaymentDtl[0];
            paymentDataWork.Payment2 = paymentSlp.PaymentDtl[1];
            paymentDataWork.Payment3 = paymentSlp.PaymentDtl[2];
            paymentDataWork.Payment4 = paymentSlp.PaymentDtl[3];
            paymentDataWork.Payment5 = paymentSlp.PaymentDtl[4];
            paymentDataWork.Payment6 = paymentSlp.PaymentDtl[5];
            paymentDataWork.Payment7 = paymentSlp.PaymentDtl[6];
            paymentDataWork.Payment8 = paymentSlp.PaymentDtl[7];
            paymentDataWork.Payment9 = paymentSlp.PaymentDtl[8];
            paymentDataWork.Payment10 = paymentSlp.PaymentDtl[9];
            paymentDataWork.ValidityTerm1 = paymentSlp.ValidityTermDtl[0];
            paymentDataWork.ValidityTerm2 = paymentSlp.ValidityTermDtl[1];
            paymentDataWork.ValidityTerm3 = paymentSlp.ValidityTermDtl[2];
            paymentDataWork.ValidityTerm4 = paymentSlp.ValidityTermDtl[3];
            paymentDataWork.ValidityTerm5 = paymentSlp.ValidityTermDtl[4];
            paymentDataWork.ValidityTerm6 = paymentSlp.ValidityTermDtl[5];
            paymentDataWork.ValidityTerm7 = paymentSlp.ValidityTermDtl[6];
            paymentDataWork.ValidityTerm8 = paymentSlp.ValidityTermDtl[7];
            paymentDataWork.ValidityTerm9 = paymentSlp.ValidityTermDtl[8];
            paymentDataWork.ValidityTerm10 = paymentSlp.ValidityTermDtl[9];
            paymentDataWork.InputDay = paymentSlp.InputDay;

            return paymentDataWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="paymentDataWork">�x���`�[���[�N�N���X</param>
        /// <returns>�x���`�[�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private PaymentSlp CopyToPaymentSlpFromPaymentDataWork(PaymentDataWork paymentDataWork)
        {
            PaymentSlp paymentSlp = new PaymentSlp();

            paymentSlp.CreateDateTime = paymentDataWork.CreateDateTime;              // �쐬���t
            paymentSlp.UpdateDateTime = paymentDataWork.UpdateDateTime;              // �X�V���t
            paymentSlp.EnterpriseCode = paymentDataWork.EnterpriseCode;              // ��ƃR�[�h
            paymentSlp.FileHeaderGuid = paymentDataWork.FileHeaderGuid;              // GUID
            paymentSlp.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            paymentSlp.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            paymentSlp.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            paymentSlp.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;        // �_���폜�敪
            paymentSlp.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                  // �ԓ`�敪
            paymentSlp.PaymentSlipNo = paymentDataWork.PaymentSlipNo;                // �x���`�[�ԍ�
            paymentSlp.SupplierCd = paymentDataWork.SupplierCd;                      // �d����R�[�h
            paymentSlp.SupplierNm1 = paymentDataWork.SupplierNm1;                    // �d���於1
            paymentSlp.SupplierNm2 = paymentDataWork.SupplierNm2;                    // �d���於2
            paymentSlp.SupplierSnm = paymentDataWork.SupplierSnm;                    // �d���旪��
            paymentSlp.PayeeCode = paymentDataWork.PayeeCode;                        // �x����R�[�h
            paymentSlp.PayeeName = paymentDataWork.PayeeName;                        // �x���於��
            paymentSlp.PayeeName2 = paymentDataWork.PayeeName2;                      // �x���於��2
            paymentSlp.PayeeSnm = paymentDataWork.PayeeSnm;                          // �x���旪��
            paymentSlp.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;    // �x�����͋��_�R�[�h
            paymentSlp.AddUpSecCode = paymentDataWork.AddUpSecCode;                  // �v�㋒�_�R�[�h
            paymentSlp.UpdateSecCd = paymentDataWork.UpdateSecCd;                    // �X�V���_�R�[�h
            paymentSlp.PaymentDate = paymentDataWork.PaymentDate;                    // �x�����t
            paymentSlp.AddUpADate = paymentDataWork.AddUpADate;                      // �v����t
            paymentSlp.PaymentTotal = paymentDataWork.PaymentTotal;                  // �x���v
            paymentSlp.Payment = paymentDataWork.Payment;                            // �x�����z
            paymentSlp.FeePayment = paymentDataWork.FeePayment;                      // �萔���x���z
            paymentSlp.DiscountPayment = paymentDataWork.DiscountPayment;            // �l���x���z
            paymentSlp.AutoPayment = paymentDataWork.AutoPayment;                    // �����x���敪
            paymentSlp.DraftDrawingDate = paymentDataWork.DraftDrawingDate;          // ��`�U�o��
            paymentSlp.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;      // �ԍ��x���A���ԍ�
            paymentSlp.PaymentAgentCode = paymentDataWork.PaymentAgentCode;          // �x���S���҃R�[�h
            paymentSlp.PaymentAgentName = paymentDataWork.PaymentAgentName;          // �x���S���Җ���
            paymentSlp.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;
            paymentSlp.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;
            paymentSlp.Outline = paymentDataWork.Outline;                            // �`�[�E�v
            paymentSlp.DraftKind = paymentDataWork.DraftKind;                        // ��`���
            paymentSlp.DraftKindName = paymentDataWork.DraftKindName;                // ��`��ޖ���
            paymentSlp.DraftDivide = paymentDataWork.DraftDivide;                    // ��`�敪
            paymentSlp.DraftDivideName = paymentDataWork.DraftDivideName;            // ��`�敪����
            paymentSlp.DraftNo = paymentDataWork.DraftNo;                            // ��`�ԍ�
            paymentSlp.BankCode = paymentDataWork.BankCode;                          // ��s�R�[�h
            paymentSlp.BankName = paymentDataWork.BankName;                          // ��s����
            paymentSlp.PaymentRowNoDtl = new int[10];
            paymentSlp.PaymentRowNoDtl[0] = paymentDataWork.PaymentRowNo1;
            paymentSlp.PaymentRowNoDtl[1] = paymentDataWork.PaymentRowNo2;
            paymentSlp.PaymentRowNoDtl[2] = paymentDataWork.PaymentRowNo3;
            paymentSlp.PaymentRowNoDtl[3] = paymentDataWork.PaymentRowNo4;
            paymentSlp.PaymentRowNoDtl[4] = paymentDataWork.PaymentRowNo5;
            paymentSlp.PaymentRowNoDtl[5] = paymentDataWork.PaymentRowNo6;
            paymentSlp.PaymentRowNoDtl[6] = paymentDataWork.PaymentRowNo7;
            paymentSlp.PaymentRowNoDtl[7] = paymentDataWork.PaymentRowNo8;
            paymentSlp.PaymentRowNoDtl[8] = paymentDataWork.PaymentRowNo9;
            paymentSlp.PaymentRowNoDtl[9] = paymentDataWork.PaymentRowNo10;
            paymentSlp.MoneyKindCodeDtl = new int[10];
            paymentSlp.MoneyKindCodeDtl[0] = paymentDataWork.MoneyKindCode1;
            paymentSlp.MoneyKindCodeDtl[1] = paymentDataWork.MoneyKindCode2;
            paymentSlp.MoneyKindCodeDtl[2] = paymentDataWork.MoneyKindCode3;
            paymentSlp.MoneyKindCodeDtl[3] = paymentDataWork.MoneyKindCode4;
            paymentSlp.MoneyKindCodeDtl[4] = paymentDataWork.MoneyKindCode5;
            paymentSlp.MoneyKindCodeDtl[5] = paymentDataWork.MoneyKindCode6;
            paymentSlp.MoneyKindCodeDtl[6] = paymentDataWork.MoneyKindCode7;
            paymentSlp.MoneyKindCodeDtl[7] = paymentDataWork.MoneyKindCode8;
            paymentSlp.MoneyKindCodeDtl[8] = paymentDataWork.MoneyKindCode9;
            paymentSlp.MoneyKindCodeDtl[9] = paymentDataWork.MoneyKindCode10;
            paymentSlp.MoneyKindNameDtl = new string[10];
            paymentSlp.MoneyKindNameDtl[0] = paymentDataWork.MoneyKindName1;
            paymentSlp.MoneyKindNameDtl[1] = paymentDataWork.MoneyKindName2;
            paymentSlp.MoneyKindNameDtl[2] = paymentDataWork.MoneyKindName3;
            paymentSlp.MoneyKindNameDtl[3] = paymentDataWork.MoneyKindName4;
            paymentSlp.MoneyKindNameDtl[4] = paymentDataWork.MoneyKindName5;
            paymentSlp.MoneyKindNameDtl[5] = paymentDataWork.MoneyKindName6;
            paymentSlp.MoneyKindNameDtl[6] = paymentDataWork.MoneyKindName7;
            paymentSlp.MoneyKindNameDtl[7] = paymentDataWork.MoneyKindName8;
            paymentSlp.MoneyKindNameDtl[8] = paymentDataWork.MoneyKindName9;
            paymentSlp.MoneyKindNameDtl[9] = paymentDataWork.MoneyKindName10;
            paymentSlp.MoneyKindDivDtl = new int[10];
            paymentSlp.MoneyKindDivDtl[0] = paymentDataWork.MoneyKindDiv1;
            paymentSlp.MoneyKindDivDtl[1] = paymentDataWork.MoneyKindDiv2;
            paymentSlp.MoneyKindDivDtl[2] = paymentDataWork.MoneyKindDiv3;
            paymentSlp.MoneyKindDivDtl[3] = paymentDataWork.MoneyKindDiv4;
            paymentSlp.MoneyKindDivDtl[4] = paymentDataWork.MoneyKindDiv5;
            paymentSlp.MoneyKindDivDtl[5] = paymentDataWork.MoneyKindDiv6;
            paymentSlp.MoneyKindDivDtl[6] = paymentDataWork.MoneyKindDiv7;
            paymentSlp.MoneyKindDivDtl[7] = paymentDataWork.MoneyKindDiv8;
            paymentSlp.MoneyKindDivDtl[8] = paymentDataWork.MoneyKindDiv9;
            paymentSlp.MoneyKindDivDtl[9] = paymentDataWork.MoneyKindDiv10;
            paymentSlp.PaymentDtl = new long[10];
            paymentSlp.PaymentDtl[0] = paymentDataWork.Payment1;
            paymentSlp.PaymentDtl[1] = paymentDataWork.Payment2;
            paymentSlp.PaymentDtl[2] = paymentDataWork.Payment3;
            paymentSlp.PaymentDtl[3] = paymentDataWork.Payment4;
            paymentSlp.PaymentDtl[4] = paymentDataWork.Payment5;
            paymentSlp.PaymentDtl[5] = paymentDataWork.Payment6;
            paymentSlp.PaymentDtl[6] = paymentDataWork.Payment7;
            paymentSlp.PaymentDtl[7] = paymentDataWork.Payment8;
            paymentSlp.PaymentDtl[8] = paymentDataWork.Payment9;
            paymentSlp.PaymentDtl[9] = paymentDataWork.Payment10;
            paymentSlp.ValidityTermDtl = new DateTime[10];
            paymentSlp.ValidityTermDtl[0] = paymentDataWork.ValidityTerm1;
            paymentSlp.ValidityTermDtl[1] = paymentDataWork.ValidityTerm2;
            paymentSlp.ValidityTermDtl[2] = paymentDataWork.ValidityTerm3;
            paymentSlp.ValidityTermDtl[3] = paymentDataWork.ValidityTerm4;
            paymentSlp.ValidityTermDtl[4] = paymentDataWork.ValidityTerm5;
            paymentSlp.ValidityTermDtl[5] = paymentDataWork.ValidityTerm6;
            paymentSlp.ValidityTermDtl[6] = paymentDataWork.ValidityTerm7;
            paymentSlp.ValidityTermDtl[7] = paymentDataWork.ValidityTerm8;
            paymentSlp.ValidityTermDtl[8] = paymentDataWork.ValidityTerm9;
            paymentSlp.ValidityTermDtl[9] = paymentDataWork.ValidityTerm10;
            paymentSlp.InputDay = paymentDataWork.InputDay;

            return paymentSlp;
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman�p�ɕύX
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �x���`�[�o�^����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.23</br>
		/// </remarks>
		public int Write(ref PaymentSlp paymentSlp)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

			PaymentSlpWork paymentSlpWork
				= (PaymentSlpWork)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlp, typeof(PaymentSlpWork));
			// XML�֕ϊ�
			byte[] parabyte = XmlByteSerializer.Serialize(paymentSlpWork);

			try
			{
				// �����f�[�^��������
				status = this._iPaymentSlpDB.Write(ref parabyte);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// XML�̓ǂݍ���
						paymentSlpWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSlpWork));
						paymentSlp = (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp));
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						_errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
					{
						_errorMessage = "�x���ԍ���ʒ[�����̔Ԃ��Ă��܂��B\r\n���΂炭���҂��ɂȂ��čēx���s���Ă��������B";
						break;
					}
					default:
					{
						_errorMessage = "�x���`�[�̕ۑ������Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = "�x���`�[�̕ۑ������ɂė�O���������܂����B\r\n" +ex.Message;
				//�I�t���C������null���Z�b�g
				_iPaymentSlpDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �x���`�[�Ǎ�����
		/// </summary>
		/// <param name="paymentSlp">�x���`�[�}�X�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�̓Ǎ����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.23</br>
		/// </remarks>
		public int Read(out PaymentSlp paymentSlp, string enterpriseCode, int paymentSlipNo)
		{
			int status = 0;
			_errorMessage = "";
			paymentSlp = null;

			try
			{
				byte[] parabyte;
				status = _iPaymentSlpDB.Read(enterpriseCode, paymentSlipNo, out parabyte);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// XML�̓ǂݍ���
						PaymentSlpWork paymentSlpWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSlpWork));
						// �N���X�������o�R�s�[
						paymentSlp = (PaymentSlp)DBAndXMLDataMergeParts.CopyPropertyInClass(paymentSlpWork, typeof(PaymentSlp));
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorMessage = "�w��x���`�[�͑��݂��܂���B";
						break;
					}
					default:
					{
						_errorMessage = "�x���`�[�̓Ǎ������Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = "�x���`�[�̓Ǎ��ɂė�O���������܂����B\r\n" + ex.Message;
				//�I�t���C������null���Z�b�g
				_iPaymentSlpDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

        /// <summary>
		/// �x���`�[�폜����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
		/// <param name="retPaymentSlpWork">�����E�ςݍ��`</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �x���`�[�̍폜���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.23</br>
		/// <br>Update Note : 2007.02.13 18322 T.Kimura �ԓ`���폜�����Ƃ��Ɍ����E�ςݍ��`��Ԃ��悤�ɕύX</br>
		/// </remarks>
        // �� 20070213 18322 c MA.NS�p�ɕύX
		//public int Delete(string enterpriseCode, int paymentSlipNo)
		//{

		public int Delete(string enterpriseCode, int paymentSlipNo, out PaymentSlpWork retPaymentSlpWork)
		{
            retPaymentSlpWork = null;

        // �� 20070213 18322 c
			int status = 0;
			_errorMessage = "";

			try
			{
                // �� 20070213 18322 c
                //status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo);

                byte[] PaymentSlpWorkByte;

                // �x���`�[�폜
				status = _iPaymentSlpDB.Delete(enterpriseCode, paymentSlipNo, out PaymentSlpWorkByte);
                // �� 20070213 18322 c

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // 20070213 18322 a MA.NS�p�ɕύX
                        if (PaymentSlpWorkByte != null) 
                        {
						    // �����E�ςݍ��`��Ԃ��B
                            retPaymentSlpWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(PaymentSlpWorkByte, typeof(PaymentSlpWork));
                        }
                        // �� 20070213 18322 a
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						_errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
						break;
					}
					default:
					{
						_errorMessage = "�x���`�[�̍폜�����Ɏ��s���܂����B";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = "�x���`�[�̍폜�����ɂė�O���������܂����B\r\n" + ex.Message;
				//�I�t���C������null���Z�b�g
				_iPaymentSlpDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

        /// <summary>
        /// �x���`�[�ԓ`�쐬����
        /// </summary>
        /// <param name="mode">�ԓ`�쐬���[�h 0:�ԓ����쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="paymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="paymentAgentNm">�x���S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�(�ԓ`���s�����`)</param>
        /// <param name="retPaymentSlpWorkList">�x���`�[�}�X�^(�X�V����)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���x���`�[�ԍ��̐Ԏx���쐬�������s���܂�</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2006.12.22</br>
		/// </remarks>
        public int RedCreate(int mode, string enterpriseCode, string updateSecCd, string paymentAgentCode, string paymentAgentNm, DateTime addUpADate, int paymentSlipNo, out ArrayList retPaymentSlpWorkList)
        {
            int status = 0;
            _errorMessage = "";

            retPaymentSlpWorkList = new ArrayList();
            retPaymentSlpWorkList.Clear();

            try
            {
                object retObj;
                status = _iPaymentSlpDB.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  addUpADate,
                                                  paymentSlipNo,
                                                  out retObj);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList wkList = retObj as ArrayList;
                            if (wkList != null)
                            {
                                for (int i = 0; i != wkList.Count; i++)
                                {
                                    PaymentSlpWork work = (PaymentSlpWork)wkList[i];
                                    retPaymentSlpWorkList.Add(work);
                                }
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍX�V�A���͍폜����Ă��܂��B";
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            _errorMessage = "�x���`�[�͑��[���ɂ����ɍ폜����Ă��܂��B";
                            break;
                        }
                    default:
                        {
                            _errorMessage = "�x���`�[�̐ԓ`�����Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = "�x���`�[�̐ԓ`�����ɂė�O���������܂����B\r\n" + ex.Message;
                //�I�t���C������null���Z�b�g
                _iPaymentSlpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman�p�ɕύX

        #endregion
    }
}
