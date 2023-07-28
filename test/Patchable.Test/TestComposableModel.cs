﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Patchable.Test;

public sealed class TestComposableModel : IComposable
{
  public Guid Id { get; set; }

  public string Name { get; set; } = string.Empty;
}