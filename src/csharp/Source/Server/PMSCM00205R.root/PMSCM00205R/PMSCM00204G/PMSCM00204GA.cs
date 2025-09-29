//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ȒP�⍇���ڑ����DB����N���X
//                  :   PMSCM00204G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21024�@���X�� ��
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CMTCnectInfoDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICMTCnectInfoDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CMTCnectInfoDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSimplInqCnectInfoDB
    {
        /// <summary>
        /// CMTCnectInfoDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public MediationSimplInqCnectInfoDB()
        {

        }

        /// <summary>
        /// ICMTCnectInfoDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICMTCnectInfoDB�I�u�W�F�N�g</returns>
        public static ISimplInqCnectInfoDB GetSimplInqCnectInfoDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISimplInqCnectInfoDB)Activator.GetObject(typeof(ISimplInqCnectInfoDB), string.Format("{0}/MySimplInqCnectInfo", wkStr));
        }
    }
}
