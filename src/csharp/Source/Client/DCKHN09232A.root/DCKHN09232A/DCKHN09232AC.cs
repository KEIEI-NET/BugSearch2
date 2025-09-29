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
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �󔭒��Ǘ��S�̐ݒ�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���F �]</br>
    /// <br>Date       : 2007.12.14</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    /// <br>UpdateNote : 2008.12.01 21024�@���X�� ��</br>
    /// <br>           : Search���\�b�h�̒ǉ�</br>
    /// </remarks>
    public class AcptAnOdrTtlStAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IAcptAnOdrTtlStDB _iAcptAnOdrTtlStDB = null;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        private AcptAnOdrTtlStLcDB _acptAnOdrTtlStLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public AcptAnOdrTtlStAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iAcptAnOdrTtlStDB = (IAcptAnOdrTtlStDB)MediationAcptAnOdrTtlStDB.GetAcptAnOdrTtlStDB();
			}
			catch (Exception ex)
			{
				if(ex.Message=="")
					this._iAcptAnOdrTtlStDB = null;
				
				//�I�t���C������null���Z�b�g
 				this._iAcptAnOdrTtlStDB = null;
			}
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._acptAnOdrTtlStLcDB = new AcptAnOdrTtlStLcDB();
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
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
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        public int GetOnlineMode()
		{
 			if (this._iAcptAnOdrTtlStDB == null)
 			{
				return (int)OnlineMode.Offline;
 			}
 			else
 			{
				return (int)OnlineMode.Online;
 			}
		}

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="acptAnOdrTtlSt">�󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�󔭒��Ǘ��S�̐ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        public int Read(out AcptAnOdrTtlSt acptAnOdrTtlSt, string enterpriseCode)
		{			
			try
			{
				acptAnOdrTtlSt = null;
				AcptAnOdrTtlStWork acptAnOdrTtlStWork	= new AcptAnOdrTtlStWork();
				acptAnOdrTtlStWork.EnterpriseCode	= enterpriseCode;

                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// XML�֕ϊ����A������̃o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);
                //
				////�󔭒��Ǘ��S�̐ݒ�ǂݍ���
				//int status = this._iAcptAnOdrTtlStDB.Read(ref parabyte,0);
                //
				//if (status == 0)
				//{
				//	// XML�̓ǂݍ���
				//	acptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(AcptAnOdrTtlStWork));
				//	// �N���X�������o�R�s�[
				//	acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
				//}
                int status;
                if (_isLocalDBRead)
                {
                    status = this._acptAnOdrTtlStLcDB.Read(ref acptAnOdrTtlStWork, 0);
                    if (status == 0)
                    {
                        // �N���X�������o�R�s�[
                        acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                    }
                }
                else
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);
                    
                    //�󔭒��Ǘ��S�̐ݒ�ǂݍ���
                    status = this._iAcptAnOdrTtlStDB.Read(ref parabyte,0);
                    if (status == 0)
                    {
                    	// XML�̓ǂݍ���
                    	acptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(AcptAnOdrTtlStWork));
                    	// �N���X�������o�R�s�[
                    	acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                    }
                }
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
                return status;
			}
			catch (Exception)
			{
				//�ʐM�G���[��-1��߂�
				acptAnOdrTtlSt = null;
				//�I�t���C������null���Z�b�g
				this._iAcptAnOdrTtlStDB = null;
				return -1;
			}
		}

        // 2008.12.01 Add >>>
        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ茟������(�_���폜�f�[�^�͏��O)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o����܂���B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2008.12.01 Add <<<

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ茟������(�_���폜�f�[�^�܂�)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ茟������(���C��)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            acptAnOdrTtlStWork.EnterpriseCode = enterpriseCode;		// ��ƃR�[�h

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = acptAnOdrTtlStWork;
            object retobj = null;

            // �󔭒��Ǘ��S�̐ݒ�S������
            status = this._iAcptAnOdrTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork in wkList)
                    {
                        retList.Add(CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(wkAcptAnOdrTtlStWork));
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="acptAnOdrTtlSt">�󔭒��Ǘ��S�̐ݒ�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        public int Write(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            AcptAnOdrTtlStWork acptAnOdrTtlStWork;
            ArrayList paraList = new ArrayList();

            // UI�f�[�^�N���X�����[�N
            acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);
            paraList.Add(acptAnOdrTtlStWork);
            object paraobj = paraList;

            int status = 0;
            try
            {
                status = _iAcptAnOdrTtlStDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }
                // ���[�N��UI�f�[�^�N���X
                paraList = (ArrayList)paraobj;
                foreach (AcptAnOdrTtlStWork acptAnOdrTtlStWork2 in paraList)
                {
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork2);
                }
                return (0);
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iAcptAnOdrTtlStDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // --- ADD 2008/06/06 -------------------------------->>>>>
            int status = 0;

            try
            {
                // �󔭒��Ǘ��S�̐ݒ�N���X���󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);

                // �ۑ�
                Object paraObj = (object)acptAnOdrTtlStWork;
                status = this._iAcptAnOdrTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �󔭒��Ǘ��S�̐ݒ胏�[�N�N���X����󔭒��Ǘ��S�̐ݒ�N���X�փ����o�R�s�[
                    ArrayList wklist = (ArrayList)paraObj;
                    acptAnOdrTtlStWork = wklist[0] as AcptAnOdrTtlStWork;
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iAcptAnOdrTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�_���폜����
        /// </summary>
        /// <param name="estimateDefSet">�󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int LogicalDelete(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            int status = 0;

            try
            {
                // �󔭒��Ǘ��S�̐ݒ�N���X���󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);

                // �_���폜
                Object paraObj = (object)acptAnOdrTtlStWork;
                status = this._iAcptAnOdrTtlStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �󔭒��Ǘ��S�̐ݒ胏�[�N�N���X���󔭒��Ǘ��S�̐ݒ�N���X�Ƀ����o�R�s�[
                    acptAnOdrTtlStWork = paraObj as AcptAnOdrTtlStWork;
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iAcptAnOdrTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ蕨���폜����
        /// </summary>
        /// <param name="estimateDefSet">�󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̕����폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Delete(AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            int status = 0;
            try
            {
                // �󔭒��Ǘ��S�̐ݒ�N���X���󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);
                // XML�ϊ����A��������o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);

                // �󔭒��Ǘ��S�̐ݒ蕨���폜
                status = this._iAcptAnOdrTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null��ݒ�
                this._iAcptAnOdrTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�_���폜��������
        /// </summary>
        /// <param name="estimateDefSet">�󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Revival(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            int status = 0;

            try
            {
                // �󔭒��Ǘ��S�̐ݒ�N���X���󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);

                // �󔭒��Ǘ��S�̐ݒ�𕜊�
                Object paraObj = (object)acptAnOdrTtlStWork;
                status = this._iAcptAnOdrTtlStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �󔭒��Ǘ��S�̐ݒ胏�[�N�N���X���󔭒��Ǘ��S�̐ݒ�N���X�Ƀ����o�R�s�[
                    acptAnOdrTtlStWork = paraObj as AcptAnOdrTtlStWork;
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iAcptAnOdrTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
		/// �󔭒��Ǘ��S�̐ݒ�V���A���C�Y����
		/// </summary>
		/// <param name="AcptAnOdrTtlSt">�V���A���C�Y�Ώێ󔭒��Ǘ��S�̐ݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �󔭒��Ǘ��S�̐ݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : ���F �]</br>
		/// <br>Date       : 2007.12.14</br>
		/// </remarks>
		public void AcptAnOdrTtlStSerialize(AcptAnOdrTtlSt AcptAnOdrTtlSt,string fileName)
		{
			//�v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(AcptAnOdrTtlSt,fileName);
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="AcptAnOdrTtlStList">�V���A���C�Y�Ώێ󔭒��Ǘ��S�̐ݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �󔭒��Ǘ��S�̐ݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : ���F �]</br>
		/// <br>Date       : 2007.12.14</br>
		/// </remarks>
		public void AcptAnOdrTtlStListSerialize(ArrayList AcptAnOdrTtlStList,string fileName)
		{
			// ArrayList����z��𐶐�
			AcptAnOdrTtlSt[] AcptAnOdrTtlSts = (AcptAnOdrTtlSt[])AcptAnOdrTtlStList.ToArray(typeof(AcptAnOdrTtlSt));
			// �v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(AcptAnOdrTtlSts,fileName);

		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�ˎ󔭒��Ǘ��S�̐ݒ�N���X�j
        /// </summary>
        /// <param name="AcptAnOdrTtlStWork">�󔭒��Ǘ��S�̐ݒ胏�[�N�N���X</param>
        /// <returns>�󔭒��Ǘ��S�̐ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ胏�[�N�N���X����󔭒��Ǘ��S�̐ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        private AcptAnOdrTtlSt CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(AcptAnOdrTtlStWork AcptAnOdrTtlStWork)
		{
			AcptAnOdrTtlSt AcptAnOdrTtlSt = new AcptAnOdrTtlSt();

			//�t�@�C���w�b�_����
			AcptAnOdrTtlSt.CreateDateTime			= AcptAnOdrTtlStWork.CreateDateTime;
			AcptAnOdrTtlSt.UpdateDateTime			= AcptAnOdrTtlStWork.UpdateDateTime;
			AcptAnOdrTtlSt.EnterpriseCode			= AcptAnOdrTtlStWork.EnterpriseCode;
			AcptAnOdrTtlSt.FileHeaderGuid			= AcptAnOdrTtlStWork.FileHeaderGuid;
			AcptAnOdrTtlSt.UpdEmployeeCode		    = AcptAnOdrTtlStWork.UpdEmployeeCode;
			AcptAnOdrTtlSt.UpdAssemblyId1			= AcptAnOdrTtlStWork.UpdAssemblyId1;
			AcptAnOdrTtlSt.UpdAssemblyId2			= AcptAnOdrTtlStWork.UpdAssemblyId2;
			AcptAnOdrTtlSt.LogicalDeleteCode		= AcptAnOdrTtlStWork.LogicalDeleteCode;
            //AcptAnOdrTtlSt.OrderNumberCompo = AcptAnOdrTtlStWork.OrderNumberCompo;       // DEL 2008/06/06
            AcptAnOdrTtlSt.EstmCountReflectDiv = AcptAnOdrTtlStWork.EstmCountReflectDiv;
            AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv = AcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv;
            AcptAnOdrTtlSt.FaxOrderDiv = AcptAnOdrTtlStWork.FaxOrderDiv;
            //AcptAnOdrTtlSt.DotKulOrderDiv = AcptAnOdrTtlStWork.DotKulOrderDiv;           // DEL 2008/06/06 
            AcptAnOdrTtlSt.SectionCode = AcptAnOdrTtlStWork.SectionCode;  // ADD 2008/06/06 

			return AcptAnOdrTtlSt;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�󔭒��Ǘ��S�̐ݒ�N���X�ˎ󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="AcptAnOdrTtlSt">�󔭒��Ǘ��S�̐ݒ胏�[�N�N���X</param>
        /// <returns>�󔭒��Ǘ��S�̐ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�N���X����󔭒��Ǘ��S�̐ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        private AcptAnOdrTtlStWork CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(AcptAnOdrTtlSt AcptAnOdrTtlSt)
		{
			AcptAnOdrTtlStWork AcptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

			AcptAnOdrTtlStWork.CreateDateTime			= AcptAnOdrTtlSt.CreateDateTime;
			AcptAnOdrTtlStWork.UpdateDateTime			= AcptAnOdrTtlSt.UpdateDateTime;
			AcptAnOdrTtlStWork.EnterpriseCode			= AcptAnOdrTtlSt.EnterpriseCode.Trim();
			AcptAnOdrTtlStWork.FileHeaderGuid			= AcptAnOdrTtlSt.FileHeaderGuid;
			AcptAnOdrTtlStWork.UpdEmployeeCode		    = AcptAnOdrTtlSt.UpdEmployeeCode;
			AcptAnOdrTtlStWork.UpdAssemblyId1			= AcptAnOdrTtlSt.UpdAssemblyId1;
			AcptAnOdrTtlStWork.UpdAssemblyId2			= AcptAnOdrTtlSt.UpdAssemblyId2;
			AcptAnOdrTtlStWork.LogicalDeleteCode		= AcptAnOdrTtlSt.LogicalDeleteCode;
            //AcptAnOdrTtlStWork.OrderNumberCompo = AcptAnOdrTtlSt.OrderNumberCompo;      // DEL 2008/06/06
            AcptAnOdrTtlStWork.EstmCountReflectDiv = AcptAnOdrTtlSt.EstmCountReflectDiv;
            AcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv = AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv;
            AcptAnOdrTtlStWork.FaxOrderDiv = AcptAnOdrTtlSt.FaxOrderDiv;
            //AcptAnOdrTtlStWork.DotKulOrderDiv = AcptAnOdrTtlSt.DotKulOrderDiv;          // DEL 2008/06/06

            AcptAnOdrTtlStWork.SectionCode = AcptAnOdrTtlSt.SectionCode;  // ADD 2008/06/06 

            return AcptAnOdrTtlStWork;
		}
	}
}
