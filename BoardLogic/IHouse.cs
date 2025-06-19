// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace BoardLogic;

using System.Drawing;

public interface IHouse
{
    IBox Jail { get; set; }

    Box[] SkyPath { get; set; }

    Box[] Path { get; set; }

    Color Color { get; set; }
}