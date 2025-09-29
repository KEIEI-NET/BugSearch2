//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �I�[�g�o�b�N�X�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/08/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �I�[�g�o�b�N�X�ݒ�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br></br>
    /// </remarks>
    public class SAndESettingAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private ISAndESettingDB _iSAndESettingDB = null;

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// <br></br>
        /// </remarks>
        public SAndESettingAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSAndESettingDB = (ISAndESettingDB)MediationSAndESettingDB.GetSAndESettingDB();
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
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="sAndESetting">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int Write(ref SAndESetting sAndESetting)
        {
            // UI�f�[�^�N���X�����[�N
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);

            object objSAndESettingWork = sAndESettingWork;

            int status = 0;
            int writeMode = 0;

            // �������ݏ���
            status = this._iSAndESettingDB.Write(ref objSAndESettingWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                sAndESettingWork = objSAndESettingWork as SAndESettingWork;

                // �N���X�������o�R�s�[
                sAndESetting = CopyToSAndESettingFromSAndESettingWork(sAndESettingWork);
            }

            return status;
        }

        #endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="sAndESetting">�I�[�g�o�b�N�X�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int LogicalDelete(ref SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);
            object objSAndESettingWork = sAndESettingWork;

            // ���_���_���폜
            int status = this._iSAndESettingDB.LogicalDelete(ref objSAndESettingWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                sAndESettingWork = objSAndESettingWork as SAndESettingWork;

                // �N���X�������o�R�s�[
                sAndESetting = CopyToSAndESettingFromSAndESettingWork(sAndESettingWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="allDefSet">�I�[�g�o�b�N�X�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int Delete(SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);

            // XML�֕ϊ����A������̃o�C�i����
            object objSAndESettingWork = sAndESettingWork;

            // ���_��񕨗��폜
            int status = this._iSAndESettingDB.Delete(ref objSAndESettingWork);

            return status;
        }

        #endregion

        #region -- ������������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>  
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            SAndESettingWork sAndESettingWork = new SAndESettingWork();

            sAndESettingWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList sAndESettingWorkList = new ArrayList();
            sAndESettingWorkList.Clear();

            object paraobj = sAndESettingWork;
            object retobj = null;

            status = this._iSAndESettingDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sAndESettingWorkList = retobj as ArrayList;

                foreach (SAndESettingWork wkSAndESettingWork in sAndESettingWorkList)
                {
                    retList.Add(CopyToSAndESettingFromSAndESettingWork(wkSAndESettingWork));
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="allDefSet">�I�[�g�o�b�N�X�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int Revival(ref SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);

            // XML�֕ϊ����A������̃o�C�i����
            object objSAndESettingWork = sAndESettingWork;

            // ��������
            int status = this._iSAndESettingDB.RevivalLogicalDelete(ref objSAndESettingWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                sAndESettingWork = objSAndESettingWork as SAndESettingWork;

                // �N���X�������o�R�s�[
                sAndESetting = CopyToSAndESettingFromSAndESettingWork(sAndESettingWork);

            }

            return status;
        }

        # endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�I�[�g�o�b�N�X�ݒ�}�X�^���[�N�N���X�˃I�[�g�o�b�N�X�ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="sAndESettingWork">�I�[�g�o�b�N�X�ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�I�[�g�o�b�N�X�ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^���[�N�N���X����I�[�g�o�b�N�X�ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SAndESetting CopyToSAndESettingFromSAndESettingWork(SAndESettingWork sAndESettingWork)
        {
            SAndESetting sAndESetting = new SAndESetting();
            sAndESetting.CreateDateTime = sAndESettingWork.CreateDateTime;
            sAndESetting.UpdateDateTime = sAndESettingWork.UpdateDateTime;
            sAndESetting.EnterpriseCode = sAndESettingWork.EnterpriseCode;
            sAndESetting.FileHeaderGuid = sAndESettingWork.FileHeaderGuid;
            sAndESetting.UpdEmployeeCode = sAndESettingWork.UpdEmployeeCode;
            sAndESetting.UpdAssemblyId1 = sAndESettingWork.UpdAssemblyId1;
            sAndESetting.UpdAssemblyId2 = sAndESettingWork.UpdAssemblyId2;
            sAndESetting.LogicalDeleteCode = sAndESettingWork.LogicalDeleteCode;
            sAndESetting.SectionCode = sAndESettingWork.SectionCode;
            sAndESetting.CustomerCode = sAndESettingWork.CustomerCode;
            sAndESetting.AddresseeShopCd = sAndESettingWork.AddresseeShopCd;
            sAndESetting.SAndEMngCode = sAndESettingWork.SAndEMngCode;
            sAndESetting.ExpenseDivCd = sAndESettingWork.ExpenseDivCd;
            sAndESetting.DirectSendingCd = sAndESettingWork.DirectSendingCd;
            sAndESetting.AcptAnOrderDiv = sAndESettingWork.AcptAnOrderDiv;
            sAndESetting.DelivererCd = sAndESettingWork.DelivererCd;
            sAndESetting.DelivererNm = sAndESettingWork.DelivererNm;
            sAndESetting.DelivererAddress = sAndESettingWork.DelivererAddress;
            sAndESetting.DelivererPhoneNum = sAndESettingWork.DelivererPhoneNum;
            sAndESetting.TradCompName = sAndESettingWork.TradCompName;
            sAndESetting.TradCompSectName = sAndESettingWork.TradCompSectName;
            sAndESetting.PureTradCompCd = sAndESettingWork.PureTradCompCd;
            sAndESetting.PureTradCompRate = sAndESettingWork.PureTradCompRate;
            sAndESetting.PriTradCompCd = sAndESettingWork.PriTradCompCd;
            sAndESetting.PriTradCompRate = sAndESettingWork.PriTradCompRate;
            sAndESetting.ABGoodsCode = sAndESettingWork.ABGoodsCode;
            sAndESetting.CommentReservedDiv = sAndESettingWork.CommentReservedDiv;
            sAndESetting.GoodsMakerCd1 = sAndESettingWork.GoodsMakerCd1;
            sAndESetting.GoodsMakerCd2 = sAndESettingWork.GoodsMakerCd2;
            sAndESetting.GoodsMakerCd3 = sAndESettingWork.GoodsMakerCd3;
            sAndESetting.GoodsMakerCd4 = sAndESettingWork.GoodsMakerCd4;
            sAndESetting.GoodsMakerCd5 = sAndESettingWork.GoodsMakerCd5;
            sAndESetting.GoodsMakerCd6 = sAndESettingWork.GoodsMakerCd6;
            sAndESetting.GoodsMakerCd7 = sAndESettingWork.GoodsMakerCd7;
            sAndESetting.GoodsMakerCd8 = sAndESettingWork.GoodsMakerCd8;
            sAndESetting.GoodsMakerCd9 = sAndESettingWork.GoodsMakerCd9;
            sAndESetting.GoodsMakerCd10 = sAndESettingWork.GoodsMakerCd10;
            sAndESetting.GoodsMakerCd11 = sAndESettingWork.GoodsMakerCd11;
            sAndESetting.GoodsMakerCd12 = sAndESettingWork.GoodsMakerCd12;
            sAndESetting.GoodsMakerCd13 = sAndESettingWork.GoodsMakerCd13;
            sAndESetting.GoodsMakerCd14 = sAndESettingWork.GoodsMakerCd14;
            sAndESetting.GoodsMakerCd15 = sAndESettingWork.GoodsMakerCd15;
            sAndESetting.PartsOEMDiv = sAndESettingWork.PartsOEMDiv;
            sAndESetting.SectionName = sAndESettingWork.SectionName;
            sAndESetting.CustomerName = sAndESettingWork.CustomerName;

            return sAndESetting;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�I�[�g�o�b�N�X�ݒ�}�X�^�N���X�˃I�[�g�o�b�N�X�ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="allDefSet">�I�[�g�o�b�N�X�ݒ�}�X�^�N���X</param>
        /// <returns>�I�[�g�o�b�N�X�ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�N���X����I�[�g�o�b�N�X�ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SAndESettingWork CopyToSAndESettingWorkFromSAndESetting(SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = new SAndESettingWork();
            sAndESettingWork.CreateDateTime = sAndESetting.CreateDateTime;
            sAndESettingWork.UpdateDateTime = sAndESetting.UpdateDateTime;
            sAndESettingWork.EnterpriseCode = sAndESetting.EnterpriseCode;
            sAndESettingWork.FileHeaderGuid = sAndESetting.FileHeaderGuid;
            sAndESettingWork.UpdEmployeeCode = sAndESetting.UpdEmployeeCode;
            sAndESettingWork.UpdAssemblyId1 = sAndESetting.UpdAssemblyId1;
            sAndESettingWork.UpdAssemblyId2 = sAndESetting.UpdAssemblyId2;
            sAndESettingWork.LogicalDeleteCode = sAndESetting.LogicalDeleteCode;
            sAndESettingWork.SectionCode = sAndESetting.SectionCode;
            sAndESettingWork.CustomerCode = sAndESetting.CustomerCode;
            sAndESettingWork.AddresseeShopCd = sAndESetting.AddresseeShopCd;
            sAndESettingWork.SAndEMngCode = sAndESetting.SAndEMngCode;
            sAndESettingWork.ExpenseDivCd = sAndESetting.ExpenseDivCd;
            sAndESettingWork.DirectSendingCd = sAndESetting.DirectSendingCd;
            sAndESettingWork.AcptAnOrderDiv = sAndESetting.AcptAnOrderDiv;
            sAndESettingWork.DelivererCd = sAndESetting.DelivererCd;
            sAndESettingWork.DelivererNm = sAndESetting.DelivererNm;
            sAndESettingWork.DelivererAddress = sAndESetting.DelivererAddress;
            sAndESettingWork.DelivererPhoneNum = sAndESetting.DelivererPhoneNum;
            sAndESettingWork.TradCompName = sAndESetting.TradCompName;
            sAndESettingWork.TradCompSectName = sAndESetting.TradCompSectName;
            sAndESettingWork.PureTradCompCd = sAndESetting.PureTradCompCd;
            sAndESettingWork.PureTradCompRate = sAndESetting.PureTradCompRate;
            sAndESettingWork.PriTradCompCd = sAndESetting.PriTradCompCd;
            sAndESettingWork.PriTradCompRate = sAndESetting.PriTradCompRate;
            sAndESettingWork.ABGoodsCode = sAndESetting.ABGoodsCode;
            sAndESettingWork.CommentReservedDiv = sAndESetting.CommentReservedDiv;
            sAndESettingWork.GoodsMakerCd1 = sAndESetting.GoodsMakerCd1;
            sAndESettingWork.GoodsMakerCd2 = sAndESetting.GoodsMakerCd2;
            sAndESettingWork.GoodsMakerCd3 = sAndESetting.GoodsMakerCd3;
            sAndESettingWork.GoodsMakerCd4 = sAndESetting.GoodsMakerCd4;
            sAndESettingWork.GoodsMakerCd5 = sAndESetting.GoodsMakerCd5;
            sAndESettingWork.GoodsMakerCd6 = sAndESetting.GoodsMakerCd6;
            sAndESettingWork.GoodsMakerCd7 = sAndESetting.GoodsMakerCd7;
            sAndESettingWork.GoodsMakerCd8 = sAndESetting.GoodsMakerCd8;
            sAndESettingWork.GoodsMakerCd9 = sAndESetting.GoodsMakerCd9;
            sAndESettingWork.GoodsMakerCd10 = sAndESetting.GoodsMakerCd10;
            sAndESettingWork.GoodsMakerCd11 = sAndESetting.GoodsMakerCd11;
            sAndESettingWork.GoodsMakerCd12 = sAndESetting.GoodsMakerCd12;
            sAndESettingWork.GoodsMakerCd13 = sAndESetting.GoodsMakerCd13;
            sAndESettingWork.GoodsMakerCd14 = sAndESetting.GoodsMakerCd14;
            sAndESettingWork.GoodsMakerCd15 = sAndESetting.GoodsMakerCd15;
            sAndESettingWork.PartsOEMDiv = sAndESetting.PartsOEMDiv;
            sAndESettingWork.CustomerName = sAndESetting.CustomerName;
            sAndESettingWork.SectionName = sAndESetting.SectionName;

            return sAndESettingWork;

        }

        # endregion

    }
}
