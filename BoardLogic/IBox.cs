// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace BoardLogic;

public interface IBox
{
    Dictionary<string, int> GetTokensOverview();

    void AddToken(Token token);

    void RemoveAToken(Token token);

    void clearBox();
}