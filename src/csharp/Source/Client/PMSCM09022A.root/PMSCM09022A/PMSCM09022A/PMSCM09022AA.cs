//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM�S�̐ݒ�}�X�^
// �v���O�����T�v   : SCM�S�̐ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/16  �C�����e : Search���\�b�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/08/03  �C�����e : ���ڒǉ�(���W�ԍ��A��M�����N���Ԋu)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20073 �� �B
// �� �� ��  2012/04/20  �C�����e : ���ڒǉ�(�̔��敪�ݒ�A�̔��敪�R�[�h)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2012/08/31  �C�����e : 2012/10���z�M�\�� SCM��Q��76�̑Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/09  �C�����e : SCM���Ǉ�10337,10338,10341�Ή�
//                                : ���ڒǉ��i�����񓚋敪�i�⍇���j�A�����񓚋敪�i�����j�A
//                                : ��t�]�ƈ��R�[�h�A�󂯏]�ƈ����́A�[�i�敪�A�[�i�敪���́j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/12/04  �C�����e : 2012/12/12�z�M �V�X�e���e�X�g��Q��96�Ή�
//                                : PCC�S�̐ݒ�}�X�^�ւ̍X�V�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/02/13  �C�����e : SCM��Q�ǉ��A�Ή�
//                                : ���ڒǉ��i�Y���������񓚋敪�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh
// �� �� ��  2013/02/27  �C�����e : �z�M���Ȃ��� Redmine#34752 �f�[�^�X�V�q�ɋ敪��ǉ�
//----------------------------------------------------------------------------//
//�Ǘ��ԍ�  10801804-00  �쐬�S�� : wangl2
//�� �� ��  2013/04/11   �C�����e : No.73 ���ώ����񓚃T�[�r�X
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// SCM�S�̐ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM�S�̐ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
	public class SCMTtlStAcs
	{
		#region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ISCMTtlStDB _iSCMTtlStDB = null;

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        private UserGuideAcs _userGuideAcs = null;
        private Hashtable _userGdBdTb = null;
        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

        // ADD 2012/12/04 2012/12/12�z�M �V�X�e���e�X�g��Q��96�Ή� ---------------------------------->>>>>
        /// <summary>
        /// PCC�S�̐ݒ�}�X�^ �A�N�Z�X�N���X
        /// </summary>
        private PccTtlStAcs _pccTtlStAcs = null;
        private PccTtlSt _pccTtlSt = null;
        private Hashtable _pccTtlStTable;

        /// <summary>
        /// ���_�}�X�^ �A�N�Z�X�N���X
        /// </summary>
        private SecInfoSetAcs _secInfoSetAcs;
        private Hashtable _sectionTb = null;
        private const string SECTION_00_MES = "�S��";
        // ADD 2012/12/04 2012/12/12�z�M �V�X�e���e�X�g��Q��96�Ή� ----------------------------------<<<<<
		
		#endregion

		#region -- �R���X�g���N�^ --
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
		static SCMTtlStAcs()
		{			
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
		public SCMTtlStAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSCMTtlStDB = (ISCMTtlStDB)MediationscmTtlStDB.GetSCMTtlStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSCMTtlStDB = null;
            }
		}
		#endregion

        #region -- �I�����C�����[�h�擾���� --
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSCMTtlStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion

        #region -- �ǂݍ��ݏ��� --
        /// <summary>
		/// �ǂݍ��ݏ���
		/// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param> 
		/// <param name="sectionCode">���_�R�[�h</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out SCMTtlSt scmTtlSt, string enterpriseCode, string sectionCode)
        {
            return ReadProc(out scmTtlSt, enterpriseCode, sectionCode);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMTtlSt scmTtlSt, string enterpriseCode, string sectionCode)
		{
            int status = 0;

            scmTtlSt = null;

			try
			{
                SCMTtlStWork scmTtlStWork = new SCMTtlStWork();
                scmTtlStWork.EnterpriseCode = enterpriseCode;
                scmTtlStWork.SectionCode = sectionCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmTtlStWork);

                status = this._iSCMTtlStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    scmTtlStWork = (SCMTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMTtlStWork));
                    // ���[�N��UI�f�[�^�N���X
                    scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				scmTtlSt = null;
				// �I�t���C������null���Z�b�g
				this._iSCMTtlStDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}
		#endregion

		#region -- �o�^��X�V���� --
		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref SCMTtlSt scmTtlSt)
		{
            int status = 0;

			// UI�f�[�^�N���X�����[�N
            SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

            object obj = scmTtlStWork;
			
			try
			{
				// �������ݏ���
                status = this._iSCMTtlStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή�-------------------------->>>>>
                    // PCC�S�̐ݒ�}�X�^�o�^�E�X�V����
                    status = PccTtlStWrite(scmTtlSt);
                    // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή�--------------------------<<<<<

                    if (obj is ArrayList)
                    {
                        scmTtlStWork = (SCMTtlStWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                    }
                }
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iSCMTtlStDB = null;
				// �ʐM�G���[��-1��߂�
				status = -1;
			}
			return status;
		}
		#endregion

		#region -- �폜���� --
		/// <summary>
		/// �_���폜����
		/// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : SCM�S�̐ݒ�̘_���폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref SCMTtlSt scmTtlSt)
		{
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

            object obj = scmTtlStWork;

            try
            {
                // �_���폜
                status = this._iSCMTtlStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή�-------------------------->>>>>
                    // PCC�S�̐ݒ�}�X�^�o�^�E�X�V����
                    status = PccTtlStLogicalDelete(scmTtlSt);
                    // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή�--------------------------<<<<<

                    scmTtlStWork = (SCMTtlStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMTtlStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}

		/// <summary>
		/// �����폜����
		/// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�̕����폜���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        public int Delete(SCMTtlSt scmTtlSt)
		{
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(scmTtlStWork);

                // �����폜
                status = this._iSCMTtlStDB.Delete(parabyte);

                // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή� ----------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // PCC�S�̐ݒ�}�X�^�폜����
                    status = PccTtlStDelete(scmTtlSt);
                }
                // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή� -----------------------<<<<<
                
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMTtlStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
		}
		#endregion

        #region -- �������� --
        /// <summary>
        /// SCM�S�̐ݒ蕜������
        /// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMTtlSt scmTtlSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

                object obj = scmTtlStWork;

                // ��������
                status = this._iSCMTtlStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή� ----------------------->>>>>
                    // PCC�S�̐ݒ�}�X�^��������
                    status = PccTtlStRevival(scmTtlSt);
                    // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή� -----------------------<<<<<

                    scmTtlStWork = (SCMTtlStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMTtlStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        // ADD 2009/06/16 ------>>>
        /// <summary>
        /// SCM�S�̐ݒ茟������(�_���폜�f�[�^�͏��O)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o����܂���B</br>
        /// <br></br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // ADD 2009/06/16 ------<<<
        
        /// <summary>
        /// SCM�S�̐ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br></br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// SCM�S�̐ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�̌����������s���܂��B</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
            int status = 0;

            SCMTtlStWork scmTtlStWork = new SCMTtlStWork();
            scmTtlStWork.EnterpriseCode = enterpriseCode;

			retList = new ArrayList();
			
            object paraobj = scmTtlStWork;
			object retobj = null;

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            // ���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
            SetDelivereds(scmTtlStWork.EnterpriseCode);
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // SCM�S�̐ݒ�̑S����
            status = this._iSCMTtlStDB.Search(out retobj, paraobj, 0, logicalMode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMTtlStWork wkSCMTtlStWork in workList)
                {
                    retList.Add(CopyToSCMTtlStFromSCMTtlStWork(wkSCMTtlStWork));
                }
            }
                
 			return status;
		}
		#endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
		/// </summary>
        /// <param name="scmTtlStWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private SCMTtlSt CopyToSCMTtlStFromSCMTtlStWork(SCMTtlStWork scmTtlStWork)
		{
            SCMTtlSt scmTtlSt = new SCMTtlSt();

            scmTtlSt.CreateDateTime = scmTtlStWork.CreateDateTime;
            scmTtlSt.UpdateDateTime = scmTtlStWork.UpdateDateTime;
            scmTtlSt.EnterpriseCode = scmTtlStWork.EnterpriseCode;
            scmTtlSt.FileHeaderGuid = scmTtlStWork.FileHeaderGuid;
            scmTtlSt.UpdEmployeeCode = scmTtlStWork.UpdEmployeeCode;
            scmTtlSt.UpdAssemblyId1 = scmTtlStWork.UpdAssemblyId1;
            scmTtlSt.UpdAssemblyId2 = scmTtlStWork.UpdAssemblyId2;
            scmTtlSt.LogicalDeleteCode = scmTtlStWork.LogicalDeleteCode;
            scmTtlSt.SectionCode = scmTtlStWork.SectionCode;

            scmTtlSt.SalesSlipPrtDiv = scmTtlStWork.SalesSlipPrtDiv;            // ����`�[���s�敪
            scmTtlSt.AcpOdrrSlipPrtDiv = scmTtlStWork.AcpOdrrSlipPrtDiv;        // �󒍓`�[���s�敪
            scmTtlSt.OldSysCooperatDiv = scmTtlStWork.OldSysCooperatDiv;        // ���V�X�e���A�g�敪
            scmTtlSt.OldSysCoopFolder = scmTtlStWork.OldSysCoopFolder;          // ���V�X�e���A�g�t�H���_
            scmTtlSt.BLCodeChgDiv = scmTtlStWork.BLCodeChgDiv;                  // BL�R�[�h�ϊ�
            scmTtlSt.AutoCooperatDis = scmTtlStWork.AutoCooperatDis;            // �����A�g�l����
            scmTtlSt.DiscountApplyCd = scmTtlStWork.DiscountApplyCd;            // �l���K�p�敪
            scmTtlSt.AutoAnswerDiv = scmTtlStWork.AutoAnswerDiv;                // �����񓚋敪
            scmTtlSt.EstimatePrtDiv = scmTtlStWork.EstimatePrtDiv;              // ���Ϗ����s�敪
            //>>>2010/08/03
            scmTtlSt.CashRegisterNo = scmTtlStWork.CashRegisterNo;              // ���W�ԍ�
            scmTtlSt.RcvProcStInterval = scmTtlStWork.RcvProcStInterval;        // ��M�����N���Ԋu
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlSt.SalesCdStAutoAns = scmTtlStWork.SalesCdStAutoAns;                // �̔��敪�ݒ�(�����񓚎�)
            scmTtlSt.SalesCode = scmTtlStWork.SalesCode;                // �̔��敪�R�[�h
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlSt.AutoAnsHourDspDiv = scmTtlStWork.AutoAnsHourDspDiv;      //�����񓚎��\���敪
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            scmTtlSt.AutoAnsInquiryDiv = scmTtlStWork.AutoAnsInquiryDiv;        // �����񓚋敪�i�⍇���j 
            scmTtlSt.AutoAnsOrderDiv = scmTtlStWork.AutoAnsOrderDiv;            // �����񓚋敪�i�����j
            scmTtlSt.FrontEmployeeCd = scmTtlStWork.FrontEmployeeCd.Trim();     // ��t�]�ƈ��R�[�h
            scmTtlSt.DeliveredGoodsDiv = scmTtlStWork.DeliveredGoodsDiv;�@�@�@�@// �[�i�敪
            scmTtlSt.DeliveredGoodsNm = GetDeliveredName(scmTtlStWork.DeliveredGoodsDiv); //�[�i�敪����
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
            scmTtlSt.FuwioutAutoAnsDiv = scmTtlStWork.FuwioutAutoAnsDiv;�@�@�@�@// �Y���������񓚋敪
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            scmTtlSt.DataUpDateWareHDiv = scmTtlStWork.DataUpDateWareHDiv; // �f�[�^�X�V�q�ɋ敪 // ADD 2013/02/27 qijh #34752
            scmTtlSt.SalesInputCode = scmTtlStWork.SalesInputCode.Trim();�@�@�@�@//�@������͎҃R�[�h�@//ADD 2013.04.11 wangl2 FOR RedMine#35269

            return scmTtlSt;
		}
		
		/// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
		/// </summary>
        /// <param name="scmTtlSt">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
		/// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br></br>
		/// </remarks>
        private SCMTtlStWork CopyToSCMTtlStWorkFromSCMTtlSt(SCMTtlSt scmTtlSt)
		{
            SCMTtlStWork scmTtlStWork = new SCMTtlStWork();

            scmTtlStWork.CreateDateTime = scmTtlSt.CreateDateTime;
            scmTtlStWork.UpdateDateTime = scmTtlSt.UpdateDateTime;
            scmTtlStWork.EnterpriseCode = scmTtlSt.EnterpriseCode;
            scmTtlStWork.FileHeaderGuid = scmTtlSt.FileHeaderGuid;
            scmTtlStWork.UpdEmployeeCode = scmTtlSt.UpdEmployeeCode;
            scmTtlStWork.UpdAssemblyId1 = scmTtlSt.UpdAssemblyId1;
            scmTtlStWork.UpdAssemblyId2 = scmTtlSt.UpdAssemblyId2;
            scmTtlStWork.LogicalDeleteCode = scmTtlSt.LogicalDeleteCode;
            scmTtlStWork.SectionCode = scmTtlSt.SectionCode;

            scmTtlStWork.SalesSlipPrtDiv = scmTtlSt.SalesSlipPrtDiv;            // ����`�[���s�敪
            scmTtlStWork.AcpOdrrSlipPrtDiv = scmTtlSt.AcpOdrrSlipPrtDiv;        // �󒍓`�[���s�敪
            scmTtlStWork.OldSysCooperatDiv = scmTtlSt.OldSysCooperatDiv;        // ���V�X�e���A�g�敪
            scmTtlStWork.OldSysCoopFolder = scmTtlSt.OldSysCoopFolder;          // ���V�X�e���A�g�t�H���_
            scmTtlStWork.BLCodeChgDiv = scmTtlSt.BLCodeChgDiv;                  // BL�R�[�h�ϊ�
            scmTtlStWork.AutoCooperatDis = scmTtlSt.AutoCooperatDis;            // �����A�g�l����
            scmTtlStWork.DiscountApplyCd = scmTtlSt.DiscountApplyCd;            // �l���K�p�敪
            scmTtlStWork.AutoAnswerDiv = scmTtlSt.AutoAnswerDiv;                // �����񓚋敪
            scmTtlStWork.EstimatePrtDiv = scmTtlSt.EstimatePrtDiv;              // ���Ϗ����s�敪
            //>>>2010/08/03
            scmTtlStWork.CashRegisterNo = scmTtlSt.CashRegisterNo;              // ���W�ԍ�
            scmTtlStWork.RcvProcStInterval = scmTtlSt.RcvProcStInterval;        // ��M�����N���Ԋu
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlStWork.SalesCdStAutoAns = scmTtlSt.SalesCdStAutoAns;                // �̔��敪�ݒ�(�����񓚎�)
            scmTtlStWork.SalesCode = scmTtlSt.SalesCode;                // �̔��敪�R�[�h
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlStWork.AutoAnsHourDspDiv = scmTtlSt.AutoAnsHourDspDiv;      //�����񓚎��\���敪
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            scmTtlStWork.AutoAnsInquiryDiv = scmTtlSt.AutoAnsInquiryDiv;        // �����񓚋敪�i�⍇���j 
            scmTtlStWork.AutoAnsOrderDiv = scmTtlSt.AutoAnsOrderDiv;            // �����񓚋敪�i�����j
            scmTtlStWork.FrontEmployeeCd = scmTtlSt.FrontEmployeeCd.Trim();     // ��t�]�ƈ��R�[�h
            scmTtlStWork.DeliveredGoodsDiv = scmTtlSt.DeliveredGoodsDiv;�@�@�@�@// �[�i�敪
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
            scmTtlStWork.FuwioutAutoAnsDiv = scmTtlSt.FuwioutAutoAnsDiv;�@�@�@�@// �Y���������񓚋敪
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            scmTtlStWork.DataUpDateWareHDiv = scmTtlSt.DataUpDateWareHDiv; // �f�[�^�X�V�q�ɋ敪 // ADD 2013/02/27 qijh #34752
            scmTtlStWork.SalesInputCode = scmTtlSt.SalesInputCode.Trim();�@�@�@�@// ������͎҃R�[�h�@�@//ADD 2013.04.11 wangl2 FOR RedMine#35269

            return scmTtlStWork;
		}
		#endregion
	
	    //>>>2010/08/03
        PosTerminalMgAcs _posTerminalMgAcs;
        List<PosTerminalMg> _posTerminalMgList;

        /// <summary>
        /// �[���Ǘ����L���b�V������
        /// </summary>
        /// <param name="enterpriseCode"></param>
        public void CachePosTerminalMg(string enterpriseCode)
        {
            ArrayList al;
            List<PosTerminalMg> posList = new List<PosTerminalMg>();

            if (this._posTerminalMgAcs == null)
            {
                this._posTerminalMgAcs = new PosTerminalMgAcs();
            }

            this._posTerminalMgAcs.SearchServer(out al, enterpriseCode);
            if (al != null) posList = new List<PosTerminalMg>((PosTerminalMg[])al.ToArray(typeof(PosTerminalMg)));

            this._posTerminalMgList = posList;
        }

        /// <summary>
        /// �[���Ǘ����擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="cashRegisterNo"></param>
        /// <returns></returns>
        public PosTerminalMg GetPosTerminalMg(string enterpriseCode, int cashRegisterNo)
        {
            PosTerminalMg retPosTerminalMg = null;

            if ((this._posTerminalMgList != null) && (this._posTerminalMgList.Count != 0))
            {
                retPosTerminalMg = this._posTerminalMgList.Find(
                    delegate(PosTerminalMg pos)
                    {
                        if (pos.CashRegisterNo == cashRegisterNo)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }

            return retPosTerminalMg;
        }
        //<<<2010/08/03
        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        /// <summary>
        /// ���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> ��ƃR�[�h</param>
        /// <br>Note       : ���[�U�[�K�C�h�ݒ�̔[�i�敪���擾���܂��B</br>
        /// <br>             (PCC�S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�����ɂ��Ă��܂��j</br>
        /// <br>Programmer : ���� ����q</br>
        /// <br>Date       : 2012.09.07</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //���[�U�[�K�C�h�ݒ�̔[�i�敪�̎擾
            ArrayList userGuidList = null;
            //�[�i�敪�̍���
            int userGuideDivCd = 48;
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        if (!_userGdBdTb.ContainsKey(userGdBd.GuideCode))
                        {
                            _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �[�i�敪���̂̎擾
        /// </summary>
        /// <param name="deliveredGoodsDiv"> �[�i�敪</param>
        /// <remarks>
        /// <returns>�[�i�敪����</returns>
        /// <br>Note       : �[�i�敪���̂��擾���܂��B</br>
        /// <br>             (PCC�S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�����ɂ��Ă��܂��j</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

        // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή�-------------------------->>>>>
        /// <summary>
        /// PCC�S�̐ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC�S�̐ݒ�}�X�^�ւ̓o�^�E�X�V�������s���܂��B</br>
        /// <br>             (PCC�S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�����ɂ��Ă��܂��j</br>
        /// </remarks>
        private int PccTtlStWrite(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC�S�̐ݒ�}�X�^�擾
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // PCC�S�̐ݒ肪�_���폜�ς̎�
                if (this._pccTtlSt != null && this._pccTtlSt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
                {
                    // PCC�S�̐ݒ�}�X�^��������
                    status = this._pccTtlStAcs.RevivalLogicalDelete(ref this._pccTtlSt);
                }

                // SCM�S�̐ݒ�I�u�W�F�N�g����PCC�S�̐ݒ�I�u�W�F�N�g�֍X�V���ڂ�ݒ�
                ScmTtlStToPccTtlSt(scmTtlSt, ref this._pccTtlSt);

                // PCC�S�̐ݒ�}�X�^�X�V
                status = this._pccTtlStAcs.Write(ref this._pccTtlSt);

            }
            return status;
        }

        /// <summary>
        /// PCC�S�̐ݒ�}�X�^�폜����
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC�S�̐ݒ�}�X�^�ւ̍폜�������s���܂��B</br>
        /// <br>             (PCC�S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�����ɂ��Ă��܂��j</br>
        /// </remarks>
        private int PccTtlStDelete(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC�S�̐ݒ�}�X�^�擾
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._pccTtlSt != null)
                {
                    // PCC�S�̐ݒ�}�X�^�폜
                    status = this._pccTtlStAcs.Delete(ref this._pccTtlSt);
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�S�̐ݒ�}�X�^�_���폜����
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC�S�̐ݒ�}�X�^�ւ̘_���폜�������s���܂��B</br>
        /// <br>             (PCC�S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�����ɂ��Ă��܂��j</br>
        /// </remarks>
        private int PccTtlStLogicalDelete(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC�S�̐ݒ�}�X�^�擾
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._pccTtlSt != null)
                {
                    // PCC�S�̐ݒ�}�X�^�_���폜
                    status = this._pccTtlStAcs.LogicalDelete(ref this._pccTtlSt);
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�S�̐ݒ�}�X�^��������
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC�S�̐ݒ�}�X�^�̕����������s���܂��B</br>
        /// <br>             (PCC�S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�����ɂ��Ă��܂��j</br>
        /// </remarks>
        private int PccTtlStRevival(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC�S�̐ݒ�}�X�^�擾
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._pccTtlSt != null)
                {
                    // PCC�S�̐ݒ�}�X�^��������
                    status = this._pccTtlStAcs.RevivalLogicalDelete(ref this._pccTtlSt);
                }

                // SCM�S�̐ݒ�I�u�W�F�N�g����PCC�S�̐ݒ�I�u�W�F�N�g�֍X�V���ڂ�ݒ�
                ScmTtlStToPccTtlSt(scmTtlSt, ref this._pccTtlSt);

                // PCC�S�̐ݒ�}�X�^�X�V
                status = this._pccTtlStAcs.Write(ref this._pccTtlSt);
            }
            return status;
        }

        /// <summary>
        /// PCC�S�̐ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC�S�̐ݒ�}�X�^�̓ǂݍ��݂��s���A�f�[�^���i�[���܂�</br>
        /// </remarks>
        private int PccTtlStRead(SCMTtlSt scmTtlSt)
        {
            int status = 0;

            // PCC�S�̐ݒ�}�X�^�A�N�Z�X�N���X�擾
            if (this._pccTtlStAcs == null)
            {
                this._pccTtlStAcs = new PccTtlStAcs();
            }

            this._pccTtlStTable = new Hashtable();
            // PCC�S�̐ݒ�}�X�^�S���擾
            status = PccTtlStSearch(scmTtlSt);
            // �擾�ł��Ȃ��������A�ȍ~�̏����𒆎~
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �X�V�Ώۃf�[�^����
            this._pccTtlSt = null;
            string key = scmTtlSt.EnterpriseCode.Trim() + scmTtlSt.SectionCode.Trim();
            if (this._pccTtlStTable.ContainsKey(key))
            {
                _pccTtlSt = (PccTtlSt)this._pccTtlStTable[key];
            }

            return status;
        }

        /// <summary>
        /// PCC�S�̐ݒ�}�X�^�S����������
        /// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J�����f�[�^�e�[�u���ɐݒ肵�܂��B</br>
        /// </remarks>
        private int PccTtlStSearch(SCMTtlSt scmTtlSt)
        {
            int status = 0;
            PccTtlSt parsepccTtlSt = new PccTtlSt();
            List<PccTtlSt> pccTtlStList = null;
            parsepccTtlSt.EnterpriseCode = scmTtlSt.EnterpriseCode;
            int totalCount = 0;

            if (this._pccTtlStTable.Count == 0)
            {
                status = this._pccTtlStAcs.Search(ref pccTtlStList, parsepccTtlSt, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this._pccTtlStTable.Clear();

                            //�S�̐ݒ�N���X���f�[�^�e�[�u���֓W�J����
                            foreach (PccTtlSt pccTtlSt in pccTtlStList)
                            {
                                if (this._pccTtlStTable.ContainsKey(pccTtlSt.EnterpriseCode.Trim() + pccTtlSt.SectionCode.Trim()) == false)
                                {
                                    this._pccTtlStTable.Add(pccTtlSt.EnterpriseCode.Trim() + pccTtlSt.SectionCode.Trim(), pccTtlSt);
                                }
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�S�̐ݒ�}�X�^���i�[����
        /// </summary>
        /// <param name="scmTtlSt">SCM�S�̐ݒ�I�u�W�F�N�g</param>
        /// <param name="pccTtlSt">PCC�S�̐ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : SCM�S�̐ݒ�I�u�W�F�N�g����PCC�S�̐ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScmTtlStToPccTtlSt(SCMTtlSt scmTtlSt, ref PccTtlSt pccTtlSt)
        {
            // SCM�S�̐ݒ��񂪂Ȃ����͈ȍ~�̏����͍s��Ȃ�
            if (scmTtlSt == null) return;
            
            if (pccTtlSt == null)
            {
                // �V�K�̏ꍇ
                pccTtlSt = new PccTtlSt();
                pccTtlSt.EnterpriseCode = scmTtlSt.EnterpriseCode;
            }
            //���_�R�[�h
            pccTtlSt.SectionCode = scmTtlSt.SectionCode;
            //���_����
            pccTtlSt.SectionName = GetSectionName(scmTtlSt.SectionCode.Trim(), scmTtlSt.EnterpriseCode);
            //��t�]�ƈ�       
            pccTtlSt.FrontEmployeeCd = scmTtlSt.FrontEmployeeCd;
            //��t�]�ƈ�����
            pccTtlSt.FrontEmployeeNm = scmTtlSt.FrontEmployeeNm;
            //�[�i�敪
            pccTtlSt.DeliveredGoodsDiv = scmTtlSt.DeliveredGoodsDiv;
            //����`�[���s�敪
            pccTtlSt.SalesSlipPrtDiv = scmTtlSt.SalesSlipPrtDiv;
            //�󒍓`�[����敪
            pccTtlSt.AcpOdrrSlipPrtDiv = scmTtlSt.AcpOdrrSlipPrtDiv;

        }

        /// <summary>
        /// ���_���̂̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetSectionName(string sectionCode, string enterpriseCode)
        {
            string sectionName = string.Empty;
            if (_sectionTb == null)
            {
                GetALLSectionName(enterpriseCode);
            }

            if (_sectionTb != null && _sectionTb.Count > 0 && _sectionTb.ContainsKey(sectionCode))
            {
                sectionName = (string)_sectionTb[sectionCode];
            }

            return sectionName;
        }

        /// <summary>
        /// ���_���̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���̂̎擾���s���܂��B</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void GetALLSectionName(string enterpriseCode)
        {
            if (this._secInfoSetAcs == null)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }
            if (_sectionTb == null)
            {
                _sectionTb = new Hashtable();
            }
            else
            {
                _sectionTb.Clear();
            }

            _sectionTb.Add("00", SECTION_00_MES);
            ArrayList retList = null;
            int status = this._secInfoSetAcs.SearchAll(out retList, enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (SecInfoSet secInfoSet in retList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        _sectionTb.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideSnm.TrimEnd());
                    }
                }
            }
        }

        // ADD 2012/12/04 2012/12/12�z�M�V�X�e���e�X�g��Q��96�Ή�--------------------------<<<<<

	}
}
