using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework2_Task1
{
    public class SpiralMatrix : MMMatrix
    {
        public SpiralMatrix(int m, int n) : base(m, n) { }

        public override MMMatrix Fill(bool revert = false)
        {
            int sideCounter = 1;
            int sideDelta = 0;
            (int y, int x) currCoord = (0, 0);

            (int dy, int dx) currentDelta;
            SByte revertMinus;

            if (revert) 
            {
                revertMinus = -1;
                currentDelta = (0, +1);
            }
            else
            {
                revertMinus = 1;
                currentDelta = (+1, 0);
            }

            for (int value = 1; value <= _n * _m; value++)
            {
                _matrix[currCoord.y, currCoord.x] = value;

                if(sideCounter == 4)
                {
                    sideCounter = 0;
                    sideDelta += 1;
                }

                (int dy, int dx) nextCoord = (currCoord.y + currentDelta.dy, currCoord.x + currentDelta.dx);

                if((nextCoord.dy >= _n - sideDelta || nextCoord.dy < sideDelta) && currentDelta.dx == 0)
                {
                    (currentDelta.dy, currentDelta.dx) = (currentDelta.dx * revertMinus, currentDelta.dy * revertMinus);
                    sideCounter++;
                }
                
                else if((nextCoord.dx >= _m - sideDelta || nextCoord.dx < sideDelta) && currentDelta.dy == 0)
                {
                    (currentDelta.dy, currentDelta.dx) = (currentDelta.dx * (-1) * revertMinus, currentDelta.dy * (-1) * revertMinus);
                    sideCounter++;
                }

                currCoord.y += currentDelta.dy;
                currCoord.x += currentDelta.dx;
            }

            return this;
        }
    }
}
