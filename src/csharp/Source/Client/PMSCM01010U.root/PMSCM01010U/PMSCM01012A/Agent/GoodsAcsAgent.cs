//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/07/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2012/04/19  �C�����e : RC-SCM���x���ǂ̏C��
//                               �F�i���������ʂ��s���ɂȂ�Ȃ��悤�L���b�V���N���A����j
//                               �F�i���L���b�V���N���A���Ă�static�ŕێ����Ă�������Ď擾���Ȃ��悤�ύX�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/08  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή�
//                                : 02.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i�񓚔��莞�j
//                                : 03.�ύX�O�P���v�Z�ďo�񐔉��ǑΉ�
//                                : 04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ�
//                                : 05.���Ӑ�}�X�^�i�`�[�Ǘ��j�擾���ǑΉ�
//                                : 06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j
//                                : 07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j
//                                : 08.����f�[�^�������̃V�X�e�����t�擾�Ή�
//                                : 09.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i����f�[�^�������j
//                                : 10.�P���v�Z�ďo�񐔉���
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// ���i�����N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class GoodsAcsAgent
    {
        #region <���i�����N���X>

        /// <summary>���i�����N���X�̃}�b�v</summary>
        private IDictionary<string, GoodsAcs> _goodsAcsMap;
        /// <summary>���i�����N���X�̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h + ���_�R�[�h</remarks>
        private IDictionary<string, GoodsAcs> GoodsAcsMap
        {
            get
            {
                if (_goodsAcsMap == null)
                {
                    _goodsAcsMap = new Dictionary<string, GoodsAcs>();
                }
                return _goodsAcsMap;
            }
        }

        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>���i�����N���X�������ς݃t���O�̃}�b�v</summary>
        private static IDictionary<string, bool> _goodsAcsInitFlagMap;
        /// <summary>���i�����N���X�������ς݃t���O�̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h + ���_�R�[�h</remarks>
        private static IDictionary<string, bool> GoodsAcsInitFlagMap
        {
            get
            {
                if ( _goodsAcsInitFlagMap == null )
                {
                    _goodsAcsInitFlagMap = new Dictionary<string, bool>();
                }
                return _goodsAcsInitFlagMap;
            }
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<

        #endregion // </���i�����N���X>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public GoodsAcsAgent() { }

        #endregion // </Constructor>

        /// <summary>
        /// ���i�����N���X���擾���܂��B
        /// </summary>
        /// <param name="scmDetailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <returns>�Y�����鏤�i�����N���X</returns>
        public GoodsAcs GetGoodsAccesser(
            ISCMOrderDetailRecord scmDetailRecord
        )
        {
            return GetGoodsAccesser(scmDetailRecord.InqOtherEpCd, scmDetailRecord.InqOtherSecCd);
        }

        /// <summary>
        /// ���i�����N���X���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�Y�����鏤�i�����N���X</returns>
        private GoodsAcs GetGoodsAccesser(
            string enterpriseCode,
            string sectionCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (GoodsAcsMap.ContainsKey(key))
            {
                return GoodsAcsMap[key];
            }
            GoodsAcs goodsAccesser = new GoodsAcs(sectionCode);
            {
                string msg = string.Empty;
                // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή� --------------------------------->>>>>
                goodsAccesser.IsGetSupplier = true;
                // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή� ---------------------------------<<<<<
                // --- UPD m.suzuki 2012/04/19 ---------->>>>>
                //goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);
                if ( !GoodsAcsInitFlagMap.ContainsKey( key ) )
                {
                    // ���i�A�N�Z�X�N���X��SearchInitial���s
                    goodsAccesser.SearchInitial( enterpriseCode, sectionCode, out msg );
                    
                    // SearchInitial���s�ς݃f�B�N�V���i���ɒǉ�
                    GoodsAcsInitFlagMap.Add( key, true );
                }
                // --- UPD m.suzuki 2012/04/19 ----------<<<<<

                GoodsAcsMap.Add(key, goodsAccesser);
            }
            return goodsAccesser;
        }
        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>
        /// GoodsAcsMap���N���A���܂��B
        /// </summary>
        public void ClearGoodsAcsMap()
        {
            if ( GoodsAcsMap != null )
            {
                GoodsAcsMap.Clear();
            }
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<
    }
}
