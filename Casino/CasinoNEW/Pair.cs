using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	public class Pair
	{
        private Object first;
        private Object second;
		
		public Pair(){}

        public Pair(Object fst, Object snd)
		{
            first = fst;
            second = snd;
		}
        public Object getFirst()
        {
            return first;
        }
        public Object getSecond()
        {
            return second;
        }
        public void setFirst(Object fst)
        {
            first = fst;
        }
        public void setSecond(Object snd)
        {
            second = snd;
        }
	}
}
