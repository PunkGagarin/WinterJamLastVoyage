using System;
using System.Collections.Generic;
using Core.Events.GameEvents;
using UnityEngine;
using Random = System.Random;

namespace Core.Events.Pools {

    public abstract class BasePool<E> where E : BaseGameEvent {


        protected List<E> _events;

        public void InitPool(List<E> events) {
            _events = events;
        }

        public abstract void InitPool();

        public E GetRandomPoolEvent() {
            if (_events.Count <= 0) {
                Debug.LogException(new Exception("There is no events in pool, probably Init is wrong"));
            }
            return _events[new Random().Next(_events.Count)];
        }

    }

}