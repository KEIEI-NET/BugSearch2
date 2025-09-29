//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
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
    /// �d���ԕi�\��ꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�\��ꗗ�\�ɃA�N�Z�X����N���X�ł�</br>
    /// <br>Programer  : FSI���� ����</br>
    /// <br>Date       :  2013/01/28</br>
    /// </remarks>
    public class PMKAK02032A
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
        private static string mySectionCode = "";
        /// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
        private static PrtOutSet prtOutSetData = null;
        #endregion

        // ===================================================================================== //
        //  �����g�p�ϐ�
        // ===================================================================================== //
        #region private member
        /// <summary>���_���A�N�Z�X�N���X</summary>
        private static SecInfoAcs _secInfoAcs;
        /// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>����pDataSet</summary>
        public DataSet _printDataSet;
        /// <summary>�o�b�t�@DataSet</summary>
        public static DataSet _printBuffDataSet;
        /// <summary>�d���ԕi�\��ꗗ�\�f�[�^�e�[�u����</summary>
        private string _Tbl_ShipmentDtl;
        // ���[�^�C�g��
        private string ListTitle = "�d���ԕi�\��ꗗ�\";
        //���o�����N���X
		private ExtrInfo_PMKAK02034E _extrInfo_PMKAK02034E;

        #endregion

        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant

        ///// <summary>�d���ԕi�\��ꗗ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �R���X�g���N�^�[

        /// <summary>
        /// �d���ԕi�\��ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02032A()
        {
            this.SettingDataTable();

            // ����pDataSet
            this._printDataSet = new DataSet();
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
        /// �d���ԕi�\��ꗗ�\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        static PMKAK02032A()
        {
            // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
            prtOutSetAcs = new PrtOutSetAcs();

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
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (prtOutSetData != null)
                {
                    prtOutSet = prtOutSetData.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = prtOutSetData.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
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
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// �d���ԕi�\��ꗗ�\�f�[�^����������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Static�������������܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --�e�[�u���s������-----------------------
            // ���o���ʃf�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[_Tbl_ShipmentDtl] != null)
            {
                this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();
            }
            // ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (_printBuffDataSet.Tables[_Tbl_ShipmentDtl] != null)
            {
                _printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();
            }
        }

        /// <summary>
        /// �d���ԕi�\��ꗗ�\�f�[�^�擾����
        /// </summary>
        /// <param name="extrInfo_PMKAK02034E"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="mode">�T�[�`���[�h(0:remote only,1:static��remote,2:static only)</param>
		public int Search(ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(extrInfo_PMKAK02034E, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(extrInfo_PMKAK02034E, out message);
                        }
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
        /// �d���ԕi�\��ꗗ�\�X�^�e�B�b�N�f�[�^�擾����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();

            if (_printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();
                        buffDr = _printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
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
        /// �d���ԕi�\��ꗗ�\�f�[�^�擾����
        /// </summary>
        /// <param name="extrInfo_PMKAK02034E"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔͈͂̎d���ԕi�\��ꗗ�\�f�[�^���擾���܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
		private int Search(ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";

            try
            {
                // StaticMemory�@������
                InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
				StockRetPlnParamWork StockRetPlnList = new StockRetPlnParamWork();

                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(extrInfo_PMKAK02034E, ref StockRetPlnList);

                status = this.SearchByMode(out retObj, StockRetPlnList);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;
                
                if ((status == 0) && (retList.Count != 0))
                {
                    // ���擾
                    for (int i = 0; i < retList.Count; i++)
                    {
                        SetTebleRowFromRetList(retList, i);

                    }
                    
                    // �f�[�^�Z�b�g�̃R�~�b�g
                    this._printDataSet.AcceptChanges();

                    if (this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        // �o�b�t�@�e�[�u���ւ̊i�[
                        _printBuffDataSet = this._printDataSet.Copy();

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                else
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

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
        /// <param name="extrInfo_PMKAK02034E">�����p�����[�^</param>
        /// <param name="StockRetPlnList">�擾�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����p�����[�^�̐ݒ���s���܂��B </br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
		private void SearchParaSet(ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E, ref StockRetPlnParamWork StockRetPlnList)
        {
            #region < ��ƃR�[�h >
            StockRetPlnList.EnterpriseCode = extrInfo_PMKAK02034E.EnterpriseCode;                 // ��ƃR�[�h
            #endregion

            #region < ���_ >

			if (extrInfo_PMKAK02034E.SectionCodes.Length != 0)
			{
				if (extrInfo_PMKAK02034E.SectionCodes[0] == "0")
				{
					// �S�Ђ̎�
					StockRetPlnList.SectionCodes = new string[0];                                 // ���_�R�[�h
				}
				else
				{
					StockRetPlnList.SectionCodes = extrInfo_PMKAK02034E.SectionCodes;             // ���_�R�[�h
				}
			}
			else
			{
				StockRetPlnList.SectionCodes = new string[0];                                     // ���_�R�[�h
			}
			#endregion

            #region < ��ʐݒ���� >
 
            StockRetPlnList.SupplierCdSt      = extrInfo_PMKAK02034E.SupplierCdSt;                // �J�n�d����R�[�h
            StockRetPlnList.SupplierCdEd      = extrInfo_PMKAK02034E.SupplierCdEd;                // �I���d����R�[�h
			StockRetPlnList.InputDaySt		   = extrInfo_PMKAK02034E.InputDaySt;				  // �J�n���͓�
			StockRetPlnList.InputDayEd		   = extrInfo_PMKAK02034E.InputDayEd;			      // �I�����͓�
			StockRetPlnList.MakeShowDiv	   = extrInfo_PMKAK02034E.MakeShowDiv;                    // ���s�^�C�v
			StockRetPlnList.SlipDiv		   = extrInfo_PMKAK02034E.SlipDiv;                        // �o�͎w��
            StockRetPlnList.PrintDailyFooter  = extrInfo_PMKAK02034E.PrintDailyFooter;            // ���t�w��
			
			#endregion
        }
        
        /// <summary>
        /// �f�[�^�X�L�[�}�\������
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.PMKAK02035EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// ���[�h����Search�ďo����
        /// </summary>
        /// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        /// <param name="StockRetPlnList">�����[�g���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
		private int SearchByMode(out object retObj, StockRetPlnParamWork StockRetPlnList)
        {
            int status = 0;
            retObj = null;

            IStockRetPlnTableDB _iStockRetListDB = (IStockRetPlnTableDB)MediationStockRetPlnTableDB.GetStockRetPlnTableDB();

            status = _iStockRetListDB.Search(out retObj, StockRetPlnList);

            return status;
        }

        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
			this._Tbl_ShipmentDtl = Broadleaf.Application.UIData.PMKAK02035EA.ct_Tbl_StockRetDtl;
        }

        /// <summary>
        /// �N�����[�h���f�[�^Row�쐬
        /// </summary>
        /// <param name="retList">�f�[�^�擾�����X�g</param>
        /// <param name="setCnt">���X�g�̃f�[�^�擾Index</param>
        private void SetTebleRowFromRetList(ArrayList retList, int setCnt)
        {
			_extrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();
            DataRow dr;
            dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();
            // ���גP��
			StockRetPlnList StockRetPlnList = (StockRetPlnList)retList[setCnt];
            // ���_�R�[�h
            dr[PMKAK02035EA.ct_Col_SectionCode]         = StockRetPlnList.SectionCode;
            // ���_�K�C�h����
            dr[PMKAK02035EA.ct_Col_SectionGuideNm]      = StockRetPlnList.SectionGuideNm;	
            // ���͓��t
			dr[PMKAK02035EA.ct_Col_InputDay]			= StockRetPlnList.InputDay;	
            // �d�����t
			dr[PMKAK02035EA.ct_Col_StockDate]			= StockRetPlnList.StockDate; 
            // �d����R�[�h
            dr[PMKAK02035EA.ct_Col_SupplierCd]          = StockRetPlnList.SupplierCd; 
            // �d���旪��
            dr[PMKAK02035EA.ct_Col_SupplierSnm]         = StockRetPlnList.SupplierSnm;   
            // ���i���[�J�[�R�[�h
            dr[PMKAK02035EA.ct_Col_GoodsMakerCd]        = StockRetPlnList.GoodsMakerCd;  
            // ���i����
            dr[PMKAK02035EA.ct_Col_MakerName]           = StockRetPlnList.MakerName; 
            // ���i�ԍ�
            dr[PMKAK02035EA.ct_Col_GoodsNo]             = StockRetPlnList.GoodsNo;               
            // �d����
            dr[PMKAK02035EA.ct_Col_StockCount]          = StockRetPlnList.StockCount;
            // �Ŕ��d���P��
            dr[PMKAK02035EA.ct_Col_StockUnitPriceFl] = StockRetPlnList.StockUnitPriceFl;
            // �ō��d���P��
            dr[PMKAK02035EA.ct_Col_StockUnitTaxPriceFl] = StockRetPlnList.StockUnitTaxPriceFl;
            // �Ŕ����׎d�����z
            dr[PMKAK02035EA.ct_Col_StockPriceTaxExc] = StockRetPlnList.StockPriceTaxExc;
            // �ō����׎d�����z
            dr[PMKAK02035EA.ct_Col_StockPriceTaxInc] = StockRetPlnList.StockPriceTaxInc;
            // �Ŕ��`�[���z
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxExc] = StockRetPlnList.StockTtlPricTaxExc;
            // �ō��`�[���z
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxInc] = StockRetPlnList.StockTtlPricTaxInc;
            // �`�[�����
            dr[PMKAK02035EA.ct_Col_SlpConsTax] = StockRetPlnList.SlpConsTax;
            // ���׏����
            dr[PMKAK02035EA.ct_Col_DtlConsTax] = StockRetPlnList.DtlConsTax;
            // �Ŕ��艿
            dr[PMKAK02035EA.ct_Col_ListPriceTaxExc] = StockRetPlnList.ListPriceTaxExc;
            // �ō��艿
            dr[PMKAK02035EA.ct_Col_ListPriceTaxInc] = StockRetPlnList.ListPriceTaxInc;
            // �ېŋ敪
            dr[PMKAK02035EA.ct_Col_TaxationCode] = StockRetPlnList.TaxationCode;
            // ����œ]�ŋ敪
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = StockRetPlnList.SuppCTaxLayCd;
            // �d���`�[���l1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = StockRetPlnList.SupplierSlipNote1;
            // �d�������œ]�ŕ����R�[�h
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = StockRetPlnList.SuppCTaxLayCd;
            // BL���i�R�[�h
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = StockRetPlnList.BLGoodsCode;
            // BL���i�R�[�h����
            dr[PMKAK02035EA.ct_Col_GoodsName] = StockRetPlnList.GoodsName;
            // ���[�^�C�g��
            dr[PMKAK02035EA.ct_Col_ListTitle] = this.ListTitle;                      
            // �d���`�[���l1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = StockRetPlnList.SupplierSlipNote1;
            // �d�������œ]�ŕ����R�[�h
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = StockRetPlnList.SuppCTaxLayCd; 
            // BL���i�R�[�h
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = StockRetPlnList.BLGoodsCode; 
            
            // �`�[�敪
            switch (StockRetPlnList.SupplierSlipCd)
			{
				case 10: // �d��

                    dr[PMKAK02035EA.ct_Col_SupplierSlipCd] = "�d��";

					break;

				case 20: // �ԕi

                    dr[PMKAK02035EA.ct_Col_SupplierSlipCd] = "�ԕi";
					
					break;
			}


            // �o�͎w��(�ԕi�\��or�ԕi�ς̖��׃X�e�[�^�X�󎚗p�j
            // �ԕi�ς̘_���폜(�ʏ�f�[�^�Ƃ��Ĉ󎚁j�F�d���f�[�^�_���폜:1�A�d�����׃f�[�^�_���폜:1�A�d�����גʔ�:0
            if (StockRetPlnList.SlpLogDelCd == 1 && StockRetPlnList.DtlLogDelCd == 1 && StockRetPlnList.SalesSlipDtlNum == 0)

                    dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "�ԕi��";

            // �d���\��̍폜�f�[�^
            else if (StockRetPlnList.SlpLogDelCd == 1 && StockRetPlnList.DtlLogDelCd == 1 && StockRetPlnList.SalesSlipDtlNum > 0)

                    dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "�ԕi�\��";

            else
            {
                switch (StockRetPlnList.DtlLogDelCd)
                {
                    case 0: // �ԕi�\��

                        dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "�ԕi�\��";

                        break;

                    case 1: // �ԕi��

                        dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "�ԕi��";

                        break;
                }
            }

            // �d���`�[�ԍ���0����
            string padCustomerCode = StockRetPlnList.SupplierSlipNo.ToString("d09");
            dr[PMKAK02035EA.ct_Col_SupplierSlipNo] = padCustomerCode;	

			this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
        }


       
        /// <summary>
        /// �N�����[�h���f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="sourceDataRow">�Z�b�g��DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            // ���_�R�[�h
            dr[PMKAK02035EA.ct_Col_SectionCode] = sourceDataRow[PMKAK02035EA.ct_Col_SectionCode];  
            // ���_�K�C�h����
            dr[PMKAK02035EA.ct_Col_SectionGuideNm] = sourceDataRow[PMKAK02035EA.ct_Col_SectionGuideNm];  
            // �d���`�[�ԍ�
            dr[PMKAK02035EA.ct_Col_SupplierSlipNo] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSlipNo];  
            // ���͓��t
            dr[PMKAK02035EA.ct_Col_InputDay] = sourceDataRow[PMKAK02035EA.ct_Col_InputDay];  
            // �d�����t
            dr[PMKAK02035EA.ct_Col_StockDate] = sourceDataRow[PMKAK02035EA.ct_Col_StockDate];  
            // �d����R�[�h
            dr[PMKAK02035EA.ct_Col_SupplierCd] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierCd];  
            // �d���旪��
            dr[PMKAK02035EA.ct_Col_SupplierSnm] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSnm];  
            // ���i���[�J�[�R�[�h
            dr[PMKAK02035EA.ct_Col_GoodsMakerCd] = sourceDataRow[PMKAK02035EA.ct_Col_GoodsMakerCd];  
            // ���i����
            dr[PMKAK02035EA.ct_Col_MakerName] = sourceDataRow[PMKAK02035EA.ct_Col_MakerName];  
            // ���i�ԍ�
            dr[PMKAK02035EA.ct_Col_GoodsNo] = sourceDataRow[PMKAK02035EA.ct_Col_GoodsNo];  
            // �d����
            dr[PMKAK02035EA.ct_Col_StockCount] = sourceDataRow[PMKAK02035EA.ct_Col_StockCount];  
            // �Ŕ��d���P��
            dr[PMKAK02035EA.ct_Col_StockUnitPriceFl] = sourceDataRow[PMKAK02035EA.ct_Col_StockUnitPriceFl];  
            // �ō��d���P��
            dr[PMKAK02035EA.ct_Col_StockUnitTaxPriceFl] = sourceDataRow[PMKAK02035EA.ct_Col_StockUnitTaxPriceFl];  
            // �Ŕ����׎d�����z
            dr[PMKAK02035EA.ct_Col_StockPriceTaxExc] = sourceDataRow[PMKAK02035EA.ct_Col_StockPriceTaxExc];  
            // �ō����׎d�����z
            dr[PMKAK02035EA.ct_Col_StockPriceTaxInc] = sourceDataRow[PMKAK02035EA.ct_Col_StockPriceTaxInc];  
            //�Ŕ��`�[���z
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxExc] = sourceDataRow[PMKAK02035EA.ct_Col_StockTtlPricTaxExc];  
            //�ō��`�[���z
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxInc] = sourceDataRow[PMKAK02035EA.ct_Col_StockTtlPricTaxInc];  
            //�`�[�����
            dr[PMKAK02035EA.ct_Col_SlpConsTax] = sourceDataRow[PMKAK02035EA.ct_Col_SlpConsTax];  
            //���׏����
            dr[PMKAK02035EA.ct_Col_DtlConsTax] = sourceDataRow[PMKAK02035EA.ct_Col_DtlConsTax];  
            //�Ŕ��艿
            dr[PMKAK02035EA.ct_Col_ListPriceTaxExc] = sourceDataRow[PMKAK02035EA.ct_Col_ListPriceTaxExc];  
            //�ō��艿
            dr[PMKAK02035EA.ct_Col_ListPriceTaxInc] = sourceDataRow[PMKAK02035EA.ct_Col_ListPriceTaxInc];  
            //�ېŋ敪
            dr[PMKAK02035EA.ct_Col_TaxationCode] = sourceDataRow[PMKAK02035EA.ct_Col_TaxationCode];  
            //����œ]�ŋ敪
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = sourceDataRow[PMKAK02035EA.ct_Col_SuppCTaxLayCd];  
            // �d���`�[���l1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSlipNote1];  
            // �d�������œ]�ŕ����R�[�h
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = sourceDataRow[PMKAK02035EA.ct_Col_SuppCTaxLayCd];  
            // BL���i�R�[�h
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = sourceDataRow[PMKAK02035EA.ct_Col_BLGoodsCode];  
            // ���[�^�C�g��
            dr[PMKAK02035EA.ct_Col_ListTitle] = sourceDataRow[PMKAK02035EA.ct_Col_ListTitle];  
            // �d���`�[���l1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSlipNote1];  
            // �d�������œ]�ŕ����R�[�h
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = sourceDataRow[PMKAK02035EA.ct_Col_SuppCTaxLayCd];  
            // BL���i�R�[�h
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = sourceDataRow[PMKAK02035EA.ct_Col_BLGoodsCode];  
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
