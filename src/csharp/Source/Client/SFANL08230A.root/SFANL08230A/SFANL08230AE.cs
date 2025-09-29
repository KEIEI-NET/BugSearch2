using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �󎚈ʒu�ݒ� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󎚈ʒu�ݒ�(���[�U�[DB)�}�X�^�X�V�E�擾���̑�����s���A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 22011 �����@���l</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: 22011 ���� ���l</br>
    /// <br>           : 2008.03.18 �󎚈ʒu�̍폜�����T�[�o�[�̈󎚈ʒu�f�[�^���ŏ��ɕύX</br>
    /// </remarks>
    public class SFANL08230AE
    {
        IFrePrtPSetDLDB _frePrtPSetDB;
        FrePrtPSetAcs _frePrtPSetAcs = new FrePrtPSetAcs();    //���R���[�󎚈ʒuDB�A�N�Z�X�N���X
        FrePrtPosLocalAcs _frePrtPosLocalAcs = new FrePrtPosLocalAcs(); //���R���[�󎚈ʒu���[�J���t�@�C���A�N�Z�X�N���X

        // Image�֘A
        private const Int32 ctSYSTEMDIVCD = 0;
        private const Int32 ctIMAGEUSESYSTEM_CODE = 100;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SFANL08230AE()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._frePrtPSetDB = (IFrePrtPSetDLDB)MediationFrePrtPSetDLDB.GetFrePrtPSetDLDB();
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._frePrtPSetDB = null;
			}
        }

        /// <summary>
        /// �󎚈ʒu�ݒ�/���o����/�\�[�g���E(�w�i�摜)�̎擾���s���܂��B
        /// </summary>
        /// <param name="frePrtPSet">�󎚈ʒu�f�[�^�N���X</param>
        /// <param name="frePprECndLs">���o�����f�[�^�N���X</param>
        /// <param name="frePprSrtOLs">�\�[�g���f�[�^�N���X</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int Read(ref FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndLs, out List<FrePprSrtO> frePprSrtOLs, out string errmsg)
        {
            int status = 0;
            errmsg = "";
            frePprECndLs = new List<FrePprECnd>();
            frePprSrtOLs = new List<FrePprSrtO>();
            try
            {
                status = _frePrtPSetAcs.ReadDBFrePrtPSet(ref frePrtPSet, out frePprECndLs, out frePprSrtOLs);
            }
            catch (Exception ex)
            {
                status = -1;
                errmsg = ex.Message;
            }
            return status;
        }

        #region �󎚈ʒu�ݒ���𕨗��폜
        /// <summary>
        /// �󎚈ʒu�ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="frePrtPSetWork">�󎚈ʒu�ݒ�f�[�^�p�����[�^(�L�[�l�݂̂��w��)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errmsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󎚈ʒu�ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public int Delete(FrePrtPSetWork frePrtPSetWork, out bool msgDiv, out string errmsg)
        {
            errmsg = "";
            msgDiv = false;
            int status = 0;

            try
            {
                // 2008.03.18 �T�[�o�[�̈󎚈ʒu�f�[�^���ŏ��ɍ폜����悤�C��
                // �r�����䎞�A�w�i�摜�݂̂�������̂�h������

                // XML�֕ϊ����A�N���X�̃o�C�i����
                byte[] frePrtPSetWorkByte = XmlByteSerializer.Serialize(frePrtPSetWork);
                // �󎚈ʒu�ݒ�̍폜
                status = this._frePrtPSetDB.DeleteFrePrtPSet(frePrtPSetWorkByte,out msgDiv, out errmsg);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
                //if ((int)ConstantManagement.DB_Status.ctDB_NORMAL == status)
                //{
                //    // ���[�J���t�@�C���폜
                //    status = _frePrtPosLocalAcs.DeleteLocalFrePrtPSet(frePrtPSetWork.EnterpriseCode, frePrtPSetWork.OutputFormFileName, frePrtPSetWork.UserPrtPprIdDerivNo);
                //    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                //    {
                //        errmsg = _frePrtPosLocalAcs.ErrorMessage;
                //        return -1;
                //    }

                //    // �摜�T�[�o�̉摜(�w�i�摜)���폜
                //    ImageGroup[] imageGroupArray;
                //    ImgManage[] imgManageArray;
                //    ImageImgAcs _imageImgAcs = new ImageImgAcs();          //�摜�Ǘ��A�N�Z�X�N���X;

                //    status = _imageImgAcs.Search(out imageGroupArray, out imgManageArray, frePrtPSetWork.EnterpriseCode, frePrtPSetWork.TakeInImageGroupCd, ctSYSTEMDIVCD, ctIMAGEUSESYSTEM_CODE, true);
                //    if ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND == status) return 0;  // 2008.03.18 ADD

                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        if (!((imageGroupArray != null) && (imageGroupArray.Length > 0)))
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }

                //        if ((imgManageArray == null) || (imgManageArray.Length == 0))
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }
                //    }
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        status = _imageImgAcs.Delete(imageGroupArray[0]);
                //    }

                //    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                //    {
                //        errmsg = "�w�i�摜�̍폜�����Ɏ��s���܂���";
                //        return -1;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception");
                //�I�t���C������null���Z�b�g
                this._frePrtPSetDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
                errmsg = ex.Message;
            }
            return status;
        }
        #endregion

        #region �󎚈ʒu�ݒ茟������(�K�C�h�p)
        /// <summary>
		/// �󎚈ʒu�ݒ茟������(�K�C�h�p)
		/// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="OutputFormFileName">�o�̓t�@�C����</param>
		/// <param name="frePrtPSetWorkList">���������󎚈ʒu�ݒ�z��</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �󎚈ʒu�ݒ�����������܂�</br>
		/// <br>           : ���o�̓t�@�C�������w�莞�A�S���X�g���擾���܂�</br>
		/// <br>           : ���󎚈ʒu�ݒ�f�[�^�A�w�i�摜�f�[�^�͎擾���܂���</br>
		/// <br>Programmer : 22011 �����@���l</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public int Search(string EnterpriseCode,string OutputFormFileName, out FrePrtPSetWork[] frePrtPSetWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, out string errmsg)
		{
			errmsg = "";
			int status = 0;
			frePrtPSetWorkList = null;
            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg="";     //�G���[���b�Z�[�W������

			try
			{
				byte[] frePrtPSetWorkListkByte;

				// �󎚈ʒu�ݒ�̌���
				status = this._frePrtPSetDB.Search(EnterpriseCode,OutputFormFileName, out frePrtPSetWorkListkByte, readMode, logicalMode, out msgDiv, out errMsg);
				if (status == 0)
				{
					// XML�o�C�g�񂩂�N���X�z��֓W�J
					frePrtPSetWorkList = (FrePrtPSetWork[])XmlByteSerializer.Deserialize(frePrtPSetWorkListkByte,typeof(FrePrtPSetWork[]));
				}
				else
				{
					frePrtPSetWorkList = null;
				}
			}
			catch (Exception ex)
			{
				//�I�t���C������null���Z�b�g
				this._frePrtPSetDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
				errmsg = ex.Message;
			}
            if (msgDiv == true)
            {
                errmsg = errmsg + "\r\n\r\n*�ڍ� = " + errMsg;
            }
			return status;
        }
        #endregion
    }
}
