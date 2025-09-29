//****************************************************************************//
// �V�X�e��         : �v�����^�ݒ�}�X�^�i�T�[�o�p�j
// �v���O��������   : �v�����^�ݒ�}�X�^�i�T�[�o�p�j�R���g���[��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬�iSFCMN09202A���ڐA����уA�����W�j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller.Other
{
	/// <summary>
    /// �v�����^�Ǘ��}�X�^�A�N�Z�X�N���X
	/// </summary>
	public sealed class PrtManageAcs
	{
        #region <�ݒ�t�@�C��>

        /// <summary>XML�t�@�C����</summary>
		private const string FILE_NAME = "PrtManage.xml";

        /// <summary>XML�t�@�C���p�X</summary>
        private readonly static string _filePath =Path.Combine(HomePath, FILE_NAME);
        /// <summary>XML�t�@�C���p�X���擾���܂��B</summary>
        private static string FilePath {  get { return _filePath; } }

        /// <summary>
        /// �z�[���p�X���擾���܂��B
        /// </summary>
        private static string HomePath
        {
            get { return ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData; }
        }

        #endregion // </�ݒ�t�@�C��>

        #region <�L���b�V��>

        /// <summary>�f�[�^�o�b�t�@</summary>
        private static ArrayList _prtManageBufferList;
        private static ArrayList PrtManageBufferList
        {
            get { return _prtManageBufferList; }
            set { _prtManageBufferList = value; }
        }

        private static ArrayList _logicalPrtManageBufferList;
        private static ArrayList LogicalPrtManageBufferList
        {
            get { return _logicalPrtManageBufferList; }
            set { _logicalPrtManageBufferList = value; }
        }

        #endregion // <�L���b�V��>

        #region <Constructor>

        /// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PrtManageAcs() { }

        #endregion // </Constructor>

        #region <�ǂ�>

        /// <summary>
		/// �v�����^�Ǘ��ǂݍ��ݏ���
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="printerMngNo">�v�����^�Ǘ�No</param>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <returns>�v�����^�Ǘ��N���X</returns>
		public int Read(
            string enterpriseCode,
            int printerMngNo,
            out PrtManage prtManage
        )
		{			
			prtManage = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			try
            {
                // �f�[�^��r�p�p�����[�^
                PrtManage prtManagePara = new PrtManage();
                {
                    prtManagePara.EnterpriseCode= enterpriseCode;
                    prtManagePara.PrinterMngNo  = printerMngNo;
                }
                // XML�̓ǂݍ���
                PrtManage[] prtManages = DeserializeHybridXML();
                {
                    foreach (PrtManage enmPrtManage in prtManages)
                    {
                        if (enmPrtManage.CompareTo(prtManagePara).Equals(0))
                        {
                            prtManage = enmPrtManage.Clone();
                            break;
                        }
                    }
                    if (prtManage == null || prtManages.Length.Equals(0))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                return status;
            }
			catch (FileNotFoundException ex)
			{
                Debug.WriteLine(ex.ToString());
                Debug.Assert(false, ex.ToString());

				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception ex)
			{
                Debug.WriteLine(ex.ToString());
                Debug.Assert(false, ex.ToString());

				prtManage = null;
                return -1;  // �ʐM�G���[��-1��߂�
			}
		}

        /// <summary>
        /// XML����v�����^�ݒ�N���X�փf�V���A���C�Y���܂��B
        /// </summary>
        /// <returns>�v�����^�ݒ�z��</returns>
        private static PrtManage[] DeserializeHybridXML()
        {
            // �V�p�X�Ƀt�@�C�������邩�`�F�b�N
            if (File.Exists(FilePath))
            {
                // �V�t�@�C��������ΐV���W�b�N���g�p
                return (PrtManage[])UserSettingController.DeserializeUserSetting(FilePath, typeof(PrtManage[]));
            }
            // �V�t�@�C�����Ȃ��Ƃ��͋����W�b�N
            return (PrtManage[])XmlByteSerializer.Deserialize(FILE_NAME, typeof(PrtManage[]));
        }

        #endregion // </�ǂ�>

        #region <����>

        /// <summary>
		/// �v�����^�Ǘ��o�^�E�X�V����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��N���X</param>
		/// <returns>STATUS</returns>
		public int Write(ref PrtManage prtManage)
		{
			ArrayList prtManageList = new ArrayList();

			// �X�e�[�^�X�� ctDB_NOT_FOUND �ɂ��Ă���
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				// XML�̓ǂݍ���
                PrtManage[] prtManages = DeserializeHybridXML();

				for (int i = 0; i < prtManages.Length; i++)
				{
					// �f�[�^����H
					if (prtManages[i].CompareTo(prtManage).Equals(0))
					{
						// �Ƃ肠���� GUID �������Ȃ�X�V�n�j�Ƃ��悤
						if (prtManages[i].FileHeaderGuid.Equals(prtManage.FileHeaderGuid))
						{
							// ���ʃw�b�_��ݒ�
							prtManage.UpdateDateTime = DateTime.Now;    // �X�V����
							// ��ƃR�[�h
							// GUID
							// �X�V�]�ƈ��R�[�h
							// �X�V�A�Z���u��ID1
							// �X�V�A�Z���u��ID2

                            prtManageList.Add(prtManage);   // �X�V�f�[�^���R���N�V�����ɒǉ�

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; // �X�e�[�^�X�� ctDB_NORMAL �ɂ���
						}
						else
						{
							// �d���G���[�I
							status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							break;
						}
					} 
					else
					{	// �f�[�^�Ȃ�
						// �����f�[�^���R���N�V�����ɒǉ�
						prtManageList.Add(prtManages[i]);		
					}
                }   // for (int i = 0; i < prtManages.Length; i++)

				// �d���f�[�^���Ȃ�������
				if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					// ���ʃw�b�_��ݒ�
					prtManage.CreateDateTime = DateTime.Now;            // �쐬����
					prtManage.UpdateDateTime = DateTime.Now;	        // �X�V����
					// ��ƃR�[�h
					prtManage.FileHeaderGuid = System.Guid.NewGuid();   // GUID
					// �X�V�]�ƈ��R�[�h
					// �X�V�A�Z���u��ID1
					// �X�V�A�Z���u��ID2

                    prtManageList.Add(prtManage);   // �ǉ��f�[�^���R���N�V�����ɒǉ�

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; // �X�e�[�^�X�� ctDB_NORMAL �ɂ���
				}

				// �X�e�[�^�X���`�F�b�N
				if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
				{
					// KEY�ŕ��ёւ���
					prtManageList.Sort();
					// XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
					SerializeList(prtManageList);
				}

				if(PrtManageBufferList != null)
				{
					SortedList sortList = new SortedList();

					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in PrtManageBufferList)
					{
						if(prtManagewk.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							PrtManageBufferList.Remove(prtManagewk);
							break;
						}
					}
					// �L���b�V���ɒǉ�
					PrtManageBufferList.Add(prtManage);

					foreach(PrtManage prtManagewk in  PrtManageBufferList)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					PrtManageBufferList.Clear();
					PrtManageBufferList.AddRange(sortList.Values);
				}

				//-- �L���b�V���̍X�V�i�_���폜�j--//
				if(LogicalPrtManageBufferList != null)
				{
					SortedList sortList = new SortedList();
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in  LogicalPrtManageBufferList)
					{
						if(prtManagewk.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							LogicalPrtManageBufferList.Remove(prtManagewk);
							break;
						}
					}
					
					// �L���b�V���ɒǉ�
					LogicalPrtManageBufferList.Add(prtManage);

					foreach (PrtManage prtManagewk in LogicalPrtManageBufferList)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					LogicalPrtManageBufferList.Clear();
					LogicalPrtManageBufferList.AddRange(sortList.Values);
				}
			}
			catch (FileNotFoundException)
			{
				// �t�@�C�������݂��Ȃ��ꍇ�i����̂݁j�Ɉȉ��̏������s��
				// ���ʃw�b�_��ݒ�
				prtManage.CreateDateTime = DateTime.Now;	        // �쐬����
				prtManage.UpdateDateTime = DateTime.Now;	        // �X�V����
				// ��ƃR�[�h
				prtManage.FileHeaderGuid = System.Guid.NewGuid();   // GUID
				// �X�V�]�ƈ��R�[�h
				// �X�V�A�Z���u��ID1
				// �X�V�A�Z���u��ID2

                prtManageList.Add(prtManage);   // �ǉ��f�[�^���R���N�V�����ɒǉ�
                SerializeList(prtManageList);   // XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; // �X�e�[�^�X�� ctDB_NORMAL �ɂ���
			}
			catch (Exception)
			{
                status = -1;    // �G���[�I
			}
			return status;
		}

		/// <summary>
		/// �v�����^�Ǘ�List�V���A���C�Y����
		/// </summary>
		/// <param name="prtManageList">�V���A���C�Y�Ώۃv�����^�Ǘ�List�N���X</param>
		private static void SerializeList(ArrayList prtManageList)
		{
			// ArrayList����z��𐶐�
			PrtManage[] prtManages = (PrtManage[])prtManageList.ToArray(typeof(PrtManage));

			// �v�����^�Ǘ��N���X���V���A���C�Y
            if (!Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData))
            {
                //�i�[�f�B���N�g�����Ȃ���΍쐬
                Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }
            UserSettingController.SerializeUserSetting(prtManages, FilePath);
        }

        #endregion // </����>

        #region <����>

        /// <summary>
		/// �v�����^�Ǘ��_���폜����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();

				// XML�̓ǂݍ���
                PrtManage[] prtManages = DeserializeHybridXML();
                
                for (int i = 0; i < prtManages.Length; i++)
				{
					// �Ώۃf�[�^�Ȃ�_���폜�敪�𗧂ĂăR���N�V�����ɒǉ�
					if (prtManages[i].CompareTo(prtManage).Equals(0))
					{
						prtManage.LogicalDeleteCode = 1;
						prtManageList.Add(prtManage);
					} 
					else
					{
						prtManageList.Add(prtManages[i]);
					}
				}
				// XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				SerializeList(prtManageList);

				//-- �L���b�V������폜 --//
				if(PrtManageBufferList != null)
				{
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage bufferedPrtManage in  PrtManageBufferList)
					{
						if(bufferedPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							PrtManageBufferList.Remove(bufferedPrtManage);
							break;
						}
					}
				}

				//-- �L���b�V���̍X�V�i�_���폜�j --//
				if(LogicalPrtManageBufferList != null)
				{
					SortedList sortList = new SortedList();
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage bufferedLogicalPrtManage in  LogicalPrtManageBufferList)
					{
						if(bufferedLogicalPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							LogicalPrtManageBufferList.Remove(bufferedLogicalPrtManage);
							break;
						}
					}
					// �_���폜�敪��_���폜�ɂ���
					prtManage.LogicalDeleteCode = 1;
					// �L���b�V���ɒǉ�
					LogicalPrtManageBufferList.Add(prtManage);

					foreach(PrtManage bufferedLogicalPrtManage in  LogicalPrtManageBufferList)
					{
						sortList.Add(bufferedLogicalPrtManage.PrinterMngNo, bufferedLogicalPrtManage);
					}
					LogicalPrtManageBufferList.Clear();
					LogicalPrtManageBufferList.AddRange(sortList.Values);
				}

				return status;
			}
			catch (Exception)
			{
                return -1;  // �ʐM�G���[��-1��߂�
			}
		}

		/// <summary>
		/// �v�����^�Ǘ������폜����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int Delete(PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();

				// XML�̓ǂݍ���
                PrtManage[] prtManages = DeserializeHybridXML();

				for (int i = 0; i < prtManages.Length; i++)
				{
					// �Ώۃf�[�^�łȂ�������R���N�V�����ɒǉ�
					if (!prtManages[i].CompareTo(prtManage).Equals(0)) prtManageList.Add(prtManages[i]);
				}
				// XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				SerializeList(prtManageList);

                // �L���b�V���̍X�V
				if(LogicalPrtManageBufferList != null)
				{
					foreach(PrtManage bufferedLogicalPrtManage in  LogicalPrtManageBufferList)
					{
						if(bufferedLogicalPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							LogicalPrtManageBufferList.Remove(bufferedLogicalPrtManage);
							break;
						}
					}
				}

				return status;
			}
			catch (Exception)
			{
                return -1;  // �ʐM�G���[��-1��߂�
			}
        }

        #endregion // </����>

        #region <�߂�>

        /// <summary>
        /// �v�����^�Ǘ��_���폜��������
        /// </summary>
        /// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Revival(ref PrtManage prtManage)
        {
            try
            {
                int status = 0;

                ArrayList prtManageList = new ArrayList();

                // XML�̓ǂݍ���
                PrtManage[] prtManages = DeserializeHybridXML();

                for (int i = 0; i < prtManages.Length; i++)
                {
                    // �Ώۃf�[�^�Ȃ�_���폜�敪�𐳏�ɖ߂��ăR���N�V�����ɒǉ�
                    if (prtManages[i].CompareTo(prtManage).Equals(0))
                    {
                        prtManage.LogicalDeleteCode = 0;
                        prtManageList.Add(prtManage);
                    }
                    else
                    {
                        prtManageList.Add(prtManages[i]);
                    }
                }
                // XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
                SerializeList(prtManageList);

                //-- �L���b�V���̍X�V --//
                if (PrtManageBufferList != null)
                {
                    SortedList sortList = new SortedList();
                    PrtManageBufferList.Add(prtManage);
                    foreach (PrtManage bufferedPrtManage in PrtManageBufferList)
                    {
                        sortList.Add(bufferedPrtManage.PrinterMngNo, bufferedPrtManage);
                    }
                    PrtManageBufferList.Clear();
                    PrtManageBufferList.AddRange(sortList.Values);
                }

                //-- �L���b�V���̍X�V�i�_���폜�j --//
                if (LogicalPrtManageBufferList != null)
                {
                    SortedList sortList = new SortedList();
                    // ���ɃL���b�V��������΍폜
                    foreach (PrtManage bufferedLogicalPrtManage in LogicalPrtManageBufferList)
                    {
                        if (bufferedLogicalPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
                        {
                            LogicalPrtManageBufferList.Remove(bufferedLogicalPrtManage);
                            break;
                        }
                    }
                    // �_���폜�敪��L���ɂ���
                    prtManage.LogicalDeleteCode = 0;
                    // �L���b�V���ɒǉ�
                    LogicalPrtManageBufferList.Add(prtManage);

                    foreach (PrtManage bufferedLogicalPrtManage in LogicalPrtManageBufferList)
                    {
                        sortList.Add(bufferedLogicalPrtManage.PrinterMngNo, bufferedLogicalPrtManage);
                    }
                    LogicalPrtManageBufferList.Clear();
                    LogicalPrtManageBufferList.AddRange(sortList.Values);
                }
                return status;
            }
            catch (Exception)
            {
                return -1;  // �ʐM�G���[��-1��߂�
            }
        }

        #endregion // </�߂�>

        #region <�T��>

        /// <summary>
        /// �v�����^�Ǘ����������i�_���폜�܂ށj
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>		
        /// <returns>STATUS</returns>
        public int SearchAll(string enterpriseCode, out ArrayList retList)
        {
            bool nextData = false;
            int retTotalCnt = 0;
            return SearchPrtManageProc(
                out retList,
                out retTotalCnt,
                out nextData,
                enterpriseCode,
                ConstantManagement.LogicalMode.GetData01,
                0,
                null
            );
        }

        /// <summary>
        /// �����w��v�����^�Ǘ����������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevPrtManage��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="readCnt">�Ǎ�����</param>		
        /// <param name="prevPrtManage">�O��ŏI�v�����^�Ǘ��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
        /// <returns>STATUS</returns>
        public int SearchSpecificationAll(
            out ArrayList retList,
            out int retTotalCnt,
            out bool nextData,
            string enterpriseCode,
            int readCnt,
            PrtManage prevPrtManage
        )
        {
            return SearchPrtManageProc(
                out retList,
                out retTotalCnt,
                out nextData,
                enterpriseCode,
                ConstantManagement.LogicalMode.GetData01,
                readCnt,
                prevPrtManage
            );
        }

        /// <summary>
        /// �v�����^�Ǘ���������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevPrtManage��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevPrtManage">�O��ŏI�v�����^�Ǘ��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        private int SearchPrtManageProc(
            out ArrayList retList,
            out int retTotalCnt,
            out bool nextData,
            string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode,
            int readCnt,
            PrtManage prevPrtManage
        )
        {
            // ���f�[�^�L��������
            nextData = false;
            // 0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();

            int status = 0;
            try
            {
                // XML�̓ǂݍ���
                PrtManage[] prtManages = DeserializeHybridXML();

                // �S�����[�h�H
                if (readCnt.Equals(0))
                {
                    for (int i = 0; i < prtManages.Length; i++)
                    {
                        // �Ǎ����ʃR���N�V�����ɒǉ�
                        if (CheckTargetData(prtManages[i], logicalMode)) retList.Add(prtManages[i]);
                    }
                    // �Ǎ��Ώۃf�[�^��������ArrayList�̌���
                    retTotalCnt = retList.Count;
                }
                else
                {	// �Ǎ������w�胊�[�h

                    // �Ǎ��Ώۃf�[�^���������z��v�f��
                    retTotalCnt = prtManages.Length;
                    // �O��f�[�^���Ȃ��H
                    if (prevPrtManage == null)
                    {
                        for (int i = 0; i < prtManages.Length; i++)
                        {
                            // �Ǎ������ɒB�����甲����
                            if (retList.Count >= readCnt)
                            {
                                nextData = true;	// ����v��񂩂�
                                break;
                            }
                            // �Ǎ����ʃR���N�V�����ɒǉ�
                            if (CheckTargetData(prtManages[i], logicalMode)) retList.Add(prtManages[i]);
                        }
                    }
                    else
                    {	// �O��f�[�^���Ȃ�

                        // �O��f�[�^�̃C���f�b�N�X��������
                        int prevDataIndex = -1;

                        for (int i = 0; i < prtManages.Length; i++)
                        {
                            // �Ǎ������ɒB�����甲����
                            if (retList.Count >= readCnt)
                            {
                                nextData = true;	// ����v��񂩂�
                                break;
                            }
                            // �O��f�[�^������������C���f�b�N�X��ޔ����Ă���
                            if (prtManages[i].Equals(prevPrtManage) == true)
                                prevDataIndex = i;
                            // �O��f�[�^�̎��̃f�[�^�ȍ~��Ǎ����ʃR���N�V�����ɒǉ�
                            if ((prevDataIndex >= 0) && (i > prevDataIndex))
                            {
                                if (CheckTargetData(prtManages[i], logicalMode)) retList.Add(prtManages[i]);
                            }
                        }
                    }
                }

                // �Ǎ����ʂȂ��̏ꍇ��EOF��Ԃ�
                if (retList.Count <= 0) status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                return -1;  // �G���[�I
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt.Equals(0)) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// �Ώۃf�[�^�`�F�b�N
        /// </summary>
        /// <param name="prtManage">�Ώۃf�[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
        private static bool CheckTargetData(
            PrtManage prtManage,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            if (logicalMode.Equals(ConstantManagement.LogicalMode.GetData0))
            {
                if (!prtManage.LogicalDeleteCode.Equals(0)) return false;
            }
            else if (logicalMode.Equals(ConstantManagement.LogicalMode.GetData1))
            {
                if (!prtManage.LogicalDeleteCode.Equals(1)) return false;
            }
            return true;
        }

        #endregion // </�T��>

        /// <summary>
        /// �v�����^�Ǘ��}�X�^���猟�����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�v�����^�ݒ�f�[�^�̃��X�g</returns>
        public static List<PrtManage> SearchFromPrtManageMaster(string enterpriseCode)
        {
            ArrayList prtManageList = null;
            {
                PrtManageAcs clientDataAcs = new PrtManageAcs();
                {
                    int status = clientDataAcs.SearchAll(enterpriseCode, out prtManageList);
                    if (!status.Equals(0))
                    {
                        if (prtManageList == null) prtManageList = new ArrayList();
                        string msg = string.Format(
                            "�v�����^�ݒ�}�X�^�A�N�Z�X�G���[�cPrtManageAcs.SearchAll() : status = {0}",
                            status
                        );
                        Debug.WriteLine(msg);
                    }
                }
            }
            return new List<PrtManage>((PrtManage[])prtManageList.ToArray(typeof(PrtManage)));
        }

        /// <summary>
        /// �v�����^�ݒ�}�X�^�֏����݂܂��B
        /// </summary>
        /// <param name="prtManage">�v�����^�ݒ�f�[�^</param>
        /// <returns>���ʃR�[�h</returns>
        public static int WriteToPrtManageMaster(ref PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.Write(ref prtManage);
                if (!status.Equals(0))    
                {
                    string msg = string.Format(
                        "�v�����^�ݒ�}�X�^�A�N�Z�X�G���[�cPrtManageAcs.Write()�Fstatus = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }

        /// <summary>
        /// �v�����^�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="prtManage">�v�����^�ݒ�f�[�^</param>
        /// <returns>���ʃR�[�h</returns>
        public static int DeleteLogicallyFromPrtManageMaster(ref PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.LogicalDelete(ref prtManage);
                if (!status.Equals(0))
                {
                    string msg = string.Format(
                        "�v�����^�ݒ�}�X�^�A�N�Z�X�G���[�cPrtManageAcs.LogicalDelete()�Fstatus = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }

        /// <summary>
        /// �v�����^�ݒ�}�X�^�ɕ��������܂��B
        /// </summary>
        /// <param name="prtManage">�v�����^�ݒ�f�[�^</param>
        /// <returns>���ʃR�[�h</returns>
        public static int ReviveIntoPrtManageMaster(ref PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.Revival(ref prtManage);
                if (!status.Equals(0))
                {
                    string msg = string.Format(
                        "�v�����^�ݒ�}�X�^�A�N�Z�X�G���[�cPrtManageAcs.Revival()�Fstatus = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }

        /// <summary>
        /// �v�����^�ݒ�}�X�^���畨���폜���܂��B
        /// </summary>
        /// <param name="prtManage">�v�����^�ݒ�f�[�^</param>
        /// <returns>���ʃR�[�h</returns>
        public static int DeletePhysicallyFromPrtManageMaster(PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.Delete(prtManage);
                if (!status.Equals(0))
                {
                    string msg = string.Format(
                        "�v�����^�ݒ�}�X�^�A�N�Z�X�G���[�cPrtManageAcs.Delete()�Fstatus = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }
    }
}