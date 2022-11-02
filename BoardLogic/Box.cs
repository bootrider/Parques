using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    public class Box
    {
        int indice = 0;
        Dictionary<string, int> tokensOverview = new Dictionary<string, int>();    

        public Box(int indice)
        {
            this.indice = indice;
        }
        public Dictionary<string, int> GetTokensOverview()
        {
            return tokensOverview;
        }

        public void AddToken(Token token)
        {

            if(tokensOverview.ContainsKey(token.getColor()))
            {
                tokensOverview[token.getColor()]+=1;
            }
            else 
            {
                tokensOverview.TryAdd(token.getColor(), 1);
            }        
        }

        public void RemoveAToken(Token token)
        {
            if (tokensOverview.TryGetValue(token.getColor(), out int indice))
            {
                if (indice >= 2 )
                {
                    tokensOverview[token.getColor()] -= 1;
                }
                else
                {
                    //si el indice es 1, se elimina el color del dicionario
                    tokensOverview.Remove(token.getColor());    
                }
            }
            //si llega here at else, es por que, es por que el parametro no exite!!. exception
        }

        public void clearBox()
        {
            tokensOverview.Clear();
        }

    }
}
