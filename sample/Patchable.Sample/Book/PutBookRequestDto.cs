﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Patchable.Sample.Book;

public record PutBookRequestDto(Guid BookId, string Title, string Description, string[] Authors) : IComposable
{
  internal BookEntity ToBookEntity() => new(BookId, Title, Description, Authors);
}
