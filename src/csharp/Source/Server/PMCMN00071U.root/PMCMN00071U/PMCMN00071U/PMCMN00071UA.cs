using System;

namespace Broadleaf.Application.Batch
{
    /// <summary>
    /// LSM���O�o�͎��s�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : LSM���O�t�@�C����ϊ���CLC���O�f�B���N�g���ɕۑ����܂��B</br>
    /// <br>Programmer : ���X�� �j</br>
    /// <br>Date       : 2015/05/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PMCMN00071UA
    {
        /// <summary>
        /// Main����
        /// </summary>
        /// <param name="args">����</param>
        public static void Main(string[] args)
        {
            // LSM���O�t�@�C������N���X
            LSMLogFileControl lsmLogFileCtrl = new LSMLogFileControl();

            // CLC�pLSM���O�t�@�C�����쐬���s
            lsmLogFileCtrl.CopyLSMToCLCLogFileMain();
        }
    }
}
