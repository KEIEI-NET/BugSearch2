using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���R���[����n���������萔�Ǘ�
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[����n���������Ŏg�p����const���`���܂�</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CD
    {
        #region public const
        // -- �쐬���������� ---------------------------------------------
        /// <summary>�e����������̊Ԋu</summary>
        public const string CT_ITEM_INTERVAL = "�@�@�@�@";

        // -- �f�[�^�\�[�X���f�[�^�����o�[ -------------------------------
        /// <summary>���R���[����p�f�[�^�Z�b�g��</summary>
        public const string CT_FREPPRPRINTDS = "FREPPRPRINTDS";
        /// <summary>���C������f�[�^�p�f�[�^�e�[�u����</summary>
        public const string CT_FREPPRPRINT_MAIN_DT = "FREPPRPRINT_MAIN_DT";
        /// <summary>���o�����p�f�[�^�e�[�u����</summary>
        public const string CT_FREPPRPRINT_EXTR_DT = "FREPPRPRINT_EXTR_DT";
        /// <summary>���[�t�b�^�[���p�f�[�^�e�[�u����</summary>
        public const string CT_FREPPRPRINT_PFTR_DT = "FREPPRPRINT_PFTR_DT";
        /// <summary>�\�[�g���ʗp�f�[�^�e�[�u����</summary>
        public const string CT_FREPPRPRINT_SRTO_DT = "FREPPRPRINT_SRTO_DT";

        // -- �t�B�[���h�� -----------------------------------------------
        // ���[�t�b�^�[���p�f�[�^�e�[�u����
        /// <summary>���[�t�b�^�[��1</summary>
        public const string CT_PRINTFOOTER1 = "PRTOUTSETRF.PRINTFOOTER1RF";
        /// <summary>���[�t�b�^�[��2</summary>
        public const string CT_PRINTFOOTER2 = "PRTOUTSETRF.PRINTFOOTER2RF";

        // ���o����������
        /// <summary>���o����������</summary>
        public const string CT_EXTRACTCONDS = "FREPPRPRINT_EXTRACT_CONDS";
        
        // �\�[�g����
        /// <summary>�\�[�g����</summary>
        public const string CT_SORTODER = "FREPPRPRINT_SORTODER";

        /// <summary>�\�[�g����1</summary>
        public const string CT_SORTODER1 = "FREPPRPRINT_SORTODER1";
        /// <summary>�\�[�g����2</summary>
        public const string CT_SORTODER2 = "FREPPRPRINT_SORTODER2";
        /// <summary>�\�[�g����3</summary>
        public const string CT_SORTODER3 = "FREPPRPRINT_SORTODER3";
        /// <summary>�\�[�g����4</summary>
        public const string CT_SORTODER4 = "FREPPRPRINT_SORTODER4";
        /// <summary>�\�[�g����5</summary>
        public const string CT_SORTODER5 = "FREPPRPRINT_SORTODER5";

////////////////////////////////////////////// 2008.02.07 TERASAKA ADD STA //
		// -- �`�[�p�R���g���[���� -----------------------------------------------
		/// <summary>�ی����GroupHeader</summary>
		public const string CT_INSURINFO_GROUPHEADERNAME = "InsurHeader";
		/// <summary>�ی����GroupFooter</summary>
		public const string CT_INSURINFO_GROUPFOOTERNAME = "InsurFooter";
// 2008.02.07 TERASAKA ADD END //////////////////////////////////////////////
        #endregion
    }
}
