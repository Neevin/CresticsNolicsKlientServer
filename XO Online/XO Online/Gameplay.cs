using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO_Online
{
    public static class Gameplay
    {
        public static bool isWin(string[,] field, string logo)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (field[i, 0] == logo && field[i, 1] == logo && field[i, 2] == logo) return true;
                if (field[0, i] == logo && field[1, i] == logo && field[2, i] == logo) return true;
            }

            if (field[0, 0] == logo && field[1, 1] == logo && field[2, 2] == logo) return true;

            if (field[2, 0] == logo && field[1, 1] == logo && field[0, 2] == logo) return true;

            return false;
        }
    }
}
