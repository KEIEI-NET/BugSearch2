using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �q�ɏ��e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �q�ɏ��e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class WarehousePrintSetAcs 
	{

		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        IWarehouseDB _iwarehouseDB = null;
        WarehouseLcDB _warehouseLcDB = null;

        private static bool _isLocalDBRead = false;

        /// <summary>���_���i�[�o�b�t�@</summary>
        private Hashtable _secInfTable = null;

        /// <summary>���_�q�ɖ��̊i�[�o�b�t�@</summary>
        private Hashtable _sectWarehouseNmTable = null;


        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �q�ɏ��e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �q�ɏ��e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public WarehousePrintSetAcs()
		{

            this._secInfTable = null;
            this._sectWarehouseNmTable = null;

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iwarehouseDB = (IWarehouseDB)MediationWarehouseDB.GetWarehouseDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iwarehouseDB = null;
            }

            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._warehouseLcDB = new WarehouseLcDB();   
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
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int GetOnlineMode()
		{
            if (this._iwarehouseDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
		}

		/// <summary>
		/// �q�ɏ��S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �q�ɏ��̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, WarehousePrintWork warehousePrintWork)
		{
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, 0, 0,  warehousePrintWork);
		}

		/// <summary>
        /// �q�ɏ�񌟍������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �q�ɏ��̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, WarehousePrintWork warehousePrintWork)
		{
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt,  enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0,  warehousePrintWork);
		}

		

		/// <summary>
        /// �q�ɏ�񌟍�����
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="warehousePrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �q�ɏ��̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, WarehousePrintWork warehousePrintWork)
		{

            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            retTotalCnt = 0;
            int status_o = 0;
            int checkstatus = 0;

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = warehouseWork;
            object retobj = null;

            // ���[�J��
            if (_isLocalDBRead)
            {
                List<WarehouseWork> warehouseWorkList = new List<WarehouseWork>();
                status_o = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, logicalMode);

                if (status_o == 0)
                {
                    ArrayList al = new ArrayList();
                    al.AddRange(warehouseWorkList);
                    retobj = (object)al;
                }
            }
            // �����[�g
            else
            {
                status_o = this._iwarehouseDB.Search(out retobj, paraobj, 0, logicalMode);
            }

            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        wkList = retobj as ArrayList;

                        if (wkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in wkList)
                            {
                            
                                    // ���o����
                                    checkstatus = DataCheck(wkLineupWork, warehousePrintWork);
                                    if (checkstatus == 0)
                                    {
                                        //�����o�R�s�[
                                        retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                    }
                            }

                            retTotalCnt = retList.Count;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status_o;
                    }
            }

            return status_o;
		}

        /// <summary>
        /// ���_��񌟍�
        /// </summary>
        /// <param name="sectionGuideNm"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int GetSecInf(out string sectionGuideNm, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            SecInfoSet secInfoSet = null;

            sectionGuideNm = "";

            // ���Џ��ǂݍ���
            status = ReadSecInf(out secInfoSet, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sectionGuideNm = secInfoSet.SectionGuideNm;
            }

            return status;
        }

        /// <summary>
        /// ���_���Ǎ�����
        /// </summary>
        /// <param name="SecInfoSet"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadSecInf(out SecInfoSet secInfoSet, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            secInfoSet = null;

            status = SetSecInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �ǂݍ��ݎ��s
                return status;
            }

            // �e�[�u���ɃL�[�����݂��Ă���
            if (this._secInfTable.ContainsKey(sectionCode) == true)
            {
                secInfoSet = ((SecInfoSet)this._secInfTable[sectionCode]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }           

            return status;
        }

        /// <summary>
        /// ���_��񌟍�����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetSecInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._secInfTable == null)
            {
                this._secInfTable = new Hashtable();
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._secInfTable.Clear();
                status = secInfoSetAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (this._secInfTable.ContainsKey(secInfoSet.SectionCode) == false)
                        {
                            this._secInfTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
                        }
                    }
                }

            }
            return status;
        }

        /// <summary>
        /// ���_�q�ɖ��̂̎擾����
        /// </summary>
        /// <param name="warehouseName">���_�q�ɖ���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">���_�q�ɃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�q�ɃR�[�h���狒�_�q�ɖ��̂��擾���܂�</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        /// 
        public int GetWarehouseName(out string warehouseName, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            int status = 0;
            Warehouse warehouse = null;

            warehouseName = "";

            // �q�ɏ��ǂݍ���
            status = ReadWarehouseInf(out warehouse, enterpriseCode, warehouseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                warehouseName = warehouse.WarehouseName;
            }

            return status;
        }

        /// <summary>
        /// �q�ɏ��Ǎ�����
        /// </summary>
        /// <param name="SecInfoSet"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadWarehouseInf(out Warehouse warehouse, string enterpriseCode, string warehouseCode)
        {
            int status = 0;
            warehouse = null;

            status = SetWarehouseInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �ǂݍ��ݎ��s
                return status;
            }

            // �e�[�u���ɃL�[�����݂��Ă���
            if (this._sectWarehouseNmTable.ContainsKey(warehouseCode) == true)
            {
                warehouse = ((Warehouse)this._sectWarehouseNmTable[warehouseCode]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// �q�ɏ�񌟍�����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetWarehouseInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._sectWarehouseNmTable == null)
            {
                this._sectWarehouseNmTable = new Hashtable();
                WarehouseAcs warehouseAcs = new WarehouseAcs();
                warehouseAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._sectWarehouseNmTable.Clear();
                status = warehouseAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (this._sectWarehouseNmTable.ContainsKey(warehouse.WarehouseCode.Trim()) == false)
                        {
                            this._sectWarehouseNmTable.Add(warehouse.WarehouseCode.Trim(), warehouse.Clone());
                        }
                    }
                }

            }
            return status;
        }

        /// <summary>
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private string GetCustomerName(out string customerName,string enterpriseCode,int customerCode )
        {
            customerName = "";

            int status;
            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            try
            {
                status = customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm;
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�q�ɏ�񃏁[�N�N���X�ˋ��_���N���X�j
        /// </summary>
        /// <param name="wkLineupWork">�q�ɏ�񃏁[�N�N���X</param>
        /// <returns>�q�ɏ��N���X</returns>
        /// <remarks>
        /// <br>Note       : �q�ɏ�񃏁[�N�N���X����q�ɏ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private WarehousePrintSet CopyToWarehouseFromWarehouseWork(WarehouseWork wkLineupWork)
        {

            WarehousePrintSet warehousePrintSet = new WarehousePrintSet();

            warehousePrintSet.WarehouseCode = wkLineupWork.WarehouseCode;
            warehousePrintSet.WarehouseName = wkLineupWork.WarehouseName;
            warehousePrintSet.SectionCode = wkLineupWork.SectionCode;

            // �K�C�h���̎擾
            string sectionGuideNm = null;
            GetSecInf(out sectionGuideNm, wkLineupWork.EnterpriseCode, wkLineupWork.SectionCode);
            warehousePrintSet.SectionGuideNm = sectionGuideNm;
            warehousePrintSet.CustomerCode = wkLineupWork.CustomerCode;

            // ���Ӑ於�̎擾
            string CustomerSnm=null;
            GetCustomerName(out CustomerSnm, wkLineupWork.EnterpriseCode, wkLineupWork.CustomerCode);
            warehousePrintSet.CustomerSnm = CustomerSnm;
            warehousePrintSet.MainMngWarehouseCd = wkLineupWork.MainMngWarehouseCd;

            // �D��q�ɖ��̎擾
            string warehouse = null;
            GetWarehouseName(out warehouse, wkLineupWork.EnterpriseCode,
                wkLineupWork.SectionCode, wkLineupWork.MainMngWarehouseCd.Trim().PadLeft(4,'0'));
            warehousePrintSet.MainWarehouseName = warehouse;
            warehousePrintSet.StockBlnktRemark = wkLineupWork.StockBlnktRemark;

            return warehousePrintSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="secInfoSetWork"></param>
        /// <param name="warehousePrintWork"></param>
        /// <returns></returns>
        private int DataCheck(WarehouseWork warehouseWork, WarehousePrintWork warehousePrintWork)
        {
            int status = 0;

            if (warehouseWork.LogicalDeleteCode != warehousePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = warehouseWork.UpdateDateTime.Year.ToString("0000") +
                                warehouseWork.UpdateDateTime.Month.ToString("00") +
                                warehouseWork.UpdateDateTime.Day.ToString("00");

            if (warehousePrintWork.LogicalDeleteCode == 1 &&
                warehousePrintWork.DeleteDateTimeSt != 0 &&
                warehousePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < warehousePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > warehousePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (warehousePrintWork.LogicalDeleteCode == 1 &&
                        warehousePrintWork.DeleteDateTimeSt != 0 &&
                        warehousePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < warehousePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (warehousePrintWork.LogicalDeleteCode == 1 &&
                       warehousePrintWork.DeleteDateTimeSt == 0 &&
                       warehousePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > warehousePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!warehousePrintWork.WarehouseCodeSt.Trim().Equals(string.Empty) &&
                !warehousePrintWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(warehouseWork.WarehouseCode) < Int32.Parse(warehousePrintWork.WarehouseCodeSt) ||
                   Int32.Parse(warehouseWork.WarehouseCode) > Int32.Parse(warehousePrintWork.WarehouseCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!warehousePrintWork.WarehouseCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(warehouseWork.WarehouseCode) < Int32.Parse(warehousePrintWork.WarehouseCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!warehousePrintWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(warehouseWork.WarehouseCode) > Int32.Parse(warehousePrintWork.WarehouseCodeEd))
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
