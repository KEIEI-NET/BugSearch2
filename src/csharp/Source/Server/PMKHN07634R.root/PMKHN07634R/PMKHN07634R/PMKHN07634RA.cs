//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/06/24  �C�����e : ���i�Ǘ������̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/03/31  �C�����e : Mantis.15256 ���i�}�X�^�C���|�[�g�̑Ώۍ��ڐݒ�Ή�
//                       �C�����e : Mantis.15272 ���i�}�X�^�̍X�V�ɂ��āA��ʂ̏����敪�����f����Ă��Ȃ����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/12  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/26  �C�����e : ���������o�b�O�̑Ή��F�����`�F�b�N���A�S�p�������ꌅ�Ɍv�Z����悤�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/03  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/05  �C�����e : ��z�Č��ARedmine#30387 ��Q�ꗗ�̎w�ENO.19�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/10  �C�����e : ��z�Č��ARedmine#30387 ��Q�ꗗ�̎w�ENO.55�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/07/12  �C�����e : ��z�Č��ARedmine#30387 ��Q�ꗗ�̎w�ENO.93�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/25  �C�����e : ��z�Č��ARedmine#30387 �G���[���b�Z�[�W�̕ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/07/26  �C�����e : Redmine#30387  ��Q�ꗗ�̎w�ENO.94�̑Ή� �G���[���b�Z�[�W�̕ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : liusy
// �C �� ��  2013/06/14  �C�����e : Redmine#35805 
//                                  ���i�}�X�^�C���|�[�g OutOfMemory Exception(�C�X�R GC�T�[�o���[�h)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175183-00 �쐬�S�� : �c����
// �C �� ��  2015/05/20  �C�����e : Redmine#45693
//                                    �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175183-00 �쐬�S�� : �c����
// �C �� ��  2015/07/24  �C�����e : Redmine#45693
//                                  �C�X�R�@���i�}�X�^�C���|�[�g ���i�}�X�^�Ɖ��i�}�X�^���ꎞ�e�[�u����JOIN���Č�������ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175183-00 �쐬�S�� : �c����
// �C �� ��  2015/08/22  �C�����e : Redmine#45693 �ꎞ�e�[�u���̍폜�^�C�~���O��ύX����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175183-00 �쐬�S�� : �c����
// �C �� ��  2015/08/26  �C�����e : ���i�}�X�^/���i�}�X�^�̌��������ɁA����CSV�̃f�[�^��DB�ɑ��݂��Ȃ��ꍇ�A���̏������I�����Ȃ��āAstatus�̔��f���폜����
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions; // ADD wangf 2012/06/12 FOR Redmine#30387
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
//using Broadleaf.Library.Globarization; // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Globalization; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: 2012/07/20 wangf </br>
    /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
    /// <br>Update Note: 2012/07/25 wangf </br>
    /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �G���[���b�Z�[�W�̕ύX�̑Ή�</br>
    /// <br>Update Note: 2012/07/26 ������</br>
    /// <br>             10801804-00�A��z�Č��ARedmine#30387  ��Q�ꗗ�̎w�ENO.94�̑Ή� �G���[���b�Z�[�W�̕ύX�̑Ή�</br>
    /// <br>Update Note: 2013/06/14 liusy</br>
    /// <br>             10801804-00�ARedmine#35805 ���i�}�X�^�C���|�[�g OutOfMemory Exception(�C�X�R GC�T�[�o���[�h)</br>
    /// <br>Update Note: 2015/05/20 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�</br>
    /// <br>           : �@���i�}�X�^�Ɖ��i�}�X�^�̑S��������p�~���ACSV�̃��[�J�[�ŕ������Č�������悤�ɕύX</br>
    /// <br>           : �A���i�}�X�^�Ɖ��i�}�X�^��Dictionary��KEY���N���X�̌^����String�̌^�֕ύX</br>
    /// <br>           : �B�g�p���Ȃ�List��Dictionary���N���A����</br>
    /// <br>           : �C��d���[�v�̔p�~���Aforeach�̑����Dictionary���g�p����</br>
    /// <br>           : �D������Q�F�����敪�u�ǉ��v�̏ꍇ�A�s��̑Ή�</br>
    /// <br>Update Note: 2015/07/24 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g ���i�}�X�^�Ɖ��i�}�X�^���ꎞ�e�[�u����JOIN���Č�������ύX</br>
    /// <br>Update Note: 2015/08/22 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 �ꎞ�e�[�u���̍폜�^�C�~���O��ύX����</br>
    /// <br>Update Note: 2015/08/26 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11175183-00</br>
    /// <br>           : Redmine#45693 ���i�}�X�^/���i�}�X�^�̌��������ɁA����CSV�̃f�[�^��DB�ɑ��݂��Ȃ��ꍇ�A���̏������I�����Ȃ��āAstatus�̔��f���폜����</br>
    /// </remarks>
    [Serializable]
    public class GoodsUImportDB : RemoteDB, IGoodsUImportDB
    {
        /// <summary>
        /// ���i�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public GoodsUImportDB()
            : base("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "GOODSURF")
        {
        }

        # region [Import]
        /// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="importGoodsWorkList">���i�}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="importGoodsPriceWorkList">���i�}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="importGoodsUGoodsPriceUWorkList">���i�E���i���[�N�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="importSetUpList">�C���|�[�g�Ώېݒ胊�X�g</param>
        /// <param name="paraPriceStartDate">���i�J�n�N����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/03 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        // 2010/03/31 >>>
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList) // DEL wangf 2012/06/12 FOR Redmine#30387
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList, ref DataTable table, DateTime paraPriceStartDate) // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
        public int Import(Int32 processKbn, Int32 dataCheckKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/20 FOR Redmine#30387
        // 2010/03/31 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;
            /* ------------DEL wangf 2012/07/03 FOR Redmine#30387--------->>>>
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            if (table == null)
            {
                table = new DataTable();
                CreateDataTable(ref table);
            }
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
            // ------------DEL wangf 2012/07/03 FOR Redmine#30387---------<<<<*/
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // �C���|�[�g����
                // 2010/03/31 >>>
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction);
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList); // DEL wangf 2012/06/12 FOR Redmine#30387
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, ref importGoodsUGoodsPriceUWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList, ref table, paraPriceStartDate); // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, ref importGoodsUGoodsPriceUWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList, paraPriceStartDate); // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
                status = this.ImportProc(processKbn, dataCheckKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, ref importGoodsUGoodsPriceUWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList, paraPriceStartDate); // ADD wangf 2012/07/20 FOR Redmine#30387
                // 2010/03/31 <<<
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="importGoodsWorkList">���i�}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="importGoodsPriceWorkList">���i�}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="importGoodsUGoodsPriceUWorkList">���i�E���i���[�N�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R���N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="importSetUpList">�C���|�[�g�Ώېݒ胊�X�g</param>
        /// <param name="paraPriceStartDate">���i�J�n�N����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note : 2012/07/03 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note : 2012/07/05 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ��Q�ꗗ�̎w�ENO.19�̑Ή�</br>
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// <br>Update Note : 2013/06/14 liusy</br>
        /// <br>             10801804-00�ARedmine#35805 ���i�}�X�^�C���|�[�g OutOfMemory Exception(�C�X�R GC�T�[�o���[�h)</br>
        /// <br>Update Note : 2015/05/20 �c����</br>
        /// <br>�Ǘ��ԍ�    : 11175183-00</br>
        /// <br>            : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g OutOfMemory�����Ή�</br>
        /// <br>Update Note : 2015/07/24 �c����</br>
        /// <br>�Ǘ��ԍ�    : 11175183-00</br>
        /// <br>            : Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g ���i�}�X�^�Ɖ��i�}�X�^���ꎞ�e�[�u����JOIN���Č�������ύX</br>
        /// <br>Update Note : 2015/08/22 �c����</br>
        /// <br>�Ǘ��ԍ�    : 11175183-00</br>
        /// <br>            : Redmine#45693 �ꎞ�e�[�u���̍폜�^�C�~���O��ύX����</br>
        /// <br>Update Note : 2015/08/26 �c����</br>
        /// <br>�Ǘ��ԍ�    : 11175183-00</br>
        /// <br>            : Redmine#45693 ���i�}�X�^/���i�}�X�^�̌��������ɁA����CSV�̃f�[�^��DB�ɑ��݂��Ȃ��ꍇ�A���̏������I�����Ȃ��āAstatus�̔��f���폜����</br>
        // 2010/03/31 >>>
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList) // DEL wangf 2012/06/12 FOR Redmine#30387
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList, ref DataTable table, DateTime paraPriceStartDate) // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
        private int ImportProc(Int32 processKbn, Int32 dataCheckKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/20 FOR Redmine#30387
        // 2010/03/31 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //----- ADD 2015/07/24 �c���� Redmine#45693 ---------->>>>>
            SqlCommand sqlCommand = null;
            string goodsTblName = string.Empty;
            //----- ADD 2015/07/24 �c���� Redmine#45693 ----------<<<<<

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            ArrayList GoodsUList = new ArrayList();
            ArrayList GoodsPriceUList = new ArrayList();
            GoodsUWork paraGoodsUWork = new GoodsUWork();
            GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
            List<int[]> setUpInfoList = (List<int[]>)importSetUpList;// 2010/03/31 Add
            
            // ���i�}�X�^�̓o�^�t���O
            bool isAddUpdFlg = false;

            // ���i�}�X�^��DB�����[�g�N���X
            GoodsUDB GoodsUDB = new GoodsUDB();
            // ���i�}�X�^��DB�����[�g�N���X
            GoodsPriceUDB GoodsPriceUDB = new GoodsPriceUDB();
            // ADD 2009/06/24 --->>>
            // �񋟃f�[�^�X�V�ݒ��DB�����[�g�N���X
            PriceChgProcStDB PriceChgProcStDB = new PriceChgProcStDB();
            Int32 priceMngCnt = 0;
            // ADD 2009/06/24 ---<<<
            /* ------------DEL wangf 2012/07/03 FOR Redmine#30387--------->>>>
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            // ���Џ��ݒ��DB�����[�g�N���X
            CompanyInfDB companyInfDB = new CompanyInfDB();
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
            // ------------DEL wangf 2012/07/03 FOR Redmine#30387---------<<<<*/
            try
            {
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                // ���i�E���i���[�N
                ArrayList importGoodsGoodsPriceWorkArray = importGoodsUGoodsPriceUWorkList as ArrayList;
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                List<GoodsUGoodsPriceUWork> goodsUGoodsPriceUWorkCheckList = new List<GoodsUGoodsPriceUWork>();
                GoodsUGoodsPriceUWork[] arr = (GoodsUGoodsPriceUWork[])importGoodsGoodsPriceWorkArray.ToArray(typeof(GoodsUGoodsPriceUWork));
                goodsUGoodsPriceUWorkCheckList.AddRange(arr);
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                if (importGoodsGoodsPriceWorkArray == null || importGoodsGoodsPriceWorkArray.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                // �p�����[�^�̐ݒ�
                // ���i�}�X�^�̃p�����[�^�̐ݒ�
                ArrayList importGoodsWorkArray = importGoodsWorkList as ArrayList;
                if (importGoodsWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    paraGoodsUWork.EnterpriseCode = ((GoodsUWork)importGoodsWorkArray[0]).EnterpriseCode;
                }
                // ���i�}�X�^�̃p�����[�^�̐ݒ�
                ArrayList importGoodsPriceWorkArray = importGoodsPriceWorkList as ArrayList;
                if (importGoodsPriceWorkArray != null && importGoodsPriceWorkArray.Count > 0)
                {
                    paraGoodsPriceUWork.EnterpriseCode = ((GoodsPriceUWork)importGoodsPriceWorkArray[0]).EnterpriseCode;
                }
                // ADD 2009/06/24 --->>>
                ArrayList addUpdGoodsUList = new ArrayList();
                // �񋟃f�[�^�X�V�ݒ�̃p�����[�^�̐ݒ�
                PriceChgProcStWork priceChgProcStWork = new PriceChgProcStWork();
                priceChgProcStWork.EnterpriseCode = paraGoodsUWork.EnterpriseCode;
                // ADD 2009/06/24 ---<<<

                //----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                //// �S�������������s��
                //// �S�ď��i�}�X�^�̃f�[�^�̌�������
                //GoodsUDB.SearchGoodsUProc(out GoodsUList, paraGoodsUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);

                //// �S�ĉ��i�}�X�^�̃f�[�^�̌�������
                //GoodsPriceUDB.SearchGoodsPriceProc(out GoodsPriceUList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<

                //----- ADD 2015/08/22 �c���� Redmine#45693 ---------->>>>>
                try
                {
                    //----- ADD 2015/08/22 �c���� Redmine#45693 ----------<<<<<
                    //----- ADD 2015/07/24 �c���� Redmine#45693 ---------->>>>>
                    // �@CSV�̏��i�i��ƃR�[�h�E���[�J�[�E�i�ԁj���ꎞ�e�[�u���Ɋi�[����
                    string tableNameGuid = Guid.NewGuid().ToString();
                    goodsTblName = "##GOODSM_" + tableNameGuid.Replace('-', '_');

                    string sqlText = "CREATE TABLE " + goodsTblName + " ( ENTERPRISECODERF nchar(16) COLLATE DATABASE_DEFAULT NOT NULL, GOODSMAKERCDRF int NOT NULL, GOODSNORF nvarchar(40) COLLATE DATABASE_DEFAULT NOT NULL) ";
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.ExecuteNonQuery();

                    // CSV�̃f�[�^��DataTable�ɓ]������
                    string enterpriseCode = "ENTERPRISECODERF";
                    string goodsMakerCode = "GOODSMAKERCDRF";
                    string goodsNo = "GOODSNORF";

                    DataTable dt = new DataTable();
                    // ��ƃR�[�h
                    DataColumn col01 = new DataColumn(enterpriseCode, typeof(string));
                    dt.Columns.Add(col01);
                    // ���[�J�[
                    DataColumn col02 = new DataColumn(goodsMakerCode, typeof(Int32));
                    dt.Columns.Add(col02);
                    // �i��
                    DataColumn col03 = new DataColumn(goodsNo, typeof(string));
                    dt.Columns.Add(col03);

                    DataRow row = null;
                    for (int i = 0; i < importGoodsWorkArray.Count; i++)
                    {
                        // ���i�}�X�^�I�u�W�F�N�g
                        GoodsUWork importGoodsUWork = (GoodsUWork)importGoodsWorkArray[i];
                        row = dt.NewRow();

                        row[enterpriseCode] = importGoodsUWork.EnterpriseCode; // ��ƃR�[�h
                        row[goodsMakerCode] = importGoodsUWork.GoodsMakerCd; // ���[�J�[
                        row[goodsNo] = importGoodsUWork.GoodsNo; // �i��

                        dt.Rows.Add(row);
                    }
                    // �d���̃f�[�^����ێ�����
                    DataTable table = dt.DefaultView.ToTable(true, new string[] { enterpriseCode, goodsMakerCode, goodsNo });

                    // �ꎞ�e�[�u���Ƀf�[�^��INSERT
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    SqlBulkCopy sbc = new SqlBulkCopy(connectionText, SqlBulkCopyOptions.UseInternalTransaction);
                    sbc.BulkCopyTimeout = 3600;
                    sbc.NotifyAfter = dt.Rows.Count;

                    sbc.DestinationTableName = goodsTblName;
                    sbc.WriteToServer(table);
                    dt.Dispose();
                    table.Dispose();

                    // �ꎞ�e�[�u���̃C���f�b�N�X�̍쐬(��ƃR�[�h�E���[�J�[�E�i��)
                    sqlText = string.Empty;
                    sqlText = "CREATE NONCLUSTERED INDEX GOODSM_IDX1 ON " + goodsTblName + " (ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF)";
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    //----- ADD 2015/07/24 �c���� Redmine#45693 ----------<<<<<

                    //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    Dictionary<int, List<string>> goodsDict = new Dictionary<int, List<string>>();
                    // CSV�t�@�C������ǂݍ��񂾃f�[�^�����[�J�[�R�[�h�ŕ�������
                    // ���ꃁ�[�J�[�R�[�h�̕i�Ԃ����X�g�֊i�[����
                    for (int i = 0; i < importGoodsWorkArray.Count; i++)
                    {
                        // ���i�}�X�^�I�u�W�F�N�g
                        GoodsUWork importGoodsUWork = (GoodsUWork)importGoodsWorkArray[i];
                        if (!goodsDict.ContainsKey(importGoodsUWork.GoodsMakerCd)) // ���[�J�[�R�[�h�ŕ���
                        {
                            List<string> goodsNoList = new List<string>();
                            goodsNoList.Add(importGoodsUWork.GoodsNo);
                            goodsDict.Add(importGoodsUWork.GoodsMakerCd, goodsNoList);
                        }
                        else
                        {
                            goodsDict[importGoodsUWork.GoodsMakerCd].Add(importGoodsUWork.GoodsNo);
                        }
                    }

                    // ��ƃR�[�h
                    string tempEnterpriseCode = paraGoodsUWork.EnterpriseCode;
                    // ���i�}�X�^���X�g
                    if (GoodsUList == null)
                    {
                        GoodsUList = new ArrayList();
                    }
                    // ���i�}�X�^���X�g
                    if (GoodsPriceUList == null)
                    {
                        GoodsPriceUList = new ArrayList();
                    }
                    // ���[�J�[�R�[�h�ŕ������āA���i�}�X�^�f�[�^�Ɖ��i�}�X�^�f�[�^����������
                    foreach (KeyValuePair<int, List<string>> dict in goodsDict)
                    {
                        //----- DEL 2015/07/24 �c���� Redmine#45693 ---------->>>>>
                        // DB�ƍ����̉e���̂��߁A�i�ԏ������폜
                        //List<string> goodsNoList = dict.Value;
                        //// �i�ԏ����Ń\�[�g����
                        //goodsNoList.Sort();
                        //----- DEL 2015/07/24 �c���� Redmine#45693 ----------<<<<<

                        #region ���i�}�X�^�̃f�[�^�̌�������
                        paraGoodsUWork = new GoodsUWork();
                        paraGoodsUWork.EnterpriseCode = tempEnterpriseCode; // ��ƃR�[�h
                        paraGoodsUWork.GoodsMakerCd = dict.Key; // ���[�J�[�R�[�h
                        //----- DEL 2015/07/24 �c���� Redmine#45693 ---------->>>>>
                        // DB�ƍ����̉e���̂��߁A�i�ԏ������폜
                        //paraGoodsUWork.GoodsNoSt = goodsNoList[0]; // �ŏ��̕i��
                        //paraGoodsUWork.GoodsNoEd = goodsNoList[goodsNoList.Count - 1]; // �ő�̕i��
                        //----- DEL 2015/07/24 �c���� Redmine#45693 ----------<<<<<

                        // ����
                        ArrayList goodsUList = null;
                        //GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // DEL 2015/07/24 �c���� Redmine#45693
                        //GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/07/24 �c���� Redmine#45693 // DEL 2015/08/22 �c���� Redmine#45693
                        //status = GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/22 �c���� Redmine#45693 // DEL 2015/08/26 �c���� Redmine#45693
                        GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/26 �c���� Redmine#45693
                        //----- DEL 2015/08/26 �c���� Redmine#45693 ---------->>>>>
                        // CSV�̃f�[�^�����i�}�X�^�ɑ��݂��Ȃ��ꍇ�A��̏��������̂܂ܐi�ނ͂��A����status��break�������폜����B
                        ////----- ADD 2015/08/22 �c���� Redmine#45693 ------>>>>>
                        //// �������s�̏ꍇ�A�����I���Ƃ���
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    break;
                        //}
                        ////----- ADD 2015/08/22 �c���� Redmine#45693 ------<<<<<
                        //----- DEL 2015/08/26 �c���� Redmine#45693 ----------<<<<<
                        GoodsUList.AddRange(goodsUList);
                        #endregion

                        #region ���i�}�X�^�̃f�[�^�̌�������
                        // �����p�����[�^�̐ݒ�
                        paraGoodsPriceUWork = new GoodsPriceUWork();
                        paraGoodsPriceUWork.EnterpriseCode = tempEnterpriseCode; // ��ƃR�[�h
                        paraGoodsPriceUWork.GoodsMakerCd = dict.Key; // ���[�J�[�R�[�h
                        //----- DEL 2015/07/24 �c���� Redmine#45693 ---------->>>>>
                        // DB�ƍ����̉e���̂��߁A�i�ԏ������폜
                        //paraGoodsPriceUWork.GoodsNoSt = goodsNoList[0]; // �ŏ��̕i��
                        //paraGoodsPriceUWork.GoodsNoEd = goodsNoList[goodsNoList.Count - 1]; // �ő�̕i��
                        //----- DEL 2015/07/24 �c���� Redmine#45693 ----------<<<<<

                        // ����
                        ArrayList goodsPriceList = null;
                        //GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // DEL 2015/07/24 �c���� Redmine#45693
                        //GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/07/24 �c���� Redmine#45693 // DEL 2015/08/22 �c���� Redmine#45693
                        //status = GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/22 �c���� Redmine#45693 // DEL 2015/08/26 �c���� Redmine#45693
                        GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/26 �c���� Redmine#45693
                        //----- DEL 2015/08/26 �c���� Redmine#45693 ---------->>>>>
                        // CSV�̃f�[�^�����i�}�X�^�ɑ��݂��Ȃ��ꍇ�A��̏��������̂܂ܐi�ނ͂��A����status��break�������폜����B
                        ////----- ADD 2015/08/22 �c���� Redmine#45693 ------>>>>>
                        //// �������s�̏ꍇ�A�����I���Ƃ���
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    break;
                        //}
                        ////----- ADD 2015/08/22 �c���� Redmine#45693 ------<<<<<
                        //----- DEL 2015/08/26 �c���� Redmine#45693 ----------<<<<<
                        GoodsPriceUList.AddRange(goodsPriceList);
                        #endregion
                    }
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                //----- ADD 2015/08/22 �c���� Redmine#45693 ---------->>>>>
                }
                catch (Exception e)
                {
                    GoodsUList = null;
                    GoodsPriceUList = null;
                    errMsg = e.Message;
                    base.WriteErrorLog(e, errMsg, -1);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    // �ꎞ�e�[�u�����폜����
                    DropTempTbl(goodsTblName, ref sqlConnection);
                }

                // ��O�������̏ꍇ�A�����I���Ƃ���
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                //----- ADD 2015/08/22 �c���� Redmine#45693 ------<<<<<
                //----- ADD 2015/08/22 �c���� Redmine#45693 ----------<<<<<

                // ���i�Ǘ������̎擾
                PriceChgProcStDB.Read(ref priceChgProcStWork, 0, ref sqlConnection, ref sqlTransaction);
                priceMngCnt = priceChgProcStWork.PriceMngCnt;

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // �S���������ʂ�Dictionary�Ɋi�[����
                // ���i�}�X�^��Dictionary�̍쐬
                //Dictionary<GoodsUImportWorkWrap, GoodsUWork> goodsUDict = new Dictionary<GoodsUImportWorkWrap, GoodsUWork>(); // DEL 2015/05/20 �c���� Redmine#45693
                // ��������ߖ񂷂邽��Dictionary��KEY�̃^�C�v��string�ɕύX����
                Dictionary<string, GoodsUWork> goodsUDict = new Dictionary<string, GoodsUWork>(); // ADD 2015/05/20 �c���� Redmine#45693
                foreach (GoodsUWork work in GoodsUList)
                {
                    //----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    //GoodsUImportWorkWrap warp = new GoodsUImportWorkWrap(work);
                    //goodsUDict.Add(warp, work);
                    //----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
                    string goodsKey = string.Format("{0}/{1}/{2}", work.EnterpriseCode, work.GoodsMakerCd, work.GoodsNo);
                    // ���i�}�X�^�ɓ����L�[�̃f�[�^���������݂��Ȃ��̂ŁA���ڂ�Dictionary�֒ǉ����Ă�����
                    goodsUDict.Add(goodsKey, work);
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                }
                // ���i�}�X�^��Dictionary�̍쐬
                //Dictionary<GoodsPriceUImportWorkWrap, GoodsPriceUWork> goodsPriceUDict = new Dictionary<GoodsPriceUImportWorkWrap, GoodsPriceUWork>(); // DEL 2015/05/20 �c���� Redmine#45693
                // ��������ߖ񂷂邽��Dictionary��KEY�̃^�C�v��string�ɕύX����
                Dictionary<string, GoodsPriceUWork> goodsPriceUDict = new Dictionary<string, GoodsPriceUWork>(); // ADD 2015/05/20 �c���� Redmine#45693
                foreach (GoodsPriceUWork work in GoodsPriceUList)
                {
                    //----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    //GoodsPriceUImportWorkWrap warp = new GoodsPriceUImportWorkWrap(work);
                    //goodsPriceUDict.Add(warp, work);
                    //----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n��
                    string priceKey = string.Format("{0}/{1}/{2}/{3}", work.EnterpriseCode, work.GoodsMakerCd, work.GoodsNo, work.PriceStartDate.ToString("yyyyMMdd"));
                    // ���i�}�X�^�ɓ����L�[�̃f�[�^���������݂��Ȃ��̂ŁA���ڂ�Dictionary�֒ǉ����Ă�����
                    goodsPriceUDict.Add(priceKey, work);
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                }

                // �ǉ��ƍX�V�f�[�^�̍쐬
                // ���i�}�X�^�̒ǉ����X�g
                ArrayList addGoodsUList = new ArrayList();
                // ���i�}�X�^�̍X�V���X�g
                ArrayList updGoodsUList = new ArrayList();
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                // ���i�}�X�^�̒ǉ��X�V���X�g
                ArrayList addUpdGoodsPriceUList = new ArrayList();
                List<GoodsPriceUWork> goodsPriceUWorkList = new List<GoodsPriceUWork>();

                int wkMakerCd = 0;
                string wkGoodsNo = "";
                int goodsPriceNo = 0;
                int addCnt2 = 0;
                int updCnt2 = 0;
                bool addFlg = false;
                bool updFlg = false;

                // �C���|�[�g�p���i�}�X�^���X�g�ɌJ��Ԃ����A���i�I�u�W�F�N�g�Ɗւ��鉿�i���X�g�I�u�W�F�N�g�������s��
                for (int i = 0; i < importGoodsWorkArray.Count; i++)
                {
                    string msg = String.Empty;
                    if (goodsPriceUWorkList.Count > 0) goodsPriceUWorkList.Clear();

                    // �`�F�b�N�p���i�E���i���[�N���
                    GoodsUGoodsPriceUWork goodsUGoodsPriceUWork = (GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i];

                    // ���i�}�X�^�I�u�W�F�N�g
                    GoodsUWork importGoodsUWork = (GoodsUWork)importGoodsWorkArray[i];
                    //GoodsUImportWorkWrap importGoodsUImportWorkWrap = new GoodsUImportWorkWrap(importGoodsUWork); // DEL 2015/05/20 �c���� Redmine#45693
                    // ���i�}�X�^�I�u�W�F�N�g�ւ���i���X�g�I�u�W�F�N�g�̏�����
                    // CSV�t�@�C�����C���|�[�g���ꂽ��A���i1=>���i5�̊֘A������ɂ���āA���i���X�g�̏��������s��
                    for (int j = i * 5; j < i * 5 + 5; j++)
                    {
                        GoodsPriceUWork importGoodsPriceUWork = (GoodsPriceUWork)importGoodsPriceWorkArray[j];
                        goodsPriceUWorkList.Add(importGoodsPriceUWork);
                    }
                    // ���i�}�X�^�ǉ��A�X�V���f
                    //if (!goodsUDict.ContainsKey(importGoodsUImportWorkWrap)) // DEL 2015/05/20 �c���� Redmine#45693
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
                    string goodsKey = string.Format("{0}/{1}/{2}", importGoodsUWork.EnterpriseCode, importGoodsUWork.GoodsMakerCd, importGoodsUWork.GoodsNo);
                    if (!goodsUDict.ContainsKey(goodsKey))
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                    {
                        // ���.�X�V�敪�F�ǉ��A�ǉ��X�V����ƁA�`�F�b�N�s��
                        if (processKbn == 1 || processKbn == 0)
                        {
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, out msg)) // DEL wangf 2012/07/03 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                            // �����ŁA�I�u�W�F�N�g���ǉ�����΁A�ݒ胊�X�g�����ł��A���.�X�V�敪���f�K�v
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 0, out msg)) // DEL wangf 2012/07/20 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                            if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 0, dataCheckKbn, goodsUGoodsPriceUWorkCheckList, goodsPriceUWorkList, out msg))
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                            {
                                //ConverToDataSetCustomerInf(goodsUGoodsPriceUWork, msg, ref table); // DEL wangf 2012/07/03 FOR Redmine#30387
                                ((GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i]).ErrorMsg = msg; // ADD wangf 2012/07/03 FOR Redmine#30387
                                continue;
                            }
                            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                            addGoodsUList.Add(ConvertToGoodsUImportWork(importGoodsUWork, null, false, setUpInfoList));
                        }
                    }
                    else
                    {
                        if (processKbn == 2 || processKbn == 0)
                        {
                            // ���.�X�V�敪�F�X�V�A�ǉ��X�V����ƁA�`�F�b�N�s��
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, out msg)) // DEL wangf 2012/07/03 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                            // �����ŁA�I�u�W�F�N�g���X�V�E�ǉ��X�V����΁A�ݒ胊�X�g�L���ł��A���.�X�V�敪���f�K�v�Ȃ�
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 1, out msg))  // DEL wangf 2012/07/20 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                            if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 1, dataCheckKbn, goodsUGoodsPriceUWorkCheckList, goodsPriceUWorkList, out msg))
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                            {
                                //ConverToDataSetCustomerInf(goodsUGoodsPriceUWork, msg, ref table); // DEL wangf 2012/07/03 FOR Redmine#30387
                                ((GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i]).ErrorMsg = msg; // ADD wangf 2012/07/03 FOR Redmine#30387
                                continue;
                            }
                            // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                            //updGoodsUList.Add(ConvertToGoodsUImportWork(importGoodsUWork, goodsUDict[importGoodsUImportWorkWrap], true, setUpInfoList)); // DEL 2015/05/20 �c���� Redmine#45693
                            updGoodsUList.Add(ConvertToGoodsUImportWork(importGoodsUWork, goodsUDict[goodsKey], true, setUpInfoList)); // ADD 2015/05/20 �c���� Redmine#45693
                        }
                        //----- ADD 2015/05/20 �c���� Redmine#45693 ������Q�Q ---------->>>>>
                        else
                        {
                            // ���.�����敪�F�ǉ�����ƁA�`�F�b�N�s��
                            // ���R�F���i�}�X�^�ɑ��݂���CSV�̕i�Ԃɑ΂��āA���̉��i�f�[�^�����i�}�X�^�ɑ��݂��Ȃ��\��������
                            // �u�ǉ��v�ɂ���ꍇ�A���i�}�X�^�֓o�^����K�v�Ȃ̂ŁA�`�F�b�N�s��
                            if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 1, dataCheckKbn, goodsUGoodsPriceUWorkCheckList, goodsPriceUWorkList, out msg))
                            {
                                ((GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i]).ErrorMsg = msg;
                                continue;
                            }
                        }
                        //----- ADD 2015/05/20 �c���� Redmine#45693 ������Q�Q ----------<<<<<
                    }
                    // �����Q�Ƃ��āA���i�}�X�^�̒ǉ��X�V���X�g�̏������s��
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387--------->>>>
                    // �捞�f�[�^�̉��i��񂪖�����(���i�J�n�N�����P�`���i�J�n�N�����T�S����ݒ肵�Ȃ���
                    // ���̏��i�̉��i�}�X�^�f�[�^���쐬����B
                    int number = 0;
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387---------<<<<
                    foreach (GoodsPriceUWork importGoodsPriceUWork in goodsPriceUWorkList)
                    {
                        //if (importGoodsPriceUWork.PriceStartDate == DateTime.MinValue) continue; // DEL wangf 2012/07/05 FOR Redmine#30387
                        // ------------ADD wangf 2012/07/05 FOR Redmine#30387--------->>>>
                        if (importGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
                        {
                            number++;
                            continue;
                        }
                        // ------------ADD wangf 2012/07/05 FOR Redmine#30387---------<<<<
                        //GoodsPriceUImportWorkWrap importGoodsPriceUImportWorkWrap = new GoodsPriceUImportWorkWrap(importGoodsPriceUWork); // DEL 2015/05/20 �c���� Redmine#45693

                        if (wkMakerCd != importGoodsPriceUWork.GoodsMakerCd || wkGoodsNo != importGoodsPriceUWork.GoodsNo)
                        {
                            wkMakerCd = importGoodsPriceUWork.GoodsMakerCd;
                            wkGoodsNo = importGoodsPriceUWork.GoodsNo;
                            goodsPriceNo = 0;
                            addFlg = false;
                            updFlg = false;
                        }

                        // �����敪���u�ǉ��v�̏ꍇ
                        if (processKbn == 1)
                        {
                            //if (!goodsPriceUDict.ContainsKey(importGoodsPriceUImportWorkWrap)) // DEL 2015/05/20 �c���� Redmine#45693
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                            // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n��
                            string priceKey = string.Format("{0}/{1}/{2}/{3}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd,
                                importGoodsPriceUWork.GoodsNo, importGoodsPriceUWork.PriceStartDate.ToString("yyyyMMdd"));
                            if (!goodsPriceUDict.ContainsKey(priceKey))
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                            {
                                // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B

                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, null, false, setUpInfoList, goodsPriceNo));
                                if (!CheckUpdAddList(importGoodsPriceUWork, addGoodsUList) && !addFlg)
                                {
                                    addCnt2++;
                                    addFlg = true;
                                }
                            }
                        }
                        // �����敪���u�X�V�v�̏ꍇ
                        else if (processKbn == 2)
                        {
                            //if (!goodsPriceUDict.ContainsKey(importGoodsPriceUImportWorkWrap)) // DEL 2015/05/20 �c���� Redmine#45693
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                            // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n��
                            string priceKey = string.Format("{0}/{1}/{2}/{3}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd,
                                importGoodsPriceUWork.GoodsNo, importGoodsPriceUWork.PriceStartDate.ToString("yyyyMMdd"));
                            if (!goodsPriceUDict.ContainsKey(priceKey))
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                            {
                            }
                            else
                            {
                                // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                                //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[importGoodsPriceUImportWorkWrap], true, setUpInfoList, goodsPriceNo)); // DEL 2015/05/20 �c���� Redmine#45693
                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[priceKey], true, setUpInfoList, goodsPriceNo)); // ADD 2015/05/20 �c���� Redmine#45693
                                if (!CheckUpdAddList(importGoodsPriceUWork, updGoodsUList) && !updFlg)
                                {
                                    updCnt2++;
                                    updFlg = true;
                                }
                            }
                        }
                        // �����敪���u�ǉ��X�V�v�̏ꍇ
                        else
                        {
                            //if (!goodsPriceUDict.ContainsKey(importGoodsPriceUImportWorkWrap)) // DEL 2015/05/20 �c���� Redmine#45693
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                            // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n��
                            string priceKey = string.Format("{0}/{1}/{2}/{3}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd,
                                importGoodsPriceUWork.GoodsNo, importGoodsPriceUWork.PriceStartDate.ToString("yyyyMMdd"));
                            if (!goodsPriceUDict.ContainsKey(priceKey))
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                            {
                                // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B

                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, null, false, setUpInfoList, goodsPriceNo));
                                if (!CheckUpdAddList(importGoodsPriceUWork, addGoodsUList) && !addFlg)
                                {
                                    addCnt2++;
                                    addFlg = true;
                                }
                            }
                            else
                            {
                                // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B

                                //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[importGoodsPriceUImportWorkWrap], true, setUpInfoList, goodsPriceNo)); // DEL 2015/05/20 �c���� Redmine#45693
                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[priceKey], true, setUpInfoList, goodsPriceNo)); // ADD 2015/05/20 �c���� Redmine#45693
                                if (!CheckUpdAddList(importGoodsPriceUWork, updGoodsUList) && !updFlg)
                                {
                                    updCnt2++;
                                    updFlg = true;
                                }
                            }
                        }
                        goodsPriceNo++;
                    }
                    // ���i�}�X�^�f�[�^�I�u�W�F�N�g������΁A���i���ݒ肵�Ȃ���΁A�V�K���i�f�[�^���������A���i�J�n�N���������Аݒ�.����N�����ݒ肳���
                    // ���i�X�V�E�ǉ����Ȃ����
                    //if (0 == updCnt2 && 0 == addCnt2) // DEL wangf 2012/07/05 FOR Redmine#30387
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387--------->>>>
                    // �捞�f�[�^�̉��i��񂪖�����(���i�J�n�N�����P�`���i�J�n�N�����T�S����ݒ肵�Ȃ����ADB�����f�[�^������΁A�V�K���i�f�[�^���s���܂�
                    //----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    //if (5 == number && ((!goodsUDict.ContainsKey(importGoodsUImportWorkWrap) && 1 == processKbn)
                    //    || (goodsUDict.ContainsKey(importGoodsUImportWorkWrap) && 2 == processKbn)
                    //    || 3 == processKbn))
                    //----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                    // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
                    if (5 == number && ((!goodsUDict.ContainsKey(goodsKey) && 1 == processKbn)
                        || (goodsUDict.ContainsKey(goodsKey) && 2 == processKbn)
                        || 3 == processKbn))
                    //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387---------<<<<
                    {
                        GoodsPriceUWork goodsPrice = new GoodsPriceUWork();
                        goodsPrice.EnterpriseCode = importGoodsUWork.EnterpriseCode;
                        goodsPrice.GoodsNo = importGoodsUWork.GoodsNo;
                        goodsPrice.GoodsMakerCd = importGoodsUWork.GoodsMakerCd;
                        goodsPrice.PriceStartDate = paraPriceStartDate;
                        //----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                        //GoodsPriceUImportWorkWrap importGoodsPriceWrap = new GoodsPriceUImportWorkWrap(goodsPrice);
                        //if (!goodsPriceUDict.ContainsKey(importGoodsPriceWrap))
                        //----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                        //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                        // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n��
                        string priceKey = string.Format("{0}/{1}/{2}/{3}", goodsPrice.EnterpriseCode, goodsPrice.GoodsMakerCd,
                            goodsPrice.GoodsNo, goodsPrice.PriceStartDate.ToString("yyyyMMdd"));
                        if (!goodsPriceUDict.ContainsKey(priceKey))
                        //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                        {
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(goodsPrice, null, false, setUpInfoList, 0));
                        }
                    }
                }
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                #region DEL wangf 2012/06/12 FOR Redmine#30387
                /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                foreach (GoodsUWork importWork in importGoodsWorkArray)
                {
                    GoodsUImportWorkWrap importWarp = new GoodsUImportWorkWrap(importWork);

                    if (!goodsUDict.ContainsKey(importWarp))
                    {
                        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                        // 2010/03/31 >>>
                        //addGoodsUList.Add(ConvertToGoodsUImportWork(importWork, null, false));
                        addGoodsUList.Add(ConvertToGoodsUImportWork(importWork, null, false, setUpInfoList));
                        // 2010/03/31 <<<
                    }
                    else
                    {
                        // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                        // 2010/03/31 >>>
                        //updGoodsUList.Add(ConvertToGoodsUImportWork(importWork, goodsUDict[importWarp], true));
                        updGoodsUList.Add(ConvertToGoodsUImportWork(importWork, goodsUDict[importWarp], true, setUpInfoList));
                        // 2010/03/31 <<<
                    }
                }
                // ���i�}�X�^�̒ǉ��X�V���X�g
                ArrayList addUpdGoodsPriceUList = new ArrayList();
                // 2010/03/31 Add >>>
                int wkMakerCd = 0;
                string wkGoodsNo = "";
                int goodsPriceNo = 0;
                int addCnt2 = 0;
                int updCnt2 = 0;
                bool addFlg = false;
                bool updFlg = false;
                // 2010/03/31 Add <<<
                foreach (GoodsPriceUWork importWork in importGoodsPriceWorkArray)
                {
                    GoodsPriceUImportWorkWrap importWarp = new GoodsPriceUImportWorkWrap(importWork);

                    // 2010/03/31 Add >>>
                    if (wkMakerCd != importWork.GoodsMakerCd || wkGoodsNo != importWork.GoodsNo)
                    {
                        wkMakerCd = importWork.GoodsMakerCd;
                        wkGoodsNo = importWork.GoodsNo;
                        goodsPriceNo = 0;
                        addFlg = false;
                        updFlg = false;
                    }
                    // 2010/03/31 Add <<<

                    // �����敪���u�ǉ��v�̏ꍇ
                    if (processKbn == 1)
                    {
                        // 2010/03/31 Del >>>
                        //foreach (GoodsUWork goodsImportWork in addGoodsUList)
                        //{
                        //if (goodsImportWork.GoodsMakerCd == importWork.GoodsMakerCd &&
                        //    goodsImportWork.GoodsNo == importWork.GoodsNo)
                        //{
                        // 2010/03/31 Del <<<
                        if (!goodsPriceUDict.ContainsKey(importWarp))
                        {
                            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false)); // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, addGoodsUList) && !addFlg)
                            {
                                addCnt2++;
                                addFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                        else
                        {
                            // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                            // 2010/03/31 Del �u�ǉ��v�̏ꍇ�͍X�V���X�g�֒ǉ����Ȃ��B >>>
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true));
                            // 2010/03/31 Del <<<
                        }
                        // 2010/03/31 Del >>>
                        //}
                        //}
                        // 2010/03/31 Del <<<
                    }
                    // �����敪���u�X�V�v�̏ꍇ
                    else if (processKbn == 2)
                    {
                        // 2010/03/31 Del >>>
                        //foreach (GoodsUWork goodsImportWork in updGoodsUList)
                        //{
                        //if (goodsImportWork.GoodsMakerCd == importWork.GoodsMakerCd &&
                        //    goodsImportWork.GoodsNo == importWork.GoodsNo)
                        //{
                        // 2010/03/31 Del <<<
                        if (!goodsPriceUDict.ContainsKey(importWarp))
                        {
                            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                            // 2010/03/31 Del �u�X�V�v�̏ꍇ�͒ǉ����X�g�֒ǉ����Ȃ��B >>>
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false));
                            // 2010/03/31 Del <<<
                        }
                        else
                        {
                            // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true));   // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, updGoodsUList) && !updFlg)
                            {
                                updCnt2++;
                                updFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                        // 2010/03/31 Del >>>
                        //}
                        //}
                        // 2010/03/31 Del <<<
                    }
                    // �����敪���u�ǉ��X�V�v�̏ꍇ
                    else
                    {
                        if (!goodsPriceUDict.ContainsKey(importWarp))
                        {
                            // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false));   // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, addGoodsUList) && !addFlg)
                            {
                                addCnt2++;
                                addFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                        else
                        {
                            // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true)); // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, updGoodsUList) && !updFlg)
                            {
                                updCnt2++;
                                updFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                    }
                    goodsPriceNo++; // 2010/03/31 Add
                }
                // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                #endregion

                // �Ǎ�����
                readCnt = importGoodsWorkArray.Count;
                
                // �R���N�V�����ƃg�����U�N�V����
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                // �����敪���u�ǉ��v�̏ꍇ
                if (processKbn == 1)
                {
                    if (addGoodsUList != null && addGoodsUList.Count > 0)
                    {
                        // ���i�}�X�^�̓o�^����
                        status = GoodsUDB.WriteGoodsUProc(ref addGoodsUList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isAddUpdFlg = true;
                            addCnt = addGoodsUList.Count;
                        }
                    }
                }
                // �����敪���u�X�V�v�̏ꍇ
                else if (processKbn == 2)
                {
                    if (updGoodsUList != null && updGoodsUList.Count > 0)
                    {
                        // ���i�}�X�^�̍X�V����
                        status = GoodsUDB.WriteGoodsUProc(ref updGoodsUList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isAddUpdFlg = true;
                            updCnt = updGoodsUList.Count;
                        }
                    }
                }
                // �����敪���u�ǉ��X�V�v�̏ꍇ
                else
                {
                    // �o�^�X�V���X�g�̍쐬
                    addUpdGoodsUList = new ArrayList();
                    if (addGoodsUList.Count > 0)
                    {
                        addUpdGoodsUList.AddRange(addGoodsUList.GetRange(0, addGoodsUList.Count));
                    }
                    if (updGoodsUList.Count > 0)
                    {
                        addUpdGoodsUList.AddRange(updGoodsUList.GetRange(0, updGoodsUList.Count));
                    }
                    if (addUpdGoodsUList.Count > 0)
                    {
                        // ���i�}�X�^�̓o�^�X�V����
                        status = GoodsUDB.WriteGoodsUProc(ref addUpdGoodsUList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isAddUpdFlg = true;
                            addCnt = addGoodsUList.Count;
                            updCnt = updGoodsUList.Count;
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2010/03/31 Del >>>
                    //if (isAddUpdFlg)
                    //{
                    // 2010/03/31 Del <<<
                    // ���i�}�X�^��DB�o�^��������������΁A���i�}�X�^�ɓo�^����B
                        ArrayList errList = new ArrayList();
                        if (addUpdGoodsPriceUList.Count > 0)
                        {
                            status = GoodsPriceUDB.WriteGoodsPriceProc(ref addUpdGoodsPriceUList, out errList, ref sqlConnection, ref sqlTransaction);
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                            // ADD 2009/06/24 --->>>
                            if (sqlTransaction != null)
                            {
                                sqlTransaction.Dispose();
                            }
                            ArrayList delList = new ArrayList();
                            ArrayList tmpAddUpdGoodsUList = new ArrayList();
                            // 2010/03/31 Del >>>
                            //// �����敪���u�ǉ��v�̏ꍇ
                            //if (processKbn == 1)
                            //{
                            //    tmpAddUpdGoodsUList = addGoodsUList;
                            //}
                            //// �����敪���u�X�V�v�̏ꍇ
                            //else if (processKbn == 2)
                            //{
                            //    tmpAddUpdGoodsUList = updGoodsUList;
                            //}
                            // 2010/03/31 Del <<<
                            #region DEL 2015/05/20 �c���� Redmine#45693
                            /*----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                            //################################################################################################
                            //## �@������Q�P_���i�폜�p���X�gtmpAddUpdGoodsUList�́A���i�}�X�^���X�g�iaddGoodsUList�AupdGoodsUList�AaddUpdGoodsUList�j���牿�i�}�X�^���X�g�ɕύX
                            //## �A�S�Ẳ��i�̍Č�����p�~���āA�O�񌟍����ꂽ���i��CSV�̉��i���i�荞��
                            //################################################################################################
                            // 2010/03/31 Add >>>
                            if (processKbn == 1 || processKbn == 2)
                            {
                                if (addGoodsUList.Count != 0)
                                    tmpAddUpdGoodsUList.AddRange(addGoodsUList.GetRange(0, addGoodsUList.Count));
                                if (updGoodsUList.Count != 0)
                                    tmpAddUpdGoodsUList.AddRange(updGoodsUList.GetRange(0, updGoodsUList.Count));
                            }
                            // 2010/03/31 Add <<<
                            // �����敪���u�ǉ��X�V�v�̏ꍇ
                            else
                            {
                                tmpAddUpdGoodsUList = addUpdGoodsUList;
                            }
                            //add by liusy #35805 2013/06/14-------->>>>>>
                            //���������[�X
                            GoodsPriceUList.Clear();
                            GoodsPriceUList = null;
                            GoodsPriceUList = new ArrayList();
                            //�w�肳�ꂽ�����̏��i���i�}�X�^���LIST(��key����)������
                            GoodsPriceUDB.SearchGoodsPriceBeforeDelProc(out GoodsPriceUList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                            //add by liusy #35805 2013/06/14--------<<<<<<
                            ----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<*/
                            #endregion
                            // �S�ĉ��i�}�X�^�̃f�[�^�̌�������
                            //GoodsPriceUDB.SearchGoodsPriceProc(out GoodsPriceUList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);  //del by liusy #35805 2013/06/14

                            //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                            // ���i�폜�p���X�gtmpAddUpdGoodsUList�́A���i�}�X�^���X�g�iaddGoodsUList�AupdGoodsUList�AaddUpdGoodsUList�j���牿�i�}�X�^���X�g�ɕύX
                            #region ��������Q�P_���i�폜�p���X�gtmpAddUpdGoodsUList�̐���
                            // �܂��A��ƃR�[�h�E���[�J�[�E�i�Ԃ̏����Ń\�[�g
                            GoodsPriceCompare2 sortInfo = new GoodsPriceCompare2();
                            addUpdGoodsPriceUList.Sort(sortInfo);

                            for (int index = 0; index < addUpdGoodsPriceUList.Count; index++ )
                            {
                                GoodsPriceUWork currentGoodsPrice = null;
                                GoodsPriceUWork prevGoodsPrice = null;
                                if (index == 0)
                                {
                                    // �擪���R�[�h�����X�g�֌Œ�ɒǉ�
                                    currentGoodsPrice = (GoodsPriceUWork)addUpdGoodsPriceUList[0];
                                    tmpAddUpdGoodsUList.Add(currentGoodsPrice);
                                }
                                else
                                {
                                    // �擪���R�[�h�ȊO�̃��R�[�h�́A�O���R�[�h�́u��ƃR�[�h�E���[�J�[�E�i�ԁv�ƈقȂ�ꍇ�A���X�g�֒ǉ�
                                    currentGoodsPrice = (GoodsPriceUWork)addUpdGoodsPriceUList[index];
                                    prevGoodsPrice = (GoodsPriceUWork)addUpdGoodsPriceUList[index - 1];

                                    string currentKey = string.Empty;
                                    string prevKey = string.Empty;

                                    if (currentGoodsPrice != null)
                                    {
                                        currentKey = string.Format("{0}/{1}/{2}", currentGoodsPrice.EnterpriseCode, currentGoodsPrice.GoodsMakerCd, currentGoodsPrice.GoodsNo);
                                    }
                                    if (prevGoodsPrice != null)
                                    {
                                        prevKey = string.Format("{0}/{1}/{2}", prevGoodsPrice.EnterpriseCode, prevGoodsPrice.GoodsMakerCd, prevGoodsPrice.GoodsNo);
                                    }
                                    if (currentKey != prevKey)
                                    {
                                        tmpAddUpdGoodsUList.Add(currentGoodsPrice);
                                    }
                                }
                            }
                            #endregion

                            // �ǉ����Ƀ��R�[�h�������i�Ǘ������𒴂���ꍇ�́A���i�J�n�N���������������R�[�h���폜����O�ɁA
                            // ���p�ȃ������̉�����s��
                            #region �����x���P_���p�ȃ������̉�����s��
                            if (goodsUGoodsPriceUWorkCheckList != null)
                            {
                                goodsUGoodsPriceUWorkCheckList.Clear();
                                goodsUGoodsPriceUWorkCheckList = null;
                            }
                            // �O�񌟍����炽���i�}�X�^���X�g
                            if (GoodsUList != null)
                            {
                                GoodsUList.Clear();
                                GoodsUList = null;
                            }
                            // �O�񌟍����炽���i�}�X�^��Dictionary
                            if (goodsUDict != null)
                            {
                                goodsUDict.Clear();
                                goodsUDict = null;
                            }
                            // �O�񌟍����炽���i�}�X�^��Dictionary
                            if (goodsPriceUDict != null)
                            {
                                goodsPriceUDict.Clear();
                                goodsPriceUDict = null;
                            }
                            // CSV����̏��i�}�X�^�̒ǉ����X�g
                            if (addGoodsUList != null)
                            {
                                addGoodsUList.Clear();
                                addGoodsUList = null;
                            }
                            // CSV����̏��i�}�X�^�̍X�V���X�g
                            if (updGoodsUList != null)
                            {
                                updGoodsUList.Clear();
                                updGoodsUList = null;
                            }
                            // ���i���X�g
                            if (goodsPriceUWorkList != null)
                            {
                                goodsPriceUWorkList.Clear();
                                goodsPriceUWorkList = null;
                            }
                            #endregion

                            // ���i�̒ǉ��X�V���X�g��NULL�̏ꍇ�A���L�̏����֐i��
                            #region �����x���P_�폜��r�p���iDictionary�̐���
                            // �폜��r�p���iDictionary
                            Dictionary<string, List<GoodsPriceUWork>> goodsPriceUDictForDel = new Dictionary<string, List<GoodsPriceUWork>>();
                            // �O�񌟍����ꂽ���i����CSV����̉��i�����i�荞��ō폜��r�p���iDictionary�֊i�[����
                            if (addUpdGoodsPriceUList != null && addUpdGoodsPriceUList.Count > 0)
                            {
                                // �O�񌟍����ꂽ���i�����폜��r�p���iDictionary�֊i�[����
                                foreach (GoodsPriceUWork firstSearchPriceWork in GoodsPriceUList)
                                { 
                                    // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
                                    string key = string.Format("{0}/{1}/{2}", firstSearchPriceWork.EnterpriseCode, firstSearchPriceWork.GoodsMakerCd, firstSearchPriceWork.GoodsNo);
                                    if (!goodsPriceUDictForDel.ContainsKey(key))
                                    {
                                        List<GoodsPriceUWork> priceList = new List<GoodsPriceUWork>();
                                        priceList.Add(firstSearchPriceWork);
                                        goodsPriceUDictForDel.Add(key, priceList);
                                    }
                                    else
                                    {
                                        goodsPriceUDictForDel[key].Add(firstSearchPriceWork);
                                    }
                                }
                                // �������̉��
                                // �O�񌟍����ꂽ���i��񃊃X�g
                                if (GoodsPriceUList != null)
                                {
                                    GoodsPriceUList.Clear();
                                    GoodsPriceUList = null;
                                }

                                // CSV����̉��i���̒ǉ��X�V���X�g���폜��r�p���iDictionary�֒ǉ�����
                                foreach (GoodsPriceUWork importGoodsPriceUWork in addUpdGoodsPriceUList)
                                {
                                    // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
                                    string key = string.Format("{0}/{1}/{2}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd, importGoodsPriceUWork.GoodsNo);
                                    if (!goodsPriceUDictForDel.ContainsKey(key))
                                    {
                                        List<GoodsPriceUWork> priceList = new List<GoodsPriceUWork>();
                                        priceList.Add(importGoodsPriceUWork);
                                        goodsPriceUDictForDel.Add(key, priceList);
                                    }
                                    else
                                    {
                                        // �O�񌟍����ꂽ���i��񃊃X�g��CSV�t�@�C���ɓ���u��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n���v�̃f�[�^�����݂��Ȃ��ꍇ�A
                                        // CSV�t�@�C���̉��i�����폜��r�p���iDictionary�֒ǉ�����
                                        if (!goodsPriceUDictForDel[key].Exists(delegate(GoodsPriceUWork compPriceWork)
                                        {
                                            return compPriceWork.EnterpriseCode == importGoodsPriceUWork.EnterpriseCode       // ��ƃR�[�h
                                                     && compPriceWork.GoodsMakerCd == importGoodsPriceUWork.GoodsMakerCd      // ���i���[�J�[�R�[�h
                                                     && compPriceWork.GoodsNo == importGoodsPriceUWork.GoodsNo                // ���i�ԍ�
                                                     && compPriceWork.PriceStartDate == importGoodsPriceUWork.PriceStartDate; // ���i�J�n��
                                        }))
                                        {
                                            goodsPriceUDictForDel[key].Add(importGoodsPriceUWork);
                                        }
                                    }
                                }
                                // �������̉��
                                // CSV����̉��i�}�X�^�̒ǉ��X�V���X�g
                                if (addUpdGoodsPriceUList != null)
                                {
                                    addUpdGoodsPriceUList.Clear();
                                    addUpdGoodsPriceUList = null;
                                }
                            }
                            #endregion
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<

                            //foreach (GoodsUWork importWork in tmpAddUpdGoodsUList) // DEL 2015/05/20 �c���� Redmine#45693 ������Q�P
                            foreach (GoodsPriceUWork importWork in tmpAddUpdGoodsUList) // ADD 2015/05/20 �c���� Redmine#45693 ������Q�P
                            {
                                List<GoodsPriceUWork> subList = new List<GoodsPriceUWork>();
                                //----- DEL 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                                //foreach (GoodsPriceUWork work in GoodsPriceUList)
                                //{
                                //    if (importWork.EnterpriseCode == work.EnterpriseCode
                                //        && importWork.GoodsMakerCd == work.GoodsMakerCd
                                //        && importWork.GoodsNo == work.GoodsNo)
                                //    {
                                //        subList.Add(work);
                                //    }
                                //}
                                //----- DEL 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                                //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                                // KEY:��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
                                string key = string.Format("{0}/{1}/{2}", importWork.EnterpriseCode, importWork.GoodsMakerCd, importWork.GoodsNo);
                                if (!goodsPriceUDictForDel.TryGetValue(key, out subList))
                                {
                                    subList = new List<GoodsPriceUWork>();
                                }
                                //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<

                                // �ǉ����Ƀ��R�[�h�������i�Ǘ������𒴂���ꍇ�́A���i�J�n�N���������������R�[�h���폜
                                if (subList.Count > priceMngCnt)
                                {
                                    GoodsPriceCompare<GoodsPriceUWork> comp = new GoodsPriceCompare<GoodsPriceUWork>();
                                    subList.Sort(comp);
                                    delList.AddRange(subList.GetRange(0, subList.Count - priceMngCnt));
                                }
                            }
                            // �������̉��
                            // �폜��r�p���iDictionary
                            if (goodsPriceUDictForDel != null)
                            {
                                goodsPriceUDictForDel.Clear();
                                goodsPriceUDictForDel = null;
                            }

                            // �ǉ����Ƀ��R�[�h�������i�Ǘ������𒴂���ꍇ�́A���i�J�n�N���������������R�[�h���폜
                            if (delList.Count > 0)
                            {
                                //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                                ArrayList searchList = new ArrayList();
                                ArrayList goodsPriceUListForDel = (ArrayList)delList.Clone();
                                delList.Clear();
                                // �폜����f�[�^���X�g�ɑ΂��āA�ŐV�̉��i���i�X�V�����j����������
                                foreach (GoodsPriceUWork delGoodsPriceUWork in goodsPriceUListForDel)
                                {
                                    status = GoodsPriceUDB.SearchGoodsPriceBeforeDelProc(out searchList, delGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        delList.AddRange(searchList);
                                    }
                                }
                                //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<

                                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                                status = GoodsPriceUDB.DeleteGoodsPriceProc(delList, ref sqlConnection, ref sqlTransaction);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // �R�~�b�g
                                    sqlTransaction.Commit();
                                }
                                else
                                {
                                    // ���[���o�b�N
                                    if (sqlTransaction.Connection != null)
                                    {
                                        sqlTransaction.Rollback();
                                    }
                                }
                            }
                            // ADD 2009/06/24 ---<<<
                            // 2010/04/07 Add >>>
                            updCnt = updCnt + updCnt2;
                            addCnt = addCnt + addCnt2;
                            // 2010/04/07 Add <<<
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
                            // �������̉��
                            if (delList != null)
                            {
                                delList.Clear();
                                delList = null;
                            }
                            if (tmpAddUpdGoodsUList != null)
                            {
                                tmpAddUpdGoodsUList.Clear();
                                tmpAddUpdGoodsUList = null;
                            }
                            //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
                        }
                        else
                        {
                            // ���[���o�b�N
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                    //}   // 2010/03/31 Del
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null)
                    {
                        readCnt = 0;
                        addCnt = 0;
                        updCnt = 0;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (SqlException ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
            catch (Exception ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, -1);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
            finally
            {
                //----- DEL 2015/08/22 �c���� Redmine#45693 --------------->>>>>
                ////----- ADD 2015/07/24 �c���� Redmine#45693 ---------->>>>>
                //// �ꎞ�e�[�u�����폜����
                //DropTempTbl(goodsTblName, ref sqlConnection);
                ////----- ADD 2015/07/24 �c���� Redmine#45693 ----------<<<<<
                //----- DEL 2015/08/22 �c���� Redmine#45693 ---------------<<<<<

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        //----- ADD 2015/07/24 �c���� Redmine#45693 ---------->>>>>
        /// <summary>
        /// �ꎞ�e�[�u�����폜����
        /// </summary>
        /// <param name="goodsTblName"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ꎞ�e�[�u����Drop����</br>
        /// <br>Programmer : 2015/01/14 �c���� Redmine#44492</br>
        /// <br>             Redmine#45693 �C�X�R�@���i�}�X�^�C���|�[�g</br>
        /// </remarks>
        private int DropTempTbl(string goodsTblName, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string sqlText = string.Empty;

            try
            {
                //�ꎞ�e�[�u����Drop
                using (SqlCommand sqlCommandDrop = new SqlCommand())
                {
                    sqlCommandDrop.Connection = sqlConnection;
                    sqlCommandDrop.CommandTimeout = 3600;

                    sqlText += "DROP TABLE " + goodsTblName + Environment.NewLine;

                    sqlCommandDrop.CommandText = sqlText;
                    sqlCommandDrop.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        //----- ADD 2015/07/24 �c���� Redmine#45693 ----------<<<<<

        /// <summary>
        /// ���i�}�X�^��DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <param name="setUpInfoList">�C���|�[�g�Ώېݒ胊�X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        // 2010/03/31 >>>
        //private GoodsUWork ConvertToGoodsUImportWork(GoodsUWork csvWork, GoodsUWork searchWork, bool isUpdFlg, List<int[]> setUpInfoList)
        private GoodsUWork ConvertToGoodsUImportWork(GoodsUWork csvWork, GoodsUWork searchWork, bool isUpdFlg, List<int[]> setUpInfoList)
        // 2010/03/31 <<<
        {
            GoodsUWork importWork = new GoodsUWork();
            if (isUpdFlg)
            {
                // �X�V�̏ꍇ
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // �_���폜�敪
                importWork.DisplayOrder = searchWork.DisplayOrder;                  // �\������
                importWork.OfferDate = searchWork.OfferDate;                        // �񋟓��t
                importWork.UpdateDate = searchWork.UpdateDate;                      // �X�V�N����
                importWork.OfferDataDiv = searchWork.OfferDataDiv;                  // �񋟃f�[�^�敪
                // 2010/03/31 Add >>>
                if (CheckUpdateDiv((int)ItemCode.GoodsName, setUpInfoList))
                {
                    importWork.GoodsName = csvWork.GoodsName;                       // �i��
                }
                else
                {
                    importWork.GoodsName = searchWork.GoodsName;                    // �i��
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsNameKana, setUpInfoList))
                {
                    importWork.GoodsNameKana = csvWork.GoodsNameKana;               // �i���J�i
                }
                else
                {
                    importWork.GoodsNameKana = searchWork.GoodsNameKana;            // �i���J�i
                }
                if (CheckUpdateDiv((int)ItemCode.Jan, setUpInfoList))
                {
                    importWork.Jan = csvWork.Jan;                                   // JAN�R�[�h
                }
                else
                {
                    importWork.Jan = searchWork.Jan;                                // JAN�R�[�h
                }
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList))
                {
                    importWork.BLGoodsCode = csvWork.BLGoodsCode;                   // BL�R�[�h
                }
                else
                {
                    importWork.BLGoodsCode = searchWork.BLGoodsCode;                // BL�R�[�h
                }
                if (CheckUpdateDiv((int)ItemCode.EnterpriseGanreCode, setUpInfoList))
                {
                    importWork.EnterpriseGanreCode = csvWork.EnterpriseGanreCode;   // ���i�敪
                }
                else
                {
                    importWork.EnterpriseGanreCode = searchWork.EnterpriseGanreCode;// ���i�敪
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsRateRank, setUpInfoList))
                {
                    importWork.GoodsRateRank = csvWork.GoodsRateRank;               // �w��
                }
                else
                {
                    importWork.GoodsRateRank = searchWork.GoodsRateRank;            // �w��
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList))
                {
                    importWork.GoodsKindCode = csvWork.GoodsKindCode;               // ���D�敪
                }
                else
                {
                    importWork.GoodsKindCode = searchWork.GoodsKindCode;            // ���D�敪
                }
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList))
                {
                    importWork.TaxationDivCd = csvWork.TaxationDivCd;               // �ېŋ敪
                }
                else
                {
                    importWork.TaxationDivCd = searchWork.TaxationDivCd;            // �ېŋ敪
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsNote1, setUpInfoList))
                {
                    importWork.GoodsNote1 = csvWork.GoodsNote1;                     // ���i���l�P
                }
                else
                {
                    importWork.GoodsNote1 = searchWork.GoodsNote1;                  // ���i���l�P
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsNote2, setUpInfoList))
                {
                    importWork.GoodsNote2 = csvWork.GoodsNote2;                     // ���i���l�Q
                }
                else
                {
                    importWork.GoodsNote2 = searchWork.GoodsNote2;                  // ���i���l�Q
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsSpecialNote, setUpInfoList))
                {
                    importWork.GoodsSpecialNote = csvWork.GoodsSpecialNote;         // ���i�K�i�E���L����
                }
                else
                {
                    importWork.GoodsSpecialNote = searchWork.GoodsSpecialNote;      // ���i�K�i�E���L����
                }
                // 2010/03/31 Add <<<
            }
            else
            {
                // �V�K�̏ꍇ
                importWork.DisplayOrder = 0;                                        // �\������
                // 2010/03/31 >>>
                //importWork.OfferDate = DateTime.Now;                                // �񋟓��t
                importWork.OfferDate = DateTime.MinValue;                                // �񋟓��t
                // 2010/03/31 <<<
                importWork.UpdateDate = DateTime.Now;                               // �X�V�N����
                importWork.OfferDataDiv = 0;                                        // �񋟃f�[�^�敪
                // 2010/03/31 Add >>>
                importWork.GoodsName = csvWork.GoodsName;                               // �i��
                importWork.GoodsNameKana = csvWork.GoodsNameKana;                       // �i���J�i
                importWork.Jan = csvWork.Jan;                                           // JAN�R�[�h
                importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BL�R�[�h
                importWork.EnterpriseGanreCode = csvWork.EnterpriseGanreCode;           // ���i�敪
                importWork.GoodsRateRank = csvWork.GoodsRateRank;                       // �w��
                importWork.GoodsKindCode = csvWork.GoodsKindCode;                       // ���D�敪
                importWork.TaxationDivCd = csvWork.TaxationDivCd;                       // �ېŋ敪
                importWork.GoodsNote1 = csvWork.GoodsNote1;                             // ���i���l�P
                importWork.GoodsNote2 = csvWork.GoodsNote2;                             // ���i���l�Q
                importWork.GoodsSpecialNote = csvWork.GoodsSpecialNote;                 // ���i�K�i�E���L����
                // 2010/03/31 Add <<<
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // ��ƃR�[�h
            importWork.GoodsNo = csvWork.GoodsNo;                                   // �i��
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         // ���[�J�[
            // 2010/03/31 Del >>>
            //importWork.GoodsName = csvWork.GoodsName;                               // �i��
            //importWork.GoodsNameKana = csvWork.GoodsNameKana;                       // �i���J�i
            //importWork.Jan = csvWork.Jan;                                           // JAN�R�[�h
            //importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BL�R�[�h
            //importWork.EnterpriseGanreCode = csvWork.EnterpriseGanreCode;           // ���i�敪
            //importWork.GoodsRateRank = csvWork.GoodsRateRank;                       // �w��
            //importWork.GoodsKindCode = csvWork.GoodsKindCode;                       // ���D�敪
            //importWork.TaxationDivCd = csvWork.TaxationDivCd;                       // �ېŋ敪
            // 2010/03/31 Del <<<
            importWork.GoodsNoNoneHyphen = csvWork.GoodsNo.Replace("-", "");        // �n�C�t�������i�ԍ�
            // 2010/03/31 Del >>>
            //importWork.GoodsNote1 = csvWork.GoodsNote1;                             // ���i���l�P
            //importWork.GoodsNote2 = csvWork.GoodsNote2;                             // ���i���l�Q
            //importWork.GoodsSpecialNote = csvWork.GoodsSpecialNote;                 // ���i�K�i�E���L����
            // 2010/03/31 Del <<<

            return importWork;
        }

        /// <summary>
        /// ���i�}�X�^��DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <param name="setUpinfoList">�C���|�[�g�Ώېݒ胊�X�g</param>
        /// <param name="goodsPriceNo">���i�}�X�^No</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        // 2010/03/31 >>>
        //private GoodsPriceUWork ConvertToGoodsPriceUImportWork(GoodsPriceUWork csvWork, GoodsPriceUWork searchWork, bool isUpdFlg)
        private GoodsPriceUWork ConvertToGoodsPriceUImportWork(GoodsPriceUWork csvWork, GoodsPriceUWork searchWork, bool isUpdFlg, List<int[]> setUpinfoList, int goodsPriceNo)
        // 2010/03/31 <<<
        {
            GoodsPriceUWork importWork = new GoodsPriceUWork();
            if (isUpdFlg)
            {
                // �X�V�̏ꍇ
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.OfferDate = searchWork.OfferDate;                        // �񋟓��t
                importWork.UpdateDate = searchWork.UpdateDate;                      // �X�V�N����
                // 2010/03/31 Add >>>
                if (CheckUpdateDiv((int)ItemCode.ListPrice1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.ListPrice = csvWork.ListPrice;                       // ���i
                }
                else
                {
                    importWork.ListPrice = searchWork.ListPrice;                    // ���i
                }
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.OpenPriceDiv = csvWork.OpenPriceDiv;                 // �I�[�v�����i�敪
                }
                else
                {
                    importWork.OpenPriceDiv = searchWork.OpenPriceDiv;              // �I�[�v�����i�敪
                }
                if (CheckUpdateDiv((int)ItemCode.StockRate1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.StockRate = csvWork.StockRate;                       // �d����
                }
                else
                {
                    importWork.StockRate = searchWork.StockRate;                    // �d����
                }
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.SalesUnitCost = csvWork.SalesUnitCost;               // ���P��
                }
                else
                {
                    importWork.SalesUnitCost = searchWork.SalesUnitCost;            // ���P��
                }
                // 2010/03/31 Add <<<
            }
            else
            {
                // �V�K�̏ꍇ
                // 2010/03/31 >>>
                //importWork.OfferDate = DateTime.Now;                                // �񋟓��t
                importWork.OfferDate = DateTime.MinValue;                                             // �񋟓��t
                // 2010/03/31 <<<
                importWork.UpdateDate = DateTime.Now;                               // �X�V�N����
                // 2010/03/31 Add >>>
                importWork.ListPrice = csvWork.ListPrice;                               // ���i
                importWork.OpenPriceDiv = csvWork.OpenPriceDiv;                         // �I�[�v�����i�敪
                importWork.StockRate = csvWork.StockRate;                               // �d����
                importWork.SalesUnitCost = csvWork.SalesUnitCost;                       // ���P��
                // 2010/03/31 Add <<<
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // ��ƃR�[�h
            importWork.GoodsNo = csvWork.GoodsNo;                                   // �i��
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         // ���[�J�[
            importWork.PriceStartDate = csvWork.PriceStartDate;                     // ���i�J�n�N����
            //importWork.ListPrice = csvWork.ListPrice;                               // ���i
            //importWork.OpenPriceDiv = csvWork.OpenPriceDiv;                         // �I�[�v�����i�敪
            //importWork.StockRate = csvWork.StockRate;                               // �d����
            //importWork.SalesUnitCost = csvWork.SalesUnitCost;                       // ���P��

            return importWork;
        }

        // ADD 2009/06/24 --->>>
        private bool IsAddCompareAfter(ArrayList list, GoodsPriceUWork csvWork, Int32 listCnt)
        {
            bool isAdd = false;

            foreach (GoodsPriceUWork work in list)
            {
                if (csvWork.PriceStartDate.CompareTo(work.PriceStartDate) > 0)
                {
                    isAdd = true;
                    break;
                }
            }

            return isAdd;
        }
        // ADD 2009/06/24 ---<<<

        // 2010/03/31 Add >>>
        /// <summary>
        /// SetUpInfoList����ItemId�̍X�V�敪������ɂȂ��Ă��邩�`�F�b�N���܂�
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <param name="setUpInfoList">SetUpInfoList</param>
        /// <returns>true:����@false:���Ȃ�</returns>
        private bool CheckUpdateDiv(int itemId, List<int[]> setUpInfoList)
        {
            // �ݒ胊�X�g�̃J�E���g��0�̏ꍇ��XML�t�@�C�������݂��Ă��Ȃ��בS���ڍX�V�ΏۂƂ���
            if (setUpInfoList.Count == 0)
            {
                return true;
            }
            int[] find = new int[2] { itemId, 0 };
            foreach (int[] setUpInfo in setUpInfoList)
            {
                if (find[0] == setUpInfo[0])
                {
                    if (setUpInfo[1] == 0)
                        return true;
                    break;
                }
            }
            return false;
        }

        /// <summary>
        /// ���i�}�X�^�̒ǉ����X�g�Y���̃f�[�^�����݂��邩�`�F�b�N���s���܂��B
        /// </summary>
        /// <param name="importWork">GoodsUWork</param>
        /// <param name="addGoodsUList">ArrayList</param>
        /// <returns>true:���݂���@false:���݂��Ȃ�</returns>
        private bool CheckUpdAddList(GoodsPriceUWork importWork, ArrayList addGoodsUList)
        {
            foreach (GoodsUWork goodsImportWork in addGoodsUList)
            {
                if (goodsImportWork.GoodsMakerCd == importWork.GoodsMakerCd &&
                    goodsImportWork.GoodsNo == importWork.GoodsNo)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �񋓑́E�C���|�[�g�Ώېݒ�̍��ڃ��X�g
        /// </summary>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        private enum ItemCode
        {
            GoodsNo = 1,            // �i��
            GoodsMakerCd,           // ���[�J�[
            GoodsName,              // �i��
            GoodsNameKana,          // �i���J�i
            Jan,                    // JAN�R�[�h
            BLGoodsCode,            // BL�R�[�h
            EnterpriseGanreCode,    // ���i�敪
            GoodsRateRank,          // �w��
            GoodsKindCode,          // ���D�敪
            TaxationDivCd,          // �ېŋ敪
            GoodsNote1,             // ���i���l�P
            GoodsNote2,             // ���i���l�Q
            GoodsSpecialNote,       // ���i�K�i�E���L����
            PriceStartDate1,        // ���i�J�n�N�����P
            ListPrice1,             // ���i�P
            OpenPriceDiv1,          // �I�[�v�����i�敪�P
            StockRate1,             // �d�����P
            SalesUnitCost1,         // ���P���P
            //PriceStartDate2,        // ���i�J�n�N�����Q
            //ListPrice2,             // ���i�Q
            //OpenPriceDiv2,          // �I�[�v�����i�敪�Q
            //StockRate2,             // �d�����Q
            //SalesUnitCost2,         // ���P���Q
            //PriceStartDate3,        // ���i�J�n�N�����R
            //ListPrice3,             // ���i�R
            //OpenPriceDiv3,          // �I�[�v�����i�敪�R
            //StockRate3,             // �d�����R
            //SalesUnitCost3,         // ���P���R
            //PriceStartDate4,        // ���i�J�n�N�����S
            //ListPrice4,             // ���i�S
            //OpenPriceDiv4,          // �I�[�v�����i�敪�S
            //StockRate4,             // �d�����S
            //SalesUnitCost4,         // ���P���S
            //PriceStartDate5,        // ���i�J�n�N�����T
            //ListPrice5,             // ���i�T
            //OpenPriceDiv5,          // �I�[�v�����i�敪�T
            //StockRate5,             // �d�����T
            //SalesUnitCost5          // ���P���T
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            PriceStartDate2,        // ���i�J�n�N�����Q
            ListPrice2,             // ���i�Q
            OpenPriceDiv2,          // �I�[�v�����i�敪�Q
            StockRate2,             // �d�����Q
            SalesUnitCost2,         // ���P���Q
            PriceStartDate3,        // ���i�J�n�N�����R
            ListPrice3,             // ���i�R
            OpenPriceDiv3,          // �I�[�v�����i�敪�R
            StockRate3,             // �d�����R
            SalesUnitCost3,         // ���P���R
            PriceStartDate4,        // ���i�J�n�N�����S
            ListPrice4,             // ���i�S
            OpenPriceDiv4,          // �I�[�v�����i�敪�S
            StockRate4,             // �d�����S
            SalesUnitCost4,         // ���P���S
            PriceStartDate5,        // ���i�J�n�N�����T
            ListPrice5,             // ���i�T
            OpenPriceDiv5,          // �I�[�v�����i�敪�T
            StockRate5,             // �d�����T
            SalesUnitCost5          // ���P���T
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
}
        // 2010/03/31 Add <<<
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion
        /* ------------DEL wangf 2012/07/03 FOR Redmine#30387--------->>>>
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        #region �G���[�f�[�^�e�[�u���ւ���
        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                  //  ���i�ԍ�
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add("GoodsNameRF", typeof(string));                //  ���i����
            dataTable.Columns.Add("GoodsNameKanaRF", typeof(string));            //  ���i���̃J�i
            dataTable.Columns.Add("JanRF", typeof(string));                      //  JAN�R�[�h

            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL���i�R�[�h
            dataTable.Columns.Add("EnterpriseGanreCodeRF", typeof(string));      // ���Е��ރR�[�h
            dataTable.Columns.Add("GoodsRateRankRF", typeof(string));            //  ���i�|�������N
            dataTable.Columns.Add("GoodsKindCodeRF", typeof(string));            //  ���i����
            dataTable.Columns.Add("TaxationDivCdRF", typeof(string));            //  �ېŋ敪
            dataTable.Columns.Add("GoodsNote1RF", typeof(string));               //  ���i���l�P
            dataTable.Columns.Add("GoodsNote2RF", typeof(string));               //  ���i���l�Q
            dataTable.Columns.Add("GoodsSpecialNoteRF", typeof(string));         //  ���i�K�i�E���L����

            dataTable.Columns.Add("PriceStartDateRF1", typeof(string));           //  ���i�J�n���P
            dataTable.Columns.Add("ListPriceRF1", typeof(string));                //  �艿�i�����j�P
            dataTable.Columns.Add("OpenPriceDivRF1", typeof(string));             //  �I�[�v�����i�敪�P
            dataTable.Columns.Add("StockRateRF1", typeof(string));                //  �d�����P
            dataTable.Columns.Add("SalesUnitCostRF1", typeof(string));            //  �����P���P

            dataTable.Columns.Add("PriceStartDateRF2", typeof(string));           //  ���i�J�n���Q
            dataTable.Columns.Add("ListPriceRF2", typeof(string));                //  �艿�i�����j�Q
            dataTable.Columns.Add("OpenPriceDivRF2", typeof(string));             //  �I�[�v�����i�敪�Q
            dataTable.Columns.Add("StockRateRF2", typeof(string));                //  �d�����Q
            dataTable.Columns.Add("SalesUnitCostRF2", typeof(string));            //  �����P���Q

            dataTable.Columns.Add("PriceStartDateRF3", typeof(string));           //  ���i�J�n���R
            dataTable.Columns.Add("ListPriceRF3", typeof(string));                //  �艿�i�����j�R
            dataTable.Columns.Add("OpenPriceDivRF3", typeof(string));             //  �I�[�v�����i�敪�R
            dataTable.Columns.Add("StockRateRF3", typeof(string));                //  �d�����R
            dataTable.Columns.Add("SalesUnitCostRF3", typeof(string));            //  �����P���R

            dataTable.Columns.Add("PriceStartDateRF4", typeof(string));           //  ���i�J�n���S
            dataTable.Columns.Add("ListPriceRF4", typeof(string));                //  �艿�i�����j�S
            dataTable.Columns.Add("OpenPriceDivRF4", typeof(string));             //  �I�[�v�����i�敪�S
            dataTable.Columns.Add("StockRateRF4", typeof(string));                //  �d�����S
            dataTable.Columns.Add("SalesUnitCostRF4", typeof(string));            //  �����P���S

            dataTable.Columns.Add("PriceStartDateRF5", typeof(string));           //  ���i�J�n���T
            dataTable.Columns.Add("ListPriceRF5", typeof(string));                //  �艿�i�����j�T
            dataTable.Columns.Add("OpenPriceDivRF5", typeof(string));             //  �I�[�v�����i�敪�T
            dataTable.Columns.Add("StockRateRF5", typeof(string));                //  �d�����T
            dataTable.Columns.Add("SalesUnitCostRF5", typeof(string));            //  �����P���T

            dataTable.Columns.Add("ErrorMessage", typeof(string));            //  �G���[���e
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="goodsUWork">��������</param>
        /// <param name="msg">DATE</param>
        /// <param name="dataTable">����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsUGoodsPriceUWork goodsUWork, string msg, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["GoodsNoRF"] = goodsUWork.GoodsNo;
            dataRow["GoodsMakerCdRF"] = goodsUWork.GoodsMakerCd;
            dataRow["GoodsNameRF"] = goodsUWork.GoodsName;
            dataRow["GoodsNameKanaRF"] = goodsUWork.GoodsNameKana;
            dataRow["JanRF"] = goodsUWork.Jan;
            dataRow["BLGoodsCodeRF"] = goodsUWork.BLGoodsCode;
            dataRow["EnterpriseGanreCodeRF"] = goodsUWork.EnterpriseGanreCode;
            dataRow["GoodsRateRankRF"] = goodsUWork.GoodsRateRank;
            dataRow["GoodsKindCodeRF"] = goodsUWork.GoodsKindCode;
            dataRow["TaxationDivCdRF"] = goodsUWork.TaxationDivCd;
            dataRow["GoodsNote1RF"] = goodsUWork.GoodsNote1;
            dataRow["GoodsNote2RF"] = goodsUWork.GoodsNote2;
            dataRow["GoodsSpecialNoteRF"] = goodsUWork.GoodsSpecialNote;
            Type type = goodsUWork.GetType();
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                dataRow["PriceStartDateRF" + index] = type.GetProperty("PriceStartDate" + index).GetValue(goodsUWork, null);
                dataRow["ListPriceRF" + index] = type.GetProperty("ListPrice" + index).GetValue(goodsUWork, null);
                dataRow["OpenPriceDivRF" + index] = type.GetProperty("OpenPriceDiv" + index).GetValue(goodsUWork, null);
                dataRow["StockRateRF" + index] = type.GetProperty("StockRate" + index).GetValue(goodsUWork, null);
                dataRow["SalesUnitCostRF" + index] = type.GetProperty("SalesUnitCost" + index).GetValue(goodsUWork, null);
            }
            dataRow["ErrorMessage"] = msg;
            dataTable.Rows.Add(dataRow);
        }
        #endregion
        // ------------DEL wangf 2012/07/03 FOR Redmine#30387---------<<<<*/

        # region �`�F�b�N
        # region ���b�Z�[�W
        private const string FORMAT_ERRMSG_LEN = "{0}�̌���{1}���ȓ��œ��͂��Ă��������B";
        private const string FORMAT_ERRMSG_TYPE = "{0}��{1}���͂̂݉\�ł��B";
        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}����͂��Ă��������B";
        private const string FORMAT_ERRMSG_ERRORVAL = "{0}���s���ł��B";
        //private const string ERRMSG_DUPLICATE = "�d���f�[�^���Ă��邽�ߓo�^�ł��܂���B"; // ADD wangf 2012/07/20 FOR Redmine#30387 // DEL wangf 2012/07/25 FOR Redmine#30387
        private const string ERRMSG_DUPLICATE = "�d���f�[�^�����邽�ߓo�^�ł��܂���B"; // ADD wangf 2012/07/25 FOR Redmine#30387
        # endregion
        # region ����
        /// <summary>
        /// CSV�t�@�C���`�F�b�N
        /// </summary>
        /// <param name="goodsUGoodsPriceUWork">���i�E���i�I�u�W�F�N�g</param>
        /// <param name="importSetUpList">�C���|�[�g�Ώېݒ胊�X�g</param>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="goodsUGoodsPriceUWorkCheckList">�t�B���^�[�p���i�}�X�^���X�g</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>TRUE:�G���[�Ȃ��AFALSE:�G���[����</returns>
        /// <remarks>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note : 2012/07/03 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note : 2012/07/10 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ��Q�ꗗ�̎w�ENO.55�̑Ή�</br>
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        //private bool CheckError(GoodsUGoodsPriceUWork goodsUGoodsPriceUWork, object importSetUpList, out string msg) // DEL wangf 2012/07/03 FOR Redmine#30387
        //private bool CheckError(GoodsUGoodsPriceUWork goodsUGoodsPriceUWork, object importSetUpList, Int32 processKbn, out string msg) // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
        private bool CheckError(GoodsUGoodsPriceUWork goodsUGoodsPriceUWork, object importSetUpList, Int32 processKbn, Int32 dataCheckKbn, List<GoodsUGoodsPriceUWork> goodsUGoodsPriceUWorkCheckList, List<GoodsPriceUWork> goodsPriceUWorkList, out string msg) // ADD wangf 2012/07/03 FOR Redmine#30387 // ADD wangf 2012/07/20 FOR Redmine#30387
        {
            msg = string.Empty;
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
            // �G���[�`�F�b�N����
            if (0 == dataCheckKbn)
            {
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                // �C���|�[�g�Ώېݒ胊�X�g
                //List<int[]> setUpInfoList = (List<int[]>)importSetUpList; // DEL wangf 2012/07/20 FOR Redmine#30387
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                List<int[]> setUpInfoList = new List<int[]>();
                for (int i = 0; i < ((List<int[]>)importSetUpList).Count; i++)
                {
                    int[] arr = new int[((List<int[]>)importSetUpList)[i].Length];
                    Array.Copy(((List<int[]>)importSetUpList)[i], arr, ((List<int[]>)importSetUpList)[i].Length);
                    setUpInfoList.Add(arr);
                }
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                // �����敪�F�ǉ��A���ׂč��ڃ`�F�b�N�Ώ�
                if (processKbn == 0)
                {
                    for (int i = 0; i < setUpInfoList.Count; i++)
                    {
                        setUpInfoList[i][1] = 0;
                    }
                }
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<

                #region ���i���
                // �i�ԁF�K�{���̓`�F�b�N
                if (!Check_IsNull("�i��", goodsUGoodsPriceUWork.GoodsNo, out msg))
                {
                    return false;
                }
                // �i�ԁF���͉^�C�v
                if (!Check_HalfEngNumFixedLength("�i��", goodsUGoodsPriceUWork.GoodsNo, out msg))
                {
                    return false;
                }
                // �i�ԁF��
                if (!Check_StrUnFixedLen("�i��", goodsUGoodsPriceUWork.GoodsNo, 24, out msg))
                {
                    return false;
                }

                // ���[�J�[�F�K�{���̓`�F�b�N
                if (!Check_DataEmpty("���[�J�[", goodsUGoodsPriceUWork.GoodsMakerCd, out msg))
                {
                    return false;
                }
                // ���[�J�[�F���͉^�C�v
                if (!Check_NumOnly("���[�J�[", goodsUGoodsPriceUWork.GoodsMakerCd, out msg))
                {
                    return false;
                }
                // ���[�J�[�F��
                if (!Check_StrUnFixedLen("���[�J�[", goodsUGoodsPriceUWork.GoodsMakerCd, 4, out msg))
                {
                    return false;
                }

                // �i���F�K�{���̓`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.GoodsName, setUpInfoList) && !Check_IsNull("�i��", goodsUGoodsPriceUWork.GoodsName, out msg))
                {
                    return false;
                }
                // �i���F��
                if (CheckUpdateDiv((int)ItemCode.GoodsName, setUpInfoList) && !Check_StrUnFixedLen("�i��", goodsUGoodsPriceUWork.GoodsName, 40, out msg))
                {
                    return false;
                }

                // �i���J�i�F�K�{���̓`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.GoodsNameKana, setUpInfoList) && !Check_IsNull("�i���J�i", goodsUGoodsPriceUWork.GoodsNameKana, out msg))
                {
                    return false;
                }
                // �i���J�i�F��
                if (CheckUpdateDiv((int)ItemCode.GoodsNameKana, setUpInfoList) && !Check_StrUnFixedLen("�i���J�i", goodsUGoodsPriceUWork.GoodsNameKana, 40, out msg))
                {
                    return false;
                }

                // �i�`�m�R�[�h�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.Jan, setUpInfoList) && !Check_NumOnly("�i�`�m�R�[�h", goodsUGoodsPriceUWork.Jan, out msg))
                {
                    return false;
                }
                // �i�`�m�R�[�h�F��
                if (CheckUpdateDiv((int)ItemCode.Jan, setUpInfoList) && !Check_StrUnFixedLen("�i�`�m�R�[�h", goodsUGoodsPriceUWork.Jan, 13, out msg))
                {
                    return false;
                }

                /* ------------DEL wangf 2012/07/10 FOR Redmine#30387--------->>>>
                // �a�k�R�[�h�F�K�{���̓`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList) && !Check_DataEmpty("�a�k�R�[�h", goodsUGoodsPriceUWork.BLGoodsCode, out msg))
                {
                    return false;
                }
                // ------------DEL wangf 2012/07/10 FOR Redmine#30387---------<<<<*/
                // �a�k�R�[�h�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList) && !Check_NumOnly("�a�k�R�[�h", goodsUGoodsPriceUWork.BLGoodsCode, out msg))
                {
                    return false;
                }
                // �a�k�R�[�h�F��
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList) && !Check_StrUnFixedLen("�a�k�R�[�h", goodsUGoodsPriceUWork.BLGoodsCode, 5, out msg))
                {
                    return false;
                }

                // ���i�敪�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.EnterpriseGanreCode, setUpInfoList) && !Check_NumOnly("���i�敪", goodsUGoodsPriceUWork.EnterpriseGanreCode, out msg))
                {
                    return false;
                }
                // ���i�敪�F��
                if (CheckUpdateDiv((int)ItemCode.EnterpriseGanreCode, setUpInfoList) && !Check_StrUnFixedLen("���i�敪", goodsUGoodsPriceUWork.EnterpriseGanreCode, 4, out msg))
                {
                    return false;
                }

                // �w�ʁF���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.GoodsRateRank, setUpInfoList) && !Check_HalfEngNumFixedLength("�w��", goodsUGoodsPriceUWork.GoodsRateRank, out msg))
                {
                    return false;
                }
                // �w�ʁF��
                if (CheckUpdateDiv((int)ItemCode.GoodsRateRank, setUpInfoList) && !Check_StrUnFixedLen("�w��", goodsUGoodsPriceUWork.GoodsRateRank, 2, out msg))
                {
                    return false;
                }

                // ���D�敪�F�K�{���̓`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_IsNull("���D�敪", goodsUGoodsPriceUWork.GoodsKindCode, out msg))
                {
                    return false;
                }
                // ���D�敪�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_NumOnly("���D�敪", goodsUGoodsPriceUWork.GoodsKindCode, out msg))
                {
                    return false;
                }
                // ���D�敪�F��
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_StrUnFixedLen("���D�敪", goodsUGoodsPriceUWork.GoodsKindCode, 1, out msg))
                {
                    return false;
                }
                // ���D�敪�F���[�J�[�Ɗ֘A�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_MakerCdAndGoodsKindCode("���D�敪", goodsUGoodsPriceUWork.GoodsMakerCd, goodsUGoodsPriceUWork.GoodsKindCode, out msg))
                {
                    return false;
                }
                // ------ ADD START 2012/07/12 Redmine#30387 ������ for ��Q�ꗗ�̎w�ENO.93�̑Ή�-------->>>>
                // ���D�敪�F�u0�v�Ɓu1�v
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && Convert.ToInt32(goodsUGoodsPriceUWork.GoodsKindCode.Trim()) != 0 && Convert.ToInt32(goodsUGoodsPriceUWork.GoodsKindCode.Trim()) != 1)
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, "���D�敪");
                    return false;
                }
                // ------ ADD END 2012/07/12 Redmine#30387 ������ for ��Q�ꗗ�̎w�ENO.93�̑Ή�--------<<<<

                // �ېŋ敪�F�K�{���̓`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && !Check_IsNull("�ېŋ敪", goodsUGoodsPriceUWork.TaxationDivCd, out msg))
                {
                    return false;
                }
                // �ېŋ敪�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && !Check_NumOnly("�ېŋ敪", goodsUGoodsPriceUWork.TaxationDivCd, out msg))
                {
                    return false;
                }
                // �ېŋ敪�F��
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && !Check_StrUnFixedLen("�ېŋ敪", goodsUGoodsPriceUWork.TaxationDivCd, 1, out msg))
                {
                    return false;
                }
                // ------ ADD START 2012/07/12 Redmine#30387 ������ for ��Q�ꗗ�̎w�ENO.93�̑Ή�-------->>>>
                // �ېŋ敪�F�u0�v�Ɓu1�v
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && Convert.ToInt32(goodsUGoodsPriceUWork.TaxationDivCd.Trim()) != 0 && Convert.ToInt32(goodsUGoodsPriceUWork.TaxationDivCd.Trim()) != 1)
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, "�ېŋ敪");
                    return false;
                }
                // ------ ADD END 2012/07/12 Redmine#30387 ������ for ��Q�ꗗ�̎w�ENO.93�̑Ή�--------<<<<
                // ���i���l�P�F��
                if (CheckUpdateDiv((int)ItemCode.GoodsNote1, setUpInfoList) && !Check_StrUnFixedLen("���i���l�P", goodsUGoodsPriceUWork.GoodsNote1, 40, out msg))
                {
                    return false;
                }

                // ���i���l�Q�F��
                if (CheckUpdateDiv((int)ItemCode.GoodsNote2, setUpInfoList) && !Check_StrUnFixedLen("���i���l�Q", goodsUGoodsPriceUWork.GoodsNote2, 40, out msg))
                {
                    return false;
                }

                // �K�i�E���L�����F��
                if (CheckUpdateDiv((int)ItemCode.GoodsSpecialNote, setUpInfoList) && !Check_StrUnFixedLen("�K�i�E���L����", goodsUGoodsPriceUWork.GoodsSpecialNote, 40, out msg))
                {
                    return false;
                }
                #endregion

                #region ���i���P
                // ���i�J�n�N�����P�F���i�P����͂���鎞�A���i�J�n�N�������K�{���͂ł��B
                if (!Check_PriceStartDateAndListPrice("���i�J�n�N�����P", goodsUGoodsPriceUWork.ListPrice1, goodsUGoodsPriceUWork.PriceStartDate1, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����P�F���͉^�C�v
                //if (!Check_NumOnly("���i�J�n�N�����P", goodsUGoodsPriceUWork.PriceStartDate1, out msg))// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                if (!Check_NumberOnly("���i�J�n�N�����P", goodsUGoodsPriceUWork.PriceStartDate1, out msg))// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                {
                    return false;
                }
                // ���i�J�n�N�����P�F��
                if (!Check_StrUnFixedLen("���i�J�n�N�����P", goodsUGoodsPriceUWork.PriceStartDate1, 8, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����P�F�ҏW���@�`�F�b�N
                if (!Check_YYYYMMDD("���i�J�n�N�����P", goodsUGoodsPriceUWork.PriceStartDate1, out msg))
                {
                    return false;
                }

                // ���i�P�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.ListPrice1, setUpInfoList) && !Check_NumOnly("���i�P", goodsUGoodsPriceUWork.ListPrice1, out msg))
                {
                    return false;
                }
                // ���i�P�F��
                if (CheckUpdateDiv((int)ItemCode.ListPrice1, setUpInfoList) && !Check_StrUnFixedLen("���i�P", goodsUGoodsPriceUWork.ListPrice1, 7, out msg))
                {
                    return false;
                }

                // �I�[�v�����i�敪�P�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv1, setUpInfoList) && !Check_NumOnly("�I�[�v�����i�敪�P", goodsUGoodsPriceUWork.OpenPriceDiv1, out msg))
                {
                    return false;
                }
                // �I�[�v�����i�敪�P�F��
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv1, setUpInfoList) && !Check_StrUnFixedLen("�I�[�v�����i�敪�P", goodsUGoodsPriceUWork.OpenPriceDiv1, 1, out msg))
                {
                    return false;
                }

                // �d�����P�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.StockRate1, setUpInfoList) && !Check_NumDouble("�d�����P", goodsUGoodsPriceUWork.StockRate1, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate1))
                {
                    return false;
                }
                // �d�����P�F��
                if (CheckUpdateDiv((int)ItemCode.StockRate1, setUpInfoList) && !Check_StrUnFixedLen("�d�����P", goodsUGoodsPriceUWork.StockRate1, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate1))
                {
                    return false;
                }
                // �d�����P�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.StockRate1, setUpInfoList) && !Check_FloatAndLen("�d�����P", goodsUGoodsPriceUWork.StockRate1, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate1))
                {
                    return false;
                }

                // ���P���P�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1, setUpInfoList) && !Check_NumDouble("���P���P", goodsUGoodsPriceUWork.SalesUnitCost1, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost1))
                {
                    return false;
                }
                // ���P���P�F��
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1, setUpInfoList) && !Check_StrUnFixedLen("���P���P", goodsUGoodsPriceUWork.SalesUnitCost1, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost1))
                {
                    return false;
                }
                // ���P���P�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1, setUpInfoList) && !Check_FloatAndLen("���P���P", goodsUGoodsPriceUWork.SalesUnitCost1, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost1))
                {
                    return false;
                }
                #endregion

                #region ���i���Q
                // ���i�J�n�N�����Q�F���i�Q����͂���鎞�A���i�J�n�N�������K�{���͂ł��B
                if (!Check_PriceStartDateAndListPrice("���i�J�n�N�����Q", goodsUGoodsPriceUWork.ListPrice2, goodsUGoodsPriceUWork.PriceStartDate2, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����Q�F���͉^�C�v
                //if (!Check_NumOnly("���i�J�n�N�����Q", goodsUGoodsPriceUWork.PriceStartDate2, out msg))// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                if (!Check_NumberOnly("���i�J�n�N�����Q", goodsUGoodsPriceUWork.PriceStartDate2, out msg))// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                {
                    return false;
                }
                // ���i�J�n�N�����Q�F��
                if (!Check_StrUnFixedLen("���i�J�n�N�����Q", goodsUGoodsPriceUWork.PriceStartDate2, 8, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����Q�F�ҏW���@�`�F�b�N
                if (!Check_YYYYMMDD("���i�J�n�N�����Q", goodsUGoodsPriceUWork.PriceStartDate2, out msg))
                {
                    return false;
                }

                // ���i�Q�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.ListPrice2, setUpInfoList) && !Check_NumOnly("���i�Q", goodsUGoodsPriceUWork.ListPrice2, out msg))
                {
                    return false;
                }
                // ���i�Q�F��
                if (CheckUpdateDiv((int)ItemCode.ListPrice2, setUpInfoList) && !Check_StrUnFixedLen("���i�Q", goodsUGoodsPriceUWork.ListPrice2, 7, out msg))
                {
                    return false;
                }

                // �I�[�v�����i�敪�Q�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv2, setUpInfoList) && !Check_NumOnly("�I�[�v�����i�敪�Q", goodsUGoodsPriceUWork.OpenPriceDiv2, out msg))
                {
                    return false;
                }
                // �I�[�v�����i�敪�Q�F��
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv2, setUpInfoList) && !Check_StrUnFixedLen("�I�[�v�����i�敪�Q", goodsUGoodsPriceUWork.OpenPriceDiv2, 1, out msg))
                {
                    return false;
                }

                // �d�����Q�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.StockRate2, setUpInfoList) && !Check_NumDouble("�d�����Q", goodsUGoodsPriceUWork.StockRate2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate2))
                {
                    return false;
                }
                // �d�����Q�F��
                if (CheckUpdateDiv((int)ItemCode.StockRate2, setUpInfoList) && !Check_StrUnFixedLen("�d�����Q", goodsUGoodsPriceUWork.StockRate2, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate2))
                {
                    return false;
                }
                // �d�����Q�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.StockRate2, setUpInfoList) && !Check_FloatAndLen("�d�����Q", goodsUGoodsPriceUWork.StockRate2, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate2))
                {
                    return false;
                }

                // ���P���Q�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost2, setUpInfoList) && !Check_NumDouble("���P���Q", goodsUGoodsPriceUWork.SalesUnitCost2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost2))
                {
                    return false;
                }
                // ���P���Q�F��
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost2, setUpInfoList) && !Check_StrUnFixedLen("���P���Q", goodsUGoodsPriceUWork.SalesUnitCost2, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost2))
                {
                    return false;
                }
                // ���P���Q�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost2, setUpInfoList) && !Check_FloatAndLen("���P���Q", goodsUGoodsPriceUWork.SalesUnitCost2, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost2))
                {
                    return false;
                }
                #endregion

                #region ���i���R
                // ���i�J�n�N�����R�F���i�R����͂���鎞�A���i�J�n�N�������K�{���͂ł��B
                if (!Check_PriceStartDateAndListPrice("���i�J�n�N�����R", goodsUGoodsPriceUWork.ListPrice3, goodsUGoodsPriceUWork.PriceStartDate3, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����R�F���͉^�C�v
                //if (!Check_NumOnly("���i�J�n�N�����R", goodsUGoodsPriceUWork.PriceStartDate3, out msg))// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                if (!Check_NumberOnly("���i�J�n�N�����R", goodsUGoodsPriceUWork.PriceStartDate3, out msg))// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                {
                    return false;
                }
                // ���i�J�n�N�����R�F��
                if (!Check_StrUnFixedLen("���i�J�n�N�����R", goodsUGoodsPriceUWork.PriceStartDate3, 8, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����R�F�ҏW���@�`�F�b�N
                if (!Check_YYYYMMDD("���i�J�n�N�����R", goodsUGoodsPriceUWork.PriceStartDate3, out msg))
                {
                    return false;
                }

                // ���i�R�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.ListPrice3, setUpInfoList) && !Check_NumOnly("���i�R", goodsUGoodsPriceUWork.ListPrice3, out msg))
                {
                    return false;
                }
                // ���i�R�F��
                if (CheckUpdateDiv((int)ItemCode.ListPrice3, setUpInfoList) && !Check_StrUnFixedLen("���i�R", goodsUGoodsPriceUWork.ListPrice3, 7, out msg))
                {
                    return false;
                }

                // �I�[�v�����i�敪�R�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv3, setUpInfoList) && !Check_NumOnly("�I�[�v�����i�敪�R", goodsUGoodsPriceUWork.OpenPriceDiv3, out msg))
                {
                    return false;
                }
                // �I�[�v�����i�敪�R�F��
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv3, setUpInfoList) && !Check_StrUnFixedLen("�I�[�v�����i�敪�R", goodsUGoodsPriceUWork.OpenPriceDiv3, 1, out msg))
                {
                    return false;
                }

                // �d�����R�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.StockRate3, setUpInfoList) && !Check_NumDouble("�d�����R", goodsUGoodsPriceUWork.StockRate3, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate3))
                {
                    return false;
                }
                // �d�����R�F��
                if (CheckUpdateDiv((int)ItemCode.StockRate3, setUpInfoList) && !Check_StrUnFixedLen("�d�����R", goodsUGoodsPriceUWork.StockRate3, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate3))
                {
                    return false;
                }
                // �d�����R�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.StockRate3, setUpInfoList) && !Check_FloatAndLen("�d�����R", goodsUGoodsPriceUWork.StockRate3, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate3))
                {
                    return false;
                }

                // ���P���R�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost3, setUpInfoList) && !Check_NumDouble("���P���R", goodsUGoodsPriceUWork.SalesUnitCost3, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost3))
                {
                    return false;
                }
                // ���P���R�F��
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost3, setUpInfoList) && !Check_StrUnFixedLen("���P���R", goodsUGoodsPriceUWork.SalesUnitCost3, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost3))
                {
                    return false;
                }
                // ���P���R�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost3, setUpInfoList) && !Check_FloatAndLen("���P���R", goodsUGoodsPriceUWork.SalesUnitCost3, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost3))
                {
                    return false;
                }
                #endregion

                #region ���i���S
                // ���i�J�n�N�����S�F���i�S����͂���鎞�A���i�J�n�N�������K�{���͂ł��B
                if (!Check_PriceStartDateAndListPrice("���i�J�n�N�����S", goodsUGoodsPriceUWork.ListPrice4, goodsUGoodsPriceUWork.PriceStartDate4, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����S�F���͉^�C�v
                //if (!Check_NumOnly("���i�J�n�N�����S", goodsUGoodsPriceUWork.PriceStartDate4, out msg))// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                if (!Check_NumberOnly("���i�J�n�N�����S", goodsUGoodsPriceUWork.PriceStartDate4, out msg))// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                {
                    return false;
                }
                // ���i�J�n�N�����S�F��
                if (!Check_StrUnFixedLen("���i�J�n�N�����S", goodsUGoodsPriceUWork.PriceStartDate4, 8, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����S�F�ҏW���@�`�F�b�N
                if (!Check_YYYYMMDD("���i�J�n�N�����S", goodsUGoodsPriceUWork.PriceStartDate4, out msg))
                {
                    return false;
                }

                // ���i�S�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.ListPrice4, setUpInfoList) && !Check_NumOnly("���i�S", goodsUGoodsPriceUWork.ListPrice4, out msg))
                {
                    return false;
                }
                // ���i�S�F��
                if (CheckUpdateDiv((int)ItemCode.ListPrice4, setUpInfoList) && !Check_StrUnFixedLen("���i�S", goodsUGoodsPriceUWork.ListPrice4, 7, out msg))
                {
                    return false;
                }

                // �I�[�v�����i�敪�S�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv4, setUpInfoList) && !Check_NumOnly("�I�[�v�����i�敪�S", goodsUGoodsPriceUWork.OpenPriceDiv4, out msg))
                {
                    return false;
                }
                // �I�[�v�����i�敪�S�F��
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv4, setUpInfoList) && !Check_StrUnFixedLen("�I�[�v�����i�敪�S", goodsUGoodsPriceUWork.OpenPriceDiv4, 1, out msg))
                {
                    return false;
                }

                // �d�����S�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.StockRate4, setUpInfoList) && !Check_NumDouble("�d�����S", goodsUGoodsPriceUWork.StockRate4, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate4))
                {
                    return false;
                }
                // �d�����S�F��
                if (CheckUpdateDiv((int)ItemCode.StockRate4, setUpInfoList) && !Check_StrUnFixedLen("�d�����S", goodsUGoodsPriceUWork.StockRate4, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate4))
                {
                    return false;
                }
                // �d�����S�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.StockRate4, setUpInfoList) && !Check_FloatAndLen("�d�����S", goodsUGoodsPriceUWork.StockRate4, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate4))
                {
                    return false;
                }

                // ���P���S�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost4, setUpInfoList) && !Check_NumDouble("���P���S", goodsUGoodsPriceUWork.SalesUnitCost4, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost4))
                {
                    return false;
                }
                // ���P���S�F��
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost4, setUpInfoList) && !Check_StrUnFixedLen("���P���S", goodsUGoodsPriceUWork.SalesUnitCost4, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost4))
                {
                    return false;
                }
                // ���P���S�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost4, setUpInfoList) && !Check_FloatAndLen("���P���S", goodsUGoodsPriceUWork.SalesUnitCost4, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost4))
                {
                    return false;
                }
                #endregion

                #region ���i���T
                // ���i�J�n�N�����T�F���i�T����͂���鎞�A���i�J�n�N�������K�{���͂ł��B
                if (!Check_PriceStartDateAndListPrice("���i�J�n�N�����T", goodsUGoodsPriceUWork.ListPrice5, goodsUGoodsPriceUWork.PriceStartDate5, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����T�F���͉^�C�v
                //if (!Check_NumOnly("���i�J�n�N�����T", goodsUGoodsPriceUWork.PriceStartDate5, out msg))// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                if (!Check_NumberOnly("���i�J�n�N�����T", goodsUGoodsPriceUWork.PriceStartDate5, out msg))// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                {
                    return false;
                }
                // ���i�J�n�N�����T�F��
                if (!Check_StrUnFixedLen("���i�J�n�N�����T", goodsUGoodsPriceUWork.PriceStartDate5, 8, out msg))
                {
                    return false;
                }
                // ���i�J�n�N�����T�F�ҏW���@�`�F�b�N
                if (!Check_YYYYMMDD("���i�J�n�N�����T", goodsUGoodsPriceUWork.PriceStartDate5, out msg))
                {
                    return false;
                }

                // ���i�T�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.ListPrice5, setUpInfoList) && !Check_NumOnly("���i�T", goodsUGoodsPriceUWork.ListPrice5, out msg))
                {
                    return false;
                }
                // ���i�T�F��
                if (CheckUpdateDiv((int)ItemCode.ListPrice5, setUpInfoList) && !Check_StrUnFixedLen("���i�T", goodsUGoodsPriceUWork.ListPrice5, 7, out msg))
                {
                    return false;
                }

                // �I�[�v�����i�敪�T�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv5, setUpInfoList) && !Check_NumOnly("�I�[�v�����i�敪�T", goodsUGoodsPriceUWork.OpenPriceDiv5, out msg))
                {
                    return false;
                }
                // �I�[�v�����i�敪�T�F��
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv5, setUpInfoList) && !Check_StrUnFixedLen("�I�[�v�����i�敪�T", goodsUGoodsPriceUWork.OpenPriceDiv5, 1, out msg))
                {
                    return false;
                }

                // �d�����T�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.StockRate5, setUpInfoList) && !Check_NumDouble("�d�����T", goodsUGoodsPriceUWork.StockRate5, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate5))
                {
                    return false;
                }
                // �d�����T�F��
                if (CheckUpdateDiv((int)ItemCode.StockRate5, setUpInfoList) && !Check_StrUnFixedLen("�d�����T", goodsUGoodsPriceUWork.StockRate5, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate5))
                {
                    return false;
                }
                // �d�����T�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.StockRate5, setUpInfoList) && !Check_FloatAndLen("�d�����T", goodsUGoodsPriceUWork.StockRate5, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate5))
                {
                    return false;
                }

                // ���P���T�F���͉^�C�v
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost5, setUpInfoList) && !Check_NumDouble("���P���T", goodsUGoodsPriceUWork.SalesUnitCost5, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost5))
                {
                    return false;
                }
                // ���P���T�F��
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost5, setUpInfoList) && !Check_StrUnFixedLen("���P���T", goodsUGoodsPriceUWork.SalesUnitCost5, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost5))
                {
                    return false;
                }
                // ���P���T�F�ҏW���@�`�F�b�N
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost5, setUpInfoList) && !Check_FloatAndLen("���P���T", goodsUGoodsPriceUWork.SalesUnitCost5, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost5))
                {
                    return false;
                }
                #endregion
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
            }
            // ���i�}�X�^�d���`�F�b�N
            int countGoodU = goodsUGoodsPriceUWorkCheckList.FindAll(
                delegate(GoodsUGoodsPriceUWork p)
                {
                    return (p.EnterpriseCode == goodsUGoodsPriceUWork.EnterpriseCode
                           && p.GoodsNo == goodsUGoodsPriceUWork.GoodsNo
                           && p.GoodsMakerCd == goodsUGoodsPriceUWork.GoodsMakerCd
                          );
                }).Count;
            if (countGoodU > 1)
            {
                msg = ERRMSG_DUPLICATE;
                return false;
            }
            // ���i�}�X�^���X�g�d���`�F�b�N
            foreach (GoodsPriceUWork goodsPriceUWorkLocal in goodsPriceUWorkList)
            {
                int countGoodsPriceU = goodsPriceUWorkList.FindAll(
                    delegate(GoodsPriceUWork x)
                    {
                        return (x.PriceStartDate != DateTime.MinValue
                                && x.EnterpriseCode == goodsPriceUWorkLocal.EnterpriseCode
                                && x.GoodsNo == goodsPriceUWorkLocal.GoodsNo
                                && x.GoodsMakerCd == goodsPriceUWorkLocal.GoodsMakerCd
                                && x.PriceStartDate == goodsPriceUWorkLocal.PriceStartDate
                               );
                    }).Count;
                if (countGoodsPriceU > 1)
                {
                    msg = ERRMSG_DUPLICATE;
                    return false;
                }
            }
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<

            return true;
        }

        /// <summary>
        /// ���[�J�[�Ə��D�敪�֘A�`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsKindCode">�D�ǋ敪</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�Ɗ֘A�`�F�b�N���s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_MakerCdAndGoodsKindCode(string fieldNm, string goodsMakerCd, string goodsKindCode, out string msg)
        {
            msg = string.Empty;
            try
            {
                // �������ꍇ�F���i���i�̃��[�J�[�R�[�h��1000�A�D�Ǖ��i�̃��[�J�[�R�[�h����1000
                if ((Convert.ToInt32(goodsMakerCd) < 1000 && Convert.ToInt32(goodsKindCode) == 1)
                    || Convert.ToInt32(goodsMakerCd) >= 1000 && Convert.ToInt32(goodsKindCode) == 0)
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                    return false;
                }
                return true;
            }
            catch
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }
        }

        /// <summary>
        /// ���i�J�n�N�����Ɖ��i�֘A�`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="listPrice">���i</param>
        /// <param name="priceStartDate">���i�J�n�N������</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�Ɗ֘A�`�F�b�N���s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_PriceStartDateAndListPrice(string fieldNm, string listPrice, string priceStartDate, out string msg)
        {
            msg = string.Empty;
            try
            {
                // �������ꍇ�F���i�Ȃǂ���͂���鎞�A���i�J�n�N�������K�{���͂ł��B
                if (!Check_DataEmpty(listPrice) && (Check_DataEmpty(priceStartDate)))
                {
                    msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }
        }

        /// <summary>
        /// "0"��string.Empty���`�F�b�N����
        /// </summary>
        /// <param name="dateData">�l</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : "0"��string.Empty���`�F�b�N����B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_DataEmpty(string dateData)
        {
            if ("0".Equals(dateData.Trim()) || string.IsNullOrEmpty(dateData.Trim()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// NULL�̔��f�i0�܂ށj
        /// </summary>
        /// <param name="fileldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : NULL�̔��f�i0�܂ށj���s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_DataEmpty(string fileldNm, string val, out string msg)
        {
            msg = string.Empty;
            if ("0".Equals(val.Trim()) || string.IsNullOrEmpty(val.Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fileldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �����̂݃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����̂݃`�F�b�N�B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/26 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ��Q�ꗗ�̎w�ENO.94�̑Ή� �G���[���b�Z�[�W�̕ύX�̑Ή�</br>
        /// </remarks>
        private bool Check_NumOnly(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = "^(0|[[0-9]+)$";
            if (!Regex.IsMatch(val, regexStr) && !string.IsNullOrEmpty(val))
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// DEL  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/26  ������ Redmine#30387 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                return false;
            }
            return true;
        }

        // ------ ADD START 2012/07/26 Redmine#30387 ������ for ��Q�ꗗ�̎w�ENO.94�̑Ή�-------->>>>
        /// <summary>
        /// �����̂݃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����̂݃`�F�b�N�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private bool Check_NumberOnly(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = "^(0|[[0-9]+)$";
            if (!Regex.IsMatch(val, regexStr) && !string.IsNullOrEmpty(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���t");
                return false;
            }
            return true;
        }
        // ------ ADD END 2012/07/26 Redmine#30387 ������ for ��Q�ꗗ�̎w�ENO.94�̑Ή�--------<<<<
        /// <summary>
        /// �����̂݃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����̂݃`�F�b�N�B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_NumDouble(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = "^\\d+(\\.\\d+)?$";
            if (!Check_DataEmpty(val) && !Regex.IsMatch(val, regexStr))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");
                return false;
            }
            return true;
        }

        /// <summary>
        /// �����l�A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="valLen">���ڒ���</param>
        /// <param name="dotLen">�_�ӏ�</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����l�A�������`�F�b�N����B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_FloatAndLen(string fieldNm, string val, int valLen, int dotLen, out string msg)
        {
            msg = string.Empty;
            if (!Check_DataEmpty(val) && Regex.IsMatch(val, @"^([0-9]{1,}([.][0-9]{0,})?)$"))
            {
                string regexStrLen = @"^([0-9]{1," + valLen.ToString() + "}([.][0-9]{1," + dotLen.ToString() + "})?)$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// NULL�̔��f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : NULL�̔��f�B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �������w�肵�Ȃ��̕�����`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �������w�肵�Ȃ��̕�����`�F�b�N�B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/06/26 wangf </br>
        /// <br>           : 10801804-00�A���������o�b�O�̑Ή��F�����`�F�b�N���A�S�p�������ꌅ�Ɍv�Z����悤�ɕύX</br>
        /// </remarks>
        private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //if (CountWordLen(val) > len) // DEL wangf 2012/06/26 FOR ���������o�b�O�̑Ή�
            if (val.Trim().Length > len) // ADD wangf 2012/06/26 FOR ���������o�b�O�̑Ή�
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, len);
                return false;
            }
            return true;
        }

        /* ------------DEL wangf 2012/06/26 FOR ���������o�b�O�̑Ή� --------->>>>
        /// <summary>
        /// ���p�A�S�p�̒����v�Z
        /// </summary>
        /// <param name="val">�l</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : ���p�A�S�p�̒����v�Z</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public int CountWordLen(string val)
        {
            int wordLen = 0;
            char[] charArr = val.ToCharArray();
            foreach (char charItem in charArr)
            {
                string str = charItem.ToString();
                wordLen += Encoding.Default.GetBytes(str).Length;
            }
            return wordLen;
        }
        // ------------DEL wangf 2012/06/26 FOR ���������o�b�O�̑Ή� ---------<<<<*/

        /// <summary>
        /// ���p�p�����A�����̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : ���p�p�����A�����̃`�F�b�N�B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = @"^[a-zA-Z0-9 \-_.+=#$*&@%\\[~!_():;'?,/""<>\[\]^`{|}]{1,}$";
            if (!Regex.IsMatch(val, regexStr) && !string.IsNullOrEmpty(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���p�p�����A����");
                return false;
            }
            return true;
        }

        /// <summary>
        /// �����`�F�b�N(20120201)
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       :  �����`�F�b�N(20120201)�B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_YYYYMMDD(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            try
            {
                if (!Check_DataEmpty(val))
                {
                    if (Convert.ToInt32(val) != 0)
                    {
                        DateTime dt = DateTime.ParseExact(val, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    }
                }
            }
            catch
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }

            return true;
        }
        # endregion
        # endregion
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
    }

    #region ���i���I�u�W�F�N�g
    /// <summary>
    /// ���i���I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class GoodsUImportWorkWrap
    {
        #region Public Field
        public GoodsUWork goodsWork;
        #endregion

        #region �N���X�R���X�g���N�^
        /// <summary>
        /// ���i���I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i���I�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public GoodsUImportWorkWrap(GoodsUWork goodsWork)
        {
            this.goodsWork = goodsWork;
        }
        #endregion

        #region ���i���I�u�W�F�N�g�̃C�R�[���̔�r
        /// <summary>
        /// ���i���I�u�W�F�N�g�̃C�R�[���̔�r
        /// </summary>
        /// <param name="obj">���i���I�u�W�F�N�g</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : ���i���I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            GoodsUImportWorkWrap target = obj as GoodsUImportWorkWrap;
            if (target == null) return false;
            // ��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ�
            // �������ꍇ�A���i���I�u�W�F�N�g�̓C�R�[���ɂ���B
            return target.goodsWork.EnterpriseCode == goodsWork.EnterpriseCode
                     && target.goodsWork.GoodsMakerCd == goodsWork.GoodsMakerCd
                     && target.goodsWork.GoodsNo == goodsWork.GoodsNo;
        }
        #endregion

        #region ���i���I�u�W�F�N�g�̃n�V�R�[�h
        /// <summary>
        /// ���i���I�u�W�F�N�g�̃n�V�R�[�h
        /// </summary>
        /// <returns>�n�V�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : ���i���I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return goodsWork.EnterpriseCode.GetHashCode()
                     + goodsWork.GoodsMakerCd.GetHashCode()
                     + goodsWork.GoodsNo.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region ���i���I�u�W�F�N�g
    /// <summary>
    /// ���i���I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class GoodsPriceUImportWorkWrap
    {
        #region Public Field
        public GoodsPriceUWork goodsPriceWork;
        #endregion

        #region �N���X�R���X�g���N�^
        /// <summary>
        /// ���i���I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i���I�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public GoodsPriceUImportWorkWrap(GoodsPriceUWork goodsPriceWork)
        {
            this.goodsPriceWork = goodsPriceWork;
        }
        #endregion

        #region ���i���I�u�W�F�N�g�̃C�R�[���̔�r
        /// <summary>
        /// ���i���I�u�W�F�N�g�̃C�R�[���̔�r
        /// </summary>
        /// <param name="obj">���i���I�u�W�F�N�g</param>
        /// <returns>��r����</returns>
        /// <remarks>
        /// <br>Note       : ���i���I�u�W�F�N�g�̃C�R�[�����ǂ������r����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            GoodsPriceUImportWorkWrap target = obj as GoodsPriceUImportWorkWrap;
            if (target == null) return false;
            // ��ƃR�[�h�A���i���[�J�[�R�[�h�A���i�ԍ��A���i�J�n��
            // �������ꍇ�A���i���I�u�W�F�N�g�̓C�R�[���ɂ���B
            return target.goodsPriceWork.EnterpriseCode == goodsPriceWork.EnterpriseCode
                     && target.goodsPriceWork.GoodsMakerCd == goodsPriceWork.GoodsMakerCd
                     && target.goodsPriceWork.GoodsNo == goodsPriceWork.GoodsNo
                     && target.goodsPriceWork.PriceStartDate == goodsPriceWork.PriceStartDate;
        }
        #endregion

        #region ���i���I�u�W�F�N�g�̃n�V�R�[�h
        /// <summary>
        /// ���i���I�u�W�F�N�g�̃n�V�R�[�h
        /// </summary>
        /// <returns>�n�V�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : ���i���I�u�W�F�N�g�̃n�V�R�[�h��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return goodsPriceWork.EnterpriseCode.GetHashCode()
                     + goodsPriceWork.GoodsMakerCd.GetHashCode()
                     + goodsPriceWork.GoodsNo.GetHashCode()
                     + goodsPriceWork.PriceStartDate.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region ���i����r�I�u�W�F�N�g
    /// <summary>
    /// ���i����r�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i����r�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.06.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class GoodsPriceCompare<T> : IComparer<T>
    {
        int IComparer<T>.Compare(T t1, T t2)
        {
            GoodsPriceUWork o1 = t1 as GoodsPriceUWork;
            GoodsPriceUWork o2 = t2 as GoodsPriceUWork;
            int ret = -1;
            if (o1.EnterpriseCode == o2.EnterpriseCode && o1.GoodsMakerCd == o2.GoodsMakerCd && o1.GoodsNo == o2.GoodsNo)
            {
                ret = o1.PriceStartDate.CompareTo(o2.PriceStartDate);
            }
            return ret;
        }
    }

    //----- ADD 2015/05/20 �c���� Redmine#45693 ---------->>>>>
    /// <summary>
    /// ���i����r�I�u�W�F�N�g(��ƃR�[�h�E���[�J�[�R�[�h�E�i��)
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i����r�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2009.06.24</br>
    /// </remarks>
    class GoodsPriceCompare2 : IComparer
    {
        int IComparer.Compare(object t1, object t2)
        {
            GoodsPriceUWork o1 = t1 as GoodsPriceUWork;
            GoodsPriceUWork o2 = t2 as GoodsPriceUWork;
            int ret = -1;
            ret = o1.EnterpriseCode.CompareTo(o2.EnterpriseCode);
            if (ret == 0)
            {
                ret = o1.GoodsMakerCd.CompareTo(o2.GoodsMakerCd);
            }
            if (ret == 0)
            {
                ret = o1.GoodsNo.CompareTo(o2.GoodsNo);
            }

            return ret;
        }
    }
    //----- ADD 2015/05/20 �c���� Redmine#45693 ----------<<<<<
    #endregion
}
