using Infrastructure.Ddd;
using Infrastructure.Ddd.Domain.State;
using System;

namespace HightechAngular.Orders.Entities
{
    public abstract class OrderHasStateBase<TStatusEnum, TState> :
       HasStateBase<int, TStatusEnum, TState>
       where TStatusEnum : Enum
    {
    }

    public abstract class HasStateBase<TKey, TStatusEnum, TState> :
        EntityBase<TKey>,
        IHasStatus<TStatusEnum>,
        IHasState<TState>
        where TStatusEnum : Enum
        where TKey : IEquatable<TKey>
    {
        private TStatusEnum _status;

        private TState _state;

        public TStatusEnum Status
        {
            get => _status;
            protected set
            {
                _status = value;
                _state = GetState(_status);
            }
        }

        public abstract TState GetState(TStatusEnum status);

        public TState State => _state ??= GetState(Status);

        public void With<T>(Action<T> action)
            where T : class, TState
        {
            if (State is T state)
            {
                action(state);
            }
        }

        public TResult With<T, TResult>(Func<T, TResult> func, TResult ifFalse = default)
            where T : class, TState
        {
            if (State is T state)
            {
                return func(state);
            }

            return ifFalse;
        }

        protected T To<T>(TStatusEnum status)
            where T : TState
        {
            Status = status;
            return (T)State;
        }

        public TCurrentState As<TCurrentState>()
            where TCurrentState : TState
        {
            return State is TCurrentState currentState
                ? currentState
                : default;
        }

        public static explicit operator TState(HasStateBase<TKey, TStatusEnum, TState> hasStatus)
        {
            return hasStatus.State;
        }
    }
}