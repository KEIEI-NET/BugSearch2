//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���m�F�\
// �v���O�����T�v   : �d���m�F�\�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �J���@�͍K
// �� �� ��  2005/01/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �C �� ��  2008/07/16  �C�����e : �f�[�^���ڂ̒ǉ�/�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/12/02  �C�����e : dayliheader�̃L�[�u���C�N�Ɏd��SEQ�ԍ���ǉ�
//                                : �\�[�g�����̓`�[�ԍ��̌�Ɏd��SEQ�ԍ���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/28  �C�����e : �s��Ή�[10599]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/14  �C�����e : ����œ]�ŕ���[�`�[][����]�ȊO�͔�\���ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� �[���N
// �C �� ��  2009/07/17  �C�����e : ���׃^�C�v�̏���ŋ��z��
//                                  ����œ]�ŕ���[����]�ȊO�͔�\���ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 3H ����
// �C �� ��  2020/02/27  �C�����e : 11570208-00 �y���ŗ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O
// �C �� ��  2022/09/28   �C�����e : 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    using StockConfNames        = MAKON02249EA; // ADD 2008/10/07 �s��Ή�[5664]
    using StockConfSlipTtlNames = MAKON02249EB; // ADD 2008/10/07 �s��Ή�[5664]

	/// <summary>
    /// �d���`�F�b�N���X�g�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����ʕ\�ɃA�N�Z�X����N���X�ł�</br>
    /// <br>Programer  : 22021�@�J���@�͍K</br>
    /// <br>Date       : 2005.01.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E�f�[�^���ڂ̒ǉ�/�C��</br>
    /// <br>Programmer	: 30415 �ēc �ύK</br>
    /// <br>Date		: 2008/07/16</br>
    /// <br>UpdateNote	: �Edayliheader�̃L�[�u���C�N�Ɏd��SEQ�ԍ���ǉ�</br>
    /// <br>            : �E�\�[�g�����̓`�[�ԍ��̌�Ɏd��SEQ�ԍ���ǉ�</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2008/12/02</br>
    /// <br>UpdateNote  : 2009/01/28 �Ɠc �M�u�@�s��Ή�[10599]</br>
    /// <br>UpdateNote  : 2009/04/14 ��� �r���@����œ]�ŕ���[�`�[][����]�ȊO�͔�\���ɏC��</br>
    /// <br>UpdateNote	: 2020/02/27 3H ���� 11570208-00 �y���ŗ��Ή�</br>
    /// <br>UpdateNote	: 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// </remarks>
	public class StockConfAcs
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
		
	    #endregion

        // ===================================================================================== //
        //  �����g�p�ϐ�
        // ===================================================================================== //
        #region private member

        private static SecInfoAcs _secInfoAcs;
        /// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
	    private static PrtOutSetAcs prtOutSetAcs         = null;
        /// <summary>����pDataSet</summary>
		public DataSet _printDataSet;
        /// <summary>�o�b�t�@DataSet</summary>
        public static DataSet _printBuffDataSet;

		/// <summary>�d���m�F�\(���גP��)�f�[�^�e�[�u����</summary>
        private string _StockConfDataTable;
		/// <summary>�d���m�F�\(�`�[�P��)�f�[�^�e�[�u����</summary>
		private string _StockConfSlipTtlDataTable;

        /// <summary>�\������</summary>
		private string CT_Sort1_Odr = "StockDateRF, SupplierSlipNoRF, StockRowNoRF";                                // �d�������`�[�ԍ�
		private string CT_Sort2_Odr = "CustomerCodeRF, StockDateRF, SupplierSlipNoRF, StockRowNoRF";                                // �d�������`�[�ԍ�
		private string CT_Sort3_Odr = "InputDayRF, SupplierSlipNoRF, StockRowNoRF";                                // �d�������`�[�ԍ�
		private string CT_Sort4_Odr = "CustomerCodeRF, InputDayRF, SupplierSlipNoRF, StockRowNoRF";                                // �d�������`�[�ԍ�
		private string CT_Sort5_Odr = "SupplierSlipNoRF, StockRowNoRF";                                             // �`�[�ԍ�

        private string CT_UpperOrder = " ASC";   // �����o��
        //private string CT_DownOrder  = " DESC";  // �~���o��

        // ADD 2008/10/15 �s��Ή�[5651]---------->>>>>
        /// <summary>�J�E���g�ς݂̓`�[�L�[���X�g</summary>
        private readonly IList<string> _countedSlipKeyList = new List<string>();
        /// <summary>
        /// �J�E���g�ς݂̓`�[�L�[���X�g���擾���܂��B
        /// </summary>
        /// <value>�J�E���g�ς݂̓`�[�L�[���X�g</value>
        private IList<string> CountedSlipKeyList
        {
            get { return _countedSlipKeyList; }
        }

        // ADD 2008/10/15 �s��Ή�[5651]----------<<<<<
        // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        /// <summary>�J�E���g�ς݂̓`�[�L�[���X�g</summary>
        private readonly IList<string> _countedTaxFreeSlipKeyList = new List<string>();
        /// <summary>
        /// �J�E���g�ς݂̓`�[�L�[���X�g���擾���܂��B
        /// </summary>
        /// <value>�J�E���g�ς݂̓`�[�L�[���X�g</value>
        private IList<string> CountedTaxFreeSlipKeyList
        {
            get { return _countedTaxFreeSlipKeyList; }
        }
        // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
        // --- ADD START 3H ���� 2020/02/27---------->>>>>
        private int _iTaxPrintDiv;  // �ŕʓ���󎚗L���敪
        private Double _taxRate1;   // �ŗ��P
        private Double _taxRate2;   // �ŗ��Q
        // --- ADD END 3H ���� 2020/02/27----------<<<<<
	    #endregion
        
        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant
	  
		///// <summary>�d�����ʕ\�o�b�t�@�f�[�^�e�[�u����</summary>
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

		private const string ct_DateFormat = "yyyy/MM/dd";
        #endregion
        
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
		#region �R���X�g���N�^�[
       
		/// <summary>
        /// �d�����ʕ\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021 �J���@�͍K</br>
        /// <br>Date       : 2005.01.30</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public StockConfAcs()
        {
            this.SettingDataTable();

            // ����pDataSet
		    this._printDataSet	= new DataSet();
            DataSetColumnConstruction(ref this._printDataSet);
            // �o�b�t�@�e�[�u���f�[�^�Z�b�g
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // ���_���擾
            this.CreateSecInfoAcs();
        }
        
		#endregion

        // ===================================================================================== //
        // �ÓI�R���X�g���N�^
        // ===================================================================================== //
        #region �ÓI�R���X�g���N�^�[

		/// <summary>
        /// �d�����ʕ\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021�@�J���@�͍K</br>
        /// <br>Date       : 2006.01.31</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static StockConfAcs()
        {
            // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
		    prtOutSetAcs       = new PrtOutSetAcs();

            // ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				mySectionCode = loginEmployee.BelongSectionCode;
		    }
	    }

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
		/// <br>Programmer : 22021 �J���@�͍K</br>
		/// <br>Date       : 2005.10.13</br>
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
    	/// �d�����ʕ\�f�[�^����������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static�������������܂��B</br>
		/// <br>Programmer : 22021�@�J���@�͍K</br>
		/// <br>Date       : 2006.01.31</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
     		// --�e�[�u���s������-----------------------
			// ���o���ʃf�[�^�e�[�u�����N���A
			if(this._printDataSet.Tables[_StockConfDataTable] != null)
			{
				this._printDataSet.Tables[_StockConfDataTable].Rows.Clear();
			}
			// ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (_printBuffDataSet.Tables[_StockConfDataTable] != null)
			{
                _printBuffDataSet.Tables[_StockConfDataTable].Rows.Clear();
			}
			// �d���m�F�\(�`�[�P��)���o���ʃf�[�^�e�[�u�����N���A
			if (this._printDataSet.Tables[_StockConfSlipTtlDataTable] != null)
			{
				this._printDataSet.Tables[_StockConfSlipTtlDataTable].Rows.Clear();
			}
		}

        /// <summary>
        /// �d�����ʕ\�f�[�^�擾����
        /// </summary>
        /// <param name="stockConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="mode">�T�[�`���[�h(0:remote only,1:static��remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_MAKON02247E stockConfListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch(mode)
            {
                case 0:
                    {
                        status = this.Search(stockConfListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        //status = this.SearchStatic(out message);
                        //if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //{
                            status = this.Search(stockConfListCndtn, out message);
                        //}
                        break;
                    }
                case 2:
                    {
                        // static only �̏ꍇ�̓����[�e�B���O�ɍs���Ȃ�
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �d�����ʕ\�X�^�e�B�b�N�f�[�^�擾����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;
            
            this._printDataSet.Tables[_StockConfDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_StockConfDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_StockConfDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_StockConfDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_StockConfDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_StockConfDataTable].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

	    /// <summary>
		/// �d�����ʕ\�f�[�^�擾����
		/// </summary>
        /// <param name="stockConfListCndtn"></param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �Ώ۔͈͂̎d���`�F�b�N���X�g�f�[�^���擾���܂��B</br>
		/// <br>Programmer : 22021�@�J���@�͍K</br>
		/// <br>Date       : 2006.01.31</br>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
		/// </remarks>
		private int Search(ExtrInfo_MAKON02247E stockConfListCndtn, out string message)
		{
			object retObj;
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		    message    = "";
			try
			{
                // --- ADD START 3H ���� 2020/02/27---------->>>>>
                _iTaxPrintDiv = stockConfListCndtn.TaxPrintDiv;�@�@// �ŕʓ���󎚗L���敪
                _taxRate1 = 0;                                     // �ŗ��P
                _taxRate2 = 0;                                     // �ŗ��Q
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(stockConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(stockConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H ���� 2020/02/27----------<<<<<

				// StaticMemory�@������
				InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
                StockConfShWork stockConfShWork = new StockConfShWork();
                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(stockConfListCndtn, ref stockConfShWork);

                status = this.SearchByMode(out retObj, stockConfShWork);

				ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // --- DEL 2008/07/16 -------------------------------->>>>>
                    //DataRow stockDr = null;
                    //bool existExplaFlg = true;   // �ڍ׏��L���t���O
                    //int prevSupplierSlipNo = 0;  // �O��`�[�ԍ�
                    //int prevStockRowNo = 0;      // �O��s�ԍ�
                    // --- DEL 2008/07/16 --------------------------------<<<<< 

					// ���擾
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_StockConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i, stockConfListCndtn);

						

#if False
                        if (stockConfListCndtn.PrintDiv == 1)
                        {
#endif
						// ���׃^�C�v�̏ꍇ
						this._printDataSet.Tables[_StockConfDataTable].Rows.Add(dr);
#if False
						}
                        else
                        {
                            // �`�[�ԍ��A�܂��͍s�ԍ����ς������
                            if ((prevSupplierSlipNo != 0) &&
                                (prevStockRowNo != 0))
                            {
                                if ((prevSupplierSlipNo != int.Parse(dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString())) ||
                                    (prevStockRowNo != int.Parse(dr[MAKON02249EA.CT_StockConf_StockRowNoRF].ToString())))
                                {
                                    if (stockDr != null)
                                    {
                                        if (existExplaFlg == false)
                                        {
                                            // ���ɏڍ׏��������ׂ������ꍇ�A�ڍ׍s�ԍ����N���A
                                            stockDr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;
                                        }
                                        // �ێ����Ă��������ԋ󔒖��ׂ̏�������
                                        this._printDataSet.Tables[_StockConfDataTable].Rows.Add(stockDr);
                                    }

                                    // ���וێ����N���A
                                    stockDr = null;
                                    existExplaFlg = true;
                                }
                            }
#if False
                            // �ڍ׃^�C�v�̏ꍇ(�ڍ׏��Ȃ��̖��ׂ��܂Ƃ߂邽�߂̏���)
                            if ((dr[MAKON02249EA.CT_StockConf_ProductNumber1RF].ToString() == "") &&
                                (dr[MAKON02249EA.CT_StockConf_ProductNumber2RF].ToString() == "") &&
                                (dr[MAKON02249EA.CT_StockConf_StockTelNo1RF].ToString() == "") &&
                                (dr[MAKON02249EA.CT_StockConf_StockTelNo2RF].ToString() == ""))
                            {
                                if (stockDr == null)
                                {
                                    // �����ԍ��󔒂̏ڍז��ׂ�ۊ�
                                    stockDr = dr;
                                }
                                else
                                {
                                    if ((prevSupplierSlipNo == int.Parse(dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString())) &&
                                        (prevStockRowNo == int.Parse(dr[MAKON02249EA.CT_StockConf_StockRowNoRF].ToString())))
                                    {
                                        existExplaFlg = false;
                                    }
                                }
                            }
                            else
                            {
#endif
							this._printDataSet.Tables[_StockConfDataTable].Rows.Add(dr);

#if False
							}
#endif

							// �O��`�[�ԍ��A�s�ԍ��̕ێ�
                            prevSupplierSlipNo = int.Parse(dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString());
                            prevStockRowNo = int.Parse(dr[MAKON02249EA.CT_StockConf_StockRowNoRF].ToString());
                        }
#endif
					}

#if False
					// �ŏI�ێ����ׂ̏���
                    if (stockDr != null)
                    {
                        if (existExplaFlg == false)
                        {
                            // ���ɏڍ׏��������ׂ������ꍇ�A�ڍ׍s�ԍ����N���A
                            stockDr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;
                        }
                        // �ێ����Ă��������ԋ󔒖��ׂ̏�������
                        this._printDataSet.Tables[_StockConfDataTable].Rows.Add(stockDr);
                    }
#endif

                    // ���וێ����N���A
                    // --- DEL 2008/07/16 -------------------------------->>>>>
                    //stockDr = null;
                    //existExplaFlg = true;
                    // --- DEL 2008/07/16 --------------------------------<<<<< 
                    this._printDataSet.AcceptChanges();

                    // ADD 2008/10/07 �s��Ή�[5664]---------->>>>>
                    this._printDataSet = CreateSortedDataSet(
                        this._printDataSet.Tables[_StockConfDataTable],
                        GetOrderByPhraseOfStockConf(stockConfListCndtn)
                    );
                    // ADD 2008/10/07 �s��Ή�[5664]----------<<<<<

                    // �o�b�t�@�e�[�u���ւ̊i�[
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}

			}
			
			catch (Exception ex)
			{
				status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}


            #region �e�X�g�f�[�^
#if false
            DataRow ab;
            int j;

            for (j = 1; j < 10; j++)
            {
                ab = this._printDataSet.Tables[_StockConfDataTable].NewRow();

                //if (j > 7)
                //{
                //    ab[MAKON02249EA.CT_StockConf_SectionCodeRF] = "02";                                     // ���_�R�[�h         (string)
                //}
                //else
                //{
                    ab[MAKON02249EA.CT_StockConf_SectionCodeRF] = "01";                                     // ���_�R�[�h         (string)
                //}

                ab[MAKON02249EA.CT_StockConf_SectionGuideNmRF] = "�e�X�g���_���̂P�P�P";                      // ���_�K�C�h����     (string)  // ADD 2008/07/16

                if (j == 1)
                {
                    ab[MAKON02249EA.CT_StockConf_StockDateRF] = DateTime.Parse("2008/06/24");               // �d�����t           (DateTime)
                }
                else
                {
                    ab[MAKON02249EA.CT_StockConf_StockDateRF] = DateTime.Parse("2008/06/25");               // �d�����t           (DateTime)
                }

                ab[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF] = DateTime.Parse("2008/06/24");         // �o�ד��t           (DateTime)
                ab[MAKON02249EA.CT_StockConf_InputDayRF] = DateTime.Parse("2008/06/24");                // ���͓��t           (DateTime)
                ab[MAKON02249EA.CT_StockConf_StockAddUpADateRF] = DateTime.Parse("2008/06/24");	        // �d���v����t       (DateTime)
                ab[MAKON02249EA.CT_StockConf_StockDateStringRF] = DateTime.Parse("2008/06/24");			// �d�����t(����p)     (DateTime)
                ab[MAKON02249EA.CT_StockConf_ArrivalGoodsDayStringRF] = "2008/06/24";                   // �o�ד��t(����p)     (DateTime)
                ab[MAKON02249EA.CT_StockConf_InputDayStringRF] = "2008/06/24";			                // ���͓��t(����p)     (DateTime)
                ab[MAKON02249EA.CT_StockConf_StockAddUpADateStringRF] = DateTime.Parse("2008/06/24");	// �d���v����t(����p) (DateTime)

                //if (j < 3)
                //{
                //    ab[MAKON02249EA.CT_StockConf_SupplierCd] = "999999";                    // �d����R�[�h       (Int32)
                //}
                //else
                //{
                    ab[MAKON02249EA.CT_StockConf_SupplierCd] = "999998";                    // �d����R�[�h       (Int32)
                //}

                ab[MAKON02249EA.CT_StockConf_SupplierSnm] = "�e�X�g�d���旪�̂P�P�Q�Q�Q�Q�Q";  // �d���旪��
                ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF] = j.ToString();      // �����`�[�ԍ� (string)
                ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF] = j;       // �d���`�[�ԍ�       (Int32)

                string aaa, bbb;
                aaa = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString();
                bbb = ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString();

                //�w�b�_�[��DataField�ݒ�
                ab[MAKON02249EA.CT_StockConf_groupHeader1DataField] = aaa.PadLeft(2, '0') + bbb.PadLeft(6, '0');

                int sort = 1;
                // �d���恨�`�[���t���`�[�ԍ�
                if (sort == 1)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF].ToString();
                }
                // �d���恨���͓��t���`�[�ԍ�
                else if (sort == 3)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_InputDayRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_InputDayRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF].ToString();
                }
                // �d���恨�`�[�ԍ�
                else if (sort == 4)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF].ToString();
                }
                else if (sort == 5)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString();
                }
                else if (sort == 6)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString();
                }
                else
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString();
                }

                ab[MAKON02249EA.CT_StockConf_SupplierSlipNote1RF] = "�e�X�g�d���`�[���l�P�Q�Q�Q�Q�Q�Q�Q�Q�Q�Q�R�R�R�R�R�R�R�R�R�R"; // ���l�P
                ab[MAKON02249EA.CT_StockConf_SupplierSlipNote2RF] = "�e�X�g�d���`�[���l2";                                           // ���l�Q

                ab[MAKON02249EA.CT_StockConf_BfListPriceRF] = 111111111;        // �ύX�O�艿  // ADD 2008/07/16
                ab[MAKON02249EA.CT_StockConf_ListPriceFlRF] = 111111111;  // �艿

                // �d���`�[�敪��
                ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = 10;
                ab[MAKON02249EA.CT_StockConf_EnterpriseGanreCodeRF] = 20;	                 //���Е��ރR�[�h
                ab[MAKON02249EA.CT_StockConf_EnterpriseGanreNameRF] = "�e�X�g���Е��ޖ���";
                ab[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = 111111;			                 // ���[�J�[�R�[�h
                ab[MAKON02249EA.CT_StockConf_GoodsNameRF] = "�e�X�g���i���̂P�P�P";    // ���i����
                ab[MAKON02249EA.CT_StockConf_GoodsCodeRF] = "111111111122222222223333";                           // ���i�R�[�h
                ab[MAKON02249EA.CT_StockConf_WarehouseCodeRF] = "600";                       // �q�ɃR�[�h
                ab[MAKON02249EA.CT_StockConf_StockOrderDivNmRF] = "�ݎ�敪";                // �ݎ�敪��
                ab[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = 11111111;                            // BL�R�[�h

                ab[MAKON02249EA.CT_StockConf_StockRowNoRF] = 15;               // �d���s�ԍ�         (Int32)
                ab[MAKON02249EA.CT_StockConf_DebitNoteDivRF] = 2;              // �ԓ`�敪           (Int32)
                ab[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF] = "�e�X�g�ԓ`"; // �ԓ`�敪�� (string)
                ab[MAKON02249EA.CT_StockConf_AccPayDivCdRF] = 1;               // ���|�敪           (Int32)
                ab[MAKON02249EA.CT_StockConf_AccPayDivNmRF] = "�e�X�g���|�敪��";
                ab[MAKON02249EA.CT_StockConf_StockAgentCodeRF] = "100";        // �d���S���҃R�[�h   (string)
                ab[MAKON02249EA.CT_StockConf_StockAgentNameRF] = "�e�X�g�d���S���Җ���";
                ab[MAKON02249EA.CT_StockConf_SupplierSlipCdRF] = 20;           // �d���`�[�敪       (Int32)
                ab[MAKON02249EA.CT_StockConf_SupplierSlipNmRF] = this.GetSupplierSlipNm(20);
                ab[MAKON02249EA.CT_StockConf_FirstRowFlg] = 9;                 // �擪�o�͖��׃t���O (Int32)
                // ���גP�ʏo�͂̏ꍇ�A�������͏ڍגP�ʏo�͂̈�s�ڂ̏ꍇ�̂ݏo��
                ab[MAKON02249EA.CT_StockConf_StockCountRF] = 11111111;               // �d����             (double)
                ab[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = 111111111;          // �d���P��           (Int64)
                ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = 999999999999;       // �d�����z           (Int64)
                ab[MAKON02249EA.CT_StockConf_TaxRF] = 111111111111;       // �d�����z����Ŋz

                ab[MAKON02249EA.CT_StockConf_StockPriceTaxIncRF] = Int64.Parse(ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) + Int64.Parse(ab[MAKON02249EA.CT_StockConf_TaxRF].ToString());

                ab[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = 111111111;             // �ύX�O�d���P�� 
                ab[MAKON02249EA.CT_StockConf_MakerNameRF] = "�e�X�g���[�J�[����";           // ���[�J�[����
                ab[MAKON02249EA.CT_StockConf_WarehouseNameRF] = "�e�X�g�q�ɖ��̂P�P�P";    // �q�ɖ���
                ab[MAKON02249EA.CT_StockConf_SalesSlipNum] = 111111111;                    // ����`�[�ԍ�
                ab[MAKON02249EA.CT_StockConf_StockDtiSlipNote1RF] = "";     // �d���`�[���ה��l1
                ab[MAKON02249EA.CT_StockConf_CustomerCodeRF] = 111111;                   // ���Ӑ�R�[�h
                ab[MAKON02249EA.CT_StockConf_UoeRemark1] = "99999999991111111111";
                ab[MAKON02249EA.CT_StockConf_UoeRemark2] = "9999999999";

                ab[MAKON02249EA.CT_StockConf_FirstRowFlg] = 1;             // �擪�o�͖��׃t���O (Int32)
                ab[MAKON02249EA.CT_StockConf_StockRowNoRF] = 123;          // �d���ڍהԍ�       (Int32)
                ab[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;        // �d���ڍהԍ�       (Int32)

                //10:�d��
                if ((int)ab[MAKON02249EA.CT_StockConf_SupplierSlipCdRF] == 10)
                {
                    // �`�[����(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                    // �`�[����(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
                    // �`�[����(���v)
                    ab[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                    // �d�����z(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF];
                    // �����(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = ab[MAKON02249EA.CT_StockConf_TaxRF];
                    // ���v���z(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = Int64.Parse(ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) + Int64.Parse(ab[MAKON02249EA.CT_StockConf_TaxRF].ToString());

                    // �d�����z(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = 0;
                    // �����(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = 0;
                    // ���v���z(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = 0;
                }
                //20:�d��
                else
                {
                    // �`�[����(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalCntRF] = 0;
                    // �`�[����(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                    // �`�[����(���v)
                    ab[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                    // �d�����z(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = 0;
                    // �����(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = 0;
                    // ���v���z(�d��)
                    ab[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = 0;

                    // �d�����z(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF];
                    // �����(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = ab[MAKON02249EA.CT_StockConf_TaxRF];
                    // ���v���z(�ԕi�l��)
                    ab[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = Int64.Parse(ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) + Int64.Parse(ab[MAKON02249EA.CT_StockConf_TaxRF].ToString());
                }

                this._printDataSet.AcceptChanges();

                // �o�b�t�@�e�[�u���ւ̊i�[
                _printBuffDataSet = this._printDataSet.Copy();
                // ���׃^�C�v�̏ꍇ
                this._printDataSet.Tables[_StockConfDataTable].Rows.Add(ab);
            }
            status = 0;
#endif
            #endregion


      		return status;
        }

        // ADD 2008/10/07 �s��Ή�[5664]---------->>>>>
        /// <summary>
        /// �o�͏��i�\�[�g���j�̗񋓑�<br/>
        /// ����ʂ̏o�͏��R���{�{�b�N�X�̒l�Ɠ��l
        /// </summary>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5664]�ɂĒǉ�</br>
        /// <br>Programmer : 30434�@�H���@�b�D</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private enum SortOrder : int
        {
            /// <summary>�Ȃ�</summary>
            None = 0,

            /// <summary>�d���恨�d�������`�[�ԍ�</summary>
            SupplierCd_StockDate_PartySaleSlipNum = 1,
            /// <summary>�d���恨���͓����`�[�ԍ�</summary>
            SupplierCd_InputDay_PartySaleSlipNum = 3,
            /// <summary>�d���恨�`�[�ԍ�</summary>
            SupplierCd_PartySaleSlipNum = 4,

            /// <summary>�d���恨�d�������d��SEQ�ԍ�</summary>
            SupplierCd_StockDate_SupplierSlipNo = 5,
            /// <summary>�d���恨���͓����d��SEQ�ԍ�</summary>
            SupplierCd_InputDay_SupplierSlipNo = 6,
            /// <summary>�d���恨�d��SEQ�ԍ�</summary>
            SupplierCd_SupplierSlipNo = 7
        }

        /// <summary>
        /// �d���m�F�\(���גP��)�̃\�[�g����(ORDER BY��)���擾���܂��B
        /// </summary>
        /// <param name="sortConditionInfo">�\�[�g�����̏��</param>
        /// <returns>�d���m�F�\(���גP��)�̃\�[�g������ORDER BY��</returns>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5664]�ɂĒǉ�</br>
        /// <br>Programmer : 30434�@�H���@�b�D</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private static string GetOrderByPhraseOfStockConf(ExtrInfo_MAKON02247E sortConditionInfo)
        {
            string orderBy = StockConfNames.CT_StockConf_SectionCodeRF + "," + StockConfNames.CT_StockConf_SupplierCd;

            switch (sortConditionInfo.SortOrder)
            {
                case (int)SortOrder.SupplierCd_StockDate_SupplierSlipNo:    // �d���恨�d�������d��SEQ�ԍ�
                    orderBy += "," + StockConfNames.CT_StockConf_StockDateRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_SupplierSlipNo:     // �d���恨���͓����d��SEQ�ԍ�
                    orderBy += "," + StockConfNames.CT_StockConf_InputDayRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_SupplierSlipNo:              // �d���恨�d��SEQ�ԍ�
                    orderBy += "," + StockConfNames.CT_StockConf_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_PartySaleSlipNum:   // �d���恨���͓����`�[�ԍ����d��SEQ�ԍ�
                    orderBy += "," + StockConfNames.CT_StockConf_InputDayRF + "," + StockConfNames.CT_StockConf_PartySaleSlipNumRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                case (int)SortOrder.SupplierCd_PartySaleSlipNum:            // �d���恨�`�[�ԍ����d��SEQ�ԍ�
                    orderBy += "," + StockConfNames.CT_StockConf_PartySaleSlipNumRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                default:// �d���恨�d�������`�[�ԍ����d��SEQ�ԍ�
                    orderBy += "," + StockConfNames.CT_StockConf_StockDateRF + "," + StockConfNames.CT_StockConf_PartySaleSlipNumRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
            }

            return orderBy;
        }

        /// <summary>
        /// �d���m�F�\(�`�[�P��)�̃\�[�g����(ORDER BY��)���擾���܂��B
        /// </summary>
        /// <param name="sortConditionInfo">�\�[�g�����̏��</param>
        /// <returns>�d���m�F�\(�`�[�P��)�̃\�[�g������ORDER BY��</returns>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5664]�ɂĒǉ�</br>
        /// <br>Programmer : 30434�@�H���@�b�D</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private static string GetOrderByPhraseOfStockConfSlipTtl(ExtrInfo_MAKON02247E sortConditionInfo)
        {
            string orderBy = StockConfSlipTtlNames.CT_StockConfSlipTtl_SectionCodeRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierCd;
            
            switch (sortConditionInfo.SortOrder)
            {
                case (int)SortOrder.SupplierCd_StockDate_SupplierSlipNo:    // �d���恨�d�������d��SEQ�ԍ�
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_StockDateRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_SupplierSlipNo:     // �d���恨���͓����d��SEQ�ԍ�
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_InputDayRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_SupplierSlipNo:              // �d���恨�d��SEQ�ԍ�
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_PartySaleSlipNum:   // �d���恨���͓����`�[�ԍ����d��SEQ�ԍ�
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_InputDayRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_PartySaleSlipNumRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                case (int)SortOrder.SupplierCd_PartySaleSlipNum:            // �d���恨�`�[�ԍ����d��SEQ�ԍ�
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_PartySaleSlipNumRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                default:// �d���恨�d�������`�[�ԍ����d��SEQ�ԍ�
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_StockDateRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_PartySaleSlipNumRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
            }

            return orderBy;
        }

        /// <summary>
        /// �\�[�g���ꂽ�d���m�F�\�f�[�^�Z�b�g�𐶐����܂��B
        /// </summary>
        /// <param name="originalDataTable">���e�[�u��</param>
        /// <param name="orderBy">�\�[�g����</param>
        /// <returns>�\�[�g���ꂽ�d���m�F�\�f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5664]�ɂĒǉ�</br>
        /// <br>Programmer : 30434�@�H���@�b�D</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private static DataSet CreateSortedDataSet(
            DataTable originalDataTable,
            string orderBy
        )
        {
            DataSet dataSet = new DataSet();
            DataSetColumnConstruction(ref dataSet);

            DataRow[] sortedRows = originalDataTable.Select("", orderBy);

            foreach (DataRow dataRow in sortedRows)
            {
                dataSet.Tables[originalDataTable.TableName].Rows.Add(dataRow.ItemArray);
            }

            return dataSet;
        }
        // ADD 2008/10/07 �s��Ή�[5664]----------<<<<<

		/// <summary>
		/// �f�[�^�擾����(�`�[�`��)
		/// </summary>
		/// <param name="stockConfListCndtn"></param>
		/// <param name="message"></param>
		/// <returns></returns>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
		public int SearchSlipTtl(ExtrInfo_MAKON02247E stockConfListCndtn, out string message)
		{
			object retObj = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			message = "";

			try
			{
                // --- ADD START 3H ���� 2020/02/27---------->>>>>
                _iTaxPrintDiv = stockConfListCndtn.TaxPrintDiv;�@�@// �ŕʓ���󎚗L���敪
                _taxRate1 = 0;                                     // �ŗ��P
                _taxRate2 = 0;                                     // �ŗ��Q
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(stockConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(stockConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H ���� 2020/02/27----------<<<<<

				// StaticMemory�@������
				InitializeCustomerLedger();

				// �����[�g����f�[�^�̎擾
				StockConfShWork stockConfShWork = new StockConfShWork();
				// ���o�����p�����[�^�Z�b�g
				this.SearchParaSet(stockConfListCndtn, ref stockConfShWork);

	            IStockConfDB _iStockConfDB = (IStockConfDB)MediationStockConfDB.GetStockConfDB();
				status = _iStockConfDB.SearchSlipTtl(out retObj, stockConfShWork);

				ArrayList retList = new ArrayList();
				retList = (ArrayList)retObj;

				if ((status == 0) && (retList.Count != 0))
				{
					// ���擾
					for (int i = 0; i < retList.Count; i++)
					{
						DataRow dr;

						dr = this._printDataSet.Tables[_StockConfSlipTtlDataTable].NewRow();
						SetStockConfSlipTtlDataTableRowFromRetList(ref dr, retList, i);

						this._printDataSet.Tables[_StockConfSlipTtlDataTable].Rows.Add(dr);
					}

                    // ADD 2008/10/07 �s��Ή�[5664]---------->>>>>
                    this._printDataSet = CreateSortedDataSet(
                        this._printDataSet.Tables[_StockConfSlipTtlDataTable],
                        GetOrderByPhraseOfStockConfSlipTtl(stockConfListCndtn)
                    );
                    // ADD 2008/10/07 �s��Ή�[5664]----------<<<<<

					status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}


                #region �e�X�g�f�[�^
#if false
                DataRow ab;

                for (int j = 1; j < 34; j++)
                {
                    ab = this._printDataSet.Tables[_StockConfSlipTtlDataTable].NewRow();

                    //if (j > 3)
                    //{
                    //    // ���_�R�[�h
                    //    ab[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF] = "02";
                    //}
                    //else
                    //{
                        // ���_�R�[�h
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF] = "01";
                    //}

                    // ���_�K�C�h����
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SectionGuideNmRF] = "�e�X�g�K�C�h���̂P�P";

                    //if (j < 2)
                    //{
                    //    // �d����R�[�h
                    //    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd] = 999999;
                    //}
                    //else
                    //{
                        // �d����R�[�h
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd] = 999998;
                    //}

                    // �d���旪��
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSnm] = "�e�X�g�d����P�P�P�P�Q�Q�Q�Q�Q";

                    // ���͓��t
                    ab[MAKON02249EB.CT_StockConfSlipTtl_InputDayRF] = DateTime.Parse("2008/06/25");
                    // ���͓��t(���)
                    ab[MAKON02249EB.CT_StockConfSlipTtl_InputDayNmRF] = "2008/06/25";

                    // ���ד��t
                    ab[MAKON02249EB.CT_StockConfSlipTtl_ArrivalGoodsDayRF] = DateTime.Parse("2008/06/25");
                    // ���͓��t(���)
                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockDateRF] = "2008/06/25";
                    // �d�����t(���)
                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockDateNmRF] = "2008/06/25";

                    // �d���`��
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalRF] = 0;
                    // �d���`����
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalNmRF] = GetSupplierFormalNm(0);
                    // �d���`�[�ԍ�
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNoRF] = 999999999;
                    // �����`�[�ԍ�
                    ab[MAKON02249EB.CT_StockConfSlipTtl_PartySaleSlipNumRF] = "9999999999888888888";
                    // �d���`�[�敪
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipCdRF] = 10;
                    // �d���`�[�敪��
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = this.GetSupplierSlipNm(10);


                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] = 2;


                    long slipTtl_StockPriceTaxInc = 0;

                    if (((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 2) || ((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 4))
                    {
                        // �d�����z�v�i�Ŕ����j
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 999999999999;
                        // �d�����z����Ŋz
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 999999999999;

                        //���v�l
                        slipTtl_StockPriceTaxInc = 999999999999;
                    }
                    else if (((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 3) || ((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 5))
                    {
                        // �d�����z�v�i�Ŕ����j
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 999999999999;
                        // �d�����z����Ŋz
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 999999999999;

                        //���v�l
                        slipTtl_StockPriceTaxInc = 999999999999;
                    }
                    else
                    {
                        // �d�����z�v�i�Ŕ����j
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 999999999999;
                        // �d�����z����Ŋz
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 999999999999;

                        //���v�l
                        slipTtl_StockPriceTaxInc = 999999999999;
                    }

                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceTaxIncRF] = slipTtl_StockPriceTaxInc;

                    string aaa, bbb;
                    aaa = ab[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF].ToString();
                    bbb = ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd].ToString();
                    ab[MAKON02249EB.COL_KEYBREAK_AR] = aaa.PadLeft(2, '0') + bbb.PadLeft(6, '0');

                    //10:�d��
                    if ((int)ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipCdRF] == 10)
                    {
                        // �`�[����(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 1;
                        // �`�[����(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 0;
                        // �`�[����(���v)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

                        // �d�����z(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = 999999999999;
                        // �����(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 999999999999;
                        // ���v���z(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = 999999999999;

                        // �d�����z(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = 0;
                        // �����(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;
                        // ���v���z(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = 0;
                    }
                    //20:�d��
                    else
                    {
                        // �`�[����(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 0;
                        // �`�[����(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 1;
                        // �`�[����(���v)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

                        // �d�����z(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = 0;
                        // �����(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 0;
                        // ���v���z(�d��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = 0;

                        // �d�����z(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = 999999999999;
                        // �����(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 999999999999;
                        // ���v���z(�ԕi�l��)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = 999999999999;
                    }

                    ab[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark1] = "�e�X�g�t�n�d���}�[�N";
                    ab[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark2] = "���}�[�N�Q";

                    this._printDataSet.Tables[_StockConfSlipTtlDataTable].Rows.Add(ab);
                }

                status = 0;
