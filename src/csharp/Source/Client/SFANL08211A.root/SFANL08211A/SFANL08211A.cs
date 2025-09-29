using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;				
using Broadleaf.Application.Remoting.ParamData;	
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[�O���[�v�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�O���[�v�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 22011 ���� ���l</br>
	/// <br>Date       : 2007.07.27</br>
    /// <br>Update Note: </br>
    /// <br>             </br>
    /// </remarks>
	public class FrePprDailyAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IFrePDailyExtRetDB _iFrePDailyExtRetDB = null;
		
        #region Constructor
        /// <summary>
		/// ���R���[�O���[�v�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.07.27</br>
		/// </remarks>
        public FrePprDailyAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iFrePDailyExtRetDB = MediationFrePDailyExtRetDB.GetFrePDailyExtRetDB();
         	}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iFrePDailyExtRetDB = null;
			}
        }
        #endregion

        #region ���R���[�O���[�v���������i�_���폜�敪�͖����j
        /// <summary>
		/// ���R���[�O���[�v���������i�_���폜�敪�͖����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="frePExtPrmWk">���R���[���ʒ��o�p�����[�^�N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.07.27</br>
		/// </remarks>
		public int Search(out List<FrePDailyExtRetWork> retList, FrePrtCmnExtPrmWork frePExtPrmWk)
		{
			return SearchProc(out retList, frePExtPrmWk, ConstantManagement.LogicalMode.GetData01);
        }
        #endregion

        #region ���R���[�O���[�v��������
        /// <summary>
		/// ���R���[�O���[�v��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="frePExtPrmWk"></param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�O���[�v�̌����������s���܂��B</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.07.27</br>
		/// </remarks>
		private int SearchProc(out List<FrePDailyExtRetWork> retList,
			FrePrtCmnExtPrmWork frePExtPrmWk,
			ConstantManagement.LogicalMode logicalMode)
		{
            retList = new List<FrePDailyExtRetWork>();
            Object retObj;
            Object paraObj = XmlByteSerializer.Serialize(frePExtPrmWk);

            bool msgDiv = false;       //���b�Z�[�W�L���敪
            string errMsg = "";     //�G���[���b�Z�[�W������

            // ���R���[�O���[�v����
            int status = 0;
            status = this._iFrePDailyExtRetDB.Search(paraObj, out retObj, out msgDiv, out errMsg);

            if (status == 0)
            {
                // �p�����[�^���n���ė��Ă��邩�m�F
                retList = retObj as List<FrePDailyExtRetWork>;
            }
            if (msgDiv == true)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP, 		                // �G���[���x��
                    "FrePprDailyAcs", 				                    // �A�Z���u���h�c�܂��̓N���X�h�c
                    "���R���[�������[�O���[�v�A�N�Z�X�N���X", 	        // �v���O��������
                    "SearchProc", 			                            // ��������
                    TMsgDisp.OPE_READ, 		    		                // �I�y���[�V����
                    "�����Ɏ��s���܂����B\r\n\r\n*�ڍ� = " + errMsg, 	// �\�����郁�b�Z�[�W
                    status, 							                // �X�e�[�^�X�l
                    this._iFrePDailyExtRetDB, 				            // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				                // �\������{�^��
                    MessageBoxDefaultButton.Button1);	                // �����\���{�^��
            }
			return status;
        }
        #endregion

        #region ���R���[�O���[�vList�N���X�f�V���A���C�Y���� DEL
        ///// ********************************************************************
        ///// <summary>
        ///// ���R���[�O���[�vList�N���X�f�V���A���C�Y����
        ///// </summary>
        ///// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        ///// <returns>���R���[�O���[�v�N���XLIST</returns>
        ///// <remarks>
        ///// <br>Note       : ���R���[�O���[�v���X�g�N���X���f�V���A���C�Y���܂��B</br>
        ///// <br>Programmer : 22011 ���� ���l</br>
        ///// <br>Date       : 2007.07.27</br>
        ///// </remarks>
        ///// ********************************************************************
        //public List<FrePDailyExtRetWork> FreePprGrpListDeserialize(string fileName)
        //{
        //    ArrayList al = new ArrayList();

        //    // �t�@�C������n���Ď��R���[�O���[�v���[�N�N���X���f�V���A���C�Y����
        //    FrePDailyExtRetWork[] frePDailyExtRetWorks;
        //    frePDailyExtRetWorks = (FrePDailyExtRetWork[])XmlByteSerializer.Deserialize(fileName, typeof(FrePDailyExtRetWork[]));

        //    //�f�V���A���C�Y���ʂ����R���[�O���[�v�t�h�N���X�փR�s�[
        //    if (frePDailyExtRetWorks != null) 
        //    {
        //        al.Capacity = frePDailyExtRetWorks.Length;
        //        for(int i=0; i < frePDailyExtRetWorks.Length; i++)
        //        {
        //            al.Add(frePDailyExtRetWorks[i]);
        //        }
        //    }
        //    return al;
        //}
        //#endregion

        //#region ���R���[�O���[�vList�V���A���C�Y����
        ///// *****************************************************************
        ///// <summary>
        ///// ���R���[�O���[�vList�V���A���C�Y����
        ///// </summary>
        ///// <param name="frePDailyExtRetWork">�V���A���C�Y�Ώێ��R���[�O���[�vList�N���X</param>
        ///// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        ///// <remarks>
        ///// <br>Note       : ���R���[�O���[�vList���̃V���A���C�Y���s���܂��B</br>
        ///// <br>Programmer : 22011 ���� ���l</br>
        ///// <br>Date       : 2007.04.27</br>
        ///// </remarks>
        ///// ******************************************************************
        //public void FreePprGrpListSerialize(List<FrePDailyExtRetWork> frePDailyExtRetWork, string fileName)
        //{
        //    FrePDailyExtRetWork[] frePDailyExtRetWorks = new FrePDailyExtRetWork[frePDailyExtRetWork.Count];
        //    //���R���[�O���[�v���[�J�[�N���X���V���A���C�Y
        //    XmlByteSerializer.Serialize(frePDailyExtRetWorks, fileName);
        //}
        #endregion
	}
}