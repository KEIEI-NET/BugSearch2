using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
//using Broadleaf.Library.Globarization;
//using Broadleaf.Application.Remoting;
//using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Windows.Forms;
//using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d����}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d����}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class SupplierSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private SupplierAcs _supplierAcs;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �d����}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d����}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public SupplierSetAcs()
		{

			
        }

        

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

	

		/// <summary>
		/// �d����}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, SupplierPrintWork supplierPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, supplierPrintWork);
		}

		/// <summary>
		/// �d����}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SupplierPrintWork supplierPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, supplierPrintWork);
		}

		

		/// <summary>
		/// �d����}�X�^��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="sectionPrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d����}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SupplierPrintWork supplierPrintWork)
		{

            this._supplierAcs = new SupplierAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList suppliers = null;

            if (logicalMode == ConstantManagement.LogicalMode.GetData01)
            {
                status = this._supplierAcs.SearchAll(
                                out suppliers,
                                enterpriseCode);
            }
            else
            {
                status = this._supplierAcs.Search(
                                out suppliers,
                                enterpriseCode);
            }

            foreach (Supplier supplier in suppliers)
            {
                // ���o����
                checkstatus = DataCheck(supplier, supplierPrintWork);
                if (checkstatus == 0)
                {

                    //�d������N���X�փ����o�R�s�[
                    retList.Add(CopyToSupplierSetFromSecInfoSetWork(supplier, enterpriseCode));

                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d����}�X�^���[�N�N���X�ˎd����}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">�d����}�X�^���[�N�N���X</param>
        /// <returns>�d����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^���[�N�N���X����d����}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private SupplierSet CopyToSupplierSetFromSecInfoSetWork(Supplier supplier, string enterpriseCode)
        {

            SupplierSet supplierSet = new SupplierSet();

            supplierSet.SupplierCd = supplier.SupplierCd;
            supplierSet.SupplierSnm = supplier.SupplierSnm;
            supplierSet.SupplierKana = supplier.SupplierKana;
            supplierSet.SupplierTelNo = supplier.SupplierTelNo;
            supplierSet.SupplierTelNo1 = supplier.SupplierTelNo1;
            supplierSet.SupplierTelNo2 = supplier.SupplierTelNo2;
            supplierSet.SupplierPostNo = supplier.SupplierPostNo;
            supplierSet.SupplierAddr1 = supplier.SupplierAddr1;
            supplierSet.SupplierAddr3 = supplier.SupplierAddr3;
            supplierSet.SupplierAddr4 = supplier.SupplierAddr4;
            supplierSet.PaymentTotalDay = supplier.PaymentTotalDay;
            supplierSet.PaymentCond = supplier.PaymentCond;
            supplierSet.PaymentMonthName = supplier.PaymentMonthName;
            supplierSet.PaymentDay = supplier.PaymentDay;
            supplierSet.StockAgentCode = supplier.StockAgentCode;
            supplierSet.StockAgentName = supplier.StockAgentName;
            supplierSet.MngSectionCode = supplier.MngSectionCode;
            supplierSet.SectionGuideNm = supplier.MngSectionName;
            supplierSet.PaymentSectionCode = supplier.PaymentSectionCode;
            supplierSet.PayeeCode = supplier.PayeeCode;
            supplierSet.PayeeSnm = supplier.PayeeSnm;


            return supplierSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(Supplier supplier, SupplierPrintWork supplierPrintWork)
        {
            int status = 0;

            if (supplier.LogicalDeleteCode != supplierPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = supplier.UpdateDateTime.Year.ToString("0000") +
                                supplier.UpdateDateTime.Month.ToString("00") +
                                supplier.UpdateDateTime.Day.ToString("00");

            if (supplierPrintWork.LogicalDeleteCode == 1 &&
                supplierPrintWork.DeleteDateTimeSt != 0 &&
                supplierPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < supplierPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > supplierPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.LogicalDeleteCode == 1 &&
                        supplierPrintWork.DeleteDateTimeSt != 0 &&
                        supplierPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < supplierPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.LogicalDeleteCode == 1 &&
                     supplierPrintWork.DeleteDateTimeSt == 0 &&
                     supplierPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > supplierPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (supplierPrintWork.SupplierCdSt != 0 &&
                supplierPrintWork.SupplierCdEd != 0)
            {
                if (supplier.SupplierCd < supplierPrintWork.SupplierCdSt ||
                   supplier.SupplierCd > supplierPrintWork.SupplierCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.SupplierCdSt != 0)
            {
                if (supplier.SupplierCd < supplierPrintWork.SupplierCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.SupplierCdEd != 0)
            {
                if (supplier.SupplierCd > supplierPrintWork.SupplierCdEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!supplierPrintWork.SupplierKanaSt.Trim().Equals(string.Empty) &&
                !supplierPrintWork.SupplierKanaEd.Trim().Equals(string.Empty))
            {
                if (supplierPrintWork.SupplierKanaSt.CompareTo(supplier.SupplierKana) > 0 ||
                    supplierPrintWork.SupplierKanaEd.CompareTo(supplier.SupplierKana) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!supplierPrintWork.SupplierKanaSt.Trim().Equals(string.Empty))
            {
                if (supplierPrintWork.SupplierKanaSt.CompareTo(supplier.SupplierKana) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!supplierPrintWork.SupplierKanaEd.Trim().Equals(string.Empty))
            {
                if (supplierPrintWork.SupplierKanaEd.CompareTo(supplier.SupplierKana) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }
}
