using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���i�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: �A�� 810 zhouyu </br>
    /// <br>Date       : 2011/08/12 </br>
	/// <br></br>
    /// </remarks>
	public class GoodsSetAcs 
	{

        #region �� Constructor
        /// <summary>
        /// ���i�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public GoodsSetAcs()
        {
            this._iGoodsPrintDB = (IGoodsPrintDB)MediationGoodsPrintDB.GetGoodsPrintDB();

        }

        /// <summary>
        /// ���i�}�X�^����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.15</br>
        /// </remarks>
        static GoodsSetAcs()
        {
            stc_Employee = null;
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs = new SecInfoAcs(1);         // ���_�A�N�Z�X�N���X
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // ���_Dictionary

            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // �����łȂ����
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                {
                    // �ǉ�
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
        }
        #endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // ���[�o�͐ݒ�A�N�Z�X�N���X
        private static SecInfoAcs stc_SecInfoAcs;                       // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion �� Static Member

        #region �� Private Member
        IGoodsPrintDB _iGoodsPrintDB;
        //-------------------ADD 2011/08/12---------------------->>>>>
        private Dictionary<string, GoodsMngWork> _goodsMngDic1;      //���_(�S�Ћ��ʊ܂�)�{���[�J�[�{�i��
        private Dictionary<string, GoodsMngWork> _goodsMngDic2;      //���_(�S�Ћ��ʊ܂�)�{�����ށ{���[�J�[�{�a�k
        private Dictionary<string, GoodsMngWork> _goodsMngDic3;      //���_(�S�Ћ��ʊ܂�)�{�����ށ{���[�J�[
        private Dictionary<string, GoodsMngWork> _goodsMngDic4;      //���_(�S�Ћ��ʊ܂�)�{���[�J�[
        private Dictionary<int, SupplierWork> _supplierWorkDic;      //�d����
        //-------------------ADD 2011/08/12----------------------<<<<<
        #endregion �� Private Member

		/// <summary>
		/// ���i�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, GoodsPrintWork goodsPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, goodsPrintWork);
		}

		/// <summary>
		/// ���i�}�X�^���������i�_���폜�j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, GoodsPrintWork goodsPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, goodsPrintWork);
		}


        //--------------------ADD 2011/08/12--------------------->>>>>
        /// <summary>
        ///  ���i�Ǘ����擾�����Ǝd����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       :  ���i�Ǘ����擾�����Ǝd������s���܂��B</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        private int SetGoodsMsgSupplier(string enterpriseCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            object retObj = null;
            status = this._iGoodsPrintDB.SearchGoodsMsgSpler(ref retObj, enterpriseCode, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (retObj is ArrayList)
                {
                    _goodsMngDic1 = new Dictionary<string, GoodsMngWork>();     //���_�{���[�J�[�{�i��
                    _goodsMngDic2 = new Dictionary<string, GoodsMngWork>();     //���_�{�����ށ{���[�J�[�{�a�k
                    _goodsMngDic3 = new Dictionary<string, GoodsMngWork>();     //���_�{�����ށ{���[�J�[
                    _goodsMngDic4 = new Dictionary<string, GoodsMngWork>();     //���_�{���[�J�[
                    _supplierWorkDic = new Dictionary<int, SupplierWork>();  // �d����
                    ArrayList workList = retObj as ArrayList;
                    foreach (object obj in  workList)
                    {
                        if (obj is GoodsMngWork)
                        {
                            GoodsMngWork goodsMngWork = obj as GoodsMngWork;
                            StringBuilder goodsMngDic1Key = new StringBuilder();
                            StringBuilder goodsMngDic2Key = new StringBuilder();
                            StringBuilder goodsMngDic3Key = new StringBuilder();
                            StringBuilder goodsMngDic4Key = new StringBuilder();

                            goodsMngDic4Key.Append(goodsMngWork.SectionCode.Trim().PadLeft(2, '0'));     //���_
                            goodsMngDic4Key.Append(goodsMngWork.GoodsMakerCd.ToString("0000"));         //���[�J�[

                            if (goodsMngWork.GoodsNo.Trim() != string.Empty)
                            {
                                goodsMngDic1Key.Append(goodsMngDic4Key.ToString());                         //���_�{���[�J�[
                                goodsMngDic1Key.Append(goodsMngWork.GoodsNo.Trim());                    //�i��

                                //���_�{���[�J�[�{�i��
                                if (!_goodsMngDic1.ContainsKey(goodsMngDic1Key.ToString()))
                                {
                                    _goodsMngDic1.Add(goodsMngDic1Key.ToString(), goodsMngWork);
                                }
                            }
                            else
                            {
                                goodsMngDic3Key.Append(goodsMngDic4Key.ToString());                         //���_�{���[�J�[
                                goodsMngDic3Key.Append(goodsMngWork.GoodsMGroup.ToString("0000"));      //������

                                goodsMngDic2Key.Append(goodsMngDic3Key.ToString());                         //���_�{���[�J�[�{������
                                goodsMngDic2Key.Append(goodsMngWork.BLGoodsCode.ToString("00000"));     //�a�k

                                if (goodsMngWork.BLGoodsCode != 0)
                                {
                                    //���_�{�����ށ{���[�J�[�{�a�k
                                    if (!_goodsMngDic2.ContainsKey(goodsMngDic2Key.ToString()))
                                    {
                                        _goodsMngDic2.Add(goodsMngDic2Key.ToString(), goodsMngWork);
                                    }
                                }
                                else if (goodsMngWork.GoodsMGroup != 0)
                                {
                                    //���_�{�����ށ{���[�J�[
                                    if (!_goodsMngDic3.ContainsKey(goodsMngDic3Key.ToString()))
                                    {
                                        _goodsMngDic3.Add(goodsMngDic3Key.ToString(), goodsMngWork);
                                    }
                                }
                                else
                                {
                                    //���_�{���[�J�[
                                    if (!_goodsMngDic4.ContainsKey(goodsMngDic4Key.ToString()))
                                    {
                                        _goodsMngDic4.Add(goodsMngDic4Key.ToString(), goodsMngWork);
                                    }
                                }
                            }
                        }
                        if (obj is SupplierWork)
                        {
                            SupplierWork supplierWork = obj as SupplierWork;
                            _supplierWorkDic.Add(supplierWork.SupplierCd, supplierWork);
                        }
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ���i�Ǘ����Ǝd����ǉ�����
        /// </summary>
        /// <param name="goodsPrintResultWork">���i�}�X�^</param>
        /// <returns>GoodsPrintResultWork</returns>
        /// <remarks>
        /// <br>Note       :  ���i�Ǘ����Ǝd����ǉ��������s���܂��B</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        private GoodsPrintResultWork AddSupplierFormGoodsMsg(GoodsPrintResultWork goodsPrintResultWork)
        {
            //���_�{���[�J�[
            StringBuilder goodsMngDic4key = new StringBuilder();
            goodsMngDic4key.Append(goodsPrintResultWork.SectionCode.Trim().PadLeft(2, '0'));
            goodsMngDic4key.Append(goodsPrintResultWork.GoodsMakerCd.ToString("0000"));
            //�y���_�{���[�J�[�z�{�i��
            StringBuilder goodsMngDic1key = new StringBuilder();
            goodsMngDic1key.Append(goodsMngDic4key.ToString());
            goodsMngDic1key.Append(goodsPrintResultWork.GoodsNo.Trim());

            //1.���_�{���[�J�[�{�i��
            if (_goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic1[goodsMngDic1key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic1[goodsMngDic1key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //�S�Ё{���[�J�[
            StringBuilder goodsMngDic8key = new StringBuilder();
            goodsMngDic8key.Append("00");
            goodsMngDic8key.Append(goodsPrintResultWork.GoodsMakerCd.ToString("0000"));
            //�y�S�Ё{���[�J�[�z�{�i��
            StringBuilder goodsMngDic5key = new StringBuilder();
            goodsMngDic5key.Append(goodsMngDic8key.ToString());
            goodsMngDic5key.Append(goodsPrintResultWork.GoodsNo.Trim());

            //2.�S�Ё{���[�J�[�{�i��
            if (_goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic1[goodsMngDic5key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic1[goodsMngDic5key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //�y���_�{���[�J�[�z�{������
            StringBuilder goodsMngDic3key = new StringBuilder();
            goodsMngDic3key.Append(goodsMngDic4key.ToString());
            goodsMngDic3key.Append(goodsPrintResultWork.GoodsRateGrpCode.ToString("0000"));
            //�y���_�{���[�J�[�{�����ށz�{�a�k
            StringBuilder goodsMngDic2key = new StringBuilder();
            goodsMngDic2key.Append(goodsMngDic3key.ToString());
            goodsMngDic2key.Append(goodsPrintResultWork.BLGoodsCode.ToString("00000"));

            //3.���_�{�����ށ{���[�J�[�{�a�k
            if (_goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic2[goodsMngDic2key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic2[goodsMngDic2key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //�y�S�Ё{���[�J�[�z�{������
            StringBuilder goodsMngDic7key = new StringBuilder();
            goodsMngDic7key.Append(goodsMngDic8key.ToString());
            goodsMngDic7key.Append(goodsPrintResultWork.GoodsRateGrpCode.ToString("0000"));
            //�y�S�Ё{���[�J�[�{�����ށz�{�a�k
            StringBuilder goodsMngDic6key = new StringBuilder();
            goodsMngDic6key.Append(goodsMngDic7key.ToString());
            goodsMngDic6key.Append(goodsPrintResultWork.BLGoodsCode.ToString("00000"));

            //4.�S�Ё{�����ށ{���[�J�[�{�a�k
            if (_goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic2[goodsMngDic6key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic2[goodsMngDic6key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //5.���_�{�����ށ{���[�J�[
            if (_goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic3[goodsMngDic3key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic3[goodsMngDic3key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //6.�S�Ё{�����ށ{���[�J�[
            if (_goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic3[goodsMngDic7key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic3[goodsMngDic7key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //7.���_�{���[�J�[
            if (_goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic4[goodsMngDic4key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic4[goodsMngDic4key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //8.�S�Ё{���[�J�[
            if (_goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic4[goodsMngDic8key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic4[goodsMngDic8key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }
            return null;
        }
        //--------------------ADD 2011/08/12---------------------<<<<<

        /// <summary>
        /// ���i�}�X�^��������
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
        /// <br>Note       : ���i�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsPrintWork goodsPrintWork)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            try
            {   

                GoodsPrintParamWork goodsPrintParamWork = new GoodsPrintParamWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevReatCndtn(goodsPrintWork, enterpriseCode, out goodsPrintParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }
                //---------------ADD 2011/08/12------------------->>>>>
                //���i�Ǘ����擾�����Ǝd����  -----------------------------------------------
                status = this.SetGoodsMsgSupplier(enterpriseCode);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }
                //---------------ADD 2011/08/12-------------------<<<<<

                // �f�[�^�擾  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iGoodsPrintDB.Search(out retReatList, goodsPrintParamWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        //-------------------ADD 2011/08/12---------------------->>>>>
                        ArrayList goodsPrintResultWorkList = new ArrayList();
                        foreach (GoodsPrintResultWork goodsPrintResultWork in (ArrayList)retReatList)
                        {
                            // �S�Ћ���
                            goodsPrintResultWork.SectionCode = "00";
                            GoodsPrintResultWork goodsPrintResultWork1 = this.AddSupplierFormGoodsMsg(goodsPrintResultWork);
                            if (goodsPrintResultWork1 != null)
                                goodsPrintResultWorkList.Add(goodsPrintResultWork1);

                            //���Ђ̃f�[�^
                            goodsPrintResultWork.SectionCode = stc_Employee.BelongSectionCode;
                            GoodsPrintResultWork goodsPrintResultWork2 = this.AddSupplierFormGoodsMsg(goodsPrintResultWork);
                            if (goodsPrintResultWork2 != null)
                                goodsPrintResultWorkList.Add(goodsPrintResultWork2);
                        }
                        //-------------------ADD 2011/08/12----------------------<<<<<
                        // �f�[�^�W�J����
                        //DevReatData(goodsPrintWork, (ArrayList)retReatList, out retList); //DEL 2011/08/12
                        DevReatData(goodsPrintWork, goodsPrintResultWorkList, out retList); //ADD 2011/08/12

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {                            
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch 
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;

        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="goodsPrintWork">UI���o�����N���X</param>
        /// <param name="goodsPrintParamWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(GoodsPrintWork goodsPrintWork, string enterpriseCode, out GoodsPrintParamWork goodsPrintParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            goodsPrintParamWork = new GoodsPrintParamWork();
            try
            {
                goodsPrintParamWork.EnterpriseCode = enterpriseCode;  // ��ƃR�[�h
                // ���o�����p�����[�^�Z�b�g
                goodsPrintParamWork.SectionCode = null;
                goodsPrintParamWork.SupplierCdSt = goodsPrintWork.SupplierCdSt;
                if (goodsPrintWork.SupplierCdEd == 0)
                {
                    goodsPrintParamWork.SupplierCdEd = 999999;
                }
                else
                {
                    goodsPrintParamWork.SupplierCdEd = goodsPrintWork.SupplierCdEd;
                }
                goodsPrintParamWork.GoodsMakerCdSt = goodsPrintWork.GoodsMakerCdSt;
                if (goodsPrintWork.GoodsMakerCdEd == 0)
                {
                    goodsPrintParamWork.GoodsMakerCdEd = 9999;
                }
                else
                {
                    goodsPrintParamWork.GoodsMakerCdEd = goodsPrintWork.GoodsMakerCdEd;
                }
                goodsPrintParamWork.BLGoodsCodeSt = goodsPrintWork.BLGoodsCodeSt;
                if (goodsPrintWork.BLGoodsCodeEd == 0)
                {
                    goodsPrintParamWork.BLGoodsCodeEd = 99999;
                }
                else
                {
                    goodsPrintParamWork.BLGoodsCodeEd = goodsPrintWork.BLGoodsCodeEd;
                }
                goodsPrintParamWork.GoodsNoSt = goodsPrintWork.GoodsNoSt;
                goodsPrintParamWork.GoodsNoEd = goodsPrintWork.GoodsNoEd;
                goodsPrintParamWork.ListPrice = goodsPrintWork.ListPrice;
                goodsPrintParamWork.ListPriceDiv = goodsPrintWork.ListPriceDiv;
                goodsPrintParamWork.SalesUnitCost = goodsPrintWork.SalesUnitCost;
                goodsPrintParamWork.SalesUnitCostDiv = goodsPrintWork.SalesUnitCostDiv;
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="goodsPrintWork">UI���o�����N���X</param>
        /// <param name="retaWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void DevReatData(GoodsPrintWork goodsPrintWork, ArrayList retaWork, out ArrayList retList)
        {
            
            retList = new ArrayList();

            foreach (GoodsPrintResultWork goodsPrintResultWork in retaWork)
            {
                if (DataCheck(goodsPrintResultWork, goodsPrintWork)==0)
                {
                    GoodsSet goodsSet = new GoodsSet();

                    goodsSet.UpdateDateTime = goodsPrintResultWork.UpdateDateTime;
                    goodsSet.GoodsMakerCd = goodsPrintResultWork.GoodsMakerCd;
                    goodsSet.MakerShortName = goodsPrintResultWork.MakerShortName;
                    goodsSet.GoodsNo = goodsPrintResultWork.GoodsNo;
                    goodsSet.BLGoodsCode = goodsPrintResultWork.BLGoodsCode;
                    goodsSet.GoodsName = goodsPrintResultWork.GoodsName;
                    goodsSet.SupplierCd = goodsPrintResultWork.SupplierCd;
                    goodsSet.SupplierSnm = goodsPrintResultWork.SupplierSnm;
                    goodsSet.ListPrice = goodsPrintResultWork.ListPrice;
                    goodsSet.StockRate = goodsPrintResultWork.StockRate;
                    goodsSet.SalesUnitCost = goodsPrintResultWork.SalesUnitCost;
                    goodsSet.GoodsRateRank = goodsPrintResultWork.GoodsRateRank;
                    goodsSet.SupplierLot = goodsPrintResultWork.SupplierLot;
                    goodsSet.GoodsSpecialNote = goodsPrintResultWork.GoodsSpecialNote;
                    goodsSet.GoodsNote1 = goodsPrintResultWork.GoodsNote1;
                    goodsSet.GoodsNote2 = goodsPrintResultWork.GoodsNote2;
                    goodsSet.PriceStartDate = goodsPrintResultWork.PriceStartDate;
                    goodsSet.NewListPrice = goodsPrintResultWork.NewListPrice;
                    goodsSet.GoodsKindCode = goodsPrintResultWork.GoodsKindCode;
                    goodsSet.TaxationDivCd = goodsPrintResultWork.TaxationDivCd;
                    goodsSet.EnterpriseGanreCode = goodsPrintResultWork.EnterpriseGanreCode;
                    goodsSet.EnterpriseGanreCodeName = goodsPrintResultWork.EnterpriseGanreCodeName;
                    goodsSet.OfferDataDiv = goodsPrintResultWork.OfferDataDiv;

                    retList.Add(goodsSet);
                }
                
            }

        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(GoodsPrintResultWork goodsPrintResultWork, GoodsPrintWork goodsPrintWork)
        {
            int status = 0;

            string upDateTime = goodsPrintResultWork.UpdateDateTime.Year.ToString("0000") +
                                goodsPrintResultWork.UpdateDateTime.Month.ToString("00") +
                                goodsPrintResultWork.UpdateDateTime.Day.ToString("00");

            if (goodsPrintWork.LogicalDeleteCode == 1 &&
                goodsPrintWork.DeleteDateTimeSt != 0 &&
                goodsPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < goodsPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > goodsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsPrintWork.LogicalDeleteCode == 1 &&
                        goodsPrintWork.DeleteDateTimeSt != 0 &&
                        goodsPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < goodsPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsPrintWork.LogicalDeleteCode == 1 &&
                      goodsPrintWork.DeleteDateTimeSt == 0 &&
                      goodsPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > goodsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // �S�Ћ��ʖ��́A���Ђ̃f�[�^�݂̂�ΏۂƂ���
            // DEL 2008/11/27 �s��Ή�[8324] ---------->>>>>
            //if (goodsPrintResultWork.SectionCode.Trim() != "00" &&
            //   goodsPrintResultWork.SectionCode != stc_Employee.BelongSectionCode)
            // DEL 2008/11/27 �s��Ή�[8324] ----------<<<<<
            // ADD 2008/11/27 �s��Ή�[8324] ---------->>>>>
            if (goodsPrintResultWork.SectionCode.Trim() != "" &&
                goodsPrintResultWork.SectionCode.Trim() != "00" &&
               goodsPrintResultWork.SectionCode != stc_Employee.BelongSectionCode)
            // ADD 2008/11/27 �s��Ή�[8324] ----------<<<<<
            {

                status = -1;
                return status;
            }

            // �V�X�e�����t�ȑO�̃f�[�^�݂̂�ΏۂƂ���
            if (goodsPrintResultWork.PriceStartDate > DateTime.Today)
            {
                status = -1;
                return status;
            }
            //-----------------ADD 2011/08/12---------------------->>>>>
            //�d����R�[�h
            if (goodsPrintWork.SupplierCdSt != 0)
            {
                if (goodsPrintResultWork.SupplierCd < goodsPrintWork.SupplierCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            if ((goodsPrintWork.SupplierCdEd != 0) && (goodsPrintWork.SupplierCdEd != 999999))
            {
                if (goodsPrintResultWork.SupplierCd > goodsPrintWork.SupplierCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            //-----------------ADD 2011/08/12---------------------->>>>>
            return status;
        }
    }
}
