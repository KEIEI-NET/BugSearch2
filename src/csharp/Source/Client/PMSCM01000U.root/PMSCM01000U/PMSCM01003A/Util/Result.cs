using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���ʃ��[�e�B���e�B
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// ���ʃR�[�h�񋓑�
        /// </summary>
        public enum Code : int
        {
            /// <summary>����</summary>
            Normal = 0,
            // 2011/03/18 Add >>>
            /// <summary>�Y������</summary>
            NotFound = 4,
            // 2011/03/18 Add <<<
            /// <summary>�G���[</summary>
            Error = 1
        }
    }
}
