//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I����������DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �I�����������̎��f�[�^������s���N���X�ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22035 �O�� �O��
// �� �� ��  2007.04.04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22035 �O�� �O��
// �� �� ��  2007.08.31  �C�����e : �ŏI�����@�̏ꍇ�A����̎d�����P���������I�ɂO�ɂ���i���ЁA����N�G���𕪂���j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �� �� ��  2008.12.02  �C�����e : PM.NS�l�ɏC�� & �s��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �� �� ��  2009.01.30  �C�����e : �s��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �� �� ��  2009/05/11  �C�����e : �d�l�ύX&�s��C��( MANTIS ID:13257 )
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �� �� ��  2009/05/22  �C�����e : �d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/11/30  �C�����e : �d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : �����
// �� �� ��  2010/02/20  �C�����e : �@���x�A�b�v�Ή�
//                                  �APM1005 �q�ɂ̎w��敪���u�P�Ɓv�̏ꍇ�A���͂��ꂽ�q�ɃR�[�h�Ő��������o�����悤�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : yangmj
// �� �� ��  2011/01/11  �C�����e : �I����Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/01/28  �C�����e : readmine#18750�A18751�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/01/30  �C�����e : readmine#18780�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2011/02/10  �C�����e : readmine#18863�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2011/02/11  �C�����e : readmine#18876�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : wangf
// �� �� ��  2011/09/02  �C�����e : NS���[�U�[���Ǘv�]�ꗗ_20110629_�D��_PM7����_��Q_�A��1014�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : wangf
// �� �� ��  2012/03/23  �쐬���e : readmine#29109�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{��
// �� �� ��  2012/04/09  �C�����e : ��Q�C�� ���i�Ǘ����̎d����K�p�`�F�b�N�������C��
//                                  �����̐ݒ���@���C���A�݌Ɏ擾�N�G���ɋ��_������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{��
// �� �� ��  2012/05/21  �C�����e : �ǉ���Q�C�� �������x����A�ݏo�E�����s���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����H
// �C �� ��  2012/05/25  �C�����e : 2012/06/27�z�M���ARedmine#29996
//                                  �I�������[�@�I���A�Ԃ��A�A�Ԃň󎚂���Ȃ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : yangyi
// �C �� ��  2012/06/08  �C�����e : 2012/06/27�z�M���ARedmine#30282
//                                  ��1002�@�I�����������̉��ǂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{��
// �� �� ��  2012/06/14  �C�����e : �݌Ɏ擾�̃N�G���ŋ��_�R�[�h��int�Ƃ��Ĉ����Ă�����Q�̏C��
//                                  �I�����_�݂̂��w�肵���ꍇ�A�N�G�����s���ɂȂ��Q�̏C��
//                                  �����v��A�ݏo�̎d����͔���f�[�^�̒l�����̂܂܎g�p����悤�C��(�f�O��)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  �@�@�@�@    �쐬�S�� : ������
// �C �� ��  2012/07/10  �C�����e : Redmine#31103�I�����������̑��x���ǂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901225-00 �쐬�S�� : zhoug
// �� �� ��  2013/03/06  �C�����e : 10901225-00 2013/5/15�z�M���ً̋}�Ή�
//                                  Redmine#34756�Ή��F�I����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00    �쐬�S�� : yangyi
// �C �� ��  2013/05/06 �C�����e : �z�M���̑Ή��ARedmine#35493 
//                                     �I�����������ŁA�|���}�X�^�̌������������ɁA�������Ԃ������A���T�[�o�[���ׂ������Ȃ�(#1902)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00    �쐬�S�� : wangl2
// �C �� ��  2013/06/07     �C�����e : Redmine#35788 
//                                     �u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j
//                                      �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00    �쐬�S�� : caohh
// �C �� ��  2015/03/06     �C�����e : Redmine#44951
//                                     �I�����������̕s��ɂ��đΉ�
//                                     �@�����v�Z�̊|���O���[�v�̃p�����[�^�̐ݒ���C��
//                                      �i�O���[�v�R�[�h�}�X�^�̏��i������->BL�R�[�h�}�X�^�̏��i�����ނɕύX�j
//                                     �A�������擾����������C��
//                                      �i�I����>=���i�}�X�^�̉��i�J�n���̏�����ǉ��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : 杍^
// �C �� ��  2020/06/18  �C�����e : PMKOBETSU-4005 ���i�}�X�^�@�艿���l�ϊ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11675035-00    �쐬�S�� : 杍^
// �C �� ��  2020/07/23     �C�����e : PMKOBETSU-3551 �I���������������s����Ə����Ɏ��s���錻�ۂ̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770024-00    �쐬�S�� : 杍^
// �C �� ��  2021/03/16     �C�����e : PMKOBETSU-3551 �I�����������̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;     //ADD �����H 2012/05/25 Redmine#29996
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I����������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�����������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2007.04.04</br>
    /// <br></br>
    /// <br>UpdateNote : �ŏI�����@�̏ꍇ�A����̎d�����P���������I�ɂO�ɂ���i���ЁA����N�G���𕪂���j</br>
    /// <br>           : �ꊇ�C���T�[�g���ɁA�I���敪��Null�Ŋi�[����Ă����������C��</br>
    /// <br>Programer  : 22035�@�O�� �O��</br>
    /// <br>Date       : 2007.08.31</br>
    /// <br></br>
    /// <br>UpdateNote : �s��C��</br>
    /// <br>Programer  : 23012�@���� �[���N</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br></br>
    /// <br>UpdateNote : �s��C��</br>
    /// <br>Programer  : 23012�@���� �[���N</br>
    /// <br>Date       : 2009.01.30</br>
    /// <br></br>
    /// <br>UpdateNote : �d�l�ύX&�s��C��( MANTIS ID:13257 )</br>
    /// <br>Programer  : 23012�@���� �[���N</br>
    /// <br>Date       : 2009/05/11</br>
    /// <br></br>
    /// <br>UpdateNote : �d�l�ύX&�s��C��</br>
    /// <br>Programer  : 23012�@���� �[���N</br>
    /// <br>Date       : 2009/05/22</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/30 ���M �ێ�˗��B�Ή�</br>
    /// <br>             �����f�[�^���ݎ��̏������e��ύX</br>
    /// <br>Update Note : 2010/02/20 ����� PM1005</br>
    /// <br>             �@���x�A�b�v�Ή�</br>
    /// <br>             �A�q�ɂ̎w��敪���u�P�Ɓv�̏ꍇ�A���͂��ꂽ�q�ɃR�[�h�Ő��������o�����悤�ɕύX</br>
    /// <br>Update Note : 2011/01/11 yangmj �I����Q�Ή�</br>
    /// <br>Update Note : 2011/09/02 wangf NS���[�U�[���Ǘv�]�ꗗ_20110629_�D��_PM7����_��Q_�A��1014�̑Ή�</br>
    /// <br>Update Note:  2012/03/23 wangf </br>
    /// <br>             redmine#29109�̑Ή�</br>
    /// <br>Update Note: 2012/05/25 �����H</br>
    /// <br>�Ǘ��ԍ�   �F10801804-00 2012/06/27�z�M��</br>
    /// <br>             Redmine#29996�@�I�������[�@�I���A�Ԃ��A�A�Ԃň󎚂���Ȃ��̑Ή�</br>
    /// <br>Update Note: 2013/03/06 zhoug</br>
    /// <br>�Ǘ��ԍ�   �F10901225-00 2013/5/15�z�M���ً̋}�Ή�</br>
    /// <br>             Redmine#34756�Ή��F�I����������</br>
    /// <br>Update Note: 2013/06/07 wangl2</br>
    /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
    /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
    /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
    /// <br>Update Note: 2015/03/06 caohh</br>
    /// <br>�Ǘ��ԍ�   �F11070149-00 Redmine#44951 �I�����������̕s��ɂ��đΉ�</br>
    /// <br>Update Note: 2020/06/18 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Update Note :2020/07/23 杍^</br>
    /// <br>�Ǘ��ԍ�    :11675035-00</br>
    /// <br>             PMKOBETSU-3551 �I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
    /// <br>Update Note: 2021/03/16 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11770024-00</br>
    /// <br>             PMKOBETSU-3551 �I�����������̑Ή�</br> 
    /// <br>           : �@GoodsUnitData�̊�ƃR�[�h����̌�</br>
    /// <br>           : �A�|���D��Ǘ��}�X�^�̋��_�w�肪�y�S�Ћ��ʁz�̏ꍇ�A���_���̊|���f�[�^���g�p����Ă��܂���</br>
    /// <br>           : �B���_���̒P�i�ݒ�̊|���f�[�^������A�|���D��Ǘ��}�X�^��[6A]�����݂��Ȃ��ꍇ�A���_���̒P�i�ݒ�̊|���f�[�^���g�p����Ă��܂���</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class InventoryExtDB : RemoteWithAppLockDB, IInventoryExtDB
    {
        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>DIC�L�[�t�H�[�}�b�g</summary>
        private const string ctDicKeyFmt = "{0}-{1:D4}-{2}";
        /// <summary>�S��</summary>
        private const string ctALLSection = "00";
        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

        /// <summary>
        /// �I����������DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>														   
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public InventoryExtDB()
            :
        base("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.StockInventoryExtWork", "INVENTORYDATARF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search�@���I���f�[�^�i�������������j
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̒I����������LIST(������������)��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̒I����������LIST(������������)��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return SearchProc(out retobj, paraobj, readMode, logicalMode);
        }

        #region SearchProc
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̒I����������LIST(������������)��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̒I����������LIST(������������)��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update     : 2007.09.14 Yokokawa  ����.NS�p�ɉ���</br>
        /// <br>Update Note: 2011/01/11 yangmj �I����Q�Ή�</br>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            InventoryExtCndtnWork inventoryExtCndtnWork = new InventoryExtCndtnWork();
            retobj = null;

            ArrayList al = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand = null;

                string sqlDm = "";
                //sqlDm += "SELECT *  FROM INVENTDATAPRERF IDP "; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlDm += "SELECT * FROM INVENTDATAPRERF IDP WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109

                sqlCommand = new SqlCommand(sqlDm, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 0);

                //-----ADD 2011/01/11----->>>>>
                //���������ˏ������ԏ�
                sqlCommand.CommandText += "ORDER BY INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF";
                //-----ADD 2011/01/11-----<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventDataPreWork wkInventDataPreWork = new InventDataPreWork();

                    #region �l�Z�b�g
                    wkInventDataPreWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkInventDataPreWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkInventDataPreWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkInventDataPreWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkInventDataPreWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkInventDataPreWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkInventDataPreWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkInventDataPreWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkInventDataPreWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkInventDataPreWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
                    wkInventDataPreWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
                    wkInventDataPreWork.InventoryProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPROCDIVRF"));
                    wkInventDataPreWork.WarehouseCodeSt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODESTRF"));
                    wkInventDataPreWork.WarehouseCodeEd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODEEDRF"));
                    wkInventDataPreWork.ShelfNoSt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNOSTRF"));
                    wkInventDataPreWork.ShelfNoEd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNOEDRF"));
                    wkInventDataPreWork.StartSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTSUPPLIERCODERF"));
                    wkInventDataPreWork.EndSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENDSUPPLIERCODERF"));
                    wkInventDataPreWork.BLGoodsCodeSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODESTRF"));
                    wkInventDataPreWork.BLGoodsCodeEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODEEDRF"));
                    wkInventDataPreWork.GoodsMakerCdSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDSTRF"));
                    wkInventDataPreWork.GoodsMakerCdEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDEDRF"));
                    wkInventDataPreWork.BLGroupCodeSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODESTRF"));
                    wkInventDataPreWork.BLGroupCodeEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODEEDRF"));
                    wkInventDataPreWork.TrtStkExtraDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRTSTKEXTRADIVRF"));
                    wkInventDataPreWork.EntCmpStkExtraDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTCMPSTKEXTRADIVRF"));
                    wkInventDataPreWork.LtInventoryUpdateSt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATESTRF"));
                    wkInventDataPreWork.LtInventoryUpdateEd = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATEEDRF"));
                    wkInventDataPreWork.SelWarehouseCode1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE1RF"));
                    wkInventDataPreWork.SelWarehouseCode2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE2RF"));
                    wkInventDataPreWork.SelWarehouseCode3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE3RF"));
                    wkInventDataPreWork.SelWarehouseCode4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE4RF"));
                    wkInventDataPreWork.SelWarehouseCode5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE5RF"));
                    wkInventDataPreWork.SelWarehouseCode6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE6RF"));
                    wkInventDataPreWork.SelWarehouseCode7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE7RF"));
                    wkInventDataPreWork.SelWarehouseCode8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE8RF"));
                    wkInventDataPreWork.SelWarehouseCode9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE9RF"));
                    wkInventDataPreWork.SelWarehouseCode10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE10RF"));
                    wkInventDataPreWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDATERF"));
                    wkInventDataPreWork.MngSectionCodeSt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODESTRF"));// ADD 2011/01/30
                    wkInventDataPreWork.MngSectionCodeEd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODEEDRF"));// ADD 2011/01/30


                    #region  �ύX�O(MA.NS)
                    /*
                    wkInventDataPreWork.CreateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkInventDataPreWork.UpdateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkInventDataPreWork.EnterpriseCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkInventDataPreWork.FileHeaderGuid      = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkInventDataPreWork.UpdEmployeeCode     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkInventDataPreWork.UpdAssemblyId1      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkInventDataPreWork.UpdAssemblyId2      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkInventDataPreWork.LogicalDeleteCode   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkInventDataPreWork.SectionCode         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkInventDataPreWork.InventoryPreprDay   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
                    wkInventDataPreWork.InventoryPreprTim   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
                    wkInventDataPreWork.InventoryProcDiv    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPROCDIVRF"));
                    wkInventDataPreWork.GeneralGoodsExtDiv  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GENERALGOODSEXTDIVRF"));
                    wkInventDataPreWork.MobileGoodsExtDiv   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOBILEGOODSEXTDIVRF"));
                    wkInventDataPreWork.AcsryGoodsExtDiv    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACSRYGOODSEXTDIVRF"));
                    wkInventDataPreWork.WarehouseCodeSt     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODESTRF"));
                    wkInventDataPreWork.WarehouseCodeEd     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODEEDRF"));
                    wkInventDataPreWork.MakerCodeSt         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODESTRF"));
                    wkInventDataPreWork.MakerCodeEd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODEEDRF"));
                    wkInventDataPreWork.CarrierCdSt         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCDSTRF"));
                    wkInventDataPreWork.CarrierCdEd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCDEDRF"));
                    wkInventDataPreWork.LgGoodsGanreCdSt    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LGGOODSGANRECDSTRF"));
                    wkInventDataPreWork.LgGoodsGanreCdEd    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LGGOODSGANRECDEDRF"));
                    wkInventDataPreWork.MdGoodsGanreCdSt    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MDGOODSGANRECDSTRF"));
                    wkInventDataPreWork.MdGoodsGanreCdEd    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MDGOODSGANRECDEDRF"));
                    wkInventDataPreWork.CellphoneModelCdSt  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELCDSTRF"));
                    wkInventDataPreWork.CellphoneModelCdEd  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELCDEDRF"));
                    wkInventDataPreWork.KtGoodsCdSt         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KTGOODSCDSTRF"));
                    wkInventDataPreWork.KtGoodsCdEd         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KTGOODSCDEDRF"));
                    wkInventDataPreWork.CmpStkExtraDiv      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPSTKEXTRADIVRF"));
                    wkInventDataPreWork.TrtStkExtraDiv      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRTSTKEXTRADIVRF"));
                    wkInventDataPreWork.EntCmpStkExtraDiv   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTCMPSTKEXTRADIVRF"));
                    wkInventDataPreWork.EntTrtStkExtraDiv   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTTRTSTKEXTRADIVRF"));
                    wkInventDataPreWork.LtInventoryUpdateSt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATESTRF"));
                    wkInventDataPreWork.LtInventoryUpdateEd = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATEEDRF"));
                    */
                    #endregion  // �ύX�O(MA.NS)

                    #endregion  // �l�Z�b�g

                    al.Add(wkInventDataPreWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (!myReader.IsClosed) myReader.Close();
            sqlConnection.Close();

            retobj = al;
            return status;

        }
        #endregion  // SearchProc
        #endregion  // Search�@���I���f�[�^�i�������������j

        #region SearchInventoryDate �I���f�[�^��������
        /// <summary>
        /// �݌Ƀ}�X�^���������A�I����������LIST(�I���f�[�^)��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������(�I���f�[�^)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^���������A�I����������LIST(�I���f�[�^)��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int SearchInventoryDate(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return SearchInventoryDateProc(out retobj, paraobj, logicalMode, out statusMSG);
        }

        /// <summary>
        /// �݌Ƀ}�X�^���������A�I����������LIST(�I���f�[�^)��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������(�I���f�[�^)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^���������A�I����������LIST(�I���f�[�^)��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>�Ǘ��ԍ�   �F10901225-00 2013/5/15�z�M���ً̋}�Ή�</br>
        /// <br>             Redmine#34756�Ή��F�I����������</br>
        private int SearchInventoryDateProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;
            InventoryExtCndtnWork inventoryExtCndtnWork = null;
            List<InventoryDataWork> al = null;   //�I���f�[�^
            //ArrayList al = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "�ڑ��ُ�ł��B";
                    return status;
                }

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                #region �r������ (�q�Ƀ��b�N)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status;
                    }
                }
                #endregion

                #region �݌Ƀ}�X�^��������

                Dictionary<int, SupplierWork> supplierDic = null; // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode);  // DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
                status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode, supplierDic); // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������

                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)  //���o�f�[�^���Ȃ��ꍇ
                {
                    statusMSG = "�X�V�Ώۂ�����܂���B";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //���o�f�[�^������ꍇ
                {
                    ArrayList retlist = new ArrayList();
                    for (int i = 0; i < al.Count; i++)
                    {
                        retlist.Add(al[i]);
                    }

                    // ���ʃZ�b�g
                    retobj = retlist;
                }
                #endregion

                #region �r���������(�q�Ƀ��b�N)
                if (status == 0 || status == 9)
                {
                    foreach (ShareCheckInfo info in infoList)
                    {
                        int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                        if (sta != 0) return status = sta;
                    }
                }
                #endregion

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchWriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }

        #endregion

        #region WriteInventoryDate�@�I���f�[�^�쐬����
        /// <summary>
        /// �I���f�[�^List����I���f�[�^�֍X�V�A�o�^���s���܂�
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="paraobj2">�I���f�[�^List</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^List����I���f�[�^�֍X�V�A�o�^���s���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int WriteInventoryDate(out object retobj, object paraobj, object paraobj2, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return WriteInventoryDateProc(out retobj, paraobj, paraobj2, logicalMode, out statusMSG);
        }

        /// <summary>
        /// �I���f�[�^List����I���f�[�^�֍X�V�A�o�^���s���܂�
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="paraobj2">�I���f�[�^List</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^List����I���f�[�^�֍X�V�A�o�^���s���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        private int WriteInventoryDateProc(out object retobj, object paraobj, object paraobj2, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            List<InventoryDataWork> al = null;   //�I���f�[�^
            al = paraobj2 as List<InventoryDataWork>;

            //#Dictionary<Guid, InventoryDataWork> dic = null;  //�I���f�[�^(���������O�f�[�^�i�[Dictionary)
            Dictionary<String, InventoryDataWork> dic = null;  //�I���f�[�^(���������O�f�[�^�i�[Dictionary)
            InventDataPreWork inventDataPreWork = null;
            InventoryExtCndtnWork inventoryExtCndtnWork = null;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "�ڑ��ُ�ł��B";
                    return status;
                }

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                #region �r������(�q�Ƀ��b�N)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status = 851;
                    }
                }
                #endregion

                //�݌Ƀ}�X�^��������
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);

                if ((al == null) || (al.Count == 0))  //���o�f�[�^���Ȃ��ꍇ
                {
                    statusMSG = "�X�V�Ώۂ�����܂���B";
                }
                else  //�f�[�^������ꍇ
                {
                    //�����ŁA
                    //al�ɓo�^����Ă���e�I���f�[�^���ƂɎw�肳�ꂽ�I�����ɂ�����݌ɐ������߂�B
                    //������e�I���f�[�^�̍݌ɑ����Ƃ��A�}�V���݌Ɋz���Čv�Z����B
                    CalcStockTotal(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode);

                    int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    // ADD 2009/05/22 >>>
                    // �I���f�[�^�ɓ���q�ɁE���[�J�[�E�i�Ԃ����݂���ꍇ�A�I�������敪�ɂ�菈�������򂵂܂��B
                    // �Q�ƍ���: �I�������敪(InventoryProcDiv)  
                    //           0:���������Ώۂɂ��Ȃ� ��(�ǉ��E�X�V���Ȃ�)�c��
                    //           1:���������Ώۂɂ���   ��(�폜�E�ǉ�)
                    //  ADD 2009/05/22 <<<


                    #region �I���f�[�^��������
                    if (inventoryExtCndtnWork.InventoryProcDiv == 0)
                    {
                        st = SeachInventoryData(out dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "�I���f�[�^�̌����Ɏ��s���܂����B";
                            status = st;
                        }
                    }
                    #endregion

                    #region �I���f�[�^�폜����
                    //�I���f�[�^�폜����
                    if (inventoryExtCndtnWork.InventoryProcDiv == 1)
                    {
                        st = DeleteInventoryData(inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, logicalMode, al, dic);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "�I���f�[�^�̍폜�Ɏ��s���܂����B";
                            status = st;
                        }
                    }
                    #endregion

                    #region �I���f�[�^�o�^����
                    if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (st == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        st = WriteInventoryData(al, dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "�I���f�[�^�̓o�^�Ɏ��s���܂����B";
                            status = st;
                        }
                        if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            statusMSG += "�X�V�Ώۂ�����܂���B";
                        }
                    }
                    #endregion

                    #region �I���f�[�^�i�������������j�o�^����
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�I���f�[�^�i�������������j�o�^����
                        #region �l�Z�b�g
                        inventDataPreWork = new InventDataPreWork();
                        inventDataPreWork.EnterpriseCode = inventoryExtCndtnWork.EnterpriseCode;
                        inventDataPreWork.SectionCode = inventoryExtCndtnWork.SectionCode;
                        inventDataPreWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim = SysTime;
                        inventDataPreWork.InventoryProcDiv = inventoryExtCndtnWork.InventoryProcDiv;
                        inventDataPreWork.WarehouseCodeSt = inventoryExtCndtnWork.StWarehouseCd;
                        inventDataPreWork.WarehouseCodeEd = inventoryExtCndtnWork.EdWarehouseCd;
                        inventDataPreWork.ShelfNoSt = inventoryExtCndtnWork.StWarehouseShelfNo;
                        inventDataPreWork.ShelfNoEd = inventoryExtCndtnWork.EdWarehouseShelfNo;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGoodsCodeSt = inventoryExtCndtnWork.StBLGoodsCd;
                        inventDataPreWork.BLGoodsCodeEd = inventoryExtCndtnWork.EdBLGoodsCd;
                        inventDataPreWork.GoodsMakerCdSt = inventoryExtCndtnWork.StMakerCd;
                        inventDataPreWork.GoodsMakerCdEd = inventoryExtCndtnWork.EdMakerCd;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGroupCodeSt = inventoryExtCndtnWork.StBLGroupCode;
                        inventDataPreWork.BLGroupCodeEd = inventoryExtCndtnWork.EdBLGroupCode;
                        inventDataPreWork.SelWarehouseCode1 = inventoryExtCndtnWork.WarehouseCd01;
                        inventDataPreWork.SelWarehouseCode2 = inventoryExtCndtnWork.WarehouseCd02;
                        inventDataPreWork.SelWarehouseCode3 = inventoryExtCndtnWork.WarehouseCd03;
                        inventDataPreWork.SelWarehouseCode4 = inventoryExtCndtnWork.WarehouseCd04;
                        inventDataPreWork.SelWarehouseCode5 = inventoryExtCndtnWork.WarehouseCd05;
                        inventDataPreWork.SelWarehouseCode6 = inventoryExtCndtnWork.WarehouseCd06;
                        inventDataPreWork.SelWarehouseCode7 = inventoryExtCndtnWork.WarehouseCd07;
                        inventDataPreWork.SelWarehouseCode8 = inventoryExtCndtnWork.WarehouseCd08;
                        inventDataPreWork.SelWarehouseCode9 = inventoryExtCndtnWork.WarehouseCd09;
                        inventDataPreWork.SelWarehouseCode10 = inventoryExtCndtnWork.WarehouseCd10;
                        inventDataPreWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;
                        #endregion    // �l�Z�b�g
                        st = WriteInventDataPre(ref inventDataPreWork, ref sqlConnection, ref sqlTrans);

                        if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusMSG += "�I���f�[�^�i�������������j�̓o�^�Ɏ��s���܂����B";
                        }
                        else
                        {
                            ArrayList retArray = new ArrayList();
                            retArray.Add(inventDataPreWork);
                            retobj = retArray;
                        }
                    }
                    #endregion

                    status = st;
                }

                #region �r���������(�q�Ƀ��b�N)
                if (status == 0 || status == 9)
                {
                    foreach (ShareCheckInfo info in infoList)
                    {
                        int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                        if (sta != 0) return status = sta;
                    }
                }
                #endregion

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchWriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;

        }

        #endregion

        #region SearchWrite
        /// <summary>
        /// �I���������������������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���������������������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int SearchWrite(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return SearchWriteProc(out retobj, paraobj, readMode, logicalMode, out statusMSG);
        }

        #region SearchWriteProc
        /// <summary>
        /// �I���������������������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�
        /// </summary>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���������������������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note : 2011/01/11 yangmj �I����Q�Ή�</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>�Ǘ��ԍ�   �F10901225-00 2013/5/15�z�M���ً̋}�Ή�</br>
        /// <br>             Redmine#34756�Ή��F�I����������</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
        /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
        private int SearchWriteProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            List<InventoryDataWork> al = null;   //�I���f�[�^
            //#Dictionary<Guid, InventoryDataWork> dic = null;  //�I���f�[�^(���������O�f�[�^�i�[Dictionary)
            Dictionary<String, InventoryDataWork> dic = null;  //�I���f�[�^(���������O�f�[�^�i�[Dictionary)
            InventDataPreWork inventDataPreWork = null;
            InventoryExtCndtnWork inventoryExtCndtnWork = null;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "�ڑ��ُ�ł��B";
                    return status;
                }

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>          
                #region �V�X�e�����b�N(�q��)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status;
                    }
                }
                #endregion
                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� ----->>>>>
                Dictionary<int, SupplierWork> supplierDic = new Dictionary<int, SupplierWork>(); ;    // �d����}�X�^���Dictionary
                SupplierDB _supplierDB = new SupplierDB();  // �d����}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
                ArrayList supplierList = new ArrayList();
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = inventoryExtCndtnWork.EnterpriseCode;  // ��ƃR�[�h
                // �d����}�X�^�����擾����
                //status = _supplierDB.Search(out supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTrans);�@// �d����}�X�^���̃��X�g���擾���܂� DEL 2013/06/07 wangl2 for Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                int status0 = _supplierDB.Search(out supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTrans);�@// �d����}�X�^���̃��X�g���擾���܂�
                if (status0 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status0 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                    && status0 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = status0;
                    return status0;
                }

                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                // �d����}�X�^���Dictionary���쐬
                foreach (SupplierWork supplierwork in supplierList)
                {
                    if (!supplierDic.ContainsKey(supplierwork.SupplierCd))
                    {
                        supplierDic.Add(supplierwork.SupplierCd, supplierwork);
                    }
                }
                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� -----<<<<<

                //�݌Ƀ}�X�^��������
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);// DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� 
                status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode, supplierDic);// ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� 
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                //-----ADD 2011/01/11----->>>>>

                #region �ݏo���f�[�^���o
                //int status1 = SearchLendExtra(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);// DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� 
                int status1 = SearchLendExtra(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode, supplierDic);// ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� 
                //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                //if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = status1;
                //}
                //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = status1;
                    return status1;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                #endregion
            

                #region �����v�㕪�f�[�^���o

                //int status2 = SearchDelayPayment(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);// DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� 
                int status2 = SearchDelayPayment(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode, supplierDic);// ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� 
                //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                //if (status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = status2;
                //}
                //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status2 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = status2;
                    return status2;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                #endregion

                //-----ADD 2011/01/11-----<<<<<

                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)  //���o�f�[�^���Ȃ��ꍇ
                {
                    statusMSG = "�X�V�Ώۂ�����܂���B";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //���o�f�[�^������ꍇ
                {
                    //�����ŁA
                    //al�ɓo�^����Ă���e�I���f�[�^���ƂɎw�肳�ꂽ�I�����ɂ�����݌ɐ������߂�B
                    //������e�I���f�[�^�̍݌ɑ����Ƃ��A�}�V���݌Ɋz���Čv�Z����B
                    CalcStockTotal(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);

                    int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    // ADD 2009/05/22 >>>
                    // �I�������敪�ɂ�菈�������򂵂܂��B
                    // --�� �I���f�[�^�ɓ���q�ɁE���[�J�[�E�i�Ԃ����݂���ꍇ�̏���
                    // �Q�ƍ���: �I�������敪(InventoryProcDiv)  
                    //           0:���������Ώۂɂ��Ȃ� ��(�ǉ��E�X�V���Ȃ�)�c��
                    //           1:���������Ώۂɂ���   ��(�폜�E�ǉ�)
                    //  ADD 2009/05/22 <<<

                    #region �I���f�[�^��������
                    //�I���f�[�^�폜����
                    //$-- 2007.09.27 �C��
                    //$if ((inventoryExtCndtnWork.InventoryProcDiv == 1) || (inventoryExtCndtnWork.InventoryProcDiv == 0))
                    //${

                    // -------UPD 2009/11/30 ---------->>>>>
                    //if (inventoryExtCndtnWork.InventoryProcDiv == 0) // ADD 2009/05/22
                    //{
                    //    st = SeachInventoryData(out dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    //    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    //    {
                    //        statusMSG += "�I���f�[�^�̌����Ɏ��s���܂����B";
                    //        status = st;
                    //    }
                    //}

                    st = SeachInventoryData(out dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        statusMSG += "�I���f�[�^�̌����Ɏ��s���܂����B";
                        status = st;
                    }
                    // -------UPD 2009/11/30-------<<<<<
                    //$}
                    #endregion

                    #region �I���f�[�^�폜����
                    //�I���f�[�^�폜����
                    if (inventoryExtCndtnWork.InventoryProcDiv == 1)�@// ADD 2009/05/22 
                    {
                        st = DeleteInventoryData(inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, logicalMode, al, dic);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "�I���f�[�^�̍폜�Ɏ��s���܂����B";
                            status = st;
                        }
                    }
                    #endregion

                    #region �I���f�[�^�o�^����
                    if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (st == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        // -------ADD 2009/11/30 ---------->>>>>
                        if (inventoryExtCndtnWork.InventoryProcDiv == 1)
                        {
                            dic = new Dictionary<string, InventoryDataWork>();
                        }
                        // -------ADD 2009/11/30 ----------<<<<<
                        st = WriteInventoryData(al, dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "�I���f�[�^�̓o�^�Ɏ��s���܂����B";
                            status = st;
                        }
                        if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            statusMSG += "�X�V�Ώۂ�����܂���B";
                        }
                    }
                    #endregion

                    #region �I���f�[�^�i�������������j�o�^����
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�I���f�[�^�i�������������j�o�^����
                        #region �l�Z�b�g
                        inventDataPreWork = new InventDataPreWork();

                        inventDataPreWork.EnterpriseCode = inventoryExtCndtnWork.EnterpriseCode;

                        inventDataPreWork.SectionCode = inventoryExtCndtnWork.SectionCode;
                        inventDataPreWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim = SysTime;
                        inventDataPreWork.InventoryProcDiv = inventoryExtCndtnWork.InventoryProcDiv;
                        inventDataPreWork.WarehouseCodeSt = inventoryExtCndtnWork.StWarehouseCd;
                        inventDataPreWork.WarehouseCodeEd = inventoryExtCndtnWork.EdWarehouseCd;
                        inventDataPreWork.ShelfNoSt = inventoryExtCndtnWork.StWarehouseShelfNo;
                        inventDataPreWork.ShelfNoEd = inventoryExtCndtnWork.EdWarehouseShelfNo;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGoodsCodeSt = inventoryExtCndtnWork.StBLGoodsCd;
                        inventDataPreWork.BLGoodsCodeEd = inventoryExtCndtnWork.EdBLGoodsCd;
                        inventDataPreWork.GoodsMakerCdSt = inventoryExtCndtnWork.StMakerCd;
                        inventDataPreWork.GoodsMakerCdEd = inventoryExtCndtnWork.EdMakerCd;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGroupCodeSt = inventoryExtCndtnWork.StBLGroupCode;
                        inventDataPreWork.BLGroupCodeEd = inventoryExtCndtnWork.EdBLGroupCode;
                        // ----ADD 2011/01/30----->>>>>
                        if (string.IsNullOrEmpty(inventoryExtCndtnWork.SectionCodeSt))
                        {
                            inventDataPreWork.MngSectionCodeSt = "0";
                        }
                        else
                        {
                            inventDataPreWork.MngSectionCodeSt = inventoryExtCndtnWork.SectionCodeSt;
                        }
                        if (string.IsNullOrEmpty(inventoryExtCndtnWork.SectionCodeEd))
                        {
                            inventDataPreWork.MngSectionCodeEd = "99";
                        }
                        else
                        {
                            inventDataPreWork.MngSectionCodeEd = inventoryExtCndtnWork.SectionCodeEd;
                        }
                        // ----ADD 2011/01/30-----<<<<<
                        //inventDataPreWork.LgGoodsGanreCdSt = inventoryExtCndtnWork.StLgGoodsGanreCd;
                        //inventDataPreWork.LgGoodsGanreCdEd = inventoryExtCndtnWork.EdLgGoodsGanreCd;
                        //inventDataPreWork.MdGoodsGanreCdSt = inventoryExtCndtnWork.StMdGoodsGanreCd;
                        //inventDataPreWork.MdGoodsGanreCdEd = inventoryExtCndtnWork.EdMdGoodsGanreCd;
                        //inventDataPreWork.DtlGoodsGanreCdSt = Convert.ToString(inventoryExtCndtnWork.StBLGroupCode);
                        //inventDataPreWork.DtlGoodsGanreCdEd = Convert.ToString(inventoryExtCndtnWork.EdBLGroupCode);
                        //inventDataPreWork.EnterpriseGanreCdSt = inventoryExtCndtnWork.StEnterpriseGanreCode;
                        //inventDataPreWork.EnterpriseGanreCdEd = inventoryExtCndtnWork.EdEnterpriseGanreCode;

                        //inventDataPreWork.CmpStkExtraDiv = inventoryExtCndtnWork.CmpStkExtraDiv;
                        //inventDataPreWork.TrtStkExtraDiv = inventoryExtCndtnWork.TrtStkExtraDiv;
                        //inventDataPreWork.EntCmpStkExtraDiv = inventoryExtCndtnWork.EntCmpStkExtraDiv;
                        //inventDataPreWork.EntTrtStkExtraDiv = inventoryExtCndtnWork.EntTrtStkExtraDiv;
                        //inventDataPreWork.LtInventoryUpdateSt = inventoryExtCndtnWork.LtInventoryUpdateSt;
                        //inventDataPreWork.LtInventoryUpdateEd = inventoryExtCndtnWork.LtInventoryUpdateEd;
                        inventDataPreWork.SelWarehouseCode1 = inventoryExtCndtnWork.WarehouseCd01;
                        inventDataPreWork.SelWarehouseCode2 = inventoryExtCndtnWork.WarehouseCd02;
                        inventDataPreWork.SelWarehouseCode3 = inventoryExtCndtnWork.WarehouseCd03;
                        inventDataPreWork.SelWarehouseCode4 = inventoryExtCndtnWork.WarehouseCd04;
                        inventDataPreWork.SelWarehouseCode5 = inventoryExtCndtnWork.WarehouseCd05;
                        inventDataPreWork.SelWarehouseCode6 = inventoryExtCndtnWork.WarehouseCd06;
                        inventDataPreWork.SelWarehouseCode7 = inventoryExtCndtnWork.WarehouseCd07;
                        inventDataPreWork.SelWarehouseCode8 = inventoryExtCndtnWork.WarehouseCd08;
                        inventDataPreWork.SelWarehouseCode9 = inventoryExtCndtnWork.WarehouseCd09;
                        inventDataPreWork.SelWarehouseCode10 = inventoryExtCndtnWork.WarehouseCd10;
                        inventDataPreWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;

                        #region  �ύX�O(MA.NS)
                        /*
                        inventDataPreWork.EnterpriseCode      = inventoryExtCndtnWork.EnterpriseCode;
                        inventDataPreWork.SectionCode         = inventoryExtCndtnWork.SectionCode;
                        inventDataPreWork.InventoryPreprDay   = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim   = SysTime;
                        inventDataPreWork.InventoryProcDiv    = inventoryExtCndtnWork.InventoryProcDiv;
                        inventDataPreWork.GeneralGoodsExtDiv  = inventoryExtCndtnWork.GeneralGoodsExtDiv;
                        inventDataPreWork.MobileGoodsExtDiv   = inventoryExtCndtnWork.MobileGoodsExtDiv;
                        inventDataPreWork.AcsryGoodsExtDiv    = inventoryExtCndtnWork.AcsryGoodsExtDiv;
                        inventDataPreWork.WarehouseCodeSt     = inventoryExtCndtnWork.StWarehouseCd;
                        inventDataPreWork.WarehouseCodeEd     = inventoryExtCndtnWork.EdWarehouseCd;
                        inventDataPreWork.MakerCodeSt         = inventoryExtCndtnWork.StMakerCd;
                        inventDataPreWork.MakerCodeEd         = inventoryExtCndtnWork.EdMakerCd;
                        inventDataPreWork.CarrierCdSt         = inventoryExtCndtnWork.StCarrierCd;
                        inventDataPreWork.CarrierCdEd         = inventoryExtCndtnWork.EdCarrierCd;
                        inventDataPreWork.LgGoodsGanreCdSt    = inventoryExtCndtnWork.StLgGoodsGanreCd;
                        inventDataPreWork.LgGoodsGanreCdEd    = inventoryExtCndtnWork.EdLgGoodsGanreCd;
                        inventDataPreWork.MdGoodsGanreCdSt    = inventoryExtCndtnWork.StMdGoodsGanreCd;
                        inventDataPreWork.MdGoodsGanreCdEd    = inventoryExtCndtnWork.EdMdGoodsGanreCd;
                        inventDataPreWork.CellphoneModelCdSt  = inventoryExtCndtnWork.StCellphoneModelCd;
                        inventDataPreWork.CellphoneModelCdEd  = inventoryExtCndtnWork.EdCellphoneModelCd;
                        inventDataPreWork.KtGoodsCdSt         = inventoryExtCndtnWork.StGoodsCd;
                        inventDataPreWork.KtGoodsCdEd         = inventoryExtCndtnWork.EdGoodsCd;
                        inventDataPreWork.CmpStkExtraDiv      = inventoryExtCndtnWork.CmpStkExtraDiv;
                        inventDataPreWork.TrtStkExtraDiv      = inventoryExtCndtnWork.TrtStkExtraDiv;
                        inventDataPreWork.EntCmpStkExtraDiv   = inventoryExtCndtnWork.EntCmpStkExtraDiv;
                        inventDataPreWork.EntTrtStkExtraDiv   = inventoryExtCndtnWork.EntTrtStkExtraDiv;
                        inventDataPreWork.LtInventoryUpdateSt = inventoryExtCndtnWork.StLtInventoryUpdate;
                        inventDataPreWork.LtInventoryUpdateEd = inventoryExtCndtnWork.EdLtInventoryUpdate;
                        */
                        #endregion    // �ύX�O(MA.NS)

                        #endregion    // �l�Z�b�g
                        st = WriteInventDataPre(ref inventDataPreWork, ref sqlConnection, ref sqlTrans);

                        if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusMSG += "�I���f�[�^�i�������������j�̓o�^�Ɏ��s���܂����B";
                        }
                        else
                        {
                            ArrayList retArray = new ArrayList();
                            retArray.Add(inventDataPreWork);
                            retobj = retArray;
                        }
                    }
                    #endregion

                    status = st;

                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status == 0 || status == 9)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                            if (sta != 0) return status = sta;
                        }
                    }
                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchWriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }
        //-----ADD 2011/01/11----->>>>>
        /// <summary>
        /// �ݏo���f�[�^���o
        /// </summary>
        /// <param name="inventoryExtCndtnWork">�I�����������I�u�W�F�N�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="supplierDic">�d����}�X�^���Dictionary</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ݏo���f�[�^���o</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/01/11</br>
        /// <br>UpdateNote : 2011/02/11 �� ��</br>
        /// <br>             Redmine#18876�̑Ή�</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>�Ǘ��ԍ�   �F10901225-00 2013/5/15�z�M���ً̋}�Ή�</br>
        /// <br>             Redmine#34756�Ή��F�I����������</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
        /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
        /// <br>Update Note :2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�    :11675035-00</br>
        /// <br>             PMKOBETSU-3551 �I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        /// <br>Update Note: 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 �I�����������̑Ή�</br>   
        //private int SearchLendExtra(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)  // DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
        private int SearchLendExtra(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode, Dictionary<int, SupplierWork> supplierDic) // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            ArrayList wkList = new ArrayList();
            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �����Z�o�p
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // �����v�Z�p�����[�^�I�u�W�F�N�g���X�g
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // ���i�A���f�[�^�I�u�W�F�N�g���X�g
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // �����v�Z���ʃ��X�g 
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // �P�i�|��Dic// ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� 

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            if (al == null)
            {
                al = new List<InventoryDataWork>();
            }

            try
            {
                string SelectDm = "";

                ArrayList resultList = new ArrayList();// ADD 2009/12/25

                // �Ώۃe�[�u�� ����f�[�^�E���㖾�׃f�[�^
                // SalesSlipRF�ESalesDetailRF 

                #region SELECT���쐬
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += " MAIN.ENTERPRISECODERF MAIN_ENTERPRISECODERF" + Environment.NewLine;   // ��ƃR�[�h
                SelectDm += ", MAIN.SECTIONCODERF MAIN_SECTIONCODERF" + Environment.NewLine;        // ���_�R�[�h
                SelectDm += ", MAIN.WAREHOUSECODERF MAIN_WAREHOUSECODERF" + Environment.NewLine;    // �q�ɃR�[�h
                SelectDm += ", MAIN.GOODSMAKERCDRF MAIN_GOODSMAKERCDRF" + Environment.NewLine;      // ���i���[�J�[�R�[�h
                SelectDm += ", MAIN.GOODSNORF MAIN_GOODSNORF" + Environment.NewLine;                // ���i�R�[�h
                SelectDm += ", MAIN.BLGROUPCODERF MAIN_BLGROUPCODERF" + Environment.NewLine;        // BL�O���[�v�R�[�h
                SelectDm += ", MAIN.BLGOODSCODERF MAIN_BLGOODSCODERF" + Environment.NewLine;        // BL�R�[�h
                SelectDm += ", MAIN.SUPPLIERCDRF MAIN_SUPPLIERCDRF" + Environment.NewLine;          // �d����R�[�h
                SelectDm += ", ACPTANODRREMAINCNTRF" + Environment.NewLine;                         // �����c��
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���
                SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF" + Environment.NewLine;              // ���[�J�[�}�X�^�E���[�J�[����
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;        // �O���[�v�R�[�h�}�X�^�E�O���[�v�R�[�h����
                SelectDm += " ,BLGR.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;  // ���i�啪�ރR�[�h
                SelectDm += " ,BLGR.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;  // ���i�����ރR�[�h
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;// ���Е��ރR�[�h
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;// �w��
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;// JAN�R�[�h
                SelectDm += " ,GOODS.GOODSNAMERF AS GOODSNAMERF" + Environment.NewLine;// JAN�R�[�h
                SelectDm += ", BLCD.GOODSRATEGRPCODERF BLCD_GOODSRATEGRPCODERF" + Environment.NewLine;// BL�R�[�h�}�X�^�E���i�|���O���[�v�R�[�h // ADD caohh 2015/03/06 for redmine#44951
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;// ���i�}�X�^�E���i����
                SelectDm += ", SEC.SECTWAREHOUSECD1RF SEC_SECTWAREHOUSECD1RF" + Environment.NewLine;// ���_���ݒ�}�X�^�E�D��q�ɂP
                SelectDm += ", WH1.WAREHOUSENAMERF WH1_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���(�D��q�ɂP)
                SelectDm += ", SEC.SECTWAREHOUSECD2RF SEC_SECTWAREHOUSECD2RF" + Environment.NewLine;// ���_���ݒ�}�X�^�E�D��q�ɂQ
                SelectDm += ", WH2.WAREHOUSENAMERF WH2_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���(�D��q�ɂQ)
                SelectDm += ", SEC.SECTWAREHOUSECD3RF SEC_SECTWAREHOUSECD3RF" + Environment.NewLine;// ���_���ݒ�}�X�^�E�D��q�ɂR
                SelectDm += ", WH3.WAREHOUSENAMERF WH3_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���(�D��q�ɂR)
                SelectDm += ", MAIN.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;           //�����P��
                SelectDm += ", MAIN.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", MAIN.GOODS_GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                SelectDm += " , GOODSPRICE.PRICESTARTDATERF AS GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; ;// ���i�J�n��
                SelectDm += " , GOODSPRICE.LISTPRICERF AS GOODSPRICE_LISTPRICERF" + Environment.NewLine; ;// �艿�i�����j

                SelectDm += " , STOCK.STOCKDIVRF AS STOCK_STOCKDIVRF" + Environment.NewLine; ;// �݌ɋ敪
                SelectDm += " , STOCK.LASTSTOCKDATERF AS STOCK_LASTSTOCKDATERF" + Environment.NewLine; ;// �ŏI�d���N����

                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                SelectDm += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                //-----ADD 2011/01/11-----<<<<<

                SelectDm += "FROM" + Environment.NewLine;
                SelectDm += "(" + Environment.NewLine;
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += "SLS.ENTERPRISECODERF ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += ", SLS.RESULTSADDUPSECCDRF SECTIONCODERF" + Environment.NewLine;
                SelectDm += ", SLD.WAREHOUSECODERF WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSMAKERCDRF GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNORF GOODSNORF" + Environment.NewLine;
                SelectDm += ", SLD.BLGROUPCODERF BLGROUPCODERF" + Environment.NewLine;
                SelectDm += ", SLD.BLGOODSCODERF BLGOODSCODERF" + Environment.NewLine;
                SelectDm += ", SLD.SUPPLIERCDRF SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += ", SUM(SLD.ACPTANODRREMAINCNTRF) ACPTANODRREMAINCNTRF" + Environment.NewLine;
                // --- ADD 2009/11/30 ---------->>>>>
                SelectDm += ", SLD.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                SelectDm += ", SLD.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<

                //SelectDm += " FROM SALESSLIPRF AS SLS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM SALESSLIPRF AS SLS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN " + Environment.NewLine;
                //SelectDm += " SALESDETAILRF AS SLD" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " SALESDETAILRF AS SLD WITH (READUNCOMMITTED)" + Environment.NewLine; // DD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON" + Environment.NewLine;
                SelectDm += " SLS.ENTERPRISECODERF = SLD.ENTERPRISECODERF AND" + Environment.NewLine;
                SelectDm += " SLS.ACPTANODRSTATUSRF = SLD.ACPTANODRSTATUSRF AND" + Environment.NewLine;
                SelectDm += " SLS.SALESSLIPNUMRF = SLD.SALESSLIPNUMRF" + Environment.NewLine;
                #endregion

                #region WHERE���̍쐬
                SelectDm += " WHERE" + Environment.NewLine;

                // ����f�[�^�F�u�󒍽ð��=40�F�o�ׁv�@AND�@���㖾�׃f�[�^�F�u�i�Ԃ��Z�b�g����Ă���v���R�[�h
                SelectDm += " SLS.ACPTANODRSTATUSRF = 40 AND " + Environment.NewLine;
                SelectDm += " SLD.GOODSNORF  != ''" + Environment.NewLine;

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //��ƃR�[�h�ݒ�
                sqlCommand.CommandText += " AND SLS.ENTERPRISECODERF=@ENTERPRISECODE";
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                // �Ǘ����_
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }

                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF<=@SECTIONCODEED" + Environment.NewLine;
                    SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                    paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }

                //�擪�`�I�����܂ł̃��R�[�h
                if (inventoryExtCndtnWork.InventoryDate != DateTime.MinValue)
                {
                    int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                    sqlCommand.CommandText += " AND SLS.SHIPMENTDAYRF <= " + InventoryDate.ToString() + Environment.NewLine;
                }

                //if (inventoryExtCndtnWork.WarehouseDiv == 0) // �q�Ɏw��敪 0:�͈�,1:�P��
                //{

                //    //�q�ɃR�[�h�ݒ�
                //    if (inventoryExtCndtnWork.StWarehouseCd != "")
                //    {
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                //        SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                //    }
                //    if (inventoryExtCndtnWork.EdWarehouseCd!= "")
                //    {
                //        //sqlCommand.CommandText += " AND (SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE OR SLD.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine; // 2008.10.08 DEL 
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine;                                                 // 2008.10.08 ADD
                //        SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd + "%");
                //    }
                //}
                //else
                //{
                //    #region �q�ɂP�`10
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " AND ( ";
                //    }

                //    //�q�ɃR�[�h01�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //    {
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD01";
                //        SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //        paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd01);
                //    }

                //    //�q�ɃR�[�h02�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd02 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD02";
                //        SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //        paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd02);
                //    }

                //    //�q�ɃR�[�h03�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd03 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD03";
                //        SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //        paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd03);
                //    }

                //    //�q�ɃR�[�h04�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd04 != "")
                //    {

                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD04";
                //        SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //        paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd04);
                //    }

                //    //�q�ɃR�[�h05�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd05 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD05";
                //        SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //        paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd05);
                //    }

                //    //�q�ɃR�[�h06�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd06 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD06";
                //        SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //        paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd06);
                //    }

                //    //�q�ɃR�[�h07�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd07 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD07";
                //        SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //        paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd07);
                //    }

                //    //�q�ɃR�[�h08�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd08 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD08";
                //        SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //        paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd08);
                //    }

                //    //�q�ɃR�[�h09�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd09 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD09";
                //        SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //        paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd09);
                //    }

                //    //�q�ɃR�[�h10�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd09 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD10";
                //        SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //        paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd10);
                //    }
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " ) ";
                //    }
                //    #endregion
                //}

                //�I�Ԑݒ�
                if (inventoryExtCndtnWork.StWarehouseShelfNo != "")
                {
                    sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);
                }
                if (inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                {
                    //sqlCommand.CommandText += " AND (SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)" + Environment.NewLine; // 2008.10.08 DEL
                    //sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO " + Environment.NewLine;   // 2008.10.08 ADD                  //DEL yangyi 2013/05/06 Redmine#35493
                    sqlCommand.CommandText += " AND ( SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF IS NULL )" + Environment.NewLine;   //ADD yangyi 2013/05/06 Redmine#35493 
                    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo + "%"); // 2008.10.08 DEL
                    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);        // 2008.10.08 ADD 
                }

                //�d����R�[�h�ݒ�
                if (inventoryExtCndtnWork.StCustomerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);
                }
                if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                }

                //�a�k���i�R�[�h�ݒ�
                if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                }
                if (inventoryExtCndtnWork.EdBLGoodsCd != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                }

                // �O���[�v�R�[�h�ݒ�
                if (inventoryExtCndtnWork.StBLGroupCode != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                    paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                }
                if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                    paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                }
                //���[�J�[�R�[�h�ݒ�
                if (inventoryExtCndtnWork.StMakerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF>=@STMAKERCODE" + Environment.NewLine;
                    SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                    paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                }
                if (inventoryExtCndtnWork.EdMakerCd != 9999)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF<=@EDMAKERCODE" + Environment.NewLine;
                    SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                    paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                }

                // --- ADD 2009/11/30 ---------->>>>>
                //�󒍎c��(AcptAnOdrRemainCntRF��0�j�͈���ΏۊO
                sqlCommand.CommandText += " AND SLD.ACPTANODRREMAINCNTRF != 0 " + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<
                #endregion

                #region GROUP���̍쐬
                sqlCommand.CommandText += "GROUP BY " + Environment.NewLine;
                sqlCommand.CommandText += "SLS.ENTERPRISECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.WAREHOUSECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.SUPPLIERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGOODSCODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSMAKERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGROUPCODERF " + Environment.NewLine;


                // --- ADD 2009/11/30 ---------->>>>>
                sqlCommand.CommandText += ", SLD.SALESUNITCOSTRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.LISTPRICETAXEXCFLRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNAMERF " + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<
                sqlCommand.CommandText += ")AS MAIN " + Environment.NewLine;
                #endregion

                #region LEFT JOIN���̍쐬
                // ���_���ݒ�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " SEC.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " SEC.SECTIONCODERF=MAIN.SECTIONCODERF" + Environment.NewLine;
                // �q�Ƀ}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH.WAREHOUSECODERF=MAIN.WAREHOUSECODERF" + Environment.NewLine;
                // �q�Ƀ}�X�^����(�D��q�ɂP)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH1.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH1.WAREHOUSECODERF=SEC.SECTWAREHOUSECD1RF" + Environment.NewLine;
                // �q�Ƀ}�X�^����(�D��q�ɂQ)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH2.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH2.WAREHOUSECODERF=SEC.SECTWAREHOUSECD2RF" + Environment.NewLine;
                // �q�Ƀ}�X�^����(�D��q�ɂR)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH3.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH3.WAREHOUSECODERF=SEC.SECTWAREHOUSECD3RF" + Environment.NewLine;
                // ���[�J�[�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " MAK.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " MAK.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF" + Environment.NewLine;
                // ���i�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " GOODS.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSNORF=MAIN.GOODSNORF" + Environment.NewLine;
                // �O���[�v�R�[�h�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLGR.BLGROUPCODERF=MAIN.BLGROUPCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND BLGR.ENTERPRISECODERF=MAIN.ENTERPRISECODERF";
                // BL�R�[�h�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLCD.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " BLCD.BLGOODSCODERF = MAIN.BLGOODSCODERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                int inventoryDateGoods = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);

                //sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += " AND GOODSPRICE.PRICESTARTDATERF  <=" + inventoryDateGoods.ToString() + Environment.NewLine;

                //sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;

                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                //-----ADD 2011/01/11-----<<<<<

                #endregion

                //���ʎ擾
                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/21
                myReader = sqlCommand.ExecuteReader();
                //----- ADD 2011/01/11----->>>>>
                InventoryDataWork beInventoryDataWork = null;
                //----- ADD 2011/01/11-----<<<<<
                //-----ADD 2011/01/28 ----->>>>>
                string WarehouseCodeStr = string.Empty;
                //-----ADD 2011/01/28 -----<<<<<

                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                //string goodsNo = string.Empty;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                string keyValue = string.Empty;
                //RateWork rateW = null;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                RateWork rateAllSec = null;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                while (myReader.Read())
                {
                    #region ���o���ʃZ�b�g
                    InventoryDataWork inventoryDataWork = new InventoryDataWork();
                    inventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));
                    inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF"));
                    inventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));
                    inventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                    inventoryDataWork.GoodsNoSrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                    inventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                    //---DEL 2011/02/11 ----->>>
                    //if (string.IsNullOrEmpty(inventoryDataWork.GoodsName))
                    //{
                    //    inventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    //}
                    //---DEL 2011/02/11 -----<<<
                    inventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));
                    inventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));
                    inventoryDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_SUPPLIERCDRF"));
                    inventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    inventoryDataWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;
                    inventoryDataWork.WarehouseShelfNo = "���޼";
                    inventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    inventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));

                    inventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // ���i�啪�ރR�[�h  
                    inventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // BL�O���[�v�R�[�h  
                    inventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// ���Е��ރR�[�h
                    inventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));            // �ύX�O�d���P��
                    inventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // �I������������
                    inventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // �I��������������
                    inventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // �ŏI�I���X�V�� 
                    inventoryDataWork.StockMashinePrice = Convert.ToInt64(inventoryDataWork.StockUnitPriceFl * inventoryDataWork.StockTotal);�@       // �}�V���݌Ɋz
                    inventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // ���i�}�X�^�EJAN�R�[�h
                    inventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_STOCKDIVRF"));
                    inventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTSTOCKDATERF")); // �ŏI�d���N����
                    //-----ADD 2011/01/28 ----->>>>>
                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == inventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == inventoryDataWork.SectionCode
                            && WarehouseCodeStr == inventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == inventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == inventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == inventoryDataWork.BLGroupCode
                            && beInventoryDataWork.SupplierCd == inventoryDataWork.SupplierCd
                            && beInventoryDataWork.StockUnitPriceFl == inventoryDataWork.StockUnitPriceFl
                            && beInventoryDataWork.ListPriceFl == inventoryDataWork.ListPriceFl
                            && beInventoryDataWork.GoodsName == inventoryDataWork.GoodsName)
                        {
                            continue;
                        }
                    }
                    WarehouseCodeStr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF")); // ADD 2011/01/28
                    //-----ADD 2011/01/28 -----<<<<<

                    if (string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD1RF"));
                    }
                    if (string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD2RF"));
                    }
                    if (string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD3RF"));
                    }

                    //-----ADD 2011/01/28 ----->>>>>
                    String warehouseCode = inventoryDataWork.WarehouseCode.Trim();
                    // �q�Ɏw��敪 0:�͈�,1:�P��
                    if (inventoryExtCndtnWork.WarehouseDiv == 0)
                    {
                        if ((inventoryExtCndtnWork.StWarehouseCd != "" && inventoryExtCndtnWork.StWarehouseCd.CompareTo(warehouseCode) > 0) ||
                            (inventoryExtCndtnWork.EdWarehouseCd != "" && inventoryExtCndtnWork.EdWarehouseCd.CompareTo(warehouseCode) < 0))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (inventoryExtCndtnWork.WarehouseCd01 != "" ||
                            inventoryExtCndtnWork.WarehouseCd02 != "" ||
                            inventoryExtCndtnWork.WarehouseCd03 != "" ||
                            inventoryExtCndtnWork.WarehouseCd04 != "" ||
                            inventoryExtCndtnWork.WarehouseCd05 != "" ||
                            inventoryExtCndtnWork.WarehouseCd06 != "" ||
                            inventoryExtCndtnWork.WarehouseCd07 != "" ||
                            inventoryExtCndtnWork.WarehouseCd08 != "" ||
                            inventoryExtCndtnWork.WarehouseCd09 != "" ||
                            inventoryExtCndtnWork.WarehouseCd10 != "")
                        {
                            if (!((inventoryExtCndtnWork.WarehouseCd01 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd01) ||
                                (inventoryExtCndtnWork.WarehouseCd02 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd02) ||
                                (inventoryExtCndtnWork.WarehouseCd03 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd03) ||
                                (inventoryExtCndtnWork.WarehouseCd04 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd04) ||
                                (inventoryExtCndtnWork.WarehouseCd05 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd05) ||
                                (inventoryExtCndtnWork.WarehouseCd06 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd06) ||
                                (inventoryExtCndtnWork.WarehouseCd07 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd07) ||
                                (inventoryExtCndtnWork.WarehouseCd08 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd08) ||
                                (inventoryExtCndtnWork.WarehouseCd09 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd09) ||
                                (inventoryExtCndtnWork.WarehouseCd10 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd10)))
                            {
                                continue;
                            }
                        }
                    }
                    //-----ADD 2011/01/28 -----<<<<<

                    if (!string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        //-----DEL 2011/01/28 ----->>>>>
                        //if (beInventoryDataWork != null)
                        //{
                        //    if (beInventoryDataWork.EnterpriseCode == inventoryDataWork.EnterpriseCode
                        //        && beInventoryDataWork.SectionCode == inventoryDataWork.SectionCode
                        //        && beInventoryDataWork.WarehouseCode == inventoryDataWork.WarehouseCode
                        //        && beInventoryDataWork.GoodsMakerCd == inventoryDataWork.GoodsMakerCd
                        //        && beInventoryDataWork.GoodsNo == inventoryDataWork.GoodsNo
                        //        && beInventoryDataWork.BLGroupCode == inventoryDataWork.BLGroupCode
                        //        && beInventoryDataWork.SupplierCd == inventoryDataWork.SupplierCd
                        //        && beInventoryDataWork.StockUnitPriceFl == inventoryDataWork.StockUnitPriceFl
                        //        && beInventoryDataWork.ListPriceFl == inventoryDataWork.ListPriceFl
                        //        && beInventoryDataWork.GoodsName == inventoryDataWork.GoodsName)
                        //    {
                        //        continue;
                        //    }
                        //}
                        //-----DEL 2011/01/28 -----<<<<<
                        //---DEL 2011/02/11 ----->>>
                        //if (inventoryDataWork.ListPriceFl == 0)
                        //{
                        //    inventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));
                        //}
                        //---DEL 2011/02/11 -----<<<
                        beInventoryDataWork = inventoryDataWork;
                        resultList.Add(inventoryDataWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // -- DEL 2012/05/21 ------------------>>>>
                    //���Ɉړ�
                    //}
                    //#endregion
                    // -- DEL 2012/05/21 ------------------<<<<

                        GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                        UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                        GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g

                        #region ���i�d���擾�f�[�^�N���X
                        goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// ��ƃR�[�h
                        goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));      // ���_�R�[�h
                        goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // ���i�ԍ�
                        goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));     // BL�R�[�h
                        goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // ���i�����ރR�[�h
                        GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                        #endregion

                        #region �P���Z�o���W���[���v�Z�p�p�����[�^
                        unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // ���_�R�[�h
                        unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));  // ���[�J�[�R�[�h
                        unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // ���i�ԍ�
                        //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));�@ // ���i�����ރR�[�h // DEL caohh 2015/03/06 for Redmine#44951 
                        unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCD_GOODSRATEGRPCODERF"));�@ // ���i�|���O���[�v�R�[�h // ADD caohh  2015/03/06 for Redmine#44951 
                        unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));// BL�O���[�v�R�[�h
                        unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));  // BL�R�[�h
                        //unitPriceCalcParam.PriceApplyDate = DateTime.Now;// DEL caohh for Redmine#44951 
                        unitPriceCalcParam.PriceApplyDate = inventoryExtCndtnWork.InventoryDate;// ADD caohh  2015/03/06 for Redmine#44951 
                        unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSRATERANKRF"));  // �w��
                        unitPriceCalcParamList.Add(unitPriceCalcParam);
                        #endregion

                        #region ���i�A���f�[�^���X�g
                        goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// ��ƃR�[�h
                        goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // ���i�ԍ�
                        goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        goodsUnitDataList.Add(goodsUnitData);
                        #endregion

                        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                        #region �P�i�|�����X�g

                        //���_���P�i�|��
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // ���_�R�[�h
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // ���i�ԍ�
                        ////keyValue = sectionCode.Trim() + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        //if (!rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        keyValue = string.Format(ctDicKeyFmt, inventoryDataWork.SectionCode.Trim(), inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //�����i�̋��_���P�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        {
                            // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                            //rateW = new RateWork();
                            //rateW.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            //rateW.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            //rateWorkByGoodsNoDic.Add(keyValue, rateW);
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                            // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        }

                        //�S�ВP�i�|��
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim(); 
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo.Trim());
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //�S�ВP�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                    // -- ADD 2012/05/21 ------------------>>>>
                    }
                    #endregion
                    // -- ADD 2012/05/21 ------------------<<<<
                }

                if (!myReader.IsClosed) myReader.Close();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�d������擾���� ���s
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region ���i�d������擾���� ���ʃZ�b�g
                    // ���i�d������擾�����ɂ��擾�����d�����
                    // �P���Z�o�p�����[�^�E�I���f�[�^���[�N�ɃZ�b�g
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                    {
                        // -- UPD 2012/05/21 ------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v���폜�A�z��ԍ��ŕR�t����悤�ύX����B
                        //for (int j = 0; j < unitPriceCalcParamList.Count; j++) // �P���Z�o���W���[���v�Z�p�p�����[�^
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //        }
                        //    }
                        //}

                        //for (int j = 0; j < al.Count; j++) // �I���f�[�^���[�N
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[i].GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[i].GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[i].BLGoodsCode) &&   // BL���i�R�[�h
                            (GoodsSupplierDataWorkList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == ((InventoryDataWork)resultList[i]).BLGoodsCode))     // BL���i�R�[�h
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                unitPriceCalcParamList[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                                //((InventoryDataWork)resultList[i]).SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // DEL 2012/06/14
                                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� ----->>>>>
                                if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParamList[i].SupplierCd))
                                {
                                    unitPriceCalcParamList[i].StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParamList[i].SupplierCd].StockUnPrcFrcProcCd;
                                }
                                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� -----<<<<<
                            }
                        }
                        else
                        {
                            throw new Exception("���i�Ǘ����ƒI���f�[�^�̕R�t�����s���ł��B�i�ݏo���f�[�^���o�j: " + 
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                unitPriceCalcParamList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcParamList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------<<<<
                    }
                    #endregion

                    //�����Z�o���� ���s
                    //unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//DEL 2012/07/10 for Redmine#31103
                    //unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//ADD 2012/07/10 for Redmine#31103 // DEL 2013/06/07 wangl2 For Redmine#35788
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //status = unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                    status = unitPriceCalculation.CalculateUnitCostForInventory2(unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, out unitPriceCalcRetList);
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                    #region �����Z�o���� ���ʃZ�b�g
                    // �����Z�o�����ɂ��擾����������
                    // �݌ɗ����f�[�^�N���X�ɃZ�b�g
                    for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                    {
                        // -- UPD 2012/05/21 ------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v�폜�A�z��ԍ��ŕR�t����悤�ύX����
                        //for (int j = 0; j < resultList.Count; j++) // �I���f�[�^�N���X
                        //{
                        //    if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[j]).GoodsMakerCd) && // ���i���[�J�[
                        //        (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[j]).GoodsNo))     // BL���i�R�[�h
                        //    {
                        //        if (((InventoryDataWork)resultList[j]).StockUnitPriceFl == 0)
                        //        {
                        //            // �d���P��
                        //            ((InventoryDataWork)resultList[j]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //            // �ύX�O�d���P��
                        //            ((InventoryDataWork)resultList[j]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                        //        }
                        //        double adjstCalcCost = 0;
                        //        FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                        //        ((InventoryDataWork)resultList[j]).AdjstCalcCost = adjstCalcCost;
                        //    }
                        //}
                        #endregion
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // ���i���[�J�[
                            (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo))     // BL���i�R�[�h
                        {
                            if (((InventoryDataWork)resultList[i]).StockUnitPriceFl == 0)
                            {
                                // �d���P��
                                ((InventoryDataWork)resultList[i]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                // �ύX�O�d���P��
                                ((InventoryDataWork)resultList[i]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                
                            }
                            // �����p�v�Z����
                            double adjstCalcCost = 0;
                            FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                            ((InventoryDataWork)resultList[i]).AdjstCalcCost = adjstCalcCost;
                        }
                        else
                        {
                            throw new Exception("�����Z�o���ʂƒI���f�[�^�̕R�t�����s���ł��B�i�ݏo���f�[�^���o�j" +
                                                i.ToString() + " : " +
                                                unitPriceCalcRetList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcRetList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------<<<<
                    }
                    #endregion

                    #region �d����R�[�h���o����
                    for (int i = 0; i < resultList.Count; i++) // �I���f�[�^���[�N
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= ((InventoryDataWork)resultList[i]).SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= ((InventoryDataWork)resultList[i]).SupplierCd))
                        {
                            wkList.Add((InventoryDataWork)resultList[i]);
                        }
                    }
                    #endregion

                    resultList = wkList;

                }
                //-----UPD 2011/01/28 ----->>>>>
                //SortData(resultList, ref al);

                //SortDataOrderList(ref al);
                List<InventoryDataWork> alResultList = null;
                SortData(resultList, out alResultList);

                SortDataOrderList(ref al, alResultList);
                //-----UPD 2011/01/28 -----<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �����v�㕪�f�[�^���o
        /// </summary>
        /// <param name="inventoryExtCndtnWork">�I�����������I�u�W�F�N�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="supplierDic">�d����}�X�^���Dictionary</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����v�㕪�f�[�^���o</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/01/11</br>
        /// <br>UpdateNote : 2011/02/11 �� ��</br>
        /// <br>             Redmine#18876�̑Ή�</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>�Ǘ��ԍ�   �F10901225-00 2013/5/15�z�M���ً̋}�Ή�</br>
        /// <br>             Redmine#34756�Ή��F�I����������</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
        /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
        /// <br>Update Note :2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�    :11675035-00</br>
        /// <br>             PMKOBETSU-3551 �I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        /// <br>Update Note: 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 �I�����������̑Ή�</br> 
        //private int SearchDelayPayment(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)  // DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
        private int SearchDelayPayment(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode, Dictionary<int, SupplierWork> supplierDic)  // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            ArrayList wkList = new ArrayList();
            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �����Z�o�p
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // �����v�Z�p�����[�^�I�u�W�F�N�g���X�g
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // ���i�A���f�[�^�I�u�W�F�N�g���X�g
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // �����v�Z���ʃ��X�g 
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // �P�i�|��Dic // ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� 

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            if (al == null)
            {
                al = new List<InventoryDataWork>();
            }

            try
            {
                string SelectDm = "";
                // �Ώۃe�[�u�� ����f�[�^�E���㖾�׃f�[�^
                ArrayList resultList = new ArrayList();

                #region SELECT���쐬
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += " MAIN.ENTERPRISECODERF MAIN_ENTERPRISECODERF" + Environment.NewLine;   // ��ƃR�[�h
                SelectDm += ", MAIN.SECTIONCODERF MAIN_SECTIONCODERF" + Environment.NewLine;        // ���_�R�[�h
                SelectDm += ", MAIN.WAREHOUSECODERF MAIN_WAREHOUSECODERF" + Environment.NewLine;    // �q�ɃR�[�h
                SelectDm += ", MAIN.GOODSMAKERCDRF MAIN_GOODSMAKERCDRF" + Environment.NewLine;      // ���i���[�J�[�R�[�h
                SelectDm += ", MAIN.GOODSNORF MAIN_GOODSNORF" + Environment.NewLine;                // ���i�R�[�h
                SelectDm += ", MAIN.BLGROUPCODERF MAIN_BLGROUPCODERF" + Environment.NewLine;        // BL�O���[�v�R�[�h
                SelectDm += ", MAIN.BLGOODSCODERF MAIN_BLGOODSCODERF" + Environment.NewLine;        // BL�R�[�h
                SelectDm += ", MAIN.SUPPLIERCDRF MAIN_SUPPLIERCDRF" + Environment.NewLine;          // �d����R�[�h
                SelectDm += ", ACPTANODRREMAINCNTRF" + Environment.NewLine;                         // �����c��
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���
                SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF" + Environment.NewLine;              // ���[�J�[�}�X�^�E���[�J�[����
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;        // �O���[�v�R�[�h�}�X�^�E�O���[�v�R�[�h����
                SelectDm += " ,BLGR.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;  // ���i�啪�ރR�[�h
                SelectDm += " ,BLGR.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;  // ���i�����ރR�[�h
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;// ���Е��ރR�[�h
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;// �w��
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;// JAN�R�[�h
                SelectDm += " ,GOODS.GOODSNAMERF AS GOODSNAMERF" + Environment.NewLine;// JAN�R�[�h
                SelectDm += ", BLCD.GOODSRATEGRPCODERF BLCD_GOODSRATEGRPCODERF" + Environment.NewLine;// BL�R�[�h�}�X�^�E���i�|���O���[�v�R�[�h�@// ADD caohh  2015/03/06 for Redmine#44951
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;// ���i�}�X�^�E���i����
                SelectDm += ", SEC.SECTWAREHOUSECD1RF SEC_SECTWAREHOUSECD1RF" + Environment.NewLine;// ���_���ݒ�}�X�^�E�D��q�ɂP
                SelectDm += ", WH1.WAREHOUSENAMERF WH1_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���(�D��q�ɂP)
                SelectDm += ", SEC.SECTWAREHOUSECD2RF SEC_SECTWAREHOUSECD2RF" + Environment.NewLine;// ���_���ݒ�}�X�^�E�D��q�ɂQ
                SelectDm += ", WH2.WAREHOUSENAMERF WH2_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���(�D��q�ɂQ)
                SelectDm += ", SEC.SECTWAREHOUSECD3RF SEC_SECTWAREHOUSECD3RF" + Environment.NewLine;// ���_���ݒ�}�X�^�E�D��q�ɂR
                SelectDm += ", WH3.WAREHOUSENAMERF WH3_WAREHOUSENAMERF" + Environment.NewLine;        // �q�Ƀ}�X�^�E�q�ɖ���(�D��q�ɂR)
                SelectDm += ", MAIN.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                SelectDm += ", MAIN.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", MAIN.GOODS_GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                SelectDm += ", MAIN.SHIPMENTCNTRF " + Environment.NewLine;
                SelectDm += " , GOODSPRICE.PRICESTARTDATERF AS GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; ;// ���i�J�n��
                SelectDm += " , GOODSPRICE.LISTPRICERF AS GOODSPRICE_LISTPRICERF" + Environment.NewLine; ;// �艿�i�����j
                SelectDm += " , STOCK.STOCKDIVRF AS STOCK_STOCKDIVRF" + Environment.NewLine; ;// �݌ɋ敪
                SelectDm += " , STOCK.LASTSTOCKDATERF AS STOCK_LASTSTOCKDATERF" + Environment.NewLine; ;// �ŏI�d���N����
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                SelectDm += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                SelectDm += "FROM" + Environment.NewLine;
                SelectDm += "(" + Environment.NewLine;
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += "SLS.ENTERPRISECODERF ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += ", SLS.RESULTSADDUPSECCDRF SECTIONCODERF" + Environment.NewLine;
                SelectDm += ", SLD.WAREHOUSECODERF WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSMAKERCDRF GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNORF GOODSNORF" + Environment.NewLine;
                SelectDm += ", SLD.BLGROUPCODERF BLGROUPCODERF" + Environment.NewLine;
                SelectDm += ", SLD.BLGOODSCODERF BLGOODSCODERF" + Environment.NewLine;
                SelectDm += ", SLD.SUPPLIERCDRF SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += ", SUM(SLD.ACPTANODRREMAINCNTRF) ACPTANODRREMAINCNTRF" + Environment.NewLine;
                SelectDm += ", SUM(SLD.SHIPMENTCNTRF) SHIPMENTCNTRF" + Environment.NewLine;
                SelectDm += ", SLD.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                SelectDm += ", SLD.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;

                //SelectDm += " FROM SALESSLIPRF AS SLS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM SALESSLIPRF AS SLS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN " + Environment.NewLine;
                //SelectDm += " SALESDETAILRF AS SLD" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " SALESDETAILRF AS SLD WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON" + Environment.NewLine;
                SelectDm += " SLS.ENTERPRISECODERF = SLD.ENTERPRISECODERF AND" + Environment.NewLine;
                SelectDm += " SLS.ACPTANODRSTATUSRF = SLD.ACPTANODRSTATUSRF AND" + Environment.NewLine;
                SelectDm += " SLS.SALESSLIPNUMRF = SLD.SALESSLIPNUMRF" + Environment.NewLine;
                #endregion

                #region WHERE���̍쐬
                SelectDm += " WHERE" + Environment.NewLine;
                //����f�[�^�F�u�󒍽ð��=30�F����v�@AND�@���㖾�׃f�[�^�F�u�i�Ԃ��Z�b�g����Ă���v���R�[�h
                SelectDm += " SLS.ACPTANODRSTATUSRF = 30 AND " + Environment.NewLine;
                SelectDm += " SLD.GOODSNORF  != ''" + Environment.NewLine;

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);


                //��ƃR�[�h�ݒ�
                sqlCommand.CommandText += " AND SLS.ENTERPRISECODERF=@ENTERPRISECODE";
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                // �Ǘ����_
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }

                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF<=@SECTIONCODEED" + Environment.NewLine;
                    SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                    paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }

                //�I�����ȍ~�̃��R�[�h�i�v����Ŕ��f����j
                if (inventoryExtCndtnWork.InventoryDate != DateTime.MinValue)
                {
                    int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                    sqlCommand.CommandText += " AND SLS.ADDUPADATERF > " + InventoryDate.ToString() + Environment.NewLine;
                }

                //-----DEL 2011/01/28 ----->>>>>
                //if (inventoryExtCndtnWork.WarehouseDiv == 0) // �q�Ɏw��敪 0:�͈�,1:�P��
                //{
                //    //�q�ɃR�[�h�ݒ�
                //    if (inventoryExtCndtnWork.StWarehouseCd != "")
                //    {
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                //        SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                //    }
                //    if (inventoryExtCndtnWork.EdWarehouseCd != "")
                //    {
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine;
                //        SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd);
                //    }
                //}
                //else
                //{
                //    #region �P�Ƒq�Ɏw��
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " AND ( ";
                //    }

                //    //�q�ɃR�[�h01�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //    {
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD01";
                //        SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //        paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd01);
                //    }

                //    //�q�ɃR�[�h02�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd02 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD02";
                //        SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //        paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd02);
                //    }

                //    //�q�ɃR�[�h03�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd03 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD03";
                //        SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //        paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd03);
                //    }

                //    //�q�ɃR�[�h04�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd04 != "")
                //    {

                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD04";
                //        SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //        paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd04);
                //    }

                //    //�q�ɃR�[�h05�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd05 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD05";
                //        SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //        paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd05);
                //    }

                //    //�q�ɃR�[�h06�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd06 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD06";
                //        SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //        paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd06);
                //    }

                //    //�q�ɃR�[�h07�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd07 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD07";
                //        SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //        paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd07);
                //    }

                //    //�q�ɃR�[�h08�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd08 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD08";
                //        SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //        paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd08);
                //    }

                //    //�q�ɃR�[�h09�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd09 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD09";
                //        SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //        paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd09);
                //    }

                //    //�q�ɃR�[�h10�ݒ�
                //    if (inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd09 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD10";
                //        SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //        paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd10);
                //    }
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " ) ";
                //    }
                //    #endregion

                //}
                //-----DEL 2011/01/28 -----<<<<<

                //�I�Ԑݒ�
                if (inventoryExtCndtnWork.StWarehouseShelfNo != "")
                {
                    sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);
                }
                if (inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                {
                    //sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO " + Environment.NewLine;                                                       // 2008.10.08 ADD  //DEL yangyi 2013/05/06 Redmine#35493
                    sqlCommand.CommandText += " AND ( SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF IS NULL ) " + Environment.NewLine;                   // 2008.10.08 ADD  //ADD yangyi 2013/05/06 Redmine#35493
                    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);
                }

                //�d����R�[�h�ݒ�
                if (inventoryExtCndtnWork.StCustomerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);
                }
                if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                }

                //�a�k���i�R�[�h�ݒ�
                if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                }
                if (inventoryExtCndtnWork.EdBLGoodsCd != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                }

                // �O���[�v�R�[�h�ݒ�
                if (inventoryExtCndtnWork.StBLGroupCode != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                    paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                }
                if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                    paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                }
                //���[�J�[�R�[�h�ݒ�
                if (inventoryExtCndtnWork.StMakerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF>=@STMAKERCODE" + Environment.NewLine;
                    SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                    paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                }
                if (inventoryExtCndtnWork.EdMakerCd != 999)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF<=@EDMAKERCODE" + Environment.NewLine;
                    SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                    paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                }

                #endregion

                #region GROUP���̍쐬
                sqlCommand.CommandText += "GROUP BY " + Environment.NewLine;
                sqlCommand.CommandText += "SLS.ENTERPRISECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.WAREHOUSECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.SUPPLIERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGOODSCODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSMAKERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGROUPCODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.SALESUNITCOSTRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.LISTPRICETAXEXCFLRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNAMERF " + Environment.NewLine;
                sqlCommand.CommandText += ")AS MAIN " + Environment.NewLine;
                #endregion

                #region LEFT JOIN���̍쐬
                // ���_���ݒ�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " SEC.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " SEC.SECTIONCODERF=MAIN.SECTIONCODERF" + Environment.NewLine;
                // �q�Ƀ}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH.WAREHOUSECODERF=MAIN.WAREHOUSECODERF" + Environment.NewLine;
                // �q�Ƀ}�X�^����(�D��q�ɂP)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH1.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH1.WAREHOUSECODERF=SEC.SECTWAREHOUSECD1RF" + Environment.NewLine;
                // �q�Ƀ}�X�^����(�D��q�ɂQ)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH2.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH2.WAREHOUSECODERF=SEC.SECTWAREHOUSECD2RF" + Environment.NewLine;
                // �q�Ƀ}�X�^����(�D��q�ɂR)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH3.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH3.WAREHOUSECODERF=SEC.SECTWAREHOUSECD3RF" + Environment.NewLine;
                // ���[�J�[�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " MAK.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " MAK.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF" + Environment.NewLine;
                // ���i�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " GOODS.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSNORF=MAIN.GOODSNORF" + Environment.NewLine;
                // �O���[�v�R�[�h�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLGR.BLGROUPCODERF=MAIN.BLGROUPCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND BLGR.ENTERPRISECODERF=MAIN.ENTERPRISECODERF";
                // BL�R�[�h�}�X�^����
                //sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLCD.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " BLCD.BLGOODSCODERF = MAIN.BLGOODSCODERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                int inventoryDateGoods = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                //sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += " AND GOODSPRICE.PRICESTARTDATERF  <=" + inventoryDateGoods.ToString() + Environment.NewLine;

                //sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                //-----ADD 2011/01/11-----<<<<<

                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                #endregion


                //���ʎ擾
                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/21
                myReader = sqlCommand.ExecuteReader();
                InventoryDataWork beInventoryDataWork = null;
                //-----ADD 2011/01/28 ----->>>>>
                string WarehouseCodeStr = string.Empty;
                //-----ADD 2011/01/28 -----<<<<<

                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                //string goodsNo = string.Empty;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                string keyValue = string.Empty;
                //RateWork rateW = null;// 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                RateWork rateAllSec = null;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                while (myReader.Read())
                {
                    #region ���o���ʃZ�b�g
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF")).Trim();
                    wkInventoryDataWork.GoodsNoSrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                    wkInventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                    //---DEL 2011/02/11 ----->>>
                    //if (string.IsNullOrEmpty(wkInventoryDataWork.GoodsName))
                    //{
                    //    wkInventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    //}
                    //---DEL 2011/02/11 -----<<<
                    wkInventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));
                    wkInventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));
                    wkInventoryDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_SUPPLIERCDRF"));
                    wkInventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    wkInventoryDataWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;
                    wkInventoryDataWork.WarehouseShelfNo = "���޼";
                    wkInventoryDataWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkInventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));

                    wkInventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // ���i�啪�ރR�[�h  
                    wkInventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // BL�O���[�v�R�[�h  
                    wkInventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// ���Е��ރR�[�h
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));            // �ύX�O�d���P��
                    wkInventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // �I������������
                    wkInventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // �I��������������
                    wkInventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // �ŏI�I���X�V�� 
                    wkInventoryDataWork.StockMashinePrice = Convert.ToInt64(wkInventoryDataWork.StockUnitPriceFl * wkInventoryDataWork.StockTotal);�@       // �}�V���݌Ɋz
                    wkInventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // ���i�}�X�^�EJAN�R�[�h
                    wkInventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_STOCKDIVRF"));
                    wkInventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTSTOCKDATERF")); // �ŏI�d���N����

                    //-----ADD 2011/01/28 ----->>>>>
                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                            && WarehouseCodeStr == wkInventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                            && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd
                            && beInventoryDataWork.StockUnitPriceFl == wkInventoryDataWork.StockUnitPriceFl
                            && beInventoryDataWork.ListPriceFl == wkInventoryDataWork.ListPriceFl
                            && beInventoryDataWork.GoodsName == wkInventoryDataWork.GoodsName)
                        {
                            continue;
                        }
                    }
                    WarehouseCodeStr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF")); // ADD 2011/01/28
                    //-----ADD 2011/01/28 -----<<<<<

                    if (string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD1RF"));
                    }
                    if (string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD2RF"));
                    }
                    if (string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD3RF"));
                    }

                    //-----ADD 2011/01/28 ----->>>>>
                    String warehouseCode = wkInventoryDataWork.WarehouseCode.Trim();
                    // �q�Ɏw��敪 0:�͈�,1:�P��
                    if (inventoryExtCndtnWork.WarehouseDiv == 0)
                    {
                        if ((inventoryExtCndtnWork.StWarehouseCd != "" && inventoryExtCndtnWork.StWarehouseCd.CompareTo(warehouseCode) > 0) ||
                            (inventoryExtCndtnWork.EdWarehouseCd != "" && inventoryExtCndtnWork.EdWarehouseCd.CompareTo(warehouseCode) < 0))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (inventoryExtCndtnWork.WarehouseCd01 != "" ||
                            inventoryExtCndtnWork.WarehouseCd02 != "" ||
                            inventoryExtCndtnWork.WarehouseCd03 != "" ||
                            inventoryExtCndtnWork.WarehouseCd04 != "" ||
                            inventoryExtCndtnWork.WarehouseCd05 != "" ||
                            inventoryExtCndtnWork.WarehouseCd06 != "" ||
                            inventoryExtCndtnWork.WarehouseCd07 != "" ||
                            inventoryExtCndtnWork.WarehouseCd08 != "" ||
                            inventoryExtCndtnWork.WarehouseCd09 != "" ||
                            inventoryExtCndtnWork.WarehouseCd10 != "")
                        {
                            if (!((inventoryExtCndtnWork.WarehouseCd01 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd01) ||
                                (inventoryExtCndtnWork.WarehouseCd02 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd02) ||
                                (inventoryExtCndtnWork.WarehouseCd03 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd03) ||
                                (inventoryExtCndtnWork.WarehouseCd04 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd04) ||
                                (inventoryExtCndtnWork.WarehouseCd05 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd05) ||
                                (inventoryExtCndtnWork.WarehouseCd06 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd06) ||
                                (inventoryExtCndtnWork.WarehouseCd07 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd07) ||
                                (inventoryExtCndtnWork.WarehouseCd08 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd08) ||
                                (inventoryExtCndtnWork.WarehouseCd09 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd09) ||
                                (inventoryExtCndtnWork.WarehouseCd10 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd10)))
                            {
                                continue;
                            }
                        }
                    }
                    //-----ADD 2011/01/28 -----<<<<<

                    if (!string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        //-----DEL 2011/01/28 ----->>>>>
                        //if (beInventoryDataWork != null)
                        //{
                        //    if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                        //        && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                        //        && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                        //        && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                        //        && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                        //        && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                        //        && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd
                        //        && beInventoryDataWork.StockUnitPriceFl == wkInventoryDataWork.StockUnitPriceFl
                        //        && beInventoryDataWork.ListPriceFl == wkInventoryDataWork.ListPriceFl
                        //        && beInventoryDataWork.GoodsName == wkInventoryDataWork.GoodsName)
                        //    {
                        //        continue;
                        //    }
                        //}
                        //-----DEL 2011/01/28 -----<<<<<
                        //---DEL 2011/02/11 ----->>>
                        //if (wkInventoryDataWork.ListPriceFl == 0)
                        //{
                        //    wkInventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));
                        //}
                        //---DEL 2011/02/11 -----<<<
                        beInventoryDataWork = wkInventoryDataWork;

                        resultList.Add(wkInventoryDataWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // -- DEL 2012/05/21 -------------------------->>>>
                    //}
                    //#endregion
                    // -- DEL 2012/05/21 --------------------------<<<<

                        GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                        UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                        GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g

                        #region ���i�d���擾�f�[�^�N���X
                        goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// ��ƃR�[�h
                        goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));      // ���_�R�[�h
                        goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // ���i�ԍ�
                        goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));     // BL�R�[�h
                        goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // ���i�����ރR�[�h
                        GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                        #endregion

                        #region �P���Z�o���W���[���v�Z�p�p�����[�^
                        unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // ���_�R�[�h
                        unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));  // ���[�J�[�R�[�h
                        unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // ���i�ԍ�
                        //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));�@ // ���i�����ރR�[�h // DEL caohh 2015/03/06 for Redmine#44951
                        unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCD_GOODSRATEGRPCODERF"));�@ // ���i�|���O���[�v�R�[�h// ADD caohh  2015/03/06 for Redmine#44951
                        unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));// BL�O���[�v�R�[�h
                        unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));  // BL�R�[�h
                        unitPriceCalcParam.PriceApplyDate = DateTime.Now;// DEL caohh for Redmine#44951
                        unitPriceCalcParam.PriceApplyDate = inventoryExtCndtnWork.InventoryDate;// ADD caohh  2015/03/06 for Redmine#44951
                        unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSRATERANKRF"));  // �w��
                        unitPriceCalcParamList.Add(unitPriceCalcParam);
                        #endregion

                        #region ���i�A���f�[�^���X�g
                        goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// ��ƃR�[�h
                        goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // ���i�ԍ�
                        goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        goodsUnitDataList.Add(goodsUnitData);
                        #endregion

                        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                        #region �P�i�|�����X�g

                        //���_���P�i�|��
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // ���_�R�[�h
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // ���i�ԍ�
                        //keyValue = sectionCode.Trim() + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        //if (!rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        keyValue = string.Format(ctDicKeyFmt, wkInventoryDataWork.SectionCode.Trim(), wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //�����i�̋��_���P�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        {
                            // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                            //rateW = new RateWork();
                            //rateW.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            //rateW.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            //rateWorkByGoodsNoDic.Add(keyValue, rateW);
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                            // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        }

                        //�S�ВP�i�|�� 
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //�S�ВP�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));

                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    // -- ADD 2012/05/21 -------------------------->>>>
                    }
                    #endregion
                    // -- ADD 2012/05/21 --------------------------<<<<
                }

                if (!myReader.IsClosed) myReader.Close();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�d������擾���� ���s
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region ���i�d������擾���� ���ʃZ�b�g
                    // ���i�d������擾�����ɂ��擾�����d�����
                    // �P���Z�o�p�����[�^�E�I���f�[�^���[�N�ɃZ�b�g
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                    {
                        //-- UPD 2012/05/21 ------------------------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v���폜�A�z��ԍ��ŕR�t����悤�ɂ���B
                        //for (int j = 0; j < unitPriceCalcParamList.Count; j++) // �P���Z�o���W���[���v�Z�p�p�����[�^
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //        }
                        //    }
                        //}

                        //for (int j = 0; j < al.Count; j++) // �I���f�[�^���[�N
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[i].GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[i].GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[i].BLGoodsCode) &&   // BL���i�R�[�h
                            (GoodsSupplierDataWorkList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == ((InventoryDataWork)resultList[i]).BLGoodsCode))     // BL���i�R�[�h
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                unitPriceCalcParamList[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                                //((InventoryDataWork)resultList[i]).SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // DEL 2012/06/14
                                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� ----->>>>>
                                if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParamList[i].SupplierCd))
                                {
                                    unitPriceCalcParamList[i].StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParamList[i].SupplierCd].StockUnPrcFrcProcCd;
                                }
                                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� -----<<<<<
                            }
                        }
                        else
                        {
                            throw new Exception("���i�Ǘ����ƒI���f�[�^�̕R�t�����s���ł��B�i�����v�㕪�f�[�^���o�j" +
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                unitPriceCalcParamList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcParamList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------------------------<<<<
                    }
                    #endregion

                    //�����Z�o���� ���s
                    //unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//DEL 2012/07/10 for Redmine#31103
                    //unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//ADD 2012/07/10 for Redmine#31103 // DEL 2013/06/07 wangl2 For Redmine#35788
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //status = unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                    status = unitPriceCalculation.CalculateUnitCostForInventory2(unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, out unitPriceCalcRetList);
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                    #region �����Z�o���� ���ʃZ�b�g
                    // �����Z�o�����ɂ��擾����������
                    // �݌ɗ����f�[�^�N���X�ɃZ�b�g
                    for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                    {
                        // -- UPD 2012/05/21 ------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v�폜�A�z��ԍ��ŕR�t����悤�ύX����
                        //for (int j = 0; j < resultList.Count; j++) // �I���f�[�^�N���X
                        //{
                        //    if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[j]).GoodsMakerCd) && // ���i���[�J�[
                        //        (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[j]).GoodsNo))     // BL���i�R�[�h
                        //    {
                        //        if (((InventoryDataWork)resultList[j]).StockUnitPriceFl == 0)
                        //        {
                        //            // �d���P��
                        //            ((InventoryDataWork)resultList[j]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //            // �ύX�O�d���P��
                        //            ((InventoryDataWork)resultList[j]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                        //        }
                        //        // �����p�v�Z����
                        //        double adjstCalcCost = 0;
                        //        FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                        //        ((InventoryDataWork)resultList[j]).AdjstCalcCost = adjstCalcCost;
                        //    }
                        //}
                        #endregion
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // ���i���[�J�[
                            (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo))     // BL���i�R�[�h
                        {
                            if (((InventoryDataWork)resultList[i]).StockUnitPriceFl == 0)
                            {
                                // �d���P��
                                ((InventoryDataWork)resultList[i]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                // �ύX�O�d���P��
                                ((InventoryDataWork)resultList[i]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                            }
                            // �����p�v�Z����
                            double adjstCalcCost = 0;
                            FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                            ((InventoryDataWork)resultList[i]).AdjstCalcCost = adjstCalcCost;
                        }
                        else
                        {
                            throw new Exception("�����Z�o���ʂƒI���f�[�^�̕R�t�����s���ł��B�i�����v�㕪�f�[�^���o�j" +
                                                i.ToString() + " : " +
                                                unitPriceCalcRetList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcRetList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------<<<<
                    }
                    #endregion

                    #region �d����R�[�h���o����
                    for (int i = 0; i < resultList.Count; i++) // �I���f�[�^���[�N
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= ((InventoryDataWork)resultList[i]).SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= ((InventoryDataWork)resultList[i]).SupplierCd))
                        {
                            wkList.Add(((InventoryDataWork)resultList[i]));
                        }
                    }
                    #endregion

                    resultList = wkList;

                }
                //-----UPD 2011/01/28 ----->>>>>
                //SortData(resultList, ref al); List<InventoryDataWork> alLend
                //SortDataOrder(ref al);
                List<InventoryDataWork> alResultList = null;
                SortData(resultList, out alResultList);

                SortDataOrder(ref al, alResultList);
                //-----UPD 2011/01/28 -----<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ���������f�[�^�\�[�g����
        /// </summary>
        /// <param name="resultList">��������ArrayList</param>
        /// <param name="al">�\�[�g����ArrayList</param>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�\�[�g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        //-----UPD 2011/01/28 ----->>>>>
        //private void SortData(ArrayList resultList, ref List<InventoryDataWork> al)
        private void SortData(ArrayList resultList, out List<InventoryDataWork> alResultList)
        //-----UPD 2011/01/28 -----<<<<<
        {
            alResultList = new List<InventoryDataWork>(); // ADD 2011/01/28

            if (resultList.Count == 0) return;
            string wareCode = string.Empty;
            string goodNo = string.Empty;
            string currentData = string.Empty;
            int makerCode = 0;
            double stockTotal = 0;
            string sectioncode = string.Empty;
            int blgroupcode;
            int blgoodscode;
            int suppliercd;
            double listPriceTaxExcFl = 0;
            double salesunitcost;

            ArrayList arrayList = new ArrayList();
            foreach (InventoryDataWork data in resultList)
            {
                // �q��
                wareCode = data.WarehouseCode.Trim();
                // �i
                goodNo = data.GoodsNoSrc.Trim();
                // ���[�J�[
                makerCode = data.GoodsMakerCd;
                sectioncode = data.SectionCode.Trim();
                blgroupcode = data.BLGroupCode;
                blgoodscode = data.BLGoodsCode;
                suppliercd = data.SupplierCd;
                salesunitcost = data.StockUnitPriceFl;
                listPriceTaxExcFl = data.ListPriceFl;
                // ����̃f�[�^�̕ۑ�
                currentData = wareCode + "-" + goodNo + "-" + makerCode.ToString() + sectioncode + blgroupcode.ToString()
                    + blgoodscode.ToString() + suppliercd.ToString() + salesunitcost.ToString() + listPriceTaxExcFl.ToString();

                // �d���f�[�^�ł͂Ȃ��ꍇ(�q�ɁE�i�ԁE���[�J�[)
                if (arrayList.Count <= 0 || !arrayList.Contains(currentData))
                {
                    arrayList.Add(currentData);
                    foreach (InventoryDataWork searchData in resultList)
                    {
                        string currentWareCode = searchData.WarehouseCode.Trim();
                        string currentGoodNo = searchData.GoodsNoSrc.Trim();
                        int currentMakerCode = searchData.GoodsMakerCd;
                        //�q�ɁE�i�ԁE���[�J�[�������ŁA�i���Ⴂ�̃f�[�^�����݂���ꍇ
                        if ((currentWareCode.Equals(wareCode)) && (currentGoodNo.Equals(goodNo)) && (currentMakerCode == makerCode)
                            && (searchData.SectionCode.Trim().Equals(sectioncode)) && (searchData.BLGroupCode.Equals(blgroupcode))
                            && (searchData.BLGoodsCode.Equals(blgoodscode)) && (searchData.SupplierCd.Equals(suppliercd))
                            && (searchData.StockUnitPriceFl.Equals(salesunitcost)) && (searchData.ListPriceFl.Equals(listPriceTaxExcFl)))
                        {
                            //����
                            if ("���޼".Equals(searchData.WarehouseShelfNo))
                            {
                                // �o�א����v
                                stockTotal += searchData.ShipmentCnt;
                            }
                            //�ݏo
                            else if ("���޼".Equals(searchData.WarehouseShelfNo))
                            {
                                // ���됔���v
                                stockTotal += searchData.StockTotal;
                            }
                        }
                    }
                    data.StockTotal = stockTotal;
                    //-----UPD 2011/01/28 ----->>>>>
                    //al.Add(data);
                    alResultList.Add(data);
                    //-----UPD 2011/01/28 -----<<<<<
                    stockTotal = 0;
                }
            }
        }


        /// <summary>
        /// ���������f�[�^�\�[�g����
        /// </summary>
        /// <param name="flag">��������ArrayList</param>
        /// <param name="al">�\�[�g����ArrayList</param>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�\�[�g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        //private void SortDataOrderList (ref List<InventoryDataWork> al)// DEL 2011/01/28
        private void SortDataOrderList(ref List<InventoryDataWork> al, List<InventoryDataWork> alResultList)// ADD 2011/01/28
        {
            Dictionary<String, InventoryDataWork> dic = new Dictionary<String, InventoryDataWork>();
            string Key = "";
            ArrayList alList = new ArrayList();

            //foreach (InventoryDataWork wkInventoryDataWork in al)// DEL 2011/01/28
            foreach (InventoryDataWork wkInventoryDataWork in alResultList)// ADD 2011/01/28
            {
                if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                {
                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.PadRight(23, ' ');
                    //�i�Ԃ̐擪>22�̏ꍇ
                    if (!string.IsNullOrEmpty(wkInventoryDataWork.GoodsNo) && wkInventoryDataWork.GoodsNo.Length > 22)
                    {
                        Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                            wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Substring(0, 22));

                        string goodsNo = wkInventoryDataWork.GoodsNo;

                        if (!dic.ContainsKey(Key))
                        {
                            dic.Add(Key, wkInventoryDataWork);

                            if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                            {
                                wkInventoryDataWork.GoodsNo = goodsNo.Substring(0, 22) + ".";
                            }
                        }
                        else
                        {
                            int index = 0;
                            for (int i = 0; i < alList.Count; i++)
                            {
                                InventoryDataWork tempwork = (InventoryDataWork)alList[i];
                                if (tempwork.GoodsNo.Length > 22)
                                {
                                    if (tempwork.WarehouseCode.Equals(wkInventoryDataWork.WarehouseCode)
                                        && (tempwork.GoodsMakerCd.Equals(wkInventoryDataWork.GoodsMakerCd))
                                        && (tempwork.GoodsNo.Substring(0, 22).Equals(wkInventoryDataWork.GoodsNo.Substring(0, 22)))
                                        && (tempwork.WarehouseShelfNo.Equals(wkInventoryDataWork.WarehouseShelfNo)))
                                    {
                                        index++;
                                    }
                                }
                            }

                            if (index > 25)
                            {
                                if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //�uA�v���珇�ɕt�Ԃ���
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "." + Convert.ToChar('Z').ToString();
                                }
                            }
                            else
                            {
                                if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //�uA�v���珇�ɕt�Ԃ���
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "." + Convert.ToChar('A' + (index - 1)).ToString();
                                }
                            }
                        }
                    }
                    alList.Add(wkInventoryDataWork);
                    al.Add(wkInventoryDataWork); // ADD 2011/01/28
                }
            }
        }

        /// <summary>
        /// ���������f�[�^�\�[�g����
        /// </summary>
        /// <param name="flag">��������ArrayList</param>
        /// <param name="al">�\�[�g����ArrayList</param>
        /// <remarks>
        /// <br>Note       : ���������f�[�^�\�[�g���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        /// private void SortDataOrder(ref List<InventoryDataWork> al)// DEL 2011/01/28
        private void SortDataOrder(ref List<InventoryDataWork> al, List<InventoryDataWork> alResultList)// ADD 2011/01/28
        {
            Dictionary<String, InventoryDataWork> dic = new Dictionary<String, InventoryDataWork>();
            string Key = "";
            ArrayList alList = new ArrayList();

            //foreach (InventoryDataWork wkInventoryDataWork in al) // DEL 2011/01/28
            foreach (InventoryDataWork wkInventoryDataWork in alResultList) // ADD 2011/01/28
            {
                if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                {
                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.PadRight(23, ' ');
                    //�i�Ԃ̐擪>22�̏ꍇ
                    if (!string.IsNullOrEmpty(wkInventoryDataWork.GoodsNo) && wkInventoryDataWork.GoodsNo.Length > 22)
                    {
                        Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                            wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Substring(0, 22));

                        string goodsNo = wkInventoryDataWork.GoodsNo;

                        if (!dic.ContainsKey(Key))
                        {
                            dic.Add(Key, wkInventoryDataWork);

                            if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                            {
                                wkInventoryDataWork.GoodsNo = goodsNo.Substring(0, 22) + "*";
                            }
                        }
                        else
                        {
                            int index = 0;
                            for (int i = 0; i < alList.Count; i++)
                            {
                                InventoryDataWork tempwork = (InventoryDataWork)alList[i];
                                if (tempwork.GoodsNo.Length > 22)
                                {
                                    if (tempwork.WarehouseCode.Equals(wkInventoryDataWork.WarehouseCode)
                                        && (tempwork.GoodsMakerCd.Equals(wkInventoryDataWork.GoodsMakerCd))
                                        && (tempwork.GoodsNo.Substring(0, 22).Equals(wkInventoryDataWork.GoodsNo.Substring(0, 22)))
                                        && (tempwork.WarehouseShelfNo.Equals(wkInventoryDataWork.WarehouseShelfNo)))
                                    {
                                        index++;
                                    }
                                }
                            }

                            if (index > 25)
                            {
                                if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //�uA�v���珇�ɕt�Ԃ���
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "*" + Convert.ToChar('Z').ToString();
                                }
                            }
                            else
                            {
                                if ("���޼".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //�uA�v���珇�ɕt�Ԃ���
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "*" + Convert.ToChar('A' + (index - 1)).ToString();
                                }
                            }
                        }
                    }
                    alList.Add(wkInventoryDataWork);
                    al.Add(wkInventoryDataWork); // ADD 2011/01/28
                }
            }
        }

        //-----ADD 2011/01/11-----<<<<<
        // �V�X�e�����b�N�p�q�Ƀ��X�g�쐬
        private int searchWarehouse(ref InventoryExtCndtnWork inventoryExtCndtnWork, out Dictionary<string, string> wareList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            wareList = new Dictionary<string, string>();
            try
            {
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += "     WAREHOUSECODERF" + Environment.NewLine;
                //sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlTxt += " FROM WAREHOUSERF WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlTxt += " WHERE" + Environment.NewLine;
                sqlTxt += "     ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                if (inventoryExtCndtnWork.StWarehouseCd != "")
                {
                    sqlTxt += " AND WAREHOUSECODERF >= @STWAREHOUSECODE" + Environment.NewLine;
                }
                if (inventoryExtCndtnWork.EdWarehouseCd != "")
                {
                    sqlTxt += " AND WAREHOUSECODERF <= @EDWAREHOUSECODE" + Environment.NewLine;
                }
                //----ADD 2012/07/10 for Redmine#31103�̃V�X�e�����b�N(�q��)------>>>>>>
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlTxt += " AND SECTIONCODERF >= @STSECTIONCODE" + Environment.NewLine;
                }
                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlTxt += " AND SECTIONCODERF <= @EDSECTIONCODE" + Environment.NewLine;
                }
                //----ADD 2012/07/10 for Redmine#31103�̃V�X�e�����b�N(�q��)------<<<<<<<
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                if (inventoryExtCndtnWork.StWarehouseCd != "")
                {
                    SqlParameter findParaStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                    findParaStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                }
                if (inventoryExtCndtnWork.EdWarehouseCd != "")
                {
                    SqlParameter findParaEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                    findParaEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd);
                }
                //----ADD 2012/07/10 for Redmine#31103�̃V�X�e�����b�N(�q��)------>>>>>>
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    SqlParameter findParaStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                    findParaStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }
                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    SqlParameter findParaEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                    findParaEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }
                //----ADD 2012/07/10 for Redmine#31103�̃V�X�e�����b�N(�q��)------<<<<<<<<
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string warehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wareList.Add(warehouseCode, warehouseCode);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion    // SearchWriteProc

        // --- ADD 2010/02/20 ---------->>>>>
        #region �݌Ƀ}�X�^��������(�I���f�[�^���݃`�F�b�N�p)
        /// <summary>
        /// �݌ɐ��ԃ}�X�^���������A�I���f�[�^List��߂��܂�(�I���f�[�^���݃`�F�b�N�p)
        /// </summary>
        /// <param name="al">�I���f�[�^List</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remark>
        /// <br>Note       : �݌ɐ��ԃ}�X�^���������A�I���f�[�^List��߂��܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/02/20</br>
        /// </remark>
        private int SeachProductStockRepate(out List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            al = new List<InventoryDataWork>();
            List<InventoryDataWork> wkList = new List<InventoryDataWork>();

            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                #region ���Ѝ݌Ɏ擾�N�G��

                #region Selecet��
                string SelectDm = string.Empty;
                SelectDm += "SELECT DISTINCT" + Environment.NewLine;
                SelectDm += "  STK.ENTERPRISECODERF AS STK_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " ,STK.SECTIONCODERF AS STK_SECTIONCODERF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSMAKERCDRF AS STK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSNORF AS STK_GOODSNORF " + Environment.NewLine;
                SelectDm += " ,STK.STOCKUNITPRICEFLRF AS STK_STOCKUNITPRICEFLRF" + Environment.NewLine; // �d���P���i�Ŕ�,�����j
                SelectDm += " ,STK.SUPPLIERSTOCKRF AS STK_SUPPLIERSTOCKRF" + Environment.NewLine;
                SelectDm += " ,STK.LASTSTOCKDATERF AS STK_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += " ,STK.LASTINVENTORYUPDATERF AS STK_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSECODERF AS STK_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSESHELFNORF AS STK_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO1RF AS STK_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO2RF AS STK_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += " ,STK.STOCKDIVRF AS STK_STOCKDIVRF" + Environment.NewLine;
                SelectDm += " ,STK.ARRIVALCNTRF AS STK_ARRIVALCNTRF" + Environment.NewLine; //���א��i���v��j
                SelectDm += " ,STK.SHIPMENTCNTRF AS STK_SHIPMENTCNTRF" + Environment.NewLine;//�o�א��i���v��j
                SelectDm += " ,STK.MOVINGSUPLISTOCKRF AS STK_MOVINGSUPLISTOCKRF" + Environment.NewLine;//�ړ����d���݌ɐ�
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;
                SelectDm += " ,GOODS.BLGOODSCODERF AS GOODS_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;
                SelectDm += " ,BLGOODS.BLGROUPCODERF AS BLGOODS_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += " ,BLGROUP.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += " ,BLGROUP.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;
                //SelectDm += "FROM STOCKRF AS STK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "FROM STOCKRF AS STK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                // ���i
                //SelectDm += "INNER JOIN GOODSURF AS GOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "INNER JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON GOODS.ENTERPRISECODERF=STK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=STK.GOODSNORF" + Environment.NewLine;
                // BL�R�[�h 
                //SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                // BL�O���[�v
                //SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 1);

                //�\�[�g�����ǉ�
                sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF";

                #endregion    // Selecet��

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                    GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g

                    #region �I���f�[�^�l�Z�b�g
                    wkInventoryDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));           // ��ƃR�[�h
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));                 // ���_�R�[�h
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSECODERF"));             // �q�ɃR�[�h
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));                // ���[�J�[�R�[�h
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));                         // ���i�R�[�h
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSESHELFNORF"));       // �I��
                    wkInventoryDataWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO1RF")); // �d���I��1
                    wkInventoryDataWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO2RF")); // �d���I��2
                    wkInventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// ���Е��ރR�[�h
                    wkInventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));                // ���i�}�X�^�EBL�R�[�h
                    wkInventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // ���i�}�X�^�EJAN�R�[�h
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));       // �d���P��
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));     // �ύX�O�d���P��
                    wkInventoryDataWork.StkUnitPriceChgFlg = 0;                                                                                         // �d���P���ύX�t���O 0:�� 1:���� 
                    wkInventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_STOCKDIVRF"));                        // �݌ɋ敪 0:���� 1:���
                    wkInventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STK_LASTSTOCKDATERF")); // �ŏI�d���N����
                    wkInventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SUPPLIERSTOCKRF"));                // ���됔
                    wkInventoryDataWork.ShipCustomerCode = 0;                                                                                           // �o�ד��Ӑ�R�[�h
                    wkInventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // �I������������
                    wkInventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // �I��������������
                    wkInventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // �ŏI�I���X�V�� 
                    wkInventoryDataWork.ToleranceUpdateCd = 0; // �ߕs���X�V�敪
                    wkInventoryDataWork.StockTotalExec = 0;    // �݌ɑ���(���{��)
                    wkInventoryDataWork.InventoryNewDiv = 0;                                                                                            // �I���V�K�ǉ��敪 0:�����쐬 1:�V�K�쐬

                    wkInventoryDataWork.StockMashinePrice = Convert.ToInt64(wkInventoryDataWork.StockUnitPriceFl * wkInventoryDataWork.StockTotal);�@ // �}�V���݌Ɋz
                    wkInventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // ���i�啪�ރR�[�h  
                    wkInventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // ���i�����ރR�[�h
                    wkInventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_BLGROUPCODERF"));              // BL�O���[�v�R�[�h  

                    wkInventoryDataWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_ARRIVALCNTRF"));               // ���א��i���v��j
                    wkInventoryDataWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SHIPMENTCNTRF"));              // �o�א��i���v��j
                    wkInventoryDataWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_MOVINGSUPLISTOCKRF"));     // �ړ����d���݌ɐ�
                    al.Add(wkInventoryDataWork);
                    #endregion    // �I���f�[�^�l�Z�b�g

                    #region ���i�d���擾�f�[�^�N���X
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));// ��ƃR�[�h
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));      // ���_�R�[�h
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));              // ���i�ԍ�
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));     // BL�R�[�h
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // ���i�����ރR�[�h
                    GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
                #endregion    // ���Ѝ݌Ɏ擾�N�G��

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�d������擾���� ���s
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region ���i�d������擾���� ���ʃZ�b�g
                    // ���i�d������擾�����ɂ��擾�����d�����
                    // �P���Z�o�p�����[�^�E�I���f�[�^���[�N�ɃZ�b�g
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                    {
                        //-- UPD 2012/05/21 ------------------------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v���폜�A�z��ԍ��ŕR�t����悤�ɂ���B
                        //for (int j = 0; j < al.Count; j++) // �I���f�[�^���[�N
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[i].GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == al[i].GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == al[i].BLGoodsCode))     // BL���i�R�[�h
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                al[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                            }
                        }
                        else
                        {
                            throw new Exception("���i�Ǘ����ƒI���f�[�^�̕R�t�����s���ł��B�i�݌Ƀ}�X�^��������(�I���f�[�^���݃`�F�b�N�p)�j" +
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                al[i].GoodsMakerCd.ToString() + ", " +
                                                al[i].GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------------------------<<<<
                    }
                    #endregion

                    #region �d����R�[�h���o����
                    for (int i = 0; i < al.Count; i++) // �I���f�[�^���[�N
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= al[i].SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= al[i].SupplierCd))
                        {
                            wkList.Add(al[i]);
                        }
                    }
                    #endregion

                    al = wkList;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachProductStockRepart Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion
        // --- ADD 2010/02/20 ----------<<<<<

        #region �݌Ƀ}�X�^��������
        /// <summary>
        /// �݌ɐ��ԃ}�X�^���������A�I���f�[�^List��߂��܂�
        /// </summary>
        /// <param name="al">�I���f�[�^List</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="supplierDic">�d����}�X�^���Dictionary</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɐ��ԃ}�X�^���������A�I���f�[�^List��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note : 2011/01/11 yangmj �I����Q�Ή�</br>
        /// <br>Update Note : 2011/09/02 wangf NS���[�U�[���Ǘv�]�ꗗ_20110629_�D��_PM7����_��Q_�A��1014�̑Ή�</br>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30282 ��1002 �I�����������̉��ǂ̑Ή�</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>�Ǘ��ԍ�   �F10901225-00 2013/5/15�z�M���ً̋}�Ή�</br>
        /// <br>             Redmine#34756�Ή��F�I����������</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
        /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
        /// <br>Update Note: 2020/06/18 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>           : PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Update Note :2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�    :11675035-00</br>
        /// <br>             PMKOBETSU-3551 �I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        /// <br>Update Note: 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 �I�����������̑Ή�</br>
        //private int SeachProductStock(out List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)  // DEL 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
        private int SeachProductStock(out List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode, Dictionary<int, SupplierWork> supplierDic)  // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I����������
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlCommand sqlCommand2 = null;
            SqlDataReader myReader = null;
            SqlDataReader myReader2 = null;
            al = new List<InventoryDataWork>();
            List<InventoryDataWork> wkList = new List<InventoryDataWork>();

            // �C�� 2009/04/27 >>>
            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �����Z�o�p
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // �����v�Z�p�����[�^�I�u�W�F�N�g���X�g
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // ���i�A���f�[�^�I�u�W�F�N�g���X�g
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // �����v�Z���ʃ��X�g 
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // �P�i�|��Dic// ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� 

            // �C�� 2009/04/27 <<<

            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                #region ���Ѝ݌Ɏ擾�N�G��

                #region Selecet��
                // �C�� 2009/04/27 >>>
                #region DEL 2009/04/27
                /*
                string SelectDm = "";
                SelectDm += "SELECT DISTINCT" + Environment.NewLine;
                //�݌Ƀ}�X�^���擾
                #region 2008/09/18 �C���O                
                //SelectDm += " STK.ENTERPRISECODERF STK_ENTERPRISECODERF";
                //SelectDm += ", STK.SECTIONCODERF STK_SECTIONCODERF";
                //SelectDm += ", STK.GOODSMAKERCDRF STK_GOODSMAKERCDRF";
                //SelectDm += ", STK.MAKERNAMERF STK_MAKERNAMERF";
                //SelectDm += ", STK.GOODSNORF STK_GOODSNORF";
                //SelectDm += ", STK.GOODSNAMERF STK_GOODSNAMERF";
                //SelectDm += ", STK.STOCKUNITPRICEFLRF STK_STOCKUNITPRICEFLRF";
                //SelectDm += ", STK.SUPPLIERSTOCKRF STK_SUPPLIERSTOCKRF";
                //SelectDm += ", STK.LASTSTOCKDATERF STK_LASTSTOCKDATERF";
                //SelectDm += ", STK.LASTINVENTORYUPDATERF STK_LASTINVENTORYUPDATERF";
                //SelectDm += ", STK.WAREHOUSECODERF STK_WAREHOUSECODERF";
                //SelectDm += ", STK.WAREHOUSENAMERF STK_WAREHOUSENAMERF";
                //SelectDm += ", STK.WAREHOUSESHELFNORF STK_WAREHOUSESHELFNORF";
                //SelectDm += ", STK.DUPLICATIONSHELFNO1RF STK_DUPLICATIONSHELFNO1RF";
                //SelectDm += ", STK.DUPLICATIONSHELFNO2RF STK_DUPLICATIONSHELFNO2RF";
                //SelectDm += ", STK.LARGEGOODSGANRECODERF STK_LARGEGOODSGANRECODERF";
                //SelectDm += ", STK.LARGEGOODSGANRENAMERF STK_LARGEGOODSGANRENAMERF";
                //SelectDm += ", STK.MEDIUMGOODSGANRECODERF STK_MEDIUMGOODSGANRECODERF";
                //SelectDm += ", STK.MEDIUMGOODSGANRENAMERF STK_MEDIUMGOODSGANRENAMERF";
                //SelectDm += ", STK.DETAILGOODSGANRECODERF STK_DETAILGOODSGANRECODERF";
                //SelectDm += ", STK.DETAILGOODSGANRENAMERF STK_DETAILGOODSGANRENAMERF";
                //SelectDm += ", STK.BLGOODSCODERF STK_BLGOODSCODERF";
                //SelectDm += ", STK.ENTERPRISEGANRECODERF STK_ENTERPRISEGANRECODERF";
                //SelectDm += ", STK.ENTERPRISEGANRENAMERF STK_ENTERPRISEGANRENAMERF";
                //SelectDm += ", STK.JANRF STK_JANRF";                 
                #endregion
                SelectDm += " STK.ENTERPRISECODERF STK_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += ", STK.SECTIONCODERF STK_SECTIONCODERF" + Environment.NewLine;
                SelectDm += ", STK.GOODSMAKERCDRF STK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += ", STK.GOODSNORF STK_GOODSNORF" + Environment.NewLine;
                SelectDm += ", STK.STOCKUNITPRICEFLRF STK_STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += ", STK.SUPPLIERSTOCKRF STK_SUPPLIERSTOCKRF" + Environment.NewLine;
                SelectDm += ", STK.LASTSTOCKDATERF STK_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += ", STK.LASTINVENTORYUPDATERF STK_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += ", STK.WAREHOUSECODERF STK_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += ", STK.WAREHOUSESHELFNORF STK_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += ", STK.DUPLICATIONSHELFNO1RF STK_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += ", STK.DUPLICATIONSHELFNO2RF STK_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += ", STK.STOCKDIVRF AS STK_STOCKDIVRF" + Environment.NewLine; // ADD 2009.01.30
                SelectDm += ", GOODS.JANRF GOODS_JANRF" + Environment.NewLine;
                SelectDm += ", GOODS.BLGOODSCODERF GOODS_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += ", GOODS.ENTERPRISEGANRECODERF GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;
                // ADD 2009.01.30 >>>
                SelectDm += ", BLGOODS.BLGROUPCODERF AS BLGOODS_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += ", BLGROUP.GOODSLGROUPRF BLGROUP_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += ", BLGROUP.GOODSMGROUPRF BLGROUP_GOODSMGROUPRF" + Environment.NewLine;
                //SelectDm += ", (CASE WHEN GOODSMNG.SUPPLIERCDRF IS NOT NULL  THEN GOODSMNG.SUPPLIERCDRF " + Environment.NewLine;
                //SelectDm += "     ELSE (CASE WHEN GOODSMNG2.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG2.SUPPLIERCDRF " + Environment.NewLine;
                //SelectDm += "           ELSE (CASE WHEN GOODSMNG3.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG3.SUPPLIERCDRF ELSE GOODSMNG4.SUPPLIERCDRF END ) END )  END) GOODSMNG_SUPPLIERCDRF" + Environment.NewLine;
                // ADD 2009.01.30 <<<
                SelectDm += " FROM STOCKRF STK " + Environment.NewLine;
                SelectDm += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine;
                SelectDm += " GOODS.ENTERPRISECODERF=STK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=STK.GOODSNORF" + Environment.NewLine;
                // ADD 2009.01.30 >>>
                // BL�R�[�h�}�X�^
                SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                // BL�O���[�v�R�[�h�}�X�^
                SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;
                // ���i�Ǘ����}�X�^
                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG.ENTERPRISECODERF --���" + Environment.NewLine;
                //SelectDm += " AND STK.SECTIONCODERF = GOODSMNG.SECTIONCODERF      -- ���_" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG.GOODSMAKERCDRF --���[�J�[" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSNORF= GOODSMNG.GOODSNORF -- �i��" + Environment.NewLine;

                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG2" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG2.ENTERPRISECODERF --���" + Environment.NewLine;
                //SelectDm += " AND '00' = GOODSMNG2.SECTIONCODERF      -- ���_" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG2.GOODSMAKERCDRF --���[�J�[" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSNORF= GOODSMNG2.GOODSNORF -- �i��" + Environment.NewLine;
                
                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG3" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG3.ENTERPRISECODERF --���" + Environment.NewLine;
                //SelectDm += " AND STK.SECTIONCODERF = GOODSMNG3.SECTIONCODERF      -- ���_" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG3.GOODSMAKERCDRF --���[�J�[" + Environment.NewLine;
                //SelectDm += " AND GOODS.BLGOODSCODERF= GOODSMNG3.BLGOODSCODERF -- BL���i�R�[�h" + Environment.NewLine;
                //SelectDm += " AND GOODSMNG2.GOODSNORF = '' -- �i��" + Environment.NewLine;
                //SelectDm += " AND (CASE WHEN BLGROUP.GOODSMGROUPRF IS NULL THEN 0 ELSE BLGROUP.GOODSMGROUPRF END) = GOODSMNG3.GOODSMGROUPRF " + Environment.NewLine;

                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG4" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG4.ENTERPRISECODERF --���" + Environment.NewLine;
                //SelectDm += " AND '00' = GOODSMNG4.SECTIONCODERF      -- ���_" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG4.GOODSMAKERCDRF --���[�J�[" + Environment.NewLine;
                //SelectDm += " AND GOODS.BLGOODSCODERF= GOODSMNG4.BLGOODSCODERF -- BL���i�R�[�h" + Environment.NewLine;
                //SelectDm += " AND GOODSMNG4.GOODSNORF = '' -- �i��" + Environment.NewLine;
                //SelectDm += " AND (CASE WHEN BLGROUP.GOODSMGROUPRF IS NULL THEN 0 ELSE BLGROUP.GOODSMGROUPRF END) = GOODSMNG4.GOODSMGROUPRF " + Environment.NewLine;
                // ADD 2009.01.30 <<<
                */
                #endregion
                string SelectDm = string.Empty;
                SelectDm += "SELECT DISTINCT" + Environment.NewLine;
                SelectDm += "  STK.ENTERPRISECODERF AS STK_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " ,STK.SECTIONCODERF AS STK_SECTIONCODERF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSMAKERCDRF AS STK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSNORF AS STK_GOODSNORF " + Environment.NewLine;
                SelectDm += " ,GOODS.GOODSNAMERF AS GOODSNAMERF " + Environment.NewLine;// ADD 2011/01/11
                SelectDm += " ,STK.STOCKUNITPRICEFLRF AS STK_STOCKUNITPRICEFLRF" + Environment.NewLine; // �d���P���i�Ŕ�,�����j
                SelectDm += " ,STK.SUPPLIERSTOCKRF AS STK_SUPPLIERSTOCKRF" + Environment.NewLine;
                SelectDm += " ,STK.LASTSTOCKDATERF AS STK_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += " ,STK.LASTINVENTORYUPDATERF AS STK_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSECODERF AS STK_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSESHELFNORF AS STK_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO1RF AS STK_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO2RF AS STK_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += " ,STK.STOCKDIVRF AS STK_STOCKDIVRF" + Environment.NewLine;
                // --- ADD 2009/11/30 ---------->>>>>
                SelectDm += " ,STK.ARRIVALCNTRF AS STK_ARRIVALCNTRF" + Environment.NewLine; //���א��i���v��j
                SelectDm += " ,STK.SHIPMENTCNTRF AS STK_SHIPMENTCNTRF" + Environment.NewLine;//�o�א��i���v��j
                SelectDm += " ,STK.MOVINGSUPLISTOCKRF AS STK_MOVINGSUPLISTOCKRF" + Environment.NewLine;//�ړ����d���݌ɐ�
                // --- ADD 2009/11/30 ----------<<<<<
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;
                SelectDm += " ,GOODS.BLGOODSCODERF AS GOODS_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;
                // --- ADD 2009/11/30 ---------->>>>>
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<
                SelectDm += " ,BLGOODS.BLGROUPCODERF AS BLGOODS_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += " ,BLGOODS.GOODSRATEGRPCODERF AS BLGOODS_GOODSRATEGRPCODERF" + Environment.NewLine; // ADD caohh 2015/03/06 for Redmine#44951
                SelectDm += " ,BLGROUP.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += " ,BLGROUP.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;
                // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                ////-----ADD 2011/01/11----->>>>>
                //SelectDm += " , GOODSPRICE.PRICESTARTDATERF AS GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; ;// ���i�J�n��
                //SelectDm += " , GOODSPRICE.LISTPRICERF AS GOODSPRICE_LISTPRICERF" + Environment.NewLine; ;// �艿�i�����j
                ////-----ADD 2011/01/11-----<<<<<
                // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                SelectDm += " ,GOODSPRICEURF.CREATEDATETIMERF AS GPRICEU_CREATEDATETIMERF,GOODSPRICEURF.UPDATEDATETIMERF AS GPRICEU_UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.ENTERPRISECODERF AS GPRICEU_ENTERPRISECODERF,GOODSPRICEURF.FILEHEADERGUIDRF AS GPRICEU_FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.UPDEMPLOYEECODERF AS GPRICEU_UPDEMPLOYEECODERF,GOODSPRICEURF.UPDASSEMBLYID1RF AS GPRICEU_UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.UPDASSEMBLYID2RF AS GPRICEU_UPDASSEMBLYID2RF,GOODSPRICEURF.LOGICALDELETECODERF AS GPRICEU_LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.GOODSMAKERCDRF AS GPRICEU_GOODSMAKERCDRF,GOODSPRICEURF.GOODSNORF AS GPRICEU_GOODSNORF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.PRICESTARTDATERF AS GPRICEU_PRICESTARTDATERF,GOODSPRICEURF.LISTPRICERF AS GPRICEU_LISTPRICERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.SALESUNITCOSTRF AS GPRICEU_SALESUNITCOSTRF,GOODSPRICEURF.STOCKRATERF AS GPRICEU_STOCKRATERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.OPENPRICEDIVRF AS GPRICEU_OPENPRICEDIVRF,GOODSPRICEURF.OFFERDATERF AS GPRICEU_OFFERDATERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.UPDATEDATERF AS GPRICEU_UPDATEDATERF " + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                SelectDm += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<        
                //SelectDm += "FROM STOCKRF AS STK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "FROM STOCKRF AS STK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                // ���i
                //SelectDm += "INNER JOIN GOODSURF AS GOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "INNER JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON GOODS.ENTERPRISECODERF=STK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=STK.GOODSNORF" + Environment.NewLine;
                // BL�R�[�h 
                //SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                // BL�O���[�v
                //SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                int inventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                //SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                //SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                //SelectDm += " AND GOODSPRICE.PRICESTARTDATERF  <=" + inventoryDate.ToString() + Environment.NewLine;
                // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                //-----ADD 2011/01/11-----<<<<<
                // �C�� 2009/04/27 <<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                SelectDm += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND STK.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                SelectDm += " AND STK.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND STK.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                SelectDm += " AND STK.LOGICALDELETECODERF = RATE.LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                SelectDm += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                SelectDm += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                SelectDm += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                SelectDm += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                SelectDm += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                SelectDm += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                SelectDm += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                SelectDm += " AND STK.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND STK.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                SelectDm += " AND STK.LOGICALDELETECODERF = RATE2.LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                SelectDm += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                SelectDm += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                SelectDm += " LEFT JOIN GOODSPRICEURF WITH (READUNCOMMITTED)" + Environment.NewLine;
                SelectDm += " ON GOODSPRICEURF.ENTERPRISECODERF = STK.ENTERPRISECODERF AND GOODSPRICEURF.GOODSMAKERCDRF = STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODSPRICEURF.GOODSNORF = STK.GOODSNORF" + Environment.NewLine;
                SelectDm += " AND GOODSPRICEURF.PRICESTARTDATERF  <=" + inventoryDate.ToString() + Environment.NewLine;// ADD caohh 2015/03/06 for Redmine#44951
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<     

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 1);

                /* -- DEL wangf 2011/09/02 ---------->>>>>
                //----- ADD 2011/01/11----->>>>>
                // �Ǘ����_
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND STK.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }

                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED" + Environment.NewLine;
                    SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                    paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }
                //----- ADD 2011/01/11-----<<<<<
                // -- DEL wangf 2011/09/02 ----------<<<<<*/
                //----- ADD 2011/01/11----->>>>>
                // �Ǘ����_
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    if (inventoryExtCndtnWork.SectionCodeEd != "")
                    {
                        sqlCommand.CommandText += " AND ((STK.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlCommand.CommandText += " AND STK.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                    }
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    // �O��ʂ���̃p�����[�^�[�u�Ǘ����_�v���u0�v��⑫
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt.PadLeft(2, '0'));
                }
                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    int startIndex = 0;
                    // �p�����[�^�[�u�Ǘ����_�v>= 10�̏ꍇ
                    if (!'0'.Equals(inventoryExtCndtnWork.SectionCodeEd.PadLeft(2, '0').Trim().ToCharArray()[0]))
                    {
                        if (inventoryExtCndtnWork.SectionCodeSt.CompareTo("10") < 0)
                        {
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                sqlCommand.CommandText += " AND STK.SECTIONCODERF<='09'" + Environment.NewLine;
                            }
                            else
                            {
                                sqlCommand.CommandText += " AND ((STK.SECTIONCODERF<='09'" + Environment.NewLine;
                            }
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                startIndex = Convert.ToInt32(inventoryExtCndtnWork.SectionCodeSt.Trim());
                            }
                            // -- UPD 2012/06/14 ------------------------------------>>>>
                            #region DELETE ���_�R�[�h��0���߂ɂ��Ă��Ȃ���Q�̏C��
                            //sqlCommand.CommandText += "OR (STK.SECTIONCODERF IN ( 9";
                            //for (int i = startIndex; i < 9; i++)
                            //{
                            //    sqlCommand.CommandText += ", " + i;
                            //}
                            #endregion
                            sqlCommand.CommandText += "OR (STK.SECTIONCODERF IN ( N'09'";
                            for (int i = startIndex; i < 9; i++)
                            {
                                sqlCommand.CommandText += ", N'" + i.ToString("00") + "'";
                            }
                            // -- UPD 2012/06/14 ------------------------------------<<<<
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                sqlCommand.CommandText += "))) OR (STK.SECTIONCODERF >= '10' AND STK.SECTIONCODERF<=@SECTIONCODEED))";
                            }
                            else
                            {
                                sqlCommand.CommandText += "))) OR (STK.SECTIONCODERF >= '10' AND STK.SECTIONCODERF<=@SECTIONCODEED))";
                            }
                            SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                            paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                        }
                        else if (inventoryExtCndtnWork.SectionCodeSt.CompareTo("10") >= 0)
                        {
                            sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED))" + Environment.NewLine;
                            SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                            paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                        }
                    }
                    else
                    {
                        // -- UPD 2012/06/14 ------------------------------------>>>>
                        #region DELETE ���_�R�[�h��0���߂ɂ��Ă��Ȃ���Q�̏C��
                        //String sectionCodeValue = inventoryExtCndtnWork.SectionCodeEd.TrimStart('0');
                        ////�z�����@��F05~09 �i5,6,7,8,9�j
                        //if (inventoryExtCndtnWork.SectionCodeSt != "")
                        //{
                        //    if ('0'.Equals(inventoryExtCndtnWork.SectionCodeSt.PadLeft(2, '0').Trim().ToCharArray()[0]))
                        //    {
                        //        if (inventoryExtCndtnWork.SectionCodeSt != "")
                        //        {
                        //            startIndex = Convert.ToInt32(inventoryExtCndtnWork.SectionCodeSt.Trim());
                        //        }
                        //        for (int j = startIndex; j < Convert.ToInt32(inventoryExtCndtnWork.SectionCodeEd.Trim()); j++)
                        //        {
                        //            sectionCodeValue += "," + j;
                        //        }
                        //    }
                        //}
                        #endregion
                        String sectionCodeValue = "N'" + inventoryExtCndtnWork.SectionCodeEd + "'";
                        if (inventoryExtCndtnWork.SectionCodeSt != "")
                        {
                            if ('0'.Equals(inventoryExtCndtnWork.SectionCodeSt.PadLeft(2, '0').Trim().ToCharArray()[0]))
                            {
                                startIndex = Convert.ToInt32(inventoryExtCndtnWork.SectionCodeSt.Trim());
                                for (int j = startIndex; j < Convert.ToInt32(inventoryExtCndtnWork.SectionCodeEd.Trim()); j++)
                                {
                                    sectionCodeValue += ", N'" + j.ToString("00") + "'";
                                }
                            }
                        }
                        // -- UPD 2012/06/14 ------------------------------------<<<<
                        // DEL yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        //sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED) OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                        // DEL yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        if (!string.IsNullOrEmpty(sectionCodeValue))
                        {
                            // -- UPD 2012/06/14 ------------------------------------>>>>
                            //sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED) OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED) OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                            }
                            else
                            {
                                sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                            }
                            // -- UPD 2012/06/14 ------------------------------------<<<<
                        }
                        else
                        {
                            sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED " + Environment.NewLine;
                        }
                        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                        paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd.PadLeft(2, '0'));
                        if (inventoryExtCndtnWork.SectionCodeSt != "")
                        {
                            sqlCommand.CommandText += ")";
                        }
                    }
                }
                //----- ADD 2011/01/11-----<<<<<

                //�\�[�g�����ǉ�
                // �C�� 2008/09/18 >>>
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.LARGEGOODSGANRECODERF, STK.MEDIUMGOODSGANRECODERF, STK.DETAILGOODSGANRECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF";
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF";// DEL 2011/01/11
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF, GOODSPRICE.PRICESTARTDATERF";// ADD 2011/01/11
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF ASC, STK.GOODSMAKERCDRF ASC, STK.GOODSNORF ASC, GOODSPRICE.PRICESTARTDATERF DESC";// ADD 2011/02/12 //DEL 2012/04/09
                // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                //sqlCommand.CommandText += " ORDER BY STK.SECTIONCODERF ASC, STK.WAREHOUSECODERF ASC, STK.GOODSMAKERCDRF ASC, STK.GOODSNORF ASC, GOODSPRICE.PRICESTARTDATERF DESC";// ADD 2012/04/09
                sqlCommand.CommandText += " ORDER BY STK.SECTIONCODERF ASC, STK.WAREHOUSECODERF ASC, STK.GOODSMAKERCDRF ASC, STK.GOODSNORF ASC, GOODSPRICEURF.PRICESTARTDATERF DESC";
                // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                // �C�� 2008/09/18 <<<

                #endregion    // Selecet��

                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/21
                myReader = sqlCommand.ExecuteReader();
                //----- ADD 2011/01/11----->>>>>
                InventoryDataWork beInventoryDataWork = null;
                //----- ADD 2011/01/11-----<<<<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                GoodsSupplierDataWork beGoodsSupplierDataWork = null;
                UnitPriceCalcParamWork beUnitPriceCalcParamWork = null;
                GoodsUnitDataWork beGoodsUnitDataWork = null;
                GoodsPriceUWork beGoodsPriceUWork = null;

                GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                string enterpriseCode = "";
                DateTime priceStartDate = DateTime.MinValue;
                //�d�����z�����敪�}�X�^�ǂݍ���
                //List<StockProcMoneyWork> stockProcMoneyList = this.SearchStockProcMoney(inventoryExtCndtnWork.EnterpriseCode);// DEL 2013/06/07 wangl2 For Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();
                int status1 = unitPriceCalculation.SearchStockProcMoneyForInventory(inventoryExtCndtnWork.EnterpriseCode, out stockProcMoneyList);
                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status1;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                // ����ł̒[�������P�ʁA�[�������敪���擾
                double taxFractionProcUnit;
                int taxFractionProcCd;
                this.GetStockFractionProcInfo(1, 0, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);
                //List<RateProtyMngWork> rateProtyMngAllList = SearchRateProtyMng(inventoryExtCndtnWork.EnterpriseCode);// DEL 2013/06/07 wangl2 For Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
                status1 = unitPriceCalculation.SearchRateProtyMngForInventory(inventoryExtCndtnWork.EnterpriseCode, out rateProtyMngAllList);
                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status1;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<


                List<RateWork> rateList;
                List<UnitPriceCalculation.UnitPriceKind> unitPriceKindList = new List<UnitPriceCalculation.UnitPriceKind>();
                unitPriceKindList.Add(UnitPriceCalculation.UnitPriceKind.UnitCost);
                //unitPriceCalculation.SearchRateForInventory(inventoryExtCndtnWork.EnterpriseCode , out rateList);// DEL 2013/06/07 wangl2 For Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                //status1 = unitPriceCalculation.SearchRateForInventory(inventoryExtCndtnWork.EnterpriseCode, out rateList);
                status1 = unitPriceCalculation.SearchRateForInventory2(inventoryExtCndtnWork.EnterpriseCode, out rateList);
                // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                {
                    if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status1;
                    }
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //���_�{���[�J�[�{�i��
                Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //���_�{�����ށ{���[�J�[�{�a�k
                Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //���_�{�����ށ{���[�J�[
                Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //���_�{���[�J�[

                goodsSupplierGetter.GetGoodsMngInfo(inventoryExtCndtnWork.EnterpriseCode,ref goodsMngDic1,ref goodsMngDic2,ref goodsMngDic3,ref goodsMngDic4);
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                //string goodsNo = string.Empty;// DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή�
                string keyValue = string.Empty;
                RateWork rateAllSec = null;
                // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                while (myReader.Read())
                {

                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    // ADD 2009/04/27 >>>
                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                    GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g
                    goodsPriceUWork = new GoodsPriceUWork();      //ADD yangyi 2013/05/06 Redmine#35493
                    // ADD 2009/04/27 <<<

                    #region �I���f�[�^�l�Z�b�g
                    wkInventoryDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));           // ��ƃR�[�h
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));                 // ���_�R�[�h
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSECODERF"));             // �q�ɃR�[�h
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));                // ���[�J�[�R�[�h
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));                         // ���i�R�[�h
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSESHELFNORF"));       // �I��
                    wkInventoryDataWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO1RF")); // �d���I��1
                    // --- ADD 2009/11/30 ---------->>>>>
                    wkInventoryDataWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO2RF")); // �d���I��2
                    // --- ADD 2009/11/30 ----------<<<<<
                    wkInventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// ���Е��ރR�[�h
                    wkInventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));                // ���i�}�X�^�EBL�R�[�h
                    wkInventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // ���i�}�X�^�EJAN�R�[�h
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));       // �d���P��
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));     // �ύX�O�d���P��
                    wkInventoryDataWork.StkUnitPriceChgFlg = 0;                                                                                         // �d���P���ύX�t���O 0:�� 1:���� 
                    wkInventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_STOCKDIVRF"));                        // �݌ɋ敪 0:���� 1:���
                    wkInventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STK_LASTSTOCKDATERF")); // �ŏI�d���N����
                    wkInventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SUPPLIERSTOCKRF"));                // ���됔
                    wkInventoryDataWork.ShipCustomerCode = 0;                                                                                           // �o�ד��Ӑ�R�[�h
                    wkInventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // �I������������
                    wkInventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // �I��������������
                    // ADD 2009/05/22 >>>
                    wkInventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // �ŏI�I���X�V�� 
                    wkInventoryDataWork.ToleranceUpdateCd = 0; // �ߕs���X�V�敪
                    wkInventoryDataWork.StockTotalExec = 0;    // �݌ɑ���(���{��)
                    // ADD 2009/05/22 <<<
                    wkInventoryDataWork.InventoryNewDiv = 0;                                                                                            // �I���V�K�ǉ��敪 0:�����쐬 1:�V�K�쐬

                    wkInventoryDataWork.StockMashinePrice = Convert.ToInt64(wkInventoryDataWork.StockUnitPriceFl * wkInventoryDataWork.StockTotal);�@ // �}�V���݌Ɋz
                    // ADD 2009.01.30 >>>
                    wkInventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // ���i�啪�ރR�[�h  
                    wkInventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // ���i�����ރR�[�h
                    wkInventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_BLGROUPCODERF"));              // BL�O���[�v�R�[�h  
                    // ADD 2009.01.30 <<<

                    // --- ADD 2009/11/30 ---------->>>>>
                    wkInventoryDataWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_ARRIVALCNTRF"));               // ���א��i���v��j
                    wkInventoryDataWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SHIPMENTCNTRF"));              // �o�א��i���v��j
                    wkInventoryDataWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_MOVINGSUPLISTOCKRF"));         // �ړ����d���݌ɐ�
                    // --- ADD 2009/11/30 ----------<<<<<

                    wkInventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); // ADD 2011/01/11
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                    //wkInventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF")); // ADD 2011/01/11
                    convertDoubleRelease.EnterpriseCode = wkInventoryDataWork.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = wkInventoryDataWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = wkInventoryDataWork.GoodsNo;
                    // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));
                    // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

                    // �ϊ��������s
                    convertDoubleRelease.ReleaseProc();

                    wkInventoryDataWork.ListPriceFl = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<

                    // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    //----- ADD 2011/01/11----->>>>>
                    //if (beInventoryDataWork != null)
                    //{
                    //    if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                    //        && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                    //        && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                    //        && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                    //        && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                    //        && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                    //        && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd)
                    //    {
                    //        continue;
                    //    }
                    //}
                    //beInventoryDataWork = wkInventoryDataWork;
                    ////----- ADD 2011/01/11-----<<<<<

                    //al.Add(wkInventoryDataWork);
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                    #endregion    // �I���f�[�^�l�Z�b�g

                    // ADD 2009/04/24 >>>
                    #region ���i�d���擾�f�[�^�N���X
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));// ��ƃR�[�h
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));      // ���_�R�[�h
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));              // ���i�ԍ�
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));     // BL�R�[�h
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // ���i�����ރR�[�h
                    //GoodsSupplierDataWorkList.Add(goodsSupplierDataWork); //DEL yangyi 2013/05/06 Redmine#35493
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    goodsMngDic1 = goodsMngDic1 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic1;
                    goodsMngDic2 = goodsMngDic2 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic2;
                    goodsMngDic3 = goodsMngDic3 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic3;
                    goodsMngDic4 = goodsMngDic4 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic4;
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<
                    goodsSupplierGetter.GetSupplierInfo(ref goodsSupplierDataWork, goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4); //ADD yangyi 2013/05/06 Redmine#35493
                    #endregion

                    #region �P���Z�o���W���[���v�Z�p�p�����[�^
                    unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));   // ���_�R�[�h
                    unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));  // ���[�J�[�R�[�h
                    unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));           // ���i�ԍ�
                    //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));�@ // ���i�����ރR�[�h// DEL caohh 2015/03/06 for Redmine#44951
                    unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_GOODSRATEGRPCODERF"));�@ // ���i�|���O���[�v�R�[�h// ADD caohh 2015/03/06 for Redmine#44951
                    unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_BLGROUPCODERF"));// BL�O���[�v�R�[�h
                    unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));  // BL�R�[�h
                    //unitPriceCalcParam.PriceApplyDate = DateTime.Now;// DEL caohh 2015/03/06 for Redmine#44951
                    unitPriceCalcParam.PriceApplyDate = inventoryExtCndtnWork.InventoryDate;  // ADD caohh 2015/03/06 for Redmine#44951
                    // --- ADD 2009/11/30 ---------->>>>>
                    unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSRATERANKRF"));  // �w��
                    // --- ADD 2009/11/30 ----------<<<<<
                    //unitPriceCalcParamList.Add(unitPriceCalcParam);  //DEL yangyi 2013/05/06 Redmine#35493
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    unitPriceCalcParam.SupplierCd = goodsSupplierDataWork.SupplierCd;
                    if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParam.SupplierCd))
                    {
                        unitPriceCalcParam.StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParam.SupplierCd].StockUnPrcFrcProcCd;
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                    #endregion

                    #region ���i�A���f�[�^���X�g
                    goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));// ��ƃR�[�h
                    goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));              // ���i�ԍ�
                    goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                    //goodsUnitDataList.Add(goodsUnitData);  //DEL yangyi 2013/05/06 Redmine#35493
                    #endregion
                    // ADD 2009/04/24 <<<

                    // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    enterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_ENTERPRISECODERF"));
                    if (enterpriseCode != null && enterpriseCode != "")
                    {
                        priceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_PRICESTARTDATERF"));
                        if (priceStartDate < DateTime.Now)
                        {
                            if (priceStartDate > goodsPriceUWork.PriceStartDate)
                            {
                                goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_CREATEDATETIMERF"));
                                goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATETIMERF"));
                                goodsPriceUWork.EnterpriseCode = enterpriseCode;
                                goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GPRICEU_FILEHEADERGUIDRF"));
                                goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDEMPLOYEECODERF"));
                                goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID1RF"));
                                goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID2RF"));
                                goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_LOGICALDELETECODERF"));
                                goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_GOODSMAKERCDRF"));
                                goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_GOODSNORF"));
                                goodsPriceUWork.PriceStartDate = priceStartDate;
                                //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                                //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));
                                convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                                convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                                convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));

                                // �ϊ��������s
                                convertDoubleRelease.ReleaseProc();

                                goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                                //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                                goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_SALESUNITCOSTRF"));
                                goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_STOCKRATERF"));
                                goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_OPENPRICEDIVRF"));
                                goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_OFFERDATERF"));
                                goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATERF"));
                            }
                        }
                        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                        // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //// �����i�̉��i���ݒ�̏ꍇ�A�P�i�|���̉��i�A�d�������Z�b�g����
                        //if ((goodsPriceUWork.SalesUnitCost == 0) && ((goodsPriceUWork.StockRate == 0 || goodsPriceUWork.ListPrice == 0)))
                        //{
                        //    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                        //    if (goodsPriceUWork.LogicalDeleteCode == 0)
                        //    {
                        //        goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                        //    }
                        //}
                        // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

                        #region �P�i�|�����X�g
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // ���[�J�[�R�[�h
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));           // ���i�ԍ�
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        //���_���P�i�|��
                        keyValue = string.Format(ctDicKeyFmt, wkInventoryDataWork.SectionCode.Trim(), wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //�����i�̋��_���P�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //�S�ВP�i������ꍇ�A�P�idic�ɒǉ�
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));

                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    }
                    #region del
                    // �������R�[�h����ꍇ�͍ŏ��̃��R�[�h�ł͂Ȃ��Ō�̃��R�[�h�����X�g�ɒǉ�����悤�ɕύX
                    //if (beInventoryDataWork != null)
                    //{
                    //    if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                    //        && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                    //        && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                    //        && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                    //        && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                    //        && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                    //        && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd)
                    //    {
                    //        continue;
                    //    }
                    //}
                    #endregion

                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                            && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                            && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd)
                        {
                            if (goodsPriceUWork.EnterpriseCode != "" )
                            {
                                if (beGoodsPriceUWork  == null || goodsPriceUWork.PriceStartDate > beGoodsPriceUWork.PriceStartDate) // ADD 2012/09/03 yangyi
                                {
                                    beGoodsPriceUWork = goodsPriceUWork;
                                }

                            }

                            // 1���R�[�h�O�Ɠ����������ꍇ
                            continue; // ���� 
                        }
                    }
                    else
                    {
                        // BeforeData
                        beInventoryDataWork = wkInventoryDataWork;
                        beGoodsSupplierDataWork = goodsSupplierDataWork;
                        beUnitPriceCalcParamWork = unitPriceCalcParam;
                        beGoodsUnitDataWork = goodsUnitData;
                        beGoodsPriceUWork = goodsPriceUWork;
                        continue;
                    }

                    // 1���R�[�h�O�ƕς�����ꍇ�ABeforeData�����X�g�ɒǉ�
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);
                    unitPriceCalcParamList.Add(beUnitPriceCalcParamWork);
                    goodsUnitDataList.Add(beGoodsUnitDataWork);

                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //unitPriceCalculation.CalculateUnitCostPrice(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                    //    , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList);
                    unitPriceCalculation.CalculateUnitCostPrice2(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                        , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList, rateWorkByGoodsNoDic);
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

                    // ���݂̃��R�[�h��BeforeData�ɃZ�b�g
                    beInventoryDataWork = wkInventoryDataWork;
                    beGoodsSupplierDataWork = goodsSupplierDataWork;
                    beUnitPriceCalcParamWork = unitPriceCalcParam;
                    beGoodsUnitDataWork = goodsUnitData;
                    if (goodsPriceUWork.EnterpriseCode != "")
                    {
                        beGoodsPriceUWork = goodsPriceUWork;
                    }
                    else
                    {
                        beGoodsPriceUWork = null;
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                if (!myReader.IsClosed) myReader.Close();
                #endregion    // ���Ѝ݌Ɏ擾�N�G��

                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                // �Ō��BeforeData�����X�g�ɒǉ�����
                if (beInventoryDataWork != null)
                {
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);
                    unitPriceCalcParamList.Add(beUnitPriceCalcParamWork);
                    goodsUnitDataList.Add(beGoodsUnitDataWork);
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //unitPriceCalculation.CalculateUnitCostPrice(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                    //    , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList);
                    unitPriceCalculation.CalculateUnitCostPrice2(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                        , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList, rateWorkByGoodsNoDic);
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                #endregion    // ���Ѝ݌Ɏ擾�N�G��

                // ADD 2009/04/27 >>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�d������擾���� ���s
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region ���i�d������擾���� ���ʃZ�b�g
                    //���i�d������擾�����ɂ��擾�����d�����
                    //�P���Z�o�p�����[�^�E�I���f�[�^���[�N�ɃZ�b�g
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                    {
                        //-- UPD 2012/05/21 ------------------------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v���폜�A�z��ԍ��ŕR�t����悤�ɂ���B
                        //for (int j = 0; j < unitPriceCalcParamList.Count; j++) // �P���Z�o���W���[���v�Z�p�p�����[�^
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            // -- UPD 2012/04/09 ----------------------------------->>>>
                        //            //unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g

                        //            //���i�Ǘ����00�S�ЂŁA�P�����W���[���Ɏd���悪�Z�b�g����ĂȂ��Ȃ�A�Z�b�g����
                        //            if (GoodsSupplierDataWorkList[i].SectionCode.Trim() == "00")
                        //            {
                        //                if (unitPriceCalcParamList[j].SupplierCd == 0)
                        //                {
                        //                    unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //                }
                        //            }
                        //            //���i�Ǘ���񂪑S�ЈȊO�A�P�����W���[���̋��_�R�[�h������Ȃ�A�d������Z�b�g����B
                        //            else if (GoodsSupplierDataWorkList[i].SectionCode == unitPriceCalcParamList[j].SectionCode)
                        //            {
                        //                unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //            }
                        //            // -- UPD 2012/04/09 -----------------------------------<<<<
                        //        }
                        //    }
                        //}

                        //for (int j = 0; j < al.Count; j++) // �I���f�[�^���[�N
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // ���i�ԍ�
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL���i�R�[�h
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            // -- UPD 2012/04/09 ----------------------------------->>>>
                        //            //al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g

                        //            //���i�Ǘ����00�S�ЂŁA�I���f�[�^�Ɏd���悪�Z�b�g����ĂȂ��Ȃ�A�Z�b�g����B
                        //            if (GoodsSupplierDataWorkList[i].SectionCode.Trim() == "00")
                        //            {
                        //                if (al[j].SupplierCd == 0)
                        //                {
                        //                    al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //                }
                        //            }
                        //            //���i�Ǘ���񂪑S�ЈȊO�A�I���f�[�^�̋��_�R�[�h������Ȃ�A�d������Z�b�g����B
                        //            else if (GoodsSupplierDataWorkList[i].SectionCode == al[j].SectionCode)
                        //            {
                        //                al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                        //            }
                        //            // -- UPD 2012/04/09 -----------------------------------<<<<
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[i].GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[i].GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[i].BLGoodsCode) &&   // BL���i�R�[�h
                            (GoodsSupplierDataWorkList[i].GoodsMakerCd == al[i].GoodsMakerCd) && // ���i���[�J�[
                            (GoodsSupplierDataWorkList[i].GoodsNo == al[i].GoodsNo) &&           // ���i�ԍ�
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == al[i].BLGoodsCode))     // BL���i�R�[�h
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                unitPriceCalcParamList[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;

                                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� ----->>>>>
                                if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParamList[i].SupplierCd))
                                {
                                    unitPriceCalcParamList[i].StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParamList[i].SupplierCd].StockUnPrcFrcProcCd;
                                }
                                // ADD 2013/03/06 zhoug For Redmine#34756�Ή��F�I���������� -----<<<<<
                                al[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                            }
                        }
                        else
                        {
                            throw new Exception("���i�Ǘ����ƒI���f�[�^�̕R�t�����s���ł��B�i�݌Ƀ}�X�^���������j" +
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                unitPriceCalcParamList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcParamList[i].GoodsNo.ToString() + " : " +
                                                al[i].GoodsMakerCd.ToString() + ", " +
                                                al[i].GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------------------------<<<<
                    }
                    #endregion

                    //�����Z�o���� ���s
                    //unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//DEL 2012/07/10 for Redmine#31103

                    // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    // ���X�g���񂵂Ȃ���GoodsPriceU���擾���镔�����폜
                    //unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//ADD 2012/07/10 for Redmine#31103
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                    #region �����Z�o���� ���ʃZ�b�g
                    // �����Z�o�����ɂ��擾����������
                    // �݌ɗ����f�[�^�N���X�ɃZ�b�g
                    for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                    {
                        // -- UPD 2012/04/09 ------------------------------------------------>>>>
                        #region DEL ���ʃ��[�v�폜�A�z��ԍ��ŕR�t����悤�ύX����
                        //for (int j = 0; j < al.Count; j++) // �I���f�[�^�N���X
                        //{
                        //    if ((unitPriceCalcRetList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // ���i���[�J�[
                        //        (unitPriceCalcRetList[i].GoodsNo == al[j].GoodsNo))     // BL���i�R�[�h
                        //    {
                        //        if (al[j].StockUnitPriceFl == 0)
                        //        {
                        //            // �d���P��
                        //            al[j].StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //            // �ύX�O�d���P��
                        //            al[j].BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                        //        }
                        //        // ADD 2009/05/11 >>>
                        //        // --- UPD 2009/11/30 ---------->>>>>
                        //        // �����p�v�Z����
                        //        //al[j].AdjstCalcCost = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //        double adjstCalcCost = 0;
                        //        FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                        //        al[j].AdjstCalcCost = adjstCalcCost;
                        //        // --- UPD 2009/11/30 ----------<<<<<
                        //        // ADD 2009/05/11 <<<
                        //    }
                        //}
                        #endregion
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == al[i].GoodsMakerCd) && // ���i���[�J�[
                            (unitPriceCalcRetList[i].GoodsNo == al[i].GoodsNo))     // BL���i�R�[�h
                        {
                            if (al[i].StockUnitPriceFl == 0)
                            {
                                // �d���P��
                                al[i].StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                // �ύX�O�d���P��
                                al[i].BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                            }
                            // �����p�v�Z����
                            double adjstCalcCost = 0;
                            FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                            al[i].AdjstCalcCost = adjstCalcCost;
                        }
                        else
                        {
                            throw new Exception("�����Z�o���ʂƒI���f�[�^�̕R�t�����s���ł��B�i�݌Ƀ}�X�^���������j" +
                                                i.ToString() + " : " +
                                                unitPriceCalcRetList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcRetList[i].GoodsNo.ToString() + " : " +
                                                al[i].GoodsMakerCd.ToString() + ", " +
                                                al[i].GoodsNo.ToString());
                        }
                        // -- UPD 2012/04/09 ------------------------------------------------<<<<
                    }
                    #endregion

                    #region �d����R�[�h���o����
                    for (int i = 0; i < al.Count; i++) // �I���f�[�^���[�N
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= al[i].SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= al[i].SupplierCd))
                        {
                            wkList.Add(al[i]);
                        }
                    }
                    #endregion
                    al = wkList;

                }
                // ADD 2009/04/27 <<< 
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachProductStock Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (sqlCommand2 != null) sqlCommand2.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (myReader2 != null && !myReader2.IsClosed) myReader2.Close();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion  // �݌Ƀ}�X�^��������

        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /*
        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// �|���D��Ǘ�����
        /// </summary>
        private List<RateProtyMngWork> SearchRateProtyMng(string _enterpriseCode)
        {
            List<RateProtyMngWork> _rateProtyMngAllList = new List<RateProtyMngWork>();

            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();

            ArrayList paralist = new ArrayList();
            RateProtyMngWork paraWork = new RateProtyMngWork();
            paraWork.EnterpriseCode = _enterpriseCode;

            paralist.Add(paraWork);

            object rateProtyMngWorkList = null;

            //�|���D��Ǘ��̓ǂݍ���
            rateProtyMngDB.Search(out rateProtyMngWorkList, paralist, 0, 0);

            if (rateProtyMngWorkList != null)
            {
                ArrayList list = rateProtyMngWorkList as ArrayList;

                _rateProtyMngAllList = new List<RateProtyMngWork>();
                _rateProtyMngAllList.AddRange((RateProtyMngWork[])list.ToArray(typeof(RateProtyMngWork)));

                // ���_�A�P����ށA�D�揇�ʂŃ\�[�g
                _rateProtyMngAllList.Sort(new FractionProcMoney.RateProtyMngComparer());
            }
            return _rateProtyMngAllList;
        }
        */
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        #region SearchStockProcMoney
        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /*
        /// <summary>
        /// �d�����z�[�������敪�ݒ茟��
        /// </summary>
        private List<StockProcMoneyWork> SearchStockProcMoney(string _enterpriseCode)
        {
            List<StockProcMoneyWork> _stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = _enterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            int status = stockProcMoneyDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                _stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                _stockProcMoneyList.Sort(new FractionProcMoney.StockProcMoneyComparer());
            }

            return _stockProcMoneyList;
        }
        */ 
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
        #endregion

        #region GetStockFractionProcInfo

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="_stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = FractionProcMoney.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = FractionProcMoney.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if ((stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (stockProcMoney.FractionProcCode == fractionProcCode) &&
                                                (stockProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }

        #endregion

        #region UnitPrcCalcDiv

        /// <summary>
        /// �P���Z�o���@
        /// </summary>
        public enum UnitPrcCalcDiv
        {
            /// <summary>�P�����ڎw��</summary>
            Price = 0,
            /// <summary>�|��</summary>
            RateVal = 1,
            /// <summary>UP��</summary>
            UpRate = 2,
            /// <summary>�e����</summary>
            GrsProfitSecureRate = 3,
        }

        #endregion

        ///// <summary>
        ///// �|���D��Ǘ����̃��X�g���擾���܂��B
        ///// <br>UpdateNote : Redmine#31103�I�����������̑��x���ǂ̑Ή�</br>
        ///// <br>Programer  : ������</br>
        ///// <br>Date       : 2012/07/10</br>
        ///// </summary>
        ///// <returns></returns>
        ////private List<RateProtyMngWork> GetRateProtyMngList(string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//DEL on 2012/07/10 for Redmine#31103
        //private List<RateProtyMngWork> GetRateProtyMngList(List<RateProtyMngWork> _rateProtyMngAllList, string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//ADD  on 2012/07/10 for Redmine#31103
        //{
        //    //----DEL on 2012/07/10 for Redmine#31103 ------->>>>>>
        //    ////�D��Ǘ��ǂݍ���
        //    //List<RateProtyMngWork> _rateProtyMngAllList =  SearchRateProtyMng(_enterpriseCode);
        //    //----DEL on 2012/07/10 for Redmine#31103 -------<<<<<<

        //    if (_rateProtyMngAllList == null || _rateProtyMngAllList.Count == 0) return null;

        //    // �Ώۋ��_���̗D��Ǘ����擾
        //    List<RateProtyMngWork> _lastRateProtyMngList = _rateProtyMngAllList.FindAll(
        //                                                            delegate(RateProtyMngWork rateProtyMng)
        //                                                            {
        //                                                                if ((rateProtyMng.SectionCode.Trim() == sectionCode.Trim()) &&
        //                                                                    (rateProtyMng.UnitPriceKind == (int)unitPriceKind))
        //                                                                {
        //                                                                    return true;
        //                                                                }
        //                                                                else
        //                                                                {
        //                                                                    return false;
        //                                                                }
        //                                                            });
        //    if (sectionCode.Trim() != "00")
        //    {
        //        // �S�Аݒ蕪��ǉ�
        //        _lastRateProtyMngList.AddRange(_rateProtyMngAllList.FindAll(
        //            delegate(RateProtyMngWork rateProtyMng)
        //            {
        //                if ((rateProtyMng.SectionCode.Trim() == "00") &&
        //                    (rateProtyMng.UnitPriceKind == (int)unitPriceKind))
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }));
        //    }

        //    return _lastRateProtyMngList;

        //}
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        #region �݌ɐ��Z�o����
        /// <summary>
        /// �݌ɐ��Z�o����
        /// �݌ɗ����f�[�^�A�݌Ɏ󕥗����f�[�^����I�����̃}�V���݌ɐ����Z�o����B
        /// 
        /// </summary>
        /// <param name="al"></param>
        /// <param name="inventoryExtCndtnWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTrans"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        private int CalcStockTotal(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // -----------UPD 2010/02/20------------>>>>>
            //int lastAddUpYearMonth = 0;
            //int lastAddUpDate = 0;
            DateTime lastAddUpDate = DateTime.MinValue;
            double stockUnitPriceFl = 0.0;
            double stockTotal = 0.0;
            double arrivalCnt = 0.0;
            double shipmentCnt = 0.0;
            InventoryDataWork ivtDataWork = null;

            //for (int i = 0; i < al.Count; i++)
            //{
            //    ivtDataWork = al[i];
            //    GetStockHistoryData(ivtDataWork, ref lastAddUpYearMonth, ref lastAddUpDate, ref stockUnitPriceFl, ref stockTotal, ref sqlConnection, ref sqlTrans);
            //    //GetLastAddUpDate(inventoryExtCndtnWork, lastAddUpYearMonth, ref lastAddUpDate, ref sqlConnection, ref sqlTrans);// DEL 2009/04/27
            //    GetStockAcPayHistData(ivtDataWork, lastAddUpDate, inventoryExtCndtnWork.InventoryDate, ref arrivalCnt, ref shipmentCnt, ref sqlConnection, ref sqlTrans);
            //    // --- UPD 2009/11/30 ---------->>>>>
            //    //al[i].StockTotal = stockTotal + arrivalCnt - shipmentCnt;
            //    if (inventoryExtCndtnWork.InventoryMngDiv == 0)
            //    {
            //        al[i].StockTotal = stockTotal + arrivalCnt - shipmentCnt;
            //    }
            //    else if (inventoryExtCndtnWork.InventoryMngDiv == 1)
            //    {
            //        //�I���f�[�^.�݌ɑ����ցu�݌Ƀ}�X�^.�d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�| �ړ����d���݌ɐ��v���Z�b�g
            //        al[i].StockTotal = al[i].StockTotal + al[i].ArrivalCnt - al[i].ShipmentCnt - al[i].MovingSupliStock;
            //    }
            //    // --- UPD 2009/11/30 ----------<<<<<

            //    al[i].InventoryDate = inventoryExtCndtnWork.InventoryDate;
            //    // �}�V���݌Ɋz
            //    al[i].StockMashinePrice = Convert.ToInt64(al[i].StockUnitPriceFl * al[i].StockTotal);

            //}

            // �݌ɗ����f�[�^
            Dictionary<string, StockHistoryWork> stockHistWorkDic = new Dictionary<string, StockHistoryWork>();
            // �݌Ɏ󕥗����f�[�^
            List<StockAcPayHistWork> stockAcpayHistWorkList = new List<StockAcPayHistWork>();

            if (al.Count > 0)
            {
                ivtDataWork = al[0];
                if (inventoryExtCndtnWork.InventoryMngDiv == 0)//ADD 2012/07/10 for Redmine#31103
                {//ADD 2012/07/10
                    // �݌ɗ����f�[�^�S������
                    status = GetStockHistoryDataAll(ref stockHistWorkDic, ivtDataWork, ref sqlConnection, ref sqlTrans);

                    // �݌Ɏ󕥗����f�[�^�S������
                    status = GetStockAcPayHistDataAll(ref stockAcpayHistWorkList, ivtDataWork, ref sqlConnection, ref sqlTrans);
                }//ADD 2012/07/10
                for (int i = 0; i < al.Count; i++)
                {
                    ivtDataWork = al[i];
                    //-----2011/01/11----->>>>>
                    //-----UPD 2011/01/28----->>>>>
                    //if ("���޼".Equals(ivtDataWork.WarehouseShelfNo) || ("���޼".Equals(ivtDataWork.WarehouseShelfNo)))
                    if (("���޼".Equals(ivtDataWork.WarehouseShelfNo) && ((ivtDataWork.GoodsNo.Contains(".") || ivtDataWork.GoodsNo.Contains("*"))))
                        || ("���޼".Equals(ivtDataWork.WarehouseShelfNo) && ((ivtDataWork.GoodsNo.Contains(".") || ivtDataWork.GoodsNo.Contains("*")))))
                    //-----UPD 2011/01/28-----<<<<<
                    {
                        continue;
                    }
                    //-----2011/01/11-----<<<<<
                    if (inventoryExtCndtnWork.InventoryMngDiv == 0)//ADD 2012/07/10 for Redmine#31103
                    {//ADD 2012/07/10
                        GetStockHistoryData2(stockHistWorkDic, ivtDataWork, ref lastAddUpDate, ref stockUnitPriceFl, ref stockTotal);
                        GetStockAcPayHistData2(stockAcpayHistWorkList, ivtDataWork, lastAddUpDate, inventoryExtCndtnWork.InventoryDate, ref arrivalCnt, ref shipmentCnt);
                    }//ADD 2012/07/10
                    if (inventoryExtCndtnWork.InventoryMngDiv == 0)
                    {
                        al[i].StockTotal = stockTotal + arrivalCnt - shipmentCnt;
                    }
                    else if (inventoryExtCndtnWork.InventoryMngDiv == 1)
                    {
                        //�I���f�[�^.�݌ɑ����ցu�݌Ƀ}�X�^.�d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�| �ړ����d���݌ɐ��v���Z�b�g
                        al[i].StockTotal = al[i].StockTotal + al[i].ArrivalCnt - al[i].ShipmentCnt - al[i].MovingSupliStock;
                    }


                    al[i].InventoryDate = inventoryExtCndtnWork.InventoryDate;
                    // �}�V���݌Ɋz
                    al[i].StockMashinePrice = Convert.ToInt64(al[i].StockUnitPriceFl * al[i].StockTotal);
                }
            }
            // --- UPD 2010/02/20 ----------<<<<<


            return status;
        }
        #endregion  // �݌ɐ��Z�o����

        #region �O�񌎎��X�V���擾
        private int GetLastAddUpDate(InventoryExtCndtnWork inventoryExtCndtnWork, int lastAddUpYearMonth, ref int lastAddUpDate,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            int monthAddUpYearMonth = 0;

            lastAddUpDate = 0;

            try
            {
                string sText = "";

                //sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF "; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
                sText += "AND LOGICALDELETECODERF=0 ";
                sText += "AND PROCDIVCDRF=0 ";
                sText += "AND HISTCTLCDRF=0 ";
                sText += "AND MONTHADDUPYEARMONTHRF = @MONTHADDUPYEARMONTH ";// �ǉ�2009/04/27
                sText += "ORDER BY MONTHADDUPYEARMONTHRF DESC ";

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    monthAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
                    if (monthAddUpYearMonth == lastAddUpYearMonth)
                    {
                        lastAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                        break;
                    }
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetLastAddUpDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;

        }
        #endregion // �O�񌎎��X�V���擾

        #region �݌ɗ����f�[�^����
        /// <summary>
        /// �݌ɗ����f�[�^����
        /// </summary>
        /// <param name="ivtDataWork"></param>
        /// <param name="addUpYearMonth"></param>
        /// <param name="stockTotal"></param>
        /// <returns></returns>
        private int GetStockHistoryData(InventoryDataWork ivtDataWork,
            ref int lastAddUpYearMonth, ref int lastAddUpDate, ref double stockUnitPriceFl, ref double stockTotal,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string sText = "";
                // �C�� 2009/04/27 >>>
                //sText += "SELECT TOP 1 ADDUPYEARMONTHRF, STOCKUNITPRICEFLRF, STOCKTOTALRF FROM STOCKHISTORYRF ";
                //sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
                //sText += "AND LOGICALDELETECODERF=0 ";
                //sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
                //sText += "AND SECTIONCODERF=@SECTIONCODE ";
                //sText += "AND GOODSNORF=@GOODSNO ";
                //sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";
                //sText += "ORDER BY ADDUPYEARMONTHRF DESC ";               
                sText += "SELECT TOP 1  " + Environment.NewLine;
                sText += " STOCKHIS.ADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKTOTALRF " + Environment.NewLine;
                sText += " ,ADDUPHIS.MONTHLYADDUPDATERF" + Environment.NewLine;
                //sText += "FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                //sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += " ON STOCKHIS.ENTERPRISECODERF = ADDUPHIS.ENTERPRISECODERF" + Environment.NewLine;
                sText += " AND STOCKHIS.ADDUPYEARMONTHRF = ADDUPHIS.MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " AND ADDUPHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.PROCDIVCDRF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.HISTCTLCDRF=0" + Environment.NewLine;
                sText += "WHERE STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND STOCKHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND STOCKHIS.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                //sText += " AND STOCKHIS.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine; // DEL 2009/05/11 
                sText += " AND STOCKHIS.GOODSNORF=@GOODSNO" + Environment.NewLine;
                sText += " AND STOCKHIS.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sText += "ORDER BY ADDUPYEARMONTHRF DESC" + Environment.NewLine;

                /// �C�� 2009/04/27 <<<

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/05/11
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.WarehouseCode);
                //paraSectionCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.SectionCode); // DEL 2009/05/11
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(ivtDataWork.GoodsNo);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(ivtDataWork.GoodsMakerCd);

                lastAddUpYearMonth = 0;
                stockUnitPriceFl = 0.0;
                stockTotal = 0.0;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    lastAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")); // �v��N��
                    lastAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));    // �v��N����  // ADD 2009/04/27
                    stockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));// �d���P���i�Ŕ��C�����j
                    stockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));            // �݌ɑ���
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockHistoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion  // �݌ɗ����f�[�^����

        #region �݌ɗ����f�[�^�S������
        /// <summary>
        /// �݌ɗ����f�[�^�S������
        /// </summary>
        /// <param name="stockHisDic">�݌ɗ����f�[�^</param>
        /// <param name="ivtDataWork">�I���f�[�^Work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: �݌ɗ����f�[�^�S���������s�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private int GetStockHistoryDataAll(ref Dictionary<string, StockHistoryWork> stockHisDic, InventoryDataWork ivtDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string sText = "";
                sText += "SELECT" + Environment.NewLine;
                sText += " STOCKHIS.ADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKTOTALRF " + Environment.NewLine;
                sText += " ,STOCKHIS.WAREHOUSECODERF " + Environment.NewLine;
                sText += " ,STOCKHIS.GOODSNORF " + Environment.NewLine;
                sText += " ,STOCKHIS.GOODSMAKERCDRF " + Environment.NewLine;
                sText += " ,ADDUPHIS.MONTHLYADDUPDATERF" + Environment.NewLine;
                //sText += "FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                //sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += " ON STOCKHIS.ENTERPRISECODERF = ADDUPHIS.ENTERPRISECODERF" + Environment.NewLine;
                sText += " AND STOCKHIS.ADDUPYEARMONTHRF = ADDUPHIS.MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " AND ADDUPHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.PROCDIVCDRF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.HISTCTLCDRF=0" + Environment.NewLine;
                sText += "WHERE STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND STOCKHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += "ORDER BY ADDUPYEARMONTHRF DESC" + Environment.NewLine;

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockHistoryWork work = new StockHistoryWork();

                    #region �N���X�֊i�[
                    work.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    work.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                    work.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    work.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    work.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    work.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    work.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));

                    string key = work.WarehouseCode + "-" + work.GoodsNo + "-" + work.GoodsMakerCd;
                    if (!stockHisDic.ContainsKey(key))
                    {
                        stockHisDic.Add(key, work);
                    }

                    #endregion
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockHistoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// �݌ɗ����f�[�^����
        /// </summary>
        /// <param name="dic">�݌Ɏ󕥗����f�[�^Dic</param>
        /// <param name="ivtDataWork">�I���f�[�^Work</param>
        /// <param name="lastAddUpDate">�v��N��</param>
        /// <param name="stockUnitPriceFl">�d���P��</param>
        /// <param name="stockTotal">�݌ɑ���</param>
        /// <remarks>
        /// <br>Note		: �݌ɗ����f�[�^�������s�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private void GetStockHistoryData2(Dictionary<string, StockHistoryWork> dic, InventoryDataWork ivtDataWork,
            ref DateTime lastAddUpDate, ref double stockUnitPriceFl, ref double stockTotal)
        {
            string tempKey = ivtDataWork.WarehouseCode + "-" + ivtDataWork.GoodsNo + "-" + ivtDataWork.GoodsMakerCd.ToString();
            lastAddUpDate = DateTime.MinValue;
            stockUnitPriceFl = 0.0;
            stockTotal = 0;
            if (dic.ContainsKey(tempKey))
            {
                StockHistoryWork work = (StockHistoryWork)dic[tempKey];
                lastAddUpDate = work.AddUpADate;
                stockUnitPriceFl = work.StockUnitPriceFl;
                stockTotal = work.StockTotal;
            }
        }
        #endregion  // �݌ɗ����f�[�^�S������

        #region �݌Ɏ󕥗����f�[�^����
        private int GetStockAcPayHistData(InventoryDataWork ivtDataWork, int lastAddUpDate, DateTime inventoryDate,
            ref double arrivalCnt, ref double shipmentCnt,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            string sText = "";

            sText += "SELECT SUM(ARRIVALCNTRF) AS S_ARRIVALCNTRF, ";
            sText += "SUM(SHIPMENTCNTRF) AS S_SHIPMENTCNTRF ";
            //sText += "FROM STOCKACPAYHISTRF "; // DEL wangf 2012/03/23 FOR Redmine#29109
            sText += "FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
            sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
            sText += "AND LOGICALDELETECODERF=0 ";
            // �C�� 2009/07/06 >>>
            //sText += "AND IOGOODSDAYRF>@LASTADDUPDATE ";
            //sText += "AND IOGOODSDAYRF<=@INVENTORYDATE ";
            sText += "AND   (  (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)>@LASTADDUPDATE ";
            sText += "      AND (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)<=@INVENTORYDATE )";
            // �C�� 2009/07/06 <<<
            sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
            //sText += "AND SECTIONCODERF=@SECTIONCODE "; // DEL 2009/05/11
            sText += "AND GOODSNORF=@GOODSNO ";
            sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";
            sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraLastAddUpDate = sqlCommand.Parameters.Add("@LASTADDUPDATE", SqlDbType.Int);
            SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/05/11
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);
            paraLastAddUpDate.Value = SqlDataMediator.SqlSetInt32(lastAddUpDate);
            paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDate);
            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.WarehouseCode);
            //paraSectionCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.SectionCode); // DEL 2009/05/11
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(ivtDataWork.GoodsNo);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(ivtDataWork.GoodsMakerCd);


            try
            {
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    arrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_ARRIVALCNTRF"));
                    shipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_SHIPMENTCNTRF"));
                }
                else
                {
                    arrivalCnt = 0.0;
                    shipmentCnt = 0.0;
                }
                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockAcPayHistData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion  // �݌Ɏ󕥗����f�[�^����

        #region �݌Ɏ󕥗����f�[�^�S������
        /// <summary>
        /// �݌Ɏ󕥗����f�[�^�S������
        /// </summary>
        /// <param name="stockAcPayHistWorkList">�݌ɗ����f�[�^</param>
        /// <param name="ivtDataWork">�I���f�[�^Work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: �݌Ɏ󕥗����f�[�^�S���������s�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private int GetStockAcPayHistDataAll(ref List<StockAcPayHistWork> stockAcPayHistWorkList, InventoryDataWork ivtDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            string sText = "";
            sText += "SELECT ARRIVALCNTRF, SHIPMENTCNTRF, WAREHOUSECODERF, GOODSNORF, GOODSMAKERCDRF,";
            sText += " CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END AS ADDUPADATEIOGOODSDAY ";
            //sText += "FROM STOCKACPAYHISTRF "; // DEL wangf 2012/03/23 FOR Redmine#29109
            sText += "FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
            sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
            sText += "AND LOGICALDELETECODERF=0 ";

            sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);

            try
            {
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();

                    #region �N���X�֊i�[
                    stockAcPayHistWork.AddUpADateIoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATEIOGOODSDAY"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    #endregion

                    stockAcPayHistWorkList.Add(stockAcPayHistWork);
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockAcPayHistData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// �݌Ɏ󕥗����f�[�^����
        /// </summary>
        /// <param name="dic">stockAcpayHistWorkList</param>
        /// <param name="ivtDataWork">�I���f�[�^Work</param>
        /// <param name="lastAddUpDate">�v��N��</param>
        /// <param name="targetDate">�I����</param>
        /// <param name="arrivalCnt">���א�</param>
        /// <param name="shipmentCnt">�o�א�</param>
        /// <remarks>
        /// <br>Note		: �݌Ɏ󕥗����f�[�^�������s�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private void GetStockAcPayHistData2(List<StockAcPayHistWork> stockAcpayHistWorkList, InventoryDataWork ivtDataWork, DateTime lastAddUpDate,
                            DateTime targetDate, ref double arrivalCnt, ref double shipmentCnt)
        {
            arrivalCnt = 0.0;
            shipmentCnt = 0.0;

            List<StockAcPayHistWork> newList = stockAcpayHistWorkList.FindAll(
                delegate(StockAcPayHistWork stockAcPayHistWork)
                {
                    if (stockAcPayHistWork.WarehouseCode == ivtDataWork.WarehouseCode
                        && stockAcPayHistWork.GoodsNo == ivtDataWork.GoodsNo
                        && stockAcPayHistWork.GoodsMakerCd.Equals(ivtDataWork.GoodsMakerCd)
                        && (stockAcPayHistWork.AddUpADateIoGoodsDay > lastAddUpDate
                             && stockAcPayHistWork.AddUpADateIoGoodsDay <= targetDate)
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                );

            // ���א��Əo�א��̎擾
            foreach (StockAcPayHistWork work in newList)
            {
                arrivalCnt += work.ArrivalCnt;
                shipmentCnt += work.ShipmentCnt;
            }
        }
        #endregion  // �݌Ɏ󕥗����f�[�^�S������

        #region �I���f�[�^��������
        /// <summary>
        /// �I���f�[�^���������A�I���f�[�^Dictionary��߂��܂�
        /// </summary>
        /// <param name="dic">�I���f�[�^Dictionary</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^Dictionary��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        //#private int SeachInventoryData(out Dictionary<Guid,InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        private int SeachInventoryData(out Dictionary<String, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            //#dic = new Dictionary<Guid, InventoryDataWork>();
            dic = new Dictionary<String, InventoryDataWork>();

            try
            {
                string SelectDm = "";
                SelectDm += "SELECT";

                //���ʎ擾
                SelectDm += " IVD.SECTIONCODERF  IVD_SECTIONCODERF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.GOODSMAKERCDRF  IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF  IVD_GOODSNORF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.STOCKUNITPRICEFLRF  IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF  IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";

                #region  �ύX�O(MA.NS)
                /*
                SelectDm += " IVD.PRODUCTSTOCKGUIDRF IVD_PRODUCTSTOCKGUIDRF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.STOCKTELNO1RF IVD_STOCKTELNO1RF";
                SelectDm += ", IVD.BFSTOCKTELNO1RF IVD_BFSTOCKTELNO1RF";
                SelectDm += ", IVD.STKTELNO1CHGFLGRF IVD_STKTELNO1CHGFLGRF";
                SelectDm += ", IVD.STOCKTELNO2RF IVD_STOCKTELNO2RF";
                SelectDm += ", IVD.BFSTOCKTELNO2RF IVD_BFSTOCKTELNO2RF";
                SelectDm += ", IVD.STKTELNO2CHGFLGRF IVD_STKTELNO2CHGFLGRF";
                SelectDm += ", IVD.STOCKUNITPRICERF IVD_STOCKUNITPRICERF";
                SelectDm += ", IVD.BFSTOCKUNITPRICERF IVD_BFSTOCKUNITPRICERF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";
                */
                #endregion  // �ύX�O(MA.NS)

                //SelectDm += " FROM INVENTORYDATARF IVD"; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM INVENTORYDATARF IVD WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 2);

                string Key = "";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    #region �I���f�[�^�l�Z�b�g
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                    wkInventoryDataWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                    // �C�� 2009/05/22 >>>
                    //Key = KeyofDic(wkInventoryDataWork.WarehouseCode, wkInventoryDataWork.WarehouseShelfNo, 
                    //               wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                    Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                                   wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                    // �C�� 2009/05/22 <<<
                    if (!dic.ContainsKey(Key))
                    {
                        dic.Add(Key, wkInventoryDataWork);
                    }

                    #region  �ύX�O(MA.NS)
                    /*
                    wkInventoryDataWork.ProductStockGuid     = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("IVD_PRODUCTSTOCKGUIDRF"));
                    wkInventoryDataWork.InventorySeqNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockTelNo1          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_STOCKTELNO1RF"));
                    wkInventoryDataWork.BfStockTelNo1        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_BFSTOCKTELNO1RF"));
                    wkInventoryDataWork.StkTelNo1ChgFlg      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKTELNO1CHGFLGRF"));
                    wkInventoryDataWork.StockTelNo2          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_STOCKTELNO2RF"));
                    wkInventoryDataWork.BfStockTelNo2        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_BFSTOCKTELNO2RF"));
                    wkInventoryDataWork.StkTelNo2ChgFlg      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKTELNO2CHGFLGRF"));
                    wkInventoryDataWork.StockUnitPrice       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICERF"));
                    wkInventoryDataWork.BfStockUnitPrice     = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICERF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt    = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                    if (!dic.ContainsKey(wkInventoryDataWork.ProductStockGuid))
                    {
                        dic.Add(wkInventoryDataWork.ProductStockGuid, wkInventoryDataWork);
                    }
                    */
                    #endregion  // �ύX�O(MA.NS)
                    #endregion  // �I���f�[�^�l�Z�b�g
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                //#if (!myReader.IsClosed) myReader.Close();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion  // �I���f�[�^��������

        #region �I���f�[�^�폜����
        /// <summary>
        /// �I���f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="inventoryExtCndtnWork">�I�����������I�u�W�F�N�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        //#private int DeleteInventoryData(InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, ConstantManagement.LogicalMode logicalMode, List<InventoryDataWork> al, Dictionary<Guid, InventoryDataWork> dic)
        private int DeleteInventoryData(InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, ConstantManagement.LogicalMode logicalMode, List<InventoryDataWork> al, Dictionary<String, InventoryDataWork> dic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlCommand sqlCommand = null;

            Dictionary<string, InventoryDataWork> skipDic = new Dictionary<string, InventoryDataWork>();
            // -------UPD 2009/11/30------->>>>>
            //SkipSearch(out skipDic, al, dic);
            foreach (InventoryDataWork skipInventoryDataWork in dic.Values)
            {
                if (!skipDic.ContainsKey(skipInventoryDataWork.WarehouseCode))
                {
                    skipDic.Add(skipInventoryDataWork.WarehouseCode, skipInventoryDataWork);
                }
            }
            // -------UPD 2009/11/30-------<<<<<

            try
            {
                string SelectDm = "";
                SelectDm += "DELETE FROM INVENTORYDATARF";

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 3);

                if (skipDic.Count > 0)
                {
                    int skipDicCount = 0;
                    // --- ADD 2009/11/30 ---------->>>>>
                    sqlCommand.CommandText += " AND (";
                    // --- ADD 2009/11/30 ----------<<<<<

                    foreach (InventoryDataWork skipInventoryDataWork in skipDic.Values)
                    {
                        // --- UPD 2009/11/30 ---------->>>>>
                        // �C�� 2009/05/22 >>>
                        //sqlCommand.CommandText += " AND (" GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " OR GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";
                        //sqlCommand.CommandText += " AND (WAREHOUSECODERF != @WAREHOUSECODE" + skipDicCount.ToString() + " AND  GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " AND GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";
                        // �C�� 2009/05/22 <<<

                        if (skipDicCount == 0)
                        {
                            sqlCommand.CommandText += " WAREHOUSECODERF = @WAREHOUSECODE" + skipDicCount.ToString();
                        }
                        else
                        {
                            sqlCommand.CommandText += " OR WAREHOUSECODERF = @WAREHOUSECODE" + skipDicCount.ToString();
                        }
                        // --- UPD 2009/11/30 ----------<<<<<

                        // --- DEL 2009/11/30 ---------->>>>>
                        //SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + skipDicCount.ToString(), SqlDbType.NVarChar);
                        //SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + skipDicCount.ToString(), SqlDbType.Int);
                        // --- DEL 2009/11/30 ----------<<<<<
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE" + skipDicCount.ToString(), SqlDbType.NVarChar); // ADD 2009/05/22

                        // --- DEL 2009/11/30 ---------->>>>>
                        //paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(skipInventoryDataWork.GoodsMakerCd);
                        //paraGoodsNo.Value = SqlDataMediator.SqlSetString(skipInventoryDataWork.GoodsNo);
                        // --- DEL 2009/11/30 ----------<<<<<
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(skipInventoryDataWork.WarehouseCode); // ADD 2009/05/22

                        #region  �ύX�O(MA.NS)
                        /*
                        sqlCommand.CommandText += " AND (MAKERCODERF!=@MAKERCODE" + skipDicCount.ToString() + " OR GOODSCODERF!=@GOODSCODE" + skipDicCount.ToString() + ")";

                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE" + skipDicCount.ToString(), SqlDbType.Int);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(skipInventoryDataWork.MakerCode);
                        SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@GOODSCODE" + skipDicCount.ToString(), SqlDbType.NVarChar);
                        paraGoodsCode.Value = SqlDataMediator.SqlSetString(skipInventoryDataWork.GoodsCode);
                        */
                        #endregion  // �ύX�O(MA.NS)
                        skipDicCount++;
                    }

                    // --- ADD 2009/11/30 ---------->>>>>
                    sqlCommand.CommandText += ")";
                    // --- ADD 2009/11/30 ----------<<<<<
                }

                //sqlCommand.CommandText += " AND (LASTINVENTORYUPDATERF IS NULL OR LASTINVENTORYUPDATERF=10101) "; // DEL 2009/05/22 


                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.DeleteInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion  // �I���f�[�^�폜����

        #region SkipSearch
        /// <summary>
        /// �I���֘A��\�����ڌ���
        /// </summary>
        /// <param name="skipDic">�I���}�X�^����</param>
        /// <param name="_inventInputSearchCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���}�X�^�̔�\�����ڂ��擾����N���X�ł��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.24</br>
        //#private void SkipSearch(out Dictionary<string, InventoryDataWork> skipDic, List<InventoryDataWork> al, Dictionary<Guid, InventoryDataWork> dic)
        private void SkipSearch(out Dictionary<string, InventoryDataWork> skipDic, List<InventoryDataWork> al, Dictionary<String, InventoryDataWork> dic)
        {
            skipDic = new Dictionary<string, InventoryDataWork>();
            string Key = "";

            if (dic != null)
            {
                foreach (InventoryDataWork wkInventoryDataWork in dic.Values)
                {
                    if ((wkInventoryDataWork.LastInventoryUpdate != null) && (wkInventoryDataWork.LastInventoryUpdate != DateTime.MinValue))
                    {
                        for (int iCnt = 0; iCnt < al.Count; iCnt++)
                        {
                            InventoryDataWork skipInventoryDataWork = al[iCnt] as InventoryDataWork;

                            if (skipInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode &&
                                //skipInventoryDataWork.WarehouseShelfNo == wkInventoryDataWork.WarehouseShelfNo && // DEL 2009/05/22
                                skipInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd &&
                                skipInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo)
                            {
                                wkInventoryDataWork.GoodsMakerCd = skipInventoryDataWork.GoodsMakerCd;
                                wkInventoryDataWork.GoodsNo = skipInventoryDataWork.GoodsNo;
                                // �C�� 2009/05/22 >>>
                                //Key = KeyofDic(wkInventoryDataWork.WarehouseCode, wkInventoryDataWork.WarehouseShelfNo,
                                //               wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                                Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                                               wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                                // �C�� 2009/05/22 <<<
                                if (!skipDic.ContainsKey(Key))
                                {
                                    skipDic.Add(Key, wkInventoryDataWork);
                                }
                                break;
                            }

                            #region  �ύX�O(MA.NS)
                            /*
                            if (skipInventoryDataWork.ProductStockGuid == wkInventoryDataWork.ProductStockGuid)
                            {
                                wkInventoryDataWork.MakerCode = skipInventoryDataWork.MakerCode;
                                wkInventoryDataWork.GoodsCode = skipInventoryDataWork.GoodsCode;

                                if (!skipDic.ContainsKey(wkInventoryDataWork.MakerCode.ToString() + "-" + wkInventoryDataWork.GoodsCode.ToString()))
                                {
                                    skipDic.Add(wkInventoryDataWork.MakerCode.ToString() + "-" + wkInventoryDataWork.GoodsCode.ToString(), wkInventoryDataWork);
                                }
                                break;
                            }
                            */
                            #endregion  // �ύX�O(MA.NS)
                        }
                    }
                }
            }
        }
        #endregion  // SkipSearch

        #region �I���f�[�^�o�^����
        /// <summary>
        /// �I���f�[�^List����I���f�[�^�֍X�V�A�o�^���s���܂�
        /// </summary>
        /// <param name="al">�I���f�[�^List</param>
        /// <param name="dic">�I���f�[�^Dictionary</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^List����I���f�[�^�֍X�V�A�o�^���s���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note: 2011/01/11 yangmj �I����Q�Ή�</br>
        //#private int WriteInventoryData(List<InventoryDataWork> al, Dictionary<Guid, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        private int WriteInventoryData(List<InventoryDataWork> al, Dictionary<String, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int MaxInventorySeqCount;
            //----ADD 2012/07/10 for Redmine#31103------>>>>>>
            Dictionary<String, int> inventorySeqsDic = new Dictionary<String, int>();
            //----ADD 2012/07/10 for Redmine#31103------<<<<<<
            string Key = "";
            try
            {
                // --- UPD 2009/11/30 ---------->>>>>
                //GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans); //DEL 2009/11/30
                al.Sort(new InventoryDataWorkComparer(inventoryExtCndtnWork.InvntryPrtOdrIniDiv));
                // --- UPD 2009/11/30 ----------<<<<<

                // �C�� 2009/05/22 >>>
                //if ((inventoryExtCndtnWork.InventoryProcDiv == 0) || (inventoryExtCndtnWork.InventoryProcDiv == 2))
                if ((inventoryExtCndtnWork.InventoryProcDiv == 0)) //����i�Ԃ��I���f�[�^�ɂ���� ���������Ώۂɂ��Ȃ�
                // �C�� 2009/05/22 <<<
                {
                    Dictionary<string, InventoryDataWork> skipDic = new Dictionary<string, InventoryDataWork>();
                    SkipSearch(out skipDic, al, dic);

                    #region �I���f�[�^�o�^ (���o�����݌Ƀ}�X�^���)
                    for (int iCnt = 0; iCnt < al.Count; iCnt++)
                    {
                        InventoryDataWork inventoryDataWork = al[iCnt] as InventoryDataWork;

                        // --- ADD 2009/11/30 ---------->>>>>
                        //GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans); //DEL 2012/07/10 for Redmine#31103
                        // --- ADD 2009/11/30 ----------<<<<<
                        // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                        //----ADD 2012/07/10 for Redmine#31103------>>>>>>
                        //if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        //{
                        //    GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                        //    inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount);
                        //}
                        //else
                        //{
                        //    MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode] + 1;
                        //    inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount;
                        //}
                        //----ADD 2012/07/10 for Redmine#31103------<<<<<<
                        // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                        // InventoryProcDiv = 0 ( �č쐬�@�I�����͐��N���A) �Ȃ̂ŒI�����͐����c���Ȃ�

                        //$-- 2007.09.27 �ǉ� >>>>>>>>
                        if (inventoryExtCndtnWork.InventoryProcDiv == 0)
                        {
                            if (dic != null)
                            {
                                // �C�� 2009/05/22 >>>
                                //Key = KeyofDic(inventoryDataWork.WarehouseCode, inventoryDataWork.WarehouseShelfNo,
                                //               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);
                                Key = KeyofDic(inventoryDataWork.WarehouseCode,
                                               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);

                                // �C�� 2009/05/22 <<<
                                if (dic.ContainsKey(Key))
                                {
                                    // �o�^���悤�Ƃ���I���f�[�^�Ɠ��ꏤ�i�����ɒI���f�[�^�e�[�u���ɂ���ꍇ
                                    continue;
                                }
                            }
                        }
                        //$-- 2007.09.27 �ǉ� <<<<<<<<

                        if (dic != null)
                        {
                            MergeInventoryDate(ref inventoryDataWork, dic, inventoryExtCndtnWork, skipDic);
                            if (inventoryDataWork == null)
                            {
                                continue;
                            }
                        }
                        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                        if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        {
                            GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                            inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount + 1);
                        }
                        else
                        {
                            MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode];
                            inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount + 1;
                        }
                        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                        //�V�K�쐬����SQL���𐶐�
                        //-----ADD 2011/01/11----->>>>>
                        //SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF, TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF) "
                        //    + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC,@TOLERANCEUPDATECD,@ADJSTCALCCOST)", sqlConnection, sqlTrans);
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF, TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF, GOODSNAMERF,LISTPRICEFLRF) "
                            + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC,@TOLERANCEUPDATECD,@ADJSTCALCCOST,@GOODSNAME,@LISTPRICEFL)", sqlConnection, sqlTrans);
                        //-----ADD 2011/01/11-----<<<<<

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventoryDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float); // ADD 2009/05/22 
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/11
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/01/11
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float); // ADD 2011/01/11
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.LogicalDeleteCode);

                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCode); // ���_�R�[�h
                        //paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + iCnt + 1); // �I���ʔ� DEL 2009/11/30
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + 1); // �I���ʔ� ADD 2009/11/30
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseCode); // �q�ɃR�[�h
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMakerCd);    // ���[�J�[�R�[�h
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsNo);             // �i��
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseShelfNo); // �I��
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo1); // �d���I��1
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo2); // �d���I��2
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsLGroup); // �啪��
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMGroup); // ������
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGroupCode); // BL�O���[�v�R�[�h
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.EnterpriseGanreCode); // ���Е��ރR�[�h
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGoodsCode); // BL�R�[�h
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.SupplierCd);   // �d����R�[�h
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataWork.Jan);                // JAN�R�[�h
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockUnitPriceFl); // �d���P��(����)
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.BfStockUnitPriceFl);// �ύX�O�d���P��
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StkUnitPriceChgFlg); // �d���P���ύX�t���O
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StockDiv);                     // �݌ɋ敪
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastStockDate); // �ŏI�d���N����
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotal);               // �݌ɑ���
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ShipCustomerCode);    // �o�ד��Ӑ�R�[�h(���g�p����)
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryStockCnt); // �I������
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryTolerancCnt); // �I���ߕs����
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryPreprDay);    // �I�������������t
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryPreprTim);                   // �I��������������
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDay);              // �I������
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastInventoryUpdate);// �ŏI�I���X�V��
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryTlrncPrice);
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotalExec); // ADD 2009/05/22
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ToleranceUpdateCd);
                        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.AdjstCalcCost); // ADD 2009/05/11 
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsName); // ADD 2011/01/11
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.ListPriceFl); // ADD 2011/01/11

                        //�ʔԑΉ��ۗ��i�ꊇ�ŒʔԂ�ݒ肷�邱�Ƃ��o���Ȃ��ׁj
                        //SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        //if (inventoryDataWork.InventorySeqNo == 0)
                        //{
                        //    MaxInventorySeqCount++;
                        //    paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount);
                        //}
                        //else
                        //{
                        //    paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventorySeqNo);
                        //}
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion

                }
                else if (inventoryExtCndtnWork.InventoryProcDiv == 1)
                {
                    Dictionary<string, InventoryDataWork> skipDic = new Dictionary<string, InventoryDataWork>();
                    SkipSearch(out skipDic, al, dic);

                    #region �I���f�[�^�o�^ (���o�����݌Ƀ}�X�^���)
                    for (int iCnt = 0; iCnt < al.Count; iCnt++)
                    {
                        InventoryDataWork inventoryDataWork = al[iCnt] as InventoryDataWork;

                        // --- ADD 2009/11/30 ---------->>>>>
                        //GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);//DEL 2012/07/10 for Redmine#31103
                        // --- ADD 2009/11/30 ----------<<<<<
                        //----ADD 2012/07/10 for Redmine#31103------>>>>>>
                        //---- DEL yangyi 2012/09/03 ------>>>>>>
                        //if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        //{
                        //    GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                        //    inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount);
                        //}
                        //else
                        //{
                        //    MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode] + 1;
                        //    inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount;
                        //}
                        //----DEL yangyi 2012/09/03 ------<<<<<
                        //----ADD 2012/07/10 for Redmine#31103------<<<<<<<
                        if (dic != null)
                        {
                            MergeInventoryDate(ref inventoryDataWork, dic, inventoryExtCndtnWork, skipDic);
                            if (inventoryDataWork == null)
                            {
                                continue;
                            }
                        }

                        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                        if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        {
                            GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                            inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount + 1);
                        }
                        else
                        {
                            MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode];
                            inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount + 1;
                        }
                        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                        //�V�K�쐬����SQL���𐶐�
                        //-----ADD 2011/01/11----->>>>>
                        //SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF,TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF) "
                        //    + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC, @TOLERANCEUPDATECD,@ADJSTCALCCOST)", sqlConnection, sqlTrans);
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF, TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF, GOODSNAMERF,LISTPRICEFLRF) "
                            + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC,@TOLERANCEUPDATECD,@ADJSTCALCCOST,@GOODSNAME,@LISTPRICEFL)", sqlConnection, sqlTrans);
                        //-----ADD 2011/01/11-----<<<<<

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventoryDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float); // ADD 2009/05/22 
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/11
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/01/11
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float); // ADD 2011/01/11

                        #endregion  // Parameter�I�u�W�F�N�g�̍쐬

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCode);
                        //paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + iCnt + 1); // DEL 2009/11/30
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + 1); // �I���ʔ� ADD 2009/11/30
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsNo);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo2);
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsLGroup);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGroupCode);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.EnterpriseGanreCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.SupplierCd);
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataWork.Jan);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.BfStockUnitPriceFl);
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StkUnitPriceChgFlg);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StockDiv);
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastStockDate);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotal);
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ShipCustomerCode);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryStockCnt);
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryTolerancCnt);
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryPreprDay);
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryPreprTim);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDay);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastInventoryUpdate);
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryTlrncPrice);
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotalExec); // ADD 2009/05/22
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ToleranceUpdateCd);
                        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.AdjstCalcCost); // ADD 2009/05/11 
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsName); // ADD 2011/01/11
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.ListPriceFl); // ADD 2011/01/11

                        #endregion  // Parameter�I�u�W�F�N�g�֒l�ݒ�

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.WriteInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            return status;
        }
        #region �ʔԍŏI�ԍ��擾
        /// <summary>
        /// �I�������f�[�^���̒ʔԍŏI�ԍ���߂��܂�
        /// </summary>
        /// <param name="MaxInventorySeqCount">�ʔԍŏI�ԍ�</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <param name="inventoryDataWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�������f�[�^���̒ʔԍŏI�ԍ���߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        private int GetMaxInventorySeq(out int MaxInventorySeqCount, InventoryExtCndtnWork inventoryExtCndtnWork, InventoryDataWork inventoryDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            MaxInventorySeqCount = 0;
            try
            {
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(INVENTORYSEQNORF) INVENTORYSEQNO_MAX FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTrans));               
                // ADD 2008/09/18 >>>
                string sText = "";
                sText = "SELECT MAX(INVENTORYSEQNORF) ";
                sText += "INVENTORYSEQNO_MAX ";
                //sText += " FROM INVENTORYDATARF"; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += " FROM INVENTORYDATARF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                //sText += " AND SECTIONCODERF=@FINDSECTIONCODE"; // DEL 2008.12.02
                sText += " AND WAREHOUSECODERF=@FINDWAREHOUSECODERF"; // ADD 2009/11/30
                using (SqlCommand sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans))
                // ADD 2008/09/18 <<<
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // DEL 2008.12.02
                    SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODERF", SqlDbType.NChar); // ADD 2009/11/30

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCode); // DEL 2008.12.02
                    findWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseCode); // ADD 2009/11/30

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        MaxInventorySeqCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNO_MAX"));
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetMaxInventorySeq Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //#if (!myReader.IsClosed) myReader.Close();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region �}�[�W����
        /// <summary>
        /// ���������O�̒I���f�[�^�Ƃ̃}�[�W���s���܂�
        /// </summary>
        /// <param name="inventoryDataWork">�I���f�[�^Work</param>
        /// <param name="dic">�I���f�[�^Dictionary</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������O�̒I���f�[�^�Ƃ̃}�[�W���s���܂��i�����敪�ɂ���ď������e�ύX�j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        //#private int MergeInventoryDate(ref InventoryDataWork inventoryDataWork, Dictionary<Guid, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, Dictionary<string, InventoryDataWork> skipDic)
        private int MergeInventoryDate(ref InventoryDataWork inventoryDataWork, Dictionary<String, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, Dictionary<string, InventoryDataWork> skipDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string Key = "";

            if (inventoryExtCndtnWork.InventoryProcDiv == 1)
            {
                // �C�� 2009/05/22 >>>
                //Key = KeyofDic(inventoryDataWork.WarehouseCode, inventoryDataWork.WarehouseShelfNo,
                //               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);
                Key = KeyofDic(inventoryDataWork.WarehouseCode,
                               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);
                // �C�� 2009/05/22 <<<

                if (dic.ContainsKey(Key))
                {
                    InventoryDataWork wkInventoryDataWork = (InventoryDataWork)dic[Key];

                    inventoryDataWork.InventorySeqNo = wkInventoryDataWork.InventorySeqNo;
                    inventoryDataWork.StockUnitPriceFl = wkInventoryDataWork.StockUnitPriceFl;
                    inventoryDataWork.BfStockUnitPriceFl = wkInventoryDataWork.BfStockUnitPriceFl;
                    inventoryDataWork.StkUnitPriceChgFlg = wkInventoryDataWork.StkUnitPriceChgFlg;
                    inventoryDataWork.InventoryStockCnt = wkInventoryDataWork.InventoryStockCnt;
                    inventoryDataWork.InventoryTolerancCnt = wkInventoryDataWork.InventoryTolerancCnt;
                    inventoryDataWork.InventoryDay = wkInventoryDataWork.InventoryDay;
                    inventoryDataWork.LastInventoryUpdate = wkInventoryDataWork.LastInventoryUpdate;
                }

                if (skipDic.Count > 0)
                {
                    foreach (InventoryDataWork skipInventoryDataWork in skipDic.Values)
                    {
                        if ((inventoryDataWork.GoodsMakerCd == skipInventoryDataWork.GoodsMakerCd) && (inventoryDataWork.GoodsNo == skipInventoryDataWork.GoodsNo))
                        {
                            inventoryDataWork = null;
                            break;
                        }
                    }
                }
            }

            #region  �ύX�O(MA.NS)
            /*
            if (inventoryExtCndtnWork.InventoryProcDiv == 1)
            {
                if (dic.ContainsKey(inventoryDataWork.ProductStockGuid))
                {
                    InventoryDataWork wkInventoryDataWork = (InventoryDataWork)dic[inventoryDataWork.ProductStockGuid];

                    //inventoryDataWork.InventorySeqNo = wkInventoryDataWork.InventorySeqNo;
                    //inventoryDataWork.StockTelNo1 = wkInventoryDataWork.StockTelNo1;
                    //inventoryDataWork.BfStockTelNo1 = wkInventoryDataWork.BfStockTelNo1;
                    //inventoryDataWork.StkTelNo1ChgFlg = wkInventoryDataWork.StkTelNo1ChgFlg;
                    //inventoryDataWork.StockTelNo2 = wkInventoryDataWork.StockTelNo2;
                    //inventoryDataWork.BfStockTelNo2 = wkInventoryDataWork.BfStockTelNo2;
                    //inventoryDataWork.StkTelNo2ChgFlg = wkInventoryDataWork.StkTelNo2ChgFlg;
                    //inventoryDataWork.StockUnitPrice = wkInventoryDataWork.StockUnitPrice;
                    //inventoryDataWork.BfStockUnitPrice = wkInventoryDataWork.BfStockUnitPrice;
                    //inventoryDataWork.StkUnitPriceChgFlg = wkInventoryDataWork.StkUnitPriceChgFlg;
                    inventoryDataWork.InventoryStockCnt = wkInventoryDataWork.InventoryStockCnt;
                    inventoryDataWork.InventoryTolerancCnt = wkInventoryDataWork.InventoryTolerancCnt;
                    inventoryDataWork.InventoryDay = wkInventoryDataWork.InventoryDay;
                    inventoryDataWork.LastInventoryUpdate = wkInventoryDataWork.LastInventoryUpdate;
                }

                if (skipDic.Count > 0)
                {
                    foreach (InventoryDataWork skipInventoryDataWork in skipDic.Values)
                    {
                        if ((inventoryDataWork.MakerCode == skipInventoryDataWork.MakerCode) && (inventoryDataWork.GoodsCode == skipInventoryDataWork.GoodsCode))
                        {
                            inventoryDataWork = null;
                            break;
                        }
                    }
                }
            }
            */
            #endregion  // �ύX�O(MA.NS)

            return status;
        }
        #endregion
        #endregion  // �I���f�[�^�o�^����

        #region �I���f�[�^�i�������������j�o�^����
        /// <summary>
        /// �I���f�[�^�i�������������j��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="inventDataPreWork">InventDataPreWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�i�������������j��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        private int WriteInventDataPre(ref InventDataPreWork inventDataPreWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���

                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ", sqlConnection, sqlTrans))
                {
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventoryPreprDay = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter findParaInventoryPreprTim = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRTIM", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != inventDataPreWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (inventDataPreWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed) myReader.Close();
                            return status;
                        }
                        // �C�� 2008/09/18  >>>
                        //sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET  UPDATEDATETIMERF=@UPDATEDATETIME, FILEHEADERGUIDRF=@FILEHEADERGUID, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1, UPDASSEMBLYID2RF=@UPDASSEMBLYID2, LOGICALDELETECODERF=@LOGICALDELETECODE, SECTIONCODERF=@SECTIONCODE, INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY, INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM, INVENTORYPROCDIVRF=@INVENTORYPROCDIV, WAREHOUSECODESTRF=@WAREHOUSECODEST, WAREHOUSECODEEDRF=@WAREHOUSECODEED, SHELFNOSTRF=@SHELFNOST, SHELFNOEDRF=@SHELFNOED, STARTSUPPLIERCODERF=@STARTSUPPLIERCODE, ENDSUPPLIERCODERF=@ENDSUPPLIERCODE, BLGOODSCODESTRF=@BLGOODSCODEST, BLGOODSCODEEDRF=@BLGOODSCODEED, GOODSMAKERCDSTRF=@GOODSMAKERCDST, GOODSMAKERCDEDRF=@GOODSMAKERCDED, LGGOODSGANRECDSTRF=@LGGOODSGANRECDST, LGGOODSGANRECDEDRF=@LGGOODSGANRECDED, MDGOODSGANRECDSTRF=@MDGOODSGANRECDST, MDGOODSGANRECDEDRF=@MDGOODSGANRECDED, DTLGOODSGANRECDSTRF=@DTLGOODSGANRECDST, DTLGOODSGANRECDEDRF=@DTLGOODSGANRECDED, ENTERPRISEGANRECDSTRF=@ENTERPRISEGANRECDST, ENTERPRISEGANRECDEDRF=@ENTERPRISEGANRECDED, CMPSTKEXTRADIVRF=@CMPSTKEXTRADIV, TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV, ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV, ENTTRTSTKEXTRADIVRF=@ENTTRTSTKEXTRADIV, LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST, LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED, SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1, SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2, SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3, SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4, SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5, SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6, SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7, SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8, SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9, SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10, INVENTORYDATERF=@INVENTORYDATE "  
                        //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";

                        // -------UPD 2011/01/30------->>>>>
                        //sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYPROCDIVRF=@INVENTORYPROCDIV , WAREHOUSECODESTRF=@WAREHOUSECODEST , WAREHOUSECODEEDRF=@WAREHOUSECODEED , SHELFNOSTRF=@SHELFNOST , SHELFNOEDRF=@SHELFNOED , STARTSUPPLIERCODERF=@STARTSUPPLIERCODE , ENDSUPPLIERCODERF=@ENDSUPPLIERCODE , BLGOODSCODESTRF=@BLGOODSCODEST , BLGOODSCODEEDRF=@BLGOODSCODEED , GOODSMAKERCDSTRF=@GOODSMAKERCDST , GOODSMAKERCDEDRF=@GOODSMAKERCDED , BLGROUPCODESTRF=@BLGROUPCODEST , BLGROUPCODEEDRF=@BLGROUPCODEED , TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV , ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV , LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST , LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED , SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1 , SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2 , SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3 , SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4 , SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5 , SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6 , SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7 , SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8 , SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9 , SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10 , INVENTORYDATERF=@INVENTORYDATE"
                        //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";
                        sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYPROCDIVRF=@INVENTORYPROCDIV , WAREHOUSECODESTRF=@WAREHOUSECODEST , WAREHOUSECODEEDRF=@WAREHOUSECODEED , SHELFNOSTRF=@SHELFNOST , SHELFNOEDRF=@SHELFNOED , STARTSUPPLIERCODERF=@STARTSUPPLIERCODE , ENDSUPPLIERCODERF=@ENDSUPPLIERCODE , BLGOODSCODESTRF=@BLGOODSCODEST , BLGOODSCODEEDRF=@BLGOODSCODEED , GOODSMAKERCDSTRF=@GOODSMAKERCDST , GOODSMAKERCDEDRF=@GOODSMAKERCDED , BLGROUPCODESTRF=@BLGROUPCODEST , BLGROUPCODEEDRF=@BLGROUPCODEED , TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV , ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV , LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST , LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED , SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1 , SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2 , SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3 , SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4 , SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5 , SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6 , SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7 , SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8 , SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9 , SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10 , INVENTORYDATERF=@INVENTORYDATE, MNGSECTIONCODESTRF=@MNGSECTIONCODEST, MNGSECTIONCODEEDRF=@MNGSECTIONCODEED"
                                               + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";
                        // -------UPD 2011/01/30-------<<<<<
                        // �C�� 2008/09/18 <<<
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                        findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                        findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //�V�K�쐬����SQL���𐶐�
                        //sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, LGGOODSGANRECDSTRF, LGGOODSGANRECDEDRF, MDGOODSGANRECDSTRF, MDGOODSGANRECDEDRF, DTLGOODSGANRECDSTRF, DTLGOODSGANRECDEDRF, ENTERPRISEGANRECDSTRF, ENTERPRISEGANRECDEDRF, CMPSTKEXTRADIVRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, ENTTRTSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF) "
                        //    + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @LGGOODSGANRECDST, @LGGOODSGANRECDED, @MDGOODSGANRECDST, @MDGOODSGANRECDED, @DTLGOODSGANRECDST, @DTLGOODSGANRECDED, @ENTERPRISEGANRECDST, @ENTERPRISEGANRECDED, @CMPSTKEXTRADIV, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @ENTTRTSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE) ";
                        // -------UPD 2011/01/30------->>>>>
                        //sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, BLGROUPCODESTRF, BLGROUPCODEEDRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF) "
                        //    + " VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @BLGROUPCODEST, @BLGROUPCODEED, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE)";
                        sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, BLGROUPCODESTRF, BLGROUPCODEEDRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF, MNGSECTIONCODESTRF, MNGSECTIONCODEEDRF) "
                            + " VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @BLGROUPCODEST, @BLGROUPCODEED, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE, @MNGSECTIONCODEST, @MNGSECTIONCODEED)";

                        // -------UPD 2011/01/30-------<<<<<
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    #region Parameter�I�u�W�F�N�g�̍쐬
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraShelfNoSt = sqlCommand.Parameters.Add("@SHELFNOST", SqlDbType.NVarChar);
                    SqlParameter paraShelfNoEd = sqlCommand.Parameters.Add("@SHELFNOED", SqlDbType.NVarChar);
                    SqlParameter paraStartSupplierCode = sqlCommand.Parameters.Add("@STARTSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraEndSupplierCode = sqlCommand.Parameters.Add("@ENDSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateSt = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateEd = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    SqlParameter paraSelWarehouseCode1 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE1", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode2 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE2", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode3 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE3", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode4 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE4", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode5 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE5", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode6 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE6", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode7 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE7", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode8 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE8", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode9 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE9", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode10 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE10", SqlDbType.NChar);
                    SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                    SqlParameter paraMngSectionCodeSt = sqlCommand.Parameters.Add("@MNGSECTIONCODEST", SqlDbType.NChar);// ADD 2011/01/30
                    SqlParameter paraMngSectionCodeEd = sqlCommand.Parameters.Add("@MNGSECTIONCODEED", SqlDbType.NChar);// ADD 2011/01/30

                    #region �ύX�O(MA.NS)
                    /*
                    SqlParameter paraCreateDateTime      = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime      = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode      = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid      = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode     = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1      = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2      = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode   = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraSectionCode         = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay   = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim   = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv    = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraGeneralGoodsExtDiv  = sqlCommand.Parameters.Add("@GENERALGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraMobileGoodsExtDiv   = sqlCommand.Parameters.Add("@MOBILEGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraAcsryGoodsExtDiv    = sqlCommand.Parameters.Add("@ACSRYGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraStWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraEdWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraStMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEST", SqlDbType.Int);
                    SqlParameter paraEdMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEED", SqlDbType.Int);
                    SqlParameter paraStCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDST", SqlDbType.Int);
                    SqlParameter paraEdCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDED", SqlDbType.Int);
                    SqlParameter paraStLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDED", SqlDbType.NVarChar);
                    SqlParameter paraStGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDED", SqlDbType.NVarChar);
                    SqlParameter paraCmpStkExtraDiv      = sqlCommand.Parameters.Add("@CMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv      = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv   = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntTrtStkExtraDiv   = sqlCommand.Parameters.Add("@ENTTRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraStLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraEdLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    */
                    #endregion  // �ύX�O(MA.NS)
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraShelfNoSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoSt);
                    paraShelfNoEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoEd);
                    paraStartSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.StartSupplierCode);
                    paraEndSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EndSupplierCode);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeSt);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeEd);
                    paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdSt);
                    paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdEd);
                    // �C�� 2009/05/15 >>>
                    //paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeSt);
                    //paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeEd);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeSt);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeEd);
                    // �C�� 2009/05/15 <<<
                    paraTrtStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraLtInventoryUpdateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraLtInventoryUpdateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    paraSelWarehouseCode1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode1);
                    paraSelWarehouseCode2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode2);
                    paraSelWarehouseCode3.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode3);
                    paraSelWarehouseCode4.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode4);
                    paraSelWarehouseCode5.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode5);
                    paraSelWarehouseCode6.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode6);
                    paraSelWarehouseCode7.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode7);
                    paraSelWarehouseCode8.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode8);
                    paraSelWarehouseCode9.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode9);
                    paraSelWarehouseCode10.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode10);
                    paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryDate);
                    paraMngSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.MngSectionCodeSt);// ADD 2011/01/30
                    paraMngSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.MngSectionCodeEd);// ADD 2011/01/30
                    #region  �ύX�O(MA.NS)
                    /*
                    paraCreateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value      = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value     = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);

                    paraSectionCode.Value         = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value   = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraGeneralGoodsExtDiv.Value  = SqlDataMediator.SqlSetInt32(inventDataPreWork.GeneralGoodsExtDiv);
                    paraMobileGoodsExtDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.MobileGoodsExtDiv);
                    paraAcsryGoodsExtDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.AcsryGoodsExtDiv);
                    paraStWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraEdWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraStCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdSt);
                    paraEdCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdEd);
                    paraStMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeSt);
                    paraEdMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeEd);
                    paraStLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdSt);
                    paraEdLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdEd);
                    paraStMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdSt);
                    paraEdMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdEd);
                    paraStCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdSt);
                    paraEdCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdEd);
                    paraStGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdSt);
                    paraEdGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdEd);
                    paraCmpStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.CmpStkExtraDiv);
                    paraTrtStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraEntTrtStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntTrtStkExtraDiv);
                    paraStLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraEdLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    */
                    #endregion    // �ύX�O(MA.NS)

                    #endregion    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.WriteInventDataPre:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            if (!myReader.IsClosed) myReader.Close();
            return status;
        }
        #endregion  // �I���f�[�^�i�������������j�o�^����
        //#endregion  // SearchWrite

        #region Write�@���I���f�[�^�i�������������j
        /// <summary>
        /// �I���f�[�^�i�������������j��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">InventoryExtCndtnWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�i�������������j��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int Write(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                InventDataPreWork inventDataPreWork = (InventDataPreWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventDataPreWork));

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                int st = WriteProc(ref inventDataPreWork, ref sqlConnection);

                if (st == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            sqlConnection.Close();

            return status;
        }

        #region WriteProc
        /// <summary>
        /// �I������������������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="inventDataPreWork">InventDataPreWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I������������������o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        private int WriteProc(ref InventDataPreWork inventDataPreWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ", sqlConnection))
                {
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventoryPreprDay = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter findParaInventoryPreprTim = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRTIM", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != inventDataPreWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (inventDataPreWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed) myReader.Close();
                            return status;
                        }

                        sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYPROCDIVRF=@INVENTORYPROCDIV , WAREHOUSECODESTRF=@WAREHOUSECODEST , WAREHOUSECODEEDRF=@WAREHOUSECODEED , SHELFNOSTRF=@SHELFNOST , SHELFNOEDRF=@SHELFNOED , STARTSUPPLIERCODERF=@STARTSUPPLIERCODE , ENDSUPPLIERCODERF=@ENDSUPPLIERCODE , BLGOODSCODESTRF=@BLGOODSCODEST , BLGOODSCODEEDRF=@BLGOODSCODEED , GOODSMAKERCDSTRF=@GOODSMAKERCDST , GOODSMAKERCDEDRF=@GOODSMAKERCDED , BLGROUPCODESTRF=@BLGROUPCODEST , BLGROUPCODEEDRF=@BLGROUPCODEED , TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV , ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV , LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST , LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED , SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1 , SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2 , SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3 , SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4 , SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5 , SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6 , SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7 , SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8 , SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9 , SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10 , INVENTORYDATERF=@INVENTORYDATE "
                        + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                        findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                        findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, BLGROUPCODESTRF, BLGROUPCODEEDRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF) "
                            + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @BLGROUPCODEST, @BLGROUPCODEED, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE) ";

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    #region Parameter�I�u�W�F�N�g�̍쐬
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraShelfNoSt = sqlCommand.Parameters.Add("@SHELFNOST", SqlDbType.NVarChar);
                    SqlParameter paraShelfNoEd = sqlCommand.Parameters.Add("@SHELFNOED", SqlDbType.NVarChar);
                    SqlParameter paraStartSupplierCode = sqlCommand.Parameters.Add("@STARTSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraEndSupplierCode = sqlCommand.Parameters.Add("@ENDSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateSt = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateEd = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    SqlParameter paraSelWarehouseCode1 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE1", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode2 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE2", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode3 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE3", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode4 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE4", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode5 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE5", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode6 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE6", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode7 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE7", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode8 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE8", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode9 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE9", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode10 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE10", SqlDbType.NChar);
                    // 2007.03.07 Add >>>>>>>>
                    SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                    // 2007.03.07 Add <<<<<<<<

                    #region  �ύX�O(MA.NS)
                    /*
                    SqlParameter paraCreateDateTime      = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime      = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode      = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid      = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode     = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1      = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2      = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode   = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraSectionCode         = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay   = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim   = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv    = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraGeneralGoodsExtDiv  = sqlCommand.Parameters.Add("@GENERALGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraMobileGoodsExtDiv   = sqlCommand.Parameters.Add("@MOBILEGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraAcsryGoodsExtDiv    = sqlCommand.Parameters.Add("@ACSRYGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraStWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraEdWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraStMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEST", SqlDbType.Int);
                    SqlParameter paraEdMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEED", SqlDbType.Int);
                    SqlParameter paraStCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDST", SqlDbType.Int);
                    SqlParameter paraEdCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDED", SqlDbType.Int);
                    SqlParameter paraStLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDED", SqlDbType.NVarChar);
                    SqlParameter paraStGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDED", SqlDbType.NVarChar);
                    SqlParameter paraCmpStkExtraDiv      = sqlCommand.Parameters.Add("@CMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv      = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv   = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntTrtStkExtraDiv   = sqlCommand.Parameters.Add("@ENTTRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraStLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraEdLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    */
                    #endregion    // �ύX�O(MA.NS)
                    #endregion    // Parameter�I�u�W�F�N�g�̍쐬

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraShelfNoSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoSt);
                    paraShelfNoEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoEd);
                    paraStartSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.StartSupplierCode);
                    paraEndSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EndSupplierCode);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeSt);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeEd);
                    paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdSt);
                    paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdEd);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeSt);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeEd);
                    paraTrtStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraLtInventoryUpdateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraLtInventoryUpdateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    paraSelWarehouseCode1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode1);
                    paraSelWarehouseCode2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode2);
                    paraSelWarehouseCode3.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode3);
                    paraSelWarehouseCode4.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode4);
                    paraSelWarehouseCode5.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode5);
                    paraSelWarehouseCode6.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode6);
                    paraSelWarehouseCode7.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode7);
                    paraSelWarehouseCode8.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode8);
                    paraSelWarehouseCode9.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode9);
                    paraSelWarehouseCode10.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode10);
                    // 2008.03.07 Add >>>>>>>>
                    paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryDate);
                    // 2008.03.07 Add <<<<<<<<

                    #region  �ύX�O(MA.NS)
                    /*
                    paraCreateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value      = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value     = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);

                    paraSectionCode.Value         = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value   = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraGeneralGoodsExtDiv.Value  = SqlDataMediator.SqlSetInt32(inventDataPreWork.GeneralGoodsExtDiv);
                    paraMobileGoodsExtDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.MobileGoodsExtDiv);
                    paraAcsryGoodsExtDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.AcsryGoodsExtDiv);
                    paraStWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraEdWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraStCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdSt);
                    paraEdCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdEd);
                    paraStMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeSt);
                    paraEdMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeEd);
                    paraStLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdSt);
                    paraEdLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdEd);
                    paraStMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdSt);
                    paraEdMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdEd);
                    paraStCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdSt);
                    paraEdCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdEd);
                    paraStGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdSt);
                    paraEdGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdEd);
                    paraCmpStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.CmpStkExtraDiv);
                    paraTrtStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraEntTrtStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntTrtStkExtraDiv);
                    paraStLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraEdLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    */
                    #endregion    // �ύX�O(MA.NS)
                    #endregion    // Parameter�I�u�W�F�N�g�֒l�ݒ�


                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.WriteProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            if (!myReader.IsClosed) myReader.Close();
            return status;
        }
        #endregion  // WriteProc
        #endregion  // Write�@���I���f�[�^�i�������������j

        #region Delete�@���I���f�[�^�i�������������j
        /// <summary>
        /// �I���f�[�^�i�������������j�𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�I�����������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�i�������������j�𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// �I���f�[�^�i�������������j�𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�I�����������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�i�������������j�𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                InventDataPreWork inventDataPreWork = (InventDataPreWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventDataPreWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ", sqlConnection))
                {
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventoryPreprDay = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter findParaInventoryPreprTim = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRTIM", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
                        if (_updateDateTime != inventDataPreWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                        findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                        findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.Delete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (!myReader.IsClosed) myReader.Close();
            sqlConnection.Close();

            return status;
        }
        #endregion  // Delete�@���I���f�[�^�i�������������j

        #region DeleteInvent�@���I���f�[�^
        /// <summary>
        /// �I���f�[�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�I���f�[�^�I�u�W�F�N�g</param>
        /// <param name="inventoryDataWork">�I���f�[�^�i�������������j�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        public int DeleteInvent(byte[] parabyte, out byte[] retbyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;
            retbyte = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                InventoryDataWork inventoryDataWork = (InventoryDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventoryDataWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                object paraobj = inventoryDataWork;
                object retobj = null;

                status = SearchInventoryData(out retobj, paraobj, ConstantManagement.LogicalMode.GetData0);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<<
                //�I���f�[�^�폜����
                status = DeleteInventProc(inventoryDataWork, out retbyte, ref sqlConnection, ref sqlTrans);


            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.DeleteInvent:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }

        #region DeleteInventProc
        /// <summary>
        /// �I���f�[�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="inventoryDataWork">�I���f�[�^�I�u�W�F�N�g</param>
        /// <param name="inventoryDataWork">�I���f�[�^�i�������������j�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�������������𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#30282 ��1002 �I�����������̉��ǂ̑Ή�</br>
        private int DeleteInventProc(InventoryDataWork inventoryDataWork, out byte[] retbyte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));
            retbyte = null;

            try
            {
                // �C�� 2008/09/18 // �����_�őS���_���̒I�������s�ł���d�l�ɕύX���邽�߁A���_�R�[�h�̎w����폜(��ƃR�[�h�̂ݎw�肷��)  >>>
                // using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE ", sqlConnection, sqlTrans))
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTrans))
                // �C�� 2008/09/18 <<<
                {
                    //KEY�R�}���h���Đݒ�
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode    = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // DEL 2008/09/18 <<<

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);
                    //findParaSectionCode.Value    = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCode); // DEL 2008/09/18 <<<
                    // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                    //�Ǘ����_�J�n
                    if (inventoryDataWork.SectionCodeSt != "")
                    {
                        sqlCommand.CommandText += " AND SECTIONCODERF>=@STSECTIONCODE ";
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeSt);
                    }
                    //�Ǘ����_�I��
                    if (inventoryDataWork.SectionCodeEd != "")
                    {
                        sqlCommand.CommandText += "AND SECTIONCODERF<=@EDSECTIONCODE ";
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeEd);
                    }
                    // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    #region �I���f�[�^�i�������������j�o�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�I���f�[�^�i�������������j�o�^����
                        #region �l�Z�b�g
                        InventDataPreWork inventDataPreWork = new InventDataPreWork();
                        inventDataPreWork.EnterpriseCode = inventoryDataWork.EnterpriseCode;
                        inventDataPreWork.SectionCode = inventoryDataWork.SectionCode;
                        inventDataPreWork.InventoryProcDiv = 3;
                        inventDataPreWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim = SysTime;
                        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        inventDataPreWork.MngSectionCodeSt = inventoryDataWork.SectionCodeSt;
                        inventDataPreWork.MngSectionCodeEd = inventoryDataWork.SectionCodeEd;
                        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        #endregion
                        status = WriteInventDataPre(ref inventDataPreWork, ref sqlConnection, ref sqlTrans);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retbyte = XmlByteSerializer.Serialize(inventDataPreWork);
                        }
                    }
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.DeleteInventProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion  // DeleteInventProc
        #endregion  // DeleteInvent�@���I���f�[�^

        #region MakeWhereString
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="inventoryExtCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="selectMode">0:�I���f�[�^�i�������������j�}�X�^, 1:���ԍ݌Ƀ}�X�^, 2:�I���f�[�^, 3:�폜�p</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, InventoryExtCndtnWork inventoryExtCndtnWork, ConstantManagement.LogicalMode logicalMode, int selectMode)
        {
            string retstring = " WHERE ";

            string tblDM = "";
            if (selectMode == 0) tblDM = "IDP.";   // �I���f�[�^�i�������������j�}�X�^
            //#if (selectMode == 1) tblDM = "PDS.";   // ���ԍ݌Ƀ}�X�^
            if (selectMode == 1) tblDM = "STK.";   // �݌Ƀ}�X�^
            if (selectMode == 2) tblDM = "IVD.";   // �I���f�[�^
            if (selectMode == 3) tblDM = "";       // �폜�p�}�X�^

            //��ƃR�[�h
            retstring += tblDM + "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);


            //�_���폜
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + tblDM + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + tblDM + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // �C�� 2008/09/18 �����_�őS���_���̒I���f�[�^���쐬�ł���d�l�ɕύX���邽�߁A�I�������̒��o���̂݋��_�R�[�h�̎Q�Ƃ����� >>>
            ////���_�R�[�h
            //if ((inventoryExtCndtnWork.SectionCode != "") && (inventoryExtCndtnWork.SectionCode != null))
            //{
            //    retstring += " AND " + tblDM + "SECTIONCODERF=@SECTIONCODE ";
            //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            //    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCode);
            //}       
            if (selectMode == 0)
            {
                // --- DEL 2009/11/30 ---------->>>>>
                ////���_�R�[�h
                //if ((inventoryExtCndtnWork.SectionCode != "") && (inventoryExtCndtnWork.SectionCode != null))
                //{
                //    retstring += " AND " + tblDM + "SECTIONCODERF=@SECTIONCODE ";
                //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                //    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCode);
                //}
                // --- DEL 2009/11/30 ----------<<<<<
            }
            // �C�� 2008/09/18 <<<
            /*
            if (selectMode == 2)
            {
                //�I���X�V���������l�ȊO������
                int ymdInventoryUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring +=  " AND (IVD.LASTINVENTORYUPDATERF=" + ymdInventoryUpDate.ToString() + " OR IVD.LASTINVENTORYUPDATERF IS NULL)";
            }
            */

            if (selectMode != 0)
            {
                //�q�ɃR�[�h�J�n
                if (inventoryExtCndtnWork.StWarehouseCd != "")
                {
                    retstring += " AND " + tblDM + "WAREHOUSECODERF>=@STWAREHOUSECODE ";
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                }
                //�q�ɃR�[�h�I��
                if (inventoryExtCndtnWork.EdWarehouseCd != "")
                {
                    retstring += "AND ( " + tblDM + "WAREHOUSECODERF<=@EDWAREHOUSECODE OR " + tblDM + "WAREHOUSECODERF LIKE @EDWAREHOUSECODE ) ";
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd + "%");
                }

                #region �P�Ƒq�Ɏw��
                // --- UPD 2010/02/20 ---------->>>>>
                ////�q�ɃR�[�h01�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD01";
                //    SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //    paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd01);
                //}
                ////�q�ɃR�[�h02�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd02 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD02";
                //    SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //    paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd02);
                //}
                ////�q�ɃR�[�h03�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd03 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD03";
                //    SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //    paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd03);
                //}
                ////�q�ɃR�[�h04�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd04 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD04";
                //    SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //    paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd04);
                //}
                ////�q�ɃR�[�h05�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd05 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD05";
                //    SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //    paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd05);
                //}
                ////�q�ɃR�[�h06�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd06 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD06";
                //    SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //    paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd06);
                //}
                ////�q�ɃR�[�h07�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd07 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD07";
                //    SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //    paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd07);
                //}
                ////�q�ɃR�[�h08�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd08 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD08";
                //    SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //    paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd08);
                //}
                ////�q�ɃR�[�h09�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd09 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD09";
                //    SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //    paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd09);
                //}
                ////�q�ɃR�[�h10�ݒ�
                //if (inventoryExtCndtnWork.WarehouseCd10 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD10";
                //    SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //    paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd10);
                //}

                Dictionary<string, string> wareList = new Dictionary<string, string>();
                if (inventoryExtCndtnWork.WarehouseCd01 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                if (inventoryExtCndtnWork.WarehouseCd02 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                if (inventoryExtCndtnWork.WarehouseCd03 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                if (inventoryExtCndtnWork.WarehouseCd04 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                if (inventoryExtCndtnWork.WarehouseCd05 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                if (inventoryExtCndtnWork.WarehouseCd06 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                if (inventoryExtCndtnWork.WarehouseCd07 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                if (inventoryExtCndtnWork.WarehouseCd08 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                if (inventoryExtCndtnWork.WarehouseCd09 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                if (inventoryExtCndtnWork.WarehouseCd10 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");

                if (wareList != null && wareList.Count != 0)
                {
                    retstring += " AND (";

                    int wareNum = 1;
                    foreach (string wCode in wareList.Keys)
                    {
                        if (wareNum == 1)
                        {
                            retstring += tblDM + "WAREHOUSECODERF=@WAREHOUSECD" + wareNum.ToString();
                        }
                        else
                        {
                            retstring += " OR " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD" + wareNum.ToString();
                        }
                        SqlParameter paraWarehouseCd = sqlCommand.Parameters.Add("@WAREHOUSECD" + wareNum.ToString(), SqlDbType.NVarChar);
                        paraWarehouseCd.Value = SqlDataMediator.SqlSetString(wCode);

                        wareNum++;
                    }

                    retstring += ")";
                }
                // --- UPD 2010/02/20 ----------<<<<<
                #endregion

                if (selectMode != 3) // ADD 2009/11/30
                {
                    if (selectMode != 2)  //ADD yangyi 2013/05/06 Redmine#35493
                    {
                    //�I�Ԑݒ�
                    if (inventoryExtCndtnWork.StWarehouseShelfNo != "")
                    {
                        retstring += " AND " + tblDM + "WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                        SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);
                    }
                    if (inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                    {
                        retstring += " AND ( " + tblDM + "WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR " + tblDM + "WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO OR " + tblDM + "WAREHOUSESHELFNORF IS NULL )";
                        SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        // --- UPD 2009/11/30 ---------->>>>>
                        //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo + "%");
                        paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);
                        // --- UPD 2009/11/30 ----------<<<<<
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    }
                    else
                    {
                        if (inventoryExtCndtnWork.StWarehouseShelfNo != "" && inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                        {
                            retstring += " AND  ( ( " + tblDM + "WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);

                            retstring += " AND " + tblDM + "WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO )";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF IS NULL ";
                      
                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                            SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                            paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("���޼");

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2 )";
                            SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                            paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("���޼");
                        }
                        else if(inventoryExtCndtnWork.StWarehouseShelfNo != "" && inventoryExtCndtnWork.EdWarehouseShelfNo == "")
                        {
                            retstring += " AND ( " + tblDM + "WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF IS NULL ";

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                            SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                            paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("���޼");

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2 )";
                            SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                            paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("���޼");
                        }
                        else if (inventoryExtCndtnWork.StWarehouseShelfNo == "" && inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                        {
                            retstring += " AND ( " + tblDM + "WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO ";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF IS NULL ";

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                            SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                            paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("���޼");

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2 )";
                            SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                            paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("���޼");
                        }
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                    // --- ADD 2011/02/10 ---------->>>>>
                    //���[�J�[�R�[�h�J�n
                    if (inventoryExtCndtnWork.StMakerCd > 0)
                    {
                        retstring += " AND " + tblDM + "GOODSMAKERCDRF>=@STMAKERCODE ";
                        SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                        paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                    }
                    //���[�J�[�R�[�h�I��
                    if (inventoryExtCndtnWork.EdMakerCd != 9999)
                    {
                        retstring += " AND " + tblDM + "GOODSMAKERCDRF<=@EDMAKERCODE ";
                        SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                        paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                    }
                    // --- ADD 2011/02/10 ----------<<<<<
                }
                // --- ADD 2011/02/10 ---------->>>>>
                else
                {
                    //�Ǘ����_�J�n
                    if (inventoryExtCndtnWork.SectionCodeSt != "")
                    {
                        retstring += " AND " + tblDM + "SECTIONCODERF>=@STSECTIONCODE ";
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                    }
                    //�Ǘ����_�I��
                    if (inventoryExtCndtnWork.SectionCodeEd != "")
                    {
                        retstring += "AND " + tblDM + "SECTIONCODERF<=@EDSECTIONCODE ";
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                    }
                }
                // --- ADD 2011/02/10 ----------<<<<<
                // --- DEL 2011/02/10 ---------->>>>>
                ////���[�J�[�R�[�h�J�n
                //if (inventoryExtCndtnWork.StMakerCd > 0)
                //{
                //    retstring += " AND " + tblDM + "GOODSMAKERCDRF>=@STMAKERCODE ";
                //    SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                //    paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                //}
                ////���[�J�[�R�[�h�I��
                //if (inventoryExtCndtnWork.EdMakerCd != 9999)
                //{
                //    retstring += " AND " + tblDM + "GOODSMAKERCDRF<=@EDMAKERCODE ";
                //    SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                //    paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                //}
                // --- DEL 2011/02/10 ----------<<<<<

                if (selectMode == 1)
                {
                    #region ���Ѝ݌ɒ��o���� (�݌Ƀ}�X�^)
                    //// �d����R�[�h
                    //if (inventoryExtCndtnWork.StCustomerCd != 0)
                    //{
                    //    retstring += " AND (CASE WHEN GOODSMNG.SUPPLIERCDRF IS NOT NULL  THEN GOODSMNG.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "     ELSE (CASE WHEN GOODSMNG2.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG2.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "           ELSE (CASE WHEN GOODSMNG3.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG3.SUPPLIERCDRF ELSE GOODSMNG4.SUPPLIERCDRF END ) END )  END) >=@STCUSTOMERCD " + Environment.NewLine;

                    //    SqlParameter paraStCustomerCd = sqlCommand.Parameters.Add("@STCUSTOMERCD", SqlDbType.Int);
                    //    paraStCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);

                    //}
                    //if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                    //{
                    //    retstring += " AND (CASE WHEN GOODSMNG.SUPPLIERCDRF IS NOT NULL  THEN GOODSMNG.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "     ELSE (CASE WHEN GOODSMNG2.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG2.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "           ELSE (CASE WHEN GOODSMNG3.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG3.SUPPLIERCDRF ELSE GOODSMNG4.SUPPLIERCDRF END ) END )  END) <=@EDCUSTOMERCD " + Environment.NewLine;

                    //    SqlParameter paraEdCustomerCd = sqlCommand.Parameters.Add("@EDCUSTOMERCD", SqlDbType.Int);
                    //    paraEdCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                    //}
                    // BL�R�[�h
                    if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                    {
                        retstring += " AND GOODS.BLGOODSCODERF>=@STBLGOODSCD ";
                        SqlParameter paraStBLGoodsCd = sqlCommand.Parameters.Add("@STBLGOODSCD", SqlDbType.Int);
                        paraStBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                    }
                    if (inventoryExtCndtnWork.EdBLGoodsCd != 99999)
                    {
                        retstring += " AND GOODS.BLGOODSCODERF<=@EDBLGOODSCD ";
                        SqlParameter paraEdBLGoodsCd = sqlCommand.Parameters.Add("@EDBLGOODSCD", SqlDbType.Int);
                        paraEdBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                    }
                    // ��ٰ�ߺ���
                    if (inventoryExtCndtnWork.StBLGroupCode != 0)
                    {
                        retstring += " AND BLGOODS.BLGROUPCODERF>=@STBLGROUPCODE ";
                        SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                        paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                    }
                    if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                    {
                        retstring += " AND BLGOODS.BLGROUPCODERF<=@EDBLGROUPCODE ";
                        SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                        paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                    }

                    //�ŏI�I���X�V��
                    if (inventoryExtCndtnWork.StLtInventoryUpdate != DateTime.MinValue)
                    {
                        int startLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.StLtInventoryUpdate);
                        retstring += " AND STK.LASTINVENTORYUPDATERF >= " + startLastInventoryExtUpdate.ToString();
                    }
                    if (inventoryExtCndtnWork.EdLtInventoryUpdate != DateTime.MinValue)
                    {
                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " AND ( STK.LASTINVENTORYUPDATERF IS NULL OR ";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.EdLtInventoryUpdate);
                        retstring += " STK.LASTINVENTORYUPDATERF <=" + endLastInventoryExtUpdate.ToString();

                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                    }
                    #endregion
                }

                #region DEL
                //#//�L�����A�R�[�h�ݒ�
                //#if (inventoryExtCndtnWork.StCarrierCd != 0)
                //#{
                //#    retstring += " AND " + tblDM + "CARRIERCODERF>=@STCARRIERCODE";
                //#    SqlParameter paraStCarrierCode = sqlCommand.Parameters.Add("@STCARRIERCODE", SqlDbType.Int);
                //#    paraStCarrierCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCarrierCd);
                //#}
                //#if (inventoryExtCndtnWork.EdCarrierCd != 999)
                //#{
                //#    retstring += " AND " + tblDM + "CARRIERCODERF<=@EDCARRIERCODE";
                //#    SqlParameter paraEdCarrierCode = sqlCommand.Parameters.Add("@EDCARRIERCODE", SqlDbType.Int);
                //#    paraEdCarrierCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCarrierCd);
                //#}

                /*
                //���i�敪�O���[�v�R�[�h�J�n
                if (inventoryExtCndtnWork.StLgGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "LARGEGOODSGANRECODERF>=@STLARGEGOODSGANRECODE ";
                    SqlParameter paraStLargeGoodsGanreCode = sqlCommand.Parameters.Add("@STLARGEGOODSGANRECODE", SqlDbType.NChar);
                    paraStLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StLgGoodsGanreCd);
                }
                //���i�敪�O���[�v�R�[�h�I��
                if (inventoryExtCndtnWork.EdLgGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "LARGEGOODSGANRECODERF<=@EDLARGEGOODSGANRECODE ";
                    SqlParameter paraEdLargeGoodsGanreCode = sqlCommand.Parameters.Add("@EDLARGEGOODSGANRECODE", SqlDbType.NChar);
                    paraEdLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdLgGoodsGanreCd);
                }

                //���i�敪�R�[�h�J�n
                if (inventoryExtCndtnWork.StMdGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "MEDIUMGOODSGANRECODERF>=@STMEDIUMGOODSGANRECODE ";
                    SqlParameter paraStMediumGoodsGanreCode = sqlCommand.Parameters.Add("@STMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                    paraStMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StMdGoodsGanreCd);
                }
                //���i�敪�R�[�h�I��
                if (inventoryExtCndtnWork.EdMdGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "MEDIUMGOODSGANRECODERF<=@EDMEDIUMGOODSGANRECODE ";
                    SqlParameter paraEdMediumGoodsGanreCode = sqlCommand.Parameters.Add("@EDMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                    paraEdMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdMdGoodsGanreCd);
                }
                */
                //#//�@��R�[�h�J�n
                //#if (inventoryExtCndtnWork.StCellphoneModelCd != "")
                //#{
                //#    retstring += " AND " + tblDM + "CELLPHONEMODELCODERF>=@STCELLPHONEMODELCODE ";
                //#    SqlParameter paraStCellphoneModelCode = sqlCommand.Parameters.Add("@STCELLPHONEMODELCODE", SqlDbType.NVarChar);
                //#    paraStCellphoneModelCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StCellphoneModelCd);
                //#}
                //#//�@��R�[�h�I��
                //#if (inventoryExtCndtnWork.EdCellphoneModelCd != "")
                //#{
                //#    retstring += "AND ( " + tblDM + "CELLPHONEMODELCODERF<=@EDCELLPHONEMODELCODE OR " + tblDM + "CELLPHONEMODELCODERF LIKE @EDCELLPHONEMODELCODE ) ";
                //#    SqlParameter paraEdCellphoneModelCode = sqlCommand.Parameters.Add("@EDCELLPHONEMODELCODE", SqlDbType.NVarChar);
                //#    paraEdCellphoneModelCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdCellphoneModelCd + "%");
                //#}

                //#//���i�R�[�h�J�n
                //#if (inventoryExtCndtnWork.StGoodsCd != "")
                //#{
                //#    retstring += " AND " + tblDM + "GOODSCODERF>=@STGOODSCODE ";
                //#    SqlParameter paraStGoodsCode = sqlCommand.Parameters.Add("@STGOODSCODE", SqlDbType.NVarChar);
                //#    paraStGoodsCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StGoodsCd);
                //#}
                //#//���i�R�[�h�I��
                //#if (inventoryExtCndtnWork.EdGoodsCd != "")
                //#{
                //#    retstring += "AND ( " + tblDM + "GOODSCODERF<=@EDGOODSCODE OR " + tblDM + "GOODSCODERF LIKE @EDGOODSCODE ) ";
                //#    SqlParameter paraEdGoodsCode = sqlCommand.Parameters.Add("@EDGOODSCODE", SqlDbType.NVarChar);
                //#    paraEdGoodsCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdGoodsCd + "%");
                //#}
                #endregion
                else if (selectMode == 2)
                {
                    #region �I���f�[�^���o����
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    // ----- ADD 2011/01/11 ----->>>>>
                    //retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                    //SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                    //paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("���޼");

                    //retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2";
                    //SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                    //paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("���޼");
                    // ----- ADD 2011/01/11 -----<<<<<
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                    //�a�k���i�R�[�h�J�n
                    if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                    {
                        retstring += " AND " + tblDM + "BLGOODSCODERF>=@STBLGOODSCD ";
                        SqlParameter paraStBLGoodsCd = sqlCommand.Parameters.Add("@STBLGOODSCD", SqlDbType.NVarChar);
                        paraStBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                    }
                    //�a�k���i�R�[�h�I��
                    if (inventoryExtCndtnWork.EdBLGoodsCd != 0)
                    {
                        retstring += " AND " + tblDM + "BLGOODSCODERF<=@EDBLGOODSCD ";
                        SqlParameter paraEdBLGoodsCd = sqlCommand.Parameters.Add("@EDBLGOODSCD", SqlDbType.NVarChar);
                        paraEdBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                    }
                    //�d����R�[�h�ݒ�
                    if (inventoryExtCndtnWork.StCustomerCd != 0)
                    {
                        retstring += " AND " + tblDM + "SUPPLIERCDRF>=@STCUSTOMERCD";
                        SqlParameter paraStCustomerCd = sqlCommand.Parameters.Add("@STCUSTOMERCD", SqlDbType.Int);
                        paraStCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);
                    }
                    if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                    {
                        retstring += " AND " + tblDM + "SUPPLIERCDRF<=@EDCUSTOMERCD";
                        SqlParameter paraEdCustomerCd = sqlCommand.Parameters.Add("@EDCUSTOMERCD", SqlDbType.Int);
                        paraEdCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                    }
                    // �O���[�v�R�[�h�ݒ�
                    if (inventoryExtCndtnWork.StBLGroupCode != 0)
                    {
                        retstring += " AND " + tblDM + "BLGROUPCODERF>=@STBLGROUPCODE";
                        SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                        paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                    }
                    if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                    {
                        retstring += " AND " + tblDM + "BLGROUPCODERF<=@EDBLGROUPCODE";
                        SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                        paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                    }
                    //-----ADD 2011/01/11----->>>>>
                    // �Ǘ����_
                    if (inventoryExtCndtnWork.SectionCodeSt != "")
                    {
                        sqlCommand.CommandText += " AND RESULTSADDUPSECCDRF>=@SECTIONCODEST" + Environment.NewLine;
                        SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                        paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                    }

                    if (inventoryExtCndtnWork.SectionCodeEd != "")
                    {
                        sqlCommand.CommandText += " AND RESULTSADDUPSECCDRF<=@SECTIONCODEED" + Environment.NewLine;
                        SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                        paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                    }
                    //-----ADD 2011/01/11-----<<<<<
                    #endregion
                }
                #region DEL
                /*
                //�݌ɒ��o�敪
                string retstockstring = "";
                //���Ѝ݌ɒ��o�敪
                if (inventoryExtCndtnWork.CmpStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=0 AND " + tblDM + "STOCKSTATERF=0)";
                }
                //����݌ɒ��o�敪
                if (inventoryExtCndtnWork.TrtStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    else
                    {
                        retstockstring += " OR ";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=1 AND " + tblDM + "STOCKSTATERF=10)";
                }
                //�ϑ��i���Ёj�݌ɒ��o�敪
                if (inventoryExtCndtnWork.EntCmpStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    else
                    {
                        retstockstring += " OR ";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=0 AND " + tblDM + "STOCKSTATERF=20)";
                }
                //�ϑ��i����j�݌ɒ��o�敪
                if (inventoryExtCndtnWork.EntTrtStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    else
                    {
                        retstockstring += " OR ";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=1 AND " + tblDM + "STOCKSTATERF=20)";
                }
                if (retstockstring != "")
                {
                    retstockstring += " )";
                    retstring += " AND " + retstockstring;
                }
                */
                //if (selectMode == 1)
                //{
                /*
                //���i���
                string retgoodsstring = "";
                //��ʒ��o�敪
                if (inventoryExtCndtnWork.GeneralGoodsExtDiv == 0)
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF=0)";
                }
                //�g�ѓd�b���o�敪
                if (inventoryExtCndtnWork.MobileGoodsExtDiv == 0)
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    else
                    {
                        retgoodsstring += " OR ";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF=1)";
                }
                //�t���i���o�敪
                if (inventoryExtCndtnWork.AcsryGoodsExtDiv == 0)
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    else
                    {
                        retgoodsstring += " OR ";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF=2)";
                }
                if ((inventoryExtCndtnWork.GeneralGoodsExtDiv == 0) && (inventoryExtCndtnWork.MobileGoodsExtDiv == 0) && (inventoryExtCndtnWork.AcsryGoodsExtDiv == 0))
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    else
                    {
                        retgoodsstring += " OR ";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF IS NULL)";
                }
                if (retgoodsstring != "")
                {
                    retgoodsstring += " )";
                    retstring += "AND " + retgoodsstring;
                }
                */
                //}
                #endregion
                else
                {
                    #region �I�������������� ���o���� �����ݖ��g�p
                    //�ŏI�I���X�V��
                    if (inventoryExtCndtnWork.StLtInventoryUpdate != DateTime.MinValue)
                    {
                        int startLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.StLtInventoryUpdate);
                        retstring += " AND " + tblDM + "LASTINVENTORYUPDATERF >= " + startLastInventoryExtUpdate.ToString();
                    }
                    if (inventoryExtCndtnWork.EdLtInventoryUpdate != DateTime.MinValue)
                    {
                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " AND ( " + tblDM + "LASTINVENTORYUPDATERF IS NULL OR ";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.EdLtInventoryUpdate);
                        retstring += " " + tblDM + "LASTINVENTORYUPDATERF <=" + endLastInventoryExtUpdate.ToString();

                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                    }
                    #endregion
                }
            }

            return retstring;
        }
        #endregion  // MakeWhereString

        /// <summary>
        /// �f�B�N�V���i���L�[
        /// </summary>
        /// <param name="WarehouseCode">�q�ɃR�[�h</param>
        /// <param name="WarehouseShelfNo">�q�ɒI��</param>
        /// <param name="GoodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="GoodsNo">���i�ԍ�</param>
        /// <returns>dic�L�[</returns>
        private string KeyofDic(string WarehouseCode, int GoodsMakerCd, string GoodsNo)
        {
            return (WarehouseCode + "." + GoodsMakerCd.ToString("%06d") + "." + GoodsNo);
        }

        // --- ADD 2009/11/30 ---------->>>>>
        #region SearchRepateDate
        /// <summary>
        /// �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�
        /// </summary>
        /// <param name="retobj">���݃`�F�b�Nflag</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.11.30</br>
        public int SearchRepateDate(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return SearchRepateDateProc(out retobj, paraobj, readMode, logicalMode, out statusMSG);
        }

        /// <summary>
        /// �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�
        /// </summary>
        /// <param name="retobj">���݃`�F�b�Nflag</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.11.30</br>
        private int SearchRepateDateProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            List<InventoryDataWork> al = null;   //�I���f�[�^
            InventoryExtCndtnWork inventoryExtCndtnWork = null;
            bool repateFlag = false;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "�ڑ��ُ�ł��B";
                    return status;
                }

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>          
                #region �V�X�e�����b�N(�q��)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //�V�F�A�`�F�b�N��񃊃X�g
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status;
                    }
                }
                #endregion
                // �V�X�e�����b�N(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- UPD 2010/02/20 ---------->>>>>
                //�݌Ƀ}�X�^��������
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                status = SeachProductStockRepate(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                // --- UPD 2010/02/20 ----------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)  //���o�f�[�^���Ȃ��ꍇ
                {
                    statusMSG = "�X�V�Ώۂ�����܂���B";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //���o�f�[�^������ꍇ
                {
                    // --- DEL 2010/02/20 ---------->>>>>
                    //�����ŁA
                    //al�ɓo�^����Ă���e�I���f�[�^���ƂɎw�肳�ꂽ�I�����ɂ�����݌ɐ������߂�B
                    //������e�I���f�[�^�̍݌ɑ����Ƃ��A�}�V���݌Ɋz���Čv�Z����B
                    //CalcStockTotal(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    // --- DEL 2010/02/20 ----------<<<<<

                    int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    #region �I���f�[�^��������
                    st = SeachInventoryRepateData(al, ref repateFlag, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        statusMSG += "�I���f�[�^�̌����Ɏ��s���܂����B";
                        status = st;
                    }
                    #endregion

                    status = st;

                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status == 0 || status == 9)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                            if (sta != 0) return status = sta;
                        }
                    }
                    // �V�X�e�����b�N����(�q��) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                retobj = repateFlag;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchRepateDateProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }

        /// <summary>
        /// �I���f�[�^���������A�I���f�[�^��߂��܂�
        /// </summary>
        /// <param name="al">�I���f�[�^</param>
        /// <param name="inventoryExtCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^Dictionary��߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.11.30</br>
        private int SeachInventoryRepateData(List<InventoryDataWork> al, ref bool repateFlag, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string SelectDm = "";
                SelectDm += "SELECT";

                //���ʎ擾
                SelectDm += " IVD.SECTIONCODERF  IVD_SECTIONCODERF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.GOODSMAKERCDRF  IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF  IVD_GOODSNORF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.STOCKUNITPRICEFLRF  IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF  IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";

                //SelectDm += " FROM INVENTORYDATARF IVD"; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM INVENTORYDATARF IVD WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 2);

                string Key = "";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    #region �I���f�[�^�l�Z�b�g
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                    wkInventoryDataWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));

                    foreach (InventoryDataWork inventoryDataWork in al)
                    {
                        if (inventoryDataWork.WarehouseCode.Equals(wkInventoryDataWork.WarehouseCode)
                            && inventoryDataWork.GoodsMakerCd.Equals(wkInventoryDataWork.GoodsMakerCd)
                            && inventoryDataWork.GoodsNo.Equals(wkInventoryDataWork.GoodsNo))
                        {
                            repateFlag = true;
                            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    #endregion  // �I���f�[�^�l�Z�b�g
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryRepateData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �I���ʔԂ�t�Ԕ�r�N���X(�I������������ݒ�敪)
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.11.30</br>
        /// <br>Update Note: 2012/05/25 �����H</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/06/27�z�M��</br>
        /// <br>             Redmine#29996�@�I�������[�@�I���A�Ԃ��A�A�Ԃň󎚂���Ȃ��̑Ή�</br>
        /// </remarks>
        public class InventoryDataWorkComparer : Comparer<InventoryDataWork>
        {
            private int _invntryPrtOdrIniDiv;
            // ADD �����H 2012/05/25 Redmine#29996 ------------->>>>>
            private CompareInfo myComp = CompareInfo.GetCompareInfo("en-US");
            private CompareOptions myOptions = CompareOptions.Ordinal;
            // ADD �����H 2012/05/25 Redmine#29996 -------------<<<<<

            public InventoryDataWorkComparer(int invntryPrtOdrIniDiv)
            {
                _invntryPrtOdrIniDiv = invntryPrtOdrIniDiv;
            }
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            /// <remarks>
            /// <br>Update Note: 2012/05/25 �����H</br>
            /// <br>�Ǘ��ԍ�   �F10801804-00 2012/06/27�z�M��</br>
            /// <br>             Redmine#29996�@�I�������[�@�I���A�Ԃ��A�A�Ԃň󎚂���Ȃ��̑Ή�</br>
            /// </remarks>
            public override int Compare(InventoryDataWork x, InventoryDataWork y)
            {
                int result = 0;
                //�I�ԏ�
                if (_invntryPrtOdrIniDiv == 0)
                {
                    #region DEL 2012/05/25
                    // DEL �����H 2012/05/25 Redmine#29996 ------------->>>>>
                    //�q�ɃR�[�h
                    //result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    //if (result != 0) return result;

                    //�q�ɒI��
                    //result = x.WarehouseShelfNo.CompareTo(y.WarehouseShelfNo);
                    //if (result != 0) return result;

                    //���i�ԍ�
                    //result = x.GoodsNo.CompareTo(y.GoodsNo);
                    //if (result != 0) return result;
                    // DEL �����H 2012/05/25 Redmine#29996 -------------<<<<<
                    #endregion DEL 2012/05/25

                    // ADD �����H 2012/05/25 Redmine#29996 ------------->>>>>
                    //�q�ɃR�[�h
                    result = myComp.Compare(x.WarehouseCode, y.WarehouseCode, myOptions);
                    if (result != 0) return result;

                    //�q�ɒI��
                    result = myComp.Compare(x.WarehouseShelfNo, y.WarehouseShelfNo, myOptions);
                    if (result != 0) return result;

                    //���i�ԍ�
                    result = myComp.Compare(x.GoodsNo, y.GoodsNo, myOptions);
                    if (result != 0) return result;
                    // ADD �����H 2012/05/25 Redmine#29996 -------------<<<<<

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //�d���揇
                else if (_invntryPrtOdrIniDiv == 1)
                {
                    //�q�ɃR�[�h
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //�d����R�[�h
                    result = x.SupplierCd.CompareTo(y.SupplierCd);
                    if (result != 0) return result;

                    //���i�ԍ�
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //BL�R�[�h��
                else if (_invntryPrtOdrIniDiv == 2)
                {
                    //�q�ɃR�[�h
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //BL���i�R�[�h
                    result = x.BLGoodsCode.CompareTo(y.BLGoodsCode);
                    if (result != 0) return result;

                    //���i�ԍ�
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //�O���[�v�R�[�h��
                else if (_invntryPrtOdrIniDiv == 3)
                {
                    //�q�ɃR�[�h
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //BL�O���[�v�R�[�h
                    result = x.BLGroupCode.CompareTo(y.BLGroupCode);
                    if (result != 0) return result;

                    //���i�ԍ�
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //���[�J�[��
                else if (_invntryPrtOdrIniDiv == 4)
                {
                    //�q�ɃR�[�h
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;

                    //���i�ԍ�
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;
                }
                //�d����E�I�ԏ�
                else if (_invntryPrtOdrIniDiv == 5)
                {
                    #region DEL 2012/05/25
                    // DEL �����H 2012/05/25 Redmine#29996 ------------->>>>>
                    //�q�ɃR�[�h
                    //result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    //if (result != 0) return result;
                    // DEL �����H 2012/05/25 Redmine#29996 -------------<<<<<
                    #endregion DEL 2012/05/25

                    // ADD �����H 2012/05/25 Redmine#29996 ------------->>>>>
                    //�q�ɃR�[�h
                    result = myComp.Compare(x.WarehouseCode, y.WarehouseCode, myOptions);
                    if (result != 0) return result;
                    // ADD �����H 2012/05/25 Redmine#29996 -------------<<<<<

                    //�d����R�[�h
                    result = x.SupplierCd.CompareTo(y.SupplierCd);
                    if (result != 0) return result;

                    #region DEL 2012/05/25
                    // DEL �����H 2012/05/25 Redmine#29996 ------------->>>>>
                    //�q�ɒI��
                    //result = x.WarehouseShelfNo.CompareTo(y.WarehouseShelfNo);
                    //if (result != 0) return result;

                    //���i�ԍ�
                    //result = x.GoodsNo.CompareTo(y.GoodsNo);
                    //if (result != 0) return result;
                    // DEL �����H 2012/05/25 Redmine#29996 -------------<<<<<
                    #endregion DEL 2012/05/25

                    // ADD �����H 2012/05/25 Redmine#29996 ------------->>>>>
                    //�q�ɒI��
                    result = myComp.Compare(x.WarehouseShelfNo, y.WarehouseShelfNo, myOptions);
                    if (result != 0) return result;
                    
                    //���i�ԍ�
                    result = myComp.Compare(x.GoodsNo, y.GoodsNo, myOptions);
                    if (result != 0) return result;
                    // ADD �����H 2012/05/25 Redmine#29996 -------------<<<<<

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //�d����E���[�J�[��
                else if (_invntryPrtOdrIniDiv == 6)
                {
                    //�q�ɃR�[�h
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //�d����R�[�h
                    result = x.SupplierCd.CompareTo(y.SupplierCd);
                    if (result != 0) return result;

                    //���i���[�J�[�R�[�h
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;

                    //���i�ԍ�
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;
                }
                else
                {
                    //�Ȃ�
                }

                return result;
            }
        }
        #endregion  // SearchRepateDate
        // --- ADD 2009/11/30 ----------<<<<<

        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̒I���f�[�^�����߂��܂�
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̒I���f�[�^�����߂��܂�</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2010.06.07</br>
        public int SearchInventoryData(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            InventoryDataWork inventoryDataWork = new InventoryDataWork();
            retobj = null;

            ArrayList al = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                inventoryDataWork = paraobj as InventoryDataWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand = null;
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = "SELECT * FROM INVENTORYDATARF  WITH (READUNCOMMITTED) ";
                
                //��ƃR�[�h
                sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);


                //�_���폜
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //�Ǘ����_�J�n
                if (inventoryDataWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND SECTIONCODERF>=@STSECTIONCODE ";
                    SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                    paraStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeSt);
                }
                //�Ǘ����_�I��
                if (inventoryDataWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += "AND SECTIONCODERF<=@EDSECTIONCODE ";
                    SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                    paraEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeEd);
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    #region �l�Z�b�g
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkInventoryDataWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));

                    #endregion  // �l�Z�b�g

                    al.Add(wkInventoryDataWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (!myReader.IsClosed) myReader.Close();
            sqlConnection.Close();

            retobj = al;
            return status;

        }
        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
    }
}
