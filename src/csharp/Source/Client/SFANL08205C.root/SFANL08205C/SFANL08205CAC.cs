//**********************************************************************//
// System           :   �r�e�D�m�d�s                                    //
// Sub System       :                                                   //
// Program name     :   ������N���X�A�C���^�[�t�F�[�X                //
//                  :												    //
// Name Space       :   Broadleaf.Application.Common				�@�@//
// Programer        :   �����@���l�@                                    //
// Date             :   2007.03.19                                      //
//----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co,. Ltd                 //
//**********************************************************************//
using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Collections.Generic;

//using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// SFANL08205C
	/// </summary>
	[Serializable]
	public class SFANL08205C
    {

        #region const
        // Message�֘A
        private const string ctDOWNLOAD_TITLE = "���R���[�w�i�摜�擾����";
        private const string ctDOWNLOAD_MESSAGE = "���R���[�p�w�i�摜�̎擾���ł��D�D�D";
        // Image�֘A
        private const Int32 ctSYSTEMDIVCD = 0;
        private const Int32 ctIMAGEUSESYSTEM_CODE = 100;
        #endregion

        #region constructor
        // �R���X�g���N�^
		/// <summary>
		/// PrintInfo �N���X�̏������y�уC���X�^���X�������s���܂��B
		/// </summary>
		public SFANL08205C()
		{
        }
        #endregion

        #region public member
        // ���o�����p�����[�^
		/// <summary>
		/// ���o�����p�����[�^���C���i�ėp�����邽�߁A�n�a�i�d�b�s�^�Ƃ���B�j
		/// �^�͉�ʁA���o�A������Ŕ��f�ł��邽�߁B
		/// </summary>
		public object jyoken;
        /// <summary>
        /// ���o�����p�����[�^���חp
        /// </summary>
        public object jyokenDtl;

		/// <summary>
		/// ��ƃR�[�h
		/// </summary>
		public string enterpriseCode;

		// ����p�p�����[�^
		/// <summary>
		/// �v���r���[�L���敪 0:���� 1:�L��
		/// </summary>
		public int prevkbn;
        /// <summary>
        /// �_�~�[�f�[�^����敪 true:�_�~�[�f�[�^��� false:DB�f�[�^�Q��
        /// </summary>
        public Boolean dummyPrtDiv;
        /// <summary>
		/// ������[�h 0:localpdf 1:local 2:���� 3:�o�b�`��� 4:�_�~�[�f�[�^�v���r���[
		/// </summary>
		public int printmode;
		/// <summary>
		/// ���[����
		/// </summary>
		public string prpnm;
		/// <summary>
		/// �v�����^��
		/// </summary>
		public string prinm;
        /// <summary>
        /// �o�̓t�@�C����
        /// </summary>
        public string outputFormFileName;
        /// <summary>
        /// ���[�U�[���[ID�}��
        /// </summary>
        public int userPrtPprIdDerivNo;
        /// <summary>
        /// �o�͊m�F���b�Z�[�W
        /// </summary>
        public string outConfimationMsg;
		/// <summary>
		/// ���o����XML�ۑ���p�X
		/// </summary>
		public string jyokenxmlpath;
        /// <summary>
        /// �󎚈ʒu�N���X�f�[�^ (ActiveReport)
        /// </summary>
        public object printPosClassData;
        /// <summary>
        /// ���[�w�i�摜�f�[�^
        /// </summary>
        public Bitmap PrintPprBgImageData;
        /// <summary>
        /// �\�[�g���ʃ��X�g
        /// </summary>
        public List<FrePprSrtO> sortOdrLs;
        /// <summary>
        /// �I�����_���X�g
        /// </summary>
        public List<string> selectSecCds;
        /// <summary>
        /// ���_�I�v�V�����L��
        /// </summary>
        public bool sectionOptionDiv;
        /// <summary>
        /// ���_���̃��X�g
        /// </summary>
        public Dictionary<string,string> sectionNameLs;
        /// <summary>
        /// ���o���_���
        /// </summary>
        public int sectionKindCd = 1;
        /// <summary>
        /// DM�͂�������ꎞ���f����
        /// </summary>
        public int pcardPrtSuspendCnt;
        /// <summary>
        /// ���[�g�p�敪
        /// </summary>
        public int printPaperUseDivcd;
        /// <summary>
        /// �捞�摜�O���[�v�R�[�h
        /// </summary>
        public Guid takeInImageGroupCd;
        /// <summary>
        /// ����R���o�[�g�g�p�敪 (0:��,1:�}�N��)
        /// </summary>
        public int SpecialConvtUseDivCd;
        /// <summary>
        /// PDF�p�X
        /// </summary>
        public string pdftemppath;
        /// <summary>
        /// ���R���[ ����p�r�敪 0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���
        /// </summary>
        public int freePrtPprSpPrpseCd;
        /// <summary>
        /// �S�Ћ敪(�S�ЁFTrue, �S�ЂłȂ�:false)
        /// </summary>
        public bool AllSectionCodeDiv = true;


		// -------------������n���p�����[�^
		/// <summary>
		/// ���o���ʃf�[�^�I�u�W�F�N�g
		/// </summary>
		public DataSet rdData;
        /// <summary>
		/// �N���o�f�h�c
		/// </summary>
		public string kidopgid;
		/// <summary>
		/// ���o�o�f�h�c
		/// </summary>
		public string extrapgid;
		/// <summary>
		/// ���o�o�f���S�^��
		/// </summary>
		public string extraclassid;
		/// <summary>
		/// ����o�f�h�c
		/// </summary>
		public string printpgid;
        /// <summary>����o�f���S�^��</summary>
		public string printclassid;
        /// <summary>���[�w�i�摜�c�ʒu</summary>
	    public double prtPprBgImageRowPos;
        /// <summary>���[�w�i�摜���ʒu</summary>
        public double prtPprBgImageColPos;
        
        // �߂�p�����[�^
		/// <summary>�X�e�[�^�X</summary>
		public int status;
        /// <summary>�߂胁�b�Z�[�W</summary>
        public string message = string.Empty;
        #endregion

        #region private member
        #endregion

        #region public methods
        /// <summary>
        /// �󎚈ʒu�ݒ���捞����(�w�i�摜�͎擾���܂���)
        /// </summary>
        /// <param name="frePrtPSet">�󎚈ʒu�ݒ�f�[�^�N���X</param>
        /// <param name="enterpriseCode">�N�ƃR�[�h</param>
        /// <param name="kidopgid">�N���o�f�h�c</param>
        /// <param name="jyokenMain">���C�����o����</param>
        /// <param name="jokenDtl">���o��������</param>
        /// <param name="dummyPrtDiv">�_�~�[�f�[�^����敪 true:�_�~�[�f�[�^��� false:DB�f�[�^�Q��</param>
        public void InportFrePrtPSet(FrePrtPSet frePrtPSet, string enterpriseCode, string kidopgid, object jyokenMain, object jokenDtl, bool dummyPrtDiv)
        {
            // ����p�����[�^���Z�b�g
            this.enterpriseCode = enterpriseCode;                      // ��ƃR�[�h
            this.kidopgid = kidopgid;		                            // �N���o�f�h�c
            this.extrapgid = frePrtPSet.ExtractionPgId;                // ���o�o�f�h�c
            this.extraclassid = frePrtPSet.ExtractionPgClassId;        // ���o�o�f���S�^��
            this.printpgid = frePrtPSet.OutputPgId;                    // �o�͂o�f�h�c
            this.printclassid = frePrtPSet.OutputPgClassId;            // �o�̓N���X�h�c
            this.jyoken = jyokenMain;                                  // ���o�������C��
            this.jyokenDtl = jokenDtl;                                 // ���o��������
            this.prpnm = frePrtPSet.DisplayName;                       // �o�͖���
            this.outputFormFileName = frePrtPSet.OutputFormFileName;   // �o�̓t�@�C����
            this.userPrtPprIdDerivNo = frePrtPSet.UserPrtPprIdDerivNo; // ���[�U�[���[ID
            this.outConfimationMsg = frePrtPSet.OutConfimationMsg;     // �o�͊m�F���b�Z�[�W
            this.printPosClassData = frePrtPSet.PrintPosClassData;     // �󎚈ʒu�N���X
            this.prtPprBgImageRowPos = frePrtPSet.PrtPprBgImageRowPos; // �w�i�摜�c�ʒu
            this.prtPprBgImageColPos = frePrtPSet.PrtPprBgImageColPos; // �w�i�摜���ʒu
            this.dummyPrtDiv = dummyPrtDiv;                            // �_�~�[�f�[�^����敪
            this.printPaperUseDivcd = frePrtPSet.PrintPaperUseDivcd;   // ���[�g�p�敪
            this.takeInImageGroupCd = frePrtPSet.TakeInImageGroupCd;   // �捞�摜�O���[�v�R�[�h
            this.freePrtPprSpPrpseCd = frePrtPSet.FreePrtPprSpPrpseCd; // ���R���[ ����p�r�敪
            // �󎚈ʒu�N���X
            MemoryStream mst1 = new MemoryStream(frePrtPSet.PrintPosClassData);
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = new DataDynamics.ActiveReports.ActiveReport3();
            prtRpt.LoadLayout(mst1);
            this.printPosClassData = prtRpt;
        }
        #endregion
    }
}