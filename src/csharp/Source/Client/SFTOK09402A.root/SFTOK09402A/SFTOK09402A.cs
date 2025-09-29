using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Application.LocalAccess;	2007.10.04 sasaki
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���l�K�C�h�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���l�K�C�h�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �O�� �M�j</br>
    /// <br>Date       : 2005.10.14</br>
    /// <br></br>
    /// <br>Update Note: 2007.02.27 22022 �i�� �m�q</br>
    /// <br>			 �ESF�ł𗬗p���g�єł��쐬</br>
    /// <br>Update Note: 2007.04.04 980023 �ђJ �k��</br>
    /// <br>			 �ERead�A�K�C�h��Search �̏��������[�J��DB����̓Ǎ��ɕύX</br>
    /// <br>Update Note: 2007.05.21 18322 �ؑ� ����</br>
    /// <br>			 �ERead�A�K�C�h��Search �̏��������[�J��DB����̓Ǎ��ɕύX(NoteGuidWorkList�Ή�)</br>
	/// <br>Update Note: 2007.10.04 21024 ���X�� ��</br>
	/// <br>			 �EDC.NS�p�Ƀ��[�J���Ή����폜</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : �I�t���C���Ή� </br>
    /// <br>			: 22008 ���� ���n</br>
    /// <br>			: 2010/05/25</br>
    /// <br>-------------------------------------------------------</br>
    /// </remarks>
    public class NoteGuidAcs : IGeneralGuideData
    {
        #region Private Members
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private INoteGuidBdDB _iNoteGuidBdDB = null;
		// 2007.10.04 sasaki >>
		///// <summary>���[�J��DB�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		//private NoteGuidBdLcDB _noteGuidBdLcDB = null;  // iitani a
		// 2007.10.04 sasaki <<
		/// <summary>�K�C�h�p�f�[�^�o�b�t�@</summary>
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        // <summary>���[�J��DB�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private NoteGuidBdLcDB _noteGuidBdLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
        private static Hashtable _guidBuff_NoteGdBd;
        /// <summary>���l�K�C�h�i�w�b�_�j�N���XStatic</summary>
        private static Hashtable _noteGdHdTable_Stc = null;
        #endregion

        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        #region Properties
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        #endregion
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

        #region Constructor
        /// <summary>
        /// ���l�K�C�h�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public NoteGuidAcs()
        {
            // ���l�K�C�h�i�w�b�_�jStatic
            if (_noteGdHdTable_Stc == null)
            {
                _noteGdHdTable_Stc = new Hashtable();
            }

            // ���O�C�����i�ŒʐM��Ԃ��m�F
            // -- UPD 2010/05/25 ------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iNoteGuidBdDB = (INoteGuidBdDB)MediationNoteGuidBdDB.GetNoteGuidBdDB();
            //    }
            //    catch (Exception)
            //    {
            //        //�I�t���C������null���Z�b�g
            //        this._iNoteGuidBdDB = null;
            //    }
            //}
            //else
            //{
            //    // �I�t���C�����̃f�[�^�ǂݍ���
            //    this.SearchOfflineData();
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iNoteGuidBdDB = (INoteGuidBdDB)MediationNoteGuidBdDB.GetNoteGuidBdDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
            }
            // -- UPD 2010/05/25 -------------------<<<

            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			// 2007.10.04 sasaki >>
            //this._noteGuidBdLcDB = new NoteGuidBdLcDB();   // iitani a
			// 2007.10.04 sasaki <<
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._noteGuidBdLcDB = new NoteGuidBdLcDB();
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
        }
        #endregion

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iNoteGuidBdDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�jStatic�������S���擾����
        /// </summary>
        /// <param name="retList">���l�K�C�h�i�w�b�_�jList</param>
        /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�jStatic�������̑S�����擾���܂��B</br>
        /// <br>Programer  : 22033  �O��  �M�j</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int SearchStaticMemory(out ArrayList retList)
        {
            retList = new ArrayList();
            retList.Clear();

            if (_noteGdHdTable_Stc == null)
            {
                return -1;
            }
            else if (_noteGdHdTable_Stc.Count == 0)
            {
                return 9;
            }

            SortedList sortedList = new SortedList();
            foreach (NoteGuidHd wkNoteGuidHd in _noteGdHdTable_Stc.Values)
            {
                sortedList.Add(wkNoteGuidHd.NoteGuideDivCode, wkNoteGuidHd);
            }

            retList.AddRange(sortedList.Values);

            return 0;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�擾����
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�N���X</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪�R�[�h</param>
        /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 4:�f�[�^����)</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j���������������܂��B</br>
        /// <br>Programer  : 22033  �O��  �M�j</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int ReadStaticMemory(out NoteGuidHd noteGuidHd, int noteGuideDivCode)
        {
            noteGuidHd = new NoteGuidHd();

            if (_noteGdHdTable_Stc == null)
            {
                return -1;
            }

            // Static���猟��
            if (_noteGdHdTable_Stc[noteGuideDivCode] == null)
            {
                return 4;
            }
            else
            {
                noteGuidHd = (NoteGuidHd)_noteGdHdTable_Stc[noteGuideDivCode];
            }

            return 0;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�jStatic���������I�t���C���������ݏ���
        /// </summary>
        /// <param name="sender">object�i�ďo���I�u�W�F�N�g�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�jStatic�������̏������[�J���t�@�C���ɕۑ����܂��B</br>
        /// <br>Programer  : 22033  �O��  �M�j</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int WriteOfflineData(object sender)
        {
            // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
            int status = 9;

            if (_noteGdHdTable_Stc.Count != 0)
            {
                // KeyList�ݒ�
                string[] noteGuidHdKeys = new string[1];
                noteGuidHdKeys[0] = LoginInfoAcquisition.EnterpriseCode;

                ArrayList noteGuidHdWorkList = new ArrayList();
                foreach (NoteGuidHd noteGuidHd in _noteGdHdTable_Stc.Values)
                {
                    // �N���X �� ���[�J�[�N���X
                    noteGuidHdWorkList.Add(CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd));
                }

                status = offlineDataSerializer.Serialize(this.ToString(), noteGuidHdKeys, noteGuidHdWorkList);
            }

            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u���ǂݍ��ݏ���
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <returns>���l�K�C�h�i�w�b�_�j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�e�[�u����Read�����ł��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public int Read(out NoteGuidHd noteGuidHd, string enterpriseCode, int noteGuideDivCode)
        {
            try
            {
                int status = 0;

                // �I�����C�����̓����[�g�擾
                // -- DEL 2010/05/25 ---------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ----------------------<<<
                    noteGuidHd = null;
                    NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
                    noteGuidHdWork.EnterpriseCode = enterpriseCode;
                    noteGuidHdWork.NoteGuideDivCode = noteGuideDivCode;

                    // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                    //// XML�֕ϊ����A������̃o�C�i����
                    //byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                    //
                    //// ���l�}�X�^�ǂݍ���(���[�J��DB)
                    //status = this._iNoteGuidBdDB.ReadHeader(ref parabyte, 0);
                    //
                    //if (status == 0)
                    //{
                    //    // XML�̓ǂݍ��� 
                    //    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                    //    // �N���X�������o�R�s�[
                    //    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                    //}
                    if (_isLocalDBRead)
                    {
                        // ���l�}�X�^�ǂݍ���(���[�J��DB) 
                        status = this._noteGuidBdLcDB.ReadHeader(ref noteGuidHdWork, 0);
                        if (status == 0)
                        {
                            // �N���X�������o�R�s�[
                            noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                        }
                    }
                    else
                    {
                        // XML�֕ϊ����A������̃o�C�i����
                        byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                        // ���l�}�X�^�ǂݍ���(���[�J��DB)
                        status = this._iNoteGuidBdDB.ReadHeader(ref parabyte, 0);
                        if (status == 0)
                        {
                            // XML�̓ǂݍ��� 
                            noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                            // �N���X�������o�R�s�[
                            noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                        }
                    }
                    // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
                // -- DEL 2010/05/25 ---------------------->>>
                //}
                //else	// �I�t���C�����̓L���b�V������擾
                //{
                //    status = ReadStaticMemory(out noteGuidHd, noteGuideDivCode);
                //}
                // -- DEL 2010/05/25 ----------------------<<<

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                noteGuidHd = null;
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }

        #region [�폜]
        // 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u�����[�J��DB�ǂݍ��ݏ���
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <returns>���l�K�C�h�i�w�b�_�j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�e�[�u���̃��[�J��DB Read�����ł��B</br>
        /// <br>Programmer : �ђJ �k��</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int ReadLocalDB(out NoteGuidHd noteGuidHd, string enterpriseCode, int noteGuideDivCode)
        {
            try
            {
                int status = 0;

                // �I�����C�����̓����[�g�擾
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    noteGuidHd = null;
                    NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
                    noteGuidHdWork.EnterpriseCode = enterpriseCode;
                    noteGuidHdWork.NoteGuideDivCode = noteGuideDivCode;

                    // ���l�}�X�^�ǂݍ���(���[�J��DB) 
                    status = this._noteGuidBdLcDB.ReadHeader(ref noteGuidHdWork, 0);

                    if (status == 0)
                    {
                        // �N���X�������o�R�s�[
                        noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                    }
                }
                else	// �I�t���C�����̓L���b�V������擾
                {
                    status = ReadStaticMemory(out noteGuidHd, noteGuideDivCode);
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                noteGuidHd = null;
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }
		*/
        // 2007.10.04 sasaki <<
        #endregion

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u���ǂݍ��ݏ���
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <param name="noteGuideCode">���l�K�C�h�R�[�h</param>
        /// <returns>���l�K�C�h�i�{�f�B�j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�e�[�u����Read�����ł��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public int Read(out NoteGuidBd noteGuidBd, string enterpriseCode, int noteGuideDivCode, int noteGuideCode)
        {
            try
            {
                noteGuidBd = null;
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
                noteGuidBdWork.EnterpriseCode = enterpriseCode;
                noteGuidBdWork.NoteGuideDivCode = noteGuideDivCode;
                noteGuidBdWork.NoteGuideCode = noteGuideCode;

                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// XML�֕ϊ����A������̃o�C�i����
                //byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                //
                //int status = this._iNoteGuidBdDB.ReadBody(ref parabyte, 0);
                //
                //if (status == 0)
                //{
                //    // XML�̓ǂݍ���
                //    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                //    // �N���X�������o�R�s�[
                //    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                //}
                int status = 0;
                if (_isLocalDBRead)
                {
                    // ���[�J��DB����̓Ǎ�
                    status = this._noteGuidBdLcDB.ReadBody(ref noteGuidBdWork, 0);
                    if (status == 0)
                    {
                        // �N���X�������o�R�s�[
                        noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                    }
                }
                else
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                    status = this._iNoteGuidBdDB.ReadBody(ref parabyte, 0);
                    if (status == 0)
                    {
                        // XML�̓ǂݍ���
                        noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                        // �N���X�������o�R�s�[
                        noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                    }
                }
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                noteGuidBd = null;
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }

		// 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u�����[�J��DB�ǂݍ��ݏ���
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <param name="noteGuideCode">���l�K�C�h�R�[�h</param>
        /// <returns>���l�K�C�h�i�{�f�B�j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�e�[�u���̃��[�J��DB Read�����ł��B</br>
        /// <br>Programmer : �ђJ �k��</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int ReadLocalDB(out NoteGuidBd noteGuidBd, string enterpriseCode, int noteGuideDivCode, int noteGuideCode)
        {
            try
            {
                noteGuidBd = null;
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
                noteGuidBdWork.EnterpriseCode = enterpriseCode;
                noteGuidBdWork.NoteGuideDivCode = noteGuideDivCode;
                noteGuidBdWork.NoteGuideCode = noteGuideCode;

                // ���[�J��DB����̓Ǎ�
                int status = this._noteGuidBdLcDB.ReadBody(ref noteGuidBdWork, 0);

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                noteGuidBd = null;
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }
		*/
		// 2007.10.04 sasaki <<

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u���o�^�E�X�V����
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�e�[�u���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Write(ref NoteGuidHd noteGuidHd)
        {
            //�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
            NoteGuidHdWork noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);

            int status = 0;

            try
            {
                //��������
                status = this._iNoteGuidBdDB.WriteHeader(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                    // �N���X�������o�R�s�[
                    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u���o�^�E�X�V����
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�e�[�u���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Write(ref NoteGuidBd noteGuidBd)
        {
            //�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
            NoteGuidBdWork noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);

            int status = 0;

            try
            {
                //��������
                status = this._iNoteGuidBdDB.WriteBody(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                    // �N���X�������o�R�s�[
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u���_���폜����
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̘_���폜���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int LogicalDelete(ref NoteGuidHd noteGuidHd)
        {
            try
            {
                NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

                noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                // �_���폜
                int status = this._iNoteGuidBdDB.LogicalDeleteHeader(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y
                    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));

                    // �N���X���Ń����o�R�s�[
                    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u���_���폜����
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̘_���폜���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int LogicalDelete(ref NoteGuidBd noteGuidBd)
        {
            try
            {
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

                noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                // �_���폜
                int status = this._iNoteGuidBdDB.LogicalDeleteBody(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y
                    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));

                    // �N���X���Ń����o�R�s�[
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u�������폜����
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̕����폜���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Delete(NoteGuidHd noteGuidHd)
        {
            try
            {
                NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

                noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

                // XML�ɕϊ���������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                // �����폜
                int status = this._iNoteGuidBdDB.DeleteHeader(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u�������폜����
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̕����폜���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Delete(NoteGuidBd noteGuidBd)
        {
            try
            {
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

                noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

                // XML�ɕϊ���������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                // �����폜
                int status = this._iNoteGuidBdDB.DeleteBody(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u�����������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchHeader(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidHdProc(out retList, enterpriseCode, 0);
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u�����������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchBody(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidBdProc(out retList, enterpriseCode, 0);
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u���S���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchAllHeader(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidHdProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u���S���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchAllBody(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidBdProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u���敪�w�茟�������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="noteGuidDivCode">���l�K�C�h�敪</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�敪�̔��l�K�C�h�i�{�f�B�j�̌����������s���܂��B
        ///					 �_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public int SearchDivCodeBody(out ArrayList retList, string enterpriseCode, int noteGuidDivCode)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;
            noteGuidBdWork.NoteGuideDivCode = noteGuidDivCode;

            retList = new ArrayList();
            retList.Clear();

            object paraObj = noteGuidBdWork as Object;
            object retObj;

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// ���l�K�C�h�i�{�f�B�j����
            //int status = this._iNoteGuidBdDB.SearchGuideDivCode(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        ArrayList noteGuidBdWorkList = retObj as ArrayList;
            //
            //        for (int i = 0; i < noteGuidBdWorkList.Count; i++)
            //        {
            //            // �N���X�������o�R�s�[
            //            retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
            //        }
            //
            //        if (retList.Count == 0)
            //        {
            //            status = 9;
            //        }
            //    }
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                // ���l�K�C�h�i�{�f�B�j����
                List<NoteGuidBdWork> workList = new List<NoteGuidBdWork>();
                List<NoteGuidBdWork> paraList = new List<NoteGuidBdWork>();
                paraList.Add(noteGuidBdWork);
                status = this._noteGuidBdLcDB.SearchGuideDivCode(out workList, paraList, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (workList.Count == 0)
                        {
                            status = 9;
                        }
                    }
                }
            }
            else
            {
                // ���l�K�C�h�i�{�f�B�j����
                status = this._iNoteGuidBdDB.SearchGuideDivCode(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList noteGuidBdWorkList = retObj as ArrayList;
                        for (int i = 0; i < noteGuidBdWorkList.Count; i++)
                        {
                            // �N���X�������o�R�s�[
                            retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
                        }
                        if (retList.Count == 0)
                        {
                            status = 9;
                        }
                    }
                }
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u���_���폜��������
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̕������s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Revival(ref NoteGuidHd noteGuidHd)
        {
            try
            {
                NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

                noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

                // XML�֕ϊ���������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                // ��������
                int status = this._iNoteGuidBdDB.RevivalLogicalDeleteHeader(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y
                    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                    // �N���X�������o�R�s�[
                    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u���_���폜��������
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̕������s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Revival(ref NoteGuidBd noteGuidBd)
        {
            try
            {
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

                noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

                // XML�֕ϊ���������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                // ��������
                int status = this._iNoteGuidBdDB.RevivalLogicalDeleteBody(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y
                    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                    // �N���X�������o�R�s�[
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iNoteGuidBdDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u����������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̌����������s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        private int SearchNoteGuidHdProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
            noteGuidHdWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// �I�����C�����̓����[�g�擾
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    object paraObj = noteGuidHdWork as Object;
            //    object retObj;
            //
            //    // ���l�K�C�h�i�w�b�_�j����
            //    status = this._iNoteGuidBdDB.SearchHeader(out retObj, paraObj, 0, logicalMode);
            //
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        ArrayList noteGuidHdWorkList = retObj as ArrayList;
            //
            //        for (int i = 0; i < noteGuidHdWorkList.Count; i++)
            //        {
            //            // �N���X�������o�R�s�[
            //            retList.Add(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
            //            // ���l�K�C�h�i�w�b�_�j�N���X �� Static�]�L����
            //            CopyToStaticFromDataClass(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
            //        }
            //    }
            //}
            //else
            //{
            //    status = this.SearchStaticMemory(out retList);
            //}
            if (_isLocalDBRead)
            {
                NoteGuidHdWork paraObj = noteGuidHdWork;
                // ���l�K�C�h�i�w�b�_�j����
                List<NoteGuidHdWork> workList = new List<NoteGuidHdWork>();
                status = this._noteGuidBdLcDB.SearchHeader(out workList, noteGuidHdWork, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < workList.Count; i++)
                    {
                        // �N���X�������o�R�s�[
                        retList.Add(CopyToNoteGuidHdFromNoteGuidHdWork(workList[i]));
                        // ���l�K�C�h�i�w�b�_�j�N���X �� Static�]�L����
                        CopyToStaticFromDataClass(CopyToNoteGuidHdFromNoteGuidHdWork(workList[i]));
                    }
                }
            }
            else
            {
                // -- DEL 2010/05/25 ------------------->>>
                // �I�����C�����̓����[�g�擾
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ------------------->>>
                    object paraObj = noteGuidHdWork as Object;
                    object retObj;

                    // ���l�K�C�h�i�w�b�_�j����
                    status = this._iNoteGuidBdDB.SearchHeader(out retObj, paraObj, 0, logicalMode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList noteGuidHdWorkList = retObj as ArrayList;

                        for (int i = 0; i < noteGuidHdWorkList.Count; i++)
                        {
                            // �N���X�������o�R�s�[
                            retList.Add(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
                            // ���l�K�C�h�i�w�b�_�j�N���X �� Static�]�L����
                            CopyToStaticFromDataClass(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
                        }
                    }
                // -- DEL 2010/05/25 ------------------->>>
                //}
                //else
                //{
                //    status = this.SearchStaticMemory(out retList);
                //}
                // -- DEL 2010/05/25 ------------------->>>
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u����������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̌����������s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        private int SearchNoteGuidBdProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //object paraObj = noteGuidBdWork as Object;
            //object retObj;
            //
            //// ���l�K�C�h�i�{�f�B�j����
            //int status = this._iNoteGuidBdDB.SearchBody(out retObj, paraObj, 0, logicalMode);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    ArrayList noteGuidBdWorkList = retObj as ArrayList;
            //
            //    for (int i = 0; i < noteGuidBdWorkList.Count; i++)
            //    {
            //        // �N���X�������o�R�s�[
            //        retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
            //    }
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                // ���l�K�C�h�i�{�f�B�j����
                List<NoteGuidBdWork> workList = new List<NoteGuidBdWork>();
                status = this._noteGuidBdLcDB.SearchBody(out workList, noteGuidBdWork, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < workList.Count; i++)
                    {
                        // �N���X�������o�R�s�[
                        retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork(workList[i]));
                    }
                }
            }
            else
            {
                object paraObj = noteGuidBdWork as Object;
                object retObj;
                // ���l�K�C�h�i�{�f�B�j����
                status = this._iNoteGuidBdDB.SearchBody(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList noteGuidBdWorkList = retObj as ArrayList;
                    for (int i = 0; i < noteGuidBdWorkList.Count; i++)
                    {
                        // �N���X�������o�R�s�[
                        retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
                    }
                }
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�e�[�u�����������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public int SearchHeaderDS(ref DataSet ds, string enterpriseCode)
        {
            NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
            noteGuidHdWork.EnterpriseCode = enterpriseCode;

            // �T�[�`�p���X�g������
            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = noteGuidHdWork;
            object retobj = null;

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
            //int status = this._iNoteGuidBdDB.SearchHeader(out retobj, paraobj, 0, 0);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    paraList = retobj as ArrayList;
            //
            //    NoteGuidHdWork[] Byte_noteGuidHdWork = new NoteGuidHdWork[paraList.Count];
            //    for (int ix = 0; ix < paraList.Count; ix++)
            //    {
            //        Byte_noteGuidHdWork[ix] = (NoteGuidHdWork)paraList[ix];
            //    }
            //
            //    // XML�֕ϊ����A������̃o�C�i����
            //    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidHdWork);
            //    XmlByteSerializer.ReadXml(ref ds, retbyte);
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                NoteGuidHdWork paraObj = noteGuidHdWork;
                // ���l�K�C�h�i�w�b�_�j����
                List<NoteGuidHdWork> workList = new List<NoteGuidHdWork>();
                workList.Clear();
                status = this._noteGuidBdLcDB.SearchHeader(out workList, paraObj, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    NoteGuidHdWork[] Byte_noteGuidHdWork = new NoteGuidHdWork[workList.Count];
                    for (int ix = 0; ix < workList.Count; ix++)
                    {
                        Byte_noteGuidHdWork[ix] = (NoteGuidHdWork)workList[ix];
                    }
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidHdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            else
            {
                // �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
                status = this._iNoteGuidBdDB.SearchHeader(out retobj, paraobj, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = retobj as ArrayList;
                    NoteGuidHdWork[] Byte_noteGuidHdWork = new NoteGuidHdWork[paraList.Count];
                    for (int ix = 0; ix < paraList.Count; ix++)
                    {
                        Byte_noteGuidHdWork[ix] = (NoteGuidHdWork)paraList[ix];
                    }
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidHdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u�����������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public int SearchBodyDS(ref DataSet ds, string enterpriseCode)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;

            // �T�[�`�p���X�g������
            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = noteGuidBdWork;
            object retobj = null;

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
            //int status = this._iNoteGuidBdDB.SearchBody(out retobj, paraobj, 0, 0);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    paraList = retobj as ArrayList;
            //
            //    NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[paraList.Count];
            //    for (int ix = 0; ix < paraList.Count; ix++)
            //    {
            //        Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)paraList[ix];
            //    }
            //
            //    // XML�֕ϊ����A������̃o�C�i����
            //    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidBdWork);
            //    XmlByteSerializer.ReadXml(ref ds, retbyte);
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                // ���l�K�C�h�i�{�f�B�j����
                List<NoteGuidBdWork> workList = new List<NoteGuidBdWork>();
                status = this._noteGuidBdLcDB.SearchBody(out workList, noteGuidBdWork, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[workList.Count];
                    for (int ix = 0; ix < workList.Count; ix++)
                    {
                        Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)workList[ix];
                    }
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidBdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            else
            {
                // �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
                status = this._iNoteGuidBdDB.SearchBody(out retobj, paraobj, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = retobj as ArrayList;
                    NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[paraList.Count];
                    for (int ix = 0; ix < paraList.Count; ix++)
                    {
                        Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)paraList[ix];
                    }
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidBdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            return status;
        }

		// 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u�����[�J��DB���������iNoteGuidBdWork���X�g�p�j
        /// </summary>
        /// <param name="noteGuidBdWorkListResult">�擾���ʊi�[�pNoteGuidBdWork���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̃��[�J��DB�����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : �ؑ� ����</br>
        /// <br>Date       : 2007.05.21</br>
        /// </remarks>
        public int SearchBodyLocalDB(out List<NoteGuidBdWork> noteGuidBdWorkListResult, string enterpriseCode, int noteGuideDivCode)
        {
            noteGuidBdWorkListResult = new List<NoteGuidBdWork>();

            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;

            // �T�[�`�p���X�g������
            ArrayList paraList = new ArrayList();
            paraList.Clear();

            ArrayList ar = new ArrayList();

            List<NoteGuidBdWork> noteGuidBdWorkList = new List<NoteGuidBdWork>();

            // �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
            int status = this._noteGuidBdLcDB.SearchBody(out noteGuidBdWorkList, noteGuidBdWork, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[noteGuidBdWorkList.Count];
                for (int ix = 0; ix < noteGuidBdWorkList.Count; ix++)
                {
                    // ���l�K�C�h�敪����v������̂̂ݎ擾
                    if (noteGuideDivCode == noteGuidBdWorkList[ix].NoteGuideDivCode)
                    {
                        ar.Add((NoteGuidBdWork)noteGuidBdWorkList[ix]);
                        //Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)noteGuidBdWorkList[ix];
                    }
                }

                ArrayList wkList = ar.Clone() as ArrayList;
                SortedList wkSort = new SortedList();

                // --- [�S��] --- //
                // ���̂܂ܑS���Ԃ�
                foreach (NoteGuidBdWork wkNoteGuidBdWork in wkList)
                {
                    if (wkNoteGuidBdWork.LogicalDeleteCode == 0)
                    {
                        wkSort.Add(wkNoteGuidBdWork.NoteGuideDivCode.ToString("0000") + wkNoteGuidBdWork.NoteGuideCode.ToString("0000"), wkNoteGuidBdWork);
                    }
                }

                // �f�[�^�����ɖ߂�
                for (int i = 0; i < wkSort.Count; i++)
                {
                    noteGuidBdWorkListResult.Add((NoteGuidBdWork)wkSort.GetByIndex(i));
                }
            }
            return status;
        }
		*/
		// 2007.10.04 sasaki <<

		// 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// ���l�K�C�h�i�{�f�B�j�e�[�u�����[�J��DB���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j�̃��[�J��DB�����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : �ђJ �k��</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int SearchBodyLocalDB(ref DataSet ds, string enterpriseCode, int noteGuideDivCode)
        {

            List<NoteGuidBdWork> noteGuidBdWorkList;

            // ���l�K�C�h(�{�f�B)���擾
            int status = this.SearchBodyLocalDB(out noteGuidBdWorkList
                                               ,    enterpriseCode
                                               ,    noteGuideDivCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] retbyte = XmlByteSerializer.Serialize(noteGuidBdWorkList);
                XmlByteSerializer.ReadXml(ref ds, retbyte);
            }

            // �� 20070521 18322 d ���W�b�N��ύX�����׍폜
            #region ���W�b�N��ύX�����׍폜
            //NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            //noteGuidBdWork.EnterpriseCode = enterpriseCode;
            //
            //// �T�[�`�p���X�g������
            //ArrayList paraList = new ArrayList();
            //paraList.Clear();
            //
            //ArrayList ar = new ArrayList();
            //
            //List<NoteGuidBdWork> noteGuidBdWorkList = new List<NoteGuidBdWork>();
            //
            //// �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
            //int status = this._noteGuidBdLcDB.SearchBody(out noteGuidBdWorkList, noteGuidBdWork, 0, 0);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    //NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[noteGuidBdWorkList.Count];
            //    for (int ix = 0; ix < noteGuidBdWorkList.Count; ix++)
            //    {
            //        // ���l�K�C�h�敪����v������̂̂ݎ擾
            //        if (noteGuideDivCode == noteGuidBdWorkList[ix].NoteGuideDivCode)
            //        {
            //            ar.Add((NoteGuidBdWork)noteGuidBdWorkList[ix]);
            //            //Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)noteGuidBdWorkList[ix];
            //        }
            //    }
            //
            //    ArrayList wkList = ar.Clone() as ArrayList;
            //    SortedList wkSort = new SortedList();
            //
            //    // --- [�S��] --- //
            //    // ���̂܂ܑS���Ԃ�
            //    foreach (NoteGuidBdWork wkNoteGuidBdWork in wkList)
            //    {
            //        if (wkNoteGuidBdWork.LogicalDeleteCode == 0)
            //        {
            //            wkSort.Add(wkNoteGuidBdWork.NoteGuideDivCode.ToString("0000") + wkNoteGuidBdWork.NoteGuideCode.ToString("0000"), wkNoteGuidBdWork);
            //        }
            //    }
            //
            //    NoteGuidBdWork[] noteGuidBdWorks = new NoteGuidBdWork[wkSort.Count];
            //
            //    // �f�[�^�����ɖ߂�
            //    for (int i = 0; i < wkSort.Count; i++)
            //    {
            //        noteGuidBdWorks[i] = (NoteGuidBdWork)wkSort.GetByIndex(i);
            //    }
            //
            //    // XML�֕ϊ����A������̃o�C�i����
            //    byte[] retbyte = XmlByteSerializer.Serialize(noteGuidBdWorks);
            //    XmlByteSerializer.ReadXml(ref ds, retbyte);
            //}
            #endregion
            // �� 20070521 18322 d

            return status;
        }
		*/
		// 2007.10.04 sasaki <<


        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���l�K�C�h�i�w�b�_�j���[�N�N���X�˔��l�K�C�h�i�w�b�_�j�N���X�j
        /// </summary>
        /// <param name="noteGuidHdWork">���l�K�C�h�i�w�b�_�j���[�N�N���X</param>
        /// <returns>���l�K�C�h�i�w�b�_�j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j���[�N�N���X������l�K�C�h�i�w�b�_�j�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        private NoteGuidHd CopyToNoteGuidHdFromNoteGuidHdWork(NoteGuidHdWork noteGuidHdWork)
        {
            NoteGuidHd noteGuidHd = new NoteGuidHd();

            noteGuidHd.CreateDateTime = noteGuidHdWork.CreateDateTime;
            noteGuidHd.UpdateDateTime = noteGuidHdWork.UpdateDateTime;
            noteGuidHd.EnterpriseCode = noteGuidHdWork.EnterpriseCode;
            noteGuidHd.FileHeaderGuid = noteGuidHdWork.FileHeaderGuid;
            noteGuidHd.UpdEmployeeCode = noteGuidHdWork.UpdEmployeeCode;
            noteGuidHd.UpdAssemblyId1 = noteGuidHdWork.UpdAssemblyId1;
            noteGuidHd.UpdAssemblyId2 = noteGuidHdWork.UpdAssemblyId2;
            noteGuidHd.LogicalDeleteCode = noteGuidHdWork.LogicalDeleteCode;

            noteGuidHd.NoteGuideDivCode = noteGuidHdWork.NoteGuideDivCode;
            noteGuidHd.NoteGuideDivName = noteGuidHdWork.NoteGuideDivName;

            return noteGuidHd;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���l�K�C�h�i�{�f�B�j���[�N�N���X�˔��l�K�C�h�i�{�f�B�j�N���X�j
        /// </summary>
        /// <param name="noteGuidBdWork">���l�K�C�h�i�{�f�B�j���[�N�N���X</param>
        /// <returns>���l�K�C�h�i�{�f�B�j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�{�f�B�j���[�N�N���X������l�K�C�h�i�{�f�B�j�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public NoteGuidBd CopyToNoteGuidBdFromNoteGuidBdWork(NoteGuidBdWork noteGuidBdWork)
        {
            NoteGuidBd noteGuidBd = new NoteGuidBd();

            noteGuidBd.CreateDateTime = noteGuidBdWork.CreateDateTime;
            noteGuidBd.UpdateDateTime = noteGuidBdWork.UpdateDateTime;
            noteGuidBd.EnterpriseCode = noteGuidBdWork.EnterpriseCode;
            noteGuidBd.FileHeaderGuid = noteGuidBdWork.FileHeaderGuid;
            noteGuidBd.UpdEmployeeCode = noteGuidBdWork.UpdEmployeeCode;
            noteGuidBd.UpdAssemblyId1 = noteGuidBdWork.UpdAssemblyId1;
            noteGuidBd.UpdAssemblyId2 = noteGuidBdWork.UpdAssemblyId2;
            noteGuidBd.LogicalDeleteCode = noteGuidBdWork.LogicalDeleteCode;

            noteGuidBd.NoteGuideDivCode = noteGuidBdWork.NoteGuideDivCode;
            noteGuidBd.NoteGuideCode = noteGuidBdWork.NoteGuideCode;
            noteGuidBd.NoteGuideName = noteGuidBdWork.NoteGuideName;

            return noteGuidBd;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���l�K�C�h�i�w�b�_�j�N���X�˔��l�K�C�h�i�w�b�_�j���[�N�N���X�j
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�N���X</param>
        /// <returns>���l�K�C�h�i�w�b�_�j���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�N���X������l�K�C�h�i�w�b�_�j���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        private NoteGuidHdWork CopyToNoteGuidHdWorkFromNoteGuidHd(NoteGuidHd noteGuidHd)
        {
            NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

            noteGuidHdWork.CreateDateTime = noteGuidHd.CreateDateTime;
            noteGuidHdWork.UpdateDateTime = noteGuidHd.UpdateDateTime;
            noteGuidHdWork.EnterpriseCode = noteGuidHd.EnterpriseCode;
            noteGuidHdWork.FileHeaderGuid = noteGuidHd.FileHeaderGuid;
            noteGuidHdWork.UpdEmployeeCode = noteGuidHd.UpdEmployeeCode;
            noteGuidHdWork.UpdAssemblyId1 = noteGuidHd.UpdAssemblyId1;
            noteGuidHdWork.UpdAssemblyId2 = noteGuidHd.UpdAssemblyId2;
            noteGuidHdWork.LogicalDeleteCode = noteGuidHd.LogicalDeleteCode;

            noteGuidHdWork.NoteGuideDivCode = noteGuidHd.NoteGuideDivCode;
            noteGuidHdWork.NoteGuideDivName = noteGuidHd.NoteGuideDivName;

            return noteGuidHdWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���l�K�C�h�i�{�f�B�j�N���X�˔��l�K�C�h�i�{�f�B�j���[�N�N���X�j
        /// </summary>
        /// <param name="noteGuidBd">���l�K�C�h�i�{�f�B�j�N���X</param>
        /// <returns>���l�K�C�h�i�{�f�B�j���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�N���X������l�K�C�h�i�{�f�B�j���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �O�� �M�j</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        private NoteGuidBdWork CopyToNoteGuidBdWorkFromNoteGuidBd(NoteGuidBd noteGuidBd)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

            noteGuidBdWork.CreateDateTime = noteGuidBd.CreateDateTime;
            noteGuidBdWork.UpdateDateTime = noteGuidBd.UpdateDateTime;
            noteGuidBdWork.EnterpriseCode = noteGuidBd.EnterpriseCode;
            noteGuidBdWork.FileHeaderGuid = noteGuidBd.FileHeaderGuid;
            noteGuidBdWork.UpdEmployeeCode = noteGuidBd.UpdEmployeeCode;
            noteGuidBdWork.UpdAssemblyId1 = noteGuidBd.UpdAssemblyId1;
            noteGuidBdWork.UpdAssemblyId2 = noteGuidBd.UpdAssemblyId2;
            noteGuidBdWork.LogicalDeleteCode = noteGuidBd.LogicalDeleteCode;

            noteGuidBdWork.NoteGuideDivCode = noteGuidBd.NoteGuideDivCode;
            noteGuidBdWork.NoteGuideCode = noteGuidBd.NoteGuideCode;
            noteGuidBdWork.NoteGuideName = noteGuidBd.NoteGuideName;

            return noteGuidBdWork;
        }

        /// <summary>
        /// �K�C�h�Ăяo��
        /// </summary>
        /// <param name="noteGuidBd">�擾���l�K�C�h���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <returns>STATUS[0:�I�� 1:�L�����Z�� -1:�G���[]</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h(Body)��\��</br>
        /// <br>Programmer : 22033 �O��  �M�j</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        public int ExecuteGuide(out NoteGuidBd noteGuidBd, string enterpriseCode, int noteGuideDivCode)
        {
            int status = -1;
            noteGuidBd = new NoteGuidBd();

            TableGuideParent tblGuid = new TableGuideParent("NOTEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable outObj = new Hashtable();
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("NoteGuideDivCode", noteGuideDivCode);

            if (tblGuid.Execute(0, inObj, ref outObj))
            {
                object noteGuidBdObj = (object)new NoteGuidBd();
                TableGuideParent.HashTableToClassProperty(outObj, ref noteGuidBdObj);
                noteGuidBd = (NoteGuidBd)noteGuidBdObj;
                status = 0;
            }
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �K�C�h�\���f�[�^�擾
        /// </summary>
        /// <param name="noteGdBdList">�K�C�h�\���f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�ɕ\������f�[�^������</br>
        /// <br>Programmer : 22033 �O��  �M�j</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        private int SearchGuideList(out SortedList noteGdBdList, string enterpriseCode, int noteGuideDivCode)
        {
            int status = 0;
            noteGdBdList = new SortedList();

            // Buffer�������ꍇ
            if ((_guidBuff_NoteGdBd == null) ||
                (_guidBuff_NoteGdBd.Count == 0))
            {
                // �K�C�h�f�[�^�擾
                status = GetNoteGdBdDataBuffer(enterpriseCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }

            // �\���f�[�^�ݒ�
            foreach (NoteGuidBd noteGuidBd in _guidBuff_NoteGdBd.Values)
            {
                if (noteGuidBd.NoteGuideDivCode == noteGuideDivCode)
                    // ���X�g�Ƀf�[�^��ǉ�
                    noteGdBdList.Add(noteGuidBd.NoteGuideCode, noteGuidBd);
            }
            return status;
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Ǎ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�f�[�^�o�b�t�@�ɔ��l�K�C�h�f�[�^��Ǎ���</br>
        /// <br>Programmer : 22033 �O��  �M�j</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        private int GetNoteGdBdDataBuffer(string enterpriseCode)
        {
            if (_guidBuff_NoteGdBd == null)
            {
                _guidBuff_NoteGdBd = new Hashtable();
            }
            _guidBuff_NoteGdBd.Clear();

            ArrayList noteGdBdList;
            int status = SearchBody(out noteGdBdList, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string hashKey;
                foreach (NoteGuidBd noteGuidBd in noteGdBdList)
                {
                    hashKey = noteGuidBd.NoteGuideDivCode.ToString() + "_" + noteGuidBd.NoteGuideCode.ToString();
                    _guidBuff_NoteGdBd.Add(hashKey, noteGuidBd);
                }
            }
            return status;
        }

        #region IGeneralGuideData �����o
        /// <summary>
        /// �K�C�h�\���f�[�^�擾
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <param name="inParm">����</param>
        /// <param name="guideList">�\���f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�ɕ\������f�[�^���擾����</br>
        /// <br>Programmer : 22033 �O��  �M�j</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = 0;

            // �������擾
            // ��ƃR�[�h
            string enterpriseCode = "";
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            else
            {
                // ���肦�Ȃ��̂ŃG���[
                status = -1;
                return status;
            }

            // ���l�K�C�h�敪
            int noteGuideDivCode = 0;
            if (inParm.ContainsKey("NoteGuideDivCode"))
            {
                noteGuideDivCode = TStrConv.StrToIntDef(inParm["NoteGuideDivCode"].ToString(), 0);
            }

			// 2007.10.04 sasaki >>
			/*
            // ���l�K�C�h�f�[�^�擾(���[�J��DB����̎擾�ɕύX) iitani c
            //status = SearchGuideList(out sortList, enterpriseCode, noteGuideDivCode);
            status = SearchBodyLocalDB(ref guideList, enterpriseCode, noteGuideDivCode);

            // iitani c
            //if (status == 0)
            //{
            //    NoteGuidBd[] noteGuidBds = new NoteGuidBd[sortList.Count];

            //    foreach (NoteGuidBd	noteGuidBd in sortList.Values)
            //    {
            //        byte[] retByte = XmlByteSerializer.Serialize(noteGuidBd);
            //        XmlByteSerializer.ReadXml(ref guideList,retByte);
            //    }
            //}
			*/

            _guidBuff_NoteGdBd = null;

			// �T�[�o�[�f�[�^�擾
			SortedList sortList;
			status = SearchGuideList(out sortList, enterpriseCode, noteGuideDivCode);

			if (status == 0)
			{
				NoteGuidBd[] noteGuidBds = new NoteGuidBd[sortList.Count];

				foreach (NoteGuidBd noteGuidBd in sortList.Values)
				{
					byte[] retByte = XmlByteSerializer.Serialize(noteGuidBd);
					XmlByteSerializer.ReadXml(ref guideList, retByte);
				}
			}
			// 2007.10.04 sasaki <<
			switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j�N���X �� UI�N���X�ϊ�����
        /// </summary>
        /// <param name="noteGuidHd">���l�K�C�h�i�w�b�_�j�N���X</param>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�N���X��Static�������ɕێ����܂��B</br>
        /// <br>Programer  : 22033  �O��  �M�j</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private void CopyToStaticFromDataClass(NoteGuidHd noteGuidHd)
        {
            // --- HashKey : �敪�R�[�h --- //

            NoteGuidHd wkNoteGuidHd = new NoteGuidHd();

            wkNoteGuidHd.CreateDateTime = noteGuidHd.CreateDateTime;
            wkNoteGuidHd.UpdateDateTime = noteGuidHd.UpdateDateTime;
            wkNoteGuidHd.LogicalDeleteCode = noteGuidHd.LogicalDeleteCode;

            wkNoteGuidHd.NoteGuideDivCode = noteGuidHd.NoteGuideDivCode;
            wkNoteGuidHd.NoteGuideDivName = noteGuidHd.NoteGuideDivName;

            _noteGdHdTable_Stc[wkNoteGuidHd.NoteGuideDivCode] = wkNoteGuidHd;
        }

        /// <summary>
        /// ���l�K�C�h�i�w�b�_�j���[�J�[�N���X �� UI�N���X�ϊ� �{ Static�W�J����
        /// </summary>
        /// <param name="noteGuidHdWork">���l�K�C�h�i�w�b�_�j���[�J�[�N���X</param>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�i�w�b�_�j�N���X��Static�������ɕێ����܂��B</br>
        /// <br>Programer  : 22033  �O��  �M�j</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private void CopyToStaticFromWork(NoteGuidHdWork noteGuidHdWork)
        {
            // --- HashKey : �敪�R�[�h --- //

            NoteGuidHd wkNoteGuidHd = new NoteGuidHd();

            wkNoteGuidHd.CreateDateTime = noteGuidHdWork.CreateDateTime;
            wkNoteGuidHd.UpdateDateTime = noteGuidHdWork.UpdateDateTime;
            wkNoteGuidHd.FileHeaderGuid = noteGuidHdWork.FileHeaderGuid;
            wkNoteGuidHd.LogicalDeleteCode = noteGuidHdWork.LogicalDeleteCode;

            wkNoteGuidHd.NoteGuideDivCode = noteGuidHdWork.NoteGuideDivCode;	// ���l�K�C�h�敪�R�[�h
            wkNoteGuidHd.NoteGuideDivName = noteGuidHdWork.NoteGuideDivName;	// ���l�K�C�h�敪����

            _noteGdHdTable_Stc[wkNoteGuidHd.NoteGuideDivCode] = wkNoteGuidHd;
        }

        /// <summary>
        /// ���[�J���t�@�C���Ǎ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
        /// <br>Programer  : 22033  �O��  �M�j</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // KeyList�ݒ�
            string[] noteGdHdKeys = new string[1];
            noteGdHdKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ���[�J���t�@�C���Ǎ��ݏ���
            object wkObj = offlineDataSerializer.DeSerialize(this.ToString(), noteGdHdKeys);
            // ArrayList�ɃZ�b�g
            ArrayList wkList = wkObj as ArrayList;

            if ((wkList != null) &&
                (wkList.Count != 0))
            {
                foreach (NoteGuidHdWork noteGuidHdWork in wkList)
                {
                    // ���l�K�C�h�i�w�b�_�j���[�J�[�N���X �� Static�ϊ�����
                    CopyToStaticFromWork(noteGuidHdWork);
                }
            }
        }
        #endregion
    }
}