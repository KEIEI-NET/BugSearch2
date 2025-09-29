using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmEpScCnt
	/// <summary>
	///                      SCM��Ƌ��_�A���}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM��Ƌ��_�A���}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2011/08/11  (CSharp File Generated Date)</br>
    /// <br>Update Date      :   2013/06/26  </br>
    /// <br>                 :   30744 ���� ����q</br>
    /// <br>                 :   SCM��Q�Ή� �^�u���b�g�g�p�敪�ǉ�</br>
    /// </remarks>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : 30745�@�g��
    // �X �V ��  2013/05/24  �C�����e : 2013/06/18�z�M�\��@SCM��10533�Ή�
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : 30973�@����
    // �� �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή�
    //----------------------------------------------------------------------------//
	public class ScmEpScCnt
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�A������ƃR�[�h</summary>
		private string _cnectOriginalEpCd = "";

		/// <summary>�A�������_�R�[�h</summary>
		private string _cnectOriginalSecCd = "";

		/// <summary>�A�������_�K�C�h����</summary>
		private string _cnectOriginalSecNm = "";

		/// <summary>�A�����ƃR�[�h</summary>
		private string _cnectOtherEpCd = "";

		/// <summary>�A���拒�_�R�[�h</summary>
		private string _cnectOtherSecCd = "";

		/// <summary>�A���拒�_�K�C�h����</summary>
		private string _cnectOtherSecNm = "";

		/// <summary>���ʋ敪</summary>
		/// <remarks>0:�A���L�� 1:�A������</remarks>
		private Int32 _discDivCd;

		/// <summary>�ʐM����(SCM)</summary>
		/// <remarks>0:���Ȃ�,1:����</remarks>
		private Int16 _scmCommMethod;

		/// <summary>�ʐM����(PCC-UOE)</summary>
		/// <remarks>0:���Ȃ�,1:����</remarks>
		private Int16 _pccUoeCommMethod;

        // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
        /// <summary>�^�u���b�g�g�p�敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _tabUseDiv;
        // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<

        // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�ʐM����(���i�⍇���E�����iRC�I�v�V�����j)</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int16 _rcScmCommMethod;

        /// <summary>�D��\���V�X�e��</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int16 _prDispSystem;
        // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
        /// <summary>�V���ؑփX�e�[�^�X</summary>
        /// <remarks>0:��,1:�^</remarks>
        private Int32 _oldNewStatus;

        /// <summary>�ʏ�/�蓮�X�e�[�^�X</summary>
        /// <remarks>0:�ʏ�,1:�蓮</remarks>
        private Int32 _usualMnalStatus;

        /// <summary>�p�[�c�}��DBID</summary>
        /// <remarks>�p�[�c�}�����_DB�T�[�o�[��ID</remarks>
        private string _pmDBId;

        /// <summary>�p�[�c�}���A�b�v���[�h�敪</summary>
        /// <remarks>0:�Ȃ�,1:�A�b�v���[�h�ς�</remarks>
        private Int32 _pmUploadDiv;
        // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
        
        /// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get { return _createDateTime; }
			set { _createDateTime = value; }
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

		/// public propaty name  :  CnectOriginalEpCd
		/// <summary>�A������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOriginalEpCd
		{
			get { return _cnectOriginalEpCd; }
			set { _cnectOriginalEpCd = value; }
		}

		/// public propaty name  :  CnectOriginalSecCd
		/// <summary>�A�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOriginalSecCd
		{
			get { return _cnectOriginalSecCd; }
			set { _cnectOriginalSecCd = value; }
		}

		/// public propaty name  :  CnectOriginalSecNm
		/// <summary>�A�������_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�������_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOriginalSecNm
		{
			get { return _cnectOriginalSecNm; }
			set { _cnectOriginalSecNm = value; }
		}

		/// public propaty name  :  CnectOtherEpCd
		/// <summary>�A�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOtherEpCd
		{
			get { return _cnectOtherEpCd; }
			set { _cnectOtherEpCd = value; }
		}

		/// public propaty name  :  CnectOtherSecCd
		/// <summary>�A���拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A���拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOtherSecCd
		{
			get { return _cnectOtherSecCd; }
			set { _cnectOtherSecCd = value; }
		}

		/// public propaty name  :  CnectOtherSecNm
		/// <summary>�A���拒�_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A���拒�_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOtherSecNm
		{
			get { return _cnectOtherSecNm; }
			set { _cnectOtherSecNm = value; }
		}

		/// public propaty name  :  DiscDivCd
		/// <summary>���ʋ敪�v���p�e�B</summary>
		/// <value>0:�A���L�� 1:�A������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DiscDivCd
		{
			get { return _discDivCd; }
			set { _discDivCd = value; }
		}

		/// public propaty name  :  ScmCommMethod
		/// <summary>�ʐM����(SCM)�v���p�e�B</summary>
		/// <value>0:���Ȃ�,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʐM����(SCM)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 ScmCommMethod
		{
			get { return _scmCommMethod; }
			set { _scmCommMethod = value; }
		}

		/// public propaty name  :  PccUoeCommMethod
		/// <summary>�ʐM����(PCC-UOE)�v���p�e�B</summary>
		/// <value>0:���Ȃ�,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʐM����(PCC-UOE)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 PccUoeCommMethod
		{
			get { return _pccUoeCommMethod; }
			set { _pccUoeCommMethod = value; }
		}

        // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
        /// public propaty name  :  TabUseDiv
        /// <summary>�^�u���b�g�g�p�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�u���b�g�g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TabUseDiv
        {
            get { return _tabUseDiv; }
            set { _tabUseDiv = value; }
        }
        // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<

        // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  RCScmCommMethod
        /// <summary>�ʐM����(���i�⍇���E�����iRC�I�v�V�����j)�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM����(���i�⍇���E�����iRC�I�v�V�����j)�v���p�e�B</br>
        /// </remarks>
        public Int16 RcScmCommMethod
        {
            get { return _rcScmCommMethod; }
            set { _rcScmCommMethod = value; }
        }

        /// public propaty name  :  PrDispSystem
        /// <summary>�D��\���V�X�e��</summary>
        /// <value>10�F�V�i���i�iPM��D��\���j�A11�F���T�C�N���iRC��D��\���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��\���V�X�e���v���p�e�B</br>
        /// </remarks>
        public Int16 PrDispSystem
        {
            get { return _prDispSystem; }
            set { _prDispSystem = value; }
        }
        // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
        /// public propaty name  :  OldNewStatus
        /// <summary>�V���ؑփX�e�[�^�X</summary>
        /// <value>0:��,1:�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���ؑփX�e�[�^�X�v���p�e�B</br>
        /// </remarks>
        public Int32 OldNewStatus
        {
            get { return _oldNewStatus; }
            set { _oldNewStatus = value; }
        }

        /// public propaty name  :  UsualMnalStatus
        /// <summary>�ʏ�/�蓮�X�e�[�^�X</summary>
        /// <value>0:�ʏ�,1:�蓮</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʏ�/�蓮�X�e�[�^�X</br>
        /// </remarks>
        public Int32 UsualMnalStatus
        {
            get { return _usualMnalStatus; }
            set { _usualMnalStatus = value; }
        }

        /// public propaty name  :  PmDBId
        /// <summary>�p�[�c�}��DBID</summary>
        /// <value>�p�[�c�}�����_DB�T�[�o�[��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �p�[�c�}��DBID</br>
        /// </remarks>
        public string PmDBId
        {
            get { return _pmDBId; }
            set { _pmDBId = value; }
        }

        /// public propaty name  :  PmUploadDiv
        /// <summary>�p�[�c�}���A�b�v���[�h�敪</summary>
        /// <value>0:�Ȃ�,1:�A�b�v���[�h�ς�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �p�[�c�}���A�b�v���[�h�敪</br>
        /// </remarks>
        public Int32 PmUploadDiv
        {
            get { return _pmUploadDiv; }
            set { _pmUploadDiv = value; }
        }
        // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
        
        /// <summary>
		/// SCM��Ƌ��_�A���}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>ScmEpScCnt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpScCnt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmEpScCnt()
		{
		}

        /// <summary>
        /// SCM��Ƌ��_�A���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
        /// <param name="cnectOriginalSecCd">�A�������_�R�[�h</param>
        /// <param name="cnectOriginalSecNm">�A�������_�K�C�h����</param>
        /// <param name="cnectOtherEpCd">�A�����ƃR�[�h</param>
        /// <param name="cnectOtherSecCd">�A���拒�_�R�[�h</param>
        /// <param name="cnectOtherSecNm">�A���拒�_�K�C�h����</param>
        /// <param name="discDivCd">���ʋ敪(0:�A���L�� 1:�A������)</param>
        /// <param name="scmCommMethod">�ʐM����(SCM)(0:���Ȃ�,1:����)</param>
        /// <param name="pccUoeCommMethod">�ʐM����(PCC-UOE)(0:���Ȃ�,1:����)</param>
        /// <param name="tabUseDiv">�^�u���b�g�g�p�敪(0:���Ȃ�,1:����)</param>
        ///// <param name="rcUoeCommMethod">�ʐM����(���i�⍇���E�����iRC�I�v�V�����j)(0:���Ȃ�,1:����)</param>
        /// <param name="rcScmCommMethod">�ʐM����(���i�⍇���E�����iRC�I�v�V�����j)�v���p�e�B</param>
        /// <param name="prDispSystem">�D��\���V�X�e��</param>
        /// <param name="oldNewStatus">�V���ؑփX�e�[�^�X</param>
        /// <param name="usualMnalStatus">�ʏ�/�蓮�X�e�[�^�X</param>
        /// <param name="pmDBId">�p�[�c�}��DBID</param>
        /// <param name="pmUploadDiv">�p�[�c�}���A�b�v���[�h�敪</param>
        /// <returns>ScmEpScCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmEpScCnt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // UPD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
        //// UPD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //// UPD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
        //////public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod)
        ////public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int32 tabUseDiv)
        ////// UPD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
        //public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int32 tabUseDiv, Int16 rcScmCommMethod, Int16 prDispSystem)
        //// UPD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int32 tabUseDiv, Int16 rcScmCommMethod, Int16 prDispSystem, Int32 oldNewStatus, Int32 usualMnalStatus, string pmDBId, Int32 pmUploadDiv)
        // UPD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._cnectOriginalEpCd = cnectOriginalEpCd;
			this._cnectOriginalSecCd = cnectOriginalSecCd;
			this._cnectOriginalSecNm = cnectOriginalSecNm;
			this._cnectOtherEpCd = cnectOtherEpCd;
			this._cnectOtherSecCd = cnectOtherSecCd;
			this._cnectOtherSecNm = cnectOtherSecNm;
			this._discDivCd = discDivCd;
			this._scmCommMethod = scmCommMethod;
			this._pccUoeCommMethod = pccUoeCommMethod;
            // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
            this._tabUseDiv = tabUseDiv;
            // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
			// ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �ȉ���10533�Œǉ�
            this._rcScmCommMethod = rcScmCommMethod;
            this._prDispSystem = prDispSystem;
			// ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
            this.OldNewStatus = oldNewStatus;
            this.UsualMnalStatus = usualMnalStatus;
            this.PmDBId = pmDBId;
            this.PmUploadDiv = pmUploadDiv;
            // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
        }

		/// <summary>
		/// SCM��Ƌ��_�A���}�X�^��������
		/// </summary>
		/// <returns>ScmEpScCnt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmEpScCnt�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmEpScCnt Clone()
		{
            // UPD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
            //// UPD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            ////// UPD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
            //////return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod);
            ////return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._tabUseDiv);
            //return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._tabUseDiv, this._rcScmCommMethod, this._prDispSystem);
            //// UPD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
            //// UPD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._tabUseDiv, this._rcScmCommMethod, this._prDispSystem, this._oldNewStatus, this.UsualMnalStatus, this.PmDBId, this.PmUploadDiv);
            // UPD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
        }

		/// <summary>
		/// SCM��Ƌ��_�A���}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmEpScCnt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpScCnt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmEpScCnt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
				 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
				 && (this.CnectOriginalSecNm == target.CnectOriginalSecNm)
				 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
				 && (this.CnectOtherSecCd == target.CnectOtherSecCd)
				 && (this.CnectOtherSecNm == target.CnectOtherSecNm)
				 && (this.DiscDivCd == target.DiscDivCd)
				 && (this.ScmCommMethod == target.ScmCommMethod)
				 && (this.PccUoeCommMethod == target.PccUoeCommMethod)
                // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
                 && (this.TabUseDiv == target.TabUseDiv)
                // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
                // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.RcScmCommMethod == target.RcScmCommMethod)
                 && (this.PrDispSystem == target.PrDispSystem)
                // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
                 && (this.OldNewStatus == target.OldNewStatus)
                 && (this.UsualMnalStatus == target.UsualMnalStatus)
                 && (this.PmDBId == target.PmDBId)
                 && (this.PmUploadDiv == target.PmUploadDiv)
                // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
                );
		}

		/// <summary>
		/// SCM��Ƌ��_�A���}�X�^��r����
		/// </summary>
		/// <param name="scmEpScCnt1">
		///                    ��r����ScmEpScCnt�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmEpScCnt2">��r����ScmEpScCnt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpScCnt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ScmEpScCnt scmEpScCnt1, ScmEpScCnt scmEpScCnt2)
		{
			return ((scmEpScCnt1.CreateDateTime == scmEpScCnt2.CreateDateTime)
				 && (scmEpScCnt1.UpdateDateTime == scmEpScCnt2.UpdateDateTime)
				 && (scmEpScCnt1.LogicalDeleteCode == scmEpScCnt2.LogicalDeleteCode)
				 && (scmEpScCnt1.CnectOriginalEpCd == scmEpScCnt2.CnectOriginalEpCd)
				 && (scmEpScCnt1.CnectOriginalSecCd == scmEpScCnt2.CnectOriginalSecCd)
				 && (scmEpScCnt1.CnectOriginalSecNm == scmEpScCnt2.CnectOriginalSecNm)
				 && (scmEpScCnt1.CnectOtherEpCd == scmEpScCnt2.CnectOtherEpCd)
				 && (scmEpScCnt1.CnectOtherSecCd == scmEpScCnt2.CnectOtherSecCd)
				 && (scmEpScCnt1.CnectOtherSecNm == scmEpScCnt2.CnectOtherSecNm)
				 && (scmEpScCnt1.DiscDivCd == scmEpScCnt2.DiscDivCd)
				 && (scmEpScCnt1.ScmCommMethod == scmEpScCnt2.ScmCommMethod)
				 && (scmEpScCnt1.PccUoeCommMethod == scmEpScCnt2.PccUoeCommMethod)
                // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
                 && (scmEpScCnt1.TabUseDiv == scmEpScCnt2.TabUseDiv)
                // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
                // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (scmEpScCnt1.RcScmCommMethod == scmEpScCnt2.RcScmCommMethod)
                 && (scmEpScCnt1.PrDispSystem == scmEpScCnt2.PrDispSystem)
                // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
                 && (scmEpScCnt1.OldNewStatus == scmEpScCnt2.OldNewStatus)
                 && (scmEpScCnt1.UsualMnalStatus == scmEpScCnt2.UsualMnalStatus)
                 && (scmEpScCnt1.PmDBId == scmEpScCnt2.PmDBId)
                 && (scmEpScCnt1.PmUploadDiv == scmEpScCnt2.PmUploadDiv)
                // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<
                 );
		}
		/// <summary>
		/// SCM��Ƌ��_�A���}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmEpScCnt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpScCnt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmEpScCnt target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
			if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
			if (this.CnectOriginalSecNm != target.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
			if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
			if (this.CnectOtherSecCd != target.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
			if (this.CnectOtherSecNm != target.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
			if (this.DiscDivCd != target.DiscDivCd) resList.Add("DiscDivCd");
			if (this.ScmCommMethod != target.ScmCommMethod) resList.Add("ScmCommMethod");
			if (this.PccUoeCommMethod != target.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
            if (this.TabUseDiv != target.TabUseDiv) resList.Add("TabUseDiv");
            // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
            // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.RcScmCommMethod != target.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (this.PrDispSystem != target.PrDispSystem) resList.Add("PrDispSystem");
            // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
            if (this.OldNewStatus != target.OldNewStatus) resList.Add("OldNewStatus");
            if (this.UsualMnalStatus != target.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (this.PmDBId != target.PmDBId) resList.Add("PmDBId");
            if (this.PmUploadDiv != target.PmUploadDiv) resList.Add("PmUploadDiv");
            // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// SCM��Ƌ��_�A���}�X�^��r����
		/// </summary>
		/// <param name="scmEpScCnt1">��r����ScmEpScCnt�N���X�̃C���X�^���X</param>
		/// <param name="scmEpScCnt2">��r����ScmEpScCnt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpScCnt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ScmEpScCnt scmEpScCnt1, ScmEpScCnt scmEpScCnt2)
		{
			ArrayList resList = new ArrayList();
			if (scmEpScCnt1.CreateDateTime != scmEpScCnt2.CreateDateTime) resList.Add("CreateDateTime");
			if (scmEpScCnt1.UpdateDateTime != scmEpScCnt2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (scmEpScCnt1.LogicalDeleteCode != scmEpScCnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (scmEpScCnt1.CnectOriginalEpCd != scmEpScCnt2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
			if (scmEpScCnt1.CnectOriginalSecCd != scmEpScCnt2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
			if (scmEpScCnt1.CnectOriginalSecNm != scmEpScCnt2.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
			if (scmEpScCnt1.CnectOtherEpCd != scmEpScCnt2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
			if (scmEpScCnt1.CnectOtherSecCd != scmEpScCnt2.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
			if (scmEpScCnt1.CnectOtherSecNm != scmEpScCnt2.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
			if (scmEpScCnt1.DiscDivCd != scmEpScCnt2.DiscDivCd) resList.Add("DiscDivCd");
			if (scmEpScCnt1.ScmCommMethod != scmEpScCnt2.ScmCommMethod) resList.Add("ScmCommMethod");
			if (scmEpScCnt1.PccUoeCommMethod != scmEpScCnt2.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            // ADD 2013/06/26 yugami SCM��Q�Ή� ----------------------------------->>>>>
            if (scmEpScCnt1.TabUseDiv != scmEpScCnt2.TabUseDiv) resList.Add("TabUseDiv");
            // ADD 2013/06/26 yugami SCM��Q�Ή� -----------------------------------<<<<<
            // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmEpScCnt1.RcScmCommMethod != scmEpScCnt2.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (scmEpScCnt1.PrDispSystem != scmEpScCnt2.PrDispSystem) resList.Add("PrDispSystem");
            // ADD 2013/05/24 �g�� 2013/06/18�z�M SCM��Q��10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/12/19 ���� SCM������ PMNS�Ή� ----------------------------------->>>>>
            if (scmEpScCnt1.OldNewStatus != scmEpScCnt2.OldNewStatus) resList.Add("OldNewStatus");
            if (scmEpScCnt1.UsualMnalStatus != scmEpScCnt2.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (scmEpScCnt1.PmDBId != scmEpScCnt2.PmDBId) resList.Add("PmDBId");
            if (scmEpScCnt1.PmUploadDiv != scmEpScCnt2.PmUploadDiv) resList.Add("PmUploadDiv");
            // ADD 2014/12/19 ���� SCM������ PMNS�Ή� -----------------------------------<<<<<

			return resList;
		}
	}
}
