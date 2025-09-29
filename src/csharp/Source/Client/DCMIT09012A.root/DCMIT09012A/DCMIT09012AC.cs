using System;
using System.Collections;
using System.Data;
using System.Reflection;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// ���Ϗ����l�ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ϗ����l�ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 980035 ����@��`</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br>UpdateNote : 2008/06/03 30415 �ēc �ύK</br>
    /// <br>        	 �E�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��</br>  
    /// <br>Update Note: 2009.07.13 20056 ���n ���</br>
    /// <br>             �R���X�g���N�^�I�[�o�[���[�h(���_�����擾���Ȃ�)</br>
    /// </remarks>
    public class EstimateDefSetAcs
	{
		// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IEstimateDefSetDB _iEstimateDefSetDB = null;

		// ���_���擾���i
		private SecInfoAcs      _secInfoAcs   = null;

		/// <summary>
        /// ���Ϗ����l�ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public EstimateDefSetAcs()
		{
			this._secInfoAcs = new SecInfoAcs(1);
			try {
				// �����[�g�I�u�W�F�N�g�擾
                this._iEstimateDefSetDB = (IEstimateDefSetDB)MediationEstimateDefSetDB.GetEstimateDefSetDB();
			}
			catch(Exception) {
				// �I�t���C������null���Z�b�g
				this._iEstimateDefSetDB = null;
			}
		}

        // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="mode">�������[�h(0:�ʏ�(��̫�ĺݽ�׸��Ɠ��l) 1:���_���̎擾�Ȃ�)</param>
        public EstimateDefSetAcs(int mode)
        {
            switch (mode)
            {
                case 0:
                    this._secInfoAcs = new SecInfoAcs(1);
                    break;
                case 1:
                    this._secInfoAcs = null;
                    break;
                default:
                    this._secInfoAcs = null;
                    break;
            }

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iEstimateDefSetDB = (IEstimateDefSetDB)MediationEstimateDefSetDB.GetEstimateDefSetDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iEstimateDefSetDB = null;
            }
        }
        // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int GetOnlineMode()
		{
			// �I�����C�����[�h���擾���܂�
			if( this._iEstimateDefSetDB == null ) {
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�Ǎ�����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̓ǂݍ��݂��s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Read(out EstimateDefSet estimateDefSet, string enterpriseCode, string sectionCode)
		{
			int status = 0;

			try {
				estimateDefSet = null;

				// �p�����[�^��ݒ�
                EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();
				estimateDefSetWork.EnterpriseCode	= enterpriseCode;	// ��ƃR�[�h
                estimateDefSetWork.SectionCode      = sectionCode;		// ���_�R�[�h

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // ���Ϗ����l�ݒ�ǂݍ���
				status = this._iEstimateDefSetDB.Read( ref parabyte, 0 );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // ���Ϗ����l�ݒ胏�[�N�N���X���f�V���A���C�Y
                    estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // ���Ϗ����l�ݒ胏�[�N�N���X���猩�Ϗ����l�ݒ�N���X�փ����o�R�s�[
					estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork( estimateDefSetWork );
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				estimateDefSet = null;
				this._iEstimateDefSetDB = null;

				// �ʐM�G���[��-1��Ԃ��B
				return -1;
			}
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�o�^�E�X�V����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Write(ref EstimateDefSet estimateDefSet)
		{
			int status = 0;

			try {
                // ���Ϗ����l�ݒ�N���X�����Ϗ����l�ݒ胏�[�N�N���X�փ����o�R�s�[
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);

				// XML�֕ϊ����A������̃o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

				// �]�ƈ��ڕW���т�ۑ�
				//status = this._iEstimateDefSetDB.Write( ref parabyte );
                Object paraObj = (object)estimateDefSetWork;
                status = this._iEstimateDefSetDB.Write(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // ���Ϗ����l�ݒ胏�[�N�N���X���f�V���A���C�Y
                    //estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // ���Ϗ����l�ݒ胏�[�N�N���X���猩�Ϗ����l�ݒ�N���X�փ����o�R�s�[
                    ArrayList wklist = (ArrayList)paraObj;
                    estimateDefSetWork = wklist[0] as EstimateDefSetWork;
                    estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork(estimateDefSetWork);
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iEstimateDefSetDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�_���폜����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int LogicalDelete(ref EstimateDefSet estimateDefSet)
		{
			int status = 0;

			try {

                // ���Ϗ����l�ݒ�N���X�����Ϗ����l�ݒ胏�[�N�N���X�փ����o�R�s�[
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);
				// XML�ϊ����A��������o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // ���Ϗ����l�ݒ��_���폜
				//status = this._iEstimateDefSetDB.LogicalDelete( ref parabyte );
                Object paraObj = (object)estimateDefSetWork;
                status = this._iEstimateDefSetDB.LogicalDelete(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // ���Ϗ����l�ݒ胏�[�N�N���X���f�V���A���C�Y
                    //estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // ���Ϗ����l�ݒ胏�[�N�N���X�����Ϗ����l�ݒ�N���X�Ƀ����o�R�s�[
                    estimateDefSetWork = paraObj as EstimateDefSetWork;
                    estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork(estimateDefSetWork);
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iEstimateDefSetDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�_���폜��������
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Revival(ref EstimateDefSet estimateDefSet)
		{
			int status = 0;

			try {
                // ���Ϗ����l�ݒ�N���X�����Ϗ����l�ݒ胏�[�N�N���X�փ����o�R�s�[
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);
				// XML�ϊ����A��������o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // ���Ϗ����l�ݒ�𕜊�
				//status = this._iEstimateDefSetDB.RevivalLogicalDelete( ref parabyte );
                Object paraObj = (object)estimateDefSetWork;
                status = this._iEstimateDefSetDB.RevivalLogicalDelete(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // ���Ϗ����l�ݒ胏�[�N�N���X���f�V���A���C�Y
                    //estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // ���Ϗ����l�ݒ胏�[�N�N���X�����Ϗ����l�ݒ�N���X�Ƀ����o�R�s�[
                    estimateDefSetWork = paraObj as EstimateDefSetWork;
                    estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork(estimateDefSetWork);
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iEstimateDefSetDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
        /// ���Ϗ����l�ݒ蕨���폜����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̕����폜���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Delete(EstimateDefSet estimateDefSet)
		{
			int status = 0;
			try {
                // ���Ϗ����l�ݒ�N���X�����Ϗ����l�ݒ胏�[�N�N���X�փ����o�R�s�[
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);
				// XML�ϊ����A��������o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // ���Ϗ����l�ݒ蕨���폜
				status = this._iEstimateDefSetDB.Delete( parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null��ݒ�
				this._iEstimateDefSetDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
        /// ���Ϗ����l�ݒ茟������(�_���폜�f�[�^����)
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ł��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int Search( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, 0 );
		}

		/// <summary>
        /// ���Ϗ����l�ݒ茟������(�_���폜�f�[�^�܂�)
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int SearchAll( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01 );
		}

		/// <summary>
        /// ���Ϗ����l�ݒ茟������(���C��)
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int SearchProc( out ArrayList retList, string enterpriseCode, 
			ConstantManagement.LogicalMode logicalMode )
		{
			int status = 0;
			
			retList = new ArrayList();
			retList.Clear();

            EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();
			estimateDefSetWork.EnterpriseCode = enterpriseCode;		// ��ƃR�[�h

			ArrayList wkList = new ArrayList();
			wkList.Clear();

			object paraobj	= estimateDefSetWork;
			object retobj	= null;

            // ���Ϗ����l�ݒ�S������
			status = this._iEstimateDefSetDB.Search( out retobj, paraobj, 0, logicalMode );

			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				wkList = retobj as ArrayList;
				if( wkList != null ) {
                    foreach (EstimateDefSetWork wkEstimateDefSetWork in wkList)
                    {
						retList.Add( CopyToEstimateDefSetFromEstimateDefSetWork( wkEstimateDefSetWork ) );
					}
				}
			}

			return status;
		}

		/// <summary>
        /// �N���X�����o�R�s�[����(���Ϗ����l�ݒ胏�[�N�N���X�����Ϗ����l�ݒ�N���X)
		/// </summary>
        /// <param name="estimateDefSetWork">���Ϗ����l�ݒ胏�[�N�N���X</param>
        /// <returns>���Ϗ����l�ݒ�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ胏�[�N�N���X���猩�Ϗ����l�ݒ�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private EstimateDefSet CopyToEstimateDefSetFromEstimateDefSetWork(EstimateDefSetWork estimateDefSetWork)
		{
            EstimateDefSet estimateDefSet = new EstimateDefSet();

			// ���ʃw�b�_
			estimateDefSet.CreateDateTime		= estimateDefSetWork.CreateDateTime;
			estimateDefSet.UpdateDateTime		= estimateDefSetWork.UpdateDateTime;
			estimateDefSet.EnterpriseCode		= estimateDefSetWork.EnterpriseCode;
			estimateDefSet.FileHeaderGuid		= estimateDefSetWork.FileHeaderGuid;
			estimateDefSet.UpdEmployeeCode		= estimateDefSetWork.UpdEmployeeCode;
			estimateDefSet.UpdAssemblyId1		= estimateDefSetWork.UpdAssemblyId1;
			estimateDefSet.UpdAssemblyId2		= estimateDefSetWork.UpdAssemblyId2;
			estimateDefSet.LogicalDeleteCode	= estimateDefSetWork.LogicalDeleteCode;

            estimateDefSet.SectionCode          = estimateDefSetWork.SectionCode;           // ���_�R�[�h
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSet.FractionProcCd       = estimateDefSetWork.FractionProcCd;		// �[�������敪
            estimateDefSet.ConsTaxLayMethod     = estimateDefSetWork.ConsTaxLayMethod;	    // ����œ]�ŕ���
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSet.ListPricePrintDiv    = estimateDefSetWork.ListPricePrintDiv;     // �艿����敪
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSet.EraNameDispCd1		= estimateDefSetWork.EraNameDispCd1;		// �����\���敪�P
            estimateDefSet.EstimateTotalPrtCd   = estimateDefSetWork.EstimateTotalPrtCd;    // ���ύ��v����敪
            estimateDefSet.EstimateFormPrtCd    = estimateDefSetWork.EstimateFormPrtCd;     // ���Ϗ�����敪
            estimateDefSet.HonorificTitlePrtCd  = estimateDefSetWork.HonorificTitlePrtCd;   // �h�̈���敪
            estimateDefSet.EstimateRequestCd    = estimateDefSetWork.EstimateRequestCd;     // ���ψ˗��敪
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSet.EstmFormNoPickDiv    = estimateDefSetWork.EstmFormNoPickDiv;     // ���Ϗ��ԍ��̔ԋ敪
            estimateDefSet.EstimateTitle1       = estimateDefSetWork.EstimateTitle1;        // ���σ^�C�g���P
            estimateDefSet.EstimateNote1        = estimateDefSetWork.EstimateNote1;         // ���ϔ��l�P
            estimateDefSet.EstimateNote2        = estimateDefSetWork.EstimateNote2;         // ���ϔ��l�Q
            estimateDefSet.EstimateNote3        = estimateDefSetWork.EstimateNote3;         // ���ϔ��l�R
            estimateDefSet.EstimatePrtDiv       = estimateDefSetWork.EstimatePrtDiv;        // ���Ϗ����s�敪
            //estimateDefSet.EstimateReqPrtDiv    = estimateDefSetWork.EstimateReqPrtDiv;     // ���ψ˗������s�敪  // DEL 2008/06/06
            //estimateDefSet.EstimateConfPrtDiv   = estimateDefSetWork.EstimateConfPrtDiv;    // ���ϊm�F�����s�敪  // DEL 2008/06/06
            estimateDefSet.FaxEstimatetDiv      = estimateDefSetWork.FaxEstimatetDiv;       // �e�`�w���ϋ敪
            estimateDefSet.ConsTaxPrintDiv      = estimateDefSetWork.ConsTaxPrintDiv;       // ����ň���敪
            // --- ADD 2008/06/03 -------------------------------->>>>>
            estimateDefSet.PartsNoPrtCd = estimateDefSetWork.PartsNoPrtCd;                  // �i�Ԉ󎚋敪
            estimateDefSet.OptionPringDivCd = estimateDefSetWork.OptionPringDivCd;          // �I�v�V�����󎚋敪
            estimateDefSet.PartsSelectDivCd = estimateDefSetWork.PartsSelectDivCd;          // ���i�I���敪
            estimateDefSet.PartsSearchDivCd = estimateDefSetWork.PartsSearchDivCd;          // ���i�����敪
            estimateDefSet.EstimateDtCreateDiv = estimateDefSetWork.EstimateDtCreateDiv;    // ���σf�[�^�쐬�敪
            estimateDefSet.EstimateValidityTerm = estimateDefSetWork.EstimateValidityTerm;  // ���Ϗ��L������
            estimateDefSet.RateUseCode = estimateDefSetWork.RateUseCode;                    // �|���g�p�敪
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return estimateDefSet;
		}

		/// <summary>
        /// �N���X�����o�R�s�[����(���Ϗ����l�ݒ�N���X�����Ϗ����l�ݒ胏�[�N�N���X)
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�N���X</param>
        /// <returns>���Ϗ����l�ݒ胏�[�N�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�N���X���猩�Ϗ����l�ݒ胏�[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private EstimateDefSetWork CopyToEstimateDefSetWorkFromEstimateDefSet(EstimateDefSet estimateDefSet)
		{
            EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();

			// ���ʃw�b�_
			estimateDefSetWork.CreateDateTime		= estimateDefSet.CreateDateTime;
			estimateDefSetWork.UpdateDateTime		= estimateDefSet.UpdateDateTime;
			estimateDefSetWork.EnterpriseCode		= estimateDefSet.EnterpriseCode;
			estimateDefSetWork.FileHeaderGuid		= estimateDefSet.FileHeaderGuid;
			estimateDefSetWork.UpdEmployeeCode		= estimateDefSet.UpdEmployeeCode;
			estimateDefSetWork.UpdAssemblyId1		= estimateDefSet.UpdAssemblyId1.TrimEnd();
			estimateDefSetWork.UpdAssemblyId2		= estimateDefSet.UpdAssemblyId2.TrimEnd();
			estimateDefSetWork.LogicalDeleteCode	= estimateDefSet.LogicalDeleteCode;

            estimateDefSetWork.SectionCode          = estimateDefSet.SectionCode;           // ���_�R�[�h

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// --- ADD 2008/06/03 -------------------------------->>>>>
            //foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //{
            //    if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
            //    {
            //        estimateDefSetWork.SectionGuideNm = si.SectionGuideNm;
            //        break;
            //    }
            //}
            //// --- ADD 2008/06/03 --------------------------------<<<<< 

            if (this._secInfoAcs != null)
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
                    {
                        estimateDefSetWork.SectionGuideNm = si.SectionGuideNm;
                        break;
                    }
                }
            }
            else
            {
                estimateDefSetWork.SectionGuideNm = string.Empty;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSetWork.FractionProcCd       = estimateDefSet.FractionProcCd;		// �[�������敪
            estimateDefSetWork.ConsTaxLayMethod     = estimateDefSet.ConsTaxLayMethod;	    // ����œ]�ŕ���
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSetWork.ListPricePrintDiv    = estimateDefSet.ListPricePrintDiv;     // �艿����敪
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSetWork.EraNameDispCd1       = estimateDefSet.EraNameDispCd1;		// �����\���敪�P
            estimateDefSetWork.EstimateTotalPrtCd   = estimateDefSet.EstimateTotalPrtCd;    // ���ύ��v����敪
            estimateDefSetWork.EstimateFormPrtCd    = estimateDefSet.EstimateFormPrtCd;     // ���Ϗ�����敪
            estimateDefSetWork.HonorificTitlePrtCd  = estimateDefSet.HonorificTitlePrtCd;   // �h�̈���敪
            estimateDefSetWork.EstimateRequestCd    = estimateDefSet.EstimateRequestCd;     // ���ψ˗��敪
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSetWork.EstmFormNoPickDiv    = estimateDefSet.EstmFormNoPickDiv;     // ���Ϗ��ԍ��̔ԋ敪
            estimateDefSetWork.EstimateTitle1       = estimateDefSet.EstimateTitle1;        // ���σ^�C�g���P
            estimateDefSetWork.EstimateNote1        = estimateDefSet.EstimateNote1;         // ���ϔ��l�P
            estimateDefSetWork.EstimateNote2        = estimateDefSet.EstimateNote2;         // ���ϔ��l�Q
            estimateDefSetWork.EstimateNote3        = estimateDefSet.EstimateNote3;         // ���ϔ��l�R
            estimateDefSetWork.EstimatePrtDiv       = estimateDefSet.EstimatePrtDiv;        // ���Ϗ����s�敪
            //estimateDefSetWork.EstimateReqPrtDiv    = estimateDefSet.EstimateReqPrtDiv;     // ���ψ˗������s�敪  // DEL 2008/06/06
            //estimateDefSetWork.EstimateConfPrtDiv   = estimateDefSet.EstimateConfPrtDiv;    // ���ϊm�F�����s�敪  // DEL 2008/06/06
            estimateDefSetWork.FaxEstimatetDiv      = estimateDefSet.FaxEstimatetDiv;       // �e�`�w���ϋ敪
            estimateDefSetWork.ConsTaxPrintDiv      = estimateDefSet.ConsTaxPrintDiv;       // ����ň���敪
            // --- ADD 2008/06/03 -------------------------------->>>>>
            estimateDefSetWork.PartsNoPrtCd         = estimateDefSet.PartsNoPrtCd;          // �i�Ԉ󎚋敪
            estimateDefSetWork.OptionPringDivCd     = estimateDefSet.OptionPringDivCd;      // �I�v�V�����󎚋敪
            estimateDefSetWork.PartsSelectDivCd     = estimateDefSet.PartsSelectDivCd;      // ���i�I���敪
            estimateDefSetWork.PartsSearchDivCd     = estimateDefSet.PartsSearchDivCd;      // ���i�����敪
            estimateDefSetWork.EstimateDtCreateDiv  = estimateDefSet.EstimateDtCreateDiv;   // ���σf�[�^�쐬�敪
            estimateDefSetWork.EstimateValidityTerm = estimateDefSet.EstimateValidityTerm;  // ���Ϗ��L������
            estimateDefSetWork.RateUseCode          = estimateDefSet.RateUseCode;           // �|���g�p�敪
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return estimateDefSetWork;
		}
	}
}
