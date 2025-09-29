//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �񓚃f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : �z���_ UOE WEB��p �񓚃f�[�^�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2009/05/25  �C�����e : 96186 ���� �T�� �z���_ UOE WEB�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  XXXXXXXX-00 �쐬�S�� : ���� ���n
// �� �� ��  2011/10/27  �C�����e : 22008 ���� ���n �`�[���גǉ����Z�b�g�s��̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
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
	/// �񓚃f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �z���_ UOE WEB��p �񓚃f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
    /// <br>Date       : 2009/05/25</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009/05/25 men �V�K�쐬</br>
    /// <br>Update Note  : 2009/05/25 96186 ���� �T��</br>
    /// <br>              �E�z���_ UOE WEB�Ή�</br>
    /// </remarks>
	public partial class UOEAnswerAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		# endregion

		// ===================================================================================== //
		// �萔�Q
		// ===================================================================================== //
		#region Public Const Member
		# endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        # region Enums
        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// </summary>
        public enum OptWorkSettingType : int
        {
            /// <summary>�o�^</summary>
            Write = 0,
            /// <summary>�Ǎ�</summary>
            Read = 1,
            /// <summary>�폜</summary>
            Delete = 2,
        }
        #endregion

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
        # region �� �d�����f�[�^�Z�b�g
        /// <summary>
        /// �d�����̏������ݏ���
        /// </summary>
        /// <param name="stockSlipGrpList">�d�����</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteStockInfo(List<StockSlipGrp> stockSlipGrpList, out string message)
        {
            return(WriteStockInfoProc(stockSlipGrpList, out message));
        }
		# endregion
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �d�����f�[�^�Z�b�g
        /// <summary>
        /// �d�����̏������ݏ���
        /// </summary>
        /// <param name="stockSlipGrpList">�d�����</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteStockInfoProc(List<StockSlipGrp> stockSlipGrpList, out string message)
        {
            //------------------------------------------------------------------------------------
            // �f�[�^�Z�b�g���@
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            �������X�g
            //      --CustomSerializeArrayList      �d�����X�g
            //          --StockSlipWork             �d���f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �d�����׃��X�g
            //              --StockDetailWork       �d�����׃f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �`�[���גǉ���񃊃X�g
            //              --SlipDetailAddInfoWork �`�[���גǉ����I�u�W�F�N�g
            //      --iOWriteCtrlOptWork            ����E�d������I�v�V����
            //------------------------------------------------------------------------------------

            # region �ϐ��̏�����
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            //�߂�l�̏�����
            # endregion

            try
            {
                //------------------------------------------------------
                // �d����񃊃X�g�p�����[�^�ݒ�
                //------------------------------------------------------
                # region �d����񃊃X�g�p�����[�^�ݒ�
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();     // �������X�g
                status = GetStockInfoPara(ref paraList, stockSlipGrpList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                //------------------------------------------------------
                // �����[�g�Q�Ɨp�p�����[�^
                //------------------------------------------------------
                # region �����[�g�Q�Ɨp�p�����[�^
                if (paraList.Count == 0)
                {
                    return (status);
                }

                IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // �����[�g�Q�Ɨp�p�����[�^
                this.SettingIOWriteCtrlOptWork(OptWorkSettingType.Write, out iOWriteCtrlOptWork); // �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
                paraList.Add(iOWriteCtrlOptWork);
                #endregion
                #endregion

                //------------------------------------------------------
                // �X�V����
                //------------------------------------------------------
                #region �X�V����
                // �ۑ��p�ϐ�������
                string retItemInfo = string.Empty;
                object paraObj = (object)paraList;

                // �X�V����
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                do
                {
                    status = this._iIOWriteControlDB.Write(ref paraObj, out message, out retItemInfo);
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
                }while ((status == 850) || (status == 851) || (status == 852));

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �d�����f�[�^�Z�b�g
        /// <summary>
        /// �d�����f�[�^�Z�b�g
        /// </summary>
        /// <param name="paraList">�d�����X�g��CustomSerializeArrayList��</param>
        /// <param name="stockSlipGrpList">�d�����X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetStockInfoPara(ref CustomSerializeArrayList paraList, List<StockSlipGrp> stockSlipGrpList, out string message)
        {
            //------------------------------------------------------------------------------------
            // �f�[�^�Z�b�g���@
            //------------------------------------------------------------------------------------
            //      --CustomSerializeArrayList      �d�����X�g
            //          --StockSlipWork             �d���f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �d�����׃��X�g
            //              --StockDetailWork       �d�����׃f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �`�[���גǉ���񃊃X�g
            //              --SlipDetailAddInfoWork �`�[���גǉ����I�u�W�F�N�g
            //------------------------------------------------------------------------------------
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = String.Empty;

            try
            {
                int slipDtlRegOrder = 0;    //�`�[�E���ׂ̓o�^���ʂ�ݒ�  // ADD 2011/10/27

                foreach (StockSlipGrp stockSlipGrp in stockSlipGrpList)
                {
                    StockSlipWork stockSlipWork = stockSlipGrp.stockSlipWork;
                    
                    //-----------------------------------------------------------
                    // �`�[���גǉ����̍쐬
                    //-----------------------------------------------------------
                    # region �`�[���גǉ����̍쐬
                    //int slipDtlRegOrder = 0;    //�`�[�E���ׂ̓o�^���ʂ�ݒ�  // DEL 2011/10/27
                    ArrayList stockDetailWorkAry = new ArrayList();
                    ArrayList slipDetailAddInfoWorkAry = new ArrayList();

                    foreach (StockDetailWork stockDetailWork in stockSlipGrp.stockDetailWorkList)
                    {
                        slipDtlRegOrder++;
                        SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

                        //slipDetailAddInfoWork.DtlRelationGuid = stockDetailWork.DtlRelationGuid;
                        slipDetailAddInfoWork.DtlRelationGuid = Guid.Empty;
                        slipDetailAddInfoWork.GoodsEntryDiv = 0;
                        slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceUpdateDiv = 0;
                        slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;
                        slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;
                        slipDetailAddInfoWork.AddUpRemDiv = 0;

                        slipDetailAddInfoWorkAry.Add(slipDetailAddInfoWork);
                        stockDetailWorkAry.Add(stockDetailWork);
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // �d�����(CustomSerializeArrayList)�̍쐬
                    //-----------------------------------------------------------
                    # region �d�����(CustomSerializeArrayList)�̍쐬
                    CustomSerializeArrayList grpAry = new CustomSerializeArrayList();
                    grpAry.Add(stockSlipWork);
                    grpAry.Add(stockDetailWorkAry);
                    grpAry.Add(slipDetailAddInfoWorkAry);

                    paraList.Add(grpAry);
                    # endregion
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

        # region �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�ݒ菈��
        /// </summary>
        /// <param name="optWorkSettinType"></param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork(OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork)
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;                     // ����N�_(0:���� 1:�d�� 2:�d�����㓯���v��)
            iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().AcpOdrrAddUpRemDiv;     // �󒍃f�[�^�v��c�敪
            iOWriteCtrlOptWork.ShipmAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().ShipmAddUpRemDiv;         // �o�׃f�[�^�v��c�敪
            iOWriteCtrlOptWork.EstimateAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().EstmateAddUpRemDiv;    // ���σf�[�^�v��c�敪
            iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().RetGoodsStockEtyDiv;   // �ԕi���݌ɓo�^�敪
            iOWriteCtrlOptWork.RemainCntMngDiv = this._uoeSndRcvCtlInitAcs.GetAllDefSet().RemainCntMngDiv;            // �c���Ǘ��敪
            iOWriteCtrlOptWork.SupplierSlipDelDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SupplierSlipDelDiv;     // �d���`�[�폜�敪
            iOWriteCtrlOptWork.CarMngDivCd = 0;                                                                       // �ԗ��Ǘ��}�X�^�o�^�敪(0:�o�^���Ȃ� 1:�o�^����)
            switch (optWorkSettinType)
            {
                case OptWorkSettingType.Write:
                    break;
                case OptWorkSettingType.Read:
                    break;
            }
        }
        # endregion


    }
}
