using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�ʖڕW�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note			 : ���i�ʖڕW�}�X�^�ւ̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer		 : NEPCO</br>
    /// <br>Date			 : 2007.05.08</br>
	/// <br>Update Note		 : 2007.11.21 ��� �O�M</br>
	/// <br>                   ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// <br></br>
    /// </remarks>
    public class GcdSalesTargetAcs
    {
        #region Public EnumerationTypes
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�����C�����[�h�̗񋓌^�ł��B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }
        #endregion

        #region Private Member

        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���_�R�[�h
        private string _sectionCode;

        ///// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IGcdSalesTargetDB _iGcdSalesTargetDB = null;

        private GoodsAcs _goodsAcs;

//----- ueno add---------- start 2007.11.21
		// ���[�J�[�R�[�h�A�N�Z�X�N���X
		private MakerAcs _makerAcs;
//----- ueno add---------- end   2007.11.21

        private int _goodsAcsStatus;

        #endregion Private Member

        #region Constructor
        /// <summary>
        /// �ڕW�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �����[�g�I�u�W�F�N�g���C���X�^���X�����܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public GcdSalesTargetAcs()
        {
            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            SecInfoSet secInfoSet;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            this._sectionCode = secInfoSet.SectionCode.TrimEnd();

            // �I�����C���̏ꍇ
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iGcdSalesTargetDB = (IGcdSalesTargetDB)MediationGcdSalesTargetDB.GetGcdSalesTargetDB();
                }
                catch (Exception)
                {
                    // �I�t���C������null���Z�b�g
                    this._iGcdSalesTargetDB = null;
                }

                this._goodsAcs = new GoodsAcs();

//----- ueno add---------- start 2007.11.21
				// ���[�J�[�R�[�h�A�N�Z�X�N���X
				this._makerAcs = new MakerAcs();
//----- ueno add---------- end   2007.11.21

                string msg;
                try
                {

                    this._goodsAcsStatus = this._goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out msg);
                }
                catch (Exception ex)
                {
                    string ms = ex.Message;

                }
            }
            else
            // �I�t���C���̏ꍇ
            {
                // �I�t���C������null���Z�b�g
                this._iGcdSalesTargetDB = null;
            }
        }

        #endregion Constructor

        #region Public Methods
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note	   : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iGcdSalesTargetDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="gcdSalesTarget">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Write(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            GcdSalesTargetWork gcdSalesTargetWork;
            ArrayList paraList = new ArrayList();

            // ���i�}�X�^�������`�F�b�N
            if (this._goodsAcsStatus != 0)
            {
                return (this._goodsAcsStatus);
            }

            // UI�f�[�^�N���X�����[�N
            foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
            {
                gcdSalesTargetWork = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget);
                paraList.Add(gcdSalesTargetWork);
            }

            object paraobj = paraList;

            int status = 0;
            try
            {
                // �������ݏ���
                status = this._iGcdSalesTargetDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }

                // ���[�N��UI�f�[�^�N���X
                GoodsUnitData goodsUnitData;
                paraList = (ArrayList)paraobj;
                GcdSalesTarget gcdSalesTarget2;
                gcdSalesTargetList.Clear();

//----- ueno upd---------- start 2007.11.21
                string goodsMakerName = "";	// ���[�J�[����
                string goodsName = "";		// ���i����
                
                foreach (GcdSalesTargetWork gcdSalesTargetWork2 in paraList)
                {
                    if (gcdSalesTargetWork2.GoodsMakerCd != 0)
                    {
                        //���[�J�[�R�[�h�L��ŏ��i�R�[�h�����̏ꍇ�A���[�J�[�}�X�^����������
                        if (gcdSalesTargetWork2.GoodsNo == "")
                        //if (gcdSalesTargetWork2.GoodsNo == "")
                        {
                            MakerUMnt makerUMnt = null;
                            status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, gcdSalesTargetWork2.GoodsMakerCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = makerUMnt.MakerShortName;
                            goodsName = "";
                        }
                        // ���[�J�[�R�[�h�A���i�R�[�h�L��̏ꍇ���i�}�X�^����������
                        else
                        {
                            status = this._goodsAcs.Read(this._enterpriseCode, gcdSalesTargetWork2.GoodsMakerCd, gcdSalesTargetWork2.GoodsNo, out goodsUnitData);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = goodsUnitData.MakerName;
                            goodsName = goodsUnitData.GoodsName;
                        }
                    }
                        gcdSalesTarget2 = CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork2, goodsName, goodsMakerName);
                        gcdSalesTargetList.Add(gcdSalesTarget2);
                }
