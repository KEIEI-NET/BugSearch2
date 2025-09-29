using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BL�R�[�h�ϊ��}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�ϊ��}�X�^�̐���S�ʂ��s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009.07.30</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.30 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    public class BLCodeChangeAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Private Members
        static BLCodeChangeAcs _blCodeChangeAcs;
        private ITbsPartsCdChgDB _iTbsPartsCdChgDB;
        #endregion

        // ===================================================================================== //
        // �O���ɒ񋟂���萔�Q
        // ===================================================================================== //
        # region ��Public Readonly Members
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        public BLCodeChangeAcs()
        {
            this._iTbsPartsCdChgDB = (ITbsPartsCdChgDB)MediationTbsPartsCdChgDB.GetTbsPartsCodeDB();
        }
        #endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region ��Delegete
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��Events
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties
        ///// <summary>�d�����v���p�e�B</summary>
        //public StockTemp StockTemp
        //{
        //    get { return this._stockTemp; }
        //    set { this._stockTemp = value; }
        //}

        ///// <summary>���㖾�׃f�[�^�s�I�u�W�F�N�g</summary>
        //public SalesInputDataSet.SalesDetailRow SalesDetailRow
        //{
        //    get { return _salesDetailRow; }
        //    set { _salesDetailRow = value; }
        //}

        ///// <summary>���i�A�����f�B�N�V���i��</summary>
        //public Dictionary<SalesSlipInputAcs.GoodsInfoKey, GoodsUnitData> GoodsUnitDataInfo
        //{
        //    get { return this._goodsUnitDataInfo; }
        //    set { this._goodsUnitDataInfo = value; }
        //}
        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� Enums
        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��Public Methods
        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^��������
        /// </summary>
        /// <param name="?"></param>
        /// <param name="paraTbsPartsCdChgWork"></param>
        /// <returns></returns>
        public int Search(out List<TbsPartsCdChgWork> retTbsPartsCdChgWorkList, TbsPartsCdChgWork paraTbsPartsCdChgWork)
        {
            ArrayList al = new ArrayList();
            al.Add(paraTbsPartsCdChgWork);
            object parabyte = al;
            object objtbsPartsCode;
            ArrayList retTbsPartsCodeArrayList;
            retTbsPartsCdChgWorkList = null;

            int status = _iTbsPartsCdChgDB.Search(out objtbsPartsCode, parabyte);

            if (objtbsPartsCode != null)
            {
                retTbsPartsCodeArrayList = (ArrayList)objtbsPartsCode;
                retTbsPartsCdChgWorkList = new List<TbsPartsCdChgWork>((TbsPartsCdChgWork[])retTbsPartsCodeArrayList.ToArray(typeof(TbsPartsCdChgWork)));
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        #endregion

        // ===================================================================================== //
        // �X�^�e�B�b�N���\�b�h
        // ===================================================================================== //
        #region ��Static Methods
        #endregion

    }
}
