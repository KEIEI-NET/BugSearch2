using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �R���o�[�g�o�[�W�����Ǘ����i
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���l�ϊ������̃o�[�W��������ێ�����N���X�ł��B</br>
    /// <br>Programmer : </br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ConvertVersionManager
    { 
        #region �萔

        /// <summary>
        /// �o�[�W�������
        /// </summary>
        private const int _convertVersionAsm = (int)ConvertVersion.CT_CONVERT_VERSION_1;

        #endregion // �萔

        #region �񋓑�

        /// <summary>
        /// �ϊ��o�[�W����
        /// </summary>
        public enum ConvertVersion
        {
            CT_CONVERT_VERSION_NONE = 0,
            CT_CONVERT_VERSION_1 = 1,
            CT_CONVERT_VERSION_2 = 2,
            CT_CONVERT_VERSION_3 = 3
        }

        #endregion // �񋓑�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ConvertVersionManager()
        {
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B

        /// <summary>
        /// �o�[�W�������
        /// </summary>
        public int ConvertVersionAsm
        {
            get { return _convertVersionAsm; }
        }

        #endregion


    }
}
