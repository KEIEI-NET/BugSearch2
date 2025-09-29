//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������A���}�b�`���X�g
// �v���O�����T�v   : ���������A���}�b�`���X�g�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/07/22  �C�����e : ���[�󎚍��ڈꗗ�̋L�ړ��e�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/07/22  �C�����e : ���O���b�Z�[�W�̕ύX
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
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���������A���}�b�`���X�g�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������A���}�b�`���X�g�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br></br>
    /// </remarks>
    public class RateUnMatchAcs
    {
        #region �� Constructor
		/// <summary>
        /// ���������A���}�b�`���X�g�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���������A���}�b�`���X�g�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ���w�q</br>
	    /// <br>Date       : 2009.04.07</br>
		/// </remarks>
		public RateUnMatchAcs()
		{
            this._iRateUnMatchDB = (IRateUnMatchDB)MediationRateUnMatchDB.GetRateUnMatchDB();
            this.goodsAcs = new GoodsAcs();
		}

		/// <summary>
        /// ���������A���}�b�`���X�g�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���������A���}�b�`���X�g�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static RateUnMatchAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X
			
			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
        private GoodsAcs goodsAcs;
        #endregion �� Static Member

        #region �� Private Member
        IRateUnMatchDB _iRateUnMatchDB;                 // ���������A���}�b�`���X�g�����[�g
        private DataSet _rateUnMatchDs;				    // ���������A���}�b�`���X�g�f�[�^�Z�b�g
        private Int32 _delUnitPriceKind1Cnt;            // �����폜����
        private Int32 _delUnitPriceKind2Cnt;            // �����폜����
        private Int32 _delUnitPriceKind3Cnt;            // ���i�폜����
        private const string ct_UIPGID = "PMHNB02200U";
        private const string ct_UIPGNM = "���������A���}�b�`���X�g";
        private const string ct_SPACE = "�@";
        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// ���������A���}�b�`���X�g�f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet RateUnMatchDs
        {
            get { return this._rateUnMatchDs; }
        }

        /// <summary>
        /// �����폜����(�ǂݎ���p)
        /// </summary>
        public Int32 DelUnitPriceKind1Cnt
        {
            get { return this._delUnitPriceKind1Cnt; }
        }

        /// <summary>
        /// �����폜����(�ǂݎ���p)
        /// </summary>
        public Int32 DelUnitPriceKind2Cnt
        {
            get { return this._delUnitPriceKind2Cnt; }
        }

        /// <summary>
        /// ���i�폜����(�ǂݎ���p)
        /// </summary>
        public Int32 DelUnitPriceKind3Cnt
        {
            get { return this._delUnitPriceKind3Cnt; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// ���������A���}�b�`���X�g�f�[�^�擾
        /// </summary>
        /// <param name="rateUnMatchCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锄�������A���}�b�`���X�g�f�[�^���擾����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int Search(RateUnMatchCndtn rateUnMatchCndtn, out string errMsg)
        {
            int status = this.SearchProc(rateUnMatchCndtn, out errMsg);

            return status;
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾

        #region �� �폜�f�[�^�擾
        #region �� �폜�f�[�^�擾
        /// <summary>
        /// ���������A���}�b�`���X�g�폜�f�[�^�擾
        /// </summary>
        /// <param name="rateUnMatchCndtn">���o����</param>
        /// <param name="delList">�폜�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锄�������A���}�b�`���X�g�폜�f�[�^���擾����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int SearchAllForDelete(RateUnMatchCndtn rateUnMatchCndtn, out ArrayList delList, out string errMsg)
        {
            delList = new ArrayList();

            int status = this.SearchProc(rateUnMatchCndtn, out errMsg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = this.SearchAll(this._rateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch], out delList, out errMsg);
            }
            return status;
        }
        #endregion

        #region �� �폜�f�[�^�擾����
        /// <summary>
        /// �폜�f�[�^�擾����
        /// </summary>
        /// <param name="dt">���������f�[�^�e�[�u��</param>
        /// <param name="delList">�폜�p�̑S�ăf�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �폜�f�[�^�擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int SearchAll(DataTable dt, out ArrayList delList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            delList = new ArrayList();
            try
            {
                RateAcs rateAcs = new RateAcs();
                ArrayList rateList = new ArrayList();
                foreach (DataRow dr in dt.Rows)
                {
                    Rate rate = new Rate();
                    // ��ƃR�[�h
                    rate.EnterpriseCode = dr[RateUnMatchResult.Col_EnterpriseCode].ToString();
                    // ���_�R�[�h
                    rate.SectionCode = dr[RateUnMatchResult.Col_SectionCode].ToString();
                    // �P���|���ݒ�敪
                    rate.UnitRateSetDivCd = dr[RateUnMatchResult.Col_UnitRateSetDivCd].ToString();
                    // �P�����
                    rate.UnitPriceKind = dr[RateUnMatchResult.Col_UnitPriceKindCd].ToString();
                    // �|���ݒ�敪
                    rate.RateSettingDivide = dr[RateUnMatchResult.Col_RateSettingDivide].ToString();
                    // ���i���[�J�[�R�[�h
                    rate.GoodsMakerCd = Convert.ToInt32(dr[RateUnMatchResult.Col_GoodsMakerCd].ToString());
                    // ���i�ԍ�
                    rate.GoodsNo = dr[RateUnMatchResult.Col_GoodsNo].ToString();
                    // ���i�|�������N
                    rate.GoodsRateRank = dr[RateUnMatchResult.Col_GoodsRateRank].ToString();
                    // ���i�|���O���[�v�R�[�h
                    rate.GoodsRateGrpCode = Convert.ToInt32(dr[RateUnMatchResult.Col_GoodsRateGrpCode].ToString());
                    // BL�O���[�v�R�[�h
                    rate.BLGroupCode = Convert.ToInt32(dr[RateUnMatchResult.Col_BLGroupCode].ToString());
                    // BL���i�R�[�h
                    rate.BLGoodsCode = Convert.ToInt32(dr[RateUnMatchResult.Col_BLGoodsCode].ToString());
                    // ���Ӑ�R�[�h
                    rate.CustomerCode = Convert.ToInt32(dr[RateUnMatchResult.Col_CustomerCode].ToString());
                    // ���Ӑ�|���O���[�v�R�[�h
                    rate.CustRateGrpCode = Convert.ToInt32(dr[RateUnMatchResult.Col_CustRateGrpCode].ToString());
                    // �d����R�[�h
                    rate.SupplierCd = Convert.ToInt32(dr[RateUnMatchResult.Col_SupplierCd].ToString());

                    // �|���}�X�^�̌�������
                    int subStatus = rateAcs.SearchAll(out rateList, ref rate, out errMsg);
                    if (subStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foreach (Rate rateObj in rateList)
                        {
                            RateUnMatchWork rateUnMatchWork = new RateUnMatchWork();
                            // �X�V����
                            rateUnMatchWork.UpdateDateTime = rateObj.UpdateDateTime;
                            // �_���폜�敪
                            rateUnMatchWork.LogicalDeleteCode = rateObj.LogicalDeleteCode;
                            // ��ƃR�[�h
                            rateUnMatchWork.EnterpriseCode = rateObj.EnterpriseCode;
                            // ���_�R�[�h
                            rateUnMatchWork.SectionCode = rateObj.SectionCode;
                            // �P���|���ݒ�敪
                            rateUnMatchWork.UnitRateSetDivCd = rateObj.UnitRateSetDivCd;
                            // �P�����
                            rateUnMatchWork.UnitPriceKindCd = rateObj.UnitPriceKind;
                            // �|���ݒ�敪
                            rateUnMatchWork.RateSettingDivide = rateObj.RateSettingDivide;
                            // ���i���[�J�[�R�[�h
                            rateUnMatchWork.GoodsMakerCd = rateObj.GoodsMakerCd;
                            // ���i�ԍ�
                            rateUnMatchWork.GoodsNo = rateObj.GoodsNo;
                            // ���i�|�������N
                            rateUnMatchWork.GoodsRateRank = rateObj.GoodsRateRank;
                            // ���i�|���O���[�v�R�[�h
                            rateUnMatchWork.GoodsRateGrpCode = rateObj.GoodsRateGrpCode;
                            // BL�O���[�v�R�[�h
                            rateUnMatchWork.BLGroupCode = rateObj.BLGroupCode;
                            // BL���i�R�[�h
                            rateUnMatchWork.BLGoodsCode = rateObj.BLGoodsCode;
                            // ���Ӑ�R�[�h
                            rateUnMatchWork.CustomerCode = rateObj.CustomerCode;
                            // ���Ӑ�|���O���[�v�R�[�h
                            rateUnMatchWork.CustRateGrpCode = rateObj.CustRateGrpCode;
                            // �d����R�[�h
                            rateUnMatchWork.SupplierCd = rateObj.SupplierCd;
                            // ���b�g��
                            rateUnMatchWork.LotCount = rateObj.LotCount;
                            // ���e
                            rateUnMatchWork.Content = dr[RateUnMatchResult.Col_Content].ToString();
                            delList.Add(rateUnMatchWork);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� �폜�f�[�^�擾����
        #endregion �� �폜�f�[�^�擾

        #region �� �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="delList">�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �폜�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int Delete(ArrayList delList, out string errMsg)
        {
            int status = this.DeleteProc(delList, out errMsg);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ���O����
                this.WriteLog(delList, out errMsg);
            }
            return status;
        }
        #endregion �� �폜����

        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� ���������A���}�b�`���X�g�f�[�^�擾
        /// <summary>
        /// ���������A���}�b�`���X�g�f�[�^�擾
        /// </summary>
        /// <param name="rateUnMatchCndtn"></param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锄�������A���}�b�`���X�g�f�[�^���擾����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int SearchProc(RateUnMatchCndtn rateUnMatchCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                // DataTable Create ----------------------------------------------------------
                RateUnMatchResult.CreateDataTableResultRateUnMatch(ref this._rateUnMatchDs);

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                status = this._iRateUnMatchDB.Search(out retList, rateUnMatchCndtn.SectionCodes);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevRateUnMatchWorkListData(rateUnMatchCndtn, this._rateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch], (ArrayList)retList);
                        if (this._rateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch].Rows.Count > 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���������A���}�b�`���X�g�f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� �񋟃f�[�^�̃`�F�b�N����
        /// <summary>
        /// �񋟃f�[�^�̃`�F�b�N����
        /// </summary>
        /// <param name="rateUnMatchWork">���o�����f�[�^</param>
        /// <param name="isDelete">�`�F�b�N����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int CheckProc(ref RateUnMatchWork rateUnMatchWork, out bool isDelete, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            isDelete = false;
            errMsg = string.Empty;
            try
            {
                // ���i�����󔒂̏ꍇ�A���[�J�����i�}�X�^�̃`�F�b�N���s���܂�
                if (rateUnMatchWork.GoodsNm == null || String.IsNullOrEmpty(rateUnMatchWork.GoodsNm))
                {
                    GoodsCndtn goodCndtn = new GoodsCndtn();
                    goodCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    goodCndtn.SectionCode = rateUnMatchWork.SectionCode.Trim();
                    goodCndtn.GoodsMakerCd = rateUnMatchWork.GoodsMakerCd;
                    goodCndtn.GoodsNo = rateUnMatchWork.GoodsNo;
                    goodCndtn.GoodsNoSrchTyp = 0;
                    goodCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

                    List<GoodsUnitData> list = new List<GoodsUnitData>();
                    string msg = "";
                    status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodCndtn, out list, out msg);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // �񋟃f�[�^�ɑ��݂���ꍇ
                        if (list != null && list.Count > 0)
                        {
                            if (rateUnMatchWork.IsErrRateProtyMng == "0"
                                && rateUnMatchWork.IsAllZero == "0"
                                && rateUnMatchWork.IsErrGoodsU == "1")
                            {
                                // ���i�}�X�^�`�F�b�N���G���[�����̏ꍇ�A�Y�����R�[�h���O��
                                isDelete = true;
                            }
                            else
                            {
                                // �񋟃f�[�^�ɑ��݂���
                                rateUnMatchWork.IsErrGoodsU = "0";
                                // �i�����Z�b�g����
                                rateUnMatchWork.GoodsNm = ((GoodsUnitData)list[0]).GoodsNameKana;
                            }
                        }
                    }

                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� �`�F�b�N����

        #region �� �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="delList">�폜�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �폜�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int DeleteProc(ArrayList delList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                this._delUnitPriceKind1Cnt = 0;
                this._delUnitPriceKind2Cnt = 0;
                this._delUnitPriceKind3Cnt = 0;
                RateAcs rateAcs = new RateAcs();
                IRateDB iRateDB = (IRateDB)MediationRateDB.GetRateDB();
                ArrayList delRateList = new ArrayList();
                foreach (RateUnMatchWork rateUnMatchWork in delList)
                {
                    Rate rate = new Rate();
                    // �X�V����
                    rate.UpdateDateTime = rateUnMatchWork.UpdateDateTime;
                    // ��ƃR�[�h
                    rate.EnterpriseCode = rateUnMatchWork.EnterpriseCode;
                    // ���_�R�[�h
                    rate.SectionCode = rateUnMatchWork.SectionCode;
                    // �P���|���ݒ�敪
                    rate.UnitRateSetDivCd = rateUnMatchWork.UnitRateSetDivCd;
                    // �P�����
                    rate.UnitPriceKind = rateUnMatchWork.UnitPriceKindCd;
                    // �|���ݒ�敪
                    rate.RateSettingDivide = rateUnMatchWork.RateSettingDivide;
                    // ���i���[�J�[�R�[�h
                    rate.GoodsMakerCd = rateUnMatchWork.GoodsMakerCd;
                    // ���i�ԍ�
                    rate.GoodsNo = rateUnMatchWork.GoodsNo;
                    // ���i�|�������N
                    rate.GoodsRateRank = rateUnMatchWork.GoodsRateRank;
                    // ���i�|���O���[�v�R�[�h
                    rate.GoodsRateGrpCode = rateUnMatchWork.GoodsRateGrpCode;
                    // BL�O���[�v�R�[�h
                    rate.BLGroupCode = rateUnMatchWork.BLGroupCode;
                    // BL���i�R�[�h
                    rate.BLGoodsCode = rateUnMatchWork.BLGoodsCode;
                    // ���Ӑ�R�[�h
                    rate.CustomerCode = rateUnMatchWork.CustomerCode;
                    // ���Ӑ�|���O���[�v�R�[�h
                    rate.CustRateGrpCode = rateUnMatchWork.CustRateGrpCode;
                    // �d����R�[�h
                    rate.SupplierCd = rateUnMatchWork.SupplierCd;
                    // ���b�g��
                    rate.LotCount = rateUnMatchWork.LotCount;

                    // �P�����
                    string kind = rate.UnitPriceKind;
                    switch (kind)
                    {
                        case "1":
                            this._delUnitPriceKind1Cnt++;
                            break;
                        case "2":
                            this._delUnitPriceKind2Cnt++;
                            break;
                        case "3":
                            this._delUnitPriceKind3Cnt++;
                            break;
                    }
                    delRateList.Add(rate);
                }
                // �|���}�X�^�̍폜����
                status = rateAcs.Delete(ref delRateList, out errMsg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                }
            }
            catch (Exception ex)
            {
                this._delUnitPriceKind1Cnt = 0;
                this._delUnitPriceKind2Cnt = 0;
                this._delUnitPriceKind3Cnt = 0;
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� �폜����

        #region �� ���O����
        /// <summary>
        /// ���O����
        /// </summary>
        /// <param name="delList">�폜�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���O�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int WriteLog(ArrayList delList, out string errMsg)
        {
            return this.WriteLogProc(delList, out errMsg);
        }

        /// <summary>
        /// ���O����
        /// </summary>
        /// <param name="delList">�폜�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���O�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int WriteLogProc(ArrayList delList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                string preMsg = string.Empty;

                foreach (RateUnMatchWork rate in delList)
                {
                    StringBuilder msgSb = new StringBuilder("�|���}�X�^�폜");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("{0}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("{1}");
                    msgSb.Append("��G:{2}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("���Ӑ�:{3}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("�d����:{4}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("Ұ��:{5}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("�w��:{6}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("���i�|��:{7}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("��ٰ�ߺ���:{8}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("BL����:{9}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("�i��:{10}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("{11}");
                    string logDelNm = String.Empty;
                    // �_���폜
                    if (rate.LogicalDeleteCode == 1)
                    {
                        logDelNm = "�_���폜" + ct_SPACE;
                    }
                    // �쐬�敪
                    string kindNm = String.Empty;
                    switch (rate.UnitPriceKindCd)
                    {
                        case "1":
                            kindNm = "�����ݒ�";
                            break;
                        case "2":
                            kindNm = "�����ݒ�";
                            break;
                        case "3":
                            // upd by liuxz on 2009/07/22 start
                            // kindNm = "�艿�ݒ�";
                            kindNm = "���i�ݒ�";
                            // upd by liuxz on 2009/07/22 end
                            break;
                    }
                    // upd by liuxz on 2009/07/22 start
                    /*
                    string msg = String.Format(msgSb.ToString(),
                                    kindNm,
                                    logDelNm,
                                    rate.CustRateGrpCode,
                                    rate.CustomerCode,
                                    rate.SupplierCd,
                                    rate.GoodsMakerCd,
                                    rate.GoodsRateRank,
                                    rate.GoodsRateGrpCode,
                                    rate.BLGroupCode,
                                    rate.BLGoodsCode,
                                    rate.GoodsNo,
                                    rate.Content);
                    */
                    string custRateGrpCode = GetMessageForLog(rate.CustRateGrpCode, 4);
                    string customerCode = GetMessageForLog(rate.CustomerCode, 8);
                    string supplierCd = GetMessageForLog(rate.SupplierCd, 6);
                    string goodsMakerCd = GetMessageForLog(rate.GoodsMakerCd, 4);
                    string goodsRateGrpCode = GetMessageForLog(rate.GoodsRateGrpCode, 4);
                    string bLGroupCode = GetMessageForLog(rate.BLGroupCode, 5);
                    string bLGoodsCode = GetMessageForLog(rate.BLGoodsCode, 5);
                    string msg = String.Format(msgSb.ToString(),
                                    kindNm,
                                    logDelNm,
                                    custRateGrpCode,
                                    customerCode,
                                    supplierCd,
                                    goodsMakerCd,
                                    rate.GoodsRateRank,
                                    goodsRateGrpCode,
                                    bLGroupCode,
                                    bLGoodsCode,
                                    rate.GoodsNo,
                                    rate.Content);
                    // upd by liuxz on 2009/07/22 end
                    if (string.IsNullOrEmpty(preMsg) || !preMsg.Equals(msg))
                    {
                        OperationHistoryLog log = new OperationHistoryLog();
                        log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, ct_UIPGID, ct_UIPGNM, string.Empty, 0, 0, msg, string.Empty);
                    }
                    preMsg = msg;
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        // add by liuxz on 2009/07/22 start
        #region ���O���e�̃t�H�[�}�b�g
        //
        /// <summary>
        /// ���O���e�̃t�H�[�}�b�g
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetMessageForLog(Int32 data, Int32 length)
        {
            if (data != 0)
            {
                return data.ToString().PadLeft(length, '0');
            }
            else
            {
                return string.Empty;
            }
        }
        // add by liuxz on 2009/07/22 end
        #endregion
        #endregion �� ���O����

        #region �� �f�[�^�W�J����
        #region �� ���������A���}�b�`���X�g�f�[�^�W�J����
        /// <summary>
        /// ���������A���}�b�`���X�g�f�[�^�W�J����
        /// </summary>
        /// <param name="rateUnMatchCndtn">���o�����N���X</param>
        /// <param name="rateUnMatchDt">�W�J�Ώ�DataTable</param>
        /// <param name="rateUnMatchWorkList">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���������A���}�b�`���X�g�f�[�^��W�J����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private void DevRateUnMatchWorkListData(RateUnMatchCndtn rateUnMatchCndtn, DataTable rateUnMatchDt, ArrayList rateUnMatchWorkList)
        {
            string lastSectionCode = null;
            string lastUnitPriceKindCd = null;
            bool isDelete = false;
            string errMsg = string.Empty;

            for (int i = 0; i < rateUnMatchWorkList.Count; i++)
            {
                RateUnMatchWork rateUnMatchWork = (RateUnMatchWork)rateUnMatchWorkList[i];
                // �񋟃f�[�^�ɏ��i�f�[�^���`�F�b�N����
                this.CheckProc(ref rateUnMatchWork, out isDelete, out errMsg);

                // ���i�}�X�^�`�F�b�N���G���[�����ȊO�̏ꍇ�A�f�[�^���쐬����
                if (!isDelete)
                {
                    DataSetRateUnMatch(rateUnMatchCndtn, rateUnMatchDt, rateUnMatchWork, ref lastSectionCode, ref lastUnitPriceKindCd);
                }
            }
        }
        #endregion

        /// <summary>
        /// �擾�f�[�^�ݒ菈��
        /// </summary>
        /// <param name="rateUnMatchCndtn">���o�����N���X</param>
        /// <param name="rateUnMatchDt">�W�J�Ώ�DataTable</param>
        /// <param name="rateUnMatchWork">�擾�f�[�^</param>
        /// <param name="lastSectionCode">�O�񋒓_�R�[�h</param>
        /// <param name="lastUnitPriceKindCd">�O��쐬�敪</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private void DataSetRateUnMatch(RateUnMatchCndtn rateUnMatchCndtn, DataTable rateUnMatchDt, RateUnMatchWork rateUnMatchWork, ref string lastSectionCode, ref string lastUnitPriceKindCd)
        {
            DataRow dr;

            dr = rateUnMatchDt.NewRow();

            // ���������A���}�b�`���X�g�f�[�^�W�J
            #region ���������A���}�b�`���X�g�f�[�^�W�J
            dr[RateUnMatchResult.Col_UpdateDateTime] = rateUnMatchWork.UpdateDateTime;
            // �����敪
            switch (rateUnMatchCndtn.ProcessKbn)
            {
                case 0:
                    dr[RateUnMatchResult.Col_ProcessKbn] = "����̂�";
                    break;
                case 1:
                    dr[RateUnMatchResult.Col_ProcessKbn] = "������폜";
                    break;
                case 2:
                    break;
            }
            dr[RateUnMatchResult.Col_EnterpriseCode] = rateUnMatchWork.EnterpriseCode;
            dr[RateUnMatchResult.Col_LogicalDeleteCode] = rateUnMatchWork.LogicalDeleteCode;
            if (rateUnMatchWork.LogicalDeleteCode == 1)
            {
                dr[RateUnMatchResult.Col_LogicalDeleteName] = "�_���폜";
            }
            else
            {
                dr[RateUnMatchResult.Col_LogicalDeleteName] = String.Empty;
            }
            dr[RateUnMatchResult.Col_SectionCode] = rateUnMatchWork.SectionCode;
            if (rateUnMatchWork.SectionCode != lastSectionCode)
            {
                dr[RateUnMatchResult.Col_SectionCodeForPrint] = rateUnMatchWork.SectionCode;
                dr[RateUnMatchResult.Col_SectionName] = rateUnMatchWork.SectionName;
            }
            else
            {
                dr[RateUnMatchResult.Col_SectionCodeForPrint] = String.Empty;
                dr[RateUnMatchResult.Col_SectionName] = String.Empty;
            }
            dr[RateUnMatchResult.Col_UnitRateSetDivCd] = rateUnMatchWork.UnitRateSetDivCd;
            dr[RateUnMatchResult.Col_UnitPriceKindCd] = rateUnMatchWork.UnitPriceKindCd;
            if (rateUnMatchWork.SectionCode != lastSectionCode || rateUnMatchWork.UnitPriceKindCd != lastUnitPriceKindCd)
            {
                switch (rateUnMatchWork.UnitPriceKindCd)
                {
                    case "1":
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = "�����ݒ�";
                        break;
                    case "2":
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = "�����ݒ�";
                        break;
                    case "3":
                        // upd by liuxz on 2009/07/22 start
                        // dr[RateUnMatchResult.Col_UnitPriceKindNm] = "�艿�ݒ�";
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = "���i�ݒ�";
                        // upd by liuxz on 2009/07/22 end
                        break;
                    default:
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = String.Empty;
                        break;
                }
            }
            else
            {
                dr[RateUnMatchResult.Col_UnitPriceKindNm] = String.Empty;
            }
            lastSectionCode = rateUnMatchWork.SectionCode;
            lastUnitPriceKindCd = rateUnMatchWork.UnitPriceKindCd;
            // �|���ݒ�敪�̐ݒ�Ώۂ̔���
            // ���[�J�[
            if (RateAcs.IsMakerSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsMakerCdForPrint] = rateUnMatchWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                dr[RateUnMatchResult.Col_GoodsMakerNm] = rateUnMatchWork.GoodsMakerNm;
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsMakerCdForPrint] = String.Empty;
                dr[RateUnMatchResult.Col_GoodsMakerNm] = String.Empty;
            }
            // �i��
            if (RateAcs.IsGoodsNoSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsNoForPrint] = rateUnMatchWork.GoodsNo;
                dr[RateUnMatchResult.Col_GoodsNm] = rateUnMatchWork.GoodsNm;
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsNoForPrint] = String.Empty;
                dr[RateUnMatchResult.Col_GoodsNm] = String.Empty;
            }
            // �w��
            if (RateAcs.IsGoodsRateRankSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsRateRankForPrint] = rateUnMatchWork.GoodsRateRank;
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsRateRankForPrint] = String.Empty;
            }
            // ���i�|��
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsRateGrpCodeForPrint] = rateUnMatchWork.GoodsRateGrpCode.ToString().PadLeft(4, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsRateGrpCodeForPrint] = String.Empty;
            }
            // �O���[�v�R�[�h
            if (RateAcs.IsBLGroupCodeSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_BLGroupCodeForPrint] = rateUnMatchWork.BLGroupCode.ToString().PadLeft(5, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_BLGroupCodeForPrint] = String.Empty;
            }
            // BL�R�[�h
            if (RateAcs.IsBLGoodsSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_BLGoodsCodeForPrint] = rateUnMatchWork.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_BLGoodsCodeForPrint] = String.Empty;
            }
            // ���Ӑ�R�[�h
            if (RateAcs.IsCustomerSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_CustomerCodeForPrint] = rateUnMatchWork.CustomerCode.ToString().PadLeft(8, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_CustomerCodeForPrint] = String.Empty;
            }
            // ��G
            if (RateAcs.IsCustRateGrpSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_CustRateGrpCodeForPrint] = rateUnMatchWork.CustRateGrpCode.ToString().PadLeft(4, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_CustRateGrpCodeForPrint] = String.Empty;
            }
            // �d����R�[�h
            if (RateAcs.IsSupplierSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_SupplierCdForPrint] = rateUnMatchWork.SupplierCd.ToString().PadLeft(6, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_SupplierCdForPrint] = String.Empty;
            }

            dr[RateUnMatchResult.Col_RateSettingDivide] = rateUnMatchWork.RateSettingDivide;
            dr[RateUnMatchResult.Col_RateMngGoodsCd] = rateUnMatchWork.RateMngGoodsCd;
            dr[RateUnMatchResult.Col_RateMngGoodsNm] = rateUnMatchWork.RateMngGoodsNm;
            dr[RateUnMatchResult.Col_RateMngCustCd] = rateUnMatchWork.RateMngCustCd;
            dr[RateUnMatchResult.Col_RateMngCustNm] = rateUnMatchWork.RateMngCustNm;
            dr[RateUnMatchResult.Col_GoodsMakerCd] = rateUnMatchWork.GoodsMakerCd;
            dr[RateUnMatchResult.Col_GoodsNo] = rateUnMatchWork.GoodsNo;           
            dr[RateUnMatchResult.Col_GoodsRateRank] = rateUnMatchWork.GoodsRateRank;
            dr[RateUnMatchResult.Col_GoodsRateGrpCode] = rateUnMatchWork.GoodsRateGrpCode;
            dr[RateUnMatchResult.Col_BLGroupCode] = rateUnMatchWork.BLGroupCode;
            dr[RateUnMatchResult.Col_BLGoodsCode] = rateUnMatchWork.BLGoodsCode;
            dr[RateUnMatchResult.Col_CustomerCode] = rateUnMatchWork.CustomerCode;
            dr[RateUnMatchResult.Col_CustRateGrpCode] = rateUnMatchWork.CustRateGrpCode;
            dr[RateUnMatchResult.Col_SupplierCd] = rateUnMatchWork.SupplierCd;
            dr[RateUnMatchResult.Col_LotCount] = rateUnMatchWork.LotCount;
            dr[RateUnMatchResult.Col_PriceFl] = rateUnMatchWork.PriceFl;
            dr[RateUnMatchResult.Col_RateVal] = rateUnMatchWork.RateVal;
            dr[RateUnMatchResult.Col_UpRate] = rateUnMatchWork.UpRate;
            dr[RateUnMatchResult.Col_GrsProfitSecureRate] = rateUnMatchWork.GrsProfitSecureRate;
            dr[RateUnMatchResult.Col_UnPrcFracProcUnit] = rateUnMatchWork.UnPrcFracProcUnit;
            dr[RateUnMatchResult.Col_UnPrcFracProcDiv] = rateUnMatchWork.UnPrcFracProcDiv;
            dr[RateUnMatchResult.Col_IsErrRateProtyMng] = rateUnMatchWork.IsErrRateProtyMng;
            dr[RateUnMatchResult.Col_IsErrGoodsU] = rateUnMatchWork.IsErrGoodsU;
            dr[RateUnMatchResult.Col_IsAllZero] = rateUnMatchWork.IsAllZero;
            StringBuilder content = new StringBuilder();
            if (dr[RateUnMatchResult.Col_IsErrRateProtyMng].ToString() != "0")
            {
                content.Append("�|���D�揇�ʂɊY������");
            }
            if (dr[RateUnMatchResult.Col_IsErrGoodsU].ToString() != "0")
            {
                if (content.Length > 0)
                {
                    content.Append("�A");
                }
                content.Append("���i�}�X�^���o�^");
            }
            if (dr[RateUnMatchResult.Col_IsAllZero].ToString() != "0")
            {
                if (content.Length > 0)
                {
                    content.Append("�A");
                }
                content.Append("�ݒ�l���S�ă[��");
            }
            dr[RateUnMatchResult.Col_Content] = content.ToString();

            // Table��Add
            rateUnMatchDt.Rows.Add(dr);
        }

        #endregion �� �f�[�^�W�J����
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
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
    }
}
