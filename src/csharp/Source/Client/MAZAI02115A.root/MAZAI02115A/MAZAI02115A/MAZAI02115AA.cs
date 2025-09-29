//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�I���֘A�ꗗ�\(0�F�I�������\�A1�F�I�����ٕ\�A2�F�I���\)
// �v���O�����T�v   �F�I���֘A�ꗗ�\������EPDF�o�͂��s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2008/10/08     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�E �K�j
// �C����    2009/03/06     �C�����e�F��QID:12229�Ή��@�I�����E�I�����z�͎l�̌ܓ��ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/16     �C�����e�FMantis�y13141�z�c�Č�No.19 �[������
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�Ɠc �M�u
// �C����    2009/05/13     �C�����e�F�s��Ή�[13259]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�Ɠc �M�u
// �C����    2009/05/21     �C�����e�F�s��Ή�[13261][13262]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F���� ���n
// �C����    2009/09/15     �C�����e�F�s��Ή�[13918]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : ������
// �C �� ��  2009/12/04     �C�����e : �s��Ή�(PM.NS�ێ�˗��B�Ή�)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : ���M
// �C �� ��  2009/12/07     �C�����e : �s��Ή�(PM.NS�ێ�˗��B�Ή�)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00    �쐬�S�� : ������
// �C �� ��  2010/02/20     �C�����e : �s��Ή�(PM1005)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00    �쐬�S�� : ������
// �C �� ��  2010/03/02     �C�����e : �s��Ή�(PM1005)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00    �쐬�S�� : liyp
// �C �� ��  2011/01/11     �C�����e : �s��Ή�(PM1101B)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : �c����
// �C �� ��  2011/02/10     �C�����e : redmine#18865 �I����Q�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : liyp
// �C �� ��  2011/02/10     �C�����e : redmine#18871 �I����Q�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : �c����
// �C �� ��  2011/02/17     �C�����e : redmine#19025 ���o���Ԃɂ���
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : ����
// �C �� ��  2011/11/28     �C�����e : Redmine #8073 �I����Q�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S�� : �����H
// �C �� ��  2012/07/20     �C�����e : redmine#31158 �u�I�����ٕ\�v�̃T�[�o�[���׌y���Ƒ��x�A�b�v�̒���
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00    �쐬�S�� : yangyi
// �C �� ��  2013/03/01     �C�����e : 20130326�z�M���̑Ή��ARedmine#34175
//                                     �I���Ɩ��̃T�[�o�[���׌y��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11000606-00 �쐬�S�� : licb
// �� �� ��  K2014/03/10 �C�����e : �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����                                 
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;//add 2011/11/28 ���� Redmine #8073
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �I���֘A�ꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���֘A�ꗗ�\�ɃA�N�Z�X����N���X�ł��B</br>
    /// <br>Programer  : 23010�@�����@�m</br>
    /// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.14 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.02.13 980035 ���� ��`</br>
    /// <br>			 �E�I�����{���Ή��iDC.NS�Ή��j</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.10.08</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : ��QID:12229�Ή��@�I�����E�I�����z�͎l�̌ܓ��ɕύX</br>
    /// <br>Programmer : 30414 �E</br>
    /// <br>Date	   : 2009.03.06</br>
    /// <br>           : 2009/04/16 ���� �@�@�@�s��Ή�[13141]</br>
    /// <br>           : 2009/05/13 �Ɠc �M�u�@�s��Ή�[13259]</br>
    /// <br>           : 2009/05/21 �Ɠc �M�u�@�s��Ή�[13261][13262]</br>
    /// <br>Update Note: 2009/12/04 ������</br>
    /// <br>			 �s��Ή�(PM.NS�ێ�˗��B�Ή�)</br>
    /// <br>Update Note: 2009/12/07 ���M</br>
    /// <br>			 �s��Ή�(PM.NS�ێ�˗��B�Ή�)</br>
    /// <br>Update Note: 2010/02/20 ������</br>
    /// <br>			 �s��Ή�(PM1005)</br>
    /// <br>Update Note: 2010/03/02 ������</br>
    /// <br>			 �s��Ή�(PM1005)</br>
    /// <br>Update Note: 2011/01/11 liyp</br>
    /// <br>			 �s��Ή�(PM1101B)</br>
    /// <br>Update Note: 2011/02/10 �c����</br>
    /// <br>             redmine#18865 �I����Q�Ή�</br>
    /// <br>Update Note: 2011/02/17 �c����</br>
    /// <br>             redmine#19025 ���o���Ԃɂ���</br>
    /// <br>Update Note: 2011/11/28 ����</br>
    /// <br>             Redmine #8073 �I����Q�Ή�</br>
    /// <br>Update Note: 2012/07/20 �����H</br>
    /// <br>             redmine#31158 �u�I�����ٕ\�v�̃T�[�o�[���׌y���Ƒ��x�A�b�v�̒���</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
    /// </remarks>
	public class InventoryListCmnAcs
	{
  	    // ===================================================================================== //
        //  �O���񋟒萔
        // ===================================================================================== //
        // 2008.10.14 30413 ���� ���g�p�̂��ߍ폜 >>>>>>START
	    #region public constant
        ///// <summary>�S���_���R�[�h�p���_�R�[�h</summary>
        //public const string CT_AllSectionCode = "000000";
	    #endregion
        // 2008.10.14 30413 ���� ���g�p�̂��ߍ폜 <<<<<<END
	    
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

        ///// <summary>���i���}�X�^�L���b�V��</summary>// DEL 2010/03/02
        //private static List<List<GoodsUnitData>> _goodsUnitDataListList;// DEL 2010/03/02

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
        private StockMngTtlSt _stockMngTtlSt = null;                    //�݌ɊǗ��S�̐ݒ� //ADD 2011/01/11
        // ---ADD 2009/05/13 �s��Ή�[13259] ----------------->>>>>
        /// <summary>���_���ݒ�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs = null;
        // ---ADD 2009/05/13 �s��Ή�[13259] -----------------<<<<<

        private GoodsAcs _goodsAcs; //ADD yangyi 2013/03/01 Redmine#34175 

        #endregion
        
        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant

        /// <summary>�I���֘A�ꗗ�\�f�[�^�e�[�u����</summary>
        private const string InventoryListDataTable = MAZAI02114EA.InventoryListDataTable;
        /// <summary>�I���֘A�ꗗ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string InventoryListCommonBuffDataTable = MAZAI02114EA.InventoryListCommonBuffDataTable;
              
        #endregion
        
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �R���X�g���N�^�[
        /// <summary>
        /// �I���֘A�ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public InventoryListCmnAcs()
        {
			// ����pDataSet
		    this._printDataSet	= new DataSet();
		    DataSetColumnConstruction(ref this._printDataSet);

            //���_���ݒ�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();          //ADD 2009/05/13 �s��Ή�[13259]
            this._goodsAcs = null;                              //ADD yangyi 2013/03/01 Redmine#34175

        }
        #endregion

        // ===================================================================================== //
        // �ÓI�R���X�g���N�^
        // ===================================================================================== //
        #region �ÓI�R���X�g���N�^�[

		/// <summary>
        /// �I���֘A�ꗗ�\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010�@�����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        static InventoryListCmnAcs()
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
		/// <br>Date       : 2007.04.09</br>
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
		/// <br>Date       : 2007.04.09</br>
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
        /// �I���֘A�ꗗ�\�f�[�^����������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static�������������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
     		// --�e�[�u���s������-----------------------
			// ���o���ʃf�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[InventoryListDataTable] != null)
			{
                this._printDataSet.Tables[InventoryListDataTable].Rows.Clear();
			}
			// ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[InventoryListCommonBuffDataTable] != null)
			{
                this._printDataSet.Tables[InventoryListCommonBuffDataTable].Rows.Clear();
			}
		}

        // 2008.10.14 30413 ���� ���o���\�b�h��ύX >>>>>>START
        #region ������Search���\�b�h���폜
        ///// <summary>
        ///// �I���֘A�ꗗ�\�f�[�^�擾����
        ///// </summary>
        ///// <param name="inventSearchCndtnUI"></param>
        ///// <param name="message">�G���[���b�Z�[�W</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �Ώ۔͈͂̒I���֘A�ꗗ�\�f�[�^���擾���܂��B</br>
        ///// <br>Programmer : 23010 �����@�m</br>
        ///// <br>Date       : 2007.04.09</br>
        ///// </remarks>
        //public int Search(InventSearchCndtnUI inventSearchCndtnUI, out string message)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    message    = "";
        //    ConstantManagement.LogicalMode logicalmode = new ConstantManagement.LogicalMode();
        //    IInventInputSearchDB _iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
        //    object inventInputRltWorkObj = null;
				
        //    try
        //    {           
        //        //StaticMemory�@������
        //        InitializeCustomerLedger();

        //        //TODO:�����[�g���ł��������
        //        InventInputSearchCndtnWork inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
				
        //        inventInputSearchCndtnWork.EnterpriseCode = inventSearchCndtnUI.EnterpriseCode;                     // ��ƃR�[�h
        //        inventInputSearchCndtnWork.SectionCode = inventSearchCndtnUI.SectionCode;                           // ���_�R�[�h
        //        inventInputSearchCndtnWork.St_MakerCode = inventSearchCndtnUI.St_MakerCode;                         // ���[�J�[�R�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_MakerCode = inventSearchCndtnUI.Ed_MakerCode;                         // ���[�J�[�R�[�h�I��
        //        inventInputSearchCndtnWork.St_GoodsNo = inventSearchCndtnUI.St_GoodsNo;                             // ���i�R�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_GoodsNo = inventSearchCndtnUI.Ed_GoodsNo;                             // ���i�R�[�h�I��
        //        // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.St_CellphoneModelCode = inventSearchCndtnUI.St_CellphoneModelCode;       // �@��R�[�h�J�n
        //        //inventInputSearchCndtnWork.Ed_CellphoneModelCode = inventSearchCndtnUI.Ed_CellphoneModelCode;       // �@��R�[�h�I��
        //        //inventInputSearchCndtnWork.St_CarrierCode        = inventSearchCndtnUI.St_CarrierCode;              // �L�����A�R�[�h
        //        //inventInputSearchCndtnWork.Ed_CarrierCode        = inventSearchCndtnUI.Ed_CarrierCode;              // �L�����A�R�[�h
        //        // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        //        inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // ���o�Ώۓ��t�敪
        //        inventInputSearchCndtnWork.St_LargeGoodsGanreCode = inventSearchCndtnUI.St_LargeGoodsGanreCode;     // ���i�啪�ރR�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_LargeGoodsGanreCode = inventSearchCndtnUI.Ed_LargeGoodsGanreCode;     // ���i�啪�ރR�[�h�I��
        //        inventInputSearchCndtnWork.St_MediumGoodsGanreCode = inventSearchCndtnUI.St_MediumGoodsGanreCode;   // ���i�����ރR�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_MediumGoodsGanreCode = inventSearchCndtnUI.Ed_MediumGoodsGanreCode;   // ���i�����ރR�[�h�I��
        //        inventInputSearchCndtnWork.St_WarehouseCode = inventSearchCndtnUI.St_WarehouseCode;                 // �q�ɃR�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_WarehouseCode = inventSearchCndtnUI.Ed_WarehouseCode;                 // �q�ɃR�[�h�I��
        //        // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.CompanyStockExtraDiv = inventSearchCndtnUI.CompanyStockExtraDiv;         // ���Ѝ݌ɒ��o�敪
        //        //inventInputSearchCndtnWork.TrustStockExtraDiv = inventSearchCndtnUI.TrustStockExtraDiv;             // ����݌ɒ��o�敪
        //        //inventInputSearchCndtnWork.EntrustCmpStockExtraDiv = inventSearchCndtnUI.EntrustCmpStockExtraDiv;   // �ϑ��i���Ёj�݌ɒ��o�敪
        //        //inventInputSearchCndtnWork.EntrustTrtStockExtraDiv = inventSearchCndtnUI.EntrustTrtStockExtraDiv;   // �ϑ��i����j�݌ɒ��o�敪
        //        //inventInputSearchCndtnWork.St_CarrierEpCode = inventSearchCndtnUI.St_CarrierEpCode;                 // ���Ǝ҃R�[�h�J�n
        //        //inventInputSearchCndtnWork.Ed_CarrierEpCode = inventSearchCndtnUI.Ed_CarrierEpCode;                 // ���Ǝ҃R�[�h�I��
        //        inventInputSearchCndtnWork.St_WarehouseShelfNo = inventSearchCndtnUI.St_WarehouseShelfNo;           // �I�ԊJ�n
        //        inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventSearchCndtnUI.Ed_WarehouseShelfNo;           // �I�ԏI��
        //        inventInputSearchCndtnWork.St_DetailGoodsGanreCode = inventSearchCndtnUI.St_DetailGoodsGanreCode;   // ���i�敪�ڍ׃R�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_DetailGoodsGanreCode = inventSearchCndtnUI.Ed_DetailGoodsGanreCode;   // ���i�敪�ڍ׃R�[�h�I��
        //        inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventSearchCndtnUI.St_EnterpriseGanreCode;     // ���Е��ރR�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventSearchCndtnUI.Ed_EnterpriseGanreCode;     // ���Е��ރR�[�h�I��
        //        inventInputSearchCndtnWork.St_BLGoodsCode = inventSearchCndtnUI.St_BLGoodsCode;                     // �a�k���i�R�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_BLGoodsCode = inventSearchCndtnUI.Ed_BLGoodsCode;                     // �a�k���i�R�[�h�I��
        //        // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
        //        inventInputSearchCndtnWork.St_CustomerCode = inventSearchCndtnUI.St_CustomerCode;                   // ���Ӑ�(�d����)�R�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_CustomerCode = inventSearchCndtnUI.Ed_CustomerCode;                   // ���Ӑ�(�d����)�R�[�h�I��
        //        inventInputSearchCndtnWork.St_ShipCustomerCode = inventSearchCndtnUI.St_ShipCustomerCode;           // �o�א擾�Ӑ�(�ϑ���)�R�[�h�J�n
        //        inventInputSearchCndtnWork.Ed_ShipCustomerCode = inventSearchCndtnUI.Ed_ShipCustomerCode;           // �o�א擾�Ӑ�(�ϑ���)�R�[�h�I��
        //        inventInputSearchCndtnWork.St_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryPreprDay);   // �J�n�I�������������t
        //        inventInputSearchCndtnWork.Ed_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.Ed_InventoryPreprDay);   // �I���I�������������t
        //        // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.St_InventoryDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryDay);             // �J�n�I�����{��
        //        //inventInputSearchCndtnWork.Ed_InventoryDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.Ed_InventoryDay);             // �I���I�����{��
        //        inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryDay);               // �I����
        //        // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
        //        inventInputSearchCndtnWork.St_InventorySeqNo = inventSearchCndtnUI.St_InventorySeqNo;               // �J�n�I���ʔ�
        //        inventInputSearchCndtnWork.Ed_InventorySeqNo = inventSearchCndtnUI.Ed_InventorySeqNo;               // �I���I���ʔ�
        //        inventInputSearchCndtnWork.DifCntExtraDiv = inventSearchCndtnUI.DifCntExtraDiv;                     // ���ٕ����o�敪
        //        inventInputSearchCndtnWork.StockCntZeroExtraDiv = inventSearchCndtnUI.StockCntZeroExtraDiv;         // �݌ɐ�0���o�敪
        //        inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = inventSearchCndtnUI.IvtStkCntZeroExtraDiv;       // �I���݌ɐ�0���o�敪
        //        // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.GrossPrintDiv = inventSearchCndtnUI.GrossPrintDiv;                       // �W�v�P��
        //        //inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelctedPaperKindDiv;             // ���[���
        //        inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelectedPaperKind;               // ���[���
        //        inventInputSearchCndtnWork.OutputAppointDiv = inventSearchCndtnUI.OutputAppointDiv;                 // �o�͎w��敪
        //        inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // ���o�Ώۓ��t�敪
        //        inventInputSearchCndtnWork.WarehouseDiv = 0;                                                        // �q�Ɏw��敪
        //        // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<

        //        // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        //        // �I�����ٕ\
        //        if (inventSearchCndtnUI.SelectedPaperKind == 1)
        //        {
        //            inventInputSearchCndtnWork.CalcStockAmountDiv  = 1;                 // �݌ɐ��Z�o�t���O
        //            inventInputSearchCndtnWork.CalcStockAmountDate = DateTime.MinValue; // �݌ɐ��Z�o���t
        //        }
        //        // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
        //        object ob = inventInputSearchCndtnWork;
        //        //�f�[�^�擾
        //        status = _iInventInputSearchDB.SearchPrint(out inventInputRltWorkObj, ob, 0, logicalmode);                      

        //        // �����[�g����f�[�^�̎擾              
        //        #region
                             
                

        //        if (status == 0)
        //        {
        //            ArrayList retObjArr = new ArrayList();
        //            //�I���f�[�^�������ʂ��Z�b�g
        //            CustomSerializeArrayList cstmAl = inventInputRltWorkObj as  CustomSerializeArrayList;

        //            foreach (ArrayList workList in cstmAl)
        //            {                       
        //                if ((workList != null) && (workList.Count != 0))
        //                {
        //                    if (workList[0].GetType() == typeof(InventInputSearchResultWork))
        //                    {
        //                        foreach (InventInputSearchResultWork work in workList)
        //                        {
        //                            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        //                            // �o�͎w��敪�`�F�b�N(�I�������\)
        //                            if (inventSearchCndtnUI.SelectedPaperKind == 0)
        //                            {
        //                                switch (inventSearchCndtnUI.OutputAppointDiv)
        //                                {
        //                                    case 0: // �S��
        //                                        {
        //                                            break;
        //                                        }
        //                                    case 1: // �I�������͕��̂�
        //                                        {
        //                                            if (work.InventoryDay != DateTime.MinValue) continue;
        //                                            break;
        //                                        }
        //                                    case 2: // ���ٕ��̂�
        //                                        {
        //                                            if (work.InventoryTolerancCnt == 0) continue;
        //                                            break;
        //                                        }
        //                                    case 3: // �d���I�ŗL��̂�
        //                                        {
        //                                            if ((work.DuplicationShelfNo1 == string.Empty) &&
        //                                                (work.DuplicationShelfNo2 == string.Empty)) continue;
        //                                            break;
        //                                        }
        //                                }
        //                            }
        //                            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
        //                            retObjArr.Add(work);
        //                        }
        //                    }
        //                }
        //            }

        //            //������0�Ȃ�return
        //            if (retObjArr.Count == 0)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //                return status;
        //            }
                          
        //            //�f�[�^�Z�b�g�֓W�J                     
        //            foreach (InventInputSearchResultWork inventInputSearchResultWork in retObjArr)
        //            {
        //                DataRow dr = this._printDataSet.Tables[InventoryListDataTable].NewRow();
	                                     
        //                dr[MAZAI02114EA.ctCol_SectionCode] = inventInputSearchResultWork.SectionCode;�@                 // ���_�R�[�h
        //                dr[MAZAI02114EA.ctCol_SectionGuideNm] = inventInputSearchResultWork.SectionGuideNm;�@           // ���_�K�C�h����
        //                dr[MAZAI02114EA.ctCol_InventorySeqNo] = inventInputSearchResultWork.InventorySeqNo;�@           // �I���ʔ�
        //                dr[MAZAI02114EA.ctCol_MakerCode] = inventInputSearchResultWork.GoodsMakerCd;�@                  // ���[�J�[�R�[�h
        //                dr[MAZAI02114EA.ctCol_MakerName] = inventInputSearchResultWork.MakerName;�@                     // ���[�J�[����
        //                dr[MAZAI02114EA.ctCol_GoodsCode] = inventInputSearchResultWork.GoodsNo;�@                       // ���i�R�[�h
        //                dr[MAZAI02114EA.ctCol_GoodsName] = inventInputSearchResultWork.GoodsName;�@                     // ���i����
        //                // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_CellphoneModelCode] = inventInputSearchResultWork.CellphoneModelCode;�@   // �@��R�[�h
        //                //dr[MAZAI02114EA.ctCol_CellphoneModelName] = inventInputSearchResultWork.CellphoneModelName;�@   // �@�햼��
        //                //dr[MAZAI02114EA.ctCol_CarrierCode] = inventInputSearchResultWork.CarrierCode;�@                 // �L�����A�R�[�h
        //                //dr[MAZAI02114EA.ctCol_CarrierName] = inventInputSearchResultWork.CarrierName;�@                 // �L�����A����
        //                //dr[MAZAI02114EA.ctCol_SystematicColorCd] = inventInputSearchResultWork.SystematicColorCd;�@     // �n���F�R�[�h
        //                //dr[MAZAI02114EA.ctCol_SystematicColorNm] = inventInputSearchResultWork.SystematicColorNm;�@     // �n���F����
        //                // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_LargeGoodsGanreCode] = inventInputSearchResultWork.LargeGoodsGanreCode;�@ // ���i�啪�ރR�[�h
        //                dr[MAZAI02114EA.ctCol_LargeGoodsGanreName] = inventInputSearchResultWork.LargeGoodsGanreName;�@ // ���i�啪�ޖ���
        //                dr[MAZAI02114EA.ctCol_MediumGoodsGanreCode] = inventInputSearchResultWork.MediumGoodsGanreCode; // ���i�����ރR�[�h
        //                dr[MAZAI02114EA.ctCol_MediumGoodsGanreName] = inventInputSearchResultWork.MediumGoodsGanreName; // ���i�����ޖ���
        //                dr[MAZAI02114EA.ctCol_Jan] = inventInputSearchResultWork.Jan;�@                                 // JAN�R�[�h
        //                dr[MAZAI02114EA.ctCol_StockUnitPrice] = inventInputSearchResultWork.StockUnitPriceFl;�@         // �d���P��
        //                dr[MAZAI02114EA.ctCol_BfStockUnitPrice] = inventInputSearchResultWork.BfStockUnitPriceFl;�@     // �ύX�O�d���P��
        //                dr[MAZAI02114EA.ctCol_StkUnitPriceChgFlg] = inventInputSearchResultWork.StkUnitPriceChgFlg;�@   // �d���P���ύX�t���O
        //                dr[MAZAI02114EA.ctCol_InventoryStkCnt] = inventInputSearchResultWork.InventoryStockCnt;�@       // �I���݌ɐ�
        //                dr[MAZAI02114EA.ctCol_InventoryTolerancCnt] = inventInputSearchResultWork.InventoryTolerancCnt; // �I���ߕs����
        //                dr[MAZAI02114EA.ctCol_InventoryPreprDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryPreprDay); // �I�������������t
        //                dr[MAZAI02114EA.ctCol_InventoryDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDay);�@         // �I�����{��
        //                dr[MAZAI02114EA.ctCol_InventoryUpDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastInventoryUpdate); // �ŏI�I���X�V��
        //                dr[MAZAI02114EA.ctCol_InventoryNewDiv] = inventInputSearchResultWork.InventoryNewDiv;�@         // �I���V�K�ǉ��敪
        //                // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_PrdNumMngDiv] = inventInputSearchResultWork.PrdNumMngDiv;�@               // ���ԊǗ��敪
        //                // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_LastStockDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastStockDate);�@       // �ŏI�d���N����
        //                dr[MAZAI02114EA.ctCol_StockCnt] = inventInputSearchResultWork.StockTotal;�@                     // �݌ɑ���
        //                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_StockTotalExec] = inventInputSearchResultWork.StockTotalExec;             // ���{�����됔
        //                dr[MAZAI02114EA.ctCol_StockTotalExec] = inventInputSearchResultWork.StockAmount;                // ���{�����됔
        //                dr[MAZAI02114EA.ctCol_InventoryDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDate);         // �I����
        //                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
        //                // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_ProductStockGuid] = inventInputSearchResultWork.ProductStockGuid;�@       // ���ԍ݌Ƀ}�X�^GUID
        //                // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_WarehouseCode] = inventInputSearchResultWork.WarehouseCode;�@             // �q�ɃR�[�h
        //                dr[MAZAI02114EA.ctCol_WarehouseName] = inventInputSearchResultWork.WarehouseName;�@             // �q�ɖ���
        //                // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_CarrierEpCode] = inventInputSearchResultWork.CarrierEpCode;�@             // ���Ǝ҃R�[�h
        //                //dr[MAZAI02114EA.ctCol_CarrierEpName] = inventInputSearchResultWork.CarrierEpName;�@             // ���ƎҖ���
        //                //dr[MAZAI02114EA.ctCol_StockDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.StockDate);�@          // �d����
        //                //dr[MAZAI02114EA.ctCol_ArrivalGoodsDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.ArrivalGoodsDay);// ���ד�
        //                //dr[MAZAI02114EA.ctCol_ProductNumber] = inventInputSearchResultWork.ProductNumber;�@             // �����ԍ�
        //                //dr[MAZAI02114EA.ctCol_StockTelNo1] = inventInputSearchResultWork.StockTelNo1;�@                 // ���i�d�b�ԍ�1
        //                //dr[MAZAI02114EA.ctCol_BfStockTelNo1] = inventInputSearchResultWork.BfStockTelNo1;�@             // �ύX�O���i�d�b�ԍ�1
        //                //dr[MAZAI02114EA.ctCol_StkTelNo1ChgFlg] = inventInputSearchResultWork.StkTelNo1ChgFlg;�@         // ���i�d�b�ԍ�1�ύX�t���O
        //                //dr[MAZAI02114EA.ctCol_StockTelNo2] = inventInputSearchResultWork.StockTelNo2;�@                 // ���i�d�b�ԍ�2
        //                //dr[MAZAI02114EA.ctCol_BfStockTelNo2] = inventInputSearchResultWork.BfStockTelNo2;�@             // �ύX�O���i�d�b�ԍ�2
        //                //dr[MAZAI02114EA.ctCol_StkTelNo2ChgFlg] = inventInputSearchResultWork.StkTelNo2ChgFlg;�@         // ���i�d�b�ԍ�2�ύX�t���O
        //                dr[MAZAI02114EA.ctCol_WarehouseShelfNo] = inventInputSearchResultWork.WarehouseShelfNo;�@       // �I��
        //                dr[MAZAI02114EA.ctCol_DuplicationShelfNo1] = inventInputSearchResultWork.DuplicationShelfNo1;�@ // �d���I��1
        //                dr[MAZAI02114EA.ctCol_DuplicationShelfNo2] = inventInputSearchResultWork.DuplicationShelfNo2;�@ // �d���I��2
        //                dr[MAZAI02114EA.ctCol_DetailGoodsGanreCode] = inventInputSearchResultWork.DetailGoodsGanreCode; // ���i�敪�ڍ׃R�[�h
        //                dr[MAZAI02114EA.ctCol_DetailGoodsGanreName] = inventInputSearchResultWork.DetailGoodsGanreName; // ���i�敪�ڍז���
        //                dr[MAZAI02114EA.ctCol_EnterpriseGanreCode] = inventInputSearchResultWork.EnterpriseGanreCode;�@ // ���Е��ރR�[�h
        //                dr[MAZAI02114EA.ctCol_EnterpriseGanreName] = inventInputSearchResultWork.EnterpriseGanreName;�@ // ���Е��ޖ���
        //                dr[MAZAI02114EA.ctCol_BLGoodsCode] = inventInputSearchResultWork.BLGoodsCode;�@                 // �a�k���i�R�[�h
        //                dr[MAZAI02114EA.ctCol_BLGoodsName] = inventInputSearchResultWork.BLGoodsName;�@                 // �a�k���i����
        //                // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_CustomerCode]    = inventInputSearchResultWork.CustomerCode;              // ���Ӑ�(�d����)�R�[�h
        //                dr[MAZAI02114EA.ctCol_CustomerName]    = inventInputSearchResultWork.CustomerName;              // ���Ӑ�(�d����)����
        //                dr[MAZAI02114EA.ctCol_CustomerName2]    = inventInputSearchResultWork.CustomerName2;            // ���Ӑ�(�d����)����2
        //                dr[MAZAI02114EA.ctCol_ShipCustomerCode]    = inventInputSearchResultWork.ShipCustomerCode;      // ���Ӑ�(�ϑ���)�R�[�h
        //                dr[MAZAI02114EA.ctCol_ShipCustomerName]    = inventInputSearchResultWork.ShipCustomerName;      // ���Ӑ�(�ϑ���)����
        //                dr[MAZAI02114EA.ctCol_ShipCustomerName2]   = inventInputSearchResultWork.ShipCustomerName2;     // ���Ӑ�(�ϑ���)����2
        //                // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_StockDiv_Print] = InventSearchCndtnUI.GetTargetStockDivName(inventInputSearchResultWork.StockDiv, inventInputSearchResultWork.StockState); //�݌ɋ敪  
        //                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_StockDiv_Print] = 0;                                                      // �݌ɋ敪  
        //                if (inventInputSearchResultWork.StockDiv == 0)                                                  // �݌ɋ敪  
        //                {
        //                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "����";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "���";
        //                }
        //                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
        //                // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<

        //                //�\�[�g�p
        //                // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //                ////�݌ɋ敪UI�p
        //                //dr[MAZAI02114EA.ctCol_UiSotckDiv] = InventSearchCndtnUI.GetUiStockDiv(inventInputSearchResultWork.StockDiv,inventInputSearchResultWork.StockState);
        //                // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<

        //                // ���ً��z(�݌Ɍ��P���~�݌ɉߕs������������(��))
        //                dr[MAZAI02114EA.ctCol_TolerancPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryTolerancCnt ;                 
        //                //�݌ɋ��z(�I�����~�݌Ɍ��P��(��))
        //                dr[MAZAI02114EA.ctCol_StockPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryStockCnt ;                
          
        //                //�ŏI�d����(����p)
        //                if(inventInputSearchResultWork.LastStockDate == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_LastStockDate_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_LastStockDate_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.LastStockDate);
        //                }
        //                //�I�������������t
        //                if(inventInputSearchResultWork.InventoryPreprDay == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.InventoryPreprDay);
        //                }
        //                //�I�����{��
        //                if(inventInputSearchResultWork.InventoryDay == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDay_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDay_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.InventoryDay);
        //                }
        //                 //�ŏI�I���X�V��
        //                if(inventInputSearchResultWork.LastInventoryUpdate == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.LastInventoryUpdate);
        //                }
        //                // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //                ////�d����
        //                //if(inventInputSearchResultWork.StockDate == DateTime.MinValue)
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_StockDate_Print] = "";
        //                //}
        //                //else
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_StockDate_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.StockDate);
        //                //}
        //                ////���ד�
        //                //if(inventInputSearchResultWork.ArrivalGoodsDay == DateTime.MinValue)
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_ArrivalGoodsDay_Print] = "";
        //                //}
        //                //else
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_ArrivalGoodsDay_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.ArrivalGoodsDay);
        //                //}
        //                ////���Ǝ҃R�[�h
        //                //if(inventInputSearchResultWork.CarrierEpCode == 0)
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_CarrierEpCode_Print] = "";
        //                //}
        //                //else
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_CarrierEpCode_Print] = inventInputSearchResultWork.CarrierEpCode.ToString();
        //                //}
        //                // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
        //                //�q�ɃR�[�h
        //                if(inventInputSearchResultWork.WarehouseCode == null)
        //                {
        //                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = inventInputSearchResultWork.WarehouseCode;
        //                }
        //                // 2007.09.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
        //                //�I�ԃu���C�N����
        //                dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = "";
        //                if (inventSearchCndtnUI.TurnOoverThePagesDiv == 1)
        //                {
        //                    // �o�͏�
        //                    // �q�Ɂ��I�� or �q�Ɂ��d���恨�I��
        //                    if ((inventSearchCndtnUI.SortDiv == 0) || (inventSearchCndtnUI.SortDiv == 4))
        //                    {
        //                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
        //                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
        //                        {
        //                            // �I�ԃu���C�N�����ȏ�̎��͌����ō��
        //                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
        //                        }
        //                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
        //                    }
        //                }
        //                // 2007.09.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
        //                // 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
        //                //�I����
        //                if (inventInputSearchResultWork.InventoryDate == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryDate);
        //                }
        //                // 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<
                        
                         
        //                this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);

        //            }
        //            status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;                   
        //        }                
        //        else
        //        {
        //            status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //        }

        //        #endregion
        //    }			
        //    catch (Exception ex)
        //    {
        //        status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        message = ex.Message;
        //    }

        //    return status;
        //}
        #endregion

        #region �ύX���Search���\�b�h
        /// <summary>
        /// �I���֘A�ꗗ�\�f�[�^�擾����
		/// </summary>
        /// <param name="inventSearchCndtnUI"></param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : �Ώ۔͈͂̒I���֘A�ꗗ�\�f�[�^���擾���܂��B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.10.14</br>
        /// <br>Update Note: 2010/03/02 ������</br>
        /// <br>             �I���\���x����Ή�</br>
        /// <br>Update Note: 2011/02/10 �c����</br>
        /// <br>             redmine#18865 �I����Q�Ή�</br>
		/// </remarks>
        public int Search(InventSearchCndtnUI inventSearchCndtnUI, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            ConstantManagement.LogicalMode logicalmode = new ConstantManagement.LogicalMode();
            IInventInputSearchDB _iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
            object inventInputRltWorkObj = null;

            try
            {
                //StaticMemory�@������
				InitializeCustomerLedger();

                // ���o�����i�[
                InventInputSearchCndtnWork inventInputSearchCndtnWork;

                // ���o�����p�����[�^�Z�b�g
                status = this.SearchParaSet(inventSearchCndtnUI, out inventInputSearchCndtnWork, out message);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                object ob = inventInputSearchCndtnWork;
                //�f�[�^�擾
                status = _iInventInputSearchDB.SearchPrint(out inventInputRltWorkObj, ob, 0, logicalmode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        //SetTebleRowFromRetList(inventSearchCndtnUI, (ArrayList)inventInputRltWorkObj);
                        // ----- ADD 2011/02/10 ------------------------------->>>>>
                        if (((ArrayList)inventInputRltWorkObj).Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                        // ----- ADD 2011/02/10 -------------------------------<<<<<
                        ArrayList retList = (ArrayList)inventInputRltWorkObj;

                        // ------------DEL 2010/03/02----------->>>>>
                        //if (inventSearchCndtnUI.SelectedPaperKind == 2)
                        //{
                        //    // �I���\�̏ꍇ�A���i���擾�̂��ߏ��i�A�N�Z�X�N���X���珤�i�A���f�[�^���擾
                        //    SetCacheGoodsUnitDataList((ArrayList)retList[0]);
                        //}
                        // ------------DEL 2010/03/02-----------<<<<<

                        SetTebleRowFromRetList(inventSearchCndtnUI, (ArrayList)retList[0]);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        // 2008.12.02 30413 ���� �Y���f�[�^�����̏ꍇ�Astatus�����̂܂ܕԂ� >>>>>>START
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        // 2008.12.02 30413 ���� �Y���f�[�^�����̏ꍇ�Astatus�����̂܂ܕԂ� <<<<<<END
                        break;
                    default:
                        message = "�I�������f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="inventSearchCndtnUI">UI���o�����N���X</param>
        /// <param name="inventInputSearchCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <br>Update Note : liyp 2011/01/11</br>
        /// <br>              �o�͏����ɐ��ʂƒI�ԂɊւ�������w���ǉ�����i�v�]�j</br>
        private int SearchParaSet(InventSearchCndtnUI inventSearchCndtnUI, out InventInputSearchCndtnWork inventInputSearchCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            inventInputSearchCndtnWork = new InventInputSearchCndtnWork();

            try
            {
                // ��ƃR�[�h
                inventInputSearchCndtnWork.EnterpriseCode = inventSearchCndtnUI.EnterpriseCode;                     // ��ƃR�[�h

                // 2008.10.31 30413 ���� ���_�R�[�h�ݒ���폜 >>>>>>START
                //// ���o�����p�����[�^�Z�b�g
                //if (inventSearchCndtnUI.CollectAddupSecCodeList.Length != 0)
                //{
                //    if (inventSearchCndtnUI.IsSelectAllSection)
                //    {
                //        // �S�Ђ̎�
                //        inventInputSearchCndtnWork.SectionCodes = null;
                //    }
                //    else
                //    {
                //        inventInputSearchCndtnWork.SectionCodes = inventSearchCndtnUI.CollectAddupSecCodeList;
                //    }
                //}
                //else
                //{
                //    inventInputSearchCndtnWork.SectionCodes = null;
                //}
                // 2008.10.31 30413 ���� ���_�R�[�h�ݒ���폜 <<<<<<END
                
                // 2008.10.14 30413 ���� ���o�����̋��_�R�[�h�̐ݒ�́H >>>>>>START
                //inventInputSearchCndtnWork.SectionCode = inventSearchCndtnUI.SectionCode;                           // ���_�R�[�h
                // 2008.10.14 30413 ���� ���o�����̋��_�R�[�h�̐ݒ�́H <<<<<<END

                // 2008.10.31 30413 ���� ���o�����̐ݒ���C�� >>>>>>START
                //inventInputSearchCndtnWork.St_MakerCode = inventSearchCndtnUI.St_MakerCode;                         // ���[�J�[�R�[�h�J�n
                //inventInputSearchCndtnWork.Ed_MakerCode = inventSearchCndtnUI.Ed_MakerCode;                         // ���[�J�[�R�[�h�I��
                //inventInputSearchCndtnWork.St_GoodsNo = inventSearchCndtnUI.St_GoodsNo;                             // ���i�R�[�h�J�n
                //inventInputSearchCndtnWork.Ed_GoodsNo = inventSearchCndtnUI.Ed_GoodsNo;                             // ���i�R�[�h�I��
                //inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // ���o�Ώۓ��t�敪
                //inventInputSearchCndtnWork.St_WarehouseCode = inventSearchCndtnUI.St_WarehouseCode;                 // �q�ɃR�[�h�J�n
                //inventInputSearchCndtnWork.Ed_WarehouseCode = inventSearchCndtnUI.Ed_WarehouseCode;                 // �q�ɃR�[�h�I��
                //inventInputSearchCndtnWork.St_WarehouseShelfNo = inventSearchCndtnUI.St_WarehouseShelfNo;           // �I�ԊJ�n
                //inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventSearchCndtnUI.Ed_WarehouseShelfNo;           // �I�ԏI��
                //inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventSearchCndtnUI.St_EnterpriseGanreCode;     // ���Е��ރR�[�h�J�n
                //inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventSearchCndtnUI.Ed_EnterpriseGanreCode;     // ���Е��ރR�[�h�I��
                //inventInputSearchCndtnWork.St_BLGoodsCode = inventSearchCndtnUI.St_BLGoodsCode;                     // �a�k���i�R�[�h�J�n
                //inventInputSearchCndtnWork.Ed_BLGoodsCode = inventSearchCndtnUI.Ed_BLGoodsCode;                     // �a�k���i�R�[�h�I��
                //inventInputSearchCndtnWork.St_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryPreprDay);   // �J�n�I�������������t
                //inventInputSearchCndtnWork.Ed_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.Ed_InventoryPreprDay);   // �I���I�������������t
                //inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryDay);               // �I����
                //inventInputSearchCndtnWork.InventoryDate = inventSearchCndtnUI.St_InventoryPreprDayDateTime;               // �I����
                //inventInputSearchCndtnWork.St_InventorySeqNo = inventSearchCndtnUI.St_InventorySeqNo;               // �J�n�I���ʔ�
                //inventInputSearchCndtnWork.Ed_InventorySeqNo = inventSearchCndtnUI.Ed_InventorySeqNo;               // �I���I���ʔ�
                //inventInputSearchCndtnWork.DifCntExtraDiv = inventSearchCndtnUI.DifCntExtraDiv;                     // ���ٕ����o�敪
                //inventInputSearchCndtnWork.StockCntZeroExtraDiv = inventSearchCndtnUI.StockCntZeroExtraDiv;         // �݌ɐ�0���o�敪
                //inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = inventSearchCndtnUI.IvtStkCntZeroExtraDiv;       // �I���݌ɐ�0���o�敪
                //inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelectedPaperKind;               // ���[���
                //inventInputSearchCndtnWork.OutputAppointDiv = inventSearchCndtnUI.OutputAppointDiv;                 // �o�͎w��敪
                //inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // ���o�Ώۓ��t�敪
                //inventInputSearchCndtnWork.WarehouseDiv = 0;                                                        // �q�Ɏw��敪

                // PM.NS�ݒ�
                inventInputSearchCndtnWork.St_MakerCode = inventSearchCndtnUI.St_MakerCode;                         // ���[�J�[�R�[�h�J�n
                if (inventSearchCndtnUI.Ed_MakerCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_MakerCode = inventSearchCndtnUI.Ed_MakerCode;                         // ���[�J�[�R�[�h�I��
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_MakerCode = 9999;
                }

                inventInputSearchCndtnWork.WarehouseDiv = 0;                                                        // �q�Ɏw��敪
                inventInputSearchCndtnWork.St_WarehouseCode = inventSearchCndtnUI.St_WarehouseCode;                 // �q�ɃR�[�h�J�n
                inventInputSearchCndtnWork.Ed_WarehouseCode = inventSearchCndtnUI.Ed_WarehouseCode;                 // �q�ɃR�[�h�I��
                inventInputSearchCndtnWork.St_WarehouseShelfNo = inventSearchCndtnUI.St_WarehouseShelfNo;           // �I�ԊJ�n
                inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventSearchCndtnUI.Ed_WarehouseShelfNo;           // �I�ԏI��
                inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventSearchCndtnUI.St_EnterpriseGanreCode;     // ���Е��ރR�[�h�J�n
                if (inventSearchCndtnUI.Ed_EnterpriseGanreCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventSearchCndtnUI.Ed_EnterpriseGanreCode;     // ���Е��ރR�[�h�I��
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = 9999;
                }

                inventInputSearchCndtnWork.St_BLGoodsCode = inventSearchCndtnUI.St_BLGoodsCode;                     // �a�k���i�R�[�h�J�n
                if (inventSearchCndtnUI.Ed_BLGoodsCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_BLGoodsCode = inventSearchCndtnUI.Ed_BLGoodsCode;                     // �a�k���i�R�[�h�I��
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_BLGoodsCode = 99999;
                }

                inventInputSearchCndtnWork.St_SupplierCd = inventSearchCndtnUI.St_SupplierCd;                       // �J�n�d����R�[�h
                if (inventSearchCndtnUI.Ed_SupplierCd != 0)
                {
                    inventInputSearchCndtnWork.Ed_SupplierCd = inventSearchCndtnUI.Ed_SupplierCd;                       // �I���d����R�[�h
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_SupplierCd = 999999;
                }

                // 2008.12.10 30413 ���� ��ʂ̒I������ݒ肷��悤�ɏC�� >>>>>>START
                //inventInputSearchCndtnWork.InventoryDate = inventSearchCndtnUI.St_InventoryPreprDayDateTime;        // �I����
                inventInputSearchCndtnWork.InventoryDate = inventSearchCndtnUI.InventoryDate;        // �I����
                // 2008.12.10 30413 ���� ��ʂ̒I������ݒ肷��悤�ɏC�� <<<<<<END
                
                inventInputSearchCndtnWork.St_InventorySeqNo = inventSearchCndtnUI.St_InventorySeqNo;               // �J�n�I���ʔ�
                if (inventSearchCndtnUI.Ed_InventorySeqNo != 0)
                {
                    inventInputSearchCndtnWork.Ed_InventorySeqNo = inventSearchCndtnUI.Ed_InventorySeqNo;               // �I���I���ʔ�
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_InventorySeqNo = 99999999;
                }

                inventInputSearchCndtnWork.St_BLGroupCode = inventSearchCndtnUI.St_BLGroupCode;                     // �J�nBL�O���[�v�R�[�h
                if (inventSearchCndtnUI.Ed_BLGroupCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_BLGroupCode = inventSearchCndtnUI.Ed_BLGroupCode;                     // �I��BL�O���[�v�R�[�h
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_BLGroupCode = 99999;
                }
                
                inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelectedPaperKind;               // ���[���
                inventInputSearchCndtnWork.OutputAppointDiv = inventSearchCndtnUI.OutputAppointDiv;                 // �o�͎w��敪
                inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // ���o�Ώۓ��t�敪
                // 2008.10.31 30413 ���� ���o�����̐ݒ���C�� <<<<<<END
                
                // -----------------------ADD 2011/01/11 -------------------------->>>>>
                inventInputSearchCndtnWork.NumOutputDiv = inventSearchCndtnUI.NumOutputDiv;                         // ���ʏo�͋敪
                inventInputSearchCndtnWork.WarehouseShelfOutputDiv = inventSearchCndtnUI.WarehouseShelfOutputDiv;   // �I�ԏo�͋敪
                // -----------------------ADD 2011/01/11 --------------------------<<<<<

                // 2008.10.31 30413 ���� �ǉ��ݒ荀�� >>>>>>START
                inventInputSearchCndtnWork.StockDiv = inventSearchCndtnUI.StockDiv;                                 // �݌ɋ敪
                inventInputSearchCndtnWork.LendExtraDiv = inventSearchCndtnUI.LendExtraDiv;                         // �ݏo���o�敪
                inventInputSearchCndtnWork.DelayPaymentDiv = inventSearchCndtnUI.DelayPaymentDiv;                   // �����v�㒊�o�敪
                // 2008.10.31 30413 ���� �ǉ��ݒ荀�� <<<<<<END
                
                // �I�����ٕ\
                if (inventSearchCndtnUI.SelectedPaperKind == 1)
                {
                    inventInputSearchCndtnWork.CalcStockAmountDiv = 1;                 // �݌ɐ��Z�o�t���O
                    inventInputSearchCndtnWork.CalcStockAmountDate = DateTime.MinValue; // �݌ɐ��Z�o���t
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� �I�������f�[�^�W�J����
		/// <summary>
        /// �I�������f�[�^�W�J����
		/// </summary>
        /// <param name="inventSearchCndtnUI">UI���o�����N���X</param>
        /// <param name="inventInputRltList">�I�������f�[�^���ʃ��X�g</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : �I�������f�[�^��W�J����B</br>
	    /// <br>Programmer : 30413 ����</br>
	    /// <br>Date       : 2008.10.14</br>
        /// <br>Update Note: 2009/12/04 ������</br>
        /// <br>             ���v����̏�Q�C��</br>
        /// <br>Update Note: 2009/12/07 ���M</br>
        /// <br>             �d���I�Ԃ���݂̂��w�莞�ɁA�I�ԉ��Ɂu�d���I�ԂP�v�Ɓu�d���I�ԂQ�v���������C��</br>
        /// <br>Update Note: 2010/03/02 ������</br>
        /// <br>             �I���\���x����Ή�</br>
        /// <br>Update Note: 2011/01/11 liyp</br>
        /// <br>             �P�A�I�����̈󎚎d�l�ύX�@�Q�A�o�͏����ɐ��ʂƒI�ԂɊւ�������w���ǉ�����i�v�]�j</br>
        /// <br>Update Note: 2011/02/10 liyp</br>
        /// <br>             ���됔�̗p���̖����͕��̃f�[�^�ɂ���</br>
        /// <br>Update Note: 2011/02/17 �c����</br>
        /// <br>             redmine#19025 ���o���Ԃɂ���</br>
        /// <br>Update Note: 2011/11/28 ����</br>
        /// <br>             �I�������\/�I�Ԃ̈�����ɂ���</br>
        /// <br>Update Note: 2012/07/20 �����H</br>
        /// <br>             redmine#31158 �u�I�����ٕ\�v�̃T�[�o�[���׌y���Ƒ��x�A�b�v�̒���</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ�����</br>
        /// </remarks>
        private void SetTebleRowFromRetList(InventSearchCndtnUI inventSearchCndtnUI, ArrayList inventInputRltList)
        {
            // ----- ADD 2011/02/17 ---------->>>>>
            //ArrayList retList;    //DEL 2012/07/20 �����H Redmine#31158
            //int statusMngTtlSt = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);    //DEL 2012/07/20 �����H Redmine#31158
            // ----- ADD 2011/02/17 ----------<<<<<
            // ----- ADD 2012/07/20 �����H Redmine#31158  ---------->>>>>
            ArrayList retList = new ArrayList();
            int statusMngTtlSt = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (inventSearchCndtnUI.SelectedPaperKind == 2)
            {
                statusMngTtlSt = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            }
            // ----- ADD 2012/07/20 �����H Redmine#31158 ----------<<<<<

            DataRow dr;
            //add 2011/11/28 ���� Redmine #8073----->>>>>
            Array arr=  inventInputRltList.ToArray();
		    MyStringComparer myComp = new MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.Ordinal,inventSearchCndtnUI.SortDiv);
		    Array.Sort(arr,myComp);
            foreach (InventInputSearchResultWork inventInputSearchResultWork in arr)
            //add 2011/11/28 ���� Redmine #8073-----<<<<<    
            //foreach (InventInputSearchResultWork inventInputSearchResultWork in inventInputRltList)//del 2011/11/28 ���� Redmine #8073
            {
                // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                if (string.IsNullOrEmpty(inventInputSearchResultWork.GoodsName))
                {
                    inventInputSearchResultWork.GoodsName = GetGoodsName(inventInputSearchResultWork.GoodsMakerCd, inventInputSearchResultWork.GoodsNo);

                    if (inventSearchCndtnUI.SelectedPaperKind == 2)
                    {
                        inventInputSearchResultWork.ListPriceFl = GetListPriceFl(inventInputSearchResultWork.GoodsMakerCd, inventInputSearchResultWork.GoodsNo, inventInputSearchResultWork.InventoryDate);
                    }
                }
                // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                // 2009.01.30 30413 ���� �I�����ٕ\�̏ꍇ�A���ِ����[���̃f�[�^�͔�� >>>>>>START
                // �I�����ٕ\
                if (inventSearchCndtnUI.SelectedPaperKind == 1)
                {
                    // ���ِ����[���̏ꍇ�͔��
                    if (inventInputSearchResultWork.InventoryTolerancCnt == 0)
                    {
                        continue;
                    }
                }
                // 2009.01.30 30413 ���� �I�����ٕ\�̏ꍇ�A���ِ����[���̃f�[�^�͔�� <<<<<<END
                
                dr = this._printDataSet.Tables[InventoryListDataTable].NewRow();

                dr[MAZAI02114EA.ctCol_SectionCode] = inventInputSearchResultWork.SectionCode;                   // ���_�R�[�h
                dr[MAZAI02114EA.ctCol_SectionGuideNm] = inventInputSearchResultWork.SectionGuideNm;             // ���_�K�C�h����
                dr[MAZAI02114EA.ctCol_InventorySeqNo] = inventInputSearchResultWork.InventorySeqNo;             // �I���ʔ�
                dr[MAZAI02114EA.ctCol_WarehouseCode] = inventInputSearchResultWork.WarehouseCode;               // �q�ɃR�[�h
                dr[MAZAI02114EA.ctCol_WarehouseName] = inventInputSearchResultWork.WarehouseName;               // �q�ɖ���
                dr[MAZAI02114EA.ctCol_GoodsMakerCd] = inventInputSearchResultWork.GoodsMakerCd;                 // ���i���[�J�[�R�[�h
                dr[MAZAI02114EA.ctCol_MakerName] = inventInputSearchResultWork.MakerName;                       // ���[�J�[����
                dr[MAZAI02114EA.ctCol_GoodsNo] = inventInputSearchResultWork.GoodsNo;                           // ���i�ԍ�
                dr[MAZAI02114EA.ctCol_GoodsName] = inventInputSearchResultWork.GoodsName;                       // ���i����
                dr[MAZAI02114EA.ctCol_WarehouseShelfNo] = inventInputSearchResultWork.WarehouseShelfNo;         // �q�ɒI��
                dr[MAZAI02114EA.ctCol_DuplicationShelfNo1] = inventInputSearchResultWork.DuplicationShelfNo1;   // �d���I��1
                dr[MAZAI02114EA.ctCol_DuplicationShelfNo2] = inventInputSearchResultWork.DuplicationShelfNo2;   // �d���I��2
                dr[MAZAI02114EA.ctCol_GoodsLGroup] = inventInputSearchResultWork.GoodsLGroup;                   // ���i�啪�ރR�[�h
                dr[MAZAI02114EA.ctCol_GoodsLGroupName] = inventInputSearchResultWork.GoodsLGroupName;           // ���i�啪�ރR�[�h����
                dr[MAZAI02114EA.ctCol_GoodsMGroup] = inventInputSearchResultWork.GoodsMGroup;                   // ���i�����ރR�[�h
                dr[MAZAI02114EA.ctCol_GoodsMGroupName] = inventInputSearchResultWork.GoodsMGroupName;           // ���i�����ރR�[�h����
                dr[MAZAI02114EA.ctCol_BLGroupCode] = inventInputSearchResultWork.BLGroupCode;                   // BL�O���[�v�R�[�h
                dr[MAZAI02114EA.ctCol_BLGroupName] = inventInputSearchResultWork.BLGroupName;                   // BL�O���[�v�R�[�h����
                dr[MAZAI02114EA.ctCol_EnterpriseGanreCode] = inventInputSearchResultWork.EnterpriseGanreCode;   // ���Е��ރR�[�h
                dr[MAZAI02114EA.ctCol_EnterpriseGanreName] = inventInputSearchResultWork.EnterpriseGanreName;   // ���Е��ޖ���
                dr[MAZAI02114EA.ctCol_BLGoodsCode] = inventInputSearchResultWork.BLGoodsCode;                   // �a�k���i�R�[�h
                dr[MAZAI02114EA.ctCol_BLGoodsCdDerivedNo] = inventInputSearchResultWork.BLGoodsCdDerivedNo;     // �a�k���i�R�[�h�}��
                dr[MAZAI02114EA.ctCol_BLGoodsName] = inventInputSearchResultWork.BLGoodsName;                   // �a�k���i����
                dr[MAZAI02114EA.ctCol_SupplierCd] = inventInputSearchResultWork.SupplierCd;                     // �d����R�[�h
                dr[MAZAI02114EA.ctCol_Jan] = inventInputSearchResultWork.Jan;                                   // �i�`�m�R�[�h
                dr[MAZAI02114EA.ctCol_StockUnitPriceFl] = inventInputSearchResultWork.StockUnitPriceFl;         // �d���P��
                dr[MAZAI02114EA.ctCol_BfStockUnitPriceFl] = inventInputSearchResultWork.BfStockUnitPriceFl;     // �ύX�O�d���P��
                dr[MAZAI02114EA.ctCol_StkUnitPriceChgFlg] = inventInputSearchResultWork.StkUnitPriceChgFlg;     // �d���P���ύX�t���O
                dr[MAZAI02114EA.ctCol_StockDiv] = inventInputSearchResultWork.StockDiv;                         // �݌ɋ敪
                dr[MAZAI02114EA.ctCol_LastStockDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastStockDate);               // �ŏI�d���N����
                dr[MAZAI02114EA.ctCol_StockTotal] = inventInputSearchResultWork.StockTotal;                     // �݌ɑ���
                dr[MAZAI02114EA.ctCol_ShipCustomerCode] = inventInputSearchResultWork.ShipCustomerCode;         // �o�א擾�Ӑ�R�[�h
                dr[MAZAI02114EA.ctCol_ShipCustomerName] = inventInputSearchResultWork.ShipCustomerName;         // �o�א擾�Ӑ於��
                dr[MAZAI02114EA.ctCol_ShipCustomerName2] = inventInputSearchResultWork.ShipCustomerName2;       // �o�ד��Ӑ於��2
                // ------------DEL 2010/02/20----------->>>>>
                //dr[MAZAI02114EA.ctCol_InventoryStockCnt] = inventInputSearchResultWork.InventoryStockCnt;       // �I���݌ɐ�
                // ------------DEL 2010/02/20-----------<<<<<
                // --- ADD licb K2014/03/10 FOR �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- >>>>>
                dr[MAZAI02114EA.ctCol_InventoryStockCntTextOut] = inventInputSearchResultWork.InventoryStockCnt;       // �I���݌ɐ�
                dr[MAZAI02114EA.ctCol_ListPriceTextOut] = inventInputSearchResultWork.ListPrice;       // �W�����i
                // --- ADD licb K2014/03/10 FRO �M�z�����ԏ���ʊJ�� �e�L�X�g�o�͋@�\��ǉ����� --- <<<<<
                dr[MAZAI02114EA.ctCol_InventoryTolerancCnt] = inventInputSearchResultWork.InventoryTolerancCnt; // �I���ߕs����
                dr[MAZAI02114EA.ctCol_InventoryPreprDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryPreprDay);       // �I�������������t
                dr[MAZAI02114EA.ctCol_InventoryPreprTim] = inventInputSearchResultWork.InventoryPreprTim;       // �I��������������
                dr[MAZAI02114EA.ctCol_InventoryDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDay);                 // �I�����{��
                dr[MAZAI02114EA.ctCol_LastInventoryUpdate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastInventoryUpdate);   // �ŏI�I���X�V��
                dr[MAZAI02114EA.ctCol_InventoryNewDiv] = inventInputSearchResultWork.InventoryNewDiv;           // �I���V�K�ǉ��敪
                dr[MAZAI02114EA.ctCol_StockMashinePrice] = inventInputSearchResultWork.StockMashinePrice;       // �}�V���݌Ɋz
                dr[MAZAI02114EA.ctCol_InventoryStockPrice] = inventInputSearchResultWork.InventoryStockPrice;   // �I���݌Ɋz
                dr[MAZAI02114EA.ctCol_InventoryTlrncPrice] = inventInputSearchResultWork.InventoryTlrncPrice;   // �I���ߕs�����z
                dr[MAZAI02114EA.ctCol_ListPriceFl] = inventInputSearchResultWork.ListPriceFl;                   // �艿�i�����j
                dr[MAZAI02114EA.ctCol_InventoryDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDate);               // �I����
                dr[MAZAI02114EA.ctCol_StockTotalExec] = inventInputSearchResultWork.StockTotalExec;             // �݌ɑ����i���{���j
                dr[MAZAI02114EA.ctCol_ToleranceUpdateCd] = inventInputSearchResultWork.ToleranceUpdateCd;       // �ߕs���X�V�敪
                dr[MAZAI02114EA.ctCol_StockAmount] = inventInputSearchResultWork.StockAmount;                   // �Z�o�݌ɐ�

                if (inventInputSearchResultWork.StockDiv == 0)                                                  // �݌ɋ敪  
                {
                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "����";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "���";
                }
                
                //// ���ً��z(�݌Ɍ��P���~�݌ɉߕs������������(��))
                //dr[MAZAI02114EA.ctCol_TolerancPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryTolerancCnt;
                ////�݌ɋ��z(�I�����~�݌Ɍ��P��(��))
                //dr[MAZAI02114EA.ctCol_StockPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryStockCnt;

                //�ŏI�d����(����p)
                if (inventInputSearchResultWork.LastStockDate == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_LastStockDate_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_LastStockDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.LastStockDate);
                }
                //�I�������������t
                if (inventInputSearchResultWork.InventoryPreprDay == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryPreprDay);
                }
                //�I�����{��
                if (inventInputSearchResultWork.InventoryDay == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryDay_Print] = "";
                    // ------------ADD 2010/02/20------------->>>>>
                    // �I�����{��(InventoryDayRF)��NULL�̏ꍇ�A�I������������Ȃ��i�󔒁j
                    dr[MAZAI02114EA.ctCol_InvStockCntFlag_Print] = 1;
                    dr[MAZAI02114EA.ctCol_InventoryStockCnt] = 0.0;       // �I���݌ɐ�
                    // ------------ADD 2010/02/20-------------<<<<<
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryDay_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryDay);
                    // ------------ADD 2010/02/20------------->>>>>
                    // �I�����{��(InventoryDayRF)��NULL�̏ꍇ�A�I���������
                    dr[MAZAI02114EA.ctCol_InvStockCntFlag_Print] = 0;
                    dr[MAZAI02114EA.ctCol_InventoryStockCnt] = inventInputSearchResultWork.InventoryStockCnt;       // �I���݌ɐ�
                    // ------------ADD 2010/02/20-------------<<<<<

                }
                //�ŏI�I���X�V��
                if (inventInputSearchResultWork.LastInventoryUpdate == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.LastInventoryUpdate);
                }
                //�q�ɃR�[�h
                if (inventInputSearchResultWork.WarehouseCode == "")
                {
                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = inventInputSearchResultWork.WarehouseCode.TrimEnd().PadLeft(4, '0');
                }

                //�q�ɃR�[�h�L���`�F�b�N(�����ꍇ�͋��_���ݒ�}�X�^�̗D��q�ɂ��擾)
                this.CheckWarehouseCode(inventInputSearchResultWork, ref dr);               //ADD 2009/05/13 �s��Ή�[13259]

                // 2008.10.31 30413 ���� �d����R�[�h�ABL�R�[�h�A�O���[�v�R�[�h�A���[�J�[�R�[�h���󎚗p��0�l�ߑΉ� >>>>>>START
                // �d����R�[�h
                if (inventInputSearchResultWork.SupplierCd == 0)
                {
                    dr[MAZAI02114EA.ctCol_SupplierCd_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_SupplierCd_Print] = inventInputSearchResultWork.SupplierCd.ToString("d06");
                }
                // BL�R�[�h
                if (inventInputSearchResultWork.BLGoodsCode == 0)
                {
                    dr[MAZAI02114EA.ctCol_BLGoodsCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_BLGoodsCode_Print] = inventInputSearchResultWork.BLGoodsCode.ToString("d05");
                }
                // �O���[�v�R�[�h
                if (inventInputSearchResultWork.BLGroupCode == 0)
                {
                    dr[MAZAI02114EA.ctCol_BLGroupCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_BLGroupCode_Print] = inventInputSearchResultWork.BLGroupCode.ToString("d05");
                }
                // ���[�J�[�R�[�h
                if (inventInputSearchResultWork.GoodsMakerCd == 0)
                {
                    dr[MAZAI02114EA.ctCol_MakerCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_MakerCode_Print] = inventInputSearchResultWork.GoodsMakerCd.ToString("d04");
                }
                // 2008.10.31 30413 ���� �d����R�[�h�ABL�R�[�h�A�O���[�v�R�[�h�A���[�J�[�R�[�h���󎚗p��0�l�ߑΉ� <<<<<<END
                
                //�I�ԃu���C�N����
                // ----------UPD 2009/12/04 --------->>>>>
                dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = "";
                // �I�����ٕ\ �{���v����{�o�͏�(�I�ԏ�)
                if ((inventSearchCndtnUI.SelectedPaperKind == 1) && (inventSearchCndtnUI.SubtotalPrintDiv == 0) && (inventSearchCndtnUI.SortDiv == 0))
                {

                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                        {
                            // �I�ԃu���C�N�����ȏ�̎��͌����ō��
                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                        }
                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
 
                }
                // �I���\ �{���v����{�o�͏�(�I�ԏ�)
                else if ((inventSearchCndtnUI.SelectedPaperKind == 2) && (inventSearchCndtnUI.SubtotalPrintDiv == 0) && (inventSearchCndtnUI.SortDiv == 0))
                {
                    String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                    if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                    {
                        // �I�ԃu���C�N�����ȏ�̎��͌����ō��
                        wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                    }
                    dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                }
                else if (inventSearchCndtnUI.TurnOoverThePagesDiv == 1)
                {
                    // �o�͏�
                    //// �q�Ɂ��I�� or �q�Ɂ��d���恨�I��
                    //if ((inventSearchCndtnUI.SortDiv == 0) || (inventSearchCndtnUI.SortDiv == 4))
                    // �q�Ɂ��I��
                    if (inventSearchCndtnUI.SortDiv == 0)
                    {
                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                        {
                            // �I�ԃu���C�N�����ȏ�̎��͌����ō��
                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                        }
                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                    }
                }
                //if (inventSearchCndtnUI.TurnOoverThePagesDiv == 1)
                //{
                //    // �o�͏�
                //    //// �q�Ɂ��I�� or �q�Ɂ��d���恨�I��
                //    //if ((inventSearchCndtnUI.SortDiv == 0) || (inventSearchCndtnUI.SortDiv == 4))
                //    // �q�Ɂ��I��
                //    if (inventSearchCndtnUI.SortDiv == 0)
                //    {
                //        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                //        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                //        {
                //            // �I�ԃu���C�N�����ȏ�̎��͌����ō��
                //            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                //        }
                //        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                //    }
                //}
                // 2009.02.16 30413 ���� �I���\�̒I�ԃu���C�N�ݒ��ǉ� >>>>>>START
                else if ((inventSearchCndtnUI.SelectedPaperKind == 2) && (inventSearchCndtnUI.TurnOoverThePagesDiv == 0) && (inventSearchCndtnUI.SubtotalPrintDiv == 0))
                {
                    // �I���\�{����(�q�ɏ�)�{���v����
                    // �q�Ɂ��I��
                    if (inventSearchCndtnUI.SortDiv == 0)
                    {
                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                        {
                            // �I�ԃu���C�N�����ȏ�̎��͌����ō��
                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                        }
                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                    }
                }
                // 2009.02.16 30413 ���� �I���\�̒I�ԃu���C�N�ݒ��ǉ� <<<<<<END
                // 2008.11.27 30413 ���� ���ł�"�q��"�܂���"���Ȃ�"�ꍇ�̏��v�󎚂ɑΉ� >>>>>>START
                else
                {
                    dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = inventInputSearchResultWork.WarehouseShelfNo;   // �I��
                }
                // 2008.11.27 30413 ���� ���ł�"�q��"�܂���"���Ȃ�"�ꍇ�̏��v�󎚂ɑΉ� <<<<<<END
                // ----------UPD 2009/12/04 ---------<<<<<
                //�I����
                if (inventInputSearchResultWork.InventoryDate == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryDate);
                }
                
                // 2008.11.04 30413 ���� �I�����ٕ\�̍��ُ��v�� >>>>>>START
                // ���ِ�
                if (inventInputSearchResultWork.InventoryTolerancCnt >= 0)
                {
                    dr[MAZAI02114EA.ctCol_PlusInventoryTolerancCnt] = inventInputSearchResultWork.InventoryTolerancCnt;     // �v���X�̍��ِ�
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_MinusInventoryTolerancCnt] = Math.Abs(inventInputSearchResultWork.InventoryTolerancCnt);      // �}�C�i�X�̍��ِ�
                }
                // ���ً��z
                if (inventInputSearchResultWork.InventoryTlrncPrice >= 0)
                {
                    dr[MAZAI02114EA.ctCol_PlusInventoryTlrncPrice] = inventInputSearchResultWork.InventoryTlrncPrice;       // �v���X�̍��ً��z
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_MinusInventoryTlrncPrice] = Math.Abs(inventInputSearchResultWork.InventoryTlrncPrice);        // �}�C�i�X�̍��ً��z
                }
                // 2008.11.04 30413 ���� �I�����ٕ\�̍��ُ��v�� <<<<<<END

                // ------------UPD 2010/03/02------------->>>>>
                //// 2008.11.04 30413 ���� ���i�A�N�Z�X�N���X���牿�i���̎擾 >>>>>>START
                //// ���[�J���L���b�V���̏��i�A���f�[�^���牿�i�����擾
                //double listPrice = GetListPrice(inventInputSearchResultWork);
                //dr[MAZAI02114EA.ctCol_ListPrice_Print] = listPrice.ToString();
                double stockCount = 0;//ADD 2011/01/11
                //// �Z�o��̒I�����z
                ////dr[MAZAI02114EA.ctCol_StockAmountPrice_Print] = ((long)(inventInputSearchResultWork.StockTotalExec * listPrice)).ToString();
                //// 2008.11.04 30413 ���� ���i�A�N�Z�X�N���X���牿�i���̎擾 <<<<<<END
                // ���i���
                dr[MAZAI02114EA.ctCol_ListPrice_Print] = inventInputSearchResultWork.ListPrice;
                // ------------UPD 2010/03/02-------------<<<<<
                // 2008.12.10 30413 ���� �I�������͋敪�̏������C�� >>>>>>START
                // 2008.11.04 30413 ���� �I�������͋敪�̏��� >>>>>>START
                //�I���\
                if (inventSearchCndtnUI.SelectedPaperKind == 2)
                {
                    // 2009.02.16 30413 ���� �I�����̎Z�o���C�� >>>>>>START
                    // �I����(�݌ɑ���(���{��)�{�I���ߕs����)
                    //long stockCount = (long)(inventInputSearchResultWork.StockTotalExec + inventInputSearchResultWork.InventoryTolerancCnt);
                    // �I����(�݌ɑ����{�I���ߕs����)

                    // -- UPD 2009/09/15 ---------------------->>>
                    //// --- CHG 2009/03/06 ��QID:12229�Ή�------------------------------------------------------>>>>>
                    ////long stockCount = (long)(inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt);
                    //// �I�����͎l�̌ܓ�
                    //long stockCount = (long)Math.Floor(inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt + 0.5);
                    //// --- CHG 2009/03/06 ��QID:12229�Ή�------------------------------------------------------<<<<<
                    
                    //double stockCount = inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt; //DEL 2011/01/11
                    // -- UPD 2009/09/15 ----------------------<<<
                    
                    // 2009.02.16 30413 ���� �I�����̎Z�o���C�� <<<<<<END

                    // ---------------ADD 2011/01/11 ------------->>>>>
                    // ----- DEL 2011/02/17 ---------->>>>>
                    //string message = "" ;
                    //ArrayList retList;
                    //int statusMngTtlSt = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                    // ----- DEL 2011/02/17 ----------<<<<<
                    if (statusMngTtlSt == 0)
                    {
                        foreach (StockMngTtlSt stockMngTtlSt in retList)
                        {
                            if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                            {
                                _stockMngTtlSt = stockMngTtlSt;
                                break;
                            }
                        }
                    }
                    else
                    {
                        _stockMngTtlSt = new StockMngTtlSt();
                    }

                    if (_stockMngTtlSt.InventoryMngDiv == 1) // �I���^�p�敪��PM7
                    {
                        //�I���� = �I���݌ɐ��iInventoryStockCnt�j
                        stockCount = inventInputSearchResultWork.InventoryStockCnt;
                        // ------------------------ADD 2011/02/10------------------>>>>
                        if ((inventSearchCndtnUI.InventoryNonInputDiv == 0) &&                     // ���됔�̗p
                            (inventInputSearchResultWork.InventoryDay == DateTime.MinValue)           // �I�������͂̃��R�[�h
                           )
                        {
                         //�I���� = �݌ɑ����iStockTotal�j
                         stockCount = inventInputSearchResultWork.StockTotal;
                        }
                        // ------------------------ADD 2011/02/10------------------<<<<
                    }
                    else                                        // �I���^�p�敪��PM.NS
                    {
                        //�I���� = �݌ɑ����iStockTotal�j + �I�����ِ��iInventoryTolerancCnt�j
                        stockCount = inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt;
                    }
                    // ---------------ADD 2011/01/11 -------------<<<<<
                    // DEL 2009/04/16 ------>>>
                    //// --- CHG 2009/03/06 ��QID:12229�Ή�------------------------------------------------------>>>>>
                    ////long stockAmountPrice = (long)(stockCount * inventInputSearchResultWork.StockUnitPriceFl);
                    //// �I�����z�͎l�̌ܓ�
                    //long stockAmountPrice = (long)Math.Floor(stockCount * inventInputSearchResultWork.StockUnitPriceFl + 0.5);
                    //// --- CHG 2009/03/06 ��QID:12229�Ή�------------------------------------------------------<<<<<
                    // DEL 2009/04/16 ------<<<

                    // ADD 2009/04/16 ------>>>
                    // �I�����͎l�̌ܓ��O�̒l�Ƃ���
                    // ---------------UPD 2011/01/11 ------------->>>>>
                    //long stockAmountPrice = (long)Math.Floor((inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt) *
                                                             //inventInputSearchResultWork.StockUnitPriceFl + 0.5);
                    // �v�Z��I����*�d���P��
                    long stockAmountPrice = (long)Math.Floor(stockCount * inventInputSearchResultWork.StockUnitPriceFl + 0.5);
                    // ---------------UPD 2011/01/11 -------------<<<<<
                    // ADD 2009/04/16 ------<<<

                    // ---DEL 2009/05/21 �s��Ή�[13262] -------------------------------------------->>>>>
                    ////if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) &&
                    ////    (inventInputSearchResultWork.InventoryDay == DateTime.MinValue))
                    ////if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) &&
                    ////    (inventInputSearchResultWork.InventoryStockCnt == 0))
                    //if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) && (stockCount == 0))
                    // ---DEL 2009/05/21 �s��Ή�[13262] -------------------------------------------->>>>>
                    if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) &&                      //ADD 2009/05/21 �s��Ή�[13262]
                        (inventInputSearchResultWork.InventoryDay == DateTime.MinValue)         //ADD 2009/05/21 �s��Ή�[13262]
                       )
                    {
                        // �����͈����A�I�������̓f�[�^
                        dr[MAZAI02114EA.ctCol_StockCount_Print] = "������";
                        dr[MAZAI02114EA.ctCol_ListPrice_Print] = "";
                        dr[MAZAI02114EA.ctCol_StockUnitPriceFl_Print] = "";
                        dr[MAZAI02114EA.ctCol_StockAmountPrice_Print] = "";
                    }
                    else
                    {
                        // �����͈����A�I�������̓f�[�^�ȊO
                        //dr[MAZAI02114EA.ctCol_StockCount_Print] = inventInputSearchResultWork.StockTotalExec.ToString();             // �݌ɑ����i���{���j
                        //dr[MAZAI02114EA.ctCol_StockUnitPriceFl_Print] = inventInputSearchResultWork.StockUnitPriceFl.ToString();         // �d���P��;
                        //long stockCount = (long)(inventInputSearchResultWork.StockTotalExec + inventInputSearchResultWork.InventoryTolerancCnt);
                        //long stockAmountPrice = (long)(stockCount * inventInputSearchResultWork.StockUnitPriceFl);
                        dr[MAZAI02114EA.ctCol_StockCount_Print] = stockCount.ToString();                                                // ���됔+�I���ߕs����
                        dr[MAZAI02114EA.ctCol_StockUnitPriceFl_Print] = inventInputSearchResultWork.StockUnitPriceFl.ToString();        // �d���P��
                        dr[MAZAI02114EA.ctCol_StockAmountPrice_Print] = stockAmountPrice.ToString();                                    // �v�Z��I����*�d���P��
                    }
                }
                // 2008.11.04 30413 ���� �I�������͋敪�̏��� <<<<<<END
                // 2008.12.10 30413 ���� �I�������͋敪�̏������C�� <<<<<<END

                this._printDataSet.CaseSensitive = true;        //ADD 2009/05/13 �s��Ή�[13259][13261][13262]�@���啶���E�����������

                dr[MAZAI02114EA.ctCol_BlankShowFlag_Print] = 0;//ADD 2009/12/07
                
                // ------------ADD 2011/01/11 ---------------->>>>>
                if (inventSearchCndtnUI.NumOutputDiv != 0 && inventSearchCndtnUI.SelectedPaperKind == 2)
                {
                    if (inventSearchCndtnUI.InventoryNonInputDiv == 0)
                    {

                        if (inventSearchCndtnUI.NumOutputDiv == 1 && (stockCount > 1 || stockCount == 1))
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                        else if (inventSearchCndtnUI.NumOutputDiv == 2 && (stockCount < 0 || stockCount == 0))
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                        else if (inventSearchCndtnUI.NumOutputDiv == 3 && stockCount == 0)
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                    }
                    else if (inventSearchCndtnUI.InventoryNonInputDiv == 1)
                    {
                        if (inventSearchCndtnUI.NumOutputDiv == 4 && inventInputSearchResultWork.InventoryDay == DateTime.MinValue)
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                        else if (inventSearchCndtnUI.NumOutputDiv == 5 && inventInputSearchResultWork.InventoryDay != DateTime.MinValue)
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                    }
                }
                else
                {
                    this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                }
               // ------------ADD 2011/01/11 ----------------<<<<<

                //this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);//DEL 2011/01/11
            }

            // -------ADD 2009/12/07------->>>>>
            //�I�������\�A�d���I�Ԃ���̂ݏꍇ
            if (inventSearchCndtnUI.SelectedPaperKind == 0 && inventSearchCndtnUI.OutputAppointDiv == 3)
            {
                // �t�B���^�[������
                string strFilter = "";
                // �\�[�g��������擾
                string strSort = this.MakeSortingOrderString(inventSearchCndtnUI.SortDiv);

                DataView dv = new DataView(this._printDataSet.Tables[InventoryListDataTable], strFilter, strSort, DataViewRowState.CurrentRows);

                DataTable dt = new DataTable();
                dt = dv.ToTable();

                this._printDataSet.Tables[InventoryListDataTable].Rows.Clear();

                foreach (DataRow dataRow in dt.Rows)
                {
                    #region
                    DataRow drNo = this._printDataSet.Tables[InventoryListDataTable].NewRow();
                    for (int i = 0; i < dataRow.Table.Columns.Count; i++ )
                    {
                        drNo[i] = dataRow[i];
                    }

                    this._printDataSet.Tables[InventoryListDataTable].Rows.Add(drNo);
                    #endregion
                    // �d���I��1
                    if (!string.IsNullOrEmpty(dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo1].ToString().Trim()))
                    {
                        DataRow drShelfNo = this._printDataSet.Tables[InventoryListDataTable].NewRow();

                        drShelfNo[MAZAI02114EA.ctCol_SectionCode] = dataRow[MAZAI02114EA.ctCol_SectionCode];                   // ���_�R�[�h
                        drShelfNo[MAZAI02114EA.ctCol_SectionGuideNm] = dataRow[MAZAI02114EA.ctCol_SectionGuideNm];             // ���_�K�C�h����
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseCode] = dataRow[MAZAI02114EA.ctCol_WarehouseCode];               // �q�ɃR�[�h
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo] = dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo1];      // �q�ɒI��
                        drShelfNo[MAZAI02114EA.ctCol_GoodsNo] = dataRow[MAZAI02114EA.ctCol_GoodsNo];      // �i��
                        drShelfNo[MAZAI02114EA.ctCol_GoodsMakerCd] = dataRow[MAZAI02114EA.ctCol_GoodsMakerCd];      // ���[�J�[
                        drShelfNo[MAZAI02114EA.ctCol_SupplierCd] = dataRow[MAZAI02114EA.ctCol_SupplierCd];      // �d����
                        drShelfNo[MAZAI02114EA.ctCol_BLGoodsCode] = dataRow[MAZAI02114EA.ctCol_BLGoodsCode];      // �a�k�R�[�h
                        drShelfNo[MAZAI02114EA.ctCol_BLGroupCode] = dataRow[MAZAI02114EA.ctCol_BLGroupCode];      // �O���[�v�R�[�h
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = dataRow[MAZAI02114EA.ctCol_WarehouseShelfNo_Print];   // �I��

                        drShelfNo[MAZAI02114EA.ctCol_BlankShowFlag_Print] = 1;

                        this._printDataSet.Tables[InventoryListDataTable].Rows.Add(drShelfNo);
                    }

                    // �d���I��2
                    if (!string.IsNullOrEmpty(dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo2].ToString().Trim()))
                    {
                        DataRow drShelfNo = this._printDataSet.Tables[InventoryListDataTable].NewRow();

                        drShelfNo[MAZAI02114EA.ctCol_SectionCode] = dataRow[MAZAI02114EA.ctCol_SectionCode];                   // ���_�R�[�h
                        drShelfNo[MAZAI02114EA.ctCol_SectionGuideNm] = dataRow[MAZAI02114EA.ctCol_SectionGuideNm];             // ���_�K�C�h����
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseCode] = dataRow[MAZAI02114EA.ctCol_WarehouseCode];               // �q�ɃR�[�h
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo] = dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo2];      // �q�ɒI��
                        drShelfNo[MAZAI02114EA.ctCol_GoodsNo] = dataRow[MAZAI02114EA.ctCol_GoodsNo];      // �i��
                        drShelfNo[MAZAI02114EA.ctCol_GoodsMakerCd] = dataRow[MAZAI02114EA.ctCol_GoodsMakerCd];      // ���[�J�[
                        drShelfNo[MAZAI02114EA.ctCol_SupplierCd] = dataRow[MAZAI02114EA.ctCol_SupplierCd];      // �d����
                        drShelfNo[MAZAI02114EA.ctCol_BLGoodsCode] = dataRow[MAZAI02114EA.ctCol_BLGoodsCode];      // �a�k�R�[�h
                        drShelfNo[MAZAI02114EA.ctCol_BLGroupCode] = dataRow[MAZAI02114EA.ctCol_BLGroupCode];      // �O���[�v�R�[�h
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = dataRow[MAZAI02114EA.ctCol_WarehouseShelfNo_Print];   // �I��
                        drShelfNo[MAZAI02114EA.ctCol_BlankShowFlag_Print] = 1;

                        this._printDataSet.Tables[InventoryListDataTable].Rows.Add(drShelfNo);
                    }
                }
            }
            // -------ADD 2009/12/07-------<<<<<
        }
        #endregion

        #region
        // ---------------DEL 2010/03/02-------------->>>>>
        //private void SetCacheGoodsUnitDataList(ArrayList inventInputRltList)
        //{
        //    GoodsAcs goodsAcs = new GoodsAcs();
        //    List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            
        //    string message = "";
        //    goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);
            
        //    foreach (InventInputSearchResultWork inventInputSearchResultWork in inventInputRltList)
        //    {
        //        // ���i�A�N�Z�X�N���X�̒��o������ݒ�
        //        GoodsCndtn workGoodsCndtn = new GoodsCndtn();
        //        workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //        workGoodsCndtn.SectionCode = inventInputSearchResultWork.SectionCode.Trim();
        //        workGoodsCndtn.MakerName = inventInputSearchResultWork.MakerName;
        //        workGoodsCndtn.GoodsNoSrchTyp = 0;
        //        workGoodsCndtn.GoodsMakerCd = inventInputSearchResultWork.GoodsMakerCd;
        //        workGoodsCndtn.GoodsNo = inventInputSearchResultWork.GoodsNo;
        //        workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

        //        goodsCndtnList.Add(workGoodsCndtn);
        //    }

        //    // ���[�J���L���b�V��������
        //    _goodsUnitDataListList = new List<List<GoodsUnitData>>();

        //    // ���������������S��v�ŏ��i�����擾
        //    int status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out _goodsUnitDataListList, out message);
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        _goodsUnitDataListList = null;
        //    }

        //}
        // ---------------DEL 2010/03/02--------------<<<<<
        #endregion

        #region
        // ---------------DEL 2010/03/02-------------->>>>>
        //private double GetListPrice(InventInputSearchResultWork inventInputSearchResultWork)
        //{
        //    double listPrice = 0;

        //    if (_goodsUnitDataListList == null)
        //    {
        //        return listPrice;
        //    }

        //    // 2009.02.03 30413 ���� �V�X�e�����t�ŉ��i�J�n�����`�F�b�N >>>>>>START
        //    string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
        //    // 2009.02.03 30413 ���� �V�X�e�����t�ŉ��i�J�n�����`�F�b�N <<<<<<END
            
        //    foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
        //    {
        //        foreach (GoodsUnitData wkGoodsUnitData in wkGoodsUnitDataList)
        //        {
        //            List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

        //            foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
        //            {
        //                // 2009.02.03 30413 ���� �V�X�e�����t�ŉ��i�J�n�����`�F�b�N >>>>>>START
        //                if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
        //                    (wkGoodsPrice.GoodsMakerCd == inventInputSearchResultWork.GoodsMakerCd) &&
        //                    (wkGoodsPrice.GoodsNo == inventInputSearchResultWork.GoodsNo))
        //                {
        //                    listPrice = wkGoodsPrice.ListPrice;
        //                    return listPrice;
        //                }
        //                // 2009.02.03 30413 ���� �V�X�e�����t�ŉ��i�J�n�����`�F�b�N <<<<<<END
        //            }
        //        }
        //    }
        //    return listPrice;
        //}
        // ---------------DEL 2010/03/02--------------<<<<<
        #endregion

        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private method

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        private GoodsAcs GetGoodsAcs()
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            return this._goodsAcs;
        }

        /// <summary>
        /// �i���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�i��</returns>
        public string GetGoodsName(int makerCode, string goodsNo)
        {
            string goodsName = "";

            try
            {
                GoodsUnitData goodsUnitData;

                int status = GetGoodsAcs().Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                if (status == 0)
                {
                    goodsName = goodsUnitData.GoodsName.Trim();
                }
            }
            catch
            {
                goodsName = "";
            }

            return goodsName;
        }

        private double GetListPriceFl(int makerCode, string goodsNo, DateTime targetDate)
        {
            double listPriceFl = 0;
      
            try
            {
                GoodsUnitData goodsUnitData;

                int status = this.GetGoodsAcs().Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                if (status == 0)
                {
                    GoodsPrice goodsPrice = this.GetGoodsAcs().GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
                    listPriceFl = goodsPrice.ListPrice;
                }
            }
            catch
            {
                listPriceFl = 0;
            }
     
            return listPriceFl;
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        #region ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
        /// <summary>
        /// ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
		/// </summary>
		/// <param name="ds">�f�[�^�Z�b�g</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : ���o��{�f�[�^�Z�b�g�̃X�L�[�}�ݒ���s���܂�</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.20</br>
		/// </remarks>
		private void DataSetColumnConstruction(ref DataSet ds)
		{
			// ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.MAZAI02114EA.SettingDataSet(ref ds);
        }

        #endregion

        // ---ADD 2009/05/13 �s��Ή�[13259] ------------------->>>>>
        #region CheckWarehouseCode(�q�ɃR�[�h�L���`�F�b�N)
        /// <summary>
        /// �q�ɃR�[�h�L���`�F�b�N
        /// </summary>
        /// <param name="inventInputSearchResultWork">���o����(����)</param>
        /// <param name="dr">InventoryListDataTable��DataRow</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h���`�F�b�N���A�����ꍇ�͋��_���̗D��q�ɂ��擾���܂��B</br>
        /// <br>             �����ɕ�������ĂȂ��ׁA�I�������\�A�I�����ٕ\�A�I���\�̑S�Ăł��̏�����ʂ�܂����A</br>
        /// <br>             �@�I�����ٕ\�A�I���\�ɂ͕K���q�ɃR�[�h�������Ă���ׁA���ۂɗD��q�ɂ��擾����̂�</br>
        /// <br>             �@�I�������\�����ƂȂ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/13</br>
        /// </remarks>
        private void CheckWarehouseCode(InventInputSearchResultWork inventInputSearchResultWork, ref DataRow dr)
        {
            //�q�ɃR�[�h����
            if (string.IsNullOrEmpty(inventInputSearchResultWork.WarehouseCode.Trim()) == false)
            {
                return;
            }

            //���_���̗D��q�ɂ��擾
            SecInfoSet secInfoSet = null;
            this._secInfoSetAcs.Read(out secInfoSet, LoginInfoAcquisition.EnterpriseCode, inventInputSearchResultWork.SectionCode);
            if (string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim()) == false)
            {
                dr[MAZAI02114EA.ctCol_WarehouseCode] = secInfoSet.SectWarehouseCd1;                                   // �q�ɃR�[�h
                dr[MAZAI02114EA.ctCol_WarehouseName] = secInfoSet.SectWarehouseNm1;                                   // �q�ɖ���
                dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = secInfoSet.SectWarehouseCd1.TrimEnd().PadLeft(4, '0');   // �q�ɃR�[�h(����p)
                return;
            }
        }
        #endregion
        // ---ADD 2009/05/13 �s��Ή�[13259] -------------------<<<<<
        #endregion

        /// <summary>
        /// �\�[�g������쐬����
        /// </summary>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g��������쐬���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.12.07</br>
        /// </remarks>
        private string MakeSortingOrderString(int sortDiv)
        {
            string sortStr = "";

            //�I�����ꂽ�\�[�g�����ɂ�菈���𕪂���q��
            switch (sortDiv)
            {
                case 0:             // �I�ԏ�
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�I��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 1:             // �d���揇
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�d����
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 2:             // �a�k�R�[�h��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�a�k�R�[�h
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 3:             // �O���[�v�R�[�h��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�O���[�v�R�[�h
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGroupCode, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 4:             // ���[�J�[��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
                case 5:             // �d����E�I�ԏ�
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�d����
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //�I��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 6:             // �d����E���[�J�[��
                    {
                        //�q��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //�d����
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //���[�J�[
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //�i��
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
            }

            return sortStr;
        }

        /// <summary>
        /// �\�[�g�p������쐬����
        /// </summary>
        /// <param name="colName">�񖼏�</param>
        /// <param name="ascDescDiv">�����E�~���敪[0:����, 1:�~��]</param>
        /// <param name="strQuery">�\�[�g�p������</param>
        /// <remarks>
        /// <br>Note       : �\�[�g�p�̕�����̍쐬���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.12.07</br>
        /// </remarks>
        private void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
        {
            if (strQuery == null)
            {
                strQuery = "";
            }

            if (strQuery == "")
            {
                strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
            else
            {
                strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
        }

        //add 2011/11/28 ���� Redmine #8073----->>>>>
        /// <summary>
        /// �I�������\����p�N���X
        /// </summary>
        private class MyStringComparer : IComparer
        {
            private CompareInfo myComp;
            private CompareOptions myOptions = CompareOptions.None;
            private int sortDiv = -1;
            public MyStringComparer(CompareInfo cmpi, CompareOptions options, int sortDiv)
            {
                myComp = cmpi;
                this.myOptions = options;
                this.sortDiv = sortDiv;
            }
            public int Compare(Object a, Object b)
            {
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;
                string stringA = "";
                string stringB = "";
                if (sortDiv == 0)// �I�ԏ�
                {
                    //�q��
                    stringA = ((InventInputSearchResultWork)a).WarehouseCode;
                    stringB = ((InventInputSearchResultWork)b).WarehouseCode;
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //�I��
                    stringA = ((InventInputSearchResultWork)a).WarehouseShelfNo;
                    stringB = ((InventInputSearchResultWork)b).WarehouseShelfNo;
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //�i��
                    stringA = ((InventInputSearchResultWork)a).GoodsNo;
                    stringB = ((InventInputSearchResultWork)b).GoodsNo;
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //���[�J�[
                    int intC = ((InventInputSearchResultWork)a).GoodsMakerCd;
                    int intD = ((InventInputSearchResultWork)b).GoodsMakerCd;
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                else if (sortDiv == 5)// �d����E�I�ԏ�
                {
                    //�q��
                    stringA = ((InventInputSearchResultWork)a).WarehouseCode;
                    stringB = ((InventInputSearchResultWork)b).WarehouseCode;
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //�d����
                    int intA = ((InventInputSearchResultWork)a).SupplierCd;
                    int intB = ((InventInputSearchResultWork)b).SupplierCd;
                    int comePareSupplierCd = intA.CompareTo(intB);
                    if (comePareSupplierCd != 0)
                    {
                        return comePareSupplierCd;
                    }
                    //�I��
                    stringA = ((InventInputSearchResultWork)a).WarehouseShelfNo;
                    stringB = ((InventInputSearchResultWork)b).WarehouseShelfNo;
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //�i��
                    stringA = ((InventInputSearchResultWork)a).GoodsNo;
                    stringB = ((InventInputSearchResultWork)b).GoodsNo;
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //���[�J�[
                    int intC = ((InventInputSearchResultWork)a).GoodsMakerCd;
                    int intD = ((InventInputSearchResultWork)b).GoodsMakerCd;
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                return 0;
            }
            //add 2011/11/28 ���� Redmine #8073-----<<<<<<
        }
    }
}
