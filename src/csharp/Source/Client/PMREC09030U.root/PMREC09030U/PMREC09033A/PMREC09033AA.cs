//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���������i�O���[�v�K�C�h
// �v���O�����T�v   �F���������i�O���[�v�A�N�Z�X�N���X
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F20073 �� �B
// �C����    2015/02/24     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
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
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���������i�O���[�v�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���������i�O���[�v�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 20073 �� �B</br>
	/// <br>Date       : 2015.02.24</br>
    /// <br>------------------------------------------------------------------------------------</br>
	/// </remarks>
	public class RecBgnGrpAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IRecBgnGrpDB _iRecBgnGrpDB = null;

		/// <summary>
		/// ���������i�O���[�v�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���������i�O���[�v�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 20073 �� �B</br>
		/// <br>Date       : 2015.02.24</br>
		/// <br></br>
		/// </remarks>
        public RecBgnGrpAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
                this._iRecBgnGrpDB = (IRecBgnGrpDB)MediationRecBgnGrpDB.GetRecBgnGrpDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
                this._iRecBgnGrpDB = null;
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
        /// �ڋq�S������
        /// </summary>
        /// <param name="retArray"></param>
        /// <param name="paraRec"></param>
        /// <returns></returns>
        public int Search(out RecBgnGrpRet[] retArray, string cnectOtherEpCd)
        {
            //RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = new RecBgnGrpSearchParaWork();
            //recBgnGrpSearchParaWork = CopyToParamDataFromUIData(paraRec);
            int count = 0;
            string errMsg = string.Empty;

            //object paraObj = recBgnGrpSearchParaWork;
            object retObj;
            ArrayList retList = new ArrayList();
            ArrayList recBgnGrpRetList = new ArrayList();
            //string cnectOtherEpCd = paraRec.InqOriginalEpCd;

            // ���Ӑ挟�� (�_���폜�s���擾)
            int status = this._iRecBgnGrpDB.Search(out retObj, cnectOtherEpCd, ConstantManagement.LogicalMode.GetData0, out count, ref errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList = retObj as ArrayList;

                if (retList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                else
                {
                    Hashtable pccCmpnyStHt = null;
                    foreach (RecBgnGrpWork retWork in retList)
                    {
                        recBgnGrpRetList.Add(this.CopyToUIDataFromParamData(retWork));
                    }
                }
            }

            retArray = (RecBgnGrpRet[])recBgnGrpRetList.ToArray(typeof(RecBgnGrpRet));

            return status;
        }
		
		/// <summary>
		/// �ڋq�S������
		/// </summary>
        /// <param name="retArray"></param>
        /// <param name="paraRec"></param>
		/// <returns></returns>
        public int Search(out RecBgnGrpRet[] retArray, RecBgnGrpPara paraRec)
		{
            RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = new RecBgnGrpSearchParaWork();
            recBgnGrpSearchParaWork = CopyToParamDataFromUIData(paraRec);
            object paraObj = (object)recBgnGrpSearchParaWork;
            object retObj;
			ArrayList retList = new ArrayList();
            ArrayList recBgnGrpRetList = new ArrayList();

            int count = 0;
            string errMsg = string.Empty;
            
            // ���Ӑ挟�� (�_���폜�s���擾)
            int status = this._iRecBgnGrpDB.Search(out retObj, paraObj, ConstantManagement.LogicalMode.GetData0, out count, ref errMsg);


			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				retList = retObj as ArrayList;

				if (retList == null)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
				else
				{
                    Hashtable pccCmpnyStHt = null;
                    foreach (RecBgnGrpWork retWork in retList)
                    {
                        recBgnGrpRetList.Add(this.CopyToUIDataFromParamData(retWork));
                    }
				}
			}

            retArray = (RecBgnGrpRet[])recBgnGrpRetList.ToArray(typeof(RecBgnGrpRet));

			return status;
		}
		
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���������i�O���[�v���[�N�N���X�˂��������i�O���[�v�K�C�h���ʃN���X�j
		/// </summary>
		/// <param name="customerSearchWork">���������i�O���[�v���[�N�N���X</param>
		/// <returns>���������i�O���[�v���ʃN���X</returns>
		/// <remarks>
		/// <br>Note       : ���������i�O���[�v���[�N�N���X���炨�������i�O���[�v�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 20073 �� �B</br>
		/// <br>Date       : 2015.02.24</br>
		/// </remarks>
        private RecBgnGrpRet CopyToUIDataFromParamData(RecBgnGrpWork recBgnGrpWork)
		{
            RecBgnGrpRet recBgnGrpRet = new RecBgnGrpRet();

			// ���Ӑ���
            //recBgnGrpWork.CreateDateTime = recBgnGrpSearchWork.CreateDateTime;            //�쐬����
            //recBgnGrpWork.UpdateDateTime = recBgnGrpSearchWork.UpdateDateTime;            //�X�V����
            recBgnGrpRet.LogicalDeleteCode = recBgnGrpWork.LogicalDeleteCode;      //�_���폜�敪
            recBgnGrpRet.InqOriginalEpCd = recBgnGrpWork.InqOriginalEpCd;          //�⍇������ƃR�[�h
            recBgnGrpRet.InqOriginalSecCd = recBgnGrpWork.InqOriginalSecCd;        //�⍇�������_�R�[�h
            recBgnGrpRet.BrgnGoodsGrpCode = recBgnGrpWork.BrgnGoodsGrpCode;        //���������i�O���[�v�R�[�h
            recBgnGrpRet.DisplayOrder = recBgnGrpWork.DisplayOrder;                //�\������
            recBgnGrpRet.BrgnGoodsGrpTitle = recBgnGrpWork.BrgnGoodsGrpTitle;      //���������i�O���[�v�^�C�g��
            recBgnGrpRet.BrgnGoodsGrpTag = recBgnGrpWork.BrgnGoodsGrpTag;          //���������i�O���[�v�R�����g�^�O
            recBgnGrpRet.BrgnGoodsGrpComment = recBgnGrpWork.BrgnGoodsGrpComment;  //���������i�O���[�v�R�����g

            return recBgnGrpRet;
		}


		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���������i�O���[�v�����N���X�˂��������i�O���[�v�K�C�h���[�N�N���X�j
		/// </summary>
        /// <param name="customerSearchPara">���������i�O���[�v�����N���X</param>
		/// <returns>���������i�O���[�v���[�N�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���������i�O���[�v�����N���X���炨�������i�O���[�v���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 20073 �� �B</br>
		/// <br>Date       : 2015.02.24</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        private RecBgnGrpSearchParaWork CopyToParamDataFromUIData(RecBgnGrpPara recBgnGrpSearchWork)
		{
            RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = new RecBgnGrpSearchParaWork();

            //recBgnGrpSearchParaWork.CreateDateTime = recBgnGrpSearchWork.CreateDateTime;
            //recBgnGrpSearchParaWork.UpdateDateTime = recBgnGrpSearchWork.UpdateDateTime;
            recBgnGrpSearchParaWork.LogicalDeleteCode = recBgnGrpSearchWork.LogicalDeleteCode;
            recBgnGrpSearchParaWork.InqOriginalEpCd = recBgnGrpSearchWork.InqOriginalEpCd;
            recBgnGrpSearchParaWork.InqOriginalSecCd = recBgnGrpSearchWork.InqOriginalSecCd;
            recBgnGrpSearchParaWork.BrgnGoodsGrpCode = recBgnGrpSearchWork.BrgnGoodsGrpCode;
            recBgnGrpSearchParaWork.DisplayOrder = recBgnGrpSearchWork.DisplayOrder;
            recBgnGrpSearchParaWork.BrgnGoodsGrpTitle = recBgnGrpSearchWork.BrgnGoodsGrpTitle;
            recBgnGrpSearchParaWork.BrgnGoodsGrpTag = recBgnGrpSearchWork.BrgnGoodsGrpTag;
            recBgnGrpSearchParaWork.BrgnGoodsGrpComment = recBgnGrpSearchWork.BrgnGoodsGrpComment;

            return recBgnGrpSearchParaWork;
		}


	}
}
