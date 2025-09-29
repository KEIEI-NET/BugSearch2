//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�׎��ѕ\
// �v���O�����T�v   : �^���ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
// Update Note : 2010/05/08 ���C�� REDMINE #7109�̑Ή�
// �@�@�@�@�@�@: �^���ʏo�בΉ��\�̕ύX
// Update Note : 2010/05/16 ���C�� REDMINE #7109�̑Ή�
// �@�@�@�@�@�@: BL�R�[�h�̈󎚃t�H�[�}�b�g�C��
// �@�@�@�@�@�@: �I�Ԃƌ��݌ɐ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhshh
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note : 2010.05.19 zhangsf Redmine #7784�̑Ή�
//             : �E�^���ʏo�בΉ��\�^�e��C��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Collections.Specialized;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �^���ʏo�׎��ѕ\ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �^���ʏo�׎��ѕ\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: zhshh</br>
    /// <br>Date		: 2010.04.21</br>
    /// </remarks>
    public class ModelShipRsltAcs
    {
        #region �� Constructor
        /// <summary>
        /// �^���ʏo�׎��ѕ\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^���ʏo�׎��ѕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public ModelShipRsltAcs()
        {
            this._iModelShipResultDB = (IModelShipResultDB)MediationModelShipResultDB.GetModelShipWorkDB();

            // --- ADD 2010/05/13 ---------->>>>>
            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd();
            string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            string msg;

            this._goodsAcs = new GoodsAcs(); // ���i�}�X�^
            this._goodsAcs.SearchInitial(enterpriseCode, loginSectionCode, out msg);
            // --- ADD 2010/05/13 ----------<<<<<
        }

        /// <summary>
        /// �^���ʏo�׎��ѕ\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^���ʏo�׎��ѕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        static ModelShipRsltAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X	
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

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
        private static PrtOutSet stc_PrtOutSet;			            // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // ���[�o�͐ݒ�A�N�Z�X�N���X

        #endregion �� Static Member

        #region �� Private Member
        IModelShipResultDB _iModelShipResultDB;

        private DataSet _carShipListDs;	    		// ���DataTable

        private GoodsAcs _goodsAcs; // ���i�}�X�^ ADD 2010/05/13

        #endregion �� Private Member

        #region �� Pricate Const
        const string ct_Extr_Top = "�ŏ�����";
        const string ct_Extr_End = "�Ō�܂�";
        const string ct_Space = "�@";
        #endregion �� Pricate Const

        #region �� Public Property
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet CarShipListDs
        {
            get { return this._carShipListDs; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �����f�[�^�擾
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="modelShip">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���f�[�^���擾����B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int SearchCarShipProcMain(ModelShipRsltListCndtn modelShip, out string errMsg)
        {
            return this.SearchModelShipProc(modelShip, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="modelShipCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���f�[�^���擾����B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// <br>Update Note: 2010/05/08 ���C�� REDMINE #7109�̑Ή�</br>
        /// </remarks>
        private int SearchModelShipProc(ModelShipRsltListCndtn modelShipCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSYA02205EA.CreateDataTable(ref this._carShipListDs);

                // ���o�����W�J  --------------------------------------------------------------
                ModelShipRsltCndtnWork modelShipRsltCndtnWork = new ModelShipRsltCndtnWork();
                status = this.DevCarShip(modelShipCndtn, out modelShipRsltCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object ModelShipResultWork = null;
                status = this._iModelShipResultDB.Search(out ModelShipResultWork, (object)modelShipRsltCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList modelShipResultList = ModelShipResultWork as ArrayList;

                        // --- ADD 2010/05/08 ---------->>>>>
                        //�����}�X�^�̌�����i�ԁi�D�Ǖi�ԁj�ƌ����惁�[�J�[�i�D�ǃ��[�J�[�j�̐ݒ�
                        SetJoinPartsInfo(modelShipCndtn, ref modelShipResultList, out errMsg);

                        // --- DEL 2010/05/13 ---------->>>>>
                        //object retWork = modelShipResultList as object;
                        //this._iModelShipResultDB.SearchStock(ref retWork, modelShipCndtn.WarehouseCode);
                        //modelShipResultList = retWork as ArrayList;
                        // --- DEL 2010/05/13 ----------<<<<<
                        // --- ADD 2010/05/08 ----------<<<<<

                        //�W�v�P�ʂ̒��Ŕ���P��(�Ŕ�,�s��)���قȂ���̂����݂���ꍇ�́A�O���Z�b�g����
                        DifUnPrcSetZeroWithGroupBy(ref modelShipResultList, modelShipCndtn);

                        // �f�[�^�W�J����
                        DevCarShipMainData(modelShipCndtn, this._carShipListDs.Tables[PMSYA02205EA.Tbl_ModelShipListData], modelShipResultList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�^���ʏo�׎��ѕ\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
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
        #endregion �� ���[�f�[�^�擾

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="modelShipCndtn">UI���o�����N���X</param>
        /// <param name="modelShipRsltCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevCarShip(ModelShipRsltListCndtn modelShipCndtn, out ModelShipRsltCndtnWork modelShipRsltCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            modelShipRsltCndtnWork = new ModelShipRsltCndtnWork();
            try
            {
                // ��ƃR�[�h 
                modelShipRsltCndtnWork.EnterpriseCode = modelShipCndtn.EnterpriseCode;
                // ���_�R�[�h���X�g
                modelShipRsltCndtnWork.SectionCodeList = modelShipCndtn.SectionCodeList;
                // �W�v���@
                modelShipRsltCndtnWork.GroupBySectionDiv = (int)modelShipCndtn.GroupBySectionDiv;
                // �����(�J�n)
                modelShipRsltCndtnWork.SalesDateSt = modelShipCndtn.SalesDateSt;
                // �����(�I��)
                modelShipRsltCndtnWork.SalesDateEd = modelShipCndtn.SalesDateEd;
                // ���͓�(�J�n)
                modelShipRsltCndtnWork.InputDateSt = modelShipCndtn.InputDateSt;
                // ���͓�(�I��)
                modelShipRsltCndtnWork.InputDateEd = modelShipCndtn.InputDateEd;
                // �݌Ɏ�񂹋敪
                modelShipRsltCndtnWork.RsltTtlDiv = (int)modelShipCndtn.RsltTtlDiv;
                // ����
                modelShipRsltCndtnWork.NewPageDiv = (int)modelShipCndtn.NewPageDiv;

                //�Ԏ탁�[�J�[�R�[�h
                modelShipRsltCndtnWork.CarMakerCodeSt = modelShipCndtn.CarMakerCodeSt;
                modelShipRsltCndtnWork.CarMakerCodeEd = modelShipCndtn.CarMakerCodeEd;

                //�Ԏ�R�[�h
                modelShipRsltCndtnWork.CarModelCodeSt = modelShipCndtn.CarModelCodeSt;
                modelShipRsltCndtnWork.CarModelCodeEd = modelShipCndtn.CarModelCodeEd;

                //�Ԏ�T�u�R�[�h
                modelShipRsltCndtnWork.CarModelSubCodeSt = modelShipCndtn.CarModelSubCodeSt;
                modelShipRsltCndtnWork.CarModelSubCodeEd = modelShipCndtn.CarModelSubCodeEd;

                //��\�^��
                modelShipRsltCndtnWork.ModelName = modelShipCndtn.ModelName;

                // ��\�^�����o�敪
                modelShipRsltCndtnWork.ModelOutDiv = (int)modelShipCndtn.ModelOutDiv;

                //���[�J�[
                modelShipRsltCndtnWork.MakerCodeSt = modelShipCndtn.MakerCodeSt;
                modelShipRsltCndtnWork.MakerCodeEd = modelShipCndtn.MakerCodeEd;

                //BL���i�R�[�h
                modelShipRsltCndtnWork.BLGoodsCodeSt = modelShipCndtn.BLGoodsCodeSt;
                modelShipRsltCndtnWork.BLGoodsCodeEd = modelShipCndtn.BLGoodsCodeEd;

                //�q�ɃR�[�h
                modelShipRsltCndtnWork.WarehouseCode = modelShipCndtn.WarehouseCode;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        #endregion �� ���o�����W�J����

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
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
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

        /// <summary>
        /// ���[�ݒ�f�[�^�擾����
        /// </summary>
        /// <param name="modelShipResultList">UI���o�����N���X</param>
        /// <param name="carShipRsltDt">carShipRsltDt</param>
        /// <param name="carShipRsltWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// <br>Update Note: 2010/05/08 ���C�� REDMINE #7109�̑Ή�</br>
        /// </remarks>
        private void DevCarShipMainData(ModelShipRsltListCndtn modelShipResultList, DataTable carShipRsltDt, ArrayList carShipRsltWork)
        {
            DataRow dr;
            ModelShipResultWork disCarShipResultWork = null;
            ModelShipResultWork nextDisCarShipResultWork = null;
            ModelShipResultWork lastDisCarShipResultWork = null;
            int count = carShipRsltWork.Count;
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                disCarShipResultWork = (ModelShipResultWork)carShipRsltWork[i];
                // --- ADD 2010/05/08 ---------->>>>>
                // �\���t���O�u1:�\�����Ȃ��v�̏ꍇ�A������Ȃ�
                if (disCarShipResultWork.IsShowFlg == 1)
                {
                    continue;
                }
                // --- ADD 2010/05/08 ----------<<<<<
                if (i + 1 < count)
                {
                    nextDisCarShipResultWork = (ModelShipResultWork)carShipRsltWork[i + 1];
                }
                dr = carShipRsltDt.NewRow();
                //���ьv�㋒�_�R�[�h
                dr[PMSYA02205EA.ct_Col_ResultsAddUpSecCdRF] = disCarShipResultWork.ResultsAddUpSecCd;
                //���_�K�C�h����
                if (string.IsNullOrEmpty(disCarShipResultWork.SectionGuideSnm))
                {
                    dr[PMSYA02205EA.ct_Col_SectionGuideSnmRF] = "���o�^";
                }
                else
                {
                    dr[PMSYA02205EA.ct_Col_SectionGuideSnmRF] = disCarShipResultWork.SectionGuideSnm;
                }
                //���[�J�[�R�[�h
                dr[PMSYA02205EA.ct_Col_MakerCodeRF] = disCarShipResultWork.MakerCode;
                //�Ԏ�R�[�h
                dr[PMSYA02205EA.ct_Col_ModelCodeRF] = disCarShipResultWork.ModelCode;
                //�Ԏ�T�u�R�[�h
                dr[PMSYA02205EA.ct_Col_ModelSubCodeRF] = disCarShipResultWork.ModelSubCode;
                //�Ԏ피�p����
                dr[PMSYA02205EA.ct_Col_ModelHalfNameRF] = disCarShipResultWork.ModelHalfName;
                //�^���i�t���^�j
                dr[PMSYA02205EA.ct_Col_FullModelRF] = disCarShipResultWork.FullModel;
                //BL���i�R�[�h
                // --- UPD 2010/05/16 ---------->>>>>
                //dr[PMSYA02205EA.ct_Col_BLGoodsCodeRF] = disCarShipResultWork.BLGoodsCode;
                dr[PMSYA02205EA.ct_Col_BLGoodsCodeRF] = string.Format("{0:D5}", disCarShipResultWork.BLGoodsCode);
                // --- UPD 2010/05/16 ----------<<<<<
                //BL���i�R�[�h���́i���p�j
                if (string.IsNullOrEmpty(disCarShipResultWork.BLGoodsHalfName))
                {
                    dr[PMSYA02205EA.ct_Col_BLGoodsHalfNameRF] = "���o�^";
                }
                else
                {
                    dr[PMSYA02205EA.ct_Col_BLGoodsHalfNameRF] = disCarShipResultWork.BLGoodsHalfName;
                }

                // --- UPD 2010/05/08 ---------->>>>>
                ////���i���� 0:���� 1:���̑�
                //if (disCarShipResultWork.GoodsKindCode == 0)
                //{
                //    //���i���[�J�[�R�[�h�i�����j
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerCd1RF] = disCarShipResultWork.GoodsMakerCd;
                //    //���i���[�J�[���́i�����j
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerName1RF] = disCarShipResultWork.MakerName;
                //    //�����i��  ���i�������D�ǂ̏ꍇ�͈󎚂��Ȃ�
                //    if (string.IsNullOrEmpty(disCarShipResultWork.JoinSourPartsNoWithH))
                //    {
                //        dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = disCarShipResultWork.GoodsNo;
                //    }
                //    else
                //    {
                //        dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = string.Empty;
                //    }
                //}
                ////���i���[�J�[�R�[�h�i�D�ǁj
                //if (disCarShipResultWork.JoinSourceMakerCode != 0)
                //{
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = disCarShipResultWork.JoinDestMakerCd;
                //}
                //else
                //{
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = DBNull.Value;
                //}
                ////���i���[�J�[���́i�D�ǁj
                //dr[PMSYA02205EA.ct_Col_GoodsMakerName2RF] = disCarShipResultWork.MakerName2;
                ////�Ή��i��
                //dr[PMSYA02205EA.ct_Col_GoodsNo2RF] = disCarShipResultWork.JoinSourPartsNoWithH;

                //���i���� 0:���� 1:���̑�
                if (disCarShipResultWork.GoodsKindCode == 0)
                {
                    //���i���[�J�[�R�[�h�i�����j
                    dr[PMSYA02205EA.ct_Col_GoodsMakerCd1RF] = disCarShipResultWork.GoodsMakerCd;
                    //���i���[�J�[���́i�����j
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName1RF] = disCarShipResultWork.MakerName;
                    // --- UPD 2010/05/13 ---------->>>>>
                    ////�����i��  ���i�������D�ǂ̏ꍇ�͈󎚂��Ȃ�
                    //if (string.IsNullOrEmpty(disCarShipResultWork.JoinDestPartsNo))
                    //{
                    //    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = disCarShipResultWork.GoodsNo;
                    //}
                    //else
                    //{
                    //    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = string.Empty;
                    //}
                    //�����i��
                    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = disCarShipResultWork.GoodsNo;
                    // --- UPD 2010/05/13 ----------<<<<<
                    //���i���[�J�[�R�[�h�i�D�ǁj
                    if (disCarShipResultWork.JoinDestMakerCd != 0)
                    {
                        dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = disCarShipResultWork.JoinDestMakerCd;
                    }
                    else
                    {
                        dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = DBNull.Value;
                    }
                    //���i���[�J�[���́i�D�ǁj
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName2RF] = disCarShipResultWork.MakerName2;
                    //�Ή��i��
                    dr[PMSYA02205EA.ct_Col_GoodsNo2RF] = disCarShipResultWork.JoinDestPartsNo;
                }
                else
                {
                    //���i���[�J�[�R�[�h�i�����j
                    dr[PMSYA02205EA.ct_Col_GoodsMakerCd1RF] = string.Empty;
                    //���i���[�J�[���́i�����j
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName1RF] = string.Empty;
                    //�����i��
                    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = string.Empty;
                    //���i���[�J�[�R�[�h�i�D�ǁj
                    dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = disCarShipResultWork.GoodsMakerCd;
                    //���i���[�J�[���́i�D�ǁj
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName2RF] = disCarShipResultWork.MakerName;
                    //�Ή��i��
                    dr[PMSYA02205EA.ct_Col_GoodsNo2RF] = disCarShipResultWork.GoodsNo;
                }
                // --- UPD 2010/05/08 ----------<<<<<

                //�o�א�
                dr[PMSYA02205EA.ct_Col_ShipmentCntRF] = disCarShipResultWork.ShipmentCnt;
                //����P���i�Ŕ��C�����j
                dr[PMSYA02205EA.ct_Col_SalesUnPrcTaxExcFlRF] = disCarShipResultWork.SalesUnPrcTaxExcFl;
                //������z�i�Ŕ����j
                dr[PMSYA02205EA.ct_Col_SalesMoneyTaxExcRF] = disCarShipResultWork.SalesMoneyTaxExc;
                // --- UPD 2010/05/16 ---------->>>>>
                //// �݌ɂ��Ȃ��ꍇ�͈󎚂��Ȃ�
                //// --- UPD 2010/05/08 ---------->>>>>
                ////if (disCarShipResultWork.JoinSourceMakerCode != 0 )
                //if (disCarShipResultWork.SalesOrderDivCd != 0)
                //// --- UPD 2010/05/08 ----------<<<<<
                //{
                //    //�q�ɒI��
                //    dr[PMSYA02205EA.ct_Col_WarehouseShelfNoRF] = disCarShipResultWork.WarehouseShelfNo;
                //    //�d���݌ɐ�
                //    // --- UPD 2010/05/08 ---------->>>>>
                //    //dr[PMSYA02205EA.ct_Col_SupplierStockRF] = disCarShipResultWork.SupplierStock;
                //    if (disCarShipResultWork.SupplierStock != 0)
                //    {
                //        dr[PMSYA02205EA.ct_Col_SupplierStockRF] = disCarShipResultWork.SupplierStock;
                //    }
                //    else
                //    {
                //        dr[PMSYA02205EA.ct_Col_SupplierStockRF] = string.Empty;
                //    }
                //    // --- UPD 2010/05/08 ----------<<<<<
                //}
                //else
                //{
                //    //�q�ɒI��
                //    dr[PMSYA02205EA.ct_Col_WarehouseShelfNoRF] = string.Empty;
                //    //�d���݌ɐ�
                //    dr[PMSYA02205EA.ct_Col_SupplierStockRF] = string.Empty;
                //}

                //�q�ɒI��
                dr[PMSYA02205EA.ct_Col_WarehouseShelfNoRF] = disCarShipResultWork.WarehouseShelfNo;
                //�d���݌ɐ�
                dr[PMSYA02205EA.ct_Col_SupplierStockRF] = disCarShipResultWork.SupplierStock;
                // --- UPD 2010/05/16 ----------<<<<<

                //�󔒂���������
                if (count > 1)
                {
                    if (i != 0)
                    {
                        lastDisCarShipResultWork = (ModelShipResultWork)carShipRsltWork[i - 1];
                    }

                    //���y�[�W�ɁA���s�f�[�^���Z�b�g����
                    if (i == 0)
                    {
                        if ((int)modelShipResultList.GroupBySectionDiv == 0)
                        {
                            k++;
                        }
                    }
                }
                // Table��Add
                carShipRsltDt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// �W�v�P�ʂ̒��Ŕ���P��(�Ŕ�,�s��)���قȂ���̂����݂���ꍇ�́A�O���Z�b�g����̏���
        /// </summary>
        /// <param name="modelShipResultList">���o���ʃ��X�g</param>
        /// <param name="modelShipRsltListCndtn">modelShipRsltListCndtn</param>
        /// <remarks>
        /// <br>Note       : �W�v�P�ʂ̒��Ŕ���P��(�Ŕ�,�s��)���قȂ���̂����݂���ꍇ�́A�O���Z�b�g����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010.04.23</br>
        /// </remarks>
        private void DifUnPrcSetZeroWithGroupBy(ref ArrayList modelShipResultList, ModelShipRsltListCndtn modelShipRsltListCndtn)
        {
            //�Ԏ�
            string modeCd = string.Empty;
            //�i��
            string partsNo = string.Empty;
            //�t���^��
            string fullModel = string.Empty;
            //�a�k�R�[�h
            string bLGoodsCode = string.Empty;
            //�o�׃��[�J�[
            string goodsMakerCd = string.Empty;

            string key = string.Empty;
            Hashtable hashtableWithGroupBy = new Hashtable();
            ArrayList arrayListWork = null;

            //���o���ʃ��X�g����W�v�P�ʂ̒��ŐV����Hashtable���쐬����
            foreach (ModelShipResultWork modelShipResultWork in modelShipResultList)
            {
                //�Ԏ�
                modeCd = modelShipResultWork.MakerCode + "/" + modelShipResultWork.ModelCode + "/" + modelShipResultWork.ModelSubCode;
                //�i��
                partsNo = modelShipResultWork.GoodsNo;
                //�t���^��
                fullModel = modelShipResultWork.FullModel;
                //�a�k�R�[�h
                bLGoodsCode = modelShipResultWork.BLGoodsCode.ToString();
                //�o�׃��[�J�[
                goodsMakerCd = modelShipResultWork.GoodsMakerCd.ToString();
                //�Ԏ탁�[�J�[�R�[�h�A�Ԏ�R�[�h�A�Ԏ�T�u�R�[�h�A�t���^���A�a�k�R�[�h�A�o�׃��[�J�[�A�o�וi��
                key = modeCd + "/" + partsNo + "/" + fullModel + "/" + bLGoodsCode + "/" + goodsMakerCd;
                if (modelShipRsltListCndtn.GroupBySectionDiv != 0)
                {
                    //���ьv�㋒�_�R�[�h
                    key += "/" + modelShipResultWork.ResultsAddUpSecCd;
                }

                if (hashtableWithGroupBy.ContainsKey(key))
                {
                    arrayListWork = (ArrayList)hashtableWithGroupBy[key];
                    arrayListWork.Add(modelShipResultWork);
                }
                else
                {
                    arrayListWork = new ArrayList();
                    arrayListWork.Add(modelShipResultWork);
                    hashtableWithGroupBy.Add(key, arrayListWork);
                }
            }

            //�قȂ���̂����݂���ꍇ�́A�O���Z�b�g����
            foreach (ArrayList temp in hashtableWithGroupBy.Values)
            {
                //���q���i�f�[�^.���P��
                double salesUnPrcTaxExcFl = 0;
                bool isZero = false;
                int cnt = 0;
                foreach (ModelShipResultWork tempModelShipResultWork in temp)
                {
                    if (cnt == 0 && salesUnPrcTaxExcFl != tempModelShipResultWork.SalesUnPrcTaxExcFl)
                    {
                        salesUnPrcTaxExcFl = tempModelShipResultWork.SalesUnPrcTaxExcFl;
                    }
                    else if (cnt != 0 && salesUnPrcTaxExcFl != tempModelShipResultWork.SalesUnPrcTaxExcFl)
                    {
                        isZero = true;
                        break;
                    }
                    cnt++;
                }
                // --- UPD 2010/05/08 ---------->>>>>
                //if (isZero)
                //{
                //    foreach (ModelShipResultWork tempModelShipResultWork in temp)
                //    {
                //        tempModelShipResultWork.SalesUnPrcTaxExcFl = 0;
                //    }
                //}

                // ���ʍ��v
                double sumCnt = 0;
                // ���z���v
                long sumMoney = 0;
                // �z�v��
                int cycleNum = 0;

                // �W�v�P�ʂ̒��ŁA������f�[�^��ۗ�����
                foreach (ModelShipResultWork tempModelShipResultWork in temp)
                {
                    sumCnt += tempModelShipResultWork.ShipmentCnt;
                    sumMoney += tempModelShipResultWork.SalesMoneyTaxExc;
                    if (cycleNum != 0)
                    {
                        // �W�v�P�ʂ̒��ŁA������f�[�^���������̂��߁A�\���t���O��ݒ肷��
                        tempModelShipResultWork.IsShowFlg = 1;
                    }
                    cycleNum++;
                }

                // ���ʁA���P���Ƌ��z�̍Đݒ�
                ModelShipResultWork newWork = (ModelShipResultWork)temp[0];
                if (isZero)
                {
                    newWork.SalesUnPrcTaxExcFl = 0;
                }
                newWork.ShipmentCnt = sumCnt;
                newWork.SalesMoneyTaxExc = sumMoney;
                // --- UPD 2010/05/08 ----------<<<<<
            }
        }

        // --- ADD 2010/05/08 ---------->>>>>
        /// <summary>
        /// �����}�X�^�̌�����i�ԁi�D�Ǖi�ԁj�ƌ����惁�[�J�[�i�D�ǃ��[�J�[�j�̐ݒ�
        /// </summary>
        /// <param name="modelShipCndtn">UI���o����</param>
        /// <param name="workList">���o���ʃ��X�g</param>
        /// <param name="msg">���ʃ��b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�̌�����i�ԁi�D�Ǖi�ԁj�ƌ����惁�[�J�[�i�D�ǃ��[�J�[�j��ݒ肷��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010.05.08</br>
        /// </remarks>
        private void SetJoinPartsInfo(ModelShipRsltListCndtn modelShipCndtn, ref ArrayList workList, out string msg)
        {
            msg = string.Empty;

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            //GoodsAcs _goodsAcs = new GoodsAcs();//DEL 2010/05/13
            goodsCndtn.EnterpriseCode = modelShipCndtn.EnterpriseCode;

            ModelShipResultWork modelShipResultWork = null;
            // �����\�����ʂ��A�����}�X�^
            Hashtable orderJoinPartsMap = null;

            foreach (ModelShipResultWork work in workList)
            {
                // ���i��ʂ� 0:�����A�q�ɃR�[�h���P�ȏ�̏ꍇ
                if (work.GoodsKindCode != 0 || modelShipCndtn.WarehouseCode.CompareTo("000001") < 0)
                {
                    continue;
                }
                work.EnterpriseCode = modelShipCndtn.EnterpriseCode;

                orderJoinPartsMap = new Hashtable();

                goodsCndtn.SectionCode = work.ResultsAddUpSecCd;
                goodsCndtn.GoodsNo = work.GoodsNo;
                goodsCndtn.GoodsMakerCd = work.GoodsMakerCd;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;

                goodsCndtn.IsSettingSupplier = 1;
                goodsCndtn.IsSettingVariousMst = 1;

                // �����}�X�^�i�񋟕��j�̎擾
                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> GoodsUnitDataList;

                int status = _goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, false, out partsInfoDataSet, out GoodsUnitDataList, out msg);


                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // --- DEL 2010/05/13 ---------->>>>>
                    //ArrayList partsMakerCdList = new ArrayList();
                    //// �D�ǐݒ�}�X�^�̎擾
                    //foreach (DataRow dr in partsInfoDataSet.OfrPrimeParts.Rows)
                    //{
                    //    partsMakerCdList.Add((int)dr["PartsMakerCd"]);
                    //}

                    //// �����\�����ʂ��A�D�ǐݒ�}�X�^�ɓo�^����Ă��錋���}�X�^�i�񋟕��j��ǉ�����
                    //if (partsMakerCdList.Count > 0)
                    //{
                    // --- DEL 2010/05/13 ----------<<<<<
                    foreach (DataRow dr in partsInfoDataSet.JoinParts.Rows)
                    {
                        // --- DEL 2010/05/13 ---------->>>>>
                        //if (partsMakerCdList.Contains((int)dr["JoinDestMakerCd"]))
                        //{
                        // --- DEL 2010/05/13 ----------<<<<<
                        modelShipResultWork = new ModelShipResultWork();
                        //�����惁�[�J�[�R�[�h
                        modelShipResultWork.JoinDestMakerCd = (int)dr["JoinDestMakerCd"];
                        //������i��(�|�t���i��)
                        modelShipResultWork.JoinDestPartsNo = dr["JoinDestPartsNo"].ToString();
                        if (!orderJoinPartsMap.ContainsKey((int)dr["JoinDispOrder"]))
                        {
                            orderJoinPartsMap.Add((int)dr["JoinDispOrder"], modelShipResultWork);
                        }
                        //}//DEL 2010/05/13
                    }
                    //}//DEL 2010/05/13

                    // �����}�X�^�i���[�U�[�o�^���j�̎擾
                    // �����\�����ʂ��A�����}�X�^�i���[�U�[�o�^���j��ǉ�����
                    foreach (DataRow dr in partsInfoDataSet.UsrJoinParts.Rows)
                    {
                        modelShipResultWork = new ModelShipResultWork();
                        // �����惁�[�J�[�R�[�h
                        modelShipResultWork.JoinDestMakerCd = (int)dr["JoinDestMakerCd"];
                        // ������i��(�|�t���i��)
                        modelShipResultWork.JoinDestPartsNo = dr["JoinDestPartsNo"].ToString();
                        if (!orderJoinPartsMap.ContainsKey((int)dr["JoinDispOrder"]))
                        {
                            orderJoinPartsMap.Add((int)dr["JoinDispOrder"], modelShipResultWork);
                        }
                    }
                }

                // �����\�����ʂ��A�����}�X�^�𒊏o���ʂɐݒ肷��
                if (orderJoinPartsMap != null && orderJoinPartsMap.Count > 0)
                {
                    ArrayList keyList = new ArrayList();
                    foreach(int key in orderJoinPartsMap.Keys)
                    {
                        keyList.Add(key);
                    }
                    keyList.Sort();
                    // --- UPD 2010/05/13 ---------->>>>>
                    //ModelShipResultWork newWork = (ModelShipResultWork)orderJoinPartsMap[(int)keyList[0]];
                    //work.JoinDestMakerCd = newWork.JoinDestMakerCd;
                    //work.JoinDestPartsNo = newWork.JoinDestPartsNo;

                    ArrayList newWorkList = new ArrayList();
                    foreach(int key in keyList)
                    {
                        newWorkList.Add((ModelShipResultWork)orderJoinPartsMap[key]);
                    }

                    object retWork = newWorkList as object;
                    this._iModelShipResultDB.SearchStock(ref retWork, modelShipCndtn.EnterpriseCode, modelShipCndtn.WarehouseCode);
                    newWorkList = retWork as ArrayList;

                    if (newWorkList.Count > 0)
                    {
                        ModelShipResultWork newWork = (ModelShipResultWork)newWorkList[0];
                        work.JoinDestMakerCd = newWork.JoinDestMakerCd;
                        work.JoinDestPartsNo = newWork.JoinDestPartsNo;

                        MakerUMnt maker = null;
                        _goodsAcs.GetMaker(modelShipCndtn.EnterpriseCode, work.JoinDestMakerCd, out maker);
                        if (maker != null)
                        {
                            //work.MakerName2 = maker.MakerKanaName;//// DEL 2010.05.19 zhangsf FOR Redmine #7784
                            work.MakerName2 = maker.MakerName;//// ADD 2010.05.19 zhangsf FOR Redmine #7784
                        }
                    }
                    // --- UPD 2010/05/13 ----------<<<<<
                }
            }
        }
        // --- ADD 2010/05/08 ----------<<<<<

        #endregion �� Private Method

    }
}
