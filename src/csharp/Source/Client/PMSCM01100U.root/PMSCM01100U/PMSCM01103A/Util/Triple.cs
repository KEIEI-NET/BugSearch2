//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 3�g�N���X
    /// </summary>
    /// <typeparam name="TFirst">1�Ԗڂ̗v�f�̌^</typeparam>
    /// <typeparam name="TSecond">2�Ԗڂ̗v�f�̌^</typeparam>
    /// <typeparam name="TThird">3�Ԗڂ̗v�f�̌^</typeparam>
    public class Triple<TFirst, TSecond, TThird>
    {
        #region <1�Ԗڂ̗v�f>

        /// <summary>1�Ԗڂ̗v�f</summary>
        private TFirst _first;
        /// <summary>1�Ԗڂ̗v�f���擾�܂��͐ݒ肵�܂��B</summary>
        public TFirst First
        {
            get { return _first; }
            set { _first = value; }
        }

        #endregion // </1�Ԗڂ̗v�f>

        #region <2�Ԗڂ̗v�f>

        /// <summary>2�Ԗڂ̗v�f</summary>
        private TSecond _second;
        /// <summary>2�Ԗڂ̗v�f���擾�܂��͐ݒ肵�܂��B</summary>
        public TSecond Second
        {
            get { return _second; }
            set { _second = value; }
        }

        #endregion // </2�Ԗڂ̗v�f>

        #region <3�Ԗڂ̗v�f>

        /// <summary>3�Ԗڂ̗v�f</summary>
        private TThird _third;
        /// <summary>3�Ԗڂ̗v�f���擾�܂��͐ݒ肵�܂��B</summary>
        public TThird Third
        {
            get { return _third; }
            set { _third = value; }
        }

        #endregion // </3�Ԗڂ̗v�f>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public Triple() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="first">1�Ԗڂ̗v�f</param>
        /// <param name="second">2�Ԗڂ̗v�f</param>
        /// <param name="third">3�Ԗڂ̗v�f</param>
        public Triple(
            TFirst first,
            TSecond second,
            TThird third
        )
        {
            _first = first;
            _second = second;
            _third = third;
        }

        #endregion // </Constructor>
    }
}
