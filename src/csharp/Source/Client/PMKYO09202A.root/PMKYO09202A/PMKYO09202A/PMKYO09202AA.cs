//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�Ώېݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ����M�Ώېݒ�̕ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : ���O
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����M�Ώېݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M�Ώېݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br>Update Note: 2020/09/25 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>           : PMKOBETSU-3877�̑Ή�</br>
    /// <br></br>
    /// </remarks>
    public class SendSetAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private ISendSetDB _iSendSetDB = null;

        // ���[�J���c�a���[�h
        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br></br>
        /// </remarks>
        public SendSetAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSendSetDB = (ISendSetDB)MediationSendSetDB.GetSendSetDB();
        }

        #endregion

        #region [���[�J���A�N�Z�X�p]
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        #endregion

        #region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="secMngSndRcvList">UI�f�[�^�N���X</param>
        /// <param name="secMngSndRcvDtlList"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �X�V�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public int Write(ref List<SecMngSndRcv> secMngSndRcvList, ref List<SecMngSndRcvDtl> secMngSndRcvDtlList)
        {
            //����M�Ώ�
            ArrayList secMngSndRcvWorkList = new ArrayList();

            foreach(SecMngSndRcv secMngSndRcv in secMngSndRcvList)
            {
                // UI�f�[�^�N���X�����[�N
                SecMngSndRcvWork secMngSndRcvWork = CopyToSecMngSndRcvWorkFromSecMngSet(secMngSndRcv);

                secMngSndRcvWorkList.Add(secMngSndRcvWork);
            }

            //����M�Ώۏڍ�
            ArrayList secMngSndRcvDtlWorkList = new ArrayList();

            foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
            {
                // UI�f�[�^�N���X�����[�N
                SecMngSndRcvDtlWork secMngSndRcvDtlWork = CopyToSecMngSndRcvDtlWorkFromSecMngDtlSet(secMngSndRcvDtl);

                secMngSndRcvDtlWorkList.Add(secMngSndRcvDtlWork);
            }


            object objsecMngSndRcvWorkList = secMngSndRcvWorkList;

            object objsecMngSndRcvDtlWorkList = secMngSndRcvDtlWorkList;

            int status = 0;
            int writeMode = 0;

            // �������ݏ���
            status = this._iSendSetDB.Write(ref objsecMngSndRcvWorkList, ref objsecMngSndRcvDtlWorkList, writeMode);

            return status;
        }

        #endregion

        #region -- �������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����M�Ώېݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retDtlList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����M�Ώېݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public int SearchAll(out List<SecMngSndRcv> retList, out List<SecMngSndRcvDtl> retDtlList, string enterpriseCode)
        {
            return SearchAll(out retList, out retDtlList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///����M�Ώېݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retDtlList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����M�Ώېݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public int SearchAll(out List<SecMngSndRcv> retList, out List<SecMngSndRcvDtl> retDtlList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            return SearchProc(out retList, out retDtlList, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����M�Ώېݒ茟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retDtlList">�Ǎ����ʃR���N�V����</param> 
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out List<SecMngSndRcv> retList, out List<SecMngSndRcvDtl> retDtlList, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, SearchMode searchMode)
        {
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            //���_�Ǘ�����M�Ώ�
            SecMngSndRcvWork pSecMngSndRcvWork = new SecMngSndRcvWork();
            pSecMngSndRcvWork.EnterpriseCode = enterpriseCode;
            //���_�Ǘ�����M�Ώۏڍ�
            SecMngSndRcvDtlWork pSecMngSndRcvDtlWork = new SecMngSndRcvDtlWork();
            pSecMngSndRcvDtlWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new List<SecMngSndRcv>();
            retDtlList = new List<SecMngSndRcvDtl>();

            ArrayList secMngSndRcvWorkList = new ArrayList();
            ArrayList secMngSndRcvDtlWorkList = new ArrayList();

            // ���f�[�^�L��������
            nextData = false;

            object paraobj = pSecMngSndRcvWork;
            object paraDtlobj = pSecMngSndRcvDtlWork;

            object retobj = null;
            object retDtlobj = null;

            status = this._iSendSetDB.Search(out retobj, paraobj, 0, logicalMode);

            status = this._iSendSetDB.SearchDtl(out retDtlobj, paraDtlobj, 0, logicalMode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                secMngSndRcvWorkList = retobj as ArrayList;

                secMngSndRcvDtlWorkList = retDtlobj as ArrayList;

                if (secMngSndRcvWorkList == null || secMngSndRcvDtlWorkList == null)
                {
                    return status;
                }

                foreach (SecMngSndRcvWork secMngSndRcvWork in secMngSndRcvWorkList)
                {
                    retList.Add(CopyToSecMngSetFromSecMngSndRcvWork(secMngSndRcvWork));
                }

                foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in secMngSndRcvDtlWorkList)
                {
                    retDtlList.Add(CopyToSecMngDtlSetFromSecMngSndRcvDtlWork(secMngSndRcvDtlWork));
                }

            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                ((retList.Count == 0) || (retDtlList.Count == 0)))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        # endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_�Ǘ�����M�Ώېݒ胏�[�N�N���X�ˊ�ƃR�[�h�ݒ�N���X�j
        /// </summary>
        /// <param name="secMngSndRcvWork">���_�Ǘ�����M�Ώېݒ胏�[�N�N���X</param>
        /// <returns>���_�Ǘ�����M�Ώېݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ�����M�Ώېݒ胏�[�N�N���X���狒�_�Ǘ�����M�Ώۏڍאݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
        private SecMngSndRcv CopyToSecMngSetFromSecMngSndRcvWork(SecMngSndRcvWork secMngSndRcvWork)
        {
            SecMngSndRcv secMngSndRcv = new SecMngSndRcv();
            secMngSndRcv.CreateDateTime = secMngSndRcvWork.CreateDateTime;
            secMngSndRcv.UpdateDateTime = secMngSndRcvWork.UpdateDateTime;
            secMngSndRcv.EnterpriseCode = secMngSndRcvWork.EnterpriseCode;
            secMngSndRcv.FileHeaderGuid = secMngSndRcvWork.FileHeaderGuid;
            secMngSndRcv.UpdEmployeeCode = secMngSndRcvWork.UpdEmployeeCode;
            secMngSndRcv.UpdAssemblyId1 = secMngSndRcvWork.UpdAssemblyId1;
            secMngSndRcv.UpdAssemblyId2 = secMngSndRcvWork.UpdAssemblyId2;
            secMngSndRcv.LogicalDeleteCode = secMngSndRcvWork.LogicalDeleteCode;
            secMngSndRcv.DisplayOrder = secMngSndRcvWork.DisplayOrder;
            secMngSndRcv.MasterName = secMngSndRcvWork.MasterName;
            secMngSndRcv.FileId = secMngSndRcvWork.FileId;
            secMngSndRcv.FileNm = secMngSndRcvWork.FileNm;
            secMngSndRcv.UserGuideDivCd = secMngSndRcvWork.UserGuideDivCd;
            secMngSndRcv.SecMngSendDiv = secMngSndRcvWork.SecMngSendDiv;
            secMngSndRcv.SecMngRecvDiv = secMngSndRcvWork.SecMngRecvDiv;
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            secMngSndRcv.AcptAnOdrSendDiv = secMngSndRcvWork.AcptAnOdrSendDiv;
            secMngSndRcv.AcptAnOdrRecvDiv = secMngSndRcvWork.AcptAnOdrRecvDiv;
            secMngSndRcv.ShipmentSendDiv = secMngSndRcvWork.ShipmentSendDiv;
            secMngSndRcv.ShipmentRecvDiv = secMngSndRcvWork.ShipmentRecvDiv;
            secMngSndRcv.EstimateSendDiv = secMngSndRcvWork.EstimateSendDiv;
            secMngSndRcv.EstimateRecvDiv = secMngSndRcvWork.EstimateRecvDiv;
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
            return secMngSndRcv;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_�Ǘ�����M�Ώۏڍאݒ胏�[�N�N���X�ˊ�ƃR�[�h�ݒ�N���X�j
        /// </summary>
        /// <param name="secMngSndRcvDtlWork">���_�Ǘ�����M�Ώۏڍאݒ胏�[�N�N���X</param>
        /// <returns>���_�Ǘ�����M�Ώۏڍאݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ�����M�Ώۏڍאݒ胏�[�N�N���X���狒�_�Ǘ�����M�Ώۏڍאݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private SecMngSndRcvDtl CopyToSecMngDtlSetFromSecMngSndRcvDtlWork(SecMngSndRcvDtlWork secMngSndRcvDtlWork)
        {
            SecMngSndRcvDtl secMngSndRcvDtl = new SecMngSndRcvDtl();

            secMngSndRcvDtl.CreateDateTime = secMngSndRcvDtlWork.CreateDateTime;
            secMngSndRcvDtl.UpdateDateTime = secMngSndRcvDtlWork.UpdateDateTime;
            secMngSndRcvDtl.EnterpriseCode = secMngSndRcvDtlWork.EnterpriseCode;
            secMngSndRcvDtl.FileHeaderGuid = secMngSndRcvDtlWork.FileHeaderGuid;
            secMngSndRcvDtl.UpdEmployeeCode = secMngSndRcvDtlWork.UpdEmployeeCode;
            secMngSndRcvDtl.UpdAssemblyId1 = secMngSndRcvDtlWork.UpdAssemblyId1;
            secMngSndRcvDtl.UpdAssemblyId2 = secMngSndRcvDtlWork.UpdAssemblyId2;
            secMngSndRcvDtl.LogicalDeleteCode = secMngSndRcvDtlWork.LogicalDeleteCode;
            secMngSndRcvDtl.FileId = secMngSndRcvDtlWork.FileId;
            secMngSndRcvDtl.FileNm = secMngSndRcvDtlWork.FileNm;
            secMngSndRcvDtl.ItemId = secMngSndRcvDtlWork.ItemId;
            secMngSndRcvDtl.ItemName = secMngSndRcvDtlWork.ItemName;
            secMngSndRcvDtl.DataUpdateDiv = secMngSndRcvDtlWork.DataUpdateDiv;
            secMngSndRcvDtl.DisplayOrder = secMngSndRcvDtlWork.DisplayOrder;

            return secMngSndRcvDtl;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_�Ǘ�����M�Ώېݒ�N���X�ˋ��_�Ǘ�����M�Ώېݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="secMngSndRcv">���_�Ǘ�����M�Ώېݒ�N���X</param>
        /// <returns>���_�Ǘ�����M�Ώېݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ�����M�Ώېݒ�N���X���狒�_�Ǘ�����M�Ώېݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
        /// </remarks>
        private SecMngSndRcvWork CopyToSecMngSndRcvWorkFromSecMngSet(SecMngSndRcv secMngSndRcv)
        {
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();

            secMngSndRcvWork.CreateDateTime = secMngSndRcv.CreateDateTime;
            secMngSndRcvWork.UpdateDateTime = secMngSndRcv.UpdateDateTime;
            secMngSndRcvWork.EnterpriseCode = secMngSndRcv.EnterpriseCode;
            secMngSndRcvWork.FileHeaderGuid = secMngSndRcv.FileHeaderGuid;
            secMngSndRcvWork.UpdEmployeeCode = secMngSndRcv.UpdEmployeeCode;
            secMngSndRcvWork.UpdAssemblyId1 = secMngSndRcv.UpdAssemblyId1;
            secMngSndRcvWork.UpdAssemblyId2 = secMngSndRcv.UpdAssemblyId2;
            secMngSndRcvWork.LogicalDeleteCode = secMngSndRcv.LogicalDeleteCode;
            secMngSndRcvWork.DisplayOrder = secMngSndRcv.DisplayOrder;
            secMngSndRcvWork.MasterName = secMngSndRcv.MasterName;
            secMngSndRcvWork.FileId = secMngSndRcv.FileId;
            secMngSndRcvWork.FileNm = secMngSndRcv.FileNm;
            secMngSndRcvWork.UserGuideDivCd = secMngSndRcv.UserGuideDivCd;
            secMngSndRcvWork.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
            secMngSndRcvWork.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            secMngSndRcvWork.AcptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
            secMngSndRcvWork.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
            secMngSndRcvWork.ShipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
            secMngSndRcvWork.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
            secMngSndRcvWork.EstimateSendDiv = secMngSndRcv.EstimateSendDiv;
            secMngSndRcvWork.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

            return secMngSndRcvWork;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_�Ǘ�����M�Ώۏڍאݒ�N���X�ˋ��_�Ǘ�����M�Ώۏڍאݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="secMngSndRcvDtl">���_�Ǘ�����M�Ώۏڍאݒ�N���X</param>
        /// <returns>���_�Ǘ�����M�Ώۏڍאݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ�����M�Ώۏڍאݒ�N���X���狒�_�Ǘ�����M�Ώۏڍאݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private SecMngSndRcvDtlWork CopyToSecMngSndRcvDtlWorkFromSecMngDtlSet(SecMngSndRcvDtl secMngSndRcvDtl)
        {
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = new SecMngSndRcvDtlWork();

            secMngSndRcvDtlWork.CreateDateTime = secMngSndRcvDtl.CreateDateTime;
            secMngSndRcvDtlWork.UpdateDateTime = secMngSndRcvDtl.UpdateDateTime;
            secMngSndRcvDtlWork.EnterpriseCode = secMngSndRcvDtl.EnterpriseCode;
            secMngSndRcvDtlWork.FileHeaderGuid = secMngSndRcvDtl.FileHeaderGuid;
            secMngSndRcvDtlWork.UpdEmployeeCode = secMngSndRcvDtl.UpdEmployeeCode;
            secMngSndRcvDtlWork.UpdAssemblyId1 = secMngSndRcvDtl.UpdAssemblyId1;
            secMngSndRcvDtlWork.UpdAssemblyId2 = secMngSndRcvDtl.UpdAssemblyId2;
            secMngSndRcvDtlWork.LogicalDeleteCode = secMngSndRcvDtl.LogicalDeleteCode;
            secMngSndRcvDtlWork.FileId = secMngSndRcvDtl.FileId;
            secMngSndRcvDtlWork.FileNm = secMngSndRcvDtl.FileNm;
            secMngSndRcvDtlWork.ItemId = secMngSndRcvDtl.ItemId;
            secMngSndRcvDtlWork.ItemName = secMngSndRcvDtl.ItemName;
            secMngSndRcvDtlWork.DataUpdateDiv = secMngSndRcvDtl.DataUpdateDiv;

            return secMngSndRcvDtlWork;

        }

        # endregion
    }
}