//----- ueno upd---------- end   2007.11.21

                return (0);

            }
            catch (Exception)
            {
                // �ʐM�G���[��-1��߂�
                return (-1);
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="gcdSalesTargetList">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �폜�������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Delete(List<GcdSalesTarget> gcdSalesTargetList)
        {
            GcdSalesTargetWork[] gcdSalesTargetWorkList;
            gcdSalesTargetWorkList = new GcdSalesTargetWork[gcdSalesTargetList.Count];

            // UI�f�[�^�N���X�����[�N
            for (int index = 0; index < gcdSalesTargetList.Count; index++)
            {
                gcdSalesTargetWorkList[index] = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTargetList[index]);
            }

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(gcdSalesTargetWorkList);

            int status = 0;
            try
            {
                // �������ݏ���
                status = this._iGcdSalesTargetDB.Delete(parabyte);
                if (status != 0)
                {
                    return (status);
                }
                // static�폜

                return (0);
            }
            catch (Exception)
            {
                // �ʐM�G���[��-1��߂�
                return (-1);
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">���X�g</param>
        /// <param name="extrInfo">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �����������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Search(
            out List<GcdSalesTarget> retList,
            ExtrInfo_MAMOK09137EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status;

            retList = new List<GcdSalesTarget>();

            // ���i�}�X�^�������`�F�b�N
            if (this._goodsAcsStatus != 0)
            {
                return (this._goodsAcsStatus);
            }

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // �p�����[�^
                    SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork = new SearchGcdSalesTargetParaWork();
                    searchGcdSalesTargetParaWork.EnterpriseCode = extrInfo.EnterpriseCode;
                    searchGcdSalesTargetParaWork.SelectSectCd = extrInfo.SelectSectCd;
                    searchGcdSalesTargetParaWork.AllSecSelEpUnit = extrInfo.AllSecSelEpUnit;
                    searchGcdSalesTargetParaWork.AllSecSelSecUnit = extrInfo.AllSecSelSecUnit;
                    searchGcdSalesTargetParaWork.TargetSetCd = extrInfo.TargetSetCd;
                    searchGcdSalesTargetParaWork.TargetContrastCd = extrInfo.TargetContrastCd;
                    searchGcdSalesTargetParaWork.TargetDivideCode = extrInfo.TargetDivideCode;
                    searchGcdSalesTargetParaWork.TargetDivideName = extrInfo.TargetDivideName;
                    searchGcdSalesTargetParaWork.StartApplyStaDate = extrInfo.ApplyStaDateSt;
                    searchGcdSalesTargetParaWork.EndApplyStaDate = extrInfo.ApplyStaDateEd;
                    searchGcdSalesTargetParaWork.StartApplyEndDate = extrInfo.ApplyEndDateSt;
                    searchGcdSalesTargetParaWork.EndApplyEndDate = extrInfo.ApplyEndDateEd;
					//----- ueno del---------- start 2007.11.21
					//searchGcdSalesTargetParaWork.CarrierCode = extrInfo.CarrierCode;
                    //searchGcdSalesTargetParaWork.CellphoneModelCode = extrInfo.CellphoneModelCode;
					//----- ueno del---------- end   2007.11.21
                    searchGcdSalesTargetParaWork.GoodsMakerCd = extrInfo.MakerCode;
                    searchGcdSalesTargetParaWork.GoodsNo = extrInfo.GoodsCode;

                    searchGcdSalesTargetParaWork.BLGoodsCode = extrInfo.BLCode;
                    searchGcdSalesTargetParaWork.BLGroupCode = extrInfo.BLGroupCode;
                    searchGcdSalesTargetParaWork.SalesCode = extrInfo.SalesTypeCode;
                    

                    // �ڕW�}�X�^����
                    object objectGcdSalesTargetWork = null;
                    status = this._iGcdSalesTargetDB.Search(out objectGcdSalesTargetWork, searchGcdSalesTargetParaWork, 0, logicalMode);
                    if (status != 0)
                    {
                        return (status);
                    }

                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList paraList = objectGcdSalesTargetWork as ArrayList;
                    if (paraList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }
//----- ueno upd---------- start 2007.11.21
					string goodsMakerName = "";	// ���[�J�[����
					string goodsName = "";		// ���i����

                    // �f�[�^�ϊ�
                    GoodsUnitData goodsUnitData;
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in paraList)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA MODIFY START
                        //���[�J�[�R�[�h�L��ŏ��i�R�[�h�����̏ꍇ�A���[�J�[�}�X�^����������
                        if (gcdSalesTargetWork.GoodsMakerCd != 0 && gcdSalesTargetWork.GoodsNo == "")
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA MODIFY END
                        {
                            MakerUMnt makerUMnt = null;
                            status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, gcdSalesTargetWork.GoodsMakerCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = makerUMnt.MakerShortName;
                            goodsName = "";
                        }
                        // ���[�J�[�R�[�h�A���i�R�[�h�L��̏ꍇ���i�}�X�^����������
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA MODIFY START
                        else if (gcdSalesTargetWork.GoodsMakerCd != 0 && !String.IsNullOrEmpty(gcdSalesTargetWork.GoodsNo))
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA MODIFY END
                        {
                            status = this._goodsAcs.Read(this._enterpriseCode, gcdSalesTargetWork.GoodsMakerCd, gcdSalesTargetWork.GoodsNo, out goodsUnitData);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = goodsUnitData.MakerName;
                            goodsName = goodsUnitData.GoodsName;
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA MODIFY START
                        // ���[�J�[����я��i�R�[�h����̏ꍇ�͕ϊ������ɋ󔒂̂܂ܒǉ�����
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA MODIFY END
                        retList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork, goodsName, goodsMakerName));
