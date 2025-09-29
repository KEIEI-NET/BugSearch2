//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE�����pI/OWriteDB����N���X
//                  :   PMUOE01005G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// IOWriteUOEOdrDtlDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IIOWriteUOEOdrDtlDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IOWriteUOEOdrDtlDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIOWriteUOEOdrDtlDB
    {
        /// <summary>
        /// IOWriteUOEOdrDtlDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        public MediationIOWriteUOEOdrDtlDB()
        {

        }

        /// <summary>
        /// IIOWriteUOEOdrDtlDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IIOWriteUOEOdrDtlDB�I�u�W�F�N�g</returns>
        public static IIOWriteUOEOdrDtlDB GetIOWriteUOEOdrDtlDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IIOWriteUOEOdrDtlDB)Activator.GetObject(typeof(IIOWriteUOEOdrDtlDB),string.Format("{0}/MyAppIOWriteUOEOdrDtl",wkStr));
        }
    }
}
