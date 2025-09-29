//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͑��샍�O�o�^�����C���^�[�t�F�[�X
// �v���O�����T�v   : �e�L�X�g�o�͑��샍�O�o�^����
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00  �쐬�S�� : �c����
// �� �� ��  2019/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �e�L�X�g�o�͑��샍�O�o�^�����C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�����C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/08/12</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITextOutPutOprtnHisLogDB
    {
        /// <summary>
        /// �e�L�X�g�o�͑��샍�O�o�^�������s���B
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWorkObj">�e�L�X�g�o�͑��샍�O�o�^�p�Ώۃ��[�N</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���s���ʏ��</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O�o�^�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(ref object textOutPutOprtnHisLogWorkObj, out string errMsg);
    }
}