//----- ueno upd---------- end   2007.11.21
                    }
                }
                catch
                {
                    return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                }

                return ((int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL);

            }
        }

        #endregion

        # region Private Methods

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^���[�N�N���X�˖ڕW�}�X�^�N���X�j
        /// </summary>
        /// <param name="gcdSalesTargetWork">�ڕW�}�X�^���[�N�N���X</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="goodsMakerName">���[�J�[����</param>
        /// <returns>�ڕW�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^���[�N�N���X����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
		private GcdSalesTarget CopyToGcdSalesTargetFromGcdSalesTargetWork(GcdSalesTargetWork gcdSalesTargetWork, string goodsName, string goodsMakerName)
        {
            GcdSalesTarget gcdSalesTarget = new GcdSalesTarget();

            gcdSalesTarget.CreateDateTime = gcdSalesTargetWork.CreateDateTime;
            gcdSalesTarget.UpdateDateTime = gcdSalesTargetWork.UpdateDateTime;
            gcdSalesTarget.EnterpriseCode = gcdSalesTargetWork.EnterpriseCode;
            gcdSalesTarget.FileHeaderGuid = gcdSalesTargetWork.FileHeaderGuid;
            gcdSalesTarget.UpdEmployeeCode = gcdSalesTargetWork.UpdEmployeeCode;
            gcdSalesTarget.UpdAssemblyId1 = gcdSalesTargetWork.UpdAssemblyId1;
            gcdSalesTarget.UpdAssemblyId2 = gcdSalesTargetWork.UpdAssemblyId2;
            gcdSalesTarget.LogicalDeleteCode = gcdSalesTargetWork.LogicalDeleteCode;

            gcdSalesTarget.SectionCode = gcdSalesTargetWork.SectionCode;
            gcdSalesTarget.TargetSetCd = gcdSalesTargetWork.TargetSetCd;
            gcdSalesTarget.TargetContrastCd = gcdSalesTargetWork.TargetContrastCd;
            gcdSalesTarget.TargetDivideCode = gcdSalesTargetWork.TargetDivideCode;
            gcdSalesTarget.TargetDivideName = gcdSalesTargetWork.TargetDivideName;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTarget.CarrierCode = gcdSalesTargetWork.CarrierCode;
            //gcdSalesTarget.CellphoneModelCode = gcdSalesTargetWork.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            gcdSalesTarget.MakerCode = gcdSalesTargetWork.GoodsMakerCd;
            gcdSalesTarget.GoodsCode = gcdSalesTargetWork.GoodsNo;
            gcdSalesTarget.ApplyStaDate = gcdSalesTargetWork.ApplyStaDate;
            gcdSalesTarget.ApplyEndDate = gcdSalesTargetWork.ApplyEndDate;
            gcdSalesTarget.GcdSalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney;
            gcdSalesTarget.GcdSalesTargetProfit = gcdSalesTargetWork.SalesTargetProfit;
            gcdSalesTarget.GcdSalesTargetCount = gcdSalesTargetWork.SalesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTarget.WeekdayRatio = gcdSalesTargetWork.WeekdayRatio;
            //gcdSalesTarget.SatSunRatio = gcdSalesTargetWork.SatSunRatio;
			//----- ueno del---------- end   2007.11.21            

			//----- ueno upd---------- start 2007.11.21
			// ���i����
			gcdSalesTarget.GoodsName = goodsName;
            // ���[�J�[����
			gcdSalesTarget.MakerName = goodsMakerName;
			//----- ueno upd---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
            // �L�����A����
            //gcdSalesTarget.CarrierName = goodsUnitData.CarrierName;
            // �@�햼��
            //gcdSalesTarget.CellphoneModelName = goodsUnitData.CellphoneModelName;
			//----- ueno del---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            gcdSalesTarget.BLGroupCode = gcdSalesTargetWork.BLGroupCode;
            gcdSalesTarget.BLCode = gcdSalesTargetWork.BLGoodsCode;
            gcdSalesTarget.SalesTypeCode = gcdSalesTargetWork.SalesCode;
            gcdSalesTarget.ItemTypeCode = gcdSalesTargetWork.EnterpriseGanreCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

            return gcdSalesTarget;
        }

        ///*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˖ڕW�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="gcdSalesTarget">�ڕW�}�X�^�N���X</param>
        /// <returns>�ڕW�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�N���X����ڕW�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private GcdSalesTargetWork CopyToGcdSalesTargetWorkFromGcdSalesTarget(GcdSalesTarget gcdSalesTarget)
        {
            GcdSalesTargetWork gcdSalesTargetWork = new GcdSalesTargetWork();

            gcdSalesTargetWork.CreateDateTime = gcdSalesTarget.CreateDateTime;
            gcdSalesTargetWork.UpdateDateTime = gcdSalesTarget.UpdateDateTime;
            gcdSalesTargetWork.EnterpriseCode = gcdSalesTarget.EnterpriseCode;
            gcdSalesTargetWork.FileHeaderGuid = gcdSalesTarget.FileHeaderGuid;
            gcdSalesTargetWork.UpdEmployeeCode = gcdSalesTarget.UpdEmployeeCode;
            gcdSalesTargetWork.UpdAssemblyId1 = gcdSalesTarget.UpdAssemblyId1;
            gcdSalesTargetWork.UpdAssemblyId2 = gcdSalesTarget.UpdAssemblyId2;
            gcdSalesTargetWork.LogicalDeleteCode = gcdSalesTarget.LogicalDeleteCode;

            gcdSalesTargetWork.SectionCode = gcdSalesTarget.SectionCode;
            gcdSalesTargetWork.TargetSetCd = gcdSalesTarget.TargetSetCd;
            gcdSalesTargetWork.TargetContrastCd = gcdSalesTarget.TargetContrastCd;
            gcdSalesTargetWork.TargetDivideCode = gcdSalesTarget.TargetDivideCode;
            gcdSalesTargetWork.TargetDivideName = gcdSalesTarget.TargetDivideName;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTargetWork.CarrierCode = gcdSalesTarget.CarrierCode;
            //gcdSalesTargetWork.CellphoneModelCode = gcdSalesTarget.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            gcdSalesTargetWork.GoodsMakerCd = gcdSalesTarget.MakerCode;
            gcdSalesTargetWork.GoodsNo = gcdSalesTarget.GoodsCode;
            gcdSalesTargetWork.ApplyStaDate = gcdSalesTarget.ApplyStaDate;
            gcdSalesTargetWork.ApplyEndDate = gcdSalesTarget.ApplyEndDate;
            gcdSalesTargetWork.SalesTargetMoney = gcdSalesTarget.GcdSalesTargetMoney;
            gcdSalesTargetWork.SalesTargetProfit = gcdSalesTarget.GcdSalesTargetProfit;
            gcdSalesTargetWork.SalesTargetCount = gcdSalesTarget.GcdSalesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTargetWork.WeekdayRatio = gcdSalesTarget.WeekdayRatio;
            //gcdSalesTargetWork.SatSunRatio = gcdSalesTarget.SatSunRatio;
			//----- ueno del---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            gcdSalesTargetWork.BLGroupCode = gcdSalesTarget.BLGroupCode;
            gcdSalesTargetWork.BLGoodsCode = gcdSalesTarget.BLCode;
            gcdSalesTargetWork.SalesCode = gcdSalesTarget.SalesTypeCode;
            gcdSalesTargetWork.EnterpriseGanreCode = gcdSalesTarget.ItemTypeCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

            return gcdSalesTargetWork;
        }

        #endregion
    }
}
