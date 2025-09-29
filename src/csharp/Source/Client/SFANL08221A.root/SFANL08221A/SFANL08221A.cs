using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;				
using Broadleaf.Application.Remoting.ParamData;	
using Broadleaf.Application.Remoting.Adapter;		
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

using Broadleaf.Application.Common; 
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[�O���[�v�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�O���[�v�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 22011 ���� ���l</br>
	/// <br>Date       : 2007.04.03</br>
    /// <br>Update Note: </br>
    /// <br>             </br>
    /// </remarks>
	public class FreePprGrpAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IFreePprGrpDB _iFreePprGrpDB = null;
		// ���R���[�O���[�v�U�փL���b�V��
		private Hashtable _frePprGrTrTable = null;
		// ���R���[�O���[�v���L���b�V���p
		private static SortedList _guideBuf_FreePprGrp = null;

        #region const
        /// <summary>�ő�\������</summary>
        private const Int32 LAST_DISPORDER_KEYWORD = 9999;
        
        #endregion

        #region Constructor
        /// <summary>
		/// ���R���[�O���[�v�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public FreePprGrpAcs()
		{
			this._frePprGrTrTable = null;
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iFreePprGrpDB = (IFreePprGrpDB)MediationFreePprGrpDB.GetFreePprGrpDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iFreePprGrpDB = null;
			}
        }
        #endregion

        #region ���R���[�O���[�v�N���X�f�V���A���C�Y����
        ///**********************************************************************
		/// <summary>
		/// ���R���[�O���[�v�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���R���[�O���[�v�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// **********************************************************************
		public FreePprGrp FreePprGrpDeserialize(string fileName)
		{
			FreePprGrp freePprGrp = null;

            FreePprGrpWork freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(fileName, typeof(FreePprGrpWork));
			
			//�f�V���A���C�Y���ʂ����R���[�O���[�v�N���X�փR�s�[
            if (freePprGrpWork != null) freePprGrp = CopyToFreePprGrpFromFreePprGrpWork(freePprGrpWork);
			return freePprGrp;
        }
        #endregion

        #region ���R���[�O���[�vList�N���X�f�V���A���C�Y����
        /// ********************************************************************
		/// <summary>
		/// ���R���[�O���[�vList�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���R���[�O���[�v�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v���X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ********************************************************************
		public ArrayList FreePprGrpListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// �t�@�C������n���Ď��R���[�O���[�v���[�N�N���X���f�V���A���C�Y����
            FreePprGrpWork[] freePprGrpWorks;
            freePprGrpWorks = (FreePprGrpWork[])XmlByteSerializer.Deserialize(fileName, typeof(FreePprGrpWork[]));

			//�f�V���A���C�Y���ʂ����R���[�O���[�v�t�h�N���X�փR�s�[
			if (freePprGrpWorks != null) 
			{
				al.Capacity = freePprGrpWorks.Length;
				for(int i=0; i < freePprGrpWorks.Length; i++)
				{
                    al.Add(CopyToFreePprGrpFromFreePprGrpWork(freePprGrpWorks[i]));
				}
			}
			return al;
        }
        #endregion

        #region ���R���[�O���[�v�o�^�E�X�V����
        /// **********************************************************
		/// <summary>
		/// ���R���[�O���[�v�o�^�E�X�V����
		/// </summary>
		/// <param name="freePprGrp">���R���[�O���[�v�N���X</param>
        /// <param name="errmsg"></param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v���̓o�^�E�X�V���s���܂��B
		///					 XML�`���֏����ׁA��U�S���Ǎ���ɓo�^����</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ************************************************************
		public int WriteFreePprGrp(ref FreePprGrp freePprGrp,out string errmsg)
		{
            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������
            errmsg = "";

			//���R���[�O���[�v�N���X���玩�R���[�O���[�v���[�J�[�N���X�Ƀ����o�R�s�[
            FreePprGrpWork freePprGrpWork = CopyToFreePprGrpWorkFromFreePprGrp(freePprGrp);
			
			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(freePprGrpWork);

			int status = 0;
			try
			{
				//���R���[�O���[�v��������
                status = this._iFreePprGrpDB.WriteFreePprGrp(ref parabyte, out msgDiv, out errMsg);
                if (status == (int)(ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    // �t�@�C������n���Ď��R���[�O���[�v���[�N�N���X���f�V���A���C�Y����
                    freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte, typeof(FreePprGrpWork));
                    // �N���X�������o�R�s�[
                    freePprGrp = CopyToFreePprGrpFromFreePprGrpWork(freePprGrpWork);

                    // �L���b�V���X�V
                    if (_guideBuf_FreePprGrp != null)
                    {
                        _guideBuf_FreePprGrp[freePprGrp.FreePrtPprGroupCd] = freePprGrp;
                    }
                }
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iFreePprGrpDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*�ڍ� = " + errMsg;
            }

			return status;
        }
        #endregion

        #region ���R���[�O���[�v�L���b�V�����f�[�^��������
        /// <summary>
		/// ���R���[�O���[�v�L���b�V�����f�[�^��������
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �L���b�V���p�X�^�e�B�b�N�̈悩�玩�R���[�O���[�v�̌������s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private int SearchStaticMemoryProc( out ArrayList retList, string enterpriseCode )
		{
			int status = 0;
			retList = new ArrayList();
			retList.Clear();

            //�L���b�V�����Ȃ���Ύ擾����
			if( ( _guideBuf_FreePprGrp == null ) || ( _guideBuf_FreePprGrp.Count == 0 ) ) 
			{
				status = GetFreePprGrpDataBuffer( enterpriseCode );
				switch( status ) 
				{
					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					{
						break;
					}
					default:
					{
						return status;
					}
				}
			}

			//�L���b�V������W�J
            foreach( FreePprGrp freePprGrp in _guideBuf_FreePprGrp.Values ) 
			{
				if( freePprGrp.LogicalDeleteCode == 0 ) 
				{
					retList.Add( freePprGrp.Clone() );
				}
			}

			if( retList.Count == 0 ) 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
			}
			return status;
        }
        #endregion

        #region ���R���[�O���[�v�L���b�V���擾����
        /// <summary>
		/// ���R���[�O���[�v�L���b�V���擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�̃L���b�V�����擾���܂�</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 22007.04.03</br>
		/// </remarks>
		private int GetFreePprGrpDataBuffer( string enterpriseCode )
		{
			int status = 0;

			if( _guideBuf_FreePprGrp == null ) 
			{
				_guideBuf_FreePprGrp = new SortedList();
			}

			ArrayList freePprGrps = null;
			bool nextData;
			int	 retTotalCnt;
            //�����[�g�ŏ����擾
			status = SearchFreePprGrpProc(out freePprGrps,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
			{   
                //�U�֏���W�J
				foreach( FreePprGrp freePprGrp in freePprGrps ) 
				{
					if( _guideBuf_FreePprGrp.ContainsKey( freePprGrp.FreePrtPprGroupCd) == false ) 
					{
						_guideBuf_FreePprGrp.Add( freePprGrp.FreePrtPprGroupCd, freePprGrp.Clone() );
					}
				}
			}
			return status;
        }
        #endregion

        #region ���R���[�O���[�v�L���b�V�����f�[�^��������
        /// <summary>
		/// ���R���[�O���[�v�L���b�V�����f�[�^��������
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �L���b�V���p�X�^�e�B�b�N�̈悩�玩�R���[�O���[�v�̌������s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int SearchStaticMemoryFreePprGrp( out ArrayList retList, string enterpriseCode )
		{
			return SearchStaticMemoryProc( out retList, enterpriseCode );
        }
        #endregion

        #region ���R���[�O���[�v�V���A���C�Y����
        /// ************************************************************
		/// <summary>
		/// ���R���[�O���[�v�V���A���C�Y����
		/// </summary>
		/// <param name="freePprGrp">�V���A���C�Y�Ώۏ]���R���[�O���[�v�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v���̃V���A���C�Y���s���܂��B
		///                  ���̊֐��͎g�p�Ă��Ȃ��̂Ŗ��׃f�[�^�����͖��g�ݍ���</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ************************************************************
		public void FreePprGrpSerialize(FreePprGrp freePprGrp,string fileName)
		{
			//���R���[�O���[�v�N���X���玩�R���[�O���[�v���[�J�[�N���X�Ƀ����o�R�s�[
            FreePprGrpWork freePprGrpWork = CopyToFreePprGrpWorkFromFreePprGrp(freePprGrp);
			//���R���[�O���[�v���[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(freePprGrpWork,fileName);
        }
        #endregion

        #region ���R���[�O���[�v�����폜����
        /// <summary>
		///	���R���[�O���[�v�����폜����
		/// </summary>
		/// <param name="freePprGrp">���R���[�O���[�v�I�u�W�F�N�g</param>
		/// <param name="frePprGrTrList">���R���[�O���[�v�U�փ��X�g</param>
        /// <param name="errmsg"></param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v���̕����폜���s���܂��B
		///					 ���R���[�O���[�v�U�ւ��ꏏ�ɍ폜���܂�</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int DeleteFreePprGrpAndGrTr(FreePprGrp freePprGrp, ArrayList frePprGrTrList,out string errmsg)
		{
            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������
            int status = 0;
            errmsg = "";

			try
			{
                FreePprGrpWork freePprGrpWork = CopyToFreePprGrpWorkFromFreePprGrp(freePprGrp);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte1 = XmlByteSerializer.Serialize(freePprGrpWork);
				byte[] parabyte2 = null;

				if (frePprGrTrList.Count != 0)
				{
					FrePprGrTrWork[] frePprGrTrWork = new FrePprGrTrWork[frePprGrTrList.Count];
					int ix=0;
					foreach(FrePprGrTr detail in frePprGrTrList)
					{
						frePprGrTrWork[ix] = CopyToFrePprGrTrWorkFromFrePprGrTr(detail);
						ix++;
					}
					//���z��̏ꍇ�̃��W�b�N
					parabyte2 = XmlByteSerializer.Serialize(frePprGrTrWork);
				}
				// �����폜
                status = this._iFreePprGrpDB.DeleteFreePprGrpAll(ref parabyte1, ref parabyte2, out msgDiv, out errMsg);
								
				// ���ב��L���b�V���폜
				if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
				{
					foreach (FrePprGrTr frePprGrTr in frePprGrTrList)
					{
						RemoveCache( frePprGrTr );
					}
				}
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iFreePprGrpDB = null;
				//�ʐM�G���[��-1��߂�
				status =  -1;
			}
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*�ڍ� = " + errMsg;
            }
            return status;
        }
        #endregion

        #region ���R���[�O���[�v���������i�_���폜�敪�͖����j
        /// <summary>
		/// ���R���[�O���[�v���������i�_���폜�敪�͖����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int SearchAllFreePprGrp(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchFreePprGrpProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
        }
        #endregion

        #region ���R���[�O���[�v��������
        /// <summary>
		/// ���R���[�O���[�v��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevFreePprGrp��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�̌����������s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private int SearchFreePprGrpProc(out ArrayList retList,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode)
		{
            FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
            freePprGrpWork.EnterpriseCode = enterpriseCode;
			
			//���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;
            retList = new ArrayList();
            Object retObj;
            Object paraObj = freePprGrpWork as Object;

            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������


            // ���R���[�O���[�v����
            int status = 0;
            status = this._iFreePprGrpDB.SearchFreePprGrp(out retObj, paraObj, 0, logicalMode, out msgDiv, out errMsg);

            if (status == 0)
            {
                // �p�����[�^���n���ė��Ă��邩�m�F
                ArrayList paraList;
                paraList = retObj as ArrayList;

                FreePprGrpWork[] al = new FreePprGrpWork[paraList.Count];

                // �f�[�^�����ɖ߂�
                for (int i = 0; i < paraList.Count; i++)
                {
                    al[i] = (FreePprGrpWork)paraList[i];
                }
                for (int i = 0; i < al.Length; i++)
                {
                    // �T�[�`���ʎ擾
                    FreePprGrpWork wkFreePprGrpWork = (FreePprGrpWork)al[i];
                    //���R���[�O���[�v�N���X�փ����o�R�s�[
                    FreePprGrp freePprGrp = CopyToFreePprGrpFromFreePprGrpWork(wkFreePprGrpWork);
                   
                    retList.Add(freePprGrp);

                }
            }
            retTotalCnt = retList.Count;
            if (msgDiv == true)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                    "FreePprGrpAcs", 				    // �A�Z���u���h�c�܂��̓N���X�h�c
                    "���R���[�O���[�v�A�N�Z�X�N���X", 	// �v���O��������
                    "SearchFreePprGrpProc", 			// ��������
                    TMsgDisp.OPE_READ, 		    		// �I�y���[�V����
                    "�����Ɏ��s���܂����B\r\n\r\n*�ڍ� = " + errMsg, 	// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._iFreePprGrpDB, 				// �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
			return status;
        }
        #endregion

        #region workclass �� dataclass�@�R���o�[�g�֌W

        #region ���R���[�O���[�v���[�N�N���X�ˎ��R���[�O���[�v�N���X
        /// ***************************************************************************************
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���R���[�O���[�v���[�N�N���X�ˎ��R���[�O���[�v�N���X�j
		/// </summary>
		/// <param name="freePprGrpWork">���R���[�O���[�v���[�N�N���X</param>
		/// <returns>���R���[�O���[�v�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v���[�N�N���X���玩�R���[�O���[�v�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ****************************************************************************************
        private FreePprGrp CopyToFreePprGrpFromFreePprGrpWork(FreePprGrpWork freePprGrpWork)
		{
			FreePprGrp freePprGrp = new FreePprGrp();
			freePprGrp.CreateDateTime			= freePprGrpWork.CreateDateTime;
			freePprGrp.UpdateDateTime			= freePprGrpWork.UpdateDateTime;
			freePprGrp.EnterpriseCode			= freePprGrpWork.EnterpriseCode;
			freePprGrp.FileHeaderGuid			= freePprGrpWork.FileHeaderGuid;
			freePprGrp.UpdEmployeeCode		    = freePprGrpWork.UpdEmployeeCode;
			freePprGrp.UpdAssemblyId1			= freePprGrpWork.UpdAssemblyId1;
			freePprGrp.UpdAssemblyId2			= freePprGrpWork.UpdAssemblyId2;
			freePprGrp.LogicalDeleteCode		= freePprGrpWork.LogicalDeleteCode;

			freePprGrp.FreePrtPprGroupCd		= freePprGrpWork.FreePrtPprGroupCd;
            freePprGrp.FreePrtPprGroupNm        = freePprGrpWork.FreePrtPprGroupNm;
			
			return freePprGrp;
        }
        #endregion

        #region ���R���[�O���[�v�N���X�ˎ��R���[�O���[�v���[�N�N���X
        /// <summary>
		/// �N���X�����o�[�R�s�[�����i���R���[�O���[�v�N���X�ˎ��R���[�O���[�v���[�N�N���X�j
		/// </summary>
		/// <param name="freePprGrp">���R���[�O���[�v���[�N�N���X</param>
		/// <returns>���R���[�O���[�v�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�N���X���玩�R���[�O���[�v���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private FreePprGrpWork CopyToFreePprGrpWorkFromFreePprGrp(FreePprGrp freePprGrp)
		{
            FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
			freePprGrpWork.CreateDateTime			= freePprGrp.CreateDateTime;
			freePprGrpWork.UpdateDateTime			= freePprGrp.UpdateDateTime;
			freePprGrpWork.EnterpriseCode			= freePprGrp.EnterpriseCode;
			freePprGrpWork.FileHeaderGuid			= freePprGrp.FileHeaderGuid;
			freePprGrpWork.UpdEmployeeCode		    = freePprGrp.UpdEmployeeCode;
			freePprGrpWork.UpdAssemblyId1			= freePprGrp.UpdAssemblyId1;
			freePprGrpWork.UpdAssemblyId2			= freePprGrp.UpdAssemblyId2;
			freePprGrpWork.LogicalDeleteCode		= freePprGrp.LogicalDeleteCode;

            freePprGrpWork.FreePrtPprGroupCd        = freePprGrp.FreePrtPprGroupCd;
            freePprGrpWork.FreePrtPprGroupNm        = freePprGrp.FreePrtPprGroupNm;
			return freePprGrpWork;
        }
        #endregion

        #region ���R���[�O���[�v�U�փN���X�ˎ��R���[�O���[�v�U�փ��[�N�N���X
        /// <summary>
        ///	�N���X�����o�[�R�s�[�����i���R���[�O���[�v�U�փ��[�N�N���X�ˎ��R���[�O���[�v�U�փN���X�j
		/// </summary>
		/// <param name="frePprGrTrWork"></param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note		: ���R���[�O���[�v�U�փ��[�N�N���X���玩�R���[�O���[�v�U�փN���X�ւ̃����o�R�s�[���s���܂��B</br>
		///	<br>Programer	: 22011 ���� ���l</br>
		///	<br>Date		: 2007.04.03</br>
		/// </remarks>						
		private FrePprGrTr CopyToFrePprGrTrFromFrePprGrTrWork(FrePprGrTrWork frePprGrTrWork)
		{
			FrePprGrTr frePprGrTr = new FrePprGrTr();

			frePprGrTr.CreateDateTime			= frePprGrTrWork.CreateDateTime;
			frePprGrTr.UpdateDateTime			= frePprGrTrWork.UpdateDateTime;
			frePprGrTr.EnterpriseCode			= frePprGrTrWork.EnterpriseCode;
			frePprGrTr.FileHeaderGuid			= frePprGrTrWork.FileHeaderGuid;
			frePprGrTr.UpdEmployeeCode			= frePprGrTrWork.UpdEmployeeCode;
			frePprGrTr.UpdAssemblyId1			= frePprGrTrWork.UpdAssemblyId1;
			frePprGrTr.UpdAssemblyId2			= frePprGrTrWork.UpdAssemblyId2;
			frePprGrTr.LogicalDeleteCode		= frePprGrTrWork.LogicalDeleteCode;

            frePprGrTr.FreePrtPprGroupCd        = frePprGrTrWork.FreePrtPprGroupCd;
            frePprGrTr.TransferCode             = frePprGrTrWork.TransferCode;
            frePprGrTr.DisplayOrder             = frePprGrTrWork.DisplayOrder;
            frePprGrTr.DisplayName              = frePprGrTrWork.DisplayName;
            frePprGrTr.OutputFormFileName       = frePprGrTrWork.OutputFormFileName;
            frePprGrTr.UserPrtPprIdDerivNo      = frePprGrTrWork.UserPrtPprIdDerivNo;
			return frePprGrTr;
        }
        #endregion

        #region ���R���[�O���[�v�U�փN���X�ˎ��R���[�O���[�v�U�փ��[�N�N���X
        /// <summary>�@
        ///	�N���X�����o�[�R�s�[�����i���R���[�O���[�v�U�փN���X�ˎ��R���[�O���[�v�U�փ��[�N�N���X�j
		/// </summary>
		/// <param name="frePprGrTr"></param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note		: ���R���[�O���[�v�U�փN���X���玩�R���[�O���[�v�U�փ��[�N�N���X�ւ̃����o�R�s�[���s���܂��B</br>
		///	<br>Programer	: 22011 ���� ���l</br>
		///	<br>Date		: 2007.04.03</br>
		/// </remarks>						
		private FrePprGrTrWork CopyToFrePprGrTrWorkFromFrePprGrTr(FrePprGrTr frePprGrTr)
		{
			FrePprGrTrWork frePprGrTrWork = new FrePprGrTrWork();
			frePprGrTrWork.CreateDateTime			= frePprGrTr.CreateDateTime;
			frePprGrTrWork.UpdateDateTime			= frePprGrTr.UpdateDateTime;
			frePprGrTrWork.EnterpriseCode			= frePprGrTr.EnterpriseCode;
			frePprGrTrWork.FileHeaderGuid			= frePprGrTr.FileHeaderGuid;
			frePprGrTrWork.UpdEmployeeCode			= frePprGrTr.UpdEmployeeCode;
			frePprGrTrWork.UpdAssemblyId1			= frePprGrTr.UpdAssemblyId1;
			frePprGrTrWork.UpdAssemblyId2			= frePprGrTr.UpdAssemblyId2;
			frePprGrTrWork.LogicalDeleteCode		= frePprGrTr.LogicalDeleteCode;

            frePprGrTrWork.FreePrtPprGroupCd        = frePprGrTr.FreePrtPprGroupCd;
            frePprGrTrWork.TransferCode             = frePprGrTr.TransferCode;
            frePprGrTrWork.DisplayOrder             = frePprGrTr.DisplayOrder;
            frePprGrTrWork.DisplayName              = frePprGrTr.DisplayName;
            frePprGrTrWork.OutputFormFileName       = frePprGrTr.OutputFormFileName;
            frePprGrTrWork.UserPrtPprIdDerivNo      = frePprGrTr.UserPrtPprIdDerivNo;

			return frePprGrTrWork;
        }
        #endregion

        #endregion


        #region freePprGrpdtl��I/O�֘A

        #region ���R���[�O���[�v�U�֖���List�N���X�f�V���A���C�Y����
        /// <summary>
		/// ���R���[�O���[�v�U�֖���List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���R���[�O���[�v�U�փN���XLIST</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�U�փ��X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public ArrayList FrePprGrTrListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// �t�@�C������n���Ď��R���[�O���[�v���[�N�N���X���f�V���A���C�Y����
			FrePprGrTrWork[] frePprGrTrWorks;
			frePprGrTrWorks = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(fileName,typeof(FrePprGrTrWork[]));
			//�f�V���A���C�Y���ʂ����R���[�O���[�v�t�h�N���X�փR�s�[
			if (frePprGrTrWorks != null) 
			{
				al.Capacity = frePprGrTrWorks.Length;
				for(int i=0; i < frePprGrTrWorks.Length; i++)
				{
					al.Add(CopyToFrePprGrTrFromFrePprGrTrWork(frePprGrTrWorks[i]));
				}
			}
			return al;
        }
        #endregion

        #region ���R���[�O���[�v�U��List�V���A���C�Y����
        /// <summary>
		/// ���R���[�O���[�v�U��List�V���A���C�Y����
		/// </summary>
		/// <param name="freePprGrpdtls">�V���A���C�Y�Ώێ��R���[�O���[�v�U��List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�U��List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public void FrePprGrTrListSerialize(ArrayList freePprGrpdtls, string fileName)
		{
			FrePprGrTrWork[] frePprGrTrWorks = new FrePprGrTrWork[freePprGrpdtls.Count];
			for(int i= 0; i < freePprGrpdtls.Count; i++)
			{
				frePprGrTrWorks[i] = CopyToFrePprGrTrWorkFromFrePprGrTr((FrePprGrTr)freePprGrpdtls[i]);
			}
			XmlByteSerializer.Serialize(frePprGrTrWorks,fileName);
        }
        #endregion

        #region ���R���[�O���[�v�U�֑S���������i�_���폜�敪�𖳎��j
        /// <summary>
		/// ���R���[�O���[�v�U�֑S���������i�_���폜�敪�𖳎��j�O���[�v�R�[�h��
		/// </summary>
		/// <param name="frePprGrTrList">���R���[�O���[�v�U�փN���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>	
		/// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�U�ւ̑S�����������s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int SearchAllFreePprGrTr(out ArrayList frePprGrTrList,string enterpriseCode,Int32 freePrtPprGroupCd)
		{			
			int status =0;

			status = SearchFrePprGrTrProc(out frePprGrTrList,freePrtPprGroupCd,enterpriseCode,ConstantManagement.LogicalMode.GetData01);			
			return status;
        }

        /// <summary>
        /// ���R���[�O���[�v�U�֑S���������i�_���폜�敪�𖳎��j
        /// </summary>
        /// <param name="frePprGrTrList">���R���[�O���[�v�U�փN���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�O���[�v�U�ւ̑S�����������s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.03</br>
        /// </remarks>
        public int SearchAllFreePprGrTr(out ArrayList frePprGrTrList, string enterpriseCode)
        {
            int status = 0;

            status = SearchFrePprGrTrProc(out frePprGrTrList, enterpriseCode);
            return status;
        }
        #endregion

        #region ���R���[�O���[�v�U�֏�񌟍��Ǎ�
        /// <summary>
		///	���R���[�O���[�v�U�֏�񌟍��Ǎ�
		/// </summary>
		/// <param name="freePprGrp"></param>
		/// <param name="retTotalCnt"></param>
		/// <param name="nextData"></param>
		/// <param name="enterpriseCode"></param>
		/// <param name="logicalMode"></param>
		/// <param name="readCnt"></param>
		/// <param name="prevFreePprGrp"></param>
		/// <returns>
		/// <br>Note		:	�w��̎��R���[�O���[�v�ɕt�����閾�ׂ݂̂�W�J����</br>
		/// <br>Programer	:	22011 ���� ���l</br>
		/// <br>Date		:	2007.04.03</br>
		/// </returns>
		private int SearchFrePprGrTrProc( ref FreePprGrp freePprGrp,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			int readCnt,
			FreePprGrp prevFreePprGrp)
		{
			//���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;

			ArrayList retList = null;
			int status = SearchCache(out retList, enterpriseCode, freePprGrp.FreePrtPprGroupCd, logicalMode);

			freePprGrp.FrePprGrTrs.AddRange(retList);
			retTotalCnt = freePprGrp.FrePprGrTrs.Count;
			return status;
        }
        #endregion

        #region ���R���[�O���[�v�U�֏�񌟍��Ǎ�
        /// <summary>
		///	���R���[�O���[�v�U�֏�񌟍��Ǎ�
		/// </summary>
		/// <param name="retList"></param>
		/// <param name="freePrtPprGroupCd"></param>
		/// <param name="enterpriseCode"></param>
		/// <param name="logicalMode"></param>
		/// <returns>
		/// <br>Note		:	�w��̎��R���[�O���[�v�ɕt�����閾�ׂ݂̂�W�J����</br>
		/// <br>Programer	:	22011 ���� ���l</br>
		/// <br>Date		:	2007.04.03</br>
		/// </returns>
		private int SearchFrePprGrTrProc(out ArrayList retList,Int32 freePrtPprGroupCd,
			string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCache(out retList, enterpriseCode, freePrtPprGroupCd, logicalMode);
        }

        /// <summary>
        ///	���R���[�O���[�v�U�֏�񌟍��Ǎ�
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns>
        /// <br>Note		:	�w��̎��R���[�O���[�v�ɕt�����閾�ׂ݂̂�W�J����</br>
        /// <br>Programer	:	22011 ���� ���l</br>
        /// <br>Date		:	2007.04.03</br>
        /// </returns>
        private int SearchFrePprGrTrProc(out ArrayList retList, string enterpriseCode)
        {
            return SearchCache(out retList, enterpriseCode);
        }
        #endregion

        #region ���R���[�O���[�v�U�֕����폜����
        /// <summary>
		///	���R���[�O���[�v�U�֕����폜����
		/// </summary>
		/// <param name="frePprGrTr">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�U�֏��̕����폜���s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
        public int DeleteFrePprGrTr(ref FrePprGrTr frePprGrTr, out string errmsg)
		{
            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������
            int status = 0;
            errmsg = "";

			try
			{
				FrePprGrTrWork frePprGrTrWork = CopyToFrePprGrTrWorkFromFrePprGrTr(frePprGrTr);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(frePprGrTrWork);
				//���R���[�O���[�v�U�֕����폜
                status = this._iFreePprGrpDB.DtlDelete(parabyte, out msgDiv, out errMsg);

				if (status == 0)
				{
					frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));
					// �N���X�������o�R�s�[
					frePprGrTr = CopyToFrePprGrTrFromFrePprGrTrWork(frePprGrTrWork);
					RemoveCache( frePprGrTr );
				}
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iFreePprGrpDB = null;
				//�ʐM�G���[��-1��߂�
				status =  -1;
			}
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*�ڍ� = " + errMsg;
            }
            return status;
        }
        #endregion

        #region ���R���[�O���[�v�U�փ}�X�^������
        /// ModuleName WriteFrePprGrTr
		/// <summary>
		///	���R���[�O���[�v�U�փ}�X�^������
		/// </summary>
		/// <param name="frePprGrTr">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
		/// ---------------------------------------------
		/// <remarks>
		/// <br>Note		:	���R���[�O���[�v�U�փ}�X�^�̏����݂��s���܂�</br>
		/// <br>Programer	:	22011 ���� ���l</br>
		/// <br>Date		:	2007.04.03</br>
		/// </remarks>
        public int WriteFrePprGrTr(ref FrePprGrTr frePprGrTr, out string errmsg)
        {
            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������
            int status = 0;
            errmsg = "";
            List<FrePprGrTrWork> wkList = new List<FrePprGrTrWork>();
            FrePprGrTr frepprgrtr;
            object paraObj;

            try
            {
                FrePprGrTrWork frePprGrTrWork;
                frePprGrTrWork = CopyToFrePprGrTrWorkFromFrePprGrTr(frePprGrTr);
                
                //�\�����ʕύX���X�g�擾����
                wkList = ChangeFrePprGrTrDispOrder(frePprGrTrWork);
                if (wkList.Count == 0) return -1;

                //DB�X�V����
                paraObj = wkList;
                status = this._iFreePprGrpDB.WriteFrePprGrTr(ref paraObj, out msgDiv, out errMsg);

                if (status == 0)
                {
                    wkList = (List<FrePprGrTrWork>)paraObj;
                    frePprGrTr = CopyToFrePprGrTrFromFrePprGrTrWork(wkList[0]);
                    foreach (FrePprGrTrWork frePprGrTrwk in wkList)
                    {
                        //���R���[�O���[�v�N���X�փ����o�R�s�[
                        frepprgrtr = CopyToFrePprGrTrFromFrePprGrTrWork(frePprGrTrwk);
                        // �L���b�V���X�V
                        UpdateCache(frepprgrtr.Clone());
                    }
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFreePprGrpDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*�ڍ� = " + errMsg;
            }
            return status;
        }

        /// <summary>
        /// �\�����ʕύX���X�g�擾����
        /// </summary>
        /// <param name="frePprGrTrWk">�I�u�W�F�N�g</param>
        /// <returns>�\�����ʂ̕ύX���s����ƕ��i�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �\�����ʂ̕ύX���s���I�u�W�F�N�g�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private List<FrePprGrTrWork> ChangeFrePprGrTrDispOrder(FrePprGrTrWork frePprGrTrWk)
        {
            List<FrePprGrTrWork> resultList = new List<FrePprGrTrWork>();
            List<FrePprGrTrWork> changeList = null;

            // �X�V���悤�Ƃ���f�[�^
            resultList.Add(frePprGrTrWk);
            // �\�����ʌJ�艺���Ώۃ��X�g�擾
            GetFrePprGrTrSequenceNumberData(out changeList, frePprGrTrWk);
            // �\�����ʌJ�艺���Ώۃ��X�g����ǉ�
            foreach (FrePprGrTrWork wkFrePprGrTrWk in changeList)
            {
                // �\�����ʂ�+1
                wkFrePprGrTrWk.DisplayOrder++;
                // �ő�\�����ʂ𒴂����Ƃ�
                if (wkFrePprGrTrWk.DisplayOrder > LAST_DISPORDER_KEYWORD)
                {
                    wkFrePprGrTrWk.DisplayOrder = LAST_DISPORDER_KEYWORD;
                }
                resultList.Add(wkFrePprGrTrWk);
            }
            return resultList;
        }

        /// <summary>
        /// �A�ԃ��R�[�h�擾����
        /// </summary>
        /// <param name="retList">���ʊi�[���X�g</param>
        /// <param name="frePprGrTrWk">�ύX�\��I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �����̃��R�[�h�ŕ\�����ʂ��p�b�f�B���O�����ꍇ�̕\�����ʌJ�艺���Ώۃ��R�[�h���擾���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void GetFrePprGrTrSequenceNumberData(out List<FrePprGrTrWork> retList, FrePprGrTrWork frePprGrTrWk)
        {
            retList = new List<FrePprGrTrWork>();
            ArrayList retwkList = new ArrayList();
            List<FrePprGrTrWork> workList = new List<FrePprGrTrWork>();
            
            //�L���b�V�����m��
            SearchCache(out retwkList, frePprGrTrWk.EnterpriseCode);

            //�ύX���K�v�ȃ��R�[�h�𒊏o
            foreach (FrePprGrTr wk in retwkList)
            {
                // �\������ >= �w��\������
                // �R�[�h != �ύX�\�背�R�[�h�̃R�[�h�i�ύX�ΏۂƓ��ꃌ�R�[�h�����O�j
                if(wk.FreePrtPprGroupCd == frePprGrTrWk.FreePrtPprGroupCd)
                    if (wk.DisplayOrder >= frePprGrTrWk.DisplayOrder)
                        if (wk.TransferCode != frePprGrTrWk.TransferCode)
                            workList.Add(CopyToFrePprGrTrWorkFromFrePprGrTr(wk));
            }
            //�\�����ʂ������Ń\�[�g
            workList.Sort(new FrePprGrTrWkDispOrderComparer());

            // ���R�[�h�����݂����Ƃ�
            int order = frePprGrTrWk.DisplayOrder;
            if (workList.Count > 0)
            {
                foreach (FrePprGrTrWork wkFrePprGrTrWk in workList)
                {
                    if (wkFrePprGrTrWk.DisplayOrder == order)
                    {
                        retList.Add(wkFrePprGrTrWk);
                        order++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        #endregion

        
        #endregion

        #region �L���b�V���֌W

        #region �L���b�V���f�[�^�擾�ݒ菈��
        /// <summary>
		/// �L���b�V���f�[�^�擾�ݒ菈��
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S���擾�����Z�b�g��Ɩ��׃f�[�^���L���b�V���Ɋi�[���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private int SetFrePprGrTrCache( string enterpriseCode)
		{
			int status = 0;
            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������

			try 
			{
				// �L���b�V���p�n�b�V���e�[�u���̃C���X�^���X�𐶐�
				this._frePprGrTrTable = new Hashtable();

			
                Object retObj;

                status = this._iFreePprGrpDB.SearchFrePprGrTrAll(out retObj, enterpriseCode, 0, ConstantManagement.LogicalMode.GetData01, out msgDiv, out errMsg);
                
                if (status == 0)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList paraList = new ArrayList();
                    paraList = retObj as ArrayList;

                    FrePprGrTrWork[] al = new FrePprGrTrWork[paraList.Count];

                    // �f�[�^�����ɖ߂�
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        al[i] = (FrePprGrTrWork)paraList[i];
                    }
                    for (int i = 0; i < al.Length; i++)
                    {
                        //�T�[�`���ʎ擾
                        FrePprGrTrWork wkFrePprGrTrWork = (FrePprGrTrWork)al[i];
                        UpdateCache((CopyToFrePprGrTrFromFrePprGrTrWork(wkFrePprGrTrWork)));
                    }
                }
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iFreePprGrpDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}
            if (msgDiv)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                    "FreePprGrpAcs", 				    // �A�Z���u���h�c�܂��̓N���X�h�c
                    "���R���[�O���[�v�A�N�Z�X�N���X", 	// �v���O��������
                    "SetFrePprGrTrCache", 			    // ��������
                    TMsgDisp.OPE_READ, 				// �I�y���[�V����
                    "�����Ɏ��s���܂����B\r\n\r\n*�ڍ� = " + errMsg, 	// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._iFreePprGrpDB, 				// �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }



            return status;
        }
        #endregion

        #region �L���b�V�����f�[�^�X�V����
        /// <summary>
		/// �L���b�V�����f�[�^�X�V����
		/// </summary>
		/// <param name="frePprGrTr">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �L���b�V�����X�V���܂�</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private void UpdateCache( FrePprGrTr frePprGrTr )
		{
			if( this._frePprGrTrTable == null )
			{
				this._frePprGrTrTable = new Hashtable();
			}
			Hashtable workCodeTable  = null;

            //�O���[�v�̃e�[�u�������݂��邩
			if( this._frePprGrTrTable.ContainsKey( frePprGrTr.FreePrtPprGroupCd) == true)
			{
				workCodeTable = ( Hashtable )this._frePprGrTrTable[ frePprGrTr.FreePrtPprGroupCd ];
			}
			else
			{
				workCodeTable = new Hashtable();
				this._frePprGrTrTable.Add( frePprGrTr.FreePrtPprGroupCd, workCodeTable );
			}
           
            workCodeTable[frePprGrTr.TransferCode] = frePprGrTr.Clone();

            //if( workCodeTable.ContainsKey( frePprGrTr.TransferCode ) )
            //{
            //    workCodeTable.Remove( frePprGrTr.TransferCode );
            //}
            //workCodeTable.Add( frePprGrTr.TransferCode, frePprGrTr.Clone() );
        }
        #endregion

        #region �L���b�V�����f�[�^�폜����
        /// <summary>
		/// �L���b�V�����f�[�^�폜����
		/// </summary>
		/// <param name="frePprGrTr">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �L���b�V�����f�[�^����w�肳�ꂽ���R���[�O���[�v�U�փI�u�W�F�N�g���폜���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private void RemoveCache( FrePprGrTr frePprGrTr )
		{
			if( this._frePprGrTrTable == null ) 
			{
				// �f�[�^�����݂��Ă��Ȃ�
				return;
			}

			Hashtable workCodeTable  = null;

			// �n�b�V���e�[�u���Ɏ��R���[�O���[�v�U�ւ��o�^����Ă��邩�H
			if( this._frePprGrTrTable.ContainsKey( frePprGrTr.FreePrtPprGroupCd ) == false ) 
			{
				// �f�[�^�����݂��Ă��Ȃ�
				return;
			}

			workCodeTable = ( Hashtable )this._frePprGrTrTable[ frePprGrTr.FreePrtPprGroupCd ];

			if( workCodeTable.ContainsKey( frePprGrTr.TransferCode ) == false ) 
			{
				// �f�[�^�����݂��Ă��Ȃ�
				return;
			}

			// �f�[�^���폜
			workCodeTable.Remove( frePprGrTr.TransferCode );
        }
        #endregion

        #region �L���b�V�����f�[�^��������
        /// <summary>
		/// �L���b�V�����f�[�^��������(�O���[�v�R�[�h��)
		/// </summary>
		/// <param name="retList">�������ʃ��X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
		/// <param name="logicalMode">�폜�敪</param>
		/// <br>Note       : �L���b�V�����f�[�^����f�[�^�̌������s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// <returns></returns>
		private int SearchCache( out ArrayList retList, string enterpriseCode, Int32 freePrtPprGroupCd, ConstantManagement.LogicalMode logicalMode )
		{
			int status = 0;

			retList = new ArrayList();
			retList.Clear();

			// �L���b�V�������݂��Ă��Ȃ��Ƃ�
			if( this._frePprGrTrTable == null ) 
			{
				// �L���b�V���f�[�^���擾
				status = SetFrePprGrTrCache( enterpriseCode );
				switch( status ) 
				{
					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					{
						return status;
					}
					default:
					{
						return status;
					}
				}
			}

			if( this._frePprGrTrTable.ContainsKey( freePrtPprGroupCd ) == true ) 
			{
				Hashtable retHashTable = ( Hashtable )this._frePprGrTrTable[ freePrtPprGroupCd ];
				// �_���폜����Ă��Ȃ����R�[�h�̂�
				if( logicalMode == 0)
				{
					foreach( FrePprGrTr frePprGrTr in retHashTable.Values ) 
					{
						if( frePprGrTr.LogicalDeleteCode == 0 )
						{
							retList.Add( frePprGrTr.Clone() );
						}
					}
				}	
				else
				{
					foreach( FrePprGrTr frePprGrTr in retHashTable.Values ) 
					{
						retList.Add( frePprGrTr.Clone() );
					}
				}
			}
			
			if( retList.Count > 0 ) 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
			}

			// �\�����ʏ��ʕ��ёւ�
			retList.Sort(new FrePprGrTrDispOrderComparer() );
			return status;
        }

        /// <summary>
        /// �L���b�V�����f�[�^��������(�S���擾)
        /// </summary>
        /// <param name="retList">�������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <br>Note       : �L���b�V�����f�[�^����f�[�^�̌������s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.03</br>
        /// <returns></returns>
        private int SearchCache(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            // �L���b�V�������݂��Ă��Ȃ��Ƃ�
            if (this._frePprGrTrTable == null)
            {
                // �L���b�V���f�[�^���擾
                status = SetFrePprGrTrCache(enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            return status;
                        }
                    default:
                        {
                            return status;
                        }
                }
            }

            // �O���[�v�R�[�h���Ƃ̃n�b�V��
            foreach (Hashtable retHashTable in _frePprGrTrTable.Values)
            {
                foreach (FrePprGrTr frePprGrTr in retHashTable.Values)
                {
                    retList.Add(frePprGrTr.Clone());
                }
            }
        
            if (retList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            // �\�����ʏ��ʕ��ёւ�
            retList.Sort(new FrePprGrTrDispOrderComparer());
            return status;
        }
        #endregion

        #endregion

        #region �\�[�g�N���X
        /// <summary>
		/// ���R���[�O���[�v�ݒ薾�ו\�����ʔ�r�p�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : IComparable �C���^�[�t�F�C�X�̎����B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public class FrePprGrTrDispOrderComparer : IComparer
		{
			/// <summary>
			/// ���R���[�O���[�v�ݒ薾�ו\�����ʔ�r���\�b�h
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <remarks>
			/// <br>Note       : x��y���r���A�������Ƃ��̓}�C�i�X�A</br>
			/// <br>           : �傫���Ƃ��̓v���X�A�����Ƃ��̓[����Ԃ��܂��B</br>
			/// <br>Programmer : 22011 ���� ���l</br>
			/// <br>Date       : 2007.04.03</br>
			/// </remarks>
			public int Compare(object x, object y) 
			{
				FrePprGrTr px = ( FrePprGrTr )x;
				FrePprGrTr py = ( FrePprGrTr )y;
				return (px.DisplayOrder - py.DisplayOrder);
			}
		}

        /// <summary>
        /// ���R���[�O���[�v�U�փ��[�N�\�����ʔ�r�p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : IComparable �C���^�[�t�F�C�X�̎����B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.03</br>
        /// </remarks>
        public class FrePprGrTrWkDispOrderComparer : IComparer<FrePprGrTrWork>
        {
            /// <summary>
            /// ���R���[�O���[�v�U�փ��[�N�\�����ʔ�r���\�b�h
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <remarks>
            /// <br>Note       : x��y���r���A�������Ƃ��̓}�C�i�X�A</br>
            /// <br>           : �傫���Ƃ��̓v���X�A�����Ƃ��̓[����Ԃ��܂��B</br>
            /// <br>Programmer : 22011 ���� ���l</br>
            /// <br>Date       : 2007.04.03</br>
            /// </remarks>
            public int Compare(FrePprGrTrWork x, FrePprGrTrWork y)
            {
                FrePprGrTrWork px = x;
                FrePprGrTrWork py = y;
                return (px.DisplayOrder - py.DisplayOrder);
            }
        }
		#endregion
	}
}