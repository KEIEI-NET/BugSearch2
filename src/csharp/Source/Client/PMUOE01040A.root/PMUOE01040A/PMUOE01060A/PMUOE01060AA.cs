//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�������A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d�������A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10502378-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  XXXXXXXX-00 �쐬�S�� : ���� ���n
// �� �� ��  2011/10/27  �C�����e : 22008 ���� ���n �`�[���גǉ����Z�b�g�s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangmj
// �� �� ��  2012/09/20  �C�����e : redmine#32404�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �t�n�d�������A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �t�n�d�������A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2009/05/25</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>Update Note: 2012/09/20 yangmj redmine#23404�̑Ή�</br>
	/// </remarks>
	public partial class UoeOrderInfoAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
        public UoeOrderInfoAcs()
		{
			//��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//���O�C�����_�R�[�h
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //UOE�����f�[�^�E�d�����׃f�[�^�X�V�����[�g�I�u�W�F�N�g
            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();

            //UOE�����f�[�^ �����[�g�I�u�W�F�N�g
            this._iIOWriteUOEOdrDtlDB = (IIOWriteUOEOdrDtlDB)MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();

            //�d���f�[�^ �����[�g�I�u�W�F�N�g
            this._iStockSlipDB = (IStockSlipDB)MediationStockSlipDB.GetStockSlipDB();

            //���ɍX�V �����[�g�I�u�W�F�N�g
            this._iUOEStockUpdateDB = MediationUOEStockUpdateDB.GetUOEStockUpdateDB();
        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns></returns>
        public static UoeOrderInfoAcs GetInstance()
        {
            if (_uoeOrderInfoAcs == null)
            {
                _uoeOrderInfoAcs = new UoeOrderInfoAcs();
            }
            return _uoeOrderInfoAcs;
        }
        # endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
        //�A�N�Z�X�N���X �C���X�^���X
        private static UoeOrderInfoAcs _uoeOrderInfoAcs = null;

		//��ƃR�[�h
		private string _enterpriseCode = "";

		//���O�C�����_�R�[�h
		private string _loginSectionCd = "";

        //UOE�����f�[�^�E�d�����׃f�[�^�X�V�����[�g
        private IIOWriteControlDB _iIOWriteControlDB = null;

        //UOE�����f�[�^ �����[�g�I�u�W�F�N�g
        private IIOWriteUOEOdrDtlDB _iIOWriteUOEOdrDtlDB = null;

        //�d���f�[�^ �����[�g�I�u�W�F�N�g
        private IStockSlipDB _iStockSlipDB = null;

        //���ɍX�V �����[�g�I�u�W�F�N�g
        private IUOEStockUpdateDB _iUOEStockUpdateDB = null;

        # endregion

		// ===================================================================================== //
		// �萔�Q
		// ===================================================================================== //
		#region Public Const Member
        // ���b�Z�[�W
        private const string MESSAGE_NoResult = "�����Ɉ�v����f�[�^�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�f�[�^�̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NotFound = "�����Ώۂ̃f�[�^�����݂��܂���B";
        # endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
        # endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region �� �t�n�d�����f�[�^�E�d�����ׂ̍X�V����
        /// <summary>
        /// �t�n�d�����f�[�^�E�d�����ׂ̍X�V����
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="StockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteUOEOrderDtl(
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            return (WriteUOEOrderDtl(
                ref uOEOrderDtlWorkList,
                ref stockDetailWorkList,
                1,
                out message));
        }
        # endregion

        # region �� �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// <summary>
        /// �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="StockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="mode">���샂�[�h 0:�V�K�쐬 1:�m�莞����</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteUOEOrderDtl(
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            int mode,
            out string message)
        {
            //-----------------------------------------------------------
            // �ϐ��̏�����
            //-----------------------------------------------------------
            # region �ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            # endregion

            try
            {
                //-----------------------------------------------------------
                // �d�����׃f�[�^�̕s���f�[�^���폜
                //-----------------------------------------------------------
                # region �t�n�d�����f�[�^�ɔ����ԍ��E�����s�ԍ���t��
                for (int i = 0; i < stockDetailWorkList.Count; i++)
                {
                    //�d���S���Җ���
                    if (stockDetailWorkList[i].StockAgentName.Length > 16)
                    {
                        string strRemove = stockDetailWorkList[i].StockAgentName.Remove(16);
                        stockDetailWorkList[i].StockAgentName = strRemove;
                    }

                    //�d�����͎Җ���
                    if (stockDetailWorkList[i].StockInputName.Length > 16)
                    {
                        string strRemove = stockDetailWorkList[i].StockInputName.Remove(16);
                        stockDetailWorkList[i].StockInputName = strRemove;
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�ɔ����ԍ��E�����s�ԍ���t��
                //-----------------------------------------------------------
                # region �t�n�d�����f�[�^�ɔ����ԍ��E�����s�ԍ���t��
                //�������t���O�̐ݒ�E�t�n�d������ꗗ�̎擾
                DateTime dateTimeNow = DateTime.Now;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
		        {
                    //��M���t�iReceiveDateRF�j�ɃV�X�e�����t���Z�b�g
                    uOEOrderDtlWorkList[i].ReceiveDate = dateTimeNow;


                    //�񓚖��ߍ��݃f�[�^�̏ꍇ
                    if (uOEOrderDtlWorkList[i].DataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_Insert)
                    {
                        //���M�t���O�u9:����I���v��ݒ�
                        uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

                        //�����t���O�u9:����I���v��ݒ�
                        uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                    }
                    //�������f�[�^�̏ꍇ
                    else
                    {
                        //�m�莞����
                        if (mode == 1)
                        {
                            //���M�t���O�u1:�������v��ݒ�
                            uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_Process;

                            //�����t���O�u0:�������v��ݒ�
                            uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess;
                        }
                        //�V�K����
                        else
                        {
                            //���M�t���O�u0:�������v��ݒ�
                            uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_NonProcess;

                            //�����t���O�u0:�������v��ݒ�
                            uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess;
                        }
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
                //-----------------------------------------------------------
                # region �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
                IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
                List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

                status = WriteUOEOrderDtl(
                    ref iOWriteCtrlOptWork,
                    ref slipDetailAddInfoWorkList,
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList,
                    out message);
                # endregion

            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
		# endregion

        # region �� �t�n�d�����񓚍X�V����
        /// <summary>
        /// �t�n�d�����񓚍X�V����
        /// </summary>
        /// <param name="stockSlipGrpList">�t�n�d�񓚏��m��p �d���w�b�_�E���׏���`</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����f�[�^��`���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Write(ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//�p�����[�^�N���X�쐬
                CustomSerializeArrayList csAry = ToCustomSerializeFromStockSlipGrpList(stockSlipGrpList, uOEOrderDtlWorkList);
				object setObj = (object)csAry;

                do
                {
                    status = this._iIOWriteUOEOdrDtlDB.OrderFixation(ref setObj);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                } while ((status == 850) || (status == 851) || (status == 852));

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (setObj is ArrayList))
				{
                    DivisionCustomSerializeArrayList((CustomSerializeArrayList)setObj, ref stockSlipGrpList, ref uOEOrderDtlWorkList);
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
				}
				else
				{
					message = MESSAGE_NoResult;
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

        # region �� �t�n�d�����f�[�^�̌�������
        /// <summary>
        /// �t�n�d�����f�[�^�̌�������
        /// </summary>
        /// <param name="para">�����p�����[�^</param>
        /// <param name="uOEOrderDtlWorkList">UOE�������[�N</param>
        /// <param name="stockDetailWorkList">�d�����׃��[�N</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Search(UOESendProcCndtnPara para, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
			message = "";

			try
			{
                UOESendProcCndtnWork uOESendProcCndtnWork = ToUOESendProcCndtnWorkFromPara(para);

                ArrayList uOEOrderDtlWorkAry = new ArrayList(); 
                ArrayList stockDetailWorkAry = new ArrayList();

                object uOESendProcCndtnWorkObj = uOESendProcCndtnWork;
                object uOEOrderDtlWorkAryObj = uOEOrderDtlWorkAry;
                object stockDetailWorkAryObj = stockDetailWorkAry;

                status = this._iIOWriteUOEOdrDtlDB.Search(  uOESendProcCndtnWorkObj,
                                                            ref uOEOrderDtlWorkAryObj,
                                                            ref stockDetailWorkAryObj,
                                                            0,
                                                            ConstantManagement.LogicalMode.GetData0);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uOEOrderDtlWorkAryObj is ArrayList)
                && (stockDetailWorkAryObj is ArrayList))
				{
					ArrayList retUOEOrderDtlWorkAry = (ArrayList)uOEOrderDtlWorkAryObj;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDetailWorkAryObj;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
                    uOEOrderDtlWorkList = null;
                    stockDetailWorkList = null;
                }
				else
				{
					message = MESSAGE_NoResult;
				}
			}
			catch (Exception ex)
			{
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

        # region �� �t�n�d�����f�[�^�̌���������UOE�����ԍ��E�i�ԁ�
        /// <summary>
        /// �� �t�n�d�����f�[�^�̌���������UOE�����ԍ��E�i�ԁ�
        /// </summary>
        /// <param name="para">ArrayList��UOEOdrDtlGodsReadCndtnWork��</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UoeOdrDtlGodsReadAll(ArrayList paraAry, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();

            try
            {
                //�p�����[�^�ݒ�
                ArrayList uOEOrderDtlWorkAry = new ArrayList();
                ArrayList stockDetailWorkAry = new ArrayList();

                object paraList = paraAry;
                object uoeOrderDtlList = uOEOrderDtlWorkAry;
                object stockDtlList = stockDetailWorkAry;

                //�����[�g�����̌Ăяo��
                status = this._iIOWriteUOEOdrDtlDB.UoeOdrDtlGodsReadAll(
                    paraList,
                    ref uoeOrderDtlList,
                    ref stockDtlList);

                //�ߒl�̐ݒ�
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeOrderDtlList is ArrayList)
                && (stockDtlList is ArrayList))
                {
                    ArrayList retUOEOrderDtlWorkAry = (ArrayList)uoeOrderDtlList;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDtlList;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    message = MESSAGE_NoResult;
                    uOEOrderDtlWorkList = null;
                    stockDetailWorkList = null;
                }
                else
                {
                    message = MESSAGE_NoResult;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
		# endregion

        # region �� �t�n�d�����f�[�^�̌���������UOE������E�����`�[�ԍ���
        /// <summary>
        /// �� �t�n�d�����f�[�^�̌���������UOE������E�����`�[�ԍ���
        /// </summary>
        /// <param name="para">ArrayList��UOEStockUpdSearchWork��</param>
        /// <param name="uOEOrderDtlWorkList">UOE�����f�[�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchAllPartySlip(ArrayList paraAry, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();

            try
            {
                //�p�����[�^�ݒ�
                ArrayList uOEOrderDtlWorkAry = new ArrayList();
                object paraList = paraAry;
                object uoeOrderDtlList = uOEOrderDtlWorkAry;

                //UOEStockUpdSearchWork uOEStockUpdSearchWork

                //�����[�g�����̌Ăяo��
                status = this._iUOEStockUpdateDB.SearchAllPartySlip(
                    paraList,
                    ref uoeOrderDtlList,
                    0,
                    0);              

                //�ߒl�̐ݒ�
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeOrderDtlList is ArrayList))
                {
                    ArrayList retUOEOrderDtlWorkAry = (ArrayList)uoeOrderDtlList;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)EnumUoeConst.Status.ct_NORMAL;
                    message = String.Empty;
                    uOEOrderDtlWorkList = null;
                }
                else
                {
                    uOEOrderDtlWorkList = null;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
		# endregion

        # region �� �d�����̓ǂݍ��ݏ������d�����E�����`�[�ԍ���
        /// <summary>
        /// �� �d�����̓ǂݍ��ݏ������d�����E�����`�[�ԍ���
        /// </summary>
        /// <param name="paraAry">ArrayList��StockSlipWork��</param>
        /// <param name="stockSlipWorkList">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int StockSlipPartySaleSlipNumReadAll(ArrayList paraAry, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
        {
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

            stockSlipWorkList = new List<StockSlipWork>();
            stockDetailWorkList = new List<StockDetailWork>();

            try
            {
                //�p�����[�^�ݒ�
                ArrayList stockSlipWorkAry = new ArrayList();
                ArrayList stockDetailWorkAry = new ArrayList();

                object paraAryobj = paraAry;
                object stockSlipAryObj = stockSlipWorkList;
                object stockDetailAryObj = stockDetailWorkList;

                //�����[�g�����̌Ăяo��
                status = this._iStockSlipDB.StockSlipPartySaleSlipNumReadAll(
                                    paraAryobj,
                                    out stockSlipAryObj,
                                    out stockDetailAryObj);

                //�ߒl�̐ݒ�
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (stockSlipAryObj is ArrayList)
                && (stockDetailAryObj is ArrayList))
                {
                    ArrayList retStockSlipWorkAry = (ArrayList)stockSlipAryObj;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDetailAryObj;

                    stockSlipWorkList.AddRange((StockSlipWork[])retStockSlipWorkAry.ToArray(typeof(StockSlipWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    message = MESSAGE_NoResult;
                    stockSlipWorkList = null;
                    stockDetailWorkList = null;
                }
                else
                {
                    message = MESSAGE_NoResult;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
			return (status);
        }
        # endregion

        # region �� �t�n�d�����f�[�^�̍폜����
        /// <summary>
		/// �t�n�d�����f�[�^�̍폜����
		/// </summary>
		/// <param name="list">�t�n�d�����f�[�^</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns></returns>
		public int Delete(List<UOEOrderDtlWork> list, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				if (list == null)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}
				if (list.Count == 0)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}

                //�p�����[�^�̐ݒ�
                ArrayList registList = new ArrayList();
                registList.AddRange(list);
				object uoeOrderDtlList = (object)registList;

                status = this._iIOWriteUOEOdrDtlDB.LogicalDelete(ref uoeOrderDtlList);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
        # endregion
        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// <summary>
        /// �t�n�d�����f�[�^�E�d�����ׂ̍쐬����
        /// </summary>
        /// <param name="iOWriteCtrlOptWork">����E�d������I�v�V����</param>
        /// <param name="slipDetailAddInfoWorkList">�`�[���גǉ����f�[�^���X�g</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="StockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteUOEOrderDtl(
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            # region �ϐ��̏�����
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            //�߂�l�̏�����

            //ArrayList�̏�����
            ArrayList slipDetailAddInfoWorkArry = null;
            ArrayList uOEOrderDtlWorkArry = null;
            ArrayList stockDetailWorkArry = null;
            # endregion

            try
            {
                # region �t�n�d�����f�[�^���X�g���e�탊�X�g���擾
                status = GetOrderWorkFromUOEOrderDtl(
                    uOEOrderDtlWorkList,
                    stockDetailWorkList,
                    out uOEOrderDtlWorkArry,
                    out stockDetailWorkArry,
                    out slipDetailAddInfoWorkArry,
                    out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                # region �����[�g�����̃p�����[�^�ݒ�
                //����E�d������I�v�V�����̐ݒ�
                IOWriteCtrlOptWork iOWriteCtrlOptWorkClass = new IOWriteCtrlOptWork();

                iOWriteCtrlOptWorkClass.CtrlStartingPoint = 1;              //����N�_
                iOWriteCtrlOptWorkClass.AcpOdrrAddUpRemDiv = 0;             //�󒍃f�[�^�v��c�敪
                iOWriteCtrlOptWorkClass.ShipmAddUpRemDiv = 0;               //�o�׃f�[�^�v��c�敪
                iOWriteCtrlOptWorkClass.RetGoodsStockEtyDiv = 0;            //�ԕi���݌ɓo�^�敪
                iOWriteCtrlOptWorkClass.SupplierSlipDelDiv = 0;             //�d���`�[�폜�敪
                iOWriteCtrlOptWorkClass.RemainCntMngDiv = 0;                //�c���Ǘ��敪
                iOWriteCtrlOptWorkClass.EnterpriseCode = _enterpriseCode;   //��ƃR�[�h
                iOWriteCtrlOptWorkClass.CarMngDivCd = 0;                    //�ԗ��Ǘ��敪

                //�����[�g�����̃p�����[�^�ݒ�
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraUoeDetailList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraStockList = new CustomSerializeArrayList();

                object objUOEOrderDtlWorkList = (object)uOEOrderDtlWorkArry;
                object objStockDetailWorkList = (object)stockDetailWorkArry;
                object objIOWriteCtrlOptWorkClass = (object)iOWriteCtrlOptWorkClass;
                object objSlipDetailAddInfoWorkList = (object)slipDetailAddInfoWorkArry;


                paraUoeDetailList.Add(objUOEOrderDtlWorkList);
                paraList.Add(paraUoeDetailList);

                paraStockList.Add(objSlipDetailAddInfoWorkList);
                paraStockList.Add(objStockDetailWorkList);

                paraList.Add(paraStockList);
                paraList.Add(objIOWriteCtrlOptWorkClass);

                object objParaList = (object)paraList;
                # endregion

                # region �����[�g�����̌Ăяo��
                //�����[�g�����̌Ăяo��
                string retItemInfo = "";
                do
                {
                    status = _iIOWriteControlDB.Write(ref objParaList, out message, out retItemInfo);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B\r"
                            + "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B\r"
                            + "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                } while ((status == 850) || (status == 851) || (status == 852));

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                # region �߂�l�̐ݒ�
                //�߂�l�̐ݒ�
                iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
                slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                CustomSerializeArrayListForAfterWrite(
                    objParaList,
                    ref iOWriteCtrlOptWork,
                    ref slipDetailAddInfoWorkList,
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList);
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �t�n�d�����m��p�p�����[�^�[�쐬
        /// <summary>
        /// �t�n�d�����m��p�p�����[�^�[�쐬
        /// </summary>
        /// <param name="stockSlipGrpList">�t�n�d�񓚏��m��p �d���w�b�_�E���׏���`</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����f�[�^��`���X�g</param>
        /// <returns>�t�n�d�����m��p�p�����[�^�[</returns>
        private CustomSerializeArrayList ToCustomSerializeFromStockSlipGrpList(List<StockSlipGrp> stockSlipGrpList, List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            //------------------------------------------------------------------------------------
            // csAry�\��
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            �������X�g
            //      --ArrayList                     UOE�����f�[�^���X�g
            //          --UOEOrderDtlWork           UOE�����f�[�^
            //      --CustomSerializeArrayList      �d���f�[�^���X�g
            //          --StockSlipWork             �d���w�b�_�N���X
            //          --ArrayList                 �d�����׃��X�g
            //              --StockDetailWork       �d�����׃N���X
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList csAry = new CustomSerializeArrayList();

            try
            {
                //UOE�����f�[�^�i�[����
                ArrayList uOEOrderDtlWorkAry = new ArrayList();
                uOEOrderDtlWorkAry.AddRange(uOEOrderDtlWorkList);

                //CustomSerializeArrayList�֐ݒ�
                csAry.Add(uOEOrderDtlWorkAry);

                //�d�����i�[����
                foreach (StockSlipGrp stockSlipGrp in stockSlipGrpList)
                {
                    CustomSerializeArrayList stockGrpAry = new CustomSerializeArrayList();

                    //�d���w�b�_�N���X
                    stockGrpAry.Add(stockSlipGrp.stockSlipWork);

                    //�d�����׃N���X
                    ArrayList dtl = new ArrayList();
                    dtl.AddRange(stockSlipGrp.stockDetailWorkList);
                    stockGrpAry.Add(dtl);

                    //CustomSerializeArrayList�֐ݒ�
                    csAry.Add(stockGrpAry);
                }

            }
            catch (Exception)
            {
                csAry = null;
            }
            return (csAry);
        }
        # endregion

        # region CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�֕���
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�֕���
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipGrpList">�t�n�d�񓚏��m��p �d���w�b�_�E���׏���`</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����f�[�^��`���X�g</param>
        private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            List<UOEOrderDtlWork> returnUOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            List<StockSlipGrp> returnStockSlipGrpList = new List<StockSlipGrp>();

            try
            {
                //------------------------------------------------------------------------------------
                // csAry�\��
                //------------------------------------------------------------------------------------
                //  CustomSerializeArrayList            �������X�g
                //      --ArrayList                     UOE�����f�[�^���X�g
                //          --UOEOrderDtlWork           UOE�����f�[�^
                //      --CustomSerializeArrayList      �d���f�[�^���X�g
                //          --StockSlipWork             �d���w�b�_�N���X
                //          --ArrayList                 �d�����׃��X�g
                //              --StockDetailWork       �d�����׃N���X
                //------------------------------------------------------------------------------------


                for (int i = 0; i < paraList.Count; i++)
                {
                    if (paraList[i] is ArrayList)
                    {
                        ArrayList list = (ArrayList)paraList[i];
                        if (list.Count == 0) continue;

                        //UOE�����f�[�^
                        if (list[0] is UOEOrderDtlWork)
                        {
                            foreach (UOEOrderDtlWork work in list)
                            {
                                returnUOEOrderDtlWorkList.Add(work);
                            }
                        }
                        //�d�����
                        else if((list[0] is ArrayList) || (list[0] is StockSlipWork))
                        {
                            StockSlipGrp stockSlipGrp = new StockSlipGrp();
                            for (int j = 0; j < list.Count; j++)
                            {
                                //�d���w�b�_�[
                                if (list[j] is StockSlipWork)
                                {
                                    stockSlipGrp.stockSlipWork = (StockSlipWork)list[j];
                                }
                                //�d������
                                else if (list[j] is ArrayList)
                                {
                                    ArrayList dtlList = (ArrayList)list[j];
                                    if (dtlList[0] is StockDetailWork)
                                    {
                                        foreach (StockDetailWork work in dtlList)
                                        {
                                            stockSlipGrp.stockDetailWorkList.Add(work);
                                        }
                                    }
                                }
                            }
                            returnStockSlipGrpList.Add(stockSlipGrp);
                        }
                    }
                }
            }
            catch (Exception)
            {
                returnStockSlipGrpList = null;
                returnUOEOrderDtlWorkList = null;
            }

            //�߂�l�ݒ�
            stockSlipGrpList = returnStockSlipGrpList;
            uOEOrderDtlWorkList = returnUOEOrderDtlWorkList;
        }
        # endregion

        # region UOE�����f�[�^���o�����ϊ�(para��Work)
        /// <summary>
        /// UOE�����f�[�^���o�����ϊ�(para��Work)
        /// </summary>
        /// <param name="para">UOE�����f�[�^���o�����p�����[�^</param>
        /// <returns>UOE�����f�[�^���o����Work</returns>
        /// <br>Update Note: 2012/09/20 yangmj redmine#23404�̑Ή�</br>
        private UOESendProcCndtnWork ToUOESendProcCndtnWorkFromPara(UOESendProcCndtnPara para)
        {
            UOESendProcCndtnWork returnUOESendProcCndtnWork = new UOESendProcCndtnWork();

   			try
			{
                returnUOESendProcCndtnWork.CashRegisterNo = para.CashRegisterNo;
                returnUOESendProcCndtnWork.CustomerCode = para.CustomerCode;
                returnUOESendProcCndtnWork.EnterpriseCode = para.EnterpriseCode;
                returnUOESendProcCndtnWork.St_InputDay = para.St_InputDay;
                returnUOESendProcCndtnWork.Ed_InputDay = para.Ed_InputDay;
                returnUOESendProcCndtnWork.SystemDivCd = para.SystemDivCd;
                returnUOESendProcCndtnWork.St_UOESalesOrderNo = para.St_UOESalesOrderNo;
                returnUOESendProcCndtnWork.Ed_UOESalesOrderNo = para.Ed_UOESalesOrderNo;
                returnUOESendProcCndtnWork.UOESupplierCd = para.UOESupplierCd;
                returnUOESendProcCndtnWork.St_OnlineNo = para.St_OnlineNo;
                returnUOESendProcCndtnWork.Ed_OnlineNo = para.Ed_OnlineNo;
                returnUOESendProcCndtnWork.DataSendCodes = para.DataSendCodes;
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
                if (LoginInfoAcquisition.Employee != null)
                {
                    returnUOESendProcCndtnWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<
			}
			catch (Exception)
			{
                returnUOESendProcCndtnWork = new UOESendProcCndtnWork();;
			}
			return (returnUOESendProcCndtnWork);
        }
		# endregion

        # region �t�n�d�����f�[�^���X�g���t�n�d�����v�n�q�j���X�g�E�d�����ׂv�n�q�j���X�g���擾
        /// <summary>
        /// �t�n�d�����f�[�^���X�g���t�n�d�����v�n�q�j���X�g�E�d�����ׂv�n�q�j���X�g���擾
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="stockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="uOEOrderDtlWorkArry">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="stockDetailWorkArry">�d�����ׂv�n�q�j���X�g</param>
        /// <param name="slipDetailAddInfoWorkArry">�`�[���גǉ����f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetOrderWorkFromUOEOrderDtl(List<UOEOrderDtlWork> uOEOrderDtlWorkList,
                                                List<StockDetailWork> stockDetailWorkList,
                                                out ArrayList uOEOrderDtlWorkArry,
                                                out ArrayList stockDetailWorkArry,
                                                out ArrayList slipDetailAddInfoWorkArry,
                                                out string message)
        {
            # region �ϐ��̏�����
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkArry = null;
            stockDetailWorkArry = null;
            slipDetailAddInfoWorkArry = null;
            message = "";

            ArrayList returnUOEOrderDtlWorkArry = new ArrayList();
            ArrayList returnStockDetailWorkArry = new ArrayList();
            ArrayList returnSlipDetailAddInfoWorkArry = new ArrayList();

            //SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // DEL 2011/10/27
            int slipDtlRegOrder = 0;    //�`�[�E���ׂ̓o�^���ʂ�ݒ�  // ADD 2011/10/27
            #endregion

            try
            {
                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    //Guid�l�擾
                    Guid guid = Guid.NewGuid();

                    # region �t�n�d�����f�[�^���t�n�d�����v�n�q�j���擾
                    //�t�n�d�����f�[�^���t�n�d�����v�n�q�j���擾
                    UOEOrderDtlWork uOEOrderDtlWork = uOEOrderDtlWorkList[i];
                    uOEOrderDtlWork.DtlRelationGuid = guid;
                    #endregion

                    # region �t�n�d�����f�[�^���d�����ׂv�n�q�j���擾
                    //�t�n�d�����f�[�^���d�����ׂv�n�q�j���擾
                    StockDetailWork stockDetailWork = stockDetailWorkList[i];
                    stockDetailWork.DtlRelationGuid = guid;
                    #endregion

                    # region �`�[���גǉ����f�[�^�ݒ�
                    //�`�[���גǉ����f�[�^
                    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // ADD 2011/10/27
                    slipDetailAddInfoWork.DtlRelationGuid = guid;               //���׊֘A�t��GUID
                    slipDetailAddInfoWork.GoodsEntryDiv = 0;                    //���i�o�^�敪
                    slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;   //���i�񋟓��t
                    slipDetailAddInfoWork.PriceUpdateDiv = 0;                   //���i�X�V�敪
                    slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;   //���i�J�n���t
                    slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;   //���i�񋟓��t
                    slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;         //�ԗ��֘A�t��GUID
                    // -- ADD 2011/10/27 ------------------------>>>
                    slipDtlRegOrder++;
                    slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;    //�`�[�o�^�D�揇��
                    // -- ADD 2011/10/27 ------------------------<<<
                    #endregion

                    # region ���X�g�ǉ�����
                    //���X�g�ǉ�����
                    returnUOEOrderDtlWorkArry.Add(uOEOrderDtlWork);
                    returnStockDetailWorkArry.Add(stockDetailWork);
                    returnSlipDetailAddInfoWorkArry.Add(slipDetailAddInfoWork);
                    #endregion
                }

                //���ʂ̊i�[
                uOEOrderDtlWorkArry = returnUOEOrderDtlWorkArry;
                stockDetailWorkArry  = returnStockDetailWorkArry;
                slipDetailAddInfoWorkArry = returnSlipDetailAddInfoWorkArry;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

		# endregion

        #region �J�X�^���V���A���C�Y�A���C���X�g��������
        /// <summary>
        /// �J�X�^���V���A���C�Y�A���C���X�g��������
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y�A���C���X�g</param>
        /// <param name="iOWriteCtrlOptWork">����E�d������I�v�V����</param>
        /// <param name="slipDetailAddInfoWorkList">�`�[���גǉ����f�[�^���X�g</param>
        /// <param name="uOEOrderDtlWorkList">�t�n�d�����v�n�q�j���X�g</param>
        /// <param name="stockDetailWorkList">�d�����ׂv�n�q�j���X�g</param>
        private void CustomSerializeArrayListForAfterWrite(object paraList,
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList)
        {
            foreach (object tempObj in (CustomSerializeArrayList)paraList)
            {
                if (tempObj is IOWriteCtrlOptWork)
                {
                    # region ����E�d������I�v�V����
                    //����E�d������I�v�V����
                    iOWriteCtrlOptWork = (IOWriteCtrlOptWork)tempObj;
                    # endregion
                }
                else if(tempObj is ArrayList)
                {
                    ArrayList tempAry = (ArrayList)tempObj;
                    if(tempAry.Count == 0)  continue;

                    foreach(object tempObj2 in tempAry)
                    {
                        if(tempObj2 is ArrayList)
                        {
                            ArrayList tempAry2 = (ArrayList)tempObj2;

                            if(tempAry2[0] is SlipDetailAddInfoWork)
                            {
                                # region �`�[���גǉ����f�[�^���X�g
                                //�`�[���גǉ����f�[�^���X�g
                                foreach(SlipDetailAddInfoWork work in tempAry2)
                                {
                                    slipDetailAddInfoWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is UOEOrderDtlWork)
                            {
                                # region �t�n�d�����v�n�q�j���X�g
                                //�t�n�d�����v�n�q�j���X�g
                                foreach (UOEOrderDtlWork work in tempAry2)
                                {
                                    uOEOrderDtlWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is StockDetailWork)
                            {
                                # region �d�����ׂv�n�q�j���X�g
                                //�d�����ׂv�n�q�j���X�g
                                foreach (StockDetailWork work in tempAry2)
                                {
                                    stockDetailWorkList.Add(work);
                                }
                                # endregion
                            }
                        }

                    }
                }
            }
        }
        # endregion
        # endregion
    }
}
