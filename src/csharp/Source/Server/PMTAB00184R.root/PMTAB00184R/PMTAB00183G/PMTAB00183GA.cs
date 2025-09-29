//**********************************************************************//
// �V�X�e��         �FPM.NS                                             //
// �v���O��������   �FPMTAB�A�b�v���[�h�r�����䌟���}�X�^����N���X     // 
// �v���O�����T�v   �FPMTAB�A�b�v���[�h�r�����䌟���}�X�^����N���X     //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����                                                                 //
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����                              //
// �� �� ��  2013/06/24  �쐬���e : �V�K�쐬                            //
//----------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// PmTabUpldExclsvDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IPmTabUpldExclsvDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PmTabUpldExclsvDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �A���� </br>
    /// <br>Date       : 2013/06/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPmTabUpldExclsvDB
	{
		/// <summary>
		/// PmTabUpldExclsvDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/24</br>
		/// </remarks>
        public MediationPmTabUpldExclsvDB()
		{
		}
		/// <summary>
        /// IPmTabUpldExclsvDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPmTabUpldExclsvDB�I�u�W�F�N�g</returns>
        public static IPmTabUpldExclsvDB GetPmtUpldExclsvDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9020";
#endif
			
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPmTabUpldExclsvDB)Activator.GetObject(typeof(IPmTabUpldExclsvDB), string.Format("{0}/MyAppPmTabUpldExclsv", wkStr));
		}
	}
}
