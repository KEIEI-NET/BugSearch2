//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌Ɉꗗ�\
// �v���O�����T�v   : �݌Ɉꗗ�\�Ŏg�p����f�[�^���擾����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����@�m
// �� �� ��  2007/03/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007/10/05  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/01/24  �C�����e : DC.NS�Ή��i�s��Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/10/08  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/01/29  �C�����e : ��Q�Ή�10566(�����[�g���o���ʂ̃\�[�g�����ǉ��Ax�������ڂ͓��L�[�̏ꍇ���Z����)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/13  �C�����e : �s��Ή�[12371][12480]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/25  �C�����e : �s��Ή�[12797]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/03  �C�����e : �s��Ή�[12373]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/13  �C�����e : �s��Ή�[13162]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/12  �C�����e : �s��Ή�[13447]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/17  �C�����e : �s��Ή�[13530]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ���� ���n
// �C �� ��  2011/03/14  �C�����e : ���x�`���[�j���O
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �݌Ɉꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉꗗ�\�ɃA�N�Z�X����N���X�ł��B</br>
    /// <br>Programer  : 23010�@�����@�m</br>
    /// <br>Date       : 2007.03.22</br>
    /// <br>Update Note: 2007.10.05 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.01.24 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή��i�s��Ή��j</br>
    /// <br>Update Note: 2008/10/08        �Ɠc �M�u</br>
    /// <br>			 �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2009/01/29 30452 ��� �r��</br>
    /// <br>			 �E��Q�Ή�10566(�����[�g���o���ʂ̃\�[�g�����ǉ��Ax�������ڂ͓��L�[�̏ꍇ���Z����)</br>
    /// <br>           : 2009/03/13       �Ɠc �M�u�@�s��Ή�[12371][12480]</br>
    /// <br>           : 2009/03/25       �Ɠc �M�u�@�s��Ή�[12797]</br>
    /// <br>           : 2009/04/03       �Ɠc �M�u�@�s��Ή�[12373]</br>
    /// <br>           : 2009/04/13       �Ɠc �M�u�@�s��Ή�[13162]</br>
    /// <br>           : 2009/06/12       �Ɠc �M�u�@�s��Ή�[13447]</br>
    /// <br>           : 2009/06/17       �Ɠc �M�u�@�s��Ή�[13530]</br>
    /// </remarks>
	public class StockListAcs
	{
  	    // ===================================================================================== //
        //  �O���񋟒萔
        // ===================================================================================== //
	    #region public constant
	    /// <summary>�S���_���R�[�h�p���_�R�[�h</summary>
        public const string CT_AllSectionCode = "000000";
	    #endregion
    
	    // ===================================================================================== //
        //  �X�^�e�B�b�N�ϐ�
        // ===================================================================================== //
        #region static variable

        /// <summary>�����_�R�[�h</summary>
        private static string mySectionCode               = "";
		/// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
		private static PrtOutSet prtOutSetData            = null;
        /// <summary>�݌ɊǗ��S�̐ݒ�f�[�^�N���X</summary>
        private static StockMngTtlSt stockMngTtlStData        = null; 
		
	    #endregion

        // ===================================================================================== //
        //  �����g�p�ϐ�
        // ===================================================================================== //
        #region private member
		
	    /// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
	    private static PrtOutSetAcs prtOutSetAcs         = null;
		/// <summary>����pDateSet</summary>
		public DataSet _printDataSet;
        /// <summary>�݌ɊǗ��S�̐ݒ�A�N�Z�X�N���X</summary>
	    private static StockMngTtlStAcs stockMngTtlStAcs = null;
        /// <summary>���[�J�[�}�X�^�A�N�Z�X�N���X</summary>
        private MakerAcs _makerAcs = null;
        /// <summary>���i�}�X�^�A�N�Z�X�N���X</summary>
        private GoodsAcs _goodsAcs = null;
	    #endregion
        
        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant

        /// <summary>�݌Ɉꗗ�\�f�[�^�e�[�u����</summary>
        private const string StockListDataTable = MAZAI02074EA.StockListDataTable;
        /// <summary>�݌Ɉꗗ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string StockListCommonBuffDataTable = MAZAI02074EA.StockListCommonBuffDataTable;
        
        #endregion
        
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �R���X�g���N�^�[
        /// <summary>
        /// �݌Ɉꗗ�\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public StockListAcs()
        {
			// ����pDataSet
		    this._printDataSet	= new DataSet();
		    DataSetColumnConstruction(ref this._printDataSet);

            // ---ADD 2009/03/25 �s��Ή�[12797] -------------------------------------->>>>>
            string msg = string.Empty;
            _goodsAcs = new GoodsAcs();
            _goodsAcs.IsGetSupplier = true;         //ADD 2009/04/13 �s��Ή�[13162]
            _goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            // ---ADD 2009/03/25 �s��Ή�[12797] --------------------------------------<<<<<
        }
        #endregion

        // ===================================================================================== //
        // �ÓI�R���X�g���N�^
        // ===================================================================================== //
        #region �ÓI�R���X�g���N�^�[

		/// <summary>
        /// �݌Ɉꗗ�\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010�@�����@�m</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        static StockListAcs()
        {
		    // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
		    prtOutSetAcs       = new PrtOutSetAcs();
			
            stockMngTtlStAcs   = new StockMngTtlStAcs();
		    // ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				mySectionCode = loginEmployee.BelongSectionCode;
		    }
	    }

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �v���p�e�B
          
      	#endregion

        // ===================================================================================== //
        // �O���񋟊֐�
        // ===================================================================================== //
        #region public method
		
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			prtOutSet  = null;
			message = "";	
			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (prtOutSetData != null)
				{
					prtOutSet = prtOutSetData.Clone(); 
					status    = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				} 
				else 
				{
					status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							prtOutSet = prtOutSetData.Clone();	
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
							prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
						default:
							prtOutSet = new PrtOutSet();
							message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂����B";
							break;
					}
				}
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}

        /// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^�Ǎ�
		/// </summary>
		/// <param name="stockMngTtlSt">�݌ɊǗ��S�̐ݒ�}�X�^�f�[�^�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̍݌ɊǗ��S�̐ݒ�̓Ǎ����s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
        public int ReadStockMngTtlSt(out StockMngTtlSt stockMngTtlSt, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			stockMngTtlSt  = null;
			message = "";
	        try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (stockMngTtlStData != null)
				{
					stockMngTtlSt = stockMngTtlStData.Clone(); 
					status    = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				} 
				else 
				{
					status = stockMngTtlStAcs.Read(out stockMngTtlSt, LoginInfoAcquisition.EnterpriseCode,0);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							stockMngTtlSt = stockMngTtlSt.Clone();
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
							stockMngTtlSt = new StockMngTtlSt();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
						default:
							stockMngTtlSt = new StockMngTtlSt();
							message = "�݌ɊǗ��S�̐ݒ�̓Ǎ��Ɏ��s���܂����B";
							break;
					}
				}
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			return status;
        }

		/// <summary>
        /// �݌Ɉꗗ�\�f�[�^����������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static�������������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
     		// --�e�[�u���s������-----------------------
			// ���o���ʃf�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[StockListDataTable] != null)
			{
                this._printDataSet.Tables[StockListDataTable].Rows.Clear();
			}
			// ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[StockListCommonBuffDataTable] != null)
			{
                this._printDataSet.Tables[StockListCommonBuffDataTable].Rows.Clear();
			}
		}
	
	    /// <summary>
        /// �݌Ɉꗗ�\�f�[�^�擾����
		/// </summary>
        /// <param name="stockListCndtn"></param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : �Ώ۔͈͂̍݌Ɉꗗ�\�f�[�^���擾���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
        public int Search(StockListCndtn stockListCndtn, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message    = "";
            ConstantManagement.LogicalMode logicalmode = new ConstantManagement.LogicalMode();
            IStockListWorkDB _iStockListWorkDB = (IStockListWorkDB)MediationStockListWorkDB.GetStockListWorkDB();
            object stockListRltWorkObj = null;

			try
			{           
				//StaticMemory�@������
				InitializeCustomerLedger();
                StockListCndtnWork stockListCndtnWork = new StockListCndtnWork();
                /* --- DEL 2008/10/08 �啝�ύX(�ǉ����ڂ���������������) --------------------------------------------------------------->>>>>
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.EnterPriseCode = stockListCndtn.EnterPriseCode;    // ��ƃR�[�h
                stockListCndtnWork.EnterpriseCode = stockListCndtn.EnterpriseCode;      // ��ƃR�[�h
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                stockListCndtnWork.DepositStockSecCodeList = stockListCndtn.DepositStockSecCodeList;  // �I���݌Ɍv�㋒�_�R�[�h
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_MakerCode = stockListCndtn.St_MakerCode;        // �J�n���[�J�[�R�[�h
                //stockListCndtnWork.Ed_MakerCode = stockListCndtn.Ed_MakerCode;        // �I�����[�J�[�R�[�h
                //stockListCndtnWork.St_GoodsCode = stockListCndtn.St_GoodsCode;        // �J�n���i�R�[�h
                //stockListCndtnWork.Ed_GoodsCode = stockListCndtn.Ed_GoodsCode;        // �I�����i�R�[�h
                stockListCndtnWork.St_GoodsMakerCd = stockListCndtn.St_GoodsMakerCd;    // �J�n���[�J�[�R�[�h
                stockListCndtnWork.Ed_GoodsMakerCd = stockListCndtn.Ed_GoodsMakerCd;    // �I�����[�J�[�R�[�h
                stockListCndtnWork.St_GoodsNo = stockListCndtn.St_GoodsNo;              // �J�n���i�R�[�h
                stockListCndtnWork.Ed_GoodsNo = stockListCndtn.Ed_GoodsNo;              // �I�����i�R�[�h
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_SupplierStock = stockListCndtn.St_SupplierStock;  // �J�n�d���݌ɐ�
                //stockListCndtnWork.Ed_SupplierStock = stockListCndtn.Ed_SupplierStock;  // �I���d���݌ɐ�
                //stockListCndtnWork.St_TrustCount = stockListCndtn.St_TrustCount;      // �J�n�����
                //stockListCndtnWork.Ed_TrustCount = stockListCndtn.Ed_TrustCount;      // �I�������
                //--- DEL 2008/08/01 ----------<<<<<
                stockListCndtnWork.St_ShipmentPosCnt = stockListCndtn.St_ShipmentPosCnt;  // �J�n�o�׉\��
                stockListCndtnWork.Ed_ShipmentPosCnt = stockListCndtn.Ed_ShipmentPosCnt;  // �I���o�׉\��
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_LargeGoodsGanreCode = stockListCndtn.St_LargeGoodsGanreCode;    // �J�n���i�敪�O���[�v�R�[�h
                //stockListCndtnWork.Ed_LargeGoodsGanreCode = stockListCndtn.Ed_LargeGoodsGanreCode;    // �I�����i�敪�O���[�v�R�[�h
                //stockListCndtnWork.St_MediumGoodsGanreCode = stockListCndtn.St_MediumGoodsGanreCode;  // �J�n���i�敪�R�[�h
                //stockListCndtnWork.Ed_MediumGoodsGanreCode = stockListCndtn.Ed_MediumGoodsGanreCode;  // �I�����i�敪�R�[�h
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_DetailGoodsGanreCode = stockListCndtn.St_DetailGoodsGanreCode;  // �J�n���i�敪�ڍ׃R�[�h
                //stockListCndtnWork.Ed_DetailGoodsGanreCode = stockListCndtn.Ed_DetailGoodsGanreCode;  // �I�����i�敪�ڍ׃R�[�h
                //stockListCndtnWork.St_EnterpriseGanreCode = stockListCndtn.St_EnterpriseGanreCode;    // �J�n���Е��ރR�[�h
                //stockListCndtnWork.Ed_EnterpriseGanreCode = stockListCndtn.Ed_EnterpriseGanreCode;    // �I�����Е��ރR�[�h
                //--- DEL 2008/08/01 ----------<<<<<
                stockListCndtnWork.St_BLGoodsCode = stockListCndtn.St_BLGoodsCode;      // �J�n�a�k���i�R�[�h
                stockListCndtnWork.Ed_BLGoodsCode = stockListCndtn.Ed_BLGoodsCode;      // �I���a�k���i�R�[�h
                stockListCndtnWork.St_WarehouseCode = stockListCndtn.St_WarehouseCode;  // �J�n�q�ɃR�[�h
                stockListCndtnWork.Ed_WarehouseCode = stockListCndtn.Ed_WarehouseCode;  // �I���q�ɃR�[�h
                // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                stockListCndtnWork.St_LastStockDate = stockListCndtn.St_LastStockDate;  // �J�n�ŏI�d���N����
                stockListCndtnWork.Ed_LastStockDate = stockListCndtn.Ed_LastStockDate;  // �I���ŏI�d���N����
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_LastSalesDate = stockListCndtn.St_LastSalesDate;  // �J�n�ŏI�����
                //stockListCndtnWork.Ed_LastSalesDate = stockListCndtn.Ed_LastSalesDate;  // �I���ŏI�����
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_CarrierCode = stockListCndtn.St_CarrierCode;    // �J�n�L�����A�R�[�h
                //stockListCndtnWork.Ed_CarrierCode = stockListCndtn.Ed_CarrierCode;    // �I���L�����A�R�[�h
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_LastInventoryUpDate = stockListCndtn.St_LastInventoryUpDate;  // �J�n�ŏI�I���X�V��
                //stockListCndtnWork.Ed_LastInventoryUpDate = stockListCndtn.Ed_LastInventoryUpDate;  // �I���ŏI�I���X�V��
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_LastInventoryUpdate = stockListCndtn.St_LastInventoryUpdate;  // �J�n�ŏI�I���X�V��
                //stockListCndtnWork.Ed_LastInventoryUpdate = stockListCndtn.Ed_LastInventoryUpdate;  // �I���ŏI�I���X�V��
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_CellphoneModelCode = stockListCndtn.St_CellphoneModelCode;    // �J�n�@��R�[�h
                //stockListCndtnWork.Ed_CellphoneModelCode = stockListCndtn.Ed_CellphoneModelCode;    // �I���@��R�[�h
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                //stockListCndtnWork.StockDiv = stockListCndtn.StockDiv;  // �݌ɏ��   // DEL 2008.08.01
                   --- DEL 2008/10/08 ------------------------------------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------------------>>>>>
                stockListCndtnWork.EnterpriseCode = stockListCndtn.EnterpriseCode;                      // ��ƃR�[�h
                stockListCndtnWork.DepositStockSecCodeList = stockListCndtn.DepositStockSecCodeList;    // ���_�R�[�h���X�g

                stockListCndtnWork.St_LastStockDate = stockListCndtn.St_LastStockDate;                  // �Ώ۔N��From
                stockListCndtnWork.Ed_LastStockDate = stockListCndtn.Ed_LastStockDate;                  // �Ώ۔N��To
                stockListCndtnWork.StockCreateDate = stockListCndtn.StockCreateDate;                    // �݌ɓo�^��
                stockListCndtnWork.StockCreateDateFlg = (int)stockListCndtn.StockCreateDateFlg;         // �݌ɓo�^���@�@"�ȑO"��
                stockListCndtnWork.St_ShipmentPosCnt = stockListCndtn.St_ShipmentPosCnt;                // �o�א�From
                stockListCndtnWork.Ed_ShipmentPosCnt = stockListCndtn.Ed_ShipmentPosCnt;                // �o�א�To
                stockListCndtnWork.PartsManagementDivide1 = stockListCndtn.PartsManagementDivide1;      // �Ǘ��敪1
                stockListCndtnWork.PartsManagementDivide2 = stockListCndtn.PartsManagementDivide2;      // �Ǘ��敪2

                stockListCndtnWork.St_WarehouseCode = stockListCndtn.St_WarehouseCode;                  // �q��From
                stockListCndtnWork.Ed_WarehouseCode = stockListCndtn.Ed_WarehouseCode;                  // �q��To
                stockListCndtnWork.St_StockSupplierCode = stockListCndtn.St_StockSupplierCode;          // �d����From
                //stockListCndtnWork.Ed_StockSupplierCode = stockListCndtn.Ed_StockSupplierCode;          // �d����To       //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                stockListCndtnWork.Ed_StockSupplierCode = this.GetEndCode(stockListCndtn.Ed_StockSupplierCode, 6);  // �d����To               
                stockListCndtnWork.St_WarehouseShelfNo = stockListCndtn.St_WarehouseShelfNo;            // �I��From
                stockListCndtnWork.Ed_WarehouseShelfNo = stockListCndtn.Ed_WarehouseShelfNo;            // �I��To
                stockListCndtnWork.St_GoodsMakerCd = stockListCndtn.St_GoodsMakerCd;                    // ���[�J�[From
                //stockListCndtnWork.Ed_GoodsMakerCd = stockListCndtn.Ed_GoodsMakerCd;                    // ���[�J�[To     //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                stockListCndtnWork.Ed_GoodsMakerCd = this.GetEndCode(stockListCndtn.Ed_GoodsMakerCd, 4);            // ���[�J�[To
                stockListCndtnWork.St_BLGoodsCode = stockListCndtn.St_BLGoodsCode;                      // BL�R�[�hFrom
                //stockListCndtnWork.Ed_BLGoodsCode = stockListCndtn.Ed_BLGoodsCode;                      // BL�R�[�hTo     //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                stockListCndtnWork.Ed_BLGoodsCode = this.GetEndCode(stockListCndtn.Ed_BLGoodsCode, 5);              // BL�R�[�hTo
                stockListCndtnWork.St_GoodsNo = stockListCndtn.St_GoodsNo;                              // �i��From
                stockListCndtnWork.Ed_GoodsNo = stockListCndtn.Ed_GoodsNo;                              // �i��To
                // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------------------<<<<<

                //�f�[�^�擾
                status = _iStockListWorkDB.Search(out stockListRltWorkObj, stockListCndtnWork, 0, logicalmode);
                //--- TEST --------->>>>>
                //stockListRltWorkObj = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

                // �����[�g����f�[�^�̎擾              
                #region
               
                if (status == 0)
                {
                    ArrayList retObjArr = new ArrayList();
                    ArrayList margeList = new ArrayList();
                    retObjArr = (ArrayList)stockListRltWorkObj;   
                    //TODO:2007.06.01 H.NAKAMURA ADD
                    // -- DEL 2011/03/14 ---------------------------->>>
                    ////�݌ɑS�̐ݒ�}�X�^��Ǎ�(�݌ɕۗL���z�̍��ڂɃZ�b�g������z��]���@���ɕύX���邽��)
                    //StockMngTtlSt stockMngTtlSt = null;
                    //string mess = string.Empty;
                    ////int st = this.ReadStockMngTtlSt(out stockMngTtlSt,out mess);
                    //if(st != 0)
                    //{
                    //    //�Ǎ����s
                    //    status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    //    message = "�݌ɊǗ��S�̐ݒ�̓Ǎ��Ɏ��s���܂����B";
                    //    return status;
                    //}
                    // -- DEL 2011/03/14 ----------------------------<<<

                    // �I�ԃu���C�N����
                    int breakLength = stockListCndtn.WarehouseShelfNoBreakLength;
                    /* --- DEL 2008/10/08 �l�������͂̏ꍇ(0�œo�^���ꂽ�ꍇ)�A�ŏ��̃f�[�^���쐬����Ȃ��� -->>>>>
                    int supplierCode = 0;
                    int makerCode = 0;
                       --- DEL 2008/10/08 --------------------------------------------------------------------<<<<< */
                    // --- ADD 2008/10/08 -------------------------------------------------------------------->>>>>
                    string warehouseCode = string.Empty;        // �q�ɃR�[�h
                    string supplierCode = string.Empty;         // �d����R�[�h
                    string makerCode = string.Empty;            // ���[�J�[�R�[�h
                    string goodsNo = string.Empty;              // �i��
                    // --- ADD 2008/10/08 --------------------------------------------------------------------<<<<<
                    // --- ADD 2009/01/29 -------------------------------->>>>>
                    // ���o�א��v�Z����
                    double shipmentCnt = 0;
                    double shipmentCntBefore1 = 0;
                    double shipmentCntBefore2 = 0;
                    double shipmentCntBefore3 = 0;

                    // ���o�׋��z�v�Z����
                    double shipmentPrice = 0;
                    double shipmentPriceBefore1 = 0;
                    double shipmentPriceBefore2 = 0;
                    double shipmentPriceBefore3 = 0;
                    // --- ADD 2009/01/29 --------------------------------<<<<<
                    double stockTotalCnt = 0;
                    double stockTotalPrice = 0;
                    double cnt = 0;         //ADD 2009/04/03 �s��Ή�[12373]

                    DataRow dr = null;

                    /* ---DEL 2009/03/13 �s��Ή�[12371] -------------------->>>>>
                    // --- ADD 2009/01/29 -------------------------------->>>>>
                    // �L�[���Ƀ\�[�g
                    List<StockListResultWork> retObjGenArr = new List<StockListResultWork>();

                    foreach (StockListResultWork stockListResultWork in retObjArr)
                    {
                        retObjGenArr.Add(stockListResultWork);
                    }

                    retObjGenArr.Sort(this.ComparisonByKey);
                    // --- ADD 2009/01/29 -------------------------------->>>>>
                       ---DEL 2009/03/13 �s��Ή�[12371] --------------------<<<<< */
                    /* ---DEL 2009/04/03 �s��Ή�[12373] ------------------------->>>>>
                    // ---ADD 2009/03/13 �s��Ή�[12371] -------------------->>>>>
                    string key = string.Empty;
                    SortedList<string, StockListResultWork> retObjArrList = new SortedList<string, StockListResultWork>();
                    foreach (StockListResultWork stockListResultWork in retObjArr)
                    {
                        key = stockListResultWork.WarehouseCode.Trim().PadLeft(4, '0') +        // �q�ɃR�[�h
                              stockListResultWork.StockSupplierCode.ToString("000000") +        // �d����R�[�h
                              stockListResultWork.GoodsMakerCd.ToString("0000") +               // ���[�J�[�R�[�h
                              stockListResultWork.GoodsNo +                                     // �i��
                              stockListResultWork.AddUpYearMonth.ToString() +                   // �v��N��
                              stockListResultWork.StockCreateDate.ToString() +
                              stockListResultWork.WarehouseShelfNo.ToString() +
                              stockListResultWork.WarehouseName;
                        
                        retObjArrList.Add(key, stockListResultWork);
                    }
                    // ---ADD 2009/03/13 �s��Ή�[12371] --------------------<<<<<
                       ---DEL 2009/04/03 �s��Ή�[12373] -------------------------<<<<< */
                    // ---ADD 2009/04/03 �s��Ή�[12373] ------------------------->>>>>
                    //����L�\�[�g���@�ł͑啶���A�����������܂���ʂ���Ȃ��ׁA�s�\���I
                    //  �Ⴆ��abc0013�AABC0013�Aabc0014�AABC0014�Ƃ������ꍇ�A���L�̏���(�啶���A�������֌W�Ȃ�)�ŕ��ԈׁAabc��ABC�ł܂Ƃ߂鎖���ł��Ȃ��B
                    //  ���L�ł�ABC0013�AABC0014�Aabc0013�Aabc0014�̏�(�啶���A�������̏�)�ɕ��ԈׁAABC��abc�ł܂Ƃ߂鎖���ł���B
                    List<StockListResultWork> retObjGenArr = new List<StockListResultWork>();

                    foreach (StockListResultWork stockListResultWork in retObjArr)
                    {
                        retObjGenArr.Add(stockListResultWork);
                    }

                    retObjGenArr.Sort(this.ComparisonByKey1);
                    // ---DEL 2009/04/03 �s��Ή�[12373] -------------------------<<<<<

                    //foreach (StockListResultWork stockListResultWork in retObjGenArr)         //DEL 2009/03/13 �s��Ή�[12371]
                    //foreach (StockListResultWork stockListResultWork in retObjArrList.Values)   //ADD 2009/03/13 �s��Ή�[12371] �� DEL 2009/04/03 �s��Ή�[12373]
                    foreach (StockListResultWork stockListResultWork in retObjGenArr)               //ADD 2009/04/03 �s��Ή�[12373]
                    {
                        /* --- DEL 2008/10/08 1���׍쐬�̏����ύX�̈�(�d����A���[�J�[�@���@�q�ɁA�d����A���[�J�[�A�i��) ------------>>>>>
                        if (stockListResultWork.StockSupplierCode != supplierCode || stockListResultWork.GoodsMakerCd != makerCode) 
                        {
                            if (supplierCode != 0)
                            {
                                this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                            }

                            dr = this._printDataSet.Tables[StockListDataTable].NewRow();

                            supplierCode = stockListResultWork.StockSupplierCode;
                            makerCode = stockListResultWork.GoodsMakerCd;

                            stockTotalCnt = 0;
                            stockTotalPrice = 0;
                        }
                           --- DEL 2008/10/08 ----------------------------------------------------------------------------------------<<<<< */
                        // --- ADD 2008/10/08 ---------------------------------------------------------------------------------------->>>>>
                        if ((stockListResultWork.WarehouseCode.Trim().PadLeft(4,'0') != warehouseCode) ||
                            (stockListResultWork.StockSupplierCode.ToString("000000") != supplierCode) ||
                            (stockListResultWork.GoodsMakerCd.ToString("0000") != makerCode) ||
                            (stockListResultWork.GoodsNo != goodsNo))
                        {
                            // �ŏ��̃f�[�^�ȊO
                            if (warehouseCode != string.Empty)
                            {
                                /* ---DEL 2009/04/03 �s��Ή�[12373] ----------------------------------------->>>>>
                                // �쐬�������ׂ�ǉ�
                                this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                                   ---DEL 2009/04/03 �s��Ή�[12373] -----------------------------------------<<<<< */
                                // ---ADD 2009/04/03 �s��Ή�[12373] ----------------------------------------->>>>>
                                cnt = double.Parse(dr[MAZAI02074EA.ctCol_ShipmentCnt].ToString());
                                if (stockListCndtn.St_ShipmentPosCnt <= cnt && cnt <= stockListCndtn.Ed_ShipmentPosCnt)
                                {
                                    // �쐬�������ׂ�ǉ�
                                    this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                                }
                                // ---ADD 2009/04/03 �s��Ή�[12373] -----------------------------------------<<<<<
                            }

                            dr = this._printDataSet.Tables[StockListDataTable].NewRow();
                            
                            warehouseCode = stockListResultWork.WarehouseCode.Trim().PadLeft(4, '0');       // �q�ɃR�[�h
                            supplierCode = stockListResultWork.StockSupplierCode.ToString("000000");        // �d����R�[�h
                            makerCode = stockListResultWork.GoodsMakerCd.ToString("0000");                  // ���[�J�[�R�[�h
                            goodsNo = stockListResultWork.GoodsNo;                                          // �i��

                            // --- ADD 2009/01/29 -------------------------------->>>>>
                            shipmentCnt = 0;
                            shipmentCntBefore1 = 0;
                            shipmentCntBefore2 = 0;
                            shipmentCntBefore3 = 0;

                            shipmentPrice = 0;
                            shipmentPriceBefore1 = 0;
                            shipmentPriceBefore2 = 0;
                            shipmentPriceBefore3 = 0;
                            // --- ADD 2009/01/29 --------------------------------<<<<<

                            stockTotalCnt = 0;
                            stockTotalPrice = 0;
                        }
                        // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------<<<<<

                        //dr[MAZAI02074EA.ctCol_SectionCode]          = stockListResultWork.SectionCode;	        // ���_�R�[�h       // DEL 2008.08.01
                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_SectionName]        = stockListResultWork.SectionName;	            // ���_����
                        //dr[MAZAI02074EA.ctCol_MakerCode]          = stockListResultWork.MakerCode;	            // ���[�J�[�R�[�h
                        //dr[MAZAI02074EA.ctCol_SectionName]          = stockListResultWork.SectionGuideNm;	        // ���_�K�C�h����   // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_GoodsMakerCd]         = stockListResultWork.GoodsMakerCd;	            // ���[�J�[�R�[�h
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //dr[MAZAI02074EA.ctCol_MakerName]            = stockListResultWork.MakerName;	            // ���[�J�[����     // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_MakerName]            = this.GetMakerName(stockListCndtn.EnterpriseCode, stockListResultWork.GoodsMakerCd);   // ���[�J�[����     //ADD 2008/10/08 ����
                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_GoodsCode]          = stockListResultWork.GoodsCode;	            // ���i�R�[�h
                        dr[MAZAI02074EA.ctCol_GoodsNo]              = stockListResultWork.GoodsNo;	                // ���i�R�[�h
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        dr[MAZAI02074EA.ctCol_GoodsName]            = stockListResultWork.GoodsName;	            // ���i����
                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_StockUnitPrice]     = stockListResultWork.StockUnitPrice;	        // �d���P��
                        //dr[MAZAI02074EA.ctCol_StockUnitPrice]       = stockListResultWork.StockUnitPriceFl;	    // �d���P��         // DEL 2008.08.01
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //dr[MAZAI02074EA.ctCol_SupplierStock]        = stockListResultWork.SupplierStock;	        // �d���݌ɐ�       // DEL 2008.08.01
                        // 2008.01.24 �폜 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_TrustCount]           = stockListResultWork.TrustCount;	            // �����
                        // 2008.01.24 �폜 <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_ReservedCount]      = stockListResultWork.ReservedCount;	        // �\��
                        //dr[MAZAI02074EA.ctCol_AllowStockCnt]      = stockListResultWork.AllowStockCnt;	        // �����݌ɐ�
                        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_AcpOdrCount]          = stockListResultWork.AcpOdrCount;	        // �󒍐�
                        //dr[MAZAI02074EA.ctCol_SalesOrderCount]      = stockListResultWork.SalesOrderCount;	    // ������
                        //dr[MAZAI02074EA.ctCol_EntrustCnt]           = stockListResultWork.EntrustCnt;	            // �d���݌ɕ��ϑ���
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_TrustEntrustCnt]    = stockListResultWork.TrustEntrustCnt;	        // ������ϑ���
                        //dr[MAZAI02074EA.ctCol_SoldCnt]            = stockListResultWork.SoldCnt;	                // ���ؐ�
                        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                        //dr[MAZAI02074EA.ctCol_MovingSupliStock]     = stockListResultWork.MovingSupliStock;	    // �ړ����d���݌ɐ�     // DEL 2008.08.01
                        // 2008.01.24 �C�� >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_MovingTrustStock]   = stockListResultWork.MovingTrustStock;	        // �ړ�������݌ɐ�
                        //dr[MAZAI02074EA.ctCol_ShipmentPosCnt]       = stockListResultWork.ShipmentPosCnt;	        // �o�׉\��           // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_ShipmentPosCnt]       = stockListResultWork.ShipmentPosCnt;	        // �o�׉\��           //ADD 2008/10/08 ����
                        //dr[MAZAI02074EA.ctCol_ShipmentCnt]          = stockListResultWork.ShipmentCnt;            // �o�א�(���v��)
                        //dr[MAZAI02074EA.ctCol_ArrivalCnt]           = stockListResultWork.ArrivalCnt;             // ���א�(���v��)       // DEL 2008.08.01

                        // �o�׉\���擾�i�o�׉\�� = �d���݌ɐ� + ���א�(���v��) - �o�א�(���v��) - �ړ����d���݌ɐ� - �󒍐��j
                        //--- DEL 2008/08/01 ---------->>>>>
                        //double shipmentPosCnt = stockListResultWork.SupplierStock + stockListResultWork.ArrivalCnt - stockListResultWork.ShipmentCnt - stockListResultWork.MovingSupliStock - stockListResultWork.AcpOdrCount;
                        //dr[MAZAI02074EA.ctCol_ShipmentPosCnt]       = shipmentPosCnt;	                            // �o�׉\��
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2008.01.24 �C�� <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_PrdNumMngDiv]       = stockListResultWork.PrdNumMngDiv;	                                        // ���ԊǗ��敪
                        //dr[MAZAI02074EA.ctCol_PrdNumMngDivName]   = StockListCndtn.GetPrdNumMngDivName(stockListResultWork.PrdNumMngDiv);	    // ���ԊǗ��敪����
                        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_LastStockDate]        = stockListResultWork.LastStockDate;	        // �ŏI�d���N����
                        //dr[MAZAI02074EA.ctCol_LastSalesDate]        = stockListResultWork.LastSalesDate;	        // �ŏI�����
                        //dr[MAZAI02074EA.ctCol_LastInventoryUpdate]  = stockListResultWork.LastInventoryUpdate;	// �ŏI�I���X�V��
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_CellphoneModelCode] = stockListResultWork.CellphoneModelCode;	    // �@��R�[�h
                        //dr[MAZAI02074EA.ctCol_CellphoneModelName] = stockListResultWork.CellphoneModelName;	    // �@�햼��
                        //dr[MAZAI02074EA.ctCol_CarrierCode]        = stockListResultWork.CarrierCode;	            // �L�����A�R�[�h
                        //dr[MAZAI02074EA.ctCol_CarrierName]        = stockListResultWork.CarrierName;	            // �L�����A����
                        //dr[MAZAI02074EA.ctCol_SystematicColorCd]  = stockListResultWork.SystematicColorCd;	    // �n���F�R�[�h
                        //dr[MAZAI02074EA.ctCol_SystematicColorNm]  = stockListResultWork.SystematicColorNm;	    // �n���F����
                        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_LargeGoodsGanreCode]  = stockListResultWork.LargeGoodsGanreCode;	// ���i�敪�O���[�v�R�[�h
                        //dr[MAZAI02074EA.ctCol_LargeGoodsGanreName]  = stockListResultWork.LargeGoodsGanreName;	// ���i�敪�O���[�v����
                        //dr[MAZAI02074EA.ctCol_MediumGoodsGanreCode] = stockListResultWork.MediumGoodsGanreCode;	// ���i�敪�R�[�h
                        //dr[MAZAI02074EA.ctCol_MediumGoodsGanreName] = stockListResultWork.MediumGoodsGanreName;	// ���i�敪����
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_DetailGoodsGanreCode] = stockListResultWork.DetailGoodsGanreCode;   // ���i�敪�ڍ׃R�[�h
                        //dr[MAZAI02074EA.ctCol_DetailGoodsGanreName] = stockListResultWork.DetailGoodsGanreName;   // ���i�敪�ڍ׃R�[�h
                        //dr[MAZAI02074EA.ctCol_EnterpriseGanreCode]  = stockListResultWork.EnterpriseGanreCode;    // ���Е��ރR�[�h
                        //dr[MAZAI02074EA.ctCol_EnterpriseGanreName]  = stockListResultWork.EnterpriseGanreName;    // ���Е��ރR�[�h
                        //--- DEL 2008/08/01 ----------<<<<<
                        dr[MAZAI02074EA.ctCol_BLGoodsCode] = stockListResultWork.BLGoodsCode;                       // �a�k���i�R�[�h
                        //dr[MAZAI02074EA.ctCol_BLGoodsName]          = stockListResultWork.BLGoodsFullName;        // �a�k���i�R�[�h       // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_WarehouseCode]        = stockListResultWork.WarehouseCode;            // �q�ɃR�[�h
                        dr[MAZAI02074EA.ctCol_WarehouseName]        = stockListResultWork.WarehouseName;            // �q�ɃR�[�h
                        // 2008.01.24 �ǉ� >>>>>>>>>>>>>>>>>>>>
                        dr[MAZAI02074EA.ctCol_WarehouseShelfNo]     = stockListResultWork.WarehouseShelfNo;         // �q�ɒI��
                        // 2008.01.24 �ǉ� <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
                        dr[MAZAI02074EA.ctCol_MinimumStockCnt]      = stockListResultWork.MinimumStockCnt;	        // �Œ�݌ɐ�
                        dr[MAZAI02074EA.ctCol_MaximumStockCnt]      = stockListResultWork.MaximumStockCnt;	        // �ō��݌ɐ�
                        //dr[MAZAI02074EA.ctCol_NmlSalOdrCount]       = stockListResultWork.NmlSalOdrCount;	        // �������       // DEL 2008.08.01
                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_SalOdrLot]          = stockListResultWork.SalOdrLot;	            // �����P��
                        //dr[MAZAI02074EA.ctCol_SalOdrLot]            = stockListResultWork.SalesOrderUnit;         // �����P��         // DEL 2008.08.01
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

                        //�݌ɕ]���@(1:�ŏI�d�������@,2:�ړ����ϖ@,3:�ʒP���@)�ɂ�蔻��
                        //�ŏI�d�������@�̎��͎d���݌ɐ��~����������
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockMngTtlSt.StockPointWay == 1)
                        //{
                        //    // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //    //dr[MAZAI02074EA.ctCol_StockTotalPrice] = stockListResultWork.StockUnitPrice * (long)stockListResultWork.SupplierStock;
                        //    dr[MAZAI02074EA.ctCol_StockTotalPrice] = stockListResultWork.StockUnitPriceFl * (long)stockListResultWork.SupplierStock;
                        //    // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //}
                        //else
                        //{
                        //    //�ʕ]���@�̏ꍇ�̓��|�[�g���ŕ\���������Ă���B
                        //    dr[MAZAI02074EA.ctCol_StockTotalPrice]          = stockListResultWork.StockTotalPrice;  // �݌ɕۗL���z
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<

                        // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_SectionName_Detail] = stockListResultWork.SectionName;	            // ���_����(����)    
                        //dr[MAZAI02074EA.ctCol_SectionName_Detail] = stockListResultWork.SectionGuideNm;	        // ���_����(����)    // DEL 2008.08.01
                        // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //�\�[�g�p(�ŏI�d���N����)
                        //dr[MAZAI02074EA.ctCol_LastStockDate_sort]   = TDateTime.DateTimeToLongDate(stockListResultWork.LastStockDate);    // DEL 2008.08.01

                        //--- DEL 2008/08/01 ---------->>>>>
                        ////���[�J�[�R�[�h(����p)
                        //// 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        ////if (stockListResultWork.MakerCode == 0)
                        //if (stockListResultWork.GoodsMakerCd == 0)
                        //// 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //{
                        //    //�O�̏ꍇ�͈�����Ȃ�
                        //    dr[MAZAI02074EA.ctCol_MakerCode_Print] = "";
                        //}
                        //else
                        //{
                        //    // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //    //dr[MAZAI02074EA.ctCol_MakerCode_Print] = stockListResultWork.MakerCode.ToString();
                        //    dr[MAZAI02074EA.ctCol_MakerCode_Print] = stockListResultWork.GoodsMakerCd.ToString();
                        //    // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                        ////�L�����A�R�[�h(����p)
                        //if(stockListResultWork.CarrierCode == 0)
                        //{
                        //    //�O�̏ꍇ�͈�����Ȃ�
                        //    dr[MAZAI02074EA.ctCol_CarrierCode_Print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_CarrierCode_Print] = stockListResultWork.CarrierCode.ToString();
                        //}
                        ////�n���F�R�[�h(����p)
                        //if(stockListResultWork.SystematicColorCd == 0)
                        //{
                        //    //�O�̏ꍇ�͈�����Ȃ�
                        //    dr[MAZAI02074EA.ctCol_SystematicColorCd_Print] = "";
                        //
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_SystematicColorCd_Print] = stockListResultWork.SystematicColorCd.ToString();
                        //}
                        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<

                        //���i�敪�O���[�v�R�[�h(����p)
                        //dr[MAZAI02074EA.ctCol_LargeGoodsGanreCode_Print] = stockListResultWork.LargeGoodsGanreCode;       // DEL 2008.08.01
                        
                        //���i�敪�R�[�h(����p)                                           
                        //dr[MAZAI02074EA.ctCol_MediumGoodsGanreCode_Print] = stockListResultWork.MediumGoodsGanreCode;     // DEL 2008.08.01

                        // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                        //���i�敪�ڍ׃R�[�h(����p)                                           
                        //dr[MAZAI02074EA.ctCol_DetailGoodsGanreCode_Print] = stockListResultWork.DetailGoodsGanreCode;     // DEL 2008.08.01
                        // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

                        //�ŏI�d����(����p)
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockListResultWork.LastStockDate == DateTime.MinValue)
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastStockDate_print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastStockDate_print]  = TDateTime.DateTimeToString("YYYY/MM/DD",stockListResultWork.LastStockDate);
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<
                        // �ŏI�����(����p)
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockListResultWork.LastSalesDate == DateTime.MinValue)
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastSalesDate_print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastSalesDate_print] = TDateTime.DateTimeToString("YYYY/MM/DD",stockListResultWork.LastSalesDate);
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<
                        // �ŏI�I���X�V��(����p)
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockListResultWork.LastInventoryUpdate == DateTime.MinValue)
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastInventoryUpdate_print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastInventoryUpdate_print] = TDateTime.DateTimeToString("YYYY/MM/DD",stockListResultWork.LastInventoryUpdate);
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<

                        //--- ADD 2008/08/01 ---------->>>>>
                        /* ---DEL 2009/03/25 �s��Ή�[12797] -------------------------------------------->>>>>
                        // �݌ɔ�����R�[�h
                        dr[MAZAI02074EA.ctCol_StockSupplierCode] = stockListResultWork.StockSupplierCode;
                        // �d���旪��
                        dr[MAZAI02074EA.ctCol_SupplierSnm] = stockListResultWork.SupplierSnm;
                           ---DEL 2009/03/25 �s��Ή�[12797] --------------------------------------------<<<<< */
                        // ---ADD 2009/03/25 �s��Ή�[12797] -------------------------------------------->>>>>
                        if (stockListResultWork.StockSupplierCode == 0)
                        {
                            int supplierCd;
                            string supplierSnm;
                            this.GetGoodsMngInfo(stockListResultWork, out supplierCd, out supplierSnm);
                            dr[MAZAI02074EA.ctCol_StockSupplierCode] = supplierCd;                                  // �d����R�[�h
                            dr[MAZAI02074EA.ctCol_SupplierSnm] = supplierSnm;                                       // �d���旪��
                            dr[MAZAI02074EA.ctCol_Sort_CustomerCode] = supplierCd.ToString("000000");               // �\�[�g�p�@�d����R�[�h
                        }
                        else
                        {
                            dr[MAZAI02074EA.ctCol_StockSupplierCode] = stockListResultWork.StockSupplierCode;                       //�d����R�[�h
                            dr[MAZAI02074EA.ctCol_SupplierSnm] = stockListResultWork.SupplierSnm;                                   //�d���旪��
                            dr[MAZAI02074EA.ctCol_Sort_CustomerCode] = stockListResultWork.StockSupplierCode.ToString("000000");    // �\�[�g�p�@�d����R�[�h
                        }
                        // ---ADD 2009/03/25 �s��Ή�[12797] --------------------------------------------<<<<<

                        // ���i�Ǘ��敪�P
                        //dr[MAZAI02074EA.ctCol_DuplicationShelfNo1] = stockListResultWork.DuplicationShelfNo1;         //DEL 2008/10/08 ID�ύX
                        dr[MAZAI02074EA.ctCol_PartsManagementDivide1] = stockListResultWork.PartsManagementDivide1;     //ADD 2008/10/08

                        // ���i�Ǘ��敪�Q
                        //dr[MAZAI02074EA.ctCol_DuplicationShelfNo2] = stockListResultWork.DuplicationShelfNo2;         //DEL 2008/10/08 ID�ύX
                        dr[MAZAI02074EA.ctCol_PartsManagementDivide2] = stockListResultWork.PartsManagementDivide2;     //ADD 2008/10/08
                        // �v��N��
                        dr[MAZAI02074EA.ctCol_AddUpYearMonth] = TDateTime.DateTimeToLongDate(stockListResultWork.AddUpYearMonth);

                        // --- DEL 2009/01/29 -------------------------------->>>>>
                        //if (stockListCndtn.PublicationType == StockListCndtn.PublicationTypeState.ByShipmentCnt)
                        //{
                        //    if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCnt] = stockListResultWork.ShipmentCnt;            // �o�א� 
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCntBefore1] = stockListResultWork.ShipmentCnt;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCntBefore2] = stockListResultWork.ShipmentCnt;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCntBefore3] = stockListResultWork.ShipmentCnt;
                        //    }
                        //}
                        //else
                        //{
                        //    if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPrice] = stockListResultWork.ShipmentPrice;            // �o�׋��z 
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPriceBefore1] = stockListResultWork.ShipmentPrice;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPriceBefore2] = stockListResultWork.ShipmentPrice;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPriceBefore3] = stockListResultWork.ShipmentPrice;
                        //    }
                        //}
                        // --- DEL 2009/01/29 --------------------------------<<<<<
                        // --- ADD 2009/01/29 -------------------------------->>>>>
                        if (stockListCndtn.PublicationType == StockListCndtn.PublicationTypeState.ByShipmentCnt)
                        {
                            if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                            {
                                shipmentCnt += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCnt] = shipmentCnt; // �o�א�
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                            {
                                shipmentCntBefore1 += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCntBefore1] = shipmentCntBefore1;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                            {
                                shipmentCntBefore2 += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCntBefore2] = shipmentCntBefore2;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                            {
                                shipmentCntBefore3 += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCntBefore3] = shipmentCntBefore3;
                            }
                        }
                        else
                        {
                            if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                            {
                                // ---ADD 2009/04/03 �s��Ή�[12373] --------------------------------->>>>>
                                shipmentCnt += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCnt] = shipmentCnt; // �o�א�
                                // ---ADD 2009/04/03 �s��Ή�[12373] ---------------------------------<<<<<
                                shipmentPrice += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPrice] = shipmentPrice; // �o�׋��z
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                            {
                                shipmentPriceBefore1 += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPriceBefore1] = shipmentPriceBefore1;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                            {
                                shipmentPriceBefore2 += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPriceBefore2] = shipmentPriceBefore2;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                            {
                                shipmentPriceBefore3 += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPriceBefore3] = shipmentPriceBefore3;
                            }
                        }
                        // --- ADD 2009/01/29 --------------------------------<<<<<

                        if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-6)) // ADD 2009/01/29
                        {
                            stockTotalCnt += stockListResultWork.ShipmentCnt;
                            stockTotalPrice += stockListResultWork.ShipmentPrice;

                            dr[MAZAI02074EA.ctCol_ShipmentCntBeforeTotal] = stockTotalCnt;
                            dr[MAZAI02074EA.ctCol_ShipmentPriceBeforeTotal] = stockTotalPrice;
                        }

                        dr[MAZAI02074EA.ctCol_StockCreateDate] = this.GetDateText(stockListResultWork.StockCreateDate); // �݌ɓo�^��
                        /* ---DEL 2009/03/13 �s��Ή�[12371] ---------------------------------------------------------------->>>>>
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseCode] = stockListResultWork.WarehouseCode;       // �\�[�g�p�@�q�ɃR�[�h
                        dr[MAZAI02074EA.ctCol_Sort_GoodsMakerCd] = stockListResultWork.GoodsMakerCd;         // �\�[�g�p�@���i���[�J�[�R�[�h
                           ---DEL 2009/03/13 �s��Ή�[12371] ----------------------------------------------------------------<<<<< */
                        // ---ADD 2009/03/13 �s��Ή�[12371] ---------------------------------------------------------------->>>>>
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseCode] = stockListResultWork.WarehouseCode.Trim().PadLeft(4,'0');    // �\�[�g�p�@�q�ɃR�[�h
                        dr[MAZAI02074EA.ctCol_Sort_GoodsMakerCd] = stockListResultWork.GoodsMakerCd.ToString("0000");           // �\�[�g�p�@���i���[�J�[�R�[�h
                        //dr[MAZAI02074EA.ctCol_Sort_CustomerCode] = stockListResultWork.StockSupplierCode.ToString("000000");    // �\�[�g�p�@�d����R�[�h         //DEL 2009/03/25 �s��Ή�[12797]
                        // ---ADD 2009/03/13 �s��Ή�[12371] ----------------------------------------------------------------<<<<<

                        dr[MAZAI02074EA.ctCol_Sort_GoodsNo] = stockListResultWork.GoodsNo;                   // �\�[�g�p�@���i�ԍ�
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseShelfNo] = stockListResultWork.WarehouseShelfNo; // �\�[�g�p�@�q�ɒI��

                        // �I�ԃu���C�N�ݒ�
                        string warehouseShelfNoBreak = stockListResultWork.WarehouseShelfNo.PadRight(8, ' ').Substring(0, breakLength);
                        dr[MAZAI02074EA.ctCol_WarehouseShelfNoBreak] = warehouseShelfNoBreak;      // �q�ɒI�ԃu���C�N
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseShelfNoBreak] = warehouseShelfNoBreak; // �\�[�g�p�@�q�ɒI�ԃu���C�N
                        //--- ADD 2008/08/01 ----------<<<<<
                    }

                    //this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);           //DEL 2009/04/03 �s��Ή�[12373]
                    // ---ADD 2009/04/03 �s��Ή�[12373] ----------------------------------------->>>>>
                    cnt = double.Parse(dr[MAZAI02074EA.ctCol_ShipmentCnt].ToString());
                    if (stockListCndtn.St_ShipmentPosCnt <= cnt && cnt <= stockListCndtn.Ed_ShipmentPosCnt)
                    {
                        // �쐬�������ׂ�ǉ�
                        this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                    }
                    // ---ADD 2009/04/03 �s��Ή�[12373] -----------------------------------------<<<<<

                    this._printDataSet.Tables[StockListDataTable].CaseSensitive = true;             //ADD 2009/03/13 �s��Ή�[12480]

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }             
                else
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                #endregion
            }			
			catch (Exception ex)
			{
				status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

      		return status;    
		}
		
		#endregion

        # region �e�X�g�p

        private object GetTestData()
        {
            ArrayList list = new ArrayList();

            StockListResultWork work = new StockListResultWork();

            work.GoodsMakerCd           = 0001;                                     // ���[�J�[�R�[�h
            work.GoodsNo                = "0002";                                   // ���i�R�[�h
            work.GoodsName              = "ABCD";                                   // ���i����
            work.ShipmentPosCnt         = 100;                                      // �o�׉\��
            work.ShipmentCnt            = 50;                                       // �o�א�(���v��)
            work.BLGoodsCode            = 0003;                                     // �a�k���i�R�[�h
            work.WarehouseCode          = "01";		                                // �q�ɃR�[�h
            work.WarehouseName          = "AAAAA";		                            // �q�ɖ���
            work.WarehouseShelfNo       = "777";                                    // �q�ɒI��
            work.MinimumStockCnt        = 1;                                        // �Œ�݌ɐ�
            work.MaximumStockCnt        = 300;                                      // �ō��݌ɐ�
            work.StockSupplierCode      = 11;		                                // �݌ɔ�����R�[�h
            work.SupplierSnm            = "BBBBB";		                            // �d���旪��
            //work.DuplicationShelfNo1    = "1";                                      // ���i�Ǘ��敪�P
            //work.DuplicationShelfNo2    = "2";                                      // ���i�Ǘ��敪�Q
            work.PartsManagementDivide1 = "1";                                      // ���i�Ǘ��敪�P
            work.PartsManagementDivide2 = "2";                                      // ���i�Ǘ��敪�Q
            work.AddUpYearMonth = TDateTime.LongDateToDateTime(20080801);   // �v��N��
            work.ShipmentPrice          = 10000;                                    // �o�׋��z
            work.StockCreateDate        = TDateTime.LongDateToDateTime(20080801);   // �݌ɓo�^��

            list.Add(work);

            StockListResultWork work1 = new StockListResultWork();

            work1.GoodsMakerCd          = 0001;                                     // ���[�J�[�R�[�h
            work1.GoodsNo               = "0002";                                   // ���i�R�[�h
            work1.GoodsName             = "ABCD";                                   // ���i����
            work1.ShipmentPosCnt        = 100;                                      // �o�׉\��
            work1.ShipmentCnt           = 50;                                       // �o�א�(���v��)
            work1.BLGoodsCode           = 0003;                                     // �a�k���i�R�[�h
            work1.WarehouseCode         = "01";		                                // �q�ɃR�[�h
            work1.WarehouseName         = "AAAAA";		                            // �q�ɖ���
            work1.WarehouseShelfNo      = "777";                                    // �q�ɒI��
            work1.MinimumStockCnt       = 1;                                        // �Œ�݌ɐ�
            work1.MaximumStockCnt       = 300;                                      // �ō��݌ɐ�
            work1.StockSupplierCode     = 11;		                                // �݌ɔ�����R�[�h
            work1.SupplierSnm           = "BBBBB";		                            // �d���旪��
            //work1.DuplicationShelfNo1   = "1";                                      // ���i�Ǘ��敪�P
            //work1.DuplicationShelfNo2   = "2";                                      // ���i�Ǘ��敪�Q
            work1.PartsManagementDivide1 = "1";                                     // ���i�Ǘ��敪�P
            work1.PartsManagementDivide2 = "2";                                     // ���i�Ǘ��敪�Q
            work1.AddUpYearMonth = TDateTime.LongDateToDateTime(20080701);   // �v��N��
            work1.ShipmentPrice         = 10000;                                    // �o�׋��z
            work1.StockCreateDate       = TDateTime.LongDateToDateTime(20080701);   // �݌ɓo�^��

            list.Add(work1);

            StockListResultWork work2 = new StockListResultWork();

            work2.GoodsMakerCd          = 0001;                                     // ���[�J�[�R�[�h
            work2.GoodsNo               = "0002";                                   // ���i�R�[�h
            work2.GoodsName             = "ABCD";                                   // ���i����
            work2.ShipmentPosCnt        = 100;                                      // �o�׉\��
            work2.ShipmentCnt           = 50;                                       // �o�א�(���v��)
            work2.BLGoodsCode           = 0003;                                     // �a�k���i�R�[�h
            work2.WarehouseCode         = "02";		                                // �q�ɃR�[�h
            work2.WarehouseName         = "VWXYZ";		                            // �q�ɖ���
            work2.WarehouseShelfNo      = "777";                                    // �q�ɒI��
            work2.MinimumStockCnt       = 1;                                        // �Œ�݌ɐ�
            work2.MaximumStockCnt       = 300;                                      // �ō��݌ɐ�
            work2.StockSupplierCode     = 11;		                                // �݌ɔ�����R�[�h
            work2.SupplierSnm           = "BBBBB";		                            // �d���旪��
            //work2.DuplicationShelfNo1   = "1";                                      // ���i�Ǘ��敪�P
            //work2.DuplicationShelfNo2   = "2";                                      // ���i�Ǘ��敪�Q
            work2.PartsManagementDivide1 = "1";                                     // ���i�Ǘ��敪�P
            work2.PartsManagementDivide2 = "2";                                     // ���i�Ǘ��敪�Q
            work2.AddUpYearMonth = TDateTime.LongDateToDateTime(20080601);   // �v��N��
            work2.ShipmentPrice         = 10000;                                    // �o�׋��z
            work2.StockCreateDate       = TDateTime.LongDateToDateTime(20080701);   // �݌ɓo�^��

            list.Add(work2);


            StockListResultWork work3 = new StockListResultWork();

            work3.GoodsMakerCd          = 0002;                                     // ���[�J�[�R�[�h
            work3.GoodsNo               = "0003";                                   // ���i�R�[�h
            work3.GoodsName             = "BCDE";                                   // ���i����
            work3.ShipmentPosCnt        = 100;                                      // �o�׉\��
            work3.ShipmentCnt           = 50;                                       // �o�א�(���v��)
            work3.BLGoodsCode           = 0004;                                     // �a�k���i�R�[�h
            work3.WarehouseCode         = "03";		                                // �q�ɃR�[�h
            work3.WarehouseName         = "VWXYZ";		                            // �q�ɖ���
            work3.WarehouseShelfNo      = "777";                                    // �q�ɒI��
            work3.MinimumStockCnt       = 1;                                        // �Œ�݌ɐ�
            work3.MaximumStockCnt       = 300;                                      // �ō��݌ɐ�
            work3.StockSupplierCode     = 12;		                                // �݌ɔ�����R�[�h
            work3.SupplierSnm           = "CCCC";		                            // �d���旪��
            //work3.DuplicationShelfNo1   = "1";                                      // ���i�Ǘ��敪�P
            //work3.DuplicationShelfNo2   = "2";                                      // ���i�Ǘ��敪�Q
            work3.PartsManagementDivide1 = "1";                                     // ���i�Ǘ��敪�P
            work3.PartsManagementDivide2 = "2";                                     // ���i�Ǘ��敪�Q
            work3.AddUpYearMonth = TDateTime.LongDateToDateTime(20080601);   // �v��N��
            work3.ShipmentPrice         = 10000;                                    // �o�׋��z
            work3.StockCreateDate       = TDateTime.LongDateToDateTime(20080701);   // �݌ɓo�^��

            list.Add(work3);

            //StockAdjustResultWork work4 = new StockAdjustResultWork();

            //work4.SectionCode = "01";				// ���_�R�[�h
            //work4.SectionGuideNm = "���_01";		// ���_�K�C�h����
            //work4.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work4.AcPayTransCd = 0;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work4.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// �������t
            //work4.StockAdjustSlipNo = 4000;			// �݌ɒ����`�[�ԍ�
            //work4.StockAdjustRowNo = 4;				// �݌ɒ����s�ԍ�
            ////work4.MakerCode = 30;					// ���[�J�[�R�[�h
            //work4.MakerName = "�\�j�[";				// ���[�J�[����
            ////work4.GoodsCode = "50";					// ���i�R�[�h
            //work4.GoodsName = "SO901_���b�h";		// ���i����
            ////work4.ProductNumber = "S100000100";		// �����ԍ�
            ////work4.BfProductNumber = "S10000000";	// �ύX�O�����ԍ�
            ////work4.StockTelNo1 = "090-4568-1000";	// ���i�d�b�ԍ�1
            ////work4.BfStockTelNo1 = "090-5555-1111";	// �ύX�O���i�d�b�ԍ�1
            //work4.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work4.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work4.StockUnitPriceFl = 45000;			// �d���P��
            //work4.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work4.DtlNote = "���ה��l�E�E�E�E";		// ���ה��l
            //work4.AdjustCount = -1.0;				// ������
            //work4.SlipNote = "�`�[���l�E�E�E�E";	// �`�[���l
            ////work4.StockTelNo2 = "";					// ���i�d�b�ԍ�2
            ////work4.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work4.PrdNumMngDiv = 1;					// ���ԊǗ��敪 0:��,1:�L
            //work4.SupplierStock = 1.0;				// �d���݌ɐ�
            //work4.TrustCount = 0.0;					// �����
            ////work4.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work4.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work4.StockDiv = 0;						// �݌ɋ敪 0:���ЁA1:���
            ////work4.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work4.WarehouseCode = "0001";
            //work4.WarehouseName = "�q��01";

            //list.Add(work4);

            //StockAdjustResultWork work5 = new StockAdjustResultWork();

            //work5.SectionCode = "01";				// ���_�R�[�h
            //work5.SectionGuideNm = "���_01";		// ���_�K�C�h����
            //work5.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work5.AcPayTransCd = 0;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work5.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// �������t
            //work5.StockAdjustSlipNo = 4000;			// �݌ɒ����`�[�ԍ�
            //work5.StockAdjustRowNo = 0;				// �݌ɒ����s�ԍ�
            ////work5.MakerCode = 30;					// ���[�J�[�R�[�h
            //work5.MakerName = "�\�j�[";				// ���[�J�[����
            ////work5.GoodsCode = "50";					// ���i�R�[�h
            //work5.GoodsName = "SO901_���b�h";		// ���i����
            ////work5.ProductNumber = "S100000100";		// �����ԍ�
            ////work5.BfProductNumber = "S10000000";	// �ύX�O�����ԍ�
            ////work5.StockTelNo1 = "090-4568-1000";	// ���i�d�b�ԍ�1
            ////work5.BfStockTelNo1 = "090-5555-1111";	// �ύX�O���i�d�b�ԍ�1
            //work5.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work5.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work5.StockUnitPriceFl = 45000;			// �d���P��
            //work5.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work5.DtlNote = "���ה��l�E�E�E�E";		// ���ה��l
            //work5.AdjustCount = -1.0;				// ������
            //work5.SlipNote = "�`�[���l�E�E�E�E";	// �`�[���l
            ////work5.StockTelNo2 = "";					// ���i�d�b�ԍ�2
            ////work5.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work5.PrdNumMngDiv = 1;					// ���ԊǗ��敪 0:��,1:�L
            //work5.SupplierStock = 1.0;				// �d���݌ɐ�
            //work5.TrustCount = 0.0;					// �����
            ////work5.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work5.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work5.StockDiv = 0;						// �݌ɋ敪 0:���ЁA1:���
            ////work5.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work5.WarehouseCode = "0001";
            //work5.WarehouseName = "�q��01";

            //list.Add(work5);

            //StockAdjustResultWork work6 = new StockAdjustResultWork();

            //work6.SectionCode = "03";				// ���_�R�[�h
            //work6.SectionGuideNm = "���_03";		// ���_�K�C�h����
            //work6.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work6.AcPayTransCd = 0;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work6.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// �������t
            //work6.StockAdjustSlipNo = 3000;			// �݌ɒ����`�[�ԍ�
            //work6.StockAdjustRowNo = 0;				// �݌ɒ����s�ԍ�
            ////work6.MakerCode = 30;					// ���[�J�[�R�[�h
            //work6.MakerName = "�\�j�[";				// ���[�J�[����
            ////work6.GoodsCode = "50";					// ���i�R�[�h
            //work6.GoodsName = "SO901_���b�h";		// ���i����
            ////work6.ProductNumber = "S100000100";		// �����ԍ�
            ////work6.BfProductNumber = "S10000000";	// �ύX�O�����ԍ�
            ////work6.StockTelNo1 = "090-4568-1000";	// ���i�d�b�ԍ�1
            ////work6.BfStockTelNo1 = "090-5555-1111";	// �ύX�O���i�d�b�ԍ�1
            //work6.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work6.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work6.StockUnitPriceFl = 45000;			// �d���P��
            //work6.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work6.DtlNote = "���ה��l�E�E�E�E";		// ���ה��l
            //work6.AdjustCount = -1.0;				// ������
            //work6.SlipNote = "";					// �`�[���l
            ////work6.StockTelNo2 = "";					// ���i�d�b�ԍ�2
            ////work6.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work6.PrdNumMngDiv = 1;					// ���ԊǗ��敪 0:��,1:�L
            //work6.SupplierStock = 1.0;				// �d���݌ɐ�
            //work6.TrustCount = 0.0;					// �����
            ////work6.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work6.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work6.StockDiv = 0;						// �݌ɋ敪 0:���ЁA1:���
            ////work6.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work6.WarehouseCode = "0001";
            //work6.WarehouseName = "�q��01";

            //list.Add(work6);

            //StockAdjustResultWork work7 = new StockAdjustResultWork();

            //work7.SectionCode = "03";				// ���_�R�[�h
            //work7.SectionGuideNm = "���_03";		// ���_�K�C�h����
            //work7.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work7.AcPayTransCd = 0;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work7.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// �������t
            //work7.StockAdjustSlipNo = 4000;			// �݌ɒ����`�[�ԍ�
            //work7.StockAdjustRowNo = 0;				// �݌ɒ����s�ԍ�
            ////work7.MakerCode = 10;					// ���[�J�[�R�[�h
            //work7.MakerName = "�p�i�\�j�b�N";		// ���[�J�[����
            ////work7.GoodsCode = "20";					// ���i�R�[�h
            //work7.GoodsName = "P901_�u���[";		// ���i����
            ////work7.ProductNumber = "P100000005";		// �����ԍ�
            ////work7.BfProductNumber = "P10000000";	// �ύX�O�����ԍ�
            ////work7.StockTelNo1 = "090-8919-0000";	// ���i�d�b�ԍ�1
            ////work7.BfStockTelNo1 = "090-1111-2222";	// �ύX�O���i�d�b�ԍ�1
            //work7.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work7.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work7.StockUnitPriceFl = 45000;			// �d���P��
            //work7.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work7.DtlNote = "���ה��l�E�E�E�E";		// ���ה��l
            //work7.AdjustCount = -1.0;				// ������
            //work7.SlipNote = "";					// �`�[���l
            ////work7.StockTelNo2 = "";					// ���i�d�b�ԍ�2
            ////work7.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work7.PrdNumMngDiv = 1;					// ���ԊǗ��敪 0:��,1:�L
            //work7.SupplierStock = 1.0;				// �d���݌ɐ�
            //work7.TrustCount = 0.0;					// �����
            ////work7.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work7.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work7.StockDiv = 0;						// �݌ɋ敪 0:���ЁA1:���
            ////work7.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work7.WarehouseCode = "0001";
            //work7.WarehouseName = "�q��01";

            //list.Add(work7);

            //StockAdjustResultWork work8 = new StockAdjustResultWork();

            //work8.SectionCode = "03";				// ���_�R�[�h
            //work8.SectionGuideNm = "���_03";		// ���_�K�C�h����
            //work8.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work8.AcPayTransCd = 0;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work8.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// �������t
            //work8.StockAdjustSlipNo = 4000;			// �݌ɒ����`�[�ԍ�
            //work8.StockAdjustRowNo = 1;				// �݌ɒ����s�ԍ�
            ////work8.MakerCode = 10;					// ���[�J�[�R�[�h
            //work8.MakerName = "�p�i�\�j�b�N";		// ���[�J�[����
            ////work8.GoodsCode = "20";					// ���i�R�[�h
            //work8.GoodsName = "P901_�u���[";		// ���i����
            ////work8.ProductNumber = "P100000100";		// �����ԍ�
            ////work8.BfProductNumber = "P10000000";	// �ύX�O�����ԍ�
            ////work8.StockTelNo1 = "090-8919-1000";	// ���i�d�b�ԍ�1
            ////work8.BfStockTelNo1 = "090-1111-3333";	// �ύX�O���i�d�b�ԍ�1
            //work8.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work8.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work8.StockUnitPriceFl = 45000;			// �d���P��
            //work8.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work8.DtlNote = "���ה��l�E�E�E�E";		// ���ה��l
            //work8.AdjustCount = -1.0;				// ������
            //work8.SlipNote = "�`�[���l�E�E�E�E";	// �`�[���l
            ////work8.StockTelNo2 = "";					// ���i�d�b�ԍ�2
            ////work8.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work8.PrdNumMngDiv = 1;					// ���ԊǗ��敪 0:��,1:�L
            //work8.SupplierStock = 1.0;				// �d���݌ɐ�
            //work8.TrustCount = 0.0;					// �����
            ////work8.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work8.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work8.StockDiv = 0;						// �݌ɋ敪 0:���ЁA1:���
            ////work8.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work8.WarehouseCode = "0001";
            //work8.WarehouseName = "�q��01";

            //list.Add(work8);

            //StockAdjustResultWork work9 = new StockAdjustResultWork();

            //work9.SectionCode = "03";				// ���_�R�[�h
            //work9.SectionGuideNm = "���_03";		// ���_�K�C�h����
            //work9.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work9.AcPayTransCd = 0;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work9.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// �������t
            //work9.StockAdjustSlipNo = 4000;			// �݌ɒ����`�[�ԍ�
            //work9.StockAdjustRowNo = 2;				// �݌ɒ����s�ԍ�
            ////work9.MakerCode = 20;					// ���[�J�[�R�[�h
            //work9.MakerName = "�x�m��";				// ���[�J�[����
            ////work9.GoodsCode = "30";					// ���i�R�[�h
            //work9.GoodsName = "F901_���b�h";		// ���i����
            ////work9.ProductNumber = "F100000100";		// �����ԍ�
            ////work9.BfProductNumber = "F10000000";	// �ύX�O�����ԍ�
            ////work9.StockTelNo1 = "090-6534-1000";	// ���i�d�b�ԍ�1
            ////work9.BfStockTelNo1 = "090-8888-1111";	// �ύX�O���i�d�b�ԍ�1
            //work9.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work9.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work9.StockUnitPriceFl = 45000;			// �d���P��
            //work9.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work9.DtlNote = "���ה��l�E�E�E�E";		// ���ה��l
            //work9.AdjustCount = -1.0;				// ������
            //work9.SlipNote = "�`�[���l�E�E�E�E";	// �`�[���l
            ////work9.StockTelNo2 = "";					// ���i�d�b�ԍ�2
            ////work9.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work9.PrdNumMngDiv = 1;					// ���ԊǗ��敪 0:��,1:�L
            //work9.SupplierStock = 1.0;				// �d���݌ɐ�
            //work9.TrustCount = 0.0;					// �����
            ////work9.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work9.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work9.StockDiv = 0;						// �݌ɋ敪 0:���ЁA1:���
            ////work9.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work9.WarehouseCode = "0002";
            //work9.WarehouseName = "�q��02";

            //list.Add(work9);

            //StockAdjustResultWork work10 = new StockAdjustResultWork();

            //work10.SectionCode = "03";				// ���_�R�[�h
            //work10.SectionGuideNm = "���_03";		// ���_�K�C�h����
            //work10.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work10.AcPayTransCd = 0;				// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work10.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// �������t
            //work10.StockAdjustSlipNo = 4000;		// �݌ɒ����`�[�ԍ�
            //work10.StockAdjustRowNo = 3;			// �݌ɒ����s�ԍ�
            ////work10.MakerCode = 30;					// ���[�J�[�R�[�h
            //work10.MakerName = "�\�j�[";			// ���[�J�[����
            ////work10.GoodsCode = "50";				// ���i�R�[�h
            //work10.GoodsName = "SO901_���b�h";		// ���i����
            ////work10.ProductNumber = "S100000100";	// �����ԍ�
            ////work10.BfProductNumber = "S10000000";	// �ύX�O�����ԍ�
            ////work10.StockTelNo1 = "090-4568-1000";	// ���i�d�b�ԍ�1
            ////work10.BfStockTelNo1 = "090-5555-1111";	// �ύX�O���i�d�b�ԍ�1
            //work10.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work10.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work10.StockUnitPriceFl = 45000;		// �d���P��
            //work10.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work10.DtlNote = "���ה��l�E�E�E�E";	// ���ה��l
            //work10.AdjustCount = -1.0;				// ������
            //work10.SlipNote = "�`�[���l�E�E�E�E";	// �`�[���l
            ////work10.StockTelNo2 = "";				// ���i�d�b�ԍ�2
            ////work10.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work10.PrdNumMngDiv = 1;				// ���ԊǗ��敪 0:��,1:�L
            //work10.SupplierStock = 1.0;				// �d���݌ɐ�
            //work10.TrustCount = 0.0;				// �����
            ////work10.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work10.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work10.StockDiv = 0;					// �݌ɋ敪 0:���ЁA1:���
            ////work10.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work10.WarehouseCode = "0002";
            //work10.WarehouseName = "�q��02";

            //list.Add(work10);

            //StockAdjustResultWork work11 = new StockAdjustResultWork();

            //work11.SectionCode = "03";				// ���_�R�[�h
            //work11.SectionGuideNm = "���_03";		// ���_�K�C�h����
            //work11.AcPaySlipCd = 0;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
            //work11.AcPayTransCd = 0;				// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���
            //work11.AdjustDate = TDateTime.LongDateToDateTime(20070315);		// �������t
            //work11.StockAdjustSlipNo = 5000;		// �݌ɒ����`�[�ԍ�
            //work11.StockAdjustRowNo = 0;			// �݌ɒ����s�ԍ�
            ////work11.MakerCode = 30;					// ���[�J�[�R�[�h
            //work11.MakerName = "�\�j�[";			// ���[�J�[����
            ////work11.GoodsCode = "50";				// ���i�R�[�h
            //work11.GoodsName = "SO901_���b�h";		// ���i����
            ////work11.ProductNumber = "S100000100";	// �����ԍ�
            ////work11.BfProductNumber = "S10000000";	// �ύX�O�����ԍ�
            ////work11.StockTelNo1 = "090-4568-1000";	// ���i�d�b�ԍ�1
            ////work11.BfStockTelNo1 = "090-5555-1111";	// �ύX�O���i�d�b�ԍ�1
            //work11.InputAgenCd = "30";				// ���͒S���҃R�[�h
            //work11.InputAgenNm = "���� ���Y";		// ���͒S���Җ���
            //work11.StockUnitPriceFl = 45000;		// �d���P��
            //work11.BfStockUnitPriceFl = 35000;		// �ύX�O�d���P��
            //work11.DtlNote = "���ה��l�E�E�E�E";	// ���ה��l
            //work11.AdjustCount = -1.0;				// ������
            //work11.SlipNote = "�`�[���l�E�E�E�E";	// �`�[���l
            ////work11.StockTelNo2 = "";				// ���i�d�b�ԍ�2
            ////work11.BfStockTelNo2 = "";				// �ύX�O���i�d�b�ԍ�2
            ////work11.PrdNumMngDiv = 1;				// ���ԊǗ��敪 0:��,1:�L
            //work11.SupplierStock = 1.0;				// �d���݌ɐ�
            //work11.TrustCount = 0.0;				// �����
            ////work11.StockState = 0;					// �݌ɏ�� 0:�݌�,10:�����,20:�ϑ���,30:����,50:����v���,60:�\��,70:�ԕi,80:���o,81:����
            ////work11.BfStockState = 10;				// �ύX�O�݌ɏ��
            //work11.StockDiv = 0;					// �݌ɋ敪 0:���ЁA1:���
            ////work11.GoodsCodeStatus = 0;				// ���i��� 0:����,1:�s�Ǖi
            //work11.WarehouseCode = "0002";
            //work11.WarehouseName = "�q��02";

            //list.Add(work11);

            return (object)list;
        }

        # endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private method
		
		private void DataSetColumnConstruction(ref DataSet ds)
		{
			// ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.MAZAI02074EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// ���t������擾
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateText(DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
            {
                //return dateTime.ToString("yy/MM/dd");         //DEL 2008/10/08 �����ύX
                return dateTime.ToString("yyyy/MM/dd");         //ADD 2008/10/08
            }
            else
            {
                return string.Empty;
            }
        }

        // ---ADD 2009/04/03 �s��Ή�[12373] -------------------------------------------------------->>>>>
        /// <summary>
        /// �\�[�g�ݒ�
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparisonByKey1(object x, object y)
        {
            //��string.CompareOrdinal�F�啶���A����������ʂ���

            StockListResultWork stockListResultWork1 = (StockListResultWork)x;
            StockListResultWork stockListResultWork2 = (StockListResultWork)y;

            int ret;

            // �q��
            ret = string.CompareOrdinal(stockListResultWork1.WarehouseCode.Trim().PadLeft(4, '0'),
                                        stockListResultWork2.WarehouseCode.Trim().PadLeft(4, '0'));
            if (ret != 0)
            {
                return ret;
            }
            // �d����
            ret = string.CompareOrdinal(stockListResultWork1.StockSupplierCode.ToString("000000"),
                                        stockListResultWork2.StockSupplierCode.ToString("000000"));
            if (ret != 0)
            {
                return ret;
            }
            // ���[�J�[
            ret = string.CompareOrdinal(stockListResultWork1.GoodsMakerCd.ToString("0000"),
                                        stockListResultWork2.GoodsMakerCd.ToString("0000"));
            if (ret != 0)
            {
                return ret;
            }

            // �i��
            return string.CompareOrdinal(stockListResultWork1.GoodsNo, stockListResultWork2.GoodsNo);

        }
        // ---ADD 2009/04/03 �s��Ή�[12373] --------------------------------------------------------<<<<<

        /* ---DEL 2009/04/03 �s��Ή�[12373] -------------------------------------------------------->>>>>
        // --- ADD 2009/01/29 -------------------------------->>>>>
        /// <summary>
        /// �\�[�g�ݒ�
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparisonByKey(object x, object y)
        {
            // �󎚗p�̃\�[�g�ݒ��2071E�ł���Ă���̂ŁA�L�[���ڏ��͓K���ł悢
            StockListResultWork stockListResultWork1 = (StockListResultWork)x;
            StockListResultWork stockListResultWork2 = (StockListResultWork)y;

            if (stockListResultWork1.WarehouseCode.Trim().PadLeft(4, '0')
                .CompareTo(stockListResultWork2.WarehouseCode.Trim().PadLeft(4, '0')) == 0)
            {
                if (stockListResultWork1.StockSupplierCode.ToString("000000")
                    .CompareTo(stockListResultWork2.StockSupplierCode.ToString("000000")) == 0)
                {
                    if (stockListResultWork1.GoodsMakerCd.ToString("0000")
                        .CompareTo(stockListResultWork2.GoodsMakerCd.ToString("0000")) == 0)
                    {
                        return stockListResultWork1.GoodsNo
                        .CompareTo(stockListResultWork2.GoodsNo);
                    }
                    else
                    {
                        return stockListResultWork1.GoodsMakerCd.ToString("0000")
                        .CompareTo(stockListResultWork2.GoodsMakerCd.ToString("0000"));
                    }
                }
                else
                {
                    return stockListResultWork1.StockSupplierCode.ToString("000000")
                    .CompareTo(stockListResultWork2.StockSupplierCode.ToString("000000"));
                }
            }
            else
            {
                return stockListResultWork1.WarehouseCode.Trim().PadLeft(4, '0')
                .CompareTo(stockListResultWork2.WarehouseCode.Trim().PadLeft(4, '0'));
            }
        }
        // --- ADD 2009/01/29 --------------------------------<<<<<
           ---DEL 2009/04/03 �s��Ή�[12373] --------------------------------------------------------<<<<< */
        #endregion

        // --- ADD 2008/10/08 ---------------------------------------------------->>>>>
        /// <summary>
        /// ���[�J�[���̎擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        private string GetMakerName(string enterpriseCode, int makerCode)
        {
            if (makerCode == 0)
            {
                //return string.Empty;      //DEL 2009/03/25 �s��Ή�[12797]
                return "���o�^";            //ADD 2009/03/25 �s��Ή�[12797]
            }

            // �A�N�Z�X�N���X�C���X�^���X��
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();
            }

            // �ǂݍ���
            MakerUMnt makerUMnt = null;
            //int status = this._makerAcs.Read(out makerUMnt, enterpriseCode, makerCode);       //DEL 2009/04/13 �s��Ή�[13162]
            int status = this._goodsAcs.GetMaker(enterpriseCode, makerCode, out makerUMnt);     //ADD 2009/04/13 �s��Ή�[13162]
            if (status == 0)
            {
                //return makerUMnt.MakerShortName.TrimEnd();        //DEL 2009/03/25 �s��Ή�[12797]
                return makerUMnt.MakerName.TrimEnd();               //ADD 2009/03/25 �s��Ή�[12797]
            }
            else
            {
                //return string.Empty;      //DEL 2009/03/25 �s��Ή�[12797]
                return "���o�^";            //ADD 2009/03/25 �s��Ή�[12797]
            }
        }

        // ---ADD 2009/03/25 �s��Ή�[12797] --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���i�Ǘ����}�X�^�擾
        /// </summary>
        /// <param name="stockListResultWork"></param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
        private void GetGoodsMngInfo(StockListResultWork stockListResultWork, out int supplierCd, out string supplierSnm)
        {
            supplierCd = 0;
            supplierSnm = "";

            // ---ADD 2009/06/17 �s��Ή�[13530] --------------------------------->>>>>
            //�����ގ擾
            int goodsMGroup = 0;
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            this._goodsAcs.GetBLGoodsCd(stockListResultWork.BLGoodsCode, out blGoodsCdUMnt);
            if (blGoodsCdUMnt != null)
            {
                BLGroupU blGroupU = null;
                this._goodsAcs.GetBLGroup(LoginInfoAcquisition.EnterpriseCode, blGoodsCdUMnt.BLGloupCode, out blGroupU);
                if (blGroupU != null)
                {
                    goodsMGroup = blGroupU.GoodsMGroup;
                }
            }
            // ---ADD 2009/06/17 �s��Ή�[13530] ---------------------------------<<<<<

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;      //DEL 2009/06/12 �s��Ή�[13447]
            goodsUnitData.SectionCode = stockListResultWork.SectionCode;                        //ADD 2009/06/12 �s��Ή�[13447]
            goodsUnitData.GoodsMakerCd = stockListResultWork.GoodsMakerCd;
            goodsUnitData.GoodsNo = stockListResultWork.GoodsNo;
            goodsUnitData.BLGoodsCode = stockListResultWork.BLGoodsCode;
            goodsUnitData.GoodsMGroup = goodsMGroup;                                            //ADD 2009/06/17 �s��Ή�[13530]

            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);         //DEL 2009/04/13 �s��Ή�[13162]

            supplierCd = goodsUnitData.SupplierCd;
            if (supplierCd == 0)
            {
                supplierSnm = "���o�^";
            }
            else
            {
                //supplierSnm = goodsUnitData.SupplierSnm;                                  //DEL 2009/04/13 �s��Ή�[13162]
                // ---ADD 2009/04/13 �s��Ή�[13162] -------------------------------------------------------------------->>>>>
                SupplierWork supplierWork = null;
                int status = this._goodsAcs.GetSupplier(LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd, out supplierWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    supplierSnm = supplierWork.SupplierSnm;
                }
                else
                {
                    supplierSnm = string.Empty;
                }
                // ---ADD 2009/04/13 �s��Ή�[13162] --------------------------------------------------------------------<<<<<
            }
        }
        // ---ADD 2009/03/25 �s��Ή�[12797] ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// �I���R�[�h�擾����
        /// </summary>
        /// <param name="value">�l</param>
        /// <param name="length">����</param>
        /// <returns></returns>
        private int GetEndCode(int value, int length)
        {
            if ((value == 0) || (string.IsNullOrEmpty(value.ToString())))
            {
                return Int32.Parse(new string('9', (length)));
            }
            else
            {
                return value;
            }
        }
        // --- ADD 2008/10/08 ----------------------------------------------------<<<<<
    }
}
