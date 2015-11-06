using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class ConwaysGOL : Board
    {
        private bool[,] boardTest;
        public ConwaysGOL(bool[,] board)
        {
            boardTest = board;

        }

        public ConwaysGOL()
        {
        }

        public bool[,] RuleOne()
       {
            throw new NotImplementedException();

            //1) define live/dead neighbors of cell X
            //2) count of live/dead neighbors of cell X
            //3) determine whether cell X will be live or dead after tick
            //4) Add new live/dead value to cell X
            //5) Return new bool[,]
        }       

        public List<List<bool>> ToList()
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            
        }

    }


}
