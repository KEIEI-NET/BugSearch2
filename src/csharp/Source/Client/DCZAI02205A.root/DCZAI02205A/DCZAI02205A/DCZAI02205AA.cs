//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɓ��o�Ɋm�F�\
// �v���O�����T�v   : �݌ɓ��o�Ɋm�F�\�Ŏg�p����f�[�^���擾����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��؁@���b
// �� �� ��  2007/09/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/12/09  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/12/11  �C�����e : �`�[�敪�u13:�݌Ɏd���v�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/12/15  �C�����e : 1.�R���o�[�g�f�[�^�œ`�[�敪�u31:�ړ����ׁv��
//                                    ���o�ɐ�\�����A���؂��o�O�C��
//                                  2.���ɋ��z�A�o�ɋ��z�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/08  �C�����e : �P������ɒP���A�o�ɒP���ɕ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/23  �C�����e : �s��Ή�[6581]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/28  �C�����e : �s��Ή�[10622]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/09  �C�����e : �s��Ή�[12240][12241][12244]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/10  �C�����e : �s��Ή�[12239]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/07  �C�����e : �s��Ή�[12997]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/26  �C�����e : �s��Ή�[12856]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2010/11/15  �C�����e : PM.NS �@�\���ǂp�S
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �C �� ��  2010/12/09  �C�����e : redmine #17944 �݌ɓ��o�Ɋm�F�\�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���� �G
// �C �� ��  2013/01/15  �C�����e :  �Ǘ�No.541 ���|�I�v�V�����ǉ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources; // ---ADD 2013/01/15

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �݌Ɏ󕥊m�F�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �݌Ɏ󕥊m�F�\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 22018 ��� ���b</br>
    /// <br>Date         : 2007.09.19</br>
	/// <br>Updatenote   : 2008/12/09 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>             : 2008/12/11 �Ɠc �M�u�@�`�[�敪�u13:�݌Ɏd���v�ǉ�</br>
    /// <br>             : 2008/12/15 �Ɠc �M�u�@</br>
    /// <br>                �E�R���o�[�g�f�[�^�œ`�[�敪�u31:�ړ����ׁv�̓��o�ɐ�\�����A���؂��o�O�C��</br>
    /// <br>                �E���ɋ��z�A�o�ɋ��z�ǉ�</br>
    /// <br>             : 2009/01/08 �Ɠc �M�u�@�P������ɒP���A�o�ɒP���ɕ���</br>
    /// <br>             : 2009/01/23 �Ɠc �M�u�@�s��Ή�[6581]</br>
    /// <br>             : 2009/01/28 �Ɠc �M�u�@�s��Ή�[10622]</br>
    /// <br>             : 2009/03/09 �Ɠc �M�u�@�s��Ή�[12240][12241][12244]</br>
    /// <br>             : 2009/03/10 �Ɠc �M�u�@�s��Ή�[12239]</br>
    /// <br>             : 2009/04/07 �Ɠc �M�u�@�s��Ή�[12997]</br>
    /// <br>             : 2009/04/07 �Ɠc �M�u�@�s��Ή�[12856]</br>
    /// <br>UpdateNote   : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// <br>UpdateNote   : 2010/12/09 yangmj</br>
    /// <br>               redmine #17944 �݌ɓ��o�Ɋm�F�\�̏C��</br>
    /// </remarks>
	public class StockAcPayListAcs
	{
		#region �� Constructor
		/// <summary>
		/// �݌Ɏ󕥊m�F�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥊m�F�\�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public StockAcPayListAcs()
		{
            this._iStockAcPayHisSearchDB = (IStockAcPayHisSearchDB)MediationStockAcPayHisSearchDB.GetStockAcPayHisSearchDB();

            this._acPaySlipNmDic = CreateAcPaySlipNmDictionary();
            this._acPayTransNmDic = CreateAcPayTransNmDictionary();

            // ---ADD 2009/05/26 �s��Ή�[12856] ----------------------------------------------------------------->>>>>
            // ���א����󎚂���`�[�敪�̃��X�g
            // 10�F�d���A11�F���ׁA13�F�݌Ɏd���A31�F�ړ����ׁA40�F�����A42�F�}�X�^�����e�A50�F�I���A60�F�g���A61�F�����A70�F��[����
            this._stockAcPaySlipOfArrivalList = new List<int>();
            this._stockAcPaySlipOfArrivalList.AddRange(new int[] { 10, 11, 13, 31, 40, 42, 50, 60, 61, 70 });
            // �o�א����󎚂���`�[�敪�̃��X�g
            // 12�F��v��A20�F����A21�F���v��A22�F�o�ׁA23�F���؁A30�F�ړ��o�ׁA41�F�����A71�F��[�o��
            this._stockAcPaySlipOfShipmentList = new List<int>();
            this._stockAcPaySlipOfShipmentList.AddRange(new int[] { 12, 20, 21, 22, 23, 30, 41, 71 });
            // ---ADD 2009/05/26 �s��Ή�[12856] -----------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// �݌Ɏ󕥊m�F�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥊m�F�\�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static StockAcPayListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs      = new SecInfoAcs(1);    // ���_�A�N�Z�X�N���X
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // ���_Dictionary

			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList ) {
                // �����łȂ����
                if (! stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) ) {
                    // �ǉ�
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
		}
        #endregion �� Constructor

		#region �� Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X

        private static SecInfoAcs stc_SecInfoAcs;               // ���_�A�N�Z�X�N���X
        private static Dictionary<string,SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion �� Static Member

		#region �� Private Member
        IStockAcPayHisSearchDB _iStockAcPayHisSearchDB;
		private DataTable _stockAcPayListDt;			// ���DataTable
		private DataView _stockAcPayListDataView;	// ���DataView
        private Dictionary<int, string> _acPaySlipNmDic;    // �`�[�敪���̃f�B�N�V���i��
        private Dictionary<int, string> _acPayTransNmDic;   // ����敪���̃f�B�N�V���i��
        private List<int> _stockAcPaySlipOfArrivalList;     // ���א����󎚂���`�[�敪�̃��X�g //ADD 2009/05/26 �s��Ή�[12856]
        private List<int> _stockAcPaySlipOfShipmentList;    // �o�א����󎚂���`�[�敪�̃��X�g //ADD 2009/05/26 �s��Ή�[12856]
		#endregion �� Private Member

		#region �� Public Property
		/// <summary>
		/// ����f�[�^�Z�b�g(�ǂݎ���p)
		/// </summary>
		public DataView StockAcPayListDataView
		{
			get{ return this._stockAcPayListDataView; }
		}
		#endregion �� Public Property

		#region �� Public Method
		#region �� �o�̓f�[�^�擾
		#region �� �����f�[�^�擾
		/// <summary>
		/// �f�[�^�擾
		/// </summary>
		/// <param name="stockAcPayListCndtn">���o����</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �������f�[�^���擾����B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( StockAcPayListCndtn stockAcPayListCndtn, out string errMsg )
		{
            return this.SearchProc(stockAcPayListCndtn, out errMsg);
		}
		#endregion
		#endregion �� �o�̓f�[�^�擾
		#endregion �� Public Method

		#region �� Private Method
		#region �� ���[�f�[�^�擾
		#region �� �݌Ɉړ��f�[�^�擾
		/// <summary>
		/// �݌Ɉړ��f�[�^�擾
		/// </summary>
		/// <param name="stockAcPayListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �������݌Ɉړ��f�[�^���擾����B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( StockAcPayListCndtn stockAcPayListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCZAI02204EA.CreateDataTable( ref this._stockAcPayListDt );
				
				StockAcPayHisSearchParaWork stockAcPayHisSearchParaWork = new StockAcPayHisSearchParaWork();
				// ���o�����W�J  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockAcPayListCndtn, out stockAcPayHisSearchParaWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// �f�[�^�擾  ----------------------------------------------------------------
				object retWorkList = null;
                status = this._iStockAcPayHisSearchDB.Search( out retWorkList, stockAcPayHisSearchParaWork, 0, ConstantManagement.LogicalMode.GetData0);

                //--- TEST ---------->>>>>
                //retWorkList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ----------<<<<<
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// �f�[�^�W�J����
						DevStockMoveData( stockAcPayListCndtn, (CustomSerializeArrayList)retWorkList );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "�݌Ɏ󕥗����f�[�^�̎擾�Ɏ��s���܂����B";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion �� ���[�f�[�^�擾

        # region �e�X�g�p
        //private object GetTestData()
        //{
        //    ArrayList list = new ArrayList();
        //    CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

        //    for (int a = 0; a < 35; a++)
        //    {
        //        StockAcPayHisSearchRetWork work = new StockAcPayHisSearchRetWork();

        //        work.GoodsMakerCd = 10;					// ���[�J�[�R�[�h
        //        work.MakerName = "�g���^";		        // ���[�J�[����
        //        work.GoodsNo = "20";					// ���i�R�[�h
        //        work.GoodsName = "12345";   			// ���i����
        //        work.IoGoodsDay = TDateTime.LongDateToDateTime(20080702);   // ���o�ד�
        //        work.AcPaySlipNum = "000000001";        // �󕥌��`�[�ԍ�
        //        work.AcPaySlipRowNo = 1;                // �󕥌��s�ԍ�
        //        work.AcPayTransCd = 40;					// �󕥌�����敪 10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���

        //        work.ArrivalCnt = 10001 + a;            // ���א�
        //        work.ShipmentCnt = 10000 + a;           // �o�א�
        //        work.ListPriceTaxExcFl = 10000 + a;     // �艿�i�Ŕ��C�����j
        //        work.StockUnitPriceFl = 1000 + a;       // �d���P���i�Ŕ��C�����j

        //        if (a >= 0 && a < 5)
        //        {
        //            work.SectionCode = "01";				// ���_�R�[�h 
        //            work.SectionGuideNm = "���_01";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0001";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��01";          // �q�ɖ���
        //            work.AcPaySlipCd = 10;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //        }
        //        else if (a >= 5 && a < 10)
        //        {
        //            work.SectionCode = "01";				// ���_�R�[�h
        //            work.SectionGuideNm = "���_02";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0002";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��02";          // �q�ɖ���
        //            work.AcPaySlipCd = 20;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //        }
        //        else if (a >= 10 && a < 15)
        //        {
        //            work.SectionCode = "02";				// ���_�R�[�h
        //            work.SectionGuideNm = "���_02";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0001";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��01";          // �q�ɖ���
        //            work.AcPaySlipCd = 20;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //        }
        //        else if (a >= 15 && a < 20)
        //        {
        //            work.SectionCode = "02";				// ���_�R�[�h
        //            work.SectionGuideNm = "���_02";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0002";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��02";          // �q�ɖ���
        //            work.AcPaySlipCd = 10;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //        }
        //        else if (a >= 20 && a < 25)
        //        {
        //            work.SectionCode = "03";				// ���_�R�[�h
        //            work.SectionGuideNm = "���_03";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0001";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��01";          // �q�ɖ���
        //            work.AcPaySlipCd = 42;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //        }
        //        else if (a >= 25 && a < 30)
        //        {
        //            work.SectionCode = "03";				// ���_�R�[�h
        //            work.SectionGuideNm = "���_03";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0002";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��02";          // �q�ɖ���
        //            work.AcPaySlipCd = 30;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //            work.AfSectionCode = "99";
        //            work.AfSectionGuideNm = "���_�X�X�X�X";
        //            work.AfEnterWarehCode = "9999";
        //            work.AfEnterWarehName = "�q�ɂX�X�X�X�X�X�X�X�X�X�X�X�X�X�X�X�X�X";
        //        }
        //        else if (a >= 30 && a < 35)
        //        {
        //            work.SectionCode = "03";				// ���_�R�[�h
        //            work.SectionGuideNm = "���_03";  		// ���_�K�C�h����
        //            work.WarehouseCode = "0003";            // �q�ɃR�[�h
        //            work.WarehouseName = "�q��03";          // �q�ɖ���
        //            work.AcPaySlipCd = 10;					// �󕥌��`�[�敪 10:�d��,11:���,12:��v��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��
        //        }

        //        list.Add(work);
        //    }

        //    customSerializeArrayList.Add(list);

        //    return (object)customSerializeArrayList;
        //}
        # endregion

		#region �� �f�[�^�W�J����
		#region �� ���o�����W�J����
		/// <summary>
		/// ���o�����W�J����
		/// </summary>
		/// <param name="stockAcPayListCndtn">UI���o�����N���X</param>
		/// <param name="stockAcPayHisSearchParaWork">�����[�g���o�����N���X</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
		/// <br>UpdateNote : 2013/01/15 FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ��Ή�</br>
        private int DevStockMoveCndtn(StockAcPayListCndtn stockAcPayListCndtn, out StockAcPayHisSearchParaWork stockAcPayHisSearchParaWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockAcPayHisSearchParaWork = new StockAcPayHisSearchParaWork();
			try
			{
                stockAcPayHisSearchParaWork.EnterpriseCode = stockAcPayListCndtn.EnterpriseCode;  // ��ƃR�[�h
				// ���o�����p�����[�^�Z�b�g
				if ( stockAcPayListCndtn.SectionCodes.Length != 0 )
				{
				    if ( stockAcPayListCndtn.IsSelectAllSection )
				    {
				        // �S�Ђ̎�
                        stockAcPayHisSearchParaWork.SectionCodes = null;
				    }
				    else
				    {
                        stockAcPayHisSearchParaWork.SectionCodes = stockAcPayListCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockAcPayHisSearchParaWork.SectionCodes = null;
				}

                //stockAcPayHisSearchParaWork.ValidDivCd = stockAcPayListCndtn.ValidDivCd; // �L���敪  // DEL 2008/07/02
                stockAcPayHisSearchParaWork.St_IoGoodsDay = GetLongDateFromDateTime(stockAcPayListCndtn.St_IoGoodsDay); // �J�n���o�ד�
                stockAcPayHisSearchParaWork.Ed_IoGoodsDay = GetLongDateFromDateTime(stockAcPayListCndtn.Ed_IoGoodsDay); // �I�����o�ד�
                stockAcPayHisSearchParaWork.St_AddUpADate = GetLongDateFromDateTime(stockAcPayListCndtn.St_AddUpADate); // �J�n�v����t
                stockAcPayHisSearchParaWork.Ed_AddUpADate = GetLongDateFromDateTime(stockAcPayListCndtn.Ed_AddUpADate); // �I���v����t
                stockAcPayHisSearchParaWork.AcPaySlipCd = stockAcPayListCndtn.AcPaySlipCd; // �󕥌��`�[�敪
                stockAcPayHisSearchParaWork.St_WarehouseCode = stockAcPayListCndtn.St_WarehouseCode; // �J�n�q�ɃR�[�h
                stockAcPayHisSearchParaWork.Ed_WarehouseCode = stockAcPayListCndtn.Ed_WarehouseCode; // �I���q�ɃR�[�h
                stockAcPayHisSearchParaWork.St_GoodsMakerCd = stockAcPayListCndtn.St_GoodsMakerCd; // �J�n���i���[�J�[�R�[�h
                stockAcPayHisSearchParaWork.Ed_GoodsMakerCd = stockAcPayListCndtn.Ed_GoodsMakerCd; // �I�����i���[�J�[�R�[�h
                stockAcPayHisSearchParaWork.St_AcPaySlipNum = stockAcPayListCndtn.St_AcPaySlipNum; // �J�n�󕥌��`�[�ԍ�
                stockAcPayHisSearchParaWork.Ed_AcPaySlipNum = stockAcPayListCndtn.Ed_AcPaySlipNum; // �I���󕥌��`�[�ԍ�
                stockAcPayHisSearchParaWork.St_GoodsNo = stockAcPayListCndtn.St_GoodsNo; // �J�n���i�ԍ�
                stockAcPayHisSearchParaWork.Ed_GoodsNo = stockAcPayListCndtn.Ed_GoodsNo; // �I�����i�ԍ�
                
                // ---ADD 2010/11/15 ------------------------>>>>>
                stockAcPayHisSearchParaWork.St_detInputDay = stockAcPayListCndtn.St_detInputDay;
                stockAcPayHisSearchParaWork.Ed_detInputDay = stockAcPayListCndtn.Ed_detInputDay;
                stockAcPayHisSearchParaWork.GroupCnt = stockAcPayListCndtn.GroupCnt;
                stockAcPayHisSearchParaWork.Sort = stockAcPayListCndtn.Sort;
                stockAcPayHisSearchParaWork.SlipKuben = stockAcPayListCndtn.SlipKuben;
                // ---ADD 2010/11/15 ------------------------<<<<<

                // ---ADD 2013/01/15 ------------------------>>>>>
                stockAcPayHisSearchParaWork.HasStkPay = HasStockingPayment(); //���|�I�v�V����
                // ---ADD 2013/01/15 ------------------------<<<<<

			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
        /// <summary>
        /// YYYYMMDD���t�擾���� (�A��DateTime.MinValue�Ȃ��0�ɕϊ�)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateFromDateTime ( DateTime dateTime )
        {
            if ( dateTime == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ( dateTime.Year * 10000 ) + ( dateTime.Month * 100 ) + dateTime.Day;
            }
        }
		#endregion

		#region �� �擾�f�[�^�W�J����
		/// <summary>
		/// �擾�f�[�^�W�J����
		/// </summary>
		/// <param name="stockAcPayListCndtn">UI���o�����N���X</param>
        /// <param name="retList">�擾�f�[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �擾�f�[�^��W�J����B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Update Note: 2010/11/15 liyp</br>
        /// <br>            �o�l�D�m�r�@�@�\���ǂp�S</br>
        /// <br>Update Note: 2010/12/09 yangmj</br>
        /// <br>             redmine #17944 �݌ɓ��o�Ɋm�F�\�̏C��</br>
        /// </remarks>
		private void DevStockMoveData ( StockAcPayListCndtn stockAcPayListCndtn, CustomSerializeArrayList retList )
		{
			DataRow dr;

            ArrayList workList;

            if ( retList.Count > 0 && retList[0] is ArrayList )
            {
                workList = (ArrayList)retList[0];
            }
            else
            {
                workList = new ArrayList();
            }

            foreach ( StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork in workList )
			{
				dr = this._stockAcPayListDt.NewRow();
				// �擾�f�[�^�W�J
				#region �擾�f�[�^�W�J
                //dr[DCZAI02204EA.ct_Col_SectionCode] = stockAcPayHisSearchRetWork.SectionCode;       // ���_�R�[�h             //DEL 2009/04/07 �s��Ή�[12997]
                //dr[DCZAI02204EA.ct_Col_SectionGuideNm] = stockAcPayHisSearchRetWork.SectionGuideNm; // ���_�K�C�h����         //DEL 2009/04/07 �s��Ή�[12997]
                dr[DCZAI02204EA.ct_Col_WarehouseCode] = stockAcPayHisSearchRetWork.WarehouseCode;   // �q�ɃR�[�h
                dr[DCZAI02204EA.ct_Col_WarehouseName] = stockAcPayHisSearchRetWork.WarehouseName;   // �q�ɖ���
                dr[DCZAI02204EA.ct_Col_GoodsMakerCd] = stockAcPayHisSearchRetWork.GoodsMakerCd;     // ���i���[�J�[�R�[�h
                dr[DCZAI02204EA.ct_Col_MakerName] = stockAcPayHisSearchRetWork.MakerName;           // ���[�J�[����
                dr[DCZAI02204EA.ct_Col_GoodsNo] = stockAcPayHisSearchRetWork.GoodsNo;               // ���i�ԍ�
                dr[DCZAI02204EA.ct_Col_GoodsName] = stockAcPayHisSearchRetWork.GoodsName;           // ���i����
                //dr[DCZAI02204EA.ct_Col_IoGoodsDay] = stockAcPayHisSearchRetWork.IoGoodsDay.ToString("yy/MM/dd"); // ���o�ד�  //DEL 2009/03/09 �s��Ή�[12240]
                // ---ADD 2009/03/09 �s��Ή�[12240] ------------------------------------------------------>>>>>
                if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                    (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                {
                    dr[DCZAI02204EA.ct_Col_IoGoodsDay] = stockAcPayHisSearchRetWork.AddUpADate.ToString("yy/MM/dd"); // �v���
                }
                else
                {
                    dr[DCZAI02204EA.ct_Col_IoGoodsDay] = stockAcPayHisSearchRetWork.IoGoodsDay.ToString("yy/MM/dd"); // ���o�ד�
                }
                // ---ADD 2009/03/09 �s��Ή�[12240] ------------------------------------------------------>>>>>

                //dr[DCZAI02204EA.ct_Col_AcPaySlipNum] = stockAcPayHisSearchRetWork.AcPaySlipNum;     // �󕥌��`�[�ԍ�         //DEL 2009/03/09 �s��Ή�[12244]
                // ---ADD 2009/03/09 �s��Ή�[12244] ------------------------------------------------------>>>>>
                try
                {
                    dr[DCZAI02204EA.ct_Col_AcPaySlipNum] = int.Parse(stockAcPayHisSearchRetWork.AcPaySlipNum).ToString("000000000");
                }
                catch
                {
                    dr[DCZAI02204EA.ct_Col_AcPaySlipNum] = stockAcPayHisSearchRetWork.AcPaySlipNum;     // �󕥌��`�[�ԍ�
                }
                // ---ADD 2009/03/09 �s��Ή�[12244] ------------------------------------------------------<<<<<

                dr[DCZAI02204EA.ct_Col_AcPaySlipRowNo] = stockAcPayHisSearchRetWork.AcPaySlipRowNo; // �󕥌��s�ԍ�
                dr[DCZAI02204EA.ct_Col_AcPaySlipCd] = stockAcPayHisSearchRetWork.AcPaySlipCd;       // �󕥌��`�[�敪
                dr[DCZAI02204EA.ct_Col_AcPayTransCd] = stockAcPayHisSearchRetWork.AcPayTransCd;     // �󕥌�����敪
                dr[DCZAI02204EA.ct_Col_AcPayOtherPartyCd] = string.Empty;                           // �󕥐�R�[�h�i����p�j
                dr[DCZAI02204EA.ct_Col_AcPayOtherPartyNm] = string.Empty;                           // �󕥐於�́i����p�j
                

                // ---UPD 2010/11/15 ------------------------------------------------------------------------>>>>>
                //dr[DCZAI02204EA.ct_Col_ArrivalCnt] = stockAcPayHisSearchRetWork.ArrivalCnt;         // ���א�
                //sdr[DCZAI02204EA.ct_Col_ShipmentCnt] = stockAcPayHisSearchRetWork.ShipmentCnt;       // �o�א�
                // ���א��E�o�א�
                // ���󕥌��`�[�敪��10:�d�� or 20:���� �����o�ד��ɒl���Z�b�g����Ă��Ȃ��ꍇ�A()�ň͂�ŕ\�����A
                //   �J�z���̌v�Z�ΏۊO�Ƃ���
                if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                    (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                // ---ADD 2009/02/09 �s��Ή�[11007] -------------------------------------------------<<<<<
                {
                    dr[DCZAI02204EA.ct_Col_ArrivalCnt] = string.Format("({0}", stockAcPayHisSearchRetWork.ArrivalCnt.ToString("#,##0.00"));    // ���א�
                    dr[DCZAI02204EA.ct_Col_ShipmentCnt] = string.Format("({0}", stockAcPayHisSearchRetWork.ShipmentCnt.ToString("#,##0.00")); // �o�א�
                    dr[DCZAI02204EA.ct_Col_Bracker] = ")";
                }
                else
                {
                    dr[DCZAI02204EA.ct_Col_ArrivalCnt] = stockAcPayHisSearchRetWork.ArrivalCnt.ToString("#,##0.00");       // ���א�
                    dr[DCZAI02204EA.ct_Col_ShipmentCnt] = stockAcPayHisSearchRetWork.ShipmentCnt.ToString("#,##0.00");     // �o�א�
                    dr[DCZAI02204EA.ct_Col_Bracker] = "";
                }
                // ---UPD 2010/11/15 ------------------------------------------------------------------------<<<<<


                dr[DCZAI02204EA.ct_Col_ListPriceTaxExcFl] = stockAcPayHisSearchRetWork.ListPriceTaxExcFl;   // �艿�i�Ŕ��C�����j
                dr[DCZAI02204EA.ct_Col_StockUnitPriceFl] = stockAcPayHisSearchRetWork.StockUnitPriceFl;     // �d���P���i�Ŕ��C�����j
                dr[DCZAI02204EA.ct_Col_AcPaySlipNm] = string.Empty;                                 // �󕥌��`�[�敪
                dr[DCZAI02204EA.ct_Col_AcPayTransNm] = string.Empty;                                // �󕥌�����敪

                // ---DEL 2009/05/26 �s��Ή�[12856] ------------------------------------------------------------->>>>>
                //// --- ADD 2008/12/15 --------------------------------------------------------------------------->>>>>
                //dr[DCZAI02204EA.ct_Col_StockPrice] = stockAcPayHisSearchRetWork.StockPrice;         // ���ɋ��z
                //dr[DCZAI02204EA.ct_Col_SalesMoney] = stockAcPayHisSearchRetWork.SalesMoney;         // �o�ɋ��z
                //// --- ADD 2008/12/15 ---------------------------------------------------------------------------<<<<<
                // ---DEL 2009/05/26 �s��Ή�[12856] -------------------------------------------------------------<<<<<
                // ---ADD 2009/05/26 �s��Ή�[12856] ------------------------------------------------------------->>>>>
                // ���א��̈󎚗L��
                if (_stockAcPaySlipOfArrivalList.Contains(stockAcPayHisSearchRetWork.AcPaySlipCd))
                {
                    // ---ADD 2010/11/15 ------------------------>>>>>
                    // ���󕥌��`�[�敪��10:�d�� or 20:���� �����o�ד��ɒl���Z�b�g����Ă��Ȃ��ꍇ�A()�ň͂�ŕ\����
                    if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                        (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                    {
                        //-----UPD 2010/12/09----->>>>>
                        //dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0.00"));// ���ɋ��z
                        dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0"));// ���ɋ��z
                        //-----UPD 2010/12/09-----<<<<<
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = ")";
                    }
                    else
                    {
                    // ---ADD 2010/11/15 ------------------------<<<<<
                        dr[DCZAI02204EA.ct_Col_StockPrice] = stockAcPayHisSearchRetWork.StockPrice;         // ���ɋ��z
                    // ---ADD 2010/11/15 ------------------------>>>>>
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = "";
                    }
                    // ---ADD 2010/11/15 ------------------------<<<<<
                    dr[DCZAI02204EA.ct_Col_SalesMoney] = 0;                                             // �o�ɋ��z
                }
                // �o�א��̈󎚗L��
                else if (_stockAcPaySlipOfShipmentList.Contains(stockAcPayHisSearchRetWork.AcPaySlipCd))
                {
                    dr[DCZAI02204EA.ct_Col_StockPrice] = 0;                                             // ���ɋ��z

                    // ---ADD 2010/11/15 ------------------------>>>>>
                    // ���󕥌��`�[�敪��10:�d�� or 20:���� �����o�ד��ɒl���Z�b�g����Ă��Ȃ��ꍇ�A()�ň͂�ŕ\����
                    if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                        (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                    {
                        //-----UPD 2010/12/09----->>>>>
                        //dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0.00"));// ���ɋ��z
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0"));// ���ɋ��z
                        //-----UPD 2010/12/09-----<<<<<
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = ")";
                    }
                    else
                    {
                    // ---ADD 2010/11/15 ------------------------<<<<<
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = stockAcPayHisSearchRetWork.SalesMoney;         // �o�ɋ��z
                    // ---ADD 2010/11/15 ------------------------>>>>>
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = "";
                    }
                    // ---ADD 2010/11/15 ------------------------<<<<<
                }
                else
                {
                    // ---ADD 2010/11/15 ------------------------>>>>>
                    // ���󕥌��`�[�敪��10:�d�� or 20:���� �����o�ד��ɒl���Z�b�g����Ă��Ȃ��ꍇ�A()�ň͂�ŕ\����
                    if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                        (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                    {
                        //-----UPD 2010/12/09----->>>>>
                        //dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0.00"));// ���ɋ��z
                        dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0"));// ���ɋ��z
                        //dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0.00"));// ���ɋ��z
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0"));// ���ɋ��z
                        //-----UPD 2010/12/09-----<<<<<
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = ")";
                    }
                    else
                    {
                    // ---ADD 2010/11/15 ------------------------<<<<<
                        dr[DCZAI02204EA.ct_Col_StockPrice] = stockAcPayHisSearchRetWork.StockPrice;         // ���ɋ��z
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = stockAcPayHisSearchRetWork.SalesMoney;         // �o�ɋ��z
                    // ---ADD 2010/11/15 ------------------------>>>>>
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = "";
                    }
                    // ---ADD 2010/11/15 ------------------------<<<<<
                }
                // ---ADD 2009/05/26 �s��Ή�[12856] -------------------------------------------------------------<<<<<

                // --- ADD 2009/01/08 --------------------------------------------------------------------------->>>>>
                dr[DCZAI02204EA.ct_Col_SalesUnPrcTaxExcFl] = stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl;     // ����P���i�Ŕ��C�����j
                // --- ADD 2009/01/08 ---------------------------------------------------------------------------<<<<<
                // --- ADD 2009/01/28 �s��Ή�[10622] --------------------------------------------------------->>>>>
                dr[DCZAI02204EA.ct_Col_AcPayHistDateTime] = stockAcPayHisSearchRetWork.AcPayHistDateTime;       // �󕥗����쐬����
                // --- ADD 2009/01/08 �s��Ή�[10622] ---------------------------------------------------------<<<<<

                //--- ADD 2010/11/15 ------------------------------------------>>>>>
                // <summary> �O�����c </summary>
                dr[DCZAI02204EA.ct_Col_StockTotal] = stockAcPayHisSearchRetWork.StockTotal;
                dr[DCZAI02204EA.ct_Col_GoodsNoMaker] = stockAcPayHisSearchRetWork.GoodsNo + stockAcPayHisSearchRetWork.GoodsMakerCd;
                try
                {
                    dr[DCZAI02204EA.ct_Col_ShelfNo] = int.Parse(stockAcPayHisSearchRetWork.ShelfNo).ToString("00000000");
                }
                catch
                {
                    dr[DCZAI02204EA.ct_Col_ShelfNo] = stockAcPayHisSearchRetWork.ShelfNo;     // �󕥌��`�[�ԍ�
                }
                dr[DCZAI02204EA.ct_Col_AcPayHistDateTimeView] = stockAcPayHisSearchRetWork.AcPayHistDateTime.ToString("yy/MM/dd");
                //--- ADD 2010/11/15 ------------------------------------------<<<<<

                #endregion

                // �󕥐�R�[�h�E���̃Z�b�g����
                SetRecordAcPayOtherParty( ref dr, stockAcPayHisSearchRetWork );
                // �敪���̃Z�b�g����
                SetRecordDivName( ref dr, stockAcPayHisSearchRetWork);

				// Table��Add
				this._stockAcPayListDt.Rows.Add( dr );
			}

			// DataView�쐬
			this._stockAcPayListDataView = new DataView( this._stockAcPayListDt, "", GetSortOrder(stockAcPayListCndtn), DataViewRowState.CurrentRows );
		}
        /// <summary>
        /// �󕥐�R�[�h�E���̃Z�b�g����
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="stockAcPayHisSearchRetWork"></param>
        /// <remarks>
        /// <br>DataRow�Ɏ󕥐�R�[�h�E���̂�ݒ肵�܂��B</br>
        /// </remarks>
        private void SetRecordAcPayOtherParty ( ref DataRow dr, StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork )
        {
            string code = string.Empty;
            string name = string.Empty;

            switch ( stockAcPayHisSearchRetWork.AcPaySlipCd )
            {
                // 30:�ړ��o��
                case 30:
                    {
                        // �ړ��拒�_�{�ړ���q��
                        //--- DEL 2008/07/03 ---------->>>>>
                        //code = string.Format( "{0}�F{1}", 
                        //                        stockAcPayHisSearchRetWork.AfSectionCode,
                        //                        stockAcPayHisSearchRetWork.AfEnterWarehCode );
                        //--- DEL 2008/07/03 ----------<<<<<
                        //--- ADD 2008/07/03 ---------->>>>>
                        code = string.Format("{0}�F{1}",
                                                stockAcPayHisSearchRetWork.AfSectionCode.Trim(),
                                                stockAcPayHisSearchRetWork.AfEnterWarehCode.Trim());
                        //--- ADD 2008/07/03 ----------<<<<<
                        name = string.Format("{0}�F{1}", 
                                                stockAcPayHisSearchRetWork.AfSectionGuideNm,
                                                stockAcPayHisSearchRetWork.AfEnterWarehName );
                    }
                    break;
                // 31:�ړ�����
                case 31:
                    {
                        // �ړ������_�{�ړ����q��
                        /* --- DEL 2008/12/15 ���؂���------------------------------------------------>>>>>
                        code = string.Format("{0}�F{1}",
                                                stockAcPayHisSearchRetWork.BfSectionCode,
                                                stockAcPayHisSearchRetWork.BfEnterWarehCode );
                           --- DEL 2008/12/15 ----------------------------------------------------------<<<<< */
                        //--- ADD 2008/12/15 ----------------------------------------------------------->>>>>
                        code = string.Format("{0}�F{1}",
                                                stockAcPayHisSearchRetWork.BfSectionCode.Trim(),
                                                stockAcPayHisSearchRetWork.BfEnterWarehCode.Trim());
                        //--- ADD 2008/12/15 -----------------------------------------------------------<<<<<
                        name = string.Format("{0}�F{1}",
                                                stockAcPayHisSearchRetWork.BfSectionGuideNm,
                                                stockAcPayHisSearchRetWork.BfEnterWarehName );
                    }
                    break;
                /* --- DEL 2009/03/10 �s��Ή�[12239] ------------------------------------------------------------------->>>>>
                //--- ADD 2008/12/11 ------------------------------------------------------------------->>>>>
                case 10:
                    {
                        // �d����
                        code = stockAcPayHisSearchRetWork.SupplierCd.ToString("000000");    // �d����R�[�h
                        name = stockAcPayHisSearchRetWork.SupplierSnm;                      // �d���於��
                    }
                    break;
                //--- ADD 2008/12/11 -------------------------------------------------------------------<<<<<
                // ���̑�
                default:
                    {
                        // ���Ӑ�
                        //code = stockAcPayHisSearchRetWork.CustomerCode.ToString("000000000"); // ���Ӑ�R�[�h     //DEL 2009/03/09 �s��Ή�[12241]
                        code = stockAcPayHisSearchRetWork.CustomerCode.ToString("00000000");    // ���Ӑ�R�[�h     //ADD 2009/03/09 �s��Ή�[12241]
                        name = stockAcPayHisSearchRetWork.CustomerSnm;  // ���Ӑ於��
                    }
                    break;
                   --- DEL 2009/03/10 �s��Ή�[12239] -------------------------------------------------------------------<<<<< */
                // --- ADD 2009/03/10 �s��Ή�[12239] ------------------------------------------------------------------->>>>>
                case 10:        //10:�d��
                case 11:        //11:����
                    {
                        // �d����
                        code = stockAcPayHisSearchRetWork.SupplierCd.ToString("000000");        // �d����R�[�h
                        name = stockAcPayHisSearchRetWork.SupplierSnm;                          // �d���於��
                    }
                    break;
                case 20:        //20:����
                case 22:        //22:�o��
                    {
                        // ���Ӑ�
                        code = stockAcPayHisSearchRetWork.CustomerCode.ToString("00000000");    // ���Ӑ�R�[�h     //ADD 2009/03/09 �s��Ή�[12241]
                        name = stockAcPayHisSearchRetWork.CustomerSnm;                          // ���Ӑ於��
                    }
                    break;
                default:        //���̑�
                    {
                        //�Ȃ�
                    }
                    break;
                // --- ADD 2009/03/10 �s��Ή�[12239] -------------------------------------------------------------------<<<<<
            }

            dr[DCZAI02204EA.ct_Col_AcPayOtherPartyCd] = code;
            dr[DCZAI02204EA.ct_Col_AcPayOtherPartyNm] = name;
        }
        /// <summary>
        /// �敪���̃Z�b�g����
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="stockAcPayHisSearchRetWork"></param>
        private void SetRecordDivName ( ref DataRow dr, StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork )
        {
            dr[DCZAI02204EA.ct_Col_AcPaySlipNm] = GetAcPaySlipNm( stockAcPayHisSearchRetWork.AcPaySlipCd ); // �󕥌��`�[�敪
            dr[DCZAI02204EA.ct_Col_AcPayTransNm] = GetAcPayTransNm( stockAcPayHisSearchRetWork.AcPayTransCd ); // �󕥌�����敪
        }
        /// <summary>
        /// �`�[�敪���̎擾
        /// </summary>
        /// <param name="acPaySlipCd"></param>
        /// <returns></returns>
        private string GetAcPaySlipNm(int acPaySlipCd)
        {
            if ( this._acPaySlipNmDic.ContainsKey( acPaySlipCd ) )
            {
                return this._acPaySlipNmDic[acPaySlipCd];
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ����敪���̎擾
        /// </summary>
        /// <param name="acPayTransCd"></param>
        /// <returns></returns>
        private string GetAcPayTransNm ( int acPayTransCd )
        {
            if ( this._acPayTransNmDic.ContainsKey( acPayTransCd ) )
            {
                return this._acPayTransNmDic[acPayTransCd];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// �`�[�敪���̃f�B�N�V���i������
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note : liyp 2010/11/15 </br>
        /// <br>            PM.NS �@�\���ǂp�S</br>
        private Dictionary<int, string> CreateAcPaySlipNmDictionary ()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add( 10, "�d��" );
            dic.Add( 11, "����" );
            dic.Add( 12, "��v��" );
            dic.Add( 13, "�݌Ɏd��");           //ADD 2008/12/11
            dic.Add( 20, "����" );
            dic.Add( 21, "���v��" );
            //dic.Add( 22, "�o��" );//DEL 2010/11/15
            dic.Add(22, "�ݏo");//ADD 2010/11/15
            dic.Add( 23, "����" );
            dic.Add( 30, "�ړ��o��" );
            dic.Add( 31, "�ړ�����" );
            dic.Add( 40, "����" );
            dic.Add( 41, "����" );
            //--- ADD 2008/07/03 ---------->>>>>
            dic.Add( 42, "�}�X�^�����e" );
            //--- ADD 2008/07/03 ----------<<<<<
            dic.Add( 50, "�I��");
            // --- ADD 2009/01/23 �s��Ή�[6581] --------->>>>>
            dic.Add( 60, "�g��");
            dic.Add( 61, "����");
            dic.Add( 70, "��[����");
            dic.Add( 71, "��[�o��");
            // --- ADD 2009/01/23 �s��Ή�[6581] ---------<<<<<

            return dic;
        }
        /// <summary>
        /// ����敪���̃f�B�N�V���i������
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> CreateAcPayTransNmDictionary ()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add( 10, "�ʏ�" );
            dic.Add( 11, "�ԕi" );
            dic.Add( 12, "�l��" );
            dic.Add( 20, "�ԓ`" );
            dic.Add( 21, "�폜" );
            dic.Add( 22, "����" );
            dic.Add( 30, "�݌ɐ�����" );
            dic.Add( 31, "��������" );
            dic.Add( 32, "���Ԓ���" );
            dic.Add( 33, "�s�Ǖi" );
            dic.Add( 34, "���o" );
            dic.Add( 35, "����" );
            dic.Add( 36, "�ꊇ�o�^" );
            dic.Add( 40, "�ߕs���X�V" );
            //dic.Add( 90, "���" );            //DEL 2009/01/28 �s��Ή�[10622]
            dic.Add( 90, "���E");               //ADD 2009/01/28 �s��Ή�[10622]

            return dic;
        }
        /// <summary>
        /// ���_�K�C�h���̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_�K�C�h����</returns>
        private string GetSectionGuideNm( string sectionCode )
        {
            if ( stc_SectionDic.ContainsKey( sectionCode ) ) {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else {
                return string.Empty;
            }
        }
		#endregion

		#region �� �\�[�g���쐬
		/// <summary>
		/// �\�[�g���쐬
		/// </summary>
		/// <returns>�\�[�g������</returns>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        private string GetSortOrder(StockAcPayListCndtn stockAcPayListCndtn)
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !stockAcPayListCndtn.IsSelectAllSection )
            //{
            //    // �S�БI������ĂȂ��Ƃ�
            //    // �勒�_
            //    strSortOrder.Append( string.Format("{0},", DCZAI02204EA.ct_Col_SectionCode ) );
            //}

            /* ---DEL 2008/12/09 �s��Ή�[8895]------------------------------------------->>>>>
            // ���_�R�[�h
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_SectionCode ) );
            // �q�ɃR�[�h
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_WarehouseCode ) );
            // ���[�J�[
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_GoodsMakerCd ) );
            // ���i�ԍ�
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_GoodsNo ) );
            // ���o�ד��i�~���j
            strSortOrder.Append( string.Format( "{0} DESC,", DCZAI02204EA.ct_Col_IoGoodsDay ) );
            // �`�[�ԍ��i�~���j
            strSortOrder.Append( string.Format( "{0} DESC,", DCZAI02204EA.ct_Col_AcPaySlipNum ) );
            // �s�ԍ�
            strSortOrder.Append( string.Format( "{0} ASC", DCZAI02204EA.ct_Col_AcPaySlipRowNo ) );
               ---DEL 2008/12/09 �s��Ή�[8895]-------------------------------------------<<<<< */
            /* ---DEL 2008/12/09 �s��Ή�[10622]----------------------------------------------->>>>>
            // ---ADD 2008/12/09 �s��Ή�[8895]------------------------------------------->>>>> 
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_SectionCode));        // ���_�R�[�h
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_WarehouseCode));      // �q�ɃR�[�h
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsNo));            // ���i�ԍ�
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_IoGoodsDay));         // ���o�ד�
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPaySlipCd));        // �`�[�敪
            strSortOrder.Append(string.Format("{0}",  DCZAI02204EA.ct_Col_AcPaySlipNum));       // �`�[�ԍ�
            // ---ADD 2008/12/09 �s��Ή�[8895]-------------------------------------------<<<<<
               ---DEL 2008/12/09 �s��Ή�[10622]-----------------------------------------------<<<<< */

            // ---UPD 2010/11/15 ------------------------>>>>>
            if (stockAcPayListCndtn.Sort == 0)
            {
                // ---ADD 2008/12/09 �s��Ή�[10622]----------------------------------------------->>>>> 
                //strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_SectionCode));        // ���_�R�[�h         //DEL 2009/04/07 �s��Ή�[12997]
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_WarehouseCode));      // �q�ɃR�[�h
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsNo));            // ���i�ԍ�
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsMakerCd)); // ���[�J�[
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPayHistDateTime));  // �󕥗����쐬����
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPaySlipNum));     // �󕥌��`�[�ԍ�
                strSortOrder.Append(string.Format("{0}", DCZAI02204EA.ct_Col_AcPaySlipRowNo));     // �󕥌��s�ԍ�
                // ---ADD 2008/12/09 �s��Ή�[10622]-----------------------------------------------<<<<<
            }
            else if (stockAcPayListCndtn.Sort == 1)
            {
                // �q�Ɂ����[�J�[���i�ԁ��쐬�������󕥌��`�[�ԍ����󕥌��s�ԍ�
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_WarehouseCode));      // �q�ɃR�[�h
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsMakerCd)); // ���[�J�[
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsNo));            // ���i�ԍ�
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPayHistDateTime));  // �󕥗����쐬����
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPaySlipNum));     // �󕥌��`�[�ԍ�
                strSortOrder.Append(string.Format("{0}", DCZAI02204EA.ct_Col_AcPaySlipRowNo));     // �󕥌��s�ԍ�
            }
                
            // ---UPD 2010/11/15 ------------------------<<<<<
			return strSortOrder.ToString();
		}
		#endregion

		#endregion �� �f�[�^�W�J����

		#region �� ���[�ݒ�f�[�^�擾
		#region �� ���[�o�͐ݒ�擾����
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
		/// <br>Programmer : 22018 kubo</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion �� ���[�ݒ�f�[�^�擾
		#endregion �� Private Method

		// ---ADD 2013/01/15 ------------------------>>>>>
        /// <summary>
        /// ���|�Ǘ����肩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :���|�Ǘ�����<br/>
        /// <c>false</c>:���|�Ǘ��Ȃ�
        /// </returns>
        /// <remarks>
        /// <br>Note       : USB���甃�|�I�v�V�����L����Ǎ���ŁAbool�^�ŕԂ��܂��B</br>
        /// <br>Programer  : FSI���� �G</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private static bool HasStockingPayment()
        {
            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment
            );
            return purchaseStatus >= PurchaseStatus.Contract;
        }
		// ---ADD 2013/01/15 ------------------------<<<<<
	}
}