#endif
                #endregion

			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return status;
		}

		#endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// �����p�����[�^�ݒ菈��
        /// </summary>
        private void SearchParaSet(ExtrInfo_MAKON02247E stockConfListCndtn, ref     StockConfShWork stockConfShWork)
        {
            stockConfShWork.EnterpriseCode = stockConfListCndtn.EnterpriseCode;  // ��ƃR�[�h

            // ���_
			if (stockConfListCndtn.StockSectionCd.Length != 0)
            {
				if (stockConfListCndtn.StockSectionCd[0] == "0")
                {
                    // �S�Ђ̎�
					stockConfShWork.StockSectionCd = new string[0];  // ���_�R�[�h
                    stockConfShWork.IsOutputAllSecRec = true;
                    stockConfShWork.IsSelectAllSection = true;
                }
                else
                {
					stockConfShWork.StockSectionCd = stockConfListCndtn.StockSectionCd;  // ���_�R�[�h
                    stockConfShWork.IsSelectAllSection = false;
                    // �S���_�Ƀ`�F�b�N�������Ă��邩�ǂ����̃`�F�b�N
					if (_secInfoAcs.SecInfoSetList.Length == stockConfListCndtn.StockSectionCd.Length)
                    {
                        stockConfShWork.IsOutputAllSecRec = true;
                    }
                    else
                    {
                        stockConfShWork.IsOutputAllSecRec = false;
                    }
                }
            }
            else
            {
				stockConfShWork.StockSectionCd = new string[0];  // ���_�R�[�h
                stockConfShWork.IsOutputAllSecRec = true;        // �S���_�W�v���R�[�h�ł̏o��
                stockConfShWork.IsSelectAllSection = false;
            }

            stockConfShWork.StockDateSt = stockConfListCndtn.StockDateSt;                // �J�n�d����
            stockConfShWork.StockDateEd = stockConfListCndtn.StockDateEd;                // �I���d����
            stockConfShWork.ArrivalGoodsDaySt = stockConfListCndtn.ArrivalGoodsDaySt;    // �J�n�o�ד�
            stockConfShWork.ArrivalGoodsDayEd = stockConfListCndtn.ArrivalGoodsDayEd;    // �I���o�ד�

			stockConfShWork.InputDaySt = stockConfListCndtn.InputDaySt;			         // �J�n���͓�
			stockConfShWork.InputDayEd = stockConfListCndtn.InputDayEd;				     // �I�����͓�
			stockConfShWork.PrintType = stockConfListCndtn.PrintType;	                 // ���s�^�C�v
			stockConfShWork.PartySaleSlipNumSt = stockConfListCndtn.PartySaleSlipNumSt;  // �J�n�����`�[�ԍ�
			stockConfShWork.PartySaleSlipNumEd = stockConfListCndtn.PartySaleSlipNumEd;  // �I�������`�[�ԍ�

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //stockConfShWork.CustomerCodeSt = stockConfListCndtn.CustomerCodeSt;        // �J�n���Ӑ�R�[�h
            //stockConfShWork.CustomerCodeEd = stockConfListCndtn.CustomerCodeEd;        // �I�����Ӑ�R�[�h
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            stockConfShWork.SupplierCdSt = stockConfListCndtn.SupplierCdSt;              // �d����R�[�h(�J�n)
            stockConfShWork.SupplierCdEd = stockConfListCndtn.SupplierCdEd;              // �d����R�[�h(�I��)
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            stockConfShWork.StockAgentCodeSt = stockConfListCndtn.StockAgentCodeSt;      // �J�n�S���R�[�h
            stockConfShWork.StockAgentCodeEd = stockConfListCndtn.StockAgentCodeEd;      // �I���S���R�[�h
            stockConfShWork.SupplierSlipNoSt = stockConfListCndtn.SupplierSlipNoSt;      // �J�n�d���`�[�ԍ�
            stockConfShWork.SupplierSlipNoEd = stockConfListCndtn.SupplierSlipNoEd;      // �I���d���`�[�ԍ�
            stockConfShWork.DebitNoteDiv = stockConfListCndtn.DebitNoteDiv;              // �ԓ`�敪
            stockConfShWork.SupplierSlipCd = stockConfListCndtn.SupplierSlipCd;          // �`�[�敪

            // --- ADD 2008/07/16 -------------------------------->>>>>
            stockConfShWork.SalesAreaCodeSt = stockConfListCndtn.SalesAreaCodeSt;        // �̔��G���A�R�[�h(�J�n)

            // �̔��G���A�R�[�h(�I��)
            // DEL 2008/10/06 �s��Ή�[5653]��
            //stockConfShWork.SalesAreaCodeEd = stockConfListCndtn.SalesAreaCodeEd;
            // ADD 2008/10/06 �s��Ή�[5653]---------->>>>>
            if (stockConfListCndtn.SalesAreaCodeEd >= 9999)
            {
                stockConfShWork.SalesAreaCodeEd = 0;
            }
            else
            {
                stockConfShWork.SalesAreaCodeEd = stockConfListCndtn.SalesAreaCodeEd;
            }
            // ADD 2008/10/06 �s��Ή�[5653]----------<<<<<

            stockConfShWork.OutputDesignated = stockConfListCndtn.OutputDesignated;      // �o�͎w��
            stockConfShWork.StockOrderDivCd = stockConfListCndtn.StockOrderDivCd;        // �d���݌Ɏ�񂹋敪
            // --- ADD 2008/07/16 --------------------------------<<<<< 

        }

        /// <summary>
        /// �f�[�^�X�L�[�}�\������
        /// </summary>
        private static void DataSetColumnConstruction(ref DataSet ds)
		{
			// ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.MAKON02249EA.SettingDataSet(ref ds);
			Broadleaf.Application.UIData.MAKON02249EB.SettingDataSet(ref ds);
		}

        /// <summary>
        /// ���[�h����Search�ďo����
        /// </summary>
        /// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockConfShWork">�����[�g���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByMode(out object retObj, StockConfShWork stockConfShWork)
        {
            int status = 0;

            retObj = null;

            IStockConfDB _iStockConfDB = (IStockConfDB)MediationStockConfDB.GetStockConfDB();

            status = _iStockConfDB.Search(out retObj, stockConfShWork);

            return status;
        }

        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.12.06</br>
        /// </remarks>
        private string GetPrintOderQuerry(ExtrInfo_MAKON02247E stockConfListCndtn)
        {
            string orderQuerry = "";

            // �\�[�g���ݒ�
            switch (stockConfListCndtn.SortOrder)
            {
                case 0:
                    {
						// ���폜���`�[���t���`�[�ԍ�
                        orderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case 1:
                    {
						// �d���恨�`�[���t���`�[�ԍ�
                        orderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 2:
                    {
						// ���폜�����͓��t���`�[�ԍ�
                        orderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case 3:
                    {
						// �d���恨���͓��t���`�[�ԍ�
                        orderQuerry = CT_Sort4_Odr;
                        break;
                    }
                case 4:
                    {
						// �d���恨�`�[�ԍ�
                        orderQuerry = CT_Sort5_Odr;
                        break;
                    }
            }

            // �����Œ�
            orderQuerry += CT_UpperOrder; 

            return orderQuerry;
        }

        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            this._StockConfDataTable = Broadleaf.Application.UIData.MAKON02249EA.CT_StockConfDataTable;
			this._StockConfSlipTtlDataTable = Broadleaf.Application.UIData.MAKON02249EB.CT_StockConfSlipTtlDataTable;
		}


        /// <summary>
		/// �d���m�F�\(�`�[�P��)���o���ʃf�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="retList">�f�[�^�擾�����X�g</param>
        /// <param name="setCnt">���X�g�̃f�[�^�擾Index</param>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
		private void SetStockConfSlipTtlDataTableRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
		{
            StockConfSlipTtlWork stockConfSlipTtlWork = (StockConfSlipTtlWork)retList[setCnt];

			// ���_�R�[�h
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
            //dr[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF]	 = stockConfSlipTtlWork.SectionCode;
            dr[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF] = stockConfSlipTtlWork.StockSectionCd;
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            // ���_�K�C�h����
			//dr[MAKON02249EB.CT_StockConfSlipTtl_SectionGuideNmRF] = stockConfSlipTtlWork.SectionGuideNm;  // DEL 2008/07/16
            dr[MAKON02249EB.CT_StockConfSlipTtl_SectionGuideNmRF] = stockConfSlipTtlWork.SectionGuideSnm;   // ADD 2008/07/16

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //// ���Ӑ�R�[�h
            //dr[MAKON02249EB.CT_StockConfSlipTtl_CustomerCodeRF]	 = stockConfSlipTtlWork.CustomerCode;
            //// ���Ӑ於��
            //dr[MAKON02249EB.CT_StockConfSlipTtl_CustomerSnmRF]	 = stockConfSlipTtlWork.CustomerSnm;
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �d����R�[�h
            dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd] = stockConfSlipTtlWork.SupplierCd;
            // �d���旪��
            dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSnm] = stockConfSlipTtlWork.SupplierSnm;
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            
            // ���͓��t
			dr[MAKON02249EB.CT_StockConfSlipTtl_InputDayRF] = TDateTime.LongDateToDateTime(stockConfSlipTtlWork.InputDay);
			// ���͓��t(���)
			//dr[MAKON02249EB.CT_StockConfSlipTtl_InputDayNmRF]	 = TDateTime.DateTimeToString("YYYY/MM/DD", stockConfSlipTtlWork.InputDay);  // DEL 2008/07/16
            dr[MAKON02249EB.CT_StockConfSlipTtl_InputDayNmRF] = TDateTime.LongDateToDateTime(stockConfSlipTtlWork.InputDay);                 // ADD 2008/07/16


			// ���ד��t
			dr[MAKON02249EB.CT_StockConfSlipTtl_ArrivalGoodsDayRF] = TDateTime.LongDateToDateTime(stockConfSlipTtlWork.ArrivalGoodsDay);
			// ���͓��t(���)
			dr[MAKON02249EB.CT_StockConfSlipTtl_StockDateRF] = stockConfSlipTtlWork.StockDate;
			// �d�����t(���)
			dr[MAKON02249EB.CT_StockConfSlipTtl_StockDateNmRF] = TDateTime.DateTimeToString("YYYY/MM/DD", stockConfSlipTtlWork.StockDate);

			// �d���`��
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalRF] = stockConfSlipTtlWork.SupplierFormal;
			// �d���`����
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalNmRF] = GetSupplierFormalNm(stockConfSlipTtlWork.SupplierFormal);
			// �d���`�[�ԍ�
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNoRF] = stockConfSlipTtlWork.SupplierSlipNo;
			// �����`�[�ԍ�
			dr[MAKON02249EB.CT_StockConfSlipTtl_PartySaleSlipNumRF] = stockConfSlipTtlWork.PartySaleSlipNum;
			// �d���`�[�敪
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipCdRF] = stockConfSlipTtlWork.SupplierSlipCd;
			// �d���`�[�敪��
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = this.GetSupplierSlipNm(stockConfSlipTtlWork.SupplierSlipCd);


			long slipTtl_StockPriceTaxInc = 0;

            // 2009.01.29 30413 ���� �d�����i�敪�ɂ��ݒ���폜 >>>>>>START
            //if ((stockConfSlipTtlWork.StockGoodsCd == 2) || (stockConfSlipTtlWork.StockGoodsCd == 4))
            //{
            //    // �d�����z�v�i�Ŕ����j
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 0;
            //    // �d�����z����Ŋz
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;

            //    //���v�l
            //    slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockPriceConsTax;
            //}
            //else if ((stockConfSlipTtlWork.StockGoodsCd == 3) || (stockConfSlipTtlWork.StockGoodsCd == 5))
            //{
            //    // �d�����z�v�i�Ŕ����j
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTotalPrice;
            //    // �d�����z����Ŋz
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 0;

            //    //���v�l
            //    slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockTotalPrice;
            //}
            //else
            //{
            //    // �d�����z�v�i�Ŕ����j
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;
            //    // �d�����z����Ŋz
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;

            //    //���v�l
            //    slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockSubttlPrice + stockConfSlipTtlWork.StockPriceConsTax;
            //}
            // �d�����z�v�i�Ŕ����j
            dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;

            // 2009.02.05 30413 �l�����̏W�v�����~�X�Ή� >>>>>>START
            // �d�����z����Ŋz
            //long stockPriceConsTax = stockConfSlipTtlWork.StockPriceConsTax; // DEL 2009/04/14
            long stockPriceConsTax = stockConfSlipTtlWork.StockTotalPrice - stockConfSlipTtlWork.StockSubttlPrice; // ADD 2009/04/14

            // �l���p�̏���Ŋz
            long disStockPriceConsTax = stockConfSlipTtlWork.StckDisTtlTaxInclu
                                      + stockConfSlipTtlWork.StockDisOutTax;
            // �d���ԕi�p�̏���Ŋz
            long salRetGdsStockPriceConsTax = stockPriceConsTax - disStockPriceConsTax;
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            string sConTaxRate = string.Empty;
            // �ŕʓ���󎚂̏ꍇ�A
            if (_iTaxPrintDiv == 0)
            {
                // ����Őŗ�
                sConTaxRate = Convert.ToString(stockConfSlipTtlWork.SupplierConsTaxRate * 100) + "%";

                // �d��
                // Title_�ŗ�1
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_Title] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_�ŗ�2
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_Title] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_���̑�
                dr[MAKON02249EB.CT_StockConfSlipTtl_Other_Title] = "���̑�";

                // �ԕi
                // Title_�ŗ�1
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetTitle] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_�ŗ�2
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetTitle] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_���̑�
                dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetTitle] = "���̑�";
                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                // Title_��ې�
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_Title] = "��ې�";
                // Title_��ې�
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetTitle] = "��ې�";
                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
            }
            // --- ADD START 3H ���� 2020/02/27 -----<<<<<

            // �����]�Ŏ��̏���Őݒ�
            if (
                stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ParentPayment)
                    ||
                stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ChildPayment)
                    ||
                stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption)
                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    ||
                (stockConfSlipTtlWork.TaxFreeExistFlag && !stockConfSlipTtlWork.TaxRateExistFlag)
                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
            )
            {
                stockPriceConsTax = 0;
                disStockPriceConsTax = 0;
                salRetGdsStockPriceConsTax = 0;
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // sConTaxRate = string.Empty;
                    if (stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip))
                    {
                        sConTaxRate = Convert.ToString(stockConfSlipTtlWork.SupplierConsTaxRate * 100) + "%";
                    }
                    else 
                    {
                        sConTaxRate = string.Empty;
                    }
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            }
            dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = stockPriceConsTax;
            // 2009.02.05 30413 �l�����̏W�v�����~�X�Ή� <<<<<<END
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // �ŕʓ���󎚂̏ꍇ�A
            if (_iTaxPrintDiv == 0)
            {
                // ����Őŗ�
                dr[MAKON02249EB.CT_Col_ConsTaxRate] = sConTaxRate;
            }
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            
            //���v�l
            slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockSubttlPrice + stockPriceConsTax;
            // 2009.01.29 30413 ���� �d�����i�敪�ɂ��ݒ���폜 <<<<<<END
            
			// �d�����z�v�i�ō��݁j
			//dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
			//														+ stockConfSlipTtlWork.StockPriceConsTax;

			dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceTaxIncRF] = slipTtl_StockPriceTaxInc;

			//dr[MAKON02249EB.COL_KEYBREAK_AR] = stockConfSlipTtlWork.SectionCode + stockConfSlipTtlWork.CustomerCode.ToString("d9");  // DEL 2008/07/16
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
            //dr[MAKON02249EB.COL_KEYBREAK_AR] = stockConfSlipTtlWork.SectionCode + stockConfSlipTtlWork.SupplierCd.ToString("d6");      // ADD 2008/07/16
            dr[MAKON02249EB.COL_KEYBREAK_AR] = stockConfSlipTtlWork.StockSectionCd + stockConfSlipTtlWork.SupplierCd.ToString("d6");      // ADD 2008/07/16
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            
            // 2009.02.05 30413 �l�����̏W�v�����~�X�Ή� >>>>>>START
            // 2009.01.09 30413 ���� �ԕi�ƒl���𕪂��Ĉ� >>>>>>START
			//10:�d��
			if (stockConfSlipTtlWork.SupplierSlipCd == 10)
			{
				// �`�[����(�d��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 1;
				// �`�[����(�ԕi�l��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 0;
				// �`�[����(���v)
				dr[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

                // 2009.01.29 30413 ���� �d�����z�A����ŁA���v���z�̐ݒ���C�� >>>>>>START
                // �d�����z(�d��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTtlPricTaxExc;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;
                dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                             - stockConfSlipTtlWork.StckDisTtlTaxExc;
				// �����(�d��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = stockPriceConsTax;
                dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
				// ���v���z(�d��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
                //                                                    + stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = slipTtl_StockPriceTaxInc;
                dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                     - stockConfSlipTtlWork.StckDisTtlTaxExc
                                                                     + salRetGdsStockPriceConsTax;
                // 2009.01.29 30413 ���� �d�����z�A����ŁA���v���z�̐ݒ���C�� <<<<<<END
                
                //// �d�����z(�ԕi�l��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = 0;
                //// �����(�ԕi�l��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;
                //// ���v���z(�ԕi�l��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = 0;
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                    //if (stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag)) 
                    {
                        // �d������_��ې�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_SalSlipCntRF] = 1;
                        // �d�����z_��ې�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        // �d�������_��ې�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF] = 0;
                        // �d���̏���ō����v���z_��ې�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                    }

                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag) && !stockConfSlipTtlWork.TaxRateExistFlag)
                    {
                        // �����Ȃ�
                    }
                    else
                    {
                        // �ŗ��Q
                        if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // �d������_�ŗ��Q
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF] = 1;
                            // �d�����z_�ŗ��Q
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf; ;
                            // �ŗ��Q
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // �d���̏���ō����v���z_�ŗ��Q
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // �d������_�ŗ��P
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF] = 1;
                            // �d�����z_�ŗ��P
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // �d�������_�ŗ��P
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // �d���̏���ō����v���z_�ŗ��P
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else
                        {
                            // �d������_���̑�
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_SalSlipCntRF] = 1;
                            // �d�����z_���̑�
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // �d�������_���̑�
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // �d���̏���ō����v���z_���̑�
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;

                        }
                    }
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
			}
			//20:�ԕi
			else
			{
				// �`�[����(�d��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 0;
				// �`�[����(�ԕi�l��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 1;
				// �`�[����(���v)
				dr[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

				// �d�����z(�d��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = 0;
				// �����(�d��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 0;
				// ���v���z(�d��)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = 0;

                //// �d�����z(�ԕi�l��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTtlPricTaxExc;
                //// �����(�ԕi�l��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;
                //// ���v���z(�ԕi�l��)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
                //                                                    + stockConfSlipTtlWork.StockPriceConsTax;
                // 2009.01.29 30413 ���� �d�����z�A����ŁA���v���z�̐ݒ���C�� >>>>>>START
                // �d�����z(�ԕi)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTtlPricTaxExc;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;
                dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                                - stockConfSlipTtlWork.StckDisTtlTaxExc;
                // �����(�ԕi)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = stockPriceConsTax;
                dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                // ���v���z(�ԕi)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
                //                                                        + stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsTotalPriceRF] = slipTtl_StockPriceTaxInc;
                dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                        - stockConfSlipTtlWork.StckDisTtlTaxExc
                                                                        + salRetGdsStockPriceConsTax;
                // 2009.01.29 30413 ���� �d�����z�A����ŁA���v���z�̐ݒ���C�� <<<<<<END
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                    // if (stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag)) 
                    {
                        // �d������_���̑�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_DisSlipCntRF] = 1;
                        // �d�����z(�ԕi)_���̑�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        // �d�������(�ԕi)_���̑�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF] = 0;
                        // �d���̏���ō����v���z_���̑�
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                    }

                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag) && !stockConfSlipTtlWork.TaxRateExistFlag)
                    {
                        //�@�����Ȃ�
                    }
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    else
                    {
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // �ŗ��Q
                        if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // �d������_�ŗ��Q
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF] = 1;
                            // �d�����z(�ԕi)_�ŗ��Q
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // �d�������(�ԕi)_�ŗ��Q
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // �d���̏���ō����v���z_�ŗ��Q
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // �d������_�ŗ��P
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF] = 1;
                            // �d�����z(�ԕi)_�ŗ��P
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // �d�������(�ԕi)_�ŗ��P
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // �d���̏���ō����v���z_�ŗ��P
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else
                        {
                            // �d������_���̑�
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_DisSlipCntRF] = 1;
                            // �d�����z(�ԕi)_���̑�
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // �d�������(�ԕi)_���̑�
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // �d���̏���ō����v���z_���̑�
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    }
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            }

            // �d�����z(�l��)
            dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StckDisTtlTaxExc;
            // �����(�l��)
            //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = stockConfSlipTtlWork.StckDisTtlTaxInclu
            //                                                            + stockConfSlipTtlWork.StockDisOutTax;
            dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = disStockPriceConsTax;
            // ���v���z(�l��)
            //dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = stockConfSlipTtlWork.StckDisTtlTaxExc
            //                                                     + stockConfSlipTtlWork.StckDisTtlTaxInclu
            //                                                     + stockConfSlipTtlWork.StockDisOutTax;
            dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = stockConfSlipTtlWork.StckDisTtlTaxExc
                                                                 + disStockPriceConsTax;
            // 2009.01.09 30413 ���� �ԕi�ƒl���𕪂��Ĉ� <<<<<<END
            // 2009.02.05 30413 �l�����̏W�v�����~�X�Ή� <<<<<<END
            
            // --- ADD 2008/07/16 -------------------------------->>>>>

            dr[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark1] = stockConfSlipTtlWork.UoeRemark1;
            dr[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark2] = stockConfSlipTtlWork.UoeRemark2;
            // --- ADD 2008/07/16 --------------------------------<<<<<

            // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
            // �d���摍�z�\�����@�敪
            dr[MAKON02249EB.CT_StockConfSlipTtl_SuppTtlAmntDspWayCd] = stockConfSlipTtlWork.SuppTtlAmntDspWayCd;

            // �d�������œ]�ŕ����R�[�h
            dr[MAKON02249EB.CT_StockConfSlipTtl_SuppCTaxLayCd] = stockConfSlipTtlWork.SuppCTaxLayCd;

            // �d�����z����Ŋz�i���Łj
            dr[MAKON02249EB.CT_StockConfSlipTtl_StckPrcConsTaxInclu] = stockConfSlipTtlWork.StckPrcConsTaxInclu;

            // �d���l������Ŋz
            dr[MAKON02249EB.CT_StockConfSlipTtl_StckDisTtlTaxInclu] = stockConfSlipTtlWork.StckDisTtlTaxInclu;

            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX >>>>>>START
            //// TODO:���ł݈̂󎚗p�̍׍H
            //if (
            //    stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ParentPayment)
            //        ||
            //    stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ChildPayment)
            //        ||
            //    stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption)
            //)
            //{
            //    if (stockConfSlipTtlWork.StckPrcConsTaxInclu.Equals(0))
            //    {
            //        // [���חp]
            //        // �d�����z
            //        long stockTtlPricTaxExc = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF];
            //        long stockPriceConsTax  = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        // �����
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 0;

            //        // [���v�t�b�^�[�p]
            //        // �d��
            //        stockTtlPricTaxExc  = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF];
            //        stockPriceConsTax   = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 0;

            //        // 2009.01.09 30413 ���� �ԕi�ƒl���𕪂��Ĉ� >>>>>>START
            //        //// �ԕi�l��
            //        //stockTtlPricTaxExc  = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF];
            //        //stockPriceConsTax   = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF];
            //        //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;

            //        // �ԕi
            //        stockTtlPricTaxExc = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF];
            //        stockPriceConsTax = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = 0;

            //        // �l��
            //        stockTtlPricTaxExc = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF];
            //        stockPriceConsTax = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;
            //        // 2009.01.09 30413 ���� �ԕi�ƒl���𕪂��Ĉ� <<<<<<END
            //    }
            //}
            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX <<<<<<END
            // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<
		}

        /// <summary>
        /// �N�����[�h���f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="retList">�f�[�^�擾�����X�g</param>
        /// <param name="setCnt">���X�g�̃f�[�^�擾Index</param>
		/// <param name="stockConfListCndtn">�������o�N���X</param>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
		private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt, ExtrInfo_MAKON02247E stockConfListCndtn)
        {
            // ���גP��
            StockConfWork stockConfWork = (StockConfWork)retList[setCnt];
            // ���_�R�[�h
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
            //dr[MAKON02249EA.CT_StockConf_SectionCodeRF] = stockConfWork.SectionCode;
            dr[MAKON02249EA.CT_StockConf_SectionCodeRF] = stockConfWork.StockSectionCd;
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            // ���_�K�C�h����
            dr[MAKON02249EA.CT_StockConf_SectionGuideNmRF] = stockConfWork.SectionGuideSnm;    

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �d����R�[�h
            dr[MAKON02249EA.CT_StockConf_SupplierCd] = stockConfWork.SupplierCd;
            // �d���旪��
            dr[MAKON02249EA.CT_StockConf_SupplierSnm] = stockConfWork.SupplierSnm;  
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // �d�����t
            dr[MAKON02249EA.CT_StockConf_StockDateRF] = stockConfWork.StockDate;
            // �o�ד��t
            dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF] = 
                                      TDateTime.LongDateToDateTime(stockConfWork.ArrivalGoodsDay);
            // ���͓��t
			dr[MAKON02249EA.CT_StockConf_InputDayRF] = 
                                      TDateTime.LongDateToDateTime(stockConfWork.InputDay);
            // �d���v����t
			dr[MAKON02249EA.CT_StockConf_StockAddUpADateRF] = stockConfWork.StockAddUpADate;
            // �d�����t(����p)
            dr[MAKON02249EA.CT_StockConf_StockDateStringRF] = GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayStringRF] = GetDateTimeString(stockConfWork.ArrivalGoodsDay, ct_DateFormat);    // �o�ד��t(����p)     (DateTime)
			//dr[MAKON02249EA.CT_StockConf_InputDayStringRF]        = GetDateTimeString(stockConfWork.InputDay, ct_DateFormat);			// ���͓��t(����p)     (DateTime)
            // --- DEL 2008/07/16 --------------------------------<<<<< 
            
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �o�ד��t(����p)
            dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayStringRF] = GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.ArrivalGoodsDay), ct_DateFormat);
            // ���͓��t(����p)
            dr[MAKON02249EA.CT_StockConf_InputDayStringRF] = GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat);
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // �d���v����t(����p)
            dr[MAKON02249EA.CT_StockConf_StockAddUpADateStringRF] = GetDateTimeString(stockConfWork.StockAddUpADate, ct_DateFormat);

			//�w�b�_�[��DataField�ݒ�
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_groupHeader1DataField] = stockConfWork.SectionCode
            //                                                    + stockConfWork.CustomerCode.ToString("d9");
            // --- DEL 2008/07/16 --------------------------------<<<<< 
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
            //dr[MAKON02249EA.CT_StockConf_groupHeader1DataField] = stockConfWork.SectionCode
            dr[MAKON02249EA.CT_StockConf_groupHeader1DataField] = stockConfWork.StockSectionCd
                                                                  + stockConfWork.SupplierCd.ToString("d6");
            // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			// TODO:�d���恨�`�[���t���`�[�ԍ����d����SEQ�ԍ�
			if (stockConfListCndtn.SortOrder == 1)
			{
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat)
                //                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                                + stockConfWork.SupplierCd.ToString("d6")
                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat)
                                                                + stockConfWork.PartySaleSlipNum.PadLeft(9, '0')
                                                                + stockConfWork.SupplierSlipNo.ToString("d9"); // ADD 2008/12/01
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
                // --- ADD 2008/07/16 --------------------------------<<<<< 
			}
            // �d���恨���͓��t���`�[�ԍ����d����SEQ�ԍ�
			else if (stockConfListCndtn.SortOrder == 3)
			{
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.InputDay, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.InputDay, ct_DateFormat)
                //                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                                    + stockConfWork.SupplierCd.ToString("d6")
                                                    + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat)
                                                                + stockConfWork.PartySaleSlipNum.PadLeft(9, '0')
                                                                + stockConfWork.SupplierSlipNo.ToString("d9"); // ADD 2008/12/01
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }
			// �d���恨�`�[�ԍ�
            else if (stockConfListCndtn.SortOrder == 4)
			{
				dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                // --- DEL 2008/07/16 -------------------------------->>>>>
                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + stockConfWork.PartySaleSlipNum.PadLeft(9, '0')
                                                                + stockConfWork.SupplierSlipNo.ToString("d9"); // ADD 2008/12/01
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �d���恨�d�����t���d��SEQ�ԍ�
            else if (stockConfListCndtn.SortOrder == 5)
            {
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                + stockConfWork.SupplierCd.ToString("d6")
                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat)
                                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            }
            // �d���恨���͓��t���d��SEQ�ԍ�
            else if (stockConfListCndtn.SortOrder == 6)
            {
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                    + stockConfWork.SupplierCd.ToString("d6")
                                    + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat)
                                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            }
            // �d���恨�d��SEQ�ԍ�
            else
            {
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                + stockConfWork.SupplierCd.ToString("d6")
                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // 2009.02.25 30413 ���� ���_�R�[�h�̕ύX <<<<<<END
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            //�d���`�[���l1
			dr[MAKON02249EA.CT_StockConf_SupplierSlipNote1RF] = stockConfWork.SupplierSlipNote1;
            //�d���`�[���l2
			dr[MAKON02249EA.CT_StockConf_SupplierSlipNote2RF] = stockConfWork.SupplierSlipNote2;
            // �����`�[�ԍ�
			dr[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF] = stockConfWork.PartySaleSlipNum;

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = stockConfWork.CustomerCode;            // ���Ӑ�R�[�h       (Int32)

            //dr[MAKON02249EA.CT_StockConf_CustomerSnmRF] = stockConfWork.CustomerSnm;		        // ���Ӑ旪����         (string)
            //dr[MAKON02249EA.CT_StockConf_CustomerNameRF] = stockConfWork.CustomerSnm;             // ���Ӑ於��1        (string)
            //dr[MAKON02249EA.CT_StockConf_CustomerName2RF] = stockConfWork.CustomerSnm;            // ���Ӑ於��2        (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

			//dr[MAKON02249EA.CT_StockConf_UnitNameRF] = stockConfWork.UnitName;        // �P�ʖ���  // DEL 2008/07/16

            // �ύX�O�艿
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = stockConfWork.BfListPrice;
            if (stockConfWork.BfListPrice == 0)
            {
                dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = DBNull.Value;
            }
            else
            {
                // 2009.02.16 30413 ���� �ύX�O�艿�̈󎚐�����C�� >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = stockConfWork.BfListPrice;
                if (stockConfWork.BfListPrice == stockConfWork.ListPriceTaxExcFl)
                {
                    // �ύX�O�艿�ƒ艿�������ꍇ�́A�ύX�O�艿�͈󎚂��Ȃ�
                    dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = DBNull.Value;
                }
                else
                {
                    // ��L�ȊO�͈󎚂���
                    dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = stockConfWork.BfListPrice;
                }
                // 2009.02.16 30413 ���� �ύX�O�艿�̈󎚐�����C�� <<<<<<END
            }

            // �艿
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_ListPriceFlRF] = stockConfWork.ListPriceTaxExcFl;
            if (stockConfWork.ListPriceTaxExcFl == 0)
            {
                dr[MAKON02249EA.CT_StockConf_ListPriceFlRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_ListPriceFlRF] = stockConfWork.ListPriceTaxExcFl;
            }

            // �d���`�[�敪��
            dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = this.GetSupplierSlipNm(stockConfWork.SupplierSlipCd);

			//dr[MAKON02249EA.CT_StockConf_OrderNumberRF] = stockConfWork.OrderFormNo;        // �������ԍ�  // DEL 2008/07/16

            //���Е��ރR�[�h
			dr[MAKON02249EA.CT_StockConf_EnterpriseGanreCodeRF] = stockConfWork.EnterpriseGanreCode;
            //���Е��ޖ���
			dr[MAKON02249EA.CT_StockConf_EnterpriseGanreNameRF] = stockConfWork.EnterpriseGanreName;
            // ���[�J�[�R�[�h
            // 2008.01.05 Modify [9490]
			//dr[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = stockConfWork.GoodsMakerCd;
            if (stockConfWork.GoodsMakerCd == 0)
            {
                dr[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = stockConfWork.GoodsMakerCd;
            }
            // ���i����
            dr[MAKON02249EA.CT_StockConf_GoodsNameRF] = stockConfWork.GoodsName;
            // ���i�R�[�h
			dr[MAKON02249EA.CT_StockConf_GoodsCodeRF] = stockConfWork.GoodsNo;
            // �q�ɃR�[�h
			dr[MAKON02249EA.CT_StockConf_WarehouseCodeRF] = stockConfWork.WarehouseCode;
            // �ݎ�敪��
            // 2009.02.16 30413 ���� ���i�l���̏ꍇ�A�ݎ�敪������ >>>>>>START
            // 2008.01.05 Modify [9490]
            // �d���`�[�敪�i���ׁj=2�i�l���j�̎��͕\�����Ȃ�
            //if (stockConfWork.StockSlipCdDtl == 2)
            if ((string.IsNullOrEmpty(stockConfWork.GoodsNo)) && (stockConfWork.StockSlipCdDtl == 2))
            {
                // �s�l���݈̂󎚂��Ȃ�
                dr[MAKON02249EA.CT_StockConf_StockOrderDivNmRF] = string.Empty;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_StockOrderDivNmRF] = GetStockOrderDivNm(stockConfWork.StockOrderDivCd);
            }
            // 2009.02.16 30413 ���� ���i�l���̏ꍇ�A�ݎ�敪������ <<<<<<END
            
            // BL�R�[�h
            // 2008.01.05 Modify [9490]
			//dr[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = stockConfWork.BLGoodsCode;
            if (stockConfWork.BLGoodsCode == 0)
            {
                dr[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = stockConfWork.BLGoodsCode;
            }

            // �d���`�[�ԍ�
			dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF] = stockConfWork.SupplierSlipNo;
            // �d���s�ԍ�
            dr[MAKON02249EA.CT_StockConf_StockRowNoRF] = stockConfWork.StockRowNo;
            // �ԓ`�敪
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivRF] = stockConfWork.DebitNoteDiv;
            // �ԓ`�敪��
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF] = this.GetDebitNoteDivNm(stockConfWork.DebitNoteDiv);
            // ���|�敪
            dr[MAKON02249EA.CT_StockConf_AccPayDivCdRF] = stockConfWork.AccPayDivCd;
            // ���|�敪��
            dr[MAKON02249EA.CT_StockConf_AccPayDivNmRF] = this.GetAccRecDivNm(stockConfWork.AccPayDivCd);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreCodeRF]  = stockConfWork.LargeGoodsGanreCode;  // ���i�啪�ރR�[�h   (Int32)
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreNameRF]  = stockConfWork.LargeGoodsGanreName;  // ���i�啪�ޖ���     (string)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreCodeRF] = stockConfWork.MediumGoodsGanreCode; // ���i�����ރR�[�h   (Int32)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreNameRF] = stockConfWork.MediumGoodsGanreName; // ���i�����ޖ���     (string)
            //dr[MAKON02249EA.CT_StockConf_DetailGoodsGanreCodeRF] = stockConfWork.DetailGoodsGanreCode; // ���i�ڍ׃R�[�h   (Int32)
            //dr[MAKON02249EA.CT_StockConf_DetailGoodsGanreNameRF] = stockConfWork.DetailGoodsGanreName; // ���i�ڍז���     (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // �d���S���҃R�[�h
			dr[MAKON02249EA.CT_StockConf_StockAgentCodeRF] = stockConfWork.StockAgentCode;
            // �d���S���Җ���
            dr[MAKON02249EA.CT_StockConf_StockAgentNameRF] = stockConfWork.StockAgentName;
            // �d���`�[�敪
            dr[MAKON02249EA.CT_StockConf_SupplierSlipCdRF] = stockConfWork.SupplierSlipCd;
            // �d���`�[�敪��
            dr[MAKON02249EA.CT_StockConf_SupplierSlipNmRF] = this.GetSupplierSlipNm(stockConfWork.SupplierSlipCd);
            // �擪�o�͖��׃t���O
            dr[MAKON02249EA.CT_StockConf_FirstRowFlg] = 9;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �ύX�O�d���P�� 
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = stockConfWork.BfStockUnitPriceFl;
            if (stockConfWork.BfStockUnitPriceFl == 0)
            {
                dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = DBNull.Value;
            }
            else
            {
                // 2009.02.16 30413 ���� �ύX�O�d���P���̈󎚐�����C�� >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = stockConfWork.BfStockUnitPriceFl;
                if (stockConfWork.BfStockUnitPriceFl == stockConfWork.StockUnitPriceFl)
                {
                    // �ύX�O�d���P���Ǝd���P���������ꍇ�́A�ύX�O�艿�͈󎚂��Ȃ�
                    dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = DBNull.Value;
                }
                else
                {
                    // ��L�ȊO�̏ꍇ�͈󎚂���
                    dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = stockConfWork.BfStockUnitPriceFl;
                }
                // 2009.02.16 30413 ���� �ύX�O�d���P���̈󎚐�����C�� <<<<<<END
            }
            // ���[�J�[����
            dr[MAKON02249EA.CT_StockConf_MakerNameRF] = stockConfWork.MakerName;
            // �q�ɖ���
            dr[MAKON02249EA.CT_StockConf_WarehouseNameRF] = stockConfWork.WarehouseName;
            // ����`�[�ԍ�
            dr[MAKON02249EA.CT_StockConf_SalesSlipNum] = stockConfWork.SalesSlipNum;
            // �d���`�[���ה��l1
            dr[MAKON02249EA.CT_StockConf_StockDtiSlipNote1RF] = stockConfWork.StockDtiSlipNote1;
            // ���Ӑ�R�[�h
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = stockConfWork.CustomerCode;
            if (stockConfWork.CustomerCode == 0)
            {
                dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = stockConfWork.CustomerCode;
            }
            // �t�n�d���}�[�N�P
            dr[MAKON02249EA.CT_StockConf_UoeRemark1] = stockConfWork.UoeRemark1;
            // �t�n�d���}�[�N�Q
            dr[MAKON02249EA.CT_StockConf_UoeRemark2] = stockConfWork.UoeRemark2;
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // �d����
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_StockCountRF] = stockConfWork.StockCount;
            if (stockConfWork.StockCount == 0)
            {
                dr[MAKON02249EA.CT_StockConf_StockCountRF] = DBNull.Value;
            }
            else
            {
                // 2009.02.16 30413 �d�����i�敪�Ő��ʂ̈󎚐����ǉ� >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_StockCountRF] = stockConfWork.StockCount;
                if (stockConfWork.StockGoodsCd == 0)
                {
                    // �d�����i�敪��"0:���i"�̏ꍇ
                    dr[MAKON02249EA.CT_StockConf_StockCountRF] = stockConfWork.StockCount;
                }
                else
                {
                    // �d�����i�敪��"0:���i"�ȊO�̏ꍇ(���݂�"6:���v"�̂�)
                    dr[MAKON02249EA.CT_StockConf_StockCountRF] = DBNull.Value;
                }
                // 2009.02.16 30413 �d�����i�敪�Ő��ʂ̈󎚐����ǉ� <<<<<<END
            }
            // �d���P��
            // 2008.01.05 Modify [9490]
			//dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = stockConfWork.StockUnitPriceFl;
            if (stockConfWork.StockUnitPriceFl == 0)
            {
                dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = stockConfWork.StockUnitPriceFl;
            }

			//dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;     // �d�����z           (Int64)
			//dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc;	//�����

            // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� >>>>>>START
            // 2008.01.05 Modify [9490]
            //Int64 stockPrice = 0;
            //Int64 stockPriceTax = 0;
            
            // 2009.01.29 30413 ���� �d�����i�敪�ɂ��ݒ���폜 >>>>>>START
            //if ((stockConfWork.StockGoodsCd == 2) || (stockConfWork.StockGoodsCd == 4))
            //{
            //    // �d�����z
            //    //dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = 0;
            //    dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            //    // �����
            //    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //    if (stockConfWork.StockPriceConsTax == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //        stockPriceTax = Int64.Parse(stockConfWork.StockPriceConsTax.ToString());
            //    }
            //}
            //else if ((stockConfWork.StockGoodsCd == 3) || (stockConfWork.StockGoodsCd == 5))
            //{
            //    // �d�����z
            //    //dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxInc;
            //    if (stockConfWork.StockPriceTaxInc == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] =DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxInc;
            //        stockPrice = Int64.Parse(stockConfWork.StockPriceTaxInc.ToString());
            //    }
            //    // �����
            //    //dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;
            //    dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //}
            //else
            //{
            //    // �d�����z
            //    //dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    if (stockConfWork.StockPriceTaxExc == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //        stockPrice = Int64.Parse(stockConfWork.StockPriceTaxExc.ToString());
            //    }
            //    //�����
            //    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //    if (stockConfWork.StockPriceConsTax == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //        stockPriceTax = Int64.Parse(stockConfWork.StockPriceConsTax.ToString());
            //    }
            //}
            //// �d�����z
            //if (stockConfWork.StockPriceTaxExc == 0)
            //{
            //    dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            //}
            //else
            //{
            //    dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    stockPrice = stockConfWork.StockPriceTaxExc;
            //}
            ////�����
            //if (stockConfWork.StockPriceConsTax == 0)
            //{
            //    dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //}
            //else
            //{
            //    dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //    stockPriceTax = Int64.Parse(stockConfWork.StockPriceConsTax.ToString());
            //}
            // 2009.01.29 30413 ���� �d�����i�敪�ɂ��ݒ���폜 <<<<<<END

            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX >>>>>>START
            //// ���ł݈̂󎚗p�̍׍H
            //if (IsPrintingTaxIncludedOnlyPattern(stockConfWork))
            //{
            //    if (!stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxIncluded))
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;    // ���łłȂ���� \0
            //    }
            //}
            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX <<<<<<END
            
            //dr[MAKON02249EA.CT_StockConf_StockPriceTaxIncRF] = Int64.Parse(dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) 
            //                                                        + Int64.Parse(dr[MAKON02249EA.CT_StockConf_TaxRF].ToString());
            //dr[MAKON02249EA.CT_StockConf_StockPriceTaxIncRF] = stockPrice + stockPriceTax;
            // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� <<<<<<END
            
