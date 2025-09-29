# region ��using
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
#endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �ԍ��Ǘ��ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �ԍ��Ǘ��ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 22033 �O��  �M�j</br>
	/// <br>Date		: 2005.09.08</br>
	/// <br>UpDateNote	: 2006.08.30 22033 �O�� �M�j</br>
	/// <br>			: �ESearch�i�ԍ��^�C�v�Ǘ��擾�p�j��static�Ή�</br>
    /// <br>Update Note : 2007.05.23 980023 �ђJ �k��</br>
    /// <br>            : �E���_���̎擾��������[�g�ɏC��</br>
    /// </remarks>
	public class NoMngSetAcs
	{
		# region �����񂷂Ƃ炭��
		/// <summary>
		/// �ԍ��Ǘ��ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public NoMngSetAcs()
		{
			//---���_��񕔕i�A�N�Z�X�N���X�̃C���X�^���X��---//
            // ----- iitani c ----- start 2007.05.23
            //this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs = new SecInfoAcs(1);   // searchMode(0: 1:)
            // ----- iitani c ----- end 2007.05.23

			if (_noTypeMngArray == null)
			{
				_noTypeMngArray = new ArrayList();
			}

			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iNoMngSetDB = (INoMngSetDB)MediationNoMngSetDB.GetNoMngSetDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iNoMngSetDB = null;
			}
		}
		# endregion

		# region ��Private Members
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private INoMngSetDB _iNoMngSetDB = null;
		/// <summary>���_���擾���i</summary>
		private SecInfoAcs _secInfoAcs = null;
		/// <summary>�ԍ��^�C�v�Ǘ�static</summary>
		private static ArrayList _noTypeMngArray;
		# endregion

		# region ��Public Methods
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iNoMngSetDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="noCode">�ԍ��R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Read(out NoMngSet noMngSet, string enterpriseCode, string sectionCode, int noCode)
		{			
			try
			{
				noMngSet = null;
				NoMngSetWork noMngSetWork	= new NoMngSetWork();
				noMngSetWork.EnterpriseCode = enterpriseCode;
				noMngSetWork.SectionCode	= sectionCode;
				noMngSetWork.NoCode			= noCode;

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);

				// �ԍ��Ǘ��ݒ�ǂݍ���
				int status = this._iNoMngSetDB.ReadNoMngSet(ref parabyte,0);

				if (status == 0)
				{
					// XML�̓ǂݍ���
					noMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));
					// �N���X�������o�R�s�[
					noMngSet = CopyToNoMngSetFromNoMngSetWork(noMngSetWork);
				}
				
				return status;
			}
			catch (Exception)
			{				
				// �ʐM�G���[��-1��߂�
				noMngSet = null;
				
				// �I�t���C������null���Z�b�g
				this._iNoMngSetDB = null;
				return -1;
			}
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="noMngSetList">�ԍ��Ǘ��ݒ�N���XList</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ���̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Write(ref ArrayList noMngSetList)
		{
			ArrayList retList = new ArrayList();
			NoMngSetWork noMngSetWork;
			NoMngSet noMngSet;

			foreach (NoMngSet noMngSetWk in noMngSetList)
			{
				// �ԍ��Ǘ��ݒ�N���X����ԍ��Ǘ��ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
				noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSetWk);
				retList.Add(noMngSetWork);
			}

			Object retObj = retList as Object;
			
			int status = 0;

			try
			{
				// �ԍ��Ǘ��ݒ菑������				 
				status = this._iNoMngSetDB.WriteNoMngSet(ref retObj);
				
				if (status == 0)
				{
					retList = retObj as ArrayList;
					noMngSetList.Clear();
					
					foreach (NoMngSetWork wkNoMngSetWork in retList)
					{
						// �ԍ��Ǘ��ݒ胏�[�J�[�N���X����ԍ��Ǘ��ݒ�N���X�Ƀ����o�R�s�[
						noMngSet = CopyToNoMngSetFromNoMngSetWork(wkNoMngSetWork);
						noMngSetList.Add(noMngSet);
					}
				}
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iNoMngSetDB = null;
				// �ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�_���폜����
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ���̘_���폜���s���܂��B(������)</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int LogicalDelete(ref NoMngSet noMngSet)
		{
			try
			{
				NoMngSetWork noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);
				// �ԍ��Ǘ��ݒ�_���폜
				int status = this._iNoMngSetDB.LogicalDeleteNoTypeMng(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���Ĕԍ��Ǘ��ݒ胏�[�N�N���X���f�V���A���C�Y����
					noMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoMngSetWork));
					// �N���X�������o�R�s�[
					noMngSet = CopyToNoMngSetFromNoMngSetWork(noMngSetWork);
				}

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iNoMngSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}

		}

		/// <summary>
		/// �ۓK�Ɖ��t��Ǘ������폜����
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ���̕����폜���s���܂��B(������)</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Delete(NoMngSet noMngSet)
		{
			try
			{
				NoMngSetWork noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);
				// �ԍ��Ǘ��ݒ蕨���폜
				int status = this._iNoMngSetDB.DeleteNoTypeMng(parabyte);

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iNoMngSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ� �S���������i�_���폜�����j
		/// </summary>
		/// <param name="retNoTypeMngList">�ԍ��^�C�v�Ǘ��R���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��^�C�v�Ǘ��̑S�����������s���܂��B
		///					 �_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.11.29</br>
		/// </remarks>
		public int Search(out ArrayList retNoTypeMngList, string enterpriseCode)
		{
			return SearchProc(out retNoTypeMngList, enterpriseCode, 0);			
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�E�ԍ��^�C�v�Ǘ� �S���������i�_���폜�����j
		/// </summary>
		/// <param name="retNoMngSetList">�ԍ��ݒ�R���N�V����</param>
		/// <param name="retNoTypeMngList">�ԍ��^�C�v�Ǘ��R���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�Ɣԍ��^�C�v�Ǘ��̑S�����������s���܂��B
		///					 �_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Search(out ArrayList retNoMngSetList, out ArrayList retNoTypeMngList, string enterpriseCode)
		{
			return SearchProc(out retNoMngSetList, out retNoTypeMngList, enterpriseCode, 0);			
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�E�ԍ��^�C�v�Ǘ� �S���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retNoMngSetList">�ԍ��ݒ�R���N�V����</param>
		/// <param name="retNoTypeMngList">�ԍ��^�C�v�Ǘ��R���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�Ɣԍ��^�C�v�Ǘ��̑S�����������s���܂��B
		///					 �_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int SearchAll(out ArrayList retNoMngSetList, out ArrayList retNoTypeMngList, string enterpriseCode)
		{
			return SearchProc(out retNoMngSetList, out retNoTypeMngList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ藝�_���폜��������
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ���̕������s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Revival(ref NoMngSet noMngSet)
		{
			try
			{
				NoMngSetWork noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);
				// ��������
				int status = this._iNoMngSetDB.RevivalLogicalDeleteNoTypeMng(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���Ĕԍ��Ǘ��ݒ胏�[�N�N���X���f�V���A���C�Y����
					noMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoMngSetWork));
					// �N���X�������o�R�s�[
					noMngSet = CopyToNoMngSetFromNoMngSetWork(noMngSetWork);
				}

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iNoMngSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}
		# endregion

		# region ��Private Methods
		/// <summary>
		/// �ԍ��Ǘ��ݒ�E�ԍ��^�C�v�Ǘ� ��������
		/// </summary>
		/// <param name="retNoMngSetList">�ԍ��ݒ�R���N�V����</param>
		/// <param name="retNoTypeMngList">�ԍ��^�C�v�Ǘ��R���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private int SearchProc(out ArrayList retNoMngSetList, out ArrayList retNoTypeMngList,string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			// ��������Object
			Object retNoMngSetObj;
			Object retNoTypeMngObj;

			retNoMngSetList  = new ArrayList();
			retNoTypeMngList = new ArrayList();

			// �ԍ��Ǘ��ݒ茟��
			int status = this._iNoMngSetDB.Search(out retNoMngSetObj, out retNoTypeMngObj, enterpriseCode, 1, logicalMode);

			if ((status == 0) || (status == 9))
			{
				ArrayList wkNoMngSetList  = new ArrayList();
				ArrayList wkNoTypeMngList = new ArrayList();
				ArrayList wkNoMngSet2List  = new ArrayList();
				ArrayList wkNoTypeMng2List = new ArrayList();
				ArrayList wkNoTypeMng3List = new ArrayList();
				Hashtable noTypeMngTable  = new Hashtable();
				NoTypeMng noTypeMng;
				NoMngSet noMngSet;
		
				// �������ʂ�ArrayList�ɃL���X�g
				wkNoMngSetList  = retNoMngSetObj as ArrayList;
				wkNoTypeMngList = retNoTypeMngObj as ArrayList;

				// ���[�J�[�N���X���f�[�^�N���X�ɃL���X�g���ēǍ��݌��ʃR���N�V������Add
				// �ԍ��^�C�v�Ǘ��}�X�^
				foreach (NoTypeMngWork noTypeMngWork in wkNoTypeMngList)
				{
					retNoTypeMngList.Add(CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWork));
					
					// �u�ԍ��̔Ԕ͈́v��[0:��ƒʔԁi���_���薳���j]�ȊO�̂��̂��擾
					if (noTypeMngWork.NumberingAmbitDivCd != 0)
					{
						wkNoTypeMng2List.Add(CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWork));
					}
					// �u�ԍ��̔Ԕ͈́v��[0:��ƒʔԁi���_���薳���j]�̂��̂��擾
					else
					{
						wkNoTypeMng3List.Add(CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWork));
					}
				}

				// �����pHash�쐬
				foreach (NoTypeMng wkNoTypeMng in retNoTypeMngList)
				{
					noTypeMngTable.Add(wkNoTypeMng.NoCode, wkNoTypeMng);
				}

				// �ԍ��Ǘ��ݒ�
				foreach (NoMngSetWork noMngSetWork in wkNoMngSetList)
				{
					retNoMngSetList.Add(CopyToNoMngSetFromNoMngSetWork(noMngSetWork));

					// �u�ԍ��̔Ԕ͈́v��[0:��ƒʔԁi���_���薳���j]�ȊO�̂��̂��擾
					noTypeMng = (NoTypeMng)noTypeMngTable[noMngSetWork.NoCode];
					
					if (noTypeMng.NumberingAmbitDivCd != 0)
					{
						wkNoMngSet2List.Add(CopyToNoMngSetFromNoMngSetWork(noMngSetWork));
					}
				}

				// ���_���Ɣԍ��Ǘ��ݒ�̋��_�������������m�F
				foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
				{
					bool existFlg = false;
					for (int ix = 0; ix != wkNoMngSet2List.Count; ix++)
					{
						noMngSet = (NoMngSet)wkNoMngSet2List[ix];
						if (noMngSet.SectionCode.TrimEnd() == secInfoSet.SectionCode.TrimEnd())				
						{
							existFlg = true;
							break;
						}
					}

					if (existFlg == false)
					{
						// �ǉ����ʎ擾�p
						ArrayList noMngSetList = null;

						// ���_���ɍ��킹�ă��R�[�h��ǉ�
						int st = AddNewNoMngSetRecord(out noMngSetList, enterpriseCode, secInfoSet.SectionCode, wkNoMngSet2List, wkNoTypeMng2List, wkNoTypeMng3List);
						
						if (st == 0)
						{
							foreach (NoMngSet wkNoMngSet in noMngSetList)
							{
								retNoMngSetList.Add(wkNoMngSet.Clone());
							}
						}
					}
				}
			}

			return status;
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ� ��������
		/// </summary>
		/// <param name="retNoTypeMngList">�ԍ��^�C�v�Ǘ��R���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��^�C�v�Ǘ��̌����������s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.11.29</br>
		/// </remarks>
		private int SearchProc(out ArrayList retNoTypeMngList,string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = 0;
			
			// ��������Object
			Object retNoTypeMngObj;
			// �p�����[�^
			NoTypeMngWork noTypeMngWork = new NoTypeMngWork();
			noTypeMngWork.EnterpriseCode = enterpriseCode;
			Object paraObj = noTypeMngWork as Object;
			
			retNoTypeMngList = new ArrayList();

			// static�ɖ����ꍇ
			if (_noTypeMngArray.Count == 0)
			{
				// �ԍ��Ǘ��ݒ茟��
				status = this._iNoMngSetDB.SearchNoTypeMng(out retNoTypeMngObj, paraObj, 0, logicalMode);

				if (status == 0)
				{
					ArrayList wkNoTypeMngList = new ArrayList();

					// �������ʂ�ArrayList�ɃL���X�g
					wkNoTypeMngList = retNoTypeMngObj as ArrayList;

					// ���[�J�[�N���X���f�[�^�N���X�ɃL���X�g���ēǍ��݌��ʃR���N�V������Add
					// �ԍ��^�C�v�Ǘ��}�X�^
					foreach (NoTypeMngWork noTypeMngWorkwk in wkNoTypeMngList)
					{
						NoTypeMng noTypeMng = CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWorkwk);

						// �߂�List�փZ�b�g
						retNoTypeMngList.Add(noTypeMng);
						// static�ɕێ�
						_noTypeMngArray.Add(noTypeMng);
					}
				}
			}
			// static�ɕێ����Ă���ꍇ
			else
			{
				retNoTypeMngList = (ArrayList)_noTypeMngArray.Clone();
			}

			return status;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ԍ��Ǘ��ݒ胏�[�N�N���X�˔ԍ��Ǘ��ݒ�N���X�j
		/// </summary>
		/// <param name="noMngSetWork">�ԍ��Ǘ��ݒ胏�[�N�N���X</param>
		/// <returns>�ԍ��Ǘ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ胏�[�N�N���X����ԍ��Ǘ��ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoMngSet CopyToNoMngSetFromNoMngSetWork(NoMngSetWork noMngSetWork)
		{
			NoMngSet noMngSet = new NoMngSet();

			//���ʃw�b�_��
			noMngSet.CreateDateTime		= noMngSetWork.CreateDateTime;
			noMngSet.UpdateDateTime		= noMngSetWork.UpdateDateTime;
			noMngSet.EnterpriseCode		= noMngSetWork.EnterpriseCode;
			noMngSet.FileHeaderGuid		= noMngSetWork.FileHeaderGuid;
			noMngSet.UpdEmployeeCode	= noMngSetWork.UpdEmployeeCode;
			noMngSet.UpdAssemblyId1		= noMngSetWork.UpdAssemblyId1;
			noMngSet.UpdAssemblyId2		= noMngSetWork.UpdAssemblyId2;
			noMngSet.LogicalDeleteCode	= noMngSetWork.LogicalDeleteCode;

			noMngSet.SectionCode		= noMngSetWork.SectionCode;	
			noMngSet.NoCode				= noMngSetWork.NoCode;			
			noMngSet.NoPresentVal		= noMngSetWork.NoPresentVal;
			noMngSet.SettingStartNo		= noMngSetWork.SettingStartNo;	
			noMngSet.SettingEndNo		= noMngSetWork.SettingEndNo;	
			noMngSet.NoIncDecWidth		= noMngSetWork.NoIncDecWidth;

			return noMngSet;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ԍ��Ǘ��ݒ�N���X�˔ԍ��Ǘ��ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ胏�[�N�N���X</param>
		/// <returns>�ԍ��Ǘ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�N���X����ԍ��Ǘ��ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoMngSetWork CopyToNoMngSetWorkFromNoMngSet(NoMngSet noMngSet)
		{
			NoMngSetWork noMngSetWork = new NoMngSetWork();

			noMngSetWork.CreateDateTime	   = noMngSet.CreateDateTime;
			noMngSetWork.UpdateDateTime	   = noMngSet.UpdateDateTime;
			noMngSetWork.EnterpriseCode	   = noMngSet.EnterpriseCode;
			noMngSetWork.FileHeaderGuid	   = noMngSet.FileHeaderGuid;
			noMngSetWork.UpdEmployeeCode   = noMngSet.UpdEmployeeCode;
			noMngSetWork.UpdAssemblyId1	   = noMngSet.UpdAssemblyId1;
			noMngSetWork.UpdAssemblyId2	   = noMngSet.UpdAssemblyId2;
			noMngSetWork.LogicalDeleteCode = noMngSet.LogicalDeleteCode;

			noMngSetWork.SectionCode	   = noMngSet.SectionCode;	
			noMngSetWork.NoCode			   = noMngSet.NoCode;			
			noMngSetWork.NoPresentVal	   = noMngSet.NoPresentVal;
			noMngSetWork.SettingStartNo	   = noMngSet.SettingStartNo;
			noMngSetWork.SettingEndNo	   = noMngSet.SettingEndNo;	
			noMngSetWork.NoIncDecWidth	   = noMngSet.NoIncDecWidth;

			return noMngSetWork;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ԍ��^�C�v�Ǘ����[�N�N���X�˔ԍ��^�C�v�Ǘ��N���X�j
		/// </summary>
		/// <param name="noTypeMngWork">�ԍ��^�C�v�Ǘ����[�N�N���X</param>
		/// <returns>�ԍ��^�C�v�Ǘ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��^�C�v�Ǘ����[�N�N���X����ԍ��^�C�v�Ǘ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoTypeMng CopyToNoTypeMngFromNoTypeMngWork(NoTypeMngWork noTypeMngWork)
		{
			NoTypeMng noTypeMng = new NoTypeMng();

			//���ʃw�b�_��
			noTypeMng.CreateDateTime	  = noTypeMngWork.CreateDateTime;
			noTypeMng.UpdateDateTime	  = noTypeMngWork.UpdateDateTime;
			noTypeMng.EnterpriseCode	  = noTypeMngWork.EnterpriseCode;
			noTypeMng.FileHeaderGuid	  = noTypeMngWork.FileHeaderGuid;
			noTypeMng.UpdEmployeeCode	  = noTypeMngWork.UpdEmployeeCode;
			noTypeMng.UpdAssemblyId1	  = noTypeMngWork.UpdAssemblyId1;
			noTypeMng.UpdAssemblyId2	  = noTypeMngWork.UpdAssemblyId2;
			noTypeMng.LogicalDeleteCode   = noTypeMngWork.LogicalDeleteCode;

			noTypeMng.NoCode			  = noTypeMngWork.NoCode;			 		   	
			noTypeMng.NoName			  = noTypeMngWork.NoName;			 	       
			noTypeMng.NoItemPatternCd	  = noTypeMngWork.NoItemPatternCd;	
			noTypeMng.NoCharcterCount	  = noTypeMngWork.NoCharcterCount;	
			noTypeMng.ConsNoCharcterCount = noTypeMngWork.ConsNoCharcterCount;	
			noTypeMng.NoDispPositionDivCd = noTypeMngWork.NoDispPositionDivCd;		   	
			noTypeMng.NumberingDivCd	  = noTypeMngWork.NumberingDivCd;
			noTypeMng.NumberingTypeDivCd  = noTypeMngWork.NumberingTypeDivCd;
			noTypeMng.NumberingAmbitDivCd = noTypeMngWork.NumberingAmbitDivCd;
			noTypeMng.NoResetTimingDivCd  = noTypeMngWork.NoResetTimingDivCd;

			return noTypeMng;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ԍ��^�C�v�Ǘ��N���X�˃��[�N�N���X�ԍ��^�C�v�Ǘ��j
		/// </summary>
		/// <param name="noTypeMng">�ԍ��^�C�v�Ǘ����[�N�N���X</param>
		/// <returns>�ԍ��^�C�v�Ǘ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �N���X����Ԕԍ��^�C�v�ԍ��^�C�v�Ǘ����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoTypeMngWork CopyToNoTypeMngWorkFromNoTypeMng(NoTypeMng noTypeMng)
		{
			NoTypeMngWork noTypeMngWork = new NoTypeMngWork();

			noTypeMngWork.CreateDateTime	  = noTypeMng.CreateDateTime;
			noTypeMngWork.UpdateDateTime	  = noTypeMng.UpdateDateTime;
			noTypeMngWork.EnterpriseCode	  = noTypeMng.EnterpriseCode;
			noTypeMngWork.FileHeaderGuid	  = noTypeMng.FileHeaderGuid;
			noTypeMngWork.UpdEmployeeCode	  = noTypeMng.UpdEmployeeCode;
			noTypeMngWork.UpdAssemblyId1	  = noTypeMng.UpdAssemblyId1;
			noTypeMngWork.UpdAssemblyId2	  = noTypeMng.UpdAssemblyId2;
			noTypeMngWork.LogicalDeleteCode	  = noTypeMng.LogicalDeleteCode;

			noTypeMngWork.NoCode			  = noTypeMng.NoCode;			 		   	
			noTypeMngWork.NoName			  = noTypeMng.NoName;			 	       
			noTypeMngWork.NoItemPatternCd	  = noTypeMng.NoItemPatternCd;			 	       
			noTypeMngWork.NoCharcterCount	  = noTypeMng.NoCharcterCount;			 	       
			noTypeMngWork.ConsNoCharcterCount = noTypeMng.ConsNoCharcterCount;	
			noTypeMngWork.NoDispPositionDivCd = noTypeMng.NoDispPositionDivCd;		   	
			noTypeMngWork.NumberingDivCd	  = noTypeMng.NumberingDivCd;
			noTypeMngWork.NumberingTypeDivCd  = noTypeMng.NumberingTypeDivCd;
			noTypeMngWork.NumberingAmbitDivCd = noTypeMng.NumberingAmbitDivCd;
			noTypeMngWork.NoResetTimingDivCd  = noTypeMng.NoResetTimingDivCd;

			return noTypeMngWork;
		}
		
		/// <summary>
		/// �ԍ��Ǘ��ݒ�ǉ�����
		/// </summary>
		/// <param name="noMngSetList">�ԍ��Ǘ��ݒ�I�u�W�F�N�gLIST</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="wkNoMngSetList">�ԍ��Ǘ��ݒ�List</param>
		/// <param name="wkNoTypeSetList">�ԍ��^�C�v�Ǘ�List(���_����L�蕪)</param>
		/// <param name="wkNoTypeSet2List">�ԍ��^�C�v�Ǘ�List(���_���薳����)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ背�R�[�h��ǉ����܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.14</br>
		/// </remarks>
		private int AddNewNoMngSetRecord(out ArrayList noMngSetList, string enterpriseCode, string sectionCode, ArrayList wkNoMngSetList, ArrayList wkNoTypeSetList, ArrayList wkNoTypeSet2List)
		{
			NoTypeMng noTypeMng = new NoTypeMng();
			noMngSetList = new ArrayList();
			NoMngSet[] noMngSets = new NoMngSet[wkNoTypeSetList.Count];
			// �L�[���ڃZ�b�g
			for (int ix = 0; ix != noMngSets.Length; ix++)
			{
				noTypeMng = (NoTypeMng)wkNoTypeSetList[ix];
				noMngSets[ix] = new NoMngSet();
				noMngSets[ix].EnterpriseCode	= enterpriseCode;
				noMngSets[ix].SectionCode		= sectionCode;
				noMngSets[ix].NoCode			= noTypeMng.NoCode;
				noMngSets[ix].NoPresentVal		= 0;
				noMngSets[ix].SettingStartNo	= 0;
				noMngSets[ix].SettingEndNo		= 0;
				noMngSets[ix].NoIncDecWidth		= 0;
			}

			noMngSetList.AddRange(noMngSets);

			// ���񎞂̂�
			if (wkNoMngSetList.Count == 0)
			{
				foreach (NoTypeMng wkNoTypeMng in wkNoTypeSet2List)
				{
					NoMngSet noMngSet = new NoMngSet();
					noMngSet.EnterpriseCode		= enterpriseCode;
                    // 2008.09.23 30413 ���� ���_�R�[�h��2���ɏC�� >>>>>>START
                    noMngSet.SectionCode = "000000";
                    //noMngSet.SectionCode = "00";
                    // 2008.09.23 30413 ���� ���_�R�[�h��2���ɏC�� <<<<<<END
                    noMngSet.NoCode = wkNoTypeMng.NoCode;
					noMngSet.NoPresentVal		= 0;
					noMngSet.SettingStartNo		= 0;
					noMngSet.SettingEndNo		= 0;
					noMngSet.NoIncDecWidth		= 0;
					
					noMngSetList.Add(noMngSet);
				}
			}

			// �V�K�o�^����
			int status = this.Write(ref noMngSetList);
			return status;
		}
		# endregion
	}
}
