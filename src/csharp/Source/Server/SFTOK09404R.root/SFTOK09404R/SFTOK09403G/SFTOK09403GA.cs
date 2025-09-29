using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// NoteGuidBdDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��INoteGuidBdDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���NoteGuidBdDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.10.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationNoteGuidBdDB
	{
		/// <summary>
		/// NoteGuidBdDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		public MediationNoteGuidBdDB()
		{
		}
		/// <summary>
		/// INoteGuidBdDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>INoteGuidBdDB�I�u�W�F�N�g</returns>
		/// <br>Note       : INoteGuidBdDB�C���^�[�t�F�[�X���擾���܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public static INoteGuidBdDB GetNoteGuidBdDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

			// �f�o�b�O�p
#if DEBUG
			wkStr = "http://localhost:8001";
# endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (INoteGuidBdDB)Activator.GetObject(typeof(INoteGuidBdDB),string.Format("{0}/MyAppNoteGuidBd",wkStr));
		}
	}
}
