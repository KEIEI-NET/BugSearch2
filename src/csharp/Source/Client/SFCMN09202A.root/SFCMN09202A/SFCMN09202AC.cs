using System;
using System.Collections;
using System.Data;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

using Broadleaf.Application.Controller.Other;
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �v�����^�Ǘ��e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �v�����^�Ǘ��e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 97606 ���@�]���q</br>
	/// <br>Date       : 2005.03.22</br>
	/// <br>Update Note: 2005.11.11 22011 �����@���l</br>
	/// <br>           : O,D�����Ή�</br>
	/// <br>Update Note: 2005.12.02 22011 �����@���l</br>
	/// <br>           : O,D�����Ή�</br>
	/// <br>Update Note: 2005.12.03 22011 �����@���l</br>
	/// <br>           : O,G���Q�Ƃ���O���B�i���[�J�������ɍs���悤�ɂ���Ή��ł��B�j</br>
	/// <br>Update Note: 2005.12.03 23003 �|�c�@�܂���</br>
	/// <br>			 �E�e�}�X�^���f�����Ή�</br>
    /// <br>Update Note: 2006.09.05 22011 �����@���l</br>
    /// <br>			 �E�������Ή�(ReadStaticMemory���\�b�h�ǉ�)</br>
    /// <br>Update Note: 2006.09.13 22011 �����@���l</br>
    /// <br>			 �EXML���[�J���ۑ��Ή�</br>
    /// <br>               XML�̊i�[�f�B���N�g�����ς�����̂ŁA�܂��V�f�B���N�g�����T�[�`���ăt�@�C�����Ȃ����</br>
    /// <br>               ���f�B���N�g��(�J�����g)���T�[�`���ɍs���d�l�ł��B</br>
    /// <br>Update Note: 2022.04.25 �c���@����</br>
    /// <br>			 11870080-00�@�d�q����2�Ή��i�[�i��PDF�o�͑Ή��j</br>
    /// </remarks>
	public class PrtManageAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		/// <summary>�w�l�k�t�@�C����</summary>
		private string _fileName;
        //2006.09.13 Kashihara Add -------------
        /// <summary>�w�l�k�t�@�C���p�X</summary>
        private string _filePath;
        //2006.09.13 Kashihara Add -------------

		/// <summary>�f�[�^�o�b�t�@</summary>
		private static ArrayList _buff_PrtManage = null;
		private static ArrayList _logicalBuff_PrtManage = null;

        // add 2022.04.25 11870080-00�@�d�q����2���Ή� >>>>>
        const string processNameSalesSlip = "MAHNB01001U";
        const string processNameCustElec = "PMKAU04000U";
        const string processNameBLPAutoReply = "PMSCM00005U";
        eBooksOutputSetting _eBooksPDFPrinterSetting;
        private enum eBookOperationApplication
        {
            APPLICATION_SALESSLIP = 1,          //����`�[����
            APPLICATION_CUSTOMERELECNOTE = 2,   //���Ӑ�d�q����
            APPLICATION_BLPAUTOREPLY = 4,       //BLP������
        }
        // add 2022.04.25 11870080-00�@�d�q����2���Ή� <<<<<

		/// <summary>
		/// �v�����^�Ǘ��e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public PrtManageAcs()
		{
			try
			{
				// �w�l�k�t�@�C������ݒ�
				this._fileName = "PrtManage.xml";
                //2006.09.13 Kashihara ADD---------------------
                // �w�l�k�t�@�C���p�X
                this._filePath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\PrtManage.xml";
                //2006.09.13 Kashihara ADD---------------------
            }
			catch (Exception)
			{		
			}
		}

		/// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

		/// <summary>
		/// �v�����^�Ǘ��ǂݍ��ݏ���
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="printerMngNo">�v�����^�Ǘ�No</param>
		/// <returns>�v�����^�Ǘ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ�����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Read(out PrtManage prtManage, string enterpriseCode, int printerMngNo)
		{			
			prtManage = null;

			try
			{
				int status = 0;

				// �f�[�^��r�p�p�����[�^
				PrtManage prtManagePara         = new PrtManage();
				prtManagePara.EnterpriseCode    = enterpriseCode;
				prtManagePara.PrinterMngNo      = printerMngNo;              

				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END
 
				foreach (PrtManage prtManageTemp in prtManages)
				{
					if (prtManageTemp.CompareTo(prtManagePara) == 0)
					{
						prtManage = prtManageTemp.Clone();
						break;
					}
				}

				if ((prtManages.Length == 0) || (prtManage == null))
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
		
				return status;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{				
				prtManage = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �v�����^�Ǘ��o�^�E�X�V����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ����̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref PrtManage prtManage)
		{
			ArrayList prtManageList = new ArrayList();
			prtManageList.Clear();

			// �X�e�[�^�X�� ctDB_NOT_FOUND �ɂ��Ă���
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

				for (int ix=0; ix<prtManages.Length; ix++)
				{
					// �f�[�^����H
					if (prtManages[ix].CompareTo(prtManage) == 0)
					{
						// �Ƃ肠���� GUID �������Ȃ�X�V�n�j�Ƃ��悤
						if (prtManages[ix].FileHeaderGuid.Equals(prtManage.FileHeaderGuid))
						{
							// ���ʃw�b�_��ݒ�
							prtManage.UpdateDateTime = DateTime.Now;	// �X�V����
								// ��ƃR�[�h
								// GUID
								// �X�V�]�ƈ��R�[�h
								// �X�V�A�Z���u��ID1
								// �X�V�A�Z���u��ID2
							// �X�V�f�[�^���R���N�V�����ɒǉ�
							prtManageList.Add(prtManage);
							// �X�e�[�^�X�� ctDB_NORMAL �ɂ���
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
						prtManageList.Add(prtManages[ix]);		
					}
				}

				// �d���f�[�^���Ȃ�������
				if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
				{
					// ���ʃw�b�_��ݒ�
					prtManage.CreateDateTime = DateTime.Now;	// �쐬����
					prtManage.UpdateDateTime = DateTime.Now;	// �X�V����
					// ��ƃR�[�h
					prtManage.FileHeaderGuid = System.Guid.NewGuid();	// GUID
					// �X�V�]�ƈ��R�[�h
					// �X�V�A�Z���u��ID1
					// �X�V�A�Z���u��ID2
					// �ǉ��f�[�^���R���N�V�����ɒǉ�
					prtManageList.Add(prtManage);
					// �X�e�[�^�X�� ctDB_NORMAL �ɂ���
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}

				// �X�e�[�^�X���`�F�b�N
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// KEY�ŕ��ёւ���
					prtManageList.Sort();
					// �w�l�k�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
					this.ListSerialize(prtManageList, this._fileName);
				}

				// 2005.12.03 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				if(_buff_PrtManage != null)
				{
					SortedList sortList = new SortedList();

					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_buff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					// �L���b�V���ɒǉ�
					_buff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_buff_PrtManage.Clear();
					_buff_PrtManage.AddRange(sortList.Values);
				}
				//--�L���b�V���̍X�V�i�_���폜�j--//
				if(_logicalBuff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					
					// �L���b�V���ɒǉ�
					_logicalBuff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_logicalBuff_PrtManage.Clear();
					_logicalBuff_PrtManage.AddRange(sortList.Values);
				}
			}
			catch (System.IO.FileNotFoundException)
			{
				// �t�@�C�������݂��Ȃ��ꍇ�i����̂݁j�Ɉȉ��̏������s��
				// ���ʃw�b�_��ݒ�
				prtManage.CreateDateTime = DateTime.Now;	// �쐬����
				prtManage.UpdateDateTime = DateTime.Now;	// �X�V����
					// ��ƃR�[�h
				prtManage.FileHeaderGuid = System.Guid.NewGuid();	// GUID
					// �X�V�]�ƈ��R�[�h
					// �X�V�A�Z���u��ID1
					// �X�V�A�Z���u��ID2
				// �ǉ��f�[�^���R���N�V�����ɒǉ�
				prtManageList.Add(prtManage);
				// �w�l�k�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				this.ListSerialize(prtManageList, this._fileName);
				// �X�e�[�^�X�� ctDB_NORMAL �ɂ���
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception)
			{
				// �G���[�I
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �v�����^�Ǘ�List�V���A���C�Y����
		/// </summary>
		/// <param name="prtManageList">�V���A���C�Y�Ώۃv�����^�Ǘ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void ListSerialize(ArrayList prtManageList, string fileName)
		{
			// ArrayList����z��𐶐�
			PrtManage[] prtManages = (PrtManage[])prtManageList.ToArray(typeof(PrtManage));
			// �v�����^�Ǘ��N���X���V���A���C�Y
			//2006.09.13 ---------------------------- Kashihara START
            //2006.09.13 DEL XmlByteSerializer.Serialize(prtManages,fileName);
            //�i�[�f�B���N�g�����Ȃ���΍쐬
            if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData) == false)
            {
                System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }

            UserSettingController.SerializeUserSetting(prtManages, _filePath);
            //2006.09.13 ---------------------------- Kashihara END
            
		}

        //2006.09.13 -------------------------------- Kashihara START
        /// <summary>
        /// XML����v�����^�ݒ�N���X�փf�V���A���C�Y���܂�
        /// </summary>
        /// <returns>�v�����^�ݒ�z��</returns>
        private PrtManage[] HybridXmlDeserialize()
        {
            //�V�p�X�Ƀt�@�C�������邩�`�F�b�N
            if (System.IO.File.Exists(_filePath))
            {
                //�V�t�@�C��������ΐV���W�b�N���g�p
                return (PrtManage[])UserSettingController.DeserializeUserSetting(this._filePath, typeof(PrtManage[]));
            }
            else
            {
                //�V�t�@�C�����Ȃ��Ƃ��͋����W�b�N
                return (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
            }
        }
        //2006.09.13 -------------------------------- Kashihara End

		/// <summary>
		/// �v�����^�Ǘ��_���폜����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ����̘_���폜���s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int LogicalDelete(ref PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();
				prtManageList.Clear();

				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END
                
                for (int ix=0; ix<prtManages.Length; ix++)
				{
					// �Ώۃf�[�^�Ȃ�_���폜�敪�𗧂ĂăR���N�V�����ɒǉ�
					if (prtManages[ix].CompareTo(prtManage) == 0)
					{
						prtManage.LogicalDeleteCode = 1;
						prtManageList.Add(prtManage);
					} 
					else
					{
						prtManageList.Add(prtManages[ix]);
					}
				}
				// �w�l�k�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				this.ListSerialize(prtManageList, this._fileName);
				//--�L���b�V������폜--//
				if(_buff_PrtManage != null)
				{
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_buff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
				}

				//--�L���b�V���̍X�V�i�_���폜�j--//
				if(_logicalBuff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					// �_���폜�敪��_���폜�ɂ���
					prtManage.LogicalDeleteCode = 1;
					// �L���b�V���ɒǉ�
					_logicalBuff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_logicalBuff_PrtManage.Clear();
					_logicalBuff_PrtManage.AddRange(sortList.Values);
				}

				return status;
			}
			catch (Exception)
			{
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �v�����^�Ǘ������폜����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ����̕����폜���s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Delete(PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();
				prtManageList.Clear();

				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

				for (int ix=0; ix<prtManages.Length; ix++)
				{
					// �Ώۃf�[�^�łȂ�������R���N�V�����ɒǉ�
					if (prtManages[ix].CompareTo(prtManage) != 0)
						prtManageList.Add(prtManages[ix]);
				}
				// �w�l�k�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				this.ListSerialize(prtManageList, this._fileName);

                //�L���b�V���̍X�V
				if(_logicalBuff_PrtManage != null)
				{
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
				}

				return status;
			}
			catch (Exception)
			{
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �v�����^�Ǘ����������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ������������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			retTotalCnt = 0;
			return 0;
		}

		/// <summary>
		/// �v�����^�Ǘ����������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ������������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			retTotalCnt = 0;
			return 0;
		}

		/// <summary>
		/// �v�����^�Ǘ��S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/// <summary>
		/// �v�����^�Ǘ����������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/// <summary>
		/// �����w��v�����^�Ǘ����������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevPrtManage��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevPrtManage">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ăv�����^�Ǘ��̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PrtManage prevPrtManage)
		{			
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevPrtManage);			
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
		/// <remarks>
		/// <br>Note       : �������w�肵�ăv�����^�Ǘ��̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PrtManage prevPrtManage)
		{			
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,readCnt,prevPrtManage);	
		}

		/// <summary>
		/// �v�����^�Ǘ��_���폜��������
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ����̕������s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Revival(ref PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();
				prtManageList.Clear();

				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));

                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

                for (int ix=0; ix<prtManages.Length; ix++)
				{
					// �Ώۃf�[�^�Ȃ�_���폜�敪�𐳏�ɖ߂��ăR���N�V�����ɒǉ�
					if (prtManages[ix].CompareTo(prtManage) == 0)
					{
						prtManage.LogicalDeleteCode = 0;
						prtManageList.Add(prtManage);
					} 
					else
					{
						prtManageList.Add(prtManages[ix]);
					}
				}
				// �w�l�k�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				this.ListSerialize(prtManageList, this._fileName);

				//--�L���b�V���̍X�V--//
				if(_buff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					_buff_PrtManage.Add(prtManage);
					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_buff_PrtManage.Clear();
					_buff_PrtManage.AddRange(sortList.Values);
				}

				//--�L���b�V���̍X�V�i�_���폜�j--//
				if(_logicalBuff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					// ���ɃL���b�V��������΍폜
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					// �_���폜�敪��L���ɂ���
					prtManage.LogicalDeleteCode = 0;
					// �L���b�V���ɒǉ�
					_logicalBuff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_logicalBuff_PrtManage.Clear();
					_logicalBuff_PrtManage.AddRange(sortList.Values);
				}
				return status;
			}
			catch (Exception)
			{
				// �ʐM�G���[��-1��߂�
				return -1;
			}
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
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��̌����������s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// <br>Note       : 11870080-00�@�d�q����2�Ή��i�[�i��PDF�o�͑Ή��j</br>
		/// <br>Programmer : �c���@����</br>
		/// <br>Date       : 2022.04.25</br>
		/// </remarks>
		private int SearchPrtManageProc(
			out ArrayList retList,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			int readCnt,
			PrtManage prevPrtManage)
		{
			
			//���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;

			retList = new ArrayList();
			retList.Clear();

			int status = 0;
			try
			{
				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

                // �S�����[�h�H
				if (readCnt == 0) 
				{
                    // add 2022.04.25 11870080-00�@�d�q����2���Ή� >>>>>
                    System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
                    SalesSlipInputAcs _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();//���`
                    CustPrtSlipSearchAcs _customerElecNote = new CustPrtSlipSearchAcs();//���Ӑ�d�q����
                    ArrayList salesDataList = new ArrayList();
                    SlipPrinter _slipPrinter = new SlipPrinter(salesDataList);//BLP������
                    int PDFPrintMnNo = 0;//PDF���z�v�����^�Ǘ��ԍ�
                    int PDFPrintIndexNo = 0;//PDF���z�v�����^���X�g�C���f�b�N�X�ԍ�
                    int PDFPrintApplication = 0;
                    if (current.ProcessName == processNameSalesSlip ||
                        current.ProcessName == processNameCustElec ||
                        current.ProcessName == processNameBLPAutoReply)
                    {
                        //�v�����^�ݒ�ďo�A�v���P�[�V�����i���`�^���Ӑ�d�q�����j
                        PDFPrintApplication = _salesSlipInputAcs.PDFPrinterStatus_EXT | _customerElecNote.PDFPrinterStatus_EXT << 1 | _slipPrinter.PDFPrinterStatus_EXT << 2 ;
                    }
                    else
                    {
                        PDFPrintApplication = 0;
                    }
                    switch (PDFPrintApplication)
                    {
                        case (int)eBookOperationApplication.APPLICATION_SALESSLIP://���`����Ă΂�Ă���
                        case (int)eBookOperationApplication.APPLICATION_BLPAUTOREPLY://BLP�����񓚂���Ă΂�Ă���(���`�Ƃ��Ĉ���)
                            //MAHNB01001U_PDFOutputSettings.xml�̓ǂݍ���
                            PDFPrintMnNo = Int32.Parse(GetEBooksPDFPrinterManageNumber((int)eBookOperationApplication.APPLICATION_SALESSLIP));
                            break;
                        case (int)eBookOperationApplication.APPLICATION_CUSTOMERELECNOTE://���Ӑ�d�q��������Ă΂�Ă���
                            //PMKAU04001U_PDFOutputSettings.xml�̓ǂݍ���
                            PDFPrintMnNo = Int32.Parse(GetEBooksPDFPrinterManageNumber((int)eBookOperationApplication.APPLICATION_CUSTOMERELECNOTE));
                            break;
                        default:
                            PDFPrintMnNo = 0;//do as usual
                            break;

                    }
                    // add 2022.04.25 11870080-00�@�d�q����2���Ή� <<<<<

                    for (int ix = 0; ix < prtManages.Length; ix++)
					{
						// �Ǎ����ʃR���N�V�����ɒǉ�
                        // add 2022.04.25 11870080-00�@�d�q����2���Ή� >>>>>
                        //if (checkTarGetData(prtManages[ix], logicalMode)) retList.Add(prtManages[ix]);
                        if (checkTarGetData(prtManages[ix], logicalMode))
                        {
                            retList.Add(prtManages[ix]);
                            if (PDFPrintApplication != 0)
                            {
                                if (prtManages[ix].PrinterMngNo == PDFPrintMnNo)
                                {
                                    PDFPrintIndexNo = ix;
                                }
                            }
                        }
                        // add 2022.04.25 11870080-00�@�d�q����2���Ή� <<<<<
                    }
                    
                    // add 2022.04.25 11870080-00�@�d�q����2���Ή� >>>>>
                    if (PDFPrintApplication != 0)
                    {
                        retList.Insert(0, prtManages[PDFPrintIndexNo]);
                        retList.RemoveAt(PDFPrintIndexNo);
                    }
                    // add 2022.04.25 11870080-00�@�d�q����2���Ή� <<<<<
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
						for (int ix=0; ix<prtManages.Length; ix++)
						{
							// �Ǎ������ɒB�����甲����
							if (retList.Count >= readCnt)
							{
								nextData = true;	// ����v��񂩂�
								break;
							}
							// �Ǎ����ʃR���N�V�����ɒǉ�
							if (checkTarGetData(prtManages[ix], logicalMode)) retList.Add(prtManages[ix]);
						}
					}
					else
					{	// �O��f�[�^���Ȃ�

						// �O��f�[�^�̃C���f�b�N�X��������
						int prevDataIndex = -1;
						
						for (int ix=0; ix<prtManages.Length; ix++)
						{
							// �Ǎ������ɒB�����甲����
							if (retList.Count >= readCnt)
							{
								nextData = true;	// ����v��񂩂�
								break;
							}
							// �O��f�[�^������������C���f�b�N�X��ޔ����Ă���
							if (prtManages[ix].Equals(prevPrtManage) == true)
								prevDataIndex = ix;
							// �O��f�[�^�̎��̃f�[�^�ȍ~��Ǎ����ʃR���N�V�����ɒǉ�
							if ((prevDataIndex >= 0) && (ix > prevDataIndex))
								if (checkTarGetData(prtManages[ix], logicalMode)) retList.Add(prtManages[ix]);
						}
					}
				}

				// �Ǎ����ʂȂ��̏ꍇ��EOF��Ԃ�
				if (retList.Count <= 0)
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				// �G���[�I
				return -1;
			}

			// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �d�q����ݒ�擾�i����`�[���́A���Ӑ�d�q�����j
        /// </summary>
        /// <param name="type">�ďo���A�v���P�[�V����</param>
        /// <returns>�d�q����󂯓n���t�H���_�p�X</returns>
        /// <remarks> 
        /// <br>Note       : 11870080-00�@�d�q����2�Ή��i�[�i��PDF�o�͑Ή��j</br>
        /// <br>Programmer : �c���@����</br>
        /// <br>Date       : 2022.04.25</br>
        /// </remarks>
        private string GetEBooksPDFPrinterManageNumber(int type)
        {
            string sXmlfileName;
            string sCustomFoldertPath = string.Empty;
            _eBooksPDFPrinterSetting = new eBooksOutputSetting();

            switch (type)
            {
                case (int)eBookOperationApplication.APPLICATION_SALESSLIP:
                    sXmlfileName = "MAHNB01001U_PDFOutputSettings.xml";
                    break;
                case (int)eBookOperationApplication.APPLICATION_CUSTOMERELECNOTE:
                    sXmlfileName = "PMKAU04001U_PDFOutputSettings.xml";
                    break;
                default:
                    sXmlfileName = string.Empty;//for raise error.
                    break;
            }

            //  �d�q����A�g�ݒ���XML�t�@�C�����݂̔��f           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlfileName)))
            {
                try
                {
                    _eBooksPDFPrinterSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlfileName));
                    if (!string.IsNullOrEmpty(_eBooksPDFPrinterSetting.PDFPrinterNumber))
                    {
                        sCustomFoldertPath = _eBooksPDFPrinterSetting.PDFPrinterNumber;
                    }
                    else
                    {
                        sCustomFoldertPath = "0";
                    }

                }
                catch (System.InvalidOperationException)
                {
                    return sCustomFoldertPath = "0";
                }
            }
            return sCustomFoldertPath;
        }

		/// <summary>
		/// �v�����^�Ǘ����������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchPrtManageDS(ref DataSet ds,string enterpriseCode)
		{
			ArrayList prtManageList = new ArrayList();
			prtManageList.Clear();

			// �Ώۃf�[�^�`�F�b�N�p�p�����[�^
			PrtManage prtManagePara = new PrtManage();
			prtManagePara.EnterpriseCode = enterpriseCode;

			try
			{
				// �w�l�k�̓ǂݍ���
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

				// �Ώۃf�[�^���R���N�V�����ɒǉ�
				for (int ix=0; ix<prtManages.Length; ix++)
				{
					if (checkTarGetData(prtManages[ix],0)) prtManageList.Add(prtManages[ix]);
				}
				// ArrayList����z��𐶐�
				prtManages = (PrtManage[])prtManageList.ToArray(typeof(PrtManage));
				// �v�����^�Ǘ����w�l�k�i�o�C�i�����j
				byte[] buffer = XmlByteSerializer.Serialize(prtManages);
				// DataSet�ւw�l�k�f�[�^����荞��
				XmlByteSerializer.ReadXml(ref ds, buffer);

				return 0;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				// �G���[�I
				return -1;
			}
		}

		/// <summary>
		/// �Ώۃf�[�^�`�F�b�N
		/// </summary>
		/// <param name="prtManage">�Ώۃf�[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �Ώۃf�[�^�ƃp�����[�^���r���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private bool checkTarGetData(PrtManage prtManage, ConstantManagement.LogicalMode logicalMode)
		{
			if (logicalMode == ConstantManagement.LogicalMode.GetData0)
			{
				if (prtManage.LogicalDeleteCode != 0) return false;
			}
			else if (logicalMode == ConstantManagement.LogicalMode.GetData1)
			{
				if (prtManage.LogicalDeleteCode != 1) return false;
			}
			
			return true;
		}

		/// <summary>
		/// �L���b�V���擾����
		/// </summary>
		/// <param name="retList">�f�[�^�o�b�t�@</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="mode">0:�_���폜������,1:�_���폜���܂�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�o�b�t�@���擾���܂�</br>
		/// <br>Programmer : 23003 �|�c�@�܂���</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		public int GetBuff(out ArrayList retList, string enterpriseCode, int mode)
		{
			int status = 0;
			
			// �K�C�h�p�o�b�t�@�Ƀf�[�^��������΃����[�g���擾����
			if((_buff_PrtManage == null)||(_buff_PrtManage.Count == 0))
			{
				if(_buff_PrtManage == null){_buff_PrtManage = new ArrayList();}
				_buff_PrtManage.Clear();

				if(_logicalBuff_PrtManage == null){_logicalBuff_PrtManage = new ArrayList();}
				_logicalBuff_PrtManage.Clear();

				ArrayList prtManageAL = new ArrayList();
				status = SearchAll(out prtManageAL,enterpriseCode);

				foreach(PrtManage prtManage in prtManageAL)
				{
					if(prtManage.LogicalDeleteCode == 0)
					{
						_buff_PrtManage.Add(prtManage);
					}
					_logicalBuff_PrtManage.Add(prtManage);
				}
			}
			if(mode == 0)
			{
				retList = _buff_PrtManage;
			}
			else
			{
				retList = _logicalBuff_PrtManage;
			}

			return status;
		}

        /// <summary>
        /// �v�����^�Ǘ��ǂݍ��ݏ���(�L���b�V������)
        /// </summary>
        /// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printerMngNo">�v�����^�Ǘ�No</param>
        /// <returns>�v�����^�Ǘ��N���X</returns>
        /// <remarks>
        /// <br>Note       : �v�����^�Ǘ������L���b�V������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2006.09.05</br>
        /// </remarks>
        public int ReadStaticMemory(out PrtManage prtManage, string enterpriseCode, int printerMngNo)
        {
            prtManage = null;

            try
            {
                int status = 0;

                // �K�C�h�p�o�b�t�@�Ƀf�[�^���������XML���擾����
                if ((_buff_PrtManage == null) || (_buff_PrtManage.Count == 0))
                {
                    if (_buff_PrtManage == null) { _buff_PrtManage = new ArrayList(); }
                    _buff_PrtManage.Clear();

                    if (_logicalBuff_PrtManage == null) { _logicalBuff_PrtManage = new ArrayList(); }
                    _logicalBuff_PrtManage.Clear();

                    ArrayList prtManageAL = new ArrayList();
                    status = SearchAll(out prtManageAL, enterpriseCode);

                    foreach (PrtManage prtMng in prtManageAL)
                    {
                        if (prtMng.LogicalDeleteCode == 0)
                        {
                            _buff_PrtManage.Add(prtMng);
                        }
                        _logicalBuff_PrtManage.Add(prtMng);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                // �J�E���g���O���Ȃ�I��
                if (_logicalBuff_PrtManage.Count == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    foreach (PrtManage prtManageTemp in _logicalBuff_PrtManage)
                    {
                        if ((prtManageTemp.EnterpriseCode == enterpriseCode) && (prtManageTemp.PrinterMngNo == printerMngNo))
                        {
                            prtManage = prtManageTemp.Clone();
                        }
                    }
                    if (prtManage == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                return status;
            }
            catch (Exception)            
            {
                prtManage = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
	}

    /// <summary>
    /// �d�q����A�g�T�|�[�g�ݒ���
    /// </summary>
    /// <remarks> 
    /// </remarks>
    public class eBooksOutputSetting
    {
        /// <summary>
        /// �d�q����A�g�T�|�[�g�ݒ���
        /// </summary>
        public eBooksOutputSetting()
        {

        }

        /// <summary>�`�[PDF�o��</summary>
        private string _eBooksOutputMode;
        /// <summary>PDF�o�͓`�[�^�C�v</summary>
        private string _eBooksOutputSlipType;
        /// <summary>PDF�v�����^</summary>
        private string _eBooksPDFPrinter;
        /// <summary>PDF�v�����^�Ǘ��ԍ�</summary>
        private string _eBooksPDFPrinterNumber;
        /// <summary>PDF�v�����^�ҋ@����</summary>
        private string _eBooksPDFPrinterWait;


        /// <summary>�`�[PDF�o��</summary>
        public string OutPutMode
        {
            get { return _eBooksOutputMode; }
            set { _eBooksOutputMode = value; }
        }
        /// <summary>PDF�o�͓`�[�^�C�v</summary>
        public string OutputSlipType
        {
            get { return _eBooksOutputSlipType; }
            set { _eBooksOutputSlipType = value; }
        }
        /// <summary>PDF�v�����^</summary>
        public string PDFPrinter
        {
            get { return _eBooksPDFPrinter; }
            set { _eBooksPDFPrinter = value; }
        }
        /// <summary>PDF�v�����^�Ǘ��ԍ�</summary>
        public string PDFPrinterNumber
        {
            get { return _eBooksPDFPrinterNumber; }
            set { _eBooksPDFPrinterNumber = value; }
        }
        /// <summary>PDF�v�����^�ҋ@����</summary>
        public string PDFPrinterWait
        {
            get { return _eBooksPDFPrinterWait; }
            set { _eBooksPDFPrinterWait = value; }
        }
    }
}