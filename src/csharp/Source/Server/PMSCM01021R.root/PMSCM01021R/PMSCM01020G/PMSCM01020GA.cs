//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�֘A�f�[�^DB����N���X
//                  :   PMSCM01020G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 ���� ���n
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ScmIOWriterDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IScmIOWriterDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IScmIOWriterDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIOWriteScmDB
    {
        /// <summary>
        /// IScmIOWriterDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public MediationIOWriteScmDB()
        {

        }

        /// <summary>
        /// IScmIOWriterDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IScmIOWriterDB�I�u�W�F�N�g</returns>
        public static IIOWriteScmDB GetIOWriteScmDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8002";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IIOWriteScmDB)Activator.GetObject(typeof(IIOWriteScmDB), string.Format("{0}/MyAppIOWriteScm", wkStr));
        }
    }
}
