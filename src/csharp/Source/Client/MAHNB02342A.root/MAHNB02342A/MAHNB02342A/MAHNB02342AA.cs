//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ����m�F�\
// �v���O�����T�v   : ����m�F�\�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �J���@�͍K
// �� �� ��  2005/01/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/10/31  �C�����e : ����ň󎚕��@�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : ��Q�Ή�10247,11302,10743,11402
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/14  �C�����e : ����œ]�ŕ���[�`�[][����]�ȊO�͔�\���ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/06/29  �C�����e : Mantis.15691�@�Ԏ햼�̈󎚂��Ԏ�S�p���̂���Ԏ피�p���̂֕ύX����B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30531 ��� �r��
// �C �� ��  2010/07/14  �C�����e : Mantis�y15806�z�@���i���̂ɏ��i���̃J�i���Z�b�g����悤�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{��
// �C �� ��  2011/07/18  �C�����e : ���ׂɁu�����񓚁v�̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/11/29  �C�����e : ��Q�� #8076����m�F�\/�����`�[�ƍ폜�`�[�̋�ʂɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 3H ����
// �C �� ��  2020/02/27  �C�����e : 11570208-00 �y���ŗ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O 
// �C �� ��  2022/09/05  �C�����e : 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
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
    /// ����m�F�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����m�F�\�ɃA�N�Z�X����N���X�ł�</br>
    /// <br>Programer  : 22021�@�J���@�͍K</br>
    /// <br>Date       : 2005.01.23</br>
    /// <br>UpdateNote : 2008/10/31 �Ɠc �M�u�@����ň󎚕��@�ύX</br>
    /// <br>UpdateNote : 2009/04/13 ��� �r���@��Q�Ή�10247,11302,10743,11402</br>
    /// <br>UpdateNote : 2009/04/14 ��� �r���@����œ]�ŕ���[�`�[][����]�ȊO�͔�\���ɏC��</br>
    /// <br>UpdateNote : 2010/07/14 ��� �r���@Mantis�y15806�z�i�����S�p�̏ꍇ�A���p�ɕϊ�����</br>
    /// <br>UpdateNote : 2020/02/27 3H ���� 11570208-00 �y���ŗ��Ή�</br>
    /// </remarks>
	public class SaleConfAcs
	{
  	    // ===================================================================================== //
        //  �O���񋟒萔
        // ===================================================================================== //
	    #region public constant
	    /// <summary>�S���_���R�[�h�p���_�R�[�h</summary>
        // 2008.07.07 30413 ���� ���_�R�[�h��2���ɕύX >>>>>>START
        //public const string CT_AllSectionCode = "000000";
        public const string CT_AllSectionCode = "00";
        // 2008.07.07 30413 ���� ���_�R�[�h��2���ɕύX <<<<<<END
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

        /// <summary>���㏇�ʕ\�f�[�^�e�[�u����</summary>
        private string _SalesConfDataTable;

        // ���[�^�C�v�i���v or ���ה���p�j
        private int _printDiv;      //ADD 2008/10/31
        // --- ADD START 3H ���� 2020/02/27---------->>>>>
        private int    _iTaxPrintDiv;  // �ŕʓ���󎚗L���敪
        private Double _taxRate1;      // �ŗ��P
        private Double _taxRate2;      // �ŗ��Q
        // --- ADD END 3H ���� 2020/02/27----------<<<<<

        // �� 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>�\������</summary>
        //private string CT_Sort1_Odr = "SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                               // ��������`�[�ԍ�
        //private string CT_Sort2_Odr = "SalesDateRF, CustomerCodeRF, SalesFormCodeRF, GoodsCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF"; // ����������Ӑ恨�̔��`�ԁ����i���`�[�ԍ�
        //private string CT_Sort3_Odr = "SalesDateRF, CustomerCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                               // ����������Ӑ恨�`�[�ԍ�
        //private string CT_Sort4_Odr = "SalesFormCodeRF, CustomerCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";              // �̔��`�ԁ����Ӑ恨��������`�[�ԍ�
        //private string CT_Sort5_Odr = "SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                                            // �`�[�ԍ�
        // �� 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 2008.07.07 30413 ���� �s�v�v���p�e�B�̍폜 >>>>>>START
        // �� 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private string CT_Sort1_Odr = "SalesDateRF, SalesSlipNumRF, SalesRowNoRF";                                               // �����+�`�[�ԍ�
        //private string CT_Sort2_Odr = "CustomerCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF"; �@                            // ���Ӑ�+�����+�`�[�ԍ�
        //private string CT_Sort3_Odr = "SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";                                          // ���͓�+�`�[�ԍ�
        //private string CT_Sort4_Odr = "CustomerCodeRF, SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";                          // ���Ӑ�+���͓�+�`�[�ԍ�
        //private string CT_Sort5_Odr = "SalesEmployeeNmRF, SalesSlipNumRF, SalesRowNoRF";                                         // �S����+�`�[�ԍ�
        //private string CT_Sort6_Odr = "SalesAreaCodeRF, SalesSlipNumRF, SalesRowNoRF";                                           // �n��(�̔��G���A)+�`�[�ԍ�
        // �� 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        

        //private string CT_UpperOrder = " ASC";   // �����o��
        // 2008.07.07 30413 ���� �s�v�v���p�e�B�̍폜 <<<<<<END
        //private string CT_DownOrder  = " DESC";  // �~���o��

        // 2009.02.03 30413 ���� �J�E���g�ς݂̓`�[�L�[���X�g��ǉ� >>>>>>START
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
        // 2009.02.03 30413 ���� �J�E���g�ς݂̓`�[�L�[���X�g��ǉ� <<<<<<END
        
	    #endregion

        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
        /// <summary>�J�E���g�ς݂̔�ېœ`�[�L�[���X�g</summary>
        private readonly IList<string> _countedTaxFreeKeyList = new List<string>();
        /// <summary>
        /// �J�E���g�ς݂̔�ېœ`�[�L�[���X�g���擾���܂��B
        /// </summary>
        /// <value>�J�E���g�ς݂̔�ېœ`�[�L�[���X�g</value>
        private IList<string> CountedTaxFreeKeyList
        {
            get { return _countedTaxFreeKeyList; }
        }
        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant
	  
		///// <summary>���㏇�ʕ\�o�b�t�@�f�[�^�e�[�u����</summary>
        //public const string CT_SalesOrderBuffDataTable = Broadleaf.Application.UIData.MAHNB02349EA.CT_SalesOrderAgentBuffDataTable;
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        #endregion
        
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
		#region �R���X�g���N�^�[
       
		/// <summary>
        /// ���㏇�ʕ\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021 �J���@�͍K</br>
        /// <br>Date       : 2005.01.30</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public SaleConfAcs()
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
        /// ���㏇�ʕ\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021�@�J���@�͍K</br>
        /// <br>Date       : 2006.01.31</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static SaleConfAcs()
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
		static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			// prtOutSet  = null;

            prtOutSet = new PrtOutSet();

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
    	/// ���㏇�ʕ\�f�[�^����������
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
			if(this._printDataSet.Tables[_SalesConfDataTable] != null)
			{
				this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();
			}

			// ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (_printBuffDataSet.Tables[_SalesConfDataTable] != null)
			{
                _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Clear();
			}
		}


        /// <summary>
        /// ���㏇�ʕ\�f�[�^�擾����
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="mode">�T�[�`���[�h(0:remote only,1:static��remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(saleConfListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(saleConfListCndtn, out message);
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
        /// ���㏇�ʕ\�X�^�e�B�b�N�f�[�^�擾����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_SalesConfDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
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
        /// ���㏇�ʕ\�f�[�^�擾����
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔͈͂̔���`�F�b�N���X�g�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22021�@�J���@�͍K</br>
        /// <br>Date       : 2006.01.31</br>
        /// </remarks>
        public int Search(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                // StaticMemory�@������
                InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
                SalesConfShWork salesConfShWork = new SalesConfShWork();

                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(saleConfListCndtn, ref salesConfShWork);

                status = this.SearchByMode(out retObj, salesConfShWork);

                // ���f�[�^****************************
                // ���擾
                //for (int i = 0; i < 10; i++)
                //{
                //dr = this._printDataSet.Tables[CT_SalesConfDataTable].NewRow();
                //
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SalesEmployeeCdRF] = "200";     // �̔��]�ƈ��R�[�h (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SalesEmployeeNmRF] = "�ђJ�k��";     // �̔��]�ƈ����� (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SectionCodeRF] = "KYOTEN";             // ���_�R�[�h (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SectionGuideNmRF] = "��O�J����";       // ���_�K�C�h���� (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SalesCountTotal] = 100 * i + 1;       // ����䐔(�W�v) (Int32)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumSalesRF] = (100 * i + 1) * 1000;                   // ������z���v(�W�v) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumIncMoneyRF] = (100 * i + 1) * 700;             // INC���z���v(�W�v) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumMoneyRF] = (100 * i + 1) * 300;                // ��������z(�W�v) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumCostRF] = (100 * i + 1 )* 200;                     // �������z���v(�W�v) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumGrossProfitRF] = (100 * i + 1) * 100;       // �e�����z���v(�W�v) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumNwopCountRF] = (100 * i + 1) * 2;           // �l�b�g���[�N�l����(�W�v) (int64) 

                //    //dr[SFURI06225EA.CT_CsSaleChkList_AddUpADateStr    ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.AddUpADate);  // �v����t(����p)�@(string)
                //    //dr[SFURI06225EA.CT_CsSaleChkList_PublicationStr   ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.Publication); // ������t(����p)�@(string)
                //    //dr[SFURI06225EA.CT_CsSaleChkList_CorporateDivName ] = DivCdCnvStrDivNm((Int32)dr["CorporateDivCode"]); //�l�E�@�l�敪(����p)�@(string)

                //    this._printDataSet.Tables[CT_SalesConfDataTable].Rows.Add(dr);
                //}
                //status = 0;
                // ���f�[�^**************************** end

                //return status;

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // ���擾
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }

                    this._printDataSet.AcceptChanges();

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
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }


        /// <summary>
        /// ���㏇�ʕ\�f�[�^�擾����(�`�[�`��)
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔͈͂̔���`�F�b�N���X�g�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ��c �h��</br>
        /// <br>Date       : 2007.11.08</br>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        public int SearchSlipform(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                this._printDiv = 1;     //ADD 2008/10/31
                // --- ADD START 3H ���� 2020/02/27---------->>>>>
                _iTaxPrintDiv = saleConfListCndtn.TaxPrintDiv;�@�@// �ŕʓ���󎚗L���敪
                _taxRate1     = 0;                                // �ŗ��P
                _taxRate2     = 0;                                // �ŗ��Q
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(saleConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(saleConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H ���� 2020/02/27----------<<<<<

                // StaticMemory�@������
                InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
                SalesConfShWork salesConfShWork = new SalesConfShWork();

                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(saleConfListCndtn, ref salesConfShWork);

                status = this.SearchByModeSlip(out retObj, salesConfShWork);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // ���擾
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }

                    this._printDataSet.AcceptChanges();

                    // �o�b�t�@�e�[�u���ւ̊i�[
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    // 2009.02.13 30413 ���� �G���[�X�e�[�^�X��ԋp���C�� >>>>>>START
                    //status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    if (status == 0)
                    {
                        // ���ɒ��o����0���ŁAstatus���[���̏ꍇ
                        status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // 2009.02.13 30413 ���� �G���[�X�e�[�^�X��ԋp���C�� <<<<<<END
                }

            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// ���㏇�ʕ\�f�[�^�擾����(���ׁA�ڍ׌`��)
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔͈͂̔���`�F�b�N���X�g�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ��c �h��</br>
        /// <br>Date       : 2007.11.08</br>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        public int SearchDetailform(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                this._printDiv = 2;     //ADD 2008/10/31
                // --- ADD START 3H ���� 2020/02/27---------->>>>>
                _iTaxPrintDiv = saleConfListCndtn.TaxPrintDiv;�@�@// �ŕʓ���󎚗L���敪
                _taxRate1 = 0;                                    // �ŗ��P
                _taxRate2 = 0;                                    // �ŗ��Q
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(saleConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(saleConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H ���� 2020/02/27----------<<<<<

                // StaticMemory�@������
                InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
                SalesConfShWork salesConfShWork = new SalesConfShWork();
                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(saleConfListCndtn, ref salesConfShWork);

                status = this.SearchByModeDetail(out retObj, salesConfShWork);
  
                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // ���擾
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);

                        // ����`�[�敪�i���ׁj��3(����)�͏���
                        if (dr[MAHNB02349EA.CT_Col_SalesSlipCdDtl].ToString() != "3") // ADD 2009/04/13
                        {
                            this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                        }
                    }

                    this._printDataSet.AcceptChanges();

                    // �o�b�t�@�e�[�u���ւ̊i�[
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    // 2009.02.13 30413 ���� �G���[�X�e�[�^�X��ԋp���C�� >>>>>>START
                    //status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    if (status == 0)
                    {
                        // ���ɒ��o����0���ŁAstatus���[���̏ꍇ
                        status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // 2009.02.13 30413 ���� �G���[�X�e�[�^�X��ԋp���C�� <<<<<<END
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
        private void SearchParaSet(ExtrInfo_MAHNB02347E saleConfListCndtn, ref SalesConfShWork salesConfShWork)
        {
            salesConfShWork.EnterpriseCode = saleConfListCndtn.EnterpriseCode;         // ��ƃR�[�h

            // ���_
            if (saleConfListCndtn.ResultsAddUpSecList.Length != 0)
            {
                if (saleConfListCndtn.ResultsAddUpSecList[0] == "0")
                {
                    // �S�Ђ̎�
                    salesConfShWork.ResultsAddUpSecList = new string[0];        // ���_�R�[�h
                    // 2008.07.08 30413 ���� ����`�̂��߃R�����g�� >>>>>>START
                    //salesConfShWork.IsOutputAllSecRec = true;
                    // 2008.07.08 30413 ���� ����`�̂��߃R�����g�� <<<<<<END
                    salesConfShWork.IsSelectAllSection = true;
                }
                else
                {
                    salesConfShWork.ResultsAddUpSecList = saleConfListCndtn.ResultsAddUpSecList;     // ���_�R�[�h
                    salesConfShWork.IsSelectAllSection = false;
                    // 2008.07.08 30413 ���� ����`�̂��߃R�����g�� >>>>>>START
                    // �S���_�Ƀ`�F�b�N�������Ă��邩�ǂ����̃`�F�b�N
                    //if (_secInfoAcs.SecInfoSetList.Length == saleConfListCndtn.ResultsAddUpSecList.Length)
                    //{
                    //    salesConfShWork.IsOutputAllSecRec = true;
                    //}
                    //else
                    //{
                    //    salesConfShWork.IsOutputAllSecRec = false;
                    //}
                    // 2008.07.08 30413 ���� ����`�̂��߃R�����g�� <<<<<<END
                }
            }
            else
            {
                salesConfShWork.ResultsAddUpSecList = new string[0];    // ���_�R�[�h
                // 2008.07.08 30413 ���� ����`�̂��߃R�����g�� >>>>>>START
                //salesConfShWork.IsOutputAllSecRec = true;               // �S���_�W�v���R�[�h�ł̏o��
                // 2008.07.08 30413 ���� ����`�̂��߃R�����g�� <<<<<<END
                salesConfShWork.IsSelectAllSection = false;
            }

            // 2008.07.07 30413 ���� ���s�^�C�v�A�_���폜���ǉ� >>>>>>START
            salesConfShWork.LogicalDeleteCode = saleConfListCndtn.LogicalDeleteCode;        // �_���폜�敪
            // 2008.07.07 30413 ���� ���s�^�C�v�A�_���폜���ǉ� <<<<<<END
            
            // �� 2007.11.08 keigo yata Delete //////////////////////////////////////////////////////////////
            //salesConfShWork.IsDetails = saleConfListCndtn.IsDetails;                        // �o�͒P��
            // �� 2007.11.08 keigo yata Delete //////////////////////////////////////////////////////////////

            salesConfShWork.SalesDateSt = saleConfListCndtn.SalesDateSt;                    // �J�n�����
            salesConfShWork.SalesDateEd = saleConfListCndtn.SalesDateEd;                    // �I�������

            // �� 2007.11.08 keigo yata Change //////////////////////////////////////////////////////////////
            //salesConfShWork.ShipmentDaySt = saleConfListCndtn.ShipmentDaySt;              // �J�n�o�ד�
            //salesConfShWork.ShipmentDayEd = saleConfListCndtn.ShipmentDayEd;              // �I���o�ד�
            // �� 2007.11.08 keigo yata Change /////////////////////////////////////////////////////////////

            // 2008.07.08 30413 ���� ���͓��̃v���p�e�B���̂�ύX >>>>>>START
            // �� 2007.11.08 keigo yata Add ////////////////////////////////////////////////////////////////
            //salesConfShWork.SearchSlipDateSt = saleConfListCndtn.SearchSlipDataSt;          // �J�n���͓�
            //salesConfShWork.SearchSlipDateEd = saleConfListCndtn.SearchSlipDataEd;          // �I�����͓�
            // �� 2007.11.08 keigo yata Add ////////////////////////////////////////////////////////////////
            salesConfShWork.SearchSlipDateSt = saleConfListCndtn.SearchSlipDateSt;          // �J�n���͓�
            salesConfShWork.SearchSlipDateEd = saleConfListCndtn.SearchSlipDateEd;          // �I�����͓�
            // 2008.07.08 30413 ���� ���͓��̃v���p�e�B���̂�ύX >>>>>>START
            
            salesConfShWork.CustomerCodeSt = saleConfListCndtn.CustomerCodeSt;              // �J�n���Ӑ�R�[�h
            salesConfShWork.CustomerCodeEd = saleConfListCndtn.CustomerCodeEd;              // �I�����Ӑ�R�[�h

            // 2008.07.07 30413 ���� �d�����ǉ� >>>>>>START
            salesConfShWork.SupplierCdSt = saleConfListCndtn.SupplierCdSt;                  // �J�n�d����R�[�h
            salesConfShWork.SupplierCdEd = saleConfListCndtn.SupplierCdEd;                  // �I���d����R�[�h
            // 2008.07.07 30413 ���� �d�����ǉ� <<<<<<END

            // �� 2007.11.08 keigo yata Delete /////////////////////////////////////////////////////////////////////////
            //salesConfShWork.LargeGoodsGanreCdSt = saleConfListCndtn.LargeGoodsGanreCdSt;    // �J�n���i�啪�ރR�[�h
            //salesConfShWork.LargeGoodsGanreCdEd = saleConfListCndtn.LargeGoodsGanreCdEd;    // �I�����i�啪�ރR�[�h
            //salesConfShWork.MediumGoodsGanreCdSt = saleConfListCndtn.MediumGoodsGanreCdSt;  // �J�n���i�����ރR�[�h
            //salesConfShWork.MediumGoodsGanreCdEd = saleConfListCndtn.MediumGoodsGanreCdEd;  // �I�����i�����ރR�[�h
            //salesConfShWork.CellphoneModelCodeSt = saleConfListCndtn.CellphoneModelCodeSt;  // �J�n�@��R�[�h
            //salesConfShWork.CellphoneModelCodeEd = saleConfListCndtn.CellphoneModelCodeEd;  // �I���@��R�[�h
            // �� 2007.11.08 keigo yata Delete /////////////////////////////////////////////////////////////////

            // �� 2007.11.08 keigo yata Change ////////////////////////////////////////////////////////////////
            //salesConfShWork.GoodsCodeSt = saleConfListCndtn.GoodsCodeSt;                  // �J�n���i�R�[�h
            //salesConfShWork.GoodsCodeEd = saleConfListCndtn.GoodsCodeEd;                  // �I�����i�R�[�h
            // �� 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////

            salesConfShWork.DebitNoteDiv = saleConfListCndtn.DebitNoteDiv;                  // �ԓ`�敪
            salesConfShWork.SalesSlipCd = saleConfListCndtn.SalesSlipCd;                    // �`�[�敪
            salesConfShWork.SalesSlipNumSt = saleConfListCndtn.SalesSlipNumSt;              // �J�n����`�[�ԍ�
            salesConfShWork.SalesSlipNumEd = saleConfListCndtn.SalesSlipNumEd;              // �I������`�[�ԍ�
            
            // �� 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////////
            salesConfShWork.SalesInputCodeSt = saleConfListCndtn.SalesInputCodeSt;          // �J�n���͎҃R�[�h
            salesConfShWork.SalesInputCodeEd = saleConfListCndtn.SalesInputCodeEd;          // �I�����͎҃R�[�h           
            salesConfShWork.SalesEmployeeCdSt = saleConfListCndtn.SalesEmployeeCdSt;        // �J�n�S���R�[�h
            salesConfShWork.SalesEmployeeCdEd = saleConfListCndtn.SalesEmployeeCdEd;        // �I���S���R�[�h
            // 2008.07.15 30413 ���� ��t�]�ƈ��R�[�h��ǉ� >>>>>>START
            salesConfShWork.FrontEmployeeCdSt = saleConfListCndtn.FrontEmployeeCdSt;        // �J�n��t�]�ƈ��R�[�h
            salesConfShWork.FrontEmployeeCdSt = saleConfListCndtn.FrontEmployeeCdSt;        // �J�n��t�]�ƈ��R�[�h
            // 2008.07.15 30413 ���� ��t�]�ƈ��R�[�h��ǉ� <<<<<<END
            // 2008.07.07 30413 ���� �n��A�Ǝ��ǉ� >>>>>>START
            salesConfShWork.SalesAreaCodeSt = saleConfListCndtn.SalesAreaCodeSt;            // �J�n�n��R�[�h
            salesConfShWork.SalesAreaCodeEd = saleConfListCndtn.SalesAreaCodeEd;            // �I���n��R�[�h
            salesConfShWork.BusinessTypeCodeSt = saleConfListCndtn.BusinessTypeCodeSt;      // �J�n�Ǝ�R�[�h
            salesConfShWork.BusinessTypeCodeEd = saleConfListCndtn.BusinessTypeCodeEd;      // �I���Ǝ�R�[�h
            // 2008.07.07 30413 ���� �n��A�Ǝ��ǉ� <<<<<<END
            // 2008.07.07 30413 ���� ���s�^�C�v�A�o�͎w���ǉ� >>>>>>START
            salesConfShWork.SalesSlipUpdateCd = saleConfListCndtn.SalesSlipUpdateCd;        // ����`�[�X�V�敪
            salesConfShWork.SalesOrderDivCd = saleConfListCndtn.SalesOrderDivCd;            // ����݌Ɏ�񂹋敪
            salesConfShWork.WayToOrder = saleConfListCndtn.WayToOrder;                      // �������@
            // 2008.07.07 30413 ���� ���s�^�C�v�A�o�͎w���ǉ� <<<<<<END
            salesConfShWork.GrsProfitCheckLower = saleConfListCndtn.GrsProfitCheckLower;    // �e�������`�F�b�N
            salesConfShWork.GrsProfitCheckBest = saleConfListCndtn.GrsProfitCheckBest;      // �e���K���`�F�b�N
            salesConfShWork.GrsProfitCheckUpper = saleConfListCndtn.GrsProfitCheckUpper;    // �e������`�F�b�N
            salesConfShWork.GrossMargin1Mark = saleConfListCndtn.GrossMargin1Mark;          // �e���`�F�b�N�}�[�N1           
            salesConfShWork.GrossMargin2Mark = saleConfListCndtn.GrossMargin2Mark;          // �e���`�F�b�N�}�[�N2
            salesConfShWork.GrossMargin3Mark = saleConfListCndtn.GrossMargin3Mark;          // �e���`�F�b�N�}�[�N3
            salesConfShWork.GrossMargin4Mark = saleConfListCndtn.GrossMargin4Mark;          // �e���`�F�b�N�}�[�N4
            // �� 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////////

            // 2008.07.15 30413 ���� �󎚃v���p�e�B��ǉ� >>>>>>START
            salesConfShWork.ZeroSalesPrint = saleConfListCndtn.ZeroSalesPrint;                  // �����[���݈̂�
            salesConfShWork.ZeroCostPrint = saleConfListCndtn.ZeroCostPrint;                    // �����[���݈̂�
            salesConfShWork.ZeroGrsProfitPrint = saleConfListCndtn.ZeroGrsProfitPrint;          // �e���[���݈̂�
            salesConfShWork.ZeroUdrGrsProfitPrint = saleConfListCndtn.ZeroUdrGrsProfitPrint;    // �e���[���ȉ��݈̂�
            salesConfShWork.GrsProfitRatePrint = saleConfListCndtn.GrsProfitRatePrint;          // �e������
            salesConfShWork.GrsProfitRatePrintVal = saleConfListCndtn.GrsProfitRatePrintVal;    // �e�����󎚒l
            salesConfShWork.GrsProfitRatePrintDiv = saleConfListCndtn.GrsProfitRatePrintDiv;    // �e�����󎚋敪
            // 2008.07.15 30413 ���� �󎚃v���p�e�B��ǉ� <<<<<<END
            

            // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////
            //// �L�����A
            //if (saleConfListCndtn.CarrierCodeList.Length != 0)
            //{
            //    if (saleConfListCndtn.CarrierCodeList[0] == 0)
            //    {
            //        // �S�Ă̎�
            //        salesConfShWork.CarrierCodeList = new int[0];  // �ΏۃL�����A
            //        salesConfShWork.IsSelectAllCarrier = true;     // �S�L�����A�W�v���R�[�h�ł̏o��
            //    }
            //    else
            //    {
            //        salesConfShWork.CarrierCodeList = saleConfListCndtn.CarrierCodeList;  // �ΏۃL�����A
            //        salesConfShWork.IsSelectAllCarrier = false;    // �e�L�����A���R�[�h�ł̏o��
            //    }
            //}
            //else
            //{
            //    salesConfShWork.CarrierCodeList = new int[0];  // �ΏۃL�����A
            //    salesConfShWork.IsOutputAllSecRec = true;      // �S�L�����A�W�v���R�[�h�ł̏o��
            //}

            // ����`��
            //if (saleConfListCndtn.SalesFormal.Length != 0)
            //{
            //    if (saleConfListCndtn.SalesFormal[0] == 0)
            //    {
            //        // �S�Ă̎�
            //        salesConfShWork.SalesFormal = new int[0];  // �Ώ۔���`��
            //    }
            //    else
            //    {
            //        salesConfShWork.SalesFormal = saleConfListCndtn.SalesFormal;  // �Ώ۔���`��
            //    }
            //}
            //else
            //{
            //    salesConfShWork.SalesFormal = new int[0];  // �Ώ۔���`��
            //}

            // �̔��`��
            //if (saleConfListCndtn.SalesFormCodeList.Length != 0)
            //{
            //    if (saleConfListCndtn.SalesFormCodeList[0] == 0)
            //    {
            //        // �S�Ă̎�
            //        salesConfShWork.SalesFormCode = new int[0];  // �Ώ۔���`��
            //    }
            //    else
            //    {
            //        salesConfShWork.SalesFormCode = saleConfListCndtn.SalesFormCodeList;  // �Ώ۔���`��
            //    }
            //}
            //else
            //{
            //    salesConfShWork.SalesFormCode = new int[0];  // �Ώ۔���`��
            //}
            // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// �f�[�^�X�L�[�}�\������
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
		{
			// ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.MAHNB02349EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// ���[�h����Search�ďo����
        /// </summary>
        /// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesConfShWork">�����[�g���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByMode(out object retObj, SalesConfShWork salesConfShWork)
        {
            int status = 0;

            retObj = null;

            ISalesConfDB _iSalesConfDB = (ISalesConfDB)MediationSalesConfDB.GetSalesConfDB();

            status = _iSalesConfDB.SearchSlip(out retObj, salesConfShWork);

            return status;
        }

        // �� 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ���[�h����Search�ďo����
        /// �`�[�`���ŏo�͂��邽�߂�SearchSlip���\�b�h�̌Ăяo��
        /// </summary>
        /// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesConfShWork">�����[�g���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByModeSlip(out object retObj, SalesConfShWork salesConfShWork)
        {
            int status = 0;

            retObj = null;

            ISalesConfDB _iSalesConfDB = (ISalesConfDB)MediationSalesConfDB.GetSalesConfDB();
            
            status = _iSalesConfDB.SearchSlip(out retObj, salesConfShWork);
            
            return status;
        }
        
        /// <summary>
        /// ���[�h����Search�ďo����
        /// ���ׁA�ڍ׌`���ŏo�͂��邽�߂�SearchDetail���\�b�h�̌Ăяo��
        /// </summary>
        /// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesConfShWork">�����[�g���������N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByModeDetail(out object retObj, SalesConfShWork salesConfShWork)
        {
            int status = 0;

            retObj = null;

            ISalesConfDB _iSalesConfDB = (ISalesConfDB)MediationSalesConfDB.GetSalesConfDB();


            status = _iSalesConfDB.SearchDetail(out retObj, salesConfShWork);


            return status;
        }
        // �� 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////

        // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// �󎚏��N�G���쐬����
        ///// </summary>
        ///// <returns>�쐬�����N�G��</returns>
        ///// <remarks>
        ///// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2005.12.06</br>
        ///// </remarks>
        //private string GetPrintOderQuerry(ExtrInfo_MAHNB02347E saleConfListCndtn)
        //{
        //    string orderQuerry = "";

        //    // �\�[�g���ݒ�
        //    switch (saleConfListCndtn.SortOrder)
        //    {
        //        case 0:
        //            {
        //                // ����䐔
        //                orderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 1:
        //            {
        //                // ������z���v
        //                orderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
        //                // ��������z
        //                orderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
        //                // �e�����z���v
        //                orderQuerry = CT_Sort4_Odr;
        //                break;
        //            }
        //        case 4:
        //            {
        //                // ȯ�ܰ��l����
        //                orderQuerry = CT_Sort5_Odr;
        //                break;
        //            }

        //    }

        //    // �����Œ�
        //    orderQuerry += CT_UpperOrder; 

        //    return orderQuerry;
        //}
        // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////

        // 2008.07.25 30413 ���� �s�v���\�b�h�̍폜 >>>>>>START
        #region �s�v���\�b�h�̍폜
        //// �� 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// �󎚏��N�G���쐬����
        ///// </summary>
        ///// <returns>�쐬�����N�G��</returns>
        ///// <remarks>
        ///// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        ///// <br>Programmer : ��c �h��</br>
        ///// <br>Date       : 2007.11.08</br>
        ///// </remarks>
        //private string GetPrintOderQuerry(ExtrInfo_MAHNB02347E saleConfListCndtn)
        //{
        //    string orderQuerry = "";

        //    // �\�[�g���ݒ�
        //    switch (saleConfListCndtn.SortOrder)
        //    {
        //        case 0:
        //            {
                        
        //                orderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 1:
        //            {
                        
        //                orderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
                        
        //                orderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
                        
        //                orderQuerry = CT_Sort4_Odr;
        //                break;
        //            }
        //        case 4:
        //            {
                        
        //                orderQuerry = CT_Sort5_Odr;
        //                break;
        //            }
        //        case 5:
        //            {
        //                orderQuerry = CT_Sort6_Odr;
        //                break;
        //            }
        //    }

        //    // �����Œ�
        //    orderQuerry += CT_UpperOrder;

        //    return orderQuerry;
        //}
        //// �� 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////
        #endregion
        // 2008.07.25 30413 ���� �s�v���\�b�h�̍폜 <<<<<<END
        
        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            this._SalesConfDataTable = Broadleaf.Application.UIData.MAHNB02349EA.CT_SalesConfDataTable;
        }


        /// <summary>
        /// �N�����[�h���f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="retList">�f�[�^�擾�����X�g</param>
        /// <param name="setCnt">���X�g�̃f�[�^�擾Index</param>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        {
            // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////
            //Int64 salesMoney = 0;
            //Int64 cost = 0;
            //double GrossMarginRate = 0.0;
            // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////

            // ���גP��
            SalesConfWork saleConfWork = (SalesConfWork)retList[setCnt];

            // 2008.07.08 30413 ���� Row���ڂ̑S�u������ >>>>>>START
            dr[MAHNB02349EA.CT_Col_SectionCode] = saleConfWork.SectionCode;                     // ���_�R�[�h (string)
            dr[MAHNB02349EA.CT_Col_SectionGuideNm] = saleConfWork.SectionGuideNm;               // ���_�K�C�h���� (string)
            dr[MAHNB02349EA.CT_Col_SubSectionCode] = saleConfWork.SubSectionCode;               // ����R�[�h (Int32)
            dr[MAHNB02349EA.CT_Col_SubSectionName] = saleConfWork.SubSectionName;               // ���喼�� (string)
            dr[MAHNB02349EA.CT_Col_SalesSlipNum] = saleConfWork.SalesSlipNum;                   // ����`�[�ԍ� (string)
            dr[MAHNB02349EA.CT_Col_ClaimCode] = saleConfWork.ClaimCode;                         // ������R�[�h (Int32)
            dr[MAHNB02349EA.CT_Col_ClaimSnm] = saleConfWork.ClaimSnm;                           // �����旪�� (string)
            dr[MAHNB02349EA.CT_Col_CustomerCode] = saleConfWork.CustomerCode;                   // ���Ӑ�R�[�h (Int32)
            dr[MAHNB02349EA.CT_Col_CustomerSnm] = saleConfWork.CustomerSnm;                     // ���Ӑ旪�� (string)
            dr[MAHNB02349EA.CT_Col_ShipmentDay] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.ShipmentDay);                     // �o�ד��t (DateTime)
            dr[MAHNB02349EA.CT_Col_SalesDate] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.SalesDate);                         // ������t (DateTime)
            dr[MAHNB02349EA.CT_Col_AddUpADate] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.AddUpADate);                       // �v����t (Int32)
            dr[MAHNB02349EA.CT_Col_SalesSlipCd] = saleConfWork.SalesSlipCd;                     // ����`�[�敪 (Int32)
            dr[MAHNB02349EA.CT_Col_AccRecDivCd] = saleConfWork.AccRecDivCd;                     // ���|�敪 (Int32)
            dr[MAHNB02349EA.CT_Col_SalesInputCode] = saleConfWork.SalesInputCode;               // ������͎҃R�[�h (string)
            dr[MAHNB02349EA.CT_Col_SalesInputName] = saleConfWork.SalesInputName;               // ������͎Җ��� (string)
            dr[MAHNB02349EA.CT_Col_FrontEmployeeCd] = saleConfWork.FrontEmployeeCd;             // ��t�]�ƈ��R�[�h (string)
            dr[MAHNB02349EA.CT_Col_FrontEmployeeNm] = saleConfWork.FrontEmployeeNm;             // ��t�]�ƈ����� (string)
            dr[MAHNB02349EA.CT_Col_SalesEmployeeCd] = saleConfWork.SalesEmployeeCd;             // �̔��]�ƈ��R�[�h (string)
            dr[MAHNB02349EA.CT_Col_SalesEmployeeNm] = saleConfWork.SalesEmployeeNm;             // �̔��]�ƈ����� (string)
            dr[MAHNB02349EA.CT_Col_PartySaleSlipNum] = saleConfWork.PartySaleSlipNum;           // �����`�[�ԍ� (string)
            dr[MAHNB02349EA.CT_Col_SalesTotalTaxInc] = saleConfWork.SalesTotalTaxInc;           // ����`�[���v�i�ō��݁j (Int64)
            dr[MAHNB02349EA.CT_Col_SalesTotalTaxExc] = saleConfWork.SalesTotalTaxExc;           // ����`�[���v�i�Ŕ����j (Int64)
            dr[MAHNB02349EA.CT_Col_TotalCost] = saleConfWork.TotalCost;                         // �������z�v (Int64)
            //dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv;         // �ԕi���R�R�[�h (Int32)
            //dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // �ԕi���R (string)
            // �ԕi���R�R�[�h�ƕԕi���R�͈�x�󔒂Őݒ�
            dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = "";                                     // �ԕi���R�R�[�h (Int32)
            dr[MAHNB02349EA.CT_Col_RetGoodsReason] = "";                                        // �ԕi���R (string)
            //dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo;                       // ���Ӑ�`�[�ԍ� (Int32)
            // ���Ӑ�`�[�ԍ��͈�x�󔒂Őݒ�
            dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";                                            // ���Ӑ�`�[�ԍ� (Int32)
            dr[MAHNB02349EA.CT_Col_SlipNote] = saleConfWork.SlipNote;                           // �`�[���l (string)
            dr[MAHNB02349EA.CT_Col_SlipNote2] = saleConfWork.SlipNote2;                         // �`�[���l�Q (string)
            dr[MAHNB02349EA.CT_Col_SlipNote3] = saleConfWork.SlipNote3;                         // �`�[���l�R (string)
            dr[MAHNB02349EA.CT_Col_BusinessTypeCode] = saleConfWork.BusinessTypeCode;           // �Ǝ�R�[�h (Int32)
            dr[MAHNB02349EA.CT_Col_BusinessTypeName] = saleConfWork.BusinessTypeName;           // �Ǝ햼�� (string)
            dr[MAHNB02349EA.CT_Col_SalesAreaCode] = saleConfWork.SalesAreaCode;                 // �̔��G���A�R�[�h (Int32)
            dr[MAHNB02349EA.CT_Col_SalesAreaName] = saleConfWork.SalesAreaName;                 // �̔��G���A���� (string)
            //dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // �t�n�d���}�[�N�P (string)
            //dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // �t�n�d���}�[�N�Q (string)
            dr[MAHNB02349EA.CT_Col_GoodsNo] = saleConfWork.GoodsNo;                             // ���i�ԍ� (string)
            // --- UPD  ���r��  2010/07/14 ---------->>>>>
            dr[MAHNB02349EA.CT_Col_GoodsName] = saleConfWork.GoodsName;                         // ���i���� (string)
            dr[MAHNB02349EA.CT_Col_GoodsNameKana] = saleConfWork.GoodsNameKana;                       // ���i���̃J�i (string)
            // --- UPD  ���r��  2010/07/14 ----------<<<<<
            // --- ADD  �{��  2011/07/18 ---------->>>>>
            // 0:�ʏ�(PCC�A�g�Ȃ�)
            if (saleConfWork.AutoAnswerDivSCM == 0)
            {
                dr[MAHNB02349EA.CT_AutoAnswer] = "�ʏ�";                       // �ʏ픭�s�}�[�N
            }
            // 1:�蓮��
            else if(saleConfWork.AutoAnswerDivSCM == 1)
            {
                dr[MAHNB02349EA.CT_AutoAnswer] = "�蓮��";                       // SCM�蓮�񓚃}�[�N
            }
            // 2:������
            else if (saleConfWork.AutoAnswerDivSCM == 2)
            {
                dr[MAHNB02349EA.CT_AutoAnswer] = "������";                       // SCM�����񓚃}�[�N
            }
            // --- ADD  �{��  2011/07/18 ----------<<<<<
            //dr[MAHNB02349EA.CT_Col_BLGoodsCode] = saleConfWork.BLGoodsCode;                     // BL���i�R�[�h (Int32)
            if (saleConfWork.BLGoodsCode == 0)
            {
                dr[MAHNB02349EA.CT_Col_BLGoodsCode] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_BLGoodsCode] = saleConfWork.BLGoodsCode.ToString("d05");                     // BL���i�R�[�h (Int32)
            }
            dr[MAHNB02349EA.CT_Col_BLGoodsFullName] = saleConfWork.BLGoodsFullName;             // BL���i�R�[�h���́i�S�p�j (string)
            dr[MAHNB02349EA.CT_Col_SalesOrderDivCd] = saleConfWork.SalesOrderDivCd;             // ����݌Ɏ�񂹋敪 (Int32)
            dr[MAHNB02349EA.CT_Col_ListPriceTaxIncFl] = saleConfWork.ListPriceTaxIncFl;         // �艿�i�ō��C�����j (Double)
            dr[MAHNB02349EA.CT_Col_ListPriceTaxExcFl] = saleConfWork.ListPriceTaxExcFl;         // �艿�i�Ŕ��C�����j (Double)
            dr[MAHNB02349EA.CT_Col_SalesRate] = saleConfWork.SalesRate;                         // ������ (Double)
            dr[MAHNB02349EA.CT_Col_ShipmentCnt] = saleConfWork.ShipmentCnt;                     // �o�א� (Double)
            dr[MAHNB02349EA.CT_Col_SalesUnitCost] = saleConfWork.SalesUnitCost;                 // �����P�� (Double)
            dr[MAHNB02349EA.CT_Col_SalesUnPrcTaxIncFl] = saleConfWork.SalesUnPrcTaxIncFl;       // ����P���i�ō��C�����j (Double)
            dr[MAHNB02349EA.CT_Col_SalesUnPrcTaxExcFl] = saleConfWork.SalesUnPrcTaxExcFl;       // ����P���i�Ŕ��C�����j (Double)
            dr[MAHNB02349EA.CT_Col_Cost] = saleConfWork.Cost;                                   // ���� (Int64)
            dr[MAHNB02349EA.CT_Col_SalesMoneyTaxInc] = saleConfWork.SalesMoneyTaxInc;           // ������z�i�ō��݁j (Int64)
            dr[MAHNB02349EA.CT_Col_SalesMoneyTaxExc] = saleConfWork.SalesMoneyTaxExc;           // ������z�i�Ŕ����j (Int64)
            //dr[MAHNB02349EA.CT_Col_SupplierCd] = saleConfWork.SupplierCd;                       // �d����R�[�h (Int32)
            if (saleConfWork.SupplierCd == 0)
            {
                dr[MAHNB02349EA.CT_Col_SupplierCd] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_SupplierCd] = saleConfWork.SupplierCd.ToString("d06");                       // �d����R�[�h (Int32)
            }
            dr[MAHNB02349EA.CT_Col_SupplierSnm] = saleConfWork.SupplierSnm;                     // �d���旪�� (string)
            //dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = saleConfWork.SupplierSlipNo;               // �d���`�[�ԍ� (Int32)
            // 2009.03.12 30413 ���� �d���`�[�ԍ��ɑ����`�[�ԍ���ݒ肷��悤�ɏC�� >>>>>>START
            //if (saleConfWork.SupplierSlipNo == 0)
            if (string.IsNullOrEmpty(saleConfWork.PartySaleSlipNumStock))
            {
                dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = "";
            }
            else
            {
                //dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = saleConfWork.SupplierSlipNo.ToString();               // �d���`�[�ԍ� (Int32)
                dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = saleConfWork.PartySaleSlipNumStock;                    // �����`�[�ԍ� (string)
            }
            // 2009.03.12 30413 ���� �d���`�[�ԍ��ɑ����`�[�ԍ���ݒ肷��悤�ɏC�� <<<<<<END
            dr[MAHNB02349EA.CT_Col_WarehouseCode] = saleConfWork.WarehouseCode;                 // �q�ɃR�[�h (string)
            dr[MAHNB02349EA.CT_Col_WarehouseName] = saleConfWork.WarehouseName;                 // �q�ɖ��� (string)
            dr[MAHNB02349EA.CT_Col_WarehouseShelfNo] = saleConfWork.WarehouseShelfNo;           // �q�ɒI�� (string)
            //dr[MAHNB02349EA.CT_Col_SalesCode] = saleConfWork.SalesCode;                         // �̔��敪�R�[�h (Int32)
            if (saleConfWork.SalesCode == 0)
            {
                dr[MAHNB02349EA.CT_Col_SalesCode] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_SalesCode] = saleConfWork.SalesCode.ToString("d04");                         // �̔��敪�R�[�h (Int32)
            }
            dr[MAHNB02349EA.CT_Col_SalesCdNm] = saleConfWork.SalesCdNm;                         // �̔��敪���� (string)
            dr[MAHNB02349EA.CT_Col_ModelFullName] = saleConfWork.ModelFullName;                 // �Ԏ�S�p���� (string)
            dr[MAHNB02349EA.CT_Col_FullModel] = saleConfWork.FullModel;                         // �^���i�t���^�j (string)
            dr[MAHNB02349EA.CT_Col_ModelDesignationNo] = saleConfWork.ModelDesignationNo;       // �^���w��ԍ� (Int32)
            dr[MAHNB02349EA.CT_Col_CategoryNo] = saleConfWork.CategoryNo;                       // �ޕʔԍ� (Int32)
            dr[MAHNB02349EA.CT_Col_CarMngCode] = saleConfWork.CarMngCode;                       // ���q�Ǘ��R�[�h (string)
            dr[MAHNB02349EA.CT_Col_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", saleConfWork.FirstEntryDate);               // ���N�x (string)
            dr[MAHNB02349EA.CT_Col_TransactionName] = saleConfWork.TransactionName;             // ����敪��[�`�[] (string)
            dr[MAHNB02349EA.CT_Col_GrossMarginRate] = saleConfWork.GrossMarginRate;             // �e����[�`�[] (Double)
            dr[MAHNB02349EA.CT_Col_GrossMarginMarkSlip] = saleConfWork.GrossMarginMarkSlip;     // �e���`�F�b�N�}�[�N[�`�[] (string)
            dr[MAHNB02349EA.CT_Col_GrossMarginRateDtl] = saleConfWork.GrossMarginRateDtl;       // �e����[����] (Double)
            dr[MAHNB02349EA.CT_Col_GrossMarginMarkDtl] = saleConfWork.GrossMarginMarkDtl;       // �e���`�F�b�N�}�[�N[����] (string)
            dr[MAHNB02349EA.CT_Col_SalesSlipCdDtl] = saleConfWork.SalesSlipCdDtl;               // ����`�[�敪�i���ׁj (Int32)
            dr[MAHNB02349EA.CT_Col_SalesDisTtlTaxExc] = saleConfWork.SalesDisTtlTaxExc;         // ����l�����z�v�i�Ŕ����j (Int64)
            dr[MAHNB02349EA.CT_Col_SearchSlipDate] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.SearchSlipDate);         // �`�[�������t(���͓��t)   (DateTime)

            // �`�[�^�C�v�̈󎚗p���t
            dr[MAHNB02349EA.CT_Col_SalesDateY2] = TDateTime.DateTimeToString("YY/MM/DD", saleConfWork.SalesDate);                         // ������t (DateTime)
            dr[MAHNB02349EA.CT_Col_AddUpADateY2] = TDateTime.DateTimeToString("YY/MM/DD", saleConfWork.AddUpADate);                       // �v����t (Int32)
            dr[MAHNB02349EA.CT_Col_SearchSlipDateY2] = TDateTime.DateTimeToString("YY/MM/DD", saleConfWork.SearchSlipDate);         // �`�[�������t(���͓��t)   (DateTime)


            // ����`�[�敪���̂̐ݒ�
            dr[MAHNB02349EA.CT_Col_SalesSlipName] = saleConfWork.TransactionName;       // ����敪��[�`�[]��OK�H

            dr[MAHNB02349EA.CT_COL_LOGICALDELETECODE] = saleConfWork.LogicalDeleteCode == 0 ? "" : "�폜"; // --- ADD  ����  2010/11/29
            
            // �ޕ�(����)�̐ݒ�
            if ((saleConfWork.ModelDesignationNo == 0) && (saleConfWork.CategoryNo == 0))
            {
                // �^���w��ԍ��Ɨޕʔԍ������ݒ�̏ꍇ�́A�ޕʂ͐ݒ肵�Ȃ�
                dr[MAHNB02349EA.CT_Col_CategoryDtl] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_CategoryDtl] = saleConfWork.ModelDesignationNo.ToString("d05") + "-" + saleConfWork.CategoryNo.ToString("d04");
            }

            // ����݌Ɏ�񂹋敪���̂̐ݒ�
            if (saleConfWork.SalesOrderDivCd == 0)
            {
                dr[MAHNB02349EA.CT_Col_SalesOrderDivName] = "���";
            }
            else if (saleConfWork.SalesOrderDivCd == 1)
            {
                dr[MAHNB02349EA.CT_Col_SalesOrderDivName] = "�݌�";
            }

            // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
            // �`�[�^�C�v
            long salesTax = 0;          // ����^�ԕi�̏����
            long salesTotalAll = 0;     // ����^�ԕi�̍��v���z
            long distTax = 0;           // �l���̏����
            long distTotalAll = 0;      // �l���̍��v���z
            // ���׃^�C�v
            long salesDtlTax = 0;       // ����^�ԕi�̏����
            long distDtlTax = 0;        // �l���̏����
            // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

            // 2010/06/29 Add >>>
            if (string.IsNullOrEmpty(saleConfWork.ModelHalfName))
            {
                dr[MAHNB02349EA.CT_Col_ModelHalfName] = GetKanaString(saleConfWork.ModelFullName);  // �Ԏ�S�p���̂𔼊p�ϊ�
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_ModelHalfName] = saleConfWork.ModelHalfName;                 // �Ԏ피�p���� (string)
            }
            // 2010/06/29 Add <<<

            // --- ADD  ���r��  2010/07/14 ---------->>>>>
            if (string.IsNullOrEmpty(saleConfWork.GoodsNameKana))
            {
                dr[MAHNB02349EA.CT_Col_GoodsNameKana] = saleConfWork.GoodsName;                     // ���i���̃J�i�istring�j
            }
            // --- ADD  ���r��  2010/07/14 ----------<<<<<

            // 2009.02.06 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX(����œ]�ŕ����ɑΉ�) >>>>>>START
            // �`�[�L�[
            string slipKey = saleConfWork.SectionCode.TrimEnd() + "-" + saleConfWork.CustomerCode.ToString("d08") + "-"
                           + saleConfWork.SalesSlipNum;
            // 2009.02.06 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX(����œ]�ŕ����ɑΉ�) <<<<<<END

            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            string sConTaxRate = string.Empty;
            // �ŕʓ���󎚂̏ꍇ�A
            if (_iTaxPrintDiv == 0)
            {
               sConTaxRate = Convert.ToString(saleConfWork.ConsTaxRate * 100) + "%"; // ����Őŗ�Title                        
               // ����
               // Title_�ŗ�1
               dr[MAHNB02349EA.CT_SalesConf_TaxRate1_Title] = Convert.ToString(_taxRate1 * 100) + "%";
               // Title_�ŗ�2
               dr[MAHNB02349EA.CT_SalesConf_TaxRate2_Title] = Convert.ToString(_taxRate2 * 100) + "%";
               // Title_���̑�
               dr[MAHNB02349EA.CT_SalesConf_Other_Title] = "���̑�";
               // �ԕi
               // Title_�ŗ�1
               dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnTitle] = Convert.ToString(_taxRate1 * 100) + "%";
               // Title_�ŗ�2
               dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnTitle] = Convert.ToString(_taxRate2 * 100) + "%";
               // Title_���̑�
               dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTitle] = "���̑�";
               // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
               // ����Title_��ې�
               dr[MAHNB02349EA.CT_SalesConf_TaxFree_Title] = "��ې�";
               // �ԕiTitle_��ې�
               dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnTitle] = "��ې�";
               // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
            }
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            
            // ����ł̐ݒ�
            //dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);      //DEL 2008/10/31 �����ɂ���ĕω������
            // --- ADD 2008/10/31 --------------------------------------------------------------------------------------------------------->>>>>
            // �`�[�P�ʂɏo�͎�
            if (this._printDiv == 1)
            {
                // --- ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                //�@����œ]�ŕ������`�[�P�ʁ@������s�ԍ���1�s�ڂ̏ꍇ
                if (saleConfWork.ConsTaxLayMethod == 0 &&
                    saleConfWork.TaxRateExistFlag &&
                    _iTaxPrintDiv == 0 &&
                    !CountedSlipKeyList.Contains(slipKey))
                {
                    long salesTotalTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                    //�@����`�[�敪(�`�[)���u����v�̏ꍇ�A���㐔�Ɣ��㌴�����o�͂���
                    if (saleConfWork.SalesSlipCd == 0)
                    {
                        dr[MAHNB02349EA.CT_SalesConf_SalesTax] = salesTotalTax;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCountnumberDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCountnumberDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTotalTax;
                        }
                    }
                    //�@����`�[�敪(�`�[)���u�ԕi�v�̏ꍇ�A���㐔�Ɣ��㌴�����o�͂���
                    if (saleConfWork.SalesSlipCd == 1)
                    {
                        dr[MAHNB02349EA.CT_SalesConf_ReturnTax] = salesTotalTax;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnSalesCountDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnSalesCountDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTotalTax;
                        }
                    }
                }
                // --- ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                if ((saleConfWork.ConsTaxLayMethod == 2) ||
                    (saleConfWork.ConsTaxLayMethod == 3) ||
                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // (saleConfWork.ConsTaxLayMethod == 9)
                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // �ېő��݂��Ȃ�����ېő��݂̏ꍇ
                    (saleConfWork.ConsTaxLayMethod == 9) ||
                    (saleConfWork.TaxFreeExistFlag && !saleConfWork.TaxRateExistFlag)
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    )
                {
                    // --- UPD 2022/09/29 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // �����
                    //dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalAmntConsTaxInclu + saleConfWork.SalesDisTtlTaxInclu); // DEL 2009/04/14
                    //dr[MAHNB02349EA.CT_SalesConf_Tax] = 0; // ADD 2009/04/14
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // ����Őŗ�
                        // dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                        if (saleConfWork.ConsTaxLayMethod == 0)
                        {
                            // ����Őŗ�
                            dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                        }
                        else
                        {
                            // ����Őŗ�
                            dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                        }
                        
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    // ���v���z
                    //dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc + (saleConfWork.SalAmntConsTaxInclu + saleConfWork.SalesDisTtlTaxInclu);

                    // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                    // �`�[�^�C�v�̏���łƍ��v���z���Z�o
                    //salesTax = saleConfWork.SalAmntConsTaxInclu; // DEL 2009/04/14
                    //salesTax = 0; // ADD 2009/04/14
                    //salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalAmntConsTaxInclu - saleConfWork.SalesDisTtlTaxExc;
                    if (saleConfWork.ConsTaxLayMethod == 0)
                    {
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc); 
                        salesTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc - saleConfWork.SalesDisOutTax;
                        distTax = saleConfWork.SalesDisOutTax;
                        distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisOutTax;
                        // ���v���z
                        dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc
                                                                        + (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);
                    }
                    else 
                    {
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = 0; 
                        salesTax = 0;
                        salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalAmntConsTaxInclu - saleConfWork.SalesDisTtlTaxExc;
                        distTax = 0; // DEL 2009/04/14
                        distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisTtlTaxInclu;
                        // ���v���z
                        dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc
                                                                        + (saleConfWork.SalAmntConsTaxInclu + saleConfWork.SalesDisTtlTaxInclu);
                    }

                    //distTax = saleConfWork.SalesDisTtlTaxInclu; // DEL 2009/04/14
                    //distTax = 0; // DEL 2009/04/14
                    //distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisTtlTaxInclu;
                    // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END
                    // --- UPD 2022/09/29 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                }
                // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
                else
                {
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // ����Őŗ�
                        dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    // �����
                    dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);
                    // ���v���z
                    dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc
                                                                    + (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);

                    // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                    // �`�[�^�C�v�̏���łƍ��v���z���Z�o
                    salesTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisOutTax;
                    salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc - saleConfWork.SalesDisOutTax;
                    distTax = saleConfWork.SalesDisOutTax;
                    distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisOutTax;
                    // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END
                }
            }
            // ���גP�ʂɏo�͎�
            else
            {
                // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                if ((saleConfWork.ConsTaxLayMethod == 2) ||
                    (saleConfWork.ConsTaxLayMethod == 3) ||
                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // (saleConfWork.ConsTaxLayMethod == 9)
                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    (saleConfWork.ConsTaxLayMethod == 9) ||
                    (saleConfWork.TaxationDivCd == 1))
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                {
                    // --- DEL 2009/04/14 -------------------------------->>>>>
                    //// �ېŋ敪�@2�F����
                    //if (saleConfWork.TaxationDivCd == 2)
                    //{
                    //    // �����
                    //    dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                    //}
                    //// �ېŋ敪�@0�F�ېŁA1�F��ې�
                    //else
                    //{
                    //    // �����
                    //    dr[MAHNB02349EA.CT_SalesConf_Tax] = DBNull.Value;
                    //}
                    // --- DEL 2009/04/14 --------------------------------<<<<<
                    dr[MAHNB02349EA.CT_SalesConf_Tax] = 0; // ADD 2009/04/14
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // ����Őŗ�
                        dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<

                    // --- ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // ����œ]�ŕ������`�[�P�ʁ@���@���㖾�׍s�ԍ���1�s�ڂ̏ꍇ�A����łƏ���Őŗ����o�͂���
                    if (saleConfWork.ConsTaxLayMethod == 0 && 
                        saleConfWork.TaxationDivCd == 1 &&
                        !CountedSlipKeyList.Contains(slipKey) && 
                        !CountedTaxFreeKeyList.Contains(slipKey)) 
                    {
                        // ���׍s�ԍ���1�s��
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        // ����Őŗ�
                        dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                }
                // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
                else
                {
                    // 2008.12.18 30413 ���� ���׃^�C�v�̒��[�œ`�[�]�ł̏ꍇ�A����s�ԍ���1�s�ڂ݂̂ɏ���ł�ݒ� >>>>>>START                        
                    // �����
                    //dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                    if (saleConfWork.ConsTaxLayMethod == 0)
                    {
                        // ����œ]�ŕ����@0�F�`�[�P��
                        //if (saleConfWork.SalesRowNo == 1)
                        if (!CountedSlipKeyList.Contains(slipKey))
                        {
                            // ����s�ԍ���1�s��
                            // �����
                            // dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc); DEL 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                            // --- ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                            if (!CountedTaxFreeKeyList.Contains(slipKey)) 
                            {
                                dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);
                            }
                            // --- ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

                            // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                            // ���׃^�C�v�̏���ł��Z�o
                            salesDtlTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisOutTax;
                            distDtlTax = saleConfWork.SalesDisOutTax;
                            // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� <<<<<<END
                            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                            // �ŕʓ���󎚂̏ꍇ�A
                            // if (_iTaxPrintDiv == 0 ) DEL 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                            // �ŕʓ���󎚂��ېł̏ꍇ
                            if (_iTaxPrintDiv == 0 && !CountedTaxFreeKeyList.Contains(slipKey)) // ADD 2022/09/20 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                            {
                                // ����Őŗ�
                                dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                            }
                            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                        }
                        else
                        {
                            // ��L�ȊO
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_Tax] = 0;
                            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                            // �ŕʓ���󎚂̏ꍇ�A
                            if (_iTaxPrintDiv == 0)
                            {
                                // ����Őŗ�
                                dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                            }
                            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                        }
                    }
                    else
                    {
                        // ����œ]�ŕ����@1�F���גP��
                        // �����
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ����Őŗ�
                            dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                        }
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }
                    // 2008.12.18 30413 ���� ���׃^�C�v�̒��[�œ`�[�]�ł̏ꍇ�A����s�ԍ���1�s�ڂ݂̂ɏ���ł�ݒ� <<<<<<END                        
                }
            }
            dr[MAHNB02349EA.CT_Col_ConsTaxLayMethod] = saleConfWork.ConsTaxLayMethod;       // ����œ]�ŕ���
            dr[MAHNB02349EA.CT_Col_TaxationDivCd] = saleConfWork.TaxationDivCd;             // �ېŋ敪
            // --- ADD 2008/10/31 ---------------------------------------------------------------------------------------------------------<<<<<

            // �e��(�Ŕ���)(�`�[)�̐ݒ�
            dr[MAHNB02349EA.CT_SalesConf_GrossProfit] = (saleConfWork.SalesTotalTaxExc - saleConfWork.TotalCost);

            // �e��(�Ŕ���)(����)�̐ݒ�
            dr[MAHNB02349EA.CT_SalesConf_GrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

            // ����s�ԍ�(����)
            dr[MAHNB02349EA.CT_SalesConf_SalesRowNo] = saleConfWork.SalesRowNo;

            //// 2009.02.03 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX >>>>>>START
            //// �`�[�L�[
            //string slipKey = saleConfWork.SectionCode.TrimEnd() + "-" + saleConfWork.CustomerCode.ToString("d08") + "-"
            //               + saleConfWork.SalesSlipNum;
            //// 2009.02.03 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX <<<<<<END
                
            // �v���̐ݒ�
            // ����`�[�敪(�`�[)(SalesSlipCd �� 0=����A1=�ԕi)
            if (saleConfWork.SalesSlipCd == 0)
            {
                // ����`�[���̃J�E���g(�`�[)
                dr[MAHNB02349EA.CT_SalesConf_SalesCountNumber] = 1;

                // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ�̕ύX�ɔ����C�� >>>>>>START
                long totalMeter = saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc;
                long salesCost = saleConfWork.TotalCost - saleConfWork.DisCost;

                // ���㍇�v���z
                //dr[MAHNB02349EA.CT_SalesConf_TotalMeter] = saleConfWork.SalesTotalTaxExc;
                dr[MAHNB02349EA.CT_SalesConf_TotalMeter] = totalMeter;

                // ���㍇�v����(�Ŕ���)
                //dr[MAHNB02349EA.CT_SalesConf_SalesCost] = saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_SalesCost] = salesCost;

                // ���㍇�v�e��
                //dr[MAHNB02349EA.CT_SalesConf_SalesGrossProfit] = saleConfWork.SalesTotalTaxExc - saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_SalesGrossProfit] = totalMeter - salesCost;
                // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ�̕ύX�ɔ����C�� <<<<<<END

                // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                // ���㍇�v�����(�`�[)
                dr[MAHNB02349EA.CT_SalesConf_SalesTax] = salesTax;

                // ����̏���ō����v���z(�`�[)
                dr[MAHNB02349EA.CT_SalesConf_SalesTotalAll] = salesTotalAll;
                // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

                // 2009.02.03 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX >>>>>>START
                //if (saleConfWork.SalesRowNo == 1)
                //{
                //    // ���㐔�̃J�E���g(����)
                //    dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;

                //    // ���ׂ�1�s�ڂ݈̂󎚂��鍀��
                //    //dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // ���Ӑ�`�[�ԍ� (Int32)
                //    if (saleConfWork.CustSlipNo == 0)
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                //    }
                //    else
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // ���Ӑ�`�[�ԍ� (Int32)
                //    }
                //    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // �t�n�d���}�[�N�P (string)
                //    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // �t�n�d���}�[�N�Q (string)
                //}
                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                //�@���גP�ʂɏo�͎��A��ېł�1�s�ڂ��ŕʓ���󎚂̏ꍇ�A���㐔(����)_��ېłƔ��㐔�̃J�E���g(����)���o�͂���
                if (!CountedTaxFreeKeyList.Contains(slipKey) && this._printDiv != 1 && _iTaxPrintDiv == 0 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                {
                    // ���㐔(����)_��ې�
                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCountnumberDtl] = 1;
                    if (!CountedSlipKeyList.Contains(slipKey)) {
                        // ���㐔�̃J�E���g(����)
                        dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;
                    }
                    CountedTaxFreeKeyList.Add(slipKey);
                    if (saleConfWork.ConsTaxLayMethod == 0 && saleConfWork.TaxRateExistFlag) {
                        long salesTotalTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            // ���㐔(����)_�ŗ�1
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCountnumberDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            // ���㐔(����)_�ŗ�2
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCountnumberDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            // ���㐔(����)_���̑�
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTotalTax;
                        }
                    }
                }
                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    // ���㐔�̃J�E���g(����)
                    // dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1; DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                    if (this._printDiv == 1)
                    {
                        // ���㐔�̃J�E���g(����)
                        dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;
                    }
                    else
                    {
                        // ��ېł�1�s�ڂ̏ꍇ�A���㐔�̃J�E���g(����)���o�͂���
                        if (!CountedTaxFreeKeyList.Contains(slipKey))
                        {
                            // ���㐔�̃J�E���g(����)
                            dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;
                        }
                    }
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<

                    // ���ׂ�1�s�ڂ݈̂󎚂��鍀��
                    if (saleConfWork.CustSlipNo == 0)
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                    }
                    else
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // ���Ӑ�`�[�ԍ� (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // �t�n�d���}�[�N�P (string)
                    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // �t�n�d���}�[�N�Q (string)

                    //CountedSlipKeyList.Add(slipKey);
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        // ����œ]�ŕ����@9�F��ې�
                        //if (saleConfWork.ConsTaxLayMethod == 9) 
                        //{
                        //    // ���㐔(����)_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1;
                        //    // �`�[�P��
                        //    if (this._printDiv == 1)
                        //    {
                        //        // ���㍇�v���z_���̑�
                        //        dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = totalMeter;
                        //        // ���㍇�v�����_���̑�
                        //        dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTax;
                        //        // ����̏���ō����v���z_���̑�
                        //        dr[MAHNB02349EA.CT_SalesConf_Other_SalesTotalAll] = salesTotalAll;
                        //    }
                        //}
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        //�@�`�[�P�ʂɏo�͎��A��ېő��݂��邩�ېő��݂���̏ꍇ
                        if (this._printDiv == 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxFreeExistFlag) && saleConfWork.TaxRateExistFlag)
                        {
                            // ���㐔(����)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCountnumberDtl] = 1;
                            // �`�[�P��
                            if (this._printDiv == 1)
                            {
                                // ���㍇�v���z_��ې�
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;
                                // ���㍇�v�����_��ې�
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtlTax] = 0;
                                // ����̏���ō����v���z_��ې�
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                            }
                        }

                        //�@�`�[�P�ʂɏo�͎��A��ېő��݂��邩�ېő��݂��Ȃ��̏ꍇ�@
                        if (this._printDiv == 1 && (saleConfWork.TaxFreeExistFlag || saleConfWork.ConsTaxLayMethod == 9) && !saleConfWork.TaxRateExistFlag)
                        {
                            // ���㐔(����)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCountnumberDtl] = 1;
                            // �`�[�P��
                            if (this._printDiv == 1)
                            {
                                // ���㍇�v���z_��ې�
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;
                                // ���㍇�v�����_��ې�
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtlTax] = 0;
                                // ����̏���ō����v���z_��ې�
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                            }
                        }
                        //�@���גP�ʂɏo�͎��A��ېł̏ꍇ
                        else if (this._printDiv != 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                        {
                            
                        }
                        //--- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        else
                        {
                            // �ŗ�2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // ���㐔(����)_�ŗ�2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCountnumberDtl] = 1;
                                
                                // �`�[�P��
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ���㍇�v���z_�ŗ�2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = totalMeter
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ���㍇�v���z_�ŗ�2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // ���㍇�v�����_�ŗ�2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ����̏���ō����v���z_�ŗ�2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ����̏���ō����v���z_�ŗ�2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                }
                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // ���㐔(����)_�ŗ�1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCountnumberDtl] = 1; 
                                // �`�[�P��
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ���㍇�v���z_�ŗ�1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = totalMeter
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ���㍇�v���z_�ŗ�1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // ���㍇�v�����_�ŗ�1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ����̏���ō����v���z_�ŗ�1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ����̏���ō����v���z_�ŗ�1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                }
                            }
                            else
                            {
                                // ���㐔(����)_���̑�
                                dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1; 
                                
                                // �`�[�P��
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ���㍇�v���z_���̑�
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ���㍇�v���z_���̑�
                                    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // ���㍇�v�����_���̑�
                                    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ����̏���ō����v���z_���̑�
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_SalesTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // ����̏���ō����v���z_���̑�
                                    dr[MAHNB02349EA.CT_SalesConf_Other_SalesTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                }

                            }
                        }
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                }
                // 2009.02.03 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX <<<<<<END
            }
            else if (saleConfWork.SalesSlipCd == 1)
            {
                // �ԕi�`�[���̃J�E���g(�`�[)
                dr[MAHNB02349EA.CT_SalesConf_ReturnCountNumber] = 1;

                // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ�̕ύX�ɔ����C�� >>>>>>START
                long returnSalesMoney = saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc;
                long salesReturnCost = saleConfWork.TotalCost - saleConfWork.DisCost;
                
                // �ԕi���v���z(�Ŕ���)
                //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoney] = saleConfWork.SalesTotalTaxExc;
                dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoney] = returnSalesMoney;

                // �ԕi���v����(�Ŕ���)
                //dr[MAHNB02349EA.CT_SalesConf_SalesReturnCost] = saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_SalesReturnCost] = salesReturnCost;

                // �ԕi���v�e��
                //dr[MAHNB02349EA.CT_SalesConf_ReturnGrossProfit] = saleConfWork.SalesTotalTaxExc - saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_ReturnGrossProfit] = returnSalesMoney - salesReturnCost;

                // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                // �ԕi���v�����(�`�[)
                dr[MAHNB02349EA.CT_SalesConf_ReturnTax] = salesTax;

                // ����̏���ō����v���z(�`�[)
                dr[MAHNB02349EA.CT_SalesConf_ReturnTotalAll] = salesTotalAll;
                // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END
                    
                if (saleConfWork.SalesRowNo == 0)
                {
                    // �`�[�^�C�v�̏ꍇ�́A����s�ԍ����[��
                    if (saleConfWork.RetGoodsReasonDiv != 0)
                    {
                        // �ԕi���R�R�[�h��0�ȊO�̏ꍇ�́A�R�[�h���Z�b�g
                        dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv.ToString("d04");  // �ԕi���R�R�[�h (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // �ԕi���R (string)
                    
                }
                // 2009.02.03 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX >>>>>>START
                //else if (saleConfWork.SalesRowNo == 1)
                //{
                //    // �ԕi���̃J�E���g(����)
                //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;

                //    // ���ׂ�1�s�ڂ݈̂󎚂��鍀��
                //    if (saleConfWork.RetGoodsReasonDiv != 0)
                //    {
                //        // �ԕi���R�R�[�h��0�ȊO�̏ꍇ�́A�R�[�h���Z�b�g
                //        dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv.ToString();  // �ԕi���R�R�[�h (Int32)
                //    }
                //    dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // �ԕi���R (string)
                //    //dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // ���Ӑ�`�[�ԍ� (Int32)
                //    if (saleConfWork.CustSlipNo == 0)
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                //    }
                //    else
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // ���Ӑ�`�[�ԍ� (Int32)
                //    }
                //    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // �t�n�d���}�[�N�P (string)
                //    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // �t�n�d���}�[�N�Q (string)
                //}
                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                //�@���גP�ʂɏo�͎��A��ېł�1�s�ڂ��ŕʓ���󎚂̏ꍇ�A�ԕi��(����)_��ېłƕԕi���̃J�E���g(����)���o�͂���
                if (!CountedTaxFreeKeyList.Contains(slipKey) && this._printDiv != 1 && _iTaxPrintDiv == 0 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                {
                    // �ԕi��(����)_��ې�
                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnSalesCountDtl] = 1;
                    if (!CountedSlipKeyList.Contains(slipKey))
                    {
                        // �ԕi���̃J�E���g(����)
                        dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;
                    }
                    CountedTaxFreeKeyList.Add(slipKey);
                    if (saleConfWork.ConsTaxLayMethod == 0 && saleConfWork.TaxRateExistFlag)
                    {
                        long salesTotalTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            // �ԕi��(����)_�ŗ�1
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnSalesCountDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            // �ԕi��(����)_�ŗ�2
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnSalesCountDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            // �ԕi��(����)_���̑�
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1;
                            // �����
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTotalTax;
                        }
                    }
                }
                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    // �ԕi���̃J�E���g(����)
                    // dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1; DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                    if (this._printDiv == 1)
                    {
                        // �ԕi���̃J�E���g(����)
                        dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;
                    }
                    else {
                        // ��ېł�1�s�ڂ̏ꍇ�A���㐔�̃J�E���g(����)���o�͂���
                        if (!CountedTaxFreeKeyList.Contains(slipKey)) 
                        {
                            // �ԕi���̃J�E���g(����)
                            dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;
                        }
                    }
                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<

                    // ���ׂ�1�s�ڂ݈̂󎚂��鍀��
                    if (saleConfWork.RetGoodsReasonDiv != 0)
                    {
                        // �ԕi���R�R�[�h��0�ȊO�̏ꍇ�́A�R�[�h���Z�b�g
                        dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv.ToString();  // �ԕi���R�R�[�h (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // �ԕi���R (string)
                    if (saleConfWork.CustSlipNo == 0)
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                    }
                    else
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // ���Ӑ�`�[�ԍ� (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // �t�n�d���}�[�N�P (string)
                    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // �t�n�d���}�[�N�Q (string)

                    //CountedSlipKeyList.Add(slipKey);
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �ŕʓ���󎚂̏ꍇ�A
                    if (_iTaxPrintDiv == 0)
                    {
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        // ����œ]�ŕ����@9�F��ې�
                        //if (saleConfWork.ConsTaxLayMethod == 9)
                        //{ 
                        //// �ԕi��(����)_���̑�
                        //dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1;

                        //// �`�[�P��
                        //if (this._printDiv == 1)
                        //{
                        //    // �ԕi���v���z_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = returnSalesMoney;

                        //    // �ԕi���v�����_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTax;

                        //    // �ԕi�̏���ō����v���z(����)_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTotalAll] = salesTotalAll;
                        //}
                        //}
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        //�@�`�[�P�ʂɏo�͎��A��ېő��݂��邩�ېő��݂���̏ꍇ
                        if (this._printDiv == 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxFreeExistFlag) && saleConfWork.TaxRateExistFlag)
                        {
                            // �ԕi��(����)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnSalesCountDtl] = 1;
                             // �ԕi���v���z_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;

                            // �ԕi���v�����_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtlTax] = 0;

                            // �ԕi�̏���ō����v���z(����)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                        }
                        //�@�`�[�P�ʂɏo�͎��A��ېő��݂��邩�ېő��݂��Ȃ��̏ꍇ
                        if (this._printDiv == 1 && (saleConfWork.TaxFreeExistFlag || saleConfWork.ConsTaxLayMethod == 9) && !saleConfWork.TaxRateExistFlag)
                        {
                            // �ԕi��(����)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnSalesCountDtl] = 1;

                            // �ԕi���v���z_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;

                            // �ԕi���v�����_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtlTax] = 0;

                            // �ԕi�̏���ō����v���z(����)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                        }
                        //�@���גP�ʂɏo�͎��A��ېł̏ꍇ
                        else if (this._printDiv != 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                        {
                            
                        }
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        else
                        {
                            // �ŗ�2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // �ԕi��(����)_�ŗ�2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnSalesCountDtl] = 1; 

                                // �`�[�P��
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_�ŗ�2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = returnSalesMoney
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_�ŗ�2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = returnSalesMoney - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

                                    // �ԕi���v�����_�ŗ�2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_�ŗ�2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi�̏���ō����v���z(����)_�ŗ�2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

                                }
                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // �ԕi��(����)_�ŗ�1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnSalesCountDtl] = 1; 
                                // �`�[�P��
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_�ŗ�1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = returnSalesMoney
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_�ŗ�1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = returnSalesMoney - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

                                    // �ԕi���v�����_�ŗ�1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtlTax] = salesTax;

                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi�̏���ō����v���z(����)_�ŗ�1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi�̏���ō����v���z(����)_�ŗ�1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                }
                            }
                            else
                            {
                                // �ԕi��(����)_���̑�
                                dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1; 
                               
                                // �`�[�P��
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_���̑�
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = returnSalesMoney
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi���v���z_���̑�
                                    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = returnSalesMoney - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

                                    // �ԕi���v�����_���̑�
                                    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTax;

                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi�̏���ō����v���z(����)_���̑�
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                    // �ԕi�̏���ō����v���z(����)_���̑�
                                    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                }

                            }
                        }
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                }
                // 2009.02.03 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX <<<<<<END
            }

            // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ��ύX >>>>>>START
            // �l�����̐ݒ�(�`�[)
            // �l�������v���z(�Ŕ���)(�`�[)
            dr[MAHNB02349EA.CT_SalesConf_DistSalesMoney] = saleConfWork.SalesDisTtlTaxExc;

            // �l�������v�������z(�`�[)
            dr[MAHNB02349EA.CT_SalesConf_DistCost] = saleConfWork.DisCost;

            // �l�������v�e��(�`�[)
            dr[MAHNB02349EA.CT_SalesConf_DistGrossProfit] = saleConfWork.SalesDisTtlTaxExc - saleConfWork.DisCost;
            // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ��ύX <<<<<<END

            // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
            // �l�������v�����(�`�[)
            dr[MAHNB02349EA.CT_SalesConf_DistTax] = distTax;

            // �l�����̏���ō����v���z(�`�[)
            dr[MAHNB02349EA.CT_SalesConf_DistTotalAll] = distTotalAll;
            // 2009.01.21 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

            
            // ����`�[�敪(����)(SalesSlipCdDtl �� 0=����A1=�ԕi�A2=�l��)
            if (saleConfWork.SalesSlipCdDtl == 0)
            {
                // ���㐔�̃J�E���g(����)
                //dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;

                // ���㍇�v���z(����)
                dr[MAHNB02349EA.CT_SalesConf_SalesDtl] = (saleConfWork.SalesMoneyTaxExc);

                // ���㍇�v����(�Ŕ���)(����)
                dr[MAHNB02349EA.CT_SalesConf_SalesCostDtl] = (saleConfWork.Cost);

                // ���㍇�v�e��(����)
                dr[MAHNB02349EA.CT_SalesConf_SalesGrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

                // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                // ���㍇�v�����(����)
                //if ((saleConfWork.ConsTaxLayMethod == 0) && (saleConfWork.SalesRowNo == 1))
                if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                    dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = salesDtlTax;
                    // �l�������v�����(����)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                }
                else
                {
                    // ��L�ȊO
                    dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                }
                // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� <<<<<<END
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ���גP��
                    if (this._printDiv != 1)
                    {
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        // ����œ]�ŕ����@9�F��ې�
                        //if (saleConfWork.ConsTaxLayMethod == 9) {
                        //    // ���㍇�v���z_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                        //    // ���㌴��(�Ŕ���)_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesCostDtl] = saleConfWork.Cost;
                        //}
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        // ����œ]�ŕ����@9�F��ېŁ@���́@�ېŋ敪�@1�F��ې�
                        if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                        {
                            // ���㍇�v���z_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                            // ���㌴��(�Ŕ���)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCostDtl] = saleConfWork.Cost;
                        }
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        else
                        {
                            // �ŗ�2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // ���㍇�v���z_�ŗ�2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                // ���㌴��(�Ŕ���)_�ŗ�2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCostDtl] = saleConfWork.Cost;
                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // ���㍇�v���z_�ŗ�1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                // ���㌴��(�Ŕ���)_�ŗ�1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCostDtl] = saleConfWork.Cost;
                            }
                            else
                            {
                                // ���㍇�v���z_���̑�
                                dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                // ���㌴��(�Ŕ���)_���̑�
                                dr[MAHNB02349EA.CT_SalesConf_Other_SalesCostDtl] = saleConfWork.Cost;
                            }
                        }
                    }
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            }
            else if (saleConfWork.SalesSlipCdDtl == 1)
            {
                // �ԕi���v���z(����)
                dr[MAHNB02349EA.CT_SalesConf_ReturnDtl] = (saleConfWork.SalesMoneyTaxExc);

                // �ԕi���v����(�Ŕ���)(����)
                dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtl] = (saleConfWork.Cost);

                // �ԕi���v�e��(����)
                dr[MAHNB02349EA.CT_SalesConf_ReturnGrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

                // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                // �ԕi���v�����(����)
                //if ((saleConfWork.ConsTaxLayMethod == 0) && (saleConfWork.SalesRowNo == 1))
                if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                    dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = salesDtlTax;
                    // �l�������v�����(����)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                }
                else
                {
                    // ��L�ȊO
                    dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                }
                // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� <<<<<<END
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                // �ŕʓ���󎚂̏ꍇ�A
                if (_iTaxPrintDiv == 0)
                {
                    // ���גP��
                    if (this._printDiv != 1)
                    {
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        //// ����œ]�ŕ����@9�F��ې�
                        //if (saleConfWork.ConsTaxLayMethod == 9) 
                        //{
                        //    // �ԕi���v���z_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                        //    // �ԕi����(�Ŕ���)_���̑�
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnCostDtl] = saleConfWork.Cost;
                        //}
                        // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                        // ����œ]�ŕ����@9�F��ېŁ@���́@�ېŋ敪�@1�F��ې�
                        if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                        {
                            // �ԕi���v���z_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                            // �ԕi����(�Ŕ���)_��ې�
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnCostDtl] = saleConfWork.Cost;
                        }
                        // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                        else
                        {
                            // �ŗ�2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // �ԕi���v���z_�ŗ�2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                // �ԕi����(�Ŕ���)_�ŗ�2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnCostDtl] = saleConfWork.Cost;

                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // �ԕi���v���z_�ŗ�1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                // �ԕi����(�Ŕ���)_�ŗ�1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnCostDtl] = saleConfWork.Cost;

                            }
                            else
                            {
                                // �ԕi���v���z_���̑�
                                dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                // �ԕi����(�Ŕ���)_���̑�
                                dr[MAHNB02349EA.CT_SalesConf_Other_ReturnCostDtl] = saleConfWork.Cost;
                            }
                        }
                    }
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
            }
            else if (saleConfWork.SalesSlipCdDtl == 2)
            {
                // 2009.03.13 30413 ���� �s�l�����̈�����ύX >>>>>>START
                // �s�l�����͔���^�ԕi�Ƃ��Ĉ���
                if (saleConfWork.ShipmentCnt == 0.0)
                {
                    // �s�l��
                    if (saleConfWork.SalesSlipCd == 0)
                    {
                        // ����Ɍv��
                        // ���㍇�v���z(����)
                        dr[MAHNB02349EA.CT_SalesConf_SalesDtl] = (saleConfWork.SalesMoneyTaxExc);
                        // ���㍇�v�����(����)
                        if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                            dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = salesDtlTax;
                            // �l�������v�����(����)
                            dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // ��L�ȊO
                            dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                        }
                        // --- ADD END 3H ���� 2020/02/27 ----->>>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ���גP��
                            if (this._printDiv != 1)
                            {
                                // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                                //// ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                                //if (saleConfWork.ConsTaxLayMethod == 9)
                                //{
                                //    // ���㍇�v���z_���̑�
                                //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                //}
                                // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                                // ����œ]�ŕ����@9�F��ېŁ@���́@�ېŋ敪�@1�F��ې�
                                if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                                {
                                    // ���㍇�v���z_��ې�
                                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                }
                                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                                else
                                {
                                    // �ŗ�2
                                    if (saleConfWork.ConsTaxRate == _taxRate2)
                                    {
                                        // ���㍇�v���z_�ŗ�2
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                    else if (saleConfWork.ConsTaxRate == _taxRate1)
                                    {
                                        // ���㍇�v���z_�ŗ�1
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                    else
                                    {
                                        // ���㍇�v���z_���̑�
                                        dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                }
                            }
                        }
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

                    }
                    else if (saleConfWork.SalesSlipCd == 1)
                    {
                        // �ԕi�Ɍv��
                        // �ԕi���v���z(����)
                        dr[MAHNB02349EA.CT_SalesConf_ReturnDtl] = (saleConfWork.SalesMoneyTaxExc);
                        // �ԕi���v�����(����)
                        if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                            dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = salesDtlTax;
                            // �l�������v�����(����)
                            dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // ��L�ȊO
                            dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                        }
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // �ŕʓ���󎚂̏ꍇ�A
                        if (_iTaxPrintDiv == 0)
                        {
                            // ���גP��
                            if (this._printDiv != 1)
                            {
                                // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                                //// ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                                //if (saleConfWork.ConsTaxLayMethod == 9)
                                //{
                                //    // �ԕi���v���z_���̑�
                                //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                //}
                                // --- DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
                                // ����œ]�ŕ����@9�F��ېŁ@���́@�ېŋ敪�@1�F��ې�
                                if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                                {
                                    // �ԕi���v���z_��ې�
                                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                }
                                // --- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
                                else
                                {
                                    // �ŗ�2
                                    if (saleConfWork.ConsTaxRate == _taxRate2)
                                    {
                                        // �ԕi���v���z_�ŗ�2
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;

                                    }
                                    else if (saleConfWork.ConsTaxRate == _taxRate1)
                                    {
                                        // �ԕi���v���z_�ŗ�1
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;

                                    }
                                    else
                                    {
                                        // �ԕi���v���z_���̑�
                                        dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                }
                            }
                        }
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
          
                    }
                }
                else
                {
                    // �l�������v���z(����)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtl] = (saleConfWork.SalesMoneyTaxExc);

                    // �l�������v�������z(�Ŕ���)(����)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtlCost] = (saleConfWork.Cost);

                    // �l�������v�e��(����)
                    dr[MAHNB02349EA.CT_SalesConf_DistGrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

                    // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                    // �l�������v�����(����)
                    //if ((saleConfWork.ConsTaxLayMethod == 0) && (saleConfWork.SalesRowNo == 1))
                    if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                        dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                        if (saleConfWork.SalesSlipCd == 0)
                        {
                            // ����`�[�敪��"0:����"
                            dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = salesDtlTax;
                        }
                        else if (saleConfWork.SalesSlipCd == 1)
                        {
                            // ����`�[�敪��"1:�ԕi"
                            dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = salesDtlTax;
                        }
                    }
                    else
                    {
                        // ��L�ȊO
                        dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                    }
                    // 2009.01.21 30413 ���� ���v���̏���ł�ǉ� <<<<<<END
                    // 2009.03.13 30413 ���� �s�l�����̈�����ύX <<<<<<END
                }
                // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ��ύX >>>>>>START
                //// �l�����̐ݒ�(�`�[)
                //// �l�������v���z(�Ŕ���)(�`�[)
                //dr[MAHNB02349EA.CT_SalesConf_DistSalesMoney] = (saleConfWork.SalesDisTtlTaxExc);

                //// �l�������v�������z(�`�[)
                //dr[MAHNB02349EA.CT_SalesConf_DistCost] = (saleConfWork.TotalCost);

                //// �l�������v�e��(�`�[)
                //dr[MAHNB02349EA.CT_SalesConf_DistGrossProfit] = (saleConfWork.SalesDisTtlTaxExc - saleConfWork.Cost);
                // 2009.01.15 30413 ���� �`�[�^�C�v�̒l���ݒ��ύX <<<<<<END
            }
            
            // 2008.07.08 30413 ���� Row���ڂ̑S�u������ <<<<<<END

            // 2009.02.06 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX(����œ]�ŕ����ɑΉ�) >>>>>>START
            // if (!CountedSlipKeyList.Contains(slipKey))  DEL 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
            //�@�ېł�1�s�ڏꍇ�A�J�E���g�ς݂̓`�[�L�[���X�g�ɓ`�[�L�[��ǉ�����
            if (!CountedSlipKeyList.Contains(slipKey) && !(_iTaxPrintDiv == 0 && this._printDiv != 1 && saleConfWork.TaxationDivCd == 1)) // ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
            {
                CountedSlipKeyList.Add(slipKey);
            }
            // 2009.02.06 30413 ���� ���׃^�C�v�̓`�[�����J�E���g������ύX(����œ]�ŕ����ɑΉ�) <<<<<<END
            
            // 2008.07.08 30413 ���� Row���ڂ̑S�u�������̂��ߊ������ڂ̓R�����g�� >>>>>>START
            //dr[MAHNB02349EA.CT_SalesConf_SectionCodeRF]          = saleConfWork.SectionCode;          // ���_�R�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SectionGuideNmRF]       = saleConfWork.SectionGuideNm;       // ���_�K�C�h����     (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesDateRF]            = TDateTime.DateTimeToLongDate(saleConfWork.SalesDate);            // ������t           (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_ShipmentDayRF]          = TDateTime.DateTimeToLongDate(saleConfWork.ShipmentDay);          // �o�ד��t           (Int32)   
            //dr[MAHNB02349EA.CT_SalesConf_SalesDateRF]            = saleConfWork.SalesDate;            // ������t           (DateTime)     
            //dr[MAHNB02349EA.CT_SalesConf_ShipmentDayRF]          = saleConfWork.ShipmentDay;          // �o�ד��t           (DateTime)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerCodeRF]         = saleConfWork.CustomerCode;         // ���Ӑ�R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerSnmRF]          = saleConfWork.CustomerSnm;          // ���Ӑ旪��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdRF]          = saleConfWork.SalesSlipCd;                           // ����`�[�敪       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmRF]          = this.GetSalesSlipNm(saleConfWork.SalesSlipCd);      // ����`�[�敪�� (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF]     = saleConfWork.SalesTotalTaxExc;     // ������z(�Ŕ�) (�`�[) (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF]     = saleConfWork.SalesMoneyTaxExc;     // ������z�i�Ŕ��j(����) (Int64)

            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxIncRF]     = saleConfWork.SalesMoneyTaxInc;     // ������z(�ō�) (����) (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesGoodsCdRF]         = saleConfWork.SalesGoodsCd;         // ���i�敪�R�[�h(Int64)            
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNumRF]         = saleConfWork.SalesSlipNum;         // ����`�[�ԍ�       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesRowNoRF]           = saleConfWork.SalesRowNo;           // ����s�ԍ�         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeCdRF]      = saleConfWork.SalesEmployeeCd;      // �̔��]�ƈ��R�[�h   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeNmRF]      = saleConfWork.SalesEmployeeNm;      // �̔��]�ƈ�����     (string)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivRF]         = saleConfWork.DebitNoteDiv;         // �ԓ`�敪           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivNmRF]       = this.GetDebitNoteDivNm(saleConfWork.DebitNoteDiv);   // �ԓ`�敪�� (string)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivCdRF]          = saleConfWork.AccRecDivCd;                            // ���|�敪   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivNmRF]          = this.GetAccRecDivNm(saleConfWork.AccRecDivCd);       // ���|�敪�� (string)

            //// �� 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////
            
            //dr[MAHNB02349EA.CT_SalesConf_SearchSlipDateRF]       = saleConfWork.SearchSlipDate;       // ���͓��t           (DateTime)
            //dr[MAHNB02349EA.CT_SalesConf_AddUpADateRF]           = saleConfWork.AddUpADate;           // �v���(������)     (DateTime)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaCodeRF]        = saleConfWork.SalesAreaCode;        // �̔��G���A�R�[�h   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaNameRF]        = saleConfWork.SalesAreaName;        // �̔��G���A����     (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNoRF]              = saleConfWork.GoodsNo;              // ���i�ԍ�           (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = saleConfWork.GoodsName;            // ���i����           (string)
            //dr[MAHNB02349EA.CT_SalesConf_UnitCodeRF]             = saleConfWork.UnitCode;             // �P�ʃR�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_UnitNameRF]             = saleConfWork.UnitName;             // �P�ʖ���           (string)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionCodeRF]       = saleConfWork.SubSectionCode;       // ����R�[�h         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionNameRF]       = saleConfWork.SubSectionName;       // ���喼��           (string)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionCodeRF]       = saleConfWork.MinSectionCode;       // �ۃR�[�h           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionNameRF]       = saleConfWork.MinSectionName;       // �ۖ���             (string)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimCodeRF]            = saleConfWork.ClaimCode;            // ������R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimSnmRF]             = saleConfWork.ClaimSnm;             // �����於��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeCodeRF]        = saleConfWork.AddresseeCode;        // �[�i��R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeNameRF]        = saleConfWork.AddresseeName;        // �[�i�於��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeName2RF]       = saleConfWork.AddresseeName2;       // �[�i�於��2        (string)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeCdRF]      = saleConfWork.FrontEmployeeCd;      // ��t�]�ƈ��R�[�h   (string)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeNmRF]      = saleConfWork.FrontEmployeeNm;      // ��t�]�ƈ�����     (string)
            //dr[MAHNB02349EA.CT_SalesConf_AcptAnOdrStatusRF]      = saleConfWork.AcptAnOdrStatus;      // �󒍃X�e�[�^�X     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_PartySaleSlipNumRF]     = saleConfWork.PartySaleSlipNum;     // �����`�[�ԍ�     (string)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkSlip]    = saleConfWork.GrossMarginMarkSlip;  // �e���`�F�b�N�}�[�N(�`�[) (string)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkDtl]     = saleConfWork.GrossMarginMarkDtl;   // �e���`�F�b�N�}�[�N(����) (string)
            //dr[MAHNB02349EA.CT_SalesConf_TotalCostRF]            = saleConfWork.TotalCost;            // �������z�v         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SlipNoteRF]             = saleConfWork.SlipNote;             // �`�[���l           (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdDtlRF]       = saleConfWork.SalesSlipCdDtl;       // ����`�[�敪(����) (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmDtlRF]       = this.GetSalesSlipNmDtl(saleConfWork.SalesSlipCdDtl); //����`�[�敪����(����) (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsMakerCdRF]         = saleConfWork.GoodsMakerCd;         // ���i���[�J�[�R�[�h (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MakerNameRF]            = saleConfWork.MakerName;            // ���[�J�[����       (string)
            //dr[MAHNB02349EA.CT_SalesConf_StdUnPrcSalUnPrcRF]     = saleConfWork.StdUnPrcSalUnPrc;     // ��P��(����P��) (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxIncFlRF]   = saleConfWork.SalesUnPrcTaxIncFl;   // ����P��(�ō�)     (double)
            
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnitCostRF]        = saleConfWork.SalesUnitCost;        // �����P��           (double)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierCdRF]           = saleConfWork.SupplierCd;           // �d����R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierSnmRF]          = saleConfWork.SupplierSnm;          // �d���旪��(����)        (string)   
            //dr[MAHNB02349EA.CT_SalesConf_PartySlipNumDtlRF]      = saleConfWork.PartySlipNumDtl;      // �����`�[�ԍ�(����) (string)
            //dr[MAHNB02349EA.CT_SalesConf_DtlNoteRF]              = saleConfWork.DtlNote;              // ���ה��l           (string)
            //dr[MAHNB02349EA.CT_SalesConf_DelayPaymentDivRF]      = saleConfWork.DelayPaymentDiv;      // �����敪           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxExcRF]    = saleConfWork.SalesDisTtlTaxExc;    // ����l�����z�v(�Ŕ�)(�`�[)  (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxIncluRF]  = saleConfWork.SalesDisTtlTaxInclu - saleConfWork.SalesDisTtlTaxExc;  // ����l�����z�v(�ō�)(�`�[) (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRate]        = saleConfWork.GrossMarginRate;      // �e����(�`�[)       (double)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRateDtl]     = saleConfWork.GrossMarginRateDtl;   // �e����(����)       (double)
            //dr[MAHNB02349EA.CT_SalesConf_TransactionNameRF]      = saleConfWork.TransactionName;      // ����敪��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputCodeRF]       = saleConfWork.SalesInputCode;       // ���͎҃R�[�h       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputNameRF]       = saleConfWork.SalesInputName;       // ���͎Җ���         (string)
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseCodeRF]        = saleConfWork.WarehouseCode;        // �q�ɃR�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseNameRF]        = saleConfWork.WarehouseName;        // �q�ɖ���           (string)

            //// ���ύX�\�肠��////////////////////////////////////////////////////////
            //// �[�i��Z���̓Ǎ���(�X�֔ԍ��A�s���{���s��S�E�����E���A���ځA�Ԓn�A�A�p�[�g����)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeAddrRF] = saleConfWork.AddresseePostNo.Trim() + saleConfWork.AddresseeAddr1.Trim()
            //                                                + saleConfWork.AddresseeAddr3.Trim() + saleConfWork.AddresseeAddr4.Trim();
            //// ���ύX�\�肠��////////////////////////////////////////////////////////


            //// �� 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////

            //// �� 2008.03.24 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////

            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxIncRF]  = saleConfWork.SalesSubtotalTaxInc;   // ���㏬�v(�Ŕ���)         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxExcRF]  = saleConfWork.SalesSubtotalTaxExc;   // ���㏬�v(�ō���)         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalseNetPriceRF]        = saleConfWork.SalseNetPrice;         // ���㐳�����z             (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF]     = saleConfWork.SalesSubtotalTaxExc;   // ���㏬�v�i�Łj           (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesOutTaxRF]     = saleConfWork.ItdedSalesOutTax;      // ����O�őΏۊz           (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesInTaxRF]      = saleConfWork.ItdedSalesInTax;       // ������őΏۊz           (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalSubttlSubToTaxFreRF] = saleConfWork.SalSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz     (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalseOutTaxRF]          = saleConfWork.SalseOutTax;           // ������z����Ŋz�i�O�Łj (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalAmntConsTaxIncluRF]  = saleConfWork.SalAmntConsTaxInclu;   // ������z����Ŋz�i���Łj (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisOutTaxRF]  = saleConfWork.ItdedSalesDisOutTax;   // ����l���O�őΏۊz���v   (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisInTaxRF]   = saleConfWork.ItdedSalesDisInTax;    // ����l�����őΏۊz���v   (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalseDisTaxFreRF]  = saleConfWork.ItdedSalseDisTaxFre;   // ����l����ېőΏۊz���v (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisOutTaxRF]       = saleConfWork.SalesDisOutTax;        // ����l������Ŋz�i�O�Łj (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_SalsePriceConsTaxRF]    = saleConfWork.SalsePriceConsTax;     // ������z����Ŋz         (Int64)

            //// �� 2008.03.24 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////


            //// �� 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////////////////////////////////
            ////dr[MAHNB02349EA.CT_SalesConf_GoodsCodeRF]            = saleConfWork.GoodsCode;            // ���i�R�[�h         (string)
            ////dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = saleConfWork.GoodsName;            // ���i����           (string)
            //// �� 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////////////////////////////////

            //// �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////
            ////dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF]     = saleConfWork.SalesSubtotalTax;     // ���㏬�v(��)       (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_CustomerName2RF]        = saleConfWork.CustomerName2;        // ���Ӑ於��2        (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesFormCodeRF]        = saleConfWork.SalesFormCode;        // �̔��`�ԃR�[�h     (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesFormNameRF]        = saleConfWork.SalesFormName;        // �̔��`�Ԗ���       (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesSlipExpNumRF]      = saleConfWork.SalesSlipExpNum;      // ����ڍהԍ�       (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_CarrierCodeRF]          = saleConfWork.CarrierCode;          // �L�����A�R�[�h     (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_CarrierNameRF]          = saleConfWork.CarrierName;          // �L�����A����       (string)
            ////dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreCodeRF]  = saleConfWork.LargeGoodsGanreCode;  // ���i�啪�ރR�[�h   (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreNameRF]  = saleConfWork.LargeGoodsGanreName;  // ���i�啪�ޖ���     (string)
            ////dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreCodeRF] = saleConfWork.MediumGoodsGanreCode; // ���i�����ރR�[�h   (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreNameRF] = saleConfWork.MediumGoodsGanreName; // ���i�����ޖ���     (string)
            ////dr[MAHNB02349EA.CT_SalesConf_CellphoneModelCodeRF]   = saleConfWork.CellphoneModelCode;   // �@��R�[�h         (string)
            ////dr[MAHNB02349EA.CT_SalesConf_CellphoneModelNameRF]   = saleConfWork.CellphoneModelName;   // �@�햼��           (string)
            ////dr[MAHNB02349EA.CT_SalesConf_ProductNumber1RF]       = saleConfWork.ProductNumber1;       // �����ԍ�1          (string)
            ////dr[MAHNB02349EA.CT_SalesConf_ProductNumber2RF]       = saleConfWork.ProductNumber2;       // �����ԍ�2          (string)
            ////dr[MAHNB02349EA.CT_SalesConf_StockTelNo1RF]          = saleConfWork.StockTelNo1;          // ���i�d�b�ԍ�1      (string)
            ////dr[MAHNB02349EA.CT_SalesConf_StockTelNo2RF]          = saleConfWork.StockTelNo2;          // ���i�d�b�ԍ�2      (string)
            //// �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////

            //// �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////
            ////if ((saleConfWork.SalesSlipExpNum == 0) ||
            ////    (saleConfWork.SalesSlipExpNum == 1))
            ////{
            ////// ���גP�ʏo�͂̏ꍇ�A�������͏ڍגP�ʏo�͂̈�s�ڂ̏ꍇ�̂ݏo��

            //    dr[MAHNB02349EA.CT_SalesConf_ShipmentCntRF]          = saleConfWork.ShipmentCnt;          // ���㐔             (double)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxExcFlRF]   = saleConfWork.SalesUnPrcTaxExcFl;   // ����P���i�Ŕ����j (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_CostRF]                 = saleConfWork.Cost;                 // ����               (Int64)

 
            //    //dr[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF]        = saleConfWork.IncentiveDtbt;        // �x���C���Z���e�B�u�z(Int64)
            //    //dr[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF]        = saleConfWork.IncentiveRecv;        // ���C���Z���e�B�u�z(Int64)
            //    //salesMoney = saleConfWork.SalesMoneyTaxExc - saleConfWork.IncentiveDtbt;
            //    //cost = saleConfWork.Cost - saleConfWork.IncentiveRecv;
            //    //dr[MAHNB02349EA.CT_SalesConf_GrossProfitRF]          = salesMoney - cost;                 // �e�����z           (Int64)
            ////}

            ////else
            ////{
            ////    dr[MAHNB02349EA.CT_SalesConf_SalesCountRF]           = 0;                             // ���㐔             (double)
            ////    dr[MAHNB02349EA.CT_SalesConf_SalesUnitPriceTaxExcRF] = 0;                             // ����P���i�Ŕ����j (Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF]     = 0;                             // ������z�i�Ŕ����j (Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_CostRF]                 = 0;                             // ����               (Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF]        = 0;                             // �x���C���Z���e�B�u�z(Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF]        = 0;                             // ���C���Z���e�B�u�z(Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_GrossProfitRF]          = 0;                             // �e�����z           (Int64)
            ////}
            //// �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////
            
            
            //long total    = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);           // ����ł̎Z�o(�`�[)
            //long totalDtl = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);           // ����ł̎Z�o(����)
            //long DisTltInclu = saleConfWork.SalesDisTtlTaxInclu - saleConfWork.SalesDisTtlTaxExc;      // �l��������ł̎Z�o
            //long SalesMoneyRF= 0;                                                                      // ����`�[���v(����^���i)
            //long SalesIncRF= 0;                                                                        // ����`�[���v(����Ł^���i)        
            //long BalanceAdjustmentRF = 0;                                                              // ����`�[���v(����^�c������)
            //long ConsumptionTaxAdjustmentRF = 0;                                                       // ����`�[���v(����Ł^����Œ���)

            //long SalesMoney = 0;                                                                       // ���㖾�׍��v(����^���i)
            //long SalesInc = 0;                                                                         // ���㖾�׍��v(����Ł^���i)        
            //long BalanceAdjustment = 0;                                                                // ���㖾�׍��v(����^�c������)
            //long ConsumptionTaxAdjustment = 0;                                                         // ���㖾�׍��v(����Ł^����Œ���)
            
            //// �`�[(0�����i 2������� 3�� �c������ 4�� ���|����� 5�����|�c��)
            //if ((saleConfWork.SalesGoodsCd == 2) || (saleConfWork.SalesGoodsCd == 4))
            //{
            //    dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF] = 0;                                  // ������z(�Ŕ�) (�`�[) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF] = saleConfWork.SalesSubtotalTax;               // ���㏬�v�i�Łj (�`�[) (Int64)

            //    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF] = 0;                                  // ������z�i�Ŕ��j(����) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF] = saleConfWork.SalsePriceConsTax;           // ������z����Ŋz       (Int64)

            //    // ���v�l(��������)
            //    ConsumptionTaxAdjustmentRF = (saleConfWork.SalesSubtotalTax);
            //    ConsumptionTaxAdjustment = (saleConfWork.SalsePriceConsTax);
         
            //}
            //else if ((saleConfWork.SalesGoodsCd == 3) || (saleConfWork.SalesGoodsCd == 5))
            //{
            //    dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF] = saleConfWork.SalesTotalTaxInc;      // ������z(�ō�) (�`�[) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF] = 0;                                           // ���㏬�v�i�Łj(�`�[) (Int64)


            //    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF] = saleConfWork.SalesMoneyTaxExc;      // ������z�i�Ŕ��j(����) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF] = 0;                                        // �����(����)

            //    //���v�l(���㍇�v���z(�Ŕ�))
            //    BalanceAdjustmentRF = (saleConfWork.SalesTotalTaxInc);
            //    BalanceAdjustment = (saleConfWork.SalesMoneyTaxExc);
            //}
            //else
            //{
            //    dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF] = saleConfWork.SalesTotalTaxExc;     // ������z(�Ŕ�) (�`�[) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF] = total;                                      // �����(�`�[)
                

            //    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF] = saleConfWork.SalesMoneyTaxExc;     // ������z�i�Ŕ��j(����) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF] = totalDtl;                                // �����(����)

            //    //���v�l
            //    // ���㍇�v���z(�Ŕ���)
            //    SalesMoneyRF = (saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc);
            //    // ��������
            //    SalesIncRF = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - DisTltInclu);

            //    SalesMoney = (saleConfWork.SalesMoneyTaxExc);
            //    SalesInc = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                
            //}
            
            //// ����`�[�敪(�`�[)(SalesSlipCd �� 0=����A1=�ԕi)
            //if (saleConfWork.SalesSlipCd == 0)
            //{                
            //    // ���㐔�̃J�E���g(�`�[)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberRF] = 1;
                
            //    // ���㍇�v�������z(�Ŕ���)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesCostRF] = (saleConfWork.TotalCost);
                
            //    // ���㍇�v���z
            //    dr[MAHNB02349EA.CT_SalesConf_TotalMeterRF] = SalesMoneyRF + BalanceAdjustmentRF;

            //    // ����ō��v
            //    dr[MAHNB02349EA.CT_SalesConf_ConsumptionTaxTotalRF] = SalesIncRF + ConsumptionTaxAdjustmentRF;
               
            //    if (saleConfWork.SalesRowNo == 1)
            //    {
            //        // ���㐔�̃J�E���g(����)
            //        dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtlRF] = 1;
            //    }

            //}            
            
            //if (saleConfWork.SalesSlipCd == 1)
            //{
            //    // �ԕi���̃J�E���g(�`�[)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountRF] = 1;

            //    // �ԕi���v���z(�Ŕ���)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoneyRF] = (saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc);

            //    // �ԕi�����
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesIncRF] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxInclu);

            //    // �ԕi���v�������z(�Ŕ���)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostRF] = (saleConfWork.TotalCost);

            //    if (saleConfWork.SalesRowNo == 1)
            //    {
            //        // �ԕi���̃J�E���g(����)
            //        dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtlRF] = 1;
            //    }

            //}


            //// ����`�[�敪(����)(SalesSlipCdDtl �� 0=����A1=�ԕi�A2=�l��)
            //if (saleConfWork.SalesSlipCdDtl == 0)
            //{

            //    //���㍇�v���z(����)
            //    //dr[MAHNB02349EA.CT_SalesConf_SalesDtlRF] = (saleConfWork.SalesMoneyTaxExc);

            //    dr[MAHNB02349EA.CT_SalesConf_SalesDtlRF] = SalesMoney + BalanceAdjustment;

            //    //��������(����)
            //    //dr[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);

            //    dr[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF] = SalesInc + ConsumptionTaxAdjustment;

            //    // ���㍇�v����(�Ŕ���)(����)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesCostDtlRF] = (saleConfWork.Cost);
                
            //}

            //if (saleConfWork.SalesSlipCdDtl == 1)
            //{

            //    //�ԕi���v���z(����)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnDtlRF] = (saleConfWork.SalesMoneyTaxExc);

            //    // �ԕi�����(����)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnIncDtlRF] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);

            //    //�ԕi���v����(�Ŕ���)(����)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtlRF] = (saleConfWork.Cost);

            //}

            //if (saleConfWork.SalesSlipCdDtl == 2)
            //{
            //    //�l�������v���z(����)
            //    dr[MAHNB02349EA.CT_SalesConf_DistDtlRF] = (saleConfWork.SalesMoneyTaxExc);

            //    //�l���������(����)
            //    dr[MAHNB02349EA.CT_SalesConf_DistIncDtlRF] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);

            //    //�l�������v�������z(�Ŕ���)(����)
            //    dr[MAHNB02349EA.CT_SalesConf_DistDtlCostRF] = (saleConfWork.Cost);

            //    // �l�������v�������z(�`�[)
            //    dr[MAHNB02349EA.CT_SalesConf_DistCostRF] = (saleConfWork.Cost);
            //}
            // 2008.07.08 30413 ���� Row���ڂ̑S�u�������̂��ߊ������ڂ̓R�����g�� <<<<<<END
        }

        /// <summary>
        /// �N�����[�h���f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="sourceDataRow">�Z�b�g��DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            // 2008.07.08 30413 ���� Row���ڂ̑S�u�������̂��ߊ������ڂ̓R�����g�� >>>>>>START
            //// �S���ҕ�
            //dr[MAHNB02349EA.CT_SalesConf_SectionCodeRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SectionCodeRF];          // ���_�R�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SectionGuideNmRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SectionGuideNmRF];       // ���_�K�C�h����     (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDateRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDateRF];            // ������t           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_ShipmentDayRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_ShipmentDayRF];          // �o�ד��t           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerCodeRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_CustomerCodeRF];         // ���Ӑ�R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerSnmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_CustomerSnmRF];          // ���Ӑ於��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNumRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipNumRF];         // ����`�[�ԍ�       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesRowNoRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesRowNoRF];           // ����s�ԍ�         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_DebitNoteDivRF];         // �ԓ`�敪           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivNmRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_DebitNoteDivNmRF];       // �ԓ`�敪��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivCdRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_AccRecDivCdRF];          // ���|�敪           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivNmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_AccRecDivNmRF];          // ���|�敪��         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeCdRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesEmployeeCdRF];      // �̔��]�ƈ��R�[�h   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeNmRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesEmployeeNmRF];      // �̔��]�ƈ�����     (string)
            //dr[MAHNB02349EA.CT_SalesConf_ShipmentCntRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_ShipmentCntRF];          // �o�א�             (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxExcFlRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxExcFlRF];   // ����P���i�Ŕ����j (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF];     // ������z�i�ō��݁j (Int64)          
            //dr[MAHNB02349EA.CT_SalesConf_CostRF]                 = sourceDataRow[MAHNB02349EA.CT_SalesConf_CostRF];                 // ����               (Int64)         
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipCdRF];          // ����`�[�敪       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipNmRF];          // ����`�[�敪��     (string)

            //// �� 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_SearchSlipDateRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SearchSlipDateRF];       // ���͓��t           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AddUpADateRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddUpADateRF];           // �v����t(������)   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesAreaCodeRF];        // �̔��G���A�R�[�h   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesAreaNameRF];        // �̔��G���A����     (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNoRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsNoRF];              // ���i�ԍ�           (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsNameRF];            // ���i����           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_UnitCodeRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_UnitCodeRF];             // �P�ʃR�[�h         (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_UnitNameRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_UnitNameRF];             // �P�ʖ���           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionCodeRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SubSectionCodeRF];       // ����R�[�h         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionNameRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SubSectionNameRF];       // ���喼��           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionCodeRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_MinSectionCodeRF];       // �ۃR�[�h           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionNameRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_MinSectionNameRF];       // �ۖ���             (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimCodeRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_ClaimCodeRF];            // ������R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimSnmRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_ClaimSnmRF];             // �����旪��         (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeCodeRF];        // �[�i��R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeNameRF];        // �[�i�於��         (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeName2RF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeName2RF];       // �[�i�於��2        (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeCdRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_FrontEmployeeCdRF];      // ��t�]�ƈ��R�[�h   (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeNmRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_FrontEmployeeNmRF];      // ��t�]�ƈ�����     (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_AcptAnOdrStatusRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_AcptAnOdrStatusRF];      // �󒍃X�e�[�^�X     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesGoodsCdRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesGoodsCdRF];         // ���㏤�i�敪       (Int32)            
            //dr[MAHNB02349EA.CT_SalesConf_PartySaleSlipNumRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_PartySaleSlipNumRF];     // �����`�[�ԍ�     (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkSlip]    = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginMarkSlip];    // �e���`�F�b�N�}�[�N(�`�[) (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkDtl]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginMarkDtl];     // �e���`�F�b�N�}�[�N(����) (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyRF];           // ������z (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyPrt]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyPrt];          // ������z (String)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoneyRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesMoneyRF];     // ���㍇�v���z (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesCostRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCostRF];            // ���㍇�v����(�Ŕ���)(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_TotalCostRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_TotalCostRF];            // �������z�v         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SlipNoteRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_SlipNoteRF];             // �`�[���l           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdDtlRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipCdDtlRF];       // ����`�[�敪(����) (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmDtlRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipNmDtlRF];       // ����`�[�敪����(����)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsMakerCdRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsMakerCdRF];         // ���i���[�J�[�R�[�h (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MakerNameRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_MakerNameRF];            // ���[�J�[����       (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_StdUnPrcSalUnPrcRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_StdUnPrcSalUnPrcRF];     // ��P��(����P��) (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxIncFlRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxIncFlRF];   // ����P��(�ō�)     (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxIncRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxIncRF];     // ������z(�ō�)     (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnitCostRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesUnitCostRF];        // �����P��           (double)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierCdRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_SupplierCdRF];           // �d����R�[�h       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierSnmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SupplierSnmRF];          // �d���於��1        (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_PartySlipNumDtlRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_PartySlipNumDtlRF];      // �����`�[�ԍ�(����)(stirng)
            //dr[MAHNB02349EA.CT_SalesConf_DtlNoteRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_DtlNoteRF];              // ���ה��l           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRate]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginRate];        // �e����(�`�[)       (double)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRateDtl]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginRateDtl];     // �e����(����)       (double)      
            //dr[MAHNB02349EA.CT_SalesConf_DelayPaymentDivRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_DelayPaymentDivRF];      // �����敪      (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF];     // ����`�[���v(�Ŕ���)(�`�[) (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxIncRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesTotalTaxIncRF];     // ����`�[���v(�ō���)(�`�[)   (Int64)    
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxExcRF]    = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxExcRF];    // ����l�����z�v(�Ŕ�)(�`�[)    (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxIncluRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxIncluRF];  // ����l�����z�v(�ō�)(�`�[)    (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_TransactionNameRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_TransactionNameRF];      // ����敪(�`�[)      (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputCodeRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesinputCodeRF];       // ���͎҃R�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputNameRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesinputNameRF];       // ���͎Җ���           (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDtlRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDtlRF];             // ���㍇�v���z(�Ŕ���)(����)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnDtlRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnDtlRF];            // ����ԕi���v(�Ŕ���)(����)
            //dr[MAHNB02349EA.CT_SalesConf_DistDtlRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistDtlRF];              // ����l�������v(�Ŕ���)(����)
            //dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_ConsTaxRF];              //�����(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF];           //�����(����)
            //dr[MAHNB02349EA.CT_SalesConf_SalesIncRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesIncRF];             // ��������(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesIncRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesIncRF];       // �ԕi�����(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF];          // ��������(����)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnIncDtlRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnIncDtlRF];         // �ԕi�����(����)
            //dr[MAHNB02349EA.CT_SalesConf_DistIncDtlRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistIncDtlRF];           // �l���������(����)
            //dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCountnumberRF];     // ���㐔(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesCountRF];     // �ԕi��(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtlRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtlRF];  // ���㐔(����)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtlRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtlRF];  // �ԕi��(����)
            //dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesReturnCostRF];      // �ԕi���v�������z(�`�[)  
            //dr[MAHNB02349EA.CT_SalesConf_SalesCostDtlRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCostDtlRF];         //���㍇�v����(�Ŕ���)(����)    
            //dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtlRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtlRF];   //�ԕi���v����(�Ŕ���)(����)   
            //dr[MAHNB02349EA.CT_SalesConf_DistDtlCostRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistDtlCostRF];          //�l�������v�������z(�Ŕ���)(����)
            //dr[MAHNB02349EA.CT_SalesConf_DistCostRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistCostRF];             //�l�������v�������z(�Ŕ���)(�`�[)
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_WarehouseCodeRF];        //�q�ɃR�[�h
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_WarehouseNameRF];        //�q�ɖ���

            //// ���ύX�\�肠��////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeAddrRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeAddrRF];        //�[�i��Z��(�X�֔ԍ��A�s���{���s��S�E�����E���A���ځA�Ԓn�A�A�p�[�g����)
            //// ���ύX�\�肠��////////////////////////////////////////////////////////

            //// �� 2007.11.08 keigo yata Add //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //// �� 2008.03.24 keigo yata Add //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxIncRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxIncRF];   // ���㏬�v(�Ŕ���)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxExcRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxExcRF];   // ���㏬�v(�ō���)
            //dr[MAHNB02349EA.CT_SalesConf_SalseNetPriceRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalseNetPriceRF];         // ���㐳�����z
            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF];      // ���㏬�v�i��)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesOutTaxRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesOutTaxRF];      // ����O�őΏۊz
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesInTaxRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesInTaxRF];       // ������őΏۊz
            //dr[MAHNB02349EA.CT_SalesConf_SalSubttlSubToTaxFreRF] = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalSubttlSubToTaxFreRF];  // ���㏬�v��ېőΏۊz
            //dr[MAHNB02349EA.CT_SalesConf_SalseOutTaxRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalseOutTaxRF];           // ������z����Ŋz�i�O��)
            //dr[MAHNB02349EA.CT_SalesConf_SalAmntConsTaxIncluRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalAmntConsTaxIncluRF];   // ������z����Ŋz�i����)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisOutTaxRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesDisOutTaxRF];   // ����l���O�őΏۊz���v
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisInTaxRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesDisInTaxRF];    // ����l�����őΏۊz���v
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalseDisTaxFreRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalseDisTaxFreRF];   // ����l����ېőΏۊz���v
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisOutTaxRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDisOutTaxRF];        // ����l������Ŋz�i�O��)
            //dr[MAHNB02349EA.CT_SalesConf_SalsePriceConsTaxRF]    = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalsePriceConsTaxRF];     // ������z����Ŋz

            // �� 2008.03.24 keigo yata Add //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 2008.07.08 30413 ���� Row���ڂ̑S�u�������̂��ߊ������ڂ̓R�����g�� <<<<<<END
            
            // �� 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_GoodsCodeRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsCodeRF];            // ���i�R�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsNameRF];            // ���i����           (string)
            // �� 2007.11.08 keigo yata Change //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // �� 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_CustomerName2RF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_CustomerName2RF];        // ���Ӑ於��2        (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesFormCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesFormCodeRF];        // �̔��`�ԃR�[�h     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesFormNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesFormNameRF];        // �̔��`�Ԗ���       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipExpNumRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipExpNumRF];      // ����ڍהԍ�       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CarrierCodeRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_CarrierCodeRF];          // �L�����A�R�[�h     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CarrierNameRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_CarrierNameRF];          // �L�����A����       (string)
            //dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreCodeRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreCodeRF];  // ���i�啪�ރR�[�h   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreNameRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreNameRF];  // ���i�啪�ޖ���     (string)
            //dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreCodeRF] = sourceDataRow[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreCodeRF]; // ���i�����ރR�[�h   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreNameRF] = sourceDataRow[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreNameRF]; // ���i�����ޖ���     (string)
            //dr[MAHNB02349EA.CT_SalesConf_CellphoneModelCodeRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_CellphoneModelCodeRF];   // �@��R�[�h         (string)
            //dr[MAHNB02349EA.CT_SalesConf_CellphoneModelNameRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_CellphoneModelNameRF];   // �@�햼��           (string)
            //dr[MAHNB02349EA.CT_SalesConf_ProductNumber1RF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_ProductNumber1RF];       // �����ԍ�1          (string)
            //dr[MAHNB02349EA.CT_SalesConf_ProductNumber2RF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_ProductNumber2RF];       // �����ԍ�2          (string)
            //dr[MAHNB02349EA.CT_SalesConf_StockTelNo1RF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_StockTelNo1RF];          // ���i�d�b�ԍ�1      (string)
            //dr[MAHNB02349EA.CT_SalesConf_StockTelNo2RF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_StockTelNo2RF];          // ���i�d�b�ԍ�2      (string)
            //dr[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF];        // �x���C���Z���e�B�u�z(Int64)
            //dr[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF];        // ���C���Z���e�B�u�z(Int64)
            //dr[MAHNB02349EA.CT_SalesConf_GrossProfitRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossProfitRF];          // �e�����z           (Int64)
            
            // �� 2007.11.08 keigo yata Delete //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[SFURI06225EA.CT_CsSaleChkList_AddUpADateStr    ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.AddUpADate);  // �v����t(����p)�@(string)
            //dr[SFURI06225EA.CT_CsSaleChkList_PublicationStr   ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.Publication); // ������t(����p)�@(string)
            //dr[SFURI06225EA.CT_CsSaleChkList_CorporateDivName ] = DivCdCnvStrDivNm((Int32)dr["CorporateDivCode"]); //�l�E�@�l�敪(����p)�@(string)
        }
        
        /// <summary>
        /// �`�[�`�� ���̉�����
        /// </summary>
        private string GetSalesSlipNm(int salesSlipCd)
        {
            string wkStr = "";

            switch (salesSlipCd)
            {
                case 0:
                    {
                        wkStr = "����";
                        break;
                    }
                case 1:
                    {
                        wkStr = "�ԕi";
                        break;
                    }
                //case 2:
                //    {
                //        wkStr = "�l��";
                //        break;
                //    }
            }

            return wkStr;
        }

       
        // �� 2007.11.08 keigo yata Delete //////////////////////////////////////////////
        /// <summary>
        /// ���׌`�� ���̉�����
        /// </summary>
        private string GetSalesSlipNmDtl(int salesSlipCdDtl)
        {
            string wkStr = "";

            switch (salesSlipCdDtl)
            {
                case 0:
                    {
                        wkStr = ""; // ����
                        break;
                    }
                case 1:
                    {
                        wkStr = "�ԕi";
                        break;
                    }
                case 2:
                    {
                        wkStr = "�l��";
                        break;
                    }
                case 3:
                    {
                        wkStr = "����";
                        break;
                    }
                case 9:
                    {
                        wkStr = "�ꎮ";
                        break;
                    }
            }

            return wkStr;
        }
        // �� 2007.11.08 keigo yata Delete //////////////////////////////////////////////

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
                        wkStr = "";//���`
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
        private string GetAccRecDivNm(int accRecDivCd)
        {
            string wkStr = "";

            switch (accRecDivCd)
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

        // 2010/07/01 Add >>>
        /// <summary>
        /// �S�p�˔��p�ϊ�
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private static string GetKanaString(string orgString)
        {
            // �S�p�˔��p�ϊ��i�r���Ɋ܂܂��ϊ��ł��Ȃ������͂��̂܂܁j
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }
        // 2010/07/01 Add <<<

		#endregion
	}
}