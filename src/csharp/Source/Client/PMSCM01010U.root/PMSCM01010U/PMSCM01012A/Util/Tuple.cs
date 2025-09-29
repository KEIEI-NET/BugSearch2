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
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// Null�I�u�W�F�N�g�N���X
    /// </summary>
    public class NullObject
    {
        /// <summary>�f�t�H���g�R���X�g���N�^</summary>
        public NullObject() { }
    }

    /// <summary>
    /// �^�v���N���X
    /// </summary>
    public class Tuple<T01, T02, T03, T04, T05, T06, T07, T08, T09, T10>
        where T01 : class, new()
        where T02 : class, new()
        where T03 : class, new()
        where T04 : class, new()
        where T05 : class, new()
        where T06 : class, new()
        where T07 : class, new()
        where T08 : class, new()
        where T09 : class, new()
        where T10 : class, new()
    {
        #region <1�Ԗ�>

        /// <summary>1�Ԗڂ̃����o</summary>
        private T01 _member01;
        /// <summary>1�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T01 Member01
        {
            get
            {
                if (_member01 == null) _member01 = new T01();
                return _member01;
            }
            set { _member01 = value; }
        }

        #endregion // </1�Ԗ�>

        #region <2�Ԗ�>

        /// <summary>2�Ԗڂ̃����o</summary>
        private T02 _member02;
        /// <summary>2�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T02 Member02
        {
            get
            {
                if (_member02 == null) _member02 = new T02();
                return _member02;
            }
            set { _member02 = value; }
        }

        #endregion // </2�Ԗ�>

        #region <3�Ԗ�>

        /// <summary>3�Ԗڂ̃����o</summary>
        private T03 _member03;
        /// <summary>3�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T03 Member03
        {
            get
            {
                if (_member03 == null) _member03 = new T03();
                return _member03;
            }
            set { _member03 = value; }
        }

        #endregion // </3�Ԗ�>

        #region <4�Ԗ�>

        /// <summary>4�Ԗڂ̃����o</summary>
        private T04 _member04;
        /// <summary>4�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T04 Member04
        {
            get
            {
                if (_member04 == null) _member04 = new T04();
                return _member04;
            }
            set { _member04 = value; }
        }

        #endregion // </4�Ԗ�>

        #region <5�Ԗ�>

        /// <summary>5�Ԗڂ̃����o</summary>
        private T05 _member05;
        /// <summary>5�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T05 Member05
        {
            get
            {
                if (_member05 == null) _member05 = new T05();
                return _member05;
            }
            set { _member05 = value; }
        }

        #endregion // </5�Ԗ�>

        #region <6�Ԗ�>

        /// <summary>6�Ԗڂ̃����o</summary>
        private T06 _member06;
        /// <summary>6�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T06 Member06
        {
            get
            {
                if (_member06 == null) _member06 = new T06();
                return _member06;
            }
            set { _member06 = value; }
        }

        #endregion // </6�Ԗ�>

        #region <7�Ԗ�>

        /// <summary>7�Ԗڂ̃����o</summary>
        private T07 _member07;
        /// <summary>7�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T07 Member07
        {
            get
            {
                if (_member07 == null) _member07 = new T07();
                return _member07;
            }
            set { _member07 = value; }
        }

        #endregion // </7�Ԗ�>

        #region <8�Ԗ�>

        /// <summary>8�Ԗڂ̃����o</summary>
        private T08 _member08;
        /// <summary>8�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T08 Member08
        {
            get
            {
                if (_member08 == null) _member08 = new T08();
                return _member08;
            }
            set { _member08 = value; }
        }

        #endregion // </8�Ԗ�>

        #region <9�Ԗ�>

        /// <summary>9�Ԗڂ̃����o</summary>
        private T09 _member09;
        /// <summary>9�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T09 Member09
        {
            get
            {
                if (_member09 == null) _member09 = new T09();
                return _member09;
            }
            set { _member09 = value; }
        }

        #endregion // </9�Ԗ�>

        #region <10�Ԗ�>

        /// <summary>10�Ԗڂ̃����o</summary>
        private T10 _member10;
        /// <summary>10�Ԗڂ̃����o���擾�܂��͐ݒ肵�܂��B</summary>
        public T10 Member10
        {
            get
            {
                if (_member10 == null) _member10 = new T10();
                return _member10;
            }
            set { _member10 = value; }
        }

        #endregion // </10�Ԗ�>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public Tuple() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="member01">1�Ԗڂ̒l</param>
        /// <param name="member02">2�Ԗڂ̒l</param>
        /// <param name="member03">3�Ԗڂ̒l</param>
        /// <param name="member04">4�Ԗڂ̒l</param>
        /// <param name="member05">5�Ԗڂ̒l</param>
        /// <param name="member06">6�Ԗڂ̒l</param>
        /// <param name="member07">7�Ԗڂ̒l</param>
        /// <param name="member08">8�Ԗڂ̒l</param>
        /// <param name="member09">9�Ԗڂ̒l</param>
        /// <param name="member10">10�Ԗڂ̒l</param>
        public Tuple(
            T01 member01,
            T02 member02,
            T03 member03,
            T04 member04,
            T05 member05,
            T06 member06,
            T07 member07,
            T08 member08,
            T09 member09,
            T10 member10
        )
        {
            _member01 = member01;
            _member02 = member02;
            _member03 = member03;
            _member04 = member04;
            _member05 = member05;
            _member06 = member06;
            _member07 = member07;
            _member08 = member08;
            _member09 = member09;
            _member10 = member10;
        }

        #endregion // <Constructor>
    }
}
