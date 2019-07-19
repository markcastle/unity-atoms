using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UnityAtoms
{
    public abstract partial class ScriptableObjectVariable<T, E1, E2> : ScriptableObjectVariableBase<T>,
        ISerializationCallbackReceiver, IVariableIcon
        where E1 : GameEvent<T>
        where E2 : GameEvent<T, T>
    {
        public override T Value { get { return _value; } set { SetValue(value); } }

        [SerializeField]
        private T _initialValue;

        [SerializeField]
        private bool _resetValueOnLevelStart;

        public T OldValue { get { return _oldValue; } }

        [FormerlySerializedAs("oldValue")]
        [SerializeField]
        private T _oldValue;

        public E1 Changed;

        public E2 ChangedWithHistory;

        protected abstract bool AreEqual(T first, T second);

        private void OnEnable()
        {
            SceneManager.sceneLoaded += ResetValue;
            if (Changed == null) return;
            Changed.Raise(Value);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= ResetValue;
        }

        public bool SetValue(T newValue)
        {
            if (!AreEqual(_value, newValue))
            {
                _oldValue = _value;
                _value = newValue;
                if (Changed != null) { Changed.Raise(_value); }
                if (ChangedWithHistory != null) { ChangedWithHistory.Raise(_value, _oldValue); }
                return true;
            }

            return false;
        }

        public bool SetValue(ScriptableObjectVariable<T, E1, E2> variable)
        {
            return SetValue(variable.Value);
        }

        public void OnBeforeSerialize() { }
        public void OnAfterDeserialize() { _value = _initialValue; }

        public void ResetValue()
        {
            SetValue(_initialValue);
        }

        #region Observable
        public IObservable<T> ObserveChange()
        {
            if (Changed == null)
            {
                throw new Exception("You must assign a Changed event in order to observe variable changes.");
            }

            return new ObservableEvent<T>(Changed.Register, Changed.Unregister);
        }

        public IObservable<ValueTuple<T, T>> ObserveChangeWithHistory()
        {
            if (ChangedWithHistory == null)
            {
                throw new Exception("You must assign a ChangedWithHistory event in order to observe variable changes.");
            }

            return new ObservableEvent<T, T, ValueTuple<T, T>>(
                register: ChangedWithHistory.Register,
                unregister: ChangedWithHistory.Unregister,
                createCombinedModel: (n, o) => new ValueTuple<T, T>(n, o)
            );
        }
        #endregion // Observable

        private void ResetValue(Scene scene, LoadSceneMode mode)
        {
            if (_resetValueOnLevelStart)
            {
                ResetValue();
            }
        }

        static partial void DoStuffOnUpdate(ScriptableObjectVariable<T, E1, E2> self);
    }
}
