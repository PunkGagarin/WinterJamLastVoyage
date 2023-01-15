using System;
using System.Collections.Generic;

namespace events {

    public class BasePool<E> where E : BaseGameEvent {


        private List<E> _events;

        public void InitPool(List<E> events) {
            _events = events;
        }

        public E GetRandomPoolEvent() {
            return _events[new Random().Next(_events.Count)];
        }

    }

}