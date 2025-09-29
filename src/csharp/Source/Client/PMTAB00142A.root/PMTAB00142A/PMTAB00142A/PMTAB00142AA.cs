//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �FPMTAB �����񓚏���(����) �e�[�u���A�N�Z�X�N���X
// �v���O�����T�v   �FPMTAB�풓�������p�����[�^�Ŏԗ��A���i�����������n�����
//                    �ԗ��A���i�����������ԗ��A���i�̌������s���A
//                    �擾��������SCM_DB�̌������ʊ֘A�̃e�[�u���ɏ�����
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01  �쐬�S�� : songg
// �� �� ��  2013/05/29   �쐬���e : PMTAB �����񓚏���(����)
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/18  �쐬���e : �ԗ��������A�S�I���̃��W�b�N��ǉ�����
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/20  �쐬���e : �ԗ��������SCM-DB��PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^���X�V���܂��B
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37231�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/25  �쐬���e : �^�u���b�g���O�Ή�
//----------------------------------------------------------------------//
// �C�����e�@���O������
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/29  �쐬���e : ���O������
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39496�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/08/01  �쐬���e : Rdmine#39496�Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/10/08  �C�����e : �R�`���i���x�x���Ή� SCM�d�|�ꗗ��10579
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/10/08  �C�����e : �R�`���i���x�x���Ή� SCM�d�|�ꗗ��10579
//----------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB �����񓚏���(����) �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       :PMTAB�풓�������p�����[�^�Ŏԗ��A���i�����������n�����</br>
    /// <br>            �ԗ��A���i�����������ԗ��A���i�̌������s���A�擾��������</br>
    /// <br>            SCM_DB�̌������ʊ֘A�̃e�[�u���ɏ�����</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
    public class ScmSearchForTablet
    {
        #region �� Constructor
        /// <summary>
        /// PMTAB �����񓚏���(����) Constructor
        /// </summary>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public ScmSearchForTablet()
        {
            // �����������A�N�Z�X
            _searchAcs = new PMTAB00142AB();
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        }
        #endregion �� Constructor

        #region �� Private Member
        // �����A�N�Z�X
        PMTAB00142AB _searchAcs;
        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        private const string CLASS_NAME = "ScmSearchForTablet";
        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        #endregion �� Private Member

        #region �� Property
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        private GoodsAcs _goodsAccesser;
        public GoodsAcs GoodsAccesser
        {
            get { return _goodsAccesser; }
            set { _goodsAccesser = value; }
        }
        // �L�����y�[�������D��ݒ胊�X�g
        private ArrayList _campaignPrcPrStList;
        public ArrayList CampaignPrcPrStList
        {
            get { return _campaignPrcPrStList; }
            set { _campaignPrcPrStList = value; }
        }
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

        #endregion // �� Property

        #region �� Public Method
        /// <summary>
        /// PMTAB �����񓚏���(����)����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="blGoodsCode">�a�k�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V�����R�[�h</param>
        /// <param name="tabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchForTablet(string enterpriseCode,
            string sectionCode, string goodsNo, int blGoodsCode, int customerCode, string businessSessionId, string tabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(����)�����@�J�n����������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(����)�����@�J�n��");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, "�d�����z�����敪�ݒ�}�X�^�@�擾����"
                + "�@�Ɩ��Z�b�V����ID�F" + businessSessionId
                + "�@PMTAB���׎���GUID�F" + tabSearchGuid
                );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            message = "";

            if (string.IsNullOrEmpty(businessSessionId))
            {
                message = "�Ɩ��Z�b�V�����R�[�h������܂���";
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, message);
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(����)�����@�I������������");
                EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(����)�����@�I����");
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (string.IsNullOrEmpty(tabSearchGuid))
            {
                message = "PMTAB���׎���GUID������܂���";
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, message);
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(����)�����@�I������������");
                EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(����)�����@�I����");
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� " + message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            }

            string pmTabSearchGuid = tabSearchGuid;

            // ADD 2013/08/01 �g�� Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._searchAcs.SetDataInit(enterpriseCode, customerCode);
            // ADD 2013/08/01 �g�� Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            this._searchAcs.GoodsAccesser = GoodsAccesser;
            this._searchAcs.CampaignPrcPrStList = CampaignPrcPrStList;
            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            // �i�Ԍ����̏ꍇ
            if (!string.IsNullOrEmpty(goodsNo))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                //return SearchByGoodsNoForTablet(enterpriseCode,
                //                            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                //                            out message);
                EasyLogger.Write(CLASS_NAME, methodName,
                    "�i�Ԍ��������@��ƃR�[�h�F" + enterpriseCode
                    + "  ���_�R�[�h�F" + sectionCode
                    + "  �Ɩ��Z�b�V����ID�F" + businessSessionId
                    + "  ���׎���GUID�F" + pmTabSearchGuid
                    + "  ���i�ԍ��F" + goodsNo
                    + "  BL�R�[�h�F" + blGoodsCode
                    + "  ���Ӑ�R�[�h�F" + customerCode
                    );

                int status = SearchByGoodsNoForTablet(enterpriseCode,
                                            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                                            out message);

                EasyLogger.Write(CLASS_NAME, methodName, "�i�Ԍ��� status�F" + status.ToString() + " " + message);
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(����)�����@�I������������");
                EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(����)�����@�I����");
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return status;
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            // BL�R�[�h�����̏ꍇ
            else if (0 != blGoodsCode)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                //return SearchByCarAndBLCodeForTablet(enterpriseCode,
                //            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                //            out message);
                EasyLogger.Write(CLASS_NAME, methodName,
                    "BL�R�[�h�����@��ƃR�[�h�F" + enterpriseCode
                    + "  ���_�R�[�h�F" + sectionCode
                    + "  �Ɩ��Z�b�V����ID�F" + businessSessionId
                    + "  ���׎���GUID�F" + pmTabSearchGuid
                    + "  ���i�ԍ��F" + goodsNo
                    + "  BL�R�[�h�F" + blGoodsCode
                    + "  ���Ӑ�R�[�h�F" + customerCode
                    );

                int status = SearchByCarAndBLCodeForTablet(enterpriseCode,
                            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                            out message);

                EasyLogger.Write(CLASS_NAME, methodName, "BL�R�[�h���� status�F" + status.ToString() + " " + message);
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(����)�����@�I������������");
                EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(����)�����@�I����");
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return status;
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�������(�i��orBL�R�[�h)�̔��肪�ł��܂���");
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(����)�����@�I������������");
                EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(����)�����@�I����");
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }
        #region �� BL�R�[�h����

        /// <summary>
        /// BL�R�[�h��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���������ƍs���܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i�ԃR�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByCarAndBLCodeForTablet(string enterpriseCode,
            string sectionCode, string goodsNo, int blGoodsCode, int customerCode, string businessSessionId, string pmTabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchByCarAndBLCodeForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            int makerCode = 0;
            int modelCode = 0;
            int modelSubCode = 0;
            int modelDesignationNo = 0;
            int categoryNo = 0;
            string fullModel = "";
            string carInspectCertModel = "";


            // SCM DB ����PMTAB����f�[�^(�ԗ����)���擾����
            ArrayList pmTabSalesDtCarList = new ArrayList();
            status = _searchAcs.ReadPmTabSalesDtCar(enterpriseCode, businessSessionId, ref pmTabSalesDtCarList);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "SCM DB ����PMTAB����f�[�^(�ԗ����)���擾 status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            if (pmTabSalesDtCarList.Count > 0)
            {
                PmTabSalesDtCarWork pmTabSalesDtCarWork = pmTabSalesDtCarList[0] as PmTabSalesDtCarWork;
                makerCode = pmTabSalesDtCarWork.MakerCode;
                modelCode = pmTabSalesDtCarWork.ModelCode;
                modelSubCode = pmTabSalesDtCarWork.ModelSubCode;
                modelDesignationNo = pmTabSalesDtCarWork.ModelDesignationNo;
                categoryNo = pmTabSalesDtCarWork.CategoryNo;
                fullModel = pmTabSalesDtCarWork.FullModel;
                carInspectCertModel = pmTabSalesDtCarWork.CarInspectCertModel;
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB����f�[�^(�ԗ����) �擾���ʁi�ԗ����������j"
                    + "�@���[�J�[�R�[�h:" + pmTabSalesDtCarWork.MakerCode.ToString()
                    + "�@�Ԏ�R�[�h:" + pmTabSalesDtCarWork.ModelCode.ToString()
                    + "�@�Ԏ�T�u�R�[�h:" + pmTabSalesDtCarWork.ModelSubCode.ToString()
                    + "�@�^���w��ԍ�:" + pmTabSalesDtCarWork.ModelDesignationNo.ToString()
                    + "�@�ޕʔԍ�:" + pmTabSalesDtCarWork.CategoryNo.ToString()
                    + "�@�^���i�t���^�j:" + pmTabSalesDtCarWork.FullModel
                    + "�@�Ԍ��،^��:" + pmTabSalesDtCarWork.CarInspectCertModel
                    );
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB����f�[�^(�ԗ����) �擾���� 0 ��");
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }



            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //return status = _searchAcs.SearchByCarAndBLCodeForTablet(enterpriseCode, sectionCode,
            //    goodsNo, blGoodsCode, customerCode,
            //    makerCode, modelCode, modelSubCode,
            //    modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
            //    businessSessionId, pmTabSearchGuid, out message
            //    , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0])); //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή� ----<<<<<
            status = _searchAcs.SearchByCarAndBLCodeForTablet(enterpriseCode, sectionCode,
                goodsNo, blGoodsCode, customerCode,
                makerCode, modelCode, modelSubCode,
                modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
                businessSessionId, pmTabSearchGuid, out message
                , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0])); //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή� ----<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, "BL�R�[�h�����@status�F" + status.ToString() + " " + message);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return status;
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }
        #endregion ��BL�R�[�h����

        #region �� �i�Ԍ���
        /// <summary>
        /// �i�Ԍ�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�Ԍ��������ƍs���܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i�ԃR�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchByGoodsNoForTablet(string enterpriseCode,
            string sectionCode, string goodsNo, int blGoodsCode, int customerCode, string businessSessionId, string pmTabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchByGoodsNoForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            int makerCode = 0;
            int modelCode = 0;
            int modelSubCode = 0;
            int modelDesignationNo = 0;
            int categoryNo = 0;
            string fullModel = "";
            string carInspectCertModel = "";

            // SCM DB ����PMTAB����f�[�^(�ԗ����)���擾����
            ArrayList pmTabSalesDtCarList = new ArrayList();
            status = _searchAcs.ReadPmTabSalesDtCar(enterpriseCode, businessSessionId, ref pmTabSalesDtCarList);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "SCM DB ����PMTAB����f�[�^(�ԗ����)���擾 status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            if (pmTabSalesDtCarList.Count > 0)
            {
                PmTabSalesDtCarWork pmTabSalesDtCarWork = pmTabSalesDtCarList[0] as PmTabSalesDtCarWork;
                makerCode = pmTabSalesDtCarWork.MakerCode;
                modelCode = pmTabSalesDtCarWork.ModelCode;
                modelSubCode = pmTabSalesDtCarWork.ModelSubCode;
                modelDesignationNo = pmTabSalesDtCarWork.ModelDesignationNo;
                categoryNo = pmTabSalesDtCarWork.CategoryNo;
                fullModel = pmTabSalesDtCarWork.FullModel;
                carInspectCertModel = pmTabSalesDtCarWork.CarInspectCertModel;
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB����f�[�^(�ԗ����) �擾���ʁi�ԗ����������j"
                    + "�@���[�J�[�R�[�h:" + pmTabSalesDtCarWork.MakerCode.ToString()
                    + "�@�Ԏ�R�[�h:" + pmTabSalesDtCarWork.ModelCode.ToString()
                    + "�@�Ԏ�T�u�R�[�h:" + pmTabSalesDtCarWork.ModelSubCode.ToString()
                    + "�@�^���w��ԍ�:" + pmTabSalesDtCarWork.ModelDesignationNo.ToString()
                    + "�@�ޕʔԍ�:" + pmTabSalesDtCarWork.CategoryNo.ToString()
                    + "�@�^���i�t���^�j:" + pmTabSalesDtCarWork.FullModel
                    + "�@�Ԍ��،^��:" + pmTabSalesDtCarWork.CarInspectCertModel
                    );
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB����f�[�^(�ԗ����) �擾���� 0 ��");
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }



            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //return status = _searchAcs.SearchByGoodsNoForTablet(enterpriseCode, sectionCode,
            //    goodsNo, blGoodsCode, customerCode,
            //    makerCode, modelCode, modelSubCode,
            //    modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
            //    businessSessionId, pmTabSearchGuid, out message
            //    , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0])); // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή�
            status = _searchAcs.SearchByGoodsNoForTablet(enterpriseCode, sectionCode,
                goodsNo, blGoodsCode, customerCode,
                makerCode, modelCode, modelSubCode,
                modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
                businessSessionId, pmTabSearchGuid, out message
                , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0]));
            EasyLogger.Write(CLASS_NAME, methodName, "�i�Ԍ����@status�F" + status.ToString() + " " + message);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            return status;
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }
        #endregion �� �i�Ԍ���

        #endregion �� Public Method
    }
}
