//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ��ꊇ�����ϊ�����
// �v���O�����T�v   : �����𖞂������f�[�^���e�L�X�g�t�@�C���֏o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/16   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �i�ԕϊ��ꊇ����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �i�ԕϊ��ꊇ�����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsChgAllDB : RemoteDB, IMeijiGoodsChgAllDB
    {
        /// <summary>
        /// �i�ԕϊ��ꊇ����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsChgAllDB()
        {
        }

        #region [�i�ԕϊ��}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̕i�ԕϊ��}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeMst(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt, out int loadCnt, out int errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;
            loadCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;

            // �i�ԕϊ��}�X�^
            MeijiGoodsChgMstDB meijiGoodsChgMstDB = new MeijiGoodsChgMstDB();
            status = meijiGoodsChgMstDB.ImportFile(goodsChangeAllCndWorkWork, out addUpdWorkObj, out dataObjectList, out readCnt, out loadCnt, out errCnt, out errMsg);
            
            return status;
        }
        #endregion

        #region [���i�݌Ƀ}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�݌Ƀ}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̕i���i�݌Ƀ}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        /// </remarks>
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�----->>>>>
        //public int GoodsChangeGoodsStock(object goodsChangeAllCndWorkWork, out object goodsSucObj, out object goodsErrObj, out object priceSucObj, out object priceErrObj,
        //    out object stockSucObj, out object stockErrObj, out int goodsReadCnt, out Int32 priceReadCnt, out Int32 stockReadCnt)
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        public int GoodsChangeGoodsStock(object goodsChangeAllCndWorkWork, out object goodsSucObj, out object goodsErrObj, out int goodsReadCnt, out int priceReadCnt, out int stockReadCnt)
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            goodsSucObj = null;
            goodsErrObj = null;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�----->>>>>
            //priceSucObj = null;
            //priceErrObj = null;
            //stockSucObj = null;
            //stockErrObj = null;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            goodsReadCnt = 0;
            priceReadCnt = 0;
            stockReadCnt = 0;

            // ���i�݌Ƀ}�X�^
            MeijiGoodsStockDB meijiGoodsStockDB = new MeijiGoodsStockDB();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�----->>>>>
            //status = meijiGoodsStockDB.WriteGoods(out goodsSucObj, out goodsErrObj, out priceSucObj, out priceErrObj, out stockSucObj, out stockErrObj, out goodsReadCnt, out priceReadCnt,
            //    out stockReadCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode, cndWork);
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            status = meijiGoodsStockDB.WriteGoods(out goodsSucObj, out goodsErrObj, out goodsReadCnt, out priceReadCnt, out stockReadCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode, cndWork);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            return status;
        }
        #endregion

        #region [���i�Ǘ����}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeGoodsMng(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // ���i�Ǘ����}�X�^
            MeijiGoodsMngDB meijiGoodsMngDB = new MeijiGoodsMngDB();
            status = meijiGoodsMngDB.WriteIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);

            return status;
        }
        #endregion

        #region [�|���}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̊|���}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeRate(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // �|���}�X�^
            MeijiRateDB meijiRateDB = new MeijiRateDB();
            status = meijiRateDB.WriteIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            return status;
        }
        #endregion

        #region [�����}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̌����}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌����}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeJoin(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // �����}�X�^
            MeijiJoinPartsDB meijiJoinPartsDB =  new MeijiJoinPartsDB();
            status = meijiJoinPartsDB.ReadIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            
            return status;
        }
        #endregion    
            
        #region [��փ}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̑�փ}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑�փ}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeParts(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // ��փ}�X�^
            MeijiPartsSubstDB meijiPartsSubstDB = new MeijiPartsSubstDB();
            status = meijiPartsSubstDB.WriteIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            
            return status;
        }
        #endregion

        #region [�Z�b�g�}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̃Z�b�g�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃Z�b�g�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeSet(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // �Z�b�g�}�X�^
            MeijiGoodsSetChgDB meijigoodsSetChgDB = new MeijiGoodsSetChgDB();
            status = meijigoodsSetChgDB.ReadIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            
            return status;
        }
        #endregion   
 
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        #region [�D�ǐݒ�}�X�^]
        /// <summary>
        /// �w�肳�ꂽ�����̗D�ǐݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̗D�ǐݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        //public int PrmSettingChange(object goodsChangeAllCndWorkWork, out object sucObjectList, out object errObjectList, out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        public int PrmSettingChange(object goodsChangeAllCndWorkWork, Dictionary<string, PrmSettingWork> offerPrmDic, out object sucObjectList, out object errObjectList, // ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή� 
            out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�    
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            sucObjectList = null;
            errObjectList = null;
            readCnt = 0;
            loginCnt = 0;
            errMsg = string.Empty;
            csvErr = false;

            // �D�ǐݒ�}�X�^
            MeijiPrmSettingDB meijiPrmSettingDB = new MeijiPrmSettingDB();
            //status = meijiPrmSettingDB.PrmSettingChange(goodsChangeAllCndWorkWork, out sucObjectList, out errObjectList, out readCnt, out loginCnt, out errMsg, out csvErr);// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            status = meijiPrmSettingDB.PrmSettingChange(goodsChangeAllCndWorkWork, offerPrmDic, out sucObjectList, out errObjectList, out readCnt, out loginCnt, out errMsg, out csvErr);// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�

            return status;
        }
        #endregion
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        #region [�ݏo�ϊ�����]
        /// <summary>
        /// �w�肳�ꂽ�����̑ݏo�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑ݏo�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int ShipmentChange(object goodsChangeAllCndWorkWork, out object sucObjectList, out object errObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            sucObjectList = null;
            errObjectList = null;
            readCnt = 0;

            // �ݏo�f�[�^�X�V����
            ShipmentChangeDB shipmentChangeDB = new ShipmentChangeDB();
            status = shipmentChangeDB.ShipmentChange(cndWork, out sucObjectList, out errObjectList, out readCnt);

            return status;
        }
        #endregion        
        
    }
}
