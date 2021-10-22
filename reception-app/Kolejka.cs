using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reception_app
{
    class Kolejka
    {
        private int n;
        private int qptr;
        private int qcnt;
        private string[] Q;

        public Kolejka(int x)
        {
            n = x;
            Q = new string[x];
            qptr = qcnt = 0;
        }
        ~Kolejka()
        {
            GC.Collect();
            GC.SuppressFinalize(Q);
            GC.SuppressFinalize(this);
        }
        public void usun()
        {
            if (qcnt != 0)
            {
                qcnt--;
                qptr++;
                if (qptr == n) qptr = 0;
            }

        }
        public string front()
        {
            if (qcnt != 0) return Q[qptr];
            return "";
        }
        public void push(string v)
        {
            int i;
            if (qcnt < n)
            {
                i = qptr + qcnt++;
                if (i >= n) i -= n;
                Q[i] = v;
            }
        }
        public bool empty()
        {
            return qcnt != 0;
        }
    }
}
