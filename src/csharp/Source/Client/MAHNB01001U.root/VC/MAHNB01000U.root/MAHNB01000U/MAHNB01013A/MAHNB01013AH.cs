using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l�擾�f�[�^������s���܂��B</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataSixthAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataSixthAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataSixthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataSixthAcs == null)
            {
                _delphiSalesSlipInputInitDataSixthAcs = new DelphiSalesSlipInputInitDataSixthAcs();
            }
            return _delphiSalesSlipInputInitDataSixthAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataSixthAcs _delphiSalesSlipInputInitDataSixthAcs;
        private List<PriceSelectSet> _displayDivList = null;              // �\���敪���X�g
        private List<NoteGuidBd> _noteGuidList = null;              // ���l�K�C�h�S�����X�g
        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        # endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataSixth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ���\���敪�}�X�^ PMHNB09003A
            PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
            status = priceSelectSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])aList.ToArray(typeof(PriceSelectSet))); ;
            }
            else
            {
                this._displayDivList = new List<PriceSelectSet>();
            }
            #endregion

            #region �����l�K�C�h�}�X�^�A�N�Z�X�N���X SFTOK09402A
            NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
            noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
            this._noteGuidList = new List<NoteGuidBd>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
            }
            #endregion

            return 0;
        }
        #endregion

        public List<PriceSelectSet> GetDisplayDivList()
        {
            return this._displayDivList;
        }
        public List<NoteGuidBd> GetNoteGuidList()
        {
            return this._noteGuidList;

        }
    }
}
