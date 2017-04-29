
using System;
namespace Chess
{
    /// <summary>
    /// Summary description for Board.
    /// </summary>
    public class Board : System.Object
    {
        public int getFundoImagem(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
