//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M�������O�����e��ʃA�N�Z�X�N���X
// �v���O�����T�v   : ���M�������O�����e��ʃA�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �� �� ��  2011/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/24  �C�����e : Redmine #23930�@�\�[�X���r���[���ʑΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���M�������O�����e��ʃA�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : ���M�������O�����e��ʃA�N�Z�X�N���X<br />
    /// Programmer : �����Y<br />
    /// Date       : 2011/08/01<br />
    /// Update     : <br />
    /// </remarks>
    public partial class SndRcvHisAcs
    {
        # region �� Constructor ��
        public SndRcvHisAcs()
        {
            _ISndRcvHisRFDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
        }
        #endregion �� Constructor ��

        #region �� Private Field ��
        private ISndRcvHisDB _ISndRcvHisRFDB = null;
        #endregion �� Private Field ��

        #region �� Public Method ��
        /// <summary>
        /// ����M�������O�߂�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="sndRcvHisCondWork">����M�������O�f�[�^���[�N</param>
        /// <param name="searchResult">���LIST</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        public int Serch(SndRcvHisCondWork sndRcvHisCondWork, out object searchResult)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            searchResult = new object(); //searchResult1 as object;

            try
            {
                status = this._ISndRcvHisRFDB.Search(sndRcvHisCondWork, out searchResult);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
				//MessageBox.Show(ex.ToString());// DEL 2011.08.24
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ����M�������O�f�[�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="sndRcvHisWorkList">�폜���鑗��M�������O�f�[�^���܂�ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        public int Delete(ref object sndRcvHisWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                status = this._ISndRcvHisRFDB.Delete(ref sndRcvHisWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
				//MessageBox.Show(ex.ToString());// DEL 2011.08.24
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

		// ADD 2011.08.24 ------------->>>>>
		/// <summary>
		/// ���_�����擾
		/// </summary>
		/// <param name="sectionCode"></param>
		/// <returns></returns>
		public string GetSetctionName(string sectionCode)
		{
			string sectionName = null;

			SecInfoAcs secInfoAcs = new SecInfoAcs();
			try
			{
				foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
					{
						sectionName = secInfoSet.SectionGuideNm.Trim();
						break;
					}
				}
			}
			catch
			{
				sectionName = string.Empty;
			}

			return sectionName;
		}

		/// <summary>
		/// DateTime�̓�����String�ɂ���
		/// </summary>
		/// <param name="dateTime">DateTime�̓���</param>
		/// <returns>String�̓���</returns>
		/// <remarks>
		/// <br>Note       : DateTime�̓�����String�ɂ���</br>
		/// <br>Programmer : �����Y</br>
		/// <br>Date       : 2011/08/01</br>
		/// </remarks>
		public string DateTimeFormatToString(DateTime dateTime)
		{
			string time = null;
			time += dateTime.Year + "�N";
			time += dateTime.Month + "��";
			time += dateTime.Day + "��";
			time += dateTime.Hour + "��";
			time += dateTime.Minute + "��";
			time += dateTime.Second + "�b";

			return time;
		}
		// ADD 2011.08.24 -------------<<<<<
        #endregion �� Public Method ��
    }
}