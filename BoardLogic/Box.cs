using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    public class Box : IBox
    {
        int index = 0;
        //Dictionary<string, int> tokensOverview = new Dictionary<string, int>();
        List<Token> myTokens = new List<Token>();

        public Box(int index)
        {
            this.index = index;
        }

        public Dictionary<string, int> GetTokensOverview()
        {
            var myDict = new Dictionary<string, int>();
            foreach (var token in this.myTokens)
            {
                if (!myDict.TryAdd(token.Color.Name, 1))
                {
                    myDict[token.Color.Name] += 1;
                }
            }
            return myDict;
        }

        public void AddToken(Token token)
        {
            this.myTokens.Add(token);     
        }

        public void RemoveAToken(Token token)
        {
            this.myTokens.Remove(token);
        }

        public void clearBox()
        {
            this.myTokens.Clear();
        }

    }
}