#if False
			if ((stockConfWork.StockRowNo == 1))
				||
				(stockConfWork.StockTelNo1 != "") ||
                (stockConfWork.StockTelNo2 != "") ||
                (stockConfWork.ProductNumber1 != "") ||
                (stockConfWork.ProductNumber2 != ""))
			{
#endif

            // �擪�o�͖��׃t���O
            dr[MAKON02249EA.CT_StockConf_FirstRowFlg] = 1;
            // �d���ڍהԍ�
			dr[MAKON02249EA.CT_StockConf_StockRowNoRF] = stockConfWork.StockRowNo;
            // �d���ڍהԍ�
            dr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;

            // 2009.01.09 30413 ���� �d���`�[�敪(����)�Ŕ��f����悤�ɏC�� >>>>>>START
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �`�[�L�[
            string slipKey = (string)dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField];    // ADD 2008/10/15 �s��Ή�[5651]
            //10:�d��
            //if (stockConfWork.SupplierSlipCd == 10)
            //{
            //    // �`�[����(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
            //    // �`�[����(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
            //    // �`�[����(���v)
            //    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

            //    // ADD 2008/10/15 �s��Ή�[5651]---------->>>>>
            //    // ���ɐ������`�[�͐����Ȃ�
            //    if (CountedSlipKeyList.Contains(slipKey))
            //    {
            //        // �`�[����(�d��)
            //        dr[MAKON02249EA.CT_StockConf_SalCntRF]  = 0;
            //        // �`�[����(�ԕi�l��)
            //        dr[MAKON02249EA.CT_StockConf_DisCntRF]  = 0;
            //        // �`�[����(���v)
            //        dr[MAKON02249EA.CT_StockConf_TotleCntRF]= 0;
            //    }
            //    else
            //    {
            //        CountedSlipKeyList.Add(slipKey);
            //    }
            //    // ADD 2008/10/15 �s��Ή�[5651]----------<<<<<

            //    // �d�����z(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    // �����(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
            //    // ���v���z(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = stockConfWork.StockPriceTaxExc
            //                                                        + stockConfWork.StockPriceConsTax;

            //    // �d�����z(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = 0;
            //    // �����(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = 0;
            //    // ���v���z(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = 0;
            //}
            ////20:�ԕi
            //else
            //{
            //    // �`�[����(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 0;     // TODO:
            //    // �`�[����(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;     // TODO:
            //    // �`�[����(���v)
            //    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;   // TODO:

            //    // ADD 2008/10/15 �s��Ή�[5651]---------->>>>>
            //    // ���ɐ������`�[�͐����Ȃ�
            //    if (CountedSlipKeyList.Contains(slipKey))
            //    {
            //        // �`�[����(�d��)
            //        dr[MAKON02249EA.CT_StockConf_SalCntRF]  = 0;
            //        // �`�[����(�ԕi�l��)
            //        dr[MAKON02249EA.CT_StockConf_DisCntRF]  = 0;
            //        // �`�[����(���v)
            //        dr[MAKON02249EA.CT_StockConf_TotleCntRF]= 0;
            //    }
            //    else
            //    {
            //        CountedSlipKeyList.Add(slipKey);
            //    }
            //    // ADD 2008/10/15 �s��Ή�[5651]----------<<<<<

            //    // �d�����z(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = 0;
            //    // �����(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = 0;
            //    // ���v���z(�d��)
            //    dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = 0;

            //    // �d�����z(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    // �����(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
            //    // ���v���z(�ԕi�l��)
            //    dr[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = stockConfWork.StockPriceTaxExc
            //                                                        + stockConfWork.StockPriceConsTax;
            //}
            // --- ADD 2008/07/16 --------------------------------<<<<<

            // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� >>>>>>START
            // �d�����z
            if (stockConfWork.StockPriceTaxExc == 0)
            {
                dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            }
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // ����Őŗ�
            string sConTaxRate = string.Empty;
            // �ŕʓ���󎚂̏ꍇ�A
            if (_iTaxPrintDiv == 0)
            {
                sConTaxRate = Convert.ToString(stockConfWork.SupplierConsTaxRate * 100) + "%";
                // �d��
                // Title_�ŗ�1
                dr[MAKON02249EA.CT_StockConf_TaxRate1_Title] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_�ŗ�2
                dr[MAKON02249EA.CT_StockConf_TaxRate2_Title] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_���̑�
                dr[MAKON02249EA.CT_StockConf_Other_Title] = "���̑�";

                // �ԕi
                // Title_�ŗ�1
                dr[MAKON02249EA.CT_StockConf_TaxRate1_RetTitle] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_�ŗ�2
                dr[MAKON02249EA.CT_StockConf_TaxRate2_RetTitle] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_���̑�
                dr[MAKON02249EA.CT_StockConf_Other_RetTitle] = "���̑�";

                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                // Title_��ې�
                dr[MAKON02249EA.CT_StockConf_TaxFree_Title] = "��ې�";
                // Title_��ې�
                dr[MAKON02249EA.CT_StockConf_TaxFree_RetTitle] = "��ې�";
                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                
            }
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            long salesDtlTax = 0;       // �d���^�ԕi�̏����
            long distDtlTax = 0;        // �l���̏����
            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            // ����œ]�ŕ���
            // if (IsPrintingTaxIncludedOnlyPattern(stockConfWork))
            if (IsPrintingTaxIncludedOnlyPattern(stockConfWork) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
            {
                // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                if (!stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxIncluded))
                {
                    dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;    // ���łłȂ���� \0
                    // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip) && !CountedTaxFreeSlipKeyList.Contains(slipKey) && !CountedSlipKeyList.Contains(slipKey))
                    {
                        dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTaxDen;
                    }
                    // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        //dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                        if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip) && !CountedTaxFreeSlipKeyList.Contains(slipKey) && !CountedSlipKeyList.Contains(slipKey))
                        {
                            dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate; 
                        }
                        else 
                        {
                            dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                        }
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                }
                else
                {
                    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                    dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                }
            }
            else
            {
                // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
                if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip))
                {
                    // ����œ]�ŕ����@0�F�`�[�P��
                    if (!CountedSlipKeyList.Contains(slipKey))
                    {
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        //// �����
                        //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTaxDen;
                        //// --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        //// �ŕʓ���󎚂̏ꍇ�A
                        //if (_iTaxPrintDiv == 0)
                        //{ 
                        //    dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                        //}
                        if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                        {
                            // �����
                            dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTaxDen;
                            // �ŕʓ���󎚂̏ꍇ�A
                            if (_iTaxPrintDiv == 0)
                            {
                                dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                            }
                        }
                        else {
                            dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;
                            // �ŕʓ���󎚂̏ꍇ�A
                            if (_iTaxPrintDiv == 0)
                            {
                                dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                            }
                        }
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

                        // DEL 2009/07/17 >>>
                        //// ���׃^�C�v�̏���ł��Z�o
                        //salesDtlTax = stockConfWork.StockPriceConsTaxDen - stockConfWork.StockDisOutTax - stockConfWork.StckDisTtlTaxInclu;
                        //distDtlTax = stockConfWork.StockDisOutTax + stockConfWork.StckDisTtlTaxInclu;
                        // DEL 2009/07/17 <<<
                    }
                    else
                    {
                        // ��L�ȊO
                        // �����
                        dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                        }
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }
                }
                else
                {
                    // ����œ]�ŕ����@1�F���גP��
                    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                    dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                }
            }
            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX <<<<<<END


            if (stockConfWork.StockSlipCdDtl == 0)
            {
                // 0:�d��
                /* ---DEL 2009/01/28 �s��Ή�[10599] ------------------------------------------->>>>>
                // �`�[����(�d��)
                dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                // �`�[����(���v)
                dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                // ���ɐ������`�[�͐����Ȃ�
                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    CountedSlipKeyList.Add(slipKey);
                }
                   ---DEL 2009/01/28 �s��Ή�[10599] -------------------------------------------<<<<< */
                // ---ADD 2009/01/28 �s��Ή�[10599] ------------------------------------------->>>>>
                // ���ɐ������`�[�͐����Ȃ�
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    // �`�[����(�d��)
                    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 0;
                    // �`�[����(���v)
                    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 0;
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey) &&
                        _iTaxPrintDiv == 0 &&
                        (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)))
                    {
                        dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                }
                else
                {
                    // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // �`�[����(�d��)
                    // dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                    // �`�[����(���v)
                    // dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                        // �`�[����(�d��)
                        dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                        // �`�[����(���v)
                        dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    }
                    // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                        // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                        if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                        {
                            // �d����_���̑�
                            //dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;
                            if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                            {
                                dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                                CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        else
                        {
                            // �ŗ��Q
                            if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                            {
                                // �d����_�ŗ��Q
                                dr[MAKON02249EA.CT_StockConf_TaxRate2_SalSlipCntRF] = 1;

                            }
                            else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                            {
                                // �d����_�ŗ��P
                                dr[MAKON02249EA.CT_StockConf_TaxRate1_SalSlipCntRF] = 1;
                            }
                            else
                            {
                                // �d����_���̑�
                                dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;

                            }
                        }
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    //CountedSlipKeyList.Add(slipKey);
                }
                // ---ADD 2009/01/28 �s��Ή�[10599] -------------------------------------------<<<<<
                
                // �d�����z(�d��)
                dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� >>>>>>START
                // 2009.01.29 30413 ���� ����ł̐ݒ���C�� >>>>>>START
                // �����(�d��)
                //dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
                //dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // �����(�d��)
                    dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = salesDtlTax;
                    // �����(�l��)
                    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                }
                else
                {
                    //dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];

                    // ADD 2009/07/17 >>>
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ByDetails)) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = stockConfWork.StockPriceConsTaxDen;
                    }
                    // ADD 2009/07/17 <<<

                }
                // 2009.01.29 30413 ���� ����ł̐ݒ���C�� <<<<<<END
                // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� <<<<<<END
                // ���v���z(�d��)
                dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = stockConfWork.StockPriceTaxExc
                //                                              + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                    // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                    {
                        // �d�����z�v�i�Ŕ����j_���̑�
                        //dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        dr[MAKON02249EA.CT_StockConf_TaxFree_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                    }
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    else
                    {
                        // �ŗ��Q
                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // �d�����z�v�i�Ŕ����j_�ŗ��Q
                            dr[MAKON02249EA.CT_StockConf_TaxRate2_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                        }
                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // �d�����z�v�i�Ŕ����j_�ŗ��P
                            dr[MAKON02249EA.CT_StockConf_TaxRate1_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        }
                        else
                        {
                            // �d�����z�v�i�Ŕ����j_���̑�
                            dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                        }
                    }
                }
                // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                // �ŕʓ���󎚂��Ȃ��̏ꍇ�A
                else
                {
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                       !CountedTaxFreeSlipKeyList.Contains(slipKey))
                    {
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                }
                // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            }
            else if (stockConfWork.StockSlipCdDtl == 1)
            {
                // 1:�ԕi
                /* ---DEL 2009/01/28 �s��Ή�[10599] ------------------------------------------->>>>>
                // �`�[����(�ԕi)
                dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                // �`�[����(���v)
                dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                // ���ɐ������`�[�͐����Ȃ�
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    CountedSlipKeyList.Add(slipKey);
                }
                   ---DEL 2009/01/28 �s��Ή�[10599] -------------------------------------------<<<<< */
                // ---ADD 2009/01/28 �s��Ή�[10599] ------------------------------------------->>>>>
                // ���ɐ������`�[�͐����Ȃ�
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    // �`�[����(�ԕi)
                    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
                    // �`�[����(���v)
                    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 0;
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey) &&
                        _iTaxPrintDiv == 0 &&
                        (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)))
                    {
                        dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                }
                else
                {
                    // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // �`�[����(�ԕi)
                    // dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                    // �`�[����(���v)
                    // dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                        // �`�[����(�ԕi)
                        dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                        // �`�[����(���v)
                        dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    }
                    // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                        // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                        if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                        {
                            // �d������(�ԕi�l��)_���̑�
                            //dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;
                            if (!CountedTaxFreeSlipKeyList.Contains(slipKey)){
                                // �d������(�ԕi�l��)_��ې�
                                dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                                CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        else
                        {
                            // �ŗ��Q
                            if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                            {
                                // �`�[����(�ԕi�l��)_�ŗ��Q
                                dr[MAKON02249EA.CT_StockConf_TaxRate2_DisSlipCntRF] = 1;

                            }
                            // �ŗ��P
                            else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                            {
                                // �`�[����(�ԕi�l��)_�ŗ��P
                                dr[MAKON02249EA.CT_StockConf_TaxRate1_DisSlipCntRF] = 1;
                            }
                            else
                            {
                                // �d����_���̑�
                                dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;

                            }
                        }
                    }
                    // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // �ŕʓ���󎚂��Ȃ��̏ꍇ�A
                    else
                    {
                        if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                           !CountedTaxFreeSlipKeyList.Contains(slipKey))
                        {
                            CountedTaxFreeSlipKeyList.Add(slipKey);
                        }
                    }
                    // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<

                    //CountedSlipKeyList.Add(slipKey);
                }
                // ---ADD 2009/01/28 �s��Ή�[10599] -------------------------------------------<<<<<

                // �d�����z(�ԕi)
                dr[MAKON02249EA.CT_StockConf_RetGdsStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� >>>>>>START
                // 2009.01.29 30413 ���� ����ł̐ݒ���C�� >>>>>>START
                // �����(�ԕi)
                //dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
                //dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // �����(�ԕi)
                    dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = salesDtlTax;
                    // �����(�l��)
                    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                }
                else
                {                    
                    dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                    // ADD 2009/07/17 
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ByDetails)) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = stockConfWork.StockPriceConsTaxDen;
                    }

                }
                // 2009.01.29 30413 ���� ����ł̐ݒ���C�� <<<<<<END
                // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� <<<<<<END
                // ���v���z(�ԕi)
                dr[MAKON02249EA.CT_StockConf_RetGdsTotalPriceRF] = stockConfWork.StockPriceTaxExc
                //                                                 + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                   + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                    // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                    {
                        // �d�����z(�ԕi)_���̑�
                        // dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        // �d�����z(�ԕi)_��ې�
                        dr[MAKON02249EA.CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                    }
                    // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    else
                    {
                        // �ŗ��Q
                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // �d�����z(�ԕi)_�ŗ��Q
                            dr[MAKON02249EA.CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                        }
                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // �d�����z(�ԕi)_�ŗ��P
                            dr[MAKON02249EA.CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        }
                        else
                        {
                            // �d�����z(�ԕi)_���̑�
                            dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        }
                    }
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            }
            else
            {
                // 2:�l��
                // 2009.02.03 30413 ���� �l�����`�[�������J�E���g >>>>>>START
                // ���ɐ������`�[�͐����Ȃ�
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    // �`�[����(�d��)
                    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 0;
                    // �`�[����(�ԕi)
                    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
                    // �`�[����(���v)
                    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 0;
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey) &&
                        _iTaxPrintDiv == 0 &&
                        (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)))
                    {
                        if (stockConfWork.SupplierSlipCd == 10)
                        {
                            dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                        }
                        else if (stockConfWork.SupplierSlipCd == 20)
                        {
                            dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                        }
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                }
                else
                {
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                    {
                        // �`�[����(���v)
                        dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    }
                    // ----- ADD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                    if (stockConfWork.SupplierSlipCd == 10)
                    {
                        // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // �`�[����(�d��)
                        // dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                        if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                            dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                        }
                        // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                            // ����œ]�ŕ��� 9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                            // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // �d����_���̑�
                                // dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;
                                if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                                {
                                    // �d����_��ې�
                                    dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                                    CountedTaxFreeSlipKeyList.Add(slipKey);
                                    if (stockConfWork.TaxRateExistFlag)
                                    {
                                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                        {
                                            // �d����_�ŗ��Q
                                            dr[MAKON02249EA.CT_StockConf_TaxRate2_SalSlipCntRF] = 1;

                                        }
                                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                        {
                                            // �d����_�ŗ��P
                                            dr[MAKON02249EA.CT_StockConf_TaxRate1_SalSlipCntRF] = 1;
                                        }
                                        else
                                        {
                                            // �d����_���̑�
                                            dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;
                                        }
                                    }
                                }
                            }
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                            else
                            {
                                // �ŗ��Q
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // �d����_�ŗ��Q
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_SalSlipCntRF] = 1;

                                }
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // �d����_�ŗ��P
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_SalSlipCntRF] = 1;
                                }
                                else
                                {
                                    // �d����_���̑�
                                    dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;

                                }
                            }
                        }
                        // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // �ŕʓ���󎚂��Ȃ��̏ꍇ�A
                        else {
                            if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                               !CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                                   CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }
                    else if (stockConfWork.SupplierSlipCd == 20)
                    {
                        
                        // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // �`�[����(�ԕi)
                        // dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                        if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                        {
                            // �`�[����(�ԕi)
                            dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                        }
                        // ----- UPD 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                            // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                            //if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // �d������(�ԕi�l��)_���̑�
                                // dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;
                                if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                                    // �d������(�ԕi�l��)_��ې�
                                    dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                                    CountedTaxFreeSlipKeyList.Add(slipKey);
                                    if (stockConfWork.TaxRateExistFlag) {
                                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                        {
                                            // �`�[����(�ԕi�l��)_�ŗ��Q
                                            dr[MAKON02249EA.CT_StockConf_TaxRate2_DisSlipCntRF] = 1;
                                        }
                                        // �ŗ��P
                                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                        {
                                            // �`�[����(�ԕi�l��)_�ŗ��P
                                            dr[MAKON02249EA.CT_StockConf_TaxRate1_DisSlipCntRF] = 1;
                                        }
                                        else
                                        {
                                            // �d����_���̑�
                                            dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;
                                        }
                                    }
                                }
                            }
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                            else
                            {
                                // �ŗ��Q
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // �`�[����(�ԕi�l��)_�ŗ��Q
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_DisSlipCntRF] = 1;

                                }
                                // �ŗ��P
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // �`�[����(�ԕi�l��)_�ŗ��P
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_DisSlipCntRF] = 1;
                                }
                                else
                                {
                                    // �d����_���̑�
                                    dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;

                                }
                            }
                        }
                        // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                        // �ŕʓ���󎚂��Ȃ��̏ꍇ�A
                        else
                        {
                            if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                               !CountedTaxFreeSlipKeyList.Contains(slipKey))
                            {
                                CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- ADD 2022/10/9 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }

                    // �`�[����(���v)
                    // dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1; DEL 2022/10/08 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    //CountedSlipKeyList.Add(slipKey);
                }
                // 2009.02.03 30413 ���� �l�����`�[�������J�E���g <<<<<<END

                // 2009.03.16 30413 ���� �s�l�����̈�����ύX >>>>>>START
                // �s�l�����͎d���^�ԕi�Ƃ��Ĉ���
                if (stockConfWork.StockCount == 0.0)
                {
                    if (stockConfWork.SupplierSlipCd == 10)
                    {
                        // �d���Ɍv��
                        // �d�����z(�d��)
                        dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        // �����(�d��)
                        if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // �����(�d��)
                            dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = salesDtlTax;
                            // �����(�l��)
                            dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                        }
                        else
                        {
                            dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                        }
                        // ���v���z(�d��)
                        dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = stockConfWork.StockPriceTaxExc
                        //                                                 + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                           + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                            // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                            // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // �d�����z�v�i�Ŕ����j_���̑�
                                // dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                // �d�����z�v�i�Ŕ����j_��ې�
                                dr[MAKON02249EA.CT_StockConf_TaxFree_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                            }
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                            else
                            {
                                // �ŗ��Q
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // �d�����z�v�i�Ŕ����j_�ŗ��Q
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // �d�����z�v�i�Ŕ����j_�ŗ��P
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                }
                                else
                                {
                                    // �d�����z�v�i�Ŕ����j_���̑�
                                    dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                            }
                        }
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }
                    else if (stockConfWork.SupplierSlipCd == 20)
                    {
                        // �d�����z(�ԕi)
                        dr[MAKON02249EA.CT_StockConf_RetGdsStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        // �����(�ԕi)
                        if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // �����(�ԕi)
                            dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = salesDtlTax;
                            // �����(�l��)
                            dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                        }
                        else
                        {
                            dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                        }
                        // ���v���z(�ԕi)
                        dr[MAKON02249EA.CT_StockConf_RetGdsTotalPriceRF] = stockConfWork.StockPriceTaxExc
                        //                                                 + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                           + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                            // ����œ]�ŕ����@9�F��ې� ����Őŗ�(�ŗ��Q,�ŗ��P�ȊO)
                            // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // �d�����z(�ԕi)_���̑�
                                // dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                // �d�����z(�ԕi)_��ې�
                                dr[MAKON02249EA.CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                            }
                            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
                            else
                            {
                                // �ŗ��Q
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // �d�����z(�ԕi)_�ŗ��Q
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // �d�����z(�ԕi)_�ŗ��P
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                }
                                else
                                {
                                    // �d�����z(�ԕi)_���̑�
                                    dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                            }
                        }
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }
                }
                else
                {
                    // �d�����z(�l��)
                    dr[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                    // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� >>>>>>START
                    // 2009.01.29 30413 ���� ����ł̐ݒ���C�� >>>>>>START
                    // �����(�l��)
                    //dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
                    //dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                        dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                        if (stockConfWork.SupplierSlipCd == 10)
                        {
                            // �d��
                            dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = salesDtlTax;
                        }
                        else if (stockConfWork.SupplierSlipCd == 20)
                        {
                            // �ԕi
                            dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = salesDtlTax;
                        }
                    }
                    else
                    {
                        // ��L�ȊO
                        dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                    }
                    // 2009.01.29 30413 ���� ����ł̐ݒ���C�� <<<<<<END
                    // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� <<<<<<END
                    // ���v���z(�l��)
                    dr[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = stockConfWork.StockPriceTaxExc
                    //                                            + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                  + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                }
                // 2009.03.16 30413 ���� �s�l�����̈�����ύX <<<<<<END
            }
            // 2009.01.09 30413 ���� �d���`�[�敪(����)�Ŕ��f����悤�ɏC�� <<<<<<END

            // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� >>>>>>START
            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            // if (!CountedSlipKeyList.Contains(slipKey))
            if (!CountedSlipKeyList.Contains(slipKey) && 
                !stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) && 
                !stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
            // ----- UPD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<<
            {
                CountedSlipKeyList.Add(slipKey);
            }
            // 2009.02.06 30413 ���� ����œ]�ŕ����̑Ή��C�� <<<<<<END
                        
            // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
            // �d���摍�z�\�����@�敪
            dr[MAKON02249EA.CT_StockConf_SuppTtlAmntDspWayCd] = stockConfWork.SuppTtlAmntDspWayCd;

            // �d�������œ]�ŕ����R�[�h
            dr[MAKON02249EA.CT_StockConf_SuppCTaxLayCd] = stockConfWork.SuppCTaxLayCd;

            // �ېŋ敪
            dr[MAKON02249EA.CT_StockConf_TaxationCode] = stockConfWork.TaxationCode;

            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX >>>>>>START
            //// TODO:���ł݈̂󎚗p�̍׍H
            //if (IsPrintingTaxIncludedOnlyPattern(stockConfWork))
            //{
            //    if (!stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxIncluded))
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;    // ���łłȂ���� \0
            //    }
            //}
            // 2009.01.29 30413 ���� ���Ń`�F�b�N�̏����ʒu��ύX <<<<<<END
            // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<
        }

        // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
        /// <summary>
        /// ���ł݈̂󎚂���p�^�[�������肵�܂��B
        /// </summary>
        /// <remarks>
        /// ���ł݈̂󎚂���p�^�[���F�]�ŕ��� = �����e(�x���e) || �����q(�x���q) || ��ې�
        /// </remarks>
        /// <param name="stockConfWork">�d���f�[�^�i���׃^�C�v�j</param>
        /// <returns>
        /// <c>true</c> :���ł݈̂󎚂���p�^�[���ł���B<br/>
        /// <c>false</c>:���ł݈̂󎚂���p�^�[���ł͂Ȃ��B
        /// </returns>
        private static bool IsPrintingTaxIncludedOnlyPattern(StockConfWork stockConfWork)
        {
            if (
                stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ParentPayment)
                    ||
                stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ChildPayment)
                    ||
                stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption)
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<

		/// <summary>
		/// ���t��������擾���܂��B
		/// </summary>
		/// <param name="date">���t</param>
		/// <param name="format">�t�H�[�}�b�g������</param>
		/// <returns>���t������</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}

        /// <summary>
        /// �N�����[�h���f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="sourceDataRow">�Z�b�g��DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            // �S���ҕ�
            dr[MAKON02249EA.CT_StockConf_SectionCodeRF]          = sourceDataRow[MAKON02249EA.CT_StockConf_SectionCodeRF];          // ���_�R�[�h         (string)
            dr[MAKON02249EA.CT_StockConf_SectionGuideNmRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SectionGuideNmRF];       // ���_�K�C�h����     (string)
            dr[MAKON02249EA.CT_StockConf_StockDateRF]            = sourceDataRow[MAKON02249EA.CT_StockConf_StockDateRF];            // �d�����t           (Int32)
            dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF]      = sourceDataRow[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF];      // �o�ד��t           (Int32)
			dr[MAKON02249EA.CT_StockConf_InputDayRF]             = sourceDataRow[MAKON02249EA.CT_StockConf_InputDayRF];             // ���͓��t           (Int32)

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_CustomerCodeRF]         = sourceDataRow[MAKON02249EA.CT_StockConf_CustomerCodeRF];         // ���Ӑ�R�[�h       (Int32)
            //dr[MAKON02249EA.CT_StockConf_CustomerNameRF]         = sourceDataRow[MAKON02249EA.CT_StockConf_CustomerNameRF];         // ���Ӑ於��         (string)
            //dr[MAKON02249EA.CT_StockConf_CustomerName2RF]        = sourceDataRow[MAKON02249EA.CT_StockConf_CustomerName2RF];        // ���Ӑ於��2        (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            dr[MAKON02249EA.CT_StockConf_SupplierCd] = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierCd];         // �d����R�[�h       (Int32)
            dr[MAKON02249EA.CT_StockConf_SupplierSnm] = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSnm];       // �d���於��         (string)
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            dr[MAKON02249EA.CT_StockConf_GoodsCodeRF]            = sourceDataRow[MAKON02249EA.CT_StockConf_GoodsCodeRF];            // ���i�R�[�h         (string)
            dr[MAKON02249EA.CT_StockConf_GoodsNameRF]            = sourceDataRow[MAKON02249EA.CT_StockConf_GoodsNameRF];            // ���i����           (string)
            dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSlipNoRF];       // �d���`�[�ԍ�       (Int32)
            dr[MAKON02249EA.CT_StockConf_StockRowNoRF]           = sourceDataRow[MAKON02249EA.CT_StockConf_StockRowNoRF];           // �d���s�ԍ�         (Int32)
            dr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StckSlipExpNumRF];       // �d���ڍהԍ�       (Int32)
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivRF]         = sourceDataRow[MAKON02249EA.CT_StockConf_DebitNoteDivRF];         // �ԓ`�敪           (Int32)
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF];       // �ԓ`�敪��         (string)
            dr[MAKON02249EA.CT_StockConf_AccPayDivCdRF]          = sourceDataRow[MAKON02249EA.CT_StockConf_AccPayDivCdRF];          // ���|�敪           (Int32)
            dr[MAKON02249EA.CT_StockConf_AccPayDivNmRF]          = sourceDataRow[MAKON02249EA.CT_StockConf_AccPayDivNmRF];          // ���|�敪��         (string)

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreCodeRF]  = sourceDataRow[MAKON02249EA.CT_StockConf_LargeGoodsGanreCodeRF];  // ���i�啪�ރR�[�h   (Int32)
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreNameRF]  = sourceDataRow[MAKON02249EA.CT_StockConf_LargeGoodsGanreNameRF];  // ���i�啪�ޖ���     (string)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreCodeRF] = sourceDataRow[MAKON02249EA.CT_StockConf_MediumGoodsGanreCodeRF]; // ���i�����ރR�[�h   (Int32)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreNameRF] = sourceDataRow[MAKON02249EA.CT_StockConf_MediumGoodsGanreNameRF]; // ���i�����ޖ���     (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            dr[MAKON02249EA.CT_StockConf_StockAgentCodeRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StockAgentCodeRF];       // �d���S���҃R�[�h   (string)
            dr[MAKON02249EA.CT_StockConf_StockAgentNameRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StockAgentNameRF];       // �d���S���Җ���     (string)
            dr[MAKON02249EA.CT_StockConf_StockCountRF]           = sourceDataRow[MAKON02249EA.CT_StockConf_StockCountRF];           // �d����             (double)
            dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StockUnitPriceRF];       // �d���P��           (Int64)
            dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF]     = sourceDataRow[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF];     // �d�����z           (Int64)
            dr[MAKON02249EA.CT_StockConf_SupplierSlipCdRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSlipCdRF];       // �d���`�[�敪       (Int32)
            dr[MAKON02249EA.CT_StockConf_SupplierSlipNmRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSlipNmRF];       // �d���`�[�敪��     (string)
            dr[MAKON02249EA.CT_StockConf_FirstRowFlg]            = sourceDataRow[MAKON02249EA.CT_StockConf_FirstRowFlg];            // �擪���׃t���O     (Int32)
        }

		/// <summary>
		/// �`�[�`�� �d���݌Ɏ�񂹖��̉�����
		/// </summary>
		private string GetStockOrderDivNm(int StockOrderDivCd)
		{
			string wkStr = "";

			switch (StockOrderDivCd)
			{
				case 1:
					{
						wkStr = "�݌�";
						break;
					}
				case 0:
					{
						wkStr = "���";
						break;
					}
			}

			return wkStr;
		}

        /// <summary>
        /// �`�[�`�� ���̉�����
        /// </summary>
        private string GetSupplierSlipNm(int SupplierSlipCd)
        {
            string wkStr = "";

            switch (SupplierSlipCd)
            {
                case 10:
                    {
                        wkStr = "�d��";
                        break;
                    }
                case 20:
                    {
                        wkStr = "�ԕi";
                        break;
                    }
            }

            return wkStr;
        }

		/// <summary>
		/// �d���`�� ���̉�����
		/// </summary>
		private string GetSupplierFormalNm(int SupplierFormal)
		{
			string wkStr = "";

			switch (SupplierFormal)
			{
				case 0:
					{
						wkStr = "�d��";
						break;
					}
				case 1:
					{
						wkStr = "����";
						break;
					}
				case 2:
					{
						wkStr = "����";
						break;
					}
			}

			return wkStr;
		}


        /// <summary>
        /// �ԓ`�敪 ���̉�����
        /// </summary>
        private string GetDebitNoteDivNm(int debitNoteDiv)
        {
            string wkStr = "";

            switch (debitNoteDiv)
            {
                case 0:
                    {
                        wkStr = "���`";
                        break;
                    }
                case 1:
                    {
                        wkStr = "�ԓ`";
                        break;
                    }
                case 2:
                    {
                        wkStr = "����";
                        break;
                    }
            }

            return wkStr;
        }

        /// <summary>
        /// ���|�敪 ���̉�����
        /// </summary>
        private string GetAccRecDivNm(int accPayDivCd)
        {
            string wkStr = "";

            switch (accPayDivCd)
            {
                case 0:
                    {
                        wkStr = "���|�Ȃ�";
                        break;
                    }
                case 1:
                    {
                        wkStr = "���|����";
                        break;
                    }
            }

            return wkStr;
        }

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

		#endregion
	}
}
