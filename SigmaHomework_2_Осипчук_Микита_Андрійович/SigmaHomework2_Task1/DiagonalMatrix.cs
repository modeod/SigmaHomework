using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework2_Task1
{// чи була потреба організовувати наслідування? краще було створити різні методи генерації наповнення
    public class DiagonalMatrix : MMMatrix
    {
        public DiagonalMatrix(int n) : base(n, n) { }

        public override MMMatrix Fill(bool revert = false)
        {//спробуйте запустити разом зімною на парі
            (int y, int x) currCoord = (0, 0);
            //Тут гарно
            (int dy, int dx) deltaUp = (-1, +1);
            (int dy, int dx) deltaDown = (+1, -1);
            bool isUp = !revert;
            int D = 0;

            for (int value = 1; value <= _n*_n; value++)
            {
                _matrix[currCoord.y, currCoord.x] = value;

                if (isUp)
                {
                    currCoord.y += deltaUp.dy;
                    currCoord.x += deltaUp.dx;
                }
                else
                {
                    currCoord.y += deltaDown.dy;
                    currCoord.x += deltaDown.dx;
                }

                int sum = currCoord.y + currCoord.x + 1;
                D = (sum - _n) < 0 ? 0 : (sum - _n);

                if (currCoord.y < D) 
                {
                    currCoord.y = D;
                    if(D != 0 || sum == _n)
                    {
                        currCoord.y += deltaDown.dy;
                        currCoord.x += deltaDown.dx;
                    }

                    isUp = !isUp;
                    continue;
                }
                else if (currCoord.x < D)
                {
                    currCoord.x = D;
                    if (D != 0 || sum == _n)
                    {
                        currCoord.y += deltaUp.dy;
                        currCoord.x += deltaUp.dx;
                    }

                    isUp = !isUp;
                    continue;
                }
            }

            return this;
        }
    }
}
