//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/06/12  �C�����e : ��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/03  �C�����e �F��z�Č��ARedmine#30393 
//                                  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/11  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.62�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/13  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.7�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/20  �C�����e �F��z�Č��ARedmine#30387 
//                                  ��Q�ꗗ�̎w�ENO.108�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Data;// ADD  2012/06/12  ������ Redmine#30393
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2012/06/12 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
    /// <br>Update Note: 2012/07/03 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
    /// <br>Update Note: 2012/07/11 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.62�̑Ή�</br>
    /// <br>Update Note: 2012/07/13 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�̑Ή�</br>
    /// <br>Update Note: 2012/07/20 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomerImportDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="checkDiv">�`�F�b�N�敪</param>
        /// <param name="consTaxLay">����œ]�ŕ���</param>
        /// <param name="objImportWorkList">�C���|�[�g�f�[�^���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="logCnt">���O����</param>// ADD  2012/06/12  ������ Redmine#30393
        /// <param name="logArrayList">���O���X�g</param>// ADD  2012/07/03  ������ Redmine#30393
        /// <param name="enterpriseCode">��ƃR�[�h</param>// ADD  2012/06/12  ������ Redmine#30393
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
        /// <br>Update Note: 2012/07/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30393  ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���</br>
        /// <br>Update Note: 2012/07/11 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.62�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.7�̑Ή�</br>
        /// <br>Update Note: 2012/07/20 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            Int32 checkDiv, // ADD  2012/07/20  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.108�̑Ή�
            //[CustomSerializationMethodParameterAttribute("PMKHN09016D", "Broadleaf.Application.Remoting.ParamData.CustomerWork")]// DEL  2012/06/12  ������ Redmine#30393
            //ref object importWorkList, //DEL  2012/06/12  ������ Redmine#30393
            //ref object importWorkTable,//ADD  2012/06/12  ������ Redmine#30393 DEL  2012/07/03  ������ Redmine#30393
            Int32 consTaxLay,// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.62�̑Ή�
            [CustomSerializationMethodParameterAttribute("PMKHN07646D", "Broadleaf.Application.Remoting.ParamData.CustomerGroupWork")]// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            ref object objImportWorkList,// ADD  2012/07/03  ������ Redmine#30393
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
            out Int32 logCnt,
            //out DataTable logTable, // DEL  2012/07/03  ������ Redmine#30393
            //out ArrayList logArrayList,// ADD  2012/07/03  ������ Redmine#30393// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.7�̑Ή�
            // ------ ADD START 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.7�̑Ή�-------->>>>
          [CustomSerializationMethodParameterAttribute("PMKHN07646D", "Broadleaf.Application.Remoting.ParamData.CustomerGroupWork")]
            out object logArrayList,
            // ------ ADD END 2012/07/13 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.7�̑Ή�--------<<<<
            string enterpriseCode,
            // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
            out string errMsg);

    }
}
