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
        //Dictionary<string, int> tokensOverview = new Dictionary<string, int>();
        List<Token> myTokens = new List<Token>();

        public Box(int indice)
        {
            this.indice = indice;
        }

        public Dictionary<string, int> GetTokensOverview()
        {
            var myDict = new Dictionary<string, int>();
            foreach (var token in this.myTokens)
            {
                if (myDict.ContainsKey(token.Color.Name))
                {
                    myDict[token.Color.Name] += 1;
                }
                else
                {
                    myDict.Add(token.Color.Name, 1);
                }                
            }
            return myDict;
        }

        public void AddToken(Token token)
        {
            this.myTokens.Add(token);
            //if (tokensOverview.ContainsKey(token.Color.Name))
            //{
            //    tokensOverview[token.Color.Name]+=1;
            //}
            //else 
            //{
            //    tokensOverview.TryAdd(token.Color.Name, 1);
            //}        
        }

        public void RemoveAToken(Token token)
        {
            this.myTokens.Remove(token);
            //if (tokensOverview.TryGetValue(token.Color.ToString(), out int indice))
            //{
            //    if (indice >= 2 )
            //    {
            //        tokensOverview[token.Color.Name] -= 1;
            //    }
            //    else
            //    {
            //        //id indice = 1, it is remove the color of dictionary
            //        tokensOverview.Remove(token.Color.Name);    
            //    }
            //}
            //si llega here at else, es por que, es por que el parametro no exite!!. exception
        }

        public void clearBox()
        {
            this.myTokens.Clear();
        }

    }
}
