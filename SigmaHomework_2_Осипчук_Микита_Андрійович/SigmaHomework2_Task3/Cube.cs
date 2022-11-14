using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework2_Task3
{ 
    public class Cube
    {
        private byte[,,] _cube;
        private int _sideLenght;

        public Cube(byte[,,] cube)
        {
            int baseLenght = cube.GetLength(0);
            for (var i = 0; i < cube.Rank; i++)
            {
                if (cube.GetLength(i) != baseLenght)
                    throw new ArgumentOutOfRangeException(nameof(cube), cube.GetLength(i), "Array is not a cube");
            }

            _cube = cube;
            _sideLenght = cube.GetLength(0);
        }

        public Cube(int i)
        {
            _cube = new byte[i, i, i];
            _sideLenght = i;
        }

        public Cube GenerateCube()
        {
            int length = _cube.GetLength(0);

            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; i < length; i++)
                {
                    for (int k = 0; i < length; i++)
                    {
                        _cube[i, j, k] = (byte)random.Next(0, 2);
                    }
                }
            }

            return this;
        }

        public bool IsThereAThroughHole()
        {
            bool checkLine(int startI, int startJ, int startK,
                int deltaI, int deltaJ, int deltaK)
            {
                int length = 1;
                while (
                    (startI > -1 && startI < _sideLenght) &&
                    (startJ > -1 && startJ < _sideLenght) &&
                    (startK > -1 && startK < _sideLenght))
                {
                    if (_cube[startI, startJ, startK] == 1)
                        return false;

                    length += 1;
                    startI += deltaI;
                    startJ += deltaJ;
                    startK += deltaK;
                }

                if (length == 1)
                    return false;

                return true;
            }

            //TODO: Implement linear algebra calculations
            //with the parametric straight line formula and the plane formula for the sides of the cube
            //Add optimisation such as check on last and middle dot is empty and only after this start to
            //raytracing.

            /*
             * В функции выше (рейтрейсинга) мы идем по заданному вектору, состоящему из вектора, который идет внутрь куба +
             * 2 направляющие, каждая от -1 до +1, что в сумме дает пирамиду обзора и поиска по осям внутрь 
             * с вершиной на стороне куба.
             * 
             * Вполне закономерный вопрос: а нафига у меня в каждом цикле фор,
             * каждый из которых отражает одну из плоскостей куба, нужны
             * 9 ифов? 
             * 
             * Ответ в том, что мы дожны пройтись по всем 9ти точкам основания пирамиды.
             * И для этого можно было бы сделать красивый цикл, где в случае, если координата основания 
             * вылезала за -1 или 1 (тоесть -2 или 2), то мы бы просто меняли направление обхода прям как
             * в задании со спиралью.
             * НО ведь имплементация такого цикла и доп проверки на то, вылезли или нет, ЭТО НЕЕФЕКТИВНО! (это я сделал на всякий случай :) )
             * 
             * В нашем случае, точек для проверки всего 9, а не 10, 50, 1_000+, потому этого можно избежать, пожертвовав красотой кода.
             * 
             *
             *
            Пример кода с Коровой, который я использовал в своем коде Точек:
            for (byte i = 0; i < 7; i++)
            {
                
                if (xCow < center.x && yCow < (center.y + 1))
                    yCow++;
                else if (xCow > center.x && yCow > (center.y - 1))
                    yCow--;
                else if (yCow < center.y && xCow > (center.x - 1))
                    xCow--;
                else if (yCow > center.y && xCow < (center.x + 1))
                    xCow++;
                
                //DEBUG
                Console.WriteLine($"cowCoord [{xCow},{yCow}]");

                try
                {
                    if (by[xCow, yCow].dotState == owner)
                        findedDots.Add(new XY((byte)xCow, (byte)yCow));
                }
                catch { continue; }

            }
             * 
             * 
             * Второй закономерный вопрос: а на кой тогда в функции рейтрейсинга (выше) мы их используем?
             * 
             * Ответ: потому что длинну линии в этом случае для избежания проверок надо расчитывать исходя из моего задания ТУДУ выше, а на него у меня сейчас нету времени, и я постараюсь
             * его сделать за вторник-среду (12-13.11.2022), так как времени у меня не достаточно.
             * Я уезжал на выходные в деревню, где небыло интернета и я работал. А в отсрочке дедлайна на число после 14го увы было отказано Лили.
             * 
             * Второй ответ: Этих проверок можно было бы избежать с помощью ТрайКетч блока, который обработает исключение OutOfRangeExeption, 
             * но погуглив я пришел лишь к тому, что это все надо замерять вручную, что быстрее, ибо зачастую работа с трайКетч медленее, чем просто проверки.
             * 
             * (попробую таки имплементировать второй ответ. Если выше будет через трай кетч - я так и поступил)
             * 
             * Следующий вопрос: Почему циклов 5, а не 6?
             * Оптимизация. Потому что при проверке пробития предыдущих 5ти сторон при его отсутствии 
             * автоматически получается то, что 6я сторона тоже не имеет ппробитий (пробитий лул :) )
             * 
             * При проверке начальной и последующих сторон со временем мы приходимк тому, что проверять ифом вектор точек стороны, который
             * в 100% случаев приводит к провереной стороне, ненужно, а значит от него можно избавится.
             * Есть так же ифы, где я поставил коментарий 
             * //Optimize triangle
             * который означает, что часть этих точек при данном векторе приходит в уже проверенные стороны, а часть не приходит.
             * Это можно так же оптимизировать, просчитав, находится ли проверяемся точка в треугольнике (прямом или равнобедренном),
             * которая ведет в проверенную сторону, и если да - не просчитывать ее. Но на это тоже увы не хватило времени и я не до конца понял,
             * насколько это целесообразно.
             * 
             * Также ВАЖНОЕ уточнение: 
             *      Срезаная точка-угол или просто ОТВЕРСТВИЕ на ребре ОДНОЙ ТОЧКИ НЕ является отверствием, а я считаю это просто сколом на кубе и не учитываю.
             *      (это условие легко добавить, буквально убрав проверку на длину в IsThereAThroughHole в случае чего)
             */


            //_cube[i, j, k]
            // 0 - empty, 1 - filled
            for (int j = 0; j < _sideLenght; j++)
            {
                for (int k = 0; k < _sideLenght; k++)
                {
                    byte currentValue = _cube[0, j, k];
                    if (currentValue == 1) continue;

                    int deltaI;

                    //Check center 0 0
                    deltaI = 1;
                    if (checkLine(0 + deltaI, j, k, deltaI, 0, 0))
                        return true;

                    // check +1 +1
                    if (checkLine(0 + deltaI, j + 1, k + 1, deltaI, 1, +1))
                        return true;

                    // check +1 0
                    if (checkLine(0 + deltaI, j + 1, k, deltaI, 1, 0))
                        return true;

                    // check +1 -1
                    if (checkLine(0 + deltaI, j + 1, k - 1, deltaI, 1, -1))
                        return true;

                    // check 0  -1
                    if (checkLine(0 + deltaI, j, k - 1, deltaI, 0, -1))
                        return true;

                    // check -1  -1
                    if (checkLine(0 + deltaI, j - 1, k - 1, deltaI, -1, -1))
                        return true;

                    // check -1 0
                    if (checkLine(0 + deltaI, j - 1, k, deltaI, -1, 0))
                        return true;

                    // check -1 +1
                    if (checkLine(0 + deltaI, j - 1, k + 1, deltaI, -1, 1))
                        return true;

                    // check 0 +1
                    if (checkLine(0 + deltaI, j, k + 1, deltaI, 0, 1))
                        return true;
                }
            }

            for (int i = 0; i < _sideLenght; i++)
            {
                for (int k = 0; k < _sideLenght; k++)
                {
                    int currentValue = _cube[i, 0, k];

                    if (currentValue == 1) continue;

                    int deltaJ = 1;
                    if (checkLine(i, 0 + deltaJ, k, 0, deltaJ, 0))
                        return true;

                    if (checkLine(i + 1, 0 + deltaJ, k + 1, 1, deltaJ, 1))
                        return true;

                    if (checkLine(i + 1, 0 + deltaJ, k, 1, deltaJ, 0))
                        return true;

                    if (checkLine(i + 1, 0 + deltaJ, k - 1, 1, deltaJ, -1))
                        return true;

                    if (checkLine(i, 0 + deltaJ, k - 1, 0, deltaJ, -1))
                        return true;

                    //Optimize triangle
                    if (checkLine(i - 1, 0 + deltaJ, k - 1, -1, deltaJ, -1))
                        return true;

                    //Optimize triangle
                    if (checkLine(i - 1, 0 + deltaJ, k + 1, -1, deltaJ, 1))
                        return true;

                    if (checkLine(i, 0 + deltaJ, k + 1, 0, deltaJ, 1))
                        return true;
                }
            }

            for (int i = 0; i < _sideLenght; i++)
            {
                for (int j = 0; j < _sideLenght; j++)
                {
                    int currentValue = _cube[i, j, 0];
                    if (currentValue == 1) continue;

                    int deltaK = 1;
                    if (checkLine(i, j, 0 + deltaK, 0, 0, deltaK))
                        return true;

                    if (checkLine(i + 1, j + 1, 0 + deltaK, 1, 1, deltaK))
                        return true;

                    if (checkLine(i + 1, j, 0 + deltaK, 1, 0, deltaK))
                        return true;

                    if (checkLine(i + 1, j - 1, 0 + deltaK, 1, -1, deltaK))
                        return true;

                    //Optimize triangle
                    if (checkLine(i - 1, j - 1, 0 + deltaK, -1, -1, deltaK))
                        return true;

                    //Optimize triangle
                    if (checkLine(i - 1, j + 1, 0 + deltaK, -1, 1, deltaK))
                        return true;

                    if (checkLine(i, j + 1, 0 + deltaK, 0, 1, deltaK))
                        return true;
                }
            }

            for (int j = 0; j < _sideLenght; j++)
            {
                for (int k = 0; k < _sideLenght; k++)
                {
                    int lastI = _sideLenght - 1;
                    byte currentValue = _cube[lastI, j, k];
                    if (currentValue == 1) continue;

                    int deltaI = -1;

                    if (checkLine(lastI + deltaI, j + 1, k + 1, deltaI, 1, 1))
                        return true;

                    //Optimize triangle
                    if (checkLine(lastI + deltaI, j + 1, k, deltaI, 1, 0))
                        return true;

                    if (checkLine(lastI + deltaI, j + 1, k - 1, deltaI, 1, -1))
                        return true;

                    //Optimize
                    if (checkLine(lastI + deltaI, j - 1, k + 1, deltaI, -1, 1))
                        return true;

                    if (checkLine(lastI + deltaI, j, k + 1, deltaI, 0, 1))
                        return true;
                }
            }

            for (int i = 0; i < _sideLenght; i++)
            {
                for (int k = 0; k < _sideLenght; k++)
                {
                    int lastJ = _sideLenght - 1;
                    byte currentValue = _cube[i, lastJ, k];
                    if (currentValue == 1) continue;

                    int deltaJ = -1;

                    if (checkLine(i + 1, lastJ + deltaJ, k + 1, 1, deltaJ, 1))
                        return true;

                    if (checkLine(i - 1, lastJ + deltaJ, k + 1, -1, deltaJ, 1))
                        return true;

                    if (checkLine(i, lastJ + deltaJ, k + 1, 0, deltaJ, 1))
                        return true;

                }
            }

            return false;
        }
    }
}
