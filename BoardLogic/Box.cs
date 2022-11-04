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

            if (tokensOverview.ContainsKey(token.Color.ToString()))
            {
                tokensOverview[token.Color.ToString()]+=1;
            }
            else 
            {
                tokensOverview.TryAdd(token.Color.ToString(), 1);
            }        
        }

        public void RemoveAToken(Token token)
        {
            if (tokensOverview.TryGetValue(token.Color.ToString(), out int indice))
            {
                if (indice >= 2 )
                {
                    tokensOverview[token.Color.ToString()] -= 1;
                }
                else
                {
                    //id indice = 1, it is remove the color of dictionary
                    tokensOverview.Remove(token.Color.ToString());    
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
