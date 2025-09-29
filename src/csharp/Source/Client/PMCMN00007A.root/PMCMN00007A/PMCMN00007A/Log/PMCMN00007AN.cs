//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���擾���i
// �v���O�����T�v   : �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B
//                  : �E���엚�������[�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Log
{
    using DBRecordType = OprtnHisLogWork;

    /// <summary>
    /// �I�t���C���p���K�[�N���X
    /// </summary>
    internal sealed class OfflineLogger //: IOprtnHisLogDB �������[�g�̃C���^�[�t�F�[�X����������̂͋֎~
    {
        #region <IOprtnHisLogDB �����o/>

        #region <�������Ȃ�/>

        /// <see cref="IOprtnHisLogDB"/>
        public int Delete(object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int LogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Read(ref object oprtnHisLogWork, int readMode)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int RevivalLogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Search(
            ref object oprtnHisLogWork,
            object oprtnHisLogSrchWork,
            int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode
        )
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion  // <�������Ȃ�/>

        /// <see cref="IOprtnHisLogDB"/>
        public int Write(ref object oprtnHisLogWork)
        {
            #region <Guard Phrase/>

            if (oprtnHisLogWork == null) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            #endregion  // <Guard Phrase/>

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList workList = oprtnHisLogWork as ArrayList;
            if (workList != null)
            {
                DBRecordType[] oprtnHisLogWorkArray = workList.ToArray(typeof(DBRecordType)) as DBRecordType[];

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), FolderPath);
                string fileName = String.Format("Client{0}{1}.log", DateTime.Now.Ticks, Guid.NewGuid());

                // �V���A���C�Y
                UserSettingController.SerializeUserSetting(oprtnHisLogWorkArray, Path.Combine(filePath, fileName));

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        #endregion  // <IOprtnHisLogDB �����o/>

        /// <summary>�I�t���C�����̃f�t�H���g�o�̓t�H���_�p�X</summary>
        public const string DEFAULT_FOLDER_PATH = "Log\\Operation";

        /// <summary>�t�H���_�p�X</summary>
        private readonly string _folderPath;
        /// <summary>
        /// �t�H���_�p�X���擾���܂��B
        /// </summary>
        /// <value>�t�H���_�p�X</value>
        public string FolderPath
        {
            get { return _folderPath; }
        }

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OfflineLogger() : this(DEFAULT_FOLDER_PATH) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="folderPath">�t�H���_�p�X</param>
        public OfflineLogger(string folderPath)
        {
            _folderPath = folderPath;
        }

        #endregion  // <Constructor/>

        #region <�����\�b�h�i�I���W�i���j/>
        
        /// <summary>
        /// ���엚�����O�I�t���C���f�[�^�o�^
        /// </summary>
        /// <param name="workobj">>�ΏۃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�t���C���f�[�^��o�^���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.12.18</br>
        /// </remarks>
        [Obsolete("�����\�b�h�i�I���W�i���j")]
        private int WriteOffline(object workobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (workobj == null) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                ArrayList workList = workobj as ArrayList;
                if (workList != null)
                {
                    OprtnHisLogWork[] oprtnHisLogWorkArray = workList.ToArray(typeof(OprtnHisLogWork)) as OprtnHisLogWork[];

                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_FOLDER_PATH);
                    string fileName = String.Format("Client{0}{1}.log", DateTime.Now.Ticks, Guid.NewGuid());

                    // �V���A���C�Y
                    UserSettingController.SerializeUserSetting(oprtnHisLogWorkArray,
                        Path.Combine(filePath, fileName));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
            }

            return status;
        }

#if DEBUG
        private DateTime _dtime_s, _dtime_e;
        private System.IO.FileStream _fs = null;
        private System.IO.StreamWriter _sw = null;

        [Obsolete("�����\�b�h�i�I���W�i���j")]
        private void DebugLogWrite(int mode, string msg)
        {
            this._fs = new System.IO.FileStream("MACMN00110C_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            this._sw = new System.IO.StreamWriter(this._fs, System.Text.Encoding.GetEncoding("shift_jis"));
            if (mode == 0)
            {

                this._dtime_s = DateTime.Now;
                TimeSpan ts = this._dtime_s.Subtract(this._dtime_s);
                string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
                    this._dtime_s, this._dtime_s.Millisecond, ts.ToString(), msg);
                this._sw.WriteLine(s);
            }
            else if (mode == 1)
            {
                this._dtime_e = DateTime.Now;
                TimeSpan ts = this._dtime_e.Subtract(this._dtime_s);
                string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
                    this._dtime_e, this._dtime_e.Millisecond, ts.ToString(), msg);

                this._sw.WriteLine(s);

                this._dtime_s = this._dtime_e;
            }
            else if (mode == 9)
            {
            }
            this._sw.Close();
            this._fs.Close();
        }
#endif
        #endregion  // <�����\�b�h�i�I���W�i���j/>
    }

    /// <summary>
    /// �������Ȃ��I�����C�����K�[�N���X
    /// </summary>
    internal sealed class NullOnlineLogger //: IOprtnHisLogDB �������[�g�̃C���^�[�t�F�[�X����������̂͋֎~
    {
        #region <IOprtnHisLogDB �����o/>

        /// <see cref="IOprtnHisLogDB"/>
        public int Delete(object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int LogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Read(ref object oprtnHisLogWork, int readMode)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int RevivalLogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Search(
            ref object oprtnHisLogWork,
            object oprtnHisLogSrchWork,
            int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode
        )
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Write(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion  // <IOprtnHisLogDB �����o/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public NullOnlineLogger() { }
    }
}
